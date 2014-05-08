namespace Server
{
    partial class frmThongso
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongso));
            this.t3 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKetthuc = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.t5 = new System.Windows.Forms.TextBox();
            this.t4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.t6 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkChonServer = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.t8 = new System.Windows.Forms.TextBox();
            this.t7 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.t9 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.t10 = new System.Windows.Forms.NumericUpDown();
            this.t11 = new System.Windows.Forms.CheckBox();
            this.t12 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.t14 = new System.Windows.Forms.TextBox();
            this.t13 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.t16 = new System.Windows.Forms.TextBox();
            this.t15 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.t17 = new System.Windows.Forms.CheckBox();
            this.t18 = new System.Windows.Forms.CheckBox();
            this.t19 = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.t21 = new System.Windows.Forms.TextBox();
            this.t20 = new System.Windows.Forms.TextBox();
            this.t22 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.t1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t10)).BeginInit();
            this.SuspendLayout();
            // 
            // t3
            // 
            this.t3.AutoSize = true;
            this.t3.Location = new System.Drawing.Point(327, 11);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(149, 17);
            this.t3.TabIndex = 9;
            this.t3.Text = "Khởi động cùng Windows";
            this.t3.UseVisualStyleBackColor = true;
            this.t3.CheckedChanged += new System.EventHandler(this.c1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Phút";
            // 
            // t1
            // 
            this.t1.BackColor = System.Drawing.Color.White;
            this.t1.Location = new System.Drawing.Point(122, 11);
            this.t1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(41, 20);
            this.t1.TabIndex = 7;
            this.t1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.t1.ValueChanged += new System.EventHandler(this.numtgian_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "máy";
            // 
            // t2
            // 
            this.t2.BackColor = System.Drawing.Color.White;
            this.t2.Enabled = false;
            this.t2.Location = new System.Drawing.Point(104, 41);
            this.t2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(41, 20);
            this.t2.TabIndex = 13;
            this.t2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.t2.ValueChanged += new System.EventHandler(this.numSomay_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tổng số máy trạm";
            // 
            // btnKetthuc
            // 
            this.btnKetthuc.Location = new System.Drawing.Point(295, 249);
            this.btnKetthuc.Name = "btnKetthuc";
            this.btnKetthuc.Size = new System.Drawing.Size(75, 24);
            this.btnKetthuc.TabIndex = 12;
            this.btnKetthuc.Text = "Kết thúc";
            this.btnKetthuc.UseVisualStyleBackColor = true;
            this.btnKetthuc.Click += new System.EventHandler(this.btnKetthuc_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(214, 249);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 24);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "phút";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t5
            // 
            this.t5.Location = new System.Drawing.Point(220, 65);
            this.t5.MaxLength = 2;
            this.t5.Name = "t5";
            this.t5.Size = new System.Drawing.Size(31, 20);
            this.t5.TabIndex = 18;
            this.t5.Text = "00";
            this.t5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMM_KeyPress);
            // 
            // t4
            // 
            this.t4.Location = new System.Drawing.Point(186, 65);
            this.t4.MaxLength = 2;
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(28, 20);
            this.t4.TabIndex = 17;
            this.t4.Text = "18";
            this.t4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHH_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tự động đồng bộ toàn bộ sau";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(212, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = ":";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "ngày";
            // 
            // t6
            // 
            this.t6.BackColor = System.Drawing.Color.White;
            this.t6.Location = new System.Drawing.Point(213, 94);
            this.t6.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.t6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.t6.Name = "t6";
            this.t6.Size = new System.Drawing.Size(41, 20);
            this.t6.TabIndex = 21;
            this.t6.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Khoảng cách ngày so với ngày hiện tại";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 23);
            this.label9.TabIndex = 24;
            this.label9.Text = "Tự động đồng bộ sau:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkChonServer
            // 
            this.chkChonServer.AutoSize = true;
            this.chkChonServer.Location = new System.Drawing.Point(327, 34);
            this.chkChonServer.Name = "chkChonServer";
            this.chkChonServer.Size = new System.Drawing.Size(159, 17);
            this.chkChonServer.TabIndex = 25;
            this.chkChonServer.Text = "Chọn Server nguồn và đích";
            this.chkChonServer.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "phút";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t8
            // 
            this.t8.Location = new System.Drawing.Point(222, 137);
            this.t8.MaxLength = 2;
            this.t8.Name = "t8";
            this.t8.Size = new System.Drawing.Size(31, 20);
            this.t8.TabIndex = 28;
            this.t8.Text = "00";
            // 
            // t7
            // 
            this.t7.Location = new System.Drawing.Point(188, 137);
            this.t7.MaxLength = 2;
            this.t7.Name = "t7";
            this.t7.Size = new System.Drawing.Size(28, 20);
            this.t7.TabIndex = 27;
            this.t7.Text = "05";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(185, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "Tự động gửi mail nhắc BN khám lúc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(214, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 15);
            this.label12.TabIndex = 29;
            this.label12.Text = ":";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t9
            // 
            this.t9.AutoSize = true;
            this.t9.Location = new System.Drawing.Point(9, 119);
            this.t9.Name = "t9";
            this.t9.Size = new System.Drawing.Size(132, 17);
            this.t9.TabIndex = 31;
            this.t9.Text = "Tự động gửi mail trước";
            this.t9.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "ngày";
            // 
            // t10
            // 
            this.t10.BackColor = System.Drawing.Color.White;
            this.t10.Location = new System.Drawing.Point(188, 116);
            this.t10.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.t10.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.t10.Name = "t10";
            this.t10.Size = new System.Drawing.Size(41, 20);
            this.t10.TabIndex = 32;
            this.t10.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // t11
            // 
            this.t11.AutoSize = true;
            this.t11.Location = new System.Drawing.Point(327, 57);
            this.t11.Name = "t11";
            this.t11.Size = new System.Drawing.Size(99, 17);
            this.t11.TabIndex = 34;
            this.t11.Text = "Hình BN ghi đè";
            this.t11.UseVisualStyleBackColor = true;
            // 
            // t12
            // 
            this.t12.AutoSize = true;
            this.t12.Location = new System.Drawing.Point(327, 80);
            this.t12.Name = "t12";
            this.t12.Size = new System.Drawing.Size(114, 17);
            this.t12.TabIndex = 35;
            this.t12.Text = "Hình CĐHA ghi đè";
            this.t12.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(259, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "phút";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t14
            // 
            this.t14.Location = new System.Drawing.Point(222, 161);
            this.t14.MaxLength = 2;
            this.t14.Name = "t14";
            this.t14.Size = new System.Drawing.Size(31, 20);
            this.t14.TabIndex = 38;
            this.t14.Text = "00";
            // 
            // t13
            // 
            this.t13.Location = new System.Drawing.Point(188, 161);
            this.t13.MaxLength = 2;
            this.t13.Name = "t13";
            this.t13.Size = new System.Drawing.Size(28, 20);
            this.t13.TabIndex = 37;
            this.t13.Text = "01";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(259, 188);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "phút";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t16
            // 
            this.t16.Location = new System.Drawing.Point(222, 184);
            this.t16.MaxLength = 2;
            this.t16.Name = "t16";
            this.t16.Size = new System.Drawing.Size(31, 20);
            this.t16.TabIndex = 42;
            this.t16.Text = "00";
            // 
            // t15
            // 
            this.t15.Location = new System.Drawing.Point(188, 184);
            this.t15.MaxLength = 2;
            this.t15.Name = "t15";
            this.t15.Size = new System.Drawing.Size(28, 20);
            this.t15.TabIndex = 41;
            this.t15.Text = "03";
            // 
            // t17
            // 
            this.t17.AutoSize = true;
            this.t17.Location = new System.Drawing.Point(9, 165);
            this.t17.Name = "t17";
            this.t17.Size = new System.Drawing.Size(165, 17);
            this.t17.TabIndex = 44;
            this.t17.Text = "Đồng bộ hình Bệnh nhân  lúc";
            this.t17.UseVisualStyleBackColor = true;
            // 
            // t18
            // 
            this.t18.AutoSize = true;
            this.t18.Location = new System.Drawing.Point(9, 188);
            this.t18.Name = "t18";
            this.t18.Size = new System.Drawing.Size(143, 17);
            this.t18.TabIndex = 45;
            this.t18.Text = "Đồng bộ hình CĐHA  lúc";
            this.t18.UseVisualStyleBackColor = true;
            // 
            // t19
            // 
            this.t19.AutoSize = true;
            this.t19.Location = new System.Drawing.Point(9, 211);
            this.t19.Name = "t19";
            this.t19.Size = new System.Drawing.Size(146, 17);
            this.t19.TabIndex = 49;
            this.t19.Text = "Đồng bộ hình chứng từ lú";
            this.t19.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(259, 211);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = "phút";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t21
            // 
            this.t21.Location = new System.Drawing.Point(222, 207);
            this.t21.MaxLength = 2;
            this.t21.Name = "t21";
            this.t21.Size = new System.Drawing.Size(31, 20);
            this.t21.TabIndex = 47;
            this.t21.Text = "00";
            // 
            // t20
            // 
            this.t20.Location = new System.Drawing.Point(188, 207);
            this.t20.MaxLength = 2;
            this.t20.Name = "t20";
            this.t20.Size = new System.Drawing.Size(28, 20);
            this.t20.TabIndex = 46;
            this.t20.Text = "03";
            // 
            // t22
            // 
            this.t22.AutoSize = true;
            this.t22.Location = new System.Drawing.Point(327, 103);
            this.t22.Name = "t22";
            this.t22.Size = new System.Drawing.Size(126, 17);
            this.t22.TabIndex = 50;
            this.t22.Text = "Hình chứng từ ghi đè";
            this.t22.UseVisualStyleBackColor = true;
            // 
            // frmThongso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 285);
            this.Controls.Add(this.t22);
            this.Controls.Add(this.t19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.t21);
            this.Controls.Add(this.t20);
            this.Controls.Add(this.t18);
            this.Controls.Add(this.t17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.t16);
            this.Controls.Add(this.t15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.t14);
            this.Controls.Add(this.t13);
            this.Controls.Add(this.t12);
            this.Controls.Add(this.t11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.t10);
            this.Controls.Add(this.t9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.t8);
            this.Controls.Add(this.t7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkChonServer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.t6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.t5);
            this.Controls.Add(this.t4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnKetthuc);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.label9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThongso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo thông số";
            this.Load += new System.EventHandler(this.frmThongso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox t3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown t1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown t2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKetthuc;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t5;
        private System.Windows.Forms.TextBox t4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown t6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkChonServer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox t8;
        private System.Windows.Forms.TextBox t7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox t9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown t10;
        private System.Windows.Forms.CheckBox t11;
        private System.Windows.Forms.CheckBox t12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox t14;
        private System.Windows.Forms.TextBox t13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox t16;
        private System.Windows.Forms.TextBox t15;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox t17;
        private System.Windows.Forms.CheckBox t18;
        private System.Windows.Forms.CheckBox t19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox t21;
        private System.Windows.Forms.TextBox t20;
        private System.Windows.Forms.CheckBox t22;
    }
}