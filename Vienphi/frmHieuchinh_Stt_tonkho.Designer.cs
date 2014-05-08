namespace Vienphi
{
    partial class frmHieuchinh_Stt_tonkho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHieuchinh_Stt_tonkho));
            this.butCapnhat = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.cboKho = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.thang = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.l1 = new System.Windows.Forms.Label();
            this.cboNhomkho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboKhoNhap = new System.Windows.Forms.ComboBox();
            this.l2 = new System.Windows.Forms.Label();
            this.lShow = new System.Windows.Forms.Label();
            this.chkTutruc = new System.Windows.Forms.CheckBox();
            this.cboTutruc = new System.Windows.Forms.ComboBox();
            this.butKiemtra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.SuspendLayout();
            // 
            // butCapnhat
            // 
            this.butCapnhat.Location = new System.Drawing.Point(14, 166);
            this.butCapnhat.Name = "butCapnhat";
            this.butCapnhat.Size = new System.Drawing.Size(103, 32);
            this.butCapnhat.TabIndex = 0;
            this.butCapnhat.Text = "Cập nhật";
            this.butCapnhat.UseVisualStyleBackColor = true;
            this.butCapnhat.Click += new System.EventHandler(this.butCapnhat_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(220, 166);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(103, 32);
            this.butKetthuc.TabIndex = 1;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cboKho
            // 
            this.cboKho.BackColor = System.Drawing.Color.White;
            this.cboKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKho.FormattingEnabled = true;
            this.cboKho.Location = new System.Drawing.Point(88, 72);
            this.cboKho.Name = "cboKho";
            this.cboKho.Size = new System.Drawing.Size(240, 21);
            this.cboKho.TabIndex = 2;
            this.cboKho.SelectedIndexChanged += new System.EventHandler(this.cboKho_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số liệu tháng :";
            // 
            // thang
            // 
            this.thang.BackColor = System.Drawing.Color.White;
            this.thang.Location = new System.Drawing.Point(88, 25);
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(38, 20);
            this.thang.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "năm :";
            // 
            // nam
            // 
            this.nam.BackColor = System.Drawing.Color.White;
            this.nam.Location = new System.Drawing.Point(163, 25);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(56, 20);
            this.nam.TabIndex = 6;
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(35, 77);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(55, 13);
            this.l1.TabIndex = 7;
            this.l1.Text = "Kho xuất :";
            this.l1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboNhomkho
            // 
            this.cboNhomkho.BackColor = System.Drawing.Color.White;
            this.cboNhomkho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhomkho.FormattingEnabled = true;
            this.cboNhomkho.Location = new System.Drawing.Point(88, 48);
            this.cboNhomkho.Name = "cboNhomkho";
            this.cboNhomkho.Size = new System.Drawing.Size(240, 21);
            this.cboNhomkho.TabIndex = 8;
            this.cboNhomkho.SelectedIndexChanged += new System.EventHandler(this.cboNhomkho_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nhóm kho :";
            // 
            // cboKhoNhap
            // 
            this.cboKhoNhap.BackColor = System.Drawing.Color.White;
            this.cboKhoNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoNhap.FormattingEnabled = true;
            this.cboKhoNhap.Location = new System.Drawing.Point(88, 96);
            this.cboKhoNhap.Name = "cboKhoNhap";
            this.cboKhoNhap.Size = new System.Drawing.Size(240, 21);
            this.cboKhoNhap.TabIndex = 10;
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(31, 101);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(59, 13);
            this.l2.TabIndex = 11;
            this.l2.Text = "Kho nhập :";
            this.l2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lShow
            // 
            this.lShow.ForeColor = System.Drawing.Color.Blue;
            this.lShow.Location = new System.Drawing.Point(2, 129);
            this.lShow.Name = "lShow";
            this.lShow.Size = new System.Drawing.Size(335, 28);
            this.lShow.TabIndex = 12;
            this.lShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkTutruc
            // 
            this.chkTutruc.AutoSize = true;
            this.chkTutruc.Location = new System.Drawing.Point(230, 28);
            this.chkTutruc.Name = "chkTutruc";
            this.chkTutruc.Size = new System.Drawing.Size(60, 17);
            this.chkTutruc.TabIndex = 13;
            this.chkTutruc.Text = "Tủ trực";
            this.chkTutruc.UseVisualStyleBackColor = true;
            this.chkTutruc.CheckedChanged += new System.EventHandler(this.chkTutruc_CheckedChanged);
            // 
            // cboTutruc
            // 
            this.cboTutruc.BackColor = System.Drawing.Color.White;
            this.cboTutruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTutruc.FormattingEnabled = true;
            this.cboTutruc.Location = new System.Drawing.Point(88, 72);
            this.cboTutruc.Name = "cboTutruc";
            this.cboTutruc.Size = new System.Drawing.Size(240, 21);
            this.cboTutruc.TabIndex = 14;
            // 
            // butKiemtra
            // 
            this.butKiemtra.Location = new System.Drawing.Point(117, 166);
            this.butKiemtra.Name = "butKiemtra";
            this.butKiemtra.Size = new System.Drawing.Size(103, 32);
            this.butKiemtra.TabIndex = 15;
            this.butKiemtra.Text = "Kiểm tra tồn";
            this.butKiemtra.UseVisualStyleBackColor = true;
            this.butKiemtra.Click += new System.EventHandler(this.butKiemtra_Click);
            // 
            // frmHieuchinh_Stt_tonkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 209);
            this.Controls.Add(this.butKiemtra);
            this.Controls.Add(this.cboTutruc);
            this.Controls.Add(this.chkTutruc);
            this.Controls.Add(this.lShow);
            this.Controls.Add(this.cboKhoNhap);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.cboNhomkho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.cboKho);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butCapnhat);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHieuchinh_Stt_tonkho";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật STT tồn kho, tủ trực";
            this.Load += new System.EventHandler(this.frmHieuchinh_Stt_tonkho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCapnhat;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.ComboBox cboKho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown thang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nam;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.ComboBox cboNhomkho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKhoNhap;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label lShow;
        private System.Windows.Forms.CheckBox chkTutruc;
        private System.Windows.Forms.ComboBox cboTutruc;
        private System.Windows.Forms.Button butKiemtra;
    }
}