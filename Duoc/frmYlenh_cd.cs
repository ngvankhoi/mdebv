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

namespace Duoc
{
	/// <summary>
	/// Summary description for frmYlenh.
	/// </summary>
	public class frmYlenh_cd : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		string s_buoi="",s_tenphieu="",s_kho="";
		private int i_makp=-1, i_loai=0,i_phieu=0,i_nhom=0;
        private bool bIntheoSLDuyet = true;
        private string s_field_soluong = "slyeucau";
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
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private string user,f_ngay,s_makp="",sql,s_makho,s_loai,cont,s_phieu,sql1,tenfile;
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
		private System.Windows.Forms.CheckBox chkCachdung;
		private System.Windows.Forms.GroupBox tt;
		private System.Windows.Forms.RadioButton tt1;
		private System.Windows.Forms.RadioButton tt2;
		private System.Windows.Forms.RadioButton tt3;
		private System.Windows.Forms.CheckBox ravien;
        private System.Windows.Forms.CheckBox chkslduyet;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmYlenh_cd(int makp,int nhom,int loai, int phieu,string kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			i_makp=makp;i_nhom=nhom;i_loai=loai;
			i_phieu=phieu;s_kho=kho;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmYlenh_cd(int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            i_nhom = nhom;
			s_makp="";
            
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
            this.tt = new System.Windows.Forms.GroupBox();
            this.tt3 = new System.Windows.Forms.RadioButton();
            this.tt2 = new System.Windows.Forms.RadioButton();
            this.tt1 = new System.Windows.Forms.RadioButton();
            this.ravien = new System.Windows.Forms.CheckBox();
            this.chkslduyet = new System.Windows.Forms.CheckBox();
            this.tt.SuspendLayout();
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
            this.label3.Location = new System.Drawing.Point(8, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Loại :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Phiếu :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 32);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 5;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // nhom
            // 
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(64, 56);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(192, 21);
            this.nhom.TabIndex = 7;
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
            this.loai.TabIndex = 8;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // phieu
            // 
            this.phieu.CheckOnClick = true;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(64, 151);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(192, 132);
            this.phieu.TabIndex = 9;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(258, 8);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(216, 244);
            this.makho.TabIndex = 10;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(196, 292);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 12;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(266, 292);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butPreview
            // 
            this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPreview.Location = new System.Drawing.Point(126, 292);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(70, 25);
            this.butPreview.TabIndex = 11;
            this.butPreview.Text = "&Xem";
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // chkCachdung
            // 
            this.chkCachdung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCachdung.Location = new System.Drawing.Point(264, 260);
            this.chkCachdung.Name = "chkCachdung";
            this.chkCachdung.Size = new System.Drawing.Size(104, 24);
            this.chkCachdung.TabIndex = 14;
            this.chkCachdung.Text = "In cách dùng";
            // 
            // tt
            // 
            this.tt.Controls.Add(this.tt3);
            this.tt.Controls.Add(this.tt2);
            this.tt.Controls.Add(this.tt1);
            this.tt.Location = new System.Drawing.Point(259, 208);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(216, 53);
            this.tt.TabIndex = 16;
            this.tt.TabStop = false;
            this.tt.Visible = false;
            // 
            // tt3
            // 
            this.tt3.Location = new System.Drawing.Point(16, 32);
            this.tt3.Name = "tt3";
            this.tt3.Size = new System.Drawing.Size(104, 16);
            this.tt3.TabIndex = 2;
            this.tt3.Text = "Tất cả";
            // 
            // tt2
            // 
            this.tt2.Location = new System.Drawing.Point(126, 8);
            this.tt2.Name = "tt2";
            this.tt2.Size = new System.Drawing.Size(64, 24);
            this.tt2.TabIndex = 1;
            this.tt2.Text = "Ra viện";
            this.tt2.Visible = false;
            // 
            // tt1
            // 
            this.tt1.Checked = true;
            this.tt1.Location = new System.Drawing.Point(16, 8);
            this.tt1.Name = "tt1";
            this.tt1.Size = new System.Drawing.Size(104, 24);
            this.tt1.TabIndex = 0;
            this.tt1.TabStop = true;
            this.tt1.Text = "Đang điều trị";
            // 
            // ravien
            // 
            this.ravien.Location = new System.Drawing.Point(370, 315);
            this.ravien.Name = "ravien";
            this.ravien.Size = new System.Drawing.Size(104, 24);
            this.ravien.TabIndex = 17;
            this.ravien.Text = "Sau ngày y lệnh";
            this.ravien.Visible = false;
            // 
            // chkslduyet
            // 
            this.chkslduyet.Checked = true;
            this.chkslduyet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkslduyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkslduyet.Location = new System.Drawing.Point(354, 263);
            this.chkslduyet.Name = "chkslduyet";
            this.chkslduyet.Size = new System.Drawing.Size(121, 21);
            this.chkslduyet.TabIndex = 29;
            this.chkslduyet.Text = "In theo SL Duyệt";
            // 
            // frmYlenh_cd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(482, 339);
            this.Controls.Add(this.chkslduyet);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.tt);
            this.Controls.Add(this.ravien);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmYlenh_cd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp y lệnh";
            this.Load += new System.EventHandler(this.frmYlenh_cd_Load);
            this.tt.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmYlenh_cd_Load(object sender, System.EventArgs e)
		{
            user = d.user; f_ngay = d.f_ngay;
			dsmabd.ReadXml("..\\..\\..\\xml\\d_mabd.xml");
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			sql="select * from "+user+".d_duockp";
			if (s_makp!="") sql+=" where makp='"+s_makp+"'";
            else sql += " where makp is not null";
            sql += " and nhom like '%" + i_nhom.ToString() + ",%'";
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
			makp.DataSource=dtmakp;
			makp.SelectedIndex=0;
			if(i_makp>=0) makp.SelectedValue=i_makp;
			else makp.SelectedIndex=0;
			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			load_nhom();
			load_makho();
			Chech_phieu();
		}

		private void load_nhom()
		{
            sql = "select * from " + user + ".d_dmnhomkho";
            sql += " where id=" + i_nhom;
			sql+=" order by stt";
			nhom.DataSource=d.get_data(sql).Tables[0];
			if(i_nhom>0)nhom.SelectedValue=i_nhom.ToString();
			load_makho();
		}

		private void load_makho()
		{
            if (nhom.SelectedIndex == -1) return;
			s_makho="";
            sql = "select * from " + user + ".d_dmkho where nhom=" + int.Parse(nhom.SelectedValue.ToString());
			if(s_kho!="")sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			r=d.getrowbyid(dtmakp,"id="+int.Parse(makp.SelectedValue.ToString()));
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
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";

            dtloai = d.get_data("select * from " + user + ".d_dmphieu where id in (1,2,3) order by stt").Tables[0];
			loai.DataSource=dtloai;
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp)
			{
				load_nhom();
			}
		}

		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nhom)
			{
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
			d.close();this.Close();
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			s_loai="";
			for(int i=0;i<loai.Items.Count;i++)
				if (loai.GetItemChecked(i)) s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
			if (s_loai!="")
			{
				s_loai=s_loai.Substring(0,s_loai.Length-1);
                dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where nhom=" + int.Parse(nhom.SelectedValue.ToString()) + " and loai in (" + s_loai + ")" + " order by stt").Tables[0];
			}
            else dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where id=-1").Tables[0];
			phieu.DataSource=dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
		}

		private void taotable()
		{
			s_makp=dtmakp.Rows[makp.SelectedIndex]["makp"].ToString();
			dsmabd.Clear();
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_ylenh_cd.xml");
            dtdmbd = d.get_data("select * from " + user + ".d_dmbd where nhom=" + int.Parse(nhom.SelectedValue.ToString())).Tables[0];
			cont=" and a.makhoa="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and a.ngay between to_date('"+tu.Text+"','"+f_ngay+"') and to_date('"+den.Text+"','"+f_ngay+"')";
			s_phieu="";
			//binh
            string s_cachdung = (chkCachdung.Checked == false) ? "to_char(c." + s_field_soluong + ",'99999999.99') as slyeucau" : "case when c." + s_field_soluong + "=0 then '' else to_char(c." + s_field_soluong + ",'999999999.99')||'..'||nullif(c.cachdung,'') end as slyeucau ";
            //string s_cachdung=(chkCachdung.Checked==false)?"to_char(c.slyeucau,'99999999.99') as slyeucau":"case when c.slyeucau=0 then '' else to_char(c.slyeucau,'999999999.99')||'..'||nullif(c.cachdung,'') end as slyeucau ";
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
                sql = "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c,"+user+".d_dmbd d where a.id=b.idduyet";
				sql+=" and b.id=c.id and c.mabd=d.id  "+cont;
				sql+=" union all ";
                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c,"+user+".d_dmbd d where a.id=b.idduyet";
				sql+=" and b.id=c.id and c.mabd=d.id  "+cont;
				sql+=" union all ";
                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c,"+user+".d_dmbd d where a.id=b.idduyet";
				sql+=" and b.id=c.id and c.mabd=d.id  "+cont;
				upd_mabd(sql);

                sql1 = "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd," + s_cachdung + " from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c,xxx.d_dausinhton d,"+user+".btdbn e where a.id=b.idduyet";
				sql1+=" and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn  "+cont;
				sql1+=" union all ";
                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd," + s_cachdung + " from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c,xxx.d_dausinhton d,"+user+".btdbn e where a.id=b.idduyet";
				sql1+=" and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn  "+cont;
				sql1+=" union all ";
                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,to_char(" + s_field_soluong + ",'9999999999.99') as slyeucau from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c,xxx.d_dausinhton d," + user + ".btdbn e where a.id=b.idduyet";
				sql1+=" and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn  "+cont;
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
                                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c,"+user+".d_dmbd d where a.id=b.idduyet";
								sql+=" and b.id=c.id and c.mabd=d.id  "+cont;
                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd," + s_cachdung + " from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c,xxx.d_dausinhton d,"+user+".btdbn e where a.id=b.idduyet";
								sql1+=" and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn  "+cont;
								break;
							case 2://bu truc
                                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c,"+user+".d_dmbd d where a.id=b.idduyet";
								sql+=" and b.id=c.id and c.mabd=d.id  "+cont;
                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd," + s_cachdung + " from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c,xxx.d_dausinhton d,"+user+".btdbn e where a.id=b.idduyet";
								sql1+=" and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn  "+cont;
								break;
							default://hoan tra																
                                sql += "select distinct c.mabd, d.manhom, d.stt from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c,"+user+".d_dmbd d where a.id=b.idduyet";
								sql+=" and b.id=c.id and c.mabd=d.id  "+cont;
                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,to_char(" + s_field_soluong + ",'999999999.99') as slyeucau from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c,xxx.d_dausinhton d," + user + ".btdbn e where a.id=b.idduyet";
								sql1+=" and b.id=c.id and b.id=d.iddutru and b.mabn=e.mabn  "+cont;
								break;
						}
					}
				}
				upd_mabd(sql);
				upd_soluong(sql1);
			}
		}

		private void upd_mabd(string sql)
		{
			DataRow r2,r3;
			DataSet ds1=d.get_thuoc(tu.Text,den.Text,sql);
			int i_stt =0;
			foreach(DataRow r1 in ds1.Tables[0].Select("true","manhom,stt "))//.Rows
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
						string s_tenbd=r2["tenhc"].ToString();
						if(s_tenbd!=r2["ten"].ToString())s_tenbd+=" ("+r2["ten"].ToString()+")";
						r3["tenbd"]=s_tenbd+" "+r2["hamluong"].ToString().Trim();//+" "+r2["dang"].ToString()+" - "+i_stt;
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
			ds1.Dispose();
		}

		private void upd_soluong(string sql)
		{
			DataRow r2;
			DataRow [] dr;
			int i_index;
			string s_slyc="",s_cachdung="";
			decimal i_slyc=0,tmp_slyc=0;
			foreach(DataRow r1 in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
			{
				//get slyeucau
				s_slyc=r1["slyeucau"].ToString();s_cachdung="";
				i_slyc=0;tmp_slyc=0;
				if (chkCachdung.Checked)
				{
					i_index=s_slyc.IndexOf("..");
					if(s_slyc!="")
					{
						if(i_index>=0)
						{
							i_slyc=decimal.Parse(s_slyc.Substring(0,i_index));
							s_cachdung=s_slyc.Substring(i_index+1);//binh
						}
						else
						{
							i_slyc=decimal.Parse(s_slyc);
							s_cachdung="";
						}
					}
					else
					{
						i_slyc=0;
						s_cachdung="";
					}
				}
				else
				{
					i_slyc=decimal.Parse(s_slyc);
					s_cachdung="";
				}
				//
				tmp_slyc=i_slyc;
				r=d.getrowbyid(ds.Tables[0],"mabn='"+r1["mabn"].ToString()+"'");
				if (r==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["stt"]=d.get_stt(ds.Tables[0]).ToString();
					r2["mabn"]=r1["mabn"].ToString();
					r2["hoten"]=r1["hoten"].ToString();
					r2["phong"]=r1["phong"].ToString();
					r2["giuong"]=r1["giuong"].ToString();
					foreach(DataRow r3 in dsmabd.Tables[0].Rows) r2["C_"+r3["mabd"].ToString().Trim()]=0;
					r2["C_"+r1["mabd"].ToString().Trim()]=r1["slyeucau"].ToString().Replace("..",";");
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr=ds.Tables[0].Select("mabn='"+r1["mabn"].ToString()+"'");
					i_index=dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString().IndexOf(";",0);
					//tmp_slyc=i_slyc;
					if(i_index>=0)
						i_slyc+=decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString().Substring(0,i_index));
					else
						i_slyc+=decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString());
					//
					if (dr!=null) dr[0]["C_"+r1["mabd"].ToString().Trim()]=i_slyc+";"+s_cachdung;// decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString())+i_slyc;//+decimal.Parse(r1["slyeucau"].ToString());		
				}
				dr=dsmabd.Tables[0].Select("mabd="+int.Parse(r1["mabd"].ToString()));
				if (dr.Length>0) dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+tmp_slyc;//+decimal.Parse(r1["slyeucau"].ToString());
			}
		}
		private void butIn_Click(object sender, System.EventArgs e)
		{
			//d.check_process_Excel();
			//Get_buoi();
			//
            bIntheoSLDuyet = chkslduyet.Checked;
            s_field_soluong = (bIntheoSLDuyet) ? "slthuc" : "slyeucau";
			taotable();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
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
			//Get_buoi();
			taotable();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
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
				int be=3,cot=ds.Tables[0].Columns.Count,dong=ds.Tables[0].Rows.Count+be+2;
				tenfile=d.Export_Excel(ds,"ylenh");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
				for(int i=0;i<5;i++) osheet.Cells[be+1,i+1]=get_ten(i);
				DataRow [] dr=dsmabd.Tables[0].Select("true","stt");//"tenbd";
				for(int i=0;i<dr.Length;i++)
				{
					osheet.Cells[be+1,i+6]=dr[i]["tenbd"].ToString();
					osheet.Cells[dong,i+6]=dr[i]["soluong"].ToString();
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
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(cot)+dong.ToString()).Borders.LineStyle=XlLineStyle.xlDot;// XlBorderWeight.xlThin;				
				orange.EntireColumn.AutoFit();								
				//cot hoten BN: In dam				
				orange=osheet.get_Range(d.getIndex(4)+"4",d.getIndex(4)+dong.ToString());
				orange.Font.Name="Arial";				
				orange.Font.Bold=true;								
				orange.EntireColumn.AutoFit();
				//
				string s_tt=(tt1.Checked)?tt1.Text:(tt2.Checked)?tt2.Text:"";
				osheet.get_Range(d.getIndex(4)+dong.ToString(),d.getIndex(cot-1)+dong.ToString()).Font.Bold=true;
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.Cells[1,2]=makp.Text+" "+s_tt;
				osheet.Cells[2,2]=(tu.Text==den.Text)?"Ngày "+tu.Text:"Ngày "+tu.Text+" - "+den.Text;
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
				//
				//Ten Thuoc
				orange=osheet.get_Range(d.getIndex(be+2)+"4",d.getIndex(cot-1)+"4");
				orange.VerticalAlignment=XlVAlign.xlVAlignBottom;
				orange.WrapText=false;
				orange.Orientation=90;
				orange.RowHeight = 180;
				orange.Font.Bold=true;
				orange.EntireRow.AutoFit();		
				//end binh
				osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
				osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
				osheet.PageSetup.LeftMargin=20;
				osheet.PageSetup.RightMargin=20;
				osheet.PageSetup.TopMargin=30;
				osheet.PageSetup.CenterFooter="Trang : &P/&N";
				if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
				else oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#region Binh
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
			if(i_incachdung!=1)chkCachdung.Checked=false;
		}		
		private void Chech_phieu()
		{
			for(int i=0;i<loai.Items.Count;i++)
			{
				if(dtloai.Rows[i]["id"].ToString()==i_loai.ToString())
				{
					loai.SetItemCheckState(i,CheckState.Checked);
					break;
				}				
			}
			dtphieu=d.get_data("select * from "+user+".d_loaiphieu where nhom="+int.Parse(nhom.SelectedValue.ToString())+" and loai in ("+i_loai+")"+" order by stt").Tables[0];
			phieu.DataSource=dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
			for(int i=0;i<phieu.Items.Count;i++)
			{
				if(dtphieu.Rows[i]["id"].ToString()==i_phieu.ToString())
				{
					phieu.SetItemCheckState(i,CheckState.Checked);
					break;
				}				
			}	
			for(int i=0;i<makho.Items.Count;i++)
			{				
				makho.SetItemCheckState(i,CheckState.Checked);				
			}
		}
		#endregion
	}
}
