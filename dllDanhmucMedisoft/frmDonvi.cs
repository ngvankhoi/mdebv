using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmDonvi.
	/// </summary>
	public class frmDonvi : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private AccessData m;
		private decimal l_doan,l_donvi;
		private int i_userid;
		private string ma = "";
		public bool bOk = false;
		private DataTable dt = new DataTable();

		private System.Windows.Forms.TextBox ten;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;

		public frmDonvi(AccessData acc,decimal doan,decimal donvi,int userid,DataTable dta,string title)
		{
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 
            
			m = acc; l_doan = doan; l_donvi = donvi; i_userid = userid; dt = dta;
            this.Text = "Đơn vị đoàn " + title; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonvi));
            this.ten = new System.Windows.Forms.TextBox();
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(47, 31);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(234, 21);
            this.ten.TabIndex = 3;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // den
            // 
            this.den.BackColor = System.Drawing.SystemColors.HighlightText;
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(47, 79);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(70, 21);
            this.den.TabIndex = 7;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(47, 55);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(70, 21);
            this.tu.TabIndex = 5;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "đến :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Từ :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Tên :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stt :";
            // 
            // stt
            // 
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(47, 8);
            this.stt.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(39, 21);
            this.stt.TabIndex = 1;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(85, 111);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 8;
            this.butLuu.Text = "    Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(155, 111);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 9;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // frmDonvi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(293, 155);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDonvi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn vị";
            this.Load += new System.EventHandler(this.frmDonvi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDonvi_Load(object sender, EventArgs e)
		{
			if (l_donvi != 0)
			{
				DataRow r = m.getrowbyid(dt, "id=" + l_donvi);
				if (r != null)
				{
					stt.Value = decimal.Parse(r["stt"].ToString());
					ma = r["ma"].ToString();
					ten.Text = r["ten"].ToString();
					tu.Text = r["tu"].ToString();
					den.Text = r["den"].ToString();
				}
			}
			else
			{
				stt.Value = Convert.ToDecimal(dt.Rows.Count + 1);
				if (dt.Rows.Count > 0)
				{
					tu.Text = dt.Rows[0]["tu"].ToString();
					den.Text = dt.Rows[0]["den"].ToString();
				}
				else
				{
					tu.Text = m.ngayhienhanh_server.Substring(0, 10);
					den.Text = tu.Text;
				}
			}
		}

		private void stt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
		}

		private bool kiemtra()
		{
			if (ten.Text == "")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tên đơn vị !"), LibMedi.AccessData.Msg);
				ten.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, EventArgs e)
		{
			if (!kiemtra()) return;
			if (l_donvi == 0)
			{
				l_donvi = m.getidyymmddhhmiss_stt_computer;
				ma = m.get_ma_kskdonvi(l_doan);
			}
			m.upd_kskdonvi(l_donvi, l_doan, stt.Value, ma, ten.Text, tu.Text, den.Text, i_userid);
			bOk = true;
			m.close();this.Close();
		}

		private void butBoqua_Click(object sender, EventArgs e)
		{
			m.close();this.Close();
		}

		private void tu_Validated(object sender, EventArgs e)
		{
			if (tu.Text == "")
			{
				tu.Focus();
				return;
			}
			tu.Text = tu.Text.Trim();
			if (tu.Text.Length == 6) tu.Text = tu.Text + DateTime.Now.Year.ToString();
			if (tu.Text.Length < 10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày!"), LibMedi.AccessData.Msg);
				tu.Focus();
				return;
			}
			if (!m.bNgay(tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
				tu.Focus();
				return;
			}
		}

		private void den_Validated(object sender, EventArgs e)
		{
			if (den.Text == "")
			{
				den.Focus();
				return;
			}
			den.Text = den.Text.Trim();
			if (den.Text.Length == 6) den.Text = den.Text + DateTime.Now.Year.ToString();
			if (den.Text.Length < 10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày!"), LibMedi.AccessData.Msg);
				den.Focus();
				return;
			}
			if (!m.bNgay(den.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				den.Focus();
				return;
			}
			if (!m.bNgay(den.Text, tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"),LibMedi.AccessData.Msg);
				den.Focus();
				return;
			}
		}
	}
}
