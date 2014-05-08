using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmChonkho.
	/// </summary>
	public class frmChonkhudt : System.Windows.Forms.Form
	{
        Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private DataTable dt;
		public string s_makho="";
		public int nhom=0, i_khudt=0;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChonkhudt(DataTable dta)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			dt=dta;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonkhudt));
            this.label1 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cơ sở (khu)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(76, 49);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(200, 21);
            this.makho.TabIndex = 1;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(91, 85);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "      Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(162, 85);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(47, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "ĐỀ NGHỊ CHỌN CƠ SỞ LÀM VIỆC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChonkhudt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(288, 134);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonkhudt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn cơ sở (khu)";
            this.Load += new System.EventHandler(this.frmChonkho_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void makho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makho.SelectedIndex==-1 && makho.Items.Count>0) makho.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void frmChonkho_Load(object sender, System.EventArgs e)
		{
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			makho.DataSource=dt;
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			//s_makho="";
            i_khudt = 0;
			System.GC.Collect();
			this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
            if (makho.Items.Count > 0 && makho.SelectedIndex < 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn cơ sở."));
                makho.Focus();
                return;
            }
            if (makho.Items.Count == 0) i_khudt = 0;
            else i_khudt = int.Parse(makho.SelectedValue.ToString());			
			System.GC.Collect();
			this.Close();
		}
	}
}
