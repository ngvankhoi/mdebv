using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmDmbs : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.ComboBox mapk;
		private System.Windows.Forms.Label label4;
		private string user,s_makp,s_mapk,s_userid;
        private int itable,i_userid;
		private bool bNew=false;
		private System.Windows.Forms.ComboBox nhom;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox viettat;
        private Label label7;
        private TextBox password_;
        private Label label8;
        private TextBox dienthoai;
        private TextBox didong;
        private Label label9;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmbs(AccessData acc,string userid,int usrid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_userid = userid; i_userid = usrid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmbs));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.mapk = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.viettat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.password_ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dienthoai = new System.Windows.Forms.TextBox();
            this.didong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(10, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(772, 458);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(511, 493);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 14;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(48, 446);
            this.ma.MaxLength = 4;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(45, 21);
            this.ma.TabIndex = 0;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(240, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(290, 446);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 2;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(442, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.Window;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(488, 446);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(115, 21);
            this.makp.TabIndex = 3;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(211, 493);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 11;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(271, 493);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(331, 493);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 9;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(391, 493);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 10;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(451, 493);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 13;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // mapk
            // 
            this.mapk.BackColor = System.Drawing.SystemColors.Window;
            this.mapk.Enabled = false;
            this.mapk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapk.Location = new System.Drawing.Point(662, 446);
            this.mapk.Name = "mapk";
            this.mapk.Size = new System.Drawing.Size(122, 21);
            this.mapk.TabIndex = 4;
            this.mapk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapk_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(582, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ph. khám :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhom
            // 
            this.nhom.BackColor = System.Drawing.SystemColors.Window;
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Enabled = false;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(48, 469);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(178, 21);
            this.nhom.TabIndex = 5;
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-1, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Nhóm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(91, 446);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 31;
            this.label6.Text = "Viết tắt :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viettat
            // 
            this.viettat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.viettat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.viettat.Enabled = false;
            this.viettat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viettat.Location = new System.Drawing.Point(140, 446);
            this.viettat.MaxLength = 10;
            this.viettat.Name = "viettat";
            this.viettat.Size = new System.Drawing.Size(86, 21);
            this.viettat.TabIndex = 1;
            this.viettat.Validated += new System.EventHandler(this.viettat_Validated);
            this.viettat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(224, 467);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 23);
            this.label7.TabIndex = 32;
            this.label7.Text = "Mật khẩu :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // password_
            // 
            this.password_.BackColor = System.Drawing.SystemColors.HighlightText;
            this.password_.Enabled = false;
            this.password_.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_.Location = new System.Drawing.Point(290, 469);
            this.password_.MaxLength = 10;
            this.password_.Name = "password_";
            this.password_.PasswordChar = '*';
            this.password_.Size = new System.Drawing.Size(152, 21);
            this.password_.TabIndex = 6;
            this.password_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(424, 467);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 23);
            this.label8.TabIndex = 33;
            this.label8.Text = "Đ. thoại :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dienthoai
            // 
            this.dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienthoai.Enabled = false;
            this.dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienthoai.Location = new System.Drawing.Point(488, 469);
            this.dienthoai.MaxLength = 10;
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Size = new System.Drawing.Size(115, 21);
            this.dienthoai.TabIndex = 7;
            this.dienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // didong
            // 
            this.didong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.didong.Enabled = false;
            this.didong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.didong.Location = new System.Drawing.Point(662, 469);
            this.didong.MaxLength = 10;
            this.didong.Name = "didong";
            this.didong.Size = new System.Drawing.Size(122, 21);
            this.didong.TabIndex = 8;
            this.didong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(596, 469);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 23);
            this.label9.TabIndex = 35;
            this.label9.Text = "Di động :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmDmbs
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.dienthoai);
            this.Controls.Add(this.didong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.password_);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.viettat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.mapk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmbs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmbs_KeyDown);
            this.Load += new System.EventHandler(this.frmDm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDm_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user; itable = m.tableid("", "dmbs");
			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			nhom.DataSource=m.get_data("select * from "+user+".nhomnhanvien order by id").Tables[0];

			mapk.DisplayMember="TENKP";
			mapk.ValueMember="MAKP";
            mapk.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];

			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            makp.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=0 order by makp").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
		}

		private void load_grid()
		{
            dt = m.get_data("SELECT a.MA, a.HOTEN,nullif(b.TENKP,' ') as tenkp,nullif(c.TENKP,' ') as TENPK, a.MAKP, a.MAPK,a.nhom,d.ten,a.viettat,a.password_,a.dienthoai,a.didong  FROM " + user + ".DMBS a left join " + user + ".BTDKP_BV b on a.makp=b.makp left join " + user + ".BTDKP_BV c on a.mapk=c.makp left join " + user + ".nhomnhanvien d on a.nhom=d.id ORDER BY a.MA").Tables[0];
			dataGrid1.DataSource=dt;
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
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "viettat";
			TextCol.HeaderText = "Viết tắt";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 240;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenpk";
			TextCol.HeaderText = "Phòng khám";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mapk";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhom";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nhóm";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "password_";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dienthoai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "didong";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
			ma.Enabled=ena;
			viettat.Enabled=ena;
			dienthoai.Enabled=didong.Enabled=password_.Enabled=hoten.Enabled=ena;
			makp.Enabled=ena;
			mapk.Enabled=ena;
			nhom.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			int i=1;
			try
			{
                i = int.Parse(m.get_data("select max(ma) from " + user + ".dmbs").Tables[0].Rows[0][0].ToString()) + 1;
			}
			catch{}
			bNew=true;
			ma.Text=i.ToString().PadLeft(4,'0');
			dienthoai.Text=didong.Text=password_.Text=hoten.Text="";
			viettat.Text="";
			ena_object(true);
			ma.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			bNew=false;
			ena_object(true);
			ma.Enabled=false;
			viettat.Focus();
		}

		private bool kiemtra()
		{
			if (ma.Text=="")
			{
				ma.Focus();
				return false;
			}
			if (hoten.Text=="")
			{
				hoten.Focus();
				return false;
			}
			if (viettat.Text=="") viettat.Text=ma.Text;
//			if (makp.SelectedIndex==-1 && mapk.SelectedIndex==-1)
//			{
//				makp.Focus();
//				return false;
//			}
			if (nhom.SelectedIndex==-1)
			{
				nhom.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
			s_mapk=(mapk.SelectedIndex==-1)?"":mapk.SelectedValue.ToString();
			s_makp=(makp.SelectedIndex==-1)?"":makp.SelectedValue.ToString();
            if (m.get_data("select * from " + user + ".dmbs where ma='" + ma.Text + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", ma.Text + "^" + hoten.Text + "^" + s_makp + "^" + s_mapk + "^" + nhom.SelectedValue.ToString() + "^" + viettat.Text);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
			if (!m.upd_dmbs(ma.Text,hoten.Text,s_makp,s_mapk,int.Parse(nhom.SelectedValue.ToString()),viettat.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin nhân viên !"));
				return;
			}
            m.execute_data("update " + user + ".dmbs set password_='" + password_.Text + "',dienthoai='"+dienthoai.Text+"',didong='"+didong.Text+"' where ma='" + ma.Text + "'");
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            if (m.get_data("select * from " + user + ".xuatvien where mabs='" + ma.Text + "'").Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên bác sĩ đã sử dụng không thể hủy !"),LibMedi.AccessData.Msg);
				return;
			}
			if (dt.Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không thể hủy !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.upd_eve_tables(itable, i_userid, "del");
                m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".dmbs", "ma='" + ma.Text + "'"));
                m.execute_data("delete from " + user + ".dmbs where ma='" + ma.Text + "'");
				load_grid();
			}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			try
			{
				ma.Text=ma.Text.PadLeft(4,'0');
                if (m.get_data("select * from " + user + ".dmbs where ma='" + ma.Text + "'").Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"));
					ma.Focus();
					return;
				}
				if (viettat.Text=="") viettat.Text=ma.Text;
			}
			catch{}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ma.Text=dataGrid1[i,0].ToString();
				viettat.Text=dataGrid1[i,1].ToString();
				hoten.Text=dataGrid1[i,2].ToString();
				makp.SelectedValue=dataGrid1[i,5].ToString();
				mapk.SelectedValue=dataGrid1[i,6].ToString();
				nhom.SelectedValue=dataGrid1[i,7].ToString();
                password_.Text = dataGrid1[i, 9].ToString();
                dienthoai.Text = dataGrid1[i, 10].ToString();
                didong.Text = dataGrid1[i, 11].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			hoten.Text=m.Caps(hoten.Text);
			if (!bNew) return;
            if (m.get_data("select * from " + user + ".dmbs where hoten='" + hoten.Text + "'").Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên này đã có !"));
				hoten.Focus();
				return;
			}
		}

		private void frmDmbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void mapk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");		
		}

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhom.SelectedIndex==-1) nhom.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void viettat_Validated(object sender, System.EventArgs e)
		{
			if (bNew)
			{
                if (m.get_data("select * from " + user + ".dmbs where viettat='" + viettat.Text + "'").Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Viết tắt này đã có !"));
					viettat.Focus();
					return;
				}
			}
		}
	}
}
