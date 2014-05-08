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
	/// Summary description for frmTktresosinh.
	/// </summary>
	public class frmTktresosinh : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataSet ds=new DataSet();
		private string sql;
		private System.Windows.Forms.ComboBox ditat;
		private System.Windows.Forms.ComboBox tinhtrang;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
        private MaskedTextBox.MaskedTextBox cn1;
        private Label label7;
        private Label label6;
        private MaskedTextBox.MaskedTextBox cn2;
        private Label label8;
        private ComboBox cboLanSinh;
        private Label label9;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTktresosinh(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTktresosinh));
            this.label1 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.ditat = new System.Windows.Forms.ComboBox();
            this.tinhtrang = new System.Windows.Forms.ComboBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cn1 = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cn2 = new MaskedTextBox.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboLanSinh = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(68, 7);
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
            this.den.Location = new System.Drawing.Point(184, 7);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(152, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(66, 155);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 15;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(137, 155);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // ditat
            // 
            this.ditat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ditat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ditat.Items.AddRange(new object[] {
            "Không",
            "Có"});
            this.ditat.Location = new System.Drawing.Point(68, 76);
            this.ditat.Name = "ditat";
            this.ditat.Size = new System.Drawing.Size(196, 21);
            this.ditat.TabIndex = 9;
            this.ditat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ditat_KeyDown);
            // 
            // tinhtrang
            // 
            this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Items.AddRange(new object[] {
            "Sống",
            "Chết",
            "Thai chết lưu"});
            this.tinhtrang.Location = new System.Drawing.Point(68, 53);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(196, 21);
            this.tinhtrang.TabIndex = 7;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhtrang_KeyDown);
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(68, 30);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(196, 21);
            this.phai.TabIndex = 5;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dị tật :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-4, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tình trạng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giới tính :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cn1
            // 
            this.cn1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cn1.Location = new System.Drawing.Point(68, 99);
            this.cn1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cn1.MaxLength = 4;
            this.cn1.Name = "cn1";
            this.cn1.Size = new System.Drawing.Size(40, 21);
            this.cn1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(185, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "gram";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(4, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cân nặng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cn2
            // 
            this.cn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cn2.Location = new System.Drawing.Point(144, 99);
            this.cn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cn2.MaxLength = 4;
            this.cn2.Name = "cn2";
            this.cn2.Size = new System.Drawing.Size(40, 21);
            this.cn2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(110, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "đến";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboLanSinh
            // 
            this.cboLanSinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboLanSinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLanSinh.Items.AddRange(new object[] {
            "sinh lần 1",
            "sinh lần 2 ",
            "sinh >= 3 lần"});
            this.cboLanSinh.Location = new System.Drawing.Point(68, 122);
            this.cboLanSinh.Name = "cboLanSinh";
            this.cboLanSinh.Size = new System.Drawing.Size(116, 21);
            this.cboLanSinh.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Lần sinh :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTktresosinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(272, 195);
            this.Controls.Add(this.cboLanSinh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cn2);
            this.Controls.Add(this.cn1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ditat);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTktresosinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách trẻ sơ sinh";
            this.Load += new System.EventHandler(this.frmTktresosinh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            sql ="SELECT c.mabn,c.hoten,to_number(to_char(now(),'yyyy'))-to_number(c.namsinh) as tuoi,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
			sql+="a.phai,a.cannang,a.tinhtrang,a.ditat,c.sonha||' '||c.thon||' '||f.tenpxa||','||e.tenquan||','||d.tentt as diachi,g.lansinh ";
            sql += "FROM " + m.user + ".TRESOSINH a," + m.user + ".BENHANDT b," + m.user + ".BTDBN c," + m.user + ".BTDTT d," + m.user + ".BTDQUAN e," + m.user + ".BTDPXA f,"+m.user+".ddsosinh g ";
			sql+=" where a.MAQL = b.MAQL and b.MABN = c.MABN and c.MATT = d.MATT and c.MAQU = e.MAQU and c.MAPHUONGXA = f.MAPHUONGXA and a.id_ss=g.maql ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (phai.SelectedIndex!=-1)	sql+=" and a.phai="+phai.SelectedIndex;
			if (tinhtrang.SelectedIndex!=-1) sql+=" and a.tinhtrang="+tinhtrang.SelectedIndex;
			if (ditat.SelectedIndex!=-1) sql+=" and a.ditat="+ditat.SelectedIndex;
            if (cn1.Text != "" && cn2.Text != "") sql += " and a.cannang between " + decimal.Parse(cn1.Text) + " and " + decimal.Parse(cn2.Text);
            if (cboLanSinh.SelectedIndex != -1)
            {
                if (cboLanSinh.SelectedIndex == 2)
                {
                    sql += " and g.lansinh>=3";
                }
                else
                {
                    int i_lansinh = cboLanSinh.SelectedIndex + 1;
                    sql += " and g.lansinh="+i_lansinh;
                }
            }
			ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
				return;
			}
			else
			{
                if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                ds.WriteXml("..//xml//tktresosinh.xml", XmlWriteMode.WriteSchema);
				string title=lan.Change_language_MessageText("Từ ngày ")+tu.Text+lan.Change_language_MessageText(" Đến ngày ")+den.Text;
				if (tu.Text==den.Text) title="Ngày "+tu.Text;
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title,"rptTKtresosinh.rpt");
				f.ShowDialog();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ditat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void frmTktresosinh_Load(object sender, System.EventArgs e)
		{
			phai.SelectedIndex=-1;
			tinhtrang.SelectedIndex=-1;
			ditat.SelectedIndex=-1;
		}
	}
}
