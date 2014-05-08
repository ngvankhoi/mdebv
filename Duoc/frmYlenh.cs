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
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckedListBox makho;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private string user,f_ngay,s_makp="",sql,s_makho,s_loai,cont,s_phieu,sql1,tenfile;
        private bool bIntheoSLDuyet = true;
        private string s_field_soluong = "slyeucau";
        private int i_nhom;
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
        private System.Windows.Forms.CheckBox chkslduyet;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmYlenh(int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            i_nhom = nhom;
            
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
            this.label7 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butPreview = new System.Windows.Forms.Button();
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
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến ngày :";
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
            this.den.Location = new System.Drawing.Point(200, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.Validated += new System.EventHandler(this.den_Validated);
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Loại :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 149);
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
            this.makp.Location = new System.Drawing.Point(64, 31);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(216, 21);
            this.makp.TabIndex = 5;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // nhom
            // 
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(64, 54);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(216, 21);
            this.nhom.TabIndex = 7;
            this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // loai
            // 
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(64, 77);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(216, 68);
            this.loai.TabIndex = 8;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // phieu
            // 
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(64, 147);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(216, 68);
            this.phieu.TabIndex = 9;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Kho :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(64, 216);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(216, 68);
            this.makho.TabIndex = 10;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(115, 325);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 12;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(185, 325);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butPreview
            // 
            this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPreview.Location = new System.Drawing.Point(45, 325);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(70, 25);
            this.butPreview.TabIndex = 11;
            this.butPreview.Text = "&Xem";
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // chkslduyet
            // 
            this.chkslduyet.Checked = true;
            this.chkslduyet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkslduyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkslduyet.Location = new System.Drawing.Point(64, 290);
            this.chkslduyet.Name = "chkslduyet";
            this.chkslduyet.Size = new System.Drawing.Size(121, 21);
            this.chkslduyet.TabIndex = 28;
            this.chkslduyet.Text = "In theo SL Duyệt";
            // 
            // frmYlenh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(290, 370);
            this.Controls.Add(this.chkslduyet);
            this.Controls.Add(this.butPreview);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label7);
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
            this.ResumeLayout(false);

		}
		#endregion

		private void frmYlenh_Load(object sender, System.EventArgs e)
		{
            user = d.user; f_ngay = d.f_ngay;
			dsmabd.ReadXml("..\\..\\..\\xml\\d_mabd.xml");
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			sql="select * from "+user+".d_duockp";
			if (s_makp!="") sql+=" where makp='"+s_makp+"'";
			else sql+=" where makp is not null";
            sql += " and nhom like '%" + i_nhom.ToString() + ",%'";
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
			makp.DataSource=dtmakp;
			makp.SelectedIndex=0;

			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			load_nhom();
			load_makho();
		}

		private void load_nhom()
		{
			sql="select * from "+user+".d_dmnhomkho";
            sql += " where id=" + i_nhom;
			sql+=" order by stt";
			nhom.DataSource=d.get_data(sql).Tables[0];
			load_makho();
		}

		private void load_makho()
		{
			s_makho="";
            sql = "select * from " + user + ".d_dmkho where nhom=" + int.Parse(nhom.SelectedValue.ToString());
			r=d.getrowbyid(dtmakp,"id="+int.Parse(makp.SelectedValue.ToString()));
			if (r!=null) s_makho=r["makho"].ToString();
			if (s_makho=="") 
			{
                foreach (DataRow r1 in d.get_data("select kho from " + user + ".d_dmphieu where nhom=" + int.Parse(nhom.SelectedValue.ToString())).Tables[0].Rows)
					s_makho+=r1["kho"].ToString();
			}
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
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
                sql = "select * from " + user + ".d_loaiphieu where loai in (" + s_loai + ")";
                if (nhom.SelectedIndex != -1) sql += " and nhom=" + int.Parse(nhom.SelectedValue.ToString());
                sql+=" order by stt";
                dtphieu = d.get_data(sql).Tables[0];
			}
            else dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where id=-1").Tables[0];
			phieu.DataSource=dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
		}

		private void taotable()
		{
			dsmabd.Clear();
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_ylenh.xml");
            ds.Tables[0].Columns.Add("ngaysinh");//khuyen 14/01/14
            ds.Tables[0].Columns.Add("DOITUONG");//khuyen 07/03/14
            dtdmbd = d.get_data("select * from " + user + ".d_dmbd where nhom=" + int.Parse(nhom.SelectedValue.ToString())).Tables[0];
			cont=" and a.makhoa="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and a.ngay between to_date('"+tu.Text+"','"+f_ngay+"') and to_date('"+den.Text+"','"+f_ngay+"')";
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
			if (s_loai=="")
			{
                sql = "select distinct c.mabd from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c where a.id=b.idduyet";
				sql+=" and b.id=c.id "+cont;
				sql+=" union all ";
                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c where a.id=b.idduyet";
				sql+=" and b.id=c.id "+cont;
				sql+=" union all ";
                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c where a.id=b.idduyet";
				sql+=" and b.id=c.id "+cont;
				upd_mabd(sql);
                //khuyen khoa 14/01/14
                //sql1 = "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c."+s_field_soluong +"  as slyeucau from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join xxx.d_dutruct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn where ";
                //sql1+=" 1=1 "+cont;
                //sql1+=" union all ";
                //sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c."+s_field_soluong +" as slyeucau from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join xxx.d_xtutrucct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn where ";
                //sql1+=" 1=1 "+cont;
                //sql1+=" union all ";
                //sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c."+s_field_soluong +" as slyeucau from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet inner join xxx.d_hoantract c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn where ";
                //sql1+=" 1=1 "+cont;
                //khuyen 14/01/14 them case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh
                sql1 = "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join xxx.d_dutruct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".doituong f on c.madoituong=f.madoituong where ";//khuyen 07/03/14 lay cot doituong
                sql1 += " 1=1 " + cont;
                sql1 += " union all ";
                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join xxx.d_xtutrucct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".doituong f on c.madoituong=f.madoituong where ";//khuyen 07/03/14 lay cot doituong
                sql1 += " 1=1 " + cont;
                sql1 += " union all ";
                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet inner join xxx.d_hoantract c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".doituong f on c.madoituong=f.madoituong where ";//khuyen 07/03/14 lay cot doituong
                sql1 += " 1=1 " + cont;
                //
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
							case 1:
                                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_dutrull b,xxx.d_dutruct c where a.id=b.idduyet";
								sql+=" and b.id=c.id "+cont;
                                //khuyen khoa 14/01/14
                                //sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c."+s_field_soluong +"  as slyeucau from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join xxx.d_dutruct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn where ";
                                //sql1+=" 1=1 "+cont;
                                //khuyen 14/01/14 them case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh

                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join xxx.d_dutruct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".doituong f on c.madoituong=f.madoituong where ";
                                sql1 += " 1=1 " + cont;
                                //
								break;
							case 2:
                                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_xtutrucll b,xxx.d_xtutrucct c where a.id=b.idduyet";
								sql+=" and b.id=c.id "+cont;
                                //khuyen khoa 14/01/14
                                //sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c."+s_field_soluong +" as slyeucau from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join xxx.d_xtutrucct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn where ";
                                //sql1+=" 1=1 "+cont;
                                //khuyen 14/01/14 them case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh

                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join xxx.d_xtutrucct c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".doituong f on c.madoituong=f.madoituong where ";
                                sql1 += " 1=1 " + cont;
                                //
								break;
							default:
                                sql += "select distinct c.mabd from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c where a.id=b.idduyet";
								sql+=" and b.id=c.id "+cont;
                                //khuyen khoa 14/01/14
                                //sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c."+s_field_soluong +"  as slyeucau from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet inner join xxx.d_hoantract c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn where ";
                                //sql1+=" 1=1 "+cont;
                                //khuyen 14/01/14 them case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh

                                sql1 += "select b.mabn,e.hoten,d.phong,d.giuong,c.mabd,c." + s_field_soluong + " as slyeucau,case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,f.doituong from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet inner join xxx.d_hoantract c on b.id=c.id left join xxx.d_dausinhton d on b.id=d.iddutru inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".doituong f on c.madoituong=f.madoituong where ";
                                sql1 += " 1=1 " + cont;
                                //
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
			foreach(DataRow r1 in dsmabd.Tables[0].Rows)
			{
				dc=new DataColumn();
				dc.ColumnName="C_"+r1["mabd"].ToString().Trim();
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
					r2["phong"]=r1["phong"].ToString();
					r2["giuong"]=r1["giuong"].ToString();
                    r2["ngaysinh"] = r1["ngaysinh"].ToString();//khuyen 14/01/14
                    r2["DOITUONG"] = r1["DOITUONG"].ToString();//khuyen 07/03/14
					foreach(DataRow r3 in dsmabd.Tables[0].Rows) r2["C_"+r3["mabd"].ToString().Trim()]=0;
					r2["C_"+r1["mabd"].ToString().Trim()]=r1["slyeucau"].ToString();
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr=ds.Tables[0].Select("mabn='"+r1["mabn"].ToString()+"'");
					if (dr!=null) dr[0]["C_"+r1["mabd"].ToString().Trim()]=decimal.Parse(dr[0]["C_"+r1["mabd"].ToString().Trim()].ToString())+decimal.Parse(r1["slyeucau"].ToString());
				}
				dr=dsmabd.Tables[0].Select("mabd="+int.Parse(r1["mabd"].ToString()));
				if (dr!=null) dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r1["slyeucau"].ToString());
			}
		}
		private void butIn_Click(object sender, System.EventArgs e)
		{
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
			taotable();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
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
			string []map={"STT","MÃ BN","HỌ TÊN","PHÒNG","GIƯỜNG","NGÀY SINH","ĐỐI TƯỢNG"};
			return map[i];
		}
        private void exp_excelCanLoc(bool print)
        {
            try
            {
                d.check_process_Excel();
                int be = 3, cot = ds.Tables[0].Columns.Count, dong = ds.Tables[0].Rows.Count + be + 2;
                DataColumn dc = new DataColumn();
                dc.ColumnName = "ghichu";
                dc.DataType = Type.GetType("System.String");
                ds.Tables[0].Columns.Add(dc);
                DataRow drstt = ds.Tables[0].NewRow();
                for (int i = 0; i < cot + 1; i++)
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
                for (int i = 0; i < 7; i++) osheet.Cells[be + 1, i + 1] = get_ten(i);
                for (int i = 0; i < dsmabd.Tables[0].Rows.Count; i++)
                {
                    osheet.Cells[be + 1, i + 8] = dsmabd.Tables[0].Rows[i]["tenbd"].ToString();
                    osheet.Cells[dong+1, i + 8] = dsmabd.Tables[0].Rows[i]["soluong"].ToString();
                }
                osheet.Cells[4, cot + 1] = "Ghi chú";
                orange = osheet.get_Range(d.getIndex(be) + "4", d.getIndex(cot) + "4");
                orange.VerticalAlignment = XlVAlign.xlVAlignBottom;
                orange.Orientation = 90;
                orange.RowHeight = 200;
                orange.EntireRow.AutoFit();

                orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(cot+10 ) + dong+10);
                orange.Font.Name = "Arial";
                orange.Font.Size = 10;
                orange.Font.Bold = false;

                osheet.get_Range(d.getIndex(0) + "4", d.getIndex(cot ) + (dong+1)).Borders.LineStyle = XlBorderWeight.xlHairline;
                //orange.EntireRow.AutoFit();
                orange.EntireColumn.AutoFit();
                orange = osheet.get_Range(d.getIndex(cot) + "1", d.getIndex(cot + 100) + dong + 10);
                orange.Cells.ColumnWidth = 3;

                //to mau tu cot thu 6

                for (int i = 7; i < cot; i++)
                {
                    if (i % 2 == 0)
                    {
                        orange = osheet.get_Range(d.getIndex(i) + "4", d.getIndex(i) + dong.ToString());
                        orange.Interior.Color = System.Drawing.Color.Beige.ToArgb();

                    }

                }
                //
                osheet.get_Range(d.getIndex(4) + (dong+1), d.getIndex(cot - 1) + (dong+1)).Font.Bold = true;
                oxl.ActiveWindow.DisplayZeros = false;
                osheet.Cells[1, 2] = d.Tenbv;
                osheet.Cells[2, 2] = (tu.Text == den.Text) ? "Ngày " + tu.Text : "Ngày " + tu.Text + " - " + den.Text;
                osheet.Cells[1, 4] = "TỔNG HỢP Y LỆNH";
                orange = osheet.get_Range(d.getIndex(2) + "1", d.getIndex(cot - 1) + "1");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size = 12;
                orange.Font.Bold = true;

                osheet.Cells[dong + 4, 26] = "In ngày " + System.DateTime.Today.Day.ToString() + " tháng " + System.DateTime.Today.Month.ToString() + " năm " + System.DateTime.Today.Year.ToString();
                osheet.Cells[dong + 5, 2] = "Khoa Dược";
                osheet.Cells[dong + 5, 7] = "Bác Sĩ";
                osheet.Cells[dong + 5, 15] = "Điều dưỡng thực hiện";
                osheet.Cells[dong + 5, 26] = "Người sao y lệnh";
                osheet.Cells[dong + 8, 2] = "Họ tên...................";
                osheet.Cells[dong + 8, 7] = "Họ tên...................";
                osheet.Cells[dong + 8, 15] = "Họ tên...................";
                osheet.Cells[dong + 8, 26] = "Họ tên...................";
                //orange = osheet.get_Range(d.getIndex(0) + dong+4, d.getIndex(cot) + dong+4);
                //orange.Font.Name = "Arial";
                //orange.Font.Size = 8;
                //orange.Font.Bold = false;

                osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                osheet.PageSetup.LeftMargin = 20;
                osheet.PageSetup.RightMargin = 20;
                osheet.PageSetup.TopMargin = 30;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //osheet.PrintPreview(Missing.Value);
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
                ds.Tables[0].Columns.Remove("DOITUONG");//KHUYEN 07/03/14
				d.check_process_Excel();
				int be=3,cot=ds.Tables[0].Columns.Count,dong=ds.Tables[0].Rows.Count+be+2;
				tenfile=d.Export_Excel(ds,"ylenh");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
				for(int i=0;i<6;i++) osheet.Cells[be+1,i+1]=get_ten(i);
				for(int i=0;i<dsmabd.Tables[0].Rows.Count;i++)
				{
					osheet.Cells[be+1,i+7]=dsmabd.Tables[0].Rows[i]["tenbd"].ToString();
					osheet.Cells[dong,i+7]=dsmabd.Tables[0].Rows[i]["soluong"].ToString();
				}
				orange=osheet.get_Range(d.getIndex(be)+"4",d.getIndex(cot-1)+"4");
				orange.VerticalAlignment=XlVAlign.xlVAlignBottom;
				orange.Orientation=90;
				orange.RowHeight = 200;
				orange.EntireRow.AutoFit();
				orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(cot-1)+dong.ToString());
				orange.Font.Name="Arial";
				orange.Font.Size=8;
				orange.Font.Bold=false;
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(cot-1)+dong.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				//orange.EntireRow.AutoFit();
				orange.EntireColumn.AutoFit();
				osheet.get_Range(d.getIndex(4)+dong.ToString(),d.getIndex(cot-1)+dong.ToString()).Font.Bold=true;
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.Cells[1,2]=makp.Text;
				osheet.Cells[2,2]=(tu.Text==den.Text)?"Ngày "+tu.Text:"Ngày "+tu.Text+" - "+den.Text;
				osheet.Cells[1,3]="TỔNG HỢP Y LỆNH";
				orange=osheet.get_Range(d.getIndex(2)+"1",d.getIndex(cot-1)+"1");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size=12;
				orange.Font.Bold=true;
				osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
				osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
				osheet.PageSetup.LeftMargin=20;
				osheet.PageSetup.RightMargin=20;
				osheet.PageSetup.TopMargin=30;
				osheet.PageSetup.CenterFooter="Trang : &P/&N";
                if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
                    //osheet.PrintPreview(Missing.Value);
                else oxl.Visible = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
