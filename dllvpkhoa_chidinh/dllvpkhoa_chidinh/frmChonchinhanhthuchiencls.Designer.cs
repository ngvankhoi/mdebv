namespace dllvpkhoa_chidinh
{
    partial class frmChonchinhanhthuchiencls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonchinhanhthuchiencls));
            this.btChuyen = new System.Windows.Forms.Button();
            this.cbChinhanhden = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btChuyen
            // 
            this.btChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btChuyen.Image = ((System.Drawing.Image)(resources.GetObject("btChuyen.Image")));
            this.btChuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btChuyen.Location = new System.Drawing.Point(86, 66);
            this.btChuyen.Name = "btChuyen";
            this.btChuyen.Size = new System.Drawing.Size(83, 25);
            this.btChuyen.TabIndex = 17;
            this.btChuyen.Text = "&Chuyển";
            this.btChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btChuyen.Click += new System.EventHandler(this.btChuyen_Click);
            // 
            // cbChinhanhden
            // 
            this.cbChinhanhden.FormattingEnabled = true;
            this.cbChinhanhden.Location = new System.Drawing.Point(11, 20);
            this.cbChinhanhden.Name = "cbChinhanhden";
            this.cbChinhanhden.Size = new System.Drawing.Size(268, 23);
            this.cbChinhanhden.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbChinhanhden);
            this.groupBox1.Controls.Add(this.btChuyen);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn chi nhánh cần chuyển đến";
            // 
            // frmChonchinhanhthuchiencls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 105);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmChonchinhanhthuchiencls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chi nhán chuyển đến";
            this.Load += new System.EventHandler(this.frmChonchinhanhthuchiencls_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btChuyen;
        private System.Windows.Forms.ComboBox cbChinhanhden;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}