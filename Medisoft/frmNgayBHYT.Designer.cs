namespace Medisoft
{
    partial class frmNgayBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNgayBHYT));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmabn = new System.Windows.Forms.TextBox();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTungay = new MaskedBox.MaskedBox();
            this.txtTungay1 = new MaskedBox.MaskedBox();
            this.txtTungay2 = new MaskedBox.MaskedBox();
            this.txtTungay3 = new MaskedBox.MaskedBox();
            this.txtDenngay = new MaskedBox.MaskedBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsothe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên:";
            // 
            // txtmabn
            // 
            this.txtmabn.Enabled = false;
            this.txtmabn.Location = new System.Drawing.Point(64, 18);
            this.txtmabn.Name = "txtmabn";
            this.txtmabn.Size = new System.Drawing.Size(67, 20);
            this.txtmabn.TabIndex = 0;
            // 
            // txthoten
            // 
            this.txthoten.Enabled = false;
            this.txthoten.Location = new System.Drawing.Point(177, 18);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(164, 20);
            this.txthoten.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Từ ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Đến ngày:";
            // 
            // txtTungay
            // 
            this.txtTungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTungay.Location = new System.Drawing.Point(64, 62);
            this.txtTungay.Mask = "##/##/####";
            this.txtTungay.Name = "txtTungay";
            this.txtTungay.Size = new System.Drawing.Size(67, 21);
            this.txtTungay.TabIndex = 2;
            this.txtTungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTungay_KeyDown);
            // 
            // txtTungay1
            // 
            this.txtTungay1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTungay1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTungay1.Location = new System.Drawing.Point(134, 62);
            this.txtTungay1.Mask = "##/##/####";
            this.txtTungay1.Name = "txtTungay1";
            this.txtTungay1.Size = new System.Drawing.Size(67, 21);
            this.txtTungay1.TabIndex = 3;
            this.txtTungay1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTungay1_KeyDown);
            // 
            // txtTungay2
            // 
            this.txtTungay2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTungay2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTungay2.Location = new System.Drawing.Point(204, 62);
            this.txtTungay2.Mask = "##/##/####";
            this.txtTungay2.Name = "txtTungay2";
            this.txtTungay2.Size = new System.Drawing.Size(67, 21);
            this.txtTungay2.TabIndex = 4;
            this.txtTungay2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTungay2_KeyDown);
            // 
            // txtTungay3
            // 
            this.txtTungay3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTungay3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTungay3.Location = new System.Drawing.Point(274, 62);
            this.txtTungay3.Mask = "##/##/####";
            this.txtTungay3.Name = "txtTungay3";
            this.txtTungay3.Size = new System.Drawing.Size(67, 21);
            this.txtTungay3.TabIndex = 5;
            this.txtTungay3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTungay3_KeyDown);
            // 
            // txtDenngay
            // 
            this.txtDenngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDenngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenngay.Location = new System.Drawing.Point(64, 85);
            this.txtDenngay.Mask = "##/##/####";
            this.txtDenngay.Name = "txtDenngay";
            this.txtDenngay.Size = new System.Drawing.Size(67, 21);
            this.txtDenngay.TabIndex = 6;
            this.txtDenngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDenngay_KeyDown);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(171, 125);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 8;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = global::Medisoft.Properties.Resources.ok;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(101, 125);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 7;
            this.butLuu.Text = "    &Đồng ý";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số thẻ:";
            // 
            // txtsothe
            // 
            this.txtsothe.Enabled = false;
            this.txtsothe.Location = new System.Drawing.Point(64, 40);
            this.txtsothe.Name = "txtsothe";
            this.txtsothe.Size = new System.Drawing.Size(277, 20);
            this.txtsothe.TabIndex = 11;
            // 
            // frmNgayBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(357, 170);
            this.Controls.Add(this.txtsothe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDenngay);
            this.Controls.Add(this.txtTungay3);
            this.Controls.Add(this.txtTungay2);
            this.Controls.Add(this.txtTungay1);
            this.Controls.Add(this.txtTungay);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txthoten);
            this.Controls.Add(this.txtmabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNgayBHYT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ngày hưởng BHYT";
            this.Load += new System.EventHandler(this.frmNgayBHYT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmabn;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
        private MaskedBox.MaskedBox txtTungay;
        private MaskedBox.MaskedBox txtTungay1;
        private MaskedBox.MaskedBox txtTungay2;
        private MaskedBox.MaskedBox txtTungay3;
        private MaskedBox.MaskedBox txtDenngay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsothe;
    }
}