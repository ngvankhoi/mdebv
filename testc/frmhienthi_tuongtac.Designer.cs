namespace testc
{
    partial class frmhienthi_tuongtac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmhienthi_tuongtac));
            this.butClose = new System.Windows.Forms.Button();
            this.lblDiengiai = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTieude = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.Location = new System.Drawing.Point(385, 429);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(112, 26);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "Đó&ng lại";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // lblDiengiai
            // 
            this.lblDiengiai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiengiai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiengiai.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblDiengiai.Location = new System.Drawing.Point(0, 0);
            this.lblDiengiai.Name = "lblDiengiai";
            this.lblDiengiai.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblDiengiai.Size = new System.Drawing.Size(773, 269);
            this.lblDiengiai.TabIndex = 4;
            this.lblDiengiai.Text = "label2";
            this.lblDiengiai.Click += new System.EventHandler(this.lblDiengiai_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblDiengiai);
            this.panel3.Location = new System.Drawing.Point(5, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(775, 271);
            this.panel3.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTieude);
            this.panel1.Location = new System.Drawing.Point(5, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 139);
            this.panel1.TabIndex = 8;
            // 
            // lblTieude
            // 
            this.lblTieude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieude.ForeColor = System.Drawing.Color.Red;
            this.lblTieude.Location = new System.Drawing.Point(0, 0);
            this.lblTieude.Name = "lblTieude";
            this.lblTieude.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblTieude.Size = new System.Drawing.Size(773, 137);
            this.lblTieude.TabIndex = 4;
            this.lblTieude.Text = "label2";
            this.lblTieude.Click += new System.EventHandler(this.lblTieude_Click);
            // 
            // frmhienthi_tuongtac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 479);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.butClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmhienthi_tuongtac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tương tác thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmhienthi_tuongtac_KeyDown);
            this.Load += new System.EventHandler(this.frmhienthi_tuongtac_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label lblDiengiai;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTieude;
    }
}