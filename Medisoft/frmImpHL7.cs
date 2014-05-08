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
	public class frmImpHL7 : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel1;
		private FolderTreeView treeView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox thumuc;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbl;
		private AccessData m;
		private System.ComponentModel.IContainer components;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private DataTable dttt=new DataTable();
		private DataTable dtqu=new DataTable();
		private DataTable dtpx=new DataTable();
		private int i_userid,pos,len,i_tuoi;
		private string tenfile,mabn,file;
		private string pid_5,pid_11_1,pid_11_2,pid_30,nk1_2,nk1_3,nk1_4,pv1_7_2,pv1_8_2,pv1_17_2,pr1_4,pr1_12,dg1_4_1,dg1_4_2,dg1_4_3,dg1_4_4,dg1_4_5,add_2,dg1_4_6,dg1_4_7,dg1_4_8;
		private string pid_12,dg1_4_3_2,dg1_4_3_3,add_20,dg1_4_3_1,dg1_4_3_4;
		private string pid_7_1,pid_29,pv1_44,pv1_45,pr1_5,in1_13,acc_1,pv1_44_1,add_13,add_14,add_18;
		private string pv1_46,pv1_47,add_17,add_19;
		private decimal l_id,l_maql;
		private DataRow r1,r2,r3;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton unicode;
		private System.Windows.Forms.RadioButton tcvn3;
		private System.Windows.Forms.CheckedListBox listBox1;
		public frmImpHL7(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			i_userid=userid;
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
            this.components = new System.ComponentModel.Container();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpHL7));
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new Medisoft.FolderTreeView();
            this.thumuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tcvn3 = new System.Windows.Forms.RadioButton();
            this.unicode = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(8, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 290);
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
            this.treeView1.Size = new System.Drawing.Size(238, 290);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // thumuc
            // 
            this.thumuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thumuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thumuc.Enabled = false;
            this.thumuc.Location = new System.Drawing.Point(64, 333);
            this.thumuc.Name = "thumuc";
            this.thumuc.Size = new System.Drawing.Size(584, 20);
            this.thumuc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(8, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thư mục :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(237, 389);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(91, 28);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "      &Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(329, 389);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(94, 28);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Đang cập nhật số liệu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Blue;
            this.lbl.Location = new System.Drawing.Point(128, 360);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 14);
            this.lbl.TabIndex = 4;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.Location = new System.Drawing.Point(248, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(400, 292);
            this.listBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcvn3);
            this.groupBox1.Controls.Add(this.unicode);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 36);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng mã";
            // 
            // tcvn3
            // 
            this.tcvn3.Checked = true;
            this.tcvn3.Location = new System.Drawing.Point(144, 10);
            this.tcvn3.Name = "tcvn3";
            this.tcvn3.Size = new System.Drawing.Size(64, 24);
            this.tcvn3.TabIndex = 1;
            this.tcvn3.TabStop = true;
            this.tcvn3.Text = "TCVN3";
            // 
            // unicode
            // 
            this.unicode.Location = new System.Drawing.Point(56, 10);
            this.unicode.Name = "unicode";
            this.unicode.Size = new System.Drawing.Size(72, 24);
            this.unicode.TabIndex = 0;
            this.unicode.Text = "Unicode";
            // 
            // frmImpHL7
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(656, 429);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.thumuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImpHL7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thu nhập số liệu từ HL7";
            this.Load += new System.EventHandler(this.frmImpHL7_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			this.thumuc.Text = this.treeView1.GetSelectedNodePath();
			try
			{
				listBox1.Items.Clear();
				string [] files=Directory.GetFiles(this.thumuc.Text);
				for(int i=0;i<files.GetLength(0);i++)
				{
					listBox1.Items.Add(files[i].ToString());
					if (files[i].ToString().ToUpper().IndexOf("HL7")!=-1 && files[i].ToString().ToUpper().IndexOf(".XML")!=-1)
						listBox1.SetItemCheckState(i,CheckState.Checked);
				}
			}
			catch{}
		}

		private void frmImpHL7_Load(object sender, System.EventArgs e)
		{
			dttt=m.get_data("select * from btdtt").Tables[0];
			dtqu=m.get_data("select * from btdquan").Tables[0];
			dtpx=m.get_data("select * from btdpxa").Tables[0];
			dsxml.ReadXml("..//..//..//xml//thongso.xml");
			unicode.Checked=m.Thongso("unicode")=="1";
			tcvn3.Checked=!unicode.Checked;
			this.treeView1.InitFolderTreeView();
			this.thumuc.Text=m.get_data("select ten from thongso where id=7").Tables[0].Rows[0][0].ToString();
			bool folderFound = treeView1.DrillToFolder(this.thumuc.Text);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				m.upd_thongso(7,"ten",thumuc.Text.ToString().Trim());
				dsxml.Tables[0].Rows[0]["unicode"]=(unicode.Checked)?1:0;
				dsxml.Tables[0].Rows[0]["tcvn3"]=(tcvn3.Checked)?1:0;
				dsxml.WriteXml("..//..//..//xml//thongso.xml");
				if (listBox1.Items.Count==0) return;
				for(int k=0;k<listBox1.Items.Count;k++)
				{
					if (listBox1.GetItemChecked(k))
					{
						tenfile=listBox1.Items[k].ToString().Trim();
						pos=tenfile.LastIndexOf("//")+1;
						len=tenfile.Length;
						file=tenfile.Substring(pos,len-pos).ToUpper();
						switch (file)
						{
							case "HL7.XML": upd_hl7();
								break;
							case "HL7_A02.XML": upd_hl7_a02();
								break;
							case "HL7_ADD.XML": upd_hl7_add();
								break;
						}
					}
				}
				if (listBox1.Items.Count!=0) MessageBox.Show(lan.Change_language_MessageText("Thu nhập số liệu xong !"),LibMedi.AccessData.Msg);
			}
			catch(Exception ex){MessageBox.Show(ex.Message,LibMedi.AccessData.Msg);}
		}

		private void upd_hl7()
		{
			if (File.Exists(tenfile))
			{
				ds=new DataSet();
				ds.ReadXml(tenfile);
				try
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						l_maql=decimal.Parse(r["pv1_19"].ToString());
						mabn=r["pid_3"].ToString();
						i_tuoi=DateTime.Now.Year-int.Parse(r["pid_7_2"].ToString());
						pos=mabn.IndexOf("/");
						if (pos!=-1) mabn=mabn.Substring(pos+1).Trim().PadLeft(2,'0')+mabn.Substring(0,pos-1).Trim().PadLeft(6,'0');
						else mabn=mabn.Substring(1).PadLeft(8,'0');
						pid_5=(tcvn3.Checked)?m.abc_uni(r["pid_5"].ToString()):r["pid_5"].ToString();
						pid_11_1=(tcvn3.Checked)?m.abc_uni(r["pid_11_1"].ToString()):r["pid_11_1"].ToString();
						pid_11_2=(tcvn3.Checked)?m.abc_uni(r["pid_11_2"].ToString()):r["pid_11_2"].ToString();
						pid_30=(tcvn3.Checked)?m.abc_uni(r["pid_30"].ToString()):r["pid_30"].ToString();
						nk1_2=(tcvn3.Checked)?m.abc_uni(r["nk1_2"].ToString()):r["nk1_2"].ToString();
						nk1_3=(tcvn3.Checked)?m.abc_uni(r["nk1_3"].ToString()):r["nk1_3"].ToString();
						nk1_4=(tcvn3.Checked)?m.abc_uni(r["nk1_4"].ToString()):r["nk1_4"].ToString();
						pv1_7_2=(tcvn3.Checked)?m.abc_uni(r["pv1_7_2"].ToString()):r["pv1_7_2"].ToString();
						pv1_17_2=(tcvn3.Checked)?m.abc_uni(r["pv1_17_2"].ToString()):r["pv1_17_2"].ToString();
						pv1_8_2=(tcvn3.Checked)?m.abc_uni(r["pv1_8_2"].ToString()):r["pv1_8_2"].ToString();
						pr1_4=(tcvn3.Checked)?m.abc_uni(r["pr1_4"].ToString()):r["pr1_4"].ToString();
						pr1_12=(tcvn3.Checked)?m.abc_uni(r["pr1_12"].ToString()):r["pr1_12"].ToString();
						dg1_4_1=(tcvn3.Checked)?m.abc_uni(r["dg1_4_1"].ToString()):r["dg1_4_1"].ToString();
						dg1_4_2=(tcvn3.Checked)?m.abc_uni(r["dg1_4_2"].ToString()):r["dg1_4_2"].ToString();
						dg1_4_3=(tcvn3.Checked)?m.abc_uni(r["dg1_4_3"].ToString()):r["dg1_4_3"].ToString();
						dg1_4_4=(tcvn3.Checked)?m.abc_uni(r["dg1_4_4"].ToString()):r["dg1_4_4"].ToString();
						dg1_4_5=(tcvn3.Checked)?m.abc_uni(r["dg1_4_5"].ToString()):r["dg1_4_5"].ToString();
						add_2=(tcvn3.Checked)?m.abc_uni(r["add_2"].ToString()):r["add_2"].ToString();
						dg1_4_6=(tcvn3.Checked)?m.abc_uni(r["dg1_4_6"].ToString()):r["dg1_4_6"].ToString();
						dg1_4_7=(tcvn3.Checked)?m.abc_uni(r["dg1_4_7"].ToString()):r["dg1_4_7"].ToString();
						dg1_4_8=(tcvn3.Checked)?m.abc_uni(r["dg1_4_8"].ToString()):r["dg1_4_8"].ToString();
						dg1_4_3_1=(tcvn3.Checked)?m.abc_uni(r["dg1_4_3_1"].ToString()):r["dg1_4_3_1"].ToString();
						dg1_4_3_4=(tcvn3.Checked)?m.abc_uni(r["dg1_4_3_4"].ToString()):r["dg1_4_3_4"].ToString();
						pid_12=r["pid_12"].ToString().Trim().PadRight(7,'0');
						if (r["pid_7_1"].ToString()!="")
							pid_7_1=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pid_7_1"].ToString()));
						else pid_7_1="";
						if (r["pid_29"].ToString()!="")
							pid_29=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pid_29"].ToString()));
						else pid_29="";
						if (r["pv1_44"].ToString()!="")
							pv1_44=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pv1_44"].ToString()));
						else pv1_44="";
						if (r["pv1_45"].ToString()!="")
							pv1_45=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pv1_45"].ToString()));
						else pv1_45="";
						if (r["pr1_5"].ToString()!="")
							pr1_5=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pr1_5"].ToString()));
						else pr1_5="";
						if (r["in1_13"].ToString()!="")
							in1_13=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["in1_13"].ToString()));
						else in1_13="";
						if (r["acc_1"].ToString()!="")
							acc_1=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["acc_1"].ToString()));
						else acc_1="";
						if (r["pv1_44_1"].ToString()!="")
							pv1_44_1=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pv1_44_1"].ToString()));
						else pv1_44_1="";
						if (r["add_13"].ToString()!="")
							add_13=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["add_13"].ToString()));
						else add_13="";
						if (r["add_14"].ToString()!="")
							add_14=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["add_14"].ToString()));
						else add_14="";
						if (r["add_18"].ToString()!="")
							add_18=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["add_18"].ToString()));
						else add_18="";
						lbl.Text="HL7->"+mabn+" ("+pid_5+")";
						lbl.Refresh();

						r1=m.getrowbyid(dttt,"matt='"+pid_12.Substring(0,3)+"'");
						if (r1==null) m.upd_btdtt("btdtt",pid_12.Substring(0,1),pid_12.Substring(0,3),"Mới");
						r2=m.getrowbyid(dtqu,"maqu='"+pid_12.Substring(0,5)+"'");
						if (r2==null) m.upd_btdquan("btdquan",pid_12.Substring(0,3),pid_12.Substring(0,5),"Mới");
						r3=m.getrowbyid(dtpx,"maphuongxa='"+pid_12+"'");
						if (r3==null) m.upd_btdpxa("btdpxa",pid_12.Substring(0,5),pid_12,"Mới","MMM");

						m.imp_benhandt(mabn,l_maql,r["pv1_3_1"].ToString().PadLeft(2,'0'),
							pv1_44,int.Parse(r["pv1_6"].ToString()),int.Parse(r["pv1_14"].ToString()),int.Parse(r["pv1_13"].ToString()),
							int.Parse(r["pv1_20"].ToString()),dg1_4_1,r["dg1_3_1"].ToString(),
							r["pv1_17_1"].ToString(),r["pid_18"].ToString(),int.Parse(r["pv1_2"].ToString()),i_userid);

						m.upd_dmbs(r["pv1_17_1"].ToString(),pv1_17_2,"","",0,r["pv1_17_1"].ToString(),0);
						
						m.imp_nhapkhoa(l_maql,mabn,l_maql,r["pv1_3_1"].ToString().PadLeft(2,'0'),1,pv1_44,
							i_tuoi.ToString().PadLeft(3,'0')+"0",r["pv1_3_3"].ToString(),"01",dg1_4_1,r["dg1_3_1"].ToString(),r["pv1_17_1"].ToString(),1,i_userid);

						if (r["in1_2"].ToString()!="")
                            m.upd_bhyt(pv1_44,mabn, l_maql, r["in1_2"].ToString(), in1_13, r["in1_10"].ToString(),0,"","","","",0);

						m.upd_btdbn(mabn,pid_5,pid_7_1,r["pid_7_2"].ToString(),int.Parse(r["pid_8"].ToString()),r["add_1"].ToString(),
							r["pid_22"].ToString(),pid_11_1,pid_11_2,add_2,pid_12.Substring(0,3),pid_12.Substring(0,5),pid_12,i_userid);

						m.upd_lienhe(l_maql,pid_11_1,pid_11_2,add_2,pid_12.Substring(0,3),pid_12.Substring(0,5),pid_12,i_tuoi.ToString().PadLeft(3,'0')+"0",0,0);

						if (r["pv1_45"].ToString()!="")
						{					
							m.imp_xuatkhoa(l_maql,pv1_45,int.Parse(r["add_3"].ToString()),int.Parse(r["add_4"].ToString()),
								dg1_4_2,r["dg1_3_2"].ToString(),r["pv1_7_1"].ToString(),
								int.Parse(r["add_5"].ToString()),int.Parse(r["add_6"].ToString()),int.Parse(r["add_7"].ToString()),i_userid);
							m.imp_xuatvien(mabn,l_maql,r["pv1_10"].ToString().PadLeft(2,'0'),pv1_45,
								int.Parse(r["add_3"].ToString()),int.Parse(r["add_4"].ToString()),
								dg1_4_2,r["dg1_3_2"].ToString(),r["pv1_7_1"].ToString(),
								r["pid_4"].ToString(),int.Parse(r["add_5"].ToString()),int.Parse(r["add_6"].ToString()),int.Parse(r["add_7"].ToString()),i_userid);
							m.upd_dmbs(r["pv1_7_1"].ToString(),pv1_7_2,"","",0,r["pv1_7_1"].ToString(),0);
						}
						if (r["dg1_4_3_1"].ToString()!="")
							m.upd_cdkemtheo(l_maql,l_maql,1,dg1_4_3_1,r["dg1_3_3_1"].ToString(),1);
						if (r["dg1_4_3_4"].ToString()!="")
							m.upd_cdkemtheo(l_maql,l_maql,4,dg1_4_3_4,r["dg1_3_3_4"].ToString(),1);
						if (r["add_18"].ToString()!="")
							m.upd_cdsankhoa(l_maql,add_18,int.Parse(r["add_20"].ToString()),"");

						if (r["dg1_4_9"].ToString()+r["dg1_4_10"].ToString()+r["dg1_4_11"].ToString()+r["dg1_4_12"].ToString()!="")
							m.upd_cdungbuou(l_maql,l_maql,r["dg1_3_9"].ToString(),r["dg1_3_10"].ToString(),r["dg1_3_11"].ToString(),r["dg1_3_12"].ToString(),r["dg1_4_9"].ToString(),r["dg1_4_10"].ToString(),r["dg1_4_11"].ToString(),r["dg1_4_12"].ToString());

						if (r["pv1_37_1"].ToString()!="")
							m.upd_chuyenvien(l_maql,r["pv1_37_1"].ToString(),int.Parse(r["pv1_37_2"].ToString()));

						if (r["dg1_4_5"].ToString()!="")
							m.upd_noigioithieu(m.Ngayhienhanh,l_maql,"",dg1_4_5,r["dg1_3_5"].ToString());

						if (r["pid_28"].ToString()!="")
							m.upd_nuocngoai(mabn,r["pid_28"].ToString());

						if (r["pv1_44_1"].ToString()!="")
							m.upd_ngaykb(l_maql,mabn,pv1_44_1);
						if (r["nk1_3"].ToString()!="")
							m.upd_quanhe(l_maql,nk1_3,nk1_2,nk1_4,r["nk1_5"].ToString());
						if (r["pr1_5"].ToString()!="")
						{
							l_id=decimal.Parse(r["pr1_1"].ToString());
							m.upd_pttt(l_id,mabn,0,l_maql,r["add_9"].ToString().PadLeft(2,'0'),decimal.Parse(r["add_8"].ToString()),pr1_5,
								dg1_4_6,r["dg1_3_6"].ToString(),dg1_4_7,
								r["dg1_3_7"].ToString(),r["pr1_3"].ToString(),pr1_4,
								r["pr1_9"].ToString(),int.Parse(r["add_10"].ToString()),r["pr1_11"].ToString(),int.Parse(r["add_11"].ToString()),
								int.Parse(r["add_12"].ToString()),i_userid);
							m.upd_dmbs(r["pr1_11"].ToString(),pr1_12,"","",0,r["pr1_11"].ToString(),0);
						}
						if (r["dg1_4_8"].ToString()!="")
						{
							m.upd_tuvong(l_maql,add_13,add_14,dg1_4_8,r["dg1_3_8"].ToString(),
								int.Parse(r["add_15"].ToString()),"",int.Parse(r["add_15"].ToString()),
								int.Parse(r["add_17"].ToString()),i_userid);
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message,"HL7");
				}
			}
		}

		private void upd_hl7_a02()
		{
			if (File.Exists(tenfile))
			{
				ds=new DataSet();
				ds.ReadXml(tenfile);
				try
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						l_id=decimal.Parse(r["pid_1"].ToString());
						l_maql=decimal.Parse(r["pv1_19"].ToString());
						mabn=r["pid_3"].ToString();
						pos=mabn.IndexOf("/");
						if (pos!=-1) mabn=mabn.Substring(pos+1).Trim().PadLeft(2,'0')+mabn.Substring(0,pos-1).Trim().PadLeft(6,'0');
						else mabn=mabn.Substring(1).PadLeft(8,'0');
						lbl.Text="HL7_A02->"+mabn;
						lbl.Refresh();
						dg1_4_1=(tcvn3.Checked)?m.abc_uni(r["dg1_4_1"].ToString()):r["dg1_4_1"].ToString();
						pv1_17_2=(tcvn3.Checked)?m.abc_uni(r["pv1_17_2"].ToString()):r["pv1_17_2"].ToString();
						dg1_4_2=(tcvn3.Checked)?m.abc_uni(r["dg1_4_2"].ToString()):r["dg1_4_2"].ToString();
						pv1_7_2=(tcvn3.Checked)?m.abc_uni(r["pv1_7_2"].ToString()):r["pv1_7_2"].ToString();
						dg1_4_5=(tcvn3.Checked)?m.abc_uni(r["dg1_4_5"].ToString()):r["dg1_4_5"].ToString();
						dg1_4_3_2=(tcvn3.Checked)?m.abc_uni(r["dg1_4_3_2"].ToString()):r["dg1_4_3_2"].ToString();
						dg1_4_3_3=(tcvn3.Checked)?m.abc_uni(r["dg1_4_3_3"].ToString()):r["dg1_4_3_3"].ToString();
						dg1_4_4=(tcvn3.Checked)?m.abc_uni(r["dg1_4_4"].ToString()):r["dg1_4_4"].ToString();
						if (r["pv1_44"].ToString()!="")
							pv1_44=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pv1_44"].ToString()));
						else pv1_44="";
						if (r["pv1_45"].ToString()!="")
							pv1_45=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pv1_45"].ToString()));
						else pv1_45="";
						if (r["pv1_46"].ToString()!="")
							pv1_46=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pv1_46"].ToString()));
						else pv1_46="";
						if (r["pv1_47"].ToString()!="")
							pv1_47=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["pv1_47"].ToString()));
						else pv1_47="";
						m.imp_nhapkhoa(l_id,mabn,l_maql,r["pv1_3_1"].ToString(),int.Parse(r["pv1_2"].ToString()),pv1_44,
							r["add_6"].ToString(),r["pv1_3_3"].ToString(),r["pv1_6"].ToString(),
							dg1_4_1,r["dg1_3_1"].ToString(),r["pv1_17_1"].ToString(),int.Parse(r["pv1_13"].ToString()),i_userid);
						m.upd_dmbs(r["pv1_17_1"].ToString(),pv1_17_2,"","",0,r["pv1_17_1"].ToString(),0);

						if (r["pv1_45"].ToString()!="")
						{
							m.imp_xuatkhoa(l_id,pv1_45,
								int.Parse(r["add_1"].ToString()),int.Parse(r["add_2"].ToString()),
								dg1_4_2,r["dg1_3_2"].ToString(),r["pv1_7_1"].ToString(),
								int.Parse(r["add_3"].ToString()),int.Parse(r["add_4"].ToString()),
								int.Parse(r["add_5"].ToString()),i_userid);
							m.upd_dmbs(r["pv1_7_1"].ToString(),pv1_7_2,"","",0,r["pv1_7_1"].ToString(),0);
						}
						if (r["pv1_3_4"].ToString()!="")
							m.upd_chuyenkhoa(l_id,mabn,l_maql,r["pv1_3_4"].ToString(),pv1_47,
								r["pv1_10"].ToString(),dg1_4_5,r["dg1_3_5"].ToString(),i_userid);

						if (r["dg1_4_3_2"].ToString()!="")
							m.upd_cdkemtheo(l_id,l_maql,2,dg1_4_3_2,r["dg1_3_3_2"].ToString(),1);
						if (r["dg1_4_3_3"].ToString()!="")
							m.upd_cdkemtheo(l_id,l_maql,3,dg1_4_3_3,r["dg1_3_3_3"].ToString(),1);
						if (r["dg1_4_4"].ToString()!="")
							m.upd_cdnguyennhan(l_id,l_maql,dg1_4_4,r["dg1_3_4"].ToString());
						if (r["dg1_4_6"].ToString()+r["dg1_4_7"].ToString()+r["dg1_4_8"].ToString()+r["dg1_4_9"].ToString()!="")
							m.upd_cdungbuou(l_id,l_maql,r["dg1_3_6"].ToString(),r["dg1_3_7"].ToString(),r["dg1_3_8"].ToString(),r["dg1_3_9"].ToString(),r["dg1_4_6"].ToString(),r["dg1_4_7"].ToString(),r["dg1_4_8"].ToString(),r["dg1_4_9"].ToString());
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message,"HL7_A02");
				}
			}
		}

		private void upd_hl7_add()
		{
			if (File.Exists(tenfile))
			{
				ds=new DataSet();
				ds.ReadXml(tenfile);
				try
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						l_maql=decimal.Parse(r["pv1_19"].ToString());
						mabn=r["pid_3"].ToString();
						pos=mabn.IndexOf("/");
						if (pos!=-1) mabn=mabn.Substring(pos+1).Trim().PadLeft(2,'0')+mabn.Substring(0,pos-1).Trim().PadLeft(6,'0');
						else mabn=mabn.Substring(1).PadLeft(8,'0');
						if (r["acc_1"].ToString()!="")
							acc_1=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["acc_1"].ToString()));
						else acc_1="";
						if (r["add_17"].ToString()!="")
							add_17=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["add_17"].ToString()));
						else add_17="";
						if (r["add_19"].ToString()!="")
							add_19=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["add_19"].ToString()));
						else add_19="";
						lbl.Text="HL7_ADD->"+mabn;
						lbl.Refresh();
						add_20=(tcvn3.Checked)?m.abc_uni(r["add_20"].ToString()):r["add_20"].ToString();
						if (r["add_1"].ToString()!="")
							m.upd_hcsosinh(mabn,r["add_1"].ToString(),r["add_2"].ToString(),r["add_3"].ToString(),
								int.Parse(r["add_4"].ToString()),r["add_5"].ToString(),r["add_6"].ToString(),
								r["add_7"].ToString(),int.Parse(r["add_8"].ToString()),r["add_9"].ToString(),"");

						if (r["add_10"].ToString()+r["add_13"].ToString()!="")
							m.upd_hcnhi(mabn,r["add_10"].ToString(),r["add_11"].ToString(),r["add_12"].ToString(),r["add_13"].ToString(),r["add_14"].ToString(),r["add_15"].ToString());

						if (r["add_16"].ToString()!="")
							m.upd_tttamthan(l_maql,r["add_16"].ToString());
						
						if (r["add_17"].ToString()!="")
							m.upd_ttbong(l_maql,add_17);

						if (r["add_19"].ToString()!="")
						{
							l_id=decimal.Parse(r["add_18"].ToString());
							m.upd_tresosinh(l_id,l_maql,add_19,
								add_20,int.Parse(r["add_21"].ToString()),int.Parse(r["add_22"].ToString()),
								int.Parse(r["add_23"].ToString()),int.Parse(r["add_24"].ToString()),i_userid);
						}
						if (r["acc_3"].ToString()!="")
						{
							m.upd_tainantt(mabn,l_maql,acc_1,int.Parse(r["acc_3"].ToString()),int.Parse(r["add_26"].ToString()),
								int.Parse(r["add_27"].ToString()),int.Parse(r["add_28"].ToString()),3,7,"",m.Mabv.Substring(0,3),m.Mabv.Substring(0,3)+"00",m.Mabv.Substring(0,3)+"0000","","","","","");
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message,"HL7_ADD");
				}
			}
		}
	}
}