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
	public class frmCls_loai : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.CheckBox hinh;
		private int id;
        private bool bAdmin;
        private string user;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox nhomvp;
		private System.Windows.Forms.CheckBox ytaphu;
		private System.Windows.Forms.CheckBox thuoc;
		private System.Windows.Forms.CheckBox canquang;
		private System.Windows.Forms.CheckBox gayme;
		private System.Windows.Forms.CheckBox mat;
        private CheckBox may;
        private CheckBox madia;
        private CheckBox phim;
        private CheckBox sa;
        private CheckBox phanung;
        private TextBox path_access;
        private Button but199;
        private Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCls_loai(AccessData acc,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; bAdmin = admin; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCls_loai));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.hinh = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nhomvp = new System.Windows.Forms.ComboBox();
            this.ytaphu = new System.Windows.Forms.CheckBox();
            this.thuoc = new System.Windows.Forms.CheckBox();
            this.canquang = new System.Windows.Forms.CheckBox();
            this.gayme = new System.Windows.Forms.CheckBox();
            this.mat = new System.Windows.Forms.CheckBox();
            this.may = new System.Windows.Forms.CheckBox();
            this.madia = new System.Windows.Forms.CheckBox();
            this.phim = new System.Windows.Forms.CheckBox();
            this.sa = new System.Windows.Forms.CheckBox();
            this.phanung = new System.Windows.Forms.CheckBox();
            this.path_access = new System.Windows.Forms.TextBox();
            this.but199 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -7);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(672, 311);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(509, 393);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-8, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nội dung :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(56, 312);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(224, 21);
            this.ten.TabIndex = 0;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(159, 393);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 15;
            this.butMoi.Text = "&Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(229, 393);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 16;
            this.butSua.Text = "&Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(299, 393);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 13;
            this.butLuu.Text = "&Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(369, 393);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 14;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(439, 393);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 17;
            this.butHuy.Text = "&Hủy";
            this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // hinh
            // 
            this.hinh.Enabled = false;
            this.hinh.Location = new System.Drawing.Point(56, 336);
            this.hinh.Name = "hinh";
            this.hinh.Size = new System.Drawing.Size(64, 24);
            this.hinh.TabIndex = 2;
            this.hinh.Text = "Có hình";
            this.hinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(272, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Loại viện  phí :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomvp
            // 
            this.nhomvp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomvp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomvp.Enabled = false;
            this.nhomvp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomvp.Location = new System.Drawing.Point(368, 312);
            this.nhomvp.Name = "nhomvp";
            this.nhomvp.Size = new System.Drawing.Size(312, 21);
            this.nhomvp.TabIndex = 1;
            this.nhomvp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomvp_KeyDown);
            // 
            // ytaphu
            // 
            this.ytaphu.Enabled = false;
            this.ytaphu.Location = new System.Drawing.Point(120, 336);
            this.ytaphu.Name = "ytaphu";
            this.ytaphu.Size = new System.Drawing.Size(55, 24);
            this.ytaphu.TabIndex = 3;
            this.ytaphu.Text = "KTV";
            this.ytaphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // thuoc
            // 
            this.thuoc.Enabled = false;
            this.thuoc.Location = new System.Drawing.Point(171, 337);
            this.thuoc.Name = "thuoc";
            this.thuoc.Size = new System.Drawing.Size(57, 24);
            this.thuoc.TabIndex = 4;
            this.thuoc.Text = "Thuốc";
            this.thuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // canquang
            // 
            this.canquang.Enabled = false;
            this.canquang.Location = new System.Drawing.Point(224, 336);
            this.canquang.Name = "canquang";
            this.canquang.Size = new System.Drawing.Size(81, 24);
            this.canquang.TabIndex = 5;
            this.canquang.Text = "Cản Quang";
            this.canquang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // gayme
            // 
            this.gayme.Enabled = false;
            this.gayme.Location = new System.Drawing.Point(303, 336);
            this.gayme.Name = "gayme";
            this.gayme.Size = new System.Drawing.Size(65, 24);
            this.gayme.TabIndex = 6;
            this.gayme.Text = "Gây mê";
            this.gayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // mat
            // 
            this.mat.Enabled = false;
            this.mat.Location = new System.Drawing.Point(368, 336);
            this.mat.Name = "mat";
            this.mat.Size = new System.Drawing.Size(144, 24);
            this.mat.TabIndex = 7;
            this.mat.Text = "Thống kê theo số mắt";
            // 
            // may
            // 
            this.may.Enabled = false;
            this.may.Location = new System.Drawing.Point(224, 358);
            this.may.Name = "may";
            this.may.Size = new System.Drawing.Size(68, 24);
            this.may.TabIndex = 12;
            this.may.Text = "Máy";
            this.may.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // madia
            // 
            this.madia.Enabled = false;
            this.madia.Location = new System.Drawing.Point(120, 358);
            this.madia.Name = "madia";
            this.madia.Size = new System.Drawing.Size(88, 24);
            this.madia.TabIndex = 11;
            this.madia.Text = "Mã đĩa";
            this.madia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // phim
            // 
            this.phim.Enabled = false;
            this.phim.Location = new System.Drawing.Point(56, 358);
            this.phim.Name = "phim";
            this.phim.Size = new System.Drawing.Size(68, 24);
            this.phim.TabIndex = 10;
            this.phim.Text = "Phim";
            this.phim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // sa
            // 
            this.sa.Enabled = false;
            this.sa.Location = new System.Drawing.Point(570, 336);
            this.sa.Name = "sa";
            this.sa.Size = new System.Drawing.Size(106, 24);
            this.sa.TabIndex = 9;
            this.sa.Text = "Siêu âm";
            this.sa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // phanung
            // 
            this.phanung.Enabled = false;
            this.phanung.Location = new System.Drawing.Point(498, 336);
            this.phanung.Name = "phanung";
            this.phanung.Size = new System.Drawing.Size(76, 24);
            this.phanung.TabIndex = 8;
            this.phanung.Text = "Phản ứng";
            this.phanung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // path_access
            // 
            this.path_access.BackColor = System.Drawing.SystemColors.HighlightText;
            this.path_access.Enabled = false;
            this.path_access.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.path_access.Location = new System.Drawing.Point(368, 358);
            this.path_access.Name = "path_access";
            this.path_access.Size = new System.Drawing.Size(285, 21);
            this.path_access.TabIndex = 161;
            // 
            // but199
            // 
            this.but199.Enabled = false;
            this.but199.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but199.Location = new System.Drawing.Point(656, 357);
            this.but199.Name = "but199";
            this.but199.Size = new System.Drawing.Size(24, 23);
            this.but199.TabIndex = 162;
            this.but199.Text = "...";
            this.but199.UseVisualStyleBackColor = true;
            this.but199.Click += new System.EventHandler(this.but199_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(272, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 163;
            this.label3.Text = "Tập tin liên kết :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCls_loai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 437);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but199);
            this.Controls.Add(this.path_access);
            this.Controls.Add(this.may);
            this.Controls.Add(this.madia);
            this.Controls.Add(this.phim);
            this.Controls.Add(this.sa);
            this.Controls.Add(this.phanung);
            this.Controls.Add(this.mat);
            this.Controls.Add(this.gayme);
            this.Controls.Add(this.canquang);
            this.Controls.Add(this.thuoc);
            this.Controls.Add(this.ytaphu);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.nhomvp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hinh);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCls_loai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân loại";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCls_loai_KeyDown);
            this.Load += new System.EventHandler(this.frmCls_loai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCls_loai_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			nhomvp.DisplayMember="TEN";
			nhomvp.ValueMember="ID";
			nhomvp.DataSource=m.get_data("select b.* from "+user+".v_nhomvp a,"+user+".v_loaivp b where a.ma=b.id order by a.stt,b.stt").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
            if (!bAdmin)
            {
                butHuy.Enabled = false;
                butSua.Enabled = false;
            }
		}

		private void load_grid()
		{
            dt = m.get_data("select a.*,b.ten as tennhomvp from " + user + ".cls_loai a left join " + user + ".v_loaivp b on a.nhomvp=b.id order by a.id").Tables[0];
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
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 210;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomvp";
			TextCol.HeaderText = "Loại viện phí";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hinh";
			TextCol.HeaderText = "Hình";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhomvp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ytaphu";
			TextCol.HeaderText = "Y tá phụ";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thuoc";
			TextCol.HeaderText = "Thuốc";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "canquang";
			TextCol.HeaderText = "Cản quang";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gayme";
			TextCol.HeaderText = "Gây mê";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mat";
			TextCol.HeaderText = "Mắt";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "phanung";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sa";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "phim";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "madia";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "may";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "path_access";
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
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void ena_object(bool ena)
		{
			canquang.Enabled=ena;
			gayme.Enabled=ena;
			mat.Enabled=ena;
			thuoc.Enabled=ena;
			ytaphu.Enabled=ena;
			hinh.Enabled=ena;
            phanung.Enabled = ena;
            sa.Enabled = ena;
            phim.Enabled = ena;
            madia.Enabled = ena;
            may.Enabled = ena;
			ten.Enabled=ena;
			nhomvp.Enabled=ena;
			butMoi.Enabled=!ena;
            if (bAdmin)  butSua.Enabled = !ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
            but199.Enabled = ena;
            if (bAdmin) butHuy.Enabled = !ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			id=0;
			hinh.Checked=false;
			ytaphu.Checked=false;
			thuoc.Enabled=false;
			canquang.Checked=false;
			gayme.Checked=false;
			mat.Checked=false;
            phanung.Checked = false;
            sa.Checked = false;
            phim.Checked = false;
            madia.Checked = false;
            may.Checked = false;
			ten.Text="";
			ena_object(true);
			ten.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (id==0) return;
			ena_object(true);
			ten.Focus();
		}

		private bool kiemtra()
		{
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (nhomvp.SelectedIndex==-1)
			{
				nhomvp.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
			if (id==0)
			{
                DataTable tmp = m.get_data("select max(id) as id from " + user + ".cls_loai").Tables[0];
				if (tmp.Rows[0]["id"].ToString()=="") id=1;
				else id=int.Parse(tmp.Rows[0]["id"].ToString())+1;
			}
            if (!m.upd_cls_loai(id, ten.Text, (hinh.Checked) ? 1 : 0, int.Parse(nhomvp.SelectedValue.ToString()), (ytaphu.Checked) ? 1 : 0, (thuoc.Checked) ? 1 : 0, (canquang.Checked) ? 1 : 0, (gayme.Checked) ? 1 : 0, (mat.Checked) ? 1 : 0, (phanung.Checked) ? 1 : 0, (sa.Checked) ? 1 : 0,(phim.Checked)?1:0,(madia.Checked)?1:0,(may.Checked)?1:0,path_access.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin phân loại !"));
				return;
			}
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (id==0) return;
            string mmyy = m.mmyy(m.ngayhienhanh_server.Substring(0,10));
            if (m.bMmyy(mmyy))
            {
                if (m.get_data("select * from "+user+mmyy+".cls_thuchien where loai=" + id).Tables[0].Rows.Count != 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Phân loại đã sử dụng không thể huỷ !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.execute_data("delete from "+user+".cls_loai where id="+id);
				load_grid();
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				id=int.Parse(dataGrid1[i,0].ToString());
				ten.Text=dataGrid1[i,1].ToString();
				hinh.Checked=dataGrid1[i,3].ToString()=="1";
				nhomvp.SelectedValue=dataGrid1[i,4].ToString();
				ytaphu.Checked=dataGrid1[i,5].ToString()=="1";
				thuoc.Checked=dataGrid1[i,6].ToString()=="1";
				canquang.Checked=dataGrid1[i,7].ToString()=="1";
				gayme.Checked=dataGrid1[i,8].ToString()=="1";
				mat.Checked=dataGrid1[i,9].ToString()=="1";
                phanung.Checked = dataGrid1[i, 10].ToString() == "1";
                sa.Checked = dataGrid1[i, 11].ToString() == "1";
                phim.Checked = dataGrid1[i, 12].ToString() == "1";
                madia.Checked = dataGrid1[i, 13].ToString() == "1";
                may.Checked = dataGrid1[i, 14].ToString() == "1";
                path_access.Text = dataGrid1[i, 15].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmCls_loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void nhomvp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhomvp.SelectedIndex==-1 && nhomvp.Items.Count>0) nhomvp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

        private void but199_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.MDB|*.*";
            of.ShowDialog();
            path_access.Text = of.FileName.ToString();
            System.Environment.CurrentDirectory = sDir;
        }

	}
}
