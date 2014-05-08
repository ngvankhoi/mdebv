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
using LibVP;

namespace Vienphi2007
{
    public partial class frmPrintHD : Form
    {
        private Language lan = new Language();
        
        private ReportDocument cMain;
        public bool bPrinter, bInchuky = false;

        private FileStream fstr;
        private byte[] image;

        private string m_userid = "";
        private LibVP.AccessData m_v;

        private ExportOptions crExportOptions;
        private DiskFileDestinationOptions crDiskFileDestinationOptions;
        private string ExportPath="", ReportFile="";

        private DataSet m_dslien = null;
        private string m_report_thutructiep = "v_bienlaithuvienphitt.rpt";
        private string m_report_thutructiep_thuong = "v_bienlaithuvienphi_thuong.rpt";
        private string m_report_thutructiep_gtgt = "v_bienlaithuvienphi_gtgt.rpt";
        private string m_report_thutamung = "v_bienlaitamung.rpt";
        private string m_report_ravien = "v_bienlaithuvienphint.rpt";
        private string m_report_ravien_thuong = "v_bienlaithuvienphint_thuong.rpt";
        private string m_report_ravien_chi = "v_bienlaithuvienphint_chi.rpt";
        //Them thong so in thanh toan ra vien chi tiet.
        private string m_report_ravien_ct = "0";
        private string m_report_ravien_thuong_ct = "0";
        private string m_report_ravien_chi_ct = "0";
        private bool thutheongay = false;
        //End.
        private string m_report_phieuchi = "v_phieuchi.rpt";
        private string m_report_thutrongoi = "v_bienlaithuvienphitrongoi.rpt";
        private string m_report_bhyt = "v_bienlaithuvienphibhyt.rpt";
        private string m_report_bhyt_hdtc = "v_bienlaithuvienphibhyt_hdtc.rpt";

        public frmPrintHD(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();

                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);

                m_v = v_v;
                m_userid = v_userid;                
                m_dslien = m_v.f_get_solien();
                if (m_dslien == null)
                {
                    m_v.f_create_v_optionlien();
                    m_v.f_Macdinh_Solien();
                    m_dslien = m_v.f_get_solien();
                }
                m_report_thutructiep = m_v.sys_report_thutructiep;
                m_report_thutamung = m_v.sys_report_thutamung;
                m_report_ravien = m_v.sys_report_ravien;
                m_report_ravien_thuong = m_v.sys_report_ravien_thuong;
                m_report_ravien_chi = m_v.sys_report_ravien_chi;
                //Them thong so in chi tiet trong bien lai thanh toan ra vien.
                m_report_ravien_ct = m_v.sys_report_ravien_ct;
                m_report_ravien_thuong_ct = m_v.sys_report_ravien_thuong_ct;
                m_report_ravien_chi_ct = m_v.sys_report_ravien_chi_ct;
                thutheongay = m_v.bhyt_thutheongay(v_userid);
                //End.
                m_report_phieuchi = m_v.sys_report_phieuchi;
                m_report_thutrongoi = m_v.sys_report_thutrongoi;
                m_report_bhyt = m_v.sys_report_bhyt;
                bInchuky = m_v.sys_Chuky;
            }
            catch
            {
            }
        }
        private void frmPrintHD_Load(object sender, EventArgs e)
        {
            this.crystalReportViewer1.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            
            string dir = System.IO.Directory.GetCurrentDirectory();
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
            if (!System.IO.Directory.Exists("..//..//Datareport//"))
            {
                System.IO.Directory.CreateDirectory("..//..//Datareport//");
            }
            if (!System.IO.Directory.Exists("..\\..\\..\\report\\"))
            {
                System.IO.Directory.CreateDirectory("..\\..\\..\\report\\");
            }
            
            butIn.Focus();
            //this.reportViewer1.RefreshReport();
            this.crystalReportViewer1.RefreshReport();
            //crystalReportViewer1
        }

        private string f_GetNgay(string v_ngay)
        {
            try
            {
                return lan.Change_language_MessageText("Ngày")+" " + v_ngay.Substring(0, 2) + " "+lan.Change_language_MessageText("tháng")+" " + v_ngay.Substring(3, 2) + " "+lan.Change_language_MessageText("năm")+" " + v_ngay.Substring(6);
            }
            catch
            {
                return "";
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
                ads.Tables[0].Columns.Add("sohieuquyenso");
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
                ads.Tables[0].Columns.Add("loaivp");
                ads.Tables[0].Columns.Add("sotien");
                ads.Tables[0].Columns.Add("chutien");
                ads.Tables[0].Columns.Add("nguoithu");
                ads.Tables[0].Columns.Add("diengiai");
                ads.Tables[0].Columns.Add("bacsithuchien");
                ads.Tables[0].Columns.Add("bacsilamsang");
                ads.Tables[0].Columns.Add("sttkham");
                ads.Tables[0].Columns.Add("id", typeof(decimal));
                //
                ads.Tables.Add("Chitiet");
                ads.Tables[1].Columns.Add("madoituong", typeof(int));
                ads.Tables[1].Columns.Add("mavp", typeof(int));
                ads.Tables[1].Columns.Add("tenvp");
                ads.Tables[1].Columns.Add("id_loaivp", typeof(int));
                ads.Tables[1].Columns.Add("loaivp");
                ads.Tables[1].Columns.Add("id_nhomvp", typeof(int));
                ads.Tables[1].Columns.Add("nhomvp");
                ads.Tables[1].Columns.Add("sotien", typeof(decimal));
                ads.Tables[1].Columns.Add("vat", typeof(decimal));
                ads.Tables[1].Columns.Add("id", typeof(decimal));
                ads.Tables[1].Columns.Add("gia_dv", typeof(decimal));
                ads.Tables[1].Columns.Add("gia_bh", typeof(decimal));
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public void f_Print_BienlaiKB(bool v_dir, string v_id, string v_mmyy, string v_loaibl,string nhom_gtgt)
        {
            string acur = System.Environment.CurrentDirectory;
            string aReport = m_report_thutructiep;
            try
            {
                try
                {                    
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong, a.bacsi as bacsichidinh, b.mabs as bacsithuchien";
                    sql += ",i.gia_bh, i.gia_dv ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";

                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, round(gvp.gia_bh,2) as gia_bh, round(gvp." + sfield_gia + ",2) as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(decode(bd.gia_bh,0, bd.dongia, bd.gia_bh),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";

                    //sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                    //sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0";
                    if (nhom_gtgt != "") sql += " and i.id not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (nhom_gtgt != "" && adst.Tables[0].Rows.Count == 0) return;
                    else if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string asyt = "", abv = "", adiachibv = "", adiachi = "";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;

                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                    if (bInchuky)
                    {
                        try
                        {
                            adst.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                            }

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                foreach (DataRow r in adst.Tables[0].Rows)
                                    r["image"] = image;
                        }
                        catch
                        {

                        }
                    }

                    
                    string alydo = "", amasothue=m_v.sys_masothue;
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        alydo += r["tenvp"].ToString() + " [" + decimal.Parse(r["sotien"].ToString()).ToString("###,###,###.###") + "đ], ";
                    }
                    adst.Tables[0].Columns.Add(new DataColumn("lydo", typeof(string)));
                    adst.Tables[0].Columns.Add(new DataColumn("masothue", typeof(string)));
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        r["lydo"] = alydo;
                        r["masothue"] = amasothue;
                    }
                    adst.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep.xml", XmlWriteMode.WriteSchema);

                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByDefault);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";

                    cMain.SetDataSource(adst);

                    if (!v_dir) 
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString() + "-" + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                string s = ex.ToString();
                s += "//"+ex.Message;
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }

        public void f_Print_BienlaiKB(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string nhom_gtgt, bool v_bdichvu, string v_sttkham, string v_userid)
        {
            string acur = System.Environment.CurrentDirectory;
            string aReport = m_report_thutructiep;
            try
            {
                try
                {
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong, a.bacsi as bacsichidinh, b.mabs as bacsithuchien";
                    sql += ",i.gia_bh, i.gia_dv ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";

                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, round(gvp.gia_bh,2) as gia_bh, round(gvp." + sfield_gia + ",2) as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(decode(bd.gia_bh,0, bd.dongia, bd.gia_bh),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";

                    //sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                    //sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0";
                    if (nhom_gtgt != "") sql += " and i.id not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (nhom_gtgt != "" && adst.Tables[0].Rows.Count == 0) return;
                    else if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (v_bdichvu)
                    {
                        aReport = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                    }
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string asyt = "", abv = "", adiachibv = "", adiachi = "";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;

                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                    if (bInchuky)
                    {
                        try
                        {
                            adst.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                            }

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                foreach (DataRow r in adst.Tables[0].Rows)
                                    r["image"] = image;
                        }
                        catch
                        {

                        }
                    }


                    string alydo = "", amasothue = m_v.sys_masothue;
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        alydo += r["tenvp"].ToString() + " [" + decimal.Parse(r["sotien"].ToString()).ToString("###,###,###.###") + "đ], ";
                    }
                    adst.Tables[0].Columns.Add(new DataColumn("lydo", typeof(string)));
                    adst.Tables[0].Columns.Add(new DataColumn("masothue", typeof(string)));
                    adst.Tables[0].Columns.Add(new DataColumn("sttkham", typeof(string)));
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        r["lydo"] = alydo;
                        r["masothue"] = amasothue;
                        r["sttkham"] = v_sttkham;
                    }
                    adst.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep.xml", XmlWriteMode.WriteSchema);

                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByDefault);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";

                    cMain.SetDataSource(adst);
                    string v_sobanin = m_v.tt_sobanin_hoadonct(v_userid);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        //this.TopMost = true;
                        banin.Value = (v_sobanin == "") ? 1 : int.Parse(v_sobanin);
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter((v_sobanin == "") ? 1 : int.Parse(v_sobanin), false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString() + "-" + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                s += "//" + ex.Message;
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string nhom_gtgt, bool v_bdichvu)
        {
            string acur = System.Environment.CurrentDirectory;
            string aReport = m_report_thutructiep;
            try
            {
                try
                {
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong, a.bacsi as bacsichidinh, b.mabs as bacsithuchien";
                    sql += ",i.gia_bh, i.gia_dv ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";

                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, round(gvp.gia_bh,2) as gia_bh, round(gvp." + sfield_gia + ",2) as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(decode(bd.gia_bh,0, bd.dongia, bd.gia_bh),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";

                    //sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                    //sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0";
                    if (nhom_gtgt != "") sql += " and i.id not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (nhom_gtgt != "" && adst.Tables[0].Rows.Count == 0) return;
                    else if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (v_bdichvu)
                    {
                        aReport = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                    }
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string asyt = "", abv = "", adiachibv = "", adiachi = "";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;

                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                    if (bInchuky)
                    {
                        try
                        {
                            adst.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                            }

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                foreach (DataRow r in adst.Tables[0].Rows)
                                    r["image"] = image;
                        }
                        catch
                        {

                        }
                    }


                    string alydo = "", amasothue = m_v.sys_masothue;
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        alydo += r["tenvp"].ToString() + " [" + decimal.Parse(r["sotien"].ToString()).ToString("###,###,###.###") + "đ], ";
                    }
                    adst.Tables[0].Columns.Add(new DataColumn("lydo", typeof(string)));
                    adst.Tables[0].Columns.Add(new DataColumn("masothue", typeof(string)));
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        r["lydo"] = alydo;
                        r["masothue"] = amasothue;
                    }
                    adst.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep.xml", XmlWriteMode.WriteSchema);

                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByDefault);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";

                    cMain.SetDataSource(adst);

                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString() + "-" + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                s += "//" + ex.Message;
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB(bool v_dir, string v_id, string v_mmyy, string v_loaibl,string report,string nhom_gtgt)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    string aReport = m_report_thutructiep;
                    if (report != "") aReport = report;
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString()); ;
                    DataSet adst = null;

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong, a.bacsi as bacsichidinh, b.mabs as bacsithuchien";
                    sql += ", i.gia_bh, i.gia_dv,b.ngay as ngaycd ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";

                    //sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                    //sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";

                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, round(gvp.gia_bh,2) as gia_bh, round(gvp."+sfield_gia+",2) as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, to_number(decode(bd.gia_bh,0, round(bd.dongia,2),round(bd.gia_bh,2))) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";

                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0";
                    if (nhom_gtgt != "") sql += " and i.nhomvp not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (nhom_gtgt != "" && adst.Tables[0].Rows.Count == 0) return;
                    else if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string asyt = "", abv = "", adiachibv = "", adiachi = "";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;

                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                    if (bInchuky)
                    {
                        try
                        {
                            adst.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                            }

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                foreach (DataRow r in adst.Tables[0].Rows)
                                    r["image"] = image;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }


                    adst.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep1.xml", XmlWriteMode.WriteSchema);

                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";

                    cMain.SetDataSource(adst);

                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB_Loai(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {

                try
                {
                    string aReport = "v_bienlaithuvienphi_loai.rpt";
                    string sql = "", sfield_gia=m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = " select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, j.id as id_loai, j.ten as tenloaivp,  j.stt as sttloaivp,sum(b.soluong*b.dongia) as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien,  b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id ";
                    sql += " inner join medibv.v_quyenso bb on a.quyenso=bb.id  ";
                    sql += " left join medibvmmyy.v_mienngtru c  on a.id=c.id ";
                    sql += " left join medibv.btdbn d on a.mabn=d.mabn ";
                    sql += " left join medibv.btdkp_bv e on a.makp=e.makp";
                    sql += " left join medibv.btdtt f on d.matt=f.matt ";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                    sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    sql += " left join  medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma ";
                    sql += " where a.id=" + v_id;
                    sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt , g.tenquan ,h.tenpxa , d.sonha, d.thon, n.ten ,a.lanin+1 ,a.namsinh,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') , e.tenkp ,f.tentt,g.tenquan,tenpxa, j.id , j.ten ,  j.stt , b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end ,  b.madoituong, m.hoten,b.tra,a.ghichu  ";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "",   anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.s_masothue;
                    amauso = m_v.s_maubienlai;
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                   
                   
                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    decimal atongmien1 = 0;

                    try
                    {
                        atongmien1 = decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString());
                    }
                    catch
                    {
                        atongmien1 = 0;
                    }



                    adst.WriteXml("..\\..\\Datareport\\v_Inhoadonthutructiep_loai.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.DataDefinition.FormulaFields["syt"].Text = "'" + asyt + "'";
                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                    cMain.DataDefinition.FormulaFields["anguoiin"].Text = "'" + anguoiin + "'";


                    cMain.SetDataSource(adst);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB_Loai(bool v_dir, string v_id, string v_mmyy, string v_loaibl, bool v_bdichvu)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {

                try
                {
                    string aReport = "v_bienlaithuvienphi_loai.rpt";
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = " select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, j.id as id_loai, j.ten as tenloaivp,  j.stt as sttloaivp,sum(b.soluong*b.dongia) as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien,  b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id ";
                    sql += " inner join medibv.v_quyenso bb on a.quyenso=bb.id  ";
                    sql += " left join medibvmmyy.v_mienngtru c  on a.id=c.id ";
                    sql += " left join medibv.btdbn d on a.mabn=d.mabn ";
                    sql += " left join medibv.btdkp_bv e on a.makp=e.makp";
                    sql += " left join medibv.btdtt f on d.matt=f.matt ";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                    sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    sql += " left join  medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma ";
                    sql += " where a.id=" + v_id;
                    sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt , g.tenquan ,h.tenpxa , d.sonha, d.thon, n.ten ,a.lanin+1 ,a.namsinh,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') , e.tenkp ,f.tentt,g.tenquan,tenpxa, j.id , j.ten ,  j.stt , b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end ,  b.madoituong, m.hoten,b.tra,a.ghichu  ";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.s_masothue;
                    amauso = m_v.s_maubienlai;
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }


                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    decimal atongmien1 = 0;

                    try
                    {
                        atongmien1 = decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString());
                    }
                    catch
                    {
                        atongmien1 = 0;
                    }

                    if (v_bdichvu)
                    {
                        adst.WriteXml("..\\..\\Datareport\\v_Inhoadonthutructiep_loai_dichvu.xml", XmlWriteMode.WriteSchema);
                        aReport = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                    }
                    else
                    {
                        adst.WriteXml("..\\..\\Datareport\\v_Inhoadonthutructiep_loai.xml", XmlWriteMode.WriteSchema);
                    }

                    
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.DataDefinition.FormulaFields["syt"].Text = "'" + asyt + "'";
                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                    cMain.DataDefinition.FormulaFields["anguoiin"].Text = "'" + anguoiin + "'";


                    cMain.SetDataSource(adst);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB_Nhom(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
               
                try
                {
                    string aReport = "v_bienlaithuvienphi_nhom.rpt";
                    string sql = "", sfield_gia=m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = " select  a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh,e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, k.ma as id_nhom, k.ten as tennhomvp, i.stt as sttvp,sum(b.soluong*b.dongia) as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien,  b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id ";
                    sql+=" inner join medibv.v_quyenso bb on a.quyenso=bb.id  ";
                    sql+=" left join medibvmmyy.v_mienngtru c  on a.id=c.id ";
                    sql+=" left join medibv.btdbn d on a.mabn=d.mabn ";
                    sql+=" left join medibv.btdkp_bv e on a.makp=e.makp"; 
                    sql+=" left join medibv.btdtt f on d.matt=f.matt ";
                    sql+=" left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql+=" left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                    sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round("+sfield_gia+",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql+=" left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    sql+=" left join  medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma ";
                    sql+=" where a.id=" + v_id;
                    sql += " group by   a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt, g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten,a.lanin+1,a.namsinh,e.tenkp, to_char(a.ngay,'dd/mm/yyyy'), e.tenkp,f.tentt,g.tenquan,tenpxa,  k.ma , k.ten, i.stt ,  b.mien, b.thieu,   b.madoituong, m.hoten,case when c.sotien is null then 0 else c.sotien end,b.tra ,a.ghichu";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.s_masothue;
                    amauso = m_v.s_maubienlai;
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                  
                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    decimal  atongmien1 = 0;

                    try
                    {
                        atongmien1 = decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString());
                    }
                    catch
                    {
                        atongmien1 = 0;
                    }



                    adst.WriteXml("..\\..\\Datareport\\v_Inhoadonthutructiep_nhom.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.DataDefinition.FormulaFields["syt"].Text = "'" + asyt + "'";
                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                    cMain.DataDefinition.FormulaFields["anguoiin"].Text = "'" + anguoiin + "'";
                    

                    cMain.SetDataSource(adst);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB_Nhom(bool v_dir, string v_id, string v_mmyy, string v_loaibl,bool v_bdichvu)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {

                try
                {
                    string aReport = "v_bienlaithuvienphi_nhom.rpt";
                    string aReport1 = aReport;
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = " select  a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh,e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, k.ma as id_nhom, k.ten as tennhomvp, i.stt as sttvp,sum(b.soluong*b.dongia) as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien,  b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id ";
                    sql += " inner join medibv.v_quyenso bb on a.quyenso=bb.id  ";
                    sql += " left join medibvmmyy.v_mienngtru c  on a.id=c.id ";
                    sql += " left join medibv.btdbn d on a.mabn=d.mabn ";
                    sql += " left join medibv.btdkp_bv e on a.makp=e.makp";
                    sql += " left join medibv.btdtt f on d.matt=f.matt ";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                    sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    sql += " left join  medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma ";
                    sql += " where a.id=" + v_id;
                    sql += " group by   a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt, g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten,a.lanin+1,a.namsinh,e.tenkp, to_char(a.ngay,'dd/mm/yyyy'), e.tenkp,f.tentt,g.tenquan,tenpxa,  k.ma , k.ten, i.stt ,  b.mien, b.thieu,   b.madoituong, m.hoten,case when c.sotien is null then 0 else c.sotien end,b.tra ,a.ghichu";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.s_masothue;
                    amauso = m_v.s_maubienlai;
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }

                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    decimal atongmien1 = 0;

                    try
                    {
                        atongmien1 = decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString());
                    }
                    catch
                    {
                        atongmien1 = 0;
                    }

                    if (v_bdichvu)
                    {
                        adst.WriteXml("..\\..\\Datareport\\v_Inhoadonthutructiep_nhom_dichvu.xml", XmlWriteMode.WriteSchema);
                        aReport1 = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                    }
                    else
                    {
                        adst.WriteXml("..\\..\\Datareport\\v_Inhoadonthutructiep_nhom.xml", XmlWriteMode.WriteSchema);
                    }

                    
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport1, OpenReportMethod.OpenReportByTempCopy);
                    cMain.DataDefinition.FormulaFields["syt"].Text = "'" + asyt + "'";
                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                    cMain.DataDefinition.FormulaFields["anguoiin"].Text = "'" + anguoiin + "'";


                    cMain.SetDataSource(adst);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB_chitiet(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                string aReport = "v_inhoadontructiep_chitiet.rpt";
                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());

                string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu, i.gia_bh, i.gia_dv ";
                sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round("+sfield_gia+",2) gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " where a.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);
               
                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";



                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void f_Print_BienlaiKB_chitiet(bool v_dir, string v_id, string v_mmyy, bool v_bdichvu, string v_userid)
        {
            try
            {
                string aReport = "v_inhoadontructiep_chitiet.rpt";
                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());

                string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu, i.gia_bh, i.gia_dv ";
                sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " where a.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                if (v_bdichvu)
                {
                    aReport = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                }

                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                string v_sobanin = m_v.tt_sobanin_hoadonct(v_userid);
                
                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.banin.Value = (v_sobanin == "") ? 1 : int.Parse(v_sobanin);
                    //this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {

                    cMain.PrintToPrinter((v_sobanin == "") ? 1 : int.Parse(v_sobanin), false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void f_Print_BienlaiKB_chitiet(bool v_dir, string v_id, string v_mmyy,bool v_bdichvu)
        {
            try
            {
                string aReport = "v_inhoadontructiep_chitiet.rpt";
                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());

                string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt,i.hamluong, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu, i.gia_bh, i.gia_dv,cc.ten as tenphongcls,a.thanhtoan, '" + m_v.s_diachi + "' as diachibv,d.msthue,d.cholam ,b.sttcho ";
                sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                sql += " left join medibvmmyy.v_mienngtru c on a.id=c.id ";
                sql += " left join medibv.dmphongthuchiencls cc on b.idphongcls=cc.id ";
                sql += " left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) gia_dv,'' as hamluong from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv,hamluong from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " where a.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);


                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                if (v_bdichvu)
                {
                    aReport = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                }

                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\Report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                // gam hepa supreport -- tach hoa don thuoc va hoa don cls rieng ( 2 mau khac nhau )
                foreach (CrystalDecisions.CrystalReports.Engine.Section section in cMain.ReportDefinition.Sections)
                {
                    // In each section we need to loop through all the reporting objects
                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject reportObject in section.ReportObjects)
                    {
                        if (reportObject.Kind == ReportObjectKind.SubreportObject)
                        {
                            SubreportObject subReport = (SubreportObject)reportObject;
                            ReportDocument subDocument = subReport.OpenSubreport(subReport.SubreportName);
                            subDocument.SetDataSource(ads);
                            subDocument.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                        }
                    }
                }

                // end 
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void f_Print_BienlaiKB_chitiet(bool v_dir, string v_id, string v_mmyy, bool v_bdichvu,int v_sttchokham)
        {
            try
            {
                string aReport = "v_inhoadontructiep_chitiet.rpt";
                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());

                string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt,i.hamluong, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu, i.gia_bh, i.gia_dv,cc.ten as tenphongcls,a.thanhtoan, '" + m_v.s_diachi + "' as diachibv,d.msthue,d.cholam ,b.sttcho ";
                sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                sql += " left join medibvmmyy.v_mienngtru c on a.id=c.id ";
                sql += " left join medibv.dmphongthuchiencls cc on b.idphongcls=cc.id ";
                sql += " left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) gia_dv,'' as hamluong from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv,hamluong from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " where a.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                
                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // gam thêm dòng số thứ tự chờ khám
                DataRow r2 = ads.Tables[0].Rows[0];
                DataRow r1 = ads.Tables[0].NewRow();
                for (int i = 0; i < ads.Tables[0].Columns.Count; i++)
                {
                    r1[i] = r2[i].ToString();
                }
               
                //r1["id_loai"] = "9999";
                r1["sotien"] = 0;
                //r1["tenloaivp"] = "Bác sĩ đọc kết quả";
                r1["tennhomvp"] = "Bác sĩ đọc kết quả";
                r1["tenvp"] = "Bác sĩ đọc kết quả";
                r1["tenphongcls"] = r2["tenkp"].ToString();
                r1["sttcho"] = v_sttchokham;
                r1["id_nhom"] = 9999;
                ads.Tables[0].Rows.Add(r1);
                // end gam

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                if (v_bdichvu)
                {
                    aReport = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                }

                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\Report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                // gam hepa supreport -- tach hoa don thuoc va hoa don cls rieng ( 2 mau khac nhau )
                foreach (CrystalDecisions.CrystalReports.Engine.Section section in cMain.ReportDefinition.Sections)
                {
                    // In each section we need to loop through all the reporting objects
                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject reportObject in section.ReportObjects)
                    {
                        if (reportObject.Kind == ReportObjectKind.SubreportObject)
                        {
                            SubreportObject subReport = (SubreportObject)reportObject;
                            ReportDocument subDocument = subReport.OpenSubreport(subReport.SubreportName);
                            subDocument.SetDataSource(ads);
                            subDocument.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                        }
                    }
                }

                // end 
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        public void f_Print_BienlaiKB_gtgt(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                string aReport = m_report_thutructiep_gtgt;

                string sql = "select a.id, a.quyensodv as quyenso, a.sobienlaidv as sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,b.vat, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphidv b on a.id=b.id inner join medibv.v_quyenso bb on a.quyensodv=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " where a.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiepgtgt.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0) return;

                if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report :")+aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";



                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Hóa đơn giá trị gia tăng (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void f_Print_BienlaiKB_chitiet(bool v_dir, string v_id, string v_mmyy, string v_loai)
        {
            try
            {
                string aReport = "v_hoadonvienphi_chitiet.rpt";
                string sql = "";
                switch (v_loai)
                {
                    case "1"://Thu trực tiếp
                        sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                        sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                        sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                        sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                        sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                        sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                        sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                        sql += " left join medibvmmyy.v_mienngtru c ";
                        sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                        sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                        sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                        sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                        sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                        sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                        sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                        sql += " where a.id in(" + v_id + ")";
                        break;
                    case "2"://Thanh toán ra viện
                        sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, aa.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                        sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                        sql += " case when l.ngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.ngay,'dd/mm/yyyy') end as giatriden, ";
                        sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                        sql += " k.id as id_vp, k.id_loai as id_loai, k.id_nhom as id_nhom, k.ten as tenvp, nvl(k.tenloai,k.tennhom) as tenloaivp, k.tennhom as tennhomvp, k.stt as sttvp, k.sttloai as sttloaivp, ";
                        sql += " k.sttnhom as sttnhomvp, k.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, a.mien, a.thieu, a.mien as tongmien, ";
                        sql += " b.madoituong, m.hoten as nguoithu, b.tra as hoantra, null as ghichu from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id inner join medibvmmyy.v_ttrvct b on aa.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                        sql += " left join medibvmmyy.v_miennoitru c ";
                        sql += " on a.id=c.id inner join medibv.btdbn d on aa.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                        sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                        //
                        sql += " inner join (select a.id, a.stt, a.ten, a.dvt, a.id_loai, c.ma as id_nhom, b.stt as sttloai, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                        sql += " union all ";
                        sql += " select a.id, 1 as stt, trim(a.ten||' '|| a.hamluong) as ten, a.dang as dvt, 0 as id_loai, b.nhomvp as id_nhom, 0 as sttloai, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as k on b.mavp=k.id";
                        //
                        sql += " left join medibvmmyy.v_ttrvbhyt l on aa.id=l.id left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                        sql += " where a.id in(" + v_id + ") order by k.sttnhom, k.sttloai";
                        break;
                }
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";



                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void f_Print_BienlaiKB_Thuong(bool v_dir, string v_id, string v_mmyy, string v_loaibl,
            string v_bsthuchien, string v_bslamsang, string nhom_gtgt)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    bool ainsotienchitiet = true;
                    bool aintungaydenngay = false;
                    bool agiabangdongiacongvattu = false;

                    string aReport = m_report_thutructiep_thuong;
                    string sql = "";
                    DataSet adst = null;
                    string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    // gam 29-04-2011
                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra,case when b.khuyenmai <= 0 then b.mien else 0 end as mien , case when b.khuyenmai > 0 then b.mien else 0 end as khuyenmai  , b.thieu, case when b.khuyenmai <= 0 then case when c.sotien<>0 then c.sotien else 0 end  else 0 end as tongmien, case when b.khuyenmai > 0 then sum(b.mien) else 0 end as tongkhuyenmai, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,z.doituong, i.gia_th, i.gia_bh, i.gia_dv ";
                    //
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, gvp.gia_th, gvp.gia_bh, gvp." + sfield_gia + " as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, bd.giaban as gia_th, bd.gia_bh as gia_bh, bd.giaban as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0 ";
                    sql += "group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt, g.tenquan ,h.tenpxa , d.sonha, d.thon, n.ten ,a.lanin+1 ,a.namsinh ,l.sothe,l.denngay,e.tenkp,a.ngay,e.tenkp,f.tentt,g.tenquan,tenpxa, i.id, j.id,k.ma, i.ten,j.ten,k.ten,i.stt,j.stt,k.stt,i.dvt,b.soluong, b.dongia,b.khuyenmai,b.thieu, b.madoituong, m.hoten,b.tra ,a.ghichu,z.doituong, i.gia_th, i.gia_bh, i.gia_dv ,b.mien,c.sotien ";
                    if (nhom_gtgt != "") sql += " and i.id not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (nhom_gtgt != "" && adst.Tables[0].Rows.Count == 0) return;
                    else if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", alydobh = "", asotien = "", achutien = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", adiengiai = "", akhoact = "", sohieuquyenso = "", aloaivp = "", v_sttkham = "";

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    try
                    {
                        string[] a_sttkham = v_bsthuchien.Split('^');
                        if (a_sttkham.Length > 1) v_sttkham = a_sttkham[1];
                        else v_sttkham = "";
                    }
                    catch { }
                    atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.sys_masothue;// s_masothue;
                    amauso = m_v.s_maubienlai;
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }

                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    sohieuquyenso = adst.Tables[0].Rows[0]["sohieu"].ToString();
                    #region

                    decimal athucthu = 0, atongtien = 0, atongmien = 0, atongmien1 = 0, atongkhuyenmai = 0, atongthieu = 0, atongbhyt = 0, asoluong = 0, adongia = 0, amien = 0, athieu = 0, abhyt = 0, avattu = 0;

                    atongmien1 = decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString().Trim());
                    atongkhuyenmai = decimal.Parse(adst.Tables[0].Rows[0]["tongkhuyenmai"].ToString().Trim());
                    for (int i = 0; i < adst.Tables[0].Rows.Count; i++)
                    {

                        if (akhoact.IndexOf(adst.Tables[0].Rows[i]["tenkpct"].ToString().Trim()) < 0)
                        {
                            akhoact = akhoact.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
                        }
                        try
                        {
                            asoluong = decimal.Parse(adst.Tables[0].Rows[i]["soluong"].ToString());
                        }
                        catch
                        {
                            asoluong = 0;
                        }

                        try
                        {
                            adongia = decimal.Parse(adst.Tables[0].Rows[i]["dongia"].ToString());
                        }
                        catch
                        {
                            adongia = 0;
                        }

                        try
                        {
                            amien = decimal.Parse(adst.Tables[0].Rows[i]["mien"].ToString());
                        }
                        catch
                        {
                            amien = 0;
                        }

                        try
                        {
                            athieu = decimal.Parse(adst.Tables[0].Rows[i]["thieu"].ToString());
                        }
                        catch
                        {
                            athieu = 0;
                        }

                        try
                        {
                            avattu = decimal.Parse(adst.Tables[0].Rows[i]["vattu"].ToString());
                        }
                        catch
                        {
                            avattu = 0;
                        }

                        abhyt = 0;
                        if (adst.Tables[0].Rows[i]["madoituong"].ToString() == "1")
                        {
                            abhyt = amien;
                            amien = 0;
                            alydobh = alydobh.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenvp"].ToString();
                            if (asoluong > 1)
                            {
                                alydobh = alydobh + " (" + asoluong.ToString() + ")";
                            }
                            if (ainsotienchitiet)
                            {
                                alydobh = alydobh + " [" + (asoluong * adongia - amien - athieu).ToString("###,###,##0.##") + "]";
                            }

                            if (aintungaydenngay)
                            {
                                alydobh += " ";
                            }
                            alydobh = alydobh.Trim();
                            if (int.Parse(aloaivp.IndexOf(adst.Tables[0].Rows[i]["tenloaivp"].ToString()).ToString()) == -1)
                            {
                                aloaivp = aloaivp.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenloaivp"].ToString();
                            }
                        }
                        else
                        {
                            alydo = alydo.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenvp"].ToString();
                            if (asoluong > 1)
                            {
                                try
                                {
                                    if (adst.Tables[0].Rows[i]["dvt"].ToString().Trim().ToLower() == "ngày")
                                    {
                                        string denngay = m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(angayin).AddDays(int.Parse((asoluong - 1).ToString("#,##0"))));
                                        alydo = alydo + " (" + angayin + " --> " + denngay + ")";
                                    }
                                    else alydo = alydo + " (" + asoluong.ToString() + ")";
                                }
                                catch { alydo = alydo + " (" + asoluong.ToString() + ")"; }

                            }
                            if (ainsotienchitiet)
                            {
                                alydo = alydo + " [" + (asoluong * adongia - amien - athieu).ToString("###,###,##0.##") + " đ]";
                            }
                            if (aintungaydenngay)
                            {
                                alydo += " ";
                            }
                            alydo = alydo.Trim();
                            if (int.Parse(aloaivp.IndexOf(adst.Tables[0].Rows[i]["tenloaivp"].ToString()).ToString()) == -1)
                            {
                                aloaivp = aloaivp.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenloaivp"].ToString();
                            }
                        }

                        if (agiabangdongiacongvattu)
                        {
                            adongia += avattu;
                        }

                        atongtien = atongtien + asoluong * adongia;
                        atongmien = atongmien + amien;
                        atongthieu = atongthieu + athieu;
                        atongbhyt = atongbhyt + abhyt;
                    }
                    //

                    akhoact = akhoact.Trim().Trim(',');
                    if (akhoact != "")
                    {
                        akhoa = akhoact;
                    }

                    atongmien = atongmien1;


                    athucthu = atongtien - atongmien - atongthieu - atongbhyt;

                    try
                    {
                        athucthu = decimal.Parse(athucthu.ToString());
                    }
                    catch
                    {
                    }
                    asotien = athucthu.ToString("###,###,##0").Trim();
                    achutien = m_v.Doiso_Unicode(Math.Round(athucthu, 0).ToString());
                    if (achutien == "")
                    {
                        achutien = lan.Change_language_MessageText("Không đồng");
                    }

                    alydo = alydo.Trim().Trim(',');
                    alydobh = alydobh.Trim().Trim(',');
                    if (alydobh != "")
                    {
                        alydo = alydo + lan.Change_language_MessageText(", BHYT(") + alydobh + ")";
                    }
                    alydo = alydo.Trim().Trim(',');
                    alydo = alydo.Trim();

                    aloaivp = aloaivp.Trim().Trim(',');
                    aloaivp = aloaivp.Trim();

                    if ((atongmien1 > 0) || (atongthieu > 0) || (atongbhyt > 0) || (atongkhuyenmai > 0))
                    {
                        adiengiai = lan.Change_language_MessageText("Ghi chú: - Tổng chi phí:") + " " + atongtien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        if (atongbhyt > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- BHYT trả:") + " " + atongbhyt.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongmien > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- Miễn:") + " " + atongmien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongkhuyenmai > 0)
                        {
                            adiengiai += " " + lan.Change_language_MessageText("- Khuyến mãi:") + " " + atongkhuyenmai.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongthieu > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- Bệnh nhân nợ:") + " " + atongthieu.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                    }

                    DataSet ads = f_Cursor_BienlaiKB();
                    if (bInchuky)
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport.ToLower() + "'", "stt"))
                    {
                        DataRow r = ads.Tables[0].NewRow();
                        r["syt"] = asyt;
                        r["bv"] = abv;
                        r["diachibv"] = adiachibv;
                        r["tongcucthue"] = atongcuc;
                        r["cucthue"] = acucthue;
                        r["masothue"] = amasothue;
                        r["mauso"] = amauso;
                        r["quyenso"] = aquyenso;
                        r["sohieuquyenso"] = sohieuquyenso;
                        r["sobienlai"] = asobienlai;
                        r["ngayin"] = angayin;
                        r["lien"] = rl["ten"].ToString().Trim();
                        r["nguoiin"] = anguoiin;
                        r["ghichu"] = aghichu;
                        r["mabn"] = amabn;
                        r["hoten"] = ahoten;
                        r["ngaysinh"] = angaysinh;
                        r["gioitinh"] = agioitinh;
                        r["khoa"] = akhoa;
                        r["diachi"] = adiachi;
                        r["lydo"] = alydo;
                        r["loaivp"] = aloaivp;
                        r["sotien"] = asotien;
                        r["chutien"] = achutien;
                        r["nguoithu"] = anguoithu;
                        if (bInchuky)
                        {
                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                r["image"] = image;
                        }
                        r["diengiai"] = adiengiai;
                        r["bacsithuchien"] = v_bsthuchien;
                        r["bacsilamsang"] = v_bslamsang;
                        r["sttkham"] = v_sttkham;
                        r["id"] = v_id;// rl["id"].ToString();
                        ads.Tables[0].Rows.Add(r);

                        // hoa don chi tiet                        
                    }
                    foreach (DataRow r2 in adst.Tables[0].Rows)
                    {
                        DataRow r1 = ads.Tables[1].NewRow();
                        r1["mavp"] = r2["id_vp"];
                        r1["madoituong"] = r2["madoituong"];
                        r1["id_loaivp"] = r2["id_loai"];
                        r1["id_nhomvp"] = r2["id_nhom"];
                        r1["loaivp"] = r2["tenloaivp"];
                        r1["nhomvp"] = r2["tennhomvp"];
                        r1["sotien"] = r2["sotien"];
                        r1["vat"] = 0;// vat;
                        r1["id"] = v_id;
                        r1["gia_dv"] = r2["gia_dv"].ToString();
                        r1["gia_bh"] = r2["gia_bh"].ToString();
                        ads.Tables[1].Rows.Add(r1);
                    }
                    #endregion


                    ads.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep_thuong.xml", XmlWriteMode.WriteSchema);

                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";

                    cMain.SetDataSource(ads);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB_Thuong(bool v_dir, string v_id, string v_mmyy, string v_loaibl,
            string v_bsthuchien, string v_bslamsang, string nhom_gtgt,bool v_dichvu)// bool dich vu tach hoa don thuong va hoa don dich vu
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    bool ainsotienchitiet = true;
                    bool aintungaydenngay = false;
                    bool agiabangdongiacongvattu = false;

                    string aReport = m_report_thutructiep_thuong;
                    string sql = "";
                    DataSet adst = null;
                    string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    // gam 29-04-2011
                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra,case when b.khuyenmai <= 0 then b.mien else 0 end as mien , case when b.khuyenmai > 0 then b.mien else 0 end as khuyenmai  , b.thieu, case when b.khuyenmai <= 0 then case when c.sotien<>0 then c.sotien else 0 end  else 0 end as tongmien, case when b.khuyenmai > 0 then sum(b.mien) else 0 end as tongkhuyenmai, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,z.doituong, i.gia_th, i.gia_bh, i.gia_dv ";
                    //
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, gvp.gia_th, gvp.gia_bh, gvp." + sfield_gia + " as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, bd.giaban as gia_th, bd.gia_bh as gia_bh, bd.giaban as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0 ";
                    sql += "group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt, g.tenquan ,h.tenpxa , d.sonha, d.thon, n.ten ,a.lanin+1 ,a.namsinh ,l.sothe,l.denngay,e.tenkp,a.ngay,e.tenkp,f.tentt,g.tenquan,tenpxa, i.id, j.id,k.ma, i.ten,j.ten,k.ten,i.stt,j.stt,k.stt,i.dvt,b.soluong, b.dongia,b.khuyenmai,b.thieu, b.madoituong, m.hoten,b.tra ,a.ghichu,z.doituong, i.gia_th, i.gia_bh, i.gia_dv ,b.mien,c.sotien ";
                    if (nhom_gtgt != "") sql += " and i.id not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);
                    string aReport1 = "";
                    if (nhom_gtgt != "" && adst.Tables[0].Rows.Count == 0) return;
                    else if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (v_dichvu)
                    {
                        aReport1 = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                    }
                    else
                        aReport1 = aReport;
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport1))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "",
                        akhoa = "", adiachi = "", alydo = "", alydobh = "", asotien = "", achutien = "", anguoithu = "", amasothue = "",
                        amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",
                        adiengiai = "", akhoact = "", sohieuquyenso = "", aloaivp = "", v_sttkham = "";

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    try
                    {
                        string[] a_sttkham = v_bsthuchien.Split('^');
                        if (a_sttkham.Length > 1) v_sttkham = a_sttkham[1];
                        else v_sttkham = "";
                    }
                    catch { }
                    atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.sys_masothue;// s_masothue;
                    amauso = m_v.s_maubienlai;
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }

                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    sohieuquyenso = adst.Tables[0].Rows[0]["sohieu"].ToString();
                    #region

                    decimal athucthu = 0, atongtien = 0, atongmien = 0, atongmien1 = 0, atongkhuyenmai = 0, atongthieu = 0, atongbhyt = 0, asoluong = 0, adongia = 0, amien = 0, athieu = 0, abhyt = 0, avattu = 0;

                    atongmien1 = decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString().Trim());
                    atongkhuyenmai = decimal.Parse(adst.Tables[0].Rows[0]["tongkhuyenmai"].ToString().Trim());
                    for (int i = 0; i < adst.Tables[0].Rows.Count; i++)
                    {

                        if (akhoact.IndexOf(adst.Tables[0].Rows[i]["tenkpct"].ToString().Trim()) < 0)
                        {
                            akhoact = akhoact.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
                        }
                        try
                        {
                            asoluong = decimal.Parse(adst.Tables[0].Rows[i]["soluong"].ToString());
                        }
                        catch
                        {
                            asoluong = 0;
                        }

                        try
                        {
                            adongia = decimal.Parse(adst.Tables[0].Rows[i]["dongia"].ToString());
                        }
                        catch
                        {
                            adongia = 0;
                        }

                        try
                        {
                            amien = decimal.Parse(adst.Tables[0].Rows[i]["mien"].ToString());
                        }
                        catch
                        {
                            amien = 0;
                        }

                        try
                        {
                            athieu = decimal.Parse(adst.Tables[0].Rows[i]["thieu"].ToString());
                        }
                        catch
                        {
                            athieu = 0;
                        }

                        try
                        {
                            avattu = decimal.Parse(adst.Tables[0].Rows[i]["vattu"].ToString());
                        }
                        catch
                        {
                            avattu = 0;
                        }

                        abhyt = 0;
                        if (adst.Tables[0].Rows[i]["madoituong"].ToString() == "1")
                        {
                            abhyt = amien;
                            amien = 0;
                            alydobh = alydobh.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenvp"].ToString();
                            if (asoluong > 1)
                            {
                                alydobh = alydobh + " (" + asoluong.ToString() + ")";
                            }
                            if (ainsotienchitiet)
                            {
                                alydobh = alydobh + " [" + (asoluong * adongia - amien - athieu).ToString("###,###,##0.##") + "]";
                            }

                            if (aintungaydenngay)
                            {
                                alydobh += " ";
                            }
                            alydobh = alydobh.Trim();
                            if (int.Parse(aloaivp.IndexOf(adst.Tables[0].Rows[i]["tenloaivp"].ToString()).ToString()) == -1)
                            {
                                aloaivp = aloaivp.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenloaivp"].ToString();
                            }
                        }
                        else
                        {
                            alydo = alydo.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenvp"].ToString();
                            if (asoluong > 1)
                            {
                                try
                                {
                                    if (adst.Tables[0].Rows[i]["dvt"].ToString().Trim().ToLower() == "ngày")
                                    {
                                        string denngay = m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(angayin).AddDays(int.Parse((asoluong - 1).ToString("#,##0"))));
                                        alydo = alydo + " (" + angayin + " --> " + denngay + ")";
                                    }
                                    else alydo = alydo + " (" + asoluong.ToString() + ")";
                                }
                                catch { alydo = alydo + " (" + asoluong.ToString() + ")"; }

                            }
                            if (ainsotienchitiet)
                            {
                                alydo = alydo + " [" + (asoluong * adongia - amien - athieu).ToString("###,###,##0.##") + " đ]";
                            }
                            if (aintungaydenngay)
                            {
                                alydo += " ";
                            }
                            alydo = alydo.Trim();
                            if (int.Parse(aloaivp.IndexOf(adst.Tables[0].Rows[i]["tenloaivp"].ToString()).ToString()) == -1)
                            {
                                aloaivp = aloaivp.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenloaivp"].ToString();
                            }
                        }

                        if (agiabangdongiacongvattu)
                        {
                            adongia += avattu;
                        }

                        atongtien = atongtien + asoluong * adongia;
                        atongmien = atongmien + amien;
                        atongthieu = atongthieu + athieu;
                        atongbhyt = atongbhyt + abhyt;
                    }
                    //

                    akhoact = akhoact.Trim().Trim(',');
                    if (akhoact != "")
                    {
                        akhoa = akhoact;
                    }

                    atongmien = atongmien1;


                    athucthu = atongtien - atongmien - atongthieu - atongbhyt;

                    try
                    {
                        athucthu = decimal.Parse(athucthu.ToString());
                    }
                    catch
                    {
                    }
                    asotien = athucthu.ToString("###,###,##0").Trim();
                    achutien = m_v.Doiso_Unicode(Math.Round(athucthu, 0).ToString());
                    if (achutien == "")
                    {
                        achutien = lan.Change_language_MessageText("Không đồng");
                    }

                    alydo = alydo.Trim().Trim(',');
                    alydobh = alydobh.Trim().Trim(',');
                    if (alydobh != "")
                    {
                        alydo = alydo + lan.Change_language_MessageText(", BHYT(") + alydobh + ")";
                    }
                    alydo = alydo.Trim().Trim(',');
                    alydo = alydo.Trim();

                    aloaivp = aloaivp.Trim().Trim(',');
                    aloaivp = aloaivp.Trim();

                    if ((atongmien1 > 0) || (atongthieu > 0) || (atongbhyt > 0) || (atongkhuyenmai > 0))
                    {
                        adiengiai = lan.Change_language_MessageText("Ghi chú: - Tổng chi phí:") + " " + atongtien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        if (atongbhyt > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- BHYT trả:") + " " + atongbhyt.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongmien > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- Miễn:") + " " + atongmien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongkhuyenmai > 0)
                        {
                            adiengiai += " " + lan.Change_language_MessageText("- Khuyến mãi:") + " " + atongkhuyenmai.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongthieu > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- Bệnh nhân nợ:") + " " + atongthieu.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                    }

                    DataSet ads = f_Cursor_BienlaiKB();
                    if (bInchuky)
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    
                    foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport.ToLower() + "'", "stt"))
                    {
                        DataRow r = ads.Tables[0].NewRow();
                        r["syt"] = asyt;
                        r["bv"] = abv;
                        r["diachibv"] = adiachibv;
                        r["tongcucthue"] = atongcuc;
                        r["cucthue"] = acucthue;
                        r["masothue"] = amasothue;
                        r["mauso"] = amauso;
                        r["quyenso"] = aquyenso;
                        r["sohieuquyenso"] = sohieuquyenso;
                        r["sobienlai"] = asobienlai;
                        r["ngayin"] = angayin;
                        r["lien"] = rl["ten"].ToString().Trim();
                        r["nguoiin"] = anguoiin;
                        r["ghichu"] = aghichu;
                        r["mabn"] = amabn;
                        r["hoten"] = ahoten;
                        r["ngaysinh"] = angaysinh;
                        r["gioitinh"] = agioitinh;
                        r["khoa"] = akhoa;
                        r["diachi"] = adiachi;
                        r["lydo"] = alydo;
                        r["loaivp"] = aloaivp;
                        r["sotien"] = asotien;
                        r["chutien"] = achutien;
                        r["nguoithu"] = anguoithu;
                        if (bInchuky)
                        {
                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                r["image"] = image;
                        }
                        r["diengiai"] = adiengiai;
                        r["bacsithuchien"] = v_bsthuchien;
                        r["bacsilamsang"] = v_bslamsang;
                        r["sttkham"] = v_sttkham;
                        r["id"] = v_id;// rl["id"].ToString();
                        ads.Tables[0].Rows.Add(r);

                        // hoa don chi tiet                        
                    }
                    foreach (DataRow r2 in adst.Tables[0].Rows)
                    {
                        DataRow r1 = ads.Tables[1].NewRow();
                        r1["mavp"] = r2["id_vp"];
                        r1["madoituong"] = r2["madoituong"];
                        r1["id_loaivp"] = r2["id_loai"];
                        r1["id_nhomvp"] = r2["id_nhom"];
                        r1["loaivp"] = r2["tenloaivp"];
                        r1["nhomvp"] = r2["tennhomvp"];
                        r1["sotien"] = r2["sotien"];
                        r1["vat"] = 0;// vat;
                        r1["id"] = v_id;
                        r1["gia_dv"] = r2["gia_dv"].ToString();
                        r1["gia_bh"] = r2["gia_bh"].ToString();
                        ads.Tables[1].Rows.Add(r1);
                    }
                    #endregion

                    ads.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep_thuong.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport1, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";

                    cMain.SetDataSource(ads);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB_Thuong_1(bool v_dir, string v_id, string v_mmyy, string v_loaibl, 
            string v_bsthuchien, string v_bslamsang,string nhom_gtgt)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    bool ainsotienchitiet = true;
                    bool aintungaydenngay = false;
                    bool agiabangdongiacongvattu = false;

                    string aReport = m_report_thutructiep_thuong;
                    string sql = "";
                    DataSet adst = null;
                    string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,z.doituong, i.gia_th, i.gia_bh, i.gia_dv ";
                    //
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, gvp.gia_th, gvp.gia_bh, gvp."+sfield_gia+" as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, bd.giaban as gia_th, bd.gia_bh as gia_bh, bd.giaban as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0";
                    if (nhom_gtgt != "") sql += " and i.id not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (nhom_gtgt != "" && adst.Tables[0].Rows.Count == 0) return;
                    else if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ")+aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", alydobh = "", asotien = "", achutien = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", adiengiai = "", akhoact = "", sohieuquyenso = "", aloaivp = "", v_sttkham = "";

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    try
                    {
                        string[] a_sttkham = v_bsthuchien.Split('^');
                        if (a_sttkham.Length > 1) v_sttkham = a_sttkham[1];
                        else v_sttkham = "";
                    }
                    catch{}
                    atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.sys_masothue;// s_masothue;
                    amauso = m_v.s_maubienlai;
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }

                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    sohieuquyenso = adst.Tables[0].Rows[0]["sohieu"].ToString();
                    #region

                    decimal athucthu = 0, atongtien = 0, atongmien = 0, atongmien1 = 0, atongthieu = 0, atongbhyt = 0, asoluong = 0, adongia = 0, amien = 0, athieu = 0, abhyt = 0, avattu = 0;

                    atongmien1 =decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString().Trim());
                    for (int i = 0; i < adst.Tables[0].Rows.Count; i++)
                    {

                        if (akhoact.IndexOf(adst.Tables[0].Rows[i]["tenkpct"].ToString().Trim()) < 0)
                        {
                            akhoact = akhoact.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
                        }
                        try
                        {
                            asoluong = decimal.Parse(adst.Tables[0].Rows[i]["soluong"].ToString());
                        }
                        catch
                        {
                            asoluong = 0;
                        }

                        try
                        {
                            adongia = decimal.Parse(adst.Tables[0].Rows[i]["dongia"].ToString());
                        }
                        catch
                        {
                            adongia = 0;
                        }

                        try
                        {
                            amien = decimal.Parse(adst.Tables[0].Rows[i]["mien"].ToString());
                        }
                        catch
                        {
                            amien = 0;
                        }

                        try
                        {
                            athieu = decimal.Parse(adst.Tables[0].Rows[i]["thieu"].ToString());
                        }
                        catch
                        {
                            athieu = 0;
                        }

                        try
                        {
                            avattu = decimal.Parse(adst.Tables[0].Rows[i]["vattu"].ToString());
                        }
                        catch
                        {
                            avattu = 0;
                        }

                        abhyt = 0;
                        if (adst.Tables[0].Rows[i]["madoituong"].ToString() == "1")
                        {
                            abhyt = amien;
                            amien = 0;
                            alydobh = alydobh.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenvp"].ToString();
                            if (asoluong > 1)
                            {
                                alydobh = alydobh + " (" + asoluong.ToString() + ")";
                            }
                            if (ainsotienchitiet)
                            {
                                alydobh = alydobh + " [" + (asoluong * adongia - amien - athieu).ToString("###,###,##0.##") + "]";
                            }

                            if (aintungaydenngay)
                            {
                                alydobh += " ";
                            }
                            alydobh = alydobh.Trim();
                            if (int.Parse(aloaivp.IndexOf(adst.Tables[0].Rows[i]["tenloaivp"].ToString()).ToString()) == -1)
                            {
                                aloaivp = aloaivp.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenloaivp"].ToString();
                            }
                        }
                        else
                        {
                            alydo = alydo.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenvp"].ToString();
                            if (asoluong > 1)
                            {
                                try
                                {
                                    if (adst.Tables[0].Rows[i]["dvt"].ToString().Trim().ToLower() == "ngày")
                                    {
                                        string denngay = m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(angayin).AddDays(int.Parse((asoluong - 1).ToString("#,##0"))));
                                        alydo = alydo + " (" + angayin + " --> " + denngay + ")";
                                    }
                                    else alydo = alydo + " (" + asoluong.ToString() + ")";
                                }
                                catch { alydo = alydo + " (" + asoluong.ToString() + ")"; }
                                
                            }
                            if (ainsotienchitiet)
                            {
                                alydo = alydo + " [" + (asoluong * adongia - amien - athieu).ToString("###,###,##0.##") + " đ]";
                            }
                            if (aintungaydenngay)
                            {
                                alydo += " ";
                            }
                            alydo = alydo.Trim();
                            if (int.Parse(aloaivp.IndexOf(adst.Tables[0].Rows[i]["tenloaivp"].ToString()).ToString()) == -1)
                            {
                                aloaivp = aloaivp.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenloaivp"].ToString();
                            }
                        }

                        if (agiabangdongiacongvattu)
                        {
                            adongia += avattu;
                        }

                        atongtien = atongtien + asoluong * adongia;
                        atongmien = atongmien + amien;
                        atongthieu = atongthieu + athieu;
                        atongbhyt = atongbhyt + abhyt;                     
                    }
                    //
                   
                    akhoact = akhoact.Trim().Trim(',');
                    if (akhoact != "")
                    {
                        akhoa = akhoact;
                    }

                    atongmien = atongmien1;


                    athucthu = atongtien - atongmien - atongthieu - atongbhyt;

                    try
                    {
                        athucthu = decimal.Parse(athucthu.ToString());
                    }
                    catch
                    {
                    }
                    asotien = athucthu.ToString("###,###,##0").Trim();
                    achutien = m_v.Doiso_Unicode(Math.Round(athucthu,0).ToString());
                    if (achutien == "")
                    {
                        achutien = lan.Change_language_MessageText("Không đồng");
                    }

                    alydo = alydo.Trim().Trim(',');
                    alydobh = alydobh.Trim().Trim(',');
                    if (alydobh != "")
                    {
                        alydo = alydo + lan.Change_language_MessageText(", BHYT(") + alydobh + ")";
                    }
                    alydo = alydo.Trim().Trim(',');
                    alydo = alydo.Trim();

                    aloaivp = aloaivp.Trim().Trim(',');
                    aloaivp = aloaivp.Trim();

                    if ((atongmien1 > 0) || (atongthieu > 0) || (atongbhyt > 0))
                    {
                        adiengiai = lan.Change_language_MessageText("Ghi chú: - Tổng chi phí:") + " " + atongtien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        if (atongbhyt > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- BHYT trả:") + " " + atongbhyt.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongmien > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- Miễn:") + " " + atongmien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongthieu > 0)
                        {
                            adiengiai = adiengiai + " " + lan.Change_language_MessageText("- Bệnh nhân nợ:") + " " + atongthieu.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                    }

                    DataSet ads = f_Cursor_BienlaiKB();
                    if (bInchuky)
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport.ToLower() + "'", "stt"))
                    {
                        DataRow r = ads.Tables[0].NewRow();
                        r["syt"] = asyt;
                        r["bv"] = abv;
                        r["diachibv"] = adiachibv;
                        r["tongcucthue"] = atongcuc;
                        r["cucthue"] = acucthue;
                        r["masothue"] = amasothue;
                        r["mauso"] = amauso;
                        r["quyenso"] = aquyenso;
                        r["sohieuquyenso"] = sohieuquyenso;
                        r["sobienlai"] = asobienlai;
                        r["ngayin"] = angayin;
                        r["lien"] = rl["ten"].ToString().Trim();
                        r["nguoiin"] = anguoiin;
                        r["ghichu"] = aghichu;
                        r["mabn"] = amabn;
                        r["hoten"] = ahoten;
                        r["ngaysinh"] = angaysinh;
                        r["gioitinh"] = agioitinh;
                        r["khoa"] = akhoa;
                        r["diachi"] = adiachi;
                        r["lydo"] = alydo;
                        r["loaivp"] = aloaivp;
                        r["sotien"] = asotien;
                        r["chutien"] = achutien;
                        r["nguoithu"] = anguoithu;
                        if (bInchuky)
                        {
                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                r["image"] = image;
                        }
                        r["diengiai"] = adiengiai;
                        r["bacsithuchien"] = v_bsthuchien;
                        r["bacsilamsang"] = v_bslamsang;
                        r["sttkham"] = v_sttkham;
                        r["id"] = v_id;// rl["id"].ToString();
                        ads.Tables[0].Rows.Add(r);

                        // hoa don chi tiet                        
                    }
                    foreach (DataRow r2 in adst.Tables[0].Rows)
                    {
                        DataRow r1 = ads.Tables[1].NewRow();
                        r1["mavp"] = r2["id_vp"];
                        r1["madoituong"] = r2["madoituong"];
                        r1["id_loaivp"] = r2["id_loai"];
                        r1["id_nhomvp"] = r2["id_nhom"];
                        r1["loaivp"] = r2["tenloaivp"];
                        r1["nhomvp"] = r2["tennhomvp"];
                        r1["sotien"] = r2["sotien"];
                        r1["vat"] = 0;// vat;
                        r1["id"] = v_id;
                        r1["gia_dv"] = r2["gia_dv"].ToString();
                        r1["gia_bh"] = r2["gia_bh"].ToString();
                        ads.Tables[1].Rows.Add(r1);
                    }
                    #endregion

                    ads.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep_thuong.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";

                    cMain.SetDataSource(ads);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }

        private DataSet f_Cursor_BienlaiKB_Trongoi()
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
                ads.Tables[0].Columns.Add("tamung");
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public void f_Print_BienlaiKB_Trongoi(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                bool ainsotienchitiet = false;
                bool aintungaydenngay = false;
                bool agiabangdongiacongvattu = false;
                try
                {
                    string aReport = m_report_thutrongoi;
                    string sql = "";
                    DataSet adst = null;
                    sql = "select  k.tenkp, l.tenkp as tenkpct, a.id, aa.sovaovien, a.sobienlai, b.soluong, b.dongia, b.mien, aaa.sotien as tongmien,a1.tamung, b.thieu, b.vattu, b.madoituong, a.mabn, a.hoten, a.namsinh as ngaysinh, b.mavp, c.ten as tenvp, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, a.lanin+1 as lanin from medibvmmyy.v_vienphill a left join medibvmmyy.tiepdon aa on a.mabn=aa.mabn and a.maql=aa.maql left join medibvmmyy.v_mienngtru aaa on a.id=aaa.id left join medibvmmyy.v_vienphict b on a.id=b.id inner join medibvmmyy.v_trongoi a1 on a.id=a1.id left join (select id, ten from medibv.v_giavp union select id, ten||' '|| hamluong as ten from medibv.d_dmbd) as c on b.mavp=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibv.btdkp_bv k on a.makp=k.makp left join medibv.btdkp_bv l on b.makp=l.makp where a.id=" + v_id + " order by b.stt";
                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí trọn gói <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", alydobh = "", asotien = "", achutien = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", adiengiai = "", akhoact = "";
                    decimal atamung = 0;
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    atongcuc = 
lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = 
lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.s_masothue;
                    amauso = m_v.s_maubienlai;
                    try
                    {
                        atamung = decimal.Parse(adst.Tables[0].Rows[0]["tamung"].ToString());
                    }
                    catch
                    {
                        atamung = 0;
                    }
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                    alydo = "";
                    asotien = "";
                    achutien = "";
                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    decimal athucthu = 0, atongtien = 0, atongmien = 0, atongmien1 = 0, atongthieu = 0, atongbhyt = 0, asoluong = 0, adongia = 0, amien = 0, athieu = 0, abhyt = 0, avattu = 0;

                    try
                    {
                        atongmien1 = decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString());
                    }
                    catch
                    {
                        atongmien1 = 0;
                    }

                    for (int i = 0; i < adst.Tables[0].Rows.Count; i++)
                    {
                        if (akhoact.IndexOf(adst.Tables[0].Rows[i]["tenkpct"].ToString().Trim()) < 0)
                        {
                            akhoact = akhoact.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
                        }
                        try
                        {
                            asoluong = decimal.Parse(adst.Tables[0].Rows[i]["soluong"].ToString());
                        }
                        catch
                        {
                            asoluong = 0;
                        }

                        try
                        {
                            adongia = decimal.Parse(adst.Tables[0].Rows[i]["dongia"].ToString());
                        }
                        catch
                        {
                            adongia = 0;
                        }

                        try
                        {
                            amien = decimal.Parse(adst.Tables[0].Rows[i]["mien"].ToString());
                        }
                        catch
                        {
                            amien = 0;
                        }

                        try
                        {
                            athieu = decimal.Parse(adst.Tables[0].Rows[i]["thieu"].ToString());
                        }
                        catch
                        {
                            athieu = 0;
                        }
                        try
                        {
                            avattu = decimal.Parse(adst.Tables[0].Rows[i]["vattu"].ToString());
                        }
                        catch
                        {
                            avattu = 0;
                        }
                        abhyt = 0;
                        if (adst.Tables[0].Rows[i]["madoituong"].ToString() == "1")
                        {
                            abhyt = amien;
                            amien = 0;
                            alydobh = alydobh.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenvp"].ToString();
                            if (asoluong > 1)
                            {
                                alydobh = alydobh + " (" + asoluong.ToString() + ")";
                            }
                            if (ainsotienchitiet)
                            {
                                alydobh = alydobh + " [" + (asoluong * adongia - amien - athieu).ToString("###,###,##0.##") + "]";
                            }

                            if (aintungaydenngay)
                            {
                                alydobh += " ";
                            }
                            alydobh = alydobh.Trim();
                        }
                        else
                        {
                            alydo = alydo.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenvp"].ToString();
                            if (asoluong > 1)
                            {
                                alydo = alydo + " (" + asoluong.ToString() + ")";
                            }
                            if (ainsotienchitiet)
                            {
                                alydo = alydo + " [" + (asoluong * adongia - amien - athieu).ToString("###,###,##0.##") + "]";
                            }
                            if (aintungaydenngay)
                            {
                                alydo += " ";
                            }
                            alydo = alydo.Trim();
                        }

                        if (agiabangdongiacongvattu)
                        {
                            adongia += avattu;
                        }

                        atongtien = atongtien + asoluong * adongia;
                        atongmien = atongmien + amien;
                        atongthieu = atongthieu + athieu;
                        atongbhyt = 0;// atongbhyt + abhyt;
                    }
                    akhoact = akhoact.Trim().Trim(',');
                    if (akhoact != "")
                    {
                        akhoa = akhoact;
                    }

                    atongmien = atongmien1;


                    athucthu = atongtien - atongmien - atongthieu;

                    try
                    {
                        athucthu = decimal.Parse(long.Parse(athucthu.ToString()).ToString());
                    }
                    catch
                    {
                    }
                    asotien = athucthu.ToString();
                    achutien = m_v.Doiso_Unicode(athucthu.ToString());
                    if (achutien == "")
                    {
                        achutien = lan.Change_language_MessageText(
"Không đồng");
                    }

                    alydo = alydo.Trim().Trim(',');
                    alydobh = alydobh.Trim().Trim(',');
                    if (alydobh != "")
                    {
                        alydo = alydo + lan.Change_language_MessageText(
", BHYT(") + alydobh + ")";
                    }
                    alydo = alydo.Trim().Trim(',');
                    alydo = alydo.Trim();

                    if (atongmien1 > 0 || atongthieu > 0 || atongbhyt > 0 || atamung > 0)
                    {
                        adiengiai = lan.Change_language_MessageText(
"Ghi chú: - Tổng chi phí:")+" " + atongtien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        if (atongbhyt > 0)
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText(
"- BHYT trả:")+" " + atongbhyt.ToString("###,###,###.##") + lan.Change_language_MessageText(
"đ");
                        }
                        if (atongmien > 0)
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText(
"- Miễn:")+" " + atongmien.ToString("###,###,###.##") + lan.Change_language_MessageText(
"đ");
                        }
                        if (atongthieu > 0)
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText(
"- Bệnh nhân nợ:")+" " + atongthieu.ToString("###,###,###.##") + lan.Change_language_MessageText(
"đ");
                        }
                        if (atamung >0)
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText(
"- Tạm ứng:")+" " + atamung.ToString("###,###,###.##") + lan.Change_language_MessageText(
"đ");
                        }
                        if (atongtien - atongbhyt - atongmien - atamung < 0)
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText("- Phải hoàn:")+" " + (atamung - atongtien + atongbhyt + atongmien).ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        else
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText("- Phải thu:")+" " + (atongtien - atongbhyt - atongmien - atamung).ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                    }
                    DataSet ads = f_Cursor_BienlaiKB_Trongoi();
                    foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport.ToLower() + "'", "stt"))
                    {
                        DataRow r = ads.Tables[0].NewRow();
                        r["syt"] = asyt;
                        r["bv"] = abv;
                        r["diachibv"] = adiachibv;
                        r["tongcucthue"] = atongcuc;
                        r["cucthue"] = acucthue;
                        r["masothue"] = amasothue;
                        r["mauso"] = amauso;
                        r["quyenso"] = aquyenso;
                        r["sobienlai"] = asobienlai;
                        r["ngayin"] = angayin;
                        r["nguoiin"] = anguoiin;
                        r["ghichu"] = aghichu;
                        r["lien"] = rl["ten"].ToString().Trim();
                        r["mabn"] = amabn;
                        r["hoten"] = ahoten;
                        r["ngaysinh"] = angaysinh;
                        r["gioitinh"] = agioitinh;
                        r["khoa"] = akhoa;
                        r["diachi"] = adiachi;
                        r["lydo"] = alydo;
                        r["sotien"] = asotien;
                        r["chutien"] = achutien;
                        r["tamung"] = atamung.ToString();
                        r["nguoithu"] = anguoithu;
                        r["diengiai"] = adiengiai;
                        ads.Tables[0].Rows.Add(r);
                    }
                    ads.WriteXml("..\\..\\Datareport\\v_vienlaithuvienphitrongoi.xml", XmlWriteMode.WriteSchema);

                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.SetDataSource(ads);
                    //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                    //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp (") + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiKB_Trongoi_Chitiet(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    string aReport = m_report_thutrongoi;
                    string sql = "";
                    DataSet adst = null;
                    sql = "select  k.tenkp, a.id, aa.sovaovien, a.sobienlai, a1.soluong, a2.ten, a2.dvt, b.sotien, b.tamung, b.hoantra, b1.sotien as sotienct, aaa.sotien as tongmien,a.mabn, a.hoten, a.namsinh as ngaysinh, b1.ma as id_loai, c.ten as ten_loai, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, a.lanin+1 as lanin from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict a1 on a.id=a1.id left join medibv.v_giavp a2 on a1.mavp=a2.id left join medibvmmyy.tiepdon aa on a.mabn=aa.mabn and a.maql=aa.maql left join medibvmmyy.v_mienngtru aaa on a.id=aaa.id inner join medibvmmyy.v_trongoi b on a.id=b.id inner join medibvmmyy.v_nhom b1 on a.id=b1.id left join medibv.v_loaivp c on b1.ma=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibv.btdkp_bv k on a.makp=k.makp where a.id="+v_id;
                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí trọn gói <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "",  asotien = "", achutien = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", adiengiai = "", akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
                    atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                    acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                    amasothue = m_v.s_masothue;
                    amauso = m_v.s_maubienlai;
                    aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                    asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                    angayin = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    aghichu = "(In lần " + adst.Tables[0].Rows[0]["lanin"].ToString() + ")";
                    amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                    ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                    akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                    akhoact = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim();
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                    alydo = "";
                    asotien = "";
                    achutien = "";
                    anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                    decimal athucthu = 0, atongtien = 0, atongmien = 0, atamung=0, asotient=0;

                    try
                    {
                        atongtien = decimal.Parse(adst.Tables[0].Rows[0]["sotien"].ToString());
                    }
                    catch
                    {
                        atongtien = 0;
                    }
                    try
                    {
                        atamung = decimal.Parse(adst.Tables[0].Rows[0]["tamung"].ToString());
                    }
                    catch
                    {
                        atamung = 0;
                    }
                    try
                    {
                        atongmien = decimal.Parse(adst.Tables[0].Rows[0]["tongmien"].ToString());
                    }
                    catch
                    {
                        atongmien = 0;
                    }

                    alydo = adst.Tables[0].Rows[0]["ten"].ToString().Trim();
                    alydo += " (" + adst.Tables[0].Rows[0]["soluong"].ToString().Trim();
                    alydo += " " + adst.Tables[0].Rows[0]["dvt"].ToString().Trim() + ")";
                    alydo += "\n"+lan.Change_language_MessageText("Bao gồm:")+" ";
                    for (int i = 0; i < adst.Tables[0].Rows.Count; i++)
                    {
                        if (akhoact.IndexOf(adst.Tables[0].Rows[i]["tenkp"].ToString().Trim()) < 0)
                        {
                            akhoact = akhoact.Trim().Trim(',') + ", " + adst.Tables[0].Rows[i]["tenkp"].ToString().Trim();
                        }
                        try
                        {
                            asotient = decimal.Parse(adst.Tables[0].Rows[i]["sotienct"].ToString());
                        }
                        catch
                        {
                            asotient = 0;
                        }
                        alydo = alydo.Trim().Trim('-') + " - " + adst.Tables[0].Rows[i]["ten_loai"].ToString();
                        alydo = alydo + ": " + (asotient).ToString("###,###,##0.##") + lan.Change_language_MessageText("đ");
                    }
                    alydo = alydo.Trim().Trim(' ');
                    alydo = alydo.Trim().Trim('-');
                    akhoact = akhoact.Trim().Trim(',');
                    if (akhoact != "")
                    {
                        akhoa = akhoact;
                    }

                    athucthu = atongtien - atongmien;

                    try
                    {
                        athucthu = decimal.Parse(long.Parse(athucthu.ToString()).ToString());
                    }
                    catch
                    {
                    }
                    asotien = athucthu.ToString();
                    achutien = m_v.Doiso_Unicode(athucthu.ToString());
                    if (achutien == "")
                    {
                        achutien = lan.Change_language_MessageText("Không đồng");
                    }

                    alydo = alydo.Trim().Trim(',');
                    alydo = alydo.Trim().Trim(',');
                    alydo = alydo.Trim();

                    if (atongmien > 0 || atamung > 0)
                    {
                        adiengiai = lan.Change_language_MessageText("Ghi chú: - Tổng chi phí:")+" " + atongtien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        if (atongmien > 0)
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText("- Miễn:")+" " + atongmien.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atamung > 0)
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung.ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        if (atongtien - atongmien - atamung < 0)
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText("- Phải hoàn:")+" " + (atamung - atongtien + atongmien).ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                        else
                        {
                            adiengiai = adiengiai + " "+lan.Change_language_MessageText("- Phải thu:")+" " + (atongtien - atongmien - atamung).ToString("###,###,###.##") + lan.Change_language_MessageText("đ");
                        }
                    }
                    DataSet ads = f_Cursor_BienlaiKB_Trongoi();
                    foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport.ToLower() + "'", "stt"))
                    {
                        DataRow r = ads.Tables[0].NewRow();
                        r["syt"] = asyt;
                        r["bv"] = abv;
                        r["diachibv"] = adiachibv;
                        r["tongcucthue"] = atongcuc;
                        r["cucthue"] = acucthue;
                        r["masothue"] = amasothue;
                        r["mauso"] = amauso;
                        r["quyenso"] = aquyenso;
                        r["sobienlai"] = asobienlai;
                        r["ngayin"] = angayin;
                        r["nguoiin"] = anguoiin;
                        r["ghichu"] = aghichu;
                        r["lien"] = rl["ten"].ToString().Trim();
                        r["mabn"] = amabn;
                        r["hoten"] = ahoten;
                        r["ngaysinh"] = angaysinh;
                        r["gioitinh"] = agioitinh;
                        r["khoa"] = akhoa;
                        r["diachi"] = adiachi;
                        r["lydo"] = alydo;
                        r["sotien"] = asotien;
                        r["chutien"] = achutien;
                        r["tamung"] = atamung.ToString();
                        r["nguoithu"] = anguoithu;
                        r["diengiai"] = adiengiai;
                        ads.Tables[0].Rows.Add(r);
                    }
                    ads.WriteXml("..\\..\\Datareport\\v_vienlaithuvienphitrongoi.xml", XmlWriteMode.WriteSchema);

                     cMain = new ReportDocument();

                     cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.SetDataSource(ads);
                    //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                    //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp (") + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
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
                ads.Tables[0].Columns.Add("lanin");//binh
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public void f_Print_BienlaiTU(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                DataSet adst;

                string sql = "";
                sql = "select  a.id, a.mabn, a.sobienlai, a.sotien, to_char(a.ngay,'dd/mm/yyyy') as ngay, b.tenkp, d.mabn, d.hoten, case when d.ngaysinh is null then d.namsinh else to_char(d.ngaysinh,'dd/mm/yyyy') end as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, a.lanin+1 as lanin from medibvmmyy.v_tamung a left join medibv.btdkp_bv b on a.makp=b.makp left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id where a.id=" + v_id + "";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu tạm ứng <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", alanin = "1", aReport="";
                aReport = m_report_thutamung;
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();
                alydo = lan.Change_language_MessageText("Tạm ứng nhập viện");
                alanin = adst.Tables[0].Rows[0]["lanin"].ToString();
                asotien = adst.Tables[0].Rows[0]["sotien"].ToString().Trim();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();

                asotien = decimal.Parse(asotien.ToString()).ToString("############");
                achutien = m_v.Doiso_Unicode(asotien.Replace(",", ""));

                DataSet ads = f_Cursor_BienlaiTU();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }                       
                    }
                    catch
                    {

                    }
                }
                foreach(DataRow rl in m_dslien.Tables[0].Select("tenreport='"+aReport+"'","stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["nguoithu"] = anguoithu;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    r["lanin"] = alanin;
                    ads.Tables[0].Rows.Add(r);
                }
                ads.WriteXml("..\\..\\Datareport\\v_bienlaitamung.xml", XmlWriteMode.WriteSchema);
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.Text = lan.Change_language_MessageText("Hoá đơn tạm ứng chi tiết (") + aReport + ")";
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_tamung set lanin=(case when lanin is null then 0 else lanin end)+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_BienlaiTU_Chitiet(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                DataSet adst;

                string sql = "";
                sql = "select  a.id, a.mabn, a.sobienlai, a.sotien, case when a1.sotien is null then 0 else a1.sotien end as sotienct, a2.ten as tenloaivp, to_char(a.ngay,'dd/mm/yyyy') as ngay, b.tenkp, d.mabn, d.hoten, case when d.ngaysinh is null then d.namsinh else to_char(d.ngaysinh,'dd/mm/yyyy') end as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, a.lanin+1 as lanin from medibvmmyy.v_tamung a left join medibvmmyy.v_tamungct a1 on a.id=a1.id left join medibv.v_loaivp a2 on a1.loaivp=a2.id left join medibv.btdkp_bv b on a.makp=b.makp left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id where a.id=" + v_id + "";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu tạm ứng <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", alanin = "1", aReport = "";
                aReport = m_report_thutamung;
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();
                alydo = lan.Change_language_MessageText("Tạm ứng nhập viện");
                foreach (DataRow r in adst.Tables[0].Rows)
                {
                    alydo += "\n";
                    alydo += r["tenloaivp"].ToString().Trim()+"\t:";
                    alydo += decimal.Parse(r["sotienct"].ToString().Trim()).ToString("###,###,##0.##") + lan.Change_language_MessageText("đ");
                }
                alanin = adst.Tables[0].Rows[0]["lanin"].ToString();
                asotien = adst.Tables[0].Rows[0]["sotien"].ToString().Trim();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();

                asotien = decimal.Parse(asotien.ToString()).ToString("############");
                achutien = m_v.Doiso_Unicode(asotien.Replace(",", ""));

                DataSet ads = f_Cursor_BienlaiTU();
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["nguoithu"] = anguoithu;
                    r["lanin"] = alanin;
                    ads.Tables[0].Rows.Add(r);
                }

                ads.WriteXml("..\\..\\Datareport\\v_bienlaitamung_chitiet.xml", XmlWriteMode.WriteSchema);
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.Text = lan.Change_language_MessageText("Hoá đơn tạm ứng chi tiết (")+aReport+")";
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_tamung set lanin=(case when lanin is null then 0 else lanin end)+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ads.Tables[0].Columns.Add("id", typeof(decimal));
                //
                ads.Tables.Add("Chitiet");
                ads.Tables[1].Columns.Add("madoituong", typeof(int));
                ads.Tables[1].Columns.Add("mavp", typeof(int));
                ads.Tables[1].Columns.Add("tenvp");
                ads.Tables[1].Columns.Add("id_loaivp", typeof(int));
                ads.Tables[1].Columns.Add("loaivp");
                ads.Tables[1].Columns.Add("id_nhomvp", typeof(int));
                ads.Tables[1].Columns.Add("nhomvp");
                ads.Tables[1].Columns.Add("sotien", typeof(decimal));
                ads.Tables[1].Columns.Add("vat", typeof(decimal));
                ads.Tables[1].Columns.Add("id", typeof(decimal));
                ads.Tables[1].Columns.Add("gia_dv", typeof(decimal));
                ads.Tables[1].Columns.Add("gia_bh", typeof(decimal));
                return ads;
            }
            catch
            {
                return null;
            }
        }
        //Them function tinh chi phi chi tiet khi thanh toan ra vien
        public string get_Lydo_ct(string v_id, string v_mmyy)
        {
            try
            {
                string s_Lydo = "";
                DataSet adst;
                string sql = "";
                sql = "select distinct * from (";
                sql += " select d.ten,e.doituong,a.madoituong, sum(a.sotien) sotien from medibvmmyy.v_ttrvct a left join medibv.v_giavp b on  a.mavp=b.id left join medibv.v_loaivp c on b.id_loai=c.id left join medibv.v_nhomvp d on c.id_nhom=d.ma inner join medibv.doituong e on a.madoituong=e.madoituong where a.id=" + v_id + " group by  d.ten,e.doituong,a.madoituong having d.ten is not null ";
                sql += " union all ";
                sql += " select d.ten,e.doituong,a.madoituong,sum(a.sotien) sotien from medibvmmyy.v_ttrvct a left join medibv.d_dmbd b on  a.mavp=b.id left join medibv.d_dmnhom c on b.manhom=c.id left join medibv.v_nhomvp d on c.nhomvp=d.ma inner join medibv.doituong e on a.madoituong=e.madoituong  where a.id=" + v_id + " group by d.ten,e.doituong,a.madoituong having d.ten is not null) froo";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                    return "-1";
                else
                {
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        if (r != null)
                        {
                            s_Lydo += r["ten"].ToString().Trim() + " [ " + r["doituong"].ToString().Trim() + " ]" + ":" + (r["sotien"] != null ? decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###").Trim() : "0") + " + ";
                        }
                    }
                }
                return s_Lydo.Trim().Substring(0,s_Lydo.Length-2);
            }
            catch 
            {
                return "-1";
            }
        }
        //thanh toan ra vien
        public void f_Print_Bienlai_ThuongNT(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    string aReport = "v_bienlaithuvienphi_thuongnt.rpt";
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, ds.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,d.namsinh as ngaysinh,  case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt,";
                    sql += "case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp,";
                    sql += "j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp,  k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,giamua, b.soluong*b.dongia as sotien, ";
                    sql += "a.bhyt as bhtra, a.mien, a.thieu,a.mien as tongmien,  b.madoituong, m.hoten as nguoithu,0 as hoantra,ds.chandoan as ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong";
                    sql += ", i.gia_bh, i.gia_dv, i.gia_th, a.tamung ";
                    sql += ", i.hangsx, i.nuocsx ";
                    sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                    sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                    sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";//binh thay a.makp thanh b.makp
                    sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join (select id, stt, ten, dvt, id_loai, gia_bh, " + sfield_gia + " as gia_dv, gia_th, null as hangsx, null as nuocsx from medibv.v_giavp union select a.id, 1 as stt, a.ten|| case when a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt, 0 as id_loai, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, b.ten as nuocsx, c.ten as hangsx from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id left join medibv.d_dmnuoc c on a.manuoc=c.id) i on b.mavp=i.id ";
                    sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    sql += " left join  medibv.bhyt l on ds.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong ";
                    sql += " where ds.id=" + v_id + "";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", adiachibv = "", adiachi = "";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    decimal atiendichvu = 0;
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;
         
                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }

                    foreach (DataRow r in adst.Tables[0].Select("giamua>0"))
                    {
                        decimal adongia = 0, agiamua = 0, atong = 0;
                        adongia = decimal.Parse(r["dongia"].ToString());
                        agiamua = decimal.Parse(r["giamua"].ToString());
                        atong = adongia - agiamua;
                        atiendichvu += atong;
                    }

                    if (bInchuky)
                    {
                        try
                        {
                            adst.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                            }

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                foreach (DataRow r in adst.Tables[0].Rows)
                                    r["image"] = image;
                        }
                        catch
                        {

                        }
                    }
                    adst.WriteXml("..\\..\\Datareport\\v_bienlaithuvienphi_thuongnt.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                    cMain.DataDefinition.FormulaFields["atiendichvu"].Text = "'" + atiendichvu + "'";
                    cMain.SetDataSource(adst);

                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_Bienlai_ThuongNT(bool v_dir, string v_id, string v_mmyy, string v_loaibl, bool v_bdichvu)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    string aReport = "v_bienlaithuvienphi_thuongnt.rpt";
                    if (v_bdichvu)
                        aReport = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, ds.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,d.namsinh as ngaysinh,  case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt,";
                    sql += "case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp,";
                    sql += "j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp,  k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,giamua, b.soluong*b.dongia as sotien, ";
                    sql += "a.bhyt as bhtra, a.mien, a.thieu,a.mien as tongmien,  b.madoituong, m.hoten as nguoithu,0 as hoantra,ds.chandoan as ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong";
                    sql += ", i.gia_bh, i.gia_dv, i.gia_th, a.tamung ";
                    sql += ", i.hangsx, i.nuocsx ";
                    sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                    sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                    sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";//binh thay a.makp thanh b.makp
                    sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join (select id, stt, ten, dvt, id_loai, gia_bh, " + sfield_gia + " as gia_dv, gia_th, null as hangsx, null as nuocsx from medibv.v_giavp union select a.id, 1 as stt, a.ten|| case when a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt, 0 as id_loai, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, b.ten as nuocsx, c.ten as hangsx from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id left join medibv.d_dmnuoc c on a.manuoc=c.id) i on b.mavp=i.id ";
                    sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    sql += " left join  medibv.bhyt l on ds.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong ";
                    sql += " where ds.id=" + v_id + "";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", adiachibv = "", adiachi = "";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    decimal atiendichvu = 0;
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;

                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }

                    foreach (DataRow r in adst.Tables[0].Select("giamua>0"))
                    {
                        decimal adongia = 0, agiamua = 0, atong = 0;
                        adongia = decimal.Parse(r["dongia"].ToString());
                        agiamua = decimal.Parse(r["giamua"].ToString());
                        atong = adongia - agiamua;
                        atiendichvu += atong;
                    }

                    if (bInchuky)
                    {
                        try
                        {
                            adst.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                            }

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                foreach (DataRow r in adst.Tables[0].Rows)
                                    r["image"] = image;
                        }
                        catch
                        {

                        }
                    }
                    adst.WriteXml("..\\..\\Datareport\\v_bienlaithuvienphi_thuongnt.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                    cMain.DataDefinition.FormulaFields["atiendichvu"].Text = "'" + atiendichvu + "'";
                    cMain.SetDataSource(adst);

                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_Bienlai_ThuongNT_HDTC(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string v_quyenso, string v_sobienlai, string v_tendv, string v_masothue, string m_vat)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    string aReport =  "v_bienlaithuvienphi_thuongnt_hddt.rpt";
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;
                    //coalesce(k.ten,'TIỀN THUỐC')
                    sql = "select a.id, '" + v_quyenso + "' as quyenso,'" + v_sobienlai + "' as sobienlai, bb.sohieu, ds.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,d.namsinh as ngaysinh,  case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt,";
                    sql += "case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp,";
                    sql += "coalesce(j.ten,'TIỀN THUỐC') as tenloaivp,k.ten  as tennhomvp, i.stt as sttvp, j.stt as sttloaivp,  k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,giamua, b.soluong*b.dongia as sotien, ";
                    sql += "a.bhyt as bhtra, a.mien, a.thieu,a.mien as tongmien,  b.madoituong, m.hoten as nguoithu,0 as hoantra,ds.chandoan as ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong";
                    sql += ", i.gia_bh, i.gia_dv, i.gia_th, a.tamung ";
                    sql += ", i.hangsx, i.nuocsx ";
                    sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                    sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                    sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";//binh thay a.makp thanh b.makp
                    sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join (select id, stt, ten, dvt, id_loai, gia_bh, " + sfield_gia + " as gia_dv, gia_th, null as hangsx, null as nuocsx from medibv.v_giavp union select a.id, 1 as stt, a.ten|| case when a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt, 0 as id_loai, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, b.ten as nuocsx, c.ten as hangsx from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id left join medibv.d_dmnuoc c on a.manuoc=c.id) i on b.mavp=i.id ";
                    sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    sql += " left join  medibv.bhyt l on ds.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong ";
                    sql += " where ds.id=" + v_id + "";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "", adiachibv = "", adiachi = "";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    decimal atiendichvu = 0;
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;

                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }

                    foreach (DataRow r in adst.Tables[0].Select("giamua>0"))
                    {
                        decimal adongia = 0, agiamua = 0, atong = 0;
                        adongia = decimal.Parse(r["dongia"].ToString());
                        agiamua = decimal.Parse(r["giamua"].ToString());
                        atong = adongia - agiamua;
                        atiendichvu += atong;
                    }

                    if (bInchuky)
                    {
                        try
                        {
                            adst.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                            }

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                foreach (DataRow r in adst.Tables[0].Rows)
                                    r["image"] = image;
                        }
                        catch
                        {

                        }
                    }
                    adst.WriteXml("..\\..\\Datareport\\v_bienlaithuvienphi_thuongnt.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                    cMain.DataDefinition.FormulaFields["atiendichvu"].Text = "'" + atiendichvu + "'";
                    cMain.DataDefinition.FormulaFields["m_tendv"].Text = "'" + v_tendv + "'";
                    cMain.DataDefinition.FormulaFields["m_masothue"].Text = "'" + v_masothue + "'";
                    cMain.DataDefinition.FormulaFields["m_vat"].Text = "" + m_vat + "";
                    cMain.SetDataSource(adst);

                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        

        public void f_Print_BienlaiNT(bool v_dir,DataSet adst, string alydo)
        {
            try
            {
                string aReport = m_report_ravien;
                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "", athua = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athua = adst.Tables[0].Rows[0]["thua"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");
                athua = decimal.Parse(athua.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT trả:") + " " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (athua != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thừa:") + " " + athua;
                }
                if (anopthem != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tiền thu BN nợ lần trước:") + " " + anopthem;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }

                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thu thêm:") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }

                ads.WriteXml("..\\..\\Datareport\\v_bienlaithuvienphint.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                //m_v.execute_data_mmyy(v_mmyy, "update medibv.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void f_Print_BienlaiNT(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string v_dotthanhtoan)
        {
            try
            {
                string aReport = m_report_ravien;
                DataSet adst;
                bool sys_ttrv_thuoc_vienphi = m_v.sys_ttrv_thuoc_vienphi;
                string sql = "", thuoc = "", lydo = "";
                if (v_mmyy == "") v_mmyy = m_v.s_curmmyy;                
                if (sys_ttrv_thuoc_vienphi)
                {
                    foreach (DataRow r in m_v.get_data("select distinct nhomvp from medibv.d_dmnhom where nhom=" + m_v.nhom_duoc).Tables[0].Rows)
                        thuoc += r["nhomvp"].ToString() + ",";                    
                    if (thuoc != "")
                    {
                        thuoc = "," + thuoc;
                        decimal th=0, vp = 0;
                        sql = "select d.id_nhom as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id ";
                        sql += "where a.id=" + v_id + " group by d.id_nhom";
                        sql += " union all ";
                        sql += "select d.nhomvp as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.d_dmbd c on b.mavp=c.id inner join medibv.d_dmnhom d on c.manhom=d.id ";
                        sql += "where a.id=" + v_id + " group by d.nhomvp";
                        foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                        {
                            if (r["sotien"].ToString() != "")
                            {
                                if (thuoc.IndexOf(","+r["nhom"].ToString() + ",") != -1) th += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                                else vp += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                        if (th != 0) lydo += "Thuốc :" + th.ToString("###,###,###,###.00");
                        if (vp != 0) lydo = lydo+((lydo!="")?"; ":"")+"Viện phí :" + vp.ToString("###,###,###,###.00");
                    }
                }                
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp,";
                sql+="(a.sotien-a.bhyt-a.mien-a.thieu+a.nopthem) as sotien , a.tamung, a.mien, a.thieu, a.bhyt , a.nopthem,";
                sql+="to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,";
                sql+="f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, ";
                sql+="i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin,a.thua ";
                sql+=" from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id ";
                sql+="left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn ";
                sql+="left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt ";
                sql+="left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                sql+="left join medibv.v_quyenso i on a.quyenso=i.id ";
                sql+="left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id ";
                sql+="left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";        
                //
                sql = " select a.id, a.mabn, b.sobienlai, b.sotien as tongcp , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,k.soluong, k.mavp as id_vp, k.sotien-k.bhyttra sotienct, -1 as id_loai, null as tenloaivp, m.nhomvp as id_nhom, l.ten tennhomvp, k.madoituong ";
                sql += " ,(b.sotien-b.bhyt-b.mien-b.thieu+b.nopthem) as sotien, b.tamung, b.mien, b.thieu, b.bhyt , b.nopthem, b.thua, p.ten as lydomien, b.lanin+1 as lanin ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.d_dmnhom m on dm.manhom=m.id inner join medibv.v_nhomvp l on m.nhomvp=l.ma left join medibvmmyy.v_miennoitru o on b.id=o.id left join medibv.v_lydomien p on o.lydo=p.id ";
                sql += " where a.id=" + v_id;
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as tongcp , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,k.soluong, k.mavp as id_vp,k.sotien-k.bhyttra sotienct, dm.id_loai as id_loai, n.ten as tenloaivp, n.id_nhom as id_nhom, l.ten tennhomvp, k.madoituong   ";
                sql += " ,(b.sotien-b.bhyt-b.mien-b.thieu+b.nopthem) as sotien, b.tamung, b.mien, b.thieu, b.bhyt , b.nopthem, b.thua, p.ten as lydomien, b.lanin+1 as lanin ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.v_loaivp n on dm.id_loai=n.id inner join medibv.v_nhomvp l on n.id_nhom=l.ma left join medibvmmyy.v_miennoitru o on b.id=o.id left join medibv.v_lydomien p on o.lydo=p.id  ";
                sql += " where a.id=" + v_id;
                //
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "", athua = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

                if (m_report_ravien_ct == "1")
                    alydo = get_Lydo_ct(v_id, v_mmyy);

                if ((m_report_ravien_ct != "1")||(alydo=="-1"))
                    alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện :"+lydo+((lydo!="")?".":""));

                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athua = adst.Tables[0].Rows[0]["thua"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");
                athua = decimal.Parse(athua.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:")+" " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
                }
                if (athua != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thừa:") + " " + athua;
                }
                if (anopthem != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tiền thu BN nợ lần trước:") + " " + anopthem;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }
              
                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " "+lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thu thêm:") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                if (m_v.ttrv_Thanhtoannhieudot_trongkhoa(m_userid) && v_dotthanhtoan != "") alydo = alydo + " [" + v_dotthanhtoan + "]";
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    r["id"] = v_id;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                //
                foreach (DataRow r2 in adst.Tables[0].Rows)
                {
                    DataRow r1 = ads.Tables[1].NewRow();
                    r1["mavp"] = r2["id_vp"];
                    r1["madoituong"] = r2["madoituong"];
                    r1["id_loaivp"] = r2["id_loai"];
                    r1["id_nhomvp"] = r2["id_nhom"];
                    r1["loaivp"] = r2["tenloaivp"];
                    r1["nhomvp"] = r2["tennhomvp"];
                    r1["sotien"] = r2["sotienct"];
                    r1["vat"] = 0;// vat;
                    r1["id"] = v_id;
                    ads.Tables[1].Rows.Add(r1);
                }
                //
                ads.WriteXml("..\\..\\Datareport\\v_bienlaithuvienphint.xml", XmlWriteMode.WriteSchema);
                

                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_BienlaiNT(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string v_dotthanhtoan, bool v_bdichvu)
        {
            try
            {
                string aReport = m_report_ravien;
                string aReport1 = aReport;
                if (v_bdichvu)
                    aReport1 = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                DataSet adst;
                bool sys_ttrv_thuoc_vienphi = m_v.sys_ttrv_thuoc_vienphi;
                string sql = "", thuoc = "", lydo = "";
                if (v_mmyy == "") v_mmyy = m_v.s_curmmyy;
                if (sys_ttrv_thuoc_vienphi)
                {
                    foreach (DataRow r in m_v.get_data("select distinct nhomvp from medibv.d_dmnhom where nhom=" + m_v.nhom_duoc).Tables[0].Rows)
                        thuoc += r["nhomvp"].ToString() + ",";
                    if (thuoc != "")
                    {
                        thuoc = "," + thuoc;
                        decimal th = 0, vp = 0;
                        sql = "select d.id_nhom as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id ";
                        sql += "where a.id=" + v_id + " group by d.id_nhom";
                        sql += " union all ";
                        sql += "select d.nhomvp as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.d_dmbd c on b.mavp=c.id inner join medibv.d_dmnhom d on c.manhom=d.id ";
                        sql += "where a.id=" + v_id + " group by d.nhomvp";
                        foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                        {
                            if (r["sotien"].ToString() != "")
                            {
                                if (thuoc.IndexOf("," + r["nhom"].ToString() + ",") != -1) th += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                                else vp += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                        if (th != 0) lydo += "Thuốc :" + th.ToString("###,###,###,###.00");
                        if (vp != 0) lydo = lydo + ((lydo != "") ? "; " : "") + "Viện phí :" + vp.ToString("###,###,###,###.00");
                    }
                }
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp,";
                sql += "(a.sotien-a.bhyt-a.mien-a.thieu+a.nopthem) as sotien , a.tamung, a.mien, a.thieu, a.bhyt , a.nopthem,";
                sql += "to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,";
                sql += "f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, ";
                sql += "i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin,a.thua ";
                sql += " from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id ";
                sql += "left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn ";
                sql += "left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt ";
                sql += "left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                sql += "left join medibv.v_quyenso i on a.quyenso=i.id ";
                sql += "left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id ";
                sql += "left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
                //
                sql = " select a.id, a.mabn, b.sobienlai, b.sotien as tongcp , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,k.soluong, k.mavp as id_vp, k.sotien-k.bhyttra sotienct, -1 as id_loai, null as tenloaivp, m.nhomvp as id_nhom, l.ten tennhomvp, k.madoituong ";
                sql += " ,(b.sotien-b.bhyt-b.mien-b.thieu+b.nopthem) as sotien, b.tamung, b.mien, b.thieu, b.bhyt , b.nopthem, b.thua, p.ten as lydomien, b.lanin+1 as lanin ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.d_dmnhom m on dm.manhom=m.id inner join medibv.v_nhomvp l on m.nhomvp=l.ma left join medibvmmyy.v_miennoitru o on b.id=o.id left join medibv.v_lydomien p on o.lydo=p.id ";
                sql += " where a.id=" + v_id;
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as tongcp , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,k.soluong, k.mavp as id_vp,k.sotien-k.bhyttra sotienct, dm.id_loai as id_loai, n.ten as tenloaivp, n.id_nhom as id_nhom, l.ten tennhomvp, k.madoituong   ";
                sql += " ,(b.sotien-b.bhyt-b.mien-b.thieu+b.nopthem) as sotien, b.tamung, b.mien, b.thieu, b.bhyt , b.nopthem, b.thua, p.ten as lydomien, b.lanin+1 as lanin ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.v_loaivp n on dm.id_loai=n.id inner join medibv.v_nhomvp l on n.id_nhom=l.ma left join medibvmmyy.v_miennoitru o on b.id=o.id left join medibv.v_lydomien p on o.lydo=p.id  ";
                sql += " where a.id=" + v_id;
                //
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "", athua = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

                if (m_report_ravien_ct == "1")
                    alydo = get_Lydo_ct(v_id, v_mmyy);

                if ((m_report_ravien_ct != "1") || (alydo == "-1"))
                    alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện :" + lydo + ((lydo != "") ? "." : ""));

                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athua = adst.Tables[0].Rows[0]["thua"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");
                athua = decimal.Parse(athua.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT trả:") + " " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (athua != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thừa:") + " " + athua;
                }
                if (anopthem != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tiền thu BN nợ lần trước:") + " " + anopthem;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }

                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thu thêm:") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                if (m_v.ttrv_Thanhtoannhieudot_trongkhoa(m_userid) && v_dotthanhtoan != "") alydo = alydo + " [" + v_dotthanhtoan + "]";
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    r["id"] = v_id;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                //
                foreach (DataRow r2 in adst.Tables[0].Rows)
                {
                    DataRow r1 = ads.Tables[1].NewRow();
                    r1["mavp"] = r2["id_vp"];
                    r1["madoituong"] = r2["madoituong"];
                    r1["id_loaivp"] = r2["id_loai"];
                    r1["id_nhomvp"] = r2["id_nhom"];
                    r1["loaivp"] = r2["tenloaivp"];
                    r1["nhomvp"] = r2["tennhomvp"];
                    r1["sotien"] = r2["sotienct"];
                    r1["vat"] = 0;// vat;
                    r1["id"] = v_id;
                    ads.Tables[1].Rows.Add(r1);
                }
                //
                ads.WriteXml("..\\..\\Datareport\\v_bienlaithuvienphint.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport1, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú (") + aReport1 + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_BienlaiNT(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string v_dotthanhtoan, string s_sothe, int traituyen)
        {
            try
            {
                string aReport = m_report_ravien;
                DataSet adst;
                bool sys_ttrv_thuoc_vienphi = m_v.sys_ttrv_thuoc_vienphi;
                string sql = "", thuoc = "", lydo = "", lydo1 = "";
                int imaphu = (s_sothe != "") ? m_v.get_maphu(s_sothe) : -1;
                if (imaphu == 1) lydo1 = " BN trả 20% BHYT ";
                else if (imaphu == 2) lydo1 = " BN trả 5% BHYT ";
                else if (imaphu == 0) lydo1 = " BHYT 100% ";
                else lydo1= "";
                if (traituyen != 0) lydo = "BHYT trái tuyến, BN trả " + m_v.iTraituyen_bhyt + "%";
                if (v_mmyy == "") v_mmyy = m_v.s_curmmyy;
                if (sys_ttrv_thuoc_vienphi)
                {
                    foreach (DataRow r in m_v.get_data("select distinct nhomvp from medibv.d_dmnhom where nhom=" + m_v.nhom_duoc).Tables[0].Rows)
                        thuoc += r["nhomvp"].ToString() + ",";
                    if (thuoc != "")
                    {
                        thuoc = "," + thuoc;
                        decimal th = 0, vp = 0;
                        sql = "select d.id_nhom as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id ";
                        sql += "where a.id=" + v_id + " group by d.id_nhom";
                        sql += " union all ";
                        sql += "select d.nhomvp as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.d_dmbd c on b.mavp=c.id inner join medibv.d_dmnhom d on c.manhom=d.id ";
                        sql += "where a.id=" + v_id + " group by d.nhomvp";
                        foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                        {
                            if (r["sotien"].ToString() != "")
                            {
                                if (thuoc.IndexOf("," + r["nhom"].ToString() + ",") != -1) th += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                                else vp += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                        if (th != 0) lydo += "Thuốc :" + th.ToString("###,###,###,###.00");
                        if (vp != 0) lydo = lydo + ((lydo != "") ? "; " : "") + "Viện phí :" + vp.ToString("###,###,###,###.00");
                    }
                }
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp,";
                sql += "(a.sotien-a.bhyt-a.mien-a.thieu+a.nopthem) as sotien , a.tamung, a.mien, a.thieu, a.bhyt , a.nopthem,";
                sql += "to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,";
                sql += "f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, ";
                sql += "i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin,a.thua ";
                sql += " from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id ";
                sql += "left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn ";
                sql += "left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt ";
                sql += "left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                sql += "left join medibv.v_quyenso i on a.quyenso=i.id ";
                sql += "left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id ";
                sql += "left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "", athua = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

                if (adst.Tables[0].Rows[0]["bhyt"].ToString() == "" || decimal.Parse(adst.Tables[0].Rows[0]["bhyt"].ToString()) == 0) lydo1 = "";
                lydo = lydo1 + lydo;
                if (m_report_ravien_ct == "1")
                    alydo = get_Lydo_ct(v_id, v_mmyy);
                
                if ((m_report_ravien_ct != "1") || (alydo == "-1"))
                    alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện :" + lydo + ((lydo != "") ? "." : ""));

                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athua = adst.Tables[0].Rows[0]["thua"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.sys_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");
                athua = decimal.Parse(athua.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT trả:") + " " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (athua != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thừa:") + " " + athua;
                }
                if (anopthem != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tiền thu BN nợ lần trước:") + " " + anopthem;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }

                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thu thêm:") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                if (m_v.ttrv_Thanhtoannhieudot_trongkhoa(m_userid) && v_dotthanhtoan != "") alydo = alydo + " [" + v_dotthanhtoan + "]";
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }

                ads.WriteXml("..\\..\\Datareport\\v_bienlaithuvienphint.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_BienlaiNT(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string v_dotthanhtoan, string s_sothe, int traituyen, bool v_bdichvu)
        {
            try
            {
                string aReport = m_report_ravien;
                string aReport1 = aReport;
                if (v_bdichvu)
                    aReport1 = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                DataSet adst;
                bool sys_ttrv_thuoc_vienphi = m_v.sys_ttrv_thuoc_vienphi;
                string sql = "", thuoc = "", lydo = "", lydo1 = "";
                int imaphu = (s_sothe != "") ? m_v.get_maphu(s_sothe) : -1;
                if (imaphu == 1) lydo1 = " BN trả 20% BHYT ";
                else if (imaphu == 2) lydo1 = " BN trả 5% BHYT ";
                else if (imaphu == 0) lydo1 = " BHYT 100% ";
                else lydo1 = "";
                if (traituyen != 0) lydo = "BHYT trái tuyến, BN trả " + m_v.iTraituyen_bhyt + "%";
                if (v_mmyy == "") v_mmyy = m_v.s_curmmyy;
                if (sys_ttrv_thuoc_vienphi)
                {
                    foreach (DataRow r in m_v.get_data("select distinct nhomvp from medibv.d_dmnhom where nhom=" + m_v.nhom_duoc).Tables[0].Rows)
                        thuoc += r["nhomvp"].ToString() + ",";
                    if (thuoc != "")
                    {
                        thuoc = "," + thuoc;
                        decimal th = 0, vp = 0;
                        sql = "select d.id_nhom as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id ";
                        sql += "where a.id=" + v_id + " group by d.id_nhom";
                        sql += " union all ";
                        sql += "select d.nhomvp as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.d_dmbd c on b.mavp=c.id inner join medibv.d_dmnhom d on c.manhom=d.id ";
                        sql += "where a.id=" + v_id + " group by d.nhomvp";
                        foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                        {
                            if (r["sotien"].ToString() != "")
                            {
                                if (thuoc.IndexOf("," + r["nhom"].ToString() + ",") != -1) th += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                                else vp += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                        if (th != 0) lydo += "Thuốc :" + th.ToString("###,###,###,###.00");
                        if (vp != 0) lydo = lydo + ((lydo != "") ? "; " : "") + "Viện phí :" + vp.ToString("###,###,###,###.00");
                    }
                }
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp,";
                sql += "(a.sotien-a.bhyt-a.mien-a.thieu+a.nopthem) as sotien , a.tamung, a.mien, a.thieu, a.bhyt , a.nopthem,";
                sql += "to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,";
                sql += "f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, ";
                sql += "i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin,a.thua ";
                sql += " from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id ";
                sql += "left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn ";
                sql += "left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt ";
                sql += "left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                sql += "left join medibv.v_quyenso i on a.quyenso=i.id ";
                sql += "left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id ";
                sql += "left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "", athua = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

                if (adst.Tables[0].Rows[0]["bhyt"].ToString() == "" || decimal.Parse(adst.Tables[0].Rows[0]["bhyt"].ToString()) == 0) lydo1 = "";
                lydo = lydo1 + lydo;
                if (m_report_ravien_ct == "1")
                    alydo = get_Lydo_ct(v_id, v_mmyy);

                if ((m_report_ravien_ct != "1") || (alydo == "-1"))
                    alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện :" + lydo + ((lydo != "") ? "." : ""));

                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athua = adst.Tables[0].Rows[0]["thua"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.sys_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");
                athua = decimal.Parse(athua.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT trả:") + " " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (athua != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thừa:") + " " + athua;
                }
                if (anopthem != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tiền thu BN nợ lần trước:") + " " + anopthem;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }

                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thu thêm:") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                if (m_v.ttrv_Thanhtoannhieudot_trongkhoa(m_userid) && v_dotthanhtoan != "") alydo = alydo + " [" + v_dotthanhtoan + "]";

                
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }

                // gam 26-05-2011 hoa don chi tiet

                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());

                sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, ds.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,d.namsinh as ngaysinh,  case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt,";
                sql += "case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp,";
                sql += "j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp,  k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,giamua, b.soluong*b.dongia as sotien, ";
                sql += "a.bhyt as bhtra, a.mien, a.thieu,a.mien as tongmien,  b.madoituong, m.hoten as nguoithu,0 as hoantra,ds.chandoan as ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong";
                sql += ", i.gia_bh, i.gia_dv, i.gia_th, a.tamung ";
                sql += ", i.hangsx, i.nuocsx ";
                sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";
                sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join (select id, stt, ten, dvt, id_loai, gia_bh, " + sfield_gia + " as gia_dv, gia_th, null as hangsx, null as nuocsx from medibv.v_giavp union select a.id, 1 as stt, a.ten|| case when a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt, 0 as id_loai, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, b.ten as nuocsx, c.ten as hangsx from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id left join medibv.d_dmnuoc c on a.manuoc=c.id) i on b.mavp=i.id ";
                sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                sql += " left join  medibv.bhyt l on ds.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong ";
                sql += " where ds.id=" + v_id + "";

                adst.Clear();
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                foreach (DataRow rct in adst.Tables[0].Rows)
                {
                    DataRow r1 = ads.Tables[1].NewRow();
                    r1["madoituong"] = rct["madoituong"].ToString();
                    r1["mavp"] = rct["id_vp"].ToString();
                    r1["tenvp"] = rct["tenvp"].ToString();
                    r1["id_loaivp"] = rct["id_loai"].ToString();
                    r1["id_nhomvp"] = rct["id_nhom"].ToString();
                    r1["nhomvp"] = 0;
                    r1["sotien"] = rct["sotien"].ToString();
                    r1["id"] = rct["id"].ToString();
                    r1["gia_dv"] = rct["gia_dv"].ToString();
                    r1["gia_bh"] = rct["gia_bh"].ToString();
                    r1["vat"] = 0;
                    ads.Tables[1].Rows.Add(r1);
                }
                ads.WriteXml("..\\..\\Datareport\\v_bienlaithuvienphint.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport1, OpenReportMethod.OpenReportByTempCopy);
                //subreprot
                foreach (CrystalDecisions.CrystalReports.Engine.Section section in cMain.ReportDefinition.Sections)
                {
                    // In each section we need to loop through all the reporting objects
                    foreach (CrystalDecisions.CrystalReports.Engine.ReportObject reportObject in section.ReportObjects)
                    {
                        if (reportObject.Kind == ReportObjectKind.SubreportObject)
                        {
                            SubreportObject subReport = (SubreportObject)reportObject;
                            ReportDocument subDocument = subReport.OpenSubreport(subReport.SubreportName);
                            subDocument.SetDataSource(ads);
                        }
                    }
                }
                // end subreprot
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú (") + aReport1 + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_BienlaiNT_Thuong(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            try
            {
                string aReport = m_report_ravien_thuong;
                DataSet adst;
                string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp, (a.sotien-a.bhyt-a.mien-a.thieu) as sotien , a.tamung, a.mien, a.thieu, a.bhyt , a.nopthem, to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();
                //alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện");
                //Sua ly do lai lay theo chi tiet.
                if (m_report_ravien_thuong_ct == "1")
                    alydo = get_Lydo_ct(v_id, v_mmyy);
                if ((m_report_ravien_thuong_ct != "1") || (alydo == "-1"))
                    alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện");
                //End.
                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:")+" " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }
                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " "+lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Thu thêm:")+" " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint_thuong.xml",XmlWriteMode.WriteSchema);
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,  ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_BienlaiNT_Thuong(bool v_dir, string v_id, string v_mmyy, string v_loaibl, bool v_bdichvu)
        {
            try
            {
                string aReport = m_report_ravien_thuong;
                string aReport1 = aReport;
                if (v_bdichvu)
                    aReport1 = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                DataSet adst;
                string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp, (a.sotien-a.bhyt-a.mien-a.thieu) as sotien , a.tamung, a.mien, a.thieu, a.bhyt , a.nopthem, to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();
                //alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện");
                //Sua ly do lai lay theo chi tiet.
                if (m_report_ravien_thuong_ct == "1")
                    alydo = get_Lydo_ct(v_id, v_mmyy);
                if ((m_report_ravien_thuong_ct != "1") || (alydo == "-1"))
                    alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện");
                //End.
                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT trả:") + " " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }
                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thu thêm:") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }

                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint_thuong.xml", XmlWriteMode.WriteSchema);
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport1, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú (") + aReport1 + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_BienlaiNT_Thuchi(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            try
            {
                string aReport = m_report_ravien_chi;
                DataSet adst;
                string sql = "";
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp, (a.sotien-a.bhyt-a.mien-a.thieu) as sotien , a.tamung, a.mien, a.thieu, a.bhyt ,a.nopthem, to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
                if (v_mmyy == "")
                {
                    v_mmyy=m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();
                //alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện");
                //Sua ly do lai lay theo chi tiet.
                if (m_report_ravien_chi_ct == "1")
                    alydo = get_Lydo_ct(v_id, v_mmyy);
                if ((m_report_ravien_chi_ct != "1") || (alydo == "-1"))
                    alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện");
                //End.
                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                //MessageBox.Show(atamung.Replace(",",""));
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:")+" " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }
                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " "+lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Thu thêm:")+" " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    ads.Tables[0].Rows.Add(r);
                }
                ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint_thuchi.xml",XmlWriteMode.WriteSchema);
                //return;

                 cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //son web them void in BHYT ngoai tru.
        public void f_Print_BienlaiNgTru_Thuchi(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            try
            {
                string aReport = m_report_ravien_chi;
                DataSet adst;
                string sql = "";
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp, (a.sotien-a.bhyt-a.mien-a.thieu) as sotien , a.tamung, a.mien, a.thieu, a.bhyt ,a.nopthem, to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
              //  sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp, (a.sotien-a.bhyt-a.mien-a.thieu) as sotien , a.tamung, a.mien, a.thieu, a.bhyt ,a.nopthem, to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();
                //alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện");
                //Sua ly do lai lay theo chi tiet.
                if (m_report_ravien_chi_ct == "1")
                    alydo = get_Lydo_ct(v_id, v_mmyy);
                if ((m_report_ravien_chi_ct != "1") || (alydo == "-1"))
                    alydo = lan.Change_language_MessageText("Thanh toán viện phí ra viện");
                //End.
                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["tongcp"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyt"].ToString();
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
                athieu = adst.Tables[0].Rows[0]["thieu"].ToString();
                anopthem = adst.Tables[0].Rows[0]["nopthem"].ToString();
                alydomien1 = adst.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "") atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                //MessageBox.Show(atamung.Replace(",",""));
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT trả:") + " " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }
          
                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt);// -decimal.Parse(amien) - decimal.Parse(athieu);
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thu thêm:") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNT();
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    ads.Tables[0].Rows.Add(r);
                }
                 ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint_chi.xml",XmlWriteMode.WriteSchema);
                //return;

                 cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);                

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí nội trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //End.

        private DataSet f_Cursor_BienlaiNGT()
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
                ads.Tables[0].Columns.Add("sothe");
                ads.Tables[0].Columns.Add("id", typeof(decimal));
                //
                ads.Tables.Add("Chitiet");
                ads.Tables[1].Columns.Add("madoituong", typeof(int));
                ads.Tables[1].Columns.Add("mavp", typeof(int));
                ads.Tables[1].Columns.Add("tenvp");
                ads.Tables[1].Columns.Add("id_loaivp", typeof(int));
                ads.Tables[1].Columns.Add("loaivp");
                ads.Tables[1].Columns.Add("id_nhomvp", typeof(int));
                ads.Tables[1].Columns.Add("nhomvp");
                ads.Tables[1].Columns.Add("sotien", typeof(decimal));
                ads.Tables[1].Columns.Add("vat", typeof(decimal));
                ads.Tables[1].Columns.Add("id", typeof(decimal));
                ads.Tables[1].Columns.Add("gia_dv", typeof(decimal));
                ads.Tables[1].Columns.Add("gia_bh", typeof(decimal));
                ads.Tables[1].Columns.Add("hangsx");
                ads.Tables[1].Columns.Add("nuocsx");
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public void f_Print_BienlaiNGT(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string v_mabn, string v_ngaykam)
        {
            try
            {
                string aReport = m_report_bhyt;
                DataSet adst;
                string sql = "";

                #region 
                //sql = "select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, " +
                //    " d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, " +
                //    " to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung " +
                //    " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id left join " +
                //    " medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join " +
                //    " medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join " +
                //    " medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa " +
                //    " left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id " +
                //    " where a.id=" + v_id;

                //sql = "select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, " +
                //   " d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, " +
                //   " to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung " +
                //   " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id left join " +
                //   " medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join " +
                //   " medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join " +
                //   " medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa " +
                //   " left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id " +
                //   " where a.id=" + v_id;
                #endregion

                sql = " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,k.soluong  ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id  ";
                sql += " where a.id=" + v_id;
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,k.soluong  ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id  ";
                sql += " where a.id=" + v_id;
                

                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }              

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

               // alydo = lan.Change_language_MessageText("Thanh toán viện phí BHYT Ngoại trú");
                foreach (DataRow r in adst.Tables[0].Rows)
                {
                    decimal s = decimal.Parse(r["soluong"].ToString());
                    alydo += r["ten"].ToString() + "(" + s.ToString("###,###,##0") + ")" + ",";
                }
                asotien = adst.Tables[0].Rows[0]["bntra"].ToString();
                atongcp = adst.Tables[0].Rows[0]["sotien"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyttra"].ToString();
                amien = "0";
                athieu = "0";
                anopthem = "0";
                alydomien1 = "";
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = (decimal.Parse(atongcp.ToString())-decimal.Parse(atamung.ToString())-decimal.Parse(abhyt.ToString())).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "" || atmp.IndexOf("-") != -1) atmp = "0";
                
                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                //MessageBox.Show(atamung.Replace(",",""));
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:")+" " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- BHYT chi trả :")+" " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }
                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);
               
                asotien = ahoan.ToString("###,###,##0.###");
                if (asotien.IndexOf("-") != -1) 
                {
                    asotien = "0";
                    achutien = lan.Change_language_MessageText("Không đồng");
                }
                if (ahoan < 0)
                {
                    atmp = atmp + "\n"+lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " "+lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BN cùng chi trả :") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNGT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                
                ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphi_BHYT.xml",XmlWriteMode.WriteSchema);
                

                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                
                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí BHYT Ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void f_Print_BienlaiNGT(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string v_mabn, string v_ngaykam,string s_sothe, int itraituyen, decimal d_tongtien)
        {
            try
            {
                string aReport = m_report_bhyt;
                DataSet adst;
                string sql = "", lydo = "", lydo1 = "",lydo4 = "";
                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                string thuoc = "";
                #region
                //sql = "select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, " +
                //    " d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, " +
                //    " to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung " +
                //    " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id left join " +
                //    " medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join " +
                //    " medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join " +
                //    " medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa " +
                //    " left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id " +
                //    " where a.id=" + v_id;

                //sql = "select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, " +
                //   " d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, " +
                //   " to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung " +
                //   " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id left join " +
                //   " medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join " +
                //   " medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join " +
                //   " medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa " +
                //   " left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id " +
                //   " where a.id=" + v_id;
                #endregion
                bool sys_ttrv_thuoc_vienphi = m_v.sys_ttrv_thuoc_vienphi;
                int imaphu = m_v.get_maphu_ngtru(s_sothe,d_tongtien,0);
                if (imaphu == 1) lydo1 = " BN trả 20% BHYT ";
                else if (imaphu == 2) lydo1 = " BN trả 5% BHYT ";
                else if (imaphu == 0) lydo1 = " BHYT 100% ";
                //gam-21/02/2011-lấy tỉ lệ % bệnh nhân cùng chi trả theo mã thẻ
                int tile = m_v.get_maphu_ngtru(s_sothe,1000000,0);

                if (tile == 1)
                {
                    lydo4 = "BN cùng chi trả 20% BHYT: ";
                }
                else if(tile == 2)
                {
                    lydo4 = "BN cùng chi trả 5% BHYT: ";
                }
                else if (tile == 0)
                {
                    lydo4 = "BHYT chi trả 100%: ";
                }
                //gam
                if (itraituyen != 0)
                {
                    int i_bntra = 100 - m_v.iTraituyen_bhyt;
                    lydo4 = "BHYT trái tuyến, BN trả " + i_bntra + "% ";// gam 19-04-2011
                }
                if (v_mmyy == "") v_mmyy = m_v.s_curmmyy;
                if (sys_ttrv_thuoc_vienphi)
                {
                    foreach (DataRow r in m_v.get_data("select distinct nhomvp from medibv.d_dmnhom where nhom=" + m_v.nhom_duoc).Tables[0].Rows)
                        thuoc += r["nhomvp"].ToString() + ",";
                    if (thuoc != "")
                    {
                        thuoc = "," + thuoc;
                        decimal th = 0, vp = 0;
                        sql = "select d.id_nhom as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id ";
                        sql += "where a.id=" + v_id + " group by d.id_nhom";
                        sql += " union all ";
                        sql += "select d.nhomvp as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.d_dmbd c on b.mavp=c.id inner join medibv.d_dmnhom d on c.manhom=d.id ";
                        sql += "where a.id=" + v_id + " group by d.nhomvp";
                        foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                        {
                            if (r["sotien"].ToString() != "")
                            {
                                if (thuoc.IndexOf("," + r["nhom"].ToString() + ",") != -1) th += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                                else vp += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                        if (th != 0) lydo += "Thuốc :" + th.ToString("###,###,###,###.00");
                        if (vp != 0) lydo = lydo + ((lydo != "") ? "; " : "") + "Viện phí :" + vp.ToString("###,###,###,###.00");
                    }
                }
                sql = " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) as soluong, k.mavp as id_vp, sum(k.sotien-k.bhyttra) sotienct, -1 as id_loai, null as tenloaivp, m.nhomvp as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm.giaban as gia_dv, hsx.ten as hangsx, nsx.ten as nuocsx,b.lanin ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.d_dmnhom m on dm.manhom=m.id inner join medibv.v_nhomvp l on m.nhomvp=l.ma left join medibv.d_dmhang hsx on dm.mahang=hsx.id left join medibv.d_dmnuoc nsx on dm.manuoc=nsx.id ";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt, b.nopthem , to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, g.tenquan,h.tenpxa, to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu, tamung, dm.ten, k.soluong, k.mavp, m.nhomvp, l.ten, k.madoituong, dm.gia_bh, dm.giaban, hsx.ten, nsx.ten,b.lanin ";
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) soluong, k.mavp as id_vp, sum(k.sotien-k.bhyttra) sotienct, dm.id_loai as id_loai, n.ten as tenloaivp, n.id_nhom as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm." + sfield_gia + " as gia_dv , null as hangsx, null as nuocsx,b.lanin  ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.v_loaivp n on dm.id_loai=n.id inner join medibv.v_nhomvp l on n.id_nhom=l.ma ";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt, b.nopthem, to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu,tamung,dm.ten, k.mavp, dm.id_loai, n.ten, n.id_nhom, l.ten, k.madoituong, dm.gia_bh, dm." + sfield_gia+",b.lanin";

                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
                // gam them field bn dong chi tra + bn chi trả (thu chenh lech va doi tuong thu)+ tổng chi phí được hưởng bhyt
                LibMedi.AccessData mdi = new LibMedi.AccessData();
                int i_nhomkho=mdi.nhom_duoc;
                decimal dtien = 0;
                LibDuoc.AccessData mdd = new LibDuoc.AccessData();
                if (s_sothe.Length == 13)
                {
                    dtien = mdd.ma13_st(i_nhomkho);
                }
                else 
                {
                    dtien = mdd.ma16_st(i_nhomkho);
                }

                adst.Tables[0].Columns.Add("bndongchitra");
                adst.Tables[0].Columns.Add("bntuchitra");
                adst.Tables[0].Columns.Add("tongchiphihuongbhyt");
                decimal sotienbhyt = 0;
                foreach ( DataRow dr in adst.Tables[0].Rows )
                {
                    if (dr["madoituong"].ToString() == "1")
                    {
                        sotienbhyt += decimal.Parse(dr["soluong"].ToString()) * decimal.Parse(dr["gia_dv"].ToString());
                    }

                }
                DataRow ar = adst.Tables[0].Rows[0];
                    if (itraituyen == 0)
                    {
                        if (sotienbhyt <= dtien)
                        {
                            ar["tongchiphihuongbhyt"] = decimal.Parse(ar["bhyttra"].ToString());
                            ar["bndongchitra"] = 0;
                        }
                        else if (tile == 2 && sotienbhyt > dtien)
                        {
                            ar["tongchiphihuongbhyt"] = (decimal.Parse(ar["bhyttra"].ToString()) * 100) / 95;
                            ar["bndongchitra"] = (decimal.Parse(ar["tongchiphihuongbhyt"].ToString()) * 5) / 100;
                        }
                        else if (tile == 1 && sotienbhyt > dtien)
                        {
                            ar["tongchiphihuongbhyt"] = (decimal.Parse(ar["bhyttra"].ToString()) * 100) / 80;
                            ar["bndongchitra"] = (decimal.Parse(ar["tongchiphihuongbhyt"].ToString()) * 20) / 100;
                        }
                       
                        else if (tile == 0)
                        {
                            ar["tongchiphihuongbhyt"] = ar["bhyttra"].ToString();
                            ar["bndongchitra"] = 0;
                        }
                    }
                    else if (itraituyen != 0)
                    {
                        ar["tongchiphihuongbhyt"] = (decimal.Parse(ar["bhyttra"].ToString()) * 100) / m_v.iTraituyen_bhyt ;
                        ar["bndongchitra"] = (decimal.Parse(ar["tongchiphihuongbhyt"].ToString()) * (100 - m_v.iTraituyen_bhyt)) / 100;
                    }
                    ar["bntuchitra"] = decimal.Parse(ar["sotien"].ToString()) - decimal.Parse(ar["tongchiphihuongbhyt"].ToString());
                
                // gam
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

                abhyt = adst.Tables[0].Rows[0]["bhyttra"].ToString();
                if (abhyt.Trim() == "" || abhyt.Trim() == "0") lydo1 = "";
                lydo = lydo1 + lydo;
                // alydo = lan.Change_language_MessageText("Thanh toán viện phí BHYT Ngoại trú");
                //
                decimal s = 0;
                string s_mavp = "";
                string s_tenvp = "";
                //
                if (sys_ttrv_thuoc_vienphi) alydo = lydo;
                else
                {                    
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        if (s_mavp != r["id_vp"].ToString())
                        {
                            if (s_tenvp != "") alydo += s_tenvp + "(" + s.ToString("###,###,##0") + ")" + ",";
                            s_tenvp = r["ten"].ToString();
                            s = decimal.Parse(r["soluong"].ToString());
                            s_mavp = r["id_vp"].ToString();
                        }
                        else
                        {
                            if (r["madoituong"].ToString() != m_v.iTunguyen.ToString())
                            {
                                s += decimal.Parse(r["soluong"].ToString());
                            }
                        }
                    }
                }
                alydo = alydo + lydo4;
                if (s_tenvp != "") alydo += s_tenvp + "(" + s.ToString("###,###,##0") + ")" + ",";
                //gam-21/02/2011-themghichu so tien bn dong chi tra + so tien bn tra + tong so tien duoc huong bhyt
                string atonghuongbhyt = decimal.Parse(adst.Tables[0].Rows[0]["tongchiphihuongbhyt"].ToString()).ToString("###,###,##0.###");
                string abndongchitra = decimal.Parse(adst.Tables[0].Rows[0]["bndongchitra"].ToString()).ToString("###,###,##0.###");
                string abntutra = decimal.Parse(adst.Tables[0].Rows[0]["bntuchitra"].ToString()).ToString("###,###,##0.###");
                //gam
                string alanin = adst.Tables[0].Rows[0]["lanin"].ToString();
                
                asotien = adst.Tables[0].Rows[0]["bntra"].ToString();
                atongcp = adst.Tables[0].Rows[0]["sotien"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyttra"].ToString();
                amien = "0";
                athieu = "0";
                anopthem = "0";
                alydomien1 = "";
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = (decimal.Parse(atongcp.ToString()) - decimal.Parse(atamung.ToString()) - decimal.Parse(abhyt.ToString())).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "" || atmp.IndexOf("-") != -1) atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                //MessageBox.Show(atamung.Replace(",",""));
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                //gam-21/02/2011 them ghi chu
                //if (atonghuongbhyt != "0")
                //{
                //    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tổng chi phí được hưởng BHYT :") + " " + atonghuongbhyt;
                //}
                
                //gam
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT chi trả :") + " " + abhyt;
                }
                
                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }
                
                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);

                asotien = ahoan.ToString("###,###,##0.###");
                if (asotien.IndexOf("-") != -1)
                {
                    asotien = "0";
                    achutien = lan.Change_language_MessageText("Không đồng");
                }
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BN cùng chi trả :") + " " + ahoan.ToString("###,###,###.###");
                //gam
                //if (abndongchitra != "0")
                //{
                //    atmp = atmp + "\n" + lan.Change_language_MessageText("- BN đồng chi trả :") + " " + abndongchitra;
                //}
                //if (abntutra != "0")
                //{
                //    atmp = atmp + "\n" + lan.Change_language_MessageText("- BN tự chi trả :") + " " + abntutra;
                //}
                //gam
                    
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNGT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                try
                {
                    ads.Tables[1].Columns.Add("lanin");
                    ads.Tables[0].Columns.Add("lanin");
                }
                catch { }
                try
                {
                    ads.Tables[1].Columns.Add("TonghuongBHYT", typeof(decimal));
                    ads.Tables[0].Columns.Add("TonghuongBHYT", typeof(decimal));
                }
                catch { }
                try
                {
                    ads.Tables[1].Columns.Add("BNdongchitra", typeof(decimal));
                    ads.Tables[0].Columns.Add("BNdongchitra", typeof(decimal));
                }
                catch { }
                try
                {
                    ads.Tables[1].Columns.Add("BNtuchitra", typeof(decimal));
                    ads.Tables[0].Columns.Add("BNtuchitra", typeof(decimal));
                }
                catch { }
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    r["sothe"] = s_sothe;
                    r["id"] = v_id;
                    r["lanin"] = alanin;
                    r["TonghuongBHYT"] = atonghuongbhyt ;
                    r["BNdongchitra"] = abndongchitra;
                    r["BNtuchitra"] = abntutra;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                //
               

                foreach (DataRow r2 in adst.Tables[0].Rows)
                {
                    DataRow r1 = ads.Tables[1].NewRow();
                    r1["mavp"] = r2["id_vp"];
                    r1["madoituong"] = r2["madoituong"];
                    r1["id_loaivp"] = r2["id_loai"];
                    r1["id_nhomvp"] = r2["id_nhom"];
                    r1["loaivp"] = r2["tenloaivp"];
                    r1["nhomvp"] = r2["tennhomvp"];
                    r1["sotien"] = r2["sotienct"];
                    r1["vat"] = 0;// vat;
                    r1["id"] = v_id;
                    r1["gia_dv"] = r2["gia_dv"].ToString();
                    r1["gia_bh"] = r2["gia_bh"].ToString();
                    r1["hangsx"] = r2["hangsx"].ToString();
                    r1["nuocsx"] = r2["nuocsx"].ToString();
                    r1["lanin"] = alanin;
                    r1["TonghuongBHYT"] = atonghuongbhyt;
                    r1["BNdongchitra"] = abndongchitra;
                    r1["BNtuchitra"] = abntutra;
                    ads.Tables[1].Rows.Add(r1);
                }
                //

                ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphi_BHYT.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí BHYT Ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;

                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_BienlaiNGT(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string v_mabn, string v_ngaykam, string s_sothe, int itraituyen, decimal d_tongtien,bool v_bInHDdichvu)
        {
            try
            {
                string aReport = m_report_bhyt;
                string aReport1 = "";
                if (v_bInHDdichvu)
                    aReport1 = aReport.Substring(0, aReport.Length - 4) + "_dichvu.rpt";
                else
                    aReport1 = aReport;
                DataSet adst;
                string sql = "", lydo = "", lydo1 = "", lydo4 = "";
                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                string thuoc = "";
                #region
               
                #endregion
                bool sys_ttrv_thuoc_vienphi = m_v.sys_ttrv_thuoc_vienphi;
                int imaphu = m_v.get_maphu_ngtru(s_sothe, d_tongtien, 0);
                if (imaphu == 1) lydo1 = " BN trả 20% BHYT ";
                else if (imaphu == 2) lydo1 = " BN trả 5% BHYT ";
                else if (imaphu == 0) lydo1 = " BHYT 100% ";
                //gam-21/02/2011-lấy tỉ lệ % bệnh nhân cùng chi trả theo mã thẻ
                int tile = m_v.get_maphu_ngtru(s_sothe, 1000000, 0);

                if (tile == 1)
                {
                    lydo4 = "BN cùng chi trả 20% BHYT: ";
                }
                else if (tile == 2)
                {
                    lydo4 = "BN cùng chi trả 5% BHYT: ";
                }
                else if (tile == 0)
                {
                    lydo4 = "BHYT chi trả 100%: ";
                }
                //gam
                if (itraituyen != 0)
                {
                    int i_bntra = 100 - m_v.iTraituyen_bhyt;
                    lydo4 = "BHYT trái tuyến, BN trả " + i_bntra + "% ";// gam 19-04-2011
                }
                if (v_mmyy == "") v_mmyy = m_v.s_curmmyy;
                if (sys_ttrv_thuoc_vienphi)
                {
                    foreach (DataRow r in m_v.get_data("select distinct nhomvp from medibv.d_dmnhom where nhom=" + m_v.nhom_duoc).Tables[0].Rows)
                        thuoc += r["nhomvp"].ToString() + ",";
                    if (thuoc != "")
                    {
                        thuoc = "," + thuoc;
                        decimal th = 0, vp = 0;
                        sql = "select d.id_nhom as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id ";
                        sql += "where a.id=" + v_id + " group by d.id_nhom";
                        sql += " union all ";
                        sql += "select d.nhomvp as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.d_dmbd c on b.mavp=c.id inner join medibv.d_dmnhom d on c.manhom=d.id ";
                        sql += "where a.id=" + v_id + " group by d.nhomvp";
                        foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                        {
                            if (r["sotien"].ToString() != "")
                            {
                                if (thuoc.IndexOf("," + r["nhom"].ToString() + ",") != -1) th += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                                else vp += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                        if (th != 0) lydo += "Thuốc :" + th.ToString("###,###,###,###.00");
                        if (vp != 0) lydo = lydo + ((lydo != "") ? "; " : "") + "Viện phí :" + vp.ToString("###,###,###,###.00");
                    }
                }
                sql = " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) as soluong, k.mavp as id_vp, sum(k.sotien-k.bhyttra) sotienct, -1 as id_loai, null as tenloaivp, m.nhomvp as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm.giaban as gia_dv, hsx.ten as hangsx, nsx.ten as nuocsx,b.lanin ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.d_dmnhom m on dm.manhom=m.id inner join medibv.v_nhomvp l on m.nhomvp=l.ma left join medibv.d_dmhang hsx on dm.mahang=hsx.id left join medibv.d_dmnuoc nsx on dm.manuoc=nsx.id ";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt, b.nopthem , to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, g.tenquan,h.tenpxa, to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu, tamung, dm.ten, k.soluong, k.mavp, m.nhomvp, l.ten, k.madoituong, dm.gia_bh, dm.giaban, hsx.ten, nsx.ten,b.lanin ";
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) soluong, k.mavp as id_vp, sum(k.sotien-k.bhyttra) sotienct, dm.id_loai as id_loai, n.ten as tenloaivp, n.id_nhom as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm." + sfield_gia + " as gia_dv , null as hangsx, null as nuocsx,b.lanin  ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.v_loaivp n on dm.id_loai=n.id inner join medibv.v_nhomvp l on n.id_nhom=l.ma ";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt, b.nopthem, to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu,tamung,dm.ten, k.mavp, dm.id_loai, n.ten, n.id_nhom, l.ten, k.madoituong, dm.gia_bh, dm." + sfield_gia + ",b.lanin";

                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
                // gam them field bn dong chi tra + bn chi trả (thu chenh lech va doi tuong thu)+ tổng chi phí được hưởng bhyt
                LibMedi.AccessData mdi = new LibMedi.AccessData();
                int i_nhomkho = mdi.nhom_duoc;
                decimal dtien = 0;
                LibDuoc.AccessData mdd = new LibDuoc.AccessData();
                if (s_sothe.Length == 13)
                {
                    dtien = mdd.ma13_st(i_nhomkho);
                }
                else
                {
                    dtien = mdd.ma16_st(i_nhomkho);
                }

                adst.Tables[0].Columns.Add("bndongchitra");
                adst.Tables[0].Columns.Add("bntuchitra");
                adst.Tables[0].Columns.Add("tongchiphihuongbhyt");
                decimal sotienbhyt = 0;
                foreach (DataRow dr in adst.Tables[0].Rows)
                {
                    if (dr["madoituong"].ToString() == "1")
                    {
                        sotienbhyt += decimal.Parse(dr["soluong"].ToString()) * decimal.Parse(dr["gia_dv"].ToString());
                    }

                }
                DataRow ar = adst.Tables[0].Rows[0];
                if (itraituyen == 0)
                {
                    if (sotienbhyt <= dtien)
                    {
                        ar["tongchiphihuongbhyt"] = decimal.Parse(ar["bhyttra"].ToString());
                        ar["bndongchitra"] = 0;
                    }
                    else if (tile == 2 && sotienbhyt > dtien)
                    {
                        ar["tongchiphihuongbhyt"] = (decimal.Parse(ar["bhyttra"].ToString()) * 100) / 95;
                        ar["bndongchitra"] = (decimal.Parse(ar["tongchiphihuongbhyt"].ToString()) * 5) / 100;
                    }
                    else if (tile == 1 && sotienbhyt > dtien)
                    {
                        ar["tongchiphihuongbhyt"] = (decimal.Parse(ar["bhyttra"].ToString()) * 100) / 80;
                        ar["bndongchitra"] = (decimal.Parse(ar["tongchiphihuongbhyt"].ToString()) * 20) / 100;
                    }

                    else if (tile == 0)
                    {
                        ar["tongchiphihuongbhyt"] = ar["bhyttra"].ToString();
                        ar["bndongchitra"] = 0;
                    }
                }
                else if (itraituyen != 0)
                {
                    ar["tongchiphihuongbhyt"] = (decimal.Parse(ar["bhyttra"].ToString()) * 100) / m_v.iTraituyen_bhyt;
                    ar["bndongchitra"] = (decimal.Parse(ar["tongchiphihuongbhyt"].ToString()) * (100 - m_v.iTraituyen_bhyt)) / 100;
                }
                ar["bntuchitra"] = decimal.Parse(ar["sotien"].ToString()) - decimal.Parse(ar["tongchiphihuongbhyt"].ToString());

                // gam
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

                abhyt = adst.Tables[0].Rows[0]["bhyttra"].ToString();
                if (abhyt.Trim() == "" || abhyt.Trim() == "0") lydo1 = "";
                lydo = lydo1 + lydo;
                // alydo = lan.Change_language_MessageText("Thanh toán viện phí BHYT Ngoại trú");
                //
                decimal s = 0;
                string s_mavp = "";
                string s_tenvp = "";
                //
                if (sys_ttrv_thuoc_vienphi) alydo = lydo;
                else
                {
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        if (s_mavp != r["id_vp"].ToString())
                        {
                            if (s_tenvp != "") alydo += s_tenvp + "(" + s.ToString("###,###,##0") + ")" + ",";
                            s_tenvp = r["ten"].ToString();
                            s = decimal.Parse(r["soluong"].ToString());
                            s_mavp = r["id_vp"].ToString();
                        }
                        else
                        {
                            if (r["madoituong"].ToString() != m_v.iTunguyen.ToString())
                            {
                                s += decimal.Parse(r["soluong"].ToString());
                            }
                        }
                    }
                }
                alydo = alydo + lydo4;
                if (s_tenvp != "") alydo += s_tenvp + "(" + s.ToString("###,###,##0") + ")" + ",";
                //gam-21/02/2011-themghichu so tien bn dong chi tra + so tien bn tra + tong so tien duoc huong bhyt
                string atonghuongbhyt = decimal.Parse(adst.Tables[0].Rows[0]["tongchiphihuongbhyt"].ToString()).ToString("###,###,##0.###");
                string abndongchitra = decimal.Parse(adst.Tables[0].Rows[0]["bndongchitra"].ToString()).ToString("###,###,##0.###");
                string abntutra = decimal.Parse(adst.Tables[0].Rows[0]["bntuchitra"].ToString()).ToString("###,###,##0.###");
                //gam
                string alanin = adst.Tables[0].Rows[0]["lanin"].ToString();

                asotien = adst.Tables[0].Rows[0]["bntra"].ToString();
                atongcp = adst.Tables[0].Rows[0]["sotien"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyttra"].ToString();
                amien = "0";
                athieu = "0";
                anopthem = "0";
                alydomien1 = "";
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = (decimal.Parse(atongcp.ToString()) - decimal.Parse(atamung.ToString()) - decimal.Parse(abhyt.ToString())).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "" || atmp.IndexOf("-") != -1) atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                //MessageBox.Show(atamung.Replace(",",""));
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                //gam-21/02/2011 them ghi chu
                //if (atonghuongbhyt != "0")
                //{
                //    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tổng chi phí được hưởng BHYT :") + " " + atonghuongbhyt;
                //}

                //gam
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT chi trả :") + " " + abhyt;
                }

                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }

                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);

                asotien = ahoan.ToString("###,###,##0.###");
                if (asotien.IndexOf("-") != -1)
                {
                    asotien = "0";
                    achutien = lan.Change_language_MessageText("Không đồng");
                }
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BN cùng chi trả :") + " " + ahoan.ToString("###,###,###.###");
                    //gam
                    //if (abndongchitra != "0")
                    //{
                    //    atmp = atmp + "\n" + lan.Change_language_MessageText("- BN đồng chi trả :") + " " + abndongchitra;
                    //}
                    //if (abntutra != "0")
                    //{
                    //    atmp = atmp + "\n" + lan.Change_language_MessageText("- BN tự chi trả :") + " " + abntutra;
                    //}
                    //gam

                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNGT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                try
                {
                    ads.Tables[1].Columns.Add("lanin");
                    ads.Tables[0].Columns.Add("lanin");
                }
                catch { }
                try
                {
                    ads.Tables[1].Columns.Add("TonghuongBHYT", typeof(decimal));
                    ads.Tables[0].Columns.Add("TonghuongBHYT", typeof(decimal));
                }
                catch { }
                try
                {
                    ads.Tables[1].Columns.Add("BNdongchitra", typeof(decimal));
                    ads.Tables[0].Columns.Add("BNdongchitra", typeof(decimal));
                }
                catch { }
                try
                {
                    ads.Tables[1].Columns.Add("BNtuchitra", typeof(decimal));
                    ads.Tables[0].Columns.Add("BNtuchitra", typeof(decimal));
                }
                catch { }
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    r["sothe"] = s_sothe;
                    r["id"] = v_id;
                    r["lanin"] = alanin;
                    r["TonghuongBHYT"] = atonghuongbhyt;
                    r["BNdongchitra"] = abndongchitra;
                    r["BNtuchitra"] = abntutra;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                //


                foreach (DataRow r2 in adst.Tables[0].Rows)
                {
                    DataRow r1 = ads.Tables[1].NewRow();
                    r1["mavp"] = r2["id_vp"];
                    r1["madoituong"] = r2["madoituong"];
                    r1["id_loaivp"] = r2["id_loai"];
                    r1["id_nhomvp"] = r2["id_nhom"];
                    r1["loaivp"] = r2["tenloaivp"];
                    r1["nhomvp"] = r2["tennhomvp"];
                    r1["sotien"] = r2["sotienct"];
                    r1["vat"] = 0;// vat;
                    r1["id"] = v_id;
                    r1["gia_dv"] = r2["gia_dv"].ToString();
                    r1["gia_bh"] = r2["gia_bh"].ToString();
                    r1["hangsx"] = r2["hangsx"].ToString();
                    r1["nuocsx"] = r2["nuocsx"].ToString();
                    r1["lanin"] = alanin;
                    r1["TonghuongBHYT"] = atonghuongbhyt;
                    r1["BNdongchitra"] = abndongchitra;
                    r1["BNtuchitra"] = abntutra;
                    ads.Tables[1].Rows.Add(r1);
                }
                //

                ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphi_BHYT.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport1, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí BHYT Ngoại trú (") + aReport1 + ")";
                    this.crystalReportViewer1.ReportSource = cMain;

                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DataSet f_Cursor_Phieuchi()
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
        public void f_Print_Phieuchi(bool v_dir, string v_id, string v_mmyy, string v_loaibl)
        {
            try
            {
                string aReport = m_report_phieuchi;
                DataSet adst;
                string sql = "";
                sql = "select a.id,a.sobienlai, sum(b.sotien) as sotien, to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, case when d.ngaysinh is null then d.namsinh else to_char(d.ngaysinh,'dd/mm/yyyy') end as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, j.hoten as nguoithu, i.sohieu as quyenso,b1.ten from medibvmmyy.v_phieuchill a left join medibvmmyy.v_phieuchict b on a.id=b.id  left join (select id, ten from medibv.v_giavp union select id, ten from medibv.d_dmbd) b1 on b.mavp=b1.id left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id where a.id=" + v_id + " group by a.id,a.sobienlai,to_char(a.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn, d.hoten, case when d.ngaysinh is null then d.namsinh else to_char(d.ngaysinh,'dd/mm/yyyy') end, e.ten,  f.tentt, g.tenquan,h.tenpxa, j.hoten, i.sohieu,b1.ten";
                if (v_mmyy == "")
                {
                    v_mmyy =m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy phiếu chi (") + v_id + ")", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //adst.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
                //return;

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", achutien = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "";
                decimal asotien = 0;
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();
                alydo = "";
                asotien = 0;
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText(
"CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText(
"TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                decimal asotient = 0;
                foreach (DataRow r in adst.Tables[0].Rows)
                {
                    try
                    {
                        asotient = decimal.Parse(r["sotien"].ToString());
                    }
                    catch
                    {
                        asotient = 0;
                    }
                    if (alydo != "")
                    {
                        alydo += ", ";
                    }
                    alydo += r["ten"].ToString();
                    asotien += asotient;
                }
                asotien = Math.Round(asotien, 0);
                achutien = m_v.Doiso_Unicode(asotien.ToString().Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText(
"Không đồng");
                }

                DataSet ads = f_Cursor_Phieuchi();
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien.ToString("###,###,##0.##");
                    r["chutien"] = achutien;
                    r["tongcp"] = "0";
                    r["tamung"] = "0";
                    r["bhyt"] = "0";
                    r["mien"] = "0";
                    r["lydomien"] = "";
                    r["nguoithu"] = anguoithu;
                    ads.Tables[0].Rows.Add(r);
                }
                ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
                //return;

                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText(
"In phiếu chi (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,  ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void f_Print_ChiphiKBCT(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                string aReport = "v_thanhtoantructiep_chitiet.rpt";
                // gam 26-04-2011
                //string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh,d.cholam, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, case when b.khuyenmai <= 0 then b.mien else 0 end as mien, case when b.khuyenmai > 0 then b.mien else 0 end as khuyenmai, b.thieu, case when b.khuyenmai <= 0 then c.sotien else 0 end as tongmien,case when b.khuyenmai > 0 then sum(b.mien) else 0 end as tongkhuyenmai ,  ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " where a.id=" + v_id;
                //sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt , g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten , l.sothe, l.denngay , e.tenkp, a.ngay,  i.id , j.id , k.ma , i.ten, j.ten , k.ten , i.stt , j.stt ,  k.stt , i.dvt, b.soluong, b.dongia, b.mien, b.thieu, b.khuyenmai , b.madoituong, m.hoten,b.tra ,a.ghichu ,b.mien ";
                sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh,d.cholam, f.tentt , g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten , l.sothe, l.denngay , e.tenkp, a.ngay,  i.id , j.id , k.ma , i.ten, j.ten , k.ten , i.stt , j.stt ,  k.stt , i.dvt, b.soluong, b.dongia, b.mien, b.thieu, b.khuyenmai , b.madoituong, m.hoten,b.tra ,a.ghichu ,b.mien,c.sotien ";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";

                if (bInchuky)
                {
                    ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                    }
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        foreach (DataRow r in ads.Tables[0].Rows)
                            r["image"] = image;
                }


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "^" + ads.Tables[0].Rows[0]["tongkhuyenmai"].ToString().Trim() + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
                string v_sobanin = m_v.tt_sobanin_hoadonct(m_userid);
                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    //this.TopMost = true;
                    this.banin.Value = (v_sobanin == "") ? 1 : int.Parse(v_sobanin);
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter((v_sobanin == "") ? 1 : int.Parse(v_sobanin), false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void f_Print_ChiphiKBCT(bool v_dir, string v_id, string v_mmyy, string v_mabn,string v_ngay)
        {
            try
            {
                string aReport = "v_thanhtoantructiep_chitiet.rpt";
                // gam 26-04-2011
                // string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh,d.cholam, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, case when b.khuyenmai <= 0 then b.mien else 0 end as mien, case when b.khuyenmai > 0 then b.mien else 0 end as khuyenmai, b.thieu, case when b.khuyenmai <= 0 then c.sotien else 0 end as tongmien,case when b.khuyenmai > 0 then sum(b.mien) else 0 end as tongkhuyenmai ,  ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                //sql += " where a.id=" + v_id;
                sql += " where a.mabn='" + v_mabn + "'";
                if (v_ngay.Trim() != "" && v_ngay.Trim() != "0")
                {
                    sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay + "'";
                }
                else
                {
                    sql += " and a.id=" + v_id;
                }
                //sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt , g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten , l.sothe, l.denngay , e.tenkp, a.ngay,  i.id , j.id , k.ma , i.ten, j.ten , k.ten , i.stt , j.stt ,  k.stt , i.dvt, b.soluong, b.dongia, b.mien, b.thieu, b.khuyenmai , b.madoituong, m.hoten,b.tra ,a.ghichu ,b.mien ";
                sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh,d.cholam, f.tentt , g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten , l.sothe, l.denngay , e.tenkp, a.ngay,  i.id , j.id , k.ma , i.ten, j.ten , k.ten , i.stt , j.stt ,  k.stt , i.dvt, b.soluong, b.dongia, b.mien, b.thieu, b.khuyenmai , b.madoituong, m.hoten,b.tra ,a.ghichu ,b.mien,c.sotien ";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";

                if (bInchuky)
                {
                    ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                    }
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        foreach (DataRow r in ads.Tables[0].Rows)
                            r["image"] = image;
                }


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "^" + ads.Tables[0].Rows[0]["tongkhuyenmai"].ToString().Trim() + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void f_Print_ChiphiKBCT_mavv(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien)
        {
            try
            {
                string aReport = "v_thanhtoantructiep_chitiet.rpt";

                string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, case when b.khuyenmai <= 0 then b.mien else 0 end as mien, case when b.khuyenmai > 0 then b.mien else 0 end as khuyenmai, b.thieu, case when b.khuyenmai <= 0 then sum(b.mien) else 0 end as tongmien,case when b.khuyenmai > 0 then sum(b.mien) else 0 end as tongkhuyenmai ,  ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                //sql += " where a.id=" + v_id;
                sql += " where a.mabn='" + v_mabn + "'";
                if (v_mavaovien.Trim() != "" && v_mavaovien.Trim() != "0")
                {
                    sql += " and a.mavaovien=" + v_mavaovien;
                }
                else
                {
                    sql += " and a.id=" + v_id;
                }
                sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt , g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten , l.sothe, l.denngay , e.tenkp, a.ngay,  i.id , j.id , k.ma , i.ten, j.ten , k.ten , i.stt , j.stt ,  k.stt , i.dvt, b.soluong, b.dongia, b.mien, b.thieu, b.khuyenmai , b.madoituong, m.hoten,b.tra ,a.ghichu ,b.mien ";
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";

                if (bInchuky)
                {
                    ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                    }
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        foreach (DataRow r in ads.Tables[0].Rows)
                            r["image"] = image;
                }


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "^" + ads.Tables[0].Rows[0]["tongkhuyenmai"].ToString().Trim() + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void f_Print_ChiphiKBCT_1(bool v_dir, string v_id, string v_mmyy,string v_mabn,string v_mavaovien )
        {
            // gam 30-01-2011 in chi phí đối tượng thu phí giống mẫu 38 
            try
            {
                bool thutheodot = false;
                thutheodot = m_v.bhyt_thutheodot_mavaovien(m_userid);
                string aReport = "v_thanhtoanravienngtru_chitiet_1.rpt";
                string exp = "where a.id="+v_id;
                if (thutheodot)
                {
                    exp = " where aa.mabn=" + v_mabn + " and aa.mavaovien=" + v_mavaovien;
                }

                string sql = "select b.mavp as id,i.ma,i.ten,i.dvt,i.hamluong,i.tenhc,b.soluong,b.dongia as giaban,b.dongia as giamua,'' as cachdung,k.ma as idnhom,k.ten as tennhom,";
                sql += "k.stt as stt_nhom,aa.mabn,d.hoten,d.namsinh,d.sonha||', '||d.thon||', '||h.tenpxa||', '||g.tenquan||', '||f.tentt as diachi,'' as sothe,'' as denngay,";
                sql += "to_char(a.ngay,'dd/mm/yyyy') as ngay,a.userid,'' as sohieu,a.sobienlai,a.sotien,a.bhyt as bhyttra,a.nopthem as bntra,";
                sql += "a.makp,'' as tenbv,e.tenkp,aa.maicd,aa.chandoan,d.phai,a.tamung from medibvmmyy.v_ttrvll a ";
                sql += "inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibvmmyy.v_ttrvds aa on aa.id=a.id inner join medibv.v_quyenso bb on a.quyenso=bb.id  ";
                sql += "left join medibvmmyy.v_mienngtru c  on a.id=c.id left join medibv.btdbn d on aa.mabn=d.mabn left join ";
                sql += "medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on ";
                sql += "d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join ";
                sql += "(select '' as hamluong,'' as tenhc,ma,id, stt, ten, dvt, id_loai from medibv.v_giavp union ";
                sql += "select hamluong,tenhc,ma,id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai from medibv.d_dmbd) i ";
                sql += "on b.mavp=i.id left join (select id, id_nhom, stt, ten from medibv.v_loaivp ";
                sql += "union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id ";
                sql += "left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k ";
                sql += "on j.id_nhom=k.ma left join  medibv.bhyt l on aa.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id ";
                sql += "left join medibv.dmphai n on d.phai=n.ma ";
                sql += exp;
               
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                ads.WriteXml("..\\..\\Datareport\\v_thanhtoanravienngtru_chitiet_1.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;
                anguoiin = ads.Tables[0].Rows[0]["userid"].ToString();
                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                aghichu = "";

                if (bInchuky)
                {
                    ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                    }
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        foreach (DataRow r in ads.Tables[0].Rows)
                            r["image"] = image;
                }


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                //cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                //cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                //cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                //cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                //cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "^" + ads.Tables[0].Rows[0]["tongkhuyenmai"].ToString().Trim() + "'";
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                cMain.DataDefinition.FormulaFields["v_congkhamBHYT"].Text = "''";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    //this.ShowDialog(this.Parent);
                    this.ShowDialog();
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void f_Print_ChiphiKBCT_(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                string aReport = "v_thanhtoantructiep_chitiet.rpt";

                string sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " where a.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);                
               
                ads.WriteXml("..\\..\\Datareport\\v_thanhtoantructiep.xml", XmlWriteMode.WriteSchema);
                //return;

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";

                if (bInchuky)
                {
                    ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                    }
                    if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        foreach (DataRow r in ads.Tables[0].Rows)
                            r["image"] = image;
                }


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }            
        }
        
        public void f_Print_ChiphiTTRVNoitruCT(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                string aReport = "v_thanhtoanravien_chitiet.rpt";
                string sql = "";

                sql = "select a.id, a.mabn, d.hoten, d.namsinh, dd.hoten_bo, dd.hoten_me, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, case when l.sothe is null then '. . . . . . . . . . . . . . ' else l.sothe end as mabhyt, case when l.denngay is null then '. . . . . . . . . . . . . . ' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ll.mabv, ll.tenbv, cc.sohieu, b.sobienlai, e.tenkp, a.maicd, a.chandoan,  to_char(b.ngay,'dd/mm/yyyy') as ngay, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, ngayra-ngayvao as songay, a.giuong, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, k.stt as sttnhomvp, i.dvt, c.soluong";
                sql += " ,c.dongia,c.soluong*c.dongia as sotien, b.sotien as tongcp, b.bhyt, b.tamung, b.mien, b.thieu, b.sotien-b.bhyt-b.mien-b.thieu-b.tamung as bntra ";
                sql += " ,c.madoituong, m.hoten as nguoithu from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c";
                sql += " on a.id=c.id left join medibv.v_quyenso cc on b.quyenso=cc.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.hcnhi dd on d.mabn=dd.mabn";
                sql += " left join medibv.btdkp_bv e on c.makp=e.makp left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu";
                sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join";
                sql += " (select g1.id, g1.stt, g1.ten, g1.dvt, g1.id_loai,g2.id_nhom from medibv.v_giavp g1 left join medibv.v_loaivp g2 on g1.id_loai=g2.id";
                sql += " union select d1.id, 1 as stt, trim(d1.ten||'['||trim(d1.tenhc)||'] '||d1.hamluong) as ten, d1.dang as dvt, 0 as id_loai, ";
                sql += " case when d2.nhomvp is null then 0 else d2.nhomvp end as id_nhom from medibv.d_dmbd d1 left join medibv.d_dmnhom d2 on d1.manhom=d2.id) i";
                sql += " on c.mavp=i.id left join ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j";
                sql += " on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k";
                sql += " on i.id_nhom=k.ma left join medibv.bhyt l on a.maql=l.maql left join medibv.dstt ll on l.mabv=ll.mabv left join medibv.v_dlogin m";
                sql += " on b.userid=m.id left join medibv.dmphai n on d.phai=n.ma where a.id="+v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);
                
                ads.WriteXml("..\\..\\Datareport\\v_thanhtoanravien.xml",XmlWriteMode.WriteSchema);
             

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";

                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";

                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Phiếu thanh toán ra viện bệnh nhân nội trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_ChiphiTTRVNgtruCT(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien, decimal v_congkhamBHYT)
        {
            try
            {
                //gam
                bool thutheodot = false;
                thutheodot = m_v.bhyt_thutheodot_mavaovien(m_userid);
                string aexp = " where b.id=" + v_id;
                string aReport = "v_thanhtoanravienngtru_chitiet.rpt";
                if (thutheodot)
                {
                    aexp = " where a.mabn=" + v_mabn + " and a.mavaovien=" + v_mavaovien ;
                }
                string sql = "";

                sql = "select d.id,d.ma,d.ten,d.dang as dvt, d.hamluong,d.tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua," +
                   " '' as cachdung, f.ma as id_nhom, f.ten as tennhom, f.stt as stt_nhom,a.mabn,g.hoten,g.namsinh," +
                   " g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as diachi,b1.sothe," +
                   " to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay" +
                   " ,b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem as bntra,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,to_number('0') as id_loai,g.msthue " +

                   " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id " +
                   " inner join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on " +
                   " b.id=c.id inner join medibv.d_dmbd d on c.mavp=d.id inner join medibv.d_dmnhom e on " +
                   " d.manhom=e.id inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.btdbn g on " +
                   " a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on " +
                   " g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join " +
                   " medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp " +
                   " inner join medibv.v_quyenso m on b.quyenso=m.id left join medibv.dmphongthuchiencls mm on c.idphongcls=mm.id " + aexp;//where b.id=" + v_id;
                sql += " union all ";
                sql += " select d.id,d.ma,d.ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban," +
                    " c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f.ten as tennhom,f.stt as stt_nhom," +
                    " a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  diachi,b1.sothe,to_char(b1.ngay,'dd/mm/yyyy') as denngay," +
                    " to_char(b.ngay,'dd/mm/yyyy') as ngay, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem as bntra,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,e.id as id_loai,g.msthue from medibvmmyy.v_ttrvds a inner join " +
                    " medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id " +
                    " inner join medibvmmyy.v_ttrvct c on b.id=c.id inner join medibv.v_giavp d on c.mavp=d.id" +
                    " inner join medibv.v_loaivp e on d.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma" +
                    " inner join medibv.btdbn g on a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner " +
                    " join medibv.btdquan i on g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa " +
                    " left join medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp " +
                    " inner join medibv.v_quyenso m on b.quyenso=m.id left join medibv.dmphongthuchiencls mm on c.idphongcls=mm.id " + aexp;// where b.id=" + v_id;
             
               
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);
                                             

                if ((ads == null)||(ads.Tables[0].Rows.Count <= 0))
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ bhyt ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
             
                ads.WriteXml("..\\..\\Datareport\\v_thanhtoanravien_ngtru.xml", XmlWriteMode.WriteSchema);

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["userid"].ToString();
                aghichu = "";             
                cMain = new ReportDocument();                
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";            
                cMain.DataDefinition.FormulaFields["v_congkhamBHYT"].Text = "'" + v_congkhamBHYT + "'";

                this.Text = lan.Change_language_MessageText("Chi phí KCB Ngoại trú (") + aReport + ")";
                if (!v_dir)
                {
                    this.crystalReportViewer1.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                    this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);           
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                    
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_ChiphiTTRVNgtruCT(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien, decimal v_congkhamBHYT,bool v_sttcho)
        {
            try
            {
                //gam
                bool thutheodot = false;
                thutheodot = m_v.bhyt_thutheodot_mavaovien(m_userid);
                string aexp = " where b.id=" + v_id;
                string aReport = "v_thanhtoanravienngtru_chitiet.rpt";
                if (thutheodot)
                {
                    aexp = " where a.mabn=" + v_mabn + " and a.mavaovien=" + v_mavaovien;
                }
                string sql = "";

                sql = "select c.madoituong,d.id,d.ma,d.ten,d.dang as dvt, d.hamluong,d.tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua," +
                   " '' as cachdung, f.ma as id_nhom, f.ten as tennhom, f.stt as stt_nhom,a.mabn,g.hoten,g.namsinh," +
                   " g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as diachi,b1.sothe," +
                   " to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay" +
                   " ,b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem as bntra,b1.mabv,k.tenbv,"+
                   "l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,to_number('0') as id_loai,g.msthue, c.phuthu " +
                   " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id " +
                   " left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on " +
                   " b.id=c.id inner join medibv.d_dmbd d on c.mavp=d.id inner join medibv.d_dmnhom e on " +
                   " d.manhom=e.id inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.btdbn g on " +
                   " a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on " +
                   " g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join " +
                   " medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp " +
                   " inner join medibv.v_quyenso m on b.quyenso=m.id left join (select makp as id, tenkp as ten from medibv.btdkp_bv union all select  to_char(id) as id, ma as ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;//where b.id=" + v_id;
                sql += " union all ";
                sql += " select c.madoituong,d.id,d.ma,d.ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban," +
                    " c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f.ten as tennhom,f.stt as stt_nhom," +
                    " a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  diachi,b1.sothe,to_char(b1.ngay,'dd/mm/yyyy') as denngay," +
                    " to_char(b.ngay,'dd/mm/yyyy') as ngay, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem as bntra,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,e.id as id_loai,g.msthue , c.phuthu from medibvmmyy.v_ttrvds a inner join " +
                    " medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id " +
                    " inner join medibvmmyy.v_ttrvct c on b.id=c.id inner join medibv.v_giavp d on c.mavp=d.id" +
                    " inner join medibv.v_loaivp e on d.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma" +
                    " inner join medibv.btdbn g on a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner " +
                    " join medibv.btdquan i on g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa " +
                    " left join medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp " +
                    " inner join medibv.v_quyenso m on b.quyenso=m.id left join (select makp as id, tenkp as ten from medibv.btdkp_bv union all select to_char(id) as id, ma ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;// where b.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);


                if ((ads == null) || (ads.Tables[0].Rows.Count <= 0))
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ bhyt ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow r2 = ads.Tables[0].Rows[0];
                DataRow r1 = ads.Tables[0].NewRow();
                if (v_sttcho)
                {
                    string v_sovaovien = m_v.get_data_mmyy(v_mmyy,"select sovaovien from medibvmmyy.tiepdon where mabn="+v_mabn+" and mavaovien="+v_mavaovien).Tables[0].Rows[0][0].ToString();
                    for (int i = 0; i < ads.Tables[0].Columns.Count; i++)
                        r1[i] = r2[i].ToString();
                    r1["id_nhom"] = 9999;
                    r1["ten"] = "Bác sĩ đọc kết quả";
                    r1["sotien"] = 0;
                    r1["giamua"] = 0;
                    r1["giaban"] = 0;
                    r1["sttcho"] = v_sovaovien==""?"0":v_sovaovien;
                    r1["phongcls"] = r2["tenkp"].ToString();
                    ads.Tables[0].Rows.Add(r1);
                }

                ads.WriteXml("..\\..\\Datareport\\v_thanhtoanravien_ngtru.xml", XmlWriteMode.WriteSchema);

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["userid"].ToString();
                aghichu = "";
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                cMain.DataDefinition.FormulaFields["v_congkhamBHYT"].Text = "'" + v_congkhamBHYT + "'";

                this.Text = lan.Change_language_MessageText("Chi phí KCB Ngoại trú (") + aReport + ")";
                if (!v_dir)
                {
                    this.crystalReportViewer1.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                    this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);

                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_Phieuchi_Chitiet(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                string aReport = "v_phieuchi_chitiet.rpt";

                string sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh, ";
                sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngay, ";
                sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                sql += " k.stt as sttnhomvp, i.dvt, 1 as soluong, b.sotien as dongia, b.sotien, 0 as bhtra, 0 as mien, 0 as thieu, 0 as tongmien, ";
                sql += " 2 as madoituong, m.hoten as nguoithu from medibvmmyy.v_phieuchill a inner join medibvmmyy.v_phieuchict b on a.id=b.id ";
                sql += " left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " where a.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);
                
                 ads.WriteXml("..\\..\\Datareport\\v_Phieuchi_chitiet.xml",XmlWriteMode.WriteSchema);
                

                if (ads.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(ads.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = ads.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";

                 cMain = new ReportDocument();
                 cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("Bảng kê chi phí điều trị ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void f_Print_Bienlaitaichinh(bool v_dir,string v_id, string v_mmyy)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {

                try
                {
                    string aReport = "v_inbienlaitaichinh.rpt";
                    string sql = "";
                    DataSet adst = null;

                    sql = " select a.*,b.*,c.*,d.hoten as nguoithu from medibvmmyy.v_bienlaitaichinhll a, medibvmmyy.v_bienlaitaichinhct b, medibvmmyy.v_vienphill c,medibv.v_dlogin d where a.id=b.id and b.idvienphi=c.id(+) and a.userid=d.id";
                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string asyt = "", abv = "",adiachibv = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;                   
                   
                    adst.WriteXml("..\\..\\Datareport\\v_inbienlaitaichinh.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.DataDefinition.FormulaFields["syt"].Text = "'" + asyt + "'";
                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                   

                    cMain.SetDataSource(adst);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai tài chính") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
                cMain.Close(); cMain.Dispose();
            }
        }
        public void f_Print_Bienlaitaichinh_1(bool v_dir, string v_id, string v_mmyy)
        {
            // in bien lai đã duyệt
            string acur = System.Environment.CurrentDirectory;
            try
            {

                try
                {
                    string aReport = "v_inbienlaitaichinh.rpt";
                    string sql = "";
                    DataSet adst = null;

                    sql = " select a.*,c.*,b.*,d.hoten as nguoithu from medibvmmyy.v_bienlaitaichinhll a, "+
                        "medibvmmyy.v_bienlaitaichinhct b,medibv.v_dlogin d,medibv.btdbn c where a.id=b.id and "+
                        "a.mabn=c.mabn and a.userid=d.id and a.id="+v_id+" and a.done=1";
                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_bienlaitaichinhll set lanin=lanin+1 where id=" + v_id);
                    string asyt = "", abv = "", adiachibv = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;

                    adst.WriteXml("..\\..\\Datareport\\v_inbienlaitaichinh.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.DataDefinition.FormulaFields["syt"].Text = "'" + asyt + "'";
                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";


                    cMain.SetDataSource(adst);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai tài chính") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
                cMain.Close(); cMain.Dispose();
            }
        }



        public void f_Print_PhieuChi_Hoantra(bool v_dir, string v_id, string v_mmyy_only)
        {
            try
            {               
                string aReport = "v_phieuchi_hoantra.rpt";
                string sql = "";
                DataSet adst = null;

                sql = " select a.id, a.mabn, a.sobienlai, a.ghichu, nvl(a.sotien,0) sotien, to_char(a.ngay,'dd/mm/yyyy') ngay, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso ";
                sql+=" from medibvmmyy.v_hoantra a, medibv.btdbn d, medibv.dmphai e, medibv.btdtt f, medibv.btdquan g, medibv.btdpxa h, medibv.v_quyenso i, medibv.v_dlogin j ";
                sql += " where a.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and to_char(a.id)='" + v_id + "'";
                if (v_mmyy_only == "")
                {
                    adst = m_v.get_data_all(DateTime.Now, DateTime.Now, sql);
                }
                else
                {
                    adst = m_v.get_data_mmyy(v_mmyy_only, sql);
                }
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không tìm thấy hoá đơn hoàn trả <" + v_id + ">", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }          

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", alydomien = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(adst.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = "";
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace("Không xác định", "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace("Không xác định", "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();
                alydo = adst.Tables[0].Rows[0]["ghichu"].ToString();
                asotien = adst.Tables[0].Rows[0]["sotien"].ToString();
                atongcp = adst.Tables[0].Rows[0]["sotien"].ToString();
                atamung = adst.Tables[0].Rows[0]["sotien"].ToString();
                abhyt = adst.Tables[0].Rows[0]["sotien"].ToString();
                amien = adst.Tables[0].Rows[0]["sotien"].ToString();
                alydomien = "";//m_ds.Tables[0].Rows[0]["lydomien"].ToString();
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = "<CỤC THUẾ>";
                atongcuc = "<TỔNG CỤC THUẾ>";
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();

                try
                {
                    atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,###.##").PadRight(20, '.');
                    atongcp = atongcp.Substring(0, atongcp.IndexOf("."));
                }
                catch
                {
                    atongcp = "0";
                }
                if (atongcp == "") atongcp = "0";
                achutien = m_v.Doiso_Unicode(atongcp.Replace(",", ""));
                atongcp = atongcp + "đồng";

                try
                {
                    atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###.##").PadRight(20, '.');
                    atamung = atamung.Substring(0, atamung.IndexOf("."));
                }
                catch
                {
                    atamung = "0";
                }
               
                if (atamung == "") atamung = "0";
                achutientu = m_v.Doiso_Unicode(atamung.Replace(",", ""));

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,###").Length > 0 ? decimal.Parse(asotien.ToString()).ToString("###,###,###") + "đồng" : "0đồng";
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###").Length > 0 ? decimal.Parse(atamung.ToString()).ToString("###,###,###") + "đồng" : "0đồng";
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,###").Length > 0 ? decimal.Parse(abhyt.ToString()).ToString("###,###,###") + "đồng" : "0đồng";
                amien = decimal.Parse(amien.ToString()).ToString("###,###,###").Length > 0 ? decimal.Parse(amien.ToString()).ToString("###,###,###") + "đồng" : "0đồng";

                DataSet ads = f_Cursor_BienlaiNT();                     
                 foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='"+aReport.ToLower()+"'","stt"))
                 {
                 
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = aquyenso;
                    r["sobienlai"] = asobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    ads.Tables[0].Rows.Add(r);
                }
                ads.WriteXml("..\\..\\datareport\\v_Inbienlaihoan.xml",XmlWriteMode.WriteSchema);
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                if (!v_dir)
                {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("Phiếu chi tiền viện phí hoàn trả.") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmPrintHD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9: butIn_Click(sender, e); break;
                case Keys.F7: butExcel_Click(sender, e); break;
                case Keys.F10: butKetthuc_Click(sender, e); break;
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bPrinter = true;
            try
            {
                cMain.PrintToPrinter(Convert.ToInt16(banin.Value), false, Convert.ToInt16(tu.Value), Convert.ToInt16(den.Value));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor = Cursors.Default;
            this.Close();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            bPrinter = false;
            this.Close();
        }

        private void butExcel_Click(object sender, EventArgs e)
        {
            
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
            this.Cursor = Cursors.Default;
        }
        public void f_Print_BienlaiKB_hdtc(bool v_dir, string v_id, string v_mabn, string v_ngaythu, string v_mmyy, string v_loaibl, string report, string nhom_gtgt, string v_quyenso, string v_sobienlai, string v_tendv,string v_masothue,string m_vat)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                try
                {
                    string aReport = m_report_thutructiep;
                    if (report != "") aReport = report;
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString()); ;
                    DataSet adst = null;

                    sql = "select a.id,'"+v_quyenso+"' as quyenso, '"+v_sobienlai+"' as sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,a.namsinh as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, coalesce(j.ten,'TIỀN THUỐC') as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong, a.bacsi as bacsichidinh, b.mabs as bacsithuchien";
                    sql += ", i.gia_bh, i.gia_dv ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";                   

                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, round(gvp.gia_bh,2) as gia_bh, round(gvp." + sfield_gia + ",2) as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, to_number(decode(bd.gia_bh,0, round(bd.dongia,2),round(bd.gia_bh,2))) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";

                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.mabn='" + v_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='"+ v_ngaythu +"' and b.tra<=0";
                    //sql += " where a.id=" + v_id + " and b.tra<=0";
                    if (nhom_gtgt != "") sql += " and i.nhomvp not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";

                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);

                    if (nhom_gtgt != "" && adst.Tables[0].Rows.Count == 0) return;
                    else if (adst.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string asyt = "", abv = "", adiachibv = "", adiachi = "";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    adiachibv = m_v.s_diachi;

                    adiachi = adst.Tables[0].Rows[0]["sonha"].ToString().Trim() + " " + adst.Tables[0].Rows[0]["thon"].ToString().Trim();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenpxa"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                    adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                    adiachi = adiachi.Trim().Trim(',').Trim();
                    if (adiachi.Trim() == "")
                    {
                        adiachi = adst.Tables[0].Rows[0]["diachi"].ToString().Trim();
                    }
                    if (bInchuky)
                    {
                        try
                        {
                            adst.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                            }

                            if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                                foreach (DataRow r in adst.Tables[0].Rows)
                                    r["image"] = image;
                        }
                        catch
                        {

                        }
                    }


                    adst.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep1.xml", XmlWriteMode.WriteSchema);

                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                    cMain.DataDefinition.FormulaFields["m_tendv"].Text = "'" + v_tendv + "'";
                    cMain.DataDefinition.FormulaFields["m_masothue"].Text = "'" + v_masothue + "'";
                    cMain.DataDefinition.FormulaFields["m_vat"].Text = "" + m_vat + "";
                    cMain.SetDataSource(adst);

                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In hóa đơn thu viện phí") + " (" + aReport + ")";
                        this.TopMost = true;
                        this.ShowDialog(this.Parent);
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);
                    cMain.Close(); cMain.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        public void f_Print_BienlaiNGT_HDTC(bool v_dir, string v_id, string v_mmyy, string s_sothe, int itraituyen, decimal d_tongtien, string v_quyenso, string v_sobienlai, string v_tendv, string v_masothue, string m_vat)
        {
            try
            {
                string aReport = m_report_bhyt_hdtc;
                DataSet adst;
                string sql = "", lydo = "", lydo1 = "";
                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                string thuoc = "";
               
                bool sys_ttrv_thuoc_vienphi = m_v.sys_ttrv_thuoc_vienphi;
                int imaphu = m_v.get_maphu_ngtru(s_sothe, d_tongtien, 0);
                if (imaphu == 1) lydo1 = " BN trả 20% BHYT ";
                else if (imaphu == 2) lydo1 = " BN trả 5% BHYT ";
                else if (imaphu == 0) lydo1 = " BHYT 100% ";
                if (itraituyen != 0)
                {
                    int i_bntra = 100 - m_v.iTraituyen_bhyt;
                    lydo1 = "BHYT trái tuyến, BN trả " + i_bntra + "% ";
                }
                if (v_mmyy == "") v_mmyy = m_v.s_curmmyy;
                if (sys_ttrv_thuoc_vienphi)
                {
                    foreach (DataRow r in m_v.get_data("select distinct nhomvp from medibv.d_dmnhom where nhom=" + m_v.nhom_duoc).Tables[0].Rows)
                        thuoc += r["nhomvp"].ToString() + ",";
                    if (thuoc != "")
                    {
                        thuoc = "," + thuoc;
                        decimal th = 0, vp = 0;
                        sql = "select d.id_nhom as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id ";
                        sql += "where a.id=" + v_id + " group by d.id_nhom";
                        sql += " union all ";
                        sql += "select d.nhomvp as nhom,sum(b.sotien) as sotien, sum(b.bhyttra) as bhyttra";
                        sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                        sql += " inner join medibv.d_dmbd c on b.mavp=c.id inner join medibv.d_dmnhom d on c.manhom=d.id ";
                        sql += "where a.id=" + v_id + " group by d.nhomvp";
                        foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                        {
                            if (r["sotien"].ToString() != "")
                            {
                                if (thuoc.IndexOf("," + r["nhom"].ToString() + ",") != -1) th += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                                else vp += decimal.Parse(r["sotien"].ToString()) - decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                        if (th != 0) lydo += "Thuốc :" + th.ToString("###,###,###,###.00");
                        if (vp != 0) lydo = lydo + ((lydo != "") ? "; " : "") + "Viện phí :" + vp.ToString("###,###,###,###.00");
                    }
                }
                sql = " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) as soluong, k.mavp as id_vp, sum(k.sotien-k.bhyttra) sotienct, -1 as id_loai, null as tenloaivp, m.nhomvp as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm.giaban as gia_dv, hsx.ten as hangsx, nsx.ten as nuocsx ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.d_dmnhom m on dm.manhom=m.id inner join medibv.v_nhomvp l on m.nhomvp=l.ma left join medibv.d_dmhang hsx on dm.mahang=hsx.id left join medibv.d_dmnuoc nsx on dm.manuoc=nsx.id ";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt, b.nopthem , to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, g.tenquan,h.tenpxa, to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu, tamung, dm.ten, k.soluong, k.mavp, m.nhomvp, l.ten, k.madoituong, dm.gia_bh, dm.giaban, hsx.ten, nsx.ten";
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) soluong, k.mavp as id_vp, sum(k.sotien-k.bhyttra) sotienct, dm.id_loai as id_loai, n.ten as tenloaivp, n.id_nhom as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm." + sfield_gia + " as gia_dv , null as hangsx, null as nuocsx  ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.v_loaivp n on dm.id_loai=n.id inner join medibv.v_nhomvp l on n.id_nhom=l.ma ";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt, b.nopthem, to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu,tamung,dm.ten, k.mavp, dm.id_loai, n.ten, n.id_nhom, l.ten, k.madoituong, dm.gia_bh, dm." + sfield_gia;

                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                adst = m_v.get_data_mmyy(v_mmyy, sql);
                if (adst.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + v_id);
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = adst.Tables[0].Rows[0]["ngay"].ToString();
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                aghichu = "";
                ahoten = adst.Tables[0].Rows[0]["hoten"].ToString();
                angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                agioitinh = adst.Tables[0].Rows[0]["gioitinh"].ToString();
                akhoa = adst.Tables[0].Rows[0]["tenkp"].ToString().Trim(); ;
                adiachi = adst.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tenquan"].ToString();
                adiachi = adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"), "").Trim().Trim(',') + ", " + adst.Tables[0].Rows[0]["tentt"].ToString();
                adiachi = adiachi.Trim().Trim(',').Trim();

                abhyt = adst.Tables[0].Rows[0]["bhyttra"].ToString();
                if (abhyt.Trim() == "" || abhyt.Trim() == "0") lydo1 = "";
                lydo = lydo1 + lydo;
                // alydo = lan.Change_language_MessageText("Thanh toán viện phí BHYT Ngoại trú");
                //
                decimal s = 0;
                string s_mavp = "";
                string s_tenvp = "";
                //
                if (sys_ttrv_thuoc_vienphi) alydo = lydo;
                else
                {
                    foreach (DataRow r in adst.Tables[0].Rows)
                    {
                        if (s_mavp != r["id_vp"].ToString())
                        {
                            if (s_tenvp != "") alydo += s_tenvp + "(" + s.ToString("###,###,##0") + ")" + ",";
                            s_tenvp = r["ten"].ToString();
                            s = decimal.Parse(r["soluong"].ToString());
                            s_mavp = r["id_vp"].ToString();
                        }
                        else
                        {
                            if (r["madoituong"].ToString() != m_v.iTunguyen.ToString())
                            {
                                s += decimal.Parse(r["soluong"].ToString());
                            }
                        }
                    }
                }
                if (s_tenvp != "") alydo += s_tenvp + "(" + s.ToString("###,###,##0") + ")" + ",";
                asotien = adst.Tables[0].Rows[0]["bntra"].ToString();
                atongcp = adst.Tables[0].Rows[0]["sotien"].ToString();
                atamung = adst.Tables[0].Rows[0]["tamung"].ToString();
                abhyt = adst.Tables[0].Rows[0]["bhyttra"].ToString();
                amien = "0";
                athieu = "0";
                anopthem = "0";
                alydomien1 = "";
                achutien = "";
                anguoithu = adst.Tables[0].Rows[0]["nguoithu"].ToString();
                amasothue = m_v.s_masothue;
                amauso = m_v.s_maubienlai;
                aquyenso = adst.Tables[0].Rows[0]["quyenso"].ToString(); ;
                asobienlai = adst.Tables[0].Rows[0]["sobienlai"].ToString();
                acucthue = lan.Change_language_MessageText("CỤC THUẾ");
                atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
                adiachibv = m_v.s_diachi;
                amabn = adst.Tables[0].Rows[0]["mabn"].ToString();
                string atmp = "";
                try
                {
                    atmp = (decimal.Parse(atongcp.ToString()) - decimal.Parse(atamung.ToString()) - decimal.Parse(abhyt.ToString())).ToString("###,###,##0");
                }
                catch
                {
                    atmp = "0";
                }

                if (atmp == "" || atmp.IndexOf("-") != -1) atmp = "0";

                achutien = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutien == "")
                {
                    achutien = lan.Change_language_MessageText("Không đồng");
                }

                try
                {
                    atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20, '.');
                    atmp = atmp.Substring(0, atmp.IndexOf("."));
                }
                catch
                {
                    atmp = "0";
                }
                //MessageBox.Show(atamung.Replace(",",""));
                if (atmp == "") atmp = "0";
                achutientu = m_v.Doiso_Unicode(atmp.Replace(",", ""));
                if (achutientu == "")
                {
                    achutientu = lan.Change_language_MessageText("Không đồng");
                }

                asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
                atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
                atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
                abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
                amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
                athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
                anopthem = decimal.Parse(anopthem.ToString()).ToString("###,###,##0.###");

                atmp = lan.Change_language_MessageText("- Tổng chi phí:") + " " + atongcp;
                if (atamung != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Tạm ứng:") + " " + atamung;
                }
                if (abhyt != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BHYT chi trả :") + " " + abhyt;
                }
                if (amien != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Miễn:") + " " + amien;
                }
                if (athieu != "0")
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Thiếu:") + " " + athieu;
                }
                if (alydomien1 != "")
                {
                    atmp += " (" + alydomien1 + ")";
                }
                decimal ahoan = decimal.Parse(atongcp) - decimal.Parse(atamung) - decimal.Parse(abhyt) - decimal.Parse(amien) - decimal.Parse(athieu);

                asotien = ahoan.ToString("###,###,##0.###");
                if (asotien.IndexOf("-") != -1)
                {
                    asotien = "0";
                    achutien = lan.Change_language_MessageText("Không đồng");
                }
                if (ahoan < 0)
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- Hoàn lại:") + " " + (-1 * ahoan).ToString("###,###,###.###");
                    if (anopthem != "0")
                    {
                        atmp += " " + lan.Change_language_MessageText("(Chưa hoàn)");
                    }
                }
                else
                {
                    atmp = atmp + "\n" + lan.Change_language_MessageText("- BN cùng chi trả :") + " " + ahoan.ToString("###,###,###.###");
                }
                alydomien = atmp;

                DataSet ads = f_Cursor_BienlaiNGT();
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["syt"] = asyt;
                    r["bv"] = abv;
                    r["diachibv"] = adiachibv;
                    r["tongcucthue"] = atongcuc;
                    r["cucthue"] = acucthue;
                    r["masothue"] = v_masothue; //amasothue;
                    r["mauso"] = amauso;
                    r["quyenso"] = v_quyenso;
                    r["sobienlai"] = v_sobienlai;
                    r["ngayin"] = angayin;
                    r["nguoiin"] = anguoiin;
                    r["ghichu"] = aghichu;
                    r["lien"] = rl["ten"].ToString().Trim();
                    r["mabn"] = amabn;
                    r["hoten"] = ahoten;
                    r["ngaysinh"] = angaysinh;
                    r["gioitinh"] = agioitinh;
                    r["khoa"] = akhoa;
                    r["diachi"] = adiachi;
                    r["lydo"] = alydo;
                    r["sotien"] = asotien;
                    r["chutien"] = achutien;
                    r["tongcp"] = atongcp;
                    r["tamung"] = atamung;
                    r["bhyt"] = abhyt;
                    r["mien"] = amien;
                    r["lydomien"] = alydomien;
                    r["nguoithu"] = anguoithu;
                    r["sothe"] = s_sothe;
                    r["id"] = v_id;
                    if (bInchuky)
                    {
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                            r["image"] = image;
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                //
                foreach (DataRow r2 in adst.Tables[0].Rows)
                {
                    DataRow r1 = ads.Tables[1].NewRow();
                    r1["mavp"] = r2["id_vp"];
                    r1["madoituong"] = r2["madoituong"];
                    r1["id_loaivp"] = r2["id_loai"];
                    r1["id_nhomvp"] = r2["id_nhom"];
                    r1["loaivp"] = r2["tenloaivp"];
                    r1["nhomvp"] = r2["tennhomvp"];
                    r1["sotien"] = r2["sotienct"];
                    r1["vat"] = 0;// vat;
                    r1["id"] = v_id;
                    r1["gia_dv"] = r2["gia_dv"].ToString();
                    r1["gia_bh"] = r2["gia_bh"].ToString();
                    r1["hangsx"] = r2["hangsx"].ToString();
                    r1["nuocsx"] = r2["nuocsx"].ToString();
                    ads.Tables[1].Rows.Add(r1);
                }
                //

                ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphi_BHYT.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai thu viện phí BHYT Ngoại trú (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;

                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    this.ShowDialog(this.Parent);
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void f_Print_Bienlaitaichinh_chitiet(bool v_dir, string v_id, string v_mmyy)
        {
            try
            {
                string aReport = "v_bltc_chitiet.rpt"; // "v_bienlaitaichinh_chitiet.rpt";
                DataSet ads = new DataSet();
                string sql = "", asyt = "", abv = "", adiachibv = "";

                sql = "select c.hoten as tenbn,c.namsinh,c.phai,c.cmnd,a.tendv,a.dcnhan,a.nguoinhan,"+
                    "a.diachi as dcdonvi,a.masothue,d.ten as tenvp,b.soluong,b.dongia,b.sotien,b.vat,"+
                    "b.madoituong,b.bhyt,f.ma as idnhom,e.id as id_loai,d.dvt,g.tenpxa ||','||h.tenquan||"+
                    "','|| i.tentt as diachibn from medibvmmyy.v_bienlaitaichinhll a inner join "+
                    "medibvmmyy.v_bienlaitaichinhct b on a.id=b.id inner join medibv.btdbn c on a.mabn=c.mabn "+
                    "inner join medibv.v_giavp d on b.mavp=d.id inner join medibv.v_loaivp e on d.id_loai=e.id "+
                    " inner join medibv.v_nhomvp f on e.id_nhom=f.ma inner join medibv.btdpxa g on "+
                    "c.maphuongxa=g.maphuongxa inner join medibv.btdquan h on c.maqu=h.maqu inner join "+
                    "medibv.btdtt i on c.matt=i.matt where a.done=1 and a.id="+v_id;

                ads = m_v.get_data_mmyy(v_mmyy, sql);
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy chứng từ ")+ v_id +".");
                    return;
                }
               
                if (bInchuky)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(new DataColumn("image", typeof(byte[])));
                        if (File.Exists("..\\..\\chukyvienphi\\" + m_userid + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\chukyvienphi\\" + m_userid + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                        }
                    }
                    catch
                    {
                    }
                }

                asyt = m_v.Syte;
                abv = m_v.Tenbv;
                adiachibv = m_v.s_diachi;

                ads.WriteXml("..\\..\\datareport\\v_bltc_chitiet.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                //cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv + "'";
                //cMain.DataDefinition.FormulaFields["v_diachibv"].Text = "'" + adiachibv + "'";
                //cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt + "'";
                
                cMain.SetDataSource(ads);

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai tài chính (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;

                    this.WindowState = FormWindowState.Maximized;
                    //this.TopMost = true;
                    this.ShowDialog();
                }
                else
                {
                    cMain.PrintToPrinter(1, false, 0, 0);
                }
                cMain.Close(); cMain.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}