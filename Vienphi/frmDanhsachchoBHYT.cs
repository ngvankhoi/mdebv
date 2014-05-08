using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDanhsachchoBHYT : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_mabn="",m_maql="",m_ngaycd="",m_quyenso="";
        private bool bTunguyen, bBatbuoc;
        bool bthuphi = false, btatca = false;
        bool bDichvu_Chuyenchungtu = false;
        bool bQuanly_Chuyenchungtu = false;
        public frmDanhsachchoBHYT(LibVP.AccessData v_v, string v_userid)
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
                f_Load_Data();
            }
            catch
            {
            }
        }
        public frmDanhsachchoBHYT(LibVP.AccessData v_v, string v_userid,bool v_thuphi,bool v_tatca)
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
                bthuphi = v_thuphi;// chỉ thu chi phí bệnh nhân <> bhyt, giống form thu trực tiếp
                btatca = v_tatca;// thu tất cả chi phí thu phí + bhyt
                m_v.f_SetEvent(this);
                f_Load_Data();
            }
            catch
            {
            }
        }

        public frmDanhsachchoBHYT(LibVP.AccessData v_v, string v_userid, bool v_thuphi, bool v_tatca, bool _Dichvu_Chuyenchungtu)
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
                bthuphi = v_thuphi;// chỉ thu chi phí bệnh nhân <> bhyt, giống form thu trực tiếp
                btatca = v_tatca;// thu tất cả chi phí thu phí + bhyt
                m_v.f_SetEvent(this);
                f_Load_Data();
                bDichvu_Chuyenchungtu = _Dichvu_Chuyenchungtu;
                bQuanly_Chuyenchungtu = true;
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
                bTunguyen = m_v.bhyt_tunguyen(m_userid);
                bBatbuoc = m_v.bhyt_batbuoc(m_userid);
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmdanhsachchoBHYT(m_userid);
                f_set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmdanhsachchoBHYT(m_userid).ToString());
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
            bool bDoituong = chkbhyt.Checked;
            try
            {
                tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                string[] s = f_Load_Bhyt_Kytu().Split('+');
                string sql = "", aexp = "", asql1 = "",aexp1="";
                string s_loai = "";
                int alimit = 0;
                try
                {
                    alimit = int.Parse(txtLimit.Value.ToString());
                }
                catch
                {
                    alimit = 0;
                }

                //gam
                string s_doituong = "";
                try
                {
                    s_doituong = m_v.get_v_optionform(1, m_userid, "BHYT_024");
                    s_doituong = (s_doituong.Trim().Length > 1) ? s_doituong.Substring(0, s_doituong.Length - 1) : "";
                }
                catch {  }
                
                //aexp = "where to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";

                //aexp += " and g.quyenso=0 ";

                aexp = "where to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                aexp1 = aexp;
                aexp1 += " and g.idttrv=0 ";// and g.done=0
                s_loai = "medibvmmyy.v_chidinh";

                if (m_v.tt_thutoatutruc(m_userid))
                {
                    s_loai = "(";
                    s_loai += "select a.mabn, a.maql, a.soluong, a.dongia, a.paid, a.ngay, a.madoituong,a.idttrv,to_number(a.makp) as makp,a.done, a.mavp from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id where a.paid=0 and a.idttrv=0 and b.guinguoi=0 ";//gam 26-04-2011                    
                    
                    s_loai += " union all ";
                    s_loai += " select mabn, maql, soluong, giaban as dongia, done as paid, ngay, madoituong,done as idttrv,makp,done, mabd as mavp from medibvmmyy.d_tienthuoc where done=0 and makp in(select a.id from medibv.d_duockp a left join medibv.btdkp_bv b on a.makp=b.makp where (b.loai=1 or b.loai=4 or b.loai is null))";//gam ngay 24-06-2011 them select makp
                    //s_loai += " union all ";
                    //s_loai += " (select mabn, maql, soluong, giaban as dongia, done as paid, ngay, madoituong from medibvmmyy.d_thuocbhytll a, medibvmmyy.d_thuocbhytct b where a.id=b.id and b.madoituong=1)";
                    s_loai += ")";

                }
                //gam-01/03/2011-load them toa thuoc mua ngoai
                if (m_v.tt_thutoamuangoai(m_userid))
                {
                    if (m_v.tt_thutoatutruc(m_userid))
                    {
                        s_loai = s_loai.Substring(0, s_loai.Length - 1);
                        s_loai += " union all ";
                        s_loai += "select distinct a.mabn,a.maql,b.soluong soluong, b.giaban as dongia,b.idttrv as paid,a.ngay,b.madoituong,b.idttrv,0 as makp,b.idttrv as done, b.mabd as mavp from medibvmmyy.d_ngtrull a inner join medibvmmyy.d_ngtruct b on a.id=b.id where b.idttrv=0 ";//,done as idttrv,to_char(makp)
                        s_loai += ")";
                    }
                    else
                    {
                        s_loai = "(";// gam 20-06-2011
                        s_loai += "select a.mabn, a.maql, a.soluong, a.dongia, a.paid, a.ngay, a.madoituong,a.idttrv,to_number(a.makp) as makp,a.done, a.mavp from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id where a.paid=0 and a.idttrv=0 and b.guinguoi=0 ";
                        s_loai += " union all ";
                        s_loai += "select distinct a.mabn,a.maql,b.soluong soluong, b.giaban as dongia,b.idttrv as paid,a.ngay,b.madoituong,b.idttrv,0 as makp,b.idttrv as done, b.mabd as mavp from medibvmmyy.d_ngtrull a inner join medibvmmyy.d_ngtruct b on a.id=b.id where b.idttrv=0 ";//,done as idttrv,to_char(makp)
                        s_loai += ")";
                    }

                }
                if (bTunguyen)
                {
                    for (int i = 0; i < s.Length; i++) if (s[i].ToString().Trim() != "") asql1 += "h.sothe like '%" + s[i].ToString() + "%' or ";
                }
                else if (bBatbuoc)
                {
                    for (int i = 0; i < s.Length; i++) if (s[i].ToString().Trim() != "") asql1 += "h.sothe not like '%" + s[i].ToString() + "%' or ";
                }
                else if (ToolStripMenuItem_Cho.Checked)
                {
                    for (int i = 0; i < s.Length; i++) if (s[i].ToString().Trim() != "") asql1 += "h.sothe like '%" + s[i].ToString() + "%' or ";
                }
                if (asql1 != "") aexp += " and (h.sothe is null or " + asql1.Substring(0, asql1.Length - 3) + ")";
                if (!bthuphi && !btatca)
                {
                    
                    sql = "select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,";
                    sql += " b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,g.thuoc+g.cls as sotien,a.sonha,a.thon,e.tenpxa as xa, ";
                    sql += "d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,";
                    sql += "f.email,g.maql as maql,h.sothe,g.makp from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma ";
                    sql += "left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu ";
                    sql += "left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn ";
                    sql += "inner join medibvmmyy.bhytkb g on a.mabn=g.mabn left join medibvmmyy.bhyt h on g.maql=h.maql " + aexp + " and g.quyenso=0 and g.sobienlai=0";
                }
                else
                {
                    //gam
                    if (m_v.get_v_optionform(1, m_userid, "BHYT_011") == "1")// co thu tien thuoc tu truc
                    {
                        s_loai = "(select mabn, maql, soluong, dongia, paid, ngay, madoituong, mavp from medibvmmyy.v_chidinh ";
                        s_loai += " union all ";
                        s_loai += " select mabn, maql, soluong, giaban as dongia, done as paid, ngay, madoituong, mabd as mavp from medibvmmyy.d_tienthuoc where makp in(select a.id from medibv.d_duockp a left join medibv.btdkp_bv b on a.makp=b.makp where (b.loai=1 or b.loai=4 or b.loai is null))";//idkhoa=0 and 
                        //s_loai += " union all ";
                        //s_loai += " (select mabn, maql, soluong, giaban as dongia, done as paid, ngay, madoituong from medibvmmyy.d_thuocbhytll a, medibvmmyy.d_thuocbhytct b where a.id=b.id and b.madoituong=1)";
                        s_loai += " )";
                    }
                    if (s_doituong != "") aexp1 += " and h.madoituong in(" + s_doituong + ")";
                    aexp1 += " and g.paid=0 ";
                    //chi dinh dich vu: tiep don
                    sql = "select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') " +
                        "end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0" +
                        " else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh," +
                        "a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,'' as sothe,i.tenkp ";
                    //if (bDoituong) sql += ", g.madoituong, dt.doituong ";//binh 100711
                    //else sql += ", 0 as madoituong, '' as doituong ";
                    sql += " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt " +
                        "left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa " +
                        "left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_chidinh g on a.mabn=g.mabn " +
                        "inner join medibvmmyy.tiepdon h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp ";
                    sql += " inner join medibv.v_giavp gi on g.mavp=gi.id ";//binh 030811
                    //if (bDoituong) sql += " inner join medibv.doituong dt on g.madoituong=dt.madoituong ";
                    sql += aexp1;
                    if (bQuanly_Chuyenchungtu)
                    {
                        if (bDichvu_Chuyenchungtu) sql += " and h.madoituong=1 and gi.chuyenchungtu=1";//binh 030811
                        else sql += "  and ((h.madoituong=1 and gi.chuyenchungtu=0) or h.madoituong<>1 )";//binh 030811
                    }
                    sql += " and g.idttrv=0 group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else " +
                        " to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan," +
                        " c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";
                    //if (bDoituong) sql += " ,g.madoituong, dt.doituong ";
                    //
                    //chi dinh dich vu: noi tru, ngoai tru
                    sql += " union all ";
                    sql += "select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy')" +
                        " end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 " +
                        "else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh," +
                        "a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,'' as sothe,i.tenkp ";
                    
                    //if (bDoituong) sql += ", g.madoituong, dt.doituong ";
                    //else sql += ", 0 as madoituong, '' as doituong ";
                    sql += " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt " +
                        "left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa " +
                        "left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_chidinh g on a.mabn=g.mabn " +
                        "inner join medibv.benhandt h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp ";
                    sql += " inner join medibv.v_giavp gi on g.mavp=gi.id ";//binh 030811
                    //if (bDoituong) sql += " inner join medibv.doituong dt on g.madoituong=dt.madoituong "; 
                    sql+= aexp1 + " and g.idttrv=0  ";
                    if (bQuanly_Chuyenchungtu)
                    {
                        if (bDichvu_Chuyenchungtu) sql += " and h.madoituong=1 and gi.chuyenchungtu=1";//binh 030811
                        else sql += "  and ((h.madoituong=1 and gi.chuyenchungtu=0) or h.madoituong<>1 )";//binh 030811
                    }
                    sql+=" group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else " +
                        "to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan," +
                        " c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";
                    //if (bDoituong) sql += " ,g.madoituong, dt.doituong ";
                    //
                    //chi dinh dich vu: ngoai tru
                    sql += " union all ";                    
                    sql += "select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy')" +
                        " end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0" +
                        " else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh," +
                        "a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,'' as sothe,i.tenkp ";
                    //if (bDoituong) sql += ", g.madoituong, dt.doituong ";//binh 100711
                    //else sql += " ,0 as madoituong, '' as doituong ";
                    sql += "from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt " +
                    "left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa " +
                    "left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_chidinh g on a.mabn=g.mabn " +
                    "inner join medibv.benhanngtr h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp ";
                    sql += " inner join medibv.v_giavp gi on g.mavp=gi.id ";//binh 030811
                    //if (bDoituong) sql += " inner join medibv.doituong dt on g.madoituong=dt.madoituong ";
                    sql += aexp1 + " and g.idttrv=0  ";
                    if (bQuanly_Chuyenchungtu)
                    {
                        if (bDichvu_Chuyenchungtu) sql += " and h.madoituong=1 and gi.chuyenchungtu=1";//binh 030811
                        else sql += "  and ((h.madoituong=1 and gi.chuyenchungtu=0) or h.madoituong<>1 )";//binh 030811
                    }
                    sql+=" group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else " +
                    "to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, " +
                    "c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";
                    //if (bDoituong) sql += " ,g.madoituong, dt.doituong ";
                    //
                    //chi dinh dich vu: PK
                    sql += " union all ";                    
                    sql += "select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') " +
                        "end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0" +
                        " else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh," +
                        "a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,'' as sothe,i.tenkp ";
                    
                    //if (bDoituong) sql += ", g.madoituong, dt.doituong ";//binh 100711
                    //else sql += ", 0 as madoituong, '' as doituong ";
                    sql += "from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt " +
                    "left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa " +
                    "left join medibv.dienthoai f on a.mabn=f.mabn inner join " + s_loai + " g on a.mabn=g.mabn " +
                    "inner join medibvmmyy.benhanpk h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp ";
                    //sql += " inner join medibv.v_giavp gi on g.mavp=gi.id ";//binh 030811
                    //if (bDoituong) sql += " inner join medibv.doituong dt on g.madoituong=dt.madoituong ";
                    sql += aexp1;
                    //if (bQuanly_Chuyenchungtu)
                    //{
                    //    if (bDichvu_Chuyenchungtu) sql += " and h.madoituong=1 and gi.chuyenchungtu=1";//binh 030811
                    //    else sql += "  and ((h.madoituong=1 and gi.chuyenchungtu=0) or h.madoituong<>1 )";//binh 030811
                    //}
                    sql += " group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy')" +
                    " end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan," +
                    "f.didong,f.email,g.maql,i.tenkp";
                    //if (bDoituong) sql += " ,g.madoituong, dt.doituong ";
                    //
                    //chi dinh dich vu: phong luu
                    sql += " union all ";                    
                    sql += "select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy')" +
                        " end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 " +
                        "else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh," +
                        "a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,'' as sothe,i.tenkp ";
                    //if (bDoituong) sql += ", g.madoituong, dt.doituong ";//binh 100711
                    //else sql += ", 0 as madoituong, '' as doituong ";
                    sql += "from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt" +
                    " left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa " +
                    "left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_chidinh g on a.mabn=g.mabn " +
                    "inner join medibvmmyy.benhancc h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp ";
                    sql += " inner join medibv.v_giavp gi on g.mavp=gi.id ";
                    //if (bDoituong) sql += " inner join medibv.doituong dt on g.madoituong=dt.madoituong ";
                    sql += aexp1;
                    if (bQuanly_Chuyenchungtu)
                    {
                        if (bDichvu_Chuyenchungtu) sql += " and h.madoituong=1 and gi.chuyenchungtu=1";//binh 030811
                        else sql += "  and ((h.madoituong=1 and gi.chuyenchungtu=0) or h.madoituong<>1 )";//binh 030811
                    }
                    sql += " and g.idttrv=0  group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else " +
                    "to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa," +
                    " d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";
                    //if (bDoituong) sql += " ,g.madoituong, dt.doituong ";
                    //if (m_v.tt_thutoamuangoai(m_userid))
                    //        {
                    //            sql += " union all ";
                    //            sql += " select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') ";
                    //            sql += "end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 ";
                    //            sql += "else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,";
                    //            sql += "a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,'' as sothe,i.ten as tenkp ";
                    //            sql += "from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt ";
                    //            sql += "left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa ";
                    //            sql += "left join medibv.dienthoai f on a.mabn=f.mabn inner join " + s_loai + " g on a.mabn=g.mabn ";
                    //            sql += "left join medibv.d_duockp i on g.makp=i.id " + aexp + "  and g.paid=0 and g.idttrv=0  ";
                    //            sql+=" group by a.mabn,a.hoten, ";
                    //            sql += "case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,";
                    //            sql += "to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, ";
                    //            sql += "f.coquan,f.didong,f.email,g.maql,i.ten ";
                    //        }
                    if (btatca && bDichvu_Chuyenchungtu==false)
                    {
                        sql += " union all ";
                        sql += "select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,";
                        sql += " b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,g.thuoc as sotien,a.sonha,a.thon,e.tenpxa as xa, ";
                        sql += "d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,";
                        sql += "f.email,g.maql as maql,h.sothe,g.makp ";
                        //if (bDoituong) sql += ", g.maphu madoituong, dt.doituong ";//binh 100711
                        //else sql += ", 0 as madoituong, '' as doituong ";
                        sql += " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma ";
                        sql += "left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu ";
                        sql += "left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn ";
                        sql += "inner join medibvmmyy.bhytkb g on a.mabn=g.mabn left join medibvmmyy.bhyt h on g.maql=h.maql ";
                        //if (bDoituong) sql += " inner join medibv.doituong dt on g.maphu=dt.madoituong ";
                        sql += aexp + " and g.quyenso=0 and g.sobienlai=0 ";
                    }
                }                
                //end gam
                dgHoadon.DataSource = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0];
                dgHoadon.Update();
                tmn_Sotien.Text = lan.Change_language_MessageText("TỔNG SỐ:")+" " + dgHoadon.RowCount.ToString();
            }
            catch
            {
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

        private void frmDanhsachchoBHYT_Load(object sender, EventArgs e)
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
                    butTim_Click(null,null);
                }
            }
            catch
            {
            }
        }

        private void frmDanhsachchoBHYT_KeyDown(object sender, KeyEventArgs e)
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
                if (atmp.ToLower().Trim() != 
lan.Change_language_MessageText("Tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "mabn like '%" + atmp + "%' or hoten like '%" + atmp + "%' or ngaysinh like '%" + atmp + "%' or phai like '%" + atmp + "%' or sonha like '%" + atmp + "%' or thon like '%" + atmp + "%' or cholam like '%" + atmp + "%' or xa like '%" + atmp + "%' or quan like '%" + atmp + "%' or tinh like '%" + atmp + "%' or dt_nha like '%" + atmp + "%' or dt_coquan like '%" + atmp + "%' or dt_didong like '%" + atmp + "%' or email like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch//(Exception ex)
            {
                // MessageBox.Show(ex.ToString());
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
                    tmn_Timnhanh.Text = 
lan.Change_language_MessageText("Tìm kiếm");
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
                m_v.set_o_limit_frmdanhsachchoBHYT(m_userid, txtLimit.Value.ToString());
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
                m_v.set_o_fullgrid_frmdanhsachchoBHYT(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void dgHoadon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tmn_Chon_Click(null, null);
        }

        private void tmn_Xemtruockhiin_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Cho_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Cho.Checked = !ToolStripMenuItem_Cho.Checked;
        }
    }
}