using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSuamabn_cls.
	/// </summary>
	public class frmSuamabn_cls : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn1;
		private System.Windows.Forms.TextBox mabn2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox mabn4;
		private System.Windows.Forms.TextBox mabn3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private string macu,mamoi,sql,user,nam,mmyy;
        private int i_userid;
		private System.Windows.Forms.TextBox tqx;
        private System.Windows.Forms.Label lhoten;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSuamabn_cls(LibMedi.AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuamabn_cls));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn1 = new System.Windows.Forms.TextBox();
            this.mabn2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tqx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mabn4 = new System.Windows.Forms.TextBox();
            this.mabn3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butSua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lhoten = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Mã BN củ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn1
            // 
            this.mabn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn1.Location = new System.Drawing.Point(96, 11);
            this.mabn1.MaxLength = 2;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(24, 21);
            this.mabn1.TabIndex = 1;
            this.mabn1.Validated += new System.EventHandler(this.mabn1_Validated);
            this.mabn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            this.mabn1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn1_KeyPress);
            // 
            // mabn2
            // 
            this.mabn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(122, 11);
            this.mabn2.MaxLength = 6;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(46, 21);
            this.mabn2.TabIndex = 2;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            this.mabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            this.mabn2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn2_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(176, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(224, 11);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(184, 21);
            this.hoten.TabIndex = 4;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(480, 11);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 21);
            this.namsinh.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(416, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(320, 35);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(200, 21);
            this.diachi.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(272, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.Enabled = false;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(96, 59);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(424, 21);
            this.tqx.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-1, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tỉnh,Quận,P.Xã :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(96, 35);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(176, 21);
            this.mann.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Nghề nghiệp :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn4
            // 
            this.mabn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn4.Location = new System.Drawing.Point(122, 91);
            this.mabn4.MaxLength = 6;
            this.mabn4.Name = "mabn4";
            this.mabn4.Size = new System.Drawing.Size(46, 21);
            this.mabn4.TabIndex = 15;
            this.mabn4.Validated += new System.EventHandler(this.mabn4_Validated);
            this.mabn4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn4_KeyDown);
            this.mabn4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn4_KeyPress);
            // 
            // mabn3
            // 
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(96, 91);
            this.mabn3.MaxLength = 2;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(24, 21);
            this.mabn3.TabIndex = 14;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            this.mabn3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn3_KeyDown);
            this.mabn3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn3_KeyPress);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "&Mã BN mới :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(169, 119);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(94, 25);
            this.butSua.TabIndex = 21;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(265, 119);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(93, 25);
            this.butKetthuc.TabIndex = 22;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // lhoten
            // 
            this.lhoten.ForeColor = System.Drawing.Color.Red;
            this.lhoten.Location = new System.Drawing.Point(176, 91);
            this.lhoten.Name = "lhoten";
            this.lhoten.Size = new System.Drawing.Size(344, 23);
            this.lhoten.TabIndex = 16;
            this.lhoten.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSuamabn_cls
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 160);
            this.Controls.Add(this.lhoten);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.mabn4);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tqx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSuamabn_cls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa mã người bệnh trong cận lâm sàng";
            this.Load += new System.EventHandler(this.frmSuamabn_cls_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void mabn1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn1_Validated(object sender, System.EventArgs e)
		{
			mabn1.Text=mabn1.Text.PadLeft(2,'0');
		}

		private void mabn2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void emp_text()
		{
			hoten.Text="";
			namsinh.Text="";
			diachi.Text="";
			mann.Text="";
			tqx.Text="";
            nam = "";
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			emp_text();
            mabn2.Text = mabn2.Text.PadLeft(6, '0');
			macu=mabn1.Text+mabn2.Text;
			sql="select a.nam,a.hoten,a.namsinh,trim(a.sonha)||' '||a.thon as diachi,b.tennn,trim(c.tentt)||','||trim(d.tenquan)||','||e.tenpxa as tqx";
            sql += " from " + user + ".btdbn a," + user + ".btdnn_bv b," + user + ".btdtt c," + user + ".btdquan d," + user + ".btdpxa e";
			sql+=" where a.mann=b.mann and a.matt=c.matt and a.maqu=d.maqu and a.maphuongxa=e.maphuongxa";
			sql+=" and a.mabn='"+macu+"'";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
                nam = r["nam"].ToString().Trim();
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				diachi.Text=r["diachi"].ToString();
				mann.Text=r["tennn"].ToString();
				tqx.Text=r["tqx"].ToString();
				break;
			}
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy mã người bệnh ")+macu,LibMedi.AccessData.Msg);
				mabn1.Focus();
			}
		}

		private void mabn3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
			mabn3.Text=mabn3.Text.PadLeft(2,'0');
		}

		private void mabn4_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn4_Validated(object sender, System.EventArgs e)
		{
			mabn4.Text=mabn4.Text.PadLeft(6,'0');
			lhoten.Text="";
			macu=mabn1.Text+mabn2.Text;
			mamoi=mabn3.Text+mabn4.Text;
			if (macu==mamoi)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã người bệnh củ và mới không được trùng nhau !"),LibMedi.AccessData.Msg);
				mabn3.Focus();
				return;
			}

            foreach (DataRow r in m.get_data("select hoten,namsinh,sonha,thon from " + user + ".btdbn where mabn='" + mamoi + "'").Tables[0].Rows)
			{
				lhoten.Text=r["hoten"].ToString().Trim().ToUpper()+", NĂM SINH : "+r["namsinh"].ToString()+", ĐỊA CHỈ :"+r["sonha"].ToString().Trim().ToUpper()+" "+r["thon"].ToString().Trim().ToUpper();
				break;
			}
		}

		private bool kiemtra()
		{
			if (hoten.Text=="" || mabn1.Text=="" || mabn2.Text=="")
			{
				mabn1.Focus();
				return false;
			}
			if (mabn3.Text=="" || mabn4.Text=="")
			{
				mabn3.Focus();
				return false;
			}
			return true;
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			macu=mabn1.Text+mabn2.Text;
			mamoi=mabn3.Text+mabn4.Text;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý sửa mã người bệnh ")+macu+lan.Change_language_MessageText(" thành ")+mamoi,LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
				try
				{
                    int i = 0, itable=0;
                    while (i < nam.Trim().Length)
                    {
                        mmyy = nam.Substring(i, 4);
                        if (m.bMmyy(mmyy))
                        {
                            foreach (DataRow r in m.get_data("select * from " + user + mmyy + ".cls_ketqua where mabn='" + macu + "'").Tables[0].Rows)
                            {
                                itable = m.tableid(mmyy, "cls_ketqua");
                                m.upd_eve_tables(itable, i_userid, "upd");
                                m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + mmyy + ".cls_ketqua", "id=" + decimal.Parse(r["id"].ToString())));
                            }
                            sql = "update " + user+mmyy + ".cls_ketqua set mabn='" + mamoi + "' where mabn='" + macu + "'";
                            m.execute_data(sql);
                        }
                        i += 5;
                    }
				}
				catch{}
				MessageBox.Show(lan.Change_language_MessageText("Đã sửa thành công !"),LibMedi.AccessData.Msg);
				mabn1.Focus();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void frmSuamabn_cls_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			mabn1.Text=DateTime.Now.Year.ToString().Substring(2,2);
			mabn3.Text=mabn1.Text;
		}

		private void mabn1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void mabn2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void mabn3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void mabn4_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}
	}
}
