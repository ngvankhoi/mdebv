namespace Medisoft
{
    partial class frmTiepdon_new
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiepdon_new));
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.cklLydokham = new System.Windows.Forms.CheckedListBox();
            this.cklLydodungtuyen = new System.Windows.Forms.CheckedListBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtLydokham = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.cmbUudai = new System.Windows.Forms.ComboBox();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butChitiet = new System.Windows.Forms.Button();
            this.lbDuyetMien = new System.Windows.Forms.Label();
            this.cmbDuyetmien = new System.Windows.Forms.ComboBox();
            this.cmbLoaitg = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dgrPhongcls = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dtv)).BeginInit();
            this.phanhchinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            this.pdienthoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarcode)).BeginInit();
            this.pgoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.pmien.SuspendLayout();
            this.dausinhton.SuspendLayout();
            this.khamthai.SuspendLayout();
            this.pnmakp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.pvaovien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPhongcls)).BeginInit();
            this.SuspendLayout();
            // 
            // tenba
            // 
            this.tenba.Location = new System.Drawing.Point(166, 27);
            // 
            // mabn1
            // 
            this.mabn1.Validated += new System.EventHandler(this.mabn1_Validated);
            // 
            // mabn2
            // 
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // treeView1
            // 
            this.treeView1.LineColor = System.Drawing.Color.Black;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // butInbarcode
            // 
            this.butInbarcode.Location = new System.Drawing.Point(155, 544);
            // 
            // button1
            // 
            this.button1.Size = new System.Drawing.Size(385, 545);
            // 
            // listdstt
            // 
            this.listdstt.Validated += new System.EventHandler(this.listdstt_Validated);
            // 
            // l_bnmoi
            // 
            this.l_bnmoi.Visible = false;
            // 
            // quanhe
            // 
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
            // 
            // qh_diachi
            // 
            this.qh_diachi.TabIndex = 22;
            // 
            // tendoituong
            // 
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            // 
            // bnmoi
            // 
            this.bnmoi.Visible = false;
            // 
            // butTiep
            // 
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // sothe
            // 
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            // 
            // tendstt
            // 
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            // 
            // qh_dienthoai
            // 
            this.qh_dienthoai.TabIndex = 21;
            // 
            // pnmakp
            // 
            this.pnmakp.Location = new System.Drawing.Point(165, 202);
            this.pnmakp.Size = new System.Drawing.Size(234, 261);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Size = new System.Drawing.Size(225, 210);
            // 
            // dataGrid2
            // 
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.Blue;
            this.dataGrid2.CaptionText = "Thông tin phòng khám";
            this.dataGrid2.Location = new System.Drawing.Point(801, 30);
            this.dataGrid2.Size = new System.Drawing.Size(146, 153);
            // 
            // chkView
            // 
            this.chkView.CheckedChanged += new System.EventHandler(this.chkView_CheckedChanged_1);
            // 
            // traituyen
            // 
            this.traituyen.Enabled = false;
            // 
            // pvaovien
            // 
            this.pvaovien.Controls.Add(this.cmbLoaitg);
            this.pvaovien.Controls.Add(this.groupBox1);
            this.pvaovien.Controls.Add(this.groupBox2);
            this.pvaovien.Controls.SetChildIndex(this.button2, 0);
            this.pvaovien.Controls.SetChildIndex(this.listBS, 0);
            this.pvaovien.Controls.SetChildIndex(this.listSothe, 0);
            this.pvaovien.Controls.SetChildIndex(this.label36, 0);
            this.pvaovien.Controls.SetChildIndex(this.l_bnmoi, 0);
            this.pvaovien.Controls.SetChildIndex(this.list, 0);
            this.pvaovien.Controls.SetChildIndex(this.label1, 0);
            this.pvaovien.Controls.SetChildIndex(this.makp, 0);
            this.pvaovien.Controls.SetChildIndex(this.label19, 0);
            this.pvaovien.Controls.SetChildIndex(this.lbldoituong, 0);
            this.pvaovien.Controls.SetChildIndex(this.lblsothe, 0);
            this.pvaovien.Controls.SetChildIndex(this.lblden, 0);
            this.pvaovien.Controls.SetChildIndex(this.pmien, 0);
            this.pvaovien.Controls.SetChildIndex(this.lblnguoithan, 0);
            this.pvaovien.Controls.SetChildIndex(this.lblhoten, 0);
            this.pvaovien.Controls.SetChildIndex(this.lbldiachi, 0);
            this.pvaovien.Controls.SetChildIndex(this.lbldienthoai, 0);
            this.pvaovien.Controls.SetChildIndex(this.label30, 0);
            this.pvaovien.Controls.SetChildIndex(this.sovaovien, 0);
            this.pvaovien.Controls.SetChildIndex(this.quanhe, 0);
            this.pvaovien.Controls.SetChildIndex(this.qh_diachi, 0);
            this.pvaovien.Controls.SetChildIndex(this.lbldkkcb, 0);
            this.pvaovien.Controls.SetChildIndex(this.bnmoi, 0);
            this.pvaovien.Controls.SetChildIndex(this.butIn, 0);
            this.pvaovien.Controls.SetChildIndex(this.lbacsy, 0);
            this.pvaovien.Controls.SetChildIndex(this.tenbs, 0);
            this.pvaovien.Controls.SetChildIndex(this.label34, 0);
            this.pvaovien.Controls.SetChildIndex(this.loai, 0);
            this.pvaovien.Controls.SetChildIndex(this.tenbv, 0);
            this.pvaovien.Controls.SetChildIndex(this.butKetthuc, 0);
            this.pvaovien.Controls.SetChildIndex(this.lbltu, 0);
            this.pvaovien.Controls.SetChildIndex(this.tungay, 0);
            this.pvaovien.Controls.SetChildIndex(this.label37, 0);
            this.pvaovien.Controls.SetChildIndex(this.giovv, 0);
            this.pvaovien.Controls.SetChildIndex(this.lhonnhan, 0);
            this.pvaovien.Controls.SetChildIndex(this.honnhan, 0);
            this.pvaovien.Controls.SetChildIndex(this.label53, 0);
            this.pvaovien.Controls.SetChildIndex(this.mabv, 0);
            this.pvaovien.Controls.SetChildIndex(this.label38, 0);
            this.pvaovien.Controls.SetChildIndex(this.ltienkham, 0);
            this.pvaovien.Controls.SetChildIndex(this.lsobienlai, 0);
            this.pvaovien.Controls.SetChildIndex(this.tienkham, 0);
            this.pvaovien.Controls.SetChildIndex(this.matienkham, 0);
            this.pvaovien.Controls.SetChildIndex(this.butKyhieu, 0);
            this.pvaovien.Controls.SetChildIndex(this.lkyhieu, 0);
            this.pvaovien.Controls.SetChildIndex(this.kyhieu, 0);
            this.pvaovien.Controls.SetChildIndex(this.checkBox1, 0);
            this.pvaovien.Controls.SetChildIndex(this.sobienlai, 0);
            this.pvaovien.Controls.SetChildIndex(this.dongia, 0);
            this.pvaovien.Controls.SetChildIndex(this.chkxml, 0);
            this.pvaovien.Controls.SetChildIndex(this.denngay, 0);
            this.pvaovien.Controls.SetChildIndex(this.lbs, 0);
            this.pvaovien.Controls.SetChildIndex(this.qh_hoten, 0);
            this.pvaovien.Controls.SetChildIndex(this.qh_dienthoai, 0);
            this.pvaovien.Controls.SetChildIndex(this.mabs, 0);
            this.pvaovien.Controls.SetChildIndex(this.listbs1, 0);
            this.pvaovien.Controls.SetChildIndex(this.lbv, 0);
            this.pvaovien.Controls.SetChildIndex(this.bacsy, 0);
            this.pvaovien.Controls.SetChildIndex(this.listbv, 0);
            this.pvaovien.Controls.SetChildIndex(this.benhvien, 0);
            this.pvaovien.Controls.SetChildIndex(this.chkNgoaitru, 0);
            this.pvaovien.Controls.SetChildIndex(this.ngay1, 0);
            this.pvaovien.Controls.SetChildIndex(this.ngay2, 0);
            this.pvaovien.Controls.SetChildIndex(this.ngay3, 0);
            this.pvaovien.Controls.SetChildIndex(this.traituyen, 0);
            this.pvaovien.Controls.SetChildIndex(this.listKP, 0);
            this.pvaovien.Controls.SetChildIndex(this.tenkp, 0);
            this.pvaovien.Controls.SetChildIndex(this.chkChenhlechcongkham, 0);
            this.pvaovien.Controls.SetChildIndex(this.chkNhanvienbv, 0);
            this.pvaovien.Controls.SetChildIndex(this.dausinhton, 0);
            this.pvaovien.Controls.SetChildIndex(this.khamthai, 0);
            this.pvaovien.Controls.SetChildIndex(this.n_makp, 0);
            this.pvaovien.Controls.SetChildIndex(this.listdstt, 0);
            this.pvaovien.Controls.SetChildIndex(this.tendoituong, 0);
            this.pvaovien.Controls.SetChildIndex(this.madoituong, 0);
            this.pvaovien.Controls.SetChildIndex(this.ngayvv, 0);
            this.pvaovien.Controls.SetChildIndex(this.tendstt, 0);
            this.pvaovien.Controls.SetChildIndex(this.madstt, 0);
            this.pvaovien.Controls.SetChildIndex(this.llydo, 0);
            this.pvaovien.Controls.SetChildIndex(this.lydo, 0);
            this.pvaovien.Controls.SetChildIndex(this.butTiep, 0);
            this.pvaovien.Controls.SetChildIndex(this.butLuu, 0);
            this.pvaovien.Controls.SetChildIndex(this.butBoqua, 0);
            this.pvaovien.Controls.SetChildIndex(this.groupBox2, 0);
            this.pvaovien.Controls.SetChildIndex(this.groupBox1, 0);
            this.pvaovien.Controls.SetChildIndex(this.cmbLoaitg, 0);
            this.pvaovien.Controls.SetChildIndex(this.pnmakp, 0);
            this.pvaovien.Controls.SetChildIndex(this.lblchieudaithe, 0);
            this.pvaovien.Controls.SetChildIndex(this.sothe, 0);
            // 
            // barcode
            // 
            this.barcode.Location = new System.Drawing.Point(107, 503);
            this.barcode.Size = new System.Drawing.Size(173, 30);
            this.barcode.Text = "10976492";
            // 
            // dataGrid3
            // 
            this.dataGrid3.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid3.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.DataMember = "";
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid3.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid3.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid3.Location = new System.Drawing.Point(801, 397);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.RowHeaderWidth = 10;
            this.dataGrid3.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.Size = new System.Drawing.Size(146, 172);
            this.dataGrid3.TabIndex = 270;
            // 
            // cklLydokham
            // 
            this.cklLydokham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cklLydokham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.cklLydokham.FormattingEnabled = true;
            this.cklLydokham.Location = new System.Drawing.Point(4, 26);
            this.cklLydokham.Name = "cklLydokham";
            this.cklLydokham.Size = new System.Drawing.Size(224, 49);
            this.cklLydokham.TabIndex = 23;
            this.cklLydokham.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cklLydokham_MouseDoubleClick);
            this.cklLydokham.SelectedIndexChanged += new System.EventHandler(this.cklLydokham_SelectedIndexChanged);
            this.cklLydokham.SelectedValueChanged += new System.EventHandler(this.cklLydokham_SelectedValueChanged);
            this.cklLydokham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cklLydokham_KeyDown);
            // 
            // cklLydodungtuyen
            // 
            this.cklLydodungtuyen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cklLydodungtuyen.Enabled = false;
            this.cklLydodungtuyen.FormattingEnabled = true;
            this.cklLydodungtuyen.Location = new System.Drawing.Point(232, 26);
            this.cklLydodungtuyen.Name = "cklLydodungtuyen";
            this.cklLydodungtuyen.Size = new System.Drawing.Size(160, 49);
            this.cklLydodungtuyen.TabIndex = 24;
            this.cklLydodungtuyen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cklLydodungtuyen_MouseDoubleClick);
            this.cklLydodungtuyen.SelectedValueChanged += new System.EventHandler(this.cklLydodungtuyen_SelectedValueChanged);
            this.cklLydodungtuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cklLydokham_KeyDown);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(3, 11);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(62, 13);
            this.label46.TabIndex = 273;
            this.label46.Text = "Lý do khám";
            // 
            // txtLydokham
            // 
            this.txtLydokham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLydokham.Enabled = false;
            this.txtLydokham.Location = new System.Drawing.Point(4, 92);
            this.txtLydokham.Multiline = true;
            this.txtLydokham.Name = "txtLydokham";
            this.txtLydokham.Size = new System.Drawing.Size(388, 23);
            this.txtLydokham.TabIndex = 25;
            this.txtLydokham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cklLydokham_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label49);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.cklLydokham);
            this.groupBox1.Controls.Add(this.txtLydokham);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.cklLydodungtuyen);
            this.groupBox1.Location = new System.Drawing.Point(2, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 120);
            this.groupBox1.TabIndex = 272;
            this.groupBox1.TabStop = false;
            this.groupBox1.Validated += new System.EventHandler(this.groupBox1_Validated);
            // 
            // label49
            // 
            this.label49.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(3, 78);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(108, 13);
            this.label49.TabIndex = 275;
            this.label49.Text = "Ghi chú - Lý do khám";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(229, 11);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(168, 13);
            this.label48.TabIndex = 274;
            this.label48.Text = "Lý do hưởng quyền lợi đúng tuyến";
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(5, 11);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(81, 13);
            this.label47.TabIndex = 273;
            this.label47.Text = "Chế độ ưu đãi: ";
            // 
            // cmbUudai
            // 
            this.cmbUudai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbUudai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUudai.FormattingEnabled = true;
            this.cmbUudai.Location = new System.Drawing.Point(9, 30);
            this.cmbUudai.Name = "cmbUudai";
            this.cmbUudai.Size = new System.Drawing.Size(152, 21);
            this.cmbUudai.TabIndex = 26;
            this.cmbUudai.SelectedIndexChanged += new System.EventHandler(this.cmbUudai_SelectedIndexChanged);
            this.cmbUudai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cklLydokham_KeyDown);
            // 
            // dataGrid4
            // 
            this.dataGrid4.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid4.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.DataMember = "";
            this.dataGrid4.FlatMode = true;
            this.dataGrid4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid4.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid4.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid4.Location = new System.Drawing.Point(6, 34);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.RowHeaderWidth = 10;
            this.dataGrid4.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.Size = new System.Drawing.Size(390, 116);
            this.dataGrid4.TabIndex = 272;
            this.dataGrid4.Validated += new System.EventHandler(this.dataGrid4_Validated);
            this.dataGrid4.CurrentCellChanged += new System.EventHandler(this.dataGrid4_CurrentCellChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.butChitiet);
            this.groupBox2.Controls.Add(this.lbDuyetMien);
            this.groupBox2.Controls.Add(this.cmbDuyetmien);
            this.groupBox2.Controls.Add(this.cmbUudai);
            this.groupBox2.Controls.Add(this.label47);
            this.groupBox2.Controls.Add(this.dataGrid4);
            this.groupBox2.Location = new System.Drawing.Point(3, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 156);
            this.groupBox2.TabIndex = 275;
            this.groupBox2.TabStop = false;
            // 
            // butChitiet
            // 
            this.butChitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butChitiet.Image = ((System.Drawing.Image)(resources.GetObject("butChitiet.Image")));
            this.butChitiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChitiet.Location = new System.Drawing.Point(86, 5);
            this.butChitiet.Name = "butChitiet";
            this.butChitiet.Size = new System.Drawing.Size(75, 25);
            this.butChitiet.TabIndex = 275;
            this.butChitiet.Text = "   Chi tiết";
            this.butChitiet.UseVisualStyleBackColor = true;
            this.butChitiet.Visible = false;
            this.butChitiet.Click += new System.EventHandler(this.butChitiet_Click);
            // 
            // lbDuyetMien
            // 
            this.lbDuyetMien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDuyetMien.AutoSize = true;
            this.lbDuyetMien.Location = new System.Drawing.Point(173, 11);
            this.lbDuyetMien.Name = "lbDuyetMien";
            this.lbDuyetMien.Size = new System.Drawing.Size(16, 13);
            this.lbDuyetMien.TabIndex = 274;
            this.lbDuyetMien.Text = "...";
            // 
            // cmbDuyetmien
            // 
            this.cmbDuyetmien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDuyetmien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuyetmien.Enabled = false;
            this.cmbDuyetmien.FormattingEnabled = true;
            this.cmbDuyetmien.Items.AddRange(new object[] {
            "",
            "Miễn giảm",
            "Khuyến mãi",
            "Ưu đãi",
            "Khuyến mãi theo thẻ BHYT"});
            this.cmbDuyetmien.Location = new System.Drawing.Point(173, 30);
            this.cmbDuyetmien.Name = "cmbDuyetmien";
            this.cmbDuyetmien.Size = new System.Drawing.Size(217, 21);
            this.cmbDuyetmien.TabIndex = 27;
            this.cmbDuyetmien.SelectedIndexChanged += new System.EventHandler(this.cmbDuyetmien_SelectedIndexChanged);
            this.cmbDuyetmien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cklLydokham_KeyDown);
            // 
            // cmbLoaitg
            // 
            this.cmbLoaitg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaitg.Enabled = false;
            this.cmbLoaitg.FormattingEnabled = true;
            this.cmbLoaitg.Location = new System.Drawing.Point(241, 0);
            this.cmbLoaitg.Name = "cmbLoaitg";
            this.cmbLoaitg.Size = new System.Drawing.Size(159, 21);
            this.cmbLoaitg.TabIndex = 272;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(799, 402);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(88, 13);
            this.linkLabel1.TabIndex = 272;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Các lần khám:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dgrPhongcls
            // 
            this.dgrPhongcls.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dgrPhongcls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrPhongcls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgrPhongcls.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgrPhongcls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgrPhongcls.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dgrPhongcls.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgrPhongcls.CaptionForeColor = System.Drawing.Color.Blue;
            this.dgrPhongcls.CaptionText = "Thông tin phòng CLS";
            this.dgrPhongcls.DataMember = "";
            this.dgrPhongcls.FlatMode = true;
            this.dgrPhongcls.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgrPhongcls.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dgrPhongcls.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dgrPhongcls.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgrPhongcls.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgrPhongcls.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgrPhongcls.LinkColor = System.Drawing.Color.Teal;
            this.dgrPhongcls.Location = new System.Drawing.Point(801, 184);
            this.dgrPhongcls.Name = "dgrPhongcls";
            this.dgrPhongcls.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dgrPhongcls.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dgrPhongcls.ReadOnly = true;
            this.dgrPhongcls.RowHeaderWidth = 10;
            this.dgrPhongcls.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgrPhongcls.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgrPhongcls.Size = new System.Drawing.Size(146, 215);
            this.dgrPhongcls.TabIndex = 273;
            // 
            // frmTiepdon_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 573);
            this.Controls.Add(this.dgrPhongcls);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.dataGrid3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTiepdon_new";
            this.Text = "frmTiepdon_new";
            this.Load += new System.EventHandler(this.frmTiepdon_new_Load);
            this.Controls.SetChildIndex(this.pBarcode, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.mabn1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.loaituoi, 0);
            this.Controls.SetChildIndex(this.maba, 0);
            this.Controls.SetChildIndex(this.tuoi, 0);
            this.Controls.SetChildIndex(this.hoten, 0);
            this.Controls.SetChildIndex(this.namsinh, 0);
            this.Controls.SetChildIndex(this.label52, 0);
            this.Controls.SetChildIndex(this.tenba, 0);
            this.Controls.SetChildIndex(this.phanhchinh, 0);
            this.Controls.SetChildIndex(this.ngaysinh, 0);
            this.Controls.SetChildIndex(this.ptb, 0);
            this.Controls.SetChildIndex(this.pdienthoai, 0);
            this.Controls.SetChildIndex(this.label42, 0);
            //this.Controls.SetChildIndex(this.pic, 0);
            this.Controls.SetChildIndex(this.label44, 0);
            this.Controls.SetChildIndex(this.label43, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.phai, 0);
            //this.Controls.SetChildIndex(this.chkDieutri, 0);
            //this.Controls.SetChildIndex(this.pgoi, 0);
            this.Controls.SetChildIndex(this.linthe, 0);
            this.Controls.SetChildIndex(this.lbienlaithe, 0);
            this.Controls.SetChildIndex(this.butInbarcode, 0);
            this.Controls.SetChildIndex(this.chkBhyt, 0);
            this.Controls.SetChildIndex(this.chkView, 0);
            this.Controls.SetChildIndex(this.butget_msbn_from_internet, 0);
            this.Controls.SetChildIndex(this.treeView1, 0);
            this.Controls.SetChildIndex(this.mabn2, 0);
            this.Controls.SetChildIndex(this.mabn3, 0);
            this.Controls.SetChildIndex(this.mathe, 0);
            this.Controls.SetChildIndex(this.pvaovien, 0);
            this.Controls.SetChildIndex(this.dataGrid3, 0);
            this.Controls.SetChildIndex(this.barcode, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.dataGrid2, 0);
            this.Controls.SetChildIndex(this.dgrPhongcls, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtv)).EndInit();
            this.phanhchinh.ResumeLayout(false);
            this.phanhchinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            this.pdienthoai.ResumeLayout(false);
            this.pdienthoai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarcode)).EndInit();
            this.pgoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.pmien.ResumeLayout(false);
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.pnmakp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPhongcls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid3;
        private System.Windows.Forms.CheckedListBox cklLydokham;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.CheckedListBox cklLydodungtuyen;
        private System.Windows.Forms.TextBox txtLydokham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbUudai;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.DataGrid dataGrid4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbDuyetmien;
        private System.Windows.Forms.ComboBox cmbLoaitg;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label lbDuyetMien;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button butChitiet;
        private System.Windows.Forms.DataGrid dgrPhongcls;

    }
}