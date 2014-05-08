namespace Server
{
    partial class frmDmTableAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmTableAuto));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.list1 = new LibList.List();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.chkCuoingay = new System.Windows.Forms.CheckBox();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnKetthuc = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTableF = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmShema,
            this.clmtable,
            this.clmTableF});
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(439, 313);
            this.dataGridView1.TabIndex = 4;
            // 
            // txtSchema
            // 
            this.txtSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSchema.Location = new System.Drawing.Point(68, 331);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(73, 20);
            this.txtSchema.TabIndex = 0;
            this.txtSchema.Validated += new System.EventHandler(this.txtSchema_Validated);
            this.txtSchema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSchema_KeyDown);
            // 
            // txtTableName
            // 
            this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTableName.Location = new System.Drawing.Point(182, 331);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(259, 20);
            this.txtTableName.TabIndex = 1;
            this.txtTableName.TextChanged += new System.EventHandler(this.txtTableName_TextChanged);
            this.txtTableName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTableName_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Schema";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Table";
            // 
            // list1
            // 
            this.list1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.list1.ColumnCount = 0;
            this.list1.FormattingEnabled = true;
            this.list1.Location = new System.Drawing.Point(3, 404);
            this.list1.MatchBufferTimeOut = 1000;
            this.list1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(75, 17);
            this.list1.TabIndex = 6;
            this.list1.TextIndex = -1;
            this.list1.TextMember = null;
            this.list1.ValueIndex = -1;
            this.list1.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(196, 374);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Lưu";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.Location = new System.Drawing.Point(260, 374);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(69, 27);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // chkCuoingay
            // 
            this.chkCuoingay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCuoingay.AutoSize = true;
            this.chkCuoingay.Location = new System.Drawing.Point(68, 354);
            this.chkCuoingay.Name = "chkCuoingay";
            this.chkCuoingay.Size = new System.Drawing.Size(73, 17);
            this.chkCuoingay.TabIndex = 7;
            this.chkCuoingay.Text = "Cuối ngày";
            this.chkCuoingay.UseVisualStyleBackColor = true;
            // 
            // btnMoi
            // 
            this.btnMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoi.Location = new System.Drawing.Point(68, 374);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(64, 27);
            this.btnMoi.TabIndex = 8;
            this.btnMoi.Text = "Mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            // 
            // btnKetthuc
            // 
            this.btnKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKetthuc.Location = new System.Drawing.Point(329, 374);
            this.btnKetthuc.Name = "btnKetthuc";
            this.btnKetthuc.Size = new System.Drawing.Size(64, 27);
            this.btnKetthuc.TabIndex = 9;
            this.btnKetthuc.Text = "Kết thúc";
            this.btnKetthuc.UseVisualStyleBackColor = true;
            this.btnKetthuc.Click += new System.EventHandler(this.btnKetthuc_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSua.Location = new System.Drawing.Point(132, 374);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(64, 27);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // clmID
            // 
            this.clmID.HeaderText = "STT";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            this.clmID.Width = 50;
            // 
            // clmShema
            // 
            this.clmShema.DataPropertyName = "schema";
            this.clmShema.HeaderText = "Schema";
            this.clmShema.Name = "clmShema";
            this.clmShema.ReadOnly = true;
            this.clmShema.Width = 80;
            // 
            // clmtable
            // 
            this.clmtable.DataPropertyName = "table";
            this.clmtable.HeaderText = "Table";
            this.clmtable.Name = "clmtable";
            this.clmtable.ReadOnly = true;
            this.clmtable.Width = 150;
            // 
            // clmTableF
            // 
            this.clmTableF.DataPropertyName = "key";
            this.clmTableF.HeaderText = "Primary key";
            this.clmTableF.Name = "clmTableF";
            this.clmTableF.ReadOnly = true;
            this.clmTableF.Width = 150;
            // 
            // frmDmTableAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 437);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnKetthuc);
            this.Controls.Add(this.btnMoi);
            this.Controls.Add(this.chkCuoingay);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.list1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.txtSchema);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmTableAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DM Table Auto update";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDmTableAuto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSchema;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private LibList.List list1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.CheckBox chkCuoingay;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnKetthuc;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShema;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtable;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTableF;
    }
}