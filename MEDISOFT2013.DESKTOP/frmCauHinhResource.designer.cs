namespace MEDISOFT2011.DESKTOP
{
    partial class frmCauHinhResource
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
            this.butForm = new DevExpress.XtraEditors.SimpleButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirectoryForm = new DevExpress.XtraEditors.TextEdit();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.butResource = new DevExpress.XtraEditors.SimpleButton();
            this.txtDirectoryPathResource = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectoryForm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectoryPathResource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // butForm
            // 
            this.butForm.Location = new System.Drawing.Point(685, 27);
            this.butForm.Name = "butForm";
            this.butForm.Size = new System.Drawing.Size(128, 23);
            this.butForm.TabIndex = 0;
            this.butForm.Text = "Directory Path Form";
            this.butForm.Click += new System.EventHandler(this.butForm_Click);
            // 
            // txtDirectoryForm
            // 
            this.txtDirectoryForm.Location = new System.Drawing.Point(58, 30);
            this.txtDirectoryForm.Name = "txtDirectoryForm";
            this.txtDirectoryForm.Properties.ReadOnly = true;
            this.txtDirectoryForm.Size = new System.Drawing.Size(621, 20);
            this.txtDirectoryForm.TabIndex = 1;
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(58, 117);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(260, 23);
            this.butSave.TabIndex = 2;
            this.butSave.Text = "Đổ dữ liệu vào resource tiếng anh";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butResource
            // 
            this.butResource.Location = new System.Drawing.Point(685, 63);
            this.butResource.Name = "butResource";
            this.butResource.Size = new System.Drawing.Size(128, 23);
            this.butResource.TabIndex = 0;
            this.butResource.Text = "Directory Path Resource";
            this.butResource.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtDirectoryPathResource
            // 
            this.txtDirectoryPathResource.Location = new System.Drawing.Point(58, 66);
            this.txtDirectoryPathResource.Name = "txtDirectoryPathResource";
            this.txtDirectoryPathResource.Properties.ReadOnly = true;
            this.txtDirectoryPathResource.Size = new System.Drawing.Size(621, 20);
            this.txtDirectoryPathResource.TabIndex = 1;
            // 
            // frmCauHinhResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 182);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.txtDirectoryPathResource);
            this.Controls.Add(this.butResource);
            this.Controls.Add(this.txtDirectoryForm);
            this.Controls.Add(this.butForm);
            this.Name = "frmCauHinhResource";
            this.Text = "frmCauHinhResource";
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectoryForm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectoryPathResource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton butForm;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.TextEdit txtDirectoryForm;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SimpleButton butResource;
        private DevExpress.XtraEditors.TextEdit txtDirectoryPathResource;
    }
}