using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for TestForm.
	/// </summary>
	public class frmError : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel1;
		private FolderTreeView treeView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox thumuc;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butKetthuc;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private DataSet ds=new DataSet();
		private AccessData m;

		public frmError(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("My Computer", 2, 3, new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("My Network Places", 4, 5);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("My Documents", 6, 7, new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Recycle Bin", 8, 9);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("C-sharp Corner", 10, 11, new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("New Folder", 12, 13);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Release", 14, 15);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Unsorted", 16, 17, new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Desktop", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode5,
            treeNode6,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("My Computer", 2, 3, new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("My Network Places", 4, 5);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("My Documents", 6, 7, new System.Windows.Forms.TreeNode[] {
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Recycle Bin", 8, 9);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("C-sharp Corner", 10, 11, new System.Windows.Forms.TreeNode[] {
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("New Folder", 12, 13);
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Release", 14, 15);
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Unsorted", 16, 17, new System.Windows.Forms.TreeNode[] {
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Desktop", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode18,
            treeNode19,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("My Computer", 2, 3, new System.Windows.Forms.TreeNode[] {
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("My Network Places", 4, 5);
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("My Documents", 6, 7, new System.Windows.Forms.TreeNode[] {
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Recycle Bin", 8, 9);
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("C-sharp Corner", 10, 11, new System.Windows.Forms.TreeNode[] {
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("New Folder", 12, 13);
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Release", 14, 15);
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Unsorted", 16, 17, new System.Windows.Forms.TreeNode[] {
            treeNode37});
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Desktop", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode31,
            treeNode32,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode38});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmError));
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new Medisoft.FolderTreeView();
            this.thumuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(8, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 264);
            this.panel1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "";
            treeNode1.Text = "";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "";
            treeNode2.SelectedImageIndex = 3;
            treeNode2.Text = "My Computer";
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "";
            treeNode3.SelectedImageIndex = 5;
            treeNode3.Text = "My Network Places";
            treeNode4.Name = "";
            treeNode4.Text = "";
            treeNode5.ImageIndex = 6;
            treeNode5.Name = "";
            treeNode5.SelectedImageIndex = 7;
            treeNode5.Text = "My Documents";
            treeNode6.ImageIndex = 8;
            treeNode6.Name = "";
            treeNode6.SelectedImageIndex = 9;
            treeNode6.Text = "Recycle Bin";
            treeNode7.Name = "";
            treeNode7.Text = "";
            treeNode8.ImageIndex = 10;
            treeNode8.Name = "";
            treeNode8.SelectedImageIndex = 11;
            treeNode8.Text = "C-sharp Corner";
            treeNode9.ImageIndex = 12;
            treeNode9.Name = "";
            treeNode9.SelectedImageIndex = 13;
            treeNode9.Text = "New Folder";
            treeNode10.ImageIndex = 14;
            treeNode10.Name = "";
            treeNode10.SelectedImageIndex = 15;
            treeNode10.Text = "Release";
            treeNode11.Name = "";
            treeNode11.Text = "";
            treeNode12.ImageIndex = 16;
            treeNode12.Name = "";
            treeNode12.SelectedImageIndex = 17;
            treeNode12.Text = "Unsorted";
            treeNode13.ImageIndex = 0;
            treeNode13.Name = "";
            treeNode13.SelectedImageIndex = 0;
            treeNode13.Text = "Desktop";
            treeNode14.Name = "";
            treeNode14.Text = "";
            treeNode15.ImageIndex = 2;
            treeNode15.Name = "";
            treeNode15.SelectedImageIndex = 3;
            treeNode15.Text = "My Computer";
            treeNode16.ImageIndex = 4;
            treeNode16.Name = "";
            treeNode16.SelectedImageIndex = 5;
            treeNode16.Text = "My Network Places";
            treeNode17.Name = "";
            treeNode17.Text = "";
            treeNode18.ImageIndex = 6;
            treeNode18.Name = "";
            treeNode18.SelectedImageIndex = 7;
            treeNode18.Text = "My Documents";
            treeNode19.ImageIndex = 8;
            treeNode19.Name = "";
            treeNode19.SelectedImageIndex = 9;
            treeNode19.Text = "Recycle Bin";
            treeNode20.Name = "";
            treeNode20.Text = "";
            treeNode21.ImageIndex = 10;
            treeNode21.Name = "";
            treeNode21.SelectedImageIndex = 11;
            treeNode21.Text = "C-sharp Corner";
            treeNode22.ImageIndex = 12;
            treeNode22.Name = "";
            treeNode22.SelectedImageIndex = 13;
            treeNode22.Text = "New Folder";
            treeNode23.ImageIndex = 14;
            treeNode23.Name = "";
            treeNode23.SelectedImageIndex = 15;
            treeNode23.Text = "Release";
            treeNode24.Name = "";
            treeNode24.Text = "";
            treeNode25.ImageIndex = 16;
            treeNode25.Name = "";
            treeNode25.SelectedImageIndex = 17;
            treeNode25.Text = "Unsorted";
            treeNode26.ImageIndex = 0;
            treeNode26.Name = "";
            treeNode26.SelectedImageIndex = 0;
            treeNode26.Text = "Desktop";
            treeNode27.Name = "";
            treeNode27.Text = "";
            treeNode28.ImageIndex = 2;
            treeNode28.Name = "";
            treeNode28.SelectedImageIndex = 3;
            treeNode28.Text = "My Computer";
            treeNode29.ImageIndex = 4;
            treeNode29.Name = "";
            treeNode29.SelectedImageIndex = 5;
            treeNode29.Text = "My Network Places";
            treeNode30.Name = "";
            treeNode30.Text = "";
            treeNode31.ImageIndex = 6;
            treeNode31.Name = "";
            treeNode31.SelectedImageIndex = 7;
            treeNode31.Text = "My Documents";
            treeNode32.ImageIndex = 8;
            treeNode32.Name = "";
            treeNode32.SelectedImageIndex = 9;
            treeNode32.Text = "Recycle Bin";
            treeNode33.Name = "";
            treeNode33.Text = "";
            treeNode34.ImageIndex = 10;
            treeNode34.Name = "";
            treeNode34.SelectedImageIndex = 11;
            treeNode34.Text = "C-sharp Corner";
            treeNode35.ImageIndex = 12;
            treeNode35.Name = "";
            treeNode35.SelectedImageIndex = 13;
            treeNode35.Text = "New Folder";
            treeNode36.ImageIndex = 14;
            treeNode36.Name = "";
            treeNode36.SelectedImageIndex = 15;
            treeNode36.Text = "Release";
            treeNode37.Name = "";
            treeNode37.Text = "";
            treeNode38.ImageIndex = 16;
            treeNode38.Name = "";
            treeNode38.SelectedImageIndex = 17;
            treeNode38.Text = "Unsorted";
            treeNode39.ImageIndex = 0;
            treeNode39.Name = "";
            treeNode39.SelectedImageIndex = 0;
            treeNode39.Text = "Desktop";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode26,
            treeNode39});
            this.treeView1.Size = new System.Drawing.Size(336, 264);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // thumuc
            // 
            this.thumuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thumuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thumuc.Enabled = false;
            this.thumuc.Location = new System.Drawing.Point(64, 301);
            this.thumuc.Name = "thumuc";
            this.thumuc.Size = new System.Drawing.Size(280, 20);
            this.thumuc.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(8, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thư mục :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(84, 332);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(90, 28);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "      &Chọn";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(179, 332);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(90, 28);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(172, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến ngày :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(84, 6);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(88, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(236, 6);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(88, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // frmError
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(352, 373);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.thumuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết xuất thông tin lỗi của hệ thống";
            this.Load += new System.EventHandler(this.frmError_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			this.thumuc.Text = this.treeView1.GetSelectedNodePath();
		}

		private void frmError_Load(object sender, System.EventArgs e)
		{
			this.treeView1.InitFolderTreeView();
			this.thumuc.Text=m.get_data("select ten from thongso where id=8").Tables[0].Rows[0][0].ToString();
			bool folderFound = treeView1.DrillToFolder(this.thumuc.Text);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			ds=m.get_data("select * from error where to_date(ngayud,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')");
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không phát hiện lỗi trong khoảng thời gian này !"),LibMedi.AccessData.Msg);
				return;
			}
			ds.WriteXml(thumuc.Text+"//error.xml",XmlWriteMode.WriteSchema);
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
