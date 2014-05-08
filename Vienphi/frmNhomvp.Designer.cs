namespace Vienphi
{
    partial class frmNhomvp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhomvp));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_readonly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_matat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_viettat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ten_nhombhyt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ngayud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_blank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_idnhombhyt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_Tim = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_Title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.butNhomduoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbNhombhyt = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtViettat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSTT = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.MaskedTextBox();
            this.chkReadonly = new System.Windows.Forms.CheckBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.butMedisoftcenter = new System.Windows.Forms.ToolStripButton();
            this.butLocal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.panel2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
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
            this.Column_ma,
            this.Column_stt,
            this.Column_matat,
            this.Column_ten,
            this.Column_viettat,
            this.Column_ten_nhombhyt,
            this.Column_ngayud,
            this.Column_blank,
            this.Column_idnhombhyt});
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
            this.dataGridView1.Size = new System.Drawing.Size(488, 360);
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
            // Column_ma
            // 
            this.Column_ma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ma.DataPropertyName = "ma";
            this.Column_ma.HeaderText = "ID";
            this.Column_ma.Name = "Column_ma";
            this.Column_ma.ReadOnly = true;
            this.Column_ma.Width = 60;
            // 
            // Column_stt
            // 
            this.Column_stt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_stt.DataPropertyName = "stt";
            this.Column_stt.HeaderText = "Stt";
            this.Column_stt.Name = "Column_stt";
            this.Column_stt.ReadOnly = true;
            this.Column_stt.Width = 60;
            // 
            // Column_matat
            // 
            this.Column_matat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_matat.DataPropertyName = "matat";
            this.Column_matat.HeaderText = "Mã nhóm";
            this.Column_matat.Name = "Column_matat";
            this.Column_matat.ReadOnly = true;
            // 
            // Column_ten
            // 
            this.Column_ten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ten.DataPropertyName = "ten";
            this.Column_ten.HeaderText = "Nhóm viện phí";
            this.Column_ten.Name = "Column_ten";
            this.Column_ten.ReadOnly = true;
            this.Column_ten.Width = 250;
            // 
            // Column_viettat
            // 
            this.Column_viettat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_viettat.DataPropertyName = "viettat";
            this.Column_viettat.HeaderText = "Viết tắt";
            this.Column_viettat.Name = "Column_viettat";
            this.Column_viettat.ReadOnly = true;
            // 
            // Column_ten_nhombhyt
            // 
            this.Column_ten_nhombhyt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ten_nhombhyt.DataPropertyName = "ten_nhombhyt";
            this.Column_ten_nhombhyt.HeaderText = "Nhóm viện phí BHYT";
            this.Column_ten_nhombhyt.Name = "Column_ten_nhombhyt";
            this.Column_ten_nhombhyt.ReadOnly = true;
            this.Column_ten_nhombhyt.Width = 400;
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
            this.Column_blank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_blank.DataPropertyName = "blank";
            this.Column_blank.HeaderText = "";
            this.Column_blank.MinimumWidth = 2;
            this.Column_blank.Name = "Column_blank";
            this.Column_blank.ReadOnly = true;
            this.Column_blank.Visible = false;
            this.Column_blank.Width = 2;
            // 
            // Column_idnhombhyt
            // 
            this.Column_idnhombhyt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_idnhombhyt.DataPropertyName = "idnhombhyt";
            this.Column_idnhombhyt.HeaderText = "idnhombhyt";
            this.Column_idnhombhyt.Name = "Column_idnhombhyt";
            this.Column_idnhombhyt.ReadOnly = true;
            this.Column_idnhombhyt.Visible = false;
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
            this.toolStripSeparator4,
            this.butNhomduoc,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(2, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(488, 25);
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
            this.toolStrip_Title.Name = "toolStrip_Title";
            this.toolStrip_Title.Size = new System.Drawing.Size(166, 22);
            this.toolStrip_Title.Text = "Danh sách nhóm viện phí ";
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
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // butNhomduoc
            // 
            this.butNhomduoc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butNhomduoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butNhomduoc.Image = ((System.Drawing.Image)(resources.GetObject("butNhomduoc.Image")));
            this.butNhomduoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butNhomduoc.Name = "butNhomduoc";
            this.butNhomduoc.Size = new System.Drawing.Size(23, 22);
            this.butNhomduoc.Text = "Phân nhóm viện phí dược";
            this.butNhomduoc.Click += new System.EventHandler(this.butNhomduoc_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(283, 3);
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
            this.butXoa.Location = new System.Drawing.Point(213, 3);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 3;
            this.butXoa.Text = "      &Xoá";
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
            this.butSua.Location = new System.Drawing.Point(143, 3);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 2;
            this.butSua.Text = "      &Sửa";
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
            this.butMoi.Location = new System.Drawing.Point(3, 3);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 0;
            this.butMoi.Text = "       &Mới";
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
            this.butLuu.Location = new System.Drawing.Point(73, 3);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 1;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbNhombhyt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtMa);
            this.panel1.Controls.Add(this.txtViettat);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSTT);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.chkReadonly);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 134);
            this.panel1.TabIndex = 10;
            // 
            // cbNhombhyt
            // 
            this.cbNhombhyt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNhombhyt.BackColor = System.Drawing.Color.White;
            this.cbNhombhyt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhombhyt.ForeColor = System.Drawing.Color.Black;
            this.cbNhombhyt.FormattingEnabled = true;
            this.cbNhombhyt.Location = new System.Drawing.Point(74, 88);
            this.cbNhombhyt.Name = "cbNhombhyt";
            this.cbNhombhyt.Size = new System.Drawing.Size(276, 21);
            this.cbNhombhyt.TabIndex = 5;
            this.cbNhombhyt.SelectionChangeCommitted += new System.EventHandler(this.cbNhombhyt_SelectionChangeCommitted);
            this.cbNhombhyt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNhombhyt_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-56, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Nhóm BHYT:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMa
            // 
            this.txtMa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa.BackColor = System.Drawing.Color.White;
            this.txtMa.ForeColor = System.Drawing.Color.Black;
            this.txtMa.Location = new System.Drawing.Point(139, 25);
            this.txtMa.MaxLength = 999;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(211, 20);
            this.txtMa.TabIndex = 2;
            this.txtMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // txtViettat
            // 
            this.txtViettat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViettat.BackColor = System.Drawing.Color.White;
            this.txtViettat.ForeColor = System.Drawing.Color.Black;
            this.txtViettat.Location = new System.Drawing.Point(74, 67);
            this.txtViettat.MaxLength = 999;
            this.txtViettat.Name = "txtViettat";
            this.txtViettat.Size = new System.Drawing.Size(276, 20);
            this.txtViettat.TabIndex = 4;
            this.txtViettat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtViettat_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-56, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Viết tắt:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSTT
            // 
            this.txtSTT.BackColor = System.Drawing.Color.White;
            this.txtSTT.Location = new System.Drawing.Point(74, 25);
            this.txtSTT.Mask = "000";
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Size = new System.Drawing.Size(28, 20);
            this.txtSTT.TabIndex = 1;
            this.txtSTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSTT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSTT_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "STT:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Location = new System.Drawing.Point(74, 4);
            this.txtID.Mask = "000";
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(28, 20);
            this.txtID.TabIndex = 0;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // chkReadonly
            // 
            this.chkReadonly.AutoSize = true;
            this.chkReadonly.Location = new System.Drawing.Point(74, 111);
            this.chkReadonly.Name = "chkReadonly";
            this.chkReadonly.Size = new System.Drawing.Size(71, 17);
            this.chkReadonly.TabIndex = 6;
            this.chkReadonly.Text = "Readonly";
            this.chkReadonly.UseVisualStyleBackColor = true;
            this.chkReadonly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkReadonly_KeyDown);
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.ForeColor = System.Drawing.Color.Black;
            this.txtTen.Location = new System.Drawing.Point(74, 46);
            this.txtTen.MaxLength = 999;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(276, 20);
            this.txtTen.TabIndex = 3;
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-56, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tên nhóm:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(102, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Mã:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.toolStrip4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 190);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1);
            this.panel2.Size = new System.Drawing.Size(360, 195);
            this.panel2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.MintCream;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Location = new System.Drawing.Point(1, 23);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowLines = false;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(354, 167);
            this.treeView1.TabIndex = 13;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "MISC13.ICO");
            this.imageList1.Images.SetKeyName(1, "MISC15.ICO");
            this.imageList1.Images.SetKeyName(2, "CLOUD.ICO");
            this.imageList1.Images.SetKeyName(3, "ENTIRNET.ICO");
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip4.GripMargin = new System.Windows.Forms.Padding(1, 2, 2, 2);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip4.Location = new System.Drawing.Point(1, 1);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(354, 22);
            this.toolStrip4.TabIndex = 12;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(134, 19);
            this.toolStripLabel1.Text = "Nhóm viện phí BHYT";
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
            this.toolStrip2.Size = new System.Drawing.Size(360, 25);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(161, 22);
            this.toolStripLabel2.Text = "Thông tin nhóm viện phí ";
            // 
            // butMedisoftcenter
            // 
            this.butMedisoftcenter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butMedisoftcenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMedisoftcenter.Image = ((System.Drawing.Image)(resources.GetObject("butMedisoftcenter.Image")));
            this.butMedisoftcenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMedisoftcenter.Name = "butMedisoftcenter";
            this.butMedisoftcenter.Size = new System.Drawing.Size(23, 22);
            this.butMedisoftcenter.Text = "Cập nhật danh mục từ Medisoft Center";
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
            this.butLocal.Text = "Cập nhật danh mục mẫu thử từ File trên máy cục bộ";
            this.butLocal.Click += new System.EventHandler(this.butLocal_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.toolStrip3.Size = new System.Drawing.Size(866, 60);
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
            this.toolStripLabel3.Size = new System.Drawing.Size(288, 57);
            this.toolStripLabel3.Text = "KHAI BÁO NHÓM VIỆN PHÍ ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttStatus});
            this.statusStrip1.Location = new System.Drawing.Point(1, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 22);
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
            this.panel3.Size = new System.Drawing.Size(866, 394);
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
            this.panel5.Size = new System.Drawing.Size(495, 390);
            this.panel5.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(496, 2);
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
            this.panel4.Location = new System.Drawing.Point(498, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 0, 1, 1);
            this.panel4.Size = new System.Drawing.Size(367, 390);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.butMoi);
            this.panel6.Controls.Add(this.butBoqua);
            this.panel6.Controls.Add(this.butLuu);
            this.panel6.Controls.Add(this.butXoa);
            this.panel6.Controls.Add(this.butSua);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(2, 159);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(360, 31);
            this.panel6.TabIndex = 0;
            // 
            // frmNhomvp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 477);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhomvp";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo nhóm viện phí  ";
            this.Load += new System.EventHandler(this.frmQuanlynguoidung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton butMedisoftcenter;
        private System.Windows.Forms.ToolStripButton butLocal;
        private System.Windows.Forms.MaskedTextBox txtSTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtViettat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbNhombhyt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton butNhomduoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_readonly;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_matat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_viettat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ten_nhombhyt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ngayud;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_blank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_idnhombhyt;
    }
}