namespace Duoc
{
    partial class frmChonthongso
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
            this.ddmmyyyy = new System.Windows.Forms.DateTimePicker();
            this.cmbsophieu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKho = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ddmmyyyy
            // 
            this.ddmmyyyy.CustomFormat = "dd/MM/yyyy";
            this.ddmmyyyy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ddmmyyyy.Location = new System.Drawing.Point(72, 41);
            this.ddmmyyyy.Name = "ddmmyyyy";
            this.ddmmyyyy.Size = new System.Drawing.Size(121, 20);
            this.ddmmyyyy.TabIndex = 1;
            this.ddmmyyyy.ValueChanged += new System.EventHandler(this.ddmmyyyy_ValueChanged);
            this.ddmmyyyy.Validated += new System.EventHandler(this.ddmmyyyy_Validated);
            // 
            // cmbsophieu
            // 
            this.cmbsophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsophieu.FormattingEnabled = true;
            this.cmbsophieu.Location = new System.Drawing.Point(72, 67);
            this.cmbsophieu.Name = "cmbsophieu";
            this.cmbsophieu.Size = new System.Drawing.Size(121, 21);
            this.cmbsophieu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chọn ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chọn phiếu";
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(48, 98);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 25);
            this.butOk.TabIndex = 3;
            this.butOk.Text = "Chọn";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(129, 98);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chọn kho";
            // 
            // cmbKho
            // 
            this.cmbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKho.FormattingEnabled = true;
            this.cmbKho.Location = new System.Drawing.Point(72, 14);
            this.cmbKho.Name = "cmbKho";
            this.cmbKho.Size = new System.Drawing.Size(121, 21);
            this.cmbKho.TabIndex = 0;
            this.cmbKho.SelectedIndexChanged += new System.EventHandler(this.cmbKho_SelectedIndexChanged);
            this.cmbKho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbKho_KeyDown);
            // 
            // frmChonthongso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 134);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbKho);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbsophieu);
            this.Controls.Add(this.ddmmyyyy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChonthongso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn ngày và phiếu ";
            this.Load += new System.EventHandler(this.frmChonthongso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker ddmmyyyy;
        private System.Windows.Forms.ComboBox cmbsophieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKho;
    }
}