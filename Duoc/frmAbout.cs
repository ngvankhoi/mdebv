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
	/// Summary description for frmAbout.
	/// </summary>
	public class frmAbout : System.Windows.Forms.Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        //lan.Read_Language_to_Xml(this.Name.ToString(),this);
		//lan.Changelanguage_to_English(this.Name.ToString(),this);
        private AccessData m = new AccessData();
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private LinkLabel linkLabel1;
        private Label tenbv;
        private Button butExit;
        private RichTextBox blog;
		private System.ComponentModel.Container components = null;
        private TreeNode tree;
        private int i_nhom;
        private string mmyy;
		public frmAbout(string tenfile,TreeNode tn,int nhomkho,string _mmyy)
		{

			InitializeComponent();
            //Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        lan.Read_Language_to_Xml(this.Name.ToString(),this);
		lan.Changelanguage_to_English(this.Name.ToString(),this);
            tenbv.Text = "Ngày cập nhật :" + m.f_modify(m.file_exe(tenfile)).ToString() + " - Size :" + m.f_size(m.file_exe(tenfile));
            tree = tn; i_nhom = nhomkho; mmyy = _mmyy;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tenbv = new System.Windows.Forms.Label();
            this.butExit = new System.Windows.Forms.Button();
            this.blog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(240, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Phone : 08.7155019 - Mobile : 090 3937066";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(0, 518);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Copyright © 1997-2008 Links Co., Ltd";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(240, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Links ® Medisoft";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 36);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(781, 36);
            this.label1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(469, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 16);
            this.label4.TabIndex = 16;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.linkLabel1.Location = new System.Drawing.Point(141, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(88, 13);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.medisoft.vn";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tenbv.Location = new System.Drawing.Point(469, 16);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(312, 18);
            this.tenbv.TabIndex = 19;
            this.tenbv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Location = new System.Drawing.Point(709, 515);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 23);
            this.butExit.TabIndex = 20;
            this.butExit.Text = "Kết thúc";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // blog
            // 
            this.blog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.blog.BackColor = System.Drawing.SystemColors.Info;
            this.blog.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blog.Location = new System.Drawing.Point(0, 34);
            this.blog.Name = "blog";
            this.blog.ReadOnly = true;
            this.blog.Size = new System.Drawing.Size(781, 478);
            this.blog.TabIndex = 22;
            this.blog.Text = "";
            // 
            // frmAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(780, 537);
            this.Controls.Add(this.blog);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAbout_KeyDown);
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmAbout_Load(object sender, System.EventArgs e)
		{
            label4.Text = m.Tenbv.Trim().ToUpper();
            string filetxt = "blog_duoc.txt";
            if (System.IO.File.Exists(filetxt))
            {
                string s = "";
                System.IO.StreamReader re = System.IO.File.OpenText(filetxt);
                string input = null;
                while ((input = re.ReadLine()) != null)
                {
                    s += input + "\n";
                }
                re.Close();
                blog.Text = s;
            }
            string sURL = "www.medisoft.vn";
            linkLabel1.Links.Add(0,sURL.Length,sURL);            
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;
				System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
			}
			catch
			{
				return;
			}
		}

        private void frmAbout_KeyDown(object sender, KeyEventArgs e)
        {
            string user = d.user,xxx=user+mmyy;
            if (e.KeyCode == Keys.F7)
            {
                string sql = "select a.* from " + xxx + ".d_tutrucct a," + user + ".d_dmkho b," + xxx + ".d_theodoi t where a.makho=b.id and a.tondau<0 and a.stt=t.id and b.nhom=" + i_nhom + " order by a.makp,a.makho,t.manguon,a.mabd,a.stt";
                decimal sl = 0;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    sl = decimal.Parse(r["tondau"].ToString());
                    sql = "select a.* from " + xxx + ".d_tutrucct a," + xxx + ".d_theodoi t where a.stt=t.id and a.mabd=" + decimal.Parse(r["mabd"].ToString()) + " and a.makp=" + decimal.Parse(r["makp"].ToString());
                    sql += " and a.makho=" + decimal.Parse(r["makho"].ToString()) + " and t.manguon=" + decimal.Parse(r["manguon"].ToString());
                    sql += " and a.tondau>=" + Math.Abs(sl) + " and a.tondau+a.slnhap-a.slxuat>=" + Math.Abs(sl);
                    sql += " order by a.makp,a.makho,t.manguon,a.mabd,a.stt";
                    foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    {
                        sql = "update " + xxx + ".d_tutrucct set tondau=tondau+" + sl + " where mabd=" + decimal.Parse(r["mabd"].ToString());
                        sql += " and makp=" + decimal.Parse(r["makp"].ToString()) + " and stt=" + decimal.Parse(r1["stt"].ToString());
                        d.execute_data(sql);
                        sql = "update " + xxx + ".d_tutrucct set tondau=0 where mabd=" + decimal.Parse(r["mabd"].ToString());
                        sql += " and makp=" + decimal.Parse(r["makp"].ToString()) + " and stt=" + decimal.Parse(r["stt"].ToString());
                        d.execute_data(sql);
                        break;
                    }
                }
                MessageBox.Show(lan.Change_language_MessageText("Đã kiểm tra lại tồn đầu tủ trực !"), d.Msg);
            }
            else if (e.KeyCode == Keys.F8) kiemtra_nhap();
            else if (e.KeyCode == Keys.F12)
            {
                if (!d.bMahoamatkhau)
                {
                    foreach (DataRow r in m.get_data("select * from " + user + ".d_dlogin").Tables[0].Rows)
                    {
                        try
                        {
                            d.execute_data("update " + user + ".d_dlogin set password_='" + m.encode(r["password_"].ToString()) + "' where id=" + decimal.Parse(r["id"].ToString()));
                        }
                        catch { }
                    }
                    d.upd_thongso(i_nhom, -13, "", "1");
                    MessageBox.Show(lan.Change_language_MessageText("Đã mã hóa mật khẩu !"), LibMedi.AccessData.Msg);
                }
                else MessageBox.Show(lan.Change_language_MessageText("Mật khẩu đã mã hóa !"), LibMedi.AccessData.Msg);
            }
            else if (e.KeyCode == Keys.F11)
            {
                if (d.bMahoamatkhau)
                {
                    foreach (DataRow r in m.get_data("select * from " + user + ".d_dlogin").Tables[0].Rows)
                    {
                        try
                        {
                            d.execute_data("update " + user + ".d_dlogin set password_='" + m.decode(r["password_"].ToString()) + "' where id=" + decimal.Parse(r["id"].ToString()));
                        }
                        catch { }
                    }
                    d.execute_data("delete from " + user + ".d_thongso where id=-13");
                    MessageBox.Show(lan.Change_language_MessageText("Đã giải hóa mật khẩu !"), LibMedi.AccessData.Msg);
                }
                else MessageBox.Show(lan.Change_language_MessageText("Mật khẩu chưa mã hóa !"), LibMedi.AccessData.Msg);
            }
            else if (e.KeyCode == Keys.L && e.Control && e.Alt && e.Shift)
            {
                frmRight_BV f = new frmRight_BV(d, tree, i_nhom);
                f.Show();
            }
        }

        private void kiemtra_nhap()
        {
            Cursor = Cursors.WaitCursor;
            string user = d.user,sql;
            d.execute_data("update " + user + mmyy + ".d_tonkhoct set slnhap=0 where makho in (select id from " + user + ".d_dmkho where nhom=" + i_nhom+")");
            sql = "select id,makho,manguon,nhomcc from " + user+mmyy + ".d_nhapll where nhom=" + i_nhom;
            decimal sttt = 0; bool bFound = false;
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                sql = "select stt,mabd,handung,losx,soluong,dongia,giaban,giamua,namsx,baohanh,nguongoc,tinhtrang,sothe,tyle_ggia,st_ggia";
                sql+=" from " + user + mmyy + ".d_nhapct where id=" + decimal.Parse(r["id"].ToString());
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    sql = "select * from " + user + mmyy + ".d_tonkhoct where idn=" + decimal.Parse(r["id"].ToString()) + " and sttn=" + decimal.Parse(r1["stt"].ToString());
                    sttt = 0;
                    foreach(DataRow r2 in d.get_data(sql).Tables[0].Rows) sttt=decimal.Parse(r2["stt"].ToString());
                    bFound = sttt != 0;
                    if (sttt == 0)
                    {
                        sttt = d.getidyymmdd(9);
                    }
                    d.upd_theodoi(mmyy, sttt, int.Parse(r1["mabd"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()),
                        r1["handung"].ToString(), r1["losx"].ToString(), r1["sothe"].ToString(), r1["namsx"].ToString(), r1["namsx"].ToString(),
                        int.Parse(r1["baohanh"].ToString()), int.Parse(r1["nguongoc"].ToString()), int.Parse(r1["tinhtrang"].ToString()),
                        decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["dongia"].ToString()),
                        decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()));
                    if (bFound) d.execute_data("update " + user+mmyy + ".d_tonkhoct set slnhap=slnhap+"+decimal.Parse(r1["soluong"].ToString())+" where idn="+decimal.Parse(r["id"].ToString())+" and sttn="+decimal.Parse(r1["stt"].ToString())+" and makho="+int.Parse(r["makho"].ToString()));
                    else d.execute_data("insert into " + user+mmyy + ".d_tonkhoct(makho,stt,idn,sttn,mabd,tondau,slnhap,slxuat) values ("+int.Parse(r["makho"].ToString())+","+sttt+","+decimal.Parse(r["id"].ToString())+","+decimal.Parse(r1["stt"].ToString())+","+decimal.Parse(r1["mabd"].ToString())+",0,"+decimal.Parse(r1["soluong"].ToString())+",0)");
                }
            }            
            d.upd_tonkho(i_nhom, mmyy);
            Cursor = Cursors.Default;
            MessageBox.Show(lan.Change_language_MessageText("Đã kiểm tra số liệu tồn kho !"), d.Msg);
        }
	}
}
