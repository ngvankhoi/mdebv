namespace Medisoft
{
    partial class frmChonkhodt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonkhodt));
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.solieu = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKho = new System.Windows.Forms.ComboBox();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kp = new System.Windows.Forms.TextBox();
            this.cmbTutruc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbNhom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solieu)).BeginInit();
            this.SuspendLayout();
            // 
            // nam
            // 
            this.nam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(226, 6);
            this.nam.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nam.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(43, 21);
            this.nam.TabIndex = 2;
            this.nam.Value = new decimal(new int[] {
            2011,
            0,
            0,
            0});
            this.nam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nam_KeyDown);
            // 
            // solieu
            // 
            this.solieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solieu.Location = new System.Drawing.Point(162, 7);
            this.solieu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.solieu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(33, 21);
            this.solieu.TabIndex = 1;
            this.solieu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(76, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "tháng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(44, 7);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(82, 20);
            this.ngay.TabIndex = 0;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(142, 152);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butOk
            // 
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(69, 152);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 8;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-25, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Ngày :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-5, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Kho :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(157, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Năm :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbKho
            // 
            this.cmbKho.BackColor = System.Drawing.Color.White;
            this.cmbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKho.Location = new System.Drawing.Point(44, 77);
            this.cmbKho.Name = "cmbKho";
            this.cmbKho.Size = new System.Drawing.Size(226, 21);
            this.cmbKho.TabIndex = 6;
            this.cmbKho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbKho_KeyDown);
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.BackColor = System.Drawing.Color.White;
            this.cmbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.Location = new System.Drawing.Point(88, 53);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(182, 21);
            this.cmbKhoa.TabIndex = 5;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            this.cmbKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbKhoa_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kp
            // 
            this.kp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kp.Location = new System.Drawing.Point(45, 53);
            this.kp.Name = "kp";
            this.kp.Size = new System.Drawing.Size(41, 21);
            this.kp.TabIndex = 4;
            this.kp.Validated += new System.EventHandler(this.kp_Validated);
            this.kp.TextChanged += new System.EventHandler(this.kp_TextChanged);
            this.kp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kp_KeyDown);
            // 
            // cmbTutruc
            // 
            this.cmbTutruc.BackColor = System.Drawing.Color.White;
            this.cmbTutruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTutruc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTutruc.Location = new System.Drawing.Point(44, 102);
            this.cmbTutruc.Name = "cmbTutruc";
            this.cmbTutruc.Size = new System.Drawing.Size(225, 21);
            this.cmbTutruc.TabIndex = 7;
            this.cmbTutruc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTutruc_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-4, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 23);
            this.label9.TabIndex = 10;
            this.label9.Text = "Tủ trực :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNhom
            // 
            this.cmbNhom.BackColor = System.Drawing.Color.White;
            this.cmbNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhom.Location = new System.Drawing.Point(45, 29);
            this.cmbNhom.Name = "cmbNhom";
            this.cmbNhom.Size = new System.Drawing.Size(225, 21);
            this.cmbNhom.TabIndex = 3;
            this.cmbNhom.SelectedIndexChanged += new System.EventHandler(this.cmbNhom_SelectedIndexChanged);
            this.cmbNhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNhom_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-4, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nhóm :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChonkhodt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 191);
            this.ControlBox = false;
            this.Controls.Add(this.cmbNhom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTutruc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.kp);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKho);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.solieu);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonkhodt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn thông số dự trù";
            this.Load += new System.EventHandler(this.frmChonkhodt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nam;
        private System.Windows.Forms.NumericUpDown solieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker ngay;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbKho;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox kp;
        private System.Windows.Forms.ComboBox cmbTutruc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbNhom;
        private System.Windows.Forms.Label label3;
    }
}