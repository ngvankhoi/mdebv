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
	public class frmNhapxuatk : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private DataTable dt=new DataTable();
		private AccessData m;
		private DataSet ds=new DataSet();
		private string s_makp,sql;
		private int i_loaiba;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox theo;
        private string user = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNhapxuatk(AccessData acc,int loaiba,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            i_loaiba = loaiba; s_makp = makp; m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapxuatk));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
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
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(56, 56);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 116);
            this.makp.TabIndex = 6;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(57, 184);
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
            this.butKetthuc.Location = new System.Drawing.Point(129, 184);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
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
            "Xuất khoa",
            "Nhập chưa xuất",
            "Nhập viện lấy từ nhập khoa",
            "Nhập khoa do khoa khác chuyển qua",
            "Xuất khoa - ra viện",
            "Xuất khoa - chuyển khoa"});
            this.theo.Location = new System.Drawing.Point(56, 32);
            this.theo.Name = "theo";
            this.theo.Size = new System.Drawing.Size(192, 21);
            this.theo.TabIndex = 5;
            this.theo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmNhapxuatk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 229);
            this.Controls.Add(this.theo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhapxuatk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập xuất khoa";
            this.Load += new System.EventHandler(this.frmNhapxuatk_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmNhapxuatk_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			theo.SelectedIndex=0;
            string tmp_makp = s_makp.Trim().Trim(',').Replace(",", "','");
            if (tmp_makp.Trim().Trim(',') != "") tmp_makp = "'" + tmp_makp + "'";
            tmp_makp = tmp_makp.Replace("''", "'");
            sql = "select * from " + user + ".btdkp_bv where loai=0";
            if (tmp_makp.Trim().Trim(',')!="") sql += " and makp in (" + tmp_makp.Trim().Trim(',') + ")";
			dt=m.get_data(sql).Tables[0];
            makp.DataSource = dt;
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_makp="";		
			if (makp.CheckedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++) if (makp.GetItemChecked(i)) s_makp+="'"+dt.Rows[i]["makp"].ToString()+"',";
			s_makp=(s_makp!="")?s_makp.Substring(0,s_makp.Length-1):"";
            string stime="'"+m.f_ngay+"'";
			sql="select a.mabn,a.hoten,case when a.phai=0 then 'Nam' else 'Nu' end as phai,a.namsinh,";
			sql+="trim(a.sonha)||' '||trim(a.thon)||' '||trim(f.tenpxa)||','||trim(e.tenquan)||','||trim(d.tentt) diachi,";
			sql+="to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,i.tenkp as khoavao,";
			sql+="b.chandoan as chandoanvao,b.maicd as icdvao,";
			sql+="to_char(c.ngay,'dd/mm/yyyy hh24:mi') ngayra,j.tenkp as khoara,";
			sql+="c.chandoan as chandoanra,c.maicd as icdra,";
			sql+="case when c.ttlucrk=7 then 'x' else ' ' end as tv,nullif(h.tenbv,' ') as tenbv";
            sql += " from " + user + ".btdbn a inner join " + user + ".nhapkhoa b on a.mabn=b.mabn";
            sql += " left join " + user + ".xuatkhoa c on b.id=c.id";
            sql += " inner join " + user + ".btdtt d on a.matt=d.matt";
            sql += " inner join " + user + ".btdquan e on a.maqu=e.maqu";
            sql += " inner join " + user + ".btdpxa f on a.maphuongxa=f.maphuongxa";
            sql += " left join " + user + ".chuyenvien g on b.maql=g.maql";
            sql += " left join " + user + ".tenvien h on g.mabv=h.mabv";
            sql += " inner join " + user + ".btdkp_bv i on b.makp=i.makp";
            sql += " left join " + user + ".btdkp_bv j on b.makp=j.makp";
            sql += " inner join " + user + ".benhandt k on b.maql=k.maql";
            sql += " where b.id>0";
			if (theo.SelectedIndex==0)
			{
                sql += " and " + m.for_ngay("b.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
				if (s_makp!="") sql+=" and b.makp in ("+s_makp+")";
			}
			else if (theo.SelectedIndex==1)
			{
                sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
				if (s_makp!="") sql+=" and b.makp in ("+s_makp+")";
			}
			else if(theo.SelectedIndex ==2)
			{
                sql += " and ((" + m.for_ngay("b.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " and c.ngay is null) or to_date(to_char(c.ngay," + stime + ")," + stime + ") > to_date('" + den.Text + "'," + stime + "))";

                if (s_makp!="") sql+=" and b.makp in ("+s_makp+")";
			}
            else if (theo.SelectedIndex == 3)
            {
                sql += " and " + m.for_ngay("k.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " and b.khoachuyen='01' ";
                if (s_makp != "") sql += " and b.makp in (" + s_makp + ")";
            }
            else if (theo.SelectedIndex == 4)
            {
                sql += " and " + m.for_ngay("k.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " and b.khoachuyen<>'01' ";
                if (s_makp != "") sql += " and b.makp in (" + s_makp + ")";
            }
            else if (theo.SelectedIndex == 5)
            {
                sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " and c.ttlucrk<>5 ";
                if (s_makp != "") sql += " and b.makp in (" + s_makp + ")";
            }
            else if (theo.SelectedIndex == 6)
            {
                sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " and c.ttlucrk=5 ";
                if (s_makp != "") sql += " and b.makp in (" + s_makp + ")";
            }
			ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,"rptNhapxuat.rpt",(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,ds.Tables[0].Select("tv='x'").Length.ToString(),ds.Tables[0].Select("tenbv<>''").Length.ToString(),m.Syte,m.Tenbv,"");
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
