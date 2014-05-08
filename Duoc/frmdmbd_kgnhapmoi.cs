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
	/// Summary description for rptThekho.
	/// </summary>
	public class frmdmbd_kgnhapmoi : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom;
		private string sql,s_rpt,s_tu,s_den,s_yy,s_kho,user,xxx;
		private DataRow []dr;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable tmpkho=new DataTable();
		private DataSet dsdm=new DataSet();
		private DataTable dtkhac=new DataTable();
		private DataTable dtphieu=new DataTable();
		private DataTable dtloaint=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtkho=new DataTable();
        private System.Windows.Forms.ComboBox kho;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged,bGiaban;
        int checkCol = 0;
        private System.Windows.Forms.ComboBox manguon;
        private CheckBox chkTatca;
        private CheckBox chknhom;
        private CheckBox chkloai;
        private TextBox tim;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmdmbd_kgnhapmoi(AccessData acc,int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdmbd_kgnhapmoi));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.kho = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.chkTatca = new System.Windows.Forms.CheckBox();
            this.chknhom = new System.Windows.Forms.CheckBox();
            this.chkloai = new System.Windows.Forms.CheckBox();
            this.tim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(260, 379);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "     &Lưu";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(330, 379);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // kho
            // 
            this.kho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kho.Enabled = false;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(389, 6);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(243, 21);
            this.kho.TabIndex = 4;
            this.kho.SelectedIndexChanged += new System.EventHandler(this.kho_SelectedIndexChanged);
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(10, 10);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(622, 335);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // manguon
            // 
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(135, 6);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(197, 21);
            this.manguon.TabIndex = 3;
            this.manguon.SelectedIndexChanged += new System.EventHandler(this.manguon_SelectedIndexChanged);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // chkTatca
            // 
            this.chkTatca.AutoSize = true;
            this.chkTatca.Checked = true;
            this.chkTatca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTatca.Location = new System.Drawing.Point(15, 8);
            this.chkTatca.Name = "chkTatca";
            this.chkTatca.Size = new System.Drawing.Size(57, 17);
            this.chkTatca.TabIndex = 30;
            this.chkTatca.Text = "Tất cả";
            this.chkTatca.UseVisualStyleBackColor = true;
            this.chkTatca.CheckedChanged += new System.EventHandler(this.chkTatca_CheckedChanged);
            // 
            // chknhom
            // 
            this.chknhom.AutoSize = true;
            this.chknhom.Location = new System.Drawing.Point(78, 8);
            this.chknhom.Name = "chknhom";
            this.chknhom.Size = new System.Drawing.Size(60, 17);
            this.chknhom.TabIndex = 31;
            this.chknhom.Text = "Nhóm :";
            this.chknhom.UseVisualStyleBackColor = true;
            this.chknhom.CheckedChanged += new System.EventHandler(this.chknhom_CheckedChanged);
            // 
            // chkloai
            // 
            this.chkloai.AutoSize = true;
            this.chkloai.Location = new System.Drawing.Point(338, 8);
            this.chkloai.Name = "chkloai";
            this.chkloai.Size = new System.Drawing.Size(52, 17);
            this.chkloai.TabIndex = 32;
            this.chkloai.Text = "Loại :";
            this.chkloai.UseVisualStyleBackColor = true;
            this.chkloai.CheckedChanged += new System.EventHandler(this.chkloai_CheckedChanged);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(10, 349);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(622, 21);
            this.tim.TabIndex = 8;
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // frmdmbd_kgnhapmoi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(642, 423);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.chkloai);
            this.Controls.Add(this.chknhom);
            this.Controls.Add(this.chkTatca);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmdmbd_kgnhapmoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mặt hàng nhập mới hoặc không cho phép nhập mới";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptThekho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptThekho_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			
			manguon.DataSource=d.get_data("select * from "+user+".d_dmnhom where nhom="+i_nhom+" order by stt").Tables[0];
			
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmloai where nhom=" + i_nhom;			
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtkho;
            
			load_grid();
			AddGridTableStyle();

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
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
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width =50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenhc";
            TextCol.HeaderText = "Hoạt chất";
            TextCol.Width = 120;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 250;
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

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tennhom";
            TextCol.HeaderText = "Nhóm";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenloai";
            TextCol.HeaderText = "Loại";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenhang";
			TextCol.HeaderText = "Hãng";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tennuoc";
            TextCol.HeaderText = "Nước SX";
			TextCol.Width =55;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tennhacc";
            TextCol.HeaderText = "Nhà cung cấp";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
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
					//				e.BackBrush = this.disabledBackBrush;
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
            try
            {
                dsdm.Clear();
                dsdm.Dispose();
            }
            catch { }
            dsdm = new DataSet();
            sql = " select a.id, a.ma, a.ten||' '||a.hamluong as ten, a.dang, a.tenhc, a.manhom, b.ten as tennhom, a.maloai,  c.ten as tenloai, a.mahang, d.ten as tenhang, a.manuoc, e.ten as tennuoc, a.hide ";
            sql += ", f.ten as tennhacc ";
            sql += " from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b on a.manhom=b.id inner join " + user + ".d_dmloai c on a.maloai=c.id ";
            sql += " left join " + user + ".d_dmhang d on a.mahang=d.id left join " + user + ".d_dmnuoc e on a.manuoc=e.id ";
            sql += " left join " + user + ".d_dmnx f on a.madv=f.id ";
            sql += " where a.nhom=" + i_nhom;
            if (chkTatca.Checked) sql += "";
            else if (chknhom.Checked && manguon.SelectedIndex >= 0) sql += " and a.manhom=" + manguon.SelectedValue.ToString();
            else if (chkloai.Checked && kho.SelectedIndex >= 0) sql += " and a.maloai=" + kho.SelectedValue.ToString();
            else sql="";
            
            dsdm = d.get_data(sql);
            //
            dsdm.Tables[0].Columns.Add("Chon", typeof(bool));
            //
			dataGrid1.DataSource=dsdm.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false;
            foreach (DataRow row in dsdm.Tables[0].Rows) row["chon"] = row["hide"].ToString() == "1";
		}

		private void kho_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==kho) load_grid();
		}

		private void Update_dmbd_kgnhapmoi()
		{
            string s_mabd = ",";
           
			foreach(DataRow dr in dsdm.Tables[0].Select("chon=true"))
			{
                s_mabd += (s_mabd.IndexOf(dr["id"].ToString() + ",") < 0) ? dr["id"].ToString() + "," : "";
			}
            s_mabd = s_mabd.Trim().Trim(',');
            sql = "update " + user + ".d_dmbd  set hide=1 where id in(" + s_mabd.Trim().Trim(',') + ")";
            d.execute_data(sql);
            //
            s_mabd = ",";
            foreach (DataRow dr in dsdm.Tables[0].Select("chon=false and hide=1"))
            {
                s_mabd += (s_mabd.IndexOf(dr["id"].ToString() + ",") < 0) ? dr["id"].ToString() + "," : "";
            }
            s_mabd = s_mabd.Trim().Trim(',');
            sql = "update " + user + ".d_dmbd  set hide=0 where id in(" + s_mabd.Trim().Trim(',') + ")";
            d.execute_data(sql);
			
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            Cursor = Cursors.WaitCursor;
            Update_dmbd_kgnhapmoi();
            load_grid();
            Cursor = Cursors.Default;
		}
		

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="ten like '%"+tim.Text.Trim()+"%' or ma like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butIn.Focus();
		}

		private void manguon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==manguon) load_grid();
		}

		
        private void chkTatca_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTatca.Checked)
            {
                chknhom.Checked = false;
                chkloai.Checked = false;
            }            
        }

        private void chknhom_CheckedChanged(object sender, EventArgs e)
        {
            manguon.Enabled = chknhom.Checked;
            if(chknhom.Checked) chkTatca.Checked = chkloai.Checked = false;
        }

        private void chkloai_CheckedChanged(object sender, EventArgs e)
        {
            kho.Enabled = chknhom.Checked;
            if (chkloai.Checked) chkTatca.Checked = chknhom.Checked = false;
        }
	}
}
