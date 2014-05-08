using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DLLPrintchidinh
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmDLLTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
        private MaskedTextBox txtmabn;
        private MaskedTextBox txtmaql;
        private DateTimePicker txtngay;
        private MaskedTextBox txtid;
        private Label label1;
        private Label label3;
        private Label label4;
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
            this.txtmabn = new System.Windows.Forms.MaskedTextBox();
            this.txtmaql = new System.Windows.Forms.MaskedTextBox();
            this.txtngay = new System.Windows.Forms.DateTimePicker();
            this.txtid = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "In chỉ định";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "In chi dinh trực tiếp";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 122);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Khai báo  thông số phiếu chỉ định";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtmabn
            // 
            this.txtmabn.Location = new System.Drawing.Point(52, 34);
            this.txtmabn.Name = "txtmabn";
            this.txtmabn.Size = new System.Drawing.Size(72, 20);
            this.txtmabn.TabIndex = 3;
            // 
            // txtmaql
            // 
            this.txtmaql.Location = new System.Drawing.Point(181, 34);
            this.txtmaql.Name = "txtmaql";
            this.txtmaql.Size = new System.Drawing.Size(125, 20);
            this.txtmaql.TabIndex = 4;
            // 
            // txtngay
            // 
            this.txtngay.CustomFormat = "dd/MM/yyyy";
            this.txtngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtngay.Location = new System.Drawing.Point(39, 9);
            this.txtngay.Name = "txtngay";
            this.txtngay.Size = new System.Drawing.Size(85, 20);
            this.txtngay.TabIndex = 5;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(177, 9);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(125, 20);
            this.txtid.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "MAQL :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID cđ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "MABN :";
            // 
            // frmDLLTest
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(309, 175);
            this.Controls.Add(this.txtmabn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtngay);
            this.Controls.Add(this.txtmaql);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmDLLTest";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

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
            af.f_Print_Chidinh(false, txtmabn.Text, txtmaql.Text,"",txtngay.Text,txtid.Text );
			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			frmPrintchidinh af = new frmPrintchidinh();
            af.f_Print_Chidinh(true, txtmabn.Text, txtmaql.Text,"", txtngay.Text, txtid.Text);
			
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			frmDMThongsophieu f = new frmDMThongsophieu("","");
			f.ShowInTaskbar=false;
			f.ShowDialog();
		}
	}
}
