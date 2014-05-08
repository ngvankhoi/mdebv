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
	/// Summary description for frmTkdieutri.
	/// </summary>
	public class frmTkdieutri : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private MaskedTextBox.MaskedTextBox thang;
		private MaskedTextBox.MaskedTextBox nam;
		private Export exp=new Export();
		private AccessData m;
		private string tu,den,s_makp;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox time;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTkdieutri(AccessData acc,string makp)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkdieutri));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.thang = new MaskedTextBox.MaskedTextBox();
            this.nam = new MaskedTextBox.MaskedTextBox();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(120, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(116, 96);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(44, 96);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // thang
            // 
            this.thang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thang.Location = new System.Drawing.Point(52, 17);
            this.thang.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.thang.MaxLength = 2;
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(24, 23);
            this.thang.TabIndex = 1;
            this.thang.Validated += new System.EventHandler(this.thang_Validated);
            // 
            // nam
            // 
            this.nam.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(164, 17);
            this.nam.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nam.MaxLength = 4;
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(40, 23);
            this.nam.TabIndex = 3;
            this.nam.Validated += new System.EventHandler(this.nam_Validated);
            // 
            // makp
            // 
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(52, 43);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(152, 21);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(-3, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.time.Location = new System.Drawing.Point(52, 69);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(156, 16);
            this.time.TabIndex = 104;
            this.time.Text = "checkBox1";
            // 
            // frmTkdieutri
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(216, 141);
            this.Controls.Add(this.time);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTkdieutri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê điều trị nội trú";
            this.Load += new System.EventHandler(this.frmTkdieutri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkdieutri_Load(object sender, System.EventArgs e)
		{
			time.Text="Giờ báo cáo "+m.sGiobaocao;
			thang.Text=DateTime.Now.Month.ToString().PadLeft(2,'0');
			nam.Text=DateTime.Now.Year.ToString().PadLeft(4,'0');
			string sql="select * from "+m.user+".btdkp_bv where loai=0 and makp<>'01'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+="order by makp";
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=m.get_data(sql).Tables[0];

		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (thang.Text=="00" || int.Parse(thang.Text)>12)
				{
					MessageBox.Show(lan.Change_language_MessageText("Tháng không hợp lệ !"),AccessData.Msg);
					thang.Focus();
					return;
				}
				tu="01/"+thang.Text+"/"+nam.Text;
                den=DateTime.DaysInMonth(int.Parse(nam.Text),int.Parse(thang.Text)).ToString().PadLeft(2,'0')+"/"+thang.Text+"/"+nam.Text;
                string s_ngayhientai = m.ngayhienhanh_server.Substring(0, 10);
                if (m.bNgay(den, s_ngayhientai))
                {
                    den = s_ngayhientai;
                }
				
				ds=exp.upd_ththbn(tu,den,(makp.SelectedIndex==-1)?"":makp.SelectedValue.ToString(),time.Checked);
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
					return;
				}
				else
				{
					string title="Tháng "+thang.Text+" năm "+nam.Text;
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title,"rptTkdieutri.rpt");
					f.ShowDialog();
				}
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void thang_Validated(object sender, System.EventArgs e)
		{
			thang.Text=thang.Text.PadLeft(2,'0');
		}

		private void nam_Validated(object sender, System.EventArgs e)
		{
			nam.Text=nam.Text.PadLeft(4,'0');
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
