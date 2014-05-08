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
	/// <summary>
	/// Summary description for frmThutien.
	/// </summary>
	public class frmThutien : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox madoituong;
		private System.Windows.Forms.CheckBox chksang_chieu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private LibMedi.AccessData m;
		private DataTable dt=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtdm=new DataTable();
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dsphong=new DataSet();
		private DataSet dsmabn=new DataSet();
		private DataSet dsbke=new DataSet();
		private DataSet dsxmlbke=new DataSet();
		private int i_dongia,i_sotien_le;
		private string s_makp,sql,s_mabn,s_madoituong;
		private System.Windows.Forms.CheckedListBox makp;
        private dllReportM.Print print = new dllReportM.Print();
		private System.Windows.Forms.CheckBox chklist;
		private System.Windows.Forms.Button butList;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tim;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged;
		int checkCol=0;
		private System.Windows.Forms.Button butDanhsach;
		private System.Windows.Forms.Button butBK;
		private System.Windows.Forms.CheckBox chkXem;
		private System.Windows.Forms.NumericUpDown soban;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThutien(LibMedi.AccessData acc,string _makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = _makp; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThutien));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.CheckedListBox();
            this.chksang_chieu = new System.Windows.Forms.CheckBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.chklist = new System.Windows.Forms.CheckBox();
            this.butList = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.butDanhsach = new System.Windows.Forms.Button();
            this.butBK = new System.Windows.Forms.Button();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.soban = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soban)).BeginInit();
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
            this.madoituong.Size = new System.Drawing.Size(160, 244);
            this.madoituong.TabIndex = 3;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chksang_chieu
            // 
            this.chksang_chieu.Location = new System.Drawing.Point(64, 296);
            this.chksang_chieu.Name = "chksang_chieu";
            this.chksang_chieu.Size = new System.Drawing.Size(176, 22);
            this.chksang_chieu.TabIndex = 4;
            this.chksang_chieu.Text = "Chiều hôm qua,sáng hôm nay";
            this.chksang_chieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(127, 328);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(93, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(490, 328);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(102, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 32);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 260);
            this.makp.TabIndex = 2;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chklist
            // 
            this.chklist.Location = new System.Drawing.Point(258, 254);
            this.chklist.Name = "chklist";
            this.chklist.Size = new System.Drawing.Size(160, 22);
            this.chklist.TabIndex = 8;
            this.chklist.Text = "Đưa vào danh sách thu tiền";
            // 
            // butList
            // 
            this.butList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butList.Location = new System.Drawing.Point(220, 328);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(88, 25);
            this.butList.TabIndex = 9;
            this.butList.Text = "&Khoa đã in";
            this.butList.Click += new System.EventHandler(this.butList_Click);
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
            this.dataGrid1.Location = new System.Drawing.Point(424, 13);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(258, 307);
            this.dataGrid1.TabIndex = 25;
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(422, 8);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(264, 21);
            this.tim.TabIndex = 26;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butDanhsach
            // 
            this.butDanhsach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDanhsach.Location = new System.Drawing.Point(308, 328);
            this.butDanhsach.Name = "butDanhsach";
            this.butDanhsach.Size = new System.Drawing.Size(87, 25);
            this.butDanhsach.TabIndex = 27;
            this.butDanhsach.Text = "&Danh sách";
            this.butDanhsach.Click += new System.EventHandler(this.butDanhsach_Click);
            // 
            // butBK
            // 
            this.butBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBK.Location = new System.Drawing.Point(395, 328);
            this.butBK.Name = "butBK";
            this.butBK.Size = new System.Drawing.Size(95, 25);
            this.butBK.TabIndex = 28;
            this.butBK.Text = "In &Bảng kê";
            this.butBK.Click += new System.EventHandler(this.butBK_Click);
            // 
            // chkXem
            // 
            this.chkXem.Checked = true;
            this.chkXem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXem.Location = new System.Drawing.Point(258, 273);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(104, 22);
            this.chkXem.TabIndex = 29;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // soban
            // 
            this.soban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soban.Location = new System.Drawing.Point(368, 296);
            this.soban.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soban.Name = "soban";
            this.soban.Size = new System.Drawing.Size(48, 21);
            this.soban.TabIndex = 30;
            this.soban.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.soban.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(264, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Số bản in :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmThutien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(696, 373);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.soban);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.butBK);
            this.Controls.Add(this.butDanhsach);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butList);
            this.Controls.Add(this.chklist);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.chksang_chieu);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThutien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo thu tiền hàng ngày";
            this.Load += new System.EventHandler(this.frmThutien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmThutien_Load(object sender, System.EventArgs e)
		{
			int i_nhom=(d.Thongso("nhomkho").Trim()=="")?1:int.Parse(d.Thongso("nhomkho").Trim());
			i_dongia=d.d_dongia_le(i_nhom);
			i_sotien_le=v.sotien_le;
			sql="select c.stt as sttnhom,c.ten as tennhom,a.id,trim(a.ten)||' '||a.hamluong as ten,a.dang as dvt";
			sql+=" from d_dmbd a,d_dmnhom b,v_nhomvp c where a.manhom=b.id and b.nhomvp=c.ma and a.nhom="+i_nhom;
			sql+=" union all ";
			sql+="select c.stt as sttnhom,c.ten as tennhom,a.id,a.ten,a.dvt";
			sql+=" from v_giavp a,v_loaivp b,v_nhomvp c where a.id_loai=b.id and b.id_nhom=c.ma";
			dtdm=m.get_data(sql).Tables[0];
			ds.ReadXml("..//..//..//xml//d_ttngay.xml");
			dsxml.ReadXml("..//..//..//xml//d_ttngay.xml");
			dsphong.ReadXml("..//..//..//xml//d_mabn.xml");
			dsmabn.ReadXml("..//..//..//xml//d_mabn.xml");
			dsbke.ReadXml("..//..//..//xml//m_inravien.xml");
			dsxmlbke.ReadXml("..//..//..//xml//m_inravien.xml");
			sql="select * from btdkp_bv ";
			if (s_makp!="") sql+=" where makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+="order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=dtkp;
			sql="select * from doituong order by madoituong";
			dt=m.get_data(sql).Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dt;
			chksang_chieu.Enabled=m.bChieu_sang;
			if (chksang_chieu.Enabled) chksang_chieu.Checked=true;
			chklist.Checked=chksang_chieu.Checked;
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

		private void get_chiphi(DataTable tmp,string fie)
		{
			DataRow r1,r2,r3,r4,r5;
			DataRow [] dr;
			decimal id=0;
			foreach(DataRow r in tmp.Select("true","makp,madoituong,mabn,maql,ngayvao"))
			{
				if (chklist.Checked) id=v.get_id_thngay(tu.Text.Substring(8,2),int.Parse(r["madoituong"].ToString()),r["mabn"].ToString(),decimal.Parse(r["maql"].ToString()),r["makp"].ToString(),tu.Text,den.Text,false);
				sql="makp='"+r["makp"].ToString()+"' and madoituong="+int.Parse(r["madoituong"].ToString())+" and mabn='"+r["mabn"].ToString()+"' and maql="+decimal.Parse(r["maql"].ToString());
				r1=m.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					if (chklist.Checked)
					{
						if (id!=0) v.execute_data("delete from v_thngayct where id="+id);
						else id=v.get_id_thngay();
						d.upd_ttngay(tu.Text,r["makp"].ToString());
					}
					r3=m.getrowbyid(dt,"madoituong="+int.Parse(r["madoituong"].ToString()));
					r4=m.getrowbyid(dtkp,"makp='"+r["makp"].ToString()+"'");
					if (r3!=null && r4!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["makp"]=r["makp"].ToString();
						r2["tenkp"]=r4["tenkp"].ToString();
						r2["madoituong"]=r["madoituong"].ToString();
						r2["doituong"]=r3["doituong"].ToString();
						r2["mabn"]=r["mabn"].ToString();
						r2["maql"]=r["maql"].ToString();
						r2["ngayvao"]=r["ngayvao"].ToString();
						r2["hoten"]=r["hoten"].ToString();
						r2["tamung"]=0;
						r2["thuoc"]=0;
						r2["vienphi"]=0;
						r2[fie]=r["sotien"].ToString();
						r5=m.getrowbyid(dsphong.Tables[0],"mabn='"+r["mabn"].ToString()+"'");
						if (r5!=null)
						{
							r2["phong"]=r5["phong"].ToString();
							r2["giuong"]=r5["giuong"].ToString();
						}
						if (chklist.Checked) v.upd_thngayll(tu.Text.Substring(8,2),id,int.Parse(r["madoituong"].ToString()),r["mabn"].ToString(),decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),tu.Text,den.Text,r2["giuong"].ToString(),r["makp"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0) dr[0][fie]=decimal.Parse(dr[0][fie].ToString())+decimal.Parse(r["sotien"].ToString());
				}
				if (chklist.Checked) v.upd_thngayct(tu.Text.Substring(8,2),id,r["ngay"].ToString(),int.Parse(r["ma"].ToString()),decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["dongia"].ToString()),decimal.Parse(r["sotien"].ToString()));
			}
		}

		private decimal get_conlai(decimal id,string mabn,decimal maql,string ngayvao,string _makp,int _madoituong)
		{
			decimal tung=0,st=0;
			DateTime d1=d.StringToDate(ngayvao);
			DateTime d2=d.StringToDate(tu.Text).AddDays(-1);
			DateTime dt1=d1.AddDays(-d.iNgaykiemke);
			DateTime dt2=d2.AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="",yy="";
			DataTable tmp;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				yy=i.ToString().Substring(2,2);
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+yy;
					if (d.bMmyy(mmyy))
					{
						sql="select sum(round(c.soluong*decode(f.loai,0,c.giamua,c.giaban),"+i_dongia+")) as sotien";
                        sql += " from " + d.user + mmyy + ".d_xuatsdll b," + d.user + mmyy + ".d_xuatsdct c," + d.user + ".d_duockp d," + d.user + ".d_loaiphieu e," + d.user + ".d_doituong f";
						sql+=" where b.id=c.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong";
						sql+=" and b.mabn='"+mabn+"' and b.maql="+maql;
						sql+=" and d.makp='"+_makp+"' and c.madoituong="+_madoituong;
						if (chksang_chieu.Checked)
						{
							if (d1>=d2) sql+=" and e.buoi=0 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy')";
							else 
							{
								sql+=" and ((e.buoi=1 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d1)+"','dd/mm/yy'))";
								sql+=" or (e.buoi=0 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy')))";
							}
						}
						else sql+=" and to_date(b.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",d1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy')";
						sql+=" and b.loai<>3";
						tmp=d.get_data(sql).Tables[0];
						if (tmp.Rows[0]["sotien"].ToString()!="") st+=decimal.Parse(tmp.Rows[0]["sotien"].ToString());
						//hoantra
						sql="select sum(round(c.soluong*decode(f.loai,0,c.giamua,c.giaban),"+i_dongia+")) as sotien";
                        sql += " from " + d.user + mmyy + ".d_xuatsdll b," + d.user + mmyy + ".d_xuatsdct c," + d.user + ".d_duockp d," + d.user + ".d_loaiphieu e," + d.user + ".d_doituong f";
						sql+=" where b.id=c.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong";
						sql+=" and b.mabn='"+mabn+"' and b.maql="+maql;
						sql+=" and d.makp='"+_makp+"' and c.madoituong="+_madoituong;
						if (chksang_chieu.Checked)
						{
							if (d1>=d2)	sql+=" and e.buoi=0 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy')";
							else 
							{
								sql+=" and ((e.buoi=1 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d1)+"','dd/mm/yy'))";
								sql+=" or (e.buoi=0 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy')))";
							}
						}
						else sql+=" and to_date(b.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",d1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy')";
						sql+=" and b.loai=3";
						tmp=d.get_data(sql).Tables[0];
						if (tmp.Rows[0]["sotien"].ToString()!="") st-=decimal.Parse(tmp.Rows[0]["sotien"].ToString());
					}
				}
			}
			return tung-st;
		}

		private void get_data()
		{
			Cursor=Cursors.WaitCursor; 
			ds.Clear();
			dsphong.Clear();
			s_madoituong="";
			if (madoituong.SelectedItems.Count>0)
				for(int i=0;i<madoituong.Items.Count;i++)
					if (madoituong.GetItemChecked(i)) s_madoituong+=dt.Rows[i]["madoituong"].ToString().Trim()+",";
			s_makp="";
			if (makp.SelectedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++)
					if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+",";
			s_mabn="";
			foreach(DataRow r in dsmabn.Tables[0].Select("chon=true","mabn")) s_mabn+="'"+r["mabn"].ToString().Trim()+"',";
			DateTime d1=d.StringToDate(tu.Text).AddDays(-1);
			DateTime d2=d.StringToDate(den.Text);
			DateTime d3=d.StringToDate(tu.Text);
			DateTime d4=d.StringToDate(den.Text).AddDays(-1);
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="",yy="";
			//
			sql="select distinct b.mabn,c.phong,c.giuong from d_duyet a,d_dutrull b,d_dausinhton c,d_duockp d";
			sql+=" where a.id=b.idduyet and b.id=c.id and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"','dd/mm/yy')";
			sql+=" and (c.phong is not null or c.giuong is not null)";
			sql+=" union all ";
			sql+="select distinct b.mabn,c.phong,c.giuong from d_duyet a,d_xtutrucll b,d_dausinhton c,d_duockp d";
			sql+=" where a.id=b.idduyet and b.id=c.id and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"','dd/mm/yy')";
			sql+=" and (c.phong is not null or c.giuong is not null)";
			dsphong.Merge(m.get_data(sql));
			//
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				yy=i.ToString().Substring(2,2);
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+yy;
					if (d.bMmyy(mmyy))
					{
						sql="select ";
						if (chklist.Checked) sql+="c.mabd as ma,to_char(b.ngay,'dd/mm/yyyy') as ngay,";
						sql+="d.makp,a.mabn,a.hoten,c.madoituong,b.maql,to_char(g.ngay,'dd/mm/yyyy') as ngayvao,decode(f.loai,0,c.giamua,c.giaban) as dongia,sum(c.soluong) as soluong,sum(round(c.soluong*decode(f.loai,0,c.giamua,c.giaban),"+i_dongia+")) as sotien";
                        sql += " from " + d.user + ".btdbn a," + d.user + mmyy + ".d_xuatsdll b," + d.user + mmyy + ".d_xuatsdct c," + d.user + ".d_duockp d," + d.user + ".d_loaiphieu e," + d.user + ".d_doituong f," + d.user + ".benhandt g";
						sql+=" where a.mabn=b.mabn and b.id=c.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong and b.maql=g.maql";
						if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
						if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
						if (s_madoituong!="") sql+=" and c.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
						if (chksang_chieu.Checked)
						{
							sql+=" and ((e.buoi=1 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d1)+"','dd/mm/yy'))";
							sql+=" or (e.buoi=0 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy'))";
							if (tu.Text!=den.Text) sql+=" or (to_date(b.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",d3)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",d4)+"','dd/mm/yy'))";
							sql+=")";
						}
						else sql+=" and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
						sql+=" and b.loai<>3";
						sql+=" group by ";
						if (chklist.Checked) sql+="c.mabd,to_char(b.ngay,'dd/mm/yyyy'),";
						sql+="d.makp,a.mabn,a.hoten,c.madoituong,b.maql,to_char(g.ngay,'dd/mm/yyyy'),decode(f.loai,0,c.giamua,c.giaban)";
						get_chiphi(d.get_data(sql).Tables[0],"thuoc");
						//hoantra
						sql="select ";
						if (chklist.Checked) sql+="c.mabd as ma,to_char(b.ngay,'dd/mm/yyyy') as ngay,";
						sql+="d.makp,a.mabn,a.hoten,c.madoituong,b.maql,to_char(g.ngay,'dd/mm/yyyy') as ngayvao,decode(f.loai,0,c.giamua,c.giaban) as dongia,-sum(c.soluong) as soluong,-sum(round(c.soluong*decode(f.loai,0,c.giamua,c.giaban),"+i_dongia+")) as sotien";
                        sql += " from " + d.user + ".btdbn a," + d.user + mmyy + ".d_xuatsdll b," + d.user + mmyy + ".d_xuatsdct c," + d.user + ".d_duockp d," + d.user + ".d_loaiphieu e," + d.user + ".d_doituong f," + d.user + ".benhandt g";
						sql+=" where a.mabn=b.mabn and b.id=c.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong and b.maql=g.maql";
						if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
						if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
						if (s_madoituong!="") sql+=" and c.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
						if (chksang_chieu.Checked)
						{
							sql+=" and ((e.buoi=1 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d1)+"','dd/mm/yy'))";
							sql+=" or (e.buoi=0 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy'))";
							if (tu.Text!=den.Text) sql+=" or (to_date(b.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",d3)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",d4)+"','dd/mm/yy'))";
							sql+=")";
						}
						else sql+=" and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
						sql+=" and b.loai=3";
						sql+=" group by ";
						if (chklist.Checked) sql+="c.mabd,to_char(b.ngay,'dd/mm/yyyy'),";
						sql+="d.makp,a.mabn,a.hoten,c.madoituong,b.maql,to_char(g.ngay,'dd/mm/yyyy'),decode(f.loai,0,c.giamua,c.giaban)";
						get_chiphi(d.get_data(sql).Tables[0],"thuoc");
					}
				}
			}
			decimal tc=0;
			decimal id=0;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				if (chklist.Checked) id=v.get_id_thngay(tu.Text.Substring(8,2),int.Parse(r["madoituong"].ToString()),r["mabn"].ToString(),decimal.Parse(r["maql"].ToString()),r["makp"].ToString(),tu.Text,den.Text,false);
				else id=0;
				r["tamung"]=get_conlai(id,r["mabn"].ToString(),decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["makp"].ToString(),int.Parse(r["madoituong"].ToString()));
				tc=decimal.Parse(r["thuoc"].ToString())+decimal.Parse(r["vienphi"].ToString());
				v.execute_data("update v_thngayll set conlai=round("+decimal.Parse(r["tamung"].ToString())+","+i_sotien_le+"),sotien=round("+tc+","+i_sotien_le+") where mabn='"+r["mabn"].ToString()+"' and maql="+decimal.Parse(r["maql"].ToString())+" and madoituong="+int.Parse(r["madoituong"].ToString())+" and makp='"+r["makp"].ToString()+"' and to_char(tu,'dd/mm/yyyy')='"+tu.Text+"' and to_char(den,'dd/mm/yyyy')='"+den.Text+"'");
			}
			dsxml.Clear();
			dsxml.Merge(ds.Tables[0].Select("true","makp,madoituong,mabn"));
			Cursor=Cursors.Default;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			get_data();
			string title=(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày :"+tu.Text+" đến :"+den.Text;
			if (dsxml.Tables[0].Rows.Count>0)
			{
				if (chkXem.Checked)
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,title,"d_ttngay.rpt");
					f.ShowDialog();
				}
				else print.Printer(m,dsxml,"d_ttngay.rpt",title,1,Convert.ToInt16(soban.Value));
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butList_Click(object sender, System.EventArgs e)
		{
			frmKhoain f=new frmKhoain(tu.Text);
			f.ShowDialog(this);
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
			s_makp="";
			if (makp.SelectedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++)
					if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+",";
			//
			sql="select distinct b.mabn,c.hoten from d_duyet a,d_dutrull b,btdbn c,d_duockp d";
			sql+=" where a.id=b.idduyet and b.mabn=c.mabn and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"','dd/mm/yy')";
			sql+=" union all ";
			sql+="select distinct b.mabn,c.hoten from d_duyet a,d_xtutrucll b,btdbn c,d_duockp d";
			sql+=" where a.id=b.idduyet and b.mabn=c.mabn and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"','dd/mm/yy')";
			sql+=" union all ";
			sql+="select distinct b.mabn,c.hoten from d_duyet a,d_hoantrall b,btdbn c,d_duockp d";
			sql+=" where a.id=b.idduyet and b.mabn=c.mabn and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"','dd/mm/yy')";
			dsmabn.Clear();
			DataRow r1,r2;
			foreach(DataRow r in m.get_data(sql).Tables[0].Select("true","mabn"))
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

		private void butBK_Click(object sender, System.EventArgs e)
		{
			get_data_bke();	
			string title=(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày :"+tu.Text+" đến :"+den.Text;
			if (dsxmlbke.Tables[0].Rows.Count>0)
			{
				if (chkXem.Checked)
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,dsxmlbke,title,"d_bkengay.rpt");
					f.ShowDialog();
				}
				else print.Printer(m,dsxmlbke,"d_bkengay.rpt",title,1,Convert.ToInt16(soban.Value));
			}
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
		}

		private void get_data_bke()
		{
			Cursor=Cursors.WaitCursor; 
			dsbke.Clear();
			dsphong.Clear();
			s_madoituong="";
			if (madoituong.SelectedItems.Count>0)
				for(int i=0;i<madoituong.Items.Count;i++)
					if (madoituong.GetItemChecked(i)) s_madoituong+=dt.Rows[i]["madoituong"].ToString().Trim()+",";
			s_makp="";
			if (makp.SelectedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++)
					if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+",";
			s_mabn="";
			foreach(DataRow r in dsmabn.Tables[0].Select("chon=true","mabn")) s_mabn+="'"+r["mabn"].ToString().Trim()+"',";
			DateTime d1=d.StringToDate(tu.Text).AddDays(-1);
			DateTime d2=d.StringToDate(den.Text);
			DateTime d3=d.StringToDate(tu.Text);
			DateTime d4=d.StringToDate(den.Text).AddDays(-1);
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="",yy="";
			//
			sql="select distinct b.mabn,c.phong,c.giuong from d_duyet a,d_dutrull b,d_dausinhton c,d_duockp d";
			sql+=" where a.id=b.idduyet and b.id=c.id and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"','dd/mm/yy')";
			sql+=" and (c.phong is not null or c.giuong is not null)";
			sql+=" union all ";
			sql+="select distinct b.mabn,c.phong,c.giuong from d_duyet a,d_xtutrucll b,d_dausinhton c,d_duockp d";
			sql+=" where a.id=b.idduyet and b.id=c.id and a.makhoa=d.id";
			if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",dt1)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",dt2)+"','dd/mm/yy')";
			sql+=" and (c.phong is not null or c.giuong is not null)";
			dsphong.Merge(m.get_data(sql));
			//
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				yy=i.ToString().Substring(2,2);
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+yy;
					if (d.bMmyy(mmyy))
					{
						sql="select ";
						sql+="c.mabd as ma,to_char(b.ngay,'dd/mm/yyyy') as ngay,";
						sql+="d.makp,a.mabn,c.madoituong,b.maql,to_char(g.ngay,'dd/mm/yyyy') as ngayvao,decode(f.loai,0,c.giamua,c.giaban) as dongia,sum(c.soluong) as soluong,sum(round(c.soluong*decode(f.loai,0,c.giamua,c.giaban),"+i_dongia+")) as sotien";
                        sql += " from " + d.user + ".btdbn a," + d.user + mmyy + ".d_xuatsdll b," + d.user + mmyy + ".d_xuatsdct c," + d.user + ".d_duockp d," + d.user + ".d_loaiphieu e," + d.user + ".d_doituong f," + d.user + ".benhandt g";
						sql+=" where a.mabn=b.mabn and b.id=c.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong and b.maql=g.maql";
						if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
						if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
						if (s_madoituong!="") sql+=" and c.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
						if (chksang_chieu.Checked)
						{
							sql+=" and ((e.buoi=1 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d1)+"','dd/mm/yy'))";
							sql+=" or (e.buoi=0 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy'))";
							if (tu.Text!=den.Text) sql+=" or (to_date(b.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",d3)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",d4)+"','dd/mm/yy'))";
							sql+=")";
						}
						else sql+=" and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
						sql+=" and b.loai<>3";
						sql+=" group by ";
						sql+="c.mabd,to_char(b.ngay,'dd/mm/yyyy'),";
						sql+="d.makp,a.mabn,c.madoituong,b.maql,to_char(g.ngay,'dd/mm/yyyy'),decode(f.loai,0,c.giamua,c.giaban)";
						get_chiphi_bke(d.get_data(sql).Tables[0]);
						//hoantra
						sql="select ";
						sql+="c.mabd as ma,to_char(b.ngay,'dd/mm/yyyy') as ngay,";
						sql+="d.makp,a.mabn,c.madoituong,b.maql,to_char(g.ngay,'dd/mm/yyyy') as ngayvao,decode(f.loai,0,c.giamua,c.giaban) as dongia,-sum(c.soluong) as soluong,-sum(round(c.soluong*decode(f.loai,0,c.giamua,c.giaban),"+i_dongia+")) as sotien";
                        sql += " from " + d.user + ".btdbn a," + d.user + mmyy + ".d_xuatsdll b," + d.user + mmyy + ".d_xuatsdct c," + d.user + ".d_duockp d," + d.user + ".d_loaiphieu e," + d.user + ".d_doituong f," + d.user + ".benhandt g";
						sql+=" where a.mabn=b.mabn and b.id=c.id and b.makhoa=d.id and b.phieu=e.id and c.madoituong=f.madoituong and b.maql=g.maql";
						if (s_makp!="") sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
						if (s_mabn!="") sql+=" and b.mabn in ("+s_mabn.Substring(0,s_mabn.Length-1)+")";
						if (s_madoituong!="") sql+=" and c.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
						if (chksang_chieu.Checked)
						{
							sql+=" and ((e.buoi=1 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d1)+"','dd/mm/yy'))";
							sql+=" or (e.buoi=0 and to_date(b.ngay,'dd/mm/yy')=to_date('"+m.DateToString("dd/MM/yyyy",d2)+"','dd/mm/yy'))";
							if (tu.Text!=den.Text) sql+=" or (to_date(b.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",d3)+"','dd/mm/yy') and to_date('"+m.DateToString("dd/MM/yyyy",d4)+"','dd/mm/yy'))";
							sql+=")";
						}
						else sql+=" and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
						sql+=" and b.loai=3";
						sql+=" group by ";
						sql+="c.mabd,to_char(b.ngay,'dd/mm/yyyy'),";
						sql+="d.makp,a.mabn,c.madoituong,b.maql,to_char(g.ngay,'dd/mm/yyyy'),decode(f.loai,0,c.giamua,c.giaban)";
						get_chiphi_bke(d.get_data(sql).Tables[0]);
					}
				}
			}
			DataRow r1;
			foreach(DataRow r in dsbke.Tables[0].Select("true","makp,madoituong,mabn,maql"))
			{
				r1=m.getrowbyid(dsbke.Tables[0],"tamung<>0 and makp='"+r["makp"].ToString()+"' and mabn='"+r["mabn"].ToString()+"' and maql="+decimal.Parse(r["maql"].ToString())+" and madoituong="+int.Parse(r["madoituong"].ToString()));
				if (r1!=null) r["tamung"]=r1["tamung"].ToString();
				else r["tamung"]=get_conlai(0,r["mabn"].ToString(),decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["makp"].ToString(),int.Parse(r["madoituong"].ToString()));
			}
			dsxmlbke.Clear();
			dsxmlbke.Merge(dsbke.Tables[0].Select("true","makp,madoituong,mabn,ngay,sttnhom,ten"));
			Cursor=Cursors.Default;
		}

		private DataTable get_hoten(string mabn)
		{
			sql="select a.hoten,a.namsinh,trim(a.sonha)||' '||trim(a.thon)||' '||trim(d.tenpxa)||','||trim(c.tenquan)||','||trim(b.tentt) as diachi";
			sql+=" from btdbn a,btdtt b,btdquan c,btdpxa d where a.matt=b.matt and a.maqu=c.maqu and a.maphuongxa=d.maphuongxa and a.mabn='"+mabn+"'";
			return m.get_data(sql).Tables[0];
		}

		private void get_chiphi_bke(DataTable tmp)
		{
			DataRow r1,r2,r3,r4,r5,r6,r7;
			DataRow [] dr;
			DataTable tmabn;
			foreach(DataRow r in tmp.Select("true","makp,madoituong,mabn,maql,ngayvao"))
			{
				sql="makp='"+r["makp"].ToString()+"' and madoituong="+int.Parse(r["madoituong"].ToString())+" and mabn='"+r["mabn"].ToString()+"' and maql="+decimal.Parse(r["maql"].ToString());
				sql+=" and ngay='"+r["ngay"].ToString()+"'";
				sql+=" and ma="+int.Parse(r["ma"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
				r1=m.getrowbyid(dsbke.Tables[0],sql);
				if (r1==null)
				{
					r3=m.getrowbyid(dt,"madoituong="+int.Parse(r["madoituong"].ToString()));
					r4=m.getrowbyid(dtkp,"makp='"+r["makp"].ToString()+"'");
					r6=m.getrowbyid(dtdm,"id="+int.Parse(r["ma"].ToString()));
					if (r3!=null && r4!=null && r6!=null)
					{
						r2=dsbke.Tables[0].NewRow();
						r2["makp"]=r["makp"].ToString();
						r2["tenkp"]=r4["tenkp"].ToString();
						r2["madoituong"]=r["madoituong"].ToString();
						r2["doituong"]=r3["doituong"].ToString();
						r2["mabn"]=r["mabn"].ToString();
						r2["maql"]=r["maql"].ToString();
						r2["ma"]=r["ma"].ToString();
						r2["ten"]=r6["ten"].ToString();
						r2["dvt"]=r6["dvt"].ToString();
						r2["sttnhom"]=r6["sttnhom"].ToString();
						r2["nhom"]=r6["tennhom"].ToString();
						r2["ngayvao"]=r["ngayvao"].ToString();
						r2["denngay"]=tu.Text;
						r2["ngayra"]=den.Text;
						r7=m.getrowbyid(dsbke.Tables[0],"mabn='"+r["mabn"].ToString()+"'");
						if (r7!=null)
						{
							r2["hoten"]=r7["hoten"].ToString();
							r2["namsinh"]=r7["namsinh"].ToString();
							r2["diachi"]=r7["diachi"].ToString();
						}
						else
						{
							tmabn=get_hoten(r["mabn"].ToString());
							if (tmabn.Rows.Count>0)
							{
								r2["hoten"]=tmabn.Rows[0]["hoten"].ToString();
								r2["namsinh"]=tmabn.Rows[0]["namsinh"].ToString();
								r2["diachi"]=tmabn.Rows[0]["diachi"].ToString();
							}
						}	
						r2["tamung"]=0;
						r2["ngay"]=r["ngay"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						r5=m.getrowbyid(dsphong.Tables[0],"mabn='"+r["mabn"].ToString()+"'");
						if (r5!=null) r2["giuong"]=r5["giuong"].ToString();
						dsbke.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr=dsbke.Tables[0].Select(sql);
					if (dr.Length>0)
					{
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
					}
				}
			}
		}

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }
	}
}
