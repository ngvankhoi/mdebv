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
using LibMedi;

namespace Vienphi
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
        private string m_report_thutructiep_dacthu = "v_bienlaithuvienphitt.rpt";
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
        private DataSet ads;
        private string aReport = "";
        

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
                m_report_thutructiep_gtgt = m_v.sys_report_thutructiep_gtgt;
                m_report_thutructiep_thuong = m_v.sys_report_thutructiep_thuong;
                m_report_thutructiep_dacthu = m_v.sys_report_thutructiep_dacthu;
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
                ads.Tables[0].Columns.Add("dtnha");
                ads.Tables[0].Columns.Add("dtdidong");
                ads.Tables[0].Columns.Add("dtcoquan");
                ads.Tables[0].Columns.Add("id", typeof(decimal));
                //
                ads.Tables.Add("Chitiet");
                ads.Tables[1].Columns.Add("madoituong", typeof(int));
                ads.Tables[1].Columns.Add("mavp", typeof(int));
                ads.Tables[1].Columns.Add("tenvp");
                ads.Tables[1].Columns.Add("dongia", typeof(decimal));
                ads.Tables[1].Columns.Add("soluong", typeof(decimal));
                ads.Tables[1].Columns.Add("id_loaivp", typeof(int));
                ads.Tables[1].Columns.Add("loaivp");
                ads.Tables[1].Columns.Add("id_nhomvp", typeof(int));
                ads.Tables[1].Columns.Add("nhomvp");
                ads.Tables[1].Columns.Add("sotien", typeof(decimal));
                ads.Tables[1].Columns.Add("vat", typeof(decimal));
                ads.Tables[1].Columns.Add("mien", typeof(decimal));
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
        public void f_Print_BienlaiKB(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string nhom_gtgt, bool v_bdichvu, string v_sttkham, string v_userid)
        {
            string acur = System.Environment.CurrentDirectory;
            string aReport = m_report_thutructiep_dacthu;
            try
            {
                try
                {
                    string sql = "", sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());
                    DataSet adst = null;

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,to_char(d.ngaysinh,'dd/mm/yyyy') as ngaysinh, ";
                    sql += " case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt, ";
                    sql += " case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden, ";
                    sql += " e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa,";
                    sql += " i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp, j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp, ";
                    sql += " k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia, b.soluong*b.dongia as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end as tongmien, ";
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong, a.bacsi as bacsichidinh, b.mabs as bacsithuchien";
                    sql += ",i.gia_bh, i.gia_dv,g1.sovaovien,g1.ngay as ngayvao,pk.chandoan,pk.maicd ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                    sql += " left join medibvmmyy.tiepdon g1 on a.mavaovien=g1.mavaovien and a.maql=g1.maql ";
                    sql += " left join medibvmmyy.benhanpk pk on a.mavaovien=pk.mavaovien and a.maql=pk.maql ";
                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, round(gvp.gia_bh,2) as gia_bh, round(gvp." + sfield_gia + ",2) as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    //gam sua 04-08-2011 sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(decode(bd.gia_bh,0, bd.dongia, bd.gia_bh),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    //sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(to_number(decode(bd.gia_bh,0, bd.dongia, bd.gia_bh)),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(to_number(case when bd.gia_bh=0 then bd.dongia else bd.gia_bh end),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";//gam 23/03/2012
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
                    string asyt = "", abv = "", adiachibv = "", adiachi = "", angaysinh="", angaythu="";//, angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "",  anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "",  akhoact = "";
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
                    
                    int atuoi = 0;
                    atuoi = DateTime.Now.Year - int.Parse(adst.Tables[0].Rows[0]["namsinh"].ToString());
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    angaythu = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    adst.Tables[0].Columns.Add(new DataColumn("thangtuoi", typeof(string)));
                    if (atuoi <= 6 && angaysinh != "")
                    {
                        LibMedi.AccessData m = new LibMedi.AccessData();
                        long songay = m.songay(m.StringToDate(angaythu), m.StringToDate(angaysinh.Substring(0,10)), 0);
                        long sothang = songay / 30;
                        foreach (DataRow r in adst.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
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
                    //sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(decode(bd.gia_bh,0, bd.dongia, bd.gia_bh),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round((case when bd.gia_bh=0 then bd.dongia else bd.gia_bh end ),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";//gam 23/03/2012

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

        public void f_Print_BienlaiKB_cuuuuu(bool v_dir, string v_id, string v_mmyy, string v_loaibl, string nhom_gtgt, bool v_bdichvu, string v_sttkham, string v_userid)
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
                    //sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(decode(bd.gia_bh,0, bd.dongia, bd.gia_bh),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round((case when bd.gia_bh=0 then bd.dongia else bd.gia_bh end),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";

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
                    sql += ",i.gia_bh, i.gia_dv,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngaycd ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c ";
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";

                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, round(gvp.gia_bh,2) as gia_bh, round(gvp." + sfield_gia + ",2) as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    //sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round(decode(bd.gia_bh,0, bd.dongia, bd.gia_bh),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, round((case when bd.gia_bh=0 then bd.dongia else bd.gia_bh end),2) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";

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
                    sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";

                    //sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                    //sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";

                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, round(gvp.gia_bh,2) as gia_bh, round(gvp."+sfield_gia+",2) as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    //sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, to_number(decode(bd.gia_bh,0, round(bd.dongia,2),round(bd.gia_bh,2))) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, (case when bd.gia_bh=0 then round(bd.dongia,2) else round(bd.gia_bh,2) end) as gia_bh, round(bd.giaban,2) as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";

                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0";
                    if (nhom_gtgt != "") sql += " and i.nhomvp not in (" + nhom_gtgt.Substring(0, nhom_gtgt.Length - 1) + ")";
                    sql += " order by e.tenkp";
                    if (v_mmyy == "")
                    {
                        v_mmyy = DateTime.Now.Year.ToString().Substring(2);
                    }
                    adst = m_v.get_data_mmyy(v_mmyy, sql);
                    string tenkp = "",n_tenkp="";
                    if(adst.Tables[0].Rows.Count > 0)
                    {
                        foreach(DataRow r_kp in adst.Tables[0].Rows)
                        {
                            if (tenkp != r_kp["tenkpct"].ToString())
                            {
                                n_tenkp += r_kp["tenkpct"].ToString() + ",";
                                tenkp = r_kp["tenkpct"].ToString();
                            }
                        }
                        foreach (DataRow r_kp1 in adst.Tables[0].Rows)
                        {
                            r_kp1["tenkp"] = n_tenkp.TrimEnd(',');
                        }
                    }
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
                    //sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(case when(gia_bh=0 then dongia else gia_bh end),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
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

                    sql = " select a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt as tinh, "+
                        "g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,"+
                        "to_char(d.ngaysinh,'dd/mm/yyyy') as ngaysinh,d.namsinh, e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct," +
                        "f.tentt,g.tenquan,tenpxa, j.id as id_loai, j.ten as tenloaivp,  j.stt as sttloaivp,"+
                        "sum(b.soluong*b.dongia) as sotien, 0 as bhtra, b.mien, b.thieu, case when c.sotien is null"+
                        " then 0 else c.sotien end as tongmien,  b.madoituong, m.hoten as nguoithu,b.tra as hoantra,"+
                        "a.ghichu,h1.sovaovien ";
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id ";
                    sql += " inner join medibv.v_quyenso bb on a.quyenso=bb.id  ";
                    sql += " left join medibvmmyy.v_mienngtru c  on a.id=c.id ";
                    sql += " left join medibv.btdbn d on a.mabn=d.mabn ";
                    sql += " left join medibv.btdkp_bv e on a.makp=e.makp";
                    sql += " left join medibv.btdtt f on d.matt=f.matt ";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                    sql += " left join medibvmmyy.tiepdon h1 on a.mavaovien=h1.mavaovien and a.maql=h1.maql ";
                    //sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round((case when gia_bh=0 then dongia else gia_bh end),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    sql += " left join  medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma ";
                    sql += " where a.id=" + v_id;
                    sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt , g.tenquan ,h.tenpxa , d.sonha, d.thon, n.ten ,a.lanin+1 ,a.namsinh,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') , e.tenkp ,f.tentt,g.tenquan,tenpxa, j.id , j.ten ,  j.stt , b.mien, b.thieu, case when c.sotien is null then 0 else c.sotien end ,  b.madoituong, m.hoten,b.tra,a.ghichu,d.ngaysinh,h1.sovaovien  ";

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

                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", akhoact = "",angaythu="";
                    int ituoi=0;
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
                    angaythu = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    ituoi = DateTime.Now.Year - int.Parse(adst.Tables[0].Rows[0]["namsinh"].ToString());
                    try { adst.Tables[0].Columns.Add("thangtuoi"); }
                    catch { }
                    //Thêm tháng tuổi
                    if (ituoi <= 6 && angaysinh != "")
                    {
                        LibMedi.AccessData m = new LibMedi.AccessData();
                        long songay = m.songay(m.StringToDate(angaythu), m.StringToDate(angaysinh), 0);
                        long sothang = songay / 30;
                        foreach (DataRow r in adst.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
                    }
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
                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv.Replace("'","") + "'";//gam 08/11/2011
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
                    //sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round("+sfield_gia+",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round((case when gia_bh=0 then dongia else gia_bh end),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
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
                    //sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
                    sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) as gia_dv from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten,  dang as dvt, 0 as id_loai, round((case when gia_bh=0 then dongia else gia_bh end),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id ";
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
                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv.Replace("'","") + "'";//gam 08/11/2011
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
                //sql += " dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " dang as dvt, 0 as id_loai, round((case when gia_bh=0 then dongia else gia_bh end),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id left join  ";
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
                //sql += " dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " dang as dvt, 0 as id_loai, round(case when gia_bh=0 then dongia else gia_bh end),2) as gia_bh, round(giaban,2) as gia_dv from medibv.d_dmbd) i on b.mavp=i.id left join  ";
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
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu, i.gia_bh, i.gia_dv,cc.ten as tenphongcls,a.thanhtoan, '" + m_v.s_diachi + "' as diachibv,d.msthue,d.cholam ,b.sttcho, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngaycd,b.vat,a.lanin ";
                sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                sql += " left join medibvmmyy.v_mienngtru c on a.id=c.id ";
                sql += " left join medibv.dmphongthuchiencls cc on b.idphongcls=cc.id ";
                sql += " left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai, round(gia_bh,2) as gia_bh, round(" + sfield_gia + ",2) gia_dv,'' as hamluong from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                //sql += " dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv,hamluong from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " dang as dvt, 0 as id_loai, round((case when gia_bh=0 then dongia else gia_bh end),2) as gia_bh, round(giaban,2) as gia_dv,hamluong from medibv.d_dmbd) i on b.mavp=i.id left join  ";
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
                abv = m_v.Tenbv.Replace("'","");

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
                m_v.execute_data_mmyy(v_mmyy, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where id=" + v_id);

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
                //sql += " dang as dvt, 0 as id_loai, round(decode(gia_bh,0, dongia,gia_bh),2) as gia_bh, round(giaban,2) as gia_dv,hamluong from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " dang as dvt, 0 as id_loai, round((case when gia_bh=0 then dongia else gia_bhend),2) as gia_bh, round(giaban,2) as gia_dv,hamluong from medibv.d_dmbd) i on b.mavp=i.id left join  ";
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
                    sql += " k.stt as sttnhomvp, i.dvt, sum(b.soluong) as soluong, b.dongia, sum(b.soluong*b.dongia) as sotien, 0 as bhtra,case when b.khuyenmai <= 0 then b.mien else 0 end as mien , case when b.khuyenmai > 0 then b.mien else 0 end as khuyenmai  , b.thieu, case when b.khuyenmai <= 0 then case when c.sotien<>0 then c.sotien else 0 end  else 0 end as tongmien, case when b.khuyenmai > 0 then sum(b.mien) else 0 end as tongkhuyenmai, ";
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
                    sql += "group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt, g.tenquan ,h.tenpxa , d.sonha, d.thon, n.ten ,a.lanin+1 ,a.namsinh ,l.sothe,l.denngay,e.tenkp,a.ngay,e.tenkp,f.tentt,g.tenquan,tenpxa, i.id, j.id,k.ma, i.ten,j.ten,k.ten,i.stt,j.stt,k.stt,i.dvt, b.dongia,b.khuyenmai,b.thieu, b.madoituong, m.hoten,b.tra ,a.ghichu,z.doituong, i.gia_th, i.gia_bh, i.gia_dv ,b.mien, c.sotien";
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

                    string aReport = m_report_thutructiep;
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
                    sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,z.doituong, i.gia_th, i.gia_bh, i.gia_dv,dthoai.nha as dtnha,dthoai.coquan as dtcoquan,dthoai.didong as dtdidong ";
                    //
                    sql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                    sql += " left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.dienthoai dthoai on a.mabn=dthoai.mabn ";
                    sql += " left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                    sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                    sql += " left join (select gvp.id, gvp.stt, gvp.ten, gvp.dvt, gvp.id_loai,lvp.id_nhom as nhomvp, gvp.gia_th, gvp.gia_bh, gvp." + sfield_gia + " as gia_dv from medibv.v_giavp gvp,medibv.v_loaivp lvp where gvp.id_loai=lvp.id ";
                    sql += " union select bd.id, 1 as stt, trim(bd.ten||' '|| bd.hamluong) as ten, ";
                    sql += " bd.dang as dvt, 0 as id_loai,dmn.nhomvp, bd.giaban as gia_th, bd.gia_bh as gia_bh, bd.giaban as gia_dv from medibv.d_dmbd bd,medibv.d_dmnhom dmn where bd.manhom=dmn.id) i on b.mavp=i.id left join  ";
                    sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                    sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong";
                    sql += " where a.id=" + v_id + " and b.tra<=0 ";
                    sql += "group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt, g.tenquan ,h.tenpxa , d.sonha, d.thon, n.ten ,a.lanin+1 ,a.namsinh ,l.sothe,l.denngay,e.tenkp,a.ngay,e.tenkp,f.tentt,g.tenquan,tenpxa, i.id, j.id,k.ma, i.ten,j.ten,k.ten,i.stt,j.stt,k.stt,i.dvt,b.soluong, b.dongia,b.khuyenmai,b.thieu, b.madoituong, m.hoten,b.tra ,a.ghichu,z.doituong, i.gia_th, i.gia_bh, i.gia_dv ,b.mien,c.sotien,b.stt,dthoai.nha,dthoai.coquan,dthoai.didong ";
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
                        adiengiai = "", akhoact = "", sohieuquyenso = "", aloaivp = "", v_sttkham = "", adtnha = "", adtcoquan = "", adtdidong = "";

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv.Replace("'","");//gam 08/11/2011
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
                    //
                    adtnha = adst.Tables[0].Rows[0]["dtnha"].ToString();
                    adtdidong = adst.Tables[0].Rows[0]["dtdidong"].ToString();
                    adtcoquan = adst.Tables[0].Rows[0]["dtcoquan"].ToString();
                    //
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
                        r["dtnha"] = adtnha;
                        r["dtdidong"] = adtdidong;
                        r["dtcoquan"] = adtcoquan;
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
                        r1["vat"] = 0;
                        r1["mien"] = r2["mien"];
                        r1["id"] = v_id;
                        r1["gia_dv"] = r2["gia_dv"].ToString();
                        r1["gia_bh"] = r2["gia_bh"].ToString();
                        r1["dongia"] = r2["dongia"].ToString();
                        r1["soluong"] = r2["soluong"].ToString();
                        r1["tenvp"] = r2["tenvp"].ToString();
                        ads.Tables[1].Rows.Add(r1);
                    }
                    #endregion

                    ads.WriteXml("..\\..\\Datareport\\v_hoadonthutructiep.xml", XmlWriteMode.WriteSchema);
                    cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport1, OpenReportMethod.OpenReportByTempCopy);

                    cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                    cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                    cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";

                    cMain.SetDataSource(ads);
                    string v_sobanin = m_v.tt_sobanin_hoadonct(m_userid);
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.ReportSource = cMain;
                        this.WindowState = FormWindowState.Maximized;
                        this.Text = lan.Change_language_MessageText("In biên lai thu viện phí trực tiếp") + " (" + aReport1 + ")";
                        //this.TopMost = true;
                        banin.Value = (v_sobanin == "") ? 1 : int.Parse(v_sobanin);
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
                        athucthu = decimal.Parse(decimal.Parse(athucthu.ToString()).ToString());
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
                        athucthu = decimal.Parse(decimal.Parse(athucthu.ToString()).ToString());
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
                ads.Tables[0].Columns.Add("doituong");//Thuy 24.04.2012
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
                sql = "select  a.id, a.mabn, a.sobienlai, a.sotien, case when a1.sotien is null then 0 "+
                " else a1.sotien end as sotienct, a2.ten as tenloaivp, to_char(a.ngay,'dd/mm/yyyy') as ngay,"+
                "b.tenkp, d.mabn, d.hoten, case when d.ngaysinh is null then d.namsinh else "+
                " to_char(d.ngaysinh,'dd/mm/yyyy') end as ngaysinh, e.ten as gioitinh,  f.tentt,"+
                " g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu,"+
                " i.sohieu as quyenso, a.lanin+1 as lanin, a0.doituong from medibvmmyy.v_tamung a inner join medibv.doituong a0"+
                " on a.madoituong=a0.madoituong left join "+//Thuy 24.04.2012
                " medibvmmyy.v_tamungct a1 on a.id=a1.id left join medibv.v_loaivp a2 on a1.loaivp=a2.id "+
                " left join medibv.btdkp_bv b on a.makp=b.makp left join medibv.btdbn d on a.mabn=d.mabn "+
                " left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt "+
                " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h "+
                " on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id "+
                " left join medibv.v_dlogin j on a.userid=j.id where a.id=" + v_id + "";
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

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", alanin = "1", aReport = "", adoituong="";
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
                adoituong = adst.Tables[0].Rows[0]["doituong"].ToString();

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
                    r["doituong"] = adoituong;
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
                ads.Tables[0].Columns.Add("sothe");
                ads.Tables[0].Columns.Add("noicap");
                ads.Tables[0].Columns.Add("tu");
                ads.Tables[0].Columns.Add("den");
                ads.Tables[0].Columns.Add("traituyen");
                ads.Tables[0].Columns.Add("ngayvv"); 

                

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
                ads.Tables[1].Columns.Add("dongia", typeof(decimal));
                ads.Tables[1].Columns.Add("soluong", typeof(decimal));
                ads.Tables[1].Columns.Add("bhyttra_ct",typeof(decimal));
                //khuyen them 30/11/2013
                ads.Tables[1].Columns.Add("ngoaidanhmuc", typeof(decimal));
                //
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

                    //sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, ds.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,d.namsinh as ngaysinh,  case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt,";
                    //sql += "case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp,";
                    //sql += "j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp,  k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,giamua, b.soluong*b.dongia as sotien, ";
                    //sql += "a.bhyt as bhtra, a.mien, a.thieu,a.mien as tongmien,  b.madoituong, m.hoten as nguoithu,0 as hoantra,ds.chandoan as ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong";
                    //sql += ", i.gia_bh, i.gia_dv, i.gia_th, a.tamung ";
                    //sql += ", i.hangsx, i.nuocsx ";
                    //sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                    //sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                    //sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";//binh thay a.makp thanh b.makp
                    //sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                    //sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join (select id, stt, ten, dvt, id_loai, gia_bh, " + sfield_gia + " as gia_dv, gia_th, null as hangsx, null as nuocsx from medibv.v_giavp union select a.id, 1 as stt, a.ten|| case when a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt, 0 as id_loai, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, b.ten as nuocsx, c.ten as hangsx from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id left join medibv.d_dmnuoc c on a.manuoc=c.id) i on b.mavp=i.id ";
                    //sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                    //sql += " left join  medibv.bhyt l on ds.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong ";
                    //sql += " where ds.id=" + v_id + "";
                    //KHUYEN THEM 06/01/2014
                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, ds.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,to_char(d.ngaysinh,'dd/mm/yyyy') as ngaysinh,  case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt,";
                    sql += "case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp,";
                    sql += "j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp,  k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,giamua, b.soluong*b.dongia as sotien, ";
                    sql += "a.bhyt as bhtra, a.mien, a.thieu,a.mien as tongmien,  b.madoituong, m.hoten as nguoithu,0 as hoantra,ds.chandoan as ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong";
                    sql += ", i.gia_bh, i.gia_dv, i.gia_th, a.tamung ";
                    // khuyen them 26/12/2013
                    sql += ", a.nopthem,a.thua ";
                    //
                    sql += ", i.hangsx, i.nuocsx,b.bhyttra as bhyttra_ct ";
                    sql += ", i.vat, to_char(ds.ngayvao,'dd/mm/yyyy') as tungay,to_char(dt2.ngay,'dd/mm/yyyy') as denngay,dt1.sovaovien,l.traituyen,x.tenbv ";
                    sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                    sql += " inner join medibv.benhandt dt1 on ds.maql=dt1.maql ";
                    sql += " inner join medibv.xuatvien dt2 on ds.maql=dt2.maql ";
                    sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                    sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";//binh thay a.makp thanh b.makp
                    sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join ";
                    sql += " (select a.id, a.stt, a.ten, a.dvt, a.id_loai,b.id_nhom, a.gia_bh, " + sfield_gia + " as gia_dv, a.gia_th, null as hangsx,";
                    sql += " null as nuocsx,a.vat from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id union select a.id, 1 as stt, a.ten|| case when ";
                    sql += " a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt,";
                    sql += " 0 as id_loai,d.nhomvp as id_nhom, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, b.ten as nuocsx, ";
                    sql += " c.ten as hangsx,a.vat from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id ";
                    sql += " left join medibv.d_dmnuoc c on a.manuoc=c.id left join medibv.d_dmnhom d on a.manhom=d.id) i on b.mavp=i.id ";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on i.id_nhom=k.ma left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join  medibv.bhyt l on ds.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong ";
                    sql += " left join medibv.dmnoicapbhyt x on x.mabv=l.mabv ";
                    if (v_loaibl == "3")
                    {
                        sql += " where ds.maql=" + v_id + "";
                    }
                    else
                    {
                        sql += " where ds.id=" + v_id + "";
                    }
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
                    
                    //
                    try { adst.Tables[0].Columns.Add("lien"); }
                    catch { }
                    m_dslien = m_v.f_get_solien();
                    if (m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt").Length > 0)
                    {
                        string sLien = "";
                        foreach (DataRow drlien in m_dslien.Tables[0].Select("tenreport='" + aReport + "' and stt=1", "stt"))
                        {
                            sLien = drlien["ten"].ToString();
                            break;
                        }
                        foreach (DataRow dr0 in adst.Tables[0].Rows)
                        {
                            dr0["lien"] = sLien;
                        }
                        adst.AcceptChanges();
                    }
                    adst.WriteXml("..\\..\\Datareport\\" + aReport.Substring(0, aReport.Length - 4) + ".xml", XmlWriteMode.WriteSchema);
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
                    if (m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt").Length > 1)
                    {
                        string sLien = "";
                        foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                        {
                            foreach (DataRow drlien in m_dslien.Tables[0].Select("tenreport='" + aReport + "' and stt=2 ", "stt"))
                            {
                                sLien = drlien["ten"].ToString();
                            }
                            foreach (DataRow dr0 in adst.Tables[0].Rows)
                            {
                                dr0["lien"] = sLien;
                            }
                            adst.AcceptChanges();
                        }
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
                    }
                    //
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

                    sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, ds.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,to_char(d.ngaysinh,'dd/mm/yyyy') as ngaysinh,  case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt,";
                    sql += "case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp,";
                    sql += "j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp,  k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,giamua, b.soluong*b.dongia as sotien, ";
                    sql += "a.bhyt as bhtra, a.mien, a.thieu,a.mien as tongmien,  b.madoituong, m.hoten as nguoithu,0 as hoantra,ds.chandoan as ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong";
                    sql += ", i.gia_bh, i.gia_dv, i.gia_th, a.tamung ";
                   // khuyen them 26/12/2013
                    sql += ", a.nopthem,a.thua ";
                    //
                    sql += ", i.hangsx, i.nuocsx,b.bhyttra as bhyttra_ct ";
                    sql += ", i.vat, to_char(ds.ngayvao,'dd/mm/yyyy') as tungay,to_char(dt2.ngay,'dd/mm/yyyy') as denngay,dt1.sovaovien,l.traituyen,x.tenbv ";
                    sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                    sql += " inner join medibv.benhandt dt1 on ds.maql=dt1.maql ";
                    sql += " left join medibv.xuatvien dt2 on ds.maql=dt2.maql ";
                    sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                    sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";//binh thay a.makp thanh b.makp
                    sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                    sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join ";
                    sql += " (select a.id, a.stt, a.ten, a.dvt, a.id_loai,b.id_nhom, a.gia_bh, " + sfield_gia + " as gia_dv, a.gia_th, null as hangsx,";
                    sql += " null as nuocsx,a.vat from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id union select a.id, 1 as stt, a.ten|| case when ";
                    sql += " a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt,";
                    sql += " 0 as id_loai,d.nhomvp as id_nhom, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, b.ten as nuocsx, ";
                    sql += " c.ten as hangsx,a.vat from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id ";
                    sql += " left join medibv.d_dmnuoc c on a.manuoc=c.id left join medibv.d_dmnhom d on a.manhom=d.id) i on b.mavp=i.id ";
                    sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on i.id_nhom=k.ma left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                    sql += " left join  medibv.bhyt l on ds.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong ";
                    sql += " left join medibv.dmnoicapbhyt x on x.mabv=l.mabv ";
                    if (v_loaibl == "3")
                    {
                        sql += " where ds.maql=" + v_id + "";
                    }
                    else
                    {
                        sql += " where ds.id=" + v_id + "";
                    }

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
                    string angaysinh = "", angaythu = "",anamsinh="";
                    int atuoi = 0;
                    angaysinh = adst.Tables[0].Rows[0]["ngaysinh"].ToString();
                    angaythu = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                    anamsinh = adst.Tables[0].Rows[0]["namsinh"].ToString();
                    atuoi = DateTime.Now.Year - int.Parse(anamsinh);
                    try{adst.Tables[0].Columns.Add("thangtuoi");}catch{}
                    //Thêm tháng tuổi
                    if (atuoi <= 6 && angaysinh != "")
                    {
                        LibMedi.AccessData m = new LibMedi.AccessData();
                        long songay = m.songay(m.StringToDate(angaythu), m.StringToDate(angaysinh), 0);
                        long sothang = songay / 30;
                        foreach (DataRow r in adst.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
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
                    try { adst.Tables[0].Columns.Add("lien"); }
                    catch { }
                    m_dslien = m_v.f_get_solien();
                    if (m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt").Length > 0)
                    {                        
                        string sLien="";
                        foreach (DataRow drlien in m_dslien.Tables[0].Select("tenreport='" + aReport + "' and stt=1", "stt"))
                        {
                            sLien = drlien["ten"].ToString();
                            break;
                        }
                        foreach (DataRow dr0 in adst.Tables[0].Rows)
                        {
                            dr0["lien"] = sLien;
                        }
                        adst.AcceptChanges();
                    }
                    adst.WriteXml("..\\..\\Datareport\\" + aReport.Substring(0,aReport.Length - 4) + ".xml", XmlWriteMode.WriteSchema);
                    if (v_loaibl == "1")
                    {
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
                    }
                    if (File.Exists("..\\..\\..\\report\\v_bienlaithuvienphi_thuongnt_1.rpt") && (v_loaibl=="2" || v_loaibl=="3"))
                    {

                        cMain = new ReportDocument();

                        cMain.Load("..\\..\\..\\report\\v_bienlaithuvienphi_thuongnt_1.rpt", OpenReportMethod.OpenReportByTempCopy);

                        cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                        cMain.DataDefinition.FormulaFields["adiachibv"].Text = "'" + adiachibv + "'";
                        cMain.DataDefinition.FormulaFields["adiachi"].Text = "'" + adiachi + "'";
                        cMain.DataDefinition.FormulaFields["atiendichvu"].Text = "'" + atiendichvu + "'";
                        cMain.SetDataSource(adst);

                        if (!v_dir)
                        {
                            this.crystalReportViewer1.ReportSource = cMain;
                            this.WindowState = FormWindowState.Maximized;
                            this.Text = lan.Change_language_MessageText("Phiếu thanh toán viện phí") + "(v_bienlaithuvienphi_thuongnt_1.rpt)";
                            this.TopMost = true;
                            this.ShowDialog(this.Parent);
                        }
                        else
                        {
                            cMain.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    if (m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt").Length > 1)
                    {
                        string sLien = "";
                        foreach (DataRow rl in m_dslien.Tables[0].Select("tenreport='" + aReport + "'", "stt"))
                        {
                            foreach (DataRow drlien in m_dslien.Tables[0].Select("tenreport='" + aReport + "' and stt=2 ", "stt"))
                            {
                                sLien = drlien["ten"].ToString();
                            }
                            foreach (DataRow dr0 in adst.Tables[0].Rows)
                            {
                                dr0["lien"] = sLien;
                            }
                            adst.AcceptChanges();
                        }
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
                sql += " ,(b.sotien-b.bhyt-b.mien-b.thieu+b.nopthem) as sotien, b.tamung, b.mien, b.thieu, b.bhyt , b.nopthem, b.thua, p.ten as lydomien, b.lanin+1 as lanin,k.dongia,p1.sothe,p1.tungay,p1.denngay,p2.tenbv as noicapbhyt,a.ngayvao as ngayvv,p1.traituyen ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on k.mavp=dm.id left join  medibv.btdkp_bv c on k.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.d_dmnhom m on dm.manhom=m.id inner join medibv.v_nhomvp l on m.nhomvp=l.ma left join medibvmmyy.v_miennoitru o on b.id=o.id left join medibv.v_lydomien p on o.lydo=p.id left join" +
                 " medibv.bhyt p1 on p1.maql=a.maql left join medibv.dmnoicapbhyt p2 on p1.mabv=p2.mabv ";
                sql += " where a.id=" + v_id;
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as tongcp , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,k.soluong, k.mavp as id_vp,k.sotien-k.bhyttra sotienct, dm.id_loai as id_loai, n.ten as tenloaivp, n.id_nhom as id_nhom, l.ten tennhomvp, k.madoituong   ";
                sql += " ,(b.sotien-b.bhyt-b.mien-b.thieu+b.nopthem) as sotien, b.tamung, b.mien, b.thieu, b.bhyt , b.nopthem, b.thua, p.ten as lydomien, b.lanin+1 as lanin,k.dongia,p1.sothe,p1.tungay,p1.denngay,p2.tenbv as noicapbhyt,a.ngayvao as ngayvv,p1.traituyen ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id left join  medibv.btdkp_bv c on k.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.v_loaivp n on dm.id_loai=n.id inner join medibv.v_nhomvp l on n.id_nhom=l.ma left join medibvmmyy.v_miennoitru o on b.id=o.id left join medibv.v_lydomien p on o.lydo=p.id left join" +
                 " medibv.bhyt p1 on p1.maql=a.maql left join medibv.dmnoicapbhyt p2 on p1.mabv=p2.mabv ";
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

                string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", 
                    akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "",
                    amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", 
                    abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "", athua = "",asothe= "",atungay= "",adenngay= "",
                    atenbv = "",atraituyen = "",angayvv = "",atenkp = "";
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
                asothe = adst.Tables[0].Rows[0]["sothe"].ToString();
                atungay = adst.Tables[0].Rows[0]["tungay"].ToString();
                adenngay = adst.Tables[0].Rows[0]["denngay"].ToString();
                atenbv = adst.Tables[0].Rows[0]["noicapbhyt"].ToString();
                atraituyen = adst.Tables[0].Rows[0]["traituyen"].ToString();
                angayvv = adst.Tables[0].Rows[0]["ngayvv"].ToString();

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
                    r["sothe"] = asothe;
                    r["noicap"] = atenbv;
                    r["tu"]= atungay;
                    r["den"] = adenngay;
                    r["traituyen"] = atraituyen;
                    r["ngayvv"] = angayvv;
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
                    r1["dongia"] = r2["dongia"];
                    r1["soluong"] = r2["soluong"];
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
                sql += ", i.hangsx, i.nuocsx,b.bhyttra as bhyttra_ct";
                //khuyen them 30/12/2013
                sql += " ,case when i.bhyt<=0 then b.soluong*b.dongia else 0 end as ngoaidanhmuc ";
                //
                sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";
                sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
               //khuyen them cot bhyt trong bang v_giavp,d_dmbd
                sql += " left join (select id, stt, ten, dvt, id_loai, gia_bh, " + sfield_gia + " as gia_dv, gia_th, null as hangsx, null as nuocsx,bhyt from medibv.v_giavp union select a.id, 1 as stt, a.ten|| case when a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt, 0 as id_loai, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, c.ten as hangsx,b.ten as nuocsx,a.bhyt  from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id left join medibv.d_dmnuoc c on a.manuoc=c.id) i on b.mavp=i.id ";
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
                    r1["dongia"] = rct["dongia"].ToString();
                    r1["bhyttra_ct"] = rct["bhyttra_ct"].ToString();
                    r1["ngoaidanhmuc"] = rct["ngoaidanhmuc"].ToString();
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
                sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp, (a.sotien-a.bhyt-a.mien-a.thieu) as "+
                    "sotien , a.tamung, a.mien, a.thieu, a.bhyt , a.nopthem, to_char(a.ngay,'dd/mm/yyyy') as ngay,"+
                    "c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,"+
                    "h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, "+
                    "l.ten as lydomien, a.lanin+1 as lanin from medibvmmyy.v_ttrvll a left join "+
                    "medibvmmyy.v_ttrvds b on a.id=b.id left join medibv.btdkp_bv c on a.makp=c.makp left join "+
                    "medibv.btdbn d on b.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join "+
                    "medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join "+
                    "medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id "+
                    "left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id "+
                    "left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
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
                //khuyen them chi tiet 31/12/2013
                string sfield_gia = m_v.field_gia(m_v.iTunguyen.ToString());

                sql = "select a.id, a.quyenso, a.sobienlai, bb.sohieu, ds.mabn, d.hoten, d.namsinh, f.tentt as tinh, g.tenquan as quan,h.tenpxa as xa, d.sonha, d.thon, n.ten as gioitinh,a.lanin+1 as lanin,d.namsinh as ngaysinh,  case when l.sothe is null then '. . . . . . . . . . . . . . . . . .' else l.sothe end as mabhyt,";
                sql += "case when l.denngay is null then '. . . . . . . . . . . . . . . . . .' else to_char(l.denngay,'dd/mm/yyyy') end as giatriden,  e.tenkp, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, e.tenkp as tenkpct,f.tentt,g.tenquan,tenpxa, i.id as id_vp, j.id as id_loai, k.ma as id_nhom, i.ten as tenvp,";
                sql += "j.ten as tenloaivp, k.ten as tennhomvp, i.stt as sttvp, j.stt as sttloaivp,  k.stt as sttnhomvp, i.dvt, b.soluong, b.dongia,giamua, b.soluong*b.dongia as sotien, ";
                sql += "a.bhyt as bhtra, a.mien, a.thieu,a.mien as tongmien,  b.madoituong, m.hoten as nguoithu,0 as hoantra,ds.chandoan as ghichu,dt.nha,dt.coquan,dt.didong,dt.email,z.doituong";
                sql += ", i.gia_bh, i.gia_dv, i.gia_th, a.tamung ";
                sql += ", i.hangsx, i.nuocsx,b.bhyttra as bhyttra_ct";
                sql += " ,case when i.bhyt<=0 then b.soluong*b.dongia else 0 end as ngoaidanhmuc ";
                sql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id";
                sql += " left join medibvmmyy.v_miennoitru c  on a.id=c.id left join medibv.btdbn d on ds.mabn=d.mabn ";
                sql += " left join medibv.dienthoai dt on d.mabn=dt.mabn left join medibv.btdkp_bv e on b.makp=e.makp ";
                sql += " left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu ";
                sql += " left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
                sql += " left join (select id, stt, ten, dvt, id_loai, gia_bh, " + sfield_gia + " as gia_dv, gia_th, null as hangsx, null as nuocsx,bhyt from medibv.v_giavp union select a.id, 1 as stt, a.ten|| case when a.tenhc='' then '' else ' [ '||a.tenhc||' ] ' end ||''||  a.hamluong as ten,  a.dang as dvt, 0 as id_loai, a.gia_bh, a.giaban as gia_dv, a.giaban as gia_th, c.ten as hangsx,b.ten as nuocsx,a.bhyt  from medibv.d_dmbd a left join medibv.d_dmhang b on a.mahang=b.id left join medibv.d_dmnuoc c on a.manuoc=c.id) i on b.mavp=i.id ";
                sql += " left join (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma ";
                sql += " left join  medibv.bhyt l on ds.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma inner join medibv.doituong z  on b.madoituong=z.madoituong ";
                sql += " where ds.id=" + v_id + "";
                //
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
                    r1["dongia"] = rct["dongia"].ToString();
                    r1["bhyttra_ct"] = rct["bhyttra_ct"].ToString();
                    r1["ngoaidanhmuc"] = rct["ngoaidanhmuc"].ToString();
                    ads.Tables[1].Rows.Add(r1);
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
                ads.Tables[1].Columns.Add("tenbv");
                ads.Tables[1].Columns.Add("ngayvao");
                ads.Tables[1].Columns.Add("ngayra");
                ads.Tables[1].Columns.Add("traituyen");
                ads.Tables[1].Columns.Add("chandoan");
                ads.Tables[1].Columns.Add("maicd");
                ads.Tables[1].Columns.Add("tungay");
                ads.Tables[1].Columns.Add("denngay");
                ads.Tables[1].Columns.Add("namsinh");
                ads.Tables[1].Columns.Add("soluong");
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
                sql = " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, to_char(d.ngaysinh,'dd/mm/yyyy') as ngaysinh,d.namsinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) as soluong, k.mavp as id_vp, sum(k.sotien-k.bhyttra) sotienct, -1 as id_loai, null as tenloaivp, m.nhomvp as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm.giaban as gia_dv, hsx.ten as hangsx, nsx.ten as nuocsx,b.lanin ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.d_dmnhom m on dm.manhom=m.id inner join medibv.v_nhomvp l on m.nhomvp=l.ma left join medibv.d_dmhang hsx on dm.mahang=hsx.id left join medibv.d_dmnuoc nsx on dm.manuoc=nsx.id ";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt, b.nopthem , to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, g.tenquan,h.tenpxa, to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu, tamung, dm.ten, k.soluong, k.mavp, m.nhomvp, l.ten, k.madoituong, dm.gia_bh, dm.giaban, hsx.ten, nsx.ten,b.lanin,d.ngaysinh ";
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra, b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten, to_char(d.ngaysinh,'dd/mm/yyyy') as ngaysinh,d.namsinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) soluong, k.mavp as id_vp, sum(k.sotien-k.bhyttra) sotienct, dm.id_loai as id_loai, n.ten as tenloaivp, n.id_nhom as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm." + sfield_gia + " as gia_dv , null as hangsx, null as nuocsx,b.lanin  ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join medibv.v_dlogin j on b.userid=j.id inner join medibv.v_loaivp n on dm.id_loai=n.id inner join medibv.v_nhomvp l on n.id_nhom=l.ma ";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt, b.nopthem, to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu,tamung,dm.ten, k.mavp, dm.id_loai, n.ten, n.id_nhom, l.ten, k.madoituong, dm.gia_bh, dm." + sfield_gia+",b.lanin,d.ngaysinh ";

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
                string anamsinh = "",angaythu="";
                int atuoi = 0;
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
                anamsinh = adst.Tables[0].Rows[0]["namsinh"].ToString();
                angaythu = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                atuoi = DateTime.Now.Year - int.Parse(anamsinh);

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
                    ads.Tables[0].Columns.Add("thangtuoi");
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

                if (atuoi <= 6 && angaysinh != "")
                {
                    long songay = mdi.songay(mdi.StringToDateTime(angaythu), mdi.StringToDateTime(angaysinh), 0);
                    long sothang = songay / 30;
                    foreach (DataRow r in ads.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
                }

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
                sql = " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra,b.mien, b.nopthem as bntra, "+
                    "to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten,  "+
                    "to_char(d.ngaysinh,'dd/mm/yyyy') as ngaysinh, d.namsinh, e.ten as gioitinh,  "+
                    "f.tentt, g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, "+
                    "i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) as soluong, k.mavp as id_vp, "+
                    "sum(k.sotien-k.bhyttra) sotienct, -1 as id_loai, null as tenloaivp, m.nhomvp as id_nhom, "+
                    "l.ten tennhomvp, k.madoituong, dm.gia_bh, dm.giaban as gia_dv, hsx.ten as hangsx, "+
                    "nsx.ten as nuocsx,b.lanin,dmncbhyt.tenbv,a.ngayvao,a.ngayra,bh.traituyen,a.chandoan,a.maicd,"+
                    "bh.tungay,bh.denngay ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id  "+
                    "inner join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.d_dmbd dm on "+
                    "k.mavp=dm.id left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on "+
                    "a.mabn=d.mabn left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on "+
                    "d.matt=f.matt left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on "+
                    "d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join "+
                    "medibv.v_dlogin j on b.userid=j.id inner join medibv.d_dmnhom m on dm.manhom=m.id "+
                    "inner join medibv.v_nhomvp l on m.nhomvp=l.ma left join medibv.d_dmhang hsx on "+
                    "dm.mahang=hsx.id left join medibv.d_dmnuoc nsx on dm.manuoc=nsx.id ";
                sql += " left join (select traituyen,sothe,tungay,denngay,mabv,maql from medibvmmyy.bhyt " +
                    " union select traituyen,sothe,tungay,denngay,mabv,maql " +
                    " from medibv.bhyt) bh on a.maql=bh.maql  left join medibv.dmnoicapbhyt dmncbhyt " +
                    "on bh.mabv=dmncbhyt.mabv";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt,b.mien, b.nopthem , "+
                    "to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, "+
                    "g.tenquan,h.tenpxa, to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu, tamung, dm.ten, "+
                    "k.soluong, k.mavp, m.nhomvp, l.ten, k.madoituong, dm.gia_bh, dm.giaban, hsx.ten, nsx.ten,"+
                    "b.lanin,d.ngaysinh,dmncbhyt.tenbv,a.ngayvao,a.ngayra,bh.traituyen,a.chandoan,a.maicd,"+
                    "bh.tungay,bh.denngay ";
                sql += " union all";
                sql += " select a.id, a.mabn, b.sobienlai, b.sotien as sotien , b.bhyt as bhyttra,b.mien,"+
                    "b.nopthem as bntra, to_char(b.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn,  d.hoten,  "+
                    "to_char(d.ngaysinh,'dd/mm/yyyy') as ngaysinh,d.namsinh, e.ten as gioitinh,  f.tentt,"+
                    "g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, "+
                    "i.sohieu as quyenso,tamung,dm.ten,sum(k.soluong) soluong, k.mavp as id_vp, "+
                    "sum(k.sotien-k.bhyttra) sotienct, dm.id_loai as id_loai, n.ten as tenloaivp, "+
                    "n.id_nhom as id_nhom, l.ten tennhomvp, k.madoituong, dm.gia_bh, dm." + sfield_gia + " "+
                    "as gia_dv , null as hangsx, null as nuocsx,b.lanin ,dmncbhyt.tenbv,a.ngayvao,a.ngayra,bh.traituyen,a.chandoan,a.maicd," +
                    "bh.tungay,bh.denngay ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner "+
                    "join medibvmmyy.v_ttrvct k on a.id=k.id inner join medibv.v_giavp dm on k.mavp=dm.id "+
                    "left join  medibv.btdkp_bv c on b.makp=c.makp left join medibv.btdbn d on a.mabn=d.mabn "+
                    "left join  medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt "+
                    "left join  medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on "+
                    "d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on b.quyenso=i.id left join "+
                    "medibv.v_dlogin j on b.userid=j.id inner join medibv.v_loaivp n on dm.id_loai=n.id "+
                    "inner join medibv.v_nhomvp l on n.id_nhom=l.ma ";
                sql += " left join (select traituyen,sothe,tungay,denngay,mabv,maql from medibvmmyy.bhyt " +
                    " union select traituyen,sothe,tungay,denngay,mabv,maql " +
                    " from medibv.bhyt) bh on a.maql=bh.maql  left join medibv.dmnoicapbhyt dmncbhyt " +
                    "on bh.mabv=dmncbhyt.mabv";
                sql += " where a.id=" + v_id;
                sql += " group by a.id, a.mabn, b.sobienlai, b.sotien , b.bhyt,b.mien, b.nopthem, "+
                    "to_char(b.ngay,'dd/mm/yyyy'), c.tenkp, d.mabn,  d.hoten, d.namsinh, e.ten,  f.tentt, "+
                    "g.tenquan,h.tenpxa,  to_char(b.ngay,'dd/mm/yyyy'), j.hoten, i.sohieu,tamung,dm.ten, k.mavp, "+
                    "dm.id_loai, n.ten, n.id_nhom, l.ten, k.madoituong, dm.gia_bh, dm." + sfield_gia + ",b.lanin,"+
                    "d.ngaysinh,dmncbhyt.tenbv,a.ngayvao,a.ngayra,bh.traituyen,a.chandoan,a.maicd,"+
                    "bh.tungay,bh.denngay ";

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

                string angaythu="",anamsinh="", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "", ahoten = "", angaysinh = "", agioitinh = "", akhoa = "", adiachi = "", alydo = "", asotien = "", achutien = "", achutientu = "", anguoithu = "", amasothue = "", amauso = "", aquyenso = "", asobienlai = "", acucthue = "", atongcuc = "", adiachibv = "", amabn = "", atongcp = "", atamung = "", abhyt = "", amien = "", athieu = "", anopthem = "", alydomien = "", alydomien1 = "";
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
                anamsinh = adst.Tables[0].Rows[0]["namsinh"].ToString();
                angaythu = adst.Tables[0].Rows[0]["ngaythu"].ToString();
                int atuoi = 0;
                atuoi = DateTime.Now.Year - int.Parse(anamsinh);
                
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
                amien = adst.Tables[0].Rows[0]["mien"].ToString();
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
                    ads.Tables[0].Columns.Add("thangtuoi", typeof(decimal)); 
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
                    r1["BNdongchitra"] = abndongchitra ;
                    r1["BNtuchitra"] = abntutra;
                    r1["tenbv"] = r2["tenbv"];
                    r1["ngayvao"] = r2["ngayvao"];
                    r1["traituyen"] = r2["traituyen"];
                    r1["chandoan"] = r2["chandoan"];
                    r1["maicd"] = r2["maicd"];
                    r1["tungay"] = r2["tungay"];
                    r1["denngay"] = r2["denngay"];
                    r1["namsinh"] = r2["namsinh"];
                    r1["soluong"] = r2["soluong"];
                    ads.Tables[1].Rows.Add(r1);
                }
                //thêm tháng tuổi
                if (atuoi <= 6 && angaysinh != "")
                {
                    long songay = mdi.songay(mdi.StringToDate(angaythu), mdi.StringToDate(angaysinh), 0);
                    long sothang = songay / 30;
                    foreach (DataRow r in ads.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
                }

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
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,ta.sotien as tamung from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " left join medibvmmyy.v_tamung ta on a.mavaovien=ta.mavaovien ";
                sql += " where a.id=" + v_id;
                //sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh, f.tentt , g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten , l.sothe, l.denngay , e.tenkp, a.ngay,  i.id , j.id , k.ma , i.ten, j.ten , k.ten , i.stt , j.stt ,  k.stt , i.dvt, b.soluong, b.dongia, b.mien, b.thieu, b.khuyenmai , b.madoituong, m.hoten,b.tra ,a.ghichu ,b.mien ";
                sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh,d.cholam, f.tentt , g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten , l.sothe, l.denngay , e.tenkp, a.ngay,  i.id , j.id , k.ma , i.ten, j.ten , k.ten , i.stt , j.stt ,  k.stt , i.dvt, b.soluong, b.dongia, b.mien, b.thieu, b.khuyenmai , b.madoituong, m.hoten,b.tra ,a.ghichu ,b.mien,c.sotien,ta.sotien ";
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
                abv = m_v.Tenbv.Replace("'","");

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
                sql += " b.madoituong, m.hoten as nguoithu,b.tra as hoantra,a.ghichu,ta.sotien as tamung from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_quyenso bb on a.quyenso=bb.id ";
                sql += " left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.btdkp_bv e on a.makp=e.makp left join medibv.btdtt f on d.matt=f.matt";
                sql += " left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa";
                sql += " left join (select id, stt, ten, dvt, id_loai from medibv.v_giavp union select id, 1 as stt, trim(ten||' '|| hamluong) as ten, ";
                sql += " dang as dvt, 0 as id_loai from medibv.d_dmbd) i on b.mavp=i.id left join  ";
                sql += " (select id, id_nhom, stt, ten from medibv.v_loaivp union all select 0 as id, 0 as id_nhom, 1 as stt, null as ten) j on i.id_loai=j.id";
                sql += " left join (select ma, ten, stt from medibv.v_nhomvp union all select 0 as ma, null as ten, 1 as stt) k on j.id_nhom=k.ma left join ";
                sql += " medibv.bhyt l on a.maql=l.maql left join medibv.v_dlogin m on a.userid=m.id left join medibv.dmphai n on d.phai=n.ma";
                sql += " left join medibvmmyy.v_tamung ta on a.mavaovien=ta.mavaovien ";
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
                sql += " group by a.id, a.quyenso, a.sobienlai, bb.sohieu, a.mabn, d.hoten, d.namsinh,d.cholam, f.tentt , g.tenquan,h.tenpxa, d.sonha, d.thon, n.ten , l.sothe, l.denngay , e.tenkp, a.ngay,  i.id , j.id , k.ma , i.ten, j.ten , k.ten , i.stt , j.stt ,  k.stt , i.dvt, b.soluong, b.dongia, b.mien, b.thieu, b.khuyenmai , b.madoituong, m.hoten,b.tra ,a.ghichu ,b.mien,c.sotien,ta.sotien ";
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
                string exp = "where a.id=" + v_id + " and b.tra<=0 ";
                if (thutheodot)
                {
                    exp = " where aa.mabn='" + v_mabn + "' and aa.mavaovien=" + v_mavaovien + " and b.tra<=0 ";
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
                   " ,b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem as bntra,b1.mabv,k.tenbv,l.tenkp,"+
                   "a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,to_number('0') as id_loai,g.msthue " +
                   ", b.mien" +

                   " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id " +
                   " left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on " +
                   " b.id=c.id inner join medibv.d_dmbd d on c.mavp=d.id inner join medibv.d_dmnhom e on " +
                   " d.manhom=e.id inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.btdbn g on " +
                   " a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on " +
                   " g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join " +
                   " medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp " +
                   " inner join medibv.v_quyenso m on b.quyenso=m.id left join medibv.dmphongthuchiencls mm on c.idphongcls=mm.id " + aexp;//where b.id=" + v_id;
                sql += " union all ";
                sql += " select d.id,d.ma,d.ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban," +
                    " c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f.ten as tennhom,f.stt as stt_nhom," +
                    " a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  "+
                    "diachi,b1.sothe,to_char(b1.ngay,'dd/mm/yyyy') as denngay," +
                    " to_char(b.ngay,'dd/mm/yyyy') as ngay, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,"+
                    "b.nopthem as bntra,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,"+
                    "c.sttcho,e.id as id_loai,g.msthue,b.mien from medibvmmyy.v_ttrvds a inner join " +
                    " medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id " +
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
        public void f_Print_ChiphiTTRVNgtruCT_cuuu(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien, decimal v_congkhamBHYT,bool v_sttcho)
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
                   "l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,to_number('0') as id_loai,g.msthue " +
                   " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id " +
                   " left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on " +
                   " b.id=c.id inner join medibv.d_dmbd d on c.mavp=d.id inner join medibv.d_dmnhom e on " +
                   " d.manhom=e.id inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.btdbn g on " +
                   " a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on " +
                   " g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join " +
                   " medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp " +
                   " inner join medibv.v_quyenso m on b.quyenso=m.id left join " +
                   " (select  to_char(id) as id, ma as ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;//where b.id=" + v_id;                
                //(select makp as id, tenkp as ten from medibv.btdkp_bv union all select  to_char(id) as id, ma as ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;//where b.id=" + v_id;

                sql += " union all ";
                sql += " select c.madoituong,d.id,d.ma,d.ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban," +
                    " c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f.ten as tennhom,f.stt as stt_nhom," +
                    " a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  diachi,b1.sothe,to_char(b1.ngay,'dd/mm/yyyy') as denngay," +
                    " to_char(b.ngay,'dd/mm/yyyy') as ngay, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem as bntra,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,e.id as id_loai,g.msthue from medibvmmyy.v_ttrvds a inner join " +
                    " medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id " +
                    " inner join medibvmmyy.v_ttrvct c on b.id=c.id inner join medibv.v_giavp d on c.mavp=d.id" +
                    " inner join medibv.v_loaivp e on d.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma" +
                    " inner join medibv.btdbn g on a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner " +
                    " join medibv.btdquan i on g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa " +
                    " left join medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp " +
                    " inner join medibv.v_quyenso m on b.quyenso=m.id left join "+
                    " (select to_char(id) as id, ma ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;// where b.id=" + v_id;
                    //(select makp as id, tenkp as ten from medibv.btdkp_bv union all select to_char(id) as id, ma ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;// where b.id=" + v_id;
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
        public void f_Print_ChiphiTTRVNgtruCT(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien, decimal v_congkhamBHYT, bool v_sttcho)
        {
            try
            {
                //gam
                bool thutheodot = false;
                thutheodot = m_v.bhyt_thutheodot_mavaovien(m_userid);
                string aexp = " where b.id=" + v_id;
                aexp += " and c.sotien>c.bhyttra ";//chi in phan BN tra
                string aReport = "v_thanhtoanravienngtru_chitiet.rpt";
                //chi dunh cho Hepa - thay cho bien lai
                //if (thutheodot)
                //{
                //    aexp = " where a.mabn=" + v_mabn + " and a.mavaovien=" + v_mavaovien;
                //}
                string sql = "";

                sql = "select case when c.phuthu=4 then to_number('0') else (case when c.phuthu=3 then to_number('3') else to_number('2') end) end as thuoc_cls, c.madoituong,d.id,d.ma,d.ten,d.dang as dvt, d.hamluong,d.tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua," +
                   " '' as cachdung, f.ma as id_nhom, f.ten as tennhom, f.stt as stt_nhom,a.mabn,g.hoten,g.namsinh," +
                   " g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as diachi,b1.sothe," +
                   " to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay" +
                   " ,b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem as bntra,b1.mabv,k.tenbv," +
                   "l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,to_number('0') as id_loai,g.msthue, c.phuthu, c.bhyttra as bhyttract, g.cholam, c.mien, b.sokham " +
                   ", f.ma as maloai, f.stt as stt_loai, f.ten as tenloai " +
                   ", c.losx, c.handung, c.idchinhanh, c.idchinhanhden, lg.hoten as thungan " +//binh 230711
                   " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id " +
                   " left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on b.id=c.id " +
                   " inner join medibv.d_dmbd d on c.mavp=d.id inner join medibv.d_dmnhom e on d.manhom=e.id " +
                   " inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.btdbn g on " +
                   " a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on g.maqu=i.maqu " +
                   " inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join " +
                   " medibv.tenvien k on b1.mabv=k.mabv left join medibv.btdkp_bv l on c.makp=l.makp " +
                   " inner join medibv.v_quyenso m on b.quyenso=m.id "+
                   " inner join medibv.v_dlogin lg on b.userid=lg.id" +
                   " left join (select  to_char(id) as id, ma as ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;//where b.id=" + v_id;
                   //" left join (select makp as id, tenkp as ten from medibv.btdkp_bv union all select  to_char(id) as id, ma as ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;//where b.id=" + v_id;
                sql += " union all ";
                sql += " select to_number('1') as thuoc_cls, c.madoituong,d.id,d.ma,d.ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban," +
                    " c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f.ten as tennhom,f.stt as stt_nhom," +
                    " a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  diachi,b1.sothe,to_char(b1.ngay,'dd/mm/yyyy') as denngay," +
                    " to_char(b.ngay,'dd/mm/yyyy') as ngay, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem as bntra,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,g.phai,tamung,b.thanhtoan,mm.ten as phongcls,c.sttcho,e.id as id_loai,g.msthue , c.phuthu, c.bhyttra as bhyttract, g.cholam, c.mien, b.sokham " +
                    ", e.id as maloai, e.stt as stt_loai, e.ten as tenloai " +
                    ", c.losx, c.handung, c.idchinhanh, c.idchinhanhden, lg.hoten as thungan " +//binh 230711
                    " from medibvmmyy.v_ttrvds a inner join " +
                    " medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id " +
                    " inner join medibvmmyy.v_ttrvct c on b.id=c.id inner join medibv.v_giavp d on c.mavp=d.id" +
                    " inner join medibv.v_loaivp e on d.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma" +
                    " inner join medibv.btdbn g on a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt  " +
                    " inner join medibv.btdquan i on g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa " +
                    " left join medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on c.makp=l.makp " +
                    " inner join medibv.v_quyenso m on b.quyenso=m.id  "+
                    " inner join medibv.v_dlogin lg on b.userid=lg.id"+
                    " left join (select to_char(id) as id, ma ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;// where b.id=" + v_id;
                    //"(select makp as id, tenkp as ten from medibv.btdkp_bv union all select to_char(id) as id, ma ten from medibv.dmphongthuchiencls) mm on c.idphongcls=mm.id " + aexp;// where b.id=" + v_id;
                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);


                if ((ads == null) || (ads.Tables[0].Rows.Count <= 0))
                {
                    //MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy chứng  từ bhyt ngoại trú <") + v_id + ">", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow r2 = ads.Tables[0].Rows[0];
                DataRow r1 = ads.Tables[0].NewRow();
                if (v_sttcho)
                {
                    string v_sovaovien = m_v.get_data_mmyy(v_mmyy, "select sovaovien from medibvmmyy.tiepdon where mabn=" + v_mabn + " and mavaovien=" + v_mavaovien).Tables[0].Rows[0][0].ToString();
                    for (int i = 0; i < ads.Tables[0].Columns.Count; i++)
                        r1[i] = r2[i].ToString();
                    r1["id_nhom"] = 9999;
                    r1["ten"] = "";// "Bác sĩ đọc kết quả";
                    r1["sotien"] = 0;
                    r1["giamua"] = 0;
                    r1["giaban"] = 0;
                    r1["sttcho"] = v_sovaovien == "" ? "0" : v_sovaovien;
                    r1["phongcls"] = r2["tenkp"].ToString();
                    r1["phuthu"] = 0;
                    r1["thuoc_cls"] = 1;
                    ads.Tables[0].Rows.Add(r1);
                    ads.AcceptChanges();
                }
                foreach(DataRow dr in ads.Tables[0].Select("sttcho>0"))
                {
                    if (dr["phongcls"].ToString().Trim().Trim(',') == "") dr["phongcls"] = dr["tenkp"].ToString();
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
                    //this.TopMost = true;
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
                    LibVP.run f = new LibVP.run(filerun, arg, true);
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
                // gam 14-07-2011
                string aReport = "v_bienlaitaichinh_chitiet.rpt";
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
                    
                    "medibv.btdtt i on c.matt=i.matt where a.done=0 and a.id="+v_id;
                sql += " union all ";
                sql += "select c.hoten as tenbn,c.namsinh,c.phai,c.cmnd,a.tendv,a.dcnhan,a.nguoinhan," +
                    "a.diachi as dcdonvi,a.masothue,d.ten as tenvp,b.soluong,b.dongia,b.sotien,b.vat," +
                    "b.madoituong,b.bhyt,to_number('0') as idnhom,to_number('0') as id_loai,d.dang as dvt,g.tenpxa ||','||h.tenquan||" +
                    "','|| i.tentt as diachibn from medibvmmyy.v_bienlaitaichinhll a inner join " +
                    "medibvmmyy.v_bienlaitaichinhct b on a.id=b.id inner join medibv.btdbn c on a.mabn=c.mabn " +
                    "inner join medibv.d_dmbd d on d.id=b.mavp inner join medibv.btdpxa g on " +
                    "c.maphuongxa=g.maphuongxa inner join medibv.btdquan h on c.maqu=h.maqu inner join " +
                    "medibv.btdtt i on c.matt=i.matt where a.done=0 and a.id=" + v_id;

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

                ads.WriteXml("..\\..\\xml\\v_bienlaitaichinh_chitiet.xml", XmlWriteMode.WriteSchema);


                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv + "'";
                cMain.DataDefinition.FormulaFields["v_diachibv"].Text = "'" + adiachibv + "'";
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt + "'";
                
                cMain.SetDataSource(ads);

                if (!v_dir)
                {
                    this.Text = lan.Change_language_MessageText("In biên lai tài chính (") + aReport + ")";
                    this.crystalReportViewer1.ReportSource = cMain;

                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
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

        ///Dong Begin
        public void f_Print_ChiphiTTRVNgtruCT_tenreport_full(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien, decimal v_congkhamBHYT, string ngay, string v_tenreport)
        {

            this.aReport = m_v.get_report_name(v_tenreport);//"v_thanhtoanravienngtru_chitiet.rpt");
            try
            {
                string str17;
                LibDuoc.AccessData data = new LibDuoc.AccessData();
                string sql = "";
                if (v_mmyy == "")
                {
                    v_mmyy = this.m_v.s_curmmyy;
                }
                sql = "select d.id,d.ma,trim(d.ten)||' '||d.hamluong as ten,d.dang as dvt, d.hamluong,d.tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua, '' as cachdung, f.ma as id_nhom, f.ten as tennhom, f.stt as stt_nhom,a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as diachi,nvl(b1.traituyen,0) as traituyen,b1.sothe, to_char(b1.tungay,'dd/mm/yyyy') as tungay,to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay, to_char(nvl(c.ngay,b.ngay),'dd/mm/yyyy') as ngayct, to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra ,b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,g.phai,tamung,x.tenbv as dkkcb,c.bhyttra as bhtra,c.soluong*c.dongia-c.bhyttra as bntra,a.maql,y.hoten as tenuser,c.madoituong,j.doituong,d.kythuat,d.bhyt from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on  b.id=c.id inner join medibv.d_dmbd d on c.mavp=d.id inner join medibv.d_dmnhom e on  d.manhom=e.id inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.btdbn g on  a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on  g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join  medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp  inner join medibv.v_quyenso m on b.quyenso=m.id  left join medibv.dmnoicapbhyt x on b1.mabv=x.mabv  left join medibv.v_dlogin y on b.userid=y.id left join medibv.doituong j on c.madoituong=j.madoituong";
                if (v_id != "")
                {
                    sql = sql + " where b.id=" + v_id;
                }
                else
                {
                    str17 = sql;
                    sql = str17 + " where a.mavaovien=" + v_mavaovien + " and a.mabn='" + v_mabn + "' and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";
                }
                //str17 = (sql + " and c.bhyttra<>0") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
                str17 = (sql + " and c.tra=0 and c.madoituong not in (5)") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
                sql = str17 + " where mavaovien=" + v_mavaovien + " and mabn='" + v_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngay + "')";
                this.ads = new DataSet();
                this.ads = this.m_v.get_data_mmyy(v_mmyy, sql);
                sql = " select d.id,d.ma,d.ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f.ten as tennhom,f.stt as stt_nhom, a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  diachi,nvl(b1.traituyen,0) as traituyen,b1.sothe,to_char(b1.tungay,'dd/mm/yyyy') as tungay,to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay, to_char(nvl(c.ngay,b.ngay),'dd/mm/yyyy') as ngayct, to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,g.phai,tamung,x.tenbv as dkkcb,c.bhyttra as bhtra,c.soluong*c.dongia-c.bhyttra as bntra,a.maql,y.hoten as tenuser,c.madoituong,j.doituong,-1 as kythuat,d.bhyt from medibvmmyy.v_ttrvds a inner join  medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id  inner join medibvmmyy.v_ttrvct c on b.id=c.id inner join medibv.v_giavp d on c.mavp=d.id inner join medibv.v_loaivp e on d.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma inner join medibv.btdbn g on a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner  join medibv.btdquan i on g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa  left join medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp  inner join medibv.v_quyenso m on b.quyenso=m.id  left join medibv.dmnoicapbhyt x on b1.mabv=x.mabv  left join medibv.v_dlogin y on b.userid=y.id left join medibv.doituong j on c.madoituong=j.madoituong ";
                if (v_id != "")
                {
                    sql = sql + " where b.id=" + v_id;
                }
                else
                {
                    str17 = sql;
                    sql = str17 + " where a.mavaovien=" + v_mavaovien + " and a.mabn='" + v_mabn + "' and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";
                }
                //str17 = (sql + " and c.bhyttra<>0 and c.tra=0") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
                str17 = (sql + " and c.tra=0 and c.madoituong not in (5)") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
                sql = str17 + " where mavaovien=" + v_mavaovien + " and mabn='" + v_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngay + "')";
                this.m_v.merge(this.ads, this.m_v.get_data_mmyy(v_mmyy, sql));
                string str2 = "";
                string str3 = "";
                string str4 = "";
                string str5 = "";
                if ((this.ads != null) && (this.ads.Tables[0].Rows.Count > 0))
                {
                    str2 = (this.ads.Tables[0].Rows[0]["chandoan"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["chandoan"].ToString() + ",") : "";
                    str3 = (this.ads.Tables[0].Rows[0]["maicd"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["maicd"].ToString() + ",") : "";
                    str4 = (this.ads.Tables[0].Rows[0]["tenkp"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["tenkp"].ToString() + ",") : "";
                    this.ads.Tables[0].Columns.Add("sotoa");
                    this.ads.Tables[0].Columns.Add("trieuchung");
                    this.ads.Tables[0].Columns.Add("ghichu");
                    string str6 = v_mavaovien.ToString() + ",";
                    string user = this.m_v.user;
                    string str8 = "";
                    string str9 = "";
                    foreach (DataRow row in this.ads.Tables[0].Rows)
                    {
                        if (str6.IndexOf(row["maql"].ToString()) == -1)
                        {
                            str6 = str6 + row["maql"].ToString() + ",";
                        }
                    }
                    if (str6 != "")
                    {
                        string s = "01/" + v_mmyy.Substring(0, 2) + "/20" + v_mmyy.Substring(2);
                        string tu = this.m_v.DateToString("dd/MM/yyyy", this.m_v.StringToDate(s).AddDays(-1.0));
                        bool flag = false;
                        str17 = "select a.maicd,a.chandoan,b.tenkp,nvl(c.lydo,'') as lydo, nvl(d.ten,'') as trieuchung from " + user + v_mmyy + ".benhanpk a," + user + ".btdkp_bv b," + user + v_mmyy + ".lydokham c," + user + v_mmyy + ".trieuchung d";
                        sql = str17 + " where a.makp=b.makp and a.maql=c.maql(+) and a.maql=d.maql(+) and (a.maql in (" + str6.Substring(0, str6.Length - 1) + ") or a.mavaovien in (" + str6.Substring(0, str6.Length - 1) + "))";
                        foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                        {
                            if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                            {
                                str2 = str2 + row["chandoan"].ToString() + ",";
                            }
                            if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                            {
                                str3 = str3 + row["maicd"].ToString() + ",";
                            }
                            if ((row["tenkp"].ToString().Trim() != "") && (str4.IndexOf(row["tenkp"].ToString().Trim()) == -1))
                            {
                                str4 = str4 + row["tenkp"].ToString() + ",";
                            }
                            if ((row["lydo"].ToString().Trim() != "") && (str9.IndexOf(row["lydo"].ToString().Trim()) == -1))
                            {
                                str9 = str9 + row["lydo"].ToString() + ",";
                            }
                            if ((row["trieuchung"].ToString().Trim() != "") && (str9.IndexOf(row["trieuchung"].ToString().Trim()) == -1))
                            {
                                str9 = str9 + row["trieuchung"].ToString() + ",";
                            }
                            str5 = row["lydo"].ToString();
                            flag = true;
                        }
                        if (!flag)
                        {
                            str17 = "select a.maicd,a.chandoan,b.tenkp,nvl(c.lydo,'') as lydo from " + user + v_mmyy + ".benhanpk a," + user + ".btdkp_bv b," + user + v_mmyy + ".lydokham c";
                            sql = str17 + " where a.makp=b.makp and a.maql=c.maql(+) and a.mabn='" + v_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and a.madoituong=1";
                            foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                            {
                                if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                                {
                                    str2 = str2 + row["chandoan"].ToString() + ",";
                                }
                                if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                                {
                                    str3 = str3 + row["maicd"].ToString() + ",";
                                }
                                if ((row["tenkp"].ToString().Trim() != "") && (str4.IndexOf(row["tenkp"].ToString().Trim()) == -1))
                                {
                                    str4 = str4 + row["tenkp"].ToString() + ",";
                                }
                                str5 = row["lydo"].ToString();
                                flag = true;
                            }
                        }
                        str17 = ("select maicd,chandoan from " + user + ".cdkemtheo where maql in (" + str6.Substring(0, str6.Length - 1) + ")") + " union all ";
                        sql = str17 + "select maicd,chandoan from " + user + v_mmyy + ".cdkemtheo where maql in (" + str6.Substring(0, str6.Length - 1) + ")";
                        foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                        {
                            if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                            {
                                str2 = str2 + row["chandoan"].ToString() + ",";
                            }
                            if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                            {
                                str3 = str3 + row["maicd"].ToString() + ",";
                            }
                        }
                        if (str5 == "")
                        {
                            sql = "select lydo from " + user + v_mmyy + ".lydokham where maql in (" + str6.Substring(0, str6.Length - 1) + ")";
                            foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                            {
                                str5 = row["lydo"].ToString() + ",";
                            }
                        }
                        foreach (DataRow row in this.m_v.get_data("select sotoa from " + user + v_mmyy + ".bhytkb where maql in (" + str6.Substring(0, str6.Length - 1) + ")").Tables[0].Rows)
                        {
                            str8 = str8 + row["sotoa"].ToString();
                            break;
                        }
                        if (str8 == "")
                        {
                            foreach (DataRow row in this.m_v.get_data("select sotoa from " + user + v_mmyy + ".bhytkb where mavaovien=" + v_mavaovien).Tables[0].Rows)
                            {
                                str8 = str8 + row["sotoa"].ToString();
                                break;
                            }
                        }
                        foreach (DataRow row in this.ads.Tables[0].Rows)
                        {
                            row["chandoan"] = str2;
                            row["maicd"] = str3;
                            row["sotoa"] = str8;
                            row["tenkp"] = str4;
                            row["trieuchung"] = str9;
                            row["ghichu"] = str5;
                        }
                    }
                    int num = data.get_sophieu_bhyt_userid(v_mmyy, v_mabn, decimal.Parse(v_mavaovien), ngay, 1, 0);
                    int asotient = data.get_laninkb(v_mmyy, v_mabn, decimal.Parse(v_mavaovien), ngay, 1);
                    this.ads.WriteXml(@"..\..\Datareport\" + aReport.Replace(".rpt", ".xml"), XmlWriteMode.WriteSchema);
                    string syte = "";
                    string tenbv = "";
                    string str14 = "";
                    string str15 = "";
                    string str16 = "";
                    syte = this.m_v.Syte;
                    tenbv = this.m_v.Tenbv;
                    str14 = this.f_GetNgay(this.ads.Tables[0].Rows[0]["ngay"].ToString());
                    str15 = this.ads.Tables[0].Rows[0]["userid"].ToString();
                    str16 = "";
                    this.cMain = new ReportDocument();
                    this.cMain.Load(@"..\..\..\report\" + this.aReport, OpenReportMethod.OpenReportByTempCopy);
                    this.cMain.SetDataSource(this.ads);
                    this.cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + syte.ToUpper() + "'";
                    this.cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + tenbv.ToUpper() + "'";
                    this.cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + str14 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + str15 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + str16 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_congkhamBHYT"].Text = "'" + v_congkhamBHYT + "'";
                    this.Text = this.aReport;
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        base.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        this.crystalReportViewer1.ReportSource = this.cMain;
                        base.WindowState = FormWindowState.Maximized;
                        base.ShowDialog(base.Parent);
                    }
                    else
                    {
                        this.cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    this.cMain.Close();
                    this.cMain.Dispose();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, aReport + "\n" + exception.ToString(), this.m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        //khuyen 26/02/14
        public void f_Print_ChiphiTTRVNgtruCT_tenreport02(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien, decimal v_congkhamBHYT, string ngay, string v_tenreport, bool v_chuyenchungtu)
        {
            this.aReport = m_v.get_report_name(v_tenreport);//"v_thanhtoanravienngtru_chitiet.rpt");
            bool b_dahoantat_mau38 = true;
            try
            {
                string str17;
                LibDuoc.AccessData data = new LibDuoc.AccessData();
                bool bMau38_01_daydu = true;
                string sql = "";
                if (v_mmyy == "")
                {
                    v_mmyy = this.m_v.s_curmmyy;
                }
                //sql = " select a.stt as sttbhyt, a.id as idnhombhyt, a.ten as tennhombhyt, b.* from medibv.v_nhombhyt a left join ( ";
                //thuoc_vattu
                sql = "select d.id,d.ma,trim(d.ten)||' '||d.hamluong as ten,d.dang as dvt, d.hamluong,d.tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua, '' as cachdung,";
                sql += "f.ma as id_nhom, f1.ten as tennhom, f1.stt as stt_nhom,a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as diachi,";
                sql += "b1.traituyen,b1.sothe, to_char(b1.tungay,'dd/mm/yyyy') as tungay,to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay, to_char(nvl(c.ngay,b.ngay),'dd/mm/yyyy') as ngayct,";
                sql += "to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra ,b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,";
                sql += "g.phai,tamung,x.tenbv as dkkcb,c.bhyttra as bhtra,c.soluong*c.dongia-c.bhyttra as bntra,a.maql,y.hoten as tenuser,c.madoituong,z.doituong,d.kythuat";
                sql += " , f.idnhombhyt, f1.stt as sttbhyt, f1.ten as tennhombhyt ";
                sql += " , f1.stt as sttbhyt1, f1.ten as tennhombhyt1, lh.soluutru, ld.lydo as chandoansobo, ld.phanbiet ";
                sql += ", c.idchinhanh, c.idchinhanhden, a.dain38";
                sql += ",c.sotien as sotienct,c.sttduyet";//khuyen 25/02/14 lay len report
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on  b.id=c.id inner join medibv.d_dmbd d on c.mavp=d.id";
                sql += " inner join medibv.d_dmnhom e on  d.manhom=e.id inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.v_nhombhyt f1 on f.idnhombhyt=f1.id inner join medibv.btdbn g on  a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on  g.maqu=i.maqu ";
                sql += " inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join  medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp  inner join medibv.v_quyenso m on b.quyenso=m.id  ";
                sql += " left join medibv.dmnoicapbhyt x on b1.mabv=x.mabv  left join medibv.v_dlogin y on b.userid=y.id left join medibv.doituong z on c.madoituong=z.madoituong";
                sql += " left join medibvmmyy.lienhe lh on a.maql=lh.maql ";
                sql += " left join medibvmmyy.lydokham ld on a.maql=ld.maql ";
                
                    str17 = sql;
                    sql = str17 + " where a.mavaovien=" + v_mavaovien + " and a.mabn='" + v_mabn + "'";// and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";
                
                str17 = (sql + " and c.bhyttra>0 and c.idtra=0 and c.madoituong not in (5)") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
                sql = str17 + " where mavaovien=" + v_mavaovien + " and mabn='" + v_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngay + "')";
                if (v_chuyenchungtu) sql += " and c.idchinhanh<>c.idchinhanhden ";
                else sql += " and c.idchinhanh=c.idchinhanhden ";
                //sql += ") b on a.id=b.idnhombhyt ";
                this.ads = new DataSet();
                this.ads = this.m_v.get_data_mmyy(v_mmyy, sql);
                //
                if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
                {
                    b_dahoantat_mau38 = decimal.Parse(ads.Tables[0].Rows[0]["dain38"].ToString()) > 0;

                }
                //
                //vien phi
                //sql = " select a.stt as sttbhyt, a.id as idnhombhyt, a.ten as tennhombhyt, b.* from medibv.v_nhombhyt a left join ( ";
                ////
                sql = " select d.id,d.ma,d.ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f1.ten as tennhom,f1.stt as stt_nhom, a.mabn,g.hoten,g.namsinh,";
                sql += "g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  diachi,b1.traituyen,b1.sothe,to_char(b1.tungay,'dd/mm/yyyy') as tungay,to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay,";
                sql += "to_char(nvl(c.ngay,b.ngay),'dd/mm/yyyy') as ngayct, to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem,b1.mabv,k.tenbv,l.tenkp,";
                sql += "a.maicd,a.chandoan,g.phai,tamung,x.tenbv as dkkcb,c.bhyttra as bhtra,c.soluong*c.dongia-c.bhyttra as bntra,a.maql,y.hoten as tenuser,c.madoituong,z.doituong,d.kythuat";
                sql += " , f.idnhombhyt, f1.stt as sttbhyt, f1.ten as tennhombhyt ";
                sql += " , f1.stt as sttbhyt1, f1.ten as tennhombhyt1, lh.soluutru, ld.lydo as chandoansobo, ld.phanbiet ";
                sql += ", c.idchinhanh, c.idchinhanhden, a.dain38";
                sql += ",c.sotien as sotienct,c.sttduyet";//khuyen 25/02/14 lay len report
                sql += " from medibvmmyy.v_ttrvds a inner join  medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id  inner join medibvmmyy.v_ttrvct c on b.id=c.id inner join medibv.v_giavp d on c.mavp=d.id inner join medibv.v_loaivp e on d.id_loai=e.id ";
                sql += " inner join medibv.v_nhomvp f on e.id_nhom=f.ma inner join medibv.v_nhombhyt f1 on f.idnhombhyt=f1.id inner join medibv.btdbn g on a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner  join medibv.btdquan i on g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa  ";
                sql += " left join medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp  inner join medibv.v_quyenso m on b.quyenso=m.id  left join medibv.dmnoicapbhyt x on b1.mabv=x.mabv  left join medibv.v_dlogin y on b.userid=y.id left join medibv.doituong z on c.madoituong=z.madoituong";
                sql += " left join medibvmmyy.lienhe lh on a.maql=lh.maql ";
                sql += " left join medibvmmyy.lydokham ld on a.maql=ld.maql ";
                    str17 = sql;
                    sql = str17 + " where a.mavaovien=" + v_mavaovien + " and a.mabn='" + v_mabn + "'";// and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";
                str17 = (sql + " and c.bhyttra>0 and c.idtra=0 and c.madoituong not in (5)") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
                sql = str17 + " where mavaovien=" + v_mavaovien + " and mabn='" + v_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngay + "')";
                if (v_chuyenchungtu) sql += " and c.idchinhanh<>c.idchinhanhden ";
                else sql += " and c.idchinhanh=c.idchinhanhden ";

                //sql += ") b on a.id=b.idnhombhyt ";

                this.m_v.merge(this.ads, this.m_v.get_data_mmyy(v_mmyy, sql));
               
                string str2 = "";
                string str3 = "";
                string str4 = "";
                string str5 = "";
                if ((this.ads != null) && (this.ads.Tables[0].Rows.Count > 0))
                {
                    str2 = (this.ads.Tables[0].Rows[0]["chandoan"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["chandoan"].ToString() + ",") : "";
                    str3 = (this.ads.Tables[0].Rows[0]["maicd"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["maicd"].ToString() + ",") : "";
                    str4 = (this.ads.Tables[0].Rows[0]["tenkp"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["tenkp"].ToString() + ",") : "";
                    this.ads.Tables[0].Columns.Add("sotoa");
                    this.ads.Tables[0].Columns.Add("trieuchung");
                    this.ads.Tables[0].Columns.Add("ghichu");
                    this.ads.Tables[0].Columns.Add("somau01");//binh 200711
                    string str6 = v_mavaovien.ToString() + ",";
                    string user = this.m_v.user;
                    string str8 = "";
                    string str9 = "";
                    int num = data.get_sophieu_bhyt_userid(v_mmyy, v_mabn, decimal.Parse(v_mavaovien), ngay, 1, 0);
                    
                    foreach (DataRow row in this.ads.Tables[0].Rows)
                    {
                        if (str6.IndexOf(row["maql"].ToString()) == -1)
                        {
                            str6 = str6 + row["maql"].ToString() + ",";
                        }
                        row["somau01"] = num;
                    }
                    ads.AcceptChanges();
                    if (str6 != "")
                    {
                        string s = "01/" + v_mmyy.Substring(0, 2) + "/20" + v_mmyy.Substring(2);
                        string tu = this.m_v.DateToString("dd/MM/yyyy", this.m_v.StringToDate(s).AddDays(-1.0));
                        bool flag = false;
                        str17 = "select a.maicd,a.chandoan,b.tenkp,nvl(c.lydo,'') as lydo,nvl(d.ten,'') as trieuchung from " + user + v_mmyy + ".benhanpk a," + user + ".btdkp_bv b," + user + v_mmyy + ".lydokham c," + user + v_mmyy + ".trieuchung d";
                        sql = str17 + " where a.makp=b.makp and a.maql=c.maql(+) and a.maql=d.maql(+) and (a.maql in (" + str6.Substring(0, str6.Length - 1) + ") or a.mavaovien in (" + str6.Substring(0, str6.Length - 1) + "))";
                        foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                        {
                            if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                            {
                                str2 = str2 + row["chandoan"].ToString() + ",";
                            }
                            if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                            {
                                str3 = str3 + row["maicd"].ToString() + ",";
                            }
                            if ((row["tenkp"].ToString().Trim() != "") && (str4.IndexOf(row["tenkp"].ToString().Trim()) == -1))
                            {
                                str4 = str4 + row["tenkp"].ToString() + ",";
                            }
                            if ((row["lydo"].ToString().Trim() != "") && (str9.IndexOf(row["lydo"].ToString().Trim()) == -1))
                            {
                                str9 = str9 + row["lydo"].ToString() + ",";
                            }
                            if ((row["trieuchung"].ToString().Trim() != "") && (str9.IndexOf(row["trieuchung"].ToString().Trim()) == -1))
                            {
                                str9 = str9 + row["trieuchung"].ToString() + ",";
                            }
                            str5 = row["lydo"].ToString();
                            flag = true;
                        }
                        if (!flag)
                        {
                            str17 = "select a.maicd,a.chandoan,b.tenkp,nvl(c.lydo,'') as lydo from " + user + v_mmyy + ".benhanpk a," + user + ".btdkp_bv b," + user + v_mmyy + ".lydokham c";
                            sql = str17 + " where a.makp=b.makp and a.maql=c.maql(+) and a.mabn='" + v_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and a.madoituong=1";
                            foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                            {
                                if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                                {
                                    str2 = str2 + row["chandoan"].ToString() + ",";
                                }
                                if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                                {
                                    str3 = str3 + row["maicd"].ToString() + ",";
                                }
                                if ((row["tenkp"].ToString().Trim() != "") && (str4.IndexOf(row["tenkp"].ToString().Trim()) == -1))
                                {
                                    str4 = str4 + row["tenkp"].ToString() + ",";
                                }
                                str5 = row["lydo"].ToString();
                                flag = true;
                            }
                        }
                        str17 = ("select maicd,chandoan from " + user + ".cdkemtheo where maql in (" + str6.Substring(0, str6.Length - 1) + ")") + " union all ";
                        sql = str17 + "select maicd,chandoan from " + user + v_mmyy + ".cdkemtheo where maql in (" + str6.Substring(0, str6.Length - 1) + ")";
                        foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                        {
                            if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                            {
                                str2 = str2 + row["chandoan"].ToString() + ",";
                            }
                            if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                            {
                                str3 = str3 + row["maicd"].ToString() + ",";
                            }
                        }
                        if (str5 == "")
                        {
                            sql = "select lydo from " + user + v_mmyy + ".lydokham where maql in (" + str6.Substring(0, str6.Length - 1) + ")";
                            foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                            {
                                str5 = row["lydo"].ToString() + ",";
                            }
                        }
                        foreach (DataRow row in this.m_v.get_data("select sotoa from " + user + v_mmyy + ".bhytkb where maql in (" + str6.Substring(0, str6.Length - 1) + ")").Tables[0].Rows)
                        {
                            str8 = str8 + row["sotoa"].ToString();
                            break;
                        }
                        if (str8 == "")
                        {
                            foreach (DataRow row in this.m_v.get_data("select sotoa from " + user + v_mmyy + ".bhytkb where mavaovien=" + v_mavaovien).Tables[0].Rows)
                            {
                                str8 = str8 + row["sotoa"].ToString();
                                break;
                            }
                        }
                        foreach (DataRow row in this.ads.Tables[0].Rows)
                        {
                            row["chandoan"] = str2;
                            row["maicd"] = str3;
                            row["sotoa"] = str8;
                            row["tenkp"] = str4;
                            row["trieuchung"] = str9;
                            row["ghichu"] = str5;
                        }
                    }
                    //int num = data.get_sophieu_bhyt_userid(v_mmyy, v_mabn, decimal.Parse(v_mavaovien), ngay, 1, 0);
                    int asotient = data.get_laninkb(v_mmyy, v_mabn, decimal.Parse(v_mavaovien), ngay, 1);
                    this.ads.WriteXml(@"..\..\Datareport\" + aReport.Replace(".rpt", ".xml"), XmlWriteMode.WriteSchema);
                    string syte = "";
                    string tenbv = "";
                    string str14 = "";
                    string str15 = "";
                    string str16 = "";
                    syte = this.m_v.Syte;
                    tenbv = this.m_v.Tenbv;
                    str14 = this.f_GetNgay(this.ads.Tables[0].Rows[0]["ngay"].ToString());
                    str15 = this.ads.Tables[0].Rows[0]["userid"].ToString();
                    str16 = "";
                    this.cMain = new ReportDocument();
                    this.cMain.Load(@"..\..\..\report\" + this.aReport, OpenReportMethod.OpenReportByTempCopy);
                    this.cMain.SetDataSource(this.ads);
                    this.cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + syte.ToUpper() + "'";
                    this.cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + tenbv.ToUpper() + "'";
                    this.cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + str14 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + str15 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + str16 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_congkhamBHYT"].Text = "'" + v_congkhamBHYT + "'";
                    this.Text = this.aReport;
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        base.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        this.crystalReportViewer1.ReportSource = this.cMain;
                        base.WindowState = FormWindowState.Maximized;
                        base.ShowDialog(base.Parent);
                    }
                    else
                    {
                        this.cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    this.cMain.Close();
                    this.cMain.Dispose();

                    //binh 260711
                    if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
                    {
                        if (num > 0 && b_dahoantat_mau38 == false)
                        {
                            DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã hoàn tất chi phí chưa?"), "Medisoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (dlg == DialogResult.Yes) b_dahoantat_mau38 = true;
                        }
                        if (b_dahoantat_mau38 && num > 0)
                        {
                            f_upd_dain_mau38(v_mmyy, v_mabn, v_mavaovien, num.ToString());
                        }
                    }
                    //
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, aReport + "\n" + exception.ToString(), this.m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        // end dong 110711
        public void f_Print_ChiphiTTRVNgtruCT_tenreport(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien, decimal v_congkhamBHYT, string ngay, string v_tenreport, bool v_chuyenchungtu)
        {
            this.aReport = m_v.get_report_name(v_tenreport);//"v_thanhtoanravienngtru_chitiet.rpt");
            bool b_dahoantat_mau38 = true;
            try
            {
                string str17;
                LibDuoc.AccessData data = new LibDuoc.AccessData();
                bool bMau38_01_daydu = true;
                string sql = "";
                if (v_mmyy == "")
                {
                    v_mmyy = this.m_v.s_curmmyy;
                }
                //sql = " select a.stt as sttbhyt, a.id as idnhombhyt, a.ten as tennhombhyt, b.* from medibv.v_nhombhyt a left join ( ";
                //thuoc_vattu
                sql = "select d.id,d.ma,trim(d.ten)||' '||d.hamluong as ten,d.dang as dvt, d.hamluong,d.tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua, '' as cachdung,";
                sql += "f.ma as id_nhom, f1.ten as tennhom, f1.stt as stt_nhom,a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as diachi,";
                sql += "b1.traituyen,b1.sothe, to_char(b1.tungay,'dd/mm/yyyy') as tungay,to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay, to_char(nvl(c.ngay,b.ngay),'dd/mm/yyyy') as ngayct,";
                sql += "to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra ,b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,";
                sql += "g.phai,tamung,x.tenbv as dkkcb,c.bhyttra as bhtra,c.soluong*c.dongia-c.bhyttra as bntra,a.maql,y.hoten as tenuser,c.madoituong,z.doituong,d.kythuat";
                sql += " , f.idnhombhyt, f1.stt as sttbhyt, f1.ten as tennhombhyt ";
                sql += " , f1.stt as sttbhyt1, f1.ten as tennhombhyt1, lh.soluutru, ld.lydo as chandoansobo, ld.phanbiet ";
                sql += ", c.idchinhanh, c.idchinhanhden, a.dain38";
                sql += ",c.sotien as sotienct,c.sttduyet";//khuyen 25/02/14 lay len report
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on  b.id=c.id inner join medibv.d_dmbd d on c.mavp=d.id";
                sql += " inner join medibv.d_dmnhom e on  d.manhom=e.id inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.v_nhombhyt f1 on f.idnhombhyt=f1.id inner join medibv.btdbn g on  a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on  g.maqu=i.maqu ";
                sql += " inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join  medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp  inner join medibv.v_quyenso m on b.quyenso=m.id  ";
                sql += " left join medibv.dmnoicapbhyt x on b1.mabv=x.mabv  left join medibv.v_dlogin y on b.userid=y.id left join medibv.doituong z on c.madoituong=z.madoituong";
                sql += " left join medibvmmyy.lienhe lh on a.maql=lh.maql ";
                sql += " left join medibvmmyy.lydokham ld on a.maql=ld.maql ";

                str17 = sql;
                sql = str17 + " where a.mavaovien=" + v_mavaovien + " and a.mabn='" + v_mabn + "'";// and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";

                str17 = (sql + " and c.bhyttra>0 and c.idtra=0 and c.madoituong not in (5)") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
                sql = str17 + " where mavaovien=" + v_mavaovien + " and mabn='" + v_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngay + "')";
                if (v_chuyenchungtu) sql += " and c.idchinhanh<>c.idchinhanhden ";
                else sql += " and c.idchinhanh=c.idchinhanhden ";
                //sql += ") b on a.id=b.idnhombhyt ";
                this.ads = new DataSet();
                this.ads = this.m_v.get_data_mmyy(v_mmyy, sql);
                //
                if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
                {
                    b_dahoantat_mau38 = decimal.Parse(ads.Tables[0].Rows[0]["dain38"].ToString()) > 0;

                }
                //
                //vien phi
                //sql = " select a.stt as sttbhyt, a.id as idnhombhyt, a.ten as tennhombhyt, b.* from medibv.v_nhombhyt a left join ( ";
                ////
                sql = " select d.id,d.ma,d.ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f1.ten as tennhom,f1.stt as stt_nhom, a.mabn,g.hoten,g.namsinh,";
                sql += "g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  diachi,b1.traituyen,b1.sothe,to_char(b1.tungay,'dd/mm/yyyy') as tungay,to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay,";
                sql += "to_char(nvl(c.ngay,b.ngay),'dd/mm/yyyy') as ngayct, to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem,b1.mabv,k.tenbv,l.tenkp,";
                sql += "a.maicd,a.chandoan,g.phai,tamung,x.tenbv as dkkcb,c.bhyttra as bhtra,c.soluong*c.dongia-c.bhyttra as bntra,a.maql,y.hoten as tenuser,c.madoituong,z.doituong,d.kythuat";
                sql += " , f.idnhombhyt, f1.stt as sttbhyt, f1.ten as tennhombhyt ";
                sql += " , f1.stt as sttbhyt1, f1.ten as tennhombhyt1, lh.soluutru, ld.lydo as chandoansobo, ld.phanbiet ";
                sql += ", c.idchinhanh, c.idchinhanhden, a.dain38";
                sql += ",c.sotien as sotienct,c.sttduyet";//khuyen 25/02/14 lay len report
                sql += " from medibvmmyy.v_ttrvds a inner join  medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id  inner join medibvmmyy.v_ttrvct c on b.id=c.id inner join medibv.v_giavp d on c.mavp=d.id inner join medibv.v_loaivp e on d.id_loai=e.id ";
                sql += " inner join medibv.v_nhomvp f on e.id_nhom=f.ma inner join medibv.v_nhombhyt f1 on f.idnhombhyt=f1.id inner join medibv.btdbn g on a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner  join medibv.btdquan i on g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa  ";
                sql += " left join medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp  inner join medibv.v_quyenso m on b.quyenso=m.id  left join medibv.dmnoicapbhyt x on b1.mabv=x.mabv  left join medibv.v_dlogin y on b.userid=y.id left join medibv.doituong z on c.madoituong=z.madoituong";
                sql += " left join medibvmmyy.lienhe lh on a.maql=lh.maql ";
                sql += " left join medibvmmyy.lydokham ld on a.maql=ld.maql ";
                str17 = sql;
                sql = str17 + " where a.mavaovien=" + v_mavaovien + " and a.mabn='" + v_mabn + "'";// and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";
                str17 = (sql + " and c.bhyttra>0 and c.idtra=0 and c.madoituong not in (5)") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
                sql = str17 + " where mavaovien=" + v_mavaovien + " and mabn='" + v_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngay + "')";
                if (v_chuyenchungtu) sql += " and c.idchinhanh<>c.idchinhanhden ";
                else sql += " and c.idchinhanh=c.idchinhanhden ";

                //sql += ") b on a.id=b.idnhombhyt ";

                this.m_v.merge(this.ads, this.m_v.get_data_mmyy(v_mmyy, sql));
                if (bMau38_01_daydu && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
                {
                    DataSet dsnhombhyt = m_v.get_data(" select id, stt, ten from medibv.v_nhombhyt order by stt ");
                    //
                    DataRow dr1 = dsnhombhyt.Tables[0].NewRow();
                    dr1["stt"] = "92";
                    dr1["id"] = "92";
                    dr1["ten"] = "Ngoài danh mục BHYT";
                    dsnhombhyt.Tables[0].Rows.Add(dr1);
                    DataRow dr2 = dsnhombhyt.Tables[0].NewRow();
                    dr2["stt"] = "93";
                    dr2["id"] = "93";
                    dr2["ten"] = "Thuốc điều trị ung thư, chống thải ghép ngoài danh mục";
                    dsnhombhyt.Tables[0].Rows.Add(dr2);
                    DataRow dr3 = dsnhombhyt.Tables[0].NewRow();
                    dr3["stt"] = "101";
                    dr3["id"] = "101";
                    dr3["ten"] = "Ngoài danh mục BHYT";
                    dsnhombhyt.Tables[0].Rows.Add(dr3);
                    dsnhombhyt.AcceptChanges();
                    //
                    DataRow r11;
                    foreach (DataRow rbhyt in dsnhombhyt.Tables[0].Rows)
                    {
                        r11 = m_v.getrowbyid(ads.Tables[0], "sttbhyt=" + rbhyt["stt"].ToString());
                        if (r11 == null)
                        {
                            DataRow r12 = ads.Tables[0].NewRow();

                            r12["id"] = 0;
                            r12["ma"] = "";
                            r12["ten"] = "";
                            r12["hamluong"] = "";
                            r12["dvt"] = "";
                            r12["tenhc"] = "";
                            r12["cachdung"] = "";
                            r12["soluong"] = 0;
                            r12["giamua"] = 0;
                            r12["giaban"] = 0;
                            r12["id_nhom"] = 0;
                            r12["tennhom"] = "";

                            r12["stt_nhom"] = 0;
                            r12["mabn"] = ads.Tables[0].Rows[0]["mabn"].ToString();
                            r12["hoten"] = ads.Tables[0].Rows[0]["hoten"].ToString();
                            r12["namsinh"] = ads.Tables[0].Rows[0]["namsinh"].ToString();
                            r12["diachi"] = ads.Tables[0].Rows[0]["diachi"].ToString();
                            r12["sothe"] = ads.Tables[0].Rows[0]["sothe"].ToString();
                            r12["traituyen"] = ads.Tables[0].Rows[0]["traituyen"].ToString();
                            r12["tungay"] = ads.Tables[0].Rows[0]["denngay"].ToString();
                            r12["denngay"] = ads.Tables[0].Rows[0]["denngay"].ToString();
                            r12["ngay"] = ads.Tables[0].Rows[0]["ngay"].ToString();
                            r12["ngayct"] = ads.Tables[0].Rows[0]["ngayct"].ToString();
                            r12["ngayvao"] = ads.Tables[0].Rows[0]["ngayvao"].ToString();
                            r12["ngayra"] = ads.Tables[0].Rows[0]["ngayra"].ToString();

                            r12["userid"] = ads.Tables[0].Rows[0]["userid"].ToString();
                            r12["sohieu"] = ads.Tables[0].Rows[0]["sohieu"].ToString();
                            r12["sobienlai"] = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                            r12["sotien"] = 0;// ads.Tables[0].Rows[0]["sotien"].ToString();
                            r12["bhyttra"] = 0;// ads.Tables[0].Rows[0]["bhyttra"].ToString();
                            r12["nopthem"] = ads.Tables[0].Rows[0]["nopthem"].ToString();
                            r12["mabv"] = ads.Tables[0].Rows[0]["mabv"].ToString();
                            r12["tenbv"] = ads.Tables[0].Rows[0]["tenbv"].ToString();
                            r12["tenkp"] = ads.Tables[0].Rows[0]["tenkp"].ToString();
                            r12["maicd"] = ads.Tables[0].Rows[0]["maicd"].ToString();
                            r12["chandoan"] = ads.Tables[0].Rows[0]["chandoan"].ToString();
                            r12["phai"] = ads.Tables[0].Rows[0]["phai"].ToString();
                            r12["tamung"] = ads.Tables[0].Rows[0]["tamung"].ToString();
                            r12["dkkcb"] = ads.Tables[0].Rows[0]["dkkcb"].ToString();
                            r12["bhtra"] = 0;// ads.Tables[0].Rows[0]["bhtra"].ToString();
                            r12["bntra"] = 0;// ads.Tables[0].Rows[0]["bntra"].ToString();
                            r12["maql"] = ads.Tables[0].Rows[0]["maql"].ToString();
                            r12["tenuser"] = ads.Tables[0].Rows[0]["tenuser"].ToString();
                            r12["madoituong"] = ads.Tables[0].Rows[0]["madoituong"].ToString();
                            r12["doituong"] = ads.Tables[0].Rows[0]["doituong"].ToString();
                            r12["soluutru"] = ads.Tables[0].Rows[0]["soluutru"].ToString();

                            r12["kythuat"] = -1;

                            r12["idnhombhyt"] = rbhyt["id"].ToString();
                            r12["sttbhyt"] = rbhyt["stt"].ToString();
                            r12["tennhombhyt"] = rbhyt["ten"].ToString();


                            r12["sttbhyt1"] = rbhyt["stt"].ToString();
                            r12["tennhombhyt1"] = rbhyt["ten"].ToString();
                            r12["sotienct"] = ads.Tables[0].Rows[0]["sotienct"].ToString();
                            r12["sttduyet"] = ads.Tables[0].Rows[0]["sttduyet"].ToString();

                            ads.Tables[0].Rows.Add(r12);


                            //if (rbhyt["stt"].ToString() == "9")
                            //{
                            //    DataRow r13 = r12.ItemArray;
                            //    r13["sttbhyt1"] = 92;
                            //    r13["tennhombhyt1"] = "Ngoài danh mục BHYT";
                            //    ads.Tables[0].Rows.Add(r13);
                            //    DataRow r14 = r12.ItemArray;
                            //    r14["sttbhyt1"] = 93;
                            //    r14["tennhombhyt1"] = "Thuốc điều trị ung thư, chống thải ghép ngoài danh mục";
                            //    ads.Tables[0].Rows.Add(r14);
                            //}
                            //else if (rbhyt["stt"].ToString() == "10")
                            //{
                            //    DataRow r15 = r12.ItemArray;
                            //    r15["sttbhyt1"] = 101;
                            //    r15["tennhombhyt1"] = "Ngoài danh mục BHYT";
                            //    ads.Tables[0].Rows.Add(r15);
                            //}
                        }
                    }

                    ads.AcceptChanges();
                }
                string str2 = "";
                string str3 = "";
                string str4 = "";
                string str5 = "";
                if ((this.ads != null) && (this.ads.Tables[0].Rows.Count > 0))
                {
                    str2 = (this.ads.Tables[0].Rows[0]["chandoan"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["chandoan"].ToString() + ",") : "";
                    str3 = (this.ads.Tables[0].Rows[0]["maicd"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["maicd"].ToString() + ",") : "";
                    str4 = (this.ads.Tables[0].Rows[0]["tenkp"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["tenkp"].ToString() + ",") : "";
                    this.ads.Tables[0].Columns.Add("sotoa");
                    this.ads.Tables[0].Columns.Add("trieuchung");
                    this.ads.Tables[0].Columns.Add("ghichu");
                    this.ads.Tables[0].Columns.Add("somau01");//binh 200711
                    string str6 = v_mavaovien.ToString() + ",";
                    string user = this.m_v.user;
                    string str8 = "";
                    string str9 = "";
                    int num = data.get_sophieu_bhyt_userid(v_mmyy, v_mabn, decimal.Parse(v_mavaovien), ngay, 1, 0);

                    foreach (DataRow row in this.ads.Tables[0].Rows)
                    {
                        if (str6.IndexOf(row["maql"].ToString()) == -1)
                        {
                            str6 = str6 + row["maql"].ToString() + ",";
                        }
                        row["somau01"] = num;
                    }
                    ads.AcceptChanges();
                    if (str6 != "")
                    {
                        string s = "01/" + v_mmyy.Substring(0, 2) + "/20" + v_mmyy.Substring(2);
                        string tu = this.m_v.DateToString("dd/MM/yyyy", this.m_v.StringToDate(s).AddDays(-1.0));
                        bool flag = false;
                        str17 = "select a.maicd,a.chandoan,b.tenkp,nvl(c.lydo,'') as lydo,nvl(d.ten,'') as trieuchung from " + user + v_mmyy + ".benhanpk a," + user + ".btdkp_bv b," + user + v_mmyy + ".lydokham c," + user + v_mmyy + ".trieuchung d";
                        sql = str17 + " where a.makp=b.makp and a.maql=c.maql(+) and a.maql=d.maql(+) and (a.maql in (" + str6.Substring(0, str6.Length - 1) + ") or a.mavaovien in (" + str6.Substring(0, str6.Length - 1) + "))";
                        foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                        {
                            if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                            {
                                str2 = str2 + row["chandoan"].ToString() + ",";
                            }
                            if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                            {
                                str3 = str3 + row["maicd"].ToString() + ",";
                            }
                            if ((row["tenkp"].ToString().Trim() != "") && (str4.IndexOf(row["tenkp"].ToString().Trim()) == -1))
                            {
                                str4 = str4 + row["tenkp"].ToString() + ",";
                            }
                            if ((row["lydo"].ToString().Trim() != "") && (str9.IndexOf(row["lydo"].ToString().Trim()) == -1))
                            {
                                str9 = str9 + row["lydo"].ToString() + ",";
                            }
                            if ((row["trieuchung"].ToString().Trim() != "") && (str9.IndexOf(row["trieuchung"].ToString().Trim()) == -1))
                            {
                                str9 = str9 + row["trieuchung"].ToString() + ",";
                            }
                            str5 = row["lydo"].ToString();
                            flag = true;
                        }
                        if (!flag)
                        {
                            str17 = "select a.maicd,a.chandoan,b.tenkp,nvl(c.lydo,'') as lydo from " + user + v_mmyy + ".benhanpk a," + user + ".btdkp_bv b," + user + v_mmyy + ".lydokham c";
                            sql = str17 + " where a.makp=b.makp and a.maql=c.maql(+) and a.mabn='" + v_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and a.madoituong=1";
                            foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                            {
                                if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                                {
                                    str2 = str2 + row["chandoan"].ToString() + ",";
                                }
                                if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                                {
                                    str3 = str3 + row["maicd"].ToString() + ",";
                                }
                                if ((row["tenkp"].ToString().Trim() != "") && (str4.IndexOf(row["tenkp"].ToString().Trim()) == -1))
                                {
                                    str4 = str4 + row["tenkp"].ToString() + ",";
                                }
                                str5 = row["lydo"].ToString();
                                flag = true;
                            }
                        }
                        str17 = ("select maicd,chandoan from " + user + ".cdkemtheo where maql in (" + str6.Substring(0, str6.Length - 1) + ")") + " union all ";
                        sql = str17 + "select maicd,chandoan from " + user + v_mmyy + ".cdkemtheo where maql in (" + str6.Substring(0, str6.Length - 1) + ")";
                        foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                        {
                            if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
                            {
                                str2 = str2 + row["chandoan"].ToString() + ",";
                            }
                            if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
                            {
                                str3 = str3 + row["maicd"].ToString() + ",";
                            }
                        }
                        if (str5 == "")
                        {
                            sql = "select lydo from " + user + v_mmyy + ".lydokham where maql in (" + str6.Substring(0, str6.Length - 1) + ")";
                            foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
                            {
                                str5 = row["lydo"].ToString() + ",";
                            }
                        }
                        foreach (DataRow row in this.m_v.get_data("select sotoa from " + user + v_mmyy + ".bhytkb where maql in (" + str6.Substring(0, str6.Length - 1) + ")").Tables[0].Rows)
                        {
                            str8 = str8 + row["sotoa"].ToString();
                            break;
                        }
                        if (str8 == "")
                        {
                            foreach (DataRow row in this.m_v.get_data("select sotoa from " + user + v_mmyy + ".bhytkb where mavaovien=" + v_mavaovien).Tables[0].Rows)
                            {
                                str8 = str8 + row["sotoa"].ToString();
                                break;
                            }
                        }
                        foreach (DataRow row in this.ads.Tables[0].Rows)
                        {
                            row["chandoan"] = str2;
                            row["maicd"] = str3;
                            row["sotoa"] = str8;
                            row["tenkp"] = str4;
                            row["trieuchung"] = str9;
                            row["ghichu"] = str5;
                        }
                    }
                    //int num = data.get_sophieu_bhyt_userid(v_mmyy, v_mabn, decimal.Parse(v_mavaovien), ngay, 1, 0);
                    int asotient = data.get_laninkb(v_mmyy, v_mabn, decimal.Parse(v_mavaovien), ngay, 1);
                    this.ads.WriteXml(@"..\..\Datareport\" + aReport.Replace(".rpt", ".xml"), XmlWriteMode.WriteSchema);
                    string syte = "";
                    string tenbv = "";
                    string str14 = "";
                    string str15 = "";
                    string str16 = "";
                    syte = this.m_v.Syte;
                    tenbv = this.m_v.Tenbv;
                    str14 = this.f_GetNgay(this.ads.Tables[0].Rows[0]["ngay"].ToString());
                    str15 = this.ads.Tables[0].Rows[0]["userid"].ToString();
                    str16 = "";
                    this.cMain = new ReportDocument();
                    this.cMain.Load(@"..\..\..\report\" + this.aReport, OpenReportMethod.OpenReportByTempCopy);
                    this.cMain.SetDataSource(this.ads);
                    this.cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + syte.ToUpper() + "'";
                    this.cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + tenbv.ToUpper() + "'";
                    this.cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + str14 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + str15 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + str16 + "'";
                    this.cMain.DataDefinition.FormulaFields["v_congkhamBHYT"].Text = "'" + v_congkhamBHYT + "'";
                    this.Text = this.aReport;
                    if (!v_dir)
                    {
                        this.crystalReportViewer1.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        base.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        this.crystalReportViewer1.ReportSource = this.cMain;
                        base.WindowState = FormWindowState.Maximized;
                        base.ShowDialog(base.Parent);
                    }
                    else
                    {
                        this.cMain.PrintToPrinter(1, false, 0, 0);
                    }
                    this.cMain.Close();
                    this.cMain.Dispose();

                    //binh 260711
                    if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
                    {
                        if (num > 0 && b_dahoantat_mau38 == false)
                        {
                            DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã hoàn tất chi phí chưa?"), "Medisoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (dlg == DialogResult.Yes) b_dahoantat_mau38 = true;
                        }
                        if (b_dahoantat_mau38 && num > 0)
                        {
                            f_upd_dain_mau38(v_mmyy, v_mabn, v_mavaovien, num.ToString());
                        }
                    }
                    //
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, aReport + "\n" + exception.ToString(), this.m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

       
        #region bo // khuyen 25/02/14
        //public void f_Print_ChiphiTTRVNgtruCT_tenreport(bool v_dir, string v_id, string v_mmyy, string v_mabn, string v_mavaovien, decimal v_congkhamBHYT, string ngay, string v_tenreport, bool v_chuyenchungtu, bool bHoantat_38, int v_userid, string v_hotenuserid)
        //{
        //    this.aReport = m_v.get_report_name(v_tenreport);//"v_thanhtoanravienngtru_chitiet.rpt");
        //    bool b_dahoantat_mau38 = false;
        //    bool bGheptenKTXQ_15042012 = m_v.bKTXQuang_TuKThuatThu2TroDiTinhGia_BHYTKhac;// true;
        //    bool bMau01_chilayca_dathuchien = m_v.sys_mau01_chitinhthuchien == "1";
        //    string s_ktvienphi = m_v.sys_ketoanvp;
        //    string s_hotengiamdoc = m_v.f_get_giamdoc_chinhanh(m_v.i_Chinhanh_hientai.ToString());
        //    //
        //    string s_maicd_chinh = "", s_chandoan_chinh = "", s_chandoansobo = "", s_maicd_kemtheo = "", s_chandoan_kemtheo = "";
        //    //
        //    try
        //    {
        //        string str17;
        //        LibDuoc.AccessData data = new LibDuoc.AccessData();
        //        bool bMau38_01_daydu = true;
        //        string sql = "";
        //        string tmp_userid = v_userid.ToString();
        //        string m_mavp_ck = m_v.f_get_mavp_congkham();
        //        bool bUserid_thuoc = false, bUserid_cls = false;
        //        string m_ngayvaovien = ngay;
        //        if (v_mavaovien.Length > 10)
        //        {
        //            m_ngayvaovien = v_mavaovien.Substring(4, 2) + "/" + v_mavaovien.Substring(2, 2) + "/20" + v_mavaovien.Substring(0, 2);
        //        }
        //        string s_ngayhoantat = ngay, tmp_ngayvao = "999912312359", tmp_ngayhoantat = "0", s_ngayvao = ngay, s_ngayra = ngay, s_chandoan = "", s_icd10 = "", s_ngaythutien = "";
        //        if (v_mmyy == "")
        //        {
        //            v_mmyy = this.m_v.s_curmmyy;
        //        }
        //        //sql = " select a.stt as sttbhyt, a.id as idnhombhyt, a.ten as tennhombhyt, b.* from medibv.v_nhombhyt a left join ( ";
        //        //thuoc_vattu
        //        sql = "select d.id,d.ma,trim(d.ten)||' '||d.hamluong as ten,d.dang as dvt, d.hamluong,d.tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua, '' as cachdung,";
        //        sql += "f.ma as id_nhom, f1.ten as tennhom, f1.stt as stt_nhom,a.mabn,g.hoten,g.namsinh, g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as diachi,";
        //        sql += "case when b1.traituyen is null then to_number('0') else b1.traituyen end as traituyen,b1.sothe, to_char(b1.tungay,'dd/mm/yyyy') as tungay,to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay, to_char(nvl(c.ngay,b.ngay),'dd/mm/yyyy') as ngayct,";
        //        sql += "to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra ,b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem,b1.mabv,k.tenbv,l.tenkp,a.maicd,a.chandoan,";
        //        //sql += "g.phai,tamung,x.tenbv as dkkcb,c.bhyttra+c.tradongchitra as bhtra,c.soluong*c.dongia-c.bhyttra-c.tradongchitra as bntra,a.maql,y.hoten as tenuser,c.madoituong,z.doituong,d.kythuat";
        //        sql += "g.phai,tamung,x.tenbv as dkkcb,c.bhyttra+c.tradongchitra as bhtra,c.sotien-c.bhyttra-c.tradongchitra as bntra,a.maql,y.hoten as tenuser,c.madoituong,z.doituong,d.kythuat";
        //        sql += " , f.idnhombhyt, f1.stt as sttbhyt, f1.ten as tennhombhyt ";
        //        sql += " , f1.stt as sttbhyt1, f1.ten as tennhombhyt1, lh.soluutru, ld.lydo as chandoansobo, ld.phanbiet ";
        //        sql += ", c.idchinhanh, c.idchinhanhden, a.dain38, c.phuthu, a.id as idttrv, g.cholam, c.sotien as sotienct, to_number('0') as thuoccls, to_char(b.ngay,'yyyymmddhh24mi') as ngaythutien, to_char(b.ngay,'dd/MM/yyyy hh24:mi') as ngaythu ";
        //        sql += ", to_char(a.ngayvao,'yyyymmddhh24mi') as ngaygiovao, to_char(a.ngayra,'yyyymmddhh24mi') as ngaygiora ";
        //        sql += ", c.lan, c.idtonghop, c.sttduyet, c.ngansachhotro ";//binh 14042012
        //        sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id inner join medibvmmyy.v_ttrvct c on  b.id=c.id inner join medibv.d_dmbd d on c.mavp=d.id";
        //        sql += " inner join medibv.d_dmnhom e on  d.manhom=e.id inner join medibv.v_nhomvp f on e.nhomvp=f.ma inner join medibv.v_nhombhyt f1 on f.idnhombhyt=f1.id inner join medibv.btdbn g on  a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner join medibv.btdquan i on  g.maqu=i.maqu ";
        //        sql += " inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa left join  medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp  ";
        //        if (v_chuyenchungtu == false) sql += " inner join medibv.v_quyenso m on b.quyenso=m.id  ";
        //        else sql += " left join medibv.v_quyenso m on b.quyenso=m.id  ";
        //        sql += " left join medibv.dmnoicapbhyt x on b1.mabv=x.mabv  left join medibv.v_dlogin y on b.userid=y.id left join medibv.doituong z on c.madoituong=z.madoituong";
        //        sql += " left join medibvmmyy.lienhe lh on a.maql=lh.maql ";
        //        sql += " left join medibvmmyy.lydokham ld on a.maql=ld.maql ";

        //        sql += " where a.mavaovien=" + v_mavaovien + " and a.mabn='" + v_mabn + "'";// and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";

        //        sql += " and c.bhyttra>0 and (c.tra=0) and c.madoituong not in (5) "; //sql += " and c.bhyttra>0 and (c.idtra=0 or c.idtra is null) and c.madoituong not in (5) ";
        //        sql += " and c.dongchitra <> 2 ";
        //        //hoan tra
        //        //sql+=" and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
        //        //sql+=" where a.mavaovien=" + v_mavaovien + " and mabn='" + v_mabn + "'";
        //        //sql += " and to_char(ngay,'dd/mm/yyyy')='" + ngay + "')";//chi in trong ngay
        //        //
        //        if (v_chuyenchungtu) sql += " and c.idchinhanh<>c.idchinhanhden ";
        //        else sql += " and c.idchinhanh=c.idchinhanhden ";
        //        //sql += ") b on a.id=b.idnhombhyt ";
        //        //
        //        sql += " order by a.id, c.sttduyet";
        //        //
        //        this.ads = new DataSet();
        //        if (ngay == "") ngay = m_v.ngayhienhanh_server.Substring(0, 10);
        //        this.ads = this.m_v.get_data_bc_1(m_ngayvaovien, ngay, sql);

        //        //vien phi
        //        //sql = " select a.stt as sttbhyt, a.id as idnhombhyt, a.ten as tennhombhyt, b.* from medibv.v_nhombhyt a left join ( ";
        //        string sql_chidinh = "select id, mabn, mavaovien, maql, mavp, done, paid from medibvmmyy.v_chidinh ";
        //        sql_chidinh = m_v.get_sql_mmyy(sql_chidinh, ngay, ngay, m_v.iNgaykiemke);
        //        ////
        //        sql = " select d.id,d.ma,case when (c.ten is null or trim(c.ten)='') then d.ten else c.ten end as ten,d.dvt, '' as hamluong,'' as tenhc,c.soluong,c.dongia as giaban, c.dongia as giamua,'' as cachdung, f.ma as id_nhom, f1.ten as tennhom,f1.stt as stt_nhom, a.mabn,g.hoten,g.namsinh,";
        //        sql += "g.sonha||', '||g.thon||', '||j.tenpxa||', '||i.tenquan||', '||h.tentt as  diachi,case when b1.traituyen is null then to_number('0') else b1.traituyen end as traituyen,b1.sothe,to_char(b1.tungay,'dd/mm/yyyy') as tungay,to_char(b1.ngay,'dd/mm/yyyy') as denngay, to_char(b.ngay,'dd/mm/yyyy') as ngay,";
        //        sql += "to_char(nvl(c.ngay,b.ngay),'dd/mm/yyyy') as ngayct, to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra, b.userid,m.sohieu,b.sobienlai,b.sotien,b.bhyt as bhyttra,b.nopthem,b1.mabv,k.tenbv,l.tenkp,";
        //        //sql += "a.maicd,a.chandoan,g.phai,tamung,x.tenbv as dkkcb,c.bhyttra+c.tradongchitra as bhtra,c.soluong*c.dongia-c.bhyttra-c.tradongchitra as bntra,a.maql,y.hoten as tenuser,c.madoituong,z.doituong,d.kythuat";
        //        sql += "a.maicd,a.chandoan,g.phai,tamung,x.tenbv as dkkcb,c.bhyttra+c.tradongchitra as bhtra,c.sotien-c.bhyttra-c.tradongchitra as bntra,a.maql,y.hoten as tenuser,c.madoituong,z.doituong,d.kythuat";
        //        sql += " , f.idnhombhyt, f1.stt as sttbhyt, f1.ten as tennhombhyt ";
        //        sql += " , f1.stt as sttbhyt1, f1.ten as tennhombhyt1, lh.soluutru, ld.lydo as chandoansobo, ld.phanbiet ";
        //        sql += ", c.idchinhanh, c.idchinhanhden, a.dain38, c.phuthu, a.id as idttrv, g.cholam, c.sotien as sotienct, to_number('1') as thuoccls, to_char(b.ngay,'yyyymmddhh24mi') as ngaythutien, to_char(b.ngay,'dd/MM/yyyy hh24:mi') as ngaythu ";
        //        sql += ", to_char(a.ngayvao,'yyyymmddhh24mi') as ngaygiovao, to_char(a.ngayra,'yyyymmddhh24mi') as ngaygiora ";
        //        sql += ", c.lan, c.idtonghop, c.sttduyet, c.ngansachhotro ";//binh 14042012
        //        sql += " from medibvmmyy.v_ttrvds a inner join  medibvmmyy.v_ttrvll b on a.id=b.id left join medibvmmyy.v_ttrvbhyt b1 on b.id=b1.id  inner join medibvmmyy.v_ttrvct c on b.id=c.id inner join medibv.v_giavp d on c.mavp=d.id inner join medibv.v_loaivp e on d.id_loai=e.id ";
        //        sql += " inner join medibv.v_nhomvp f on e.id_nhom=f.ma inner join medibv.v_nhombhyt f1 on f.idnhombhyt=f1.id inner join medibv.btdbn g on a.mabn=g.mabn inner join medibv.btdtt h on g.matt=h.matt inner  join medibv.btdquan i on g.maqu=i.maqu inner join medibv.btdpxa j on g.maphuongxa=j.maphuongxa  ";
        //        sql += " left join medibv.tenvien k on b1.mabv=k.mabv inner join medibv.btdkp_bv l on b.makp=l.makp  ";//inner join medibv.v_quyenso m on b.quyenso=m.id                  
        //        if (v_chuyenchungtu == false) sql += " inner join medibv.v_quyenso m on b.quyenso=m.id  ";
        //        else sql += " left join medibv.v_quyenso m on b.quyenso=m.id  ";
        //        sql += " left join medibv.dmnoicapbhyt x on b1.mabv=x.mabv  left join medibv.v_dlogin y on b.userid=y.id left join medibv.doituong z on c.madoituong=z.madoituong";
        //        sql += " left join medibvmmyy.lienhe lh on a.maql=lh.maql ";
        //        sql += " left join medibvmmyy.lydokham ld on a.maql=ld.maql ";
        //        //
        //        if (bMau01_chilayca_dathuchien) sql += " Left join (" + sql_chidinh + ") cd on c.idtonghop=cd.id "; //binh 17122011 
        //        //
        //        sql += " where a.mavaovien=" + v_mavaovien + " and a.mabn='" + v_mabn + "'";// and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";
        //        sql += " and c.bhyttra>0 and (c.tra=0) and c.madoituong not in (5)"; //sql += " and c.bhyttra>0 and (c.idtra=0 or c.idtra is null) and c.madoituong not in (5)";
        //        sql += " and c.dongchitra <> 2 ";
        //        if (bMau01_chilayca_dathuchien) sql += " and (cd.done <> 0 or d.thuchien=0)";//binh 17122011
        //        //Hoan tra
        //        //sql += " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ";
        //        //sql += " where mavaovien=" + v_mavaovien + " and mabn='" + v_mabn + "'";
        //        //sql += " and to_char(ngay,'dd/mm/yyyy')='" + ngay + "')";//in trong ngay
        //        //
        //        if (v_chuyenchungtu) sql += " and c.idchinhanh<>c.idchinhanhden  and to_char(b.ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "'";
        //        else sql += " and c.idchinhanh=c.idchinhanhden ";
        //        //
        //        sql += " order by a.id, c.sttduyet";
        //        //sql += ") b on a.id=b.idnhombhyt ";
        //        if (ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
        //        {
        //            this.m_v.merge(this.ads, this.m_v.get_data_bc_1(m_ngayvaovien, ngay, sql));//this.m_v.merge(this.ads, this.m_v.get_data_mmyy(v_mmyy, sql));
        //        }
        //        else ads = m_v.get_data_bc_1(m_ngayvaovien, ngay, sql);
        //        if (bMau38_01_daydu && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
        //        {
        //            DataSet dsnhombhyt = m_v.get_data(" select id, stt, ten from medibv.v_nhombhyt order by stt ");
        //            //
        //            DataRow dr1 = dsnhombhyt.Tables[0].NewRow();
        //            dr1["stt"] = "92";
        //            dr1["id"] = "92";
        //            dr1["ten"] = "Ngoài danh mục BHYT";
        //            dsnhombhyt.Tables[0].Rows.Add(dr1);
        //            DataRow dr2 = dsnhombhyt.Tables[0].NewRow();
        //            dr2["stt"] = "93";
        //            dr2["id"] = "93";
        //            dr2["ten"] = "Thuốc điều trị ung thư, chống thải ghép ngoài danh mục";
        //            dsnhombhyt.Tables[0].Rows.Add(dr2);
        //            DataRow dr3 = dsnhombhyt.Tables[0].NewRow();
        //            dr3["stt"] = "101";
        //            dr3["id"] = "101";
        //            dr3["ten"] = "Ngoài danh mục BHYT";
        //            dsnhombhyt.Tables[0].Rows.Add(dr3);
        //            dsnhombhyt.AcceptChanges();
        //            //
        //            DataRow r11;
        //            string s_colname = "";
        //            foreach (DataRow rbhyt in dsnhombhyt.Tables[0].Rows)
        //            {
        //                r11 = m_v.getrowbyid(ads.Tables[0], "sttbhyt=" + rbhyt["stt"].ToString());
        //                if (r11 == null)
        //                {
        //                    DataRow r12 = ads.Tables[0].NewRow();

        //                    r12["id"] = 0;
        //                    r12["ma"] = "";
        //                    r12["ten"] = "";
        //                    r12["hamluong"] = "";
        //                    r12["dvt"] = "";
        //                    r12["tenhc"] = "";
        //                    r12["cachdung"] = "";
        //                    r12["soluong"] = 0;
        //                    r12["giamua"] = 0;
        //                    r12["giaban"] = 0;
        //                    r12["id_nhom"] = 0;
        //                    r12["tennhom"] = "";

        //                    r12["stt_nhom"] = 0;
        //                    r12["mabn"] = ads.Tables[0].Rows[0]["mabn"].ToString();
        //                    r12["hoten"] = ads.Tables[0].Rows[0]["hoten"].ToString();
        //                    r12["namsinh"] = ads.Tables[0].Rows[0]["namsinh"].ToString();
        //                    r12["diachi"] = ads.Tables[0].Rows[0]["diachi"].ToString().Trim().Trim(',');
        //                    r12["sothe"] = ads.Tables[0].Rows[0]["sothe"].ToString();
        //                    r12["traituyen"] = ads.Tables[0].Rows[0]["traituyen"].ToString();
        //                    r12["tungay"] = ads.Tables[0].Rows[0]["tungay"].ToString();
        //                    r12["denngay"] = ads.Tables[0].Rows[0]["denngay"].ToString();
        //                    r12["ngay"] = ads.Tables[0].Rows[0]["ngay"].ToString();
        //                    r12["ngayct"] = ads.Tables[0].Rows[0]["ngayct"].ToString();
        //                    r12["ngayvao"] = ads.Tables[0].Rows[0]["ngayvao"].ToString();
        //                    r12["ngayra"] = ads.Tables[0].Rows[0]["ngayra"].ToString();

        //                    r12["userid"] = ads.Tables[0].Rows[0]["userid"].ToString();
        //                    r12["sohieu"] = ads.Tables[0].Rows[0]["sohieu"].ToString();
        //                    r12["sobienlai"] = ads.Tables[0].Rows[0]["sobienlai"].ToString();
        //                    r12["sotien"] = 0;// ads.Tables[0].Rows[0]["sotien"].ToString();
        //                    r12["bhyttra"] = 0;// ads.Tables[0].Rows[0]["bhyttra"].ToString();
        //                    r12["nopthem"] = ads.Tables[0].Rows[0]["nopthem"].ToString();
        //                    r12["mabv"] = ads.Tables[0].Rows[0]["mabv"].ToString();
        //                    r12["tenbv"] = ads.Tables[0].Rows[0]["tenbv"].ToString();
        //                    r12["tenkp"] = ads.Tables[0].Rows[0]["tenkp"].ToString();
        //                    r12["maicd"] = ads.Tables[0].Rows[0]["maicd"].ToString();
        //                    r12["chandoan"] = ads.Tables[0].Rows[0]["chandoan"].ToString();
        //                    r12["phai"] = ads.Tables[0].Rows[0]["phai"].ToString();
        //                    r12["tamung"] = ads.Tables[0].Rows[0]["tamung"].ToString();
        //                    r12["dkkcb"] = ads.Tables[0].Rows[0]["dkkcb"].ToString();
        //                    r12["bhtra"] = 0;// ads.Tables[0].Rows[0]["bhtra"].ToString();
        //                    r12["bntra"] = 0;// ads.Tables[0].Rows[0]["bntra"].ToString();
        //                    r12["maql"] = ads.Tables[0].Rows[0]["maql"].ToString();
        //                    r12["tenuser"] = ads.Tables[0].Rows[0]["tenuser"].ToString();
        //                    r12["madoituong"] = ads.Tables[0].Rows[0]["madoituong"].ToString();
        //                    r12["doituong"] = ads.Tables[0].Rows[0]["doituong"].ToString();
        //                    r12["soluutru"] = ads.Tables[0].Rows[0]["soluutru"].ToString();
        //                    r12["cholam"] = ads.Tables[0].Rows[0]["cholam"].ToString();

        //                    r12["kythuat"] = -1;
        //                    r12["sotienct"] = 0;

        //                    r12["idnhombhyt"] = rbhyt["id"].ToString();
        //                    r12["sttbhyt"] = rbhyt["stt"].ToString();
        //                    r12["tennhombhyt"] = rbhyt["ten"].ToString();


        //                    r12["sttbhyt1"] = rbhyt["stt"].ToString();
        //                    r12["tennhombhyt1"] = rbhyt["ten"].ToString();
        //                    r12["thuoccls"] = "0";
        //                    r12["ngaythutien"] = "0";
        //                    r12["ngaygiovao"] = "0";
        //                    r12["ngaygiora"] = "0";
        //                    r12["ngansachhotro"] = "0";

        //                    ads.Tables[0].Rows.Add(r12);


        //                    //if (rbhyt["stt"].ToString() == "9")
        //                    //{
        //                    //    DataRow r13 = r12.ItemArray;
        //                    //    r13["sttbhyt1"] = 92;
        //                    //    r13["tennhombhyt1"] = "Ngoài danh mục BHYT";
        //                    //    ads.Tables[0].Rows.Add(r13);
        //                    //    DataRow r14 = r12.ItemArray;
        //                    //    r14["sttbhyt1"] = 93;
        //                    //    r14["tennhombhyt1"] = "Thuốc điều trị ung thư, chống thải ghép ngoài danh mục";
        //                    //    ads.Tables[0].Rows.Add(r14);
        //                    //}
        //                    //else if (rbhyt["stt"].ToString() == "10")
        //                    //{
        //                    //    DataRow r15 = r12.ItemArray;
        //                    //    r15["sttbhyt1"] = 101;
        //                    //    r15["tennhombhyt1"] = "Ngoài danh mục BHYT";
        //                    //    ads.Tables[0].Rows.Add(r15);
        //                    //}
        //                }
        //            }

        //            ads.AcceptChanges();
        //        }
        //        string str2 = "";
        //        string str3 = "";
        //        string str4 = "";
        //        string str5 = "";
        //        if ((this.ads != null) && (this.ads.Tables[0].Rows.Count > 0))
        //        {
        //            str2 = (this.ads.Tables[0].Rows[0]["chandoan"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["chandoan"].ToString() + ",") : "";
        //            str3 = (this.ads.Tables[0].Rows[0]["maicd"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["maicd"].ToString() + ",") : "";
        //            str4 = (this.ads.Tables[0].Rows[0]["tenkp"].ToString().Trim() != "") ? (this.ads.Tables[0].Rows[0]["tenkp"].ToString() + ",") : "";
        //            this.ads.Tables[0].Columns.Add("sotoa");
        //            this.ads.Tables[0].Columns.Add("trieuchung");
        //            this.ads.Tables[0].Columns.Add("ghichu");
        //            this.ads.Tables[0].Columns.Add("somau01");//binh 200711
        //            this.ads.Tables[0].Columns.Add("ketoanvp");//binh 200711
        //            this.ads.Tables[0].Columns.Add("giamdoc");//binh 200711
        //            string str6 = v_mavaovien.ToString() + ",";
        //            string user = this.m_v.user;
        //            string str8 = "";
        //            string str9 = "";
        //            int i_sophieu38 = 0;//
        //            if (b_dahoantat_mau38 == false) b_dahoantat_mau38 = ads.Tables[0].Select("phuthu=3").Length > 0;//neu BN da co toa thuoc thi xem nhu chac chan hoan tat mau 38bv
        //            //
        //            string s_ngaycapstt38 = "01/" + ngay.Substring(3, 2) + "/" + ngay.Substring(6, 4);
        //            //
        //            i_sophieu38 = data.get_sophieu_bhyt_userid(v_mmyy, v_mabn, long.Parse(v_mavaovien), s_ngaycapstt38, 1, 0);//Cap stt theo thang -->nen ngay cap trong thang la ngay 1
        //            string s_idttrv = "";
        //            s_hotengiamdoc = "";
        //            decimal d_tongchiphi_bhyt = 0;
        //            if (bMau01_chilayca_dathuchien)
        //            {
        //                foreach (DataRow row in this.ads.Tables[0].Select("traituyen=0 and sotienct>0", "ngaythutien desc"))//.Rows)
        //                {
        //                    d_tongchiphi_bhyt += decimal.Parse(row["sotienct"].ToString());
        //                }
        //                if (d_tongchiphi_bhyt < m_v.ma13_st(m_v.nhom_duoc))
        //                {
        //                    foreach (DataRow row in this.ads.Tables[0].Select("traituyen=0 and sotienct>0", "ngaythutien desc"))//.Rows)
        //                    {
        //                        row["bhtra"] = row["sotienct"].ToString();
        //                        row["bntra"] = 0;
        //                    }
        //                }
        //                ads.AcceptChanges();
        //            }
        //            foreach (DataRow row in this.ads.Tables[0].Select("", "ngaythutien desc"))//.Rows)
        //            {
        //                if (s_hotengiamdoc.Trim() == "") s_hotengiamdoc = m_v.f_get_giamdoc_chinhanh(row["idchinhanhden"].ToString());
        //                if (row["ngaythu"].ToString().Trim() != "") s_ngaythutien = row["ngaythu"].ToString();
        //                if (long.Parse(row["ngaygiovao"].ToString()) > 0 && long.Parse(row["ngaygiovao"].ToString()) < long.Parse(tmp_ngayvao))
        //                {
        //                    tmp_ngayvao = row["ngaygiovao"].ToString();
        //                    s_ngayvao = row["ngayvao"].ToString();
        //                }
        //                if (long.Parse(row["ngaythutien"].ToString()) > 0 && long.Parse(row["ngaythutien"].ToString()) < long.Parse(tmp_ngayvao))
        //                {
        //                    tmp_ngayvao = row["ngaythutien"].ToString();
        //                    s_ngayvao = row["ngaythu"].ToString();
        //                }
        //                if (long.Parse(row["ngaygiora"].ToString()) > long.Parse(tmp_ngayhoantat))
        //                {
        //                    s_ngayhoantat = row["ngayra"].ToString();
        //                    tmp_ngayhoantat = row["ngaygiora"].ToString();
        //                    s_ngayra = row["ngayra"].ToString();
        //                }
        //                if (long.Parse(row["ngaythutien"].ToString()) > long.Parse(tmp_ngayhoantat))
        //                {
        //                    s_ngayhoantat = row["ngay"].ToString();//v_ttrvll.ngay
        //                    tmp_ngayhoantat = row["ngaythutien"].ToString();
        //                    s_ngayra = row["ngaythu"].ToString();//v_ttrvll.ngay
        //                }
        //                if (s_idttrv.IndexOf(row["idttrv"].ToString() + ",") < 0) s_idttrv += row["idttrv"].ToString() + ",";
        //                if (str6.IndexOf(row["maql"].ToString()) == -1)
        //                {
        //                    str6 = str6 + row["maql"].ToString() + ",";
        //                }
        //                row["somau01"] = i_sophieu38;
        //                if (bUserid_thuoc == false && row["thuoccls"].ToString() == "0")
        //                {
        //                    tmp_userid = row["userid"].ToString();
        //                    bUserid_thuoc = true;
        //                }
        //                else if (bUserid_thuoc == false && bUserid_cls == false && row["thuoccls"].ToString() == "1")
        //                {
        //                    if (m_mavp_ck.IndexOf(row["id"].ToString() + ",") >= 0) bUserid_cls = false;
        //                    else bUserid_cls = true;
        //                    tmp_userid = row["userid"].ToString();

        //                }
        //                row["giamdoc"] = s_hotengiamdoc;
        //                row["ketoanvp"] = s_ktvienphi;
        //            }
        //            ads.AcceptChanges();
        //            if (str6 != "")
        //            {
        //                string s = "01/" + v_mmyy.Substring(0, 2) + "/20" + v_mmyy.Substring(2);
        //                string tu = this.m_v.DateToString("dd/MM/yyyy", this.m_v.StringToDate(s).AddDays(-1.0));
        //                bool flag = false;
        //                str17 = "select a.maicd,a.chandoan,b.tenkp,nvl(c.lydo,'') as lydo,nvl(d.ten,'') as trieuchung from " + user + v_mmyy + ".benhanpk a," + user + ".btdkp_bv b," + user + v_mmyy + ".lydokham c," + user + v_mmyy + ".trieuchung d";
        //                sql = str17 + " where a.makp=b.makp and a.maql=c.maql(+) and a.maql=d.maql(+) and (a.maql in (" + str6.Substring(0, str6.Length - 1) + ") or a.mavaovien in (" + str6.Substring(0, str6.Length - 1) + "))";
        //                foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
        //                {

        //                    s_chandoan_chinh = row["chandoan"].ToString().Trim();
        //                    s_maicd_chinh = row["maicd"].ToString().Trim();

        //                    if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
        //                    {
        //                        str2 = str2.Trim().Trim(',') + ", " + row["chandoan"].ToString().Trim();
        //                    }
        //                    if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
        //                    {
        //                        str3 = str3.Trim().Trim(',') + ", " + row["maicd"].ToString().Trim();
        //                    }
        //                    if ((row["tenkp"].ToString().Trim() != "") && (str4.IndexOf(row["tenkp"].ToString().Trim()) == -1))
        //                    {
        //                        str4 = str4.Trim().Trim(',') + ", " + row["tenkp"].ToString().Trim();
        //                    }
        //                    if ((row["lydo"].ToString().Trim() != "") && (str9.IndexOf(row["lydo"].ToString().Trim()) == -1))
        //                    {
        //                        str9 = str9.Trim().Trim(',') + ", " + row["lydo"].ToString();
        //                    }
        //                    if ((row["trieuchung"].ToString().Trim() != "") && (str9.IndexOf(row["trieuchung"].ToString().Trim()) == -1))
        //                    {
        //                        str9 = str9.Trim().Trim(',') + ", " + row["trieuchung"].ToString().Trim();
        //                    }
        //                    str5 = row["lydo"].ToString();
        //                    flag = true;
        //                }
        //                if (!flag)
        //                {
        //                    str17 = "select a.maicd,a.chandoan,b.tenkp,nvl(c.lydo,'') as lydo from " + user + v_mmyy + ".benhanpk a," + user + ".btdkp_bv b," + user + v_mmyy + ".lydokham c";
        //                    sql = str17 + " where a.makp=b.makp and a.maql=c.maql(+) and a.mabn='" + v_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and a.madoituong=1";
        //                    foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
        //                    {
        //                        if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
        //                        {
        //                            str2 = str2.Trim().Trim(',') + ", " + row["chandoan"].ToString().Trim();
        //                        }
        //                        if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1))
        //                        {
        //                            str3 = str3.Trim().Trim(',') + ", " + row["maicd"].ToString().Trim();
        //                        }
        //                        if ((row["tenkp"].ToString().Trim() != "") && (str4.IndexOf(row["tenkp"].ToString().Trim()) == -1))
        //                        {
        //                            str4 = str4.Trim().Trim(',') + ", " + row["tenkp"].ToString().Trim();
        //                        }
        //                        str5 = row["lydo"].ToString();
        //                        flag = true;
        //                    }
        //                }
        //                str17 = ("select maicd,chandoan from " + user + ".cdkemtheo where maql in (" + str6.Substring(0, str6.Length - 1) + ")") + " union all ";
        //                sql = str17 + "select maicd,chandoan from xxx.cdkemtheo where maql in (" + str6.Substring(0, str6.Length - 1) + ")";
        //                foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
        //                {
        //                    if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
        //                    {
        //                        str2 = str2.Trim().Trim(',') + ", " + row["chandoan"].ToString().Trim();
        //                    }
        //                    if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1) && row["maicd"].ToString().Trim().IndexOf("Z01.") == -1)
        //                    {
        //                        str3 = str3.Trim().Trim(',') + ", " + row["maicd"].ToString() + ",";
        //                    }
        //                }

        //                sql = "select maicd,chandoan, maicdrv, chandoanrv from medibv.benhanngtr where maql in (" + str6.Substring(0, str6.Length - 1) + ") or mavaovien=" + v_mavaovien;
        //                foreach (DataRow row in this.m_v.get_data(sql).Tables[0].Rows)
        //                {
        //                    if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
        //                    {
        //                        str2 = str2.Trim().Trim(',') + ", " + row["chandoan"].ToString().Trim();
        //                    }
        //                    if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1) && row["maicd"].ToString().Trim().IndexOf("Z01.") == -1)
        //                    {
        //                        str3 = str3.Trim().Trim(',') + ", " + row["maicd"].ToString() + ",";
        //                    }

        //                    if ((row["chandoanrv"].ToString().Trim() != "") && (str2.IndexOf(row["chandoanrv"].ToString().Trim()) == -1))
        //                    {
        //                        str2 = str2.Trim().Trim(',') + ", " + row["chandoanrv"].ToString().Trim();
        //                    }
        //                    if ((row["maicdrv"].ToString().Trim() != "") && (str3.IndexOf(row["maicdrv"].ToString().Trim()) == -1) && row["maicdrv"].ToString().Trim().IndexOf("Z01.") == -1)
        //                    {
        //                        str3 = str3.Trim().Trim(',') + ", " + row["maicdrv"].ToString() + ",";
        //                    }
        //                }
        //                //
        //                if (str3.Trim().Trim(',') == "")
        //                {
        //                    sql = "select maicd,chandoan from xxx.v_chidinh where madoituong=1 and paid=1 and maql in (" + str6.Substring(0, str6.Length - 1) + ")";
        //                    foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
        //                    {
        //                        if ((row["chandoan"].ToString().Trim() != "") && (str2.IndexOf(row["chandoan"].ToString().Trim()) == -1))
        //                        {
        //                            str2 = str2.Trim().Trim(',') + ", " + row["chandoan"].ToString().Trim();
        //                        }
        //                        if ((row["maicd"].ToString().Trim() != "") && (str3.IndexOf(row["maicd"].ToString().Trim()) == -1) && str3.IndexOf("Z01.") == -1)
        //                        {
        //                            str3 = str3.Trim().Trim(',') + row["maicd"].ToString() + ",";
        //                        }
        //                    }
        //                }
        //                str3 = str3.Replace("Z01.8", "").Replace("Z01.7", "").Replace("U00", "").Trim().Trim(',');
        //                str2 = str2.Replace("Không xác định", "").Replace("không xác định", "").Trim().Trim(',');
        //                //
        //                if (str5 == "")
        //                {
        //                    sql = "select lydo from xxx.lydokham where maql in (" + str6.Substring(0, str6.Length - 1) + ")";
        //                    foreach (DataRow row in this.m_v.get_data_mmyy(sql, tu, s, false).Tables[0].Rows)
        //                    {
        //                        str5 = row["lydo"].ToString() + ",";
        //                    }
        //                }
        //                foreach (DataRow row in this.m_v.get_data_bc_1(ngay, ngay, "select sotoa from xxx.bhytkb where maql in (" + str6.Substring(0, str6.Length - 1) + ")").Tables[0].Rows)
        //                {
        //                    str8 = str8 + row["sotoa"].ToString();
        //                    break;
        //                }
        //                if (str8 == "")
        //                {
        //                    foreach (DataRow row in this.m_v.get_data_bc_1(ngay, ngay, "select sotoa from xxx.bhytkb where mavaovien=" + v_mavaovien).Tables[0].Rows)
        //                    {
        //                        str8 = str8 + row["sotoa"].ToString();
        //                        break;
        //                    }
        //                }
        //                if (tmp_userid != "")
        //                {
        //                    v_hotenuserid = m_v.f_get_tenuserlogin(int.Parse(tmp_userid));
        //                }
        //                else tmp_userid = v_userid.ToString();
        //                string tmp_ngaydk = "", tmp_ngaydk_yymmdd = "0";
        //                if (v_chuyenchungtu == false)
        //                {
        //                    f_get_ngayvao(v_mabn, v_mavaovien, ref tmp_ngaydk_yymmdd, ref tmp_ngaydk);
        //                    if (tmp_ngaydk != "" && long.Parse(tmp_ngaydk_yymmdd) < long.Parse(tmp_ngayvao)) s_ngayvao = tmp_ngaydk;
        //                }
        //                else if (v_chuyenchungtu && s_ngayvao.Substring(0, 10) != s_ngayra.Substring(0, 10))
        //                {
        //                    s_ngayvao = s_ngaythutien;
        //                }
        //                if (str9 != "" && str2.IndexOf(str9) >= 0) str9 = "";
        //                string s_sttduyettoa = "0", s_exp_toa = "";
        //                foreach (DataRow row in this.ads.Tables[0].Rows)
        //                {
        //                    if (s_sttduyettoa != row["sttduyet"].ToString() && s_exp_toa != row["id"].ToString() + "-" + row["giamua"].ToString())
        //                    {
        //                        s_sttduyettoa = row["sttduyet"].ToString();
        //                        s_exp_toa = row["id"].ToString() + "-" + row["giamua"].ToString();
        //                    }
        //                    row["sttduyet"] = (s_sttduyettoa == "") ? "0" : s_sttduyettoa;
        //                    row["chandoan"] = str2.Trim().Trim(',');
        //                    row["maicd"] = str3.Trim().Trim(',');
        //                    row["sotoa"] = str8.Trim().Trim(',');
        //                    row["tenkp"] = str4.Trim().Trim(',');
        //                    row["trieuchung"] = str9.Trim().Trim(',');
        //                    row["ghichu"] = str5.Trim().Trim(',');
        //                    //
        //                    row["diachi"] = row["diachi"].ToString().Replace("Không xác định", "").Trim().Trim(',');
        //                    row["userid"] = tmp_userid;// v_userid;
        //                    row["tenuser"] = v_hotenuserid;
        //                    //
        //                    row["ngayra"] = s_ngayra;
        //                    row["ngayvao"] = s_ngayvao;
        //                    //
        //                }
        //            }
        //            ads.AcceptChanges();
        //            //
        //            //Ghép Tên KTXQ
        //            if (bGheptenKTXQ_15042012)
        //            {
        //                DataSet dsgiaxq = LayDMKTGiaXQ();
        //                string s_idcd_remove = "", s_idcd_giu = "", s_tenKTGhep = "";
        //                decimal d_giaBH_ghep = 0, d_BNtra_ghep = 0, d_BHTra_ghep = 0;
        //                GhepTenKTXQuang(ads.Tables[0], dsgiaxq.Tables[0], ref s_idcd_remove, ref s_idcd_giu, ref s_tenKTGhep, ref d_giaBH_ghep, ref d_BNtra_ghep, ref d_BHTra_ghep);
        //                if (s_idcd_remove.Trim().Trim(',') != "")
        //                {
        //                    foreach (DataRow dr in ads.Tables[0].Select("idtonghop in(" + s_idcd_remove + ")"))
        //                    {
        //                        ads.Tables[0].Rows.Remove(dr);
        //                    }
        //                    ads.AcceptChanges();
        //                    foreach (DataRow dr in ads.Tables[0].Select("idtonghop in(" + s_idcd_giu + ")"))
        //                    {
        //                        dr["ten"] = s_tenKTGhep;
        //                        dr["giaban"] = d_giaBH_ghep;
        //                        dr["giamua"] = d_giaBH_ghep;
        //                        dr["bhtra"] = d_BHTra_ghep;
        //                        dr["bntra"] = d_BNtra_ghep;
        //                        dr["sotienct"] = d_giaBH_ghep;
        //                    }
        //                    ads.AcceptChanges();
        //                }
        //            }
        //            //
        //            //int num = data.get_sophieu_bhyt_userid(v_mmyy, v_mabn, long.Parse(v_mavaovien), ngay, 1, 0);
        //            string s_ngaycapstt38_1 = "01/" + ngay.Substring(3, 2) + "/" + ngay.Substring(6, 4);
        //            int asotient = data.get_laninkb(v_mmyy, v_mabn, long.Parse(v_mavaovien), s_ngaycapstt38_1, 1);
        //            this.ads.WriteXml(@"..\..\Datareport\" + aReport.Replace(".rpt", ".xml"), XmlWriteMode.WriteSchema);
        //            string syte = "";
        //            string tenbv = "";
        //            string str14 = "";
        //            string str15 = "";
        //            string str16 = "";
        //            syte = this.m_v.Syte;
        //            tenbv = this.m_v.Tenbv;
        //            str14 = this.f_GetNgay(this.ads.Tables[0].Rows[0]["ngay"].ToString());
        //            str15 = m_v.f_get_tenuserlogin(int.Parse(this.ads.Tables[0].Rows[0]["userid"].ToString()));
        //            str16 = "";
        //            this.cMain = new ReportDocument();
        //            this.cMain.Load(@"..\..\..\report\" + this.aReport, OpenReportMethod.OpenReportByTempCopy);
        //            this.cMain.SetDataSource(this.ads);
        //            this.cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + syte.ToUpper() + "'";
        //            this.cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + tenbv.ToUpper() + "'";
        //            this.cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + str14 + "'";
        //            this.cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + str15 + "'";
        //            this.cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + str16 + "'";
        //            this.cMain.DataDefinition.FormulaFields["v_congkhamBHYT"].Text = "'" + v_congkhamBHYT + "'";
        //            this.Text = this.aReport;
        //            if (!v_dir)
        //            {
        //                this.crystalReportViewer1.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        //                base.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        //                this.crystalReportViewer1.ReportSource = this.cMain;
        //                base.WindowState = FormWindowState.Maximized;
        //                base.ShowDialog(base.Parent);
        //            }
        //            else
        //            {
        //                this.cMain.PrintToPrinter(1, false, 0, 0);
        //            }
        //            this.cMain.Close();
        //            this.cMain.Dispose();

        //            //binh 260711
        //            if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
        //            {
        //                //if (num > 0 && b_dahoantat_mau38 == false)
        //                //{
        //                //    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã hoàn tất chi phí chưa?"), "Medisoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        //                //    if (dlg == DialogResult.Yes) b_dahoantat_mau38 = true;
        //                //}
        //                if ((b_dahoantat_mau38 || bHoantat_38) && i_sophieu38 > 0)
        //                {
        //                    f_upd_dain_mau38(v_mmyy, v_mabn, v_mavaovien, i_sophieu38.ToString(), s_ngayhoantat, s_idttrv);
        //                }
        //            }
        //            //cap nhat lai chan doan
        //            if (str2.Trim().Trim(',') != "")
        //            {
        //                string asql = "update medibvmmyy.v_ttrvds set maicd='" + str3.Trim().Trim(',') + "', chandoan='" + str2.Trim().Trim(',') + "' where mabn='" + v_mabn + "' and mavaovien=" + v_mavaovien;
        //                m_v.execute_data_mmyy(v_mmyy, asql);
        //            }
        //            //cap nhat lai chan doan chinh
        //            if (s_chandoan_chinh.Trim().Trim(',') != "" && s_maicd_chinh.Trim().Trim() != "")
        //            {
        //                string asql = "update medibvmmyy.v_ttrvds set maicd='" + s_maicd_chinh.Trim().Trim(',') + "', chandoan='" + s_chandoan_chinh.Trim().Trim(',') + "' where mabn='" + v_mabn + "' and mavaovien=" + v_mavaovien;
        //                m_v.execute_data_mmyy(v_mmyy, asql);
        //            }
        //            //
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(this, aReport + "\n" + exception.ToString(), this.m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}

        #endregion// end khuyen 25/02/14

        private void f_upd_dain_mau38(string m_mmyy, string m_mabn, string m_mavaovien, string m_sottmau38)
        {
            string mxxx = m_v.user + m_mmyy;
            string sql = "update " + mxxx + ".v_ttrvds set dain38=" + m_sottmau38 + " where mabn='" + m_mabn + "' and mavaovien=" + m_mavaovien;
            m_v.execute_data(sql);
        }

        /*public void f_Print_PhieuChi_Hoantra_Chitiet(bool v_dir, string v_id, string v_mmyy_only)
        {
            try
            {
                string aReport = "v_phieuchi_hoantra_chitiet.rpt";
                string sql = "";
                DataSet adst = null;

                sql = "select a.id, a.mabn, a.sobienlai, a.ghichu, nvl(a.sotien,0) tongtien,nvl(aa.sotien,0) sotien, to_char(a.ngay,'dd/mm/yyyy') ngay,";
                sql += " d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh,d.cholam,d.msthue,";
                sql += " e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu,";
                sql += " i.sohieu quyenso,k.ten as tenvp,l.id as id_loai,l.ten as tenloai,m.ma as id_nhom,m.ten as tennhom  ";
                sql += " from medibvmmyy.v_hoantra a,medibvmmyy.v_hoantract aa , medibv.btdbn d, medibv.dmphai e, medibv.btdtt f,";
                sql += "  medibv.btdquan g, medibv.btdpxa h, medibv.v_quyenso i, medibv.v_dlogin j,";
                sql += " (select id,ten,id_loai,dvt from medibv.v_giavp union all select id,ten || ' '|| hamluong as ten,to_number('0') ";
                sql += "  as id_loai,dang as dvt from medibv.d_dmbd) k,(select id,id_nhom,ten from medibv.v_loaivp union  ";
                sql += " select to_number('0') as id,to_number('0') as id_nhom,'Thuốc' as ten from dual )l,(select ma,ten from medibv.v_nhomvp  ";
                sql += " union select to_number('0') as ma,'Thuốc' as ten from dual ) m  where a.mabn=d.mabn and ";
                sql += "  d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.id=aa.id and  ";
                sql += " aa.loaivp=k.id and  k.id_loai=l.id and l.id_nhom=m.ma  and a.quyenso = i.id and a.userid=j.id(+) and to_char(a.id)='" + v_id + "'";

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

                if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy report ") + aReport + ".");
                    return;
                }

                string asyt = "", abv = "", angayin = "", anguoiin = "";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;

                angayin = f_GetNgay(adst.Tables[0].Rows[0]["ngay"].ToString());
                anguoiin = adst.Tables[0].Rows[0]["nguoithu"].ToString();

                adst.WriteXml("..\\..\\datareport\\v_Inbienlaihoan_chitiet.xml", XmlWriteMode.WriteSchema);
                cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(adst);
                cMain.DataDefinition.FormulaFields["syt"].Text = "'" + asyt + "'";
                cMain.DataDefinition.FormulaFields["bv"].Text = "'" + abv + "'";
                cMain.DataDefinition.FormulaFields["ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["nguoiin"].Text = "'" + anguoiin + "'";

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
                MessageBox.Show(this, ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/
        public void f_Print_PhieuChi_Hoantra_Chitiet(bool v_dir, string v_id, string v_mmyy)
        {
            
            try
            {
                bool thutheodot = false;
                thutheodot = m_v.bhyt_thutheodot_mavaovien(m_userid);
                string aReport = "v_phieuchi_hoantra_chitiet.rpt";
                string exp = "where ht.id=" + v_id + " and b.tra>0 ";
               

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
                sql += " inner join "+m_v.user + v_mmyy+".v_hoantract htct on b.idtra=htct.id ";
                sql += " inner join "+m_v.user + v_mmyy+".v_hoantra ht on htct.id=ht.id ";
                sql += exp;

                if (v_mmyy == "")
                {
                    v_mmyy = m_v.s_curmmyy;
                }
                DataSet ads = m_v.get_data_mmyy(v_mmyy, sql);

                ads.WriteXml("..\\..\\Datareport\\v_phieuchi_hoantra_chitiet.xml", XmlWriteMode.WriteSchema);
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

    }
}