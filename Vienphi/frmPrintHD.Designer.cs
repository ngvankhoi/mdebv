namespace Vienphi
{
    partial class frmPrintHD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintHD));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.banin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.butExcel = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.butPdf = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(597, 4);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(51, 23);
            this.butIn.TabIndex = 15;
            this.butIn.Text = "      In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(760, 4);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(74, 23);
            this.butKetthuc.TabIndex = 17;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(355, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "&Số bản in :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Từ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // banin
            // 
            this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banin.Location = new System.Drawing.Point(411, 5);
            this.banin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.banin.Name = "banin";
            this.banin.Size = new System.Drawing.Size(38, 21);
            this.banin.TabIndex = 10;
            this.banin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(552, 5);
            this.den.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(44, 21);
            this.den.TabIndex = 14;
            // 
            // butExcel
            // 
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(647, 4);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(60, 23);
            this.butExcel.TabIndex = 16;
            this.butExcel.Text = "      Excel";
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(473, 5);
            this.tu.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(44, 21);
            this.tu.TabIndex = 12;
            // 
            // butPdf
            // 
            this.butPdf.Image = ((System.Drawing.Image)(resources.GetObject("butPdf.Image")));
            this.butPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPdf.Location = new System.Drawing.Point(706, 4);
            this.butPdf.Name = "butPdf";
            this.butPdf.Size = new System.Drawing.Size(55, 23);
            this.butPdf.TabIndex = 18;
            this.butPdf.Text = "PDF";
            this.butPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPdf.UseVisualStyleBackColor = true;
            this.butPdf.Click += new System.EventHandler(this.butPdf_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayBackgroundEdge = false;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(1, 1);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(836, 572);
            this.crystalReportViewer1.TabIndex = 19;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // frmPrintHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 573);
            this.Controls.Add(this.butPdf);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.banin);
            this.Controls.Add(this.den);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crystalReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPrintHD";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In hoá đơn";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintHD_KeyDown);
            this.Load += new System.EventHandler(this.frmPrintHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.banin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown banin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown den;
        private System.Windows.Forms.Button butExcel;
        private System.Windows.Forms.NumericUpDown tu;
        private System.Windows.Forms.Button butPdf;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}