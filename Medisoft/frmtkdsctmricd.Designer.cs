namespace Medisoft
{
    partial class frmtkdsctmricd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtkdsctmricd));
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.butFind = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.may = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rAll = new System.Windows.Forms.RadioButton();
            this.rTrasau = new System.Windows.Forms.RadioButton();
            this.rMien = new System.Windows.Forms.RadioButton();
            this.rThuphi = new System.Windows.Forms.RadioButton();
            this.cmbma = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listbscd = new LibList.List();
            this.mabs = new System.Windows.Forms.TextBox();
            this.butMabs = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(152, 6);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 1;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(51, 6);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(120, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(-2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(50, 30);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(166, 21);
            this.loai.TabIndex = 2;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(-3, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 11;
            this.label15.Text = "Loại  :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butFind
            // 
            this.butFind.Image = ((System.Drawing.Image)(resources.GetObject("butFind.Image")));
            this.butFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butFind.Location = new System.Drawing.Point(156, 165);
            this.butFind.Name = "butFind";
            this.butFind.Size = new System.Drawing.Size(91, 25);
            this.butFind.TabIndex = 8;
            this.butFind.Text = "&In";
            this.butFind.UseVisualStyleBackColor = true;
            this.butFind.Click += new System.EventHandler(this.butFind_Click);
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Image = global::Medisoft.Properties.Resources.exit1;
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(247, 165);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(89, 25);
            this.butExit.TabIndex = 9;
            this.butExit.Text = "&Kết thúc";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // may
            // 
            this.may.BackColor = System.Drawing.SystemColors.HighlightText;
            this.may.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.may.Location = new System.Drawing.Point(50, 53);
            this.may.Name = "may";
            this.may.Size = new System.Drawing.Size(166, 21);
            this.may.TabIndex = 3;
            this.may.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(-16, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 23);
            this.label20.TabIndex = 296;
            this.label20.Text = "Máy :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(66, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 31);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Checked = true;
            this.rb3.Location = new System.Drawing.Point(195, 10);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(56, 17);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.Text = "Tất cả";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(84, 9);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(110, 17);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Không cản quang";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(6, 9);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(77, 17);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "Cản quang";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rAll);
            this.groupBox2.Controls.Add(this.rTrasau);
            this.groupBox2.Controls.Add(this.rMien);
            this.groupBox2.Controls.Add(this.rThuphi);
            this.groupBox2.Location = new System.Drawing.Point(65, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 31);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // rAll
            // 
            this.rAll.AutoSize = true;
            this.rAll.Checked = true;
            this.rAll.Location = new System.Drawing.Point(195, 8);
            this.rAll.Name = "rAll";
            this.rAll.Size = new System.Drawing.Size(56, 17);
            this.rAll.TabIndex = 3;
            this.rAll.TabStop = true;
            this.rAll.Text = "Tất cả";
            this.rAll.UseVisualStyleBackColor = true;
            this.rAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // rTrasau
            // 
            this.rTrasau.AutoSize = true;
            this.rTrasau.Location = new System.Drawing.Point(131, 9);
            this.rTrasau.Name = "rTrasau";
            this.rTrasau.Size = new System.Drawing.Size(61, 17);
            this.rTrasau.TabIndex = 2;
            this.rTrasau.Text = "Trả sau";
            this.rTrasau.UseVisualStyleBackColor = true;
            this.rTrasau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // rMien
            // 
            this.rMien.AutoSize = true;
            this.rMien.Location = new System.Drawing.Point(77, 9);
            this.rMien.Name = "rMien";
            this.rMien.Size = new System.Drawing.Size(48, 17);
            this.rMien.TabIndex = 1;
            this.rMien.Text = "Miễn";
            this.rMien.UseVisualStyleBackColor = true;
            this.rMien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // rThuphi
            // 
            this.rThuphi.AutoSize = true;
            this.rThuphi.Location = new System.Drawing.Point(6, 9);
            this.rThuphi.Name = "rThuphi";
            this.rThuphi.Size = new System.Drawing.Size(63, 17);
            this.rThuphi.TabIndex = 0;
            this.rThuphi.Text = "Thu phí";
            this.rThuphi.UseVisualStyleBackColor = true;
            this.rThuphi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // cmbma
            // 
            this.cmbma.CheckOnClick = true;
            this.cmbma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbma.Location = new System.Drawing.Point(218, 6);
            this.cmbma.Name = "cmbma";
            this.cmbma.Size = new System.Drawing.Size(167, 100);
            this.cmbma.TabIndex = 5;
            this.cmbma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(-16, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 297;
            this.label3.Text = "BSĩ CD :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listbscd
            // 
            this.listbscd.BackColor = System.Drawing.SystemColors.Info;
            this.listbscd.ColumnCount = 0;
            this.listbscd.Location = new System.Drawing.Point(310, 176);
            this.listbscd.MatchBufferTimeOut = 1000;
            this.listbscd.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbscd.Name = "listbscd";
            this.listbscd.Size = new System.Drawing.Size(75, 17);
            this.listbscd.TabIndex = 304;
            this.listbscd.TextIndex = -1;
            this.listbscd.TextMember = null;
            this.listbscd.ValueIndex = -1;
            this.listbscd.Visible = false;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(50, 76);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(166, 21);
            this.mabs.TabIndex = 4;
            this.mabs.TextChanged += new System.EventHandler(this.mabs_TextChanged);
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // butMabs
            // 
            this.butMabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMabs.Image = ((System.Drawing.Image)(resources.GetObject("butMabs.Image")));
            this.butMabs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMabs.Location = new System.Drawing.Point(55, 165);
            this.butMabs.Name = "butMabs";
            this.butMabs.Size = new System.Drawing.Size(101, 25);
            this.butMabs.TabIndex = 305;
            this.butMabs.Text = "Danh sách";
            this.butMabs.UseVisualStyleBackColor = true;
            this.butMabs.Click += new System.EventHandler(this.butMabs_Click);
            // 
            // frmtkdsctmricd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(386, 205);
            this.Controls.Add(this.butMabs);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butFind);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.listbscd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbma);
            this.Controls.Add(this.may);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.den);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmtkdsctmricd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.frmtkdsctmricd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedBox.MaskedBox den;
        private MaskedBox.MaskedBox tu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox loai;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button butFind;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.ComboBox may;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rAll;
        private System.Windows.Forms.RadioButton rTrasau;
        private System.Windows.Forms.RadioButton rMien;
        private System.Windows.Forms.RadioButton rThuphi;
        private System.Windows.Forms.CheckedListBox cmbma;
        private System.Windows.Forms.Label label3;
        private LibList.List listbscd;
        private System.Windows.Forms.TextBox mabs;
        private System.Windows.Forms.Button butMabs;
    }
}