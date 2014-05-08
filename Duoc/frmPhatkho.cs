using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmDuyet.
	/// </summary>
	public class frmPhatkho : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged,bSkip=false;
		private int checkCol=0;
		private AccessData d;
		private int i_nhom,sole;
		private string user,sql,s_tu,s_den,s_mmyy,title,xxx,s_kho;
		private DataTable dt=new DataTable();
        private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butRef;
        private DataGrid dataGrid2;
        private Button butXem;
        private DataTable dtdetail = new DataTable();
        private GroupBox groupBox1;
        private RadioButton rb3;
        private RadioButton rb2;
        private RadioButton rb1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPhatkho(AccessData acc,int nhom,string tu,string den,string mmyy,string kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; s_tu = tu; s_den = den; s_kho = kho; s_mmyy = mmyy;
			title=(s_tu==s_den)?" Ngày "+s_tu:" Từ ngày "+s_tu+" đến "+s_den;
			this.Text="Phiếu phát thuốc ("+title+")";
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhatkho));
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.butRef = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.butXem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(360, 521);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Image = global::Duoc.Properties.Resources.close_r;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(500, 521);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
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
            this.dataGrid1.Location = new System.Drawing.Point(5, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(738, 498);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(5, 488);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(1134, 21);
            this.tim.TabIndex = 2;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butRef.Image = global::Duoc.Properties.Resources.chonkhoa;
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(275, 521);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(85, 25);
            this.butRef.TabIndex = 4;
            this.butRef.Text = "&Danh sách";
            this.butRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(749, -16);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(390, 498);
            this.dataGrid2.TabIndex = 7;
            // 
            // butXem
            // 
            this.butXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXem.Image = global::Duoc.Properties.Resources.search;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(430, 521);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 8;
            this.butXem.Text = "    &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(5, 505);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 33);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Checked = true;
            this.rb3.Location = new System.Drawing.Point(133, 10);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(74, 17);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.Text = "Chưa phát";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(68, 10);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(63, 17);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Đã phát";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(6, 10);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 17);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "Tất cả";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // frmPhatkho
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1141, 575);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 38);
            this.Name = "frmPhatkho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu phát kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhatkho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPhatkho_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);

			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
            //
            f_upd_d_daduyet(s_mmyy, s_tu, s_den, 0, 0, 0);
            //
			load_grid();
            sole = d.d_soluong_le(i_nhom);
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
			discontinuedCol.HeaderText = "Phát";
			discontinuedCol.Width = 30;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width =70;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 180;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenphieu";
            TextCol.HeaderText = "Phiếu";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenloai";
			TextCol.HeaderText = "Loại";
			TextCol.Width = 205;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenkho";
			TextCol.HeaderText = "Kho";
			TextCol.Width = 115;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "loai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "phieu";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "makp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "makho";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
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


		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
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
			}
			catch{}
		}

		private void load_grid()
		{
            string f_ngay = d.f_ngay;
            sql  = "select to_char(a.ngay,'dd/mm/yyyy') as ngay,a.makp,a.loai,a.phieu,a.makho,";
            sql += "b.ten as tenkp,c.ten as tenphieu,d.ten as tenloai,e.ten as tenkho,a.done ";
            sql += " from " + xxx + ".d_daduyet a," + user + ".d_duockp b,"+user+".d_dmphieu c,"+user+".d_loaiphieu d,"+user+".d_dmkho e";
			sql += " where a.makp=b.id and a.loai=c.id and a.phieu=d.id and a.makho=e.id " ;
            if (s_kho != "") sql += " and a.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
			sql+=" and a.ngay between to_date('"+s_tu+"','"+f_ngay+"') and to_date('"+s_den+"','"+f_ngay+"')";
			sql+=" and a.nhom="+i_nhom;
            if (rb2.Checked) sql += " and a.done=1";
            else if (rb3.Checked) sql += " and a.done=0";
			sql+=" order by a.ngay,c.stt,d.stt,e.stt";
			dt=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
			if (!bSkip) AddGridTableStyle();
			bSkip=true;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dt.Columns.Add("Chon",typeof(bool));
			foreach (DataRow r in dt.Rows) r["chon"]=(r["done"].ToString()=="1");
			butLuu.Enabled=dt.Rows.Count!=0 && rb1.Checked==false;
			dataGrid1.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="";
			upd_data(rb3.Checked);
			load_grid();
			Cursor=Cursors.Default;
		}

		private void upd_data()
		{
			int idone;
			foreach(DataRow r in dt.Rows)
			{
				idone=(r["chon"].ToString()=="True")?1:0;
                d.execute_data("update " + xxx + ".d_daduyet set done=" + idone + " where nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + r["ngay"].ToString() + "' and makp=" + int.Parse(r["makp"].ToString()) + " and loai=" + int.Parse(r["loai"].ToString()) + " and phieu=" + int.Parse(r["phieu"].ToString()) + " and makho=" + int.Parse(r["makho"].ToString()));
			}
		}
        private void upd_data(bool bphat)
        {
            int idone;
            foreach (DataRow r in dt.Rows)
            {
                idone = (r["chon"].ToString() == "True") ? 1 : 0;
                if(bphat && idone==1) d.execute_data("update " + xxx + ".d_daduyet set done=" + idone + " where nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + r["ngay"].ToString() + "' and makp=" + int.Parse(r["makp"].ToString()) + " and loai=" + int.Parse(r["loai"].ToString()) + " and phieu=" + int.Parse(r["phieu"].ToString()) + " and makho=" + int.Parse(r["makho"].ToString()));
                else if (!bphat && idone == 0) d.execute_data("update " + xxx + ".d_daduyet set done=" + idone + " where nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + r["ngay"].ToString() + "' and makp=" + int.Parse(r["makp"].ToString()) + " and loai=" + int.Parse(r["loai"].ToString()) + " and phieu=" + int.Parse(r["phieu"].ToString()) + " and makho=" + int.Parse(r["makho"].ToString()));
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
					dv.RowFilter="tenkho like '%"+tim.Text.Trim()+"%' or tenphieu like '%"+tim.Text.Trim()+"%' or tenloai like '%"+tim.Text.Trim()+"%' or tenkp like '%"+tim.Text.Trim()+"%' or ngay like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
//            f_upd_d_daduyet(s_mmyy, s_tu, s_den, 0, 0, 0);
			load_grid();
		}

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }
        private void butXem_Click(object sender, System.EventArgs e)
        {
            try
            {
                int i_rownum = 0;
                i_rownum = dataGrid1.CurrentCell.RowNumber;
                string tenfile = (int.Parse(dataGrid1[i_rownum, 6].ToString()) == 2) ? "d_thucbucstt" : "d_thucxuat";
                sql = "select b.mabd,t.manguon,d.ten as tennguon,c.ten||' '||c.hamluong as tenbd,c.dang,trunc(sum(b.soluong),"+sole+") as soluong ";
                sql += " from " + xxx + ".d_xuatsdll a," + xxx + "."+tenfile+" b,"+user+".d_dmbd c,"+user+".d_dmnguon d,"+xxx+".d_theodoi t ";
                sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and t.manguon=d.id ";
                sql += " and a.loai=" + int.Parse(dataGrid1[i_rownum, 6].ToString());
                sql += " and a.phieu=" + int.Parse(dataGrid1[i_rownum, 7].ToString());
                sql += " and a.nhom=" + i_nhom;
                sql += " and a.makhoa=" + int.Parse(dataGrid1[i_rownum, 8].ToString());//a.makp
                sql += " and b.makho=" + int.Parse(dataGrid1[i_rownum, 9].ToString());
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + dataGrid1[i_rownum, 1].ToString() + "'";
                sql += " group by b.mabd,t.manguon,d.ten,c.ten||' '||c.hamluong,c.dang order by c.ten||' '||c.hamluong";
                dtdetail = d.get_data(sql).Tables[0];
                dataGrid2.DataSource = dtdetail;
                AddGridTableStyle2();
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource, dataGrid2.DataMember];
                DataView dv = (DataView)cm.List;
                dv.AllowDelete = false;
                dv.AllowNew = false;
                dv.AllowEdit = false;
            }
            catch { }
        }
        private void AddGridTableStyle2()
        {
            dataGrid2.TableStyles.Clear();
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtdetail.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 3;
            ts.AllowSorting = false;

            FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tennguon";
            TextCol.HeaderText = "Nguồn";
            TextCol.Width = 70;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenbd";
            TextCol.HeaderText = "Tên thuốc - hàm lượng";
            TextCol.Width = 200;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "dang";
            TextCol.HeaderText = "ĐVT";
            TextCol.Width = 30;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "soluong";
            TextCol.HeaderText = "SL";
            TextCol.Width = 50;
            TextCol.ReadOnly = true;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            butLuu.Enabled = !rb1.Checked;
        }

        private void f_upd_d_daduyet(string a_mmyy, string a_tungay, string a_denngay, int a_makp, int a_loai, int a_phieu)
        {
            string s_userdb = d.user;
            string asql = "select distinct 'xxx' as mmyy, a.nhom, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, a.makp, a.loai, a.phieu, b.makho, to_number('0') as done, to_number('0') as duyettreole ";
            asql += " from xxx.d_xuatsdll a inner join xxx.d_xuatsdct b on a.id=b.id ";
            asql += " where a.loai in(1,3,4) and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + a_tungay + "','dd/mm/yyyy') and to_date('" + a_denngay + "','dd/mm/yyyy')";
            if (a_makp > 0) asql += " and a.makp=" + a_makp;
            if (a_loai > 0) asql += " and a.loai=" + a_loai;
            if (a_phieu > 0) asql += " and a.phieu =" + a_phieu;
            asql += " UNION ALL ";
            asql += "select distinct 'xxx' as mmyy, a.nhom, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, a.makp, a.loai, a.phieu, b.makho, to_number('0') as done, to_number('0') as duyettreole ";
            asql += " from xxx.d_xuatsdll a inner join xxx.d_bucstt b on a.id=b.id ";
            asql += " where a.loai in(2) and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + a_tungay + "','dd/mm/yyyy') and to_date('" + a_denngay + "','dd/mm/yyyy')";
            if (a_makp > 0) asql += " and a.makp=" + a_makp;
            if (a_loai > 0) asql += " and a.loai=" + a_loai;
            if (a_phieu > 0) asql += " and a.phieu =" + a_phieu;
            DataSet ads = d.get_data_mmyy(asql, s_tu, s_den, true);
            string tmp_mmyy = a_mmyy;

            foreach (DataRow dr in ads.Tables[0].Rows)
            {
                tmp_mmyy = dr["mmyy"].ToString().Replace(s_userdb, "");
                if (tmp_mmyy.Trim().Length != 4) tmp_mmyy = a_mmyy;
                d.upd_daduyet(tmp_mmyy, int.Parse(dr["nhom"].ToString()), dr["ngay"].ToString(), int.Parse(dr["makp"].ToString()), int.Parse(dr["loai"].ToString()), int.Parse(dr["phieu"].ToString()), int.Parse(dr["makho"].ToString()));
            }
        }
	}
}
