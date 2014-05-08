using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmNhapxuat.
	/// </summary>
	public class frmNXkhoa : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private DataTable dt=new DataTable();
        private AccessData m;
		private DataSet ds=new DataSet();
		private string s_makp,sql;
		private int i_loaiba;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox theo;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox loaiba;
        private string s_user = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNXkhoa(AccessData acc,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNXkhoa));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loaiba = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 8);
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
            this.tu.Location = new System.Drawing.Point(56, 8);
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
            this.den.Location = new System.Drawing.Point(168, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(58, 111);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 10;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(129, 111);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Theo :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theo
            // 
            this.theo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.theo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theo.Items.AddRange(new object[] {
            "Nhập khoa",
            "Xuất khoa"});
            this.theo.Location = new System.Drawing.Point(56, 32);
            this.theo.Name = "theo";
            this.theo.Size = new System.Drawing.Size(192, 21);
            this.theo.TabIndex = 5;
            this.theo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(56, 56);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 7;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Khoa :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điều trị :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaiba
            // 
            this.loaiba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaiba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaiba.Items.AddRange(new object[] {
            "Nội trú",
            "Ngoại trú"});
            this.loaiba.Location = new System.Drawing.Point(56, 80);
            this.loaiba.Name = "loaiba";
            this.loaiba.Size = new System.Drawing.Size(192, 21);
            this.loaiba.TabIndex = 9;
            this.loaiba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmNXkhoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 157);
            this.Controls.Add(this.loaiba);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.theo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNXkhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập xuất khoa";
            this.Load += new System.EventHandler(this.frmNXkhoa_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmNXkhoa_Load(object sender, System.EventArgs e)
		{
            s_user = m.user;
			theo.SelectedIndex=0;
			loaiba.SelectedIndex=0;
            sql = "select * from " + s_user + ".btdkp_bv where loai=0";
			if (s_makp!="") sql+=" and makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			dt=m.get_data(sql).Tables[0];
            makp.DataSource = dt;
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";			
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();
				return;
			}
			i_loaiba=(loaiba.SelectedIndex==0)?1:2;
            string stime = "'" + m.f_ngay + "'";
			sql="select a.mabn,l.soluutru,a.hoten,case when a.phai=0 then a.namsinh else '' end as nam,";
			sql+="case when a.phai=0 then '' else a.namsinh end as nu,g.tennn,";
			sql+="trim(a.sonha)||' '||trim(a.thon)||' '||trim(f.tenpxa)||','||trim(e.tenquan)||','||trim(d.tentt) as diachi,";
            if (theo.SelectedIndex == 0)
                sql += "to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.chandoan,b.maicd";
            else
            {
                if (i_loaiba == 1)
                    sql += "to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.chandoan,c.maicd";
                else
                    sql += "to_char(b.ngayrv,'dd/mm/yyyy hh24:mi') as ngay,b.chandoanrv as chandoan,b.maicdrv as maicd";
            }
            sql += " from " + s_user + ".btdbn a inner join " + s_user + ".btdtt d on a.matt=d.matt";
            sql += " inner join " + s_user + ".btdquan e on a.maqu=e.maqu";
            sql += " inner join " + s_user + ".btdpxa f on a.maphuongxa=f.maphuongxa";
            sql += " inner join " + s_user + ".btdnn_bv g on a.mann=g.mann";//nhapkhoa b,xuatkhoa c,
            if (i_loaiba == 1)
            {
                sql += " inner join " + s_user + ".nhapkhoa b on a.mabn=b.mabn left join " + s_user + ".xuatkhoa c on b.id=c.id inner join " + s_user + ".benhandt k on b.maql=k.maql";
            }
            if (i_loaiba == 2)
            {
                sql += " inner join " + s_user + ".benhanngtr b on a.mabn=b.mabn";
            }
            sql += " inner join " + s_user + ".lienhe l on b.maql=l.maql";
            sql += " where b.maql>0";
			if (theo.SelectedIndex==0)
			{

                sql += " and " + m.for_ngay("b.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			}
			else if (theo.SelectedIndex==1)
			{
                if (i_loaiba == 1)
                    sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                else
                    sql += " and " + m.for_ngay("b.ngayrv", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			}
			sql+=" and b.makp='"+makp.SelectedValue.ToString()+"' order by l.soluutru";
			ds=m.get_data(sql);
			string title=(theo.SelectedIndex==0)?"DANH SÁCH NHẬP KHOA ":" DANH SÁCH XUẤT KHOA ";
			title+=makp.Text.ToUpper().Trim();
			if (ds.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,"rptNXkhoa.rpt",(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,title,(loaiba.SelectedIndex==0)?"Nội trú":"Ngoại trú",m.Syte,m.Tenbv,"");
				f.ShowDialog(this);
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}
	}
}
