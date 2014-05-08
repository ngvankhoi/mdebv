using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmSohieu.
	/// </summary>
	public class frmSohieu : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.ComboBox sohieu;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button butOK;
		private System.Windows.Forms.Button butCancel;
		private DataTable dt=new DataTable();
        private DataTable dtuser = new DataTable();
		private DataSet ds=new DataSet();
		private AccessData m=new AccessData();
		private string sql,user;
        public int iuserid, iAdmin, iLoai, iKyhieu, iAll = 0;//Thuy 24.02.2012 thêm biến iAdmin.//Thuy 29.02.2012
        public string i_Suserid;
        private ComboBox c196;
        private Label label3;
        private Label label4;
        private TextBox matkhau;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSohieu()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSohieu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.sohieu = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.c196 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.matkhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Loại :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(2, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ký hiệu :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(58, 51);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(144, 21);
            this.loai.TabIndex = 5;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // sohieu
            // 
            this.sohieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sohieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohieu.Location = new System.Drawing.Point(58, 74);
            this.sohieu.Name = "sohieu";
            this.sohieu.Size = new System.Drawing.Size(144, 21);
            this.sohieu.TabIndex = 7;
            this.sohieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sohieu_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(57, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Liệt kê tất cả";
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sohieu_KeyDown);
            // 
            // butOK
            // 
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(33, 121);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(74, 25);
            this.butOK.TabIndex = 8;
            this.butOK.Text = "      &Đồng ý";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(107, 121);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(74, 25);
            this.butCancel.TabIndex = 9;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // c196
            // 
            this.c196.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c196.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c196.Location = new System.Drawing.Point(58, 7);
            this.c196.Name = "c196";
            this.c196.Size = new System.Drawing.Size(144, 21);
            this.c196.TabIndex = 1;
            this.c196.SelectedIndexChanged += new System.EventHandler(this.c196_SelectedIndexChanged);
            this.c196.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c196_KeyDown);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(-13, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Người thu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(-13, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mật khẩu :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matkhau
            // 
            this.matkhau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matkhau.Location = new System.Drawing.Point(58, 29);
            this.matkhau.Name = "matkhau";
            this.matkhau.PasswordChar = '*';
            this.matkhau.Size = new System.Drawing.Size(144, 21);
            this.matkhau.TabIndex = 3;
            this.matkhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c196_KeyDown);
            // 
            // frmSohieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(213, 157);
            this.ControlBox = false;
            this.Controls.Add(this.matkhau);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c196);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.sohieu);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSohieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ký hiệu biên lai";
            this.Load += new System.EventHandler(this.frmSohieu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSohieu_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			ds.ReadXml("..\\..\\..\\xml\\v_thongso.xml");
			loai.DisplayMember="TEN";
			loai.ValueMember="MA";
			loai.DataSource=m.get_data("select * from "+user+".v_tenloaivp order by ma").Tables[0];
			loai.SelectedValue=ds.Tables[0].Rows[0]["loai"].ToString();

            dtuser = m.get_data("select * from " + user + ".v_dlogin order by id").Tables[0];
            c196.DisplayMember = "HOTEN";
            c196.ValueMember = "ID";
            c196.DataSource = dtuser;

			sohieu.DisplayMember="SOHIEU";
			sohieu.ValueMember="ID";
			load_sohieu();
			sohieu.Text=ds.Tables[0].Rows[0]["c01"].ToString();
		}

		private void load_sohieu()
		{
			sql="select * from "+user+".v_quyenso where loai like '%"+loai.SelectedValue.ToString()+"%'";
			if (!checkBox1.Checked) sql+=" and soghi<den";
            if (m.bKyhieu_may) sql += " and computerid=" + m.iRownum;
            else if (!checkBox1.Checked) sql += " and userid=" + decimal.Parse(c196.SelectedValue.ToString());
			dt=m.get_data(sql).Tables[0];
			sohieu.DataSource=dt;
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai) load_sohieu();
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loai.SelectedIndex==-1) loai.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void sohieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void checkBox1_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==checkBox1) load_sohieu();
		}

		private void butOK_Click(object sender, System.EventArgs e)
		{
			if (loai.SelectedIndex==-1)
			{
				loai.Focus();
				return;
			}
			if (sohieu.SelectedIndex==-1)
			{
				sohieu.Focus();
				return;
			}
            if (dtuser.Rows[c196.SelectedIndex]["password_"].ToString().Trim().ToLower() != matkhau.Text.Trim().ToLower())
            {
                MessageBox.Show(lan.Change_language_MessageText("Mật khẩu không hợp lệ !"), LibMedi.AccessData.Msg);
                matkhau.Focus();
                return;
            }
			iKyhieu=int.Parse(sohieu.SelectedValue.ToString());
			iLoai=int.Parse(loai.SelectedValue.ToString());
            iuserid = int.Parse(c196.SelectedValue.ToString());//Thuy 29.02.2012
            i_Suserid = c196.Text;
            iAll = (checkBox1.Checked) ? 1 : 0;
            //Thuy 24.02.2012
            if (dtuser.Rows[c196.SelectedIndex]["admin"].ToString() == "1")
            {
                iAdmin = 1;
            }
            else
            {
                iAdmin = 0;
            }
			try
			{
                ds.Tables[0].Rows[0]["c01"] = sohieu.Text;
				ds.WriteXml("..\\..\\..\\xml\\v_thongso.xml");
			}
			catch{}
			m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			iKyhieu=0;iLoai=0;
			m.close();this.Close();
		}

        private void c196_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c196) load_sohieu();
        }

        private void c196_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
	}
}
