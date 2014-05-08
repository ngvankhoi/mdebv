using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptThekho.
	/// </summary>
	public class frmDonthuoc_bacsy : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        //lan.Read_Language_to_Xml(this.Name.ToString(),this);
		//lan.Changelanguage_to_English(this.Name.ToString(),this);
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d;
        private LibMedi.AccessData m = new LibMedi.AccessData();
		private decimal l_id;
		private DataSet dsdm=new DataSet();
        private DataTable dt = new DataTable();
        private DataTable dtdoituong = new DataTable();
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
        int checkCol = 0;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mabs;
        private System.Windows.Forms.ComboBox lmabs;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butHuy;
        private System.Windows.Forms.Button butSua;
		private string user,sql;
		private int i_nhom=5;
		private System.Windows.Forms.Button butThem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDonthuoc_bacsy(LibDuoc.AccessData acc,int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
           // Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        lan.Read_Language_to_Xml(this.Name.ToString(),this);
		lan.Changelanguage_to_English(this.Name.ToString(),this);
            d = acc; i_nhom = nhom;
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
            this.tim = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.mabs = new System.Windows.Forms.TextBox();
            this.lmabs = new System.Windows.Forms.ComboBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(502, 538);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 10;
            this.butXoa.Text = "     &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(642, 538);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Size = new System.Drawing.Size(783, 234);
            this.dataGrid1.TabIndex = 7;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Enabled = false;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(5, 515);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(784, 21);
            this.tim.TabIndex = 6;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(292, 538);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 11;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(5, 8);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(784, 280);
            this.dataGrid2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(42, 3);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(747, 21);
            this.mabs.TabIndex = 2;
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // lmabs
            // 
            this.lmabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lmabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lmabs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lmabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmabs.Location = new System.Drawing.Point(42, 3);
            this.lmabs.Name = "lmabs";
            this.lmabs.Size = new System.Drawing.Size(747, 21);
            this.lmabs.TabIndex = 0;
            this.lmabs.SelectedIndexChanged += new System.EventHandler(this.lmabs_SelectedIndexChanged);
            this.lmabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lmabs_KeyDown);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(362, 538);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 12;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(152, 538);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 13;
            this.butTiep.Text = "     &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(572, 538);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 15;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(222, 538);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 14;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(432, 538);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 9;
            this.butThem.Text = "     &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // frmDonthuoc_bacsy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.lmabs);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butXoa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDonthuoc_bacsy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo gói thuốc vật tư y tế";
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
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			dsdm.ReadXml("..\\..\\..\\xml\\d_dmbd.xml");
			dsdm.Tables[0].Columns.Add("Chon",typeof(bool));
			load_grid();
            m.execute_data("ALTER TABLE " + user+ ".d_theodonct add madoituong numeric(2,0) default 0;");
            m.execute_data("insert into "+user+".d_doituong(madoituong,doituong) values(0,'Khác');");
            string sql = "select madoituong,doituong from medibv.d_doituong order by madoituong";
            dtdoituong = m.get_data(sql).Tables[0];
            
            
			AddGridTableStyle();

            this.disabledBackBrush = new SolidBrush(Color.FromArgb(255, 255, 192));
            this.disabledTextBrush = new SolidBrush(Color.FromArgb(255, 0, 0));

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);

            this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));
            lmabs.DisplayMember = "GHICHU";
            lmabs.ValueMember = "ID";
            load_head();
            load_chitiet();
            AddGridTableStyle1();
		}

        private void load_head()
		{
            sql = "select * from " + user + ".d_theodonll where mabs='' and ghichu<>'' and stt=-1 order by ghichu";
			lmabs.DataSource=m.get_data(sql).Tables[0];
            l_id = (lmabs.SelectedIndex != -1) ? decimal.Parse(lmabs.SelectedValue.ToString()) : 0;
		}
	
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
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
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
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
			TextCol.Width = 200;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            DataGridComboBoxColumn ComCol = new DataGridComboBoxColumn(dtdoituong, 1,1);
            ComCol.MappingName = "doituong";
            ComCol.HeaderText ="Đối tượng";
            ComCol.Width = 100;
            ComCol.ReadOnly = false;
            ComCol.Alignment = HorizontalAlignment.Left;
            ComCol.NullText = string.Empty;
            dataGrid1.CaptionText = string.Empty;
            ts.GridColumnStyles.Add(ComCol);
            dataGrid1.TableStyles.Add(ts);

            //ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dtdoituong, "doituong", "madoituong"));
            //ts.GridColumnStyles[6].MappingName = "tenkp";
            //ts.GridColumnStyles[6].HeaderText = "Chuyển phòng";
            //ts.GridColumnStyles[6].Width = 160;
            //ts.GridColumnStyles[6].Alignment = HorizontalAlignment.Left;
            //ts.GridColumnStyles[6].NullText = string.Empty;
            //dataGrid1.CaptionText = string.Empty;

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
			sql="select id,ma,trim(ten)||' '||hamluong as ten,dang,nullif(tenhc,' ') as tenhc,'Khác' doituong from ";
            sql +=user + ".d_dmbd where nhom=" + i_nhom + " order by ten";
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
            if (l_id == 0)
            {
                l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString()+ d.get_id_donthuoc_bacsy().ToString());
            }
            else d.execute_data("delete from " + user + ".d_theodonct where id=" + l_id);
			d.upd_theodonll(l_id,"","",mabs.Text,-1,dt.Rows.Count,1);
            dt.AcceptChanges();
            foreach (DataRow r in dt.Rows)
            {
                DataRow r_dt = m.getrowbyid(dtdoituong, "doituong='" + r["doituong"] + "'");
                r["madoituong"] = r_dt["madoituong"].ToString();
                d.upd_theodonct(l_id, int.Parse(r["mabd"].ToString()), decimal.Parse(r["soluong"].ToString()), r["cachdung"].ToString(), int.Parse(r["stt"].ToString()), int.Parse(r["madoituong"].ToString()));
            }
			ena_object(false);
			decimal id=l_id;
			load_head();
			lmabs.SelectedValue=id;
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
			sql="select b.mabd,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,nullif(a.tenhc,' ') as tenhc,b.soluong,b.cachdung,b.stt,c.doituong,b.madoituong ";
            sql += " from " + user + ".d_dmbd a," + user + ".d_theodonct b,"+user+".d_doituong c where a.id=b.mabd and b.madoituong=c.madoituong and b.id=" + l_id;// +" order by a.ten";
            sql += " order by b.stt ";
			dt=m.get_data(sql).Tables[0];
			dataGrid2.DataSource=dt;
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

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
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

            //TextCol = new DataGridTextBoxColumn();
            //TextCol.MappingName = "doituong";
            //TextCol.HeaderText = "Đối tượng";
            //TextCol.Width = 100;
            //TextCol.ReadOnly = false;
            //ts.GridColumnStyles.Add(TextCol);
            //dataGrid2.TableStyles.Add(ts);

            DataGridComboBoxColumn ComCol = new DataGridComboBoxColumn(dtdoituong, 1, 1);
            ComCol.MappingName = "doituong";
            ComCol.HeaderText = "Đối tượng";
            ComCol.Width = 100;
            ComCol.ReadOnly = false;
            ComCol.Alignment = HorizontalAlignment.Left;
            ComCol.NullText = string.Empty;
            dataGrid1.CaptionText = string.Empty;
            ts.GridColumnStyles.Add(ComCol);
            dataGrid2.TableStyles.Add(ts);
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}


		private void lmabs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == lmabs)
            {
                l_id = decimal.Parse(lmabs.SelectedValue.ToString());
                load_chitiet();
            }
		}

		private void lmabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			dt.Clear();
            l_id = 0;
			mabs.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (lmabs.Items.Count==0) return;
			ena_object(true);
            mabs.Text = lmabs.Text;
			dataGrid2.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            load_head();
			load_chitiet();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.execute_data("delete from " + user + ".d_theodonll where id=" + l_id);
                m.execute_data("delete from " + user + ".d_theodonct where id=" + l_id);
				load_head();
				load_chitiet();
			}
		}

		private void ena_object(bool ena)
		{
			if (ena) mabs.Text="";
			lmabs.Visible=!ena;
			mabs.Enabled=ena;
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
                int stt = 1;
				foreach(DataRow r in dsdm.Tables[0].Select("chon=true")) 
                {
                    DataRow r_dt=m.getrowbyid(dtdoituong,"doituong='"+r["doituong"]+"'");
                    int i_madoituong = int.Parse(r_dt["madoituong"].ToString());
					m.updrec_donthuoc(dt,int.Parse(r["id"].ToString()),r["ma"].ToString(),r["ten"].ToString(),r["dang"].ToString(),r["tenhc"].ToString(),stt++,r["doituong"].ToString(),i_madoituong);
                }
				foreach (DataRow row in dsdm.Tables[0].Rows) row["chon"]=false;
			}
		}

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }
	}
}
