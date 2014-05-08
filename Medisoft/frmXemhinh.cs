using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXemhinh.
	/// </summary>
	public class frmXemhinh : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Button butExit;
		private byte[] image;
		private Bitmap map;
		private System.IO.MemoryStream memo;
		private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXemhinh(string hoten,byte [] _image)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Text=hoten;
			image=_image;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmXemhinh));
			this.pic = new System.Windows.Forms.PictureBox();
			this.butExit = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pic
			// 
			this.pic.BackColor = System.Drawing.SystemColors.HighlightText;
			this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pic.Image = ((System.Drawing.Bitmap)(resources.GetObject("pic.Image")));
			this.pic.Name = "pic";
			this.pic.Size = new System.Drawing.Size(272, 208);
			this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pic.TabIndex = 308;
			this.pic.TabStop = false;
			// 
			// butExit
			// 
			this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butExit.Image = ((System.Drawing.Bitmap)(resources.GetObject("butExit.Image")));
			this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butExit.Location = new System.Drawing.Point(109, 224);
			this.butExit.Name = "butExit";
			this.butExit.Size = new System.Drawing.Size(70, 25);
			this.butExit.TabIndex = 309;
			this.butExit.Text = "&Kết thúc";
			this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butExit.Click += new System.EventHandler(this.butExit_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.pic});
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(272, 208);
			this.panel1.TabIndex = 310;
			// 
			// frmXemhinh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.butExit;
			this.ClientSize = new System.Drawing.Size(288, 269);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.butExit});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmXemhinh";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmXemhinh";
			this.Load += new System.EventHandler(this.frmXemhinh_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmXemhinh_Load(object sender, System.EventArgs e)
		{
			memo = new MemoryStream(image);
			map = new Bitmap(Image.FromStream(memo));
			pic.Image = (Bitmap)map;
			pic.Tag = image;
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			System.GC.Collect();
			this.Close();
		}
	}
}
