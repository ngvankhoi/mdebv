namespace Medisoft
{
    partial class frmPhieuksk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuksk));
            this.label1 = new System.Windows.Forms.Label();
            this.donvi = new System.Windows.Forms.ComboBox();
            this.list = new AsYetUnnamed.MultiColumnListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.loai = new System.Windows.Forms.ComboBox();
            this.ketluan = new System.Windows.Forms.TextBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.listBS = new LibList.List();
            this.chkThem = new System.Windows.Forms.CheckBox();
            this.listMabn = new LibList.List();
            this.tim = new System.Windows.Forms.TextBox();
            this.butThem = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butPs = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkAlldv = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đơn vị :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // donvi
            // 
            this.donvi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.donvi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.donvi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donvi.FormattingEnabled = true;
            this.donvi.Location = new System.Drawing.Point(52, 3);
            this.donvi.Name = "donvi";
            this.donvi.Size = new System.Drawing.Size(153, 21);
            this.donvi.TabIndex = 1;
            this.donvi.SelectedIndexChanged += new System.EventHandler(this.donvi_SelectedIndexChanged);
            this.donvi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(245)))));
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(4, 25);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(202, 407);
            this.list.TabIndex = 2;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã số :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Họ tên :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Năm sinh :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(672, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Giới tính :";
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(252, 3);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(69, 21);
            this.mabn.TabIndex = 3;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(366, 3);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(216, 21);
            this.hoten.TabIndex = 4;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(637, 3);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 5;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            this.namsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.namsinh_KeyDown);
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.FormattingEnabled = true;
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(724, 3);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(63, 21);
            this.phai.TabIndex = 6;
            this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
            this.phai.Validated += new System.EventHandler(this.phai_Validated);
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid1.CaptionText = "Các mục thực hiện";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(209, 26);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(578, 343);
            this.dataGrid1.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(204, 396);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 248;
            this.label6.Text = "Kết luận :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(211, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 249;
            this.label7.Text = "Bác sĩ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(571, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 250;
            this.label8.Text = "Phân loại :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(325, 372);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(240, 21);
            this.tenbs.TabIndex = 8;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(284, 372);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 7;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Enabled = false;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.FormattingEnabled = true;
            this.loai.Location = new System.Drawing.Point(652, 372);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(135, 21);
            this.loai.TabIndex = 9;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // ketluan
            // 
            this.ketluan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.ketluan.Enabled = false;
            this.ketluan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketluan.Location = new System.Drawing.Point(284, 395);
            this.ketluan.Multiline = true;
            this.ketluan.Name = "ketluan";
            this.ketluan.Size = new System.Drawing.Size(503, 83);
            this.ketluan.TabIndex = 10;
            this.ketluan.TextChanged += new System.EventHandler(this.ketluan_TextChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(696, 498);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(92, 25);
            this.butKetthuc.TabIndex = 17;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(168, 498);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(88, 25);
            this.butMoi.TabIndex = 13;
            this.butMoi.Text = "&Mới";
            this.butMoi.UseVisualStyleBackColor = true;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(256, 498);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(88, 25);
            this.butSua.TabIndex = 14;
            this.butSua.Text = "&Sửa";
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(344, 498);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(88, 25);
            this.butLuu.TabIndex = 11;
            this.butLuu.Text = "&Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(432, 498);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(88, 25);
            this.butBoqua.TabIndex = 12;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(520, 498);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(88, 25);
            this.butHuy.TabIndex = 15;
            this.butHuy.Text = "&Hủy";
            this.butHuy.UseVisualStyleBackColor = true;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(608, 498);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(88, 25);
            this.butIn.TabIndex = 16;
            this.butIn.Text = "&In";
            this.butIn.UseVisualStyleBackColor = true;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(221, 529);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 273;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // chkThem
            // 
            this.chkThem.AutoSize = true;
            this.chkThem.Location = new System.Drawing.Point(652, 480);
            this.chkThem.Name = "chkThem";
            this.chkThem.Size = new System.Drawing.Size(135, 17);
            this.chkThem.TabIndex = 274;
            this.chkThem.Text = "Thêm ngoài danh sách";
            this.chkThem.UseVisualStyleBackColor = true;
            // 
            // listMabn
            // 
            this.listMabn.BackColor = System.Drawing.SystemColors.Info;
            this.listMabn.ColumnCount = 0;
            this.listMabn.Location = new System.Drawing.Point(140, 529);
            this.listMabn.MatchBufferTimeOut = 1000;
            this.listMabn.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listMabn.Name = "listMabn";
            this.listMabn.Size = new System.Drawing.Size(75, 17);
            this.listMabn.TabIndex = 275;
            this.listMabn.TextIndex = -1;
            this.listMabn.TextMember = null;
            this.listMabn.ValueIndex = -1;
            this.listMabn.Visible = false;
            this.listMabn.Validated += new System.EventHandler(this.mabn_Validated);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(4, 466);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(202, 21);
            this.tim.TabIndex = 19;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Location = new System.Drawing.Point(746, 26);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(42, 21);
            this.butThem.TabIndex = 276;
            this.butThem.Text = "&Thêm";
            this.toolTip1.SetToolTip(this.butThem, "Làm thêm bệnh nhân tự thanh toán");
            this.butThem.UseVisualStyleBackColor = true;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butEdit
            // 
            this.butEdit.Enabled = false;
            this.butEdit.Location = new System.Drawing.Point(658, 26);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(42, 21);
            this.butEdit.TabIndex = 277;
            this.butEdit.Text = "Sửa";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.Location = new System.Drawing.Point(702, 26);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(42, 21);
            this.butXoa.TabIndex = 278;
            this.butXoa.Text = "&Xoá";
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butPs
            // 
            this.butPs.Enabled = false;
            this.butPs.Location = new System.Drawing.Point(597, 26);
            this.butPs.Name = "butPs";
            this.butPs.Size = new System.Drawing.Size(59, 21);
            this.butPs.TabIndex = 279;
            this.butPs.Text = "&Phát sinh";
            this.toolTip1.SetToolTip(this.butPs, "Phát sinh theo chỉ định cơ quan thanh toán");
            this.butPs.UseVisualStyleBackColor = true;
            this.butPs.Click += new System.EventHandler(this.butPs_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Red;
            this.lbl1.Location = new System.Drawing.Point(7, 435);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(14, 13);
            this.lbl1.TabIndex = 280;
            this.lbl1.Text = "1";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl2.Location = new System.Drawing.Point(7, 450);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(14, 13);
            this.lbl2.TabIndex = 281;
            this.lbl2.Text = "2";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(4, 503);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(159, 17);
            this.chkAll.TabIndex = 282;
            this.chkAll.Text = "In tất cả kết quả trong đoàn";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkAlldv
            // 
            this.chkAlldv.AutoSize = true;
            this.chkAlldv.Location = new System.Drawing.Point(4, 487);
            this.chkAlldv.Name = "chkAlldv";
            this.chkAlldv.Size = new System.Drawing.Size(164, 17);
            this.chkAlldv.TabIndex = 283;
            this.chkAlldv.Text = "In tất cả kết quả trong đơn vị";
            this.chkAlldv.UseVisualStyleBackColor = true;
            this.chkAlldv.CheckedChanged += new System.EventHandler(this.chkAlldv_CheckedChanged);
            // 
            // frmPhieuksk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkAlldv);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.butPs);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.listMabn);
            this.Controls.Add(this.chkThem);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.list);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.ketluan);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.donvi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhieuksk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu kết quả";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhieuksk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox donvi;
        private AsYetUnnamed.MultiColumnListBox list;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mabn;
        private System.Windows.Forms.TextBox hoten;
        private System.Windows.Forms.TextBox namsinh;
        private System.Windows.Forms.ComboBox phai;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tenbs;
        private System.Windows.Forms.TextBox mabs;
        private System.Windows.Forms.ComboBox loai;
        private System.Windows.Forms.TextBox ketluan;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butMoi;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butHuy;
        private System.Windows.Forms.Button butIn;
        private LibList.List listBS;
        private System.Windows.Forms.CheckBox chkThem;
        private LibList.List listMabn;
        private System.Windows.Forms.TextBox tim;
        private System.Windows.Forms.Button butThem;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Button butPs;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkAlldv;
    }
}