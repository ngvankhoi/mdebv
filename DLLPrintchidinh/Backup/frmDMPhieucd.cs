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
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmDMPhieucd.
	/// </summary>
	public class frmDMPhieucd : System.Windows.Forms.Form
	{
		private string m_userid="";
		private LibMedi.AccessData m_m = new LibMedi.AccessData();
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butInchiphi;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.TextBox txtTim;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lbRefresh;
		private System.ComponentModel.IContainer components;

		public frmDMPhieucd()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			f_SetEvent(panel2);

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDMPhieucd));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label15 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbRefresh = new System.Windows.Forms.Label();
			this.txtTen = new System.Windows.Forms.TextBox();
			this.txtTim = new System.Windows.Forms.TextBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.butMoi = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butSua = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butInchiphi = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.label10 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SteelBlue;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lbTitle,
																				 this.pictureBox1});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.DockPadding.Bottom = 1;
			this.panel1.DockPadding.Left = 1;
			this.panel1.DockPadding.Right = 1;
			this.panel1.DockPadding.Top = 1;
			this.panel1.ForeColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(700, 49);
			this.panel1.TabIndex = 16;
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = System.Drawing.Color.SteelBlue;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(71, 1);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(393, 45);
			this.lbTitle.TabIndex = 15;
			this.lbTitle.Text = " KHAI BÁO DANH MỤC PHIẾU CHỈ ĐỊNH";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(1, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(70, 45);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 63;
			this.pictureBox1.TabStop = false;
			// 
			// label15
			// 
			this.label15.Dock = System.Windows.Forms.DockStyle.Top;
			this.label15.Location = new System.Drawing.Point(3, 52);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(700, 3);
			this.label15.TabIndex = 18;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.txtTim,
																				 this.lbRefresh,
																				 this.txtTen,
																				 this.panel4,
																				 this.DataGrid1,
																				 this.label10});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.DockPadding.All = 3;
			this.panel2.ForeColor = System.Drawing.Color.Navy;
			this.panel2.Location = new System.Drawing.Point(3, 55);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(700, 373);
			this.panel2.TabIndex = 19;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			// 
			// lbRefresh
			// 
			this.lbRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lbRefresh.BackColor = System.Drawing.SystemColors.Control;
			this.lbRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbRefresh.Image = ((System.Drawing.Bitmap)(resources.GetObject("lbRefresh.Image")));
			this.lbRefresh.Location = new System.Drawing.Point(674, 6);
			this.lbRefresh.Name = "lbRefresh";
			this.lbRefresh.Size = new System.Drawing.Size(17, 18);
			this.lbRefresh.TabIndex = 192;
			this.toolTip1.SetToolTip(this.lbRefresh, "Lấy số liệu");
			this.lbRefresh.Click += new System.EventHandler(this.lbRefresh_Click);
			// 
			// txtTen
			// 
			this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtTen.BackColor = System.Drawing.Color.White;
			this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTen.Location = new System.Drawing.Point(59, 306);
			this.txtTen.MaxLength = 100;
			this.txtTen.Name = "txtTen";
			this.txtTen.Size = new System.Drawing.Size(560, 21);
			this.txtTen.TabIndex = 0;
			this.txtTen.Tag = "";
			this.txtTen.Text = "";
			this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
			// 
			// txtTim
			// 
			this.txtTim.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.txtTim.BackColor = System.Drawing.Color.White;
			this.txtTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTim.Location = new System.Drawing.Point(622, 306);
			this.txtTim.MaxLength = 100;
			this.txtTim.Name = "txtTim";
			this.txtTim.Size = new System.Drawing.Size(72, 21);
			this.txtTim.TabIndex = 2;
			this.txtTim.TabStop = false;
			this.txtTim.Tag = "";
			this.txtTim.Text = "Tìm kiếm";
			this.txtTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTim_KeyDown);
			this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
			this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
			this.txtTim.Enter += new System.EventHandler(this.txtTim_Enter);
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel4.BackColor = System.Drawing.Color.SteelBlue;
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.butMoi,
																				 this.butLuu,
																				 this.butSua,
																				 this.butHuy,
																				 this.butBoqua,
																				 this.butInchiphi,
																				 this.butKetthuc});
			this.panel4.DockPadding.Bottom = 3;
			this.panel4.DockPadding.Left = 3;
			this.panel4.DockPadding.Right = 3;
			this.panel4.DockPadding.Top = 4;
			this.panel4.Location = new System.Drawing.Point(3, 331);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(692, 37);
			this.panel4.TabIndex = 150;
			// 
			// butMoi
			// 
			this.butMoi.BackColor = System.Drawing.SystemColors.Control;
			this.butMoi.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butMoi.ForeColor = System.Drawing.Color.Navy;
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(5, 4);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(64, 28);
			this.butMoi.TabIndex = 0;
			this.butMoi.Text = "     Mới";
			this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butLuu
			// 
			this.butLuu.BackColor = System.Drawing.SystemColors.Control;
			this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butLuu.ForeColor = System.Drawing.Color.Navy;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(70, 4);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(64, 28);
			this.butLuu.TabIndex = 1;
			this.butLuu.Text = "      Lưu";
			this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butSua
			// 
			this.butSua.BackColor = System.Drawing.SystemColors.Control;
			this.butSua.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butSua.ForeColor = System.Drawing.Color.Navy;
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(135, 4);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(64, 28);
			this.butSua.TabIndex = 2;
			this.butSua.Text = "      Sữa";
			this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butHuy
			// 
			this.butHuy.BackColor = System.Drawing.SystemColors.Control;
			this.butHuy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butHuy.ForeColor = System.Drawing.Color.Navy;
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(200, 4);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(64, 28);
			this.butHuy.TabIndex = 3;
			this.butHuy.Text = "      Xoá";
			this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
			this.butBoqua.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butBoqua.ForeColor = System.Drawing.Color.Navy;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(265, 4);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(80, 28);
			this.butBoqua.TabIndex = 4;
			this.butBoqua.Text = "      Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butInchiphi
			// 
			this.butInchiphi.BackColor = System.Drawing.SystemColors.Control;
			this.butInchiphi.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butInchiphi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butInchiphi.ForeColor = System.Drawing.Color.Navy;
			this.butInchiphi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butInchiphi.Image")));
			this.butInchiphi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butInchiphi.Location = new System.Drawing.Point(346, 4);
			this.butInchiphi.Name = "butInchiphi";
			this.butInchiphi.Size = new System.Drawing.Size(64, 28);
			this.butInchiphi.TabIndex = 5;
			this.butInchiphi.Text = "        In";
			this.butInchiphi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butInchiphi.Click += new System.EventHandler(this.butInchiphi_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
			this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(411, 4);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(86, 28);
			this.butKetthuc.TabIndex = 6;
			this.butKetthuc.Text = "        Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.DataGrid1.BackColor = System.Drawing.Color.White;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "Máy xét nghiệm";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.ForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DataGrid1.Location = new System.Drawing.Point(4, 4);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.RowHeaderWidth = 16;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.SteelBlue;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(690, 299);
			this.DataGrid1.TabIndex = 0;
			this.DataGrid1.TabStop = false;
			this.DataGrid1.SizeChanged += new System.EventHandler(this.DataGrid1_SizeChanged);
			this.DataGrid1.CurrentCellChanged += new System.EventHandler(this.DataGrid1_CurrentCellChanged);
			// 
			// label10
			// 
			this.label10.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label10.Location = new System.Drawing.Point(-5, 306);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 20);
			this.label10.TabIndex = 147;
			this.label10.Text = "Tên report:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmDMPhieucd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.ClientSize = new System.Drawing.Size(706, 431);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel2,
																		  this.label15,
																		  this.panel1});
			this.DockPadding.All = 3;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmDMPhieucd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Phiếu chỉ định";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDMPhieucd_KeyDown);
			this.SizeChanged += new System.EventHandler(this.frmDMPhieucd_SizeChanged);
			this.Load += new System.EventHandler(this.frmDMPhieucd_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDMPhieucd_Load(object sender, System.EventArgs e)
		{
			f_Load_DG();
			txtTen.Tag="";
			DataGrid1.Tag="";
			butMoi_Click(null,null);
			butBoqua_Click(null,null);
		}
		private void f_Load_DG()
		{
			try
			{
				DataSet ads = null;
				string asql="select reportname ten from cd_phieucd order by reportname";
				ads =m_m.get_data(asql);
				try
				{
					string atmp = ads.Tables[0].TableName;
				}
				catch
				{
					m_m.execute_data("create table cd_phieucd(reportname varchar2(100), constraint pk_cd_phieucd primary key(reportname))");
					ads = m_m.get_data(asql);
				}
				AddGridTableStyle(ads);
				f_resizeDG();
			}
			catch
			{
			}
		}
		private void f_print()
		{
			try
			{
				
				string sql="select * from cd_phieucd order by reportname";
				DataSet ds=m_m.get_data(sql);
			
				//ds.WriteXml("D:\\DMSo.xml",XmlWriteMode.WriteSchema);
				if(ds.Tables[0].Rows.Count>0)
				{
					CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
					crystalReportViewer1.ActiveViewIndex = -1;
					crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
					crystalReportViewer1.DisplayGroupTree = false;
					crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
					crystalReportViewer1.Name = "crystalReportViewer1";
					crystalReportViewer1.ReportSource = null;
					crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
					crystalReportViewer1.TabIndex = 85;
					System.Windows.Forms.Form af = new System.Windows.Forms.Form();
					af.WindowState=FormWindowState.Maximized;
					af.Controls.Add(crystalReportViewer1);
					crystalReportViewer1.BringToFront();
					crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
	
					string areport="",asyt="",abv="",angayin="",anguoiin="",aghichu="";
					areport="cd_phieucd.rpt";
					asyt = m_m.Syte;
					abv = m_m.Tenbv;
					angayin ="Ngày " + DateTime.Now.Day.ToString().PadLeft(2,'0') + " tháng " + DateTime.Now.Month.ToString().PadLeft(2,'0') + " năm " + DateTime.Now.Year.ToString();
					anguoiin = "";
					aghichu = "";

					ReportDocument cMain=new ReportDocument();
					cMain.Load(@"..\..\..\Report\"+areport, OpenReportMethod.OpenReportByTempCopy);
					cMain.SetDataSource(ds);
					cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
					cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
					cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
					cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
					cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
					crystalReportViewer1.ReportSource=cMain;
					af.Text="Danh mục Máy xét nghiệm";
					af.ShowDialog();				
				}
				else
					MessageBox.Show("Trong Máy xét nghiệm không danh mục","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch(Exception ex){ MessageBox.Show(ex.ToString()); }
		}

		private void f_Load_CB()
		{
			try
			{
				//string asql = "select to_char(madoituong) ma, doituong ten from doituong order by madoituong asc";
				//DataSet ads =  m_d.get_data(asql);
				//cbDoiTuong.DisplayMember="TEN";
				//cbDoiTuong.ValueMember="MA";
				//cbDoiTuong.DataSource = ads.Tables[0];
				//cbDoiTuong.SelectedValue="";
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
				TextCol.MappingName = "ten";
				TextCol.HeaderText = "Tên report";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 200;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				DataGrid1.TableStyles.Add(ts);

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
				string aft=f_filter();
				CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource,DataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = false; 
				dv.AllowDelete = false; 
				dv.AllowEdit = false; 
				dv.RowFilter=aft;
				int n=20;

				if(dv.Table.Select(aft).Length>13)
				{
					DataGrid1.TableStyles[0].GridColumnStyles[0].Width = DataGrid1.Width - n - 16;
				}
				else
				{
					DataGrid1.TableStyles[0].GridColumnStyles[0].Width = DataGrid1.Width - n;
				}
				DataGrid1.CaptionText="Máy xét nghiệm: "+dv.Table.Select(aft).Length.ToString();
				DataGrid1.Update();
			}
			catch
			{
				DataGrid1.CaptionText="Máy xét nghiệm";
			}
		}
		private string f_filter()
		{
			try
			{
				string aft="";				
				if(txtTim.Text!="Tìm kiếm")
				{
					if( aft.Length>0)
					{
						aft=aft+" and (ten like '%"+ txtTim.Text+"%')";
					}
					else
					{
						aft="ten like '%"+ txtTim.Text+"%'";
					}					
				}													 
				return aft;
			}
			catch
			{				
				return "";
			}
		}
		#region Datagrid Colored Collum
		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
			try
			{
				switch (col.ToString())
				{
					case "0":
						c=Color.Black;
						break;
					case "1":
						c=Color.Blue;
						break;
					case "2":
						c=Color.Red;
						break;
					case "3":
						c=Color.Orange;
						break;
					case "4":
						c=Color.Cyan;
						break;
					default:
						c=Color.Black;
						break;
				}
				if(DataGrid1[row,4].ToString()=="1")
				{
					c=Color.DarkGray;
				}
			}
			catch
			{
			}
			return c;
		}

		private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource,DataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = false; 
				dv.AllowDelete = false; 
				dv.AllowEdit = false; 
				string aid="";
								
				if(txtTen.Text.Trim().Length<=0)
				{
					MessageBox.Show(this,"Nhập tên report","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					txtTen.Focus();
					return;
				}
				try
				{
					aid = txtTen.Tag.ToString().Trim();
				}
				catch
				{
					aid="";
				}
				if(aid=="")
				{
					if(m_m.get_data("select reportname from cd_phieucd where lower(trim(reportname))='"+txtTen.Text.Trim().ToLower()+"'").Tables[0].Rows.Count>0)
					{
						MessageBox.Show(this,"Đã tồn tại, chọn tên khác","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						txtTen.Focus();
						return;
					}
				}
				else
				{
					if(m_m.get_data("select reportname from cd_phieucd where lower(trim(reportname))='"+txtTen.Text.Trim().ToLower()+"' and lower(trim(reportname))<>'"+aid+"'").Tables[0].Rows.Count>0)
					{
						MessageBox.Show(this,"Đã tồn tại, chọn tên khác","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						txtTen.Focus();
						return;
					}
				}
				
				if(aid!="")
				{
					m_m.execute_data("delete from cd_phieucd where lower(trim(reportname))='"+aid.ToLower().Trim()+"'");
					m_m.execute_data("update cd_thongsophieucd set report='"+txtTen.Text.Trim().ToLower()+"' where lower(trim(report))='"+aid.ToLower().Trim()+"'");
				}
				else
				{
				}

				if(txtTen.Text.Trim()!="")
				{
					m_m.execute_data("insert into cd_phieucd (reportname) values('"+txtTen.Text.Trim().ToLower()+"')");
				}
				f_Load_DG();
				f_resizeDG();
				txtTen.Enabled=false;
				txtTen.Tag=aid;
				butMoi.Enabled = true;
				butLuu.Enabled=false;
				butHuy.Enabled=true;
				butSua.Enabled=true;
				butMoi.Focus();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTen.Tag.ToString()!="")
				{
					if(MessageBox.Show(this,"Đồng ý xoá?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
					{
						m_m.execute_data("delete from cd_phieucd where lower(trim(reportname))='"+txtTen.Tag.ToString().Trim().ToLower()+"'");
						f_Load_DG();
						butMoi_Click(null,null);
					}
				}
			}
			catch
			{
			}
		}

		private void frmDMPhieucd_SizeChanged(object sender, System.EventArgs e)
		{
			try
			{
				//this.WindowState=FormWindowState.Normal;
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
				DataGrid1.UnSelect(int.Parse(DataGrid1.Tag.ToString()));
			}
			catch
			{
			}

			try
			{
				DataGrid1.Tag = DataGrid1.CurrentCell.RowNumber;
				DataGrid1.Select(int.Parse(DataGrid1.Tag.ToString()));
				//DataGrid1.CurrentCell =  new DataGridCell(DataGrid1.CurrentCell.RowNumber,0);
			}
			catch
			{
			}

			try
			{
				txtTen.Tag = "";
				CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource,DataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = false; 
				dv.AllowDelete = false; 
				dv.AllowEdit = false; 
				int i = DataGrid1.CurrentRowIndex;
				DataRow []rs = dv.Table.Select("id='"+ DataGrid1[DataGrid1.CurrentRowIndex,0].ToString().Trim()+"'");
				if(rs.Length>0)
				{
					txtTen.Tag=rs[0]["ten"].ToString();
					txtTen.Text=rs[0]["ten"].ToString();
					txtTen.Enabled=false;
				}
			}
			catch
			{
			}
			butLuu.Enabled=(txtTen.Tag.ToString()=="");
			butSua.Enabled=(txtTen.Tag.ToString()!="");
			butHuy.Enabled=(txtTen.Tag.ToString()!="");
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTen.Tag.ToString()!="")
				{
					txtTen.Enabled=true;
			
					butMoi.Enabled=false;
					butLuu.Enabled=true;
					butHuy.Enabled=false;
					butSua.Enabled=false;

					txtTen.Focus();
				}
			}
			catch
			{
			}
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
				txtTen.Tag="";
				txtTen.Text="";
				txtTen.Enabled=true;
				butMoi.Enabled=false;
				butLuu.Enabled=true;
				butHuy.Enabled=false;
				butSua.Enabled=false;
				txtTen.Focus();
			}
			catch
			{
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			try
			{
				txtTen.Enabled=false;
				butMoi.Enabled=true;
				butLuu.Enabled=false;
				butHuy.Enabled=false;
				butSua.Enabled=false;
				butMoi.Focus();
			}
			catch
			{
			}
		}

		private void txtTen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}
		private void txtTim_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				string aft=f_filter();
				CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource,DataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew=false;
				dv.AllowEdit=false;
				dv.RowFilter=aft;
				DataGrid1.CaptionText="Máy xét nghiệm: "+dv.Table.Select(aft).Length.ToString();
				f_resizeDG();
			}
			catch{}
		}

		private void txtTim_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTim.Text=="")
				{
					txtTim.Text="Tìm kiếm";
				}
			}
			catch
			{
			}
		}

		private void txtTim_Enter(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTim.Text=="Tìm kiếm")
				{
					txtTim.Text="";
				}
			}
			catch
			{
			}		
		}

		private void txtTim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}
		private void butInchiphi_Click(object sender, System.EventArgs e)
		{
			f_print();
		}		
		private void lbRefresh_Click(object sender, System.EventArgs e)
		{
			f_Load_DG();
		}

		private void chkBV_CheckedChanged(object sender, System.EventArgs e)
		{
			f_resizeDG();
		}

		private void frmDMPhieucd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}
		private void DataGrid1_SizeChanged(object sender, System.EventArgs e)
		{
			f_resizeDG();
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
					//foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
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
