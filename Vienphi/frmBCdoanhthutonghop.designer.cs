namespace Vienphi
{
    partial class frmBCdoanhthutonghop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCdoanhthutonghop));
            this.user_thu = new System.Windows.Forms.CheckedListBox();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // user_thu
            // 
            this.user_thu.FormattingEnabled = true;
            this.user_thu.Location = new System.Drawing.Point(12, 35);
            this.user_thu.Name = "user_thu";
            this.user_thu.Size = new System.Drawing.Size(251, 199);
            this.user_thu.TabIndex = 47;
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(48, 8);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(83, 20);
            this.ngay.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "Từ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(127, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "Đến";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(171, 9);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(83, 20);
            this.den.TabIndex = 51;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(120, 235);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(82, 26);
            this.butKetthuc.TabIndex = 46;
            this.butKetthuc.Text = "   &Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(38, 235);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(82, 26);
            this.butIN.TabIndex = 44;
            this.butIN.Text = "&In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // frmBCdoanhthutonghop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 266);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user_thu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label1);
            this.Name = "frmBCdoanhthutonghop";
            this.Text = "Báo cáo doanh thu tổng hợp";
            this.Load += new System.EventHandler(this.frmBCdoanhthutonghop_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox user_thu;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butIN;
        private System.Windows.Forms.DateTimePicker ngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker den;
    }
}