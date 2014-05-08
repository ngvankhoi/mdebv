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
	/// Summary description for frmMuc.
	/// </summary>
	public class frmMuc : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private AccessData m;
		private long l_id,l_doan;
		public bool bOk = false;
		private DataTable dt = new DataTable();
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox tt;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;

		public frmMuc(AccessData acc,long id,long doan,DataTable dta,string title)
		{
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 

            m = acc; l_id = id; l_doan = doan; dt = dta; this.Text = "Mục đăng ký đoàn " + title;
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuc));
            this.namsinh = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ComboBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(104, 59);
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(38, 21);
            this.namsinh.TabIndex = 6;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            this.namsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Năm sinh :";
            // 
            // tt
            // 
            this.tt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tt.Items.AddRange(new object[] {
            "<",
            "<=",
            "=",
            ">",
            ">="});
            this.tt.Location = new System.Drawing.Point(62, 58);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(39, 21);
            this.tt.TabIndex = 5;
            this.tt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(62, 35);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(80, 21);
            this.phai.TabIndex = 3;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Giới tính :";
            // 
            // stt
            // 
            this.stt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(62, 12);
            this.stt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(50, 21);
            this.stt.TabIndex = 1;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Stt :";
            // 
            // butBoqua
            // 
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(96, 91);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 8;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(34, 91);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 7;
            this.butLuu.Text = "     Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // frmMuc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(190, 131);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tt);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.stt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMuc";
            this.Load += new System.EventHandler(this.frmMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void stt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void namsinh_Validated(object sender, EventArgs e)
		{
			if (namsinh.Text!="")
				if (namsinh.Text.Length < 4) 
					namsinh.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text));
		}

		private void frmMuc_Load(object sender, EventArgs e)
		{
			tt.SelectedIndex = 0;
			if (l_id != 0)
			{
				DataRow r = m.getrowbyid(dt, "id=" + l_id);
				if (r != null)
				{
					stt.Value = decimal.Parse(r["stt"].ToString());
					phai.SelectedIndex = int.Parse(r["phai"].ToString());
					tt.Text = r["tt"].ToString();
					namsinh.Text = r["namsinh"].ToString();
				}
			}
			else
				stt.Value = Convert.ToDecimal(dt.Rows.Count + 1);
		}

		private void butBoqua_Click(object sender, EventArgs e)
		{
			m.close();this.Close();
		}

		private void butLuu_Click(object sender, EventArgs e)
		{
			if (l_id == 0) l_id = m.getidyymmddhhmiss_stt_computer;
			string _ghichu = "";
			_ghichu = (phai.SelectedIndex != -1) ? phai.Text : "";
			if (namsinh.Text != "") _ghichu += tt.Text + namsinh.Text;
			m.upd_kskmuc(l_id, l_doan, stt.Value, phai.SelectedIndex, tt.Text, namsinh.Text, (_ghichu!="")?_ghichu:"Tất cả");
			bOk = true;
			m.close();this.Close();
		}
	}
}
