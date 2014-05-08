namespace Duoc
{
    partial class frmDmthuocBYT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmthuocBYT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbodm = new System.Windows.Forms.ComboBox();
            this.dgthuoc = new System.Windows.Forms.DataGridView();
            this.chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hoatchat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duongdung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butluu = new System.Windows.Forms.Button();
            this.butketthuc = new System.Windows.Forms.Button();
            this.dgthuoc05 = new System.Windows.Forms.DataGridView();
            this.id05 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoatchat05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duongdung05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuyenxa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tuyenhuyen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tuyentinh = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tuyentu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.cboloaithuoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgthuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgthuoc05)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn danh mục :";
            // 
            // cbodm
            // 
            this.cbodm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbodm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodm.FormattingEnabled = true;
            this.cbodm.Items.AddRange(new object[] {
            "Danh mục thuốc không kê đơn(TT08)",
            "Danh mục thuốc theo thông tư 05"});
            this.cbodm.Location = new System.Drawing.Point(96, 6);
            this.cbodm.Name = "cbodm";
            this.cbodm.Size = new System.Drawing.Size(453, 21);
            this.cbodm.TabIndex = 1;
            this.cbodm.SelectedIndexChanged += new System.EventHandler(this.cbodm_SelectedIndexChanged);
            // 
            // dgthuoc
            // 
            this.dgthuoc.AllowUserToAddRows = false;
            this.dgthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgthuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgthuoc.BackgroundColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgthuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgthuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgthuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.hoatchat,
            this.duongdung,
            this.id});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgthuoc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgthuoc.Location = new System.Drawing.Point(12, 65);
            this.dgthuoc.Name = "dgthuoc";
            this.dgthuoc.RowHeadersVisible = false;
            this.dgthuoc.Size = new System.Drawing.Size(537, 401);
            this.dgthuoc.TabIndex = 2;
            // 
            // chon
            // 
            this.chon.FillWeight = 30.45685F;
            this.chon.HeaderText = "Chọn";
            this.chon.Name = "chon";
            // 
            // hoatchat
            // 
            this.hoatchat.DataPropertyName = "hoatchat";
            this.hoatchat.FillWeight = 134.7716F;
            this.hoatchat.HeaderText = "Thành phần hoạt chất";
            this.hoatchat.Name = "hoatchat";
            // 
            // duongdung
            // 
            this.duongdung.DataPropertyName = "duongdung";
            this.duongdung.FillWeight = 134.7716F;
            this.duongdung.HeaderText = "Đường dùng, dạng bào chế,giới hạn hàm lượng, nồng độ";
            this.duongdung.Name = "duongdung";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // butluu
            // 
            this.butluu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butluu.Image = ((System.Drawing.Image)(resources.GetObject("butluu.Image")));
            this.butluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butluu.Location = new System.Drawing.Point(405, 472);
            this.butluu.Name = "butluu";
            this.butluu.Size = new System.Drawing.Size(70, 25);
            this.butluu.TabIndex = 3;
            this.butluu.Text = "   &Lưu";
            this.butluu.UseVisualStyleBackColor = true;
            this.butluu.Click += new System.EventHandler(this.butluu_Click);
            // 
            // butketthuc
            // 
            this.butketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butketthuc.Image = ((System.Drawing.Image)(resources.GetObject("butketthuc.Image")));
            this.butketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butketthuc.Location = new System.Drawing.Point(478, 472);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(70, 25);
            this.butketthuc.TabIndex = 4;
            this.butketthuc.Text = "   &Kết thúc";
            this.butketthuc.UseVisualStyleBackColor = true;
            this.butketthuc.Click += new System.EventHandler(this.butketthuc_Click);
            // 
            // dgthuoc05
            // 
            this.dgthuoc05.AllowUserToAddRows = false;
            this.dgthuoc05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgthuoc05.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgthuoc05.BackgroundColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgthuoc05.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgthuoc05.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgthuoc05.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id05,
            this.stt,
            this.hoatchat05,
            this.duongdung05,
            this.tuyenxa,
            this.tuyenhuyen,
            this.tuyentinh,
            this.tuyentu});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgthuoc05.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgthuoc05.Location = new System.Drawing.Point(12, 65);
            this.dgthuoc05.Name = "dgthuoc05";
            this.dgthuoc05.RowHeadersVisible = false;
            this.dgthuoc05.Size = new System.Drawing.Size(537, 401);
            this.dgthuoc05.TabIndex = 5;
            // 
            // id05
            // 
            this.id05.DataPropertyName = "id05";
            this.id05.HeaderText = "id";
            this.id05.Name = "id05";
            this.id05.Visible = false;
            // 
            // stt
            // 
            this.stt.DataPropertyName = "stt";
            this.stt.FillWeight = 53.29949F;
            this.stt.HeaderText = "Stt";
            this.stt.Name = "stt";
            // 
            // hoatchat05
            // 
            this.hoatchat05.DataPropertyName = "hoatchat05";
            this.hoatchat05.FillWeight = 164.0494F;
            this.hoatchat05.HeaderText = "Tên thuốc, hoạt chất";
            this.hoatchat05.Name = "hoatchat05";
            // 
            // duongdung05
            // 
            this.duongdung05.DataPropertyName = "duongdung05";
            this.duongdung05.FillWeight = 164.0494F;
            this.duongdung05.HeaderText = "Đường dùng hoặc dạng đường dùng";
            this.duongdung05.Name = "duongdung05";
            // 
            // tuyenxa
            // 
            this.tuyenxa.FillWeight = 65.65488F;
            this.tuyenxa.HeaderText = "Tuyến xã";
            this.tuyenxa.Name = "tuyenxa";
            // 
            // tuyenhuyen
            // 
            this.tuyenhuyen.FillWeight = 75.64417F;
            this.tuyenhuyen.HeaderText = "Tuyến huyện";
            this.tuyenhuyen.Name = "tuyenhuyen";
            // 
            // tuyentinh
            // 
            this.tuyentinh.FillWeight = 84.61932F;
            this.tuyentinh.HeaderText = "Tuyến tỉnh";
            this.tuyentinh.Name = "tuyentinh";
            // 
            // tuyentu
            // 
            this.tuyentu.FillWeight = 92.68329F;
            this.tuyentu.HeaderText = "Tuyến trung ương";
            this.tuyentu.Name = "tuyentu";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttimkiem.ForeColor = System.Drawing.Color.Red;
            this.txttimkiem.Location = new System.Drawing.Point(13, 474);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(372, 20);
            this.txttimkiem.TabIndex = 6;
            this.txttimkiem.Text = "tìm kiếm";
            this.txttimkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttimkiem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txttimkiem_MouseClick);
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // cboloaithuoc
            // 
            this.cboloaithuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboloaithuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboloaithuoc.FormattingEnabled = true;
            this.cboloaithuoc.Location = new System.Drawing.Point(95, 32);
            this.cboloaithuoc.Name = "cboloaithuoc";
            this.cboloaithuoc.Size = new System.Drawing.Size(453, 21);
            this.cboloaithuoc.TabIndex = 8;
            this.cboloaithuoc.SelectedValueChanged += new System.EventHandler(this.cboloaithuoc_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chọn loại thuốc :";
            // 
            // frmDmthuocBYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 505);
            this.Controls.Add(this.cboloaithuoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.butketthuc);
            this.Controls.Add(this.butluu);
            this.Controls.Add(this.cbodm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgthuoc05);
            this.Controls.Add(this.dgthuoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmthuocBYT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục thuốc theo Bộ Y Tế";
            this.Load += new System.EventHandler(this.frmDmthuocBYT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgthuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgthuoc05)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbodm;
        private System.Windows.Forms.DataGridView dgthuoc;
        private System.Windows.Forms.Button butluu;
        private System.Windows.Forms.Button butketthuc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoatchat;
        private System.Windows.Forms.DataGridViewTextBoxColumn duongdung;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridView dgthuoc05;
        private System.Windows.Forms.DataGridViewCheckBoxColumn id05;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoatchat05;
        private System.Windows.Forms.DataGridViewTextBoxColumn duongdung05;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tuyenxa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tuyenhuyen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tuyentinh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tuyentu;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.ComboBox cboloaithuoc;
        private System.Windows.Forms.Label label2;
    }
}