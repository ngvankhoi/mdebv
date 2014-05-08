using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibDuoc;
using System.Data;
namespace Duoc
{
	/// <summary>
	/// Summary description for frmdsduyet.
	/// </summary>
	public class frmdsduyet : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		AccessData d=new AccessData();
		DataTable dtdt=new DataTable();
		DataTable dtd=new DataTable();
		string d_ngay="";
		private Wildgrape.Aqua.Controls.Button butOk;
		private Wildgrape.Aqua.Controls.Button butCancel;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmdsduyet(string ngay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d_ngay=ngay;
            
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
			this.butOk = new Wildgrape.Aqua.Controls.Button();
			this.butCancel = new Wildgrape.Aqua.Controls.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// butOk
			// 
			this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.butOk.Location = new System.Drawing.Point(392, 488);
			this.butOk.Name = "butOk";
			this.butOk.SizeToLabel = false;
			this.butOk.TabIndex = 12;
			this.butOk.Text = "Đọc lại";
			this.butOk.Click += new System.EventHandler(this.butOk_Click);
			// 
			// butCancel
			// 
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Location = new System.Drawing.Point(312, 488);
			this.butCancel.Name = "butCancel";
			this.butCancel.TabIndex = 13;
			this.butCancel.Text = "Bỏ qua";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.CaptionText = "Danh sách các khoa đã dự trù";
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(8, 16);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 20;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(384, 456);
			this.dataGrid1.TabIndex = 62;
			// 
			// dataGrid2
			// 
			this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.CaptionText = "Danh sách các khoa đã được duyệt - Cấp phát";
			this.dataGrid2.DataMember = "";
			this.dataGrid2.FlatMode = true;
			this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid2.Location = new System.Drawing.Point(400, 16);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid2.ReadOnly = true;
			this.dataGrid2.RowHeaderWidth = 20;
			this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid2.Size = new System.Drawing.Size(384, 456);
			this.dataGrid2.TabIndex = 63;
			// 
			// frmdsduyet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGrid2,
																		  this.dataGrid1,
																		  this.butOk,
																		  this.butCancel});
			this.Name = "frmdsduyet";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Theo dõi tình hình duyệt thuốc trong ngày";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmdsduyet_Load);
			this.Activated += new System.EventHandler(this.frmdsduyet_Activated);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		private DataSet Load_ds_dadutru(string d_ngay)
		{
			string sql="select a.*, b.ten tenkp, (d.ten||' - '||c.ten) diengiai,d.id loai "+
				 " from d_duyet a, d_duockp b, d_loaiphieu c, d_dmphieu d"+
				 " where a.makp=b.makp and a.loai=d.id and a.phieu=c.id and a.done=1 and to_char(a.ngay,'dd/mm/yyyy')='"+d_ngay+"'"+
				 " order by b.ten, d.id, a.phieu";
			DataSet ds=d.get_data(sql);
			return ds;
		}

		private DataSet Load_ds_daduyet(string d_ngay)
		{
			string sql="select a.*, b.ten tenkp, (d.ten||' - '||c.ten) diengiai,d.id loai "+
				" from d_duyet a, d_duockp b, d_loaiphieu c, d_dmphieu d"+
				" where a.makp=b.makp and a.loai=d.id and a.phieu=c.id and a.done=2 and to_char(a.ngay,'dd/mm/yyyy')='"+d_ngay+"'"+
				" order by b.ten, d.id, a.phieu";
			DataSet ds=d.get_data(sql);
			return ds;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = "dsdutru";
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;

			DataGridTextBoxColumn TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "tenkp";
			TextCol1.HeaderText = "Khoa - Phòng";
			TextCol1.Width = 130;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			DataGridTextBoxColumn TextCol2=new DataGridTextBoxColumn();
			TextCol2.MappingName = "diengiai";
			TextCol2.HeaderText = "Buổi";
			TextCol2.Width = 235;
			ts.GridColumnStyles.Add(TextCol2);
			dataGrid1.TableStyles.Add(ts);			

		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = "dsduyet";
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;

			DataGridTextBoxColumn TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "tenkp";
			TextCol1.HeaderText = "Khoa -phòng";
			TextCol1.Width = 130;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			DataGridTextBoxColumn TextCol2=new DataGridTextBoxColumn();
			TextCol2.MappingName = "diengiai";
			TextCol2.HeaderText = "Buổi";
			TextCol2.Width = 235;
			ts.GridColumnStyles.Add(TextCol2);
			dataGrid2.TableStyles.Add(ts);			

		}

		private void frmdsduyet_Load(object sender, System.EventArgs e)
		{
			AddGridTableStyle();
			AddGridTableStyle1();
			//
			DataSet ds=new DataSet();
			ds=Load_ds_dadutru(d_ngay);
			ds.Tables[0].TableName="dsdutru";
			dataGrid1.SetDataBinding(ds,"dsdutru");
			//
			DataSet ds1=new DataSet();
			ds1=Load_ds_daduyet(d_ngay);
			ds1.Tables[0].TableName="dsduyet";
			dataGrid2.SetDataBinding(ds1,"dsduyet");
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			DataSet ds=new DataSet();
			ds=Load_ds_dadutru(d_ngay);
			ds.Tables[0].TableName="dsdutru";
			dataGrid1.SetDataBinding(ds,"dsdutru");
			//
			DataSet ds1=new DataSet();
			ds1=Load_ds_daduyet(d_ngay);
			ds1.Tables[0].TableName="dsduyet";
			dataGrid2.SetDataBinding(ds1,"dsduyet");
		}

		private void frmdsduyet_Activated(object sender, System.EventArgs e)
		{
			
		}
	}
}
