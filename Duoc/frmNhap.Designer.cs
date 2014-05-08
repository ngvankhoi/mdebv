namespace Duoc
{
    partial class frmNhap
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // ngaykiem
            // 
            this.ngaykiem.Size = new System.Drawing.Size(59, 21);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Size = new System.Drawing.Size(815, 241);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(19, 471);
            // 
            // butLuu
            // 
            this.butLuu.Location = new System.Drawing.Point(157, 471);
            // 
            // butBoqua
            // 
            this.butBoqua.Location = new System.Drawing.Point(364, 471);
            // 
            // frmNhap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(821, 534);
            this.Name = "frmNhap";
            this.Load += new System.EventHandler(this.frmNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}