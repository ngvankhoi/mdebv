namespace Server
{
    partial class frmchonngay
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
            this.butOK = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.txtTu = new System.Windows.Forms.DateTimePicker();
            this.txtDen = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(41, 64);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(101, 26);
            this.butOK.TabIndex = 0;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(148, 64);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(101, 26);
            this.butClose.TabIndex = 1;
            this.butClose.Text = "Kết thúc";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // txtTu
            // 
            this.txtTu.CustomFormat = "dd/MM/yyyy";
            this.txtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTu.Location = new System.Drawing.Point(48, 21);
            this.txtTu.Name = "txtTu";
            this.txtTu.Size = new System.Drawing.Size(91, 20);
            this.txtTu.TabIndex = 2;
            // 
            // txtDen
            // 
            this.txtDen.CustomFormat = "dd/MM/yyyy";
            this.txtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDen.Location = new System.Drawing.Point(181, 21);
            this.txtDen.Name = "txtDen";
            this.txtDen.Size = new System.Drawing.Size(91, 20);
            this.txtDen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến :";
            // 
            // frmchonngay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 102);
            this.Controls.Add(this.txtDen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTu);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butOK);
            this.Name = "frmchonngay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn ngày";
            this.Load += new System.EventHandler(this.frmchonngay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.DateTimePicker txtTu;
        private System.Windows.Forms.DateTimePicker txtDen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}