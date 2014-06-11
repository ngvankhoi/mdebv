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
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;
using LibMedi;

using System.Diagnostics;
namespace XN
{
	
	public class frmPrintAll : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer Report;
        private System.Windows.Forms.Button butPdf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butExcel;
        private System.Windows.Forms.Button butIn;
        private NumericUpDown den;
        private NumericUpDown tu;
        private NumericUpDown banin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        public bool bPrinter;
        private string ExportPath,aReport="report.rpt";
        private DataSet ds;
        ExportOptions crExportOptions;
        DiskFileDestinationOptions crDiskFileDestinationOptions;
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private ReportDocument oRpt;

		/// <summary>
		///Cách sử dụng:
		///- Khi muốn in một mẩu báo cáo nào đó ta làm các bước sau:
		///1. Mở form frmPrintAll này lên
		///2. Khai báo vá định nghĩa tên hàm mới của mình với quyền public
		///3. Trong from muốn gọi đến hàm này ta sẽ: khai báo from (instant) -> gọi hàm vừa định nghĩa -> show form.
		///4. Nếu không muốn show form (in trực tiếp ra máy in) thì ta không sẽ: khai báo from (instant) -> gọi hàm vừa định nghĩa.
		///- Chú ý không được xoá bất ký một hàm nào trong Class này vì các form khác đã sử dụng.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public frmPrintAll()
		{
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintAll));
            this.Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.butPdf = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butExcel = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.banin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
            this.SuspendLayout();
            // 
            // Report
            // 
            this.Report.ActiveViewIndex = -1;
            this.Report.BackColor = System.Drawing.SystemColors.Control;
            this.Report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Report.DisplayGroupTree = false;
            this.Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report.Location = new System.Drawing.Point(0, 0);
            this.Report.Name = "Report";
            this.Report.SelectionFormula = "";
            this.Report.ShowCloseButton = false;
            this.Report.ShowGroupTreeButton = false;
            this.Report.ShowRefreshButton = false;
            this.Report.Size = new System.Drawing.Size(792, 573);
            this.Report.TabIndex = 85;
            this.Report.ViewTimeSelectionFormula = "";
            // 
            // butPdf
            // 
            this.butPdf.Image = ((System.Drawing.Image)(resources.GetObject("butPdf.Image")));
            this.butPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPdf.Location = new System.Drawing.Point(660, 4);
            this.butPdf.Name = "butPdf";
            this.butPdf.Size = new System.Drawing.Size(55, 22);
            this.butPdf.TabIndex = 95;
            this.butPdf.Text = "PDF";
            this.butPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPdf.UseVisualStyleBackColor = true;
            this.butPdf.Click += new System.EventHandler(this.butPdf_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(283, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "&Số bản in :";
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(716, 4);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(73, 22);
            this.butKetthuc.TabIndex = 94;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butExcel
            // 
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(599, 4);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(60, 22);
            this.butExcel.TabIndex = 93;
            this.butExcel.Text = "Excel";
            this.butExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExcel.UseVisualStyleBackColor = true;
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(553, 4);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(45, 22);
            this.butIn.TabIndex = 92;
            this.butIn.Text = "In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.UseVisualStyleBackColor = true;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(506, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(44, 21);
            this.den.TabIndex = 91;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(429, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(45, 21);
            this.tu.TabIndex = 89;
            // 
            // banin
            // 
            this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banin.Location = new System.Drawing.Point(345, 5);
            this.banin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.banin.Name = "banin";
            this.banin.Size = new System.Drawing.Size(34, 21);
            this.banin.TabIndex = 87;
            this.banin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(476, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(377, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Từ trang :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmPrintAll
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butPdf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.banin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Report);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPrintAll";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrintAll_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPrintAll_Load(object sender, System.EventArgs e)
		{
            string dir = System.IO.Directory.GetCurrentDirectory();
            ExportPath = "";
            int j = 0;
            for (int i = 0; i < dir.Length; i++)
            {
                if (dir.Substring(i, 1) == "//") j++;
                if (j == 2) break;
                ExportPath += dir.Substring(i, 1);
            }
            ExportPath += "//pdf//";
            if (!System.IO.Directory.Exists(ExportPath)) System.IO.Directory.CreateDirectory(ExportPath);
            this.Tag = System.Environment.CurrentDirectory.ToString();
		}
		/// <param name="v_direct"></param>
		/// <param name="v_ads"></param>
		/// <param name="v_syt"></param>
		/// <param name="v_benhvien"></param>
		/// <param name="v_ngaybaocao"></param>
		/// <param name="v_nguoibaocao"></param>
		/// <param name="v_ghichu"></param>
		public void BangKQ(bool v_direct, DataSet v_ads, string v_syt, string v_benhvien,string v_diachi, string v_bsdoc, string v_truongkhoa,string v_bsyc)
		{
            /*
			string strTemp="c:\\Reportpic";
			string strTenfile="";
			try
			{
				if(!Directory.Exists(strTemp)) Directory.CreateDirectory(strTemp);
			}
			catch
			{
			}
			if(!Directory.Exists(strTemp))
			{
				MessageBox.Show("Tạo thư mục C:\\Reportpic, và phân quyền cho thư mục đó.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			byte [] image ;
			MemoryStream memo ;
			Bitmap map ;
		
			foreach(DataRow r in v_ads.Tables[0].Rows)
			{
				if(r["anh1"]!=null)
				{
					image = new byte[0];
					image = (byte[])(r["anh1"]);
					memo = new MemoryStream(image);
					map = new Bitmap(Image.FromStream(memo));
					strTenfile="C:\\Reportpic\\Image1.bmp";
					map.Save(strTenfile, System.Drawing.Imaging.ImageFormat.Bmp);
				}
				else
				{
					strTenfile="C:\\Reportpic\\Image1.bmp";
					File.Copy("none.bmp",strTenfile,true);
				}

				if(r["anh2"]!=null)
				{
					image = new byte[0];
					image = (byte[])(r["anh2"]);
					memo = new MemoryStream(image);
					map = new Bitmap(Image.FromStream(memo));
					strTenfile="C:\\Reportpic\\Image2.bmp";
					map.Save(strTenfile, System.Drawing.Imaging.ImageFormat.Bmp);
				}
				else
				{
					strTenfile="C:\\Reportpic\\Image2.bmp";
					File.Copy("none.bmp",strTenfile,true);
				}


			}
            */
			try
			{
				
				this.Text="Kết quả giải phẫu bệnh";
				aReport ="bangkq.rpt";
                ds = new DataSet();
                ds = v_ads.Copy();
				this.Text=this.Text+" - "+aReport;
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(v_ads);
				oRpt.DataDefinition.FormulaFields["msyte"].Text="'"+v_syt.ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["mbvien"].Text="'"+v_benhvien.ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["bsdoc"].Text="'"+v_bsdoc+"'";
				oRpt.DataDefinition.FormulaFields["truongkhoa"].Text="'"+v_truongkhoa+"'";
				oRpt.DataDefinition.FormulaFields["v_bsyc"].Text="'"+v_bsyc+"'";
				oRpt.DataDefinition.FormulaFields["diachi"].Text="'"+v_diachi+"'";
				oRpt.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				oRpt.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
				if(!v_direct)
				{
					this.Report.ReportSource=oRpt;
				}
				else
				{
					oRpt.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void BangKQ_Word(bool v_direct, DataSet v_ads, string v_syt, string v_benhvien,string v_diachi, string v_bsdoc, string v_truongkhoa,string v_bsyc)
		{
			string tenfile = "";
			aReport ="bangkq.rpt";
            ds = new DataSet();
            ds = v_ads.Copy();
			try
			{
				End_process("WINWORD");
				this.Text=this.Text+" - "+aReport;
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(v_ads);
				oRpt.DataDefinition.FormulaFields["msyte"].Text="'"+v_syt.ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["mbvien"].Text="'"+v_benhvien.ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["bsdoc"].Text="'"+v_bsdoc+"'";
				oRpt.DataDefinition.FormulaFields["truongkhoa"].Text="'"+v_truongkhoa+"'";
				oRpt.DataDefinition.FormulaFields["v_bsyc"].Text="'"+v_bsyc+"'";
				oRpt.DataDefinition.FormulaFields["diachi"].Text="'"+v_diachi+"'";
				oRpt.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				oRpt.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
				
				tenfile = aReport.ToLower().Replace(".rpt", "");
				tenfile = "..\\..\\..\\report\\"+ tenfile + ".doc";
				crDiskFileDestinationOptions = new DiskFileDestinationOptions();
				crExportOptions = oRpt.ExportOptions;
				crDiskFileDestinationOptions.DiskFileName = tenfile;
				crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
				crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
				crExportOptions.ExportFormatType = ExportFormatType.WordForWindows;
				oRpt.Export();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void Sttt(bool v_direct, DataSet v_ads, string v_syt, string v_benhvien,string v_diachi,int v_sldung,int v_slsai)
		{
			try
			{
				this.Text="Báo cáo sinh thiết tức thì";
                ds = new DataSet();
                ds = v_ads.Copy();
				aReport ="sttt.rpt";
				this.Text=this.Text+" - "+aReport;
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(v_ads);
				oRpt.DataDefinition.FormulaFields["msyte"].Text="'"+v_syt.ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["mbvien"].Text="'"+v_benhvien.ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["tsdung"].Text="'"+v_sldung+"'";
				oRpt.DataDefinition.FormulaFields["tssai"].Text="'"+v_slsai+"'";
				oRpt.DataDefinition.FormulaFields["diachi"].Text="'"+v_diachi+"'";
				oRpt.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				oRpt.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
				if(!v_direct)
				{
					this.Report.ReportSource=oRpt;					
				}
				else
				{
					oRpt.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void Vtst(bool v_direct, DataSet v_ads, string v_syt, string v_benhvien,string v_diachi,string v_rptname)
		{
			try
			{
				this.Text="Báo cáo vị trí sinh thiết - gpb - pxn";
				aReport =v_rptname;
                ds = new DataSet();
                ds = v_ads.Copy();
				this.Text=this.Text+" - "+aReport;
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(v_ads);
				oRpt.DataDefinition.FormulaFields["msyte"].Text="'"+v_syt.ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["mbvien"].Text="'"+v_benhvien.ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["diachi"].Text="'"+v_diachi+"'";
				oRpt.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				oRpt.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
				if(!v_direct)
				{
					this.Report.ReportSource=oRpt;
				}
				else
				{
					oRpt.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void End_process(string program)
		{

			Process[] processes = Process.GetProcesses();
			if (processes.Length > 1)
				for (int n = 0; n <= processes.Length - 1; n++)
				{
					if (((Process)processes[n]).ProcessName.ToString().ToUpper() == program)
						processes[n].Kill();
				}

		}

        private void butKetthuc_Click(object sender, System.EventArgs e)
        {
            bPrinter = false;

            if (Report != null)
            {
                oRpt.Close();
                oRpt.Dispose();
                Report.Dispose();
            }
            try
            {
                m.close(); this.Close();
            }
            catch
            {
            }
        }

        private void butIn_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bPrinter = true;
            try
            {
                oRpt.PrintToPrinter(Convert.ToInt16(banin.Value), false, Convert.ToInt16(tu.Value), Convert.ToInt16(den.Value));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor = Cursors.Default;
            if (Report != null)
            {
                oRpt.Close();
                oRpt.Dispose();
                Report.Dispose();
            }
            m.close(); this.Close();
        }

        private void frmReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: butPdf_Click(sender, e); break;
                case Keys.F9: if (butIn.Enabled) butIn_Click(sender, e); break;
                case Keys.F7: butExcel_Click(sender, e); break;
                case Keys.F10: butKetthuc_Click(sender, e); break;
            }
        }

        private void banin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butExcel_Click(object sender, System.EventArgs e)
        {
            m.check_process_Excel();
            string tenfile = m.Export_Excel(ds,aReport.Substring(0,aReport.Length - 4));
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

        private void butPdf_Click(object sender, EventArgs e)
        {
            string tenfile = aReport.ToLower().Replace(".rpt", "");
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
                    run f = new run(filerun, arg, true);
                    f.Launch();
                }
            }
            catch
            {
                MessageBox.Show("Tập tin :" + tenfile);
            }
        }
	}
}
