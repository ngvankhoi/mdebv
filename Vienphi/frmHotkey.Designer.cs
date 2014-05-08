namespace Vienphi
{
    partial class frmHotkey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHotkey));
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.txtGhichu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbHotkey = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(133, 58);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(74, 28);
            this.butBoqua.TabIndex = 3;
            this.butBoqua.Text = "   &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(60, 58);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(74, 28);
            this.butLuu.TabIndex = 2;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // txtGhichu
            // 
            this.txtGhichu.BackColor = System.Drawing.Color.White;
            this.txtGhichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtGhichu.Location = new System.Drawing.Point(70, 34);
            this.txtGhichu.MaxLength = 255;
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(145, 21);
            this.txtGhichu.TabIndex = 1;
            this.txtGhichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhichu_KeyDown);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Ghi chú:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbHotkey
            // 
            this.cbHotkey.BackColor = System.Drawing.Color.White;
            this.cbHotkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHotkey.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHotkey.FormattingEnabled = true;
            this.cbHotkey.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F11",
            "F12"});
            this.cbHotkey.Location = new System.Drawing.Point(70, 11);
            this.cbHotkey.Name = "cbHotkey";
            this.cbHotkey.Size = new System.Drawing.Size(145, 21);
            this.cbHotkey.TabIndex = 0;
            this.cbHotkey.SelectedIndexChanged += new System.EventHandler(this.cbHotkey_SelectedIndexChanged);
            this.cbHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbHotkey_KeyDown);
            // 
            // label26
            // 
            this.label26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(5, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(68, 20);
            this.label26.TabIndex = 68;
            this.label26.Text = "Phím nóng:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmHotkey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 96);
            this.ControlBox = false;
            this.Controls.Add(this.cbHotkey);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtGhichu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmHotkey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt phím nóng";
            this.Load += new System.EventHandler(this.frmHotkey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.TextBox txtGhichu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbHotkey;
        private System.Windows.Forms.Label label26;
    }
}