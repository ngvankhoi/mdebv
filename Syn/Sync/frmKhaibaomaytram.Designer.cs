namespace Server
{
    partial class frmKhaibaomaytram
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
            DAL.Client client1 = new DAL.Client();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhaibaomaytram));
            this.btnLuu = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPathBN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butImageBN = new System.Windows.Forms.Button();
            this.cmbMayTram = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.txtPath_chungtu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butDirHinhCtu = new System.Windows.Forms.Button();
            this.clientUI1 = new UI.ClientUI();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(96, 307);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 26);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(400, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 13;
            this.button2.Text = "Kết thúc";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Thư mục lưu ảnh";
            // 
            // image
            // 
            this.image.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.image.Image = global::Server.Properties.Resources.openinnewwindow;
            this.image.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.image.Location = new System.Drawing.Point(125, 206);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(33, 23);
            this.image.TabIndex = 2;
            this.image.Text = "...";
            this.image.UseVisualStyleBackColor = true;
            this.image.Click += new System.EventHandler(this.image_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(158, 208);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(322, 20);
            this.txtPath.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Example: \\\\\\\\Server\\\\folder";
            // 
            // txtPathBN
            // 
            this.txtPathBN.Location = new System.Drawing.Point(158, 230);
            this.txtPathBN.Name = "txtPathBN";
            this.txtPathBN.Size = new System.Drawing.Size(322, 20);
            this.txtPathBN.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Thư mục lưu ảnh BN";
            // 
            // butImageBN
            // 
            this.butImageBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImageBN.Image = global::Server.Properties.Resources.openinnewwindow;
            this.butImageBN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImageBN.Location = new System.Drawing.Point(125, 228);
            this.butImageBN.Name = "butImageBN";
            this.butImageBN.Size = new System.Drawing.Size(33, 23);
            this.butImageBN.TabIndex = 4;
            this.butImageBN.Text = "...";
            this.butImageBN.UseVisualStyleBackColor = true;
            this.butImageBN.Click += new System.EventHandler(this.butImageBN_Click);
            // 
            // cmbMayTram
            // 
            this.cmbMayTram.FormattingEnabled = true;
            this.cmbMayTram.Location = new System.Drawing.Point(80, 6);
            this.cmbMayTram.Name = "cmbMayTram";
            this.cmbMayTram.Size = new System.Drawing.Size(404, 21);
            this.cmbMayTram.TabIndex = 0;
            this.cmbMayTram.SelectedIndexChanged += new System.EventHandler(this.cmbMayTram_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Máy Trạm :";
            // 
            // butMoi
            // 
            this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoi.Location = new System.Drawing.Point(20, 307);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(75, 26);
            this.butMoi.TabIndex = 8;
            this.butMoi.Text = "Mới";
            this.butMoi.UseVisualStyleBackColor = true;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.Location = new System.Drawing.Point(172, 307);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(75, 26);
            this.butSua.TabIndex = 10;
            this.butSua.Text = "Sửa";
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Location = new System.Drawing.Point(248, 307);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(75, 26);
            this.butBoqua.TabIndex = 11;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHuy.Location = new System.Drawing.Point(324, 307);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(75, 26);
            this.butHuy.TabIndex = 12;
            this.butHuy.Text = "Hủy";
            this.butHuy.UseVisualStyleBackColor = true;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // txtPath_chungtu
            // 
            this.txtPath_chungtu.Location = new System.Drawing.Point(158, 253);
            this.txtPath_chungtu.Name = "txtPath_chungtu";
            this.txtPath_chungtu.Size = new System.Drawing.Size(322, 20);
            this.txtPath_chungtu.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Thư mục ảnh Chứng từ";
            // 
            // butDirHinhCtu
            // 
            this.butDirHinhCtu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDirHinhCtu.Image = global::Server.Properties.Resources.openinnewwindow;
            this.butDirHinhCtu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDirHinhCtu.Location = new System.Drawing.Point(125, 251);
            this.butDirHinhCtu.Name = "butDirHinhCtu";
            this.butDirHinhCtu.Size = new System.Drawing.Size(33, 23);
            this.butDirHinhCtu.TabIndex = 6;
            this.butDirHinhCtu.Text = "...";
            this.butDirHinhCtu.UseVisualStyleBackColor = true;
            this.butDirHinhCtu.Click += new System.EventHandler(this.button1_Click);
            // 
            // clientUI1
            // 
            client1.DatabaseName = "medisoft_phuocan";
            client1.DbLink = "may114";
            client1.Host = "192.168.1.114";
            client1.ID = ((long)(-1));
            client1.ImagePath = null;
            client1.ImagePath_BN = null;
            client1.ImagePath_Chungtu = null;
            client1.Passworddb = "links1920";
            client1.Port = "5432";
            client1.ServerName = "may114";
            client1.STT = -5;
            client1.Thoigian = 5;
            client1.Userdb = "medisoft";
            this.clientUI1.Client = client1;
            this.clientUI1.Location = new System.Drawing.Point(80, 33);
            this.clientUI1.Name = "clientUI1";
            this.clientUI1.Size = new System.Drawing.Size(240, 179);
            this.clientUI1.TabIndex = 1;
            // 
            // frmKhaibaomaytram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 347);
            this.Controls.Add(this.txtPath_chungtu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butDirHinhCtu);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMayTram);
            this.Controls.Add(this.txtPathBN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butImageBN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.image);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.clientUI1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKhaibaomaytram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo máy trạm";
            this.Load += new System.EventHandler(this.frmKhaibaomaytram_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.ClientUI clientUI1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPathBN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butImageBN;
        private System.Windows.Forms.ComboBox cmbMayTram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butMoi;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butHuy;
        private System.Windows.Forms.TextBox txtPath_chungtu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butDirHinhCtu;
    }
}