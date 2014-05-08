using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllvpkhoa_chidinh
{
	/// <summary>
	/// Summary description for frmChidinh.
	/// </summary>
	public class frmChidinh_k : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.DataGrid dataGrid1;
		private LibList.List list;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
        private LibVienphi.AccessData v = new LibVienphi.AccessData();
        private dllReportM.Print print = new dllReportM.Print();
        private string user, xxx, s_ngay, s_makp, s_tenkp, sql, s_sovaovien, s_denngay, ngay1, ngay2, ngay3, tungay, s_noicap, s_table;
        private bool bInchitiet, bTinnhan, bTinnhan_sound, bAdmin, bAdminHethong, bAdminInlaiphieuchidinh, bAdminInlaidonthuoc, bMadoituong, bChidinh_exp_txt, bChuky, bChidinh_ngtru_vienphi, bChenhlech = false, bChenhlech_doituong, bChidinh_loaivp, bChidinh_lietke_kemgia = true, bBHYT_Traituyen_tinh_Tyle_khac = false, bChenhlechPK_chitinh_vaongaynghi = false;
        private int i_madoituong, i_userid, i_sokham, traituyen, i_loaiba, i_tunguyen,i_madoituongvao;
		private decimal l_maql,l_mavaovien,l_idkhoa;
        private bool bNew, bSothe_ngay_huong, bKhamchuyen_chidinh;
        private bool bChidinh_dain_khongchohuy = false;
        private bool bSophieu_chidinh;
		private DataRow r;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtdt=new DataTable();
        private DataTable dtg = new DataTable();
		private System.Windows.Forms.TextBox ma;
		private LibList.List listHoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox namsinh;
        private Button butIn;
        private CheckBox chkXml;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChidinh_k(LibMedi.AccessData acc,string ngay,string makp,string tenkp,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChidinh_k));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.list = new LibList.List();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.ma = new System.Windows.Forms.TextBox();
            this.listHoten = new LibList.List();
            this.label3 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXml = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(64, 289);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(119, 21);
            this.mabn.TabIndex = 0;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(166, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(261, 289);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(163, 21);
            this.hoten.TabIndex = 1;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
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
            this.dataGrid1.Location = new System.Drawing.Point(9, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(696, 294);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(416, 416);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 30;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(64, 313);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(119, 21);
            this.madoituong.TabIndex = 2;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(184, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Khám :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(301, 313);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(403, 21);
            this.ten.TabIndex = 4;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(98, 345);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 7;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(168, 345);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 8;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(238, 345);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 5;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(378, 345);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(448, 345);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 9;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(518, 345);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(261, 313);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(37, 21);
            this.ma.TabIndex = 3;
            this.ma.Validated += new System.EventHandler(this.mavp_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // listHoten
            // 
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(336, 416);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 31;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            this.listHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHoten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(512, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 74;
            this.label3.Text = "Số thẻ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(560, 289);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(144, 21);
            this.sothe.TabIndex = 73;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(415, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 75;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(478, 288);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(39, 21);
            this.namsinh.TabIndex = 76;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(308, 345);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 77;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkXml
            // 
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(654, 350);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(48, 17);
            this.chkXml.TabIndex = 78;
            this.chkXml.Text = "XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // frmChidinh_k
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(714, 447);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChidinh_k";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ định khám";
            this.Load += new System.EventHandler(this.frmChidinh_k_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChidinh_k_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bKhamchuyen_chidinh = m.bKhamchuyen_chidinh;
            i_sokham = m.iSokham; bSothe_ngay_huong = m.bSothe_ngay_huong;
            user = m.user; xxx = user + m.mmyy(s_ngay);
            dthoten = m.get_hiendien(s_makp, s_ngay).Tables[0];
			listHoten.DisplayMember="MABN";
			listHoten.ValueMember="HOTEN";
			listHoten.DataSource=dthoten;

            dtg = m.get_data("select * from " + user + ".v_giavp").Tables[0];

			sql="select makp,tenkp,* from "+user+".btdkp_bv where loai=1 order by makp";
			dt=m.get_data(sql).Tables[0];
			list.DisplayMember="tenkp";
			list.ValueMember="id";
			list.DataSource=dt;

			dtdt=m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdt;

			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

            bAdmin = m.bAdmin(i_userid); 
            bAdminHethong = m.bAdminHethong(i_userid);
           
            bChenhlech_doituong = m.bChenhlech_doituong;
            bAdminInlaidonthuoc = m.bAdminInlaidonthuoc;
            bAdminInlaiphieuchidinh = m.bAdminInlaiphieuchidinh;
            bSophieu_chidinh = m.bSophieu_chidinh;
            i_tunguyen = m.iTunguyen;
            s_table = "xxx.tiepdon";
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = ds.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "maql";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "mabn";
			TextCol1.HeaderText = "Mã BN";
			TextCol1.Width = 60;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "hoten";
			TextCol1.HeaderText = "Họ tên";
			TextCol1.Width =180;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "namsinh";
			TextCol1.HeaderText = "NS";
			TextCol1.Width =40;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "doituong";
			TextCol1.HeaderText = "Đối tượng";
			TextCol1.Width = 100;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "sothe";
			TextCol1.HeaderText = "Số thẻ";
			TextCol1.Width = 100;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "tenkp";
			TextCol1.HeaderText = "Khám";
			TextCol1.Width = 130;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "done";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "sovaovien";
			TextCol1.HeaderText = "Số khám";
			TextCol1.Width = 60;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 9);
            TextCol1.MappingName = "mavaovien";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return (this.dataGrid1[row,7].ToString().Trim()=="x")?Color.Red:Color.Black;
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
			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
		private void load_grid()
		{
			sql="select a.mabn,a.maql,a.mavaovien,c.hoten,c.namsinh,b.makp,d.tenkp,b.madoituong,e.doituong,f.sothe,";
            sql+="b.done,b.sovaovien,";
            sql+=" to_char(f.denngay,'dd/mm/yyyy') as denngay,to_char(f.tungay,'dd/mm/yyyy') as tungay,to_char(f.ngay1,'dd/mm/yyyy') as ngay1,";
            sql+=" to_char(f.ngay2,'dd/mm/yyyy') as ngay2,to_char(f.ngay3,'dd/mm/yyyy') as ngay3,f.traituyen,f.mabv";
			sql+=" from "+xxx+".khoacdkham a inner join "+xxx+".tiepdon b on a.maql=b.maql ";
            sql+=" inner join "+user+".btdbn c on a.mabn=c.mabn ";
            sql+=" inner join "+user+".btdkp_bv d on b.makp=d.makp ";
            sql+=" inner join "+user+".doituong e on b.madoituong=e.madoituong ";
            sql+=" left join "+xxx+".bhyt f on a.maql=f.maql ";
			sql+=" where to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"' and a.makp='"+s_makp+"'";
			sql+=" order by a.maql";
			ds=m.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
		}
		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible) list.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				Filter(ten.Text);
				list.BrowseToDanhmuc(ten,ma,butLuu);
			}
		}

		private void ref_text()
		{
			try
			{
				l_maql=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				DataRow r1=m.getrowbyid(ds.Tables[0],"maql="+l_maql);
				if (r1!=null)
				{
                    l_mavaovien = decimal.Parse(r1["mavaovien"].ToString());
					mabn.Text=r1["mabn"].ToString();
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					sothe.Text=r1["sothe"].ToString();
					madoituong.SelectedValue=r1["madoituong"].ToString();
					ma.Text=r1["makp"].ToString();
					ten.Text=r1["tenkp"].ToString();
					s_sovaovien=r1["sovaovien"].ToString();
                    s_denngay = r1["denngay"].ToString();
                    s_noicap = r1["mabv"].ToString();
                    tungay = r1["tungay"].ToString();
                    ngay1 = r1["ngay1"].ToString();
                    ngay2 = r1["ngay2"].ToString();
                    ngay3 = r1["ngay3"].ToString();
                    traituyen = int.Parse(r1["traituyen"].ToString());
				}
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void Filter(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				sql="tenkp like '%"+ten.Trim()+"%'";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			mabn.Enabled=ena;
			hoten.Enabled=ena;
			madoituong.Enabled=ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (ena && l_maql==0)
			{
                ten.Text = ma.Text = namsinh.Text = ""; traituyen = 0;
				s_noicap=ngay1=ngay2=ngay3=tungay=hoten.Text=mabn.Text=sothe.Text=s_sovaovien="";
			}
			else butMoi.Focus();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            l_maql = 0; l_mavaovien = 0;
			bNew=true;
			ena_object(true);
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
				if (dataGrid1[dataGrid1.CurrentCell.RowNumber,7].ToString()=="x")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"),LibMedi.AccessData.Msg);
					return;
				}
			}
			catch{}
			ena_object(true);
			bNew=false;
			mabn.Enabled=false;hoten.Enabled=false;
			ma.Focus();
		}

		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
				madoituong.Focus();
				return false;
			}
			r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
            if (r == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"), LibMedi.AccessData.Msg);
                mabn.Focus();
                return false;
            }
            else
            {
                s_denngay = r["denngay"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                l_idkhoa = decimal.Parse(r["id"].ToString());
            }
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),LibMedi.AccessData.Msg);
				if (mabn.Text=="") mabn.Focus();
				else if (hoten.Text=="") hoten.Focus();
				return false;
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
            int itable = m.tableid(m.mmyy(s_ngay), "tiepdon");
			if (!kiemtra()) return;
			if (ma.Text!="" && ten.Text!="")
			{
                string ngay = s_ngay + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                int tuoi = int.Parse(s_ngay.Substring(6, 4)) - ((namsinh.Text == "") ? int.Parse(s_ngay.Substring(6, 4)) : int.Parse(namsinh.Text));
                if (bNew) l_maql = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", mabn.Text + "^" + l_maql.ToString() + "^" + ma.Text + "^" + ngay + "^" + madoituong.SelectedValue.ToString() + "^" + s_sovaovien + "^" + tuoi.ToString().PadLeft(3, '0') + "0" + "^" + i_userid.ToString() + "^" + "0" + "^" + LibMedi.AccessData.Khoa.ToString()+"^"+ "0");
                }
                itable = m.tableid(m.mmyy(s_ngay), "khoacdkham");
                if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + s_makp + "^" + ngay + "^" + i_userid.ToString());
                }
				if (i_sokham!=3 && s_sovaovien=="" && bNew)
					s_sovaovien=m.get_sokham(s_ngay,ma.Text,i_sokham).ToString();
                string nam = m.get_mabn_nam(mabn.Text);
                if (nam.IndexOf(m.mmyy(s_ngay)) == -1) m.execute_data("update " + user + ".btdbn set nam='" + nam + m.mmyy(s_ngay) + "+" + " where mabn='" + mabn.Text + "'");
				m.upd_khoacdkham(mabn.Text,l_mavaovien,l_maql,s_makp,ngay,i_userid);
				m.upd_tiepdon(mabn.Text,l_mavaovien,l_maql,ma.Text,ngay,int.Parse(madoituong.SelectedValue.ToString()),s_sovaovien,tuoi.ToString().PadLeft(3,'0')+"0",i_userid,0,LibMedi.AccessData.Khoa,0);
				if (dtdt.Rows[madoituong.SelectedIndex]["sothe"].ToString()!="0" && sothe.Text!="") 
                    m.upd_bhyt(s_ngay,mabn.Text,l_maql,sothe.Text,s_denngay,s_noicap,0,tungay,ngay1,ngay2,ngay3,traituyen);
                if (bNew && bKhamchuyen_chidinh)
                {
                    DataRow r = m.getrowbyid(dt, "mavp<>0 and makp='" + ma.Text + "'");
                    if (r != null)
                    {
                        int mavp = int.Parse(r["mavp"].ToString());
                        r = m.getrowbyid(dtg, "id=" + mavp);
                        if (r != null)
                        {
                            string gia = m.field_gia(madoituong.SelectedValue.ToString());
                            decimal d_dongia = decimal.Parse(r[gia].ToString());
                            decimal id = v.get_id_chidinh;
                            v.upd_chidinh(id, mabn.Text,l_mavaovien,l_maql, l_idkhoa, s_ngay, v.iNgoaitru, ma.Text,
                                int.Parse(madoituong.SelectedValue.ToString()), mavp, 1, d_dongia, 0, i_userid, 0, 0,id, "", "", "",1,"");
                        }
                    }
                }
				updrec();
			}
			ena_object(false);
		}

		private void updrec()
		{
			r=m.getrowbyid(ds.Tables[0],"maql="+l_maql);
			if (r==null)
			{
				DataRow r1=ds.Tables[0].NewRow();
				r1["mabn"]=mabn.Text;
                r1["mavaovien"] = l_mavaovien;
				r1["maql"]=l_maql;
				r1["hoten"]=hoten.Text;
				r1["namsinh"]=namsinh.Text;
				r1["makp"]=ma.Text;
				r1["tenkp"]=ten.Text;
				r1["sothe"]=sothe.Text;
				r1["sovaovien"]=s_sovaovien;
				r1["madoituong"]=madoituong.SelectedValue.ToString();
				r1["doituong"]=madoituong.Text;
				r1["done"]="";
                r1["denngay"]=s_denngay;
                r1["mabv"]=s_noicap;
                r1["tungay"]=tungay;
                r1["ngay1"]=ngay1;
                r1["ngay2"]=ngay2;
                r1["ngay3"]=ngay3;
                r1["traituyen"]=traituyen;
				ds.Tables[0].Rows.Add(r1);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("maql="+l_maql);
				if (dr.Length>0)
				{
                    dr[0]["mavaovien"] = l_mavaovien;
					dr[0]["makp"]=ma.Text;
					dr[0]["tenkp"]=ten.Text;
					dr[0]["sothe"]=sothe.Text;
					dr[0]["madoituong"]=madoituong.SelectedValue.ToString();
					dr[0]["doituong"]=madoituong.Text;
                    dr[0]["denngay"] = s_denngay;
                    dr[0]["mabv"] = s_noicap;
                    dr[0]["tungay"] = tungay;
                    dr[0]["ngay1"] = ngay1;
                    dr[0]["ngay2"] = ngay2;
                    dr[0]["ngay3"] = ngay3;
                    dr[0]["traituyen"] = traituyen;
				}
			}
		}
		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
				int i_row=dataGrid1.CurrentCell.RowNumber;
				if (dataGrid1[i_row,7].ToString()=="x")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"),LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_maql=decimal.Parse(dataGrid1[i_row,0].ToString());
                    int itable = m.tableid(m.mmyy(s_ngay), "khoacdkham");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del",m.fields(xxx+".khoacdkham","maql="+l_maql));
					m.execute_data("delete from "+xxx+".khoacdkham where maql="+l_maql);
                    itable = m.tableid(m.mmyy(s_ngay), "tiepdon");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".tiepdon", "maql=" + l_maql));
                    m.execute_data("delete from " + xxx + ".tiepdon where maql=" + l_maql);
                    m.execute_data("delete from " + xxx + ".bhyt where maql=" + l_maql);
                    if (bKhamchuyen_chidinh)
                    {
                        DataRow r = m.getrowbyid(dt, "mavp<>0 and makp='" + ma.Text + "'");
                        if (r != null)
                        {
                            int mavp = int.Parse(r["mavp"].ToString());
                            r = m.getrowbyid(dtg, "id=" + mavp);
                            if (r != null)
                            {
                                decimal id = get_id_chidinh(m.mmyy(s_ngay), l_maql, mavp, v.iNgoaitru, ma.Text);
                                m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_chidinh where id=" + id);
                            }
                        }
                    }
					m.delrec(ds.Tables[0],"maql="+l_maql);
					ref_text();
				}
			}
			catch{}
		}

        private decimal get_id_chidinh(string mmyy, decimal m_maql, int m_mavp, int m_loai, string makp)
        {
            ds = m.get_data("select id from " + user + mmyy + ".v_chidinh where maql=" + m_maql + " and mavp=" + m_mavp + " and loai=" + m_loai + " and makp='" + makp + "'");
            if (ds.Tables[0].Rows.Count > 0) return decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            else return 0;
        }

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				try
				{
					DataRow r=m.getrowbyid(dt,"makp='"+ma.Text+"'");
					if (r!=null)
					{
						ten.Text=r["tenkp"].ToString();
						ma.Text=r["makp"].ToString();
					}
				}
				catch{ma.Text="";ten.Text="";}
			}
		}

		private void mavp_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="")
			{
				sql="makp='"+ma.Text+"'";
				DataRow r=m.getrowbyid(dt,sql);
				if (r!=null) ten.Text=r["tenkp"].ToString();
			}
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void Filt_hoten(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listHoten.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listHoten.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listHoten.Visible) listHoten.Focus();
				else SendKeys.Send("{Tab}");
			}				
		}

		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				listHoten.BrowseToDanhmuc(hoten,mabn,madoituong);
			}
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butMoi.Focus();
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				i_madoituong=int.Parse(r["madoituong"].ToString());
				madoituong.SelectedValue=i_madoituong.ToString();
				sothe.Text=r["sothe"].ToString();
                s_denngay = r["denngay"].ToString();
                s_noicap = r["mabv"].ToString();
                tungay = r["tungay"].ToString();
                ngay1 = r["ngay1"].ToString();
                ngay2 = r["ngay2"].ToString();
                ngay3 = r["ngay3"].ToString();
                traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
			}
			else{l_maql=0;hoten.Text=namsinh.Text=sothe.Text="";}
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) mabn_Validated(null,null);
		}

        private void butIn_Click(object sender, EventArgs e)
        {
            fprint("rptChidinhk.rpt", false);
        }
        private void fprint(string tenfile, bool chitiet)
        {
            if (bAdminInlaiphieuchidinh)
            {
                if (!m.bAdminHethong(i_userid) && s_ngay.Substring(0, 10) != m.ngayhienhanh_server.Substring(0, 10))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền in lại chỉ định của ngày trước !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            string s_id = "";
            string xxx = m.user + m.mmyy(s_ngay);
            if (bChidinh_dain_khongchohuy)
            {
                if (s_id.Trim().Trim(',') == "")
                {
                    foreach (DataRow r1 in ds.Tables[0].Rows)
                    {
                        sql = "update " + xxx + ".v_chidinh set lan=lan+1 where id=" + decimal.Parse(r1["id"].ToString());
                        m.execute_data(sql);
                    }
                }
                else
                {
                    sql = " update " + xxx + ".v_chidinh set lan=lan+1 where id in (" + s_id.Trim().Trim(',') + ")";
                    m.execute_data(sql);
                }
            }

           
            //
            string sophieu = "";
            //if (bSophieu_chidinh) sophieu = "CD" + s_ngay.Substring(8, 2) + s_ngay.Substring(3, 2) + s_ngay.Substring(0, 2) + m.get_sophieucls(m.mmyy(s_ngay), mabn.Text, l_mavaovien, s_ngay.Substring(0, 10), 1, 0).ToString().PadLeft(4, '0');
            sql = "select ";
            if (bChidinh_loaivp) sql += "e.ten as nhomvp,";
            else sql += "f.ten as nhomvp,";
            sql += " e.ten as tenloaivp, e.stt as sttloai, f.ten as tennhomvp, f.stt as sttnhom, ";
            sql += "a.mabn,g.hoten,";
            sql += int.Parse(s_ngay.Substring(6, 4)) + "-to_number(g.namsinh,'0000') as tuoi,";
            sql += "trim(g.sonha)||' '||trim(g.thon)||' '||trim(j.tenpxa)||','||trim(i.tenquan)||','||trim(h.tentt) as diachi,";
            sql += "case when g.phai=0 then 'Nam' else 'Nữ' end as phai,d.tenkp,b.ten,b.dvt,to_number(1,9) as soluong,";
            sql += "ba.chandoan,'' as maicd,";
            sql += "'' as giuong,";
            sql += " '' as tinhtrang,'' as thuchien,";
            sql += " case when x.sothe is null then x1.sothe else x.sothe end as sothe,";
            sql += " case when x.tungay is null then to_char(x1.tungay,'dd/mm/yyyy')  else to_char(x.tungay,'dd/mm/yyyy') end as tungay,";
            sql += " case when x.denngay is null then to_char(x1.denngay,'dd/mm/yyyy')  else to_char(x.denngay,'dd/mm/yyyy') end as denngay,";
            sql += " case when y.tenbv is null then y1.tenbv else y.tenbv end as noigioithieu,";
            sql += "'' as tenbs,ba.mabs";
            sql += ", a.madoituong,z.doituong,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngay,d.mavp,b.chenhlech,b.gia_th,b.gia_bh,b.gia_dv,b.gia_cs,b.gia_nn,b.gia_ksk, '' as ghichu";
            sql += ", ba.loaiba, case when x.traituyen is null then (case when x1.traituyen is null then 0 else x1.traituyen end) else x.traituyen end traituyen ";
            sql += ", case when (lh.tuoivao is null) then '0000' else lh.tuoivao end as tuoivao, lh.cholam ";
            sql += " from xxx.tiepdon a "; 
            sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
            sql += " inner join " + user + ".v_giavp b on d.mavp=b.id ";
            sql += " inner join " + user + ".v_loaivp e on b.id_loai=e.id ";
            sql += " inner join " + user + ".v_nhomvp f on e.id_nhom=f.ma ";
            sql += " inner join " + user + ".btdbn g on a.mabn=g.mabn ";
            sql += " inner join " + user + ".btdtt h on g.matt=h.matt ";
            sql += " inner join " + user + ".btdquan i on g.maqu=i.maqu ";
            sql += " inner join " + user + ".btdpxa j on g.maphuongxa=j.maphuongxa ";
            if (s_table != "xxx.tiepdon") sql += " left join " + user + ".dmbs p on a.mabs=p.ma ";
            sql += " left join xxx.bhyt x on a.maql=x.maql ";
            sql += " left join " + user + ".bhyt x1 on a.maql=x1.maql ";
            sql += " left join " + user + ".dmnoicapbhyt y on x.mabv=y.mabv";
            sql += " left join " + user + ".dmnoicapbhyt y1 on x1.mabv=y1.mabv";
            sql += " inner join " + user + ".doituong z on a.madoituong=z.madoituong ";
            sql += " left join " + user + ".benhandt ba on ba.maql=a.maql ";
            sql += " left join xxx.lienhe lh on a.maql=lh.maql";
            sql += " where a.mabn='" + mabn.Text + "' and d.makp='"+ma.Text+"'";
            sql += " and a.maql=" + l_maql;
         
            DataSet dstmp = m.get_data_nam(m.mmyy(s_ngay), sql);
            if (dstmp.Tables[0].Rows.Count > 0)
            {
                if (i_madoituong == 1 && dstmp.Tables[0].Select("chenhlech=1").Length > 0)
                {
                    foreach (DataRow r1 in dstmp.Tables[0].Select("chenhlech=1 and madoituong=" + i_tunguyen, "mabn,ngay,mavp"))
                        if (r1[m.field_gia(i_tunguyen.ToString())].ToString() != r1["gia_bh"].ToString())
                            m.delrec(dstmp.Tables[0], "mabn='" + r1["mabn"].ToString() + "' and mavp=" + int.Parse(r1["mavp"].ToString()) + " and ngay='" + r1["ngay"].ToString() + "' and madoituong=" + i_tunguyen);
                    dstmp.AcceptChanges();
                }

                dstmp.Tables[0].Columns.Add("sophieu");
                if (bSophieu_chidinh) foreach (DataRow r in dstmp.Tables[0].Rows) r["sophieu"] = sophieu;
                if (chitiet)
                {
                    DataSet dst = new DataSet();
                    dst = dstmp.Copy();
                    dstmp.Clear();
                    decimal sl = 0, n = 0;
                    DataRow r;
                    foreach (DataRow r1 in dst.Tables[0].Rows)
                    {
                        sl = decimal.Parse(r1["soluong"].ToString());
                        n = sl;
                        for (int i = 0; i < Convert.ToInt16(n); i++)
                        {
                            r = dstmp.Tables[0].NewRow();
                            for (int j = 0; j < dst.Tables[0].Columns.Count; j++) r[j] = r1[j].ToString();
                            r["soluong"] = Math.Min(sl, 1);
                            r["ngay"] = m.DateToString("dd/MM/yyyy", m.StringToDate(r1["ngay"].ToString().Substring(0, 10)).AddDays(i));
                            dstmp.Tables[0].Rows.Add(r);
                            sl -= 1;
                        }
                    }
                }
                string s_cdkemtheo = m.f_get_cdkemtheo(s_ngay, l_maql, 4);
                if (s_cdkemtheo.Trim().Trim(',') != "")
                {
                    foreach (DataRow dr in dstmp.Tables[0].Rows)
                    {
                        dr["chandoan"] += ((dr["chandoan"].ToString().Trim() == "") ? "" : ", ") + s_cdkemtheo;
                    }
                }
                if (chkXml.Checked)
                {
                    if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                    dstmp.WriteXml("..//xml//chidinh.xml", XmlWriteMode.WriteSchema);
                }
                dllReportM.frmReport f = new dllReportM.frmReport(m, dstmp, s_ngay.Substring(0, 10), tenfile);
                f.ShowDialog();
            }
        }

	}
}
