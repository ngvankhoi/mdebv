namespace Vienphi
{
    partial class frmMedisoftcenterupdate
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedisoftcenterupdate));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butChonall = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.butRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pStart = new System.Windows.Forms.PictureBox();
            this.pStop = new System.Windows.Forms.PictureBox();
            this.butClose = new System.Windows.Forms.Button();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.butSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butDownload = new System.Windows.Forms.Button();
            this.ttProgress = new System.Windows.Forms.ProgressBar();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pStop)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 26);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panel2.Size = new System.Drawing.Size(599, 307);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_chon,
            this.Column_id,
            this.Column_ten,
            this.Column_status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(1, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(593, 277);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            // 
            // Column_chon
            // 
            this.Column_chon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_chon.DataPropertyName = "chon";
            this.Column_chon.FalseValue = "0";
            this.Column_chon.Frozen = true;
            this.Column_chon.HeaderText = "Chọn";
            this.Column_chon.IndeterminateValue = "0";
            this.Column_chon.Name = "Column_chon";
            this.Column_chon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_chon.ToolTipText = "Chọn";
            this.Column_chon.TrueValue = "1";
            this.Column_chon.Width = 35;
            // 
            // Column_id
            // 
            this.Column_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_id.DataPropertyName = "id";
            this.Column_id.HeaderText = "id";
            this.Column_id.Name = "Column_id";
            this.Column_id.ReadOnly = true;
            this.Column_id.Visible = false;
            this.Column_id.Width = 40;
            // 
            // Column_ten
            // 
            this.Column_ten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ten.DataPropertyName = "ten";
            this.Column_ten.HeaderText = "Nội dung cập nhật";
            this.Column_ten.Name = "Column_ten";
            this.Column_ten.ReadOnly = true;
            this.Column_ten.ToolTipText = "Nội dung cập nhật";
            // 
            // Column_status
            // 
            this.Column_status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_status.DataPropertyName = "status";
            this.Column_status.HeaderText = "Status";
            this.Column_status.Name = "Column_status";
            this.Column_status.ReadOnly = true;
            this.Column_status.Width = 73;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butChonall,
            this.toolStripSeparator1,
            this.butRefresh,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(1, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(593, 25);
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butChonall
            // 
            this.butChonall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butChonall.Image = ((System.Drawing.Image)(resources.GetObject("butChonall.Image")));
            this.butChonall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butChonall.Name = "butChonall";
            this.butChonall.Size = new System.Drawing.Size(23, 22);
            this.butChonall.Text = "Chọn / không chọn tất cả";
            this.butChonall.Click += new System.EventHandler(this.butChonall_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // butRefresh
            // 
            this.butRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butRefresh.Image = ((System.Drawing.Image)(resources.GetObject("butRefresh.Image")));
            this.butRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(23, 22);
            this.butRefresh.ToolTipText = "Refresh";
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // pStart
            // 
            this.pStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pStart.Image = ((System.Drawing.Image)(resources.GetObject("pStart.Image")));
            this.pStart.Location = new System.Drawing.Point(544, 3);
            this.pStart.Name = "pStart";
            this.pStart.Size = new System.Drawing.Size(53, 23);
            this.pStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pStart.TabIndex = 0;
            this.pStart.TabStop = false;
            // 
            // pStop
            // 
            this.pStop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pStop.Image = ((System.Drawing.Image)(resources.GetObject("pStop.Image")));
            this.pStop.Location = new System.Drawing.Point(455, 4);
            this.pStop.Name = "pStop";
            this.pStop.Size = new System.Drawing.Size(55, 51);
            this.pStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pStop.TabIndex = 2;
            this.pStop.TabStop = false;
            this.pStop.Visible = false;
            // 
            // butClose
            // 
            this.butClose.BackColor = System.Drawing.SystemColors.Control;
            this.butClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(524, 3);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(73, 25);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "      Bỏ qua";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.ForestGreen;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(1, 1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(599, 25);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(261, 22);
            this.toolStripLabel1.Text = "MEDISOFT CENTER UPDATE";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.SystemColors.Control;
            this.butSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSave.Enabled = false;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSave.Location = new System.Drawing.Point(443, 3);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(81, 25);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "      Cập nhật";
            this.butSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butDownload);
            this.panel3.Controls.Add(this.ttProgress);
            this.panel3.Controls.Add(this.butSave);
            this.panel3.Controls.Add(this.butClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1, 333);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.panel3.Size = new System.Drawing.Size(599, 30);
            this.panel3.TabIndex = 14;
            // 
            // butDownload
            // 
            this.butDownload.BackColor = System.Drawing.SystemColors.Control;
            this.butDownload.Dock = System.Windows.Forms.DockStyle.Right;
            this.butDownload.Enabled = false;
            this.butDownload.Image = ((System.Drawing.Image)(resources.GetObject("butDownload.Image")));
            this.butDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDownload.Location = new System.Drawing.Point(357, 3);
            this.butDownload.Name = "butDownload";
            this.butDownload.Size = new System.Drawing.Size(86, 25);
            this.butDownload.TabIndex = 0;
            this.butDownload.Text = "      Tải về";
            this.butDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDownload.UseVisualStyleBackColor = true;
            this.butDownload.Click += new System.EventHandler(this.butDownload_Click);
            // 
            // ttProgress
            // 
            this.ttProgress.Location = new System.Drawing.Point(3, 6);
            this.ttProgress.Name = "ttProgress";
            this.ttProgress.Size = new System.Drawing.Size(134, 17);
            this.ttProgress.TabIndex = 13;
            // 
            // frmMedisoftcenterupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 364);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pStart);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.pStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMedisoftcenterupdate";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft Center Update";
            this.Load += new System.EventHandler(this.frmMedisoftcenterupdate_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pStop)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.PictureBox pStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.PictureBox pStop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar ttProgress;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butChonall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton butRefresh;
        private System.Windows.Forms.Button butDownload;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_status;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}