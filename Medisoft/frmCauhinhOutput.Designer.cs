namespace Medisoft
{
    partial class frmCauhinhOutput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauhinhOutput));
            this.tdx = new System.Windows.Forms.NumericUpDown();
            this.tdy = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tdR = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tdC = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tdt = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tdx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdt)).BeginInit();
            this.SuspendLayout();
            // 
            // tdx
            // 
            this.tdx.Location = new System.Drawing.Point(61, 12);
            this.tdx.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.tdx.Name = "tdx";
            this.tdx.Size = new System.Drawing.Size(47, 20);
            this.tdx.TabIndex = 0;
            // 
            // tdy
            // 
            this.tdy.Location = new System.Drawing.Point(179, 12);
            this.tdy.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.tdy.Name = "tdy";
            this.tdy.Size = new System.Drawing.Size(42, 20);
            this.tdy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tọa độ X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tọa độ Y :";
            // 
            // tdR
            // 
            this.tdR.Location = new System.Drawing.Point(61, 33);
            this.tdR.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.tdR.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tdR.Name = "tdR";
            this.tdR.Size = new System.Drawing.Size(47, 20);
            this.tdR.TabIndex = 4;
            this.tdR.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rộng :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(125, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Kết thúc";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tdC
            // 
            this.tdC.Location = new System.Drawing.Point(179, 33);
            this.tdC.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.tdC.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tdC.Name = "tdC";
            this.tdC.Size = new System.Drawing.Size(43, 20);
            this.tdC.TabIndex = 8;
            this.tdC.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cao :";
            // 
            // tdt
            // 
            this.tdt.Location = new System.Drawing.Point(122, 54);
            this.tdt.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.tdt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tdt.Name = "tdt";
            this.tdt.Size = new System.Drawing.Size(47, 20);
            this.tdt.TabIndex = 10;
            this.tdt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lấy lại danh sách sau :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Phút";
            // 
            // frmCauhinhOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 126);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tdt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tdC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tdR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tdy);
            this.Controls.Add(this.tdx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCauhinhOutput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình LCD";
            this.Load += new System.EventHandler(this.frmCauhinhOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tdx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown tdx;
        private System.Windows.Forms.NumericUpDown tdy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown tdR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown tdC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown tdt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}