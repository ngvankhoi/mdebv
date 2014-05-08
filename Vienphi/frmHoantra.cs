using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmHoantra : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;        
        private string m_userid="";
        private int itable;
        private int i_maxlength_mabn = 8;
        private bool m_is_sub = false;
        private frmHoantract m_frmhoantract = null;
        private frmPrintHD frmInhoantra;
        private string m_mabn = "", m_mavaovien = "",m_ngay="";
        private decimal m_congkham = 0;
        public frmHoantra(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();

                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Read_dtgrid_to_Xml(dgHoan, this.Name + "_" + "dgHoan");
                lan.Change_dtgrid_HeaderText_to_English(dgHoan, this.Name + "_" + "dgHoan");

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
        public string s_sohoadon
        {
            set
            {
                txtSobienlai.Text = value;
            }
        }
        public string s_quyenso
        {
            set
            {
                try
                {
                    cbKyhieu.SelectedValue = value;
                }
                catch
                {
                }
            }
        }
        public string s_ngaythu
        {
            set
            {
                txtNgaythu.Text=value;
            }
        }
        public string s_ngayhoan
        {
            set
            {
                txtNgayhoan.Value = m_v.f_parse_date(value);
            }
        }
        public string s_loaihd
        {
            set
            {
                chkTructiep.Checked = false;
                chkTamung.Checked = false;
                chkTTRV.Checked = false;
                chkTrongoi.Checked = false;
                chkPhieuchi.Checked = false;
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
                    else if (atmp == m_v.s_loaiform_phieuchi)
                    {
                        chkPhieuchi.Checked = true;
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

                string asqltt = "", asqlnt="",asqltu="", asqlpc="", aexptt = "", aexpnt="",aexptu="",aexppc="", adk = " or ",atmp1="";
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
                aexppc = "where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
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

                asqltt = "select a.mabn,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then to_number(0,'0') else c.sotien end as mien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end as tamung,sum(b.soluong*b.dongia-case when b.thieu is null then to_number(0,'0') else b.thieu end) as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end as ghichu, case when b1.id is null then 1 else 4 end as loaihd,a.loaibn,a.mavaovien from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " group by a.id,a.mabn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu,a.sobienlai,c.sotien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end,e.userid,e.hoten,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end, case when b1.id is null then 1 else 4 end,a.loaibn order by sohieu,sobienlai";
                asqlnt = "select a.mabn,c.hoten,c.namsinh,to_char(b.ngay,'dd/mm/yyyy') ||' '||to_char(b.ngayud,'hh24:mi') as ngay, d.sohieu,b.sobienlai, (b.sotien-b.mien-b.bhyt-b.thieu) as thucthu,case when b.mien is null then to_number(0,'0') else b.mien end as mien,case when b.tamung is null then to_number(0,'0') else b.tamung end as tamung,b.sotien, trim(c.sonha || ' ' || c.thon || ' ' ||c.cholam) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(b.sobienlai,9999999)) as sbl,'Thanh toán ra viện' as ghichu, 3 as loaihd,b.loaibn,a.mavaovien  from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll b on a.id=b.id left join medibv.btdbn c on a.mabn=c.mabn left join medibv.v_quyenso d on b.quyenso=d.id left join medibv.v_dlogin e on b.userid=e.id " + aexpnt + " order by sohieu,sobienlai";
                asqltu = "select a.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, c.sohieu,a.sobienlai, a.sotien as thucthu,to_number(0,'0') as mien,to_number(0,'0') as tamung,a.sotien, trim(b.sonha || ' ' || b.thon || ' ' || b.cholam) as diachi,d.userid as user_nv,d.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'Tạm ứng' as ghichu, 2 as loaihd,a.loaibn,a.mavaovien from medibvmmyy.v_tamung a left join medibv.btdbn b on a.mabn=b.mabn left join medibv.v_quyenso c on a.quyenso=c.id left join medibv.v_dlogin d on a.userid=d.id " + aexptu + " order by sohieu,sobienlai";
                asqlpc = "select a.mabn,b1.hoten,b1.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, c.sohieu,a.sobienlai, sum(b.sotien) as thucthu,to_number(0,'0') as mien,to_number(0,'0') as tamung, sum(b.sotien) as sotien, trim(b1.sonha || ' ' || b1.thon || ' ' || b1.cholam) as diachi,d.userid as user_nv,d.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'Phiếu chi' as ghichu,5 as loaihd,a.loaibn,a.maql as mavaovien from medibvmmyy.v_phieuchill a inner join medibvmmyy.v_phieuchict b on a.id=b.id left join medibv.btdbn b1 on a.mabn=b1.mabn left join medibv.v_quyenso c on a.quyenso=c.id left join medibv.v_dlogin d on a.userid=d.id " + aexppc + " group by a.mabn,b1.hoten,b1.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), c.sohieu,a.sobienlai, trim(b1.sonha || ' ' || b1.thon || ' ' || b1.cholam),d.userid,d.hoten,a.id,trim(to_char(a.sobienlai,9999999)),a.loaibn order by sohieu,sobienlai";

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
                        asqltt = "select a.mabn,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then to_number(0,'0') else c.sotien end as mien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end as tamung,sum(b.soluong*b.dongia-case when b.thieu is null then to_number(0,'0') else b.thieu end) as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end as ghichu, case when b1.id is null then 1 else 4 end as loaihd,a.loaibn,a.mavaovien from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " and b1.id is null group by a.id,a.mabn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu,a.sobienlai,c.sotien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end,e.userid,e.hoten,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end, case when b1.id is null then 1 else 4 end,a.loaibn,a.mavaovien order by sohieu,sobienlai";//gam 26/09/2011 them group by a.mavaovien
                        adstt = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqltt, alimit);
                    }
                    else if (chkTrongoi.Checked)
                    {
                        asqltt = "select a.mabn,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then to_number(0,'0') else c.sotien end as mien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end as tamung,sum(b.soluong*b.dongia-case when b.thieu is null then to_number(0,'0') else b.thieu end) as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end as ghichu, case when b1.id is null then 1 else 4 end as loaihd,a.loaibn,a.mavaovien from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id inner join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " group by a.id,a.mabn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu,a.sobienlai,c.sotien,case when b1.sotien is null then to_number(0,'0') else b1.sotien end,e.userid,e.hoten,case when b1.id is null then 'Thu trực tiếp' else 'Thu trọn gói' end, case when b1.id is null then 1 else 4 end,a.loaibn order by sohieu,sobienlai";
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
                        adspc = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqlpc, alimit);
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
                lbTong.Text = dgHoadon.RowCount.ToString();
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
                lbTong.Text = "0";
            }
            butTim.Enabled = true;
        }
        private void f_Load_DG_Hoan()
        {
            butHT_Xem.Enabled = false;
            try
            {
                string sql = "",aexp="";
                aexp = "where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtHT_TN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtHT_DN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                sql = "select a.mabn, f.hoten, f.namsinh, b.sohieu, a.sobienlai,a.sotien,case when a.ghichu ='1' then 'Thu trực tiếp' when a.ghichu='2' then 'Thu tạm ứng' when a.ghichu='3' then 'Thanh toán ra viện' when a.ghichu='4' then 'Thu trọn gói' when a.ghichu='5' then 'Phiếu chi' else a.ghichu end as ghichu, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(a.ngayud,'dd/mm/yyyy') as ngaythu,c.hoten as user_hoten, c.userid as user_userid,d.ten as loaidv_ten, e.ten as loaibn_ten,f.sonha,f.thon,i.tenpxa as xa,h.tenquan as quan, g.tentt as tinh,a.id,trim(a.ghichu) as loaihd,a.quyenso,a.maql,a.loai,a.loaibn from medibvmmyy.v_hoantra a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id left join medibv.v_tenloaivp d on a.loai=d.ma left join medibv.v_loaibn e on a.loaibn=e.id left join medibv.btdbn f on a.mabn=f.mabn left join medibv.btdtt g on f.matt=g.matt left join medibv.btdquan h on f.maqu=h.maqu left join medibv.btdpxa i on f.maphuongxa=i.maphuongxa " + aexp;
                DataSet ads = m_v.get_data_bc(txtHT_TN.Value, txtHT_DN.Value, sql, 0);
                dgHoan.DataSource = ads.Tables[0];
                dgHoan.Update();
                decimal atong = 0,atmp=0;
                if (ads != null)
                {
                    foreach (DataRow r in ads.Tables[0].Rows)
                    {
                        try
                        {
                            atmp = decimal.Parse(r["sotien"].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        atong += atmp;
                    }
                }
                lbHT_Tonghd.Text = dgHoan.RowCount.ToString();
                lbHT_Tongtien.Text = atong.ToString("###,###,##0.##");
            }
            catch
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoan.DataSource, dgHoan.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    dv.Table.Rows.Clear();
                }
                catch
                {
                }
                lbHT_Tonghd.Text = "0";
                lbHT_Tongtien.Text = "0";
            }
            butHT_Xem.Enabled = true;
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

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmhoantra(m_userid);
                f_Set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmhoantra(m_userid).ToString());

                tmn_Luuin_Hoan.Checked = m_v.get_o_luuin_frmhoantra(m_userid);
                tmn_Xemtruockhiin.Checked = m_v.get_o_preview_frmhoantra(m_userid);

                tmn_Hoanchitiet.Enabled = m_v.tt_HoanHDchitiet(m_userid);

                frmInhoantra = new frmPrintHD(m_v, m_userid);
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
                lbTong.Text = "0";
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

        private void tmn_Hoan_Click(object sender, EventArgs e)
        {
            try
            {
                string aid = "", aidht = "", ammyy = "", sql = "", sql1 = "", ammyyhd = "", aghichu = "", s_amavp = "", s_tenvp = "", aloaibn = "0";
                ammyy = m_v.get_mmyy(txtNgayhoan.Text.Substring(0,10));
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                aid = arv["id"].ToString();
                ammyyhd = m_v.get_mmyy(arv["ngay"].ToString().Substring(0,10));
                DateTime angaythu = m_v.f_parse_date(arv["ngay"].ToString().Substring(0, 10));
                aloaibn = arv["loaibn"].ToString();
                if (angaythu > txtNgayhoan.Value)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Ngày hoàn trả phải >= ") + arv["ngay"].ToString().Substring(0, 10) + " !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (aid != "")
                {
                    switch (arv["loaihd"].ToString())
                    {
                        case "1"://TT
                            if (!m_v.tt_hoanhoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền hoàn trả hoá đơn thu trực tiếp.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            aghichu = "1";// "Thu trực tiếp";
                            sql = "select a.id,a.mabn,a.hoten,a.mavaovien,a.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,coalesce(b.mavp,0) as mavp, sum(b.soluong*b.dongia-b.mien-b.thieu) as sotien, sum(b.soluong*b.dongia-b.mien-b.thieu) as sotienct from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id where a.id=" + aid + " group by a.id,a.mabn,a.hoten,a.mavaovien,a.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,b.mavp";
                            break;
                        case "2"://TU
                            if (!m_v.tu_hoanhoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền hoàn trả hoá đơn tạm ứng.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            aghichu = "2";// "Thu tạm ứng";
                            sql1 = "select a.mabn, a.done, a.idttrv from medibvmmyy.v_tamung a left join medibv.btdbn b on a.mabn=b.mabn where a.id=" + aid + " and done<>0 and idttrv<>0 ";
                            sql = "select a.id,a.mabn,b.hoten,a.mavaovien,a.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,-1 as mavp,a.sotien as sotien,a.sotien as sotienct from medibvmmyy.v_tamung a left join medibv.btdbn b on a.mabn=b.mabn where a.id=" + aid;
                            break;
                        case "3"://NT
                            if (!m_v.ttrv_hoanhoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền hoàn trả hoá đơn thu chi ra viện.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            aghichu = "3"; //"Thu chi ra viện";
                            sql = "select a.id,c.mabn,d.hoten,c.mavaovien,c.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,coalesce(b.mavp,0) as mavp, a.sotien, sum(coalesce(b.soluong,0)*b.dongia) as sotienct from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_ttrvds c left join medibv.btdbn d on c.mabn=d.mabn on a.id=c.id where a.id=" + aid + " group by a.id,c.mabn,d.hoten,c.mavaovien,c.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,b.mavp,a.sotien";
                            break;
                        case "4"://Tron goi
                            if (!m_v.tg_hoanhoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền hoàn trả hoá đơn thu trọn gói.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            aghichu = "4"; //"Thu trọn gói";
                            sql = "select a.id,a.mabn,a.hoten,a.mavaovien,a.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,b.mavp, sum(b.soluong*b.dongia-b.mien-b.thieu) as sotien, sum(b.soluong*b.dongia-b.mien-b.thieu) as sotienct from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id where a.id=" + aid + " group by a.id,a.mabn,a.hoten,a.mavaovien,a.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,b.mavp";
                            break;
                        case "5"://Phieu chi
                            if (!m_v.pc_hoanhoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền hoàn trả phiếu chi.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            aghichu = "5"; //"Phiếu chi";
                            sql = "select a.id,a.mabn,a.hoten,a.maql as mavaovien,a.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,b.mavp, sum(b.sotien) as sotien, sum(b.sotien) as sotienct from medibvmmyy.v_phieuchill a inner join medibvmmyy.v_phieuchict b on a.id=b.id where a.id=" + aid + " group by a.id,a.mabn,a.hoten,a.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,b.mavp";
                            break;
                    }
                    if (sql1.Trim() != "")
                    {
                        DataSet ads1 = m_v.get_data_mmyy(ammyyhd, sql1);
                        if (ads1.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn tạm ứng đã hoàn khi thanh toán ra viện!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    DataSet ads = m_v.get_data_mmyy(ammyyhd,sql);
                    if (ads.Tables[0].Rows.Count > 0)
                    {                       
                        foreach (DataRow r0 in ads.Tables[0].Rows)
                        {
                            foreach (DataRow r12 in m_v.get_data_mmyy(ammyyhd, "select * from medibvmmyy.v_chidinh a,medibv.v_giavp b where a.mavp=b.id and a.done=1 and a.hide=0 and a.mavp=" + ((r0["mavp"].ToString()!="")?r0["mavp"].ToString():"0") + " and maql=" + r0["maql"].ToString() + " and mabn='" + r0["mabn"].ToString() + "'").Tables[0].Rows)
                            {
                                s_amavp = r12["ten"].ToString();
                                s_tenvp += "- " + s_amavp + "\n";
                            }
                        }
                        if (s_tenvp != "" && tmn_MienHoadon.Checked == false && arv["loaihd"].ToString() != "3")
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Các dịch vụ này bệnh nhân đã làm không hoàn trả được!")+" \n" + s_tenvp + "", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        DataRow r = ads.Tables[0].Rows[0];
                        if (m_v.dahoantra(r["mabn"].ToString(), r["mavaovien"].ToString(), r["maql"].ToString(), r["quyenso"].ToString(), r["sobienlai"].ToString(), r["loai"].ToString(), r["loaibn"].ToString()))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả rồi, không được hoàn trả nữa!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý hoàn trả hoá đơn này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            //xuat vien                        
                            m_v.execute_data("update medibv.xuatvien set paid=0 where mabn='" + ads.Tables[0].Rows[0]["mabn"].ToString() + "' and maql=" + ads.Tables[0].Rows[0]["maql"].ToString());
                            //
                            decimal asotien = 0, atmp = 0;
                            if (arv["loaihd"].ToString() == "1" || arv["loaihd"].ToString() == "5")
                            {
                                foreach (DataRow r0 in ads.Tables[0].Rows)
                                {
                                    try
                                    {
                                        atmp = decimal.Parse(r0["sotienct"].ToString());
                                    }
                                    catch
                                    {
                                        atmp = 0;
                                    }
                                    asotien += atmp;
                                }
                            }
                            else
                                asotien = decimal.Parse(ads.Tables[0].Rows[0]["sotien"].ToString());
                                                            
                            aidht = m_v.upd_v_hoantra(ammyy, 0, decimal.Parse(r["quyenso"].ToString()), decimal.Parse(r["sobienlai"].ToString()), txtNgayhoan.Text.Substring(0, 10), arv["ngay"].ToString().Substring(0, 10), r["mabn"].ToString().Trim(), decimal.Parse(r["mavaovien"].ToString()), decimal.Parse(r["maql"].ToString()), r["hoten"].ToString().Trim(), r["makp"].ToString(), asotien, aghichu, decimal.Parse(m_userid), decimal.Parse(r["loai"].ToString()), decimal.Parse(aloaibn));                            
                           
                            if (aid != "")
                            {
                                m_v.upd_eve_tables(ammyy, itable, int.Parse(m_userid), "upd");
                                m_v.upd_eve_upd_del(ammyy, itable, int.Parse(m_userid), "upd", m_v.fields("medibv" + ammyy + ".v_hoantra", "id=" + aidht));
                            }
                            
                            if (aidht != "0")
                            {
                                foreach (DataRow r1 in ads.Tables[0].Rows)
                                    m_v.upd_v_hoantract(ammyy, decimal.Parse(aidht), decimal.Parse(r1["mavp"].ToString()), decimal.Parse(r1["sotienct"].ToString()));
                                if (arv["loaihd"].ToString() == "1")//TT
                                {
                                    //m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_chidinh set paid=0 where maql in(select maql from medibvmmyy.v_vienphill where id=" + aid + ") and mavp in(select mavp from medibvmmyy.v_vienphict where id=" + aid + ")");
                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_chidinh set paid=0, idttrv=0 where idttrv=" + aid + " and mavp in(select mavp from medibvmmyy.v_vienphict where id=" + aid + ")");
                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_vienphict set tra = soluong*dongia-mien-thieu,ngaytra=to_date('" + txtNgayhoan.Text.Substring(0, 10) + "','dd/MM/yyyy'),useridtra=" + m_userid + " where id=" + aid);
                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_vienphict set idtra = " + aidht + " where id=" + aid);

                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.tiepdon set done='x' where mavaovien in (select mavaovien from medibvmmyy.v_vienphill where id=" + aid + ") and madoituong in( select madoituong from medibv.doituong where mien !=1 and donvi==0 and trasau!=1)");

                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_vpkhoa set idttrv = 0, done=0 where idttrv=" + aid);
                                    m_v.execute_data(txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set idttrv = 0, done=0 where idttrv=" + aid);
                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.d_tienthuoc set idttrv = 0, done=0 where idttrv=" + aid);
                                    m_v.execute_data(txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set idttrv = 0, done=0 where idttrv=" + aid);

                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.d_thuocbhytct set idttrv = 0, paid=0 where idttrv=" + aid);
                                    m_v.execute_data(txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), "update medibvmmyy.d_thuocbhyt set idttrv = 0, done=0 where idttrv=" + aid);
                                    m_v.execute_data(txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), "update medibvmmyy.d_ngtruct set idttrv = 0 where idttrv=" + aid);
                                    m_v.execute_data(txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), "update medibvmmyy.d_ngtrull set quyenso=0,sobienlai=0,idttrv = 0 where idttrv=" + aid);

                                }
                            }
                            //
                            if (m_v.tt_phuthudonthuocBHYT(m_userid))
                            {
                                int iNgaykk = m_v.iNgaykiemke;
                                string v_tn = m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(txtTN.Text.Substring(0,10)).AddDays(-iNgaykk));
                                string v_dn = m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(txtDN.Text.Substring(0,10)).AddDays(iNgaykk));
                                m_v.execute_data(v_tn,v_dn, "update medibvmmyy.d_thuocbhytll set idtt_cl=0 where idtt_cl=" + aid);
                            }
                            //
                            if (arv["loaihd"].ToString() == "2")//TU
                            {
                                string ammyytu = m_v.get_mmyy(arv["ngay"].ToString().Substring(0, 10));
                                m_v.execute_data_mmyy(ammyytu, "update medibvmmyy.v_tamung set done=1,ngaytra=to_date('" + txtNgayhoan.Text.Substring(0, 10) + "','dd/MM/yyyy') where id=" + arv["id"].ToString());
                                m_v.execute_data("update medibv.v_tamung set done=1,ngaytra=to_date('" + txtNgayhoan.Text.Substring(0, 10) + "','dd/MM/yyyy') where id=" + arv["id"].ToString());
                                m_v.execute_data_mmyy(ammyytu, "update medibvmmyy.v_tamungcd set done=0 where idduyet=" + arv["id"].ToString());//gam 22/08/2011
                                m_v.execute_data_mmyy(m_v.get_mmyy(txtNgayhoan.Text.Substring(0,10)), "update medibvmmyy.v_tontamung set done=1 where id=" + arv["id"].ToString());
                            }
                            if (arv["loaihd"].ToString() == "3" )//TTRV
                            {
                                try
                                {
                                    if (tmn_MienHoadon.Checked == false)//binh: xet dieu kien hoàn tra thuong
                                    {
                                        string ammyyttrv = m_v.get_mmyy(arv["ngay"].ToString().Substring(0, 10));
                                        DataSet adsrv = m_v.get_data_mmyy(ammyyttrv, "select to_char(ngayvao,'dd/mm/yyyy') as ngayvao, to_char(ngayra,'dd/mm/yyyy') as ngayra, mabn, maql, mavaovien,idkhoa,id from medibvmmyy.v_ttrvds where id = " + aid);
                                        DateTime anv = m_v.f_parse_date(adsrv.Tables[0].Rows[0]["ngayvao"].ToString());
                                        DateTime anr = m_v.f_parse_date(adsrv.Tables[0].Rows[0]["ngayra"].ToString());
                                        anv = anv.AddMonths(-4);
                                        anv = anv.AddMonths(4);
                                        string anvs = anv.Day.ToString().PadLeft(2, '0') + "/" + anv.Month.ToString().PadLeft(2, '0') + "/" + anv.Year.ToString();
                                        string anrs = anr.Day.ToString().PadLeft(2, '0') + "/" + anr.Month.ToString().PadLeft(2, '0') + "/" + anr.Year.ToString();
                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.v_vpkhoa set done=0,idttrv=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and maql=" + adsrv.Tables[0].Rows[0]["maql"].ToString() + " and idttrv=" + aid + "");
                                        //khuyen them 22/03/14 m_v.execute_data(anvs, anrs, "update medibvmmyy.v_chidinh set paid=0,idttrv=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and mavaovien=" + adsrv.Tables[0].Rows[0]["mavaovien"].ToString() + " and idttrv=" + aid + "");
                                        // khuyen them 22/03/14
                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.v_chidinh set paid=0,idttrv=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and mavaovien=" + adsrv.Tables[0].Rows[0]["mavaovien"].ToString() + " and idttrv=" + aid + "");//khuyen

                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.v_thvpll set done=0,idttrv=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and maql=" + adsrv.Tables[0].Rows[0]["maql"].ToString() + " and idttrv=" + aid + "");
                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.v_thvpct set done=0,idttrv=0 where idttrv=" + aid + "");
                                        m_v.execute_data("update medibv.v_tamung set done=0,idttrv=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and idttrv=" + aid + "");
                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.v_tamung set done=0,idttrv=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and idttrv=" + aid + "");
                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.v_tontamung set done=0,idttrv=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and idttrv=" + aid + "");
                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.d_tienthuoc set done=0,idttrv=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and mavaovien=" + adsrv.Tables[0].Rows[0]["mavaovien"].ToString() + " and idttrv=" + aid + "");
                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.bhytkb set quyenso=0,sobienlai=0 where mabn='" + adsrv.Tables[0].Rows[0]["mabn"].ToString() + "' and quyenso=" + r["quyenso"].ToString() + " and sobienlai =" + r["sobienlai"].ToString() + "");
                                        m_v.execute_data(anvs, anrs, "update medibvmmyy.d_ngtruct set idttrv=0 where idttrv=" + aid + "");

                                        m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_ttrvct set tra = soluong*dongia,ngaytra=to_date('" + txtNgayhoan.Text.Substring(0, 10) + "','dd/MM/yyyy') where id=" + aid);//binh                                        
                                        m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_ttrvct set idtra = " + aidht + " where id=" + aid);//binh                                        
                                        foreach (DataRow r0 in m_v.get_data("select distinct idtonghop from " + m_v.user + ammyyhd + ".v_ttrvct where id=" + aid).Tables[0].Rows)
                                        {
                                            m_v.execute_data(anvs, anrs, "update medibvmmyy.bhytkb set quyenso=0,sobienlai=0 where id=" + Math.Abs(decimal.Parse(r0["idtonghop"].ToString())));
                                            //break;
                                        }                                           
                                    }
                                    else //Binh: bien lai ra roi, BGD duyet mien hoa don nay
                                    {
                                        m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_ttrvct set tra = soluong*dongia where id=" + aid);
                                    }
                                }
                                catch
                                {
                                }
                            }
                            f_Load_DG_Hoan();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void tmn_Hoanchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                string aid = "", ammyyhd = "";
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                aid = arv["id"].ToString();
                m_mabn = arv["mabn"].ToString();
                m_mavaovien = arv["mavaovien"].ToString();
                ammyyhd = m_v.get_mmyy(arv["ngay"].ToString().Substring(0, 10));
                DateTime angaythu = m_v.f_parse_date(arv["ngay"].ToString().Substring(0, 10));
                if (angaythu > txtNgayhoan.Value)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Ngày hoàn trả phải >= ") + arv["ngay"].ToString().Substring(0, 10) + " !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (aid != "")
                {
                    switch (arv["loaihd"].ToString())
                    {
                        case "1"://TT                            
                            if (!m_v.tt_hoanhoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền hoàn trả hoá đơn thu trực tiếp.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            else
                            {
                                if (m_frmhoantract == null)
                                {
                                    m_frmhoantract = new frmHoantract(m_v, m_userid,m_mabn,m_mabn, m_mavaovien);
                                }
                                m_frmhoantract.ShowInTaskbar = false;
                                m_frmhoantract.s_id = aid;
                                m_frmhoantract.s_mmyy = ammyyhd;
                                m_frmhoantract.s_loai = "1";
                                m_frmhoantract.s_ngayhoan = txtNgayhoan.Text.Substring(0, 10);
                                m_frmhoantract.s_kyhieu = lan.Change_language_MessageText("Ký hiệu:") + " " + arv["sohieu"].ToString();
                                m_frmhoantract.s_sobienlai = lan.Change_language_MessageText("Số hoá đơn:") + " " + arv["sobienlai"].ToString();
                                m_frmhoantract.s_ngayhd = lan.Change_language_MessageText("Ngày hoá đơn:") + " " + arv["ngay"].ToString();
                                m_frmhoantract.s_benhnhan = lan.Change_language_MessageText("Mã BN:") + " " + arv["mabn"].ToString() + lan.Change_language_MessageText(" - Họ và tên:") + " " + arv["hoten"].ToString() + " " + lan.Change_language_MessageText("- Năm sinh:") + " " + arv["namsinh"].ToString();
                                m_frmhoantract.s_diachi = lan.Change_language_MessageText("Địa chỉ:") + " " + arv["diachi"].ToString();
                                m_frmhoantract.s_nhanvien = lan.Change_language_MessageText("Nhân viên thu ngân:") + " " + arv["hoten_nv"].ToString();
                                m_frmhoantract.ShowDialog();
                            }
                            break;
                        case "3":  //TTRV
                            if (!m_v.ttrv_hoanhoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền hoàn trả hoá đơn thu chi ra viện.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            else
                            {
                                if (m_frmhoantract == null)
                                {
                                    m_frmhoantract = new frmHoantract(m_v, m_userid,m_mabn,m_mavaovien,m_ngay);
                                }
                                m_frmhoantract.ShowInTaskbar = false;
                                m_frmhoantract.s_id = aid;
                                m_frmhoantract.s_mmyy = ammyyhd;
                                m_frmhoantract.s_loai = "3";
                                m_frmhoantract.s_ngayhoan = txtNgayhoan.Text.Substring(0, 10);
                                m_frmhoantract.s_kyhieu = lan.Change_language_MessageText("Ký hiệu:") + " " + arv["sohieu"].ToString();
                                m_frmhoantract.s_sobienlai = lan.Change_language_MessageText("Số hoá đơn:") + " " + arv["sobienlai"].ToString();
                                m_frmhoantract.s_ngayhd = lan.Change_language_MessageText("Ngày hoá đơn:") + " " + arv["ngay"].ToString();
                                m_frmhoantract.s_benhnhan = lan.Change_language_MessageText("Mã BN:") + " " + arv["mabn"].ToString() + lan.Change_language_MessageText(" - Họ và tên:") + " " + arv["hoten"].ToString() + " " + lan.Change_language_MessageText("- Năm sinh:") + " " + arv["namsinh"].ToString();
                                m_frmhoantract.s_diachi = lan.Change_language_MessageText("Địa chỉ:") + " " + arv["diachi"].ToString();
                                m_frmhoantract.s_nhanvien = lan.Change_language_MessageText("Nhân viên thu ngân:") + " " + arv["hoten_nv"].ToString();
                                m_frmhoantract.ShowDialog();
                            }
                            break;
                        default:
                            MessageBox.Show(this, lan.Change_language_MessageText("Chỉ được hoàn trả chi tiết đối với hoá đơn thu trực tiếp !"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            break;
                    }
                }
                f_Load_DG_Hoan();
            }
            catch
            {
            }
        }


        private void frmHoantrathutructiep_Load(object sender, EventArgs e)
        {
            itable = m_v.tableid(m_v.get_mmyy(txtNgayhoan.Text.Substring(0, 10)), "v_hoantra");
            i_maxlength_mabn = LibVP.AccessData.i_maxlength_mabn;
            //string s_mask = "000000";
            //txtMabn1.Mask = s_mask.PadLeft(i_maxlength_mabn - 2, '0');
            //
            f_capnhat_db();//
            //
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            if (txtSobienlai.Text != "")
            {
                f_Load_DG();
            }
            f_Load_DG_Hoan();
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

        private void frmHoantrathutructiep_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
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
                if (atmp.Trim() != lan.Change_language_MessageText("Tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "mabn like '%" + atmp + "%' or hoten like '%" + atmp + "%' or namsinh like '%" + atmp + "%' or ngay like '%" + atmp + "%' or sohieu like '%" + atmp + "%' or diachi like '%" + atmp + "%' or sbl like '%" + atmp + "%' or ghichu like '%" + atmp + "%'";
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
                    if (txtMabn.Text.Length == 2 && txtMabn1.Text.Length == i_maxlength_mabn-2)
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
                m_v.set_o_limit_frmhoantra(m_userid, txtLimit.Value.ToString());
            }
            catch
            {
            }
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
                m_v.set_o_fullgrid_frmhoantra(m_userid, tmn_Fullgrid.Checked);
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

        private void txtNgayhoan_KeyDown(object sender, KeyEventArgs e)
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

        private void txtHT_TN_KeyDown(object sender, KeyEventArgs e)
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

        private void txtHT_DN_KeyDown(object sender, KeyEventArgs e)
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

        private void butHT_Xem_Click(object sender, EventArgs e)
        {
            f_Load_DG_Hoan();
        }
        private void txtHT_TN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtHT_TN.Value > txtHT_DN.Value)
                {
                    txtHT_DN.Value = txtHT_TN.Value;
                }
            }
            catch
            {
            }
        }

        private void txtHT_DN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtHT_DN.Value < txtHT_TN.Value)
                {
                    txtHT_TN.Value = txtHT_DN.Value;
                }
            }
            catch
            {
            }
        }

        private void tmn_Xemtruockhiin_Click(object sender, EventArgs e)
        {
            m_v.set_o_preview_frmhoantra(m_userid, tmn_Xemtruockhiin.Checked);
        }

        private void tmn_Luuin_Hoan_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_frmhoantra(m_userid, tmn_Luuin_Hoan.Checked);
        }

        private void tmn_HT_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (!m_v.ht_phuchoihoatra(m_userid))
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền phục hồi hoá đơn hoàn trả.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string aid = "", ammyy = "",sql="";
                DataRowView arv = (DataRowView)(dgHoan.CurrentRow.DataBoundItem);
                aid = arv["id"].ToString();
                ammyy = m_v.get_mmyy(arv["ngay"].ToString());
                if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý phục hồi hóa đơn hoàn trả này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {    
                    //son web 18/10/2007                    
                    if (aid != "")
                    {
                        string s = m_v.fields("medibv" + ammyy + ".v_hoantra", "id=" + aid);
                        m_v.upd_eve_tables(ammyy, itable, int.Parse(m_userid), "del");
                        m_v.upd_eve_upd_del(ammyy, itable, int.Parse(m_userid), "del", s);
                    } 
                    if (arv["loaihd"].ToString() == "1")
                    {
                        try
                        {
                            string auserroot = m_v.s_schemaroot, ammyyhd = m_v.get_mmyy(arv["ngaythu"].ToString()), aidhd = "";
                            aidhd = decimal.Parse(m_v.get_data_mmyy(ammyyhd, "select id from medibvmmyy.v_vienphill where mabn='" + arv["mabn"].ToString().Trim() + "' and maql=" + decimal.Parse(arv["maql"].ToString()).ToString() + " and quyenso=" + decimal.Parse(arv["quyenso"].ToString()).ToString() + " and sobienlai=" + decimal.Parse(arv["sobienlai"].ToString()).ToString() + " and loai=" + decimal.Parse(arv["loai"].ToString()).ToString() + " and to_char(ngay,'dd/mm/yyyy')='" + arv["ngaythu"].ToString() + "'").Tables[0].Rows[0][0].ToString()).ToString();
                            sql = "update " + auserroot + ammyyhd + ".v_vienphict set tra=0 where id=" + aidhd + " and mavp in (select loaivp from " + auserroot + ammyy + ".v_hoantract where id=" + aid + ")";
                            m_v.execute_data(sql);
                            sql = "update " + auserroot + ammyyhd + ".v_vienphict set tra=0, idtra=0 where id=" + aidhd + " and idtra=" + aid;
                            m_v.execute_data(sql);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    if (arv["loaihd"].ToString() == "2")
                    {
                        try
                        {
                            string auserroot = m_v.s_schemaroot, ammyyhd = m_v.get_mmyy(arv["ngaythu"].ToString());
                            m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_tamung set ngaytra=null where mabn='" + arv["mabn"].ToString().Trim() + "' and maql=" + decimal.Parse(arv["maql"].ToString()).ToString() + " and quyenso=" + decimal.Parse(arv["quyenso"].ToString()).ToString() + " and sobienlai=" + decimal.Parse(arv["sobienlai"].ToString()).ToString() + " and loai=" + decimal.Parse(arv["loai"].ToString()).ToString() + " and to_char(ngay,'dd/mm/yyyy')='" + arv["ngaythu"].ToString() + "'");
                            m_v.execute_data("update medibv.v_tamung set ngaytra=null where mabn='" + arv["mabn"].ToString().Trim() + "' and maql=" + decimal.Parse(arv["maql"].ToString()).ToString() + " and quyenso=" + decimal.Parse(arv["quyenso"].ToString()).ToString() + " and sobienlai=" + decimal.Parse(arv["sobienlai"].ToString()).ToString() + " and loai=" + decimal.Parse(arv["loai"].ToString()).ToString() + " and to_char(ngay,'dd/mm/yyyy')='" + arv["ngaythu"].ToString() + "'");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    if (arv["loaihd"].ToString() == "3")
                    {
                        try
                        {
                            string auserroot = m_v.s_schemaroot, ammyyhd = m_v.get_mmyy(arv["ngaythu"].ToString()), aidhd = "";
                            aidhd = decimal.Parse(m_v.get_data_mmyy(ammyyhd, "select a.id from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id where a.mabn='" + arv["mabn"].ToString().Trim() + "' and a.maql=" + decimal.Parse(arv["maql"].ToString()).ToString() + " and b.quyenso=" + decimal.Parse(arv["quyenso"].ToString()).ToString() + " and b.sobienlai=" + decimal.Parse(arv["sobienlai"].ToString()).ToString() + " and b.loai=" + decimal.Parse(arv["loai"].ToString()).ToString() + " and to_char(b.ngay,'dd/mm/yyyy')='" + arv["ngaythu"].ToString() + "'").Tables[0].Rows[0][0].ToString()).ToString();
                            sql = "update " + auserroot + ammyyhd + ".v_ttrvct set tra=0 where id=" + aidhd + " and mavp in (select loaivp from " + auserroot + ammyy + ".v_hoantract where id=" + aid + ")";                            
                            m_v.execute_data(sql);
                            sql = "update " + auserroot + ammyyhd + ".v_ttrvct set tra=0,idtra=0 where id=" + aidhd + " and idtra=" + aid;
                            m_v.execute_data(sql);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    sql = "delete from medibvmmyy.v_hoantract where id=" + aid;
                    m_v.execute_data_mmyy(ammyy, sql);
                    sql = "delete from medibvmmyy.v_hoantra where id=" + aid;
                    m_v.execute_data_mmyy(ammyy, sql);
                    f_Load_DG_Hoan();
                }
            }
            catch
            {
            }
        }

        private void tmnHT_Inhd_Click(object sender, EventArgs e)
        {
            try
            {
                string aid="",ngayht="";
                DataRowView arv = (DataRowView)(dgHoan.CurrentRow.DataBoundItem);
                aid = arv["id"].ToString();
                m_mabn = arv["mabn"].ToString();
                ngayht = arv["ngay"].ToString();
                if (tmn_InChiTietHoaDon.Checked)
                {
                    frmInhoantra.f_Print_PhieuChi_Hoantra_Chitiet(!tmn_Xemtruockhiin.Checked, aid, m_v.get_mmyy(ngayht.Substring(0, 10)));
                }
                else
                {
                    frmInhoantra.f_Print_PhieuChi_Hoantra(!tmn_Xemtruockhiin.Checked, aid, m_v.get_mmyy(ngayht.Substring(0, 10)));
                }
            }
            catch
            {
            }
        }

        private void tmnHT_Inds_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }

        private void tmnHT_Excel_Click(object sender, EventArgs e)
        {
            try
            {
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
                    txtMabn1.Text = txtMabn1.Text.Trim().PadLeft(6, '0');//.PadLeft(6, '0');
                }
            }
            catch
            {
                txtMabn1.Text = "";
            }
        }

        private void tmn_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DG_Hoan();
        }

        private void f_capnhat_db()
        {
            string asql = "alter table medibvmmyy.v_ttrvct add idtra numeric(18) default 0";
            m_v.execute_data(txtTN.Text, txtDN.Text, asql,false);
            asql = "alter table medibvmmyy.v_vienphict add idtra numeric(18) default 0";
            m_v.execute_data(txtTN.Text, txtDN.Text, asql,false);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            f_capnhat_db();
            Cursor = Cursors.WaitCursor;
        }

        private void dgHoadon_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void txtMabn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "0123456789\b".IndexOf(e.KeyChar) == -1;
        }


        
    }
}