namespace Server
{
    partial class frmDmemail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmemail));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_tieude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_noidung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTieude = new System.Windows.Forms.TextBox();
            this.txtNoidung = new System.Windows.Forms.TextBox();
            this.butExit = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.cmbloai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_id,
            this.c_ten,
            this.c_tieude,
            this.c_noidung});
            this.dataGridView1.Location = new System.Drawing.Point(12, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(294, 353);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // c_id
            // 
            this.c_id.DataPropertyName = "id";
            this.c_id.HeaderText = "ID";
            this.c_id.Name = "c_id";
            this.c_id.ReadOnly = true;
            this.c_id.Width = 30;
            // 
            // c_ten
            // 
            this.c_ten.DataPropertyName = "ten";
            this.c_ten.HeaderText = "Tên";
            this.c_ten.Name = "c_ten";
            this.c_ten.ReadOnly = true;
            // 
            // c_tieude
            // 
            this.c_tieude.DataPropertyName = "tieude";
            this.c_tieude.HeaderText = "Tiêu đề";
            this.c_tieude.Name = "c_tieude";
            this.c_tieude.ReadOnly = true;
            this.c_tieude.Width = 170;
            // 
            // c_noidung
            // 
            this.c_noidung.DataPropertyName = "noidung";
            this.c_noidung.HeaderText = "noidung";
            this.c_noidung.Name = "c_noidung";
            this.c_noidung.ReadOnly = true;
            this.c_noidung.Visible = false;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Enabled = false;
            this.txtTen.Location = new System.Drawing.Point(389, 30);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(383, 20);
            this.txtTen.TabIndex = 1;
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbloai_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Danh sách Email mẫu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tiêu đề";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nội dung";
            // 
            // txtTieude
            // 
            this.txtTieude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTieude.Enabled = false;
            this.txtTieude.Location = new System.Drawing.Point(389, 53);
            this.txtTieude.Name = "txtTieude";
            this.txtTieude.Size = new System.Drawing.Size(383, 20);
            this.txtTieude.TabIndex = 2;
            this.txtTieude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbloai_KeyDown);
            // 
            // txtNoidung
            // 
            this.txtNoidung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoidung.Enabled = false;
            this.txtNoidung.Location = new System.Drawing.Point(389, 75);
            this.txtNoidung.Multiline = true;
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.Size = new System.Drawing.Size(383, 308);
            this.txtNoidung.TabIndex = 3;
            // 
            // butExit
            // 
            this.butExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(542, 412);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(87, 25);
            this.butExit.TabIndex = 9;
            this.butExit.Text = "Kết thúc";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(456, 412);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(86, 25);
            this.butCancel.TabIndex = 8;
            this.butCancel.Text = "Bỏ qua";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butDel
            // 
            this.butDel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butDel.Image = ((System.Drawing.Image)(resources.GetObject("butDel.Image")));
            this.butDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDel.Location = new System.Drawing.Point(381, 412);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 25);
            this.butDel.TabIndex = 7;
            this.butDel.Text = "Xóa";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butEdit
            // 
            this.butEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butEdit.Image = ((System.Drawing.Image)(resources.GetObject("butEdit.Image")));
            this.butEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEdit.Location = new System.Drawing.Point(306, 412);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(75, 25);
            this.butEdit.TabIndex = 6;
            this.butEdit.Text = "Sửa";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSave.Location = new System.Drawing.Point(231, 412);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 25);
            this.butSave.TabIndex = 5;
            this.butSave.Text = "Lưu";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butNew
            // 
            this.butNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butNew.Image = ((System.Drawing.Image)(resources.GetObject("butNew.Image")));
            this.butNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNew.Location = new System.Drawing.Point(156, 412);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 25);
            this.butNew.TabIndex = 4;
            this.butNew.Text = "Mới";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // cmbloai
            // 
            this.cmbloai.FormattingEnabled = true;
            this.cmbloai.Items.AddRange(new object[] {
            "",
            "Nhắc Bệnh nhân tái khám",
            "Thông báo Bệnh nhân BS nghỉ phép",
            "Thông báo Bệnh nhân khi có hội thảo",
            "Thông báo Bệnh nhân khi có khuyến mại",
            "Khác"});
            this.cmbloai.Location = new System.Drawing.Point(389, 7);
            this.cmbloai.Name = "cmbloai";
            this.cmbloai.Size = new System.Drawing.Size(383, 21);
            this.cmbloai.TabIndex = 0;
            this.cmbloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbloai_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Loại mail";
            // 
            // frmDmemail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbloai);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butNew);
            this.Controls.Add(this.txtNoidung);
            this.Controls.Add(this.txtTieude);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmemail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục Email";
            this.Load += new System.EventHandler(this.frmDmemail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTieude;
        private System.Windows.Forms.TextBox txtNoidung;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_tieude;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_noidung;
        private System.Windows.Forms.ComboBox cmbloai;
        private System.Windows.Forms.Label label5;
    }
}