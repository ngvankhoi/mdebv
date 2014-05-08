using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Vienphi
{
    public partial class frmVienphiBHYT_hepa : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private frmGoibenhKham fgoi;
        private int sizestt = 120;
        private string s_idthutamung = "", s_idbhytkb = "", s_loaidt_sokham="BH";
        private string m_cur_yy = "";
        private string m_id_gia = "";
        private string m_giodangkykham = "", v_ngaygiodangky = "";//binh 140711
        private int i_loaitg_dkkham = 0;//binh 140711
        private string s_bhyt_chieudai = "";
        private string s_bhyt_kytu = "";
        private string s_bhyt_vitri = "";
        private decimal d_bhyt_sotien = 0,v_sotien_huong_bhyt = -1;
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
        private bool bInphieumiengiam = false, v_nhapmienchitiet = false, v_Giamchitiet = false, m_Docmavach = true;
        private bool b_upd_bhytkb = false;
        private int i_maxlength_mabn = 8;
        private bool bKhongchoxem_tongthu = false,bThuCLS = false,bCongkham = false,bInsttcho = false;
        private TableLayoutPanel m_table;
        //private LibBaocao.AccessData lib_bc = new LibBaocao.AccessData();
        private LibVP.AccessData m_v;
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private DataSet m_dshoadon, m_dstamung, dsqs;
        private DataTable dtdm = new DataTable();
        private string m_id = "", m_mavaovien = "", m_maql = "", m_userid = "", m_maql_tiepdon = "",s_matunguyen="";
        private DataSet m_dsgiavp;
        private DataSet m_dsnhomvp;
        private DataSet m_dsloaivp;
        private DataSet ds_bnmien;

        private string m_id_toathuocbhyt = "", v_dongiabhyt = "";
        private decimal zsotien_datra = 0, zbhyt_datra = 0, zmien_datra = 0, zbntra_datra = 0, ztamung_datra=0;

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
        private int i_chinhanh = 0;
        private bool bNhieudot = false;
        private string acongkham = "0";
        private int i_tylechinhsach = 0;

        public frmVienphiBHYT_hepa(LibVP.AccessData v_v, string v_userid)
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
            //txtMabn1.Mask.Length = m.i_maxlength_mabn - 2;
            //
            try
            {
                i_maxlength_mabn = LibVP.AccessData.i_maxlength_mabn;

                i_chinhanh = f_get_chinhanh(int.Parse(m_userid));
                //
                iTunguyen = m_v.iTunguyen; cmbTraituyen.SelectedIndex = 0;
                lTraituyen = (m.bTraituyen) ? m.lTraituyen_phongkham : 0;
                iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
                s_bhyt_chieudai = f_Load_Bhyt_Chieudai().ToString().Trim().Trim(',') + ",";
                s_bhyt_kytu = f_Load_Bhyt_Kytu().ToString().Trim().Trim('+') + "+";
                s_bhyt_vitri = f_Load_Bhyt_Vitri().ToString().Trim();
                m_doituongthu = m_v.bhyt_chithudoituong(m_userid);
                d_bhyt_sotien = decimal.Parse(f_Load_Bhyt_Sotien().ToString().Trim());
                v_solanin = m_v.sys_solanin;
                m_Docmavach = m_v.tt_Quanlymavach(m_userid);
                //
                if (m_Docmavach)
                {
                    txtMabn.Mask = "9999999999";
                    txtMabn1.Mask = "9999999999";
                }
                //
                v_Giamchitiet = m_v.tt_Nhapmiengianchitiet(m_userid);
                bKhongchoxem_tongthu = m_v.sys_khongchoxem_tongthu == "1";
                v_tachhoadon_dv = m_v.bhyt_tachhoadon_dichvu(m_userid);
                v_tachbienlai_dv = m_v.bhyt_bienlai_dichvu(m_userid);
                v_bhyt_suanoidunghoadon = m_v.bhyt_suanoidunghoadon(m_userid);
                bThuCLS = false;// đánh dấu hóa đơn thu CLS cần quay lại phòng khám 
                bInphieumiengiam = true;// cho lay form option khai bao them option in phiếu miễn giảm
                bInsttcho = true; // chờ lấy from option khai báo in thêm dòng bác sĩ đọc kết quả ( hepa)
                bThuchenhlechtruoc_duyettoasau = m_v.bThuchenhlechtruoc_duyettoasau(m.nhom_duoc);
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

                dgHoadon.AutoGenerateColumns = false;
                bLaygiamua_khi_giabh_0_giabh_nho_giamua = m.bLaygiamua_khi_giabh_0_giabh_nho_giamua;
                if(m_v.bhyt_suanoidunghoadon(m_userid )==false) dgHoadon.ReadOnly = true;
                f_Load_Thutrongngay();
                f_Load_DG();
                f_Load_Data();
                f_Load_Hotkey();
                f_Load_Tonghop();
                f_load_loaitg();
                f_Enable(false);                
                this.Refresh();
                string tmp_qso = m_cur_quyenso;
                lbKyhieu_Click(null, null);
                s_quyenso = tmp_qso;
                txtSobienlai.ReadOnly = true;
                if (cbKyhieu.Items.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Phải khai báo quyển sổ thu viện phí trước!") + "\n" + lan.Change_language_MessageText("Vào [Tiện ích] - [Khai báo quyển sổ] để khai!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                }
                cbLoaidv_SelectedIndexChanged(null, null);
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
                v_nhapmienchitiet = m_v.tt_Nhapmientheotungmon(m_userid);
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

                // thêm cb ly do mien + người duyệt miễn
                ads = m_v.get_data("select id,ten from medibv.v_lydomien order by ten asc");
                DataRow  r = ads.Tables[0].NewRow();
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

                cbphatthuoc.DisplayMember = "ten";
                cbphatthuoc.ValueMember = "id";
                cbphatthuoc.DataSource = m_v.get_data("select id,ten from medibv.dmphongthuchiencls where loai=1").Tables[0];

                // end
                sql = "select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong ";
                if (m_v.bhyt_thuBHYT_tructiep(m_userid) == false)
                {
                    if (m_doituongthu.Trim().Trim(',') == "") sql += " where madoituong=1 or mien=1 ";
                    else sql += " where madoituong=1 or mien=1 or madoituong in(" + m_doituongthu.Trim().Trim(',') + ")";
                }
                sql += " order by madoituong ";
                //ads = m_v.get_data("select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong where madoituong=1 or mien=1 order by madoituong");
                ads = m_v.get_data(sql);//"select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong order by madoituong");
                cbDoituongTD.DataSource = ads.Tables[0].Copy();
                cbDoituongTD.DisplayMember = "doituong";
                cbDoituongTD.ValueMember = "madoituong";

                m_doituongmien = "";
                foreach (DataRow r1 in ads.Tables[0].Select("mien=1"))
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
                dsqs = m_v.get_data(sql); 
                cbKyhieu.DisplayMember = "sohieu";
                cbKyhieu.ValueMember = "id";
                cbKyhieu.DataSource = dsqs.Tables[0];
                

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

                //
                sql = "select a.id, case when b.id_nhom is null then 0 else b.id_nhom end as id_nhom,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.bhyt, case when a.ndm is null then 0 else a.ndm end as ndm, 0 as loaigia, a.bhyt_tt, chuyenchungtu, cosothay, coso ";
                sql += " from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id ";
                sql += " union all ";
                sql += " select a1.id,case when b1.nhomvp is null then 0 else b1.nhomvp end as id_nhom,a1.ma,a1.ten || case when trim(a1.tenhc)='' then '' else '[' || trim(a1.tenhc) || ']' end as ten ,a1.dang as dvt, a1.giaban as gia_th, a1.giaban as gia_bh, a1.giaban as gia_dv,a1.giaban as gia_nn, a1.giaban as gia_cs, a1.bhyt,0 as ndm, 1 as loaigia, a1.bhyt as bhyt_tt, to_number('0') as chuyenchungtu, '' as cosothay, to_number('0') as coso ";
                sql += " from medibv.d_dmbd a1 inner join medibv.d_dmnhom b1 on a1.manhom=b1.id where b1.nhom=1 order by ten";
                //
                m_dsgiavp = m_v.get_data(sql);
                m_dsnhomvp = m_v.get_data("select ma as id, stt, ten,viettat, to_number('0') as sotien from medibv.v_nhomvp order by stt, ten");
                m_dsloaivp = m_v.get_data("select id,stt,ten,viettat,id_nhom,to_number('0') as sotien from medibv.v_loaivp order by stt, ten");

                sql = "select to_char(now(),'') as ma, to_char(now(),'') as ten,to_char(now(),'') as dvt,to_number('0') as soluong, to_number('0') as dongia, to_number('0') as sotien, to_number('0') as bhyttra,to_number('0') as bntra, to_number('0') as mavp, to_number('0') as madoituong,to_number('0') as dichvu";
                m_dshoadon = m_v.get_data(sql).Clone();
                //m_dshoadon.Tables[0].Rows.Clear();
                dgHoadon.DataSource = m_dshoadon.Tables[0];

                sql = "select to_number('0') as chon, to_char(now(),'dd/mm/yyyy hh24:mi') as ngay, '' as sohieu, to_number('0') as sobienlai,to_number('0') as sotien,'' as user, to_number('0') as done, to_number('0') as id";
                m_dstamung = m_v.get_data(sql);
                m_dstamung.Tables[0].Rows.Clear();


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
                tmn_inmau38bv.Checked = m_v.get_o_luuin_mau38_frmvienphiBHYT(m_userid);
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

                
                //tmn_nhacnhokhiluu.Checked = m_v.get_o_luu_nhacnho_khiluu(m_userid);

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
                            if (tmn_Nhaplydomien.Checked && txtMien.Text.Trim().Trim('0')!="")
                            {
                                txtLydomien.Focus();
                            }
                            else if (tmn_Nhapkymien.Checked && txtMien.Text.Trim().Trim('0') != "")
                            {
                                txtKymien.Focus();
                            }                            
                            else 
                            {
                                //butLuu.Focus();
                                txtTienBNDua.Focus();
                            }
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
                txtMabn1.Tag = "";
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

                txtLydomien.Enabled = v_bool && tmn_Nhaplydomien.Checked;
                cbLydomien.Enabled = v_bool && tmn_Nhaplydomien.Checked;
                txtKymien.Enabled = v_bool && tmn_Nhapkymien.Checked;
                cbKymien.Enabled = v_bool && tmn_Nhapkymien.Checked;

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
                bThuCLS = false;
                bCongkham = false;

                txtMabn.Enabled = true ;
                txtMabn1.Enabled = true ;
                txtMabn1.Tag = "";
                tmn_Danhsachcho.Enabled = true ;

                txtKymien.Text = "";
                txtLydomien.Text = "";

                f_FullScreen(m_o_fullscreen);
                m_bnmoi = true;
                v_loadcho = false;
                m_id = "";
                m_id_toathuocbhyt = "";

                m_mavaovien = "";
                m_maql = "";
                m_id_gia = "";
                toolStrip_BNDua.Text = "";
                toolStrip_Thoilai.Text = "";
                txtTienBNDua.Text = "";
                txtTienthoilai.Text = "";

                lblsokham.Text = "";

                b_hddathu = false;
                b_sua = false;
                b_upd_bhytkb = false;
                m_sohieu = "";
                cbNgayvv.DataSource = null;
                m_dshoadon.Tables[0].Rows.Clear();
                m_dstamung.Tables[0].Rows.Clear();
                m_dshoadon.AcceptChanges();
                dgHoadon.Update();
                dgHoadon.Refresh();
                rdTienmat.Checked = true;

                f_Clear_pTonghop();
                f_Tinhtien(-1);
                f_Clear_HC();
                f_Enable(true);
                f_Enable_HC(true);
                txtNgaythu.Value = m_cur_ngay;
                //binh 140711
                cbloaitg.Tag = "";
                m_giodangkykham = "";
                v_ngaygiodangky = m_v.Ngaygio_hienhanh;
                i_loaitg_dkkham = 0;
                ///
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
                m_dshoadon.Tables[0].Rows.Clear();
                m_dstamung.Tables[0].Rows.Clear();
                m_dshoadon.AcceptChanges();
                dgHoadon.DataSource = m_dshoadon.Tables[0];
                dgHoadon.Update();
                dgHoadon.Refresh();
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
            if (txtMabn1.Text.Trim().Length != i_maxlength_mabn-2)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập mã số bệnh nhân!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMabn1.Focus();
                return false;
            }

            //if (txtICD.Text == "" && !tmn_khongcungchitra.Checked)
            //{
            //    f_FullScreen(false);
            //    butLuu.Enabled = true;
            //    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập mã chẩn đoán bệnh!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtICD.Focus();
            //    return false;
            //}
            //if (txtChandoan.Text == "" && !tmn_khongcungchitra.Checked)
            //{
            //    f_FullScreen(false);
            //    butLuu.Enabled = true;
            //    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập chẩn đoán bệnh!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtChandoan.Focus();
            //    return false;
            //}
            if (cbKhoavv.SelectedIndex < 0)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập khoa phòng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbKhoavv.Focus();
                SendKeys.Send("{F4}");
                return false;
            }
            //if (cbBacsi.SelectedIndex < 0)
            //{
            //    f_FullScreen(false);
            //    butLuu.Enabled = true;
            //    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập bác sĩ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cbBacsi.Focus();
            //    SendKeys.Send("{F4}");
            //    return false;
            //}
            if (cbNgayvv.Items.Count <= 0)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Bệnh nhân chưa có hồ sơ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMabn.Focus();
                return false;
            }
            return true;
        }
        private DataSet capIdPhongCLS(DataSet dsHoadonct, ref int v_sttthuoc)
        {
            DataSet ds1 = new DataSet();
            ds1 = dsHoadonct.Clone();
            string[] sidphong = { "0" };
            string sphong = "";
            int min = 0, k = 0, tam = 0;
            foreach (DataRow r in dsHoadonct.Tables[0].Rows)
            {
                DataRow r2 = ds1.Tables[0].NewRow();
                try
                {
                    sphong = f_get_idphongcls(r["phongthuchiencls"].ToString(), i_chinhanh).Trim(',');//binh 270711
                    sidphong = sphong.Trim(',').Split(',');// lay phong thuc hien cls thuoc chi nhanh
                    //sidphong = r["phongthuchiencls"].ToString().Split(',');
                    //sphong = r["phongthuchiencls"].ToString();//binh 270711 comment
                    r2["ma"] = r["ma"].ToString();
                    r2["ten"] = r["ten"].ToString();
                    r2["mabs"] = r["mabs"].ToString();
                    r2["id"] = r["id"].ToString();
                    r2["dvt"] = r["dvt"].ToString();
                    r2["soluong"] = r["soluong"].ToString();
                    r2["dongia"] = r["dongia"].ToString();
                    r2["giaban"] = r["giaban"].ToString();
                    r2["gia_bh"] = r["gia_bh"].ToString();
                    r2["sotien"] = r["sotien"].ToString();
                    r2["bhyttra"] = r["bhyttra"].ToString();
                    r2["bntra"] = r["bntra"].ToString();
                    r2["mavp"] = r["mavp"].ToString();
                    r2["madoituong"] = r["madoituong"].ToString();
                    r2["loai"] = r["loai"].ToString();
                    r2["dichvu"] = r["dichvu"].ToString();
                    r2["nhom"] = r["nhom"].ToString();
                    r2["mien"] = r["mien"].ToString();
                    r2["phongthuchiencls"] = r["phongthuchiencls"].ToString();
                    r2["phuthu"] = r["phuthu"].ToString();//binh 100711 -->
                    r2["idtonghop"] = r["idtonghop"].ToString();//binh 100711 -->

                    r2["makp"] = r["makp"].ToString();//binh 100711 -->
                    r2["mabs"] = r["mabs"].ToString();//binh 100711 -->
                    r2["losx"] = r["losx"].ToString();//binh 100711 -->
                    r2["handung"] = r["handung"].ToString();//binh 100711 -->
                    r2["sttcho"] = r["sttcho"].ToString();
                }
                catch(Exception ex) { }
                if ((sidphong.Length == 1 || sidphong[0] == "0") && r["loai"].ToString() == "0") // neu phong thuc hien chi co 1 phong thi gan maphongcls=phongthuchiencls va sttcho
                {
                    try
                    {
                        // nếu là công khám thì phát sinh thêm stt chờ khám
                        // nếu là công khám thì lấy stt từ tiepdon vao
                        if (m_v.bCongkham(r["mavp"].ToString()))
                        {
                            string v_sttkham = "0", v_tenpk = "";
                            f_get_sttkham(f_get_mabn(), cbNgayvv.Text.Substring(0, 10), r["makp"].ToString(), ref v_sttkham, ref v_tenpk);
                            bCongkham = true;
                            r2["maphongcls"] = r["makp"].ToString();// txtKhoavv.Text;
                            r2["sttcho"] = v_sttkham;// (txtMabn1.Tag.ToString() == "") ? "1" : txtMabn1.Tag.ToString();//capSttCho(int.Parse(txtKhoavv.Text == "" ? "0" : txtKhoavv.Text),2,2);
                        }
                        else if (m_v.bCLS(r["mavp"].ToString())) // là xét nghiệm hoặc CDHA phát sinh số stt chờ lấy mẫu
                        {
                            bThuCLS = true;
                            r2["maphongcls"] = (sidphong[0] == "") ? "0" : sidphong[0];//binh 090711 // r2["maphongcls"]=r["phongthuchiencls"].ToString() == "" ? "0" : r["phongthuchiencls"].ToString();
                            r2["sttcho"] = capSttCho(int.Parse(sidphong[0] == "" ? "0" : sidphong[0]), int.Parse(r["loai"].ToString() == "" ? "0" : r["loai"].ToString()), 0);
                        }
                        else
                        {
                            r2["maphongcls"] = 0;
                            r2["sttcho"] = 0;
                        }
                        ds1.Tables[0].Rows.Add(r2);
                    }
                    catch (Exception ex) {MessageBox.Show(ex.ToString()); }
                }
                else if (r["loai"].ToString() == "1")// nếu là tiền thuốc BHYT thì phát sinh stt chờ lấy thuốc
                {
                    string maphong = cbphatthuoc.SelectedIndex <0 ? "0" : cbphatthuoc.SelectedValue.ToString();
                    v_sttthuoc = capSttCho(int.Parse(maphong), 0, 1);
                    r2["maphongcls"] = maphong ;
                    r2["sttcho"] = v_sttthuoc;
                    ds1.Tables[0].Rows.Add(r2);
                }
                else // neu 1 chi dinh co tren 2 phong thuc hien thi kiem tra 
                {
                    // neu bn co lam dv tai 1 trong những phòng này thì ưu tiên cho bn thuc hien tai phong nay va lay sttcho
                    string exp = "";
                    if (sphong != "") exp = "maphongcls in (" + sphong + ")";
                    if ( ds1.Tables[0].Select(exp).Length > 0)
                    {
                        foreach (DataRow r1 in ds1.Tables[0].Select(exp))//"maphongcls in (" + sphong + ")")
                        {
                            r2["maphongcls"] = r1["maphongcls"].ToString();
                            r2["sttcho"] = capSttCho(int.Parse(r1["maphongcls"].ToString()), int.Parse(r["loai"].ToString() == "" ? "0" : r["loai"].ToString()),0);
                            ds1.Tables[0].Rows.Add(r2);
                            break;
                        }
                    }
                    else
                    {
                        // neu bn khong lam lam dv ca hai phong nay thi lay sttcho cua 2 phong neu sttcho nao nho nhất 
                        //thì gán maphong thực hiện là phòng có stt chờ nhỏ nhất
                        min = capSttCho((sidphong[0] == "") ? 0 : int.Parse(sidphong[0]), int.Parse(r["loai"].ToString() == "" ? "0" : r["loai"].ToString()), 0);
                        for (int j = 1; j < sidphong.Length; j++)
                        {
                            tam = capSttCho((sidphong[j] == "") ? 0 : int.Parse(sidphong[j]), int.Parse(r["loai"].ToString() == "" ? "0" : r["loai"].ToString()), 0);
                            if (tam < min)
                            {
                                k = j;
                                min = tam;
                            }
                        }
                        r2["maphongcls"] = sidphong[k] == "" ? "0" : sidphong[k];
                        r2["sttcho"] = min;
                        ds1.Tables[0].Rows.Add(r2);
                    }
                }
            }
            return ds1;
        }
        //private int capSTTChoKham(int mapk)
        //{
        //    string angay = txtNgaythu.Text.Substring(0, 10);
        //    string ammyy = m_v.get_mmyy(angay);
        //    string asql = "select count(*) from medibvmmyy.tiepdon where makp='" + mapk.ToString().PadLeft(3, '0') + "' and to_char(ngay,'dd/mm/yyyy')='" + angay + "'";
        //    DataTable dt = m_v.get_data_mmyy(ammyy, asql).Tables[0];// gam 19-06-2011
        //    if (dt.Rows.Count == 0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return (int.Parse(dt.Rows[0][0].ToString()) + 1);
        //    }
        //}
        private int capSttCho(int idphongthuchiencls, int v_idloaivp,int v_loai_cls_thuoc_kham)
        {
            // v_loai_cls_thuoc_kham = 0: CLS, v_loai_cls_thuoc_kham = 1: thuoc,v_loai_cls_thuoc_kham = 2: stt chờ tại phòng khám
            if (idphongthuchiencls == 0) return 0;
            else 
            {                
                string angay = txtNgaythu.Text.Substring(0, 10);
                string ammyy = m_v.get_mmyy(angay);
                string sql = "";
                if (v_loai_cls_thuoc_kham == 0)
                {
                    //cls
                    sql = "select count(*) as sttcho from ( ";
                    sql += " select distinct idphongthuchiencls, stt from medibvmmyy.v_chidinh where idphongthuchiencls=" + idphongthuchiencls + " and paid=1 and to_char(ngay,'dd/mm/yyyy')='" + angay + "'";
                    sql += ") a";
                                                                              
                    //binh cap stt cho bi loi
                    //ve nha kiem tra va sua lai
                    //sql = "select count(*) as sttcho from (";
                    //sql+=" select distinct mabn, idphongthuchiencls, idchidinh from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.dmphongthuchiencls c ";
                    //sql += "on b.id_loai=c.id_loaivp where c.id=" + idphongthuchiencls + " and a.paid=1 and to_char(ngay,'dd/mm/yyyy')='" + angay + "'";//binh 090711 bo dk//and (','|| c.id_loaivp || ',') like '%," + idloai + ",%' 
                    //sql += " ) a";
                    //end loi
                }
                else if (v_loai_cls_thuoc_kham == 1)
                {
                    sql = "select max(sttcho) from medibvmmyy.bhytkb where quyenso>0 and sobienlai>0 and idphongcls=" + idphongthuchiencls + " and to_char(ngay,'dd/mm/yyyy')='" + angay + "'";
                }
                else if (v_loai_cls_thuoc_kham == 2)
                {
                    sql = "select max(to_number(sovaovien)) as sttcho from medibvmmyy.tiepdon where makp='" + idphongthuchiencls.ToString().PadLeft(3, '0') + "' and to_char(ngay,'dd/mm/yyyy')='" + angay + "' and sovaovien is not null and trim(sovaovien)<>''";
                }
                DataSet dt = m_v.get_data_mmyy(ammyy, sql);// gam 17-06-2011
                if (dt==null || dt.Tables.Count<=0 || dt.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                else
                {                    
                    //
                    return (int.Parse(dt.Tables[0].Rows[0][0].ToString() == "" ? "0" : dt.Tables[0].Rows[0][0].ToString()) + 1); ;
                }
            }
        }
        private void f_InPhieuMien_tbl_vienphill(string aid)
        {
            string ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16));
            string anoidung = "";
            DataSet ads = new DataSet();
            string asql = "select distinct a.id,d.hoten,d.namsinh,d.mabn,a.diachi, i.ten as noidung,c.sotien,c.lydo,f.ten as nguoiduyet ,n.hoten as nguoithu ";
            asql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id ";
            asql += " left join medibvmmyy.v_mienngtru c on a.id=c.id inner join medibv.btdbn d on a.mabn=d.mabn";
            asql += " left join medibv.tylemien_mg e on a.mavaovien=e.mavaovien left join medibv.v_dsduyet f ";
            asql += " on e.nguoiduyetmien=f.ma inner join medibvmmyy.tiepdon g on a.maql=g.maql inner join ";
            asql += " medibv.doituong h on g.madoituong=h.madoituong inner join medibv.v_giavp k on b.mavp=k.id ";
            asql += "inner join medibv.v_loaivp i on k.id_loai=i.id inner join medibv.v_dlogin n on a.userid=n.id where a.id=" + aid;

            if (tmn_Cokhambenh.Checked)
            {
                if (asql != "") asql += " union all ";
                asql += "select distinct a.id,d.hoten,d.namsinh,d.mabn,a.diachi, i.ten as noidung,c.sotien,c.lydo,f.ten as nguoiduyet ,n.hoten as nguoithu ";
                asql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id ";
                asql += " left join medibvmmyy.v_mienngtru c on a.id=c.id inner join medibv.btdbn d on a.mabn=d.mabn";
                asql += " left join medibv.tylemien_mg e on a.mavaovien=e.mavaovien left join medibv.v_dsduyet f ";
                asql += " on e.nguoiduyetmien=f.ma inner join medibvmmyy.benhanpk g on a.maql=g.maql inner join ";
                asql += " medibv.doituong h on g.madoituong=h.madoituong inner join medibv.v_giavp k on b.mavp=k.id ";
                asql += "inner join medibv.v_loaivp i on k.id_loai=i.id inner join medibv.v_dlogin n on a.userid=n.id where a.id=" + aid;
            }
            if (tmn_Cophongluu.Checked)
            {
                if (asql != "") asql += " union all ";
                asql += "select distinct a.id,d.hoten,d.namsinh,d.mabn,a.diachi, i.ten as noidung,c.sotien,c.lydo,f.ten as nguoiduyet ,n.hoten as nguoithu ";
                asql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id ";
                asql += " left join medibvmmyy.v_mienngtru c on a.id=c.id inner join medibv.btdbn d on a.mabn=d.mabn";
                asql += " left join medibv.tylemien_mg e on a.mavaovien=e.mavaovien left join medibv.v_dsduyet f ";
                asql += " on e.nguoiduyetmien=f.ma inner join medibvmmyy.benhancc g on a.maql=g.maql inner join ";
                asql += " medibv.doituong h on g.madoituong=h.madoituong inner join medibv.v_giavp k on b.mavp=k.id";
                asql += " inner join medibv.v_loaivp i on k.id_loai=i.id inner join medibv.v_dlogin n on a.userid=n.id where a.id=" + aid;
            }
            ads = m_v.get_data_mmyy(ammyy, asql);

            string asyt = "", abv = "", adiachibv = "", aReport = "";

            foreach (DataRow r in ads.Tables[0].Rows)
            {
                anoidung += r["noidung"].ToString() + ",";
            }
            anoidung = anoidung.Trim(',');
            aReport = "v_inphieumien.rpt";
            if (ads.Tables[0].Rows.Count > 0)
            {

                if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                asyt = m_v.Syte;
                abv = m_v.Tenbv;
                adiachibv = m_v.s_diachi;

                ads.WriteXml("..\\..\\Datareport\\v_inphieumien.xml", XmlWriteMode.WriteSchema);

                CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crystalReportViewer1.ActiveViewIndex = -1;
                crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
                crystalReportViewer1.DisplayGroupTree = false;
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                crystalReportViewer1.Name = "crystalReportViewer1";
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
                crystalReportViewer1.TabIndex = 85;

                System.Windows.Forms.Form af = new System.Windows.Forms.Form();
                af.WindowState = FormWindowState.Maximized;
                af.Controls.Add(crystalReportViewer1);
                crystalReportViewer1.BringToFront();
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                ReportDocument cMain = new ReportDocument();

                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);

                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + txtNgaythu.Text.Substring(0, 10) + "'";
                cMain.DataDefinition.FormulaFields["s_noidung"].Text = "'" + anoidung + "'";

                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = "In phiếu miễn ";
                af.Text = af.Text + " (" + aReport + ")";
                af.ShowDialog();

            }
        }
        private void f_InPhieuMien(string aid)
        {
            // gam 14-07-2011
            string ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16));
            string anoidung = "";
            DataSet ads = new DataSet();
            string asql = "select distinct a.id,'" + cbDoituongTD.Text + "' as doituong,d.hoten,d.namsinh,d.mabn,gg.tenpxa||','||hh.tenquan||',' ||ii.tentt as diachi, i.ten as noidung,c.sotien,kk.ten as lydo,f.ten as nguoiduyet ,n.hoten as nguoithu ";
            asql += " from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
            asql += " left join medibvmmyy.v_mienngtru c on a.id=c.id inner join medibv.btdbn d on aa.mabn=d.mabn";
            asql += " left join medibv.tylemien_mg e on aa.mavaovien=e.mavaovien left join medibv.v_dsduyet f ";
            asql += " on e.nguoiduyetmien=f.ma inner join medibvmmyy.tiepdon g on aa.maql=g.maql inner join ";
            asql += " medibv.doituong h on g.madoituong=h.madoituong inner join medibv.v_giavp k on b.mavp=k.id ";
            asql += "inner join medibv.v_loaivp i on k.id_loai=i.id inner join medibv.v_dlogin n on a.userid=n.id ";
            asql += "inner join medibv.btdpxa gg on d.maphuongxa=gg.maphuongxa inner join medibv.btdquan hh on d.maqu=hh.maqu inner join medibv.btdtt ii on d.matt=ii.matt ";
            asql += "inner join medibv.v_lydomien kk on c.lydo=kk.id ";
            asql += "where a.id=" + aid;

            if (tmn_Cokhambenh.Checked)
            {
                if (asql != "") asql += " union all ";
                asql += "select distinct a.id,'" + cbDoituongTD.Text + "' as doituong,d.hoten,d.namsinh,d.mabn,gg.tenpxa||','||hh.tenquan||',' ||ii.tentt as diachi, i.ten as noidung,c.sotien,kk.ten as lydo,f.ten as nguoiduyet ,n.hoten as nguoithu ";
                asql += " from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                asql += " left join medibvmmyy.v_mienngtru c on a.id=c.id inner join medibv.btdbn d on aa.mabn=d.mabn";
                asql += " left join medibv.tylemien_mg e on aa.mavaovien=e.mavaovien left join medibv.v_dsduyet f ";
                asql += " on e.nguoiduyetmien=f.ma inner join medibvmmyy.benhanpk g on aa.maql=g.maql inner join ";
                asql += " medibv.doituong h on g.madoituong=h.madoituong inner join medibv.v_giavp k on b.mavp=k.id ";
                asql += "inner join medibv.v_loaivp i on k.id_loai=i.id inner join medibv.v_dlogin n on a.userid=n.id ";
                asql += " inner join medibv.btdpxa gg on d.maphuongxa=gg.maphuongxa inner join medibv.btdquan hh on d.maqu=hh.maqu inner join medibv.btdtt ii on d.matt=ii.matt ";
                asql += "inner join medibv.v_lydomien kk on c.lydo=kk.id ";
                asql += "where aa.id=" + aid;
            }
            if (tmn_Cophongluu.Checked)
            {
                if (asql != "") asql += " union all ";
                asql += "select distinct a.id,'" + cbDoituongTD.Text + "' as doituong,d.hoten,d.namsinh,d.mabn,gg.tenpxa||','||hh.tenquan||',' ||ii.tentt as diachi, i.ten as noidung,c.sotien,kk.ten as lydo,f.ten as nguoiduyet ,n.hoten as nguoithu ";
                asql += " from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id ";
                asql += " left join medibvmmyy.v_mienngtru c on a.id=c.id inner join medibv.btdbn d on aa.mabn=d.mabn";
                asql += " left join medibv.tylemien_mg e on aa.mavaovien=e.mavaovien left join medibv.v_dsduyet f ";
                asql += " on e.nguoiduyetmien=f.ma inner join medibvmmyy.benhancc g on aa.maql=g.maql inner join ";
                asql += " medibv.doituong h on g.madoituong=h.madoituong inner join medibv.v_giavp k on b.mavp=k.id";
                asql += " inner join medibv.v_loaivp i on k.id_loai=i.id inner join medibv.v_dlogin n on a.userid=n.id ";
                asql += "inner join medibv.btdpxa gg on d.maphuongxa=gg.maphuongxa inner join medibv.btdquan hh on d.maqu=hh.maqu inner join medibv.btdtt ii on d.matt=ii.matt ";
                asql += "inner join medibv.v_lydomien kk on c.lydo=kk.id ";
                asql += "where aa.id=" + aid;
            }
            ads = m_v.get_data_mmyy(ammyy, asql);

            string asyt = "", abv = "", adiachibv = "", aReport = "";

            foreach (DataRow r in ads.Tables[0].Rows)
            {
                anoidung += r["noidung"].ToString() + ",";
            }
            anoidung = anoidung.Trim(',');
            aReport = "v_inphieumien.rpt";
            if (ads.Tables[0].Rows.Count > 0)
            {

                if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy report ") + aReport, m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                asyt = m_v.Syte;
                abv = m_v.Tenbv;
                adiachibv = m_v.s_diachi;

                ads.WriteXml("..\\..\\Datareport\\v_inphieumien.xml", XmlWriteMode.WriteSchema);

                CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crystalReportViewer1.ActiveViewIndex = -1;
                crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
                crystalReportViewer1.DisplayGroupTree = false;
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                crystalReportViewer1.Name = "crystalReportViewer1";
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
                crystalReportViewer1.TabIndex = 85;

                System.Windows.Forms.Form af = new System.Windows.Forms.Form();
                af.WindowState = FormWindowState.Maximized;
                af.Controls.Add(crystalReportViewer1);
                crystalReportViewer1.BringToFront();
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                ReportDocument cMain = new ReportDocument();

                cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);

                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + txtNgaythu.Text.Substring(0, 10) + "'";
                cMain.DataDefinition.FormulaFields["s_noidung"].Text = "'" + anoidung + "'";

                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = "In phiếu miễn ";
                af.Text = af.Text + " (" + aReport + ")";
                af.ShowDialog();

            }
        }
        private void f_Luu()
        {
            try
            {
                //
                string s_loaiba = "0,";
                s_loaiba += (tmn_Cokhambenh.Checked) ? "3," : "";
                s_loaiba += (tmn_Cophongluu.Checked) ? "4," : "";
                s_loaiba += (tmn_conamngoaitru.Checked) ? "2," : "";
                s_loaiba += (tmn_Conhanbenh.Checked) ? "1," : "";
                s_loaiba = s_loaiba.Trim().Trim(',');
                //
                bool asua = (m_id != "" && m_id != "0");
                string atmp = "", aidcd = "";
                butLuu.Enabled = false;
                int sttThuoc = 0;

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
                if (cbDoituongTD.SelectedValue.ToString() != "1" && toolStrip_Mien.Text != "0" && tmn_Nhaplydomien.Checked && cbLydomien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Đề nghị nhập lý do miễn giảm!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLydomien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (cbDoituongTD.SelectedValue.ToString() != "1" && toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Đề nghị nhập người duyệt miễn giảm!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKymien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (toolStrip_Tongcong.Text == toolStrip_BHYT.Text && !b_bhyt_100_theodoibienlai)
                {
                    asobienlai = "-1";
                }
                else
                {
                    asobienlai = txtSobienlai.Text.Trim();
                }
                amabn = txtMabn.Text.Trim() + txtMabn1.Text.Trim();
                if (amabn.Length != i_maxlength_mabn )
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
                //cap so thu tu kham khi luu hoa don
                if (lblsokham.Text.Trim() == "")
                {
                    if (cbDoituongTD.SelectedValue.ToString() == "1")//bhyt
                        s_loaidt_sokham = "BH";
                    else s_loaidt_sokham = "DV";
                    string v_ddmmyy = txtNgaythu.Text.Substring(0, 2) + txtNgaythu.Text.Substring(3, 2) + txtNgaythu.Text.Substring(8, 2);
                    decimal v_sttkham = m_v.get_v_capsokham(1, v_ddmmyy, s_loaidt_sokham, i_chinhanh);
                    lblsokham.Text = s_loaidt_sokham + i_chinhanh.ToString().PadLeft(2, '0') + v_ddmmyy + v_sttkham.ToString().PadLeft(6, '0');
                    lblsokham.Refresh();
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
                // gam hepa 17-06-2011 cấp phòng và số thứ tự chờ 
                m_dshoadon = capIdPhongCLS(m_dshoadon, ref sttThuoc);
                // end gam
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
                //if (tmn_nhacnhokhiluu.Checked && atongtien <= d_tongtien && !tmn_khongcungchitra.Checked)
                //{
                //    if (MessageBox.Show(lan.Change_language_MessageText("Có lưu hóa đơn không ?")+"\n"+lan.Change_language_MessageText("Hoặc chờ bệnh nhân khám chữa bệnh xong mới lưu !"), "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2).ToString() == "No")
                //        return;
                //}
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
                string v_maql_TD = "";
                
                if (m_id_toathuocbhyt != "") id_tonghop = m_id_toathuocbhyt;
                
                if (aid == "0") aid = m_v.get_id_v_ttrvll.ToString();
                string achandoan = txtChandoan.Text.Trim('-').Trim('+').Trim('-').Trim('+');
                m_v.databaselinks_name = "";
                if (m_v.upd_v_ttrvds(ammyy, decimal.Parse(aid), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), 0, "", angay, angay, achandoan, txtICD.Text) == "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu danh sách BN bị lỗi"), m_v.s_AppName);
                    return;
                }
                if (m_v.upd_v_ttrvll(ammyy, decimal.Parse(aid), decimal.Parse(aloaibn), decimal.Parse(cbLoaidv.SelectedValue.ToString()), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, cbKhoavv.SelectedValue.ToString(), decimal.Parse(toolStrip_Tongcong.Text.Replace(",", "")), decimal.Parse(toolStrip_Tamung.Text.Replace(",", "")), decimal.Parse(toolStrip_Mien.Text.Replace(",", "")), decimal.Parse(toolStrip_BHYT.Text.Replace(",", "")), 0, 0, 0, 0, 0, -Math.Abs(decimal.Parse(id_tonghop)), decimal.Parse(m_userid), 0, 0,i_tylechinhsach,int.Parse(cbDoituong.SelectedValue.ToString())) == "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu tổng hợp bị lỗi"), m_v.s_AppName);
                    return;
                }
                else
                {
                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set thanhtoan=" + (rdThe.Checked ? "2" : rdTienmat.Checked ? "0" : rdTrasau.Checked ? "1" : "0") + ", sokham='" + lblsokham.Text + "', madoituong=" + ((cbDoituongTD.SelectedIndex < 0) ? "0" : cbDoituongTD.SelectedValue.ToString()) + " where id=" + aid);
                }
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
                    m_v.upd_v_mienngtru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien), decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", "")), "Miển giảm thu trực tiếp", decimal.Parse(amaduyet));
                }   
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
                if (tmn_khongcungchitra.Checked || tmn_thutatca.Checked)
                {
                    // amavaovien;// "";                    
                    try
                    {
                        v_maql_TD = m_v.get_data_mmyy(ammyy, "select maql from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and (done='c' or done is null) ").Tables[0].Rows[0][0].ToString();// and (done='c' or done is null)
                        if (v_maql_TD != "0" || v_maql_TD != "")
                        {
                            m_v.execute_data("Update medibv" + ammyy + ".tiepdon set done=null where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD + " and (done='c' or done is null) ");
                        }
                        if (bThuCLS && !bCongkham)
                        {
                            //v_maql_TD = m_v.get_data_mmyy(ammyy, "select maql from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10)+"'").Tables[0].Rows[0][0].ToString();
                            //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set sovaovien='" + capSttCho(int.Parse(txtKhoavv.Text), 0, 2) + "' where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD);
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
                //
                int v_idchinhanh_tiepnhan_chungtu = i_chinhanh;
                
                //
                string v_mavp_chuyenchungtu = "";
                foreach (DataRow r in m_dshoadon.Tables[0].Select(exp)) 
                {
                    gia_bh = 0;
                    v_idchinhanh_tiepnhan_chungtu = i_chinhanh;
                    id_tonghop = (r["idtonghop"].ToString() == "") ? "0" : r["idtonghop"].ToString();
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
                    
                    //if (!m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), d_stt++, angay.Substring(0, 10), cbKhoavv.SelectedValue.ToString(), g, decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, 0, decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["bhyttra"].ToString()), gia_bh,v_ngaygiodangky,i_loaitg_dkkham, r["mabs"].ToString()))
                    if (!m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), d_stt++, angay.Substring(0, 10), r["makp"].ToString(), g, decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, 0, decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["bhyttra"].ToString()), gia_bh, v_ngaygiodangky, i_loaitg_dkkham, r["mabs"].ToString()))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu chi tiết bị lỗi"), m_v.s_AppName);
                        return;
                    }
                    else
                    {
                        if (cbDoituongTD.SelectedIndex >= 0 && cbDoituongTD.SelectedValue.ToString() == "1") f_get_chinhanhchuyen_chinhanhden(int.Parse(r["mavp"].ToString()), i_chinhanh, ref v_idchinhanh_tiepnhan_chungtu);
                        if (v_idchinhanh_tiepnhan_chungtu != i_chinhanh) v_mavp_chuyenchungtu += r["mavp"].ToString() + ",";
                        string sql = "update medibvmmyy.v_ttrvct set idphongcls=" + r["maphongcls"].ToString() + ",sttcho=" + r["sttcho"].ToString() + ",mien=" + (r["mien"].ToString() == "" ? "0" : r["mien"].ToString()) + ", phuthu=" + (r["phuthu"].ToString() == "" ? "0" : r["phuthu"].ToString()) + ", idtonghop=" + (r["idtonghop"].ToString() == "" ? "0" : r["idtonghop"].ToString()) + ", idchinhanh=" + i_chinhanh + ",idchinhanhden=" + v_idchinhanh_tiepnhan_chungtu;
                        sql += ", losx='" + r["losx"].ToString() + "', handung='" + r["handung"].ToString() + "'";
                        sql += " where id=" + aid + " and stt=" + (d_stt - 1);
                        m_v.execute_data_mmyy(ammyy, sql);
                        // nếu thu tiền công khám hoặc CLS thi update table tiepdon 
                        if(m_v.bCongkham(r["mavp"].ToString()))
                        {
                            m_v.execute_data_mmyy(ammyy,"update medibvmmyy.tiepdon set sovaovien='"+r["sttcho"].ToString()+"' where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD);
                        }
                        
                    }
                    //m_v.databaselinks_name="";
                }
                bool links_ll = false;
                bool bChuyenChungtu_error = false;
                v_mavp_chuyenchungtu = v_mavp_chuyenchungtu.Trim().Trim(',');
                string s_dblink = "";
                if (v_mavp_chuyenchungtu.Trim().Trim(',') != "")
                {
                    foreach (DataRow r in m_dshoadon.Tables[0].Select(exp))//linh
                    {                        
                        f_get_chinhanhchuyen_chinhanhden(int.Parse(r["mavp"].ToString()), i_chinhanh, ref v_idchinhanh_tiepnhan_chungtu);
                        if (i_chinhanh != v_idchinhanh_tiepnhan_chungtu)
                        {
                            s_dblink = m_v.get_Tendatabase(v_idchinhanh_tiepnhan_chungtu);
                            m_v.databaselinks_name = s_dblink;
                            s_dblink = s_dblink == "" ? "" : "@" + s_dblink.Trim('@');
                            if (s_dblink.Trim().Trim('@') != "")
                            {
                                if (!links_ll)
                                {
                                    links_ll = true;
                                    if (m_v.upd_v_ttrvds(ammyy, decimal.Parse(aid), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), 0, "", angay, angay, achandoan, txtICD.Text) == "0")
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu danh sách BN chuyển chứng từ bị lỗi"), m_v.s_AppName);
                                        bChuyenChungtu_error = true;
                                    }
                                    if (bChuyenChungtu_error == false)
                                    {
                                        if (m_v.upd_v_ttrvll(ammyy, decimal.Parse(aid), decimal.Parse(aloaibn), decimal.Parse(cbLoaidv.SelectedValue.ToString()), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, cbKhoavv.SelectedValue.ToString(), decimal.Parse(toolStrip_Tongcong.Text.Replace(",", "")), decimal.Parse(toolStrip_Tamung.Text.Replace(",", "")), decimal.Parse(toolStrip_Mien.Text.Replace(",", "")), decimal.Parse(toolStrip_BHYT.Text.Replace(",", "")), 0, 0, 0, 0, 0, -Math.Abs(decimal.Parse(id_tonghop)), decimal.Parse(m_userid), 0, 0, i_tylechinhsach, int.Parse(cbDoituong.SelectedValue.ToString())) == "0")
                                        {
                                            MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu tổng hợp bị lỗi"), m_v.s_AppName);
                                            bChuyenChungtu_error = true;
                                        }
                                        else
                                        {
                                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll" + s_dblink + " set thanhtoan=" + (rdThe.Checked ? "2" : rdTienmat.Checked ? "0" : rdTrasau.Checked ? "1" : "0") + ", sokham='" + lblsokham.Text + "', madoituong=" + ((cbDoituongTD.SelectedIndex < 0) ? "0" : cbDoituongTD.SelectedValue.ToString()) + " where id=" + aid);
                                        }
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
                                    }
                                }
                                if (bChuyenChungtu_error == false)
                                {
                                    gia_bh = 0;
                                    id_tonghop = (r["idtonghop"].ToString() == "") ? "0" : r["idtonghop"].ToString();
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
                                    //if (!m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), d_stt++, angay.Substring(0, 10), cbKhoavv.SelectedValue.ToString(), g, decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, 0, decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["bhyttra"].ToString()), gia_bh,v_ngaygiodangky,i_loaitg_dkkham, r["mabs"].ToString()))
                                    if (!m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), d_stt++, angay.Substring(0, 10), r["makp"].ToString(), g, decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, 0, decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["bhyttra"].ToString()), gia_bh, v_ngaygiodangky, i_loaitg_dkkham, r["mabs"].ToString()))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu chi tiết (chuyển chứng từ) bị lỗi"), m_v.s_AppName);
                                        bChuyenChungtu_error = true;
                                    }
                                    else
                                    {
                                        s_dblink = s_dblink == "" ? "" : "@" + s_dblink.Trim('@');
                                        string sql = "update medibvmmyy.v_ttrvct" + s_dblink + "  set idphongcls=" + r["maphongcls"].ToString() + ",sttcho=" + r["sttcho"].ToString() + ",mien=" + (r["mien"].ToString() == "" ? "0" : r["mien"].ToString()) + ", phuthu=" + (r["phuthu"].ToString() == "" ? "0" : r["phuthu"].ToString()) + ", idtonghop=" + (r["idtonghop"].ToString() == "" ? "0" : r["idtonghop"].ToString()) + ", idchinhanh=" + i_chinhanh + ",idchinhanhden=" + v_idchinhanh_tiepnhan_chungtu;
                                        sql += ", losx='" + r["losx"].ToString() + "', handung='" + r["handung"].ToString() + "'";
                                        sql += " where id=" + aid + " and stt=" + (d_stt - 1);
                                        m_v.execute_data_mmyy(ammyy, sql);
                                        //// nếu thu tiền công khám hoặc CLS thi update table tiepdon 
                                        //if (m_v.bCongkham(r["mavp"].ToString()))
                                        //{
                                        //    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set sovaovien='" + r["sttcho"].ToString() + "' where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD);
                                        //}
                                    }
                                }
                            }
                        }
                        m_v.databaselinks_name = "";
                    }
                }
                //binh 17072011
                //
                f_del_dongchitra_truynguoc(amabn, amavaovien, amaql, aid, aquyenso, asobienlai);//delete cac chi phi duoi dinh muc bhyt chi tra cua cac hoa don truoc, de luu lai trong hoa don sau
                //
                //
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
                                    string v_mabs = cbBacsi.SelectedIndex < 0 ? "0000" : cbBacsi.SelectedValue.ToString();
                                    id_tonghop = m_v.upd_bhytkb(rr["mmyy"].ToString(), decimal.Parse(id_tonghop), 1, decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), cbKhoavv.SelectedValue.ToString(), txtChandoan.Text.Trim(), txtICD.Text.Trim(), v_mabs, txtSothe.Text.Trim(), 1, txtNDK_Ma.Text.Trim(), 0, 0, 0, decimal.Parse(toolStrip_Thucthu.Text.Replace(",", "")), decimal.Parse(toolStrip_BHYT.Text.Replace(",", "")), decimal.Parse(aloaibn), decimal.Parse(m_userid), traituyen);
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
                aidcd = "";
                
                if (id_tonghop != "0")
                {
                   //decimal astt = 1;
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            if (tmn_Thuchidinh.Checked && thutheodot_mavaovien)
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + ",idphongthuchiencls="+r["maphongcls"].ToString()+",stt="+r["sttcho"].ToString()+" where mabn='" + amabn + "' and mavaovien=" + m_mavaovien + " and paid=0 and loaiba in(" + ((s_loaiba == "") ? "1,2,3,4" : s_loaiba) + ") and mavp in (" + r["mavp"].ToString() + ") ");
                            }
                            else if (tmn_Thuchidinh.Checked && !thutheodot_mavaovien)
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + ",idphongthuchiencls=" + (r["maphongcls"].ToString() == "" ? "0" : r["maphongcls"].ToString()) + ",stt=" + (r["sttcho"].ToString() == "" ? "0" : r["sttcho"].ToString()) + " where mabn='" + amabn + "' and maql=" + amaql + " and paid=0 and mavp in (" + r["mavp"].ToString() + ") and madoituong=" + r["madoituong"].ToString() + " and  " + exp);
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + ",idphongthuchiencls=" + (r["maphongcls"].ToString() == "" ? "0" : r["maphongcls"].ToString()) + ",stt=" + (r["sttcho"].ToString() == "" ? "0" : r["sttcho"].ToString()) + " where mabn='" + amabn + "' and id=" + r["idtonghop"].ToString() + " and paid=0 and mavp in (" + r["mavp"].ToString() + ") and madoituong=" + r["madoituong"].ToString() + " and  " + exp);
                            }

                            if (tmn_Toathuocmuangoai.Checked)
                            {
                                //set done trong d_ngtrull+d_ngtruct
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_ngtruct set idttrv=" + aid.ToString() + " where idttrv=0 and mabd =" + r["mavp"].ToString() + " and id=" + r["idtonghop"].ToString());
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_ngtrull set idttrv=" + aid.ToString() + ", quyenso=" + aquyenso + ", sobienlai=" + asobienlai + " where id=" + r["idtonghop"].ToString());

                            }
                            aidcd += r["mavp"].ToString() + ",";
                        }
                        catch
                        {
                        }
                    }
                    aidcd = aidcd.Trim().Trim(',');
                   // end
                    string asql = "";
                    if ((thutheongay || thutheodot_mavaovien) && !tmn_khongcungchitra.Checked || tmn_thutatca.Checked)
                    {
                        foreach (DataRow rdel in m_v.get_data_mmyy(ammyy, "select id from medibvmmyy.bhytkb where mabn='" + amabn + "' and mavaovien=" + m_mavaovien + "").Tables[0].Rows) 
                        {
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set cls = (select case when sum(soluong*dongia) is null then 0 else sum(soluong*dongia) end from medibvmmyy.bhytcls where id = " + rdel["id"].ToString() + ") where id=" + rdel["id"].ToString());
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set thuoc = (select case when sum(a.soluong*a1.giamua) is null then 0 else sum(a.soluong*a1.giamua) end from medibvmmyy.bhytthuoc a inner join medibvmmyy.d_theodoi a1 on a.sttt=a1.id where a.id = " + rdel["id"].ToString() + ") where id=" + rdel["id"].ToString());
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set idphongcls=" + ((cbphatthuoc.SelectedIndex < 0) ? "000" : cbphatthuoc.SelectedValue.ToString().PadLeft(3, '0')) + ", sttcho=" + sttThuoc + " where id=" + rdel["id"].ToString());
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
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set quyenso=" + decimal.Parse(aquyenso) + ",sobienlai=" + decimal.Parse(asobienlai) + ", idttrv=" + aid + " where id=" + rdel["id"].ToString());//,done=1
                        }
                    }
                    else if (!tmn_khongcungchitra.Checked)
                    {
                        m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.bhytkb set quyenso=" + decimal.Parse(aquyenso) + ",sobienlai=" + decimal.Parse(asobienlai) + ", idttrv=" + aid + " where id=" + id_tonghop);//,done=1 
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
                                    f_Inhoadon();
                                }
                            }
                            else
                            {
                                f_Inhoadon();
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
                    if (bInphieumiengiam == true && toolStrip_Mien.Text.Trim().Replace(".","").Replace(",","").Trim('0') !="")  // gam hepa 17-06-2011
                    {
                        f_InPhieuMien(aid);
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
        private void f_Luu(bool bdichvu,DataRow[] dsHoadon)
        {
            try
            {
                if (dsHoadon.Length <= 0)
                {
                    return;
                }
                //
                if (bdichvu)
                {
                    txtSobienlai.Text = f_Get_Sobienlai(s_quyenso_dichvu).Split(':')[0];
                    cbKyhieu.SelectedValue = s_quyenso_dichvu;
                }
                string s_loaiba = "0,";
                int sttThuoc = 0;
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
                if (toolStrip_Tongcong.Text == toolStrip_BHYT.Text && !b_bhyt_100_theodoibienlai)
                {
                    asobienlai = "-1";
                }
                else
                {
                    asobienlai = txtSobienlai.Text.Trim();
                }
                amabn = txtMabn.Text.Trim() + txtMabn1.Text.Trim();
                if (amabn.Length != i_maxlength_mabn )
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
                // gam hepa 17-06-2011 cấp phòng và số thứ tự chờ 
                m_dshoadon = capIdPhongCLS(m_dshoadon, ref sttThuoc);
                // end gam
                //gam 28-03-11
                decimal atongtien = decimal.Parse(toolStrip_Tongcong.Text);
                LibDuoc.AccessData dd = new LibDuoc.AccessData();
                decimal d_tongtien = dd.ma13_st(1);
                string v_maql_TD = "";
                //if (tmn_nhacnhokhiluu.Checked && atongtien <= d_tongtien && !tmn_khongcungchitra.Checked)
                //{
                //    if (MessageBox.Show(lan.Change_language_MessageText("Có lưu hóa đơn không ?") + "\n" + lan.Change_language_MessageText("Hoặc chờ bệnh nhân khám chữa bệnh xong mới lưu !"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString() == "No")
                //        return;
                //}
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
                if (m_v.upd_v_ttrvll(ammyy, decimal.Parse(aid), decimal.Parse(aloaibn), decimal.Parse(cbLoaidv.SelectedValue.ToString()), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, cbKhoavv.SelectedValue.ToString(), decimal.Parse(toolStrip_Tongcong.Text.Replace(",", "")), decimal.Parse(toolStrip_Tamung.Text.Replace(",", "")), 0, decimal.Parse(toolStrip_BHYT.Text.Replace(",", "")), 0, 0, 0, 0, 0, -Math.Abs(decimal.Parse(id_tonghop)), decimal.Parse(m_userid), 0, 0, i_tylechinhsach, int.Parse(cbDoituong.SelectedValue.ToString())) == "0")//gam 09/12/2011
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu tổng hợp bị lỗi"), m_v.s_AppName);
                    return;
                }
                else
                {
                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set thanhtoan=" + (rdThe.Checked ? "2" : rdTienmat.Checked ? "0" : rdTrasau.Checked ? "1" : "0") + " where id=" + aid);
                }
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
                    m_v.upd_v_mienngtru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien), decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", "")), "Miển giảm thu trực tiếp", decimal.Parse(amaduyet));
                }  
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
                if (tmn_khongcungchitra.Checked || tmn_thutatca.Checked)
                {
                    // amavaovien;// "";                    
                    try
                    {
                        v_maql_TD = m_v.get_data_mmyy(ammyy, "select maql from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and done='c'").Tables[0].Rows[0][0].ToString();
                        if (v_maql_TD != "0" || v_maql_TD != "")
                        {
                            m_v.execute_data("Update medibv" + ammyy + ".tiepdon set done='x' where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD);
                        }
                        if (bThuCLS && !bCongkham)
                        {
                            v_maql_TD = m_v.get_data_mmyy(ammyy, "select maql from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "'").Tables[0].Rows[0][0].ToString();
                            //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set sovaovien='" + capSttCho(int.Parse(txtKhoavv.Text), 0, 2) + "' where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD);
                        }
                    }
                    catch { }
                }

                decimal d_stt = 1;
                decimal gia_bh = 0;
                DataRow r0;
                int i = dsHoadon.Length;
                string exp = "";
                if (tmn_khongcungchitra.Checked)
                    exp = "id<0";
                else
                    exp = "1=1";
                foreach (DataRow r in dsHoadon)
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
                    if (!m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), d_stt++, angay.Substring(0, 10), cbKhoavv.SelectedValue.ToString(), g, decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, 0, decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["bhyttra"].ToString()), gia_bh,v_ngaygiodangky,i_loaitg_dkkham, r["mabs"].ToString()))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thông tin lưu chi tiết bị lỗi"), m_v.s_AppName);
                        return;
                    }
                    else
                    {
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvct set idphongcls=" + r["maphongcls"].ToString() + ",sttcho=" + r["sttcho"].ToString() + ",mien=" + (r["mien"].ToString() == "" ? "0" : r["mien"].ToString()) + " where id=" + aid + " and stt=" + (d_stt - 1));
                        // nếu thu tiền công khám hoặc CLS thi update table tiepdon  --> stt kham lay tu tiep don qua --> khong can cap lai
                        //if (m_v.bCongkham(r["mavp"].ToString()))
                        //{
                        //    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set sovaovien='" + r["sttcho"].ToString() + "' where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "' and maql=" + v_maql_TD);
                        //}

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
                    foreach (DataRow r in dsHoadon)
                    {
                        try
                        {
                            if (tmn_Thuchidinh.Checked && thutheodot_mavaovien)
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + ",idphongthuchiencls=" + r["maphongcls"].ToString() + ",stt=" + r["sttcho"].ToString() + " where mabn='" + amabn + "' and mavaovien=" + m_mavaovien + " and paid=0 and loaiba in(" + ((s_loaiba == "") ? "1,2,3,4" : s_loaiba) + ") and mavp in (" + r["mavp"].ToString() + ") ");
                            }
                            else if (tmn_Thuchidinh.Checked && !thutheodot_mavaovien)
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid.ToString() + " where mabn='" + amabn + "' and maql=" + amaql + " and paid=0 and mavp in (" + r["mavp"].ToString() + ") and " + exp);
                            }
                            aidcd += r["mavp"].ToString() + ",";

                            if (tmn_Toathuocmuangoai.Checked)
                            {
                                //set done trong d_ngtrull+d_ngtruct
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_ngtruct set idttrv=" + aid.ToString() + " where idttrv=0 and mabd =" + r["mavp"].ToString() + " and id=" + r["idtonghop"].ToString());
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_ngtrull set idttrv=" + aid.ToString() + ", quyenso="+aquyenso+",sobienlai="+asobienlai+" where id=" + r["idtonghop"].ToString());

                            }
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
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set quyenso=" + decimal.Parse(aquyenso) + ",sobienlai=" + decimal.Parse(asobienlai) + ", idttrv=" + aid + " where id=" + rdel["id"].ToString());//,done=1
                            }
                            b_upd_bhytkb = true;
                        }
                    }
                    else if (!tmn_khongcungchitra.Checked)
                    {
                        m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.bhytkb set quyenso=" + decimal.Parse(aquyenso) + ",sobienlai=" + decimal.Parse(asobienlai) + ", idttrv=" + aid + " where id=" + id_tonghop);//,done=1 
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
                    if (bInphieumiengiam == true && toolStrip_Mien.Text.Trim().Replace(".","").Replace(",","").Trim('0') !="") // gam hepa 17-06-2011
                    {
                        f_InPhieuMien(aid);
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
                                string asql1 = "update medibvmmyy.bhytkb set quyenso=0,sobienlai=0,idttrv=0 where id=" + id_tonghop;
                                if (thutheongay || thutheodot_mavaovien)
                                {
                                    asql1 += " or mavaovien=" + m_mavaovien;
                                }
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_chidinh set paid=0,idttrv=0 where maql=" + m_maql + " and idttrv=" + m_id + " and mavp in(select mavp from medibvmmyy.v_ttrvct where id=" + m_id + ")");
                                m_v.execute_data_mmyy(ammyy, asql1);
                                m_v.del_v_ttrvll(ammyy, cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), m_id, txtMabn.Text + txtMabn1.Text, cbNgayvv.SelectedValue.ToString(), cbKhoavv.SelectedValue.ToString(), "");
                                //hien 040811
                                int id_chinhanhden = m_v.get_idchinhanhden_vttrvct(m_id, ammyy);
                                m_v.del_v_ttrvll(ammyy, cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), m_id, txtMabn.Text + txtMabn1.Text, cbNgayvv.SelectedValue.ToString(), cbKhoavv.SelectedValue.ToString(), "");

                                if (id_chinhanhden > 0)
                                {
                                    string s_dblink = m_v.get_Tendatabase(id_chinhanhden);
                                    m_v.databaselinks_name = s_dblink;
                                    s_dblink = s_dblink == "" ? "" : "@" + s_dblink.Trim('@');
                                    if (s_dblink.Trim().Trim('@') != "")
                                    {
                                        // xoa ly xoa sang may remote.
                                        m_v.del_thongtinvienphi(m_id, ammyy, s_dblink);
                                    }
                                }
                                m_v.databaselinks_name = "";
                                //
                            }
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set done='c' where maql=" + m_maql + " and mabn=" + txtMabn.Text + txtMabn1.Text + " and done is null");
                            f_Load_Thutrongngay();
                            f_Clear_HC();
                            m_dshoadon.Tables[0].Rows.Clear();
                            m_dstamung.Tables[0].Rows.Clear();
                            dgHoadon.Update();
                            dgHoadon.Refresh();
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
                if (m_id != "" && (tmn_Luuin_Hoadon.Checked || tmn_Luuin_Phieuthuchi.Checked)) 
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
                
                //if (tmn_in38_thuphi.Checked)
                //{
                //    m_frmprinthd.f_Print_ChiphiTTRVNgtruCT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien, decimal.Parse(toolStrip_CongkhamBHYT.Text.Trim()));
                //    m_frmprinthd.Dispose();
                //    m_frmprinthd = new frmPrintHD(m_v, m_userid);
                //    m_frmprinthd.f_Print_ChiphiKBCT_1(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien);
                //}
                //else 
                if(tmn_Luuin_Chiphi.Checked)
                {
                    m_frmprinthd.f_Print_ChiphiTTRVNgtruCT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien, decimal.Parse(toolStrip_CongkhamBHYT.Text.Trim()),(bInsttcho == bThuCLS == true));
                }
                //if (tmn_inmau38bv.Checked)
                //{
                //    this.m_frmprinthd.f_Print_ChiphiTTRVNgtruCT_tenreport(!this.tmn_Xemtruockhiin_Icon.Checked, this.bNhieudot ? "" : this.m_id, this.m_v.get_mmyy(this.txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + this.txtMabn1.Text, this.m_mavaovien, decimal.Parse(acongkham), this.txtNgaythu.Text.Substring(0, 10), "v_ttrv_mau01.rpt");
                //}
            }
            catch
            {
            }
        }

        private void f_Inchiphi_mau38()
        {
            try
            {

                if (tmn_in38_thuphi.Checked)
                {
                    //m_frmprinthd.f_Print_ChiphiTTRVNgtruCT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien, decimal.Parse(toolStrip_CongkhamBHYT.Text.Trim()));
                    //m_frmprinthd.Dispose();
                    m_frmprinthd = new frmPrintHD(m_v, m_userid);
                    m_frmprinthd.f_Print_ChiphiKBCT_1(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien);
                }
                
                if (tmn_inmau38bv.Checked)
                {
                    this.m_frmprinthd.f_Print_ChiphiTTRVNgtruCT_tenreport(!this.tmn_Xemtruockhiin_Icon.Checked, this.bNhieudot ? "" : this.m_id, this.m_v.get_mmyy(this.txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + this.txtMabn1.Text, this.m_mavaovien, decimal.Parse(acongkham), this.txtNgaythu.Text.Substring(0, 10), "v_ttrv_mau01.rpt", false);//
                    this.m_frmprinthd.f_Print_ChiphiTTRVNgtruCT_tenreport(!this.tmn_Xemtruockhiin_Icon.Checked, this.bNhieudot ? "" : this.m_id, this.m_v.get_mmyy(this.txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + this.txtMabn1.Text, this.m_mavaovien, decimal.Parse(acongkham), this.txtNgaythu.Text.Substring(0, 10), "v_ttrv_mau01.rpt", true);//dich vu chuyen chung tu
                }

                if (tmn_inphieumien.Checked && toolStrip_Mien.Text.Trim().Replace(".","").Replace(",","").Trim('0') !="")
                {
                    f_InPhieuMien(m_id);
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
       /* private void f_Tinhtien()
        {
            try
            {
                bool bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
                bool bTraituyen_bhtra = m.bTraituyen_bhtra;//true: trai tuyen tinh theo: ty le the * ty le trai tuyen
                decimal asoluong = 0, adongia = 0, asotien = 0, abhtra = 0, abntra = 0, atongcp = 0, atongbhyttra = 0, atongbntra = 0, acongkhambhyt = 0, atamung = 0, atongsocp = 0, atyle = 0;
                foreach (DataRow r in m_dsnhomvp.Tables[0].Rows)
                {
                    r["sotien"] = 0;
                }
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
                //
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
                    DataRow r1 = null;
                    try { r1 = m_dsgiavp.Tables[0].Select("id='" + r["mavp"].ToString() + "'")[0]; }
                    catch { r1 = null; }
                    //	
                    bKhongcungchitra = false; d_dichvu_tt_bhyt_tra = 0; d_dichvu_tt = 0;
                    if (r1 != null)
                    {
                        dtyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());//100% tra ve 1
                        if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bBHYT_Traituyen_tinh_Tyle_khac && decimal.Parse(r1["bhyt"].ToString()) > decimal.Parse(r1["bhyt_tt"].ToString()))
                        {
                            bKhongcungchitra = true;
                            d_dichvu_tt = asotien;
                            d_dichvu_tt_bhyt_tra = asotien * decimal.Parse(r1["bhyt_tt"].ToString()) / 100;
                        }
                    }
                    abhtra = (asotien - d_dichvu_tt) * dtyle + d_dichvu_tt_bhyt_tra;// f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                    //
                    if (r["madoituong"].ToString() == "1" && atyle != 100) abhtra = abhtra * (bKhongcungchitra ? 100 : atyle) / 100;
                    else if (m_doituongmien.IndexOf("," + r["madoituong"].ToString() + ",") != -1) abhtra = asotien;
                    abntra = asotien - abhtra;

                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["sotien"] = asotien;
                    r["bntra"] = abntra;
                    r["bhyttra"] = abhtra;

                    try
                    {
                        string aid_nhom = m_dsgiavp.Tables[0].Select("id=" + r["mavp"].ToString())[0]["id_nhom"].ToString();
                        foreach (DataRow rn in m_dsnhomvp.Tables[0].Select("id=" + aid_nhom))
                        {
                            rn["sotien"] = (decimal.Parse(rn["sotien"].ToString()) + asotien);
                        }
                    }
                    catch
                    {
                    }

                    atongbntra += abntra;
                    atongbhyttra += abhtra;
                    atongcp += asotien;
                }

                m_dshoadon.AcceptChanges();

                atamung = decimal.Parse(txtTamung.Text.Replace(",", ""));

                //atongbhyttra = atongbhyttra * f_get_Tylebhytchitra(atongbhyttra) / 100;
                atongbntra = atongcp - atongbhyttra;
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
                else if (lTraituyen!=0 && cmbTraituyen.SelectedIndex!=0 && atongbhyttra>lTraituyen)
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
            }
        } */
        private void f_Tinhtien(decimal v_asotien)// v_asotien <=0 tính tỷ lệ bhyt chi trả dựa vào tổng chi phí trong m_dshoadon, nếu v_asotien > 0 tính tỷ lệ bhyt chi trả đựa vào tổng tiền truyền vào
        {
            try
            {
                
                f_TinhtienhuongBHYT(m_dshoadon);
                bool bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
                bool bTraituyen_bhtra = m.bTraituyen_bhtra;//true: trai tuyen tinh theo: ty le the * ty le trai tuyen
                decimal asoluong = 0, adongia = 0, amien = 0, asotien = 0, abhtra = 0, abntra = 0, atongmien= 0, atongcp = 0, atongbhyttra = 0, atongbntra = 0, acongkhambhyt = 0, atamung = 0, atongsocp = 0, atyle = 0;
                foreach (DataRow r in m_dsnhomvp.Tables[0].Rows)
                {
                    r["sotien"] = 0;
                }
                //if (v_asotien > 0)
                //{
                //    asotien = v_asotien;
                //}
                //else
                //{
                asotien = v_sotien_huong_bhyt;
                    
                //}
               
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
                //khong luu phan BHYT duoi dinh muc
                //if (m_dshoadon.Tables.Count>0 && m_dshoadon.Tables[0].Rows.Count>0 && cmbTraituyen.SelectedIndex == 0 && tmn_thuBH100_duoidinhmuc.Checked == false && v_sotien_huong_bhyt + zsotien_datra < m_v.ma13_st(m_v.nhom_duoc))
                //{
                //    DataRow[] r1 = m_dshoadon.Tables[0].Select("madoituong=1");// m_v.getrowbyid(m_dshoadon.Tables[0], "madoituong=1");
                //    for (int ii = 0; ii < r1.Length; ii++)
                //    {
                //        m_dshoadon.Tables[0].Rows.Remove(r1[ii]);
                //    }
                    
                //}
                int i_phuthu = 0;//0: thu thuong; 1: tien phu thu - tien chenh lech; 2: bhyt - dong chi tra
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)                
                {
                    amien = abhtra = abntra = asotien = asoluong = 0;
                    i_phuthu = (r["madoituong"].ToString() == "1" && r["phuthu"].ToString() != "3" && r["phuthu"].ToString() != "4") ? 2 : int.Parse(r["phuthu"].ToString());
                    r["phuthu"] = i_phuthu;//0: dv, thuoc tu truc; 1 phu thu; 2: dong chi tra; 3: dong chi tra toa thuoc bhyt; 4 toa thuoc dich vu
                    if (i_phuthu == 1) r["ten"] = "Phụ thu " + r["ten"].ToString();
                    abhtra = 0;
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
                    DataRow r1 = null;
                    try { r1 = m_dsgiavp.Tables[0].Select("id='" + r["mavp"].ToString() + "'")[0]; }
                    catch { r1 = null; }
                    //	
                    bKhongcungchitra = false; d_dichvu_tt_bhyt_tra = 0; d_dichvu_tt = 0;
                    if (r1 != null)
                    {
                        dtyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());//100% tra ve 1
                        if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bBHYT_Traituyen_tinh_Tyle_khac && decimal.Parse(r1["bhyt"].ToString()) > decimal.Parse(r1["bhyt_tt"].ToString()))
                        {
                            bKhongcungchitra = true;
                            d_dichvu_tt = asotien;
                            d_dichvu_tt_bhyt_tra = asotien * decimal.Parse(r1["bhyt_tt"].ToString()) / 100;
                        }
                    }
                    if (r["madoituong"].ToString() == "1")
                    {
                        abhtra = (asotien - d_dichvu_tt) * dtyle + d_dichvu_tt_bhyt_tra;// f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                    }
                    //
                    if (r["madoituong"].ToString() == "1" && atyle != 100)
                    {
                        abhtra = abhtra * (bKhongcungchitra ? 100 : atyle) / 100;
                        //xu ly mien giam dong chi tra
                        f_bnmien(int.Parse(r["mavp"].ToString()));
                        foreach (DataRow drr in ds_bnmien.Tables[0].Rows)
                        {
                            amien = (asotien - abhtra) * decimal.Parse(drr["tldongchitra"].ToString()) / 100;
                        }

                        //
                    }

                    //if (r["madoituong"].ToString() == "1" && atyle != 100 && ( r["bhyt_tt"].ToString() == "0" || r["bhyt_tt"].ToString() == r["bhyt"].ToString())) 
                    //    abhtra = abhtra * (bKhongcungchitra ? 100 : atyle) / 100;
                    //else if (r["madoituong"].ToString() == "1" && atyle != 100 && (r["bhyt_tt"].ToString() != "0" && r["bhyt_tt"].ToString() != r["bhyt"].ToString()))
                    //{
                    //    abhtra = abhtra * (bKhongcungchitra ? 100 : (decimal.Parse(r["bhyt_tt"].ToString() == "" ? atyle.ToString() : r["bhyt_tt"].ToString()))) / 100;
                    //}

                    else
                    {
                        amien = 0;
                        if (m_doituongmien.IndexOf("," + r["madoituong"].ToString() + ",") != -1) amien = asotien;
                    }
                    try
                    {
                        if (v_nhapmienchitiet && amien == 0)
                        {
                            //amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));//lay mien tu chi dinh qua
                            //xu ly mien giam tienthuoc
                            f_bnmien ( int.Parse(r["mavp"].ToString()));//tinh lai mien tu luc dang ky
                            foreach (DataRow drr1 in ds_bnmien.Tables[0].Rows)
                            {
                                amien += (asotien - abhtra) * decimal.Parse(drr1["tylemien"].ToString()) / 100;
                            }
                        }
                        if (amien < 0 || amien > adongia * asoluong)
                        {
                            amien = 0;
                        }

                        

                    }
                    catch
                    {
                        amien = 0;
                    }
                    abntra = asotien - abhtra - amien;

                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["mien"] = amien;
                    r["sotien"] = asotien;
                    r["bntra"] = abntra ;
                    r["bhyttra"] = abhtra;

                    try
                    {
                        string aid_nhom = m_dsgiavp.Tables[0].Select("id=" + r["mavp"].ToString())[0]["id_nhom"].ToString();
                        foreach (DataRow rn in m_dsnhomvp.Tables[0].Select("id=" + aid_nhom))
                        {
                            rn["sotien"] = (decimal.Parse(rn["sotien"].ToString()) + asotien);
                        }
                    }
                    catch
                    {
                    }

                    atongbntra += abntra;
                    atongbhyttra += abhtra;
                    atongmien += amien;
                    atongcp += asotien;
                }

                m_dshoadon.AcceptChanges();

                atamung = (txtTamung.Text == "") ? 0 : decimal.Parse(txtTamung.Text.Replace(",", ""));

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
                        atongbntra = atongcp + zsotien_datra - atongbhyttra - zbhyt_datra - atongmien;
                    }
                }
                else if (lTraituyen != 0 && cmbTraituyen.SelectedIndex != 0 && atongbhyttra > lTraituyen)
                {
                    decimal tc = atongbhyttra + atongbntra;
                    atongbhyttra = decimal.Parse(lTraituyen.ToString());
                    atongbntra = tc - atongbhyttra - atongmien ;
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
                toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##").Trim();

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
            }
        }
     
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

            sql = "select ma,ten,dvt,to_number('" + solankham + "') as soluong," + v_dongiabhyt + " as dongia, to_number('0') as giaban, to_number('0') as gia_bh, " + solankham + "* " + v_dongiabhyt + " as sotien,to_number('0') as bhyttra, to_number('0') as bntra, id as mavp, to_number('1') as madoituong from medibv.v_giavp where id=" + s_mavp_congkham;
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
                sql = "select sum(a.sotien-a.bhyt-a.mien-a.thieu) as sotien from medibvmmyy.v_ttrvll a where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and idtonghop<0 ";
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
                sql = "select count(distinct a.id) as sohd from medibvmmyy.v_ttrvll a where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and idtonghop<0";
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
                    " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra,a1.mavp,coalesce(e.traituyen,0) as traituyen ,b.dichvu,g.thanhtoan" +
                    " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id " +
                    " inner join medibvmmyy.v_ttrvct a1 on a.id=a1.id inner join medibvmmyy.v_ttrvbhyt e on a.id=e.id" +
                    " inner join medibv.v_giavp b on a1.mavp=b.id where a.id = " + v_id;
                DataSet ads = m_v.get_data_mmyy(ammyy, sql);
                sql = "select a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp," +
                    " '' as mabs,a.maicd,a.chandoan,e.sothe,e.maphu,e.mabv,g.quyenso,g.sobienlai,b.ma,b.ten||' '||b.hamluong as ten,b.dang as dvt," +
                    " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra," +
                    " a1.mavp,coalesce(e.traituyen,0) as traituyen,to_number('0') as dichvu,g.thanhtoan from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id " +
                    " inner join medibvmmyy.v_ttrvct a1 on a.id=a1.id " +
                    " inner join medibv.d_dmbd b on a1.mavp=b.id inner join medibvmmyy.v_ttrvbhyt e on a.id=e.id " +
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
                    traituyen = cmbTraituyen.SelectedIndex= int.Parse(ads.Tables[0].Rows[0]["traituyen"].ToString());
                    txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    txtNgaythu.Value = m_v.f_parse_date(ads.Tables[0].Rows[0]["ngaythu"].ToString());
                    txtNDK_Ma.Text = ads.Tables[0].Rows[0]["mabv"].ToString();
                    txtSothe.Text = ads.Tables[0].Rows[0]["sothe"].ToString();
                    txtICD.Text = ads.Tables[0].Rows[0]["maicd"].ToString();
                    txtChandoan.Text = ads.Tables[0].Rows[0]["chandoan"].ToString();

                    rdTienmat.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "0";
                    rdThe.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "2";
                    rdTrasau.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "1";

                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("mavaovien");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loaiba");
                    ads.Tables[0].Columns.Remove("ngaythu");
                    ads.Tables[0].Columns.Remove("makp");
                    ads.Tables[0].Columns.Remove("mabs");
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
                sql += " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra,a1.mavp,";
                sql += "tamung,a1.madoituong,coalesce(e.traituyen,0) as traituyen,b.dichvu,f.ma nhom ,g.thanhtoan,a1.mien,";
                sql += "'' as phongthuchiencls,a1.idphongcls as maphongcls,a1.sttcho, a1.phuthu, a1.idtonghop ";
                sql += ", g.sokham ";
                sql += ", a1.makp as makpct, a1.mabs, a1.losx, a1.handung ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id inner join ";
                sql += " medibvmmyy.v_ttrvct a1 on a.id=a1.id inner join ";
                sql += " medibv.v_giavp b on a1.mavp=b.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id ";
                sql += " inner join medibv.v_loaivp e1 on b.id_loai=e1.id inner join medibv.v_nhomvp f on e1.id_nhom=f.ma";
                sql += " where a.id = " + v_id;
                ads = m_v.get_data_mmyy(ammyy, sql);

                sql = "select a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp,";
                sql += " '' as mabs,a.maicd,a.chandoan,e.sothe,e.maphu,e.mabv,g.quyenso,g.sobienlai,b.ma,b.ten||' '||b.hamluong as ten,b.dang as dvt,";
                sql += " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra,";
                sql += " a1.mavp,tamung,a1.madoituong,coalesce(e.traituyen,0) as traituyen,to_number('0') as dichvu,e1.nhomvp nhom,g.thanhtoan,a1.mien,";
                sql += "'' as phongthuchiencls,a1.idphongcls as maphongcls,a1.sttcho, a1.phuthu, a1.idtonghop ";
                sql += ", g.sokham ";
                sql += ", a1.makp as makpct, a1.mabs, a1.losx, a1.handung ";
                sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id";
                sql += " inner join medibvmmyy.v_ttrvct a1 on a.id=a1.id ";
                sql += " inner join medibv.d_dmbd b on a1.mavp=b.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id ";
                sql += " inner join medibv.d_dmnhom e1 on b.manhom=e1.id ";
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
                    cmbTraituyen.SelectedIndex= traituyen = int.Parse(ads.Tables[0].Rows[0]["traituyen"].ToString());
                    txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    txtNgaythu.Value = m_v.f_parse_date(ads.Tables[0].Rows[0]["ngaythu"].ToString());
                    txtNDK_Ma.Text = ads.Tables[0].Rows[0]["mabv"].ToString();
                    txtSothe.Text = ads.Tables[0].Rows[0]["sothe"].ToString();
                    txtICD.Text = ads.Tables[0].Rows[0]["maicd"].ToString();
                    txtChandoan.Text = ads.Tables[0].Rows[0]["chandoan"].ToString();                    
                    cbKhoavv.SelectedValue = ads.Tables[0].Rows[0]["makp"].ToString();
                    txtKhoavv.Text = ads.Tables[0].Rows[0]["makp"].ToString();

                    rdTienmat.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "0";
                    rdThe.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "2";
                    rdTrasau.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "1";

                    lblsokham.Text = ads.Tables[0].Rows[0]["sokham"].ToString();

                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("mavaovien");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loaiba");
                    ads.Tables[0].Columns.Remove("ngaythu");
                    ads.Tables[0].Columns.Remove("makp");
                    ads.Tables[0].Columns.Remove("mabs");
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
                atn = m_v.f_string_date(atn);
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
                //binh 120711
                //copy tu 115 qua - load lai chi phi bhyt ma duoi dinh muc len thu lai
                #region load_lai_cpbhyt_duoidinhmuc
                f_Load_BHYT();
                try
                {
                    if (((txtSothe.Text != "") && (m_id == "0" || m_id == "")) && (m_v.get_maphu(txtSothe.Text) != 0))
                    {

                        string ammyy = m_v.mmyy(txtNgaythu.Text);
                        sql = "select c.*, c.id as idth,b.sobienlaidv from medibvmmyy.v_ttrvds a,medibvmmyy.v_ttrvll b,medibvmmyy.v_ttrvct c ";
                        sql = sql + " where a.id=b.id and a.id=c.id and a.mabn='" + txtMabn.Text + txtMabn1.Text.Trim() + "'";

                        sql = sql + " and c.madoituong in (1) and c.bhyttra=c.sotien and b.loaibn in (0,3,4)";
                        sql = ((sql + " and ((a.mavaovien=" + m_mavaovien + ") or a.maql in( " + v_maql + "," + m_mavaovien + "))") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ") + " where mabn='" + txtMabn.Text.Trim() + txtMabn1.Text.Trim() + "'";
                        sql = sql + " and (mavaovien=" + m_mavaovien + ")) ";
                        decimal idth = 0;
                        decimal id = 0;
                        decimal asobldv = 0;
                        foreach (DataRow r in m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows)
                        {                            
                            idth = decimal.Parse(r["idth"].ToString().Trim().Replace(",", ""));
                            id = decimal.Parse(r["id"].ToString().Trim().Replace(",", ""));
                            asobldv = decimal.Parse(r["sobienlaidv"].ToString().Trim().Replace(",", ""));
                            //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set sotien=sotien-" + r["sotien"].ToString() + ", bhyt=bhyt-" + r["bhyttra"].ToString() + " where id=" + r["id"].ToString());
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvct set dongchitra=1 where madoituong=1 and bhyttra=sotien and id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());//danh dau so tien lan truoc thu duoi muc BHYT qui dinh
                        }
                        //if (idth != 0)
                        //{
                        //    if (this.tmn_Thuocthuongquy.Checked)
                        //    {
                        //        this.m_v.execute_data_mmyy(ammyy, "update medibvmmyy.d_tienthuoc set done=0,idttrv=0 where madoituong=1 and idttrv=" + id);
                        //    }
                        //}
                    }
                }
                catch
                {
                }
                #endregion
                //
                f_Load_Tamung(v_tn, v_maql);
                string exp1 = "";
                //if (!tmn_khongcungchitra.Checked)
                //    exp1 = "=1 ";
                //else
                //    exp1 = "<>1 ";
                if (m_doituongthu.Trim(',') != "")
                    exp1 = " in (" + m_doituongthu.Trim(',') + ")";
                else
                    exp1 = "=1";
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
                    sql = "select b.bhyt,b.bhyt_tt,a.mabs,a.id,b.ma, b.ten, b.dvt, a.soluong, a.dongia, to_number('0') as giaban, to_number('0') as gia_bh, a.soluong*a.dongia as sotien, to_number('0') as bhyttra, to_number('0') as bntra, a.mavp, a.madoituong ,to_number('0') as loai,b.dichvu,f.ma nhom,a.stgiam as mien,b.phongthuchiencls,to_number('0') as maphongcls, a.stt as sttcho, a.hide as phuthu, a.id as idtonghop";
                    sql+=" , a.makp, a.mabs, '' as losx, '' as handung ";//binh 220711
                    sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp ";
                    sql += "inner join medibv.v_loaivp e on b.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma" + aexp;
                    sql += " and b.guinguoi=0 ";//khong thu cac dich vu chuyen vien+chuyennguoi
                    if (tmn_thudichvu_chuyenchungtu.Checked) sql += " and b.chuyenchungtu=1";//binh 270711
                    else sql += " and (b.chuyenchungtu=0 or (b.chuyenchungtu=1 and a.madoituong<> 1 and a.hide=0))";
                    //sql+=" and ((a.kskdoan=1 and a.kskphatsinh=1) or a.kskdoan=0)";//khong thu kham sua khoe
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
                    aexp = " where a.madoituong " + exp1 + " and paid=0 and a.maql = " + m_mavaovien;
                    sql = "select b.bhyt,b.bhyt_tt,a.mabs,a.id, b.ma, b.ten, b.dvt, a.soluong, a.dongia, to_number('0') as giaban, to_number('0') as gia_bh, a.soluong*a.dongia as sotien, to_number('0') as bhyttra, to_number('0') as bntra, a.mavp, a.madoituong, 0 as loai,b.dichvu,f.ma as nhom,a.stgiam as mien,b.phongthuchiencls,to_number('0') as maphongcls,a.stt as sttcho, a.hide as as phuthu, a.id as idtonghop ";
                    sql += " , a.makp, a.mabs, '' as losx, '' as handung ";//binh 220711
                    sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp";
                    sql += " inner join medibv.v_loaivp e on b.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma" + aexp;
                    if (tmn_thudichvu_chuyenchungtu.Checked) sql += " and b.chuyenchungtu=1";//binh 270711
                    else sql += " and b.chuyenchungtu=0";
                    sql += " and b.guinguoi=0 ";//khong thu cac dich vu chuyen vien+chuyennguoi
                    //sql+=" and ((a.kskdoan=1 and a.kskphatsinh=1) or a.kskdoan=0)";//khong thu kham sua khoe
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
                if (tmn_Vienphikhoa.Checked && tmn_thudichvu_chuyenchungtu.Checked == false)
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
                    sql = "select b.bhyt,b.bhyt_tt,'' as mabs,a.id,b.ma, b.ten, b.dvt, a.soluong, a.dongia, to_number('0') as giaban, to_number('0') as gia_bh,";
                    sql += " a.soluong*a.dongia as sotien, to_number('0') as bhyttra, to_number('0') as bntra, a.mavp, a.madoituong ,";
                    sql += "to_number('0') as loai,b.dichvu,f.ma nhom,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho, to_number('0') as phuthu, a.id as idtonghop ";
                    sql += " , a.makp, '' as mabs, '' as losx, '' as handung  ";//binh 220711
                    sql += "from medibvmmyy.v_vpkhoa a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on ";
                    sql += "a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp inner join medibv.v_loaivp e ";
                    sql += "on b.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma " + aexp;
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
                if (tmn_Thuocthuongquy.Checked && tmn_thudichvu_chuyenchungtu.Checked == false)
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
                    sql = "select to_number('0') as bhyt,to_number('0') as bhyt_tt,'' as mabs,a.id,b.ma, b.ten, b.dang as dvt, a.soluong, a.giamua as dongia, a.giaban, b.gia_bh, a.soluong*a.giamua as sotien, to_number('0') as bhyttra,to_number('0') as bntra,a.mabd as mavp, a.madoituong,to_number('1') as loai,to_number('0') as dichvu,e.nhomvp as nhom,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho,  to_number('0') as phuthu , a.id as idtonghop ";
                    sql += " , a1.makp, '' as mabs, '' as losx, '' as handung ";//binh 220711
                    sql += " from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp inner join medibv.d_dmnhom e on b.manhom=e.id " + aexp;
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
                if (tmn_DonthuocBHYT.Checked && tmn_thudichvu_chuyenchungtu.Checked == false)
                {
                    if (thutheongay)
                    {
                        aexp = " where to_char(ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and a.mabn='" + txtMabn.Text + txtMabn1.Text + "' ";
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
                    if ((!tmn_khongcungchitra.Checked || tmn_thutatca.Checked) || (!tmn_khongcungchitra.Checked && !tmn_thutatca.Checked))
                    {
                        //thu phan chi phi BHYT + BN cung chi tra
                        sql = "select to_number('0') as bhyt,to_number('0') as bhyt_tt,a.mabs,a.id, a.mabs,b.ma,b.ten,b.dang as dvt,a1.soluong, a2.giamua as dongia, a2.giaban, a1.gia_bh, ";
                        sql += " a1.soluong*a2.giamua as sotien, to_number('0') as bhyttra, to_number('0') as bntra,a1.mabd as mavp,";
                        sql += "a.maphu as madoituong,a2.giamua,to_number('1') as loai ";
                        sql += ", b.chenhlech,to_number('0') as dichvu,e.nhomvp as nhom,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho, to_number('3') as phuthu, a.id as idtonghop  ";
                        sql += " , a.makp, a.mabs, '' as losx, '' as handung ";//binh 220711
                        sql += " from medibvmmyy.bhytkb a inner join medibvmmyy.bhytthuoc a1 on a.id=a1.id ";
                        sql += " inner join medibvmmyy.d_theodoi a2 on a1.sttt=a2.id inner join medibv.d_dmbd b on a1.mabd=b.id ";
                        sql += " left join medibv.btdkp_bv c on a.makp=c.makp inner join medibv.d_dmnhom e on b.manhom=e.id " + aexp + "";
                        //
                        sql += " union all ";
                        sql += " select b.bhyt,b.bhyt_tt,a.mabs,a.id, a.mabs,b.ma,b.ten,b.dvt,a1.soluong,a1.dongia as dongia, ";
                        sql += "to_number('0') as giaban, to_number('0') as gia_bh ,a1.soluong*a1.dongia as sotien, ";
                        sql += " to_number('0') as bhyttra, to_number('0') as bntra,a1.mavp as mavp, a.maphu as madoituong,a1.dongia as giamua,to_number('0') as loai ";
                        sql += ", b.chenhlech,b.dichvu,f.ma as nhom,to_number('0') as mien ,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho, to_number('0') as phuthu, a.id as idtonghop ";
                        sql += " , a.makp, a.mabs, '' as losx, '' as handung  ";//binh 220711
                        sql += " from medibvmmyy.bhytkb a inner join medibvmmyy.bhytcls a1 on a.id=a1.id inner join medibv.v_giavp b ";
                        sql += " on a1.mavp=b.id left join medibv.btdkp_bv c on a.makp=c.makp ";
                        sql += "inner join medibv.v_loaivp e on b.id_loai=e.id inner join medibv.v_nhomvp f on e.id_nhom=f.ma " + aexp + "";
                        //
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
                    if ((tmn_khongcungchitra.Checked || tmn_thutatca.Checked) && tmn_thudichvu_chuyenchungtu.Checked == false)
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
                        //Cac doi tuong khac BHYT
                        if (cbDoituongTD.SelectedValue.ToString() == "1")
                        {
                            sql = "select to_number('0') as bhyt,to_number('0') as bhyt_tt,'' as mabs,a.id,b.ma, b.ten, b.dang as dvt, a.soluong, a.giaban as dongia, a.giaban, to_number('0') ";
                            sql += "as gia_bh, a.soluong*a.giaban as sotien, to_number('0') as bhyttra, to_number('0') ";
                            sql += "as bntra, a.mabd as mavp, a.madoituong ,to_number(4,'9') as loai,to_number('0') as dichvu,to_number('0') nhom,to_number('0') as mien,to_char(0) phongthuchiencls,";
                            sql += "to_number('0') as maphongcls,to_number('0') as sttcho,to_number('0') as phuthu, a.id as idtonghop ";
                            sql += " , d.makp, '' as mabs, '' as losx, '' as handung  ";//binh 220711
                            sql += "from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id ";
                            sql += "left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp ";
                            sql += "inner join medibv.d_dmnhom e on b.manhom=e.id " + aexp + " and a.done=0 and a.madoituong in (" + m_doituongthu.Trim(',') + ")";
                            sql += " and done=0 and a.maql = " + v_maql + " and a.madoituong<>1";
                            sql += " and a.soluong<>0 ";
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
                        if (tmn_Toathuocmuangoai.Checked && tmn_thudichvu_chuyenchungtu.Checked == false)
                        {
                            if (thutheongay)
                            {
                                aexp = " where to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and a.mabn='" + txtMabn.Text + txtMabn1.Text + "' ";
                            }
                            else
                            {
                                aexp = " where a.maql in( " + v_maql + "," + m_mavaovien + ")";
                            }
                            aexp += " and aa.idttrv=0 ";
                            if (m_doituongthu != "")
                            {
                                aexp += " and aa.madoituong in(" + m_doituongthu.Trim(',') + ")";
                            }

                            sql = "select to_number('0') as bhyt,to_number('0') as bhyt_tt, a.mabs,a.id,b.ma, b.ten, b.dang as dvt, aa.soluong, b.giaban as dongia, b.giaban, to_number('0') as gia_bh, aa.soluong*b.giaban as sotien, to_number('0') as bhyttra, to_number('0') as bntra, aa.mabd as mavp, aa.madoituong ,to_number('2') as loai,to_number('0') as dichvu,to_number('0') as nhom,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho,  to_number('4') as phuthu, a.id as idtonghop ";
                            sql += " , a1.makp, '' mabs, aaa.losx, aaa.handung ";//binh 220711
                            sql += " from medibvmmyy.d_ngtrull a inner join medibvmmyy.d_ngtruct aa on a.id=aa.id inner join medibvmmyy.d_theodoi aaa on aa.sttt=aaa.id ";
                            sql += " left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on aa.mabd=b.id left join medibv.doituong c on aa.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp ";
                            sql += aexp + " and a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";// gam 20-06-2011 them dk and mabn=''
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
                        if (tmn_Toathuocmuangoai_chuaduyet.Checked && tmn_thudichvu_chuyenchungtu.Checked == false)
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
                            aexp += " and aa.paid=0 ";
                            if (m_doituongthu != "")
                            {
                                aexp += " and aa.madoituong in(" + m_doituongthu.Trim(',') + ") ";
                            }
                            sql = "select to_number('0') as bhyt,to_number('0') as bhyt_tt,a.mabs,a.id,b.ma, b.ten, b.dang as dvt, aa.slyeucau as soluong, b.giaban as dongia, to_number('0') as giaban, to_number('0') as gia_bh, aa.slyeucau*b.giaban as sotien, to_number('0') as bhyttra, to_number('0') as bntra, aa.mabd as mavp, aa.madoituong ,to_number('2') as loai,to_number('0') as dichvu,to_number('0') nhom,to_number('0') as mien,to_char(0) phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho,  to_number('0') as phuthu, a.id as idtonghop ";
                            sql += " , a.makp, a.mabs, '' as losx, '' as handung ";//binh 220711
                            sql += " from medibvmmyy.d_thuocbhytll a inner join medibvmmyy.d_thuocbhytct aa on a.id=aa.id left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on aa.mabd=b.id left join medibv.doituong c on aa.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + aexp + " and a.mabn='" + txtMabn.Text + txtMabn1.Text + "' and a.madoituong<>1";// gam 20-06-2011 them dk and mabn=''
                            sql += " and a.done = 0";//chua duyet - binh 120711
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

                    }
                    #region Load_phanbhyt_duoi_dinhmuc_124500
                    if (tmn_thudichvu_chuyenchungtu.Checked == false && ((txtSothe.Text != "") && (m_id == "0" || m_id == "")) && (m_v.get_maphu(txtSothe.Text) != 0))
                    {
                        sql = "select to_number('0') as bhyt,to_number('0') as bhyt_tt, c.mabs, c.idtonghop as id, e.ma,e.ten,e.dvt, c.soluong, c.dongia, c.dongia giaban, c.dongia as gia_bh, ";
                        sql += " c.soluong*c.dongia as sotien, to_number('0') as bhyttra, to_number('0') as bntra,e.id as mavp,";
                        sql += " c.madoituong, c.dongia, to_number('1') as loai ";
                        sql += ", b.chenhlech,to_number('0') as dichvu,e.nhomvp as nhom,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,c.sttcho, to_number('0') as phuthu, c.idtonghop as idtonghop  ";
                        sql += " , c.makp, c.mabs, c.losx, c.handung ";//binh 220711
                        sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id ";
                        sql += " inner join medibvmmyy.v_ttrvct c on a.id=c.id ";
                        sql += " inner join (select a.id, a.ma, a.ten||' '||a.hamluong as ten, a.dang as dvt, d.ma as nhomvp, d.ten as tennhomvp from medibv.d_dmbd a, medibv.d_dmnhom b, medibv.v_loaivp c, medibv.v_nhomvp d where a.manhom=b.id and b.loaivp=c.id and c.id_nhom=d.ma union all select a.id, a.ma, a.ten, a.dvt, c.ma as nhomvp, c.ten as tennhomvp from medibv.v_giavp a, medibv.v_loaivp b, medibv.v_nhomvp c where a.id_loai=b.id and b.id_nhom=c.ma) e on c.mavp=e.id ";
                        sql += " left join medibv.dmbs d on c.mabs=d.ma ";
                        sql += " where a.mabn='" + txtMabn.Text + txtMabn1.Text.Trim() + "'";

                        sql = sql + " and c.madoituong in (1) and c.bhyttra=c.sotien and b.loaibn in (0,3,4)";
                        sql = ((sql + " and ((a.mavaovien=" + m_mavaovien + ") or a.maql in( " + v_maql + "," + m_mavaovien + "))") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ") + " where mabn='" + txtMabn1.Text.Trim() + "'";
                        sql = sql + " and (mavaovien=" + m_mavaovien + ")) ";
                        sql += " and c.dongchitra=1";

                        //
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
                    //
                    #endregion
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
                    if (tmn_thutatca.Checked)
                    {
                        //f_TinhtienhuongBHYT(m_dshoadon);//binh 030711 comment --> do goi trong f_tientien roi
                        f_Tinhtien(v_sotien_huong_bhyt);
                    }
                    else
                        f_Tinhtien(-1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_TinhtienhuongBHYT(DataSet m_dshoadon)
        {
            v_sotien_huong_bhyt = 0;
            decimal asoluong = 0, adongia = 0;
            try
            {
                foreach (DataRow r in m_dshoadon.Tables[0].Select("madoituong in (1)"))
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
                        v_sotien_huong_bhyt += Math.Round(asoluong * adongia, 2);
                    }
                }

            }
            catch
            {
                v_sotien_huong_bhyt = -1;
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

                sql = "select distinct a.maql, a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.ngay,'yyyymmddhh24:mi') as ngay1, a.makp,a.madoituong,to_number('3') as loaibn, nvl(a.maicd,' ') as maicd, nvl(a.chandoan,' ' ) as chandoan, nvl(a.mabs,' ') as mabs,c.ma as kyduyet, a.sovaovien from medibvmmyy.benhanpk a left join medibv.tylemien_mg b on a.mavaovien=b.mavaovien left join medibv.v_dsduyet c on b.nguoiduyetmien=c.ma where a.mabn='" + amabn + "' and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<= to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                if (tmn_thutatca.Checked || tmn_khongcungchitra.Checked)
                {
                    sql += " union all ";
                    //sql += "select distinct a.maql, a.maql as mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(a.ngay,'yyyymmddhh24:mi') as ngay1,a.makp,a.madoituong, to_number('0') as loaibn, '' as maicd,'' as chandoan,'' as mabs,c.ma as kyduyet, a.sovaovien from medibvmmyy.tiepdon  a left join medibv.tylemien_mg b on a.mavaovien=b.mavaovien left join medibv.v_dsduyet c on b.nguoiduyetmien=c.ma where a.noitiepdon not in (3) and a.mabn='" + amabn + "'";
                    sql += "select distinct a.maql, a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(a.ngay,'yyyymmddhh24:mi') as ngay1,a.makp,a.madoituong, to_number('0') as loaibn, '' as maicd,'' as chandoan,'' as mabs,c.ma as kyduyet, a.sovaovien from medibvmmyy.tiepdon  a left join medibv.tylemien_mg b on a.mavaovien=b.mavaovien left join medibv.v_dsduyet c on b.nguoiduyetmien=c.ma where a.noitiepdon not in (3) and a.mabn='" + amabn + "' and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<= to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (tmn_Cophongluu.Checked)
                {
                    if (sql1 != "")
                    {

                        sql1 += " union all ";
                    }
                    sql1 += "select distinct a.maql, a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.ngay,'yyyymmddhh24:mi') as ngay1, a.makp,a.madoituong, to_number('4') as loaibn, nvl(maicd,' ') as maicd, nvl(chandoan,' ' ) as chandoan, nvl(a.mabs,' ') as mabs,c.ma as kyduyet, a.sovaovien from medibvmmyy.benhancc  a left join medibv.tylemien_mg b on a.mavaovien=b.mavaovien left join medibv.v_dsduyet c on b.nguoiduyetmien=c.ma where a.mabn='" + amabn + "' and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<= to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (tmn_Conhanbenh.Checked)
                {
                    if (sql1 != "")
                    {
                        sql1 += " union all ";
                    }
                    sql1 += "select distinct a.maql, a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.ngay,'yyyymmddhh24:mi') as ngay1, a.makp,a.madoituong, a.loaiba as loaibn, nvl(a.maicd,' ') as maicd, nvl(a.chandoan,' ' ) as chandoan, nvl(a.mabs,' ') as mabs,c.ma as kyduyet, a.sovaovien from medibv.benhandt  a left join medibv.tylemien_mg b on a.mavaovien=b.mavaovien left join medibv.v_dsduyet c on b.nguoiduyetmien=c.ma where a.mabn='" + amabn + "' and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<= to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (tmn_conamngoaitru.Checked)
                {
                    if (sql1 != "")
                    {
                        sql1 += " union all ";
                    }
                    sql1 += "select distinct a.maql, a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.ngay,'yyyymmddhh24:mi') as ngay1, a.makp,a.madoituong,to_number('2') as loaibn, nvl(a.maicd,' ') as maicd, nvl(a.chandoan,' ' ) as chandoan, nvl(a.mabs,' ') as mabs,c.ma as kyduyet, a.sovaovien from medibv.benhanngtr  a left join medibv.tylemien_mg b on a.mavaovien=b.mavaovien left join medibv.v_dsduyet c on b.nguoiduyetmien=c.ma where a.mabn='" + amabn + "' and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<= to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }

                DataSet ads = null, ads1 = null, ads2 = null;
                if (sql1 != "")
                {
                    sql1 += "  order by ngay1 desc,maql desc";
                    //ads1 = m_v.get_data_bc(adt.AddMonths(-1), txtNgaythu.Value.AddMonths(1), sql1);
                    ads1 = m_v.get_data_mmyy(sql1, m_v.DateToString("dd/MM/yyyy", adt.AddMonths(-iSothang)), txtNgaythu.Text.Substring(0, 10), true);
                }
                //
                if (sql != "")
                {
                    sql += "  order by ngay1 desc,maql desc";
                    //ads = m_v.get_data_bc(adt.AddMonths(-1), txtNgaythu.Value, sql);
                    ads = m_v.get_data_mmyy(sql, m_v.DateToString("dd/MM/yyyy", adt.AddMonths(-iSothang)), txtNgaythu.Text.Substring(0, 10), true);
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
                foreach (DataRow r in ads.Tables[0].Select("", "ngay1 desc,maql desc"))   ads2.Tables[0].Rows.Add(r.ItemArray);
              
                cbNgayvv.DisplayMember = "ngay";
                cbNgayvv.ValueMember = "maql";
                cbNgayvv.DataSource = ads2.Tables[0];
                cbDoituong.SelectedValue = ads2.Tables[0].Rows[0]["madoituong"].ToString();
                try
                {
                    txtBacsi.Text = ads2.Tables[0].Rows[0]["mabs"].ToString();
                    txtBacsi_Validated(null, null);
                }
                catch { txtBacsi.Text = ""; }
                try
                {
                   txtICD.Text = ads2.Tables[0].Rows[0]["maicd"].ToString();
                }
                catch { txtChandoan.Text = ""; }
                try
                {
                    txtKymien.Text = ads2.Tables[0].Rows[0]["kyduyet"].ToString();
                }
                catch { txtChandoan.Text = ""; }
                if (v_maql != "")
                {
                    try
                    {
                        cbNgayvv.SelectedValue = v_maql;
                    }
                    catch{}
                }
                else if (cbNgayvv.SelectedIndex != -1) v_maql = cbNgayvv.SelectedValue.ToString();
              // f_Load_BHYT();
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
            tmn_thudichvu_chuyenchungtu.Checked = false;
            f_Moi();
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            string ammyy = "",exp = "";
            if (!kiemtra())
                return;
            if (v_tachhoadon_dv != "" || v_tachbienlai_dv != "" || tmn_thutatca.Checked)
            {
                
                if (v_tachhoadon_dv == "" && v_tachbienlai_dv == "")
                {
                    //f_TinhtienhuongBHYT(m_dshoadon);
                    LibDuoc.AccessData d = new LibDuoc.AccessData();
                    decimal atien = d.ma16_st(1);
                    f_TinhtienhuongBHYT(m_dshoadon);

                    f_Luu();

                    //if (cmbTraituyen.SelectedIndex == 0 && v_sotien_huong_bhyt>0  && v_sotien_huong_bhyt + zsotien_datra < atien && cbDoituongTD.SelectedValue.ToString() == "1")
                    //{
                    //    if (MessageBox.Show("Số tiền được hưởng BHYT nhỏ hơn " + atien + ". Bạn có muốn lưu chi phí BHYT không ? ", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //    {
                    //        f_Luu();
                    //    }
                    //    else
                    //    {
                    //        f_Luu(false, m_dshoadon.Tables[0].Select("madoituong not in (1)"));
                    //    }
                    //}
                    //else
                    //{
                    //    f_Luu();
                    //}

                }
                else
                {
                    if (v_tachhoadon_dv != "") exp = "madoituong in (" + v_tachhoadon_dv + ")";
                    else if (v_tachbienlai_dv != "") exp = "nhom in (" + v_tachbienlai_dv.Trim(',') + ")";
                    DataSet ds = new DataSet();
                    ds = m_dshoadon.Clone();
                    //tách hóa đơn

                    foreach (DataRow rct in m_dshoadon.Tables[0].Select(exp))
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
                    f_Tinhtien(v_sotien_huong_bhyt);
                    f_Luu(false, m_dshoadon.Tables[0].Select("true"));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        m_dshoadon.Clear();
                        m_dshoadon = ds.Copy();
                        dgHoadon.DataSource = m_dshoadon.Tables[0];
                        if (!b_sua && !b_huykembldv) m_id = "";
                        else if (!b_sua && b_huykembldv) m_id = "-" + m_id;

                        f_Tinhtien(v_sotien_huong_bhyt);
                        f_Luu(true, m_dshoadon.Tables[0].Select("true"));
                    }
                }
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16));
                f_Load_Thutrongngay();
            }
            
            
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
                    dgHoadon.Update();
                    dgHoadon.Refresh();
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
                    txtMabn_Validated(null, null);
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
            if (m_Docmavach)
            {
                string s = txtMabn.Text;
                if (s.Length == i_maxlength_mabn)
                {
                    txtMabn.Text = s.Substring(0, 2);
                    txtMabn1.Text = s.Substring(2);
                    txtMabn1.Text = txtMabn1.Text.PadLeft(i_maxlength_mabn - 2, '0');//(6, '0');
                }
            }
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
            if (m_Docmavach)
            {
                string s = txtMabn1.Text;
                if (s.Length == i_maxlength_mabn)
                {
                    txtMabn.Text = s.Substring(0, 2);
                    txtMabn1.Text = s.Substring(2);
                    txtMabn1.Text = txtMabn1.Text.PadLeft(i_maxlength_mabn - 2, '0');//(6, '0');
                }
            }
            try
            {
                int i = int.Parse(txtMabn1.Text.Trim());
                 string tmp_max_mabn = "999999";
                if (i_maxlength_mabn > 8) tmp_max_mabn = tmp_max_mabn.PadLeft(i_maxlength_mabn - 2, '9');
                if (i >= 0 && i <= int.Parse(tmp_max_mabn))                
                {
                    txtMabn1.Text = i.ToString().PadLeft(i_maxlength_mabn - 2, '0');//.PadLeft(6, '0');
                }
                else
                {
                    txtMabn1.Text = "";
                }
            }
            catch
            {
                txtMabn1.Text = "";
            }
           
            if (txtMabn.Text.Length == 2 && txtMabn1.Text.Length == i_maxlength_mabn-2)//&& txtMabn1.Text.Length == 6)
            {
                f_Load_Hanhchanh(txtMabn.Text + txtMabn1.Text);
            }
            //label26_Click(null, null);
        }

        private void cbNgayvv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //gam 21-04-2011 kiểm tra nếu đang load hóa đơn thu rồi thì không load lại chỉ định
                if (m_id != "")
                {
                    return;
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNgayvv.DataSource]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("maql=" + cbNgayvv.SelectedValue.ToString()))
                {
                    cbLoaibn.SelectedValue = r["loaibn"].ToString();
                    cbKhoavv.SelectedValue = r["makp"].ToString();
                    txtKhoavv.Text = r["makp"].ToString();
                    cbKhoavv.SelectedValue = r["makp"].ToString();
                    txtICD.Text = r["maicd"].ToString();
                    txtChandoan.Text = r["chandoan"].ToString();
                    txtBacsi.Text = r["mabs"].ToString();
                    cbBacsi.SelectedValue = r["mabs"].ToString();
                    txtKymien.Text = r["kyduyet"].ToString();
                    txtMabn1.Tag = r["sovaovien"].ToString();
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
                   
                    //
                    f_load_thoidiemdangky(f_get_mabn(), m_mavaovien);
                    if (txtChandoan.Text.Trim() == "") txtChandoan.Text = f_get_chandoan_chidinh_cls(f_get_mabn(), m_maql, m_mavaovien);
                    //
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
            if (!tmn_Luuin_Hoadon.Checked && !tmn_Luuin_Phieuthuchi.Checked && !tmn_Luuin_Chiphi.Checked)
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
                    f_Inchiphi();
                }
                else
                {
                    f_Inhoadon(false);
                    f_Inchiphi();
                }
                if (tmn_Luuin_Phieuthuchi.Checked)
                {
                    f_Inphieuthuchi();
                }
                if (tmn_inphieumien.Checked)
                {
                    f_InPhieuMien(m_id);
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
            f_Inchiphi_mau38();// f_Inchiphi();            
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
                pHanhchanh.Height = v_bool ? 25 : 135;
            }
            catch
            {
            }
        }

        private void toolStrip_Title_Click(object sender, EventArgs e)
        {
            try
            {
                pHanhchanh.Height = (pHanhchanh.Height > 100) ? 25 : 135;
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
                frmDanhsachchoBHYT m_frmdanhsachchoBHYT = new frmDanhsachchoBHYT(m_v, m_userid,thuphi,tmn_thutatca.Checked,tmn_thudichvu_chuyenchungtu.Checked);
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
                            f_Load_Chidinh(m_frmdanhsachchoBHYT.s_ngaycd, m_frmdanhsachchoBHYT.s_maql, false);
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
            try
            {
                txtMabn1.Text = txtMabn1.Text.Trim();
            }
            catch
            {
            }
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
                    SendKeys.Send("{Tab}{F4}");
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

        private void get_tongchiphi_datra(string m_mabn, string m_mavaovien, string m_ngay,string m_sothe)
        {
            string xxx = m_v.user + m_v.mmyy(m_ngay), sql = "", sqlht = "";
            zsotien_datra = 0; zbhyt_datra = 0; zmien_datra = 0; zbntra_datra = 0; ztamung_datra = 0;
            if (m_id.Trim() == "" && m_mavaovien == "") return;
            sqlht = "select * from " + xxx + ".v_hoantra where mabn='" + m_mabn + "' and loaibn in (1,3) and to_char(ngay,'dd/mm/yyyy')='" + m_ngay.Substring(0, 10) + "'";
            //sql = "select b.sotien,b.mien,b.bhyt,b.tamung from " + xxx + ".v_ttrvds a inner join " + xxx + ".v_ttrvll b on a.id=b.id inner join " + xxx + ".v_ttrvbhyt c on a.id=c.id ";//
            sql = "select sum(cc.sotien) as sotien, max(b.mien) as mien, sum(cc.bhyttra) as bhyt, max(b.tamung) as tamung ";
            sql += " from " + xxx + ".v_ttrvds a inner join " + xxx + ".v_ttrvll b on a.id=b.id inner join " + xxx + ".v_ttrvbhyt c on a.id=c.id inner join " + xxx + ".v_ttrvct cc on a.id=cc.id ";//binh 040711
            sql += " left join (" + sqlht + ") d on b.quyenso=d.quyenso and b.sobienlai=d.sobienlai and d.id is null ";            
            sql += "  where b.sobienlai>0 and a.mabn='" + m_mabn + "' and to_char(b.ngay,'dd/mm/yyyy')='" + m_ngay.Substring(0, 10) + "' and c.sothe='" + m_sothe + "'";
            sql += " and cc.madoituong=1 and cc.dongchitra=0";//chi lay phan BHYT da tinh dong chi tra, dongchitra=1--> cho xet dong chi tra o nhung hoa don sau
            if (m_id != "") sql += " and a.id <> " + m_id;
            if (m_mavaovien.Trim() != "") sql += " and a.mavaovien=" + m_mavaovien;
            if (tmn_thudichvu_chuyenchungtu.Checked) sql += " and cc.idchinhanh<>cc.idchinhanhden ";
            DataSet lds= m_v.get_data(sql);
            

            foreach (DataRow r in lds.Tables[0].Rows)
            {
                zsotien_datra += (r["sotien"].ToString() == "") ? 0 : decimal.Parse(r["sotien"].ToString());
                zbhyt_datra += (r["bhyt"].ToString() == "") ? 0 : decimal.Parse(r["bhyt"].ToString());
                zmien_datra += (r["mien"].ToString() == "") ? 0 : decimal.Parse(r["mien"].ToString());
                ztamung_datra += (r["tamung"].ToString() == "") ? 0 : decimal.Parse(r["tamung"].ToString());
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

        
        private void toolStrip_Thoilai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (butLuu.Enabled && butMoi.Enabled == false) butLuu.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void toolStrip_Thoilai_Validated(object sender, EventArgs e)
        {
            try
            {
                string s_bndua = toolStrip_BNDua.Text.Trim();
                if (s_bndua.Trim().Length > 0)
                {
                    decimal d_bndua = decimal.Parse(s_bndua);
                    decimal d_bntra = decimal.Parse(toolStrip_Thucthu.Text);
                    decimal d_thoilai = d_bndua - d_bntra;
                    toolStrip_Thoilai.Text = d_thoilai.ToString("###,###,##0.##").Trim();
                    toolStrip_BNDua.Text = d_bndua.ToString("###,###,##0.##").Trim();

                    f_call_lcd(txtMabn.Text + txtMabn1.Text, txtHoten.Text, d_bntra.ToString("###,###,##0.##"), d_bndua.ToString("###,###,##0.##"), d_thoilai.ToString("###,###,##0.##"));
                }
            }
            catch
            {
                toolStrip_BNDua.Text = "";
                toolStrip_Thoilai.Text = "";
            }
        }
        private void f_call_lcd(string v_mabn, string v_hoten, string v_sotien, string v_sotien_bndua, string v_thoilai)
        {
            DataSet ds = new DataSet();
            if (this.mnu_LCD.Checked)
            {
                if (System.IO.File.Exists(@"..\..\..\xml\v_mauLCD.xml") == false)
                    System.IO.File.Copy(@"..\..\..\xml\mauLCD.xml", @"..\..\..\xml\v_mauLCD.xml");

                ds.ReadXml(@"..\..\..\xml\v_mauLCD.xml");
                this.sizestt = int.Parse(ds.Tables[0].Rows[0]["s2"].ToString());
                try
                {
                    if (this.fgoi == null)
                    {
                        this.fgoi = new frmGoibenhKham();
                        this.fgoi.Show();
                        this.fgoi.sets = this.sizestt;
                        this.fgoi.s_sohienthi = "Số tiền: " + v_sotien.Replace(".", ";").Replace(",", ".").Replace(";", ",");
                        this.fgoi.set_size_hoten = 40;
                        this.fgoi.s_hotenbn = v_hoten;// +" [" + v_mabn + "]";
                        this.fgoi.s_sotien_bn_dua = "Khách Đưa: " + v_sotien_bndua.Replace(".", ";").Replace(",", ".").Replace(";", ",");
                        this.fgoi.s_sotien_thoilai = "Thối lại: " + v_thoilai.Replace(".", ";").Replace(",", ".").Replace(";", ",");
                        //
                        this.fgoi.s_diachi = "Địa chỉ: " + txtDiachi.Text.Trim().Trim('-').Trim();
                        this.fgoi.s_ngaysinh = "Ngày sinh: " + txtNgaysinh.Text;
                        //
                        this.fgoi.Update();
                        this.fgoi.Refresh();

                    }
                    else
                    {
                        this.fgoi.sets = this.sizestt;
                        this.fgoi.s_sohienthi = "Số tiền: " + v_sotien.Replace(".", ";").Replace(",", ".").Replace(";", ",");
                        this.fgoi.set_size_hoten = 40;
                        this.fgoi.s_hotenbn = v_hoten;// +" [" + v_mabn + "]";
                            this.fgoi.s_sotien_bn_dua = "Khách Đưa: " + v_sotien_bndua.Replace(".", ";").Replace(",", ".").Replace(";", ",");
                            this.fgoi.s_sotien_thoilai = "Thối lại: " + v_thoilai.Replace(".", ";").Replace(",", ".").Replace(";", ",");
                        this.fgoi.s_diachi = "Địa chỉ: " + txtDiachi.Text.Trim().Trim('-').Trim();
                        this.fgoi.s_ngaysinh = "Ngày sinh: " + txtNgaysinh.Text;
                        this.fgoi.Update();
                        this.fgoi.Refresh();

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            System.Threading.Thread.Sleep(1000);
        }

        private void mnu_xuatLCD_Click(object sender, EventArgs e)
        {
            this.m_v.writeXml("v_thongso", "ttlcd", this.mnu_LCD.Checked ? "1" : "0");
        }

        private void mnu_thongsoLCD_Click(object sender, EventArgs e)
        {
            new frmThongsoLCD(this.m_v).ShowDialog();

        }

        private void toolStrip_BNDua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (butLuu.Enabled && butMoi.Enabled == false) butLuu.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void toolStrip_BNDua_Validated(object sender, EventArgs e)
        {
            try
            {
                string s_bndua = toolStrip_BNDua.Text.Trim();
                if (s_bndua.Trim().Length > 0)
                {
                    decimal d_bndua = decimal.Parse(s_bndua);
                    decimal d_bntra = decimal.Parse(toolStrip_Thucthu.Text);
                    decimal d_thoilai = d_bndua - d_bntra;
                    toolStrip_Thoilai.Text = d_thoilai.ToString("###,###,##0.##").Trim();
                    toolStrip_BNDua.Text = d_bndua.ToString("###,###,##0.##").Trim();

                    f_call_lcd(txtMabn.Text + txtMabn1.Text, txtHoten.Text, d_bntra.ToString("###,###,##0.##"), d_bndua.ToString("###,###,##0.##"), d_thoilai.ToString("###,###,##0.##"));
                }
            }
            catch
            {
                toolStrip_BNDua.Text = "";
                toolStrip_Thoilai.Text = "";
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

        private void cbLydomien_KeyDown(object sender, KeyEventArgs e)
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

        private void cbKymien_KeyDown(object sender, KeyEventArgs e)
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

        private string f_get_idphongcls(string v_idpcls, int v_chinhanh)
        {
            if (v_idpcls == "") return v_idpcls;
            string v_idphongthuchiencls = v_idpcls;
            string sql = "select id from " + m_v.user + ".dmphongthuchiencls where 1=1 ";
            if (v_chinhanh > 0) sql += " and idchinhanh=" + v_chinhanh;
            if (v_idpcls.Trim().Trim(',') != "") sql += " and id in(" + v_idpcls.Trim().Trim(',') + ")";
            DataSet lds = m_v.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0) v_idphongthuchiencls = "";
            else
            {
                v_idphongthuchiencls = "";
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    v_idphongthuchiencls += r["id"].ToString() + ",";
                }
            }
            return v_idphongthuchiencls;
        }
        private int f_get_chinhanh(int i_userid)
        {
            int _chinhanh = 0;
            string sql = "select chinhanh from " + m_v.user + ".v_dlogin where id=" + i_userid;
            DataSet lds = m_v.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0)
            {
                _chinhanh = 0;
            }
            else _chinhanh = int.Parse(lds.Tables[0].Rows[0]["chinhanh"].ToString());

            return _chinhanh;
        }

        private void tmn_inphieumien_Click(object sender, EventArgs e)
        {

        }

        private void f_load_loaitg()
        {
            string sql = "select * from medibv.dmloaitg order by id";
            cbloaitg.DataSource= m_v.get_data(sql).Tables[0];
            cbloaitg.DisplayMember = "TEN";
            cbloaitg.ValueMember = "ID";

        }

        private void f_load_thoidiemdangky(string v_mabn, string v_mavaovien)
        {
            string user = m_v.user;
            string sql = "select to_char(ngaygio,'hh24:mi') as giodk, to_char(ngaygio,'dd/mm/yyyy hh24:mi') as ngaygio, id_loaitg from medibv.bndk_tg where mabn='" + v_mabn + "' and mavaovien=" + v_mavaovien;

            DataSet lds = m_v.get_data(sql);
            if (lds != null && lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    label36.Text = "Đăng ký khám lúc : " + r["ngaygio"].ToString();
                    cbloaitg.SelectedValue = r["id_loaitg"].ToString();
                    cbloaitg.Tag = r["ngaygio"].ToString();
                    m_giodangkykham = r["giodk"].ToString();
                    v_ngaygiodangky = r["ngaygio"].ToString();
                    i_loaitg_dkkham = (r["id_loaitg"].ToString() == "0") ? 0 : int.Parse(r["id_loaitg"].ToString());
                    break;
                }
            }

        }

        private string f_get_mabn()
        {
            return txtMabn.Text.PadLeft(2, '0') + txtMabn1.Text.PadLeft(i_maxlength_mabn - 2, '0');
        }

        private void tmn_inmau38bv_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_mau38_frmvienphiBHYT(m_userid, tmn_inmau38bv.Checked);
        }
        #region delete_phandongchitra_truynguoclai
        private void f_del_dongchitra_truynguoc(string a_mabn, string a_mavv, string a_maql, string aid_hientai, string aquyenso_hientai, string asobienlai_hientai)
        {
            //Tìm cac chi phi cua BN BHYT ma duoi dinh muc BHYT qui dinh
            //Xoa cac dong do: do da load len de thanh toan o hoa don sau
            // giam tong tien trong v_ttrvll, v_ttrvct
            if (((txtSothe.Text != "") && (m_id == "0" || m_id == "")) && (m_v.get_maphu(txtSothe.Text) != 0))
            {

                string ammyy = m_v.mmyy(txtNgaythu.Text);
                string sql = "select c.*, c.id as idth,b.sobienlaidv from medibvmmyy.v_ttrvds a,medibvmmyy.v_ttrvll b,medibvmmyy.v_ttrvct c ";
                sql = sql + " where a.id=b.id and a.id=c.id and a.mabn='" + a_mabn + "'";

                sql = sql + " and c.madoituong in (1) and c.bhyttra=c.sotien and b.loaibn in (0,3,4)";
                sql = ((sql + " and ((a.mavaovien=" + a_mavv + ") or a.maql in( " + a_maql + "," + a_mavv + "))") + " and a.mabn||' '||to_char(b.quyenso)||' '||to_char(b.sobienlai) " + " not in (select mabn||' '||to_char(quyenso)||' '||to_char(sobienlai) from medibvmmyy.v_hoantra ") + " where mabn='" + a_mavv + "'";
                sql = sql + " and (mavaovien=" + a_mavv + ")) ";
                sql += " and c.dongchitra=1 and a.id!=" + aid_hientai;
                decimal idth = 0;
                decimal id = 0;
                decimal asobldv = 0;
                foreach (DataRow r in m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows)
                {
                    if (decimal.Parse(r["idtonghop"].ToString()) != 0)
                    {
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set quyenso=" + aquyenso_hientai + ",sobienlai=" + asobienlai_hientai + ", idttrv=" + aid_hientai + " where id=" + decimal.Parse(r["idtonghop"].ToString().Trim().Replace(",", "")));
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_chidinh set idttrv=" + aid_hientai + " where madoituong=1 and id=" + decimal.Parse(r["idtonghop"].ToString().Trim().Replace(",", "")));
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vpkhoa set idttrv=" + aid_hientai + " where madoituong=1 and id=" + decimal.Parse(r["idtonghop"].ToString().Trim().Replace(",", "")));
                    }
                    idth = decimal.Parse(r["idth"].ToString().Trim().Replace(",", ""));
                    id = decimal.Parse(r["id"].ToString().Trim().Replace(",", ""));
                    asobldv = decimal.Parse(r["sobienlaidv"].ToString().Trim().Replace(",", ""));
                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set sotien=sotien-" + r["sotien"].ToString() + ", bhyt=bhyt-" + r["bhyttra"].ToString() + " where id=" + r["id"].ToString());

                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvct where madoituong=1 and bhyttra=sotien and id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());                    
                }                
            }
        }
        #endregion

        private void f_bnmien(int idvp)
        {
            string sql = "select distinct id_loai from medibv.v_giavp where id=" + idvp;
            sql += " union all ";
            sql += " select distinct b.loaivp as id_loai from medibv.d_dmbd a, medibv.d_dmnhom b where a.manhom=b.id  and a.id=" + idvp;
            foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
            {
                sql = "select mabn,mavaovien, tyle as tylemien, tldongchitra from medibv.tylemien_km a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + f_get_mabn() + "' and a.mavaovien=" + m_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien, tyle as tylemien, tldongchitra from medibv.tylemien_mg a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + f_get_mabn() + "' and a.mavaovien=" + m_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien, tyle as tylemien, tldongchitra  from medibv.tylemien_ud a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + f_get_mabn() + "' and a.mavaovien=" + m_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " order by mabn";
                ds_bnmien = m_v.get_data(sql);
            }
        }

        private void f_bnmien_thuoc(int v_mabd)
        {
            string sql = " select distinct b.loaivp as id_loai from medibv.d_dmbd a, medibv.d_dmnhom b where a.manhom=b.id  and a.id=" + v_mabd;
            foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
            {
                sql = "select mabn,mavaovien,tldongchitra as tylemien from medibv.tylemien_km a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + f_get_mabn() + "' and a.mavaovien=" + m_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien,tldongchitra as tylemien from medibv.tylemien_mg a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + f_get_mabn() + "' and a.mavaovien=" + m_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien,tldongchitra as tylemien  from medibv.tylemien_ud a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + f_get_mabn() + "' and a.mavaovien=" + m_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " order by mabn";
                ds_bnmien = m_v.get_data(sql);
            }
        }

        private void txtTienBNDua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (butLuu.Enabled && butMoi.Enabled == false) butLuu.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void txtTienBNDua_Validated(object sender, EventArgs e)
        {
            try
            {
                string s_bndua = txtTienBNDua.Text.Trim();
                if (s_bndua.Trim().Length > 0)
                {
                    decimal d_bndua = decimal.Parse(s_bndua);
                    decimal d_bntra = decimal.Parse(toolStrip_Thucthu.Text);
                    decimal d_thoilai = d_bndua - d_bntra;
                    toolStrip_Thoilai.Text = d_thoilai.ToString("###,###,##0.##").Trim();
                    txtTienthoilai.Text = d_thoilai.ToString("###,###,##0.##").Trim();
                    toolStrip_BNDua.Text = d_bndua.ToString("###,###,##0.##").Trim();
                    txtTienBNDua.Text = d_bndua.ToString("###,###,##0.##").Trim();

                    f_call_lcd(txtMabn.Text + txtMabn1.Text, txtHoten.Text, d_bntra.ToString("###,###,##0.##"), d_bndua.ToString("###,###,##0.##"), d_thoilai.ToString("###,###,##0.##"));
                }
            }
            catch
            {
                toolStrip_BNDua.Text = "";
                toolStrip_Thoilai.Text = "";
                txtTienthoilai.Text = "";
                txtTienBNDua.Text = "";
            }
        }
        #region cap nhat bhytcls
        //private void upd_vienphi(string v_mabn, string v_mavaovien)
        //{
        //    decimal d_id = 0;
        //    string user = m_v.user, sql = "", maso = "";
        //    DateTime dt1 = m.StringToDate(cbNgayvv.Text).AddDays(-m_v.iNgaykiemke);
        //    DateTime dt2 = m.StringToDate(cbNgayvv.Text).AddDays(m_v.iNgaykiemke);
        //    int y1 = dt1.Year, m1 = dt1.Month;
        //    int y2 = dt2.Year, m2 = dt2.Month;
        //    int itu, iden;
        //    DataTable tmp;
        //    string mmyy = "", d_mmyy = "";
        //    for (int i = y1; i <= y2; i++)
        //    {
        //        itu = (i == y1) ? m1 : 1;
        //        iden = (i == y2) ? m2 : 12;
        //        for (int j = itu; j <= iden; j++)
        //        {
        //            mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
        //            if (m_v.bMmyy(mmyy))
        //            {
        //                sql = "select id from " + user + mmyy + ".bhytkb where mabn='" + v_mabn + "' and mavaovien=" + v_mavaovien;
        //                if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
        //                tmp = m.get_data(sql).Tables[0];
        //                if (tmp.Rows.Count > 0)
        //                {
        //                    d_id = decimal.Parse(tmp.Rows[0]["id"].ToString());
        //                    d_mmyy = mmyy;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    string yyy = user + m_v.mmyy(cbNgayvv.Text.Substring(0,10));
        //    int stt = 1, itable;
        //    if (d_id != 0 && d_mmyy != "" && txtSothe.Text != "")
        //    {
        //        itable = d.tableid(d_mmyy, "bhytcls");
        //        //d.execute_data("delete from " + user + d_mmyy + ".bhytcls where id=" + d_id);
        //        sql = "select * from xxx.v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + v_mavaovien;
        //        //if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
        //        sql += " and madoituong=1 and paid=0 and idttrv=0";
        //        foreach (DataRow r in d.get_data_mmyy(sql, cbNgayvv.Text, cbNgayvv .Text, 30).Tables[0].Rows)
        //        {
        //            d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));
        //            sql = "update xxx.v_chidinh set paid=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString());
        //            if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
        //            sql += " and madoituong=" + int.Parse(madoituong.Text);
        //            d.execute_data_mmyy(sql, ngayvv.Text, ngayvv.Text, 30);
        //            d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
        //        }
        //        //d.execute_data("update xxx.v_chidinh set paid=1 where ");
        //        sql = "update " + user + d_mmyy + ".bhytkb set bntra=" + bntra + ",bhyttra=" + bhyttra;//+" where id=" + d_id;
        //        sql += " where mavaovien=" + l_matd;
        //        if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
        //        m.execute_data(sql);
        //    }
        //    else if (bDuyet_khambenh && sothe.Text != "")
        //    {
        //        int i_nhom = m.nhom_duoc;
        //        d_id = d.get_id_bhyt;
        //        d_mmyy = m.mmyy(ngayvv.Text);
        //        if (!d.upd_bhytds(d_mmyy, s_mabn, hoten.Text, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text.Trim()))
        //        {
        //            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
        //            return;
        //        }
        //        itable = d.tableid(d_mmyy, "bhytkb");
        //        d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
        //        if (!d.upd_bhytkb(d_mmyy, d_id, i_nhom, ngayvv.Text, s_mabn, l_matd, l_maql, makp.Text, cd_chinh.Text, icd_chinh.Text, mabs.Text, sothe.Text, int.Parse(madoituong.Text), s_noicap, i_userid, 3, traituyen.SelectedIndex))
        //        {
        //            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
        //            return;
        //        }
        //        sql = "update " + user + d_mmyy + ".bhytkb set bntra=" + bntra + ",bhyttra=" + bhyttra;
        //        sql += " where mavaovien=" + l_matd;
        //        if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
        //        //+" where id=" + d_id;
        //        m.execute_data(sql);
        //        itable = d.tableid(d_mmyy, "bhytcls");
        //        sql = "select * from xxx.v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_matd;
        //        if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
        //        sql += " and madoituong=" + int.Parse(madoituong.Text);
        //        foreach (DataRow r in d.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, 30).Tables[0].Rows)
        //        {
        //            d.upd_bhytcls(d_mmyy, d_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));
        //            sql = "update xxx.v_chidinh set paid=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString());
        //            if (maso != "") sql += " and maql in (" + maso.Substring(0, maso.Length - 1) + ")";
        //            sql += " and madoituong=" + int.Parse(madoituong.Text);
        //            d.execute_data_mmyy(sql, ngayvv.Text, ngayvv.Text, 30);
        //            d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
        //        }
        //    }
        //}
        #endregion

        private void f_get_chinhanhchuyen_chinhanhden(int v_mavp, int v_idchinhanh, ref int v_idchinhanhden )
        {
            string s_csthay="";
            v_idchinhanhden=v_idchinhanh;
            DataRow r = m_v.getrowbyid(m_dsgiavp.Tables[0], "chuyenchungtu=1 and id=" + v_mavp);
            if (r != null)
            {
                s_csthay=","+r["cosothay"].ToString().Trim(',')+",";
                if (s_csthay.Trim().Trim(',') == "") v_idchinhanhden = v_idchinhanh;
                else if (s_csthay.IndexOf("," + v_idchinhanh.ToString() + ",") < 0) v_idchinhanhden = int.Parse(r["coso"].ToString());
            }
        }

        private string f_get_chandoan_chidinh_cls(string m_mabn, string m_maql, string m_mavv)
        {
            string asql = "select distinct chandoan from medibvmmyy.v_chidinh where mabn='" + m_mabn + "'" ;
            if (m_mavaovien.Trim() != "" && m_mavaovien.Trim() != "0") asql += " and mavaovien=" + m_mavaovien;
            if (m_maql.Trim() != "" && m_maql.Trim() != "0") asql += "  and maql=" + m_maql;

            DataSet lds = m_v.get_data_bc_1(txtNgaythu.Text, txtNgaythu.Text, asql);
            string v_chandoan = "";
            if (lds!=null && lds.Tables.Count >= 0)
            {
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    if (v_chandoan.IndexOf(r["chandoan"].ToString()) < 0) v_chandoan += r["chandoan"].ToString() + ", ";
                }
            }
            return v_chandoan.Trim().Trim(',');
        }

        private void f_get_sttkham(string v_mabn, string v_ngay, string v_makp, ref string v_sttkham, ref string v_tenpk)
        {
            string asql = "select a.sovaovien, b.tenkp from " + m_v.user + m_v.mmyy(v_ngay) + ".tiepdon a, " + m_v.user + ".btdkp_bv b where a.makp=b.makp and a.mabn='" + v_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay + "' and a.makp='" + v_makp + "' order by a.maql desc ";
            DataSet lds = m_v.get_data(asql);
            if (lds != null || lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
            {
                v_sttkham = lds.Tables[0].Rows[0]["sovaovien"].ToString();
                v_tenpk = lds.Tables[0].Rows[0]["tenkp"].ToString();
            }
        }
    }
}