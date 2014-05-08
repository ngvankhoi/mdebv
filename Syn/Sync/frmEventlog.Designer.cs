namespace Server
{
    partial class frmEventlog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventlog));
            this.listView1 = new System.Windows.Forms.ListView();
            this.clmImage = new System.Windows.Forms.ColumnHeader();
            this.clmNgay = new System.Windows.Forms.ColumnHeader();
            this.clmThoigian = new System.Windows.Forms.ColumnHeader();
            this.clmEvent = new System.Windows.Forms.ColumnHeader();
            this.clmSchema = new System.Windows.Forms.ColumnHeader();
            this.clmtable = new System.Windows.Forms.ColumnHeader();
            this.clmTen = new System.Windows.Forms.ColumnHeader();
            this.clmsrvSend = new System.Windows.Forms.ColumnHeader();
            this.clmsrvReceive = new System.Windows.Forms.ColumnHeader();
            this.clmComputer = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conrefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView2 = new System.Windows.Forms.ListView();
            this.clm = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmImage,
            this.clmNgay,
            this.clmThoigian,
            this.clmEvent,
            this.clmSchema,
            this.clmtable,
            this.clmTen,
            this.clmsrvSend,
            this.clmsrvReceive,
            this.clmComputer});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1020, 505);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // clmImage
            // 
            this.clmImage.Text = "Status";
            this.clmImage.Width = 50;
            // 
            // clmNgay
            // 
            this.clmNgay.Text = "Ngày";
            this.clmNgay.Width = 76;
            // 
            // clmThoigian
            // 
            this.clmThoigian.Text = "Thời gian";
            this.clmThoigian.Width = 69;
            // 
            // clmEvent
            // 
            this.clmEvent.Text = "Sự kiện";
            this.clmEvent.Width = 102;
            // 
            // clmSchema
            // 
            this.clmSchema.Text = "Schema";
            // 
            // clmtable
            // 
            this.clmtable.Text = "Table";
            // 
            // clmTen
            // 
            this.clmTen.Text = "Tên";
            // 
            // clmsrvSend
            // 
            this.clmsrvSend.Text = "Tên máy gửi";
            this.clmsrvSend.Width = 116;
            // 
            // clmsrvReceive
            // 
            this.clmsrvReceive.Text = "Tên máy nhận";
            this.clmsrvReceive.Width = 115;
            // 
            // clmComputer
            // 
            this.clmComputer.Text = "Máy tính";
            this.clmComputer.Width = 78;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "error.ico");
            this.imageList1.Images.SetKeyName(1, "Warning.ico");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conrefresh,
            this.xóaTấtCảToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 48);
            // 
            // conrefresh
            // 
            this.conrefresh.Name = "conrefresh";
            this.conrefresh.Size = new System.Drawing.Size(134, 22);
            this.conrefresh.Text = "Làm tươi";
            this.conrefresh.Click += new System.EventHandler(this.conrefresh_Click_1);
            // 
            // xóaTấtCảToolStripMenuItem
            // 
            this.xóaTấtCảToolStripMenuItem.Name = "xóaTấtCảToolStripMenuItem";
            this.xóaTấtCảToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.xóaTấtCảToolStripMenuItem.Text = "Xóa tất cả";
            this.xóaTấtCảToolStripMenuItem.Click += new System.EventHandler(this.xóaTấtCảToolStripMenuItem_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(336, 195);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // clm
            // 
            this.clm.Text = "Trạng thái";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ngày";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Giờ";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sự kiện";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Schema";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Table";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tên";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên máy gửi";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tên máy nhận";
            this.columnHeader9.Width = 93;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tên máy";
            this.columnHeader10.Width = 110;
            // 
            // frmEventlog
            // 
            this.ClientSize = new System.Drawing.Size(336, 195);
            this.Controls.Add(this.listView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEventlog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sự kiện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEventlog_Load_1);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader clmImage;
        private System.Windows.Forms.ColumnHeader clmNgay;
        private System.Windows.Forms.ColumnHeader clmEvent;
        private System.Windows.Forms.ColumnHeader clmTen;
        private System.Windows.Forms.ColumnHeader clmsrvSend;
        private System.Windows.Forms.ColumnHeader clmsrvReceive;
        private System.Windows.Forms.ColumnHeader clmComputer;
        private System.Windows.Forms.ColumnHeader clmThoigian;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conrefresh;
        private System.Windows.Forms.ColumnHeader clmSchema;
        private System.Windows.Forms.ColumnHeader clmtable;
        private System.Windows.Forms.ToolStripMenuItem xóaTấtCảToolStripMenuItem;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader clm;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}