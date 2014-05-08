namespace Medisoft
{
    partial class frmDausinhton_pk
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
            this.label4 = new System.Windows.Forms.Label();
            this.chieucao = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbongayvaovien = new System.Windows.Forms.ComboBox();
            this.cbotenkp = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dthoten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtnv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtct)).BeginInit();
            this.SuspendLayout();
            // 
            // hoten
            // 
            this.hoten.Size = new System.Drawing.Size(256, 21);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(445, 6);
            // 
            // mabs
            // 
            this.mabs.Location = new System.Drawing.Point(490, 6);
            // 
            // tenbs
            // 
            this.tenbs.Location = new System.Drawing.Point(527, 6);
            this.tenbs.Size = new System.Drawing.Size(383, 21);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Location = new System.Drawing.Point(7, 34);
            this.dataGrid1.Size = new System.Drawing.Size(906, 409);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(820, 478);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(750, 478);
            // 
            // butBoqua
            // 
            this.butBoqua.Location = new System.Drawing.Point(610, 478);
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Location = new System.Drawing.Point(540, 478);
            this.butLuu.TabIndex = 17;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(470, 478);
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(400, 478);
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // ghichu
            // 
            this.ghichu.Size = new System.Drawing.Size(613, 21);
            // 
            // huyetap1
            // 
            this.huyetap1.Location = new System.Drawing.Point(658, 261);
            // 
            // butBieudo
            // 
            this.butBieudo.Location = new System.Drawing.Point(680, 478);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(787, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "Chiều cao :";
            // 
            // chieucao
            // 
            this.chieucao.Location = new System.Drawing.Point(848, 452);
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(42, 20);
            this.chieucao.TabIndex = 16;
            this.chieucao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chieucao_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(892, 455);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 123;
            this.label15.Text = "cm";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Enabled = false;
            this.label16.Location = new System.Drawing.Point(15, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 124;
            this.label16.Text = "Ngày vào viện :";
            this.label16.Visible = false;
            // 
            // cbongayvaovien
            // 
            this.cbongayvaovien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbongayvaovien.Enabled = false;
            this.cbongayvaovien.FormattingEnabled = true;
            this.cbongayvaovien.Location = new System.Drawing.Point(94, 56);
            this.cbongayvaovien.Name = "cbongayvaovien";
            this.cbongayvaovien.Size = new System.Drawing.Size(121, 21);
            this.cbongayvaovien.TabIndex = 125;
            this.cbongayvaovien.Visible = false;
            // 
            // cbotenkp
            // 
            this.cbotenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotenkp.Enabled = false;
            this.cbotenkp.FormattingEnabled = true;
            this.cbotenkp.Location = new System.Drawing.Point(94, 79);
            this.cbotenkp.Name = "cbotenkp";
            this.cbotenkp.Size = new System.Drawing.Size(122, 21);
            this.cbotenkp.TabIndex = 127;
            this.cbotenkp.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Enabled = false;
            this.label20.Location = new System.Drawing.Point(5, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 13);
            this.label20.TabIndex = 126;
            this.label20.Text = "Tên khoa phòng :";
            this.label20.Visible = false;
            // 
            // frmDausinhton_pk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 573);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chieucao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbotenkp);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cbongayvaovien);
            this.Controls.Add(this.label16);
            this.Name = "frmDausinhton_pk";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmDausinhton_pk_Load);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.cbongayvaovien, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.cbotenkp, 0);
            this.Controls.SetChildIndex(this.huyetap1, 0);
            this.Controls.SetChildIndex(this.manv, 0);
            this.Controls.SetChildIndex(this.dataGrid1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.mabs, 0);
            this.Controls.SetChildIndex(this.tenbs, 0);
            this.Controls.SetChildIndex(this.mabn, 0);
            this.Controls.SetChildIndex(this.hoten, 0);
            this.Controls.SetChildIndex(this.butHuy, 0);
            this.Controls.SetChildIndex(this.butKetthuc, 0);
            this.Controls.SetChildIndex(this.cmbMabn, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.phong, 0);
            this.Controls.SetChildIndex(this.giuong, 0);
            this.Controls.SetChildIndex(this.ghichu, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.mach, 0);
            this.Controls.SetChildIndex(this.cannang, 0);
            this.Controls.SetChildIndex(this.nhiptho, 0);
            this.Controls.SetChildIndex(this.nhietdo, 0);
            this.Controls.SetChildIndex(this.ngay, 0);
            this.Controls.SetChildIndex(this.butBieudo, 0);
            this.Controls.SetChildIndex(this.huyetap, 0);
            this.Controls.SetChildIndex(this.butBoqua, 0);
            this.Controls.SetChildIndex(this.butMoi, 0);
            this.Controls.SetChildIndex(this.butSua, 0);
            this.Controls.SetChildIndex(this.butLuu, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.chieucao, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dthoten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtnv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox chieucao;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbongayvaovien;
        private System.Windows.Forms.ComboBox cbotenkp;
        private System.Windows.Forms.Label label20;
    }
}