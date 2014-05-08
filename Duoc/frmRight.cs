using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	public class frmRight : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData d;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.TextBox txtUserId;
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtRight;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private int i_nhom;
        private string s_userid, user, strRight = "", m_id_copy = "";
        private DataSet adsRight = new DataSet();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private DataGrid dataGrid1;
        private Panel panel5;
        private Splitter splitter1;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Button butAll;
        private Button butKethuc;
        private Button butLuu;
        private Button butHuy;
        private Button butSua;
        private Button butThem;
        private TreeView treeView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_copy;
        private ToolStripMenuItem ToolStripMenuItem_Paste;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private TextBox tim;
        private Label butPastets;
        private Label label5;
        private Label butCopyts;
        private Label label2;
        private ToolTip toolTip1;
        private TextBox txtNodeTextSearch;
        private DataSet ads_Menu = new DataSet();
        public frmRight(AccessData acc, int nhom, string user)
		{
			InitializeComponent();
			d=acc;i_nhom=nhom;s_userid=user;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            f_Load_Tree();
		}
        public frmRight(AccessData acc, int nhom, string user, TreeNode tn)
        {
            InitializeComponent();
            d = acc; i_nhom = nhom; s_userid = user;

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            treeView1.Nodes.Add(tn);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRight));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tim = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel6 = new System.Windows.Forms.Panel();
            this.butAll = new System.Windows.Forms.Button();
            this.butKethuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtNodeTextSearch = new System.Windows.Forms.TextBox();
            this.butPastets = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.butCopyts = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "");
            this.imgList.Images.SetKeyName(1, "");
            this.imgList.Images.SetKeyName(2, "");
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtUserId.Enabled = false;
            this.txtUserId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.Location = new System.Drawing.Point(816, 442);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(208, 23);
            this.txtUserId.TabIndex = 8;
            // 
            // txtRight
            // 
            this.txtRight.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtRight.Enabled = false;
            this.txtRight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRight.Location = new System.Drawing.Point(816, 353);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(320, 23);
            this.txtRight.TabIndex = 13;
            this.txtRight.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 572);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 2);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 570);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 2);
            this.panel3.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGrid1);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 568);
            this.panel4.TabIndex = 19;
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackColor = System.Drawing.SystemColors.Info;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.Highlight;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.ColumnHeadersVisible = false;
            this.dataGrid1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 23);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(321, 545);
            this.dataGrid1.TabIndex = 1;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_copy,
            this.ToolStripMenuItem_Paste});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 48);
            // 
            // ToolStripMenuItem_copy
            // 
            this.ToolStripMenuItem_copy.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_copy.Image")));
            this.ToolStripMenuItem_copy.Name = "ToolStripMenuItem_copy";
            this.ToolStripMenuItem_copy.Size = new System.Drawing.Size(138, 22);
            this.ToolStripMenuItem_copy.Text = "Copy quyền";
            this.ToolStripMenuItem_copy.Click += new System.EventHandler(this.butCopyts_Click);
            // 
            // ToolStripMenuItem_Paste
            // 
            this.ToolStripMenuItem_Paste.Enabled = false;
            this.ToolStripMenuItem_Paste.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_Paste.Image")));
            this.ToolStripMenuItem_Paste.Name = "ToolStripMenuItem_Paste";
            this.ToolStripMenuItem_Paste.Size = new System.Drawing.Size(138, 22);
            this.ToolStripMenuItem_Paste.Text = "Paste quyền";
            this.ToolStripMenuItem_Paste.Click += new System.EventHandler(this.butPastets_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tim);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 23);
            this.panel5.TabIndex = 0;
            // 
            // tim
            // 
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tim.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(0, 0);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(321, 23);
            this.tim.TabIndex = 17;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(323, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 568);
            this.splitter1.TabIndex = 20;
            this.splitter1.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.butAll);
            this.panel6.Controls.Add(this.butKethuc);
            this.panel6.Controls.Add(this.butLuu);
            this.panel6.Controls.Add(this.butHuy);
            this.panel6.Controls.Add(this.butSua);
            this.panel6.Controls.Add(this.butThem);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(328, 540);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(466, 30);
            this.panel6.TabIndex = 21;
            // 
            // butAll
            // 
            this.butAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAll.Image = ((System.Drawing.Image)(resources.GetObject("butAll.Image")));
            this.butAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAll.Location = new System.Drawing.Point(239, 2);
            this.butAll.Name = "butAll";
            this.butAll.Size = new System.Drawing.Size(70, 25);
            this.butAll.TabIndex = 11;
            this.butAll.Text = "Chọn cả";
            this.butAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAll.Click += new System.EventHandler(this.butAll_Click);
            // 
            // butKethuc
            // 
            this.butKethuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKethuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKethuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butKethuc.Image = ((System.Drawing.Image)(resources.GetObject("butKethuc.Image")));
            this.butKethuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKethuc.Location = new System.Drawing.Point(379, 2);
            this.butKethuc.Name = "butKethuc";
            this.butKethuc.Size = new System.Drawing.Size(70, 25);
            this.butKethuc.TabIndex = 13;
            this.butKethuc.Text = "&Kết thúc";
            this.butKethuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKethuc.Click += new System.EventHandler(this.butKethuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(99, 2);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 10;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butHuy
            // 
            this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHuy.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(169, 2);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 9;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butSua
            // 
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(309, 2);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butThem
            // 
            this.butThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(29, 2);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 8;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.treeView1);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(328, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(466, 538);
            this.panel7.TabIndex = 22;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.CheckBoxes = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip2;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 23);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(466, 515);
            this.treeView1.TabIndex = 18;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripSeparator5,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator6,
            this.toolStripMenuItem13,
            this.toolStripSeparator4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(195, 154);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem9.Text = "Lưu phân quyền";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(191, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem1.Text = "Copy quyền";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.butCopyts_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem2.Text = "Paste quyền";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.butPastets_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(191, 6);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem13.Image")));
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem13.Text = "Chọn tất cả";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.butAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(191, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem3.Text = "Mở rông tất cả các nút";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem4.Text = "Đóng tất cả các nút";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtNodeTextSearch);
            this.panel8.Controls.Add(this.butPastets);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.butCopyts);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(466, 23);
            this.panel8.TabIndex = 1;
            // 
            // txtNodeTextSearch
            // 
            this.txtNodeTextSearch.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNodeTextSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNodeTextSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNodeTextSearch.ForeColor = System.Drawing.Color.Red;
            this.txtNodeTextSearch.Location = new System.Drawing.Point(180, 0);
            this.txtNodeTextSearch.Name = "txtNodeTextSearch";
            this.txtNodeTextSearch.Size = new System.Drawing.Size(256, 23);
            this.txtNodeTextSearch.TabIndex = 18;
            this.txtNodeTextSearch.Text = "Tìm kiếm";
            this.txtNodeTextSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNodeTextSearch.TextChanged += new System.EventHandler(this.txtNodeTextSearch_TextChanged);
            this.txtNodeTextSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNodeTextSearch_KeyDown);
            this.txtNodeTextSearch.Enter += new System.EventHandler(this.txtNodeTextSearch_Enter);
            // 
            // butPastets
            // 
            this.butPastets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butPastets.Dock = System.Windows.Forms.DockStyle.Left;
            this.butPastets.Enabled = false;
            this.butPastets.Image = ((System.Drawing.Image)(resources.GetObject("butPastets.Image")));
            this.butPastets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPastets.Location = new System.Drawing.Point(95, 0);
            this.butPastets.Name = "butPastets";
            this.butPastets.Size = new System.Drawing.Size(85, 23);
            this.butPastets.TabIndex = 3;
            this.butPastets.Text = "Paste quyền";
            this.butPastets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.butPastets, "Paste lại user cùng quyền khi copy");
            this.butPastets.Click += new System.EventHandler(this.butPastets_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(90, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(5, 23);
            this.label5.TabIndex = 2;
            // 
            // butCopyts
            // 
            this.butCopyts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butCopyts.Dock = System.Windows.Forms.DockStyle.Left;
            this.butCopyts.Image = ((System.Drawing.Image)(resources.GetObject("butCopyts.Image")));
            this.butCopyts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCopyts.Location = new System.Drawing.Point(10, 0);
            this.butCopyts.Name = "butCopyts";
            this.butCopyts.Size = new System.Drawing.Size(80, 23);
            this.butCopyts.TabIndex = 1;
            this.butCopyts.Text = "Copy quyền";
            this.butCopyts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.butCopyts, "Copy quyền của user cùng cấp");
            this.butCopyts.Click += new System.EventHandler(this.butCopyts_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 23);
            this.label2.TabIndex = 0;
            // 
            // frmRight
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRight);
            this.Controls.Add(this.txtUserId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền sử dụng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRight_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void AddGridTableStyle()
		{
			dataGrid1.TableStyles.Clear();
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
			ts.RowHeadersVisible=false;
			ts.ColumnHeadersVisible=false;
			ts.GridLineColor= Color.White;

			DataGridIconColumn  iconColumn = new DataGridIconColumn(this.imgList,new delegateGetIconIndexForRow(MyGetImageIndexForRow));
			iconColumn.HeaderText = "";
			iconColumn.MappingName = "Icon";
			iconColumn.Width = this.imgList.Images[0].Size.Width;
			ts.GridColumnStyles.Add(iconColumn);
			dataGrid1.TableStyles.Add(ts);
			
			DataGridTextBoxColumn TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "userid";
			TextCol1.HeaderText = "User ID";
			TextCol1.Width = 100;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);		

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "password_";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);	

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "right_";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);	

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "nhomkho";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);	

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "makho";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);	
            //6
			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);	

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "makp";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);	

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "manhom";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);	

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "loaint";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);	

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "loaikhac";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridTextBoxColumn();
            TextCol1.MappingName = "hoten";
            TextCol1.HeaderText = "";
            TextCol1.Width =150;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);	
		}

		public delegate int delegateGetIconIndexForRow(int row);
		public class DataGridIconColumn : DataGridTextBoxColumn
		{
			private ImageList _icons;
			delegateGetIconIndexForRow _getIconIndex;
		
			public DataGridIconColumn(ImageList Icons, delegateGetIconIndexForRow getIconIndex)
			{
				_icons = Icons;
				_getIconIndex = getIconIndex;
			}

			protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible) 
			{ 
				if(this.MappingName == "Icon") return; 
 				base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible); 
			} 

			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					g.FillRectangle(backBrush, bounds);
					g.DrawImage(this._icons.Images[_getIconIndex(rowNum)], bounds);
				}	
				catch{}
			}
		}

		public int MyGetImageIndexForRow(int row)
		{	
			return row % 3;
		}

		private void frmRight_Load(object sender, System.EventArgs e)
		{
            user = d.user;           
			if (i_nhom!=0)
				ds=d.get_data("select * from "+user+".d_dlogin where nhomkho="+i_nhom);
			else
                ds = d.get_data("select * from " + user + ".d_dlogin");
			ds.Tables[0].Columns.Add("Icon");
			AddGridTableStyle();
			dataGrid1.DataSource=ds.Tables[0];
			ref_text();
		}

		private void butKethuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}		
	

		private void luu_right()
		{
			try
			{
                d.upd_dlogin_right(int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 6].ToString()), strRight);
                d.updrec_right(ds.Tables[0], int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 6].ToString()), strRight);
			}
			catch{}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
            frmUser f = new frmUser(d, ds, 0, "", "", "", i_nhom, "", "", true, "", s_userid, "", "");
            f.ShowDialog();
            ds = f.dsright;
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            frmUser f = new frmUser(d, ds, decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 6].ToString()), txtUserId.Text, dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString(), dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString(), int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 4].ToString()), dataGrid1[dataGrid1.CurrentCell.RowNumber, 5].ToString(), dataGrid1[dataGrid1.CurrentCell.RowNumber, 7].ToString(), true, dataGrid1[dataGrid1.CurrentCell.RowNumber, 8].ToString(), s_userid, dataGrid1[dataGrid1.CurrentCell.RowNumber, 9].ToString(), dataGrid1[dataGrid1.CurrentCell.RowNumber, 10].ToString());
            f.ShowDialog();
            ds = f.dsright;
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không được hủy !"),d.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                d.execute_data("delete from " + user + ".d_dlogin where id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 6].ToString()));
				d.delrec(ds.Tables[0],"id="+decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,6].ToString()));
				ds.AcceptChanges();
			}
		}

		private void butAll_Click(object sender, System.EventArgs e)
		{
            butAll.Text = butAll.Text == "Chọn cả" ? "Bỏ cả" : "Chọn cả";
            toolStripMenuItem13.Text = toolStripMenuItem13.Text == "Chọn cả" ? "Bỏ cả" : "Chọn cả";
            if (butAll.Text == "Chọn cả") f_Set_All(false);
            else f_Set_All(true);
		}
        private void f_Set_All(bool bAll)
        {
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    f_Chon_Quyen(anode, bAll);
                }
            }
        }
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ref_text()
		{
			try
			{
				i_nhom=int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,4].ToString());
				txtRight.Text=dataGrid1[dataGrid1.CurrentCell.RowNumber,3].ToString();
				txtUserId.Text=dataGrid1[dataGrid1.CurrentCell.RowNumber,1].ToString();
                f_Set_Right();
			}
			catch{}
		}

        private void tim_Enter(object sender, System.EventArgs e)
        {
            tim.Text = "";
        }

        private void tim_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or userid like '%" + tim.Text.Trim() + "%'";
                ref_text();
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            strRight = "";
            f_Get_Right();
            luu_right();
            butThem.Focus();
        }     
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                {
                    f_Chon_Quyen(e.Node, e.Node.Checked);
                }
            }
            catch
            {
            }
        }
        private void f_Chon_Quyen(TreeNode v_node, bool v_bool)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = v_bool;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode, v_bool);
                    }
                }
            }
            catch
            {
            }
        }

        private void f_Get_Right()
        {
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    f_Get_Right(anode);
                }
            }
        }
        private void f_Get_Right(TreeNode v_node)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    if (anode.Nodes.Count > 0)
                    {
                        f_Get_Right(anode);
                    }
                    else
                    {
                        if (anode.Checked)
                        {
                            strRight += anode.Tag.ToString() + "+";
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Set_Right()
        {
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0) f_Set_Right(anode);
                else
                {
                    if (txtRight.Text.Trim().IndexOf(anode.Tag.ToString() + "+") != -1)
                    {
                        anode.Checked = true;
                    }
                    else anode.Checked = false;
                }
            }
        }
        private void f_Set_Right(TreeNode v_node)
        {

            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    if (anode.Nodes.Count > 0)
                    {
                        f_Set_Right(anode);
                    }
                    else
                    {
                        if (txtRight.Text.Trim().IndexOf(anode.Tag.ToString() + "+") != -1)
                        {
                            anode.Checked = true;
                        }
                        else anode.Checked = false;
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Load_Tree()
        {
            adsRight = d.get_data("select * from " + d.user + ".d_menuitem");
            treeView1.Nodes.Clear();
            TreeNode anode, anode1;
            anode1 = new TreeNode("Chức năng");
            anode1.Tag = "menuChucnang";
            anode1.Name = "menuChucnang";
            treeView1.Nodes.Add(anode1);
            foreach (DataRow r in adsRight.Tables[0].Select("id_goc='-1'", "id"))
            {
                anode = new TreeNode(r["ten"].ToString());
                anode.Tag = r["id_menu"].ToString();
                anode.ForeColor = Color.Black;
                if (adsRight.Tables[0].Select("id_goc=" + anode.Tag.ToString(), "stt").Length > 0)
                {
                    f_Add_Node(anode);
                }
                anode1.Nodes.Add(anode);
            }
            treeView1.ExpandAll();
            treeView1.SelectedNode = anode1;
        }
        private void f_Add_Node(TreeNode v_node)
        {
            try
            {
                TreeNode anode;
                foreach (DataRow r in adsRight.Tables[0].Select("id_goc=" + v_node.Tag.ToString(), "stt"))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["id_menu"].ToString();
                    anode.ForeColor = Color.Black;
                    if (adsRight.Tables[0].Select("id_goc=" + anode.Tag.ToString(), "stt").Length > 0)
                    {
                        f_Add_Node(anode);
                    }
                    v_node.Nodes.Add(anode);
                }
            }
            catch
            {
            }
        }

        private void butCopyts_Click(object sender, EventArgs e)
        {
            f_Copy();
        }
        private void f_Copy()
        {
            try
            {
                string aid = "";
                try
                {
                    aid = txtRight.Text.Trim();
                }
                catch
                {
                    aid = "";
                }
                m_id_copy = aid;
            }
            catch
            {
            }
            finally
            {
                butPastets.Enabled = m_id_copy != "";
                ToolStripMenuItem_Paste.Enabled = m_id_copy != "";
                toolStripMenuItem2.Enabled = m_id_copy != "";
            }
        }

        private void butPastets_Click(object sender, EventArgs e)
        {
            f_Paste();
        }
        private void f_Paste()
        {
            try
            {
                string aid = "", auserid = "";
                try
                {
                    aid = txtRight.Text;
                    auserid = dataGrid1[dataGrid1.CurrentCell.RowNumber, 6].ToString();
                }
                catch
                {
                    aid = "";
                }
                if (m_id_copy != "" && auserid != "")
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý paste quyền cho đối tượng đang chọn!"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        d.execute_data("update medibv.d_dlogin set right_='" + m_id_copy + "' where id=" + auserid + " and nhomkho=" + i_nhom);
                        ref_text(m_id_copy);
                    }
                }
            }
            catch
            {
            }
        }
        private void ref_text(string quyen)
        {
            try
            {
                txtRight.Text = quyen;
                f_Set_Right();
            }
            catch { }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void txtNodeTextSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter) treeView1.Focus();
        }

        private void txtNodeTextSearch_Enter(object sender, System.EventArgs e)
        {
            txtNodeTextSearch.Text = "";
        }
        private void NodeTextSearch()
        {
            ClearBackColor();
            FindByText();
        }
        private void ClearBackColor()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearRecursive(n);
            }
        }
        private void FindByText()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive(n);
            }
        }
        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Text.ToLower().IndexOf(this.txtNodeTextSearch.Text.ToLower().Trim()) != -1)
                    tn.BackColor = Color.Yellow;
                FindRecursive(tn);
            }
        }
        private void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive(tn);
            }
        }
        private void txtNodeTextSearch_TextChanged(object sender, System.EventArgs e)
        {
            NodeTextSearch();
        }
	}
}
