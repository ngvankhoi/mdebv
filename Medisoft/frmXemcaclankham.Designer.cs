namespace Medisoft
{
    partial class frmXemcaclankham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemcaclankham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chinhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phongkham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bacsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icd10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chandoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayhen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 15);
            this.label1.TabIndex = 272;
            this.label1.Text = "...";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(696, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 25);
            this.button1.TabIndex = 273;
            this.button1.Text = "   &Kết thúc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ngay,
            this.chinhanh,
            this.phongkham,
            this.bacsi,
            this.icd10,
            this.chandoan,
            this.ngayhen});
            this.dataGridView1.Location = new System.Drawing.Point(5, 24);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(773, 223);
            this.dataGridView1.TabIndex = 274;
            // 
            // ngay
            // 
            this.ngay.DataPropertyName = "ngay";
            this.ngay.HeaderText = "Ngày";
            this.ngay.Name = "ngay";
            this.ngay.ReadOnly = true;
            // 
            // chinhanh
            // 
            this.chinhanh.DataPropertyName = "chinhanh";
            this.chinhanh.HeaderText = "Chi nhánh";
            this.chinhanh.Name = "chinhanh";
            this.chinhanh.ReadOnly = true;
            // 
            // phongkham
            // 
            this.phongkham.DataPropertyName = "phongkham";
            this.phongkham.HeaderText = "Phòng khám";
            this.phongkham.Name = "phongkham";
            this.phongkham.ReadOnly = true;
            this.phongkham.Width = 150;
            // 
            // bacsi
            // 
            this.bacsi.DataPropertyName = "bacsi";
            this.bacsi.HeaderText = "Bác sĩ";
            this.bacsi.Name = "bacsi";
            this.bacsi.ReadOnly = true;
            this.bacsi.Width = 130;
            // 
            // icd10
            // 
            this.icd10.DataPropertyName = "maicd";
            this.icd10.HeaderText = "ICD10";
            this.icd10.Name = "icd10";
            this.icd10.ReadOnly = true;
            this.icd10.Width = 60;
            // 
            // chandoan
            // 
            this.chandoan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chandoan.DataPropertyName = "chandoan";
            this.chandoan.HeaderText = "Chẩn đoán";
            this.chandoan.Name = "chandoan";
            this.chandoan.ReadOnly = true;
            // 
            // ngayhen
            // 
            this.ngayhen.DataPropertyName = "ngayhen";
            this.ngayhen.HeaderText = "Ngày hẹn";
            this.ngayhen.Name = "ngayhen";
            this.ngayhen.ReadOnly = true;
            // 
            // frmXemcaclankham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 290);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemcaclankham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Các lần đã khám";
            this.Load += new System.EventHandler(this.frmXemcaclankham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn chinhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn phongkham;
        private System.Windows.Forms.DataGridViewTextBoxColumn bacsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn icd10;
        private System.Windows.Forms.DataGridViewTextBoxColumn chandoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayhen;
    }
}