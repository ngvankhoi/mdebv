using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDanhsachchothutructiep : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid = "", m_mabn = "", m_maql = "", m_ngaycd = "", s_madoituongthu = "",m_id="",m_loai="";
        bool btt_Thutungdonthuoc = false;
        public frmDanhsachchothutructiep(LibVP.AccessData v_v, string v_userid)
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
        public string s_id
        {
            get
            {
                return m_id;
            }
        }
        public string s_loai
        {
            get
            {
                return m_loai;
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
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmdanhsachchothutructiep(m_userid);
                f_set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmdanhsachchothutructiep(m_userid).ToString());
                try
                {
                    s_madoituongthu = m_v.get_data("select giatri from medibv.v_optionform where ma='TT_026' and userid=" + m_userid + "").Tables[0].Rows[0]["giatri"].ToString().Trim(',');
                }
                catch
                {
                    s_madoituongthu = "";
                }
            }
            catch
            {
            }
        }
        private void f_Load_DG()
        {
            butTim.Enabled = false;
            try
            {
                tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                string sql = "", exp = "", s_loai = "", exp1 = "", dk_tachtheotoa = "", dk_tachtheotoa1 = "", dk_tachtheotoa2 = "", dk_tachtheotoa3 = "";
                int alimit = 0;
                //Thuy 20.06.2012 nếu có chọn option -> cho phép thu theo từng đơn thuốc
                if (btt_Thutungdonthuoc)
                {
                    dk_tachtheotoa = "id,";
                    dk_tachtheotoa1 = "a.id,";
                    dk_tachtheotoa2 = "a.id,";
                    dk_tachtheotoa3 = "g.id,";
                }
                else
                {
                    dk_tachtheotoa = "";
                    dk_tachtheotoa1 = "";
                    dk_tachtheotoa2 = "distinct ";
                    dk_tachtheotoa3 = "";
                }
                try
                {
                    alimit = int.Parse(txtLimit.Value.ToString());
                }
                catch
                {
                    alimit = 0;
                }
                exp = "where to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(g.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";//g.paid = 0 and 
                if (s_madoituongthu != "") exp += " and g.madoituong in(" + s_madoituongthu + ")";
                exp += " and g.madoituong<>1";//khong thu doi tuong bhyt trong man hinh thu truc tiep
                exp1 = exp;

                exp += " and g.paid=0 and g.idttrv=0 ";
                exp1 += " and g.done=0 and g.idttrv=0 ";
                s_loai = "medibvmmyy.v_chidinh";
                
                if (m_v.tt_thutoatutruc(m_userid))
                {
                    s_loai = "(";
                    s_loai += "select " + dk_tachtheotoa + "mabn, maql, soluong, dongia, paid, ngay, madoituong,idttrv,to_number(makp) as makp,0 as loai from medibvmmyy.v_chidinh where paid=0 and idttrv=0 ";//Thuy 20.06.2012 cls<=>loai=0
                    s_loai += " union all ";
                    s_loai += " select " + dk_tachtheotoa + "mabn, maql, soluong, giaban as dongia, done as paid, ngay, madoituong,done as idttrv,makp,1 as loai from medibvmmyy.d_tienthuoc where done=0 and makp in(select a.id from medibv.d_duockp a left join medibv.btdkp_bv b on a.makp=b.makp where (b.loai=1 or b.loai=4 or b.loai is null))";//Thuy 20.06.2012 thuoc<=>loai=1
                    s_loai += ")";
                   
                }
                //gam-01/03/2011-load them toa thuoc mua ngoai
                if(m_v.tt_thutoamuangoai(m_userid))
                {
                    if (m_v.tt_thutoatutruc(m_userid))
                    {
                        s_loai = s_loai.Substring(0, s_loai.Length - 1);
                        s_loai += " union all ";
                        s_loai += "select " + dk_tachtheotoa2 + "a.mabn,a.maql,b.soluong as soluong,b.giaban as dongia,b.idttrv as paid,a.ngay,b.madoituong,b.idttrv,0 as makp,1 as loai from medibvmmyy.d_ngtrull a inner join medibvmmyy.d_ngtruct b on a.id=b.id where b.idttrv=0 ";//,done as idttrv,to_char(makp)
                        s_loai += ")";
                    }
                    else
                    {
                        s_loai = "(";// gam 20-06-2011
                        s_loai += "select " + dk_tachtheotoa + "mabn, maql, soluong, dongia, paid, ngay, madoituong,idttrv,to_number(makp) as makp,0 as loai from medibvmmyy.v_chidinh where paid=0 and idttrv=0 ";
                        s_loai += " union all ";
                        s_loai += "select " + dk_tachtheotoa2 + "a.mabn,a.maql,b.soluong as soluong, b.giaban as dongia,b.idttrv as paid,a.ngay,b.madoituong,b.idttrv,0 as makp,1 as loai from medibvmmyy.d_ngtrull a inner join medibvmmyy.d_ngtruct b on a.id=b.id where b.idttrv=0 ";//,done as idttrv,to_char(makp)
                        s_loai += ")";
                    }
                    
                }
                //linh
                string s_loaibn = m_v.tt_Loaibn_thutructiep(m_userid);
                if (s_loaibn.Trim() != "")
                {
                    string[] sloaibn = s_loaibn.Split(',');
                    sql = "";
                    for (int i = 0; i < sloaibn.Length; i++)
                    {
                        if (sloaibn[i] == "0")
                        {
                            if (sql != "") sql += " union all ";
                            //sql += "select a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,i.tenkp from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_chidinh g on a.mabn=g.mabn inner join medibvmmyy.tiepdon h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp " + exp + " and g.paid=0 and g.idttrv=0 group by a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";
                            sql += "select " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,i.tenkp,g.loai from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join " + s_loai + " g on a.mabn=g.mabn inner join medibvmmyy.tiepdon h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp " + exp + " and g.paid=0 and g.idttrv=0 group by " + dk_tachtheotoa3 + "a.mabn,a.hoten,g.loai, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";
                        }
                        else if (sloaibn[i] == "1")
                        {
                            if (sql != "") sql += " union all ";
                            sql += "select " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,i.tenkp,g.loai from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join " + s_loai + " g on a.mabn=g.mabn inner join medibv.benhandt h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp " + exp + "  and g.paid=0 and g.idttrv=0  group by " + dk_tachtheotoa3 + "a.mabn,a.hoten,g.loai, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";//gam 11042012
                        }
                        else if (sloaibn[i] == "2")
                        {
                            if (sql != "") sql += " union all ";
                            sql += "select " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,i.tenkp,0 as loai from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_chidinh g on a.mabn=g.mabn inner join medibv.benhanngtr h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp " + exp + "  and g.paid=0 and g.idttrv=0  group by " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp ";
                        }
                        else if (sloaibn[i] == "3")
                        {
                            if (sql != "") sql += " union all ";
                            sql += "select " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,i.tenkp,g.loai from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join " + s_loai + " g on a.mabn=g.mabn inner join medibvmmyy.benhanpk h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp " + exp + " and g.paid=0 and g.idttrv=0  group by " + dk_tachtheotoa3 + "a.mabn,a.hoten,g.loai, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";
                        }
                        else if (sloaibn[i] == "4")
                        {
                            if (sql != "") sql += " union all ";
                            sql += "select " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,i.tenkp,0 as loai from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.v_chidinh g on a.mabn=g.mabn inner join medibvmmyy.benhancc h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp " + exp + " and g.idttrv=0  group by " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp";
                            if (m_v.tt_thutoatutruc(m_userid))
                            {
                                if (sql != "") sql += " union all ";
                                sql += "select " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,sum(case when g.soluong is null then 0 else g.soluong*g.giaban end) as sotien,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,i.tenkp,1 as loai from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn inner join medibvmmyy.d_tienthuoc g on a.mabn=g.mabn inner join medibvmmyy.benhancc h on g.maql=h.maql inner join medibv.btdkp_bv i on h.makp=i.makp " + exp1 + " and g.idttrv=0  group by " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql,i.tenkp"; 
                            }
                        }
                    }
                }
                else
                {
                    //end linh
                    sql = "select " + dk_tachtheotoa3 + "a.mabn,a.hoten, case when a.ngaysinh is null then "+
                    " a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,to_char(g.ngay,'dd/mm/yyyy') as ngaycd,"+
                    " sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,a.sonha,a.thon,"+
                    " e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, "+
                    " f.coquan as dt_coquan,f.didong as dt_didong,f.email,g.maql as maql,g.loai "+
                    " from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c "+
                    " on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e "+
                    " on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn "+
                    " inner join " + s_loai + " g on a.mabn=g.mabn " + exp + " and g.paid=0 and g.idttrv=0 group by " + dk_tachtheotoa3 + "a.mabn,a.hoten,g.loai, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end,b.ten,to_char(g.ngay,'dd/mm/yyyy'),a.sonha,a.thon,e.tenpxa, d.tenquan, c.tentt,a.cholam,f.nha, f.coquan,f.didong,f.email,g.maql order by a.hoten, a.mabn";
                }
                dgHoadon.DataSource = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false).Tables[0];
                dgHoadon.Update();
                tmn_Sotien.Text = lan.Change_language_MessageText("TỔNG SỐ:") + " " + dgHoadon.RowCount.ToString();
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
                m_loai = arv["loai"].ToString();
                if (btt_Thutungdonthuoc)
                {
                    m_id = arv["id"].ToString();
                }
                else
                {
                    m_id = "";
                }
            }
            catch
            {
                m_mabn = "";
                m_maql = "";
                m_ngaycd = "";
                m_id = "";
                m_loai = "";
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

        private void frmDanhsachchothutructiep_Load(object sender, EventArgs e)
        {
            btt_Thutungdonthuoc = m_v.tt_Thutungdonthuoc(m_userid);
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

        private void frmDanhsachchothutructiep_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    m_mabn = "";
                    m_maql = "";
                    m_id = "";
                    m_loai = "";
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
                if (atmp.ToLower().Trim() != lan.Change_language_MessageText("tìm kiếm") && atmp.ToLower().Trim() != "")
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
           tmn_Timnhanh.BackColor = Color.LightYellow;
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
                m_v.set_o_limit_frmdanhsachchothutructiep(m_userid, txtLimit.Value.ToString());
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
                m_v.set_o_fullgrid_frmdanhsachchothutructiep(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void dgHoadon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tmn_Chon_Click(null, null);
        }
    }
}