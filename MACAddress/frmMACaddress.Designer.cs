namespace Medisoft2009.MACAddress
{
    partial class frmMACaddress
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
            this.lblCach1 = new System.Windows.Forms.Label();
            this.aq = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblCach1
            // 
            this.lblCach1.Location = new System.Drawing.Point(56, 67);
            this.lblCach1.Name = "lblCach1";
            this.lblCach1.Size = new System.Drawing.Size(178, 23);
            this.lblCach1.TabIndex = 0;
            this.lblCach1.Text = "label1";
            this.lblCach1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aq
            // 
            this.aq.Location = new System.Drawing.Point(12, 103);
            this.aq.Name = "aq";
            this.aq.ReadOnly = true;
            this.aq.Size = new System.Drawing.Size(260, 96);
            this.aq.TabIndex = 2;
            this.aq.Text = "";
            // 
            // frmMACaddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.aq);
            this.Controls.Add(this.lblCach1);
            this.Name = "frmMACaddress";
            this.Text = "MAC address";
            this.Load += new System.EventHandler(this.frmMACaddress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCach1;
        private System.Windows.Forms.RichTextBox aq;
    }
}

