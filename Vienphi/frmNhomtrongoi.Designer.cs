namespace Vienphi
{
    partial class frmNhomtrongoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhomtrongoi));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.cbten = new System.Windows.Forms.ComboBox();
            this.trongoi = new System.Windows.Forms.CheckedListBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhóm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(38, 6);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(56, 20);
            this.txtTen.TabIndex = 1;
            this.txtTen.Validated += new System.EventHandler(this.txtTen_Validated);
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // cbten
            // 
            this.cbten.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbten.FormattingEnabled = true;
            this.cbten.Location = new System.Drawing.Point(95, 6);
            this.cbten.Name = "cbten";
            this.cbten.Size = new System.Drawing.Size(370, 21);
            this.cbten.TabIndex = 2;
            this.cbten.SelectedIndexChanged += new System.EventHandler(this.cbten_SelectedIndexChanged);
            this.cbten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbten_KeyDown);
            // 
            // trongoi
            // 
            this.trongoi.FormattingEnabled = true;
            this.trongoi.Location = new System.Drawing.Point(38, 30);
            this.trongoi.Name = "trongoi";
            this.trongoi.Size = new System.Drawing.Size(427, 409);
            this.trongoi.TabIndex = 3;
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(179, 447);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(72, 27);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "&Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(251, 447);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 27);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmNhomtrongoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 484);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.trongoi);
            this.Controls.Add(this.cbten);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNhomtrongoi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhóm viện phí trọn gói";
            this.Load += new System.EventHandler(this.frmNhomtrongoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.ComboBox cbten;
        private System.Windows.Forms.CheckedListBox trongoi;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butLuu;
    }
}