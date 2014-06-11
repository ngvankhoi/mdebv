using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace XN
{
	/// <summary>
	/// Summary description for frmThongso.
	/// </summary>
	public class frmThongso : System.Windows.Forms.Form
	{
        private gpblib.AccessData k = new gpblib.AccessData();
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butThoat;
		private System.Windows.Forms.ComboBox cboGiavp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numNgayhethong;
		private System.Windows.Forms.CheckBox chkVpkhoa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThongso()
		{
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongso));
            this.butLuu = new System.Windows.Forms.Button();
            this.butThoat = new System.Windows.Forms.Button();
            this.cboGiavp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numNgayhethong = new System.Windows.Forms.NumericUpDown();
            this.chkVpkhoa = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numNgayhethong)).BeginInit();
            this.SuspendLayout();
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(91, 85);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(68, 25);
            this.butLuu.TabIndex = 0;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butThoat
            // 
            this.butThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThoat.Image = ((System.Drawing.Image)(resources.GetObject("butThoat.Image")));
            this.butThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThoat.Location = new System.Drawing.Point(160, 85);
            this.butThoat.Name = "butThoat";
            this.butThoat.Size = new System.Drawing.Size(68, 25);
            this.butThoat.TabIndex = 1;
            this.butThoat.Text = "Kết thúc";
            this.butThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThoat.Click += new System.EventHandler(this.butThoat_Click);
            // 
            // cboGiavp
            // 
            this.cboGiavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboGiavp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiavp.Enabled = false;
            this.cboGiavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGiavp.Location = new System.Drawing.Point(16, 54);
            this.cboGiavp.Name = "cboGiavp";
            this.cboGiavp.Size = new System.Drawing.Size(296, 21);
            this.cboGiavp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khoảng cách làm việc so với ngày hệ thống";
            // 
            // numNgayhethong
            // 
            this.numNgayhethong.Location = new System.Drawing.Point(256, 7);
            this.numNgayhethong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numNgayhethong.Name = "numNgayhethong";
            this.numNgayhethong.Size = new System.Drawing.Size(56, 23);
            this.numNgayhethong.TabIndex = 5;
            // 
            // chkVpkhoa
            // 
            this.chkVpkhoa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVpkhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVpkhoa.Location = new System.Drawing.Point(84, 30);
            this.chkVpkhoa.Name = "chkVpkhoa";
            this.chkVpkhoa.Size = new System.Drawing.Size(185, 24);
            this.chkVpkhoa.TabIndex = 6;
            this.chkVpkhoa.Text = "Cập nhật vào viện phí khoa";
            this.chkVpkhoa.CheckedChanged += new System.EventHandler(this.chkVpkhoa_CheckedChanged);
            // 
            // frmThongso
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(320, 119);
            this.Controls.Add(this.cboGiavp);
            this.Controls.Add(this.numNgayhethong);
            this.Controls.Add(this.chkVpkhoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butThoat);
            this.Controls.Add(this.butLuu);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông số hệ thống";
            this.Load += new System.EventHandler(this.frmThongso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNgayhethong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void butThoat_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmThongso_Load(object sender, System.EventArgs e)
		{
			cboGiavp.DisplayMember="TEN";
			cboGiavp.ValueMember="ID";
            cboGiavp.DataSource = k.get_data("select id,ten from " + k.user + ".v_giavp order by ten").Tables[0];
            foreach (DataRow r in k.get_data("select * from " + k.user + ".gpb_thongso").Tables[0].Rows)
			{
				switch(r["id"].ToString())
				{
					case "1":cboGiavp.SelectedValue=r["value"].ToString();
						break;
					case "2":numNgayhethong.Value=decimal.Parse(r["value"].ToString());
						break;
					case "3":chkVpkhoa.Checked=r["value"].ToString()=="1";
						break;
					default:
						break;
				}
			}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			k.upd_thongso(1,"Gia vp",(cboGiavp.SelectedIndex!=-1)?cboGiavp.SelectedValue.ToString():"-1");
			k.upd_thongso(2,"Ngay lam viec",numNgayhethong.Value.ToString());
			k.upd_thongso(3,"Cap nhat vp khoa",chkVpkhoa.Checked?"1":"0");
			Cursor=Cursors.Default;
		}

		private void chkVpkhoa_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkVpkhoa.Checked)cboGiavp.Enabled=true;
			else
			{
				cboGiavp.SelectedIndex=0;
				cboGiavp.Refresh();
				cboGiavp.SelectedIndex=-1;
				cboGiavp.Refresh();
				cboGiavp.Enabled=false;
			}
		}
	}
}
