using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmYlenh.
	/// </summary>
	public class frmYlenh : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.CheckedListBox loai;
		private System.Windows.Forms.CheckedListBox phieu;
		private System.Windows.Forms.CheckedListBox makho;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m;
        private string s_makp, sql, s_makho, s_loai, cont, s_phieu, sql1, tenfile, s_nhomkho, user, stime, s_tenphieu = "", s_buoi;
		private bool bSovaovien;
        private bool bIntheoSLDuyet = false;
        private string s_field_soluong = "slyeucau";
		private DataRow r;
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtloai=new System.Data.DataTable();
		private System.Data.DataTable dtphieu=new System.Data.DataTable();
		private System.Data.DataTable dtdmbd=new System.Data.DataTable();
        private DataSet ds;
		private DataSet dsmabd=new DataSet();
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Button butPreview;
		private System.Windows.Forms.CheckBox chkNhathuoc;
        private ComboBox madoituong;
        private ComboBox manguon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkTutruc;
        private System.Windows.Forms.CheckBox chkslduyet;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmYlenh(LibMedi.AccessData acc,string makp,string _nhomkho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			s_makp=makp;s_nhomkho=_nhomkho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYlenh));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.loai = new System.Windows.Forms.CheckedListBox();
            this.phieu = new System.Windows.Forms.CheckedListBox();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butPreview = new System.Windows.Forms.Button();
            this.chkNhathuoc = new System.Windows.Forms.CheckBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkTutruc = new System.Windows.Forms.CheckBox();
            this.chkslduyet = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 8);
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
            this.tu.Location = new System.Drawing.Point(64, 8);
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
            this.den.Location = new System.Drawing.Point(176, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.Validated += new System.EventHandler(this.den_Validated);
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Loại :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Phiếu :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 55);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 7;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // nhom
            // 
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(64, 32);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(192, 21);
            this.nhom.TabIndex = 5;
            this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // loai
            // 
            this.loai.CheckOnClick = true;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(64, 80);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(192, 68);
            this.loai.TabIndex = 9;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // phieu
            // 
            this.phieu.CheckOnClick = true;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(64, 151);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(192, 84);
            this.phieu.TabIndex = 11;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(259, 55);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(216, 180);
            this.makho.TabIndex = 14;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(115, 243);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 16;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(187, 243);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 17;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butPreview
            // 
            this.butPreview.Image = ((System.Drawing.Image)(resources.GetObject("butPreview.Image")));
            this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPreview.Location = new System.Drawing.Point(43, 243);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(70, 25);
            this.butPreview.TabIndex = 15;
            this.butPreview.Text = "    &Xem";
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // chkNhathuoc
            // 
            this.chkNhathuoc.AutoSize = true;
            this.chkNhathuoc.Location = new System.Drawing.Point(262, 239);
            this.chkNhathuoc.Name = "chkNhathuoc";
            this.chkNhathuoc.Size = new System.Drawing.Size(120, 17);
            this.chkNhathuoc.TabIndex = 18;
            this.chkNhathuoc.Text = "Kèm đơn nhà thuốc";
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(316, 31);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(159, 21);
            this.madoituong.TabIndex = 13;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(316, 8);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(159, 21);
            this.manguon.TabIndex = 12;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(259, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "Nguồn :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(256, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "Đối tượng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTutruc
            // 
            this.chkTutruc.AutoSize = true;
            this.chkTutruc.Enabled = false;
            this.chkTutruc.Location = new System.Drawing.Point(262, 258);
            this.chkTutruc.Name = "chkTutruc";
            this.chkTutruc.Size = new System.Drawing.Size(145, 17);
            this.chkTutruc.TabIndex = 18;
            this.chkTutruc.Text = "Kèm theo tồn cuối tủ trực";
            // 
            // chkslduyet
            // 
            this.chkslduyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkslduyet.Location = new System.Drawing.Point(262, 276);
            this.chkslduyet.Name = "chkslduyet";
            this.chkslduyet.Size = new System.Drawing.Size(121, 21);
            this.chkslduyet.TabIndex = 28;
            this.chkslduyet.Text = "In theo SL Duyệt";
            // 
            // frmYlenh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(482, 303);
            this.Controls.Add(this.chkslduyet);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.chkTutruc);
            this.Controls.Add(this.chkNhathuoc);
            this.Controls.Add(this.butPreview);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
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
            this.Name = "frmYlenh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp y lệnh";
            this.Load += new System.EventHandler(this.frmYlenh_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmYlenh_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void f_Load_Local()
        {
            DataSet ads = new DataSet();         
            try
            {
                ads.ReadXml("..//..//..//xml//Inylenhtutruc.xml");
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    if (r["id"].ToString() == "chkTutruc")
                    {
                        chkTutruc.Checked = (r["val"].ToString() == "1");
                        continue;
                    }
                }
            }
            catch
            {
                f_Save_Local();
            }
        }
        private void f_Save_Local()
        {
            try
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("id");
                ads.Tables[0].Columns.Add("val");
                ads.Tables[0].Rows.Add(new string[] { "chkTutruc", chkTutruc.Checked ? "1" : "0" });
                ads.WriteXml("..//..//..//xml//Inylenhtutruc.xml", XmlWriteMode.WriteSchema);
            }
            catch
            {
            }
        }
		private void frmYlenh_Load(object sender, System.EventArgs e)
		{
            f_Load_Local();


            user = m.user; stime = "'" + m.f_ngay + "'";
			bSovaovien=m.bSovaovien_ylenh;
			chkNhathuoc.Visible=m.bYlenh_nhathuoc;
			if (chkNhathuoc.Visible) chkNhathuoc.Checked=true;
			dsmabd.ReadXml("..//..//..//xml//d_mabd.xml");
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";

            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";

            madoituong.DataSource = m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.SelectedIndex = -1;

			dtloai=d.get_data("select * from "+user+".d_dmphieu where id in (1,2,3) order by stt").Tables[0];
			loai.DataSource=dtloai;
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";

            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";

            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";

            nhom.DisplayMember = "TEN";
            nhom.ValueMember = "ID";

			load_nhom();
			load_makp();
			load_makho();
		}

		private void load_makp()
		{
			if (nhom.SelectedIndex!=-1)
			{
                sql = "select * from " + user + ".d_duockp where nhom like '%" + nhom.SelectedValue.ToString() + ",%'";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
				sql+=" order by stt";
				dtmakp=d.get_data(sql).Tables[0];
				makp.DataSource=dtmakp;
			}
		}

		private void load_nhom()
		{
            sql = "select * from " + user + ".d_dmnhomkho ";
			if (s_nhomkho!="") sql+=" where id in ("+s_nhomkho.Substring(0,s_nhomkho.Length-1)+")";
			sql+=" order by stt";
			nhom.DataSource=d.get_data(sql).Tables[0];
		}

		private void load_makho()
		{
			s_makho="";
            sql = "select * from " + user + ".d_dmkho where nhom=" + int.Parse(nhom.SelectedValue.ToString());
			if (makp.SelectedIndex!=-1 && !m.bPhatthuoc_kho_khoa)
			{
				r=d.getrowbyid(dtmakp,"id="+int.Parse(makp.SelectedValue.ToString()));
				if (r!=null) s_makho=r["makho"].ToString();
			}
			if (s_makho=="") 
			{
                foreach (DataRow r1 in d.get_data("select kho from " + user + ".d_dmphieu where nhom=" + int.Parse(nhom.SelectedValue.ToString())).Tables[0].Rows)
					s_makho+=r1["kho"].ToString();
			}
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";
            sql = "select * from " + user + ".d_dmnguon";
            if (d.bQuanlynguon(int.Parse(nhom.SelectedValue.ToString()))) sql += " where nhom=" + int.Parse(nhom.SelectedValue.ToString());
            else sql += " where id=0 or nhom=" + int.Parse(nhom.SelectedValue.ToString());
            sql += " order by stt";
            manguon.DataSource = d.get_data(sql).Tables[0];
            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";
            manguon.SelectedIndex = -1;
		}


		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nhom)
			{
				load_makp();
				load_makho();
			}
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (!m.ngay(m.StringToDate(tu.Text.Substring(0,10)),DateTime.Now,m.Ngaylv_Ngayht))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống {")+m.Ngaylv_Ngayht.ToString()+"}!",LibMedi.AccessData.Msg);
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
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống {")+m.Ngaylv_Ngayht.ToString()+"}!",LibMedi.AccessData.Msg);
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

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (nhom.SelectedIndex==-1 && nhom.Items.Count>0) nhom.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == loai)
            {
                s_loai = "";
                //for (int i = 0; i < loai.Items.Count; i++)
                //    loai.SetItemChecked(i, false);
                //loai.SetItemCheckState(loai.SelectedIndex, CheckState.Checked);
                for (int i = 0; i < loai.Items.Count; i++)
                    if (loai.GetItemChecked(i)) s_loai += dtloai.Rows[i]["id"].ToString().Trim() + ",";

                if (s_loai != "")
                {
                    s_loai = s_loai.Substring(0, s_loai.Length - 1);
                    dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where nhom=" + int.Parse(nhom.SelectedValue.ToString()) + " and loai in (" + s_loai + ")" + " order by stt").Tables[0];
                }
                else dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where id=-1").Tables[0];
                phieu.DataSource = dtphieu;
                phieu.DisplayMember = "TEN";
                phieu.ValueMember = "ID";
                if (s_loai == "2") chkTutruc.Enabled = true;
                else
                {
                    chkTutruc.Enabled = false;
                    chkTutruc.Checked = false;
                }
            }
        }

        private void Get_buoi()
        {
            s_buoi = "";
            s_tenphieu = "";
            int i_incachdung = 0;
            for (int i = 0; i < phieu.Items.Count; i++)
            {
                if (phieu.GetItemChecked(i))
                {
                    i_incachdung += 1;
                    s_buoi += dtphieu.Rows[i]["ten"].ToString() + ", ";
                }
            }
            for (int i = 0; i < loai.Items.Count; i++)
                if (loai.GetItemChecked(i)) s_tenphieu += dtloai.Rows[i]["ten"].ToString() + ", ";
        }

		private void taotable()
		{
			dsmabd.Clear();
			ds=new DataSet();
			ds.ReadXml("..//..//..//xml//d_ylenh.xml");
            ds.Tables[0].Columns.Add("ngaysinh");//Khuong 05/11/2011
            ds.Tables[0].Columns.Add("doituong");//khuyen 07/03/14
            sql = "select * from " + user + ".d_dmbd ";
			if (!chkNhathuoc.Checked) sql+=" where nhom="+int.Parse(nhom.SelectedValue.ToString());
			dtdmbd=d.get_data(sql).Tables[0];
			cont=" and a.makhoa="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
            if (madoituong.SelectedIndex != -1) cont += " and c.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
            if (manguon.SelectedIndex != -1) cont += " and c.manguon=" + int.Parse(manguon.SelectedValue.ToString());
			s_phieu="";
			for(int i=0;i<phieu.Items.Count;i++)
				if (phieu.GetItemChecked(i)) s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";
			if (s_phieu!="") cont+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			s_loai="";
			for(int i=0;i<loai.Items.Count;i++)
				if (loai.GetItemChecked(i)) s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
			if (s_loai!="") cont+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			s_makho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i)) s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
			if (s_makho!="") cont+=" and c.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
            if (s_loai == "")
            {

                sql = "select distinct c.mabd from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c where a.id=b.idduyet";
                sql += " and b.id=c.id " + cont;
                sql += " union all ";

                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c where a.id=b.idduyet";
                sql += " and b.id=c.id " + cont;

                sql += " union all ";

                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c where a.id=b.idduyet";
                sql += " and b.id=c.id " + cont;
                upd_mabd(sql);

                //sql1 = " select * from (";
                sql1 = "select b.stt, b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,' ' as sovaovien,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c,xxx.d_dausinhton d," + user + ".btdbn e ," + user + ".doituong f where a.id=b.idduyet and c.madoituong=f.madoituong ";////Khuong 05/11/2011// 07/02/2014 khuyen lay cot f.doituong
                sql1 += " and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn " + cont;
                sql1 += " union all ";
                sql1 += "select b.stt, b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,' ' as sovaovien,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c,xxx.d_dausinhton d," + user + ".btdbn e ," + user + ".doituong f where a.id=b.idduyet and c.madoituong=f.madoituong ";//07/02/2014 khuyen lay cot f.doituong
                sql1 += " and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn " + cont;
               // sql1 += " and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn " + cont;
                sql1 += " union all ";
                sql1 += "select  b.stt, b.mabn,e.hoten,d.phong,d.giuong,c.mabd,-c." + s_field_soluong + " as slyeucau,' ' as sovaovien,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c,xxx.d_dausinhton d," + user + ".btdbn e, " + user + ".doituong f where a.id=b.idduyet and c.madoituong=f.madoituong ";//07/02/2014 khuyen lay cot f.doituong
                sql1 += " and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn " + cont;
                //sql1 += " ) order by stt ";
               // sql1 += " and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn " + cont;
                upd_soluong(sql1);
            }
            else
            {
                sql = ""; sql1 = "";
                for (int i = 1; i < 4; i++)
                {
                    if (s_loai.IndexOf(i.ToString()) != -1)
                    {
                        if (sql != "") sql += " union all ";
                        if (sql1 != "") sql1 += " union all ";
                        switch (i)
                        {
                            case 1:
                                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c where a.id=b.idduyet";
                                sql += " and b.id=c.id " + cont;
                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,' ' as sovaovien,case when e.ngaysinh is null then e.namsinh " +
                                "else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join xxx.d_dutruct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " +//khuyen 07/03/14 lay cot f.doituong
                                user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".d_doituong f on c.madoituong=f.madoituong where ";//gam 08/11/2011
                                sql1 += " 1=1  " + cont;
                                break;
                            case 2:
                                if (chkTutruc.Checked)
                                {
                                    sql = " select distinct mabd from xxx.d_tutrucct where makp=" + makp.SelectedValue.ToString();
                                    upd_mabd(sql);
                                    upd_soluong("select '' as mabn,'TỒN ĐẦU TỦ TRỰC' as hoten,'' as phong,'' as giuong,mabd,sum(tondau+slnhap-slxuat) as slyeucau,' ' as sovaovien,'' as ngaysinh,'' as doituong from xxx.d_tutrucct where makp=" + makp.SelectedValue.ToString() + " group by mabd");////khuyen 07/03/14 lay cot doituong
                                }
                                else
                                {
                                    sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c where a.id=b.idduyet";
                                    sql += " and b.id=c.id " + cont;
                                }
                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,' ' as sovaovien,case when e.ngaysinh is null then e.namsinh " +
                                    " else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join xxx.d_xtutrucct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".d_doituong  f on c.madoituong=f.madoituong where ";//07/03/14 khuyen lay cot doituong
                                sql1 += " 1=1 " + cont;
                                break;
                            default:
                                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c where a.id=b.idduyet";
                                sql += " and b.id=c.id " + cont;
                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,' ' as sovaovien,case when e.ngaysinh is null then e.namsinh else " +
                                    " to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet inner join xxx.d_hoantract c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".d_doituong f on c.madoituong=f.madoituong where ";//khuyen 07/03/14 lay cot doi tuong,
                                sql1 += " 1=1 " + cont;
                                break;
                        }
                    }
                }
                if (!chkTutruc.Checked)
                    upd_mabd(sql);

                upd_soluong(sql1);
            }
		}

		private void upd_mabd(string sql)
		{
			DataRow r2,r3;
			foreach(DataRow r1 in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
			{
				r=d.getrowbyid(dsmabd.Tables[0],"mabd="+int.Parse(r1["mabd"].ToString()));
				if (r==null)
				{
					r2=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
					if (r2!=null)
					{
						r3=dsmabd.Tables[0].NewRow();
						r3["mabd"]=r1["mabd"].ToString();
						r3["tenbd"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString().Trim()+" "+r2["dang"].ToString();
						r3["soluong"]=0;
						dsmabd.Tables[0].Rows.Add(r3);
					}
				}
			}
			if (chkNhathuoc.Checked)
			{
				sql="select distinct b.mabd from xxx.d_ngtrull a,xxx.d_ngtruct b,"+user+".d_duockp c where a.id=b.id and a.makp=c.id";
				if (makp.SelectedIndex!=-1) sql+=" and c.makp='"+dtmakp.Rows[makp.SelectedIndex]["makp"].ToString()+"'";
				sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
				foreach(DataRow r1 in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
				{
					r=d.getrowbyid(dsmabd.Tables[0],"mabd="+int.Parse(r1["mabd"].ToString()));
					if (r==null)
					{
						r2=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
						if (r2!=null)
						{
							r3=dsmabd.Tables[0].NewRow();
							r3["mabd"]=r1["mabd"].ToString();
							r3["tenbd"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString().Trim()+" "+r2["dang"].ToString();
							r3["soluong"]=0;
							dsmabd.Tables[0].Rows.Add(r3);
						}
					}
				}
			}
			DataRow [] dr=dsmabd.Tables[0].Select("true","tenbd");
			for(int i=0;i<dr.Length;i++)
			{
				dc=new DataColumn();
				dc.ColumnName="C_"+dr[i]["mabd"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
		}

		private void upd_soluong(string sql)
		{
			DataRow r2;
			DataRow [] dr;
			foreach(DataRow r1 in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
			{
				r=d.getrowbyid(ds.Tables[0],"mabn='"+r1["mabn"].ToString()+"'");
				if (r==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["stt"]=d.get_stt(ds.Tables[0]).ToString();
					r2["mabn"]=r1["mabn"].ToString();
					r2["hoten"]=r1["hoten"].ToString();
					r2["phong"]=(bSovaovien)?r1["sovaovien"].ToString():r1["phong"].ToString();
					r2["giuong"]=r1["giuong"].ToString();
                    r2["ngaysinh"] = r1["ngaysinh"].ToString();//Khuong 05/11/2011
                    r2["DOITUONG"] = r1["DOITUONG"].ToString();//KHUYEN 07/03/14
					foreach(DataRow r3 in dsmabd.Tables[0].Rows) r2["C_"+r3["mabd"].ToString().Trim()]=0;
					r2["C_"+r1["mabd"].ToString().Trim()]=r1["slyeucau"].ToString();
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr=ds.Tables[0].Select("mabn='"+r1["mabn"].ToString()+"'");
					if (dr.Length>0) dr[0]["C_"+r1["mabd"].ToString().Trim()]=decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString())+decimal.Parse(r1["slyeucau"].ToString());
				}
                if (r1["mabn"].ToString() != "") 
                {
                    dr = dsmabd.Tables[0].Select("mabd=" + int.Parse(r1["mabd"].ToString()));
                    if (dr.Length > 0) dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r1["slyeucau"].ToString());
                }
			}

			if (chkNhathuoc.Checked)
			{
				sql="select a.mabn,a.hoten,'' as phong,'' as giuong,b.mabd,b.soluong as slyeucau,'' as sovaovien from xxx.d_ngtrull a,xxx.d_ngtruct b,"+user+".d_duockp c where a.id=b.id and a.makp=c.id";
				if (makp.SelectedIndex!=-1) sql+=" and c.makp='"+dtmakp.Rows[makp.SelectedIndex]["makp"].ToString()+"'";
				sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
				foreach(DataRow r1 in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
				{
					r=d.getrowbyid(ds.Tables[0],"mabn='"+r1["mabn"].ToString()+"'");
					if (r==null)
					{
						r2=ds.Tables[0].NewRow();
						r2["stt"]=d.get_stt(ds.Tables[0]).ToString();
						r2["mabn"]=r1["mabn"].ToString();
						r2["hoten"]=r1["hoten"].ToString();
						r2["phong"]=(bSovaovien)?r1["sovaovien"].ToString():r1["phong"].ToString();
						r2["giuong"]=r1["giuong"].ToString();
                        r2["ngaysinh"] = r1["ngaysinh"].ToString();//Khuong 05/11/2011
                        r2["DOITUONG"] = r1["DOITUONG"].ToString();//KHUYEN 07/03/14
						foreach(DataRow r3 in dsmabd.Tables[0].Rows) r2["C_"+r3["mabd"].ToString().Trim()]=0;
						r2["C_"+r1["mabd"].ToString().Trim()]=r1["slyeucau"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
					else
					{
						dr=ds.Tables[0].Select("mabn='"+r1["mabn"].ToString()+"'");
						if (dr.Length>0) dr[0]["C_"+r1["mabd"].ToString().Trim()]=decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString())+decimal.Parse(r1["slyeucau"].ToString());
					}
                    if (r1["mabn"].ToString() != "")
                    {
                        dr = dsmabd.Tables[0].Select("mabd=" + int.Parse(r1["mabd"].ToString()));
                        if (dr.Length > 0)
                            dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r1["slyeucau"].ToString());
                    }
				}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            bIntheoSLDuyet = chkslduyet.Checked;
            s_field_soluong = (bIntheoSLDuyet) ? "slthuc" : "slyeucau";
			taotable();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
            Get_buoi();
			exp_excel(true);
		}

		private void butPreview_Click(object sender, System.EventArgs e)
		{
            bIntheoSLDuyet = chkslduyet.Checked;
            s_field_soluong = (bIntheoSLDuyet) ? "slthuc" : "slyeucau";
            taotable();
			if (ds.Tables[0].Rows.Count==0)
			{
                
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
            Get_buoi();
            if (ds.Tables[0].Rows.Count > 0)
            {
                int i = 0; string smabn = "";
                DataSet dstemp = ds.Clone();
                foreach (DataRow r in ds.Tables[0].Select("", "mabn"))
                {
                    if (smabn != r["mabn"].ToString())
                    {
                        i++;
                    }
                    r["stt"] = i.ToString();
                    smabn = r["mabn"].ToString();
                    dstemp.Tables[0].Rows.Add(r.ItemArray);
                }
                ds.Clear();
                ds = dstemp.Copy();
            }

            //khuyen khoa 13/01/2014 exp_excel(false);
            //khuyen 13/01/2014 Can loc
            if (d.Mabv == "405.5.04")
            {
                exp_excelCanLoc(false);
            }

            else
                exp_excel(false);
            //
		}

		private string get_ten(int i)
		{
			string s=(bSovaovien)?"SỐ VÀO VIỆN":"PHÒNG";
			string []map={"STT","MÃ BN","HỌ TÊN",s,"GIƯỜNG","NGÀY SINH","ĐỐI TƯỢNG"};
			return map[i];
		}
        private void exp_excelCanLoc(bool print)
        {
            try
            {
                d.check_process_Excel();

                int be = 3, cot = ds.Tables[0].Columns.Count, dong = ds.Tables[0].Rows.Count + be + 2, sss = dong - 1, sodong = dong + 1;

                DataColumn dc = new DataColumn();
                dc.ColumnName = "ghichu";
                dc.DataType = Type.GetType("System.String");
                ds.Tables[0].Columns.Add(dc);
                DataRow drstt = ds.Tables[0].NewRow();
                for (int i = 0; i < cot+1; i++)
                {
                    drstt[i] = i.ToString();
                }
                ds.Tables[0].Rows.InsertAt(drstt, 0);
                
                tenfile = d.Export_Excel(ds, "ylenh");
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;
                for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
                for (int i = 0; i < 7; i++) osheet.Cells[be + 1, i + 1] = get_ten(i); //Khuong 05/11/2011
               
                DataRow[] dr = dsmabd.Tables[0].Select("true", "tenbd");
                for (int i = 0; i < dr.Length; i++)
                {
                    osheet.Cells[be + 1, i + 8] = dr[i]["tenbd"].ToString(); //Khuong 05/11/2011
                    osheet.Cells[dong+1, i + 8] = dr[i]["soluong"].ToString(); //Khuong 05/11/2011
                }
                if (chkTutruc.Checked)
                {

                    osheet.Cells[dong + 1, 3] = "TỔNG TỒN CUỐI";
                    for (int i = 5; i < dsmabd.Tables[0].Rows.Count + 6; i++) //Khuong 05/11/2011
                    {
                        osheet.Cells[dong + 1, i] = "=" + d.getIndex(i - 1) + "5" + "-" + d.getIndex(i - 1) + dong.ToString() + "";
                    }
                }
                osheet.Cells[4, cot + 1] = "Ghi chú";
                //tieu de của dòng 4 nằm theo chiều ngang
               
                orange = osheet.get_Range(d.getIndex(be) + "4", d.getIndex(cot ) + "4");
                orange.VerticalAlignment = XlVAlign.xlVAlignBottom;
                orange.Orientation = 90;
                orange.RowHeight = 200;
                orange.EntireRow.AutoFit();
                //
                
                //font chử
                orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(cot +10) + dong+10);
                orange.Font.Name = "Arial";
                orange.Font.Size = 10;
                orange.Font.Bold = false;
                //
                //ke bang
                osheet.get_Range(d.getIndex(0) + "4", d.getIndex(cot) + sodong.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                
                orange.EntireColumn.AutoFit();
                orange = osheet.get_Range(d.getIndex(cot) + "1", d.getIndex(cot + 100) + dong + 10);
                orange.Cells.ColumnWidth = 3;

                  
               //
                //to mau tu cot thu 6
             
                for (int i = 7; i < cot; i++)
                {
                    if (i % 2 == 0)
                    {
                        orange = osheet.get_Range(d.getIndex(i) + "4", d.getIndex(i) + sodong.ToString());
                        orange.Interior.Color = System.Drawing.Color.Beige.ToArgb();
                        
                    }

                }
                //
                    osheet.get_Range(d.getIndex(4) + dong.ToString(), d.getIndex(cot - 1) + dong.ToString()).Font.Bold = true;
                if (chkTutruc.Checked)
                {
                    osheet.get_Range(d.getIndex(4) + sodong.ToString(), d.getIndex(cot - 1) + sodong.ToString()).Font.Bold = true;
                    orange = osheet.get_Range(d.getIndex(4) + sodong.ToString(), d.getIndex(cot - 1) + sodong.ToString());
                    orange.Font.ColorIndex = 5;
                }
                oxl.ActiveWindow.DisplayZeros = false;
                //osheet.Cells[1, 2] = makp.Text;
                osheet.Cells[1, 2] = d.Tenbv;
                osheet.Cells[2, 2] = ((manguon.SelectedIndex != -1) ? manguon.Text.Trim() + "," : "") + ((madoituong.SelectedIndex != -1) ? madoituong.Text.Trim() + "," : "") + ((tu.Text == den.Text) ? "Ngày " + tu.Text : "Ngày " + tu.Text + " - " + den.Text);
                osheet.Cells[2, 6] = ((s_tenphieu == "") ? "" : s_tenphieu + " :  ") + ((s_buoi == "") ? "Cả ngày" : s_buoi);

                osheet.Cells[1, 4] = "TỔNG HỢP Y LỆNH";
                orange = osheet.get_Range(d.getIndex(2) + "1", d.getIndex(cot - 1) + "1");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size = 12;
                orange.Font.Bold = true;
                osheet.Cells[dong + 4, 26] = "In ngày "+System.DateTime.Today.Day.ToString()+" tháng "+System.DateTime.Today.Month.ToString()+" năm "+System.DateTime.Today.Year.ToString();
                osheet.Cells[dong + 5, 2] = "Khoa Dược";
                osheet.Cells[dong + 5, 7] = "Bác Sĩ";
                osheet.Cells[dong + 5, 15] = "Điều dưỡng thực hiện";
                osheet.Cells[dong + 5, 26] = "Người sao y lệnh";
                osheet.Cells[dong + 8, 2] = "Họ tên...................";
                osheet.Cells[dong + 8, 7] = "Họ tên...................";
                osheet.Cells[dong + 8, 15] = "Họ tên...................";
                osheet.Cells[dong + 8, 26] = "Họ tên...................";
                try
                {
                    osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                    osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                    osheet.PageSetup.LeftMargin = 20;
                    osheet.PageSetup.RightMargin = 20;
                    osheet.PageSetup.TopMargin = 30;
                    osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                }
                catch { }
                if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                else oxl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
		private void exp_excel(bool print)
		{
			try
			{
                ds.Tables[0].Columns.Remove("doituong");
				d.check_process_Excel();
                int be = 3, cot = ds.Tables[0].Columns.Count, dong = ds.Tables[0].Rows.Count + be + 2, sss = dong - 1, sodong = dong + 1;
				tenfile=d.Export_Excel(ds,"ylenh");
				oxl=new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
                for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
				for(int i=0;i<6;i++) osheet.Cells[be+1,i+1]=get_ten(i); //Khuong 05/11/2011
				DataRow [] dr=dsmabd.Tables[0].Select("true","tenbd");
				for(int i=0;i<dr.Length;i++)
				{
                    osheet.Cells[be + 1, i + 7] = dr[i]["tenbd"].ToString(); //Khuong 05/11/2011
                    osheet.Cells[dong, i + 7] = dr[i]["soluong"].ToString(); //Khuong 05/11/2011
				}
                if (chkTutruc.Checked)
                {

                    osheet.Cells[dong + 1, 3] = "TỔNG TỒN CUỐI";
                    for (int i = 5; i < dsmabd.Tables[0].Rows.Count + 6; i++) //Khuong 05/11/2011
                    {
                        osheet.Cells[dong + 1, i] = "=" + d.getIndex(i - 1) + "5" + "-" + d.getIndex(i-1) + dong.ToString() + "";
                    }
                }
                orange = osheet.get_Range(d.getIndex(be) + "4", d.getIndex(cot - 1) + "4");
				orange.VerticalAlignment=XlVAlign.xlVAlignBottom;
				orange.Orientation=90;
				orange.RowHeight = 200;
				orange.EntireRow.AutoFit();
                orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(cot - 1) + dong.ToString());
				orange.Font.Name="Arial";
				orange.Font.Size=10;
				orange.Font.Bold=false;
                osheet.get_Range(d.getIndex(0) + "5", d.getIndex(cot - 1) + sodong.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
				//orange.EntireRow.AutoFit();
				orange.EntireColumn.AutoFit();
                osheet.get_Range(d.getIndex(4) + dong.ToString(), d.getIndex(cot - 1) + dong.ToString()).Font.Bold = true;
                if (chkTutruc.Checked)
                {
                    osheet.get_Range(d.getIndex(4) + sodong.ToString(), d.getIndex(cot - 1) + sodong.ToString()).Font.Bold = true;
                    orange = osheet.get_Range(d.getIndex(4) + sodong.ToString(), d.getIndex(cot - 1) + sodong.ToString());
                    orange.Font.ColorIndex = 5;
                }
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.Cells[1,2]=makp.Text;
                osheet.Cells[2, 2] = ((manguon.SelectedIndex != -1) ? manguon.Text.Trim() + "," : "") + ((madoituong.SelectedIndex != -1) ? madoituong.Text.Trim() + "," : "") + ((tu.Text == den.Text) ? "Ngày " + tu.Text : "Ngày " + tu.Text + " - " + den.Text);
                osheet.Cells[2, 6] = ((s_tenphieu == "") ? "" : s_tenphieu + " :  ") + ((s_buoi == "") ? "Cả ngày" : s_buoi);

				osheet.Cells[1,3]="TỔNG HỢP Y LỆNH";
                orange = osheet.get_Range(d.getIndex(2) + "1", d.getIndex(cot - 1) + "1");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size=12;
				orange.Font.Bold=true;
                try
                {
                    osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                    osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                    osheet.PageSetup.LeftMargin = 20;
                    osheet.PageSetup.RightMargin = 20;
                    osheet.PageSetup.TopMargin = 30;
                    osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                }
                catch{}
				if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
				else oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void frmYlenh_FormClosing(object sender, FormClosingEventArgs e)
        {
            f_Save_Local();
        }

        private void makp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == makp) load_makho();
        }
	}
}
