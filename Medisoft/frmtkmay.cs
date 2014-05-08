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
	public class frmtkmay : System.Windows.Forms.Form
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
		private string sql,user,stime,s_cls,s_madoituong;
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

		public frmtkmay(AccessData acc,string cls)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtkmay));
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
            this.label1.Location = new System.Drawing.Point(-14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(190, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-11, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(51, 10);
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
            this.den.Location = new System.Drawing.Point(223, 10);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(51, 34);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(253, 21);
            this.loai.TabIndex = 5;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(74, 123);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(84, 25);
            this.butIN.TabIndex = 9;
            this.butIN.Text = "&In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(160, 123);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(95, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-11, 58);
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
            this.may.Location = new System.Drawing.Point(51, 58);
            this.may.Name = "may";
            this.may.Size = new System.Drawing.Size(253, 21);
            this.may.TabIndex = 7;
            this.may.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(51, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 31);
            this.groupBox1.TabIndex = 11;
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
            // 
            // frmtkmay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(319, 167);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.may);
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
            this.Name = "frmtkmay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê theo máy";
            this.Load += new System.EventHandler(this.frmtkmay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmtkmay_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
            s_madoituong = "";
            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where trasau=1 order by madoituong";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows) s_madoituong += r["madoituong"].ToString().PadLeft(2,'0') + ",";
			ds.ReadXml("..//..//..//xml//m_tkclsds.xml");
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
			DataRow r1,r2;
			DataRow [] dr;
			ds.Clear();
            int ma = 0;
            string ten = "";
            decimal c01, c02, c03, c04, c05, c06,c07,c08;
            sql = "select case when c.trasau=1 then 6 else case when a.madoituong=4 then 5 else case when a.lt-a.cp=0 then 1 else case when a.lt-a.cp=a.lt or a.madoituong=3 then 2 else case when a.cp=a.lt/2 then 3 else 4 end end end end end as ma,";
            sql+=" case when b.canquang is null then 0 else b.canquang end as canquang,sum(1) as ca,sum(abs(a.lt)) as lt,sum(abs(a.cp)) as cp";
            sql += " from xxx.cls_ketqua a left join xxx.cls_motact b on a.id=b.id ";
            sql += " inner join " + user + ".doituong c on a.madoituong=c.madoituong ";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai="+int.Parse(loai.SelectedValue.ToString());
            if (rb1.Checked) sql += " and b.canquang=1";
            else if (rb2.Checked) sql += " and (b.canquang=0 or b.canquang is null)";
            if (may.SelectedIndex != -1) sql += " and a.idmay=" + int.Parse(may.SelectedValue.ToString());
            sql += " group by case when c.trasau=1 then 6 else case when a.madoituong=4 then 5 else case when a.lt-a.cp=0 then 1 else case when a.lt-a.cp=a.lt or a.madoituong=3 then 2 else case when a.cp=a.lt/2 then 3 else 4 end end end end end,";
            sql += " case when b.canquang is null then 0 else b.canquang end";
			foreach(DataRow r in m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0].Select("true","ma"))
			{
                if (r["cp"].ToString() != "" && r["lt"].ToString() != "")
                {
                    ten = "";
                    c01 = 0; c02 = 0; c03 = 0; c04 = 0; c05 = 0; c06 = 0; c07 = 0; c08 = 0;
                    ma = int.Parse(r["ma"].ToString());
                    if (ma == 6)
                    {
                        if (r["canquang"].ToString() == "0")
                        {
                            c05 = decimal.Parse(r["ca"].ToString()); c06 = decimal.Parse(r["cp"].ToString());
                        }
                        else
                        {
                            c07 = decimal.Parse(r["ca"].ToString()); c08 = decimal.Parse(r["cp"].ToString());
                        }
                    }
                    else
                    {
                        switch (ma)
                        {
                            case 1: ten = "Thu đủ"; break;
                            case 2: ten = "Miễn phí"; break;
                            case 3: ten = "Thu 50%"; break;
                            case 4: ten = "Giảm khác"; break;
                            case 5: ten = "Thu khác"; break;
                        }
                        if (r["canquang"].ToString() == "0")
                        {
                            c01 = decimal.Parse(r["ca"].ToString()); c02 = decimal.Parse(r["cp"].ToString());
                        }
                        else
                        {
                            c03 = decimal.Parse(r["ca"].ToString()); c04 = decimal.Parse(r["cp"].ToString());
                        }
                    }
                    sql = "ma=" + ma;
                    r1 = m.getrowbyid(ds.Tables[0], sql);
                    if (r1 == null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["ma"] = ma;
                        r2["ten"] = ten;
                        r2["may"] = may.Text;
                        r2["c01"] = c01;
                        r2["c02"] = c02;
                        r2["c03"] = c03;
                        r2["c04"] = c04;
                        r2["c05"] = c05;
                        r2["c06"] = c06;
                        r2["c07"] = c07;
                        r2["c08"] = c08;
                        r2["c09"] = decimal.Parse(r["lt"].ToString());
                        r2["c10"] = decimal.Parse(r["cp"].ToString());
                        ds.Tables[0].Rows.Add(r2);
                    }
                    else
                    {
                        dr = ds.Tables[0].Select(sql);
                        if (dr.Length > 0)
                        {
                            dr[0]["c01"] = decimal.Parse(dr[0]["c01"].ToString()) + c01;
                            dr[0]["c02"] = decimal.Parse(dr[0]["c02"].ToString()) + c02;
                            dr[0]["c03"] = decimal.Parse(dr[0]["c03"].ToString()) + c03;
                            dr[0]["c04"] = decimal.Parse(dr[0]["c04"].ToString()) + c04;
                            dr[0]["c05"] = decimal.Parse(dr[0]["c05"].ToString()) + c05;
                            dr[0]["c06"] = decimal.Parse(dr[0]["c06"].ToString()) + c06;
                            dr[0]["c07"] = decimal.Parse(dr[0]["c07"].ToString()) + c07;
                            dr[0]["c08"] = decimal.Parse(dr[0]["c08"].ToString()) + c08;
                            dr[0]["c09"] = decimal.Parse(dr[0]["c09"].ToString()) + decimal.Parse(r["lt"].ToString());
                            dr[0]["c10"] = decimal.Parse(dr[0]["c10"].ToString()) + decimal.Parse(r["cp"].ToString());
                        }
                    }
                    if (ma == 6)
                    {
                        ma = 1;
                        sql = "ma=" + ma;
                        r1 = m.getrowbyid(ds.Tables[0], sql);
                        if (r1 == null)
                        {
                            r2 = ds.Tables[0].NewRow();
                            r2["ma"] = ma;
                            r2["ten"] = ten;
                            r2["may"] = may.Text;
                            r2["c01"] = c05;
                            r2["c02"] = c06;
                            r2["c03"] = c07;
                            r2["c04"] = c08;
                            r2["c05"] = 0;
                            r2["c06"] = 0;
                            r2["c07"] = 0;
                            r2["c08"] = 0;
                            r2["c09"] = decimal.Parse(r["lt"].ToString());
                            r2["c10"] = decimal.Parse(r["cp"].ToString());
                            ds.Tables[0].Rows.Add(r2);
                        }
                        else
                        {
                            dr = ds.Tables[0].Select(sql);
                            if (dr.Length > 0)
                            {
                                dr[0]["c01"] = decimal.Parse(dr[0]["c01"].ToString()) + c05;
                                dr[0]["c02"] = decimal.Parse(dr[0]["c02"].ToString()) + c06;
                                dr[0]["c03"] = decimal.Parse(dr[0]["c03"].ToString()) + c07;
                                dr[0]["c04"] = decimal.Parse(dr[0]["c04"].ToString()) + c08;
                            }
                        }
                    }
                }
			}
            for (ma = 1; ma < 6; ma++)
            {
                switch (ma)
                {
                    case 1: ten = "Thu đủ"; break;
                    case 2: ten = "Miễn phí"; break;
                    case 3: ten = "Thu 50%"; break;
                    case 4: ten = "Giảm khác"; break;
                    case 5: ten = "Thu khác"; break;
                }
                sql = "ma=" + ma;
                r1 = m.getrowbyid(ds.Tables[0], sql);
                if (r1 == null)
                {
                    r2 = ds.Tables[0].NewRow();
                    r2["ma"] = ma;
                    r2["ten"] = ten;
                    r2["may"] = may.Text;
                    r2["c01"] = 0;
                    r2["c02"] = 0;
                    r2["c03"] = 0;
                    r2["c04"] = 0;
                    r2["c05"] = 0;
                    r2["c06"] = 0;
                    r2["c07"] = 0;
                    r2["c08"] = 0;
                    r2["c09"] = 0;
                    r2["c10"] = 0;
                    ds.Tables[0].Rows.Add(r2);
                }
            }
			Cursor=Cursors.Default;
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,(tu.Text==den.Text)?"Ngày :"+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,"rpttkmay.rpt");
				f.ShowDialog();
			}
		}

        private void loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == loai) load_may();
        }
	}
}
