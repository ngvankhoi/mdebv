using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibVienphi;
using LibMedi;

namespace Medisoft
{
	public class frmDonthuoc : System.Windows.Forms.Form
    {
        #region Khai bao
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
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private LibMedi.AccessData m;
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
		private int i_dongia,i_nhom;
		private string s_makp,sql,s_loai,s_phieu,title,s_madoituong,s_tenphieu,s_tenloai,s_mabn,user,stime;
		private System.Windows.Forms.CheckedListBox makp;
        private dllReportM.Print print = new dllReportM.Print();
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
		private System.ComponentModel.Container components = null;
        private bool bGia_bh_quydinh = false, bGia_bh_quydinh_giamua = false;
        private CheckBox chkchenhlech;
        #endregion

        public frmDonthuoc(LibMedi.AccessData acc,string _makp)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = _makp; if (m.bBogo) tv.GanBogo(this, textBox111);
		}

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
            this.chkchenhlech = new System.Windows.Forms.CheckBox();
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
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.chksang_chieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chksang_chieu.Location = new System.Drawing.Point(64, 284);
            this.chksang_chieu.Name = "chksang_chieu";
            this.chksang_chieu.Size = new System.Drawing.Size(192, 22);
            this.chksang_chieu.TabIndex = 9;
            this.chksang_chieu.Text = "Chiều hôm qua,sáng hôm nay";
            this.chksang_chieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butXem
            // 
            this.butXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
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
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
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
            this.phieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.loai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(7, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Loại :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkvienphi
            // 
            this.chkvienphi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkvienphi.Checked = true;
            this.chkvienphi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkvienphi.Location = new System.Drawing.Point(263, 268);
            this.chkvienphi.Name = "chkvienphi";
            this.chkvienphi.Size = new System.Drawing.Size(160, 22);
            this.chkvienphi.TabIndex = 10;
            this.chkvienphi.Text = "In viện phí vào đơn thuốc";
            // 
            // butDanhsach
            // 
            this.butDanhsach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.chkCachdung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCachdung.Checked = true;
            this.chkCachdung.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCachdung.Location = new System.Drawing.Point(263, 248);
            this.chkCachdung.Name = "chkCachdung";
            this.chkCachdung.Size = new System.Drawing.Size(160, 22);
            this.chkCachdung.TabIndex = 25;
            this.chkCachdung.Text = "Kèm cách dùng";
            // 
            // chkchenhlech
            // 
            this.chkchenhlech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkchenhlech.Location = new System.Drawing.Point(262, 290);
            this.chkchenhlech.Name = "chkchenhlech";
            this.chkchenhlech.Size = new System.Drawing.Size(160, 22);
            this.chkchenhlech.TabIndex = 26;
            this.chkchenhlech.Text = "Chênh lệch thuốc in riêng";
            this.chkchenhlech.Click += new System.EventHandler(this.chkchenhlech_Click);
            // 
            // frmDonthuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 357);
            this.Controls.Add(this.chkchenhlech);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
            i_nhom = m.nhom_duoc;
            //
            bGia_bh_quydinh = m.bGia_bh_quydinh;
            bGia_bh_quydinh_giamua = m.bGia_bh_quydinh_giamua;
            chkchenhlech.Checked = m.Thongso("indonthuoc_tachchenhlech") == "1";
            
            //
			i_dongia=d.d_dongia_le(i_nhom);
			chkCachdung.Checked=m.bDonthuoc_cachdung;
			ds1.ReadXml("..//..//..//xml//d_donthuoc1.xml");
            ds1.Tables[0].Columns.Add("giaban", typeof(decimal)).DefaultValue = 0;
            ds1.Tables[0].Columns.Add("sothe", typeof(string));
            ds1.Tables[0].Columns.Add("tungay", typeof(string));
            ds1.Tables[0].Columns.Add("denngay", typeof(string));
            ds1.Tables[0].Columns.Add("mabv", typeof(string));
            //ds1.Tables[0].Columns.Add("tenbv", typeof(string));
            ds1.Tables[0].Columns.Add("traituyen", typeof(decimal)).DefaultValue = 0;
            ds1.Tables[0].Columns.Add("maicd", typeof(string));
            ds1.Tables[0].Columns.Add("chandoan", typeof(string));
            ds1.Tables[0].Columns.Add("manhom", typeof(decimal)).DefaultValue = 0;
            ds1.Tables[0].Columns.Add("tennhom", typeof(string));
            ds1.Tables[0].Columns.Add("hotennguoinhap", typeof(string));//Tu:11/08/2011
            ds1.Tables[0].Columns.Add("solan", typeof(decimal)).DefaultValue = 0;

			ds2.ReadXml("..//..//..//xml//d_donthuoc2.xml");
            ds2.Tables[0].Columns.Add("giaban", typeof(decimal)).DefaultValue = 0;
            ds2.Tables[0].Columns.Add("sothe", typeof(string));
            ds2.Tables[0].Columns.Add("tungay", typeof(string));
            ds2.Tables[0].Columns.Add("denngay", typeof(string));
            ds2.Tables[0].Columns.Add("mabv", typeof(string)); 
            //ds2.Tables[0].Columns.Add("tenbv", typeof(string));
            ds2.Tables[0].Columns.Add("traituyen", typeof(decimal)).DefaultValue = 0;
            ds2.Tables[0].Columns.Add("maicd", typeof(string));
            ds2.Tables[0].Columns.Add("chandoan", typeof(string));
            ds2.Tables[0].Columns.Add("manhom", typeof(decimal)).DefaultValue = 0;
            ds2.Tables[0].Columns.Add("tennhom", typeof(string));
            ds2.Tables[0].Columns.Add("hotennguoinhap", typeof(string));//Tu:11/08/2011
            ds2.Tables[0].Columns.Add("solan", typeof(decimal)).DefaultValue = 0;

            //ds.ReadXml("..//..//..//xml//d_donthuoc.xml");
            //ds.Tables[0].Columns.Add("giaban", typeof(decimal)).DefaultValue = 0;
            sql = " select '0' as nhom,0 as loai,' ' as makp,' ' as mabn,null hoten,0 as madoituong, 0 as ma ,0 as dongia, 0 as soluong , 0 as giaban,'' as bacsy ";//from " + m.user + ".d_loaiphieu where 1=2 ";
            ds = m.get_data(sql);
                    

			dsmabn.ReadXml("..//..//..//xml//d_mabn.xml");
            dsmabn.Tables[0].Columns.Add("sothe");
            dsmabn.Tables[0].Columns.Add("tungay");
            dsmabn.Tables[0].Columns.Add("denngay");
            dsmabn.Tables[0].Columns.Add("mabv");
            dsmabn.Tables[0].Columns.Add("tenbv");
            dsmabn.Tables[0].Columns.Add("traituyen", typeof(decimal)).DefaultValue = 0;
            dsmabn.Tables[0].Columns.Add("maicd", typeof(string));
            dsmabn.Tables[0].Columns.Add("chandoan", typeof(string));

			dsphong.ReadXml("..//..//..//xml//d_mabn.xml");
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
			
            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong";
			dt=m.get_data(sql).Tables[0];
			madoituong.DataSource=dt;
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";

			chksang_chieu.Enabled=m.bChieu_sang;
			if (chksang_chieu.Enabled) chksang_chieu.Checked=true;

            //gam 18-04-2011
			//sql="select id,trim(ten)||' '||hamluong as ten,dang as dvt from "+user+".d_dmbd where nhom="+i_nhom;
            sql = "select id,trim(ten)||' '||hamluong as ten,dang as dvt from " + user + ".d_dmbd ";
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
			m.close();this.Close();
		}
		
        private void get_data()
        {
            Cursor = Cursors.WaitCursor;
            DataTable t1 = new DataTable("toa1");
            DataTable t2 = new DataTable("toa2");
            string s_giaban = (d.bGiaban(m.nhom_duoc)) ? "z.giaban" : "z.giaban";// "z.giamua";
            string s_dongia = (bGia_bh_quydinh) ? "case when bd.gia_bh=0 then z.giamua else bd.gia_bh end" : "z.giamua";
            t1 = ds1.Tables[0].Clone();
            t2 = ds2.Tables[0].Clone();
            ds.Clear(); dsphong.Clear();
            title = (tu.Text == den.Text) ? "Ngày " + tu.Text : "Ngày " + tu.Text + "-" + den.Text;
            s_mabn = "";
            foreach (DataRow r in dsmabn.Tables[0].Select("chon=true", "mabn")) s_mabn += "'" + r["mabn"].ToString().Trim() + "',";
            s_madoituong = "";
            if (madoituong.SelectedItems.Count > 0)
                for (int i = 0; i < madoituong.Items.Count; i++)
                    if (madoituong.GetItemChecked(i)) s_madoituong += dt.Rows[i]["madoituong"].ToString().Trim() + ",";
            s_makp = "'";
            if (makp.CheckedItems.Count == 0) for (int i = 0; i < makp.Items.Count; i++) makp.SetItemCheckState(i, CheckState.Checked);
            for (int i = 0; i < makp.Items.Count; i++)
                if (makp.GetItemChecked(i)) s_makp += dtkp.Rows[i]["makp"].ToString().Trim() + "','";
            s_makp = (s_makp.Length > 1) ? s_makp.Substring(0, s_makp.Length - 1) : "";
            s_loai = ""; s_tenloai = "";
            if (loai.SelectedItems.Count > 0)
                for (int i = 0; i < loai.Items.Count; i++)
                    if (loai.GetItemChecked(i))
                    {
                        s_loai += dtloai.Rows[i]["id"].ToString().Trim() + ",";
                        s_tenloai += dtloai.Rows[i]["ten"].ToString().Trim() + ",";
                    }
            s_phieu = ""; s_tenphieu = "";
            if (phieu.SelectedItems.Count > 0)
                for (int i = 0; i < phieu.Items.Count; i++)
                    if (phieu.GetItemChecked(i))
                    {
                        s_phieu += dtphieu.Rows[i]["id"].ToString().Trim() + ",";
                        s_tenphieu += dtphieu.Rows[i]["ten"].ToString().Trim() + ",";
                    }
            DateTime d1 = d.StringToDate(tu.Text).AddDays(-1);
            DateTime d2 = d.StringToDate(den.Text);
            DateTime d3 = d.StringToDate(tu.Text);
            DateTime d4 = d.StringToDate(den.Text).AddDays(-1);
            DateTime dt1 = d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
            DateTime dt2 = d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
            //
            ds = null;
            //
            sql = "select distinct b.id, b.mabn,c.mabs,e.ten as phong,c.giuong, bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nk.maicd, nk.chandoan,b2.solan ";
            sql += " from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join (select id,avg(solan) solan from xxx.d_dutruct group by id) b2 on b.id = b2.id ";
            sql += " left join xxx.d_dausinhton c on b.id=c.id inner join " + user + ".d_duockp d on a.makhoa=d.id ";
            sql += " left join "+ user + ".dmgiuong f on c.giuong=f.ma ";
            sql += " left join " + user + ".dmphong e on f.idphong=e.id ";
            sql += " left join " + user + ".bhyt bh on  b.maql=bh.maql and (bh.sudung is null or bh.sudung=1) ";
            sql += " left join " + user + ".dmnoicapbhyt bv on bh.mabv=bv.mabv left join " + user + ".nhapkhoa nk on b.idkhoa=nk.id ";
            sql += " where 1=1 ";
            if (s_makp != "") sql += " and d.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
            if (s_loai != "") sql += " and a.loai in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
            if (s_phieu != "") sql += " and a.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
            if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
            sql += " and to_date(to_char(a.ngay,'dd/MM/yyyy'),'dd/MM/yyyy') between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
            sql += " and (c.phong is not null or c.giuong is not null or c.mabs is not null)";
            //
            sql += " union all ";
            sql += "select distinct b.id, b.mabn,c.mabs,e.ten as phong,c.giuong, bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nk.maicd, nk.chandoan,b2.solan ";
            sql += " from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join (select id,avg(solan) solan from xxx.d_xtutrucct group by id) b2 on b.id = b2.id  left join xxx.d_dausinhton c on b.id=c.id ";
            sql += " left join " + user + ".d_duockp d on a.makhoa=d.id ";
            sql += " left join " + user + ".dmgiuong f on c.giuong=f.ma ";
            sql += " left join " + user + ".dmphong e on f.idphong=e.id ";
            sql += " left join " + user + ".bhyt bh on b.maql=bh.maql and (bh.sudung is null or bh.sudung=1) ";
            sql += " left join " + user + ".dmnoicapbhyt bv on bh.mabv=bv.mabv ";
            sql += " left join " + user + ".nhapkhoa nk on  b.idkhoa=nk.id ";
            sql += " where  1=1 ";
            if (s_makp != "") sql += " and d.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
            if (s_loai != "") sql += " and a.loai in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
            if (s_phieu != "") sql += " and a.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
            if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
            sql += " and to_date(to_char(a.ngay,'dd/MM/yyyy'),'dd/MM/yyyy') between to_date('" + m.DateToString("dd/MM/yyyy", dt1) +
                "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
            sql += " and (c.phong is not null or c.giuong is not null or c.mabs is not null)";
            //
            sql += " UNION ALL ";
            sql += "select distinct b.id, b.mabn,c.mabs,e.ten as phong,c.giuong , bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nk.maicd, nk.chandoan,number '1' solan ";
            sql += " from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet left join xxx.d_dausinhton c on b.id=c.id ";
            sql += " inner join " + user + ".d_duockp d on a.makhoa=d.id ";
            sql += " left join " + user + ".dmgiuong f on c.giuong=f.ma ";
            sql += " left join " + user + ".dmphong e on f.idphong=e.id ";
            sql += " left join " + user + ".bhyt bh on b.maql=bh.maql and (bh.sudung is null or bh.sudung=1) ";
            sql += " left join " + user + ".dmnoicapbhyt bv on bh.mabv=bv.mabv left join " + user + ".nhapkhoa nk on  b.idkhoa=nk.id ";
            sql += " where 1=1 ";                
            if (s_makp != "") sql += " and d.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
            if (s_loai != "") sql += " and a.loai in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
            if (s_phieu != "") sql += " and a.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
            if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
            sql += " and a.ngay between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
            sql += " and (c.phong is not null or c.giuong is not null or c.mabs is not null)";
            //
            sql += " UNION ALL ";
            sql += " select distinct b.id, b.mabn,b.mabs,'' as phong, null as giuong , bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nk.maicd, nk.chandoan,b.soluong solan ";
            sql += " from xxx.v_chidinh b left join " + user + ".bhyt bh on b.maql=bh.maql and (bh.sudung is null or bh.sudung=1) ";
            sql += " left join " + user + ".dmnoicapbhyt bv on bh.mabv=bv.mabv inner join " + user + ".nhapkhoa nk on b.idkhoa=nk.id and b.idkhoa>0 ";
            sql += " where to_date(to_char(b.ngay," + stime + ")," + stime + ") between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
            //
            sql += " UNION ALL ";
            sql += " select distinct b.id, b.mabn,'' as mabs,'' as phong, null as giuong , bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nk.maicd, nk.chandoan,b.soluong solan ";
            sql += " from xxx.v_vpkhoa b left join " + user + ".bhyt bh on b.maql=bh.maql and (bh.sudung is null or bh.sudung=1)";
            sql += " left join " + user + ".dmnoicapbhyt bv on  bh.mabv=bv.mabv ";
            sql += " inner join " + user + ".nhapkhoa nk on b.maql=nk.maql and b.idkhoa=nk.id ";
            sql += " where  to_date(to_char(b.ngay," + stime + ")," + stime + ") between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
            // gam 26-04-2011
            dsphong.Merge(d.get_thuoc(m.DateToString("dd/MM/yyyy", dt1), m.DateToString("dd/MM/yyyy", dt2), sql));
            //
            if (chkCachdung.Checked)
            {
                sql = "select distinct b.mabn,c.mabd,c.madoituong,c.cachdung ";
                sql += " from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join xxx.d_dutruct c on b.id=c.id  ";
                sql += " where c.cachdung is not null and c.cachdung<>''";
                if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
                sql += " and to_date(to_char(a.ngay,'dd/MM/yyyy'),'dd/MM/yyyy') between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
                sql += " UNION ALL ";
                sql += "select distinct b.mabn,c.mabd,c.madoituong,c.cachdung ";
                sql += " from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join xxx.d_xtutrucct c on b.id=c.id ";
                sql += " where c.cachdung is not null and c.cachdung<>''";
                if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
                sql += " and to_date(to_char(a.ngay,'dd/MM/yyyy'),'dd/MM/yyyy') between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
                dtcachdung = d.get_thuoc(m.DateToString("dd/MM/yyyy", dt1), m.DateToString("dd/MM/yyyy", dt2), sql).Tables[0];
            }
            //
            if (s_loai != "3,")
            {
                if (s_loai == "" || s_loai.IndexOf("1,") != -1)
                {
                    sql = "select '0' as nhom,0 as loai,d.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh as hoten,c.madoituong,c.mabd as ma,";
                    sql += " case when f.loai=1 and c.madoituong<>1 then " + s_giaban + " else " + s_dongia + " end as dongia, ";
                    sql += " sum(c.soluong) as soluong";
                    sql += " ,z.giaban, b.idduyet, bd.manhom, tt.ten as tennhom,dl.hoten as hotennguoinhap, avg(b2.solan) solan";//Tu:11/08/2011 lay them hoten nguoi nhap
                    sql += " from " + user + ".btdbn a inner join xxx.d_xuatsdll b on a.mabn=b.mabn inner join xxx.d_xuatsdct c on b.id=c.id ";
                    sql += " inner join xxx.d_theodoi z on c.sttt=z.id inner join " + user + ".d_duockp d on b.makhoa=d.id ";
                    sql += " inner join " + user + ".d_loaiphieu e on b.phieu=e.id inner join " + user + ".d_doituong f on c.madoituong=f.madoituong ";
                    sql += " inner join xxx.d_dutrull g on b.idduyet=g.id inner join xxx.d_dutruct b2 on g.id = b2.id inner join xxx.d_duyet t on g.idduyet=t.id";
                    sql += " inner join " + user + ".d_dmbd bd on c.mabd=bd.id inner join " + user + ".d_dmnhom tt on bd.manhom=tt.id ";
                    sql += " left join " + user + ".dlogin dl on g.userid=dl.id ";//Tu:11/08/2011 lay them hoten nguoi nhap
                    sql += " where  1=1 ";//gam 1310/2011
                    if (s_makp != "") sql += " and d.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
                    if (s_madoituong != "") sql += " and c.madoituong in (" + s_madoituong.Substring(0, s_madoituong.Length - 1) + ")";
                    if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
                    if (s_loai != "" && s_loai.IndexOf("3,") == -1) sql += " and b.loai in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
                    else sql += " and b.loai<>3";
                    if (s_phieu != "") sql += " and t.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
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
                    sql += " and t.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                    sql += " group by d.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh,c.madoituong,c.mabd,";//case when f.loai=0 then z.giamua else z.giaban end";
                    sql += " case when f.loai=1 and c.madoituong<>1 then " + s_giaban + " else " + s_dongia + " end, ";
                    sql += " z.giaban, b.idduyet, bd.manhom, tt.ten,dl.hoten  ";//Tu:11/08/2011 lay them hoten nguoi nhap
                    if (ds == null || ds.Tables.Count <= 0) ds = d.get_thuoc(tu.Text, den.Text, sql);
                    else ds.Merge(d.get_thuoc(tu.Text, den.Text, sql));
                }
                if (s_loai == "" || s_loai.IndexOf("2,") != -1)
                {
                    sql = "select '0' as nhom,0 as loai,d.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh as hoten,c.madoituong,c.mabd as ma,";
                    //sql+=" case when f.loai=0 then z.giamua else z.giaban end as dongia,";
                    //sql+=" sum(c.soluong) as soluong";
                    sql += " case when f.loai=1 and c.madoituong<>1 then " + s_giaban + " else " + s_dongia + " end as dongia, ";
                    sql += " sum(c.soluong) as soluong";
                    sql += " ,z.giaban, b.idduyet, bd.manhom, tt.ten as tennhom,dl.hoten as hotennguoinhap, avg(b2.solan) solan";//Tu:11/08/2011 lay them hoten nguoi nhap
                    sql += " from " + user + ".btdbn a inner join xxx.d_xuatsdll b on a.mabn=b.mabn inner join xxx.d_xuatsdct c on b.id=c.id ";
                    sql += " inner join " + user + ".d_duockp d on b.makhoa=d.id inner join " + user + ".d_loaiphieu e on b.phieu=e.id ";
                    sql += " inner join " + user + ".d_doituong f on c.madoituong=f.madoituong ";
                    sql += " inner join  xxx.d_xtutrucll g on b.idduyet=g.id inner join xxx.d_xtutrucct b2 on g.id = b2.id inner join xxx.d_duyet t on g.idduyet=t.id ";
                    sql += " inner join xxx.d_theodoi z on c.sttt=z.id inner join " + user + ".d_dmbd bd on c.mabd=bd.id inner join " + user + ".d_dmnhom tt on bd.manhom=tt.id ";
                    sql += " left join " + user + ".dlogin dl on g.userid=dl.id ";//Tu:11/08/2011 lay them hoten nguoi nhap
                    sql += " where 1=1 ";
                    if (s_makp != "") sql += " and d.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")"; 
                    if (s_madoituong != "") sql += " and c.madoituong in (" + s_madoituong.Substring(0, s_madoituong.Length - 1) + ")";
                    if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
                    if (s_loai != "" && s_loai.IndexOf("3,") == -1) sql += " and b.loai in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
                    else sql += " and b.loai<>3";
                    if (s_phieu != "") sql += " and t.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
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
                    sql += " group by b.loai,d.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh,c.madoituong,c.mabd,";//case when f.loai=0 then z.giamua else z.giaban end";
                    sql += " case when f.loai=1 and c.madoituong<>1 then " + s_giaban + " else " + s_dongia + " end, ";
                    sql += " z.giaban, b.idduyet, bd.manhom, tt.ten,dl.hoten ";//Tu:11/08/2011 lay them hoten nguoi nhap
                    if (ds == null || ds.Tables.Count <= 0) ds = d.get_thuoc(tu.Text, den.Text, sql);
                    else ds.Merge(d.get_thuoc(tu.Text, den.Text, sql));
                }
            }
            if (s_loai == "" || s_loai.IndexOf("3,") != -1)
            {
                sql = "select '0' as nhom,0 as loai,d.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh as hoten,c.madoituong,c.mabd as ma,";
                //sql+=" case when f.loai=0  then z.giamua else z.giaban end as dongia,";
                //sql+="-sum(c.soluong) as soluong";
                sql += " case when f.loai=1 and c.madoituong<>1 then " + s_giaban + " else " + s_dongia + " end as dongia, ";
                sql += " -1*sum(c.soluong) as soluong";
                sql += " ,z.giaban, b.idduyet, bd.manhom, tt.ten as tennhom ";
                sql += " from " + user + ".btdbn a inner join xxx.d_xuatsdll b on a.mabn=b.mabn inner join xxx.d_xuatsdct c on b.id=c.id ";
                sql += " inner join xxx.d_theodoi z on c.sttt=z.id inner join " + user + ".d_duockp d on  b.makhoa=d.id ";
                sql += " inner join " + user + ".d_loaiphieu e on b.phieu=e.id inner join " + user + ".d_doituong f on c.madoituong=f.madoituong ";
                sql += " inner join xxx.d_hoantrall g on b.idduyet=g.id inner join xxx.d_duyet t on g.idduyet=t.id ";
                sql += " inner join " + user + ".d_dmbd bd on c.mabd=bd.id inner join " + user + ".d_dmnhom tt on  bd.manhom=tt.id ";
                sql += " where  1=1";
                if (s_makp != "") sql += " and d.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
                if (s_madoituong != "") sql += " and c.madoituong in (" + s_madoituong.Substring(0, s_madoituong.Length - 1) + ")";
                if (s_mabn != "") sql += " and b.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
                sql += " and b.loai=3";
                if (s_phieu != "") sql += " and t.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
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
                sql += " group by d.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh,c.madoituong,c.mabd,";//case when f.loai=0 then z.giamua else z.giaban end";
                sql += " case when f.loai=1 and c.madoituong<>1 then " + s_giaban + " else " + s_dongia + " end, ";
                sql += " z.giaban, b.idduyet, bd.manhom, tt.ten ";
                if (ds == null || ds.Tables.Count <= 0) ds = d.get_thuoc(tu.Text, den.Text, sql);
                else ds.Merge(d.get_thuoc(tu.Text, den.Text, sql));
            }

            if (chkvienphi.Checked)
            {
                sql = "select '1' as nhom,0 as loai,b.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh as hoten,b.madoituong,b.mavp as ma,(b.dongia+b.vattu) as dongia,sum(b.soluong) as soluong, (b.dongia+b.vattu) as giaban, to_number('0') as idduyet, to_number('0') as manhom, 'CLS' as tennhom";
                sql += " from " + user + ".btdbn a inner join xxx.v_vpkhoa b on a.mabn=b.mabn inner join " + user + ".v_giavp c on b.mavp=c.id ";
                sql += " where 1=1 ";
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
                sql += " and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " group by b.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh,b.madoituong,b.mavp,(b.dongia+b.vattu)";
                ds.Merge(d.get_thuoc(tu.Text, den.Text, sql));
                //
                sql = "select '1' as nhom,0 as loai,b.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh as hoten,b.madoituong,b.mavp as ma,(b.dongia+b.vattu) as dongia,sum(b.soluong) as soluong, (b.dongia+b.vattu) as giaban, to_number('0') as idduyet, to_number('0') as manhom, 'CLS' as tennhom";
                sql += " from " + user + ".btdbn a inner join xxx.v_chidinh b on a.mabn=b.mabn inner join " + user + ".v_giavp c on b.mavp=c.id ";
                sql += " where 1=1 ";
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
                sql += " group by b.makp,a.mabn,trim(a.hoten)||' ,Giới tính :'||case when a.phai=0 then 'Nam' else 'Nữ' end||', Năm sinh :'||a.namsinh,b.madoituong,b.mavp,(b.dongia+b.vattu)";
                if (ds == null || ds.Tables.Count <= 0) ds = d.get_thuoc(tu.Text, den.Text, sql);
                else ds.Merge(d.get_thuoc(tu.Text, den.Text, sql));
            }
            //
            if (chkchenhlech.Checked) tach_chenhlech_thuoc(ds.Tables[0].Copy());
            sort(t1, t2);
            dsxml = new DataSet();
            dsxml.Tables.Add(t1);
            dsxml.Tables.Add(t2);
            if (System.IO.Directory.Exists("..//..//dataxml") == false) System.IO.Directory.CreateDirectory("..//..//dataxml");
            try
            {
                dsxml.WriteXml("..//..//dataxml//d_donthuoc12.xml", XmlWriteMode.WriteSchema);
            }
            catch { }
            Cursor = Cursors.Default;
        }
		private void upd_data(DataTable dta,string makp,string madoituong,string mabn,string hoten,string nhom,int loai,string ma,string dongia,string soluong, decimal giaban, decimal l_idxuat, int d_manhom, string d_tennhom,string s_hotennguoinhap,decimal solan)
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
                    if (solan != null)
                        r2["solan"] = solan;
                    r6 = m.getrowbyid(dsphong.Tables[0], "mabn='" + mabn + "' and id=" + l_idxuat);
                    if (r6 == null) r6 = m.getrowbyid(dsphong.Tables[0], "mabn='" + mabn + "'");
					if (r6!=null)
					{
						r2["phong"]=r6["phong"].ToString();
						r2["giuong"]=r6["giuong"].ToString();
						r7=m.getrowbyid(dtbs,"ma='"+r6["mabs"].ToString()+"'");
						if (r7!=null) r2["bacsy"]=r7["hoten"].ToString();
                        //
                        r2["sothe"] = r6["sothe"].ToString();
                        r2["tungay"] = r6["tungay"].ToString();
                        r2["denngay"] = r6["denngay"].ToString();
                        r2["mabv"] = r6["mabv"].ToString();
                        r2["tenbv"] = r6["tenbv"].ToString();
                        r2["traituyen"] = (r6["traituyen"].ToString() == "") ? "0" : r6["traituyen"].ToString();
                        r2["maicd"]=r6["maicd"].ToString();
                        r2["chandoan"] = r6["chandoan"].ToString();
					}
					if (chkCachdung.Checked) 
					{
						r8=m.getrowbyid(dtcachdung,"mabn='"+mabn+"' and mabd="+int.Parse(ma)+" and madoituong="+int.Parse(madoituong));
						if (r8!=null) r2["cachdung"]=r8["cachdung"].ToString();
					}
					else r2["cachdung"]="";
					r2["ngay"]=title;
					r2["loai"]=loai;
					r2["phieu"]=s_tenphieu;
					r2["tenloai"]=s_tenloai;
					r2["soluong"]=soluong;
					r2["dongia"]=dongia;
                    r2["giaban"] = giaban;
                    //
                    r2["manhom"] = d_manhom ;
                    r2["tennhom"] = d_tennhom ;
                    r2["hotennguoinhap"] = s_hotennguoinhap;//Tu:11/08/2011
                    //
                    DataRow dr1 = m.getrowbyid(dsmabn.Tables[0], "mabn='" + mabn + "'");
                    if (dr1 != null)
                    {
                        r2["sothe"] = dr1["sothe"].ToString();
                        r2["tungay"] = dr1["tungay"].ToString();
                        r2["denngay"] = dr1["denngay"].ToString();
                        r2["mabv"] = dr1["mabv"].ToString();
                        r2["tenbv"] = dr1["tenbv"].ToString();
                        r2["traituyen"] = (dr1["traituyen"].ToString() == "") ? "0" : dr1["traituyen"].ToString();
                        r2["maicd"] = dr1["maicd"].ToString();
                        r2["chandoan"]= dr1["chandoan"].ToString();
                    }
                    //
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
                upd_data((j % 2 == 0) ? t2 : t1, r["makp"].ToString(), r["madoituong"].ToString(), r["mabn"].ToString(), r["hoten"].ToString(), r["nhom"].ToString(), int.Parse(r["loai"].ToString()), r["ma"].ToString(), r["dongia"].ToString(), r["soluong"].ToString(), decimal.Parse(r["giaban"].ToString()), (r["idduyet"].ToString() == "") ? 0 : decimal.Parse(r["idduyet"].ToString()), (r["manhom"].ToString() == "") ? 0 : int.Parse(r["manhom"].ToString()), r["tennhom"].ToString(),r["hotennguoinhap"].ToString(),r.Table.Columns.Contains("solan")?decimal.Parse(r["solan"].ToString()):0);
			}
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			get_data();
			if (dsxml.Tables[0].Rows.Count>0)
			{
                int i = 0; string smabn = "";
                dsxml.Tables[0].Columns.Add("stt");
                dsxml.Tables[1].Columns.Add("stt");
                DataSet dstemp = dsxml.Clone();
                foreach (DataRow r in dsxml.Tables[0].Select("", "mabn"))
                {
                    if (smabn != r["mabn"].ToString())
                    {
                        i++;
                    }
                    r["stt"] = i.ToString();
                    smabn = r["mabn"].ToString();
                    dstemp.Tables[0].Rows.Add(r.ItemArray);
                }
                foreach (DataRow r1 in dsxml.Tables[1].Select("", "mabn"))
                {
                    if (smabn != r1["mabn"].ToString())
                    {
                        i++;
                    }
                    r1["stt"] = i.ToString();
                    smabn = r1["mabn"].ToString();
                    dstemp.Tables[1].Rows.Add(r1.ItemArray);
                }
                dstemp.WriteXml("..//..//dataxml//d_donthuoc12.xml", XmlWriteMode.WriteSchema);
                dllReportM.frmReport f = new dllReportM.frmReport(m, dstemp, title, (chkCachdung.Checked) ? "rpt_donthuoc_cd.rpt" : "rpt_donthuoc.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			get_data();
            if (dsxml.Tables[0].Rows.Count > 0)
            {
                int i = 0; string smabn = "";
                try
                {
                    dsxml.Tables[0].Columns.Add("stt");
                }
                catch { }
                try
                {
                    dsxml.Tables[1].Columns.Add("stt");
                }
                catch { }
                DataSet dstemp = dsxml.Clone();
                foreach (DataRow r in dsxml.Tables[0].Select("", "mabn"))
                {
                    if (smabn != r["mabn"].ToString())
                    {
                        i++;
                    }
                    r["stt"] = i.ToString();
                    smabn = r["mabn"].ToString();
                    dstemp.Tables[0].Rows.Add(r.ItemArray);
                }
                foreach (DataRow r1 in dsxml.Tables[1].Select("", "mabn"))
                {
                    if (smabn != r1["mabn"].ToString())
                    {
                        i++;
                    }
                    r1["stt"] = i.ToString();
                    smabn = r1["mabn"].ToString();
                    dstemp.Tables[1].Rows.Add(r1.ItemArray);
                }
                try
                {
                    if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                    dstemp.WriteXml("..\\..\\dataxml\\d_donthuoc12.xml", XmlWriteMode.WriteSchema);
                }
                catch { }
                print.Printer(m, dstemp, (chkCachdung.Checked) ? "rpt_donthuoc_cd.rpt" : "rpt_donthuoc.rpt", title, (chkCachdung.Checked) ? 2 : 1);
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
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
			DateTime dt1=d.StringToDate(tu.Text);//.AddDays(-1);
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
			sql="select distinct b.mabn,c.hoten, bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nk.maicd, nk.chandoan ";
            sql+=" from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join "+user+".btdbn c on b.mabn=c.mabn ";
            sql += " inner join " + user + ".d_duockp d on a.makhoa=d.id ";
            sql += " left join " + user + ".bhyt bh on b.maql=bh.maql and (bh.sudung is null or bh.sudung=1)";
            sql += " left join " + user + ".dmnoicapbhyt bv on  bh.mabv=bv.mabv left join " + user + ".nhapkhoa nk on  b.idkhoa=nk.id ";
            sql += " where  1=1 ";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')  between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
			sql+=" union ";// all ";
            sql += "select distinct b.mabn,c.hoten, bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nk.maicd, nk.chandoan  ";
            sql += " from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join " + user + ".btdbn c on b.mabn=c.mabn ";
            sql += " inner join " + user + ".d_duockp d on a.makhoa=d.id left join " + user + ".bhyt bh on b.maql=bh.maql and (bh.sudung is null or bh.sudung=1)";
            sql += " left join " + user + ".dmnoicapbhyt bv on bh.mabv=bv.mabv left join  " + user + ".nhapkhoa nk on b.idkhoa=nk.id ";
            sql += " where 1=1 ";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')  between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
			sql+=" union ";// all ";
            sql += "select distinct b.mabn,c.hoten, bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nk.maicd, nk.chandoan  ";
            sql += " from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet inner join " + user + ".btdbn c on b.mabn=c.mabn ";
            sql += " inner join " + user + ".d_duockp d on a.makhoa=d.id left join " + user + ".bhyt bh on b.maql=bh.maql and (bh.sudung is null or bh.sudung=1)";
            sql += " left join " + user + ".dmnoicapbhyt bv on bh.mabv=bv.mabv left join " + user + ".nhapkhoa nk on b.idkhoa=nk.id";
            sql += " where 1=1 ";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')  between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
            //
            //v_chidinh
            sql += " union ";// all";
            sql += "select distinct a.mabn,c.hoten, bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nvl(nk.maicd, a.maicd) as maicd, nvl(nk.chandoan, a.chandoan) as chandoan  ";
            sql += " from xxx.v_chidinh a inner join " + user + ".btdbn c on a.mabn=c.mabn inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
            sql += " left join " + user + ".bhyt bh on a.maql=bh.maql and (bh.sudung is null or bh.sudung=1) ";
            sql += " left join " + user + ".dmnoicapbhyt bv on bh.mabv=bv.mabv left join " + user + ".nhapkhoa nk on  a.idkhoa=nk.id";
            sql += " where 1=1 ";
            if (s_makp != "") sql += " and d.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')  between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";
            //
            //vp khoa
            sql += " union ";// all";
            sql += "select distinct a.mabn,c.hoten, bh.sothe, bh.tungay, bh.denngay, bh.mabv, bh.traituyen, bv.tenbv, nvl(nk.maicd,'') as maicd, nvl(nk.chandoan, '') as chandoan  ";
            sql += " from xxx.v_vpkhoa a inner join " + user + ".btdbn c on a.mabn=c.mabn inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
            sql += " left join " + user + ".bhyt bh  on a.maql=bh.maql and (bh.sudung is null or bh.sudung=1) ";
            sql += " left join " + user + ".dmnoicapbhyt bv on bh.mabv=bv.mabv left join  " + user + ".nhapkhoa nk on a.idkhoa=nk.id ";
            sql += " where 1=1 ";
            if (s_makp != "") sql += " and d.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')  between to_date('" + m.DateToString("dd/MM/yyyy", dt1) + "'," + stime + ") and to_date('" + m.DateToString("dd/MM/yyyy", dt2) + "'," + stime + ")";

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
                    r2["sothe"] = r["sothe"].ToString();
                    r2["tungay"] = r["tungay"].ToString();
                    r2["denngay"] = r["denngay"].ToString();
                    r2["mabv"] = r["mabv"].ToString();
                    r2["tenbv"] = r["tenbv"].ToString();
                    r2["traituyen"] = r["traituyen"].ToString() == "" ? 0 : int.Parse(r["traituyen"].ToString());
                    r2["chandoan"] = r["chandoan"].ToString();
                    r2["maicd"] = r["maicd"].ToString();
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

        private void tach_chenhlech_thuoc(DataTable dtthuoc)
        {
            int iTunguyen = m.iTunguyen; 
            DataTable dt1=dtthuoc.Clone();
            foreach(DataRow r in dtthuoc.Select("madoituong=1 and nhom='0' and giaban > dongia"))
            {
                dt1.Rows.Add(r.ItemArray);
            }
            foreach (DataRow r1 in dt1.Rows)
            {
                r1["madoituong"] = iTunguyen;
                r1["dongia"] = decimal.Parse(r1["giaban"].ToString()) - decimal.Parse(r1["dongia"].ToString());
            }
            dt1.AcceptChanges();
            foreach (DataRow r2 in dt1.Rows)
            {
                ds.Tables[0].Rows.Add(r2.ItemArray);
            }
            ds.AcceptChanges();
        }

        private void chkchenhlech_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "indonthuoc_tachchenhlech", chkchenhlech.Checked ? "1" : "0");
        }

        
	}
}
