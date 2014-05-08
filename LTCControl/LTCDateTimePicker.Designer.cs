namespace LTCControl
{
    partial class LTCDateTimePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuy = new System.Windows.Forms.NumericUpDown();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtTuthang = new System.Windows.Forms.NumericUpDown();
            this.txtDenthang = new System.Windows.Forms.NumericUpDown();
            this.txtTunam = new System.Windows.Forms.NumericUpDown();
            this.txtDennam = new System.Windows.Forms.NumericUpDown();
            this.txtTungay = new System.Windows.Forms.DateTimePicker();
            this.txtDenngay = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbLuyke = new System.Windows.Forms.ComboBox();
            this.txtLuyke = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuthang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenthang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTunam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDennam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quý:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ tháng:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(2, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Từ ngày:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(146, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Đến tháng:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(82, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "/";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(150, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Đến ngày:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuy
            // 
            this.txtQuy.Location = new System.Drawing.Point(53, 2);
            this.txtQuy.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtQuy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuy.Name = "txtQuy";
            this.txtQuy.Size = new System.Drawing.Size(39, 20);
            this.txtQuy.TabIndex = 0;
            this.txtQuy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuy.ValueChanged += new System.EventHandler(this.txtQuy_ValueChanged);
            this.txtQuy.Validated += new System.EventHandler(this.txtQuy_Validated);
            this.txtQuy.Leave += new System.EventHandler(this.txtControl_Leave);
            this.txtQuy.Enter += new System.EventHandler(this.txtControl_Enter);
            this.txtQuy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // txtNam
            // 
            this.txtNam.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtNam.Location = new System.Drawing.Point(102, 2);
            this.txtNam.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(49, 20);
            this.txtNam.TabIndex = 1;
            this.txtNam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtNam.ValueChanged += new System.EventHandler(this.txtNam_ValueChanged);
            this.txtNam.Validated += new System.EventHandler(this.txtQuy_Validated);
            this.txtNam.Leave += new System.EventHandler(this.txtControl_Leave);
            this.txtNam.Enter += new System.EventHandler(this.txtControl_Enter);
            this.txtNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // txtTuthang
            // 
            this.txtTuthang.Location = new System.Drawing.Point(53, 25);
            this.txtTuthang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtTuthang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTuthang.Name = "txtTuthang";
            this.txtTuthang.Size = new System.Drawing.Size(39, 20);
            this.txtTuthang.TabIndex = 2;
            this.txtTuthang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTuthang.Validated += new System.EventHandler(this.txtTuthang_Validated);
            this.txtTuthang.Click += new System.EventHandler(this.txtTuthang_Click);
            this.txtTuthang.Leave += new System.EventHandler(this.txtControl_Leave);
            this.txtTuthang.Enter += new System.EventHandler(this.txtControl_Enter);
            this.txtTuthang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // txtDenthang
            // 
            this.txtDenthang.Location = new System.Drawing.Point(220, 25);
            this.txtDenthang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtDenthang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDenthang.Name = "txtDenthang";
            this.txtDenthang.Size = new System.Drawing.Size(39, 20);
            this.txtDenthang.TabIndex = 4;
            this.txtDenthang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDenthang.Validated += new System.EventHandler(this.txtDenthang_Validated);
            this.txtDenthang.Click += new System.EventHandler(this.txtDenthang_Click);
            this.txtDenthang.Leave += new System.EventHandler(this.txtControl_Leave);
            this.txtDenthang.Enter += new System.EventHandler(this.txtControl_Enter);
            this.txtDenthang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // txtTunam
            // 
            this.txtTunam.Location = new System.Drawing.Point(102, 25);
            this.txtTunam.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtTunam.Name = "txtTunam";
            this.txtTunam.Size = new System.Drawing.Size(49, 20);
            this.txtTunam.TabIndex = 3;
            this.txtTunam.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.txtTunam.Validated += new System.EventHandler(this.txtTuthang_Validated);
            this.txtTunam.Click += new System.EventHandler(this.txtTunam_Click);
            this.txtTunam.Leave += new System.EventHandler(this.txtControl_Leave);
            this.txtTunam.Enter += new System.EventHandler(this.txtControl_Enter);
            this.txtTunam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // txtDennam
            // 
            this.txtDennam.Location = new System.Drawing.Point(270, 25);
            this.txtDennam.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtDennam.Name = "txtDennam";
            this.txtDennam.Size = new System.Drawing.Size(49, 20);
            this.txtDennam.TabIndex = 5;
            this.txtDennam.Validated += new System.EventHandler(this.txtDenthang_Validated);
            this.txtDennam.Click += new System.EventHandler(this.txtDennam_Click);
            this.txtDennam.Leave += new System.EventHandler(this.txtControl_Leave);
            this.txtDennam.Enter += new System.EventHandler(this.txtControl_Enter);
            this.txtDennam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // txtTungay
            // 
            this.txtTungay.CustomFormat = "dd/MM/yyyy";
            this.txtTungay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTungay.Location = new System.Drawing.Point(53, 48);
            this.txtTungay.Name = "txtTungay";
            this.txtTungay.Size = new System.Drawing.Size(99, 20);
            this.txtTungay.TabIndex = 6;
            this.txtTungay.ValueChanged += new System.EventHandler(this.txtTungay_ValueChanged);
            this.txtTungay.Validated += new System.EventHandler(this.txtTungay_Validated);
            this.txtTungay.Leave += new System.EventHandler(this.txtControl_Leave);
            this.txtTungay.Enter += new System.EventHandler(this.txtControl_Enter);
            this.txtTungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // txtDenngay
            // 
            this.txtDenngay.CustomFormat = "dd/MM/yyyy";
            this.txtDenngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenngay.Location = new System.Drawing.Point(220, 48);
            this.txtDenngay.Name = "txtDenngay";
            this.txtDenngay.Size = new System.Drawing.Size(99, 20);
            this.txtDenngay.TabIndex = 7;
            this.txtDenngay.ValueChanged += new System.EventHandler(this.txtDenngay_ValueChanged);
            this.txtDenngay.Validated += new System.EventHandler(this.txtTungay_Validated);
            this.txtDenngay.Leave += new System.EventHandler(this.txtControl_Leave);
            this.txtDenngay.Enter += new System.EventHandler(this.txtControl_Enter);
            this.txtDenngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(79, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "/";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(250, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "/";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(149, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "Lũy kế theo:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbLuyke
            // 
            this.cbLuyke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLuyke.FormattingEnabled = true;
            this.cbLuyke.Items.AddRange(new object[] {
            "Năm",
            "Quý",
            "Tháng",
            "Không tính"});
            this.cbLuyke.Location = new System.Drawing.Point(220, 2);
            this.cbLuyke.Name = "cbLuyke";
            this.cbLuyke.Size = new System.Drawing.Size(99, 21);
            this.cbLuyke.TabIndex = 8;
            this.cbLuyke.SelectedIndexChanged += new System.EventHandler(this.cbLuyke_SelectedIndexChanged);
            this.cbLuyke.Leave += new System.EventHandler(this.txtControl_Leave);
            this.cbLuyke.Enter += new System.EventHandler(this.txtControl_Enter);
            this.cbLuyke.Validated += new System.EventHandler(this.cbLuyke_Validated);
            this.cbLuyke.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyDown);
            // 
            // txtLuyke
            // 
            this.txtLuyke.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLuyke.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuyke.ForeColor = System.Drawing.Color.Blue;
            this.txtLuyke.Location = new System.Drawing.Point(176, 79);
            this.txtLuyke.Name = "txtLuyke";
            this.txtLuyke.ReadOnly = true;
            this.txtLuyke.Size = new System.Drawing.Size(166, 14);
            this.txtLuyke.TabIndex = 9;
            this.txtLuyke.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLuyke.Visible = false;
            // 
            // LTCDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLuyke);
            this.Controls.Add(this.cbLuyke);
            this.Controls.Add(this.txtDenngay);
            this.Controls.Add(this.txtTungay);
            this.Controls.Add(this.txtDennam);
            this.Controls.Add(this.txtTunam);
            this.Controls.Add(this.txtDenthang);
            this.Controls.Add(this.txtTuthang);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtQuy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Name = "LTCDateTimePicker";
            this.Size = new System.Drawing.Size(320, 69);
            this.Load += new System.EventHandler(this.LTCDateTimePicker_Load);
            this.Leave += new System.EventHandler(this.LTCDateTimePicker_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuthang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenthang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTunam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDennam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown txtQuy;
        public System.Windows.Forms.NumericUpDown txtNam;
        public System.Windows.Forms.NumericUpDown txtTuthang;
        public System.Windows.Forms.NumericUpDown txtDenthang;
        public System.Windows.Forms.NumericUpDown txtTunam;
        public System.Windows.Forms.NumericUpDown txtDennam;
        public System.Windows.Forms.DateTimePicker txtTungay;
        public System.Windows.Forms.DateTimePicker txtDenngay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cbLuyke;
        public System.Windows.Forms.TextBox txtLuyke;
    }
}
