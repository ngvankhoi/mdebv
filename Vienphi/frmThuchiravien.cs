﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LibMedi;
namespace Vienphi
{
    public partial class frmThuchiravien : Form
    {
        private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string s_bhyt_chieudai = "";
        private string s_idthutamung = "";
        private string s_bhyt_kytu = "";
        private string s_bhyt_vitri = "",sql;
        private decimal d_bhyt_sotien = 0;
        private string m_cur_yy = "";
        private string m_id_gia = "";
        private DateTime m_cur_ngay = DateTime.Now;
        private string m_cur_loaidv = "", v_solanin = "";
        private string m_cur_quyenso = "", m_cur_quyenso_thathu = "", m_cur_quyenso_thua = "", m_cur_quyenso_dichvu = "";
        private string m_id_thvpll = "0", m_id_ttrvthatthu = "0", m_id_ttrvthua = "0";
        private DateTime m_cur_ngay_thuong = DateTime.Now;
        private string m_cur_loaidv_thuong = "",s_id_captoa="";
        private string m_cur_quyenso_thuong = "";
        private string m_doituongmien = "";
        private string quyensodv, sobienlaidv;
        private DataTable dtdm = new DataTable();        
        private TableLayoutPanel m_table;
        private LibVP.AccessData m_v;
        private DataSet m_dshoadon, m_dstamung, m_dsthieu,m_dsthua;
        private string m_id = "", m_mavaovien = "", m_maql = "", m_userid = "", m_idkhoa = "", m_maql_phongluu = "", s_loaibn_mien = "", m_idthuoc = "";
        private string v_doituongthu = "", v_khoaphongthu = "", v_idkhoa = "";
        private string s_makp_luu = "", s_mavp_huy = "", ttrv_bienlai_dichvu="";
        private DataSet m_dsgiavp;
        private DataSet m_dsnhomvp;
        private DataSet m_dsloaivp;
        private DataSet m_dshoadon_nhomvp;
        private DataSet m_dstyleban;
        private DataSet m_dsdoituong;
        private DataTable dtdv = new DataTable();
        private frmChonvp m_frmchonvp;
        private frmPrintHD m_frmprinthd;
        private bool CongthucTraiTuyen160212 = false, v_chuyenchidinhCLS = false;
        private bool m_bnmoi = false, bKhongcungchitra=false;        
        decimal d_dichvu_tt = 0, d_dichvu_tt_bhyt_tra = 0;
        private bool v_miendt_loai, v_BHYT_PL_PK, v_BHYT_PL_PK_KhongNV, v_BHYT_NT_PK, v_BHYT_NgT_PK, v_Quanglythatthuno, v_loadcho = false, v_Quanglydichvu;
        private bool v_thanhtoannhieudot_trongkhoa, b_bhyt_100_noitru_theodoibienlai = false, bThuchiravien_lamttrontienbn = false;
        private bool v_chophepsuagia = false, bTunguyen, bBatbuoc, v_ttrv_suanoidunghoadon;
        private string v_tachhoadon_dv = "";
        private bool b_sua = false, b_luumien = false, m_Docmavach = false; 
        private bool m_o_fullscreen = false, bCapcuu_Noitru = false, bDichvucapphatle = false, v_phuthu_capphatle_bhytnoitru = false, bCapve_noitru, b_huykembldv = false;// b_huykenbldv neu gia tri bằng true thì khi huy bien lai 
        //tự động hủy luôn biên lai đã được tách ( nếu có ) option in hoa don dich vu;
        private int itable, itableds, itablell, itablemien,iTraituyen, iSothang;
        private decimal l_maql_phongluu = 0,lTraituyen;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private string s_maql_captoa = "", v_NamBTDBN;
        private int iKytubegin_xet_chiphivanchuyen = 0, ikytuend_xet_chiphivanchuyen = 0;//gam 15/08/2011
        private int i_tylechinhsach = 0;
        private bool bThuchiRaVien_TachHDGTGT_TheoVAT = false;//binh 120912
        private bool bThuchiRaVien_SuaTamUng = false;//Thuy 13.09.2012
        private int i_maxlength_mabn = 8;
        private bool bbhyt_100_theodoibienlai = false, bChonhapmoi = false, m_mabntudong = false;
        private int iTreem6, iTreem15;
        private DataTable dticd = new DataTable();
        //
        public frmThuchiravien(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();

                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);           
                m_v = v_v;
                m_userid = v_userid;
                m_v.f_SetEvent(this);
                dgHoadon.AutoGenerateColumns = false;
                f_Load_Data();
                dgGia.Visible = false;
                
                m_o_fullscreen = m_v.get_o_fullscreen_frmthuchiravien(m_userid);
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
        public string s_quyenso_thatthu
        {
            set
            {
                try
                {                    
                    m_cur_quyenso_thathu = value;
                }
                catch
                {
                }
            }
        }
        public string s_quyenso_thua
        {
            set
            {
                try
                {                    
                    m_cur_quyenso_thua = value;
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
                    m_cur_ngay_thuong = txtNgaythu.Value;
                }
                catch
                {
                }
            }
        }
     
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
            //    return (m_v.get_data("select ten from medibv.thongso where id=50").Tables[0].Rows[0][0].ToString());
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

        private void frmThuchiravien_Load(object sender, EventArgs e)
        {
            try
            {
                string user = m_v.user; lTraituyen = (m.bTraituyen) ? m.lTraituyen_noitru : 0;
                i_maxlength_mabn = LibVP.AccessData.i_maxlength_mabn;
                bThuchiravien_lamttrontienbn = m_v.bThuchiravien_lamttrontienbn(m_userid);
                bbhyt_100_theodoibienlai = m_v.bhyt_100_theodoibienlai(m_userid);
                m_Docmavach = m_v.tt_Quanlymavach(m_userid);
                if (m_Docmavach)
                {
                    txtMabn.MaxLength = i_maxlength_mabn;
                    txtMabn1.MaxLength = i_maxlength_mabn;
                }
                //
                iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
                ttrv_bienlai_dichvu = m_v.ttrv_bienlai_dichvu(m_userid); cmbTraituyen.SelectedIndex = 0;
                b_bhyt_100_noitru_theodoibienlai = m_v.bhyt_100_noitru_theodoibienlai(m_userid);
                v_ttrv_suanoidunghoadon=m_v.ttrv_suanoidunghoadon(m_userid);
                v_Quanglydichvu = ttrv_bienlai_dichvu != "";
                v_tachhoadon_dv = m_v.ttrv_tachhoadon_dichvu(m_userid);
                if (v_Quanglydichvu)
                {
                    sql="select a.id from "+user+".d_dmbd a,"+user+".d_dmnhom b where a.manhom=b.id ";
                    sql += " and b.nhomvp in (" + ttrv_bienlai_dichvu.Substring(0, ttrv_bienlai_dichvu.Length - 1) + ")";
                    sql += " union all ";
                    sql += " select a.id from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id";
                    sql += " and b.id_nhom in (" + ttrv_bienlai_dichvu.Substring(0, ttrv_bienlai_dichvu.Length - 1) + ")";
                    dtdv = m_v.get_data(sql).Tables[0];
                }

                itable = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_ttrvct");
                itableds = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_ttrvds");
                itablell = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_ttrvll");
                itablemien = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_miennoitru");
                dtdm = m_v.get_data("select id,gia_bh from " + m_v.user + ".d_dmbd where hide=0 and bhyt>0 union all select id,gia_bh from " + m_v.user + ".v_giavp where hide=0 and bhyt>0").Tables[0];

                tmn_Nhapkymien_CheckedChanged(null, null);
                tmn_Nhaplydomien_CheckedChanged(null, null);
                s_bhyt_chieudai = f_Load_Bhyt_Chieudai().ToString().Trim().Trim(',') + ",";
                s_bhyt_kytu = f_Load_Bhyt_Kytu().ToString().Trim().Trim('+') + "+";
                s_bhyt_vitri = f_Load_Bhyt_Vitri().ToString().Trim();
                d_bhyt_sotien = decimal.Parse(f_Load_Bhyt_Sotien().ToString().Trim());
                //
                bThuchiRaVien_TachHDGTGT_TheoVAT = m_v.bThuchiravien_TachHoadonGTGT_VAT(m_userid);//binh 150812
                bThuchiRaVien_SuaTamUng = m_v.bThuchiravien_SuaTamUng(m_userid);//Thuy 13.09.2012
                bChonhapmoi = m_v.tt_chonhapmoi(m_userid);
                m_mabntudong = m_v.tt_mabntudong(m_userid);
                v_chuyenchidinhCLS = m_v.tt_ChuyenCLSChuaquaChidinh(m_userid);
                if (!bThuchiRaVien_SuaTamUng)
                {
                    txtTamung.ReadOnly = true;
                }
                //
                f_Load_Thutrongngay();
                CongthucTraiTuyen160212 = m.CongthucTraiTuyen160212;//gam 14/02/2012

                f_Load_Tonghop();
                f_Enable(false);               
                this.Refresh();
                butBoqua_Click(null, null);
                //
                string tmp_qso = m_cur_quyenso;
                lbKyhieu_Click(null, null);
                s_quyenso = tmp_qso;
                //
                try
                {
                    iSothang = int.Parse(m_v.sys_sothang);
                }
                catch { iSothang = 1; }
                //
                txtSobienlai.ReadOnly = true;
                if (cbKyhieu.Items.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Phải khai báo quyển sổ thu viện phí trước!") + "\n" + lan.Change_language_MessageText("Vào [Tiện ích] -> [Khai báo quyển sổ] để khai!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                }
                cbLoaidv_SelectedIndexChanged(null,null);
                butMoi_Click(null, null);
            }
            catch
            {
            }
            //gam 15/08/2011
            string s_vitri_xet_chiphivanchuyen = d.thetunguyen_vitri(1);
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
        }
       
        private void f_Display()
        {
            try
            {
                dgGia.Width = dgHoadon.Width;
                dgGia.Height = 104;
                dgGia.Width = dgHoadon.Width - 1;
                dgGia.Left = panel3.Left + dgHoadon.Left+11;
                dgGia.Top = panel3.Top+panel3.Height-dgGia.Height-panel1.Height-12;

                cbDoituong.DropDownWidth = cbDoituong.Width*2;
                cbKhoa.DropDownWidth = cbDoituong.Right-cbKhoa.Left;
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
                bTunguyen = m_v.ttrv_tunguyen(m_userid);
                bBatbuoc = m_v.ttrv_batbuoc(m_userid);
                tmn_Dungchungso.Checked = m_v.sys_dungchungso;
                tmn_thanhtoantheokhoa.Checked = m_v.bThanhtoan_khoa;
                v_thanhtoannhieudot_trongkhoa = m_v.ttrv_Thanhtoannhieudot_trongkhoa(m_userid) || m.bThanhtoan_ndot;
                b_bhyt_100_noitru_theodoibienlai = m_v.bhyt_100_noitru_theodoibienlai(m_userid);
                bDichvucapphatle = m_v.ttrv_dichvucapphatle(m_userid);
                tmn_Dungchungso.Enabled = false;
                v_solanin = m_v.sys_solanin;
                if (tmn_thanhtoantheokhoa.Checked && v_thanhtoannhieudot_trongkhoa)
                {
                    cbNgayrv.Visible = m_v.bThanhtoan_khoa;
                    label24.Visible = m_v.bThanhtoan_khoa;
                }
                else if (v_thanhtoannhieudot_trongkhoa && !tmn_thanhtoantheokhoa.Checked)
                {
                    cbNgayrv.Visible = v_thanhtoannhieudot_trongkhoa;
                    label24.Visible = v_thanhtoannhieudot_trongkhoa;
                }

                v_phuthu_capphatle_bhytnoitru = m_v.ttrv_phuthuCapphatleBHYT_Noitru(m_userid);

                v_miendt_loai = m_v.ttrv_Miendt_loaiNT(m_userid);
                v_BHYT_PL_PK = (m_v.ttrv_BHYT_PL_PK(m_userid) || m.bPhongluu_bhyt_khambenh);
                v_BHYT_PL_PK_KhongNV = m.bPhongluu_bhyt_khambenh_khongnhapvien;
                v_BHYT_NT_PK = m_v.bNoitru_bhyt_khambenh;
                v_BHYT_NgT_PK = m_v.bNgoaitru_bhyt_khambenh;
                v_Quanglythatthuno = m_v.ttrv_Quanlythathu(m_userid);
                
                bool asys_suatuychon = m_v.sys_quyen_suatuychon(m_userid);
                v_chophepsuagia = m_v.ttrv_chophepsuadongia(m_userid);
                tmn_Nhaplydomien.Enabled = asys_suatuychon;
                tmn_Nhapkymien.Enabled = asys_suatuychon;
                tmn_Nhapmienchitiet.Enabled = asys_suatuychon;
                tmn_Cokhambenh.Enabled = asys_suatuychon;
                tmn_Cophongluu.Enabled = asys_suatuychon;
                tmn_Conhanbenh.Enabled = asys_suatuychon;
                tmn_Congoaitru.Enabled = asys_suatuychon;
    
                tmn_Cokhambenh.Checked = m_v.ttrv_cokhambenh(m_userid);
                tmn_Cophongluu.Checked = m_v.ttrv_conamluu(m_userid);
                tmn_Conhanbenh.Checked = m_v.ttrv_conhanbenh(m_userid);
                tmn_Congoaitru.Checked = m_v.ttrv_congoaitru(m_userid);

                s_loaibn_mien = m_v.sys_Loaibn_mien();
                v_doituongthu = m_v.ttrv_Doituongthu(m_userid);
                v_khoaphongthu = m_v.ttrv_khoathu(m_userid);

                bCapcuu_Noitru = m_v.bCapcuu_noitru;
                bCapve_noitru = m_v.bCapve_noitru;
                string sql = "";
                string atmp = m_v.s_curmmyyyy;
                DataSet ads;
                DataRow r;
                m_cur_ngay = m_v.f_parse_date(atmp);
                m_cur_yy = m_cur_ngay.Year.ToString().Substring(2);

                ads = m_v.get_data("select makp,tenkp from medibv.btdkp_bv order by loai, tenkp");
            

                cbKhoa.DataSource = ads.Tables[0].Copy();
                cbKhoa.DisplayMember = "tenkp";
                cbKhoa.ValueMember = "makp";

                cbKhoavv.DataSource = ads.Tables[0].Copy();
                cbKhoavv.DisplayMember = "tenkp";
                cbKhoavv.ValueMember = "makp";

                cbKhoarv.DataSource = ads.Tables[0].Copy();
                cbKhoarv.DisplayMember = "tenkp";
                cbKhoarv.ValueMember = "makp"; 
                
                dticd = m.get_data("select cicd10,vviet from medibv.icd10 where hide=0 order by cicd10").Tables[0];
                listICD.DisplayMember = "CICD10";
                listICD.ValueMember = "VVIET";
                listICD.DataSource = dticd;

                try
                {
                    m_dstyleban = m_v.get_data("select tu,den,tyle as tyle from medibv.dmtyleban");
                }
                catch { }
                try
                {
                    sql = "select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong ";
                    if (v_doituongthu != "")
                    {
                        sql += " where madoituong in(" + v_doituongthu + ")";
                    }
                    sql += " order by madoituong";
                }
                catch
                {
                }

                ads = m_v.get_data(sql);
                m_dsdoituong = ads.Copy();
                cbDoituong.DataSource = ads.Tables[0].Copy();
                cbDoituong.DisplayMember = "doituong";
                cbDoituong.ValueMember = "madoituong";

                cbDoituongTD.DataSource = m_v.get_data("select * from medibv.doituong order by madoituong").Tables[0];
                cbDoituongTD.DisplayMember = "doituong";
                cbDoituongTD.ValueMember = "madoituong";
                m_doituongmien = "";

                tendantoc.DisplayMember = "DANTOC";
                tendantoc.ValueMember = "MADANTOC";
                tendantoc.DataSource = m_v.get_data("select * from medibv.btddt order by madantoc").Tables[0];
                tendantoc.SelectedValue = "25";

                tennuoc.DisplayMember = "TEN";
                tennuoc.ValueMember = "MA";
                tennuoc.DataSource = m_v.get_data("select * from medibv.dmquocgia order by ten").Tables[0];
                tennuoc.SelectedIndex = -1;

                tennn.DisplayMember = "TENNN";
                tennn.ValueMember = "MANN";
                load_btdnn(0);

                cbTinh.DataSource = m_v.get_data("select matt,tentt from medibv.btdtt order by tentt").Tables[0];
                cbTinh.DisplayMember = "tentt";
                cbTinh.ValueMember = "matt";

                foreach (DataRow r1 in ads.Tables[0].Select("mien=1"))
                {
                    m_doituongmien += ",";
                    m_doituongmien += r1["madoituong"].ToString();
                }
                m_doituongmien += ",";

                cbLoaidv.DataSource = m_v.get_data("select ma,ten from medibv.v_tenloaivp order by ma").Tables[0];
                cbLoaidv.DisplayMember = "ten";
                cbLoaidv.ValueMember = "ma";
                
                sql = "select id,sohieu,loai,userid,* from medibv.v_quyenso";
                if (!tmn_Dungchungso.Checked)
                {
                    sql += " where userid = " + m_userid;
                }
                sql += " order by ngayud desc";

                cbKyhieu.DisplayMember = "sohieu";
                cbKyhieu.ValueMember = "id";
                cbKyhieu.DataSource = m_v.get_data(sql).Tables[0];
                

                cbLoaibn.DataSource = m_v.get_data("select id,ten from medibv.v_loaibn order by id").Tables[0];
                cbLoaibn.DisplayMember = "ten";
                cbLoaibn.ValueMember = "id";

                cbGioitinh.DataSource = m_v.get_data("select ma,ten from medibv.dmphai order by ma desc").Tables[0];
                cbGioitinh.DisplayMember = "ten";
                cbGioitinh.ValueMember = "ma";

                iTreem6 = m_v.iTreem6;
                iTreem15 = m_v.iTreem15;                

                ads = m_v.get_data("select id,ten from medibv.v_lydomien order by ten asc");
                r = ads.Tables[0].NewRow();
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

                cbTuoi.DataSource = m_v.f_get_dmtuoi().Tables[0];
                cbTuoi.DisplayMember = "ten";
                cbTuoi.ValueMember = "id";
               
                sql = "select id,ma,ten,dvt,gia_th,gia_bh,gia_dv,gia_nn,gia_cs,gia_ksk,bhyt, sothe, bhyt_tt from medibv.v_giavp where hide=0 ";
                sql += " union all ";
                //sql += " select a1.id,a1.ma,a1.ten ||' '|| case when trim(a1.tenhc)='' then '' else '[ ' || trim(a1.tenhc) || ' ]' end ||' '|| "+
                //"case when trim(a1.hamluong)='' then '' else hamluong end as ten ,a1.dang as dvt, a1.giaban as gia_th, a1.giaban as gia_bh, " +
                //"a1.giaban as gia_dv,a1.giaban as gia_nn, a1.giaban as gia_cs, a1.giaban as gia_ksk, a1.bhyt, a1.sothe, a1.bhyt as bhyt_tt " +
                //"from medibv.d_dmbd a1 inner join medibv.d_dmnhom b1 on a1.manhom=b1.id where  a1.hide=0 ";//b1.nhom=1 and
                //sql += " order by ten";
                sql += " select a1.id,a1.ma,a1.ten ||' '|| case when trim(a1.tenhc)='' then '' else '[ ' || trim(a1.tenhc) || ' ]' end ||' '|| " +
                "case when trim(a1.hamluong)='' then '' else hamluong end as ten ,a1.dang as dvt,"+
               // " a1.giaban as gia_th,"+ kh khoa 12/02/14
                " a1.gia_bh as gia_th," +//khuyen 12/02/14 thay giaban=gia_bh
                " a1.giaban as gia_bh, " +
                "a1.giaban as gia_dv,a1.giaban as gia_nn, a1.giaban as gia_cs, a1.giaban as gia_ksk, a1.bhyt, a1.sothe, a1.bhyt as bhyt_tt " +
                "from medibv.d_dmbd a1 inner join medibv.d_dmnhom b1 on a1.manhom=b1.id where  a1.hide=0 ";//b1.nhom=1 and
                sql += " order by ten";
                dgGia.DataSource = m_v.get_data(sql).Tables[0];

                m_dsgiavp = m_v.get_data("select a.id, case when b.id_nhom is null then 0 else b.id_nhom end as id_nhom, a.ma, a.ten, a.dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs, a.gia_ksk, a.bhyt, case when a.ndm is null then 0 else a.ndm end as ndm, a.kcct, a.sothe, a.bhyt_tt from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id union all select a1.id,case when b1.nhomvp is null then 0 else b1.nhomvp end as id_nhom,a1.ma,a1.ten || case when trim(a1.tenhc)='' then '' else '[' || trim(a1.tenhc) || ']' end as ten ,a1.dang as dvt, a1.giaban as gia_th, a1.giaban as gia_bh, a1.giaban as gia_dv,a1.giaban as gia_nn, a1.giaban as gia_cs, a1.giaban as gia_ksk, a1.bhyt,0 as ndm ,a1.kcct, a1.sothe, a1.bhyt as bhyt_tt from medibv.d_dmbd a1 inner join medibv.d_dmnhom b1 on a1.manhom=b1.id order by ten");//where b1.nhom=1 
                m_dsnhomvp = m_v.get_data("select ma as id, stt, ten, viettat, to_number('0') as sotien from medibv.v_nhomvp order by stt, ten");
                m_dsloaivp = m_v.get_data("select id, stt, ten, viettat, id_nhom, to_number('0') as sotien from medibv.v_loaivp order by stt, ten");

                sql = "select to_char(now(),'') as ngay, to_char(now(),'') as ma, to_char(now(),'') as ten, to_char(now(),'') as dvt, to_number('0') as soluong, to_number('0') as dongia, to_number('0') as giamua, to_number('0') as sotien, to_number('0') as bhyttra,to_number('0') as chenhlech, to_number('0') as miendt,to_number('0') as bntra, to_number('0') as vat, to_number('0') as vattu, to_char(now(),'') as doituong, to_char(now(),'') as tenkp ,to_number('0') as madoituong,to_char(now(),'') as makp, to_number('0') as mavp, to_number('0') as onpaid,to_number('0') as id_ktcao,to_number('0') as ktcao,to_number('0') as mien_gdduyet,to_number('0') as id_loai,to_number('0') as mabs,to_number('0') as idtonghop,to_number('0') as stttonghop ";
                m_dshoadon = m_v.get_data(sql);
                m_dshoadon.Tables[0].Rows.Clear();
                dgHoadon.DataSource = m_dshoadon.Tables[0];

                sql = "select to_number('0') as chon, to_char(now(),'dd/mm/yyyy hh24:mi') as ngay, '' as sohieu, to_number('0') as sobienlai,to_number('0') as sotien,'' as user, to_number('0') as done, to_number('0') as id,0 as quyenso";
                m_dstamung = m_v.get_data(sql);
                m_dstamung.Tables[0].Rows.Clear();


                sql = "select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs,a.gia_ksk, trim(b.ten) as tenloai,b.id as id_loai, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id where a.hide=0 order by b.ten,b.stt, b.id, a.ten,a.stt";
                m_frmchonvp = new frmChonvp(m_v, m_userid,"GIA_TH", m_v.get_data(sql),m_v.s_loaiform_thuchiravien);
                m_frmchonvp.ShowInTaskbar = false;

                //m_frmdanhsachthuchiravien = new frmDanhsachthuchiravien(m_v, m_userid);
                //m_frmdanhsachthuchiravien.ShowInTaskbar = false;

                //m_frmdanhsachchothuchiravien = new frmDanhsachchothuchiravien(m_v, m_userid, v_doituongthu, v_khoaphongthu);
                //m_frmdanhsachchothuchiravien.ShowInTaskbar = false;
                
                //m_frmtimbenhnhan = new frmTimbenhnhan(m_v, m_userid);
                //m_frmtimbenhnhan.ShowInTaskbar = false;
                
                //m_frmtimhoadon = new frmTimhoadon(m_v, m_userid);
                //m_frmtimhoadon.ShowInTaskbar = false;
                //m_frmtimhoadon.s_loaihd = "1";

                //m_frmhoantra = new frmHoantra(m_v, m_userid);
                //m_frmhoantra.ShowInTaskbar = false;
                //m_frmhoantra.s_loaihd = "1";

                m_frmprinthd = new frmPrintHD(m_v,m_userid);

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmthuchiravien(m_userid);
                f_Set_Fullgrid();

                f_Display();

                //Option
                tmn_Luuin_Hoadon.Checked = m_v.get_o_luuin_hoadon_frmthuchiravien(m_userid);               
                tmn_Luuin_Phieuthuchi.Checked = m_v.get_o_luuin_phieuthuphieuchi_frmthuchiravien(m_userid);              
                tmn_Luuin_Chiphi.Checked = m_v.get_o_luuin_chiphi_frmthuchiravien(m_userid);               
                tmn_Luuin_Hoadon_Icon.Checked = m_v.get_o_luuin_frmthuchiravien(m_userid);               
                tmn_Xemtruockhiin_Icon.Checked = m_v.get_o_xemtruockhiin_frmthuchiravien(m_userid);

                tmn_Nhaplydomien.Checked = m_v.ttrv_nhaplydomien(m_userid);
                tmn_Nhapkymien.Checked = m_v.ttrv_nhapduyetmien(m_userid);
                tmn_Nhapmienchitiet.Checked = m_v.ttrv_nhapmienchitiet(m_userid);

                tmn_Thuchidinh.Checked = m_v.ttrv_thuchidinh(m_userid);
                tmn_Toathuoctutruc.Checked = m_v.ttrv_thutoatutruc(m_userid);
                tmn_Thuocthuongquy.Checked = m_v.ttrv_thuthuocthuongquy(m_userid);
                tmn_Vienphikhoa.Checked = m_v.ttrv_thuvienphikhoa(m_userid);
                tmn_Toachove.Checked = m_v.ttrv_ToaBHYT(m_userid);
                tmn_Khoatonghop.Checked = m_v.ttrv_thukhoatonghop(m_userid);
                tmn_Theotungkhoa.Checked = m_v.ttrv_Thanhtoannhieudot_theotungkhoa(m_userid);

                TTRV_HDDacthu.Checked = m_v.ttrv_InHDdacthu(m_userid);
                TTRV_HDChitiet.Checked = m_v.ttrv_InHDchitiet(m_userid);

                lbDuyetmien.Visible = tmn_Nhapkymien.Checked;
                lbLydomien.Visible = tmn_Nhaplydomien.Checked;
                
                txtLydomien.Visible = tmn_Nhaplydomien.Checked;
                cbLydomien.Visible = tmn_Nhaplydomien.Checked;

                txtKymien.Visible = tmn_Nhapkymien.Checked;
                cbKymien.Visible = tmn_Nhapkymien.Checked;
                chkBNthieu.Visible=m_v.ttrv_Quanlythathu(m_userid);
                chkBNThua.Visible = m_v.ttrv_Quanlythathu(m_userid);
            }
            catch
            {
            }
        }
        private void load_btdnn(int i)
        {
            if (i == 0) tennn.DataSource = m_v.get_data("select * from medibv.btdnn_bv order by mann").Tables[0];
            else
            {
                string s = txtNgaysinh.Text.Length > 4 ? txtNgaysinh.Text.Substring(6, 4) : txtNgaysinh.Text;
                if (txtNgaysinh.Text != "")
                {
                    if (DateTime.Now.Year - int.Parse(s) < iTreem6)
                        tennn.DataSource = m_v.get_data("select * from medibv.btdnn_bv where mannbo='01' order by mann").Tables[0];
                    else if (DateTime.Now.Year - int.Parse(s) < iTreem15)
                        tennn.DataSource = m_v.get_data("select * from medibv.btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
                    else tennn.DataSource = m_v.get_data("select * from medibv.btdnn_bv where mannbo<>'01' order by mann").Tables[0];
                }
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
                int iNext = 2;
                if (tmn_Nhapmienchitiet.Checked) iNext = 3;
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    ai++;
                    if (acol < 2) 
                    {
                        m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
                    }
                    alb = new Label();
                    alb.Name = "lbma_" + r["id"].ToString();
                    alb.Text = (r["viettat"].ToString().Trim()!="" ? r["viettat"].ToString().Trim() : r["ten"].ToString().Trim()) + ":";
                    toolTip1.SetToolTip(alb,r["ten"].ToString().Trim());
                    alb.AutoSize = true;
                    alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                    //Ty le % Mien
                    if (tmn_Nhapmienchitiet.Checked)
                    {
                        atb = new TextBox();
                        atb.Name = "tbtyle_" + r["id"].ToString();
                        atb.Text = "";
                        atb.BackColor = Color.White;
                        atb.Width = 25;
                        atb.Leave += new System.EventHandler(this.f_Control_Leave);
                        atb.Enter += new System.EventHandler(this.f_Control_Enter);
                        atb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                        //atb.Validated += new System.EventHandler(this.txt_Validated);
                        atb.ReadOnly = false;
                        atb.TextAlign = HorizontalAlignment.Right;
                        m_table.Controls.Add(atb, acol + 2, arow);
                    }
                    //End Ty le % Mien
                    arow++;
                    if (arow >= an)
                    {
                        arow = 0;
                        acol += iNext;
                    }
                }
                m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                alb = new Label();
                alb.Name = "_blank";
                alb.Text = "";
                alb.AutoSize = true;
                alb.Font = new System.Drawing.Font("Microsoft Sans Serif",10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                    f_Tinhtien();
                    //End
                    if (atb == m_table.Controls[m_table.Controls.Count - 2])
                    {
                        if (txtGDDuyet.Enabled)
                        {
                            txtGDDuyet.Focus();
                        }
                        else
                        {
                            butLuu.Focus();
                        }
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
            f_Tinhtien();
        }

        private void f_Load_Hanhchanh(string v_mabn)
        {
            try
            {
                bool aok = false;
                string sql = "",sql1="";
                m_bnmoi = true;
                sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.phai,a.sonha,a.thon,a.cholam,a.maphuongxa,a.mann,a.madantoc,nam,a.sonha||' '||a.thon||' '||d.tenpxa ||' '||c.tenquan||' '||b.tentt as  diachi from medibv.btdbn a inner join medibv.btdtt b on a.matt=b.matt inner join medibv.btdquan c on a.maqu=c.maqu inner join medibv.btdpxa d on a.maphuongxa=d.maphuongxa where a.mabn='" + v_mabn + "'";
                f_Clear_HC();
                sql1 = " select * from medibv.xuatkhoa where id in(select id from medibv.nhapkhoa where mabn='" + v_mabn + "') and ttlucrk in('1','2','3','4','7')";
                foreach (DataRow r in m_v.get_data(sql1).Tables[0].Rows)
                {
                    txtICD.Text = r["MAICD"].ToString();
                    txtChandoan.Text = r["CHANDOAN"].ToString();
                }
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    txtHoten.Text = r["hoten"].ToString();
                    noilamviec.Text = r["cholam"].ToString();
                    txtNgaysinh.Text = r["ngaysinh"].ToString();
                    txtNamsinh.Text = r["namsinh"].ToString();
                    if (txtNgaysinh.Text.Trim() == "null" || txtNgaysinh.Text.Trim() == "")
                    {
                        txtNgaysinh.Text = r["namsinh"].ToString();
                    }
                    cbGioitinh.SelectedValue = r["phai"].ToString();
                    txtDiachi.Text = r["diachi"].ToString().Trim();
                    f_Load_BNNO(v_mabn);
                    f_Load_BVNO(v_mabn);
                    txtSonha.Text = r["sonha"].ToString().Trim();
                    txtThonpho.Text = r["thon"].ToString().Trim();// +((noilamviec.Text != "") ? " - Nơi làm việc : " + noilamviec.Text + "" : "");
                    tennn.SelectedValue = r["mann"].ToString();
                    mann.Text = r["mann"].ToString();
                    madantoc.Text = r["madantoc"].ToString();
                    v_NamBTDBN = r["nam"].ToString();
                    if (manuoc.Enabled == false)
                        foreach (DataRow r1 in m_v.get_data("select id_nuoc from medibv.nuocngoai where mabn='" + v_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue = r1["id_nuoc"].ToString();
                    f_Load_T_Q_X(r["maphuongxa"].ToString());
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
                        try
                        {
                            cbDoituong.SelectedValue = "2";
                        }
                        catch
                        {
                        }
                        try
                        {
                            cbKhoa.SelectedValue = "00";
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
                        //MessageBox.Show(this, lan.Change_language_MessageText("Không cho phép bệnh nhân chưa hoàn tất thủ tục!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //f_Enable_HC(false);
                        //txtMabn.Focus();
                        //return;
                        if (bChonhapmoi)
                        {
                            f_Enable_HC(true);
                            f_Enabled_VP(true);
                            f_FullScreen(false);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(this, "Không cho phép nhập bệnh nhân mới!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            f_Enable_HC(false);
                            f_Enabled_VP(false);
                            txtMabn.Focus();
                            return;
                        }
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
                        if (bChonhapmoi)
                        {
                            f_Enable_HC(true);
                        }
                        else
                        {
                            f_Enable_HC(!aok);
                        }
                        txtGDDuyet.Focus();
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Load_BNNO(string s_mabn)
        {
            try
            {
                string sql = "select sum(sotien) as tongtien from medibv.v_ttrvthatthu where mabn='" + s_mabn + "'  and sotientra<>sotien ";
                decimal asotien=decimal.Parse(m_v.get_data(sql).Tables[0].Rows[0]["tongtien"].ToString());
                txtBNNolantruoc.Text = asotien.ToString("###,###,##0.##");
            }
            catch
            {
                txtBNNolantruoc.Text = "0";
            }
        }
        private void f_Load_BVNO(string s_mabn)
        {
            try
            {
                string sql = "select sum(sotien) as tongtien from medibv.v_ttrvthua where mabn='" + s_mabn + "'  and sotientra<>sotien ";
                decimal asotien = decimal.Parse(m_v.get_data(sql).Tables[0].Rows[0]["tongtien"].ToString());
                txtBVThieulantruoc.Text = asotien.ToString("###,###,##0.##");
            }
            catch
            {
                txtBVThieulantruoc.Text = "0";
            }
        }
        private void f_Clear_pTonghop()
        {
            try
            {
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0 || c.Name.IndexOf("tbtyle_") == 0)
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
                txtHoten.Text = txtNgaysinh.Text = noilamviec.Text = txtTuoi.Text = "";
                txtSonha.Text = "";
                txtThonpho.Text = "";
                txtNoilamviec.Text = "";
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
                txtTQX.Text = "";
                try
                {
                    cbTQX.SelectedIndex = -1;
                }
                catch
                {
                }
                cmbTraituyen.SelectedIndex = 0;
                txtDiachi.Text = txtSothe.Text = txtTN.Text = txtDN.Text = txtNDK_Ma.Text = txtNDK_Ten.Text = txtNgayrv.Text = txtSongayDT.Text = txtICD.Text = txtChandoan.Text = "";
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
                    cbDoituong.SelectedValue = 2;
                }
                catch
                {
                }
                try
                {
                    cbKhoa.SelectedIndex = -1;
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
                txtKhoarv.Text = "";
                try
                {
                    cbKhoarv.SelectedIndex = -1;
                }
                catch
                {
                }
                txtKhoarv.Text = "";
                try
                {
                    cbLydomien.SelectedIndex = -1;
                }
                catch
                {
                }
                txtLydomien.Text = txtTenvp.Text = txtSoluong.Text = txtDongia.Text = "";
                txtCPBHYT.Text = txtCPVienphi.Text = txtCongCP.Text = txtMienBHYT.Text = txtMienDT.Text = txtCongmien.Text = "";
                txtBNTra_BHYT.Text = txtBNTra_VP.Text = txtCongpt.Text = txtChenhlech.Text = "";
                txtTamung.Text = txtGDDuyet.Text = txtMienphantram.Text = txtPhaithu.Text = txtBNThieu.Text = txtthua.Text = txtBNNolantruoc.Text = txtBVtraNo.Text = txtBNtraNO.Text = txtThucthu_No.Text = "";
                lbBNTra.Text = lan.Change_language_MessageText("Phải thu:");
                lbPhaithu.Text = lan.Change_language_MessageText("Phải thu:");
                chkChuahoan.Checked = false;
                toolStrip_Mien.Text = toolStrip_BHYT.Text = toolStrip_Thucthu.Text = toolStrip_Tongcong.Text = toolStrip_Tamung.Text = "0";
                txtTinh.Text = m_v.Mabv.Substring(0, 3);
                cbTinh.SelectedValue = m_v.Mabv.Substring(0, 3);
                f_Load_CB_Quan(m_v.Mabv.Substring(0, 3));
                f_Load_CB_Xa(m_v.Mabv.Substring(0, 3) + "00");
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

                //txtHoten.ReadOnly = true;// !v_bool;
                //txtNgaysinh.ReadOnly = true;// !v_bool;
                //txtTuoi.ReadOnly = true;// !v_bool;
                cbTuoi.Enabled = v_bool;// v_bool;
                cbGioitinh.Enabled = v_bool;// v_bool;
                //txtDiachi.ReadOnly = true;// !v_bool;
                //txtSothe.ReadOnly = true;// !v_bool;
                //txtTN.ReadOnly = true;// !v_bool;
                //txtDN.ReadOnly = true;// !v_bool;
                //txtNDK_Ma.ReadOnly = true;// !v_bool;
                //txtNDK_Ten.ReadOnly = true;// !v_bool;
                cbLoaibn.Enabled = v_bool;
                cbDoituongTD.Enabled = v_bool;
                txtNgayrv.Enabled = true;
                txtSongayDT.Enabled = v_bool;
                txtICD.Enabled = v_bool;
                txtKhoavv.Enabled = v_bool;
                cbKhoavv.Enabled = v_bool;
                txtKhoarv.Enabled = v_bool;
                cbKhoarv.Enabled = v_bool;
                chkBNthieu.Enabled = true;
                chkBNThua.Enabled = true;

                txtTQX.Enabled = v_bool;
                cbTQX.Enabled = v_bool;
                txtTinh.Enabled = v_bool;
                cbTinh.Enabled = v_bool;
                txtQuan.Enabled = v_bool;
                cbQuan.Enabled = v_bool;

                txtXa.Enabled = v_bool;
                cbXa.Enabled = v_bool;  
            }
            catch
            {
            }

        }
        private void f_Enabled_VP(bool v_bool)
        {
            try
            {
                cbDoituong.Enabled = v_bool;
                txtTenvp.Enabled = v_bool;
                txtSoluong.Enabled = v_bool;
                txtDongia.Enabled = v_bool;
                cbKhoa.Enabled = v_bool;

                txtLydomien.Enabled = v_bool && tmn_Nhaplydomien.Checked;
                cbLydomien.Enabled = v_bool && tmn_Nhaplydomien.Checked;

                txtKymien.Enabled = v_bool && tmn_Nhapkymien.Checked;
                cbKymien.Enabled = v_bool && tmn_Nhapkymien.Checked;

                butAdd.Enabled = v_bool;
                butRem.Enabled = v_bool;
                butChon.Enabled = v_bool;

                dgHoadon.Columns[6].ReadOnly = (v_ttrv_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[7].ReadOnly = (v_ttrv_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[8].ReadOnly = (v_ttrv_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[9].ReadOnly = (v_ttrv_suanoidunghoadon == false) ? true : !butLuu.Enabled;
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
                butInhoadon.Enabled = m_id != "" && m_id!="0";
                butInchiphi.Enabled = m_id != "" && m_id != "0";
                butSua.Enabled = !v_bool && m_id != "" && m_id != "0";
                butXoa.Enabled = !v_bool && m_id != "" && m_id != "0";
                butBoqua.Enabled = true;
                butPre.Enabled = !v_bool;
                butNext.Enabled = !v_bool;
                butKetthuc.Enabled = !v_bool;
                chkThuong.Enabled = !butLuu.Enabled;
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Phải khai báo quyển sổ thu viện phí trước!") + "\n" + lan.Change_language_MessageText("Vào [Tiện ích] -> [Khai báo quyển sổ] để khai!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                    return;
                }
                txtMabn.Enabled = true;
                txtMabn1.Enabled = true;
                tmn_Danhsachcho.Enabled = true ;
                f_FullScreen(m_o_fullscreen);
                m_bnmoi = true;
                v_loadcho = false;
                v_NamBTDBN = "";
                m_id = "";
                m_mavaovien = "";
                m_maql = "";
                m_idkhoa = "";
                m_idthuoc = "";
                b_sua = false;
                b_luumien = false;
                m_id_gia = "";
                s_mavp_huy = "";
                label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                m_dshoadon.Tables[0].Rows.Clear();
                try { m_dstamung.Tables[0].Rows.Clear(); }
                catch { }
                tendantoc.SelectedValue = "25";
                tennuoc.SelectedValue = "VN";
                cbNgayvv.DataSource = null;
                m_dshoadon_nhomvp = null;
                f_Clear_pTonghop();
                f_Clear_HC();
                f_Enable(true);
                f_Enable_HC(true);
                if (chkThuong.Checked)
                {
                    txtNgaythu.Value = m_cur_ngay_thuong;
                }
                else
                {                    
                    txtNgaythu.Value = m_v.f_parse_date_16(m_cur_ngay.Day.ToString().PadLeft(2,'0')+"/"+m_cur_ngay.Month.ToString().PadLeft(2,'0')+"/"+m_cur_ngay.Year.ToString() + " " + m_v.ngayhienhanh_server.Substring(11, 5));
                }

                try
                {
                    if (chkThuong.Checked)
                    {
                        if (m_cur_loaidv_thuong != "")
                        {
                            cbLoaidv.SelectedValue = m_cur_loaidv_thuong;
                            cbLoaidv_Validated(null, null);
                        }
                        else
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Chọn loại thu viện phí nội bộ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbLoaidv.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbLoaidv.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                    }
                    else
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
                }
                catch
                {
                }
                try
                {
                    if (chkThuong.Checked)
                    {
                        if (m_cur_quyenso_thuong != "")
                        {
                            cbKyhieu.SelectedValue = m_cur_quyenso_thuong;
                        }
                        else
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Chọn quyển sổ thu viện phí nội bộ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbLoaidv.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbKyhieu.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                    }
                    else
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
                }
                catch
                {
                }
                atmp = f_Get_Sobienlai();
                txtSobienlai.Text = atmp.Split(':')[0];
                if (v_Quanglythatthuno)
                {
                    lbl_SBLthatthu.Text = f_Get_Sobienlai_thatthu(m_cur_quyenso_thathu).Split(':')[0];
                    lbl_SBLthua.Text = f_Get_Sobienlai_thatthu(m_cur_quyenso_thua).Split(':')[0];

                    lbl_quyensothatthu.Text = m_cur_quyenso_thathu;
                    lbl_quyensothua.Text = m_cur_quyenso_thua;
                }

                if (v_Quanglydichvu)
                {
                    lbl_SBLdichvu.Text = f_Get_Sobienlai_thatthu(m_cur_quyenso_dichvu).Split(':')[0];
                    lbl_quyensodichvu.Text = m_cur_quyenso_dichvu;
                }
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
                chkBNThua.Checked = false;
                chkBNthieu.Checked = false;
                dgGia.Visible = false;
                txtMabn.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string f_Get_SoBienLai_Am()
        {
            try
            {
                string r = "";
                DataSet ads = m_v.get_data("select (nvl(soghiam,0)-1) soghiam from medibv.v_quyenso where to_char(id)='" + cbKyhieu.SelectedValue.ToString() + "'");
                r = ads.Tables[0].Rows[0]["soghiam"].ToString();
                return r;
            }
            catch
            {
                return "?";
            }
        }
        private void f_Luu()
        {
            bool bln_ct = true; bool bVPCapstt = false;
            string amakp_ll = "01";
            try
            {
                bool asua = (m_id!="" && m_id!="0");
                string atmp = "", aidcd = ",", aidchidinh = ",", amadoiutongct = "", amakpct = "";
                butLuu.Enabled = false;
                
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
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", anamsinh = "", ahoten = "", amavaovien = "", amaql = "", aidkhoa = "", amakp = "", aloai = "", aloaibn = "", auserid = "";             
                angay = txtNgaythu.Text.Substring(0, 16);
                ammyy = m_v.get_mmyy(angay);
                aid=m_id;
                try
                {
                    aid=decimal.Parse(m_id).ToString();
                }
                catch
                {
                    aid="0";
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
                try
                {
                    string s_sobienlai = m_v.get_data("select den from medibv.v_quyenso where id=" + cbKyhieu.SelectedValue.ToString() + "").Tables[0].Rows[0]["den"].ToString();
                    if (decimal.Parse(txtSobienlai.Text.Trim()) > decimal.Parse(s_sobienlai))
                    {
                        butLuu.Enabled = true;
                        MessageBox.Show(lan.Change_language_MessageText("Số biên lai nhập")+" " + txtSobienlai.Text.Trim() + " "+lan.Change_language_MessageText("không được lớn hơn số biên đã khai")+" " + s_sobienlai + " !"+"\n"+ lan.Change_language_MessageText("Vui lòng nhập lại số biên lai nhỏ hơn hoặc bằng")+" " + s_sobienlai + ".", m_v.s_AppName);
                        label31.Enabled = true;
                        txtSobienlai.Focus();
                        return; 
                    }
                }
                catch
                {
                }
                amabn=txtMabn.Text.Trim()+txtMabn1.Text.Trim();
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
                    amakp = cbKhoarv.SelectedValue.ToString();
                }
                catch
                {
                    amakp = "";
                }
                ahoten = txtHoten.Text.Trim();
                if (ahoten.Length == 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Nhập thông tin bệnh nhân!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHoten.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                anamsinh = txtNgaysinh.Text.Trim();
                if (anamsinh.Length > 4)
                {
                    anamsinh = anamsinh.Substring(anamsinh.Length - 4);
                }
                if (anamsinh == "")
                {
                    anamsinh = txtNgaythu.Value.Year.ToString();
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
                    amaql=decimal.Parse(m_maql).ToString();
                }
                catch
                {
                    amaql="";
                }
                try
                {
                    amavaovien=decimal.Parse(m_mavaovien).ToString();
                }
                catch
                {
                    amavaovien="";
                }
                try
                {
                    aidkhoa = decimal.Parse(m_idkhoa).ToString();
                }
                catch
                {
                    aidkhoa = "0";
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
                #region lưu bn mới
                if (m_bnmoi || v_chuyenchidinhCLS)
                {
                    try
                    {
                        string m_khongdau = m_v.f_khongdau(ahoten);
                        if (v_NamBTDBN.IndexOf(m_v.get_mmyy(angay) + "+") == -1) v_NamBTDBN = v_NamBTDBN + m_v.get_mmyy(angay) + "+";
                        //Luu hanh chanh
                        if (!m_v.upd_btdbn(amabn, ahoten, txtNgaysinh.Text, anamsinh, decimal.Parse(cbGioitinh.SelectedValue.ToString()), mann.Text.Trim(), madantoc.Text.Trim(), txtSonha.Text.Trim(), txtThonpho.Text.Trim(), txtNoilamviec.Text.Trim(), cbTinh.SelectedValue.ToString(), cbQuan.SelectedValue.ToString(), cbXa.SelectedValue.ToString(), -decimal.Parse(auserid), v_NamBTDBN, m_khongdau))
                        {
                            amabn = "";
                        }
                        if (manuoc.Enabled && manuoc.Text != "") m_v.upd_nuocngoai(amabn, manuoc.Text);
                        else m_v.execute_data("delete from medibv.nuocngoai where mabn='" + amabn + "'");
                    }
                    catch
                    {
                        amabn = "";
                    }
                    if (amabn == "")
                    {
                        butLuu.Enabled = true;
                        MessageBox.Show(this, "Không cập nhật được thông tin bệnh nhân!\nChưa lưu hoá đơn!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (bVPCapstt) m_dshoadon = capIdPhongCLS(m_dshoadon);
                string v_maql_TD = amavaovien == "" ? "0" : amavaovien;// "";
                if (v_maql_TD == "0")
                {
                    try
                    {
                        v_maql_TD = m_v.get_data_mmyy(ammyy, "select maql from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0, 10) + "'").Tables[0].Rows[0]["maql"].ToString();
                    }
                    catch
                    {
                        v_maql_TD = "0";
                    }
                }
                if (v_maql_TD == "0")
                {
                    try
                    {
                        amaql = m_v.upd_tiepdon(amabn, 0, 0, amakp_ll, angay, decimal.Parse(cbDoituongTD.SelectedValue.ToString()), "0000000000", txtTuoi.Text.PadLeft(4, '0'), 1, 7, 0, -decimal.Parse(auserid)).ToString();
                    }
                    catch
                    {
                    }
                }
                if (amaql == "" || amaql == "0")
                {
                    amaql = v_maql_TD;
                }
                if (amaql == "" || amaql == "0")
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Không cập nhật được thông tin tiếp đón! \n Chưa lưu hoá đơn!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (amavaovien == "")
                {
                    amavaovien = amaql;
                }
                #endregion
                #region
                if (aid != "0")
                {
                    m_v.upd_eve_tables(ammyy, itableds, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itableds, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ammyy + ".v_ttrvds", "id=" + aid));
                    m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ammyy + ".v_ttrvll", "id=" + aid));
                    foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvct where id=" + aid + "").Tables[0].Rows)
                    {
                        m_v.upd_eve_tables(ammyy, itable, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itable, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ammyy + ".v_ttrvct", "id=" + aid + " and stt=" + int.Parse(r1["stt"].ToString())));
                    }
                    foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_miennoitru where id=" + aid + "").Tables[0].Rows)
                    {
                        m_v.upd_eve_tables(ammyy, itablemien, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablemien, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ammyy + ".v_miennoitru", "id=" + aid));
                    }
                }
                #endregion

                if (toolStrip_Tongcong.Text == toolStrip_BHYT.Text && !b_bhyt_100_noitru_theodoibienlai) asobienlai = f_Get_SoBienLai_Am();
                else   asobienlai = txtSobienlai.Text.Trim();

                if (aid != "0")
                {
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvct where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvbhyt where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvnhom where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_miennoitru where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvpttt where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvptttct where id = " + aid);
                }
                decimal asotient = 0, asotien = 0, atamung = 0, abhyt = 0, athieu = 0, athua = 0, anopthem = 0, abvtrathua = 0, avatutu = 0, amien = 0, achenhlech = 0, aidtonghop = 0;
                try
                {
                    asotien = decimal.Parse(txtCongCP.Text.Replace(",", ""));
                }
                catch
                {
                    asotien = 0; 
                }
                try
                {
                    atamung = decimal.Parse(txtTamung.Text.Replace(",", ""));
                }
                catch
                {
                    atamung = 0;
                }
                try
                {
                    asotient = decimal.Parse(txtGDDuyet.Text.Replace(",", ""));
                }
                catch
                {
                    asotient = 0;
                }
                amien += asotient;
                try
                {
                    asotient = decimal.Parse(txtMienDT.Text.Replace(",", ""));
                }
                catch
                {
                    asotient = 0;
                }
                amien += asotient;

                try
                {
                    abhyt = decimal.Parse(txtMienBHYT.Text.Replace(",", ""));
                }
                catch
                {
                    abhyt = 0;
                }
                try
                {
                    athieu = decimal.Parse(txtBNThieu.Text.Replace(",", ""));
                }
                catch
                {
                    athieu = 0;
                }
                try
                {
                    achenhlech = decimal.Parse(txtChenhlech.Text.Replace(",", ""));
                }
                catch
                {
                    achenhlech = 0;
                }

                try
                {
                    athua = decimal.Parse(txtthua.Text.Replace(",", ""));
                }
                catch
                {
                    athua = 0;
                }
                try
                {
                    abvtrathua = decimal.Parse(txtBVtraNo.Text.Replace(",", ""));
                }
                catch
                {
                    abvtrathua = 0;
                }

                try
                {
                    anopthem = decimal.Parse(txtBNtraNO.Text.Replace(",", ""));
                }
                catch
                {
                    anopthem = 0;
                }
                aidtonghop = 0;
                try
                {
                    aidtonghop=decimal.Parse(m_id_thvpll);
                }
                catch
                {
                    aidtonghop=0;
                }

                string agiuong = "", s_angayrv = "";
                try
                {                   
                    if (txtNgayrv.Text.Length < 16)
                        s_angayrv = txtNgayrv.Text.Trim().Substring(0, 10) + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Second;
                    else
                        s_angayrv = txtNgayrv.Text.Trim().Substring(0,16);
                }
                catch
                {
                    s_angayrv = txtNgayrv.Text.Trim().Substring(0, 10) + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Second;                
                }
                //binh 12/10/09   
                if (cbNgayrv.Items.Count > 0)
                {
                    CurrencyManager cm1 = (CurrencyManager)(BindingContext[cbNgayrv.DataSource]);
                    DataView dv1 = (DataView)(cm1.List);
                    DataRow dr1 = m_v.getrowbyid(dv1.Table, "id=" + aidtonghop);
                    if (dr1 != null)
                    {
                        if (amaql != dr1["maql"].ToString())
                        {
                            amaql = dr1["maql"].ToString();
                            aidkhoa = dr1["idkhoa"].ToString();
                            cbKhoarv.SelectedValue = dr1["makp"].ToString();
                        }
                    }
                }
                //Thuy 31.05.2012 cập nhật ngàyvv trong v_ttrvds nếu bn được chuyển từ phòng lưu vào nội trú thì ngày vv trong v_ttrvds phải lấy từ ngày vào phòng lưu.
                string ngayvv = "";
                DataRow r_mavv = m_v.getrowbyid(m_v.get_data_mmyy(ammyy, "select mavaovien,to_char(ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao from medibvmmyy.v_thvpll where mabn=" + amabn + "").Tables[0], "mavaovien=" + amavaovien);
                if (r_mavv != null)
                {
                    ngayvv = r_mavv["ngayvao"].ToString().Substring(0, 16);
                }
                else
                {
                    //ngayvv = cbNgayvv.Text;//cbNgayvv.Text.Substring(0, 16);
                    //ngayvv = DateTime.Now.Date.ToString().Substring(0, 16);
                    ngayvv = DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                }
                aid = m_v.upd_v_ttrvds(ammyy, decimal.Parse(aid), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), agiuong,
                   ngayvv, s_angayrv, txtChandoan.Text.Trim().Trim('-').Trim('+').Trim('-').Trim('+'),
                   txtICD.Text.Trim('-').Trim('+').Trim('-').Trim('+'));
                if (aid == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this, lan.Change_language_MessageText("Lỗi lưu dữ liệu!") + "\n" + lan.Change_language_MessageText("Chưa lưu dược hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (chkChuahoan.Checked)
                {
                    try
                    {
                        anopthem = decimal.Parse(txtPhaithu.Text.Replace(",", ""));
                    }
                    catch
                    {
                        anopthem = 0;
                    }
                }
                if (v_Quanglythatthuno)
                {
                    if (chkBNthieu.Checked)
                    {
                        aquyenso = lbl_quyensothatthu.Text.Trim();
                        asobienlai = lbl_SBLthatthu.Text.Trim();
                    }
                    if (chkBNThua.Checked)
                    {
                        aquyenso = lbl_quyensothua.Text.Trim();
                        asobienlai = lbl_SBLthua.Text.Trim();
                    }
                }
                quyensodv = sobienlaidv = "";
                if (v_Quanglydichvu)
                {
                    quyensodv = lbl_quyensodichvu.Text.Trim();
                    sobienlaidv = lbl_SBLdichvu.Text.Trim();
                }//alinh 21.04.2012
                m_v.upd_v_ttrvll(ammyy, decimal.Parse(aid), decimal.Parse(aloaibn), decimal.Parse(aloai), decimal.Parse(aquyenso), decimal.Parse(asobienlai),
                    angay, cbKhoarv.SelectedValue.ToString(), asotien, atamung, amien, abhyt, athieu, anopthem, achenhlech, avatutu, athua, aidtonghop,
                    decimal.Parse(m_userid), (quyensodv != "") ? decimal.Parse(quyensodv) : 0, (sobienlaidv != "") ? decimal.Parse(sobienlaidv) : 0, 
                    i_tylechinhsach, int.Parse(cbDoituongTD.SelectedValue.ToString()),decimal.Parse(txtGDDuyet.Text));
                ///quản lý BN thiếu
                if (athieu > 0) 
                {
                    m_v.upd_v_ttrvthatthu(decimal.Parse(aid), decimal.Parse(aloai), decimal.Parse(aquyenso), decimal.Parse(asobienlai), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), cbNgayvv.Text.Substring(0, 16), s_angayrv, angay, athieu, 0, decimal.Parse(m_userid), 0, 0, "");
                }
                if (anopthem > 0) 
                {
                    m_v.execute_data("update medibv.v_ttrvthatthu set idttrv=" + aid + " where id=" + m_id_ttrvthatthu + "");
                }
                //Quản lý bn thừa
                if (athua > 0) 
                {
                    m_v.upd_v_ttrvthua(decimal.Parse(aid), decimal.Parse(aloai), decimal.Parse(aquyenso), decimal.Parse(asobienlai), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), cbNgayvv.Text.Substring(0, 16), s_angayrv, angay, athua, 0, decimal.Parse(m_userid), 0, 0, "");
                }
                if (abvtrathua > 0) 
                {
                    m_v.execute_data("update medibv.v_ttrvthua set idttrv=" + aid + " where id=" + m_id_ttrvthua + "");
                }
                //end thua, thieu
                int amaphu = 0;
                string asothe = "", atungay = "", adenngay = "", amanoidk = "";

                asothe = txtSothe.Text.Trim();
                atungay = txtTN.Text.Trim();
                adenngay = txtDN.Text.Trim();
                amanoidk=txtNDK_Ma.Text.Trim();

                if (asothe != "")
                {
                    int bhyt_tu = int.Parse(s_bhyt_vitri.Split(',')[0].ToString());
                    int bhyt_den = int.Parse(s_bhyt_vitri.Split(',')[1].ToString());
                    if (asothe.Length >= (bhyt_tu + 1))
                    {
                        if (s_bhyt_kytu.ToString().IndexOf(asothe.Substring(bhyt_tu - 1, bhyt_den) + "+") >= 0)
                            amaphu = 1;
                    }
                }
                //
                try
                {
                    m_v.upd_v_ttrvbhyt(ammyy, decimal.Parse(aid), asothe, amaphu, (adenngay.Length >= 10) ? adenngay.Substring(0, 10) : "", atungay.Length >= 10 ? atungay.Substring(0, 10) : "", amanoidk, amanoidk,cmbTraituyen.SelectedIndex);
                }
                catch (Exception ex)
                {
                    m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "upd_v_ttrvbhyt_BHYT_f_LUU");
                }

                if (!v_Quanglydichvu)
                {
                    if (toolStrip_Tongcong.Text != toolStrip_BHYT.Text)
                        m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                    else
                        m_v.execute_data("update medibv.v_quyenso set soghiam=" + decimal.Parse(asobienlai) + " where id=" + decimal.Parse(aquyenso));
                }
                if (toolStrip_Mien.Text.Trim() != "0" && aid!="0")
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
                    m_v.upd_v_miennoitru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien),lan.Change_language_MessageText("Miển giảm thu chi ra viện"), decimal.Parse(amaduyet));
                }
                aidcd = ",";
                aidchidinh = ",";
                amadoiutongct = ",";
                amakpct = "'";
                if (aid != "0")
                {
                    //v_ttrvct
                    decimal astt = 1,gia_bh=0;
                    DataRow r0;
                    bool bHoadondv = false,bHoadon=false;
                    s_id_captoa = ",";
                    try
                    {
                        m_dshoadon.WriteXml("C:\\dshoadon.xml");
                    }
                    catch { }
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            if (r["stttonghop"].ToString() != "" && r["idtonghop"].ToString() != "" && r["idtonghop"].ToString() != "0" && s_id_captoa.IndexOf("," + r["idtonghop"].ToString() + ",") < 0) s_id_captoa += r["idtonghop"].ToString() + ",";
                            gia_bh = 0;
                            decimal agiamua = 0;
                            r0 = m_v.getrowbyid(dtdm, "id=" + decimal.Parse(r["mavp"].ToString()));
                            if (r0 != null) gia_bh = decimal.Parse(r0["gia_bh"].ToString());
                            if (decimal.Parse(r["dongia"].ToString()) == decimal.Parse(r["giamua"].ToString()))
                            {
                                agiamua = 0;
                            }
                            else
                            {
                                agiamua = decimal.Parse(r["giamua"].ToString());
                            }

                            string idktcao = r["id_ktcao"].ToString();
                            if (idktcao == "" || idktcao == null) idktcao = "0";
                             bln_ct = m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), astt, r["ngay"].ToString(), r["makp"].ToString(), decimal.Parse(r["madoituong"].ToString()), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vat"].ToString()), decimal.Parse(r["vattu"].ToString()), decimal.Parse(r["sotien"].ToString()), agiamua, decimal.Parse(r["bhyttra"].ToString()), gia_bh, r["mabs"].ToString(), r["idtonghop"].ToString() == "" ? 0 : decimal.Parse(r["idtonghop"].ToString()), r["stttonghop"].ToString() == "" ? 0 : int.Parse(r["stttonghop"].ToString()));
                            if (r["id_ktcao"].ToString() != "0")
                            {
                                m_v.execute_data("update " + m_v.user + ammyy + ".v_ttrvct set ktcao=1,id_ktcao=" + idktcao + " where id=" + decimal.Parse(aid) + " and mavp=" + decimal.Parse(r["mavp"].ToString()) + " and stt=" + astt);
                            }
                            //if (bln_ct == false)
                            //{
                            //    m_v.modify_tables_vp_mmyy(ammyy);
                            //    bln_ct = m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), astt, r["ngay"].ToString(), r["makp"].ToString(), decimal.Parse(r["madoituong"].ToString()), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vat"].ToString()), decimal.Parse(r["vattu"].ToString()), decimal.Parse(r["sotien"].ToString()), agiamua, decimal.Parse(r["bhyttra"].ToString()), gia_bh);
                            //}
                            if (v_Quanglydichvu)
                            {
                                r0 = m_v.getrowbyid(dtdv, "id=" + decimal.Parse(r["mavp"].ToString()));
                                if (r0 != null)
                                {
                                    m_v.upd_v_ttrvct("v_ttrvdv", ammyy, decimal.Parse(aid), astt, r["ngay"].ToString(), r["makp"].ToString(), decimal.Parse(r["madoituong"].ToString()), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vat"].ToString()), decimal.Parse(r["vattu"].ToString()), decimal.Parse(r["sotien"].ToString()), agiamua, decimal.Parse(r["bhyttra"].ToString()), gia_bh, r["mabs"].ToString(), decimal.Parse(r["idtonghop"].ToString()), int.Parse(r["stttonghop"].ToString()));
                                    bHoadondv = true;
                                }
                                else bHoadon = true;
                            }
                            astt += 1;
                            if (aidcd.IndexOf("," + r["mavp"].ToString() + ",") == -1) aidcd += r["mavp"].ToString() + ",";
                            if (r["idchidinh"].ToString() != "0" && aidchidinh.IndexOf("," + r["idchidinh"].ToString() + ",") == -1) aidchidinh += r["idchidinh"].ToString() + ",";
                            if (amadoiutongct.IndexOf("," + r["madoituong"].ToString() + ",") == -1) amadoiutongct += r["madoituong"].ToString() + ",";
                            if (amakpct.IndexOf("'"+r["makp"].ToString()+"'")==-1) amakpct += r["makp"].ToString() + "','";
                            //Update thu tien thuoc phu thu
                            if (v_phuthu_capphatle_bhytnoitru)
                            {
                                string sql = "update medibvmmyy.d_tienthuoc set datra=" + decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()) + " where mabn='" + amabn + "' and maql=" + amaql + " and madoituong=1 and mabd=" + decimal.Parse(r["mavp"].ToString()) + " and id =" + decimal.Parse(r["idchidinh"].ToString());
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), angay.Substring(0, 10), sql);
                            }
                        }
                        catch(Exception ex)
                        {
                            m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "Luu v_ttrvct_TTRV");
                        }
                    }
                    if (bHoadon && bHoadondv && quyensodv == aquyenso)
                    {
                        m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                        lbl_SBLdichvu.Text = f_Get_Sobienlai_thatthu(m_cur_quyenso_dichvu).Split(':')[0];
                        lbl_quyensodichvu.Text = m_cur_quyenso_dichvu;
                        quyensodv = lbl_quyensodichvu.Text.Trim();
                        sobienlaidv = lbl_SBLdichvu.Text.Trim();
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set sobienlaidv=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                    }
                    if (bHoadondv) m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                    else if (v_Quanglydichvu && bHoadon)
                    {
                        if (toolStrip_Tongcong.Text != toolStrip_BHYT.Text)
                            m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                        else
                            m_v.execute_data("update medibv.v_quyenso set soghiam=" + decimal.Parse(asobienlai) + " where id=" + decimal.Parse(aquyenso));
                    }
                    if (v_Quanglydichvu && bHoadondv && !bHoadon) m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set quyenso=" + decimal.Parse(quyensodv) + ",sobienlai=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                    aidcd = aidcd.Trim().Trim(',');// (aidcd != "") ? aidcd.Substring(0, aidcd.Length - 1) : "";
                    aidchidinh = aidchidinh.Trim().Trim(',');// (aidchidinh != "") ? aidchidinh.Substring(0, aidchidinh.Length - 1) : "";                    
                    amadoiutongct = amadoiutongct.Trim().Trim(',');// (amadoiutongct != "") ? amadoiutongct.Substring(0, amadoiutongct.Length - 1) : "";
                    amakpct = (amakpct.Length > 1) ? amakpct.Substring(0, amakpct.Length - 2) : "";
                    //v_ttrvctnhom
                    foreach (Control c in m_table.Controls)
                    {
                        if (c.Name.IndexOf("tbma_") == 0 && c.Text!="")
                        {
                            m_v.upd_v_ttrvnhom(ammyy, decimal.Parse(aid), decimal.Parse(c.Name.Replace("tbma_", "")), decimal.Parse(c.Text.Replace(",", "")));
                        }
                    }
                    //xuat vien
                    if (amaql != "")
                    {
                        m_v.execute_data("update medibv.xuatvien set paid=1 where mabn='" + amabn + "' and maql=" + amaql);
                    }
                    //v_tamung: paid,idttrv
                    string ammyytu="";
                    bool bHoantra_blai_tamung = m_v.bThuchiravien_hoantra_bienlaitamung(m_userid);
                    foreach (DataRow r in m_dstamung.Tables[0].Select("chon=1"))
                    {                        
                        ammyytu = m_v.get_mmyy(r["ngay"].ToString());
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_tontamung set done=1, idttrv=" + aid + ",ngaytra=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') where id=" + r["id"].ToString());
                        m_v.execute_data_mmyy(ammyytu, "update medibvmmyy.v_tamung set done=1, idttrv=" + aid + ",ngaytra=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') where id=" + r["id"].ToString());
                        m_v.execute_data("update medibv.v_tamung set done=1, idttrv=" + aid + " ,useridtt=" + m_userid + ",ngaytt=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy'),ngaytra=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') where id=" + r["id"].ToString());
                        if (bHoantra_blai_tamung)
                        {
                            m_v.upd_v_hoantra(ammyy, decimal.Parse(r["id"].ToString()), decimal.Parse(r["quyenso"].ToString()), decimal.Parse(r["sobienlai"].ToString()), angay.Substring(0, 10), angay.Substring(0, 10), amabn, decimal.Parse(m_mavaovien), decimal.Parse(m_maql), txtHoten.Text, r["makp"].ToString(), decimal.Parse(r["sotien"].ToString()), "TTRV", decimal.Parse(m_userid), 1, decimal.Parse(aloaibn));
                        }
                    }
                    //Done
                    if (aidcd != "")
                    {
                        if (tmn_Thuchidinh.Checked)
                        {
                            if (s_mavp_huy.Trim(',') != "")
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + " and id not in(" + s_mavp_huy.Trim(',') + ") and mavp in (" + aidcd + ")"); ;
                            }
                            else
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + "  and mavp in (" + aidcd + ") and id in (" + aidchidinh + ")");
                            }
                        }
                        if (tmn_Vienphikhoa.Checked)
                        {
                            if (s_mavp_huy.Trim(',') != "")
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + "  and id not in(" + s_mavp_huy.Trim(',') + ") and mavp in (" + aidcd + ")");
                            }
                            else
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + " and mavp in (" + aidcd + ") and id in (" + aidchidinh + ")");
                            }
                        }
                        if (tmn_Toathuoctutruc.Checked)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.d_ngtruct set paid=1,idttrv=" + aid + " where id in(select id from medibvmmyy.d_ngtrull where mabn='" + amabn + "' and  maql=" + amaql + ") and mabd in(" + aidcd + ")");
                        }
                        if (tmn_Thuocthuongquy.Checked)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + " and mabd in (" + aidcd + ") and madoituong in (" + amadoiutongct + ") and id in(" + aidchidinh + ")");
                            //binh 130511
                            try
                            {
                                if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                    m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                            }
                            catch { }
                        }
                        if (tmn_Toachove.Checked)
                        {
                            if (s_id_captoa.Trim().Trim(',') == "") s_id_captoa = "";
                            if (s_id_captoa.Trim().Trim(',') == "")
                            {
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set quyenso=" + aquyenso + ",sobienlai=" + asobienlai + " where mabn='" + amabn + "' and maql in(" + s_maql_captoa + ")");// and maql in(" + amaql + "");
                            }
                            else
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.bhytkb set quyenso=" + aquyenso + ",sobienlai=" + asobienlai + " where mabn='" + amabn + "' and id in(" + s_id_captoa.Trim().Trim(',') + ")");// and maql in(" + s_maql_captoa + ")");// and maql in(" + amaql + "");
                            }
                        }
                        if (tmn_Khoatonghop.Checked)
                        {
                            string ngay = m_v.ngayhienhanh_server.Substring(0, 10);// txtNgayrv.Text.Substring(0, 10)
                            if (tmn_thanhtoantheokhoa.Checked || v_thanhtoannhieudot_trongkhoa)
                            {
                                string stime="'dd/mm/yyyy'",tu=cbNgayvv.Text.Substring(0,10),den = txtNgayrv.Text.Substring(0, 10);
                                if (cbNgayrv.SelectedIndex != -1)
                                {
                                    tu = cbNgayrv.Text.Substring(0, 10);
                                    den = cbNgayrv.Text.Substring(14,10).Trim();
                                }
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid + " where id=" + m_id_thvpll + " and mabn='" + amabn + "'");
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where  mabn='" + amabn + "' and id=" + m_id_thvpll + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10),ngay, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid + " where id=" + m_id_thvpll + " and mabn='" + amabn + "'");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10),ngay, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where  mabn='" + amabn + "' and id=" + m_id_thvpll + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");                                
                                if (m_idthuoc != "" && m_idthuoc.Trim().Length>2)
                                {
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where makp in(select id from medibv.d_duockp where makp in(" + amakpct.Trim(',') + ")) and id in(" + m_idthuoc.Trim().Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and paid=0 and mavp in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + "  and madoituong in (" + amadoiutongct + ") and done=0 and mavp in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                                else 
                                {
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where makp in(select id from medibv.d_duockp where makp in(" + amakpct.Trim(',') + ")) and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + "  and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql);
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql);
                                //m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where mabn='" + amabn + "' and maql=" + amaql + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");

                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and  mabn='" + amabn + "' and maql=" + amaql + "  and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where makp in(select id from medibv.d_duockp where makp in(" + amakpct.Trim(',') + ")) and mabn='" + amabn + "' and maql=" + amaql + "  and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                //binh 130511
                                try
                                {
                                    if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                        m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                }
                                catch { }
                            }
                        }
                        if (bCapve_noitru)
                        {
                            string s_maql = m_v.get_maql_phongkham(cbNgayvv.Text.Substring(0, 10), decimal.Parse(amaql));
                            if (cbLoaibn.SelectedValue.ToString() == "2") s_maql += "," + m_v.get_maql_ngoaitru(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), decimal.Parse(amaql)).Trim().Trim(',');
                            if (s_maql != "")
                            {
                                if (m_idthuoc != "")
                                {
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where id in(" + m_idthuoc.Trim().Trim(',') + ") and mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ") and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ") and madoituong in (" + amadoiutongct + ") and id in(" + m_idthuoc.Trim().Trim(',') + ") and mavp in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ")  and madoituong in (" + amadoiutongct + ") and id in(" + m_idthuoc.Trim().Trim(',') + ") and mavp in (" + aidcd + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                                else
                                {
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ") and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ")  and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                            }
                        }
                        //Update chi phi cap cuu
                        if (bCapcuu_Noitru)
                        {
                            l_maql_phongluu = m_v.get_maql_phongluu(cbNgayvv.Text.Substring(0, 10), decimal.Parse(amaql));
                            if (l_maql_phongluu != 0)
                            {
                                if (m_idthuoc != "")
                                {
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where id in(" + m_idthuoc.Trim().Trim(',') + ") and mabn='" + amabn + "' and maql=" + l_maql_phongluu + " and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + " and madoituong in (" + amadoiutongct + ") and id in(" + m_idthuoc.Trim().Trim(',') + ") and mavp in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + "  and madoituong in (" + amadoiutongct + ") and id in(" + m_idthuoc.Trim().Trim(',') + ") and mavp in (" + aidcd + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                                else
                                {
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + " and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + " and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + "  and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                            }
                        }
                        //End
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
                    try
                    {
                        if(m_v.get_data("select maql from medibv.dasuamadt where maql="+amaql).Tables[0].Rows.Count<=0)
                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                    }
                    catch { }
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
                            else  f_Inhoadon();
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
                            else   f_Inhoadon();
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
                            else   f_Inchiphi();
                        }
                    }
                    butMoi.Focus();
                }
            }
            catch (Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Luu");
            }
        }
        private int capSttCho(int idphong, int idloai)
        {
            if (idphong == 0) return 0;
            else
            {
                string angay = txtNgaythu.Text.Substring(0, 10);
                string ammyy = m_v.get_mmyy(angay);
                string sql = "select count(*) from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.dmphongthuchiencls c ";
                sql += "on b.id_loai=c.id_loaivp where c.id=" + idphong + " and c.id_loaivp=" + idloai + " and to_char(ngay,'dd/mm/yyyy')='" + angay + "'";
                DataTable dt = m_v.get_data_mmyy(ammyy, sql).Tables[0];// gam 17-06-2011
                if (dt.Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return (int.Parse(dt.Rows[0][0].ToString()) + 1);
                }
            }
        }
        private DataSet capIdPhongCLS(DataSet dsHoadonct)
        {
            DataSet ds1 = new DataSet();
            ds1 = dsHoadonct.Copy();
            ds1.Clear();
            string[] sidphong = { "0" };
            string sphong = "";
            int min = 0, k = 0, tam = 0;
            foreach (DataRow r in dsHoadonct.Tables[0].Rows)
            {
                DataRow r2 = ds1.Tables[0].NewRow();
                try
                {
                    sidphong = (r["phongthuchiencls"].ToString() == "" ? "0" : r["phongthuchiencls"].ToString()).Split(',');
                    sphong = r["phongthuchiencls"].ToString() == "" ? "0" : r["phongthuchiencls"].ToString();
                    r2["id"] = r["id"].ToString();
                    r2["chon"] = r["chon"].ToString();
                    r2["ngaycd"] = r["ngaycd"].ToString();
                    r2["mavp"] = r["mavp"].ToString();
                    r2["ma"] = r["ma"].ToString();
                    r2["ten"] = r["ten"].ToString();
                    r2["dvt"] = r["dvt"].ToString();
                    r2["soluong"] = r["soluong"].ToString();
                    r2["dongia"] = r["dongia"].ToString();
                    r2["thanhtien"] = r["thanhtien"].ToString();
                    r2["thucthu"] = r["thucthu"].ToString();
                    r2["madoituong"] = r["madoituong"].ToString();
                    r2["doituong"] = r["doituong"].ToString();
                    r2["makp"] = r["makp"].ToString();
                    r2["tenkp"] = r["tenkp"].ToString();
                    r2["mabs"] = r["mabs"].ToString();
                    r2["tenbs"] = r["tenbs"].ToString();
                    r2["idcd"] = r["idcd"].ToString();
                    r2["id_loai"] = r["id_loai"].ToString();
                    r2["id_nhom"] = r["id_nhom"].ToString();
                    r2["dichvu"] = r["dichvu"].ToString();
                    r2["mien"] = r["mien"].ToString();
                    r2["phongthuchiencls"] = r["phongthuchiencls"].ToString() == "" ? "0" : r["phongthuchiencls"].ToString();

                }
                catch { }
                if (sidphong.Length == 1 || sidphong[0] == "0") // neu phong thuc hien chi co 1 phong hoac do la tien thuoc thi gan maphongcls=phongthuchiencls va sttcho
                {
                    try
                    {
                        r2["maphongcls"] = sphong;
                        r2["sttcho"] = capSttCho(int.Parse(sidphong[0]), int.Parse(r["id_loai"].ToString() == "" ? "0" : r["id_loai"].ToString()));
                        ds1.Tables[0].Rows.Add(r2);
                    }
                    catch (Exception ex) { }
                }
                else // neu 1 chi dinh co tren 2 phong thuc hien thi kiem tra 
                {
                    // neu bn co lam dv tai 1 trong những phòng này thì ưu tiên cho bn thuc hien tai phong nay va lay sttcho
                    if (ds1.Tables[0].Select("maphongcls in (" + sphong + ")").Length > 0)
                    {
                        foreach (DataRow r1 in ds1.Tables[0].Select("maphongcls in (" + sphong + ")"))
                        {
                            r2["maphongcls"] = r1["maphongcls"].ToString();
                            r2["sttcho"] = capSttCho(int.Parse(r1["maphongcls"].ToString()), int.Parse(r["id_loai"].ToString() == "" ? "0" : r["id_loai"].ToString()));
                            ds1.Tables[0].Rows.Add(r2);
                            break;
                        }
                    }
                    else
                    {
                        // neu bn khong lam lam dv ca hai phong nay thi lay sttcho cua 2 phong neu sttcho nao nho nhất 
                        //thì gán maphong thực hiện là phòng có stt chờ nhỏ nhất
                        min = capSttCho(int.Parse(sidphong[0]), int.Parse(r["id_loai"].ToString() == "" ? "0" : r["id_loai"].ToString()));
                        for (int j = 1; j < sidphong.Length; j++)
                        {
                            tam = capSttCho(int.Parse(sidphong[j]), int.Parse(r["id_loai"].ToString() == "" ? "0" : r["id_loai"].ToString()));
                            if (tam < min)
                            {
                                k = j;
                                min = tam;
                            }
                        }
                        r2["maphongcls"] = sidphong[k];
                        r2["sttcho"] = min;
                        ds1.Tables[0].Rows.Add(r2);
                    }
                }
            }
            return ds1;
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
            if (toolStrip_Mien.Text != "0" && tmn_Nhaplydomien.Checked && cbLydomien.SelectedIndex <= 0)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập lý do miễn giảm!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLydomien.Focus();
                SendKeys.Send("{F4}");
                return false;
            }
            if (toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập người duyệt miễn giảm!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbKymien.Focus();
                SendKeys.Send("{F4}");
                return false;
            }
            if (txtNgayrv.Text == "")
            {
                txtNgayrv.Text = txtNgaythu.Text.Substring(0, 16);
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập ngày ra viện!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgayrv.Focus();
                return false;
            }
            if (cbKhoarv.SelectedIndex < 0)
            {
                f_FullScreen(false);
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập khoa ra viện!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbKhoarv.Focus();
                SendKeys.Send("{F4}");
                return false;
            }
            return true;
        }
        private void f_Luu(bool v_hoadondv)
        {
            bool bln_ct = true;
            try
            {
                if (m_dshoadon.Tables[0].Rows.Count <= 0)
                    return;
                bool asua = (m_id != "" && m_id != "0");
                string atmp = "", aidcd = ",", aidchidinh = ",", amadoiutongct = "", amakpct = "";
                butLuu.Enabled = false;
                if (v_hoadondv)
                {
                    txtSobienlai.Text = f_Get_Sobienlai(s_quyenso_dichvu).Split(':')[0];
                    cbKyhieu.SelectedValue = s_quyenso_dichvu;
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
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "", amaql = "", aidkhoa = "", amakp = "", aloai = "", aloaibn = "", auserid = "";
                angay = txtNgaythu.Text.Substring(0, 16);
                ammyy = m_v.get_mmyy(angay);
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
                try
                {
                    string s_sobienlai = m_v.get_data("select den from medibv.v_quyenso where id=" + cbKyhieu.SelectedValue.ToString() + "").Tables[0].Rows[0]["den"].ToString();
                    if (decimal.Parse(txtSobienlai.Text.Trim()) > decimal.Parse(s_sobienlai))
                    {
                        butLuu.Enabled = true;
                        MessageBox.Show(lan.Change_language_MessageText("Số biên lai nhập") + " " + txtSobienlai.Text.Trim() + " " + lan.Change_language_MessageText("không được lớn hơn số biên đã khai") + " " + s_sobienlai + " !" + "\n" + lan.Change_language_MessageText("Vui lòng nhập lại số biên lai nhỏ hơn hoặc bằng") + " " + s_sobienlai + ".", m_v.s_AppName);
                        label31.Enabled = true;
                        txtSobienlai.Focus();
                        return;
                    }
                }
                catch
                {
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
                    amakp = cbKhoarv.SelectedValue.ToString();
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
                try
                {
                    aidkhoa = decimal.Parse(m_idkhoa).ToString();
                }
                catch
                {
                    aidkhoa = "0";
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
                #region
                if (aid != "0")
                {
                    m_v.upd_eve_tables(ammyy, itableds, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itableds, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ammyy + ".v_ttrvds", "id=" + aid));
                    m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ammyy + ".v_ttrvll", "id=" + aid));
                    foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvct where id=" + aid + "").Tables[0].Rows)
                    {
                        m_v.upd_eve_tables(ammyy, itable, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itable, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ammyy + ".v_ttrvct", "id=" + aid + " and stt=" + int.Parse(r1["stt"].ToString())));
                    }
                    foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_miennoitru where id=" + aid + "").Tables[0].Rows)
                    {
                        m_v.upd_eve_tables(ammyy, itablemien, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablemien, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ammyy + ".v_miennoitru", "id=" + aid));
                    }
                }
                #endregion

                if (toolStrip_Tongcong.Text == toolStrip_BHYT.Text && !b_bhyt_100_noitru_theodoibienlai) asobienlai = f_Get_SoBienLai_Am();
                else asobienlai = txtSobienlai.Text.Trim();

                if (aid != "0")
                {
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvct where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvbhyt where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvnhom where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_miennoitru where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvpttt where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_ttrvptttct where id = " + aid);
                }
                decimal asotient = 0, asotien = 0, atamung = 0, abhyt = 0, athieu = 0, athua = 0, anopthem = 0, abvtrathua = 0, avatutu = 0, amien = 0, achenhlech = 0, aidtonghop = 0;
                try
                {
                    asotien = decimal.Parse(txtCongCP.Text.Replace(",", ""));
                }
                catch
                {
                    asotien = 0;
                }
                try
                {
                    atamung = decimal.Parse(txtTamung.Text.Replace(",", ""));
                }
                catch
                {
                    atamung = 0;
                }
                try
                {
                    asotient = decimal.Parse(txtGDDuyet.Text.Replace(",", ""));
                }
                catch
                {
                    asotient = 0;
                }
                amien += asotient;
                try
                {
                    asotient = decimal.Parse(txtMienDT.Text.Replace(",", ""));
                }
                catch
                {
                    asotient = 0;
                }
                amien += asotient;

                try
                {
                    abhyt = decimal.Parse(txtMienBHYT.Text.Replace(",", ""));
                }
                catch
                {
                    abhyt = 0;
                }
                try
                {
                    athieu = decimal.Parse(txtBNThieu.Text.Replace(",", ""));
                }
                catch
                {
                    athieu = 0;
                }
                try
                {
                    achenhlech = decimal.Parse(txtChenhlech.Text.Replace(",", ""));
                }
                catch
                {
                    achenhlech = 0;
                }

                try
                {
                    athua = decimal.Parse(txtthua.Text.Replace(",", ""));
                }
                catch
                {
                    athua = 0;
                }
                try
                {
                    abvtrathua = decimal.Parse(txtBVtraNo.Text.Replace(",", ""));
                }
                catch
                {
                    abvtrathua = 0;
                }

                try
                {
                    anopthem = decimal.Parse(txtBNtraNO.Text.Replace(",", ""));
                }
                catch
                {
                    anopthem = 0;
                }
                aidtonghop = 0;
                try
                {
                    aidtonghop = decimal.Parse(m_id_thvpll);
                }
                catch
                {
                    aidtonghop = 0;
                }

                string agiuong = "", s_angayrv = "";
                try
                {
                    if (txtNgayrv.Text.Length < 16)
                        s_angayrv = txtNgayrv.Text.Trim().Substring(0, 10) + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Second;
                    else
                        s_angayrv = txtNgayrv.Text.Trim().Substring(0, 16);
                }
                catch
                {
                    s_angayrv = txtNgayrv.Text.Trim().Substring(0, 10) + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Second;
                }
                //binh 12/10/09   
                if (cbNgayrv.Items.Count > 0)
                {
                    CurrencyManager cm1 = (CurrencyManager)(BindingContext[cbNgayrv.DataSource]);
                    DataView dv1 = (DataView)(cm1.List);
                    DataRow dr1 = m_v.getrowbyid(dv1.Table, "id=" + aidtonghop);
                    if (dr1 != null)
                    {
                        if (amaql != dr1["maql"].ToString())
                        {
                            amaql = dr1["maql"].ToString();
                            aidkhoa = dr1["idkhoa"].ToString();
                            cbKhoarv.SelectedValue = dr1["makp"].ToString();
                        }
                    }
                }
                //
                aid = m_v.upd_v_ttrvds(ammyy, decimal.Parse(aid), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), agiuong, 
                    cbNgayvv.Text.Substring(0, 16), s_angayrv, txtChandoan.Text.Trim().Trim('-').Trim('+').Trim('-').Trim('+'),
                    txtICD.Text.Trim('-').Trim('+').Trim('-').Trim('+'));
                if (aid == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this, lan.Change_language_MessageText("Lỗi lưu dữ liệu!") + "\n" + lan.Change_language_MessageText("Chưa lưu dược hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (chkChuahoan.Checked)
                {
                    try
                    {
                        anopthem = decimal.Parse(txtPhaithu.Text.Replace(",", ""));
                    }
                    catch
                    {
                        anopthem = 0;
                    }
                }
                if (v_Quanglythatthuno)
                {
                    if (chkBNthieu.Checked)
                    {
                        aquyenso = lbl_quyensothatthu.Text.Trim();
                        asobienlai = lbl_SBLthatthu.Text.Trim();
                    }
                    if (chkBNThua.Checked)
                    {
                        aquyenso = lbl_quyensothua.Text.Trim();
                        asobienlai = lbl_SBLthua.Text.Trim();
                    }
                }
                quyensodv = sobienlaidv = "";
                if (v_Quanglydichvu)
                {
                    quyensodv = lbl_quyensodichvu.Text.Trim();
                    sobienlaidv = lbl_SBLdichvu.Text.Trim();
                }
                m_v.upd_v_ttrvll(ammyy, decimal.Parse(aid), decimal.Parse(aloaibn), decimal.Parse(aloai), decimal.Parse(aquyenso), decimal.Parse(asobienlai),
                    angay, cbKhoarv.SelectedValue.ToString(), asotien, atamung, amien, abhyt, athieu, anopthem, achenhlech, avatutu, athua, aidtonghop, 
                    decimal.Parse(m_userid), (quyensodv != "") ? decimal.Parse(quyensodv) : 0, (sobienlaidv != "") ? decimal.Parse(sobienlaidv) : 0,
                    i_tylechinhsach,int.Parse(cbDoituongTD.SelectedValue.ToString()),decimal.Parse(txtGDDuyet.Text));
                ///quản lý BN thiếu
                if (athieu > 0)
                {
                    m_v.upd_v_ttrvthatthu(decimal.Parse(aid), decimal.Parse(aloai), decimal.Parse(aquyenso), decimal.Parse(asobienlai), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), cbNgayvv.Text.Substring(0, 16), s_angayrv, angay, athieu, 0, decimal.Parse(m_userid), 0, 0, "");
                }
                if (anopthem > 0)
                {
                    m_v.execute_data("update medibv.v_ttrvthatthu set idttrv=" + aid + " where id=" + m_id_ttrvthatthu + "");
                }
                //Quản lý bn thừa
                if (athua > 0)
                {
                    m_v.upd_v_ttrvthua(decimal.Parse(aid), decimal.Parse(aloai), decimal.Parse(aquyenso), decimal.Parse(asobienlai), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), cbNgayvv.Text.Substring(0, 16), s_angayrv, angay, athua, 0, decimal.Parse(m_userid), 0, 0, "");
                }
                if (abvtrathua > 0)
                {
                    m_v.execute_data("update medibv.v_ttrvthua set idttrv=" + aid + " where id=" + m_id_ttrvthua + "");
                }
                //end thua, thieu
                int amaphu = 0;
                string asothe = "", atungay = "", adenngay = "", amanoidk = "";

                asothe = txtSothe.Text.Trim();
                atungay = txtTN.Text.Trim();
                adenngay = txtDN.Text;
                amanoidk = txtNDK_Ma.Text.Trim();

                if (asothe != "")
                {
                    int bhyt_tu = int.Parse(s_bhyt_vitri.Split(',')[0].ToString());
                    int bhyt_den = int.Parse(s_bhyt_vitri.Split(',')[1].ToString());
                    if (asothe.Length >= (bhyt_tu + 1))
                    {
                        if (s_bhyt_kytu.ToString().IndexOf(asothe.Substring(bhyt_tu - 1, bhyt_den) + "+") >= 0)
                            amaphu = 1;
                    }
                }
                //
                try
                {
                    m_v.upd_v_ttrvbhyt(ammyy, decimal.Parse(aid), asothe, amaphu, (adenngay.Length >= 10) ? adenngay.Substring(0, 10) : "", atungay.Length >= 10 ? atungay.Substring(0, 10) : "", amanoidk, amanoidk, cmbTraituyen.SelectedIndex);
                }
                catch (Exception ex)
                {
                    m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "upd_v_ttrvbhyt_BHYT_f_LUU");
                }

                if (!v_Quanglydichvu)
                {
                    if (toolStrip_Tongcong.Text != toolStrip_BHYT.Text)
                        m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                    else
                        m_v.execute_data("update medibv.v_quyenso set soghiam=" + decimal.Parse(asobienlai) + " where id=" + decimal.Parse(aquyenso));
                }
                if (toolStrip_Mien.Text.Trim() != "0" && aid != "0")
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
                    if (!b_luumien)
                    {
                        m_v.upd_v_miennoitru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien), lan.Change_language_MessageText("Miển giảm thu chi ra viện"), decimal.Parse(amaduyet));
                        b_luumien = true;
                    }
                }
                aidcd = ",";
                aidchidinh = ",";
                amadoiutongct = ",";
                amakpct = "'";
                if (aid != "0")
                {
                    //v_ttrvct
                    decimal astt = 1, gia_bh = 0;
                    DataRow r0;
                    bool bHoadondv = false, bHoadon = false;
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            gia_bh = 0;
                            decimal agiamua = 0;
                            r0 = m_v.getrowbyid(dtdm, "id=" + decimal.Parse(r["mavp"].ToString()));
                            if (r0 != null) gia_bh = decimal.Parse(r0["gia_bh"].ToString());
                            if (decimal.Parse(r["dongia"].ToString()) == decimal.Parse(r["giamua"].ToString()))
                                agiamua = 0;
                            else
                                agiamua = decimal.Parse(r["giamua"].ToString());

                            bln_ct = m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), astt, r["ngay"].ToString(), r["makp"].ToString(), decimal.Parse(r["madoituong"].ToString()), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vat"].ToString()), decimal.Parse(r["vattu"].ToString()), decimal.Parse(r["sotien"].ToString()), agiamua, decimal.Parse(r["bhyttra"].ToString()), gia_bh, r["mabs"].ToString(), decimal.Parse(r["idtonghop"].ToString()), int.Parse(r["stttonghop"].ToString()));
                            if (bln_ct == false)
                            {
                                m_v.modify_tables_vp_mmyy(ammyy);
                                bln_ct = m_v.upd_v_ttrvct("v_ttrvct", ammyy, decimal.Parse(aid), astt, r["ngay"].ToString(), r["makp"].ToString(), decimal.Parse(r["madoituong"].ToString()), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vat"].ToString()), decimal.Parse(r["vattu"].ToString()), decimal.Parse(r["sotien"].ToString()), agiamua, decimal.Parse(r["bhyttra"].ToString()), gia_bh, r["mabs"].ToString(),decimal.Parse(r["idtonghop"].ToString()),int.Parse(r["stttonghop"].ToString()));
                            }
                            if (v_Quanglydichvu)
                            {
                                r0 = m_v.getrowbyid(dtdv, "id=" + decimal.Parse(r["mavp"].ToString()));
                                if (r0 != null)
                                {
                                    m_v.upd_v_ttrvct("v_ttrvdv", ammyy, decimal.Parse(aid), astt, r["ngay"].ToString(), r["makp"].ToString(), decimal.Parse(r["madoituong"].ToString()), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vat"].ToString()), decimal.Parse(r["vattu"].ToString()), decimal.Parse(r["sotien"].ToString()), agiamua, decimal.Parse(r["bhyttra"].ToString()), gia_bh, r["mabs"].ToString(), decimal.Parse(r["idtonghop"].ToString()), int.Parse(r["stttonghop"].ToString()));
                                    bHoadondv = true;
                                }
                                else bHoadon = true;
                            }
                            astt += 1;
                            if (aidcd.IndexOf("," + r["mavp"].ToString() + ",") == -1) aidcd += r["mavp"].ToString() + ",";
                            if (aidchidinh.IndexOf("," + r["idchidinh"].ToString() + ",") == -1) aidchidinh += r["idchidinh"].ToString() + ",";
                            if (amadoiutongct.IndexOf("," + r["madoituong"].ToString() + ",") == -1) amadoiutongct += r["madoituong"].ToString() + ",";
                            if (amakpct.IndexOf("'" + r["makp"].ToString() + "'") == -1) amakpct += r["makp"].ToString() + "','";
                            //Update thu tien thuoc phu thu
                            if (v_phuthu_capphatle_bhytnoitru)
                            {
                                string sql = "update medibvmmyy.d_tienthuoc set datra=" + decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString()) + " where mabn='" + amabn + "' and maql=" + amaql + " and madoituong=1 and mabd=" + decimal.Parse(r["mavp"].ToString()) + " and id =" + decimal.Parse(r["idchidinh"].ToString());
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), angay.Substring(0, 10), sql);
                            }
                        }
                        catch (Exception ex)
                        {
                            m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "Luu v_ttrvct_TTRV");
                        }
                    }
                    if (bHoadon && bHoadondv && quyensodv == aquyenso)
                    {
                        m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                        lbl_SBLdichvu.Text = f_Get_Sobienlai_thatthu(m_cur_quyenso_dichvu).Split(':')[0];
                        lbl_quyensodichvu.Text = m_cur_quyenso_dichvu;
                        quyensodv = lbl_quyensodichvu.Text.Trim();
                        sobienlaidv = lbl_SBLdichvu.Text.Trim();
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set sobienlaidv=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                    }
                    if (bHoadondv) m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                    else if (v_Quanglydichvu && bHoadon)
                    {
                        if (toolStrip_Tongcong.Text != toolStrip_BHYT.Text)
                            m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                        else
                            m_v.execute_data("update medibv.v_quyenso set soghiam=" + decimal.Parse(asobienlai) + " where id=" + decimal.Parse(aquyenso));
                    }
                    if (v_Quanglydichvu && bHoadondv && !bHoadon) m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvll set quyenso=" + decimal.Parse(quyensodv) + ",sobienlai=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                    aidcd = aidcd.Trim().Trim(',');// (aidcd != "") ? aidcd.Substring(0, aidcd.Length - 1) : "";
                    aidchidinh = aidchidinh.Trim().Trim(',');// (aidchidinh != "") ? aidchidinh.Substring(0, aidchidinh.Length - 1) : "";                    
                    amadoiutongct = amadoiutongct.Trim().Trim(',');// (amadoiutongct != "") ? amadoiutongct.Substring(0, amadoiutongct.Length - 1) : "";
                    amakpct = (amakpct.Length > 1) ? amakpct.Substring(0, amakpct.Length - 2) : "";
                    //v_ttrvctnhom
                    foreach (Control c in m_table.Controls)
                    {
                        if (c.Name.IndexOf("tbma_") == 0 && c.Text != "")
                        {
                            m_v.upd_v_ttrvnhom(ammyy, decimal.Parse(aid), decimal.Parse(c.Name.Replace("tbma_", "")), decimal.Parse(c.Text.Replace(",", "")));
                        }
                    }
                    //xuat vien
                    if (amaql != "")
                    {
                        m_v.execute_data("update medibv.xuatvien set paid=1 where mabn='" + amabn + "' and maql=" + amaql);
                    }
                    //v_tamung: paid,idttrv
                    string ammyytu = "";
                    bool bHoantra_blai_tamung = m_v.bThuchiravien_hoantra_bienlaitamung(m_userid);
                    foreach (DataRow r in m_dstamung.Tables[0].Select("chon=1"))
                    {
                        ammyytu = m_v.get_mmyy(r["ngay"].ToString());
                        m_v.execute_data("update medibv.v_tamung set done=1, idttrv=" + aid + ",ngaytra=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy'),ngaytt=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy'),useridtt="+m_userid+" where id=" + r["id"].ToString());
                        m_v.execute_data_mmyy(ammyytu, "update medibvmmyy.v_tamung set done=1, idttrv=" + aid + ",ngaytra=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') where id=" + r["id"].ToString());
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_tontamung set done=1, idttrv=" + aid + ",ngaytra=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') where id=" + r["id"].ToString());
                        if (bHoantra_blai_tamung)
                        {
                            m_v.upd_v_hoantra(ammyy, decimal.Parse(r["id"].ToString()), decimal.Parse(r["quyenso"].ToString()), decimal.Parse(r["sobienlai"].ToString()), angay.Substring(0, 10), angay.Substring(0, 10), amabn, decimal.Parse(m_mavaovien), decimal.Parse(m_maql), txtHoten.Text, r["makp"].ToString(), decimal.Parse(r["sotien"].ToString()), "TTRV", decimal.Parse(m_userid), 1, decimal.Parse(aloaibn));
                        }
                        r["chon"] = 0;
                    }
                    //m_dstamung.Clear();
                    //Done
                    if (aidcd != "")
                    {
                        if (tmn_Thuchidinh.Checked)
                        {
                            if (s_mavp_huy.Trim(',') != "")
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + " and id not in(" + s_mavp_huy.Trim(',') + ") and mavp in (" + aidcd + ")"); ;
                            }
                            else
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + "  and mavp in (" + aidcd + ") and id in (" + aidchidinh + ")");
                            }
                        }
                        if (tmn_Vienphikhoa.Checked)
                        {
                            if (s_mavp_huy.Trim(',') != "")
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + "  and id not in(" + s_mavp_huy.Trim(',') + ") and mavp in (" + aidcd + ")");
                            }
                            else
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + " and mavp in (" + aidcd + ") and id in (" + aidchidinh + ")");
                            }
                        }
                        if (tmn_Toathuoctutruc.Checked)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.d_ngtruct set paid=1,idttrv=" + aid + " where id in(select id from medibvmmyy.d_ngtrull where mabn='" + amabn + "' and  maql=" + amaql + ") and mabd in(" + aidcd + ")");
                        }
                        if (tmn_Thuocthuongquy.Checked)
                        {
                            m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql + " and mabd in (" + aidcd + ") and madoituong in (" + amadoiutongct + ") and id in(" + aidchidinh + ")");
                            //binh 130511
                            try
                            {
                                if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                    m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                            }
                            catch { }
                        }
                        if (tmn_Toachove.Checked)
                        {
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.bhytkb set quyenso=" + aquyenso + ",sobienlai=" + asobienlai + " where mabn='" + amabn + "' and maql in(" + s_maql_captoa + ")");// and maql in(" + amaql + "");
                        }
                        if (tmn_Khoatonghop.Checked)
                        {
                            string ngay = m_v.ngayhienhanh_server.Substring(0, 10);// txtNgayrv.Text.Substring(0, 10)
                            if (tmn_thanhtoantheokhoa.Checked || v_thanhtoannhieudot_trongkhoa)
                            {
                                string stime = "'dd/mm/yyyy'", tu = cbNgayvv.Text.Substring(0, 10), den = txtNgayrv.Text.Substring(0, 10);
                                if (cbNgayrv.SelectedIndex != -1)
                                {
                                    tu = cbNgayrv.Text.Substring(0, 10);
                                    den = cbNgayrv.Text.Substring(14, 10).Trim();
                                }
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid + " where id=" + m_id_thvpll + " and mabn='" + amabn + "'");
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where  mabn='" + amabn + "' and id=" + m_id_thvpll + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid + " where id=" + m_id_thvpll + " and mabn='" + amabn + "'");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where  mabn='" + amabn + "' and id=" + m_id_thvpll + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                if (m_idthuoc != "" && m_idthuoc.Trim().Length > 2)
                                {
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where makp in(select id from medibv.d_duockp where makp in(" + amakpct.Trim(',') + ")) and id in(" + m_idthuoc.Trim().Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and paid=0 and mavp in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + "  and madoituong in (" + amadoiutongct + ") and done=0 and mavp in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                                else
                                {
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where makp in(select id from medibv.d_duockp where makp in(" + amakpct.Trim(',') + ")) and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + "  and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ") and " + for_ngay("ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql);
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_thvpll set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + amaql);
                                //m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_thvpct set done=1,idttrv=" + aid + " where id in (select id from medibvmmyy.v_thvpll where mabn='" + amabn + "' and maql=" + amaql + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");

                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and mabn='" + amabn + "' and maql=" + amaql + " and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where makp in(" + amakpct.Trim(',') + ") and  mabn='" + amabn + "' and maql=" + amaql + "  and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), ngay, "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where makp in(select id from medibv.d_duockp where makp in(" + amakpct.Trim(',') + ")) and mabn='" + amabn + "' and maql=" + amaql + "  and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                //binh 130511
                                try
                                {
                                    if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                        m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                }
                                catch { }
                            }
                        }
                        if (bCapve_noitru)
                        {
                            string s_maql = m_v.get_maql_phongkham(cbNgayvv.Text.Substring(0, 10), decimal.Parse(amaql));
                            if (cbLoaibn.SelectedValue.ToString() == "2") s_maql += "," + m_v.get_maql_ngoaitru(cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), decimal.Parse(amaql)).Trim().Trim(',');
                            if (s_maql != "")
                            {
                                if (m_idthuoc != "")
                                {
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where id in(" + m_idthuoc.Trim().Trim(',') + ") and mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ") and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ") and madoituong in (" + amadoiutongct + ") and id in(" + m_idthuoc.Trim().Trim(',') + ") and mavp in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ")  and madoituong in (" + amadoiutongct + ") and id in(" + m_idthuoc.Trim().Trim(',') + ") and mavp in (" + aidcd + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                                else
                                {
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ") and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ") and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ")  and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                            }
                        }
                        //Update chi phi cap cuu
                        if (bCapcuu_Noitru)
                        {
                            l_maql_phongluu = m_v.get_maql_phongluu(cbNgayvv.Text.Substring(0, 10), decimal.Parse(amaql));
                            if (l_maql_phongluu != 0)
                            {
                                if (m_idthuoc != "")
                                {
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where id in(" + m_idthuoc.Trim().Trim(',') + ") and mabn='" + amabn + "' and maql=" + l_maql_phongluu + " and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + " and madoituong in (" + amadoiutongct + ") and id in(" + m_idthuoc.Trim().Trim(',') + ") and mavp in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + "  and madoituong in (" + amadoiutongct + ") and id in(" + m_idthuoc.Trim().Trim(',') + ") and mavp in (" + aidcd + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                                else
                                {
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + " and madoituong in (" + amadoiutongct + ") and mabd in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_chidinh set paid=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + " and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(cbNgayvv.Text.Substring(0, 10)).AddMonths(-iSothang)), cbNgayvv.Text.Substring(0, 10), "update medibvmmyy.v_vpkhoa set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and maql=" + l_maql_phongluu + "  and madoituong in (" + amadoiutongct + ") and mavp in (" + aidcd + ")");
                                    //binh 130511
                                    try
                                    {
                                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                                    }
                                    catch { }
                                }
                            }
                        }
                        //End
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
                    try
                    {
                        if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                            m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                    }
                    catch { }
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
                                    f_Inhoadon(v_hoadondv);
                                }
                            }
                            else f_Inhoadon(v_hoadondv);
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
                            else f_Inhoadon(v_hoadondv);
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
                            else f_Inchiphi();
                        }
                    }
                    butMoi.Focus();
                }
            }
            catch (Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Luu");
            }
        }

        public string for_ngay(string ngay, string time)
        {
            return "to_date(to_char(" + ngay + ", " + time + "), " + time + ")";
        }

        private void f_Sua()
        {
            try
            {
                if (m_v.ttrv_suahoadon(m_userid))
                {
                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép sửa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        m_dshoadon_nhomvp = null;
                        f_Enable(true);
                        f_Enable_HC(false);
                        txtTenvp.Focus();
                        b_sua = true;
                        b_luumien = false;
                        dgGia.Visible = false;
                        txtMabn.Enabled = false ;
                        txtMabn1.Enabled = false;
                        tmn_Danhsachcho.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {
            }
        }
        private void f_Xoa()
        {
            try
            {
                
                if (m_v.ttrv_xoahoadon(m_userid))
                {
                    string ammyy = txtNgaythu.Value.Month.ToString().PadLeft(2, '0') + txtNgaythu.Value.Year.ToString().Substring(2);
                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql,(cbKyhieu.SelectedIndex!=-1)? cbKyhieu.SelectedValue.ToString():"", txtSobienlai.Text,(cbLoaidv.SelectedIndex!=-1)? cbLoaidv.SelectedValue.ToString():"",(cbLoaibn.SelectedIndex!=-1)? cbLoaibn.SelectedValue.ToString():""))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép xoá."), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Nếu xoá xem như hoá đơn chưa phát sinh, sẽ không có trong báo cáo") + "\n" + lan.Change_language_MessageText("Nếu hoàn xem như hoá đơn đã phát sinh và không có giá trị sử dụng, có trong báo cáo hoàn.") + "\n" + lan.Change_language_MessageText("Đồng ý xoá hoá đơn này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {

                            #region

                            if (m_id != "0")
                            {
                                foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvct where id=" + m_id + "").Tables[0].Rows)
                                {
                                    string s = m_v.fields(m_v.user + ammyy + ".v_ttrvct", "id=" + m_id + " and stt=" + int.Parse(r1["stt"].ToString()));
                                    m_v.upd_eve_tables(ammyy, itable, int.Parse(m_userid), "del");
                                    m_v.upd_eve_upd_del(ammyy, itable, int.Parse(m_userid), "del", s);
                                }
                                if (v_Quanglydichvu) m_v.execute_data_mmyy(ammyy,"delete from medibvmmyy.v_ttrvdv where id=" + m_id + "");
                            }                                                     
                           
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".v_ttrvds", "id=" + m_id);
                                m_v.upd_eve_tables(ammyy, itableds, int.Parse(m_userid), "del");
                                m_v.upd_eve_upd_del(ammyy, itableds, int.Parse(m_userid), "del", s);
                            }                            
                           
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".v_ttrvll", "id=" + m_id);
                                m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "del");
                                m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "del", s);
                            }                            
                            
                            if (m_id != "0")
                            {
                                foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_miennoitru where id=" + m_id + "").Tables[0].Rows)
                                {
                                    string s = m_v.fields(m_v.user + ammyy + ".v_miennoitru", "id=" + m_id);
                                    m_v.upd_eve_tables(ammyy, itablemien, int.Parse(m_userid), "del");
                                    m_v.upd_eve_upd_del(ammyy, itablemien, int.Parse(m_userid), "del", s);
                                }
                            }
                            #endregion

                            string s_ngayhuyblai = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');//binh

                            if (MessageBox.Show(this, "Có muốn hoá đơn đã xoá này có trong báo cáo hoá đơn đã dùng không ?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                m_v.upd_huybienlai(ammyy, decimal.Parse(m_id), "v_ttrvll", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text, txtKhoarv.Text, s_ngayhuyblai, decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text.Trim()), "Hủy biên lai thanh toán ra viện", int.Parse(m_userid), (toolStrip_Thucthu.Text.Trim() == "") ? 0 : decimal.Parse(toolStrip_Thucthu.Text));
                            }
                            else
                            {
                                m_v.upd_huybienlai(ammyy, decimal.Parse(m_id), "v_ttrvll", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text, txtKhoarv.Text, s_ngayhuyblai, decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text.Trim()), "Hủy biên lai thanh toán ra viện", int.Parse(m_userid), (toolStrip_Thucthu.Text.Trim() == "") ? 0 : decimal.Parse(toolStrip_Thucthu.Text));
                            }
                        
                            if (v_phuthu_capphatle_bhytnoitru)
                            {
                                foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvct where id=" + m_id + "").Tables[0].Rows)
                                {
                                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.d_tienthuoc set datra=0 where madoituong=1 and mabn='" + txtMabn.Text + txtMabn1.Text + "' and maql=" + m_maql + " and mabd=" + int.Parse(r1["mavp"].ToString()));
                                }
                            }

                            m_v.del_v_ttrvll(ammyy,cbNgayvv.Text.Substring(0,10),txtNgayrv.Text.Substring(0,10), m_id, txtMabn.Text + txtMabn1.Text, cbNgayvv.SelectedValue.ToString(), txtKhoarv.Text,v_doituongthu);

                            //Thuy 10.08.2012
                            //v_tamung: paid,idttrv,ngaytra
                            string ammyytu = "";
                            foreach (DataRow r in m_dstamung.Tables[0].Select("chon=1"))
                            {
                                ammyytu = m_v.get_mmyy(r["ngay"].ToString());
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_tontamung set done=0, idttrv=0,ngaytra=null where id=" + r["id"].ToString());
                                m_v.execute_data_mmyy(ammyytu, "update medibvmmyy.v_tamung set done=0, idttrv=0,ngaytra=null where id=" + r["id"].ToString());
                                m_v.execute_data("update medibv.v_tamung set done=0, idttrv=0 ,useridtt=0,ngaytt=null,ngaytra=null where id=" + r["id"].ToString());
                            }
                        
                            f_Load_Thutrongngay();
                            f_Clear_HC();
                            m_dshoadon.Tables[0].Rows.Clear();
                            m_dstamung.Tables[0].Rows.Clear();
                            f_Clear_pTonghop();
                            f_Tinhtien();
                            f_Enable(false);
                            f_Enable_HC(false);
                            butMoi.Focus();
                        }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền xóa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void f_inhoadondichvu()
        {                                                
            string _mmyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
            decimal st1,st2,bh1,bh2;
            sql = "select d.id_nhom,b.madoituong,sum(b.sotien) as sotien";
            sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id";
            sql += " inner join medibv.v_giavp c on b.mavp=c.id ";
            sql += " inner join medibv.v_loaivp d on c.id_loai=d.id";
            sql += " inner join medibv.doituong e on b.madoituong=e.madoituong";
            sql += " where a.id=" + m_id + " and (b.madoituong=1 or e.mien=0)";
            sql += " group by d.id_nhom,b.madoituong";
            sql += " union all ";
            sql += "select d.nhomvp as id_nhom,b.madoituong,sum(b.sotien) as sotien";
            sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id";
            sql += " inner join medibv.d_dmbd c on b.mavp=c.id ";
            sql += " inner join medibv.d_dmnhom d on c.manhom=d.id";
            sql += " inner join medibv.doituong e on b.madoituong=e.madoituong";
            sql += " where a.id=" + m_id + " and (b.madoituong=1 or e.mien=0)";
            sql += " group by d.nhomvp,b.madoituong";
            DataTable tmp = m_v.get_data_mmyy(_mmyy, sql).Tables[0];
            st1 =st2=bh1=bh2 = 0;
            int maphu = (txtSothe.Text!="")?d.get_maphu_noitru(txtSothe.Text, 0):0,chitra;
            foreach (DataRow r in tmp.Select("true","id_nhom,madoituong"))
            {
                if (ttrv_bienlai_dichvu.IndexOf(r["id_nhom"].ToString().PadLeft(3, '0')) != -1)
                {
                    if (txtSothe.Text != "" && int.Parse(r["madoituong"].ToString()) == 1)
                    {
                        if (maphu != 0)
                        {
                            chitra = (maphu == 1) ? 80 : 95;
                            bh1 += decimal.Parse(r["sotien"].ToString()) * chitra / 100;
                            st1 += decimal.Parse(r["sotien"].ToString()) - (decimal.Parse(r["sotien"].ToString()) * chitra / 100);
                        }
                    }
                    else st1 += decimal.Parse(r["sotien"].ToString());
                }
                else
                {
                    if (txtSothe.Text != "" && int.Parse(r["madoituong"].ToString()) == 1)
                    {
                        if (maphu != 0)
                        {
                            chitra = (maphu == 1) ? 80 : 95;
                            bh2 += decimal.Parse(r["sotien"].ToString()) * chitra / 100;
                            st2 += decimal.Parse(r["sotien"].ToString()) - (decimal.Parse(r["sotien"].ToString()) * chitra / 100);
                        }
                    }
                    else st2 += decimal.Parse(r["sotien"].ToString());
                }
            }

            sql = "select b.mabn, a.sobienlai, a.sotien as tongcp,";
            sql+=" (a.sotien-a.bhyt-a.mien-a.thieu+a.nopthem) as sotien ,";
            sql+=" 0 as tamung,0 as mien, 0 as thieu, 0 as bhyt , 0 as nopthem,";
            sql+=" to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh,";
            sql+=" e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu,";
            sql+="j.hoten as nguoithu, i.sohieu as quyenso, l.ten as lydomien,a.lanin+1 as lanin,0 as thua,a.sobienlaidv ";
            sql+= " from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id ";
            sql+=" left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn ";
            sql+=" left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt ";
            sql+=" left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa ";
            sql+=" left join medibv.v_quyenso i on a.quyenso=i.id ";
            sql+=" left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id ";
            sql+=" left join medibv.v_lydomien l on k.lydo=l.id ";
            sql+=" where a.id=" + m_id + "";
            DataSet dst= m_v.get_data_mmyy(_mmyy, sql);

            if (dst.Tables[0].Rows.Count > 0)
            {
                if (st2 != 0)
                {
                    dst.Tables[0].Rows[0]["sotien"] = st2;
                    dst.Tables[0].Rows[0]["bhyt"] = bh2;
                    m_frmprinthd.f_Print_BienlaiNT(!tmn_Xemtruockhiin_Icon.Checked, dst, "Thu viện phí");
                }
                if (st1 != 0)
                {
                    dst.Tables[0].Rows[0]["sotien"] = st1;
                    dst.Tables[0].Rows[0]["bhyt"] = bh1;
                    dst.Tables[0].Rows[0]["sobienlai"] = dst.Tables[0].Rows[0]["sobienlaidv"];
                    m_frmprinthd.f_Print_BienlaiNT(!tmn_Xemtruockhiin_Icon.Checked, dst, "Thu tiền thuốc");
                }
                if (st1 != 0 || st2 != 0) m_v.execute_data_mmyy(_mmyy, "update medibvmmyy.v_ttrvll set lanin=lanin+1 where id=" + m_id);
            }
        }
        private void f_Inhoadon()
        {
            try
            {
                if (m_id != "")
                {
                    string s = m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "select lanin from medibvmmyy.v_ttrvll where id=" + m_id + "").Tables[0].Rows[0]["lanin"].ToString();
                    if (decimal.Parse(v_solanin) > decimal.Parse(s))
                    {

                        if (v_Quanglydichvu) f_inhoadondichvu();
                        else
                        {
                            if (TTRV_HDChitiet.Checked)
                            {
                                m_frmprinthd.f_Print_Bienlai_ThuongNT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
                            }

                            if (TTRV_HDDacthu.Checked)
                            {
                                if (chkThuong.Checked)
                                {
                                    m_frmprinthd.f_Print_BienlaiNT_Thuong(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
                                }
                                else
                                {
                                    m_frmprinthd.f_Print_BienlaiNT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", cbNgayrv.Text,txtSothe.Text,cmbTraituyen.SelectedIndex);
                                }
                            }
                            if (!TTRV_HDChitiet.Checked && !TTRV_HDDacthu.Checked)
                            {
                                if (chkThuong.Checked)
                                {
                                    m_frmprinthd.f_Print_BienlaiNT_Thuong(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
                                }
                                else
                                {
                                    m_frmprinthd.f_Print_BienlaiNT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", cbNgayrv.Text);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Số lần in " + s + " vượt quá số lần in quy định " + v_solanin + " !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Inhoadon(bool bhddichvu)
        {
            try
            {
                if (m_id != "")
                {
                    string s = m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "select lanin from medibvmmyy.v_ttrvll where id=" + m_id + "").Tables[0].Rows[0]["lanin"].ToString();
                    if (decimal.Parse(v_solanin) > decimal.Parse(s))
                    {

                        if (v_Quanglydichvu) f_inhoadondichvu();
                        else
                        {
                            if (TTRV_HDChitiet.Checked)
                            {
                                m_frmprinthd.f_Print_Bienlai_ThuongNT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1",bhddichvu);
                            }
                            if (TTRV_HDDacthu.Checked)
                            {
                                if (chkThuong.Checked)
                                {
                                    m_frmprinthd.f_Print_BienlaiNT_Thuong(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1",bhddichvu);
                                }
                                else
                                {
                                    m_frmprinthd.f_Print_BienlaiNT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", cbNgayrv.Text, txtSothe.Text, cmbTraituyen.SelectedIndex,bhddichvu);
                                }
                            }
                            //if (TTRV_PhieuTTVP.Checked)
                            //{
                            //    m_frmprinthd.f_Print_Bienlai_ThuongNT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "2", bhddichvu);
                            //}
                            if (!TTRV_HDChitiet.Checked && !TTRV_HDDacthu.Checked && !TTRV_PhieuTTVP.Checked)
                            {
                                if (chkThuong.Checked)
                                {
                                    m_frmprinthd.f_Print_BienlaiNT_Thuong(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1",bhddichvu);
                                }
                                else
                                {
                                    m_frmprinthd.f_Print_BienlaiNT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", cbNgayrv.Text,bhddichvu);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Số lần in " + s + " vượt quá số lần in quy định " + v_solanin + " !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
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
                    if (v_Quanglydichvu) f_inhoadondichvu();
                    else m_frmprinthd.f_Print_BienlaiNT_Thuchi(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
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
                if (tmn_InThanhToanRaVien.Checked)
                {
                    m_frmprinthd.f_Print_ChiphiTTRVNgtruCT_tenreport02(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, m_mavaovien, 0, txtNgaythu.Text.Substring(0, 10), "v_ttrv_mau02.rpt", false);
                }
                else
                {
                    m_frmprinthd.f_Print_ChiphiTTRVNoitruCT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)));
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
                frmHoantra m_frmhoantra = new frmHoantra(m_v, m_userid);
                m_frmhoantra.ShowInTaskbar = false;
                m_frmhoantra.s_loaihd = "1";
                if (m_id != "")
                {
                    m_frmhoantra.s_sohoadon = txtSobienlai.Text;
                    m_frmhoantra.s_ngay = txtNgaythu.Value;
                }
                m_frmhoantra.s_quyenso = cbKyhieu.SelectedValue.ToString();
                m_frmhoantra.s_ngaythu = txtNgaythu.Text.Substring(0, 10);
                m_frmhoantra.s_ngayhoan = m_v.f_ngay10(m_cur_ngay);
                m_frmhoantra.s_loaihd = m_v.s_loaiform_thuchiravien;
                m_frmhoantra.ShowDialog();
            }
            catch
            {
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
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgGia.DataSource,dgGia.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                if (dgGia.Visible == false && this.ActiveControl==txtTenvp)
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
                    aft = "loai like '%" + cbLoaidv.SelectedValue.ToString() + "%'";
                }
                if (!tmn_Dungchungso.Checked)
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
                string art = "0:2";
                bool bDasudung = false;
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" + cbKyhieu.SelectedValue.ToString()).Tables[0].Rows)
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
        private string f_Get_Sobienlai_thatthu(string v_quyenso)
        {
            try
            {
                string art = "0:2";
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" +v_quyenso).Tables[0].Rows)
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
        private void f_Get_Item()
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituong.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r = dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString())[0];
                DataRowView arv = (DataRowView)(dgGia.CurrentRow.DataBoundItem);
                m_id_gia = arv["id"].ToString();
                txtDongia.Text = arv[r["field_gia"].ToString().Trim()].ToString();
                txtDongia.ReadOnly = true;
                if (v_chophepsuagia && decimal.Parse(txtDongia.Text) == 0) txtDongia.ReadOnly = false;
                txtTenvp.Text = arv["ten"].ToString();
                f_Tinhtien_mon();
            }
            catch//(Exception ex)
            {
                m_id_gia = "";
            }
        }
        private void f_Add_Chon(string v_id)
        {
            if (cbKhoa.SelectedIndex < 0)
            {
                cbKhoa.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            if (cbDoituong.SelectedIndex < 0)
            {
                cbDoituong.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            if (v_id == "")
            {
                return;
            }
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituong.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r0 = dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString())[0];
                string adoituong = cbDoituong.SelectedValue.ToString();
                string afieldgia = r0["field_gia"].ToString().Trim();
                decimal adongia = 0, asoluong = 0, avat = 0, avattu = 0, asotien = 0;
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
                            avat = 0;
                            avattu = 0;
                            asotien = asoluong * adongia + (asoluong * adongia * avat) / 100 + asoluong * avattu + (asoluong * avattu * avat) / 100;
                        
                          
                            string aexp = "mavp=" + r1["id"].ToString() + " and madoituong=" + cbDoituong.SelectedValue.ToString() + " and makp='" + cbKhoa.SelectedValue.ToString() + "' and dongia=" + adongia.ToString() + " and ngay='" + txtNgaythu.Text.Substring(0, 10) + "'";
                            if (m_dshoadon.Tables[0].Select(aexp).Length <= 0)
                            {
                                DataRow r = m_dshoadon.Tables[0].NewRow();
                                r["ngay"] = txtNgaythu.Text.Substring(0, 10);
                                r["ma"] = r1["ma"].ToString();
                                r["ten"] = r1["ten"].ToString();
                                r["dvt"] = r1["dvt"].ToString();
                                r["soluong"] = asoluong;
                                r["dongia"] = adongia;
                                r["giamua"] = 0;
                                r["vat"] = avat;
                                r["vattu"] = avattu;
                                r["sotien"] = 0;
                                r["bhyttra"] = 0;
                                r["bntra"] = 0;
                                r["doituong"] = cbDoituong.Text.Trim();
                                r["tenkp"] = cbKhoa.Text.Trim();
                                r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                                r["madoituong"] = cbDoituong.SelectedValue.ToString();
                                r["mavp"] = r1["id"].ToString();
                                m_dshoadon.Tables[0].Rows.Add(r);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                f_Tinhtien();
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
                if (m_doituongmien.IndexOf("," + v_madoituong + ",") >= 0)
                {
                    if (v_madoituong == "1")
                    {
                        DataRow  dr1=m_v.getrowbyid(m_dsgiavp.Tables[0],"id=" + v_mavp);
                        if (dr1 != null)
                        {
                            if (dr1["kcct"].ToString() == "1")
                                bKhongcungchitra = true;

                            if (bKhongcungchitra) atyle = 1;
                            else
                            {
                                atyle = decimal.Parse(m_dsgiavp.Tables[0].Select("id=" + v_mavp)[0]["bhyt"].ToString());
                                atyle = atyle / 100;
                            }
                        }
                        else
                            atyle = 1;
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

        private decimal f_Get_Tyle_BHYT(string v_madoituong, string v_mavp, string v_sothe)
        {
            
            decimal atyle = 0;
            try
            {
                if (v_madoituong == "1")
                {
                    DataRow dr1 = m_v.getrowbyid(m_dsgiavp.Tables[0], "id=" + v_mavp);
                    if (dr1 != null)
                    {
                        if (dr1["sothe"].ToString().Trim() != "" && dr1["sothe"].ToString().Trim().IndexOf(v_sothe.Substring(iKytubegin_xet_chiphivanchuyen,ikytuend_xet_chiphivanchuyen)) >= 0)
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
        private void f_Add()
        {
            if (cbKhoa.SelectedIndex < 0)
            {
                cbKhoa.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            if (cbDoituong.SelectedIndex < 0)
            {
                cbDoituong.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            if (m_id_gia == "")
            {
                return;
            }
            try
            {
                decimal adongia = 0, asoluong = 0, avat = 0, avattu = 0, asotien = 0;
                try
                {
                    adongia = decimal.Parse(txtDongia.Text.Trim().Replace(",",""));
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
                }
                catch
                {
                    asoluong = 0;
                }
                avat = 0;
                avattu = 0;
                asotien = asoluong * adongia + (asoluong * adongia * avat) / 100 + asoluong * avattu + (asoluong * avattu * avat)/100;
                string aexp = "";
                try
                {
                    m_dshoadon.Tables[0].Columns.Add("idchidinh", typeof(decimal)).DefaultValue = 0;
                }
                catch { }
                try
                {
                    m_dshoadon.Tables[0].Columns.Add("idtonghop", typeof(decimal)).DefaultValue = 0;
                }
                catch { }
                try
                {
                    m_dshoadon.Tables[0].Columns.Add("stttonghop", typeof(decimal)).DefaultValue = 0;
                }
                catch { }


                try
                {
                    m_dshoadon.Tables[0].Columns.Add("mien_gdduyet", typeof(decimal)).DefaultValue = 0;
                }
                catch { }
                
                
                
                foreach (DataRow r0 in m_dsgiavp.Tables[0].Select("id=" + m_id_gia))
                {
                    aexp = "mavp=" + r0["id"].ToString() + " and madoituong=" + cbDoituong.SelectedValue.ToString() + " and makp='" + cbKhoa.SelectedValue.ToString() + "' and dongia=" + adongia.ToString() + " and ngay='" + txtNgaythu.Text.Substring(0, 10) + "'";
                    if (m_dshoadon.Tables[0].Select(aexp).Length <= 0)
                    {
                        DataRow r = m_dshoadon.Tables[0].NewRow();
                        r["ngay"] = txtNgaythu.Text.Substring(0, 10);
                        r["ma"] = r0["ma"].ToString();
                        r["ten"] = r0["ten"].ToString();
                        r["dvt"] = r0["dvt"].ToString();
                        r["soluong"] = asoluong;
                        r["dongia"] = adongia;
                        r["giamua"] = 0;
                        r["vat"] = avat;
                        r["vattu"] = avattu;
                        r["sotien"] = 0;
                        r["bhyttra"] = 0;
                        r["bntra"] = 0;
                        r["doituong"] = cbDoituong.Text.Trim();
                        r["tenkp"] = cbKhoa.Text.Trim();
                        r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                        r["madoituong"] = cbDoituong.SelectedValue.ToString();
                        r["mavp"] = r0["id"].ToString();
                        r["idchidinh"] = 0;
                        r["idtonghop"] = 0;
                        r["stttonghop"] = 0;
                        try { r["mabs"] = 0; }
                        catch { }
                        r["id_loai"] = 0;
                        r["mien_gdduyet"] = 0;
                        m_dshoadon.Tables[0].Rows.Add(r);
                    }
                }//m_dshoadon.Tables[0].Clear();
                dgHoadon.DataSource = m_dshoadon.Tables[0];
                f_Tinhtien();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Rem()
        {
            try
            {
                DataRowView drv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);

                try
                {
                    s_mavp_huy += drv["idchidinh"].ToString() + ",";
                }
                catch
                {
 
                }
                m_dshoadon.Tables[0].Rows.RemoveAt(dgHoadon.CurrentCell.RowIndex);
                m_dshoadon.AcceptChanges();
                f_Tinhtien();
            }
            catch
            {
            }
        }
        private void f_Tinhtien_mon()
        {
            try
            {
                decimal adongia = 0, asoluong = 0, amien = 0,athucthu=0;
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
                        asoluong = 0;
                    }
                }
                catch
                {
                    asoluong = 0;
                }
                athucthu = asoluong * adongia - amien;

                txtDongia.Text = adongia.ToString("###,###,##0.##").Trim();
                txtSoluong.Text = asoluong.ToString("###,###,##0.##").Trim();
            }
            catch
            {
            }
        }
        
        private void f_Tinhtien()
       {
            try
            {
                bool bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
                bool bTraituyen_bhtra = m.bTraituyen_bhtra;//true: trai tuyen tinh theo: ty le the * ty le trai tuyen
                
                foreach (DataRow r in m_dsnhomvp.Tables[0].Rows)
                {
                    r["sotien"] = 0;
                }              
                decimal asoluong = 0, adongia = 0, avat = 0, avattu = 0, asotien = 0, abhyt_bhtra = 0, abhyt_bntra = 0, abhyt_chenhlech = 0, atongbhyt = 0, atongbhyttra = 0, atongbntra = 0, atongchenhlech = 0, atongvp = 0, atongmienvp = 0;
                decimal atyle = 0;
                decimal d_cpvc = 0;//gam 15/08/2011 
                decimal amien = 0; //gam 11/10/2011
                bool TraiTuyenKhongTinhTyLe = false;//gam 14/02/2012 dung kiem tra neu chi phi tu ngay 16/02/2012 và có chọn option G92. thì gán biến = true => không tính tỷ lệ BHYT chi tra
                DataRow rct = null;
                //try { r1 = m_dsgiavp.Tables[0].Select("id='" + r["mavp"].ToString() + "'")[0]; }
                //catch { r1 = null; }
                ////	
                //if (r1 != null)
                //{
                //    dTyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString(), txtSothe.Text);
               
                foreach (DataRow rr in m_dshoadon.Tables[0].Rows)
                {
                    if (rr["id_ktcao"].ToString() == "")
                    {
                        rr["id_ktcao"] = "0";
                    }
                    if (rr["ktcao"].ToString() == "")
                    {
                        rr["ktcao"] = "0";
                    }
                }
                //Tinh ty le
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    decimal atmp = 0;
                    string loc_the = "";
                    try
                    {
                        if (r["madoituong"].ToString() == "1")
                        {
                            //ThanhCuong - 14/08/2012
                            try
                            {
                                if (decimal.Parse(r["id_ktcao"].ToString()) > 0)
                                {
                                    atmp = 0;
                                }
                                else
                                {
                                    atmp = decimal.Parse(decimal.Parse(r["soluong"].ToString()).ToString("###,###,##0.##")) * decimal.Parse(r["dongia"].ToString());
                                }
                            }
                            catch { atmp = 0; }
                        }
                        
                    }
                    catch
                    {
                        atmp = 0;
                    }
                    //gam 15/08/2011
                    try
                    {
                        rct = m_dsgiavp.Tables[0].Select("id='" + r["mavp"].ToString() + "'")[0];
                        if (rct != null )
                        {
                           loc_the = rct["sothe"].ToString();
                            if(loc_the != null && loc_the !="" && txtSothe.Text != "")
                            {
                                if (loc_the.IndexOf(txtSothe.Text.Substring(iKytubegin_xet_chiphivanchuyen, ikytuend_xet_chiphivanchuyen)) >= 0)
                                {
                                    d_cpvc += atmp;
                                }
                            }
                        }

                    }
                    catch{}
                    //end gam
                    atongbhyttra += atmp;
                }
                
                if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && !bTraituyen_bhtra) atyle = iTraituyen;
                else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && (v_BHYT_NT_PK && atongbhyttra<= m_v.ma13_st(m_v.nhom_duoc)))//Thuy 16.12.2011
                {
                    atyle = iTraituyen;
                }//End Thuy 16.12.2011
                else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra)
                {
                    atyle = f_get_Tylebhytchitra();
                    atyle = atyle * decimal.Parse(iTraituyen.ToString()) / 100;
                }
                else if (v_BHYT_PL_PK_KhongNV && (cbLoaibn.SelectedValue.ToString() == "4" || txtKhoarv.Text == "99"))
                {
                    if (m_v.bDanhapvien(m_mavaovien)) //neu nhap vien thi tinh}
                    {
                        atyle = f_get_Tylebhytchitra(atongbhyttra - d_cpvc); //atyle = f_get_Tylebhytchitra();//tinh 20% khong ke tong chi phi
                        label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    else atyle = f_get_Tylebhytchitra(atongbhyttra-d_cpvc);
                }
                else if (v_BHYT_PL_PK && cbLoaibn.SelectedValue.ToString() == "4")
                    atyle = f_get_Tylebhytchitra_PL(atongbhyttra - d_cpvc);//gam 15/08/2011 //phong luu tinh nhu phong khám: kiem tra chi phi vuot 15% thang luong tt
                else if (v_BHYT_NT_PK && cbLoaibn.SelectedValue.ToString() == "1")
                    atyle = f_get_Tylebhytchitra_Noitru(atongbhyttra - d_cpvc);//gam 15/08/2011 //noi tru tinh nhu phong khám: kiem tra chi phi vuot 15% thang luong tt
                else if (v_BHYT_NgT_PK && cbLoaibn.SelectedValue.ToString() == "2")
                    atyle = f_get_Tylebhytchitra_ngoaitru(atongbhyttra - d_cpvc);//gam 15/08/2011 //ngoai tru tinh nhu phong khám: kiem tra chi phi vuot 15% thang luong tt
                else atyle = f_get_Tylebhytchitra();// f_get_Tylebhytchitra(atongbhyttra);
                atongbhyttra = 0;
                //End
                decimal dTyle = 0;
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    dTyle = 0;
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
                        asoluong = decimal.Parse(decimal.Parse(r["soluong"].ToString().Trim().Replace(",", "")).ToString("###,###,##0.###"));
                    }
                    catch
                    {
                        asoluong = 0;
                    }
                    try
                    {
                        avat = decimal.Parse(r["vat"].ToString().Trim().Replace(",", ""));
                        if (avat < 0)
                        {
                            avat = 0;
                        }
                    }
                    catch
                    {
                        avat = 0;
                    }
                    try
                    {
                        avattu = decimal.Parse(r["vattu"].ToString().Trim().Replace(",", ""));
                        if (avattu < 0)
                        {
                            avattu = 0;
                        }
                    }
                    catch
                    {
                        avattu = 0;
                    }
                    if (m.StringToDate(r["ngay"].ToString()) >= m.StringToDate("15/02/2012") && CongthucTraiTuyen160212 && cmbTraituyen.SelectedIndex !=0)
                    {
                        TraiTuyenKhongTinhTyLe = true;
                    }
                    else
                    {
                        TraiTuyenKhongTinhTyLe = false;
                    }
                    abhyt_chenhlech = 0;
                    abhyt_bhtra = 0;
                    //asotien = Math.Round(asoluong * adongia + (asoluong * adongia * avat) / 100 + asoluong * avattu + (asoluong * avattu * avat) / 100,2);
                    asotien = Math.Round(asoluong * adongia + asoluong * avattu , 2);
                    bKhongcungchitra = false; d_dichvu_tt = 0; d_dichvu_tt_bhyt_tra = 0; i_tylechinhsach = 0;
                    if (r["madoituong"].ToString() == "1")// && r["kythuat"].ToString() == "-1")
                    {
                        //tinh chi phi van chuyen nhung the ma BHYT cho huong 100%
                        DataRow r1 = null;
                        try { r1 = m_dsgiavp.Tables[0].Select("id='" + r["mavp"].ToString() + "'")[0]; }
                        catch { r1 = null; }
                        //	
                        if (r1 != null)
                        {
                            //ThanhCuong - 14/08/2012 - kỹ thuật cao
                            if (decimal.Parse(r["ktcao"].ToString()) == 1)
                            {
                                if (decimal.Parse(r["id_ktcao"].ToString()) == 0)
                                {
                                    dTyle = dTylektcao(txtSothe.Text);
                                    abhyt_bhtra = asotien * (dTyle / 100);
                                    abhyt_bntra = asotien - abhyt_bhtra;
                                }
                                else
                                {
                                    asotien = 0;
                                    abhyt_bhtra = 0;
                                    abhyt_bntra = 0;
                                }
                            }
                            else
                            {
                                if (!TraiTuyenKhongTinhTyLe)
                                {

                                    dTyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString(), txtSothe.Text);//100% tra ve 1
                                }
                                else
                                {
                                    dTyle = 0;
                                }
                                if (r["madoituong"].ToString() == "1" && cmbTraituyen.SelectedIndex == 0)
                                {
                                    i_tylechinhsach = m.get_tyle_bhyt_chinhsach(txtSothe.Text);
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
                                abhyt_bhtra = (asotien - d_dichvu_tt) * dTyle + d_dichvu_tt_bhyt_tra;
                                abhyt_bntra = asotien - abhyt_bhtra;// 0;
                            }
                        }
                        //abhyt_bhtra = (asotien - d_dichvu_tt) * dTyle + d_dichvu_tt_bhyt_tra;
                        //abhyt_bntra = asotien - abhyt_bhtra;// 0;
                        

                    }
                    if (dTyle == 0)
                    {
                        if (m_doituongmien.IndexOf("," + r["madoituong"].ToString() + ",") != -1)
                        {
                            //decimal dTyle =(tmn_Khoatonghop.Checked)?1:f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                            if (!TraiTuyenKhongTinhTyLe)
                            {
                                dTyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                            }
                            else
                            {
                                dTyle = 0;
                            }
                            if (r["madoituong"].ToString() == "1" || (cbDoituongTD.SelectedValue.ToString() == "1" && r["madoituong"].ToString() != "1" && dTyle != 1))
                                //abhyt_bhtra = asotien * dTyle;//((tmn_Khoatonghop.Checked)?1:f_Get_Tyle_BHYT("1", r["mavp"].ToString()));
                                abhyt_bhtra = asotien * dTyle;
                            else abhyt_bhtra = asotien * dTyle;// f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());                            
                        }

                        abhyt_bntra = asotien - abhyt_bhtra;
                        //
                        if (atyle != 0 && r["madoituong"].ToString() == "1" && !TraiTuyenKhongTinhTyLe)//==80//doi tuong BHYT
                        {
                            abhyt_bhtra = ((asotien - d_dichvu_tt) * ((bKhongcungchitra) ? 100 : atyle)) / 100 + d_dichvu_tt_bhyt_tra; //abhyt_bhtra = abhyt_bhtra * ((bKhongcungchitra) ? 100 : atyle)) / 100;
                            abhyt_bntra = asotien - abhyt_bhtra;
                            //gam 11/10/2011
                            amien = abhyt_bntra * i_tylechinhsach / 100;
                            abhyt_bntra = abhyt_bntra - amien;
                            //end gam
                        }
                        else if (atyle != 0 && r["madoituong"].ToString() == "1" && TraiTuyenKhongTinhTyLe)
                        {
                            abhyt_bhtra = ((asotien - d_dichvu_tt) * ((bKhongcungchitra) ? 100 : 0)) / 100 + d_dichvu_tt_bhyt_tra; //abhyt_bhtra = abhyt_bhtra * ((bKhongcungchitra) ? 100 : atyle)) / 100;
                            abhyt_bntra = asotien - abhyt_bhtra;
                            //gam 11/10/2011
                            amien = abhyt_bntra * i_tylechinhsach / 100;
                            abhyt_bntra = abhyt_bntra - amien;
                        }
                    }
                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["vat"] = avat;
                    r["vattu"] = avattu;
                    r["sotien"] = asotien;
                    r["bntra"] = (abhyt_bntra + abhyt_chenhlech);
                    r["chenhlech"] = abhyt_chenhlech;
                    r["miendt"] = amien;//gam 11/10/2011
                    try
                    {
                        string aid_nhom=m_dsgiavp.Tables[0].Select("id="+r["mavp"].ToString())[0]["id_nhom"].ToString();
                        foreach(DataRow rn in m_dsnhomvp.Tables[0].Select("id="+aid_nhom))
                        {
                            rn["sotien"] = (decimal.Parse(rn["sotien"].ToString()) + asotien);
                        }
                    }
                    catch
                    {
                    }           
                    if (r["madoituong"].ToString() == "1")
                    {
                        atongbhyt += asotien;
                        atongbhyttra += abhyt_bhtra;
                        atongmienvp += amien;// gam 11/10/2011
                        r["bhyttra"] = abhyt_bhtra;
                        //r["miendt"] = 0;
                    }
                    else 
                    {
                        atongvp += asotien;
                        if (m_doituongmien.IndexOf("," + r["madoituong"].ToString() + ",") != -1)
                        {
                            atongmienvp += abhyt_bhtra;
                            r["miendt"] = abhyt_bhtra;
                            r["bhyttra"] = 0;
                        }
                        else
                        {
                            r["miendt"] = 0;
                            r["bhyttra"] = abhyt_bhtra;
                            atongbhyttra += abhyt_bhtra;
                        }
                    }
                    atongbntra += abhyt_bntra;
                    atongbntra += abhyt_chenhlech;
                }
                
                m_dshoadon.AcceptChanges();
                if (atongbhyttra > 0)
                {
                    atongbntra = atongbhyt - atongbhyttra;
                }
                else
                {
                    atongbntra = 0;
                }
                //m_dshoadon.WriteXml("c:\\cccc.xml", XmlWriteMode.WriteSchema);
                #region Mien doi tuong theo loai vp
                if (v_miendt_loai)
                {
                    if (s_loaibn_mien != "")
                    {
                        string[] s_loaibnmien = s_loaibn_mien.Split(',');
                        for (int i = 0; i < s_loaibnmien.Length; i++)
                        {
                            if (s_loaibnmien[i] == "1" && cbLoaibn.SelectedValue.ToString() == "1")
                            {
                                DataSet ads_giam = new DataSet();
                                decimal aLoai_giam = 0, aTongtiengiam = 0;
                                ads_giam = m_v.get_data("select * from medibv.v_miendtloaivp where madoituong=" + cbDoituongTD.SelectedValue.ToString() + "");

                                if (ads_giam.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow r_ct in ads_giam.Tables[0].Rows)
                                    {
                                        foreach (DataRow r_hd in m_dshoadon.Tables[0].Select("id_loai=" + r_ct["idloaivp"].ToString() + ""))
                                        {
                                            aLoai_giam += (decimal.Parse(r_hd["soluong"].ToString()) * decimal.Parse(r_hd["dongia"].ToString()));
                                        }
                                        aTongtiengiam += aLoai_giam * decimal.Parse(r_ct["tyle"].ToString()) / 100;
                                        aLoai_giam = 0;
                                    }
                                }
                                atongmienvp = aTongtiengiam;
                            }
                            else if (s_loaibnmien[i] == "2" && cbLoaibn.SelectedValue.ToString() == "2")
                            {
                                DataSet ads_giam = new DataSet();
                                decimal aLoai_giam = 0, aTongtiengiam = 0;
                                ads_giam = m_v.get_data("select * from medibv.v_miendtloaivp where madoituong=" + cbDoituongTD.SelectedValue.ToString() + "");

                                if (ads_giam.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow r_ct in ads_giam.Tables[0].Rows)
                                    {
                                        foreach (DataRow r_hd in m_dshoadon.Tables[0].Select("id_loai=" + r_ct["idloaivp"].ToString() + ""))
                                        {
                                            aLoai_giam += (decimal.Parse(r_hd["soluong"].ToString()) * decimal.Parse(r_hd["dongia"].ToString()));
                                        }
                                        aTongtiengiam += aLoai_giam * decimal.Parse(r_ct["tyle"].ToString()) / 100;
                                        aLoai_giam = 0;
                                    }
                                }
                                atongmienvp = aTongtiengiam;
                            }
                            else if (s_loaibnmien[i] == "4" && cbLoaibn.SelectedValue.ToString() == "4")
                            {
                                DataSet ads_giam = new DataSet();
                                decimal aLoai_giam = 0, aTongtiengiam = 0;
                                ads_giam = m_v.get_data("select * from medibv.v_miendtloaivp where madoituong=" + cbDoituongTD.SelectedValue.ToString() + "");

                                if (ads_giam.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow r_ct in ads_giam.Tables[0].Rows)
                                    {
                                        foreach (DataRow r_hd in m_dshoadon.Tables[0].Select("id_loai=" + r_ct["idloaivp"].ToString() + ""))
                                        {
                                            aLoai_giam += (decimal.Parse(r_hd["soluong"].ToString()) * decimal.Parse(r_hd["dongia"].ToString()));
                                        }
                                        aTongtiengiam += aLoai_giam * decimal.Parse(r_ct["tyle"].ToString()) / 100;
                                        aLoai_giam = 0;
                                    }
                                }
                                atongmienvp = aTongtiengiam;
                            }
                        }
                    }
                    else
                    {
                        DataSet ads_giam = new DataSet();
                        decimal aLoai_giam = 0, aTongtiengiam = 0;
                        ads_giam = m_v.get_data("select * from medibv.v_miendtloaivp where madoituong=" + cbDoituongTD.SelectedValue.ToString() + "");
                        if (ads_giam.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow r_ct in ads_giam.Tables[0].Rows)
                            {
                                foreach (DataRow r_hd in m_dshoadon.Tables[0].Select("id_loai=" + r_ct["idloaivp"].ToString() + ""))
                                {
                                    aLoai_giam += (decimal.Parse(r_hd["soluong"].ToString()) * decimal.Parse(r_hd["dongia"].ToString()));
                                }
                                aTongtiengiam += aLoai_giam * decimal.Parse(r_ct["tyle"].ToString()) / 100;
                                aLoai_giam = 0;
                            }
                        }
                        atongmienvp = aTongtiengiam;
                    }
                }
                #endregion

               

                #region Tinh tien tong hop
                try
                {
                    string _id = "";
                    decimal tyle = 0, _sotien = 0, _sotien_nhom = 0;
                    if (m_id != "0" && tmn_Nhapmienchitiet.Checked && m_dshoadon_nhomvp != null)
                    {
                        foreach (Control c in m_table.Controls)
                        {
                            if (c.Name.IndexOf("tbma_") != -1 && m_v.getrowbyid(m_dshoadon_nhomvp.Tables[0], "ma=" + c.Name.Replace("tbma_", "")) != null)
                            {
                                _id = c.Name.Replace("tbma_", "");
                                _sotien = decimal.Parse(m_dshoadon_nhomvp.Tables[0].Select("ma=" + _id)[0]["sotien"].ToString());
                                _sotien_nhom = decimal.Parse(m_dsnhomvp.Tables[0].Select("id=" + _id)[0]["sotien"].ToString());
                                c.Text = _sotien.ToString("###,###,##0.##");
                                foreach (Control c1 in m_table.Controls)
                                {
                                    if (c1.GetType() == typeof(TextBox))
                                    {
                                        if (c1.Name.Trim() == "tbtyle_" + _id)
                                        {
                                            tyle = 100 - ((_sotien * 100) / _sotien_nhom);
                                            if (tyle == 0) c1.Text = "";
                                            else c1.Text = Math.Round(tyle, 0).ToString();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Control c in m_table.Controls)
                        {
                            if (c.Name.IndexOf("tbma_") != -1)
                            {
                                _id = c.Name.Replace("tbma_", "");
                                foreach (Control c1 in m_table.Controls)
                                {
                                    if (c1.GetType() == typeof(TextBox))
                                    {
                                        TextBox tb = (TextBox)c1;
                                        if (tb.Name.Trim() == "tbtyle_" + _id)
                                        {
                                            tyle = (tb.Text == "") ? 0 : decimal.Parse(tb.Text);
                                            break;
                                        }
                                    }
                                }
                                try
                                {
                                    _sotien = decimal.Parse(m_dsnhomvp.Tables[0].Select("id=" + _id)[0]["sotien"].ToString());
                                    atongmienvp = atongmienvp + (_sotien * tyle / 100);
                                    c.Text = (_sotien - (_sotien * tyle / 100)).ToString("###,###,##0.##");
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
                }
                catch
                {
                }
                #endregion

                if (cbDoituongTD.SelectedValue.ToString()=="1" && txtSothe.Text!="" && lTraituyen != 0 && cmbTraituyen.SelectedIndex != 0 && atongbhyttra > lTraituyen)
                {
                    decimal tc = atongbhyttra + atongbntra;
                    atongbhyttra = decimal.Parse(lTraituyen.ToString());
                    atongbntra = tc - atongbhyttra;
                }
                txtCPBHYT.Text = atongbhyt.ToString("###,###,##0.##");
                txtCPVienphi.Text = atongvp.ToString("###,###,##0.##");
                txtCongCP.Text = (atongbhyt + atongvp).ToString("###,###,##0.##");
                txtMienBHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                txtMienDT.Text = atongmienvp.ToString("###,###,##0.##");
                txtCongmien.Text = atongmienvp.ToString("###,###,##0.##");
                txtChenhlech.Text = atongchenhlech.ToString("###,###,##0.##");
                txtBNTra_BHYT.Text = atongbntra.ToString("###,###,##0.##");
                txtBNTra_VP.Text = (atongvp - atongmienvp).ToString("###,###,##0.##");
                txtCongpt.Text = ((atongbhyt - atongbhyttra) + (atongvp - atongmienvp)).ToString("###,###,##0.##");
                f_Tinhtien_Tong();
            }
            catch
            {
                toolStrip_Tongcong.Text = "0";
                toolStrip_BHYT.Text = "0";
                toolStrip_Mien.Text = "0";
                toolStrip_Tamung.Text = "0";
                toolStrip_Thucthu.Text = "0";
            }
        }
 
        #region Kiem tra the bhyt moi(THANH TOAN 80%).
        private int f_get_Tylebhytchitra_PL(decimal v_sotien)
        {
            int tyletmp = 100;
            if (txtSothe.Text != "")
            {
                int maphu = (m_v.bPhongluu_bhyt_khambenh)?m_v.get_maphu_ngtru(txtSothe.Text, v_sotien, m_v.nhom_duoc):m_v.get_maphu(txtSothe.Text);
                tyletmp = (maphu == 1) ? 80 : (maphu == 2) ? 95 : 100;
            }
            return tyletmp;
        }
        private int f_get_Tylebhytchitra_Noitru(decimal v_sotien)
        {
            int tyletmp = 100;
            if (txtSothe.Text != "")
            {
                int maphu = (m_v.bNoitru_bhyt_khambenh) ? m_v.get_maphu_ngtru(txtSothe.Text, v_sotien, m_v.nhom_duoc) : m_v.get_maphu(txtSothe.Text);
                tyletmp = (maphu == 1) ? 80 : (maphu == 2) ? 95 : 100;
            }
            return tyletmp;
        }

        private int f_get_Tylebhytchitra_ngoaitru(decimal v_sotien)
        {
            int tyletmp = 100;
            if (txtSothe.Text != "")
            {
                int maphu = (m_v.bNgoaitru_bhyt_khambenh) ? m_v.get_maphu_ngtru(txtSothe.Text, v_sotien, m_v.nhom_duoc) : m_v.get_maphu(txtSothe.Text);
                tyletmp = (maphu == 1) ? 80 : (maphu == 2) ? 95 : 100;
            }
            return tyletmp;
        }  
        private int f_get_Tylebhytchitra(decimal v_sotien)
        {
            int tyletmp = 100;
            if (txtSothe.Text != "")
            {
                int maphu = m_v.get_maphu_ngtru (txtSothe.Text,v_sotien,m_v.nhom_duoc);
                tyletmp = (maphu == 1) ? 80 : (maphu == 2) ? 95 : 100;                
            }
            return tyletmp;
        }

        private int f_get_Tylebhytchitra()
        {
            int tyletmp = 100;
            if (txtSothe.Text != "")
            {
                int maphu = m_v.get_maphu(txtSothe.Text);
                tyletmp = (maphu == 1) ? 80 : (maphu == 2) ? 95 : 100;
            }
            return tyletmp;
        }
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
        #endregion
        private decimal dTylektcao(string sothe)
        {
            decimal dTyle_kt = 0;
            if (d.get_nhom(sothe, m.cc1_te1, m.nhom_duoc)) { dTyle_kt = 100; }
            else if (d.get_nhom(sothe, m.ck2_ca3, m.nhom_duoc)) { dTyle_kt = 100; }
            else if (d.get_nhom(sothe, m.bt4_hn4_ht5, m.nhom_duoc)) { dTyle_kt = 95; }
            else { dTyle_kt = decimal.Parse(m.phantram_bhyt.ToString()); }
            return dTyle_kt;
        }
        private void f_Tinhtien_Tong()
        {
            try
            {
                decimal acongpt = 0, acongmien = 0, amiendt = 0, atamung = 0, agdduyet = 0, athieu = 0, aphantram = 0, aphaitra = 0, abntrathieu = 0, athucthu_no = 0, abnthua = 0, abvtrathua = 0;
                try
                {
                    acongpt = decimal.Parse(txtCongpt.Text.Replace(",", ""));
                }
                catch
                {
                    acongpt = 0;
                }
                try
                {
                    amiendt = decimal.Parse(txtCongmien.Text.Replace(",", ""));
                }
                catch
                {
                    amiendt = 0;
                }
                try
                {
                    atamung = decimal.Parse(txtTamung.Text.Replace(",", ""));
                }
                catch
                {
                    atamung = 0;
                }
                try
                {
                    agdduyet = decimal.Parse(txtGDDuyet.Text.Replace(",", ""));
                }
                catch
                {
                    agdduyet = 0;
                }
                try
                {
                    aphantram = decimal.Parse(txtMienphantram.Text.Replace(",", ""));
                }
                catch
                {
                    aphantram = 0;
                }
                try
                {
                    athieu = decimal.Parse(txtBNThieu.Text.Replace(",", ""));
                }
                catch
                {
                    athieu = 0;
                }
                try
                {
                    abntrathieu = decimal.Parse(txtBNtraNO.Text.Replace(",", ""));
                }
                catch
                {
                    abntrathieu = 0;
                }
                try
                {
                    abnthua = decimal.Parse(txtthua.Text.Replace(",", ""));
                }
                catch
                {
                    abnthua = 0;
                }

                try
                {
                    abvtrathua = decimal.Parse(txtBVtraNo.Text.Replace(",", ""));
                }
                catch
                {
                    abvtrathua = 0;
                }

                if (acongpt < 0)
                {
                    acongpt = 0;
                }
                if (atamung < 0)
                {
                    atamung = 0;
                }
                if (agdduyet < 0)
                {
                    agdduyet = 0;
                }
                if (athieu < 0)
                {
                    athieu = 0;
                }
                if (aphantram < 0 || aphantram>100)
                {
                    aphantram = 0;
                }
                
                if (agdduyet <= 0 && aphantram>0)
                {
                    agdduyet = Math.Round(aphantram * acongpt/100,2);
                }

                if (acongpt - agdduyet < 0)
                {
                    agdduyet = 0;
                }

                aphaitra = acongpt - agdduyet - atamung;

                if (abntrathieu > 0 || abvtrathua>0)
                {
                    athucthu_no = aphaitra + abntrathieu - abvtrathua;
                }
                else
                {
                    athucthu_no = aphaitra;
                }
                if (aphaitra < 0)
                {
                    athieu = 0;
                    txtPhaithu.Text = aphaitra.ToString("###,###,##0.##").Trim('-');
                    lbPhaithu.Text = lan.Change_language_MessageText("Phải hoàn:");
                    txtThucthu_No.Text = athucthu_no.ToString("###,###,##0.##").Trim('-');
                    lbltu_no.Text = lan.Change_language_MessageText("Phải hoàn+BN trả nợ:");
                }
                else
                {
                    if (athieu > aphaitra)
                    {
                        athieu = 0;
                    }
                    aphaitra = aphaitra - athieu;
                    athucthu_no = athucthu_no - athieu;
                    txtPhaithu.Text = aphaitra.ToString("###,###,##0.##");
                    lbPhaithu.Text = lan.Change_language_MessageText("Phải thu:");
                    txtThucthu_No.Text = athucthu_no.ToString("###,###,##0.##").Trim('-');
                    lbltu_no.Text = lan.Change_language_MessageText("Phải thu+BN trả nợ:");
                }

                txtTamung.Text = atamung.ToString("###,###,##0.##");
                txtBNThieu.Text = athieu.ToString("###,###,##0.##");
                txtthua.Text = abnthua.ToString("###,###,##0.##");                
                txtGDDuyet.Text = agdduyet.ToString("###,###,##0.##");

                txtMienphantram.Text = "";
                if (agdduyet > 0)
                {
                    aphantram = Math.Round(agdduyet * 100 / acongpt, 2);
                    txtMienphantram.Text = aphantram.ToString("###,###,##0.##");
                }
                chkChuahoan.Enabled = aphaitra<0;
                acongmien = amiendt + agdduyet;
                toolStrip_Tongcong.Text = txtCongCP.Text;
                toolStrip_BHYT.Text = txtMienBHYT.Text;
                toolStrip_Mien.Text = acongmien.ToString("###,###,##0.##");
                toolStrip_Tamung.Text = atamung.ToString("###,###,##0.##");
                lbBNTra.Text = athucthu_no > 0 ? lan.Change_language_MessageText("Phải thu:") : lan.Change_language_MessageText("Phải hoàn:");              
                if(bThuchiravien_lamttrontienbn)
                {
                    if(lbBNTra.Text=="Phải thu:")
                    {
                    athucthu_no = Math.Ceiling(athucthu_no);
                    }
                    else if (lbBNTra.Text == "Phải hoàn:")
                    {
                        athucthu_no = Math.Floor(athucthu_no);
                    }
                    toolStrip_Thucthu.Text = athucthu_no.ToString("###,###,##0").Trim('-');
                }
                else
                {
                    toolStrip_Thucthu.Text = athucthu_no.ToString("###,###,##0.##").Trim('-');
                }
                if (int.Parse(toolStrip_Thucthu.Text) <= 0 && bbhyt_100_theodoibienlai == false)
                {
                    decimal temp=-1*decimal.Parse(txtSobienlai.Text);
                    txtSobienlai.Text = temp.ToString();
                }
            }
            catch
            {
            }
        }
        private void f_Load_Thutrongngay()
        {
            try
            {
                string sql = "", ammyy = "";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                decimal asotien = 0, asohd=0;
                sql = "select sum(a.sotien-a.bhyt-a.mien-a.thieu) as sotien from medibvmmyy.v_ttrvll a where a.userid="+m_userid+" and a.loaithu=0 and to_char(a.ngay,'dd/mm/yyyy')='"+txtNgaythu.Text.Substring(0,10)+"'";
                try
                {
                    asotien = decimal.Parse(m_v.get_data_mmyy(ammyy,sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    asotien = 0;
                }
                sql = "select count(distinct a.id) as sohd from medibvmmyy.v_ttrvll a where a.userid=" + m_userid + " and a.loaithu=0 and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                try
                {
                    asohd = decimal.Parse(m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    asohd = 0;
                }

                tmn_Tongthu.Text = asohd.ToString() + "=" + asotien.ToString("###,###,##0.##") + lan.Change_language_MessageText("đ");
                tmn_Tongthu.ToolTipText = m_v.Doiso_Unicode(asotien.ToString("#########")).Replace("  ", " ");
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
                string sql = "", ammyy = "", sql1 = "";
                ammyy = v_mmyy;
                if (ammyy == "")  ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));

                sql = "select a1.mabn,a1.mavaovien,a1.maql,a1.idkhoa,a.idtonghop,a.mien,a.bhyt,a.thieu,a.tamung,a.nopthem,a.chenhlech as chenhlech1,b2.lydo,b2.maduyet,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngaythu,to_char(a1.ngayra,'dd/mm/yyyy hh24:mi') as ngayra, a.makp as makpra,a.quyenso,a.sobienlai,a.loai,a.loaibn,to_char(b.ngay,'dd/mm/yyyy') as ngay,c.ma,c.ten,c.dvt,b.soluong,b.dongia,b.giamua,b.vat,b.vattu,(b.soluong*b.dongia) as sotien,0 as bhyttra, 0 as miendt, 0 as chenhlech, 0 as bntra,d.doituong,e.tenkp,b.madoituong,b.makp,b.mavp,thua,a1.chandoan,a1.maicd,to_number(1) as onpaid,nvl(b.id_ktcao,0) as id_ktcao,nvl(b.ktcao,0) as ktcao,a.mien_gdduyet, id_loai,b.mabs ";//binh sua lay ngay thu: lay them gioi ra//+ b.soluong*b.dongia*vat/100
                sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru b2 on a.id=b2.id left join (select id,ma,ten,dvt,id_loai from medibv.v_giavp union select d0.id,d0.ma,d0.ten, d0.dang as dvt, d1.loaivp as id_loai from medibv.d_dmbd d0 inner join medibv.d_dmnhom d1 on d0.manhom=d1.id ) c on b.mavp=c.id left join medibv.doituong d on b.madoituong=d.madoituong left join medibv.btdkp_bv e on b.makp=e.makp where a.id = " + v_id;//where d1.nhom=1

                DataSet ads = m_v.get_data_mmyy(ammyy, sql);
                sql1 = "select id, sothe, maphu, to_char(tungay,'dd/mm/yyyy') as tungay, to_char(ngay,'dd/mm/yyyy') as ngay, mabv, noigioithieu,traituyen from  medibvmmyy.v_ttrvbhyt where id=" + v_id;
                DataSet ads1 = m_v.get_data_mmyy(ammyy, sql1);
                m_dshoadon_nhomvp = m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvnhom where id=" + v_id);
                m_mavaovien = m_maql = m_idkhoa = m_id_thvpll = "";

                if (ads.Tables[0].Rows.Count > 0)
                {
                    m_mavaovien = ads.Tables[0].Rows[0]["mavaovien"].ToString();
                    m_maql = ads.Tables[0].Rows[0]["maql"].ToString();
                    if (ads.Tables[0].Rows[0]["idkhoa"].ToString() != "" && ads.Tables[0].Rows[0]["idkhoa"].ToString() != "0")
                        m_idkhoa = ads.Tables[0].Rows[0]["idkhoa"].ToString();

                    if (ads.Tables[0].Rows[0]["idtonghop"].ToString() != "" && ads.Tables[0].Rows[0]["idtonghop"].ToString() != "0")
                        m_id_thvpll = ads.Tables[0].Rows[0]["idtonghop"].ToString();

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
                        cbLoaidv.SelectedValue = ads.Tables[0].Rows[0]["loai"].ToString();
                        cbLoaidv_Validated(null, null);
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
                        cbLoaibn.SelectedValue = ads.Tables[0].Rows[0]["loaibn"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbKhoarv.SelectedValue = ads.Tables[0].Rows[0]["makpra"].ToString();
                        txtKhoarv.Text = ads.Tables[0].Rows[0]["makpra"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbLydomien.SelectedValue = ads.Tables[0].Rows[0]["lydo"].ToString();
                        txtLydomien.Text = ads.Tables[0].Rows[0]["lydo"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbKymien.SelectedValue = ads.Tables[0].Rows[0]["maduyet"].ToString();
                        txtKymien.Text = ads.Tables[0].Rows[0]["maduyet"].ToString();
                    }
                    catch
                    {
                    }
                    txtICD.Text = ads.Tables[0].Rows[0]["maicd"].ToString();
                    txtChandoan.Text = ads.Tables[0].Rows[0]["chandoan"].ToString();
                    txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    txtNgaythu.Value = m_v.f_parse_date_16(ads.Tables[0].Rows[0]["ngaythu"].ToString());//binh doi ham lay ngay 10 ky tu thanh lay ngay 16 ky tu co gio
                    txtNgayrv.Text = ads.Tables[0].Rows[0]["ngayra"].ToString();
                    try
                    {
                        cmbTraituyen.SelectedIndex = (ads1.Tables[0].Rows[0]["traituyen"].ToString().Trim()!="")?int.Parse(ads1.Tables[0].Rows[0]["traituyen"].ToString()):0;
                        txtSothe.Text = ads1.Tables[0].Rows[0]["sothe"].ToString();
                        txtTN.Text = ads1.Tables[0].Rows[0]["tungay"].ToString().Substring(0, 10);
                        txtDN.Text = ads1.Tables[0].Rows[0]["ngay"].ToString().Substring(0,10);
                        txtNDK_Ma.Text = ads1.Tables[0].Rows[0]["noigioithieu"].ToString();
                    }
                    catch { }
                    try
                    {//Thuy 15.12.2012 gan gdduyet = mien_gdduyet trong v_ttrvll
                        txtGDDuyet.Text = decimal.Parse(ads.Tables[0].Rows[0]["mien_gdduyet"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        txtGDDuyet.Text = "0";
                    }
                    try
                    {
                        txtBNThieu.Text = decimal.Parse(ads.Tables[0].Rows[0]["thieu"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        txtBNThieu.Text = "0";
                    }
                    try
                    {
                        txtTamung.Text = decimal.Parse(ads.Tables[0].Rows[0]["tamung"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        txtTamung.Text = "0";
                    }
                    try
                    {
                        txtChenhlech.Text = decimal.Parse(ads.Tables[0].Rows[0]["chenhlech1"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        txtChenhlech.Text = "0";
                    }
                    try
                    {
                        txtthua.Text = decimal.Parse(ads.Tables[0].Rows[0]["thua"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        txtthua.Text = "0";
                    }
                    try
                    {
                        chkChuahoan.Checked = decimal.Parse(ads.Tables[0].Rows[0]["nopthem"].ToString()) > 0;
                        txtBNtraNO.Text = decimal.Parse(ads.Tables[0].Rows[0]["nopthem"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        chkChuahoan.Checked = false;
                        txtBNtraNO.Text = "0";
                    }
                    if (tmn_thanhtoantheokhoa.Checked || v_thanhtoannhieudot_trongkhoa)
                    {
                        f_load_BC_Ngayrv(false);
                        try
                        {
                            cbNgayrv.SelectedValue = ads.Tables[0].Rows[0]["idtonghop"].ToString();
                        }
                        catch { }
                    }
                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("mavaovien");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loai");
                    ads.Tables[0].Columns.Remove("loaibn");
                    ads.Tables[0].Columns.Remove("ngaythu");
                    ads.Tables[0].Columns.Remove("mien");
                    ads.Tables[0].Columns.Remove("bhyt");
                    ads.Tables[0].Columns.Remove("thieu");
                    ads.Tables[0].Columns.Remove("nopthem");
                    ads.Tables[0].Columns.Remove("tamung");
                    ads.Tables[0].Columns.Remove("chenhlech1");
                    ads.Tables[0].Columns.Remove("ngayra");
                    ads.Tables[0].Columns.Remove("makpra");
                    ads.Tables[0].Columns.Remove("lydo");
                    ads.Tables[0].Columns.Remove("maduyet");
                    ads.Tables[0].Columns.Remove("idkhoa");
                    ads.Tables[0].Columns.Remove("idtonghop");
                    m_dshoadon = ads.Copy();
                    dgHoadon.DataSource = m_dshoadon.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien();
                    m_id = v_id;
                }
                f_Enable(m_id == "" || m_id == "0");
                butLuu_EnabledChanged(null, null);
                if (v_Quanglythatthuno)
                {
                    if (txtBNThieu.Text != "" && txtBNThieu.Text != "0")
                    {
                        chkBNthieu.Checked = true;
                        chkBNthieu.Enabled = false;
                    }
                    else
                    {
                        chkBNthieu.Checked = false;
                        chkBNthieu.Enabled = false;
                    }

                    if (txtthua.Text != "" && txtthua.Text != "0")
                    {
                        chkBNThua.Checked = true;
                        chkBNThua.Enabled = false;
                    }
                    else
                    {
                        chkBNThua.Checked = false;
                        chkBNThua.Enabled = false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                m_mavaovien = "";
                m_maql = "";
            }
        }
        private void f_Load_Hoadon_NextPre(int v_pre)
        {
            try
            {
                string sql = "", ammyy = "", asobienlai="",aexp="",aid="";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                aexp = " a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                if (m_id != "" && m_id != "0")
                {
                    try
                    {
                        asobienlai = decimal.Parse(m_v.get_data_mmyy(ammyy,"select sobienlai from medibvmmyy.v_ttrvll where id = " + m_id).Tables[0].Rows[0][0].ToString()).ToString();
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
                sql = "select a.id from medibvmmyy.v_ttrvll a where " + aexp;
                try
                {
                    aid = decimal.Parse(m_v.get_data_mmyy(ammyy,sql).Tables[0].Rows[0][0].ToString()).ToString();
                }
                catch
                {
                    aid = "";
                }
                if (aid == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy hoá đơn ") + (v_pre < 0 ? lan.Change_language_MessageText("trước") : lan.Change_language_MessageText("sau")) + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cmbTraituyen.SelectedIndex = 0;
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
               
                atn = (cbNgayvv.SelectedIndex >= 0) ? cbNgayvv.Text : m_v.f_string_date(atn);
                if (atn.Length >= 10) atn = atn.Substring(0, 10);
                else  atn = txtNgaythu.Text.Substring(0, 10);
                string sql = "";
                sql = "select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tn, to_char(a.denngay,'dd/mm/yyyy') as dn,a.mabv,b.tenbv,a.maphu,a.traituyen from medibv.bhyt a left join medibv.dmnoicapbhyt b on a.mabv=b.mabv where a.maql = " + amaql;
                sql += " union all select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tn, to_char(a.denngay,'dd/mm/yyyy') as dn,a.mabv,b.tenbv,a.maphu,a.traituyen from medibvmmyy.bhyt a left join medibv.dmnoicapbhyt b on a.mabv=b.mabv where a.maql = " + amaql;
                foreach (DataRow r in m_v.get_data_bc_1(atn, txtNgaythu.Text.Substring(0, 10), sql,1).Tables[0].Rows)
                {
                    cmbTraituyen.SelectedIndex = (r["traituyen"].ToString().Trim() != "") ? int.Parse(r["traituyen"].ToString()) : 0;
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
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_BHYT()");
            }
        }
        private void f_Load_Tamung(string v_tn, string v_maql, bool v_laylaisolieu)
        {
            s_idthutamung = "";
            try
            {
                if (chkThuong.Checked)
                {
                    return;
                }
                try
                {
                    v_maql = decimal.Parse(v_maql).ToString();
                }
                catch
                {
                    return;
                }
               
                string sql = "", sql_luu = "";
                sql = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id,a.quyenso, a.makp,a.madoituong from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id where a.mabn='" + txtMabn.Text+txtMabn1.Text + "'";
                if (v_doituongthu != "")
                {
                    sql += " and a.madoituong in(" + v_doituongthu + ")";
                }
                if (m.bTonghopbienlaitamung_chuahoan)
                {
                    string _ngayvv = m.get_ngay_Capcuu_noitru(cbNgayvv.Text, decimal.Parse(m_mavaovien));
                    if (_ngayvv == "") _ngayvv = cbNgayvv.Text.Substring(0, 10);
                    if (_ngayvv.Length > 10) _ngayvv = _ngayvv.Substring(0, 10);
                    sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + _ngayvv  + "','dd/mm/yyyy') and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";//chi theo mabn
                    //sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + cbNgayvv.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtNgaythu.Text.Substring(0,10) + "','dd/mm/yyyy')";//chi theo mabn
                }
                else if (m_mavaovien != "" || m_mavaovien != "0")
                {
                    sql += " and (a.mavaovien=" + m_mavaovien + " or a.maql=" + m_mavaovien + ")";
                }
                else
                {
                    if (m_maql != "")
                    {
                        sql += " and a.maql=" + m_maql;
                    }
                    if (m_maql_phongluu != "" && m_maql_phongluu != "0")
                    {
                        sql_luu = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id, a.quyenso, a.makp,a.madoituong from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id where a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";
                        sql_luu += " and a.maql=" + m_maql_phongluu;
                    }
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
                    //m_dstamung = m_v.get_data_bc_1(v_tn,txtNgaythu.Text.Substring(0,10),sql);
                    if (!v_thanhtoannhieudot_trongkhoa)
                    {
                        m_dstamung = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), true);
                        if (m_maql_phongluu != "" && m_maql != m_maql_phongluu)
                        {
                            m_dstamung.Merge(m_v.get_data_mmyy(sql_luu, v_tn, txtNgaythu.Text.Substring(0, 10), true));
                        }
                    }
                    else
                    {
                        //string tmp_dn = (cbNgayrv.Text.Length > 10) ? cbNgayrv.Text.Substring(cbNgayrv.Text.Length - 10, 10) : txtNgaythu.Text.Substring(0, 10);
                        //string tmp_tn = (cbNgayrv.Text.Length > 10) ? cbNgayrv.Text.Substring(0, 10) : txtNgaythu.Text.Substring(0,10);
                        string tmp_dn = (cbNgayrv.Text.Length > 10) ? cbNgayrv.Text.Substring(cbNgayrv.Text.Length - 10, 10) : txtNgaythu.Text.Substring(0, 10);
                        string tmp_tn = (cbNgayvv.Text.Length > 10) ? cbNgayvv.Text.Substring(0, 10) : cbNgayvv.Text.Substring(0, 10);
                        m_dstamung = m_v.get_data_mmyy(sql, tmp_tn,tmp_dn, true);
                        if (m_maql_phongluu != "" && m_maql != m_maql_phongluu)
                        {
                            m_dstamung.Merge(m_v.get_data_mmyy(sql_luu, tmp_tn, tmp_dn, false));
                        }
                    }
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
                    txtTamung_Validated(null, null);
                    s_idthutamung = s_idthutamung.Trim().Trim(',');
                }
                catch
                {
                }
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(sql + " -" + ex.ToString(), m_v.s_ComputerName, "f_Load_Tamung()");
            }
        }

        private void f_Load_Chidinh(string v_tn, string v_maql, bool v_laylaisolieu)
        {
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
                //m_maql_phongluu = m_v.get_maql_benhancc(m_mavaovien, txtMabn.Text + txtMabn1.Text, v_tn.Substring(0, 10)).ToString();
                m_maql_phongluu = m_v.get_maql_phongluu(v_tn.Substring(0, 10), decimal.Parse(v_maql)).ToString();
                string s_maql = v_maql;
                if (tmn_Cophongluu.Checked && m_maql_phongluu != "0") s_maql += "," + m_maql_phongluu;
                if (cbLoaibn.SelectedValue.ToString() == "2")
                {
                    s_maql += "," + m_v.get_maql_ngoaitru(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), decimal.Parse(v_maql));
                }
                //
                string s_maql_pk = "";
                if (tmn_Cokhambenh.Checked)
                {
                    s_maql_pk = m_v.get_maql_phongkham(cbNgayvv.Text, txtNgayrv.Text, decimal.Parse(m_mavaovien));
                }
                if (s_maql_pk.Trim().Trim(',') != "") s_maql = s_maql.Trim().Trim(',') + "," + s_maql_pk;
                s_maql = s_maql.Trim().Trim(',');
                s_maql_captoa = s_maql;
                //f_Load_Tamung(v_tn, v_maql, v_laylaisolieu);
                f_Load_Tamung(cbNgayvv.Text.Substring(0, 10), v_maql, v_laylaisolieu);   //lay tien tam ung theo ngay vao vien de lay tamung cua 2 thang neu co
                //Chi dinh
                DataSet ads = null, ads1 = null;
                if (tmn_Thuchidinh.Checked)
                {
                    //aexp = " where a.maql = " + v_maql + "";
                    aexp = " where a.maql in (" + s_maql + ")";
                    #region truongthuy edit 22042014
                    if (!v_laylaisolieu)
                    {
                        aexp += " and a.paid=0";
                    }
                    #endregion 
                    if (chkThuong.Checked)
                    {
                        aexp += " and b.thuong=1";
                    }
                    else
                    {
                        aexp += " and b.thuong<>1";
                    }
                    if (!m_v.ttrv_thanhtoanhaophi(m_userid)) aexp += " and a.madoituong<>5";
                    if (v_doituongthu != "")
                    {
                        aexp += " and a.madoituong in(" + v_doituongthu + ")";
                    }
                    //binh
                    if (v_khoaphongthu != "")
                    {
                        aexp += " and a.makp in(" + v_khoaphongthu + ")";
                    }
                    //end binh
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        aexp += " and a.id not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay, b.ma,b.ten,b.dvt,a.soluong,a.dongia," +
                        "a.dongia as giamua,a.soluong*a.dongia as sotien,to_number('0') as bhyttra," +
                        "to_number('0') as chenhlech,to_number('0') as miendt,to_number('0') as bntra," +
                        "b.vat, to_number('0') as vattu,c.doituong, d.tenkp, a.makp," +
                        "a.madoituong,a.mavp,a.id as idchidinh,to_number('0') as onpaid";
                    sql += ",a.mabs,to_number('0') as id_ktcao,to_number('0') as ktcao";//gam 27/02/2012
                    sql += ", a.id, to_number('1') as stt, to_number('0') as toave, a.id as idtonghop, to_number('0') as stttonghop";//binh 190913
                    sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join " +
                        "medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on " +
                        "a.makp=d.makp" + aexp;
                    ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), false);
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
                if (tmn_Vienphikhoa.Checked)
                {
                    //aexp = " where a.maql = " + v_maql;
                    aexp = " where a.maql in (" + s_maql + ")";
                    if (!v_laylaisolieu)
                    {
                        aexp += " and a.done=0";
                    }
                    if (chkThuong.Checked)
                    {
                        aexp += " and b.thuong=1";
                    }
                    else
                    {
                        aexp += " and b.thuong<>1";
                    }
                    if (!m_v.ttrv_thanhtoanhaophi(m_userid)) aexp += " and a.madoituong<>5";
                    if (v_doituongthu != "")
                    {
                        aexp += " and a.madoituong in(" + v_doituongthu + ")";
                    }
                    //binh
                    if (v_khoaphongthu != "")
                    {
                        aexp += " and a.makp in(" + v_khoaphongthu + ")";
                    }
                    //end binh
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        aexp += " and a.id not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay, b.ma,b.ten,b.dvt,a.soluong," +
                        "a.dongia,a.dongia as giamua,a.soluong*a.dongia as sotien, to_number('0') as bhyttra," +
                        " to_number('0') as chenhlech, to_number('0') as miendt,to_number('0') as bntra," +
                        "b.vat, to_number('0') as vattu,c.doituong, d.tenkp, a.makp," +
                        "a.madoituong,a.mavp,a.id as idchidinh,to_number('0') as onpaid ";
                    sql += ",'' as mabs,a.id as id_ktcao,to_number('0') as ktcao";//gam 27/02/2012
                    sql += ", a.id, to_number('1') as stt, to_number('0') as toave, a.id as idtonghop, to_number('0') as stttonghop";//binh 190913
                    sql += " from medibvmmyy.v_vpkhoa a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp" + aexp;
                    ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), false);
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
                if (tmn_Toathuoctutruc.Checked)
                {
                    //aexp = " where a.maql = " + v_maql;
                    aexp = " where a.maql in (" + s_maql + ")";
                    if (!v_laylaisolieu)
                    {
                        aexp += " and b.paid=0";
                    }
                    if (!m_v.ttrv_thanhtoanhaophi(m_userid)) aexp += " and b.madoituong<>5";
                    sql = " select to_char(a.ngay,'dd/mm/yyyy') as ngay,d.ma,d.ten|| case when d.tenhc='' then '' else ' [ '||d.tenhc||' ] ' end ||''||  d.hamluong as ten,d.dang as dvt,b.soluong,";
                    sql += "b.giaban as dongia,";
                    sql += "b.giaban as giamua,";
                    sql += "b.soluong*b.giaban as sotien,";
                    sql += "to_number('0') as bhyttra,to_number('0') as chenhlech, to_number('0') as miendt," +
                        " to_number('0') as bntra,d.vat, to_number('0') as vattu,e.doituong," +
                        " f.tenkp, c.makp,b.madoituong,b.mabd as mavp,to_number('0') as idchidinh," +
                        "to_number('0') as onpaid ";
                    sql += ",a.mabs,to_number('0') as id_ktcao,to_number('0') as ktcao ";
                    sql += ", a.id, b.stt, to_number('1') as toave, a.id as idtonghop, b.stt as stttonghop";//binh 190913
                    sql += " from medibvmmyy.d_ngtrull a inner join medibvmmyy.d_ngtruct b on a.id=b.id left join medibv.d_duockp c on a.makp=c.id inner join medibv.d_dmbd d on b.mabd=d.id inner join medibv.doituong e on b.madoituong=e.madoituong left join medibv.btdkp_bv f on c.makp=f.makp";
                    sql += " " + aexp + "";
                    ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), true);
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
                if (tmn_Thuocthuongquy.Checked)
                {
                    if (!chkThuong.Checked)
                    {
                        aexp = " where a.soluong<>0 ";
                        aexp = " where a.maql in (" + s_maql + ")";
                        if (!v_laylaisolieu)
                        {
                            aexp += " and a.done=0";
                        }
                        if (!m_v.ttrv_thanhtoanhaophi(m_userid)) aexp += " and a.madoituong<>5";
                        if (v_doituongthu != "")
                        {
                            aexp += " and a.madoituong in(" + v_doituongthu + ")";
                        }
                        //binh
                        if (v_khoaphongthu != "")
                        {
                            aexp += " and a1.makp in(" + v_khoaphongthu + ")";
                        }
                        aexp += " and a.soluong<>0 ";
                        //end binh
                        sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay, b.ma,b.ten|| case when b.tenhc='' then '' else ' [ '||b.tenhc||' ] ' end ||''||  b.hamluong as ten,b.dang as dvt,a.soluong,";
                        sql += " case when c.loai=1 and a.madoituong<>1 then a.giaban else a.giamua end as dongia,a.giamua,a.soluong*(case when c.loai=1 and a.madoituong<>1 then a.giaban else a.giamua end) as sotien,";
                        //sql += " a.giaban as dongia,a.giamua,a.soluong*a.giaban as sotien,";
                        sql += " to_number('0') as bhyttra,to_number('0') as chenhlech, to_number('0') as miendt, to_number('0') as bntra,b.vat, to_number('0') as vattu,c.doituong, d.tenkp, a1.makp,a.madoituong,a.mabd as mavp,a.id as idchidinh,to_number('0') as onpaid";
                        sql += ",a.mabs,nvl(a.id_ktcao,0) as id_ktcao,to_number('0') as ktcao ";
                        sql += ", a.id, to_number('0') as stt, to_number('0') as toave, a.id as idtonghop, to_number('0') as stttonghop";//binh 190913
                        sql += " from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id left join medibv.d_doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + aexp;
                        ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), true);
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
                }

                //Phu thu dich vu cap phat le BHYT noi tru
                if (v_phuthu_capphatle_bhytnoitru)
                {
                    int i_tunguyen = m_v.iTunguyen == 0 ? 2 : m_v.iTunguyen;
                    string s_doituong = m_dsdoituong.Tables[0].Select("madoituong=" + i_tunguyen)[0]["doituong"].ToString();
                    //aexp = " where a.maql = " + v_maql;
                    aexp = " where a.maql in (" + s_maql + ")";
                    aexp += " and a.madoituong=1 and nvl(a.datra,0)=0 and done=0 and idttrv=0 and idkhoa<>0";
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        aexp += " and a.mabd not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay, b.ma, b.ten, b.dang as dvt, a.soluong, " +
                    "case when a.giaban-( case when b.gia_bh=0 then a.giamua else b.gia_bh end)<0 then 0 else " +
                    "a.giaban-(case when b.gia_bh=0 then a.giamua else b.gia_bh end) end as dongia, a.giamua, " +
                    "a.soluong*(case when a.giaban-(case when b.gia_bh=0 then a.giamua else b.gia_bh end)<0 then 0 " +
                    "else a.giaban-(case when b.gia_bh=0 then a.giamua else b.gia_bh end) end) as sotien, " +
                    "to_number('0') as bhyttra, to_number('0') as chenhlech, to_number('0') as miendt, " +
                    "to_number('0') as bntra,b.vat, to_number('0') as vattu, " +
                    "'" + s_doituong + "' as doituong, d.tenkp, d.makp, to_number('" + i_tunguyen + "',0) " +
                    "as madoituong, a.mabd as mavp, a.id as idchidinh, to_number('0') as onpaid,'' as mabs," +
                    "a.id_ktcao,to_number('0') as ktcao, a.id as idtonghop, to_number('0') as stttonghop ";
                    sql += ", a.id, to_number('0') as stt, to_number('0') as toave";//binh 190913
                    sql += " from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on " +
                    "a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id left join medibv.doituong c on " +
                        "a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + aexp;
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

                if (tmn_Toachove.Checked)
                {
                    //aexp = " where a.maql = " + v_maql;
                    aexp = " where a.maql in (" + s_maql + ")";
                    if (!v_laylaisolieu)
                    {
                        aexp += " and a.quyenso=0";
                    }
                    if (v_doituongthu != "")
                    {
                        aexp += " and a.maphu in(" + v_doituongthu + ")";
                    }
                    sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay, b.ma,b.ten|| case when b.tenhc='' then '' else ' [ '||b.tenhc||' ] ' end ||''||  b.hamluong as ten,b.dang as dvt,a.soluong,a.giamua as dongia,a.giamua as giamua,a.soluong*a.giamua as sotien, "; //a.giaban as dongia,a.giaban as giamua,a.soluong*a.giaban as sotien, ";
                    sql += " to_number('0') as bhyttra,to_number('0') as chenhlech, to_number('0') as miendt, to_number('0') as bntra,b.vat,";
                    sql += " to_number('0') as vattu, a.doituong as doituong, d.tenkp, a.makp, a.maphu as madoituong,a.mabd as mavp,to_number('0')as id_loai,to_number('0') as idchidinh,to_number('0') as onpaid,a.mabs";
                    sql += ", id_ktcao, ktcao, a.id, a.stt, a.toave, a.idtonghop, a.stttonghop";
                    sql += " from ";
                    sql += " (select x.mabn, x.quyenso, x.sobienlai, x.maphu, x.maql, x.ngay, x.makp, dt.doituong," +
                        " y.mabd, y.soluong, case when dt.loai=1 and x.maphu<>1 then y.giaban else yy.giamua" +
                        " end giaban, case when dt.loai=1 and x.maphu<>1 then y.giaban else yy.giamua end " +
                        "giamua,x.mabs,to_number('0') as id_ktcao,to_number('0') as ktcao ";
                    sql += ", x.id, y.stt, to_number('1') as toave, x.id as idtonghop, y.stt as stttonghop";//binh 190913
                    sql += " from medibvmmyy.bhytkb as x,medibvmmyy.bhytthuoc as y, medibvmmyy.d_theodoi as yy," +
                        " medibv.d_doituong dt where x.id=y.id and y.sttt=yy.id and x.maphu=dt.madoituong " +
                        "and x.maql in (" + s_maql + ")) as a ";
                    sql += " inner join medibv.d_dmbd b on a.mabd=b.id left join ";
                    sql += " medibv.btdkp_bv d on a.makp=d.makp ";
                    sql += aexp;
                    //lay so lieu tu bhytcld+bhytkb
                    sql += " UNION ALL";
                    sql += " select to_char(a.ngay,'dd/mm/yyyy') as ngay, b.ma,b.ten as ten,b.dvt as dvt,a.soluong,a.giaban,a.giamua,a.soluong*a.giamua as sotien, "; //a.giaban as dongia,a.giaban as giamua,a.soluong*a.giaban as sotien, ";
                    sql += " to_number('0') as bhyttra,to_number('0') as chenhlech, to_number('0') as miendt, to_number('0') as bntra,b.vat,";
                    sql += " to_number('0') as vattu, a.doituong as doituong, d.tenkp, a.makp, a.maphu as madoituong,a.mabd as mavp,to_number('0')as id_loai,to_number('0') as idchidinh,to_number('0') as onpaid,a.mabs";
                    sql += ", id_ktcao, ktcao, a.id, a.stt, a.toave, a.idtonghop, a.stttonghop";
                    sql += " from ";
                    sql += " (select x.mabn, x.quyenso, x.sobienlai, x.maphu, x.maql, x.ngay, x.makp, dt.doituong," +
                        " y.mavp as mabd, y.soluong, y.dongia as giaban, y.dongia as giamua,x.mabs,to_number('0') as id_ktcao,to_number('0') as ktcao ";
                    sql += ", x.id, y.stt, to_number('1') as toave, x.id as idtonghop, y.stt as stttonghop";//binh 190913
                    sql += " from medibvmmyy.bhytkb as x,medibvmmyy.bhytcls as y," +
                        " medibv.d_doituong dt where x.id=y.id and x.maphu=dt.madoituong " +
                        "and x.maql in (" + s_maql + ")) as a ";
                    sql += " inner join medibv.v_giavp b on a.mabd=b.id left join ";
                    sql += " medibv.btdkp_bv d on a.makp=d.makp ";
                    sql += aexp;
                    ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), true);
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
                m_id_thvpll = "0";
                if (tmn_Khoatonghop.Checked)
                {
                    if (tmn_thanhtoantheokhoa.Checked || v_thanhtoannhieudot_trongkhoa)
                    {
                        decimal s_aid;
                        try
                        {
                            s_aid = decimal.Parse(cbNgayrv.SelectedValue.ToString());
                        }
                        catch
                        {
                            dgHoadon.DataSource = null;
                            dgHoadon.Refresh();
                            return;
                        }
                        aexp = " where a1.id = " + s_aid;
                        //
                    }
                    else
                    {
                        aexp = " where a1.maql = " + v_maql;
                    }
                    if (!v_laylaisolieu)
                    {
                        aexp += " and a.idttrv=0";//linh 23042012 //" and a.done=0"
                    }
                    if (chkThuong.Checked)
                    {
                        aexp += " and b.thuong=1";
                    }
                    else
                    {
                        aexp += " and b.thuong<>1";
                    }

                    if (!m_v.ttrv_thanhtoanhaophi(m_userid)) aexp += " and a.madoituong<>5";
                    if (v_doituongthu != "")
                    {
                        aexp += " and a.madoituong in(" + v_doituongthu + ")";
                    }
                    aexp += " and a.soluong<>0 ";
                   // sql = "select a1.id, to_char(a.ngay,'dd/mm/yyyy') as ngay, b.ma,b.ten,b.dvt,a.soluong,";
                    sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay, b.ma,b.ten,b.dvt,a.soluong,";// thuytruong 08/04/2014  
                    sql += "a.dongia,";
                    sql += "a.dongia as giamua,";
                    sql += "a.soluong*a.dongia as sotien,";
                    sql += " to_number('0') as bhyttra,to_number('0') as chenhlech,to_number('0') as miendt, to_number('0') as bntra,b.vat, " +
                        "to_number('0') as vattu,c.doituong, d.tenkp, a.makp,a.madoituong,a.mavp,b.id_loai,to_number('0') as idchidinh,to_number('0') as onpaid";
                    sql += ",a.mabs,nvl(a.id_ktcao,0) as id_ktcao,nvl(a.ktcao,0) as ktcao";//gam 27/02/2012
                    sql += ", a.id, to_number('0') as stt, to_number('0') as toave, a.idtonghop,";
                    // a.stttonghop ";//binh 190913  
                    sql += " to_number( a.stttonghop) as stttonghop";//thuytruong 08/04/2014 
                    sql += " from medibvmmyy.v_thvpct a inner join medibvmmyy.v_thvpll a1 on a.id=a1.id ";
                    sql += " inner join (select id,ma,ten,dvt,thuong,id_loai,vat from medibv.v_giavp union all select d0.id,d0.ma,d0.ten|| case when d0.tenhc='' " +
                        " then '' else '['||d0.tenhc||']' end as ten,d0.dang,to_number('0') as thuong,d2.id_nhom as id_loai,d0.vat from medibv.d_dmbd d0 " +
                        "inner join medibv.d_dmnhom d1 on d0.manhom=d1.id left join medibv.v_loaivp d2 on d1.nhomvp=d2.id_nhom group by d0.id,d0.ma," +
                        " d0.ten|| case when d0.tenhc='' then '' else '['||d0.tenhc||']' end,d0.dang,d2.id_nhom,d0.vat) b on a.mavp=b.id ";
                    sql += " left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp" + aexp;
                    ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), false);
                    if (ads1 != null)
                    {
                        if (ads1.Tables[0].Rows.Count > 0)
                        {
                            m_id_thvpll = ads1.Tables[0].Rows[0][0].ToString();
                        }
                       // ads1.Tables[0].Columns.Remove("id"); thuytruong 08042014
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

                if (ads != null)
                {
                    m_dshoadon = ads;
                    dgHoadon.DataSource = ads.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien();
                    if (System.IO.Directory.Exists("..//..//dataxml") == false) System.IO.Directory.CreateDirectory("..//..//dataxml");
                    ads.WriteXml("..//..//dataxml//thuchirv.xml", XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_Chidinh()");
            }
        }
        private void f_load_BC_Ngayrv(bool v_edit)
        {
            try
            {
                string adone = "", amabn = "", amaql="";
                if (v_edit)
                {
                    adone = " and c.idttrv=0";//linh 23042012 :" and done=0"
                }
                else
                {
                    adone = " and c.idttrv<>0";//linh 13042012 " and done=1";
                    if (m_idkhoa != "" && m_idkhoa != "0")
                        v_idkhoa = " and idkhoa=" + m_idkhoa + "";
                    else
                        v_idkhoa = "";
                }
                amabn = txtMabn.Text + txtMabn1.Text;         
                string sql = "";
                //<-------------idthuoc : cap nhat d_tienthuoc, tranh truong hop cap nhat luon ca phan chua chuyen thanh toan' (thanh toan' nhieu dot)------------->
                sql = "select a.id, to_char(a.ngayvao,'dd/mm/yyyy')||' -> '||to_char(a.ngayra,'dd/mm/yyyy') as ngay, "+
                    " to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra,a.makp,a.idkhoa,a.idthuoc, a.maql,"+
                    "b.sothe, nvl(b.traituyen,0) as traituyen, b.noicap as mabv, f.tenbv ";
                sql += " from medibvmmyy.v_thvpll a left join medibvmmyy.v_thvpbhyt b on a.id=b.id " +
                    " inner join (select distinct id,idttrv from medibvmmyy.v_thvpct) c on a.id=c.id " +//linh 23042012
                    " left join medibv.dmnoicapbhyt f on b.noicap=f.mabv " +
                    "where a.mabn='" + amabn + "' " + adone + " " + v_idkhoa + amaql + " order by ngayra desc";
                DataSet ads = m_v.get_data_bc_1(cbNgayvv.Text.Substring(0, 10),txtNgaythu.Text.Substring(0,10), sql);
                cbNgayrv.DisplayMember = "NGAY";
                cbNgayrv.ValueMember = "ID";
                cbNgayrv.DataSource = ads.Tables[0];
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_BC_Ngayrv()");
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
                if (tmn_Cokhambenh.Checked)
                {
                    if (sql1 != "")
                    {
                        sql1 += " union all ";
                    }
                    sql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24mi') as ngay1, makp,madoituong,to_number('3') as loaibn,chandoan,maicd,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayra from medibvmmyy.benhanpk where mabn='" + amabn + "'";
                }
                if (tmn_Cophongluu.Checked)
                {
                    if (sql1 != "")
                    {
                        sql1 += " union all ";
                    }
                    sql1 += "select maql, mavaovien, to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24mi') as ngay1, makp, madoituong, to_number('4') as loaibn, chandoanrv as chandoan, maicdrv as maicd,to_char(ngayrv,'dd/mm/yyyy hh24:mi') as ngayra from medibvmmyy.benhancc where mabn='" + amabn + "'";
                }
                if (tmn_Congoaitru.Checked)
                {
                    if (sql1 != "")
                    {
                        sql1 += " union all ";
                    }
                    sql1 += "select maql, mavaovien, to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24mi') as ngay1, makp, madoituong, to_number('2') as loaibn, chandoan, maicd, to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayra from medibv.benhanngtr where mabn='" + amabn + "'";
                }
                DataSet ads = null, ads1 = null, ads2 = null;
                if (sql1 != "")
                {
                    sql1 += " order by ngay1 desc,maql desc";
                    //ads = m_v.get_data_bc(adt.AddMonths(-1), txtNgaythu.Value.AddMonths(1), sql1);
                    ads = m_v.get_data_mmyy(sql1, m_v.DateToString("dd/MM/yyyy", adt.AddMonths(-iSothang)), txtNgaythu.Text.Substring(0, 10), true);
                }
                if (tmn_Conhanbenh.Checked)
                {
                    if (tmn_Khoatonghop.Checked && v_thanhtoannhieudot_trongkhoa)
                    {
                        sql = "select a.maql, a.mavaovien, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(a.ngay,'yyyymmddhh24mi') as ngay1, b.makp, a.madoituong, loaiba as loaibn, a.chandoan, a.maicd, to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngayra ";
                        sql += " from medibv.benhandt a left join medibv.nhapkhoa b on a.maql=b.maql left join medibv.xuatkhoa c on b.id=c.id where a.mabn='" + amabn + "'";
                        if (tmn_Theotungkhoa.Checked) sql += " and c.ngay is not null order by ngay1 desc, a.maql desc";
                        else sql += " order by ngay1 desc, a.maql desc";
                    }
                    else if (tmn_Khoatonghop.Checked && !v_thanhtoannhieudot_trongkhoa)
                    {
                        sql = "select a.maql, a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.ngay,'yyyymmddhh24mi') as ngay1, a.makp,a.madoituong,loaiba as loaibn, case when b.chandoan is null then a.chandoan else b.chandoan end as chandoan,case when b.maicd is null then a.maicd else b.maicd end as maicd,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra  from medibv.benhandt a left join medibv.xuatvien b on a.maql=b.maql where a.mabn='" + amabn + "' order by ngay1 desc,a.maql desc";
                    }
                    else
                    {
                        sql = "select a.maql, a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.ngay,'yyyymmddhh24mi') as ngay1, a.makp,a.madoituong,loaiba as loaibn, case when b.chandoan is null then a.chandoan else b.chandoan end as chandoan,case when b.maicd is null then a.maicd else b.maicd end as maicd, to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra  from medibv.benhandt a left join medibv.xuatvien b on a.maql=b.maql where a.mabn='" + amabn + "' order by ngay1 desc,a.maql desc";
                    }
                    ads1 = m_v.get_data(sql);
                }
                if (ads1 != null)
                {
                    if (ads == null)
                    {
                        ads = ads1;
                    }
                    else if (ads1.Tables[0].Rows.Count > 0)
                    {
                        ads.Merge(ads1);
                    }
                }
                ads2 = ads.Clone();
                foreach (DataRow r in ads.Tables[0].Select("", "ngay1 desc,maql desc"))
                    ads2.Tables[0].Rows.Add(r.ItemArray);

                cbNgayvv.DisplayMember = "NGAY";
                cbNgayvv.ValueMember = "MAQL";
                cbNgayvv.DataSource = ads2.Tables[0];
                if (v_maql != "")
                {
                    try
                    {
                        cbNgayvv.SelectedValue = v_maql;
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_CB_Ngayvv()");
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (!kiemtra())
            {
                return;
            }
            if (v_tachhoadon_dv == "")
            {
                f_Luu();
            }
            else
            {
                DataSet ds = new DataSet();
                DataSet ds_tamung = m_dstamung.Clone();
                ds = m_dshoadon.Copy();
                decimal i_tamungdv = 0;
                ds.Clear();
                //
                string s_exp = "madoituong in (" + v_tachhoadon_dv + ")";
                //if (bThuchiRaVien_TachHDGTGT_TheoVAT) s_exp += " and vat>0 ";
                //
                foreach (DataRow rct in m_dshoadon.Tables[0].Select(s_exp)) //foreach (DataRow rct in m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")"))
                {
                    DataRow r_ds = ds.Tables[0].NewRow();
                    r_ds["ngay"] = rct["ngay"].ToString() == "" ? "0" :rct["ngay"].ToString();
                    r_ds["ma"] = rct["ma"].ToString() == "" ? "0" : rct["ma"].ToString();
                    r_ds["ten"] = rct["ten"].ToString() == "" ? "0" : rct["ten"].ToString();
                    r_ds["dvt"] = rct["dvt"].ToString() == "" ? "0" : rct["dvt"].ToString();
                    r_ds["soluong"] = rct["soluong"].ToString() == "" ? "0" :rct["soluong"].ToString();
                    r_ds["dongia"] = rct["dongia"].ToString() == "" ? "0" : rct["dongia"].ToString();
                    r_ds["miendt"] = rct["miendt"].ToString() == "" ? "0" : rct["miendt"].ToString();
                    r_ds["vat"] = rct["vat"].ToString() == "" ? "0" : rct["vat"].ToString();
                    r_ds["sotien"] = rct["sotien"].ToString() == "" ? "0" : rct["sotien"].ToString();
                    r_ds["bhyttra"] = rct["bhyttra"].ToString() == "" ? "0" : rct["bhyttra"].ToString() ;
                    r_ds["bntra"] = rct["bntra"].ToString()== "" ? "0" :rct["bntra"].ToString();
                    r_ds["mavp"] = rct["mavp"].ToString() == "" ? "0" :rct["mavp"].ToString();
                    r_ds["madoituong"] = rct["madoituong"].ToString() == "" ? "0" :rct["madoituong"].ToString();
                    r_ds["vattu"] = rct["vattu"].ToString() == "" ? "0" :rct["vattu"].ToString();
                    r_ds["doituong"] = rct["doituong"].ToString() == "" ? "0" : rct["doituong"].ToString();
                    r_ds["tenkp"] = rct["tenkp"].ToString() == "" ? "0" : rct["tenkp"].ToString();
                    r_ds["giamua"] = rct["giamua"].ToString() == "" ? "0" : rct["giamua"].ToString();
                    r_ds["chenhlech"] = rct["chenhlech"].ToString() == "" ? "0" : rct["chenhlech"].ToString();
                    r_ds["makp"] = rct["makp"].ToString() == "" ? "0" : rct["makp"].ToString();
                    r_ds["id_loai"] = rct["id_loai"].ToString()=="" ? "0" :rct["id_loai"].ToString();
                    r_ds["idchidinh"] = rct["idchidinh"].ToString() == "" ? "0" : rct["idchidinh"].ToString();
                    r_ds["onpaid"] = rct["onpaid"].ToString() == "" ? "0" : rct["onpaid"].ToString();
                    r_ds["idtonghop"] = rct["idtonghop"].ToString() == "" ? "0" : rct["idtonghop"].ToString();
                    r_ds["stttonghop"] = rct["stttonghop"].ToString() == "" ? "0" : rct["stttonghop"].ToString();
                    ds.Tables[0].Rows.Add(r_ds);
                    m_dshoadon.Tables[0].Rows.Remove(rct);
                }
                
                foreach (DataRow r_tu in m_dstamung.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")"))
                {
                    DataRow r = ds_tamung.Tables[0].NewRow();
                    r["chon"] = r_tu["chon"].ToString();
                    r["ngay"] = r_tu["ngay"].ToString();
                    r["sohieu"] = r_tu["sohieu"].ToString();
                    r["sobienlai"] = r_tu["sobienlai"].ToString();
                    r["sotien"] = r_tu["sotien"].ToString();
                    r["user"] = r_tu["user"].ToString();
                    r["done"] = r_tu["done"].ToString();
                    r["id"] = r_tu["id"].ToString();
                    r["quyenso"] = r_tu["quyenso"].ToString();
                    r["makp"] = r_tu["makp"].ToString();
                    r["madoituong"] = r_tu["madoituong"].ToString();

                    i_tamungdv += decimal.Parse(r_tu["sotien"].ToString());
                    ds_tamung.Tables[0].Rows.Add(r);
                    m_dstamung.Tables[0].Rows.Remove(r_tu);
                }
                //f_Luu(false, m_dshoadon.Tables[0].Select("madoituong not in (" + v_tachhoadon_dv + ") and dichvu=0" + exp));
               
                if (m_dshoadon.Tables[0].Rows.Count > 0)
                {
                    //.ToString("###,###,##0.##");
                    //decimal.Parse(txtTamung.Text.Replace(",", ""));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTamung.Text = (decimal.Parse(txtTamung.Text.Replace(",", "")) - i_tamungdv).ToString("###,###,##0.##");
                    }
                    f_Tinhtien();
                    f_Luu(false);
                }
                if (m_dshoadon.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    f_Load_Tamung(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString(), false);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (bThuchiRaVien_TachHDGTGT_TheoVAT == false)
                    {
                        m_dshoadon.Clear();
                        m_dshoadon = ds.Copy();
                        dgHoadon.DataSource = m_dshoadon.Tables[0];
                        if (!b_sua && !b_huykembldv) m_id = "";
                        else if (!b_sua && b_huykembldv) m_id = "-" + m_id;

                        f_Tinhtien();
                        f_Luu(true);
                    }
                    else
                    {
                        if (ds.Tables[0].Select("VAT=0").Length > 0)
                        {
                            m_dshoadon.Clear();
                            //VAT 0%
                            foreach (DataRow dr0 in ds.Tables[0].Select("VAT=0"))
                            {
                                m_dshoadon.Tables[0].Rows.Add(dr0.ItemArray);
                            }
                            m_dshoadon.AcceptChanges();
                            if (m_dshoadon.Tables[0].Rows.Count > 0)
                            {
                                dgHoadon.DataSource = m_dshoadon.Tables[0];
                                if (!b_sua && !b_huykembldv) m_id = "";
                                else if (!b_sua && b_huykembldv) m_id = "-" + m_id;

                                f_Tinhtien();
                                f_Luu(true);
                            }
                        }
                        if (ds.Tables[0].Select("VAT=5").Length > 0)
                        {
                            m_dshoadon.Clear();
                            //VAT 5%
                            foreach (DataRow dr0 in ds.Tables[0].Select("VAT=5"))
                            {
                                m_dshoadon.Tables[0].Rows.Add(dr0.ItemArray);
                            }
                            m_dshoadon.AcceptChanges();
                            if (m_dshoadon.Tables[0].Rows.Count > 0)
                            {
                                dgHoadon.DataSource = m_dshoadon.Tables[0];
                                if (!b_sua && !b_huykembldv) m_id = "";
                                else if (!b_sua && b_huykembldv) m_id = "-" + m_id;

                                f_Tinhtien();
                                f_Luu(true);
                            }
                        }
                        if (ds.Tables[0].Select("VAT=10").Length > 0)
                        {
                            //VAT 10%
                            m_dshoadon.Clear();
                            foreach (DataRow dr0 in ds.Tables[0].Select("VAT=10"))
                            {
                                m_dshoadon.Tables[0].Rows.Add(dr0.ItemArray);
                            }
                            m_dshoadon.AcceptChanges();
                            if (m_dshoadon.Tables[0].Rows.Count > 0)
                            {
                                dgHoadon.DataSource = m_dshoadon.Tables[0];
                                if (!b_sua && !b_huykembldv) m_id = "";
                                else if (!b_sua && b_huykembldv) m_id = "-" + m_id;

                                f_Tinhtien();
                                f_Luu(true);
                            }
                        }

                    }
                    if (TTRV_PhieuTTVP.Checked)
                    {
                        m_frmprinthd.f_Print_Bienlai_ThuongNT(!tmn_Xemtruockhiin_Icon.Checked, m_maql, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "3", m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")").Length > 0);
                    }
                }
            }
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
                    m_dshoadon_nhomvp = null;
                    f_Load_Hoadon(m_id, "");
                }
                else
                {
                    m_dshoadon.Tables[0].Rows.Clear();
                    f_Clear_pTonghop();
                  //  f_Tinhtien();
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
                cbDoituong.SelectedValue = cbDoituongTD.SelectedValue;
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituongTD.DataSource]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString()))
                {
                    txtTN.Enabled = (r["ngay"].ToString() == "1") && m_bnmoi;
                    txtDN.Enabled = txtTN.Enabled;
                    
                    txtNDK_Ma.Enabled = (r["mabv"].ToString() == "1") && m_bnmoi;
                    txtNDK_Ten.Enabled = txtNDK_Ma.Enabled;

                    try
                    {
                        txtSothe.MaxLength = int.Parse(r["sothe"].ToString());
                    }
                    catch
                    {
                        txtSothe.MaxLength = 20;
                    }
                    try
                    {
                        txtSothe.Enabled = (int.Parse(r["sothe"].ToString()) > 0 && m_bnmoi);
                    }
                    catch
                    {
                        txtSothe.Enabled = false;
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
                        string s = txtMabn.Text;
                        if (s.Length >= 3)
                        {
                            txtMabn.Text = s.Substring(0, 2);
                            txtMabn1.Text = s.Substring(2);
                            txtMabn1_Validated(sender, e);
                        }
                    }
                    //txtMabn_Validated(null,null);
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
                    //if (txtNgaysinh.Text != "")
                    //{
                    //    cbGioitinh.Focus();
                    //    SendKeys.Send("{F4}");
                    //}
                    //else
                    //{
                        SendKeys.Send("{Tab}");
                    //}
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSothe.Text.Trim() == "")
                    {
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

        private void txtTN_KeyDown(object sender, KeyEventArgs e)
        {      
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtNDK_Ma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtNDK_Ten_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)          SendKeys.Send("{Tab}{F4}");
        }

        private void cbNgayvv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbLoaibn_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}{F4}");
  
        }

        private void cbDoituongTD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbDoituongTD_SelectedIndexChanged(null, null);
                    if (txtSothe.Enabled)
                    {
                        txtSothe.Focus();
                    }
                    else
                    {
                        txtTenvp.Focus();
                    }
                }
            }
            catch
            {
            }

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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (butLuu.Enabled)
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
                {
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
                        {
                            if (dgGia.RowCount > 0)
                            {
                                aid = dgGia.RowCount - 1;
                                dgGia.Rows[aid].Selected = true;
                                dgGia.CurrentCell = dgGia.Rows[aid].Cells[1];
                                SendKeys.Send("{End}");
                            }
                        }
                    }
                    else
                    {
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
                            {
                                if (dgGia.RowCount > 0)
                                {
                                    aid = 0;
                                    dgGia.Rows[aid].Selected = true;
                                    dgGia.CurrentCell = dgGia.Rows[aid].Cells[1];
                                    SendKeys.Send("{End}");
                                }
                            }
                        }
                        else
                        {
                            if (e.KeyCode == Keys.Escape)
                            {
                                dgGia.Visible = !dgGia.Visible;
                            }
                        }
                    }
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
                    decimal asoluong= 0;
                    try
                    {
                        asoluong = decimal.Parse(txtSoluong.Text);
                    }
                    catch { asoluong = 0; }
                    if (asoluong == 0) 
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập số luợng."));
                        txtSoluong.Focus();
                        return;
                    }
                    f_Get_Item();
                    if (txtDongia.Text != "" && txtDongia.Text != "0")
                    {
                        butAdd_Click(null,null);
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
                    //f_Get_Item();
                    decimal asoluong = 0;
                    try
                    {
                        asoluong = decimal.Parse(txtSoluong.Text);
                    }
                    catch { asoluong = 0; }
                    if (asoluong != 0 && txtDongia.Text != "")
                    {
                        butAdd.Focus();
                    }
                    else
                    if(asoluong != 0)//if (txtSoluong.Text != "" || txtSoluong.Text != "0")
                    {
                        //txtSoluong.Text = "1";
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butAdd.Focus();
                }
            }
            catch
            {
            }
        }

        private void cbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butAdd.Focus();
                }
            }
            catch
            {
            }
        }

        private void cbBacsi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butAdd.Focus();
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
            //try
            //{
            //    //int i = int.Parse(txtMabn1.Text.Trim());
            //    //if (i >= 0 && i <= 999999)
            //    //{
            //    //    txtMabn1.Text = i.ToString().PadLeft(6, '0');
            //    //}
            //    //else
            //    //{
            //    //    txtMabn1.Text = "";
            //    //}
            //    txtMabn1.Text = txtMabn1.Text.PadLeft(6, '0');
            //}
            //catch
            //{
            //    txtMabn1.Text = "";
            //}
            if (bChonhapmoi == true && m_mabntudong == true && txtMabn1.Text.Trim().Trim('0') == "")
            {
                string atmp = "";
                for (; ; )
                {
                    atmp = m_v.get_cap_mabn(txtNgaythu.Text.Substring(8, 2));
                    if (m_v.get_data("select mabn from " + m_v.user + ".btdbn where mabn='" + atmp + "'").Tables[0].Rows.Count == 0) break;
                }
                txtMabn.Text = atmp.Substring(0, 2);
                txtMabn1.Text = atmp.Substring(2);
            }
            try
            {
                txtMabn1.Text = txtMabn1.Text.PadLeft(6, '0');
            }
            catch
            {
                txtMabn1.Text = "";
            }
            if (m_Docmavach)
            {
                string s = txtMabn1.Text;
                if (s.Length >6)
                {
                    txtMabn.Text = s.Substring(0, 2);
                    txtMabn1.Text = s.Substring(2);
                    txtMabn1.Text = txtMabn1.Text.PadLeft(6, '0');//(6, '0');
                }
            }
            if (txtMabn.Text.Length == 2 && txtMabn1.Text.Length >= 3)
            {
                s_maql_captoa = "";
                f_Load_Hanhchanh(txtMabn.Text+txtMabn1.Text);
            }
        
        }
        //gam 06/09/2011 load thêm khoa ra viện
        private void f_load_cbKhoarv( string a_maql)
        {
            try
            {
                string mmyy = m.mmyy(cbNgayvv.Text.ToString().Substring(0, 10));
                string sql = "select makp from ( ";
                sql += " select makp,ngay from medibv.xuatvien where maql=" + (a_maql != "" ? a_maql : "0") + " and mabn='" + (txtMabn.Text + txtMabn1.Text) + "' ";
                sql += " union ";
                sql += " select b.makp,a.ngay from medibv.xuatkhoa a inner join medibv.nhapkhoa b on a.id=b.id where b.maql=" + (a_maql != "" ? a_maql : "0") + " and b.mabn='" + (txtMabn.Text + txtMabn1.Text) + "'";
                sql += " ) as a order by ngay desc ";
                DataSet ds = m_v.get_data(sql);
                if (ds.Tables[0].Rows.Count>0)
                {
                    cbKhoarv.SelectedValue = ds.Tables[0].Rows[0]["makp"].ToString();
                    txtKhoarv.Text = ds.Tables[0].Rows[0]["makp"].ToString();
                }
                //Thuy 12/12/2011.
                if (ds.Tables[0].Rows.Count == 0)
                {
                    sql = "select makp from medibv" + mmyy + ".benhancc where maql=" + (a_maql != "" ? a_maql : "0") + " and mabn='" + (txtMabn.Text + txtMabn1.Text) + "' ";
                    sql += " and ttlucrv != 5";
                    DataSet dspl = m_v.get_data(sql);
                    if (dspl != null)
                    {
                        cbKhoarv.SelectedValue = dspl.Tables[0].Rows[0]["makp"].ToString();
                        txtKhoarv.Text = dspl.Tables[0].Rows[0]["makp"].ToString();
                    }
                }
                //end Thuy.

            }
            catch {  }
        }
        //end gam

        private void cbNgayvv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNgayvv.DataSource]);
                DataView dv = (DataView)(cm.List);
                v_idkhoa = "";
                foreach (DataRow r in dv.Table.Select("maql='" + cbNgayvv.SelectedValue.ToString()+"'"))
                {
                    cbLoaibn.SelectedValue = r["loaibn"].ToString();
                    cbKhoavv.SelectedValue = r["makp"].ToString();
                    txtKhoavv.Text = r["makp"].ToString();
                    //cbKhoarv.SelectedValue = r["makp"].ToString();
                    //txtKhoarv.Text = r["makp"].ToString();
                    f_load_cbKhoarv(cbNgayvv.SelectedValue.ToString());//gam 06/09/2011
                    cbKhoa.SelectedValue = r["makp"].ToString();
                    cbDoituong.SelectedValue = r["madoituong"].ToString();
                    cbDoituongTD.SelectedValue = r["madoituong"].ToString();
                    txtICD.Text = r["maicd"].ToString();
                    txtChandoan.Text = r["chandoan"].ToString();
                    txtNgayrv.Text = r["ngayra"].ToString();

                    if (txtNgayrv.Text.Trim() == "")
                    {
                        txtNgayrv.Text = txtNgaythu.Text.Substring(0, 16);
                    }
                    m_mavaovien = decimal.Parse(r["mavaovien"].ToString()).ToString();
                    m_maql = decimal.Parse(r["maql"].ToString()).ToString();
                    s_makp_luu = r["makp"].ToString();
                    f_Load_BHYT();
                    if (tmn_thanhtoantheokhoa.Checked || v_thanhtoannhieudot_trongkhoa)
                    {
                        if (m_id != "" && m_id != "0")
                        {
                            f_load_BC_Ngayrv(false);
                            if (m_idkhoa == "" && m_idkhoa == "0")
                            {
                                try
                                {
                                    m_idkhoa = m_v.get_data_mmyy("select idkhoa from medibvmmyy.v_thvpll where id=" + cbNgayrv.SelectedValue.ToString() + "", cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), false).Tables[0].Rows[0]["idkhoa"].ToString();
                                }
                                catch { }
                            }
                            cbNgayrv_SelectedIndexChanged(null, null);
                            v_idkhoa = " idkhoa=" + m_idkhoa + " and ";
                        }
                        else
                        {
                            f_load_BC_Ngayrv(true);
                            if (!v_loadcho)
                            {
                                f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString(), false);
                            }
                            cbNgayrv_SelectedIndexChanged(null, null);
                            if (m_idkhoa == "" || m_idkhoa == "0")
                            {
                                try
                                {
                                    m_idkhoa = m_v.get_data_mmyy("select idkhoa from medibvmmyy.v_thvpll where id=" + m_id_thvpll + "", cbNgayvv.Text.Substring(0, 10), txtNgayrv.Text.Substring(0, 10), false).Tables[0].Rows[0]["idkhoa"].ToString();
                                }
                                catch { }
                            }
                            v_idkhoa = " idkhoa=" + m_idkhoa + " and ";
                        }
                    }
                    else
                    {
                        if (m_id == "" || m_id == "0")
                            f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString(), false);
                        v_idkhoa = "";
                    }
                    break;
                }
            }
            catch
            {
                m_mavaovien = "";
                m_maql = "";
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
                toolStripSplitButton1.ShowDropDown();
                return;
            }
            if (tmn_Luuin_Hoadon.Checked)
            {
                if (v_tachhoadon_dv != "")
                {
                    if (m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")").Length > 0)
                        f_Inhoadon(true);
                    else
                        f_Inhoadon(false);
                }
                else
                    f_Inhoadon(false);
            }
            if (tmn_Luuin_Phieuthuchi.Checked)
            {
                f_Inphieuthuchi();
            }
            if (TTRV_PhieuTTVP.Checked)
            {
                // m_frmprinthd.f_Print_Bienlai_ThuongNT(!tmn_Xemtruockhiin_Icon.Checked,m_maql, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "3", m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")").Length > 0);
                if (v_tachhoadon_dv == "")
                {
                    m_frmprinthd.f_Print_Bienlai_ThuongNT(!tmn_Xemtruockhiin_Icon.Checked, m_maql, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "3", true);

                }
                else
                {
                    m_frmprinthd.f_Print_Bienlai_ThuongNT(!tmn_Xemtruockhiin_Icon.Checked, m_maql, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "3", m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ")").Length > 0);
                }
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

        private void frmThuchiravien_SizeChanged(object sender, EventArgs e)
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
                txtNgaythu.Enabled = false;        
                if (txtNgaythu.Enabled == false)
                {
                    if (chkThuong.Checked)
                    {
                        m_cur_ngay_thuong = txtNgaythu.Value;
                        try
                        {

                            m_cur_loaidv_thuong = cbLoaidv.SelectedValue.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (m_cur_quyenso_thuong != "" && m_cur_quyenso_thuong != cbKyhieu.SelectedValue.ToString())
                            {
                                m_v.execute_data("update medibv.v_quyenso set dangsd=0 where id=" + m_cur_quyenso_thuong);
                            }
                            m_cur_quyenso_thuong = cbKyhieu.SelectedValue.ToString();
                            if (m_cur_quyenso_thuong != "")
                            {
                                m_v.execute_data("update medibv.v_quyenso set dangsd=1 where id=" + m_cur_quyenso_thuong);
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
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

        private void frmThuchiravien_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                dgGia.BackgroundColor = Color.LightYellow;
                if (dgGia.Visible)
                {
                    cbDoituong_Validated(null, null);
                }
            }
            catch
            {
            }
        }

        private void cbDoituong_Validated(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituong.DataSource]);
                DataView dv = (DataView)(cm.List);
                string afield = dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString())[0]["field_gia"].ToString().ToUpper().Trim();

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
                //if (txtSoluong.Text == "" || txtSoluong.Text == "0")
                //{
                //    txtSoluong.Text = "1";
                //}
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
                txtSoluong.Text = "";
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
                txtSoluong.Text = "";
                txtDongia.Text = "0";
                f_Filter_Giavp();
                //txtTenvp.Focus();
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
                //MessageBox.Show(aindex);
                switch (aindex)
                {
                    case "5"://SL
                    case "6"://Dongia
                    case "7"://VAT
                    case "8"://Vattu
                        f_Tinhtien();
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
                txtTuoi.Text="1";
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
                //ngay_or_nam:tuoi:thang:ngay
                //MessageBox.Show(atmp);
                //txtNgaysinh.Text = "";
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
        
       
        private void f_Chon(string v_keycode)
        {
            try
            {
                if (butLuu.Enabled)
                {
                    if (cbKhoa.SelectedIndex < 0)
                    {
                        cbKhoa.Focus();
                        SendKeys.Send("{F4}");
                        return;
                    }
                    if (cbDoituong.SelectedIndex < 0)
                    {
                        cbDoituong.Focus();
                        SendKeys.Send("{F4}");
                        return;
                    }


                    CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituong.DataSource]);
                    DataView dv = (DataView)(cm.List);
                    DataRow r = dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString())[0];
                    m_frmchonvp.s_field_gia = r["field_gia"].ToString();
                    m_frmchonvp.s_title = (txtMabn.Text + txtMabn1.Text + " - " + txtHoten.Text.Trim() + " - " + txtNgaysinh.Text.Trim() + " - " + cbGioitinh.Text.Trim());
                    m_frmchonvp.s_hotkey = v_keycode;
                    m_frmchonvp.s_chochon = butLuu.Enabled;                  
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


                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhấn nút ") + (m_id == "" ? lan.Change_language_MessageText("Mới") : lan.Change_language_MessageText("Sửa")) + lan.Change_language_MessageText(" trước khi chọn viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmThuchiravien_KeyDown(object sender, KeyEventArgs e)
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
            f_Tinhtien();
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
                    dgHoadon.Columns["Column_0"].ToolTipText = lan.Change_language_MessageText("Đánh dấu những mục cần in:")+" " + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString();
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
                pHanhchanh.Height = v_bool?25:180;
                if (tmn_Nhapkymien.Checked || tmn_Nhaplydomien.Checked)
                {
                    pHanhchanh.Height = v_bool ? 48 : 180;
                }
            }
            catch
            {
            }
        }
        
        private void toolStrip_Title_Click(object sender, EventArgs e)
        {
            try
            {
                pHanhchanh.Height = (pHanhchanh.Height > 100)?25:139;
                m_v.set_o_fullscreen_frmthuchiravien(m_userid, pHanhchanh.Height > 100 ? false : true);
                m_o_fullscreen = m_v.get_o_fullscreen_frmthuchiravien(m_userid);
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
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbKymien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (butLuu.Enabled)
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

        private void txtLydomien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cbLydomien.SelectedValue=txtLydomien.Text;
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
                //if (butMoi.Enabled) butMoi_Click(null, null);//binh
                frmDanhsachchothuchiravien m_frmdanhsachchothuchiravien = new frmDanhsachchothuchiravien(m_v, m_userid, v_doituongthu, v_khoaphongthu);
                m_frmdanhsachchothuchiravien.ShowInTaskbar = false;
                m_frmdanhsachchothuchiravien.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachchothuchiravien.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachchothuchiravien.s_mabn != "")
                    {
                        string atmp = m_frmdanhsachchothuchiravien.s_mabn;
                        f_Moi();//binh 120511
                        v_loadcho = true;
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                        if (m_frmdanhsachchothuchiravien.s_maql != "")
                        {
                            //f_Load_CB_Ngayvv(m_frmdanhsachchothuchiravien.s_ngaycd, m_frmdanhsachchothuchiravien.s_maql);
                            cbNgayvv.SelectedValue = m_frmdanhsachchothuchiravien.s_maql;
                            f_Load_Chidinh(m_frmdanhsachchothuchiravien.s_ngaycd, m_frmdanhsachchothuchiravien.s_maql,false);
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
                m_frmtimhoadon.s_loaihd = m_v.s_loaiform_thuchiravien;
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
                frmDanhsachthuchiravien m_frmdanhsachthuchiravien = new frmDanhsachthuchiravien(m_v, m_userid);
                m_frmdanhsachthuchiravien.ShowInTaskbar = false;
                m_frmdanhsachthuchiravien.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachthuchiravien.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachthuchiravien.s_id != "")
                    {
                        txtMabn.Enabled = false;//Thuy 15.12.2011
                        txtMabn1.Enabled = false;//Thuy 15.12.2011
                        m_id = m_frmdanhsachthuchiravien.s_id;
                        f_Load_Hoadon(m_id, m_v.get_mmyy(m_frmdanhsachthuchiravien.s_ngaythu.Substring(0, 10)));
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
                cbDoituong.SelectedValue = arv["madoituong"].ToString();
                cbKhoa.SelectedValue = arv["makp"].ToString();
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
                txtSobienlai.ForeColor=txtSobienlai.ReadOnly?Color.Orange:Color.Red;
            }
            catch
            {
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbNgayvv.Items.Count > 0)
                {
                    f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString(), false);
                }
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

                    decimal asoluong = 0;
                    try
                    {
                        asoluong = decimal.Parse(txtSoluong.Text);
                    }
                    catch { asoluong = 0; }
                    if (asoluong == 0) 
                    {
                        txtSoluong.Focus();
                    }
                    else
                    {                        
                        f_Add();
                    }
                }
                else
                    if(e.KeyCode==Keys.Escape)
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
                            //f_Rem();
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
                f_Tinhtien();
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
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
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
                m_v.set_o_fullgrid_frmthuchiravien(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }
         
        private void tmn_Luuin_Hoadon_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_hoadon_frmthuchiravien(m_userid,tmn_Luuin_Hoadon.Checked);
        }
        private void tmn_Xemtruockhiin_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_xemtruockhiin_frmthuchiravien(m_userid, tmn_Xemtruockhiin_Icon.Checked);
        }
        private void tmn_Luuin_Chiphi_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_chiphi_frmthuchiravien(m_userid,tmn_Luuin_Chiphi.Checked);
        }             
        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m_v.Disconnect();
            System.GC.Collect();           
            this.Close();
        }

        private void frmThuchiravien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý kết thúc chức năng thu chi ra viện!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
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

        private void cbDoituongTD_Validated(object sender, EventArgs e)
        {
            cbDoituongTD_SelectedIndexChanged(null, null);
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
                cbDoituong_Validated(null, null);
            }
        }

        private void txtKhoavv_KeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void cbKhoarv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTongBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTongvp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTongcp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtBHYTTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtBNTra_KeyDown(object sender, KeyEventArgs e)
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

        private void txtGDDuyet_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtGDDuyet.Text != "" && txtGDDuyet.Text != "0")
                    {
                        if (tmn_Nhaplydomien.Checked && txtLydomien.Enabled)
                        {
                            txtLydomien.Focus();
                        }
                        else if (tmn_Nhapkymien.Checked && txtKymien.Enabled)
                        {
                            txtKymien.Focus();
                        }
                        else
                        {
                            butLuu.Focus();
                        }
                    }
                    else
                    {
                        txtMienphantram.Focus();
                    }
                    ///SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }
        private void txtMienphantram_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (tmn_Nhaplydomien.Checked && txtLydomien.Enabled)
                    {
                        txtLydomien.Focus();
                    }
                    else if (tmn_Nhapkymien.Checked && txtKymien.Enabled)
                    {
                        txtKymien.Focus();
                    }
                    else
                    {
                        butLuu.Focus();
                    }
                    ///SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtBNThieu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (butLuu.Enabled)
                    {
                        txtPhaithu.Focus();
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

        private void chkChuahoan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butLuu.Focus();
                }
            }
            catch
            {
            }
        }

        private void txtTamung_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_Tong();
        }

        private void txtGDDuyet_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_Tong();
        }

        private void txtBNThieu_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_Tong();
        }
        private void txtPhaithu_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_Tong();
        }

        private void cbKhoavv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKhoavv.Text = cbKhoavv.SelectedValue.ToString();
                if (txtKhoavv.Text.Length > 2)
                {
                    txtKhoavv.Text = "";
                }
            }
            catch
            {
                txtKhoavv.Text = "";
            }
        }

        private void cbKhoarv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKhoarv.Text = cbKhoarv.SelectedValue.ToString();
                if (txtKhoarv.Text.Length > 2)
                {
                    txtKhoarv.Text = "";
                }
            }
            catch
            {
                txtKhoarv.Text = "";
            }
        }

        private void txtNgayrv_Validated(object sender, EventArgs e)
        {
            try
            {
                txtNgayrv.Text = m_v.f_string_date(txtNgayrv.Text);
                if (txtNgayrv.Text.Length < 10)
                {
                    txtNgayrv.Text = txtNgaythu.Text.Substring(0, 10);
                }
                txtSongayDT.Text=m_v.get_songay(cbNgayvv.Text.Substring(0,10),txtNgayrv.Text.Substring(0,10)).ToString();
            }
            catch
            {
                txtNgayrv.Text = txtNgaythu.Text.Substring(0, 10);
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
                    f_Tinhtien_Tong();
                }
            }
            catch
            {
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {
            f_Tinhtien();
        }

        private void txtMienphantram_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal apt = 0, abntra = 0,amien=0;
                try
                {
                    apt = decimal.Parse(txtMienphantram.Text);
                }
                catch
                {
                    apt = 0;
                }
                if (apt < 0 || apt > 100)
                {
                    apt = 0;
                }
                try
                {
                    abntra = decimal.Parse(txtBNTra_VP.Text.Replace(",", ""));
                }
                catch
                {
                    abntra = 0;
                }
                if (abntra < 0)
                {
                    abntra = 0;
                }
                amien = Math.Round(abntra * apt/100,2);
                txtGDDuyet.Text = amien.ToString("###,###,##0.##");
                f_Tinhtien_Tong();
            }
            catch
            {
            }
        }

        private void tmn_Luuin_Phieuthuchi_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_phieuthuphieuchi_frmthuchiravien(m_userid, tmn_Luuin_Phieuthuchi.Checked);
        }

        private void tmn_Luuin_Hoadon_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_frmthuchiravien(m_userid, tmn_Luuin_Hoadon_Icon.Checked);
        }

        private void txtPhaithu_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (butLuu.Enabled)
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

        private void tmn_Nhaplydomien_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lbLydomien.Visible = tmn_Nhaplydomien.Checked;
                txtLydomien.Visible = lbLydomien.Visible;
                cbLydomien.Visible = lbLydomien.Visible;
            }
            catch
            {
            }
        }

        private void tmn_Nhapkymien_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lbDuyetmien.Visible = tmn_Nhapkymien.Checked;
                txtKymien.Visible = lbDuyetmien.Visible;
                cbKymien.Visible = lbDuyetmien.Visible;
            }
            catch
            {
            }
        }

        private void chkThuong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkThuong.Checked)
                {
                    if (m_cur_loaidv_thuong == "" || m_cur_quyenso_thuong == "")
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chọn thông tin thu viện phí nội bộ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoaidv.Enabled = false;
                        lbKyhieu_Click(null, null);
                        cbLoaidv.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    {
                        cbLoaidv.SelectedValue = m_cur_loaidv_thuong;
                        cbLoaidv_Validated(null, null);
                        cbKyhieu.SelectedValue = m_cur_quyenso_thuong;
                    }
                }
                else
                {
                    if (m_cur_loaidv == "" || m_cur_quyenso == "")
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chọn thông tin thu viện phí nội bộ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoaidv.Enabled = false;
                        lbKyhieu_Click(null, null);
                        cbLoaidv.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    {
                        cbLoaidv.SelectedValue = m_cur_loaidv;
                        cbLoaidv_Validated(null, null);
                        cbKyhieu.SelectedValue = m_cur_quyenso;
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Nhaplydomien_Click(object sender, EventArgs e)
        {

        }

        private void cbNgayrv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string amakp = "";
                CurrencyManager mc = (CurrencyManager)BindingContext[cbNgayrv.DataSource];
                DataView dv = (DataView)mc.List;
                m_id_thvpll = cbNgayrv.SelectedValue.ToString();
                foreach (DataRow r in dv.Table.Select("id=" + m_id_thvpll + ""))
                {
                    amakp = r["makp"].ToString();
                    try
                    {
                        cbKhoarv.SelectedValue = amakp;
                    }
                    catch
                    {
                        cbKhoarv.SelectedIndex = 0;
                    }
                    try
                    {
                        cbKhoavv.SelectedValue = amakp;
                    }
                    catch
                    {
                        cbKhoavv.SelectedIndex = 0;
                    }
                    m_idkhoa = r["idkhoa"].ToString();
                    m_idthuoc = r["idthuoc"].ToString();
                    txtSothe.Text = r["sothe"].ToString();
                    txtNDK_Ma.Text = r["mabv"].ToString();
                    txtNDK_Ten.Text = r["tenbv"].ToString();
                    
                    cmbTraituyen.SelectedIndex = r["traituyen"].ToString()==""?0:int.Parse(r["traituyen"].ToString());
                    if (m_id == "" || m_id == "0")
                    {
                        f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString(), false);//True
                    }
                    break;
                }
            }
            catch { }
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

        private void butOptionIn_Click(object sender, EventArgs e)
        {
            contextMenuIN.Show(butOptionIn, new Point(butOptionIn.ClientRectangle.Left + butOptionIn.Width, butOptionIn.ClientRectangle.Bottom - contextMenuIN.Items.Count * 20 - 24));
        }

        private void TTRV_HDDacthu_Click(object sender, EventArgs e)
        {            
            TTRV_HDDacthu.Checked = !TTRV_HDDacthu.Checked;
            m_v.set_ttrv_InHDdacthu(m_userid, TTRV_HDDacthu.Checked);
        }

        private void TTRV_HDChitiet_Click(object sender, EventArgs e)
        {
            TTRV_HDChitiet.Checked = !TTRV_HDChitiet.Checked;
            m_v.set_ttrv_InHDchitiet(m_userid, TTRV_HDChitiet.Checked);
        }

        private void txtSobienlai_KeyPress(object sender, KeyPressEventArgs e)
        {
            m_v.MaskDecimal(e);
        }

        private void txtTamung_KeyPress(object sender, KeyPressEventArgs e)
        {
            m_v.MaskDecimal(e);
        }

        private void txtGDDuyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            m_v.MaskDecimal(e);
        }

        private void toolStrip_Mien_KeyPress(object sender, KeyPressEventArgs e)
        {
            m_v.MaskDecimal(e);
        }

        private void txtBNThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            m_v.MaskDecimal(e);
        }

        private void chkBNthieu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBNthieu.Checked)
            {
               // txtBNThieu.Text = toolStrip_Thucthu.Text;
                chkBNThua.Checked = false;
            }
            else
                txtBNThieu.Text = "0";
            f_Tinhtien_Tong();
        }

        private void chkBNThua_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBNThua.Checked) chkBNthieu.Checked = false;
        }

        private void lblThieu_Click(object sender, EventArgs e)
        {
            try
            {
                frmBNthieu f = new frmBNthieu(m_v, m_userid, txtMabn.Text + txtMabn1.Text, txtNgaythu.Text.Substring(0, 16));
                f.ShowInTaskbar = false;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    m_dsthieu = f.s_ds;
                    decimal asotien = 0, atmp = 0;
                    m_id_ttrvthatthu = "";
                    foreach (DataRow r in m_dsthieu.Tables[0].Rows)
                    {
                        try
                        {
                            m_id_ttrvthatthu = r["id"].ToString();
                            atmp = decimal.Parse(r["sotientra"].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        asotien += atmp;
                        m_id_ttrvthatthu += m_id_ttrvthatthu + ",";
                    }
                    txtBNtraNO.Text = asotien.ToString("###,###,##0.##");
                }
                f_Tinhtien_Tong();
            }
            catch
            {
 
            }
        }

        private void txtBNtraNO_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_Tong();
        }

        private void txtBNtraNO_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (butLuu.Enabled)
                    {
                        txtThucthu_No.Focus();
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

        private void lblThua_Click(object sender, EventArgs e)
        {
            try
            {
                frmBNthua f = new frmBNthua(m_v, m_userid, txtMabn.Text + txtMabn1.Text, txtNgaythu.Text.Substring(0, 16));
                f.ShowInTaskbar = false;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    m_dsthua = f.s_ds;
                    decimal asotien = 0, atmp = 0;
                    m_id_ttrvthua = "";
                    foreach (DataRow r in m_dsthua.Tables[0].Rows)
                    {
                        try
                        {
                            m_id_ttrvthua = r["id"].ToString();
                            atmp = decimal.Parse(r["sotientra"].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        asotien += atmp;
                        m_id_ttrvthua += m_id_ttrvthua + ",";
                    }
                    txtBVtraNo.Text = asotien.ToString("###,###,##0.##");
                }
                f_Tinhtien_Tong();
            }
            catch
            {

            }
        }

        private bool bBienlai_dasudung(string iQuyenso, string iSobienlai)
        {
            string suser = m_v.user;
                string asql = "select * from " + suser + ".vv_bienlaithuvienphi_" + m_v.get_dmcomputer().ToString().PadLeft(4, '0') + " where quyenso=" + iQuyenso + " and sobienlai=" + iSobienlai;
            DataSet lds = m_v.get_data(asql);
            return lds.Tables[0].Rows.Count > 0;
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
        private void TTRV_PhieuTTVP_Click(object sender, EventArgs e)
        {
            TTRV_PhieuTTVP.Checked = !TTRV_PhieuTTVP.Checked;
            m_v.set_ttrv_InHDchitiet(m_userid, TTRV_HDChitiet.Checked);
        }

        private void madantoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void madantoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == madantoc)
                {
                    tendantoc.SelectedValue = madantoc.Text;
                }
            }
            catch
            {
            }
        }

        private void tendantoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tendantoc.SelectedIndex == -1) tendantoc.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }
        private void ena_nuoc(bool ena)
        {
            manuoc.Enabled = ena;
            tennuoc.Enabled = ena;
        }

        private void tendantoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                madantoc.Text = tendantoc.SelectedValue.ToString();
                if (madantoc.Text == "55") ena_nuoc(true);
                else
                {
                    ena_nuoc(false);
                    tennuoc.SelectedValue = "VN";
                }
            }
            catch { madantoc.Text = ""; }
        }

        private void manuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void manuoc_Validated(object sender, EventArgs e)
        {
            try
            {
                tennuoc.SelectedValue = manuoc.Text;
            }
            catch { }
        }

        private void tennuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                manuoc.Text = tennuoc.SelectedValue.ToString();
            }
            catch { manuoc.Text = ""; }
        }

        private void tennuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tennuoc.SelectedIndex == -1) tennuoc.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void mann_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void mann_Validated(object sender, EventArgs e)
        {
            try
            {
                tennn.SelectedValue = mann.Text;
            }
            catch { }
        }

        private void tennn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mann.Text = tennn.SelectedValue.ToString();
            }
            catch { mann.Text = ""; }
        }

        private void tennn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tennn.SelectedIndex == -1) tennn.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void txtTQX_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtTQX.Text.Trim() != "")
                    {
                        f_Load_CB_TQX(txtTQX.Text.Trim());
                        if (cbTQX.Items.Count == 1)
                        {
                            f_Load_T_Q_X(cbTQX.SelectedValue.ToString());
                            txtICD.Focus();
                        }
                        else
                            if (cbTQX.Items.Count > 1)
                            {
                                cbTQX.Focus();
                                SendKeys.Send("{F4}");
                            }
                            else
                            {
                                txtTinh.Focus();
                            }
                    }
                    else
                    {
                        cbTinh.Focus();
                    }
                }
            }
            catch
            {
            }
        }

        private void cbTQX_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cbTQX.Items.Count > 0)
                    {
                        f_Load_T_Q_X(cbTQX.SelectedValue.ToString());
                        txtICD.Focus();
                    }
                    else
                    {
                        txtTinh.Focus();
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Load_T_Q_X(string v_maphuongxa)
        {
            try
            {
                cbTinh.SelectedValue = v_maphuongxa.Substring(0, 3);
                txtTinh.Text = cbTinh.SelectedValue.ToString();
                f_Load_CB_Quan(cbTinh.SelectedValue.ToString());
                cbQuan.SelectedValue = v_maphuongxa.Substring(0, 5);
                txtQuan.Text = cbQuan.SelectedValue.ToString().Substring(3);
                f_Load_CB_Xa(cbQuan.SelectedValue.ToString());
                cbXa.SelectedValue = v_maphuongxa.ToString();
                txtXa.Text = cbXa.SelectedValue.ToString().Substring(5);
            }
            catch
            {
            }
        }

        private void f_Load_CB_Quan(string v_matt)
        {
            try
            {
                cbQuan.DataSource = m_v.get_data("select maqu,tenquan from medibv.btdquan where matt='" + v_matt + "' order by maqu").Tables[0];
                cbQuan.DisplayMember = "tenquan";
                cbQuan.ValueMember = "maqu";
                txtTinh.Text = cbTinh.SelectedValue.ToString();
            }
            catch
            {
            }
        }
        private void f_Load_CB_Xa(string v_maqu)
        {
            try
            {
                cbXa.DataSource = m_v.get_data("select maphuongxa,tenpxa from medibv.btdpxa where maqu='" + v_maqu + "' order by maphuongxa").Tables[0];
                cbXa.DisplayMember = "tenpxa";
                cbXa.ValueMember = "maphuongxa";
                txtQuan.Text = cbQuan.SelectedValue.ToString().Substring(3);
            }
            catch
            {
            }
        }
        private void f_Load_CB_TQX(string v_matat)
        {
            try
            {
                cbTQX.DataSource = m_v.get_data("select a.maphuongxa as ma, c.tentt ||', ' || b.tenquan ||', '|| a.tenpxa as ten from medibv.btdpxa a left join medibv.btdquan b on a.maqu=b.maqu left join medibv.btdtt c on b.matt=c.matt where lower(a.viettat) like lower('%" + v_matat + "%') order by c.tentt, b.tenquan, a.tenpxa").Tables[0];
                cbTQX.DisplayMember = "ten";
                cbTQX.ValueMember = "ma";
            }
            catch
            {
            }
        }

        private void txtTinh_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == txtTinh)
                {
                    cbTinh.SelectedValue = txtTinh.Text;
                }
            }
            catch
            {
            }
        }

        private void cbTinh_KeyDown(object sender, KeyEventArgs e)
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

        private void cbTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtTinh.Text = cbTinh.SelectedValue.ToString();
                f_Load_CB_Quan(txtTinh.Text);
            }
            catch
            {
            }
            if (txtTinh.Text.Length > 3)
            {
                txtTinh.Text = "";
            }
        }

        private void txtQuan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == txtQuan)
                {
                    cbQuan.SelectedValue = (cbTinh.SelectedValue.ToString() + txtQuan.Text);
                }
            }
            catch
            {
            }
        }

        private void txtQuan_KeyDown(object sender, KeyEventArgs e)
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

        private void cbQuan_KeyDown(object sender, KeyEventArgs e)
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

        private void cbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtQuan.Text = cbQuan.SelectedValue.ToString().Substring(3);
                f_Load_CB_Xa(txtTinh.Text + txtQuan.Text);
            }
            catch
            {
            }
            if (txtQuan.Text.Length > 2)
            {
                txtQuan.Text = "";
            }
        }

        private void cbQuan_Validated(object sender, EventArgs e)
        {
            try
            {
                f_Load_CB_Xa(cbQuan.SelectedValue.ToString());
            }
            catch
            {
            }
        }

        private void txtXa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == txtXa)
                {
                    cbXa.SelectedValue = (cbQuan.SelectedValue.ToString() + txtXa.Text);
                }
            }
            catch
            {
            }
        }

        private void txtXa_KeyDown(object sender, KeyEventArgs e)
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

        private void cbXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtXa.Text = cbXa.SelectedValue.ToString().Substring(5);
            }
            catch
            {
            }
            if (txtXa.Text.Length > 2)
            {
                txtXa.Text = "";
            }
        }

        private void cbXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtSonha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtThonpho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtThonpho.Text = m_v.Viettat(txtThonpho.Text) + " ";
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter)
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

        private void txtNamsinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtICD_TextChanged(object sender, EventArgs e)
        {
            listICD.Hide();
        }

        private void txtICD_Validated(object sender, EventArgs e)
        {
            if (txtICD.Text == "" && !txtChandoan.Enabled)
            {
                txtChandoan.Text = "";
                butLuu.Focus();
                return;
            }
            else if (txtICD.Text != "")
            {
                txtChandoan.Text = m.get_vviet(txtICD.Text);
                if (txtChandoan.Text == "" && txtICD.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", txtICD.Text, txtChandoan.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        txtChandoan.Text = f.mTen;
                        txtICD.Text = f.mICD;
                    }
                }
                //s_icd_chinh = txtICD.Text;
            }
        }

        private void txtChandoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }		
        }

        private void txtChandoan_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtChandoan)
            {
                if (txtICD.Text == "" || txtICD.Text.Trim() == "U00")
                {
                    Filt_ICD(txtChandoan.Text);
                    //if (bPhongkham_chandoan)
                    //{
                    //    if (lydo.Enabled) listICD.BrowseToICD10(cd_chinh, icd_chinh, lydo, icd_chinh.Location.X - 421, icd_chinh.Location.Y + icd_chinh.Height - 2, icd_chinh.Width + cd_chinh.Width + 2 + 421, icd_chinh.Height);
                    //    else listICD.BrowseToICD10(cd_chinh, icd_chinh, mabs, icd_chinh.Location.X - 421, icd_chinh.Location.Y + icd_chinh.Height - 2, icd_chinh.Width + cd_chinh.Width + 2 + 421, icd_chinh.Height);
                    //}
                    //else listICD.BrowseToICD10(cd_chinh, icd_chinh, icd_kemtheo, icd_chinh.Location.X - 421, icd_chinh.Location.Y + icd_chinh.Height - 2, icd_chinh.Width + cd_chinh.Width + 2 + 421, icd_chinh.Height);
                    listICD.BrowseToICD10(txtChandoan, txtICD, cbNgayvv, txtICD.Location.X, txtICD.Location.Y + txtICD.Height - 2, txtICD.Width + txtChandoan.Width + 2+421, txtICD.Height);
                }
            }
        }

        private void Filt_ICD(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listICD.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "vviet like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void tmn_InThanhToanRaVien_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_chiphi_frmthuchiravien(m_userid, tmn_InThanhToanRaVien.Checked);
        }
    }
}