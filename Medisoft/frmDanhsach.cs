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
	/// Summary description for frmDanhsach.
	/// </summary>
	public class frmDanhsach : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m;
		private int i_userid;
		private decimal l_donvi,iCapso=0;
		private string s_mmyy,s_ma = "",s_mabn="",nam,s_madantoc="",s_matt="",vd_namsinh="",user;
		private DataTable dt = new DataTable();
		private bool bMabn_tudong;
		public bool bOk = false;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox dienthoai;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox mann;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butMoi;
		private System.ComponentModel.Container components = null;

		public frmDanhsach(AccessData acc,string mmyy,string ma,string mabn,decimal donvi,int userid,DataTable dta,string title)
		{
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 

            m = acc; s_mmyy = mmyy; s_ma = ma; s_mabn = mabn; l_donvi = donvi; i_userid = userid; dt = dta;
            this.Text = title; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhsach));
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.phai = new System.Windows.Forms.ComboBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dienthoai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.ComboBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // stt
            // 
            this.stt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(74, 12);
            this.stt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(39, 21);
            this.stt.TabIndex = 1;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(183, 60);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(129, 21);
            this.phai.TabIndex = 9;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(74, 60);
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(46, 21);
            this.namsinh.TabIndex = 7;
            this.namsinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.namsinh_KeyPress);
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            this.namsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(74, 36);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(238, 21);
            this.hoten.TabIndex = 5;
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(127, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 13);
            this.label22.TabIndex = 8;
            this.label22.Text = "Giới tính :";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(0, 66);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "Năm sinh :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(0, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Họ tên :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Stt :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butBoqua
            // 
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(205, 168);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 18;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(135, 168);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 16;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(168, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(240, 12);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(73, 21);
            this.mabn.TabIndex = 3;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Điện thoại :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dienthoai
            // 
            this.dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienthoai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienthoai.Location = new System.Drawing.Point(74, 108);
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Size = new System.Drawing.Size(238, 21);
            this.dienthoai.TabIndex = 13;
            this.dienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nghề nghiệp :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(74, 84);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(238, 21);
            this.mann.TabIndex = 11;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(74, 132);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(238, 21);
            this.diachi.TabIndex = 15;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(65, 168);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 17;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // frmDanhsach
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(322, 207);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dienthoai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhsach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDanhsach";
            this.Load += new System.EventHandler(this.frmDanhsach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void frmDanhsach_Load(object sender, EventArgs e)
		{
			bMabn_tudong = m.bMabn_tudong_tiepdon;
            user = m.user;
			mann.DisplayMember="TENNN";
			mann.ValueMember="MANN";
			mann.DataSource=m.get_data("select * from "+user+".btdnn_bv order by mann").Tables[0];
			phai.SelectedIndex = 0;
			if (s_mabn != "")
			{
				DataRow r = m.getrowbyid(dt, "mabn='" + s_mabn + "'");
				if (r != null)
				{
					stt.Value = decimal.Parse(r["stt"].ToString());
					mabn.Text = r["mabn"].ToString();
					hoten.Text = r["hoten"].ToString();
					namsinh.Text = r["namsinh"].ToString();
					phai.SelectedIndex = int.Parse(r["phai"].ToString());
				}
			}
			else stt.Value = Convert.ToDecimal(dt.Rows.Count + 1);		
		}

		private void stt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void namsinh_KeyPress(object sender, KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private bool kiemtra()
		{
			if (mabn.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập Mã BN !"),LibMedi.AccessData.Msg);
				mabn.Focus();
				return false;
			}
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập họ và tên !"),LibMedi.AccessData.Msg);
				hoten.Focus();
				return false;
			}
			if (namsinh.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập năm sinh !"),LibMedi.AccessData.Msg);
				namsinh.Focus();
				return false;
			}
			s_mabn=mabn.Text;
			return true;
		}
		private void butLuu_Click(object sender, EventArgs e)
		{
			if (!kiemtra()) return;
			m.upd_kskbtdbn(l_donvi, stt.Value, s_mabn, hoten.Text, namsinh.Text, phai.SelectedIndex,mann.SelectedValue.ToString(),dienthoai.Text,diachi.Text,i_userid);
			if (iCapso!=0 && hoten.Enabled)
			{
				nam=m.get_mabn_nam(s_mabn);
				if (nam.IndexOf(s_mmyy + "+") == -1) nam = nam + s_mmyy + "+";
                if (m.get_data("select * from " + user + ".btdbn where mabn='" + mabn.Text + "'").Tables[0].Rows.Count == 0)
					m.upd_btdbn(mabn.Text, hoten.Text,"", (namsinh.Text=="")?vd_namsinh:namsinh.Text, phai.SelectedIndex,mann.SelectedValue.ToString(),s_madantoc,"","","",s_matt,s_matt+"00",s_matt+"0000", i_userid, nam);
			}
			bOk = true;
			DataRow r1;
			r1=m.getrowbyid(dt,"mabn='"+mabn.Text+"'");
			if (r1==null)
			{
				DataRow r2=dt.NewRow();
				r2["stt"]=stt.Value;
				r2["mabn"]=mabn.Text;
				r2["hoten"]=hoten.Text;
				r2["namsinh"]=namsinh.Text;
				r2["phai"]=phai.SelectedIndex;
				r2["mann"]=mann.SelectedValue.ToString();
				r2["dienthoai"]=dienthoai.Text;
				r2["diachi"]=diachi.Text;
				dt.Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=dt.Select("mabn='"+mabn.Text+"'");
				if (dr.Length>0)
				{
					dr[0]["stt"]=stt.Value;
					dr[0]["mabn"]=mabn.Text;
					dr[0]["hoten"]=hoten.Text;
					dr[0]["namsinh"]=namsinh.Text;
					dr[0]["phai"]=phai.SelectedIndex;
					dr[0]["mann"]=mann.SelectedValue.ToString();
					dr[0]["dienthoai"]=dienthoai.Text;
					dr[0]["diachi"]=diachi.Text;
				}
			}
			butMoi.Focus();
			//m.close();this.Close();
		}

		private void butBoqua_Click(object sender, EventArgs e)
		{
			m.close();this.Close();
		}

		private void namsinh_Validated(object sender, EventArgs e)
		{
			if (namsinh.Text!="")
				if (namsinh.Text.Length < 4) 
					namsinh.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text));
		}

		private void mabn_Validated(object sender, EventArgs e)
		{
			if (mabn.Text == "" || mabn.Text.Trim().Length < 3) return;
			if (mabn.Text.Trim().Length != 8) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
			if (bMabn_tudong && mabn.Text == "")
			{
                decimal stt = 0;
                for (; ; )
                {
                    stt = m.get_mabn(int.Parse(s_mmyy.Substring(0, 2)), 1, 1, true);
                    mabn.Text = s_mmyy.Substring(0, 2) + stt.ToString().PadLeft(6, '0');
                    if (m.get_data("select * from " + user + ".btdbn where mabn='" + mabn.Text + "'").Tables[0].Rows.Count == 0) break;
                }
				return;
			}
			else if (mabn.Text=="") return;			
			bool bFound = false;
            foreach (DataRow r in m.get_data("select * from " + user + ".kskbtdbn where mabn='" + mabn.Text + "'").Tables[0].Rows)
			{
				hoten.Text = r["hoten"].ToString();
				namsinh.Text = r["namsinh"].ToString();
				phai.SelectedIndex = int.Parse(r["phai"].ToString());
				mann.SelectedValue=r["mann"].ToString();
				dienthoai.Text=r["dienthoai"].ToString();
				diachi.Text=r["diachi"].ToString();
				bFound = true;
				break;
			}
			if (!bFound)
			{
                foreach (DataRow r in m.get_data("select a.*,b.nha as dienthoai from " + user + ".btdbn a left join " + user + ".dienthoai b on a.mabn=b.mabn where a.mabn='" + mabn.Text + "'").Tables[0].Rows)
				{
					hoten.Text = r["hoten"].ToString();
					namsinh.Text = r["namsinh"].ToString();
					phai.SelectedIndex = int.Parse(r["phai"].ToString());
					mann.SelectedValue=r["mann"].ToString();
					dienthoai.Text=r["dienthoai"].ToString();
					diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString();
					bFound = true;
					break;
				}
			}
			hoten.Enabled = !bFound;
			namsinh.Enabled = hoten.Enabled;
			phai.Enabled = hoten.Enabled;
			if (bFound) butLuu.Focus();
		}

		private void mann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (mann.SelectedIndex==-1 && mann.Items.Count>0) mann.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
				stt.Value = decimal.Parse(dt.Rows[dt.Rows.Count-1]["stt"].ToString())+1;
			}
			catch{stt.Value=1;}
			mabn.Text = "";	hoten.Text = "";
			namsinh.Text = "";dienthoai.Text="";diachi.Text="";			
			mabn.Focus();
		}
	}
}
