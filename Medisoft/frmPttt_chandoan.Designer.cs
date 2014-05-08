namespace Medisoft
{
    partial class frmPttt_chandoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPttt_chandoan));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maicd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chandoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmaicdchinh = new System.Windows.Forms.TextBox();
            this.txtChandoanchinh = new System.Windows.Forms.TextBox();
            this.txtChandoan = new System.Windows.Forms.TextBox();
            this.txtMaicd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.listICD = new LibList.List();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maicd,
            this.c_userid,
            this.chandoan});
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(488, 280);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // maicd
            // 
            this.maicd.DataPropertyName = "maicd";
            this.maicd.HeaderText = "ICD10";
            this.maicd.Name = "maicd";
            this.maicd.ReadOnly = true;
            this.maicd.Width = 80;
            // 
            // c_userid
            // 
            this.c_userid.DataPropertyName = "userid";
            this.c_userid.HeaderText = "Column1";
            this.c_userid.Name = "c_userid";
            this.c_userid.Visible = false;
            // 
            // chandoan
            // 
            this.chandoan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chandoan.DataPropertyName = "chandoan";
            this.chandoan.HeaderText = "Chẩn đoán";
            this.chandoan.Name = "chandoan";
            this.chandoan.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chẩn đoán";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmaicdchinh
            // 
            this.txtmaicdchinh.Enabled = false;
            this.txtmaicdchinh.Location = new System.Drawing.Point(81, 6);
            this.txtmaicdchinh.Name = "txtmaicdchinh";
            this.txtmaicdchinh.Size = new System.Drawing.Size(69, 20);
            this.txtmaicdchinh.TabIndex = 2;
            // 
            // txtChandoanchinh
            // 
            this.txtChandoanchinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChandoanchinh.Enabled = false;
            this.txtChandoanchinh.Location = new System.Drawing.Point(151, 6);
            this.txtChandoanchinh.Name = "txtChandoanchinh";
            this.txtChandoanchinh.Size = new System.Drawing.Size(349, 20);
            this.txtChandoanchinh.TabIndex = 3;
            // 
            // txtChandoan
            // 
            this.txtChandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChandoan.Location = new System.Drawing.Point(151, 319);
            this.txtChandoan.Name = "txtChandoan";
            this.txtChandoan.Size = new System.Drawing.Size(349, 20);
            this.txtChandoan.TabIndex = 6;
            this.txtChandoan.TextChanged += new System.EventHandler(this.txtChandoan_TextChanged);
            this.txtChandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChandoan_KeyDown);
            // 
            // txtMaicd
            // 
            this.txtMaicd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMaicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaicd.Location = new System.Drawing.Point(81, 319);
            this.txtMaicd.Name = "txtMaicd";
            this.txtMaicd.Size = new System.Drawing.Size(69, 20);
            this.txtMaicd.TabIndex = 5;
            this.txtMaicd.Validated += new System.EventHandler(this.txtMaicd_Validated);
            this.txtMaicd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaicd_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(0, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chẩn đoán";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(361, 353);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 285;
            this.butKetthuc.Text = "    &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(291, 353);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 284;
            this.butBoqua.Text = "      &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(151, 353);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 281;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butXoa.BackColor = System.Drawing.SystemColors.Control;
            this.butXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(221, 353);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 283;
            this.butXoa.Text = "      &Xoá";
            this.butXoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butMoi.BackColor = System.Drawing.SystemColors.Control;
            this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(81, 353);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 280;
            this.butMoi.Text = "       &Thêm";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.UseVisualStyleBackColor = true;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(437, 345);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 286;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // frmPttt_chandoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 390);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.txtChandoan);
            this.Controls.Add(this.txtMaicd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChandoanchinh);
            this.Controls.Add(this.txtmaicdchinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPttt_chandoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chẩn đoán";
            this.Load += new System.EventHandler(this.frmPttt_chandoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmaicdchinh;
        private System.Windows.Forms.TextBox txtChandoanchinh;
        private System.Windows.Forms.TextBox txtChandoan;
        private System.Windows.Forms.TextBox txtMaicd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Button butMoi;
        private LibList.List listICD;
        private System.Windows.Forms.DataGridViewTextBoxColumn maicd;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn chandoan;
    }
}