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
	/// Summary description for frmChonbaoan.
	/// </summary>
	public class frmChonbaoan : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private LibMedi.AccessData m;
		private string user,sql;
		public int i_phieu;
		public decimal l_duyet;
		public string s_makp,s_ngay,s_tenkp,s_phieu,s_mmyy;
		private DataRow r;
		private DataTable dt=new DataTable();
		private DataTable dtphieu=new DataTable();
        private DataTable dtkp = new DataTable();
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.NumericUpDown yyyy;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox kp;
        private CheckBox chkAll;
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>

		public frmChonbaoan(LibMedi.AccessData acc,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonbaoan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.phieu = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.kp = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Khoa :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Phiếu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phieu
            // 
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(45, 58);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(172, 21);
            this.phieu.TabIndex = 6;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(80, 35);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(184, 21);
            this.makp.TabIndex = 5;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(67, 85);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = global::Medisoft.Properties.Resources.exit1;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(138, 85);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(45, 11);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(83, 21);
            this.ngay.TabIndex = 0;
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(122, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số liệu :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(171, 11);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(34, 21);
            this.mm.TabIndex = 1;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(219, 11);
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(45, 21);
            this.yyyy.TabIndex = 2;
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(206, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "/";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kp
            // 
            this.kp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kp.Location = new System.Drawing.Point(45, 35);
            this.kp.Name = "kp";
            this.kp.Size = new System.Drawing.Size(32, 21);
            this.kp.TabIndex = 4;
            this.kp.Validated += new System.EventHandler(this.kp_Validated);
            this.kp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(217, 57);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 23);
            this.chkAll.TabIndex = 14;
            this.chkAll.Text = "Tất cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmChonbaoan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(274, 125);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.kp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonbaoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn thông số";
            this.Load += new System.EventHandler(this.frmChonbaoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1 && makp.Items.Count>0) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void phieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (phieu.SelectedIndex==-1) phieu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp)
			{
				if (makp.SelectedIndex!=-1) kp.Text=dtkp.Rows[makp.SelectedIndex]["makp"].ToString();
                load_phieu(chkAll.Checked);
			}
		}

		private bool kiemtra()
		{
			if (phieu.SelectedIndex==-1)
			{
				phieu.Focus();
				return false;
			}
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();
				return false;
			}
			return true;
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			s_mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			if (!m.bMmyy(s_mmyy))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+mm.Value.ToString()+"/"+yyyy.Value.ToString()+" "+lan.Change_language_MessageText("chưa tạo !"),LibMedi.AccessData.Msg);
				mm.Focus();
				return;
			}
            s_makp = makp.SelectedValue.ToString();
			s_ngay=ngay.Text;
			s_tenkp=makp.Text;
			s_phieu=phieu.Text;
			i_phieu=int.Parse(phieu.SelectedValue.ToString());
            dt = m.get_data("select a.id,a.makp,b.tenkp from " + user + s_mmyy + ".di_duyet a," + user + ".btdkp_bv b where a.makp=b.makp and to_char(a.ngay,'dd/mm/yyyy')='" + ((s_ngay.Length > 10) ? s_ngay.Substring(0, 10) : s_ngay) + "' and a.phieu=" + i_phieu + " and a.makp='" + makp.SelectedValue.ToString()+"'").Tables[0];
            l_duyet = (dt.Rows.Count==0)?0:decimal.Parse(dt.Rows[0][0].ToString());
            string ngayt = m.DateToString("dd/MM/yyyy", m.StringToDate("01/" + mm.Value.ToString().PadLeft(2, '0') + "/" + yyyy.Value.ToString().PadLeft(4, '0')).AddMonths(-1));
            string mmyyt = m.mmyy(ngayt);
            if (m.bMmyy(mmyyt))
            {
                sql = "select a.* from " + user + mmyyt + ".di_kthucdonll a," + user + mmyyt + ".di_duyet b ";
                sql += " where a.idduyet=b.id ";
                sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and phieu=" + i_phieu + " and makp='" + makp.SelectedValue.ToString()+"'";
                if (m.get_data(sql).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã nhập trong tháng") + " " + mmyyt.Substring(0, 2) + " năm 20" + mmyyt.Substring(2, 2), LibMedi.AccessData.Msg);
                    mm.Value = decimal.Parse(mmyyt.Substring(0, 2));
                    yyyy.Value = decimal.Parse("20" + mmyyt.Substring(2, 2));
                    mm.Focus();
                    return;
                }
            }
			m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			s_makp="";
			m.close();this.Close();
		}

		private void frmChonbaoan_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            dtkp = m.get_data("select * from "+user+".btdkp_bv where loai=0 and makp<>'01' order by makp").Tables[0];
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            makp.DataSource = dtkp;
            if (makp.SelectedIndex != -1) kp.Text = makp.SelectedValue.ToString();

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";            

            sql = "select mmyy from " + user + ".table ";
			sql+=" order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
			dt=m.get_data(sql).Tables[0];
			if (dt.Rows.Count>=0) s_mmyy=dt.Rows[0][0].ToString();
			else s_mmyy=s_ngay.Substring(3,2)+s_ngay.Substring(8,2);
			decimal yy=decimal.Parse("20"+s_mmyy.Substring(2,2));
			mm.Value=decimal.Parse(s_mmyy.Substring(0,2));
			yyyy.Minimum=yy-3;yyyy.Maximum=yy+3;
			yyyy.Value=yy;

            load_phieu(chkAll.Checked);
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,m.Ngaylv_Ngayht+3))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
				ngay.Focus();
				return;
			}
		}

		private void kp_Validated(object sender, System.EventArgs e)
		{
			try
			{
                makp.SelectedValue = kp.Text;
			}
			catch{}
		}

        private void load_phieu(bool all)
        {
            string s_phieu = "";
            s_mmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            s_ngay = ngay.Text;
            if (!all && m.bMmyy(s_mmyy))
            {
                sql = "select phieu from "+user+s_mmyy+".di_duyet where to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "' and done<>0 ";
                sql += " and makp='"+makp.SelectedValue.ToString()+"'";
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows) s_phieu += r["phieu"].ToString() + ",";
            }
            sql = "select * from " + user + ".di_dmphieu where id<>0";
            if (s_phieu != "") sql += " and id not in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
            sql += " order by stt";
            dtphieu = m.get_data(sql).Tables[0];
            phieu.DataSource = dtphieu;
        }

        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == chkAll) load_phieu(chkAll.Checked);
        }
	}
}
