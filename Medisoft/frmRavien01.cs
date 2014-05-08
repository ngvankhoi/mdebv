using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien01.
	/// </summary>
	public class frmRavien01 : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butExit;
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataSet dsngay_tmp=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtbd=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtvp=new DataTable();
		private DataTable dtmadt=new DataTable(); 
		private DataTable dtngay=new DataTable();
		private DataSet dsdone=new DataSet();
		private DataSet dsdot=new DataSet();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private long l_maql,l_idkhoa;
		private int i_loaiba;
		private string s_makp,sql,s_ngayvao;
		private bool bVienphi_phongluu;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged,bChitiet;
		int checkCol=0;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.CheckedListBox madt;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox maphu;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox done;
		private MaskedBox.MaskedBox ngayra;
		private System.Windows.Forms.CheckBox chkTH;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Label l_tungay;
		private System.Windows.Forms.Label l_denngay;
		private System.Windows.Forms.DataGrid dataGrid2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRavien01(LibMedi.AccessData acc,string makp,int loaiba)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			s_makp=makp;i_loaiba=loaiba;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRavien01));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.l_tungay = new System.Windows.Forms.Label();
			this.l_denngay = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.mabn = new System.Windows.Forms.TextBox();
			this.hoten = new System.Windows.Forms.TextBox();
			this.namsinh = new System.Windows.Forms.TextBox();
			this.tenkp = new System.Windows.Forms.TextBox();
			this.diachi = new System.Windows.Forms.TextBox();
			this.sothe = new System.Windows.Forms.TextBox();
			this.butTiep = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.butIn = new System.Windows.Forms.Button();
			this.butExit = new System.Windows.Forms.Button();
			this.makp = new System.Windows.Forms.TextBox();
			this.madt = new System.Windows.Forms.CheckedListBox();
			this.ngayvao = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.maphu = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.done = new System.Windows.Forms.ComboBox();
			this.ngayra = new MaskedBox.MaskedBox();
			this.chkTH = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.loai = new System.Windows.Forms.ComboBox();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(328, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "&Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(424, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 20;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(536, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 22;
			this.label3.Text = "Năm sinh :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// l_tungay
			// 
			this.l_tungay.Location = new System.Drawing.Point(0, 29);
			this.l_tungay.Name = "l_tungay";
			this.l_tungay.Size = new System.Drawing.Size(64, 23);
			this.l_tungay.TabIndex = 2;
			this.l_tungay.Text = "Từ ngày :";
			this.l_tungay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// l_denngay
			// 
			this.l_denngay.Location = new System.Drawing.Point(181, 29);
			this.l_denngay.Name = "l_denngay";
			this.l_denngay.Size = new System.Drawing.Size(73, 23);
			this.l_denngay.TabIndex = 4;
			this.l_denngay.Text = "Đến ngày :";
			this.l_denngay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(377, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "Khoa xuất viện :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(-30, 52);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "Số thẻ :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(344, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 24;
			this.label8.Text = "Địa chỉ :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid1
			// 
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(408, 64);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.Size = new System.Drawing.Size(375, 424);
			this.dataGrid1.TabIndex = 10;
			this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// mabn
			// 
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(376, 9);
			this.mabn.MaxLength = 8;
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(68, 21);
			this.mabn.TabIndex = 2;
			this.mabn.Text = "";
			this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
			this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(488, 9);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(152, 21);
			this.hoten.TabIndex = 21;
			this.hoten.Text = "";
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(601, 88);
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(40, 21);
			this.namsinh.TabIndex = 23;
			this.namsinh.Text = "";
			// 
			// tenkp
			// 
			this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkp.Enabled = false;
			this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkp.Location = new System.Drawing.Point(488, 31);
			this.tenkp.Name = "tenkp";
			this.tenkp.Size = new System.Drawing.Size(152, 21);
			this.tenkp.TabIndex = 8;
			this.tenkp.Text = "";
			// 
			// diachi
			// 
			this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.diachi.Enabled = false;
			this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diachi.Location = new System.Drawing.Point(408, 54);
			this.diachi.Name = "diachi";
			this.diachi.Size = new System.Drawing.Size(232, 21);
			this.diachi.TabIndex = 25;
			this.diachi.Text = "";
			// 
			// sothe
			// 
			this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sothe.Enabled = false;
			this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sothe.Location = new System.Drawing.Point(65, 54);
			this.sothe.MaxLength = 20;
			this.sothe.Name = "sothe";
			this.sothe.Size = new System.Drawing.Size(111, 21);
			this.sothe.TabIndex = 11;
			this.sothe.Text = "";
			// 
			// butTiep
			// 
			this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butTiep.Image = ((System.Drawing.Bitmap)(resources.GetObject("butTiep.Image")));
			this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTiep.Location = new System.Drawing.Point(139, 493);
			this.butTiep.Name = "butTiep";
			this.butTiep.Size = new System.Drawing.Size(88, 28);
			this.butTiep.TabIndex = 8;
			this.butTiep.Text = "         &Tiếp";
			this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
			// 
			// butLuu
			// 
			this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(229, 493);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(88, 28);
			this.butLuu.TabIndex = 6;
			this.butLuu.Text = "          &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(319, 493);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(80, 28);
			this.butBoqua.TabIndex = 7;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butHuy
			// 
			this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(483, 493);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(80, 28);
			this.butHuy.TabIndex = 10;
			this.butHuy.Text = "          &Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butIn
			// 
			this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(401, 493);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(80, 28);
			this.butIn.TabIndex = 9;
			this.butIn.Text = "&In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butExit
			// 
			this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butExit.Image = ((System.Drawing.Bitmap)(resources.GetObject("butExit.Image")));
			this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butExit.Location = new System.Drawing.Point(565, 493);
			this.butExit.Name = "butExit";
			this.butExit.Size = new System.Drawing.Size(88, 28);
			this.butExit.TabIndex = 11;
			this.butExit.Text = "&Kết thúc";
			this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butExit.Click += new System.EventHandler(this.butExit_Click);
			// 
			// makp
			// 
			this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makp.Enabled = false;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(462, 31);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(24, 21);
			this.makp.TabIndex = 7;
			this.makp.Text = "";
			// 
			// madt
			// 
			this.madt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.madt.CheckOnClick = true;
			this.madt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madt.Location = new System.Drawing.Point(648, 8);
			this.madt.Name = "madt";
			this.madt.Size = new System.Drawing.Size(136, 68);
			this.madt.TabIndex = 90;
			this.madt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
			// 
			// ngayvao
			// 
			this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayvao.Location = new System.Drawing.Point(65, 31);
			this.ngayvao.Name = "ngayvao";
			this.ngayvao.Size = new System.Drawing.Size(112, 21);
			this.ngayvao.TabIndex = 4;
			this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
			this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(176, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(77, 23);
			this.label9.TabIndex = 4;
			this.label9.Text = "Mã phụ :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// maphu
			// 
			this.maphu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.maphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maphu.Location = new System.Drawing.Point(253, 54);
			this.maphu.Name = "maphu";
			this.maphu.Size = new System.Drawing.Size(96, 21);
			this.maphu.TabIndex = 6;
			this.maphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphu_KeyDown);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(-6, 8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 23);
			this.label10.TabIndex = 26;
			this.label10.Text = "Tình trạng :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// done
			// 
			this.done.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.done.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.done.Items.AddRange(new object[] {
													  "",
													  ""});
			this.done.Location = new System.Drawing.Point(65, 8);
			this.done.Name = "done";
			this.done.Size = new System.Drawing.Size(157, 21);
			this.done.TabIndex = 0;
			this.done.KeyDown += new System.Windows.Forms.KeyEventHandler(this.done_KeyDown);
			// 
			// ngayra
			// 
			this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayra.Location = new System.Drawing.Point(253, 31);
			this.ngayra.Mask = "##/##/#### ##:##";
			this.ngayra.Name = "ngayra";
			this.ngayra.Size = new System.Drawing.Size(123, 21);
			this.ngayra.TabIndex = 5;
			this.ngayra.Text = "";
			this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated);
			// 
			// chkTH
			// 
			this.chkTH.Location = new System.Drawing.Point(16, 496);
			this.chkTH.Name = "chkTH";
			this.chkTH.Size = new System.Drawing.Size(112, 24);
			this.chkTH.TabIndex = 27;
			this.chkTH.Text = "In tổng hợp";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(189, 8);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 23);
			this.label11.TabIndex = 91;
			this.label11.Text = "Loại :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// loai
			// 
			this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loai.Location = new System.Drawing.Point(253, 8);
			this.loai.Name = "loai";
			this.loai.Size = new System.Drawing.Size(79, 21);
			this.loai.TabIndex = 1;
			this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
			this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
			// 
			// dataGrid2
			// 
			this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.FlatMode = true;
			this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(16, 64);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.RowHeaderWidth = 10;
			this.dataGrid2.Size = new System.Drawing.Size(375, 424);
			this.dataGrid2.TabIndex = 92;
			this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
			// 
			// frmRavien01
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.loai,
																		  this.chkTH,
																		  this.ngayra,
																		  this.mabn,
																		  this.done,
																		  this.label10,
																		  this.maphu,
																		  this.label9,
																		  this.ngayvao,
																		  this.madt,
																		  this.makp,
																		  this.butExit,
																		  this.butIn,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butTiep,
																		  this.sothe,
																		  this.diachi,
																		  this.tenkp,
																		  this.hoten,
																		  this.label8,
																		  this.label7,
																		  this.label6,
																		  this.l_denngay,
																		  this.l_tungay,
																		  this.label2,
																		  this.label1,
																		  this.dataGrid1,
																		  this.label11,
																		  this.namsinh,
																		  this.label3,
																		  this.dataGrid2});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmRavien01";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Phiếu thanh toán viện phí";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmRavien01_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmRavien01_Load(object sender, System.EventArgs e)
		{
			bVienphi_phongluu=m.bCapcuu_noitru;
			s_makp="";
			bChitiet=m.bInthanhtoanchitiet;
			if (m.bBosolieuduoc) dtkp=m.get_data("select 0 id,makp,tenkp ten from btdkp_bv where loai=0").Tables[0];
			else dtkp=m.get_data("select * from d_duockp").Tables[0];
			if (bChitiet) sql="select a.id,a.ma,DECODE(A.TEN,A.TENHC,trim(a.ten),A.TENHC||' ('||A.TEN||')') ||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' ten,";
			else sql="select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' ten,";
			sql+="a.dang dvt,c.stt sttloai,c.ten loai,d.stt sttnhom,d.ten nhom,bhyt,e.stt sttnhombhyt,e.ten nhombhyt"; 
			sql+=" from d_dmbd a,d_dmhang b,d_dmnhom c,v_nhomvp d,v_nhombhyt e";
			sql+=" where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma and d.idnhombhyt=e.id ";
			dtbd=m.get_data(sql).Tables[0];
			sql="select a.id,a.ma,a.ten,a.dvt,b.stt sttloai,b.ten loai,c.stt sttnhom,c.ten nhom,a.chenhlech,a.gia_th,a.gia_bh,a.bhyt,d.stt sttnhombhyt,d.ten nhombhyt";
			sql+=" from v_giavp a,v_loaivp b,v_nhomvp c,v_nhombhyt d";
			sql+=" where a.id_loai=b.id and b.id_nhom=c.ma and c.idnhombhyt=d.id";
			dtvp=m.get_data(sql).Tables[0];
			dtmadt=m.get_data("select * from d_doituong order by madoituong").Tables[0];
			madt.DisplayMember="DOITUONG";
			madt.ValueMember="MADOITUONG";
			madt.DataSource=dtmadt;
			maphu.DisplayMember="TEN";
			maphu.ValueMember="ID";
			maphu.DataSource=m.get_data("select * from dmphu").Tables[0];

			dsdone.ReadXml("..\\..\\..\\xml\\m_ttrang.xml");
			done.DisplayMember="ten";
			done.ValueMember="ma";
			done.DataSource=dsdone.Tables[0];

			DataSet dsloaitt=new DataSet();
			dsloaitt.ReadXml("..\\..\\..\\xml\\m_loaitt.xml");
			loai.DisplayMember="ten";
			loai.ValueMember="ma";
			loai.DataSource=dsloaitt.Tables[0];

			dsngay.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			ngayvao.DataSource=dsngay.Tables[0];
			dsngay_tmp=dsngay.Clone();
			dsxml.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
			ds.ReadXml("..\\..\\..\\xml\\m_ravien.xml");
			ds.Tables[0].Columns.Add("chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
			dsdot.ReadXml("..\\..\\..\\xml\\m_dotvp.xml");
			dsdot.Tables[0].Columns.Add("datt",typeof(bool));
			dataGrid2.DataSource=dsdot.Tables[0];
			CurrencyManager cm2 = (CurrencyManager)BindingContext[dataGrid2.DataSource];
			DataView dv2 = (DataView) cm2.List; 
			dv2.AllowNew = false; 
			AddGridTableStyle1();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));//SystemColors.Info
			//this.disabledTextBrush = new SolidBrush(SystemColors.GrayText);
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			int i=0;string s_giuong,s_cont="",s_sothe="",s_denngay="",s_tenbv="";long o_maql;
			hoten.Text="";l_maql=0;l_idkhoa=0;dsngay.Clear();dsngay_tmp.Clear();
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			if (s_makp!="")
			{
				if (done.SelectedValue.ToString()=="2") s_cont="a.id=b.id(+)";
				else s_cont="a.id=b.id.";
				sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.maql,a.id,a.giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy hh24:mi'),to_char(b.ngay,'dd/mm/yyyy hh24:mi')) ngayra,a.makp,d.tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa,' ' soluutru from nhapkhoa a,xuatkhoa b,btdbn c,btdkp_bv d,btdtt e,btdquan f,btdpxa g,benhandt h where "+s_cont+" and a.mabn=c.mabn and a.makp=d.makp and c.matt=e.matt(+) and c.maqu=f.maqu(+) and c.maphuongxa=g.maphuongxa(+) and a.maql=h.maql and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+") and a.mabn='"+mabn.Text+"' and h.loaiba="+i_loaiba+" order by a.id desc";
			}
			else
			{
				if (done.SelectedValue.ToString()=="2") s_cont="a.maql=b.maql(+)";
				else s_cont="a.maql=b.maql";
				sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.maql,0 id,' ' giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy hh24:mi'),to_char(b.ngay,'dd/mm/yyyy hh24:mi')) ngayra,decode(b.makp,null,a.makp,b.makp) makp,decode(b.makp,null,h.tenkp,d.tenkp) tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa,b.soluutru from benhandt a,xuatvien b,btdbn c,btdkp_bv d,btdtt e,btdquan f,btdpxa g,btdkp_bv h where "+s_cont+" and a.mabn=c.mabn and b.makp=d.makp(+) and c.matt=e.matt(+) and c.maqu=f.maqu(+) and c.maphuongxa=g.maphuongxa(+) and a.makp=h.makp and a.mabn='"+mabn.Text+"' and a.loaiba="+i_loaiba+" order by a.maql desc";
			}
			dtngay=m.get_data(sql).Tables[0];
			if(dtngay.Rows.Count>0)	load_dotvp(dtngay.Rows[dtngay.Rows.Count-1]["ngayvao"].ToString(),dtngay.Rows[0]["ngayra"].ToString(),mabn.Text);
			foreach(DataRow r in dtngay.Rows)
			{
				if (i==0)
				{
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					s_ngayvao=r["ngayvao"].ToString();
					ngayra.Text=r["ngayra"].ToString();
					diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim();
					makp.Text=r["makp"].ToString();
					tenkp.Text=r["tenkp"].ToString();
					l_maql=long.Parse(r["maql"].ToString());
					l_idkhoa=long.Parse(r["id"].ToString());
					sothe.Text=m.get_sothe(l_maql).ToString();
					i++;
				}

				string s_tungay=check_dot(long.Parse(r["maql"].ToString()),r["makp"].ToString(), r["ngayvao"].ToString().Substring(0,10),r["ngayra"].ToString().Substring(0,10));
				if(s_tungay=="") continue;
				else if(s_tungay!=r["ngayvao"].ToString().Substring(0,10)) r["ngayvao"]=s_tungay+r["ngayvao"].ToString().Substring(10);

				o_maql=long.Parse(r["maql"].ToString());
				foreach(DataRow r1 in m.get_data("select a.sothe,to_char(a.denngay,'dd/mm/yyyy') denngay,b.tenbv from bhyt a,dmnoicapbhyt b where a.mabv=b.mabv and a.maql="+o_maql).Tables[0].Rows)
				{
					s_sothe=r1["sothe"].ToString();s_denngay=r1["denngay"].ToString();
					s_tenbv=r1["tenbv"].ToString();
					break;
				}
				s_giuong=r["giuong"].ToString().Trim();
				if (s_giuong=="") s_giuong=m.get_giuong(o_maql,r["makp"].ToString());
				m.updrec_ravien(dsngay,mabn.Text,o_maql,long.Parse(r["id"].ToString()),
					hoten.Text,r["namsinh"].ToString(),(r["phai"].ToString()=="0")?"Nam":"Nữ",r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+", "+r["tenpxa"].ToString().Trim()+", "+r["tenquan"].ToString().Trim()+", "+r["tentt"].ToString().Trim(),
					0,"",s_sothe,s_denngay,m.get_noigioithieu(o_maql),s_tenbv,s_giuong,r["makp"].ToString(),r["tenkp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),
					r["chandoan"].ToString(),r["maicd"].ToString(),m.get_nguoinha(m.mmyy(r["ngayvao"].ToString()),mabn.Text,o_maql),2,m.phuongphapdieutri(r["makp"].ToString()),m.ketquadieutri(int.Parse(r["ketqua"].ToString()),int.Parse(r["ttlucrv"].ToString())),r["soluutru"].ToString());

				i++;
			}
			if (dtngay.Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
			else if(ngayvao.Items.Count==0)
			{
				ena_but(false);
				dataGrid2.Focus();
			}
			else 
			{
				ngayvao.SelectedIndex=0;
				ngayvao.Focus();
			}
			if(dsdot.Tables[0].Rows.Count>0)dataGrid2_CurrentCellChanged(null,null);
			if (sothe.Text!="") maphu.SelectedIndex=d.get_maphu(l_maql);
			maphu.Enabled=sothe.Text!="";
		}
		private void kiemtradot()
		{
			string s_tungay="";
			DataRow r1;
			foreach(DataRow r in dsngay_tmp.Tables[0].Rows)
			{
				s_tungay=check_dot(long.Parse(r["maql"].ToString()),r["makp"].ToString(), r["ngayvao"].ToString().Substring(0,10),r["ngayra"].ToString().Substring(0,10));
				if(s_tungay=="") continue;
				else if(s_tungay.Substring(0,10)!=r["ngayvao"].ToString().Substring(0,10)) r["ngayvao"]=s_tungay;
				r1=dsngay.Tables[0].NewRow();
				foreach(DataColumn c in dsngay_tmp.Tables[0].Columns)
				{
					r1[c]=r[c];
				}
				dsngay.Tables[0].Rows.Add(r1);
			}
		}
		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_but(bool ena)
		{
			butTiep.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butExit.Enabled=!ena;
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			mabn.Text="";
			hoten.Text="";
			namsinh.Text="";
			ngayra.Text=m.Ngaygio_hienhanh;
			tenkp.Text="";
			makp.Text="";
			sothe.Text="";
			diachi.Text="";
			l_maql=0;l_idkhoa=0;
			for(int i=0;i<madt.Items.Count;i++) madt.SetItemCheckState(i,CheckState.Unchecked);
			dsdot.Tables[0].Clear();
			ena_but(true);
			done.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text!="")
			{
				if (m.getrowbyid(ds.Tables[0],"mabn='"+mabn.Text+"'")!=null)
				{
					butBoqua_Click(sender,e);
					return;
				}
				if (done.SelectedValue.ToString()=="0")
				{
					if (v.get_done_thvp(ngayra.Text.Substring(8,2),mabn.Text,l_maql,l_idkhoa,ngayvao.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+"\n"+ngayvao.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
						done.Focus();
						return;
					}
				}
				DataRow dr;
				if (madt.CheckedItems.Count==0)
				{
					string s=m.get_doituong(mabn.Text,l_maql,l_idkhoa,ngayvao.Text,ngayra.Text,(s_makp!="")?makp.Text:"",dtkp,int.Parse(done.SelectedValue.ToString()),bVienphi_phongluu);
					for(int i=0;i<madt.Items.Count;i++) 
						if (s.IndexOf(dtmadt.Rows[i]["madoituong"].ToString().Trim()+",")!=-1) madt.SetItemCheckState(i,CheckState.Checked);
				}
				for(int i=0;i<madt.Items.Count;i++)
				{
					#region updrec
					if (madt.GetItemChecked(i))
					{
						dr=ds.Tables[0].NewRow();
						dr["mabn"]=mabn.Text;
						dr["hoten"]=hoten.Text;
						dr["namsinh"]=namsinh.Text;
						dr["ngayvao"]=ngayvao.Text;
						dr["ngayra"]=ngayra.Text;
						dr["madoituong"]=dtmadt.Rows[i]["madoituong"].ToString();
						dr["doituong"]=dtmadt.Rows[i]["doituong"].ToString();
						dr["sothe"]=sothe.Text;
						dr["maphu"]=maphu.SelectedIndex;
						dr["makp"]=makp.Text;
						dr["tenkp"]=tenkp.Text;
						dr["maql"]=l_maql;
						dr["idkhoa"]=l_idkhoa;
						dr["phai"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["phai"].ToString();
						dr["diachi"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["diachi"].ToString();
						dr["denngay"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["denngay"].ToString();
						dr["noigioithieu"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["noigioithieu"].ToString();
						dr["noicap"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["noicap"].ToString();
						dr["giuong"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["giuong"].ToString();
						dr["chandoan"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["chandoan"].ToString();
						dr["maicd"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maicd"].ToString();
						dr["nguoinha"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["nguoinha"].ToString();
						dr["hinhthuc"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["hinhthuc"].ToString();
						dr["phuongphap"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["phuongphap"].ToString();
						dr["ketqua"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ketqua"].ToString();
						dr["soluutru"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["soluutru"].ToString();
						dr["done"]=done.SelectedValue.ToString();
						dr["chon"]=true;
						ds.Tables[0].Rows.Add(dr);
					}
					#endregion
				}
				long idthvp=v.get_id_thvp(ngayra.Text.Substring(8,2),mabn.Text,l_maql,l_idkhoa,ngayvao.Text);
				if(idthvp==0) idthvp=v.get_id_thvp();
				v.upd_thvpll(ngayra.Text.Substring(8,2),idthvp,mabn.Text,l_maql,l_idkhoa,ngayvao.Text,ngayra.Text,"",makp.Text,"","",0,0,0,0);
				load_dotvp(dsngay.Tables[0].Rows[dsngay.Tables[0].Rows.Count-1]["ngayvao"].ToString(),dsngay.Tables[0].Rows[0]["ngayra"].ToString(),mabn.Text);
				dataGrid2.CurrentCell=new DataGridCell(dsdot.Tables[0].Rows.Count-1,1);
//				d.upd_laitienthuoc(mabn.Text,l_maql,ngayvao.Text,ngayra.Text,true);
			}
			ena_but(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_rpt="rptTtravien.rpt",title=tenkp.Text;//title="PHIẾU THANH TOÁN RA VIỆN";
			if (bChitiet)
			{
				s_rpt=(chkTH.Checked)?"rpt_ttravien_vp.rpt":"rpt_ttravien_kp_bh.rpt";
				//dsxml=m.get_ttravien_ct_ndot(dsxml,ds.Tables[0].Select("chon=true"),dtkp,dtbd,dtvp,(s_makp!="")?makp.Text:"",bVienphi_phongluu);
			}
			//else 
				dsxml=m.get_ttravien_ct(dsxml,ds.Tables[0].Select("chon=true"),dtkp,dtbd,dtvp,s_makp,bVienphi_phongluu);
			if (dsxml.Tables[0].Rows.Count>0)
			{
				frmReport f=new frmReport(m,dsxml,i_loaiba==1?"NỘI TRÚ":"NGOẠI TRÚ",s_rpt,true);
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if(dataGrid2.CurrentRowIndex>=0)
			{
				if(s_makp!="")
				{
					if(!(s_makp.IndexOf(dataGrid2[dataGrid2.CurrentRowIndex,6].ToString())>=0)) 
						return;
				}
				if(!(bool)dataGrid2[dataGrid2.CurrentRowIndex,0])
				{
					if(MessageBox.Show(lan.Change_language_MessageText("Chắc chắn muốn xóa phiếu viện phí "+dataGrid2[dataGrid2.CurrentRowIndex,2].ToString()+" - "+dataGrid2[dataGrid2.CurrentRowIndex,3].ToString()+" !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
						del_thvp(long.Parse(dataGrid2[dataGrid2.CurrentRowIndex,5].ToString()),dataGrid2[dataGrid2.CurrentRowIndex,3].ToString().Substring(8,2));
				}
				else
					MessageBox.Show(lan.Change_language_MessageText("Đã thanh toán ,không thể hủy !"),LibMedi.AccessData.Msg);
				
				ds.Clear();
			}
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 35;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayvao";
			TextCol.HeaderText = "Từ ngày";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayra";
			TextCol.HeaderText = "Đến ngày";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsdot.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "datt";
			discontinuedCol.HeaderText = "Đã tt";
			discontinuedCol.Width = 35;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid2.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Tên khoa phòng";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tungay";
			TextCol.HeaderText = "Từ ngày";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "denngay";
			TextCol.HeaderText = "Đến ngày";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "maql";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			//7
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "idkhoa";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			//8
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
			//9
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "bhdenngay";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
			//10
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenbv";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
			//11
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "maphu";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}
	
		// Provides the format for the given cell.
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				//conditionally set properties in e depending upon e.Row and e.Col
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				//check is discontinued
				if(e.Column > 0 && !(bool)(this.dataGrid1[e.Row, 0]))//discontinued)
				{
					//				e.BackBrush = this.disabledBackBrush;
					e.ForeBrush = this.disabledTextBrush;
				}
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}
		private void SetCellFormat1(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				//conditionally set properties in e depending upon e.Row and e.Col
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid2[e.Row, 0] : e.CurrentCellValue);
				//check is discontinued
				if(e.Column>0 && (bool)(this.dataGrid2[e.Row, 0]))//discontinued)
				{
					//				e.BackBrush = this.disabledBackBrush;
					e.ForeBrush = this.disabledTextBrush;
				}
				else 
					if(e.Column > 0 && e.Row == this.dataGrid2.CurrentRowIndex)//discontinued)
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
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
				this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count 
				&& hti.Type == DataGrid.HitTestType.Cell 
				&&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
			afterCurrentCellChanged = false;
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao)
			{
				if (ngayvao.Items.Count>0)
				{
					if(!(ngayvao.SelectedIndex>=0)) return;
					ngayra.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
					sothe.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["sothe"].ToString();
					makp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
					tenkp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
					l_maql=long.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
					l_idkhoa=long.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["idkhoa"].ToString());
					if (sothe.Text!="") maphu.SelectedIndex=d.get_maphu(sothe.Text);
				}
			}
		}

		private void maphu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (maphu.SelectedIndex==-1) maphu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void done_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (done.SelectedIndex==-1) done.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void ngayra_Validated(object sender, System.EventArgs e)
		{
			if (ngayra.Text=="")
			{
				ngayra.Focus();
				return;
			}
			ngayra.Text=ngayra.Text.Trim();
			if (ngayra.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ !"),LibMedi.AccessData.Msg);
				ngayra.Focus();
				return;
			}
			if (!m.bNgay(ngayra.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayra.Focus();
				return;
			}
			ngayra.Text=m.Ktngaygio(ngayra.Text,16);
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(loai.SelectedIndex<0)loai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}
		private void load_dotvp(string tungay,string denngay,string mabn)
		{
			int t_yy=int.Parse(tungay.Substring(8,2));
			int d_yy=int.Parse(denngay.Substring(8,2));
			dsdot.Clear();
			dsdot.Dispose();
			dsdot=new DataSet();
			dsdot.ReadXml("..\\..\\..\\xml\\m_dotvp.xml");
			for(int i=t_yy;i<=d_yy;i++)
			{
				/*if(v.bYy(i.ToString().PadLeft(2,'0')))
				{
					if(i==t_yy)dsdot=m.get_data("select done,tenkp,to_char(ngayvao,'dd/mm/yyyy hh24:mi') tungay,to_char(ngayra,'dd/mm/yyyy hh24:mi') denngay,'' doituong,a.maql,a.id,a.makp,idkhoa,sothe,to_char(denngay,'dd/mm/yyyy') bhdenngay,tenbv,nvl(maphu,-1) maphu from v_thvpll a,"+m.user+".btdkp_bv b,"+m.user+".bhyt c,"+m.user+".dmnoicapbhyt d,"+m.user+".benhandt e where a.makp=b.makp and c.mabv=d.mabv(+) and a.mabn='"+mabn+"' and a.maql=c.maql(+) and a.maql=e.maql and e.loaiba="+i_loaiba+" order by a.ngayvao");
					else dsdot.Merge(m.get_data("select done,tenkp,to_char(ngayvao,'dd/mm/yyyy hh24:mi') tungay,to_char(ngayra,'dd/mm/yyyy hh24:mi') denngay,'' doituong,a.maql,a.id,a.makp,idkhoa,sothe,to_char(denngay,'dd/mm/yyyy') bhdenngay,tenbv,nvl(maphu,-1) maphu from v_thvpll a,"+m.user+".btdkp_bv b,"+m.user+".bhyt c,"+m.user+".dmnoicapbhyt d,"+m.user+".benhandt e where a.makp=b.makp and c.mabv=d.mabv(+) and a.mabn='"+mabn+"' and a.maql=c.maql(+) and a.maql=e.maql and e.loaiba="+i_loaiba+" order by a.ngayvao").Tables[0]);
				}*/
			}
			//dsdot.WriteXml("..\\..\\..\\xml\\m_dotvp.xml",XmlWriteMode.WriteSchema);
			dsdot.Tables[0].Columns.Add("datt",typeof(bool));
			foreach(DataRow r in dsdot.Tables[0].Rows) r["datt"]=r["done"].ToString()=="1"?true:false;
			dataGrid2.DataSource=dsdot.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource];
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
		}
		//return
		//"" : da ton tai
		//<>"" : tu ngay doi thanh gia tri nay
		//= tungay
		private string check_dot(long maql,string makp,string tungay,string denngay)
		{
			//da co
			if(dsdot.Tables[0].Select("tungay like '*"+tungay.Substring(0,10)+"*'").Length>0 && dsdot.Tables[0].Select("denngay like '*"+denngay.Substring(0,10)+"*'").Length>0) return "";
			foreach(DataRow r in dsdot.Tables[0].Rows)
			{
				//da thanh toan 1 dot trong lan nhap khoa nay,tungay se la ngay ke tiep cua den ngay cua dot thanh toan truoc
				if(tungay.Substring(0,10)==r["tungay"].ToString().Substring(0,10) && denngay.Substring(0,10)!=r["denngay"].ToString().Substring(0,10) && m.bNgay(denngay.Substring(0,10),r["denngay"].ToString().Substring(0,10)))
				{
					return m.DateToString("dd/MM/yyyy",m.StringToDate(r["denngay"].ToString().Substring(0,10)).AddDays(1));
				}
					//cung 1 khoa,2 dot thanh toan lien tiep se trùng 1 ngay,dot thanh toan sau tungay se la ngay ke tiep
				else if(maql==long.Parse(r["maql"].ToString())&& makp==r["makp"].ToString() && tungay.Substring(0,10)== r["denngay"].ToString().Substring(0,10))
				{
					return m.DateToString("dd/MM/yyyy",m.StringToDate(r["denngay"].ToString().Substring(0,10)).AddDays(1));
				}
				else if(tungay.Substring(0,10)==r["tungay"].ToString().Substring(0,10) && denngay.Substring(0,10)==r["denngay"].ToString().Substring(0,10))
				{
					return "";
				}
			}
			return tungay;
		}
		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataRow dr,dr1,dr2;
			if (madt.CheckedItems.Count==0)
			{
				madt.SetItemChecked(0,true);
				madt.SetItemChecked(1,true);
			}
			ds.Tables[0].Clear();
			dr1=m.getrowbyid(dtngay,"maql="+dataGrid2[dataGrid2.CurrentRowIndex,4].ToString()+" and makp='"+dataGrid2[dataGrid2.CurrentRowIndex,6].ToString()+"'");
			dr2=m.getrowbyid(dsngay_tmp.Tables[0],"maql="+dataGrid2[dataGrid2.CurrentRowIndex,4].ToString()+" and makp='"+dataGrid2[dataGrid2.CurrentRowIndex,6].ToString()+"' and ngayvao='"+dataGrid2[dataGrid2.CurrentRowIndex,2].ToString()+"'");

			for(int i=0;i<madt.Items.Count;i++)
			{
					#region updrec
				if (madt.GetItemChecked(i))
				{
					dr=ds.Tables[0].NewRow();
					dr["mabn"]=mabn.Text;
					dr["hoten"]=hoten.Text;
					dr["namsinh"]=namsinh.Text;
					dr["ngayvao"]=dataGrid2[dataGrid2.CurrentRowIndex,2].ToString();
					dr["ngayra"]=dataGrid2[dataGrid2.CurrentRowIndex,3].ToString();
					dr["madoituong"]=dtmadt.Rows[i]["madoituong"].ToString();
					dr["doituong"]=dtmadt.Rows[i]["doituong"].ToString();
					dr["sothe"]=dataGrid2[dataGrid2.CurrentRowIndex,8].ToString();
					dr["maphu"]=dataGrid2[dataGrid2.CurrentRowIndex,11].ToString();
					dr["makp"]=dataGrid2[dataGrid2.CurrentRowIndex,6].ToString();
					dr["tenkp"]=dataGrid2[dataGrid2.CurrentRowIndex,1].ToString();
					dr["maql"]=dataGrid2[dataGrid2.CurrentRowIndex,4].ToString();
					dr["idkhoa"]=dataGrid2[dataGrid2.CurrentRowIndex,7].ToString();
					dr["phai"]=dr1!=null?(dr1["phai"].ToString()=="0")?"Nam":"Nữ" :"";
					dr["diachi"]=dr1!=null? dr1["sonha"].ToString().Trim()+" "+dr1["thon"].ToString().Trim()+", "+dr1["tenpxa"].ToString().Trim()+", "+dr1["tenquan"].ToString().Trim()+", "+dr1["tentt"].ToString().Trim():"";
					dr["denngay"]=dataGrid2[dataGrid2.CurrentRowIndex,9].ToString();
//					dr["noigioithieu"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["noigioithieu"].ToString();
					dr["noicap"]=dataGrid2[dataGrid2.CurrentRowIndex,10].ToString();
//					dr["giuong"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["giuong"].ToString();
					dr["chandoan"]=dr1!=null?dr1["chandoan"].ToString():"";
					dr["maicd"]=dr1!=null?dr1["maicd"].ToString():"";
                    dr["nguoinha"] = m.get_nguoinha(m.mmyy(dataGrid2[dataGrid2.CurrentRowIndex, 2].ToString()), mabn.Text, long.Parse(dataGrid2[dataGrid2.CurrentRowIndex, 4].ToString()));
					dr["hinhthuc"]=2;
					dr["phuongphap"]=m.phuongphapdieutri(dataGrid2[dataGrid2.CurrentRowIndex,6].ToString());
					dr["ketqua"]=dr2!=null?dr2["ketqua"].ToString():"0";
					dr["soluutru"]=dr2!=null?dr2["soluutru"].ToString():"";
					dr["done"]=done.SelectedValue.ToString();
					dr["chon"]=true;
					ds.Tables[0].Rows.Add(dr);
				}
					#endregion
			}
		}

		private void del_thvp(long id,string yy)
		{
			m.execute_data("delete from v_thvpct where id="+id);
			m.execute_data("delete from v_thvpll where id="+id);
			m.delrec(dsdot.Tables[0],"id="+id);
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(loai.SelectedValue.ToString()=="1") ngayra.Enabled=false;
			else ngayra.Enabled=true;
		}
	}
}
