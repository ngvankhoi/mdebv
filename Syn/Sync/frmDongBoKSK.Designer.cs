namespace Server
{
    partial class frmDongBoKSK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDongBoKSK));
            this.dgDSDoan = new System.Windows.Forms.DataGridView();
            this.chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tendoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.chkLaymau = new System.Windows.Forms.CheckBox();
            this.chkChaymau = new System.Windows.Forms.CheckBox();
            this.chkKhamKQCLS = new System.Windows.Forms.CheckBox();
            this.butExit = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblstatuss = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.Trangthai = new System.Windows.Forms.ToolStripStatusLabel();
            this.proStatus = new System.Windows.Forms.ProgressBar();
            this.txtText = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgDSDoan)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgDSDoan
            // 
            this.dgDSDoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDSDoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.id,
            this.tendoan});
            this.dgDSDoan.Location = new System.Drawing.Point(3, 26);
            this.dgDSDoan.Name = "dgDSDoan";
            this.dgDSDoan.Size = new System.Drawing.Size(636, 225);
            this.dgDSDoan.TabIndex = 0;
            // 
            // chon
            // 
            this.chon.DataPropertyName = "chon";
            this.chon.HeaderText = "Chọn";
            this.chon.Name = "chon";
            this.chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // tendoan
            // 
            this.tendoan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tendoan.DataPropertyName = "ten";
            this.tendoan.HeaderText = "Đoàn Khám";
            this.tendoan.Name = "tendoan";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(3, 3);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(636, 20);
            this.txtTim.TabIndex = 1;
            this.txtTim.Text = "Tìm kiếm";
            this.txtTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkLaymau
            // 
            this.chkLaymau.AutoSize = true;
            this.chkLaymau.Location = new System.Drawing.Point(3, 258);
            this.chkLaymau.Name = "chkLaymau";
            this.chkLaymau.Size = new System.Drawing.Size(126, 17);
            this.chkLaymau.TabIndex = 2;
            this.chkLaymau.Text = "Lây thông tin lấy máu";
            this.chkLaymau.UseVisualStyleBackColor = true;
            // 
            // chkChaymau
            // 
            this.chkChaymau.AutoSize = true;
            this.chkChaymau.Location = new System.Drawing.Point(135, 258);
            this.chkChaymau.Name = "chkChaymau";
            this.chkChaymau.Size = new System.Drawing.Size(136, 17);
            this.chkChaymau.TabIndex = 3;
            this.chkChaymau.Text = "Lấy thông tin chạy mẫu";
            this.chkChaymau.UseVisualStyleBackColor = true;
            // 
            // chkKhamKQCLS
            // 
            this.chkKhamKQCLS.AutoSize = true;
            this.chkKhamKQCLS.Location = new System.Drawing.Point(277, 258);
            this.chkKhamKQCLS.Name = "chkKhamKQCLS";
            this.chkKhamKQCLS.Size = new System.Drawing.Size(188, 17);
            this.chkKhamKQCLS.TabIndex = 4;
            this.chkKhamKQCLS.Text = "Lấy thông tin khám + Kết quả CLS";
            this.chkKhamKQCLS.UseVisualStyleBackColor = true;
            // 
            // butExit
            // 
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(323, 379);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 25);
            this.butExit.TabIndex = 43;
            this.butExit.Text = "  &Kết thúc";
            this.butExit.UseVisualStyleBackColor = true;
            // 
            // butOK
            // 
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(233, 379);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(90, 25);
            this.butOK.TabIndex = 42;
            this.butOK.Text = "  &Lấy dữ liệu";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatuss,
            this.statusServer,
            this.Trangthai});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 44;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblstatuss
            // 
            this.lblstatuss.Name = "lblstatuss";
            this.lblstatuss.Size = new System.Drawing.Size(38, 17);
            this.lblstatuss.Text = "Ready";
            // 
            // statusServer
            // 
            this.statusServer.AutoSize = false;
            this.statusServer.Name = "statusServer";
            this.statusServer.Size = new System.Drawing.Size(150, 17);
            this.statusServer.Text = "Label1";
            // 
            // Trangthai
            // 
            this.Trangthai.AutoSize = false;
            this.Trangthai.Name = "Trangthai";
            this.Trangthai.Size = new System.Drawing.Size(250, 17);
            // 
            // proStatus
            // 
            this.proStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.proStatus.Location = new System.Drawing.Point(0, 412);
            this.proStatus.Name = "proStatus";
            this.proStatus.Size = new System.Drawing.Size(640, 23);
            this.proStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.proStatus.TabIndex = 45;
            // 
            // txtText
            // 
            this.txtText.BackColor = System.Drawing.Color.White;
            this.txtText.Location = new System.Drawing.Point(2, 278);
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(637, 97);
            this.txtText.TabIndex = 46;
            this.txtText.Text = "";
            // 
            // frmDongBoKSK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 457);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.proStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.chkKhamKQCLS);
            this.Controls.Add(this.chkChaymau);
            this.Controls.Add(this.chkLaymau);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.dgDSDoan);
            this.Name = "frmDongBoKSK";
            this.ShowIcon = false;
            this.Text = "Đồng bộ dữ liệu khám sức khỏe";
            this.Load += new System.EventHandler(this.frmDongBoKSK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDSDoan)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDSDoan;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.CheckBox chkLaymau;
        private System.Windows.Forms.CheckBox chkChaymau;
        private System.Windows.Forms.CheckBox chkKhamKQCLS;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendoan;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblstatuss;
        private System.Windows.Forms.ToolStripStatusLabel statusServer;
        private System.Windows.Forms.ToolStripStatusLabel Trangthai;
        public System.Windows.Forms.ProgressBar proStatus;
        public System.Windows.Forms.RichTextBox txtText;
    }
}