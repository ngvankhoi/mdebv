using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
namespace Duoc
{
	/// <summary>
	/// Summary description for rptBhyt.
	/// </summary>
	public class frmtoabanle : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		//
		System.Data.DataTable dtkp=new System.Data.DataTable();
		string s_tbl_ll,s_tbl_ct;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_userid=0;
		private bool bClear=true,bUser;
		private string sql,s_kho,s_makho,s_mabs,s_tenbs,user,stime,xxx;
		private DataSet ds;
		private System.Data.DataTable dtbs=new System.Data.DataTable();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox quay;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton r1;
		private System.Windows.Forms.RadioButton r2;
		private System.Windows.Forms.RadioButton r3;
		private System.Windows.Forms.CheckBox r4;
		private System.Windows.Forms.Label lquay;
		private System.Windows.Forms.CheckedListBox mabs;
		private System.Windows.Forms.CheckBox chkbacsi;
		private	doiso.Doisototext dd=new doiso.Doisototext();
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rb3;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb4;
        private CheckBox chkXML;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmtoabanle(AccessData acc,int nhom,string kho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;
            i_userid = _userid;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtoabanle));
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.quay = new System.Windows.Forms.ComboBox();
            this.lquay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.r3 = new System.Windows.Forms.RadioButton();
            this.r2 = new System.Windows.Forms.RadioButton();
            this.r1 = new System.Windows.Forms.RadioButton();
            this.r4 = new System.Windows.Forms.CheckBox();
            this.mabs = new System.Windows.Forms.CheckedListBox();
            this.chkbacsi = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(239, 232);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(156, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(71, 52);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(209, 84);
            this.kho.TabIndex = 5;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butXem
            // 
            this.butXem.Image = global::Duoc.Properties.Resources.Print1;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(167, 232);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(72, 25);
            this.butXem.TabIndex = 8;
            this.butXem.Text = "      &In";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(71, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(200, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // quay
            // 
            this.quay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quay.Location = new System.Drawing.Point(71, 28);
            this.quay.Name = "quay";
            this.quay.Size = new System.Drawing.Size(209, 21);
            this.quay.TabIndex = 4;
            this.quay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // lquay
            // 
            this.lquay.Location = new System.Drawing.Point(-31, 28);
            this.lquay.Name = "lquay";
            this.lquay.Size = new System.Drawing.Size(104, 23);
            this.lquay.TabIndex = 15;
            this.lquay.Text = "Quầy :";
            this.lquay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb4);
            this.groupBox1.Controls.Add(this.r3);
            this.groupBox1.Controls.Add(this.r2);
            this.groupBox1.Controls.Add(this.r1);
            this.groupBox1.Location = new System.Drawing.Point(70, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 34);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rb4
            // 
            this.rb4.Location = new System.Drawing.Point(159, 11);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(59, 16);
            this.rb4.TabIndex = 3;
            this.rb4.Text = "Tất cả";
            // 
            // r3
            // 
            this.r3.Location = new System.Drawing.Point(116, 11);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(48, 16);
            this.r3.TabIndex = 2;
            this.r3.Text = "Hủy";
            this.r3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // r2
            // 
            this.r2.Location = new System.Drawing.Point(56, 11);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(64, 16);
            this.r2.TabIndex = 1;
            this.r2.Text = "Chưa in";
            this.r2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // r1
            // 
            this.r1.Checked = true;
            this.r1.Location = new System.Drawing.Point(4, 11);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(56, 16);
            this.r1.TabIndex = 0;
            this.r1.TabStop = true;
            this.r1.Text = "In toa";
            this.r1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // r4
            // 
            this.r4.Location = new System.Drawing.Point(71, 201);
            this.r4.Name = "r4";
            this.r4.Size = new System.Drawing.Size(72, 24);
            this.r4.TabIndex = 7;
            this.r4.Text = "Tổng hợp";
            this.r4.CheckedChanged += new System.EventHandler(this.r4_CheckedChanged);
            this.r4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // mabs
            // 
            this.mabs.CheckOnClick = true;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(283, 4);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(200, 212);
            this.mabs.TabIndex = 16;
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkbacsi
            // 
            this.chkbacsi.Location = new System.Drawing.Point(144, 201);
            this.chkbacsi.Name = "chkbacsi";
            this.chkbacsi.Size = new System.Drawing.Size(144, 24);
            this.chkbacsi.TabIndex = 17;
            this.chkbacsi.Text = "Tổng hợp theo bác sĩ";
            this.chkbacsi.CheckedChanged += new System.EventHandler(this.chkbacsi_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb3);
            this.groupBox2.Controls.Add(this.rb2);
            this.groupBox2.Controls.Add(this.rb1);
            this.groupBox2.Location = new System.Drawing.Point(70, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 32);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(139, 11);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(68, 16);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Hóa đơn";
            this.rb3.CheckedChanged += new System.EventHandler(this.rb3_CheckedChanged);
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(59, 11);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(85, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Ko hóa đơn";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(4, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Tất cả";
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(391, 222);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(92, 24);
            this.chkXML.TabIndex = 19;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // frmtoabanle
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(498, 279);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.chkbacsi);
            this.Controls.Add(this.r4);
            this.Controls.Add(this.quay);
            this.Controls.Add(this.lquay);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmtoabanle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toa thuốc bán lẻ";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptBhyt_MouseMove);
            this.Load += new System.EventHandler(this.frmtoabanle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmtoabanle_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			bUser=d.bXuatban_user(i_nhom);
			dt=d.get_data("select * from "+user+".d_dmbd where nhom="+i_nhom+" order by id").Tables[0];
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
			//
			lquay.Text=(bUser)?"Người nhập":"Quầy";
            sql = (bUser) ? "select * from " + user + ".d_dlogin where nhomkho=" + i_nhom + " order by id" : "select * from "+user+".d_dmloaint where nhom=" + i_nhom + " order by stt";
			quay.DataSource=d.get_data(sql).Tables[0];
            quay.DisplayMember = (bUser) ? "HOTEN" : "TEN";
            quay.ValueMember = "ID";
			quay.SelectedIndex=-1;
			//

            sql = "select * from " + user + ".dmbs order by ma";
			dtbs=d.get_data(sql).Tables[0];
            mabs.DataSource = dtbs;
			mabs.DisplayMember="HOTEN";
			mabs.ValueMember="MA";
			
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}


		private void rptBhyt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				if (bUser) quay.SelectedIndex=-1;
				bClear=false;
			}
		}		

		private void butXem_Click(object sender, System.EventArgs e)
		{			
			if(r4.Checked || chkbacsi.Checked) kiemtra_toa_th();
			else kiemtra_toa();
		}	

		private void get_dsbn_toa(string s_cond )
		{
			s_tbl_ll=(r3.Checked)?"d_huybanll":"d_ngtrull";
			s_tbl_ct=(r3.Checked)?"d_huybanct":"d_ngtruct";
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden,be=0;
			string mmyy="",dk;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
                        dk = s_cond;
                        if (rb2.Checked) dk += " and a.id not in (select id from " + xxx + ".d_bienlai)";
                        else if (rb3.Checked) dk += " and a.id in (select id from " + xxx + ".d_bienlai)";
						sql=" select (a.mabn||a.id) as key_,";
						if (rb3.Checked) sql+="trim(g.sohieu) as mabn, ";
						else sql+="'' as mabn,";
						sql+="a.hoten, a.ngay,b.soluong,b.soluong*b.giaban as sotien, 0 as dongia,b.giaban, d.ma,(d.ten||' '||d.hamluong) as ten, d.tenhc, d.hamluong, d.dang, a.sotoa, a.loai, f.ten as quaythu,h.hoten as nguoinhap,c.giamua,c.gianovat ";
                        sql += " from " + xxx + "." + s_tbl_ll + " a inner join " + xxx + "." + s_tbl_ct + " b on a.id=b.id ";
                        sql += " inner join " + xxx + ".d_theodoi c on  b.sttt=c.id ";
                        sql+=" inner join "+user+".d_dmbd d on b.mabd=d.id ";
                        sql+=" inner join "+user+".d_dmloaint f on a.loai=f.id ";
						if (rb3.Checked) sql+=" inner join "+xxx+".d_bienlai g on a.id=g.id ";
                        sql+=" left join "+user+".d_dlogin h on a.userid=h.id ";
						sql+=" where b.soluong>0  ";
						if(s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
						if(s_mabs!="") sql+=" and a.mabs in ("+s_mabs.Substring(0,s_mabs.Length-1)+")";
						if (dk!="") sql+=dk;
						sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						sql+=" and a.nhom="+i_nhom;
						if (be==0) ds=d.get_data(sql);
						else ds.Merge(d.get_data(sql));
						be++;
					}
				}
			}
		}	

		private void get_dsbn_toa_th(string s_cond )
		{
			s_tbl_ll=(r3.Checked)?"d_huybanll":"d_ngtrull";
			s_tbl_ct=(r3.Checked)?"d_huybanct":"d_ngtruct";
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden,be=0;
			string mmyy="",dk;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
                        dk = s_cond;
                        if (rb2.Checked) dk += " and a.id not in (select id from " + xxx + ".d_bienlai)";
                        else if (rb3.Checked) dk += " and a.id in (select id from " + xxx + ".d_bienlai)";
						sql=" select to_char(a.ngay,'yyyy/mm/dd') as ngay,sum(b.soluong) as soluong, sum(b.soluong*b.giaban) as sotien, 0 as dongia,b.giaban, d.ma,(d.ten||' '||d.hamluong) as ten, d.tenhc, d.hamluong, d.dang, f.ten as tenhang, f.loai as idnn, g.ten as noingoai, a.loai, h.ten as quaythu,c.giamua,c.gianovat ";//lấy thêm gia chưa thuế lên
						sql+=" from "+xxx+"."+s_tbl_ll+" a, "+xxx+"."+s_tbl_ct+" b,"+xxx+".d_theodoi c,"+user+".d_dmbd d,"+user+".d_dmhang f,"+user+".d_nhomhang g,"+user+".d_dmloaint h ";
                        sql += " where a.id=b.id and b.mabd=d.id and b.soluong>0 and d.mahang=f.id and f.loai=g.id and a.loai=h.id and  b.sttt=c.id ";
						if(s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
						if(s_mabs!="") sql+=" and a.mabs in ("+s_mabs.Substring(0,s_mabs.Length-1)+")";
						if (dk!="") sql+=dk;
                        sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
						sql+=" and a.nhom="+i_nhom;
                        sql += " group by b.mabd, b.giaban, to_char(a.ngay,'yyyy/mm/dd'),d.ma, d.ten, d.hamluong, d.tenhc, d.dang, f.ten, f.loai, g.ten, a.loai, h.ten,c.giamua,c.gianovat";
						if (be==0) ds=d.get_data(sql);
						else ds.Merge(d.get_data(sql));
						be++;
					}
				}
			}
		}
		private void kiemtra_toa()
		{			
			string s_cond="";
			if(quay.SelectedIndex>=0)
			{
				if (bUser) s_cond+=" and a.userid="+quay.SelectedValue.ToString();
				else s_cond+=" and a.loai="+quay.SelectedValue.ToString();
			}
			if (r1.Checked) s_cond+=" and a.done=1";
			else if (r2.Checked) s_cond+=" and a.done=0";
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			string s_rpt="d_pxtoa_bl_ct.rpt";
			if (rb3.Checked) s_rpt="d_pxtoa_bl_hd.rpt";
			if (r2.Checked) s_title=" Số toa thuốc chưa in "+s_title;
			else if(r3.Checked)s_title=" Danh sách toa hủy "+s_title;
			//
			s_kho="";
			if (kho.CheckedItems.Count>0) 
				for(int i=0;i<kho.Items.Count;i++)	if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
			s_mabs="";
			if (mabs.CheckedItems.Count>0) 
				for(int i=0;i<mabs.Items.Count;i++)	if (mabs.GetItemChecked(i)) s_mabs+=dtbs.Rows[i]["ma"].ToString()+",";

			get_dsbn_toa(s_cond);
			//
			if(ds.Tables[0].Rows.Count<=0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			else
			{
				doiso.Doisototext dd=new doiso.Doisototext();				
				decimal tc=0;
				foreach(DataRow r in ds.Tables[0].Select("sotien>0")) tc+=decimal.Parse(r["sotien"].ToString());
				DataSet tmp=ds.Copy();
				if (rb3.Checked) 
				{
					tmp.Clear();
					tmp.Merge(ds.Tables[0].Select("true","mabn,ma"));
				}
                if (chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                    tmp.WriteXml("..\\xml\\banle.xml", XmlWriteMode.WriteSchema);
                }
				frmReport f=new frmReport(d,tmp.Tables[0], i_userid,s_rpt,"",s_title,kho.Text,"","","",kho.Text,"","",dd.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
				f.ShowDialog();				
			}
		}
				
		private void kiemtra_toa_th()
		{			
			string s_cond="";
			if(quay.SelectedIndex>=0)s_cond+=" and a.loai="+quay.SelectedValue.ToString();
			if (r1.Checked) s_cond+=" and a.done=1";
			else if (r2.Checked) s_cond+=" and a.done=0";
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			string s_rpt="d_pxtoa_bl.rpt";
			if (r2.Checked) s_title="Số toa thuốc chưa in "+s_title;
			else if(r3.Checked) s_title="Số thuốc thuộc các toa đã hủy "+s_title;
			//
			s_kho="";
			if (kho.CheckedItems.Count>0) 
				for(int i=0;i<kho.Items.Count;i++)	if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
			s_mabs="";s_tenbs="";
			if (mabs.CheckedItems.Count>0) 
				for(int i=0;i<mabs.Items.Count;i++)	
					if (mabs.GetItemChecked(i))
					{
						s_mabs+=dtbs.Rows[i]["ma"].ToString()+",";
						s_tenbs+=dtbs.Rows[i]["hoten"].ToString()+";";
					}
			get_dsbn_toa_th(s_cond);
			//
			if(ds.Tables[0].Rows.Count<=0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			else
			{
				if (r4.Checked)
				{
					decimal tc=0;
					foreach(DataRow r in ds.Tables[0].Select("sotien>0")) tc+=decimal.Parse(r["sotien"].ToString());
					//tong hop theo tien
					if (!bUser)
					{
						s_rpt="d_pxtoa_bl_th.rpt";
						frmReport f=new frmReport(d,ds.Tables[0],i_userid,s_rpt,"",s_title,kho.Text,"","","",kho.Text,"","",dd.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
						f.ShowDialog();				
					}
					//tong hop theo thuoc
					s_rpt="d_pxtoa_bl.rpt";
					frmReport f1=new frmReport(d,ds.Tables[0], i_userid,s_rpt,"",s_title,kho.Text,"","","",kho.Text,"","",dd.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
					f1.ShowDialog();				
				}
				else
				{
					decimal tc=0;
					DataSet dsxml=new DataSet();
					dsxml=ds.Copy();
					dsxml.Clear();
					DataRow r5,r6;
					DataRow [] dr;
					foreach(DataRow r in ds.Tables[0].Select("soluong>0","ma"))
					{
						sql="ma='"+r["ma"].ToString()+"' and giaban="+decimal.Parse(r["giaban"].ToString());
						r5=d.getrowbyid(dsxml.Tables[0],sql);
						if (r5==null)
						{
							r6=dsxml.Tables[0].NewRow();
							r6["ma"]=r["ma"].ToString();
							r6["ten"]=r["ten"].ToString();
							r6["hamluong"]=r["hamluong"].ToString();
							r6["dang"]=r["dang"].ToString();
							r6["tenhang"]=r["tenhang"].ToString();
							r6["soluong"]=r["soluong"].ToString();
							r6["giaban"]=r["giaban"].ToString();
							r6["sotien"]=r["sotien"].ToString();
							dsxml.Tables[0].Rows.Add(r6);
						}
						else
						{
							dr=dsxml.Tables[0].Select(sql);
							if (dr.Length>0) dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
						}
						tc+=decimal.Parse(r["soluong"].ToString())*decimal.Parse(r["giaban"].ToString());
					}
					frmReport f1=new frmReport(d,dsxml.Tables[0], i_userid ,"d_bacsi_thuoc.rpt",s_tenbs,s_title,kho.Text,"","","",kho.Text,"","",dd.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
					f1.ShowDialog();	
				}
			}
		}

		private void r4_CheckedChanged(object sender, System.EventArgs e)
		{
			if (r4.Checked && chkbacsi.Checked) chkbacsi.Checked=false;
		}

		private void chkbacsi_CheckedChanged(object sender, System.EventArgs e)
		{
			if (r4.Checked && chkbacsi.Checked) r4.Checked=false;
		}

		private void rb3_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rb3.Checked) rb4.Checked=true;
		}				
	}
}
