namespace Vienphi
{
    partial class frmChonvpct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonvpct));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tmn_Title = new System.Windows.Forms.ToolStripLabel();
            this.tmn_Sotien = new System.Windows.Forms.ToolStripTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tmn_Boqua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmn_Chon = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmn_Chonall = new System.Windows.Forms.ToolStripButton();
            this.tmn_Display = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmn_Bochonall = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tmn_Clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.txtTimnhanh = new System.Windows.Forms.ToolStripTextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "group.ico");
            this.imageList1.Images.SetKeyName(1, "t_icon_ok_ (3).ico");
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.ForestGreen;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmn_Title,
            this.tmn_Sotien});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(1, 1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.toolStrip3.Size = new System.Drawing.Size(787, 51);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tmn_Title
            // 
            this.tmn_Title.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.tmn_Title.ForeColor = System.Drawing.Color.White;
            this.tmn_Title.Name = "tmn_Title";
            this.tmn_Title.Size = new System.Drawing.Size(169, 48);
            this.tmn_Title.Text = "CHỌN VIỆN PHÍ";
            // 
            // tmn_Sotien
            // 
            this.tmn_Sotien.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tmn_Sotien.BackColor = System.Drawing.Color.ForestGreen;
            this.tmn_Sotien.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.tmn_Sotien.ForeColor = System.Drawing.Color.Orange;
            this.tmn_Sotien.Name = "tmn_Sotien";
            this.tmn_Sotien.ReadOnly = true;
            this.tmn_Sotien.Size = new System.Drawing.Size(200, 51);
            this.tmn_Sotien.Text = "0";
            this.tmn_Sotien.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tmn_Sotien.ToolTipText = "Tổng số tiền đã chọn";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeView1);
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 52);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel3.Size = new System.Drawing.Size(787, 465);
            this.panel3.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(181, -21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 480);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.ForeColor = System.Drawing.SystemColors.Info;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(784, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 461);
            this.label2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmn_Boqua,
            this.toolStripSeparator1,
            this.tmn_Chon,
            this.toolStripSeparator3,
            this.tmn_Chonall,
            this.tmn_Display,
            this.toolStripSeparator5,
            this.toolStripSeparator2,
            this.tmn_Bochonall,
            this.toolStripSeparator6,
            this.tmn_Clear,
            this.toolStripSeparator7,
            this.txtTimnhanh});
            this.toolStrip1.Location = new System.Drawing.Point(1, 517);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(787, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tmn_Boqua
            // 
            this.tmn_Boqua.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tmn_Boqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmn_Boqua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.tmn_Boqua.Image = ((System.Drawing.Image)(resources.GetObject("tmn_Boqua.Image")));
            this.tmn_Boqua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmn_Boqua.Name = "tmn_Boqua";
            this.tmn_Boqua.Size = new System.Drawing.Size(60, 22);
            this.tmn_Boqua.Text = "&Bỏ &qua";
            this.tmn_Boqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tmn_Chon
            // 
            this.tmn_Chon.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tmn_Chon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmn_Chon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.tmn_Chon.Image = ((System.Drawing.Image)(resources.GetObject("tmn_Chon.Image")));
            this.tmn_Chon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmn_Chon.Name = "tmn_Chon";
            this.tmn_Chon.Size = new System.Drawing.Size(62, 22);
            this.tmn_Chon.Text = "&Đồn&g ý";
            this.tmn_Chon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tmn_Chonall
            // 
            this.tmn_Chonall.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tmn_Chonall.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmn_Chonall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.tmn_Chonall.Image = global::Vienphi.Properties.Resources.t_chon_5;
            this.tmn_Chonall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmn_Chonall.Name = "tmn_Chonall";
            this.tmn_Chonall.Size = new System.Drawing.Size(83, 22);
            this.tmn_Chonall.Text = "&Chọn tất cả";
            this.tmn_Chonall.Click += new System.EventHandler(this.tmn_Chonall_Click);
            // 
            // tmn_Display
            // 
            this.tmn_Display.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmn_Display.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.tmn_Display.Image = ((System.Drawing.Image)(resources.GetObject("tmn_Display.Image")));
            this.tmn_Display.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmn_Display.Name = "tmn_Display";
            this.tmn_Display.Size = new System.Drawing.Size(23, 22);
            this.tmn_Display.Text = "Hiển thị nhiều dòng";
            this.tmn_Display.Click += new System.EventHandler(this.tmn_Display_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tmn_Bochonall
            // 
            this.tmn_Bochonall.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tmn_Bochonall.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmn_Bochonall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.tmn_Bochonall.Image = ((System.Drawing.Image)(resources.GetObject("tmn_Bochonall.Image")));
            this.tmn_Bochonall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmn_Bochonall.Name = "tmn_Bochonall";
            this.tmn_Bochonall.Size = new System.Drawing.Size(96, 22);
            this.tmn_Bochonall.Text = "&Bỏ chọn tất cả";
            this.tmn_Bochonall.Click += new System.EventHandler(this.tmn_Bochonall_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tmn_Clear
            // 
            this.tmn_Clear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tmn_Clear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmn_Clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.tmn_Clear.Image = ((System.Drawing.Image)(resources.GetObject("tmn_Clear.Image")));
            this.tmn_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmn_Clear.Name = "tmn_Clear";
            this.tmn_Clear.Size = new System.Drawing.Size(100, 22);
            this.tmn_Clear.Text = "Chọ&n lại từ đầu";
            this.tmn_Clear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // txtTimnhanh
            // 
            this.txtTimnhanh.BackColor = System.Drawing.SystemColors.Info;
            this.txtTimnhanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimnhanh.Name = "txtTimnhanh";
            this.txtTimnhanh.Size = new System.Drawing.Size(100, 25);
            this.txtTimnhanh.Text = "Tìm kiếm";
            this.txtTimnhanh.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimnhanh.Leave += new System.EventHandler(this.txtTimnhanh_Leave);
            this.txtTimnhanh.TextChanged += new System.EventHandler(this.txtTimnhanh_TextChanged);
            this.txtTimnhanh.Click += new System.EventHandler(this.txtTimnhanh_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(142, 523);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 15;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.Color.MintCream;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.PathSeparator = " -> ";
            this.treeView1.Size = new System.Drawing.Size(176, 457);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // frmChonvpct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 542);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmChonvpct";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn viện phí";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChonvpct_KeyDown);
            this.Load += new System.EventHandler(this.frmChonvpct_Load);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel tmn_Title;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tmn_Chon;
        private System.Windows.Forms.ToolStripButton tmn_Clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tmn_Display;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tmn_Boqua;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tmn_Chonall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tmn_Bochonall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripTextBox tmn_Sotien;
        private System.Windows.Forms.ToolStripTextBox txtTimnhanh;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TreeView treeView1;
    }
}