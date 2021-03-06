namespace Medisoft
{
    partial class frmClsmau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClsmau));
            this.mau = new System.Windows.Forms.ComboBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.butChon = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mau
            // 
            this.mau.BackColor = System.Drawing.SystemColors.Info;
            this.mau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mau.FormattingEnabled = true;
            this.mau.Location = new System.Drawing.Point(1, 1);
            this.mau.Name = "mau";
            this.mau.Size = new System.Drawing.Size(580, 21);
            this.mau.TabIndex = 0;
            this.mau.SelectedIndexChanged += new System.EventHandler(this.mau_SelectedIndexChanged);
            this.mau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mau_KeyDown);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(1, 23);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.ReadOnly = true;
            this.ten.Size = new System.Drawing.Size(607, 418);
            this.ten.TabIndex = 3;
            // 
            // butChon
            // 
            this.butChon.Image = ((System.Drawing.Image)(resources.GetObject("butChon.Image")));
            this.butChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChon.Location = new System.Drawing.Point(219, 447);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(84, 25);
            this.butChon.TabIndex = 1;
            this.butChon.Text = "&Chọn";
            this.butChon.UseVisualStyleBackColor = true;
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(305, 447);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(80, 25);
            this.butBoqua.TabIndex = 2;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // chkAll
            // 
            this.chkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(582, -1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(26, 24);
            this.chkAll.TabIndex = 320;
            this.chkAll.Text = "...";
            this.chkAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkAll, "Liệt kê tất cả");
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmClsmau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butBoqua;
            this.ClientSize = new System.Drawing.Size(609, 479);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butChon);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.mau);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClsmau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả";
            this.Load += new System.EventHandler(this.frmClsmau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mau;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.Button butChon;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkAll;
    }
}