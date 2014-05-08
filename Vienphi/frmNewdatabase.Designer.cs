namespace Vienphi
{
    partial class frmNewdatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewdatabase));
            this.butClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkCDHA = new System.Windows.Forms.CheckBox();
            this.chkXetnghiem = new System.Windows.Forms.CheckBox();
            this.chkVienphi = new System.Windows.Forms.CheckBox();
            this.chkDuoc = new System.Windows.Forms.CheckBox();
            this.txtMMYY = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.butDongy = new System.Windows.Forms.Button();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.BackColor = System.Drawing.SystemColors.Control;
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(173, 262);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(80, 29);
            this.butClose.TabIndex = 8;
            this.butClose.Text = "      Kết thúc";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.chkCDHA);
            this.panel2.Controls.Add(this.chkXetnghiem);
            this.panel2.Controls.Add(this.chkVienphi);
            this.panel2.Controls.Add(this.chkDuoc);
            this.panel2.Controls.Add(this.txtMMYY);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 199);
            this.panel2.TabIndex = 9;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(112, 171);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(63, 17);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "Kế toán";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(112, 148);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(56, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Lương";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(112, 125);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Nhân sự";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkCDHA
            // 
            this.chkCDHA.AutoSize = true;
            this.chkCDHA.Enabled = false;
            this.chkCDHA.Location = new System.Drawing.Point(112, 102);
            this.chkCDHA.Name = "chkCDHA";
            this.chkCDHA.Size = new System.Drawing.Size(123, 17);
            this.chkCDHA.TabIndex = 6;
            this.chkCDHA.Text = "Chẩn đoán hình ảnh";
            this.chkCDHA.UseVisualStyleBackColor = true;
            // 
            // chkXetnghiem
            // 
            this.chkXetnghiem.AutoSize = true;
            this.chkXetnghiem.Enabled = false;
            this.chkXetnghiem.Location = new System.Drawing.Point(112, 79);
            this.chkXetnghiem.Name = "chkXetnghiem";
            this.chkXetnghiem.Size = new System.Drawing.Size(79, 17);
            this.chkXetnghiem.TabIndex = 5;
            this.chkXetnghiem.Text = "Xét nghiệm";
            this.chkXetnghiem.UseVisualStyleBackColor = true;
            // 
            // chkVienphi
            // 
            this.chkVienphi.AutoSize = true;
            this.chkVienphi.Checked = true;
            this.chkVienphi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVienphi.Location = new System.Drawing.Point(112, 56);
            this.chkVienphi.Name = "chkVienphi";
            this.chkVienphi.Size = new System.Drawing.Size(66, 17);
            this.chkVienphi.TabIndex = 4;
            this.chkVienphi.Text = "Viện phí";
            this.chkVienphi.UseVisualStyleBackColor = true;
            // 
            // chkDuoc
            // 
            this.chkDuoc.AutoSize = true;
            this.chkDuoc.Enabled = false;
            this.chkDuoc.Location = new System.Drawing.Point(112, 33);
            this.chkDuoc.Name = "chkDuoc";
            this.chkDuoc.Size = new System.Drawing.Size(52, 17);
            this.chkDuoc.TabIndex = 3;
            this.chkDuoc.Text = "Dược";
            this.chkDuoc.UseVisualStyleBackColor = true;
            // 
            // txtMMYY
            // 
            this.txtMMYY.CustomFormat = "MM/yyyy";
            this.txtMMYY.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtMMYY.Location = new System.Drawing.Point(112, 7);
            this.txtMMYY.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.txtMMYY.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.txtMMYY.Name = "txtMMYY";
            this.txtMMYY.Size = new System.Drawing.Size(68, 20);
            this.txtMMYY.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tạo số liệu tháng:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butDongy
            // 
            this.butDongy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDongy.BackColor = System.Drawing.SystemColors.Control;
            this.butDongy.Image = ((System.Drawing.Image)(resources.GetObject("butDongy.Image")));
            this.butDongy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDongy.Location = new System.Drawing.Point(93, 262);
            this.butDongy.Name = "butDongy";
            this.butDongy.Size = new System.Drawing.Size(80, 29);
            this.butDongy.TabIndex = 10;
            this.butDongy.Text = "      Đồng ý";
            this.butDongy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDongy.UseVisualStyleBackColor = true;
            this.butDongy.Click += new System.EventHandler(this.butDongy_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.ForestGreen;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(1, 1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(343, 60);
            this.toolStrip3.TabIndex = 12;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(239, 57);
            this.toolStripLabel1.Text = "TẠO SỐ LIỆU THÁNG MỚI";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttStatus});
            this.statusStrip1.Location = new System.Drawing.Point(1, 293);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(343, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttStatus
            // 
            this.ttStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.ttStatus.Image = ((System.Drawing.Image)(resources.GetObject("ttStatus.Image")));
            this.ttStatus.Name = "ttStatus";
            this.ttStatus.Size = new System.Drawing.Size(62, 17);
            this.ttStatus.Text = "ttStatus";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(-28, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // frmNewdatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 316);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.butDongy);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewdatabase";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo mới số liệu tháng mới";
            this.Load += new System.EventHandler(this.frmNewdatabase_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkCDHA;
        private System.Windows.Forms.CheckBox chkXetnghiem;
        private System.Windows.Forms.CheckBox chkVienphi;
        private System.Windows.Forms.CheckBox chkDuoc;
        private System.Windows.Forms.DateTimePicker txtMMYY;
        private System.Windows.Forms.Button butDongy;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttStatus;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}