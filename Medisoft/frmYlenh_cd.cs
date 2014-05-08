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
	public class frmYlenh_cd : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		string s_buoi="",s_tenphieu="";
		//
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
		private string s_makp,sql,s_makho,s_loai,cont,s_phieu,sql1,tenfile,s_nhomkho,stime,user;
        private bool bIntheoSLDuyet = false;
        private string s_field_soluong = "slyeucau";
		private DataRow r;
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtloai=new System.Data.DataTable();
		private System.Data.DataTable dtphieu=new System.Data.DataTable();
		private System.Data.DataTable dtdmbd=new System.Data.DataTable();
		private System.Data.DataTable dtnv=new System.Data.DataTable();
        private DataSet ds;
		private DataSet dsmabd=new DataSet();
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Button butPreview;
		private System.Windows.Forms.CheckBox chkCachdung;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tennv;
		private MaskedTextBox.MaskedTextBox manv;
		private LibList.List listNv;
		private System.Windows.Forms.CheckBox chkHoatchat;
        private ComboBox madoituong;
        private ComboBox manguon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkTutruc;
        private System.Windows.Forms.CheckBox chkslduyet;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmYlenh_cd(LibMedi.AccessData acc,string makp,string _nhomkho)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYlenh_cd));
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
            this.chkCachdung = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tennv = new System.Windows.Forms.TextBox();
            this.manv = new MaskedTextBox.MaskedTextBox();
            this.listNv = new LibList.List();
            this.chkHoatchat = new System.Windows.Forms.CheckBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkTutruc = new System.Windows.Forms.CheckBox();
            this.chkslduyet = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
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
            this.label3.Location = new System.Drawing.Point(5, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
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
            this.makp.Location = new System.Drawing.Point(64, 56);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 7;
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
            this.phieu.Size = new System.Drawing.Size(192, 100);
            this.phieu.TabIndex = 11;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(259, 58);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(216, 196);
            this.makho.TabIndex = 17;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(114, 284);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 19;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(187, 284);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 20;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butPreview
            // 
            this.butPreview.Image = ((System.Drawing.Image)(resources.GetObject("butPreview.Image")));
            this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPreview.Location = new System.Drawing.Point(41, 284);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(70, 25);
            this.butPreview.TabIndex = 18;
            this.butPreview.Text = "    &Xem";
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // chkCachdung
            // 
            this.chkCachdung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCachdung.Location = new System.Drawing.Point(262, 252);
            this.chkCachdung.Name = "chkCachdung";
            this.chkCachdung.Size = new System.Drawing.Size(98, 24);
            this.chkCachdung.TabIndex = 21;
            this.chkCachdung.Text = "In cách dùng";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "ĐDV :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tennv
            // 
            this.tennv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennv.Location = new System.Drawing.Point(102, 253);
            this.tennv.Name = "tennv";
            this.tennv.Size = new System.Drawing.Size(154, 21);
            this.tennv.TabIndex = 14;
            this.tennv.TextChanged += new System.EventHandler(this.tennv_TextChanged);
            this.tennv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennv_KeyDown);
            // 
            // manv
            // 
            this.manv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.manv.Location = new System.Drawing.Point(64, 253);
            this.manv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(36, 21);
            this.manv.TabIndex = 13;
            this.manv.Validated += new System.EventHandler(this.manv_Validated);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(400, 320);
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
            // chkHoatchat
            // 
            this.chkHoatchat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHoatchat.Location = new System.Drawing.Point(262, 273);
            this.chkHoatchat.Name = "chkHoatchat";
            this.chkHoatchat.Size = new System.Drawing.Size(98, 24);
            this.chkHoatchat.TabIndex = 22;
            this.chkHoatchat.Text = "In hoạt chất";
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(312, 33);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(163, 21);
            this.madoituong.TabIndex = 16;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(312, 8);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(163, 21);
            this.manguon.TabIndex = 15;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(254, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Đối tượng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(259, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 24;
            this.label9.Text = "Nguồn :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTutruc
            // 
            this.chkTutruc.AutoSize = true;
            this.chkTutruc.Enabled = false;
            this.chkTutruc.Location = new System.Drawing.Point(262, 297);
            this.chkTutruc.Name = "chkTutruc";
            this.chkTutruc.Size = new System.Drawing.Size(145, 17);
            this.chkTutruc.TabIndex = 26;
            this.chkTutruc.Text = "Kèm theo tồn cuối tủ trực";
            // 
            // chkslduyet
            // 
            this.chkslduyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkslduyet.Location = new System.Drawing.Point(354, 254);
            this.chkslduyet.Name = "chkslduyet";
            this.chkslduyet.Size = new System.Drawing.Size(121, 21);
            this.chkslduyet.TabIndex = 27;
            this.chkslduyet.Text = "In theo SL Duyệt";
            // 
            // frmYlenh_cd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(482, 339);
            this.Controls.Add(this.chkslduyet);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.chkTutruc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkHoatchat);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.tennv);
            this.Controls.Add(this.manv);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkCachdung);
            this.Controls.Add(this.butPreview);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
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
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmYlenh_cd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp y lệnh";
            this.Load += new System.EventHandler(this.frmYlenh_cd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmYlenh_cd_Load(object sender, System.EventArgs e)	
        {
            user = m.user; stime = "'" + m.f_ngay + "'";
			dsmabd.ReadXml("..//..//..//xml//d_mabd.xml");
			sql="select * from "+user+".d_duockp";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " where makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
			makp.DataSource=dtmakp;
            makp.DisplayMember = "TEN";
            makp.ValueMember = "ID";
			makp.SelectedIndex=0;

            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";

            madoituong.DataSource = m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.SelectedIndex = -1;

            dtnv = d.get_data("select ma,hoten,nhom from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
            listNv.DataSource = dtnv;
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";

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
			if(makp.SelectedIndex>=0) load_makho();
		}

		private void load_makp()
		{
			if (nhom.SelectedIndex!=-1)
			{
                string s = (s_makp.Trim().Trim(',') == "") ? "" : "'" + s_makp.Replace("'", "").Replace(",", "','");
                sql = "select * from " + user + ".d_duockp where nhom like '%" + nhom.SelectedValue.ToString() + ",%'";                
				if (s!="") sql+=" and makp in ("+s.Substring(0,s.Length-2)+")";
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
			r=d.getrowbyid(dtmakp,"id="+((makp.SelectedIndex>=0)?int.Parse(makp.SelectedValue.ToString()):0));
			if (r!=null) s_makho=r["makho"].ToString();
			if (s_makho=="") 
			{
                foreach (DataRow r1 in d.get_data("select kho from " + user + ".d_dmphieu where nhom=" + int.Parse(nhom.SelectedValue.ToString())).Tables[0].Rows)
					s_makho+=r1["kho"].ToString();
			}
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            dtloai = d.get_data("select * from " + user + ".d_dmphieu where id in (1,2,3) order by stt").Tables[0];
			loai.DataSource=dtloai;
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";

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
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
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
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
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
			s_loai="";
			for(int i=0;i<loai.Items.Count;i++)
				if (loai.GetItemChecked(i)) s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
			if (s_loai!="")
			{
				s_loai=s_loai.Substring(0,s_loai.Length-1);
                dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where loai in (" + s_loai + ")" + " and nhom="+int.Parse(nhom.SelectedValue.ToString())+" order by stt").Tables[0];
			}
            else dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where id=-1").Tables[0];
			phieu.DataSource=dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
            if (s_loai == "2") chkTutruc.Enabled = true;
            else
            {
                chkTutruc.Enabled = false;
                chkTutruc.Checked = false;
            }
		}

		private void taotable()
		{
			dsmabd.Clear();
			ds=new DataSet();
			ds.ReadXml("..//..//..//xml//d_ylenh_cd.xml");            
            dtdmbd = d.get_data("select * from " + user + ".d_dmbd where nhom=" + int.Parse(nhom.SelectedValue.ToString())).Tables[0];
			cont=" and a.makhoa="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
            if (madoituong.SelectedIndex != -1) cont += " and c.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
            if (manguon.SelectedIndex != -1) cont += " and c.manguon=" + int.Parse(manguon.SelectedValue.ToString());
			if (manv.Text!="") cont+=" and f.manv='"+manv.Text+"'";
			s_phieu="";
			//binh
            string s_cachdung = (chkCachdung.Checked == false) ? "to_char(c." + s_field_soluong + ") as slyeucau" : "case when c." + s_field_soluong + "=0 then '' else (c." + s_field_soluong + "||'..'||c.cachdung) end as slyeucau ";//string s_cachdung=(chkCachdung.Checked==false)?"to_char(c.slyeucau) as slyeucau":"case when c.slyeucau=0 then '' else (c.slyeucau||'..'||c.cachdung) end as slyeucau ";
			//
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
			if (s_loai=="")
			{
                sql = "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c, "+user+".d_dmbd d,xxx.d_dausinhton f where a.id=b.idduyet";
				sql+=" and b.id=c.id and b.id=f.iddutru and c.mabd=d.id "+cont;
				sql+=" union all ";
                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c, "+user+".d_dmbd d,xxx.d_dausinhton f where a.id=b.idduyet";
				sql+=" and b.id=c.id and b.id=f.iddutru and c.mabd=d.id "+cont;
				sql+=" union all ";
                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c, "+user+".d_dmbd d,xxx.d_dausinhton f where a.id=b.idduyet";
				sql+=" and b.id=c.id and b.id=f.iddutru and c.mabd=d.id "+cont;
				upd_mabd(sql);

                sql1 = "select b.mabn,trim(e.hoten)||' ('||to_char(to_number(to_char(now(),'yyyy'),'9999')-to_number(e.namsinh,'9999'))||')' as hoten,f.phong,f.giuong,c.mabd," + s_cachdung + " from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c,xxx.d_dausinhton f,"+user+".btdbn e where a.id=b.idduyet";
				sql1+=" and b.id=c.id and b.id=f.iddutru and b.mabn=e.mabn "+cont;
				sql1+=" union all ";
                sql1 += "select b.mabn,trim(e.hoten)||' ('||to_char(to_number(to_char(now(),'yyyy'),'9999')-to_number(e.namsinh,'9999'))||')' as hoten,f.phong,f.giuong,c.mabd," + s_cachdung + " from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c,xxx.d_dausinhton f," + user + ".btdbn e where a.id=b.idduyet";
				sql1+=" and b.id=c.id and b.id=f.iddutru and b.mabn=e.mabn "+cont;
				sql1+=" union all ";
                sql1 += "select b.mabn,trim(e.hoten)||' ('||to_char(to_number(to_char(now(),'yyyy'),'9999')-to_number(e.namsinh,'9999'))||')' as hoten,f.phong,f.giuong,c.mabd,to_char(-" + s_field_soluong + ") slyeucau from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c,xxx.d_dausinhton f," + user + ".btdbn e where a.id=b.idduyet";
				sql1+=" and b.id=c.id and b.id=f.iddutru and b.mabn=e.mabn "+cont;
				upd_soluong(sql1);
			}
			else
			{
				sql="";sql1="";
				for(int i=1;i<4;i++)
				{
					if (s_loai.IndexOf(i.ToString())!=-1)
					{
						if (sql!="") sql+=" union all ";
						if (sql1!="") sql1+=" union all ";
						switch (i)
						{
							case 1://linh
                                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c, " + user + ".d_dmbd d,xxx.d_dausinhton f where a.id=b.idduyet";
								sql+=" and b.id=c.id and b.id=f.iddutru and c.mabd=d.id "+cont;
                                sql1 += "select b.mabn,e.hoten,f.phong,f.giuong,c.mabd," + s_cachdung + " from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c,xxx.d_dausinhton f,"+user+".btdbn e where a.id=b.idduyet";
								sql1+=" and b.id=c.id and b.id=f.iddutru and b.mabn=e.mabn "+cont;
								break;
							case 2://bu truc
                                if (chkTutruc.Checked)
                                {
                                    sql = "select distinct a.mabd, b.manhom, b.stt from xxx.d_tutrucct a inner join medibv.d_dmbd b on a.mabd=b.id where makp=" + makp.SelectedValue.ToString();
                                    upd_mabd(sql);
                                    upd_soluong("select '' as mabn,'TỒN ĐẦU TỦ TRỰC' as hoten,'' as phong,'' as giuong,mabd,sum(tondau+slnhap-slxuat) as slyeucau,' ' as sovaovien from xxx.d_tutrucct where makp=" + makp.SelectedValue.ToString() + " group by mabd");
                                }
                                else
                                {
                                    sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c, " + user + ".d_dmbd d,xxx.d_dausinhton f where a.id=b.idduyet";
                                    sql += " and b.id=c.id and b.id=f.iddutru and c.mabd=d.id " + cont;
                                }

                                sql1 += "select b.mabn,e.hoten,f.phong,f.giuong,c.mabd," + s_cachdung + " from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c,xxx.d_dausinhton f,"+user+".btdbn e where a.id=b.idduyet";
								sql1+=" and b.id=c.id and b.id=f.iddutru and b.mabn=e.mabn "+cont;

								break;
							default://hoan tra																
                                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c, " + user + ".d_dmbd d,xxx.d_dausinhton f where a.id=b.idduyet";
								sql+=" and b.id=c.id and b.id=f.iddutru and c.mabd=d.id "+cont;
                                sql1 += "select b.mabn,e.hoten,f.phong,f.giuong,c.mabd,to_char(" + s_field_soluong + ") slyeucau from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c,xxx.d_dausinhton f," + user + ".btdbn e where a.id=b.idduyet";
								sql1+=" and b.id=c.id and b.id=f.iddutru and b.mabn=e.mabn "+cont;
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
			int i_stt=0;
			string s_tenbd;
			foreach(DataRow r1 in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Select("","manhom,stt"))//.Rows
			{
				r=d.getrowbyid(dsmabd.Tables[0],"mabd="+int.Parse(r1["mabd"].ToString()));
				if (r==null)
				{
					r2=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
					if (r2!=null)
					{
						r3=dsmabd.Tables[0].NewRow();
						i_stt+=1;
						r3["mabd"]=r1["mabd"].ToString();
						if (chkHoatchat.Checked) 
						{
							s_tenbd=r2["tenhc"].ToString();
							if(s_tenbd!=r2["ten"].ToString())s_tenbd+=" ("+r2["ten"].ToString()+")";
							r3["tenbd"]=s_tenbd+" "+r2["hamluong"].ToString().Trim()+";"+r2["dang"].ToString();
						}
						else r3["tenbd"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString().Trim()+";"+r2["dang"].ToString();
						r3["soluong"]=0;						
						r3["stt"]=i_stt;
						dsmabd.Tables[0].Rows.Add(r3);
					}
				}
			}
			DataRow [] dr=dsmabd.Tables[0].Select("true","stt");//"tenbd");
			for(int i=0;i<dr.Length;i++)
			{
				dc=new DataColumn();
				dc.ColumnName="C_"+dr[i]["mabd"].ToString().Trim();
				dc.DataType=Type.GetType("System.String");//("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
		}

		private void upd_soluong(string sql)
		{
			DataRow r2;
			DataRow [] dr;
			foreach(DataRow r1 in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Select("true","phong,giuong"))
			{
				//get slyeucau
				string s_slyc=r1["slyeucau"].ToString(), s_cachdung="";
				decimal i_slyc=0,tmp_slyc=0;
				int i_index=s_slyc.IndexOf("..");
				if(s_slyc!="")
				{
					if(i_index>=0)
					{
						i_slyc=decimal.Parse(s_slyc.Substring(0,i_index));
						s_cachdung=s_slyc.Substring(i_index+1);
					}
					else
					{
						i_slyc=decimal.Parse(s_slyc);
						s_cachdung="";//binh
					}
				}
				else
				{
					i_slyc=0;
					s_cachdung="";//binh
				}
				tmp_slyc=i_slyc;
				//
				r=d.getrowbyid(ds.Tables[0],"mabn='`"+r1["mabn"].ToString()+"'");
				if (r==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["stt"]=d.get_stt(ds.Tables[0]).ToString();
					r2["mabn"]="`"+r1["mabn"].ToString();
					r2["hoten"]=r1["hoten"].ToString();
					r2["phong"]=r1["phong"].ToString();
					r2["giuong"]=r1["giuong"].ToString();
					foreach(DataRow r3 in dsmabd.Tables[0].Rows) r2["C_"+r3["mabd"].ToString().Trim()]=0;
					r2["C_"+r1["mabd"].ToString().Trim()]=r1["slyeucau"].ToString().Replace("..",";");
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr=ds.Tables[0].Select("mabn='`"+r1["mabn"].ToString()+"'");
					i_index=dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString().IndexOf(";",0);
					if(i_index>=0)
						i_slyc+=decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString().Substring(0,i_index));
					else
						i_slyc+=decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString());
					//
                    if (dr != null) dr[0]["C_" + r1["mabd"].ToString().Trim()] = i_slyc + ";" + s_cachdung;// decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString())+i_slyc;//+decimal.Parse(r1["slyeucau"].ToString());
				}
                if (r1["mabn"].ToString() != "")
                {
                    dr = dsmabd.Tables[0].Select("mabd=" + int.Parse(r1["mabd"].ToString()));
                    if (dr != null) dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + tmp_slyc;//+decimal.Parse(r1["slyeucau"].ToString());
                }
			}
		}
		private void butIn_Click(object sender, System.EventArgs e)
		{
            bIntheoSLDuyet = chkslduyet.Checked;
            s_field_soluong = (bIntheoSLDuyet) ? "slthuc" : "slyeucau";
            d.check_process_Excel();
			Get_buoi();
			//
			taotable();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
			exp_excel(true);
		}

		private void butPreview_Click(object sender, System.EventArgs e)
		{
            bIntheoSLDuyet = chkslduyet.Checked;
            s_field_soluong = (bIntheoSLDuyet) ? "slthuc" : "slyeucau";
			d.check_process_Excel();
			Get_buoi();
			taotable();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
			exp_excel(false);
		}

		private string get_ten(int i)
		{
			string []map={"STT","PHÒNG","GIƯỜNG","MÃ BN","HỌ TÊN"};
			return map[i];
		}

		private void exp_excel(bool print)
		{
			try
			{
                int be = 3, cot = ds.Tables[0].Columns.Count, dong = ds.Tables[0].Rows.Count + be + 2, sss = dong - 1, sodong = dong + 1;
				tenfile=d.Export_Excel(ds,"ylenh");
				oxl=new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
                for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
				for(int i=0;i<5;i++) osheet.Cells[be+1,i+1]=get_ten(i);
				DataRow [] dr=dsmabd.Tables[0].Select("true","stt");//"tenbd");
				for(int i=0;i<dr.Length;i++)
				{
					osheet.Cells[be+1,i+6]=dr[i]["tenbd"].ToString();
					osheet.Cells[dong,i+6]=dr[i]["soluong"].ToString();
				}
                if (chkTutruc.Checked)
                {

                    osheet.Cells[dong + 1, 5] = "TỒN CUỐI TỦ TRỰC";
                    for (int i = 5; i < dsmabd.Tables[0].Rows.Count + 6; i++)
                    {
                        osheet.Cells[dong + 1, i] = "=" + d.getIndex(i - 1) + "5" + "-" + d.getIndex(i - 1) + dong.ToString() + "";
                    }
                }
				//Phong giuong
				orange=osheet.get_Range(d.getIndex(1)+"4",d.getIndex(2)+"4");
				orange.VerticalAlignment=XlVAlign.xlVAlignBottom;
				orange.Orientation=90;
				orange.RowHeight = 180;
				//Ten Thuoc
				orange=osheet.get_Range(d.getIndex(be+2)+"4",d.getIndex(cot-1)+"4");
				orange.VerticalAlignment=XlVAlign.xlVAlignBottom;
				orange.WrapText=false;
				orange.Orientation=90;
				orange.RowHeight = 180;
				orange.Font.Bold=true;
				orange.EntireRow.AutoFit();				
				//Hien thi chi tiet
				orange=osheet.get_Range(d.getIndex(0)+"5",d.getIndex(cot-1)+dong.ToString());
				orange.Font.Name="Arial";
				orange.Font.Size=10;
				orange.Font.Bold=false;
				orange.RowHeight = 16;
				orange.NumberFormat="###0.##";
                osheet.get_Range(d.getIndex(0) + "4", d.getIndex(cot) + sodong.ToString()).Borders.LineStyle = XlLineStyle.xlDot;			
				orange.EntireColumn.AutoFit();								
				//
				//cot hoten BN: In dam				
                orange = osheet.get_Range(d.getIndex(4) + "4", d.getIndex(4) + dong.ToString());
				orange.Font.Name="Arial";				
				orange.Font.Bold=true;
				orange.EntireColumn.AutoFit();
				//
                osheet.get_Range(d.getIndex(4) + dong.ToString(), d.getIndex(cot - 1) + dong.ToString()).Font.Bold = true;
                if (chkTutruc.Checked)
                {
                    osheet.get_Range(d.getIndex(4) + sodong.ToString(), d.getIndex(cot - 1) + sodong.ToString()).Font.Bold = true;
                    orange = osheet.get_Range(d.getIndex(4) + sodong.ToString(), d.getIndex(cot - 1) + sodong.ToString());
                    orange.Font.ColorIndex = 3;

                }
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.Cells[1,2]=makp.Text;
                osheet.Cells[2, 2] = ((manguon.SelectedIndex != -1) ? manguon.Text.Trim() + "," : "")+((madoituong.SelectedIndex != -1) ? madoituong.Text.Trim() + "," : "") + ((tu.Text == den.Text) ? "Ngày " + tu.Text : "Ngày " + tu.Text + " - " + den.Text);
				osheet.Cells[2,6]=((s_tenphieu=="")?"":s_tenphieu+" :  ")+ ((s_buoi=="")?"Cả ngày":s_buoi);
				
				osheet.Cells[1,5]="TỔNG HỢP Y LỆNH";				
				orange=osheet.get_Range(d.getIndex((cot>3)?4:cot-1)+"1",d.getIndex(cot-1)+"1");				
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size=12;
				orange.Font.Bold=true;
				//border lai dong cot
				int jcot=(cot<16)?16:cot;			
				//
				for (int ji=0;ji<jcot;ji++)
				{
					orange=osheet.get_Range(m.getIndex(ji)+"4",m.getIndex(ji)+dong);
					orange.Cells.BorderAround(5,Excel.XlBorderWeight.xlHairline,Excel.XlColorIndex.xlColorIndexAutomatic,0);								
					if(ji>=cot)orange.ColumnWidth=3 ;//[b.getIndex(0)+"3",b.getIndex(ji)]
				}
				for (int ji=4;ji<dong;ji++)
				{
					orange=osheet.get_Range(m.getIndex(0)+ji,m.getIndex(jcot)+ji);
					orange.Cells.BorderAround(5,Excel.XlBorderWeight.xlHairline,Excel.XlColorIndex.xlColorIndexAutomatic,0);
				}							
				orange=osheet.get_Range(m.getIndex(0)+"4:"+m.getIndex(0)+dong,m.getIndex(0)+"4:"+m.getIndex(jcot)+dong);
				orange.Cells.BorderAround(1,Excel.XlBorderWeight.xlThin,Excel.XlColorIndex.xlColorIndexAutomatic,2);
				//
				//ke them row trong			
				for (int ji=0;ji<jcot;ji++)
				{
					orange=osheet.get_Range(m.getIndex(ji)+(dong+3),m.getIndex(ji)+(dong+15));
					orange.Cells.BorderAround(5,Excel.XlBorderWeight.xlHairline,Excel.XlColorIndex.xlColorIndexAutomatic,0);								
					if(ji>=cot)orange.ColumnWidth=3 ;//[b.getIndex(0)+"3",b.getIndex(ji)]
				}
				for (int ji=dong+3;ji<dong+15;ji++)
				{
					orange=osheet.get_Range(m.getIndex(0)+ji,m.getIndex(jcot-1)+ji);
					orange.Cells.BorderAround(5,Excel.XlBorderWeight.xlHairline,Excel.XlColorIndex.xlColorIndexAutomatic,0);
				}
				//
				for(int ji=5;ji<=dong+15;ji++)
				{
					orange=osheet.get_Range(m.getIndex(0)+ji,m.getIndex(cot)+ji);
					orange.VerticalAlignment=Excel.XlVAlign.xlVAlignCenter;
					orange.RowHeight=16;	
					orange.WrapText=false;
				}
				//end binh
				//
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
				if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
				else oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void Get_buoi()
		{
			s_buoi="";
			s_tenphieu="";
			int i_incachdung=0;
			for(int i=0;i<phieu.Items.Count;i++)
			{
				if (phieu.GetItemChecked(i)) 
				{
					i_incachdung+=1;
					s_buoi+=dtphieu.Rows[i]["ten"].ToString()+", ";
				}
			}
			for(int i=0;i<loai.Items.Count;i++)
				if (loai.GetItemChecked(i)) s_tenphieu+=dtloai.Rows[i]["ten"].ToString()+", ";
			//if(i_incachdung!=1)chkCachdung.Checked=false;
		}

		private void manv_Validated(object sender, System.EventArgs e)
		{
			if (manv.Text=="") return;
			r=d.getrowbyid(dtnv,"nhom="+LibMedi.AccessData.nhanvien+" and ma='"+manv.Text+"'");
			if (r!=null) tennv.Text=r["hoten"].ToString();
			else tennv.Text="";
		}

		private void tennv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tennv)
			{
				Filt_dmbs(tennv.Text,"nhom="+LibMedi.AccessData.nhanvien);
				listNv.BrowseToDanhmuc(tennv,manv,butPreview,35);
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

