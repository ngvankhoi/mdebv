namespace Server
{
    partial class frmQuanlyDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanlyDatabase));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mmyy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mmyy,
            this.clmShema,
            this.syn});
            this.dataGridView1.Location = new System.Drawing.Point(23, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(213, 187);
            this.dataGridView1.TabIndex = 5;
            // 
            // mmyy
            // 
            this.mmyy.DataPropertyName = "mmyy";
            this.mmyy.HeaderText = "mmyy";
            this.mmyy.Name = "mmyy";
            this.mmyy.Visible = false;
            this.mmyy.Width = 50;
            // 
            // clmShema
            // 
            this.clmShema.DataPropertyName = "schemas";
            this.clmShema.HeaderText = "Schema";
            this.clmShema.Name = "clmShema";
            this.clmShema.Width = 80;
            // 
            // syn
            // 
            this.syn.DataPropertyName = "syn";
            this.syn.FalseValue = "0";
            this.syn.HeaderText = "Đồng bộ";
            this.syn.IndeterminateValue = "";
            this.syn.Name = "syn";
            this.syn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.syn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.syn.TrueValue = "1";
            this.syn.Width = 80;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(39, 202);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnKetthuc
            // 
            this.btnKetthuc.Location = new System.Drawing.Point(120, 202);
            this.btnKetthuc.Name = "btnKetthuc";
            this.btnKetthuc.Size = new System.Drawing.Size(75, 23);
            this.btnKetthuc.TabIndex = 7;
            this.btnKetthuc.Text = "Kết thúc";
            this.btnKetthuc.UseVisualStyleBackColor = true;
            this.btnKetthuc.Click += new System.EventHandler(this.btnKetthuc_Click);
            // 
            // frmQuanlyDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 248);
            this.Controls.Add(this.btnKetthuc);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQuanlyDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý đồng bộ";
            this.Load += new System.EventHandler(this.frmQuanlyDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnKetthuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn mmyy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShema;
        private System.Windows.Forms.DataGridViewCheckBoxColumn syn;
    }
}