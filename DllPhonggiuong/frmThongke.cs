using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibMedi;
namespace DllPhonggiuong
{
	public class frmThongke : System.Windows.Forms.Form
	{
		private AccessData m=new AccessData();
        private string sql = "", s_userid = "", s_makp = "", s_user = "";
		private int i_userid;
		private DataSet ds;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.CheckBox chkUserid;
		private System.Windows.Forms.Panel pTieude;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tungay;
		private System.Windows.Forms.DateTimePicker denngay;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button butInBK;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TreeView tree_KP;
		private System.Windows.Forms.CheckBox chkKP;
		private System.Windows.Forms.GroupBox option;
		private System.Windows.Forms.RadioButton rd1;
		private System.ComponentModel.Container components = null;

		public frmThongke(int userid)
		{
			InitializeComponent();
			this.i_userid=userid;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmThongke));
			this.label1 = new System.Windows.Forms.Label();
			this.tungay = new System.Windows.Forms.DateTimePicker();
			this.tree_User = new System.Windows.Forms.TreeView();
			this.chkUserid = new System.Windows.Forms.CheckBox();
			this.pTieude = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.denngay = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.butInBK = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.tree_KP = new System.Windows.Forms.TreeView();
			this.chkKP = new System.Windows.Forms.CheckBox();
			this.option = new System.Windows.Forms.GroupBox();
			this.rd1 = new System.Windows.Forms.RadioButton();
			this.pTieude.SuspendLayout();
			this.option.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Navy;
			this.label1.Location = new System.Drawing.Point(299, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ ngày :";
			// 
			// tungay
			// 
			this.tungay.CustomFormat = "dd/MM/yyyy";
			this.tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tungay.Location = new System.Drawing.Point(352, 24);
			this.tungay.Name = "tungay";
			this.tungay.Size = new System.Drawing.Size(88, 20);
			this.tungay.TabIndex = 1;
			// 
			// tree_User
			// 
			this.tree_User.CheckBoxes = true;
			this.tree_User.ForeColor = System.Drawing.Color.DimGray;
			this.tree_User.FullRowSelect = true;
			this.tree_User.ImageIndex = -1;
			this.tree_User.Location = new System.Drawing.Point(8, 26);
			this.tree_User.Name = "tree_User";
			this.tree_User.SelectedImageIndex = -1;
			this.tree_User.ShowLines = false;
			this.tree_User.ShowPlusMinus = false;
			this.tree_User.ShowRootLines = false;
			this.tree_User.Size = new System.Drawing.Size(288, 131);
			this.tree_User.Sorted = true;
			this.tree_User.TabIndex = 188;
			// 
			// chkUserid
			// 
			this.chkUserid.ForeColor = System.Drawing.Color.Navy;
			this.chkUserid.Location = new System.Drawing.Point(9, 8);
			this.chkUserid.Name = "chkUserid";
			this.chkUserid.Size = new System.Drawing.Size(196, 17);
			this.chkUserid.TabIndex = 187;
			this.chkUserid.TabStop = false;
			this.chkUserid.Text = "Nhân viên đặt giường";
			this.chkUserid.CheckedChanged += new System.EventHandler(this.chkUserid_CheckedChanged);
			// 
			// pTieude
			// 
			this.pTieude.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.pTieude.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.panel1});
			this.pTieude.Dock = System.Windows.Forms.DockStyle.Top;
			this.pTieude.Name = "pTieude";
			this.pTieude.Size = new System.Drawing.Size(592, 4);
			this.pTieude.TabIndex = 189;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(592, 4);
			this.panel1.TabIndex = 190;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(4, 297);
			this.panel2.TabIndex = 190;
			// 
			// denngay
			// 
			this.denngay.CustomFormat = "dd/MM/yyyy";
			this.denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.denngay.Location = new System.Drawing.Point(498, 24);
			this.denngay.Name = "denngay";
			this.denngay.Size = new System.Drawing.Size(88, 20);
			this.denngay.TabIndex = 192;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Navy;
			this.label2.Location = new System.Drawing.Point(444, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 191;
			this.label2.Text = "đến ngày ";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(588, 4);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(4, 297);
			this.panel3.TabIndex = 193;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(4, 297);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(584, 4);
			this.panel4.TabIndex = 194;
			// 
			// butInBK
			// 
			this.butInBK.BackColor = System.Drawing.SystemColors.Control;
			this.butInBK.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butInBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butInBK.ForeColor = System.Drawing.Color.Navy;
			this.butInBK.Image = ((System.Drawing.Bitmap)(resources.GetObject("butInBK.Image")));
			this.butInBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butInBK.Location = new System.Drawing.Point(342, 256);
			this.butInBK.Name = "butInBK";
			this.butInBK.Size = new System.Drawing.Size(114, 27);
			this.butInBK.TabIndex = 196;
			this.butInBK.Text = "       &In bảng kê";
			this.butInBK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butInBK.Click += new System.EventHandler(this.butInBK_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
			this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(456, 256);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(107, 27);
			this.butKetthuc.TabIndex = 197;
			this.butKetthuc.Text = "        &Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// tree_KP
			// 
			this.tree_KP.CheckBoxes = true;
			this.tree_KP.ForeColor = System.Drawing.Color.DimGray;
			this.tree_KP.FullRowSelect = true;
			this.tree_KP.ImageIndex = -1;
			this.tree_KP.Location = new System.Drawing.Point(8, 179);
			this.tree_KP.Name = "tree_KP";
			this.tree_KP.SelectedImageIndex = -1;
			this.tree_KP.ShowLines = false;
			this.tree_KP.ShowPlusMinus = false;
			this.tree_KP.ShowRootLines = false;
			this.tree_KP.Size = new System.Drawing.Size(288, 117);
			this.tree_KP.Sorted = true;
			this.tree_KP.TabIndex = 200;
			// 
			// chkKP
			// 
			this.chkKP.ForeColor = System.Drawing.Color.Navy;
			this.chkKP.Location = new System.Drawing.Point(9, 159);
			this.chkKP.Name = "chkKP";
			this.chkKP.Size = new System.Drawing.Size(104, 20);
			this.chkKP.TabIndex = 199;
			this.chkKP.TabStop = false;
			this.chkKP.Text = "Khoa/ Phòng";
			this.chkKP.CheckedChanged += new System.EventHandler(this.chkKP_CheckedChanged);
			// 
			// option
			// 
			this.option.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.rd1});
			this.option.ForeColor = System.Drawing.Color.Navy;
			this.option.Location = new System.Drawing.Point(299, 48);
			this.option.Name = "option";
			this.option.Size = new System.Drawing.Size(288, 192);
			this.option.TabIndex = 201;
			this.option.TabStop = false;
			this.option.Text = "Mẫu báo cáo";
			// 
			// rd1
			// 
			this.rd1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.rd1.Checked = true;
			this.rd1.Location = new System.Drawing.Point(8, 24);
			this.rd1.Name = "rd1";
			this.rd1.Size = new System.Drawing.Size(274, 16);
			this.rd1.TabIndex = 0;
			this.rd1.TabStop = true;
			this.rd1.Text = "Bảng kê đặt giường dịch vụ hàng ngày";
			// 
			// frmThongke
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(592, 301);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.option,
																		  this.tree_KP,
																		  this.chkKP,
																		  this.butInBK,
																		  this.butKetthuc,
																		  this.panel4,
																		  this.panel3,
																		  this.denngay,
																		  this.label2,
																		  this.panel2,
																		  this.pTieude,
																		  this.tree_User,
																		  this.chkUserid,
																		  this.tungay,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmThongke";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thống kê báo cáo";
			this.Load += new System.EventHandler(this.frmThongke_Load);
			this.pTieude.ResumeLayout(false);
			this.option.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmThongke_Load(object sender, System.EventArgs e)
		{
            s_user = m.user;
			tungay.Value=System.DateTime.Now;
			denngay.Value=System.DateTime.Now;
			load_user();
			load_kp();
		}
		private void load_user()
		{
            sql = "select to_char(id) ma, trim(hoten)||' ('||userid||')' ten from " + s_user + ".v_dlogin order by hoten asc";
			load_tree(tree_User,m.get_data(sql));
			for(int i=0;i<tree_User.Nodes.Count;i++)
			{
				if(tree_User.Nodes[i].Tag.ToString()==i_userid.ToString())
				{
					tree_User.Nodes[i].Checked=true;
					break;
				}
			}
		}
		private void load_kp()
		{
            sql = "select distinct to_char(a.makp) ma, a.tenkp ten from " + s_user + ".btdkp_bv a, " + s_user + ".dmphong b where a.makp=b.makp order by a.tenkp asc";
			load_tree(tree_KP,m.get_data(sql));
		}
		private void load_tree(TreeView v_tree, DataSet v_ds)
		{
			TreeNode anode;
			v_tree.Nodes.Clear();
			for(int i=0;i<v_ds.Tables[0].Rows.Count;i++)
			{
				anode = new TreeNode(v_ds.Tables[0].Rows[i]["ten"].ToString());
				anode.Tag = v_ds.Tables[0].Rows[i]["ma"].ToString();
				v_tree.Nodes.Add(anode);
			}
		}

		private void chkKP_CheckedChanged(object sender, System.EventArgs e)
		{
			set_value_tree(tree_KP,chkKP.Checked);
		}
		private void set_value_tree(TreeView v_tree, bool bCheck)
		{
			for(int i=0;i<v_tree.Nodes.Count;i++)
			{
				v_tree.Nodes[i].Checked=bCheck;
			}
		}

		private void chkUserid_CheckedChanged(object sender, System.EventArgs e)
		{
			set_value_tree(tree_User,chkUserid.Checked);
		}

		private void butInBK_Click(object sender, System.EventArgs e)
		{
			s_userid="";s_makp="";
			string s_title=(tungay.Value==denngay.Value)?"Ngày "+tungay.Text:"Từ ngày "+tungay.Text+" đến ngày "+denngay.Text;
			s_userid=get_value_tree(tree_User);
			s_makp=get_value_tree(tree_KP);
			get_data_rd1();
			if(ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show("Không có số liệu!");
				return;
			}
			frmReport f=new frmReport(m,ds,s_title,"v_bangke_datgiuong.rpt");
			f.ShowDialog();
		}
		private string get_value_tree(TreeView v_tree)
		{
			string ret="";
			for(int i=0;i<v_tree.Nodes.Count;i++)
			{
				if(v_tree.Nodes[i].Checked) ret+=","+v_tree.Nodes[i].Tag.ToString();
			}
			ret=ret.Trim().Trim(',');
			return ret;
		}
		private void get_data_rd1()
		{
			ds=new DataSet();
            sql = "select a.mabn,b.hoten,decode(b.ngaysinh,null,b.namsinh,to_char(b.ngaysinh,'dd/mm/yyyy')) namsinh,trim(d.ten||' - '||c.ten) tengiuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngaydat from " + s_user + ".datgiuong a, " + s_user + ".btdbn b, " + s_user + ".dmgiuong c, " + s_user + ".dmphong d where a.mabn=b.mabn and a.idgiuong=c.id and c.idphong=d.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay.Text + "','dd/mm/yyyy') and to_date('" + denngay.Text + "','dd/mm/yyyy')";
			if(s_userid!="") sql+=" and a.userid in("+s_userid+")";
			if(s_makp!="") sql+=" and d.makp in("+s_makp+")";
			sql+=" order by to_char(a.ngay,'dd/mm/yyyy hh24:mi')";
			ds=m.get_data(sql);
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}

