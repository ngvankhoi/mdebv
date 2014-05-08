namespace Server
{
    partial class frmdmTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdmTable));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.cbMaytram = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yy = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clmChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmShema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.synSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yy)).BeginInit();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmChon,
            this.clmShema,
            this.clmtable,
            this.synSTT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(5, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(387, 276);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(137, 362);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Chọn";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(218, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Kết thúc";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Location = new System.Drawing.Point(71, 52);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(321, 20);
            this.txtTimkiem.TabIndex = 3;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            this.txtTimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimkiem_KeyDown);
            // 
            // cbMaytram
            // 
            this.cbMaytram.FormattingEnabled = true;
            this.cbMaytram.Location = new System.Drawing.Point(71, 30);
            this.cbMaytram.Name = "cbMaytram";
            this.cbMaytram.Size = new System.Drawing.Size(321, 21);
            this.cbMaytram.TabIndex = 2;
            this.cbMaytram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMaytram_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Chọn server :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tìm kiếm";
            // 
            // mm
            // 
            this.mm.Location = new System.Drawing.Point(71, 8);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(60, 20);
            this.mm.TabIndex = 0;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.ValueChanged += new System.EventHandler(this.mm_ValueChanged);
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // yy
            // 
            this.yy.Location = new System.Drawing.Point(175, 7);
            this.yy.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.yy.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yy.Name = "yy";
            this.yy.Size = new System.Drawing.Size(107, 20);
            this.yy.TabIndex = 1;
            this.yy.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yy.ValueChanged += new System.EventHandler(this.yy_ValueChanged);
            this.yy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yy_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tháng :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Năm :";
            // 
            // clmChon
            // 
            this.clmChon.DataPropertyName = "chon";
            this.clmChon.FalseValue = "false";
            this.clmChon.HeaderText = "Chọn";
            this.clmChon.Name = "clmChon";
            this.clmChon.ReadOnly = true;
            this.clmChon.TrueValue = "true";
            this.clmChon.Width = 50;
            // 
            // clmShema
            // 
            this.clmShema.DataPropertyName = "schema_name";
            this.clmShema.HeaderText = "Schema";
            this.clmShema.Name = "clmShema";
            this.clmShema.ReadOnly = true;
            this.clmShema.Width = 80;
            // 
            // clmtable
            // 
            this.clmtable.DataPropertyName = "table_name";
            this.clmtable.HeaderText = "Table";
            this.clmtable.Name = "clmtable";
            this.clmtable.ReadOnly = true;
            this.clmtable.Width = 150;
            // 
            // synSTT
            // 
            this.synSTT.DataPropertyName = "stt";
            this.synSTT.HeaderText = "STT";
            this.synSTT.Name = "synSTT";
            this.synSTT.ReadOnly = true;
            // 
            // frmdmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 397);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yy);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.cbMaytram);
            this.Controls.Add(this.txtTimkiem);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmdmTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn table đồng bộ";
            this.Load += new System.EventHandler(this.dmTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.ComboBox cbMaytram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown mm;
        private System.Windows.Forms.NumericUpDown yy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShema;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmtable;
        private System.Windows.Forms.DataGridViewTextBoxColumn synSTT;
    }
}