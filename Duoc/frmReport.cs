using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;
using LibDuoc;
using LibMedi;
using System.IO;

namespace Duoc
{
	/// <summary>
	/// Summary description for Freport.
	/// </summary>
	public class frmReport : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		//binh
        string s_dirreport = "report", s_fomular = "";
		int i_soluong_le=0,i_dongia_le=0,i_thanhtien_le=0;
		int i_nhom=1;
        bool bAdminHethong = false;
        private int d_userid = 0;
		//
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		ReportDocument oRpt;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private string ReportFile;
		private System.Data.DataTable dt=new System.Data.DataTable();
        private DataSet ds = new DataSet();
		private CrystalDecisions.Windows.Forms.CrystalReportViewer Report;
		private string c1="",c2="",c3="",c4="",c5="",c6="",c7="",c8="",c9="",c10="",c11="",c12="",msg="";
		private bool b_bienlai=false,bDs=false;
		public bool bPrinter;
		private System.Windows.Forms.NumericUpDown banin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.Button butExcel;
        private System.Windows.Forms.Button butPdf;
        private string ExportPath;
        ExportOptions crExportOptions;
        DiskFileDestinationOptions crDiskFileDestinationOptions;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReport(LibDuoc.AccessData acc,System.Data.DataTable ta, int _userid, string mMsg,string report)
		{
			InitializeComponent();
			dt=ta;d=acc;
			msg=mMsg;
			ReportFile=report;
			this.Text=report;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            d_userid = _userid;
        }

        public frmReport(LibDuoc.AccessData acc, DataSet dset, int _userid, string mMsg, string report)
        {
            InitializeComponent();
            d = acc;
            ds = dset; bDs = true;
            msg = mMsg;
            ReportFile = report;
            this.Text = report;
            d_userid = _userid;
        }

        public frmReport(LibDuoc.AccessData acc, System.Data.DataTable ta, int _userid, string mMsg, string report, decimal soban)
        {
            InitializeComponent();
            dt = ta; d = acc;
            msg = mMsg;
            ReportFile = report;
            this.Text = report;
            banin.Value = soban;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            d_userid = _userid;
        }

        public frmReport(LibDuoc.AccessData acc, System.Data.DataTable ta, int _userid, string report, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10)
		{
			InitializeComponent();
			d=acc;dt=ta;
			c1=s1;c2=s2;c3=s3;c4=s4;c5=s5;
			c6=s6;c7=s7;c8=s8;c9=s9;c10=s10;
			ReportFile=report;this.Text=report;
            d_userid = _userid;
        }

        public frmReport(LibDuoc.AccessData acc, System.Data.DataTable ta, int _userid, string report, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, int soban)
        {
            InitializeComponent();
            d = acc; dt = ta;
            c1 = s1; c2 = s2; c3 = s3; c4 = s4; c5 = s5;
            c6 = s6; c7 = s7; c8 = s8; c9 = s9; c10 = s10;
            ReportFile = report; this.Text = report;
            banin.Value = decimal.Parse(soban.ToString());
            d_userid = _userid;
        }

        public frmReport(LibDuoc.AccessData acc, System.Data.DataTable ta, int _userid, string report, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12)
		{
			InitializeComponent();
			d=acc;dt=ta;
			c1=s1;c2=s2;c3=s3;c4=s4;c5=s5;c6=s6;
			c7=s7;c8=s8;c9=s9;c10=s10;c11=s11;c12=s12;
			ReportFile=report;this.Text=report;
            d_userid = _userid;
		}

        public frmReport(LibDuoc.AccessData acc, System.Data.DataTable ta, int _userid, string report, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, decimal soban)
        {
            InitializeComponent();
            d = acc; dt = ta;
            c1 = s1; c2 = s2; c3 = s3; c4 = s4; c5 = s5; c6 = s6;
            c7 = s7; c8 = s8; c9 = s9; c10 = s10; c11 = s11; c12 = s12; banin.Value = soban;
            ReportFile = report; this.Text = report;
            d_userid = _userid;
        }

        public frmReport(LibDuoc.AccessData acc, System.Data.DataTable ta, int _userid, string s1, string s2, string report)
		{
			InitializeComponent();
			d=acc;
			dt=ta;
			c1=s1;c2=s2;
			b_bienlai=true;
			ReportFile=report;
			this.Text=report;
            d_userid = _userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.banin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.butExcel = new System.Windows.Forms.Button();
            this.butPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            this.SuspendLayout();
            // 
            // Report
            // 
            this.Report.ActiveViewIndex = -1;
            this.Report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Report.DisplayGroupTree = false;
            this.Report.Location = new System.Drawing.Point(-1, 0);
            this.Report.Name = "Report";
            this.Report.SelectionFormula = "";
            this.Report.ShowCloseButton = false;
            this.Report.ShowRefreshButton = false;
            this.Report.Size = new System.Drawing.Size(376, 150);
            this.Report.TabIndex = 9;
            this.Report.ViewTimeSelectionFormula = "";
            // 
            // banin
            // 
            this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banin.Location = new System.Drawing.Point(375, 5);
            this.banin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.banin.Name = "banin";
            this.banin.Size = new System.Drawing.Size(38, 21);
            this.banin.TabIndex = 1;
            this.banin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.banin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(310, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Số bản in :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(798, 4);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(588, 4);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "      In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(409, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ trang :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(462, 5);
            this.tu.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(44, 21);
            this.tu.TabIndex = 3;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(500, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(541, 5);
            this.den.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(44, 21);
            this.den.TabIndex = 5;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
            // 
            // butExcel
            // 
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(658, 4);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(70, 25);
            this.butExcel.TabIndex = 7;
            this.butExcel.Text = "      Excel";
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // butPdf
            // 
            this.butPdf.Image = ((System.Drawing.Image)(resources.GetObject("butPdf.Image")));
            this.butPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPdf.Location = new System.Drawing.Point(728, 4);
            this.butPdf.Name = "butPdf";
            this.butPdf.Size = new System.Drawing.Size(70, 25);
            this.butPdf.TabIndex = 11;
            this.butPdf.Text = "PDF";
            this.butPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPdf.UseVisualStyleBackColor = true;
            this.butPdf.Click += new System.EventHandler(this.butPdf_Click);
            // 
            // frmReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butKetthuc;
            this.ClientSize = new System.Drawing.Size(1016, 713);
            this.Controls.Add(this.butPdf);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.banin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.Report);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viện phí .NET";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.banin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmReport_Load(object sender, System.EventArgs e)
		{
			this.Report.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width,Screen.PrimaryScreen.WorkingArea.Height);
			this.Size= new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width,Screen.PrimaryScreen.WorkingArea.Height);
            string dir = System.IO.Directory.GetCurrentDirectory();
            //
            bAdminHethong = d.bAdmin(d_userid);
            i_nhom = get_nhomkho();
            if (!bAdminHethong && d.bUserthuong_CamxuatExcel_E11(i_nhom))
            {
                butExcel.Enabled = false;
                Report.ShowExportButton = false;
            }
            //            
            ExportPath = "";
            int j = 0;
            for (int i = 0; i < dir.Length; i++)
            {
                if (dir.Substring(i, 1) == "\\") j++;
                if (j == 2) break;
                ExportPath += dir.Substring(i, 1);
            }
            ExportPath += "\\pdf\\";
            if (!System.IO.Directory.Exists(ExportPath)) System.IO.Directory.CreateDirectory(ExportPath);			
			s_dirreport=get_dirreport(56);//doc thu muc report cua tung benh vien			
			i_soluong_le=d.d_soluong_le(i_nhom);
			i_dongia_le=d.d_dongia_le(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			//
			if (b_bienlai) Bienlai();
			else if (ReportFile.ToString().ToLower()=="d_phieunhap.rpt")  Phieunhap();
            else if (bDs) Reportds();
			else if (msg!="") treem();
			else PreviewReport();
		}

		private void treem()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dt);
                oRpt.DataDefinition.FormulaFields["SoYTe"].Text = "'" + m.Syte.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["BenhVien"].Text = "'" + m.Tenbv.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["TenBenhAn"].Text = "'" + msg.Replace("'", "''") + "'";
				if (ReportFile!="bieu_07.rpt") oRpt.DataDefinition.FormulaFields["treem"].Text=m.iTreem6tuoi.ToString();
                //oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}

        private void Reportds()
        {
            try
            {
                oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\" + ReportFile, OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(ds);
                oRpt.DataDefinition.FormulaFields["SoYTe"].Text = "'" + m.Syte.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["BenhVien"].Text = "'" + m.Tenbv.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["TenBenhAn"].Text = "'" + msg.Replace("'", "''") + "'";
                if (ReportFile != "bieu_07.rpt") oRpt.DataDefinition.FormulaFields["treem"].Text = m.iTreem6tuoi.ToString();
                //oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                Report.ReportSource = oRpt;
            }
            catch (Exception e)
            {
                MessageBox.Show("The following error was discovered: '" + e.Message + "'. It was occured in '" + e.StackTrace + "'", "Report Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }	

		private void Bienlai()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dt);
				if (c1!="")
				{
                    oRpt.DataDefinition.FormulaFields["s_nguoithu"].Text = "'" + c1.Replace("'", "''") + "'";
                    oRpt.DataDefinition.FormulaFields["s_sovaovien"].Text = "'" + c2.Replace("'", "''") + "'";
				}
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
				//oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
				//oRpt.PrintOptions.PaperOrientation=PaperOrientation.Landscape;
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}		
		private void PreviewReport()
		{
			try
			{
				oRpt=new ReportDocument();
				if(Directory.Exists("..\\..\\..\\"+s_dirreport)==false)s_dirreport="report";
				oRpt.Load("..\\..\\..\\"+s_dirreport+"\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dt);
                s_fomular = "soyte";
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte.Replace("'", "''") + "'"; s_fomular = "benhvien";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv.Replace("'", "''") + "'"; s_fomular = "c1";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + c1.Replace("'", "''") + "'"; s_fomular = "c2";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + c2.Replace("'", "''") + "'"; s_fomular = "c3";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + c3.Replace("'", "''") + "'"; s_fomular = "c4";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + c4.Replace("'", "''") + "'"; s_fomular = "c5";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + c5.Replace("'", "''") + "'"; s_fomular = "c6";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + c6.Replace("'", "''") + "'"; s_fomular = "c7";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + c7.Replace("'", "''") + "'"; s_fomular = "c8";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + c8.Replace("'", "''") + "'"; s_fomular = "c9";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + c9.Replace("'", "''") + "'"; s_fomular = "c10";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + c10.Replace("'", "''") + "'"; s_fomular = "";
				if (ReportFile=="d_bhyt.rpt" || ReportFile=="d_treem.rpt")
                {
                    s_fomular = "giamdoc";
                    oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + c11.Replace("'", "''") + "'";
                }
                else if (ReportFile == "d_phieunhap_nhom.rpt")
                {
                    s_fomular = "diachi";
                    oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + c11.Replace("'", "''") + "'";
                }
				else
                {
                    s_fomular = "giamdoc";
                    oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom).Replace("'", "''") + "'";
                }
                s_fomular = "phutrach";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom).Replace("'", "''") + "'";
				if (ReportFile=="d_bhyt.rpt")
                {
                   s_fomular = "thongke";
                   oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + c12.Replace("'", "''") + "'";
                }
                else if (ReportFile == "d_phieunhap_nhom.rpt")
                {
                    s_fomular = "masothue";
                    oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + c12.Replace("'", "''") + "'"; 
                }
                else
                {
                    s_fomular = "thongke";
                    oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom).Replace("'", "''") + "'"; 
                }
                s_fomular = "ketoan";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom).Replace("'", "''") + "'"; s_fomular = "thukho";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom).Replace("'", "''") + "'";s_fomular = "";
				//
				//binh
                if (ReportFile != "d_ctduoc.rpt")
                {
                    s_fomular = "l_soluong";
                    oRpt.DataDefinition.FormulaFields["l_soluong"].Text = i_soluong_le.ToString(); s_fomular = "l_dongia";
                    oRpt.DataDefinition.FormulaFields["l_dongia"].Text = i_dongia_le.ToString(); s_fomular = "l_thanhtien";
                    oRpt.DataDefinition.FormulaFields["l_thanhtien"].Text = i_thanhtien_le.ToString();s_fomular = "";
                }
				//
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
                if (s_fomular != "") MessageBox.Show("Thiếu formula " + s_fomular+"\nĐề nghị mở report ra bổ sung thêm formula: "+s_fomular);
                else
				    MessageBox.Show ("The following error was discovered: '"+e.ToString()+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}
		private void Phieunhap()
		{
			try
			{
				oRpt=new ReportDocument();
				if(Directory.Exists("..\\..\\..\\"+s_dirreport)==false)s_dirreport="report";
				oRpt.Load("..\\..\\..\\"+s_dirreport+"\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dt);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + c1.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + c2.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + c3.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + c4.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + c5.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + c6.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + c7.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + c8.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + c9.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + c10.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + c11.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + c12.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom).Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom).Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom).Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom).Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom).Replace("'", "''") + "'";
				//
				//binh
				oRpt.DataDefinition.FormulaFields["l_soluong"].Text=i_soluong_le.ToString();
				oRpt.DataDefinition.FormulaFields["l_dongia"].Text=i_dongia_le.ToString();
				oRpt.DataDefinition.FormulaFields["l_thanhtien"].Text=i_thanhtien_le.ToString();
				//
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			bPrinter=false;
            oRpt.Close(); oRpt.Dispose();
			d.close();this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			bPrinter=true;
			try
			{
				oRpt.PrintToPrinter(Convert.ToInt16(banin.Value),false,Convert.ToInt16(tu.Value),Convert.ToInt16(den.Value));
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
			Cursor=Cursors.Default;
            oRpt.Close(); oRpt.Dispose();
			d.close();this.Close();
		}

		private void frmReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.F5: butPdf_Click(sender, e); break;
				case Keys.F9: butIn_Click(sender,e);break;
				case Keys.F7: butExcel_Click(sender,e);break;
				case Keys.F10: butKetthuc_Click(sender,e);break;
			}
		}		
		//binh
		private string get_dirreport(int s_id)
		{
			string s_dir="";
			string sql="select * from "+d.user+".d_thongso where id="+s_id+" and nhom="+i_nhom;
			try
			{
				System.Data.DataTable dt=d.get_data(sql).Tables[0];
				foreach(DataRow r in dt.Rows)
				{
					s_dir=r["ten"].ToString().Trim();
				}
				dt.Dispose();
			}
			catch{}
			return (s_dir=="")?"report":s_dir;
		}		
		private int get_nhomkho()
		{
			DataSet lds=new DataSet();
			lds.ReadXml("..\\..\\..\\xml\\d_nhomkholog.xml");
			int i_nhomkho=1;
			foreach(DataRow r in lds.Tables[0].Rows)
			{
				i_nhomkho=int.Parse(r["nhomkho"].ToString());
				break;
			}
			lds.Dispose();
			return i_nhomkho;
		}

		private void butExcel_Click(object sender, System.EventArgs e)
		{
            if (butExcel.Enabled == false) return;
			d.check_process_Excel();
			string tenfile=d.Export_Excel(dt,ReportFile.Substring(0,ReportFile.Length-4));
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			oxl.ActiveWindow.DisplayZeros=false;
            try
            {
                osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                osheet.PageSetup.LeftMargin = 20;
                osheet.PageSetup.RightMargin = 20;
                osheet.PageSetup.TopMargin = 30;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
            }
            catch { }
			oxl.Visible=true;
		}

		private void banin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
		#region binh_writemenubar
		//copy theo Tan
		private void f_WriteMenu(MainMenu v_m)
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add();
				ads.Tables[0].Columns.Add("TEN");
				string t="";
				for(int i=0;i<v_m.MenuItems.Count-3;i++)
				{
					for(int j=0;j<v_m.MenuItems[i].MenuItems.Count;j++)
					{
						if((v_m.MenuItems[i].MenuItems[j].Text.Trim()!="-")&&(v_m.MenuItems[i].MenuItems[j].Text.Trim().ToUpper().IndexOf("LOG OFF")<0)&&(v_m.MenuItems[i].MenuItems[j].MenuItems.Count<=0))
						{
							t=v_m.MenuItems[i].MenuItems[j].Text.Trim().Replace("&","");
							try
							{
								t=t.Substring(t.IndexOf(".")+1).Trim();
							}
							catch
							{
							}
							if(t!="")
								ads.Tables[0].Rows.Add(new string[] {t});
						}
						else
						{
							for(int k=0;k<v_m.MenuItems[i].MenuItems[j].MenuItems.Count;k++)
							{
								if((v_m.MenuItems[i].MenuItems[j].MenuItems[k].Text.Trim()!="-")&&(v_m.MenuItems[i].MenuItems[j].MenuItems[k].Text.Trim().ToUpper().IndexOf("LOG OFF")<0)&&(v_m.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems.Count<=0))
								{
									t=v_m.MenuItems[i].MenuItems[j].MenuItems[k].Text.Trim().Replace("&","");
									try
									{
										t=t.Substring(t.IndexOf(".")+1).Trim();
									}
									catch
									{
									}
									if(t!="")
										ads.Tables[0].Rows.Add(new string[] {t});
								}
								else
								{
									for(int l=0;l<v_m.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems.Count;k++)
									{
										if((v_m.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].Text.Trim()!="-")&&(v_m.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].Text.Trim().ToUpper().IndexOf("LOG OFF")<0)&&(v_m.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].MenuItems.Count<=0))
										{
											t=v_m.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[l].Text.Trim().Replace("&","");
											try
											{
												t=t.Substring(t.IndexOf(".")+1).Trim();
											}
											catch
											{
											}
											if(t!="")
												ads.Tables[0].Rows.Add(new string[] {t});
										}
										else
										{
										}
									}
								}
							}
						}
					}
				}
				ads.WriteXml("..//..//..//xml//d_menubar.xml");
			}
			catch
			{
			}
		}
		private void get_nhomkho(int i_userid)
		{
			string sql="select nhomkho from "+d.user+".d_dlogin where id='"+i_userid+"'";
			DataSet lds=d.get_data(sql);
			lds.WriteXml("..\\..\\..\\xml\\d_nhomkholog.xml",XmlWriteMode.WriteSchema);
		}
		#endregion

        private void butPdf_Click(object sender, EventArgs e)
        {
            string tenfile = ReportFile.ToLower().Replace(".rpt", "");
            tenfile = ExportPath + tenfile + ".pdf";
            crDiskFileDestinationOptions = new DiskFileDestinationOptions();
            crExportOptions = oRpt.ExportOptions;
            crDiskFileDestinationOptions.DiskFileName = tenfile;
            crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
            crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            oRpt.Export();
            try
            {
                string filerun = "AcroRd32.exe", arg = tenfile;
                if (System.IO.File.Exists(arg))
                {
                    backup f = new backup(filerun, arg, true);
                    f.Launch();
                }
            }
            catch
            {
                MessageBox.Show(lan.Change_language_MessageText("Tập tin :")+" "+ tenfile);
            }
        }
	}
}