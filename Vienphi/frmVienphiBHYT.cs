using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmVienphiBHYT : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private string s_idthutamung = "", s_idbhytkb = "";
        private string m_cur_yy = "";
        private string m_id_gia = "";
        private string s_bhyt_chieudai = "";
        private string s_bhyt_kytu = "";
        private string s_bhyt_vitri = "";
        private decimal d_bhyt_sotien = 0;
        private DateTime m_cur_ngay = DateTime.Now;
        private string m_cur_loaidv = "";
        private string m_sohieu = "";
        private string m_cur_quyenso = "";
        private string s_mavp_congkham = "";
        private string m_doituongmien = "", m_doituongthu = "";
        private string v_tachhoadon_dv = "";//tách biên lai theo đối tượng
        private string v_tachbienlai_dv = "";//tách biên lai theo nhóm viện phí
        private bool b_sua = false, b_huykembldv = false;// b_huykenbldv neu gia tri bằng true thì khi huy bien lai 
        //tự động hủy luôn biên lai đã được tách ( nếu có ) option in hoa don dich vu
        private bool bGiaban = false;
        private bool b_upd_bhytkb = false, m_Docmavach = false;
        private bool b_datinh_cpvc = false,bQuanly_Theo_Chinhanh = false;
        private int i_maxlength_mabn = 8;
        private bool bKhongchoxem_tongthu = false, bChithuBNChuaVuotNguong = false, bBHYTThu_BNChiquatiepdon = false;
        private TableLayoutPanel m_table;
        //private LibBaocao.AccessData lib_bc = new LibBaocao.AccessData();
        private LibVP.AccessData m_v;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private DataSet m_dshoadon, m_dstamung, dsqs;
        private DataTable dtdm = new DataTable();
        private string m_id = "", m_mavaovien = "", m_maql = "", m_userid = "", m_maql_tiepdon = "", s_matunguyen = "", m_sobienlai = "";
        private DataSet m_dsgiavp;
        private DataSet m_dsnhomvp;
        private DataSet m_dsloaivp;

        private string m_id_toathuocbhyt = "", v_dongiabhyt = "";
        private decimal zsotien_datra = 0, zbhyt_datra = 0, zmien_datra = 0, zbntra_datra = 0, ztamung_datra=0;
        private bool bDuyet_khambenh = false;
        private bool bDuyet_donvepl = false;
        private bool CongthucTraiTuyen160212 = false;
        private bool bbhyt_100_theodoibienlai = false;
        private bool BHYTThu_nhacnho_ThuDichvu_tuchitra = false;


        private frmChonvp m_frmchonvp;
        //private frmDanhsachBHYT m_frmdanhsachBHYT;
        //private frmDanhsachchoBHYT m_frmdanhsachchoBHYT;
        //private frmTimhoadon m_frmtimhoadon;
        //private frmTimbenhnhan m_frmtimbenhnhan;
        //private frmHoantra m_frmhoantra;
        private frmPrintHD m_frmprinthd;
        private bool m_bnmoi = false, thutheongay = false, thutheodot_mavaovien = false, v_loadcho = false, bTunguyen, bBatbuoc, b_bhyt_100_theodoibienlai = false;
        private bool b_hddathu = false;
        private int itablekb, itablethuoc, itablecls, itablebhyt, itableds, itablettrvbhyt, itablect, itablell, iTunguyen, traituyen = 0, iTraituyen, iSothang=1;
        private decimal dBhyt_Chitra_Toida_7CN = 0;
        private bool m_o_fullscreen = false, bChenhlech_thuoc_vattu = false, bGia_bh_quydinh = false, bGia_bh_quydinh_giamua = false, bChenhlech = false, bChenhlech_thuoc_dannhmuc = false, v_bhyt_suanoidunghoadon;
        private bool bThuchenhlechtruoc_duyettoasau=false, bLaygiamua_khi_giabh_0_giabh_nho_giamua =true ;
        private decimal lTraituyen=0;
        private string v_solanin = "1", m_cur_quyenso_dichvu = "";
        private int i_tylechinhsach = 0;
        
        public frmVienphiBHYT(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();

                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_ContextMenuStrip_to_Xml(this.Name.ToString() + "_" + "contextMenuStrip1", contextMenuStrip1);
                lan.Change_ContextMenuStrip_to_English(this.Name.ToString() + "_" + "contextMenuStrip1", contextMenuStrip1);

                m_v = v_v;
                m_userid = v_userid;
                m_v.f_SetEvent(pHanhchanh);
                m_v.f_SetEvent(panel1);
                f_Load_Data();
                dgGia.Visible = false;                
                m_o_fullscreen = m_v.get_o_fullscreen_frmvienphiBHYT(m_userid);
                
            }
            catch
            {
            }
        }
        public string s_loaidv
        {
            set
            {
                try
                {
                    cbLoaidv.SelectedValue = value;
                    m_cur_loaidv = value;
                }
                catch
                {
                }
            }
        }
        public string s_quyenso
        {
            set
            {
                try
                {
                    cbKyhieu.SelectedValue = value;
                    m_cur_quyenso = value;
                }
                catch
                {
                }
            }
        }
        public string s_quyenso_dichvu
        {
            set
            {
                try
                {
                    m_cur_quyenso_dichvu = value;
                }
                catch
                {
                }
            }
            get
            {
                return m_cur_quyenso_dichvu;
            }
        }
        public string s_ngay
        {
            set
            {
                try
                {
                    txtNgaythu.Value = m_v.f_parse_date_16(value);
                    m_cur_ngay = txtNgaythu.Value;
                }
                catch
                {
                }
            }
        }
        //son w them de quan ly the BHYT moi.
        private string f_Load_Bhyt_Chieudai()
        {
            try
            {

                return (m_v.get_data("select dai from medibv.doituong where madoituong=1").Tables[0].Rows[0][0].ToString());
            }
            catch { return "-1"; };
        }
        private string f_Load_Bhyt_Kytu()
        {
            return m_v.get_ma13 + m_v.get_ma16 + m_v.get_ma16_95;
            //try
            //{
            //    return (m_v.get_data("select ten from medibv.thongso where id=50 ").Tables[0].Rows[0][0].ToString());
            //}
            //catch { return "-1"; };
        }
        private string f_Load_Bhyt_Vitri()
        {
            try
            {
                return (m_v.get_data("select ten from medibv.d_thongso where id=53 and nhom=1 ").Tables[0].Rows[0][0].ToString());
            }
            catch { return "-1"; };
        }
        private string f_Load_Bhyt_Sotien()
        {
            try
            {
                return (m_v.get_data("select ten from medibv.d_thongso where id=51 and nhom=1 ").Tables[0].Rows[0][0].ToString());
            }
            catch { return "-1"; };
        }
        //End.
        private void frmVienphiBHYT_Load(object sender, EventArgs e)
        {            
            //
            try
            {
                //m_v.tao_view();
                m_Docmavach = m_v.tt_Quanlymavach(m_userid);
                i_maxlength_mabn = LibVP.AccessData.i_maxlength_mabn;
                if (m_Docmavach)
                {
                    txtMabn.MaxLength = i_maxlength_mabn;
                    txtMabn1.MaxLength = i_maxlength_mabn;
                }
                bQuanly_Theo_Chinhanh = m_v.bQuanly_Theo_Chinhanh;
                iTunguyen = m_v.iTunguyen; cmbTraituyen.SelectedIndex = 0;
                lTraituyen = (m.bTraituyen) ? m.lTraituyen_phongkham : 0;
                iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
                s_bhyt_chieudai = f_Load_Bhyt_Chieudai().ToString().Trim().Trim(',') + ",";
                s_bhyt_kytu = f_Load_Bhyt_Kytu().ToString().Trim().Trim('+') + "+";
                s_bhyt_vitri = f_Load_Bhyt_Vitri().ToString().Trim();
                m_doituongthu = m_v.bhyt_chithudoituong(m_userid);
                d_bhyt_sotien = decimal.Parse(f_Load_Bhyt_Sotien().ToString().Trim());
                v_solanin = m_v.sys_solanin;
                bKhongchoxem_tongthu = m_v.sys_khongchoxem_tongthu == "1";
                v_tachhoadon_dv = m_v.bhyt_tachhoadon_dichvu(m_userid);
                v_tachbienlai_dv = m_v.bhyt_bienlai_dichvu(m_userid);
                v_bhyt_suanoidunghoadon = m_v.bhyt_suanoidunghoadon(m_userid);
                bDuyet_donvepl = m.bDuyet_donvepl;
                bDuyet_khambenh = m.bDuyet_khambenh;
                CongthucTraiTuyen160212 = m.CongthucTraiTuyen160212;
                bThuchenhlechtruoc_duyettoasau = m_v.bThuchenhlechtruoc_duyettoasau(m.nhom_duoc);
                bbhyt_100_theodoibienlai = m_v.bhyt_100_theodoibienlai(m_userid);
                BHYTThu_nhacnho_ThuDichvu_tuchitra = m_v.BHYTThu_nhacnho_ThuDichvu_tuchitra(m_userid);
                try
                {
                    iSothang = int.Parse(m_v.sys_sothang);
                }
                catch { iSothang = 1;  }
                dtdm = m_v.get_data("select id,gia_bh from " + m_v.user + ".d_dmbd where hide=0 and bhyt>0 union all select id,gia_bh from " + m_v.user + ".v_giavp where hide=0 and bhyt>0").Tables[0];
                itablekb = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "bhytkb");
                itablethuoc = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "bhytthuoc");
                itablecls = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "bhytcls");
                itablebhyt = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "bhyt");

                itableds = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_ttrvds");
                itablettrvbhyt = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_ttrvbhyt");
                itablect = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_ttrvct");
                itablell = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_ttrvll");

                bLaygiamua_khi_giabh_0_giabh_nho_giamua = m.bLaygiamua_khi_giabh_0_giabh_nho_giamua;
                bChithuBNChuaVuotNguong = m_v.ChiThuBNChuaVuotNguong(m_userid);
                bBHYTThu_BNChiquatiepdon = m_v.BHYTThu_BNChiquatiepdon(m_userid);
                if(m_v.bhyt_suanoidunghoadon(m_userid )==false) dgHoadon.ReadOnly = true;
                string tmp_qso = m_cur_quyenso;
                lbKyhieu_Click(null, null);
                s_quyenso = tmp_qso;
                f_Load_Thutrongngay();
                f_Load_DG();
                f_Load_Hotkey();
                f_Load_Tonghop();
                f_Enable(false);                
                this.Refresh();
                txtSobienlai.ReadOnly = true;
                if (cbKyhieu.Items.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Phải khai báo quyển sổ thu viện phí trước!") + "\n" + lan.Change_language_MessageText("Vào [Tiện ích] - [Khai báo quyển sổ] để khai!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                }
                cbLoaidv_SelectedIndexChanged(null, null);
                dgHoadon.AutoGenerateColumns = false;
                butMoi_Click(null, null);
            }
            catch
            {
            }
        }

        #region key
        private void f_Load_Hotkey()
        {
            try
            {
                tmn_F1.Enabled = false;
                tmn_F2.Enabled = false;
                tmn_F3.Enabled = false;
                tmn_F5.Enabled = false;
                tmn_F6.Enabled = false;
                tmn_F7.Enabled = false;
                tmn_F8.Enabled = false;
                tmn_F9.Enabled = false;
                tmn_F11.Enabled = false;
                tmn_F12.Enabled = false;

                tmn_F1.Text = "F1";
                tmn_F2.Text = "F2";
                tmn_F3.Text = "F3";
                tmn_F5.Text = "F5";
                tmn_F6.Text = "F6";
                tmn_F7.Text = "F7";
                tmn_F8.Text = "F8";
                tmn_F9.Text = "F9";
                tmn_F11.Text = "F11";
                tmn_F12.Text = "F12";

                string atable = tmn_Hotkey_KSK_Show.Checked ? "_ksk" : "";
                foreach (DataRow r in m_v.get_data("select distinct hotkey, ghichu from medibv.v_optionhotkey" + atable + " where userid=" + m_userid + " and loai=3").Tables[0].Rows)
                {
                    if (r["hotkey"].ToString() == "F1")
                    {
                        tmn_F1.Text = "F1 - " + r["ghichu"].ToString().Trim();
                        tmn_F1.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F2")
                    {
                        tmn_F2.Text = "F2 - " + r["ghichu"].ToString().Trim();
                        tmn_F2.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F3")
                    {
                        tmn_F3.Text = "F3 - " + r["ghichu"].ToString().Trim();
                        tmn_F3.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F5")
                    {
                        tmn_F5.Text = "F5 - " + r["ghichu"].ToString().Trim();
                        tmn_F5.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F6")
                    {
                        tmn_F6.Text = "F6 - " + r["ghichu"].ToString().Trim();
                        tmn_F6.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F7")
                    {
                        tmn_F7.Text = "F7 - " + r["ghichu"].ToString().Trim();
                        tmn_F7.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F8")
                    {
                        tmn_F8.Text = "F8 - " + r["ghichu"].ToString().Trim();
                        tmn_F8.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F9")
                    {
                        tmn_F9.Text = "F9 - " + r["ghichu"].ToString().Trim();
                        tmn_F9.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F11")
                    {
                        tmn_F11.Text = "F11 - " + r["ghichu"].ToString().Trim();
                        tmn_F11.Enabled = true;
                        continue;
                    }
                    if (r["hotkey"].ToString() == "F12")
                    {
                        tmn_F12.Text = "F12 - " + r["ghichu"].ToString().Trim();
                        tmn_F12.Enabled = true;
                        continue;
                    }
                }
            }
            catch
            {
            }
            tt_Hotkey.Visible = tmn_Show_Hotkey.Checked;
        }
        #endregion

        private void f_Display()
        {
            try
            {
                dgGia.Width = dgHoadon.Width;
                dgGia.Height = 104;
                dgGia.Width = dgHoadon.Width - 1;
                dgGia.Left = panel3.Left + dgHoadon.Left + 11;
                dgGia.Top = panel3.Top + panel3.Height - dgGia.Height - panel1.Height - 12;

                cbKyhieu.DropDownWidth = txtSobienlai.Right - cbKyhieu.Left;
            }
            catch
            {
            }
        }
        private void f_Load_Data()
        {
            try
            {
                tmn_Dungchungso.Checked = m_v.sys_dungchungso;
                tmn_Dungchungso.Enabled = false;

                bool asys_suatuychon = m_v.sys_quyen_suatuychon(m_userid);
                tmn_Cokhambenh.Enabled = asys_suatuychon;
                tmn_Cophongluu.Enabled = asys_suatuychon;
                tmn_Conhanbenh.Enabled = asys_suatuychon;

                tmn_Cokhambenh.Checked = m_v.bhyt_cokhambenh(m_userid);
                tmn_Cophongluu.Checked = m_v.bhyt_conamluu(m_userid);
                tmn_Conhanbenh.Checked = m_v.bhyt_conhanbenh(m_userid);
                tmn_conamngoaitru.Checked = m_v.bhyt_conamngoaitru(m_userid);
                bTunguyen = m_v.bhyt_tunguyen(m_userid);
                bBatbuoc = m_v.bhyt_batbuoc(m_userid);
                s_matunguyen = m_v.get_ma13 + m_v.get_ma16 + m_v.get_ma16_95;
                //Chenh lech thuoc BHYT
                //
                //bChenhlech_thuoc_vattu = m_v.bChenhlech_thuoc;
                bChenhlech = m.bChenhlech;
                bChenhlech_thuoc_vattu = (m.bChenhlech) ? m.bChenhlech_thuoc : false;
                bChenhlech_thuoc_dannhmuc = (bChenhlech_thuoc_vattu) ? m.bChenhlech_thuoc_dannhmuc : false;
                //
                bGia_bh_quydinh = m_v.bGia_bh_quydinh;
                bGia_bh_quydinh_giamua = m_v.bGia_bh_quydinh_giamua;
                //End
                s_mavp_congkham = m_v.sys_mavp_congkhamBHYT;
                dBhyt_Chitra_Toida_7CN = m_v.Bhyt_Chitra_7cn;

                string sql = "";
                string atmp = m_v.s_curmmyyyy;
                DataSet ads;

                m_cur_ngay = m_v.f_parse_date(atmp);
                m_cur_yy = m_cur_ngay.Year.ToString().Substring(2);
                thutheongay = m_v.bhyt_thutheongay(m_userid);
                thutheodot_mavaovien = m_v.bhyt_thutheodot_mavaovien(m_userid);

                ads = m_v.get_data("select makp,tenkp from medibv.btdkp_bv order by loai, tenkp");
                cbKhoavv.DataSource = ads.Tables[0].Copy();
                cbKhoavv.DisplayMember = "tenkp";
                cbKhoavv.ValueMember = "makp";

                cbBacsi.DataSource = ads.Tables[0].Copy();
                cbBacsi.DisplayMember = "tenkp";
                cbBacsi.ValueMember = "makp";

                sql = "select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong ";
                if(m_doituongthu.Trim().Trim(',')=="") sql+=" where madoituong=1 or mien=1 ";
                else sql += " where madoituong=1 or mien=1 or madoituong in(" + m_doituongthu.Trim().Trim(',') + ")"; 
                sql += " order by madoituong ";
                //ads = m_v.get_data("select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong where madoituong=1 or mien=1 order by madoituong");
                ads = m_v.get_data(sql);//"select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong order by madoituong");
                cbDoituongTD.DataSource = ads.Tables[0].Copy();
                cbDoituongTD.DisplayMember = "doituong";
                cbDoituongTD.ValueMember = "madoituong";

                m_doituongmien = "";
                foreach (DataRow r1 in ads.Tables[0].Select("mien=1 and madoituong<>1"))
                {
                    m_doituongmien += ",";
                    m_doituongmien += r1["madoituong"].ToString();
                }
                m_doituongmien += ",";

                cbLoaidv.DataSource = m_v.get_data("select ma,ten from medibv.v_tenloaivp order by ma").Tables[0];
                cbLoaidv.DisplayMember = "ten";
                cbLoaidv.ValueMember = "ma";

                sql = "select id,sohieu,loai,userid,* from medibv.v_quyenso ";
                if (!tmn_Dungchungso.Checked)
                {
                    sql += " where userid = " + m_userid;
                }
                sql += " order by ngayud desc";
                dsqs = m_v.get_data(sql);//gam 28/09/2011
                cbKyhieu.DataSource = dsqs.Tables[0];
                cbKyhieu.DisplayMember = "sohieu";
                cbKyhieu.ValueMember = "id";
                
                

                cbLoaibn.DataSource = m_v.get_data("select id,ten from medibv.v_loaibn order by id").Tables[0];
                cbLoaibn.DisplayMember = "ten";
                cbLoaibn.ValueMember = "id";

                cbGioitinh.DataSource = m_v.get_data("select ma,ten from medibv.dmphai order by ma desc").Tables[0];
                cbGioitinh.DisplayMember = "ten";
                cbGioitinh.ValueMember = "ma";

                ads = m_v.get_data("select ma,hoten from medibv.dmbs order by hoten");
                cbBacsi.DataSource = ads.Tables[0];
                cbBacsi.DisplayMember = "hoten";
                cbBacsi.ValueMember = "ma";
                txtBacsi.Text = "";

                cbTuoi.DataSource = m_v.f_get_dmtuoi().Tables[0];
                cbTuoi.DisplayMember = "ten";
                cbTuoi.ValueMember = "id";

                sql = "select id,ma,ten,dvt,gia_th,gia_bh,gia_dv,gia_nn,gia_cs,bhyt from medibv.v_giavp order by ten";
                dgGia.DataSource = m_v.get_data(sql).Tables[0];

                m_dsgiavp = m_v.get_data("select a.id, case when b.id_nhom is null then 0 else b.id_nhom end as id_nhom,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.bhyt, case when a.ndm is null then 0 else a.ndm end as ndm, 0 as loaigia, a.bhyt_tt,a.sothe from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id union all select a1.id,case when b1.nhomvp is null then 0 else b1.nhomvp end as id_nhom,a1.ma,a1.ten || case when trim(a1.tenhc)='' then '' else '[' || trim(a1.tenhc) || ']' end as ten ,a1.dang as dvt, a1.giaban as gia_th, a1.giaban as gia_bh, a1.giaban as gia_dv,a1.giaban as gia_nn, a1.giaban as gia_cs, a1.bhyt,0 as ndm, 1 as loaigia, a1.bhyt as bhyt_tt,'' as sothe from medibv.d_dmbd a1 inner join medibv.d_dmnhom b1 on a1.manhom=b1.id where b1.nhom=1 order by ten");//gam 16/08/2011
                m_dsnhomvp = m_v.get_data("select ma as id, stt, ten,viettat, to_number(0,'9') as sotien from medibv.v_nhomvp order by stt, ten");
                m_dsloaivp = m_v.get_data("select id,stt,ten,viettat,id_nhom,to_number(0,'9') as sotien from medibv.v_loaivp order by stt, ten");

                sql = "select to_char(now(),'') as ma, to_char(now(),'') as ten,to_char(now(),'') as dvt,to_number(0,'9') as soluong, to_number(0,'9') as dongia, to_number(0,'9') as sotien, to_number(0,'9') as bhyttra,to_number(0,'9') as bntra, to_number(0,'9') as mavp, to_number(0) as madoituong,to_number(0) as dichvu";
                m_dshoadon = m_v.get_data(sql).Clone();
                //m_dshoadon.Tables[0].Rows.Clear();
                dgHoadon.DataSource = m_dshoadon.Tables[0];

                sql = "select to_number(0,'9') as chon, to_char(now(),'dd/mm/yyyy hh24:mi') as ngay, '' as sohieu, to_number(0,'9') as sobienlai,to_number(0,'9') as sotien,'' as user, to_number(0,'9') as done, to_number(0,'9') as id";
                m_dstamung = m_v.get_data(sql);
                m_dstamung.Tables[0].Rows.Clear();

                ads = m_v.get_data("select id,ten from medibv.v_lydomien order by ten asc");
                DataRow r = ads.Tables[0].NewRow();
                r["id"] = "0";
                r["ten"] = "";
                ads.Tables[0].Rows.InsertAt(r, 0);
                cbLydomien.DataSource = ads.Tables[0];
                cbLydomien.DisplayMember = "ten";
                cbLydomien.ValueMember = "id";
                txtLydomien.Text = "";

                ads = m_v.get_data("select ma,ten from medibv.v_dsduyet order by ten desc");
                r = ads.Tables[0].NewRow();
                r["ma"] = "0";
                r["ten"] = "";
                ads.Tables[0].Rows.InsertAt(r, 0);
                cbKymien.DataSource = ads.Tables[0];
                cbKymien.DisplayMember = "ten";
                cbKymien.ValueMember = "ma";
                txtKymien.Text = "";



                sql = "select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs, trim(b.ten) as tenloai,b.id as id_loai, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id order by b.ten,b.stt, b.id, a.ten,a.stt";
                m_frmchonvp = new frmChonvp(m_v, m_userid, "GIA_TH", m_v.get_data(sql), m_v.s_loaiform_bhyt);
                m_frmchonvp.s_multiline = m_v.get_o_multiline_frmchonvp(m_userid);
                m_frmchonvp.s_dshotkey = m_v.f_get_hotkey_frmvienphibhyt(m_userid);
                m_frmchonvp.s_dshotkey_ksk = m_v.f_get_hotkey_ksk_frmvienphibhyt(m_userid);
                m_frmchonvp.s_hotkey = "";
                m_frmchonvp.ShowInTaskbar = false;

                //m_frmdanhsachBHYT = new frmDanhsachBHYT(m_v, m_userid);
                //m_frmdanhsachBHYT.ShowInTaskbar = false;

                //m_frmdanhsachchoBHYT = new frmDanhsachchoBHYT(m_v, m_userid);
                //m_frmdanhsachchoBHYT.ShowInTaskbar = false;

                //m_frmtimbenhnhan = new frmTimbenhnhan(m_v, m_userid);
                //m_frmtimbenhnhan.ShowInTaskbar = false;

                //m_frmtimhoadon = new frmTimhoadon(m_v, m_userid);
                //m_frmtimhoadon.ShowInTaskbar = false;
                //m_frmtimhoadon.s_loaihd = "1";

                //m_frmhoantra = new frmHoantra(m_v, m_userid);
                //m_frmhoantra.ShowInTaskbar = false;
                //m_frmhoantra.s_loaihd = "1";

                m_frmprinthd = new frmPrintHD(m_v, m_userid);

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmvienphiBHYT(m_userid);
                f_Set_Fullgrid();

                tmn_Hotkey_Show.Checked = m_v.get_o_show_hotkey_frmvienphiBHYT(m_userid);
                tmn_Hotkey_KSK_Show.Checked = m_v.get_o_show_hotkey_ksk_frmvienphiBHYT(m_userid);
                if (tmn_Hotkey_Show.Checked && tmn_Hotkey_KSK_Show.Checked)
                {
                    tmn_Hotkey_KSK_Show.Checked = false;
                    m_v.set_o_show_hotkey_ksk_frmvienphiBHYT(m_userid, false);
                }
                tmn_Hotkey_Addall.Checked = m_v.get_o_addall_hotkey_frmvienphiBHYT(m_userid);
                tmn_Show_Hotkey.Checked = m_v.get_o_show_hotkey_toolbar_frmvienphiBHYT(m_userid);
                tt_Hotkey.Visible = tmn_Show_Hotkey.Checked;
                f_Display();

                //Option
                tmn_Luuin_Hoadon.Checked = m_v.get_o_luuin_hoadon_frmvienphiBHYT(m_userid);
                tmn_Luuin_Phieuthuchi.Checked = m_v.get_o_luuin_phieuthuphieuchi_frmvienphiBHYT(m_userid);
                tmn_Luuin_Chiphi.Checked = m_v.get_o_luuin_chiphi_frmvienphiBHYT(m_userid);
                tmn_Luuin_Hoadon_Icon.Checked = m_v.get_o_luuin_frmvienphiBHYT(m_userid);
                tmn_Xemtruockhiin_Icon.Checked = m_v.get_o_xemtruockhiin_frmvienphiBHYT(m_userid);

                tmn_Thuchidinh.Checked = m_v.bhyt_thuchidinh(m_userid);
                tmn_Toathuoctutruc.Checked = m_v.bhyt_thutoatutruc(m_userid);
                tmn_Thuocthuongquy.Checked = m_v.bhyt_thuthuocthuongquy(m_userid);
                tmn_Vienphikhoa.Checked = m_v.bhyt_thuvienphikhoa(m_userid);
                tmn_DonthuocBHYT.Checked = m_v.bhyt_thutoathuocbhyt(m_userid);
                tmn_Donthuocduocphat.Checked = m_v.bhyt_thutoathuocduocphat(m_userid);
                tmn_Khoatonghop.Checked = m_v.bhyt_thukhoatonghop(m_userid);
                b_bhyt_100_theodoibienlai = m_v.bhyt_100_theodoibienlai(m_userid);

                //gam 21/11/2011
                tmn_Nhaplydomien.Checked = m_v.bbhyt_nhaplydomien(m_userid);
                tmn_Nhapkymien.Checked = m_v.bbhyt_nhapduyetmien(m_userid);
                //end gam
                
                tmn_nhacnhokhiluu.Checked = m_v.get_o_luu_nhacnho_khiluu(m_userid);
                

            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_Data_BHYT");
            }
        }
        private void f_Load_Tonghop()
        {
            try
            {
                pTonghop.Controls.Clear();
                Label alb;
                TextBox atb;

                m_table = new TableLayoutPanel();
                m_table.Name = "tableLayoutPanel_01";
                m_table.Text = "?";
                m_table.AutoScroll = true;
                m_table.BorderStyle = BorderStyle.None;
                m_table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
                m_table.BackColor = Color.Honeydew;
                //m_table.Size = Screen.PrimaryScreen.WorkingArea.Size;
                m_table.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                m_table.AutoSize = true;

                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));

                DataSet ads = m_dsnhomvp;
                int ai = 0, acol = 0, arow = 0, an = ads.Tables[0].Rows.Count / 4;
                if (an * 4 < ads.Tables[0].Rows.Count)
                {
                    an += 1;
                }
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    ai++;
                    if (acol < 2)
                    {
                        m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
                    }

                    alb = new Label();
                    alb.Name = "lbma_" + r["id"].ToString();
                    alb.Text = (r["viettat"].ToString().Trim() != "" ? r["viettat"].ToString().Trim() : r["ten"].ToString().Trim()) + ":";
                    toolTip1.SetToolTip(alb, r["ten"].ToString().Trim());
                    alb.AutoSize = true;
                    alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                    alb.TextAlign = ContentAlignment.MiddleRight;
                    m_table.Controls.Add(alb, acol, arow);

                    atb = new TextBox();
                    atb.Name = "tbma_" + r["id"].ToString();
                    atb.Text = "";
                    atb.BackColor = Color.White;
                    atb.Width = 70;
                    atb.Leave += new System.EventHandler(this.f_Control_Leave);
                    atb.Enter += new System.EventHandler(this.f_Control_Enter);
                    atb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                    //atb.Validated += new System.EventHandler(this.txt_Validated);
                    atb.ReadOnly = true;
                    atb.TextAlign = HorizontalAlignment.Right;
                    m_table.Controls.Add(atb, acol + 1, arow);
                    arow++;
                    if (arow >= an)
                    {
                        arow = 0;
                        acol += 2;
                    }
                }
                m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                alb = new Label();
                alb.Name = "_blank";
                alb.Text = "";
                alb.AutoSize = true;
                alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
                alb.TextAlign = ContentAlignment.MiddleRight;
                m_table.Controls.Add(alb, 0, an);

                pTonghop.Controls.Add(m_table);
                m_table.Dock = DockStyle.Fill;
                m_table.BringToFront();
            }
            catch
            {
            }
            finally
            {
                f_Tinhtien(-1);
            }
        }
        public void f_Control_Enter(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                c.ForeColor = (c.Text != "") ? Color.Blue : Color.Black;
                //c.BackColor = Color.LightYellow;
            }
            catch
            {
            }
        }
        public void f_Control_Leave(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                c.ForeColor = Color.Black;
            }
            catch
            {
            }
        }
        private void f_Control_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextBox atb = (TextBox)(sender);
                    if (atb == m_table.Controls[m_table.Controls.Count - 2])
                    {
                        butLuu.Focus();
                    }
                    else
                    {
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch
            {
            }
        }
        private void txt_Validated(object sender, EventArgs e)
        {
            f_Tinhtien(-1);
        }

        private void f_Load_Hanhchanh(string v_mabn)
        {
            try
            {
                bool aok = false;
                string sql = "";
                m_bnmoi = true;
                sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.phai,a.sonha||' - '||a.thon||' - '||d.tenpxa ||' - '||c.tenquan||' - '||b.tentt||' - '||a.cholam as  diachi from medibv.btdbn a inner join medibv.btdtt b on a.matt=b.matt inner join medibv.btdquan c on a.maqu=c.maqu inner join medibv.btdpxa d on a.maphuongxa=d.maphuongxa where a.mabn='" + v_mabn + "'";
                f_Clear_HC();
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    txtHoten.Text = r["hoten"].ToString();
                    txtNgaysinh.Text = r["ngaysinh"].ToString();
                    if (txtNgaysinh.Text.Trim() == "null" || txtNgaysinh.Text.Trim() == "")
                    {
                        txtNgaysinh.Text = r["namsinh"].ToString();
                    }
                    cbGioitinh.SelectedValue = r["phai"].ToString();
                    txtDiachi.Text = r["diachi"].ToString().Trim();

                    if (m_id == "")
                    {
                        f_Load_CB_Ngayvv("", "");
                    }
                    else
                    {
                        f_Load_CB_Ngayvv(txtNgaythu.Text.Substring(0, 10), m_maql);
                    }
                    if (cbNgayvv.Items.Count <= 0)
                    {
                        try
                        {
                            cbLoaibn.SelectedValue = "0";
                        }
                        catch
                        {
                        }
                    }
                    txtNgaysinh_Validated(null, null);
                    m_bnmoi = false;
                    aok = true;
                    break;
                }

                if (m_id == "" || m_id == "0")
                {
                    if (m_bnmoi)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không cho phép bệnh nhân chưa hoàn tất thủ tục!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        f_Enable_HC(false);
                        txtMabn.Focus();
                        return;
                    }
                    else if (cbNgayvv.Items.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không cho phép bệnh nhân chưa hoàn tất thủ tục!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        f_Enable_HC(false);
                        txtMabn.Focus();
                        return;
                    }
                    else
                    {
                        cbNgayvv_Validated(null, null);
                        f_Enable_HC(!aok);
                        if (m_dshoadon.Tables[0].Rows.Count > 0)
                        {
                            butLuu.Focus();
                        }
                        else
                        {
                            cbNgayvv.Focus();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_HanhChanh_BHYT");
            }
        }
        private void f_Load_DG()
        {
            try
            {
                //m_dsds = m_v.f_get_v_dmlydothieu("","","");
                //dataGridView1.DataSource = m_dsds.Tables[0];
                //toolStrip_Title.Text = "Danh sách lý do thiếu (" + m_dsds.Tables[0].Rows.Count.ToString() + ")";
                //toolStrip_Title.Tag = m_dsds.Tables[0].Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Clear_pTonghop()
        {
            try
            {
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        c.Text = "";
                        c.BackColor = (c.Text != "") ? Color.LightYellow : Color.White;
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Clear_HC()
        {
            try
            {
                txtChieudaithe.Text = txtHoten.Text = txtNgaysinh.Text = txtTuoi.Text = "";
                try
                {
                    cbTuoi.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    cbGioitinh.SelectedIndex = 0;
                }
                catch
                {
                }
                txtDiachi.Text = txtSothe.Text = txtTN.Text = txtDN.Text = txtNDK_Ma.Text = txtNDK_Ten.Text = txtChandoan.Text = txtICD.Text = "";
                cmbTraituyen.SelectedIndex= traituyen = 0;
                try
                {
                    cbLoaibn.SelectedValue = "0";
                }
                catch
                {
                }
                try
                {
                    cbDoituongTD.SelectedValue = 2;
                }
                catch
                {
                }
                try
                {
                    cbKhoavv.SelectedIndex = -1;
                }
                catch
                {
                }
                txtKhoavv.Text = "";

                try
                {
                    cbBacsi.SelectedIndex = -1;
                }
                catch
                {
                }
                txtBacsi.Text = txtTenvp.Text = txtSoluong.Text = txtDongia.Text = "";
                toolStrip_CongkhamBHYT.Text = toolStrip_BHYT.Text = toolStrip_Tamung.Text = toolStrip_Thucthu.Text = toolStrip_Tongcong.Text = "0";
                txtCongkham.Text = txtCPBHYT.Text = txtBNTra_BHYT.Text = txtMienBHYT.Text = txtTamung.Text = txtPhaithu.Text = "";
            }
            catch
            {
            }
        }
        private void f_Enable_HC(bool v_bool)
        {
            try
            {
                cbLoaidv.Enabled = false;// v_bool;
                txtNgaythu.Enabled = false;// v_bool;
                cbKyhieu.Enabled = false;// v_bool;
                //txtSobienlai.ReadOnly = true;// !v_bool;

                txtHoten.ReadOnly = true;// !v_bool;
                txtNgaysinh.ReadOnly = true;// !v_bool;
                txtTuoi.ReadOnly = true;// !v_bool;
                cbTuoi.Enabled = false;// v_bool;
                cbGioitinh.Enabled = false;// v_bool;
                txtDiachi.ReadOnly = true;// !v_bool;
            }
            catch
            {
            }

        }
        private void f_Enabled_VP(bool v_bool)
        {
            try
            {
                txtSothe.ReadOnly = !v_bool;
                txtTN.ReadOnly = !v_bool;
                txtDN.ReadOnly = !v_bool;
                txtNDK_Ma.ReadOnly = !v_bool;
                txtNDK_Ten.ReadOnly = !v_bool;
                cbLoaibn.Enabled = v_bool;
                cbDoituongTD.Enabled = v_bool;
                txtChandoan.ReadOnly = !v_bool;
                txtICD.ReadOnly = !v_bool;
                txtBacsi.ReadOnly = !v_bool;
                cbBacsi.Enabled = v_bool;
                txtKhoavv.ReadOnly = !v_bool;
                cbKhoavv.Enabled = v_bool;

                txtTenvp.Enabled = v_bool;
                txtSoluong.Enabled = v_bool;
                txtDongia.Enabled = v_bool;

                butAdd.Enabled = v_bool;
                butRem.Enabled = v_bool;
                butChon.Enabled = v_bool;

                dgHoadon.Columns[6].ReadOnly = (v_bhyt_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[7].ReadOnly = (v_bhyt_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[8].ReadOnly = (v_bhyt_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[9].ReadOnly = (v_bhyt_suanoidunghoadon == false) ? true : !butLuu.Enabled;
            }
            catch
            {
            }
        }
        private void f_Enable(bool v_bool)
        {
            try
            {
                butMoi.Enabled = !v_bool;
                butLuu.Enabled = v_bool;
                butInhoadon.Enabled = m_id != "" && m_id != "0";
                butInchiphi.Enabled = m_id != "" && m_id != "0";
                butSua.Enabled = !v_bool && m_id != "" && m_id != "0";
                butXoa.Enabled = !v_bool && m_id != "" && m_id != "0";
                butBoqua.Enabled = true;
                butPre.Enabled = !v_bool;
                butNext.Enabled = !v_bool;
                butKetthuc.Enabled = !v_bool;
            }
            catch
            {
            }
        }
        private void f_Moi()
        {
            try
            {
                string atmp = "";
                if (cbKyhieu.Items.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Phải khai báo quyển sổ thu viện phí trước!") + "\n" + lan.Change_language_MessageText("Vào [Tiện ích] - [Khai báo quyển sổ] để khai!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                    return;
                }
                txtMabn.Enabled = true ;
                txtMabn1.Enabled = true ;
                tmn_Danhsachcho.Enabled = true ;

                f_FullScreen(m_o_fullscreen);
                m_bnmoi = true;
                v_loadcho = false;
                m_id = "";
                m_id_toathuocbhyt = "";

                m_mavaovien = "";
                m_maql = "";
                m_id_gia = "";
                b_hddathu = false;
                b_sua = false;
                b_upd_bhytkb = false;
                m_sohieu = "";
                cbNgayvv.DataSource = null;
                m_dshoadon.Tables[0].Rows.Clear();
                m_dstamung.Tables[0].Rows.Clear();

                f_Clear_pTonghop();
                f_Tinhtien(-1);
                f_Clear_HC();
                f_Enable(true);
                f_Enable_HC(true);
                txtNgaythu.Value = m_cur_ngay;

                try
                {
                    if (m_cur_loaidv != "")
                    {
                        cbLoaidv.SelectedValue = m_cur_loaidv;
                        cbLoaidv_Validated(null, null);
                    }
                    else
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chọn loại thu viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoaidv.Enabled = false;
                        lbKyhieu_Click(null, null);
                        cbLoaidv.Focus();
                        SendKeys.Send("{F4}");
                        return;
                    }
                }
                catch
                {
                }
                try
                {
                    if (m_cur_quyenso != "")
                    {
                        cbKyhieu.SelectedValue = m_cur_quyenso;
                    }
                    else
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chọn quyển sổ thu viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoaidv.Enabled = false;
                        lbKyhieu_Click(null, null);
                        cbKyhieu.Focus();
                        SendKeys.Send("{F4}");
                        return;
                    }
                }
                catch
                {
                }
                atmp = f_Get_Sobienlai();
                m_sobienlai = atmp.Split(':')[0];
                txtSobienlai.Text = atmp.Split(':')[0];
                if (atmp.Split(':')[1] == "1")//Hết số
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    cbLoaidv.Focus();
                    return;
                }
                else
                    if (atmp.Split(':')[1] == "2")//Lỗi
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy quyển sổ thu viện phí!") + "\n" + lan.Change_language_MessageText("Đề nghị chọn sổ"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txtMabn.Text = m_cur_yy;
                txtMabn1.Text = "";
                f_Filter_Giavp();
                dgGia.Visible = false;

                txtMabn.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool kiemtra()
        {
            if (m_dshoadon.Tables[0].Rows.Count <= 0)
            {
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập nội dung thu viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenvp.Focus();
                return false;
            }
            if (txtMabn.Text.Trim().Length != 2)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập mã số bệnh nhân!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMabn.Focus();
                return false;
            }
            if (txtMabn1.Text == "" || txtMabn.Text == "")
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập mã số bệnh nhân!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMabn1.Focus();
                return false;
            }

            if (txtICD.Text == "" && !tmn_khongcungchitra.Checked && !(cbLoaibn.SelectedValue.ToString() == "0"))
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập mã chẩn đoán bệnh!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtICD.Focus();
                return false;
            }
            if (txtChandoan.Text == "" && !tmn_khongcungchitra.Checked && !(cbLoaibn.SelectedValue.ToString() == "0"))
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập chẩn đoán bệnh!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChandoan.Focus();
                return false;
            }
            if (cbKhoavv.SelectedIndex < 0)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập khoa phòng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbKhoavv.Focus();
                SendKeys.Send("{F4}");
                return false;
            }
            if (cbBacsi.SelectedIndex < 0 &&  !(cbLoaibn.SelectedValue.ToString() == "0"))
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập bác sĩ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbBacsi.Focus();
                SendKeys.Send("{F4}");
                return false;
            }
            if (cbNgayvv.Items.Count <= 0)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Bệnh nhân chưa có hồ sơ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMabn.Focus();
                return false;
            }
            if (bChithuBNChuaVuotNguong && cbDoituongTD.SelectedValue.ToString() == "1" && (decimal.Parse(toolStrip_Thucthu.Text.Replace(",", "")) > 0 || decimal.Parse(txtBNTra_BHYT.Text.Replace(",", "")) > 0))
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Bệnh nhân đã vượt ngưỡng!\n Bạn không được phép thu BN này!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMabn.Focus();
                return false;
            }
            if (BHYTThu_nhacnho_ThuDichvu_tuchitra && f_Kiemtra_chiphi_Tuchitrachuathu(cbNgayvv.Text, txtNgaythu.Text, txtMabn.Text + txtMabn1.Text, m_mavaovien, m_doituongthu))
            {
                DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Đối tượng khác chưa thu.") + "\n" + lan.Change_language_MessageText("Bạn có muốn tiếp tục không?"), "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.No)
                {
                    butBoqua_Click(null, null);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Kiem tra Xem Co con cac chi phi cac doi tuong khac BHYT da dong tien chua?
        /// </summary>
        /// <param name="v_tungay"></param>
        /// <param name="v_denngay"></param>
        /// <param name="v_mabn"></param>
        /// <param name="v_mavaovien"></param>
        /// <param name="v_madoituong_thu"></param>
        /// <returns>False: khong con, True: con</returns>
        private bool f_Kiemtra_chiphi_Tuchitrachuathu(string v_tungay, string v_denngay, string v_mabn, string v_mavaovien, string v_madoituong_thu)
        {
            string asql = " select sum(a.dongia*a.soluong) as sotien ";
            asql += " from medibvmmyy.v_chidinh a inner join medibv.doituong b on a.madoituong=b.madoituong ";
            asql += " where a.mabn='" + v_mabn + "' and a.mavaovien=" + v_mavaovien;
            asql += " and b.mien=0 and b.trasau=0 and a.madoituong<>1 and a.paid=0";
            if (v_madoituong_thu.Trim().Trim(',') != "") asql += " and a.madoituong not in(" + v_madoituong_thu.Trim().Trim(',') + ")";
            else asql += " and 1=2";
            bool bln = false;
            DataSet ads = m_v.get_data_mmyy(asql, v_tungay, v_denngay, true);
            if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
            {
                if (ads.Tables[0].Rows[0]["sotien"].ToString() == "") bln = false;
                else bln = decimal.Parse(ads.Tables[0].Rows[0]["sotien"].ToString()) > 0;
            }
            else bln = false;

            return bln;
        }

        private void f_Luu()
        {
            try
            {
                //
                string asql = "";
                string s_loaiba = "0,";
                s_loaiba += (tmn_Cokhambenh.Checked) ? "3," : "";
                s_loaiba += (tmn_Cophongluu.Checked) ? "4," : "";
                s_loaiba += (tmn_conamngoaitru.Checked) ? "2," : "";
                s_loaiba += (tmn_Conhanbenh.Checked) ? "1," : "";
                s_loaiba = s_loaiba.Trim().Trim(',');
                //
                bool asua = (m_id != "" && m_id != "0");
                string atmp = "", aidcd = "", aidtonghop = "";
                butLuu.Enabled = false;

                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "", amaql = "", amakp = "", aloai = "", aloaibn = "", auserid = "";
                angay = txtNgaythu.Text.Substring(0, 16);
                ammyy = m_v.get_mmyy(angay.Substring(0,10));
                aid = m_id;
    
                try
                {
                    aid = decimal.Parse(m_id).ToString();
                }
                catch
                {
                    aid = "0";
                }
              
                try
                {
                    aquyenso = decimal.Parse(cbKyhieu.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    aquyenso = "";
                }
               

                if (aquyenso == "")
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn quyển sổ thu viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    lbKyhieu_Click(null, null);
                    cbKyhieu.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if ((toolStrip_Tongcong.Text == toolStrip_BHYT.Text && !b_bhyt_100_theodoibienlai) || (decimal.Parse(toolStrip_Thucthu.Text) <= 0 && bbhyt_100_theodoibienlai == false))
                {
                    decimal d_sblam = m_v.v_get_sobienlaiam() * -1;
                    txtSobienlai.Text = d_sblam.ToString();
                    asobienlai = txtSobienlai.Text.Trim();//Thuy 18.04.2013 sua sobienlai=txtsobienlai.text*(-1) thay vì sobienlai=-1
                }
                else
                {
                    asobienlai = txtSobienlai.Text.Trim();
                }
                amabn = txtMabn.Text.Trim() + txtMabn1.Text.Trim();
                if (amabn == "" && txtHoten.Text == "")
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập thông tin bệnh nhân!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMabn.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                try
                {
                    amakp = cbBacsi.SelectedValue.ToString();
                }
                catch
                {
                    amakp = "";
                }
                try
                {
                    aloai = decimal.Parse(cbLoaidv.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    aloai = "0";
                }
                try
                {
                    aloaibn = decimal.Parse(cbLoaibn.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    aloaibn = "0";
                }
                auserid = m_userid;

                try
                {
                    amaql = decimal.Parse(m_maql).ToString();
                }
                catch
                {
                    amaql = "";
                }
                try
                {
                    amavaovien = decimal.Parse(m_mavaovien).ToString();
                }
                catch
                {
                    amavaovien = "";
                }

                if (amaql != "" && amaql != "0")
                {
                    if (m_v.f_parse_date(cbNgayvv.Text.Substring(0, 10)) > txtNgaythu.Value)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị chọn ngày thu >= ngày bệnh nhân vào viện (") + cbNgayvv.Text.Substring(0, 10) + ")!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        butLuu.Enabled = true;
                        cbLoaidv.Enabled = false;
                        lbKyhieu_Click(null, null);
                        txtNgaythu.Focus();
                        return;
                    }
                }

                txtSobienlai_Validated(null, null);
                if ((txtSobienlai.ReadOnly == true || txtSobienlai.Text.Trim() == "" || txtSobienlai.Text.Trim() == "0") && (m_id == "" || m_id == "0"))
                {
                    atmp = f_Get_Sobienlai();
                    m_sobienlai = atmp.Split(':')[0];
                    txtSobienlai.Text = atmp.Split(':')[0];
                    if (atmp.Split(':')[1] == "1")//Hết số
                    {
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!") + "\n" + lan.Change_language_MessageText("Có muốn chọn sổ khác không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            butLuu.Enabled = true;
                            cbLoaidv.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbKyhieu.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                    }
                    else
                        if (atmp.Split(':')[1] == "2")//Lỗi
                        {
                            butLuu.Enabled = true;
                            MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy quyển sổ thu viện phí!") + "\n" + lan.Change_language_MessageText("Đề nghị chọn sổ"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbKyhieu.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbKyhieu.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                }
                if (toolStrip_CongkhamBHYT.Text == toolStrip_Tongcong.Text && !b_bhyt_100_theodoibienlai)
                {
                    try
                    {                       
                        string sql = "select * from medibvmmyy.v_ttrvds where mabn='" + amabn + "' and id in(select id from medibvmmyy.v_ttrvll where to_char(ngay,'dd/mm/yyyy')='" + cbNgayvv.Text.Substring(0, 10) + "' and makp='" + txtKhoavv.Text.Trim() + "') and maql=" + amaql + "";
                        if (m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows.Count > 0) 
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này không có chi phí khám bệnh."), m_v.s_AppName);
                            butMoi_Click(null, null);
                            txtMabn.Focus();
                            return;
                        }
                    }
                    catch
                    {
                        butMoi_Click(null, null);
                        txtMabn.Focus();
                        return;
                    }
                    
                }
                //gam 21/11/2011 thêm phần chọn lý do miễn và người duyệt miễn
                if (toolStrip_Mien.Text != "0" && tmn_Nhaplydomien.Checked && cbLydomien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Đề nghị nhập lý do miễn giảm!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLydomien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Đề nghị nhập người duyệt miễn giảm!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKymien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (!tmn_Nhaplydomien.Checked)
                {
                    try
                    {
                        cbLydomien.SelectedIndex = 0;
                    }
                    catch
                    {
                    }
                }
                if (!tmn_Nhapkymien.Checked)
                {
                    try
                    {
                        cbKymien.SelectedIndex = 0;
                    }
                    catch
                    {
                    }
                }
                //end gam 21/11/2011
                
                #region 
                
                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".bhyt", "mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itablebhyt, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablebhyt, int.Parse(m_userid), "upd", s);
                }
                
                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".bhytcls", "id=" + aid);
                    m_v.upd_eve_tables(ammyy, itablecls, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablecls, int.Parse(m_userid), "upd", s);
                }
                
                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".bhytkb", "id=" + aid + " and mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itablekb, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablekb, int.Parse(m_userid), "upd", s);
                }

                
                if (aid != "0")
                {
                    foreach (DataRow r in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.bhytthuoc where id=" + aid + "").Tables[0].Rows)
                    {
                        string s = m_v.fields(m_v.user + ammyy + ".bhytthuoc", "id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                        m_v.upd_eve_tables(ammyy, itablethuoc, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablethuoc, int.Parse(m_userid), "upd", s);
                    }
                }
                #endregion
                //gam 28-03-11
                decimal atongtien = decimal.Parse(toolStrip_Tongcong.Text);
                LibDuoc.AccessData dd = new LibDuoc.AccessData();
                decimal d_tongtien = dd.ma13_st(1);
                if (tmn_nhacnhokhiluu.Checked && atongtien <= d_tongtien && !tmn_khongcungchitra.Checked)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Có lưu hóa đơn không ?")+"\n"+lan.Change_language_MessageText("Hoặc chờ bệnh nhân khám chữa bệnh xong mới lưu !"), "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2).ToString() == "No")
                        return;
                }
                //linh
                #region event
                
                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_ttrvds", "mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itableds, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itableds, int.Parse(m_userid), "upd", s);
                }
                
                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_ttrvll", "id=" + aid);
                    m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "upd", s);
                }
                
                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_ttrvbhyt", "id=" + aid);
                    m_v.upd_eve_tables(ammyy, itablettrvbhyt, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablettrvbhyt, int.Parse(m_userid), "upd", s);
                }

                
                if (aid != "0")
                {
                    foreach (DataRow r in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvct where id=" + aid + "").Tables[0].Rows)
                    {
                        string s = m_v.fields(m_v.user + ammyy + ".v_ttrvct", "id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                        m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "upd", s);
                    }
                }
                #endregion
                
                //linh
                string id_tonghop = "-1";
                
                if (m_id_toathuocbhyt != "") id_tonghop = m_id_toathuocbhyt;
                
                if (aid == "0") aid = m_v.get_id_v_ttrvll.ToString();
                string achandoan = txtChandoan.Text.Trim('-').Trim('+').Trim('-').Trim('+');
                if (m_v.upd_v_ttrvds(ammyy, decimal.Parse(aid), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), 0, "", angay, angay, achandoan, txtICD.Text) == "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu danh sách BN bị lỗi"), m_v.s_AppName);
                    return;
                }
                if (m_v.upd_v_ttrvll(ammyy, decimal.Parse(aid), decimal.Parse(aloaibn), decimal.Parse(cbLoaidv.SelectedValue.ToString()), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, cbKhoavv.SelectedValue.ToString(), decimal.Parse(toolStrip_Tongcong.Text.Replace(",", "")), decimal.Parse(toolStrip_Tamung.Text.Replace(",", "")), decimal.Parse(toolStrip_Mien.Text.Replace(",", "")), decimal.Parse(toolStrip_BHYT.Text.Replace(",", "")), 0, decimal.Parse(toolStrip_Thucthu.Text.Replace(",", "")), 0, 0, 0, -Math.Abs(decimal.Parse(id_tonghop)), decimal.Parse(m_userid), 0, 0, i_tylechinhsach, int.Parse(cbDoituongTD.SelectedValue.ToString())) == "0")//gam 09/12/2011
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu tổng hợp bị lỗi"), m_v.s_AppName);
                    return;
                }
                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set loaithu=1 where id=" + aid);
                //gam 21/11/2011
                if (toolStrip_Mien.Text.Trim() != "0" && aid != "0")// && cbDoituongTD.SelectedValue.ToString() != "1")
                {
                    string alydomien = "", amaduyet = "";
                    try
                    {
                        alydomien = decimal.Parse(cbLydomien.SelectedValue.ToString()).ToString();
                    }
                    catch
                    {
                        alydomien = "0";
                    }
                    try
                    {
                        amaduyet = decimal.Parse(cbKymien.SelectedValue.ToString()).ToString();
                    }
                    catch
                    {
                        amaduyet = "0";
                    }
                    m_v.upd_v_mienngtru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien), decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", "")), "Miển giảm thu BHYT ngoại trú", decimal.Parse(amaduyet));
                }
                //end gam 21/11/2011
                try
                {
                    if (txtSothe.Text != "" && !tmn_khongcungchitra.Checked)
                    {
                        int amaphu = 0;
                        try
                        {
                            int bhyt_tu = int.Parse(s_bhyt_vitri.Split(',')[0].ToString());
                            int bhyt_den = int.Parse(s_bhyt_vitri.Split(',')[1].ToString());
                            if (s_bhyt_kytu.ToString().IndexOf(txtSothe.Text.ToString().Substring(bhyt_tu - 1, bhyt_den) + "+") >= 0)
                                amaphu = 1;
                        }
                        catch { }
                        m_v.upd_v_ttrvbhyt(ammyy, decimal.Parse(aid), txtSothe.Text, amaphu, txtDN.Text, txtTN.Text, txtNDK_Ma.Text, "",traituyen);
                    }
                }
                catch (Exception ex)
                {
                    m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "upd_v_ttrvbhyt_BHYT_f_LUU");
                }
                if (tmn_khongcungchitra.Checked)
                {
                    string v_maql_TD = "";// amavaovien;// "";
                    try
                    {
                        asql = "select maql from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "'";
                        asql += " and done='x'";
                        v_maql_TD = m_v.get_data_mmyy(ammyy, asql).Tables[0].Rows[0]["maql"].ToString();

                        if (v_maql_TD != "0" || v_maql_TD != "")
                        {
                            m_v.execute_data("Update medibv" + ammyy + ".tiepdon set done=null where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD);
                        }
                    }
                    catch { }
                }

                decimal d_stt = 1;
                decimal gia_bh = 0;
                DataRow r0;
                int i = m_dshoadon.Tables[0].Rows.Count;
                string exp = "";
                if (tmn_khongcungchitra.Checked)
                    exp = "id<0";
                else
                    exp = "1=1";
                foreach (DataRow r in m_dshoadon.Tables[0].Select(exp)) 
                {
                    gia_bh = 0;
                    r0 = m_v.getrowbyid(dtdm, "id=" + decimal.Parse(r["mavp"].ToString()));
                    if (r0 != null) gia_bh = decimal.Parse(r0["gia_bh"].ToString());
                    string test = cbKhoavv.SelectedValue.ToString();
                    //decimal a=decimal.Parse(r["madoituong"].ToString());
                    decimal b=decimal.Parse(r["mavp"].ToString());
                    decimal c=decimal.Parse(r["soluong"].ToString());
                    decimal d=decimal.Parse(r["dongia"].ToString());
                    decimal e=decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString());
                    decimal f = decimal.Parse(r["bhyttra"].ToString());
                    decimal g = decimal.Parse(r["madoituong"].ToString());
                    if (!m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), d_stt++, angay.Substring(0, 10), cbKhoavv.SelectedValue.ToString(), g, decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, 0, decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["bhyttra"].ToString()), gia_bh, decimal.Parse(r["mien"].ToString()), r["mabs1"].ToString(), decimal.Parse(r["idtonghop"].ToString()), int.Parse(r["stttonghop"].ToString())))//ThanhCuong 15/03/2012 sửa r["mabs"].ToString() --> r["mabs1"].ToString()
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu chi tiết bị lỗi"), m_v.s_AppName);
                        return;
                    }
                }
                if (!tmn_khongcungchitra.Checked)
                {
                    foreach (DataRow rr in m_v.get_data("select mmyy,substr(mmyy,3)||substr(mmyy,0,2) as chim from medibv.table where  substr(mmyy,3)||substr(mmyy,0,2) >='" + "0" + ammyy.Substring(3) + ammyy.Substring(0, 2) + "' order by mmyy").Tables[0].Rows)
                    {
                        if (m_v.s_iscreated_mmyy(rr["mmyy"].ToString()))
                        {
                            if (m_v.get_data_mmyy(rr["mmyy"].ToString(), "select * from medibvmmyy.bhytkb where mabn='" + amabn + "' and to_char(ngay,'dd/mm/yyyy')='" + cbNgayvv.Text.Substring(0, 10) + "'").Tables[0].Rows.Count > 0)
                            {

                                m_v.upd_bhytds(rr["mmyy"].ToString(), amabn, txtHoten.Text.Trim(), txtNgaysinh.Text.Trim().PadLeft(10, '0').Substring(6, 4), txtDiachi.Text);
                                if (thutheongay)
                                {
                                    if (!m_v.upd_bhytkb(rr["mmyy"].ToString(), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay.Substring(0, 10), amabn))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu BHYT khám bệnh bị lỗi"), m_v.s_AppName);
                                        return;
                                    }
                                }
                                else
                                {
                                    id_tonghop = m_v.upd_bhytkb(rr["mmyy"].ToString(), decimal.Parse(id_tonghop), 1, decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), cbKhoavv.SelectedValue.ToString(),txtChandoan.Text != "" ? txtChandoan.Text.Trim(): "", txtICD.Text.Trim(), cbBacsi.SelectedValue.ToString(), txtSothe.Text.Trim(), 1, txtNDK_Ma.Text.Trim(), 0, 0, 0, decimal.Parse(toolStrip_Thucthu.Text.Replace(",", "")), decimal.Parse(toolStrip_BHYT.Text.Replace(",", "")), decimal.Parse(aloaibn), decimal.Parse(m_userid), traituyen);
                                }
                                if (id_tonghop == "0")
                                {
                                    f_Enable(true);
                                    f_Enable_HC(true);
                                    MessageBox.Show(this, lan.Change_language_MessageText("Lỗi lưu dữ liệu!") + "\n" + lan.Change_language_MessageText("Chưa lưu dược hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                if ((cbDoituongTD.SelectedValue.ToString() == "1" && txtDN.Text.Trim().Length >= 10) || (cbDoituongTD.SelectedValue.ToString() == "6" && txtDN.Text.Trim().Length >= 10))
                                    m_v.upd_bhyt_mmyy(rr["mmyy"].ToString(), amabn, decimal.Parse(amaql), txtSothe.Text.Trim(), txtTN.Text.Trim(), txtDN.Text.Trim(), txtNDK_Ma.Text.Trim(), 1, traituyen);
                            }
                        }
                    }
                }              
                if (toolStrip_Tongcong.Text != toolStrip_BHYT.Text)    m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                aidcd = ""; aidtonghop = "";
                
                //if (id_tonghop != "0")
                //{
                   ////decimal astt = 1;
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {                            
                            aidcd += r["mavp"].ToString() + ",";
                            aidtonghop += r["idtonghop"].ToString() + ",";
                            //binh 21032014 --> do khi luu co luu field v_ttrvct.idtonghop = v_chidinh.id, bhytkb.id; v_ttrvct.sttduyet= bhytthuoc.stt, bhytcls.stt
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.bhytkb set quyenso=" + aquyenso + ", sobienlai=" + asobienlai + ", idttrv=" + aid + " where id = " + r["idtonghop"].ToString() + "");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1, idttrv=" + aid + " where id = " + r["idtonghop"].ToString() + " and paid=0");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1, idttrv=" + aid + " where id = " + r["idtonghop"].ToString() + " ");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1, idttrv=" + aid + " where id = " + r["idtonghop"].ToString() + " and stt=" + r["stttonghop"].ToString());
                            //
                        }
                        catch
                        {
                        }
                    }
                    aidcd = aidcd.Trim().Trim(',');
                   // end
                    asql = "";
                    if ((thutheongay || thutheodot_mavaovien) && !tmn_khongcungchitra.Checked)
                    {
                        foreach (DataRow rdel in m_v.get_data_mmyy(ammyy, "select id from medibvmmyy.bhytkb where mabn='" + amabn + "' and mavaovien=" + m_mavaovien + "").Tables[0].Rows) 
                        {
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set cls = (select case when sum(soluong*dongia) is null then 0 else sum(soluong*dongia) end from medibvmmyy.bhytcls where id = " + rdel["id"].ToString() + ") where id=" + rdel["id"].ToString());
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set thuoc = (select case when sum(a.soluong*a1.giamua) is null then 0 else sum(a.soluong*a1.giamua) end from medibvmmyy.bhytthuoc a inner join medibvmmyy.d_theodoi a1 on a.sttt=a1.id where a.id = " + rdel["id"].ToString() + ") where id=" + rdel["id"].ToString());
                            asql = "update medibvmmyy.v_tamung set idttrv=" + aid.ToString() + ",done=1 ";
                            if (s_idthutamung.Trim().Trim(',') != "") asql += " where (maql=" + m_maql_tiepdon + " or id in (" + s_idthutamung.Trim().Trim(',') + "))";
                            else asql += " where (maql=" + m_maql_tiepdon + ")";
                            m_v.execute_data_mmyy(ammyy, asql);
                            //
                            asql = "update medibvmmyy.v_tontamung set idttrv=" + aid.ToString() + ",done=1 ";
                            if (s_idthutamung.Trim().Trim(',') != "") asql += " where (maql=" + m_maql_tiepdon + " or id in (" + s_idthutamung.Trim().Trim(',') + "))";
                            else asql += " where (maql=" + m_maql_tiepdon + ")";
                            m_v.execute_data_mmyy(ammyy, asql);
                            //
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set quyenso=" + decimal.Parse(aquyenso) + ",sobienlai=" + decimal.Parse(asobienlai) + " where id=" + rdel["id"].ToString());//,done=1
                        }
                    }
                    else if (!tmn_khongcungchitra.Checked)
                    {
                        m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.bhytkb set quyenso=" + decimal.Parse(aquyenso) + ",sobienlai=" + decimal.Parse(asobienlai) + " where id=" + id_tonghop);//,done=1 
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set cls = (select case when sum(soluong*dongia) is null then 0 else sum(soluong*dongia) end from medibvmmyy.bhytcls where id = " + id_tonghop + ") where id=" + id_tonghop);
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set thuoc = (select case when sum(a.soluong*a1.giamua) is null then 0 else sum(a.soluong*a1.giamua) end from medibvmmyy.bhytthuoc a inner join medibvmmyy.d_theodoi a1 on a.sttt=a1.id where a.id = " + id_tonghop + ") where id=" + id_tonghop);
                        asql = "update medibvmmyy.v_tamung set idttrv=" + aid.ToString() + ",done=1 ";
                        if (s_idthutamung.Trim().Trim(',') == "") asql += " where maql=" + m_maql_tiepdon + "";
                        else asql += " where (maql=" + m_maql_tiepdon + " or id in (" + s_idthutamung.Trim().Trim(',') + "))";
                        m_v.execute_data_mmyy(ammyy, asql);
                        //
                        asql = "update medibvmmyy.v_tontamung set idttrv=" + aid.ToString() + ",done=1 ";
                        if (s_idthutamung.Trim().Trim(',') == "") asql += " where maql=" + m_maql_tiepdon + "";
                        else asql += " where (maql=" + m_maql_tiepdon + " or id in (" + s_idthutamung.Trim().Trim(',') + "))";
                        m_v.execute_data_mmyy(ammyy, asql);
                    }
                    //Done
                    if (aidcd.Trim().Trim(',') != "")
                    {
                        if (tmn_Thuchidinh.Checked && thutheodot_mavaovien )
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and mavaovien=" + m_mavaovien + " and loaiba in(" + ((s_loaiba == "") ? "1,2,3,4" : s_loaiba) + ") and mavp in (" + aidcd.Trim().Trim(',') + ") and id in(" + aidtonghop.Trim().Trim(',') + ") ");//and paid=0
                        }
                        else if (tmn_Thuchidinh.Checked && !thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and mavp in (" + aidcd.Trim().Trim(',') + ") and id in(" + aidtonghop.Trim().Trim(',') + ") and " + exp);//and paid=0
                        }
                        if (tmn_Vienphikhoa.Checked && !thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and done=0 and mavp in (" + aidcd.Trim().Trim(',') + ") and id in(" + aidtonghop.Trim().Trim(',') + ")");
                        }
                        else if (tmn_Vienphikhoa.Checked && thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + m_mavaovien + ") and mavp in (" + aidcd.Trim().Trim(',') + ") and id in(" + aidtonghop.Trim().Trim(',') + ")");
                        }
                        if ((tmn_Toathuoctutruc.Checked || tmn_Thuocthuongquy.Checked) && !thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + amavaovien + ") and mabd in (" + aidcd.Trim().Trim(',') + ") and id in(" + aidtonghop.Trim().Trim(',') + ")");
                            //binh 130511
                            try
                            {
                                if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                    m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                            }
                            catch { }
                            
                        }
                        else if ((tmn_Toathuoctutruc.Checked || tmn_Thuocthuongquy.Checked) && thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + m_mavaovien + ") and mabd in (" + aidcd + ") and id in(" + aidtonghop.Trim().Trim(',') + ") ");
                            //binh 130511
                            try
                            {
                                if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                    m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                            }
                            catch { }
                        }
                        if (tmn_Khoatonghop.Checked)
                        {
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid.ToString() + "  where mabn='" + amabn + "' and maql=" + amaql + " and "+exp);
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and mavp in (" + aidcd + ") ");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and mavp in (" + aidcd + ") ");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and mabd in (" + aidcd + ") ");
                            //binh 130511
                            try
                            {
                                if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                    m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                            }
                            catch { }
                        }
                        else//
                        {
                            //cap nhat v_thvpll: khi chi phi phong luu lo chuyen xuong vien phi
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + amavaovien + ") and makp in(select makp from medibv.btdkp_bv where loai <>1) ");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid.ToString() + " where id in(select id from medibvmmyy.v_thvpll where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + amavaovien + ")) and mavp in (" + aidcd.Trim().Trim(',') + ") and makp in(select makp from medibv.btdkp_bv where loai <>1)");
                        }
                        if (m_v.bCongkham(aidcd) && CongthucTraiTuyen160212 && cmbTraituyen.SelectedIndex != 0 && m.StringToDate(angay.Substring(0,10)) >= m.StringToDate("15/02/2012"))
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), 
                                "update medibvmmyy.tiepdon set done=null where mabn='" + amabn + "' and maql=" + amaql);
                        }
                    }
                    
                //}
                m_id = aid;
                if (m_id == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this, lan.Change_language_MessageText("Lỗi lưu dữ liệu!") + "\n" + lan.Change_language_MessageText("Chưa lưu dược hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    f_Enable(false);
                    f_Enable_HC(false);
                    if (tmn_Luuin_Hoadon_Icon.Checked)
                    {
                        if (tmn_Luuin_Hoadon.Checked)
                        {
                            if (asua)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại hoá đơn vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inhoadon();
                                }
                            }

                            else
                            {
                                if (tmn_Luuin_Hoadon.Checked && ((v_tachhoadon_dv != "" && m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")").Length > 0) || v_tachbienlai_dv != "" && m_dshoadon.Tables[0].Select("nhom in (" + v_tachbienlai_dv + ")").Length > 0))
                                {
                                    f_Inhoadon(true);
                                }
                                else
                                {
                                    f_Inhoadon(false);
                                }
                                //f_Inhoadon();
                            }
                        }
                        if (tmn_Luuin_Phieuthuchi.Checked)
                        {
                            if (asua)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại phiếu thu chi vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inphieuthuchi();
                                }
                            }
                            else
                            {
                                f_Inhoadon();
                            }
                        }
                        if (tmn_Luuin_Chiphi.Checked)
                        {
                            if (asua)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại chi phí vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inchiphi();
                                }
                            }
                            else
                            {
                                f_Inchiphi();
                            }
                        }
                    }
                    butMoi.Focus();
                }
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_LUU_BHYT");
            }
        }
        private string f_Get_Sobienlai(string v_quyenso)
        {
            try
            {
                string art = "0:2";
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" + v_quyenso).Tables[0].Rows)
                {
                    art = r["soghi"].ToString();
                    if (decimal.Parse(r["soghi"].ToString()) > decimal.Parse(r["den"].ToString()))
                    {
                        art += ":1";
                    }
                    else
                    {
                        art += ":0";
                    }
                    break;
                }
                return art;
            }
            catch
            {
                return "0:2";
            }
        }
        private void f_Luu(bool bdichvu,DataSet dsHoadon)
        {
            try
            {
                if (dsHoadon.Tables[0].Rows.Count <= 0)
                {
                    return;
                }
                //
                if (bdichvu)
                {
                    m_sobienlai = f_Get_Sobienlai(s_quyenso_dichvu).Split(':')[0];
                    txtSobienlai.Text = m_sobienlai;// f_Get_Sobienlai(s_quyenso_dichvu).Split(':')[0];
                    cbKyhieu.SelectedValue = s_quyenso_dichvu;
                }
                string s_loaiba = "0,";
                s_loaiba += (tmn_Cokhambenh.Checked) ? "3," : "";
                s_loaiba += (tmn_Cophongluu.Checked) ? "4," : "";
                s_loaiba += (tmn_conamngoaitru.Checked) ? "2," : "";
                s_loaiba += (tmn_Conhanbenh.Checked) ? "1," : "";
                s_loaiba = s_loaiba.Trim().Trim(',');
                decimal am_id = decimal.Parse((m_id == "" || m_id == "-") ? "0" : m_id);
                //
                bool asua = (m_id != "" && m_id != "0" && am_id > 0 && m_id != "-");
                string atmp = "", aidcd = "";
                butLuu.Enabled = false;

                
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "", amaql = "", amakp = "", aloai = "", aloaibn = "", auserid = "";
                angay = txtNgaythu.Text.Substring(0, 16);
                ammyy = m_v.get_mmyy(angay.Substring(0, 10));
                aid = m_id;

                try
                {
                    aid = decimal.Parse(m_id).ToString();
                }
                catch
                {
                    aid = "0";
                }

                try
                {
                    aquyenso = decimal.Parse(cbKyhieu.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    aquyenso = "";
                }


                if (aquyenso == "")
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn quyển sổ thu viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    lbKyhieu_Click(null, null);
                    cbKyhieu.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }

                //gam 21/11/2011 thêm phần chọn lý do miễn và người duyệt miễn
                if (toolStrip_Mien.Text != "0" && tmn_Nhaplydomien.Checked && cbLydomien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Đề nghị nhập lý do miễn giảm!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLydomien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Đề nghị nhập người duyệt miễn giảm!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKymien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (!tmn_Nhaplydomien.Checked)
                {
                    try
                    {
                        cbLydomien.SelectedIndex = 0;
                    }
                    catch
                    {
                    }
                }
                if (!tmn_Nhapkymien.Checked)
                {
                    try
                    {
                        cbKymien.SelectedIndex = 0;
                    }
                    catch
                    {
                    }
                }
                //end gam 21/11/2011
                if (toolStrip_Tongcong.Text == toolStrip_BHYT.Text && !b_bhyt_100_theodoibienlai)
                {
                    asobienlai = "-"+txtSobienlai.Text.Trim(); //Thuy 18.04.2013 sua sobienlai=txtsobienlai.text*(-1) thay vì sobienlai=-1
                }
                else
                {
                    asobienlai = txtSobienlai.Text.Trim();
                }
                amabn = txtMabn.Text.Trim() + txtMabn1.Text.Trim();
                if (amabn.Length <= 2)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập thông tin bệnh nhân!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMabn.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                try
                {
                    amakp = cbBacsi.SelectedValue.ToString();
                }
                catch
                {
                    amakp = "";
                }
                try
                {
                    aloai = decimal.Parse(cbLoaidv.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    aloai = "0";
                }
                try
                {
                    aloaibn = decimal.Parse(cbLoaibn.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    aloaibn = "0";
                }
                auserid = m_userid;

                try
                {
                    amaql = decimal.Parse(m_maql).ToString();
                }
                catch
                {
                    amaql = "";
                }
                try
                {
                    amavaovien = decimal.Parse(m_mavaovien).ToString();
                }
                catch
                {
                    amavaovien = "";
                }

                if (amaql != "" && amaql != "0")
                {
                    if (m_v.f_parse_date(cbNgayvv.Text.Substring(0, 10)) > txtNgaythu.Value)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị chọn ngày thu >= ngày bệnh nhân vào viện (") + cbNgayvv.Text.Substring(0, 10) + ")!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        butLuu.Enabled = true;
                        cbLoaidv.Enabled = false;
                        lbKyhieu_Click(null, null);
                        txtNgaythu.Focus();
                        return;
                    }
                }

                txtSobienlai_Validated(null, null);
                if ((txtSobienlai.ReadOnly == true || txtSobienlai.Text.Trim() == "" || txtSobienlai.Text.Trim() == "0") && (m_id == "" || m_id == "0"))
                {
                    atmp = f_Get_Sobienlai();
                    m_sobienlai = atmp.Split(':')[0];
                    txtSobienlai.Text = atmp.Split(':')[0];
                    if (atmp.Split(':')[1] == "1")//Hết số
                    {
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!") + "\n" + lan.Change_language_MessageText("Có muốn chọn sổ khác không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            butLuu.Enabled = true;
                            cbLoaidv.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbKyhieu.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                    }
                    else
                        if (atmp.Split(':')[1] == "2")//Lỗi
                        {
                            butLuu.Enabled = true;
                            MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy quyển sổ thu viện phí!") + "\n" + lan.Change_language_MessageText("Đề nghị chọn sổ"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbKyhieu.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbKyhieu.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                }
                if (toolStrip_CongkhamBHYT.Text == toolStrip_Tongcong.Text && !b_bhyt_100_theodoibienlai)
                {
                    try
                    {
                        string sql = "select * from medibvmmyy.v_ttrvds where mabn='" + amabn + "' and id in(select id from medibvmmyy.v_ttrvll where to_char(ngay,'dd/mm/yyyy')='" + cbNgayvv.Text.Substring(0, 10) + "' and makp='" + txtKhoavv.Text.Trim() + "') and maql=" + amaql + "";
                        if (m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này không có chi phí khám bệnh."), m_v.s_AppName);
                            butMoi_Click(null, null);
                            txtMabn.Focus();
                            return;
                        }
                    }
                    catch
                    {
                        butMoi_Click(null, null);
                        txtMabn.Focus();
                        return;
                    }

                }

                #region

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".bhyt", "mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itablebhyt, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablebhyt, int.Parse(m_userid), "upd", s);
                }

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".bhytcls", "id=" + aid);
                    m_v.upd_eve_tables(ammyy, itablecls, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablecls, int.Parse(m_userid), "upd", s);
                }

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".bhytkb", "id=" + aid + " and mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itablekb, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablekb, int.Parse(m_userid), "upd", s);
                }


                if (aid != "0")
                {
                    foreach (DataRow r in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.bhytthuoc where id=" + aid + "").Tables[0].Rows)
                    {
                        string s = m_v.fields(m_v.user + ammyy + ".bhytthuoc", "id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                        m_v.upd_eve_tables(ammyy, itablethuoc, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablethuoc, int.Parse(m_userid), "upd", s);
                    }
                }
                #endregion
                //gam 28-03-11
                decimal atongtien = decimal.Parse(toolStrip_Tongcong.Text);
                LibDuoc.AccessData dd = new LibDuoc.AccessData();
                decimal d_tongtien = dd.ma13_st(1);
                if (tmn_nhacnhokhiluu.Checked && atongtien <= d_tongtien && !tmn_khongcungchitra.Checked)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Có lưu hóa đơn không ?") + "\n" + lan.Change_language_MessageText("Hoặc chờ bệnh nhân khám chữa bệnh xong mới lưu !"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString() == "No")
                        return;
                }
                //linh
                #region event

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_ttrvds", "mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itableds, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itableds, int.Parse(m_userid), "upd", s);
                }

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_ttrvll", "id=" + aid);
                    m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "upd", s);
                }

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_ttrvbhyt", "id=" + aid);
                    m_v.upd_eve_tables(ammyy, itablettrvbhyt, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablettrvbhyt, int.Parse(m_userid), "upd", s);
                }


                if (aid != "0")
                {
                    foreach (DataRow r in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvct where id=" + aid + "").Tables[0].Rows)
                    {
                        string s = m_v.fields(m_v.user + ammyy + ".v_ttrvct", "id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                        m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "upd", s);
                    }
                }
                #endregion

                //linh
                string id_tonghop = "-1";

                if (m_id_toathuocbhyt != "") id_tonghop = m_id_toathuocbhyt;

                if (aid == "0") aid = m_v.get_id_v_ttrvll.ToString();
                string achandoan = txtChandoan.Text.Trim('-').Trim('+').Trim('-').Trim('+');
                if (m_v.upd_v_ttrvds(ammyy, decimal.Parse(aid), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), 0, "", angay, angay, achandoan, txtICD.Text) == "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu danh sách BN bị lỗi"), m_v.s_AppName);
                    return;
                }
                if (m_v.upd_v_ttrvll(ammyy, decimal.Parse(aid), decimal.Parse(aloaibn), decimal.Parse(cbLoaidv.SelectedValue.ToString()), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, cbKhoavv.SelectedValue.ToString(), decimal.Parse(toolStrip_Tongcong.Text.Replace(",", "")), decimal.Parse(toolStrip_Tamung.Text.Replace(",", "")), decimal.Parse(toolStrip_Mien.Text.Replace(",", "")), decimal.Parse(toolStrip_BHYT.Text.Replace(",", "")), 0, 0, 0, 0, 0, -Math.Abs(decimal.Parse(id_tonghop)), decimal.Parse(m_userid), 0, 0, i_tylechinhsach,int.Parse(cbDoituongTD.SelectedValue.ToString())) == "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu tổng hợp bị lỗi"), m_v.s_AppName);
                    return;
                }
                //gam 21/11/2011
                if (toolStrip_Mien.Text.Trim() != "0" && aid != "0")// && cbDoituongTD.SelectedValue.ToString() != "1")
                {
                    string alydomien = "", amaduyet = "";
                    try
                    {
                        alydomien = decimal.Parse(cbLydomien.SelectedValue.ToString()).ToString();
                    }
                    catch
                    {
                        alydomien = "0";
                    }
                    try
                    {
                        amaduyet = decimal.Parse(cbKymien.SelectedValue.ToString()).ToString();
                    }
                    catch
                    {
                        amaduyet = "0";
                    }
                    m_v.upd_v_mienngtru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien), decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", "")), "Miển giảm thu BHYT ngoại trú", decimal.Parse(amaduyet));
                }   
                //end gam 21/11/2011
                try
                {
                    if (txtSothe.Text != "" && !tmn_khongcungchitra.Checked)
                    {
                        int amaphu = 0;
                        try
                        {
                            int bhyt_tu = int.Parse(s_bhyt_vitri.Split(',')[0].ToString());
                            int bhyt_den = int.Parse(s_bhyt_vitri.Split(',')[1].ToString());
                            if (s_bhyt_kytu.ToString().IndexOf(txtSothe.Text.ToString().Substring(bhyt_tu - 1, bhyt_den) + "+") >= 0)
                                amaphu = 1;
                        }
                        catch { }
                        m_v.upd_v_ttrvbhyt(ammyy, decimal.Parse(aid), txtSothe.Text, amaphu, txtDN.Text, txtTN.Text, txtNDK_Ma.Text, "", traituyen);
                    }
                }
                catch (Exception ex)
                {
                    m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "upd_v_ttrvbhyt_BHYT_f_LUU");
                }
                if (tmn_khongcungchitra.Checked)
                {
                    string v_maql_TD = "";// amavaovien;// "";
                    v_maql_TD = m_v.get_data_mmyy(ammyy, "select maql from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and done='x'").Tables[0].Rows[0]["maql"].ToString();
                    try
                    {
                        if (v_maql_TD != "0" || v_maql_TD != "")
                        {
                            m_v.execute_data("Update medibv" + ammyy + ".tiepdon set done=null where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD);
                        }
                    }
                    catch { }
                }

                decimal d_stt = 1;
                decimal gia_bh = 0;
                DataRow r0;
                int i = dsHoadon.Tables[0].Rows.Count;
                string exp = "";
                if (tmn_khongcungchitra.Checked)
                    exp = "id<0";
                else
                    exp = "1=1";
                foreach (DataRow r in dsHoadon.Tables[0].Select(exp))
                {
                    gia_bh = 0;
                    r0 = m_v.getrowbyid(dtdm, "id=" + decimal.Parse(r["mavp"].ToString()));
                    if (r0 != null) gia_bh = decimal.Parse(r0["gia_bh"].ToString());
                    string test = cbKhoavv.SelectedValue.ToString();
                    //decimal a=decimal.Parse(r["madoituong"].ToString());
                    decimal b = decimal.Parse(r["mavp"].ToString());
                    decimal c = decimal.Parse(r["soluong"].ToString());
                    decimal d = decimal.Parse(r["dongia"].ToString());
                    decimal e = decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString());
                    decimal f = decimal.Parse(r["bhyttra"].ToString());
                    decimal g = decimal.Parse(r["madoituong"].ToString());
                    if (!m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), d_stt++, angay.Substring(0, 10), cbKhoavv.SelectedValue.ToString(), g, decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, 0, decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["bhyttra"].ToString()), gia_bh, r["mabs"].ToString(),decimal.Parse(r["idtonghop"].ToString()),int.Parse(r["stttonghop"].ToString())))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu chi tiết bị lỗi"), m_v.s_AppName);
                        return;
                    }
                }
                if (!tmn_khongcungchitra.Checked)
                {
                    foreach (DataRow rr in m_v.get_data("select mmyy,substr(mmyy,3)||substr(mmyy,0,2) as chim from medibv.table where  substr(mmyy,3)||substr(mmyy,0,2) >='" + "0" + ammyy.Substring(3) + ammyy.Substring(0, 2) + "' order by mmyy").Tables[0].Rows)
                    {
                        if (m_v.s_iscreated_mmyy(rr["mmyy"].ToString()))
                        {
                            if (m_v.get_data_mmyy(rr["mmyy"].ToString(), "select * from medibvmmyy.bhytkb where mabn='" + amabn + "' and to_char(ngay,'dd/mm/yyyy')='" + cbNgayvv.Text.Substring(0, 10) + "'").Tables[0].Rows.Count > 0)
                            {

                                m_v.upd_bhytds(rr["mmyy"].ToString(), amabn, txtHoten.Text.Trim(), txtNgaysinh.Text.Trim().PadLeft(10, '0').Substring(6, 4), txtDiachi.Text);
                                if (thutheongay)
                                {
                                    if (!m_v.upd_bhytkb(rr["mmyy"].ToString(), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay.Substring(0, 10), amabn))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu BHYT khám bệnh bị lỗi"), m_v.s_AppName);
                                        return;
                                    }
                                }
                                else
                                {
                                    id_tonghop = m_v.upd_bhytkb(rr["mmyy"].ToString(), decimal.Parse(id_tonghop), 1, decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), cbKhoavv.SelectedValue.ToString(), txtChandoan.Text.Trim(), txtICD.Text.Trim(), cbBacsi.SelectedValue.ToString(), txtSothe.Text.Trim(), 1, txtNDK_Ma.Text.Trim(), 0, 0, 0, decimal.Parse(toolStrip_Thucthu.Text.Replace(",", "")), decimal.Parse(toolStrip_BHYT.Text.Replace(",", "")), decimal.Parse(aloaibn), decimal.Parse(m_userid), traituyen);
                                }
                                if (id_tonghop == "0")
                                {
                                    f_Enable(true);
                                    f_Enable_HC(true);
                                    MessageBox.Show(this, lan.Change_language_MessageText("Lỗi lưu dữ liệu!") + "\n" + lan.Change_language_MessageText("Chưa lưu dược hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                if ((cbDoituongTD.SelectedValue.ToString() == "1" && txtDN.Text.Trim().Length >= 10) || (cbDoituongTD.SelectedValue.ToString() == "6" && txtDN.Text.Trim().Length >= 10))
                                    m_v.upd_bhyt_mmyy(rr["mmyy"].ToString(), amabn, decimal.Parse(amaql), txtSothe.Text.Trim(), txtTN.Text.Trim(), txtDN.Text.Trim(), txtNDK_Ma.Text.Trim(), 1, traituyen);
                            }
                        }
                    }
                }
                if (toolStrip_Tongcong.Text != toolStrip_BHYT.Text) m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                aidcd = "";

                if (id_tonghop != "0")
                {
                    //decimal astt = 1;
                    foreach (DataRow r in dsHoadon.Tables[0].Rows)
                    {
                        try
                        {
                            //if (m_dsgiavp.Tables[0].Select("loaigia=0 and id=" + r["mavp"].ToString()).Length > 0)
                            //{                                
                            //    //m_v.upd_bhytcls(ammyy, decimal.Parse(r["id"].ToString()), astt, decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0);
                            //   // astt += 1;
                            //    if (aidcd != "")
                            //    {
                            //        aidcd += ",";
                            //    }
                            //    aidcd += r["mavp"].ToString();
                            //}
                            aidcd += r["mavp"].ToString() + ",";
                        }
                        catch
                        {
                        }
                    }
                    aidcd = aidcd.Trim().Trim(',');
                    // end
                    string asql = "";
                    if ((thutheongay || thutheodot_mavaovien) && !tmn_khongcungchitra.Checked)
                    {
                        if (!b_upd_bhytkb)
                        {
                            foreach (DataRow rdel in m_v.get_data_mmyy(ammyy, "select id from medibvmmyy.bhytkb where mabn='" + amabn + "' and mavaovien=" + m_mavaovien + "").Tables[0].Rows)
                            {
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set cls = (select case when sum(soluong*dongia) is null then 0 else sum(soluong*dongia) end from medibvmmyy.bhytcls where id = " + rdel["id"].ToString() + ") where id=" + rdel["id"].ToString());
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set thuoc = (select case when sum(a.soluong*a1.giamua) is null then 0 else sum(a.soluong*a1.giamua) end from medibvmmyy.bhytthuoc a inner join medibvmmyy.d_theodoi a1 on a.sttt=a1.id where a.id = " + rdel["id"].ToString() + ") where id=" + rdel["id"].ToString());
                                asql = "update medibvmmyy.v_tamung set idttrv=" + aid.ToString() + ",done=1 ";
                                if (s_idthutamung.Trim().Trim(',') != "") asql += " where (maql=" + m_maql_tiepdon + " or id in (" + s_idthutamung.Trim().Trim(',') + "))";
                                else asql += " where (maql=" + m_maql_tiepdon + ")";
                                m_v.execute_data_mmyy(ammyy, asql);
                                //
                                asql = "update medibvmmyy.v_tontamung set idttrv=" + aid.ToString() + ",done=1 ";
                                if (s_idthutamung.Trim().Trim(',') != "") asql += " where (maql=" + m_maql_tiepdon + " or id in (" + s_idthutamung.Trim().Trim(',') + "))";
                                else asql += " where (maql=" + m_maql_tiepdon + ")";
                                m_v.execute_data_mmyy(ammyy, asql);
                                //
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set quyenso=" + decimal.Parse(aquyenso) + ",sobienlai=" + decimal.Parse(asobienlai) + " where id=" + rdel["id"].ToString());//,done=1
                            }
                            b_upd_bhytkb = true;
                        }
                    }
                    else if (!tmn_khongcungchitra.Checked)
                    {
                        m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.bhytkb set quyenso=" + decimal.Parse(aquyenso) + ",sobienlai=" + decimal.Parse(asobienlai) + " where id=" + id_tonghop);//,done=1 
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set cls = (select case when sum(soluong*dongia) is null then 0 else sum(soluong*dongia) end from medibvmmyy.bhytcls where id = " + id_tonghop + ") where id=" + id_tonghop);
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set thuoc = (select case when sum(a.soluong*a1.giamua) is null then 0 else sum(a.soluong*a1.giamua) end from medibvmmyy.bhytthuoc a inner join medibvmmyy.d_theodoi a1 on a.sttt=a1.id where a.id = " + id_tonghop + ") where id=" + id_tonghop);
                        asql = "update medibvmmyy.v_tamung set idttrv=" + aid.ToString() + ",done=1 ";
                        if (s_idthutamung.Trim().Trim(',') == "") asql += " where maql=" + m_maql_tiepdon + "";
                        else asql += " where (maql=" + m_maql_tiepdon + " or id in (" + s_idthutamung.Trim().Trim(',') + "))";
                        m_v.execute_data_mmyy(ammyy, asql);
                        //
                        asql = "update medibvmmyy.v_tontamung set idttrv=" + aid.ToString() + ",done=1 ";
                        if (s_idthutamung.Trim().Trim(',') == "") asql += " where maql=" + m_maql_tiepdon + "";
                        else asql += " where (maql=" + m_maql_tiepdon + " or id in (" + s_idthutamung.Trim().Trim(',') + "))";
                        m_v.execute_data_mmyy(ammyy, asql);
                    }
                    //Done
                    if (aidcd.Trim().Trim(',') != "")
                    {
                        if (tmn_Thuchidinh.Checked && thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and mavaovien=" + m_mavaovien + " and loaiba in(" + ((s_loaiba == "") ? "1,2,3,4" : s_loaiba) + ") and mavp in (" + aidcd.Trim().Trim(',') + ") ");//and paid=0
                        }
                        else if (tmn_Thuchidinh.Checked && !thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and mavp in (" + aidcd.Trim().Trim(',') + ") and " + exp);//and paid=0 
                        }
                        if (tmn_Vienphikhoa.Checked && !thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and done=0 and mavp in (" + aidcd.Trim().Trim(',') + ") ");
                        }
                        else if (tmn_Vienphikhoa.Checked && thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + m_mavaovien + ") and mavp in (" + aidcd.Trim().Trim(',') + ") ");
                        }
                        if ((tmn_Toathuoctutruc.Checked || tmn_Thuocthuongquy.Checked) && !thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + amavaovien + ") and mabd in (" + aidcd.Trim().Trim(',') + ")");
                            //binh 130511
                            try
                            {
                                if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                    m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                            }
                            catch { }

                        }
                        else if ((tmn_Toathuoctutruc.Checked || tmn_Thuocthuongquy.Checked) && thutheodot_mavaovien)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + m_mavaovien + ") and mabd in (" + aidcd + ") ");
                            //binh 130511
                            try
                            {
                                if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                    m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                            }
                            catch { }
                        }
                        if (tmn_Khoatonghop.Checked)
                        {
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid.ToString() + "  where mabn='" + amabn + "' and maql=" + amaql + " and " + exp);
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and mavp in (" + aidcd + ") ");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and mavp in (" + aidcd + ") ");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and mabd in (" + aidcd + ") ");
                            //binh 130511
                            try
                            {
                                if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                    m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                            }
                            catch { }
                        }
                        else//
                        {
                            //cap nhat v_thvpll: khi chi phi phong luu lo chuyen xuong vien phi
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + amavaovien + ") and makp in(select makp from medibv.btdkp_bv where loai <>1) ");
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid.ToString() + " where id in(select id from medibvmmyy.v_thvpll where mabn='" + amabn + "' and (maql=" + amaql + " or mavaovien=" + amavaovien + ")) and mavp in (" + aidcd.Trim().Trim(',') + ") and makp in(select makp from medibv.btdkp_bv where loai <>1)");
                        }
                    }
                }
                m_id = aid;
                if (m_id == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this, lan.Change_language_MessageText("Lỗi lưu dữ liệu!") + "\n" + lan.Change_language_MessageText("Chưa lưu dược hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    f_Enable(false);
                    f_Enable_HC(false);
                    if (tmn_Luuin_Hoadon_Icon.Checked)
                    {
                        if (tmn_Luuin_Hoadon.Checked)
                        {
                            if (asua)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại hoá đơn vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inhoadon(bdichvu);
                                }
                            }
                            else
                            {
                                f_Inhoadon(bdichvu);
                            }
                        }
                        if (tmn_Luuin_Phieuthuchi.Checked)
                        {
                            if (asua)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại phiếu thu chi vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inphieuthuchi();
                                }
                            }
                            else
                            {
                                f_Inhoadon(bdichvu);
                            }
                        }
                        if (tmn_Luuin_Chiphi.Checked)
                        {
                            if (asua)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại chi phí vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inchiphi();
                                }
                            }
                            else
                            {
                                f_Inchiphi();
                            }
                        }
                    }
                    butMoi.Focus();
                }
            }
            catch (Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_LUU_BHYT");
            }
        }

        private void f_Sua()
        {
            try
            {
                if (m_v.bhyt_suahoadon(m_userid))
                {
                    // gam 21-04-2011
                    //if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))

                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, (cbKyhieu.SelectedValue == null && b_hddathu ? m_sohieu : cbKyhieu.SelectedValue.ToString()), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép sửa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        f_Enable(true);
                        f_Enable_HC(false);
                        b_sua = false;
                        b_upd_bhytkb = false;
                        txtTenvp.Focus();
                        dgGia.Visible = false;
                        //txtMabn.Enabled = false;
                        //txtMabn1.Enabled = false;
                        tmn_Danhsachcho.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Sua_BHYT");
            }
        }

        private void f_Xoa()
        {
            try
            {
                if (m_v.bhyt_xoahoadon(m_userid))
                {
                    string ammyy = txtNgaythu.Value.Month.ToString().PadLeft(2, '0') + txtNgaythu.Value.Year.ToString().Substring(2);
                    // gam 21-04-2011
                    //if (m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_hoantra where quyenso=" + cbKyhieu.SelectedValue.ToString() + " and sobienlai=" + txtSobienlai.Text.Trim() + "").Tables[0].Rows.Count > 0)
                    if (m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_hoantra where quyenso=" + (cbKyhieu.SelectedValue == null && b_hddathu ? m_sohieu : cbKyhieu.SelectedValue.ToString()) + " and sobienlai=" + txtSobienlai.Text.Trim() + "").Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(this, "Hoá đơn này đã hoàn trả. Không thể Xóa!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.bhytkb where done=1 and quyenso=" + (cbKyhieu.SelectedValue == null && b_hddathu ? m_sohieu : cbKyhieu.SelectedValue.ToString()) + " and sobienlai=" + txtSobienlai.Text.Trim() + "").Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(this, "Thuốc trong hoá đơn này đã phát. Không thể Xóa!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Nếu xoá xem như hoá đơn chưa phát sinh, sẽ không có trong báo cáo") + "\n" + lan.Change_language_MessageText("Nếu hoàn xem như hoá đơn đã phát sinh và không có giá trị sử dụng, có trong báo cáo hoàn.") + "\n" + lan.Change_language_MessageText("Đồng ý xoá hoá đơn này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            #region region_event
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".bhyt", "mabn='" + txtMabn.Text + txtMabn1.Text + "'");
                                m_v.upd_eve_tables(ammyy, itablebhyt, int.Parse(m_userid), "upd");
                                m_v.upd_eve_upd_del(ammyy, itablebhyt, int.Parse(m_userid), "upd", s);
                            }
                                                        
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".bhytcls", "id=" + m_id);
                                m_v.upd_eve_tables(ammyy, itablecls, int.Parse(m_userid), "upd");
                                m_v.upd_eve_upd_del(ammyy, itablecls, int.Parse(m_userid), "upd", s);
                            }
                            
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".bhytkb", "id=" + m_id + " and mabn='" + txtMabn.Text + txtMabn1.Text + "'");
                                m_v.upd_eve_tables(ammyy, itablekb, int.Parse(m_userid), "upd");
                                m_v.upd_eve_upd_del(ammyy, itablekb, int.Parse(m_userid), "upd", s);
                            }

                            if (m_id != "0")
                            {
                                foreach (DataRow r in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.bhytthuoc where id=" + m_id + "").Tables[0].Rows)
                                {
                                    string s = m_v.fields(m_v.user + ammyy + ".bhytthuoc", "id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                                    m_v.upd_eve_tables(ammyy, itablethuoc, int.Parse(m_userid), "upd");
                                    m_v.upd_eve_upd_del(ammyy, itablethuoc, int.Parse(m_userid), "upd", s);
                                }
                            }
                            //
                            
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".v_ttrvds", "id=" + m_id + " and mabn='" + txtMabn.Text + txtMabn1.Text + "'");
                                m_v.upd_eve_tables(ammyy, itableds, int.Parse(m_userid), "upd");
                                m_v.upd_eve_upd_del(ammyy, itableds, int.Parse(m_userid), "upd", s);
                            }

                          
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".v_ttrvll", "id=" + m_id);
                                m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "upd");
                                m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "upd", s);
                            }
                          
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".v_ttrvbhyt", "id=" + m_id);
                                m_v.upd_eve_tables(ammyy, itablettrvbhyt, int.Parse(m_userid), "upd");
                                m_v.upd_eve_upd_del(ammyy, itablettrvbhyt, int.Parse(m_userid), "upd", s);
                            }

                          
                            if (m_id != "0")
                            {
                                foreach (DataRow r in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvct where id=" + m_id + "").Tables[0].Rows)
                                {
                                    string s = m_v.fields(m_v.user + ammyy + ".v_ttrvct", "id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                                    m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "upd");
                                    m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "upd", s);
                                }
                            }
                            #endregion //linh
                            string id_tonghop = "-1";
                            foreach (DataRow r in m_v.get_data("select distinct idtonghop from " + m_v.user + ammyy + ".v_ttrvll where id=" + m_id).Tables[0].Rows)
                            {
                                id_tonghop = Math.Abs(decimal.Parse(r["idtonghop"].ToString())).ToString();
                                break;
                            }
                            if (id_tonghop != "-1")
                            {
                                string asql1 = "update medibvmmyy.bhytkb set quyenso=0,sobienlai=0,done=0 where id=" + id_tonghop;
                                if (thutheongay || thutheodot_mavaovien)
                                {
                                    asql1 += " or mavaovien=" + m_mavaovien;
                                }
                                //khuyen 22/03/14 m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_chidinh set idttrv=0 where maql=" + m_maql + " and idttrv=" + m_id + " and mavp in(select mavp from medibvmmyy.v_ttrvct where id=" + m_id + ")");//paid=0,
                                //khuyen 22/03/14 update paid=0
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_chidinh set idttrv=0 and paid=0 where maql=" + m_maql + " and idttrv=" + m_id + " and mavp in(select mavp from medibvmmyy.v_ttrvct where id=" + m_id + ")");//paid=0,


                                m_v.execute_data_mmyy(ammyy, asql1);
                                m_v.del_v_ttrvll(ammyy, cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), m_id, txtMabn.Text + txtMabn1.Text, cbNgayvv.SelectedValue.ToString(), cbKhoavv.SelectedValue.ToString(), "");
                                


                            }
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set done='c' where maql=" + m_maql + " and mabn=" + txtMabn.Text + txtMabn1.Text + " and done is null");
                            f_Load_Thutrongngay();
                            f_Clear_HC();
                            m_dshoadon.Tables[0].Rows.Clear();
                            m_dstamung.Tables[0].Rows.Clear();
                            f_Clear_pTonghop();
                            f_Tinhtien(-1);
                            f_Enable(false);
                            f_Enable_HC(false);
                            butMoi.Focus();
                        }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền xóa."), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {
            }
        }
        private void f_Inhoadon()
        {
            try
            {
                if (m_id != "")
                {

                    m_frmprinthd.f_Print_BienlaiNGT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", txtMabn.Text.Trim() + txtMabn1.Text.Trim(), txtNgaythu.Text.Substring(0, 10), txtSothe.Text, cmbTraituyen.SelectedIndex, decimal.Parse(toolStrip_Tongcong.Text));

                }
            }
            catch
            {
            }
        }
        private void f_Inhoadon(bool bInHDdichvu)
        {
            try
            {
                if (m_id != "")
                {

                    m_frmprinthd.f_Print_BienlaiNGT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", txtMabn.Text.Trim() + txtMabn1.Text.Trim(), txtNgaythu.Text.Substring(0, 10), txtSothe.Text, cmbTraituyen.SelectedIndex, decimal.Parse(toolStrip_Tongcong.Text),bInHDdichvu);

                }
            }
            catch
            {
            }
        }
        private void f_Inphieuthuchi()
        {
            try
            {
                if (m_id != "")
                {
                    m_frmprinthd.f_Print_BienlaiNgTru_Thuchi(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
                }
            }
            catch
            {
            }
        }
        private void f_Inchiphi()
        {
            try
            {
                if (tmn_in38_thuphi.Checked)
                {
                    m_frmprinthd.f_Print_ChiphiTTRVNgtruCT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien, decimal.Parse(toolStrip_CongkhamBHYT.Text.Trim()));
                    m_frmprinthd.Dispose();
                    m_frmprinthd = new frmPrintHD(m_v, m_userid);
                    m_frmprinthd.f_Print_ChiphiKBCT_1(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien);
                }
                else
                {
                    m_frmprinthd.f_Print_ChiphiTTRVNgtruCT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien, decimal.Parse(toolStrip_CongkhamBHYT.Text.Trim()));
                }
            }
            catch
            {
            }
        }
        private void f_Boqua()
        {
            try
            {
                f_Enable_HC(false);
                f_Enable(false);
            }
            catch
            {
            }
        }
        private void f_Hoan()
        {
            try
            {
                if (m_v.bhyt_hoanhoadon(m_userid))
                {
                    frmHoantra m_frmhoantra = new frmHoantra(m_v, m_userid);
                    if (m_id != "")
                    {
                        m_frmhoantra.s_sohoadon = txtSobienlai.Text;
                        m_frmhoantra.s_ngay = txtNgaythu.Value;
                    }
                    //gam 21-04-2011
                    //m_frmhoantra.s_quyenso = cbKyhieu.SelectedValue.ToString();
                    m_frmhoantra.s_quyenso = (cbKyhieu.SelectedValue == null && b_hddathu ? m_sohieu : cbKyhieu.SelectedValue.ToString());
                    m_frmhoantra.s_ngaythu = txtNgaythu.Text.Substring(0, 10);
                    m_frmhoantra.s_ngayhoan = m_v.f_ngay10(m_cur_ngay);
                    m_frmhoantra.ShowDialog();
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không được phép hoàn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Hoan_BHYT");
            }
        }
        private void f_Filter_Giavp()
        {
            try
            {
                string aft = "";
                if (txtTenvp.Text != "")
                {
                    aft = "ma like '%" + txtTenvp.Text.Trim() + "%' or ten like '%" + txtTenvp.Text.Trim() + "%' or dvt like '%" + txtTenvp.Text.Trim() + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgGia.DataSource, dgGia.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                if (dgGia.Visible == false && this.ActiveControl == txtTenvp)
                {
                    dgGia.Visible = true;
                }
            }
            catch
            {
            }
        }
        private void f_Filter_Quyenso()
        {
            try
            {
                string aft = "";
                if (tmn_Locsotheoloai.Checked)
                {
                    aft = " (loai like '%" + cbLoaidv.SelectedValue.ToString() + "%' or loai ='' or loai is null) ";
                }
                if (!tmn_Dungchungso.Checked ) 
                {
                    if (aft != "")
                    {
                        aft += " and ";
                    }
                    aft += "userid = " + m_userid;
                }
                if (m_v.sys_SBLtu_den)
                {
                    if (aft != "")
                    {
                        aft += " and ";
                    }
                    aft += "( soghi >= tu-1 ) and ( soghi < den )";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbKyhieu.DataSource]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                if (cbKyhieu.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "Hết sổ, đề nghị chọn sổ mới!\n Đề nghị chọn sổ.", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Focus();
                    return;
                }
            }
            catch
            {
            }
        }
        private string f_Get_Sobienlai()
        {
            try
            {
                string art = "0:2"; bool bDasudung = false;
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" + (cbKyhieu.SelectedValue == null ? m_sohieu : cbKyhieu.SelectedValue.ToString())).Tables[0].Rows)
                {
                    art = r["soghi"].ToString();
                    bDasudung = bBienlai_dasudung(cbKyhieu.SelectedValue.ToString(), art);
                    if (bDasudung) break;
                    if (decimal.Parse(r["soghi"].ToString()) > decimal.Parse(r["den"].ToString()))
                    {
                        art += ":1";
                    }
                    else
                    {
                        art += ":0";
                    }
                    break;
                }
                if (bDasudung)
                {
                    m_v.execute_data("update medibv.v_quyenso set soghi=soghi+1 where id =" + cbKyhieu.SelectedValue.ToString());
                    art = f_Get_Sobienlai();
                }
                return art;
            }
            catch
            {
                return "0:2";
            }
        }
        private void f_Get_Item()
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituongTD.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r = dv.Table.Select("madoituong=" + cbDoituongTD.SelectedValue.ToString())[0];
                DataRowView arv = (DataRowView)(dgGia.CurrentRow.DataBoundItem);
                m_id_gia = arv["id"].ToString();
                txtDongia.Text = arv[r["field_gia"].ToString().Trim()].ToString();
                txtTenvp.Text = arv["ten"].ToString();
                f_Tinhtien_mon();
            }
            catch//(Exception ex)
            {
                m_id_gia = "";
                //MessageBox.Show(ex.ToString());
            }
        }
        private void f_Add_Chon(string v_id)
        {
            if (v_id == "")
            {
                return;
            }
            try
            {
                string afieldgia = "gia_th";
                decimal adongia = 0, asoluong = 0, asotien = 0;
                foreach (string aid in v_id.Split(','))
                {
                    foreach (DataRow r1 in m_dsgiavp.Tables[0].Select("id =" + aid))
                    {
                        try
                        {
                            try
                            {
                                adongia = decimal.Parse(r1[afieldgia].ToString().Replace(",", ""));
                                if (adongia < 0)
                                {
                                    adongia = 0;
                                }
                            }
                            catch
                            {
                                adongia = 0;
                            }
                            asoluong = 1;
                            asotien = asoluong * adongia;

                            string aexp = "mavp=" + r1["id"].ToString() + " and dongia=" + adongia.ToString();
                            if (m_dshoadon.Tables[0].Select(aexp).Length <= 0)
                            {
                                DataRow r = m_dshoadon.Tables[0].NewRow();
                                r["ma"] = r1["ma"].ToString();
                                r["ten"] = r1["ten"].ToString();
                                r["dvt"] = r1["dvt"].ToString();
                                r["soluong"] = asoluong;
                                r["dongia"] = adongia;
                                r["sotien"] = 0;
                                r["bhyttra"] = 0;
                                r["bntra"] = 0;
                                r["mavp"] = r1["id"].ToString();
                                m_dshoadon.Tables[0].Rows.Add(r);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                f_Tinhtien(-1);
            }
            catch
            {
            }
        }
        private decimal f_Get_Tyle_BHYT(string v_madoituong, string v_mavp, string v_sothe)
        {
            //gam 15/08/2011
            string s_vitri_xet_chiphivanchuyen = d.thetunguyen_vitri(1);
            int iKytubegin_xet_chiphivanchuyen = 0, ikytuend_xet_chiphivanchuyen = 0;
            try
            {
                iKytubegin_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(0, 1));
                ikytuend_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(2, 1));

            }
            catch
            {
                iKytubegin_xet_chiphivanchuyen = 0;
                ikytuend_xet_chiphivanchuyen = 2;
            }
            //end gam
            decimal atyle = 0;
            try
            {
                if (v_madoituong == "1")
                {
                    DataRow dr1 = m_v.getrowbyid(m_dsgiavp.Tables[0], "id=" + v_mavp);
                    if (dr1 != null)
                    {
                        if (dr1["sothe"].ToString().Trim() != "" && dr1["sothe"].ToString().Trim().IndexOf(v_sothe.Substring(iKytubegin_xet_chiphivanchuyen, ikytuend_xet_chiphivanchuyen)) >= 0)
                            atyle = 1;
                        else
                            atyle = 0;
                    }
                }
            }
            catch
            {
                atyle = 0;
            }
            return atyle;
        }
        private decimal f_Get_Tyle_BHYT(string v_madoituong, string v_mavp)
        {
           
            decimal atyle = 0;
            try
            {
                if (m_doituongmien.IndexOf("," + v_madoituong + ",") >= 0 || v_madoituong == "1")
                {
                    if (v_madoituong == "1")
                    {
                        atyle = decimal.Parse(m_dsgiavp.Tables[0].Select("id=" + v_mavp)[0]["bhyt"].ToString());
                        atyle = atyle / 100;
                    }
                    else
                    {
                        atyle = m_dsgiavp.Tables[0].Select("ndm=0 and id=" + v_mavp).Length > 0 ? 1 : 0;
                    }
                }
            }
            catch
            {
                atyle = 0;
            }
            return atyle;
        }
    
        #region son w them vao doan kiem tra the bhyt moi(THANH TOAN 80%).
        private int f_get_Tylebhytchitra(decimal v_sotien)
        {
            int tyletmp = 100;
            if (txtSothe.Text != "")
            {
                int maphu = m_v.get_maphu_ngtru(txtSothe.Text, v_sotien, m_v.nhom_duoc);
                tyletmp = (maphu == 1) ? 80 : (maphu == 2) ? 95 : 100;
            }
            return tyletmp;
        }    
        #endregion

        private DateTime f_String_To_Date(string v_ngay)
        {
            try
            {
                return new DateTime(int.Parse(v_ngay.Substring(6, 4)), int.Parse(v_ngay.Substring(3, 2)), int.Parse(v_ngay.Substring(0, 2)));
            }
            catch
            {
                return DateTime.Now;
            }
        }
        private void f_Add()
        {
            if (m_id_gia == "")
            {
                return;
            }
            try
            {
                if (cbDoituongTD.SelectedIndex < 0)
                {
                    cbDoituongTD.SelectedValue = "1";
                }
                decimal adongia = 0, asoluong = 0, asotien = 0;
                try
                {
                    adongia = decimal.Parse(txtDongia.Text.Trim().Replace(",", ""));
                    if (adongia < 0)
                    {
                        adongia = 0;
                    }
                }
                catch
                {
                    adongia = 0;
                }
                try
                {
                    asoluong = decimal.Parse(txtSoluong.Text.Trim().Replace(",", ""));
                    //if (asoluong < 0)
                    //{
                    //    asoluong = 1;
                    //}
                }
                catch
                {
                    asoluong = 0;
                }
                asotien = asoluong * adongia;
                string aexp = "";
                foreach (DataRow r0 in m_dsgiavp.Tables[0].Select("id=" + m_id_gia))
                {
                    aexp = "mavp=" + r0["id"].ToString() + " and dongia=" + adongia.ToString();
                    if (m_dshoadon.Tables[0].Select(aexp).Length <= 0)
                    {
                        DataRow r = m_dshoadon.Tables[0].NewRow();
                        r["ma"] = r0["ma"].ToString();
                        r["ten"] = r0["ten"].ToString();
                        r["dvt"] = r0["dvt"].ToString();
                        r["soluong"] = asoluong;
                        r["dongia"] = adongia;
                        r["sotien"] = 0;
                        r["bhyttra"] = 0;
                        r["bntra"] = 0;
                        r["mavp"] = r0["id"].ToString();
                        m_dshoadon.Tables[0].Rows.Add(r);
                    }
                }
                m_id_gia = "";
                f_Tinhtien(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Rem()
        {
            try
            {
                m_dshoadon.Tables[0].Rows.RemoveAt(dgHoadon.CurrentCell.RowIndex);
                m_dshoadon.AcceptChanges();
                f_Tinhtien(-1);
            }
            catch
            {
            }
        }
        private void f_Tinhtien_mon()
        {
            try
            {
                decimal adongia = 0, asoluong = 0;
                try
                {
                    adongia = decimal.Parse(txtDongia.Text.Trim().Replace(",", ""));
                    if (adongia < 0)
                    {
                        adongia = 0;
                    }
                }
                catch
                {
                    adongia = 0;
                }
                try
                {
                    asoluong = decimal.Parse(txtSoluong.Text.Trim().Replace(",", ""));
                    if (asoluong < 0)
                    {
                        asoluong = 1;
                    }
                }
                catch
                {
                    asoluong = 1;
                }
                txtDongia.Text = adongia.ToString("###,###,##0.##").Trim();
                txtSoluong.Text = asoluong.ToString("###,###,##0.##").Trim();
            }
            catch
            {
            }
        }
         private void f_Tinhtien(decimal v_asotien)// v_asotien <=0 tính tỷ lệ bhyt chi trả dựa vào tổng chi phí trong m_dshoadon, nếu v_asotien > 0 tính tỷ lệ bhyt chi trả đựa vào tổng tiền truyền vào
        {
            //khuyen 21/03/14
            string s_mien = toolStrip_Mien.Text.Trim();
            decimal phantram =0,mien=0,tongso=0;
             try
            {
                
                if (s_mien.IndexOf("%") > 0)
                {
                   phantram = decimal.Parse(toolStrip_Thucthu.Text.Trim());
                     mien = decimal.Parse(s_mien.Trim('%'));
                     tongso = phantram * mien / 100;
                   
                }
                else
                {
                tongso=decimal.Parse(s_mien);
                }
            }
            catch
            {
                toolStrip_Mien.Text = "";
            }
            //
            try

            {
                bool bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
                bool bTraituyen_bhtra = m.bTraituyen_bhtra;//true: trai tuyen tinh theo: ty le the * ty le trai tuyen
                decimal asoluong = 0, adongia = 0, asotien = 0, abhtra = 0, abntra = 0, atongcp = 0, atongbhyttra = 0, atongbntra = 0, acongkhambhyt = 0, atamung = 0, atongsocp = 0, atyle = 0;
                decimal amientong = 0;
                decimal d_cpvc = 0;
                i_tylechinhsach = 0;
                bool TraiTuyenKhongTinhTyLe = false;//gam 14/02/2012 dung kiem tra neu chi phi tu ngay 16/02/2012 và có chọn option G92. thì gán biến = true => không tính tỷ lệ BHYT chi tra
                try
                {
                    m_dshoadon.Tables[0].Columns.Add("mien",typeof(decimal)).DefaultValue = 0;
                }
                catch { }//gam 12/10/2011
                foreach (DataRow r in m_dsnhomvp.Tables[0].Rows)
                {
                    r["sotien"] = 0;
                }
                if (v_asotien > 0)
                {
                    asotien = v_asotien;
                }
                else
                {
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        if (r["madoituong"].ToString() == "1")
                        {
                            try
                            {
                                adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
                                if (adongia < 0)
                                {
                                    adongia = 0;
                                }
                            }
                            catch
                            {
                                adongia = 0;
                            }
                            try
                            {
                                asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
                            }
                            catch
                            {
                                asoluong = 0;
                            }
                            asotien += Math.Round(asoluong * adongia, 2);
                        }
                    }
                    
                }
                get_tongchiphi_datra(txtMabn.Text + txtMabn1.Text, m_mavaovien, txtNgaythu.Text, txtSothe.Text);
                //
                if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && !bTraituyen_bhtra) atyle = iTraituyen;
                else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && asotien > m_v.ma13_st(m_v.nhom_duoc))
                {
                    atyle = f_get_Tylebhytchitra(9999999);
                    atyle = atyle * decimal.Parse(iTraituyen.ToString()) / 100;
                }
                else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && asotien <= m_v.ma13_st(m_v.nhom_duoc))
                {
                    atyle = decimal.Parse(iTraituyen.ToString());
                }
                else atyle = f_get_Tylebhytchitra(asotien + zsotien_datra);
                decimal dtyle = 0;
                bool bKhongcungchitra = false;
                decimal d_dichvu_tt = 0, d_dichvu_tt_bhyt_tra = 0;
                decimal amien = 0,atongmien = 0;
                if (cmbTraituyen.SelectedIndex == 0)
                {
                    i_tylechinhsach = m.get_tyle_bhyt_chinhsach(txtSothe.Text);
                }
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    try
                    {
                        adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
                        if (adongia < 0)
                        {
                            adongia = 0;
                        }
                    }
                    catch
                    {
                        adongia = 0;
                    }
                    try
                    {
                        asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
                    }
                    catch
                    {
                        asoluong = 0;
                    }
                    asotien = Math.Round(asoluong * adongia, 2);
                    //tinh chi phi van chuyen nhung the ma BHYT cho huong 100%
                    if (m.StringToDate(r["ngay"].ToString()) >= m.StringToDate("15/02/2012") && CongthucTraiTuyen160212 && cmbTraituyen.SelectedIndex != 0)
                    {
                        TraiTuyenKhongTinhTyLe = true;
                    }
                    else
                    {
                        TraiTuyenKhongTinhTyLe = false;
                    }
                    DataRow r1 = null;
                    try { r1 = m_dsgiavp.Tables[0].Select("id='" + r["mavp"].ToString() + "'")[0]; }
                    catch { r1 = null; }
                    //	
                    bKhongcungchitra = false; d_dichvu_tt_bhyt_tra = 0; d_dichvu_tt = 0;
                    if (r1 != null)
                    {
                        //chi phi van chuyen tinh theo the 100%
                        if (!TraiTuyenKhongTinhTyLe )
                        {
                            dtyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString(), txtSothe.Text);//chi phi van chuyen 100% tra ve 1
                        }
                        else
                        {
                            dtyle = 0;
                        }
                        
                        if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bBHYT_Traituyen_tinh_Tyle_khac && decimal.Parse(r1["bhyt"].ToString()) > decimal.Parse(r1["bhyt_tt"].ToString()))
                        {
                            bKhongcungchitra = true;
                            d_dichvu_tt = asotien;
                            if (!TraiTuyenKhongTinhTyLe)
                            {
                                d_dichvu_tt_bhyt_tra = asotien * decimal.Parse(r1["bhyt_tt"].ToString()) / 100;
                            }
                            else
                            {
                                d_dichvu_tt_bhyt_tra = 0;
                            }
                            
                        }
                        if (dtyle > 0) d_cpvc += asotien;
                        if (r["madoituong"].ToString() == "7") // truongthuy 20052014 BN bo doi  MIEN 100%
                        {
                            abhtra = 0;
                            abntra = 0;
                            amien = asotien;
                        }
                        else
                        {
                            abhtra = (asotien - d_dichvu_tt) * dtyle + d_dichvu_tt_bhyt_tra;
                            abntra = asotien - abhtra;
                            amien = abntra * i_tylechinhsach / 100;
                            abntra = abntra;
                        }
                    }
                    // f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                    if (dtyle == 0)
                    {
                        if (!TraiTuyenKhongTinhTyLe)
                        {
                            dtyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());//100% tra ve 1
                        }
                        else
                        {
                            dtyle = 0;
                        }
                        if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bBHYT_Traituyen_tinh_Tyle_khac && decimal.Parse(r1["bhyt"].ToString()) > decimal.Parse(r1["bhyt_tt"].ToString()))
                        {
                            bKhongcungchitra = true;
                            d_dichvu_tt = asotien;
                            if (!TraiTuyenKhongTinhTyLe)
                            {
                                d_dichvu_tt_bhyt_tra = asotien * decimal.Parse(r1["bhyt_tt"].ToString()) / 100;
                            }
                            else
                            {
                                d_dichvu_tt_bhyt_tra = 0;
                            }
                        }
                        abhtra = (asotien - d_dichvu_tt) * dtyle + d_dichvu_tt_bhyt_tra;
                        if (r["madoituong"].ToString() == "1" && atyle != 100 ) abhtra = abhtra * (bKhongcungchitra ? 100 : atyle) / 100;
                       // truong thuy them doi voi BN bộ dội BHYT trả 100% 20052014
                        else if(r["madoituong"].ToString() == "7")
                        {
                            abhtra = 0;
                            abntra = 0;
                            amien = asotien;

                        }
 
                        else if (m_doituongmien.IndexOf("," + r["madoituong"].ToString() + ",") != -1 && !TraiTuyenKhongTinhTyLe)
                        {
                            amien = asotien;//Thuy 13.05.2013
                            abhtra = 0;
                            abntra = 0;
                        }
                        else
                        {
                            abntra = asotien - abhtra;
                            amien = abntra * i_tylechinhsach / 100;
                            abntra = abntra;
                        }
                    }
                    //
                    
                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["sotien"] = asotien;
                    r["bntra"] = abntra;
                    r["bhyttra"] = abhtra;
                    r["mien"] = amien;

                    try
                    {
                        string aid_nhom = m_dsgiavp.Tables[0].Select("id=" + r["mavp"].ToString())[0]["id_nhom"].ToString();
                        foreach (DataRow rn in m_dsnhomvp.Tables[0].Select("id='" + aid_nhom+"'"))
                        {
                            rn["sotien"] = (decimal.Parse(rn["sotien"].ToString()) + asotien);
                        }
                    }
                    catch
                    {
                    }

                    atongbntra += abntra ;
                    atongbhyttra += abhtra;
                    atongcp += asotien;
                    atongmien += amien;
                    
                }

                toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##");//truongthuy 20052014
              //  toolStrip_Mien.Text = tongso.ToString("###,###,##0.##");//21/03/14khuyen
               try
                {
                    amientong = decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", ""));//truongthuy 20052014
                  //  amientong = decimal.Parse(tongso.ToString().Trim().Replace(",", ""));////21/03/14khuyen
                }
                catch
                {
                    amientong = 0;
                }
                toolStrip_Mien.ReadOnly = (!butLuu.Enabled && atongmien > 0);
                if (atongmien <= 0 && amientong > 0)
                {
                    toolStrip_Mien.ReadOnly = !butLuu.Enabled;
                    //atongmien = amientong;//21/03/14khuyen chuyen ra ngoai ham if
                }
                atongmien = amientong;//21/03/14khuyen
                if (atongmien > atongbntra)
                {
                    toolStrip_Mien.ReadOnly = !butLuu.Enabled;
                    //atongmien = atongbntra;
                    //atongbntra = 0;

                    
                }
                if (d_cpvc > 0 && !b_datinh_cpvc && (atongcp - d_cpvc) < m_v.ma13_st(m_v.nhom_duoc))
                {
                    b_datinh_cpvc = true;
                    f_Tinhtien(atongcp - d_cpvc);
                    return;
                }
                m_dshoadon.AcceptChanges();

                atamung = decimal.Parse(txtTamung.Text.Replace(",", ""));

                //atongbhyttra = atongbhyttra * f_get_Tylebhytchitra(atongbhyttra) / 100;
                atongbntra = atongcp - atongbhyttra - atongmien;
                try
                {
                    acongkhambhyt = decimal.Parse(get_congkhambhyt().Tables[0].Rows[0]["sotien"].ToString());
                    toolStrip_CongkhamBHYT.Text = acongkhambhyt.ToString("###,###,##0.##");
                }
                catch
                {
                    toolStrip_CongkhamBHYT.Text = "0";
                }

                string s_ngay_7_cn = ((DateTime)(m_v.s_server_date)).DayOfWeek.ToString().ToUpper();

                if (dBhyt_Chitra_Toida_7CN != 0 && (s_ngay_7_cn == DayOfWeek.Saturday.ToString().ToUpper() || s_ngay_7_cn == DayOfWeek.Sunday.ToString().ToUpper()))
                {
                    if (atongcp + zsotien_datra > dBhyt_Chitra_Toida_7CN)
                    {
                        atongbhyttra = dBhyt_Chitra_Toida_7CN;
                        //atongbhyttra = (atongcp+zsotien_datra <= dBhyt_Chitra_Toida_7CN) ? atongcp+zsotien_datra : dBhyt_Chitra_Toida_7CN;
                        atongbntra = atongcp + zsotien_datra - atongbhyttra - zbhyt_datra;
                    }
                }
                else if (lTraituyen != 0 && cmbTraituyen.SelectedIndex != 0 && atongbhyttra > lTraituyen)
                {
                    decimal tc = atongbhyttra + atongbntra;
                    atongbhyttra = decimal.Parse(lTraituyen.ToString());
                    atongbntra = tc - atongbhyttra;
                }
                atongsocp = atongbntra - atamung;
                //

                //
                if (atongsocp < 0)
                {
                    toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
                    txtPhaithu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
                    lbBNTra.Text = lan.Change_language_MessageText("Phải hoàn:");
                    lbPhaithu.Text = lan.Change_language_MessageText("Phải hoàn:");
                }
                else
                {
                    toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##");
                    txtPhaithu.Text = atongsocp.ToString("###,###,##0.##");
                    lbBNTra.Text = lan.Change_language_MessageText("Phải thu:");
                    lbPhaithu.Text = lan.Change_language_MessageText("Phải thu:");
                }
               
                toolStrip_Tamung.Text = atamung.ToString("###,###,##0.##");

                toolStrip_BHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                toolStrip_Tongcong.Text = atongcp.ToString("###,###,##0.##");
                toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##");


                txtCongkham.Text = acongkhambhyt.ToString("###,###,##0.##");
                txtCPBHYT.Text = atongcp.ToString("###,###,##0.##");
                txtMienBHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                txtBNTra_BHYT.Text = atongbntra.ToString("###,###,##0.##");
                txtTamung.Text = atamung.ToString("###,###,##0.##");
                try
                {
                    foreach (Control c in m_table.Controls)
                    {
                        if (c.Name.IndexOf("tbma_") == 0)
                        {
                            try
                            {
                                c.Text = decimal.Parse(m_dsnhomvp.Tables[0].Select("id=" + c.Name.Replace("tbma_", ""))[0]["sotien"].ToString()).ToString("###,###,##0.##");
                                if (c.Text == "0")
                                {
                                    c.Text = "";
                                }
                            }
                            catch
                            {
                                c.Text = "";
                            }
                            c.BackColor = (c.Text != "") ? Color.LightYellow : Color.White;
                        }
                    }
                }
                catch
                {
                }

            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                toolStrip_CongkhamBHYT.Text = "0";
                toolStrip_Tongcong.Text = "0";
                toolStrip_BHYT.Text = "0";
                toolStrip_Thucthu.Text = "0";
                toolStrip_Mien.Text = "0";
            }
        }

        /// <summary>
        /// v_asotien <= 0 tính tỷ lệ bhyt chi trả dựa vào tổng chi phí trong m_dshoadon; nếu v_asotien > 0 tính tỷ lệ bhyt chi trả đựa vào tổng tiền truyền vào
        /// </summary>
        /// <param name="v_asotien"></param>
        /// 
        #region  khuyen dong 08/04/2014 do khong load len so tien mien
        //private void f_Tinhtien(decimal v_asotien)
        //{
        //    //khuyen 21/03/14
        //    string s_mien = toolStrip_Mien.Text.Trim();
        //    decimal phantram = 0, mien = 0, tongso = 0;
        //    try
        //    {

        //        if (s_mien.IndexOf("%") > 0)
        //        {
        //            phantram = decimal.Parse(toolStrip_Thucthu.Text.Trim());
        //            mien = decimal.Parse(s_mien.Trim('%'));
        //            tongso = phantram * mien / 100;

        //        }
        //        else
        //        {
        //            tongso = decimal.Parse(s_mien);
        //        }
        //    }
        //    catch
        //    {
        //        toolStrip_Mien.Text = "";
        //    }
        //    //

        //    try
        //    {
        //        bool bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
        //        bool bTraituyen_bhtra = m.bTraituyen_bhtra;//true: trai tuyen tinh theo: ty le the * ty le trai tuyen
        //        decimal asoluong = 0, adongia = 0, asotien = 0, abhtra = 0, abntra = 0, atongcp = 0, atongbhyttra = 0, atongbntra = 0, acongkhambhyt = 0, atamung = 0, atongsocp = 0, atyle = 0;
        //        decimal amientong = 0;
        //        decimal d_cpvc = 0;
        //        i_tylechinhsach = 0;
        //        //Theo cong van: ngay 16/02/2012: BHYT qui dinh doi voi PK, BV tu nhan --> BN BHYT trai tuyen khong duoc huong quyen loi BHYT, ma tat ca la thu phi, bn tu lay chiphi do ve co quan bhyt cua minh de duoc thanh toan lai
        //        //Sau nay khong thay BV nao con ap dung cong van nay --> nen bien nay luon lay gia false --> de BHYT tinh dung tuyen, trai tuyen nhu qui dinh
        //        bool TraiTuyenKhongTinhTyLe = false;//gam 14/02/2012 dung kiem tra neu chi phi tu ngay 16/02/2012 và có chọn option G92. thì gán biến = true => không tính tỷ lệ BHYT chi tra
        //        try
        //        {
        //            m_dshoadon.Tables[0].Columns.Add("mien",typeof(decimal)).DefaultValue = 0;
        //        }
        //        catch { }//gam 12/10/2011
        //        //reset dataset chi phi theo nhom - hien thi tren man hinh tong hop
        //        foreach (DataRow r in m_dsnhomvp.Tables[0].Rows)
        //        {
        //            r["sotien"] = 0;
        //        }
        //        if (v_asotien > 0)
        //        {
        //            asotien = v_asotien;
        //        }
        //        else
        //        {
        //            //Lay tong Chi Phi BHYT 
        //            foreach (DataRow r in m_dshoadon.Tables[0].Rows)
        //            {
        //                if (r["madoituong"].ToString() == "1")
        //                {
        //                    try
        //                    {
        //                        adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
        //                        if (adongia < 0)
        //                        {
        //                            adongia = 0;
        //                        }
        //                    }
        //                    catch
        //                    {
        //                        adongia = 0;
        //                    }
        //                    try
        //                    {
        //                        asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
        //                    }
        //                    catch
        //                    {
        //                        asoluong = 0;
        //                    }
        //                    asotien += Math.Round(asoluong * adongia, 2);
        //                }
        //            }
                    
        //        }
        //        //Tinh tong so tien ma BHYT tra tren hoa don truoc, theo mavaovien 
        //        //muc dinh: lay tong tien hien tai, va tong tien thu truoc do de tinh vuot nguong BHYT
        //        // Vi du: hoa don truoc 200.000 > nguong; chi phi chuan bi thu: co tong la 50.000 < nguong --> nen phai cong them hoa don da thu: 200k+50k > vuot nguong --< tinh dong chi tra lai cho 50k chi phi chờ thu
        //        get_tongchiphi_datra(txtMabn.Text + txtMabn1.Text, m_mavaovien, txtNgaythu.Text, txtSothe.Text);
        //        //
        //        //Lay ty le BHYT tra
        //        if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && !bTraituyen_bhtra) atyle = iTraituyen;//lay ty le bhyt tra tuyen tra
        //        else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && asotien > m_v.ma13_st(m_v.nhom_duoc))
        //        {                    
        //            atyle = f_get_Tylebhytchitra(9999999);
        //            atyle = atyle * decimal.Parse(iTraituyen.ToString()) / 100;
        //        }
        //        else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && asotien <= m_v.ma13_st(m_v.nhom_duoc))
        //        {
        //            atyle = decimal.Parse(iTraituyen.ToString());
        //        }
        //        else atyle = f_get_Tylebhytchitra(asotien + zsotien_datra);
        //        //
        //        decimal dtyle = 0;
        //        bool bKhongcungchitra = false;
        //        decimal d_dichvu_tt = 0, d_dichvu_tt_bhyt_tra = 0;
        //        decimal amien = 0,atongmien = 0;
        //        if (cmbTraituyen.SelectedIndex == 0)
        //        {
        //            //Phan ti le ngan sach ho tro them: vi du, TPHCM co cong van: BN BHYT the CN6 --> Nha nuoc ho tro them 15%, BN chi tra 5% --> 15% se chuyen vao phan mien (ben hepa: dua vao cot ngansachhotro)
        //            i_tylechinhsach = m.get_tyle_bhyt_chinhsach(txtSothe.Text);
        //        }
        //        foreach (DataRow r in m_dshoadon.Tables[0].Rows)
        //        {
        //            amien = 0;
        //            try
        //            {
        //                adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
        //                if (adongia < 0)
        //                {
        //                    adongia = 0;
        //                }
        //            }
        //            catch
        //            {
        //                adongia = 0;
        //            }
        //            try
        //            {
        //                asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
        //            }
        //            catch
        //            {
        //                asoluong = 0;
        //            }
        //            asotien = Math.Round(asoluong * adongia, 2);
        //            //Tinh cho option G92 (medisoft)
        //            // BN trai tuyen khong duoc BHYT chi tra, ma bn tu lam vien voi BHYT, BV xem nhu la BN thu phi (ap dung doi BV, PK tu nhan)
        //            if (m.StringToDate(r["ngay"].ToString()) >= m.StringToDate("15/02/2012") && CongthucTraiTuyen160212 && cmbTraituyen.SelectedIndex != 0)
        //            {
        //                TraiTuyenKhongTinhTyLe = true;
        //            }
        //            else
        //            {
        //                TraiTuyenKhongTinhTyLe = false;
        //            }
        //            //Tinh ti le BHYT tra theo tung dich vu
        //            DataRow r1 = null;
        //            try { r1 = m_dsgiavp.Tables[0].Select("id='" + r["mavp"].ToString() + "'")[0]; }
        //            catch { r1 = null; }
        //            //	
        //            bKhongcungchitra = false; d_dichvu_tt_bhyt_tra = 0; d_dichvu_tt = 0;
        //            if (r1 != null)
        //            {
        //                //chi phi van chuyen tinh theo the 100%
        //                if (!TraiTuyenKhongTinhTyLe )
        //                {
        //                    dtyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString(), txtSothe.Text);//chi phi van chuyen 100% tra ve 1
        //                }
        //                else
        //                {
        //                    dtyle = 0;
        //                }
                        
        //                if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bBHYT_Traituyen_tinh_Tyle_khac && decimal.Parse(r1["bhyt"].ToString()) > decimal.Parse(r1["bhyt_tt"].ToString()))
        //                {
        //                    bKhongcungchitra = true;
        //                    d_dichvu_tt = asotien;
        //                    if (!TraiTuyenKhongTinhTyLe)
        //                    {
        //                        d_dichvu_tt_bhyt_tra = asotien * decimal.Parse(r1["bhyt_tt"].ToString()) / 100;
        //                    }
        //                    else
        //                    {
        //                        d_dichvu_tt_bhyt_tra = 0;
        //                    }
                            
        //                }
        //                if (dtyle > 0) d_cpvc += asotien;
        //                abhtra = (asotien - d_dichvu_tt) * dtyle + d_dichvu_tt_bhyt_tra;
        //                abntra = asotien - abhtra;
        //                if (i_tylechinhsach > 0) amien = abntra * i_tylechinhsach / 100; 
        //                abntra = abntra ;
        //            }
        //            // f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
        //            if (dtyle == 0)
        //            {
        //                if (!TraiTuyenKhongTinhTyLe)
        //                {
        //                    dtyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());//100% tra ve 1
        //                }
        //                else
        //                {
        //                    dtyle = 0;
        //                }
        //                if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bBHYT_Traituyen_tinh_Tyle_khac && decimal.Parse(r1["bhyt"].ToString()) > decimal.Parse(r1["bhyt_tt"].ToString()))
        //                {
        //                    bKhongcungchitra = true;
        //                    d_dichvu_tt = asotien;
        //                    if (!TraiTuyenKhongTinhTyLe)
        //                    {
        //                        d_dichvu_tt_bhyt_tra = asotien * decimal.Parse(r1["bhyt_tt"].ToString()) / 100;
        //                    }
        //                    else
        //                    {
        //                        d_dichvu_tt_bhyt_tra = 0;
        //                    }
        //                }
        //                abhtra = (asotien - d_dichvu_tt) * dtyle + d_dichvu_tt_bhyt_tra;
        //                if (r["madoituong"].ToString() == "1" && atyle != 100)
        //                {
        //                    abhtra = abhtra * (bKhongcungchitra ? 100 : atyle) / 100;
        //                    abntra = asotien - abhtra;
        //                    amien = abntra * i_tylechinhsach / 100;
        //                    abntra = abntra;
        //                }
        //                else if (m_doituongmien.IndexOf("," + r["madoituong"].ToString() + ",") != -1 && !TraiTuyenKhongTinhTyLe)
        //                {
        //                    amien = asotien;//Thuy 13.05.2013
        //                    abhtra = 0;
        //                    abntra = 0;
        //                }
        //                else
        //                {
        //                    abntra = asotien - abhtra;
        //                    amien = abntra * i_tylechinhsach / 100;
        //                    abntra = abntra;
        //                }
        //            }
        //            //
                    
        //            r["soluong"] = asoluong;
        //            r["dongia"] = adongia;
        //            r["sotien"] = asotien;
        //            r["bntra"] = abntra;
        //            r["bhyttra"] = abhtra;
        //            r["mien"] = amien;

        //            try
        //            {
        //                string aid_nhom = m_dsgiavp.Tables[0].Select("id=" + r["mavp"].ToString())[0]["id_nhom"].ToString();
        //                foreach (DataRow rn in m_dsnhomvp.Tables[0].Select("id='" + aid_nhom+"'"))
        //                {
        //                    rn["sotien"] = (decimal.Parse(rn["sotien"].ToString()) + asotien);
        //                }
        //            }
        //            catch
        //            {
        //            }

        //            atongbntra += abntra ;
        //            atongbhyttra += abhtra;
        //            atongcp += asotien;
        //            atongmien += amien;
                    
        //        }
                
        //        //   toolStrip_Mien.Text = atongmien .ToString("###,###,##0.##");//21/03/14khuyen
        //        toolStrip_Mien.Text = tongso.ToString("###,###,##0.##");//21/03/14khuyen

        //        try
        //        {
        //            // amientong = decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", ""));//21/03/14khuyen
        //            amientong = decimal.Parse(tongso.ToString().Trim().Replace(",", ""));////21/03/14khuyen

                    
        //        }
        //        catch
        //        {
        //            amientong = 0;
        //        }
        //        toolStrip_Mien.ReadOnly = (!butLuu.Enabled && atongmien > 0);
        //        if (atongmien <= 0 && amientong > 0)
        //        {
        //            toolStrip_Mien.ReadOnly = !butLuu.Enabled;
        //            //atongmien = amientong;//21/03/14khuyen chuyen ra ngoai ham if
        //        }
        //        atongmien = amientong;//21/03/14khuyen

        //        if (atongmien > atongbntra)
        //        {
        //            toolStrip_Mien.ReadOnly = !butLuu.Enabled;
        //            //atongmien = atongbntra;
        //            //atongbntra = 0;                    
        //        }
        //        if (d_cpvc > 0 && !b_datinh_cpvc && (atongcp - d_cpvc) < m_v.ma13_st(m_v.nhom_duoc))
        //        {
        //            b_datinh_cpvc = true;
        //            f_Tinhtien(atongcp - d_cpvc);
        //            return;
        //        }
        //        m_dshoadon.AcceptChanges();

        //        atamung = decimal.Parse(txtTamung.Text.Replace(",", ""));

        //        //atongbhyttra = atongbhyttra * f_get_Tylebhytchitra(atongbhyttra) / 100;
        //        atongbntra = atongcp - atongbhyttra - atongmien;
        //        try
        //        {
        //            acongkhambhyt = decimal.Parse(get_congkhambhyt().Tables[0].Rows[0]["sotien"].ToString());
        //            toolStrip_CongkhamBHYT.Text = acongkhambhyt.ToString("###,###,##0.##");
        //        }
        //        catch
        //        {
        //            toolStrip_CongkhamBHYT.Text = "0";
        //        }

        //        string s_ngay_7_cn = ((DateTime)(m_v.s_server_date)).DayOfWeek.ToString().ToUpper();

        //        if (dBhyt_Chitra_Toida_7CN != 0 && (s_ngay_7_cn == DayOfWeek.Saturday.ToString().ToUpper() || s_ngay_7_cn == DayOfWeek.Sunday.ToString().ToUpper()))
        //        {
        //            if (atongcp + zsotien_datra > dBhyt_Chitra_Toida_7CN)
        //            {
        //                atongbhyttra = dBhyt_Chitra_Toida_7CN;
        //                //atongbhyttra = (atongcp+zsotien_datra <= dBhyt_Chitra_Toida_7CN) ? atongcp+zsotien_datra : dBhyt_Chitra_Toida_7CN;
        //                atongbntra = atongcp + zsotien_datra - atongbhyttra - zbhyt_datra;
        //            }
        //        }
        //        else if (lTraituyen != 0 && cmbTraituyen.SelectedIndex != 0 && atongbhyttra > lTraituyen)
        //        {
        //            decimal tc = atongbhyttra + atongbntra;
        //            atongbhyttra = decimal.Parse(lTraituyen.ToString());
        //            atongbntra = tc - atongbhyttra;
        //        }
        //        atongsocp = atongbntra - atamung;
        //        //

        //        //
        //        if (atongsocp < 0)
        //        {
        //            toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
        //            txtPhaithu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
        //            lbBNTra.Text = lan.Change_language_MessageText("Phải hoàn:");
        //            lbPhaithu.Text = lan.Change_language_MessageText("Phải hoàn:");
        //        }
        //        else
        //        {
        //            toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##");
        //            txtPhaithu.Text = atongsocp.ToString("###,###,##0.##");
        //            lbBNTra.Text = lan.Change_language_MessageText("Phải thu:");
        //            lbPhaithu.Text = lan.Change_language_MessageText("Phải thu:");
        //        }
               
        //        toolStrip_Tamung.Text = atamung.ToString("###,###,##0.##");

        //        toolStrip_BHYT.Text = atongbhyttra.ToString("###,###,##0.##");
        //        toolStrip_Tongcong.Text = atongcp.ToString("###,###,##0.##");
        //        toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##");


        //        txtCongkham.Text = acongkhambhyt.ToString("###,###,##0.##");
        //        txtCPBHYT.Text = atongcp.ToString("###,###,##0.##");
        //        txtMienBHYT.Text = atongbhyttra.ToString("###,###,##0.##");
        //        txtBNTra_BHYT.Text = atongbntra.ToString("###,###,##0.##");
        //        txtTamung.Text = atamung.ToString("###,###,##0.##");
        //        try
        //        {
        //            foreach (Control c in m_table.Controls)
        //            {
        //                if (c.Name.IndexOf("tbma_") == 0)
        //                {
        //                    try
        //                    {
        //                        c.Text = decimal.Parse(m_dsnhomvp.Tables[0].Select("id=" + c.Name.Replace("tbma_", ""))[0]["sotien"].ToString()).ToString("###,###,##0.##");
        //                        if (c.Text == "0")
        //                        {
        //                            c.Text = "";
        //                        }
        //                    }
        //                    catch
        //                    {
        //                        c.Text = "";
        //                    }
        //                    c.BackColor = (c.Text != "") ? Color.LightYellow : Color.White;
        //                }
        //            }
        //        }
        //        catch
        //        {
        //        }

        //    }
        //    catch//(Exception ex)
        //    {
        //        //MessageBox.Show(ex.ToString());
        //        toolStrip_CongkhamBHYT.Text = "0";
        //        toolStrip_Tongcong.Text = "0";
        //        toolStrip_BHYT.Text = "0";
        //        toolStrip_Thucthu.Text = "0";
        //        toolStrip_Mien.Text = "0";
        //    }
        //}
        #endregion
     
        private DataSet get_congkhambhyt()
        {
            
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituongTD.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r = dv.Table.Select("madoituong=" + cbDoituongTD.SelectedValue.ToString())[0];
                v_dongiabhyt = r["field_gia"].ToString();
            }
            catch
            { 
            }
            DataSet ads = new DataSet();
            int solankham = 1;
            string sql = "";
            if (thutheongay)
            {
                sql = "select count(*) from medibvmmyy.benhanpk where mabn='" + txtMabn.Text.Trim() + txtMabn1.Text.Trim() + "' and to_char(ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and makp in (select makp from medibvmmyy.bhytkb where mabn='" + txtMabn.Text.Trim() + txtMabn1.Text.Trim() + "' and to_char(ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and quyenso=0)";
                solankham = int.Parse(m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), sql).Tables[0].Rows[0][0].ToString());
                if (solankham == 0) solankham = 1;
            }
            s_mavp_congkham = s_mavp_congkham == "" ? "-1" : s_mavp_congkham;

            sql = "select ma,ten,dvt,to_number(" + solankham + ",0) as soluong," + v_dongiabhyt + " as dongia, to_number(0,'9') as giaban, to_number(0,'9') as gia_bh, " + solankham + "* " + v_dongiabhyt + " as sotien,to_number(0,'9') as bhyttra, to_number(0,9) as bntra, id as mavp, to_number(1) as madoituong from medibv.v_giavp where id=" + s_mavp_congkham;
            ads=m_v.get_data(sql);
            return ads;
        }

        private void f_Load_Thutrongngay()
        {
            try
            {
                string sql = "", ammyy = "";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                decimal asotien = 0, asohd = 0;
                //linh
                //sql = "select sum(a.congkham + a.cls + a.bhyttra + a.bntra + a.thuoc) as sotien from medibvmmyy.bhytkb a where a.userid="+m_userid+" and to_char(a.ngay,'dd/mm/yyyy')='"+txtNgaythu.Text.Substring(0,10)+"'";
                sql = "select sum(a.sotien-a.bhyt-a.mien-a.thieu) as sotien from medibvmmyy.v_ttrvll a where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and a.loaithu=1 ";
                try
                {
                    asotien = decimal.Parse(m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    asotien = 0;
                }
                //linh
                //sql = "select count(distinct a.id) as sohd from medibvmmyy.bhytkb a where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                sql = "select count(distinct a.id) as sohd from medibvmmyy.v_ttrvll a where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and a.loaithu=1 ";
                try
                {
                    asohd = decimal.Parse(m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    asohd = 0;
                }

                tmn_Tongthu.Text = (bKhongchoxem_tongthu) ? "" : asohd.ToString() + "=" + asotien.ToString("###,###,##0.##") + lan.Change_language_MessageText("đ");
                tmn_Tongthu.ToolTipText = (bKhongchoxem_tongthu) ? "" : m_v.Doiso_Unicode(asotien.ToString("#########")).Replace("  ", " ");
            }
            catch
            {
                tmn_Tongthu.Text = lan.Change_language_MessageText("0=0đ");
                tmn_Tongthu.ToolTipText = lan.Change_language_MessageText("Không đồng");
            }
        }

        private void f_Load_Hoadon(string v_id, string v_mmyy)
        {
            try
            {
                if (v_id == "") return;
                v_id = decimal.Parse(v_id).ToString();
                string sql = "", ammyy = "";
                ammyy = v_mmyy;
                if (ammyy == "")  ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                sql = "select a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp," +
                    " '' as mabs,a.maicd,a.chandoan,e.sothe,e.maphu,e.mabv,g.quyenso,g.sobienlai,b.ma,b.ten,b.dvt," +
                    " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra,a1.mavp,"+
                    "coalesce(e.traituyen,0) as traituyen ,b.dichvu,b2.sotien as tongmien,b2.maduyet,b2.lydo " +
                    " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id " +
                    " inner join medibvmmyy.v_ttrvct a1 on a.id=a1.id inner join medibvmmyy.v_ttrvbhyt e on a.id=e.id" +
                    " inner join medibv.v_giavp b on a1.mavp=b.id left join medibvmmyy.v_mienngtru b2 on a.id=b2.id where a.id = " + v_id;
                DataSet ads = m_v.get_data_mmyy(ammyy, sql);
                sql = "select a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp," +
                    " '' as mabs,a.maicd,a.chandoan,e.sothe,e.maphu,e.mabv,g.quyenso,g.sobienlai,b.ma,b.ten||' '||b.hamluong as ten,b.dang as dvt," +
                    " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra," +
                    " a1.mabd as mavp,coalesce(e.traituyen,0) as traituyen,to_number(0) as dichvu ,b2.sotien as tongmien,b2.maduyet,b2.lydo from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id " +
                    " inner join medibvmmyy.v_ttrvct a1 on a.id=a1.id " +
                    " inner join medibv.d_dmbd b on a1.mavp=b.id inner join medibvmmyy.v_ttrvbhyt e on a.id=e.id left join medibvmmyy.v_mienngtru b2 on a.id=b2.id " +
                    " where a.id = " + v_id;
                DataSet ads1 = m_v.get_data_mmyy(ammyy, sql);
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
                m_mavaovien = "";
                m_maql = "";
                if (ads.Tables[0].Rows.Count > 0)
                {
                    m_mavaovien = ads.Tables[0].Rows[0]["mavaovien"].ToString();
                    m_maql = ads.Tables[0].Rows[0]["maql"].ToString();

                    txtMabn.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(0, 2);
                    txtMabn1.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(2);
                    txtMabn1_Validated(null, null);
                    try
                    {
                        cbNgayvv.SelectedValue = ads.Tables[0].Rows[0]["maql"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbKyhieu.SelectedValue = ads.Tables[0].Rows[0]["quyenso"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbLoaibn.SelectedValue = ads.Tables[0].Rows[0]["loaiba"].ToString();
                    }
                    catch
                    {
                    }
                    //gam 21/11/2011
                    try
                    {
                        toolStrip_Mien.Text = decimal.Parse(ads.Tables[0].Rows[0]["tongmien"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        toolStrip_Mien.Text = "0";
                    }
                    try
                    {
                        txtLydomien.Text = ads.Tables[0].Rows[0]["lydo"].ToString().Trim();
                    }
                    catch
                    {
                        txtLydomien.Text = "";
                    }
                    try
                    {
                        txtKymien.Text = ads.Tables[0].Rows[0]["maduyet"].ToString().Trim();
                    }
                    catch
                    {
                        txtKymien.Text = "";
                    }
                    //end gam 21/11/2011
                    traituyen = cmbTraituyen.SelectedIndex= int.Parse(ads.Tables[0].Rows[0]["traituyen"].ToString());
                    txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    txtNgaythu.Value = m_v.f_parse_date(ads.Tables[0].Rows[0]["ngaythu"].ToString());
                    txtNDK_Ma.Text = ads.Tables[0].Rows[0]["mabv"].ToString();
                    txtSothe.Text = ads.Tables[0].Rows[0]["sothe"].ToString();
                    txtICD.Text = ads.Tables[0].Rows[0]["maicd"].ToString();
                    txtChandoan.Text = ads.Tables[0].Rows[0]["chandoan"].ToString();
                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("mavaovien");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loaiba");
                    ads.Tables[0].Columns.Remove("ngaythu");
                    ads.Tables[0].Columns.Remove("makp");
                    //ads.Tables[0].Columns.Remove("mabs");
                    ads.Tables[0].Columns.Remove("chandoan");
                    ads.Tables[0].Columns.Remove("maicd");
                    ads.Tables[0].Columns.Remove("sothe");
                    ads.Tables[0].Columns.Remove("maphu");
                    ads.Tables[0].Columns.Remove("mabv");
                    ads.Tables[0].Columns.Remove("traituyen");
                    m_dshoadon = ads;
                    dgHoadon.DataSource = m_dshoadon.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien(-1);
                    m_id = v_id;
                }
                f_Enable(m_id == "" || m_id == "0");
                butLuu_EnabledChanged(null, null);
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_HoaDon");
                m_mavaovien = "";
                m_maql = "";
            }
        }
        private void f_Load_Hoadon_thuroi(string v_id, string v_mmyy, string v_mabn, string v_ngaythu,string vp_mavaovien)
        {
            try
            {
                if (v_id == "") return;
                v_id = decimal.Parse(v_id).ToString();
                string sql = "", ammyy = "",aquyenso = "";
                ammyy = v_mmyy;
                if (ammyy == "")  ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                DataSet ads, ads1;

                sql = "select a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp,";
                sql += " '' mabs,a.maicd,a.chandoan,e.sothe,e.maphu,e.mabv,g.quyenso,g.sobienlai,b.ma,b.ten,b.dvt,";
                sql += " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra,a1.mavp,tamung,a1.madoituong,";
                sql += " coalesce(e.traituyen,0) as traituyen,b.dichvu,f.ma nhom,b2.sotien as tongmien,b2.maduyet,b2.lydo ";
                sql += " , to_char(a1.ngay,'dd/MM/yyyy') as ngay ";//gam 14/02/2012
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id inner join ";
                sql += " medibvmmyy.v_ttrvct a1 on a.id=a1.id inner join ";
                sql += " medibv.v_giavp b on a1.mavp=b.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id ";
                sql += " inner join medibv.v_loaivp e1 on b.id_loai=e1.id inner join medibv.v_nhomvp f on e1.id_nhom=f.ma";
                sql += " left join medibvmmyy.v_mienngtru b2 on a.id=b2.id ";
                sql += " where a.id = " + v_id;
                ads = m_v.get_data_mmyy(ammyy, sql);

                sql = "select a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp,";
                sql += " '' as mabs,a.maicd,a.chandoan,e.sothe,e.maphu,e.mabv,g.quyenso,g.sobienlai,b.ma,b.ten||' '||b.hamluong as ten,b.dang as dvt,";
                sql += " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra,";
                sql += " a1.mavp,tamung,a1.madoituong,coalesce(e.traituyen,0) as traituyen,to_number(0) as dichvu,e1.nhomvp nhom ";
                sql += ",b2.sotien as tongmien,b2.maduyet,b2.lydo ";
                sql += " , to_char(a1.ngay,'dd/MM/yyyy') as ngay ";//gam 14/02/2012
                sql += "from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id";
                sql += " inner join medibvmmyy.v_ttrvct a1 on a.id=a1.id ";
                sql += " inner join medibv.d_dmbd b on a1.mavp=b.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id ";
                sql += " inner join medibv.d_dmnhom e1 on b.manhom=e1.id ";
                sql += " left join medibvmmyy.v_mienngtru b2 on a.id=b2.id ";
                sql += " where a.id = " + v_id;
                ads1 = m_v.get_data_mmyy(ammyy, sql);
               
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
                m_mavaovien = "";
                m_maql = "";
                aquyenso = ads.Tables[0].Rows[0]["quyenso"].ToString();
                if (ads.Tables[0].Rows.Count > 0)
                {
                    m_mavaovien = ads.Tables[0].Rows[0]["mavaovien"].ToString();
                    m_maql = ads.Tables[0].Rows[0]["maql"].ToString();

                    txtMabn.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(0, 2);
                    txtMabn1.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(2);
                    txtMabn1_Validated(null, null);

                    
                    m_sohieu = aquyenso;
                    b_hddathu = true;

                    try
                    {
                        cbNgayvv.SelectedValue = ads.Tables[0].Rows[0]["maql"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbKyhieu.SelectedValue = aquyenso;
                    }
                    catch ( Exception ex)
                    {

                    }
                    try
                    {
                        cbLoaibn.SelectedValue = ads.Tables[0].Rows[0]["loaiba"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        txtTamung.Text = decimal.Parse(ads.Tables[0].Rows[0]["tamung"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        txtTamung.Text = "0";
                    }
                    //gam 21/11/2011
                    try
                    {
                        toolStrip_Mien.Text = decimal.Parse(ads.Tables[0].Rows[0]["tongmien"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        toolStrip_Mien.Text = "0";
                    }
                    try
                    {
                        txtLydomien.Text = ads.Tables[0].Rows[0]["lydo"].ToString().Trim();
                    }
                    catch
                    {
                        txtLydomien.Text = "";
                    }
                    try
                    {
                        txtKymien.Text = ads.Tables[0].Rows[0]["maduyet"].ToString().Trim();
                    }
                    catch
                    {
                        txtKymien.Text = "";
                    }
                    //end gam 21/11/2011
                    cmbTraituyen.SelectedIndex= traituyen = int.Parse(ads.Tables[0].Rows[0]["traituyen"].ToString());
                    txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    txtNgaythu.Value = m_v.f_parse_date(ads.Tables[0].Rows[0]["ngaythu"].ToString());
                    txtNDK_Ma.Text = ads.Tables[0].Rows[0]["mabv"].ToString();
                    txtSothe.Text = ads.Tables[0].Rows[0]["sothe"].ToString();
                    txtICD.Text = ads.Tables[0].Rows[0]["maicd"].ToString();
                    txtChandoan.Text = ads.Tables[0].Rows[0]["chandoan"].ToString();
                    txtKhoavv.Text = ads.Tables[0].Rows[0]["makp"].ToString();
                    cbKhoavv.SelectedValue = ads.Tables[0].Rows[0]["makp"].ToString();
                   
                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("mavaovien");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loaiba");
                    ads.Tables[0].Columns.Remove("ngaythu");
                    ads.Tables[0].Columns.Remove("makp");
                    ads.Tables[0].Columns.Remove("mabs");
                    //ads.Tables[0].Columns.Remove("chandoan");
                    ads.Tables[0].Columns.Remove("maicd");
                    ads.Tables[0].Columns.Remove("sothe");
                    ads.Tables[0].Columns.Remove("maphu");
                    ads.Tables[0].Columns.Remove("mabv");
                    ads.Tables[0].Columns.Remove("traituyen");
                    m_dshoadon = ads;
                    dgHoadon.DataSource = m_dshoadon.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien(-1);
                    m_id = v_id;
                }
                f_Enable(m_id == "" || m_id == "0");
                //dgHoadon_CellClick(null, null);
                butLuu_EnabledChanged(null, null);
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_HoaDon_Roi");
                m_mavaovien = "";
                m_maql = "";
            }
        }
        private void f_Load_Hoadon_NextPre(int v_pre)
        {
            try
            {
                string sql = "", ammyy = "", asobienlai = "", aexp = "", aid = "";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                aexp = " a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                if (m_id != "" && m_id != "0")
                {
                    try
                    {
                        //asobienlai = decimal.Parse(m_v.get_data_mmyy(ammyy,"select sobienlai from medibvmmyy.bhytkb where id = " + m_id).Tables[0].Rows[0][0].ToString()).ToString();
                        asobienlai = decimal.Parse(m_v.get_data_mmyy(ammyy, "select sobienlai from medibvmmyy.v_ttrvll where id = " + m_id).Tables[0].Rows[0][0].ToString()).ToString();
                    }
                    catch
                    {
                        asobienlai = "";
                    }
                    if (asobienlai != "")
                    {
                        if (v_pre < 0)
                        {
                            aexp += " and a.sobienlai < " + asobienlai + " order by a.sobienlai desc limit 1";
                        }
                        else
                        {
                            aexp += " and a.sobienlai > " + asobienlai + " order by a.sobienlai asc limit 1";
                        }
                    }
                    else
                    {
                        if (v_pre < 0)
                        {
                            aexp += " order by a.sobienlai asc limit 1";
                        }
                        else
                        {
                            aexp += " order by a.sobienlai desc limit 1";
                        }
                    }
                }
                //sql = "select a.id from medibvmmyy.bhytkb a where " + aexp;
                sql = "select a.id from medibvmmyy.v_ttrvll a where " + aexp;
                try
                {
                    aid = decimal.Parse(m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows[0][0].ToString()).ToString();
                }
                catch
                {
                    aid = "";
                }
                if (aid == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText(
"Không tìm thấy hoá đơn ") + (v_pre < 0 ? lan.Change_language_MessageText(
"trước") : lan.Change_language_MessageText(
"sau")) + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    f_Load_Hoadon(aid, ammyy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_BHYT()
        {
            try
            {
                cmbTraituyen.SelectedIndex= traituyen = 0;
                txtSothe.Text = txtTN.Text = txtDN.Text = txtNDK_Ma.Text = txtNDK_Ten.Text = "";
                string amaql = "", atn = "";
                try
                {
                    amaql = decimal.Parse(cbNgayvv.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    return;
                }
                atn = m_v.f_string_date((cbNgayvv.Text.Length > 10) ? cbNgayvv.Text.Substring(0, 10) : atn); // m_v.f_string_date(atn);
                if (atn.Length >= 10)  atn = atn.Substring(0, 10);
                else  atn = txtNgaythu.Text.Substring(0, 10);
                string sql = "";
                sql = "select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tn, to_char(a.denngay,'dd/mm/yyyy') as dn,a.mabv,b.tenbv,a.maphu,a.traituyen from medibv.bhyt a left join medibv.dmnoicapbhyt b on a.mabv=b.mabv where a.maql = " + amaql;
                sql += " union all select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tn, to_char(a.denngay,'dd/mm/yyyy') as dn,a.mabv,b.tenbv,a.maphu,a.traituyen from medibvmmyy.bhyt a left join medibv.dmnoicapbhyt b on a.mabv=b.mabv where a.maql = " + amaql;
                foreach (DataRow r in m_v.get_data_bc_1(atn, txtNgaythu.Text.Substring(0, 10), sql, 1).Tables[0].Rows)
                {
                    cmbTraituyen.SelectedIndex= traituyen = int.Parse(r["traituyen"].ToString());
                    txtSothe.Text = r["sothe"].ToString();
                    txtTN.Text = r["tn"].ToString();
                    txtDN.Text = r["dn"].ToString();
                    txtNDK_Ma.Text = r["mabv"].ToString();
                    txtNDK_Ten.Text = r["tenbv"].ToString();
                    break;
                }
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_BHYT");
            }
        }
        private void f_Load_Chidinh(string v_tn, string v_maql, bool v_laylaisolieu)
        {
            string s_loaiba = "";
            b_datinh_cpvc = false;//gam 18/08/2011

            s_loaiba += (tmn_Cokhambenh.Checked) ? "3," : "";
            s_loaiba += (tmn_Cophongluu.Checked) ? "4," : "";
            s_loaiba += (tmn_conamngoaitru.Checked) ? "2," : "";
            s_loaiba += (tmn_Conhanbenh.Checked) ? "1," : "";
            s_loaiba = s_loaiba.Trim().Trim(',');
            try
            {
                try
                {
                    v_maql = decimal.Parse(v_maql).ToString();
                }
                catch
                {
                    return;
                }

                string sql = "", aexp = "";
                v_tn = m_v.f_string_date(v_tn);
                if (v_tn.Length >= 10)
                {
                    v_tn = v_tn.Substring(0, 10);
                }
                else
                {
                    v_tn = txtNgaythu.Text.Substring(0, 10);
                }

                //Chi dinh
                DataSet ads = null, ads1 = null;
                try
                {
                    m_maql_tiepdon = (m_mavaovien != "") ? m_v.get_maql_tiepdon(m_mavaovien, txtMabn.Text + txtMabn1.Text, v_tn).ToString() : v_maql;
                }
                catch { }

                f_Load_Tamung(v_tn, v_maql);
                string exp1 = "";
                if (!tmn_khongcungchitra.Checked)
                    exp1 = "=1 ";
                else
                    exp1 = "<>1 ";
                if (tmn_Thuchidinh.Checked)
                {
                    if (thutheongay)
                    {
                        aexp = " where a.mabn='" + txtMabn.Text.Trim() + txtMabn1.Text.Trim() + "' and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' ";
                    }
                    else if (thutheodot_mavaovien)
                    {
                        aexp = " where (a.maql in( " + v_maql + "," + m_mavaovien + ") or a.mavaovien in(" + m_mavaovien + ")) ";
                    }
                    else
                    {
                        aexp = " where a.maql in( " + v_maql + "," + m_mavaovien + ") ";
                    }
                    if (s_loaiba.Trim().Trim() != "") aexp += " and a.loaiba in (" + s_loaiba + ")";
                    if (!v_laylaisolieu)
                    {
                        aexp += " and a.paid=0 and a.idttrv=0";
                    }
                    else aexp += " and a.idttrv!=0";

                   
                        if (m_doituongthu.Trim() != "")
                        {
                            aexp += " and a.madoituong in(" + m_doituongthu.Trim().Trim(',') + ")";
                        }
                   
                    sql = "select b.ma, b.ten, b.dvt, a.soluong, a.dongia, to_number(0,'9') as giaban, to_number(0,'9') as gia_bh, a.soluong*a.dongia as sotien, to_number(0,'9') as bhyttra, to_number(0,'9') as bntra, a.mavp, a.madoituong ,0 as loai,b.dichvu,f.ma nhom ";
                    sql += ",to_char(a.ngay,'dd/MM/yyyy') as ngay,a.mabs, a.id as idtonghop, to_number('0') as stttonghop ";//gam 14/02/2012
                    sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp ";
                    sql += "inner join medibv.v_loaivp e on b.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma" + aexp;
                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
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
                if (m_v.bhyt_inchiphihen(m_userid))
                {
                    aexp = " where a.madoituong" + exp1 + " and paid=0 and a.maql = " + m_mavaovien;
                    sql = "select b.ma, b.ten, b.dvt, a.soluong, a.dongia, to_number(0,'9') as giaban, to_number(0,'9') as gia_bh, a.soluong*a.dongia as sotien, to_number(0,'9') as bhyttra, to_number(0,'9') as bntra, a.mavp, a.madoituong, 0 as loai,b.dichvu,f.ma as nhom ";
                    sql += ",to_char(a.ngay,'dd/MM/yyyy') as ngay,a.mabs, a.id as idtonghop, to_number('0') as stttonghop ";//gam 14/02/2012
                    sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp";
                    sql += " inner join medibv.v_loaivp e on b.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma" + aexp;
                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
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
                if (tmn_Vienphikhoa.Checked)
                {
                    if (thutheongay)
                    {
                        aexp = " where  a.mabn='" + txtMabn.Text.Trim() + txtMabn1.Text.Trim() + "' and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                    }
                    else if (thutheodot_mavaovien)
                    {
                        aexp = " where  (a.maql in( " + v_maql + "," + m_mavaovien + ") or a.mavaovien in(" + m_mavaovien + "))";
                    }

                    else
                    {
                        aexp = " where  a.maql in( " + v_maql + "," + m_mavaovien + ")";
                    }
                    if (!v_laylaisolieu)
                    {
                        aexp += " and a.done=0";
                    }
                    if (m_doituongthu.Trim() != "")
                    {
                        aexp += " and a.madoituong in(" + m_doituongthu.Trim().Trim(',') + ")";
                    }
                    sql = "select b.ma, b.ten, b.dvt, a.soluong, a.dongia, to_number(0,'9') as giaban, to_number(0,'9') as gia_bh, a.soluong*a.dongia as sotien, to_number(0,'9') as bhyttra, to_number(0,'9') as bntra, a.mavp, a.madoituong ,0 as loai,b.dichvu,f.ma nhom ";
                    sql += ",to_char(a.ngay,'dd/MM/yyyy') as ngay,'' as mabs, a.id as idtonghop, to_number('0') as stttonghop ";//gam 14/02/2012
                    sql += "from medibvmmyy.v_vpkhoa a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp inner join medibv.v_loaivp e on b.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma " + aexp;
                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
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
                if (tmn_Thuocthuongquy.Checked)
                {
                    if (thutheongay)
                    {
                        aexp = " where  to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";
                    }
                    else if (thutheodot_mavaovien)
                    {
                        aexp = " where  (a.maql = " + v_maql + " or a.mavaovien=" + m_mavaovien + ")";
                    }
                    else
                    {
                        aexp = " where  a.maql = " + v_maql;
                    }
                    if (!v_laylaisolieu)
                    {
                        aexp += " and a.done=0";
                    }
                    if (m_doituongthu.Trim() != "")
                    {
                        aexp += " and a.madoituong in(" + m_doituongthu.Trim().Trim(',') + ")";
                    }
                    aexp += " and a.soluong<>0 ";
                    sql = "select b.ma, b.ten, b.dang as dvt, a.soluong, a.giamua as dongia, a.giaban, b.gia_bh, a.soluong*a.giamua as sotien, to_number(0,'9') as bhyttra,to_number(0,9) as bntra,a.mabd as mavp, a.madoituong,1 as loai,to_number(0) as dichvu,e.nhomvp as nhom ";
                    sql += ",to_char(a.ngay,'dd/MM/yyyy') as ngay,a.mabs, a.id as idtonghop, to_number('0') as stttonghop ";//gam 14/02/2012
                    sql += "from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp inner join medibv.d_dmnhom e on b.manhom=e.id " + aexp;
                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
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
                m_id_toathuocbhyt = "";
                if (tmn_DonthuocBHYT.Checked)
                {
                    if (thutheongay)
                    {
                        aexp = " where to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and a.mabn='" + txtMabn.Text + txtMabn1.Text + "' ";
                    }
                    else if (thutheodot_mavaovien)
                    {
                        aexp = " where (a.maql in( " + v_maql + "," + m_mavaovien + ") or a.mavaovien in(" + m_mavaovien + "))";
                    }
                    else
                    {
                        aexp = " where a.maql in( " + v_maql + "," + m_mavaovien + ")";
                    }
                    if (s_loaiba.Trim().Trim() != "") aexp += " and a.loaiba in (" + s_loaiba + ")";
                    if (!v_laylaisolieu)
                    {
                        aexp += " and a.quyenso=0";
                    }
                    if (cbDoituongTD.SelectedValue.ToString() == "7")
                    {
                        aexp += " and a.maphu in(" + cbDoituongTD.SelectedValue.ToString() + ")";
                    }
                    else
                    {
                        if (m_doituongthu.Trim() != "")
                        {
                            aexp += " and a.maphu in(" + m_doituongthu.Trim().Trim(',') + ")";
                        }
                    }
                    if (!tmn_khongcungchitra.Checked)
                    {
                        //thu phan chi phi BHYT + BN cung chi tra
                        if (bDuyet_khambenh || bDuyet_donvepl)//gam 05/11/2011
                        {
                           // sql = "select a.id, a.mabs,b.ma,b.ten,b.dang as dvt,a1.soluong,a1.giaban as dongia , a2.giaban, a1.gia_bh, ";//gam 10/10/2011 sửa d_theodoi.giamua as dongia = bhytthuoc.gia_bh as dongia => bn kontum cap toan F3 co ca doi tuong mien phi, gia duoc luu trong table bhytthuoc
                           // sql += " a1.soluong*a1.giaban as sotien, to_number(0,'9') as bhyttra, to_number(0,9) as bntra,a1.mabd as mavp,";

                            sql = "select a.id, a.mabs,b.ma,b.ten,b.dang as dvt,a1.soluong,a2.giamua as dongia , a2.giaban, a1.gia_bh, ";  //truongthuy 02/05/2014 Lấy giá mua để khớp với mẫu 01
                           sql += " a1.soluong*a2.giamua as sotien, to_number(0,'9') as bhyttra, to_number(0,9) as bntra,a1.mabd as mavp,";
                        
                        }
                        else if (bGia_bh_quydinh)
                        {
                            sql = "select a.id, a.mabs,b.ma,b.ten,b.dang as dvt,a1.soluong,a1.gia_bh as dongia , a2.giaban, a1.gia_bh, ";//gam 10/10/2011 sửa d_theodoi.giamua as dongia = bhytthuoc.gia_bh as dongia => bn kontum cap toan F3 co ca doi tuong mien phi, gia duoc luu trong table bhytthuoc
                            sql += " a1.soluong*a1.gia_bh as sotien, to_number(0,'9') as bhyttra, to_number(0,9) as bntra,a1.mabd as mavp,";
                        }
                        else
                        {
                            sql = "select a.id, a.mabs,b.ma,b.ten,b.dang as dvt,a1.soluong,a2.giamua as dongia , a2.giaban, a1.gia_bh, ";
                            sql += " a1.soluong*a2.giaban as sotien, to_number(0,'9') as bhyttra, to_number(0,9) as bntra,a1.mabd as mavp,";
                        }
                        sql += "a.maphu as madoituong,a2.giamua,1 as loai ";
                        sql += ", b.chenhlech,to_number(0) as dichvu,e.nhomvp as nhom ";
                        sql += ",to_char(a.ngay,'dd/MM/yyyy') as ngay,a.mabs, a.id as idtonghop, a1.stt as stttonghop ";//gam 14/02/2012
                        sql += " from medibvmmyy.bhytkb a inner join medibvmmyy.bhytthuoc a1 on a.id=a1.id ";
                        sql += " inner join medibvmmyy.d_theodoi a2 on a1.sttt=a2.id inner join medibv.d_dmbd b on a1.mabd=b.id ";
                        sql += " left join medibv.btdkp_bv c on a.makp=c.makp inner join medibv.d_dmnhom e on b.manhom=e.id " + aexp + "";
                        sql += " union all select a.id, a.mabs,b.ma,b.ten,b.dvt,a1.soluong,a1.dongia as dongia, ";
                        sql += "to_number(0,'9') as giaban, to_number(0,'9') as gia_bh ,a1.soluong*a1.dongia as sotien, ";
                        sql += " to_number(0,'9') as bhyttra, to_number(0,9) as bntra,a1.mavp as mavp, a.maphu as madoituong,a1.dongia as giamua,0 as loai ";
                        sql += ", b.chenhlech,b.dichvu,f.ma as nhom ";
                        sql += ",to_char(a.ngay,'dd/MM/yyyy') as ngay,a.mabs, a.id as idtonghop, a1.stt as stttonghop ";//gam 14/02/2012
                        sql += " from medibvmmyy.bhytkb a inner join medibvmmyy.bhytcls a1 on a.id=a1.id inner join medibv.v_giavp b ";
                        sql += " on a1.mavp=b.id left join medibv.btdkp_bv c on a.makp=c.makp ";
                        sql += "inner join medibv.v_loaivp e on b.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma " + aexp + "";
                        ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
                    }
                    else if (tmn_khongcungchitra.Checked)
                    {
                        //Cac doi tuong khac BHYT
                        sql = "select 0 as id,a.mabs,b.ma,b.ten,b.dang as dvt,a.soluong,a.giaban as dongia,a.giaban,";
                        sql += "to_number(0,'9') as gia_bh,a.giaban* a.soluong as sotien, to_number(0,'9') as bhyttra,";
                        sql += "a.soluong*a.giaban as bntra, a.mabd as mavp, a.madoituong,a.giamua, 1 as loai,to_number(0) as chenhlech,to_number(0) as dichvu,e.nhomvp as nhom ";
                        sql += ",to_char(a.ngay,'dd/MM/yyyy') as ngay, a.mabs, a.id as idtonghop, to_number('0') as stttonghop  ";//gam 14/02/2012
                        sql += "from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id ";
                        sql += "left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp ";
                        sql += "inner join medibv.d_dmnhom e on b.manhom=e.id ";
                        sql += "where done=0 and a.maql = " + v_maql + " and a.madoituong<>1";
                        sql += " and a.soluong<>0 ";
                        ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
                    }
                    if (ads1 != null)
                    {
                        try
                        {
                            if (ads1.Tables[0].Rows.Count > 0)
                            {
                                m_id_toathuocbhyt = ads1.Tables[0].Rows[0]["id"].ToString();
                                try
                                {
                                    cbBacsi.SelectedValue = ads1.Tables[0].Rows[0]["mabs"].ToString();
                                    cbBacsi_SelectedIndexChanged(null, null);
                                }
                                catch
                                {
                                    cbBacsi.SelectedIndex = -1;
                                    cbBacsi_SelectedIndexChanged(null, null);
                                }
                            }
                            ads1.Tables[0].Columns.Remove("mabs");
                        }
                        catch { }
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
                if (get_congkhambhyt().Tables[0].Rows.Count > 0)
                {
                    if (ads == null)
                    {
                        ads = get_congkhambhyt();
                    }
                    else
                    {
                        ads.Merge(get_congkhambhyt());
                    }
                }
                if (ads != null)
                {
                    m_dshoadon = ads;
                    DataSet dst = ads.Copy();
                    if (bChenhlech_thuoc_vattu && bGia_bh_quydinh)//if (bChenhlech_thuoc_vattu && bGia_bh_quydinh && bThuchenhlechtruoc_duyettoasau==false)
                    {
                        foreach (DataRow r in ads.Tables[0].Select("loai=1"))
                        {
                            if (bLaygiamua_khi_giabh_0_giabh_nho_giamua) r["dongia"] = (decimal.Parse(r["gia_bh"].ToString()) > 0 && (decimal.Parse(r["gia_bh"].ToString()) < decimal.Parse(r["giamua"].ToString()))) ? decimal.Parse(r["gia_bh"].ToString()) : decimal.Parse(r["giamua"].ToString());
                            else r["dongia"] = (decimal.Parse(r["gia_bh"].ToString()));
                            r["sotien"] = decimal.Parse(r["dongia"].ToString()) * decimal.Parse(r["soluong"].ToString());
                        }
                        if (bThuchenhlechtruoc_duyettoasau == false) m_v.merge(ads, chenhlech(dst));
                        ads.AcceptChanges();
                    }
                    //ads.Tables[0].Columns.Remove("giamua");
                    //ads.Tables[0].Columns.Remove("loai");
                    dgHoadon.DataSource = ads.Tables[0];
                    dgHoadon.Update();
                    f_Load_BHYT();
                    f_Tinhtien(-1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private DataSet chenhlech(DataSet ds)
        {
            DataSet dst = ds.Clone();
            decimal dongia = 0;
            DataRow r3;
            string s_exp = "loai=1";
            if (bChenhlech_thuoc_dannhmuc) s_exp += " and chenhlech=1";
            foreach (DataRow r in ds.Tables[0].Select(s_exp))
            {
                dongia = ((bGia_bh_quydinh_giamua) ? decimal.Parse(r["giamua"].ToString()) : decimal.Parse(r["giaban"].ToString())) - ((decimal.Parse(r["gia_bh"].ToString()) > 0) ? decimal.Parse(r["gia_bh"].ToString()) : decimal.Parse(r["giamua"].ToString()));
                if (dongia > 0)
                {
                    r3 = dst.Tables[0].NewRow();
                    r3["id"] = r["id"].ToString();
                    r3["ma"] = r["ma"].ToString();
                    r3["ten"] = r["ten"].ToString();
                    r3["dvt"] = r["dvt"].ToString();
                    r3["soluong"]=r["soluong"].ToString();
                    r3["giaban"] = r["giaban"].ToString();
                    r3["gia_bh"] = r["gia_bh"].ToString();
                    r3["bhyttra"] = 0;
                    r3["bntra"] = 0;
                    r3["mavp"] = r["mavp"].ToString();
                    r3["giamua"] = r["giamua"].ToString();
                    r3["loai"] = r["loai"].ToString();
                    r3["dichvu"] = 0;
                    r3["nhom"] = 0;
                    r3["idtonghop"] = 0;
                    r3["stttonghop"] = 0;
                    r3["madoituong"] = iTunguyen.ToString();
                    r3["dongia"] = dongia;
                    r3["sotien"] = decimal.Parse(r3["dongia"].ToString()) * decimal.Parse(r3["soluong"].ToString());
                    r3["chenhlech"] = (r["chenhlech"].ToString() == "") ? "0" : r["chenhlech"].ToString();
                    dst.Tables[0].Rows.Add(r3);
                }
            }
            return dst;
        }

        private void f_Load_Tamung(string v_tn, string v_maql)
        {
            s_idthutamung = "";
            try
            {            
                try
                {
                    v_maql = decimal.Parse(v_maql).ToString();
                }
                catch
                {
                    return;
                }
                string sql = "", sql_luu = ""; ;
                sql = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id where a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";
                if (m_maql != "")
                {
                    if (m_maql_tiepdon != "")
                    {
                        sql += " and (a.maql=" + m_maql + " or mavaovien =" + m_maql_tiepdon + ")";
                    }
                    else sql += " and a.maql=" + m_maql; 
                }
                if (m_maql_tiepdon != "")
                {
                    sql_luu = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id where a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";
                    sql_luu += " and a.maql=" + m_maql_tiepdon;
                }
                v_tn = m_v.f_string_date(v_tn);
                if (v_tn.Length >= 10)
                {
                    v_tn = v_tn.Substring(0, 10);
                }
                else
                {
                    try
                    {
                        v_tn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        v_tn = txtNgaythu.Text.Substring(0, 10);
                    }
                }
                //Tamung
                decimal atu = 0, atut = 0;
                try
                {
                    m_dstamung = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
                    //if (m_maql_tiepdon != "")
                    //{
                    //    m_dstamung.Merge(m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql_luu));
                    //}
                    foreach (DataRow r in m_dstamung.Tables[0].Select("chon=1"))
                    {
                        try
                        {
                            atut = decimal.Parse(r["sotien"].ToString());
                        }
                        catch
                        {
                            atut = 0;
                        }
                        atu += atut;
                        s_idthutamung += r["id"].ToString() + ",";
                    }
                    txtTamung.Text = atu.ToString("###,###,##0.##");
                    s_idthutamung = s_idthutamung.Trim().Trim(',');
                }
                catch
                {
                }
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_Tamung");
            }
        }

        private void f_Load_CB_Ngayvv(string v_tn, string v_maql)
        {
            try
            {
                string sql = "", sql1 = "", amabn = "";
                amabn = txtMabn.Text + txtMabn1.Text;
                DateTime adt = txtNgaythu.Value;
                v_tn = m_v.f_string_date(v_tn);

                if (v_tn.Length >= 10)
                {
                    adt = m_v.f_parse_date(v_tn.Substring(0, 10));
                }
                if (CongthucTraiTuyen160212)
                {
                    sql = "select maql, mavaovien as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi')  as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number('0') as loaibn,'' as maicd, '' as chandoan ,'' as mabs from medibvmmyy.tiepdon where noitiepdon not in (3,2) and mabn='" + amabn + "'";//khuyen 07/04/14 noitiepdon not in (2)
                    sql += " union all ";
                }
                sql += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number(3,9) as loaibn, nvl(maicd,' ') as maicd, nvl(chandoan,' ' ) as chandoan, nvl(mabs,' ') as mabs from medibvmmyy.benhanpk where mabn='" + amabn + "'";
                if(tmn_khongcungchitra.Checked || bBHYTThu_BNChiquatiepdon )
                {
                    sql += " union all ";
                    sql += "select maql, mavaovien as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(0,9) as loaibn, '' as maicd,'' as chandoan,'' as mabs from medibvmmyy.tiepdon where noitiepdon not in (3,2) and mabn='" + amabn + "'";//khuyen 07/04/14 noitiepdon not in (2)
                }
                if (tmn_Cophongluu.Checked)
                {
                    //if (sql1 != "")
                    //{
                    //    sql1 += " union all ";
                    //}
                    //sql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(4,9) as loaibn, nvl(maicd,' ') as maicd, nvl(chandoan,' ' ) as chandoan, nvl(mabs,' ') as mabs from medibvmmyy.benhancc where mabn='" + amabn + "'";
                    //khuyen 07/04/14 thay maql as  mavaovien thanh mavaovien as mavaovien
                    sql += " union all ";
                    sql += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(4,9) as loaibn, nvl(maicd,' ') as maicd, nvl(chandoan,' ' ) as chandoan, nvl(mabs,' ') as mabs from medibvmmyy.benhancc where mabn='" + amabn + "'";
                    //
                }
                if (tmn_Conhanbenh.Checked)
                {
                    if (sql1 != "")
                    {
                        sql1 += " union all ";
                    }
                    sql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number(loaiba,9) as loaibn, nvl(maicd,' ') as maicd, nvl(chandoan,' ' ) as chandoan, nvl(mabs,' ') as mabs from medibv.benhandt where mabn='" + amabn + "'";
                }
                if (tmn_conamngoaitru.Checked)
                {
                    if (sql1 != "")
                    {
                        sql1 += " union all ";
                    }
                    sql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number(2,9) as loaibn, nvl(maicd,' ') as maicd, nvl(chandoan,' ' ) as chandoan, nvl(mabs,' ') as mabs from medibv.benhanngtr where mabn='" + amabn + "'";
                }
                //khuyen 10/03/14
                //if (sql != "")
                {
                    sql += " union all ";
                }
                sql += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,maphu as madoituong,loaiba as loaibn, nvl(maicd,' ') as maicd, nvl(chandoan,' ' ) as chandoan, nvl(mabs,' ') as mabs from medibvmmyy.bhytkb where mabn='" + amabn + "' and (sobienlai=0 or sobienlai is null) and (idttrv=0 or idttrv is null)";
                //end //
                DataSet ads = null, ads1 = null, ads2 = null;
                if (sql1 != "")
                {
                    //khuyen 10/03/14 sql1 += "  order by ngay1 desc,maql desc";
                    sql1 += "  order by ngay1 ,maql ";
                    //ads1 = m_v.get_data_bc(adt.AddMonths(-1), txtNgaythu.Value.AddMonths(1), sql1);
                    ads1 = m_v.get_data_mmyy(sql1, m_v.DateToString("dd/MM/yyyy", adt.AddMonths(-iSothang)), txtNgaythu.Text.Substring(0, 10), true);
                }
                //
                if (sql != "")
                {

                    ////khuyen 10/03/14 sql += "  order by ngay1 desc,maql desc";
                    sql += "  order by ngay1 ,maql ";
                    //ads = m_v.get_data_bc(adt.AddMonths(-1), txtNgaythu.Value, sql);
                    ads = m_v.get_data(sql);
                }
                if (ads1 != null)
                {
                    if (ads == null)
                    {
                        ads = ads1;
                    }
                    else
                        if (ads1.Tables[0].Rows.Count > 0)
                        {
                            ads.Merge(ads1);
                        }
                }
                ads2 = ads.Clone();
                //khuyen 10/03/14  foreach (DataRow r in ads.Tables[0].Select("", "ngay1 desc,maql desc")) 
                foreach (DataRow r in ads.Tables[0].Select("", "ngay1 ,maql ")) ads2.Tables[0].Rows.Add(r.ItemArray);

                cbNgayvv.DisplayMember = "ngay";
                cbNgayvv.ValueMember = "maql";
                cbNgayvv.DataSource = ads2.Tables[0];
                if (v_maql != "")
                {
                    try
                    {
                        cbNgayvv.SelectedValue = v_maql;
                    }
                    catch{}
                }
                else if (cbNgayvv.SelectedIndex != -1) v_maql = cbNgayvv.SelectedValue.ToString();
               //f_Load_BHYT();
            }
            catch (Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_BC_Ngayvv_BHYT");
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void toolStrip_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }
        private void toolStrip_Tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //string aft = "";
                //if (toolStrip_Tim.Text != "")
                //{
                //    aft = "ten like '%" + toolStrip_Tim.Text.Replace("'","''") + "%'";
                //}
                //CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                //DataView dv = (DataView)(cm.List);
                //dv.RowFilter = aft;
                //toolStrip_Title.Text = "Danh sách lý do thiếu (" + dv.Table.Select(aft).Length.ToString() + "/" + toolStrip_Title.Tag.ToString() + ")";
            }
            catch
            {
            }
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            string ammyy = "",exp = "";
            if (!kiemtra())
                return;
            if (v_tachhoadon_dv == "" && v_tachbienlai_dv == "")
            {
                f_Luu();
            }
            else
            {
                if (v_tachhoadon_dv != "") exp = "madoituong in (" + v_tachhoadon_dv + ")";
                else if (v_tachbienlai_dv != "") exp = "nhom in ("+v_tachbienlai_dv.Trim(',')+")";
                DataSet ds = new DataSet();
                ds = m_dshoadon.Copy();
                ds.Clear();

                decimal asotien = 0,asoluong = 0,adongia = 0;
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    if (r["madoituong"].ToString() == "1")//tính tổng tiền
                    {
                        try
                        {
                            adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
                            if (adongia < 0)
                            {
                                adongia = 0;
                            }
                        }
                        catch
                        {
                            adongia = 0;
                        }
                        try
                        {
                            asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
                        }
                        catch
                        {
                            asoluong = 0;
                        }
                        asotien += Math.Round(asoluong * adongia, 2);
                    }
                    //tách hóa đơn
                }
                foreach ( DataRow rct in m_dshoadon.Tables[0].Select(exp))
                {

                    DataRow r_ds = ds.Tables[0].NewRow();
                    r_ds["ma"] = rct["ma"].ToString();
                    r_ds["ten"] = rct["ten"].ToString();
                    r_ds["dvt"] = rct["dvt"].ToString();
                    r_ds["soluong"] = rct["soluong"].ToString();
                    r_ds["dongia"] = rct["dongia"].ToString();
                    r_ds["giaban"] = rct["giaban"].ToString();
                    r_ds["gia_bh"] = rct["gia_bh"].ToString();
                    r_ds["sotien"] = rct["sotien"].ToString();
                    r_ds["bhyttra"] = rct["bhyttra"].ToString();
                    r_ds["bntra"] = rct["bntra"].ToString();
                    r_ds["mavp"] = rct["mavp"].ToString();
                    r_ds["madoituong"] = rct["madoituong"].ToString();
                    r_ds["loai"] = rct["loai"].ToString();
                    r_ds["dichvu"] = rct["dichvu"].ToString();
                    r_ds["id"] = rct["id"].ToString() == "" ? "0" : rct["id"].ToString();
                    r_ds["giamua"] = rct["giamua"].ToString() == "" ? "0" : rct["giamua"].ToString();
                    r_ds["chenhlech"] = rct["chenhlech"].ToString() == "" ? "0" : rct["chenhlech"].ToString();
                    r_ds["nhom"] = rct["nhom"].ToString();
                    ds.Tables[0].Rows.Add(r_ds);
                    m_dshoadon.Tables[0].Rows.Remove(rct);                    
                }
                f_Tinhtien(asotien);
                f_Luu(false, m_dshoadon);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    m_dshoadon.Clear();
                    m_dshoadon = ds.Copy();
                    dgHoadon.DataSource = m_dshoadon.Tables[0];
                    if (!b_sua && !b_huykembldv) m_id = "";
                    else if (!b_sua && b_huykembldv) m_id = "-" + m_id;

                    f_Tinhtien(asotien);
                    f_Luu(true, m_dshoadon);
                }
            }
            ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16));
            f_Load_Thutrongngay();
            
            
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            f_Sua();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            f_Xoa();
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_id != "" && m_id != "0")
                {
                    f_Load_Hoadon(m_id, "");
                }
                else
                {
                    m_dshoadon.Tables[0].Rows.Clear();
                    f_Clear_pTonghop();
                    f_Tinhtien(-1);
                }
                f_Enable_HC(false);
                f_Enable(false);                
                tmn_Danhsachcho.Enabled = true;
                butMoi.Focus();
            }
            catch
            {
            }
        }
        private void txtTen_KeyDown(object sender, KeyEventArgs e)
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

        private void cbDoituongTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituongTD.DataSource]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("madoituong=" + cbDoituongTD.SelectedValue.ToString()))
                {
                    try
                    {
                        //txtSothe.MaxLength = int.Parse(r["sothe"].ToString());                        
                        txtSothe.MaxLength = 20;
                    }
                    catch
                    {
                        txtSothe.MaxLength = 20;
                    }

                    break;
                }
            }
            catch
            {
            }
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (m_Docmavach)
                    {
                        txtMabn.MaxLength = i_maxlength_mabn;
                        string s = txtMabn.Text;
                        if (s.Length >=3)
                        {
                            txtMabn.Text = s.Substring(0, 2);
                            txtMabn1.Text = s.Substring(2);
                            txtMabn1_Validated(sender, e);
                        }
                    }
                    //txtMabn_Validated(null, null);
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
                    if (m_Docmavach)
                    {
                        txtMabn1.MaxLength = i_maxlength_mabn;
                        string s = txtMabn1.Text;
                        if (s.Length == i_maxlength_mabn)
                        {
                            txtMabn.Text = s.Substring(0, 2);
                            txtMabn1.Text = s.Substring(2);                            
                        }
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

        private void txtNgaysinh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNgaysinh_Validated(null, null);
                    if (txtNgaysinh.Text != "")
                    {
                        cbGioitinh.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    {
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch
            {
            }
        }

        private void txtTuoi_KeyDown(object sender, KeyEventArgs e)
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

        private void cbTuoi_KeyDown(object sender, KeyEventArgs e)
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

        private void cbGioitinh_KeyDown(object sender, KeyEventArgs e)
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
                    if (m_bnmoi)
                    {
                        cbDoituongTD.SelectedValue = "2";
                        cbDoituongTD.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    {
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch
            {
            }
        }

        private void txtSothe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSothe.Text.Trim() == "")
                {
                    cbDoituongTD.Focus();
                    SendKeys.Send("{F4}");
                }
                else  SendKeys.Send("{Tab}");
            }
        }

        private void txtTN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)    SendKeys.Send("{Tab}");
        }

        private void txtDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}");
        }

        private void txtNDK_Ma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtNDK_Ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)    SendKeys.Send("{Tab}{F4}");
        }

        private void cbNgayvv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbLoaibn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   SendKeys.Send("{Tab}{F4}");
        }

        private void cbDoituongTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");

        }

        private void toolStrip_Tongcong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void toolStrip_Mien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void toolStrip_Thucthu_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    if (butLuu.Enabled)
                    {
                        butLuu.Focus();
                    }
                    else
                        SendKeys.Send("{Tab}");
                }
        }

        private void cbDoituong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTenvp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int aid = 0;
                if (e.KeyCode == Keys.Enter)
                {
                    f_Get_Item();
                    if (txtTenvp.Text != "")
                    {
                        txtSoluong.SelectAll();
                        SendKeys.Send("{Tab}");
                    }
                }
                else
                    if (e.KeyCode == Keys.Up)
                    {
                        dgGia.Visible = true;
                        if (dgGia.CurrentCell.RowIndex > 0)
                        {
                            aid = dgGia.CurrentCell.RowIndex - 1;
                            dgGia.Rows[aid].Selected = true;
                            dgGia.CurrentCell = dgGia.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                        else
                            if (dgGia.RowCount > 0)
                            {
                                aid = dgGia.RowCount - 1;
                                dgGia.Rows[aid].Selected = true;
                                dgGia.CurrentCell = dgGia.Rows[aid].Cells[1];
                                SendKeys.Send("{End}");
                            }
                    }
                    else
                        if (e.KeyCode == Keys.Down)
                        {
                            dgGia.Visible = true;
                            if (dgGia.CurrentCell.RowIndex < dgGia.Rows.Count - 1)
                            {
                                aid = dgGia.CurrentCell.RowIndex + 1;
                                dgGia.Rows[aid].Selected = true;
                                dgGia.CurrentCell = dgGia.Rows[aid].Cells[1];
                                SendKeys.Send("{End}");
                            }
                            else
                                if (dgGia.RowCount > 0)
                                {
                                    aid = 0;
                                    dgGia.Rows[aid].Selected = true;
                                    dgGia.CurrentCell = dgGia.Rows[aid].Cells[1];
                                    SendKeys.Send("{End}");
                                }
                        }
                        else
                            if (e.KeyCode == Keys.Escape)
                            {
                                dgGia.Visible = !dgGia.Visible;
                            }
            }
            catch
            {
            }
        }

        private void txtSoluong_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    f_Get_Item();
                    if (txtDongia.Text != "" && txtDongia.Text != "0")
                    {
                        butAdd_Click(null, null);
                    }
                    else
                    {
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch
            {
            }
        }

        private void txtDongia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    f_Get_Item();
                    if (txtSoluong.Text != "" && txtSoluong.Text != "0" && txtDongia.Text != "")
                    {
                        butAdd.Focus();
                    }
                    else
                        if (txtSoluong.Text != "" || txtSoluong.Text != "0")
                        {
                            txtSoluong.Text = "1";
                            SendKeys.Send("{Tab}");
                        }
                        else
                        {
                            SendKeys.Send("{Tab}");
                        }
                }
            }
            catch
            {
            }
        }

        private void txtThucthu_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                          butAdd.Focus();

        }

        private void cbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
 
                if (e.KeyCode == Keys.Enter)
                    butAdd.Focus();
       
        }

        private void cbBacsi_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                    butAdd.Focus();
      
        }

        private void txtMabn_Validated(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtMabn.Text.Trim());
                if (i >= 0 && i <= 99)
                {
                    txtMabn.Text = i.ToString().PadLeft(2, '0');
                }
                else
                {
                    txtMabn.Text = m_v.s_curyy;
                }
            }
            catch
            {
                txtMabn.Text = m_v.s_curyy;
            }
        }
        private void txtMabn1_Validated(object sender, EventArgs e)
        {
            try
            {
                //int i = int.Parse(txtMabn1.Text.Trim());
                //if (i >= 0)
                //{
                //    if (bQuanly_Theo_Chinhanh)
                //    {
                //        txtMabn1.Text = i.ToString().PadLeft(i_maxlength_mabn, '0');
                //    }
                //    else
                //    {
                //        txtMabn1.Text = i.ToString().PadLeft(i_maxlength_mabn - 2, '0');//.PadLeft(6, '0');
                //    }
                //}
                //else
                //{
                //    txtMabn1.Text = "";
                //}
                txtMabn1.Text = txtMabn1.Text.PadLeft(6, '0');
            }
            catch
            {
                txtMabn1.Text = "";
            }
            if (m_Docmavach)
            {
                string s = txtMabn1.Text;
                if (s.Length >=8)
                {
                    txtMabn.Text = s.Substring(0, 2);
                    txtMabn1.Text = s.Substring(2);
                    txtMabn1.Text = txtMabn1.Text.PadLeft(6, '0');//(6, '0');
                }
            }
            if (txtMabn.Text.Trim() + txtMabn1.Text.Trim() != "")// .Length == 2 && txtMabn1.Text.Length == i_maxlength_mabn-2)//&& txtMabn1.Text.Length == 6)
            {
                f_Load_Hanhchanh(txtMabn.Text + txtMabn1.Text);
            }
            //label26_Click(null, null);
        }

        private void cbNgayvv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNgayvv.DataSource]);
                DataView dv = (DataView)(cm.List);
                //dv.Table.AcceptChanges();
                 //khuyen 10/03/14   foreach (DataRow r in dv.Table.Select("maql='" + cbNgayvv.SelectedValue.ToString() + "' "))
                foreach (DataRow r in dv.Table.Select("maql='" + cbNgayvv.SelectedValue.ToString() + "' AND NGAY='" + cbNgayvv.Text + "'"))//khuyen 10/03/14 lay trong bhytkb
                {
                //foreach (DataRow r in dv.Table.Select("maql='"+ cbNgayvv.SelectedValue.ToString()+"'"))
                //{
                    cbLoaibn.SelectedValue = r["loaibn"].ToString();
                    cbKhoavv.SelectedValue = r["makp"].ToString();
                    txtKhoavv.Text = r["makp"].ToString();
                    cbKhoavv.SelectedValue = r["makp"].ToString();
                    txtICD.Text = r["maicd"].ToString();
                    txtChandoan.Text = r["chandoan"].ToString();
                    txtBacsi.Text = r["mabs"].ToString();
                    cbBacsi.SelectedValue = r["mabs"].ToString();

                    string s = r["madoituong"].ToString();
                    try
                    {
                        cbDoituongTD.SelectedValue = r["madoituong"].ToString();
                    }
                    catch
                    {
                    }
                    if (cbDoituongTD.SelectedIndex < 0)
                    {
                        cbDoituongTD.SelectedIndex = 0;
                    }

                    m_mavaovien = decimal.Parse(r["mavaovien"].ToString()).ToString();
                    m_maql = decimal.Parse(r["maql"].ToString()).ToString();
                    //gam 21-04-2011 kiểm tra nếu đang load hóa đơn thu rồi thì không load lại chỉ định
                    if (!v_loadcho )
                        f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString(), false);
                   
                    break;
                }
            }
            catch
            {
                m_mavaovien = m_maql = "";
            }
        }

        private void butHoan_Click(object sender, EventArgs e)
        {
            f_Hoan();
        }

        private void butInhoadon_Click(object sender, EventArgs e)
        {
            if (!tmn_Luuin_Hoadon.Checked && !tmn_Luuin_Phieuthuchi.Checked)
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Chọn loại hoá đơn cần in từ [Tùy chọn]!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string s = m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "select lanin from medibvmmyy.v_ttrvll where id=" + m_id + "").Tables[0].Rows[0]["lanin"].ToString();
            if (decimal.Parse(v_solanin) > decimal.Parse(s))
            {
                //if (tmn_Luuin_Hoadon.Checked && v_tachhoadon_dv == "")
                //{
                //    f_Inhoadon();
                //}
                //else if (tmn_Luuin_Hoadon.Checked && v_tachhoadon_dv != "")
                //{
                //    if (m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")").Length > 0)
                //    {
                //        f_Inhoadon(true);
                //    }
                //    else
                //    {
                //        f_Inhoadon(false);
                //    }
                //}
                if (tmn_Luuin_Hoadon.Checked && ((v_tachhoadon_dv != "" && m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")").Length > 0) || v_tachbienlai_dv != "" && m_dshoadon.Tables[0].Select("nhom in (" + v_tachbienlai_dv + ")").Length > 0))
                {
                    f_Inhoadon(true);
                }
                else
                {
                    f_Inhoadon(false);
                }
                if (tmn_Luuin_Phieuthuchi.Checked)
                {
                    f_Inphieuthuchi();
                }
            }
            else
            {
                MessageBox.Show(this, "Số lần in " + s + " vượt quá số lần in quy định " + v_solanin + " !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butInchiphi_Click(object sender, EventArgs e)
        {
            f_Inchiphi();
        }

        private void txtTenvp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl != dgGia)
                {
                    dgGia.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void txtTenvp_Enter(object sender, EventArgs e)
        {
            try
            {
                f_Display();
                dgGia.Visible = true;
            }
            catch
            {
            }
        }

        private void frmVienphiBHYT_SizeChanged(object sender, EventArgs e)
        {
            f_Display();
        }

        private void cbNgayvv_Validated(object sender, EventArgs e)
        {
            try
            {
                  f_Load_BHYT();
            }
            catch
            {
            }
        }

        private void lbKyhieu_Click(object sender, EventArgs e)
        {
            try
            {
                cbLoaidv.Enabled = !cbLoaidv.Enabled;
                cbKyhieu.Enabled = cbLoaidv.Enabled;
                txtNgaythu.Enabled = false;// cbLoaidv.Enabled;
                //txtSobienlai.ReadOnly = !cbLoaidv.Enabled;
                if (txtNgaythu.Enabled == false)
                {
                    m_cur_ngay = txtNgaythu.Value;
                    try
                    {

                        m_cur_loaidv = cbLoaidv.SelectedValue.ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (m_cur_quyenso != "" && m_cur_quyenso != cbKyhieu.SelectedValue.ToString())
                        {
                            m_v.execute_data("update medibv.v_quyenso set dangsd=0 where id=" + m_cur_quyenso);
                        }
                        m_cur_quyenso = cbKyhieu.SelectedValue.ToString();
                        if (m_cur_quyenso != "")
                        {
                            m_v.execute_data("update medibv.v_quyenso set dangsd=1 where id=" + m_cur_quyenso);
                        }
                    }
                    catch
                    {
                    }
                }
                cbKyhieu_Validated(null, null);
            }
            catch
            {
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {
            try
            {
                txtSobienlai.ReadOnly = !txtSobienlai.ReadOnly;
            }
            catch
            {
            }
        }

        private void txtTenvp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == txtTenvp)
                {
                    f_Filter_Giavp();
                }
            }
            catch
            {
            }
        }

        private void cbDoituongTD_Validated(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituongTD.DataSource]);
                DataView dv = (DataView)(cm.List);
                string afield = dv.Table.Select("madoituong=" + cbDoituongTD.SelectedValue.ToString())[0]["field_gia"].ToString().ToUpper().Trim();

                DataGridViewCellStyle dataGridViewCellStyle_B = new DataGridViewCellStyle();
                dataGridViewCellStyle_B.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                dataGridViewCellStyle_B.Format = "### ### ### ##0.##";
                dataGridViewCellStyle_B.NullValue = "0";
                dataGridViewCellStyle_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                DataGridViewCellStyle dataGridViewCellStyle_R = new DataGridViewCellStyle();
                dataGridViewCellStyle_R.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                dataGridViewCellStyle_R.Format = "### ### ### ##0.##";
                dataGridViewCellStyle_R.NullValue = "0";
                dataGridViewCellStyle_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                switch (afield)
                {
                    case "GIA_BH":
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_cs

                        break;
                    case "GIA_DV":
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_cs
                        break;
                    case "GIA_NN":
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_cs
                        break;
                    case "GIA_CS":
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_cs
                        break;
                    default:
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_cs
                        break;
                }
            }
            catch
            {
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbDoituongTD.SelectedIndex < 0)
                {
                    cbDoituongTD.SelectedValue = "1";
                }
                if (txtSoluong.Text == "" || txtSoluong.Text == "0")
                {
                    txtSoluong.Text = "1";
                }
                if (txtDongia.Text == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Đơn giá chưa có!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (txtDongia.Enabled)
                    {
                        txtDongia.Focus();
                        return;
                    }
                    else
                    {
                        txtTenvp.Focus();
                        return;
                    }
                }
                f_Add();
                txtTenvp.Text = "";
                txtSoluong.Text = "1";
                txtDongia.Text = "0";
                f_Filter_Giavp();
                txtTenvp.Focus();
            }
            catch
            {
            }
        }

        private void butRem_Click(object sender, EventArgs e)
        {
            try
            {
                f_Rem();
                txtTenvp.Text = "";
                txtSoluong.Text = "1";
                txtDongia.Text = "0";
                f_Filter_Giavp();
            }
            catch
            {
            }
        }

        private void dgHoadon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string aindex = e.ColumnIndex.ToString();
                switch (aindex)
                {
                    case "5"://SL
                    case "6"://Dongia
                    case "7"://VAT
                    case "8"://Vattu
                        f_Tinhtien(-1);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
            }
        }

        private void txtSoluong_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_mon();
        }

        private void txtDongia_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_mon();
        }

        private void txtSothe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtChieudaithe.Text = txtSothe.Text.Length.ToString();
            }
            catch
            {
            }
        }

        private void txtTuoi_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal atuoi = decimal.Parse(txtTuoi.Text);
                if (atuoi < 0)
                {
                    atuoi = 0;
                }
                txtTuoi.Text = atuoi.ToString("####");
            }
            catch
            {
                txtTuoi.Text = "1";
            }
        }

        private void cbTuoi_Validated(object sender, EventArgs e)
        {
            try
            {
                string atmp = "";
                txtTuoi_Validated(null, null);
                if (txtTuoi.Text != "")
                {
                    atmp = m_v.tinhngay(txtTuoi.Text, cbTuoi.SelectedValue.ToString());
                }
                else
                {
                    atmp = m_v.tinhtuoi(txtNgaysinh.Text, 300);
                }
                txtTuoi.Text = "";
                if (atmp.Split(':')[0] != "?")
                {
                    if (txtNgaysinh.Text.Length < 10)
                    {
                        if (atmp.Split(':')[0].Length == 10)
                        {
                            txtNgaysinh.Text = atmp.Split(':')[0].Split('/')[2];
                        }
                        else
                        {
                            txtNgaysinh.Text = atmp.Split(':')[0];
                        }
                    }
                }
                if (atmp.Split(':')[1] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[1];
                    cbTuoi.SelectedValue = "1";
                }
                if (atmp.Split(':')[2] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[2];
                    cbTuoi.SelectedValue = "2";
                }
                if (atmp.Split(':')[3] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[3];
                    cbTuoi.SelectedValue = "3";
                }
            }
            catch
            {
                txtNgaysinh.Text = "";
            }
        }

        private string f_get_mavp_hotkey(string v_hotkey)
        {
            try
            {
                string art = "";
                if (tmn_Hotkey_KSK_Show.Checked)
                {
                    foreach (DataRow r in m_frmchonvp.s_dshotkey_ksk.Tables[0].Select("hotkey='" + v_hotkey + "'"))
                    {
                        art += ",";
                        art += r["id"].ToString();
                    }
                }
                else
                    if (tmn_Hotkey_Show.Checked)
                    {
                        foreach (DataRow r in m_frmchonvp.s_dshotkey.Tables[0].Select("hotkey='" + v_hotkey + "'"))
                        {
                            art += ",";
                            art += r["id"].ToString();
                        }
                    }
                art = art.Trim(',');
                return art;
            }
            catch
            {
                return "";
            }
        }

        private void f_Chon(string v_keycode)
        {
            try
            {
                if (butLuu.Enabled)
                {
                    if (cbDoituongTD.SelectedIndex < 0)
                    {
                        cbDoituongTD.SelectedValue = "1";
                    }

                    if (tmn_Hotkey_Addall.Checked && v_keycode != "" && (tmn_Hotkey_Show.Checked || tmn_Hotkey_KSK_Show.Checked))
                    {
                        f_Add_Chon(f_get_mavp_hotkey(v_keycode));
                    }
                    else
                    {
                        m_frmchonvp.s_field_gia = "gia_bh";
                        m_frmchonvp.s_title = (txtMabn.Text + txtMabn1.Text + " - " + txtHoten.Text.Trim() + " - " + txtNgaysinh.Text.Trim() + " - " + cbGioitinh.Text.Trim());
                        m_frmchonvp.s_hotkey = v_keycode;
                        m_frmchonvp.s_chochon = butLuu.Enabled;
                        m_frmchonvp.s_loai_hotkey = tmn_Hotkey_KSK_Show.Checked ? "1" : "";
                        if (m_frmchonvp.ShowDialog(this) == DialogResult.OK)
                        {
                            if (m_frmchonvp.s_mavp != "")
                            {
                                f_Add_Chon(m_frmchonvp.s_mavp);
                            }
                        }
                        if (toolStrip_Tongcong.Text != "" && toolStrip_Tongcong.Text != "0")
                        {
                            butLuu.Focus();
                        }
                        if (m_frmchonvp.s_reset)
                        {
                            f_Load_Hotkey();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText(
"Nhấn nút ") + (m_id == "" ? lan.Change_language_MessageText(
"Mới") : lan.Change_language_MessageText(
"Sửa")) + lan.Change_language_MessageText(
" trước khi chọn viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void butChon_Click(object sender, EventArgs e)
        {
            f_Chon("");
        }

        private void frmVienphiBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        f_Chon("F1");
                        break;
                    case Keys.F2:
                        f_Chon("F2");
                        break;
                    case Keys.F3:
                        f_Chon("F3");
                        break;
                    case Keys.F5:
                        f_Chon("F5");
                        break;
                    case Keys.F6:
                        f_Chon("F6");
                        break;
                    case Keys.F7:
                        f_Chon("F7");
                        break;
                    case Keys.F8:
                        f_Chon("F8");
                        break;
                    case Keys.F9:
                        f_Chon("F9");
                        break;
                    case Keys.F11:
                        f_Chon("F11");
                        break;
                    case Keys.F12:
                        f_Chon("F12");
                        break;
                }
                if (e.KeyValue.ToString() == "192")
                {
                    f_Chon("");
                }
            }
            catch
            {
            }
        }

        private void toolStrip_Mien_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    string s_mien = toolStrip_Mien.Text.Trim();
            //    if (s_mien.IndexOf("%") > 0)
            //    {
            //        decimal phantram = decimal.Parse(toolStrip_Thucthu.Text.Trim());
            //        decimal mien = decimal.Parse(s_mien.Trim('%'));
            //        decimal tongso = phantram * mien / 100;
            //        toolStrip_Mien.Text = tongso.ToString();
            //    }
            //}
            //catch
            //{
            //    toolStrip_Mien.Text = "";
            //}khuyen dong 21/03/14
            f_Tinhtien(-1);
        }

        private void dgHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    if (dgHoadon[e.ColumnIndex, e.RowIndex].Value.ToString() == "1")
                    {
                        m_dshoadon.Tables[0].Rows[e.RowIndex]["chon"] = 0;
                    }
                    else
                    {
                        m_dshoadon.Tables[0].Rows[e.RowIndex]["chon"] = 1;
                    }
                    dgHoadon.Columns["Column_0"].ToolTipText = lan.Change_language_MessageText(
"Đánh dấu những mục cần in:") + " " + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString();
                }
            }
            catch
            {
            }
        }

        private void f_FullScreen(bool v_bool)
        {
            try
            {
                pHanhchanh.Height = v_bool ? 35 : 137;
            }
            catch
            {
            }
        }

        private void toolStrip_Title_Click(object sender, EventArgs e)
        {
            try
            {
                pHanhchanh.Height = (pHanhchanh.Height > 100) ? 25 : 114;
                m_v.set_o_fullscreen_frmvienphiBHYT(m_userid, pHanhchanh.Height > 100 ? false : true);
                m_o_fullscreen = m_v.get_o_fullscreen_frmvienphiBHYT(m_userid);
            }
            catch
            {
            }
        }

        private void txtNgaysinh_Validated(object sender, EventArgs e)
        {
            try
            {
                string atmp = m_v.tinhtuoi(txtNgaysinh.Text, 300);
                //ngay_or_nam:tuoi:thang:ngay
                txtNgaysinh.Text = "";
                txtTuoi.Text = "";
                if (atmp.Split(':')[0] != "?")
                {
                    txtNgaysinh.Text = atmp.Split(':')[0];
                }
                if (atmp.Split(':')[1] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[1];
                    cbTuoi.SelectedValue = "1";
                }
                if (atmp.Split(':')[2] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[2];
                    cbTuoi.SelectedValue = "2";
                }
                if (atmp.Split(':')[3] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[3];
                    cbTuoi.SelectedValue = "3";
                }
            }
            catch
            {
            }
        }

        private void cbLoaidv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tmn_Locsotheoloai.Checked)
                {
                    f_Filter_Quyenso();
                }
            }
            catch
            {
            }
        }

        private void cbLoaidv_Validated(object sender, EventArgs e)
        {
            f_Filter_Quyenso();
        }

        private void tmn_Locsotheoloai_Click(object sender, EventArgs e)
        {
            f_Filter_Quyenso();
        }

        private void tmn_Dungchungso_Click(object sender, EventArgs e)
        {
            f_Filter_Quyenso();
        }
        private void cbKyhieu_Validated(object sender, EventArgs e)
        {
            try
            {
                string atmp = f_Get_Sobienlai();
                txtSobienlai.Text = atmp.Split(':')[0];
                if (atmp.Split(':')[1] == "1")//Hết số
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    cbLoaidv.Focus();
                    return;
                }
                else
                    if (atmp.Split(':')[1] == "2")//Lỗi
                    {
                        //MessageBox.Show(this, "Không tìm thấy quyển sổ thu viện phí!\nĐề nghị chọn sổ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch
            {
            }
        }

        private void txtSobienlai_Validated(object sender, EventArgs e)
        {
            try
            {
                txtSobienlai.Text = decimal.Parse(txtSobienlai.Text.Trim()).ToString();
            }
            catch
            {
                txtSobienlai.Text = "";
            }
        }

        private void toolStrip_Tongthu_Click(object sender, EventArgs e)
        {
            f_Load_Thutrongngay();
        }

        private void butPre_Click(object sender, EventArgs e)
        {
            f_Load_Hoadon_NextPre(-1);
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            f_Load_Hoadon_NextPre(1);
        }

        private void tmn_Danhsachcho_Click(object sender, EventArgs e)
        {
            try
            {
                bool thuphi = tmn_khongcungchitra.Checked;
                //butMoi_Click(null, null);
                frmDanhsachchoBHYT m_frmdanhsachchoBHYT = new frmDanhsachchoBHYT(m_v, m_userid, thuphi, false);
                m_frmdanhsachchoBHYT.ShowInTaskbar = false;
                m_frmdanhsachchoBHYT.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachchoBHYT.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachchoBHYT.s_mabn != "")
                    {
                        v_loadcho = true;
                        string atmp = m_frmdanhsachchoBHYT.s_mabn;
                        f_Moi();//binh 120511
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(sender,e);

                        if (m_frmdanhsachchoBHYT.s_maql != "")
                        {
                           // f_Load_CB_Ngayvv(m_frmdanhsachchoBHYT.s_ngaycd, m_frmdanhsachchoBHYT.s_maql);
                            cbNgayvv.SelectedValue = m_frmdanhsachchoBHYT.s_maql;
                            cbNgayvv_SelectedIndexChanged(cbNgayvv, e);
                            //f_Load_Chidinh(m_frmdanhsachchoBHYT.s_ngaycd, m_frmdanhsachchoBHYT.s_maql, false);
                        }
                        if (cbNgayvv.SelectedIndex == -1)
                        {
                            v_loadcho = false;
                            txtMabn1_Validated(sender, e);
                            //f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString(), false);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Timbenhnhan_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimbenhnhan m_frmtimbenhnhan = new frmTimbenhnhan(m_v, m_userid);
                m_frmtimbenhnhan.ShowInTaskbar = false;
                m_frmtimbenhnhan.s_ngay = txtNgaythu.Value;
                if (m_frmtimbenhnhan.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmtimbenhnhan.s_mabn != "")
                    {
                        string atmp = m_frmtimbenhnhan.s_mabn;
                        f_Moi();//binh 130511
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Timhoadon_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimhoadon m_frmtimhoadon = new frmTimhoadon(m_v, m_userid);
                m_frmtimhoadon.ShowInTaskbar = false;
                m_frmtimhoadon.s_loaihd = "1";

                m_frmtimhoadon.s_ngay = txtNgaythu.Value;
                m_frmtimhoadon.s_loaihd = m_v.s_loaiform_bhyt;
                if (m_frmtimhoadon.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmtimhoadon.s_id != "")
                    {
                        f_Moi();//binh 130511
                        m_id = m_frmtimhoadon.s_id;
                        f_Load_Hoadon(m_id, m_v.get_mmyy(m_frmtimhoadon.s_ngaythu));
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Bangkehoadon_Click(object sender, EventArgs e)
        {
            try
            {
                frmDanhsachBHYT m_frmdanhsachBHYT = new frmDanhsachBHYT(m_v, m_userid);
                m_frmdanhsachBHYT.ShowInTaskbar = false;
                m_frmdanhsachBHYT.s_ngay = txtNgaythu.Value;

                if (m_frmdanhsachBHYT.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachBHYT.s_id != "")
                    {
                        m_id = m_frmdanhsachBHYT.s_id;
                        f_Load_Hoadon_thuroi(m_id, m_v.get_mmyy(m_frmdanhsachBHYT.s_ngaythu), m_frmdanhsachBHYT.s_mabn, m_frmdanhsachBHYT.s_ngaythu,m_frmdanhsachBHYT.s_mavaovien);
                        //txtMabn.Enabled = false;
                        //txtMabn1.Enabled = false;
                        
                    }
                }
            }
            catch
            {
            }
        }

        private void dgHoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                m_id_gia = arv["mavp"].ToString();
                txtTenvp.Text = arv["ten"].ToString();
                txtSoluong.Text = arv["soluong"].ToString();
                txtDongia.Text = arv["dongia"].ToString();
                txtSoluong_Validated(null, null);
                txtDongia_Validated(null, null);
                f_Filter_Giavp();
                dgGia.Visible = false;
            }
            catch
            {
            }

        }

        private void txtSobienlai_ReadOnlyChanged(object sender, EventArgs e)
        {
            try
            {
                txtSobienlai.ForeColor = txtSobienlai.ReadOnly ? Color.Orange : Color.Red;
            }
            catch
            {
            }
        }

        private void butLuu_EnabledChanged(object sender, EventArgs e)
        {
            f_Enabled_VP(butLuu.Enabled);
        }

        private void dgGia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl != txtTenvp)
                {
                    dgGia.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void dgGia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    f_Get_Item();
                    f_Add();
                }
                else
                    if (e.KeyCode == Keys.Escape)
                    {
                        dgGia.Visible = false;
                    }
            }
            catch
            {
            }
        }

        private void dgGia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                f_Get_Item();
                f_Add();
            }
            catch
            {
            }
        }

        private void dgHoadon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (butLuu.Enabled)
                {
                    switch (e.ColumnIndex.ToString())
                    {
                        case "3":
                        case "4":
                        case "5":
                            f_Rem();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                tmn_Xoaall.Enabled = m_dshoadon.Tables[0].Rows.Count > 0 && butLuu.Enabled;
                tmn_Xoacur.Enabled = m_dshoadon.Tables[0].Rows.Count > 0 && butLuu.Enabled;
            }
            catch
            {
                tmn_Xoaall.Enabled = false;
                tmn_Xoacur.Enabled = false;
            }
        }

        private void tmn_Xoaall_Click(object sender, EventArgs e)
        {
            try
            {
                m_dshoadon.Tables[0].Rows.Clear();
                f_Clear_pTonghop();
                f_Tinhtien(-1);
            }
            catch
            {
            }
        }

        private void tmn_Xoacur_Click(object sender, EventArgs e)
        {
            f_Rem();
        }

        private void cbLoaidv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbLoaidv_SelectedIndexChanged(null, null);
                    cbKyhieu.Focus();
                    SendKeys.Send("{F4}");
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
                    cbKyhieu_Validated(null, null);
                    txtNgaythu.Focus();
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

        private void txtSobienlai_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (butLuu.Enabled)
                    {
                        txtMabn1.Focus();
                    }
                    else
                    {
                        butMoi.Focus();
                    }
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
                dgHoadon.Columns["Column1_5"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column1_4"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column1_3"].Frozen = !tmn_Fullgrid.Checked;
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
                m_v.set_o_fullgrid_frmvienphiBHYT(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void tmn_Hotkey_Show_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmn_Hotkey_Show.Checked)
                {
                    tmn_Hotkey_KSK_Show.Checked = false;
                }
                f_Load_Hotkey();
                m_v.set_o_show_hotkey_frmvienphiBHYT(m_userid, tmn_Hotkey_Show.Checked);
                m_v.set_o_show_hotkey_ksk_frmvienphiBHYT(m_userid, tmn_Hotkey_KSK_Show.Checked);
            }
            catch
            {
            }
        }

        private void tmn_Hotkey_KSK_Show_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmn_Hotkey_KSK_Show.Checked)
                {
                    tmn_Hotkey_Show.Checked = false;
                }
                f_Load_Hotkey();
                f_Display();
                m_v.set_o_show_hotkey_frmvienphiBHYT(m_userid, tmn_Hotkey_Show.Checked);
                m_v.set_o_show_hotkey_ksk_frmvienphiBHYT(m_userid, tmn_Hotkey_KSK_Show.Checked);
            }
            catch
            {
            }
        }

        private void tmn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                tmn_Show_Hotkey.Checked = false;
                tt_Hotkey.Visible = false;
                f_Display();
                m_v.set_o_show_hotkey_toolbar_frmvienphiBHYT(m_userid, tmn_Show_Hotkey.Checked);
            }
            catch
            {
            }
        }

        private void tmn_F1_Click(object sender, EventArgs e)
        {
            f_Chon("F1");
        }

        private void tmn_F2_Click(object sender, EventArgs e)
        {
            f_Chon("F2");
        }

        private void tmn_F3_Click(object sender, EventArgs e)
        {
            f_Chon("F3");
        }

        private void tmn_F5_Click(object sender, EventArgs e)
        {
            f_Chon("F5");
        }

        private void tmn_F6_Click(object sender, EventArgs e)
        {
            f_Chon("F6");
        }

        private void tmn_F7_Click(object sender, EventArgs e)
        {
            f_Chon("F7");
        }

        private void tmn_F8_Click(object sender, EventArgs e)
        {
            f_Chon("F8");
        }

        private void tmn_F9_Click(object sender, EventArgs e)
        {
            f_Chon("F9");
        }

        private void tmn_F11_Click(object sender, EventArgs e)
        {
            f_Chon("F11");
        }

        private void tmn_F12_Click(object sender, EventArgs e)
        {
            f_Chon("F12");
        }

        private void tt_Hotkey_DoubleClick(object sender, EventArgs e)
        {
            f_Load_Hotkey();
        }

        private void tmn_Luuin_Hoadon_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_hoadon_frmvienphiBHYT(m_userid, tmn_Luuin_Hoadon.Checked);
        }
        private void tmn_Xemtruockhiin_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_xemtruockhiin_frmvienphiBHYT(m_userid, tmn_Xemtruockhiin_Icon.Checked);
        }
        private void tmn_Luuin_Chiphi_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_chiphi_frmvienphiBHYT(m_userid, tmn_Luuin_Chiphi.Checked);
        }

        private void tmn_Hotkey_Addall_Click(object sender, EventArgs e)
        {
            m_v.set_o_addall_hotkey_frmvienphiBHYT(m_userid, tmn_Hotkey_Addall.Checked);
        }

        private void tmn_Show_Hotkey_Click(object sender, EventArgs e)
        {
            m_v.set_o_show_hotkey_toolbar_frmvienphiBHYT(m_userid, tmn_Show_Hotkey.Checked);
            f_Load_Hotkey();
        }
        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m_v.Disconnect();
            System.GC.Collect();           
            this.Close();
        }

        private void frmVienphiBHYT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, lan.Change_language_MessageText(
"Đồng ý kết thúc chức năng thu chi BHYT phòng khám!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        private void txtMabn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "0123456789\b".IndexOf(e.KeyChar) == -1;
            //try
            //{
            //    txtMabn1.Text = txtMabn1.Text.Trim();
            //}
            //catch
            //{
            //}
        }

        private void txtMabn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtMabn.Text = txtMabn.Text.Trim();
            }
            catch
            {
            }
        }

        private void txtTN_Validated(object sender, EventArgs e)
        {
            try
            {
                txtTN.Text = m_v.f_string_date(txtTN.Text);
            }
            catch
            {
            }
            if (txtTN.Text.Length == 10 && txtDN.Text.Length == 10)
            {
                try
                {
                    DateTime adt = m_v.f_parse_date(txtTN.Text);
                    DateTime adt1 = m_v.f_parse_date(txtDN.Text);
                    if (adt > adt1)
                    {
                        txtTN.Text = "";
                    }
                }
                catch
                {
                }
            }
        }

        private void txtDN_Validated(object sender, EventArgs e)
        {
            try
            {
                txtDN.Text = m_v.f_string_date(txtDN.Text);
            }
            catch
            {
            }
            if (txtTN.Text.Length == 10 && txtDN.Text.Length == 10)
            {
                try
                {
                    DateTime adt = m_v.f_parse_date(txtTN.Text);
                    DateTime adt1 = m_v.f_parse_date(txtDN.Text);
                    if (adt > adt1)
                    {
                        txtDN.Text = "";
                    }
                }
                catch
                {
                }
            }
        }

        private void dgGia_VisibleChanged(object sender, EventArgs e)
        {
            if (dgGia.Visible)
            {
                cbDoituongTD_Validated(null, null);
            }
        }

        private void txtKhoavv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtKhoavv_Validated(null, null);
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void cbKhoavv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtNgayrv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtSongayDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtICD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtKhoarv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtKhoavv_Validated(null, null);
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void cbKhoarv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (m_dshoadon.Tables[0].Rows.Count > 0)
                    {
                        butLuu.Focus();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabPage2;
                        txtTenvp.Focus();
                    }
                }
            }
            catch
            {
            }
        }

        private void txtTongvp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTongcp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtPhaithu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTamung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTongBNTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbKhoavv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKhoavv.Text = cbKhoavv.SelectedValue.ToString();
            }
            catch
            {
                txtKhoavv.Text = "";
            }
            if (txtKhoavv.Text.Length > 2)
            {
                txtKhoavv.Text = "";
            }
        }
        private void tmn_Luuin_Phieuthuchi_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_phieuthuphieuchi_frmvienphiBHYT(m_userid, tmn_Luuin_Phieuthuchi.Checked);
        }

        private void tmn_Luuin_Hoadon_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_frmvienphiBHYT(m_userid, tmn_Luuin_Hoadon_Icon.Checked);
        }

        private void cbBacsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtBacsi.Text = cbBacsi.SelectedValue.ToString();
            }
            catch
            {
                txtBacsi.Text = "";
            }
            if (txtBacsi.Text.Length > 4)
            {
                txtBacsi.Text = "";
            }
        }

        private void txtICD_Validated(object sender, EventArgs e)
        {
            string atmp = "";
            try
            {
                atmp = m_v.get_data("select vviet from medibv.icd10 where cicd10='" + txtICD.Text.Trim() + "'").Tables[0].Rows[0][0].ToString().Trim();
            }
            catch
            {
                atmp = "";
            }
            if (atmp != "")
            {
                txtChandoan.Text = atmp;
            }
        }

        private void txtNDK_Ma_Validated(object sender, EventArgs e)
        {
            string atmp = "";
            try
            {
                atmp = m_v.get_data("select tenbv from medibv.dmnoicapbhyt where mabv='" + txtNDK_Ma.Text.Trim() + "'").Tables[0].Rows[0][0].ToString().Trim();
            }
            catch
            {
                atmp = "";
            }
            if (atmp != "")
            {
                txtNDK_Ten.Text = atmp;
            }
        }

        private void txtBacsi_Validated(object sender, EventArgs e)
        {
            try
            {
                cbBacsi.SelectedValue = txtBacsi.Text.Trim();
            }
            catch
            {
            }
        }

        private void txtKhoavv_Validated(object sender, EventArgs e)
        {
            try
            {
                cbKhoavv.SelectedValue = txtKhoavv.Text.Trim();
            }
            catch
            {
            }
        }
        private void txtSothe_Validated(object sender, EventArgs e)
        {

            bool bln = true;
            if (cbDoituongTD.SelectedIndex < 0) return;
            if (cbDoituongTD.SelectedIndex >= 0)
            {
                if (cbDoituongTD.SelectedValue.ToString() == "1")
                {
                    char[] a_char ={ ',' };
                    string[] s_char = s_bhyt_chieudai.Split(a_char);
                    for (int i = 0; i < s_char.Length; i++)
                    {
                        int i_len = (s_char[i] == "") ? 0 : int.Parse(s_char[i]);
                        if (txtSothe.Text.Trim().Length == i_len)
                        {
                            bln = true;
                            break;
                        }
                        else
                        {
                            bln = false;
                        }

                    }
                    if (!bln)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ."));
                        txtSothe.Focus();
                    }
                }

            }
        }

        private void label32_Click(object sender, EventArgs e)
        {
            try
            {          
                string atn = "";
                try
                {
                    atn = cbNgayvv.Text.Substring(0, 10);
                }
                catch
                {
                    atn = "";
                }

                frmHoantamung af = new frmHoantamung(m_v, txtMabn.Text + txtMabn1.Text, m_maql, atn, txtNgaythu.Text.Substring(0, 10),m_mavaovien);
                af.ShowInTaskbar = false;
                if (af.ShowDialog() == DialogResult.OK)
                {
                    m_dstamung = af.s_ds;
                    decimal asotien = 0, atmp = 0;
                    foreach (DataRow r in m_dstamung.Tables[0].Select("chon=1"))
                    {
                        try
                        {
                            atmp = decimal.Parse(r["sotien"].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        asotien += atmp;
                    }
                    txtTamung.Text = asotien.ToString("###,###,##0.##");
                   // f_Tinhtien_Tong();
                }
            }
            catch
            {
            }
        }

        private void txtTamung_Validated(object sender, EventArgs e)
        {
            toolStrip_Tamung.Text = txtTamung.Text;
            f_Tinhtien(-1);
        }

        private void txtTamung_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbKyhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string atmp = f_Get_Sobienlai();
            //    txtSobienlai.Text = atmp.Split(':')[0];
            //    if (atmp.Split(':')[1] == "1")//Hết số
            //    {
            //        MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        cbLoaidv.Enabled = false;
            //        cbLoaidv.Focus();
            //        return;
            //    }
            //    else
            //        if (atmp.Split(':')[1] == "2")//Lỗi
            //        {
            //            //MessageBox.Show(this, "Không tìm thấy quyển sổ thu viện phí!\nĐề nghị chọn sổ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //}
            //catch
            //{
            //}
        }

        private void get_tongchiphi_datra(string m_mabn, string m_mavaovien, string m_ngay,string m_sothe)
        {
            string xxx = m_v.user + m_v.mmyy(m_ngay), sql = "", sqlht = "";
            sqlht = "select * from " + xxx + ".v_hoantra where mabn='" + m_mabn + "' and loaibn in (1,3) and to_char(ngay,'dd/mm/yyyy')='" + m_ngay.Substring(0, 10) + "'";
            sql = "select sum(e.sotien) as sotien,b.mien,b.bhyt,b.tamung from " + xxx + ".v_ttrvds a inner join " + xxx + ".v_ttrvll b on a.id=b.id inner join " + xxx + ".v_ttrvbhyt c on a.id=c.id inner join "+xxx+".v_ttrvct e on b.id=e.id ";
            sql += " left join (" + sqlht + ") d on b.quyenso=d.quyenso and b.sobienlai=d.sobienlai ";
            sql += "  where b.sobienlai>0 and a.mabn='" + m_mabn + "' and c.sothe='" + m_sothe + "' and d.id is null";//and to_char(b.ngay,'dd/mm/yyyy')='" + m_ngay.Substring(0, 10) + "'
            sql += " and e.madoituong=1 and e.tra=0 ";
            if (m_id != "") sql += " and a.id <> " + m_id;
            if (m_mavaovien.Trim() != "") sql += " and a.mavaovien=" + m_mavaovien;
            sql += " group by b.mien,b.tamung,b.bhyt";
            DataSet lds= m_v.get_data(sql);
            
            zsotien_datra = 0; zbhyt_datra = 0; zmien_datra = 0; zbntra_datra = 0; ztamung_datra = 0;
            foreach (DataRow r in lds.Tables[0].Rows)
            {
                zsotien_datra += decimal.Parse(r["sotien"].ToString());
                zbhyt_datra  += decimal.Parse(r["bhyt"].ToString());
                zmien_datra += decimal.Parse(r["mien"].ToString());
                ztamung_datra += decimal.Parse(r["tamung"].ToString());
            }
            zbntra_datra = zsotien_datra - zbhyt_datra - zmien_datra;
        }
        

        private bool bBienlai_dasudung(string iQuyenso, string iSobienlai)
        {
            string suser = m_v.user;
            string asql = "select * from " + suser + ".vv_bienlaithuvienphi_" + m_v.get_dmcomputer().ToString().PadLeft(4, '0') + " where quyenso=" + iQuyenso + " and sobienlai=" + iSobienlai;
            DataSet lds = m_v.get_data(asql);
            return lds.Tables[0].Rows.Count > 0;
        }

        private void tmn_nhacnhokhiluu_Click(object sender, EventArgs e)
        {
            m_v.set_o_luu_nhacnho_khiluu(m_userid, tmn_nhacnhokhiluu.Checked);
        }

        private void toolStrip_Mien_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == this.toolStrip_Mien.Control)
            {
                if (toolStrip_Mien.Text.Trim().Length == 1)
                {
                    string s_add = toolStrip_Mien.Text.Trim() == "5" ? "0%" : "5%";
                    toolStrip_Mien.Text = toolStrip_Mien.Text.Trim() + s_add;
                    toolStrip_Mien.SelectionStart = 1;
                    toolStrip_Mien.SelectionLength = toolStrip_Mien.Text.Length - 1;
                }
                else if (toolStrip_Mien.Text.Trim().Length == 2)
                {
                    toolStrip_Mien.Text = toolStrip_Mien.Text.Trim() + "%";
                    toolStrip_Mien.SelectionStart = 2;
                    toolStrip_Mien.SelectionLength = toolStrip_Mien.Text.Length - 2;
                }

            }
        }

        private void tmn_Nhaplydomien_Click(object sender, EventArgs e)
        {
            m_v.set_bhyt_nhaplydomien(m_userid, tmn_Nhaplydomien.Checked);
        }

        private void tmn_Nhapkymien_Click(object sender, EventArgs e)
        {
            m_v.set_bhyt_nhapduyetmien(m_userid, tmn_Nhapkymien.Checked);
        }

        private void cbKymien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKymien.Text = cbKymien.SelectedValue.ToString();
            }
            catch
            {
            }
        }

        private void cbKymien_Validated(object sender, EventArgs e)
        {
            try
            {
                txtKymien.Text = cbKymien.SelectedValue.ToString();
            }
            catch
            {
            }
        }

        private void cbLydomien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtLydomien.Text = cbLydomien.SelectedValue.ToString();
            }
            catch
            {
            }
        }

        private void cbLydomien_Validated(object sender, EventArgs e)
        {
            try
            {
                txtLydomien.Text = cbLydomien.SelectedValue.ToString();
            }
            catch
            {
            }
        }

        private void txtLydomien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cbLydomien.SelectedValue = txtLydomien.Text;
            }
            catch
            {
            }
        }

        private void txtLydomien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void txtKymien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void txtKymien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cbKymien.SelectedValue = txtKymien.Text;
            }
            catch
            {
            }
        }     
    }
}