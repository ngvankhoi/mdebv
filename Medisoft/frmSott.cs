using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSott.
	/// </summary>
	public class frmSott : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label lbl;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSott(string stt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lbl.Text=stt;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSott));
			this.butKetthuc = new System.Windows.Forms.Button();
			this.lbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// butKetthuc
			// 
			this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butKetthuc.Location = new System.Drawing.Point(162, 80);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(61, 25);
			this.butKetthuc.TabIndex = 0;
			this.butKetthuc.Text = "Kết thúc";
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// lbl
			// 
			this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl.ForeColor = System.Drawing.Color.Red;
			this.lbl.Location = new System.Drawing.Point(4, 16);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(376, 48);
			this.lbl.TabIndex = 1;
			this.lbl.Text = "label1";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmSott
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.butKetthuc;
			this.ClientSize = new System.Drawing.Size(384, 120);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lbl,
																		  this.butKetthuc});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmSott";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmSott";
			this.ResumeLayout(false);

		}
		#endregion

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			System.GC.Collect();
			this.Close();
		}
	}
}
