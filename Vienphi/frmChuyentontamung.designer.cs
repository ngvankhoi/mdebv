namespace Vienphi
{
    partial class frmChuyentontamung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyentontamung));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTuMM = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTuYYYY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDenMM = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDenYYYY = new System.Windows.Forms.NumericUpDown();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuYYYY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenYYYY)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Từ tháng :";
            // 
            // txtTuMM
            // 
            this.txtTuMM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuMM.Location = new System.Drawing.Point(86, 7);
            this.txtTuMM.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtTuMM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTuMM.Name = "txtTuMM";
            this.txtTuMM.Size = new System.Drawing.Size(34, 21);
            this.txtTuMM.TabIndex = 10;
            this.txtTuMM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Năm: ";
            // 
            // txtTuYYYY
            // 
            this.txtTuYYYY.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuYYYY.Location = new System.Drawing.Point(166, 7);
            this.txtTuYYYY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtTuYYYY.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtTuYYYY.Name = "txtTuYYYY";
            this.txtTuYYYY.Size = new System.Drawing.Size(44, 21);
            this.txtTuYYYY.TabIndex = 14;
            this.txtTuYYYY.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sang tháng: ";
            // 
            // txtDenMM
            // 
            this.txtDenMM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenMM.Location = new System.Drawing.Point(86, 37);
            this.txtDenMM.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtDenMM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDenMM.Name = "txtDenMM";
            this.txtDenMM.Size = new System.Drawing.Size(34, 21);
            this.txtDenMM.TabIndex = 16;
            this.txtDenMM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Năm: ";
            // 
            // txtDenYYYY
            // 
            this.txtDenYYYY.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenYYYY.Location = new System.Drawing.Point(166, 37);
            this.txtDenYYYY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtDenYYYY.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtDenYYYY.Name = "txtDenYYYY";
            this.txtDenYYYY.Size = new System.Drawing.Size(44, 21);
            this.txtDenYYYY.TabIndex = 18;
            this.txtDenYYYY.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // btOK
            // 
            this.btOK.Image = ((System.Drawing.Image)(resources.GetObject("btOK.Image")));
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(36, 73);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(84, 29);
            this.btOK.TabIndex = 21;
            this.btOK.Text = "&Chuyển";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::Vienphi.Properties.Resources.close_r;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(132, 73);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(84, 29);
            this.btCancel.TabIndex = 22;
            this.btCancel.Text = "   &Kết thúc";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = global::Vienphi.Properties.Resources.close_r;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(132, 73);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(84, 29);
            this.butCancel.TabIndex = 22;
            this.butCancel.Text = "   &Kết thúc";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // frmChuyentontamung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 111);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.txtDenYYYY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDenMM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTuYYYY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTuMM);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmChuyentontamung";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyen ton tam ung";
            this.Load += new System.EventHandler(this.frmChuyentontamung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTuMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuYYYY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenYYYY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtTuMM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtTuYYYY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtDenMM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtDenYYYY;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button btCancel;
    }
}