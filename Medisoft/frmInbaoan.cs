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
	/// Summary description for frmYlenh.
	/// </summary>
	public class frmInbaoan : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox makp;
        private System.Windows.Forms.CheckedListBox phieu;
		private LibMedi.AccessData m;
		private string s_makp,sql,cont,s_phieu,stime,user,s_tenphieu="";
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtphieu=new System.Data.DataTable();
		private System.Data.DataTable dtnv=new System.Data.DataTable();
        private DataSet ds;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tennv;
		private MaskedTextBox.MaskedTextBox manv;
        private LibList.List listNv;
        private System.Windows.Forms.Label label8;
        private ComboBox madoituong;
        private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butKetthuc;
        private CheckBox chkxml;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInbaoan(LibMedi.AccessData acc,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            s_makp = makp; m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInbaoan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.phieu = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tennv = new System.Windows.Forms.TextBox();
            this.manv = new MaskedTextBox.MaskedTextBox();
            this.listNv = new LibList.List();
            this.label8 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chkxml = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(64, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(176, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.Validated += new System.EventHandler(this.den_Validated);
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Phiếu :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 27);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // phieu
            // 
            this.phieu.CheckOnClick = true;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(64, 96);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(192, 100);
            this.phieu.TabIndex = 12;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-3, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Y tá (ĐDV) :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tennv
            // 
            this.tennv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennv.Location = new System.Drawing.Point(102, 73);
            this.tennv.Name = "tennv";
            this.tennv.Size = new System.Drawing.Size(154, 21);
            this.tennv.TabIndex = 10;
            this.tennv.TextChanged += new System.EventHandler(this.tennv_TextChanged);
            this.tennv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennv_KeyDown);
            // 
            // manv
            // 
            this.manv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.manv.Location = new System.Drawing.Point(64, 73);
            this.manv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(36, 21);
            this.manv.TabIndex = 9;
            this.manv.Validated += new System.EventHandler(this.manv_Validated);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(-17, 118);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 23;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "Đối tượng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(64, 50);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(192, 21);
            this.madoituong.TabIndex = 7;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(62, 207);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 13;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(133, 207);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 14;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chkxml
            // 
            this.chkxml.AutoSize = true;
            this.chkxml.Location = new System.Drawing.Point(222, 200);
            this.chkxml.Name = "chkxml";
            this.chkxml.Size = new System.Drawing.Size(48, 17);
            this.chkxml.TabIndex = 24;
            this.chkxml.Text = "XML";
            this.chkxml.UseVisualStyleBackColor = true;
            // 
            // frmInbaoan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(264, 243);
            this.Controls.Add(this.chkxml);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.tennv);
            this.Controls.Add(this.manv);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInbaoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In phiếu báo ăn";
            this.Load += new System.EventHandler(this.frmInbaoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmInbaoan_Load(object sender, System.EventArgs e)	
        {
            user = m.user; stime = "'" + m.f_ngay + "'";

			sql="select * from "+user+".btdkp_bv where loai=0 and makp<>'01'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by makp";
			dtmakp=m.get_data(sql).Tables[0];
			makp.DataSource=dtmakp;
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";

            dtphieu = m.get_data("select * from " + user + ".di_dmphieu order by stt").Tables[0];
            phieu.DataSource = dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";

            madoituong.DataSource = m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.SelectedIndex = -1;

            dtnv = m.get_data("select ma,hoten,nhom from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
            listNv.DataSource = dtnv;
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (!m.ngay(m.StringToDate(tu.Text.Substring(0,10)),DateTime.Now,m.Ngaylv_Ngayht))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
				tu.Focus();
				return;
			}
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (!m.ngay(m.StringToDate(den.Text.Substring(0,10)),DateTime.Now,m.Ngaylv_Ngayht))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
				den.Focus();
				return;
			}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (makp.SelectedIndex==-1 && makp.Items.Count>0) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void taotable()
		{
            ds = new DataSet();
			cont=" where a.makp='"+makp.SelectedValue.ToString()+"' and a.done<>0";
			cont+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
            if (madoituong.SelectedIndex != -1) cont += " and b.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
			if (manv.Text!="") cont+=" and b.yta='"+manv.Text+"'";
            s_phieu = ""; s_tenphieu = "";
			for(int i=0;i<phieu.Items.Count;i++)
                if (phieu.GetItemChecked(i))
                {
                    s_phieu += dtphieu.Rows[i]["id"].ToString().Trim() + ",";
                    s_tenphieu += dtphieu.Rows[i]["ten"].ToString().Trim() + ",";
                }
			if (s_phieu!="") cont+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
            if (s_tenphieu != "") s_tenphieu = s_tenphieu.Substring(0, s_tenphieu.Length - 1);
            ds = m.getinbaoan(tu.Text, den.Text,cont,true);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			taotable();
            //foreach (DataRow r in ds.Tables[0].Rows) r["ten"]=m.holot_ten(r["ten"].ToString());
            if (chkxml.Checked)
            {
                if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                ds.WriteXml("..//xml//baoan.xml",XmlWriteMode.WriteSchema);
            }
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
				tu.Focus();
				return;
			}
            dllReportM.frmReport f = new dllReportM.frmReport(m, ds, "rptBaoan.rpt", (tu.Text == den.Text) ? "Ngày :" + tu.Text : "Từ ngày :" + tu.Text + " đến :" + den.Text, makp.Text,(madoituong.SelectedIndex!=-1)?madoituong.Text:"", s_tenphieu, tennv.Text, "");
            f.ShowDialog();
		}

		private void manv_Validated(object sender, System.EventArgs e)
		{
			if (manv.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"nhom="+LibMedi.AccessData.nhanvien+" and ma='"+manv.Text+"'");
			if (r!=null) tennv.Text=r["hoten"].ToString();
			else tennv.Text="";
		}

		private void tennv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tennv)
			{
				Filt_dmbs(tennv.Text,"nhom="+LibMedi.AccessData.nhanvien);
				listNv.BrowseToDanhmuc(tennv,manv,butIn,35);
			}
		}

		private void tennv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv.Visible) listNv.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}
		private void Filt_dmbs(string ten,string exp)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%' and "+exp;
			}
			catch{}
		}		
	}
}

