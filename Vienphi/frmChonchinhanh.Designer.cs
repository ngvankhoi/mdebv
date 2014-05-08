namespace Vienphi
{
    partial class frmChonchinhanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonchinhanh));
            this.butBoqua = new System.Windows.Forms.Button();
            this.chkChinhanh = new System.Windows.Forms.CheckedListBox();
            this.butDongy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(205, 227);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(75, 25);
            this.butBoqua.TabIndex = 1;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // chkChinhanh
            // 
            this.chkChinhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChinhanh.CheckOnClick = true;
            this.chkChinhanh.FormattingEnabled = true;
            this.chkChinhanh.Location = new System.Drawing.Point(3, 6);
            this.chkChinhanh.Name = "chkChinhanh";
            this.chkChinhanh.Size = new System.Drawing.Size(276, 214);
            this.chkChinhanh.TabIndex = 2;
            // 
            // butDongy
            // 
            this.butDongy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDongy.Image = ((System.Drawing.Image)(resources.GetObject("butDongy.Image")));
            this.butDongy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDongy.Location = new System.Drawing.Point(124, 227);
            this.butDongy.Name = "butDongy";
            this.butDongy.Size = new System.Drawing.Size(75, 25);
            this.butDongy.TabIndex = 0;
            this.butDongy.Text = "Đồng ý";
            this.butDongy.UseVisualStyleBackColor = true;
            this.butDongy.Click += new System.EventHandler(this.butDongy_Click);
            // 
            // frmChonchinhanh
            // 
            this.AcceptButton = this.butDongy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butBoqua;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.chkChinhanh);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butDongy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonchinhanh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chi nhánh";
            this.Load += new System.EventHandler(this.frmChonchinhanh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butDongy;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.CheckedListBox chkChinhanh;
    }
}