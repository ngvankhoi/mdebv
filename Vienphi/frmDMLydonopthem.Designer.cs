namespace Vienphi
{
    partial class frmDMLydonopthem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMLydonopthem));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_readonly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ngayud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_blank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_Tim = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_Title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.MaskedTextBox();
            this.chkReadonly = new System.Windows.Forms.CheckBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.butMedisoftcenter = new System.Windows.Forms.ToolStripButton();
            this.butLocal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_readonly,
            this.Column_ID,
            this.Column_hoten,
            this.Column_ngayud,
            this.Column_blank});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(2, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(470, 360);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // Column_readonly
            // 
            this.Column_readonly.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_readonly.DataPropertyName = "readonly";
            this.Column_readonly.FalseValue = "0";
            this.Column_readonly.Frozen = true;
            this.Column_readonly.HeaderText = "R";
            this.Column_readonly.IndeterminateValue = "0";
            this.Column_readonly.Name = "Column_readonly";
            this.Column_readonly.ReadOnly = true;
            this.Column_readonly.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_readonly.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_readonly.ToolTipText = "R: Chỉ xem, không cho phép sửa, xoá";
            this.Column_readonly.TrueValue = "1";
            this.Column_readonly.Width = 25;
            // 
            // Column_ID
            // 
            this.Column_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ID.DataPropertyName = "ID";
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 30;
            // 
            // Column_hoten
            // 
            this.Column_hoten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_hoten.DataPropertyName = "ten";
            this.Column_hoten.HeaderText = "Lý do";
            this.Column_hoten.Name = "Column_hoten";
            this.Column_hoten.ReadOnly = true;
            // 
            // Column_ngayud
            // 
            this.Column_ngayud.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ngayud.DataPropertyName = "ngayud";
            this.Column_ngayud.HeaderText = "Ngày cập nhật";
            this.Column_ngayud.Name = "Column_ngayud";
            this.Column_ngayud.ReadOnly = true;
            // 
            // Column_blank
            // 
            this.Column_blank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_blank.DataPropertyName = "blank";
            this.Column_blank.HeaderText = "";
            this.Column_blank.Name = "Column_blank";
            this.Column_blank.ReadOnly = true;
            this.Column_blank.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(1, 2, 2, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_Refresh,
            this.toolStripSeparator1,
            this.toolStrip_Tim,
            this.toolStrip_Title,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(2, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(470, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip_Refresh
            // 
            this.toolStrip_Refresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStrip_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_Refresh.Image")));
            this.toolStrip_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_Refresh.Name = "toolStrip_Refresh";
            this.toolStrip_Refresh.Size = new System.Drawing.Size(23, 22);
            this.toolStrip_Refresh.Text = "Nạp lại danh sách";
            this.toolStrip_Refresh.ToolTipText = "Nạp lại danh sách người sử dụng";
            this.toolStrip_Refresh.Click += new System.EventHandler(this.toolStrip_Refresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip_Tim
            // 
            this.toolStrip_Tim.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_Tim.BackColor = System.Drawing.Color.White;
            this.toolStrip_Tim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_Tim.Font = new System.Drawing.Font("Tahoma", 7F);
            this.toolStrip_Tim.Name = "toolStrip_Tim";
            this.toolStrip_Tim.Size = new System.Drawing.Size(100, 25);
            this.toolStrip_Tim.ToolTipText = "Nhập nội dung cần tìm trên lưới vào đây";
            this.toolStrip_Tim.TextChanged += new System.EventHandler(this.toolStrip_Tim_TextChanged);
            // 
            // toolStrip_Title
            // 
            this.toolStrip_Title.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStrip_Title.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStrip_Title.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_Title.Image")));
            this.toolStrip_Title.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStrip_Title.Name = "toolStrip_Title";
            this.toolStrip_Title.Size = new System.Drawing.Size(168, 22);
            this.toolStrip_Title.Text = "Danh sách lý do nộp thêm";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(282, 3);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "      &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.BackColor = System.Drawing.SystemColors.Control;
            this.butXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(212, 3);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 3;
            this.butXoa.Text = "        &Xoá";
            this.butXoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butSua
            // 
            this.butSua.BackColor = System.Drawing.SystemColors.Control;
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(142, 3);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 2;
            this.butSua.Text = "        &Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.BackColor = System.Drawing.SystemColors.Control;
            this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(2, 3);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 0;
            this.butMoi.Text = "         &Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.UseVisualStyleBackColor = true;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(72, 3);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 1;
            this.butLuu.Text = "        &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.chkReadonly);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 86);
            this.panel1.TabIndex = 10;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(64, 12);
            this.txtID.Mask = "00";
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(24, 20);
            this.txtID.TabIndex = 0;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // chkReadonly
            // 
            this.chkReadonly.AutoSize = true;
            this.chkReadonly.Location = new System.Drawing.Point(64, 57);
            this.chkReadonly.Name = "chkReadonly";
            this.chkReadonly.Size = new System.Drawing.Size(71, 17);
            this.chkReadonly.TabIndex = 3;
            this.chkReadonly.Text = "Readonly";
            this.chkReadonly.UseVisualStyleBackColor = true;
            this.chkReadonly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkReadonly_KeyDown);
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.ForeColor = System.Drawing.Color.Black;
            this.txtTen.Location = new System.Drawing.Point(64, 34);
            this.txtTen.MaxLength = 999;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(205, 20);
            this.txtTen.TabIndex = 1;
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-66, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Nội dung:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(22, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 245);
            this.panel2.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(1, 2, 2, 2);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.butMedisoftcenter,
            this.butLocal,
            this.toolStripSeparator2});
            this.toolStrip2.Location = new System.Drawing.Point(2, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(352, 25);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(163, 22);
            this.toolStripLabel2.Text = "Thông tin lý do nộp thêm";
            // 
            // butMedisoftcenter
            // 
            this.butMedisoftcenter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butMedisoftcenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMedisoftcenter.Image = ((System.Drawing.Image)(resources.GetObject("butMedisoftcenter.Image")));
            this.butMedisoftcenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMedisoftcenter.Name = "butMedisoftcenter";
            this.butMedisoftcenter.Size = new System.Drawing.Size(23, 22);
            this.butMedisoftcenter.Text = "Cập nhật danh từ Medisoft Center";
            this.butMedisoftcenter.Click += new System.EventHandler(this.butMedisoftcenter_Click);
            // 
            // butLocal
            // 
            this.butLocal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butLocal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butLocal.Image = ((System.Drawing.Image)(resources.GetObject("butLocal.Image")));
            this.butLocal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butLocal.Name = "butLocal";
            this.butLocal.Size = new System.Drawing.Size(23, 22);
            this.butLocal.Text = "Cập nhật danh từ File";
            this.butLocal.Click += new System.EventHandler(this.butLocal_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.toolStripButton5,
            this.toolStripButton1,
            this.toolStripLabel3});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(1, 1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(840, 60);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 57);
            this.toolStripButton5.Text = "Hướng dẫn";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 57);
            this.toolStripButton1.Text = " Kết thúc";
            this.toolStripButton1.Click += new System.EventHandler(this.butClose_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(290, 57);
            this.toolStripLabel3.Text = "KHAI BÁO LÝ DO NỘP THÊM";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttStatus});
            this.statusStrip1.Location = new System.Drawing.Point(1, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(840, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttStatus
            // 
            this.ttStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.ttStatus.Image = ((System.Drawing.Image)(resources.GetObject("ttStatus.Image")));
            this.ttStatus.Name = "ttStatus";
            this.ttStatus.Size = new System.Drawing.Size(62, 17);
            this.ttStatus.Text = "ttStatus";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 61);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel3.Size = new System.Drawing.Size(840, 394);
            this.panel3.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.toolStrip1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 2);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2, 0, 1, 1);
            this.panel5.Size = new System.Drawing.Size(477, 390);
            this.panel5.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(478, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 390);
            this.label2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.toolStrip2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(480, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 0, 1, 1);
            this.panel4.Size = new System.Drawing.Size(359, 390);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.butBoqua);
            this.panel6.Controls.Add(this.butLuu);
            this.panel6.Controls.Add(this.butXoa);
            this.panel6.Controls.Add(this.butMoi);
            this.panel6.Controls.Add(this.butSua);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(2, 111);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(352, 29);
            this.panel6.TabIndex = 0;
            // 
            // frmDMLydonopthem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 477);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMLydonopthem";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo lý do nộp thêm ";
            this.Load += new System.EventHandler(this.frmQuanlynguoidung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStrip_Refresh;
        private System.Windows.Forms.ToolStripLabel toolStrip_Title;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butMoi;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkReadonly;
        private System.Windows.Forms.ToolStripTextBox toolStrip_Tim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStripStatusLabel ttStatus;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.MaskedTextBox txtID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_readonly;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ngayud;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_blank;
        private System.Windows.Forms.ToolStripButton butMedisoftcenter;
        private System.Windows.Forms.ToolStripButton butLocal;
    }
}