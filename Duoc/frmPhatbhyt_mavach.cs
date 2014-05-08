using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.IO.Ports;
using LibDuoc;

namespace Duoc
{
	public class frmPhatbhyt_mavach : System.Windows.Forms.Form
    {
        //linh
        DataTable dtton = new DataTable();
        bool b_ngoaitru = false;
        bool b_khongngoaitru = false;
        //end ;linh
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private FingerApp.FrmNhanDang fnhandang;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged, bSkip = false, bBhyt_20_vp_phat, bVantay = true, bDalanVantay = false;
		private int checkCol=0;
		private AccessData d;
		private int i_nhom,i_madoituong,i_loaiba,itable,i_userid,sole;
		private decimal l_id;
		private string user,sql,s_tu,s_den,s_mmyy,title,xxx,s_kho;
		private DataTable dt=new DataTable();
        private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butRef;
        private DataGrid dataGrid2;
        private DataTable dtct = new DataTable();
        private CheckBox chkAll;
        private GroupBox groupBox1;
        private RadioButton rb3;
        private RadioButton rb2;
        private RadioButton rb1;
        private Label lbl;
        private PictureBox ptb;
        private Label label1;
        private TextBox mavach_sttt;
        private Label lbltenthuoc;
        private Button butHoadon;
        private Button cmdGoi;
		private System.ComponentModel.Container components = null;
        #endregion
        private SerialPort comport = new SerialPort();
        private TextBox txtSotoa;
        private ToolStripMenuItem mnuThongSoLCD;
        private ToolStrip MnuToolStrip;
        private ToolStripDropDownButton MnuTienIch;
        private ToolStripMenuItem chkXuatLCD;
        private ToolStripMenuItem chkBangDien;
        bool _xuatbangdien = true;
        public frmPhatbhyt_mavach(AccessData acc,int nhom,string tu,string den,string mmyy,int madoituong,int loaiba,int userid,string kho,bool thuhoi)
		{
			InitializeComponent();
            d = acc; i_loaiba = loaiba; i_userid = userid;
            i_nhom = nhom; s_tu = tu; s_den = den; s_kho = kho;
			s_mmyy=mmyy;i_madoituong=madoituong;
			title=(s_tu==s_den)?" Ngày "+s_tu:" Từ ngày "+s_tu+" đến "+s_den;
			this.Text="Đơn thuốc bảo hiểm ("+title+")";
            butHuy.Enabled = thuhoi;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
					}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhatbhyt_mavach));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.lbl = new System.Windows.Forms.Label();
            this.butRef = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.ptb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mavach_sttt = new System.Windows.Forms.TextBox();
            this.lbltenthuoc = new System.Windows.Forms.Label();
            this.butHoadon = new System.Windows.Forms.Button();
            this.cmdGoi = new System.Windows.Forms.Button();
            this.txtSotoa = new System.Windows.Forms.TextBox();
            this.mnuThongSoLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuToolStrip = new System.Windows.Forms.ToolStrip();
            this.MnuTienIch = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkXuatLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.chkBangDien = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            this.MnuToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(5, 12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(486, 476);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(57, 496);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(434, 21);
            this.tim.TabIndex = 2;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(497, 12);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(295, 476);
            this.dataGrid2.TabIndex = 7;
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(714, 517);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(78, 17);
            this.chkAll.TabIndex = 8;
            this.chkAll.Text = "Hiện tất cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(57, 522);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 33);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Checked = true;
            this.rb3.Location = new System.Drawing.Point(133, 10);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(74, 17);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.Text = "Chưa phát";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(68, 10);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(63, 17);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Đã phát";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(6, 10);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 17);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "Tất cả";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(691, 529);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(144, 37);
            this.lbl.TabIndex = 10;
            this.lbl.Text = "label1";
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butRef.Image = global::Duoc.Properties.Resources.chonkhoa;
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(312, 529);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(84, 25);
            this.butRef.TabIndex = 4;
            this.butRef.Text = "&Danh sách";
            this.butRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(466, 529);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 5;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Image = global::Duoc.Properties.Resources.close_r;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(614, 529);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(396, 529);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // ptb
            // 
            this.ptb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ptb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ptb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb.ErrorImage = null;
            this.ptb.Location = new System.Drawing.Point(1, 494);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(55, 64);
            this.ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb.TabIndex = 260;
            this.ptb.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 261;
            this.label1.Text = "Mã vạch Sttt :";
            // 
            // mavach_sttt
            // 
            this.mavach_sttt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mavach_sttt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavach_sttt.ForeColor = System.Drawing.Color.Black;
            this.mavach_sttt.Location = new System.Drawing.Point(576, 496);
            this.mavach_sttt.Name = "mavach_sttt";
            this.mavach_sttt.Size = new System.Drawing.Size(216, 21);
            this.mavach_sttt.TabIndex = 262;
            this.mavach_sttt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mavach_sttt.TextChanged += new System.EventHandler(this.mavach_sttt_TextChanged);
            // 
            // lbltenthuoc
            // 
            this.lbltenthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltenthuoc.AutoSize = true;
            this.lbltenthuoc.ForeColor = System.Drawing.Color.Red;
            this.lbltenthuoc.Location = new System.Drawing.Point(579, 521);
            this.lbltenthuoc.Name = "lbltenthuoc";
            this.lbltenthuoc.Size = new System.Drawing.Size(0, 13);
            this.lbltenthuoc.TabIndex = 263;
            // 
            // butHoadon
            // 
            this.butHoadon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHoadon.Image = ((System.Drawing.Image)(resources.GetObject("butHoadon.Image")));
            this.butHoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHoadon.Location = new System.Drawing.Point(536, 529);
            this.butHoadon.Name = "butHoadon";
            this.butHoadon.Size = new System.Drawing.Size(78, 25);
            this.butHoadon.TabIndex = 264;
            this.butHoadon.Text = "       Hoá đơn";
            this.butHoadon.Click += new System.EventHandler(this.butHoadon_Click);
            // 
            // cmdGoi
            // 
            this.cmdGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdGoi.Location = new System.Drawing.Point(273, 528);
            this.cmdGoi.Name = "cmdGoi";
            this.cmdGoi.Size = new System.Drawing.Size(36, 26);
            this.cmdGoi.TabIndex = 265;
            this.cmdGoi.Text = "Gọi";
            this.cmdGoi.UseVisualStyleBackColor = true;
            this.cmdGoi.Click += new System.EventHandler(this.cmdGoi_Click);
            // 
            // txtSotoa
            // 
            this.txtSotoa.Location = new System.Drawing.Point(101, 555);
            this.txtSotoa.Name = "txtSotoa";
            this.txtSotoa.Size = new System.Drawing.Size(100, 20);
            this.txtSotoa.TabIndex = 266;
            // mnuThongSoLCD
            // 
            this.mnuThongSoLCD.Name = "mnuThongSoLCD";
            this.mnuThongSoLCD.Size = new System.Drawing.Size(216, 22);
            this.mnuThongSoLCD.Text = "Thông số LCD";
            // 
            // MnuToolStrip
            // 
            this.MnuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuTienIch});
            this.MnuToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MnuToolStrip.Name = "MnuToolStrip";
            this.MnuToolStrip.Size = new System.Drawing.Size(794, 25);
            this.MnuToolStrip.TabIndex = 267;
            this.MnuToolStrip.Text = "toolStrip1";
            // 
            // MnuTienIch
            // 
            this.MnuTienIch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkXuatLCD,
            this.chkBangDien});
            this.MnuTienIch.Image = ((System.Drawing.Image)(resources.GetObject("MnuTienIch.Image")));
            this.MnuTienIch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuTienIch.Name = "MnuTienIch";
            this.MnuTienIch.Size = new System.Drawing.Size(78, 22);
            this.MnuTienIch.Text = "Tiện ích";
            // 
            // chkXuatLCD
            // 
            this.chkXuatLCD.CheckOnClick = true;
            this.chkXuatLCD.Name = "chkXuatLCD";
            this.chkXuatLCD.Size = new System.Drawing.Size(216, 22);
            this.chkXuatLCD.Text = "Xuất danh sách chờ ra LCD";
            // 
            // chkBangDien
            // 
            this.chkBangDien.Name = "chkBangDien";
            this.chkBangDien.Size = new System.Drawing.Size(216, 22);
            this.chkBangDien.Text = "Thông số LCD";
            this.chkBangDien.Click += new System.EventHandler(this.chkBangDien_Click);
            // 
            // frmPhatbhyt_mavach
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.MnuToolStrip);
            this.Controls.Add(this.txtSotoa);
            this.Controls.Add(this.cmdGoi);
            this.Controls.Add(this.butHoadon);
            this.Controls.Add(this.lbltenthuoc);
            this.Controls.Add(this.mavach_sttt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptb);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.lbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 38);
            this.Name = "frmPhatbhyt_mavach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc bảo hiểm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhatbhyt_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPhatbhyt_mavach_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhatbhyt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            this.MnuToolStrip.ResumeLayout(false);
            this.MnuToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPhatbhyt_Load(object sender, System.EventArgs e)
		{
            user = d.user; xxx = user + s_mmyy;
            f_capnhat_db();
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);

			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
            sole = d.d_soluong_le(i_nhom);
            bBhyt_20_vp_phat = d.bBhyt_20_vp_phat(i_nhom);
            // hien sua 20-06-2011: yeu cau bv Thuan an: Neu D1(TSHT) check=true --> disable chkAll
            chkAll.Visible = !bBhyt_20_vp_phat && i_madoituong==1;
            // end hien
            chkXuatLCD.Checked = d.Thongso(chkXuatLCD.Name) == "1";
			load_grid();
            load_ct();
            AddGridTableStyle2();
            dtton = d.get_data("select mabd,id from " + xxx + ".d_theodoi").Tables[0];
            txtSotoa.Hide();
        }
        public delegate Color delegateGetColorRowCol(int row, int col);
        public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
        {
            private delegateGetColorRowCol _getColorRowCol;
            private int _column;
            public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
            {
                _getColorRowCol = getcolorRowCol;
                _column = column;
            }
            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
            {
                try
                {
                    foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
                    //backBrush = new SolidBrush(Color.GhostWhite);
                }
                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }

		private void AddGridTableStyle()
		{
            DataGridTableStyle ts = new DataGridTableStyle();
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			ts.MappingName = dt.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=3;
			ts.AllowSorting=false;

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();//0
            discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Phát";
			discontinuedCol.Width = 30;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);


            DataGridColoredTextBoxColumn TextCol;//1
            TextCol = new DataGridColoredTextBoxColumn(de, 1);
            TextCol.MappingName = "sotoa";
            TextCol.HeaderText = "STT";
            TextCol.Width = 90;
            TextCol.ReadOnly = true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//2
            TextCol = new DataGridColoredTextBoxColumn(de, 2);
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Khoa/phòng";
            TextCol.Width = 90;
            TextCol.ReadOnly = true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//3
            TextCol = new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width =60;
			TextCol.ReadOnly=true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//4
            TextCol = new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 120;
			TextCol.ReadOnly=true;
			//TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//5
            TextCol = new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			//TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);


            //TextCol=new FormattableTextBoxColumn();//6
            TextCol = new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 30;
			TextCol.ReadOnly=true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//7
            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "phai";
            TextCol.HeaderText = "Phái";
            TextCol.Width = 30;
            TextCol.ReadOnly = true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//8
            TextCol = new DataGridColoredTextBoxColumn(de, 8);
            TextCol.MappingName = "chandoan";
            TextCol.HeaderText = "Chẩn đoán";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);


            discontinuedCol = new FormattableBooleanColumn();//9
            discontinuedCol.MappingName = "huy";
            discontinuedCol.HeaderText = "Hủy";
            discontinuedCol.Width = 30;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);


            //TextCol = new FormattableTextBoxColumn();//10
            TextCol = new DataGridColoredTextBoxColumn(de,10);
			TextCol.MappingName = "sobienlai";
			TextCol.HeaderText = "Biên lai";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//11
            TextCol = new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "congkham";
			TextCol.HeaderText = "Công khám";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//12
            TextCol = new DataGridColoredTextBoxColumn(de, 12);
			TextCol.MappingName = "thuoc";
			TextCol.HeaderText = "Thuốc";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			

            //TextCol=new FormattableTextBoxColumn();
            //TextCol.MappingName = "cls";
            //TextCol.HeaderText = "Dịch vụ";
            //TextCol.Width = 65;
            //TextCol.ReadOnly=true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            //ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//13
            TextCol = new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "bntra";
			TextCol.HeaderText = "BN Trả";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//14
            TextCol = new DataGridColoredTextBoxColumn(de, 14);
			TextCol.MappingName = "bhyttra";
			TextCol.HeaderText = "BHYT Trả";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
            //TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//15
            TextCol = new DataGridColoredTextBoxColumn(de, 15);
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//16
            TextCol = new DataGridColoredTextBoxColumn(de, 16);
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//17
            TextCol = new DataGridColoredTextBoxColumn(de, 17);
            TextCol.MappingName = "maphu";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);


            //TextCol = new FormattableTextBoxColumn();//18
            TextCol = new DataGridColoredTextBoxColumn(de, 18);
            TextCol.MappingName = "done";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            //linh
            //TextCol = new FormattableTextBoxColumn();//19
            TextCol = new DataGridColoredTextBoxColumn(de, 19);
            TextCol.MappingName = "loaitoa";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);

            //TextCol = new FormattableTextBoxColumn();//20
            TextCol = new DataGridColoredTextBoxColumn(de, 20);
            TextCol.MappingName = "idttrv";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);

            //TextCol = new FormattableTextBoxColumn();//21
            TextCol = new DataGridColoredTextBoxColumn(de, 21);
            TextCol.MappingName = "quyenso";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);

            dataGrid1.TableStyles.Clear();//end linh
            dataGrid1.TableStyles.Add(ts);
        }

        public Color MyGetColorRowCol(int row, int col)
        {
            if (this.dataGrid1[row, 10].ToString().Trim() != "0" && this.dataGrid1[row, 21].ToString().Trim() != "0") return Color.Red;//|| this.dataGrid1[row, 20].ToString().Trim() != "0"
            else return Color.Black;
        }
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = this.disabledTextBrush;
                else if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 8])) e.ForeBrush = new SolidBrush(Color.FromArgb(0, 0,255));
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}

		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}


		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
            if (rb3.Checked)
            {
                if ((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
                afterCurrentCellChanged = true;
            }
            load_ct();
            try
            {
                txtSotoa.Text = dataGrid1[dataGrid1.CurrentCell.RowNumber, 1].ToString();
            }
            catch
            {
                txtSotoa.Text = "0";
            }

		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			try
			{
				Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
				DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
				BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
				if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
				{	
					this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
					RefreshRow(hti.Row);
				}
				afterCurrentCellChanged = false;
			}
			catch{}
		}

		private void load_grid()
		{
            string f_ngay = d.f_ngay, sqlbn = "",dk="",str="";
            if (b_khongngoaitru)
            {
                sql = "select distinct 0 as loaitoa,a.id,a.sobienlai,d.tenkp,a.mabn,a.sothe,b.hoten,b.namsinh,";
                sql += " a.congkham,a.thuoc,a.cls,a.bntra,a.bhyttra,a.done,to_char(a.ngay,'dd/mm/yyyy') as ngay,";
                sql += "a.chandoan,a.maicd,case when e.phai=0 then 'Nam' else 'Nữ' end as phai,a.maphu,a.idttrv,a.quyenso,a.sotoa ";
                dk = " from " + xxx + ".bhytkb a," + xxx + ".bhytds b," + xxx + ".bhytthuoc c," + user + ".btdkp_bv d," + user + ".btdbn e";
                dk += " where a.mabn=b.mabn and a.id=c.id and a.makp=d.makp and a.mabn=e.mabn";
                if (s_kho != "") dk += " and c.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                dk += " and a.ngay between to_date('" + s_tu + " 00:00','dd/MM/yyyy hh24:mi') and to_date('" + s_den + " 23:59','dd/MM/yyyy hh24:mi')";
                dk += " and a.nhom=" + i_nhom;
                if (i_loaiba == 2) dk += " and a.loaiba=" + i_loaiba;
                else
                {
                    dk += " and a.loaiba<>2";
                    if (i_madoituong == 1) dk += " and a.maphu=1";
                    else dk += " and a.maphu<>1";
                }
                if (bBhyt_20_vp_phat && i_madoituong == 1 && !chkAll.Checked) dk += " and (a.bntra=0 or (a.bntra<>0 and a.sobienlai>0))";
                sql += dk;
                str = sql;
                if (rb2.Checked) sql += " and a.done=1";//da phat
                else if (rb3.Checked) sql += " and a.done=0";//chua phat          
                //sql+=" order by id";
                //dt=d.get_data(sql).Tables[0];
                DataTable tmp = d.get_data(str).Tables[0];//Tu:21/07/2011
                DataTable tmp1 = d.get_data("select distinct a.mabn,a.done " + dk).Tables[0];//Tu:21/07/2011
            }
            if (b_ngoaitru)
            {
                //TU:03/07/2011 lấy từ d_ngtrull và d_ngtruct
                if (!b_khongngoaitru)
                {
                    sql = " ";
                }
                else
                {
                    sql += " union all ";
                }
                sql += " select distinct 1 as loaitoa, a.id,a.sobienlai,d.ten as tenkp,a.mabn,'' as sothe,a.hoten,a.namsinh,";
                sql += " cast(0 as numeric) as congkham,sum(b.soluong*b.giaban) as thuoc,cast(0 as numeric) as cls,sum(b.soluong*b.giaban) as bntra,cast(0 as numeric) as bhyttra,a.done,to_char(a.ngay,'dd/mm/yyyy') as ngay,";
                sql += "'' as chandoan,'' as maicd,case when e.phai=0 then 'Nam' else 'Nữ' end as phai,cast(0 as numeric) as maphu,b.idttrv,a.quyenso,a.sotoa ";
                dk = " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_duockp d," + user + ".btdbn e";
                dk += " where a.id=b.id and a.makp=d.id(+) and a.mabn=e.mabn(+)";
                if (s_kho != "") dk += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                dk += " and a.ngay between to_date('" + s_tu + " 00:00','dd/MM/yyyy hh24:mi') and to_date('" + s_den + " 23:59','dd/MM/yyyy hh24:mi')";
                dk += " and a.nhom=" + i_nhom;
                sql += dk;
                if (rb2.Checked) sql += " and a.done=1";//da phat
                else if (rb3.Checked) sql += " and a.done=0 ";// and b.idttrv<>0 ";//chua phat//
                sql += " group by a.id,d.ten,a.mabn,a.hoten,a.namsinh,a.done,to_char(a.ngay,'dd/mm/yyyy'),e.phai,b.idttrv,a.sobienlai,a.sotoa,a.quyenso ";
                sql += " order by a.sotoa ";
                //dt.Merge(d.get_data(sql).Tables[0]);
            }
            dt = d.get_data(sql).Tables[0];
            //end TU
            str = sql;
			dataGrid1.DataSource=dt;
            if (!bSkip)
            {
                AddGridTableStyle();
                bSkip = true;
            }
            if (rb3.Checked || d.bAdmin(i_userid))
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
                dt.Columns.Add("Chon", typeof(bool));
                dt.Columns.Add("Huy", typeof(bool));
                foreach (DataRow r in dt.Rows)
                {
                    r["chon"] = (r["done"].ToString() == "1");
                    r["huy"] = false;
                }
            }
            //tmp.Merge(d.get_data(str).Tables[0]);//Tu:21/07/2011
            int phat = dt.Select("done=1").Length, chua = dt.Select("done=0").Length;
            //tmp1.Merge(d.get_data("select distinct a.mabn,a.done " + dk).Tables[0]);//Tu:21/07/2011
            lbl.Text = "Số toa đã phát :" + phat.ToString().Trim() + " (" + dt.Select("done=1").Length.ToString().Trim() + " BN)" + "\nSố toa chưa phát :" + chua.ToString().Trim() + " (" + dt.Select("done=0").Length.ToString().Trim() + " BN)";
			butLuu.Enabled=dt.Rows.Count!=0 && rb1.Checked==false;
            dataGrid1.Focus();
            load_ct();
            if (chkXuatLCD.Checked) { XuatLCD(); }
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="";
			upd_data(rb3.Checked);
			load_grid();
            bDalanVantay = false;
			Cursor=Cursors.Default;
		}

		private void upd_data()
		{
			int idone;
			foreach(DataRow r in dt.Rows)
			{
				idone=(r["chon"].ToString()=="True")?1:0;
                d.execute_data("update " + xxx + ".bhytkb set done=" + idone + " where id=" + decimal.Parse(r["id"].ToString()));
			}
		}

        private void upd_data(bool bphat)
        {
            int idone;
            foreach (DataRow r in dt.Rows)
            {
                idone = (r["chon"].ToString() == "True") ? 1 : 0;
                if (bphat && idone == 1) 
                {
                    //linh
                    if (r["loaitoa"].ToString() == "0")
                    {
                        d.execute_data("update " + xxx + ".bhytkb set done=" + idone + " where id=" + decimal.Parse(r["id"].ToString()));
                    }
                    else
                    {
                        d.execute_data("update " + xxx + ".d_ngtrull set done=" + idone + " where id=" + decimal.Parse(r["id"].ToString()));
                    }
                    foreach (DataRow r1 in dtct.Select("id="+r["id"].ToString()))//.Rows)
                    {
                        d.execute_data("update " + xxx + ".bhytthuoc set mavach=" + r1["sttt"].ToString() + " where id=" + decimal.Parse(r1["id"].ToString()) + " and mabd=" + r1["mabd"].ToString() + " and stt=" + r1["stt"].ToString());
                        d.execute_data("update " + xxx + ".d_ngtruct set mavach=" + r1["sttt"].ToString() + " where id=" + decimal.Parse(r1["id"].ToString()) + " and mabd=" + r1["mabd"].ToString() + " and stt=" + r1["stt"].ToString());
                        d.upd_d_phatthuoc(decimal.Parse(r1["id"].ToString()), (r["maphu"].ToString() == "1") ? 5 : (r["maphu"].ToString() == "0") ? 7 : 6,
                            int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["sttt"].ToString()), decimal.Parse(r1["soluong"].ToString()),
                            r["mabn"].ToString(), d.ngayhienhanh_server.Substring(0, 10), i_userid);
                    }
                }
                else if (!bphat && idone == 0)
                {
                    if (r["loaitoa"].ToString() == "0")
                    {
                        d.execute_data("update " + xxx + ".bhytkb set done=" + idone + " where id=" + decimal.Parse(r["id"].ToString()));
                    }
                    else
                    {
                        d.execute_data("update " + xxx + ".d_ngtrull set done=" + idone + " where id=" + decimal.Parse(r["id"].ToString()));
                    }
                    foreach (DataRow r1 in dtct.Select("id=" + r["id"].ToString()))//.Rows)
                    {
                        d.execute_data("update " + xxx + ".bhytthuoc set mavach='' where id=" + decimal.Parse(r1["id"].ToString()) + " and mabd=" + r1["mabd"].ToString() + " and stt=" + r1["stt"].ToString());
                        d.execute_data("update " + xxx + ".d_ngtruct set mavach='' where id=" + decimal.Parse(r1["id"].ToString()) + " and mabd=" + r1["mabd"].ToString() + " and stt=" + r1["stt"].ToString());
                        d.execute_data("delete " + user + ".d_phatthuoc where id=" + r1["id"].ToString() + " and stt=" + r1["stt"].ToString());
                    }
                }
                if (bVantay && rb3.Checked) d.execute_data("update " + xxx + ".bhytkb set vantay=" + ((bDalanVantay) ? "1" : "0") + " where id=" + decimal.Parse(r["id"].ToString()));

                //if (bphat && idone == 1)//Tu
                //{
                //    d.execute_data("update " + xxx + ".d_ngtrull set done=" + idone + " where id=" + decimal.Parse(r["id"].ToString()));
                //    foreach(DataRow r1 in dtct.Rows)
                //    {
                //        d.upd_d_phatthuoc(decimal.Parse(r1["id"].ToString()), (r["maphu"].ToString() == "1") ? 5 : (r["maphu"].ToString() == "0") ? 7 : 6,
                //            int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["sttt"].ToString()), decimal.Parse(r1["soluong"].ToString()),
                //            r["mabn"].ToString(), d.ngayhienhanh_server.Substring(0, 10), i_userid);
                //    }
                //}//end Tu
                //end linh
            }
        }

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="hoten like '%"+tim.Text.Trim()+"%' or sothe like '%"+tim.Text.Trim()+"%' or mabn like '%"+tim.Text.Trim()+"%' or tenkp like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
			load_grid();
            //butLuu.Enabled = rb3.Checked;
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            if (d.bKhoaso(i_nhom, s_mmyy))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng") + " " + s_mmyy.Substring(0, 2) + " " + lan.Change_language_MessageText("năm") + " " + s_mmyy.Substring(2, 2) + " " + lan.Change_language_MessageText("đã khóa !") + "\n" + lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                return;
            }
 			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                dt.AcceptChanges();
                foreach (DataRow r in dt.Select("huy=true and chon=false and sobienlai=0"))
                {
                    l_id = decimal.Parse(r["id"].ToString());//dataGrid1[i, 13].ToString());
                    string mmyy = d.mmyy(r["ngay"].ToString());//dataGrid1[i, 14].ToString());
                    itable = d.tableid(s_mmyy, "bhytthuoc");
                    foreach (DataRow r1 in d.get_data("select a.*,a.soluong*t.giamua as sotien,t.manguon,t.nhomcc,t.handung,t.losx,t.giamua,t.giaban from " + xxx + ".bhytthuoc a," + xxx + ".d_theodoi t where a.sttt=t.id and a.id=" + l_id).Tables[0].Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytthuoc", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), 0, 0);
                    }
                    itable = d.tableid(s_mmyy, "bhytkb");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytkb", "id=" + l_id));                    
                    d.execute_data("delete from " + xxx + ".bhytthuoc where id=" + l_id);
                    sql = "select * from " + xxx + ".bhytcls where id=" + l_id;
                    if (d.get_data(sql).Tables[0].Rows.Count <= 0)
                    {
                        d.execute_data("delete from " + xxx + ".d_chandoan where loai=1 and id=" + l_id);
                        d.execute_data("delete from " + xxx + ".bhytkb where sobienlai=0 and id=" + l_id);
                    }
                    foreach (DataRow r1 in d.get_data("select * from " + user + mmyy + ".d_thuocbhytct where id=" + l_id).Tables[0].Rows)
                        d.upd_tonkhoth_dutru(d.dutru, i_nhom, s_mmyy, int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["slthuc"].ToString()));
                    d.execute_data("update " + user + mmyy + ".d_thuocbhytct set slthuc=0 where id=" + l_id);
                    d.execute_data("update " + user + mmyy + ".d_thuocbhytll set done=0 where id=" + l_id);
                }
                load_grid();
			}
		}

        private void load_ct()
        {
            dtct.Clear();
            int i_done=0;
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i, 15].ToString());
                i_done = int.Parse(dataGrid1[i, 18].ToString());
            }
            catch { l_id = 0; }
            if (i_done == 0)
            {
                sql = "select a.id,a.stt,a.mabd,cast(0 as numeric) as sttt,trim(b.ten)||' '||trim(b.hamluong) as ten,b.dang,trunc(a.soluong," + sole + ") as soluong from " + xxx + ".bhytthuoc a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + l_id;
                sql += " order by a.stt";
                dtct = d.get_data(sql).Tables[0];

                //Tu:03/07/2011
                sql = "select a.id,a.stt,a.mabd,cast(0 as numeric) as sttt,trim(b.ten)||' '||trim(b.hamluong) as ten,b.dang,trunc(a.soluong," + sole + ") as soluong from " + xxx + ".d_ngtruct a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + l_id;
                sql += " order by a.stt";
                dtct.Merge(d.get_data(sql).Tables[0]);
            }
            else
            {
                sql = "select a.id,a.stt,a.mabd,a.sttt_phat as sttt,trim(b.ten)||' '||trim(b.hamluong) as ten,b.dang,trunc(a.soluong," + sole + ") as soluong from " + user + ".d_phatthuoc a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + l_id;
                sql += " order by a.stt";
                dtct.Merge(d.get_data(sql).Tables[0]);
            }
            //end Tu
            dataGrid2.DataSource = dtct;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource, dataGrid2.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
        }

        private void AddGridTableStyle2()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtct.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Tên thuốc";
            TextCol.Width = 140;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dang";
            TextCol.HeaderText = "ĐVT";
            TextCol.Width = 30;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "soluong";
            TextCol.HeaderText = "SL";
            TextCol.Width = 30;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sttt";
            TextCol.HeaderText = "Mã vạch";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            this.tim.Text = "";
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkAll) load_grid();
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            butLuu.Enabled = !rb1.Checked;
        }

        private void frmPhatbhyt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    if (bVantay) lay_mabn_vantay();
                    break;
            }
        }

        private void lay_mabn_vantay()
        {
            string ma_vantay = "";
            string s_mabn = "";
            bDalanVantay = false;
            //if (fnhandang == null) 
            fnhandang = new FingerApp.FrmNhanDang(ptb);
            fnhandang.ShowDialog();
            ma_vantay = fnhandang.mabn;
            if (ma_vantay.Length == 8)
            {
                s_mabn = ma_vantay;
                tim.Text = s_mabn;
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or sothe like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%' or tenkp like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
                //
                bDalanVantay = true;
                int i_rec = dv.Table.Rows.Count;
                if (rb3.Checked)
                {
                    foreach (DataRow r in dt.Select("mabn='" + s_mabn + "'"))
                    {
                        r["chon"] = (r["done"].ToString() != "1");
                        r["huy"] = false;
                        i_rec += 1;
                    }
                }
                //if (i_rec == 1) butLuu_Click(null, null);
            }
            else
            {
                //khong tim thay mabn
            }
        }

        private void f_capnhat_db()
        {
            string asql = "select vantay from " + xxx + ".bhytkb where 1=2";
            DataSet lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + xxx + ".bhytkb add vantay numeric (1) default 0";
                d.execute_data(asql, false);
            }
        }

        private void mavach_sttt_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void mavach_sttt_TextChanged(object sender, EventArgs e)
        {
            bool bfound = false;
            if (mavach_sttt.Text.Length >= 18)
            {
                string s_sttt = mavach_sttt.Text;
                DataRow r = d.getrowbyid(dtton, "id=" + s_sttt);                
                if (r != null)
                {
                    bfound = true;
                    //if (r == null)
                    //{
                    //    MessageBox.Show(lan.Change_language_MessageText("Thuốc này không có!"));
                    //    mavach_sttt.Focus();
                    //    return;
                    //}
                    int i_mabd = int.Parse(r["mabd"].ToString());
                    foreach (DataRow r1 in dtct.Select("mabd=" + i_mabd.ToString()))
                    {
                        r1["sttt"] = mavach_sttt.Text.Trim();
                        lbltenthuoc.Text = r1["ten"].ToString();
                    }
                    dtct.AcceptChanges();
                }
            }
            if (bfound) mavach_sttt.Text = "";
        }
        //linh
        public bool PhatCaNgoaitru
        {
            set { b_ngoaitru = value; }
        }
        public bool PhatKhongNgoaiTru
        {
            set { b_khongngoaitru = value; }
        }

        private void butHoadon_Click(object sender, EventArgs e)
        {
            string sql = "", _ngaytoathuoc = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i, 14].ToString());
                decimal d_idttrv = decimal.Parse(dataGrid1[i, 19].ToString());
                _ngaytoathuoc = dataGrid1[i, 15].ToString();
                DateTime dt_tungay = d.StringToDate(_ngaytoathuoc);
                int i_songayphattoa = 2;
                DateTime dt_denngay = dt_tungay.AddDays(i_songayphattoa);
                string v_vienphi="";
                while (DateTime.Compare(dt_tungay, dt_denngay) < 0)
                {
                    string _mmyy = dt_tungay.ToString("MMyy");
                    if (d.bMmyy(_mmyy))
                    {
                        v_vienphi += v_vienphi == "" ? "" : " union all ";
                        v_vienphi += " select a1.mabn,a.quyenso,a.sobienlai,a.mien,a.bhyt as bhyttract,b.* from " + user + _mmyy + ".v_ttrvds a1," + user + _mmyy + ".v_ttrvll a," + user + _mmyy + ".v_ttrvct b where a1.id=a.id and a.id=b.id";// and a.id=" + d_idttrv.ToString();
                    }
                    dt_tungay = dt_tungay.AddMonths(1);
                }
                if (v_vienphi == "")
                {
                    return;
                }
                sql = "select b.mabn,d.hoten,e.sohieu,b.mavp as mabd,trim(c.ten) as ten,c.hamluong,c.dang as dvt,d.sonha||', '||d.thon||', '||g.tenpxa||', '||h.tenquan||', '||tentt as diachi,d.cholam,"+
                    "'' as tennhom,d.msthue, b.* from "+xxx+".bhytkb a,(" + v_vienphi + ") b," + user + ".d_dmbd c," + user + ".btdbn d, " + user + ".v_quyenso e, " +
                    user + ".btdpxa g, " + user + ".btdquan h, " + user + ".btdtt i " +
                    " where a.quyenso=b.quyenso and a.sobienlai=b.sobienlai and b.mavp=c.id and b.mabn=d.mabn and b.quyenso=e.id and d.matt=i.matt and d.maqu=h.maqu and  "+
                    "d.maphuongxa=g.maphuongxa and a.id=" + l_id.ToString();
                DataSet dstmp = new DataSet();
                dstmp = d.get_data(sql);
                if (dstmp.Tables[0].Rows.Count > 0)
                {
                    DataSet dsmavach = new DataSet();
                    dsmavach = d.get_data("select a.*,b.handung,b.losx from " + user + ".d_phatthuoc a,"+xxx+".d_theodoi b where a.sttt_phat=b.id and a.id=" + l_id.ToString());
                    foreach (DataRow rhd in dstmp.Tables[0].Rows)
                    {
                        string i_mabd = rhd["mabd"].ToString();
                        DataRow rmavach = d.getrowbyid(dsmavach.Tables[0], "mabd=" + i_mabd);
                        if (rmavach != null)
                        {
                            rhd["handung"] = rmavach["handung"].ToString();
                            rhd["losx"] = rmavach["losx"].ToString();
                        }
                    }
                    dstmp.WriteXml("..//..//dataxml//phatthuoc.xml", XmlWriteMode.WriteSchema);
                    frmReport f = new frmReport(d, dstmp,i_userid, "", "d_hoadonphatthuoc.rpt");
                    f.ShowDialog();
                }
                //sql += " union all ";
                //sql += "select a.id,a.stt,a.mabd,cast(0 as numeric) as sttt,trim(b.ten)||' '||trim(b.hamluong) as ten,b.dang,trunc(a.soluong," + sole + ") as soluong from " + xxx + ".d_ngtruct a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + l_id;
                //dtct.Merge(d.get_data(sql).Tables[0]);
                //sql = "select a.id,a.stt,a.mabd,a.sttt_phat as sttt,trim(b.ten)||' '||trim(b.hamluong) as ten,b.dang,trunc(a.soluong," + sole + ") as soluong from " + user + ".d_phatthuoc a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + l_id;
                //sql += " order by a.stt";
                //dtct.Merge(d.get_data(sql).Tables[0]);
            }
            catch { l_id = 0; }
        }
        void OpenPort()
        {
            //string m_parati = "None,Even,Odd";
            bool error = false;
            string setting = "", ports = "", _Parity = "";

            DataSet lds = new DataSet();
            lds.ReadXml(@"..\..\..\xml\cauhinh_com.xml", XmlReadMode.ReadSchema);

            ports = lds.Tables[0].Rows[0]["port"].ToString();

            setting = lds.Tables[0].Rows[0]["config"].ToString();
            string[] set = setting.Split(',');
            //ports = m_x.s_Port;
            switch (set[1].ToString())
            {
                case "n":
                    _Parity = "None";
                    break;
                case "e":
                    _Parity = "Even";
                    break;
                case "o":
                    _Parity = "Odd";
                    break;

            }

            if (comport.IsOpen) comport.Close();
            comport.BaudRate = int.Parse(set[0].ToString());
            comport.DataBits = int.Parse(set[2].ToString());
            comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), set[3].ToString());
            comport.Parity = (Parity)Enum.Parse(typeof(Parity), _Parity);
            comport.PortName = ports;

            try
            {
                // Open the port
                comport.Open();
            }
            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }
            if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }
        private void cmdGoi_Click(object sender, EventArgs e)
        {
            string input = "";
            if (txtSotoa.Text == "") return;
            input = "$" + txtSotoa.Text.PadLeft(4, '0') + "*";
            if (_xuatbangdien)
            {
                if (comport.IsOpen == false)
                    OpenPort();
            }
            if (comport.IsOpen)
                comport.Write(input);
        }

        private void chkBangDien_Click(object sender, EventArgs e)
        {
            frmthongsobangdien frmthongso = new frmthongsobangdien();
            frmthongso.ShowDialog();
        }
        frmbangdien frmlcd = null;
        void XuatLCD()
        {
            DataSet ds2 = new DataSet();
            if (rb3.Checked)
            {
                DataTable dttmp = new DataTable();
                dttmp = dt.Copy();
                dttmp.Columns.Add("yymmdd", typeof(string));
                dttmp.Columns.Add("stt", typeof(string));
                ds2.Tables.Add(dttmp.Clone());
                foreach (DataRow r in dttmp.Rows)
                {
                    string exp = "mabn='" + r["mabn"].ToString() + "'";
                    DataRow dr = d.getrowbyid(ds2.Tables[0], exp);
                    if (dr == null)
                    {
                        r["stt"] = r["sotoa"];
                        ds2.Tables[0].Rows.Add(r.ItemArray);
                        ds2.AcceptChanges();
                    }
                }
            }
            else
            {
                string f_ngay = d.f_ngay, sqlbn = "", dk = "", str = "";
                if (b_khongngoaitru)
                {
                    sql = "select a.sotoa as stt,b.hoten,to_char(a.ngayud,'dd/mm/yyyy') as yymmdd";
                    dk = " from " + xxx + ".bhytkb a," + xxx + ".bhytds b," + user + ".btdkp_bv d," + user + ".btdbn e";
                    dk += " where a.mabn=b.mabn and a.makp=d.makp and a.mabn=e.mabn";
                    //if (s_kho != "") dk += " and c.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                    dk += " and a.ngay between to_date('" + s_tu + " 00:00','dd/MM/yyyy hh24:mi') and to_date('" + s_den + " 23:59','dd/MM/yyyy hh24:mi')";
                    dk += " and a.nhom=" + i_nhom;
                    if (i_loaiba == 2) dk += " and a.loaiba=" + i_loaiba;
                    else
                    {
                        dk += " and a.loaiba<>2";
                        if (i_madoituong == 1) dk += " and a.maphu=1";
                        else dk += " and a.maphu<>1";
                    }
                    if (bBhyt_20_vp_phat && i_madoituong == 1 && !chkAll.Checked) dk += " and (a.bntra=0 or (a.bntra<>0 and a.sobienlai>0))";
                    sql += dk;
                    str = sql;
                    sql += " and a.done=0";//chua phat          
                    DataTable tmp = d.get_data(str).Tables[0];//Tu:21/07/2011
                    DataTable tmp1 = d.get_data("select distinct a.mabn,a.done " + dk).Tables[0];//Tu:21/07/2011
                }
                if (b_ngoaitru)
                {
                    //TU:03/07/2011 lấy từ d_ngtrull và d_ngtruct
                    if (!b_khongngoaitru)
                    {
                        sql = " ";
                    }
                    else
                    {
                        sql += " union all ";
                    }
                    sql += " select a.sotoa as stt,a.hoten,to_char(a.ngayud,'dd/mm/yyyy') as yymmdd";
                    dk = " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_duockp d," + user + ".btdbn e";
                    dk += " where a.id=b.id and a.makp=d.id(+) and a.mabn=e.mabn(+)";
                    if (s_kho != "") dk += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                    dk += " and a.ngay between to_date('" + s_tu + " 00:00','dd/MM/yyyy hh24:mi') and to_date('" + s_den + " 23:59','dd/MM/yyyy hh24:mi')";
                    dk += " and a.nhom=" + i_nhom;
                    sql += dk;
                    sql += " and a.done=0 and b.idttrv<>0 ";//chua phat//
                    sql += " group by a.id,d.ten,a.mabn,a.hoten,a.namsinh,a.done,to_char(a.ngay,'dd/mm/yyyy'),e.phai,b.idttrv,a.sobienlai,a.sotoa ";
                    sql += " order by a.sotoa ";
                    //dt.Merge(d.get_data(sql).Tables[0]);
                }
                ds2 = d.get_data(sql);
            }
            try
            {
                bool isloading = (d.Thongso("thongsobangdien", "isload").ToLower() == "true") ? true : false;
                if (!isloading || frmlcd == null)
                {
                    frmlcd = new frmbangdien(ds2, "", "");
                    frmlcd.Show();
                }
                else { frmlcd.refect(ds2, ""); }
            }
            catch (Exception ex) { string s = ex.ToString(); }
        }

        private void frmPhatbhyt_mavach_FormClosing(object sender, FormClosingEventArgs e)
        {
            d.writeXml("d_thongso", chkXuatLCD.Name, chkXuatLCD.Checked ? "1" : "0");
        }
	}
}
