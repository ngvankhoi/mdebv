namespace Medisoft
{
    partial class frmTK_baolucgiadinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTK_baolucgiadinh));
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIN = new System.Windows.Forms.Button();
            this.tungay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.denngay = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(169, 76);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(69, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "   &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(100, 76);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(69, 25);
            this.butIN.TabIndex = 6;
            this.butIN.Text = "    &In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // tungay
            // 
            this.tungay.CustomFormat = "dd/MM/yyyy";
            this.tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tungay.Location = new System.Drawing.Point(62, 22);
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(98, 20);
            this.tungay.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Đến ngày:";
            // 
            // denngay
            // 
            this.denngay.CustomFormat = "dd/MM/yyyy";
            this.denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.denngay.Location = new System.Drawing.Point(221, 22);
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(98, 20);
            this.denngay.TabIndex = 11;
            // 
            // frmTK_baolucgiadinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 133);
            this.Controls.Add(this.denngay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tungay);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(347, 171);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(347, 171);
            this.Name = "frmTK_baolucgiadinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê bệnh nhân bạo lực gia đình";
            this.Load += new System.EventHandler(this.frmTK_baolucgiadinh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private haison haison1;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butIN;
        private System.Windows.Forms.DateTimePicker tungay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker denngay;
    }
}