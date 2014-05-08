using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmYlenh.
	/// </summary>
	public class frmTHSDThuoc : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.CheckedListBox makho;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new AccessData();
		private string s_makp,sql,s_makho,cont,sql1,tenfile,s_nhomkho,_makp;
		private DataRow r;
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtdmbd=new System.Data.DataTable();
        private System.Data.DataTable dtnhom = new System.Data.DataTable();
        private DataSet ds;
		private DataSet dsmabd=new DataSet();
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Button butPreview;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb3;
        private string user = "",s_time="";
        private CheckedListBox dmnhom;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTHSDThuoc(LibMedi.AccessData acc,string makp,string _nhomkho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			_makp=makp;s_nhomkho=_nhomkho;
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmTHSDThuoc( string makp, string _nhomkho)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            _makp = makp; s_nhomkho = _nhomkho;
            m = new AccessData();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTHSDThuoc));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butPreview = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.dmnhom = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
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
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Khoa :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(258, 8);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(216, 196);
            this.makho.TabIndex = 10;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(201, 250);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(83, 25);
            this.butIn.TabIndex = 12;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(284, 250);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(94, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butPreview
            // 
            this.butPreview.Image = ((System.Drawing.Image)(resources.GetObject("butPreview.Image")));
            this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPreview.Location = new System.Drawing.Point(118, 250);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(83, 25);
            this.butPreview.TabIndex = 11;
            this.butPreview.Text = "&Xem";
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 56);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 148);
            this.makp.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(125, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 32);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Checked = true;
            this.rb3.Location = new System.Drawing.Point(171, 7);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(56, 22);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.Text = "Cả hai";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(93, 7);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(76, 22);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Xuất viện";
            // 
            // rb1
            // 
            this.rb1.Location = new System.Drawing.Point(8, 7);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(104, 22);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "Đang điều trị";
            // 
            // dmnhom
            // 
            this.dmnhom.CheckOnClick = true;
            this.dmnhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dmnhom.Location = new System.Drawing.Point(480, 8);
            this.dmnhom.Name = "dmnhom";
            this.dmnhom.Size = new System.Drawing.Size(216, 196);
            this.dmnhom.TabIndex = 16;
            // 
            // frmTHSDThuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(711, 295);
            this.Controls.Add(this.dmnhom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butPreview);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTHSDThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp sử dụng thuốc";
            this.Load += new System.EventHandler(this.frmTHSDThuoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmTHSDThuoc_Load(object sender, System.EventArgs e)
		{
            s_time="'"+m.f_ngay+"'";
            user = m.user;
			dsmabd.ReadXml("..//..//..//xml//d_mabd.xml");

            load_nhom();
            nhom.DisplayMember = "TEN";
            nhom.ValueMember = "ID";

            load_makho();
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";

            load_makp();
            makp.DisplayMember = "TEN";
            makp.ValueMember = "ID";

            load_dmnhombd();
            dmnhom.DisplayMember = "TEN";
            dmnhom.ValueMember = "ID";
		}

        private void load_dmnhombd()
        {
            s_makho = "";
            sql = "select * from "+user+".d_dmnhom where nhom=" + int.Parse(nhom.SelectedValue.ToString());
            sql += " order by stt";
            dtnhom = d.get_data(sql).Tables[0];
            dmnhom.DataSource = dtnhom;
        }
		private void load_makp()
		{
			if (nhom.SelectedIndex!=-1)
			{
                sql = "select * from " + user + ".d_duockp where nhom like '%" + nhom.SelectedValue.ToString() + ",%'";
                if (_makp != "")
                {
                    string s = _makp.Replace(",", "','");
                    sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
				sql+=" order by stt";
				dtmakp=d.get_data(sql).Tables[0];
				makp.DataSource=dtmakp;
                makp.DisplayMember = "TEN";
                makp.ValueMember = "ID";
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
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";

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
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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


		private void taotable()
		{
			dsmabd.Clear();
			ds=new DataSet();
			ds.ReadXml("..//..//..//xml//d_ylenh.xml");
			ds.Tables[0].Columns.Remove("PHONG");
			ds.Tables[0].Columns.Remove("GIUONG");
            ds.Tables[0].Columns.Add("TENKP");
            dtdmbd = d.get_data("select * from " + user + ".d_dmbd where nhom=" + int.Parse(nhom.SelectedValue.ToString())).Tables[0];
			cont=" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			s_makho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i)) s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
			s_makp="";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) s_makp+=dtmakp.Rows[i]["id"].ToString().Trim()+",";
			if (s_makp!="") cont+=" and a.makhoa in ("+s_makp.Substring(0,s_makp.Length-1)+")";

            string s_manhom = "";
            for (int i = 0; i < dmnhom.Items.Count; i++)
                if (dmnhom.GetItemChecked(i)) s_manhom += dtnhom.Rows[i]["id"].ToString().Trim() + ",";
            if (s_manhom != "")
            {
                cont += " and bd.manhom in (" + s_manhom.Trim().Trim(',') + ")";
            }
            //

            if (rb1.Checked)
            {
                cont += " and b.maql not in (select maql from " + user + ".xuatvien";
                cont += " where " + m.for_ngay("ngay", s_time) + " between to_date('" + tu.Text + "'," + s_time + ") and to_date('" + den.Text + "'," + s_time + "))";
            }
            else if (rb2.Checked)
            {
                cont += " and b.maql in (select maql from " + user + ".xuatvien";
                cont += " where " + m.for_ngay("ngay", s_time) + " between to_date('" + tu.Text + "'," + s_time + ") and to_date('" + den.Text + "'," + s_time + "))";
            }
            sql = "select distinct c.mabd from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join xxx.d_dutruct c on b.id=c.id inner join " + user + ".d_dmbd bd on c.mabd=bd.id ";
			sql+=" where a.id>0 "+cont;
			sql+=" union all ";
            sql += "select distinct c.mabd from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join xxx.d_xtutrucct c on b.id=c.id inner join " + user + ".d_dmbd bd on c.mabd=bd.id ";
			sql+=" where a.id>0 "+cont;
			sql+=" union all ";
            sql += "select distinct c.mabd from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet inner join xxx.d_hoantract c on b.id=c.id inner join " + user + ".d_dmbd bd on c.mabd=bd.id ";
			sql+=" where a.id>0 "+cont;
			upd_mabd(sql);
            sql1 = "select b.mabn,e.hoten,c.mabd,c.slyeucau, kp.ten as tenkp from xxx.d_duyet a inner join xxx.d_dutrull b on a.id=b.idduyet inner join xxx.d_dutruct c on b.id=c.id inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".d_dmbd bd on c.mabd=bd.id inner join " + user + ".d_duockp kp on a.makp=kp.id ";
            sql1 += " where a.id>0 " + cont;
            sql1 += " union all ";
            sql1 += "select b.mabn,e.hoten,c.mabd,c.slyeucau, kp.ten as tenkp from xxx.d_duyet a inner join xxx.d_xtutrucll b on a.id=b.idduyet inner join xxx.d_xtutrucct c on b.id=c.id inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".d_dmbd bd on c.mabd=bd.id inner join " + user + ".d_duockp kp on a.makp=kp.id  ";
            sql1 += " where a.id>0 " + cont;
            sql1 += " union all ";
            sql1 += "select b.mabn,e.hoten,c.mabd,-c.slyeucau, kp.ten as tenkp from xxx.d_duyet a inner join xxx.d_hoantrall b on a.id=b.idduyet inner join xxx.d_hoantract c on b.id=c.id inner join " + user + ".btdbn e on b.mabn=e.mabn inner join " + user + ".d_dmbd bd on c.mabd=bd.id  inner join " + user + ".d_duockp kp on a.makp=kp.id ";
            sql1 += " where a.id>0 " + cont;
			upd_soluong(sql1);
		}

		private void upd_mabd(string sql)
		{
			DataRow r2,r3;
			//foreach(DataRow r1 in d.get_data(sql).Tables[0].Rows)
            foreach (DataRow r1 in m.get_data_mmyy(sql,tu.Text.Substring(0,10),den.Text.Substring(0,10),true).Tables[0].Rows)
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
			//foreach(DataRow r1 in d.get_data(sql).Tables[0].Rows)
            foreach (DataRow r1 in m.get_data_mmyy(sql,tu.Text.Substring(0,10),den.Text.Substring(0,10),true).Tables[0].Rows)
			{
				r=d.getrowbyid(ds.Tables[0],"mabn='"+r1["mabn"].ToString()+"'");
				if (r==null)
				{
					r2=ds.Tables[0].NewRow();
                    r2["tenkp"] = r1["tenkp"].ToString();
					r2["stt"]=d.get_stt(ds.Tables[0]).ToString();
					r2["mabn"]=r1["mabn"].ToString();
					r2["hoten"]=r1["hoten"].ToString();
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
			string []map={"STT","MÃ BN","HỌ TÊN","KHOA"};
			return map[i];
		}

        private void exp_excel(bool print)
        {
            try
            {
                d.check_process_Excel();
                int be = 3, cot = ds.Tables[0].Columns.Count, dong = ds.Tables[0].Rows.Count + be + 2;
                tenfile = d.Export_Excel(ds, "TONGHOP");
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;
                for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
                for (int i = 0; i < 4; i++) osheet.Cells[be + 1, i + 1] = get_ten(i);
                DataRow[] dr = dsmabd.Tables[0].Select("true", "tenbd");
                for (int i = 0; i < dr.Length; i++)
                {
                    osheet.Cells[be + 1, i + 5] = dr[i]["tenbd"].ToString();
                    osheet.Cells[dong, i + 5] = dr[i]["soluong"].ToString();
                }
                orange = osheet.get_Range(d.getIndex(be) + "4", d.getIndex(cot - 1) + "4");
                orange.VerticalAlignment = XlVAlign.xlVAlignBottom;
                orange.Orientation = 90;
                orange.RowHeight = 200;
                orange.EntireRow.AutoFit();
                orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(cot - 1) + dong.ToString());
                orange.Font.Name = "Arial";
                orange.Font.Size = 10;
                orange.Font.Bold = false;
                osheet.get_Range(d.getIndex(0) + "4", d.getIndex(cot - 1) + dong.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                //orange.EntireRow.AutoFit();
                orange.EntireColumn.AutoFit();
                osheet.get_Range(d.getIndex(3) + dong.ToString(), d.getIndex(cot - 1) + dong.ToString()).Font.Bold = true;
                oxl.ActiveWindow.DisplayZeros = false;
                osheet.Cells[1, 2] = "";//makp.Text;
                osheet.Cells[2, 3] = (tu.Text == den.Text) ? "Ngày " + tu.Text : "Ngày " + tu.Text + " - " + den.Text;
                osheet.Cells[1, 3] = "TỔNG HỢP SỬ DỤNG THUỐC";
                orange = osheet.get_Range(d.getIndex(2) + "1", d.getIndex(cot - 1) + "2");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                try
                {
                    orange.Font.Size = 12;
                    orange.Font.Bold = true;
                    osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                    osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                    osheet.PageSetup.LeftMargin = 20;
                    osheet.PageSetup.RightMargin = 20;
                    osheet.PageSetup.TopMargin = 30;
                }
                catch { }
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                else oxl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
		private void exp_excel_eee(bool print)
		{
			try
			{
				d.check_process_Excel();
				int be=3,cot=ds.Tables[0].Columns.Count,dong=ds.Tables[0].Rows.Count+be+2;
				tenfile=d.Export_Excel(ds,"TONGHOP");
				oxl=new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
                for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
				for(int i=0;i<4;i++) osheet.Cells[be+1,i+1]=get_ten(i);
				DataRow [] dr=dsmabd.Tables[0].Select("true","tenbd");
				for(int i=0;i<dr.Length;i++)
				{
					osheet.Cells[be+1,i+4]=dr[i]["tenbd"].ToString();
					osheet.Cells[dong,i+4]=dr[i]["soluong"].ToString();
				}
				orange=osheet.get_Range(d.getIndex(be)+"4",d.getIndex(cot-1)+"4");
				orange.VerticalAlignment=XlVAlign.xlVAlignBottom;
				orange.Orientation=90;
				orange.RowHeight = 200;
				orange.EntireRow.AutoFit();
				orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(cot-1)+dong.ToString());
				orange.Font.Name="Arial";
				orange.Font.Size=10;
				orange.Font.Bold=false;
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(cot-1)+dong.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				//orange.EntireRow.AutoFit();
				orange.EntireColumn.AutoFit();
				osheet.get_Range(d.getIndex(3)+dong.ToString(),d.getIndex(cot-1)+dong.ToString()).Font.Bold=true;
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.Cells[1,2]="";//makp.Text;
				osheet.Cells[2,3]=(tu.Text==den.Text)?"Ngày "+tu.Text:"Ngày "+tu.Text+" - "+den.Text;
				osheet.Cells[1,3]="TỔNG HỢP SỬ DỤNG THUỐC";
				orange=osheet.get_Range(d.getIndex(2)+"1",d.getIndex(cot-1)+"2");
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
				else oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
