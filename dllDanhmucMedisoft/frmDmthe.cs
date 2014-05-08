using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmDmthe.
	/// </summary>
	public class frmDmthe : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox thumuc;
		private System.Windows.Forms.Button butPath;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lbl;
		private DataSet ds=new DataSet();
        private string user;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private AccessData m;

		public frmDmthe(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmthe));
            this.label1 = new System.Windows.Forms.Label();
            this.thumuc = new System.Windows.Forms.TextBox();
            this.butPath = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thư mục :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumuc
            // 
            this.thumuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thumuc.Enabled = false;
            this.thumuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thumuc.Location = new System.Drawing.Point(51, 16);
            this.thumuc.Name = "thumuc";
            this.thumuc.Size = new System.Drawing.Size(200, 21);
            this.thumuc.TabIndex = 1;
            // 
            // butPath
            // 
            this.butPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPath.Location = new System.Drawing.Point(256, 15);
            this.butPath.Name = "butPath";
            this.butPath.Size = new System.Drawing.Size(24, 23);
            this.butPath.TabIndex = 2;
            this.butPath.Text = "...";
            this.toolTip1.SetToolTip(this.butPath, "Thư mục chứa cơ sở dữ liệu Access");
            this.butPath.Click += new System.EventHandler(this.butPath_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(75, 144);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 0;
            this.butOk.Text = "     Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(146, 144);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(48, 48);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(192, 23);
            this.lbl.TabIndex = 5;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(56, 80);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Loại thẻ";
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(56, 100);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(160, 16);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Nơi đăng ký khám bệnh";
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(56, 120);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(104, 16);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "Số thẻ";
            // 
            // frmDmthe
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(288, 189);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butPath);
            this.Controls.Add(this.thumuc);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmthe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển danh mục thẻ bảo hiểm";
            this.Load += new System.EventHandler(this.frmDmthe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void butPath_Click(object sender, System.EventArgs e)
		{
			string sDir=System.Environment.CurrentDirectory.ToString();
			OpenFileDialog of=new OpenFileDialog();
			of.Filter="*.MDB|*.*";
			of.ShowDialog();
			thumuc.Text=of.FileName.ToString();
			System.Environment.CurrentDirectory=sDir;
		}

		private void frmDmthe_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			thumuc.Text=m.get_data("select ten from "+user+".thongso where id=20").Tables[0].Rows[0][0].ToString();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (thumuc.Text=="")
			{
				butPath_Click(null,null);
				return;
			}
			if (!System.IO.File.Exists(thumuc.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy File !"),LibMedi.AccessData.Msg);
				return;
			}
			Cursor=Cursors.WaitCursor;
			if (checkBox1.Checked) dmloaithe();
			if (checkBox2.Checked) dmnoicapbhyt();
			if (checkBox3.Checked) dmthe();
			Cursor=Cursors.Default;
			m.upd_thongso(20,"ten",thumuc.Text.ToString().Trim());
			MessageBox.Show(lan.Change_language_MessageText("Đã chuyển số liệu xong !"),LibMedi.AccessData.Msg);
		}

		private void dmloaithe()
		{
            foreach (DataRow r in m.get_data_acc("select * from dmloaithe", thumuc.Text).Tables[0].Rows)
			{
				lbl.Text=r["ma"].ToString();
				lbl.Update();
				m.upd_dmloaithe(r["ma"].ToString().Trim(),m.abc_uni(r["ten"].ToString().Trim()),int.Parse(r["nhom"].ToString()),(r["thu20"].ToString().Trim()=="true")?1:0);
			}
		}

		private void dmnoicapbhyt()
		{
            foreach (DataRow r in m.get_data_acc("select * from dmnoicapbhyt", thumuc.Text).Tables[0].Rows)
			{
                if (m.get_data("select * from " + user + ".dmnoicapbhyt where mabv='" + r["mabv"].ToString() + "'").Tables[0].Rows.Count == 0)
                {
                    lbl.Text = r["mabv"].ToString();
                    lbl.Update();
                    m.upd_tenvien("dmnoicapbhyt", r["mabv"].ToString().Trim(), m.abc_uni(r["tenbv"].ToString().Trim()), m.abc_uni(r["diachi"].ToString().Trim()), r["sodt"].ToString(), r["matuyen"].ToString(), r["maloai"].ToString(), r["mahang"].ToString(), r["mavung"].ToString(), r["matinh"].ToString());
                }
			}
		}

		private void dmthe()
		{
			string sql="";
            foreach (DataRow r1 in m.get_data_acc("select * from dmloaithe", thumuc.Text).Tables[0].Rows)
			{
                sql = "select sothe,mathe,madt,makcb,hoten,namsinh,gioitinh,diachi,matt,maqu,maphuongxa,cholam,format(tungay,'dd/MM/yyyy') as tu,format(denngay,'dd/MM/yyyy') as den,mabv from dmthe where madt='" + r1["ma"].ToString() + "'";
				foreach(DataRow r in m.get_data_acc(sql,thumuc.Text).Tables[0].Rows)
				{
					lbl.Text=r["sothe"].ToString();
					lbl.Update();
                    if (m.get_data("select * from " + user + ".dmthe where sothe='" + r["sothe"].ToString() + "'").Tables[0].Rows.Count == 0)
						m.upd_dmthe(r["sothe"].ToString().Trim(),r["mathe"].ToString().Trim(),r["madt"].ToString().Trim(),r["makcb"].ToString().Trim(),m.abc_uni(r["hoten"].ToString().Trim()).ToUpper(),r["namsinh"].ToString(),(r["gioitinh"].ToString().Trim()=="1")?0:1,m.abc_uni(r["diachi"].ToString().Trim()),r["matt"].ToString().Trim(),r["maqu"].ToString().Trim(),r["maphuongxa"].ToString().Trim(),m.abc_uni(r["cholam"].ToString().Trim()),r["tu"].ToString().Trim(),r["den"].ToString().Trim(),r["mabv"].ToString());
				}
			}
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}
	}
}
