namespace DuTruKhoTTB
{
    partial class frmDuTruKhoTTB
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dựTrùKhoTrangThiếtBịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xemtaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.dựTrùKhoTrangThiếtBịToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // dựTrùKhoTrangThiếtBịToolStripMenuItem
            // 
            this.dựTrùKhoTrangThiếtBịToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem1,
            this.MenuItem2,
            this.xemtaToolStripMenuItem});
            this.dựTrùKhoTrangThiếtBịToolStripMenuItem.Name = "dựTrùKhoTrangThiếtBịToolStripMenuItem";
            this.dựTrùKhoTrangThiếtBịToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.dựTrùKhoTrangThiếtBịToolStripMenuItem.Text = "&Dự trù kho trang thiết bị";
            // 
            // MenuItem1
            // 
            this.MenuItem1.Name = "MenuItem1";
            this.MenuItem1.Size = new System.Drawing.Size(190, 22);
            this.MenuItem1.Text = "Phiếu dự trù tài sản";
            this.MenuItem1.Click += new System.EventHandler(this.PhieuDuTruTaiSan_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Name = "MenuItem2";
            this.MenuItem2.Size = new System.Drawing.Size(190, 22);
            this.MenuItem2.Text = "Phiếu hoàn tra tài sản";
            this.MenuItem2.Click += new System.EventHandler(this.PhieuHoanTraTaiSan_Click);
            // 
            // xemtaToolStripMenuItem
            // 
            this.xemtaToolStripMenuItem.Name = "xemtaToolStripMenuItem";
            this.xemtaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.xemtaToolStripMenuItem.Text = "Xem tài sản tại khoa";
            this.xemtaToolStripMenuItem.Click += new System.EventHandler(this.xemtaToolStripMenuItem_Click);
            // 
            // frmDuTruKhoTTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDuTruKhoTTB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dự trù kho trang thiết bị";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dựTrùKhoTrangThiếtBịToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xemtaToolStripMenuItem;
    }
}