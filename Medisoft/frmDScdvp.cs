using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmDScdvp.
	/// </summary>
	public class frmDScdvp : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manhom;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb3;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker den;
		private string sql,s_makp,s_madoituong,user,stime;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dtmakp=new DataTable();
		private DataTable dtmadt=new DataTable();
		private System.Windows.Forms.CheckedListBox madoituong;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDScdvp(LibMedi.AccessData acc,string _makp,string _madoituong)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

			m=acc;s_makp=_makp;s_madoituong=_madoituong;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDScdvp));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.manhom = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.madoituong = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(135, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(55, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(167, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhóm :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manhom
            // 
            this.manhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(55, 32);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(192, 21);
            this.manhom.TabIndex = 5;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(250, 8);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 164);
            this.makp.TabIndex = 8;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(46, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 37);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(128, 8);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(89, 25);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Viện phí";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(59, 7);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(70, 26);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Chỉ định";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(7, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Cả hai";
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(154, 184);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 9;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(225, 184);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // madoituong
            // 
            this.madoituong.CheckOnClick = true;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(55, 56);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(192, 84);
            this.madoituong.TabIndex = 7;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmDScdvp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(448, 229);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDScdvp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách chỉ định & viện phí";
            this.Load += new System.EventHandler(this.frmDScdvp_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDScdvp_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			ds.ReadXml("..//..//..//xml//m_dscdvp.xml");
			dsxml.ReadXml("..//..//..//xml//m_dscdvp.xml");
			manhom.DataSource=m.get_data("select * from "+user+".v_nhomvp order by stt").Tables[0];
            manhom.DisplayMember = "TEN";
            manhom.ValueMember = "MA";
			sql="select * from "+user+".btdkp_bv ";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " where makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by loai,makp";
			dtmakp=m.get_data(sql).Tables[0];
            makp.DataSource = dtmakp;	
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			
			sql="select * from "+user+".doituong ";
			if (s_madoituong!="") sql+=" where madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
			sql+=" order by madoituong";
			dtmadt=m.get_data(sql).Tables[0];
			madoituong.DataSource=dtmadt;
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (manhom.SelectedIndex==-1)
			{
				manhom.Focus();	
				return;
			}
			s_makp="";s_madoituong="";
			for(int i=0;i<makp.Items.Count;i++) if (makp.GetItemChecked(i)) s_makp+="'"+dtmakp.Rows[i]["makp"].ToString().Trim()+"',";//Tu: 22/08/2011
			for(int i=0;i<madoituong.Items.Count;i++) if (madoituong.GetItemChecked(i)) s_madoituong+=dtmadt.Rows[i]["madoituong"].ToString().Trim()+",";
			int yy1=int.Parse(tu.Text.Substring(8,2)),yy2=int.Parse(den.Text.Substring(8,2));
			ds.Clear();
			dsxml.Clear();
			if (rb1.Checked)
			{
				get_data("v_vpkhoa");
				get_data("v_chidinh");
			}
			else if (rb2.Checked) get_data("v_chidinh");
			else get_data("v_vpkhoa");
			dsxml.Merge(ds.Tables[0].Select("soluong>0","loaivp,tenvp"));
			if (dsxml.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,(tu.Text==den.Text)?" Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,"rptDscdvp.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void get_data(string table)
		{
			DataRow r1,r2;
			DataRow [] dr;
			sql="select to_char(c.ngay,'dd/mm/yyyy') as ngay,b.tenkp,a.mabn,a.hoten,a.namsinh,c.mavp,e.ten as loaivp,d.ten as tenvp,c.soluong,c.dongia,c.soluong*c.dongia as sotien ";
			sql+=" from "+user+".btdbn a,"+user+".btdkp_bv b,xxx."+table+" c,"+user+".v_giavp d,"+user+".v_loaivp e";
			sql+=" where a.mabn=c.mabn and c.makp=b.makp and c.mavp=d.id and d.id_loai=e.id";
            sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and e.id_nhom="+int.Parse(manhom.SelectedValue.ToString());
            if (s_makp != "")//gam 11/08/2011
            {
                sql += " and c.makp in (" + s_makp.Trim(',') + ")";
            }
			if (s_madoituong!="") sql+=" and c.madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
			foreach(DataRow r in m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0].Rows)
			{
				sql="ngay='"+r["ngay"].ToString()+"' and mabn='"+r["mabn"].ToString()+"' and mavp="+int.Parse(r["mavp"].ToString());
				r1=m.getrowbyid(ds.Tables[0],sql);				
				if (r1==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["tenkp"]=r["tenkp"].ToString();
					r2["mabn"]=r["mabn"].ToString();
					r2["hoten"]=r["hoten"].ToString();
					r2["namsinh"]=r["namsinh"].ToString();
					r2["ngay"]=r["ngay"].ToString();
					r2["mavp"]=r["mavp"].ToString();
					r2["tenvp"]=r["tenvp"].ToString();
					r2["loaivp"]=r["loaivp"].ToString();
					r2["soluong"]=r["soluong"].ToString();
					r2["dongia"]=r["dongia"].ToString();
					r2["sotien"]=decimal.Parse(r["soluong"].ToString())*decimal.Parse(r["dongia"].ToString());
					ds.Tables[0].Rows.Add(r2);
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0)
					{
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["soluong"].ToString())*decimal.Parse(r["dongia"].ToString());
					}
				}
			}
		}
	}
}
