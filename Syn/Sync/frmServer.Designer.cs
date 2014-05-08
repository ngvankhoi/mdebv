namespace Server
{
    partial class frmServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.khaiBáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnumaytram = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaoTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThucthi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLaydata = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudayData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSLCuoiNgay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuKsk = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChuyendulieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDongBoKSK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuimail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDongBoHinhAnh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDongbotheongay = new System.Windows.Forms.ToolStripMenuItem();
            this.tiệnÍchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu31 = new System.Windows.Forms.ToolStripMenuItem();
            this.conXemdsmaytram = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddFieldChuyendi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuupdatecd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanlydatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ngừngĐồngBộToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chạyĐồngBộToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCauHinhEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKetthuc = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conThem = new System.Windows.Forms.ToolStripMenuItem();
            this.conXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.noticIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.syn_time = new System.Windows.Forms.Timer(this.components);
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblstatuss = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.Trangthai = new System.Windows.Forms.ToolStripStatusLabel();
            this.image_time = new System.Windows.Forms.Timer(this.components);
            this.txtText = new System.Windows.Forms.RichTextBox();
            this.proStatus = new System.Windows.Forms.ProgressBar();
            this.syn_time_full = new System.Windows.Forms.Timer(this.components);
            this.mnuChuyenlaiKQXN_Thangcu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.khaiBáoToolStripMenuItem,
            this.menuThucthi,
            this.tiệnÍchToolStripMenuItem,
            this.mnuKetthuc,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(611, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // khaiBáoToolStripMenuItem
            // 
            this.khaiBáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnumaytram,
            this.mnuThongso,
            this.mnuTaoTable});
            this.khaiBáoToolStripMenuItem.Name = "khaiBáoToolStripMenuItem";
            this.khaiBáoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.khaiBáoToolStripMenuItem.Text = "Khai báo";
            // 
            // mnumaytram
            // 
            this.mnumaytram.Name = "mnumaytram";
            this.mnumaytram.Size = new System.Drawing.Size(174, 22);
            this.mnumaytram.Text = "Khai báo máy trạm";
            this.mnumaytram.Click += new System.EventHandler(this.mnumaytram_Click);
            // 
            // mnuThongso
            // 
            this.mnuThongso.Name = "mnuThongso";
            this.mnuThongso.Size = new System.Drawing.Size(174, 22);
            this.mnuThongso.Text = "Khai báo thông số";
            this.mnuThongso.Click += new System.EventHandler(this.mnuThongso_Click);
            // 
            // mnuTaoTable
            // 
            this.mnuTaoTable.Name = "mnuTaoTable";
            this.mnuTaoTable.Size = new System.Drawing.Size(174, 22);
            this.mnuTaoTable.Text = "Tạo Table";
            this.mnuTaoTable.Visible = false;
            this.mnuTaoTable.Click += new System.EventHandler(this.mnuTaoTable_Click);
            // 
            // menuThucthi
            // 
            this.menuThucthi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLaydata,
            this.mnudayData,
            this.mnuUpdate,
            this.mnuSLCuoiNgay,
            this.toolStripMenuItem1,
            this.mnuKsk,
            this.mnuChuyendulieu,
            this.mnuDongBoKSK,
            this.mnuGuimail,
            this.mnuDongBoHinhAnh,
            this.mnuDongbotheongay,
            this.mnuChuyenlaiKQXN_Thangcu});
            this.menuThucthi.Name = "menuThucthi";
            this.menuThucthi.Size = new System.Drawing.Size(58, 20);
            this.menuThucthi.Text = "Thực thi";
            // 
            // mnuLaydata
            // 
            this.mnuLaydata.Name = "mnuLaydata";
            this.mnuLaydata.Size = new System.Drawing.Size(245, 22);
            this.mnuLaydata.Text = "Lấy số liệu về máy trung tâm";
            this.mnuLaydata.Visible = false;
            this.mnuLaydata.Click += new System.EventHandler(this.mnuLaydata_Click);
            // 
            // mnudayData
            // 
            this.mnudayData.Name = "mnudayData";
            this.mnudayData.Size = new System.Drawing.Size(245, 22);
            this.mnudayData.Text = "Đẩy số liệu xuống máy trạm";
            this.mnudayData.Visible = false;
            this.mnudayData.Click += new System.EventHandler(this.mnudayData_Click);
            // 
            // mnuUpdate
            // 
            this.mnuUpdate.Image = global::Server.Properties.Resources.synchro;
            this.mnuUpdate.Name = "mnuUpdate";
            this.mnuUpdate.Size = new System.Drawing.Size(245, 22);
            this.mnuUpdate.Text = "Đồng bộ ";
            this.mnuUpdate.Click += new System.EventHandler(this.mnuUpdate_Click);
            // 
            // mnuSLCuoiNgay
            // 
            this.mnuSLCuoiNgay.Image = global::Server.Properties.Resources.Synchronize;
            this.mnuSLCuoiNgay.Name = "mnuSLCuoiNgay";
            this.mnuSLCuoiNgay.Size = new System.Drawing.Size(245, 22);
            this.mnuSLCuoiNgay.Text = "Đồng bộ cuối ngày";
            this.mnuSLCuoiNgay.Click += new System.EventHandler(this.mnuSLCuoiNgay_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
            // 
            // mnuKsk
            // 
            this.mnuKsk.Name = "mnuKsk";
            this.mnuKsk.Size = new System.Drawing.Size(245, 22);
            this.mnuKsk.Text = "Đồng bộ khám sức khoẻ";
            this.mnuKsk.Visible = false;
            this.mnuKsk.Click += new System.EventHandler(this.đồngBộKSToolStripMenuItem_Click);
            // 
            // mnuChuyendulieu
            // 
            this.mnuChuyendulieu.Name = "mnuChuyendulieu";
            this.mnuChuyendulieu.Size = new System.Drawing.Size(245, 22);
            this.mnuChuyendulieu.Text = "Chuyển dữ liệu";
            this.mnuChuyendulieu.Visible = false;
            this.mnuChuyendulieu.Click += new System.EventHandler(this.mnuChuyendulieu_Click);
            // 
            // mnuDongBoKSK
            // 
            this.mnuDongBoKSK.Name = "mnuDongBoKSK";
            this.mnuDongBoKSK.Size = new System.Drawing.Size(245, 22);
            this.mnuDongBoKSK.Text = "Đồng bộ Khám sức khỏe 1";
            this.mnuDongBoKSK.Visible = false;
            this.mnuDongBoKSK.Click += new System.EventHandler(this.mnuDongBoKSK_Click);
            // 
            // mnuGuimail
            // 
            this.mnuGuimail.Name = "mnuGuimail";
            this.mnuGuimail.Size = new System.Drawing.Size(245, 22);
            this.mnuGuimail.Text = "Gửi mail nhắc Bệnh nhân tái khám";
            this.mnuGuimail.Click += new System.EventHandler(this.mnuGuimail_Click);
            // 
            // mnuDongBoHinhAnh
            // 
            this.mnuDongBoHinhAnh.Name = "mnuDongBoHinhAnh";
            this.mnuDongBoHinhAnh.Size = new System.Drawing.Size(245, 22);
            this.mnuDongBoHinhAnh.Text = "Đồng bộ hình ảnh";
            this.mnuDongBoHinhAnh.Visible = false;
            this.mnuDongBoHinhAnh.Click += new System.EventHandler(this.mnuDongBoHinhAnh_Click);
            // 
            // mnuDongbotheongay
            // 
            this.mnuDongbotheongay.Name = "mnuDongbotheongay";
            this.mnuDongbotheongay.Size = new System.Drawing.Size(245, 22);
            this.mnuDongbotheongay.Text = "Đồng bộ theo ngày";
            this.mnuDongbotheongay.Click += new System.EventHandler(this.mnuDongbotheongay_Click);
            // 
            // tiệnÍchToolStripMenuItem
            // 
            this.tiệnÍchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu31,
            this.conXemdsmaytram,
            this.mnuAddFieldChuyendi,
            this.mnuupdatecd,
            this.mnuQuanlydatabase,
            this.mnuEvent,
            this.mnuExportColumn,
            this.copyPictureToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.ngừngĐồngBộToolStripMenuItem,
            this.chạyĐồngBộToolStripMenuItem,
            this.mnuCauHinhEmail});
            this.tiệnÍchToolStripMenuItem.Name = "tiệnÍchToolStripMenuItem";
            this.tiệnÍchToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.tiệnÍchToolStripMenuItem.Text = "Tiện ích";
            // 
            // mnu31
            // 
            this.mnu31.Name = "mnu31";
            this.mnu31.Size = new System.Drawing.Size(260, 22);
            this.mnu31.Text = "Danh mục table được đồng bộ tables";
            this.mnu31.Click += new System.EventHandler(this.mnu31_Click);
            // 
            // conXemdsmaytram
            // 
            this.conXemdsmaytram.Name = "conXemdsmaytram";
            this.conXemdsmaytram.Size = new System.Drawing.Size(260, 22);
            this.conXemdsmaytram.Text = "Xem danh sách máy trạm";
            this.conXemdsmaytram.Click += new System.EventHandler(this.conXemdsmaytram_Click);
            // 
            // mnuAddFieldChuyendi
            // 
            this.mnuAddFieldChuyendi.Name = "mnuAddFieldChuyendi";
            this.mnuAddFieldChuyendi.Size = new System.Drawing.Size(260, 22);
            this.mnuAddFieldChuyendi.Text = "Thêm field Chuyển đi";
            this.mnuAddFieldChuyendi.Click += new System.EventHandler(this.mnuAddFieldChuyendi_Click);
            // 
            // mnuupdatecd
            // 
            this.mnuupdatecd.Name = "mnuupdatecd";
            this.mnuupdatecd.Size = new System.Drawing.Size(260, 22);
            this.mnuupdatecd.Text = "Chuyển field chuyển đi về 1";
            this.mnuupdatecd.Visible = false;
            this.mnuupdatecd.Click += new System.EventHandler(this.mnuupdatecd_Click);
            // 
            // mnuQuanlydatabase
            // 
            this.mnuQuanlydatabase.Name = "mnuQuanlydatabase";
            this.mnuQuanlydatabase.Size = new System.Drawing.Size(260, 22);
            this.mnuQuanlydatabase.Text = "Quản lý database";
            this.mnuQuanlydatabase.Visible = false;
            this.mnuQuanlydatabase.Click += new System.EventHandler(this.mnuModifyField_Click);
            // 
            // mnuEvent
            // 
            this.mnuEvent.Name = "mnuEvent";
            this.mnuEvent.Size = new System.Drawing.Size(260, 22);
            this.mnuEvent.Text = "Xem sự kiện cập nhật";
            this.mnuEvent.Click += new System.EventHandler(this.mnuEvent_Click);
            // 
            // mnuExportColumn
            // 
            this.mnuExportColumn.Name = "mnuExportColumn";
            this.mnuExportColumn.Size = new System.Drawing.Size(260, 22);
            this.mnuExportColumn.Text = "Xuất columns ";
            this.mnuExportColumn.Visible = false;
            this.mnuExportColumn.Click += new System.EventHandler(this.mnuExportColumn_Click);
            // 
            // copyPictureToolStripMenuItem
            // 
            this.copyPictureToolStripMenuItem.Name = "copyPictureToolStripMenuItem";
            this.copyPictureToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.copyPictureToolStripMenuItem.Text = "Copy hình Bệnh nhân";
            this.copyPictureToolStripMenuItem.Click += new System.EventHandler(this.copyPictureToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItem2.Text = "Copy Hình kết quả CĐHA";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItem3.Text = "Copy Hình chứng từ";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // ngừngĐồngBộToolStripMenuItem
            // 
            this.ngừngĐồngBộToolStripMenuItem.Name = "ngừngĐồngBộToolStripMenuItem";
            this.ngừngĐồngBộToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.ngừngĐồngBộToolStripMenuItem.Text = "Ngừng đồng bộ";
            this.ngừngĐồngBộToolStripMenuItem.Visible = false;
            this.ngừngĐồngBộToolStripMenuItem.Click += new System.EventHandler(this.ngừngĐồngBộToolStripMenuItem_Click);
            // 
            // chạyĐồngBộToolStripMenuItem
            // 
            this.chạyĐồngBộToolStripMenuItem.Name = "chạyĐồngBộToolStripMenuItem";
            this.chạyĐồngBộToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.chạyĐồngBộToolStripMenuItem.Text = "Chạy đồng bộ";
            this.chạyĐồngBộToolStripMenuItem.Visible = false;
            this.chạyĐồngBộToolStripMenuItem.Click += new System.EventHandler(this.chạyĐồngBộToolStripMenuItem_Click);
            // 
            // mnuCauHinhEmail
            // 
            this.mnuCauHinhEmail.Name = "mnuCauHinhEmail";
            this.mnuCauHinhEmail.Size = new System.Drawing.Size(260, 22);
            this.mnuCauHinhEmail.Text = "Cấu hình Email";
            this.mnuCauHinhEmail.Click += new System.EventHandler(this.mnuCauHinhEmail_Click);
            // 
            // mnuKetthuc
            // 
            this.mnuKetthuc.Name = "mnuKetthuc";
            this.mnuKetthuc.Size = new System.Drawing.Size(59, 20);
            this.mnuKetthuc.Text = "Kết thúc";
            this.mnuKetthuc.Click += new System.EventHandler(this.mnuKetthuc_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửDụngToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // sửDụngToolStripMenuItem
            // 
            this.sửDụngToolStripMenuItem.Name = "sửDụngToolStripMenuItem";
            this.sửDụngToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.sửDụngToolStripMenuItem.Text = "Sử dụng";
            this.sửDụngToolStripMenuItem.Click += new System.EventHandler(this.sửDụngToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conThem,
            this.conXoa});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 48);
            // 
            // conThem
            // 
            this.conThem.Name = "conThem";
            this.conThem.Size = new System.Drawing.Size(174, 22);
            this.conThem.Text = "Khai báo máy trạm";
            this.conThem.Click += new System.EventHandler(this.conThem_Click);
            // 
            // conXoa
            // 
            this.conXoa.Name = "conXoa";
            this.conXoa.Size = new System.Drawing.Size(174, 22);
            this.conXoa.Text = "Xóa";
            this.conXoa.Click += new System.EventHandler(this.conXoa_Click);
            // 
            // noticIcon
            // 
            this.noticIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.noticIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("noticIcon.Icon")));
            this.noticIcon.Text = "Máy server trung tâm";
            this.noticIcon.Visible = true;
            this.noticIcon.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // syn_time
            // 
            this.syn_time.Enabled = true;
            this.syn_time.Interval = 36000;
            this.syn_time.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatuss,
            this.statusServer,
            this.Trangthai});
            this.status.Location = new System.Drawing.Point(0, 388);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(611, 22);
            this.status.TabIndex = 20;
            this.status.Text = "statusStrip1";
            // 
            // lblstatuss
            // 
            this.lblstatuss.BackColor = System.Drawing.Color.Transparent;
            this.lblstatuss.Name = "lblstatuss";
            this.lblstatuss.Size = new System.Drawing.Size(35, 17);
            this.lblstatuss.Text = "ready";
            // 
            // statusServer
            // 
            this.statusServer.AutoSize = false;
            this.statusServer.BackColor = System.Drawing.SystemColors.Control;
            this.statusServer.Name = "statusServer";
            this.statusServer.Size = new System.Drawing.Size(150, 17);
            this.statusServer.Text = "Local";
            // 
            // Trangthai
            // 
            this.Trangthai.AutoSize = false;
            this.Trangthai.BackColor = System.Drawing.SystemColors.Control;
            this.Trangthai.Name = "Trangthai";
            this.Trangthai.Size = new System.Drawing.Size(250, 17);
            // 
            // image_time
            // 
            this.image_time.Enabled = true;
            this.image_time.Interval = 1000;
            this.image_time.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // txtText
            // 
            this.txtText.BackColor = System.Drawing.Color.White;
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Location = new System.Drawing.Point(0, 24);
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(611, 341);
            this.txtText.TabIndex = 22;
            this.txtText.Text = "";
            this.txtText.Visible = false;
            // 
            // proStatus
            // 
            this.proStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.proStatus.Location = new System.Drawing.Point(0, 365);
            this.proStatus.Name = "proStatus";
            this.proStatus.Size = new System.Drawing.Size(611, 23);
            this.proStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.proStatus.TabIndex = 24;
            this.proStatus.Visible = false;
            // 
            // syn_time_full
            // 
            this.syn_time_full.Enabled = true;
            this.syn_time_full.Interval = 36000;
            // 
            // mnuChuyenlaiKQXN_Thangcu
            // 
            this.mnuChuyenlaiKQXN_Thangcu.Name = "mnuChuyenlaiKQXN_Thangcu";
            this.mnuChuyenlaiKQXN_Thangcu.Size = new System.Drawing.Size(245, 22);
            this.mnuChuyenlaiKQXN_Thangcu.Text = "Chuyển lại KQ XN tháng cũ";
            this.mnuChuyenlaiKQXN_Thangcu.Click += new System.EventHandler(this.mnuChuyenlaiKQXN_Thangcu_Click);
            // 
            // frmServer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Server.Properties.Resources.abstract_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(611, 410);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.proStatus);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Resize += new System.EventHandler(this.Server_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem khaiBáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnumaytram;
        private System.Windows.Forms.ToolStripMenuItem mnuThongso;
        private System.Windows.Forms.ToolStripMenuItem mnuTaoTable;
        private System.Windows.Forms.ToolStripMenuItem menuThucthi;
        private System.Windows.Forms.ToolStripMenuItem mnuLaydata;
        private System.Windows.Forms.ToolStripMenuItem mnudayData;
        private System.Windows.Forms.ToolStripMenuItem tiệnÍchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuupdatecd;
        private System.Windows.Forms.ToolStripMenuItem mnuKetthuc;
        private System.Windows.Forms.NotifyIcon noticIcon;
        private System.Windows.Forms.Timer syn_time;
        private System.Windows.Forms.ToolStripMenuItem mnuSLCuoiNgay;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanlydatabase;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conThem;
        private System.Windows.Forms.ToolStripMenuItem conXoa;
        private System.Windows.Forms.ToolStripMenuItem mnuEvent;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem conXemdsmaytram;
        private System.Windows.Forms.ToolStripStatusLabel lblstatuss;
        private System.Windows.Forms.Timer image_time;
        private System.Windows.Forms.ToolStripMenuItem mnuExportColumn;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ngừngĐồngBộToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chạyĐồngBộToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu31;
        public System.Windows.Forms.RichTextBox txtText;
        private System.Windows.Forms.ToolStripStatusLabel statusServer;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel Trangthai;
        public System.Windows.Forms.ProgressBar proStatus;
        private System.Windows.Forms.Timer syn_time_full;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuKsk;
        private System.Windows.Forms.ToolStripMenuItem mnuDongBoKSK;
        private System.Windows.Forms.ToolStripMenuItem mnuAddFieldChuyendi;
        private System.Windows.Forms.ToolStripMenuItem mnuChuyendulieu;
        private System.Windows.Forms.ToolStripMenuItem mnuCauHinhEmail;
        private System.Windows.Forms.ToolStripMenuItem mnuGuimail;
        private System.Windows.Forms.ToolStripMenuItem mnuDongBoHinhAnh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuDongbotheongay;
        private System.Windows.Forms.ToolStripMenuItem mnuChuyenlaiKQXN_Thangcu;
    }
}

