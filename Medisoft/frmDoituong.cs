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
	/// Summary description for frmDm.
	/// </summary>
	public class frmDoituong : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private DataTable dt=new DataTable();
		private DataSet ds=new DataSet();
        private DataTable dtdv = new DataTable();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox ngay;
		private System.Windows.Forms.NumericUpDown sothe;
		private System.Windows.Forms.CheckBox mabv;
		private System.Windows.Forms.CheckBox mien;
		private System.Windows.Forms.ComboBox field_gia;
		private System.Windows.Forms.Label label4;
        private int itable, i_userid;
        private string user;
        private CheckBox trasau;
        private CheckBox cholam;
        private TextBox dai;
        private CheckBox chenhlech;
        private Label label5;
        private ComboBox dmdvchitra;
        private CheckBox ngaysinh;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDoituong(LibMedi.AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoituong));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.CheckBox();
            this.sothe = new System.Windows.Forms.NumericUpDown();
            this.mabv = new System.Windows.Forms.CheckBox();
            this.mien = new System.Windows.Forms.CheckBox();
            this.field_gia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trasau = new System.Windows.Forms.CheckBox();
            this.cholam = new System.Windows.Forms.CheckBox();
            this.dai = new System.Windows.Forms.TextBox();
            this.chenhlech = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dmdvchitra = new System.Windows.Forms.ComboBox();
            this.ngaysinh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sothe)).BeginInit();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(489, 320);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(369, 382);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 17;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(36, 312);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(24, 21);
            this.ma.TabIndex = 0;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            this.ma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ma_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(48, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(88, 312);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(144, 21);
            this.ten.TabIndex = 1;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(69, 382);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 14;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(129, 382);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 15;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(189, 382);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 12;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(249, 382);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 13;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(309, 382);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 16;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(195, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Chiều dài :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.Enabled = false;
            this.ngay.Location = new System.Drawing.Point(395, 310);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(128, 22);
            this.ngay.TabIndex = 3;
            this.ngay.Text = "Nhập ngày hết hạn";
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(295, 220);
            this.sothe.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(40, 21);
            this.sothe.TabIndex = 2;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // mabv
            // 
            this.mabv.Enabled = false;
            this.mabv.Location = new System.Drawing.Point(7, 337);
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(116, 19);
            this.mabv.TabIndex = 4;
            this.mabv.Text = "Nhập nơi ĐKKCB";
            this.mabv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // mien
            // 
            this.mien.Enabled = false;
            this.mien.Location = new System.Drawing.Point(121, 338);
            this.mien.Name = "mien";
            this.mien.Size = new System.Drawing.Size(54, 16);
            this.mien.TabIndex = 5;
            this.mien.Text = "Miễn";
            this.mien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // field_gia
            // 
            this.field_gia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.field_gia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.field_gia.Enabled = false;
            this.field_gia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.field_gia.Location = new System.Drawing.Point(383, 335);
            this.field_gia.Name = "field_gia";
            this.field_gia.Size = new System.Drawing.Size(124, 21);
            this.field_gia.TabIndex = 8;
            this.field_gia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(322, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tính theo :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trasau
            // 
            this.trasau.Enabled = false;
            this.trasau.Location = new System.Drawing.Point(174, 337);
            this.trasau.Name = "trasau";
            this.trasau.Size = new System.Drawing.Size(64, 16);
            this.trasau.TabIndex = 6;
            this.trasau.Text = "Trả sau";
            this.trasau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // cholam
            // 
            this.cholam.Enabled = false;
            this.cholam.Location = new System.Drawing.Point(239, 337);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(91, 19);
            this.cholam.TabIndex = 7;
            this.cholam.Text = "Nơi làm việc";
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // dai
            // 
            this.dai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dai.Enabled = false;
            this.dai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dai.Location = new System.Drawing.Point(289, 312);
            this.dai.Name = "dai";
            this.dai.Size = new System.Drawing.Size(102, 21);
            this.dai.TabIndex = 2;
            this.dai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // chenhlech
            // 
            this.chenhlech.Enabled = false;
            this.chenhlech.Location = new System.Drawing.Point(7, 358);
            this.chenhlech.Name = "chenhlech";
            this.chenhlech.Size = new System.Drawing.Size(158, 19);
            this.chenhlech.TabIndex = 9;
            this.chenhlech.Text = "Thanh toán chênh lệch";
            this.chenhlech.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(234, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Cơ quan thanh toán :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dmdvchitra
            // 
            this.dmdvchitra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dmdvchitra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dmdvchitra.Enabled = false;
            this.dmdvchitra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dmdvchitra.Location = new System.Drawing.Point(352, 358);
            this.dmdvchitra.Name = "dmdvchitra";
            this.dmdvchitra.Size = new System.Drawing.Size(155, 21);
            this.dmdvchitra.TabIndex = 11;
            this.dmdvchitra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // ngaysinh
            // 
            this.ngaysinh.Enabled = false;
            this.ngaysinh.Location = new System.Drawing.Point(147, 358);
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(102, 19);
            this.ngaysinh.TabIndex = 10;
            this.ngaysinh.Text = "Nhập ngày sinh";
            this.ngaysinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // frmDoituong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(509, 426);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.dmdvchitra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chenhlech);
            this.Controls.Add(this.dai);
            this.Controls.Add(this.cholam);
            this.Controls.Add(this.trasau);
            this.Controls.Add(this.field_gia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mien);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.sothe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDoituong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục đối tượng";
            this.Load += new System.EventHandler(this.frmDoituong_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDoituong_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sothe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDoituong_Load(object sender, System.EventArgs e)
		{
            user = m.user; itable = m.tableid("", "doituong");
            ds.ReadXml("..//..//..//xml//m_field_gia.xml");
			field_gia.DisplayMember="TEN";
			field_gia.ValueMember="MA";
			field_gia.DataSource=ds.Tables[0];
            dmdvchitra.DisplayMember = "TEN";
            dmdvchitra.ValueMember = "ID";
            dtdv = m.get_data("select * from " + user + ".dmdvchitra").Tables[0];
            if (dtdv.Rows.Count == 0)
            {
                m.upd_dmdvchitra(0, "Bảo hiểm");
                dtdv = m.get_data("select * from " + user + ".dmdvchitra").Tables[0];
            }
            dmdvchitra.DataSource = dtdv;
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
		}

		private void load_grid()
		{
			dt=m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];
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
			TextCol.MappingName = "madoituong";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 20;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 110;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dai";
			TextCol.HeaderText = "Chiều dài";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Hết hạn";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabv";
			TextCol.HeaderText = "ĐKKCB";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mien";
			TextCol.HeaderText = "Miễn";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "trasau";
            TextCol.HeaderText = "Trả sau";
            TextCol.Width = 40;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "cholam";
            TextCol.HeaderText = "Làm việc";
            TextCol.Width = 40;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "field_gia";
			TextCol.HeaderText = "Giá viện phí";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sothe";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chenhlech";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "donvi";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngaysinh";
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

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
			//sothe.Enabled=ena;
            dai.Enabled = ena;
			ngay.Enabled=ena;
			mabv.Enabled=ena;
			mien.Enabled=ena;
            trasau.Enabled = ena;
            ngaysinh.Enabled=dmdvchitra.Enabled=chenhlech.Enabled=cholam.Enabled = ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
			field_gia.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			DataRow r;
			int i=1;
			for(i=1;i<100;i++)
			{
				if (i!=d.iHaophi)
				{
					r=m.getrowbyid(dt,"madoituong="+i);
					if (r==null) break;
				}
			}
			ma.Text=i.ToString();
            ten.Text = ""; sothe.Value = 0; ngay.Checked = false; mabv.Checked = false; trasau.Checked = false; ngaysinh.Checked=chenhlech.Checked=cholam.Checked = false; dai.Text = "";
			ena_object(true);
			ma.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			ma.Enabled=false;
			ten.Focus();
		}

		private bool kiemtra()
		{
			if (ma.Text=="")
			{
				ma.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (dai.Text=="")//(sothe.Value==0)
			{
				ngay.Checked=false;mabv.Checked=false;
			}
			if (field_gia.SelectedIndex==-1)
			{
				field_gia.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
            if (m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where madoituong=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", ma.Text + "^" + ten.Text + "^" + sothe.Value.ToString() + "^" + ((ngay.Checked) ? "1" : "0") + "^" + ((mabv.Checked) ? "1" : "0") + "^" + ((mien.Checked) ? "1" : "0") + "^" + field_gia.SelectedValue.ToString() + "^" + ((trasau.Checked) ? "1" : "0")+"^"+dai.Text);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");            
            sothe.Value = (dai.Text != "") ? 1 : 0;
			if (!m.upd_doituong(int.Parse(ma.Text),ten.Text,Convert.ToInt32(sothe.Value),(ngay.Checked)?1:0,(mabv.Checked)?1:0,(mien.Checked)?1:0,field_gia.SelectedValue.ToString(),(trasau.Checked) ? 1 : 0,(cholam.Checked) ? 1 : 0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin !"));
				return;
			}
            m.execute_data("update " + user + ".doituong set dai='" + dai.Text + "',chenhlech=" + ((chenhlech.Checked) ? 1 : 0) + ",donvi=" + ((dmdvchitra.SelectedIndex == -1) ? 0 : int.Parse(dmdvchitra.SelectedValue.ToString())) + ",ngaysinh=" + ((ngaysinh.Checked) ? 1 : 0) + " where madoituong=" + int.Parse(ma.Text));
            if (m.get_data("select * from " + user + ".d_doituong where madoituong=" + int.Parse(ma.Text)).Tables[0].Rows.Count == 0)
                d.upd_doituong("d_doituong", int.Parse(ma.Text), ten.Text, "", 0, "", "");
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (m.get_data("select * from "+user+".benhandt where madoituong="+int.Parse(ma.Text)).Tables[0].Rows.Count!=0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đối tượng đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.upd_eve_tables(itable, i_userid, "del");
                m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".doituong", "madoituong=" + int.Parse(ma.Text)));
				m.execute_data("delete from "+user+".doituong where madoituong="+int.Parse(ma.Text));
				load_grid();
			}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (m.get_data("select * from "+user+".doituong where madoituong="+int.Parse(ma.Text)).Tables[0].Rows.Count!=0 || int.Parse(ma.Text)==d.iHaophi)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"));
					ma.Focus();
					return;
				}
			}
			catch{}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ma.Text=dataGrid1[i,0].ToString();
				ten.Text=dataGrid1[i,1].ToString();
                dai.Text = dataGrid1[i, 2].ToString();
				sothe.Value=decimal.Parse(dataGrid1[i,9].ToString());
				ngay.Checked=dataGrid1[i,3].ToString()=="1";
				mabv.Checked=dataGrid1[i,4].ToString()=="1";
				mien.Checked=dataGrid1[i,5].ToString()=="1";
                trasau.Checked = dataGrid1[i, 6].ToString() == "1";
                cholam.Checked = dataGrid1[i, 7].ToString() == "1";
				field_gia.SelectedValue=dataGrid1[i,8].ToString();
                chenhlech.Checked = dataGrid1[i, 10].ToString() == "1";
                dmdvchitra.SelectedValue = dataGrid1[i, 11].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			//ten.Text=m.Caps(ten.Text);
		}

		private void frmDoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void ma_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void sothe_Validated(object sender, System.EventArgs e)
		{
			if (sothe.Value==0) mien.Focus();
		}
	}
}
