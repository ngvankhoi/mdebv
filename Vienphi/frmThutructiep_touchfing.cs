using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmThutructiep_touchfing : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_cur_yy = "";
        private string m_makp_khongkham = "", s_loaibn = "";
        private DateTime m_cur_ngay = DateTime.Now;
        private string m_cur_loaidv = "";
        private string m_cur_quyenso = "";

        private int iTreem6, iTreem15;

        private LibVP.AccessData m_v;             

        private DataSet m_dshoadon;

        private string m_doituongmien = "", s_mavp_huy = "";
        private string aidchidinh = "", v_solanin = "",v_NamBTDBN;
        private string m_id = "", m_mavaovien = "", m_maql = "", m_userid = "", s_madoituongthu = "", s_loaibnthu = "", s_loaibn_mien = "", s_tutructhutheokhoa = "";
        private DataSet m_dsgiavp;
        private DataSet m_dsloaivp;
        private DataSet m_dsdoituong;

        private frmChonvp m_frmchonvp;
        private frmDanhsachthutructiep m_frmdanhsachthutructiep;
        private frmDanhsachchothutien_touchfing m_frmdanhsachchothutien_touch;
        private frmTimhoadon m_frmtimhoadon;
        private frmTimbenhnhan m_frmtimbenhnhan;
        private frmHoantra m_frmhoantra;
        private frmPrintHD m_frmprinthd;

        //var
        private bool m_bnmoi = false;
        private bool m_mabntudong = false,m_Docmavach,v_chuyenchidinhCLS,v_chuakhaigiavp,v_Giamchitiet,v_nhapmienchitiet,v_miendt_loai;
        private bool bDoctinnhan_Sound = false, bLuu_In = false, bPreview = false;
        //option
        private bool m_o_fullscreen = false;
        private int itablell, itablect, itablemien;

        public frmThutructiep_touchfing(LibVP.AccessData v_v, string v_userid)
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
        private void frmThutructiep_touchfing_Load(object sender, EventArgs e)
        {
            try
            {                        
                itablell = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_vienphill");
                itablect = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_vienphict");
                itablemien = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_mienngtru");
                
                if (bDoctinnhan_Sound)                
                {
                    //Clock = new Timer();
                    Clock.Interval = m_v.delay_tinnhan;
                    Clock.Start();
                    Clock.Tick += new EventHandler(Clock_Tick);
                }

                f_Load_Thutrongngay();
                f_Enable(false);
                bLuu_In = m_v.get_o_luuin_hoadon_frmthutructiep(m_userid);
                bPreview = m_v.get_o_xemtruockhiin_frmthutructiep(m_userid);
               
                this.Refresh();
                butBoqua_Click(null, null);
                //
                string tmp_qso = m_cur_quyenso;
                lbKyhieu_Click(null, null);
                s_quyenso = tmp_qso;
                if (m_Docmavach)
                {
                    txtMabn.MaxLength = 8;
                    txtMabn1.MaxLength = 8;
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
                butMoi_Click(null, null);                              
            }
            catch
            {
            }
        }
        private void f_Display()
        {
            try
            {
                cbKyhieu.DropDownWidth = txtSobienlai.Right - cbKyhieu.Left;
                pButton.Location = new Point(1 + (this.Width - 950) / 2, 1);
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
                m_makp_khongkham = m_v.sys_makp_khongkham;
                v_solanin = m_v.sys_solanin;

                m_Docmavach = m_v.tt_Quanlymavach(m_userid);
                v_chuyenchidinhCLS = m_v.tt_ChuyenCLSChuaquaChidinh(m_userid);
                v_Giamchitiet = m_v.tt_Nhapmiengianchitiet(m_userid);
                v_nhapmienchitiet = m_v.tt_Nhapmientheotungmon(m_userid);
                v_miendt_loai = m_v.tt_Miendt_loai(m_userid);
                bool asys_suatuychon = m_v.sys_quyen_suatuychon(m_userid);

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

                ToolStripMenuItem_Loai.Checked = m_v.tt_Intheoloai(m_userid);
                ToolStripMenuItem_Nhom.Checked = m_v.tt_Intheonhom(m_userid);
                ToolStripMenuItem_Chitiet.Checked = m_v.tt_InchitietHD(m_userid);
                ToolStripMenuItem_Dacthu.Checked = m_v.tt_InHDdacthu(m_userid);
                ToolStripMenuItem_thuong.Checked = m_v.tt_InHD_thuong(m_userid);

                string sql = "";
                string atmp = m_v.s_curmmyyyy;
                DataSet ads;
                DataRow r;
                m_cur_ngay = m_v.f_parse_date(atmp);
                m_cur_yy = m_cur_ngay.Year.ToString().Substring(2);

                ads = m_v.get_data("select makp,tenkp from medibv.btdkp_bv order by loai, tenkp");
                r = ads.Tables[0].NewRow();
                r["makp"] = "00";
                r["tenkp"] = "";
                ads.Tables[0].Rows.InsertAt(r, 0);

                ads = m_v.get_data("select ma,hoten from medibv.dmbs order by hoten");
                r = ads.Tables[0].NewRow();
                r["ma"] = "0000";
                r["hoten"] = "";
                ads.Tables[0].Rows.InsertAt(r, 0);
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

                cbLoaidv.DataSource = m_v.get_data("select ma,ten from medibv.v_tenloaivp order by ma").Tables[0];
                cbLoaidv.DisplayMember = "ten";
                cbLoaidv.ValueMember = "ma";
                
                sql = "select id,sohieu,loai,userid,* from medibv.v_quyenso";
                sql += " where userid = " + m_userid;
                sql += " order by ngayud desc";
                cbKyhieu.DataSource = m_v.get_data(sql).Tables[0];
                cbKyhieu.DisplayMember = "sohieu";
                cbKyhieu.ValueMember = "id";

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

                cbTinh.DataSource = m_v.get_data("select matt,tentt from medibv.btdtt order by tentt").Tables[0];
                cbTinh.DisplayMember = "tentt";
                cbTinh.ValueMember = "matt";

                tennn.DisplayMember = "TENNN";
                tennn.ValueMember = "MANN";
                load_btdnn(0);	
                
                cbGioitinh.DataSource = m_v.get_data("select ma,ten from medibv.dmphai order by ma desc").Tables[0];
                cbGioitinh.DisplayMember = "ten";
                cbGioitinh.ValueMember = "ma";

                cbTuoi.DataSource = m_v.f_get_dmtuoi().Tables[0];
                cbTuoi.DisplayMember = "ten";
                cbTuoi.ValueMember = "id";

                cbLoaibn.DataSource = m_v.get_data("select id,ten from medibv.v_loaibn order by id").Tables[0];
                cbLoaibn.DisplayMember = "ten";
                cbLoaibn.ValueMember = "id";

                m_dsgiavp = m_v.get_data("select * from medibv.v_giavp a,medibv.v_loaivp b where a.hide=0 and a.id_loai=b.id order by a.id_loai, a.ten");
                m_dsloaivp = m_v.get_data("select id,stt,ten,viettat,id_nhom,to_number(0,'9') as sotien from medibv.v_loaivp order by stt, ten");

                sql = "select 0 as id, 0 as chon,'' as ngaycd, 0 as mavp, '' as ma,'' as ten,'' as dvt,0 as soluong, 0 as dongia, 0 as thanhtien, 0 as mien,0 as thucthu,0 as madoituong,'' as doituong,'' as makp, '' as tenkp, '' as mabs,'' as tenbs, 0 as idcd,0 as id_loai";
                m_dshoadon = m_v.get_data(sql);
                m_dshoadon.Tables[0].Rows.Clear();
                
                dgHoadon.DataSource = m_dshoadon.Tables[0];

                sql = "select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs,a.gia_ksk, trim(b.ten) as tenloai,b.id as id_loai, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id where a.hide=0 order by b.ten,b.stt, b.id, a.ten,a.stt";
                m_frmchonvp = new frmChonvp(m_v, m_userid,"GIA_TH", m_v.get_data(sql),m_v.s_loaiform_thutructiep);
             
                m_frmchonvp.s_multiline = m_v.get_o_multiline_frmchonvp(m_userid);
                m_frmchonvp.s_dshotkey = m_v.f_get_hotkey_frmthutructiep(m_userid);
                
                m_frmchonvp.s_dshotkey_ksk = m_v.f_get_hotkey_ksk_frmthutructiep(m_userid);
                m_frmchonvp.s_hotkey = "";
                m_frmchonvp.ShowInTaskbar = false;

                m_frmdanhsachthutructiep = new frmDanhsachthutructiep(m_v, m_userid);
                m_frmdanhsachthutructiep.ShowInTaskbar = false;

                m_frmdanhsachchothutien_touch = new frmDanhsachchothutien_touchfing(m_v, m_userid);
                m_frmdanhsachchothutien_touch.ShowInTaskbar = false;
                
                m_frmtimbenhnhan = new frmTimbenhnhan(m_v, m_userid);
                m_frmtimbenhnhan.ShowInTaskbar = false;
                
                m_frmtimhoadon = new frmTimhoadon(m_v, m_userid);
                m_frmtimhoadon.ShowInTaskbar = false;
                m_frmtimhoadon.s_loaihd = "1";

                m_frmhoantra = new frmHoantra(m_v, m_userid);
                m_frmhoantra.ShowInTaskbar = false;
                m_frmhoantra.s_loaihd = "1";

                m_frmprinthd = new frmPrintHD(m_v,m_userid);

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmthutructiep(m_userid);
                f_Set_Fullgrid();
                f_Display();
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
                    txtHoten.Text = r["hoten"].ToString();
                    txtNgaysinh.Text = r["ngaysinh"].ToString();
                    if (txtNgaysinh.Text.Trim() == "null" || txtNgaysinh.Text.Trim()=="")
                    {
                        txtNgaysinh.Text = r["namsinh"].ToString();
                    }
                    cbGioitinh.SelectedValue = r["phai"].ToString();
                    txtThonpho.Text = (r["sonha"].ToString() + " - " + r["thon"].ToString().Trim()).Trim().Trim('-');
                    tennn.SelectedValue = r["mann"].ToString();
                    mann.Text = r["mann"].ToString();
                    madantoc.Text = r["madantoc"].ToString();
                    v_NamBTDBN = r["nam"].ToString();
                    f_Load_T_Q_X(r["maphuongxa"].ToString());
                    if (manuoc.Enabled == false)
                        foreach (DataRow r1 in m_v.get_data("select id_nuoc from medibv.nuocngoai where mabn='" + v_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue = r1["id_nuoc"].ToString();                   
                    if (m_id == "")
                    {
                        f_Load_CB_Ngayvv("", "");
                    }
                    else
                    {
                        f_Load_CB_Ngayvv(txtNgaythu.Text.Substring(0, 10), m_maql);
                    }
                    txtNgaysinh_Validated(null, null);
                    m_bnmoi = false;
                    aok = true;
                    break;
                }
                if (m_id == "" || m_id == "0")
                {
                    if (cbNgayvv.Items.Count <= 0)
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

                txtHoten.Text = "";
                txtNgaysinh.Text = "";
                txtTuoi.Text = "";
                txtThonpho.Text = "";
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
                try
                {
                    cbDoituongTD.SelectedValue = 2;
                }
                catch
                {
                }
                lMien.Text = "0";
                lThucthu.Text = "0";
                lTongchiphi.Text = "0";
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

                txtHoten.ReadOnly = !v_bool;
                txtNgaysinh.ReadOnly = !v_bool;
                txtTuoi.ReadOnly = !v_bool;
                cbTuoi.Enabled = v_bool;
                cbGioitinh.Enabled = v_bool;
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
                dgHoadon.Columns[6].ReadOnly = !butLuu.Enabled;
                dgHoadon.Columns[7].ReadOnly = !butLuu.Enabled;
                dgHoadon.Columns[9].ReadOnly = !butLuu.Enabled;
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
                butXoa.Enabled = !v_bool && m_id != "" && m_id != "0";
                butBoqua.Enabled = true;
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
                    MessageBox.Show(this,"Phải khai báo quyển sổ thu viện phí trước!\n Vào [Tiện ích] - [Khai báo quyển sổ] để khai!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                    return;
                }

                f_FullScreen(m_o_fullscreen);
                m_bnmoi = true;
                m_mabntudong = m_v.tt_mabntudong(m_userid);
                m_id = "";
                v_NamBTDBN = "";
                m_mavaovien = "";
                m_maql = "";
                s_mavp_huy = "";
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
                    MessageBox.Show(this,"Không tìm thấy quyển sổ thu viện phí! \n Đề nghị chọn sổ",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtMabn.Text = m_cur_yy;
                txtMabn1.Text = "";
                dgHoadon.Columns["Column_0"].ToolTipText ="Đánh dấu những mục cần in.";
                txtmapk.Text = m_makp_khongkham;
                cbotenpk.SelectedValue = m_makp_khongkham;
                txtMabn.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Luu()
        {
            try
            {
                bool asua = (m_id != "" && m_id != "0");
                
                string atmp = "", aidcd = "", amakp_ll = "01", amakp_td = "";
                butLuu.Enabled = false;
        
                
                if (m_dshoadon.Tables[0].Rows.Count <= 0)
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Đề nghị nhập nội dung thu viện phí!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "", amaql = "", aidkhoa = "", amakp = "", ahoten = "", anamsinh = "", adiachi = "", aloai = "", aloaibn = "", auserid = "",aphai="";
                angay = txtNgaythu.Text.Substring(0, 16);
                ammyy = m_v.get_mmyy(angay);
                aid=m_id;
                aid = m_id == "" ? "0" : decimal.Parse(m_id).ToString();
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
                if (amabn.Length != 8)
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
                if (amaql == "" || amaql=="0")
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
                aid = m_v.upd_v_vienphill(ammyy, decimal.Parse(aid), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), amakp_ll, ahoten, anamsinh, adiachi, decimal.Parse(aloai), decimal.Parse(aloaibn), decimal.Parse(auserid), decimal.Parse(aphai), "", "", 0,0,0,"");
                m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                if (aid != "0")
                {
                    decimal astt=1;
                    //string v_aid = "";
                    string atn = "";
                    try
                    {
                        atn = cbNgayvv.Text.Substring(0, 10);
                    }
                    catch
                    {
                        atn = angay.Substring(0, 10);
                    }
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            m_v.upd_v_vienphict("v_vienphict", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
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
                            if (r["makp"].ToString().Trim() != "")
                            {
                                if(amakp_td!="") amakp_td += ",";
                                amakp_td += "'"+ r["makp"].ToString()+"'";
                            }
                        }
                        catch
                        {
                        }
                    }
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
                    sql = "update medibvmmyy.v_chidinh set paid = 1 where mabn='" + amabn + "' and  id in(" + aidcd + ")";
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    sql = "update medibvmmyy.d_tienthuoc set done=1,idttrv=" + aid + " where mabn='" + amabn + "' and id in(" + aidcd + ")";
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
                }
                if (amakp_td != "")
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
                    sql = "update medibvmmyy.tiepdon set done=null where maql="+amaql+" and makp in(" + amakp_td + ")";
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
                    if (bLuu_In)
                    {
                        if (asua)
                        {
                            if (MessageBox.Show(this, "Thông tin thay đổi đã được cập nhật! \n Có muốn in lại hoá đơn vừa sửa không?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                f_Inhoadon();
                            }
                        }
                        else
                        {
                            f_Inhoadon();
                        }
                    }
                    butMoi.Focus();
                }
            }
            catch
            {
               
            }
        }
        private void f_Sua()
        {
            try
            {
                if (m_v.tt_suahoadon(m_userid))
                {
                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), s_loaibn))
                    {
                        MessageBox.Show(this,"Hoá đơn đã hoàn trả, không cho phép sửa. \n Liên hệ quản trị khi có nhu cầu!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        f_Enable(true);
                        f_Enable_HC(false);
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

                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), s_loaibn))
                    {
                       // MessageBox.Show(this,"Hoá đơn đã hoàn trả, không cho phép sửa. \n Liên hệ quản trị khi có nhu cầu!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        MessageBox.Show(this,"Hoá đơn này đã làm biên lai hoàn trả. Không thể Xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                }
                            }
                            #endregion//end

                            if (MessageBox.Show(this,"Xóa hoá đơn này có trong báo cáo không?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                m_v.upd_huybienlai(ammyy, decimal.Parse(m_id), "v_vienphill", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text.Trim(), cbotenpk.SelectedValue.ToString(), cbNgayvv.Text.Substring(0, 16).ToString(), decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text), "Hủy biên lai thu trực tiếp", int.Parse(m_userid), 0);
                            }
                            else
                            {
                                m_v.upd_huybienlai(ammyy, decimal.Parse(m_id), "v_vienphill", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text.Trim(), cbotenpk.SelectedValue.ToString(), cbNgayvv.Text.Substring(0, 16).ToString(), decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text), "Hủy biên lai thu trực tiếp", int.Parse(m_userid), 0);
                            }
                            m_v.execute_data_mmyy(ammyy, "update medibvmmyy.d_tienthuoc set done=0,idttrv=0 where to_char(idttrv)='" + m_id + "'");//thuoc tu truc
                            m_v.del_v_vienphill_new(ammyy, m_id, m_maql, txtmapk.Text, txtMabn.Text + txtMabn1.Text);
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
        private void f_Inhoadon()
        {
            try
            {
                if (m_id != "")
                {
                    string s = m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "select lanin from medibvmmyy.v_vienphill where id=" + m_id + "").Tables[0].Rows[0]["lanin"].ToString();
                    if (decimal.Parse(v_solanin) > decimal.Parse(s))
                    {
                        if (m_v.tt_Intheoloai(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Loai(!bPreview, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
                        }
                        if (m_v.tt_Intheonhom(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Nhom(!bPreview, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
                        }
                        if (m_v.tt_InchitietHD(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_chitiet(!bPreview, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)));
                        }
                        if (m_v.tt_InHDdacthu(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB(!bPreview, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1","");
                        }
                        if (m_v.tt_InHD_thuong(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Thuong(!bPreview, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", "", "","");
                        }
                        if(!m_v.tt_Intheoloai(m_userid) && !m_v.tt_Intheonhom(m_userid) && !m_v.tt_InchitietHD(m_userid) && !m_v.tt_InHDdacthu(m_userid) && !m_v.tt_InHD_thuong(m_userid))
                        {
                            m_frmprinthd.f_Print_BienlaiKB_Thuong(!bPreview, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1", "", "","");
                        }
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
                m_frmprinthd.f_Print_ChiphiKBCT(true, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)));
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
        
        private string f_Get_Sobienlai()
        {
            try
            {
                string art = "0:2";
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" + cbKyhieu.SelectedValue.ToString()).Tables[0].Rows)
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
        
        private void f_Rem()
        {
            try
            {
                try
                {
                    if (decimal.Parse(m_dshoadon.Tables[0].Rows[dgHoadon.CurrentCell.RowIndex]["mien"].ToString()) == decimal.Parse(lMien.Text))
                    {
                        lMien.Text = "0";
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
        
        private void f_Tinhtien()
        {
            try
            {
                decimal adongia = 0, asoluong = 0, amien = 0, athucthu = 0, atongcong = 0, atongmien = 0, atongthu = 0, amientong = 0;             
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
                        amien = adongia * asoluong * f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                        if (v_nhapmienchitiet && amien == 0) 
                        {
                            amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));
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
                    athucthu = asoluong * adongia - amien;
                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["mien"] = amien;
                    
                    r["thanhtien"] = asoluong*adongia;
                    r["thucthu"] = athucthu;

                    atongcong += (asoluong * adongia);
                    atongmien += amien;
                  
                }
                //ket thuc foreach
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
                    lMien.Text = aTongtiengiam.ToString("###,###,##0.##");
                }
                
                try
                {                  
                    amientong = decimal.Parse(lMien.Text.Trim().Replace(",", ""));
                }
                catch
                {
                    amientong = 0;
                }
                if (atongmien <= 0 && amientong > 0)
                {
                    atongmien = amientong;
                }
                if (atongmien > atongcong)
                {
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
                        athucthu = asoluong * adongia - amien;

                        r1["soluong"] = asoluong;
                        r1["dongia"] = adongia;
                        r1["mien"] = amien;
                       
                        r1["thanhtien"] = asoluong * adongia;
                        r1["thucthu"] = athucthu;
                    }
                }
                m_dshoadon.AcceptChanges();
                atongthu = atongcong - atongmien;
                lTongchiphi.Text = atongcong.ToString("###,###,##0.##").Trim();
                lMien.Text = atongmien.ToString("###,###,##0.##").Trim();
                lThucthu.Text = atongthu.ToString("###,###,##0.##").Trim();
                toolStrip_Somuc.Text = m_dshoadon.Tables[0].Rows.Count.ToString() + " " +"mục";
            }
            catch
            {
                lTongchiphi.Text = "0";
                lMien.Text = "0";
                lThucthu.Text = "0";
                toolStrip_Somuc.Text = "0 " +"mục";
            }
        }
        private decimal f_Get_Tyle_BHYT(string v_madoituong, string v_mavp)
        {
            decimal atyle = 0;
            try
            {
                if (m_doituongmien.IndexOf("," + v_madoituong + ",") >= 0)
                {
                    if (v_madoituong == "3")
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
                sql = "select sum(b.soluong*b.dongia-b.thieu) as sotien from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id where  b1.id is null and a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
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
            }
            catch
            {
            }
        }
        private void f_Load_Hoadon(string v_id, string v_mmyy)
        {
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
                sql = "select a.mabn,a.mavaovien,a.maql,b2.sotien as tongmien,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.quyenso,a.sobienlai,a.loai,a.loaibn,a.id, case when b.lanin <> 0 then 1 else 0 end as chon, b.mavp, c.ma,c.ten,c.dvt,b.soluong,b.dongia,b.soluong*b.dongia as thanhtien, b.mien,b.soluong*b.dongia-b.mien as thucthu,b.madoituong,d.doituong,b.makp, e.tenkp, b.mabs,f.hoten as tenbs, 0 as idcd,a.ghichu,bacsi,c.id_loai,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,c.id_loai,0 as id_nhom,a.done,idchidinh";
                sql+=" from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru b2 on a.id=b2.id left join (select id,ma,ten,dvt,id_loai from medibv.v_giavp union select d0.id,d0.ma,d0.ten, d0.dang  as dvt,to_number('0') as id_loai from medibv.d_dmbd d0 inner join medibv.d_dmnhom d1 on d0.manhom=d1.id where d1.nhom=1) c on b.mavp=c.id left join medibv.doituong d on b.madoituong=d.madoituong left join medibv.btdkp_bv e on b.makp=e.makp left join medibv.dmbs f on b.mabs=f.ma where b1.id is null and a.id = " + v_id;
               
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
                    txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    txtNgaythu.Value = m_v.f_parse_date(ads.Tables[0].Rows[0]["ngay"].ToString());

                    try
                    {
                        lMien.Text = decimal.Parse(ads.Tables[0].Rows[0]["tongmien"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        lMien.Text = "0";
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
                string sql = "", ammyy = "", asobienlai="",aexp="",aid="";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                aexp = " a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
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
                sql = "select a.id from medibvmmyy.v_vienphill a left join medibvmmyy.v_trongoi b on a.id=b.id where b.id is null and " + aexp;
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
                string sql = "", aexp = "";
                DataSet ads = null, ads1 = null;
                
                //Chi dinh
                if (m_v.tt_thuchidinh(m_userid))
                {
                    aexp = " where a.paid=0 and a.maql = " + v_maql;
                    if (s_madoituongthu != "")
                    {
                        aexp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        aexp += " and a.mavp not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, e.mabs,f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom";
                    if (m_v.sys_khuyenmai)
                    {
                        sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                    }
                    else 
                    {
                        sql += " ,to_number(0,'9') as mien";
                    }
                 
                    sql += " from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on e.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + aexp;
                   
                    ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), true);
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
                if (m_v.tt_thuvienphikhoa(m_userid))
                {
                    aexp = " where done=0 and a.maql="+v_maql;
                    if (s_madoituongthu != "")
                    {
                        aexp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        aexp += " and a.mavp not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd, a.mavp, b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as thanhtien,a.soluong*a.dongia as thucthu,a.madoituong,c.doituong,a.makp, d.tenkp, e.mabs,f.hoten as tenbs, a.id as idcd,b.id_loai, g.id_nhom";
                    if (m_v.sys_khuyenmai)
                    {
                        sql += " ,a.dongia*tylekhuyenmai/100 as mien";
                    }
                    else
                    {
                        sql += " ,to_number(0,'9') as mien";
                    }
                    sql += " from medibvmmyy.v_vpkhoa a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on e.mabs=f.ma left join medibv.v_loaivp g on g.id=b.id_loai" + aexp;

                    ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), true);
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
                if (m_v.tt_thutoatutruc(m_userid))
                {
                    aexp = " where a.maql = " + v_maql;
                    if (s_madoituongthu != "")
                    {
                        aexp += " and a.madoituong in(" + s_madoituongthu + ")";
                    }
                    if (s_mavp_huy.Trim(',') != "")
                    {
                        aexp += " and a.mabd not in(" + s_mavp_huy.Trim(',') + ")";
                    }
                    if (s_tutructhutheokhoa.Trim(',') != "")
                    {
                        aexp += " and d.makp in(" + s_tutructhutheokhoa.Trim(',') + ")";
                    }
                    sql = "select 0 as id, 1 as chon,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,a.mabd as mavp, b.ma,b.ten,b.dang as dvt,a.soluong,a.giaban as dongia,a.giaban* a.soluong as thanhtien,a.soluong*a.giaban as thucthu, a.madoituong, c.doituong, d.makp, d.tenkp,'' as mabs, '' as tenbs, a.id as idcd,to_number(0,'9') as id_loai,to_number(0,'9') as id_nhom,to_number(0,'9') as mien";
                    sql += " from medibvmmyy.d_tienthuoc a left join medibv.d_duockp a1 on a.makp=a1.id inner join medibv.d_dmbd b on a.mabd=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a1.makp=d.makp" + aexp;
                    ads1 = m_v.get_data_mmyy(sql, v_tn, txtNgaythu.Text.Substring(0, 10), true);
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
                    dgHoadon.DataSource = ads.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien();
                }
            }
            catch 
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

                asql1 = "select maql, maql as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(0,9) as loaibn from medibvmmyy.tiepdon where noitiepdon not in (3) and mabn='" + amabn + "'";
                if (m_v.tt_cokhambenh(m_userid))
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number(3,9) as loaibn  from medibvmmyy.benhanpk where mabn='" + amabn + "'";
                }
                if (m_v.tt_conamluu(m_userid))
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(4,9) as loaibn from medibvmmyy.benhancc where mabn='" + amabn + "'";
                }
                DataSet ads = null, ads1 = null, ads2 = null;
                if (asql1 != "")
                {
                    asql1 += "  order by ngay1 desc";
                    ads = m_v.get_data_bc(adt.AddMonths(-1), txtNgaythu.Value.AddMonths(0), asql1);
                }
                if (m_v.tt_conhanbenh(m_userid))
                {
                    sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number(loaiba,9) as loaibn from medibv.benhandt where mabn='" + amabn + "' order by ngay1 desc";
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
            this.Close();
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            string v_nhieubienlai = "";
            if (m_v.tt_thutheoloai(m_userid)) v_nhieubienlai = "LOAI";
            else if (m_v.tt_thutheonhom(m_userid)) v_nhieubienlai = "NHOM";
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
            if (exp == "")
            {
                f_Luu();
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
                string atmp = "", aidcd = "", amakp_ll = "01", amakp_td = "";
                butLuu.Enabled = false;            
                if (m_dshoadon.Tables[0].Rows.Count <= 0)
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this,"Đề nghị nhập nội dung thu viện phí!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "", amaql = "", aidkhoa = "", amakp = "", ahoten = "", anamsinh = "", adiachi = "", aloai = "", aloaibn = "", auserid = "";
                angay = txtNgaythu.Text.Substring(0, 16);
                ammyy = m_v.get_mmyy(angay);

                try
                {
                    aid = "0";// decimal.Parse(m_id).ToString();
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
                if (amabn.Length != 8)
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

                if (txtThonpho.Text != "")
                {
                    adiachi += txtThonpho.Text.Trim() + ",";
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
                    aloaibn = decimal.Parse(s_loaibn).ToString();
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
                    // amaql = "";
                    try
                    {
                        string m_khongdau = m_v.f_khongdau(ahoten);
                        if (v_NamBTDBN.IndexOf(m_v.get_mmyy(angay) + "+") == -1) v_NamBTDBN = v_NamBTDBN + m_v.get_mmyy(angay) + "+";
                        ////Luu hanh chanh
                        //if (!m_v.upd_btdbn(amabn, ahoten, txtNgaysinh.Text, anamsinh, decimal.Parse(cbGioitinh.SelectedValue.ToString()), mann.Text.Trim(), madantoc.Text.Trim(), txtSonha.Text.Trim(), txtThonpho.Text.Trim(), "", cbTinh.SelectedValue.ToString(), cbQuan.SelectedValue.ToString(), cbXa.SelectedValue.ToString(), -decimal.Parse(auserid), v_NamBTDBN, m_khongdau))
                        //{
                        //    amabn = "";
                        //}
                        //if (manuoc.Enabled && manuoc.Text != "") m_v.upd_nuocngoai(amabn, manuoc.Text);
                        //else m_v.execute_data("delete from medibv.nuocngoai where mabn='" + amabn + "'");
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

                        //Luu tiep don.

                        // amakp_ll = m_makp_khongkham;
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

                #region son web
                

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

                aid = m_v.upd_v_vienphill(ammyy, decimal.Parse(aid), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), amakp_ll, ahoten, anamsinh, adiachi, decimal.Parse(aloai), decimal.Parse(aloaibn), decimal.Parse(auserid),decimal.Parse(cbGioitinh.SelectedValue.ToString()),"","", 0,0,0,"");
                m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                if (aid != "0")
                {
                    decimal astt = 1;
                    //string v_aid = "";
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {                       
                        try
                        {
                            string sa = r["mavp"].ToString();
                            if (m_dsgiavp.Tables[0].Select(exp + " and id='" + r["mavp"].ToString() + "'").Length == 0) continue;
                            m_v.upd_v_vienphict("v_vienphict", ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(), decimal.Parse(r["idcd"].ToString()), 0);
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
                            if (r["makp"].ToString().Trim() != "")
                            {
                                if (amakp_td != "") amakp_td += ",";
                                amakp_td += "'" + r["makp"].ToString() + "'";
                            }
                        }
                        catch
                        {
                        }
                    }
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
                    if (m_v.tt_thutoatutruc(m_userid))
                    {
                        sql = "update medibvmmyy.d_tienthuoc set done = 1 where mabn='" + amabn + "' and id in(" + aidcd + ")";
                        m_v.execute_data(atn, angay.Substring(0, 10), sql);
                    }
                }

                if (amakp_td != "")
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
                    sql = "update medibvmmyy.tiepdon set done=null where maql=" + amaql + " and makp in(" + amakp_td + ")";
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
                    if(bLuu_In) f_Inhoadon();
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
            catch//(Exception ex)
            {
                // MessageBox.Show(ex.ToString());
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

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (m_Docmavach)
                    {
                        string s = txtMabn.Text;
                        if (s.Length == 8)
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
                    if (m_Docmavach)
                    {
                        string s = txtMabn1.Text;
                        if (s.Length == 8)
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
                    SendKeys.Send("{Tab}");
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
                    txtMabn1.Text = f.m_mabn.Substring(2, 6);
                    s_mabn = txtMabn.Text + txtMabn1.Text;
                    txtMabn1_Validated(null, null);
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
        private void cbNgayvv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    
                    //SendKeys.Send("{Tab}");
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
                int i = int.Parse(txtMabn1.Text.Trim());
                if (i >= 0 && i <= 999999)
                {
                    txtMabn1.Text = i.ToString().PadLeft(6, '0');
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
            if (m_Docmavach)
            {
                string s = txtMabn1.Text;
                if (s.Length == 8)
                {
                    txtMabn.Text = s.Substring(0, 2);
                    txtMabn1.Text = s.Substring(2);
                    txtMabn1.Text = txtMabn1.Text.PadLeft(6, '0');
                }
            }

            if (txtMabn.Text.Length == 2 && txtMabn1.Text.Length == 6)
            {
                f_Load_Hanhchanh(txtMabn.Text+txtMabn1.Text);
            }
           // label26_Click(null, null);
        }

        private void cbNgayvv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNgayvv.DataSource]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("maql=" + cbNgayvv.SelectedValue.ToString()))
                {
                    cbotenpk.SelectedValue = r["makp"].ToString();
                    cbDoituongTD.SelectedValue = r["madoituong"].ToString();
                    m_mavaovien = decimal.Parse(r["mavaovien"].ToString()).ToString();
                    m_maql = decimal.Parse(r["maql"].ToString()).ToString();
                    s_loaibn = r["loaibn"].ToString();
                    f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString());
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
            f_Inhoadon();
        }
        private void butInchiphi_Click(object sender, EventArgs e)
        {
            f_Inchiphi();
        }

        private void txtTenvp_Leave(object sender, EventArgs e)
        {
        }

        private void txtTenvp_Enter(object sender, EventArgs e)
        {
            try
            {
                f_Display();
            }
            catch
            {
            }
        }

        private void frmThutructiep_touchfing_SizeChanged(object sender, EventArgs e)
        {
            f_Display();
        }

        private void cbNgayvv_Validated(object sender, EventArgs e)
        {
            try
            {
                cbNgayvv_SelectedIndexChanged(null, null);
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

        private void frmThutructiep_touchfing_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
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
        private void butChon_Click(object sender, EventArgs e)
        {
            s_mavp_huy = "";
        }

        private void toolStrip_Mien_Validated(object sender, EventArgs e)
        {
            try
            {
                string s_mien = lMien.Text.Trim();
                if (s_mien.IndexOf("%") > 0)
                {
                    decimal phantram = decimal.Parse(lTongchiphi.Text.Trim());
                    decimal mien = decimal.Parse(s_mien.Trim('%'));
                    decimal tongso = phantram * mien / 100;
                    lMien.Text = tongso.ToString();
                }
            }
            catch 
            {
                lMien.Text = ""; 
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
                m_frmdanhsachchothutien_touch.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachchothutien_touch.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachchothutien_touch.s_mabn != "")
                    {
                        string atmp = m_frmdanhsachchothutien_touch.s_mabn;
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                        if (m_frmdanhsachchothutien_touch.s_maql != "")
                        {
                            f_Load_CB_Ngayvv(m_frmdanhsachchothutien_touch.s_ngaycd, m_frmdanhsachchothutien_touch.s_maql);
                            f_Load_Chidinh(m_frmdanhsachchothutien_touch.s_ngaycd, m_frmdanhsachchothutien_touch.s_maql);
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
                m_frmtimbenhnhan.s_ngay = txtNgaythu.Value;
                if (m_frmtimbenhnhan.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmtimbenhnhan.s_mabn != "")
                    {
                        string atmp = m_frmtimbenhnhan.s_mabn;
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
                m_frmtimhoadon.s_ngay = txtNgaythu.Value;
                m_frmtimhoadon.s_loaihd = "1";
                if (m_frmtimhoadon.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmtimhoadon.s_id != "")
                    {
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
                m_frmdanhsachthutructiep.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachthutructiep.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachthutructiep.s_id != "")
                    {
                        m_id = m_frmdanhsachthutructiep.s_id;
                        f_Load_Hoadon(m_id, m_v.get_mmyy(m_frmdanhsachthutructiep.s_ngaythu));
                    }
                }
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

        private void butLuu_EnabledChanged(object sender, EventArgs e)
        {
            f_Enabled_VP(butLuu.Enabled);
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
            this.Close();
        }

        private void frmThutructiep_touchfing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this,"Đồng ý kết thúc chức năng thu trực tiếp!",m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
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
            //if (this.ActiveControl ==this.lMien.Control) 
            //{
            //    if (toolStrip_Mien.Text.Trim().Length == 1)
            //    {
            //        string s_add = toolStrip_Mien.Text.Trim() == "5" ? "0%" : "5%";
            //        toolStrip_Mien.Text = toolStrip_Mien.Text.Trim() + s_add;
            //        toolStrip_Mien.SelectionStart = 1;
            //        toolStrip_Mien.SelectionLength = toolStrip_Mien.Text.Length - 1;
            //    }
            //    else if (toolStrip_Mien.Text.Trim().Length == 2)
            //    {
            //        toolStrip_Mien.Text = toolStrip_Mien.Text.Trim() + "%";
            //        toolStrip_Mien.SelectionStart = 2;
            //        toolStrip_Mien.SelectionLength = toolStrip_Mien.Text.Length - 2;
            //    }

            //}
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

        private void butDanhsachcho_Click(object sender, EventArgs e)
        {
            try
            {
                m_frmdanhsachchothutien_touch.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachchothutien_touch.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachchothutien_touch.s_mabn != "")
                    {
                        string atmp = m_frmdanhsachchothutien_touch.s_mabn;
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                        if (m_frmdanhsachchothutien_touch.s_maql != "")
                        {
                            f_Load_CB_Ngayvv(m_frmdanhsachchothutien_touch.s_ngaycd, m_frmdanhsachchothutien_touch.s_maql);
                            f_Load_Chidinh(m_frmdanhsachchothutien_touch.s_ngaycd, m_frmdanhsachchothutien_touch.s_maql);
                            if (dgHoadon.Rows.Count > 0 && !butLuu.Enabled) f_Enable(true);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}