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
	/// Summary description for frmDoichieu.
	/// </summary>
	public class frmCDVPCLS : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox tenloai;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private string sql,s_makp,cont,user,stime;
		private bool bClear=true;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox madoituong;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCDVPCLS(LibMedi.AccessData acc,string makp,string title,string dk)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;s_makp=makp;cont=dk;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            this.Text = lan.Change_language_MessageText(title);
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCDVPCLS));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tenloai = new System.Windows.Forms.ComboBox();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(152, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-1, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Khoa phòng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(72, 14);
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
            this.den.Location = new System.Drawing.Point(184, 14);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tenloai
            // 
            this.tenloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenloai.Location = new System.Drawing.Point(72, 38);
            this.tenloai.Name = "tenloai";
            this.tenloai.Size = new System.Drawing.Size(192, 21);
            this.tenloai.TabIndex = 5;
            this.tenloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tenkp
            // 
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(72, 62);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(192, 21);
            this.tenkp.TabIndex = 7;
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(65, 120);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 11;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(137, 120);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 12;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đối tượng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(72, 86);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(192, 21);
            this.madoituong.TabIndex = 9;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmCDVPCLS
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(272, 165);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.tenloai);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCDVPCLS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đối chiếu chỉ định - viện phí - thực hiện";
            this.Load += new System.EventHandler(this.frmCDVPCLS_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmCDVPCLS_MouseMove);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCDVPCLS_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			tenloai.DisplayMember="TEN";
			tenloai.ValueMember="ID";
			tenloai.DataSource=m.get_data("select * from "+user+".v_loaivp order by stt").Tables[0];

			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
            sql = "select * from " + user + ".btdkp_bv";
			if (s_makp!="")
			{
				string s=s_makp.Replace(",","','");
				sql+=" where makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by loai desc,makp";
			tenkp.DataSource=m.get_data(sql).Tables[0];

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
			ds.ReadXml("..//..//..//xml//m_doichieu.xml");
		}

		private void frmCDVPCLS_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				tenloai.SelectedIndex=-1;
				tenkp.SelectedIndex=-1;
				madoituong.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void load_grid()
		{
			ds.Clear();
			sql="select to_char(a.ngay,'yyyymmdd') as yyyymmdd,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.mabn,d.hoten,c.ten,e.tenkp,f.hoten as tenbs,a.soluong as c01,a.soluong*(a.dongia+a.vattu) as c02,a.paid ";
			sql+=" from xxx.v_chidinh a inner join "+user+".v_giavp c on a.mavp=c.id ";
            sql+=" inner join "+user+".v_loaivp b on c.id_loai=b.id ";
            sql+=" inner join "+user+".btdbn d on a.mabn=d.mabn ";
            sql+=" left join "+user+".btdkp_bv e on a.makp=e.makp ";
            //sql += " left join xxx.benhanpk g on a.maql=g.maql ";
            sql += " left join (select maql,mabs from xxx.benhanpk union all select maql,mabs from xxx.benhancc  ) g on a.maql=g.maql ";//gam 21/10/2011
            sql+=" left join "+user+".dmbs f on g.mabs=f.ma";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (tenloai.SelectedIndex!=-1) sql+=" and b.id="+int.Parse(tenloai.SelectedValue.ToString());
			if (tenkp.SelectedIndex!=-1) sql+=" and a.makp='"+tenkp.SelectedValue.ToString()+"'";
			if (madoituong.SelectedIndex!=-1) sql+=" and a.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			sql+=" and "+cont;
			ds.Merge(v.get_vienphi(tu.Text,den.Text,sql).Tables[0].Select("true","yyyymmdd,mabn"));
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			load_grid();
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
                ds.WriteXml("m_cdvpcls.xml");
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds.Tables[0],"m_cdvpcls.rpt",(tu.Text==den.Text)?
lan.Change_language_MessageText("Ngày")+" "+tu.Text:
lan.Change_language_MessageText("Từ ngày")+" "+tu.Text+" "+
lan.Change_language_MessageText("đến")+" "+den.Text,(madoituong.SelectedIndex!=-1)?madoituong.Text:"",(tenloai.SelectedIndex!=-1)?tenloai.Text:"",(tenkp.SelectedIndex!=-1)?tenkp.Text:"",this.Text,"","","","","");
				f.ShowDialog();
			}
		}
	}
}
