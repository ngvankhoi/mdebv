namespace Server
{
    partial class frmHuongdan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHuongdan));
            this.txtHuongdan = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtHuongdan
            // 
            this.txtHuongdan.BackColor = System.Drawing.Color.White;
            this.txtHuongdan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHuongdan.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHuongdan.Location = new System.Drawing.Point(0, 0);
            this.txtHuongdan.Name = "txtHuongdan";
            this.txtHuongdan.ReadOnly = true;
            this.txtHuongdan.Size = new System.Drawing.Size(499, 484);
            this.txtHuongdan.TabIndex = 0;
            this.txtHuongdan.Text = resources.GetString("txtHuongdan.Text");
            // 
            // frmHuongdan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 484);
            this.Controls.Add(this.txtHuongdan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHuongdan";
            this.ShowInTaskbar = false;
            this.Text = "Hướng dẫn sử dụng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHuongdan_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtHuongdan;
    }
}