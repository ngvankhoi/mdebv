namespace Medisoft
{
    partial class frmCongthucchenhlech
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongthucchenhlech));
            this.cbloai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clloaivp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clgia_1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clgia_2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.butKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbloai
            // 
            this.cbloai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbloai.Location = new System.Drawing.Point(43, 4);
            this.cbloai.Name = "cbloai";
            this.cbloai.Size = new System.Drawing.Size(121, 21);
            this.cbloai.TabIndex = 1;
            this.cbloai.SelectedIndexChanged += new System.EventHandler(this.cbloai_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loai:";
            // 
            // btOk
            // 
            this.btOk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.Black;
            this.btOk.Image = global::Medisoft.Properties.Resources.ok;
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(276, 292);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(68, 25);
            this.btOk.TabIndex = 11;
            this.btOk.Text = "   &Lưu";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clloaivp,
            this.clgia_1,
            this.clgia_2});
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(430, 236);
            this.dataGridView1.TabIndex = 36;
            // 
            // clloaivp
            // 
            this.clloaivp.DataPropertyName = "loaivp";
            this.clloaivp.HeaderText = "Loại viện phí";
            this.clloaivp.Name = "clloaivp";
            this.clloaivp.Width = 200;
            // 
            // clgia_1
            // 
            this.clgia_1.DataPropertyName = "gia_1";
            this.clgia_1.HeaderText = "Giá 1";
            this.clgia_1.Name = "clgia_1";
            this.clgia_1.Width = 60;
            // 
            // clgia_2
            // 
            this.clgia_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clgia_2.DataPropertyName = "gia_2";
            this.clgia_2.HeaderText = "Giá 2";
            this.clgia_2.Name = "clgia_2";
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Black;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(347, 292);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 37;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmCongthucchenhlech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 347);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.cbloai);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCongthucchenhlech";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công thức tính chênh lệch";
            this.Load += new System.EventHandler(this.frmCongthucchenhlech_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbloai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn clloaivp;
        private System.Windows.Forms.DataGridViewComboBoxColumn clgia_1;
        private System.Windows.Forms.DataGridViewComboBoxColumn clgia_2;
        private System.Windows.Forms.Button butKetthuc;
    }
}