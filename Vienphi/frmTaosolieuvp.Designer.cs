namespace Vienphi
{
    partial class frmTaosolieuvp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaosolieuvp));
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(61, 11);
            this.tu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(34, 21);
            this.tu.TabIndex = 9;
            this.tu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "đến :";
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(125, 11);
            this.den.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.den.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(34, 21);
            this.den.TabIndex = 11;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = global::Vienphi.Properties.Resources.close_r;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(130, 53);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(84, 29);
            this.butCancel.TabIndex = 15;
            this.butCancel.Text = "   &Kết thúc";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(46, 53);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(84, 29);
            this.butOk.TabIndex = 14;
            this.butOk.Text = "&Tạo";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(191, 11);
            this.yyyy.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(44, 21);
            this.yyyy.TabIndex = 13;
            this.yyyy.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yyyy_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Năm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Từ tháng :";
            // 
            // frmTaosolieuvp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 97);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTaosolieuvp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo số liệu ";
            this.Load += new System.EventHandler(this.frmTaosolieuvp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown tu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown den;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.NumericUpDown yyyy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}