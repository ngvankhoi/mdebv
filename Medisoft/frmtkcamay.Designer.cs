namespace Medisoft
{
    partial class frmtkcamay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtkcamay));
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.butFind = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.may = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(152, 6);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 1;
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
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(120, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(-2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 9;
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
            this.loai.TabIndex = 2;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(-3, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 11;
            this.label15.Text = "Loại  :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butFind
            // 
            this.butFind.Location = new System.Drawing.Point(61, 80);
            this.butFind.Name = "butFind";
            this.butFind.Size = new System.Drawing.Size(60, 25);
            this.butFind.TabIndex = 8;
            this.butFind.Text = "&In";
            this.butFind.UseVisualStyleBackColor = true;
            this.butFind.Click += new System.EventHandler(this.butFind_Click);
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Location = new System.Drawing.Point(123, 80);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(60, 25);
            this.butExit.TabIndex = 9;
            this.butExit.Text = "&Kết thúc";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // may
            // 
            this.may.BackColor = System.Drawing.SystemColors.HighlightText;
            this.may.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.may.Location = new System.Drawing.Point(50, 53);
            this.may.Name = "may";
            this.may.Size = new System.Drawing.Size(166, 21);
            this.may.TabIndex = 3;
            this.may.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.Location = new System.Drawing.Point(-16, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 23);
            this.label20.TabIndex = 296;
            this.label20.Text = "Máy :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmtkcamay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(227, 119);
            this.Controls.Add(this.may);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butFind);
            this.Controls.Add(this.den);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmtkcamay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê ca theo máy";
            this.Load += new System.EventHandler(this.frmtkcamay_Load);
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
        private System.Windows.Forms.ComboBox may;
        private System.Windows.Forms.Label label20;
    }
}