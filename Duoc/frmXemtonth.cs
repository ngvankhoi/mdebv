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
	/// Summary description for frmXemton.
	/// </summary>
	public class frmXemtonth : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_kho, i_nhom, i_userid=0;
		private string s_mmyy,sql,format_soluong,user;
		private DataTable dt=new DataTable();
        private DataTable dtt = new DataTable();
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butIn;
        private Button butXoatreo;
        private Button butLoc;
        private TextBox manguon;
        private TextBox manhom;
        private Label label2;
        private Label label1;
        private ComboBox cbnguon;
        private ComboBox cbnhom; 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXemtonth(AccessData acc,int kho,string mmyy,string tenkho,int nhom, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_kho=kho;
			s_mmyy=mmyy;
			i_nhom=nhom;
            i_userid = _userid;
			this.Text="Tồn "+tenkho.Trim()+" tổng hợp tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemtonth));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butRef = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butXoatreo = new System.Windows.Forms.Button();
            this.butLoc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.TextBox();
            this.manhom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbnguon = new System.Windows.Forms.ComboBox();
            this.cbnhom = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 28);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 455);
            this.dataGrid1.TabIndex = 0;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(445, 492);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 2;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(305, 492);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(70, 25);
            this.butRef.TabIndex = 0;
            this.butRef.Text = "&Đọc lại";
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Location = new System.Drawing.Point(8, 25);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(776, 20);
            this.tim.TabIndex = 6;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(375, 492);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 1;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butXoatreo
            // 
            this.butXoatreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoatreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoatreo.Location = new System.Drawing.Point(186, 492);
            this.butXoatreo.Name = "butXoatreo";
            this.butXoatreo.Size = new System.Drawing.Size(118, 25);
            this.butXoatreo.TabIndex = 8;
            this.butXoatreo.Text = "Xóa tồn treo";
            this.butXoatreo.Click += new System.EventHandler(this.butXoatreo_Click);
            // 
            // butLoc
            // 
            this.butLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butLoc.Location = new System.Drawing.Point(750, 1);
            this.butLoc.Name = "butLoc";
            this.butLoc.Size = new System.Drawing.Size(35, 23);
            this.butLoc.TabIndex = 7;
            this.butLoc.Text = "Lọc";
            this.butLoc.UseVisualStyleBackColor = true;
            this.butLoc.Click += new System.EventHandler(this.butLoc_Click);
            // 
            // manguon
            // 
            this.manguon.Location = new System.Drawing.Point(51, 2);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(41, 20);
            this.manguon.TabIndex = 3;
            this.manguon.Validated += new System.EventHandler(this.manguon_Validated);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // manhom
            // 
            this.manhom.Location = new System.Drawing.Point(392, 2);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(56, 20);
            this.manhom.TabIndex = 5;
            this.manhom.Validated += new System.EventHandler(this.manhom_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nhóm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nguốn";
            // 
            // cbnguon
            // 
            this.cbnguon.FormattingEnabled = true;
            this.cbnguon.Location = new System.Drawing.Point(93, 2);
            this.cbnguon.Name = "cbnguon";
            this.cbnguon.Size = new System.Drawing.Size(245, 21);
            this.cbnguon.TabIndex = 4;
            this.cbnguon.Validated += new System.EventHandler(this.cbnguon_Validated);
            this.cbnguon.SelectedIndexChanged += new System.EventHandler(this.cbnguon_SelectedIndexChanged);
            // 
            // cbnhom
            // 
            this.cbnhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbnhom.FormattingEnabled = true;
            this.cbnhom.Location = new System.Drawing.Point(449, 2);
            this.cbnhom.Name = "cbnhom";
            this.cbnhom.Size = new System.Drawing.Size(300, 21);
            this.cbnhom.TabIndex = 6;
            this.cbnhom.Validated += new System.EventHandler(this.cbnhom_Validated);
            this.cbnhom.SelectedIndexChanged += new System.EventHandler(this.cbnhom_SelectedIndexChanged);
            // 
            // frmXemtonth
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butLoc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbnguon);
            this.Controls.Add(this.cbnhom);
            this.Controls.Add(this.butXoatreo);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemtonth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXemtonth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXemtonth_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user;
            dtt = d.get_data("select * from "+user+".d_toithieu where makho=" + i_kho).Tables[0];
			format_soluong=d.format_soluong(i_nhom);
            //
            //
            cbnhom.DataSource = d.get_data("select id, ten from " + user + ".d_dmnhom where nhom=" + i_nhom).Tables[0];
            cbnhom.DisplayMember = "TEN";
            cbnhom.ValueMember = "ID";
            //
            cbnguon.DataSource = d.get_data("select id, ten from " + user + ".d_dmnguon where nhom=" + i_nhom).Tables[0];
            cbnguon.DisplayMember = "TEN";
            cbnguon.ValueMember = "ID";
            //
            //
            load_grid("", "");
			AddGridTableStyle();
		}

		private void load_grid(string d_manguon, string d_manhom)
		{
			sql="select c.ten as tennguon,b.ma,trim(b.ten)||' '||b.hamluong as tenbd,b.tenhc,b.dang,a.tondau,a.slnhap,a.slxuat,a.tondau+a.slnhap-a.slxuat as toncuoi ";
			sql+=",000000000.00 as tongton,b.sltoithieu as toithieu,a.manguon,a.mabd, case when a.slyeucau<0 then 0 else a.slyeucau end as slyeucau, a.makho ";
            sql += " from " + user + s_mmyy + ".d_tonkhoth a inner join " + user + ".d_dmbd b on a.mabd=b.id left join " + user + ".d_dmnguon c on a.manguon=c.id  ";
			sql+=" where a.makho="+i_kho+"";
            if (d_manguon.Trim() != "" && d_manguon.Trim() != "0") sql += " and a.manguon in(" + d_manguon.Trim().Trim(',') + ")";
            if (d_manhom.Trim() != "" && d_manhom.Trim() != "0") sql += " and b.manhom in(" + d_manhom.Trim().Trim(',') + ")";
            sql+=" order by b.ten";
			dt=d.get_data(sql).Tables[0];
            sql = "select a.manguon,a.mabd,sum(a.tondau+a.slnhap-a.slxuat) as ton ";
            sql += " from " + user + s_mmyy + ".d_tonkhoth a inner join " + user + ".d_dmbd b  on a.mabd=b.id left join " + user + ".d_dmnguon c on a.manguon=c.id ";
			sql+="where a.makho in (select id from "+user+".d_dmkho where nhom="+i_nhom+")";
            if (d_manguon.Trim() != "" && d_manguon.Trim() != "0") sql += " and a.manguon in(" + d_manguon.Trim().Trim(',') + ")";
            if (d_manhom.Trim() != "" && d_manhom.Trim() != "0") sql += " and b.manhom in(" + d_manhom.Trim().Trim(',') + ")";
			sql+=" group by a.manguon,a.mabd";
			DataRow r1;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dt,"manguon="+int.Parse(r["manguon"].ToString())+" and mabd="+int.Parse(r["mabd"].ToString()));
				if (r1!=null) r1["tongton"]=r["ton"].ToString();
			}
            foreach (DataRow r in dt.Rows)
            {
                r1 = d.getrowbyid(dtt, "mabd=" + int.Parse(r["mabd"].ToString()));
                if (r1 != null) r["toithieu"] = r1["soluong"].ToString();
            }
			dataGrid1.DataSource=dt;
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
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
			ts.RowHeaderWidth=5;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (d.bHoatchat)?200:270;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "tondau";
			TextCol.HeaderText = "Tồn đầu";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "slnhap";
			TextCol.HeaderText = "Nhập";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "slxuat";
			TextCol.HeaderText = "Xuất";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "toncuoi";
			TextCol.HeaderText = "Tồn cuối";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "tongton";
			TextCol.HeaderText = "Tổng tồn";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de,10);
			TextCol.MappingName = "toithieu";
			TextCol.HeaderText = "Tồn tối thiểu";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 11);
            TextCol.MappingName = "slyeucau";
            TextCol.HeaderText = "KP Dự trù";
            TextCol.Width = 72;
            TextCol.Format = format_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 12);
            TextCol.MappingName = "makho";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 13);
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (decimal.Parse(this.dataGrid1[row,9].ToString().Trim())<decimal.Parse(this.dataGrid1[row,10].ToString().Trim())) return Color.Red;
			else return Color.Black;
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

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbd like '%"+text.Trim()+"%' or tenhc like '%"+text.Trim()+"%' or ma like '%"+text.Trim()+"%'";
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
            Cursor = Cursors.WaitCursor;
            if (d.bKhoaso(i_nhom, s_mmyy) == false) d.f_capnhat_tonkhoct(s_mmyy, i_nhom);
            d.execute_data("delete from " + user + s_mmyy + ".d_tonkhoct where tondau=0 and slnhap=0 and slxuat=0");
            d.execute_data("delete from " + user + s_mmyy + ".d_tonkhoth where tondau=0 and slnhap=0 and slxuat=0");
            d.execute_data("update " + user + s_mmyy + ".d_tonkhoth set slyeucau=0 where slyeucau<0");
			d.upd_tonkho(s_mmyy,i_nhom,1);
			load_grid("","");
            try
            {
                if (tim.Text.Trim() != "Tìm kiếm") RefreshChildren(tim.Text);
            }
            catch { }
            Cursor = Cursors.Default;
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim) RefreshChildren(tim.Text);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			sql="select d.stt as manhom,d.ten as tennhom,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,c.ten as tenhang,a.tondau,a.slnhap,a.slxuat,a.tondau+a.slnhap-a.slxuat as toncuoi, ";
			sql+="000000000.00 as tongton,b.sltoithieu as toithieu,a.mabd ";
            sql += " from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnhom d";
			sql+=" where a.mabd=b.id and b.mahang=c.id and b.manhom=d.id and a.makho="+i_kho+" order by d.stt,b.ten";
			DataSet dstmp=d.get_data(sql);
            sql = "select a.manguon,a.mabd,sum(a.tondau+a.slnhap-a.slxuat) as ton from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmbd b," + user + ".d_dmnguon c ";
			sql+="where a.mabd=b.id and a.manguon=c.id and a.makho in (select id from "+user+".d_dmkho where nhom="+i_nhom+")";
			sql+=" group by a.manguon,a.mabd";
			DataRow r1;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dstmp.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1!=null) r1["tongton"]=r["ton"].ToString();
			}
			DataSet dsxml=dstmp.Copy();
            string tenbaocao = "";
            if (d.bLoctontoithieu(i_nhom))
            {
                dsxml.Clear();
                dsxml.Merge(dstmp.Tables[0].Select("tongton<toithieu"));
                tenbaocao = "DANH SÁCH THUỐC DƯỚI TỒN TỐI THIỂU";
            }
            else
            {
                tenbaocao = "DANH SÁCH THUỐC TỒN KHO ";
            }
			if (dsxml.Tables[0].Rows.Count>0)
			{
                frmReport f1 = new frmReport(d, dsxml.Tables[0], i_userid, "d_tonkho.rpt", tenbaocao, "Tháng " + s_mmyy.Substring(0, 2) + " Năm 20" + s_mmyy.Substring(2), "", "", "", "", "", "", "", "");
				f1.ShowDialog(this);
			}
		}

        private void butXoatreo_Click(object sender, EventArgs e)
        {
            Cursor= Cursors.WaitCursor;
            int i = dataGrid1.CurrentRowIndex;
            try
            {
                sql = "update " + user + s_mmyy + ".d_tonkhoth set slyeucau=0 where mabd=" + dataGrid1[i, 13].ToString() + " and makho=" + dataGrid1[i, 12].ToString();
                d.execute_data(sql);

                load_grid("","");
                if (tim.Text.Trim() != "Tìm kiếm") RefreshChildren(tim.Text);
            }
            catch { }
            Cursor = Cursors.Default;
        }

        private void cbnhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cbnhom) manhom.Text = cbnhom.SelectedValue.ToString();
            }
            catch { manhom.Text = "0"; }
        }

        private void cbnguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.ActiveControl==cbnguon) manguon.Text = cbnguon.SelectedValue.ToString();
            }
            catch { manguon.Text = "0"; }
        }

        private void manguon_Validated(object sender, EventArgs e)
        {
            try
            {
                cbnguon.SelectedValue = manguon.Text;
            }
            catch { }
        }

        private void manhom_Validated(object sender, EventArgs e)
        {
            try
            {
                cbnhom.SelectedValue = manhom.Text;
            }
            catch { }
        }

        private void manguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }


        private void cbnhom_Validated(object sender, EventArgs e)
        {
            try
            {
                manhom.Text = cbnhom.SelectedValue.ToString();
            }
            catch { manhom.Text = "0"; }
        }

        private void cbnguon_Validated(object sender, EventArgs e)
        {
            try
            {
                manguon.Text = cbnguon.SelectedValue.ToString();
            }
            catch { manguon.Text = "0"; }
        }

        private void butLoc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            load_grid(manguon.Text,manhom.Text);
            try
            {
                if (tim.Text.Trim() != "Tìm kiếm") RefreshChildren(tim.Text);
            }
            catch { }
            Cursor = Cursors.Default;
        }
	}
}
