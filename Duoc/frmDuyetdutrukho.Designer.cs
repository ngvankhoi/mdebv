namespace Duoc
{
    partial class frmDuyetdutrukho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetdutrukho));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.timkiem = new System.Windows.Forms.TextBox();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butThuhoi = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.butRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(1, 5);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(472, 412);
            this.dataGrid1.TabIndex = 38;
            // 
            // timkiem
            // 
            this.timkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timkiem.Location = new System.Drawing.Point(479, 2);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(153, 20);
            this.timkiem.TabIndex = 54;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timkiem.Enter += new System.EventHandler(this.timkiem_Enter);
            this.timkiem.Leave += new System.EventHandler(this.timkiem_Leave);
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(55, 1);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(105, 21);
            this.cmbSophieu.TabIndex = 48;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(55, 2);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.MaxLength = 10;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(72, 21);
            this.sophieu.TabIndex = 52;
            // 
            // txtTitle
            // 
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(296, 2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(177, 20);
            this.txtTitle.TabIndex = 53;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(199, 1);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 50;
            this.ngaysp.Text = "  /  /    ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 47;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(153, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 49;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(262, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 23);
            this.label9.TabIndex = 51;
            this.label9.Text = "Kho : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(250, 423);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 46;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(110, 423);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 45;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butThuhoi
            // 
            this.butThuhoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThuhoi.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butThuhoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThuhoi.Location = new System.Drawing.Point(180, 423);
            this.butThuhoi.Name = "butThuhoi";
            this.butThuhoi.Size = new System.Drawing.Size(70, 25);
            this.butThuhoi.TabIndex = 44;
            this.butThuhoi.Text = "     &Thu hồi";
            this.butThuhoi.Click += new System.EventHandler(this.butThuhoi_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(40, 423);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 42;
            this.butMoi.Text = "    &Duyệt";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(326, 428);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(48, 17);
            this.chkXem.TabIndex = 55;
            this.chkXem.Text = "XML";
            this.chkXem.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(479, 24);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(153, 398);
            this.treeView1.TabIndex = 56;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            // 
            // butRefresh
            // 
            this.butRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRefresh.Location = new System.Drawing.Point(479, 425);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(153, 25);
            this.butRefresh.TabIndex = 75;
            this.butRefresh.Text = "&Refresh(F5)";
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // frmDuyetdutrukho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.butRefresh);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butThuhoi);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDuyetdutrukho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách các phiếu đã duyệt";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDuyetdutrukho_KeyDown);
            this.Load += new System.EventHandler(this.frmDuyetdutrukho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butThuhoi;
        private System.Windows.Forms.Button butMoi;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox timkiem;
        private System.Windows.Forms.ComboBox cmbSophieu;
        private MaskedTextBox.MaskedTextBox sophieu;
        private System.Windows.Forms.TextBox txtTitle;
        private MaskedBox.MaskedBox ngaysp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkXem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button butRefresh;
    }
}