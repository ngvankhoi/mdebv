namespace Vienphi
{
    partial class frmNewgroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewgroup));
            this.butClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDiengiai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdUser = new System.Windows.Forms.RadioButton();
            this.rdAdmin = new System.Windows.Forms.RadioButton();
            this.rdApplication = new System.Windows.Forms.RadioButton();
            this.rdDatabase = new System.Windows.Forms.RadioButton();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.butLuu = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
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
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butClose.BackColor = System.Drawing.SystemColors.Control;
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(353, 249);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(70, 25);
            this.butClose.TabIndex = 5;
            this.butClose.Text = "      Đó&ng";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtDiengiai);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.rdUser);
            this.panel2.Controls.Add(this.rdAdmin);
            this.panel2.Controls.Add(this.rdApplication);
            this.panel2.Controls.Add(this.rdDatabase);
            this.panel2.Controls.Add(this.txtTen);
            this.panel2.Controls.Add(this.txtMa);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 184);
            this.panel2.TabIndex = 9;
            // 
            // txtDiengiai
            // 
            this.txtDiengiai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiengiai.BackColor = System.Drawing.Color.White;
            this.txtDiengiai.ForeColor = System.Drawing.Color.Black;
            this.txtDiengiai.Location = new System.Drawing.Point(71, 55);
            this.txtDiengiai.MaxLength = 255;
            this.txtDiengiai.Name = "txtDiengiai";
            this.txtDiengiai.Size = new System.Drawing.Size(338, 20);
            this.txtDiengiai.TabIndex = 2;
            this.txtDiengiai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiengiai_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-59, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Diễn giải:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdUser
            // 
            this.rdUser.AutoSize = true;
            this.rdUser.Checked = true;
            this.rdUser.Location = new System.Drawing.Point(71, 150);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(80, 17);
            this.rdUser.TabIndex = 6;
            this.rdUser.TabStop = true;
            this.rdUser.Tag = "4";
            this.rdUser.Text = "Người dùng";
            this.rdUser.UseVisualStyleBackColor = true;
            this.rdUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdUser_KeyDown);
            // 
            // rdAdmin
            // 
            this.rdAdmin.AutoSize = true;
            this.rdAdmin.Location = new System.Drawing.Point(71, 127);
            this.rdAdmin.Name = "rdAdmin";
            this.rdAdmin.Size = new System.Drawing.Size(122, 17);
            this.rdAdmin.TabIndex = 5;
            this.rdAdmin.TabStop = true;
            this.rdAdmin.Tag = "3";
            this.rdAdmin.Text = "Quản trị khoa phòng";
            this.rdAdmin.UseVisualStyleBackColor = true;
            this.rdAdmin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdAdmin_KeyDown);
            // 
            // rdApplication
            // 
            this.rdApplication.AutoSize = true;
            this.rdApplication.Location = new System.Drawing.Point(71, 104);
            this.rdApplication.Name = "rdApplication";
            this.rdApplication.Size = new System.Drawing.Size(107, 17);
            this.rdApplication.TabIndex = 4;
            this.rdApplication.TabStop = true;
            this.rdApplication.Tag = "2";
            this.rdApplication.Text = "Quản trị hệ thống";
            this.rdApplication.UseVisualStyleBackColor = true;
            this.rdApplication.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdApplication_KeyDown);
            // 
            // rdDatabase
            // 
            this.rdDatabase.AutoSize = true;
            this.rdDatabase.Location = new System.Drawing.Point(71, 81);
            this.rdDatabase.Name = "rdDatabase";
            this.rdDatabase.Size = new System.Drawing.Size(125, 17);
            this.rdDatabase.TabIndex = 3;
            this.rdDatabase.TabStop = true;
            this.rdDatabase.Tag = "1";
            this.rdDatabase.Text = "Quản trị cơ sở dử liệu";
            this.rdDatabase.UseVisualStyleBackColor = true;
            this.rdDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdDatabase_KeyDown);
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.ForeColor = System.Drawing.Color.Black;
            this.txtTen.Location = new System.Drawing.Point(71, 34);
            this.txtTen.MaxLength = 255;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(338, 20);
            this.txtTen.TabIndex = 1;
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // txtMa
            // 
            this.txtMa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa.BackColor = System.Drawing.Color.White;
            this.txtMa.ForeColor = System.Drawing.Color.Black;
            this.txtMa.Location = new System.Drawing.Point(71, 13);
            this.txtMa.MaxLength = 20;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(218, 20);
            this.txtMa.TabIndex = 0;
            this.txtMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMa_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-59, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên nhóm:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-59, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã nhóm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Image = global::Vienphi.Properties.Resources.t_chon_5;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(290, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "      Tạo nhóm mặc định";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(73, 249);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 1;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.BackColor = System.Drawing.SystemColors.Control;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(3, 249);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 0;
            this.butMoi.Text = "       &Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.UseVisualStyleBackColor = true;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.BackColor = System.Drawing.SystemColors.Control;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(143, 249);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 2;
            this.butSua.Text = "      &Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.BackColor = System.Drawing.SystemColors.Control;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(213, 249);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 3;
            this.butXoa.Text = "      &Xoá";
            this.butXoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(283, 249);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "      &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
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
            this.toolStrip3.Size = new System.Drawing.Size(426, 60);
            this.toolStrip3.TabIndex = 11;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(293, 57);
            this.toolStripLabel1.Text = "KHAI BÁO NHÓM NGƯỜI DÙNG";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttStatus});
            this.statusStrip1.Location = new System.Drawing.Point(1, 278);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(426, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttStatus
            // 
            this.ttStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.ttStatus.Image = ((System.Drawing.Image)(resources.GetObject("ttStatus.Image")));
            this.ttStatus.Name = "ttStatus";
            this.ttStatus.Size = new System.Drawing.Size(63, 17);
            this.ttStatus.Text = "ttStatus";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(-12, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // frmNewgroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 301);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewgroup";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo nhóm người dùng";
            this.Load += new System.EventHandler(this.frmNewgroup_Load);
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
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.RadioButton rdDatabase;
        private System.Windows.Forms.RadioButton rdUser;
        private System.Windows.Forms.RadioButton rdAdmin;
        private System.Windows.Forms.RadioButton rdApplication;
        private System.Windows.Forms.TextBox txtDiengiai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butMoi;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttStatus;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}