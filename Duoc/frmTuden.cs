using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmTuden.
	/// </summary>
	public class frmTuden : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butChon;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibDuoc.AccessData d;
        private bool bCongdon, bThua ;
		private string s_makho,f_ngay,sql;
		public int i_makp,i_phieu,i_nhom,i_loai;
		public string user,xxx,s_mmyy,s_tu,s_den,s_ngay,s_tenkp,s_phieu;
		private DataTable dtphieu=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtph=new DataTable();
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.CheckedListBox phieudutru;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkNgay;
		private System.Windows.Forms.TextBox kp;
        private CheckBox chkChuyen;
        private int i_userid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTuden(LibDuoc.AccessData acc,DataTable tkp,DataTable tphieu,int iNhom,int iMakp,int iLoai,int iPhieu,string ngay,bool congdon,bool thua,string makho,string mmyy,int iuserid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=iNhom;i_makp=iMakp;i_loai=iLoai;
			i_phieu=iPhieu;dtphieu=tphieu;dtkp=tkp;bThua=thua;s_makho=makho;
            s_ngay = ngay; bCongdon = congdon; s_mmyy = mmyy;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_userid = iuserid;//gam 07/01/2011
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTuden));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butChon = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.ComboBox();
            this.phieu = new System.Windows.Forms.ComboBox();
            this.phieudutru = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkNgay = new System.Windows.Forms.CheckBox();
            this.kp = new System.Windows.Forms.TextBox();
            this.chkChuyen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(134, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(57, 26);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(169, 26);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-4, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Phiếu :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butChon
            // 
            this.butChon.Image = global::Duoc.Properties.Resources.ok;
            this.butChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChon.Location = new System.Drawing.Point(63, 221);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(72, 25);
            this.butChon.TabIndex = 6;
            this.butChon.Text = "     &Chọn";
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(136, 221);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(88, 50);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(160, 21);
            this.makp.TabIndex = 3;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // phieu
            // 
            this.phieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(57, 74);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(191, 21);
            this.phieu.TabIndex = 4;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
            // 
            // phieudutru
            // 
            this.phieudutru.CheckOnClick = true;
            this.phieudutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieudutru.Location = new System.Drawing.Point(57, 98);
            this.phieudutru.Name = "phieudutru";
            this.phieudutru.Size = new System.Drawing.Size(190, 116);
            this.phieudutru.TabIndex = 5;
            this.phieudutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Lọc :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNgay
            // 
            this.chkNgay.Location = new System.Drawing.Point(11, 4);
            this.chkNgay.Name = "chkNgay";
            this.chkNgay.Size = new System.Drawing.Size(129, 19);
            this.chkNgay.TabIndex = 8;
            this.chkNgay.Text = "Lấy ngày chưa duyệt";
            this.chkNgay.Click += new System.EventHandler(this.chkNgay_Click);
            // 
            // kp
            // 
            this.kp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kp.Location = new System.Drawing.Point(57, 50);
            this.kp.Name = "kp";
            this.kp.Size = new System.Drawing.Size(30, 21);
            this.kp.TabIndex = 2;
            this.kp.Validated += new System.EventHandler(this.kp_Validated);
            this.kp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkChuyen
            // 
            this.chkChuyen.Location = new System.Drawing.Point(137, 4);
            this.chkChuyen.Name = "chkChuyen";
            this.chkChuyen.Size = new System.Drawing.Size(118, 19);
            this.chkChuyen.TabIndex = 9;
            this.chkChuyen.Text = "Chuyển xuống kho";
            // 
            // frmTuden
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 256);
            this.Controls.Add(this.chkChuyen);
            this.Controls.Add(this.kp);
            this.Controls.Add(this.chkNgay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phieudutru);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butChon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTuden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ ngày ... đến ngày";
            this.Load += new System.EventHandler(this.frmTuden_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();return;
			}
			if (phieu.SelectedIndex==-1)
			{
				phieu.Focus();return;
			}
			s_phieu="";
            if (phieudutru.CheckedItems.Count > 0)
            {
                for (int i = 0; i < phieudutru.Items.Count; i++)
                {
                    if (phieudutru.GetItemChecked(i))
                    {
                        s_phieu += dtph.Rows[i]["id"].ToString().Trim() + ",";
                    }
                }
            }
			s_tu=tu.Text;s_den=den.Text;i_phieu=int.Parse(phieu.SelectedValue.ToString());i_makp=int.Parse(makp.SelectedValue.ToString());
			s_tenkp=makp.Text;
            if (d.get_duyet(s_mmyy, i_makp, i_nhom, i_loai, i_phieu, s_ngay, s_makho))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày")+" "+s_ngay+"\n"+lan.Change_language_MessageText("Khoa")+" "+makp.Text+"\n"+lan.Change_language_MessageText("Phiếu")+" "+phieu.Text+"\n"+lan.Change_language_MessageText("Đã duyệt !"),d.Msg);
				return;
			}
			bool bChieu_sang=m.bChieu_sang;
			if (bChieu_sang)
			{
				DataRow r1,r2;
				r2=d.getrowbyid(dtphieu,"id="+int.Parse(phieu.SelectedValue.ToString()));
				if (r2!=null)
				{
					if (r2["buoi"].ToString()=="0")
					{
						r1=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
						if (r1!=null)
						{
							if (d.get_ttngay(s_ngay,r1["makp"].ToString()))
							{
								MessageBox.Show(lan.Change_language_MessageText("Ngày")+" "+s_ngay+" "+lan.Change_language_MessageText("viện phí đã in danh sách thu tiền")+"\n"+lan.Change_language_MessageText("Yêu cầu chọn phiếu buổi chiều !"),d.Msg);
								return;
							}
						}
					}
				}
			}
            if (chkChuyen.Checked)
            {
                string sql = "select id from " + xxx + ".d_duyet ";
                sql += " where done=0 and nhom=" + i_nhom + " and loai=" + i_loai;
                sql += " and makhoa=" + i_makp;
                sql += " and ngay between to_date('" + s_tu + "','" + f_ngay + "') and to_date('" + s_den + "','" + f_ngay + "')";
                if (s_phieu != "") sql += " and phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                    d.execute_data("update " + xxx + ".d_duyet set done=1 where id=" + decimal.Parse(r["id"].ToString()));
            }
            DataTable dttam = new DataTable();
            dttam = d.get_data("select computer from " + user + ".d_danglaysolieu where makp=" + i_makp +
                " and phieu=" + i_phieu + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "' and computer<>'" + System.Environment.MachineName + "'").Tables[0];
            if (dttam.Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Phiếu này đang lấy số liệu duyệt tại máy ")+ dttam.Rows[0][0].ToString() + lan.Change_language_MessageText(".\n Vui lòng chọn phiếu khác."));
                return;
            }
            d.upd_danglaysolieu(i_makp, i_phieu, s_ngay,i_userid);
			d.close();this.Close();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			s_tu="";s_den="";
			d.close();this.Close();
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void phieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void frmTuden_Load(object sender, System.EventArgs e)
		{
            chkChuyen.Visible = i_loai == 2;
            if (d.bIntheocstt(i_nhom) && i_loai == 2) label3.Text = "Tủ trực :";
            user = d.user; xxx = user + s_mmyy; f_ngay = d.f_ngay;
			load_ngay_duyet();
			phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
            phieu.DataSource = dtphieu;
			phieu.SelectedValue=i_phieu.ToString();

			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			makp.DataSource=dtkp;
			makp.SelectedValue=i_makp.ToString();
			if (makp.Items.Count>0) kp.Text=dtkp.Rows[makp.SelectedIndex]["ma"].ToString();
			string sql="select * from "+user+".d_loaiphieu ";
			if (bThua) sql+=" where id=0";
			else
			{
				sql+=" where nhom="+i_nhom+" and loai="+i_loai;
				sql+=" and id<>0 order by stt";
			}
			dtph=d.get_data(sql).Tables[0];
			phieudutru.DataSource=dtph;
            phieudutru.DisplayMember = "TEN";
            phieudutru.ValueMember = "ID";
            if (!d.bLocphieu_duyet(i_nhom) && !bCongdon && i_loai != 2) Check_phieu_default();
            else if (!d.bLocphieu_bu_khiduyet(i_nhom) && !bCongdon && i_loai == 2)  Check_phieu_default();
            load_phieu();

		}

        private void load_phieu()
        {
            string s_phieuk = "", s_loai = "";
            if (bThua) sql = "select * from " + user + ".d_loaiphieu where id=0";
            else
            {
                string s_phieu = "";
                if (s_makho != "")
                {
                    sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
                    sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
                    foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                    {
                        s_phieuk += r["phieu"].ToString();
                        s_loai += r["loaiphieu"].ToString();
                    }
                }
                string tenfile = (i_loai == 2) ? "d_bucstt" : "d_xuatsdct";
                sql = "select distinct a.phieu from " + xxx + ".d_xuatsdll a,"+xxx+"."+tenfile+" b where a.id=b.id and a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (makp.SelectedIndex != -1 && i_loai!=2) sql += " and a.makp=" + int.Parse(makp.SelectedValue.ToString());
                else if (makp.SelectedIndex != -1 && i_loai == 2) sql += " and a.makhoa=" + int.Parse(makp.SelectedValue.ToString());
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    s_phieu += r["phieu"].ToString() + ",";

                sql = "select * from " + user + ".d_loaiphieu where nhom=" + i_nhom;
                sql += " and loai=" + i_loai;
                if (s_phieu != "") sql += " and id not in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                if (s_phieuk.IndexOf(i_loai.ToString()) != -1 && s_loai != "") sql += " and id in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
                sql += " and id<>0 order by stt";
            }
            dtphieu = d.get_data(sql).Tables[0];
            phieu.DataSource = dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
            DataRow r1 = d.getrowbyid(dtphieu, "id=" + i_phieu);
            if (r1 != null) phieu.SelectedValue = i_phieu.ToString();
            sql = "select * from " + user + ".d_loaiphieu ";
            if (bThua) sql += " where id=0";
            else
            {
                s_phieuk = (makp.SelectedIndex != -1) ? dtkp.Rows[makp.SelectedIndex]["phieu"].ToString() : "";
                s_loai = (makp.SelectedIndex != -1) ? dtkp.Rows[makp.SelectedIndex]["loaiphieu"].ToString() : "";
                sql += " where nhom=" + i_nhom + " and loai=" + i_loai;
                if (s_phieuk.IndexOf(i_loai.ToString()) != -1 && s_loai != "") sql += " and id in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
                sql += " and id<>0 order by stt";
            }
            dtph = d.get_data(sql).Tables[0];
            phieudutru.DataSource = dtph;
            phieudutru.DisplayMember = "TEN";
            phieudutru.ValueMember = "ID";
        }

		private void Check_phieu_default()
		{
			for(int i=0;i<phieudutru.Items.Count;i++)
			{
				if(dtphieu.Rows[i]["id"].ToString()==i_phieu.ToString())
				{
					phieudutru.SetItemCheckState(i,CheckState.Checked);
					break;
				}				
			}
			phieudutru.Enabled=false;
		}

		private void chkNgay_Click(object sender, System.EventArgs e)
		{
			load_ngay_duyet();
		}
		private void load_ngay_duyet()
		{
			//Mac dinh lay ngay hien hanh, khi nao can moi Load lai nhung ngay chua duyet
			if(chkNgay.Checked==true)
			{
				DataTable dt=d.get_data("select to_char(ngay,'yyyymmdd') as ngay from "+xxx+".d_theodoiduyet where nhom="+i_nhom+" and loai="+i_loai+" and makp="+i_makp+" order by ngay ").Tables[0];
				if (dt.Rows.Count>0)
				{
					string s_tu=dt.Rows[0]["ngay"].ToString(),s_den=dt.Rows[dt.Rows.Count-1]["ngay"].ToString();
					tu.Value=new DateTime(int.Parse(s_tu.Substring(0,4)),int.Parse(s_tu.Substring(4,2)),int.Parse(s_tu.Substring(6,2)),0,0,0);
					den.Value=new DateTime(int.Parse(s_den.Substring(0,4)),int.Parse(s_den.Substring(4,2)),int.Parse(s_den.Substring(6,2)),0,0,0);
				}
				else
				{
					tu.Value=new DateTime(int.Parse(s_ngay.Substring(6,4)),int.Parse(s_ngay.Substring(3,2)),int.Parse(s_ngay.Substring(0,2)),0,0,0);
					den.Value=tu.Value;
				}
			}
			else
			{
				tu.Value=new DateTime(int.Parse(s_ngay.Substring(6,4)),int.Parse(s_ngay.Substring(3,2)),int.Parse(s_ngay.Substring(0,2)),0,0,0);
				den.Value=tu.Value;
			}
		}

		private void kp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DataRow r=d.getrowbyid(dtkp,"ma='"+kp.Text+"'");
				if (r!=null) makp.SelectedValue=r["id"].ToString();
				else makp.SelectedIndex=-1;
                load_phieu();
			}
			catch{}
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == makp && makp.SelectedIndex != -1)
            {
                kp.Text = dtkp.Rows[makp.SelectedIndex]["ma"].ToString();
                load_phieu();
            }
        }
	}
}
