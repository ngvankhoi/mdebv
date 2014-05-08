using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Medisoft
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmDLLTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDLLTest()
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
				if (components != null) 
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "In chỉ định";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(200, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "In chi dinh trực tiếp";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 72);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(200, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Khai báo  thông số phiếu chỉ định";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// frmDLLTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 109);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button3,
																		  this.button2,
																		  this.button1});
			this.Name = "frmDLLTest";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmDLLTest());
		}

		private void frmDLLTest_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			frmPrintchidinh af = new frmPrintchidinh();
			af.f_Print_Chidinh(false,"08007792","80819075408283131","");
			af.Show();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			frmPrintchidinh af = new frmPrintchidinh();
			af.f_Print_Chidinh(true,"08007792","80819075408283131","");
			af.Show();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			frmDMThongsophieucd af = new frmDMThongsophieucd("","");
			af.ShowInTaskbar=false;
			af.ShowDialog();
		}
	}
}
