namespace Duoc
{
    partial class frmChonChinhanh
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
            this.chkCungchinhanh = new System.Windows.Forms.CheckBox();
            this.chkKhacchinhanh = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbChinhanh = new System.Windows.Forms.ComboBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkCungchinhanh
            // 
            this.chkCungchinhanh.AutoSize = true;
            this.chkCungchinhanh.Checked = true;
            this.chkCungchinhanh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCungchinhanh.Location = new System.Drawing.Point(38, 9);
            this.chkCungchinhanh.Name = "chkCungchinhanh";
            this.chkCungchinhanh.Size = new System.Drawing.Size(101, 17);
            this.chkCungchinhanh.TabIndex = 0;
            this.chkCungchinhanh.Text = "Cùng chi nhánh";
            this.chkCungchinhanh.UseVisualStyleBackColor = true;
            this.chkCungchinhanh.CheckedChanged += new System.EventHandler(this.chkCungchinhanh_CheckedChanged);
            this.chkCungchinhanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCungchinhanh_KeyDown);
            // 
            // chkKhacchinhanh
            // 
            this.chkKhacchinhanh.AutoSize = true;
            this.chkKhacchinhanh.Location = new System.Drawing.Point(38, 30);
            this.chkKhacchinhanh.Name = "chkKhacchinhanh";
            this.chkKhacchinhanh.Size = new System.Drawing.Size(104, 17);
            this.chkKhacchinhanh.TabIndex = 1;
            this.chkKhacchinhanh.Text = "Khác chi nhánh ";
            this.chkKhacchinhanh.UseVisualStyleBackColor = true;
            this.chkKhacchinhanh.CheckedChanged += new System.EventHandler(this.chkKhacchinhanh_CheckedChanged);
            this.chkKhacchinhanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCungchinhanh_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn Chi nhánh dự trù :";
            // 
            // cmbChinhanh
            // 
            this.cmbChinhanh.Enabled = false;
            this.cmbChinhanh.FormattingEnabled = true;
            this.cmbChinhanh.Location = new System.Drawing.Point(181, 56);
            this.cmbChinhanh.Name = "cmbChinhanh";
            this.cmbChinhanh.Size = new System.Drawing.Size(213, 21);
            this.cmbChinhanh.TabIndex = 2;
            this.cmbChinhanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCungchinhanh_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(225, 98);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 27);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(150, 98);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 27);
            this.butOk.TabIndex = 3;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // frmChonChinhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 147);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.cmbChinhanh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkKhacchinhanh);
            this.Controls.Add(this.chkCungchinhanh);
            this.Name = "frmChonChinhanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chi nhánh";
            this.Load += new System.EventHandler(this.frmChonChinhanh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCungchinhanh;
        private System.Windows.Forms.CheckBox chkKhacchinhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChinhanh;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butOk;
    }
}