namespace Server
{
    partial class frmThucong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThucong));
            this.label1 = new System.Windows.Forms.Label();
            this.dgrChinhanh = new System.Windows.Forms.DataGridView();
            this.dgrChinhanh_chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgrChinhanh_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrChinhanh_Chinhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrChinhanh_server = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgrChinhanh_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrChinhanh_port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrChinhanh_database = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTungay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDenngay = new System.Windows.Forms.DateTimePicker();
            this.butOK = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.RichTextBox();
            this.proStatus = new System.Windows.Forms.ProgressBar();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblstatuss = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.Trangthai = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtMabn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrChinhanh)).BeginInit();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dữ liệu cần lấy:";
            // 
            // dgrChinhanh
            // 
            this.dgrChinhanh.AllowDrop = true;
            this.dgrChinhanh.AllowUserToAddRows = false;
            this.dgrChinhanh.AllowUserToDeleteRows = false;
            this.dgrChinhanh.AllowUserToResizeColumns = false;
            this.dgrChinhanh.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgrChinhanh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrChinhanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrChinhanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgrChinhanh.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgrChinhanh.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgrChinhanh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrChinhanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrChinhanh.ColumnHeadersHeight = 40;
            this.dgrChinhanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrChinhanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgrChinhanh_chon,
            this.dgrChinhanh_ID,
            this.dgrChinhanh_Chinhanh,
            this.dgrChinhanh_server,
            this.dgrChinhanh_ip,
            this.dgrChinhanh_port,
            this.dgrChinhanh_database});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrChinhanh.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrChinhanh.GridColor = System.Drawing.Color.Gainsboro;
            this.dgrChinhanh.Location = new System.Drawing.Point(92, 33);
            this.dgrChinhanh.MultiSelect = false;
            this.dgrChinhanh.Name = "dgrChinhanh";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrChinhanh.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrChinhanh.RowHeadersVisible = false;
            this.dgrChinhanh.RowHeadersWidth = 20;
            this.dgrChinhanh.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgrChinhanh.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrChinhanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrChinhanh.Size = new System.Drawing.Size(443, 230);
            this.dgrChinhanh.StandardTab = true;
            this.dgrChinhanh.TabIndex = 33;
            // 
            // dgrChinhanh_chon
            // 
            this.dgrChinhanh_chon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgrChinhanh_chon.DataPropertyName = "chon";
            this.dgrChinhanh_chon.FalseValue = "False";
            this.dgrChinhanh_chon.HeaderText = "Chọn";
            this.dgrChinhanh_chon.MinimumWidth = 2;
            this.dgrChinhanh_chon.Name = "dgrChinhanh_chon";
            this.dgrChinhanh_chon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrChinhanh_chon.TrueValue = "True";
            this.dgrChinhanh_chon.Width = 35;
            // 
            // dgrChinhanh_ID
            // 
            this.dgrChinhanh_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgrChinhanh_ID.DataPropertyName = "id";
            this.dgrChinhanh_ID.HeaderText = "Mã";
            this.dgrChinhanh_ID.Name = "dgrChinhanh_ID";
            this.dgrChinhanh_ID.ReadOnly = true;
            this.dgrChinhanh_ID.Visible = false;
            this.dgrChinhanh_ID.Width = 50;
            // 
            // dgrChinhanh_Chinhanh
            // 
            this.dgrChinhanh_Chinhanh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgrChinhanh_Chinhanh.DataPropertyName = "ten";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgrChinhanh_Chinhanh.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrChinhanh_Chinhanh.HeaderText = "Chi nhánh";
            this.dgrChinhanh_Chinhanh.Name = "dgrChinhanh_Chinhanh";
            // 
            // dgrChinhanh_server
            // 
            this.dgrChinhanh_server.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgrChinhanh_server.DataPropertyName = "server";
            this.dgrChinhanh_server.FalseValue = "False";
            this.dgrChinhanh_server.HeaderText = "Chuyển về trung tâm";
            this.dgrChinhanh_server.Name = "dgrChinhanh_server";
            this.dgrChinhanh_server.TrueValue = "True";
            this.dgrChinhanh_server.Width = 65;
            // 
            // dgrChinhanh_ip
            // 
            this.dgrChinhanh_ip.DataPropertyName = "ip";
            this.dgrChinhanh_ip.HeaderText = "IP";
            this.dgrChinhanh_ip.Name = "dgrChinhanh_ip";
            this.dgrChinhanh_ip.Width = 42;
            // 
            // dgrChinhanh_port
            // 
            this.dgrChinhanh_port.DataPropertyName = "port";
            this.dgrChinhanh_port.HeaderText = "Port";
            this.dgrChinhanh_port.Name = "dgrChinhanh_port";
            this.dgrChinhanh_port.Width = 51;
            // 
            // dgrChinhanh_database
            // 
            this.dgrChinhanh_database.DataPropertyName = "database_local";
            this.dgrChinhanh_database.HeaderText = "Database";
            this.dgrChinhanh_database.Name = "dgrChinhanh_database";
            this.dgrChinhanh_database.Width = 78;
            // 
            // txtTungay
            // 
            this.txtTungay.CustomFormat = "dd/MM/yyyy";
            this.txtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTungay.Location = new System.Drawing.Point(92, 7);
            this.txtTungay.Name = "txtTungay";
            this.txtTungay.Size = new System.Drawing.Size(95, 20);
            this.txtTungay.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Từ ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Đến ngày:";
            // 
            // txtDenngay
            // 
            this.txtDenngay.CustomFormat = "dd/MM/yyyy";
            this.txtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenngay.Location = new System.Drawing.Point(252, 7);
            this.txtDenngay.Name = "txtDenngay";
            this.txtDenngay.Size = new System.Drawing.Size(95, 20);
            this.txtDenngay.TabIndex = 36;
            // 
            // butOK
            // 
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(90, 454);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 25);
            this.butOK.TabIndex = 40;
            this.butOK.Text = "  &Chuyển";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butExit
            // 
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(165, 454);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 25);
            this.butExit.TabIndex = 41;
            this.butExit.Text = "  &Kết thúc";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.BackColor = System.Drawing.Color.White;
            this.txtText.Location = new System.Drawing.Point(92, 269);
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(443, 155);
            this.txtText.TabIndex = 42;
            this.txtText.Text = "";
            // 
            // proStatus
            // 
            this.proStatus.Location = new System.Drawing.Point(92, 428);
            this.proStatus.Name = "proStatus";
            this.proStatus.Size = new System.Drawing.Size(443, 23);
            this.proStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.proStatus.TabIndex = 43;
            // 
            // status
            // 
            this.status.AutoSize = false;
            this.status.Dock = System.Windows.Forms.DockStyle.None;
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatuss,
            this.statusServer,
            this.Trangthai});
            this.status.Location = new System.Drawing.Point(243, 457);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(291, 22);
            this.status.TabIndex = 44;
            this.status.Text = "statusStrip1";
            // 
            // lblstatuss
            // 
            this.lblstatuss.BackColor = System.Drawing.Color.Transparent;
            this.lblstatuss.Name = "lblstatuss";
            this.lblstatuss.Size = new System.Drawing.Size(35, 17);
            this.lblstatuss.Text = "ready";
            // 
            // statusServer
            // 
            this.statusServer.AutoSize = false;
            this.statusServer.BackColor = System.Drawing.SystemColors.Control;
            this.statusServer.Name = "statusServer";
            this.statusServer.Size = new System.Drawing.Size(150, 17);
            this.statusServer.Text = "Local";
            // 
            // Trangthai
            // 
            this.Trangthai.AutoSize = false;
            this.Trangthai.BackColor = System.Drawing.SystemColors.Control;
            this.Trangthai.Name = "Trangthai";
            this.Trangthai.Size = new System.Drawing.Size(250, 17);
            // 
            // txtMabn
            // 
            this.txtMabn.Location = new System.Drawing.Point(435, 7);
            this.txtMabn.Name = "txtMabn";
            this.txtMabn.Size = new System.Drawing.Size(100, 20);
            this.txtMabn.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Mã BN:";
            // 
            // frmThucong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 485);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMabn);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.proStatus);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDenngay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTungay);
            this.Controls.Add(this.dgrChinhanh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThucong";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đồng bộ thông tin khám sức khoẻ";
            this.Load += new System.EventHandler(this.frmThucong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrChinhanh)).EndInit();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgrChinhanh;
        private System.Windows.Forms.DateTimePicker txtTungay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDenngay;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butExit;
        public System.Windows.Forms.RichTextBox txtText;
        public System.Windows.Forms.ProgressBar proStatus;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel lblstatuss;
        private System.Windows.Forms.ToolStripStatusLabel statusServer;
        private System.Windows.Forms.ToolStripStatusLabel Trangthai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgrChinhanh_chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrChinhanh_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrChinhanh_Chinhanh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgrChinhanh_server;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrChinhanh_ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrChinhanh_port;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgrChinhanh_database;
        private System.Windows.Forms.TextBox txtMabn;
        private System.Windows.Forms.Label label4;

    }
}