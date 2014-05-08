namespace Medisoft
{
    partial class frmChonpk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonpk));
            ((System.ComponentModel.ISupportInitialize)(this.dtbs)).BeginInit();
            this.SuspendLayout();
            // 
            // makp
            // 
            this.makp.DisplayMember = "TENKP";
            this.makp.Location = new System.Drawing.Point(48, 11);
            this.makp.ValueMember = "MAKP";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 11);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 103);
            this.label1.Visible = false;
            // 
            // phong
            // 
            this.phong.DisplayMember = "TEN";
            this.phong.Location = new System.Drawing.Point(48, 103);
            this.phong.ValueMember = "ID";
            this.phong.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-9, 127);
            this.label5.Visible = false;
            // 
            // tenbs
            // 
            this.tenbs.Location = new System.Drawing.Point(88, 127);
            this.tenbs.Visible = false;
            // 
            // mabs
            // 
            this.mabs.Location = new System.Drawing.Point(48, 127);
            this.mabs.Visible = false;
            // 
            // listBS
            // 
            this.listBS.DisplayMember = "MA";
            this.listBS.ValueMember = "HOTEN";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(137, 44);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(61, 44);
            // 
            // tenba
            // 
            this.tenba.DisplayMember = "TENVT";
            this.tenba.Location = new System.Drawing.Point(48, 80);
            this.tenba.ValueMember = "MABA";
            this.tenba.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-1, 80);
            this.label3.Visible = false;
            // 
            // frmChonpk
            // 
            this.ClientSize = new System.Drawing.Size(258, 78);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonpk";
            this.Load += new System.EventHandler(this.frmChonpk_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.phong, 0);
            this.Controls.SetChildIndex(this.mabs, 0);
            this.Controls.SetChildIndex(this.tenbs, 0);
            this.Controls.SetChildIndex(this.tenba, 0);
            this.Controls.SetChildIndex(this.butCancel, 0);
            this.Controls.SetChildIndex(this.butOk, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.makp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
