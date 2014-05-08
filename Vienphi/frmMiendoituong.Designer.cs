namespace Vienphi
{
    partial class frmMiendoituong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMiendoituong));
            this.cbDoituong = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.pCT = new System.Windows.Forms.Panel();
            this.txtSotienmien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.txtSotien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.butBoqua = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbDoituong
            // 
            this.cbDoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoituong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoituong.FormattingEnabled = true;
            this.cbDoituong.Location = new System.Drawing.Point(62, 3);
            this.cbDoituong.Name = "cbDoituong";
            this.cbDoituong.Size = new System.Drawing.Size(355, 23);
            this.cbDoituong.TabIndex = 0;
            this.cbDoituong.SelectedIndexChanged += new System.EventHandler(this.cbDoituong_SelectedIndexChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(6, 8);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(56, 13);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Đối tượng:";
            // 
            // pCT
            // 
            this.pCT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pCT.Location = new System.Drawing.Point(5, 52);
            this.pCT.Name = "pCT";
            this.pCT.Size = new System.Drawing.Size(412, 413);
            this.pCT.TabIndex = 8;
            // 
            // txtSotienmien
            // 
            this.txtSotienmien.BackColor = System.Drawing.Color.Black;
            this.txtSotienmien.Enabled = false;
            this.txtSotienmien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSotienmien.ForeColor = System.Drawing.Color.White;
            this.txtSotienmien.Location = new System.Drawing.Point(2, 26);
            this.txtSotienmien.Name = "txtSotienmien";
            this.txtSotienmien.Size = new System.Drawing.Size(111, 23);
            this.txtSotienmien.TabIndex = 17;
            this.txtSotienmien.Text = "10 000 000";
            this.txtSotienmien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSotienmien.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số tiền miễn:";
            this.label1.Visible = false;
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.butKetthuc.Image = global::Vienphi.Properties.Resources.close_r1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(240, 470);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(83, 26);
            this.butKetthuc.TabIndex = 22;
            this.butKetthuc.Text = "     &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(92, 470);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(69, 26);
            this.butLuu.TabIndex = 19;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // txtSotien
            // 
            this.txtSotien.BackColor = System.Drawing.Color.Black;
            this.txtSotien.Enabled = false;
            this.txtSotien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSotien.ForeColor = System.Drawing.Color.White;
            this.txtSotien.Location = new System.Drawing.Point(331, 27);
            this.txtSotien.Name = "txtSotien";
            this.txtSotien.Size = new System.Drawing.Size(74, 23);
            this.txtSotien.TabIndex = 17;
            this.txtSotien.Text = "10 000 000";
            this.txtSotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(249, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phần trăm miễn:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(405, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "%";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "đồng";
            this.label4.Visible = false;
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(161, 470);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(79, 26);
            this.butBoqua.TabIndex = 21;
            this.butBoqua.Text = "    &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // frmMiendoituong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 500);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.txtSotien);
            this.Controls.Add(this.txtSotienmien);
            this.Controls.Add(this.pCT);
            this.Controls.Add(this.cbDoituong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMiendoituong";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Miễn giảm đối tượng theo loại viện phí";
            this.Load += new System.EventHandler(this.frmMiendoituong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDoituong;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Panel pCT;
        private System.Windows.Forms.TextBox txtSotienmien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.TextBox txtSotien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butBoqua;
    }
}