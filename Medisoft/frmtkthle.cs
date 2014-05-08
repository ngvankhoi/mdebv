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
	/// Summary description for frmtkdscls.
	/// </summary>
	public class frmtkthle : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Button butIN;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataTable dtkp=new DataTable();
		private string sql,matt,s_makp;
		private int namsinh;
		private AccessData m;
		private System.Windows.Forms.CheckedListBox makp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmtkthle(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

			m=acc;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtkthle));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butIN = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.CheckedListBox();
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
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(52, 140);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(75, 28);
            this.butIN.TabIndex = 5;
            this.butIN.Text = "       &In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(129, 140);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 28);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(55, 32);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 100);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmtkthle
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 181);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmtkthle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê tổng hợp khám lé";
            this.Load += new System.EventHandler(this.frmtkthle_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmtkthle_Load(object sender, System.EventArgs e)
		{
			matt=m.Mabv.Substring(0,3);
			ds.ReadXml("..//..//..//xml//m_tkcls.xml");
			dtkp=m.get_data("select * from btdkp_bv order by loai,makp").Tables[0];
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=dtkp;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			namsinh=int.Parse(tu.Text.ToString().Substring(6,4));
			s_makp="'";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+"','";
			ds.Clear();
			sql="select to_char(a.ngay,'yyyymmdd') as ngay,";
			sql+=" sum(1) as ts,";
			sql+=" sum(case when a.kham=1 and "+namsinh+"-to_number(b.namsinh)<=6 then 1 else 0 end) as c01,";
			sql+=" sum(case when a.kham=1 and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 then 1 else 0 end) as c02,";
			sql+=" sum(case when a.kham=1 and "+namsinh+"-to_number(b.namsinh)>14 and b.phai=0 then 1 else 0 end) as c03,";
			sql+=" sum(case when a.kham=1 and "+namsinh+"-to_number(b.namsinh)>14 and b.phai=1 then 1 else 0 end) as c04,";
			sql+=" sum(case when a.kham=0 and "+namsinh+"-to_number(b.namsinh)<=6 then 1 else 0 end) as c05,";
			sql+=" sum(case when a.kham=0 and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 then 1 else 0 end) as c06,";
			sql+=" sum(case when a.kham=0 and "+namsinh+"-to_number(b.namsinh)>14 and b.phai=0 then 1 else 0 end) as c07,";
			sql+=" sum(case when a.kham=0 and "+namsinh+"-to_number(b.namsinh)>14 and b.phai=1 then 1 else 0 end) as c08,";
			sql+=" sum(case when b.matt='"+matt+"' and a.madoituong=1 then 1 else 0 end) as c09,";
			sql+=" sum(case when b.matt='"+matt+"' and "+namsinh+"-to_number(b.namsinh)<=6 and a.madoituong<>1 and c.mien=0 then 1 else 0 end) as c10,";
			sql+=" sum(case when b.matt='"+matt+"' and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 and a.madoituong<>1 and c.mien=0 then 1 else 0 end) as c11,";
			sql+=" sum(case when b.matt='"+matt+"' and "+namsinh+"-to_number(b.namsinh)<=6 and a.madoituong<>1 and c.mien=1 then 1 else 0 end) as c12,";
			sql+=" sum(case when b.matt='"+matt+"' and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 and a.madoituong<>1 and c.mien=1 then 1 else 0 end) as c13,";
			sql+=" sum(case when b.matt<>'"+matt+"' and a.madoituong=1 then 1 else 0 end) as c14,";
			sql+=" sum(case when b.matt<>'"+matt+"' and "+namsinh+"-to_number(b.namsinh)<=6 and a.madoituong<>1 and c.mien=0 then 1 else 0 end) as c15,";
			sql+=" sum(case when b.matt<>'"+matt+"' and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 and a.madoituong<>1 and c.mien=0 then 1 else 0 end) as c16,";
			sql+=" sum(case when b.matt<>'"+matt+"' and "+namsinh+"-to_number(b.namsinh)<=6 and a.madoituong<>1 and c.mien=1 then 1 else 0 end) as c17,";
			sql+=" sum(case when b.matt<>'"+matt+"' and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 and a.madoituong<>1 and c.mien=1 then 1 else 0 end) as c18";
			sql+=" from le_thuchien a,btdbn b,doituong c";
			sql+=" where a.mabn=b.mabn and a.madoituong=c.madoituong";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			if (s_makp.Length>1) sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
			sql+=" group by to_char(a.ngay,'yyyymmdd')";
			sql+=" order by to_char(a.ngay,'yyyymmdd')";
			ds=m.get_data(sql);
			Cursor=Cursors.Default;
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,"KHÁM LÉ"+","+((tu.Text==den.Text)?"Ngày :"+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text),"rpttkthle.rpt");
				f.ShowDialog();
			}
		}
	}
}
