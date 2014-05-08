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
	/// Summary description for frmDuyetcap.
	/// </summary>
	public class frmDuyetcap : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ComboBox khon;
		private System.Windows.Forms.ComboBox khox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbSophieu;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butKetthuc;
		private string s_mmyy,user,xxx,sql,s_loai,format_soluong,s_makho;
		private int i_nhom,i_khotoithieu;
		private AccessData d;
        public bool bOK = false, bSuasoluong_khiduyetkhocap=false;
		public DataTable dtll,dtct;
		private DataTable dtkhox,dtkhon;
		private DataTable dtton=new DataTable();
		private System.Windows.Forms.DataGrid dataGrid1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDuyetcap(AccessData acc,DataTable ll,DataTable ct,DataTable kx,DataTable kn,string mmyy,string loai,int nhom,string f_soluong,string makho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;dtll=ll.Copy();dtct=ct.Copy();dtkhox=kx;dtkhon=kn;s_mmyy=mmyy;s_loai=loai;i_nhom=nhom;format_soluong=f_soluong;
			s_makho=makho;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetcap));
            this.khon = new System.Windows.Forms.ComboBox();
            this.khox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // khon
            // 
            this.khon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khon.Location = new System.Drawing.Point(248, 3);
            this.khon.Name = "khon";
            this.khon.Size = new System.Drawing.Size(128, 21);
            this.khon.TabIndex = 11;
            this.khon.SelectedIndexChanged += new System.EventHandler(this.khon_SelectedIndexChanged);
            this.khon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khon_KeyDown);
            // 
            // khox
            // 
            this.khox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khox.Location = new System.Drawing.Point(64, 3);
            this.khox.Name = "khox";
            this.khox.Size = new System.Drawing.Size(120, 21);
            this.khox.TabIndex = 10;
            this.khox.SelectedIndexChanged += new System.EventHandler(this.khox_SelectedIndexChanged);
            this.khox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khox_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(184, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Kho nhập :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Kho xuất : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(376, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(440, 3);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(160, 21);
            this.cmbSophieu.TabIndex = 15;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            // 
            // butLuu
            // 
            this.butLuu.Image = global::Duoc.Properties.Resources.ok;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(236, 317);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 29;
            this.butLuu.Text = "Đồng ý";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(305, 317);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 30;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 7);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(592, 307);
            this.dataGrid1.TabIndex = 31;
            // 
            // frmDuyetcap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(608, 357);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.khox);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.khon);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDuyetcap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyệt cấp";
            this.Load += new System.EventHandler(this.frmDuyetcap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDuyetcap_Load(object sender, System.EventArgs e)
		{
            user = d.user; xxx = user + s_mmyy;
            bSuasoluong_khiduyetkhocap = d.bSuasoluong_khiduyetkhocap(i_nhom);
			i_khotoithieu=d.iKhotoithieu(i_nhom);
			khox.DisplayMember="TEN";
			khox.ValueMember="ID";
			khox.DataSource=dtkhox;

			khon.DisplayMember="TEN";
			khon.ValueMember="ID";
			khon.DataSource=dtkhon;

			cmbSophieu.DisplayMember="SOPHIEU";
			cmbSophieu.ValueMember="ID";
			load_head();
			AddGridTableStyle();
			dataGrid1.ReadOnly=false;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
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
			ts.MappingName = dtct.TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "Mã số";
			TextCol1.Width = 50;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Tên thuốc - hàm lượng";
			TextCol1.Width = (d.bQuanlynguon(i_nhom))?128:208;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "tenhc";
			TextCol1.HeaderText = "Hoạt chất";
			TextCol1.Width = 0;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "dang";
			TextCol1.HeaderText = "ĐVT";
			TextCol1.Width = 50;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "tennguon";
			TextCol1.HeaderText = "Nguồn";
			TextCol1.Width = (d.bQuanlynguon(i_nhom))?80:0;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "slyeucau";
			TextCol1.HeaderText = "Yêu cầu";
			TextCol1.Width = 60;
			TextCol1.Format="# ### ###.##";
			TextCol1.ReadOnly=true;
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

           
			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "soluong";
			TextCol1.HeaderText = "Duyệt cấp";
			TextCol1.Width = 60;
			TextCol1.Format="# ### ###.##";
            TextCol1.ReadOnly = (bSuasoluong_khiduyetkhocap) ? false : true;
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "ton";
			TextCol1.HeaderText = "Tồn kho";
			TextCol1.Width = 60;
			TextCol1.Format="# ### ###.##";
            TextCol1.ReadOnly = true;
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "sltoithieu";
			TextCol1.HeaderText = "Tồn tối thiểu";
			TextCol1.Width = 72;
			TextCol1.Format="# ### ##0.00";
            TextCol1.ReadOnly = true;
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (khox.SelectedIndex!=-1)
			{
				if (i_khotoithieu!=0 && int.Parse(khox.SelectedValue.ToString())==i_khotoithieu)
				{
					if (decimal.Parse(this.dataGrid1[row,7].ToString().Trim())<decimal.Parse(this.dataGrid1[row,8].ToString().Trim())) return Color.Red;
					else return Color.Black;
				}
				else return Color.Black;
			}
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

		private void load_head()
		{
			dataGrid1.DataSource=null;
			sql="select id,sophieu,to_char(ngay,'dd/mm/yyyy') as ngay,khox,khon from "+xxx+".d_dutrucapll ";
			sql+="where loai='"+s_loai+"'"+" and nhom="+i_nhom;
			if (khox.SelectedIndex!=-1) sql+=" and khox="+int.Parse(khox.SelectedValue.ToString());
			if (khon.SelectedIndex!=-1) sql+=" and khon="+int.Parse(khon.SelectedValue.ToString());
			sql+=" and done=0 order by id";
			cmbSophieu.DataSource=d.get_data(sql).Tables[0];
			if (cmbSophieu.Items.Count>0) load_grid(decimal.Parse(cmbSophieu.SelectedValue.ToString()));
			else load_grid(0);
		}

		private void load_khon()
		{
			try
			{
				sql="select * from "+user+".d_dmkho where nhom="+i_nhom+" and id<>"+int.Parse(khox.SelectedValue.ToString());
				sql+=" order by stt";
				khon.DataSource=d.get_data(sql).Tables[0];
			}
			catch{}
		}

		private void khox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (khox.SelectedIndex==-1) khox.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");	
			}
		}

		private void khon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (khon.SelectedIndex==-1) khon.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void khox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==khox)
			{
				load_khon();
				load_head();
            }
		}

		private void khon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==khon) load_head();
		}

		private void cmbSophieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbSophieu && cmbSophieu.Items.Count>0) load_grid(decimal.Parse(cmbSophieu.SelectedValue.ToString()));
		}

		private void load_grid(decimal id)
		{
			sql="select 0 as stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,c.ten as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.slyeucau-a.slthuc as soluong,0 as dongia,0 as sotien,0 as giaban,0 as giamua,a.manguon,0 as nhomcc,' ' as tennuoc,' ' as sothe,' ' as mabs,' ' as tenbs,' ' as hotenbn,a.slyeucau,00000000.00 as ton,b.sltoithieu";
			sql+=" from "+xxx+".d_dutrucapct a,"+user+".d_dmbd b,"+user+".d_dmnguon c,"+user+".d_dmnuoc e where a.mabd=b.id and a.manguon=c.id and b.manuoc=e.id and a.id="+id+" order by b.ma";
			dtct=d.get_data(sql).Tables[0];
			if (khox.SelectedIndex!=-1)
			{
				dtton=d.get_data("select mabd,sum(tondau+slnhap-slxuat) as soluong from "+xxx+".d_tonkhoth where makho="+int.Parse(khox.SelectedValue.ToString())+" group by mabd").Tables[0];
				DataRow r1;
				foreach(DataRow r in dtct.Rows)
				{
					r1=d.getrowbyid(dtton,"mabd="+int.Parse(r["mabd"].ToString()));
					if (r1!=null) r["ton"]=r1["soluong"].ToString();
				}
			}
			dataGrid1.DataSource=dtct;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			bOK=false;
			dtll.Clear();
			d.close();this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.SelectedIndex==-1) return;
			bOK=true;
			dtll.Clear();
			dtct.AcceptChanges();
			d.updrec_xuatll(dtll,decimal.Parse(cmbSophieu.SelectedValue.ToString()),cmbSophieu.Text,"",int.Parse(khox.SelectedValue.ToString()),int.Parse(khon.SelectedValue.ToString()),"","");
			d.close();this.Close();
		}
	}
}
