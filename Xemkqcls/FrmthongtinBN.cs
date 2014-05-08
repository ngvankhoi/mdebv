using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace frmCanlamsan
{
	/// <summary>
	/// Summary description for FrmthongtinBN.
	/// </summary>
	public class FrmthongtinBN : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmthongtinBN()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.listView1 = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(592, 416);
			this.listView1.TabIndex = 1;
			// 
			// FrmthongtinBN
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 413);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listView1});
			this.Name = "FrmthongtinBN";
			this.Text = "FrmthongtinBN";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
