namespace Vienphi
{
    partial class frmBKhoadontaichinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBKhoadontaichinh));
            this.dttungay = new System.Windows.Forms.DateTimePicker();
            this.dtdenngay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butInhoadon = new System.Windows.Forms.Button();
            this.butTim = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbdoituong = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDaduyetin = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dttungay
            // 
            this.dttungay.CustomFormat = "dd/MM/yyyy";
            this.dttungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttungay.Location = new System.Drawing.Point(60, 66);
            this.dttungay.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dttungay.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dttungay.Name = "dttungay";
            this.dttungay.Size = new System.Drawing.Size(81, 20);
            this.dttungay.TabIndex = 1;
            this.dttungay.Value = new System.DateTime(2011, 7, 15, 0, 0, 0, 0);
            // 
            // dtdenngay
            // 
            this.dtdenngay.CustomFormat = "dd/MM/yyyy";
            this.dtdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtdenngay.Location = new System.Drawing.Point(219, 66);
            this.dtdenngay.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dtdenngay.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtdenngay.Name = "dtdenngay";
            this.dtdenngay.Size = new System.Drawing.Size(81, 20);
            this.dtdenngay.TabIndex = 2;
            this.dtdenngay.Value = new System.DateTime(2011, 7, 15, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Đến ngày:";
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(196, 140);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butInhoadon
            // 
            this.butInhoadon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butInhoadon.BackColor = System.Drawing.SystemColors.Control;
            this.butInhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInhoadon.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butInhoadon.Image = ((System.Drawing.Image)(resources.GetObject("butInhoadon.Image")));
            this.butInhoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInhoadon.Location = new System.Drawing.Point(126, 140);
            this.butInhoadon.Name = "butInhoadon";
            this.butInhoadon.Size = new System.Drawing.Size(68, 25);
            this.butInhoadon.TabIndex = 16;
            this.butInhoadon.Text = "&In";
            this.butInhoadon.UseVisualStyleBackColor = true;
            this.butInhoadon.Click += new System.EventHandler(this.butInhoadon_Click);
            // 
            // butTim
            // 
            this.butTim.BackColor = System.Drawing.SystemColors.Control;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(57, 140);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(68, 25);
            this.butTim.TabIndex = 17;
            this.butTim.Text = "     &Xem";
            this.butTim.UseVisualStyleBackColor = true;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Đối tượng:";
            // 
            // cbdoituong
            // 
            this.cbdoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdoituong.Location = new System.Drawing.Point(60, 92);
            this.cbdoituong.Name = "cbdoituong";
            this.cbdoituong.Size = new System.Drawing.Size(240, 21);
            this.cbdoituong.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 52);
            this.panel1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "BẢNG KÊ HÓA ĐƠN TÀI CHÍNH";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDaduyetin
            // 
            this.chkDaduyetin.AutoSize = true;
            this.chkDaduyetin.Location = new System.Drawing.Point(60, 119);
            this.chkDaduyetin.Name = "chkDaduyetin";
            this.chkDaduyetin.Size = new System.Drawing.Size(94, 17);
            this.chkDaduyetin.TabIndex = 21;
            this.chkDaduyetin.Text = "Đã in hóa đơn";
            this.chkDaduyetin.UseVisualStyleBackColor = true;
            // 
            // frmBKhoadontaichinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 168);
            this.ControlBox = false;
            this.Controls.Add(this.chkDaduyetin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbdoituong);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.butInhoadon);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dtdenngay);
            this.Controls.Add(this.dttungay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBKhoadontaichinh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng kê hóa đơn tài chính";
            this.Load += new System.EventHandler(this.frmBKhoadontaichinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dttungay;
        private System.Windows.Forms.DateTimePicker dtdenngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butInhoadon;
        private System.Windows.Forms.Button butTim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbdoituong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDaduyetin;
    }
}