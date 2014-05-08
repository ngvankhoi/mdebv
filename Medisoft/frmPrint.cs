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
//using doiso;
using dichso;
using LibDuoc;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	public class frmPrint : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m_m;
		private LibVienphi.AccessData m_v;
		private LibDuoc.AccessData m_d;
		//private doiso.Doisototext m_doiso;
        private numbertotext m_doiso;

		private string m_userid="";
		private string m_tendangnhap="";

		private string m_sql="";
		private DataSet m_ds=new DataSet();

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.ComponentModel.Container components = null;
		
		public frmPrint()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m_m =  new LibMedi.AccessData();
			m_v = new LibVienphi.AccessData();
			m_d = new LibDuoc.AccessData();
			m_userid = "";
			//m_doiso = new doiso.Doisototext();
            m_doiso = new numbertotext();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v_userid">dlogin.id.ToString()</param>
		public frmPrint(string v_userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_m =  new LibMedi.AccessData();
			m_v = new LibVienphi.AccessData();
			m_d = new LibDuoc.AccessData();
			m_userid = v_userid;
			//m_doiso = new doiso.Doisototext();
            m_doiso = new numbertotext();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v_m">LibMedi.AccessData</param>
		/// <param name="v_v">LibVienphi.AccessData</param>
		/// <param name="v_d">LibDuoc.AccessData</param>
		/// <param name="v_userid">dlogin.id.ToString()</param>
		public frmPrint(LibMedi.AccessData v_m, LibVienphi.AccessData v_v, LibDuoc.AccessData v_d, string v_userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_m = v_m;
			m_v = v_v;
			m_d = v_d;
			m_userid = v_userid;
			//m_doiso = new doiso.Doisototext();
            m_doiso = new numbertotext();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrint));
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.BackColor = System.Drawing.SystemColors.Control;
			this.crystalReportViewer1.DisplayGroupTree = false;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = null;
			this.crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
			this.crystalReportViewer1.TabIndex = 85;
			// 
			// frmPrint
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.crystalReportViewer1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmPrint";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrint_KeyDown);
			this.Load += new System.EventHandler(this.frmPrint_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmPrint_Load(object sender, System.EventArgs e)
		{
			try
			{
				m_tendangnhap = m_d.get_data("select a.hoten from dlogin a where a.id=" + m_userid).Tables[0].Rows[0]["hoten"].ToString();
			}
			catch
			{
				m_tendangnhap = "Chưa đăng nhập";
			}
		}
		private string f_GetNgay(string v_ngay)
		{
			try
			{
				return "Ngày " + v_ngay.Substring(0,2) + " tháng " + v_ngay.Substring(3,2) + " năm " + v_ngay.Substring(6);
			}
			catch
			{
				return "";
			}
		}
		/// <summary>
		/// In toa thuốc thường
		/// </summary>
		/// <param name="v_dir">v_dir=true: in trực tiếp ra máy in; v_dir=false: xem trước khi in</param>
		/// <param name="v_id">d_toathuocll.id.ToString()</param>
		public void f_Print_Toathuoc(bool v_dir, string v_id)
		{
			try
			{
				this.Text="Toa thuốc";
				string aReport ="t_rptToathuoc.rpt";

				//lấy địa chỉ từ lienhe
				//m_sql = "select a.id, a.stt, a.mabd, a.soluong, a.cachdung, b.ten, b.tenhc , b.dang, to_char(c.ngay,'dd/mm/yyyy') ngay, c.makp, c.mabs, c.maicd, c.chandoan, c.ghichu, d.tenkp, e.hoten tenbs, f.hoten tennguoinhap, g.mabn, g.hoten, nvl(to_char(g.ngaysinh,'dd/mm/yyyy'),g.namsinh) ngaysinh, i.tentt tinh, j.tenquan quan, k.tenpxa xa, h.sonha, h.thon, h.cholam, l.ten gioitinh, to_char(c.sophieu) sophieu from d_toathuocct a, d_dmthuoc b, d_toathuocll c, btdkp_bv d, dmbs e, dlogin f, btdbn g, lienhe h, btdtt i, btdquan j, btdpxa k, dmphai l where a.mabd=b.id(+) and a.id = c.id and c.makp=d.makp(+) and c.mabs=e.ma and c.userid=f.id and c.mabn=g.mabn(+) and c.maql=h.maql(+) and h.matt=i.matt(+) and h.maqu=j.maqu(+) and h.maphuongxa=k.maphuongxa(+) and g.phai=l.ma(+) and to_char(a.id)='"+ v_id +"' order by a.stt";
				//lấy địa chỉ từ btdbn
				m_sql = "select a.id, a.stt, a.mabd, a.soluong, a.cachdung, b.ten, b.tenhc , b.dang, to_char(c.ngay,'dd/mm/yyyy') ngay, c.makp, c.mabs, c.maicd, c.chandoan, c.ghichu, d.tenkp, e.hoten tenbs, f.hoten tennguoinhap, g.mabn, g.hoten, nvl(to_char(g.ngaysinh,'dd/mm/yyyy'),g.namsinh) ngaysinh, i.tentt tinh, j.tenquan quan, k.tenpxa xa, h.sonha, h.thon, h.cholam, l.ten gioitinh, to_char(c.sophieu) sophieu from d_toathuocct a, d_dmthuoc b, d_toathuocll c, btdkp_bv d, dmbs e, dlogin f, btdbn g, lienhe h, btdtt i, btdquan j, btdpxa k, dmphai l where a.mabd=b.id(+) and a.id = c.id and c.makp=d.makp(+) and c.mabs=e.ma and c.userid=f.id and c.mabn=g.mabn(+) and c.maql=h.maql(+) and g.matt=i.matt(+) and g.maqu=j.maqu(+) and g.maphuongxa=k.maphuongxa(+) and g.phai=l.ma(+) and to_char(a.id)='"+ v_id +"' order by a.stt";
				m_ds = m_d.get_data(m_sql);
				m_ds.WriteXml("..//t_rptToathuoc.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				angayin ="Ngày " + System.DateTime.Now.Day.ToString().PadLeft(2,'0') + " tháng " + System.DateTime.Now.Month.ToString().PadLeft(2,'0') + " năm " + System.DateTime.Now.Year.ToString();
				anguoiin = m_tendangnhap;
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog();
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		/// <summary>
		/// In toa thuốc BHYT
		/// </summary>
		/// <param name="v_dir">v_dir=true: in trực tiếp ra máy in; v_dir=false: xem trước khi in</param>
		/// <param name="v_id">bhytkb.id.ToString()</param>
		public void f_Print_ToathuocBH(bool v_dir, string v_id)
		{
			try
			{
				this.Text="Toa thuốc BHYT";
				string aReport ="t_rptToathuoc.rpt";

				m_sql = "select a.id, a.stt, a.mabd, a.soluong, a.cachdung, b.ten, b.tenhc , b.dang, to_char(c.ngay,'dd/mm/yyyy') ngay, c.makp, c.mabs, c.maicd, c.chandoan, c.ghichu, d.tenkp, e.hoten tenbs, f.hoten tennguoinhap, g.mabn, g.hoten, nvl(to_char(g.ngaysinh,'dd/mm/yyyy'),g.namsinh) ngaysinh, i.tentt tinh, j.tenquan quan, k.tenpxa xa, h.sonha, h.thon, h.cholam, l.ten gioitinh, to_char(c.sophieu) sophieu from d_toathuocct a, d_dmthuoc b, d_toathuocll c, btdkp_bv d, dmbs e, dlogin f, btdbn g, lienhe h, btdtt i, btdquan j, btdpxa k, dmphai l where a.mabd=b.id(+) and a.id = c.id and c.makp=d.makp(+) and c.mabs=e.ma and c.userid=f.id and c.mabn=g.mabn(+) and c.maql=h.maql(+) and g.matt=i.matt(+) and g.maqu=j.maqu(+) and g.maphuongxa=k.maphuongxa(+) and g.phai=l.ma(+) and to_char(a.id)='"+ v_id +"' order by a.stt";
				m_ds = m_d.get_data(m_sql);
				//m_ds.WriteXml("..//t_rptToathuoc.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				angayin ="Ngày " + System.DateTime.Now.Day.ToString().PadLeft(2,'0') + " tháng " + System.DateTime.Now.Month.ToString().PadLeft(2,'0') + " năm " + System.DateTime.Now.Year.ToString();
				anguoiin = m_tendangnhap;
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog();
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private DataSet f_Cursor_BienlaiKB()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("BienLaiTamUng");
				ads.Tables[0].Columns.Add("syt");
				ads.Tables[0].Columns.Add("bv");
				ads.Tables[0].Columns.Add("diachibv");
				ads.Tables[0].Columns.Add("tongcucthue");
				ads.Tables[0].Columns.Add("cucthue");
				ads.Tables[0].Columns.Add("masothue");
				ads.Tables[0].Columns.Add("mauso");
				ads.Tables[0].Columns.Add("quyenso");
				ads.Tables[0].Columns.Add("sobienlai");
				ads.Tables[0].Columns.Add("ngayin");
				ads.Tables[0].Columns.Add("nguoiin");
				ads.Tables[0].Columns.Add("ghichu");
				ads.Tables[0].Columns.Add("sovaovien");
				ads.Tables[0].Columns.Add("lien");
				ads.Tables[0].Columns.Add("mabn");
				ads.Tables[0].Columns.Add("hoten");
				ads.Tables[0].Columns.Add("ngaysinh");
				ads.Tables[0].Columns.Add("gioitinh");
				ads.Tables[0].Columns.Add("khoa");
				ads.Tables[0].Columns.Add("diachi");
				ads.Tables[0].Columns.Add("lydo");
				ads.Tables[0].Columns.Add("sotien");
				ads.Tables[0].Columns.Add("chutien");
				ads.Tables[0].Columns.Add("nguoithu");
				ads.Tables[0].Columns.Add("diengiai");
				return ads;
			}
			catch
			{
				return null;
			}
		}
		public void f_Print_BienlaiKB(bool v_dir, string v_id, int v_nlien)
		{
			try
			{
				this.Text="In biên lai thu viện phí khám bệnh";
				string aReport ="t_bienlaithuvienphi.rpt";
				//m_sql = "select  a.id, aa.sovaovien, a.sobienlai, b.soluong, b.dongia, b.mien, b.thieu, d.mabn, a.hoten, decode(d.ngaysinh,null,nvl(d.namsinh,a.namsinh),to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, c.ten tenvp, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_vienphill a, tiepdon aa, v_vienphict b, (select id, ten from v_giavp union select id, trim(ten||' '|| hamluong) ten from d_dmbd) c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, v_dlogin j where a.id=b.id(+) and a.maql=aa.maql(+) and a.mabn=d.mabn(+) and b.mavp=c.id(+) and d.phai=e.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id(+) and a.userid=j.id(+) and to_char(a.id)='"+v_id+"' order by b.stt";
				m_sql = "select  a.id, aa.sovaovien, a.sobienlai, nvl(b.soluong,0) soluong, nvl(b.dongia,0) dongia, nvl(b.mien,0) mien, nvl(aaa.sotien,0) tongmien, nvl(b.thieu,0) thieu, b.madoituong, d.mabn, a.hoten, decode(d.ngaysinh,null,nvl(d.namsinh,a.namsinh),to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, c.ten tenvp, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_vienphill a, tiepdon aa, v_mienngtru aaa, v_vienphict b,(select id, ten from v_giavp union select id, trim(ten||' '|| hamluong) ten from d_dmbd) c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, v_dlogin j where a.id=b.id(+) and a.maql=aa.maql(+) and a.id=aaa.id(+) and a.mabn=d.mabn(+) and b.mavp=c.id(+) and d.phai=e.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id(+) and a.userid=j.id(+) and to_char(a.id)='"+v_id+"' order by b.stt";
				m_ds = m_d.get_data(m_sql);

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..//t_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="", alydobh="",asotien="", achutien="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", adiengiai="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				adiachibv = m_v.Diachi;
				atongcuc = "<TỔNG CỤC THUẾ>";
				acucthue = "<CỤC THUẾ>";
				amasothue=m_v.Masothue;
				amauso=m_v.Mausobienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				angayin="Ngày " + System.DateTime.Now.Day.ToString().PadLeft(2,'0') + " tháng " + System.DateTime.Now.Month.ToString().PadLeft(2,'0') + " năm " + System.DateTime.Now.Year.ToString();
				anguoiin=m_tendangnhap;
				aghichu = "";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa="Khám bệnh";//m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["sonha"].ToString().Trim() + " "+ m_ds.Tables[0].Rows[0]["thon"].ToString().Trim();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenpxa"].ToString();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				if(adiachi.Trim()=="")
				{
					adiachi=m_ds.Tables[0].Rows[0]["diachi"].ToString().Trim();
				}
				alydo="";
				asotien="";
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				decimal athucthu=0, atongtien=0, atongmien=0, atongmien1=0, atongthieu=0, atongbhyt=0, asoluong=0, adongia=0, amien=0, athieu=0, abhyt=0;

				try
				{
					atongmien1 = decimal.Parse(m_ds.Tables[0].Rows[0]["tongmien"].ToString());
				}
				catch
				{
					atongmien1=0;
				}
				
				for(int i=0;i<m_ds.Tables[0].Rows.Count;i++)
				{
					try
					{
						asoluong = decimal.Parse(m_ds.Tables[0].Rows[i]["soluong"].ToString());
					}
					catch
					{
						asoluong=0;
					}

					try
					{
						adongia = decimal.Parse(m_ds.Tables[0].Rows[i]["dongia"].ToString());
					}
					catch
					{
						adongia=0;
					}

					try
					{
						amien = decimal.Parse(m_ds.Tables[0].Rows[i]["mien"].ToString());
					}
					catch
					{
						amien=0;
					}
					
					try
					{
						athieu = decimal.Parse(m_ds.Tables[0].Rows[i]["thieu"].ToString());
					}
					catch
					{
						athieu=0;
					}
					abhyt=0;
					if(m_ds.Tables[0].Rows[i]["madoituong"].ToString()=="1")
					{
						abhyt=amien;
						amien=0;
						alydobh=alydobh.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydobh=alydobh + " (" + asoluong.ToString()+")";
						}
					}
					else
					{
						alydo=alydo.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydo=alydo + " (" + asoluong.ToString()+")";
						}
					}
					atongtien = atongtien + asoluong * adongia;
					atongmien = atongmien + amien;
					atongthieu = atongthieu + athieu;
					atongbhyt = atongbhyt + abhyt;
				}

				if(atongmien==0)
				{
					atongmien=atongmien1;
				}

				//MessageBox.Show(atongtien.ToString()+"-"+ atongmien.ToString()+"-"+atongmien1.ToString()+"-"+atongthieu.ToString());
				
				athucthu = atongtien - atongmien - atongbhyt - atongthieu;

				try
				{
					athucthu = decimal.Parse(decimal.Parse(athucthu.ToString()).ToString());
				}
				catch//(Exception exx)
				{
					//MessageBox.Show(exx.ToString());
				}
				asotien = athucthu.ToString("###,###,##0.##") + "đồng";
				achutien = m_doiso.doiraso(athucthu.ToString());
				if(achutien=="")
				{
					achutien="Không đồng";
				}

				alydo=alydo.Trim().Trim(',');
				alydobh=alydobh.Trim().Trim(',');
				if(alydobh!="")
				{
					alydo=alydo+ ", BHYT(" + alydobh + ")";
				}
				alydo=alydo.Trim().Trim(',');
				alydo=alydo.Trim();

				if((atongmien1>0)||(atongthieu>0)||(atongbhyt>0))
				{
					adiengiai="Ghi chú: - Tổng chi phí: " + atongtien.ToString("###,###,###.##")+"đ";
					if(atongbhyt>0)
					{
						adiengiai=adiengiai+" - BHYT trả: " + atongbhyt.ToString("###,###,###.##")+"đ";
					}
					if(atongmien>0)
					{
						adiengiai=adiengiai+" - Miễn: " + atongmien.ToString("###,###,###.##")+"đ";
					}
					if(atongthieu>0)
					{
						adiengiai=adiengiai+" - Bệnh nhân nợ: " + atongthieu.ToString("###,###,###.##")+"đ";
					}
				}
				DataSet ads = f_Cursor_BienlaiKB();
				string []nlien=new string[] {"Liên 2: Giao cho bệnh nhân","Liên 1: Báo soát","Liên 3: Giao cho phòng tài chánh kế toán"};
				for(int i=0;i<v_nlien &&i<nlien.Length;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=nlien[i];
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["nguoithu"]=anguoithu;
					r["diengiai"]=adiengiai;
					ads.Tables[0].Rows.Add(r);
				}
				
				//ads.WriteXml("..//..//DataReport//t_bienlaithuvienphi.xml",XmlWriteMode.WriteSchema);
				//return;
				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
				m_v.execute_data("update v_vienphill set lanin=nvl(lanin,0)+1 where to_char(id)='"+v_id+"'");
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiKB(bool v_dir, string v_id)
		{
			try
			{
				this.Text="Bảng kê chi phí điều trị ngoại trú";
				string aReport ="t_thanhtoantructiep.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . . . . .') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . . . . .') giatriden, e.tenkp, to_char(a.ngay,'dd/mm/yyyy') ngay, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(b.soluong,0) soluong, nvl(b.dongia,0) dongia, (nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, decode(b.madoituong,1,nvl(b.mien,0),0) bhtra, nvl(b.mien,0) mien, nvl(b.thieu,0) thieu, nvl(c.sotien,0) tongmien, b.madoituong, m.hoten nguoithu from v_vienphill a, v_vienphict b, v_mienngtru c, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '|| hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, v_dlogin m, dmphai n where a.id=b.id and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.makp=e.makp(+) and a.userid=m.id(+) and b.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and a.maql=l.maql(+) and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				//MessageBox.Show(m_sql+m_ds.Tables[0].Rows.Count.ToString());
				//m_ds.WriteXml("..//..//Datareport//t_thanhtoantructiep.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiKBCT(bool v_dir, string v_id)
		{
			try
			{
				this.Text="Bảng kê chi phí điều trị ngoại trú";
				string aReport ="t_thanhtoantructiep_chitiet.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . . . . .') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . . . . .') giatriden, e.tenkp, to_char(a.ngay,'dd/mm/yyyy') ngay, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(b.soluong,0) soluong, nvl(b.dongia,0) dongia, (nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, decode(b.madoituong,1,nvl(b.mien,0),0) bhtra, nvl(b.mien,0) mien, nvl(b.thieu,0) thieu, nvl(c.sotien,0) tongmien, b.madoituong, m.hoten nguoithu from v_vienphill a, v_vienphict b, v_mienngtru c, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '|| hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, v_dlogin m, dmphai n where a.id=b.id and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.makp=e.makp(+) and a.userid=m.id(+) and b.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and a.maql=l.maql(+) and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				//MessageBox.Show(m_sql+m_ds.Tables[0].Rows.Count.ToString());
				//m_ds.WriteXml("..//..//Datareport//t_thanhtoantructiep.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private DataSet f_Cursor_BienlaiTU()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("BienLaiTamUng");
				ads.Tables[0].Columns.Add("syt");
				ads.Tables[0].Columns.Add("bv");
				ads.Tables[0].Columns.Add("diachibv");
				ads.Tables[0].Columns.Add("tongcucthue");
				ads.Tables[0].Columns.Add("cucthue");
				ads.Tables[0].Columns.Add("masothue");
				ads.Tables[0].Columns.Add("mauso");
				ads.Tables[0].Columns.Add("quyenso");
				ads.Tables[0].Columns.Add("sobienlai");
				ads.Tables[0].Columns.Add("ngayin");
				ads.Tables[0].Columns.Add("nguoiin");
				ads.Tables[0].Columns.Add("ghichu");
				ads.Tables[0].Columns.Add("lien");
				ads.Tables[0].Columns.Add("mabn");
				ads.Tables[0].Columns.Add("hoten");
				ads.Tables[0].Columns.Add("ngaysinh");
				ads.Tables[0].Columns.Add("gioitinh");
				ads.Tables[0].Columns.Add("khoa");
				ads.Tables[0].Columns.Add("diachi");
				ads.Tables[0].Columns.Add("lydo");
				ads.Tables[0].Columns.Add("sotien");
				ads.Tables[0].Columns.Add("chutien");
				ads.Tables[0].Columns.Add("nguoithu");
				return ads;
			}
			catch
			{
				return null;
			}
		}
		public void f_Print_BienlaiTU(bool v_dir, string v_id, int v_nlien)
		{
			try
			{
				this.Text="In biên lai thu tạm ứng";
				string aReport ="t_bienlaitamung.rpt";

				m_sql = "select  a.id, a.mabn, a.sobienlai, nvl(a.sotien,0) sotien , to_char(a.ngay,'dd/mm/yyyy') ngay, b.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_tamung a, btdkp_bv b, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, v_dlogin j where a.makp=b.makp(+) and a.mabn=d.mabn(+) and d.phai=e.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id(+) and a.userid=j.id(+) and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu tạm ứng <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..//t_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo="Thu tiền tạm ứng";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.Masothue;
				amauso=m_v.Mausobienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue="<CỤC THUẾ>";
				atongcuc="<TỔNG CỤC THUẾ>";
				adiachibv=m_v.Diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,###") + "đồng";
				achutien = m_doiso.doiraso(asotien.Replace(",",""));

				DataSet ads = f_Cursor_BienlaiTU();
				string []nlien=new string[] {"Liên 1: Giao cho bệnh nhân","Liên 2: Lưu phòng tài chánh kế toán","Liên 3: Giao cho khoa"};
				for(int i=0;i<v_nlien &&i<nlien.Length;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=nlien[i];
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("t_bienlaitamung.xml",XmlWriteMode.WriteSchema);
				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private DataSet f_Cursor_BienlaiNT()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("BienLaiTamUng");
				ads.Tables[0].Columns.Add("syt");
				ads.Tables[0].Columns.Add("bv");
				ads.Tables[0].Columns.Add("diachibv");
				ads.Tables[0].Columns.Add("tongcucthue");
				ads.Tables[0].Columns.Add("cucthue");
				ads.Tables[0].Columns.Add("masothue");
				ads.Tables[0].Columns.Add("mauso");
				ads.Tables[0].Columns.Add("quyenso");
				ads.Tables[0].Columns.Add("sobienlai");
				ads.Tables[0].Columns.Add("ngayin");
				ads.Tables[0].Columns.Add("nguoiin");
				ads.Tables[0].Columns.Add("ghichu");
				ads.Tables[0].Columns.Add("lien");
				ads.Tables[0].Columns.Add("mabn");
				ads.Tables[0].Columns.Add("hoten");
				ads.Tables[0].Columns.Add("ngaysinh");
				ads.Tables[0].Columns.Add("gioitinh");
				ads.Tables[0].Columns.Add("khoa");
				ads.Tables[0].Columns.Add("diachi");
				ads.Tables[0].Columns.Add("lydo");
				ads.Tables[0].Columns.Add("sotien");
				ads.Tables[0].Columns.Add("chutien");
				ads.Tables[0].Columns.Add("tongcp");
				ads.Tables[0].Columns.Add("tamung");
				ads.Tables[0].Columns.Add("bhyt");
				ads.Tables[0].Columns.Add("mien");
				ads.Tables[0].Columns.Add("lydomien");
				ads.Tables[0].Columns.Add("nguoithu");
				return ads;
			}
			catch
			{
				return null;
			}
		}
		public void f_Print_PhieuChi(bool v_dir, string v_id, int v_nlien)
		{
			try
			{
				this.Text="Phiếu chi tiền viện phí";
				string aReport ="t_phieuchi.rpt";

				m_sql = "select a.id, a.mabn, a.sobienlai, a.ghichu, nvl(a.sotien,0) sotien, to_char(a.ngay,'dd/mm/yyyy') ngay, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_hoantra a, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, v_dlogin j where a.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy hoá đơn hoàn trả <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..//t_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="", alydomien="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa="";
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=m_ds.Tables[0].Rows[0]["ghichu"].ToString();
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				amien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				alydomien="";//m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.Masothue;
				amauso=m_v.Mausobienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue="<CỤC THUẾ>";
				atongcuc="<TỔNG CỤC THUẾ>";
				adiachibv=m_v.Diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				
				try
				{
					atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,###.##").PadRight(20,'.');
					atongcp=atongcp.Substring(0,atongcp.IndexOf("."));
				}
				catch
				{
					atongcp="0";
				}
				if(atongcp=="") atongcp="0";
				achutien = m_doiso.doiraso(atongcp.Replace(",",""));
				atongcp = atongcp+"đồng";

				try
				{
					atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###.##").PadRight(20,'.');
					atamung=atamung.Substring(0,atamung.IndexOf("."));
				}
				catch
				{
					atamung="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atamung=="") atamung="0";
				achutientu = m_doiso.doiraso(atamung.Replace(",",""));

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,###").Length>0?decimal.Parse(asotien.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###").Length>0?decimal.Parse(atamung.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,###").Length>0?decimal.Parse(abhyt.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				amien = decimal.Parse(amien.ToString()).ToString("###,###,###").Length>0?decimal.Parse(amien.ToString()).ToString("###,###,###")+"đồng": "0đồng";

				DataSet ads = f_Cursor_BienlaiNT();
				string []nlien=new string[] {"Liên 2: Giao cho bệnh nhân","Liên 1: Báo soát","Liên 3: Giao cho phòng tài chánh kế toán"};
				for(int i=0;i<v_nlien &&i<nlien.Length;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=nlien[i];
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..//..//datareport//t_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				aReport ="t_phieuchi.rpt";
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiNT(bool v_dir, string v_id, int v_nlien)
		{
			try
			{
				this.Text="In biên lai thu viện phí nội trú";
				string aReport ="t_bienlaithuvienphint.rpt";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt , to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, v_dlogin j where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and a.loaibn="+m_v.iNoitru.ToString()+" and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..//t_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="", alydomien="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo="Thanh toán ra viện bệnh nhân nội trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				alydomien="";//m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.Masothue;
				amauso=m_v.Mausobienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue="<CỤC THUẾ>";
				atongcuc="<TỔNG CỤC THUẾ>";
				adiachibv=m_v.Diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				
				try
				{
					asotien = decimal.Parse(asotien.ToString()).ToString("###,###,###.##").PadRight(20,'.');
					asotien=asotien.Substring(0,asotien.IndexOf("."));
				}
				catch
				{
					asotien="0";
				}

				if(asotien=="") asotien="0";
				
				achutien = m_doiso.doiraso(asotien.Replace(",",""));
				if(achutien=="")
				{
					achutien="Không đồng";
				}
				
				try
				{
					atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###.##").PadRight(20,'.');
					atamung=atamung.Substring(0,atamung.IndexOf("."));
				}
				catch
				{
					atamung="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atamung=="") atamung="0";
				achutientu = m_doiso.doiraso(atamung.Replace(",",""));
				if(achutientu=="")
				{
					achutientu="Không đồng";
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,###").Length>0?decimal.Parse(asotien.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,###").Length>0?decimal.Parse(atongcp.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###").Length>0?decimal.Parse(atamung.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,###").Length>0?decimal.Parse(abhyt.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				amien = decimal.Parse(amien.ToString()).ToString("###,###,###").Length>0?decimal.Parse(amien.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				
				string atmp="";
				atmp="- Tổng chi phí: " + atongcp;
				if(atamung!="0đồng")
				{
					atmp = atmp+ "\n- Tạm ứng: " + atamung;
				}
				if(abhyt!="0đồng")
				{
					atmp = atmp+ "\n- BHYT trả: " + abhyt;
				}
				if(amien!="0đồng")
				{
					atmp = atmp+ "\n- Miễn: " + amien;
				}
				if(alydomien!="")
				{
					atmp = atmp+ "- Lý do miễn: " + alydomien;
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				string []nlien=new string[] {"Liên 2: Giao cho bệnh nhân","Liên 1: Báo soát","Liên 3: Giao cho phòng tài chánh kế toán"};
				for(int i=0;i<v_nlien &&i<nlien.Length;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=nlien[i];
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..//..//datareport//t_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
				if(atamung!="0đồng")
				{
					foreach(DataRow r in ads.Tables[0].Rows)
					{
						r["chutien"]=achutientu;
						r["lydo"]="Hoàn trả tiền tạm ứng";
					}
					aReport ="t_phieuchi.rpt";
					cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
					cMain.SetDataSource(ads);
					//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
					//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain;
						this.WindowState=FormWindowState.Maximized;
						this.ShowDialog(this.Parent);
					}
					else
					{
						cMain.PrintToPrinter(1,false,0,0);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiTTRVNoitru(bool v_dir, string v_id)
		{
			try
			{
				this.Text="Phiếu thanh toán ra viện bệnh nhân nội trú";
				string aReport ="t_thanhtoanravien.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, e.tenkp, a.maicd, a.chandoan, to_char(b.ngay,'dd/mm/yyyy') ngay, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, nvl(ngayra-ngayvao,1) songay, a.giuong, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(c.soluong,0) soluong, nvl(c.dongia,0) dongia, (nvl(c.soluong,0)*nvl(c.dongia,0)) sotien, nvl(b.sotien,0) tongcp, nvl(b.bhyt,0) bhyt , nvl(b.tamung,0) tamung, nvl(b.mien,0) mien, (nvl(b.sotien,0)-nvl(b.bhyt,0)-nvl(b.mien,0)-nvl(b.tamung,0)) bntra , c.madoituong, m.hoten nguoithu from v_ttrvds a, v_ttrvll b, v_ttrvct c, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '||hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, v_dlogin m, dmphai n where a.id=b.id(+) and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and b.makp=e.makp(+) and b.userid=m.id(+) and c.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and a.maql=l.maql(+) and b.loaibn="+m_v.iNoitru.ToString()+" and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				//MessageBox.Show(m_sql);
				m_ds.WriteXml("..//..//Datareport//t_thanhtoanravien.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiTTRVNoitruCT(bool v_dir, string v_id)
		{
			try
			{
				this.Text="Phiếu thanh toán ra viện bệnh nhân nội trú";
				string aReport ="t_thanhtoanravien_chitiet.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, e.tenkp, a.maicd, a.chandoan,  to_char(b.ngay,'dd/mm/yyyy') ngay, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, nvl(ngayra-ngayvao,1) songay, a.giuong, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(c.soluong,0) soluong, nvl(c.dongia,0) dongia, (nvl(c.soluong,0)*nvl(c.dongia,0)) sotien, nvl(b.sotien,0) tongcp, nvl(b.bhyt,0) bhyt , nvl(b.tamung,0) tamung, nvl(b.mien,0) mien, (nvl(b.sotien,0)-nvl(b.bhyt,0)-nvl(b.mien,0)-nvl(b.tamung,0)) bntra , c.madoituong, m.hoten nguoithu from v_ttrvds a, v_ttrvll b, v_ttrvct c, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '||hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, v_dlogin m, dmphai n where a.id=b.id(+) and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and b.makp=e.makp(+) and b.userid=m.id(+) and c.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and a.maql=l.maql(+) and b.loaibn="+m_v.iNoitru.ToString()+" and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				//MessageBox.Show(m_sql+m_ds.Tables[0].Rows.Count.ToString());
				m_ds.WriteXml("..//..//Datareport//t_thanhtoanravien.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiNgoaitru(bool v_dir, string v_id, int v_nlien)
		{
			try
			{
				this.Text="In biên lai thu viện phí ngoại trú";
				string aReport ="t_bienlaithuvienphingoaitru.rpt";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt , to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, v_dlogin j where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and a.loaibn="+m_v.iNgoaitru.ToString()+" and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..//t_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="", alydomien="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace("Không xác định","").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo="Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				alydomien="";//m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.Masothue;
				amauso=m_v.Mausobienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue="<CỤC THUẾ>";
				atongcuc="<TỔNG CỤC THUẾ>";
				adiachibv=m_v.Diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				
				try
				{
					asotien = decimal.Parse(asotien.ToString()).ToString("###,###,###.##").PadRight(20,'.');
					asotien=asotien.Substring(0,asotien.IndexOf("."));
				}
				catch
				{
					asotien="0";
				}

				if(asotien=="") asotien="0";
				
				achutien = m_doiso.doiraso(asotien.Replace(",",""));
				if(achutien=="")
				{
					achutien="Không đồng";
				}
				
				try
				{
					atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###.##").PadRight(20,'.');
					atamung=atamung.Substring(0,atamung.IndexOf("."));
				}
				catch
				{
					atamung="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atamung=="") atamung="0";
				achutientu = m_doiso.doiraso(atamung.Replace(",",""));
				if(achutientu=="")
				{
					achutientu="Không đồng";
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,###").Length>0?decimal.Parse(asotien.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,###").Length>0?decimal.Parse(atongcp.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###").Length>0?decimal.Parse(atamung.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,###").Length>0?decimal.Parse(abhyt.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				amien = decimal.Parse(amien.ToString()).ToString("###,###,###").Length>0?decimal.Parse(amien.ToString()).ToString("###,###,###")+"đồng": "0đồng";
				
				string atmp="";
				atmp="- Tổng chi phí: " + atongcp;
				if(atamung!="0đồng")
				{
					atmp = atmp+ "\n- Tạm ứng: " + atamung;
				}
				if(abhyt!="0đồng")
				{
					atmp = atmp+ "\n- BHYT trả: " + abhyt;
				}
				if(amien!="0đồng")
				{
					atmp = atmp+ "\n- Miễn: " + amien;
				}
				if(alydomien!="")
				{
					atmp = atmp+ "- Lý do miễn: " + alydomien;
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				string []nlien=new string[] {"Liên 2: Giao cho bệnh nhân","Liên 1: Báo soát","Liên 3: Giao cho phòng tài chánh kế toán"};
				for(int i=0;i<v_nlien &&i<nlien.Length;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=nlien[i];
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..//..//datareport//t_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
				if(atamung!="0đồng")
				{
					foreach(DataRow r in ads.Tables[0].Rows)
					{
						r["chutien"]=achutientu;
						r["lydo"]="Hoàn trả tiền tạm ứng";
					}
					aReport ="t_phieuchi.rpt";
					cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
					cMain.SetDataSource(ads);
					cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
					cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain;
						this.WindowState=FormWindowState.Maximized;
						this.ShowDialog(this.Parent);
					}
					else
					{
						cMain.PrintToPrinter(1,false,0,0);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiTTRVNgoaitru(bool v_dir, string v_id)
		{
			try
			{
				this.Text="Phiếu thanh toán ra viện bệnh nhân ngoại trú";
				string aReport ="t_thanhtoanravienngoaitru.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, e.tenkp, a.maicd, a.chandoan,  to_char(b.ngay,'dd/mm/yyyy') ngay, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, nvl(ngayra-ngayvao,1) songay, a.giuong, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(c.soluong,0) soluong, nvl(c.dongia,0) dongia, (nvl(c.soluong,0)*nvl(c.dongia,0)) sotien, nvl(b.sotien,0) tongcp, nvl(b.bhyt,0) bhyt , nvl(b.tamung,0) tamung, nvl(b.mien,0) mien, (nvl(b.sotien,0)-nvl(b.bhyt,0)-nvl(b.mien,0)-nvl(b.tamung,0)) bntra , c.madoituong, m.hoten nguoithu from v_ttrvds a, v_ttrvll b, v_ttrvct c, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '||hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, v_dlogin m, dmphai n where a.id=b.id(+) and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and b.makp=e.makp(+) and b.userid=m.id(+) and c.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and a.maql=l.maql(+) and b.loaibn="+m_v.iNgoaitru.ToString()+" and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				//MessageBox.Show(m_sql);
				m_ds.WriteXml("..//..//Datareport//t_thanhtoanravienngoaitru.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiTTRVNgoaitruCT(bool v_dir, string v_id)
		{
			try
			{
				this.Text="Phiếu thanh toán ra viện bệnh nhân ngoại trú";
				string aReport ="t_thanhtoanravienngoaitru_chitiet.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, e.tenkp, a.maicd, a.chandoan,  to_char(b.ngay,'dd/mm/yyyy') ngay, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, nvl(ngayra-ngayvao,1) songay, a.giuong, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(c.soluong,0) soluong, nvl(c.dongia,0) dongia, (nvl(c.soluong,0)*nvl(c.dongia,0)) sotien, nvl(b.sotien,0) tongcp, nvl(b.bhyt,0) bhyt , nvl(b.tamung,0) tamung, nvl(b.mien,0) mien, (nvl(b.sotien,0)-nvl(b.bhyt,0)-nvl(b.mien,0)-nvl(b.tamung,0)) bntra , c.madoituong, m.hoten nguoithu from v_ttrvds a, v_ttrvll b, v_ttrvct c, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '||hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, v_dlogin m, dmphai n where a.id=b.id(+) and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and b.makp=e.makp(+) and b.userid=m.id(+) and c.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and a.maql=l.maql(+) and b.loaibn="+m_v.iNgoaitru.ToString()+" and to_char(a.id)='"+v_id+"'";
				m_ds = m_d.get_data(m_sql);
				//MessageBox.Show(m_sql);
				m_ds.WriteXml("..//..//Datareport//t_thanhtoanravienngoaitru.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện ngoại trú <")+v_id+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_NhapVienPhiKhoa(bool v_dir, string v_maql, string v_makp)
		{
			try
			{
				this.Text="Bảng kê nhập viện phí khoa";
				string aReport ="t_nhapvienphikhoa.rpt";

				string exp = "to_char(a.maql)='" + v_maql+"'";
				if(v_makp!="")
				{
					exp=exp + " and makp='" + v_makp + "'";
				}

				m_sql = "select a.id, to_char(b.ngay,'dd/mm/yyyy')||' '||to_char(b.ngayud,'hh24:mi') ngayvv, a.mabn, d.hoten, d.namsinh, n.ten gioitinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, nvl(l.sothe,'. . . . . . . . . . . . . . . . . .') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . . . . .') giatriden, e.tenkp, to_char(a.ngay,'dd/mm/yyyy') ngay, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(a.soluong,0) soluong, nvl(a.dongia,0) dongia, (nvl(a.soluong,0)*nvl(a.dongia,0)) sotien, decode(a.madoituong,1,nvl(a.soluong,0)*nvl(a.dongia,0),0) bhtra, decode(a.madoituong,1,0,nvl(a.soluong,0)*nvl(a.dongia,0)) bntra, a.madoituong, m.hoten nguoithu from v_vpkhoa a, benhandt b, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '|| hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, v_dlogin m, dmphai n where a.mabn=d.mabn(+) and a.maql=b.maql(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.makp=e.makp(+) and a.userid=m.id(+) and a.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and d.phai=n.ma(+) and a.maql=l.maql(+) and "+ exp;
				m_ds = m_d.get_data(m_sql);
				//MessageBox.Show(m_sql+m_ds.Tables[0].Rows.Count.ToString());
				//m_ds.WriteXml("..//..//Datareport//t_nhapvienphikhoa.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy thông tin nhập viện phí khoa <")+v_maql+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_NhapVienPhiKhoaCT(bool v_dir, string v_maql, string v_makp)
		{
			try
			{
				this.Text="Bảng kê nhập viện phí khoa";
				string aReport ="t_nhapvienphikhoa_chitiet.rpt";
				string exp = "to_char(a.maql)='" + v_maql+"'";
				if(v_makp!="")
				{
					exp=exp + " and makp='" + v_makp + "'";
				}

				m_sql = "select a.id, to_char(b.ngay,'dd/mm/yyyy')||' '||to_char(b.ngayud,'hh24:mi') ngayvv, a.mabn, d.hoten, d.namsinh, n.ten gioitinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, nvl(l.sothe,'. . . . . . . . . . . . . . . . . .') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . . . . .') giatriden, e.tenkp, to_char(a.ngay,'dd/mm/yyyy') ngay, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(a.soluong,0) soluong, nvl(a.dongia,0) dongia, (nvl(a.soluong,0)*nvl(a.dongia,0)) sotien, decode(a.madoituong,1,nvl(a.soluong,0)*nvl(a.dongia,0),0) bhtra, decode(a.madoituong,1,0,nvl(a.soluong,0)*nvl(a.dongia,0)) bntra, a.madoituong, m.hoten nguoithu from v_vpkhoa a, benhandt b, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '|| hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, v_dlogin m, dmphai n where a.mabn=d.mabn(+) and a.maql=b.maql(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.makp=e.makp(+) and a.userid=m.id(+) and a.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and d.phai=n.ma(+) and a.maql=l.maql(+) and "+ exp;
				m_ds = m_d.get_data(m_sql);
				//MessageBox.Show(m_sql+m_ds.Tables[0].Rows.Count.ToString());
				//m_ds.WriteXml("..//..//Datareport//t_nhapvienphikhoa.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy thông tin nhập viện phí khoa <")+v_maql+">",lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_d.Syte;
				abv = m_d.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..//..//..//report//"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void frmPrint_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Escape)
				{
					this.Close();
				}
			}
			catch
			{
			}
		}
	}
}
