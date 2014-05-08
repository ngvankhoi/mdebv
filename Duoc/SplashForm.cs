using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Duoc
{
	/// <summary>
	/// Summary description for SplashForm.
	/// </summary>
	public class SplashForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer tmrIncrementBar;
		private ProgressBarControl.Progress status;
        private Label lStatusInfo;
		private System.ComponentModel.IContainer components;

		public SplashForm()
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

		public string StatusInfo 
		{
			set 
			{
				_StatusInfo = value;
				ChangeStatusText();
			}
			get 
			{
				return _StatusInfo;
			}
		}

		public void ChangeStatusText() 
		{
			try 
			{
				if (this.InvokeRequired) 
				{
					this.Invoke(new MethodInvoker(this.ChangeStatusText));
					return;
				}

				lStatusInfo.Text = _StatusInfo;
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
		}
		private string _StatusInfo = "";

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrIncrementBar = new System.Windows.Forms.Timer(this.components);
            this.status = new ProgressBarControl.Progress();
            this.lStatusInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 232);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tmrIncrementBar
            // 
            this.tmrIncrementBar.Tick += new System.EventHandler(this.tmrIncrementBar_Tick);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 250);
            this.status.Maximum = 100;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(264, 32);
            this.status.Step = 10;
            this.status.TabIndex = 3;
            // 
            // lStatusInfo
            // 
            this.lStatusInfo.BackColor = System.Drawing.Color.White;
            this.lStatusInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatusInfo.Location = new System.Drawing.Point(0, 233);
            this.lStatusInfo.Name = "lStatusInfo";
            this.lStatusInfo.Size = new System.Drawing.Size(264, 22);
            this.lStatusInfo.TabIndex = 4;
            this.lStatusInfo.Text = "Connecting to PostgreSQL Database Server ";
            this.lStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(264, 280);
            this.Controls.Add(this.lStatusInfo);
            this.Controls.Add(this.status);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void tmrIncrementBar_Tick(object sender, System.EventArgs e)
		{
			status.PerformStep();
			if (status.Maximum == status.Value)
			{
				tmrIncrementBar.Enabled = false;
			}
		}

		private void SplashForm_Load(object sender, System.EventArgs e)
		{
			tmrIncrementBar.Enabled = false;

			status.Value = 0;
			status.Maximum = 20;
			status.Step = 1;

			tmrIncrementBar.Enabled = true;
		}
	}
}
