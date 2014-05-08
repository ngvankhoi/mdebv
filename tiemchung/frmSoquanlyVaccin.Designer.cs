namespace tiemchung
{
    partial class frmSoquanlyVaccin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoquanlyVaccin));
            this.tungay = new System.Windows.Forms.DateTimePicker();
            this.denngay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chkVxDv = new System.Windows.Forms.CheckBox();
            this.butin = new System.Windows.Forms.Button();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tungay
            // 
            this.tungay.CustomFormat = "dd/MM/yyyy";
            this.tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tungay.Location = new System.Drawing.Point(59, 15);
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(100, 20);
            this.tungay.TabIndex = 0;
            // 
            // denngay
            // 
            this.denngay.CustomFormat = "dd/MM/yyyy";
            this.denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.denngay.Location = new System.Drawing.Point(242, 15);
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(100, 20);
            this.denngay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến ngày";
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(272, 92);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 20;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chkVxDv
            // 
            this.chkVxDv.AutoSize = true;
            this.chkVxDv.Checked = true;
            this.chkVxDv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVxDv.Location = new System.Drawing.Point(15, 51);
            this.chkVxDv.Name = "chkVxDv";
            this.chkVxDv.Size = new System.Drawing.Size(97, 17);
            this.chkVxDv.TabIndex = 21;
            this.chkVxDv.Text = "Vaccin dịch vụ";
            this.chkVxDv.UseVisualStyleBackColor = true;
            // 
            // butin
            // 
            this.butin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butin.Image = ((System.Drawing.Image)(resources.GetObject("butin.Image")));
            this.butin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butin.Location = new System.Drawing.Point(202, 92);
            this.butin.Name = "butin";
            this.butin.Size = new System.Drawing.Size(70, 25);
            this.butin.TabIndex = 22;
            this.butin.Text = "&In";
            this.butin.Click += new System.EventHandler(this.butin_Click);
            // 
            // chkXml
            // 
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(15, 97);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 23;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // frmSoquanlyVaccin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 129);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.butin);
            this.Controls.Add(this.chkVxDv);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.denngay);
            this.Controls.Add(this.tungay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSoquanlyVaccin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ quản lý Vaccine";
            this.Load += new System.EventHandler(this.frmSoquanlyVaccin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker tungay;
        private System.Windows.Forms.DateTimePicker denngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.CheckBox chkVxDv;
        private System.Windows.Forms.Button butin;
        private System.Windows.Forms.CheckBox chkXml;
    }
}