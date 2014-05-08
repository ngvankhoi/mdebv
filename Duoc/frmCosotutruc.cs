using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmNhap.
	/// </summary>
	public class frmCosotutruc : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private LibList.List listDMBD;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox mabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private string s_mmyy,sql,user;
        private int i_nhom, i_mabd, i_makp, d_userid = 0;
		private decimal l_id;
		private decimal d_soluong;
		private AccessData d;
		private DataTable dtdmbd=new DataTable();
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Label ldvt;
		private DataRow r;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private System.Windows.Forms.Button butTim;
		private frmMain parent;
		private System.Windows.Forms.TextBox tenhang;
		private System.Windows.Forms.TextBox tennuoc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCosotutruc(AccessData acc,string mmyy,int makp,int nhom,string title, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_makp=makp;
			i_nhom=nhom;
			s_mmyy=mmyy;
			this.Text="Cơ số tủ trực "+title.Trim()+" tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
            d_userid = _userid;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCosotutruc));
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listDMBD = new LibList.List();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label13 = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butTim = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.stt = new System.Windows.Forms.TextBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.tenhang = new System.Windows.Forms.TextBox();
            this.tennuoc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(120, 475);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Hãng :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(457, 477);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Nước :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(376, 544);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 26;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            this.listDMBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDMBD_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 464);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(18, 452);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(112, 452);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(56, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(16, 475);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(34, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(656, 475);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(168, 452);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(272, 21);
            this.tenbd.TabIndex = 2;
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(50, 452);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(71, 21);
            this.mabd.TabIndex = 1;
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(50, 475);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(71, 21);
            this.dang.TabIndex = 4;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(714, 475);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(71, 21);
            this.soluong.TabIndex = 7;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(139, 506);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 14;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(209, 506);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 15;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(279, 506);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 12;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.Image = global::Duoc.Properties.Resources.search;
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(349, 506);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 16;
            this.butTim.Text = "    &Tìm";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(419, 506);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 13;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(489, 506);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 17;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(559, 506);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 18;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(629, 506);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 19;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(64, 352);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 20);
            this.stt.TabIndex = 60;
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(505, 452);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(280, 21);
            this.tenhc.TabIndex = 3;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(431, 451);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(74, 23);
            this.lTenhc.TabIndex = 64;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenhang
            // 
            this.tenhang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhang.Enabled = false;
            this.tenhang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhang.Location = new System.Drawing.Point(168, 475);
            this.tenhang.Name = "tenhang";
            this.tenhang.Size = new System.Drawing.Size(272, 21);
            this.tenhang.TabIndex = 65;
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.Enabled = false;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(505, 475);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(152, 21);
            this.tennuoc.TabIndex = 66;
            // 
            // frmCosotutruc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.tenhang);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.stt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCosotutruc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cơ số tủ trực";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCosotutruc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCosotutruc_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user;
			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="MA";
			load_dm();
			
			load_grid();
			AddGridTableStyle();
			ref_text(0);
		}

		private void load_grid()
		{
			sql="select a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as tenbd,b.tenhc,b.dang,a.soluong,c.ten as tenhang,d.ten as tennuoc ";
            sql += " from " + user + ".d_cosotutruc a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d ";
			sql+=" where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.mmyy='"+s_mmyy+"'"+" and a.makp="+i_makp+" and a.nhom="+i_nhom+" order by b.ten";
			dt=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="soluong>0";
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
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabd";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 35;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhang";
			TextCol.HeaderText = "Hãng";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennuoc";
			TextCol.HeaderText = "Nước";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width =60;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void ref_text(decimal id)
		{
			try
			{
				if (id==0)
				{
					int i=dataGrid1.CurrentCell.RowNumber;
					r=d.getrowbyid(dt,"mabd="+decimal.Parse(dataGrid1[i,0].ToString()));
				}
				else r=d.getrowbyid(dt,"mabd="+id);
				if (r!=null)
				{
					stt.Text=r["mabd"].ToString();
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["tenbd"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					tenhang.Text=r["tenhang"].ToString();
					tennuoc.Text=r["tennuoc"].ToString();
					d_soluong=(r["soluong"].ToString()!="")?decimal.Parse(r["soluong"].ToString()):0;
					soluong.Text=d_soluong.ToString("###,###,##0.00");
					l_id=decimal.Parse(stt.Text);
				}
			}
			catch{}
		}

		private void load_dm()
		{
            dtdmbd = d.get_data("select a.ma,trim(a.ten)||' '||hamluong as ten,a.tenhc,a.dang,a.id,b.ten as tenhang,c.ten as tennuoc from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnuoc c where a.mahang=b.id and a.manuoc=c.id and a.nhom=" + i_nhom + " order by a.ten").Tables[0];
			listDMBD.DataSource=dtdmbd;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBD.Visible) listDMBD.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				Filter_dmbd(tenbd.Text);
				listDMBD.BrowseToDmbd(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-32,mabd.Height+5);
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
			if (tenbd.Text!="" && mabd.Text=="")
			{
				r=d.getrowbyid(dtdmbd,"ten='"+tenbd.Text+"'");
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					dang.Text=r["dang"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					tenhang.Text=r["tenhang"].ToString();
					tennuoc.Text=r["tennuoc"].ToString();
				}
			}
		}

		private void ena_object(bool ena)
		{
			dataGrid1.Enabled=!ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butTim.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			if (d.bDanhmuc || d.bDmbd)
			{
				if (d.bDanhmuc) d.writeXml("d_thongso","c01","0");
				else d.writeXml("d_thongso","c02","0");
				load_dm();
			}
        }

		private void emp_detail()
		{
			l_id=0;
			mabd.Text="";
			tenbd.Text="";
			tenhc.Text="";
			dang.Text="";
			soluong.Text="";
			tenhang.Text="";
			tennuoc.Text="";
			stt.Text="0";
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_detail();
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			l_id=decimal.Parse(stt.Text);
			ena_object(true);
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private bool KiemtraDetail()
		{
			i_mabd=0;
			if (mabd.Text=="" && tenbd.Text=="")
			{
				mabd.Focus();
				return false;
			}
			if ((mabd.Text=="" && tenbd.Text!="") || (mabd.Text!="" && tenbd.Text==""))
			{
				if (mabd.Text=="")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				mabd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraDetail()) return;
			if (!d.upd_cosotutruc(i_nhom,s_mmyy,i_makp,i_mabd,d_soluong))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin cơ số tủ trực !"),d.Msg);
				return;
			}
			ena_object(false);
			load_grid();
			ref_text(0);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			butMoi.Focus();
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			if (mabd.Text!="")
			{
				r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
				if (r!=null) 
				{
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					tenhang.Text=r["tenhang"].ToString();
					tennuoc.Text=r["tennuoc"].ToString();
				}
			}
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			mabd_Validated(null,null);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text(0);
		}


		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString("#,###,##0.00");
			}
			catch{}
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dt.Rows.Count==0) return;
				if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    d.execute_data("delete from " + user + ".d_cosotutruc where mmyy='" + s_mmyy + "'" + " and nhom=" + i_nhom + " and mabd=" + l_id + " and makp=" + i_makp);
					load_grid();
					ref_text(0);
				}
			}
			catch{}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            frmReport f = new frmReport(d, d.get_data("select b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.soluong as tondau,0 as sttondau from " + user + ".d_cosotutruc a," + user + ".d_dmbd b where a.mabd=b.id and a.soluong<>0 and a.mmyy='" + s_mmyy + "'" + " and a.nhom=" + i_nhom + " and a.makp=" + i_makp + " order by b.ten").Tables[0],d_userid, "d_cosotutruc.rpt", this.Text.Trim().ToUpper(), "", "", "", "", "", "", "", "", "");
			f.ShowDialog();
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
			l_id=0;
			frmTimcosotutruc f=new frmTimcosotutruc(this);
			f.MdiParent=parent;
			f.RefreshText("");
			f.Show();
		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="(soluong>0) and (tenbd like '%"+text.Trim()+"%'"+" or tenhc like '%"+text.Trim()+"%')";
				if (text!="") ref_text(0);
				else ref_text(l_id);
			}
			catch{}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				Filter_mabd(mabd.Text);
				listDMBD.BrowseToDmbd(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-32,mabd.Height+5);
			}		
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ma like '%"+ma.Trim()+"%'";
			}
			catch{}
		}
	}
}
