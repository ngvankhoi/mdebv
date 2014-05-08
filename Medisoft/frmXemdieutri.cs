using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXemdieutri.
	/// </summary>
	public class frmXemdieutri : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox dienbien;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox chedoan;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.IContainer components;
		private DataSet ds=new DataSet();
		private DataTable dtnv=new DataTable(); 
		private LibMedi.AccessData m;
		private string user,s_ngayvv,s_ngayrv,sql;
		private decimal l_idkhoa;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true;
		private int checkCol=0;
		private System.Windows.Forms.RichTextBox ylenh;
		private System.Windows.Forms.TextBox tenbs_pass;

		public frmXemdieutri(LibMedi.AccessData acc,decimal _idkhoa,string _ngayvv,string _ngayrv)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;l_idkhoa=_idkhoa;s_ngayvv=_ngayvv;s_ngayrv=_ngayrv;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemdieutri));
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dienbien = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chedoan = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tenbs_pass = new System.Windows.Forms.TextBox();
            this.ylenh = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(551, 360);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(168, 21);
            this.tenbs.TabIndex = 7;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(507, 360);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(41, 21);
            this.mabs.TabIndex = 6;
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(472, 362);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(48, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "Bác sĩ :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(288, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 304;
            this.label9.Text = "DIỄN BIẾN BỆNH";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(288, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "&Y LỆNH";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dienbien
            // 
            this.dienbien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienbien.Enabled = false;
            this.dienbien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienbien.Location = new System.Drawing.Point(296, 24);
            this.dienbien.Multiline = true;
            this.dienbien.Name = "dienbien";
            this.dienbien.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dienbien.Size = new System.Drawing.Size(488, 94);
            this.dienbien.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(209, 362);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 308;
            this.label15.Text = "Chế độ ăn uống :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chedoan
            // 
            this.chedoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chedoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chedoan.Enabled = false;
            this.chedoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chedoan.Location = new System.Drawing.Point(296, 360);
            this.chedoan.Name = "chedoan";
            this.chedoan.Size = new System.Drawing.Size(176, 21);
            this.chedoan.TabIndex = 5;
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
            this.dataGrid1.Location = new System.Drawing.Point(6, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(280, 368);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(704, 120);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(80, 21);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tenbs_pass
            // 
            this.tenbs_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_pass.Enabled = false;
            this.tenbs_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_pass.Location = new System.Drawing.Point(720, 360);
            this.tenbs_pass.Name = "tenbs_pass";
            this.tenbs_pass.PasswordChar = '*';
            this.tenbs_pass.Size = new System.Drawing.Size(64, 21);
            this.tenbs_pass.TabIndex = 8;
            this.toolTip1.SetToolTip(this.tenbs_pass, "Mật khẩu bác sĩ điều trị");
            // 
            // ylenh
            // 
            this.ylenh.AutoWordSelection = true;
            this.ylenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ylenh.Enabled = false;
            this.ylenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ylenh.Location = new System.Drawing.Point(296, 142);
            this.ylenh.Name = "ylenh";
            this.ylenh.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ylenh.Size = new System.Drawing.Size(488, 216);
            this.ylenh.TabIndex = 311;
            this.ylenh.Text = "";
            // 
            // frmXemdieutri
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butKetthuc;
            this.ClientSize = new System.Drawing.Size(792, 397);
            this.Controls.Add(this.ylenh);
            this.Controls.Add(this.tenbs_pass);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.chedoan);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dienbien);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemdieutri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tờ điều trị";
            this.Load += new System.EventHandler(this.frmXemdieutri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXemdieutri_Load(object sender, System.EventArgs e)
		{
			user=m.user;
			dtnv=m.get_data("select * from dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];
			chedoan.DisplayMember="TEN";
			chedoan.ValueMember="ID";
			chedoan.DataSource=m.get_data("select * from ba_dmchedoan order by stt").Tables[0];
			load_grid();
			AddGridTableStyle();
			this.disabledBackBrush = new SolidBrush(Color.Black);
			this.disabledTextBrush = new SolidBrush(Color.Red);

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));

			ref_text();
		}

		private void load_grid()
		{
			sql="select a.id,a.idthuchien,a.sophieu,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.dienbien,a.ylenh,";
			sql+="a.idylenh,a.chedoan,a.mabs,a.loai,c.hoten as tenbs,c.password_ from xxx.ba_dieutri a,xxx.ba_thuchien b,"+user+".dmbs c where a.idthuchien=b.id and a.mabs=c.ma and b.idkhoa="+l_idkhoa;
			sql+=" order by a.id";
			ds=m.get_data_mmyy(sql,s_ngayvv.Substring(0,10),s_ngayrv.Substring(0,10),false);
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in ds.Tables[0].Rows) row["chon"]=false;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
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
			discontinuedCol.HeaderText = "";
			discontinuedCol.Width = 0;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "sophieu";
			TextCol1.HeaderText = "Số";
			TextCol1.Width = 30;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tenbs";
			TextCol1.HeaderText = "Bác sĩ";
			TextCol1.Width = 170;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				if (this.dataGrid1[e.Row,8].ToString().Trim()=="1" || this.dataGrid1[e.Row,9].ToString().Trim()=="1")
					e.ForeBrush=this.disabledTextBrush;
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = new SolidBrush(Color.Blue);
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
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
			ref_text();
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
		}

		private void ref_text()
		{
			try
			{
				load_items(decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,1].ToString()));
			}
			catch{}
		}

		private void load_items(decimal id)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"id="+id);
			if (r!=null)
			{
				dienbien.Text=r["dienbien"].ToString();
				ylenh.Text=r["ylenh"].ToString();
				chedoan.SelectedValue=r["chedoan"].ToString();
				mabs.Text=r["mabs"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r!=null)
				{
					tenbs.Text=r1["hoten"].ToString();
					tenbs_pass.Text=r1["password_"].ToString();
				}
				else
				{
					tenbs.Text="";	
					tenbs_pass.Text="";
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
