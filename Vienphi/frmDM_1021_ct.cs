using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using System.Data;
using System.Xml;

namespace Vienphi
{
	public class frmDM_1021_ct : System.Windows.Forms.Form
	{
		private string m_userid="";
		private LibVP.AccessData m_v;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Panel panel4;
        private Button butChon;
        private Button butKetthuc;
        private Panel panel2;
        private DataGrid DataGrid1;
		private System.ComponentModel.IContainer components;

		public frmDM_1021_ct(string v_userid,LibVP.AccessData _m_v)
		{
			InitializeComponent();
			m_userid=v_userid;
			f_SetEvent(panel2);
            this.m_v = _m_v;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDM_1021_ct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.butChon = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DataGrid1 = new System.Windows.Forms.DataGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(792, 49);
            this.panel1.TabIndex = 16;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(71, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(545, 47);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = " KHAI BÁO CHI TIẾT NỘI DUNG BÁO CÁO BỘ (BIỂU 1021)";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(792, 3);
            this.label15.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.butChon);
            this.panel4.Controls.Add(this.butKetthuc);
            this.panel4.Location = new System.Drawing.Point(1, 427);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel4.Size = new System.Drawing.Size(785, 40);
            this.panel4.TabIndex = 150;
            // 
            // butChon
            // 
            this.butChon.BackColor = System.Drawing.Color.White;
            this.butChon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChon.ForeColor = System.Drawing.Color.Navy;
            this.butChon.Image = ((System.Drawing.Image)(resources.GetObject("butChon.Image")));
            this.butChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChon.Location = new System.Drawing.Point(6, 6);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(98, 28);
            this.butChon.TabIndex = 7;
            this.butChon.Text = "   Khai báo";
            this.butChon.UseVisualStyleBackColor = false;
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.White;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(104, 6);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(98, 28);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "   Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.DataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(792, 472);
            this.panel2.TabIndex = 19;
            // 
            // DataGrid1
            // 
            this.DataGrid1.BackColor = System.Drawing.Color.White;
            this.DataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.DataGrid1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
            this.DataGrid1.CaptionText = "Danh sách giá viện phí";
            this.DataGrid1.DataMember = "";
            this.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid1.ForeColor = System.Drawing.Color.Navy;
            this.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid1.Location = new System.Drawing.Point(3, 3);
            this.DataGrid1.Name = "DataGrid1";
            this.DataGrid1.RowHeaderWidth = 16;
            this.DataGrid1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
            this.DataGrid1.Size = new System.Drawing.Size(782, 462);
            this.DataGrid1.TabIndex = 2;
            this.DataGrid1.TabStop = false;
            this.DataGrid1.CurrentCellChanged += new System.EventHandler(this.DataGrid1_CurrentCellChanged);
            // 
            // frmDM_1021_ct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(798, 530);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDM_1021_ct";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo chi tiết nội dung báo cáo bộ (Biểu 1021)";
            this.Load += new System.EventHandler(this.frmDM_1021_ct_Load);
            this.SizeChanged += new System.EventHandler(this.frmDM_1021_ct_SizeChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmDM_1021_ct_Closing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDM_1021_ct_Load(object sender, System.EventArgs e)
		{
			f_Load_DG();
		}
		private void f_Load_DG()
		{
			try
			{
                AddGridTableStyle(m_v.get_data("select a.stt, a.ma,a.ten, count(b.mavp) as n from medibv.dm_1021 a, medibv.dm_1021_ct b where a.ma=b.ma(+) group by a.stt,a.ma,a.ten order by ma asc, ten asc"));
				DataGrid1_CurrentCellChanged(null,null);
				f_resizeDG();
			}
			catch
			{
			}
		}
		private string f_Cur_Date()
		{
			try
			{
				return System.DateTime.Now.Day.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Month.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Year.ToString();
			}
			catch
			{
				return "";
			}
		}
		private void f_SetEvent(System.Windows.Forms.Control v_c)
		{
			try
			{
				foreach(Control c in v_c.Controls)
				{
					c.Leave += new System.EventHandler(this.Control_Leave);
					c.Enter += new System.EventHandler(this.Control_Enter);
				}
			}
			catch
			{
			}
		}
		private void Control_Enter(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox")||(c.GetType().ToString()=="System.Windows.Forms.NumericUpDown"))
				{
					c.BackColor=SystemColors.Info;
					if(c.ForeColor!=Color.Red)
					{
						//c.ForeColor=SystemColors.InfoText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=SystemColors.Info;
					}
					else
						if(c.GetType().ToString()=="System.Windows.Forms.ComboBox")
					{
						System.Windows.Forms.ComboBox c1 = (System.Windows.Forms.ComboBox)(sender);
						if(c1.SelectedIndex<0)
						{
							c1.SelectedIndex=0;
						}
					}
				}
			}
			catch
			{
			}
		}
		private void Control_Leave(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox")||(c.GetType().ToString()=="System.Windows.Forms.NumericUpDown"))
				{
					c.BackColor=Color.FromArgb(255,255,255);
					if(c.ForeColor!=Color.Red)
					{
						//c.ForeColor=SystemColors.ControlText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=Color.White;
					}
				}
			}
			catch
			{
			}
		}
		private void AddGridTableStyle(DataSet v_ds)
		{
			try
			{
				DataGrid1.TableStyles.Clear();
				DataGrid1.AllowSorting=true;
				//DataGrid1.DataSource=v_ds.Tables[0];//null;
				//return;
				DataGridColoredTextBoxColumn TextCol;
				delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
				DataGridTableStyle ts =new DataGridTableStyle();
				ts.MappingName = v_ds.Tables[0].TableName;
				ts.AlternatingBackColor = Color.Linen;
				ts.BackColor = Color.GhostWhite;
				ts.ForeColor = Color.MidnightBlue;
				ts.GridLineColor = SystemColors.Control;
				ts.HeaderBackColor = SystemColors.Control;
				ts.HeaderForeColor = Color.Navy;
				ts.SelectionBackColor = Color.Teal;
				ts.SelectionForeColor = Color.White;
				ts.RowHeaderWidth=16;
				ts.AllowSorting=true;
						
				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "ma";
				TextCol.HeaderText = "Mã";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 60;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				DataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "ten";
				TextCol.HeaderText = "Nội dung";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 200;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				DataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "n";
				TextCol.HeaderText = "Đã khai";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Center;
				TextCol.Width = 60;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				DataGrid1.TableStyles.Add(ts);

				DataGrid1.DataSource = v_ds.Tables[0];
				//MessageBox.Show(v_ds.Tables[0].Rows.Count.ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_resizeDG()
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource,DataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = false; 
				dv.AllowDelete = false; 
				dv.AllowEdit = true; 
				int n=120;
				if(dv.Table.Rows.Count>13)
				{
					DataGrid1.TableStyles[0].GridColumnStyles[1].Width = DataGrid1.Width - n - 16;
				}
				else
				{
					DataGrid1.TableStyles[0].GridColumnStyles[1].Width = DataGrid1.Width - n;
				}
				DataGrid1.Update();
			}
			catch
			{
			}
		}
		#region Datagrid Colored Collum
		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Navy;
			switch (col.ToString())
			{
				case "0":
					c=Color.Navy;
					break;
				case "1":
					c=Color.Blue;
					break;
			}

			try
			{
				if(row==DataGrid1.CurrentRowIndex)
				{
					//DataGrid1.Select(row);
					c=Color.White;
				}
			}
			catch
			{
			}
			return c;
		}
		private void frmDM_1021_ct_SizeChanged(object sender, System.EventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void DataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource,DataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = false; 
				dv.AllowDelete = false; 
				dv.AllowEdit = true; 
			}
			catch
			{
			}

			try
			{
				if(int.Parse(DataGrid1.Tag.ToString())>=0)
				{
					DataGrid1.UnSelect(int.Parse(DataGrid1.Tag.ToString()));
				}
			}
			catch
			{
				DataGrid1.Tag="-1";
			}

			try
			{
				DataGrid1.Tag = DataGrid1.CurrentRowIndex.ToString();
				if(DataGrid1.CurrentRowIndex>=0)
				{
					DataGrid1.Select(int.Parse(DataGrid1.Tag.ToString()));
				}
			}
			catch
			{
				DataGrid1.Tag="-1";
			}
		}
		private void frmDM_1021_ct_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			try
			{
                frmChondichvuVP_bcbo af = new frmChondichvuVP_bcbo(DataGrid1[DataGrid1.CurrentCell.RowNumber, 0].ToString(), m_v);
				af.ShowInTaskbar=false;
				af.ShowDialog();
				f_Load_DG();
			}
			catch
			{
			}
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

		#endregion
	}
}
