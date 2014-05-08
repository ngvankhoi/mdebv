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
	public class frmImp_bs2001 : System.Windows.Forms.Form
	{
		Language lan = new Language();
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
		private int len,pos,i_userid;
		private long l_id;
		private bool bFound=false;
		private string tenfile,bieu,ngay,exp;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		public frmImp_bs2001(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;	
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmImp_bs2001));
			this.panel1 = new System.Windows.Forms.Panel();
			this.treeView1 = new Medisoft.FolderTreeView();
			this.thumuc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.butOk = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.treeView1});
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(238, 290);
			this.panel1.TabIndex = 1;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Name = "treeView1";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("Desktop", 0, 0, new System.Windows.Forms.TreeNode[] {
																																											 new System.Windows.Forms.TreeNode("My Computer", 2, 3, new System.Windows.Forms.TreeNode[] {
																																																																			new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("My Network Places", 4, 5),
																																											 new System.Windows.Forms.TreeNode("My Documents", 6, 7, new System.Windows.Forms.TreeNode[] {
																																																																			 new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("Recycle Bin", 8, 9),
																																											 new System.Windows.Forms.TreeNode("C-sharp Corner", 10, 11, new System.Windows.Forms.TreeNode[] {
																																																																				 new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("New Folder", 12, 13),
																																											 new System.Windows.Forms.TreeNode("Release", 14, 15),
																																											 new System.Windows.Forms.TreeNode("Unsorted", 16, 17, new System.Windows.Forms.TreeNode[] {
																																																																		   new System.Windows.Forms.TreeNode("")})}),
																				  new System.Windows.Forms.TreeNode("Desktop", 0, 0, new System.Windows.Forms.TreeNode[] {
																																											 new System.Windows.Forms.TreeNode("My Computer", 2, 3, new System.Windows.Forms.TreeNode[] {
																																																																			new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("My Network Places", 4, 5),
																																											 new System.Windows.Forms.TreeNode("My Documents", 6, 7, new System.Windows.Forms.TreeNode[] {
																																																																			 new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("Recycle Bin", 8, 9),
																																											 new System.Windows.Forms.TreeNode("C-sharp Corner", 10, 11, new System.Windows.Forms.TreeNode[] {
																																																																				 new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("New Folder", 12, 13),
																																											 new System.Windows.Forms.TreeNode("Release", 14, 15),
																																											 new System.Windows.Forms.TreeNode("Unsorted", 16, 17, new System.Windows.Forms.TreeNode[] {
																																																																		   new System.Windows.Forms.TreeNode("")})}),
																				  new System.Windows.Forms.TreeNode("Desktop", 0, 0, new System.Windows.Forms.TreeNode[] {
																																											 new System.Windows.Forms.TreeNode("My Computer", 2, 3, new System.Windows.Forms.TreeNode[] {
																																																																			new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("My Network Places", 4, 5),
																																											 new System.Windows.Forms.TreeNode("My Documents", 6, 7, new System.Windows.Forms.TreeNode[] {
																																																																			 new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("Recycle Bin", 8, 9),
																																											 new System.Windows.Forms.TreeNode("C-sharp Corner", 10, 11, new System.Windows.Forms.TreeNode[] {
																																																																				 new System.Windows.Forms.TreeNode("")}),
																																											 new System.Windows.Forms.TreeNode("New Folder", 12, 13),
																																											 new System.Windows.Forms.TreeNode("Release", 14, 15),
																																											 new System.Windows.Forms.TreeNode("Unsorted", 16, 17, new System.Windows.Forms.TreeNode[] {
																																																																		   new System.Windows.Forms.TreeNode("")})})});
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(238, 290);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// thumuc
			// 
			this.thumuc.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.thumuc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.thumuc.Enabled = false;
			this.thumuc.Location = new System.Drawing.Point(64, 301);
			this.thumuc.Name = "thumuc";
			this.thumuc.Size = new System.Drawing.Size(584, 20);
			this.thumuc.TabIndex = 2;
			this.thumuc.Text = "";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.Location = new System.Drawing.Point(8, 301);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Thư mục :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butOk
			// 
			this.butOk.Image = ((System.Drawing.Bitmap)(resources.GetObject("butOk.Image")));
			this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butOk.Location = new System.Drawing.Point(240, 360);
			this.butOk.Name = "butOk";
			this.butOk.Size = new System.Drawing.Size(88, 28);
			this.butOk.TabIndex = 5;
			this.butOk.Text = "      &Đồng ý";
			this.butOk.Click += new System.EventHandler(this.butOk_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(328, 360);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(94, 28);
			this.butKetthuc.TabIndex = 7;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 328);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Đang cập nhật số liệu :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl
			// 
			this.lbl.AutoSize = true;
			this.lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl.ForeColor = System.Drawing.Color.Blue;
			this.lbl.Location = new System.Drawing.Point(128, 328);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(0, 15);
			this.lbl.TabIndex = 4;
			this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listBox1
			// 
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listBox1.Location = new System.Drawing.Point(248, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(400, 290);
			this.listBox1.TabIndex = 8;
			// 
			// frmImp_bs2001
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 405);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listBox1,
																		  this.lbl,
																		  this.label1,
																		  this.butKetthuc,
																		  this.butOk,
																		  this.thumuc,
																		  this.label2,
																		  this.panel1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmImp_bs2001";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chuyển số liệu tổng hợp từ  BS2001 vào Medisoft 2003";
			this.Load += new System.EventHandler(this.frmImp_bs2001_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

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
				}
			}
			catch{}
		}

		private void frmImp_bs2001_Load(object sender, System.EventArgs e)
		{
			this.treeView1.InitFolderTreeView();
			this.thumuc.Text=m.get_data("select ten from thongso where id=7").Tables[0].Rows[0][0].ToString();
			bool folderFound = treeView1.DrillToFolder(this.thumuc.Text);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				m.upd_thongso(7,thumuc.Text.ToString().Trim());
				if (listBox1.Items.Count==0) return;
				bFound=false;
				exp=thumuc.Text;
				string [] files=Directory.GetFiles(exp);
				for(int i=0;i<files.GetLength(0);i++)
				{
					tenfile=files[i].ToString();
					pos=tenfile.LastIndexOf("\\")+1;
					len=tenfile.Length;
					bieu=tenfile.Substring(pos,len-pos-4).ToUpper();
					lbl.Text=tenfile;
					lbl.Refresh();
					bFound=bieu.Trim().ToUpper()=="BC1";
					if (bFound) break;
				}
				if (bFound)
				{
					upd_bs2001();
					if (listBox1.Items.Count!=0) MessageBox.Show(lan.Change_language_MessageText("Thu nhập số liệu xong !"),LibMedi.AccessData.Msg);
				}
				else MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy File BC1.DBF cần chuyển !"),LibMedi.AccessData.Msg);
			}
			catch(Exception ex){MessageBox.Show(ex.Message,LibMedi.AccessData.Msg);}
		}
		
		private void upd_bs2001()
		{
			try
			{
				upd_bieu01();
				upd_bieu02();
				upd_bieu031();
				upd_bieu04();
				upd_bieu05();
				upd_bieu06();
				upd_bieu07();
				upd_bieu08();
				upd_bieu091();
				upd_bieu101();
				upd_bieu1021();
				upd_bieu1022();
				upd_bieu103();
				upd_bieu11();
				ds=new DataSet();
				ds=m.get_data(exp,"select a.*,b.noi_dung from bc1 a,dmbc092 b where a.id=b.id and a.ma_ct='092'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(ds.Tables[0].Rows[0]["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_092",19);
						m.upd_bieu092(l_id,int.Parse(r["id"].ToString()),ngay,m.abc_uni(r["noi_dung"].ToString().Trim()),decimal.Parse(r["c1"].ToString()),
							int.Parse(r["c2"].ToString()),int.Parse(r["c3"].ToString()),int.Parse(r["c4"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void upd_bieu01()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='01'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_01",10);
						m.upd_bieu01(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),
							int.Parse(r["c2"].ToString()),int.Parse(r["c3"].ToString()),int.Parse(r["c4"].ToString()),
							int.Parse(r["c5"].ToString()),int.Parse(r["c6"].ToString()),int.Parse(r["c7"].ToString()),
							int.Parse(r["c8"].ToString()),int.Parse(r["c9"].ToString()),int.Parse(r["c10"].ToString()),
							int.Parse(r["c11"].ToString()),int.Parse(r["c12"].ToString()),int.Parse(r["c13"].ToString()),
							int.Parse(r["c14"].ToString()),int.Parse(r["c15"].ToString()),int.Parse(r["c16"].ToString()),
							int.Parse(r["c17"].ToString()),int.Parse(r["c18"].ToString()),int.Parse(r["c19"].ToString()),
							int.Parse(r["c20"].ToString()),int.Parse(r["c21"].ToString()),int.Parse(r["c22"].ToString()),
							int.Parse(r["c23"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 01"));}
		}

		private void upd_bieu02()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='02'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_02",11);
						m.upd_bieu02(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),
							int.Parse(r["c2"].ToString()),int.Parse(r["c3"].ToString()),int.Parse(r["c4"].ToString()),
							int.Parse(r["c5"].ToString()),int.Parse(r["c6"].ToString()),int.Parse(r["c7"].ToString()),
							int.Parse(r["c8"].ToString()),int.Parse(r["c9"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 02"));}
		}

		private void upd_bieu031()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='031'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_031",12);
						m.upd_bieu031(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),
							int.Parse(r["c2"].ToString()),int.Parse(r["c3"].ToString()),int.Parse(r["c4"].ToString()),
							int.Parse(r["c5"].ToString()),int.Parse(r["c6"].ToString()),int.Parse(r["c7"].ToString()),
							int.Parse(r["c8"].ToString()),int.Parse(r["c9"].ToString()),int.Parse(r["c10"].ToString()),
							int.Parse(r["c11"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 031"));}
		}

		private void upd_bieu04()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='04'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_04",13);
						m.upd_bieu04(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),
							int.Parse(r["c2"].ToString()),int.Parse(r["c3"].ToString()),int.Parse(r["c4"].ToString()),
							int.Parse(r["c5"].ToString()),int.Parse(r["c6"].ToString()),int.Parse(r["c7"].ToString()),
							int.Parse(r["c8"].ToString()),int.Parse(r["c9"].ToString()),int.Parse(r["c10"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 04"));}
		}

		private void upd_bieu05()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='05'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_05",14);
						m.upd_bieu05(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 05"));}
		}

		private void upd_bieu06()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='06'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_06",15);
						m.upd_bieu06(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),int.Parse(r["c2"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 06"));}
		}

		private void upd_bieu07()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='07'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_07",16);
						m.upd_bieu07(l_id,int.Parse(r["id"].ToString()),ngay,Decimal.Parse(r["c1"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 07"));}
		}

		private void upd_bieu08()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='08'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_08",17);
						m.upd_bieu08(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),
							int.Parse(r["c2"].ToString()),int.Parse(r["c3"].ToString()),int.Parse(r["c4"].ToString()),
							int.Parse(r["c5"].ToString()),int.Parse(r["c6"].ToString()),int.Parse(r["c7"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 08"));}
		}

		private void upd_bieu091()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='091'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_091",18);
						m.upd_bieu091(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 091"));}
		}

		private void upd_bieu101()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='10A'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_101",20);
						m.upd_bieu101(l_id,int.Parse(r["id"].ToString()),ngay,Decimal.Parse(r["c1"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 101"));}
		}

		private void upd_bieu1021()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='10B'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_1021",21);
						m.upd_bieu1021(l_id,int.Parse(r["id"].ToString()),ngay,Decimal.Parse(r["c1"].ToString()),Decimal.Parse(r["c2"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 1021"));}
		}

		private void upd_bieu1022()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='10C'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_1022",22);
						m.upd_bieu1022(l_id,int.Parse(r["id"].ToString()),ngay,Decimal.Parse(r["c1"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 1022"));}
		}

		private void upd_bieu103()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='10D'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_103",23);
						m.upd_bieu103(l_id,int.Parse(r["id"].ToString()),ngay,Decimal.Parse(r["c1"].ToString()),
							Decimal.Parse(r["c2"].ToString()),Decimal.Parse(r["c3"].ToString()),Decimal.Parse(r["c4"].ToString()),
							Decimal.Parse(r["c5"].ToString()),Decimal.Parse(r["c6"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 103"));}
		}

		private void upd_bieu11()
		{
			try
			{
				ds=new DataSet();
				ds=m.get_data(exp,"select * from bc1 where ma_ct='11'");
				if (ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay_ct"].ToString()));
						l_id=m.get_id(ngay,"bieu_11",24);
						m.upd_bieu11(l_id,int.Parse(r["id"].ToString()),ngay,int.Parse(r["c1"].ToString()),
							int.Parse(r["c2"].ToString()),int.Parse(r["c3"].ToString()),int.Parse(r["c4"].ToString()),
							int.Parse(r["c5"].ToString()),int.Parse(r["c6"].ToString()),int.Parse(r["c7"].ToString()),
							int.Parse(r["c8"].ToString()),int.Parse(r["c9"].ToString()),int.Parse(r["c10"].ToString()),
							int.Parse(r["c11"].ToString()),int.Parse(r["c12"].ToString()),i_userid);
					}
				}
			}
			catch(Exception ex)
			{MessageBox.Show(ex.Message,lan.Change_language_MessageText("Biểu 11"));}
		}
	}
}
