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
	/// Summary description for frmDmbenhan.
	/// </summary>
	public class frmDmbenhan : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
        private string user;
		private AccessData m;
        private CheckBox phong;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmbenhan(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmbenhan));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butThem = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.phong = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(16, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(248, 329);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.Location = new System.Drawing.Point(280, 32);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(248, 329);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "DANH MỤC BỆNH ÁN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(280, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "BỆNH ÁN SỬ DỤNG TRONG BỆNH VIỆN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butThem
            // 
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(177, 376);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 4;
            this.butThem.Text = "     &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(237, 376);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 5;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(297, 376);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // phong
            // 
            this.phong.AutoSize = true;
            this.phong.Location = new System.Drawing.Point(402, 365);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(130, 17);
            this.phong.TabIndex = 7;
            this.phong.Text = "Quản lý phòng giường";
            this.phong.UseVisualStyleBackColor = true;
            this.phong.CheckedChanged += new System.EventHandler(this.phong_CheckedChanged);
            // 
            // frmDmbenhan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(544, 421);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmbenhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo sử dụng bệnh án";
            this.Load += new System.EventHandler(this.frmDmbenhan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmbenhan_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmbenhan_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            phong.Enabled = m.bPhonggiuong && m.bGiuong_khoa;
            listBox1.DataSource = m.get_data("select * from " + user + ".dmbenhan order by maba").Tables[0];
            listBox1.DisplayMember = "TEN";
            listBox1.ValueMember = "MAVT";
			load();
		}

		private void load()
		{
            listBox2.DataSource = m.get_data("select * from " + user + ".dmbenhan_bv order by maba").Tables[0];
            listBox2.DisplayMember = "TEN";
            listBox2.ValueMember = "MAVT";
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
            if (LibMedi.AccessData.sosinh.IndexOf(listBox1.SelectedValue.ToString()) != -1 && m.get_data("select * from " + user + ".btdnn_bv where mannbo='01'").Tables[0].Rows.Count == 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không thể thêm bệnh án ")+listBox1.Text.Trim().ToUpper()+" vì danh mục nghề nghiệp chưa có trẻ em !",LibMedi.AccessData.Msg);
				return;
			}
            foreach (DataRow r in m.get_data("select * from " + user + ".dmbenhan where mavt='" + listBox1.SelectedValue.ToString() + "'").Tables[0].Rows)
			{
				m.upd_dmbenhan_bv(int.Parse(r["maba"].ToString()),r["mavt"].ToString(),int.Parse(r["loaiba"].ToString()),r["ten"].ToString(),r["tenvt"].ToString(),r["tenfile"].ToString());
				break;
			}
			load();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (listBox2.Items.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy, vì bắt buộc phải còn bệnh án !"),LibMedi.AccessData.Msg);
                return;
			}
            int iMaba = int.Parse(m.get_data("select maba from " + user + ".dmbenhan where mavt='" + listBox2.SelectedValue.ToString() + "'").Tables[0].Rows[0][0].ToString());
            if (m.get_data("select * from " + user + ".nhapkhoa where maba=" + iMaba).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Bệnh án này đã sử dụng không thể hủy !"),LibMedi.AccessData.Msg);
				return;
			}
            m.execute_data("delete from " + user + ".dmbenhan_bv where mavt='" + listBox2.SelectedValue.ToString() + "'");
			load();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			butThem_Click(null,null);
		}

		private void frmDmbenhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

        private void phong_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == phong)
                m.execute_data("update "+user+".dmbenhan_bv set phong=" + ((phong.Checked) ? 1 : 0) + " where mavt='" + listBox2.SelectedValue.ToString() + "'");
        }

        private void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == listBox2)
            {
                try
                {
                    phong.Checked = m.get_data("select * from "+user+".dmbenhan_bv where phong=1 and mavt='" + listBox2.SelectedValue.ToString() + "'").Tables[0].Rows.Count > 0;
                }
                catch { }
            }
        }

	}
}
