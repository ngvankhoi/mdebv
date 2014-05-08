using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDanhsachchothuchiravien : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid = "", m_mabn = "", m_maql = "", m_ngaycd = "", v_doituongthu = "";
        private string v_khoaphongthu = "";//binh
        private bool v_theochidinh, v_thevpkhoa, v_thuthuocthuongquy, v_khoatonghop, v_taothuocban, bTunguyen, bBatbuoc, tmn_Toachove;
        private DataSet dscho=new DataSet();

        public frmDanhsachchothuchiravien(LibVP.AccessData v_v, string v_userid, string s_doituongthu)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");

                m_v = v_v;
                m_userid = v_userid;
                m_v.f_SetEvent(this);
                v_doituongthu = s_doituongthu;
                f_Load_Data();
            }
            catch
            {
            }
        }

        public frmDanhsachchothuchiravien(LibVP.AccessData v_v, string v_userid, string s_doituongthu, string s_khoaphongthu)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");

                m_v = v_v;
                m_userid = v_userid;
                m_v.f_SetEvent(this);
                v_doituongthu = s_doituongthu;
                v_khoaphongthu = s_khoaphongthu;
                f_Load_Data();
            }
            catch
            {
            }
        }

        public string s_mabn
        {
            get
            {
                return m_mabn;
            }
        }
        public string s_maql
        {
            get
            {
                return m_maql;
            }
        }
        public string s_ngaycd
        {
            get
            {
                return m_ngaycd;
            }
        }
        public DateTime s_ngay
        {
            set
            {
                txtTN.Value = value;
                txtDN.Value = value;
            }
        }
        private void f_Load_Data()
        {
            try
            {
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmdanhsachchothuchiravien(m_userid);
                bTunguyen=m_v.ttrv_tunguyen(m_userid);
                bBatbuoc = m_v.ttrv_batbuoc(m_userid);
                v_theochidinh = m_v.ttrv_thuchidinh(m_userid);
                v_thevpkhoa = m_v.ttrv_thuvienphikhoa(m_userid);
                v_thuthuocthuongquy = m_v.ttrv_thuthuocthuongquy(m_userid);
                
                v_khoatonghop = m_v.ttrv_thukhoatonghop(m_userid);
                v_taothuocban = m_v.ttrv_thutoatutruc(m_userid);

                tmn_Toachove = m_v.ttrv_ToaBHYT(m_userid);// truongthuy 240414
                f_set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmdanhsachchothuchiravien(m_userid).ToString());

            }
            catch
            {
            }
        }
        private string f_Load_Bhyt_Kytu()
        {
            return m_v.get_ma13 + m_v.get_ma16 + m_v.get_ma16_95;
            //try
            //{
            //    return (m_v.get_data("select ten from medibv.thongso where id=50").Tables[0].Rows[0][0].ToString());
            //}
            //catch { return "-1"; };
        }
        private void f_Load_DG()
        {
            butTim.Enabled = false;
            try
            {
                tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                string[] s = f_Load_Bhyt_Kytu().Split('+');
                string sql = "", aexp = "",sql1="";
                DataSet ads = null, ads1 = null;
                int alimit = 0;
                try
                {
                    alimit = int.Parse(txtLimit.Value.ToString());
                }
                catch
                {
                    alimit = 0;
                }

                aexp = "";
                if (v_theochidinh)
                {
                    if (v_doituongthu != "")  aexp += " and g.madoituong in(" + v_doituongthu.Trim(',') + ")";
                    if (v_khoaphongthu != "") aexp += " and g.makp in(" + v_khoaphongthu.Trim(',') + ")";
                    //end binh
                    sql = " select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql";
                    sql += " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_chidinh g on a.mabn=g.mabn ";
                    sql += " where to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and g.paid=0 ";
                    sql += aexp + " and g.soluong<>0";//binh
                    sql += " group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql ";
                    sql += " order by a.hoten, a.mabn";
                    //ads1 = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql, alimit);
                    ads1 = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                if (v_thevpkhoa)
                {
                    aexp = ""; //binh
                    if (v_doituongthu != "")
                    {
                        aexp += " and g.madoituong in(" + v_doituongthu.Trim(',') + ")";
                    }
                    //binh
                    if (v_khoaphongthu != "")
                    {
                        aexp += " and g.makp in(" + v_khoaphongthu.Trim(',') + ")";
                    }
                    //end binh
                    sql = " select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql";
                    sql += " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_vpkhoa g on a.mabn=g.mabn ";
                    sql += " where to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and g.done=0 ";
                    sql += aexp + " and g.soluong<>0"; //binh
                    sql += " group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql ";
                    sql += " order by a.hoten, a.mabn";
                    //ads1 = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql, alimit);
                    ads1 = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                if (v_taothuocban)
                {
                    aexp = "";//binh
                    if (v_doituongthu != "")
                    {
                        aexp += " and h.madoituong in(" + v_doituongthu.Trim(',') + ")";
                    }
                    sql = " select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when h.soluong is null then 0 else h.soluong*h.giaban end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql";
                    sql += " from medibv.btdbn a inner join medibv.dmphai b on a.phai=b.ma inner join medibv.btdtt c on a.matt=c.matt inner join medibv.btdquan d on a.maqu=d.maqu inner join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.d_ngtrull g on a.mabn=g.mabn inner join medibvmmyy.d_ngtruct h on g.id=h.id";
                    sql += " where to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and h.paid=0 ";
                    sql += aexp + " and h.soluong<>0";//binh
                    sql += "  group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql order by a.hoten, a.mabn";
                    //ads1 = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql, alimit);
                    ads1 = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                if (v_thuthuocthuongquy)
                {
                    aexp = "";//binh
                    if (v_doituongthu != "")   aexp += " and g.madoituong in(" + v_doituongthu.Trim(',') + ")";
                    if (v_khoaphongthu != "")   aexp += " and h.makp in(" + v_khoaphongthu.Trim(',') + ")";
                    //end binh
                    sql = " select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.giaban end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql";
                    sql += " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.d_tienthuoc g on a.mabn=g.mabn ";
                    sql += " inner join medibv.d_duockp h on g.makp= h.id ";//binh
                    sql += " where to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and g.done=0 ";
                    sql += aexp + " and g.soluong<>0";//binh
                    sql += " group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql ";
                    sql += " order by a.hoten, a.mabn";
                    //ads1 = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql, alimit);
                    ads1 = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }

                //Phu thu dich vu cap phat le BHYT noi tru
                if (m_v.ttrv_phuthuCapphatleBHYT_Noitru(m_userid))
                {
                    aexp = "";
                    if (v_khoaphongthu != "")   aexp += " and h.makp in(" + v_khoaphongthu.Trim(',') + ")";
                    sql = " select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd, sum(g.soluong*(case when g.giaban-to_number(( case when gg.gia_bh=0 then g.giamua else gg.gia_bh end))<0 then 0 else g.giaban-to_number(( case when gg.gia_bh=0 then g.giamua else gg.gia_bh end)) end)) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql";
                    sql += ", '' as chandoan, '' as maicd, to_char(g.makp) as makp, h.ten as tenkp";
                    sql += " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.d_tienthuoc g on a.mabn=g.mabn inner join medibv.d_dmbd gg on g.mabd=gg.id ";
                    sql += " inner join medibv.d_duockp h on g.makp= h.id ";                    
                    sql += " where to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and g.madoituong=1 and nvl(g.datra,0)=0 and g.done=0 and g.idttrv=0 and g.idkhoa<>0 ";
                    sql += aexp + " and g.soluong<>0";
                    sql += " group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql ";
                    sql += ", g.makp, h.ten ";
                    sql += " order by a.hoten, a.mabn";
                    ads1 = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }

                if (v_khoatonghop)
                {
                    sql1 = "";                    
                    aexp = " where to_date(to_char(g.ngayra,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";//binh copy o tren dau function xuong

                    if (bTunguyen)
                    {
                        for (int i = 0; i < s.Length; i++) if (s[i].ToString().Trim() != "") sql1 += " bh.sothe like '%" + s[i].ToString() + "%' or ";
                    }
                    else if (bBatbuoc)
                    {
                        for (int i = 0; i < s.Length; i++) if (s[i].ToString().Trim() != "") sql1 = "bh.sothe not like '%" + s[i].ToString() + "%' or ";
                    }
                    if (sql1 != "") aexp += " and (bh.sothe is null or " + sql1.Substring(0, sql1.Length - 3) + ")";

                    if (v_doituongthu != "")   aexp += " and h.madoituong in(" + v_doituongthu.Trim(',') + ")";
                    sql = " select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngayra,'dd/mm/yyyy') as ngaycd,sum(case when h.soluong is null then 0 else h.soluong*h.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql";
                    sql += ", g.chandoan, g.maicd, g.makp, kp.tenkp, h.madoituong, dt.doituong";
                    sql += " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma ";
                    sql+=" left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu ";
                    sql+=" left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn ";
                    sql+=" inner join medibvmmyy.v_thvpll g on a.mabn=g.mabn inner join medibvmmyy.v_thvpct h on g.id=h.id ";
                    sql += " left join medibvmmyy.v_thvpbhyt bh on g.id=bh.id ";
                    sql += " left join medibv.btdkp_bv kp on g.makp=kp.makp left join medibv.doituong dt on h.madoituong = dt.madoituong";
                    sql += "" + aexp + "  and h.done=0 and h.soluong<>0";
                    sql += " group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngayra,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql ";
                    sql += ", g.chandoan, g.maicd, g.makp, kp.tenkp,h.madoituong, dt.doituong ";
                    sql += " order by a.hoten, a.mabn";
                    //ads1 = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql, alimit);
                    ads1 = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }

                //// thuytruong 25042014 them doi voi toa bhyt dc duyet 
                if (tmn_Toachove)
                {
                    sql = " select mabn, hoten,ngaysinh,phai,ngaycd, sum(sotien) as sotien ,sonha,thon,xa,quan,tinh,cholam,dt_nha,dt_didong,email,maql from (";
                    sql += "select a.mabn,e.hoten, case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,g.ten as phai ,to_char(a.ngay,'dd/mm/yyyy') as ngaycd ,sum(case when a.soluong is null then 0 else a.soluong*a.giamua end) as sotien, e.sonha,e.thon,  ";
                    sql += "  k.tenpxa as xa, i.tenquan as quan , h.tentt as tinh, e.cholam,l.nha as dt_nha, l.coquan as dt_coquan,l.didong as dt_didong,l.email,a.maql ";
                  sql += ", a.chandoan, a.maicd, d.makp, d.tenkp, a.maphu as madoituong, a.doituong as doituong";
                    sql += " from ";
                    sql += " (select x.maicd, x.chandoan, x.mabn, x.quyenso, x.sobienlai, x.maphu, x.maql, x.ngay, x.makp, dt.doituong," +
                        " y.mabd, y.soluong, case when dt.loai=1 and x.maphu<>1 then y.giaban else yy.giamua" +
                        " end giaban, case when dt.loai=1 and x.maphu<>1 then y.giaban else yy.giamua end " +
                        "giamua,x.mabs,to_number('0') as id_ktcao,to_number('0') as ktcao ";
                    sql += ", x.id, y.stt, to_number('1') as toave, x.id as idtonghop, y.stt as stttonghop";//binh 190913
                    sql += " from medibvmmyy.bhytkb as x,medibvmmyy.bhytthuoc as y, medibvmmyy.d_theodoi as yy," +
                        " medibv.d_doituong dt where x.id=y.id and y.sttt=yy.id and x.maphu=dt.madoituong " +
                        " and x.quyenso=0 and x.sobienlai=0 ";
                    sql += " and  to_date(to_char(x.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') ";
                     sql += "   ) as a ";
                    sql += " inner join medibv.d_dmbd b on a.mabd=b.id left join ";
                    sql += " medibv.btdkp_bv d on a.makp=d.makp ";
                    sql += " left join medibv.btdbn e on e.mabn=a.mabn ";
                    sql += " left join  medibv.dmphai g on e.phai=g.ma ";
                    sql += " left join medibv.btdtt h on h.matt=e.matt left join medibv.btdquan i on i.maqu=e.maqu ";
                    sql += " left join medibv.btdpxa k on k.maphuongxa=e.maphuongxa left join medibv.dienthoai l on l.mabn=e.mabn ";
                    sql += " group by ";
                    sql += " a.mabn,e.hoten,e.ngaysinh ,g.ten ,a.ngay,a.soluong,a.giamua , e.sonha,e.thon,  "; //a.giaban as dongia,a.giaban as giamua,a.soluong*a.giaban as sotien, ";
                    sql += "  k.tenpxa, i.tenquan, h.tentt,e.cholam,l.nha, l.coquan,l.didong,l.email,a.maql ";
                    sql += ", a.chandoan, a.maicd, d.makp, d.tenkp, a.maphu , a.doituong,e.namsinh ,e.ngaysinh ";
                    sql += " union all ";
                   sql += "select a.mabn,e.hoten, case when e.ngaysinh is null then e.namsinh else to_char(e.ngaysinh,'dd/mm/yyyy') end as ngaysinh,g.ten as phai ,to_char(a.ngay,'dd/mm/yyyy') as ngaycd ,sum(case when a.soluong is null then 0 else a.soluong*a.dongia end) as sotien, e.sonha,e.thon,  ";
                   sql += "  k.tenpxa as xa, i.tenquan as quan, h.tentt as tinh ,e.cholam,l.nha as dt_nha, l.coquan as dt_coquan,l.didong as dt_didong,l.email,a.maql ";
                    sql += ", a.chandoan, a.maicd, d.makp, d.tenkp, a.maphu as madoituong,a.doituong as doituong";
                    sql += " from ";
                    sql += " (select x.maicd, x.chandoan,x.mabn, x.quyenso, x.sobienlai, x.maphu, x.maql, x.ngay, x.makp, dt.doituong," +
                        " y.mavp as mabd, y.soluong, case when dt.loai=1 and x.maphu<>1 then y.dongia else y.dongia" +
                        " end giaban, case when dt.loai=1 and x.maphu<>1 then  y.dongia else y.dongia end " +
                        "dongia,x.mabs,to_number('0') as id_ktcao,to_number('0') as ktcao ";
                    sql += ", x.id, y.stt, to_number('1') as toave, x.id as idtonghop, y.stt as stttonghop";//binh 190913
                    sql += " from medibvmmyy.bhytkb as x,medibvmmyy.bhytcls as y," +
                        " medibv.d_doituong dt where x.id=y.id  and x.maphu=dt.madoituong " +
                        " and x.quyenso=0 and x.sobienlai=0 ";
                    sql += " and  to_date(to_char(x.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') ";
                    sql+=" ) as a ";
                    sql += " inner join medibv.v_giavp b on a.mabd=b.id left join ";
                    sql += " medibv.btdkp_bv d on a.makp=d.makp ";
                    sql += " left join medibv.btdbn e on e.mabn=a.mabn ";
                    sql += " left join  medibv.dmphai g on e.phai=g.ma ";
                    sql += " left join medibv.btdtt h on h.matt=e.matt left join medibv.btdquan i on i.maqu=e.maqu ";
                    sql += " left join medibv.btdpxa k on k.maphuongxa=e.maphuongxa left join medibv.dienthoai l on l.mabn=e.mabn ";
                    sql += " group by ";
                    sql += " a.mabn,e.hoten,e.ngaysinh ,g.ten ,a.ngay,a.soluong,a.dongia , e.sonha,e.thon,  "; //a.giaban as dongia,a.giaban as giamua,a.soluong*a.giaban as sotien, ";
                    sql += "  k.tenpxa, i.tenquan, h.tentt,e.cholam,l.nha, l.coquan,l.didong,l.email,a.maql ";
                    sql += ", a.chandoan, a.maicd, d.makp, d.tenkp,a.maphu,a.doituong,e.namsinh";
                    sql+=" ) group by  mabn, hoten,ngaysinh,phai,ngaycd,sonha,thon,xa,quan,tinh,cholam,dt_nha,dt_didong,email,maql ";//,chandoan,maicd,makp ,madoituong, doituong "; 
                    ads1 = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                    if (ads1.Tables[0].Rows.Count > 0)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                ///
                if (ads == null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đề nghị kiểm tra lại quyền thu trong phần tùy chọn người dùng của người thu này."));
                    return;
                }
                dscho = new DataSet();
                dscho = ads.Copy();
                dgHoadon.DataSource = ads.Tables[0];
                dgHoadon.Update();
                tmn_Sotien.Text = lan.Change_language_MessageText("TỔNG SỐ:") + " " + dgHoadon.RowCount.ToString();
            }
            catch(Exception ex)
            {
                string sss = ex.ToString();
                MessageBox.Show(sss);
                try
                {
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    dv.Table.Rows.Clear();
                }
                catch
                {
                }
                tmn_Sotien.Text = "";
            }
            butTim.Enabled = true;
        }

        private void tmn_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tmn_Chon_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                m_mabn = arv["mabn"].ToString();
                m_maql = arv["maql"].ToString();
                m_ngaycd = arv["ngaycd"].ToString();
            }
            catch
            {
                m_mabn = "";
                m_maql = "";
                m_ngaycd = "";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tmn_Inhoadon_Click(object sender, EventArgs e)
        {

        }

        private void tmn_Inchiphi_Click(object sender, EventArgs e)
        {

        }

        private void frmDanhsachchothuchiravien_Load(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void txtTN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtDN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butTim_Click(null, null);
                }
            }
            catch
            {
            }
        }

        private void frmDanhsachchothuchiravien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    m_mabn = "";
                    m_maql = "";
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void txtTN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTN.Value > txtDN.Value)
                {
                    txtDN.Value = txtTN.Value;
                }
            }
            catch
            {
            }
        }

        private void txtDN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDN.Value < txtTN.Value)
                {
                    txtTN.Value = txtDN.Value;
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                string atmp = tmn_Timnhanh.Text.Trim();
                if (atmp.Trim() != lan.Change_language_MessageText("Tìm kiếm") && atmp.Trim() != "")
                {
                    aft = "mabn like '%" + atmp + "%' or hoten like '%" + atmp + "%' or ngaysinh like '%" + atmp + "%' or phai like '%" + atmp + "%' or sonha like '%" + atmp + "%' or thon like '%" + atmp + "%' or cholam like '%" + atmp + "%' or xa like '%" + atmp + "%' or quan like '%" + atmp + "%' or tinh like '%" + atmp + "%' or dt_nha like '%" + atmp + "%' or dt_coquan like '%" + atmp + "%' or dt_didong like '%" + atmp + "%' or email like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void tmn_Timnhanh_Enter(object sender, EventArgs e)
        {
             tmn_Timnhanh.Text = "";
        }

        private void tmn_Timnhanh_Leave(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.White;
                if (tmn_Timnhanh.Text.Trim() == "")
                {
                    tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int aid = 0;
                if (e.KeyCode == Keys.Up)
                {
                    if (dgHoadon.CurrentCell.RowIndex > 0)
                    {
                        aid = dgHoadon.CurrentCell.RowIndex - 1;
                        dgHoadon.Rows[aid].Selected = true;
                        dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                        SendKeys.Send("{End}");
                    }
                    else
                        if (dgHoadon.RowCount > 0)
                        {
                            aid = dgHoadon.RowCount - 1;
                            dgHoadon.Rows[aid].Selected = true;
                            dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                }
                else
                    if (e.KeyCode == Keys.Down)
                    {
                        if (dgHoadon.CurrentCell.RowIndex < dgHoadon.Rows.Count - 1)
                        {
                            aid = dgHoadon.CurrentCell.RowIndex + 1;
                            dgHoadon.Rows[aid].Selected = true;
                            dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                        else
                            if (dgHoadon.RowCount > 0)
                            {
                                aid = 0;
                                dgHoadon.Rows[aid].Selected = true;
                                dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                                SendKeys.Send("{End}");
                            }
                    }
            }
            catch
            {
            }
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void txtLimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butTim.Focus();
                }
                m_v.set_o_limit_frmdanhsachchothuchiravien(m_userid, txtLimit.Value.ToString());
            }
            catch
            {
            }
        }
        private void f_set_Fullgrid()
        {
            try
            {
                dgHoadon.Columns["Column_5"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_4"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_3"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_2"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_1"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_0"].Frozen = !tmn_Fullgrid.Checked;

            }
            catch
            {
            }
        }
        private void tmn_Fullgrid_Click(object sender, EventArgs e)
        {
            try
            {
                f_set_Fullgrid();
                m_v.set_o_fullgrid_frmdanhsachchothuchiravien(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void dgHoadon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tmn_Chon_Click(null, null);
        }

        private void tmn_Excel_Click(object sender, EventArgs e)
        {
            f_Export();
        }

        private void tmn_In_Click(object sender, EventArgs e)
        {
            string reportname = "", asyt = "", abv = "", inbc = "";
            if (!System.IO.Directory.Exists("..//..//Datareport//"))
            {
                System.IO.Directory.CreateDirectory("..//..//Datareport//");
            }
            dscho.WriteXml("..//..//Datareport//v_2007_dscho_ttrv.xml", XmlWriteMode.WriteSchema);
            asyt = m_v.Syte;
            abv = m_v.Tenbv;
            inbc = lan.Change_language_MessageText("Từ ngày ") + " " + txtTN.Text.Substring(0,10) + " " + lan.Change_language_MessageText("đến ngày ") + " " + txtDN.Text.Substring(0,10);
            if (txtTN.Text ==txtDN.Text)
                inbc = lan.Change_language_MessageText("Ngày ") + " " + txtTN.Text.Substring(0, 10);
            reportname = "v_2007_dscho_ttrv.rpt";
            frmReport f = new frmReport(m_v, dscho.Tables[0], reportname, asyt.ToUpper(), abv.ToUpper(), inbc, "", "", "", "", "", "", "", 1, true);
            f.ShowDialog();
        }

        private void f_Export()
        {            
            string acurdir = System.Environment.CurrentDirectory;
            try
            {                                
                if (dscho != null)
                {
                    frmPreviewdata af = new frmPreviewdata("", dscho, "");
                    af.ShowInTaskbar = false;
                    af.WindowState = FormWindowState.Maximized;
                    af.ShowDialog();
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acurdir;                
            }
        }
    }
}