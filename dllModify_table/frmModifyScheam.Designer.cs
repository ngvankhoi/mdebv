namespace dllModify_table
{
    partial class frmModifyScheam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyScheam));
            this.butGet_cautruc_cu = new System.Windows.Forms.Button();
            this.butModify = new System.Windows.Forms.Button();
            this.ButClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkmedibv = new System.Windows.Forms.CheckBox();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkmedibv_taolai = new System.Windows.Forms.CheckBox();
            this.mm_tao = new System.Windows.Forms.NumericUpDown();
            this.yyyy_tao = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butBoquaAlter = new System.Windows.Forms.Button();
            this.butSuaAlter = new System.Windows.Forms.Button();
            this.butTaolai = new System.Windows.Forms.Button();
            this.butLuuAltertable = new System.Windows.Forms.Button();
            this.cbCommand = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDatatype = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTblName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_schema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_tablename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_comand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_datatype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_default_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbSchema = new System.Windows.Forms.ComboBox();
            this.butHuy_altertable = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mm_tao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy_tao)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // butGet_cautruc_cu
            // 
            this.butGet_cautruc_cu.Location = new System.Drawing.Point(36, 71);
            this.butGet_cautruc_cu.Name = "butGet_cautruc_cu";
            this.butGet_cautruc_cu.Size = new System.Drawing.Size(125, 23);
            this.butGet_cautruc_cu.TabIndex = 0;
            this.butGet_cautruc_cu.Text = "Get_Cấu trúc";
            this.butGet_cautruc_cu.UseVisualStyleBackColor = true;
            this.butGet_cautruc_cu.Click += new System.EventHandler(this.butGet_cautruc_cu_Click);
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(33, 71);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(137, 23);
            this.butModify.TabIndex = 1;
            this.butModify.Text = "Modify Cấu trúc";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // ButClose
            // 
            this.ButClose.Location = new System.Drawing.Point(223, 109);
            this.ButClose.Name = "ButClose";
            this.ButClose.Size = new System.Drawing.Size(106, 26);
            this.ButClose.TabIndex = 2;
            this.ButClose.Text = "Kết thúc";
            this.ButClose.UseVisualStyleBackColor = true;
            this.ButClose.Click += new System.EventHandler(this.ButClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkmedibv);
            this.groupBox1.Controls.Add(this.mm);
            this.groupBox1.Controls.Add(this.yyyy);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.butGet_cautruc_cu);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu trúc chuẩn";
            // 
            // chkmedibv
            // 
            this.chkmedibv.AutoSize = true;
            this.chkmedibv.Location = new System.Drawing.Point(9, 46);
            this.chkmedibv.Name = "chkmedibv";
            this.chkmedibv.Size = new System.Drawing.Size(84, 17);
            this.chkmedibv.TabIndex = 8;
            this.chkmedibv.Text = "Medibv Gốc";
            this.chkmedibv.UseVisualStyleBackColor = true;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(54, 16);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(35, 22);
            this.mm.TabIndex = 5;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(141, 16);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(52, 22);
            this.yyyy.TabIndex = 7;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(102, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Năm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkmedibv_taolai);
            this.groupBox2.Controls.Add(this.mm_tao);
            this.groupBox2.Controls.Add(this.yyyy_tao);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.butModify);
            this.groupBox2.Location = new System.Drawing.Point(274, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modify lại";
            // 
            // chkmedibv_taolai
            // 
            this.chkmedibv_taolai.AutoSize = true;
            this.chkmedibv_taolai.Location = new System.Drawing.Point(10, 44);
            this.chkmedibv_taolai.Name = "chkmedibv_taolai";
            this.chkmedibv_taolai.Size = new System.Drawing.Size(84, 17);
            this.chkmedibv_taolai.TabIndex = 12;
            this.chkmedibv_taolai.Text = "Medibv Gốc";
            this.chkmedibv_taolai.UseVisualStyleBackColor = true;
            // 
            // mm_tao
            // 
            this.mm_tao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm_tao.Location = new System.Drawing.Point(55, 15);
            this.mm_tao.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm_tao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm_tao.Name = "mm_tao";
            this.mm_tao.Size = new System.Drawing.Size(35, 22);
            this.mm_tao.TabIndex = 9;
            this.mm_tao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yyyy_tao
            // 
            this.yyyy_tao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy_tao.Location = new System.Drawing.Point(142, 15);
            this.yyyy_tao.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy_tao.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy_tao.Name = "yyyy_tao";
            this.yyyy_tao.Size = new System.Drawing.Size(52, 22);
            this.yyyy_tao.TabIndex = 11;
            this.yyyy_tao.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(103, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tháng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 141);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(611, 281);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 451);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.ButClose);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(619, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lấy cấu trúc - Modify";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butHuy_altertable);
            this.tabPage2.Controls.Add(this.butBoquaAlter);
            this.tabPage2.Controls.Add(this.butSuaAlter);
            this.tabPage2.Controls.Add(this.butTaolai);
            this.tabPage2.Controls.Add(this.butLuuAltertable);
            this.tabPage2.Controls.Add(this.cbCommand);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.txtDatatype);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.txtDefaultValue);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.txtColumnName);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txtTblName);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.txtTim);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.cbSchema);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(619, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View column";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // butBoquaAlter
            // 
            this.butBoquaAlter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoquaAlter.Location = new System.Drawing.Point(259, 396);
            this.butBoquaAlter.Name = "butBoquaAlter";
            this.butBoquaAlter.Size = new System.Drawing.Size(94, 23);
            this.butBoquaAlter.TabIndex = 8;
            this.butBoquaAlter.Text = "Bỏ qua";
            this.butBoquaAlter.UseVisualStyleBackColor = true;
            this.butBoquaAlter.Click += new System.EventHandler(this.butBoquaAlter_Click);
            // 
            // butSuaAlter
            // 
            this.butSuaAlter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSuaAlter.Location = new System.Drawing.Point(71, 396);
            this.butSuaAlter.Name = "butSuaAlter";
            this.butSuaAlter.Size = new System.Drawing.Size(94, 23);
            this.butSuaAlter.TabIndex = 6;
            this.butSuaAlter.Text = "Sửa";
            this.butSuaAlter.UseVisualStyleBackColor = true;
            this.butSuaAlter.Click += new System.EventHandler(this.butSuaAlter_Click);
            // 
            // butTaolai
            // 
            this.butTaolai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTaolai.Location = new System.Drawing.Point(448, 396);
            this.butTaolai.Name = "butTaolai";
            this.butTaolai.Size = new System.Drawing.Size(117, 23);
            this.butTaolai.TabIndex = 9;
            this.butTaolai.Text = "Kết thúc";
            this.butTaolai.UseVisualStyleBackColor = true;
            this.butTaolai.Click += new System.EventHandler(this.butTaolai_Click);
            // 
            // butLuuAltertable
            // 
            this.butLuuAltertable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuuAltertable.Location = new System.Drawing.Point(165, 396);
            this.butLuuAltertable.Name = "butLuuAltertable";
            this.butLuuAltertable.Size = new System.Drawing.Size(94, 23);
            this.butLuuAltertable.TabIndex = 7;
            this.butLuuAltertable.Text = "Lưu";
            this.butLuuAltertable.UseVisualStyleBackColor = true;
            this.butLuuAltertable.Click += new System.EventHandler(this.butLuuAltertable_Click);
            // 
            // cbCommand
            // 
            this.cbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommand.FormattingEnabled = true;
            this.cbCommand.Items.AddRange(new object[] {
            "add",
            "alter column"});
            this.cbCommand.Location = new System.Drawing.Point(81, 369);
            this.cbCommand.Name = "cbCommand";
            this.cbCommand.Size = new System.Drawing.Size(104, 21);
            this.cbCommand.TabIndex = 3;
            this.cbCommand.SelectedIndexChanged += new System.EventHandler(this.cbCommand_SelectedIndexChanged);
            this.cbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(190, 373);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 40;
            this.label20.Text = "Data type";
            // 
            // txtDatatype
            // 
            this.txtDatatype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDatatype.Location = new System.Drawing.Point(249, 370);
            this.txtDatatype.Name = "txtDatatype";
            this.txtDatatype.Size = new System.Drawing.Size(168, 20);
            this.txtDatatype.TabIndex = 4;
            this.txtDatatype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(425, 373);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "Default value";
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultValue.Location = new System.Drawing.Point(498, 370);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(111, 20);
            this.txtDefaultValue.TabIndex = 5;
            this.txtDefaultValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 373);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 36;
            this.label18.Text = "Command";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(280, 350);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Column Name";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColumnName.Location = new System.Drawing.Point(360, 347);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(249, 20);
            this.txtColumnName.TabIndex = 2;
            this.txtColumnName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 350);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Table Name";
            // 
            // txtTblName
            // 
            this.txtTblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTblName.Location = new System.Drawing.Point(81, 347);
            this.txtTblName.Name = "txtTblName";
            this.txtTblName.Size = new System.Drawing.Size(193, 20);
            this.txtTblName.TabIndex = 1;
            this.txtTblName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_schema,
            this.c_tablename,
            this.c_Column_name,
            this.c_comand,
            this.c_datatype,
            this.c_default_value});
            this.dataGridView1.Location = new System.Drawing.Point(1, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(615, 317);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "id";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.Visible = false;
            // 
            // c_schema
            // 
            this.c_schema.DataPropertyName = "schema_name";
            this.c_schema.HeaderText = "Schema";
            this.c_schema.Name = "c_schema";
            // 
            // c_tablename
            // 
            this.c_tablename.DataPropertyName = "table_name";
            this.c_tablename.HeaderText = "Table_Name";
            this.c_tablename.Name = "c_tablename";
            // 
            // c_Column_name
            // 
            this.c_Column_name.DataPropertyName = "field_name";
            this.c_Column_name.HeaderText = "Column Name";
            this.c_Column_name.Name = "c_Column_name";
            // 
            // c_comand
            // 
            this.c_comand.DataPropertyName = "command_ct";
            this.c_comand.HeaderText = "Command";
            this.c_comand.Name = "c_comand";
            // 
            // c_datatype
            // 
            this.c_datatype.DataPropertyName = "data_type";
            this.c_datatype.HeaderText = "Data Type";
            this.c_datatype.Name = "c_datatype";
            // 
            // c_default_value
            // 
            this.c_default_value.DataPropertyName = "default_value";
            this.c_default_value.HeaderText = "Default value";
            this.c_default_value.Name = "c_default_value";
            // 
            // txtTim
            // 
            this.txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTim.Location = new System.Drawing.Point(160, 3);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(452, 20);
            this.txtTim.TabIndex = 12;
            this.txtTim.Text = "Tìm kiếm";
            this.txtTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
            this.txtTim.Enter += new System.EventHandler(this.txtTim_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Schema";
            // 
            // cbSchema
            // 
            this.cbSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Items.AddRange(new object[] {
            "MMYY",
            "Medibv"});
            this.cbSchema.Location = new System.Drawing.Point(53, 2);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(101, 21);
            this.cbSchema.TabIndex = 0;
            this.cbSchema.SelectedIndexChanged += new System.EventHandler(this.cbSchema_SelectedIndexChanged);
            // 
            // butHuy_altertable
            // 
            this.butHuy_altertable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy_altertable.Location = new System.Drawing.Point(354, 396);
            this.butHuy_altertable.Name = "butHuy_altertable";
            this.butHuy_altertable.Size = new System.Drawing.Size(94, 23);
            this.butHuy_altertable.TabIndex = 41;
            this.butHuy_altertable.Text = "Huỷ";
            this.butHuy_altertable.UseVisualStyleBackColor = true;
            this.butHuy_altertable.Click += new System.EventHandler(this.butHuy_altertable_Click);
            // 
            // frmModifyScheam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 451);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "frmModifyScheam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Schema";
            this.Load += new System.EventHandler(this.frmModifyScheam_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmModifyScheam_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mm_tao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy_tao)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butGet_cautruc_cu;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button ButClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown mm;
        private System.Windows.Forms.NumericUpDown yyyy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown mm_tao;
        private System.Windows.Forms.NumericUpDown yyyy_tao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkmedibv;
        private System.Windows.Forms.CheckBox chkmedibv_taolai;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbSchema;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_schema;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_tablename;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_comand;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_datatype;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_default_value;
        private System.Windows.Forms.ComboBox cbCommand;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDatatype;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTblName;
        private System.Windows.Forms.Button butBoquaAlter;
        private System.Windows.Forms.Button butSuaAlter;
        private System.Windows.Forms.Button butTaolai;
        private System.Windows.Forms.Button butLuuAltertable;
        private System.Windows.Forms.Button butHuy_altertable;
    }
}

