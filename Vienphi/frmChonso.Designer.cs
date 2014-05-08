namespace Vienphi
{
    partial class frmChonso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonso));
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbKyhieu = new System.Windows.Forms.ComboBox();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNgaythu = new System.Windows.Forms.DateTimePicker();
            this.chkLocso = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTuden = new System.Windows.Forms.CheckBox();
            this.chkDungchungso = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dichvu = new System.Windows.Forms.ComboBox();
            this.ldichvu = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbThatthu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbThua = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.Color.Black;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(191, 238);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(68, 25);
            this.butBoqua.TabIndex = 1;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.Color.Black;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(122, 238);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(68, 25);
            this.butLuu.TabIndex = 0;
            this.butLuu.Text = "&Đồng ý";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quyển sổ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbKyhieu
            // 
            this.cbKyhieu.BackColor = System.Drawing.Color.White;
            this.cbKyhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKyhieu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKyhieu.FormattingEnabled = true;
            this.cbKyhieu.Location = new System.Drawing.Point(100, 62);
            this.cbKyhieu.Name = "cbKyhieu";
            this.cbKyhieu.Size = new System.Drawing.Size(277, 24);
            this.cbKyhieu.TabIndex = 2;
            this.cbKyhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbKyhieu_KeyDown);
            // 
            // cbLoai
            // 
            this.cbLoai.BackColor = System.Drawing.Color.White;
            this.cbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoai.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(100, 37);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(277, 24);
            this.cbLoai.TabIndex = 1;
            this.cbLoai.SelectedIndexChanged += new System.EventHandler(this.cbLoai_SelectedIndexChanged);
            this.cbLoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLoai_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(39, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Loại:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgaythu
            // 
            this.txtNgaythu.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNgaythu.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtNgaythu.Enabled = false;
            this.txtNgaythu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaythu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgaythu.Location = new System.Drawing.Point(100, 13);
            this.txtNgaythu.Name = "txtNgaythu";
            this.txtNgaythu.Size = new System.Drawing.Size(139, 23);
            this.txtNgaythu.TabIndex = 0;
            this.txtNgaythu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgaythu_KeyDown);
            // 
            // chkLocso
            // 
            this.chkLocso.AutoSize = true;
            this.chkLocso.Checked = true;
            this.chkLocso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocso.Location = new System.Drawing.Point(3, 3);
            this.chkLocso.Name = "chkLocso";
            this.chkLocso.Size = new System.Drawing.Size(101, 17);
            this.chkLocso.TabIndex = 3;
            this.chkLocso.Text = "Lọc sổ theo loại";
            this.chkLocso.UseVisualStyleBackColor = true;
            this.chkLocso.CheckedChanged += new System.EventHandler(this.chkLocso_CheckedChanged);
            this.chkLocso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkLocso_KeyDown);
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Location = new System.Drawing.Point(39, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ngày thu:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // chkTuden
            // 
            this.chkTuden.AutoSize = true;
            this.chkTuden.Checked = true;
            this.chkTuden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTuden.Enabled = false;
            this.chkTuden.Location = new System.Drawing.Point(3, 22);
            this.chkTuden.Name = "chkTuden";
            this.chkTuden.Size = new System.Drawing.Size(180, 17);
            this.chkTuden.TabIndex = 4;
            this.chkTuden.Text = "[Từ số - 1] <= [Số ghi] < [Đến số]";
            this.chkTuden.UseVisualStyleBackColor = true;
            this.chkTuden.CheckedChanged += new System.EventHandler(this.chkTuden_CheckedChanged);
            this.chkTuden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkTuden_KeyDown);
            // 
            // chkDungchungso
            // 
            this.chkDungchungso.AutoSize = true;
            this.chkDungchungso.Enabled = false;
            this.chkDungchungso.Location = new System.Drawing.Point(3, 42);
            this.chkDungchungso.Name = "chkDungchungso";
            this.chkDungchungso.Size = new System.Drawing.Size(99, 17);
            this.chkDungchungso.TabIndex = 5;
            this.chkDungchungso.Text = "Dùng chung sổ";
            this.chkDungchungso.UseVisualStyleBackColor = true;
            this.chkDungchungso.CheckedChanged += new System.EventHandler(this.chkDungchungso_CheckedChanged);
            this.chkDungchungso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkDungchungso_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dichvu);
            this.groupBox1.Controls.Add(this.ldichvu);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.txtNgaythu);
            this.groupBox1.Controls.Add(this.cbLoai);
            this.groupBox1.Controls.Add(this.cbKyhieu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(-7, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dichvu
            // 
            this.dichvu.BackColor = System.Drawing.Color.White;
            this.dichvu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dichvu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dichvu.FormattingEnabled = true;
            this.dichvu.Location = new System.Drawing.Point(100, 88);
            this.dichvu.Name = "dichvu";
            this.dichvu.Size = new System.Drawing.Size(277, 24);
            this.dichvu.TabIndex = 3;
            this.dichvu.Visible = false;
            this.dichvu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbKyhieu_KeyDown);
            // 
            // ldichvu
            // 
            this.ldichvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldichvu.Location = new System.Drawing.Point(6, 86);
            this.ldichvu.Name = "ldichvu";
            this.ldichvu.Size = new System.Drawing.Size(96, 23);
            this.ldichvu.TabIndex = 13;
            this.ldichvu.Text = "Dịch vụ :";
            this.ldichvu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ldichvu.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkLocso);
            this.panel2.Controls.Add(this.chkDungchungso);
            this.panel2.Controls.Add(this.chkTuden);
            this.panel2.Location = new System.Drawing.Point(97, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 62);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbThatthu);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbThua);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(0, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(420, 54);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // cbThatthu
            // 
            this.cbThatthu.BackColor = System.Drawing.Color.White;
            this.cbThatthu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThatthu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThatthu.FormattingEnabled = true;
            this.cbThatthu.Location = new System.Drawing.Point(100, 1);
            this.cbThatthu.Name = "cbThatthu";
            this.cbThatthu.Size = new System.Drawing.Size(277, 24);
            this.cbThatthu.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Quyển sổ thất thu:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbThua
            // 
            this.cbThua.BackColor = System.Drawing.Color.White;
            this.cbThua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThua.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThua.FormattingEnabled = true;
            this.cbThua.Location = new System.Drawing.Point(100, 26);
            this.cbThua.Name = "cbThua";
            this.cbThua.Size = new System.Drawing.Size(277, 24);
            this.cbThua.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quyển sổ thừa:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChonso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 277);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmChonso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Viện phí";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChonso_KeyDown);
            this.Load += new System.EventHandler(this.frmChonso_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKyhieu;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtNgaythu;
        private System.Windows.Forms.CheckBox chkLocso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTuden;
        private System.Windows.Forms.CheckBox chkDungchungso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbThatthu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbThua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dichvu;
        private System.Windows.Forms.Label ldichvu;
    }
}