using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Medisoft.Utilities; 

namespace XN
{
	public class frmMain : System.Windows.Forms.Form
	{
		//Lib_gpbl.Khaibao k =new Lib_gpbl.Khaibao();
        private gpblib.AccessData k = new gpblib.AccessData();
		private DateUtil du=new DateUtil();
		private DataSet ds=new DataSet();
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label lbNhapdulieu;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button buttonNhuomdacbiet;
		private System.Windows.Forms.Button buttonPhieuxetnghiem;
        private System.Windows.Forms.Button buttonBackup;
		private System.Windows.Forms.Button buttonBACSIDOC;
		private System.Windows.Forms.Button buttonTINHHINH;
		private System.Windows.Forms.Button buttonGPB;
		private System.Windows.Forms.Button buttonNHOMVTST;
		private System.Windows.Forms.Button buttonPHUONGPHAPNHUOM;
		private System.Windows.Forms.Button buttonSINHTHIETTUCTHI;
		private System.Windows.Forms.Label lbTUNGAY;
		private System.Windows.Forms.Label lBDENNGAY;
		private System.Windows.Forms.Button buttonGiaiphaubenh;
		private MaskedBox.MaskedBox den;
        private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.Button bntViettat;
		private System.Windows.Forms.Button bntKbLoaiVTST;
		private System.Windows.Forms.Button butHethong;
		private System.Windows.Forms.Label label2;
        private string user;
        private Button buttonVitrisinhthiet;
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			InitializeComponent();
			buttonPhieuxetnghiem.Focus();
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonPhieuxetnghiem = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bntKbLoaiVTST = new System.Windows.Forms.Button();
            this.bntViettat = new System.Windows.Forms.Button();
            this.butHethong = new System.Windows.Forms.Button();
            this.buttonGiaiphaubenh = new System.Windows.Forms.Button();
            this.buttonNhuomdacbiet = new System.Windows.Forms.Button();
            this.lbNhapdulieu = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.lBDENNGAY = new System.Windows.Forms.Label();
            this.lbTUNGAY = new System.Windows.Forms.Label();
            this.buttonNHOMVTST = new System.Windows.Forms.Button();
            this.buttonPHUONGPHAPNHUOM = new System.Windows.Forms.Button();
            this.buttonSINHTHIETTUCTHI = new System.Windows.Forms.Button();
            this.buttonGPB = new System.Windows.Forms.Button();
            this.buttonTINHHINH = new System.Windows.Forms.Button();
            this.buttonBACSIDOC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonVitrisinhthiet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 456);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(344, 56);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 208);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonBackup);
            this.tabPage1.Controls.Add(this.buttonPhieuxetnghiem);
            this.tabPage1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(368, 182);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "XÉT NGHIỆM";
            // 
            // buttonBackup
            // 
            this.buttonBackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackup.Location = new System.Drawing.Point(200, 37);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(144, 104);
            this.buttonBackup.TabIndex = 1;
            this.buttonBackup.Text = "Kết thúc";
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonPhieuxetnghiem
            // 
            this.buttonPhieuxetnghiem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonPhieuxetnghiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPhieuxetnghiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPhieuxetnghiem.Location = new System.Drawing.Point(24, 37);
            this.buttonPhieuxetnghiem.Name = "buttonPhieuxetnghiem";
            this.buttonPhieuxetnghiem.Size = new System.Drawing.Size(144, 104);
            this.buttonPhieuxetnghiem.TabIndex = 0;
            this.buttonPhieuxetnghiem.Text = "PHIẾU XÉT NGHIỆM";
            this.buttonPhieuxetnghiem.Click += new System.EventHandler(this.buttonPhieuxetnghiem_Click);
            this.buttonPhieuxetnghiem.Enter += new System.EventHandler(this.buttonPhieuxetnghiem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bntKbLoaiVTST);
            this.tabPage2.Controls.Add(this.bntViettat);
            this.tabPage2.Controls.Add(this.butHethong);
            this.tabPage2.Controls.Add(this.buttonGiaiphaubenh);
            this.tabPage2.Controls.Add(this.buttonNhuomdacbiet);
            this.tabPage2.Controls.Add(this.buttonVitrisinhthiet);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(368, 182);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HỆ THỐNG";
            // 
            // bntKbLoaiVTST
            // 
            this.bntKbLoaiVTST.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntKbLoaiVTST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntKbLoaiVTST.Location = new System.Drawing.Point(192, 96);
            this.bntKbLoaiVTST.Name = "bntKbLoaiVTST";
            this.bntKbLoaiVTST.Size = new System.Drawing.Size(152, 32);
            this.bntKbLoaiVTST.TabIndex = 7;
            this.bntKbLoaiVTST.Text = "LOẠI VỊ TRÍ SINH THIẾT";
            this.bntKbLoaiVTST.Click += new System.EventHandler(this.bntKbLoaiVTST_Click);
            // 
            // bntViettat
            // 
            this.bntViettat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntViettat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntViettat.Location = new System.Drawing.Point(24, 56);
            this.bntViettat.Name = "bntViettat";
            this.bntViettat.Size = new System.Drawing.Size(152, 32);
            this.bntViettat.TabIndex = 6;
            this.bntViettat.Text = "KHAI BÁO VIẾT TẮT";
            this.bntViettat.Click += new System.EventHandler(this.bntViettat_Click);
            // 
            // butHethong
            // 
            this.butHethong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butHethong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHethong.Location = new System.Drawing.Point(24, 96);
            this.butHethong.Name = "butHethong";
            this.butHethong.Size = new System.Drawing.Size(152, 32);
            this.butHethong.TabIndex = 5;
            this.butHethong.Text = "Khai báo hệ thống";
            this.butHethong.Click += new System.EventHandler(this.butHethong_Click);
            // 
            // buttonGiaiphaubenh
            // 
            this.buttonGiaiphaubenh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGiaiphaubenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGiaiphaubenh.Location = new System.Drawing.Point(192, 56);
            this.buttonGiaiphaubenh.Name = "buttonGiaiphaubenh";
            this.buttonGiaiphaubenh.Size = new System.Drawing.Size(152, 32);
            this.buttonGiaiphaubenh.TabIndex = 4;
            this.buttonGiaiphaubenh.Text = "GIẢI PHẪU BỆNH";
            this.buttonGiaiphaubenh.Click += new System.EventHandler(this.buttonGiaiphaubenh_Click);
            // 
            // buttonNhuomdacbiet
            // 
            this.buttonNhuomdacbiet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNhuomdacbiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNhuomdacbiet.Location = new System.Drawing.Point(192, 17);
            this.buttonNhuomdacbiet.Name = "buttonNhuomdacbiet";
            this.buttonNhuomdacbiet.Size = new System.Drawing.Size(152, 32);
            this.buttonNhuomdacbiet.TabIndex = 3;
            this.buttonNhuomdacbiet.Text = "NHUỘM ĐẶC BIỆT";
            this.buttonNhuomdacbiet.Click += new System.EventHandler(this.buttonNhuomdacbiet_Click);
            // 
            // lbNhapdulieu
            // 
            this.lbNhapdulieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNhapdulieu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbNhapdulieu.Location = new System.Drawing.Point(344, 32);
            this.lbNhapdulieu.Name = "lbNhapdulieu";
            this.lbNhapdulieu.Size = new System.Drawing.Size(120, 24);
            this.lbNhapdulieu.TabIndex = 3;
            this.lbNhapdulieu.Text = "NHẬP DỮ LIỆU";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.den);
            this.groupBox1.Controls.Add(this.tu);
            this.groupBox1.Controls.Add(this.lBDENNGAY);
            this.groupBox1.Controls.Add(this.lbTUNGAY);
            this.groupBox1.Controls.Add(this.buttonNHOMVTST);
            this.groupBox1.Controls.Add(this.buttonPHUONGPHAPNHUOM);
            this.groupBox1.Controls.Add(this.buttonSINHTHIETTUCTHI);
            this.groupBox1.Controls.Add(this.buttonGPB);
            this.groupBox1.Controls.Add(this.buttonTINHHINH);
            this.groupBox1.Controls.Add(this.buttonBACSIDOC);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(344, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 192);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // den
            // 
            this.den.BackColor = System.Drawing.SystemColors.HighlightText;
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(232, 24);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 13;
            this.den.Text = "12/12/2005";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(72, 24);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 12;
            this.tu.Text = "01/01/2004";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // lBDENNGAY
            // 
            this.lBDENNGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBDENNGAY.Location = new System.Drawing.Point(160, 29);
            this.lBDENNGAY.Name = "lBDENNGAY";
            this.lBDENNGAY.Size = new System.Drawing.Size(80, 16);
            this.lBDENNGAY.TabIndex = 11;
            this.lBDENNGAY.Text = "ĐẾN  NGÀY :";
            // 
            // lbTUNGAY
            // 
            this.lbTUNGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTUNGAY.Location = new System.Drawing.Point(16, 29);
            this.lbTUNGAY.Name = "lbTUNGAY";
            this.lbTUNGAY.Size = new System.Drawing.Size(64, 16);
            this.lbTUNGAY.TabIndex = 10;
            this.lbTUNGAY.Text = "TỪ NGÀY :";
            // 
            // buttonNHOMVTST
            // 
            this.buttonNHOMVTST.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNHOMVTST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNHOMVTST.Location = new System.Drawing.Point(192, 64);
            this.buttonNHOMVTST.Name = "buttonNHOMVTST";
            this.buttonNHOMVTST.Size = new System.Drawing.Size(168, 32);
            this.buttonNHOMVTST.TabIndex = 9;
            this.buttonNHOMVTST.Text = "NHÓM VTST";
            this.buttonNHOMVTST.Click += new System.EventHandler(this.buttonNHOMVTST_Click);
            // 
            // buttonPHUONGPHAPNHUOM
            // 
            this.buttonPHUONGPHAPNHUOM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPHUONGPHAPNHUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPHUONGPHAPNHUOM.Location = new System.Drawing.Point(192, 104);
            this.buttonPHUONGPHAPNHUOM.Name = "buttonPHUONGPHAPNHUOM";
            this.buttonPHUONGPHAPNHUOM.Size = new System.Drawing.Size(168, 32);
            this.buttonPHUONGPHAPNHUOM.TabIndex = 8;
            this.buttonPHUONGPHAPNHUOM.Text = "PHƯƠNG PHÁP NHUỘM ";
            this.buttonPHUONGPHAPNHUOM.Click += new System.EventHandler(this.buttonPHUONGPHAPNHUOM_Click);
            // 
            // buttonSINHTHIETTUCTHI
            // 
            this.buttonSINHTHIETTUCTHI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSINHTHIETTUCTHI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSINHTHIETTUCTHI.Location = new System.Drawing.Point(192, 144);
            this.buttonSINHTHIETTUCTHI.Name = "buttonSINHTHIETTUCTHI";
            this.buttonSINHTHIETTUCTHI.Size = new System.Drawing.Size(168, 32);
            this.buttonSINHTHIETTUCTHI.TabIndex = 7;
            this.buttonSINHTHIETTUCTHI.Text = "SINH THIẾT TỨC THÌ";
            this.buttonSINHTHIETTUCTHI.Click += new System.EventHandler(this.buttonSINHTHIETTUCTHI_Click);
            // 
            // buttonGPB
            // 
            this.buttonGPB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGPB.Location = new System.Drawing.Point(16, 64);
            this.buttonGPB.Name = "buttonGPB";
            this.buttonGPB.Size = new System.Drawing.Size(160, 32);
            this.buttonGPB.TabIndex = 6;
            this.buttonGPB.Text = "GIẢI PHẪU BỆNH";
            this.buttonGPB.Click += new System.EventHandler(this.buttonGPB_Click);
            // 
            // buttonTINHHINH
            // 
            this.buttonTINHHINH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTINHHINH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTINHHINH.Location = new System.Drawing.Point(16, 104);
            this.buttonTINHHINH.Name = "buttonTINHHINH";
            this.buttonTINHHINH.Size = new System.Drawing.Size(160, 32);
            this.buttonTINHHINH.TabIndex = 5;
            this.buttonTINHHINH.Text = "TÌNH HÌNH";
            this.buttonTINHHINH.Click += new System.EventHandler(this.buttonTINHHINH_Click);
            // 
            // buttonBACSIDOC
            // 
            this.buttonBACSIDOC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBACSIDOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBACSIDOC.Location = new System.Drawing.Point(16, 144);
            this.buttonBACSIDOC.Name = "buttonBACSIDOC";
            this.buttonBACSIDOC.Size = new System.Drawing.Size(160, 32);
            this.buttonBACSIDOC.TabIndex = 4;
            this.buttonBACSIDOC.Text = "BÁC SĨ ĐỌC";
            this.buttonBACSIDOC.Click += new System.EventHandler(this.buttonBACSIDOC_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(344, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "THỐNG KÊ ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(850, 650);
            this.label2.TabIndex = 7;
            // 
            // buttonVitrisinhthiet
            // 
            this.buttonVitrisinhthiet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVitrisinhthiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVitrisinhthiet.Location = new System.Drawing.Point(24, 17);
            this.buttonVitrisinhthiet.Name = "buttonVitrisinhthiet";
            this.buttonVitrisinhthiet.Size = new System.Drawing.Size(152, 32);
            this.buttonVitrisinhthiet.TabIndex = 2;
            this.buttonVitrisinhthiet.Text = "VỊ TRÍ SINH THIẾT";
            this.buttonVitrisinhthiet.Click += new System.EventHandler(this.buttonVitrisinhthiet_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(760, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbNhapdulieu);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giải phẫu bệnh";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        //[STAThread]
        //static void frmMain() 
        //{
        //    try
        //    {
        //        Application.Run(new frmMain());
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message,LibMedi.AccessData.Msg);
        //    }
        //}

		private void buttonBacsi_Click(object sender, System.EventArgs e)
		{
			//DMBACSI frmbacsi = new DMBACSI();		
			//frmbacsi.Show();
			MessageBox.Show ("Khai/Lấy bên medisoft!","Medisoft_This");
		}

		private void buttonKhoaphong_Click(object sender, System.EventArgs e)
		{
			//DMKHOAPHONG frmkhoaphong = new DMKHOAPHONG();
			//frmkhoaphong.Show();
			MessageBox.Show ("Lấy/Khai bên medisoft!","Medisoft_This");
		}

		private void buttonVitrisinhthiet_Click(object sender, System.EventArgs e)
		{
			DMVTST f =  new DMVTST();
			//frmvitrisinhthiet.MdiParent=this;
			f.ShowDialog();
		}

		private void buttonNhuomdacbiet_Click(object sender, System.EventArgs e)
		{
			DMPHUONGPHAPNHUOM f = new DMPHUONGPHAPNHUOM();
			f.ShowDialog();
		}

		private void buttonGiaiphaubenh_Click(object sender, System.EventArgs e)
		{
			DMGIAIPHAUBENH f = new DMGIAIPHAUBENH();
			f.ShowDialog();
		}		

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
            k.execute_data("delete  from " + user + ".GPB_XNHMMD1");
            k.execute_data("delete  from " + user + ".GPB_VTST1");
			Application.Exit();
		}

		public void Enable_buttonBacsi(bool ena)
		{				
		//	buttonBacsi.Enabled=ena;
		}

		private void buttonPhieuxetnghiem_Click(object sender, System.EventArgs e)
		{
			buttonPhieuxetnghiem.Enabled=false;
			frmGPB f = new frmGPB();
			f.ShowDialog();
			buttonPhieuxetnghiem.Enabled=true;
		}

		private void frmMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
		}

		private void buttonLoaiDV_Click(object sender, System.EventArgs e)
		{
			//DMLOAIDV frmLoaiDV = new DMLOAIDV();
			//frmLoaiDV.Show();
		}

		private void frmMain_Closed(object sender, System.EventArgs e)
		{
            k.execute_data("delete  from " + user + ".GPB_XNHMMD1");
            k.execute_data("delete  from " + user + ".GPB_VTST1");
		}
		private void buttonGPB_Click(object sender, System.EventArgs e)
		{
			frmTkgpb f= new frmTkgpb(tu.Text,den.Text);
			f.Show();
		}
		private void buttonNHOMVTST_Click(object sender, System.EventArgs e)
		{
			frmTkvtst f= new frmTkvtst(tu.Text,den.Text);
			f.ShowDialog();
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if(!du.isValidDate(tu.Text))
			{
				MessageBox.Show("Ngày không hợp lệ !",LibMedi.AccessData.Msg);
				tu.Focus();
			}		
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if(!du.isValidDate(den.Text))
			{
				MessageBox.Show("Ngày không hợp lệ !",LibMedi.AccessData.Msg);
				den.Focus();
			}		
		}
		private void buttonTINHHINH_Click(object sender, System.EventArgs e)
		{
			frmTktinhhinh f= new frmTktinhhinh(tu.Text,den.Text);
			f.ShowDialog();
		}
		private void buttonPHUONGPHAPNHUOM_Click(object sender, System.EventArgs e)
		{
			frmTknhuom f= new frmTknhuom(tu.Text,den.Text);
			f.ShowDialog();
		}
		private void buttonBACSIDOC_Click(object sender, System.EventArgs e)
		{
			frmTkbs f= new frmTkbs(tu.Text,den.Text);
			f.ShowDialog();
		}
		private void buttonSINHTHIETTUCTHI_Click(object sender, System.EventArgs e)
		{
			frmTksttt f= new frmTksttt(tu.Text,den.Text);
			f.ShowDialog();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			frmxemgiaiphaubenh frm = new  frmxemgiaiphaubenh("05000001");
			frm.ShowDialog();
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			if(Screen.PrimaryScreen.WorkingArea.Width<1024) this.WindowState=FormWindowState.Maximized;
            user = k.user;
			tu.Text=DateTime.Now.Day.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Month.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Year.ToString().PadLeft(4,'0');
			den.Text=DateTime.Now.Day.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Month.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Year.ToString().PadLeft(4,'0');
		}

		private void bntKbLoaiVTST_Click(object sender, System.EventArgs e)
		{
			frmDmloaiVTST f = new frmDmloaiVTST();
			f.ShowDialog();
		}

		private void bntViettat_Click(object sender, System.EventArgs e)
		{
			frmKhaibaoviettat f = new frmKhaibaoviettat();
			f.ShowDialog();
		}

		private void butHethong_Click(object sender, System.EventArgs e)
		{
			frmThongso f=new frmThongso();
			f.ShowDialog();
		}

		private void buttonBackup_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
