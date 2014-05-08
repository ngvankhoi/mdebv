using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace DllPhonggiuong
{
	public class frmChuyenkhoa : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.DateTimePicker ngay;
		private MaskedTextBox.MaskedTextBox maicd;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.TextBox khoaden;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.ComboBox tenkhoaden;
		private AccessData m;
		private string m_mabn,m_hoten,m_namsinh,m_makp,sql,m_mabs,m_tuoivao,m_giuong,m_ngay,m_chandoan,m_maicd,s_maicd,s_ngay,m_ngayra,m_khoacuoi,m_tenkhoacuoi;
		private long m_maql,m_id;
		private DataTable dt=new DataTable();
		private int m_userid,m_maba,songay;
		public bool upd=false;
		private LibList.List listICD;
		private DataTable dticd=new DataTable();
		private System.ComponentModel.Container components = null;

		public frmChuyenkhoa(AccessData acc,string mabn,string hoten,string namsinh,string makp,long maql,int userid,int maba,string mabs,string tuoivao,string giuong,string ngay,string ngayra,string khoacuoi,string tenkhoacuoi)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			m_mabn=mabn;
			m_hoten=hoten;
			m_namsinh=namsinh;
			m_makp=makp;
			m_maql=maql;
			m_userid=userid;
			m_maba=maba;
			m_mabs=mabs;
			m_tuoivao=tuoivao;
			m_giuong=giuong;
			m_ngay=ngay;
			m_ngayra=ngayra;
			m_khoacuoi=khoacuoi;
			m_tenkhoacuoi=tenkhoacuoi;
		}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChuyenkhoa));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.mabn = new System.Windows.Forms.TextBox();
			this.hoten = new System.Windows.Forms.TextBox();
			this.namsinh = new System.Windows.Forms.TextBox();
			this.makp = new System.Windows.Forms.TextBox();
			this.khoaden = new System.Windows.Forms.TextBox();
			this.tenkp = new System.Windows.Forms.ComboBox();
			this.tenkhoaden = new System.Windows.Forms.ComboBox();
			this.ngay = new System.Windows.Forms.DateTimePicker();
			this.maicd = new MaskedTextBox.MaskedTextBox();
			this.chandoan = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.butMoi = new System.Windows.Forms.Button();
			this.butSua = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.listICD = new LibList.List();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(58, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(192, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(440, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Năm sinh :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(18, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Khoa chuyển đi :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(248, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 5;
			this.label5.Text = "Ngày giờ chuyển :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(448, 35);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "Khoa đến :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(-10, 59);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(116, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "Chẩn đoán chuyển :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mabn
			// 
			this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn.Enabled = false;
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(103, 11);
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(73, 21);
			this.mabn.TabIndex = 0;
			this.mabn.Text = "";
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(248, 11);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(168, 21);
			this.hoten.TabIndex = 1;
			this.hoten.Text = "";
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(512, 11);
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(40, 21);
			this.namsinh.TabIndex = 2;
			this.namsinh.Text = "";
			// 
			// makp
			// 
			this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makp.Enabled = false;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(103, 35);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(24, 21);
			this.makp.TabIndex = 3;
			this.makp.Text = "";
			// 
			// khoaden
			// 
			this.khoaden.BackColor = System.Drawing.SystemColors.HighlightText;
			this.khoaden.Enabled = false;
			this.khoaden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.khoaden.Location = new System.Drawing.Point(512, 35);
			this.khoaden.Name = "khoaden";
			this.khoaden.Size = new System.Drawing.Size(24, 21);
			this.khoaden.TabIndex = 7;
			this.khoaden.Text = "";
			this.khoaden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoaden_KeyDown);
			this.khoaden.Validated += new System.EventHandler(this.khoaden_Validated);
			// 
			// tenkp
			// 
			this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenkp.Enabled = false;
			this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkp.Location = new System.Drawing.Point(129, 35);
			this.tenkp.Name = "tenkp";
			this.tenkp.TabIndex = 4;
			this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
			// 
			// tenkhoaden
			// 
			this.tenkhoaden.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkhoaden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenkhoaden.Enabled = false;
			this.tenkhoaden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkhoaden.Location = new System.Drawing.Point(538, 35);
			this.tenkhoaden.Name = "tenkhoaden";
			this.tenkhoaden.TabIndex = 8;
			this.tenkhoaden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkhoaden_KeyDown);
			this.tenkhoaden.SelectedIndexChanged += new System.EventHandler(this.tenkhoaden_SelectedIndexChanged);
			// 
			// ngay
			// 
			this.ngay.CustomFormat = "dd/MM/yyyy HH:mm";
			this.ngay.Enabled = false;
			this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.ngay.Location = new System.Drawing.Point(341, 35);
			this.ngay.Name = "ngay";
			this.ngay.Size = new System.Drawing.Size(112, 21);
			this.ngay.TabIndex = 6;
			this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
			this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
			// 
			// maicd
			// 
			this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.maicd.Enabled = false;
			this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maicd.Location = new System.Drawing.Point(103, 59);
			this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
			this.maicd.MaxLength = 9;
			this.maicd.Name = "maicd";
			this.maicd.Size = new System.Drawing.Size(57, 21);
			this.maicd.TabIndex = 9;
			this.maicd.Text = "";
			this.maicd.Validated += new System.EventHandler(this.maicd_Validated);
			// 
			// chandoan
			// 
			this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.chandoan.Enabled = false;
			this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chandoan.Location = new System.Drawing.Point(162, 59);
			this.chandoan.Name = "chandoan";
			this.chandoan.Size = new System.Drawing.Size(496, 21);
			this.chandoan.TabIndex = 10;
			this.chandoan.Text = "";
			this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chandoan_KeyDown);
			this.chandoan.Validated += new System.EventHandler(this.chandoan_Validated);
			this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(8, 72);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(648, 232);
			this.dataGrid1.TabIndex = 17;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(141, 312);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(75, 28);
			this.butMoi.TabIndex = 13;
			this.butMoi.Text = "        &Thêm";
			this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(576, 312);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(75, 28);
			this.butSua.TabIndex = 14;
			this.butSua.Text = "         &Sửa";
			this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Visible = false;
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(218, 312);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(75, 28);
			this.butLuu.TabIndex = 11;
			this.butLuu.Text = "         &Lưu";
			this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(295, 312);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(75, 28);
			this.butBoqua.TabIndex = 12;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(372, 312);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(75, 28);
			this.butHuy.TabIndex = 15;
			this.butHuy.Text = "         &Hủy";
			this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(449, 312);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 16;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// listICD
			// 
			this.listICD.ColumnCount = 0;
			this.listICD.Location = new System.Drawing.Point(56, 328);
			this.listICD.MatchBufferTimeOut = 1000;
			this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listICD.Name = "listICD";
			this.listICD.Size = new System.Drawing.Size(75, 17);
			this.listICD.TabIndex = 222;
			this.listICD.TextIndex = -1;
			this.listICD.TextMember = null;
			this.listICD.ValueIndex = -1;
			this.listICD.Visible = false;
			// 
			// frmChuyenkhoa
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 357);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listICD,
																		  this.butKetthuc,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butSua,
																		  this.butMoi,
																		  this.chandoan,
																		  this.maicd,
																		  this.label7,
																		  this.dataGrid1,
																		  this.ngay,
																		  this.tenkhoaden,
																		  this.tenkp,
																		  this.khoaden,
																		  this.makp,
																		  this.namsinh,
																		  this.hoten,
																		  this.mabn,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmChuyenkhoa";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thông tin chuyển khoa";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChuyenkhoa_KeyDown);
			this.Load += new System.EventHandler(this.frmChuyenkhoa_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmChuyenkhoa_Load(object sender, System.EventArgs e)
		{
			dticd=m.get_data("select cicd10,vviet from icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			songay=m.Ngaylv_Ngayht;
			mabn.Text=m_mabn;
			hoten.Text=m_hoten;
			namsinh.Text=m_namsinh;
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			tenkp.DataSource=m.get_data("select * from btdkp_bv where loai=0 order by makp").Tables[0];

			tenkhoaden.DisplayMember="TENKP";
			tenkhoaden.ValueMember="MAKP";
			load_makp();
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
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
			TextCol.MappingName = "khoachuyen";
			TextCol.HeaderText = "Khoa chuyển đi";
			TextCol.Width = 110;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngaychuyen";
			TextCol.HeaderText = "Ngày chuyển";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkhoaden";
			TextCol.HeaderText = "Khoa đến";
			TextCol.Width = 110;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width = 240;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maicd";
			TextCol.HeaderText = "ICD";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "khoaden";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void load_grid()
		{
			sql="select b.tenkp as khoachuyen,to_char(a.ngaychuyen,'dd/mm/yyyy hh24:mi') as ngaychuyen,";
			sql+=" c.tenkp as tenkhoaden,a.chandoan,a.maicd,a.makp,a.khoaden,a.id from chuyenkhoa a,btdkp_bv b,btdkp_bv c";
			sql+=" where a.makp=b.makp and a.khoaden=c.makp and a.maql="+m_maql+" order by ngaychuyen,id";
			dt=m.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
		}

		private void load_makp()
		{
			tenkhoaden.DataSource=m.get_data("select * from btdkp_bv where makp<>'01' and loai=0 and makp<>'"+tenkp.SelectedValue.ToString()+"'"+" order by makp").Tables[0];
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void khoaden_Validated(object sender, System.EventArgs e)
		{	
			try
			{
				tenkhoaden.SelectedValue=khoaden.Text;
			}
			catch{}
		}

		private void khoaden_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Text=tenkp.SelectedValue.ToString();
				load_makp();
			}
			catch{}
		}

		private void tenkhoaden_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				khoaden.Text=tenkhoaden.SelectedValue.ToString();
			}
			catch{}
		}

		private void tenkhoaden_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkhoaden.SelectedIndex==-1) tenkhoaden.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void maicd_Validated(object sender, System.EventArgs e)
		{
			if (maicd.Text!=s_maicd)
			{
				if (maicd.Text=="") chandoan.Text="";
				else chandoan.Text=m.get_vviet(maicd.Text);
				if (chandoan.Text=="" && maicd.Text!="")
				{
					frmDMICD10 f=new frmDMICD10(m,"icd10",maicd.Text,chandoan.Text,true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						chandoan.Text=f.mTen;
						maicd.Text=f.mICD;
					}
				}
				s_maicd=maicd.Text;
			}
		}

		private void chandoan_Validated(object sender, System.EventArgs e)
		{
			if (maicd.Text=="") maicd.Text=m.get_cicd10(chandoan.Text);
			if (!m.bMaicd(maicd.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),LibMedi.AccessData.Msg);
				maicd.Text="";
				maicd.Focus();
			}
		}

		private void chandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
			khoaden.Enabled=ena;
			tenkhoaden.Enabled=ena;
			maicd.Enabled=ena;
			chandoan.Enabled=ena;
			if (ena) chandoan.Enabled=m.bChandoan;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			m_chandoan="";
			m_maicd="";
		}	

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			string s_makp="";
			m_chandoan="";
			DataTable dt1=m.get_data("select makp,to_char(ngaychuyen,'dd/mm/yyyy hh24:mi') as ngay,khoaden,chandoan,maicd from chuyenkhoa where maql="+m_maql+" order by ngaychuyen desc,id desc").Tables[0];
			if (dt1.Rows.Count!=0)
			{
				s_makp=dt1.Rows[0]["khoaden"].ToString();
				m_ngay=dt1.Rows[0]["ngay"].ToString();
				m_chandoan=dt1.Rows[0]["chandoan"].ToString();
				m_maicd=dt1.Rows[0]["maicd"].ToString();
				dt1=m.get_data("select makp,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,chandoan,maicd from nhapkhoa where maql="+m_maql+" order by ngay desc").Tables[0];
				if (dt1.Rows.Count!=0)
				{
					m_ngay=dt1.Rows[0]["ngay"].ToString();
					m_chandoan=dt1.Rows[0]["chandoan"].ToString();
					m_maicd=dt1.Rows[0]["maicd"].ToString();
				}
			}
			s_makp=(s_makp!="")?s_makp:m_makp;
			tenkp.SelectedValue=s_makp;
			if (m_khoacuoi!="") tenkhoaden.SelectedValue=m_khoacuoi;
			else tenkhoaden.SelectedIndex=-1;
			maicd.Text="";
			chandoan.Text="";
			s_maicd="";
			s_ngay=ngay.Text;
			ena_object(true);
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_id=long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,5].ToString());
				m_ngay=m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from nhapkhoa where id="+m_id).Tables[0].Rows[0][0].ToString();
			}
			catch{}
			m_chandoan=chandoan.Text;
			ngay.Focus();
			ena_object(true);
		}

		private bool kiemtra()
		{
			if (tenkhoaden.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập khoa đến !"),LibMedi.AccessData.Msg);
				khoaden.Focus();
				return false;
			}

			if (maicd.Text=="" || chandoan.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán chuyển !"),LibMedi.AccessData.Msg);
				maicd.Focus();
				return false;
			}
			if (!m.Kiemtra_maicd(dticd,maicd.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
				maicd.Focus();
				return false;
			}
			if (!m.Kiemtra_tenbenh(dticd,chandoan.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
				chandoan.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			m_id=m.get_id(m_maql,makp.Text,m_ngay);
			if (m_chandoan!="")
				m.upd_xuatkhoa(m_id,ngay.Text,3,5,m_chandoan,m_maicd,m_mabs,0,0,0,m_userid);
			else
				m.upd_xuatkhoa(m_id,ngay.Text,3,5,chandoan.Text,maicd.Text,m_mabs,0,0,0,m_userid);
			m.upd_chuyenkhoa(m_id,m_mabn,m_maql,makp.Text,ngay.Text,khoaden.Text,chandoan.Text,maicd.Text,m_userid);
			m_id=m.get_id(m_maql,khoaden.Text,ngay.Text);
			m.upd_nhapkhoa(m_id,m_mabn,m_maql,khoaden.Text,m_maba,ngay.Text,m_tuoivao,m_giuong,makp.Text,chandoan.Text,maicd.Text,m_mabs,1,m_userid);
			ena_object(false);
			load_grid();
			upd=true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin đang chọn !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					m_id=long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,5].ToString());
					m.delrec(dt,"id="+m_id);
					m.execute_data("delete from chuyenkhoa where id="+m_id);
					load_grid();
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_khoacuoi!="")
				{
					if (m.get_data("select khoaden from chuyenkhoa where maql="+m_maql+" order by ngaychuyen desc").Tables[0].Rows[0][0].ToString()!=m_khoacuoi)
					{
						MessageBox.Show(lan.Change_language_MessageText("Khoa cuối phải là :")+m_tenkhoacuoi+" !",LibMedi.AccessData.Msg);
						butMoi.Focus();
						return;
					}
				}
			}
			catch{}
			this.Close();
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				string s_ngay=dataGrid1[i,1].ToString();
				int dd=int.Parse(s_ngay.Substring(0,2));
				int mm=int.Parse(s_ngay.Substring(3,2));
				int yyyy=int.Parse(s_ngay.Substring(6,4));
				int hh=int.Parse(s_ngay.Substring(11,2));
				int mi=int.Parse(s_ngay.Substring(14,2));
				ngay.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
				tenkp.SelectedValue=dataGrid1[i,6].ToString();
				tenkhoaden.SelectedValue=dataGrid1[i,7].ToString();
				chandoan.Text=dataGrid1[i,3].ToString();
				maicd.Text=dataGrid1[i,4].ToString();
				s_maicd=maicd.Text;
				s_ngay=ngay.Text;
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (ngay.Text!=s_ngay)
			{
				if (!m.bNgaygio(ngay.Text,m_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày chuyển khoa không được nhỏ hơn ngày vào khoa !"),LibMedi.AccessData.Msg);
					ngay.Focus();
					return;
				}
				if (m_ngayra!="")
				{
					if (!m.bNgaygio(m_ngayra,ngay.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày chuyển khoa không được lớn hơn ngày ra viện !"),LibMedi.AccessData.Msg);
						ngay.Focus();
						return;
					}
				}
				if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày chuyển khoa không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",LibMedi.AccessData.Msg);
					ngay.Focus();
					return;
				}
			}
		}

		private void frmChuyenkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
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

		private void chandoan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chandoan)
			{
				Filt_ICD(chandoan.Text);
				listICD.BrowseToICD10(chandoan,maicd,butLuu,maicd.Location.X,maicd.Location.Y+maicd.Height,maicd.Width+chandoan.Width+2,maicd.Height);
			}		
		}
	}
}
