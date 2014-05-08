using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRight.
	/// </summary>
	public class frmRight : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m;
        private System.Windows.Forms.ImageList imgList;
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtRight;
        private DataSet ds = new DataSet();
        private DataSet adsRight = new DataSet();
        private string strRight = "", m_id_copy = "";
        private ToolTip toolTip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_copy;
        private ToolStripMenuItem ToolStripMenuItem_Paste;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private Splitter splitter1;
        private ToolStrip toolStrip2;
        private ToolStripTextBox txtTimUser;
        private TreeView treeView2;
        private Panel panel4;
        private Button butAll;
        private Button butKethuc;
        private Button butLuu;
        private Button butHuy;
        private Button butSua;
        private Button butThem;
        private Panel panel6;
        private TreeView treeView1;
        private ToolStrip toolStrip1;
        private ToolStripButton butCopyts;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton butPastets;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripTextBox txtNodeTextSearch;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem toolStripMenuItem17;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem toolStripMenuItem13;
        private ImageList imageList1;
        private int i_chinhanh = 0;
		public frmRight(AccessData acc, int _chinhanh)
		{
			InitializeComponent();
            i_chinhanh = _chinhanh;
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            f_Load_Tree();
		}
        public frmRight(AccessData acc,TreeNode tn, int _chinhanh)
        {
            InitializeComponent();
            i_chinhanh = _chinhanh;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc;
            treeView1.Nodes.Add(tn);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRight));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.txtTimUser = new System.Windows.Forms.ToolStripTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.butAll = new System.Windows.Forms.Button();
            this.butKethuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butCopyts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.butPastets = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtNodeTextSearch = new System.Windows.Forms.ToolStripTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_copy,
            this.ToolStripMenuItem_Paste,
            this.toolStripSeparator3,
            this.toolStripMenuItem18,
            this.toolStripMenuItem17});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 98);
            // 
            // ToolStripMenuItem_copy
            // 
            this.ToolStripMenuItem_copy.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_copy.Image")));
            this.ToolStripMenuItem_copy.Name = "ToolStripMenuItem_copy";
            this.ToolStripMenuItem_copy.Size = new System.Drawing.Size(182, 22);
            this.ToolStripMenuItem_copy.Text = "Copy quyền";
            this.ToolStripMenuItem_copy.Click += new System.EventHandler(this.ToolStripMenuItem_copy_Click);
            // 
            // ToolStripMenuItem_Paste
            // 
            this.ToolStripMenuItem_Paste.Enabled = false;
            this.ToolStripMenuItem_Paste.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_Paste.Image")));
            this.ToolStripMenuItem_Paste.Name = "ToolStripMenuItem_Paste";
            this.ToolStripMenuItem_Paste.Size = new System.Drawing.Size(182, 22);
            this.ToolStripMenuItem_Paste.Text = "Paste quyền";
            this.ToolStripMenuItem_Paste.Click += new System.EventHandler(this.ToolStripMenuItem_Paste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem18.Image")));
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem18.Text = "Mở rông tất cả các nút";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.toolStripMenuItem18_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem17.Image")));
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem17.Text = "Đóng tất cả các nút";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.toolStripMenuItem17_Click);
            // 
            // txtRight
            // 
            this.txtRight.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtRight.Enabled = false;
            this.txtRight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRight.Location = new System.Drawing.Point(907, 210);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(147, 23);
            this.txtRight.TabIndex = 13;
            this.txtRight.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "t_icon_ok_ (4).ico");
            this.imageList1.Images.SetKeyName(1, "t_icon_ok_ (5).ico");
            this.imageList1.Images.SetKeyName(2, "t_icon_ok_ (2).ico");
            this.imageList1.Images.SetKeyName(3, "t_icon_ok_ (3).ico");
            this.imageList1.Images.SetKeyName(4, "t_icon_ok_ (286).ICO");
            this.imageList1.Images.SetKeyName(5, "t_icon_ok_ (223).ICO");
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 2);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 570);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 570);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 2);
            this.panel3.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.treeView2);
            this.panel5.Controls.Add(this.toolStrip2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(285, 568);
            this.panel5.TabIndex = 22;
            // 
            // treeView2
            // 
            this.treeView2.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.Location = new System.Drawing.Point(0, 23);
            this.treeView2.Name = "treeView2";
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.Size = new System.Drawing.Size(285, 545);
            this.treeView2.TabIndex = 26;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            this.treeView2.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView2_BeforeSelect);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtTimUser});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(285, 23);
            this.toolStrip2.TabIndex = 25;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // txtTimUser
            // 
            this.txtTimUser.BackColor = System.Drawing.SystemColors.Info;
            this.txtTimUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimUser.Name = "txtTimUser";
            this.txtTimUser.Size = new System.Drawing.Size(100, 21);
            this.txtTimUser.Text = "Tìm nhanh";
            this.txtTimUser.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimUser_KeyDown);
            this.txtTimUser.Enter += new System.EventHandler(this.txtTimUser_Enter);
            this.txtTimUser.TextChanged += new System.EventHandler(this.txtTimUser_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(287, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 568);
            this.splitter1.TabIndex = 23;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.butAll);
            this.panel4.Controls.Add(this.butKethuc);
            this.panel4.Controls.Add(this.butLuu);
            this.panel4.Controls.Add(this.butHuy);
            this.panel4.Controls.Add(this.butSua);
            this.panel4.Controls.Add(this.butThem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(291, 542);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(503, 28);
            this.panel4.TabIndex = 25;
            // 
            // butAll
            // 
            this.butAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAll.Image = ((System.Drawing.Image)(resources.GetObject("butAll.Image")));
            this.butAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAll.Location = new System.Drawing.Point(214, 2);
            this.butAll.Name = "butAll";
            this.butAll.Size = new System.Drawing.Size(70, 25);
            this.butAll.TabIndex = 20;
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
            this.butKethuc.Location = new System.Drawing.Point(354, 2);
            this.butKethuc.Name = "butKethuc";
            this.butKethuc.Size = new System.Drawing.Size(70, 25);
            this.butKethuc.TabIndex = 22;
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
            this.butLuu.Location = new System.Drawing.Point(74, 2);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 19;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butHuy
            // 
            this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHuy.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(144, 2);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 18;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butSua
            // 
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(284, 2);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 21;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butThem
            // 
            this.butThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(4, 2);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 17;
            this.butThem.Text = "     &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.treeView1);
            this.panel6.Controls.Add(this.toolStrip1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(291, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(503, 540);
            this.panel6.TabIndex = 26;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip2;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 23);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(503, 517);
            this.treeView1.TabIndex = 25;
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
            this.contextMenuStrip2.Size = new System.Drawing.Size(183, 154);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem9.Text = "Lưu phân quyền";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem1.Text = "Copy quyền";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.butCopyts_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem2.Text = "Paste quyền";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.butPastets_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem13.Image")));
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem13.Text = "Chọn tất cả";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.butAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem3.Text = "Mở rông tất cả các nút";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem4.Text = "Đóng tất cả các nút";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butCopyts,
            this.toolStripSeparator1,
            this.butPastets,
            this.toolStripSeparator2,
            this.txtNodeTextSearch});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(503, 23);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butCopyts
            // 
            this.butCopyts.Image = ((System.Drawing.Image)(resources.GetObject("butCopyts.Image")));
            this.butCopyts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butCopyts.Name = "butCopyts";
            this.butCopyts.Size = new System.Drawing.Size(85, 20);
            this.butCopyts.Text = "Copy quyền";
            this.butCopyts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCopyts.ToolTipText = "Copy quyền của user cùng cấp";
            this.butCopyts.Click += new System.EventHandler(this.butCopyts_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // butPastets
            // 
            this.butPastets.Enabled = false;
            this.butPastets.Image = ((System.Drawing.Image)(resources.GetObject("butPastets.Image")));
            this.butPastets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butPastets.Name = "butPastets";
            this.butPastets.Size = new System.Drawing.Size(87, 20);
            this.butPastets.Text = "Paste quyền";
            this.butPastets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPastets.ToolTipText = "Paste lại user cùng quyền khi copy";
            this.butPastets.Click += new System.EventHandler(this.butPastets_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // txtNodeTextSearch
            // 
            this.txtNodeTextSearch.BackColor = System.Drawing.SystemColors.Info;
            this.txtNodeTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNodeTextSearch.Name = "txtNodeTextSearch";
            this.txtNodeTextSearch.Size = new System.Drawing.Size(100, 21);
            this.txtNodeTextSearch.Text = "Tìm nhanh";
            this.txtNodeTextSearch.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNodeTextSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNodeTextSearch_KeyDown);
            this.txtNodeTextSearch.Enter += new System.EventHandler(this.txtNodeTextSearch_Enter);
            this.txtNodeTextSearch.TextChanged += new System.EventHandler(this.txtNodeTextSearch_TextChanged);
            // 
            // frmRight
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền sử dụng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRight_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
		private void frmRight_Load(object sender, System.EventArgs e)
		{
            f_Load_User();
            ds = m.get_data("select * from medibv.dlogin where chinhanh in(0," + i_chinhanh + ")");
            treeView2.Focus();
		}

		private void butKethuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}		
	
		private void luu_right()
		{
            string aid = "";
            try
            {
                int i = treeView2.SelectedNode.Parent == null ? 0 : 1;
                aid = treeView2.SelectedNode.Tag.ToString().Split(':')[i];
            }
            catch
            {
                aid = "";
            }

			try
			{
				m.upd_dlogin(int.Parse(aid),strRight);
                m.updrec(ds.Tables[0], int.Parse(aid), "", "", strRight);
			}
			catch{}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
            frmUser f = new frmUser(m, ds, 0, "", "", "");
            f.ShowDialog();
            ds = f.dsright;
            f_Load_User();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            string aid = "";
            try
            {
                int i = treeView2.SelectedNode.Parent == null ? 0 : 1;
                aid = treeView2.SelectedNode.Tag.ToString().Split(':')[i];
            }
            catch
            {
                aid = "0";
            }
            frmUser f = new frmUser(m, ds, int.Parse(aid), f_Get_Userid(aid), f_Get_Pass(aid), f_Get_Right(aid));
            f.ShowDialog();
            ds = f.dsright;
            f_Load_User();
		}
        private string f_Get_Pass(string s_userid)
        {
            try
            {
                return m.get_data("select password_ from medibv.dlogin where id=" + s_userid + "").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }
        private string f_Get_Userid(string s_userid)
        {
            try
            {
                return m.get_data("select userid from medibv.dlogin where id=" + s_userid + "").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }
		private void butHuy_Click(object sender, System.EventArgs e)
		{
            string aid = "";
            try
            {
                int i = treeView2.SelectedNode.Parent == null ? 0 : 1;
                aid = treeView2.SelectedNode.Tag.ToString().Split(':')[i];
            }
            catch
            {
                aid = "0";
            }

            if (m.get_data("select * from " + m.user + ".btdbn where userid=" + int.Parse(aid)).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người dùng đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
			if (ds.Tables[0].Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không được hủy !"),LibMedi.AccessData.Msg);
				return;
			}

			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.execute_data("delete from " + m.user + ".dlogin where id=" + int.Parse(aid));
				m.delrec(ds.Tables[0],"id="+int.Parse(aid));
				ds.AcceptChanges();
			}
		}
		private void butAll_Click(object sender, System.EventArgs e)
		{
            butAll.Text = butAll.Text == "Chọn cả" ? "Bỏ cả" : "Chọn cả";
            toolStripMenuItem13.Text = butAll.Text;
            if (butAll.Text == "Chọn cả") f_Set_All(false);
            else f_Set_All(true);
		}

        private void f_Chon_Quyen(TreeNode v_node, bool v_bool)
        {
            try
            {
                //foreach (TreeNode anode in v_node.Nodes)
                //{
                //    anode.Checked = v_bool;
                //    if (anode.Nodes.Count > 0)
                //    {
                //        f_Chon_Quyen(anode, v_bool);
                //    }

                //}
                //Loan 23.02.20413


                if (v_node.Nodes.Count > 0)
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
                else//Loan 23.02.2013
                {
                    v_node.Checked = v_bool;
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
            string[] arRight = txtRight.Text.Split('+');

            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0) f_Set_Right(anode);
                else
                {
                    //if (txtRight.Text.Trim().IndexOf(anode.Tag.ToString() + "+") != -1)
                    //{
                    //    anode.Checked = true;
                    //}
                    //else 
                    //    anode.Checked = false;
                    //Thuy 23.02.2013
                    foreach (string s_tmp in arRight)
                    {
                        anode.Checked = anode.Tag.ToString() == s_tmp;
                        if (anode.Checked)
                            break;
                    }
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
                        //if (txtRight.Text.Trim().IndexOf(anode.Tag.ToString() + "+") != -1)
                        //{
                        //    anode.Checked = true;
                        //}
                        //else 
                        //    anode.Checked = false;
                        string[] arRight = txtRight.Text.Split('+');
                        foreach (string s_tmp in arRight)
                        {
                            anode.Checked = anode.Tag.ToString() == s_tmp;
                            if(anode.Checked)
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
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
        private void f_Load_Tree()
        {
            adsRight = m.get_data("select * from " + m.user + ".m_menuitem");
            treeView1.Nodes.Clear();
            TreeNode anode, anode1;
            anode1 = new TreeNode("Chức năng");
            anode1.Tag = "menuChucnang";
            anode1.Name = "menuChucnang";
            treeView1.Nodes.Add(anode1);
            foreach (DataRow r in adsRight.Tables[0].Select("id_goc='-1'", "id"))
            {
                anode = new TreeNode(r["ten"].ToString());
                anode.Tag = r["id_menu"].ToString().Trim();
                anode.ForeColor = Color.Black;
                if (adsRight.Tables[0].Select("id_goc='" + anode.Tag.ToString() + "'", "stt").Length > 0) 
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
                foreach (DataRow r in adsRight.Tables[0].Select("id_goc='" + v_node.Tag.ToString() + "'", "stt")) 
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["id_menu"].ToString().Trim();
                    anode.ForeColor = Color.Black;
                    if (adsRight.Tables[0].Select("id_goc='" + anode.Tag.ToString() + "'", "stt").Length > 0) 
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
        private void butLuu_Click(object sender, EventArgs e)
        {
            strRight = "";
            f_Get_Right();
            luu_right();
            butThem.Focus();
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
                    auserid = treeView2.SelectedNode.Tag.ToString().Split(':')[treeView2.SelectedNode.Parent == null ? 0 : 1];
                }
                catch
                {
                    aid = "";
                }
                if (m_id_copy != ""  && auserid != "") 
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý paste quyền cho đối tượng đang chọn!"),LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        m.execute_data("update medibv.dlogin set right_='" + m_id_copy + "' where id=" + auserid + "");
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
        #region TIM TREEVIEW
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
        //------------------------------------
        private void txtTimUser_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter) treeView2.Focus();
        }

        private void txtTimUser_Enter(object sender, System.EventArgs e)
        {
            txtTimUser.Text = "";
        }
        private void NodeTextSearch1()
        {
            ClearBackColor1();
            FindByText1();
        }
        private void ClearBackColor1()
        {
            TreeNodeCollection nodes = treeView2.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearRecursive1(n);
            }
        }
        private void ClearRecursive1(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive1(tn);
            }
        }
        private void FindByText1()
        {
            TreeNodeCollection nodes = treeView2.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive1(n);
            }
        }
        private void FindRecursive1(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Text.ToLower().IndexOf(this.txtTimUser.Text.ToLower().Trim()) != -1)
                    tn.BackColor = Color.Yellow;
                FindRecursive1(tn);
            }
        }

        private void txtTimUser_TextChanged(object sender, System.EventArgs e)
        {
            NodeTextSearch1();
        }
        #endregion

        private void ToolStripMenuItem_copy_Click(object sender, EventArgs e)
        {
            f_Copy();
        }

        private void ToolStripMenuItem_Paste_Click(object sender, EventArgs e)
        {
            f_Paste();
        }

        private void f_Load_User()
        {
            try
            {
                TreeNode anode, anode1;
                treeView2.Nodes.Clear();
                treeView2.ItemHeight = 18;
                string sql = "";
                foreach (DataRow r in f_NhomDlogin().Tables[0].Rows)
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["id"].ToString();
                    anode.ImageIndex = (r["id"].ToString() == "0" || r["id"].ToString() == "1") ? 0 : 1;
                    anode.SelectedImageIndex = anode.ImageIndex;
                    treeView2.Nodes.Add(anode);
                    sql = "select * from medibv.dlogin where 1=1 ";//where chinhanh in(0," + i_chinhanh + ") order by hoten";
                    if (i_chinhanh > 0) sql += " and chinhanh=" + i_chinhanh;
                    //sql += " and id>0";
                    sql += " order by hoten ";
                    foreach (DataRow r1 in m.get_data(sql).Tables[0].Select("manhom=" + r["id"].ToString() + "")) 
                    {
                        anode1 = new TreeNode(r1["hoten"].ToString() + " ( " + r1["userid"].ToString() + " )");
                        anode1.Tag = r["id"].ToString() + ":" + r1["id"].ToString();
                        anode1.ImageIndex = (r["id"].ToString() == "0" || r["id"].ToString() == "1") ? 2 : 3;
                        anode1.SelectedImageIndex = anode1.ImageIndex;
                        anode.Nodes.Add(anode1);
                    }
                }
                anode = new TreeNode(lan.Change_language_MessageText("Nhóm hệ thống"));
                anode.Tag = "-1:?";
                anode.ImageIndex = 4;
                anode.SelectedImageIndex = 4;
                treeView2.Nodes.Add(anode);

                anode1 = new TreeNode(lan.Change_language_MessageText("Quản trị hệ thống"));
                anode1.Tag = "-1:-1";
                anode1.ImageIndex = 5;
                anode1.SelectedImageIndex = 5;
                anode.Nodes.Add(anode1);

                anode1 = new TreeNode(lan.Change_language_MessageText("Quản trị khoa phòng"));
                anode1.Tag = "-1:-2";
                anode1.ImageIndex = 5;
                anode1.SelectedImageIndex = 5;
                anode.Nodes.Add(anode1);

                anode1 = new TreeNode(lan.Change_language_MessageText("Người dùng"));
                anode1.Tag = "-1:-3";
                anode1.ImageIndex = 5;
                anode1.SelectedImageIndex = 5;
                anode.Nodes.Add(anode1);

                anode1 = new TreeNode(lan.Change_language_MessageText("Nhập liệu khoa/phòng"));
                anode1.Tag = "-1:-4";
                anode1.ImageIndex = 5;
                anode1.SelectedImageIndex = 5;
                anode.Nodes.Add(anode1);

                treeView2.ExpandAll();
            }
            catch
            { 
            }
        }
        private DataSet f_NhomDlogin()
        {
            DataSet ads_nhom = new DataSet();
            try
            {
                ads_nhom.Tables.Add("Table");
                ads_nhom.Tables[0].Columns.Add("id");
                ads_nhom.Tables[0].Columns.Add("ten");
                ads_nhom.Tables[0].Rows.Add(new string[] { "0", "Quản trị hệ thống" });
                ads_nhom.Tables[0].Rows.Add(new string[] { "1", "Quản trị khoa phòng" });
                ads_nhom.Tables[0].Rows.Add(new string[] { "2", "Người dùng" });
                ads_nhom.Tables[0].Rows.Add(new string[] { "3", "Nhập liệu khoa/phòng" });                                 
            }
            catch
            {
 
            }
            return ads_nhom;
        }

        private string f_Get_Right(string s_userid)
        {
            try
            {

                return m.get_data("select right_ from medibv.dlogin where id=" + s_userid + " and chinhanh in(0," + i_chinhanh + ")").Tables[0].Rows[0][0].ToString();
            }
            catch { return ""; }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string aid = treeView2.SelectedNode.Tag.ToString().Split(':')[treeView2.SelectedNode.Parent == null ? 0 : 1];
                
                txtRight.Text = f_Get_Right(aid);
                f_Set_Right();

                e.Node.ForeColor = Color.Red;
            }
            catch
            {
            }
        }

        private void treeView2_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeView2.SelectedNode.ForeColor = Color.Black;
            }
            catch
            {
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            treeView2.ExpandAll();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            treeView2.CollapseAll();
        }
	}
}
