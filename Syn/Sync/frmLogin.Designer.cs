namespace Server
{
    partial class frmLogin
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnKetthuc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.loginUI1 = new UI.LoginUI();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Image = global::Server.Properties.Resources.key_manytoone;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(49, 111);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Đăng nhập";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnKetthuc
            // 
            this.btnKetthuc.Image = global::Server.Properties.Resources.close_r;
            this.btnKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKetthuc.Location = new System.Drawing.Point(136, 111);
            this.btnKetthuc.Name = "btnKetthuc";
            this.btnKetthuc.Size = new System.Drawing.Size(80, 23);
            this.btnKetthuc.TabIndex = 2;
            this.btnKetthuc.Text = "Kết thúc";
            this.btnKetthuc.UseVisualStyleBackColor = true;
            this.btnKetthuc.Click += new System.EventHandler(this.btnKetthuc_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 30);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHƯƠNG TRÌNH ĐỒNG BỘ DATABASE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loginUI1
            // 
            this.loginUI1.Location = new System.Drawing.Point(21, 33);
            this.loginUI1.Name = "loginUI1";
            this.loginUI1.Size = new System.Drawing.Size(216, 78);
            this.loginUI1.TabIndex = 5;
            this.loginUI1.e_Pass_KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginUI1_e_Pass_KeyDown_1);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 146);
            this.ControlBox = false;
            this.Controls.Add(this.loginUI1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKetthuc);
            this.Controls.Add(this.btnOk);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnKetthuc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private UI.LoginUI loginUI1;
    }
}