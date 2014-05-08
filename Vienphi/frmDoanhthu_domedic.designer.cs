namespace Vienphi
{
    partial class frmDoanhthu_domedic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoanhthu_domedic));
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIN = new System.Windows.Forms.Button();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.user_thu = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(143, 228);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(82, 26);
            this.butKetthuc.TabIndex = 40;
            this.butKetthuc.Text = "   &Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(61, 228);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(82, 26);
            this.butIN.TabIndex = 4;
            this.butIN.Text = "&In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(177, 4);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(83, 20);
            this.den.TabIndex = 2;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(129, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Đến:";
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(30, 4);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(83, 20);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Từ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 208);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(231, 17);
            this.checkBox1.TabIndex = 41;
            this.checkBox1.Text = "Theo tên đăng nhập hoặc họ tên người thu";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // user_thu
            // 
            this.user_thu.FormattingEnabled = true;
            this.user_thu.Location = new System.Drawing.Point(30, 34);
            this.user_thu.Name = "user_thu";
            this.user_thu.Size = new System.Drawing.Size(230, 169);
            this.user_thu.TabIndex = 42;
            // 
            // frmDoanhthu_domedic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 259);
            this.Controls.Add(this.user_thu);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoanhthu_domedic";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu theo người thu";
            this.Load += new System.EventHandler(this.frmDoanhthu_domedic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butIN;
        private System.Windows.Forms.DateTimePicker den;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker tu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckedListBox user_thu;
    }
}