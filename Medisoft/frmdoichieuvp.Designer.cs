namespace Medisoft
{
    partial class frmdoichieuvp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdoichieuvp));
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.butFind = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(152, 6);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 3;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(51, 6);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 1;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(120, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(-2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(50, 30);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(166, 21);
            this.loai.TabIndex = 5;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(-3, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 4;
            this.label15.Text = "Loại  :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butFind
            // 
            this.butFind.Image = ((System.Drawing.Image)(resources.GetObject("butFind.Image")));
            this.butFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butFind.Location = new System.Drawing.Point(12, 88);
            this.butFind.Name = "butFind";
            this.butFind.Size = new System.Drawing.Size(101, 25);
            this.butFind.TabIndex = 8;
            this.butFind.Text = "&In";
            this.butFind.UseVisualStyleBackColor = true;
            this.butFind.Click += new System.EventHandler(this.butFind_Click);
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Image = global::Medisoft.Properties.Resources.exit1;
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(115, 88);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(100, 25);
            this.butExit.TabIndex = 9;
            this.butExit.Text = "&Kết thúc";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(6, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 33);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(136, 11);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(76, 17);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Khác ngày";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Checked = true;
            this.rb2.Location = new System.Drawing.Point(60, 11);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(79, 17);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "Chênh lệch";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(3, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 17);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "Tất cả";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // frmdoichieuvp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(227, 124);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butFind);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmdoichieuvp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đối chiếu viện phí chi tiết";
            this.Load += new System.EventHandler(this.frmdoichieuvp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedBox.MaskedBox den;
        private MaskedBox.MaskedBox tu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox loai;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button butFind;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb3;
    }
}