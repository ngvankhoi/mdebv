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
using System.IO;
using Excel;
using LibVP;

namespace Vienphi
{	
	public class frmReport : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private ReportDocument cMain;
		private AccessData m_v;        
        private string ReportFile;
        private System.Data.DataTable dt = new System.Data.DataTable();
        private string c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21;
        private bool thue = false, bKetxuatExcel = true;
        private ExportOptions crExportOptions;
        private DiskFileDestinationOptions crDiskFileDestinationOptions;
        private string ExportPath;

		public bool bPrinter;
        private int I1= 0;
		private System.Windows.Forms.NumericUpDown banin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown den;
        private System.Windows.Forms.Button butExcel;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Report;

        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        private System.Windows.Forms.Button butPdf;        

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


        public bool KetxuatExcel
        {
            set
            {
                bKetxuatExcel = false;
            }
        }
        public frmReport(LibVP.AccessData acc, System.Data.DataTable ta, string report, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string tieude,int i,bool Xemtruoc)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m_v = acc; dt = ta;
            c1 = s1; c2 = s2; c3 = s3; c4 = s4; c5 = s5;
            c6 = s6; c7 = s7; c8 = s8; c9 = s9; I1 = i; bPrinter = Xemtruoc;
            ReportFile = report; this.Text = tieude+ " ( " + report+" )";

        }
        public frmReport(LibVP.AccessData acc, System.Data.DataTable ta, string report, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15,bool co,string tieude)
		{
			InitializeComponent();
            m_v = acc; dt = ta;
            c1 = s1; c2 = s2; c3 = s3; c4 = s4; c5 = s5; c6 = s6;
            c7 = s7; c8 = s8; c9 = s9; c10 = s10; c11 = s11; c12 = s12; c13 = s13; c14 = s14; c15 = s15; thue = co;
            ReportFile = report; this.Text = tieude + " ( " + report + " )";
		}

        public frmReport(LibVP.AccessData acc, System.Data.DataTable ta, string report, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15, string s16, string s17, string s18, string s19, string s20, string s21, string tieude)
        {
            InitializeComponent();
            m_v = acc; dt = ta;
            c1 = s1; c2 = s2; c3 = s3; c4 = s4; c5 = s5; c6 = s6;
            c7 = s7; c8 = s8; c9 = s9; c10 = s10; c11 = s11; c12 = s12; c13 = s13; c14 = s14; c15 = s15; c16 = s16; c17 = s17; c18 = s18; c19 = s19; c20 = s20; c21 = s21;
            ReportFile = report; this.Text = tieude + " ( " + report + " )";
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
            this.banin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.butExcel = new System.Windows.Forms.Button();
            this.Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.butPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            this.SuspendLayout();
            // 
            // banin
            // 
            this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banin.Location = new System.Drawing.Point(365, 4);
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
            this.label1.Location = new System.Drawing.Point(300, 3);
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
            this.butKetthuc.Location = new System.Drawing.Point(739, 3);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(74, 23);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(554, 3);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 23);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "      In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(391, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(431, 4);
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
            this.label3.Location = new System.Drawing.Point(469, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(510, 4);
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
            this.butExcel.Location = new System.Drawing.Point(624, 3);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(60, 23);
            this.butExcel.TabIndex = 7;
            this.butExcel.Text = "      Excel";
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // Report
            // 
            this.Report.ActiveViewIndex = -1;
            this.Report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Report.DisplayGroupTree = false;
            this.Report.DisplayStatusBar = false;
            this.Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report.Location = new System.Drawing.Point(0, 0);
            this.Report.Name = "Report";
            this.Report.SelectionFormula = "";
            this.Report.ShowCloseButton = false;
            this.Report.ShowRefreshButton = false;
            this.Report.Size = new System.Drawing.Size(820, 573);
            this.Report.TabIndex = 11;
            this.Report.ViewTimeSelectionFormula = "";
            // 
            // butPdf
            // 
            this.butPdf.Image = ((System.Drawing.Image)(resources.GetObject("butPdf.Image")));
            this.butPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPdf.Location = new System.Drawing.Point(684, 3);
            this.butPdf.Name = "butPdf";
            this.butPdf.Size = new System.Drawing.Size(55, 22);
            this.butPdf.TabIndex = 12;
            this.butPdf.Text = "PDF";
            this.butPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPdf.UseVisualStyleBackColor = true;
            this.butPdf.Click += new System.EventHandler(this.butPdf_Click);
            // 
            // frmReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butKetthuc;
            this.ClientSize = new System.Drawing.Size(820, 573);
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
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viện phí .NET";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
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
            butExcel.Enabled = bKetxuatExcel;
            Report.ShowExportButton = bKetxuatExcel;
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

            int o=I1;
            if (thue) BC_Thue();
            else if (I1==1) BC_Thutructiep();
            else if (c21 != "") BC_tonghop();
            //else BC_Thutructiep();    
		    
		}

		private void BC_Thutructiep()
		{
			try
			{
				cMain=new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + ReportFile, OpenReportMethod.OpenReportByTempCopy);	
               
                cMain.SetDataSource(dt);
                cMain.DataDefinition.FormulaFields["v_syt"].Text  ="'"+c1+"'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + c2 + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + c3 + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + c4 + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + c5 + "'";
                if (c6 != "")
                {
                    cMain.DataDefinition.FormulaFields["v_nguoilapphieu"].Text = "'" + c6 + "'";
                }
                if (c7 != "")
                {
                    cMain.DataDefinition.FormulaFields["v_thuquy"].Text = "'" + c7 + "'";
                }
                if (c8 != "")
                {
                    cMain.DataDefinition.FormulaFields["v_ketoanvp"].Text = "'" + c8 + "'";
                }
                if (c9 != "")
                {
                    cMain.DataDefinition.FormulaFields["v_phongtckt"].Text = "'" + c9 + "'";
                }                
                cMain.PrintOptions.PaperSize = PaperSize.PaperA4;
                Report.ReportSource = cMain;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}

        private void BC_Thue()
        {
            try
            {
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + ReportFile, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(dt);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + c1 + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + c2 + "'";
                cMain.DataDefinition.FormulaFields["v_diachi"].Text = "'" + c3 + "'";
                cMain.DataDefinition.FormulaFields["v_masothue"].Text = "'" + c4 + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + c5 + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + c6 + "'";
                cMain.DataDefinition.FormulaFields["v_nguoilapbang"].Text = "'" + c7 + "'";
                cMain.DataDefinition.FormulaFields["v_cucthue"].Text = "'" + c8 + "'";
                cMain.DataDefinition.FormulaFields["v_mau"].Text = "'" + c9 + "'";
                cMain.DataDefinition.FormulaFields["v_so"].Text = "'" + c10 + "'";
                cMain.DataDefinition.FormulaFields["v_ketoantruong"].Text = "'" + c11 + "'";
                cMain.DataDefinition.FormulaFields["v_giamdoc"].Text = "'" + c12 + "'";
                cMain.DataDefinition.FormulaFields["v_tylenop"].Text = "'" + c13 + "'";
                cMain.DataDefinition.FormulaFields["v_hoan"].Text = "'" + c14 + "'";
                cMain.DataDefinition.FormulaFields["v_lamtron"].Text = "'" + c15 + "'";

                cMain.PrintOptions.PaperSize = PaperSize.PaperA4;
                Report.ReportSource = cMain;

            }
            catch (Exception e)
            {
                MessageBox.Show("The following error was discovered: '" + e.Message + "'. It was occured in '" + e.StackTrace + "'", "Report Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BC_tonghop()
        {
            try
            {
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + ReportFile, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(dt);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + c1 + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + c2 + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + c3 + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + c4 + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + c5 + "'";
                cMain.DataDefinition.FormulaFields["v_chutien"].Text = "'" + c6 + "'";
                cMain.DataDefinition.FormulaFields["v_tenloai"].Text = "'" + c7 + "'";
                cMain.DataDefinition.FormulaFields["v_nguoilapphieu"].Text = "'" + c8 + "'";
                cMain.DataDefinition.FormulaFields["v_ketoanvp"].Text = "'" + c9 + "'";
                cMain.DataDefinition.FormulaFields["v_thuquy"].Text = "'" + c10 + "'";
                cMain.DataDefinition.FormulaFields["v_lock00"].Text = "'" + c11 + "'";
                cMain.DataDefinition.FormulaFields["v_lock01"].Text = "'" + c12 + "'";
                cMain.DataDefinition.FormulaFields["v_lock02"].Text = "'" + c13 + "'";
                cMain.DataDefinition.FormulaFields["v_lock03"].Text = "'" + c14 + "'";
                cMain.DataDefinition.FormulaFields["v_lock04"].Text = "'" + c15 + "'";
                cMain.DataDefinition.FormulaFields["v_lock05"].Text = "'" + c16 + "'";
                cMain.DataDefinition.FormulaFields["v_lock06"].Text = "'" + c17 + "'";
                cMain.DataDefinition.FormulaFields["v_locklast"].Text = "'" + c18 + "'";
                cMain.DataDefinition.FormulaFields["v_luykethang"].Text = "'" + c19 + "'";
                cMain.DataDefinition.FormulaFields["v_luykenam"].Text = "'" + c20 + "'";
                cMain.DataDefinition.FormulaFields["v_lamtron"].Text = "'" + c21 + "'";

                cMain.PrintOptions.PaperSize = PaperSize.PaperA4;
                Report.ReportSource = cMain;
            }
            catch (Exception e)
            {
                MessageBox.Show("The following error was discovered: '" + e.Message + "'. It was occured in '" + e.StackTrace + "'", "Report Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			bPrinter=false;
			this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			bPrinter=true;
			try
			{
				cMain.PrintToPrinter(Convert.ToInt16(banin.Value),false,Convert.ToInt16(tu.Value),Convert.ToInt16(den.Value));
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
			Cursor=Cursors.Default;
			this.Close();
		}

		private void frmReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F9: butIn_Click(sender,e);break;
				case Keys.F7: butExcel_Click(sender,e);break;
				case Keys.F10: butKetthuc_Click(sender,e);break;
                case Keys.F5: butPdf_Click(sender, e); break;
			}
		}		
		
		private void butExcel_Click(object sender, System.EventArgs e)
		{
            if (butExcel.Enabled == false)
            {
                MessageBox.Show("Bạn chưa được phân quyền kết xuất.");                
                return;
            }
            m_v.check_process_Excel();
            string tenfile = m_v.f_export_excel(dt,ReportFile);
            oxl = new Excel.Application();
            owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
            osheet = (Excel._Worksheet)owb.ActiveSheet;
            oxl.ActiveWindow.DisplayGridlines = true;
            oxl.ActiveWindow.DisplayZeros = false;
            osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
            osheet.PageSetup.LeftMargin = 20;
            osheet.PageSetup.RightMargin = 20;
            osheet.PageSetup.TopMargin = 30;
            osheet.PageSetup.CenterFooter = "Trang : &P/&N";
            oxl.Visible = true;
		}

		private void banin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

        private void butPdf_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string tenfile = ReportFile.ToLower().Replace(".rpt", "");
            tenfile = ExportPath + tenfile + ".pdf";
            crDiskFileDestinationOptions = new DiskFileDestinationOptions();
            crExportOptions = cMain.ExportOptions;
            crDiskFileDestinationOptions.DiskFileName = tenfile;
            crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
            crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            cMain.Export();
            try
            {
                string filerun = "AcroRd32.exe", arg = tenfile;
               // string filerun = "C:\\Program Files\\Foxit Software\\Foxit Reader\\Foxit Reader.exe", arg = tenfile;
                if (System.IO.File.Exists(arg))
                {
                    run f = new run(filerun, arg, true);
                    f.Launch();
                }
            }
            catch
            {
                MessageBox.Show(lan.Change_language_MessageText("Tập tin :") + tenfile);
            }
            this.Cursor = Cursors.Default;
        }
	}
}