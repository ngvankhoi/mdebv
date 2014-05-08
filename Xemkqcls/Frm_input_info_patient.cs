using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;


namespace frmCanlamsan
{
	/// <summary>
	/// Summary description for Frm_input_info_patient.
	/// </summary>
	public class Frm_input_info_patient : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtmabn;
		private System.Windows.Forms.Button btnok;
		private System.Windows.Forms.Button btncancel;
		private System.Windows.Forms.TextBox txtname;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;		
		private System.Windows.Forms.CheckBox chkall;
		private bool blnall=false;
		private string pstrmabn;
			 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_input_info_patient(string strmabn)
		{
			InitializeComponent();
			txtmabn.Text=strmabn;
			pstrmabn=strmabn;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_input_info_patient));
            this.txtmabn = new System.Windows.Forms.TextBox();
            this.btnok = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtmabn
            // 
            this.txtmabn.Location = new System.Drawing.Point(24, 56);
            this.txtmabn.Name = "txtmabn";
            this.txtmabn.Size = new System.Drawing.Size(56, 20);
            this.txtmabn.TabIndex = 1;
            this.txtmabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(48, 104);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(72, 24);
            this.btnok.TabIndex = 4;
            this.btnok.Text = "&Đồng ý";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(136, 104);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(72, 24);
            this.btncancel.TabIndex = 5;
            this.btncancel.Text = "&Kết Thúc";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(80, 56);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(160, 20);
            this.txtname.TabIndex = 2;
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtname_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(16, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nhập họ tên hoặc mã của bệnh nhân cân truy xuất";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã BN";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(80, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Họ Tên";
            // 
            // chkall
            // 
            this.chkall.Location = new System.Drawing.Point(24, 80);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(88, 16);
            this.chkall.TabIndex = 9;
            this.chkall.Text = "Chọn tất cả";
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // Frm_input_info_patient
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(264, 133);
            this.Controls.Add(this.chkall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.txtmabn);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.txtname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_input_info_patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin";
            this.Load += new System.EventHandler(this.Frm_input_info_patient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btncancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void txtmabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.ToString()=="Enter")
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void txtname_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		
			if(e.KeyCode.ToString()=="Enter")
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void txtdt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.ToString()=="Enter")
			{
				SendKeys.Send("{Tab}");
			}
		}


		private void chkall_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkall.Checked)
			{
				blnall=true;
				txtmabn.Text="";
			}

			else
			{
				blnall=false;
				txtmabn.Text=pstrmabn;
			}
		    
		}

		private void Frm_input_info_patient_Load(object sender, System.EventArgs e)
		{
		
		}

        private void btnok_Click(object sender, EventArgs e)
        {

        }
		
	}
}

