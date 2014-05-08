namespace Medisoft
{
    partial class frmLCD_laocai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLCD_laocai));
            this.SuspendLayout();
            // 
            // frmLCD_laocai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(657, 445);
            this.Name = "frmLCD_laocai";
            this.Text = "frmLCD_laocai";
            this.Load += new System.EventHandler(this.frmLCD_laocai_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLCD_laocai_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmManHinhLCD_Closed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLCD_laocai_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLCD_laocai_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion


    }
}