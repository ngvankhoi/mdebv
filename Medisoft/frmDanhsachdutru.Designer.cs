namespace Medisoft
{
    partial class frmDanhsachdutru
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhsachdutru));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTungay = new System.Windows.Forms.DateTimePicker();
            this.txtDenngay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butXem = new System.Windows.Forms.Button();
            this.butThoat = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtTim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtTungay
            // 
            resources.ApplyResources(this.txtTungay, "txtTungay");
            this.txtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTungay.Name = "txtTungay";
            this.txtTungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTungay_KeyDown);
            // 
            // txtDenngay
            // 
            resources.ApplyResources(this.txtDenngay, "txtDenngay");
            this.txtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenngay.Name = "txtDenngay";
            this.txtDenngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTungay_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cboKhoa
            // 
            resources.ApplyResources(this.cboKhoa, "cboKhoa");
            this.cboKhoa.BackColor = System.Drawing.Color.White;
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTungay_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            resources.ApplyResources(this.dataGrid1, "dataGrid1");
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butXem
            // 
            resources.ApplyResources(this.butXem, "butXem");
            this.butXem.Name = "butXem";
            this.butXem.UseVisualStyleBackColor = true;
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // butThoat
            // 
            resources.ApplyResources(this.butThoat, "butThoat");
            this.butThoat.Name = "butThoat";
            this.butThoat.UseVisualStyleBackColor = true;
            this.butThoat.Click += new System.EventHandler(this.butThoat_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            resources.ApplyResources(this.dataGrid2, "dataGrid2");
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 5;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtThang
            // 
            resources.ApplyResources(this.txtThang, "txtThang");
            this.txtThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Name = "txtThang";
            this.txtThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtNam
            // 
            resources.ApplyResources(this.txtNam, "txtNam");
            this.txtNam.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // txtTim
            // 
            resources.ApplyResources(this.txtTim, "txtTim");
            this.txtTim.ForeColor = System.Drawing.Color.Red;
            this.txtTim.Name = "txtTim";
            this.txtTim.Enter += new System.EventHandler(this.txtTim_Enter);
            this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // frmDanhsachdutru
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butThoat);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDenngay);
            this.Controls.Add(this.txtTungay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.dataGrid2);
            this.Name = "frmDanhsachdutru";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmDanhsachdutru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtTungay;
        private System.Windows.Forms.DateTimePicker txtDenngay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button butXem;
        private System.Windows.Forms.Button butThoat;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtThang;
        private System.Windows.Forms.NumericUpDown txtNam;
        private System.Windows.Forms.TextBox txtTim;
    }
}