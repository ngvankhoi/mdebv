namespace toolChuyennhomkho
{
    partial class Form1
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
            this.butChuyen = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.cmbNhomkhonguon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNhomkhoDich = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkdmbd = new System.Windows.Forms.CheckBox();
            this.chkdmnhom = new System.Windows.Forms.CheckBox();
            this.chkLoai = new System.Windows.Forms.CheckBox();
            this.chkHang = new System.Windows.Forms.CheckBox();
            this.chkdmnuoc = new System.Windows.Forms.CheckBox();
            this.chkdmnx = new System.Windows.Forms.CheckBox();
            this.chkNhombo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // butChuyen
            // 
            this.butChuyen.Location = new System.Drawing.Point(223, 167);
            this.butChuyen.Name = "butChuyen";
            this.butChuyen.Size = new System.Drawing.Size(81, 26);
            this.butChuyen.TabIndex = 0;
            this.butChuyen.Text = "&Chuyển";
            this.butChuyen.UseVisualStyleBackColor = true;
            this.butChuyen.Click += new System.EventHandler(this.butChuyen_Click);
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(304, 167);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(81, 26);
            this.butClose.TabIndex = 1;
            this.butClose.Text = "&Kết thúc";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // cmbNhomkhonguon
            // 
            this.cmbNhomkhonguon.FormattingEnabled = true;
            this.cmbNhomkhonguon.Location = new System.Drawing.Point(153, 12);
            this.cmbNhomkhonguon.Name = "cmbNhomkhonguon";
            this.cmbNhomkhonguon.Size = new System.Drawing.Size(121, 21);
            this.cmbNhomkhonguon.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chuyển DM từ nhóm kho";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "sang nhóm kho";
            // 
            // cmbNhomkhoDich
            // 
            this.cmbNhomkhoDich.FormattingEnabled = true;
            this.cmbNhomkhoDich.Location = new System.Drawing.Point(366, 12);
            this.cmbNhomkhoDich.Name = "cmbNhomkhoDich";
            this.cmbNhomkhoDich.Size = new System.Drawing.Size(154, 21);
            this.cmbNhomkhoDich.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 205);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(532, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "label3";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkdmbd
            // 
            this.chkdmbd.AutoSize = true;
            this.chkdmbd.Location = new System.Drawing.Point(25, 44);
            this.chkdmbd.Name = "chkdmbd";
            this.chkdmbd.Size = new System.Drawing.Size(82, 17);
            this.chkdmbd.TabIndex = 7;
            this.chkdmbd.Text = "01. d_dmbd";
            this.chkdmbd.UseVisualStyleBackColor = true;
            // 
            // chkdmnhom
            // 
            this.chkdmnhom.AutoSize = true;
            this.chkdmnhom.Location = new System.Drawing.Point(25, 66);
            this.chkdmnhom.Name = "chkdmnhom";
            this.chkdmnhom.Size = new System.Drawing.Size(96, 17);
            this.chkdmnhom.TabIndex = 8;
            this.chkdmnhom.Text = "02. d_dmnhom";
            this.chkdmnhom.UseVisualStyleBackColor = true;
            // 
            // chkLoai
            // 
            this.chkLoai.AutoSize = true;
            this.chkLoai.Location = new System.Drawing.Point(25, 89);
            this.chkLoai.Name = "chkLoai";
            this.chkLoai.Size = new System.Drawing.Size(86, 17);
            this.chkLoai.TabIndex = 9;
            this.chkLoai.Text = "03. d_dmloai";
            this.chkLoai.UseVisualStyleBackColor = true;
            // 
            // chkHang
            // 
            this.chkHang.AutoSize = true;
            this.chkHang.Location = new System.Drawing.Point(25, 112);
            this.chkHang.Name = "chkHang";
            this.chkHang.Size = new System.Drawing.Size(94, 17);
            this.chkHang.TabIndex = 10;
            this.chkHang.Text = "04. d_dmhang";
            this.chkHang.UseVisualStyleBackColor = true;
            // 
            // chkdmnuoc
            // 
            this.chkdmnuoc.AutoSize = true;
            this.chkdmnuoc.Location = new System.Drawing.Point(25, 135);
            this.chkdmnuoc.Name = "chkdmnuoc";
            this.chkdmnuoc.Size = new System.Drawing.Size(94, 17);
            this.chkdmnuoc.TabIndex = 11;
            this.chkdmnuoc.Text = "05. d_dmnuoc";
            this.chkdmnuoc.UseVisualStyleBackColor = true;
            // 
            // chkdmnx
            // 
            this.chkdmnx.AutoSize = true;
            this.chkdmnx.Location = new System.Drawing.Point(25, 158);
            this.chkdmnx.Name = "chkdmnx";
            this.chkdmnx.Size = new System.Drawing.Size(156, 17);
            this.chkdmnx.TabIndex = 12;
            this.chkdmnx.Text = "06. d_dmnx (nhà cung cấp)";
            this.chkdmnx.UseVisualStyleBackColor = true;
            // 
            // chkNhombo
            // 
            this.chkNhombo.AutoSize = true;
            this.chkNhombo.Location = new System.Drawing.Point(25, 178);
            this.chkNhombo.Name = "chkNhombo";
            this.chkNhombo.Size = new System.Drawing.Size(160, 17);
            this.chkNhombo.TabIndex = 13;
            this.chkNhombo.Text = "07. d_dmnhombo (Dược BV)";
            this.chkNhombo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 228);
            this.Controls.Add(this.chkNhombo);
            this.Controls.Add(this.chkdmnx);
            this.Controls.Add(this.chkdmnuoc);
            this.Controls.Add(this.chkHang);
            this.Controls.Add(this.chkLoai);
            this.Controls.Add(this.chkdmnhom);
            this.Controls.Add(this.chkdmbd);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbNhomkhoDich);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNhomkhonguon);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butChuyen);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool chuyển danh mục từ nhóm kho A --> B";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butChuyen;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.ComboBox cmbNhomkhonguon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNhomkhoDich;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkdmbd;
        private System.Windows.Forms.CheckBox chkdmnhom;
        private System.Windows.Forms.CheckBox chkLoai;
        private System.Windows.Forms.CheckBox chkHang;
        private System.Windows.Forms.CheckBox chkdmnuoc;
        private System.Windows.Forms.CheckBox chkdmnx;
        private System.Windows.Forms.CheckBox chkNhombo;
    }
}

