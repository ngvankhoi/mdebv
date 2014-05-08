namespace tiemchung
{
    partial class frmTheodoinhietdotulanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheodoinhietdotulanh));
            this.label2 = new System.Windows.Forms.Label();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.butin = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNgay = new System.Windows.Forms.DateTimePicker();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.cboDonvi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBuoi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkXml = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tháng:";
            // 
            // cmbThang
            // 
            this.cmbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbThang.Location = new System.Drawing.Point(53, 11);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(46, 21);
            this.cmbThang.TabIndex = 35;
            this.cmbThang.SelectedIndexChanged += new System.EventHandler(this.cmbThang_SelectedIndexChanged);
            // 
            // butin
            // 
            this.butin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butin.Image = ((System.Drawing.Image)(resources.GetObject("butin.Image")));
            this.butin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butin.Location = new System.Drawing.Point(637, 363);
            this.butin.Name = "butin";
            this.butin.Size = new System.Drawing.Size(70, 25);
            this.butin.TabIndex = 46;
            this.butin.Text = "&In";
            this.butin.Click += new System.EventHandler(this.butin_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(707, 363);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 47;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(567, 363);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 45;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(149, 11);
            this.numNam.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(49, 20);
            this.numNam.TabIndex = 48;
            this.numNam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numNam.ValueChanged += new System.EventHandler(this.cmbThang_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Năm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Ngày làm việc:";
            // 
            // txtNgay
            // 
            this.txtNgay.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgay.Location = new System.Drawing.Point(287, 11);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(126, 20);
            this.txtNgay.TabIndex = 50;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(767, 344);
            this.dataGrid1.TabIndex = 51;
            // 
            // cboDonvi
            // 
            this.cboDonvi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDonvi.BackColor = System.Drawing.Color.White;
            this.cboDonvi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonvi.FormattingEnabled = true;
            this.cboDonvi.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboDonvi.Location = new System.Drawing.Point(470, 10);
            this.cboDonvi.Name = "cboDonvi";
            this.cboDonvi.Size = new System.Drawing.Size(192, 21);
            this.cboDonvi.TabIndex = 53;
            this.cboDonvi.SelectedIndexChanged += new System.EventHandler(this.cmbThang_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Đơn vị";
            // 
            // cboBuoi
            // 
            this.cboBuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBuoi.BackColor = System.Drawing.Color.White;
            this.cboBuoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuoi.FormattingEnabled = true;
            this.cboBuoi.Items.AddRange(new object[] {
            "Sáng",
            "Chiều",
            "Cả ngày"});
            this.cboBuoi.Location = new System.Drawing.Point(700, 10);
            this.cboBuoi.Name = "cboBuoi";
            this.cboBuoi.Size = new System.Drawing.Size(77, 21);
            this.cboBuoi.TabIndex = 55;
            this.cboBuoi.SelectedIndexChanged += new System.EventHandler(this.cmbThang_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Buổi:";
            // 
            // chkXml
            // 
            this.chkXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(12, 371);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(48, 17);
            this.chkXml.TabIndex = 56;
            this.chkXml.Text = "XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // frmTheodoinhietdotulanh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 403);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.cboBuoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboDonvi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numNam);
            this.Controls.Add(this.butin);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.cmbThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTheodoinhietdotulanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theo dõi nhiệt độ tủ lạnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTheodoinhietdotulanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Button butin;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtNgay;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.ComboBox cboDonvi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBuoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkXml;
    }
}