using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for rptThekho.
	/// </summary>
	public class frmDonthuoc_bacsy : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private long l_id;
		private DataSet dsdm=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtll=new DataTable();
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged;
		int checkCol=0;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.ComboBox tenbs;
		private MaskedTextBox.MaskedTextBox ma;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox lmabs;
		private System.Windows.Forms.ComboBox lmaicd;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butSua;
		private LibList.List listICD;
		private string user,sql;
		private int i_nhom=5;
		private bool bDanhmuc_nhathuoc;
		private System.Windows.Forms.Button butThem;
        private Button butTuongtac;
        private TextBox ghichu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDonthuoc_bacsy(LibMedi.AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m=acc;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonthuoc_bacsy));
            this.butXoa = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.mabs = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.ComboBox();
            this.ma = new MaskedTextBox.MaskedTextBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lmabs = new System.Windows.Forms.ComboBox();
            this.lmaicd = new System.Windows.Forms.ComboBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.listICD = new LibList.List();
            this.butThem = new System.Windows.Forms.Button();
            this.butTuongtac = new System.Windows.Forms.Button();
            this.ghichu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(415, 500);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(60, 25);
            this.butXoa.TabIndex = 10;
            this.butXoa.Text = "     &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(620, 500);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(6, 275);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(783, 196);
            this.dataGrid1.TabIndex = 7;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Diễn giải :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tim
            // 
            this.tim.Enabled = false;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(5, 476);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(784, 21);
            this.tim.TabIndex = 7;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(229, 500);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 11;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(5, 30);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(784, 258);
            this.dataGrid2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Bác sỹ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(52, 3);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 2;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(91, 3);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(191, 21);
            this.tenbs.TabIndex = 3;
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(337, 3);
            this.ma.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.ma.MaxLength = 9;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(48, 21);
            this.ma.TabIndex = 4;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(386, 3);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(400, 21);
            this.ten.TabIndex = 5;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(278, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 31;
            this.label2.Text = "Tên bệnh :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmabs
            // 
            this.lmabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lmabs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lmabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmabs.Location = new System.Drawing.Point(52, 3);
            this.lmabs.Name = "lmabs";
            this.lmabs.Size = new System.Drawing.Size(230, 21);
            this.lmabs.TabIndex = 0;
            this.lmabs.SelectedIndexChanged += new System.EventHandler(this.lmabs_SelectedIndexChanged);
            this.lmabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lmabs_KeyDown);
            // 
            // lmaicd
            // 
            this.lmaicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lmaicd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lmaicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmaicd.Location = new System.Drawing.Point(332, 145);
            this.lmaicd.Name = "lmaicd";
            this.lmaicd.Size = new System.Drawing.Size(450, 21);
            this.lmaicd.TabIndex = 1;
            this.lmaicd.SelectedIndexChanged += new System.EventHandler(this.lmaicd_SelectedIndexChanged);
            this.lmaicd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lmaicd_KeyDown);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(291, 500);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 12;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butTiep
            // 
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(105, 500);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(60, 25);
            this.butTiep.TabIndex = 13;
            this.butTiep.Text = "     &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(558, 500);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 15;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(167, 500);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 14;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(632, 548);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 40;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(353, 500);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 9;
            this.butThem.Text = "     &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butTuongtac
            // 
            this.butTuongtac.Image = ((System.Drawing.Image)(resources.GetObject("butTuongtac.Image")));
            this.butTuongtac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTuongtac.Location = new System.Drawing.Point(477, 500);
            this.butTuongtac.Name = "butTuongtac";
            this.butTuongtac.Size = new System.Drawing.Size(79, 25);
            this.butTuongtac.TabIndex = 270;
            this.butTuongtac.Text = "Tương tác";
            this.butTuongtac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTuongtac.Click += new System.EventHandler(this.butTuongtac_Click);
            // 
            // ghichu
            // 
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.ForeColor = System.Drawing.Color.Black;
            this.ghichu.Location = new System.Drawing.Point(52, 26);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(734, 21);
            this.ghichu.TabIndex = 6;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // frmDonthuoc_bacsy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.butTuongtac);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.lmabs);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.lmaicd);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.dataGrid2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDonthuoc_bacsy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc theo bác sỹ & tên bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDonthuoc_bacsy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDonthuoc_bacsy_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			bDanhmuc_nhathuoc=m.bDanhmuc_nhathuoc || m.bDanhmucthuocbv;
			i_nhom=(m.bDanhmuc_nhathuoc)?m.nhom_nhathuoc:m.nhom_duoc;
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=m.get_data("select cicd10,vviet from "+user+".icd10 order by cicd10").Tables[0];
			dsdm.ReadXml("..//..//..//xml//d_dmbd.xml");
			dsdm.Tables[0].Columns.Add("Chon",typeof(bool));
			load_grid();
			AddGridTableStyle();

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			tenbs.DisplayMember="HOTEN";
			tenbs.ValueMember="MA";
            tenbs.DataSource = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
			lmabs.DisplayMember="HOTEN";
			lmabs.ValueMember="MABS";
			lmaicd.DisplayMember="VVIET";
			lmaicd.ValueMember="ID";
			load_head();
			load_maicd();
			load_chitiet();
			AddGridTableStyle1();
		}

		private void load_head()
		{
            sql = "select distinct a.mabs,b.hoten from " + user + ".d_theodonll a,"+user+".dmbs b where a.mabs=b.ma";
			lmabs.DataSource=m.get_data(sql).Tables[0];
		}
	
		private void load_maicd()
		{

			if (lmabs.Items.Count>0)
			{
                sql = "select a.*,b.vviet from " + user + ".d_theodonll a," + user + ".icd10 b where a.maicd=b.cicd10 ";
				sql+=" and a.mabs='"+lmabs.SelectedValue.ToString()+"' order by b.cicd10";
				dtll=m.get_data(sql).Tables[0];
				lmaicd.DataSource=dtll;
				l_id=(lmaicd.Items.Count>0)?long.Parse(lmaicd.SelectedValue.ToString()):0;
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsdm.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=5;
					
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
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 365;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = 305;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
				{
					//e.BackBrush = this.disabledBackBrush;
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

		private void load_grid()
		{
			dsdm.Clear();
			if (bDanhmuc_nhathuoc)
			{
				sql="select id,'' as ma,trim(ten)||' '||hamluong as ten,dang,nullif(tenhc,' ') as tenhc from ";
                sql +=user + ".d_dmbd where nhom=" + i_nhom + " order by ten";
			}
            else sql = "select id,'' as ma,ten,dang,nullif(tenhc,' ') as tenhc from " + user + ".d_dmthuoc order by ten";
			dsdm.Merge(m.get_data(sql));
			dataGrid1.DataSource=dsdm.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in dsdm.Tables[0].Rows) row["chon"]=false;
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
                string ten = tim.Text.Trim();
                if (ten.IndexOf("%") != -1) ten = ten.Substring(0, ten.IndexOf("%"));
				if (tim.Text!="")
					dv.RowFilter="ten like '%"+ten+"%' or ma like '%"+ten+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) dataGrid1.Focus();
		}

		private bool kiemtra()
		{
			if (mabs.Text=="")
			{
				mabs.Focus();
				return false;
			}
			if (ma.Text=="")
			{
				ma.Focus();
				return false;
			}
            if (ghichu.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập diễm giải !"), LibMedi.AccessData.Msg);
                ghichu.Focus();
                return false;
            }
			if (dt.Rows.Count==0)
			{
				butThem.Focus();
				return false;
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			l_id=d.get_id_donthuoc_bacsy(mabs.Text,ma.Text);
			if (l_id==0) l_id=d.get_id_donthuoc_bacsy();
            else d.execute_data("delete from " + user + ".d_theodonct where id=" + l_id);
			d.upd_theodonll(l_id,mabs.Text,ma.Text,ghichu.Text,0,dt.Rows.Count,1);
			foreach(DataRow r in dt.Rows) 
                d.upd_theodonct(l_id,int.Parse(r["mabd"].ToString()),decimal.Parse(r["soluong"].ToString()),r["cachdung"].ToString(),int.Parse(r["stt"].ToString()));
			ena_object(false);
			long id=l_id;
			string _mabs=mabs.Text;
			load_head();
			lmabs.SelectedValue=_mabs;
			load_maicd();
			lmaicd.SelectedValue=id.ToString();
			l_id=id;
			load_chitiet();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count>0)
			{
				int i=dataGrid2.CurrentCell.RowNumber;
				m.delrec(dt,"mabd="+int.Parse(dataGrid2[i,0].ToString()));
			}
		}

		private void load_chitiet()
		{
			if (bDanhmuc_nhathuoc)
			{
				sql="select b.stt,b.mabd,'' as ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,nullif(a.tenhc,' ') as tenhc,b.soluong,b.cachdung ";
                sql += " from " + user + ".d_dmbd a," + user + ".d_theodonct b where a.id=b.mabd and b.id=" + l_id +" order by b.stt";
			}
			else
			{
				sql="select b.stt,b.mabd,'' as ma,a.ten,a.dang,nullif(a.tenhc,' ') as tenhc,b.soluong,b.cachdung ";
                sql += " from " + user + ".d_dmthuoc a," + user + ".d_theodonct b where a.id=b.mabd and b.id=" + l_id +" order by b.stt";
			}
			dt=m.get_data(sql).Tables[0];
			dataGrid2.DataSource=dt;
            foreach (DataRow r in m.get_data("select * from " + user + ".d_theodonll where id=" + l_id).Tables[0].Rows)
                ghichu.Text = r["ghichu"].ToString();
		}

		private void AddGridTableStyle1()
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
			dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "Stt";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 250;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = 200;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cachdung";
			TextCol.HeaderText = "Cách dùng";
			TextCol.Width = 170;
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text=="") return;
			ten.Text=m.get_vviet(ma.Text);
			if (ten.Text=="")
			{
				frmDMICD10 f=new frmDMICD10(m,"icd10",ma.Text,ten.Text,true);
				f.ShowDialog();
				if (f.mICD!="")
				{
					ten.Text=f.mTen;
					ma.Text=f.mICD;
				}
			}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				Filt_ICD(ten.Text);
				listICD.BrowseToICD10(ten,ma,tim,ma.Location.X,ma.Location.Y+ma.Height,ma.Width+ten.Width+2,ma.Height);
			}
		}

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			tenbs.SelectedValue=mabs.Text;
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
                if (tenbs.SelectedIndex == -1 && tenbs.Items.Count > 0) tenbs.SelectedIndex = 0;
                if (tenbs.SelectedIndex!=-1) mabs.Text = tenbs.SelectedValue.ToString();
				SendKeys.Send("{Tab}");
			}
		}

		private void lmabs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==lmabs)
			{
				load_maicd();
				load_chitiet();
			}
		}

		private void lmabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void lmaicd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void lmaicd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==lmaicd)
			{
				try
				{
					l_id=long.Parse(lmaicd.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_chitiet();
			}
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			dt.Clear();
            ghichu.Text = "";
			mabs.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (lmabs.Items.Count==0) return;
			ena_object(true);
			mabs.Enabled=false;
			tenbs.Enabled=false;
			ma.Enabled=false;
			ten.Enabled=false;
			mabs.Text=lmabs.SelectedValue.ToString();
			tenbs.SelectedValue=mabs.Text;
			ten.Text=lmaicd.Text;
			DataRow r=m.getrowbyid(dtll,"vviet='"+ten.Text+"'");
			if (r!=null) ma.Text=r["maicd"].ToString();
			dataGrid2.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			load_head();
			load_maicd();
			load_chitiet();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.execute_data("delete from " + user + ".d_theodonll where id=" + l_id);
                m.execute_data("delete from " + user + ".d_theodonct where id=" + l_id);
				load_head();
				load_maicd();
				load_chitiet();
			}
		}

		private void ena_object(bool ena)
		{
			if (ena)
			{
				mabs.Text="";tenbs.SelectedIndex=-1;ma.Text="";ten.Text="";
			}
			lmabs.Visible=!ena;
			lmaicd.Visible=!ena;
			mabs.Enabled=ena;
			ghichu.Enabled=tenbs.Enabled=ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
			tim.Enabled=ena;
			butTiep.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butXoa.Enabled=ena;
			butThem.Enabled=ena;
			butKetthuc.Enabled=!ena;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (dsdm.Tables[0].Select("chon=true").Length>0)
			{
				foreach(DataRow r in dsdm.Tables[0].Select("chon=true")) 
					m.updrec_donthuoc(dt,int.Parse(r["id"].ToString()),r["ten"].ToString(),r["dang"].ToString(),r["tenhc"].ToString(),d.get_stt(dt));
				foreach (DataRow row in dsdm.Tables[0].Rows) row["chon"]=false;
			}
		}

        private void butTuongtac_Click(object sender, EventArgs e)
        {
            testc.clsTuongtac t = new testc.clsTuongtac();
            bool b_tuongtac = t.kiemtra_tuongtac(dt, i_nhom);
            //DataTable dtdmbd = t.get_dmbd(i_nhom.ToString());
            //string s_tenhc1 = t.get_tenhc(dtdmbd, dt);
            //string s_tenhc2 = s_tenhc1; DataTable dtdmhc = t.get_dmhc();
            //t.get_tuongtac(dtdmhc, s_tenhc1, s_tenhc2);
            //string s_tuongtac = "";
            //if (t.s_effect.Trim() != "")
            //{
            //    s_tuongtac = "EFFECT : '" + t.s_tenhc1.ToUpper() + "' " + t.s_effect + " '" + t.s_tenhc2.ToUpper() + "'";
            //    s_tuongtac += "\n";
            //    s_tuongtac += "SEVERITY : " + t.s_severity;
            //    s_tuongtac += "\n";
            //    s_tuongtac += "ACTIONS: " + t.s_actions;
            //    s_tuongtac += "\n";
            //    s_tuongtac += "MECHANISM : " + t.s_mechanism;
            //    s_tuongtac += "\n";
            //    s_tuongtac += "MEC_DETAIL : " + t.s_mec_detail;
            //    MessageBox.Show(s_tuongtac, "Thông báo -  Tương tác thuốc");
            //}
            //else
            //{
            //    MessageBox.Show("Không tìm thấy tương tác", "Thông báo - Tương tác thuốc");
            //}
            //dtdmbd.Dispose();
            //dtdmhc.Dispose();
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void ghichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
	}
}
