using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmPhieuchi : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private string m_cur_yy = "";
        private string m_id_gia = "";
        private DateTime m_cur_ngay = DateTime.Now;
        private string m_cur_loaidv = "";
        private string m_cur_quyenso = "";
        

        private LibVP.AccessData m_v;
        private DataSet m_dshoadon;
    
        private string m_id="",m_mavaovien="",m_maql="",m_userid="",v_namBTDBN="";
        private DataSet m_dsgiavp;

        private frmChonvp m_frmchonvp;
        private frmDanhsachphieuchi m_frmdanhsachphieuchi;
        private frmDanhsachchophieuchi m_frmdanhsachchophieuchi;
        private frmTimhoadon m_frmtimhoadon;
        private frmTimbenhnhan m_frmtimbenhnhan;
        private frmHoantra m_frmhoantra;
        private frmPrintHD m_frmprinthd;

        //var
        private bool m_bnmoi = false;
        //option
        private bool m_o_fullscreen = false;
        public frmPhieuchi(LibVP.AccessData v_v, string v_userid)
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
                
                m_o_fullscreen = m_v.get_o_fullscreen_frmphieuchi(m_userid);
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
                    txtNgaythu.Value = m_v.f_parse_date(value);
                    m_cur_ngay = txtNgaythu.Value;
                }
                catch
                {
                }
            }
        }
        private void frmPhieuchi_Load(object sender, EventArgs e)
        {
            try
            {
                f_Load_Thutrongngay();
                f_Load_DG();
                f_Load_Hotkey();
                f_Enable(false);
                this.WindowState = FormWindowState.Maximized;
                this.Refresh();
                butBoqua_Click(null, null);
                //
                string tmp_qso = m_cur_quyenso;
                lbKyhieu_Click(null, null);
                s_quyenso = tmp_qso;
                //
                txtSobienlai.ReadOnly = true;
                if (cbKyhieu.Items.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Phải khai báo quyển sổ phiếu chi trước!")+"\n"+lan.Change_language_MessageText("Vào [Tiện ích] -> [Khai báo quyển sổ] để khai!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                foreach (DataRow r in m_v.get_data("select distinct hotkey, ghichu from medibv.v_optionhotkey" + atable + " where userid=" + m_userid + " and loai=1").Tables[0].Rows)
                {
                    if (r["hotkey"].ToString() == "F1")
                    {
                        tmn_F1.Text = "F1 - "+r["ghichu"].ToString().Trim();
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
                tmn_Chonhapmoi.Enabled = asys_suatuychon;
                tmn_Chokhongquatiepdon.Enabled = asys_suatuychon;
                tmn_Cokhambenh.Enabled = asys_suatuychon;
                tmn_Cophongluu.Enabled = asys_suatuychon;
                tmn_Conhanbenh.Enabled = asys_suatuychon;

                tmn_Cokhambenh.Checked = m_v.pc_cokhambenh(m_userid);
                tmn_Cophongluu.Checked = m_v.pc_conamluu(m_userid);
                tmn_Conhanbenh.Checked = m_v.pc_conhanbenh(m_userid);

                string sql = "";
                string atmp = m_v.s_curmmyyyy;
                DataSet ads;
                DataRow r;
                m_cur_ngay = m_v.f_parse_date(atmp);
                m_cur_yy = m_cur_ngay.Year.ToString().Substring(2);

                cbTinh.DataSource = m_v.get_data("select matt,tentt from medibv.btdtt order by tentt").Tables[0];
                cbTinh.DisplayMember = "tentt";
                cbTinh.ValueMember = "matt";

                ads = m_v.get_data("select makp,tenkp from medibv.btdkp_bv order by loai, tenkp");
                r = ads.Tables[0].NewRow();
                r["makp"] = "00";
                r["tenkp"] = "";
                ads.Tables[0].Rows.InsertAt(r, 0);

                cbKhoa.DataSource = ads.Tables[0];
                cbKhoa.DisplayMember = "tenkp";
                cbKhoa.ValueMember = "makp";

                cbDoituongTD.DataSource = m_v.get_data("select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong order by madoituong").Tables[0];
                cbDoituongTD.DisplayMember = "doituong";
                cbDoituongTD.ValueMember = "madoituong";

                cbLoaidv.DataSource = m_v.get_data("select ma,ten from medibv.v_tenloaivp order by ma").Tables[0];
                cbLoaidv.DisplayMember = "ten";
                cbLoaidv.ValueMember = "ma";
                
                sql = "select id,sohieu,loai,userid from medibv.v_quyenso";
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

                cbGioitinh.DataSource = m_v.get_data("select ma,ten from medibv.dmphai order by ma desc").Tables[0];
                cbGioitinh.DisplayMember = "ten";
                cbGioitinh.ValueMember = "ma";

                cbTuoi.DataSource = m_v.f_get_dmtuoi().Tables[0];
                cbTuoi.DisplayMember = "ten";
                cbTuoi.ValueMember = "id";

                sql = "select id,ma,ten,dvt,gia_th,gia_bh,gia_dv,gia_nn,gia_cs,bhyt from medibv.v_giavp order by ten";
                dgGia.DataSource = m_v.get_data(sql).Tables[0];

                m_dsgiavp = m_v.get_data("select * from medibv.v_giavp order by id_loai, ten");

                sql = "select to_number(0,'9') as chon, to_number(0,'9') as mavp, '' as ma,'' as ten,'' as dvt,to_number(0,'9') as sotien";
                m_dshoadon = m_v.get_data(sql);
                m_dshoadon.Tables[0].Rows.Clear();
                
                dgHoadon.DataSource = m_dshoadon.Tables[0];


                sql = "select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs, trim(b.ten) as tenloai,b.id as id_loai, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id order by b.ten,b.stt, b.id, a.ten,a.stt";
                m_frmchonvp = new frmChonvp(m_v, m_userid,"GIA_TH", m_v.get_data(sql),m_v.s_loaiform_phieuchi);
                m_frmchonvp.s_multiline = m_v.get_o_multiline_frmchonvp(m_userid);
                m_frmchonvp.s_dshotkey = m_v.f_get_hotkey_frmphieuchi(m_userid);
                m_frmchonvp.s_dshotkey_ksk = m_v.f_get_hotkey_ksk_frmphieuchi(m_userid);
                m_frmchonvp.s_hotkey = "";
                m_frmchonvp.ShowInTaskbar = false;

                m_frmdanhsachphieuchi = new frmDanhsachphieuchi(m_v, m_userid);
                m_frmdanhsachphieuchi.ShowInTaskbar = false;

                m_frmdanhsachchophieuchi = new frmDanhsachchophieuchi(m_v, m_userid);
                m_frmdanhsachchophieuchi.ShowInTaskbar = false;
                
                m_frmtimbenhnhan = new frmTimbenhnhan(m_v, m_userid);
                m_frmtimbenhnhan.ShowInTaskbar = false;
                
                m_frmtimhoadon = new frmTimhoadon(m_v, m_userid);
                m_frmtimhoadon.ShowInTaskbar = false;
                m_frmtimhoadon.s_loaihd = "1";

                m_frmhoantra = new frmHoantra(m_v, m_userid);
                m_frmhoantra.ShowInTaskbar = false;
                m_frmhoantra.s_loaihd = "1";

                m_frmprinthd = new frmPrintHD(m_v,m_userid);

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmphieuchi(m_userid);
                f_Set_Fullgrid();

                tmn_Hotkey_Show.Checked = m_v.get_o_show_hotkey_frmphieuchi(m_userid);
                tmn_Hotkey_KSK_Show.Checked = m_v.get_o_show_hotkey_ksk_frmphieuchi(m_userid);
                if (tmn_Hotkey_Show.Checked && tmn_Hotkey_KSK_Show.Checked)
                {
                    tmn_Hotkey_KSK_Show.Checked = false;
                    m_v.set_o_show_hotkey_ksk_frmphieuchi(m_userid, false);
                }
                tmn_Hotkey_Addall.Checked = m_v.get_o_addall_hotkey_frmphieuchi(m_userid);
                tmn_Show_Hotkey.Checked = m_v.get_o_show_hotkey_toolbar_frmphieuchi(m_userid);
                tt_Hotkey.Visible = tmn_Show_Hotkey.Checked;
                f_Display();

                //Option
                tmn_Luuin_Hoadon.Checked = m_v.get_o_luuin_hoadon_frmphieuchi(m_userid);
                tmn_Luuin_Chiphi.Checked = m_v.get_o_luuin_chiphi_frmphieuchi(m_userid);
                tmn_Xemtruockhiin_Icon.Checked = m_v.get_o_xemtruockhiin_frmphieuchi(m_userid);
                
                tmn_Chonhapmoi.Checked = m_v.pc_chonhapmoi(m_userid);
                tmn_Chokhongquatiepdon.Checked = m_v.pc_chokhongquatiepdon(m_userid);
            }
            catch
            {
            }
        }
        private void f_Load_CB_Quan(string v_matt)
        {
            try
            {
                cbQuan.DataSource = m_v.get_data("select maqu,tenquan from medibv.btdquan where matt='"+v_matt+"' order by tenquan").Tables[0];
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
                cbXa.DataSource = m_v.get_data("select maphuongxa,tenpxa from medibv.btdpxa where maqu='" + v_maqu + "' order by tenpxa").Tables[0];
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
                sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.phai,a.sonha,a.thon,a.cholam,a.maphuongxa,nam from medibv.btdbn a where a.mabn='" + v_mabn + "'";
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
                    txtDiachi.Text = r["sonha"].ToString().Trim();
                    v_namBTDBN=r["nam"].ToString();
                    if(r["thon"].ToString().Trim()!="")
                    {
                        if (r["sonha"].ToString().Trim() != "")
                        {
                            txtDiachi.Text=txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + r["thon"].ToString().Trim();
                    }

                    if (r["cholam"].ToString().Trim() != "")
                    {
                        if (txtDiachi.Text.Trim() != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + " ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + "(" + r["cholam"].ToString().Trim()+")";
                    }
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
                            cbDoituongTD.SelectedValue = "2";
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
                        if (tmn_Chonhapmoi.Checked)
                        {
                            f_Enable_HC(true);
                            f_Enabled_VP(true);
                            f_FullScreen(false);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Không cho phép nhập bệnh nhân mới!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            f_Enable_HC(false);
                            f_Enabled_VP(false);
                            txtMabn.Focus();
                            return;
                        }
                    }
                    else
                    if (cbNgayvv.Items.Count <= 0 && !tmn_Chokhongquatiepdon.Checked)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không cho phép, bệnh nhân chưa hoàn tất thủ tục!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        txtTenvp.Focus();
                    }
                }
            }
            catch
            {
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Clear_HC()
        {
            try
            {
                //cbLoaidv.Text="";
                //txtNgaythu.Text="";
                //cbKyhieu.Text="";
                //txtSobienlai.Text="";

                txtHoten.Text = "";
                txtNgaysinh.Text = "";
                txtTuoi.Text = "";
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
                txtTinh.Text = "";
                try
                {
                    cbTinh.SelectedIndex = -1;
                }
                catch
                {
                }
                txtQuan.Text = "";
                try
                {
                    cbQuan.SelectedIndex = -1;
                }
                catch
                {
                }
                txtXa.Text = "";
                try
                {
                    cbXa.SelectedIndex = 0;
                }
                catch
                {
                }
                txtDiachi.Text = "";
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
                    cbKhoa.SelectedIndex = -1;
                }
                catch
                {
                }
                txtTenvp.Text = "";
                txtSotien.Text = "";

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
                cbLoaidv.Enabled = false;// v_bool;
                txtNgaythu.Enabled = false;// v_bool;
                cbKyhieu.Enabled = false;// v_bool;
                //txtSobienlai.ReadOnly = true;// !v_bool;

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
                txtDiachi.ReadOnly = !v_bool;
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
                txtTenvp.Enabled = v_bool;
                txtSotien.Enabled = v_bool;

                butAdd.Enabled = v_bool;
                butRem.Enabled = v_bool;
                butChon.Enabled = v_bool;

                dgHoadon.Columns[4].ReadOnly = !butLuu.Enabled;
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Phải khai báo quyển sổ phiếu chi trước!")+"\n"+lan.Change_language_MessageText("Vào [Tiện ích] -> [Khai báo quyển sổ] để khai!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                    return;
                }

                f_FullScreen(m_o_fullscreen);
                m_bnmoi = true;
                m_id = "";
                v_namBTDBN = "";
                m_mavaovien = "";
                m_maql = "";
                m_id_gia = "";

                m_dshoadon.Tables[0].Rows.Clear();
                f_Tinhtien();
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (atmp.Split(':')[1] == "2")//Lỗi
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy quyển sổ phiếu chi!")+"\n"+lan.Change_language_MessageText("Đề nghị chọn sổ"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtMabn.Text = m_cur_yy;
                txtMabn1.Text = "";
                dgHoadon.Columns["Column_0"].ToolTipText = lan.Change_language_MessageText("Đánh dấu những mục cần in");
                f_Filter_Giavp();
                dgGia.Visible = false;

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
                bool asua = (m_id!="" && m_id!="0");
                string atmp="";
                butLuu.Enabled = false;

                if (m_dshoadon.Tables[0].Rows.Count <= 0)
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập nội dung phiếu chi!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenvp.Focus();
                    return;
                }
                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "", amaql = "", aidkhoa = "", amakp = "", ahoten = "", anamsinh = "", adiachi = "", aloai = "", aloaibn = "", auserid = "";
                angay = txtNgaythu.Text.Substring(0, 10);
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn quyển sổ phiếu chi!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập thông tin bệnh nhân!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMabn.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                try
                {
                    amakp = cbKhoa.SelectedValue.ToString();
                }
                catch
                {
                    amakp = "00";
                }
                ahoten=txtHoten.Text.Trim();
                if (ahoten.Length == 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập thông tin bệnh nhân!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                adiachi=txtDiachi.Text.Trim();
                if(cbXa.Text.ToUpper().Trim() != lan.Change_language_MessageText("KHÔNG XÁC ĐỊNH"))
                {
                    if(adiachi!="")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbXa.Text.Trim();
                }
                if(cbQuan.Text.ToUpper().Trim() != 
lan.Change_language_MessageText("KHÔNG XÁC ĐỊNH"))
                {
                    if(adiachi!="")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbQuan.Text.Trim();
                }
                if(cbTinh.Text.ToUpper().Trim() != 
lan.Change_language_MessageText("KHÔNG XÁC ĐỊNH"))
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
                        MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị chọn ngày chi >= ngày bệnh nhân vào viện (") + cbNgayvv.Text.Substring(0, 10) + ")!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!")+"\n"+lan.Change_language_MessageText("Có muốn chọn sổ khác không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                            MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy quyển sổ phiếu chi!")+"\n"+lan.Change_language_MessageText("Đề nghị chọn sổ"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbKyhieu.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbKyhieu.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                }
                if (m_bnmoi)
                {
                    amaql = "";
                    try
                    {
                        string m_khongdau = m_v.f_khongdau(ahoten);
                        if (v_namBTDBN.IndexOf(m_v.get_mmyy(angay) + "+") == -1) v_namBTDBN = v_namBTDBN + m_v.get_mmyy(angay) + "+";
                        
                        //Luu hanh chanh
                        if (!m_v.upd_btdbn(amabn, ahoten, txtNgaysinh.Text, anamsinh, decimal.Parse(cbGioitinh.SelectedValue.ToString()), "99", "25", "", "", "", cbTinh.SelectedValue.ToString(), cbQuan.SelectedValue.ToString(), cbXa.SelectedValue.ToString(), -1, v_namBTDBN, m_khongdau))
                        {
                            amabn = "";
                        }
                    }
                    catch
                    {
                        amabn = "";
                    }
                    if (amabn == "")
                    {
                        butLuu.Enabled = true;
                        MessageBox.Show(this, lan.Change_language_MessageText("Không cập nhật được thông tin bệnh nhân!")+"\n"+lan.Change_language_MessageText("Chưa lưu hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (amaql == "" || amaql=="0")
                {
                    try
                    {
                        //Luu tiep don
                        amaql = m_v.upd_tiepdon(amabn,0, 0, amakp,angay, decimal.Parse(cbDoituongTD.SelectedValue.ToString()), "0000000000", txtTuoi.Text.PadLeft(4,'0'), 1, 7, 0,-1).ToString();
                    }
                    catch
                    {
                    }
                }
                if (amaql == "" || amaql=="0")
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Không cập nhật được thông tin tiếp đón!")+"\n"+lan.Change_language_MessageText("Chưa lưu hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (amavaovien == "")
                {
                    amavaovien = amaql;
                }

                asobienlai = txtSobienlai.Text.Trim();
                if (aid != "0")
                {
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_phieuchict where id = " + aid);
                }
                aid = m_v.upd_v_phieuchill(ammyy,decimal.Parse(aid),decimal.Parse(aquyenso),decimal.Parse(asobienlai),angay,amabn,decimal.Parse(amaql),decimal.Parse(aidkhoa),amakp,ahoten,decimal.Parse(aloai),decimal.Parse(aloaibn),decimal.Parse(auserid));
                m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                if (aid != "0")
                {
                    decimal astt=1;
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            m_v.upd_v_phieuchict(ammyy, decimal.Parse(aid), astt, decimal.Parse(r["mavp"].ToString()),decimal.Parse(r["sotien"].ToString()));
                            astt += 1;
                        }
                        catch
                        {
                        }
                    }
                }

                m_id = aid;
                if (m_id == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this, lan.Change_language_MessageText("Lỗi lưu dữ liệu!")+"\n"+lan.Change_language_MessageText("Chưa lưu dược hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!")+"\n"+lan.Change_language_MessageText("Có muốn in lại hoá đơn vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inhoadon();
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
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!")+"\n"+lan.Change_language_MessageText("Có muốn in lại chi phí vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
            catch
            {
            }
        }
        private void f_Sua()
        {
            try
            {
                if (m_v.pc_suahoadon(m_userid))
                {
                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép sửa.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        f_Enable(true);
                        f_Enable_HC(false);
                        txtTenvp.Focus();
                        dgGia.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (m_v.pc_xoahoadon(m_userid))
                {
                    string ammyy = txtNgaythu.Value.Month.ToString().PadLeft(2, '0') + txtNgaythu.Value.Year.ToString().Substring(2);
                    if (m_v.dadung_v_vienphill(ammyy, m_id) != 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá hoá đơn này!") + "\n" + lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Hoá đơn đã in không được xoá, chỉ được phép hoàn trả") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép sửa.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                            if (MessageBox.Show(this, lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Nếu xoá xem như hoá đơn chưa phát sinh, sẽ không có trong báo cáo")+"\n"+ lan.Change_language_MessageText("Nếu hoàn xem như hoá đơn đã phát sinh và không có giá trị sử dụng, có trong báo cáo hoàn.")+"\n"+lan.Change_language_MessageText("Đồng ý xoá hoá đơn này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            if (!m_v.del_v_vienphill(ammyy, m_id))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá hoá đơn này!")+"\n"+lan.Change_language_MessageText("Ghi chú:")+"\n"+ lan.Change_language_MessageText("Hoá đơn đã in không được xoá, chỉ được phép hoàn trả") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                f_Load_Thutrongngay();
                                f_Clear_HC();
                                m_dshoadon.Tables[0].Rows.Clear();
                                f_Tinhtien();
                                f_Enable(false);
                                f_Enable_HC(false);
                                butMoi.Focus();
                            }
                        }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền xóa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    m_frmprinthd.f_Print_Phieuchi(!tmn_Xemtruockhiin_Icon.Checked,m_id,m_v.get_mmyy(txtNgaythu.Text.Substring(0,10)),"1");
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
                m_frmprinthd.f_Print_Phieuchi_Chitiet(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)));
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
                m_frmhoantra.s_loaihd = m_v.s_loaiform_phieuchi;
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
                Column2_3.HeaderText = lan.Change_language_MessageText("Tên viện phí (Tìm thấy:")+" "+dv.Table.Select(aft).Length.ToString()+")";
                if (dgGia.Visible == false && this.ActiveControl==txtTenvp)
                {
                    dgGia.Visible = true;
                }
            }
            catch
            {
                Column2_3.HeaderText = lan.Change_language_MessageText("Tên viện phí (Tìm thấy:")+" " + m_dsgiavp.Tables[0].Rows.Count.ToString() + ")";
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
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbKyhieu.DataSource]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
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
        private void f_Get_Item()
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituongTD.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r = dv.Table.Select("madoituong=" + cbDoituongTD.SelectedValue.ToString())[0];
                DataRowView arv = (DataRowView)(dgGia.CurrentRow.DataBoundItem);
                m_id_gia = arv["id"].ToString();
                txtSotien.Text = arv[r["field_gia"].ToString().Trim()].ToString();
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
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituongTD.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r = dv.Table.Select("madoituong=" + cbDoituongTD.SelectedValue.ToString())[0];
                string adoituong = cbDoituongTD.SelectedValue.ToString();
                string afieldgia = r["field_gia"].ToString().Trim();
                string amien100 = r["mien"].ToString();
                decimal asotien = 0;
                foreach(string aid in v_id.Split(','))
                {
                    foreach (DataRow r1 in m_dsgiavp.Tables[0].Select("id =" + aid))
                    {
                        try
                        {
                            asotien = decimal.Parse(r1[afieldgia].ToString());
                            if (asotien < 0)
                            {
                                asotien = 0;
                            }
                        }
                        catch
                        {
                            asotien = 0;
                        }
                        if (m_dshoadon.Tables[0].Select("mavp=" + r1["id"].ToString()).Length > 0)
                        {
                            DataRow r2 = m_dshoadon.Tables[0].Select("mavp=" + r1["id"].ToString())[0];
                            r2["ma"] = r1["ma"].ToString();
                            r2["ten"] = r1["ten"].ToString();
                            r2["dvt"] = r1["dvt"].ToString();
                            r2["sotien"] = asotien;
                        }
                        else
                        {
                            DataRow r2 = m_dshoadon.Tables[0].NewRow();
                            r2["chon"] = 1;
                            r2["mavp"] = r1["id"].ToString();
                            r2["ma"] = r1["ma"].ToString();
                            r2["ten"] = r1["ten"].ToString();
                            r2["dvt"] = r1["dvt"].ToString();
                            r2["sotien"] = asotien;
                            m_dshoadon.Tables[0].Rows.Add(r2);
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
                decimal asotien = 0;
                try
                {
                    asotien = decimal.Parse(txtSotien.Text.Trim().Replace(" ",""));
                    if (asotien < 0)
                    {
                        asotien = 0;
                    }
                }
                catch
                {
                    asotien = 0;
                }

                DataRow arv = m_dsgiavp.Tables[0].Select("id="+m_id_gia)[0];

                if (m_dshoadon.Tables[0].Select("mavp=" + arv["id"].ToString()).Length > 0)
                {
                    DataRow r = m_dshoadon.Tables[0].Select("mavp=" + arv["id"].ToString())[0];
                    r["mavp"] = arv["id"].ToString();
                    r["ma"] = arv["ma"].ToString();
                    r["ten"] = arv["ten"].ToString();
                    r["dvt"] = arv["dvt"].ToString();
                    r["sotien"] = asotien;
                }
                else
                {
                    DataRow r = m_dshoadon.Tables[0].NewRow();
                    r["chon"] = 1;
                    r["mavp"] = arv["id"].ToString();
                    r["ma"] = arv["ma"].ToString();
                    r["ten"] = arv["ten"].ToString();
                    r["dvt"] = arv["dvt"].ToString();
                    r["sotien"] = asotien;
                    m_dshoadon.Tables[0].Rows.Add(r);
                }
                m_id_gia = "";
                f_Tinhtien();
            }
            catch
            {
            }
        }
        private void f_Rem()
        {
            try
            {
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
                decimal asotien = 0;
                try
                {
                    asotien = decimal.Parse(txtSotien.Text.Trim().Replace(",", ""));
                    if (asotien < 0)
                    {
                        asotien = 0;
                    }
                }
                catch
                {
                    asotien = 0;
                }
                txtSotien.Text = asotien.ToString("###,###,##0.##").Trim();
            }
            catch
            {
            }
        }
        private void f_Tinhtien()
        {
            try
            {
                decimal asotien = 0, atongcong = 0;
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    try
                    {
                        asotien = decimal.Parse(r["sotien"].ToString().Trim().Replace(",", ""));
                        if (asotien < 0)
                        {
                            asotien = 0;
                        }
                    }
                    catch
                    {
                        asotien = 0;
                    }
                    r["sotien"] = asotien;

                    atongcong += asotien;
                }
                m_dshoadon.AcceptChanges();

                toolStrip_Tongcong.Text = atongcong.ToString("###,###,##0.##").Trim();
                toolStrip_Tongcong.ToolTipText = m_v.Doiso_Unicode(atongcong.ToString("##########")).Replace("  "," ");
                
                toolStrip_Somuc.Text = m_dshoadon.Tables[0].Rows.Count.ToString() +" "+ lan.Change_language_MessageText("mục");
            }
            catch
            {
                toolStrip_Tongcong.Text = "0";
                toolStrip_Tongcong.ToolTipText = lan.Change_language_MessageText("Không đồng");
                
                toolStrip_Somuc.Text = lan.Change_language_MessageText("0 mục");
            }
        }
        private void f_Load_Thutrongngay()
        {
            try
            {
                string sql = "", ammyy = "";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                decimal asotien = 0, asohd=0;
                sql = "select sum(b.sotien) as sotien from medibvmmyy.v_phieuchill a inner join medibvmmyy.v_phieuchict b on a.id=b.id where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                try
                {
                    asotien = decimal.Parse(m_v.get_data_mmyy(ammyy,sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    asotien = 0;
                }

                sql = "select count(distinct a.id) as sohd from medibvmmyy.v_phieuchill a inner join medibvmmyy.v_phieuchict b on a.id=b.id where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
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
                sql = "select a.mabn,a.maql,a.makp,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.quyenso,a.sobienlai,a.loai,a.loaibn,a.id, to_number(0,'9') as chon, b.mavp, c.ma,c.ten,c.dvt,b.sotien from medibvmmyy.v_phieuchill a left join medibvmmyy.v_phieuchict b on a.id=b.id left join medibv.v_giavp c on b.mavp=c.id left join medibv.btdkp_bv e on a.makp=e.makp where a.id = " + v_id;
                DataSet ads = m_v.get_data_mmyy(ammyy, sql);
                m_mavaovien = "";
                m_maql = "";
                if (ads.Tables[0].Rows.Count>0)
                {
                    m_mavaovien = "0";// ads.Tables[0].Rows[0]["mavaovien"].ToString();
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
                        cbKhoa.SelectedValue = ads.Tables[0].Rows[0]["makp"].ToString();
                    }
                    catch
                    {
                    }
                    txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    txtNgaythu.Value = m_v.f_parse_date(ads.Tables[0].Rows[0]["ngay"].ToString());

                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loai");
                    ads.Tables[0].Columns.Remove("loaibn");
                    ads.Tables[0].Columns.Remove("ngay");
                    ads.Tables[0].Columns.Remove("makp");
                    m_dshoadon = ads;
                    dgHoadon.DataSource = m_dshoadon.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien();
                    m_id = v_id;
                }
                f_Enable(m_id == "" || m_id == "0");
                butLuu_EnabledChanged(null, null);
            }
            catch
            {
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
                        asobienlai = decimal.Parse(m_v.get_data_mmyy(ammyy,"select a.sobienlai from medibvmmyy.v_phieuchill a where a.id = " + m_id).Tables[0].Rows[0][0].ToString()).ToString();
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
                sql = "select a.id from medibvmmyy.v_phieuchill a where " + aexp;
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy hoá đơn")+" " + (v_pre < 0 ? lan.Change_language_MessageText("trước")+" " : " "+ lan.Change_language_MessageText("sau")) + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                asql1 = "select maql, maql as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, makp,madoituong, to_number(0,9) as loaibn from medibvmmyy.tiepdon where mabn='" + amabn + "'";
                if (tmn_Cokhambenh.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, makp,madoituong,to_number(3,9) as loaibn  from medibvmmyy.benhanpk where mabn='" + amabn + "'";
                }
                if (tmn_Cophongluu.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, makp,madoituong, to_number(4,9) as loaibn from medibvmmyy.benhancc where mabn='" + amabn + "'";
                }
                DataSet ads = null, ads1 = null;
                if (asql1 != "")
                {
                    asql1 += "  order by ngay desc";
                    ads = m_v.get_data_bc(adt.AddMonths(-1), txtNgaythu.Value.AddMonths(0), asql1);
                }
                if (tmn_Conhanbenh.Checked)
                {
                    sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, makp,madoituong,to_number(loaiba,9) as loaibn from medibv.benhandt where mabn='" + amabn + "'";
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

                cbNgayvv.DataSource = ads.Tables[0];
                cbNgayvv.DisplayMember = "ngay";
                cbNgayvv.ValueMember = "maql";
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
            f_Luu();
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

        private void cbDoituongTD_SelectedIndexChanged(object sender, EventArgs e)
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

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMabn_Validated(null,null);
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
                            txtDiachi.Focus();
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

        private void cbTQX_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cbTQX.Items.Count > 0)
                    {
                        f_Load_T_Q_X(cbTQX.SelectedValue.ToString());
                        txtDiachi.Focus();
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
        private void cbNgayvv_KeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{Tab}{F4}}");
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
                        txtSotien.SelectAll();
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

        private void txtSotien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSotien.Text != "" && txtSotien.Text != "0")
                    {
                        butAdd.Focus();
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
        private void cbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtTenvp.Enabled)
                    {
                        txtTenvp.Focus();
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
            if (txtMabn.Text.Length == 2 && txtMabn1.Text.Length == 6)
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
                    cbDoituongTD.SelectedValue = r["madoituong"].ToString();
                    m_mavaovien = decimal.Parse(r["mavaovien"].ToString()).ToString();
                    m_maql = decimal.Parse(r["maql"].ToString()).ToString();
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
            if (!tmn_Luuin_Hoadon.Checked)
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Chọn loại hoá đơn cần in từ [Tùy chọn]!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tmn_Luuin_Hoadon.Checked)
            {
                f_Inhoadon();
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

        private void frmPhieuchi_SizeChanged(object sender, EventArgs e)
        {
            f_Display();
        }

        private void cbNgayvv_Validated(object sender, EventArgs e)
        {
            try
            {
                cbNgayvv_SelectedIndexChanged(null, null);
                if (m_dshoadon.Tables[0].Rows.Count <= 0 && butLuu.Enabled && (m_id == "" || m_id == "0") && tmn_Thuchidinh.Checked && cbNgayvv.Items.Count > 0)
                {
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

        private void frmPhieuchi_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                dgGia.BackgroundColor = Color.LightYellow;
                if (dgGia.Visible)
                {
                    cbDoituongTD_Validated(null, null);
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
                if (txtSotien.Text == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa nhập số tiền!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (txtSotien.Enabled)
                    {
                        txtSotien.Focus();
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
                txtSotien.Text = "0";
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
                txtSotien.Text = "0";
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
                        dgHoadon.Columns["Column_0"].ToolTipText = lan.Change_language_MessageText("Đánh dấu những mục cần in:")+" " + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString();
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

        private void txtSotien_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_mon();
        }

        private void txtMien_Validated(object sender, EventArgs e)
        {
            f_Tinhtien_mon();
        }

        private void cbTinh_Validated(object sender, EventArgs e)
        {
            try
            {
                f_Load_CB_Quan(cbTinh.SelectedValue.ToString());
            }
            catch
            {
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

        private void cbTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtTinh.Text = cbTinh.SelectedValue.ToString();
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
                        CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituongTD.DataSource]);
                        DataView dv = (DataView)(cm.List);
                        DataRow r = dv.Table.Select("madoituong=" + cbDoituongTD.SelectedValue.ToString())[0];
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhấn nút")+" " + (m_id == "" ? lan.Change_language_MessageText("Mới") : lan.Change_language_MessageText("Sửa") +" "+ lan.Change_language_MessageText("trước khi chọn viện phí!")), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmPhieuchi_KeyDown(object sender, KeyEventArgs e)
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
                    toolTip1.SetToolTip(chkAll,lan.Change_language_MessageText("Đánh dấu những mục cần in:")+" " + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString());
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
                pHanhchanh.Height = v_bool?25:114;
            }
            catch
            {
            }
        }
        
        private void toolStrip_Title_Click(object sender, EventArgs e)
        {
            try
            {
                pHanhchanh.Height = (pHanhchanh.Height > 100)?25:114;
                m_v.set_o_fullscreen_frmphieuchi(m_userid, pHanhchanh.Height > 100 ? false : true);
                m_o_fullscreen = m_v.get_o_fullscreen_frmphieuchi(m_userid);
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
        private void txtKhoa_KeyDown(object sender, KeyEventArgs e)
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
        private void cbKhoa_Validated(object sender, EventArgs e)
        {
            try
            {
                txtKhoa.Text = cbKhoa.SelectedValue.ToString();
            }
            catch
            {
            }
        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKhoa.Text = cbKhoa.SelectedValue.ToString();
            }
            catch
            {
            }
        }
        private void txtKhoa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cbKhoa.SelectedValue = txtKhoa.Text;
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
                }
                else
                if (atmp.Split(':')[1] == "2")//Lỗi
                {
                    //MessageBox.Show(this, "Không tìm thấy quyển sổ phiếu chi!\nĐề nghị chọn sổ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                m_frmdanhsachchophieuchi.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachchophieuchi.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachchophieuchi.s_mabn != "")
                    {
                        string atmp = m_frmdanhsachchophieuchi.s_mabn;
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                        if (m_frmdanhsachchophieuchi.s_maql != "")
                        {
                            f_Load_CB_Ngayvv(m_frmdanhsachchophieuchi.s_ngaycd, m_frmdanhsachchophieuchi.s_maql);
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
                m_frmdanhsachphieuchi.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachphieuchi.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachphieuchi.s_id != "")
                    {
                        m_id = m_frmdanhsachphieuchi.s_id;
                        f_Load_Hoadon(m_id, m_v.get_mmyy(m_frmdanhsachphieuchi.s_ngaythu));
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
                txtSotien.Text = arv["sotien"].ToString();
                txtSotien_Validated(null, null);
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
                        case "1":
                        case "2":
                        case "3":
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
                //dgHoadon.Columns["Column1_4"].Frozen = !tmn_Fullgrid.Checked;
                //dgHoadon.Columns["Column1_3"].Frozen = !tmn_Fullgrid.Checked;
                //dgHoadon.Columns["Column_0"].Frozen = !tmn_Fullgrid.Checked;
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
                m_v.set_o_fullgrid_frmphieuchi(m_userid, tmn_Fullgrid.Checked);
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
                m_v.set_o_show_hotkey_frmphieuchi(m_userid, tmn_Hotkey_Show.Checked);
                m_v.set_o_show_hotkey_ksk_frmphieuchi(m_userid, tmn_Hotkey_KSK_Show.Checked);
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
                m_v.set_o_show_hotkey_frmphieuchi(m_userid, tmn_Hotkey_Show.Checked);
                m_v.set_o_show_hotkey_ksk_frmphieuchi(m_userid, tmn_Hotkey_KSK_Show.Checked);
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
                m_v.set_o_show_hotkey_toolbar_frmphieuchi(m_userid, tmn_Show_Hotkey.Checked);
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
            m_v.set_o_luuin_hoadon_frmphieuchi(m_userid,tmn_Luuin_Hoadon.Checked);
        }
        private void tmn_Luuin_Hoadon_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_frmphieuchi(m_userid, tmn_Luuin_Hoadon_Icon.Checked);
        }

        private void tmn_Xemtruockhiin_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_xemtruockhiin_frmphieuchi(m_userid, tmn_Xemtruockhiin_Icon.Checked);
        }
        private void tmn_Luuin_Chiphi_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_chiphi_frmphieuchi(m_userid,tmn_Luuin_Chiphi.Checked);
        }
        private void tmn_Hotkey_Addall_Click(object sender, EventArgs e)
        {
            m_v.set_o_addall_hotkey_frmphieuchi(m_userid, tmn_Hotkey_Addall.Checked);
        }

        private void tmn_Show_Hotkey_Click(object sender, EventArgs e)
        {
            m_v.set_o_show_hotkey_toolbar_frmphieuchi(m_userid, tmn_Show_Hotkey.Checked);
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
                dgHoadon.Columns["Column_0"].ToolTipText = lan.Change_language_MessageText("Đánh dấu những mục cần in:")+" " + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString();
                toolTip1.SetToolTip(chkAll, lan.Change_language_MessageText("Đánh dấu những mục cần in:")+" " + m_dshoadon.Tables[0].Select("chon = 1").Length.ToString() + "/" + m_dshoadon.Tables[0].Rows.Count.ToString());
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

        private void frmPhieuchi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý kết thúc chức năng lập phiếu chi!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
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

        private void cbDoituongTD_Validated(object sender, EventArgs e)
        {
            cbDoituongTD_SelectedIndexChanged(null, null);
        }
        private void dgGia_VisibleChanged(object sender, EventArgs e)
        {
            if (dgGia.Visible)
            {
                cbDoituongTD_Validated(null, null);
            }
        }
    }
}