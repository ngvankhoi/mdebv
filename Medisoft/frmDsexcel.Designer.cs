namespace Medisoft
{
    partial class frmDsexcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDsexcel));
            this.label20 = new System.Windows.Forms.Label();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.butPath = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sheet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.tt = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(2, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Tập tin  :";
            // 
            // butBoqua
            // 
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(177, 119);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(77, 25);
            this.butBoqua.TabIndex = 8;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(100, 119);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(77, 25);
            this.butLuu.TabIndex = 7;
            this.butLuu.Text = "Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.SystemColors.HighlightText;
            this.path.Enabled = false;
            this.path.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.path.Location = new System.Drawing.Point(49, 7);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(267, 21);
            this.path.TabIndex = 1;
            // 
            // butPath
            // 
            this.butPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPath.Location = new System.Drawing.Point(319, 7);
            this.butPath.Name = "butPath";
            this.butPath.Size = new System.Drawing.Size(24, 21);
            this.butPath.TabIndex = 2;
            this.butPath.Text = "...";
            this.toolTip1.SetToolTip(this.butPath, "Chọn tập tin");
            this.butPath.UseVisualStyleBackColor = true;
            this.butPath.Click += new System.EventHandler(this.butPath_Click);
            // 
            // sheet
            // 
            this.sheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sheet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheet.FormattingEnabled = true;
            this.sheet.Location = new System.Drawing.Point(49, 30);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(267, 21);
            this.sheet.TabIndex = 4;
            this.sheet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sheet_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sheet :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(49, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 34);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng mã";
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(220, 12);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(43, 17);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "VNI";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sheet_KeyDown);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(147, 13);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(60, 17);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "TCVN3";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sheet_KeyDown);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(68, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(65, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Unicode";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sheet_KeyDown);
            // 
            // tt
            // 
            this.tt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tt.FormattingEnabled = true;
            this.tt.Items.AddRange(new object[] {
            "Stt,Họ,Tên,Nam,Nữ",
            "Stt,Họ và tên,Nam,Nữ"});
            this.tt.Location = new System.Drawing.Point(49, 53);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(267, 21);
            this.tt.TabIndex = 5;
            // 
            // frmDsexcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 159);
            this.Controls.Add(this.tt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butPath);
            this.Controls.Add(this.path);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.label20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDsexcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDsexcel";
            this.Load += new System.EventHandler(this.frmDsexcel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button butPath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox sheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.ComboBox tt;
    }
}