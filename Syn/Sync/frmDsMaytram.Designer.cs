namespace Server
{
    partial class frmDsMaytram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDsMaytram));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.cmlHost = new System.Windows.Forms.ColumnHeader();
            this.clmPort = new System.Windows.Forms.ColumnHeader();
            this.clmUserdb = new System.Windows.Forms.ColumnHeader();
            this.clmPass = new System.Windows.Forms.ColumnHeader();
            this.clmdatabase = new System.Windows.Forms.ColumnHeader();
            this.clmServername = new System.Windows.Forms.ColumnHeader();
            this.clmthoigian = new System.Windows.Forms.ColumnHeader();
            this.clmdblink = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.clImageCDHA = new System.Windows.Forms.ColumnHeader();
            this.clHinhBN = new System.Windows.Forms.ColumnHeader();
            this.clHinhChungtu = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conXoa});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // conXoa
            // 
            this.conXoa.Name = "conXoa";
            this.conXoa.Size = new System.Drawing.Size(103, 22);
            this.conXoa.Text = "Xóa";
            this.conXoa.Click += new System.EventHandler(this.conXoa_Click);
            // 
            // cmlHost
            // 
            this.cmlHost.Text = "Host";
            this.cmlHost.Width = 91;
            // 
            // clmPort
            // 
            this.clmPort.Text = "Port";
            this.clmPort.Width = 50;
            // 
            // clmUserdb
            // 
            this.clmUserdb.Text = "User";
            this.clmUserdb.Width = 77;
            // 
            // clmPass
            // 
            this.clmPass.Text = "Password";
            this.clmPass.Width = 96;
            // 
            // clmdatabase
            // 
            this.clmdatabase.Text = "Database";
            this.clmdatabase.Width = 114;
            // 
            // clmServername
            // 
            this.clmServername.Text = "ServerName";
            this.clmServername.Width = 101;
            // 
            // clmthoigian
            // 
            this.clmthoigian.Text = "ID";
            this.clmthoigian.Width = 73;
            // 
            // clmdblink
            // 
            this.clmdblink.Text = "Dblink";
            this.clmdblink.Width = 85;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cmlHost,
            this.clmPort,
            this.clmUserdb,
            this.clmPass,
            this.clmdatabase,
            this.clmServername,
            this.clmthoigian,
            this.clmdblink,
            this.clImageCDHA,
            this.clHinhBN,
            this.clHinhChungtu});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(352, 218);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // clImageCDHA
            // 
            this.clImageCDHA.Text = "Image CDHA";
            // 
            // clHinhBN
            // 
            this.clHinhBN.Text = "Image BN";
            // 
            // clHinhChungtu
            // 
            this.clHinhChungtu.Text = "Image Chungtu";
            // 
            // frmDsMaytram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 218);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDsMaytram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách máy trạm";
            this.Load += new System.EventHandler(this.frmDsMaytram_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conXoa;
        private System.Windows.Forms.ColumnHeader cmlHost;
        private System.Windows.Forms.ColumnHeader clmPort;
        private System.Windows.Forms.ColumnHeader clmUserdb;
        private System.Windows.Forms.ColumnHeader clmPass;
        private System.Windows.Forms.ColumnHeader clmdatabase;
        private System.Windows.Forms.ColumnHeader clmServername;
        private System.Windows.Forms.ColumnHeader clmthoigian;
        private System.Windows.Forms.ColumnHeader clmdblink;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader clImageCDHA;
        private System.Windows.Forms.ColumnHeader clHinhBN;
        private System.Windows.Forms.ColumnHeader clHinhChungtu;
    }
}