namespace Duoc
{
    partial class frmChondutrungay
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
            this.label2 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.lanthu = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.solieu = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(28, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kho :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(76, 81);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(203, 132);
            this.kho.TabIndex = 5;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // lanthu
            // 
            this.lanthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lanthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanthu.Location = new System.Drawing.Point(76, 34);
            this.lanthu.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lanthu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lanthu.Name = "lanthu";
            this.lanthu.Size = new System.Drawing.Size(53, 21);
            this.lanthu.TabIndex = 2;
            this.lanthu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lanthu.ValueChanged += new System.EventHandler(this.lanthu_ValueChanged);
            this.lanthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lanthu_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lần thứ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(76, 58);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(203, 21);
            this.manguon.TabIndex = 4;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(28, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nguồn :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(145, 219);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(76, 219);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 6;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(164, 34);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(112, 20);
            this.ngay.TabIndex = 3;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(95, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ngày :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solieu
            // 
            this.solieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solieu.Location = new System.Drawing.Point(76, 11);
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
            this.solieu.Size = new System.Drawing.Size(53, 21);
            this.solieu.TabIndex = 0;
            this.solieu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-10, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Số liệu tháng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nam
            // 
            this.nam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(164, 10);
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
            this.nam.Size = new System.Drawing.Size(112, 21);
            this.nam.TabIndex = 1;
            this.nam.Value = new decimal(new int[] {
            2011,
            0,
            0,
            0});
            this.nam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nam_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(95, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Năm :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChondutrungay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 279);
            this.ControlBox = false;
            this.Controls.Add(this.nam);
            this.Controls.Add(this.solieu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.lanthu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Name = "frmChondutrungay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn thông số";
            this.Load += new System.EventHandler(this.frmChondutrungay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox kho;
        private System.Windows.Forms.NumericUpDown lanthu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox manguon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.DateTimePicker ngay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown solieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nam;
        private System.Windows.Forms.Label label6;

    }
}