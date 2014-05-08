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
	public class frmtkbsdoc : System.Windows.Forms.Form
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
		private DataTable dtbs=new DataTable();
		private string sql,user,stime,s_cls;
		private AccessData m;
        private Label label4;
        private ComboBox may;
        private GroupBox groupBox1;
        private RadioButton rb3;
        private RadioButton rb2;
        private RadioButton rb1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmtkbsdoc(AccessData acc,string cls)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m = acc; s_cls = cls;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtkbsdoc));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.loai = new System.Windows.Forms.ComboBox();
            this.butIN = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.may = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-19, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(196, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-15, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(51, 6);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(223, 6);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(52, 30);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(252, 21);
            this.loai.TabIndex = 2;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(72, 117);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(82, 25);
            this.butIN.TabIndex = 5;
            this.butIN.Text = "&In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(156, 117);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(98, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-11, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Máy :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // may
            // 
            this.may.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.may.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.may.Location = new System.Drawing.Point(51, 54);
            this.may.Name = "may";
            this.may.Size = new System.Drawing.Size(253, 21);
            this.may.TabIndex = 3;
            this.may.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(51, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 31);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Checked = true;
            this.rb3.Location = new System.Drawing.Point(195, 10);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(56, 17);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.Text = "Tất cả";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(84, 9);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(110, 17);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Không cản quang";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(6, 9);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(77, 17);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "Cản quang";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmtkbsdoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(310, 158);
            this.Controls.Add(this.may);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmtkbsdoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê số ca đọc kết quả của bác sĩ";
            this.Load += new System.EventHandler(this.frmtkbsdoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmtkbsdoc_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			dtbs=m.get_data("select * from "+user+".dmbs").Tables[0];
			ds.ReadXml("..//..//..//xml//m_tkcls.xml");
            sql = "select * from " + user + ".cls_loai ";
            if (s_cls != "") sql += " where id in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
            sql+=" order by id";
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=m.get_data(sql).Tables[0];
            may.DisplayMember = "TEN";
            may.ValueMember = "ID";
            load_may();
		}

        private void load_may()
        {
            if (loai.SelectedIndex != -1)
            {
                sql = "select * from " + user + ".cls_may where loai=" + int.Parse(loai.SelectedValue.ToString()) + " order by id";
                may.DataSource = m.get_data(sql).Tables[0];
            }
        }

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			DataRow r1,r2,r3;
			DataRow [] dr;
			ds.Clear();
			sql="select a.mabs,count(*) as so ";
            sql+="from xxx.cls_ketqua a inner join "+user+".dmbs b on a.mabs=b.ma ";
            sql+=" inner join "+user+".cls_loai g on a.loai=g.id";
            sql += " left join xxx.cls_motact i on a.id=i.id ";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai="+int.Parse(loai.SelectedValue.ToString());
            if (rb1.Checked) sql += " and i.canquang=1";
            else if (rb2.Checked) sql += " and (i.canquang=0 or i.canquang is null)";
            if (may.SelectedIndex != -1) sql += " and a.idmay=" + int.Parse(may.SelectedValue.ToString());
			sql+=" group by a.mabs";
			foreach(DataRow r in m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0].Select("true","mabs"))
			{
				r1=m.getrowbyid(dtbs,"ma='"+r["mabs"].ToString()+"'");
				if (r1!=null)
				{
					sql=" mabn='"+r["mabs"].ToString()+"'";
					r2=m.getrowbyid(ds.Tables[0],sql);
					if (r2==null)
					{
						r3=ds.Tables[0].NewRow();
                        if (may.SelectedIndex!=-1) r3["tenkp"] = may.Text;
                        r3["ngay"] = loai.Text;
						r3["mabn"]=r["mabs"].ToString();
						r3["hoten"]=r1["hoten"].ToString();
						r3["c01"]=decimal.Parse(r["so"].ToString());
						ds.Tables[0].Rows.Add(r3);
					}
					else
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0)
							dr[0]["c01"]=decimal.Parse(dr[0]["c01"].ToString())+decimal.Parse(r["so"].ToString());
					}
				}
			}
			Cursor=Cursors.Default;
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
                string title = (rb1.Checked) ? "CE, " : (rb2.Checked) ? "NE, " : "";
                title += (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text;
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title,"rpttkbsdoc.rpt");
				f.ShowDialog();
			}
		}

        private void loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == loai) load_may();
        }
	}
}
