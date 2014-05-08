using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DllPhonggiuong
{
	public class frmChonkho : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private DataTable dt;
		public string s_makho="", s_user="";
		private System.ComponentModel.Container components = null;

		public frmChonkho(DataTable dta)
		{
			InitializeComponent();
			dt=dta;
		}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChonkho));
			this.label1 = new System.Windows.Forms.Label();
			this.makho = new System.Windows.Forms.ComboBox();
			this.butOk = new System.Windows.Forms.Button();
			this.butCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Kho :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// makho
			// 
			this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makho.Location = new System.Drawing.Point(40, 16);
			this.makho.Name = "makho";
			this.makho.Size = new System.Drawing.Size(200, 21);
			this.makho.TabIndex = 1;
			this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
			// 
			// butOk
			// 
			this.butOk.Image = ((System.Drawing.Bitmap)(resources.GetObject("butOk.Image")));
			this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butOk.Location = new System.Drawing.Point(50, 52);
			this.butOk.Name = "butOk";
			this.butOk.Size = new System.Drawing.Size(74, 28);
			this.butOk.TabIndex = 2;
			this.butOk.Text = "      Đồng ý";
			this.butOk.Click += new System.EventHandler(this.butOk_Click);
			// 
			// butCancel
			// 
			this.butCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("butCancel.Image")));
			this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCancel.Location = new System.Drawing.Point(127, 52);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(74, 28);
			this.butCancel.TabIndex = 3;
			this.butCancel.Text = "&Kết thúc";
			this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// frmChonkho
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 103);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butCancel,
																		  this.butOk,
																		  this.makho,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmChonkho";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chọn kho";
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
			s_makho="";
			this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			s_makho=makho.SelectedValue.ToString().Trim()+",";
			this.Close();
		}
	}
}
