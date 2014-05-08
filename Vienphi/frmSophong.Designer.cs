namespace Vienphi
{
    partial class frmSophong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSophong));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_blank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ngayud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_Tim = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_Title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.toolStrip3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "group.ico");
            this.imageList1.Images.SetKeyName(1, "t_icon_ok_ (3).ico");
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.ForestGreen;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripLabel3});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(1, 1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(716, 60);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 57);
            this.toolStripButton5.Text = "Hướng dẫn";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(225, 57);
            this.toolStripLabel3.Text = "KHAI BÁO SỐ PHÒNG";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Location = new System.Drawing.Point(1, 452);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(716, 25);
            this.toolStrip2.TabIndex = 13;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 61);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel3.Size = new System.Drawing.Size(716, 391);
            this.panel3.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.toolStrip1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 2);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2, 0, 1, 1);
            this.panel5.Size = new System.Drawing.Size(711, 387);
            this.panel5.TabIndex = 2;
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
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_hoten,
            this.Column_blank,
            this.Column_ngayud});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(2, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(704, 357);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 1;
            // 
            // Column_ID
            // 
            this.Column_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_ID.DataPropertyName = "id";
            this.Column_ID.HeaderText = "Mã VP";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 64;
            // 
            // Column_hoten
            // 
            this.Column_hoten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_hoten.DataPropertyName = "ten";
            this.Column_hoten.HeaderText = "Tên viện phí";
            this.Column_hoten.Name = "Column_hoten";
            this.Column_hoten.ReadOnly = true;
            this.Column_hoten.Width = 458;
            // 
            // Column_blank
            // 
            this.Column_blank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_blank.DataPropertyName = "sophong";
            this.Column_blank.HeaderText = "Số Phòng";
            this.Column_blank.Name = "Column_blank";
            this.Column_blank.ReadOnly = true;
            this.Column_blank.Width = 79;
            // 
            // Column_ngayud
            // 
            this.Column_ngayud.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ngayud.DataPropertyName = "ngayud";
            this.Column_ngayud.HeaderText = "Ngày cập nhật";
            this.Column_ngayud.Name = "Column_ngayud";
            this.Column_ngayud.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(1, 2, 2, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_Refresh,
            this.toolStripSeparator1,
            this.toolStrip_Tim,
            this.toolStrip_Title,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(2, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(704, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip_Refresh
            // 
            this.toolStrip_Refresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStrip_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_Refresh.Image")));
            this.toolStrip_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_Refresh.Name = "toolStrip_Refresh";
            this.toolStrip_Refresh.Size = new System.Drawing.Size(23, 22);
            this.toolStrip_Refresh.Text = "Nạp lại danh sách";
            this.toolStrip_Refresh.ToolTipText = "Nạp lại danh sách người sử dụng";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip_Tim
            // 
            this.toolStrip_Tim.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_Tim.BackColor = System.Drawing.Color.White;
            this.toolStrip_Tim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_Tim.Font = new System.Drawing.Font("Tahoma", 7F);
            this.toolStrip_Tim.Name = "toolStrip_Tim";
            this.toolStrip_Tim.Size = new System.Drawing.Size(100, 25);
            this.toolStrip_Tim.ToolTipText = "Nhập nội dung cần tìm trên lưới vào đây";
            // 
            // toolStrip_Title
            // 
            this.toolStrip_Title.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStrip_Title.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStrip_Title.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_Title.Image")));
            this.toolStrip_Title.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStrip_Title.Name = "toolStrip_Title";
            this.toolStrip_Title.Size = new System.Drawing.Size(135, 22);
            this.toolStrip_Title.Text = "Danh sách số phòng";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(712, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 387);
            this.label2.TabIndex = 1;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.BackColor = System.Drawing.SystemColors.Control;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSave.Location = new System.Drawing.Point(572, 450);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(70, 25);
            this.butSave.TabIndex = 15;
            this.butSave.Text = "      Lưu";
            this.butSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSave.UseVisualStyleBackColor = true;
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.BackColor = System.Drawing.SystemColors.Control;
            this.butClose.Image = global::Vienphi.Properties.Resources.close_r;
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(642, 450);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(70, 25);
            this.butClose.TabIndex = 16;
            this.butClose.Text = "      Đóng";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.UseVisualStyleBackColor = true;
            // 
            // frmSophong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 477);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSophong";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo số phòng";
            this.Load += new System.EventHandler(this.frmSophong_Load);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_blank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ngayud;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStrip_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStrip_Tim;
        private System.Windows.Forms.ToolStripLabel toolStrip_Title;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butClose;
    }
}