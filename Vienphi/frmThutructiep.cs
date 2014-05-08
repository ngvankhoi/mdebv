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
    public partial class frmThutructiep : Form
    {
        private frmGoibenhKham fgoi;// = new frmGoibenhKham();
        private frmReport cMain;
        private int sizestt = 120;
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_mabn = 8, i_trangthai = 0, i_idchinhanhden = -1;
        private string m_cur_yy = "";
        private string m_id_gia = "", m_makp_khongkham="";
        private DateTime m_cur_ngay = DateTime.Now;
        private string m_cur_loaidv = "";
        private bool bbhyt_100_theodoibienlai = false;
        private string m_cur_quyenso = "",sql;
        private bool bAll_days = false, b_sua = false,b_huykembldv = false;// b_huykenbldv neu gia tri bằng true thì khi huy bien lai 
        //tự động hủy luôn biên lai đã được tách ( nếu có ) option in hoa don dich vu
        private bool bInphieumiengiam = false;// gam hepa in phieu mien giam
        private int iTreem6, iTreem15, ichinhanh;
        private string v_tachhoadon_dv = "";
        private bool bKhongchoxem_tongthu = false, bQuanly_Theo_Chinhanh = false,btt_Thutungdonthuoc = false;
        private bool bKhongthu_tutruc_phongluu = false, bKhongthu_tutruc_noitru = false;
        private bool blamtron = false;//gam 18/10/2011

        private LibVP.AccessData m_v;
        private LibMedi.AccessData m = new LibMedi.AccessData();

        private DataSet m_dshoadon, m_dstamung;
        private bool edit = true;//Thuy 26.12.2011
        private string m_doituongmien = "", s_mavp_huy = "", sMien_Chenhlech_Cholam = "";
        private string aidchidinh = "", v_solanin = "",v_NamBTDBN;
        private string m_id = "", m_mavaovien = "", m_maql = "", m_userid = "", s_madoituongthu = "", s_loaibnthu = "", s_loaibn_mien = "", s_tutructhutheokhoa = "", mavp_gioihan = "", mavp_gioihan_noitru = "";
        private string quyensodv, sobienlaidv, m_cur_quyenso_dichvu = "", ttrv_bienlai_dichvu = "";
        private DataSet m_dsgiavp;
        private DataSet m_dsloaivp;
        private DataSet m_dsdoituong;
        private string s_makp_thu = "";
        private DataTable dtdv = new DataTable();
        private DataTable dtchinhanh = new DataTable();
        private DataTable dt_giavp = new DataTable();

        private frmChonvp m_frmchonvp;
        //private frmDanhsachthutructiep m_frmdanhsachthutructiep;
        //private frmDanhsachchothutructiep m_frmdanhsachchothutructiep;
        //private frmTimhoadon m_frmtimhoadon;
        //private frmTimbenhnhan m_frmtimbenhnhan;
        //private frmHoantra m_frmhoantra;
        private frmPrintHD m_frmprinthd;

        //var
        private bool m_bnmoi = false, v_btrutamung = false;
        private bool m_mabntudong = false,m_Docmavach,v_chuyenchidinhCLS,v_chuakhaigiavp,v_Giamchitiet,v_nhapmienchitiet,v_miendt_loai;
        private bool bDoctinnhan_Sound = false, tt_thuchidinh_ngay, v_Quanglydichvu, v_khongthuhoadonthuong = false, v_chithuhoadonthuong = false, v_tt_suanoidunghoadon;
        //option
        private bool m_o_fullscreen = false;
        bool bLuumien = false;
        private int itablell, itablect, itablemien, iMien_Chenhlech_Doituong, iMien_Chenhlech_Tyle = 0,iSothang=1;
        string s_tenchinhanh = "";
        bool bTachHDGTGT_TheoVAT = false;
        public frmThutructiep(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();

                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Read_ContextMenuStrip_to_Xml(this.Name.ToString() + "_" + "contextMenuStrip1", contextMenuStrip1);
                lan.Change_ContextMenuStrip_to_English(this.Name.ToString() + "_" + "contextMenuStrip1", contextMenuStrip1);

                m_v = v_v;
                m_userid = v_userid;
                m_v.f_SetEvent(this);
                f_Load_Data();
                dgGia.Visible = false;
                ichinhanh = m.i_Chinhanh_hientai;
                
                m_o_fullscreen = m_v.get_o_fullscreen_frmthutructiep(m_userid);
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
        private void frmThutructiep_Load(object sender, EventArgs e)
        {
            try
            {
                string user = m_v.user;
                i_maxlength_mabn = LibVP.AccessData.i_maxlength_mabn;
                bQuanly_Theo_Chinhanh = m_v.bQuanly_Theo_Chinhanh;                
                ttrv_bienlai_dichvu = "";//m_v.tt_bienlai_gtgt(m_userid);
                v_Quanglydichvu = (m_v.tt_bienlai_gtgt(m_userid) != "");
                v_btrutamung = m_v.tt_trutamung(m_userid);// nếu có chọn option tru tam ưng thì se load len tam ung cua benh nhan, neu khong thi khong load 
                if (v_Quanglydichvu)
                {
                    sql = " select a.id,a.vat from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id and a.vat>0";
                    dtdv = m_v.get_data(sql).Tables[0];
                    foreach(DataRow r in dtdv.Rows) ttrv_bienlai_dichvu+=r["id"].ToString()+",";
                }
                itablell = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_vienphill");
                itablect = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_vienphict");
                itablemien = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_mienngtru");
                v_khongthuhoadonthuong = m_v.tt_khongthudichvu_hdthuong(m_userid);
                v_chithuhoadonthuong = m_v.tt_chithudichvu_hdthuong(m_userid);
                chkKhuyenMai.Checked = m_v.sys_cokhuyenmai_tt;
                v_tachhoadon_dv = m_v.tt_tachhoadon_dichvu(m_userid);
                bKhongchoxem_tongthu = m_v.sys_khongchoxem_tongthu == "1";
                v_tt_suanoidunghoadon=m_v.tt_suanoidunghoadon(m_userid);
                bKhongthu_tutruc_phongluu = m_v.tt_khongthutoatutruc_phongluu(m_userid);
                bKhongthu_tutruc_noitru = m_v.tt_khongthutoatutruc_noitru(m_userid);
                blamtron = m.blamtron_thuphi;
                bInphieumiengiam = m_v.tt_ingiaydenghi_miengiam(m_userid);// cho lay form option khai bao them option in phiếu miễn giảm
                btt_Thutungdonthuoc = m_v.tt_Thutungdonthuoc(m_userid);
                bTachHDGTGT_TheoVAT = m_v.tt_TachhoadonGTGT_theoVAT(m_userid);
                bbhyt_100_theodoibienlai = m_v.bhyt_100_theodoibienlai(m_userid);
                if (bDoctinnhan_Sound)                
                {
                    Clock.Interval = m_v.delay_tinnhan;
                    Clock.Start();
                    Clock.Tick += new EventHandler(Clock_Tick);
                }
                try
                {
                    iSothang = int.Parse(m_v.sys_sothang);
                }
                catch { iSothang = 1; }

                f_Load_Thutrongngay();
                f_Load_Hotkey();
                f_Enable(false);
               
                this.Refresh();
                butBoqua_Click(null, null);
                //
                string tmp_qso = m_cur_quyenso;
                lbKyhieu_Click(null, null);
                s_quyenso = tmp_qso;
                if (m_Docmavach)
                {
                    txtMabn.MaxLength = i_maxlength_mabn ;//8
                    txtMabn1.MaxLength = i_maxlength_mabn;//8 ;
                }
                //
                txtSobienlai.ReadOnly = true;
                if (cbKyhieu.Items.Count <= 0)
                {
                    MessageBox.Show(this,"Phải khai báo quyển sổ thu viện phí trước!\n Vào [Tiện ích] - [Khai báo quyển sổ] để khai!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                }
                //Thuy 18.05.2012
                dt_giavp = m.get_data("select id,ma,ten,guimau,coso from "+user+".v_giavp").Tables[0];
                DataSet dstmp = m.get_data("select id,ten,database,mabv from " + user + ".dmchinhanh");
                if (dstmp != null)
                {
                    if (dstmp.Tables[0].Rows.Count > 0)
                    {
                        dtchinhanh = dstmp.Tables[0].Copy();
                        dstmp.Dispose();
                    }
                }
                if (dtchinhanh != null)
                {
                    DataRow rcn = m.getrowbyid(dtchinhanh, "id=" + ichinhanh);
                    if (rcn != null)
                    {
                        s_tenchinhanh = rcn["ten"].ToString();
                    }
                }
                cbLoaidv_SelectedIndexChanged(null,null);
                butMoi_Click(null, null);                              
            }
            catch
            {
            }
        }
        private void f_Load_Hotkey()
        {
            try
            {
                tmn_F1.Enabled=false;
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
                foreach (DataRow r in m_v.get_data("select distinct hotkey,ghichu from medibv.v_optionhotkey" + atable + " where userid=" + m_userid + " and loai=1").Tables[0].Rows)
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
        private void f_Display()
        {
            try
            {
                dgGia.Width = dgHoadon.Width;
                dgGia.Height = 104;
                dgGia.Width = dgHoadon.Width - 1;
                dgGia.Left = panel3.Left + dgHoadon.Left+5;
                dgGia.Top = panel3.Top+panel3.Height-dgGia.Height-panel1.Height-7;

                cbDoituong.DropDownWidth = txtTenvp.Right - cbDoituong.Left;
                cbKhoa.DropDownWidth = cbBacsi.Right-cbKhoa.Left;
                cbBacsi.DropDownWidth = butChon.Right - cbBacsi.Left;
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
                bDoctinnhan_Sound = m_v.sys_doctinnhan;
                tmn_Dungchungso.Checked = m_v.sys_dungchungso;
                m_makp_khongkham = m_v.sys_makp_khongkham;
                tmn_khuyenmai.Checked = m_v.sys_khuyenmai;
                v_solanin = m_v.sys_solanin;

                tmn_Dungchungso.Enabled = false;               
                m_Docmavach = m_v.tt_Quanlymavach(m_userid);
                v_chuyenchidinhCLS = m_v.tt_ChuyenCLSChuaquaChidinh(m_userid);
                v_Giamchitiet = m_v.tt_Nhapmiengianchitiet(m_userid);
                v_nhapmienchitiet = m_v.tt_Nhapmientheotungmon(m_userid);
                v_miendt_loai = m_v.tt_Miendt_loai(m_userid);
                bool asys_suatuychon = m_v.sys_quyen_suatuychon(m_userid);
                //Mien chenh lech
                sMien_Chenhlech_Cholam = m_v.mien_chenhlech_cholam;
                iMien_Chenhlech_Doituong = m_v.mien_chenhlech_doituong;
                iMien_Chenhlech_Tyle = m_v.mien_chenhlech;
                
                //End Mien
                v_chuakhaigiavp = m_v.tt_Nhapgiavienphichuakhai(m_userid);
                s_tutructhutheokhoa = m_v.tt_khoathututruc(m_userid);
                iTreem6 = m_v.iTreem6;
                iTreem15 = m_v.iTreem15;                
                try
                {
                    s_madoituongthu = m_v.get_data("select giatri from medibv.v_optionform where ma='TT_026' and userid=" + m_userid + "").Tables[0].Rows[0]["giatri"].ToString().Trim(',');
                }
                catch 
                {
                    s_madoituongthu = "";
                }
           

                try
                {
                    s_loaibnthu = m_v.tt_Loaibn_thutructiep(m_userid).Trim(',');
                }
                catch
                {
                    s_loaibnthu = "";
                }
                try
                {
                    s_loaibn_mien = m_v.sys_Loaibn_mien().Trim(',');
                }
                catch
                {
                    s_loaibn_mien = "";
                }

                tmn_Nhaplydomien.Enabled = asys_suatuychon;
                tmn_Nhapkymien.Enabled = asys_suatuychon;
                tmn_Chonhapmoi.Enabled = asys_suatuychon;
                tmn_Chokhongquatiepdon.Enabled = asys_suatuychon;
                tmn_Cokhambenh.Enabled = asys_suatuychon;
                tmn_Cophongluu.Enabled = asys_suatuychon;
                tmn_Conhanbenh.Enabled = asys_suatuychon;
                tmn_congoaitru.Enabled = asys_suatuychon;

                tmn_Cokhambenh.Checked = m_v.tt_cokhambenh(m_userid);
                tmn_Cophongluu.Checked = m_v.tt_conamluu(m_userid);
                tmn_Conhanbenh.Checked = m_v.tt_conhanbenh(m_userid);
                tmn_congoaitru.Checked = m_v.tt_congoaitru(m_userid);

                tmn_thutheonhomvp.Checked = m_v.tt_thutheonhom(m_userid);                
                tmn_thutheoloaivp.Checked = m_v.tt_thutheoloai(m_userid);

                ToolStripMenuItem_Loai.Checked = m_v.tt_Intheoloai(m_userid);
                ToolStripMenuItem_Nhom.Checked = m_v.tt_Intheonhom(m_userid);
                ToolStripMenuItem_Chitiet.Checked = m_v.tt_InchitietHD(m_userid);
                ToolStripMenuItem_Dacthu.Checked = m_v.tt_InHDdacthu(m_userid);
                ToolStripMenuItem_thuong.Checked = m_v.tt_InHD_thuong(m_userid);

                txtTinh.Text = m_v.Mabv.Substring(0, 3);

                string sql = "";
                string atmp = m_v.s_curmmyyyy;
                DataSet ads;
                DataRow r;
                m_cur_ngay = m_v.f_parse_date(atmp);
                m_cur_yy = m_cur_ngay.Year.ToString().Substring(2);

                cbTinh.DataSource = m_v.get_data("select matt,tentt from medibv.btdtt order by tentt").Tables[0];
                cbTinh.DisplayMember = "tentt";
                cbTinh.ValueMember = "matt";

                ads = m_v.get_data("select makp, tenkp from medibv.btdkp_bv order by loai, tenkp");
                r = ads.Tables[0].NewRow();
                r["makp"] = "00";
                r["tenkp"] = "";
                ads.Tables[0].Rows.InsertAt(r, 0);

                cbKhoa.DataSource = ads.Tables[0];
                cbKhoa.DisplayMember = "tenkp";
                cbKhoa.ValueMember = "makp";

                ads = m_v.get_data("select ma,hoten from medibv.dmbs order by hoten");
                r = ads.Tables[0].NewRow();
                r["ma"] = "0000";
                r["hoten"] = "";
                ads.Tables[0].Rows.InsertAt(r, 0);
                cbBacsi.DataSource = ads.Tables[0];
                cbBacsi.DisplayMember = "hoten";
                cbBacsi.ValueMember = "ma";

                try
                {                    
                    sql = "select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong ";
                    if (s_madoituongthu!="")
                    {
                        sql += " where madoituong in("+s_madoituongthu+")";
                    }
                    sql += " order by madoituong";
                }
                catch
                { 
                }

                cbDoituong.DataSource = m_v.get_data(sql).Tables[0];
                cbDoituong.DisplayMember = "doituong";
                cbDoituong.ValueMember = "madoituong";

                m_doituongmien = "";
                foreach (DataRow r1 in m_v.get_data(sql).Tables[0].Select("mien=1"))
                {
                    m_doituongmien += ",";
                    m_doituongmien += r1["madoituong"].ToString();
                }
                m_doituongmien += ",";

                try
                {
                    sql = "select madoituong,doituong,field_gia,mien,mabv,sothe,ngay,chenhlech from medibv.doituong ";
                    //if (s_madoituongthu!="")
                    //{
                    //    sql += " where madoituong in(" + s_madoituongthu + ")";
                    //}
                    sql += " order by madoituong";
                }
                catch
                {
                }
                m_dsdoituong = m_v.get_data(sql);
                cbDoituongTD.DataSource = m_dsdoituong.Tables[0];
                cbDoituongTD.DisplayMember = "doituong";
                cbDoituongTD.ValueMember = "madoituong";

                cbLoaidv.DataSource = m_v.get_data("select to_char(ma) as ma,ten from medibv.v_tenloaivp order by ma").Tables[0];
                cbLoaidv.DisplayMember = "ten";
                cbLoaidv.ValueMember = "ma";
                
                sql = "select to_char(id) as id,sohieu,loai,userid,* from medibv.v_quyenso";
                if (!tmn_Dungchungso.Checked)
                {
                    sql += " where userid = " + m_userid;
                }
                sql += " order by ngayud desc";
                cbKyhieu.DataSource = m_v.get_data(sql).Tables[0];
                cbKyhieu.DisplayMember = "sohieu";
                cbKyhieu.ValueMember = "id";
                

                cbLoaibn.DataSource = m_v.get_data("select id,ten from medibv.v_loaibn order by id").Tables[0];
                cbLoaibn.DisplayMember = "ten";
                cbLoaibn.ValueMember = "id";

                cbotenpk.DataSource = m_v.get_data("select makp,tenkp from medibv.btdkp_bv  order by makp").Tables[0];
                cbotenpk.DisplayMember = "tenkp";
                cbotenpk.ValueMember = "makp";

                tennuoc.DisplayMember = "TEN";
                tennuoc.ValueMember = "MA";
                tennuoc.DataSource = m_v.get_data("select * from medibv.dmquocgia order by ten").Tables[0];
                tennuoc.SelectedIndex = -1;

                tendantoc.DisplayMember = "DANTOC";
                tendantoc.ValueMember = "MADANTOC";
                tendantoc.DataSource = m_v.get_data("select * from medibv.btddt order by madantoc").Tables[0];
                tendantoc.SelectedValue = "25";

                tennn.DisplayMember = "TENNN";
                tennn.ValueMember = "MANN";
                load_btdnn(0);	
                
                cbGioitinh.DataSource = m_v.get_data("select ma,ten from medibv.dmphai order by ma desc").Tables[0];
                cbGioitinh.DisplayMember = "ten";
                cbGioitinh.ValueMember = "ma";

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

                string mavp = (m_v.tt_gioihanvp(m_userid))?m_v.tt_gioihan_mavp(m_userid):"";
                mavp_gioihan = mavp;
                mavp_gioihan_noitru = (m_v.tt_gioihanvp(m_userid)) ? m_v.tt_gioihan_mavp_noitru(m_userid) : "";//binh 100611
                sql = "select id,ma,ten,dvt,gia_th,gia_bh,gia_dv,gia_nn,gia_cs,gia_ksk,bhyt from medibv.v_giavp where hide=0 ";
                if (mavp != "") sql += " and id in (" + mavp.Substring(0, mavp.Length - 1) + ")";
                sql +=" order by ten";
                if (m_v.sys_cokhuyenmai_tt)
                {
                    string sngay = m_cur_ngay.ToString().Substring(3, 3) + m_cur_ngay.ToString().Substring(0, 3) + m_cur_ngay.ToString().Substring(6, 4);
                    sql = "select a.id,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.bhyt,sum(a.sotienkhuyenmai) as sotienkhuyenmai, sum(a.tylekhuyenmai ) as tylekhuyenmai from ( ";
                    sql += "select id,ma,ten,dvt,gia_th,gia_bh,gia_dv,gia_nn,gia_cs,gia_ksk,bhyt,0 as sotienkhuyenmai,0 as tylekhuyenmai from medibv.v_giavp where hide=0 ";
                    sql += " union all ";
                    sql += "select a.id,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.bhyt,b.sotienkhuyenmai,b.tylekhuyenmai ";
                    sql += "from medibv.v_giavp a inner join medibv.v_giavp_khuyenmai b on a.id=b.idvp inner join medibv.v_dot_khuyenmai c on b.iddot=c.id ";
                    sql += "where a.hide=0 and c.hide=0 and to_date('"+sngay+"','dd/mm/yyyy') between to_date(to_char(c.tungay,'dd/mm/yyyy'),'dd/mm/yyyy') and to_date(to_char(c.denngay,'dd/mm/yyyy'),'dd/mm/yyyy') ";
                    sql += ")as a group by a.id,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.bhyt order by ten ";
                }
                dgGia.DataSource = m_v.get_data(sql).Tables[0];

                m_dsgiavp = m_v.get_data("select * from medibv.v_giavp a,medibv.v_loaivp b where a.hide=0 and a.id_loai=b.id order by a.id_loai, a.ten");
                m_dsloaivp = m_v.get_data("select id,stt,ten,viettat,id_nhom,to_number('0') as sotien from medibv.v_loaivp order by stt, ten");

                sql = "select 0 as id, 0 as chon,'' as ngaycd, 0 as mavp, '' as ma,'' as ten,'' as dvt,0 as soluong, 0 as dongia, 0 as thanhtien, 0 as mien,0 as thucthu,0 as madoituong,'' as doituong,'' as makp, '' as tenkp, '' as mabs,'' as tenbs, 0 as idcd,0 as id_loai,0 as dichvu, 0 as idphongcls, 0 as stt,0 as maphongcls,0 as sttcho";//binh 120611
                m_dshoadon = m_v.get_data(sql);
                m_dshoadon.Tables[0].Rows.Clear();
                
                dgHoadon.DataSource = m_dshoadon.Tables[0];


                sql = "select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs,a.gia_ksk, trim(b.ten) as tenloai,b.id as id_loai, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id where a.hide=0 ";
                if (mavp != "") sql += " and a.id in (" + mavp.Substring(0, mavp.Length - 1) + ")";
                sql += " order by b.ten,b.stt, b.id, a.ten,a.stt";


                m_dstamung = m_v.get_data_mmyy(m_cur_ngay.Month.ToString().PadLeft(2,'0')+m_cur_ngay.Year.ToString().Substring(2,2), "select 0 as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id,a.quyenso, a.makp from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id where 1=2");
                m_frmchonvp = new frmChonvp(m_v, m_userid, "GIA_TH", m_v.get_data(sql), m_v.s_loaiform_thutructiep);

                m_frmchonvp.s_multiline = m_v.get_o_multiline_frmchonvp(m_userid);
                m_frmchonvp.s_dshotkey = m_v.f_get_hotkey_frmthutructiep(m_userid);

                m_frmchonvp.s_dshotkey_ksk = m_v.f_get_hotkey_ksk_frmthutructiep(m_userid);
                m_frmchonvp.s_hotkey = "";
                m_frmchonvp.ShowInTaskbar = false;

                //m_frmdanhsachthutructiep = new frmDanhsachthutructiep(m_v, m_userid);
                //m_frmdanhsachthutructiep.ShowInTaskbar = false;

                //m_frmdanhsachchothutructiep = new frmDanhsachchothutructiep(m_v, m_userid);
                //m_frmdanhsachchothutructiep.ShowInTaskbar = false;

                //m_frmtimbenhnhan = new frmTimbenhnhan(m_v, m_userid);
                //m_frmtimbenhnhan.ShowInTaskbar = false;

                //m_frmtimhoadon = new frmTimhoadon(m_v, m_userid);
                //m_frmtimhoadon.ShowInTaskbar = false;
                //m_frmtimhoadon.s_loaihd = "1";

                //m_frmhoantra = new frmHoantra(m_v, m_userid);
                //m_frmhoantra.ShowInTaskbar = false;
                //m_frmhoantra.s_loaihd = "1";

                m_frmprinthd = new frmPrintHD(m_v,m_userid);

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmthutructiep(m_userid);
                f_Set_Fullgrid();

                tmn_Hotkey_Show.Checked = m_v.get_o_show_hotkey_frmthutructiep(m_userid);
                tmn_Hotkey_KSK_Show.Checked = m_v.get_o_show_hotkey_ksk_frmthutructiep(m_userid);
                if (tmn_Hotkey_Show.Checked && tmn_Hotkey_KSK_Show.Checked)
                {
                    tmn_Hotkey_KSK_Show.Checked = false;
                    m_v.set_o_show_hotkey_ksk_frmthutructiep(m_userid, false);
                }
                tmn_Hotkey_Addall.Checked = m_v.get_o_addall_hotkey_frmthutructiep(m_userid);
                tmn_Show_Hotkey.Checked = m_v.get_o_show_hotkey_toolbar_frmthutructiep(m_userid);
                tt_Hotkey.Visible = tmn_Show_Hotkey.Checked;
                f_Display();

                //Option
                tmn_Luuin_Hoadon.Checked = m_v.get_o_luuin_hoadon_frmthutructiep(m_userid);
                tmn_Luuin_Chiphi.Checked = m_v.get_o_luuin_chiphi_frmthutructiep(m_userid);
                tmn_Luuin_Chiphi_cadot.Checked = m_v.get_o_luuin_chiphi_cadot_frmthutructiep(m_userid);

                tmn_Luuin_Hoadon_Icon.Checked = m_v.get_o_luuin_frmthutructiep(m_userid);
                tmn_luukhongin.Checked = !tmn_Luuin_Hoadon_Icon.Checked;
                tmn_luuvain.Checked = tmn_Luuin_Hoadon_Icon.Checked;
                tmn_Xemtruockhiin_Icon.Checked = m_v.get_o_xemtruockhiin_frmthutructiep(m_userid);
                tmn_xemtruockhiin.Checked = tmn_Xemtruockhiin_Icon.Checked;
                
                tmn_Nhapkhoaphong.Checked = m_v.tt_nhapkhoaphong(m_userid);
                tmn_Nhapbacsi.Checked = m_v.tt_nhapbacsi(m_userid);
                tmn_Nhaplydomien.Checked = m_v.tt_nhaplydomien(m_userid);
                tmn_Nhapkymien.Checked = m_v.tt_nhapduyetmien(m_userid);
                tmn_Thuchidinh.Checked = m_v.tt_thuchidinh(m_userid);
                tt_thuchidinh_ngay = m_v.tt_thuchidinh_ngay(m_userid);
                tmn_thuvienphikhoa.Checked = m_v.tt_thuvienphikhoa(m_userid);
                tmn_Toathuoctutruc.Checked = m_v.tt_thutoatutruc(m_userid);
                tmn_Toathuocmuangoai.Checked = m_v.tt_thutoamuangoai(m_userid);
                tmn_Toathuocmuangoai_chuaduyet.Checked = m_v.tt_thutoamuangoai_chuaduyet(m_userid);
                tmn_Chonhapmoi.Checked = m_v.tt_chonhapmoi(m_userid);
                tmn_Chokhongquatiepdon.Checked = m_v.tt_chokhongquatiepdon(m_userid);
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

        private void f_Load_CB_Quan(string v_matt)
        {
            try
            {
                cbQuan.DataSource = m_v.get_data("select maqu,tenquan from medibv.btdquan where matt='"+v_matt+"' order by maqu").Tables[0];
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
                cbTQX.DataSource = m_v.get_data("select a.maphuongxa as ma, c.tentt ||', ' || b.tenquan ||', '|| a.tenpxa as ten from medibv.btdpxa a left join medibv.btdquan b on a.maqu=b.maqu left join medibv.btdtt c on b.matt=c.matt where lower(a.viettat) like lower('%"+v_matat+"%') order by c.tentt, b.tenquan, a.tenpxa").Tables[0];
                cbTQX.DisplayMember = "ten";
                cbTQX.ValueMember = "ma";
            }
            catch
            {
            }
        }
        private void f_Load_T_Q_X(string v_maphuongxa)
        {
            try
            {
                cbTinh.SelectedValue = v_maphuongxa.Substring(0,3);
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
        private void f_Load_Hanhchanh(string v_mabn)
        {
            try
            {
                bool aok = false;
                string sql = "";
                m_bnmoi = true;
                sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.phai,a.sonha,a.thon,a.cholam,a.maphuongxa,a.mann,a.madantoc,nam from medibv.btdbn a where a.mabn='" + v_mabn + "'";
                f_Clear_HC();
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    txtNoilamviec.Text = r["cholam"].ToString();
                    txtHoten.Text = r["hoten"].ToString();
                    txtNgaysinh.Text = r["ngaysinh"].ToString();
                    if (txtNgaysinh.Text.Trim() == "null" || txtNgaysinh.Text.Trim()=="")
                    {
                        txtNgaysinh.Text = r["namsinh"].ToString();
                    }
                    cbGioitinh.SelectedValue = r["phai"].ToString();
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
                //    if (tmn_Toathuocmuangoai.Checked)
                //    {
                //        bNgayvv_Validated(null, null);
                //        f_Enable_HC(!aok);
                //        f_Enabled_VP(true);
                //        cbDoituong.Focus();
                //    }
                //    else if (m_bnmoi)
                    if (m_bnmoi)
                    {
                        if (tmn_Chonhapmoi.Checked)
                        {
                            f_Enable_HC(true);
                            f_Enabled_VP(true);
                            f_FullScreen(false);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(this,"Không cho phép nhập bệnh nhân mới!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            f_Enable_HC(false);
                            f_Enabled_VP(false);
                            txtMabn.Focus();
                            return;
                        }
                    }
                    else
                    if (cbNgayvv.Items.Count <= 0 && !tmn_Chokhongquatiepdon.Checked)
                    {
                        MessageBox.Show(this,"Không cho phép bệnh nhân chưa hoàn tất thủ tục!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        f_Enable_HC(false);
                        f_Enabled_VP(false);
                        txtMabn.Focus();
                        return;
                    }
                    else
                    {
                        cbNgayvv_Validated(null, null);
                        f_Enable_HC(!aok);
                        f_Enabled_VP(true);
                        cbDoituong.Focus();
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
                chkTheKB.Checked = false;
                txtHoten.Text = "";
                txtNgaysinh.Text = "";
                txtTuoi.Text = "";
                txtSonha.Text = "";
                txtThonpho.Text = "";
                txtNoilamviec.Text = "";
                txtTinh.Text = m_v.Mabv.Substring(0, 3);
                cbTinh.SelectedValue = m_v.Mabv.Substring(0, 3);
                f_Load_CB_Quan(m_v.Mabv.Substring(0, 3));
                f_Load_CB_Xa(m_v.Mabv.Substring(0, 3)+"00");
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
                txtSothe.Text = "";
                txtTN.Text = "";
                txtDN.Text = "";
                txtNDK_Ma.Text = "";
                txtNDK_Ten.Text = "";
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
                    cbBacsi.SelectedIndex = -1;
                }
                catch
                {
                }
                try
                {
                    cbLydomien.SelectedIndex = -1;
                }
                catch
                {
                }
                txtTenvp.Text = "";
                txtSoluong.Text = "";
                txtDongia.Text = "";
                txtMien.Text = "";
                txtThucthu.Text = "";
                toolStrip_Mien.Text = "0";
                toolStrip_BHYT.Text = "0";
                toolStrip_Thucthu.Text = "0";
                toolStrip_Tongcong.Text = "0";
            }
            catch
            {
            }
        }
        private void f_Enable_HC(bool v_bool)
        {
            try
            {

                //txtMabn.Enabled = v_bool;
                //txtMabn1.Enabled = v_bool;

                cbLoaidv.Enabled = false;// v_bool;
                txtNgaythu.Enabled = false;// v_bool;
                cbKyhieu.Enabled = false;// v_bool;
                txtHoten.ReadOnly = !v_bool;
                txtNgaysinh.ReadOnly = !v_bool;
                txtTuoi.ReadOnly = !v_bool;
                cbTuoi.Enabled = v_bool;
                cbGioitinh.Enabled = v_bool;
                txtTQX.Enabled = v_bool;
                cbTQX.Enabled = v_bool;
                txtTinh.Enabled = v_bool;
                cbTinh.Enabled = v_bool;
                txtQuan.Enabled = v_bool;
                cbQuan.Enabled = v_bool;

                txtXa.Enabled = v_bool;
                cbXa.Enabled = v_bool;                
                txtSothe.ReadOnly = !v_bool;
                txtTN.ReadOnly = !v_bool;
                txtDN.ReadOnly = !v_bool;
                txtNDK_Ma.ReadOnly = !v_bool;
                txtNDK_Ten.ReadOnly = !v_bool;
                cbLoaibn.Enabled = false;// v_bool;
                cbDoituongTD.Enabled = v_bool;
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
                txtTenvp.Enabled = (v_tt_suanoidunghoadon) ? v_bool : false;
                txtSoluong.Enabled = v_bool;
                txtDongia.Enabled = v_bool;
                txtMien.Enabled = v_bool;
                txtThucthu.Enabled = v_bool;
                cbKhoa.Enabled = v_bool;
                cbBacsi.Enabled = v_bool;

                txtLydomien.Enabled = v_bool && tmn_Nhaplydomien.Checked;
                cbLydomien.Enabled = v_bool && tmn_Nhaplydomien.Checked;

                txtKymien.Enabled = v_bool && tmn_Nhapkymien.Checked;
                cbKymien.Enabled = v_bool && tmn_Nhapkymien.Checked;
                cbKhoa.Enabled = v_bool && tmn_Nhapkhoaphong.Checked;
                cbBacsi.Enabled = v_bool && tmn_Nhapbacsi.Checked;

                butAdd.Enabled = v_tt_suanoidunghoadon ? v_bool : false;
                butRem.Enabled = v_tt_suanoidunghoadon ? v_bool : false;
                butChon.Enabled = v_tt_suanoidunghoadon ? v_bool : false; 

                toolStrip_Mien.ReadOnly = !v_bool;

                dgHoadon.Columns[6].ReadOnly = (v_tt_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[7].ReadOnly = (v_tt_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[8].ReadOnly = (v_tt_suanoidunghoadon == false) ? true : !butLuu.Enabled;
                dgHoadon.Columns[9].ReadOnly = (v_tt_suanoidunghoadon == false) ? true : !butLuu.Enabled;
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
                butSua.Enabled = !v_bool && m_id != "" && m_id != "0" && edit;//Thuy 26.12.2011
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
                edit = true;//Thuy 26.12.2011
                bAll_days = false;
                string atmp = "";
                if (cbKyhieu.Items.Count <= 0)
                {
                    MessageBox.Show(this,"Phải khai báo quyển sổ thu viện phí trước!\n Vào [Tiện ích] - [Khai báo quyển sổ] để khai!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                    return;
                }
                txtMabn.Enabled = true;
                txtMabn1.Enabled = true;
                tmn_Danhsachcho.Enabled = true;
                f_FullScreen(m_o_fullscreen);
                m_bnmoi = true;
                m_mabntudong = m_v.tt_mabntudong(m_userid);
                m_id = "";
                v_NamBTDBN = "";
                m_mavaovien = "";
                m_maql = "";
                m_id_gia = "";
                s_mavp_huy = "";
                toolStrip_BNDua.Text = "";
                toolStrip_Thoilai.Text = "";
                tendantoc.SelectedValue = "25";
                tennuoc.SelectedValue = "VN";
                m_dshoadon.Tables[0].Rows.Clear();
               
                cbNgayvv.DataSource = null;

                f_Tinhtien();
                f_Clear_HC();
                f_Enable(true);
                f_Enable_HC(true);
                try
                {
                    txtNgaythu.Value = m_v.f_parse_date_16(m_cur_ngay.Day.ToString().PadLeft(2, '0') + "/" + m_cur_ngay.Month.ToString().PadLeft(2, '0') + "/" + m_cur_ngay.Year.ToString() + " " + m_v.ngayhienhanh_server.Substring(11, 5));
                }
                catch
                {
                    txtNgaythu.Value = m_cur_ngay;
                }
                try
                {
                    if (m_cur_loaidv != "")
                    {
                        cbLoaidv.SelectedValue = m_cur_loaidv;
                        cbLoaidv_Validated(null, null);
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
                }
                catch
                {
                }
                atmp = f_Get_Sobienlai();
                txtSobienlai.Text = atmp.Split(':')[0];
                if (atmp.Split(':')[1] == "1")//Hết số
                {
                    MessageBox.Show(this,"Hết sổ, đề nghị chọn sổ mới!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    cbLoaidv.Focus();
                    return;
                }
                else
                if (atmp.Split(':')[1] == "2")//Lỗi
                {
                    //MessageBox.Show(this,"Không tìm thấy quyển sổ thu viện phí! \n Đề nghị chọn sổ",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (v_Quanglydichvu)
                {
                    lbl_SBLdichvu.Text = f_Get_Sobienlai(m_cur_quyenso_dichvu).Split(':')[0];
                    lbl_quyensodichvu.Text = m_cur_quyenso_dichvu;
                }
                txtMabn.Text = m_cur_yy;
                txtMabn1.Text = "";
                dgHoadon.Columns["Column_0"].ToolTipText ="Đánh dấu những mục cần in.";
                f_Filter_Giavp();
                dgGia.Visible = false;
                txtmapk.Text = m_makp_khongkham;
                cbotenpk.SelectedValue = m_makp_khongkham;
                //
                m_dshoadon.Tables[0].Rows.Clear();
                dgHoadon.DataSource = m_dshoadon.Tables[0];
                dgHoadon.Update();
                dgHoadon.Refresh();
                txtMabn1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private DataSet capIdPhongCLS(DataSet dsHoadonct)
        {
            DataSet ds1 = new DataSet();
            ds1 = dsHoadonct.Copy();
            ds1.Clear();
            string[] sidphong = {"0"};
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

                }catch { }
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
        private int capSttCho(int idphong, int idloai)
        {
            if (idphong == 0) return 0;
            else
            {
                string angay = txtNgaythu.Text.Substring(0, 10);
                string ammyy = m_v.get_mmyy(angay);
                string sql = "select count(*) from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.dmphongthuchiencls c ";
                sql += "on b.id_loai=c.id_loaivp where c.id="+idphong+" and c.id_loaivp="+idloai+" and to_char(ngay,'dd/mm/yyyy')='"+angay+"'";
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

        private void toolStrip_BNDua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (butLuu.Enabled && butMoi.Enabled == false) butLuu.Focus();
                else SendKeys.Send("{Tab}");
            }
        }
        private void f_InPhieuMien(string aid)
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
            ads = m_v.get_data_mmyy(ammyy,asql);

            string asyt = "", abv = "", adiachibv = "",aReport = "";

            foreach( DataRow r in ads.Tables[0].Rows )
            {
                anoidung += r["noidung"].ToString() +",";
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
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + txtNgaythu.Text.Substring(0,10) + "'";
                cMain.DataDefinition.FormulaFields["s_noidung"].Text = "'" + anoidung + "'";

                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
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
                bool asua = (m_id != "" && m_id != "0");
                string atmp = "", aidcd = "", amakp_ll = "01";
                bool bVPCapstt = false;
                butLuu.Enabled = false;
                if (m_dshoadon.Tables[0].Rows.Count <= 0)
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Đề nghị nhập nội dung thu viện phí!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenvp.Focus();
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
                if (cbDoituongTD.SelectedValue.ToString() != "1" && toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Đề nghị nhập người duyệt miễn giảm!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKymien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "",
                amaql = "", aidkhoa = "", amakp = "", ahoten = "", anamsinh = "", adiachi = "", aloai = "", aloaibn = "", 
                auserid = "",aphai="",amavp = "";
                angay = txtNgaythu.Text.Substring(0, 16);
                ammyy = m_v.get_mmyy(angay);
                aid=m_id;
                try
                {
                    aid = decimal.Parse(m_id).ToString();
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
                    MessageBox.Show(this,"Chọn quyển sổ thu viện phí!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    lbKyhieu_Click(null, null);
                    cbKyhieu.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                amabn=txtMabn.Text.Trim()+txtMabn1.Text.Trim();
                if (txtMabn.Text.Trim()==""||txtMabn1.Text.Trim()==""||txtHoten.Text.Trim()=="")
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Nhập thông tin bệnh nhân!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMabn.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                try
                {
                    amakp = cbotenpk.SelectedValue.ToString();
                }
                catch
                {
                    amakp = m_makp_khongkham;
                }
                amakp_ll = amakp;
                if (amakp_ll == "00" || amakp_ll=="")
                {
                    amakp_ll = m_makp_khongkham;
                }
                ahoten=txtHoten.Text.Trim();
                if (ahoten.Length == 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Nhập thông tin bệnh nhân!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtSonha.Text != "")
                {
                    adiachi = txtSonha.Text.Trim() + ",";
                }
                if (txtThonpho.Text != "")
                {
                    adiachi += txtThonpho.Text.Trim() + ",";
                }
                if (cbXa.Text.ToUpper().Trim() !="KHÔNG XÁC ĐỊNH")
                {
                    if(adiachi!="")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbXa.Text.Trim();
                }
                if (cbQuan.Text.ToUpper().Trim() !="KHÔNG XÁC ĐỊNH")
                {
                    if(adiachi!="")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbQuan.Text.Trim();
                }
                if (cbTinh.Text.ToUpper().Trim() !="KHÔNG XÁC ĐỊNH")
                {
                    if(adiachi!="")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbTinh.Text.Trim();
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
                    aphai = decimal.Parse(cbGioitinh.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    aphai = "0";
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
                aidkhoa = "0";
                if (amaql != "" && amaql!="0")
                {
                    if (m_v.f_parse_date(cbNgayvv.Text.Substring(0, 10)) > txtNgaythu.Value)
                    {
                        MessageBox.Show(this,"Đề nghị chọn ngày thu lớn hơn hay = ngày bệnh nhân vào viện (" + cbNgayvv.Text.Substring(0, 10) + ")!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                        if (MessageBox.Show(this,"Hết sổ, đề nghị chọn sổ mới! \n Có muốn chọn sổ khác không?",m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                            MessageBox.Show(this,"Không tìm thấy quyển sổ thu viện phí! \n Đề nghị chọn sổ",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbKyhieu.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbKyhieu.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                }
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
                        MessageBox.Show(this,"Không cập nhật được thông tin bệnh nhân!\nChưa lưu hoá đơn!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                // gam hepa phat sinh idphongcls va stt chờ v_vienphict
                if (bVPCapstt) m_dshoadon = capIdPhongCLS(m_dshoadon);
                //end gam
                string v_maql_TD = amavaovien==""?"0":amavaovien;// "";
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
                         amaql = m_v.upd_tiepdon(amabn,0, 0, amakp_ll, angay, decimal.Parse(cbDoituongTD.SelectedValue.ToString()), "0000000000", txtTuoi.Text.PadLeft(4, '0'), 1, 7, 0, -decimal.Parse(auserid)).ToString();
                    }
                    catch
                    {
                    }
                }
                if (amaql == "" || amaql == "0")
                {
                    amaql = v_maql_TD;
                }
                if(amaql == "" || amaql == "0")
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Không cập nhật được thông tin tiếp đón! \n Chưa lưu hoá đơn!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (amavaovien == "")
                {
                    amavaovien = amaql;
                }
                #region        
             
                if (aid != "0")                
                {
                    string s= m_v.fields(m_v.user+ammyy+".v_vienphill", "id=" + aid +" and mabn='"+amabn+"'");    
                    m_v.upd_eve_tables(ammyy,itablell, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy,itablell, int.Parse(m_userid), "upd",s);
                }
                //else m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "ins");
                    
                if (aid!="0")
                {
                    foreach (DataRow r1 in m_v.get_data_mmyy(ammyy,"select * from medibvmmyy.v_vienphict where id=" + aid + "").Tables[0].Rows)
                    {                    
                        string s = m_v.fields(m_v.user + ammyy + ".v_vienphict", "id=" + aid + " and stt=" + int.Parse(r1["stt"].ToString()));
                        m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "upd",s);
                    }
                } //else m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "ins");
                

                if (aid != "0")
                {                  
                        string s = m_v.fields(m_v.user + ammyy + ".v_mienngtru", "id=" + aid);
                        m_v.upd_eve_tables(ammyy, itablemien, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablemien, int.Parse(m_userid), "upd", s);
                    }
                #endregion
                asobienlai = txtSobienlai.Text.Trim();
                if (aid != "0")
                {
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_vienphict where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_mienngtru where id = " + aid);
                }
                quyensodv = sobienlaidv = "";
                if (v_Quanglydichvu)
                {
                    quyensodv = lbl_quyensodichvu.Text.Trim();
                    sobienlaidv = lbl_SBLdichvu.Text.Trim();
                }
                decimal atamung = 0;
                try
                {
                    atamung = decimal.Parse(toolStrip_Tamung.Text) ;
                }
                catch { atamung = 0; }
                aid = m_v.upd_v_vienphill(ammyy, decimal.Parse(aid), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), amakp_ll, ahoten, anamsinh, adiachi, decimal.Parse(aloai), decimal.Parse(aloaibn), decimal.Parse(auserid), decimal.Parse(aphai), "", "", chkTheKB.Checked ? 2 : 0, (quyensodv != "") ? decimal.Parse(quyensodv) : 0, (sobienlaidv != "") ? decimal.Parse(sobienlaidv) : 0,"");
                m_v.execute_data_mmyy(ammyy,"update medibvmmyy.v_vienphill set tamung="+atamung+ " where id="+aid);
                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set thanhtoan=" + (rdTienmat.Checked ? 0 : rdTrasau.Checked ? 1 : rdThe.Checked ? 2 : 0) + " where id=" + aid);// gam hepa 14-05-2011
                if (!v_Quanglydichvu) m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
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
                if (aid != "0")
                {
                    decimal astt=1,vat=0;
                    string atn = "";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    DataRow r0;
                    bool bHoadondv = false, bHoadon = false;
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            vat = 0;
                            if (v_Quanglydichvu)
                            {
                                r0 = m_v.getrowbyid(dtdv, "id=" + decimal.Parse(r["mavp"].ToString()));
                                if (r0 != null)
                                {
                                    vat = decimal.Parse(r0["vat"].ToString());
                                    m_v.upd_v_vienphict("v_vienphidv", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), vat, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
                                    bHoadondv = true;
                                }
                                else bHoadon = true;
                            }
                            int co = 0, i_dotkhuyenmai = 0;

                            if (chkKhuyenMai.Checked)/////////////////LUU  hoa don khuyen mai
                            {
                                DataSet ads_km = new DataSet();
                                string smakp = "", smabs="";
                                smabs = r["mabs"].ToString() == "" ? "0" : r["mabs"].ToString();
                                smakp = r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll;
                                
                                try
                                {
                                    ads_km = m_v.get_data("select a.idvp,a.iddot from medibv.v_giavp_khuyenmai a inner join medibv.v_dot_khuyenmai b  on b.id=a.iddot where b.hide=0 and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') >= b.tungay and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')<= b.denngay");
                                    
                                    if (ads_km.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow r_ct in ads_km.Tables[0].Select("idvp=" + r["mavp"].ToString()))
                                        {
                                            
                                            i_dotkhuyenmai = (r_ct["iddot"].ToString() == "") ? 0 : int.Parse(r_ct["iddot"].ToString());
                                            co = 1;
                                            break;
                                        }
                                    }
                                   
                                }
                                catch { }
                            }
                            
                            //binh 22022011
                            m_v.upd_v_vienphict("v_vienphict", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), vat, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphict set idphongcls="+r["maphongcls"].ToString()+", sttcho="+r["sttcho"].ToString()+" where id=" + aid + " and stt="+ astt);// gam hepa 14-03-2011
                            if (co != 0)//binh 22022011
                            {
                                m_v.execute_data("update medibv" + ammyy + ".v_vienphict set khuyenmai=" + i_dotkhuyenmai + " where id=" + aid + " and stt=" + astt + " and idchidinh=" + r["idcd"].ToString());
                            }
                            //

                            astt += 1;
                            //update paid chi dinh
                            if (r["idcd"].ToString().Trim() != "0" && r["idcd"].ToString().Trim() != "")
                            {
                                //gam 09/08/2011
                                //aidcd += ",";
                                //aidcd += r["idcd"].ToString();
                                aidcd += r["idcd"].ToString();
                                aidcd += ",";
                                sql = "update medibvmmyy.v_chidinh set idphongthuchiencls=" + r["maphongcls"].ToString() ;
                                sql += " where id in(" + r["idcd"].ToString() + ")";
                                m_v.execute_data(atn, angay.Substring(0, 10), sql);
                            }
                            else
                            {
                                if (v_chuyenchidinhCLS)
                                {
                                    aidchidinh = "";
                                    aidchidinh = m_v.get_id_v_chidinh.ToString();
                                    if (r["chon"].ToString() == "1")
                                        m_v.upd_v_chidinh_tt(ammyy, decimal.Parse(aidchidinh), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), angay, int.Parse(aloai), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, int.Parse(r["madoituong"].ToString()), int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 1, 0, -int.Parse(auserid), 1, 1, 0, 0, decimal.Parse(aid));
                                    else
                                        m_v.upd_v_chidinh_tt(ammyy, decimal.Parse(aidchidinh), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), angay, int.Parse(aloai), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, int.Parse(r["madoituong"].ToString()), int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 1, 0, -int.Parse(auserid), 1, 1, 1, 1, decimal.Parse(aid));
                                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphict set idchidinh=" + aidchidinh + " where mavp=" + r["mavp"].ToString() + " and id=" + aid + "");
                                }                             
                            }
                           
                            if (r["mavp"].ToString().Trim() != "")
                            {
                                amavp += r["mavp"].ToString().Trim() + ",";
                            }
                        }
                        catch(Exception ex)
                        {
                        }
                        //Thuy 18.05.2012
                        try 
                        {
                            if (dtchinhanh != null)
                            {
                                
                                int i_guimau = 0; 
                                m = new LibMedi.AccessData();
                                string s_cosoduocthuchien = "", s_tenchinhanhchuyenden="";
                                DataRow rvp = m.getrowbyid(dt_giavp, "id=" + r["mavp"].ToString());
                                i_guimau = int.Parse(rvp["guimau"].ToString());
                                s_cosoduocthuchien = rvp["coso"].ToString();
                                i_idchinhanhden = int.Parse(s_cosoduocthuchien);
                                s_tenchinhanhchuyenden = m.f_getten_chinhanh(i_idchinhanhden);
                                if (i_guimau == 1)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + rvp["ten"].ToString() + ".\n" +
                                        lan.Change_language_MessageText("Đã được gửi sang") + " " + s_tenchinhanhchuyenden + " " + lan.Change_language_MessageText("để thực hiện."));
                                    i_trangthai = 3;
                                }
                                if (i_trangthai == 3)//chuyển giữa các chi nhánh 
                                {
                                    DataRow rcn = m.getrowbyid(dtchinhanh, "id=" + i_idchinhanhden);
                                    if (rcn != null)
                                    {
                                        string _mmyy = m.mmyy(r["ngaycd"].ToString());
                                        string databaselink = rcn["database"].ToString().Trim('@');
                                        //s_mabv = rcn["mabv"].ToString();
                                        databaselink = databaselink == "" ? "" : "@" + databaselink;
                                        if (databaselink != "")
                                        {
                                            if (m.get_data("select mmyy from "+m.user+".table" + databaselink + " where mmyy='" + _mmyy + "'").Tables[0].Rows.Count > 0)
                                            {
                                                m.DatabseLinkName = databaselink.Trim('@');
                                                //databaselink = databaselink.Trim('@') == "" ? "" : "@" + databaselink.Trim('@');
                                                //update v_chidinh set paid =1//default done =0
                                                m.execute_data("update " + m.user + _mmyy + ".v_chidinh" + databaselink + " set paid=1, done=0 where id=" + r["idcd"].ToString());
                                            }                                            
                                            else
                                            {
                                                MessageBox.Show(lan.Change_language_MessageText("Cơ sở dữ liệu của chi nhánh cần chuyển tới chưa được tạo.") + "\n" +
                                                    lan.Change_language_MessageText("Vui lòng liên hệ với quản trị mạng"));
                                            }
                                        }
                                    }
                                } 
                            }
                        }
                        catch { }//end Thuy 18.05.2012
                    }
                    if (bHoadon && bHoadondv && quyensodv == aquyenso)
                    {
                        m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                        lbl_SBLdichvu.Text = f_Get_Sobienlai(m_cur_quyenso_dichvu).Split(':')[0];
                        lbl_quyensodichvu.Text = m_cur_quyenso_dichvu;
                        quyensodv = lbl_quyensodichvu.Text.Trim();
                        sobienlaidv = lbl_SBLdichvu.Text.Trim();
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set sobienlaidv=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                    }
                    if (bHoadondv) m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                    else if (v_Quanglydichvu && bHoadon) m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                    if (v_Quanglydichvu && bHoadondv && !bHoadon) m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set quyenso=" + decimal.Parse(quyensodv) + ",sobienlai=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                }
                aidcd = aidcd.Trim();
                aidcd = aidcd.Trim(',');
                if (aidcd != "")
                {
                    string atn = "",sql="";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    sql = "update medibvmmyy.v_chidinh set paid = (case when madoituong=1 then 0 else 1 end), idttrv=" + decimal.Parse(aid);
                    sql+=" where mabn='" + amabn + "' and  id in(" + aidcd + ")";
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    if (tmn_Toathuoctutruc.Checked)
                    {
                        sql = "update medibvmmyy.d_tienthuoc set done=1, idttrv=" + aid + " where mabn='" + amabn + "' and id in(" + aidcd + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                        //binh 130511
                        try
                        {
                            if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                        }
                        catch { }
                    }
                    if (tmn_Toathuocmuangoai.Checked)
                    {
                        sql = "update medibvmmyy.d_ngtruct set idttrv=" + aid + " where id in(" + aidcd + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    }
                    if (tmn_Toathuocmuangoai_chuaduyet.Checked)
                    {
                        amavp = amavp.Trim(',');
                        sql = "update medibvmmyy.d_thuocbhytct set paid=1,idttrv=" + aid + " where id in(" + aidcd + ") and mabd in ("+amavp+")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    }
                    if (tmn_thuvienphikhoa.Checked )
                    {
                        sql = "update medibvmmyy.v_vpkhoa set done = (case when madoituong=1 then 0 else 1 end), idttrv=" + decimal.Parse(aid);
                        sql += " where mabn='" + amabn + "' and  id in(" + aidcd + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    }
                }
                //if (amakp_td != "")
                //{
                //    string atn = "", sql = "";
                //    try
                //    {
                //        atn = cbNgayvv.Text.Substring(0, 10);
                //    }
                //    catch
                //    {
                //        atn = angay.Substring(0, 10);
                //    }
                //    sql = "update medibvmmyy.tiepdon set done=null where  makp in(" + amakp_td + ")";
                //    if (tt_thuchidinh_ngay == false) sql += " and maql=" + amaql;
                //    else sql += " and to_char(ngay,'dd/mm/yyyy')='" + atn + "' and mabn='" + amabn + "'";
                //    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                //}
                if (m_v.bCongkham(amavp))
                {
                    string atn = "", sql = "";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    //gam 27/10/2011
                    //sql = "update medibvmmyy.tiepdon set done=null where mabn='" + amabn + "' and maql=" + amaql;
                    if(!tt_thuchidinh_ngay)
                        sql = "update medibvmmyy.tiepdon set done=null where mabn='" + amabn + "' and maql=" + amaql;
                    else
                        sql = "update medibvmmyy.tiepdon set done=null where mabn='" + amabn + "' and makp in ('" + s_makp_thu.Trim(',').Replace(",", "','") + "') and to_char(ngay,'dd/mm/yyyy')='" + atn + "'";
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                }
                string ammyytu = "";
                bool bHoantra_blai_tamung = m_v.bThuchiravien_hoantra_bienlaitamung(m_userid);
                foreach (DataRow r in m_dstamung.Tables[0].Select("chon=1"))
                {
                    ammyytu = m_v.get_mmyy(r["ngay"].ToString());
                    m_v.execute_data_mmyy(ammyytu, "update medibvmmyy.v_tamung set done=1, idttrv=" + aid + ",ngaytra=to_date('"+txtNgaythu.Text.Substring(0,10)+"','dd/mm/yyyy') where id=" + r["id"].ToString());
                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_tontamung set done=1, idttrv=" + aid + ",ngaytra=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')  where id=" + r["id"].ToString());
                    if (bHoantra_blai_tamung)
                    {
                        m_v.upd_v_hoantra(ammyy, decimal.Parse(r["id"].ToString()), decimal.Parse(r["quyenso"].ToString()), decimal.Parse(r["sobienlai"].ToString()), angay.Substring(0, 10), angay.Substring(0, 10), amabn, decimal.Parse(m_mavaovien), decimal.Parse(m_maql), txtHoten.Text, r["makp"].ToString(), decimal.Parse(r["sotien"].ToString()), "3", decimal.Parse(m_userid), 1, decimal.Parse(aloaibn));
                    }
                }
                m_id = aid;
                if (m_id == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this,"Lỗi lưu dữ liệu! \n Chưa lưu dược hoá đơn!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                if (MessageBox.Show(this,"Thông tin thay đổi đã được cập nhật! \n Có muốn in lại hoá đơn vừa sửa không?",m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inhoadon(true);
                                }
                            }
                            else
                            {
                                f_Inhoadon(false);
                            }
                        }
                        if (tmn_Luuin_Chiphi.Checked)
                        {
                            if (asua)
                            {
                                if (MessageBox.Show(this,"Thông tin thay đổi đã được cập nhật! \n Có muốn in lại chi phí vừa sửa không?",m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                    if (bInphieumiengiam && toolStrip_Mien.Text.Trim().Trim('0')!="" ) // gam hepa 17-06-2011
                    {
                        f_InPhieuMien(aid);
                    }
                    butMoi.Focus();
                }
            }
            catch//(Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
        private void f_Luu(bool bdichvu, DataRow[] dsHoadon)
        {
            decimal am_id = decimal.Parse((m_id==""||m_id=="-")?"0":m_id);
            if (dsHoadon.Length <= 0) 
                return;
            if (bdichvu)
            {
                txtSobienlai.Text = f_Get_Sobienlai(s_quyenso_dichvu).Split(':')[0];
                cbKyhieu.SelectedValue = s_quyenso_dichvu;
            }
            try
            {
                bool asua = (m_id != "" && m_id != "0" && am_id > 0 && m_id != "-" );
                string atmp = "", aidcd = "", amakp_ll = "01";
                butLuu.Enabled = false;
                if (dsHoadon.Length <= 0)
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Đề nghị nhập nội dung thu viện phí!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenvp.Focus();
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
                //if (cbDoituongTD.SelectedValue.ToString() != "1" && toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
                //{
                //    f_FullScreen(false);
                //    butLuu.Enabled = true;
                //    MessageBox.Show(this, "Đề nghị nhập người duyệt miễn giảm!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cbKymien.Focus();
                //    SendKeys.Send("{F4}");
                //    return;
                //}
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "", amaql = "", aidkhoa = "", amakp = "", ahoten = "", anamsinh = "", adiachi = "", aloai = "", aloaibn = "", auserid = "", aphai = "", amavp = "";
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
                    MessageBox.Show(this, "Chọn quyển sổ thu viện phí!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    lbKyhieu_Click(null, null);
                    cbKyhieu.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                amabn = txtMabn.Text.Trim() + txtMabn1.Text.Trim();
                if (txtMabn.Text.Trim()==""||txtMabn1.Text.Trim()==""||txtHoten.Text.Trim()=="")
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, "Nhập thông tin bệnh nhân!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMabn.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                try
                {
                    amakp = cbotenpk.SelectedValue.ToString();
                }
                catch
                {
                    amakp = m_makp_khongkham;
                }
                amakp_ll = amakp;
                if (amakp_ll == "00" || amakp_ll == "")
                {
                    amakp_ll = m_makp_khongkham;
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
                if (txtSonha.Text != "")
                {
                    adiachi = txtSonha.Text.Trim() + ",";
                }
                if (txtThonpho.Text != "")
                {
                    adiachi += txtThonpho.Text.Trim() + ",";
                }
                if (cbXa.Text.ToUpper().Trim() != "KHÔNG XÁC ĐỊNH")
                {
                    if (adiachi != "")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbXa.Text.Trim();
                }
                if (cbQuan.Text.ToUpper().Trim() != "KHÔNG XÁC ĐỊNH")
                {
                    if (adiachi != "")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbQuan.Text.Trim();
                }
                if (cbTinh.Text.ToUpper().Trim() != "KHÔNG XÁC ĐỊNH")
                {
                    if (adiachi != "")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbTinh.Text.Trim();
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
                    aphai = decimal.Parse(cbGioitinh.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    aphai = "0";
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
                aidkhoa = "0";
                if (amaql != "" && amaql != "0")
                {
                    if (m_v.f_parse_date(cbNgayvv.Text.Substring(0, 10)) > txtNgaythu.Value)
                    {
                        MessageBox.Show(this, "Đề nghị chọn ngày thu lớn hơn hay = ngày bệnh nhân vào viện (" + cbNgayvv.Text.Substring(0, 10) + ")!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                        if (MessageBox.Show(this, "Hết sổ, đề nghị chọn sổ mới! \n Có muốn chọn sổ khác không?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                            //butLuu.Enabled = true;
                            //MessageBox.Show(this, "Không tìm thấy quyển sổ thu viện phí! \n Đề nghị chọn sổ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cbKyhieu.Enabled = false;
                            //lbKyhieu_Click(null, null);
                            //cbKyhieu.Focus();
                            //SendKeys.Send("{F4}");
                            //return;
                        }
                }
                if (m_bnmoi || v_chuyenchidinhCLS)
                {
                    try
                    {
                        string m_khongdau = m_v.f_khongdau(ahoten);
                        if (v_NamBTDBN.IndexOf(m_v.get_mmyy(angay) + "+") == -1) v_NamBTDBN = v_NamBTDBN + m_v.get_mmyy(angay) + "+";
                        //Luu hanh chanh
                        if (!m_v.upd_btdbn(amabn, ahoten, txtNgaysinh.Text, anamsinh, decimal.Parse(cbGioitinh.SelectedValue.ToString()), mann.Text.Trim(), madantoc.Text.Trim(), txtSonha.Text.Trim(), txtThonpho.Text.Trim(), "", cbTinh.SelectedValue.ToString(), cbQuan.SelectedValue.ToString(), cbXa.SelectedValue.ToString(), -decimal.Parse(auserid), v_NamBTDBN, m_khongdau))
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
                #region

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_vienphill", "id=" + aid + " and mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "upd", s);
                }
                //else m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "ins");

                if (aid != "0")
                {
                    foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_vienphict where id=" + aid + "").Tables[0].Rows)
                    {
                        string s = m_v.fields(m_v.user + ammyy + ".v_vienphict", "id=" + aid + " and stt=" + int.Parse(r1["stt"].ToString()));
                        m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "upd", s);
                    }
                } //else m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "ins");


                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_mienngtru", "id=" + aid);
                    m_v.upd_eve_tables(ammyy, itablemien, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablemien, int.Parse(m_userid), "upd", s);
                }
                #endregion
                asobienlai = txtSobienlai.Text.Trim();
                if (aid != "0")
                {
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_vienphict where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_mienngtru where id = " + aid);
                }
                quyensodv = sobienlaidv = "";
                if (v_Quanglydichvu)
                {
                    quyensodv = lbl_quyensodichvu.Text.Trim();
                    sobienlaidv = lbl_SBLdichvu.Text.Trim();
                }
                decimal atamung = 0;
                try
                {
                    atamung = decimal.Parse(toolStrip_Tamung.Text);
                }
                catch { atamung = 0; }
                aid = m_v.upd_v_vienphill(ammyy, decimal.Parse(aid), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), amakp_ll, ahoten, anamsinh, adiachi, decimal.Parse(aloai), decimal.Parse(aloaibn), decimal.Parse(auserid), decimal.Parse(aphai), "", "", chkTheKB.Checked ? 2 : 0, (quyensodv != "") ? decimal.Parse(quyensodv) : 0, (sobienlaidv != "") ? decimal.Parse(sobienlaidv) : 0, "");
                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set tamung=" + atamung + " where id=" + aid);
                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set thanhtoan=" + (rdTienmat.Checked ? 0 : rdTrasau.Checked ? 1 : rdThe.Checked ? 2 : 0) + " where id=" + aid);// gam hepa 14-05-2011
                if (!v_Quanglydichvu) m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
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
                    
                    if (!bLuumien)
                    {
                        m_v.upd_v_mienngtru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien), decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", "")), "Miển giảm thu trực tiếp", decimal.Parse(amaduyet));
                        bLuumien = true;
                    }
                }
                if (aid != "0")
                {
                    decimal astt = 1, vat = 0;
                    string atn = "";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    DataRow r0;
                    bool bHoadondv = false, bHoadon = false;
                    foreach (DataRow r in dsHoadon)
                    {
                        try
                        {
                            vat = (r["vat"].ToString().Trim() == "") ? 0 : decimal.Parse(r["vat"].ToString().Trim());
                            if (v_Quanglydichvu)
                            {
                                r0 = m_v.getrowbyid(dtdv, "id=" + decimal.Parse(r["mavp"].ToString()));
                                if (r0 != null)
                                {
                                    vat = decimal.Parse(r0["vat"].ToString());
                                    m_v.upd_v_vienphict("v_vienphidv", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), vat, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
                                    bHoadondv = true;
                                }
                                else bHoadon = true;
                            }
                            int co = 0, i_dotkhuyenmai = 0;

                            if (chkKhuyenMai.Checked)/////////////////LUU  hoa don khuyen mai
                            {
                                DataSet ads_km = new DataSet();
                                string smakp = "", smabs = "";
                                smabs = r["mabs"].ToString() == "" ? "0" : r["mabs"].ToString();
                                smakp = r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll;

                                try
                                {
                                    ads_km = m_v.get_data("select a.idvp,a.iddot from medibv.v_giavp_khuyenmai a inner join medibv.v_dot_khuyenmai b  on b.id=a.iddot where b.hide=0 and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') >= b.tungay and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')<= b.denngay");

                                    if (ads_km.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow r_ct in ads_km.Tables[0].Select("idvp=" + r["mavp"].ToString()))
                                        {

                                            i_dotkhuyenmai = (r_ct["iddot"].ToString() == "") ? 0 : int.Parse(r_ct["iddot"].ToString());
                                            co = 1;
                                            break;
                                        }
                                    }

                                }
                                catch { }
                            }

                            m_v.upd_v_vienphict("v_vienphict", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), vat, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
                            if (co != 0)//binh 22022011
                            {
                                m_v.execute_data("update medibv" + ammyy + ".v_vienphict set khuyenmai=" + i_dotkhuyenmai + " where id=" + aid + " and stt=" + astt + " and idchidinh=" + r["idcd"].ToString());
                            }
                            //

                            astt += 1;
                            //update paid chi dinh
                            if (r["idcd"].ToString().Trim() != "0" && r["idcd"].ToString().Trim() != "")
                            {
                                aidcd += ",";
                                aidcd += r["idcd"].ToString();
                            }
                            else
                            {
                                if (v_chuyenchidinhCLS)
                                {
                                    aidchidinh = "";
                                    aidchidinh = m_v.get_id_v_chidinh.ToString();
                                    if (r["chon"].ToString() == "1")
                                        m_v.upd_v_chidinh_tt(ammyy, decimal.Parse(aidchidinh), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), angay, int.Parse(aloai), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, int.Parse(r["madoituong"].ToString()), int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 1, 0, -int.Parse(auserid), 1, 1, 0, 0, decimal.Parse(aid));
                                    else
                                        m_v.upd_v_chidinh_tt(ammyy, decimal.Parse(aidchidinh), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), angay, int.Parse(aloai), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, int.Parse(r["madoituong"].ToString()), int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 1, 0, -int.Parse(auserid), 1, 1, 1, 1, decimal.Parse(aid));
                                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphict set idchidinh=" + aidchidinh + " where mavp=" + r["mavp"].ToString() + " and id=" + aid + "");
                                }
                            }
                            //if (r["makp"].ToString().Trim() != "")
                            //{
                            //    if (amakp_td != "") amakp_td += ",";
                            //    amakp_td += "'" + r["makp"].ToString() + "'";
                            //}
                            if (r["mavp"].ToString().Trim() != "")
                            {
                                amavp += r["mavp"].ToString().Trim() + ",";
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (bHoadon && bHoadondv && quyensodv == aquyenso)
                    {
                        m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                        lbl_SBLdichvu.Text = f_Get_Sobienlai(m_cur_quyenso_dichvu).Split(':')[0];
                        lbl_quyensodichvu.Text = m_cur_quyenso_dichvu;
                        quyensodv = lbl_quyensodichvu.Text.Trim();
                        sobienlaidv = lbl_SBLdichvu.Text.Trim();
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set sobienlaidv=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                    }
                    if (bHoadondv) m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                    else if (v_Quanglydichvu && bHoadon) m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                    if (v_Quanglydichvu && bHoadondv && !bHoadon) m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set quyenso=" + decimal.Parse(quyensodv) + ",sobienlai=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                }
                aidcd = aidcd.Trim();
                aidcd = aidcd.Trim(',');
                if (aidcd != "")
                {
                    string atn = "", sql = "";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    sql = "update medibvmmyy.v_chidinh set paid = (case when madoituong=1 then 0 else 1 end), idttrv=" + decimal.Parse(aid);
                    sql += " where mabn='" + amabn + "' and  id in(" + aidcd + ")";
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    if (tmn_Toathuoctutruc.Checked)
                    {
                        sql = "update medibvmmyy.d_tienthuoc set done=1, idttrv=" + aid + " where mabn='" + amabn + "' and id in(" + aidcd + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                        //binh 130511
                        try
                        {
                            if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                        }
                        catch { }
                    }
                    if (tmn_Toathuocmuangoai.Checked)
                    {
                        sql = "update medibvmmyy.d_ngtruct set idttrv=" + aid + " where id in(" + aidcd + ")";
                        if (amavp.Trim().Trim(',') != "") sql += " and mabd in(" + amavp.Trim().Trim(',') + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    }
                    if (tmn_thuvienphikhoa.Checked)
                    {
                        sql = "update medibvmmyy.v_vpkhoa set done = (case when madoituong=1 then 0 else 1 end ), idttrv=" + decimal.Parse(aid);
                        sql += " where mabn='" + amabn + "' and  id in(" + aidcd + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    }
                }
                string ammyytu = "";
                bool bHoantra_blai_tamung = m_v.bThuchiravien_hoantra_bienlaitamung(m_userid);
                foreach (DataRow r in m_dstamung.Tables[0].Select("chon=1"))
                {
                    ammyytu = m_v.get_mmyy(r["ngay"].ToString());
                    m_v.execute_data_mmyy(ammyytu, "update medibvmmyy.v_tamung set done=1, idttrv=" + aid + ",ngaytra=to_date('"+txtNgaythu.Text.Substring(0,10)+"','dd/mm/yyyy') where id=" + r["id"].ToString());
                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_tontamung set done=1, idttrv=" + aid + ",ngaytra=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') where id=" + r["id"].ToString());
                    if (bHoantra_blai_tamung)
                    {
                        m_v.upd_v_hoantra(ammyy, decimal.Parse(r["id"].ToString()), decimal.Parse(r["quyenso"].ToString()), decimal.Parse(r["sobienlai"].ToString()), angay.Substring(0, 10), angay.Substring(0, 10), amabn, decimal.Parse(m_mavaovien), decimal.Parse(m_maql), txtHoten.Text, r["makp"].ToString(), decimal.Parse(r["sotien"].ToString()), "3", decimal.Parse(m_userid), 1, decimal.Parse(aloaibn));
                    }
                }
                if (m_v.bCongkham(amavp))
                {
                    string atn = "", sql = "";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    //gam 27/10/2011
                    //sql = "update medibvmmyy.tiepdon set done=null where mabn='" + amabn + "' and maql=" + amaql;
                    if (!tt_thuchidinh_ngay)
                        sql = "update medibvmmyy.tiepdon set done=null where mabn='" + amabn + "' and maql=" + amaql;
                    else
                        sql = "update medibvmmyy.tiepdon set done=null where mabn='" + amabn + "' and makp in ('" + s_makp_thu.Trim(',').Replace(",", "','") + "') and to_char(ngay,'dd/mm/yyyy')='" + atn + "'";
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                }
                //if (amakp_td != "")
                //{
                //    string atn = "", sql = "";
                //    try
                //    {
                //        atn = cbNgayvv.Text.Substring(0, 10);
                //    }
                //    catch
                //    {
                //        atn = angay.Substring(0, 10);
                //    }
                //    sql = "update medibvmmyy.tiepdon set done=null where  makp in(" + amakp_td + ")";
                //    if (tt_thuchidinh_ngay == false) sql += " and maql=" + amaql;
                //    else sql += " and to_char(ngay,'dd/mm/yyyy')='" + atn + "' and mabn='" + amabn + "'";
                //    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                //}
                m_id = aid;
                if (m_id == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this, "Lỗi lưu dữ liệu! \n Chưa lưu dược hoá đơn!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    f_Enable(false);
                    f_Enable_HC(false);
                    if (tmn_Luuin_Hoadon_Icon.Checked)
                    {
                        if (tmn_Luuin_Hoadon.Checked)
                        {
                            if (asua && b_sua)
                            {
                                if (MessageBox.Show(this, "Thông tin thay đổi đã được cập nhật! \n Có muốn in lại hoá đơn vừa sửa không?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inhoadon(bdichvu);
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
                                if (MessageBox.Show(this, "Thông tin thay đổi đã được cập nhật! \n Có muốn in lại chi phí vừa sửa không?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
            catch//(Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
        }
        private void f_Sua()
        {
            try
            {
                if (m_v.tt_suahoadon(m_userid))
                {
                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                    {
                        MessageBox.Show(this,"Hoá đơn đã hoàn trả, không cho phép sửa. \n Liên hệ quản trị khi có nhu cầu!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        chkTheKB.Enabled = true;
                        f_Enable(true);
                        f_Enable_HC(false);
                        txtTenvp.Focus();
                        dgGia.Visible = false;
                        txtMabn.Enabled = false;
                        txtMabn1.Enabled = false;
                        tmn_Danhsachcho.Enabled = false;
                        b_sua = true;
                    }
                }
                else
                {
                    MessageBox.Show(this,"Chưa được phân quyền sửa. \n Liên hệ quản trị khi có nhu cầu!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (m_v.tt_xoahoadon(m_userid))
                {
                    string ammyy = txtNgaythu.Value.Month.ToString().PadLeft(2, '0') + txtNgaythu.Value.Year.ToString().Substring(2);
                    decimal am_id = decimal.Parse(m_id) * -1;
                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                    {
                        MessageBox.Show(this,"Hoá đơn này đã làm biên lai hoàn trả. Không thể Xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (bDichvu_dathuchien(m_id, ammyy) && m_v.tt_huyhoadon_dathuchien(m_userid)==false)
                    {
                        MessageBox.Show(this, "Các dịch vụ này đã thực hiện, không thể Xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                        if (MessageBox.Show(this,"Ghi chú: \n Nếu xoá xem như hoá đơn chưa phát sinh, sẽ không có trong báo cáo.\n -Nếu hoàn xem như hoá đơn đã phát sinh và không có giá trị sử dụng, có trong báo cáo hoàn. \n Đồng ý xoá hoá đơn này?",m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            #region 
                           
                            if (m_id != "0")
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".v_vienphill", "id=" + m_id + " and mabn='" + txtMabn.Text + txtMabn1.Text + "'");
                                m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "del");
                                m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "del", s);
                            }
                            //else m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "ins");
                            if (m_id != "0")
                            {
                                foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_vienphict where id=" + m_id + "").Tables[0].Rows)
                                {
                                    string s = m_v.fields(m_v.user + ammyy + ".v_vienphict", "id=" + m_id + " and stt=" + int.Parse(r1["stt"].ToString()));
                                    m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "del");
                                    m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "del", s);
                                    if (m_v.bCongkham(r1["mavp"].ToString()))
                                    {
                                        if (!tt_thuchidinh_ngay)//gam 17/10/2011
                                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set done='c' where mabn='" + txtMabn.Text + txtMabn1.Text + "' and maql=" + m_maql);
                                        else
                                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set done='c' where mabn='" + txtMabn.Text + txtMabn1.Text + "' and makp in ('" + s_makp_thu.Trim(',').Replace(",", "','") + "') and to_char(ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0,10) + "'");
                                        //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.tiepdon set done='c' where mabn='" + txtMabn.Text + txtMabn1.Text + "' and maql=" + m_maql);
                                    }
                                }
                                if (v_Quanglydichvu) m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_vienphidv where id=" + m_id + "");
                            }
                            
                            if (m_id != "0" && b_huykembldv)
                            {
                                string s = m_v.fields(m_v.user + ammyy + ".v_vienphill", "id=" + am_id + " and mabn='" + txtMabn.Text + txtMabn1.Text + "'");
                                m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "del");
                                m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "del", s);
                            }
                            //else m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "ins");
                            if (m_id != "0" && b_huykembldv )
                            {
                                foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_vienphict where id=" + am_id + "").Tables[0].Rows)
                                {
                                   
                                    string s = m_v.fields(m_v.user + ammyy + ".v_vienphict", "id=" + m_id + " and stt=" + int.Parse(r1["stt"].ToString()));
                                    m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "del");
                                    m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "del", s);
                                    
                                }
                                if (v_Quanglydichvu) m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_vienphidv where id=" + am_id + "");
                            }
                            #endregion//end

                            string s_ngayhuyblai = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');//binh

                            if (MessageBox.Show(this,"Xóa hoá đơn này có trong báo cáo không?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                m_v.upd_huybienlai(ammyy, decimal.Parse(m_id), "v_vienphill", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text.Trim(), cbotenpk.SelectedValue.ToString(), s_ngayhuyblai, decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text), "Hủy biên lai thu trực tiếp", int.Parse(m_userid), (toolStrip_Thucthu.Text.Trim() == "") ? 0 : decimal.Parse(toolStrip_Thucthu.Text));
                                if (b_huykembldv)
                                {
                                    m_v.upd_huybienlai(ammyy, decimal.Parse(m_id)*-1, "v_vienphill", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text.Trim(), cbotenpk.SelectedValue.ToString(), s_ngayhuyblai, decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text), "Hủy biên lai thu trực tiếp", int.Parse(m_userid), (toolStrip_Thucthu.Text.Trim() == "") ? 0 : decimal.Parse(toolStrip_Thucthu.Text));
                                }
                            }
                            else
                            {
                                m_v.upd_huybienlai(ammyy, decimal.Parse(m_id), "v_vienphill", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text.Trim(), cbotenpk.SelectedValue.ToString(), s_ngayhuyblai, decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text), "Hủy biên lai thu trực tiếp", int.Parse(m_userid), (toolStrip_Thucthu.Text.Trim() == "") ? 0 : decimal.Parse(toolStrip_Thucthu.Text));
                                if (b_huykembldv)
                                {
                                    m_v.upd_huybienlai(ammyy, decimal.Parse(m_id)*-1, "v_vienphill", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text.Trim(), cbotenpk.SelectedValue.ToString(), s_ngayhuyblai, decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text), "Hủy biên lai thu trực tiếp", int.Parse(m_userid), (toolStrip_Thucthu.Text.Trim() == "") ? 0 : decimal.Parse(toolStrip_Thucthu.Text));
                                }
                            }
                            if (tmn_Toathuoctutruc.Checked)
                            {
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.d_tienthuoc set done=0,idttrv=0 where to_char(idttrv)='" + m_id + "'");//thuoc tu truc
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=0,idttrv=0 where to_char(idttrv)='" + m_id + "'");//thuoc tu truc
                                if (b_huykembldv)
                                {
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_tienthuoc set done=0,idttrv=0 where to_char(idttrv)='" + decimal.Parse(m_id) * -1 + "'");//thuoc tu truc
                                }
                            }
                            if (tmn_Toathuocmuangoai.Checked)
                            {
                                //m_v.execute_data_mmyy(ammyy, "update medibvmmyy.d_ngtruct set idttrv=0 where to_char(idttrv)='" + m_id + "'");//thuoc mua ngoai
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_ngtruct set idttrv=0 where to_char(idttrv)='" + m_id + "'");//thuoc mua ngoai
                                if (b_huykembldv)
                                {
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_ngtruct set idttrv=0 where to_char(idttrv)='" + decimal.Parse(m_id) * -1 + "'");//thuoc mua ngoai
                                }
                            }
                            if (tmn_Toathuocmuangoai_chuaduyet.Checked)
                            {
                                m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_thuocbhytct set idttrv=0,paid=0 where to_char(idttrv)='" + m_id + "'");//thuoc mua ngoai
                                if (b_huykembldv)
                                {
                                    m_v.execute_data(cbNgayvv.Text.Substring(0, 10), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.d_thuocbhytct set idttrv=0,paid=0 where to_char(idttrv)='" + decimal.Parse(m_id) * -1 + "'");//thuoc mua ngoai
                                }
                            }
                            if (tmn_thuvienphikhoa.Checked)
                            {
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vpkhoa set idttrv=0, done=0 where to_char(idttrv)='" + m_id + "'");//thuoc mua ngoa
                                if (b_huykembldv)
                                {
                                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vpkhoa set idttrv=0, done=0 where to_char(idttrv)='" + decimal.Parse(m_id) * -1 + "'");//thuoc mua ngoa
                                }
                            }
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_chidinh set paid=0, idttrv=0 where idttrv=" + m_id + " and mavp in(select mavp from medibvmmyy.v_vienphict where id=" + m_id + ")");
                            if (b_huykembldv)
                            {
                                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_chidinh set paid=0, idttrv=0 where idttrv=" + m_id + " and mavp in(select mavp from medibvmmyy.v_vienphict where id=" + m_id + ")");
                            }
                            m_v.del_v_vienphill_new(ammyy, m_id, m_maql, txtmapk.Text, txtMabn.Text + txtMabn1.Text);
                            if (b_huykembldv)
                            {
                                m_v.del_v_vienphill_new(ammyy, am_id.ToString(), m_maql, txtmapk.Text, txtMabn.Text + txtMabn1.Text);
                            }
                            bool bHoantra_blai_tamung = m_v.bThuchiravien_hoantra_bienlaitamung(m_userid);
                            if (bHoantra_blai_tamung)
                            {
                                m_v.execute_data_mmyy(ammyy,"delete medibvmmyy.v_hoantra where id in (select id from medibvmmyy.v_tamung where idttrv="+m_id+")");
                            }
                           
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_tamung set done=0,idttrv=0 where idttrv=" + m_id);
                            f_Load_Thutrongngay();
                            f_Clear_HC();
                            m_dshoadon.Tables[0].Rows.Clear();
                            f_Tinhtien();
                            f_Enable(false);
                            f_Enable_HC(false);
                            butMoi.Focus();
                        }
                }
                else
                {
                    MessageBox.Show(this,"Chưa được phân quyền xóa. \n Liên hệ quản trị khi có nhu cầu!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {
            }
        }
        private void f_Inhoadon( bool b_Inhddichvu)
        {
            try
            {
                string dttachhoadon = m_v.tt_tachhoadon_dichvu(m_userid);
                string s_sttkham = lblSTTKham.Text;
                
                if (m_id != "")
                {
                    
                    string mmyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                    m_v.get_data_mmyy(mmyy, "update medibvmmyy.v_vienphill set dain=1 where id=" + m_id + "");
                    
                    string s = m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "select lanin from medibvmmyy.v_vienphill where id=" + m_id + "").Tables[0].Rows[0]["lanin"].ToString();
                    if (decimal.Parse(v_solanin) > decimal.Parse(s))
                    {
                        if (m_v.tt_Intheoloai(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Loai(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1",b_Inhddichvu);
                        }
                        if (m_v.tt_Intheonhom(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Nhom(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1",b_Inhddichvu);
                        }
                        if (m_v.tt_InchitietHD(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_chitiet(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)),b_Inhddichvu);
                        }
                        if (m_v.tt_InHDdacthu(m_userid))
                        {
                            m_frmprinthd = new frmPrintHD(m_v, m_userid);
                            m_frmprinthd.f_Print_BienlaiKB(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", ttrv_bienlai_dichvu, b_Inhddichvu, lblSTTKham.Text,m_userid);
                        }
                        if (m_v.tt_InHD_thuong(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Thuong(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", cbBacsi.Text + "^" + lblSTTKham.Text, "", ttrv_bienlai_dichvu);
                        }
                        if(!m_v.tt_Intheoloai(m_userid) && !m_v.tt_Intheonhom(m_userid) && !m_v.tt_InchitietHD(m_userid) && !m_v.tt_InHDdacthu(m_userid) && !m_v.tt_InHD_thuong(m_userid))
                        {
                            m_frmprinthd = new frmPrintHD(m_v, m_userid);
                            m_frmprinthd.f_Print_BienlaiKB_Thuong(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", cbBacsi.Text + "^" + lblSTTKham.Text, "", ttrv_bienlai_dichvu, b_Inhddichvu);
                        }
                        if (v_Quanglydichvu) m_frmprinthd.f_Print_BienlaiKB_gtgt(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)));
                    }
                    else
                    {
                        MessageBox.Show(this,"Số lần in " + s + " vượt quá số lần in quy định " + v_solanin + " !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
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
                if (tmn_Luuin_Chiphi_cadot.Checked)
                    m_frmprinthd.f_Print_ChiphiKBCT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), txtMabn.Text + txtMabn1.Text, txtNgaythu.Text.Substring(0,10));
                else
                    m_frmprinthd.f_Print_ChiphiKBCT(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)));
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
                m_frmhoantra.s_loaihd = m_v.s_loaiform_thutructiep;
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
                Column2_3.HeaderText = "Tên viện phí (Tìm thấy: "+dv.Table.Select(aft).Length.ToString()+")";
                if (dgGia.Visible == false && this.ActiveControl==txtTenvp)
                {
                    dgGia.Visible = true;
                }
            }
            catch
            {
                Column2_3.HeaderText = "Tên viện phí (Tìm thấy: " + m_dsgiavp.Tables[0].Rows.Count.ToString() + ")";
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
                    MessageBox.Show(this,"Hết sổ, đề nghị chọn sổ mới!\n Đề nghị chọn sổ.",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
           catch (Exception exx)
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

                if (v_chuakhaigiavp)
                {
                    if (arv[r["field_gia"].ToString().Trim()].ToString() == "0")
                    {
                        txtSoluong.Focus();
                        txtDongia.Text = txtDongia.Text;
                    }
                    else
                    {
                        txtDongia.Text = arv[r["field_gia"].ToString().Trim()].ToString();                       
                    }
                }
                else
                {
                    txtDongia.Text = arv[r["field_gia"].ToString().Trim()].ToString();
                }
                txtTenvp.Text = arv["ten"].ToString();
             
                if (r["mien"].ToString() == "1")
                {
                    txtMien.Text = txtDongia.Text.ToString();
                }
                else
                {
                    txtMien.Text = "0";
                }
                if (m_v.sys_cokhuyenmai_tt && r["mien"].ToString() != "1" && chkKhuyenMai.Checked)
                {
                    try
                    {
                        txtMien.Text = arv["sotienkhuyenmai"].ToString();
                        txtTylemien.Text = arv["tylekhuyenmai"].ToString();
                    }
                    catch
                    {
                        
                    }
                }
                f_Tinhtien_mon();
            }
            catch(Exception ex)
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
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituong.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r = dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString())[0];
                string adoituong = cbDoituong.SelectedValue.ToString();
                string afieldgia = "";
                if (v_chuakhaigiavp)
                {
                    if (r["field_gia"].ToString().Trim() == "0")
                    {
                        txtSoluong.Focus();
                        afieldgia = txtDongia.Text;
                    }
                    else
                    {
                        afieldgia = r["field_gia"].ToString().Trim();
                    }
                }
                else
                {
                    afieldgia = r["field_gia"].ToString().Trim();
                }

              //  string afieldgia = r["field_gia"].ToString().Trim();
                
                string amien100 = r["mien"].ToString();
                decimal adongia = 0, asoluong = 0, amien = 0, athucthu = 0;
                foreach(string aid in v_id.Split(','))
                {
                    foreach (DataRow r1 in m_dsgiavp.Tables[0].Select("id =" + aid))
                    {
                        try
                        {
                            adongia = decimal.Parse(r1[afieldgia].ToString());
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
                        amien = (amien100 == "1" ? asoluong * adongia : 0);

                        athucthu = asoluong * adongia - amien;

                        DataRow[] r_chenhlech1 = m_dsgiavp.Tables[0].Select("id=" + aid + " and chenhlech=1");

                        DataRow[] dr = m_dsgiavp.Tables[0].Select("trongoi=1 and id=" + aid);

                        if (r_chenhlech1.Length > 0 && r1[m_v.field_gia(m_v.iTunguyen.ToString())].ToString() != r1["gia_bh"].ToString())
                        {

                            upd_chenhlech(false, int.Parse(aid), asoluong, amien);

                            cbDoituongTD.SelectedValue = m_v.iTunguyen.ToString();
                            upd_chenhlech(true, int.Parse(aid), asoluong, amien);

                        }
                        else
                        {
                            if (dr.Length > 0)
                            {
                                string sql = "";
                                if (s_madoituongthu != "")
                                {
                                    sql = "select a.*,b.*,c.* from medibv.v_trongoi a inner join medibv.v_giavp b on a.id_gia=b.id left join medibv.doituong c on a.madoituong=c.madoituong where a.madoituong in(0," + s_madoituongthu + ") and a.id=" + aid + "  order by a.stt";
                                }
                                else
                                {
                                    sql = "select a.*,b.*,c.* from medibv.v_trongoi a inner join medibv.v_giavp b on a.id_gia=b.id left join medibv.doituong c on a.madoituong=c.madoituong where a.id=" + aid + "  order by a.stt";
                                }
                                foreach (DataRow r12 in m_v.get_data(sql).Tables[0].Rows)
                                {
                                    DataRow ra = m_dshoadon.Tables[0].NewRow();
                                    ra["id"] = 0;
                                    ra["chon"] = 1;
                                    ra["idcd"] = 0;
                                    ra["mavp"] = r12["id_gia"].ToString();
                                    ra["ma"] = r1["ma"].ToString();
                                    ra["ten"] = r12["ten"].ToString();
                                    ra["ngaycd"] = txtNgaythu.Text.Substring(0, 10);
                                    ra["dvt"] = r1["dvt"].ToString();
                                    ra["soluong"] = asoluong;
                                    ra["dongia"] = decimal.Parse(r12["sotien"].ToString());
                                    ra["mien"] = amien;
                                    ra["thucthu"] = athucthu;

                                    if (r12["madoituong"].ToString() != "0")
                                    {
                                        ra["madoituong"] = r12["madoituong"].ToString();
                                        ra["doituong"] = r12["doituong"].ToString();
                                    }
                                    else
                                    {
                                        ra["madoituong"] = cbDoituongTD.SelectedValue.ToString();
                                        ra["doituong"] = cbDoituongTD.Text.Trim();
                                    }

                                    if (tmn_Nhapkhoaphong.Checked)
                                    {
                                        try
                                        {
                                            ra["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                                            ra["tenkp"] = cbKhoa.Text.Trim();
                                        }
                                        catch
                                        {
                                            ra["makp"] = m_makp_khongkham;
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            ra["makp"] = cbotenpk.SelectedValue.ToString().Trim();
                                            ra["tenkp"] = cbotenpk.Text.Trim();
                                        }
                                        catch
                                        {
                                            ra["makp"] = m_makp_khongkham;
                                        }
                                    }
                                    try
                                    {
                                        ra["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                                    }
                                    catch
                                    {
                                        ra["mabs"] = "";
                                    }
                                    ra["id_loai"] = r1["id_loai"].ToString();
                                    ra["tenbs"] = cbBacsi.Text.Trim();
                                    m_dshoadon.Tables[0].Rows.Add(ra);
                                }
                            }
                            else
                            {
                                if (m_dshoadon.Tables[0].Select("mavp=" + r1["id"].ToString() + " and madoituong=" + adoituong).Length > 0)
                                {
                                    DataRow r2 = m_dshoadon.Tables[0].Select("mavp=" + r1["id"].ToString() + " and madoituong=" + adoituong)[0];

                                    r2["mavp"] = r1["id"].ToString();
                                    r2["ma"] = r1["ma"].ToString();
                                    r2["ten"] = r1["ten"].ToString();
                                    r2["ngaycd"] = txtNgaythu.Text.Substring(0, 10);
                                    r2["dvt"] = r1["dvt"].ToString();
                                    r2["soluong"] = asoluong;
                                    r2["dongia"] = adongia;
                                    r2["mien"] = amien;

                                    r2["thucthu"] = athucthu;
                                    r2["madoituong"] = adoituong;
                                    r2["doituong"] = cbDoituong.Text.Trim();

                                    if (tmn_Nhapkhoaphong.Checked)
                                    {
                                        try
                                        {
                                            r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                                            r["tenkp"] = cbKhoa.Text.Trim();
                                        }
                                        catch
                                        {
                                            r["makp"] = m_makp_khongkham;
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            r["makp"] = cbotenpk.SelectedValue.ToString().Trim();
                                            r["tenkp"] = cbotenpk.Text.Trim();
                                        }
                                        catch
                                        {
                                            r["makp"] = m_makp_khongkham;
                                        }
                                    }

                                    try
                                    {
                                        r2["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                                    }
                                    catch
                                    {
                                        r2["mabs"] = "";
                                    }
                                    r2["id_loai"] = r1["id_loai"].ToString();
                                    r2["tenbs"] = cbBacsi.Text.Trim();
                                }
                                else
                                {
                                    DataRow r2 = m_dshoadon.Tables[0].NewRow();
                                    r2["id"] = 0;
                                    r2["chon"] = 1;
                                    r2["idcd"] = 0;
                                    r2["mavp"] = r1["id"].ToString();
                                    r2["ma"] = r1["ma"].ToString();
                                    r2["ten"] = r1["ten"].ToString();
                                    r2["ngaycd"] = txtNgaythu.Text.Substring(0, 10);
                                    r2["dvt"] = r1["dvt"].ToString();
                                    r2["soluong"] = asoluong;
                                    r2["dongia"] = adongia;
                                    r2["mien"] = amien;

                                    r2["thucthu"] = athucthu;
                                    r2["madoituong"] = adoituong;
                                    r2["doituong"] = cbDoituong.Text.Trim();

                                    if (tmn_Nhapkhoaphong.Checked)
                                    {
                                        try
                                        {
                                            r2["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                                            r2["tenkp"] = cbKhoa.Text.Trim();
                                        }
                                        catch
                                        {
                                            r2["makp"] = m_makp_khongkham;
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            r2["makp"] = cbotenpk.SelectedValue.ToString().Trim();
                                            r2["tenkp"] = cbotenpk.Text.Trim();
                                        }
                                        catch
                                        {
                                            r2["makp"] = m_makp_khongkham;
                                        }
                                    }
                                    try
                                    {
                                        r2["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                                    }
                                    catch
                                    {
                                        r2["mabs"] = "";
                                    }
                                    r2["id_loai"] = r1["id_loai"].ToString();
                                    r2["tenbs"] = cbBacsi.Text.Trim();
                                    m_dshoadon.Tables[0].Rows.Add(r2);
                                }
                            }
                        }
                    }
                }
                f_Tinhtien();
            }
            catch
            {
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
                decimal adongia = 0, asoluong = 0, amien = 0, athucthu = 0;
                try
                {
                    adongia = decimal.Parse(txtDongia.Text.Trim().Replace(" ",""));
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
                try
                {
                   
                    amien = decimal.Parse(txtMien.Text.Trim().Replace(",", ""));
                    

                    if (amien < 0 || amien > adongia * asoluong)
                    {
                        amien = 0;
                    }
                }
                catch
                {
                    amien = 0;
                }
                athucthu = asoluong * adongia - amien;

                DataRow arv = m_dsgiavp.Tables[0].Select("id=" + m_id_gia)[0];

                DataRow[] r_chenhlech1 = m_dsgiavp.Tables[0].Select("id=" + m_id_gia + " and chenhlech=1");

                DataRow[] dr = m_dsgiavp.Tables[0].Select("trongoi=1 and id=" + m_id_gia);

                if (r_chenhlech1.Length > 0 && m_dsdoituong.Tables[0].Select("chenhlech=1 and madoituong=" + cbDoituongTD.SelectedValue.ToString()).Length > 0)//arv[m_v.field_gia(cbDoituong.SelectedValue.ToString())].ToString() != arv["gia_bh"].ToString() && 
                {
                    if (m_dsdoituong.Tables[0].Select("chenhlech=1 and madoituong=" + cbDoituong.SelectedValue.ToString()).Length > 0)
                    {
                        athucthu = upd_chenhlech(false, int.Parse(m_id_gia), asoluong, amien);
                        cbDoituong.SelectedValue = m_v.iTunguyen.ToString();
                        athucthu = upd_chenhlech(true, int.Parse(m_id_gia), asoluong, amien);
                    }
                    else
                    {
                        if (cbDoituong.SelectedValue.ToString() == m_v.iTunguyen.ToString()) athucthu = upd_chenhlech(true, int.Parse(m_id_gia), asoluong, amien);
                        else athucthu = upd_chenhlech(false, int.Parse(m_id_gia), asoluong, amien);
                    }
                }
                else
                {
                    if (dr.Length > 0)
                    {
                        string sql = "";
                        if (s_madoituongthu != "")
                        {
                            sql = "select a.*,b.*,c.* from medibv.v_trongoi a inner join medibv.v_giavp b on a.id_gia=b.id left join medibv.doituong c on a.madoituong=c.madoituong where a.madoituong in(0," + s_madoituongthu + ") and a.id=" + m_id_gia + "  order by a.stt";
                        }
                        else
                        {
                            sql = "select a.*,b.*,c.* from medibv.v_trongoi a inner join medibv.v_giavp b on a.id_gia=b.id left join medibv.doituong c on a.madoituong=c.madoituong where a.id=" + m_id_gia + "  order by a.stt";
                        }

                        foreach (DataRow r1 in m_v.get_data(sql).Tables[0].Rows)
                        {
                            DataRow r = m_dshoadon.Tables[0].NewRow();
                            r["id"] = 0;
                            r["chon"] = 1;
                            r["idcd"] = 0;
                            r["mavp"] = r1["id_gia"].ToString();
                            r["ma"] = arv["ma"].ToString();
                            r["ten"] = r1["ten"].ToString();
                            r["ngaycd"] = txtNgaythu.Text.Substring(0, 10);
                            r["dvt"] = arv["dvt"].ToString();
                            r["soluong"] = asoluong;
                            r["dongia"] = decimal.Parse(r1["sotien"].ToString());
                            r["mien"] = amien;
                            r["thucthu"] = athucthu;
                            r["dichvu"] = arv["dichvu"].ToString();//gam 09/11/2011
                            if (r1["madoituong"].ToString() != "0")
                            {
                                r["madoituong"] = r1["madoituong"].ToString();
                                r["doituong"] = r1["doituong"].ToString();
                            }
                            else
                            {
                                r["madoituong"] = cbDoituongTD.SelectedValue.ToString();
                                r["doituong"] = cbDoituongTD.Text.Trim();
                            }

                            if (tmn_Nhapkhoaphong.Checked)
                            {
                                try
                                {
                                    r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                                    r["tenkp"] = cbKhoa.Text.Trim();
                                }
                                catch
                                {
                                    r["makp"] = m_makp_khongkham;
                                }
                            }
                            else
                            {
                                try
                                {
                                    r["makp"] = cbotenpk.SelectedValue.ToString().Trim();
                                    r["tenkp"] = cbotenpk.Text.Trim();
                                }
                                catch
                                {
                                    r["makp"] = m_makp_khongkham;
                                }
                            }


                            try
                            {
                                r["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                            }
                            catch
                            {
                                r["mabs"] = "";
                            }
                            r["id_loai"] = arv["id_loai"].ToString();
                            r["tenbs"] = cbBacsi.Text.Trim();
                            m_dshoadon.Tables[0].Rows.Add(r);
                        }
                    }
                    else
                    {

                        if (m_dshoadon.Tables[0].Select("mavp=" + arv["id"].ToString() + " and madoituong=" + cbDoituong.SelectedValue.ToString()).Length > 0)
                        {
                            DataRow r = m_dshoadon.Tables[0].Select("mavp=" + arv["id"].ToString() + " and madoituong=" + cbDoituong.SelectedValue.ToString())[0];
                            r["mavp"] = arv["id"].ToString();
                            r["ma"] = arv["ma"].ToString();
                            r["ten"] = arv["ten"].ToString();
                            r["ngaycd"] = txtNgaythu.Text.Substring(0, 10);
                            r["dvt"] = arv["dvt"].ToString();
                            r["soluong"] = asoluong;
                            r["dongia"] = adongia;
                            r["mien"] = amien;
                            r["thucthu"] = athucthu;
                            r["madoituong"] = cbDoituong.SelectedValue.ToString();
                            r["doituong"] = cbDoituong.Text.Trim();
                            r["dichvu"] = arv["dichvu"].ToString();//gam 09/11/2011
                            if (tmn_Nhapkhoaphong.Checked)
                            {
                                try
                                {
                                    r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                                    r["tenkp"] = cbKhoa.Text.Trim();
                                }
                                catch
                                {
                                    r["makp"] = m_makp_khongkham;
                                }
                            }
                            else
                            {
                                try
                                {
                                    r["makp"] = cbotenpk.SelectedValue.ToString().Trim();
                                    r["tenkp"] = cbotenpk.Text.Trim();
                                }
                                catch
                                {
                                    r["makp"] = m_makp_khongkham;
                                }
                            }
                            try
                            {
                                r["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                            }
                            catch
                            {
                                r["mabs"] = "";
                            }
                            r["id_loai"] = arv["id_loai"].ToString();
                            r["tenbs"] = cbBacsi.Text.Trim();
                        }
                        else
                        {
                            DataRow r = m_dshoadon.Tables[0].NewRow();
                            r["id"] = 0;
                            r["chon"] = 1;
                            r["idcd"] = 0;
                            r["mavp"] = arv["id"].ToString();
                            r["ma"] = arv["ma"].ToString();
                            r["ten"] = arv["ten"].ToString();
                            r["ngaycd"] = txtNgaythu.Text.Substring(0, 10);
                            r["dvt"] = arv["dvt"].ToString();
                            r["soluong"] = asoluong;
                            r["dongia"] = adongia;
                            r["mien"] = amien;
                            r["thucthu"] = athucthu;
                            r["madoituong"] = cbDoituong.SelectedValue.ToString();
                            r["doituong"] = cbDoituong.Text.Trim();
                            r["dichvu"] = arv["dichvu"].ToString();//gam 09/11/2011
                            if (tmn_Nhapkhoaphong.Checked)
                            {
                                try
                                {
                                    r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                                    r["tenkp"] = cbKhoa.Text.Trim();
                                }
                                catch
                                {
                                    r["makp"] = m_makp_khongkham;
                                }
                            }
                            else
                            {
                                try
                                {
                                    r["makp"] = cbotenpk.SelectedValue.ToString().Trim();
                                    r["tenkp"] = cbotenpk.Text.Trim();
                                }
                                catch
                                {
                                    r["makp"] = m_makp_khongkham;
                                }
                            }
                            try
                            {
                                r["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                            }
                            catch
                            {
                                r["mabs"] = "";
                            }
                            r["id_loai"] = arv["id_loai"].ToString();
                            r["tenbs"] = cbBacsi.Text.Trim();
                            m_dshoadon.Tables[0].Rows.Add(r);
                        }
                    }
                }
                if (athucthu > 0 && iMien_Chenhlech_Tyle > 0 && sMien_Chenhlech_Cholam.ToUpper() == txtNoilamviec.Text.ToUpper())
                {
                    f_Tinhtien_Mien_Chenhlech(decimal.Parse(m_id_gia));
                }
                m_id_gia = "";
                f_Tinhtien();
            }
            catch
            {
            }
        }
        private decimal upd_chenhlech(bool chenhlech, int i_mavp, decimal d_soluong,decimal d_mien)
        {
            DataRow r_chenhlech = m_v.getrowbyid(m_dsgiavp.Tables[0], "id=" + i_mavp);
            string gia="";
            decimal athucthu = 0;
            if (r_chenhlech != null)
            {
                gia = m_v.field_gia(cbDoituong.SelectedValue.ToString());
                decimal d_dongia = decimal.Parse(r_chenhlech["" + gia + ""].ToString()) - decimal.Parse(r_chenhlech["gia_bh"].ToString());
                if (chenhlech && d_dongia != 0)
                {
                    DataRow r = m_dshoadon.Tables[0].NewRow();
                    r["id"] = 0;
                    r["chon"] = 1;
                    r["idcd"] = 0;
                    r["mavp"] = r_chenhlech["id"].ToString();
                    r["ma"] = r_chenhlech["ma"].ToString();
                    r["ten"] = r_chenhlech["ten"].ToString() + " - " + m_v.sChenhlech;
                    r["ngaycd"] = txtNgaythu.Text.Substring(0, 10);
                    r["dvt"] = r_chenhlech["dvt"].ToString();
                    r["soluong"] = d_soluong;
                    r["dongia"] = decimal.Parse(d_dongia.ToString().Trim('-'));
                    r["mien"] = 0;
                    athucthu = d_soluong * decimal.Parse(d_dongia.ToString().Trim('-'));
                    r["thucthu"] = athucthu;
                    r["madoituong"] = cbDoituong.SelectedValue.ToString();
                    r["doituong"] = cbDoituong.Text.Trim();
                    if (tmn_Nhapkhoaphong.Checked)
                    {
                        try
                        {
                            r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                            r["tenkp"] = cbKhoa.Text.Trim();
                        }
                        catch
                        {
                            r["makp"] = m_makp_khongkham;
                        }
                    }
                    else
                    {
                        try
                        {
                            r["makp"] = cbotenpk.SelectedValue.ToString().Trim();
                            r["tenkp"] = cbotenpk.Text.Trim();
                        }
                        catch
                        {
                            r["makp"] = m_makp_khongkham;
                        }
                    }


                    try
                    {
                        r["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                    }
                    catch
                    {
                        r["mabs"] = "";
                    }
                    r["id_loai"] = r_chenhlech["id_loai"].ToString();
                    r["tenbs"] = cbBacsi.Text.Trim();
                    m_dshoadon.Tables[0].Rows.Add(r);
                }
                else
                {
                    gia = m_v.field_gia(cbDoituong.SelectedValue.ToString());
                    d_dongia = decimal.Parse(r_chenhlech["" + gia + ""].ToString());
                    DataRow r = m_dshoadon.Tables[0].NewRow();
                    r["id"] = 0;
                    r["chon"] = 1;
                    r["idcd"] = 0;
                    r["mavp"] = r_chenhlech["id"].ToString();
                    r["ma"] = r_chenhlech["ma"].ToString();
                    r["ten"] = r_chenhlech["ten"].ToString();
                    r["ngaycd"] = txtNgaythu.Text.Substring(0, 10);
                    r["dvt"] = r_chenhlech["dvt"].ToString();
                    r["soluong"] = d_soluong;
                    r["dongia"] = d_dongia;
                    r["mien"] = d_mien;
                    athucthu = d_soluong * d_dongia - d_mien;
                    r["thucthu"] = athucthu;
                    r["madoituong"] = cbDoituong.SelectedValue.ToString();
                    r["doituong"] = cbDoituong.Text.Trim();
                    if (tmn_Nhapkhoaphong.Checked)
                    {
                        try
                        {
                            r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                            r["tenkp"] = cbKhoa.Text.Trim();
                        }
                        catch
                        {
                            r["makp"] = m_makp_khongkham;
                        }
                    }
                    else
                    {
                        try
                        {
                            r["makp"] = cbotenpk.SelectedValue.ToString().Trim();
                            r["tenkp"] = cbotenpk.Text.Trim();
                        }
                        catch
                        {
                            r["makp"] = m_makp_khongkham;
                        }
                    }
                    try
                    {
                        r["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                    }
                    catch
                    {
                        r["mabs"] = "";
                    }
                    r["id_loai"] = r_chenhlech["id_loai"].ToString();
                    r["tenbs"] = cbBacsi.Text.Trim();
                    m_dshoadon.Tables[0].Rows.Add(r);
                }
            }
            return athucthu;
        }
        private void f_Rem()
        {
            try
            {
                try
                {
                    if (decimal.Parse(m_dshoadon.Tables[0].Rows[dgHoadon.CurrentCell.RowIndex]["mien"].ToString()) == decimal.Parse(toolStrip_Mien.Text))
                    {
                        toolStrip_Mien.Text = "0";
                    }
                }
                catch
                { 

                }
                DataRowView drv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                s_mavp_huy += drv["mavp"].ToString() + ",";   
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
                        asoluong = 1;
                    }
                }
                catch
                {
                    asoluong = 1;
                }
                try
                {
                    amien = decimal.Parse(txtMien.Text.Trim().Replace(",", "")) * asoluong;
                    if (amien < 0 || amien>adongia * asoluong)
                    {
                        amien = 0;
                    }
                }
                catch
                {
                    amien = 0;
                }
                athucthu = asoluong * adongia - amien;
                txtDongia.Text = adongia.ToString("###,###,##0.##").Trim();
                txtSoluong.Text = asoluong.ToString("###,###,##0.##").Trim();
                txtMien.Text = amien.ToString("###,###,##0.##").Trim();
                txtThucthu.Text = athucthu.ToString("###,###,##0.##").Trim();
            }
            catch
            {
            }
        }
        private void f_Tinhtien_1()
        {
            try
            {
                decimal adongia = 0, asoluong = 0, amien = 0,abhyt=0, athucthu = 0, atongcong = 0, atongmien = 0, atongthu = 0, amientong = 0, atongbhyt = 0;             
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
                        if (asoluong < 0)
                        {
                            asoluong = 1;
                        }
                    }
                    catch
                    {
                        asoluong = 1;
                    }
                    try
                    {
                        if (tmn_khuyenmai.Checked)
                        {
                            amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));
                        }
                        if( m_v.sys_cokhuyenmai_tt)
                        {
                            amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));
                        }
                        else 
                        {
                            if (r["madoituong"].ToString() == "1")
                                abhyt = adongia * asoluong * f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                            else
                            {
                                amien = adongia * asoluong * f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                                if (v_nhapmienchitiet && amien == 0)
                                {
                                    amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));
                                }
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
                    athucthu = asoluong * adongia - amien - abhyt;
                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["mien"] = amien + abhyt;
                    r["thanhtien"] = asoluong*adongia;
                    r["thucthu"] = athucthu;
                    atongcong += (asoluong * adongia);
                    atongmien += amien;
                    atongbhyt += abhyt;
                }//ket thuc foreach

                #region Mien giam chi tiet
                if (v_Giamchitiet)
                {
                    DataSet ads_giam = new DataSet();
                    decimal aLoai_giam = 0, aTongtiengiam = 0;
                    ads_giam = m_v.get_data("select * from medibv.v_tylegiamll a,medibv.v_tylegiamct b where a.id=b.id and to_char(ngayvao,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and mabn='" + txtMabn.Text.Trim() + txtMabn1.Text.Trim() + "'");
                    if (ads_giam.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r_ct in ads_giam.Tables[0].Rows)
                        {                           
                            foreach (DataRow r_hd in m_dshoadon.Tables[0].Select("id_loai=" + r_ct["id_loaivp"].ToString() + ""))
                            {
                                aLoai_giam += (decimal.Parse(r_hd["soluong"].ToString()) * decimal.Parse(r_hd["dongia"].ToString()));
                            }
                            aTongtiengiam += aLoai_giam * decimal.Parse(r_ct["tyle"].ToString())/100;
                            aLoai_giam = 0;
                        }
                    }
                    toolStrip_Mien.Text = aTongtiengiam.ToString("###,###,##0.##");
                }
                #endregion
                //#region Mien Giam Theo Dot Khuyen mai
                //if (chkKhuyenMai.Checked)
                //{
                //    DataSet ads_km = new DataSet();
                //    decimal tyle = 0,sotienkm = 0,tongtienkhuyenmai = 0;
                //    ads_km = m_v.get_data("select a.idvp,a.tylekhuyenmai,a.sotienkhuyenmai,b.tugio,b.dengio,b.theogio from medibv.v_giavp_khuyenmai a inner join medibv.v_dot_khuyenmai b on a.iddot=b.id where b.hide=0 and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') >= b.tungay and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')<= b.denngay");
                //    if (ads_km.Tables[0].Rows.Count > 0)
                //    {
                //        foreach (DataRow r_ct in ads_km.Tables[0].Rows)
                //        {
                //            if (f_kiemTraGio(r_ct["tugio"].ToString(), r_ct["dengio"].ToString()) || r_ct["theogio"].ToString() == "0" )
                //            {
                //                foreach (DataRow r_hd in m_dshoadon.Tables[0].Select("mavp=" + r_ct["idvp"].ToString()))
                //                {
                //                    sotienkm += (decimal.Parse(r_hd["soluong"].ToString()) * decimal.Parse(r_ct["sotienkhuyenmai"].ToString()));
                //                }
                //                tongtienkhuyenmai += sotienkm;
                //                sotienkm = 0;
                //            }
                //        }
                //    }
                //    toolStrip_Mien.Text = tongtienkhuyenmai.ToString("###,###,##0.##");
                //}
                //#endregion

                    #region Mien doi tuong theo loai vp
                    if (v_miendt_loai)
                {
                    if (s_loaibn_mien != "")
                    {
                        string[] s_loaibnmien = s_loaibn_mien.Split(',');
                        for (int i = 0; i < s_loaibnmien.Length; i++)
                        {
                            if (s_loaibnmien[i] == "0" && cbLoaibn.SelectedValue.ToString() == "0")
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
                                toolStrip_Mien.Text = aTongtiengiam.ToString("###,###,##0.##");
                            }
                            else if (s_loaibnmien[i] == "3" && cbLoaibn.SelectedValue.ToString() == "3")
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
                                toolStrip_Mien.Text = aTongtiengiam.ToString("###,###,##0.##");
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
                        toolStrip_Mien.Text = aTongtiengiam.ToString("###,###,##0.##");
                    }
                }
                #endregion

                try
                {                  
                    amientong = decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", ""));
                }
                catch
                {
                    amientong = 0;
                }
                toolStrip_Mien.ReadOnly = (!butLuu.Enabled && atongmien > 0);
                if (atongmien <= 0 && amientong > 0)
                {
                    toolStrip_Mien.ReadOnly = !butLuu.Enabled;
                    atongmien = amientong;
                }
                if (atongmien > atongcong)
                {
                    toolStrip_Mien.ReadOnly = !butLuu.Enabled;
                    atongmien = 0;
                    foreach (DataRow r1 in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            adongia = decimal.Parse(r1["dongia"].ToString().Trim().Replace(",", ""));
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
                            asoluong = decimal.Parse(r1["soluong"].ToString().Trim().Replace(",", ""));
                            if (asoluong < 0)
                            {
                                asoluong = 1;
                            }
                        }
                        catch
                        {
                            asoluong = 1;
                        }
                        amien = 0;
                        athucthu = asoluong * adongia - amien - abhyt;
                        r1["soluong"] = asoluong;
                        r1["dongia"] = adongia;
                        r1["mien"] = amien+abhyt;
                        r1["thanhtien"] = asoluong * adongia;
                        r1["thucthu"] = athucthu;
                    }
                }
                m_dshoadon.AcceptChanges();
                atongthu = atongcong - atongmien - atongbhyt;
                toolStrip_Tongcong.Text = atongcong.ToString("###,###,##0.##").Trim();
                toolStrip_Tongcong.ToolTipText = m_v.Doiso_Unicode(atongcong.ToString("##########")).Replace("  "," ");
                toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##").Trim();
                toolStrip_Mien.ToolTipText = m_v.Doiso_Unicode(atongmien.ToString("##########")).Replace("  ", " "); 
                toolStrip_Thucthu.Text = atongthu.ToString("###,###,##0.##").Trim();
                toolStrip_Thucthu.ToolTipText = m_v.Doiso_Unicode(atongthu.ToString("##########")).Replace("  ", " ");
                toolStrip_Somuc.Text = m_dshoadon.Tables[0].Rows.Count.ToString() + " " +"mục";

                toolStrip_BHYT.Text = atongbhyt.ToString("###,###,##0.##").Trim();
                toolStrip_BHYT.ToolTipText = m_v.Doiso_Unicode(atongbhyt.ToString("##########")).Replace("  ", " "); 
            }
            catch
            {
                toolStrip_Tongcong.Text = "0";
                toolStrip_Tongcong.ToolTipText = "Không đồng";
                toolStrip_Mien.Text = "0";
                toolStrip_Mien.ToolTipText = "Không đồng";
                toolStrip_Thucthu.Text = "0";
                toolStrip_Thucthu.ToolTipText = "Không đồng";
                toolStrip_Somuc.Text = "0 " + "mục";

                toolStrip_BHYT.Text = "0";
                toolStrip_BHYT.ToolTipText = "Không đồng";
            }
        }
        private void f_Load_Tamung(string v_tn, string v_mavaovien)
        {
            try
            {
                string asql = "";
                decimal tamung=0,tu=0;
                asql = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
                asql += "b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id,";
                asql += "a.quyenso, a.makp from medibvmmyy.v_tamung a left join medibv.v_quyenso b on ";
                asql += "a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id where a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";
                if (s_madoituongthu != "")
                    asql += " and '0' || a.madoituong in ('" + s_madoituongthu.Replace(",", "','") + "')";
                if ( v_mavaovien != "")
                    asql += " and a.mavaovien=" + v_mavaovien;
                m_dstamung = m_v.get_data_mmyy(asql, v_tn, txtNgaythu.Text.Substring(0, 10), true);
                //if (!bKhongthu_tutruc_phongluu)
                //{
                //    //v_maql_phongluu = m_v.get_maql_phongluu(v_tn, decimal.Parse(m_mavaovien==""?"0":m_mavaovien));
                //    v_maql_phongluu = m_v.get_maql_benhancc(m_mavaovien, txtMabn.Text + txtMabn1.Text, v_tn);
                //    if (v_maql_phongluu > 0)
                //    {
                //        asql_luu = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
                //        asql_luu += "b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id,";
                //        asql_luu += "a.quyenso, a.makp from medibvmmyy.v_tamung a left join medibv.v_quyenso b on ";
                //        asql_luu += "a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id where a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";
                //        if (s_madoituongthu != "")
                //            asql_luu += " and '0' || a.madoituong in ('" + s_madoituongthu.Replace(",", "','") + "')";
                //        asql_luu += " and a.maql=" + v_maql_phongluu;
                //        m_dstamung.Merge(m_v.get_data_mmyy(asql_luu, v_tn, txtNgaythu.Text.Substring(0, 10), true));
                //    }
                //}
                foreach (DataRow r in m_dstamung.Tables[0].Select("chon=1"))
                {
                    try
                    {
                        tu = decimal.Parse(r["sotien"].ToString() == "" ? "0" : r["sotien"].ToString());
                    }
                    catch
                    {
                        tu = 0;
                    }
                    tamung += tu;
                }
                toolStrip_Tamung.Text = tamung.ToString("###,###,##0.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void f_Tinhtien()
        {
            try
            {
                decimal adongia = 0,atamung=0, asoluong = 0, amien = 0, abhyt = 0, athucthu = 0, atongcong = 0, atongmien = 0, atongthu = 0, amientong = 0, atongbhyt = 0;
                s_makp_thu = "";
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    try
                    {
                        adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
                        if (adongia < 0)
                        {
                            adongia = 0;
                        }
                        if (s_makp_thu.IndexOf(r["makp"].ToString() + ",") < 0)//gam 27/10/2011
                            s_makp_thu += r["makp"].ToString() + ",";
                    }
                    catch
                    {
                        adongia = 0;
                    }
                    try
                    {
                        asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
                        if (asoluong < 0)
                        {
                            asoluong = 1;
                        }
                    }
                    catch
                    {
                        asoluong = 1;
                    }
                    try
                    {
                        if (tmn_khuyenmai.Checked)
                        {
                            amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));
                        }
                        if (chkKhuyenMai.Checked)
                        {
                            amien = decimal.Parse(r["mien"].ToString());
                        }
                        else
                        {
                            if (r["madoituong"].ToString() == "1")
                                abhyt = adongia * asoluong * f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                            else
                            {
                                //amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));//binh 160611 ????
                                //binh comment 160611 --> vi ben v_chidinh duoc mien qua ben vp khong lay duoc tien mien
                                amien = adongia * asoluong * f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                                if (v_nhapmienchitiet && amien == 0)
                                {
                                    amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));
                                }
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
                    athucthu = asoluong * adongia - amien - abhyt;
                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["mien"] = amien + abhyt;
                    r["thanhtien"] = asoluong * adongia;
                    r["thucthu"] = athucthu;
                    //binh 120611: stt, idphongcls
                    //m_v.f_get_phongcls_stt(txtNgaythu.Text.Substring(0, 10), r["mavp"].ToString(), "", ref v_idphongcls, ref i_stt_cls);
                    //r["idphongcls"] = v_idphongcls;
                    //r["sttcls"] = i_stt_cls;
                    //
                    atongcong += (asoluong * adongia);
                    atongmien += amien;
                    atongbhyt += abhyt;
                }//ket thuc foreach

                #region Mien giam chi tiet
                if (v_Giamchitiet)
                {
                    DataSet ads_giam = new DataSet();
                    decimal aLoai_giam = 0, aTongtiengiam = 0;
                    ads_giam = m_v.get_data("select * from medibv.v_tylegiamll a,medibv.v_tylegiamct b where a.id=b.id and to_char(ngayvao,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and mabn='" + txtMabn.Text.Trim() + txtMabn1.Text.Trim() + "'");
                    if (ads_giam.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r_ct in ads_giam.Tables[0].Rows)
                        {
                            foreach (DataRow r_hd in m_dshoadon.Tables[0].Select("id_loai=" + r_ct["id_loaivp"].ToString() + ""))
                            {
                                aLoai_giam += (decimal.Parse(r_hd["soluong"].ToString()) * decimal.Parse(r_hd["dongia"].ToString()));
                            }
                            aTongtiengiam += aLoai_giam * decimal.Parse(r_ct["tyle"].ToString()) / 100;
                            aLoai_giam = 0;
                        }
                    }
                    toolStrip_Mien.Text = aTongtiengiam.ToString("###,###,##0.##");
                }
                #endregion
                #region Mien Giam Theo Dot Khuyen mai
                if (chkKhuyenMai.Checked)
                {
                    DataSet ads_km = new DataSet();
                    decimal sotienkm = 0, tongtienkhuyenmai = 0;
                    ads_km = m_v.get_data("select a.idvp,a.tylekhuyenmai,a.sotienkhuyenmai,b.tugio,b.dengio,b.theogio from medibv.v_giavp_khuyenmai a inner join medibv.v_dot_khuyenmai b on a.iddot=b.id where b.hide=0 and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') >= b.tungay and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')<= b.denngay");
                    if (ads_km.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r_ct in ads_km.Tables[0].Rows)
                        {
                            if (f_kiemTraGio(r_ct["tugio"].ToString(), r_ct["dengio"].ToString()) || r_ct["theogio"].ToString() == "0")
                            {
                                foreach (DataRow r_hd in m_dshoadon.Tables[0].Select("mavp=" + r_ct["idvp"].ToString()))
                                {
                                    sotienkm += (decimal.Parse(r_hd["soluong"].ToString()) * decimal.Parse(r_ct["sotienkhuyenmai"].ToString()));
                                }
                                tongtienkhuyenmai += sotienkm;
                                sotienkm = 0;
                            }
                        }
                    }
                    toolStrip_Mien.Text = tongtienkhuyenmai.ToString("###,###,##0.##");
                }
                #endregion

                #region Mien doi tuong theo loai vp
                if (v_miendt_loai)
                {
                    if (s_loaibn_mien != "")
                    {
                        string[] s_loaibnmien = s_loaibn_mien.Split(',');
                        for (int i = 0; i < s_loaibnmien.Length; i++)
                        {
                            if (s_loaibnmien[i] == "0" && cbLoaibn.SelectedValue.ToString() == "0")
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
                                toolStrip_Mien.Text = aTongtiengiam.ToString("###,###,##0.##");
                            }
                            else if (s_loaibnmien[i] == "3" && cbLoaibn.SelectedValue.ToString() == "3")
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
                                toolStrip_Mien.Text = aTongtiengiam.ToString("###,###,##0.##");
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
                        toolStrip_Mien.Text = aTongtiengiam.ToString("###,###,##0.##");
                    }
                }
                #endregion

                try
                {
                    amientong = decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", ""));
                }
                catch
                {
                    amientong = 0;
                }
                toolStrip_Mien.ReadOnly = (!butLuu.Enabled && atongmien > 0);
                if (atongmien <= 0 && amientong > 0)
                {
                    toolStrip_Mien.ReadOnly = !butLuu.Enabled;
                    atongmien = amientong;
                }
                if (atongmien > atongcong)
                {
                    toolStrip_Mien.ReadOnly = !butLuu.Enabled;
                    atongmien = 0;
                    foreach (DataRow r1 in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            adongia = decimal.Parse(r1["dongia"].ToString().Trim().Replace(",", ""));
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
                            asoluong = decimal.Parse(r1["soluong"].ToString().Trim().Replace(",", ""));
                            if (asoluong < 0)
                            {
                                asoluong = 1;
                            }
                        }
                        catch
                        {
                            asoluong = 1;
                        }
                        amien = 0;
                        athucthu = asoluong * adongia - amien - abhyt;
                        r1["soluong"] = asoluong;
                        r1["dongia"] = adongia;
                        r1["mien"] = amien + abhyt;
                        r1["thanhtien"] = asoluong * adongia;
                        r1["thucthu"] = athucthu;
                       
                    }
                }
                m_dshoadon.AcceptChanges();
                try
                {
                    atamung = decimal.Parse(toolStrip_Tamung.Text);
                }
                catch
                {
                    atamung = 0;
                }
                atongthu = atongcong - atongmien - atongbhyt - atamung;
                if (atongthu < 0)
                {
                    toolStripLabel4.Text = "Hoàn:";
                    toolStripLabel4.ForeColor = Color.Red;
                    atongthu = atongthu * -1;
                }
                else
                {
                    toolStripLabel4.Text = "BN Trả:";
                    toolStripLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
                }
                if (blamtron)
                {
                    atongthu = (atongthu % 100) > 0 ? ((atongthu - (atongthu % 100)) + 100 ): atongthu;

                }
                toolStrip_Tongcong.Text = atongcong.ToString("###,###,##0.##").Trim();
                toolStrip_Tongcong.ToolTipText = m_v.Doiso_Unicode(atongcong.ToString("##########")).Replace("  ", " ");
                toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##").Trim();
                toolStrip_Mien.ToolTipText = m_v.Doiso_Unicode(atongmien.ToString("##########")).Replace("  ", " ");
                toolStrip_Thucthu.Text = atongthu.ToString("###,###,##0.##").Trim();
                //Thuy 05.13.2013
                if (decimal.Parse(toolStrip_Thucthu.Text) <= 0 && bbhyt_100_theodoibienlai==false)
                {
                    txtSobienlai.Text = "-1" + txtSobienlai.Text;
                }
                //end
                toolStrip_Thucthu.ToolTipText = m_v.Doiso_Unicode(atongthu.ToString("##########")).Replace("  ", " ");
                toolStrip_Somuc.Text = m_dshoadon.Tables[0].Rows.Count.ToString() + " " + "mục";
                toolStrip_Tamung.Text = atamung.ToString("###,###,##0.##");
                toolStrip_BHYT.Text = atongbhyt.ToString("###,###,##0.##").Trim();
                toolStrip_BHYT.ToolTipText = m_v.Doiso_Unicode(atongbhyt.ToString("##########")).Replace("  ", " ");
            }
            catch
            {
                toolStrip_Tongcong.Text = "0";
                toolStrip_Tongcong.ToolTipText = "Không đồng";
                toolStrip_Mien.Text = "0";
                toolStrip_Mien.ToolTipText = "Không đồng";
                toolStrip_Thucthu.Text = "0";
                toolStrip_Thucthu.ToolTipText = "Không đồng";
                toolStrip_Somuc.Text = "0 " + "mục";
                toolStrip_Tamung.Text = "0";
                toolStrip_BHYT.Text = "0";
                toolStrip_BHYT.ToolTipText = "Không đồng";
            }
        }
        private bool f_kiemTraGio( string tugio,string dengio)
        {
            int gio1 = 0, gio2 = 0, phut1 = 0, phut2 = 0,gio =0,phut = 0;

            try
            {
                gio = int.Parse(txtNgaythu.Text.Substring(11, 2)) == 0 ? 24 : int.Parse(txtNgaythu.Text.Substring(11, 2));
                gio1 = int.Parse(tugio.Substring(0, 2))== 0 ? 24 :int.Parse(tugio.Substring(0, 2));
                gio2 = int.Parse(dengio.Substring(0, 2)) == 0 ? 24 : int.Parse(dengio.Substring(0, 2));
                phut = int.Parse(txtNgaythu.Text.Substring(14,2));
                phut1 = int.Parse(tugio.Substring(3,2));
                phut2 = int.Parse(dengio.Substring(3, 2));
                if (gio1 == gio2 && gio1 == 24)
                {
                    return true;
                }
                else if (gio < gio1 || gio > gio2)
                {
                    return false;
                }
                else if (gio1 == gio2 && gio >= gio1 && gio <= gio2)
                {
                    if (phut < phut1 || phut > phut2)
                    {
                        return false;
                    }
                }

            }
            catch { }
            return true;
        }
        private void f_Tinhtien_Mien_Chenhlech(decimal id_gia)
        {
            DataRow r1 = m_v.getrowbyid(m_dshoadon.Tables[0]," mavp=" + id_gia + " and thucthu > 0");
            DataRow r2 = m_v.getrowbyid(m_dshoadon.Tables[0], "mavp=" + id_gia + " and thucthu > 0");
            if (r1 != null && r2 != null)
            {
                int _tyle = 100 - iMien_Chenhlech_Tyle;
                decimal d_gia = decimal.Parse(r1["dongia"].ToString());
                r1["dongia"] = d_gia * _tyle / 100;
                m_dshoadon.Tables[0].Rows.Add(r2.ItemArray);
                r2["chon"] = 0;
                r2["madoituong"] = iMien_Chenhlech_Doituong.ToString();
                r2["doituong"] = m_dsdoituong.Tables[0].Select("madoituong=" + iMien_Chenhlech_Doituong)[0]["doituong"].ToString();
                r2["dongia"] = d_gia * iMien_Chenhlech_Tyle / 100;
                r2["thucthu"] = 0;
                r2["mien"] = d_gia * iMien_Chenhlech_Tyle / 100;
                m_dshoadon.AcceptChanges();
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

        private void f_Load_Thutrongngay()
        {
            try
            {
                string sql = "", ammyy = "";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                decimal asotien = 0, amien = 0, ahoan=0, asohd=0;
                sql = "select sum(b.soluong*b.dongia-b.thieu) as sotien from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id where  b1.id is null and a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' ";
                try
                {
                    asotien = decimal.Parse(m_v.get_data_mmyy(ammyy,sql).Tables[0].Rows[0][0].ToString());
                    
                }
                catch
                {
                    asotien = 0;
                }

                sql = "select sum(b.sotien) as sotien from medibvmmyy.v_vienphill a left join medibvmmyy.v_mienngtru b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id where b1.id is null and a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                try
                {
                    amien = decimal.Parse(m_v.get_data_mmyy(ammyy,sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    amien = 0;
                }

                sql = "select count(distinct a.id) as sohd from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id where b1.id is null and a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                try
                {
                    asohd = decimal.Parse(m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    asohd = 0;
                }

                asotien = asotien - amien - ahoan;

                tmn_Tongthu.Text = (bKhongchoxem_tongthu) ? "" : asohd.ToString() + "=" + asotien.ToString("###,###,##0.##") + "đ";
                tmn_Tongthu.ToolTipText = (bKhongchoxem_tongthu) ? "" : m_v.Doiso_Unicode(asotien.ToString("#########")).Replace("  ", " ");
            }
            catch
            {
                tmn_Tongthu.Text = "=0đ";
                tmn_Tongthu.ToolTipText ="Không đồng";
            }
        }
        private void f_Load_Hoadon(string v_id, string v_mmyy)
        {
            edit = true;//Thuy 26.12.2011
            try
            {
                try
                {
                    v_id = decimal.Parse(v_id).ToString();
                }
                catch
                {
                    v_id = "";
                }
                if (v_id == "")
                {
                    return;
                }
                string sql = "", ammyy = "";
                ammyy = v_mmyy;
                if(ammyy=="")
                {
                    ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                }
                sql = "select a.mabn,a.mavaovien,a.maql,b2.sotien as tongmien,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.quyenso,a.sobienlai,a.loai,a.loaibn,a.id, case when b.lanin <> 0 then 1 else 0 end as chon, b.mavp, c.ma,c.ten,c.dvt,b.soluong,b.dongia,b.soluong*b.dongia as thanhtien, b.mien,b.soluong*b.dongia-b.mien as thucthu,b.madoituong,d.doituong,b.makp, e.tenkp, b.mabs,f.hoten as tenbs, 0 as idcd,a.ghichu,bacsi,c.id_loai,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,c.id_loai,0 as id_nhom,a.done,idchidinh,c.dichvu,a.thanhtoan,b.idphongcls as maphongcls,b.sttcho ";//Thuy 15.12.2011
                sql += ",a.dain, b.vat ";//Thuy 26.12.2011
                sql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru b2 on a.id=b2.id left join (select id,ma,ten,dvt,id_loai,dichvu from medibv.v_giavp union select d0.id,d0.ma,d0.ten, d0.dang  as dvt,to_number('0') as id_loai,to_number('0')as dichvu from medibv.d_dmbd d0 inner join medibv.d_dmnhom d1 on d0.manhom=d1.id ) c on b.mavp=c.id left join medibv.doituong d on b.madoituong=d.madoituong left join medibv.btdkp_bv e on b.makp=e.makp left join medibv.dmbs f on b.mabs=f.ma ";
                sql += " where b1.id is null and a.id = " + v_id;//where d1.nhom=1
               
                DataSet ads = m_v.get_data_mmyy(ammyy, sql);
                m_mavaovien = "";
                m_maql = "";
                if (ads.Tables[0].Rows.Count>0)
                {
                    m_mavaovien = ads.Tables[0].Rows[0]["mavaovien"].ToString();
                    m_maql = ads.Tables[0].Rows[0]["maql"].ToString();

                    txtMabn.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(0, 2);
                    txtMabn1.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(2);
                    txtMabn1_Validated(null, null);
                    // gam hepa
                    rdTienmat.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "0";
                    rdTrasau.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "1";
                    rdThe.Checked = ads.Tables[0].Rows[0]["thanhtoan"].ToString() == "2";

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
                    txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    txtNgaythu.Value = m_v.f_parse_date(ads.Tables[0].Rows[0]["ngay"].ToString());

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
                        toolStrip_Tamung.Text = decimal.Parse(ads.Tables[0].Rows[0]["tamung"].ToString()).ToString("###,###,##0.##");
                    }
                    catch { toolStrip_Tamung.Text = "0"; }
                    try
                    {
                        if (ads.Tables[0].Rows[0]["done"].ToString() == "2")
                        {
                            chkTheKB.Checked = true;
                            chkTheKB.ForeColor = System.Drawing.Color.Red;
                            chkTheKB.Enabled = false;
                        }
                        else
                        {
                            chkTheKB.Checked = false;
                            chkTheKB.Enabled = false;
                        }
                    }
                    catch
                    { 
                    }
                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("mavaovien");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loai");
                    ads.Tables[0].Columns.Remove("loaibn");
                    ads.Tables[0].Columns.Remove("ngay");
                    ads.Tables[0].Columns.Remove("tongmien");                    
                    m_dshoadon = ads;
                    dgHoadon.DataSource = m_dshoadon.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien();
                    m_id = v_id;
                }
               
                
               
                f_Enable(m_id == "" || m_id == "0");
                butLuu_EnabledChanged(null, null);
                //Thuy 26.12.2011
                if (ads.Tables[0].Rows[0]["dain"].ToString() == "1" && !m_v.is_admin(m_userid.ToString()))
                {
                    butSua.Enabled = false;
                    edit = false;
                }//end Thuy
            }
            catch(Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_hoadon()");
                m_mavaovien = "";
                m_maql = "";
            }
        }
        private void f_Load_Hoadon_NextPre(int v_pre)
        {
            try
            {
                string sql = "", ammyy = "", asobienlai="",exp="",aid="";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                exp = " a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                if (m_id != "" && m_id != "0")
                {
                    try
                    {
                        asobienlai = decimal.Parse(m_v.get_data_mmyy(ammyy,"select a.sobienlai from medibvmmyy.v_vienphill a left join medibvmmyy.v_trongoi b on a.id=b.id where b.id is null and a.id = " + m_id).Tables[0].Rows[0][0].ToString()).ToString();
                    }
                    catch
                    {
                        asobienlai = "";
                    }
                    if (asobienlai != "")
                    {
                        if (v_pre < 0)
                        {
                            exp += " and a.sobienlai < " + asobienlai + " order by a.sobienlai desc limit 1";
                        }
                        else
                        {
                            exp += " and a.sobienlai > " + asobienlai + " order by a.sobienlai asc limit 1";
                        }
                    }
                    else
                    {
                        if (v_pre < 0)
                        {
                            exp += " order by a.sobienlai asc limit 1";
                        }
                        else
                        {
                            exp += " order by a.sobienlai desc limit 1";
                        }
                    }
                }
                sql = "select a.id from medibvmmyy.v_vienphill a left join medibvmmyy.v_trongoi b on a.id=b.id where b.id is null and " + exp;
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
                    MessageBox.Show(this,"Không tìm thấy hoá đơn" + (v_pre < 0 ?"trước+" :"sau") + "!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtSothe.Text = "";
                txtTN.Text = "";
                txtDN.Text = "";
                txtNDK_Ma.Text = "";
                txtNDK_Ten.Text = "";
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
                if (atn.Length >= 10)
                {
                    atn = atn.Substring(0, 10);
                }
                else
                {
                    atn = txtNgaythu.Text.Substring(0, 10);
                }
                string sql = "";
                sql = "select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tn, to_char(a.denngay,'dd/mm/yyyy') as dn,a.mabv,b.tenbv,a.maphu from medibv.bhyt a left join medibv.dmnoicapbhyt b on a.mabv=b.mabv where a.maql = " + amaql;
                sql += " union all select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tn, to_char(a.denngay,'dd/mm/yyyy') as dn,a.mabv,b.tenbv,a.maphu from medibvmmyy.bhyt a left join medibv.dmnoicapbhyt b on a.mabv=b.mabv where a.maql = " + amaql;
                foreach (DataRow r in m_v.get_data_bc_1(atn, txtNgaythu.Text.Substring(0, 10), sql,1).Tables[0].Rows)
                {
                    txtSothe.Text = r["sothe"].ToString();
                    txtTN.Text = r["tn"].ToString();
                    txtDN.Text = r["dn"].ToString();
                    txtNDK_Ma.Text = r["mabv"].ToString();
                    txtNDK_Ten.Text = r["tenbv"].ToString();
                    break;
                }
            }
            catch
            {
            }
        }
        private void f_Load_Chidinh(string v_tn, string v_maql)
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
                v_tn = m_v.f_string_date(v_tn);
                if (v_tn.Length >= 10)
                {
                    v_tn = v_tn.Substring(0, 10);
                }
                else
                {
                    v_tn = txtNgaythu.Text.Substring(0, 10);
                }
                if (v_btrutamung)
                    f_Load_Tamung(v_tn, m_mavaovien);
                else
                    toolStrip_Tamung.Text = "0";
                string sql = "", exp = "", s_loaiba="0,5,";
                DataSet ads = null, ads1 = null;
                //Chi dinh
                if (tmn_Thuchidinh.Checked)
                {
                    if (tmn_Conhanbenh.Checked)
                    {
                        s_loaiba += " 1,";
                    }
                    if (tmn_Cophongluu.Checked)
                    {
                        s_loaiba += "4,";
                    }
                    if (tmn_Cokhambenh.Checked)
                    {
                        s_loaiba += " 3,";
                    }
                    if (tmn_congoaitru.Checked)
                    {
                        s_loaiba += " 2,";
                    }                    
                    exp = " where a.paid=0 and a.idttrv=0 ";
                    if (s_loaiba.Trim().Trim(',') != "") exp += " and a.loaiba in(" + s_loaiba.Trim().Trim(',') + ")";
                    if (tt_thuchidinh_ngay) exp += " and a.mabn='" + txtMabn.Text + txtMabn1.Text + "' and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+v_tn+"','dd/mm/yyyy') and to_date('"+txtNgaythu.Text.Substring(0,10)+"','dd/mm/yyyy')";                    
                    else exp += " and a.maql = " + v_maql;
                    //Khong cho thu doi tuong bhyt tren man hinh thu truc tiep
                    exp += " and a.madoituong<>1";
                    //
                    if (s_madoituongthu != "")
                    {
                        exp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and a.mavp not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    if (v_khongthuhoadonthuong)
                    {
                        exp += " and b.thuong =0 ";
                    }
                    if (v_chithuhoadonthuong)
                    {
                        exp += " and b.thuong = 1 ";
                    }
                    if (mavp_gioihan.Trim().Trim(',') != "")
                    {
                        exp += " and a.mavp in(" + mavp_gioihan.Trim().Trim(',') + ")";
                    }
                    if (mavp_gioihan_noitru.Trim().Trim(',') != "")
                    {
                        exp += " and ((a.mavp in(" + mavp_gioihan_noitru.Trim().Trim(',') + ") and a.loaiba in(1)) or loaiba not in(1) )";//binh 100611
                    }
                    if (chkKhuyenMai.Checked)// nếu load chỉ định theo đợt khuyến mãi
                    {
                        DataSet ads_km = new DataSet();
                        ads_km = m_v.get_data("select a.tugio,a.dengio from medibv.v_dot_khuyenmai a where a.hide=0 and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') >= a.tungay and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')<= a.denngay");
                        if (ads_km.Tables[0].Rows.Count > 0)
                        {
                            if (f_kiemTraGio(ads_km.Tables[0].Rows[0][0].ToString(), ads_km.Tables[0].Rows[0][1].ToString()))// kiem tra con trong khoang thoi gian khuyen mai
                            {
                                sql = "select a.id, a.chon,a.ngaycd, a.mavp, a.ma,a.ten,a.dvt,a.soluong,a.dongia,a.thanhtien,min(a.thucthu) as thucthu,a.madoituong,a.doituong,a.makp,a.tenkp, a.tenbs, a.idcd,a.id_loai, a.id_nhom ,sum(mien) as mien,a.dichvu, a.vat  from ( ";
                                sql += "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                                if (tmn_khuyenmai.Checked)
                                {
                                    sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                                }
                                else
                                {
                                    sql += " , a.stgiam as mien"; //sql += " ,to_number('0') as mien";
                                }
                                sql += " ,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho";
                                sql += ",a.mabs ";//gam 15/02/2012
                                sql += ",b.vat ";//binh  14082012
                                sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + exp;
                                sql += " union all ";
                                sql += " select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,((a.soluong*a.dongia)-(h.sotienkhuyenmai*a.soluong)) as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom ,b.dichvu,h.sotienkhuyenmai*a.soluong as mien ,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                                sql += ",a.mabs ";//gam 15/02/2012
                                sql += ",b.vat ";//binh  14082012
                                sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai inner join medibv.v_giavp_khuyenmai h on a.mavp=h.idvp inner join medibv.v_dot_khuyenmai i on h.iddot=i.id " + exp + " and i.hide=0 ";
                                sql += ") as a group by a.mavp, a.chon,a.ngaycd, a.id, a.ma,a.ten,a.dvt,a.soluong,a.dongia,a.thanhtien,a.madoituong,a.doituong,a.makp, a.tenkp, a.mabs,a.tenbs, a.idcd,a.id_loai, a.id_nhom,a.dichvu, a.vat ";

                            }
                            else
                            {
                                sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                                if (tmn_khuyenmai.Checked)
                                {
                                    sql += " ,a.dongia*tylekhuyenmai/100 as mien,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho";
                                }
                                else
                                {
                                    sql += " , a.stgiam as mien,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho"; //sql += " ,to_number('0') as mien,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho";
                                }
                                sql += ",a.mabs ";//gam 15/02/2012
                                sql += ",b.vat ";//binh  14082012
                                sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + exp;
                            }
                        }//end khuyen mai
                        else
                        {
                            sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                            if (tmn_khuyenmai.Checked)
                            {
                                sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                            }
                            else
                            {
                                sql += " ,a.stgiam as mien"; // sql += " ,to_number('0') as mien";
                            }
                            sql += ",b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                            sql += ",a.mabs ";//gam 15/02/2012
                            sql += ",b.vat ";//binh  14082012
                            sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + exp;
                        }
                        
                    }
                    else
                    {
                        sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                        if (tmn_khuyenmai.Checked)
                        {
                            sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                        }
                        else
                        {
                            sql += " ,a.stgiam as mien"; //sql += " ,to_number('0') as mien";
                        }
                        sql += ",b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                        sql += ",a.mabs ";//gam 15/02/2012
                        sql += ",b.vat ";//binh  14082012
                        sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + exp;
                    }
                    
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
                if (tmn_thuvienphikhoa.Checked)
                {
                    exp = " where done=0 and a.maql="+v_maql;
                    //Khong cho thu doi tuong bhyt tren man hinh thu truc tiep
                    exp += " and a.madoituong<>1";
                    //
                    if (s_madoituongthu != "")
                    {
                        exp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (v_khongthuhoadonthuong)
                    {
                        exp += " and b.thuong =0 ";
                    }
                    if (v_chithuhoadonthuong)
                    {
                        exp += " and b.thuong = 1 ";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and a.mavp not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,";
                    sql+="a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp,";
                    sql += "d.tenkp,'' as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                    if (tmn_khuyenmai.Checked)
                    {
                        sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                    }
                    else
                    {
                        sql += " ,to_number('0') as mien";
                    }
                    sql += ",b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                    sql += ",'' as mabs ";//gam 15/02/2012
                    sql += ", b.vat ";//binh  14082012
                    sql += " from medibvmmyy.v_vpkhoa a inner join medibv.v_giavp b on a.mavp=b.id ";
                    sql+=" left join medibv.doituong c on a.madoituong=c.madoituong ";
                    sql+=" left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id ";
                    sql+=" left join medibv.v_loaivp g on g.id=b.id_loai" + exp;

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
                //Toa thuoc thu truc
                if (tmn_Toathuoctutruc.Checked && !v_chithuhoadonthuong )
                {
                    exp = " where done=0 and a.maql = " + v_maql;
                    //Khong cho thu doi tuong bhyt tren man hinh thu truc tiep
                    exp += " and a.madoituong<>1";
                    //
                    if (s_madoituongthu != "")
                    {
                        exp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and a.mabd not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    if (s_tutructhutheokhoa.Trim(',') != "")
                    {
                        exp += " and d.makp in(" + s_tutructhutheokhoa.Trim(',') + ")";
                    }
                    if (bKhongthu_tutruc_noitru)
                    {
                        exp += " and (d.loai is null or d.loai<>0)";
                    }
                    if (bKhongthu_tutruc_phongluu)
                    {
                        exp += " and (d.loai is null or d.loai<>4)";
                    }
                    exp += " and a.soluong<>0 ";
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,a.mabd as mavp, b.ma,b.ten,b.dang as dvt,a.soluong,";
                    sql += " case when c.loai=1 then a.giaban else a.giamua end as dongia,";
                    sql += "(case when c.loai=1 then a.giaban else a.giamua end) * a.soluong as thanhtien,a.soluong*a.giaban as thucthu, ";
                    sql += "a.madoituong, c.doituong, d.makp, d.tenkp, '' as tenbs, a.id as idcd,to_number('0') as id_loai,to_number('0') as id_nhom,to_number('0') as dichvu,to_number('0') as mien ,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                    sql += ", a.mabs ";
                    sql += ", b.vat ";//binh  14082012
                    sql += " from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id left join medibv.d_doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + exp;
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
                if (tmn_Toathuocmuangoai.Checked && !v_chithuhoadonthuong)
                {
                    exp = " where aa.idttrv=0 and a.maql = " + v_maql;
                    if (s_madoituongthu != "")
                    {
                        exp += " and aa.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and aa.mabd not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,aa.mabd as mavp, b.ma,b.ten,b.dang as dvt,aa.soluong,";
                    if (blamtron) sql += "(case when aa.madoituong=1 then aa.giaban else (case when round(aa.giaban,-2) < aa.giaban then round(aa.giaban,-2)+100 else round(aa.giaban,-2) end)end) as dongia,(case when aa.madoituong=1 then aa.giaban else (case when round(aa.giaban,-2) < aa.giaban then round(aa.giaban,-2)+100 else round(aa.giaban,-2) end)end)* aa.soluong as thanhtien,aa.soluong*(case when aa.madoituong=1 then aa.giaban else (case when round(aa.giaban,-2) < aa.giaban then round(aa.giaban,-2)+100 else round(aa.giaban,-2) end)end) as thucthu,";
                    else sql += "aa.giaban as dongia,aa.giaban* aa.soluong as thanhtien,aa.soluong*aa.giaban as thucthu,";
                    sql += " aa.madoituong, c.doituong, d.makp, d.tenkp, '' as tenbs, a.id as idcd,to_number('0') as id_loai,to_number('0') as id_nhom,to_number('0') as dichvu,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                    sql += ",a.mabs ";//gam 15/02/2012
                    sql += ", b.vat ";//binh  14082012
                    sql += " from medibvmmyy.d_ngtrull a inner join medibvmmyy.d_ngtruct aa on a.id=aa.id left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on aa.mabd=b.id left join medibv.doituong c on aa.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + exp + " and a.mabn='"+txtMabn.Text+txtMabn1.Text+"'";// gam 20-06-2011 them dk and mabn=''
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
                    if (tmn_Toathuocmuangoai_chuaduyet.Checked && !v_chithuhoadonthuong)
                {
                    exp = " where aa.paid=0 and a.maql = " + v_maql;
                    if (s_madoituongthu != "")
                    {
                        exp += " and aa.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and aa.mabd not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,aa.mabd as mavp, b.ma,b.ten,b.dang as dvt,aa.slyeucau as soluong,";
                    if (blamtron) sql += "(case when b.madoituong=1 then b.giaban else (case when round(b.giaban,-2) < b.giaban then round(b.giaban,-2)+100 else round(b.giaban,-2) end)end) as dongia,(case when b.madoituong=1 then b.giaban else (case when round(b.giaban,-2) < b.giaban then round(b.giaban,-2)+100 else round(b.giaban,-2) end)end)* aa.slyeucau as thanhtien,(case when b.madoituong=1 then b.giaban else (case when round(b.giaban,-2) < b.giaban then round(b.giaban,-2)+100 else round(b.giaban,-2) end)end)* aa.slyeucau  as thucthu,";
                    else sql += "b.giaban as dongia,b.giaban* aa.slyeucau as thanhtien,b.giaban* aa.slyeucau  as thucthu,";
                    sql += " aa.madoituong, c.doituong, d.makp, d.tenkp, '' as tenbs, a.id as idcd,to_number('0') as id_loai,to_number('0') as id_nhom,to_number('0') as dichvu,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                    sql += ",a.mabs ";//gam 15/02/2012
                    sql += ", b.vat ";//binh  14082012
                    sql += " from medibvmmyy.d_thuocbhytll a inner join medibvmmyy.d_thuocbhytct aa on a.id=aa.id left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on aa.mabd=b.id left join medibv.doituong c on aa.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + exp + " and a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";// gam 20-06-2011 them dk and mabn=''
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
                if (ads != null)
                {
                    m_dshoadon = ads;
                    if (iMien_Chenhlech_Tyle > 0 && sMien_Chenhlech_Cholam.ToUpper() == txtNoilamviec.Text.ToUpper())
                    {
                        foreach (DataRow r in ads.Tables[0].Select("thucthu>0"))
                        {
                            f_Tinhtien_Mien_Chenhlech(decimal.Parse(r["mavp"].ToString()));
                        }
                    }
                    dgHoadon.DataSource = ads.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien();
                }
            }
            catch(Exception ex) 
            {
            }
        }

        private void f_Load_Chidinh(string v_tn, string v_maql,string v_id,string v_loai)
        {
            try
            {
                try
                {
                    v_maql = decimal.Parse(v_maql).ToString();
                    v_id = decimal.Parse(v_id).ToString();
                }
                catch
                {
                    return;
                }
                v_tn = m_v.f_string_date(v_tn);
                if (v_tn.Length >= 10)
                {
                    v_tn = v_tn.Substring(0, 10);
                }
                else
                {
                    v_tn = txtNgaythu.Text.Substring(0, 10);
                }
                if (v_btrutamung)
                    f_Load_Tamung(v_tn, m_mavaovien);
                else
                    toolStrip_Tamung.Text = "0";
                string sql = "", exp = "", s_loaiba = "0,5,";
                DataSet ads = null, ads1 = null;
                DataSet ads_cd =null;
                DataSet ads_toathuoc = null,ads_toathuocchon=null;

                //Chi dinh
                if (tmn_Thuchidinh.Checked)
                {
                    if (tmn_Conhanbenh.Checked)
                    {
                        s_loaiba += " 1,";
                    }
                    if (tmn_Cophongluu.Checked)
                    {
                        s_loaiba += "4,";
                    }
                    if (tmn_Cokhambenh.Checked)
                    {
                        s_loaiba += " 3,";
                    }
                    if (tmn_congoaitru.Checked)
                    {
                        s_loaiba += " 2,";
                    }
                    exp = " where a.paid=0 and a.idttrv=0 ";
                    if (s_loaiba.Trim().Trim(',') != "") exp += " and a.loaiba in(" + s_loaiba.Trim().Trim(',') + ")";
                    if (tt_thuchidinh_ngay) exp += " and a.mabn='" + txtMabn.Text + txtMabn1.Text + "' and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + v_tn + "','dd/mm/yyyy') and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    else exp += " and a.maql = " + v_maql;
                    //Khong cho thu doi tuong bhyt tren man hinh thu truc tiep
                    exp += " and a.madoituong<>1";
                    //
                    if (s_madoituongthu != "")
                    {
                        exp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and a.mavp not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    if (v_khongthuhoadonthuong)
                    {
                        exp += " and b.thuong =0 ";
                    }
                    if (v_chithuhoadonthuong)
                    {
                        exp += " and b.thuong = 1 ";
                    }
                    if (mavp_gioihan.Trim().Trim(',') != "")
                    {
                        exp += " and a.mavp in(" + mavp_gioihan.Trim().Trim(',') + ")";
                    }
                    if (mavp_gioihan_noitru.Trim().Trim(',') != "")
                    {
                        exp += " and ((a.mavp in(" + mavp_gioihan_noitru.Trim().Trim(',') + ") and a.loaiba in(1)) or loaiba not in(1) )";//binh 100611
                    }
                    if (chkKhuyenMai.Checked)// nếu load chỉ định theo đợt khuyến mãi
                    {
                        DataSet ads_km = new DataSet();
                        ads_km = m_v.get_data("select a.tugio,a.dengio from medibv.v_dot_khuyenmai a where a.hide=0 and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') >= a.tungay and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')<= a.denngay");
                        if (ads_km.Tables[0].Rows.Count > 0)
                        {
                            if (f_kiemTraGio(ads_km.Tables[0].Rows[0][0].ToString(), ads_km.Tables[0].Rows[0][1].ToString()))// kiem tra con trong khoang thoi gian khuyen mai
                            {
                                sql = "select a.id, a.chon,a.ngaycd, a.mavp, a.ma,a.ten,a.dvt,a.soluong,a.dongia,a.thanhtien,min(a.thucthu) as thucthu,a.madoituong,a.doituong,a.makp,a.tenkp, a.tenbs, a.idcd,a.id_loai, a.id_nhom ,sum(mien) as mien,a.dichvu  from ( ";
                                sql += "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                                if (tmn_khuyenmai.Checked)
                                {
                                    sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                                }
                                else
                                {
                                    sql += " , a.stgiam as mien"; //sql += " ,to_number('0') as mien";
                                }
                                sql += " ,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho";
                                sql += ",a.mabs";//gam 15/02/2012
                                sql += ",b.vat ";//binh  14082012
                                sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + exp;
                                sql += " union all ";
                                sql += " select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,((a.soluong*a.dongia)-(h.sotienkhuyenmai*a.soluong)) as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom ,b.dichvu,h.sotienkhuyenmai*a.soluong as mien ,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                                sql += ",a.mabs ";//gam 15/02/2012
                                sql += ",b.vat ";//binh  14082012
                                sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai inner join medibv.v_giavp_khuyenmai h on a.mavp=h.idvp inner join medibv.v_dot_khuyenmai i on h.iddot=i.id " + exp + " and i.hide=0 ";
                                sql += ") as a group by a.mavp, a.chon,a.ngaycd, a.id, a.ma,a.ten,a.dvt,a.soluong,a.dongia,a.thanhtien,a.madoituong,a.doituong,a.makp, a.tenkp, a.mabs,a.tenbs, a.idcd,a.id_loai, a.id_nhom,b.dichvu ";
                            }
                            else
                            {
                                sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                                if (tmn_khuyenmai.Checked)
                                {
                                    sql += " ,a.dongia*tylekhuyenmai/100 as mien,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho";
                                }
                                else
                                {
                                    sql += " , a.stgiam as mien,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho"; //sql += " ,to_number('0') as mien,b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho";
                                }
                                sql += ",a.mabs ";//gam 15/02/2012
                                sql += ",b.vat ";//binh  14082012
                                sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + exp;
                            }
                        }
                        else
                        {
                            sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                            if (tmn_khuyenmai.Checked)
                            {
                                sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                            }
                            else
                            {
                                sql += " ,a.stgiam as mien"; // sql += " ,to_number('0') as mien";
                            }
                            sql += ",b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                            sql += ",a.mabs ";//gam 15/02/2012
                            sql += ",b.vat ";//binh  14082012
                            sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + exp;
                        }

                    }//end khuyen mai
                    else
                    {
                        sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                        if (tmn_khuyenmai.Checked)
                        {
                            sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                        }
                        else
                        {
                            sql += " ,a.stgiam as mien"; //sql += " ,to_number('0') as mien";
                        }
                        sql += ",b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                        sql += ",a.mabs ";//gam 15/02/2012
                        sql += ",b.vat ";//binh  14082012
                        sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on a.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + exp;
                    }
                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
                    if (ads1 != null)
                    {
                        if(btt_Thutungdonthuoc)
                        {
                            if(ads_cd==null)
                            {
                                ads_cd = ads1;
                            }
                            else
                            {
                                ads_cd.Merge(ads1);
                            }
                        }
                        else if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                if (tmn_thuvienphikhoa.Checked)
                {
                    exp = " where done=0 and a.maql=" + v_maql;
                    //Khong cho thu doi tuong bhyt tren man hinh thu truc tiep
                    exp += " and a.madoituong<>1";
                    //
                    if (s_madoituongthu != "")
                    {
                        exp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (v_khongthuhoadonthuong)
                    {
                        exp += " and b.thuong =0 ";
                    }
                    if (v_chithuhoadonthuong)
                    {
                        exp += " and b.thuong = 1 ";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and a.mavp not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,";
                    sql += "a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp,";
                    sql += "d.tenkp,'' as tenbs, a.id as idcd,b.id_loai, g.id_nhom,b.dichvu";
                    if (tmn_khuyenmai.Checked)
                    {
                        sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                    }
                    else
                    {
                        sql += " ,to_number('0') as mien";
                    }
                    sql += ",b.phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                    sql += ",'' as mabs ";//gam 15/02/2012
                    sql += ",b.vat ";//binh  14082012
                    sql += " from medibvmmyy.v_vpkhoa a inner join medibv.v_giavp b on a.mavp=b.id ";
                    sql += " left join medibv.doituong c on a.madoituong=c.madoituong ";
                    sql += " left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id ";
                    sql += " left join medibv.v_loaivp g on g.id=b.id_loai" + exp;

                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
                    if (ads1 != null)
                    {
                        if(btt_Thutungdonthuoc)
                        {
                            if(ads_cd==null)
                            {
                                ads_cd = ads1;
                            }
                            else
                            {
                                ads_cd.Merge(ads1);
                            }
                        }
                        else if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                //Toa thuoc thu truc
                if (tmn_Toathuoctutruc.Checked && !v_chithuhoadonthuong)
                {
                    exp = " where done=0 and a.maql = " + v_maql;
                    //Khong cho thu doi tuong bhyt tren man hinh thu truc tiep
                    exp += " and a.madoituong<>1";
                    //
                    if (s_madoituongthu != "")
                    {
                        exp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and a.mabd not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    if (s_tutructhutheokhoa.Trim(',') != "")
                    {
                        exp += " and d.makp in(" + s_tutructhutheokhoa.Trim(',') + ")";
                    }
                    if (bKhongthu_tutruc_noitru)
                    {
                        exp += " and (d.loai is null or d.loai<>0)";
                    }
                    if (bKhongthu_tutruc_phongluu)
                    {
                        exp += " and (d.loai is null or d.loai<>4)";
                    }
                    exp += " and a.soluong<>0 ";
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,a.mabd as mavp, b.ma,b.ten,b.dang as dvt,a.soluong,";
                    sql += "a.giaban as dongia,";
                    sql += "a.giaban* a.soluong as thanhtien,a.soluong*a.giaban as thucthu, ";
                    sql += "a.madoituong, c.doituong, d.makp, d.tenkp, '' as tenbs, a.id as idcd,to_number('0') as id_loai,to_number('0') as id_nhom,to_number('0') as dichvu,to_number('0') as mien ,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                    sql += ", a.mabs ";
                    sql += ", b.vat ";//binh  14082012
                    sql += " from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + exp;
                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
                    if (ads1 != null)
                    {
                        if(btt_Thutungdonthuoc)
                        {
                            if(ads_toathuoc == null)
                            {
                                ads_toathuoc = ads1;
                            }
                            else
                            {
                                ads_toathuoc.Merge(ads1);
                            }
                        }
                        else if (ads == null)
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
                if (tmn_Toathuocmuangoai.Checked && !v_chithuhoadonthuong)
                {
                    exp = " where aa.idttrv=0 and a.maql = " + v_maql;
                    if (s_madoituongthu != "")
                    {
                        exp += " and aa.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and aa.mabd not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,aa.mabd as mavp, b.ma,b.ten,b.dang as dvt,aa.soluong,";
                    if (blamtron) sql += "(case when aa.madoituong=1 then aa.giaban else (case when round(aa.giaban,-2) < aa.giaban then round(aa.giaban,-2)+100 else round(aa.giaban,-2) end)end) as dongia,(case when aa.madoituong=1 then aa.giaban else (case when round(aa.giaban,-2) < aa.giaban then round(aa.giaban,-2)+100 else round(aa.giaban,-2) end)end)* aa.soluong as thanhtien,aa.soluong*(case when aa.madoituong=1 then aa.giaban else (case when round(aa.giaban,-2) < aa.giaban then round(aa.giaban,-2)+100 else round(aa.giaban,-2) end)end) as thucthu,";
                    else sql += "aa.giaban as dongia,aa.giaban* aa.soluong as thanhtien,aa.soluong*aa.giaban as thucthu,";
                    sql += " aa.madoituong, c.doituong, d.makp, d.tenkp, '' as tenbs, a.id as idcd,to_number('0') as id_loai,to_number('0') as id_nhom,to_number('0') as dichvu,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                    sql += ",a.mabs ";//gam 15/02/2012
                    sql += ",b.vat ";//binh  14082012
                    sql += " from medibvmmyy.d_ngtrull a inner join medibvmmyy.d_ngtruct aa on a.id=aa.id left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on aa.mabd=b.id left join medibv.doituong c on aa.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + exp + " and a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";// gam 20-06-2011 them dk and mabn=''
                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
                    if (ads1 != null)
                    {
                        if(btt_Thutungdonthuoc)
                        {
                            if(ads_toathuoc == null)
                            {
                                ads_toathuoc = ads1;
                            }
                            else
                            {
                                ads_toathuoc.Merge(ads1);
                            }
                        }
                        else if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                if (tmn_Toathuocmuangoai_chuaduyet.Checked && !v_chithuhoadonthuong)
                {
                    exp = " where aa.paid=0 and a.maql = " + v_maql;
                    if (s_madoituongthu != "")
                    {
                        exp += " and aa.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        exp += " and aa.mabd not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,aa.mabd as mavp, b.ma,b.ten,b.dang as dvt,aa.slyeucau as soluong,";
                    if (blamtron) sql += "(case when b.madoituong=1 then b.giaban else (case when round(b.giaban,-2) < b.giaban then round(b.giaban,-2)+100 else round(b.giaban,-2) end)end) as dongia,(case when b.madoituong=1 then b.giaban else (case when round(b.giaban,-2) < b.giaban then round(b.giaban,-2)+100 else round(b.giaban,-2) end)end)* aa.slyeucau as thanhtien,(case when b.madoituong=1 then b.giaban else (case when round(b.giaban,-2) < b.giaban then round(b.giaban,-2)+100 else round(b.giaban,-2) end)end)* aa.slyeucau  as thucthu,";
                    else sql += "b.giaban as dongia,b.giaban* aa.slyeucau as thanhtien,b.giaban* aa.slyeucau  as thucthu,";
                    sql += " aa.madoituong, c.doituong, d.makp, d.tenkp, '' as tenbs, a.id as idcd,to_number('0') as id_loai,to_number('0') as id_nhom,to_number('0') as dichvu,to_number('0') as mien,to_char(0) as phongthuchiencls,to_number('0') as maphongcls,to_number('0') as sttcho ";
                    sql += ",a.mabs ";//gam 15/02/2012
                    sql += ",b.vat ";//binh  14082012
                    sql += " from medibvmmyy.d_thuocbhytll a inner join medibvmmyy.d_thuocbhytct aa on a.id=aa.id left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on aa.mabd=b.id left join medibv.doituong c on aa.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + exp + " and a.mabn='" + txtMabn.Text + txtMabn1.Text + "'";// gam 20-06-2011 them dk and mabn=''
                    ads1 = m_v.get_data_bc_1(v_tn, txtNgaythu.Text.Substring(0, 10), sql);
                    if (ads1 != null)
                    {
                        if(btt_Thutungdonthuoc)
                        {
                            if(ads_toathuoc == null)
                            {
                                ads_toathuoc = ads1;
                            }
                            else
                            {
                                ads_toathuoc.Merge(ads1);
                            }
                        }
                        else if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                if (ads_cd != null || ads_toathuoc != null || ads!=null)
                {
                    if (btt_Thutungdonthuoc && ads == null)
                    {
                        if(v_loai=="0" && ads_cd!=null)
                        {
                            m_dshoadon = ads_cd;
                        }
                        else if (v_loai == "1" && ads_toathuoc != null)
                        {
                            ads_toathuocchon = ads_toathuoc.Clone();
                            foreach (DataRow r in ads_toathuoc.Tables[0].Select("idcd='"+v_id+"'"))
                            {
                                ads_toathuocchon.Tables[0].Rows.Add(r.ItemArray);
                            }
                            m_dshoadon = ads_toathuocchon;
                        }
                    }
                    else
                    {
                        m_dshoadon = ads;
                    }
                    if (iMien_Chenhlech_Tyle > 0 && sMien_Chenhlech_Cholam.ToUpper() == txtNoilamviec.Text.ToUpper())
                    {
                        foreach (DataRow r in ads.Tables[0].Select("thucthu>0"))
                        {
                            f_Tinhtien_Mien_Chenhlech(decimal.Parse(r["mavp"].ToString()));
                        }
                    }
                    if (btt_Thutungdonthuoc && v_loai == "0" && ads_cd.Tables[0].Rows.Count != 0)
                    {
                        dgHoadon.DataSource = ads_cd.Tables[0];
                    }
                    else if (btt_Thutungdonthuoc && v_loai == "1" && ads_toathuocchon.Tables[0].Rows.Count != 0)
                    {
                        dgHoadon.DataSource = ads_toathuocchon.Tables[0];
                    }
                    else
                    {
                        dgHoadon.DataSource = ads.Tables[0];
                    }
                    dgHoadon.Update();
                    f_Tinhtien();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void f_Load_CB_Ngayvv(string v_tn, string v_maql)
        {
            try
            {
                string sql = "", asql1 = "", amabn = "";
                amabn = txtMabn.Text + txtMabn1.Text;
                DateTime adt = txtNgaythu.Value;
                v_tn = m_v.f_string_date(v_tn);

                if (v_tn.Length >= 10)
                {
                    adt = m_v.f_parse_date(v_tn.Substring(0, 10));
                }

                asql1 = "select maql, maql as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') ||'-TĐ' as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number('0') as loaibn, sovaovien from medibvmmyy.tiepdon where noitiepdon not in (3) and mabn='" + amabn + "'";
                if (bAll_days == false) asql1 += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                if (tmn_Cokhambenh.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi')||'-PK'  as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number('3') as loaibn, sovaovien  from medibvmmyy.benhanpk where mabn='" + amabn + "'";
                    if (bAll_days == false) asql1 += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                //gam 01/03/2011-nếu có phân quyền thu toa thuốc mua ngoài thì lấy thêm ngày mua thuốc
                if (tmn_Toathuocmuangoai.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    // gam 29-04-2011
                    asql1 += "select maql,to_number('0') as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi')||'-MN'  as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1,";
                    asql1 += "to_char(makp) as makp,2 as madoituong,to_number('3') as loaibn, to_char('') as sovaovien from medibvmmyy.d_ngtrull where mabn='" + amabn + "'";
                    if (bAll_days == false) asql1 += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                //gam
               
                if (tmn_Cophongluu.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi')||'-PL' as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number('4') as loaibn, sovaovien from medibvmmyy.benhancc where mabn='" + amabn + "'";
                    if (bAll_days == false) asql1 += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                DataSet ads = null, ads1 = null, ads2 = null;
                if (asql1 != "")
                {
                    asql1 += "  order by ngay1 desc";
                    ads = m_v.get_data_mmyy(asql1, m_v.DateToString("dd/MM/yyyy", adt.AddMonths(-iSothang)), txtNgaythu.Text.Substring(0, 10), true);
                }
                if (tmn_Conhanbenh.Checked)
                {
                    sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi')||'-NT'  as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,loaiba as loaibn, '' as sovaovien from medibv.benhandt where mabn='" + amabn + "'";
                    if (bAll_days == false) sql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    sql+=" order by ngay1 desc";
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
                //
                if (tmn_congoaitru.Checked)
                {
                    sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi')||'-NgT'  as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number('3') as loaibn, '' as sovaovien  from medibv.benhanngtr where mabn='" + amabn + "'";
                    if (bAll_days == false) sql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (ads == null)
                    {
                        ads = m_v.get_data(sql);
                    }
                    else
                    {
                        ads.Merge(m_v.get_data(sql));
                    }
                    
                }
                
                ads2 = ads.Clone();

                foreach (DataRow r in ads.Tables[0].Select("", "ngay1 desc,maql desc"))
                    ads2.Tables[0].Rows.Add(r.ItemArray);

                cbNgayvv.DisplayMember = "ngay";
                cbNgayvv.ValueMember = "maql";
                cbNgayvv.DataSource = ads2.Tables[0];
                if (v_maql!="")
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
            catch
            {
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            m_v.Disconnect();
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
            string v_nhieubienlai = "";
           
            if (tmn_thutheoloaivp.Checked) v_nhieubienlai = "LOAI";
            else if (tmn_thutheonhomvp.Checked) v_nhieubienlai = "NHOM";
            CurrencyManager cm = (CurrencyManager)BindingContext[dgHoadon.DataSource, dgHoadon.DataMember];
            DataView dv = (DataView)cm.List;
            string exp = "", sql_exp = v_nhieubienlai == "NHOM" ? "id_nhom=" : (v_nhieubienlai == "LOAI" ? "id_loai=" : "");
            if(v_nhieubienlai!="")
			{
                foreach (DataRow r1 in dv.Table.Rows)
                {
                    DataRow r = m_v.getrowbyid(m_dsgiavp.Tables[0], "id='" + r1["mavp"].ToString().Trim() + "'");
                    if (r == null) continue;
                    if (v_nhieubienlai == "NHOM") 
                    { 
                        if (exp.IndexOf(r["id_nhom"].ToString() + ",") < 0) exp += r["id_nhom"].ToString() + ","; 
                    }
                    else if (v_nhieubienlai == "LOAI") 
                    {
                        if (exp.IndexOf(r["id_loai"].ToString() + ",") < 0) exp += r["id_loai"].ToString() + ","; 
                    }
                }
                if (exp != "") exp = exp.Substring(0, exp.Length - 1);
            }
           
            if (exp == "" && v_tachhoadon_dv == "")
            {
                f_Luu();
                
            }
            else if (v_tachhoadon_dv != "")
            {
                string ammyy = "";
                if (m_dshoadon.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Đề nghị nhập nội dung thu viện phí!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenvp.Focus();
                    return;
                }
                string s_exp = "(madoituong not in (" + v_tachhoadon_dv + ") and dichvu=0)";
                //if (bTachHDGTGT_TheoVAT) s_exp += " or (vat=0)";
                f_Luu(false, m_dshoadon.Tables[0].Select(s_exp));
                if (!b_sua && !b_huykembldv) m_id = "";
                else if (!b_sua && b_huykembldv) m_id = "-" + m_id;
                if (bTachHDGTGT_TheoVAT==false)//binh 140812
                {
                    f_Luu(true, m_dshoadon.Tables[0].Select("madoituong in (" + v_tachhoadon_dv + ") or dichvu=1"));
                }
                else
                {
                    f_Luu(true, m_dshoadon.Tables[0].Select("vat=5 and (madoituong in (" + v_tachhoadon_dv + ") or dichvu=1)"));//hoa don vat 5%
                    if (m_dshoadon.Tables[0].Select("vat=10 and (madoituong in (" + v_tachhoadon_dv + ") or dichvu=1)").Length > 0)
                    {
                        m_id = "0";
                        f_Luu(true, m_dshoadon.Tables[0].Select("vat=10 and (madoituong in (" + v_tachhoadon_dv + ") or dichvu=1)"));//hoa don vat 10%
                    }

                    if (m_dshoadon.Tables[0].Select("vat=0 and (madoituong in (" + v_tachhoadon_dv + ") or dichvu=1)").Length > 0)
                    {
                        m_id = "0";
                        f_Luu(true, m_dshoadon.Tables[0].Select("vat=0 and (madoituong in (" + v_tachhoadon_dv + ") or dichvu=1)"));//hoa don vat 10%
                    }
                }
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16));
                f_Load_Hoadon(m_id,ammyy);
            }
            else
            {
                foreach (string e_exp in exp.Split(",".ToCharArray()))
                {
                    f_Luu(sql_exp + e_exp);
                }
            }
            f_Load_Thutrongngay();
            
        }
        private void f_Luu(string exp)
        {
            try
            {
                bool asua = (m_id != "" && m_id != "0");
                string atmp = "", aidcd = "", amakp_ll = "01";
                butLuu.Enabled = false;            
                if (m_dshoadon.Tables[0].Rows.Count <= 0)
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Đề nghị nhập nội dung thu viện phí!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenvp.Focus();
                    return;
                }
                if (toolStrip_Mien.Text != "0" && tmn_Nhaplydomien.Checked && cbLydomien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Đề nghị nhập lý do miễn giảm!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLydomien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Đề nghị nhập người duyệt miễn giảm!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Đề nghị nhập người duyệt miễn giảm!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKymien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "",
                    amaql = "", aidkhoa = "", amakp = "", ahoten = "", anamsinh = "", adiachi = "", aloai = "", aloaibn = "", 
                    auserid = "",amavp = "";
                angay = txtNgaythu.Text.Substring(0, 16);
                ammyy = m_v.get_mmyy(angay);
                try
                {
                    aid = "0";
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
                    MessageBox.Show(this,"Chọn quyển sổ thu viện phí!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    lbKyhieu_Click(null, null);
                    cbKyhieu.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                amabn = txtMabn.Text.Trim() + txtMabn1.Text.Trim();
                if (txtMabn1.Text==""||txtMabn.Text==""||txtHoten.Text == "")
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Nhập thông tin bệnh nhân!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMabn.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                try
                {
                    amakp = cbotenpk.SelectedValue.ToString();
                }
                catch
                {
                    amakp = m_makp_khongkham;
                }
                amakp_ll = amakp;
                if (amakp_ll == "00" || amakp_ll == "")
                {
                    amakp_ll = m_makp_khongkham;
                }
                ahoten = txtHoten.Text.Trim();
                if (ahoten.Length == 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Nhập thông tin bệnh nhân!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtSonha.Text != "")
                {
                    adiachi = txtSonha.Text.Trim() + ",";
                }
                if (txtThonpho.Text != "")
                {
                    adiachi += txtThonpho.Text.Trim() + ",";
                }
                if (cbXa.Text.ToUpper().Trim() !="KHÔNG XÁC ĐỊNH")
                {
                    if (adiachi != "")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbXa.Text.Trim();
                }
                if (cbQuan.Text.ToUpper().Trim() !="KHÔNG XÁC ĐỊNH")
                {
                    if (adiachi != "")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbQuan.Text.Trim();
                }
                if (cbTinh.Text.ToUpper().Trim() !="KHÔNG XÁC ĐỊNH")
                {
                    if (adiachi != "")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbTinh.Text.Trim();
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
                aidkhoa = "0";
                if (amaql != "" && amaql != "0")
                {
                    if (m_v.f_parse_date(cbNgayvv.Text.Substring(0, 10)) > txtNgaythu.Value)
                    {
                        MessageBox.Show(this,"Đề nghị chọn ngày thu lớn hơn hay = ngày bệnh nhân vào viện (" + cbNgayvv.Text.Substring(0, 10) + ")!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                        if (MessageBox.Show(this, "Hết sổ, đề nghị chọn sổ mới! \n Có muốn chọn sổ khác không?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                    {
                        if (atmp.Split(':')[1] == "2")//Lỗi
                        {
                            //butLuu.Enabled = true;
                            //MessageBox.Show(this, "Không tìm thấy quyển sổ thu viện phí! \n Đề nghị chọn sổ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cbKyhieu.Enabled = false;
                            //lbKyhieu_Click(null, null);
                            //cbKyhieu.Focus();
                            //SendKeys.Send("{F4}");
                            //return;
                        }
                    }
                }
                if (m_bnmoi || v_chuyenchidinhCLS)
                {
                    try
                    {
                        string m_khongdau = m_v.f_khongdau(ahoten);
                        if (v_NamBTDBN.IndexOf(m_v.get_mmyy(angay) + "+") == -1) v_NamBTDBN = v_NamBTDBN + m_v.get_mmyy(angay) + "+";
                        //Luu hanh chanh
                        if (!m_v.upd_btdbn(amabn, ahoten, txtNgaysinh.Text, anamsinh, decimal.Parse(cbGioitinh.SelectedValue.ToString()), mann.Text.Trim(), madantoc.Text.Trim(), txtSonha.Text.Trim(), txtThonpho.Text.Trim(), "", cbTinh.SelectedValue.ToString(), cbQuan.SelectedValue.ToString(), cbXa.SelectedValue.ToString(), -decimal.Parse(auserid), v_NamBTDBN, m_khongdau))
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
                        MessageBox.Show(this,"Không cập nhật được thông tin bệnh nhân! \n Chưa lưu hoá đơn!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                string v_maql_TD = "";
                try
                {
                    v_maql_TD = m_v.get_data_mmyy(ammyy, "select maql from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/MM/yyyy')='" + angay.Substring(0,10) + "'").Tables[0].Rows[0]["maql"].ToString();

                }
                catch
                {
                    v_maql_TD = "0";
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
                    MessageBox.Show(this,"Không cập nhật được thông tin tiếp đón! \n Chưa lưu hoá đơn!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (amavaovien == "")
                {
                    amavaovien = amaql;
                }

                #region 
                

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_vienphill", "id=" + aid + " and mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "upd", s);
                }
                //else m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "ins");

                
                if (aid != "0")
                {
                    foreach (DataRow r1 in m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_vienphict where id=" + aid + "").Tables[0].Rows)
                    {
                        string s = m_v.fields(m_v.user + ammyy + ".v_vienphict", "id=" + aid + " and stt=" + int.Parse(r1["stt"].ToString()));
                        m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "upd");
                        m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "upd", s);
                    }
                } //else m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "ins");

                

                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_mienngtru", "id=" + aid);
                    m_v.upd_eve_tables(ammyy, itablemien, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablemien, int.Parse(m_userid), "upd", s);
                }
                #endregion //end

                asobienlai = txtSobienlai.Text.Trim();
                if (aid != "0")
                {
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_vienphict where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_mienngtru where id = " + aid);
                }
                quyensodv = sobienlaidv = "";
                if (v_Quanglydichvu)
                {
                    quyensodv = lbl_quyensodichvu.Text.Trim();
                    sobienlaidv = lbl_SBLdichvu.Text.Trim();
                }
                aid = m_v.upd_v_vienphill(ammyy, decimal.Parse(aid), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), amakp_ll, ahoten, anamsinh, adiachi, decimal.Parse(aloai), decimal.Parse(aloaibn), decimal.Parse(auserid), decimal.Parse(cbGioitinh.SelectedValue.ToString()), "", "", chkTheKB.Checked ? 2 : 0, (quyensodv != "") ? decimal.Parse(quyensodv) : 0, (sobienlaidv != "") ? decimal.Parse(sobienlaidv) : 0,"");
                if (!v_Quanglydichvu) m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
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
                    m_v.upd_v_mienngtru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien), decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", "")), "Miển giảm thu trực tiếp", decimal.Parse(amaduyet));
                }
                if (aid != "0")
                {
                    decimal astt = 1,vat=0;
                    DataRow r0;
                    bool bHoadondv = false, bHoadon = false;
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {                       
                        try
                        {
                            string sa = r["mavp"].ToString();
                            if (m_dsgiavp.Tables[0].Select(exp + " and id='" + r["mavp"].ToString() + "'").Length == 0) continue;
                            vat = (r["vat"].ToString() == "") ? 0 : decimal.Parse(r["vat"].ToString());//binh 140812
                            if (v_Quanglydichvu)
                            {
                                r0 = m_v.getrowbyid(dtdv, "id=" + decimal.Parse(r["mavp"].ToString()));
                                if (r0 != null)
                                {
                                    vat = decimal.Parse(r0["vat"].ToString());
                                    m_v.upd_v_vienphict("v_vienphidv", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), vat, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
                                    bHoadondv = true;
                                }
                                else bHoadon = true;
                            }
                            if (chkKhuyenMai.Checked)/////////////////LUU  hoa don khuyen mai
                            {
                                DataSet ads_km = new DataSet();
                                string sql = "", smakp = "", smabs = "";
                                smabs = r["mabs"].ToString() == "" ? "0" : r["mabs"].ToString();
                                smakp = r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll;

                                try
                                {
                                    ads_km = m_v.get_data("select a.idvp from medibv.v_giavp_khuyenmai a inner join medibv.v_dot_khuyenmai b  on b.id=a.iddot where b.hide=0 and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') >= b.tungay and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')<= b.denngay");
                                    if (ads_km.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow r_ct in ads_km.Tables[0].Select("idvp=" + r["mavp"].ToString()))
                                        {
                                            sql = "update medibv" + ammyy + ".v_vienphict set id=" + aid + ", stt=" + astt + ", madoituong=" + r["madoituong"].ToString() + ", makp=" + smakp + ", ten='" + r["ten"].ToString() + "', mavp=" + r["mavp"].ToString() + ", soluong=" + r["soluong"].ToString() + ", dongia=" + r["dongia"].ToString() + ", mien=" + r["mien"].ToString() + ", mabs=" + smabs + ", idchidinh=" + r["idcd"].ToString() + ",khuyenmai=1" + " where id=" + aid + " and stt=" + astt + " and idchidinh=" + r["idcd"].ToString();
                                            m_v.execute_data(sql);
                                            try
                                            {
                                                sql = "insert into medibv" + ammyy + ".v_vienphict(id,stt,madoituong,makp,ten,mavp,soluong,dongia,mien,mabs,idchidinh,khuyenmai) values(" + aid + "," + astt + "," + r["madoituong"].ToString() + "," + smakp + ",'" + r["ten"].ToString() + "'," + r["mavp"].ToString() + "," + r["soluong"].ToString() + "," + r["dongia"].ToString() + "," + r["mien"].ToString() + "," + smabs + "," + r["idcd"].ToString() + ",1)";
                                                m_v.execute_data(sql);
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }
                                    }
                                    else
                                    {
                                        m_v.upd_v_vienphict("v_vienphict", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), vat, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
                                    }
                                }
                                catch { }
                            }
                            else
                            {
                                m_v.upd_v_vienphict("v_vienphict", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), vat, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
                            }
                            astt += 1;
                            //update paid chi dinh
                            if (r["idcd"].ToString().Trim() != "0" && r["idcd"].ToString().Trim() != "")
                            {
                                aidcd += ",";
                                aidcd += r["idcd"].ToString();
                            }
                            else
                            {
                                if (v_chuyenchidinhCLS)
                                {
                                    aidchidinh = "";
                                    aidchidinh = m_v.get_id_v_chidinh.ToString();
                                    if (r["chon"].ToString() == "1")
                                        m_v.upd_v_chidinh_tt(ammyy, decimal.Parse(aidchidinh), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), angay, int.Parse(aloai), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, int.Parse(r["madoituong"].ToString()), int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 1, 0, -int.Parse(auserid), 1, 1, 0, 0, decimal.Parse(aid));
                                    else
                                        m_v.upd_v_chidinh_tt(ammyy, decimal.Parse(aidchidinh), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), angay, int.Parse(aloai), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, int.Parse(r["madoituong"].ToString()), int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 1, 0, -int.Parse(auserid), 1, 1, 1, 1, decimal.Parse(aid));
                                    m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphict set idchidinh=" + aidchidinh + " where mavp=" + r["mavp"].ToString() + " and id=" + aid + "");
                                }
                            }
                            if (r["mavp"].ToString().Trim() != "")
                            {
                                amavp += r["mavp"].ToString().Trim() + ",";
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (bHoadon && bHoadondv && quyensodv == aquyenso)
                    {
                        m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                        lbl_SBLdichvu.Text = f_Get_Sobienlai(m_cur_quyenso_dichvu).Split(':')[0];
                        lbl_quyensodichvu.Text = m_cur_quyenso_dichvu;
                        quyensodv = lbl_quyensodichvu.Text.Trim();
                        sobienlaidv = lbl_SBLdichvu.Text.Trim();
                        m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set sobienlaidv=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                    }
                    if (bHoadondv) m_v.upd_v_quyenso(decimal.Parse(quyensodv), decimal.Parse(sobienlaidv), true);
                    else if (v_Quanglydichvu && bHoadon) m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                    if (v_Quanglydichvu && bHoadondv && !bHoadon) m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_vienphill set quyenso=" + decimal.Parse(quyensodv) + ",sobienlai=" + decimal.Parse(sobienlaidv) + " where id=" + decimal.Parse(aid));
                }
                aidcd = aidcd.Trim();
                aidcd = aidcd.Trim(',');
                if (aidcd != "")
                {
                    string atn = "", sql = "";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    sql = "update medibvmmyy.v_chidinh set paid = 1 where mabn='" + amabn + "' and id in(" + aidcd + ")";
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    if (tmn_Toathuoctutruc.Checked)
                    {
                        sql = "update medibvmmyy.d_tienthuoc set done = 1 where mabn='" + amabn + "' and id in(" + aidcd + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                        //binh 130511
                        try
                        {
                            if (m_v.get_data("select maql from medibv.dasuamadt where maql=" + amaql).Tables[0].Rows.Count <= 0)
                                m_v.execute_data("insert into medibv.dasuamadt(maql,idkhoa) values(" + amaql + ",0)");
                        }
                        catch { }
                    }
                    if (tmn_Toathuocmuangoai.Checked)
                    {
                        sql = "update medibvmmyy.d_ngtruct set idttrv = " + aid + " where id in(" + aidcd + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    }
                }
                //if (amakp_td != "")
                //{
                //    string atn = "", sql = "";
                //    try
                //    {
                //        atn = cbNgayvv.Text.Substring(0, 10);
                //    }
                //    catch
                //    {
                //        atn = angay.Substring(0, 10);
                //    }
                //    sql = "update medibvmmyy.tiepdon set done=null where makp in(" + amakp_td + ")";
                //    if (tt_thuchidinh_ngay == false) sql += " and maql=" + amaql;
                //    else sql += " and to_char(ngay,'dd/mm/yyyy')='" + atn + "' and mabn='" + amabn + "'";
                //    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                //}
                if (m_v.bCongkham(amavp))
                {
                    string atn = "", sql = "";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    sql = "update medibvmmyy.tiepdon set done=null where mabn='" + amabn + "' and maql=" + amaql;
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                }
                m_id = aid;
                if (m_id == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this,"Lỗi lưu dữ liệu! \n Chưa lưu dược hoá đơn!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    f_Enable(false);
                    f_Enable_HC(false);
                    if (tmn_Luuin_Hoadon_Icon.Checked || tmn_Xemtruockhiin_Icon.Checked)
                    {
                        if (tmn_Luuin_Hoadon.Checked)
                        {
                             f_Inhoadon(false);
                        }
                        if (tmn_Luuin_Chiphi.Checked)
                        {
                            f_Inchiphi();
                        }
                    }
                    butMoi.Focus();
                }

                try
                {
                    if (m_cur_quyenso != "")
                    {
                        cbKyhieu.SelectedValue = m_cur_quyenso;
                    }
                }
                catch
                {
                }
                atmp = f_Get_Sobienlai();
                txtSobienlai.Text = atmp.Split(':')[0];
                if (atmp.Split(':')[1] == "1")//Hết số
                {
                    MessageBox.Show(this,"Hết sổ, đề nghị chọn sổ mới!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    cbLoaidv.Focus();
                    return;
                }
                else
                    if (atmp.Split(':')[1] == "2")//Lỗi
                    {
                        MessageBox.Show(this,"Không tìm thấy quyển sổ thu viện phí! \n Đề nghị chọn sổ",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch
            {

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
                    f_Tinhtien();
                }
                f_Enable_HC(false);
                f_Enable(false);
                tmn_Danhsachcho.Enabled = true ;
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

                    //try
                    //{
                    //    txtSothe.MaxLength = int.Parse(r["sothe"].ToString());
                    //}
                    //catch
                    //{
                    //    txtSothe.MaxLength = 20;
                    //}
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
                        if (s.Length >=3)
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
                            txtSonha.Focus();
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
        
        private void txtMabn1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (m_Docmavach)
                    {
                        string s = txtMabn1.Text;
                        if (s.Length >=3)
                        {
                            txtMabn.Text = s.Substring(0, 2);
                            txtMabn1.Text = s.Substring(2);
                           // txtMabn1_Validated(sender, e);
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
                if (e.KeyCode == Keys.Space)
                {
                    txtHoten.Text = f_Getmatat(txtHoten.Text);
                    SendKeys.Send("{END}");
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }
        private string f_Getmatat(string matat)
        {
            string s = "";
            return s = m_v.get_data("select ten from medibv.v_viettat where trim(ma)='"+matat.ToUpper()+"'").Tables[0].Rows[0][0].ToString();
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
                    if (cbTuoi.SelectedIndex == -1) cbTuoi.SelectedIndex = 0;
                    txtNgaysinh.Text = m_v.Namsinh("", int.Parse(txtTuoi.Text), cbTuoi.SelectedIndex).ToString();
                    if (!load_tim_mabn())
                    {
                        if (cbGioitinh.Enabled) SendKeys.Send("{Tab}{F4}");
                        else SendKeys.Send("{Tab}");
                    }
                }
            }
            catch
            {
            }
        }

        private bool load_tim_mabn()
        {
            string s_mabn = txtMabn.Text.Trim() + txtMabn1.Text.Trim();
            string s_mann = mann.Text;
            load_btdnn(1);
            DataTable dt = m_v.v_get_timmabn(txtHoten.Text.Trim().ToUpper(), txtNgaysinh.Text.Length > 4 ? txtNgaysinh.Text : "", txtNgaysinh.Text.Length > 4 ? txtNgaysinh.Text.Substring(6, 4).ToString() : txtNgaysinh.Text, s_mabn).Tables[0];
            if (dt.Rows.Count > 0)
            {
                frmFinmabn f = new frmFinmabn(dt);
                f.ShowDialog();
                if (f.m_mabn != "")
                {
                    txtMabn.Text = f.m_mabn.Substring(0, 2);
                    if (bQuanly_Theo_Chinhanh)
                    {
                        txtMabn1.Text = f.m_mabn.Substring(2, i_maxlength_mabn);
                    }
                    else
                    {
                        txtMabn1.Text = f.m_mabn.Substring(2);
                    }
                    s_mabn = txtMabn.Text + txtMabn1.Text;
                    txtMabn1_Validated(null, null);
                    cbDoituong.Focus();
                    SendKeys.Send("{Home}");
                    return true;
                }
            }
            return false;
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

        private void cbTQX_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cbTQX.Items.Count > 0)
                    {
                        f_Load_T_Q_X(cbTQX.SelectedValue.ToString());
                        txtSonha.Focus();
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

        private void cbXa_KeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtNDK_Ma_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNDK_Ten_KeyDown(object sender, KeyEventArgs e)
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

        private void cbNgayvv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbDoituong.Focus();
                    //SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void cbLoaibn_KeyDown(object sender, KeyEventArgs e)
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

        private void cbDoituongTD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbDoituongTD_SelectedIndexChanged(null, null);
                    if (m_bnmoi)
                    {
                        if (cbDoituongTD.SelectedValue.ToString() == "1")
                            txtSothe.Focus();
                        else
                            txtmapk.Focus();
                    }
                    else
                    {
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
            }
            catch
            {
            }

        }

        private void toolStrip_Tongcong_KeyDown(object sender, KeyEventArgs e)
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

        private void toolStrip_Mien_KeyDown(object sender, KeyEventArgs e)
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
                        if (tmn_Nhapkhoaphong.Checked)
                        {
                            cbKhoa.Focus();
                            SendKeys.Send("{F4}");
                        }
                        else
                        if (tmn_Nhapbacsi.Checked)
                        {
                            cbBacsi.Focus();
                            SendKeys.Send("{F4}");
                        }
                        else
                            if (v_nhapmienchitiet)
                            {
                                txtTylemien.Focus();
                            }
                            else
                            {
                                butAdd_Click(null, null);
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

        private void txtDongia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    f_Get_Item();
                    if (txtSoluong.Text != "" && txtSoluong.Text != "0" && txtDongia.Text != "")
                    {
                        if (tmn_Nhapkhoaphong.Checked)
                        {
                            cbKhoa.Focus();
                            SendKeys.Send("{F4}");
                        }
                        else
                        if (tmn_Nhapbacsi.Checked)
                        {
                            cbBacsi.Focus();
                            SendKeys.Send("{F4}");
                        }
                        else
                        if (v_nhapmienchitiet)
                        {
                            txtTylemien.Focus();
                        }
                        else
                        {
                            butAdd.Focus();
                        }
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

        private void txtMien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (tmn_Nhapkhoaphong.Checked)
                    {
                        cbKhoa.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    if (tmn_Nhapbacsi.Checked)
                    {
                        cbBacsi.Focus();
                        SendKeys.Send("{F4}");
                    }                                   
                    else
                    {
                        butAdd.Focus();
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
                    if (tmn_Nhapkhoaphong.Checked)
                    {
                        cbKhoa.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    if (tmn_Nhapbacsi.Checked)
                    {
                        cbBacsi.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    {
                        butAdd.Focus();
                    }
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
                    if (tmn_Nhapbacsi.Checked)
                    {
                        cbBacsi.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    {
                        butAdd.Focus();
                    }
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
                //if (m_Docmavach)
                //{
                //    string s = txtMabn1.Text;
                //    if (s.Length == 8)
                //    {
                //        txtMabn.Text = s.Substring(0, 2);
                //        txtMabn1.Text = s.Substring(2);
                //        txtMabn1_Validated(sender, e);
                //    }
                //}
                //txtMabn.Text = txtMabn.Text.PadLeft(2, '0');

            }
            catch
            {
                txtMabn.Text = m_v.s_curyy;
            }
        }

        private void txtMabn1_Validated(object sender, EventArgs e)
        {
            if (tmn_Chonhapmoi.Checked==true && m_mabntudong==true && txtMabn1.Text.Trim().Trim('0')=="")
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
            if (txtMabn.Text.Length == 2 && (txtMabn1.Text.Length >=6))//&& txtMabn1.Text.Length == 6)
            {
                f_Load_Hanhchanh(txtMabn.Text+txtMabn1.Text);
            }
        }

        private void cbNgayvv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNgayvv.DataSource]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("maql=" + cbNgayvv.SelectedValue.ToString()))
                {
                    cbLoaibn.SelectedValue = r["loaibn"].ToString();
                    cbKhoa.SelectedValue = r["makp"].ToString();
                    cbotenpk.SelectedValue = r["makp"].ToString();
                    cbDoituong.SelectedValue = r["madoituong"].ToString();
                    cbDoituongTD.SelectedValue = r["madoituong"].ToString();
                    m_mavaovien = decimal.Parse(r["mavaovien"].ToString()).ToString();
                    m_maql = decimal.Parse(r["maql"].ToString()).ToString();
                    f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString());
                    lblSTTKham.Text = r["sovaovien"].ToString();
                    lblSTTKham.Visible = lblSTTKham.Text != "";
                    break;
                }
                f_call_lcd(txtMabn.Text + txtMabn1.Text, txtHoten.Text, toolStrip_Thucthu.Text,"0","");
                
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
            if (!tmn_Luuin_Hoadon.Checked)
            {
                MessageBox.Show(this,"Chọn loại hoá đơn cần in từ [Tùy chọn]!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripSplitButton1.ShowDropDown();
                return;
            }
            if (tmn_Luuin_Hoadon.Checked)
            {
                string exp = "(madoituong in (" + v_tachhoadon_dv + ") or dichvu=1)";
                if (bTachHDGTGT_TheoVAT) exp += " and vat >0 ";
                if (v_tachhoadon_dv != "" && m_dshoadon.Tables[0].Select(exp).Length > 0)
                {
                    f_Inhoadon(true);
                }
                else
                {
                    f_Inhoadon(false);
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

        private void frmThutructiep_SizeChanged(object sender, EventArgs e)
        {
            f_Display();
        }

        private void cbNgayvv_Validated(object sender, EventArgs e)
        {
            try
            {
                cbNgayvv_SelectedIndexChanged(null, null);
                f_Load_BHYT();
                if (m_dshoadon.Tables[0].Rows.Count <= 0 && butLuu.Enabled && (m_id == "" || m_id == "0") && cbNgayvv.Items.Count > 0)
                {
                    f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString());
                }
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
                        if (m_cur_quyenso != "" && m_cur_quyenso!=cbKyhieu.SelectedValue.ToString())
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

        private void frmThutructiep_VisibleChanged(object sender, EventArgs e)
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
                        dgGia.Columns["gia_ksk"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_ksk
                        break;
                    case "GIA_DV":
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_cs
                        dgGia.Columns["gia_ksk"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_ksk
                        break;
                    case "GIA_NN":
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_cs
                        dgGia.Columns["gia_ksk"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_ksk
                        break;
                    case "GIA_CS":
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_cs
                        dgGia.Columns["gia_ksk"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_ksk
                        break;
                    default:
                        dgGia.Columns["Column2_5"].DefaultCellStyle = dataGridViewCellStyle_B;//gia_th
                        dgGia.Columns["Column2_6"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_bh
                        dgGia.Columns["Column2_7"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_dv
                        dgGia.Columns["Column2_8"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_nn
                        dgGia.Columns["Column2_9"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_cs
                        dgGia.Columns["gia_ksk"].DefaultCellStyle = dataGridViewCellStyle_R;//gia_ksk
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
                if (txtSoluong.Text == "" || txtSoluong.Text == "0")
                {
                    txtSoluong.Text = "1";
                }
                if (txtDongia.Text == "")
                {
                    MessageBox.Show(this,"Đơn giá chưa có!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                s_mavp_huy = "";
                f_Add();
                txtTenvp.Text = "";
                txtSoluong.Text = "1";
                txtDongia.Text = "0";
                txtThucthu.Text = "0";
                txtTylemien.Text = "";
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
                txtThucthu.Text = "0";
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
                switch (aindex)
                {
                    case "1"://In
                        dgHoadon.Columns["Column_0"].ToolTipText ="Đánh dấu những mục cần in." + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString();
                        butInhoadon.Enabled = (m_dshoadon.Tables[0].Select("chon = 1").Length > 0 && m_id != "" && m_id != "0");
                        break;
                    case "6"://SL
                    case "7"://Dongia
                    case "9"://Mien
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

        private void txtMien_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_mon();
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

        private void cbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtQuan.Text = cbQuan.SelectedValue.ToString().Substring(3);
                f_Load_CB_Xa(txtTinh.Text+txtQuan.Text);
            }
            catch
            {
            }
            if (txtQuan.Text.Length > 2)
            {
                txtQuan.Text = "";
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

        private void txtQuan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == txtQuan)
                {
                    cbQuan.SelectedValue = (cbTinh.SelectedValue.ToString()+txtQuan.Text);
                }
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
                if(tmn_Hotkey_KSK_Show.Checked)
                {
                    foreach (DataRow r in m_frmchonvp.s_dshotkey_ksk.Tables[0].Select("hotkey='"+v_hotkey+"'"))
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
                    if (tmn_Hotkey_Addall.Checked && v_keycode != "" && (tmn_Hotkey_Show.Checked || tmn_Hotkey_KSK_Show.Checked))
                    {
                        f_Add_Chon(f_get_mavp_hotkey(v_keycode));
                    }
                    else
                    {
                        CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituong.DataSource]);
                        DataView dv = (DataView)(cm.List);
                        DataRow r = dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString())[0];
                        m_frmchonvp.s_field_gia = r["field_gia"].ToString();
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
                    MessageBox.Show(this,"Nhấn nút" + (m_id == "" ?"Mới" :"Sửa") +"Trước khi chọn viện phí!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
        
        private void butChon_Click(object sender, EventArgs e)
        {
            s_mavp_huy = "";
            f_Chon("");
        }

        private void toolStrip_Mien_Validated(object sender, EventArgs e)
        {
            try
            {
                string s_mien = toolStrip_Mien.Text.Trim();
                if (s_mien.IndexOf("%") > 0)
                {
                    decimal phantram = decimal.Parse(toolStrip_Tongcong.Text.Trim());
                    decimal mien = decimal.Parse(s_mien.Trim('%'));
                    decimal tongso = phantram * mien / 100;
                    toolStrip_Mien.Text = tongso.ToString();
                }
            }
            catch 
            {
                toolStrip_Mien.Text = ""; 
            }

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
                    dgHoadon.Columns["Column_0"].ToolTipText ="Đánh dấu những mục cần in." + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString();
                    toolTip1.SetToolTip(chkAll,"Đánh dấu những mục cần in." + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString());
                    butInhoadon.Enabled = (m_dshoadon.Tables[0].Select("chon = 1").Length > 0 && m_id != "" && m_id != "0");
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
                pHanhchanh.Height = v_bool?25:158;
            }
            catch
            {
            }
        }
        
        private void toolStrip_Title_Click(object sender, EventArgs e)
        {
            try
            {
                pHanhchanh.Height = (pHanhchanh.Height > 100)?25:158;
                m_v.set_o_fullscreen_frmthutructiep(m_userid, pHanhchanh.Height > 100 ? false : true);
                m_o_fullscreen = m_v.get_o_fullscreen_frmthutructiep(m_userid);
            }
            catch
            {
            }
        }

        private void txtNgaysinh_Validated(object sender, EventArgs e)
        {
            try
            {
                string atmp = m_v.tinhtuoi(txtNgaysinh.Text,300);
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
                    MessageBox.Show(this,"Hết sổ, đề nghị chọn sổ mới!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    cbLoaidv.Focus();
                    return;
                }
                else
                if (atmp.Split(':')[1] == "2")//Lỗi
                {
                    //MessageBox.Show(this,"Không tìm thấy quyển sổ thu viện phí!\nĐề nghị chọn sổ",ds_language.Tables[0].Select("ma='m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
               
                frmDanhsachchothutructiep m_frmdanhsachchothutructiep = new frmDanhsachchothutructiep(m_v, m_userid);
                m_frmdanhsachchothutructiep.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachchothutructiep.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachchothutructiep.s_mabn != "")
                    {
                        string atmp = m_frmdanhsachchothutructiep.s_mabn;
                        f_Moi();//binh 130511
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                        if (m_frmdanhsachchothutructiep.s_maql != "")
                        {
                            f_Load_CB_Ngayvv(m_frmdanhsachchothutructiep.s_ngaycd, m_frmdanhsachchothutructiep.s_maql);
                            if (btt_Thutungdonthuoc)
                            {
                                f_Load_Chidinh(m_frmdanhsachchothutructiep.s_ngaycd, m_frmdanhsachchothutructiep.s_maql, m_frmdanhsachchothutructiep.s_id, m_frmdanhsachchothutructiep.s_loai);
                            }
                            else
                            {
                                f_Load_Chidinh(m_frmdanhsachchothutructiep.s_ngaycd, m_frmdanhsachchothutructiep.s_maql);
                            }
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
                m_frmtimhoadon.s_ngay = txtNgaythu.Value;
                m_frmtimhoadon.s_loaihd = "1";
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
                frmDanhsachthutructiep m_frmdanhsachthutructiep = new frmDanhsachthutructiep(m_v, m_userid);
                m_frmdanhsachthutructiep.ShowInTaskbar = false;
                m_frmdanhsachthutructiep.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachthutructiep.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachthutructiep.s_id != "")
                    {
                        txtMabn.Enabled = false;
                        txtMabn1.Enabled = false;
                        m_id = m_frmdanhsachthutructiep.s_id;
                        f_Load_Hoadon(m_id, m_v.get_mmyy(m_frmdanhsachthutructiep.s_ngaythu));
                        
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
                cbBacsi.SelectedValue = arv["mabs"].ToString();
                txtTenvp.Text = arv["ten"].ToString();
                txtSoluong.Text = arv["soluong"].ToString();
                txtDongia.Text = arv["dongia"].ToString();
                txtMien.Text = arv["mien"].ToString();
              
                txtThucthu.Text = arv["thucthu"].ToString();
                txtSoluong_Validated(null, null);
                txtDongia_Validated(null, null);
                txtMien_Validated(null, null);
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
                if (tmn_Thuchidinh.Checked)
                {
                    if (cbNgayvv.Items.Count > 0 && tmn_Thuchidinh.Checked)
                    {
                        f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString());
                    }
                }
                else
                {
                    if (MessageBox.Show(this,"Tùy chọn thu theo chỉ định chưa được bật! \n Có muốn bật chế độ thu theo chỉ định của bác sĩ không?",m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (tmn_Thuchidinh.Enabled)
                        {
                            tmn_Thuchidinh.Checked = true;
                            if (cbNgayvv.Items.Count > 0 && tmn_Thuchidinh.Checked)
                            {
                                f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show(this,"Chưa được phân quyền sử dụng chức năng này! \n Liên hệ quản trị khi có nhu cầu!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
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
                    f_Add();
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
                tmn_Xoaall.Enabled = v_tt_suanoidunghoadon && m_dshoadon.Tables[0].Rows.Count > 0 && butLuu.Enabled;
                tmn_Xoacur.Enabled = v_tt_suanoidunghoadon && m_dshoadon.Tables[0].Rows.Count > 0 && butLuu.Enabled;
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
                dgHoadon.Columns["Column_0"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["ngaycd"].Frozen = !tmn_Fullgrid.Checked;
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
                m_v.set_o_fullgrid_frmthutructiep(m_userid, tmn_Fullgrid.Checked);
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
                m_v.set_o_show_hotkey_frmthutructiep(m_userid, tmn_Hotkey_Show.Checked);
                m_v.set_o_show_hotkey_ksk_frmthutructiep(m_userid, tmn_Hotkey_KSK_Show.Checked);
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
                m_v.set_o_show_hotkey_frmthutructiep(m_userid, tmn_Hotkey_Show.Checked);
                m_v.set_o_show_hotkey_ksk_frmthutructiep(m_userid, tmn_Hotkey_KSK_Show.Checked);
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
                m_v.set_o_show_hotkey_toolbar_frmthutructiep(m_userid, tmn_Show_Hotkey.Checked);
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
            m_v.set_o_luuin_hoadon_frmthutructiep(m_userid,tmn_Luuin_Hoadon.Checked);
        }
        
        private void tmn_Luuin_Hoadon_Icon_Click(object sender, EventArgs e)
        {
            tmn_luuvain.Checked = tmn_Luuin_Hoadon_Icon.Checked;
            tmn_luukhongin.Checked = !tmn_Luuin_Hoadon_Icon.Checked; 
            m_v.set_o_luuin_frmthutructiep(m_userid, tmn_Luuin_Hoadon_Icon.Checked);
        }

        private void tmn_Xemtruockhiin_Icon_Click(object sender, EventArgs e)
        {
            tmn_xemtruockhiin.Checked = tmn_Xemtruockhiin_Icon.Checked;
            m_v.set_o_xemtruockhiin_frmthutructiep(m_userid, tmn_Xemtruockhiin_Icon.Checked);
        }
        
        private void tmn_Luuin_Chiphi_Click(object sender, EventArgs e)
        {
            if (tmn_Luuin_Chiphi.Checked) tmn_Luuin_Chiphi_cadot.Checked = false;
            m_v.set_o_luuin_chiphi_frmthutructiep(m_userid,tmn_Luuin_Chiphi.Checked);
            m_v.set_o_luuin_chiphi_cadot_frmthutructiep(m_userid, tmn_Luuin_Chiphi_cadot.Checked);            
        }

        private void tmn_Nhapbacsi_Click(object sender, EventArgs e)
        {
            m_v.set_tt_nhapbacsi(m_userid,tmn_Nhapbacsi.Checked);
        }

        private void tmn_Nhapkhoaphong_Click(object sender, EventArgs e)
        {
            m_v.set_tt_nhapkhoaphong(m_userid, tmn_Nhapkhoaphong.Checked);
        }

        private void tmn_Nhaplydomien_Click(object sender, EventArgs e)
        {
            m_v.set_tt_nhaplydomien(m_userid,tmn_Nhaplydomien.Checked);
        }

        private void tmn_Nhapkymien_Click(object sender, EventArgs e)
        {
            m_v.set_tt_nhapduyetmien(m_userid, tmn_Nhapkymien.Checked);
        }

        private void tmn_Thuchidinh_Click(object sender, EventArgs e)
        {
            m_v.set_tt_thuchidinh(m_userid, tmn_Thuchidinh.Checked);
        }

        private void tmn_Toathuoctutruc_Click(object sender, EventArgs e)
        {
            m_v.set_tt_thutoatutruc(m_userid, tmn_Toathuoctutruc.Checked);
        }

        private void tmn_Hotkey_Addall_Click(object sender, EventArgs e)
        {
            m_v.set_o_addall_hotkey_frmthutructiep(m_userid, tmn_Hotkey_Addall.Checked);
        }

        private void tmn_Show_Hotkey_Click(object sender, EventArgs e)
        {
            m_v.set_o_show_hotkey_toolbar_frmthutructiep(m_userid, tmn_Show_Hotkey.Checked);
            f_Load_Hotkey();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int aval = chkAll.Checked ? 1 : 0;
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    r["chon"] = aval;
                }
                dgHoadon.Update();
                dgHoadon.Columns["Column_0"].ToolTipText ="Đánh dấu những mục cần in." + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString();
                toolTip1.SetToolTip(chkAll,"Đánh dấu những mục cần in." + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString());
                butInhoadon.Enabled = (m_dshoadon.Tables[0].Select("chon = 1").Length > 0 && m_id != "" && m_id != "0");
            }
            catch
            {
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m_frmchonvp.Dispose();
            //m_frmdanhsachthutructiep.Dispose();
            //m_frmdanhsachchothutructiep.Dispose();
            //m_frmtimhoadon.Dispose();
            //m_frmtimbenhnhan.Dispose();
            //m_frmhoantra.Dispose();
            m_frmprinthd.Dispose();
            m_v.Disconnect();
            System.GC.Collect();
            this.Close();
        }

        private void frmThutructiep_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this,"Đồng ý kết thúc chức năng thu trực tiếp!",m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
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

     
        private void txtmapk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtmapk_Validated(object sender, EventArgs e)
        {
            cbotenpk.SelectedValue = txtmapk.Text;
        }

        private void cbotenpk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                if (txtSothe.Text=="" && txtSothe.Enabled)
                {
                    txtSothe.Focus();
                }
                else 
                {
                    txtTenvp.Focus();
                }
                          
            }
        }

        private void cbotenpk_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtmapk.Text = cbotenpk.SelectedValue.ToString();
            }
            catch
            {
                txtmapk.Text = "00";
            }
        }

        private void tmn_thuvienphikhoa_Click(object sender, EventArgs e)
        {
            m_v.set_tt_thuvienphikhoa(m_userid, tmn_thuvienphikhoa.Checked);
        }

    
        private void tmn_thutheonhomvp_Click(object sender, EventArgs e)
        {
            m_v.set_tt_thutheonhom(m_userid, tmn_thutheonhomvp.Checked);
        }

        private void tmn_thutheoloaivp_Click(object sender, EventArgs e)
        {
            m_v.set_tt_thutheoloai(m_userid, tmn_thutheoloaivp.Checked);
        }

        private void txtmapk_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == txtmapk)
                {
                    cbotenpk.SelectedValue = txtmapk.Text;
                }
            }
            catch
            {}
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

        private void madantoc_KeyDown(object sender, KeyEventArgs e)
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
        private void ena_nuoc(bool ena)
        {
            manuoc.Enabled = ena;
            tennuoc.Enabled = ena;
        }
        private void tendantoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tendantoc.SelectedIndex == -1) tendantoc.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
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

        private void tennuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tennuoc.SelectedIndex == -1) tennuoc.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tennuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                manuoc.Text = tennuoc.SelectedValue.ToString();
            }
            catch { manuoc.Text = ""; }
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

        private void txtNgaythu_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ToolStripMenuItem_Nhom_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Nhom.Checked = !ToolStripMenuItem_Nhom.Checked;
            m_v.set_tt_Intheonhom(m_userid, ToolStripMenuItem_Nhom.Checked);
        }

        private void butOptionIn_Click(object sender, EventArgs e)
        {
            context_IN.Show(butOptionIn, new Point(butOptionIn.ClientRectangle.Left + butOptionIn.Width, butOptionIn.ClientRectangle.Bottom - context_IN.Items.Count * 20 - 24));
        }

        private void ToolStripMenuItem_Loai_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Loai.Checked = !ToolStripMenuItem_Loai.Checked;
            m_v.set_tt_Intheoloai(m_userid, ToolStripMenuItem_Loai.Checked);
        }

        private void ToolStripMenuItem_Chitiet_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Chitiet.Checked = !ToolStripMenuItem_Chitiet.Checked;
            m_v.set_tt_InchitietHD(m_userid, ToolStripMenuItem_Chitiet.Checked);
        }

        private void ToolStripMenuItem_Dacthu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Dacthu.Checked = !ToolStripMenuItem_Dacthu.Checked;
            m_v.set_tt_InHDdacthu(m_userid, ToolStripMenuItem_Dacthu.Checked);
        }

        private void ToolStripMenuItem_thuong_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_thuong.Checked = !ToolStripMenuItem_thuong.Checked;
            m_v.set_tt_InHD_thuong(m_userid, ToolStripMenuItem_thuong.Checked);
        }

        private void txtTylemien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (tmn_Nhapkhoaphong.Checked)
                    {
                        cbKhoa.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                        if (tmn_Nhapbacsi.Checked)
                        {
                            cbBacsi.Focus();
                            SendKeys.Send("{F4}");
                        }
                        else
                        {
                            butAdd.Focus();
                        }
                }
            }
            catch
            {
            }
        }

        private void txtTylemien_Validated(object sender, EventArgs e)
        {
            try
            {
                string s_mien = txtTylemien.Text.Trim();
                if (s_mien.IndexOf("%") > 0)
                {
                    int soluong = int.Parse(txtSoluong.Text);
                    double dongia = double.Parse(txtDongia.Text);
                    double mien = double.Parse(s_mien.Substring(0, s_mien.Length - 1)) / 100;
                    txtMien.Text = (soluong * dongia * mien).ToString();
                }
            }
            catch { txtMien.Text = ""; }

            f_Tinhtien_mon();
        }

        private void txtTylemien_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTylemien)
            {
                if (txtTylemien.Text.Trim().Length == 1)
                {
                    string s_add = txtTylemien.Text.Trim() == "5" ? "0%" : "5%";
                    txtTylemien.Text = txtTylemien.Text.Trim() + s_add;
                    txtTylemien.SelectionStart = 1;
                    txtTylemien.SelectionLength = txtTylemien.Text.Length - 1;
                }
                else if (txtTylemien.Text.Trim().Length == 2)
                {
                    txtTylemien.Text = txtTylemien.Text.Trim() + "%";
                    txtTylemien.SelectionStart = 2;
                    txtTylemien.SelectionLength = txtTylemien.Text.Length - 2;
                }
            }
        }

  
        private void cbKyhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string atmp = f_Get_Sobienlai();
                txtSobienlai.Text = atmp.Split(':')[0];
                if (atmp.Split(':')[1] == "1")//Hết số
                {
                    MessageBox.Show(this,"Hết sổ, đề nghị chọn sổ mới!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaidv.Enabled = false;
                    cbLoaidv.Focus();
                    return;
                }
                else
                    if (atmp.Split(':')[1] == "2")//Lỗi
                    {
                        //MessageBox.Show(this,"Không tìm thấy quyển sổ thu viện phí!\nĐề nghị chọn sổ",ds_language.Tables[0].Select("ma='m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch
            {
            }
        }

        private void toolStrip_Mien_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl ==this.toolStrip_Mien.Control) 
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

        private void Clock_Tick(object sender, EventArgs e)
        {
            if (sender == Clock)
            {
                try
                {
                    m_v.get_tinnhan(System.Environment.MachineName, "vienphi");
                }
                catch { }
            }
        }

        private bool bDichvu_dathuchien(string aid, string mmyy)
        {
            string xxx = m_v.user + mmyy;
            sql = "select * from " + xxx + ".v_chidinh where done =1 and idttrv=" + aid;
            DataSet lds = m_v.get_data(sql);
            return lds.Tables[0].Rows.Count > 0;
        }

        private void label29_Click(object sender, EventArgs e)
        {
            //txtNgaythu.Enabled = !txtNgaythu.Enabled;
        }

     
        private bool bBienlai_dasudung(string iQuyenso, string iSobienlai)
        {
            string suser = m_v.user;
            string asql = "select * from " + suser + ".vv_bienlaithuvienphi_" + m_v.get_dmcomputer().ToString().PadLeft(4, '0') + " where quyenso=" + iQuyenso + " and sobienlai=" + iSobienlai;
            DataSet lds = m_v.get_data(asql);
            return lds.Tables[0].Rows.Count > 0;
        }

        private void tmn_luukhongin_Click(object sender, EventArgs e)
        {
            tmn_Luuin_Hoadon_Icon.Checked = !tmn_luukhongin.Checked;
            tmn_luuvain.Checked = !tmn_luukhongin.Checked;
            m_v.set_o_luuin_frmthutructiep(m_userid, !tmn_luukhongin.Checked);
        }

        private void tmn_luuvain_Click(object sender, EventArgs e)
        {
            tmn_Luuin_Hoadon_Icon.Checked = tmn_luuvain.Checked;
            tmn_luukhongin.Checked = !tmn_luuvain.Checked;
            m_v.set_o_luuin_frmthutructiep(m_userid, tmn_luuvain.Checked);
        }

        private void tmn_xemtruockhiin_Click(object sender, EventArgs e)
        {
            tmn_Xemtruockhiin_Icon.Checked = tmn_xemtruockhiin.Checked;
            m_v.set_o_xemtruockhiin_frmthutructiep(m_userid, tmn_xemtruockhiin.Checked);
        }

        private void chkKhuyenMai_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkKhuyenMai.Checked && m_v.sys_cokhuyenmai_tt)
            {
               
                if (m_v.get_data("select a.idvp from medibv.v_giavp_khuyenmai a inner join medibv.v_dot_khuyenmai b on a.iddot=b.id where b.hide=0 and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy') >= b.tungay and to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')<= b.denngay").Tables[0].Rows.Count > 0)
                {
                    string qt = MessageBox.Show("Còn đợt khuyến mãi !\nBạn có muốn không tính khuyến mãi không ?", "Thông báo", MessageBoxButtons.YesNo).ToString();
                    if (qt == "No")
                    {
                        chkKhuyenMai.Checked = true;
                    }
                }

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            bAll_days = true;
            cbNgayvv_SelectedIndexChanged(null,null);
        }

        private void tmn_Luuin_Chiphi_cadot_Click(object sender, EventArgs e)
        {
            if (tmn_Luuin_Chiphi_cadot.Checked) tmn_Luuin_Chiphi.Checked = false;
            m_v.set_o_luuin_chiphi_cadot_frmthutructiep(m_userid, tmn_Luuin_Chiphi_cadot.Checked);
            m_v.set_o_luuin_chiphi_frmthutructiep(m_userid, tmn_Luuin_Chiphi.Checked);            
        }

        

        private void mnu_xuatLCD_Click(object sender, EventArgs e)
        {
            this.m_v.writeXml("v_thongso", "ttlcd", this.mnu_LCD.Checked ? "1" : "0");
        }

        private void mnu_thongsoLCD_Click(object sender, EventArgs e)
        {
            new frmThongsoLCD(this.m_v).ShowDialog();
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
                        this.fgoi.sets = this.sizestt;
                        this.fgoi.s_sohienthi = "Số tiền: " + v_sotien;
                        this.fgoi.set_size_hoten = 40;
                        this.fgoi.s_hotenbn = v_hoten + " [" + v_mabn + "]";
                        this.fgoi.s_sotien_bn_dua = "BN Đưa:" + v_sotien_bndua;
                        this.fgoi.s_sotien_thoilai = "Thối lại:" + v_thoilai;
                        this.fgoi.Update();
                        this.fgoi.Refresh();
                        this.fgoi.Show();
                    }
                    else
                    {
                        this.fgoi.sets = this.sizestt;
                        this.fgoi.s_sohienthi = "Số tiền: " + v_sotien;
                        this.fgoi.set_size_hoten = 40;
                        this.fgoi.s_hotenbn = v_hoten + " [" + v_mabn + "]";
                        this.fgoi.s_sotien_bn_dua = "BN Đưa:" + v_sotien_bndua;
                        this.fgoi.s_sotien_thoilai = "Thối lại:" + v_thoilai;
                        this.fgoi.Update();
                        this.fgoi.Refresh();
                        //this.fgoi.Show();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
}