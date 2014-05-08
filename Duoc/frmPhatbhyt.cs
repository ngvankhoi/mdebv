using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using System.IO;
using System.IO.Ports;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmDuyet.
	/// </summary>
	public class frmPhatbhyt : System.Windows.Forms.Form
	{
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
        private bool afterCurrentCellChanged, bSkip = false, bBhyt_20_vp_phat, bVantay = true, bDalanVantay = false, bPhaiThutienMoiHienDSchophatthuoc_d10=false;
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
        private TextBox txtSotoa;
        private Button cmdGoi;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private SerialPort comport = new SerialPort();
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton mnuTienIch;
        private ToolStripMenuItem chkXuatDanhSachChoRaLCD;
        private ToolStripMenuItem mnuThongSoLCD;
        bool _xuatbangdien = true;
		public frmPhatbhyt(AccessData acc,int nhom,string tu,string den,string mmyy,int madoituong,int loaiba,int userid,string kho,bool thuhoi)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_loaiba = loaiba; i_userid = userid;
            i_nhom = nhom; s_tu = tu; s_den = den; s_kho = kho;
			s_mmyy=mmyy;i_madoituong=madoituong;
			title=(s_tu==s_den)?" Ngày "+s_tu:" Từ ngày "+s_tu+" đến "+s_den;
			this.Text="Đơn thuốc bảo hiểm ("+title+")";
            butHuy.Enabled = thuhoi;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhatbhyt));
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
            this.txtSotoa = new System.Windows.Forms.TextBox();
            this.cmdGoi = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuTienIch = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkXuatDanhSachChoRaLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongSoLCD = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.dataGrid1.Size = new System.Drawing.Size(559, 478);
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
            this.tim.Location = new System.Drawing.Point(57, 493);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(649, 21);
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
            this.dataGrid2.Location = new System.Drawing.Point(570, 12);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(222, 478);
            this.dataGrid2.TabIndex = 7;
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(712, 494);
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
            this.groupBox1.Location = new System.Drawing.Point(57, 513);
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
            this.lbl.Location = new System.Drawing.Point(609, 517);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(183, 46);
            this.lbl.TabIndex = 10;
            this.lbl.Text = "label1";
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butRef.Image = global::Duoc.Properties.Resources.chonkhoa;
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(312, 528);
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
            this.butHuy.Location = new System.Drawing.Point(464, 528);
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
            this.butBoqua.Location = new System.Drawing.Point(533, 528);
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
            this.butLuu.Location = new System.Drawing.Point(395, 528);
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
            // txtSotoa
            // 
            this.txtSotoa.Location = new System.Drawing.Point(625, 552);
            this.txtSotoa.Name = "txtSotoa";
            this.txtSotoa.Size = new System.Drawing.Size(100, 20);
            this.txtSotoa.TabIndex = 261;
            // 
            // cmdGoi
            // 
            this.cmdGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdGoi.Location = new System.Drawing.Point(276, 528);
            this.cmdGoi.Name = "cmdGoi";
            this.cmdGoi.Size = new System.Drawing.Size(36, 26);
            this.cmdGoi.TabIndex = 262;
            this.cmdGoi.Text = "Gọi";
            this.cmdGoi.UseVisualStyleBackColor = true;
            this.cmdGoi.Click += new System.EventHandler(this.cmdGoi_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTienIch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 25);
            this.toolStrip1.TabIndex = 263;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuTienIch
            // 
            this.mnuTienIch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkXuatDanhSachChoRaLCD,
            this.mnuThongSoLCD});
            this.mnuTienIch.Image = ((System.Drawing.Image)(resources.GetObject("mnuTienIch.Image")));
            this.mnuTienIch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuTienIch.Name = "mnuTienIch";
            this.mnuTienIch.Size = new System.Drawing.Size(77, 22);
            this.mnuTienIch.Text = "Tiệc ích";
            // 
            // chkXuatDanhSachChoRaLCD
            // 
            this.chkXuatDanhSachChoRaLCD.CheckOnClick = true;
            this.chkXuatDanhSachChoRaLCD.Name = "chkXuatDanhSachChoRaLCD";
            this.chkXuatDanhSachChoRaLCD.Size = new System.Drawing.Size(216, 22);
            this.chkXuatDanhSachChoRaLCD.Text = "Xuất danh sách chờ ra LCD";
            // 
            // mnuThongSoLCD
            // 
            this.mnuThongSoLCD.Name = "mnuThongSoLCD";
            this.mnuThongSoLCD.Size = new System.Drawing.Size(216, 22);
            this.mnuThongSoLCD.Text = "Thông số LCD";
            this.mnuThongSoLCD.Click += new System.EventHandler(this.mnuThongSoLCD_Click);
            // 
            // frmPhatbhyt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmdGoi);
            this.Controls.Add(this.txtSotoa);
            this.Controls.Add(this.ptb);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 38);
            this.Name = "frmPhatbhyt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc bảo hiểm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhatbhyt_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPhatbhyt_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhatbhyt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPhatbhyt_Load(object sender, System.EventArgs e)
		{
            txtSotoa.Hide();
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
            chkAll.Visible = bBhyt_20_vp_phat && i_madoituong == 1;
            chkXuatDanhSachChoRaLCD.Checked = d.Thongso(chkXuatDanhSachChoRaLCD.Name) == "1";
            bPhaiThutienMoiHienDSchophatthuoc_d10 = d.bPhaiThutienMoiHienDSchophatthuoc_d10(i_nhom);
			load_grid();
            load_ct();
            AddGridTableStyle2();
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
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

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Phát";
			discontinuedCol.Width = 30;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

            FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "sotoa";
            TextCol.HeaderText = "STT Chờ";
            TextCol.Width = 50;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Khoa/phòng";
            TextCol.Width = 90;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width =60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 120;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 30;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "phai";
            TextCol.HeaderText = "Phái";
            TextCol.Width = 30;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "chandoan";
            TextCol.HeaderText = "Chẩn đoán";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "huy";
            discontinuedCol.HeaderText = "Hủy";
            discontinuedCol.Width = 30;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sobienlai";
			TextCol.HeaderText = "Biên lai";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "congkham";
			TextCol.HeaderText = "Công khám";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "thuoc";
			TextCol.HeaderText = "Thuốc";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "cls";
			TextCol.HeaderText = "Dịch vụ";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "bntra";
			TextCol.HeaderText = "BN Trả";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "bhyttra";
			TextCol.HeaderText = "BHYT Trả";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();//gam 16/03/2012
            TextCol.MappingName = "hotenuser";
            TextCol.HeaderText = "User";
            TextCol.Width = 65;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
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
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
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
            string sqlbn = "",dk="";
            
            sql = "select distinct a.id,a.sobienlai,d.tenkp,a.mabn,a.sothe,b.hoten,b.namsinh,";
			sql += " a.congkham,a.thuoc,a.cls,a.bntra,a.bhyttra,a.done,to_char(a.ngay,'dd/mm/yyyy') as ngay,";
            sql += "a.chandoan,a.maicd,case when e.phai=0 then 'Nam' else 'Nữ' end as phai,a.done";
            sql += ",k.hoten as hotenuser,a.sotoa ";//gam 16/03/2012
            dk += "from " + xxx + ".bhytkb a inner join " + xxx + ".bhytds b on a.mabn=b.mabn inner join " +
                 xxx + ".bhytthuoc c on a.id=c.id inner join medibv.btdkp_bv d on a.makp=d.makp inner join " +
                user + ".btdbn e on a.mabn=e.mabn left join " + user + ".d_phatthuoc f on a.id=f.id left join " +
                user + ".d_dlogin k on f.userid=k.id ";
            dk += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')"; //Khuong 15/11/2011
            dk += " and a.nhom=" + i_nhom;
            if (s_kho != "") dk += " and c.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            
            if (i_loaiba == 2) dk += " and a.loaiba=" + i_loaiba;
            else
            {
                dk += " and a.loaiba<>2";
                if (i_madoituong == 1) dk += " and a.maphu in(1,3)";//a.maphu=1
                else dk += " and a.maphu<>1";
            }
            if (bPhaiThutienMoiHienDSchophatthuoc_d10) dk += " and  a.sobienlai<>0 ";
            else if (bBhyt_20_vp_phat && i_madoituong == 1 && !chkAll.Checked)  dk += " and (a.bntra=0 or (a.bntra<>0 and a.sobienlai>0))";
            sql += dk;
            string str = sql;
            if (rb2.Checked) sql += " and a.done=1";
            else if (rb3.Checked) sql += " and a.done=0";
            sql += " order by a.sotoa,id";
			dt=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
			if (!bSkip) AddGridTableStyle();
			bSkip=true;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dt.Columns.Add("Chon",typeof(bool));
            dt.Columns.Add("Huy", typeof(bool));
            foreach (DataRow r in dt.Rows)
            {
                r["chon"] = (r["done"].ToString() == "1");
                r["huy"] = false;
            }
            DataTable tmp = d.get_data(str).Tables[0];
            int phat = tmp.Select("done=1").Length, chua = tmp.Select("done=0").Length;
            tmp = d.get_data("select distinct a.mabn,a.done " + dk).Tables[0];
            lbl.Text = "Số toa đã phát :" + phat.ToString().Trim() + " (" + tmp.Select("done=1").Length.ToString().Trim() + " BN)" + "\nSố toa chưa phát :" + chua.ToString().Trim() + " (" + tmp.Select("done=0").Length.ToString().Trim() + " BN)";
			butLuu.Enabled=dt.Rows.Count!=0 && rb1.Checked==false;
            dataGrid1.Focus();
            load_ct();
            if (chkXuatDanhSachChoRaLCD.Checked) { XuatLCD(); }
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
                foreach( DataRow r1 in dtct.Rows )
                {

                    d.upd_d_phatthuoc(decimal.Parse(r1["id"].ToString()), 7,
                                int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["sttt"].ToString()), decimal.Parse(r1["soluong"].ToString()),
                                r["mabn"].ToString(), d.ngayhienhanh_server.Substring(0, 10), i_userid);
                }
                if (bphat && idone == 1)
                {
                    d.execute_data("update " + xxx + ".bhytkb set done=" + idone + " where id=" + decimal.Parse(r["id"].ToString()));
                                   
                }
                else if (!bphat && idone == 0)
                {
                    d.execute_data("update " + xxx + ".bhytkb set done=" + idone + " where id=" + decimal.Parse(r["id"].ToString()));
                }
                
                if (bVantay && rb3.Checked) d.execute_data("update " + xxx + ".bhytkb set vantay=" + ((bDalanVantay) ? "1" : "0") + " where id=" + decimal.Parse(r["id"].ToString()));
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
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i, 17].ToString());
            }
            catch { l_id = 0; }
            //sql = "select trim(b.ten)||' '||trim(b.hamluong) as ten,b.dang,trunc(a.soluong,"+sole+") as soluong from "+xxx+".bhytthuoc a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + l_id;
            sql = "select a.id,a.stt,a.mabd,cast(0 as numeric) as sttt,trim(b.ten)||' '||trim(b.hamluong) as ten,b.dang,trunc(a.soluong," + sole + ") as soluong from " + xxx + ".bhytthuoc a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + l_id;
            sql += " order by a.stt";
            dtct = d.get_data(sql).Tables[0];
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

        private void mnuThongSoLCD_Click(object sender, EventArgs e)
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
                string s_select = "select a.sotoa as stt,b.hoten,to_char(f.ngayud,'dd/mm/yyyy') as yymmdd";
                string s_sql = " from " + xxx + ".bhytkb a inner join " + xxx + ".bhytds b on a.mabn=b.mabn inner join " + xxx +
                    ".bhytthuoc c on a.id=c.id inner join " + user + ".btdkp_bv d on a.makp=d.makp inner join " + user + ".btdbn e on a.mabn=e.mabn ";
                s_sql += " left join " + user + ".d_phatthuoc f on a.id=f.id left join " + user + ".d_dlogin g on f.userid=g.id where 0=0 ";
                if (s_kho.Trim(',') != "")
                {
                    s_sql = s_sql + " and c.makho in (" + s_kho.Trim(',') + ")";
                }
                //if (s_makp.Trim(',') != "")
                //{
                //    string s_temp = s_makp.Trim(',').Replace(",", "','");
                //    s_sql = s_sql + " and a.makp in ('" + s_temp + "')";
                //}
                s_sql = (s_sql + " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')") + " and a.nhom=" + i_nhom;
                if (i_loaiba == 2)
                {
                    s_sql = s_sql + " and a.loaiba=" + i_loaiba;
                }
                else
                {
                    //if (!bBhyt_ngtr)
                    //{
                    //    s_sql = s_sql + " and a.loaiba<>2";
                    //}
                    if (i_madoituong == 1)
                    {
                        s_sql = s_sql + " and a.maphu in(1,3)";//a.maphu=1";
                    }
                    else
                    {
                        s_sql = s_sql + " and a.maphu not in(1,3)";
                    }
                }
                if (bBhyt_20_vp_phat)
                {
                    s_sql = s_sql + " and (a.bntra=0 or (a.bntra<>0 and a.sobienlai>0))";
                }
                s_sql = s_sql + " and a.done=0";
                ds2 = d.get_data(s_select + " " + s_sql);
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

        private void frmPhatbhyt_FormClosing(object sender, FormClosingEventArgs e)
        {
            d.writeXml("d_thongso", chkXuatDanhSachChoRaLCD.Name, chkXuatDanhSachChoRaLCD.Checked ? "1" : "0");
        }
	}
}
