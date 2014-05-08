using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmTimhoadon : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
      
        private LibVP.AccessData m_v;
        private string m_userid = "", m_quyenso = "", m_id = "", m_ngaythu = "", m_loaihd = "", v_solanin = "";
        private bool m_is_sub = true, bKhongchoxem_tongthu=false;
        private int i_maxlength_mabn = 8;
        private frmPrintHD m_frmprinthd;

        public frmTimhoadon(LibVP.AccessData v_v, string v_userid)
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
                f_CLear();
            }
            catch
            {
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
        public string s_id
        {
            get
            {
                return m_id;
            }
        }
        public string s_ngaythu
        {
            get
            {
                return m_ngaythu;
            }
        }
        public string s_quyenso
        {
            set
            {
                m_quyenso = value;
            }
            get
            {
                return m_quyenso;
            }
        }
        public string s_loaihd
        {
            set
            {
                chkTructiep.Checked = false;
                chkTrongoi.Checked = false;
                chkTamung.Checked = false;
                chkTTRV.Checked = false;
                m_loaihd = value;
                foreach (string atmp in value.Split(','))
                {
                    if (atmp == m_v.s_loaiform_thutructiep)
                    {
                        chkTructiep.Checked = true;
                    }
                    else if (atmp == m_v.s_loaiform_thutamung)
                    {
                        chkTamung.Checked = true;
                    }
                    else if (atmp == m_v.s_loaiform_thuchiravien)
                    {
                        chkTTRV.Checked = true;
                    }
                    else if (atmp == m_v.s_loaiform_thutrongoi)
                    {
                        chkTrongoi.Checked = true;
                    }
                }
            }
        }
        public bool s_is_sub
        {
            set
            {
                m_is_sub = value;
            }
        }
        private void f_Load_DG()
        {
            butTim.Enabled = false;
            try
            {
                tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                txtSobienlai_Validated(null, null);
                txtTuso_Validated(null, null);
                txtDenso_Validated(null, null);

                string asqltt = "", asqlnt="",asqltu="",asqlpc="", aexptt = "", aexpnt="",aexptu="",aexppc="", adk = " or ",atmp1="";
                if (rdAnd.Checked)
                {
                    adk = " and ";
                }
                int alimit = 0;
                try
                {
                    alimit = int.Parse(txtLimit.Value.ToString());
                }
                catch
                {
                    alimit = 0;
                }
                aexptt = "where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                aexpnt = "where to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                aexptu = "where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                if (txtMabn.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.mabn like '%" + txtMabn.Text+"%'";

                    aexpnt += adk;
                    aexpnt += "a.mabn like '%" + txtMabn.Text + "%'";

                    aexptu += adk;
                    aexptu += "a.mabn like '%" + txtMabn.Text + "%'";

                    aexppc += adk;
                    aexppc += "a.mabn like '%" + txtMabn.Text + "%'";
                }
                if (txtMabn1.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.mabn like '%" + txtMabn1.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "a.mabn like '%" + txtMabn1.Text + "%'";

                    aexptu += adk;
                    aexptu += "a.mabn like '%" + txtMabn1.Text + "%'";

                    aexppc += adk;
                    aexppc += "a.mabn like '%" + txtMabn1.Text + "%'";
                }
                if (txtHoten.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.hoten like '%" + txtHoten.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "c.hoten like '%" + txtHoten.Text + "%'";

                    aexptu += adk;
                    aexptu += "b.hoten like '%" + txtHoten.Text + "%'";

                    aexppc += adk;
                    aexppc += "b1.hoten like '%" + txtHoten.Text + "%'";
                }
                if (txtNamsinh.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.namsinh like '%" + txtNamsinh.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "c.namsinh like '%" + txtNamsinh.Text + "%'";

                    aexptu += adk;
                    aexptu += "b.namsinh like '%" + txtNamsinh.Text + "%'";

                    aexppc += adk;
                    aexppc += "b1.namsinh like '%" + txtNamsinh.Text + "%'";
                }
                if (txtDiachi.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.diachi like '%" + txtDiachi.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "(c.sonha like '%" + txtDiachi.Text + "%' or c.thon like '%" + txtDiachi.Text + "%' or c.cholam like '%" + txtDiachi.Text + "%')";

                    aexptu += adk;
                    aexptu += "(b.sonha like '%" + txtDiachi.Text + "%' or b.thon like '%" + txtDiachi.Text + "%' or b.cholam like '%" + txtDiachi.Text + "%')";

                    aexppc += adk;
                    aexppc += "(b1.sonha like '%" + txtDiachi.Text + "%' or b1.thon like '%" + txtDiachi.Text + "%' or b1.cholam like '%" + txtDiachi.Text + "%')";
                }
                if (txtNgaythu.Text != "")
                {
                    aexptt += adk;
                    aexptt += "to_char(a.ngay,'dd/mm/yyyy') like '%" + txtNgaythu.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "to_char(b.ngay,'dd/mm/yyyy') like '%" + txtNgaythu.Text + "%'";

                    aexptu += adk;
                    aexptu += "to_char(a.ngay,'dd/mm/yyyy') like '%" + txtNgaythu.Text + "%'";

                    aexppc += adk;
                    aexppc += "to_char(a.ngay,'dd/mm/yyyy') like '%" + txtNgaythu.Text + "%'";
                }
                atmp1 = "";
                try
                {
                    if (cbLoaidv.SelectedIndex >= 0)
                    {
                        atmp1 = "a.loai = " + cbLoaidv.SelectedValue.ToString();
                    }
                }
                catch
                {
                    atmp1 = "";
                }
                if (atmp1 != "")
                {
                    aexptt += adk;
                    aexptt += atmp1;

                    aexptu += adk;
                    aexptu += atmp1;

                    aexppc += adk;
                    aexppc += atmp1;

                    aexpnt += adk;
                    aexpnt += atmp1.Replace("a.","b.");
                }

                atmp1 = "";
                try
                {
                    if (cbKyhieu.SelectedIndex >= 0)
                    {
                        atmp1 = "a.quyenso = " + cbKyhieu.SelectedValue.ToString();
                    }
                }
                catch
                {
                    atmp1 = "";
                }
                if (atmp1 != "")
                {
                    aexptt += adk;
                    aexptt += atmp1;

                    aexptu += adk;
                    aexptu += atmp1;

                    aexppc += adk;
                    aexppc += atmp1;

                    aexpnt += adk;
                    aexpnt += atmp1.Replace("a.", "b.");
                }

                atmp1 = "";
                try
                {
                    if (cbLoaibn.SelectedIndex >= 0)
                    {
                        atmp1 = "a.loaibn = " + cbLoaibn.SelectedValue.ToString();
                    }
                }
                catch
                {
                    atmp1 = "";
                }
                if (atmp1 != "")
                {
                    aexptt += adk;
                    aexptt += atmp1;

                    aexptu += adk;
                    aexptu += atmp1;

                    aexppc += adk;
                    aexppc += atmp1;

                    aexpnt += adk;
                    aexpnt += atmp1.Replace("a.","b.");
                }

                atmp1 = "";
                try
                {
                    if (cbNguoithu.SelectedIndex >= 0)
                    {
                        atmp1 = "a.userid = " + cbNguoithu.SelectedValue.ToString();
                    }
                }
                catch
                {
                    atmp1 = "";
                }
                if (atmp1 != "")
                {
                    aexptt += adk;
                    aexptt += atmp1;

                    aexptu += adk;
                    aexptu += atmp1;

                    aexppc += adk;
                    aexppc += atmp1;

                    aexpnt += adk;
                    aexpnt += atmp1.Replace("a.","b.");
                }

                if (txtSobienlai.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.sobienlai = "+txtSobienlai.Text.Trim();

                    aexpnt += adk;
                    aexpnt += "b.sobienlai = " + txtSobienlai.Text.Trim();

                    aexptu += adk;
                    aexptu += "a.sobienlai = " + txtSobienlai.Text.Trim();

                    aexppc += adk;
                    aexppc += "a.sobienlai = " + txtSobienlai.Text.Trim();
                }
                if (txtTuso.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.sobienlai >= " + txtTuso.Text.Trim();

                    aexpnt += adk;
                    aexpnt += "b.sobienlai >= " + txtTuso.Text.Trim();

                    aexptu += adk;
                    aexptu += "a.sobienlai >= " + txtTuso.Text.Trim();

                    aexppc += adk;
                    aexppc += "a.sobienlai >= " + txtTuso.Text.Trim();
                }
                if (txtDenso.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.sobienlai <= " + txtDenso.Text.Trim();
                    
                    aexpnt += adk;
                    aexpnt += "b.sobienlai <= " + txtDenso.Text.Trim();

                    aexptu += adk;
                    aexptu += "a.sobienlai <= " + txtDenso.Text.Trim();

                    aexppc += adk;
                    aexppc += "a.sobienlai <= " + txtDenso.Text.Trim();
                }
                if (bKhongchoxem_tongthu==false)
                {
                    asqltt = "select a.mabn,a.maql,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then to_number(0,'0') else c.sotien end as mien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end as tamung,sum(b.soluong*b.dongia-case when b.thieu is null then to_number(0,'0') else b.thieu end) as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end as ghichu from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " group by a.id,a.mabn,a.maql,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu,a.sobienlai,c.sotien,b1.sotien,e.userid,e.hoten,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end order by sohieu,sobienlai";
                    asqlnt = "select a.mabn,a.maql,c.hoten,c.namsinh,to_char(b.ngay,'dd/mm/yyyy') ||' '||to_char(b.ngayud,'hh24:mi') as ngay, d.sohieu,b.sobienlai, (b.sotien-b.mien-b.bhyt-b.thieu) as thucthu,case when b.mien is null then to_number(0,'0') else b.mien end as mien,case when b.tamung is null then to_number(0,'0') else b.tamung end as tamung,b.sotien, trim(c.sonha || ' ' || c.thon || ' ' ||c.cholam) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(b.sobienlai,9999999)) as sbl,'Thanh toán ra viện' as ghichu from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll b on a.id=b.id left join medibv.btdbn c on a.mabn=c.mabn left join medibv.v_quyenso d on b.quyenso=d.id left join medibv.v_dlogin e on b.userid=e.id " + aexpnt + " order by sohieu,sobienlai";
                    asqltu = "select a.mabn,a.maql,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, c.sohieu,a.sobienlai, a.sotien as thucthu,to_number(0,'0') as mien,to_number(0,'0') as tamung,a.sotien, trim(b.sonha || ' ' || b.thon || ' ' || b.cholam) as diachi,d.userid as user_nv,d.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'" + lan.Change_language_MessageText("Thu tạm ứng") + "' as ghichu from medibvmmyy.v_tamung a left join medibv.btdbn b on a.mabn=b.mabn left join medibv.v_quyenso c on a.quyenso=c.id left join medibv.v_dlogin d on a.userid=d.id " + aexptu + " order by sohieu,sobienlai";
                    asqlpc = "select a.mabn,a.maql,b1.hoten,b1.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, c.sohieu,a.sobienlai, sum(b.sotien) as thucthu,to_number(0,'0') as mien,to_number(0,'0') as tamung, sum(b.sotien) as sotien, trim(b1.sonha || ' ' || b1.thon || ' ' || b1.cholam) as diachi,d.userid as user_nv,d.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'Phiếu chi' as ghichu from medibvmmyy.v_phieuchill a inner join medibvmmyy.v_phieuchict b on a.id=b.id left join medibv.btdbn b1 on a.mabn=b1.mabn left join medibv.v_quyenso c on a.quyenso=c.id left join medibv.v_dlogin d on a.userid=d.id " + aexppc + " group by a.mabn,a.maql,b1.hoten,b1.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), c.sohieu,a.sobienlai, trim(b1.sonha || ' ' || b1.thon || ' ' || b1.cholam),d.userid,d.hoten,a.id,trim(to_char(a.sobienlai,9999999)) order by sohieu,sobienlai";
                }
                else
                {
                    asqltt = "select a.mabn,a.maql,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai, 0 as thucthu,0 as mien,0 as tamung, 0 as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end as ghichu from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " group by a.id,a.mabn,a.maql,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu,a.sobienlai,c.sotien,b1.sotien,e.userid,e.hoten,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end order by sohieu,sobienlai";
                    asqlnt = "select a.mabn,a.maql,c.hoten,c.namsinh,to_char(b.ngay,'dd/mm/yyyy') ||' '||to_char(b.ngayud,'hh24:mi') as ngay, d.sohieu,b.sobienlai, 0 as thucthu,0 as mien,0 as tamung,0 as sotien, trim(c.sonha || ' ' || c.thon || ' ' ||c.cholam) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(b.sobienlai,9999999)) as sbl,'Thanh toán ra viện' as ghichu from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll b on a.id=b.id left join medibv.btdbn c on a.mabn=c.mabn left join medibv.v_quyenso d on b.quyenso=d.id left join medibv.v_dlogin e on b.userid=e.id " + aexpnt + " order by sohieu,sobienlai";
                    asqltu = "select a.mabn,a.maql,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, c.sohieu,a.sobienlai, 0 as thucthu,0 as mien,0 as tamung,0 as sotien, trim(b.sonha || ' ' || b.thon || ' ' || b.cholam) as diachi,d.userid as user_nv,d.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'" + lan.Change_language_MessageText("Thu tạm ứng") + "' as ghichu from medibvmmyy.v_tamung a left join medibv.btdbn b on a.mabn=b.mabn left join medibv.v_quyenso c on a.quyenso=c.id left join medibv.v_dlogin d on a.userid=d.id " + aexptu + " order by sohieu,sobienlai";
                    asqlpc = "select a.mabn,a.maql,b1.hoten,b1.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, c.sohieu,a.sobienlai, 0 as thucthu,0 as mien,0 as tamung,0 as sotien, trim(b1.sonha || ' ' || b1.thon || ' ' || b1.cholam) as diachi,d.userid as user_nv,d.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'Phiếu chi' as ghichu from medibvmmyy.v_phieuchill a inner join medibvmmyy.v_phieuchict b on a.id=b.id left join medibv.btdbn b1 on a.mabn=b1.mabn left join medibv.v_quyenso c on a.quyenso=c.id left join medibv.v_dlogin d on a.userid=d.id " + aexppc + " group by a.mabn,a.maql,b1.hoten,b1.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), c.sohieu,a.sobienlai, trim(b1.sonha || ' ' || b1.thon || ' ' || b1.cholam),d.userid,d.hoten,a.id,trim(to_char(a.sobienlai,9999999)) order by sohieu,sobienlai";
                }


                DataSet adstt = null;
                DataSet adsnt = null;
                DataSet adstu = null;
                DataSet adspc = null;
                DataSet ads = null;

                if ((chkTructiep.Checked && chkTamung.Checked && chkTTRV.Checked && chkTrongoi.Checked && chkPhieuchi.Checked) || (!chkTructiep.Checked && !chkTamung.Checked && !chkTTRV.Checked && !chkTrongoi.Checked && !chkPhieuchi.Checked))
                {
                    adstt = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqltt, alimit);
                    adsnt = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqlnt, alimit);
                    adstu = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqltu, alimit);
                    adspc = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqlpc, alimit);
                }
                else
                {
                    if (chkTructiep.Checked && chkTrongoi.Checked)
                    {
                        adstt = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqltt, alimit);
                    }
                    else if (chkTructiep.Checked)
                    {
                        asqltt = "select a.mabn,a.maql,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then to_number(0,'0') else c.sotien end as mien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end as tamung,sum(b.soluong*b.dongia-case when b.thieu is null then to_number(0,'0') else b.thieu end) as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end as ghichu from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " and b1.id is null group by a.id,a.mabn,a.maql,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu,a.sobienlai,c.sotien,b1.sotien,e.userid,e.hoten,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end order by sohieu,sobienlai";
                        adstt = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqltt, alimit);
                    }
                    else if (chkTrongoi.Checked)
                    {
                        asqltt = "select a.mabn,a.maql,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then to_number(0,'0') else c.sotien end as mien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end as tamung,sum(b.soluong*b.dongia-case when b.thieu is null then to_number(0,'0') else b.thieu end) as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,case when b1.id is null then lan.Change_language_MessageText('Thu trực tiếp') else lan.Change_language_MessageText('Thu trọn gói') end as ghichu from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id inner join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " group by a.id,a.mabn,a.maql,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu,a.sobienlai,c.sotien,b1.sotien,e.userid,e.hoten,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end order by sohieu,sobienlai";
                        adstt = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqltt, alimit);
                    }

                    if (chkTTRV.Checked)
                    {
                        adsnt = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqlnt, alimit);
                    }
                    if (chkTamung.Checked)
                    {
                        adstu = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqltu, alimit);
                    }
                    if (chkPhieuchi.Checked)
                    {
                        adstu = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqlpc, alimit);
                    }
                }

                if (adstt != null)
                {
                    if (ads == null)
                    {
                        ads = adstt;
                    }
                    else
                    {
                        ads.Merge(adstt);
                    }
                }
                if (adsnt != null)
                {
                    if (ads == null)
                    {
                        ads = adsnt;
                    }
                    else
                    {
                        ads.Merge(adsnt);
                    }
                }
                if (adstu != null)
                {
                    if (ads == null)
                    {
                        ads = adstu;
                    }
                    else
                    {
                        ads.Merge(adstu);
                    }
                }
                if (adspc != null)
                {
                    if (ads == null)
                    {
                        ads = adspc;
                    }
                    else
                    {
                        ads.Merge(adspc);
                    }
                }
                dgHoadon.DataSource = ads.Tables[0];
                dgHoadon.Update();
                decimal atmp = 0, asotien=0;

                //Sum số tiền
                if (ads != null)
                {
                    foreach (DataRow r in ads.Tables[0].Rows)
                    {
                        try
                        {
                            atmp = decimal.Parse(r["thucthu"].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        asotien += atmp;
                    }
                }
                tmn_Sotien.Text = (bKhongchoxem_tongthu) ? "" : (dgHoadon.RowCount.ToString() + " " + lan.Change_language_MessageText("HĐ =") + " " + asotien.ToString("###,###,##0.##") + " " + lan.Change_language_MessageText("Đ"));
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
        private void f_Load_Data()
        {
            try
            {
                cbNguoithu.DataSource = m_v.get_data("select id,hoten from medibv.v_dlogin order by hoten").Tables[0];
                cbNguoithu.DisplayMember = "hoten";
                cbNguoithu.ValueMember = "id";

                cbLoaidv.DataSource = m_v.get_data("select ma,ten from medibv.v_tenloaivp order by ma").Tables[0];
                cbLoaidv.DisplayMember = "ten";
                cbLoaidv.ValueMember = "ma";

                cbLoaibn.DataSource = m_v.get_data("select id,ten from medibv.v_loaibn order by id").Tables[0];
                cbLoaibn.DisplayMember = "ten";
                cbLoaibn.ValueMember = "id";

                cbKyhieu.DataSource = m_v.get_data("select id,sohieu from medibv.v_quyenso order by sohieu").Tables[0];
                cbKyhieu.DisplayMember = "sohieu";
                cbKyhieu.ValueMember = "id";

                v_solanin = m_v.sys_solanin;
                m_frmprinthd = new frmPrintHD(m_v,m_userid);
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmtimhoadon(m_userid);
                f_Set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmtimhoadon(m_userid).ToString());

                toolStripMenuItem_TTLoai.Checked = m_v.tt_Intheoloai(m_userid);
                ToolStripMenuItem_TTNhom.Checked = m_v.tt_Intheonhom(m_userid);
                toolStripMenuItem_TTchitiet.Checked = m_v.tt_InchitietHD(m_userid);
                toolStripMenuItem_TTDacthu.Checked = m_v.tt_InHDdacthu(m_userid);
                toolStripMenuItem_TTThuong.Checked = m_v.tt_InHD_thuong(m_userid);
                toolStripMenuItem_TTRVTHuong.Checked =m_v.ttrv_InHDchitiet(m_userid);
                toolStripMenuItem_TTRVDacthu.Checked = m_v.ttrv_InHDdacthu(m_userid);
            }
            catch
            {
            }
        }
        private void f_CLear()
        {
            try
            {
                txtMabn.Text = "";
                txtMabn1.Text = "";
                txtHoten.Text = "";
                txtNamsinh.Text = "";
                txtDiachi.Text = "";
                txtNgaythu.Text = "";
                cbLoaidv.Text = "";
                cbNguoithu.Text = "";
                cbKyhieu.Text = "";
                cbLoaibn.Text = "";
                try
                {
                    cbLoaidv.SelectedIndex = -1;
                    cbNguoithu.SelectedIndex = -1;
                    cbKyhieu.SelectedIndex = -1;
                    cbLoaibn.SelectedIndex = -1;
                }
                catch
                {
                }
                txtTuso.Text = "";
                txtDenso.Text = "";
                txtSobienlai.Text = "";
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
            catch
            {
            }
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
                string aloaihd = "2", atitle = "", aghichu = "";
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                try
                {
                    m_id = arv["id"].ToString();
                    m_ngaythu = arv["ngay"].ToString();
                    aghichu = arv["ghichu"].ToString();
                    atitle = lan.Change_language_MessageText("HOÁ ĐƠN:")+" " + arv["sohieu"].ToString() + " - " + arv["sobienlai"].ToString().PadLeft(7, '0') + " "+"- NGÀY LẬP:"+" " + m_ngaythu;
                    if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thu trực tiếp"))
                    {
                        aloaihd = "1";
                    }
                    else if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thu tạm ứng"))
                    {
                        aloaihd = "2";
                    }
                    else if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thanh toán ra viện"))
                    {
                        aloaihd = "3";
                    }
                    else if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thu trọn gói"))
                    {
                        aloaihd = "4";
                    }
                }
                catch
                {
                    m_id = "";
                    m_ngaythu = "";
                }
                if (m_is_sub)
                {
                    if (m_loaihd == "" || aloaihd == m_loaihd)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn:")+" " + aghichu +" "+ lan.Change_language_MessageText("Chỉ xem thôi nhé!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (m_id != "" && m_ngaythu != "" && aloaihd != "2")
                    {
                        frmChitiethd af = new frmChitiethd(m_v, m_id, aloaihd, m_v.get_mmyy(m_ngaythu));
                        af.s_kyhieu = lan.Change_language_MessageText("Ký hiệu:")+" " + arv["sohieu"].ToString();
                        af.s_sobienlai = lan.Change_language_MessageText("Số hoá đơn:") + " " + arv["sobienlai"].ToString();
                        af.s_ngayhd = lan.Change_language_MessageText("Ngày hoá đơn:") + " " + arv["ngay"].ToString();
                        af.s_benhnhan = lan.Change_language_MessageText("Mã BN:") + " " + arv["mabn"].ToString() + lan.Change_language_MessageText(" - Họ và tên: ") + arv["hoten"].ToString() + lan.Change_language_MessageText(" - Năm sinh: ") + arv["namsinh"].ToString();
                        af.s_diachi = lan.Change_language_MessageText("Địa chỉ:") + " " + arv["diachi"].ToString();
                        af.s_nhanvien = lan.Change_language_MessageText("Nhân viên thu ngân:") + " " + arv["hoten_nv"].ToString();
                        af.ShowInTaskbar = false;
                        af.TopMost = true;
                        af.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn:")+" " + aghichu + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Inhoadon_Click(object sender, EventArgs e)
        {
            string  atitle = "", aghichu = "";
            DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
            try
            {
                m_id = arv["id"].ToString();
                m_ngaythu = arv["ngay"].ToString();
                aghichu = arv["ghichu"].ToString();
                atitle = lan.Change_language_MessageText("HOÁ ĐƠN:") + " " + arv["sohieu"].ToString() + " - " + arv["sobienlai"].ToString().PadLeft(7, '0') + " " + "- NGÀY LẬP:" + " " + m_ngaythu;
                if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thu trực tiếp"))
                {           
                    string s = m_v.get_data_mmyy(m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "select lanin from medibvmmyy.v_vienphill where id=" + m_id + "").Tables[0].Rows[0]["lanin"].ToString();
                    if (decimal.Parse(v_solanin) > decimal.Parse(s))
                    {
                        if (m_v.tt_Intheoloai(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Loai(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1");
                        }
                        if (m_v.tt_Intheonhom(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Nhom(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1");
                        }
                        if (m_v.tt_InchitietHD(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_chitiet(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)));
                        }
                        if (m_v.tt_InHDdacthu(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1","");
                        }
                        if (m_v.tt_InHD_thuong(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Thuong(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1", "", "","");
                        }
                        if (!m_v.tt_Intheoloai(m_userid) && !m_v.tt_Intheonhom(m_userid) && !m_v.tt_InchitietHD(m_userid) && !m_v.tt_InHDdacthu(m_userid) && !m_v.tt_InHD_thuong(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Thuong(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1", "", "","");
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Số lần in " + s + " vượt quá số lần in quy định " + v_solanin + " !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thu tạm ứng"))
                {
                    m_frmprinthd.f_Print_BienlaiTU(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)));
                }
                else if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thanh toán ra viện"))
                {
                   
                    string ss = m_v.get_data_mmyy(m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "select lanin from medibvmmyy.v_ttrvll where id=" + m_id + "").Tables[0].Rows[0]["lanin"].ToString();
                    if (decimal.Parse(v_solanin) > decimal.Parse(ss))
                    {
                        if (toolStripMenuItem_TTRVTHuong.Checked)
                        {
                            m_frmprinthd.f_Print_Bienlai_ThuongNT(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1");
                        }
                        if (toolStripMenuItem_TTRVDacthu.Checked)
                        {
                            m_frmprinthd.f_Print_BienlaiNT(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1", "");

                        }
                        if (!toolStripMenuItem_TTRVTHuong.Checked && !toolStripMenuItem_TTRVDacthu.Checked)
                        {

                            m_frmprinthd.f_Print_BienlaiNT(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1", "");
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Số lần in " + ss + " vượt quá số lần in quy định " + v_solanin + " !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thu trọn gói"))
                {
                   // aloaihd = "4";
                }


            }
            catch
            {
                m_id = "";
                m_ngaythu = "";
            }

        }

        private void tmn_Inchiphi_Click(object sender, EventArgs e)
        {
            string atitle = "", aghichu = "", m_maql = "";
            DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
            try
            {
                m_maql = arv["maql"].ToString();
                m_ngaythu = arv["ngay"].ToString();
                aghichu = arv["ghichu"].ToString();
                atitle = lan.Change_language_MessageText("HOÁ ĐƠN:") + " " + arv["sohieu"].ToString() + " - " + arv["sobienlai"].ToString().PadLeft(7, '0') + " " + "- NGÀY LẬP:" + " " + m_ngaythu;
                string v_loai = "";
                if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thu trực tiếp")) v_loai = "1";
                if (arv["ghichu"].ToString() == lan.Change_language_MessageText("Thanh toán ra viện")) v_loai = "2";
                CurrencyManager cm = (CurrencyManager)BindingContext[dgHoadon.DataSource, dgHoadon.DataMember];
                DataView dv = (DataView)cm.List;
                m_id = "";
                foreach (DataRow r in dv.Table.Select("maql=" + m_maql))
                {
                    m_id += r["id"].ToString() + ",";
                }
                m_id = m_id.Trim().Trim(',');
                if (v_loai != "") m_frmprinthd.f_Print_BienlaiKB_chitiet(false, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), v_loai);
            }
            catch
            {
                m_id = "";
                m_ngaythu = "";
            }
        }

        private void frmTimhoadonthutructiep_Load(object sender, EventArgs e)
        {
            i_maxlength_mabn = LibVP.AccessData.i_maxlength_mabn;
            //string s_mask = "999999";
            //txtMabn1.Mask = s_mask.PadLeft(i_maxlength_mabn - 2, '9');
            tmn_Chon.Text = (m_is_sub ? lan.Change_language_MessageText("Chọn") : lan.Change_language_MessageText("Chi tiết"));
            bKhongchoxem_tongthu = m_v.sys_khongchoxem_tongthu == "1";
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
                    //f_Load_DG();
                    butTim.Focus();
                }
            }
            catch
            {
            }
        }

        private void frmTimhoadonthutructiep_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    m_id = "";
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
                string atmp = tmn_Timnhanh.Text;
                if (atmp.ToLower().Trim() != lan.Change_language_MessageText("Tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "mabn like '%" + atmp + "%' or hoten like '%" + atmp + "%' or namsinh like '%" + atmp + "%' or ngay like '%" + atmp + "%' or sohieu like '%" + atmp + "%' or diachi like '%" + atmp + "%' or sbl like '%" + atmp + "%' or ghichu like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch
            {
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

        private void butClear_Click(object sender, EventArgs e)
        {
            f_CLear();
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
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

        private void txtMabn1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMabn1_Validated(null, null);
                    if (txtMabn.Text.Length == 2 && txtMabn1.Text.Length == 6)
                    {
                        butTim_Click(null, null);
                    }
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtHoten_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNamsinh_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSobienlai_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNgaythu_KeyDown(object sender, KeyEventArgs e)
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

        private void cbNguoithu_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTuso_KeyDown(object sender, KeyEventArgs e)
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

        private void cbLoaidv_KeyDown(object sender, KeyEventArgs e)
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

        private void cbKyhieu_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDenso_KeyDown(object sender, KeyEventArgs e)
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

        private void tmn_In_Click(object sender, EventArgs e)
        {

        }

        private void tmn_Excel_Click(object sender, EventArgs e)
        {

        }

        private void txtLimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butTim.Focus();
                }
            }
            catch
            {
            }
            m_v.set_o_limit_frmtimhoadon(m_userid, txtLimit.Value.ToString());
        }

        private void txtSobienlai_Validated(object sender, EventArgs e)
        {
            try
            {
                txtSobienlai.Text = decimal.Parse(txtSobienlai.Text.Trim()).ToString("#########");
            }
            catch
            {
                txtSobienlai.Text = "";
            }
        }
        private void txtTuso_Validated(object sender, EventArgs e)
        {
            try
            {
                txtTuso.Text = decimal.Parse(txtTuso.Text.Trim()).ToString("#########");
            }
            catch
            {
                txtTuso.Text = "";
            }
        }
        private void txtDenso_Validated(object sender, EventArgs e)
        {
            try
            {
                txtDenso.Text = decimal.Parse(txtDenso.Text.Trim()).ToString("#########");
            }
            catch
            {
                txtDenso.Text = "";
            }
        }

        private void cbLoaibn_KeyDown(object sender, KeyEventArgs e)
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

        private void rdAnd_KeyDown(object sender, KeyEventArgs e)
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

        private void rdOr_KeyDown(object sender, KeyEventArgs e)
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
        private void f_Set_Fullgrid()
        {
            try
            {
                dgHoadon.Columns["Column_6"].Frozen = !tmn_Fullgrid.Checked;
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
                f_Set_Fullgrid();
                m_v.set_o_fullgrid_frmtimhoadon(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void chkTructiep_KeyDown(object sender, KeyEventArgs e)
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

        private void chkTamung_KeyDown(object sender, KeyEventArgs e)
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

        private void chkTTRV_KeyDown(object sender, KeyEventArgs e)
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

        private void dgHoadon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tmn_Chon_Click(null, null);
        }

        private void chkTrongoi_KeyDown(object sender, KeyEventArgs e)
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
        private void txtMabn_Validated(object sender, EventArgs e)
        {
            try
            {
                txtMabn.Text = txtMabn.Text.Trim();
                if (txtMabn.Text.Trim().Length > 0)
                {
                    txtMabn.Text = txtMabn.Text.Trim().PadLeft(2, '0');
                }
            }
            catch
            {
                txtMabn.Text = "";
            }
        }

        private void txtMabn1_Validated(object sender, EventArgs e)
        {
            try
            {
                txtMabn1.Text = txtMabn1.Text.Trim();
                if (txtMabn1.Text.Trim().Length > 0)
                {
                    txtMabn1.Text = txtMabn1.Text.Trim().PadLeft(6, '0');
                }
            }
            catch
            {
                txtMabn1.Text = "";
            }
        }

     
        private void ToolStripMenuItem_TTNhom_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_TTNhom.Checked = !ToolStripMenuItem_TTNhom.Checked;
            m_v.set_tt_Intheonhom(m_userid, ToolStripMenuItem_TTNhom.Checked);
        }

        private void toolStripMenuItem_TTLoai_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_TTLoai.Checked = !toolStripMenuItem_TTLoai.Checked;
            m_v.set_tt_Intheoloai(m_userid, toolStripMenuItem_TTLoai.Checked);
        }

        private void toolStripMenuItem_TTchitiet_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_TTchitiet.Checked = !toolStripMenuItem_TTchitiet.Checked;
            m_v.set_tt_InchitietHD(m_userid, toolStripMenuItem_TTchitiet.Checked);
        }

        private void toolStripMenuItem_TTThuong_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_TTThuong.Checked = !toolStripMenuItem_TTThuong.Checked;
            m_v.set_tt_InHDdacthu(m_userid, toolStripMenuItem_TTThuong.Checked);
        }

        private void toolStripMenuItem_TTDacthu_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_TTDacthu.Checked = !toolStripMenuItem_TTDacthu.Checked;
            m_v.set_tt_InHD_thuong(m_userid, toolStripMenuItem_TTDacthu.Checked);
        }

        private void toolStripMenuItem_TTRVTHuong_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_TTRVTHuong.Checked = !toolStripMenuItem_TTRVTHuong.Checked;
            m_v.set_ttrv_InHDdacthu(m_userid, toolStripMenuItem_TTRVTHuong.Checked);
           
        }

        private void toolStripMenuItem_TTRVDacthu_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_TTRVDacthu.Checked = !toolStripMenuItem_TTRVDacthu.Checked;
            m_v.set_ttrv_InHDchitiet(m_userid, toolStripMenuItem_TTRVDacthu.Checked);
        }

        private void txtMabn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "0123456789\b".IndexOf(e.KeyChar) == -1;
        }
    }
}