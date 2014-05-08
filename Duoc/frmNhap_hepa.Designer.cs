namespace Duoc
{
    partial class frmNhap_hepa
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
            this.cbochinhanh = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbosophieudh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Location = new System.Drawing.Point(8, 83);
            this.dataGrid1.Size = new System.Drawing.Size(776, 303);
            // 
            // butMoi
            // 
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLuu
            // 
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // co
            // 
            this.co.KeyDown += new System.Windows.Forms.KeyEventHandler(this.co_KeyDown);
            // 
            // cbochinhanh
            // 
            this.cbochinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbochinhanh.FormattingEnabled = true;
            this.cbochinhanh.Location = new System.Drawing.Point(72, 75);
            this.cbochinhanh.Name = "cbochinhanh";
            this.cbochinhanh.Size = new System.Drawing.Size(256, 21);
            this.cbochinhanh.TabIndex = 131;
            this.cbochinhanh.SelectedValueChanged += new System.EventHandler(this.cbochinhanh_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 132;
            this.label6.Text = "Chi nhánh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbosophieudh
            // 
            this.cbosophieudh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbosophieudh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosophieudh.FormattingEnabled = true;
            this.cbosophieudh.Location = new System.Drawing.Point(433, 75);
            this.cbosophieudh.Name = "cbosophieudh";
            this.cbosophieudh.Size = new System.Drawing.Size(354, 21);
            this.cbosophieudh.TabIndex = 133;
            this.cbosophieudh.SelectedValueChanged += new System.EventHandler(this.cbosophieudh_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 134;
            this.label1.Text = "Số phiếu đặt hàng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmNhap_hepa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.cbosophieudh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbochinhanh);
            this.Controls.Add(this.label6);
            this.Name = "frmNhap_hepa";
            this.Load += new System.EventHandler(this.frmNhap_hepa_Load);
            this.Controls.SetChildIndex(this.butMoi, 0);
            this.Controls.SetChildIndex(this.butLuu, 0);
            this.Controls.SetChildIndex(this.butBoqua, 0);
            this.Controls.SetChildIndex(this.co, 0);
            this.Controls.SetChildIndex(this.dataGrid1, 0);
            this.Controls.SetChildIndex(this.bbkiem, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cbochinhanh, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbosophieudh, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbochinhanh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbosophieudh;
        private System.Windows.Forms.Label label1;
    }
}