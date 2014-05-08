namespace LTCControl
{
    partial class LTCDataGridList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.splFilter = new System.Windows.Forms.Splitter();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgData
            // 
            this.dgData.AllowUserToResizeRows = false;
            this.dgData.BackgroundColor = System.Drawing.Color.White;
            this.dgData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgData.Location = new System.Drawing.Point(0, 24);
            this.dgData.MultiSelect = false;
            this.dgData.Name = "dgData";
            this.dgData.RowHeadersWidth = 25;
            this.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgData.Size = new System.Drawing.Size(565, 313);
            this.dgData.TabIndex = 0;
            this.dgData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgData_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "_chon_";
            this.Column1.FalseValue = "0";
            this.Column1.HeaderText = "Column1";
            this.Column1.IndeterminateValue = "0";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.TrueValue = "1";
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "_ten_";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // pTitle
            // 
            this.pTitle.BackColor = System.Drawing.SystemColors.Control;
            this.pTitle.Controls.Add(this.lbTitle);
            this.pTitle.Controls.Add(this.chkAll);
            this.pTitle.Controls.Add(this.cbFilter);
            this.pTitle.Controls.Add(this.splFilter);
            this.pTitle.Controls.Add(this.txtFilter);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.pTitle.Size = new System.Drawing.Size(565, 24);
            this.pTitle.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(19, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(403, 22);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "lbTitle";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAll
            // 
            this.chkAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAll.Location = new System.Drawing.Point(0, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(19, 22);
            this.chkAll.TabIndex = 0;
            this.toolTip1.SetToolTip(this.chkAll, "Chọn (bỏ chọn) tất cả");
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cbFilter
            // 
            this.cbFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(422, 1);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(59, 21);
            this.cbFilter.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbFilter, "Điều kiện lọc (Filter by)");
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.cbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFilter_KeyDown);
            // 
            // splFilter
            // 
            this.splFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.splFilter.Location = new System.Drawing.Point(481, 1);
            this.splFilter.Name = "splFilter";
            this.splFilter.Size = new System.Drawing.Size(3, 22);
            this.splFilter.TabIndex = 2;
            this.splFilter.TabStop = false;
            this.splFilter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splFilter_SplitterMoved);
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(484, 1);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(81, 21);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.Text = "Search";
            this.txtFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtFilter, "Nội dung lọc (Filter value)");
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            this.txtFilter.Leave += new System.EventHandler(this.txtFilter_Leave);
            this.txtFilter.Enter += new System.EventHandler(this.txtFilter_Enter);
            // 
            // LTCDataGridList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgData);
            this.Controls.Add(this.pTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LTCDataGridList";
            this.Size = new System.Drawing.Size(565, 337);
            this.Load += new System.EventHandler(this.LTCDataGridList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTitle;
        public System.Windows.Forms.Label lbTitle;
        public System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Splitter splFilter;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkAll;
        public System.Windows.Forms.ComboBox cbFilter;
        public System.Windows.Forms.TextBox txtFilter;
    }
}
