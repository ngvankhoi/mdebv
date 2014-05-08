using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmTim.
	/// </summary>
	public class frmTimsochitiet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button butCancel;
		private rptSochitiet parent;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTimsochitiet(rptSochitiet p)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			parent=p;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTimsochitiet));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.butCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tên cần tìm :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(80, 20);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(176, 23);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// butCancel
			// 
			this.butCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("butCancel.Image")));
			this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCancel.Location = new System.Drawing.Point(96, 64);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(80, 28);
			this.butCancel.TabIndex = 1;
			this.butCancel.Text = "Kết thúc";
			this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// frmTimsochitiet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 117);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butCancel,
																		  this.textBox1,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTimsochitiet";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tìm kiếm";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			parent.RefreshChildren("");
			this.Close();
		}

		public void RefreshText(string text)
		{
			textBox1.Text = text;
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			parent.RefreshChildren(textBox1.Text);			
		}

		private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode.ToString()=="Enter")
				SendKeys.Send("{Tab}");
		}

	}
}
