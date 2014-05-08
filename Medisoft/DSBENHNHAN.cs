using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Medisoft
{
	/// <summary>
	/// Summary description for DSBENHNHAN.
	/// </summary>
	public class DSBENHNHAN : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdKetthuc;
		private System.Windows.Forms.Button cmdChon;
		private System.Windows.Forms.DataGrid dtg1;
		public string mabncu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DSBENHNHAN(System.Windows.Forms.Form frmdangkykham,DataSet Ds)
		{			
			InitializeComponent();
			dtg1.DataSource=Ds.Tables[0];
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DSBENHNHAN));
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.cmdChon = new System.Windows.Forms.Button();
			this.dtg1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dtg1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdKetthuc.Image")));
			this.cmdKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdKetthuc.Location = new System.Drawing.Point(355, 240);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(75, 28);
			this.cmdKetthuc.TabIndex = 4;
			this.cmdKetthuc.Text = "Kết thúc";
			this.cmdKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// cmdChon
			// 
			this.cmdChon.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdChon.Image")));
			this.cmdChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdChon.Location = new System.Drawing.Point(275, 240);
			this.cmdChon.Name = "cmdChon";
			this.cmdChon.Size = new System.Drawing.Size(75, 28);
			this.cmdChon.TabIndex = 3;
			this.cmdChon.Text = "    Chọn";
			this.cmdChon.Click += new System.EventHandler(this.cmdChon_Click);
			// 
			// dtg1
			// 
			this.dtg1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dtg1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dtg1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dtg1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtg1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dtg1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtg1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dtg1.DataMember = "";
			this.dtg1.FlatMode = true;
			this.dtg1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtg1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtg1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dtg1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dtg1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dtg1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtg1.LinkColor = System.Drawing.Color.Teal;
			this.dtg1.Name = "dtg1";
			this.dtg1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dtg1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dtg1.ReadOnly = true;
			this.dtg1.RowHeaderWidth = 10;
			this.dtg1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dtg1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtg1.Size = new System.Drawing.Size(704, 222);
			this.dtg1.TabIndex = 5;
			// 
			// DSBENHNHAN
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(704, 285);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dtg1,
																		  this.cmdKetthuc,
																		  this.cmdChon});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DSBENHNHAN";
			this.Text = "DANH SÁCH BỆNH NHÂN";
			this.Load += new System.EventHandler(this.DSBENHNHAN_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtg1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void DSBENHNHAN_Load(object sender, System.EventArgs e)
		{
			LoadGridStyle();
		}

		private void LoadGridStyle()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName="BTDBN";

			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.MidnightBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.ReadOnly=true;
			tbs.RowHeaderWidth=10;

			DataGridTextBoxColumn c0=new DataGridTextBoxColumn();
			c0.MappingName="MABN";
			c0.HeaderText="Mã BN";
			c0.Width=60;
			c0.NullText="";
			tbs.GridColumnStyles.Add(c0);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="HOTEN";
			c1.HeaderText="Tên Bệnh Nhân";
			c1.NullText="";
			c1.Width=130;
			tbs.GridColumnStyles.Add(c1);			

			DataGridTextBoxColumn c3=new DataGridTextBoxColumn();
			c3.MappingName="NAMSINH";
			c3.HeaderText="Năm Sinh";
			c3.NullText="";
			c3.Width=75;
			tbs.GridColumnStyles.Add(c3);			

			DataGridTextBoxColumn c5=new DataGridTextBoxColumn();
			c5.MappingName="SONHA";
			c5.HeaderText="Số Nhà";
			c5.NullText="";
			c5.Width=53;
			tbs.GridColumnStyles.Add(c5);

			DataGridTextBoxColumn c6=new DataGridTextBoxColumn();
			c6.MappingName="THON";
			c6.HeaderText="Thôn/Phố";
			c6.NullText="";
			c6.Width=120;
			tbs.GridColumnStyles.Add(c6);

			DataGridTextBoxColumn c7=new DataGridTextBoxColumn();
			c7.MappingName="TENTT";
			c7.HeaderText="Tỉnh/Thành";
			c7.NullText="";
			c7.Width=80;
			tbs.GridColumnStyles.Add(c7);

			DataGridTextBoxColumn c8=new DataGridTextBoxColumn();
			c8.MappingName="TENQUAN";
			c8.HeaderText="Quận/Huyện";
			c8.NullText="";
			c8.Width=80;
			tbs.GridColumnStyles.Add(c8);

			DataGridTextBoxColumn c9=new DataGridTextBoxColumn();
			c9.MappingName="TENPXA";
			c9.HeaderText="Phường/Xã";
			c9.NullText="";
			c9.Width=80;
			tbs.GridColumnStyles.Add(c9);

			dtg1.TableStyles.Add(tbs);
		}

		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{
			mabncu="";
			this.Close();
		}

		private void cmdChon_Click(object sender, System.EventArgs e)
		{
			mabncu=dtg1[dtg1.CurrentCell.RowNumber,0].ToString().Trim();
			this.Close();
		}
	}
}
