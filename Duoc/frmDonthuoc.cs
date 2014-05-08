using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibVienphi;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmThutien.
	/// </summary>
	public class frmDonthuoc : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox madoituong;
		private System.Windows.Forms.CheckBox chksang_chieu;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private DataTable dt=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataSet ds1=new DataSet();
		private DataSet ds2=new DataSet();
		private DataSet ds=new DataSet();
		private DataTable dtloai=new DataTable();
		private DataTable dtphieu=new DataTable();
		private DataTable dtma=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataSet dsphong=new DataSet();
		private DataSet dsmabn=new DataSet();
		private DataTable dtcachdung=new DataTable();
		private DataSet dsxml;
        private int i_dongia, i_nhom, d_userid=0;
		private string s_makp="",sql,s_loai,s_phieu,title,s_madoituong,s_tenphieu,s_tenloai,s_mabn,user,stime;
		private System.Windows.Forms.CheckedListBox makp;
		private Print print=new Print();
		private System.Windows.Forms.CheckedListBox phieu;
		private System.Windows.Forms.CheckedListBox loai;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkvienphi;
		private System.Windows.Forms.Button butDanhsach;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged;
		int checkCol=0;
		private System.Windows.Forms.CheckBox chkCachdung;
        private CheckBox chkXML;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDonthuoc(LibDuoc.AccessData acc,int nhom, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            d = acc; i_nhom = nhom;
            d_userid = _userid;
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
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
					}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonthuoc));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.CheckedListBox();
            this.chksang_chieu = new System.Windows.Forms.CheckBox();
            this.butXem = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.phieu = new System.Windows.Forms.CheckedListBox();
            this.loai = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkvienphi = new System.Windows.Forms.CheckBox();
            this.butDanhsach = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.chkCachdung = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(143, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(63, 8);
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
            this.den.Location = new System.Drawing.Point(175, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.CheckOnClick = true;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(258, 8);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(160, 132);
            this.madoituong.TabIndex = 3;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chksang_chieu
            // 
            this.chksang_chieu.Location = new System.Drawing.Point(64, 284);
            this.chksang_chieu.Name = "chksang_chieu";
            this.chksang_chieu.Size = new System.Drawing.Size(192, 22);
            this.chksang_chieu.TabIndex = 9;
            this.chksang_chieu.Text = "Chiều hôm qua,sáng hôm nay";
            this.chksang_chieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butXem
            // 
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(74, 315);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 6;
            this.butXem.Text = "     &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(144, 315);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(297, 315);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 32);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 180);
            this.makp.TabIndex = 2;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // phieu
            // 
            this.phieu.CheckOnClick = true;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(258, 144);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(160, 100);
            this.phieu.TabIndex = 5;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // loai
            // 
            this.loai.CheckOnClick = true;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(64, 214);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(192, 68);
            this.loai.TabIndex = 4;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Loại :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkvienphi
            // 
            this.chkvienphi.Checked = true;
            this.chkvienphi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkvienphi.Location = new System.Drawing.Point(263, 266);
            this.chkvienphi.Name = "chkvienphi";
            this.chkvienphi.Size = new System.Drawing.Size(160, 22);
            this.chkvienphi.TabIndex = 10;
            this.chkvienphi.Text = "In viện phí vào đơn thuốc";
            // 
            // butDanhsach
            // 
            this.butDanhsach.Image = ((System.Drawing.Image)(resources.GetObject("butDanhsach.Image")));
            this.butDanhsach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDanhsach.Location = new System.Drawing.Point(214, 315);
            this.butDanhsach.Name = "butDanhsach";
            this.butDanhsach.Size = new System.Drawing.Size(83, 25);
            this.butDanhsach.TabIndex = 12;
            this.butDanhsach.Text = "     &Danh sách";
            this.butDanhsach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDanhsach.Click += new System.EventHandler(this.butDanhsach_Click);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(420, 8);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(260, 21);
            this.tim.TabIndex = 13;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(422, 13);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(258, 334);
            this.dataGrid1.TabIndex = 24;
            // 
            // chkCachdung
            // 
            this.chkCachdung.Checked = true;
            this.chkCachdung.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCachdung.Location = new System.Drawing.Point(263, 248);
            this.chkCachdung.Name = "chkCachdung";
            this.chkCachdung.Size = new System.Drawing.Size(160, 22);
            this.chkCachdung.TabIndex = 25;
            this.chkCachdung.Text = "Kèm cách dùng";
            this.chkCachdung.Click += new System.EventHandler(this.chkCachdung_Click);
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(263, 284);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(160, 22);
            this.chkXML.TabIndex = 26;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // frmDonthuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 357);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.chkCachdung);
            this.Controls.Add(this.butDanhsach);
            this.Controls.Add(this.chkvienphi);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.chksang_chieu);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDonthuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc";
            this.Load += new System.EventHandler(this.frmDonthuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmDonthuoc_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + m.f_ngay + "'";
			i_dongia=d.d_dongia_le(i_nhom);
			chkCachdung.Checked=m.bDonthuoc_cachdung;
			ds1.ReadXml("..\\..\\..\\xml\\d_donthuoc1.xml");
			ds2.ReadXml("..\\..\\..\\xml\\d_donthuoc2.xml");
            ds1.Tables[0].Columns.Add("songay", typeof(decimal));
            ds2.Tables[0].Columns.Add("songay", typeof(decimal));
			ds.ReadXml("..\\..\\..\\xml\\d_donthuoc.xml");
            ds.Tables[0].Columns.Add("songay", typeof(decimal));
			dsmabn.ReadXml("..\\..\\..\\xml\\d_mabn.xml");
			dsphong.ReadXml("..\\..\\..\\xml\\d_mabn.xml");
            dsphong.Tables[0].Columns.Add("songay", typeof(decimal));
            chkCachdung.Checked = d.Thongso("donthuoc_kemcd") == "1";            

			sql="select * from "+user+".btdkp_bv ";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " where makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+="order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
            makp.DataSource = dtkp;
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			
            sql = "select * from " + user + ".doituong order by madoituong";
			dt=m.get_data(sql).Tables[0];
			madoituong.DataSource=dt;
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";

			chksang_chieu.Enabled=m.bChieu_sang;
			if (chksang_chieu.Enabled) chksang_chieu.Checked=true;

			sql="select id,trim(ten)||' '||hamluong as ten,dang as dvt from "+user+".d_dmbd where nhom="+i_nhom;
			sql+=" union select id,ten,dvt from "+user+".v_giavp ";
			dtma=m.get_data(sql).Tables[0];
			dtbs=m.get_data("select * from "+user+".dmbs").Tables[0];

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";
			dtloai=d.get_data("select * from "+user+".d_dmphieu where id in (1,2,3) order by stt").Tables[0];
			loai.DataSource=dtloai;
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";

			dsmabn.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=dsmabn.Tables[0];
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void get_data()
		{
			Cursor=Cursors.WaitCursor;
			DataTable t1=new DataTable("toa1");
			DataTable t2=new DataTable("toa2");
			t1=ds1.Tables[0].Clone();
			t2=ds2.Tables[0].Clone();
			ds.Clear();dsphong.Clear();
			title=(tu.Text==den.Text)?"Ngày "+tu.Text:"Ngày "+tu.Text+"-"+den.Text;
			s_mabn="";
			foreach(DataRow r in dsmabn.Tables[0].Select("chon=true","mabn")) s_mabn+="'"+r["mabn"].ToString().Trim()+"',";
			s_madoituong="";
			if (madoituong.SelectedItems.Count>0)
				for(int i=0;i<madoituong.Items.Count;i++)
					if (madoituong.GetItemChecked(i)) s_madoituong+=dt.Rows[i]["madoituong"].ToString().Trim()+",";
			s_makp="'";
            if (makp.CheckedItems.Count == 0) for (int i = 0; i < makp.Items.Count; i++) makp.SetItemCheckState(i, CheckState.Checked);
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+"','";
            s_makp = (s_makp.Length > 1) ? s_makp.Substring(0, s_makp.Length - 1) : "";
			s_loai="";s_tenloai="";
			if (loai.SelectedItems.Count>0)
				for(int i=0;i<loai.Items.Count;i++)
					if (loai.GetItemChecked(i))
					{
						s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
						s_tenloai+=dtloai.Rows[i]["ten"].ToString().Trim()+",";
					}
			s_phieu="";s_tenphieu="";
			if (phieu.SelectedItems.Count>0)
				for(int i=0;i<phieu.Items.Count;i++)
					if (phieu.GetItemChecked(i))
					{
						s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";
						s_tenphieu+=dtphieu.Rows[i]["ten"].ToString().Trim()+",";
					}
			DateTime d1=d.StringToDate(tu.Text).AddDays(-1);
			DateTime d2=d.StringToDate(den.Text);
			DateTime d3=d.StringToDate(tu.Text);
			DateTime d4=d.StringToDate(den.Text).AddDays(-1);
            DateTime dt1 = d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
            DateTime dt2 = d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			//
            sql = "select distinct b.mabn,c.mabs,c.phong,c.giuong,b.songay, to_char(a.ngay,'dd/mm/yyyy') ngay, b.id from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dausinhton c," + user + ".d_duockp d";
			sql+=" where a.id=b.idduyet and b.id=c.id and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
            sql+= " and a.ngay between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
			sql+=" and (c.phong is not null or c.giuong is not null or c.mabs is not null)";
			sql+=" union all ";
            sql += "select distinct b.mabn,c.mabs,c.phong,c.giuong,b.songay, to_char(a.ngay,'dd/mm/yyyy') ngay, b.id from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_dausinhton c," + user + ".d_duockp d";
			sql+=" where a.id=b.idduyet and b.id=c.id and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
            sql+= " and a.ngay between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
			sql+=" and (c.phong is not null or c.giuong is not null or c.mabs is not null)";
			sql+=" union all ";
            sql += "select distinct b.mabn,c.mabs,c.phong,c.giuong,0 as songay, to_char(a.ngay,'dd/mm/yyyy') ngay, b.id from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_dausinhton c," + user + ".d_duockp d";
			sql+=" where a.id=b.idduyet and b.id=c.id and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
			sql+=" and a.ngay between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"',"+stime+") and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"',"+stime+")";
			sql+=" and (c.phong is not null or c.giuong is not null or c.mabs is not null)";
			dsphong.Merge(d.get_thuoc(m.DateToString("dd/MM/yyyy",dt1),m.DateToString("dd/MM/yyyy",dt2),sql));
			//
			if (chkCachdung.Checked)
			{
				sql="select distinct b.mabn,c.mabd,c.madoituong,c.cachdung,b.id ";
                sql += " from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c ";
				sql+=" where a.id=b.idduyet and b.id=c.id and c.cachdung is not null";
				if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
                sql += " and a.ngay between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
				sql+=" union all ";
				sql+="select distinct b.mabn,c.mabd,c.madoituong,c.cachdung,b.id ";
                sql += " from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c ";
				sql+=" where a.id=b.idduyet and b.id=c.id and c.cachdung is not null";
				if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
                sql += " and a.ngay between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
				//dtcachdung=d.get_thuoc(m.DateToString("dd/MM/yyyy",dt1),m.DateToString("dd/MM/yyyy",dt2),sql).Tables[0];
                dtcachdung = d.get_thuoc(tu.Text,den.Text,sql).Tables[0];
			}
			//
			if (s_loai!="3,")
			{
				if (s_loai=="" || s_loai.IndexOf("1,")!=-1)
				{
					sql="select '0' as nhom,0 as loai,d.makp,a.mabn,a.hoten,c.madoituong,c.mabd as ma,case when f.loai=0 then z.giamua else z.giaban end as dongia,sum(c.soluong) as soluong, g.id";
					sql+=" from "+user+".btdbn a,xxx.d_xuatsdll b,xxx.d_xuatsdct c,xxx.d_theodoi z,"+user+".d_duockp d,"+user+".d_loaiphieu e,"+user+".d_doituong f,xxx.d_dutrull g,xxx.d_duyet t";
					sql+=" where a.mabn=b.mabn and b.id=c.id and c.sttt=z.id and b.idduyet=g.id and g.idduyet=t.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong";
					if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
					if (s_madoituong!="") sql+=" and c.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
					if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
					if (s_loai!="" && s_loai.IndexOf("3,")==-1) sql+=" and b.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
					else sql+=" and b.loai<>3";
					if (s_phieu!="") sql+=" and b.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
                    /*
					if (chksang_chieu.Checked)
					{
						sql+=" and ((e.buoi=1 and to_char(t.ngay,'dd/mm/yyyy')='"+m.DateToString("dd/MM/yyyy",d1)+"'";
						sql+=" or (e.buoi=0 and to_char(t.ngay,'dd/mm/yyyy')='"+m.DateToString("dd/MM/yyyy",d2)+"'";
						if (tu.Text!=den.Text) sql+=" or (t.ngay between to_date('"+m.DateToString("dd/MM/yyyy",d3)+"',"+stime+") and to_date('"+m.DateToString("dd/MM/yyyy",d4)+"',"+stime+"))";
						sql+=")";
					}
					else 
                    */
                    sql+=" and t.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
                    sql += " group by d.makp,a.mabn,a.hoten,c.madoituong,c.mabd,case when f.loai=0 then z.giamua else z.giaban end, g.id";
					ds.Merge(d.get_thuoc(tu.Text,den.Text,sql));
				}
				if (s_loai=="" || s_loai.IndexOf("2,")!=-1)
				{
                    sql = "select '0' as nhom,0 as loai,d.makp,a.mabn,a.hoten,c.madoituong,c.mabd as ma,case when f.loai=0 then z.giamua else z.giaban end as dongia,sum(c.soluong) as soluong, g.id";
					sql+=" from "+user+".btdbn a,xxx.d_xuatsdll b,xxx.d_xuatsdct c,"+user+".d_duockp d,"+user+".d_loaiphieu e,"+user+".d_doituong f,xxx.d_xtutrucll g,xxx.d_duyet t,xxx.d_theodoi z";
					sql+=" where a.mabn=b.mabn and b.id=c.id and c.sttt=z.id and b.idduyet=g.id and g.idduyet=t.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong";
					if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
					if (s_madoituong!="") sql+=" and c.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
					if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
					if (s_loai!="" && s_loai.IndexOf("3,")==-1) sql+=" and b.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
					else sql+=" and b.loai<>3";
					if (s_phieu!="") sql+=" and b.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
                    /*
					if (chksang_chieu.Checked)
					{
                        sql += " and ((e.buoi=1 and to_char(t.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", d1) + "'";
                        sql += " or (e.buoi=0 and to_char(t.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", d2) + "'";
                        if (tu.Text != den.Text) sql += " or (t.ngay between to_date('" + m.DateToString("dd/MM/yyyy", d3) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", d4) + "'," + stime + "))";
                        sql += ")";
					}
                    else 
                     */
                    sql += " and t.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                    sql += " group by b.loai,d.makp,a.mabn,a.hoten,c.madoituong,c.mabd,case when f.loai=0 then z.giamua else z.giaban end, g.id";
                    ds.Merge(d.get_thuoc(tu.Text, den.Text, sql));
				}
			}
			if (s_loai=="" || s_loai.IndexOf("3,")!=-1)
			{
                sql = "select '0' as nhom,0 as loai,d.makp,a.mabn,a.hoten,c.madoituong,c.mabd as ma,case when f.loai=0 then z.giamua else z.giaban end as dongia,-sum(c.soluong) as soluong, g.id";
				sql+=" from "+user+".btdbn a,xxx.d_xuatsdll b,xxx.d_xuatsdct c,xxx.d_theodoi z,"+user+".d_duockp d,"+user+".d_loaiphieu e,"+user+".d_doituong f,xxx.d_hoantrall g,xxx.d_duyet t";
				sql+=" where a.mabn=b.mabn and b.id=c.id and c.sttt=z.id and b.idduyet=g.id and g.idduyet=t.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong";
				if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
				if (s_madoituong!="") sql+=" and c.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
				if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
				sql+=" and b.loai=3";
				if (s_phieu!="") sql+=" and b.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
                /*
				if (chksang_chieu.Checked)
				{
                    sql += " and ((e.buoi=1 and to_char(t.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", d1) + "'";
                    sql += " or (e.buoi=0 and to_char(t.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", d2) + "'";
                    if (tu.Text != den.Text) sql += " or (t.ngay between to_date('" + m.DateToString("dd/MM/yyyy", d3) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", d4) + "'," + stime + "))";
                    sql += ")";
				}
                else
                 */ 
                sql += " and t.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " group by d.makp,a.mabn,a.hoten,c.madoituong,c.mabd,case when f.loai=0 then z.giamua else z.giaban end, g.id";
                ds.Merge(d.get_thuoc(tu.Text, den.Text, sql));
			}

			if (chkvienphi.Checked)
			{
				sql="select '1' as nhom,0 as loai,b.makp,a.mabn,a.hoten,b.madoituong,b.mavp as ma,(b.dongia+b.vattu) as dongia,sum(b.soluong) as soluong, b.maql as id";
				sql+=" from "+user+".btdbn a,xxx.v_vpkhoa b,"+user+".v_giavp c";
				sql+=" where a.mabn=b.mabn and b.mavp=c.id";
				if (s_makp!="") sql+=" and b.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
				if (s_madoituong!="") sql+=" and b.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
				if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
                /*
				if (chksang_chieu.Checked)
				{
                    sql += " and ((b.buoi=1 and to_char(b.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", d1) + "'";
                    sql += " or (b.buoi=0 and to_char(b.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", d2) + "'";
                    if (tu.Text != den.Text) sql += " or (b.ngay between to_date('" + m.DateToString("dd/MM/yyyy", d3) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", d4) + "'," + stime + "))";
                    sql += ")";
				}
                else */
                sql += " and b.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
				sql+=" group by b.makp,a.mabn,a.hoten,b.madoituong,b.mavp,(b.dongia+b.vattu), b.maql";
				ds.Merge(d.get_thuoc(tu.Text,den.Text,sql));
                //
                sql = "select '1' as nhom,0 as loai,b.makp,a.mabn,a.hoten,b.madoituong,b.mavp as ma,(b.dongia+b.vattu) as dongia,sum(b.soluong) as soluong, b.maql as id";
                sql += " from " + user + ".btdbn a,xxx.v_chidinh b,"+user+".v_giavp c";
                sql += " where a.mabn=b.mabn and b.mavp=c.id ";
                if (s_makp != "") sql += " and b.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
                if (s_madoituong != "") sql += " and b.madoituong in (" + s_madoituong.Substring(0, s_madoituong.Length - 1) + ")";
                if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
                /*
                if (chksang_chieu.Checked)
                {
                    sql += " and ((b.buoi=1 and to_char(b.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", d1) + "'";
                    sql += " or (b.buoi=0 and to_char(b.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", d2) + "'";
                    if (tu.Text != den.Text) sql += " or (b.ngay between to_date('" + m.DateToString("dd/MM/yyyy", d3) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", d4) + "'," + stime + "))";
                    sql += ")";
                }
                else */
                sql += " and " + m.for_ngay("b.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " group by b.makp,a.mabn,a.hoten,b.madoituong,b.mavp,(b.dongia+b.vattu), b.maql ";
                ds.Merge(d.get_thuoc(tu.Text, den.Text, sql));
			}
			sort(t1,t2);
			dsxml=new DataSet();
			dsxml.Tables.Add(t1);
			dsxml.Tables.Add(t2);
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\d_donthuoc12.xml",XmlWriteMode.WriteSchema);
            }
			Cursor=Cursors.Default;
		}

		private void upd_data(DataTable dta,string makp,string madoituong,string mabn,string hoten,string nhom,int loai,string ma,string dongia,string soluong, decimal iddutru)
		{
			DataRow r1,r2,r3,r4,r5,r6,r7,r8;
			DataRow [] dr;
			string _loai;
			sql="makp='"+makp+"' and madoituong="+int.Parse(madoituong.ToString())+" and mabn='"+mabn+"' and ma="+int.Parse(ma)+" and dongia="+decimal.Parse(dongia);
			r1=m.getrowbyid(dta,sql);
			if (r1==null)
			{
				r3=m.getrowbyid(dt,"madoituong="+int.Parse(madoituong));
				r4=m.getrowbyid(dtkp,"makp='"+makp+"'");
				r5=m.getrowbyid(dtma,"id="+int.Parse(ma));
				if (r3!=null && r4!=null && r5!=null)
				{
					_loai=(loai==2)?"* ":(loai==3)?"- ":"";
					r2=dta.NewRow();
					r2["tenbv"]=m.Tenbv;
					r2["makp"]=makp;
					r2["tenkp"]=r4["tenkp"].ToString();
					r2["madoituong"]=madoituong;
					r2["doituong"]=r3["doituong"].ToString();
					r2["mabn"]=mabn;
					r2["hoten"]=hoten;
					r2["ma"]=ma;
					r2["ten"]=_loai+r5["ten"].ToString();
					r2["dvt"]=r5["dvt"].ToString();
					r2["nhom"]=(nhom=="0")?"Thuốc":"Viện phí";
					//r6=m.getrowbyid(dsphong.Tables[0],"mabn='"+mabn+"'");
                    r6 = m.getrowbyid(dsphong.Tables[0], "mabn='" + mabn + "' and id=" + iddutru.ToString());
					if (r6!=null)
					{
                        r2["songay"] = r6["songay"].ToString();
						r2["phong"]=r6["phong"].ToString();
						r2["giuong"]=r6["giuong"].ToString();
						r7=m.getrowbyid(dtbs,"ma='"+r6["mabs"].ToString()+"'");
						if (r7!=null) r2["bacsy"]=r7["hoten"].ToString();
					}
					if (chkCachdung.Checked) 
					{
						r8=m.getrowbyid(dtcachdung,"mabn='"+mabn+"' and mabd="+int.Parse(ma)+" and madoituong="+int.Parse(madoituong)+" and id="+iddutru);
						if (r8!=null) r2["cachdung"]=r8["cachdung"].ToString();
					}
					else r2["cachdung"]="";
					r2["ngay"]=title;
					r2["loai"]=loai;
					r2["phieu"]=s_tenphieu;
					r2["tenloai"]=s_tenloai;
					r2["soluong"]=soluong;
					r2["dongia"]=dongia;
					dta.Rows.Add(r2);
				}
			}
			else
			{
				dr=dta.Select(sql);
				if (dr.Length>0) dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(soluong);
			}
		}
		private void sort(DataTable t1,DataTable t2)
		{
			int j=0;
			string s="";
			foreach(DataRow r in ds.Tables[0].Select("true","makp,madoituong,mabn,nhom,loai"))
			{
				if (s!=r["makp"].ToString().Trim()+r["madoituong"].ToString().Trim()+r["mabn"].ToString().Trim())
				{
					s=r["makp"].ToString().Trim()+r["madoituong"].ToString().Trim()+r["mabn"].ToString().Trim();
					j++;
				}
				upd_data((j%2==0)?t2:t1,r["makp"].ToString(),r["madoituong"].ToString(),r["mabn"].ToString(),r["hoten"].ToString(),r["nhom"].ToString(),int.Parse(r["loai"].ToString()),r["ma"].ToString(),r["dongia"].ToString(),r["soluong"].ToString(),decimal.Parse(r["id"].ToString()));
			}
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			get_data();
			if (dsxml.Tables[0].Rows.Count>0)
			{
				frmReport f=new frmReport(d,dsxml, d_userid,title,(chkCachdung.Checked)?"rpt_donthuoc_cd.rpt":"rpt_donthuoc.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			get_data();
			if (dsxml.Tables[0].Rows.Count>0) print.Printer(d,dsxml,(chkCachdung.Checked)?"rpt_donthuoc_cd.rpt":"rpt_donthuoc.rpt",title,(chkCachdung.Checked)?2:1);
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			s_loai="";
			for(int i=0;i<loai.Items.Count;i++)
				if (loai.GetItemChecked(i)) s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
			if (s_loai!="")
			{
				s_loai=s_loai.Substring(0,s_loai.Length-1);
				dtphieu=d.get_data("select * from "+user+".d_loaiphieu where nhom="+i_nhom+" and loai in ("+s_loai+")"+" order by loai,stt").Tables[0];
			}
			else dtphieu=d.get_data("select * from "+user+".d_loaiphieu where id=-1").Tables[0];
			phieu.DataSource=dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsmabn.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=5;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "...";
			discontinuedCol.Width = 20;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width =60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 145;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
				{
					//				e.BackBrush = this.disabledBackBrush;
					e.ForeBrush = this.disabledTextBrush;
				}
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
				this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count 
				&& hti.Type == DataGrid.HitTestType.Cell 
				&&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
			afterCurrentCellChanged = false;
		}

		private void butDanhsach_Click(object sender, System.EventArgs e)
		{
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-1);
			DateTime dt2=d.StringToDate(den.Text);
			s_madoituong="";
			if (madoituong.SelectedItems.Count>0)
				for(int i=0;i<madoituong.Items.Count;i++)
					if (madoituong.GetItemChecked(i)) s_madoituong+=dt.Rows[i]["madoituong"].ToString().Trim()+",";
			s_makp="'";
			if (makp.SelectedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++)
					if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+"','";
			s_loai="";s_tenloai="";
            s_makp = (s_makp.Length == 1) ? "" : s_makp.Substring(0, s_makp.Length - 1);
			if (loai.SelectedItems.Count>0)
				for(int i=0;i<loai.Items.Count;i++)
					if (loai.GetItemChecked(i))
					{
						s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
						s_tenloai+=dtloai.Rows[i]["ten"].ToString().Trim()+",";
					}
			s_phieu="";s_tenphieu="";
			if (phieu.SelectedItems.Count>0)
				for(int i=0;i<phieu.Items.Count;i++)
					if (phieu.GetItemChecked(i))
					{
						s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";
						s_tenphieu+=dtphieu.Rows[i]["ten"].ToString().Trim()+",";
					}
			//
			sql="select distinct b.mabn,c.hoten from xxx.d_duyet a,xxx.d_dutrull b,"+user+".btdbn c,"+user+".d_duockp d";
			sql+=" where a.id=b.idduyet and b.mabn=c.mabn and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			sql+=" and a.ngay between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"',"+stime+") and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"',"+stime+")";
			sql+=" union all ";
			sql+="select distinct b.mabn,c.hoten from xxx.d_duyet a,xxx.d_xtutrucll b,"+user+".btdbn c,"+user+".d_duockp d";
			sql+=" where a.id=b.idduyet and b.mabn=c.mabn and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
            sql += " and a.ngay between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
			sql+=" union all ";
			sql+="select distinct b.mabn,c.hoten from xxx.d_duyet a,xxx.d_hoantrall b,"+user+".btdbn c,"+user+".d_duockp d";
			sql+=" where a.id=b.idduyet and b.mabn=c.mabn and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
            sql += " and a.ngay between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
			dsmabn.Clear();
			DataRow r1,r2;
			foreach(DataRow r in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Select("true","mabn"))
			{
				r1=m.getrowbyid(dsmabn.Tables[0],"mabn='"+r["mabn"].ToString()+"'");
				if (r1==null)
				{
					r2=dsmabn.Tables[0].NewRow();
					r2["mabn"]=r["mabn"].ToString();
					r2["hoten"]=r["hoten"].ToString();
					r2["chon"]=false;
					dsmabn.Tables[0].Rows.Add(r2);
				}
			}
			dataGrid1.DataSource=dsmabn.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="hoten like '%"+tim.Text.Trim()+"%' or mabn like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

        private void chkCachdung_Click(object sender, EventArgs e)
        {
            d.writeXml("d_thongso", "donthuoc_kemcd", (chkCachdung.Checked) ? "1" : "0");
        }
	}
}
