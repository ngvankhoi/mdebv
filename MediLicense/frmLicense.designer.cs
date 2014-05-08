namespace MediLicense
{
    partial class frmLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicense));
            this.butGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.butExit = new DevExpress.XtraEditors.SimpleButton();
            this.butCont = new DevExpress.XtraEditors.SimpleButton();
            this.txtKey = new System.Windows.Forms.RichTextBox();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // butGenerate
            // 
            this.butGenerate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butGenerate.Image = ((System.Drawing.Image)(resources.GetObject("butGenerate.Image")));
            this.butGenerate.Location = new System.Drawing.Point(214, 163);
            this.butGenerate.LookAndFeel.SkinName = "Blue";
            this.butGenerate.LookAndFeel.UseDefaultLookAndFeel = false;
            this.butGenerate.Name = "butGenerate";
            this.butGenerate.Size = new System.Drawing.Size(75, 23);
            this.butGenerate.TabIndex = 0;
            this.butGenerate.Text = "Generate";
            this.butGenerate.Click += new System.EventHandler(this.butGenerate_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Key";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Code";
            // 
            // butExit
            // 
            this.butExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(294, 163);
            this.butExit.LookAndFeel.SkinName = "Blue";
            this.butExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 6;
            this.butExit.Text = "&Exit";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butCont
            // 
            this.butCont.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCont.Image = ((System.Drawing.Image)(resources.GetObject("butCont.Image")));
            this.butCont.Location = new System.Drawing.Point(133, 163);
            this.butCont.LookAndFeel.SkinName = "Blue";
            this.butCont.LookAndFeel.UseDefaultLookAndFeel = false;
            this.butCont.Name = "butCont";
            this.butCont.Size = new System.Drawing.Size(75, 23);
            this.butCont.TabIndex = 7;
            this.butCont.Text = "Coninue";
            this.butCont.Click += new System.EventHandler(this.butCont_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(49, 3);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(425, 75);
            this.txtKey.TabIndex = 8;
            this.txtKey.Text = "";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(49, 82);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(425, 75);
            this.txtCode.TabIndex = 9;
            this.txtCode.Text = "";
            // 
            // frmLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 195);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.butCont);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.butGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Money Twins";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLicense";
            this.Text = "Generate License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton butGenerate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton butExit;
        private DevExpress.XtraEditors.SimpleButton butCont;
        private System.Windows.Forms.RichTextBox txtKey;
        private System.Windows.Forms.RichTextBox txtCode;
    }
}