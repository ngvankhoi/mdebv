namespace Vienphi
{
    partial class frmDoiso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiso));
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbKyhieu = new System.Windows.Forms.ComboBox();
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
            this.butBoqua.Location = new System.Drawing.Point(155, 44);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(83, 26);
            this.butBoqua.TabIndex = 2;
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
            this.butLuu.Location = new System.Drawing.Point(68, 44);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(87, 26);
            this.butLuu.TabIndex = 1;
            this.butLuu.Text = "    &Đồng ý";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sổ thu mới:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbKyhieu
            // 
            this.cbKyhieu.BackColor = System.Drawing.Color.White;
            this.cbKyhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKyhieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKyhieu.FormattingEnabled = true;
            this.cbKyhieu.Location = new System.Drawing.Point(69, 21);
            this.cbKyhieu.Name = "cbKyhieu";
            this.cbKyhieu.Size = new System.Drawing.Size(168, 21);
            this.cbKyhieu.TabIndex = 0;
            this.cbKyhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbKyhieu_KeyDown);
            // 
            // frmDoiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 96);
            this.ControlBox = false;
            this.Controls.Add(this.cbKyhieu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDoiso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi sổ hóa đơn";
            this.Load += new System.EventHandler(this.frmDoiso_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKyhieu;
    }
}