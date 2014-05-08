using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DllPhonggiuong
{
	public class frmTragiuong : System.Windows.Forms.Form
	{
		public string giuongnew="";
		public decimal dongia=0;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.DataGrid dataGrid1;
		private PinkieControls.ButtonXP butLuu;
		private PinkieControls.ButtonXP butKetthuc;
		private System.ComponentModel.Container components = null;
		public frmTragiuong(DataTable adt)
		{
			InitializeComponent();
			this.dt=adt;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTragiuong));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.butLuu = new PinkieControls.ButtonXP();
			this.butKetthuc = new PinkieControls.ButtonXP();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.BackgroundColor = System.Drawing.Color.AliceBlue;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(2, -15);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(372, 111);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// butLuu
			// 
			this.butLuu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butLuu.DefaultScheme = true;
			this.butLuu.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butLuu.Hint = "";
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.Location = new System.Drawing.Point(104, 117);
			this.butLuu.Name = "butLuu";
			this.butLuu.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butLuu.Size = new System.Drawing.Size(79, 33);
			this.butLuu.TabIndex = 92;
			this.butLuu.Text = "&Đồng ý";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butKetthuc.DefaultScheme = true;
			this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butKetthuc.Hint = "";
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.Location = new System.Drawing.Point(184, 117);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butKetthuc.Size = new System.Drawing.Size(88, 33);
			this.butKetthuc.TabIndex = 93;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// frmTragiuong
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.AliceBlue;
			this.ClientSize = new System.Drawing.Size(376, 165);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butLuu,
																		  this.butKetthuc,
																		  this.dataGrid1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTragiuong";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chọn giường bệnh nhân nằm";
			this.Load += new System.EventHandler(this.frmTragiuong_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmTragiuong_Load(object sender, System.EventArgs e)
		{
			dataGrid1.DataSource=dt;
			AddGridTableStyle1();   
		}
		private void AddGridTableStyle1()
		{
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
			ts.MappingName = dt.TableName;
			ts.AllowSorting=false;
			ts.ReadOnly=true;
			
			DataGridTextBoxColumn TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "ID";
			TextCol1.Width = 0;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "Mã";
			TextCol1.Width = 70;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Phòng/giường";
			TextCol1.Width = 200;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "dongia";
			TextCol1.HeaderText = "Đơn giá";
			TextCol1.Width =80;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}
		public Color MyGetColorRowCol(int row, int col)
		{
			return Color.Black;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}
		private void ref_text()
		{
			try
			{
				giuongnew=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
				dongia=decimal.Parse(dataGrid1[dataGrid1.CurrentRowIndex,3].ToString());
			}
			catch{giuongnew="";}
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if(giuongnew=="") 
			{
				MessageBox.Show("Chọn giường bệnh nhân nằm lại!");
				return;
			}
			this.Close();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			giuongnew="";
			this.Close();
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
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
	}
}
