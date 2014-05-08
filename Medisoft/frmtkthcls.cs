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
	public class frmtkthcls : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Button butIN;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private string sql,matt,s_cls,user,stime;
		private int namsinh;
		private AccessData m;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmtkthcls(AccessData acc,string cls)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

			m=acc;s_cls=cls;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtkthcls));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.loai = new System.Windows.Forms.ComboBox();
            this.butIN = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(56, 32);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(192, 21);
            this.loai.TabIndex = 5;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(41, 72);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(88, 25);
            this.butIN.TabIndex = 6;
            this.butIN.Text = "&In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(129, 72);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(92, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmtkthcls
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 117);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmtkthcls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê tổng hợp cận làm sàng";
            this.Load += new System.EventHandler(this.frmtkthcls_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmtkthcls_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			matt=m.Mabv.Substring(0,3);
			ds.ReadXml("..//..//..//xml//m_tkcls.xml");
			sql="select * from "+user+".cls_loai ";
			if (s_cls!="") sql+=" where id in ("+s_cls.Substring(0,s_cls.Length-1)+")";
			sql+=" order by id";
			dt=m.get_data(sql).Tables[0];
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=dt;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			namsinh=int.Parse(tu.Text.ToString().Substring(6,4));
			ds.Clear();
			sql="select to_char(a.ngay,'yyyymmdd') as ngay,";
			sql+=" sum(case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end) as ts,";
			sql+=" sum(case when a.kham=1 and "+namsinh+"-to_number(b.namsinh)<=6 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c01,";
			sql+=" sum(case when a.kham=1 and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c02,";
			sql+=" sum(case when a.kham=1 and "+namsinh+"-to_number(b.namsinh)>14 and b.phai=0 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c03,";
			sql+=" sum(case when a.kham=1 and "+namsinh+"-to_number(b.namsinh)>14 and b.phai=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c04,";
			sql+=" sum(case when a.kham=0 and "+namsinh+"-to_number(b.namsinh)<=6 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c05,";
			sql+=" sum(case when a.kham=0 and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c06,";
			sql+=" sum(case when a.kham=0 and "+namsinh+"-to_number(b.namsinh)>14 and b.phai=0 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c07,";
			sql+=" sum(case when a.kham=0 and "+namsinh+"-to_number(b.namsinh)>14 and b.phai=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c08,";
			sql+=" sum(case when b.matt='"+matt+"' and a.madoituong=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c09,";
			sql+=" sum(case when b.matt='"+matt+"' and "+namsinh+"-to_number(b.namsinh)<=6 and a.madoituong<>1 and c.mien=0 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c10,";
			sql+=" sum(case when b.matt='"+matt+"' and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 and a.madoituong<>1 and c.mien=0 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c11,";
			sql+=" sum(case when b.matt='"+matt+"' and "+namsinh+"-to_number(b.namsinh)<=6 and a.madoituong<>1 and c.mien=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c12,";
			sql+=" sum(case when b.matt='"+matt+"' and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 and a.madoituong<>1 and c.mien=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c13,";
			sql+=" sum(case when b.matt<>'"+matt+"' and a.madoituong=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c14,";
			sql+=" sum(case when b.matt<>'"+matt+"' and "+namsinh+"-to_number(b.namsinh)<=6 and a.madoituong<>1 and c.mien=0 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c15,";
			sql+=" sum(case when b.matt<>'"+matt+"' and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 and a.madoituong<>1 and c.mien=0 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c16,";
			sql+=" sum(case when b.matt<>'"+matt+"' and "+namsinh+"-to_number(b.namsinh)<=6 and a.madoituong<>1 and c.mien=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c17,";
			sql+=" sum(case when b.matt<>'"+matt+"' and "+namsinh+"-to_number(b.namsinh)>6 and "+namsinh+"-to_number(b.namsinh)<=14 and a.madoituong<>1 and c.mien=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c18";
			sql+=" from xxx.cls_thuchien a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql+=" inner join "+user+".doituong c on a.madoituong=c.madoituong ";
            sql+=" left join xxx.cls_mat d on a.id=d.id ";
            sql+=" inner join "+user+".cls_loai g on a.loai=g.id";
            sql+= " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai="+int.Parse(loai.SelectedValue.ToString());
			sql+=" group by to_char(a.ngay,'yyyymmdd')";
			sql+=" order by to_char(a.ngay,'yyyymmdd')";
			ds=m.get_data_mmyy(sql,tu.Text,den.Text,false);
			Cursor=Cursors.Default;
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,loai.Text.Trim().ToUpper()+","+((tu.Text==den.Text)?"Ngày :"+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text),"rpttkthcls.rpt");
				f.ShowDialog();
			}
		}
	}
}
