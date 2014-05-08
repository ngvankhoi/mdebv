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
	/// Summary description for frmRavien.
	/// </summary>
	public class frmRavien_ng : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
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
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtbd=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtvp=new DataTable();
		private DataTable dtmadt=new DataTable(); 
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private long l_maql,l_idkhoa;
		private int i_loaiba;
		private string s_makp,sql,s_ngayvao;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged,b_ndot,bChitiet;
		int checkCol=0;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.CheckedListBox madt;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox maphu;
		private System.Windows.Forms.TextBox mabn;
		private MaskedBox.MaskedBox ngayra;
		private System.Windows.Forms.CheckBox chkTH;
		private System.Windows.Forms.Label label1;
		private MaskedBox.MaskedBox ngayvao;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRavien_ng(LibMedi.AccessData acc,string makp,int loaiba)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRavien_ng));
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
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
			this.label9 = new System.Windows.Forms.Label();
			this.maphu = new System.Windows.Forms.ComboBox();
			this.mabn = new System.Windows.Forms.TextBox();
			this.ngayra = new MaskedBox.MaskedBox();
			this.chkTH = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ngayvao = new MaskedBox.MaskedBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(112, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 20;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(536, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 22;
			this.label3.Text = "Năm sinh :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(2, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Ngày vào :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(136, 29);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Ngày ra :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(288, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "Khoa :";
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
			this.dataGrid1.Location = new System.Drawing.Point(12, 64);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.Size = new System.Drawing.Size(768, 424);
			this.dataGrid1.TabIndex = 10;
			this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(176, 9);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(368, 21);
			this.hoten.TabIndex = 21;
			this.hoten.Text = "";
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(601, 9);
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
			this.tenkp.Location = new System.Drawing.Point(368, 31);
			this.tenkp.Name = "tenkp";
			this.tenkp.Size = new System.Drawing.Size(272, 21);
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
			this.makp.Location = new System.Drawing.Point(344, 31);
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
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(179, 52);
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
			this.maphu.ItemHeight = 13;
			this.maphu.Location = new System.Drawing.Point(256, 54);
			this.maphu.Name = "maphu";
			this.maphu.Size = new System.Drawing.Size(96, 21);
			this.maphu.TabIndex = 5;
			this.maphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphu_KeyDown);
			// 
			// mabn
			// 
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(65, 9);
			this.mabn.MaxLength = 8;
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(68, 21);
			this.mabn.TabIndex = 1;
			this.mabn.Text = "";
			this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
			this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
			// 
			// ngayra
			// 
			this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayra.Location = new System.Drawing.Point(224, 31);
			this.ngayra.Mask = "##/##/####";
			this.ngayra.Name = "ngayra";
			this.ngayra.Size = new System.Drawing.Size(68, 21);
			this.ngayra.TabIndex = 5;
			this.ngayra.Text = "  /  /    ";
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
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ngayvao
			// 
			this.ngayvao.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayvao.Location = new System.Drawing.Point(65, 32);
			this.ngayvao.Mask = "##/##/####";
			this.ngayvao.Name = "ngayvao";
			this.ngayvao.Size = new System.Drawing.Size(68, 21);
			this.ngayvao.TabIndex = 3;
			this.ngayvao.Text = "  /  /    ";
			this.ngayvao.Validated += new System.EventHandler(this.ngayvao_Validated);
			// 
			// frmRavien_ng
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ngayvao,
																		  this.chkTH,
																		  this.ngayra,
																		  this.mabn,
																		  this.maphu,
																		  this.label9,
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
																		  this.namsinh,
																		  this.hoten,
																		  this.label8,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.dataGrid1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmRavien_ng";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bảng thanh toán viện phí";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmRavien_ng_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmRavien_ng_Load(object sender, System.EventArgs e)
		{
			b_ndot=m.bThanhtoan_ndot;
			if (!b_ndot) s_makp="";
			bChitiet=m.bInthanhtoanchitiet;
			if (m.bBosolieuduoc) dtkp=m.get_data("select 0 id,makp,tenkp ten from btdkp_bv where loai=0").Tables[0];
			else dtkp=m.get_data("select * from d_duockp").Tables[0];
			if (bChitiet) sql="select a.id,a.ma,DECODE(A.TEN,A.TENHC,trim(a.ten),A.TENHC||' ('||A.TEN||')') ||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' ten,";
			else sql="select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' ten,";
			sql+="a.dang dvt,c.stt sttloai,c.ten loai,d.stt sttnhom,d.ten nhom"; 
			sql+=" from d_dmbd a,d_dmhang b,d_dmnhom c,v_nhomvp d";
			sql+=" where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma";
			dtbd=m.get_data(sql).Tables[0];
			sql="select a.id,a.ma,a.ten,a.dvt,b.stt sttloai,b.ten loai,c.stt sttnhom,c.ten nhom";
			sql+=" from v_giavp a,v_loaivp b,v_nhomvp c";
			sql+=" where a.id_loai=b.id and b.id_nhom=c.ma";
			dtvp=m.get_data(sql).Tables[0];
			dtmadt=m.get_data("select * from d_doituong order by madoituong").Tables[0];
			madt.DisplayMember="DOITUONG";
			madt.ValueMember="MADOITUONG";
			madt.DataSource=dtmadt;
			maphu.DisplayMember="TEN";
			maphu.ValueMember="ID";
			maphu.DataSource=m.get_data("select * from dmphu").Tables[0];

			dsngay.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
			ds.ReadXml("..\\..\\..\\xml\\m_ravien.xml");
			ds.Tables[0].Columns.Add("chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
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
			int i=0;string s_cont="",s_sothe="",s_denngay="",s_tenbv="";long o_maql;
			hoten.Text="";l_maql=0;l_idkhoa=0;dsngay.Clear();
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			if (b_ndot)
			{
				s_cont="a.id=b.id(+)";
				sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.maql,a.id,a.giuong,to_char(sysdate,'dd/mm/yyyy') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy'),to_char(b.ngay,'dd/mm/yyyy')) ngayra,a.makp,d.tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa,nvl(b.ketqua,0) as ketqua,nvl(b.ttlucrk,0) as ttlucrv,' ' as soluutru from nhapkhoa a,xuatkhoa b,btdbn c,btdkp_bv d,btdtt e,btdquan f,btdpxa g,benhandt h where "+s_cont+" and a.mabn=c.mabn and a.makp=d.makp and c.matt=e.matt(+) and c.maqu=f.maqu(+) and c.maphuongxa=g.maphuongxa(+) and a.maql=h.maql and a.mabn='"+mabn.Text+"' and h.loaiba="+i_loaiba;
				if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
				sql+=" order by a.id desc";
			}
			else
			{
				if (s_makp!="")
				{
					s_cont="a.id=b.id(+)";
					sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.maql,a.id,a.giuong,to_char(sysdate,'dd/mm/yyyy') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy'),to_char(b.ngay,'dd/mm/yyyy')) ngayra,a.makp,d.tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa,nvl(b.ketqua,0) as ketqua,nvl(b.ttlucrk,0) as ttlucrv,' ' as soluutru from nhapkhoa a,xuatkhoa b,btdbn c,btdkp_bv d,btdtt e,btdquan f,btdpxa g,benhandt h where "+s_cont+" and a.mabn=c.mabn and a.makp=d.makp and c.matt=e.matt(+) and c.maqu=f.maqu(+) and c.maphuongxa=g.maphuongxa(+) and a.maql=h.maql and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+") and a.mabn='"+mabn.Text+"' and h.loaiba="+i_loaiba+" order by a.id desc";
				}
				else
				{
					s_cont="a.maql=b.maql(+)";
					sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.maql,0 id,' ' giuong,to_char(sysdate,'dd/mm/yyyy') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy'),to_char(b.ngay,'dd/mm/yyyy')) ngayra,decode(b.makp,null,a.makp,b.makp) makp,decode(b.makp,null,h.tenkp,d.tenkp) tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa,nvl(b.ketqua,0) as ketqua,nvl(b.ttlucrv,0) as ttlucrv,b.soluutru from benhandt a,xuatvien b,btdbn c,btdkp_bv d,btdtt e,btdquan f,btdpxa g,btdkp_bv h where "+s_cont+" and a.mabn=c.mabn and b.makp=d.makp(+) and c.matt=e.matt(+) and c.maqu=f.maqu(+) and c.maphuongxa=g.maphuongxa(+) and a.makp=h.makp and a.mabn='"+mabn.Text+"' and a.loaiba="+i_loaiba+" order by a.maql desc";
				}
			}
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
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
				}
				o_maql=long.Parse(r["maql"].ToString());
				foreach(DataRow r1 in m.get_data("select a.sothe,to_char(a.denngay,'dd/mm/yyyy') denngay,b.tenbv from bhyt a,dmnoicapbhyt b where a.mabv=b.mabv and a.maql="+o_maql).Tables[0].Rows)
				{
					s_sothe=r1["sothe"].ToString();s_denngay=r1["denngay"].ToString();
					s_tenbv=r1["tenbv"].ToString();
					break;
				}
				m.updrec_ravien(dsngay,mabn.Text,o_maql,long.Parse(r["id"].ToString()),
					hoten.Text,r["namsinh"].ToString(),(r["phai"].ToString()=="0")?"Nam":"Nữ",r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+", "+r["tenpxa"].ToString().Trim()+", "+r["tenquan"].ToString().Trim()+", "+r["tentt"].ToString().Trim(),
					0,"",s_sothe,s_denngay,m.get_noigioithieu(o_maql),s_tenbv,r["giuong"].ToString(),
					r["makp"].ToString(),r["tenkp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),
					r["chandoan"].ToString(),r["maicd"].ToString(),m.get_nguoinha(m.mmyy(r["ngayvao"].ToString()),mabn.Text,o_maql),2,m.phuongphapdieutri(r["makp"].ToString()),m.ketquadieutri(int.Parse(r["ketqua"].ToString()),int.Parse(r["ttlucrv"].ToString())),r["soluutru"].ToString());

				i++;
			}
			if (l_maql==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
			ngayvao.Text=s_ngayvao;
			if (sothe.Text!="") maphu.SelectedIndex=d.get_maphu(l_maql);
			maphu.Enabled=sothe.Text!="";
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
			ngayra.Text=m.Ngaygio_hienhanh.Substring(0,10);
			tenkp.Text="";
			makp.Text="";
			sothe.Text="";
			diachi.Text="";
			l_maql=0;l_idkhoa=0;
			for(int i=0;i<madt.Items.Count;i++) madt.SetItemCheckState(i,CheckState.Unchecked);
			ena_but(true);
			mabn.Focus();
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
				DataRow dr;
				if (madt.CheckedItems.Count==0)
				{
					string s=m.get_doituong(mabn.Text,l_maql,l_idkhoa,ngayvao.Text,ngayra.Text,(s_makp!="")?makp.Text:"",dtkp,2,m.bCapcuu_noitru);
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
						dr["phai"]=dsngay.Tables[0].Rows[0]["phai"].ToString();
						dr["diachi"]=dsngay.Tables[0].Rows[0]["diachi"].ToString();
						dr["denngay"]=dsngay.Tables[0].Rows[0]["denngay"].ToString();
						dr["noigioithieu"]=dsngay.Tables[0].Rows[0]["noigioithieu"].ToString();
						dr["noicap"]=dsngay.Tables[0].Rows[0]["noicap"].ToString();
						dr["giuong"]=dsngay.Tables[0].Rows[0]["giuong"].ToString();
						dr["chandoan"]=dsngay.Tables[0].Rows[0]["chandoan"].ToString();
						dr["maicd"]=dsngay.Tables[0].Rows[0]["maicd"].ToString();
						dr["nguoinha"]=dsngay.Tables[0].Rows[0]["nguoinha"].ToString();
						dr["hinhthuc"]=dsngay.Tables[0].Rows[0]["hinhthuc"].ToString();
						dr["phuongphap"]=dsngay.Tables[0].Rows[0]["phuongphap"].ToString();
						dr["ketqua"]=dsngay.Tables[0].Rows[0]["ketqua"].ToString();
						dr["soluutru"]=dsngay.Tables[0].Rows[0]["soluutru"].ToString();
						dr["done"]=2;
						dr["chon"]=true;
						ds.Tables[0].Rows.Add(dr);
					}
					#endregion
				}
				d.upd_laitienthuoc(mabn.Text,l_maql,ngayvao.Text,ngayra.Text,true);
			}
			ena_but(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_rpt="rptTtravien.rpt",title="PHIẾU THANH TOÁN RA VIỆN";
			//if (bChitiet)
			//{
				s_rpt=(chkTH.Checked)?"rpt_ttravien_vp.rpt":"rpt_ttravien_ng.rpt";
				title=tenkp.Text;
				dsxml=m.get_ttravien_ct(dsxml,ds.Tables[0].Select("chon=true"),dtkp,dtbd,dtvp,(s_makp!="")?makp.Text:"",m.bCapcuu_noitru);
			//}
			//else dsxml=m.get_ttravien(dsxml,ds.Tables[0].Select("chon=true"),dtkp,dtbd,dtvp,s_makp);
			if (dsxml.Tables[0].Rows.Count>0)
			{
				frmReport f=new frmReport(m,dsxml,title,s_rpt,true);
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
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
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 200;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 40;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayvao";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayra";
			TextCol.HeaderText = "Ngày ra";
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
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
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

		private void maphu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (maphu.SelectedIndex==-1) maphu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
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
			if (!m.bNgay(ngayra.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayra.Focus();
				return;
			}
			ngayra.Text=m.Ktngaygio(ngayra.Text,10);
		}

		private void ngayvao_Validated(object sender, System.EventArgs e)
		{
			if (ngayvao.Text=="")
			{
				ngayvao.Focus();
				return;
			}
			ngayvao.Text=ngayvao.Text.Trim();
			if (!m.bNgay(ngayvao.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayvao.Focus();
				return;
			}
			ngayvao.Text=m.Ktngaygio(ngayvao.Text,10);
		}
	}
}
