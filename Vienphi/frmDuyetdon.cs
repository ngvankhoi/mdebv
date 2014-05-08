using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using System.IO;
using doiso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Vienphi
{
	/// <summary>
	/// Summary description for frmDuyet.
	/// </summary>
	public class frmDuyetdon : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont,alertFont2;
		private Brush alertTextBrush;
		private Font currentRowFont,currentRowFont2;
		private Brush currentRowBackBrush,RowBackBrushVP;
        private bool afterCurrentCellChanged, bSkip = false, bIncachdung, bGiaban_noi_ngoai, bKhoaso, bDaduyet = false;
		private int checkCol=0,i_userid,i_row,i_row_thuoc=0,songayduyet,i_loaiba;
		private LibDuoc.AccessData d;
        private LibMedi.AccessData m = new LibMedi.AccessData();
		private int i_nhom,i_loai,i_makho;
		private int i_soluong_le=0,i_dongia_le=0,i_thanhtien_le=0;
		private decimal l_id=0,l_maql=0;
		private string user,sql,s_kho,s_ngay,s_mmyy,s_mabn,s_makp,s_makho,s_manguon,s_userid,s_loai,hoten,s_tenkho,s_tenbs,s_chandoan,s_maicd,namsinh,ghichu,s_mabs="",s_tenkp="",stime,s_tu,s_den;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dttonct=new DataTable();
        private DataTable dtkp = new DataTable();
		private DataRow r2;
		public DataTable dtll=new DataTable();
		public bool bOk=false;
		public int sobienlai;
		private decimal d_tongcong;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.TextBox tim2;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
        private Doisototext doiso = new Doisototext();
        private System.Windows.Forms.Button butLuu;
        private Button butSum;
        private ToolTip toolTip1;
        private PictureBox pic;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private Bitmap map;
        private Button butIn;
        private CheckBox chkXml;
        private Button butAll;
        private CheckBox chkTumua;
        private Button butList;
        private Button button1;
        private Button btHuy38;
        private IContainer components;

		public frmDuyetdon(LibDuoc.AccessData acc,int nhom,string kho,string ngay,int userid,string mmyy,int loai,string makho,string manguon,string suserid,string sloai,string tenkho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;			
			i_nhom=nhom;i_loai=loai;
			i_userid=userid;s_userid=suserid;s_loai=sloai;
            s_kho = kho; i_makho = int.Parse(s_kho.Trim().Trim(','));
			s_makho=makho;s_manguon=manguon;s_tenkho=tenkho;
			s_ngay=ngay;
			s_mmyy=mmyy;
            
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
						RowBackBrushVP.Dispose();
						alertFont2.Dispose();
						currentRowFont2.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetdon));
            this.butBoqua = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.tim2 = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSum = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butAll = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.chkTumua = new System.Windows.Forms.CheckBox();
            this.butList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btHuy38 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(512, 464);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(75, 25);
            this.butBoqua.TabIndex = 7;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(9, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(275, 446);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(48, 433);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(214, 21);
            this.tim.TabIndex = 3;
            this.tim.Validated += new System.EventHandler(this.tim_Validated);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(-8, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Tìm kiếm";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(294, -16);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(496, 443);
            this.dataGrid2.TabIndex = 1;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            this.dataGrid2.Click += new System.EventHandler(this.dataGrid2_Click);
            // 
            // tim2
            // 
            this.tim2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim2.Location = new System.Drawing.Point(288, 433);
            this.tim2.Name = "tim2";
            this.tim2.Size = new System.Drawing.Size(496, 21);
            this.tim2.TabIndex = 4;
            this.tim2.TextChanged += new System.EventHandler(this.tim2_TextChanged);
            this.tim2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(183, 464);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(75, 25);
            this.butLuu.TabIndex = 5;
            this.butLuu.Text = "      Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSum
            // 
            this.butSum.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSum.Location = new System.Drawing.Point(209, 3);
            this.butSum.Name = "butSum";
            this.butSum.Size = new System.Drawing.Size(24, 21);
            this.butSum.TabIndex = 8;
            this.butSum.Text = "...";
            this.toolTip1.SetToolTip(this.butSum, "Tổng số tiền");
            this.butSum.Click += new System.EventHandler(this.butSum_Click);
            // 
            // butAll
            // 
            this.butAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAll.Location = new System.Drawing.Point(263, 433);
            this.butAll.Name = "butAll";
            this.butAll.Size = new System.Drawing.Size(24, 22);
            this.butAll.TabIndex = 260;
            this.butAll.Text = "...";
            this.toolTip1.SetToolTip(this.butAll, "Chọn tất cả");
            this.butAll.UseVisualStyleBackColor = true;
            this.butAll.Click += new System.EventHandler(this.butAll_Click);
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(48, 456);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(44, 38);
            this.pic.TabIndex = 257;
            this.pic.TabStop = false;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(579, 461);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(120, 25);
            this.butIn.TabIndex = 258;
            this.butIn.Text = "In đơn không mua";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.UseVisualStyleBackColor = true;
            this.butIn.Visible = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkXml
            // 
            this.chkXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(658, 477);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 259;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // chkTumua
            // 
            this.chkTumua.AutoSize = true;
            this.chkTumua.Location = new System.Drawing.Point(658, 459);
            this.chkTumua.Name = "chkTumua";
            this.chkTumua.Size = new System.Drawing.Size(133, 17);
            this.chkTumua.TabIndex = 261;
            this.chkTumua.Text = "In những thuốc tự mua";
            this.chkTumua.UseVisualStyleBackColor = true;
            this.chkTumua.Visible = false;
            // 
            // butList
            // 
            this.butList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butList.Image = ((System.Drawing.Image)(resources.GetObject("butList.Image")));
            this.butList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butList.Location = new System.Drawing.Point(258, 464);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(84, 25);
            this.butList.TabIndex = 262;
            this.butList.Text = "&Danh sách";
            this.butList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butList.Click += new System.EventHandler(this.butList_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(342, 464);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 25);
            this.button1.TabIndex = 263;
            this.button1.Text = "Đã d&uyệt";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btHuy38
            // 
            this.btHuy38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btHuy38.Enabled = false;
            this.btHuy38.Image = ((System.Drawing.Image)(resources.GetObject("btHuy38.Image")));
            this.btHuy38.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHuy38.Location = new System.Drawing.Point(426, 464);
            this.btHuy38.Name = "btHuy38";
            this.btHuy38.Size = new System.Drawing.Size(86, 25);
            this.btHuy38.TabIndex = 264;
            this.btHuy38.Text = "&Hủy";
            this.btHuy38.Click += new System.EventHandler(this.btHuy38_Click);
            // 
            // frmDuyetdon
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 498);
            this.Controls.Add(this.btHuy38);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.butList);
            this.Controls.Add(this.chkTumua);
            this.Controls.Add(this.butAll);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.butSum);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.tim2);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butBoqua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 38);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuyetdon";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDuyetdon_KeyDown);
            this.Load += new System.EventHandler(this.frmDuyetdon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDuyetdon_Load(object sender, System.EventArgs e)
		{
            user = d.user; songayduyet = d.songayduyet(i_nhom);
            s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
            s_den = s_ngay; stime = "'dd/mm/yyyy'";
            pic.Visible = m.bHinh;
            bKhoaso = d.bKhoaso(i_nhom, s_mmyy);
            sql = "select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
            sql += " and makp is not null";
            sql += " order by stt";
            dtkp = d.get_data(sql).Tables[0];
            bGiaban_noi_ngoai = d.bGiaban_noi_ngtru(i_nhom);
			bIncachdung=d.bIncachdung_xuatban(i_nhom);
			i_soluong_le=d.d_soluong_le(i_nhom);
			i_dongia_le=d.d_dongia_le(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			this.alertFont2 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Bold);
			this.currentRowFont2 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Regular);

			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			this.RowBackBrushVP = new SolidBrush(Color.Blue);
            dtton = d.get_tonkhoth_xuatban(s_mmyy, s_makho, s_kho, s_manguon);//binh 010611 //dtton=d.get_tonkhoth(s_mmyy,s_makho,s_kho,s_manguon);//
			ds.ReadXml("..\\..\\..\\xml\\d_duyetdon.xml");
			dataGrid2.DataSource=ds.Tables[0];
			AddGridTableStyle2();
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
            ds.Tables[0].Columns.Add("No", typeof(bool));
            ds.Tables[0].Columns.Add("madoituong", typeof(decimal));
            ds.Tables[0].Columns.Add("loaiba", typeof(decimal));
            ds.Tables[0].Columns.Add("cachdung");
			load_grid();
		}

		private void AddGridTableStyle2()
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
			ts.RowHeaderWidth=3;
			ts.AllowSorting=false;

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Bỏ";
			discontinuedCol.Width = 20;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged2);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid2.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width =0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width =50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên thuốc";
			TextCol.Width =170;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width =35;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "SL";
			TextCol.Width = 40;
			TextCol.ReadOnly=false;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = "Đơn gía";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sotienban";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
            TextCol.Format = "### ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
			//TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

            discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "no";
            discontinuedCol.HeaderText = "Nợ";
            discontinuedCol.Width = 30;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat3);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged3);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "loaiba";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
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
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 30;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width =60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
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

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "maicd";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "sotien";
            TextCol.HeaderText = "Số tiền";
            TextCol.Width = 50;
            TextCol.Format = "### ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "mabs";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "loaiba";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "songay";
            TextCol.HeaderText = "Số";
            TextCol.Width = 30;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
                if (dataGrid1[e.Row, 11].ToString() == "1") e.ForeBrush = new SolidBrush(Color.Blue);
                else e.ForeBrush = new SolidBrush(Color.Black);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
					e.ForeBrush = this.disabledTextBrush;
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

        private void SetCellFormat3(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                e.BackBrush = new SolidBrush(Color.LightGray);
            }
            catch { }
        }

		private void SetCellFormat2(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid2[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid2[e.Row, 0])) e.ForeBrush = this.disabledTextBrush;
				else if (e.Column>0 && this.dataGrid2[e.Row,4].ToString()=="0") e.ForeBrush=this.RowBackBrushVP;
				else if(e.Column > 0 && e.Row == this.dataGrid2.CurrentRowIndex)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont2;
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


		private void BoolValueChanged2(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid2.EndEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow2(e.Row);
			this.dataGrid2.BeginEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
            if (dataGrid2[e.Row, 0].ToString().ToLower()=="true" && dataGrid2[e.Row, 9].ToString().ToLower()=="true") dataGrid2[e.Row, 9] = false;
		}

        private void BoolValueChanged3(object sender, BoolValueChangedEventArgs e)
        {
            if (dataGrid2[e.Row, 10].ToString() != "1")
            {
                dataGrid2[e.Row, 9] = false;
                return;
            }
            else
            {
                this.dataGrid2.EndEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
                RefreshRow2(e.Row);
                this.dataGrid2.BeginEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
            }
        }

		private void RefreshRow2(int row)
		{
			Rectangle rect = this.dataGrid2.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid2.Width, rect.Height);
			this.dataGrid2.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
			i_row=dataGrid1.CurrentRowIndex;
            if (pic.Visible)
            {
                try
                {
                    string mabn = dataGrid1[dataGrid1.CurrentCell.RowNumber, 1].ToString();
                    foreach (DataRow r in d.get_data("select * from " + d.user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows)
                    {
                        try
                        {
                            image = new byte[0];
                            image = (byte[])(r["image"]);
                            memo = new MemoryStream(image);
                            map = new Bitmap(Image.FromStream(memo));
                            pic.Image = (Bitmap)map;
                        }
                        catch
                        {
                            pic.Tag = "0000.bmp";
                            fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            map = new Bitmap(Image.FromStream(fstr));
                            pic.Image = (Bitmap)map;
                        }
                        break;
                    }
                }
                catch { }

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
				//
				l_id=decimal.Parse(dataGrid1[i_row,3].ToString());
				s_makp=dataGrid1[i_row,4].ToString();
				s_mabn=dataGrid1[i_row,1].ToString();
				s_tenbs=dataGrid1[i_row,5].ToString();
				s_chandoan=dataGrid1[i_row,6].ToString();
				s_maicd=dataGrid1[i_row,7].ToString();
                s_mabs = dataGrid1[i_row, 9].ToString();
                s_tenkp = dataGrid1[i_row, 10].ToString();
                i_loaiba=int.Parse(dataGrid1[i_row, 11].ToString());
				if (dataGrid1[i_row,0].ToString().Trim()=="True")
				{
					load_dtct();
                    decimal d_slxuat = 0, d_slton = 0;
                    bool b_chon = (bDaduyet) ? false : true;
					foreach(DataRow r in dtct.Rows)
					{
                        if (bDaduyet == false)
                        {
                            r2 = d.getrowbyid(dtton, "id=" + int.Parse(r["mabd"].ToString().Trim()) + " and makho=" + int.Parse(r["makho"].ToString()) + " and manguon=" + int.Parse(r["manguon"].ToString()));
                            if (r2 != null)
                            {
                                d_slxuat = decimal.Parse(r["soluong"].ToString());
                                d_slton = decimal.Parse(r2["soluong"].ToString());
                                if (d_slxuat > d_slton && d_slton > 0)
                                {
                                    d_slxuat = d_slton;
                                    b_chon = false;
                                }
                                else b_chon = d_slxuat > d_slton;

                                d.updrec_donthuoc(ds.Tables[0], dataGrid1[i_row, 2].ToString(), l_id, int.Parse(r["stt"].ToString()), decimal.Parse(r["sttt"].ToString()), int.Parse(r["mabd"].ToString()),
                                    r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),
                                    r2["tennguon"].ToString(), r["cachdung"].ToString(), r["handung"].ToString(), r["losx"].ToString(), d_slxuat, decimal.Parse(r["dongia"].ToString()),
                                    decimal.Parse(r["sotien"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()), Math.Round(d_slxuat * decimal.Parse(r["giaban"].ToString()), 0), b_chon, false, int.Parse(r["madoituong"].ToString()), i_loaiba, null, r["cachdung"].ToString());

                                //d.updrec_donthuoc(ds.Tables[0], dataGrid1[i_row, 2].ToString(), l_id, int.Parse(r["stt"].ToString()), decimal.Parse(r["sttt"].ToString()), int.Parse(r["mabd"].ToString()),
                                //    r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),
                                //    r2["tennguon"].ToString(), r["cachdung"].ToString(), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()),
                                //    decimal.Parse(r["sotien"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()), Math.Round(decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["giaban"].ToString()), 0), (decimal.Parse(r["soluong"].ToString()) <= decimal.Parse(r2["soluong"].ToString())) ? false : true, false, int.Parse(r["madoituong"].ToString()), i_loaiba, null, r["cachdung"].ToString());
                            }
                            else
                            {
                                d.updrec_donthuoc(ds.Tables[0], dataGrid1[i_row, 2].ToString(), l_id, int.Parse(r["stt"].ToString()), decimal.Parse(r["sttt"].ToString()), int.Parse(r["mabd"].ToString()),
                                    r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),
                                    r["tennguon"].ToString(), r["cachdung"].ToString(), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()),
                                    decimal.Parse(r["sotien"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["sotienban"].ToString()), true, false, int.Parse(r["madoituong"].ToString()), i_loaiba, null, r["cachdung"].ToString());
                            }
                        }
                        else
                        {
                            d.updrec_donthuoc(ds.Tables[0], dataGrid1[i_row, 2].ToString(), l_id, int.Parse(r["stt"].ToString()), decimal.Parse(r["sttt"].ToString()), int.Parse(r["mabd"].ToString()),
                                    r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),
                                    r["tennguon"].ToString(), r["cachdung"].ToString(), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()),
                                    decimal.Parse(r["sotien"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["sotienban"].ToString()), false , false, int.Parse(r["madoituong"].ToString()), i_loaiba, null, r["cachdung"].ToString());
                        }
					}
                 	decimal st=0;
					foreach(DataRow r in ds.Tables[0].Select("id="+l_id)) st+=decimal.Parse(r["sotienban"].ToString());
					dataGrid1[i_row,8]=st;
				}
				else
				{
					d.delrec(ds.Tables[0],"id="+l_id);
					dataGrid1[i_row,8]=0;
				}
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void load_grid()
		{
			sql="select distinct a.id,a.mabn,a.maql,b.hoten,b.namsinh,trim(b.sonha)||' '||trim(b.thon)||' '||trim(k.tenpxa)||' '||trim(j.tenquan)||' '||trim(i.tentt) as diachi,b.cholam,";
            sql += " a.makp as kp,c.tenkp,a.mabs,e.hoten as tenbs,";
            sql += " a.chandoan,a.maicd,0 as sotien,a.loaiba,0 as makp,l.nha,l.coquan,l.didong,a.songay ";
            sql += " from xxx.d_thuocbhytll a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            sql += " left join " + user + ".btdkp_bv c on a.makp=c.makp ";
            sql += " left join " + user + ".dmbs e on a.mabs=e.ma ";
            sql += " inner join xxx.d_thuocbhytct f on a.id=f.id";
            sql += " left join " + user + ".btdtt i on b.matt=i.matt ";
            sql += " left join " + user + ".btdquan j on b.maqu=j.maqu ";
            sql += " left join " + user + ".btdpxa k on b.maphuongxa=k.maphuongxa ";
            sql += " left join " + user + ".dienthoai l on a.mabn=l.mabn ";
			sql += " where a.done=0 and " + m.for_ngay("a.ngay",stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
            //and a.madoituong=5 
			sql += " and a.nhom="+i_nhom+" and f.makho="+i_makho;
			//sql+=" order by a.id";
			dt=d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0];
			dataGrid1.DataSource=dt;
			if (!bSkip) AddGridTableStyle();
			bSkip=true;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dt.Columns.Add("Chon",typeof(bool));
            DataRow r1; string _diachi = "";
            foreach (DataRow row in dt.Rows)
            {
                _diachi = row["diachi"].ToString();
                if (row["nha"].ToString() != "" || row["coquan"].ToString() != "" || row["didong"].ToString() != "")
                {
                    _diachi += " Điện thoại :";
                    if (row["didong"].ToString() != "") _diachi += row["didong"].ToString();
                    else if (row["nha"].ToString() != "") _diachi += row["nha"].ToString();
                    else _diachi += row["coquan"].ToString();
                }
                row["chon"] = false;
                row["diachi"] = _diachi;
                r1 = m.getrowbyid(dtkp, "makp='" + row["kp"].ToString() + "'");
                if (r1 != null) row["makp"] = int.Parse(r1["id"].ToString());
            }
			butLuu.Enabled=dt.Rows.Count!=0;			
			dataGrid1.Focus();
			i_row=dataGrid1.CurrentRowIndex;
			load_items();
		}

		private void load_items()
		{
			ds.Clear();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            if (bKhoaso)
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng") + " " + s_mmyy.Substring(0, 2) + " " + lan.Change_language_MessageText("năm") + " " + s_mmyy.Substring(2, 2) + " " +
                lan.Change_language_MessageText("đã khóa !") + "\n" + lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                return;
            }
			Cursor=Cursors.WaitCursor;
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="";
			cm= (CurrencyManager)BindingContext[dataGrid2.DataSource];
			dv=(DataView)cm.List;
			dv.RowFilter="";
			upd_data(false);
			load_grid();
			bOk=true;
			Cursor=Cursors.Default;
		}

		private void load_tonct()
		{
			dttonct=d.get_tonkhoct(s_mmyy,s_makho.Trim().Trim().Trim(','),s_kho,s_manguon,i_nhom);
		}

		private void load_dtct()
		{
            if (bDaduyet == false)
            {
                sql = "select a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten) as ten,";
                sql += " b.tenhc,b.dang,'' as tenkho,'' as tennguon,' ' as tennhomcc,";
                sql += " ' ' as handung,' ' as losx,ceiling(a.slyeucau) as soluong,";
                if (bGiaban_noi_ngoai) sql += "b.giaban2 as dongia,";
                else sql += "b.giaban as dongia,";
                sql += "ceiling(a.slyeucau)*b.dongia as sotien,";
                if (bGiaban_noi_ngoai) sql += "b.giaban2 as giaban,";
                else sql += "b.giaban,";
                sql += "b.dongia as giamua,";
                if (bGiaban_noi_ngoai) sql += " round(ceiling(a.slyeucau)*b.giaban2,0) as sotienban,";
                else sql += " round(ceiling(a.slyeucau)*b.giaban,0) as sotienban,";
                sql += "a.makho,a.manguon,0 as nhomcc,0 as soluongcu,0 as sotiencu,a.cachdung,a.madoituong ";
                sql += " from xxx.d_thuocbhytct a," + user + ".d_dmbd b";
                sql += " where a.mabd=b.id ";
                sql += " and a.id=" + l_id + " order by a.stt";
            }
            else
            {
                sql = "select a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten) as ten,";
                sql += " b.tenhc,b.dang,'' as tenkho,'' as tennguon,' ' as tennhomcc,";
                sql += " ' ' as handung,' ' as losx,ceiling(a.soluong) as soluong,";
                sql += "a.giaban as dongia,";
                sql += "ceiling(a.soluong)*a.giaban as sotien,";
                sql += "a.giaban,";
                sql += "b.giaban as giamua,";
                if (bGiaban_noi_ngoai) sql += " round(ceiling(a.soluong)*a.giaban,0) as sotienban,";
                else sql += " round(ceiling(a.soluong)*a.giaban,0) as sotienban,";
                sql += "a.makho,0 as manguon,0 as nhomcc,0 as soluongcu,0 as sotiencu,a.cachdung,a.madoituong ";
                sql += " from xxx.d_ngtruct a," + user + ".d_dmbd b";
                sql += " where a.mabd=b.id ";
                sql += " and a.id=" + l_id + " order by a.stt";
            }
			dtct=d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0];
		}

		private void upd_data(bool prn)
		{
			//load_tonct();
			decimal o_id=0,id;
			int i_sotoa;
			hoten="";
			DataRow r;
			DataRow [] dr=ds.Tables[0].Select("chon=false and soluong>0","id,stt");
			for(int i=0;i<dr.Length;i++)
			{
				l_id=decimal.Parse(dr[i]["id"].ToString());
				if (o_id!=l_id)
				{
					r=d.getrowbyid(dt,"chon=true and id="+l_id);
					if (r!=null)
					{
						hoten=r["hoten"].ToString();
						namsinh=r["namsinh"].ToString();
                        s_mabs = r["mabs"].ToString();
						id=d.get_id_xuatban;
						i_sotoa=d.get_sotoa_xuatban(s_mmyy,id,i_loai,s_ngay);
                        d.upd_ngtrull(s_mmyy, id, i_nhom, r["mabn"].ToString(), r["hoten"].ToString(), r["namsinh"].ToString(), s_ngay, r["mabs"].ToString(), (r["makp"].ToString() == "") ? 0 : int.Parse(r["makp"].ToString()), i_loai, i_userid, i_sotoa, decimal.Parse(r["maql"].ToString()), r["diachi"].ToString() + "^" + r["tenkp"].ToString(), r["tenbs"].ToString());
                        if (decimal.Parse(r["songay"].ToString()) != 0) d.execute_data("update " + user + s_mmyy + ".d_ngtrull set songay=" + decimal.Parse(r["songay"].ToString()) + " where id=" + id);
						d.upd_chandoan(s_mmyy,id,0,s_maicd,s_chandoan);
						dtct=d.get_ngtruct(s_mmyy,ds.Tables[0].Select("chon=false and id="+l_id,"stt"),id,l_id);
                        //d.updrec_ngtrull_ban(dtll, id, r["mabn"].ToString(), r["hoten"].ToString(), r["namsinh"].ToString(), s_ngay, r["mabs"].ToString(), (r["makp"].ToString() == "") ? 0 : int.Parse(r["makp"].ToString()), i_loai, 0, i_userid, i_sotoa, decimal.Parse(r["maql"].ToString()), r["diachi"].ToString() + "^" + r["tenkp"].ToString(), r["tenbs"].ToString(), decimal.Parse(r["songay"].ToString()));
						d.execute_data_mmyy("update xxx.d_thuocbhytll set done=1,idduyet="+id+" where id="+l_id,s_tu,s_den,songayduyet);
						//if (prn) printer(i_sotoa,id,decimal.Parse(r["songay"].ToString()));
					}
					o_id=l_id;
				}
			}
		}

		private void printer(int toa,decimal l_id,decimal sothang)
		{
            //DataRow r;
            //string stuoi=namsinh;
            //decimal l_maql=0;
            //ghichu="";
            //s_chandoan=s_chandoan.Trim()+";";
            ///*
            //if (namsinh!="") 
            //{
            //    int tuoi=DateTime.Now.Year-int.Parse(namsinh);
            //    stuoi=tuoi.ToString();
            //}*/
            //sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,";
            //sql+=" c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
            //sql+=" case when a.paid=1 then t.giamua else 0 end as dongia,";
            //sql+=" case when a.paid=1 then a.soluong*t.giamua else 0 end as sotien,";
            //sql+=" case when a.paid=1 then a.giaban else 0 end as giaban,a.makho,t.manguon,t.nhomcc,";
            //sql+=" case when a.paid=1 then a.soluong*a.giaban else 0 end as sotienban,";
            //sql+=" a.soluong as soluongcu,case when a.paid=1 then a.soluong*t.giamua else 0 end as sotiencu,a.paid,"+sothang+" as sothang";
            //sql += ",a.cachdung";
            //sql += " from " + user + s_mmyy + ".d_ngtruct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e," + user + s_mmyy + ".d_theodoi t where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and a.id=" + l_id + " order by a.stt";
            //DataSet dsct=d.get_data(sql);
            //DataTable dt = d.get_data("select lanin from " + user + s_mmyy + ".d_ngtrull where id=" + l_id).Tables[0];
            //string _diachi = "", _hen = "", _phai = "";
            ////if (bIncachdung)
            ////{
            //string s_tenkp = "";
            //    sql="select a.maql,a.ghichu,b.mabd,b.cachdung, c.tenkp from xxx.d_thuocbhytll a,xxx.d_thuocbhytct b,"+user+".btdkp_bv c where a.id=b.id and a.makp=c.makp and a.idduyet="+l_id;
            //    foreach(DataRow r1 in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
            //    {
            //        r=d.getrowbyid(dsct.Tables[0],"mabd="+int.Parse(r1["mabd"].ToString()));
            //        if (r!=null) r["tennhomcc"]=r1["cachdung"].ToString();
            //        ghichu=r1["ghichu"].ToString();
            //        l_maql=decimal.Parse(r1["maql"].ToString());
            //        s_tenkp = r1["tenkp"].ToString();
            //    }
            //    if (l_maql != 0)
            //    {
            //        foreach (DataRow r1 in d.get_data_mmyy("select chandoan from xxx.cdkemtheo where maql=" + l_maql + " order by stt",s_tu,s_den,songayduyet).Tables[0].Rows)
            //            s_chandoan += r1["chandoan"].ToString() + ";";
            //        sql = "select a.sonha,a.thon,b.tentt,c.tenquan,d.tenpxa,a.phai,";
            //        sql += " case when f.songay is null then 0 else f.songay end as songay,";
            //        sql += " case when f.loai is null then 0 else f.loai end as loai,";
            //        sql += " case when f.ghichu is null then '' else f.ghichu end as ghichu,g.nha,g.coquan,g.didong ";
            //        sql += " from " + user + ".btdbn a left join " + user + ".btdtt b on a.matt=b.matt ";
            //        sql += " left join " + user + ".btdquan c on a.maqu=c.maqu ";
            //        sql += " left join " + user + ".btdpxa d on a.maphuongxa=d.maphuongxa ";
            //        sql += " left join xxx.benhanpk e on a.mabn=e.mabn ";
            //        sql += " left join " + user + ".dienthoai g on a.mabn=g.mabn ";
            //        sql += " left join xxx.hen f on e.maql=f.maql where e.maql=" + l_maql;
            //        foreach (DataRow r3 in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
            //        {
            //            _diachi = r3["sonha"].ToString().Trim() + " " + r3["thon"].ToString().Trim() + " " + r3["tenpxa"].ToString().Trim() + " " + r3["tenquan"].ToString().Trim() + " " + r3["tentt"].ToString();
            //            if (r3["nha"].ToString() != "" || r3["coquan"].ToString() != "" || r3["didong"].ToString() != "")
            //            {
            //                _diachi += " Điện thoại :";
            //                if (r3["didong"].ToString() != "") _diachi += r3["didong"].ToString();
            //                else if (r3["nha"].ToString() != "") _diachi += r3["nha"].ToString();
            //                else _diachi += r3["coquan"].ToString();
            //            }
                        
            //            if (r3["songay"].ToString() != "0")
            //            {
            //                _hen = r3["ghichu"].ToString().Trim() + " " + r3["songay"].ToString();
            //                switch (int.Parse(r3["loai"].ToString()))
            //                {
            //                    case 0: _hen += " Ngày liên tục"; break;
            //                    case 1: _hen += " Ngày"; break;
            //                    case 2: _hen += " Tuần"; break;
            //                    default: _hen += " Tháng"; break;
            //                }
            //            }
            //            _phai = (r3["phai"].ToString() == "0") ? " Nam" : " Nữ";
            //        }
            //    }
            //    _diachi += "^" + s_tenkp;
            ////}
            //int lanin=(dt.Rows.Count>0)?int.Parse(dt.Rows[0]["lanin"].ToString()):0;
            //if (lanin>0)
            //{
            //    lanin++;
            //    if (MessageBox.Show(lan.Change_language_MessageText("Lần in thứ")+" "+lanin.ToString()+"\n"+lan.Change_language_MessageText("Bạn có muốn in ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;
            //}
            //DataSet ldt=dsct.Copy();
            //ldt.Tables[0].Columns.Add("lien");            
            //ldt.Tables[0].Columns.Add("Image", typeof(byte[]));
            //int i_lien=1;
            //string d_tenrpt=(i_lien>1)?"d_xuatban.rpt":"d_xuatban_a5.rpt";
            //string s_c8=(lanin>1 && !d.bInPhieuxuatban(i_nhom))?"Lần in thứ "+lanin.ToString():s_tenkho;
            //tongcong_n_lien(ldt.Tables[0],i_lien);
            //decimal d_sotoa=Convert.ToDecimal(toa);
            //string tmp_ngaygio=s_ngay+" "+DateTime.Now.Hour.ToString().PadLeft(2,'0')+":"+DateTime.Now.Minute.ToString().PadLeft(2,'0');
            //string s_toa=(d.bNgtru_mabn)?s_mabn:d_sotoa.ToString("###,###");
            //s_toa+=" ("+tmp_ngaygio+" - "+s_loai+")";
            //string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString());
            //r=d.getrowbyid(dtll,"id="+l_id);
            //if (r!=null) r["done"]=1;
            //d.execute_data("update " + user + s_mmyy + ".d_ngtrull set lanin=lanin+1,done=1 where id=" + l_id);
            //if (File.Exists("..\\..\\..\\chuky\\" + s_mabs + ".bmp"))
            //{
            //    fstr = new FileStream("..\\..\\..\\chuky\\" + s_mabs + ".bmp", FileMode.Open, FileAccess.Read);
            //    image = new byte[fstr.Length];
            //    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
            //    fstr.Close();
            //    foreach (DataRow r1 in ldt.Tables[0].Rows) r1["Image"] = image;
            //}
            //string _hoten = hoten.Trim() + " - " + s_mabn;
            //string s_diungthuoc = d.f_get_diung(s_mabn);
            //if (chkXml.Checked)
            //{
            //    if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
            //    ldt.WriteXml("..\\xml\\donthuoc.xml", XmlWriteMode.WriteSchema);
            //}

            //if (d.bPreview)
            //{
            //    frmReport f=new frmReport(d,ldt.Tables[0],d_tenrpt,s_toa,_hoten,s_tenbs+"^"+s_tenkp,stuoi,s_ngay,s_userid+"^"+d_sotoa.ToString("#####"),s_chu,s_c8+"^"+_diachi,ghichu+"^"+_hen,s_chandoan+"^"+_phai+"^^"+s_diungthuoc);
            //    f.ShowDialog();
            //}
            //else
            //{
            //    try
            //    {
            //        ReportDocument oRpt=new ReportDocument();
            //        oRpt.Load("..\\..\\..\\report\\"+d_tenrpt,OpenReportMethod.OpenReportByTempCopy);
            //        oRpt.SetDataSource(ldt.Tables[0]);
            //        oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
            //        oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
            //        oRpt.DataDefinition.FormulaFields["c1"].Text="'"+s_toa+"'";
            //        oRpt.DataDefinition.FormulaFields["c2"].Text="'"+_hoten+"'";
            //        oRpt.DataDefinition.FormulaFields["c3"].Text="'"+s_tenbs+"^"+s_tenkp+"'";
            //        oRpt.DataDefinition.FormulaFields["c4"].Text="'"+stuoi+"'";
            //        oRpt.DataDefinition.FormulaFields["c5"].Text="'"+s_ngay+"'";
            //        oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + s_userid + "^" + d_sotoa.ToString("#####") + "'";
            //        oRpt.DataDefinition.FormulaFields["c7"].Text="'"+s_chu+"'";
            //        oRpt.DataDefinition.FormulaFields["c8"].Text="'"+s_c8+"'^'"+_diachi;
            //        oRpt.DataDefinition.FormulaFields["c9"].Text="'"+ghichu+"'^'"+_hen;
            //        oRpt.DataDefinition.FormulaFields["c10"].Text="'"+s_chandoan+"'^'"+_phai+"^^"+s_diungthuoc;
            //        oRpt.DataDefinition.FormulaFields["giamdoc"].Text="";
            //        oRpt.DataDefinition.FormulaFields["phutrach"].Text="";
            //        oRpt.DataDefinition.FormulaFields["thongke"].Text="";
            //        oRpt.DataDefinition.FormulaFields["ketoan"].Text="";
            //        oRpt.DataDefinition.FormulaFields["thukho"].Text="";
            //        oRpt.DataDefinition.FormulaFields["l_soluong"].Text=i_soluong_le.ToString();
            //        oRpt.DataDefinition.FormulaFields["l_dongia"].Text=i_dongia_le.ToString();
            //        oRpt.DataDefinition.FormulaFields["l_thanhtien"].Text=i_thanhtien_le.ToString();
            //        //oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
            //        //oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
            //        if (d.bPrintDialog)
            //        {
            //            result=Thongso();
            //            if (result==DialogResult.OK)
            //            {
            //                oRpt.PrintOptions.PrinterName=p.PrinterSettings.PrinterName;
            //                oRpt.PrintToPrinter(p.PrinterSettings.Copies,false,p.PrinterSettings.FromPage,p.PrinterSettings.ToPage);
            //            }
            //        }
            //        else oRpt.PrintToPrinter(1,false,0,0);
            //        oRpt.Close(); oRpt.Dispose();
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //        return;
            //    }
            //}
		}
		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

		private void tongcong_n_lien(DataTable dt, int i_lien)
		{
			d_tongcong=0;
			int i=0,j=0;
			foreach(DataRow r1 in dt.Rows) 
			{
				d_tongcong+=decimal.Parse(r1["sotienban"].ToString());
				r1["lien"]=1;
				i+=1;
			}
			if(i_lien>1)
			{
				for(j=i;j<6;j++)
				{
					DataRow lr=dt.NewRow();
					lr["lien"]=1;
					lr["stt"]=j;
					lr["soluong"]=0;
					dt.Rows.Add(lr);
				}			
				DataTable tmpdt=dt.Copy();
				j=0;
				for(int k=2;k<4;k++)
				{				
					foreach(DataRow lr2 in tmpdt.Rows)
					{									
						dt.Rows.Add(lr2.ItemArray);
						dt.Rows[dt.Rows.Count-1]["lien"]=k;
					}				
				}
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
					dv.RowFilter="hoten like '%"+tim.Text.Trim()+"%' or mabn like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim2_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim2)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid2.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim2.Text!="")
					dv.RowFilter="ten like '%"+tim2.Text.Trim()+"%' or hoten like '%"+tim2.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void dataGrid2_Click(object sender, System.EventArgs e)
		{
			try
			{
				Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
				DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
				BindingManagerBase bmb = this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
				if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
				{	
					this.dataGrid2[hti.Row, checkCol] = !(bool)this.dataGrid2[hti.Row, checkCol];
					RefreshRow(hti.Row);
				}
				afterCurrentCellChanged = false;
			}
			catch{}
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid2[this.dataGrid2.CurrentRowIndex, checkCol]) this.dataGrid2.CurrentCell = new DataGridCell(this.dataGrid2.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
			try
			{
				if (dataGrid2.CurrentCell.ColumnNumber==2)
				{
					string ma=dataGrid2[i_row_thuoc,2].ToString().ToUpper();
					r2=d.getrowbyid(dtton,"ma='"+ma+"'");
					if (r2!=null)
					{
						ds.Tables[0].Rows[i_row_thuoc]["ma"]=ma;
						ds.Tables[0].Rows[i_row_thuoc]["mabd"]=r2["mabd"].ToString();
						ds.Tables[0].Rows[i_row_thuoc]["dang"]=r2["dang"].ToString();
						ds.Tables[0].Rows[i_row_thuoc]["ten"]=r2["ten"].ToString();
						ds.Tables[0].Rows[i_row_thuoc]["giaban"]=r2["giaban"].ToString();
						ds.Tables[0].Rows[i_row_thuoc]["sotienban"]=Math.Round(decimal.Parse(ds.Tables[0].Rows[i_row_thuoc]["soluong"].ToString())*decimal.Parse(r2["giaban"].ToString()),0);
					}
					else ds.Tables[0].Rows[i_row_thuoc]["chon"]=true;
					i_row_thuoc=dataGrid2.CurrentRowIndex;
				}
			}
			catch{}
		}

		private void frmDuyetdon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F5) butLuu_Click(sender,e);
			//else if (e.KeyCode==Keys.F9) butLuuin_Click(sender,e);
		}

		
        private void butSum_Click(object sender, EventArgs e)
        {
            decimal st = 0;
            ds.AcceptChanges();
            foreach (DataRow r in dt.Select("chon=true"))
            {
                st = 0;
                foreach (DataRow r1 in ds.Tables[0].Select("chon=false and id=" + decimal.Parse(r["id"].ToString())))
                    st += decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(r1["giaban"].ToString());
                r["sotien"] = st;
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r1 = m.getrowbyid(dt, "id=" + l_id);
                if (r1 != null)
                {
                    string xxx = user + d.mmyy(s_ngay);
                    string lydo = m.get_lydokham(s_ngay, l_maql).Trim(), stuoi = "", schandoan = r1["chandoan"].ToString().Trim() + ";";
                    foreach (DataRow r in d.get_data_mmyy("select chandoan from xxx.cdkemtheo where maql=" + decimal.Parse(r1["maql"].ToString()) + " order by stt",s_tu,s_den,songayduyet).Tables[0].Rows)
                        schandoan += r["chandoan"].ToString() + ";";
                    if (r1["namsinh"].ToString() != "")
                    {
                        int tuoi = DateTime.Now.Year - int.Parse(r1["namsinh"].ToString());
                        stuoi = tuoi.ToString();
                    }
                    sql = "select 1 as loai,a.stt,' ' as doituong,b.ma,trim(b.ten)||' '||b.hamluong as ten,";
                    sql += "nullif(b.tenhc,' ') as tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,1 as madoituong,";
                    sql += "a.makho,nullif(a.cachdung,' ') as cachdung,b.mahc,' ' as diung,a.manguon,0 as tutruc,0 as idvpkhoa ";
                    sql += ",0 as mabd";
                    sql += " from xxx.d_thuocbhytct a inner join " + user + ".d_dmbd b on a.mabd=b.id ";
                    sql += " left join " + user + ".d_dmnhom c on b.manhom=c.id ";
                    sql += " left join " + user + ".d_dmkho f on a.makho=f.id ";
                    sql += " where a.id=" + l_id;
                    if (chkTumua.Checked) sql += " and a.manguon=-1";
                    DataSet dstmp = d.get_data_mmyy(sql,s_tu,s_den,songayduyet);
                    DataColumn dc = new DataColumn("Image", typeof(byte[]));
                    dstmp.Tables[0].Columns.Add(dc);
                    if (File.Exists("..\\..\\..\\chuky\\" + s_mabs + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\..\\chuky\\" + s_mabs + ".bmp", FileMode.Open, FileAccess.Read);
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                        foreach (DataRow r in dstmp.Tables[0].Rows) r["Image"] = image;
                    }
                    if (chkXml.Checked)
                    {
                        if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                        dstmp.WriteXml("..\\xml\\donthuoc.xml", XmlWriteMode.WriteSchema);
                    }
                    string tenfile=(System.IO.File.Exists("..\\..\\..\\report\\d_donthuocb.rpt"))?"d_donthuocb.rpt":"d_donthuoc.rpt";
                    //frmReport f = new frmReport(d, dstmp.Tables[0], tenfile, r1["hoten"].ToString(), stuoi, "", schandoan, r1["diachi"].ToString(), r1["tenbs"].ToString(), dstmp.Tables[0].Rows.Count.ToString(), r1["mabn"].ToString(), lydo,"");
                    //f.ShowDialog(this);
                }
            }
            catch { }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            decimal st = 0;
            sql = "chon=false";
            if (tim.Text != "")
                sql += " and hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
            foreach (DataRow r1 in dt.Select(sql))
            {
                l_id = decimal.Parse(r1["id"].ToString());
                s_makp = r1["makp"].ToString();
                s_mabn = r1["mabn"].ToString();
                l_maql = decimal.Parse(r1["maql"].ToString());
                s_tenbs = r1["tenbs"].ToString();
                s_chandoan = r1["chandoan"].ToString();
                s_maicd = r1["maicd"].ToString();
                s_mabs = r1["mabs"].ToString();
                s_tenkp = r1["tenkp"].ToString();
                i_loaiba = int.Parse(r1["loaiba"].ToString());
                load_dtct();
                foreach (DataRow r in dtct.Rows)
                {
                    r2 = d.getrowbyid(dtton, "id=" + int.Parse(r["mabd"].ToString().Trim()) + " and makho=" + int.Parse(r["makho"].ToString()) + " and manguon=" + int.Parse(r["manguon"].ToString()));
                    if (r2 != null)
                        d.updrec_donthuoc(ds.Tables[0], dataGrid1[i_row, 2].ToString(), l_id, int.Parse(r["stt"].ToString()), decimal.Parse(r["sttt"].ToString()), int.Parse(r["mabd"].ToString()),
                            r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),
                            r2["tennguon"].ToString(), r["cachdung"].ToString(), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()),
                            decimal.Parse(r["sotien"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()), Math.Round(decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["giaban"].ToString()), 0), (decimal.Parse(r["soluong"].ToString()) <= decimal.Parse(r2["soluong"].ToString())) ? false : true, false, int.Parse(r["madoituong"].ToString()), i_loaiba, null,r["cachdung"].ToString());
                    else
                        d.updrec_donthuoc(ds.Tables[0], dataGrid1[i_row, 2].ToString(), l_id, int.Parse(r["stt"].ToString()), decimal.Parse(r["sttt"].ToString()), int.Parse(r["mabd"].ToString()),
                            r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),
                            r["tennguon"].ToString(), r["cachdung"].ToString(), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()),
                            decimal.Parse(r["sotien"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["sotienban"].ToString()), true, false, int.Parse(r["madoituong"].ToString()), i_loaiba, null, r["cachdung"].ToString());
                }
                st = 0;
                foreach (DataRow r in ds.Tables[0].Select("id=" + l_id)) st += decimal.Parse(r["sotienban"].ToString());
                r1["sotien"] = st;
                r1["chon"] = true;
            }
            Cursor = Cursors.Default;
            butLuu.Focus();
        }

        private void tim_Validated(object sender, EventArgs e)
        {
            if (tim.Text.Trim().Length == 8) butAll_Click(sender, e);
        }

        private void butList_Click(object sender, EventArgs e)
        {
            bDaduyet = false;
            //btHuy38.Enabled = bDaduyet;
            //butLuu.Enabled = !bDaduyet;
            load_grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bDaduyet = true;
            //btHuy38.Enabled = bDaduyet;
            butLuu.Enabled = !bDaduyet;
            load_grid_daduyet();
        }

        private void load_grid_daduyet()
        {
            sql = "select distinct a.id,a.mabn,a.maql,b.hoten,b.namsinh,trim(b.sonha)||' '||trim(b.thon)||' '||trim(k.tenpxa)||' '||trim(j.tenquan)||' '||trim(i.tentt) as diachi,b.cholam,";
            sql += " a.makp as kp,c.tenkp,a.mabs,e.hoten as tenbs,";
            sql += " '' as chandoan, '' as maicd,0 as sotien, 3 as loaiba,0 as makp,l.nha,l.coquan,l.didong,a.songay ";
            sql += " from xxx.d_ngtrull a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            sql += " left join " + user + ".btdkp_bv c on a.makp=c.makp ";
            sql += " left join " + user + ".dmbs e on a.mabs=e.ma ";
            sql += " inner join xxx.d_ngtruct f on a.id=f.id";
            sql += " left join " + user + ".btdtt i on b.matt=i.matt ";
            sql += " left join " + user + ".btdquan j on b.maqu=j.maqu ";
            sql += " left join " + user + ".btdpxa k on b.maphuongxa=k.maphuongxa ";
            sql += " left join " + user + ".dienthoai l on a.mabn=l.mabn ";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
            //and a.madoituong=5 
            sql += " and a.nhom=" + i_nhom + " and f.makho=" + i_makho;
            //sql+=" order by a.id";
            dt = d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0];
            dataGrid1.DataSource = dt;
            if (!bSkip) AddGridTableStyle();
            bSkip = true;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            dt.Columns.Add("Chon", typeof(bool));
            DataRow r1; string _diachi = "";
            foreach (DataRow row in dt.Rows)
            {
                _diachi = row["diachi"].ToString();
                if (row["nha"].ToString() != "" || row["coquan"].ToString() != "" || row["didong"].ToString() != "")
                {
                    _diachi += " Điện thoại :";
                    if (row["didong"].ToString() != "") _diachi += row["didong"].ToString();
                    else if (row["nha"].ToString() != "") _diachi += row["nha"].ToString();
                    else _diachi += row["coquan"].ToString();
                }
                row["chon"] = false;
                row["diachi"] = _diachi;
                r1 = m.getrowbyid(dtkp, "makp='" + row["kp"].ToString() + "'");
                if (r1 != null) row["makp"] = int.Parse(r1["id"].ToString());
            }
            btHuy38.Enabled = dt.Rows.Count != 0;
            dataGrid1.Focus();
            i_row = dataGrid1.CurrentRowIndex;
            load_items();
        }

        private void btHuy38_Click(object sender, EventArgs e)
        {
            try
            {
                if (l_id == 0) return;
                if (bKhoaso)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng") + " " + s_mmyy.Substring(0, 2) + " " + lan.Change_language_MessageText("năm") + " " + s_mmyy.Substring(2, 2) + " " + lan.Change_language_MessageText("đã khóa !") + "\n" + lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                    return;
                }
                string xxx=d.user+d.mmyy(s_ngay);
                sql = "select distinct idttrv from " + xxx + ".d_ngtruct where id=" + l_id+" and idttrv>0 ";
                DataSet lds = d.get_data(sql);
                if (lds != null && lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đơn thuốc này đã thanh toán, không được phép hủy."));
                    return;
                }
                if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {                    
                    //if (bBienlai) d.execute_data("delete from " + xxx + ".d_bienlai where id=" + l_id);
                    int itable = d.tableid(s_mmyy, "d_ngtruct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_ngtruct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                    }

                    itable = d.tableid(s_mmyy, "d_ngtrull");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_ngtrull", "id=" + l_id));
                    d.execute_data("insert into " + xxx + ".d_huybanll(id,nhom,mabn,hoten,namsinh,ngay,mabs,makp,loai,done,userid,ngayud,lanin,sotoa,maql,idduyet) select id,nhom,mabn,hoten,namsinh,ngay,mabs,makp,loai,done,userid,ngayud,lanin,sotoa,maql,idduyet from " + xxx + ".d_ngtrull where id=" + l_id);
                    d.execute_data("insert into " + xxx + ".d_huybanct select * from " + xxx + ".d_ngtruct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_ngtruct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_ngtrull where id=" + l_id);
                    d.execute_data_mmyy("update xxx.d_thuocbhytll set done=0 where idduyet=" + l_id, s_tu, s_den, songayduyet);
                    
                    load_grid_daduyet();
                    
                    butList.Focus();
                }
            }
            catch { }
        }
	}
}
