namespace Medisoft
{
    partial class frmEditkq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditkq));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dongia = new System.Windows.Forms.TextBox();
            this.lamthem = new System.Windows.Forms.TextBox();
            this.ketqua = new System.Windows.Forms.TextBox();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đơn giá :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Làm thêm :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kết quả :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ghi chú :";
            // 
            // dongia
            // 
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(60, 6);
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(79, 21);
            this.dongia.TabIndex = 1;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dongia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dongia_KeyPress);
            this.dongia.Validated += new System.EventHandler(this.dongia_Validated);
            this.dongia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dongia_KeyDown);
            // 
            // lamthem
            // 
            this.lamthem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.lamthem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lamthem.Location = new System.Drawing.Point(60, 29);
            this.lamthem.Multiline = true;
            this.lamthem.Name = "lamthem";
            this.lamthem.Size = new System.Drawing.Size(257, 39);
            this.lamthem.TabIndex = 3;
            this.lamthem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dongia_KeyDown);
            // 
            // ketqua
            // 
            this.ketqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(60, 70);
            this.ketqua.Multiline = true;
            this.ketqua.Name = "ketqua";
            this.ketqua.Size = new System.Drawing.Size(257, 80);
            this.ketqua.TabIndex = 5;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(60, 152);
            this.ghichu.Multiline = true;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(257, 53);
            this.ghichu.TabIndex = 7;
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(86, 211);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(79, 25);
            this.butLuu.TabIndex = 8;
            this.butLuu.Text = "&Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(167, 211);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(87, 25);
            this.butBoqua.TabIndex = 9;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // label5
            // 
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(41, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 23);
            this.label5.TabIndex = 11;
            this.toolTip1.SetToolTip(this.label5, "Chọn kết quả bình thường");
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // frmEditkq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butBoqua;
            this.ClientSize = new System.Drawing.Size(332, 248);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.lamthem);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditkq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditkq";
            this.Load += new System.EventHandler(this.frmEditkq_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dongia;
        private System.Windows.Forms.TextBox lamthem;
        private System.Windows.Forms.TextBox ketqua;
        private System.Windows.Forms.TextBox ghichu;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}