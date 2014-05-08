using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmThutrongoi : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_cur_yy = "";
        private string m_id_gia = "",m_makp_khongkham="";
        private DateTime m_cur_ngay = DateTime.Now;
        private string m_cur_loaidv = "";
        private string m_cur_quyenso = "";
        
        private TableLayoutPanel m_table;

        private LibVP.AccessData m_v;
        private DataSet m_dshoadon;

        private string m_id = "", m_mavaovien = "", m_maql = "", m_userid = "", v_namBTDBN="";
        private DataSet m_dsgiavp;
        private DataSet m_dsgoivp;

        private frmChonvp m_frmchonvp;
        private frmDanhsachthutrongoi m_frmdanhsachthutrongoi;
        private frmDanhsachchothutrongoi m_frmdanhsachchothutrongoi;
        private frmTimhoadon m_frmtimhoadon;
        private frmTimbenhnhan m_frmtimbenhnhan;
        private frmHoantra m_frmhoantra;
        private frmPrintHD m_frmprinthd;

        //var
        private bool m_bnmoi = false;
        private int iSothang = 1;
        //option
        private bool m_o_fullscreen = false;
        public frmThutrongoi(LibVP.AccessData v_v, string v_userid)
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
                m_v.f_SetEvent(this);
                f_Load_Data();
                dgGia.Visible = false;
                
                m_o_fullscreen = m_v.get_o_fullscreen_frmthutrongoi(m_userid);
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
        private void frmThutrongoi_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    iSothang = int.Parse(m_v.sys_sothang);
                }
                catch { iSothang = 1; }
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Phải khai báo quyển sổ thu viện phí trước!") + "\n" + lan.Change_language_MessageText("Vào [Tiện ích] - [Khai báo quyển sổ] để khai!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Enable(false);
                    f_Enable_HC(false);
                    f_Enabled_VP(false);
                }
                cbLoaidv_SelectedIndexChanged(null,null);
                butMoi_Click(null, null);
                lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");
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
                foreach (DataRow r in m_v.get_data("select distinct hotkey, ghichu from medibv.v_optionhotkey" + atable + " where userid=" + m_userid + " and loai=3").Tables[0].Rows)
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
                tmn_Dungchungso.Checked = m_v.sys_dungchungso;
                m_makp_khongkham = m_v.sys_makp_khongkham;
                tmn_Dungchungso.Enabled = false;

                bool asys_suatuychon = m_v.sys_quyen_suatuychon(m_userid);
                tmn_Nhaplydomien.Enabled = asys_suatuychon;
                tmn_Nhapkymien.Enabled = asys_suatuychon;
                tmn_Chonhapmoi.Enabled = asys_suatuychon;
                tmn_Chokhongquatiepdon.Enabled = asys_suatuychon;
                tmn_Cokhambenh.Enabled = asys_suatuychon;
                tmn_Cophongluu.Enabled = asys_suatuychon;
                tmn_Conhanbenh.Enabled = asys_suatuychon;

                tmn_Cokhambenh.Checked = m_v.tg_cokhambenh(m_userid);
                tmn_Cophongluu.Checked = m_v.tg_conamluu(m_userid);
                tmn_Conhanbenh.Checked = m_v.tg_conhanbenh(m_userid);

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

                ads = m_v.get_data("select ma,hoten from medibv.dmbs order by hoten");
                r = ads.Tables[0].NewRow();
                r["ma"] = "0000";
                r["hoten"] = "";
                ads.Tables[0].Rows.InsertAt(r, 0);
                cbBacsi.DataSource = ads.Tables[0];
                cbBacsi.DisplayMember = "hoten";
                cbBacsi.ValueMember = "ma";

                cbDoituong.DataSource = m_v.get_data("select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong order by madoituong").Tables[0];
                cbDoituong.DisplayMember = "doituong";
                cbDoituong.ValueMember = "madoituong";

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

                sql = "select distinct a.id,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.bhyt from medibv.v_giavp a inner join medibv.v_trongoi b on a.id=b.id and b.id_gia=0 order by ten";
                dgGia.DataSource = m_v.get_data(sql).Tables[0];

                m_dsgiavp = m_v.get_data("select * from medibv.v_giavp order by id_loai, ten");
                m_dsgoivp = m_v.get_data("select a.id,a.stt,a.id_nhom,a.id_loai,a.sotien,b.ten from medibv.v_trongoi a inner join medibv.v_loaivp b on a.id_loai=b.id where id_gia=0 order by a.id,a.stt");

                sql = "select 0 as id, 0 as chon, 0 as mavp, '' as ma,'' as ten,0 as soluong,'' as dvt,'' as doituong, 0 as dongia, 0 as thanhtien, 0 as mien,0 as thucthu,0 as madoituong,'' as makp, '' as tenkp, '' as mabs,'' as tenbs, 0 as idcd";
                m_dshoadon = m_v.get_data(sql);
                m_dshoadon.Tables[0].Rows.Clear();
                
                dgHoadon.DataSource = m_dshoadon.Tables[0];

                sql = "select distinct a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs, trim(b.ten) as tenloai,b.id as id_loai, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id inner join medibv.v_trongoi c on a.id=c.id and c.id_gia=0 where a.loaitrongoi=1 order by ten,ma";
                m_frmchonvp = new frmChonvp(m_v, m_userid,"GIA_TH", m_v.get_data(sql),m_v.s_loaiform_thutrongoi);
                m_frmchonvp.s_multiline = m_v.get_o_multiline_frmchonvp(m_userid);
                m_frmchonvp.s_dshotkey = m_v.f_get_hotkey_frmthutrongoi(m_userid);
                m_frmchonvp.s_dshotkey_ksk = m_v.f_get_hotkey_ksk_frmthutrongoi(m_userid);
                m_frmchonvp.s_hotkey = "";
                m_frmchonvp.ShowInTaskbar = false;

                m_frmdanhsachthutrongoi = new frmDanhsachthutrongoi(m_v, m_userid);
                m_frmdanhsachthutrongoi.ShowInTaskbar = false;

                m_frmdanhsachchothutrongoi = new frmDanhsachchothutrongoi(m_v, m_userid);
                m_frmdanhsachchothutrongoi.ShowInTaskbar = false;
                
                m_frmtimbenhnhan = new frmTimbenhnhan(m_v, m_userid);
                m_frmtimbenhnhan.ShowInTaskbar = false;
                
                m_frmtimhoadon = new frmTimhoadon(m_v, m_userid);
                m_frmtimhoadon.ShowInTaskbar = false;
                m_frmtimhoadon.s_loaihd = "4";

                m_frmhoantra = new frmHoantra(m_v, m_userid);
                m_frmhoantra.ShowInTaskbar = false;
                m_frmhoantra.s_loaihd = "4";

                m_frmprinthd = new frmPrintHD(m_v,m_userid);

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmthutrongoi(m_userid);
                f_Set_Fullgrid();

                tmn_Hotkey_Show.Checked = m_v.get_o_show_hotkey_frmthutrongoi(m_userid);
                tmn_Hotkey_KSK_Show.Checked = m_v.get_o_show_hotkey_ksk_frmthutrongoi(m_userid);
                if (tmn_Hotkey_Show.Checked && tmn_Hotkey_KSK_Show.Checked)
                {
                    tmn_Hotkey_KSK_Show.Checked = false;
                    m_v.set_o_show_hotkey_ksk_frmthutrongoi(m_userid, false);
                }
                tmn_Hotkey_Addall.Checked = m_v.get_o_addall_hotkey_frmthutrongoi(m_userid);
                tmn_Show_Hotkey.Checked = m_v.get_o_show_hotkey_toolbar_frmthutrongoi(m_userid);
                tt_Hotkey.Visible = tmn_Show_Hotkey.Checked;
                f_Display();

                //Option
                tmn_Luuin_Hoadon.Checked = m_v.get_o_luuin_hoadon_frmthutrongoi(m_userid);
                tmn_Luuin_Hoadon_Chitiet.Checked = m_v.get_o_luuin_hoadon_chitiet_frmthutrongoi(m_userid);
                tmn_Luuin_Chiphi.Checked = m_v.get_o_luuin_chiphi_frmthutrongoi(m_userid);
                tmn_Luuin_Hoadon_Icon.Checked = m_v.get_o_luuin_frmthutrongoi(m_userid);
                tmn_Xemtruockhiin_Icon.Checked = m_v.get_o_xemtruockhiin_frmthutrongoi(m_userid);
                
                tmn_Nhapkhoaphong.Checked = m_v.tg_nhapkhoaphong(m_userid);
                tmn_Nhapbacsi.Checked = m_v.tg_nhapbacsi(m_userid);
                tmn_Nhaplydomien.Checked = m_v.tg_nhaplydomien(m_userid);
                tmn_Nhapkymien.Checked = m_v.tg_nhapduyetmien(m_userid);
                tmn_Chonhapmoi.Checked = m_v.tg_chonhapmoi(m_userid);
                tmn_Chokhongquatiepdon.Checked = m_v.tg_chokhongquatiepdon(m_userid);
            }
            catch
            {
            }
        }
        private void f_Load_Chitiet()
        {
            try
            {
                string aid = "";
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                aid = arv["mavp"].ToString();

                if (m_table != null && m_table.Name.Replace("tableLayoutPanel_", "") == aid)
                {
                    return;
                }
                pChitiet.Controls.Clear();
                Label alb;
                TextBox atb;

                m_table = new TableLayoutPanel();
                m_table.Name = "tableLayoutPanel_" + aid;
                m_table.Text = arv["ten"].ToString();
                m_table.AutoScroll = true;
                m_table.Dock = DockStyle.Fill;
                m_table.BorderStyle = BorderStyle.None;
                m_table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
                m_table.BackColor = Color.Honeydew;
                m_table.Size = Screen.PrimaryScreen.WorkingArea.Size;
                m_table.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                m_table.AutoSize = true;
                m_table.Click += new System.EventHandler(this.pChitiet_Click);

                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));

                int ai = 0, acol = 0, arow = 0, an = m_dsgoivp.Tables[0].Select("id=" + aid).Length / 4;
                if (an * 4 < m_dsgoivp.Tables[0].Select("id=" + aid).Length)
                {
                    an += 1;
                }
                foreach (DataRow r in m_dsgoivp.Tables[0].Select("id=" + aid, "stt"))
                {
                    ai++;
                    if (acol < 2)
                    {
                        m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
                    }

                    alb = new Label();
                    alb.Name = "lbma_" + r["id_loai"].ToString();
                    alb.Text = r["ten"].ToString().Trim() + ":";
                    alb.AutoSize = true;
                    alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                    alb.TextAlign = ContentAlignment.MiddleRight;
                    m_table.Controls.Add(alb, acol, arow);

                    atb = new TextBox();
                    atb.Name = "tbma_" + r["id_loai"].ToString();
                    atb.Text = decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.##");
                    atb.Width = 70;
                    atb.Leave += new System.EventHandler(this.f_Control_Leave);
                    atb.Enter += new System.EventHandler(this.f_Control_Enter);
                    atb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                    atb.Validated += new System.EventHandler(this.txt_Validated);
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

                pChitiet.Controls.Add(m_table);
            }
            catch
            {
            }
            finally
            {
                f_Tinhtien();
            }
        }
        private void f_Load_Chitiet(string v_mmyy, string v_id)
        {
            try
            {
                pChitiet.Controls.Clear();
                string aid = v_id;
                Label alb;
                TextBox atb;

                m_table = new TableLayoutPanel();
                m_table.Name = "tableLayoutPanel_" + aid;
                m_table.Text = "";
                m_table.AutoScroll = true;
                m_table.Dock = DockStyle.Fill;
                m_table.BorderStyle = BorderStyle.None;
                m_table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
                m_table.BackColor = Color.Honeydew;
                m_table.Size = Screen.PrimaryScreen.WorkingArea.Size;
                m_table.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                m_table.AutoSize = true;
                m_table.Click += new System.EventHandler(this.pChitiet_Click);

                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));

                DataSet ads = m_v.get_data_mmyy(v_mmyy, "select a.ma as id, b.ten, a.sotien from medibvmmyy.v_nhom a left join medibv.v_loaivp b on a.ma=b.id where a.id=" + v_id);
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
                    alb.Text = r["ten"].ToString().Trim() + ":";
                    alb.AutoSize = true;
                    alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                    alb.TextAlign = ContentAlignment.MiddleRight;
                    m_table.Controls.Add(alb, acol, arow);

                    atb = new TextBox();
                    atb.Name = "tbma_" + r["id"].ToString();
                    atb.Text = decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.##");
                    atb.Width = 70;
                    atb.Leave += new System.EventHandler(this.f_Control_Leave);
                    atb.Enter += new System.EventHandler(this.f_Control_Enter);
                    atb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                    atb.Validated += new System.EventHandler(this.txt_Validated);
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

                pChitiet.Controls.Add(m_table);
            }
            catch
            {
            }
            finally
            {
                f_Tinhtien();
            }
        }
        public void f_Control_Enter(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                c.BackColor = Color.LightYellow;
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
                c.BackColor = Color.White;//GhostWhite;
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
                        if (toolStrip_Mien.ReadOnly == false)
                        {
                            toolStrip_Mien.Focus();
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
                    v_namBTDBN = r["nam"].ToString();
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
                        MessageBox.Show(this, lan.Change_language_MessageText("Không cho phép bệnh nhân chưa hoàn tất thủ tục!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                
                chkPM.Checked = false;
                chkYC.Checked = false;

                f_Tinhtien();
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
                txtTenvp.Enabled = v_bool;
                txtSoluong.Enabled = v_bool;
                txtDongia.Enabled = v_bool;
                cbKhoa.Enabled = v_bool;
                cbBacsi.Enabled = v_bool;

                txtLydomien.Enabled = v_bool && tmn_Nhaplydomien.Checked;
                cbLydomien.Enabled = v_bool && tmn_Nhaplydomien.Checked;

                txtKymien.Enabled = v_bool && tmn_Nhapkymien.Checked;
                cbKymien.Enabled = v_bool && tmn_Nhapkymien.Checked;

                butAdd.Enabled = v_bool;
                butRem.Enabled = v_bool;
                butChon.Enabled = v_bool;

                toolStrip_Mien.ReadOnly = !v_bool;
                toolStrip_Tamung.ReadOnly = !v_bool;

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

                f_FullScreen(m_o_fullscreen);
                m_bnmoi = true;
                m_id = "";
                v_namBTDBN = "";
                m_mavaovien = "";
                m_maql = "";
                m_id_gia = "";

                m_dshoadon.Tables[0].Rows.Clear();
           
                f_Load_Chitiet();
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy quyển sổ thu viện phí!") + "\n" + lan.Change_language_MessageText("Đề nghị chọn sổ"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string atmp="",aidcd="",amakp_ll="";
                butLuu.Enabled = false;

                if (m_dshoadon.Tables[0].Rows.Count <= 0 || toolStrip_Tongcong.Text=="0" || toolStrip_Tongcong.Text=="")
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập nội dung thu viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenvp.Focus();
                    return;
                }
                if (toolStrip_Mien.Text != "0" && tmn_Nhaplydomien.Checked && cbLydomien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập lý do miễn giảm!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLydomien.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (toolStrip_Mien.Text != "0" && tmn_Nhapkymien.Checked && cbKymien.SelectedIndex <= 0)
                {
                    f_FullScreen(false);
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập người duết miễn giảm!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị nhập người duyệt miễn giảm!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKymien.Focus();
                    SendKeys.Send("{F4}");
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn quyển sổ thu viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                amakp_ll = amakp;
                if (amakp == "" || amakp == "00")
                {
                    amakp_ll = m_makp_khongkham;
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
                if(cbQuan.Text.ToUpper().Trim() != lan.Change_language_MessageText("KHÔNG XÁC ĐỊNH"))
                {
                    if(adiachi!="")
                    {
                        adiachi += ", ";
                    }
                    adiachi += cbQuan.Text.Trim();
                }
                if(cbTinh.Text.ToUpper().Trim() != lan.Change_language_MessageText("KHÔNG XÁC ĐỊNH"))
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
                        MessageBox.Show(this, lan.Change_language_MessageText("Không cập nhật được thông tin bệnh nhân!") + "\n" + lan.Change_language_MessageText("Chưa lưu hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (amaql == "" || amaql=="0")
                {
                    try
                    {
                        //Luu tiep don
                        amaql = m_v.upd_tiepdon(amabn,0, 0, amakp_ll,angay, decimal.Parse(cbDoituongTD.SelectedValue.ToString()), "0000000000", txtTuoi.Text.PadLeft(4,'0'), 1, 7, 0,-1).ToString();
                    }
                    catch
                    {
                    }
                }
                if (amaql == "" || amaql=="0")
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Không cập nhật được thông tin tiếp đón!") + "\n" + lan.Change_language_MessageText("Chưa lưu hoá đơn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (amavaovien == "")
                {
                    amavaovien = amaql;
                }

                asobienlai = txtSobienlai.Text.Trim();
                if (aid != "0")
                {
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_nhom where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_trongoi where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_vienphict where id = " + aid);
                    m_v.execute_data_mmyy(ammyy, "delete from medibvmmyy.v_mienngtru where id = " + aid);
                }
                aid = m_v.upd_v_vienphill(ammyy,decimal.Parse(aid),decimal.Parse(aquyenso),decimal.Parse(asobienlai),angay,amabn,decimal.Parse(amavaovien),decimal.Parse(amaql),decimal.Parse(aidkhoa),amakp_ll,ahoten,anamsinh,adiachi,decimal.Parse(aloai),decimal.Parse(aloaibn),decimal.Parse(auserid),decimal.Parse(cbGioitinh.SelectedValue.ToString()),txtghichu.Text.Trim(),"",0,0,0,"");
                m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);

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
                    m_v.upd_v_mienngtru(ammyy, decimal.Parse(aid), decimal.Parse(alydomien), decimal.Parse(toolStrip_Mien.Text.Trim().Replace(",", "")), "Miển giảm thu trọn gói", decimal.Parse(amaduyet));
                }
                if (aid != "0")
                {
                    decimal astt=1;
                    foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                    {
                        try
                        {
                            m_v.upd_v_vienphict("v_vienphict",ammyy, decimal.Parse(aid), astt, decimal.Parse(r["madoituong"].ToString()), r["makp"].ToString().Trim() != "" ? r["makp"].ToString().Trim() : amakp_ll, r["ten"].ToString(), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()),0, decimal.Parse(r["mien"].ToString()), 0, 0, r["mabs"].ToString(),0,0);
                            astt += 1;
                            //update paid chi dinh
                            if (r["idcd"].ToString().Trim() != "0" && r["idcd"].ToString().Trim() != "")
                            {
                                aidcd += ",";
                                aidcd += r["idcd"].ToString();
                            }
                        }
                        catch
                        {
                        }
                    }
                    decimal agiact = 0;
                    m_v.upd_v_trongoi(ammyy, decimal.Parse(aid), decimal.Parse(toolStrip_Tongcong.Text.Replace(" ", "")), decimal.Parse(toolStrip_Tamung.Text.Replace(" ", "")), lbBNtra.Text != lan.Change_language_MessageText("BN Trả:")?decimal.Parse(toolStrip_Tamung.Text.Replace(" ", "")):0,chkPM.Checked?1:0,chkYC.Checked?1:0,m_dshoadon.Tables[0].Rows[0]["ten"].ToString().Trim());
                    foreach (Control c in m_table.Controls)
                    {
                        if(c.Name.IndexOf("tbma_")==0)
                        {
                            try
                            {
                                agiact = decimal.Parse(c.Text.Replace(",", ""));
                            }
                            catch
                            {
                                agiact = 0;
                            }
                            m_v.upd_v_nhom(ammyy, decimal.Parse(aid), decimal.Parse(c.Name.Replace("tbma_", "")),agiact);
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
                    sql = "update medibvmmyy.v_chidinh set paid = 1 where id in(" + aidcd + ")";
                    m_v.execute_data(atn, angay.Substring(0, 10), sql);
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
                        if (tmn_Luuin_Hoadon_Chitiet.Checked)
                        {
                            if (asua)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại hoá đơn vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inhoadonchitiet();
                                }
                            }
                            else
                            {
                                f_Inhoadonchitiet();
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
            catch
            {
            }
        }
        private void f_Sua()
        {
            try
            {
                if (m_v.tg_suahoadon(m_userid))
                {
                    if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                    {
                        MessageBox.Show(this,
                            lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép sửa.") +
                            "\n"+ lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa.")+"\n"+lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (m_v.tg_xoahoadon(m_userid))
                {
                    string ammyy = txtNgaythu.Value.Month.ToString().PadLeft(2, '0') + txtNgaythu.Value.Year.ToString().Substring(2);
                    if (m_v.dadung_v_vienphill(ammyy, m_id) != 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá hoá đơn này!") + "\n" + lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Hoá đơn đã in không được xoá, chỉ được phép hoàn trả") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép sửa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                            if (MessageBox.Show(this, lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Nếu xoá xem như hoá đơn chưa phát sinh, sẽ không có trong báo cáo") + "\n" + lan.Change_language_MessageText("Nếu hoàn xem như hoá đơn đã phát sinh và không có giá trị sử dụng, có trong báo cáo hoàn.") + "\n" + lan.Change_language_MessageText("Đồng ý xoá hoá đơn này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            if (!m_v.del_v_vienphill(ammyy, m_id))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá hoá đơn này!") + "\n" + lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Hoá đơn đã in không được xoá, chỉ được phép hoàn trả") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền xóa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    m_frmprinthd.f_Print_BienlaiKB_Trongoi(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
                }
            }
            catch
            {
            }
        }
        private void f_Inhoadonchitiet()
        {
            try
            {
                if (m_id != "")
                {
                    m_frmprinthd.f_Print_BienlaiKB_Trongoi_Chitiet(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), "1");
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
                //m_frmprint.f_Print_ChiphiKBCT(!tmn_Xemtruockhiin.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)));
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
                m_frmhoantra.s_loaihd = m_v.s_loaiform_thutrongoi;
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
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituong.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r = dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString())[0];
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
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbDoituong.DataSource]);
                DataView dv = (DataView)(cm.List);
                DataRow r = dv.Table.Select("madoituong=" + cbDoituong.SelectedValue.ToString())[0];
                string adoituong = cbDoituong.SelectedValue.ToString();
                string afieldgia = r["field_gia"].ToString().Trim();
                string amien100 = r["mien"].ToString();
                decimal adongia = 0, asoluong = 0, amien = 0, athucthu = 0;
                m_dshoadon.Tables[0].Rows.Clear();
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
                        toolStrip_Mien.Text = amien.ToString("### ### ##0.##");
                        amien = 0;
                        athucthu = asoluong * adongia - amien;
                        DataRow r2 = m_dshoadon.Tables[0].NewRow();
                        r2["id"] = 0;
                        r2["chon"] = 1;
                        r2["idcd"] = 0;
                        r2["mavp"] = r1["id"].ToString();
                        r2["ma"] = r1["ma"].ToString();
                        r2["ten"] = r1["ten"].ToString();
                        r2["dvt"] = r1["dvt"].ToString();
                        r2["soluong"] = asoluong;
                        r2["dongia"] = adongia;
                        r2["mien"] = 0;// amien;
                        r2["thucthu"] = athucthu;
                        r2["madoituong"] = adoituong;
                        r2["doituong"] = cbDoituong.Text.Trim();
                        try
                        {
                            r2["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                        }
                        catch
                        {
                            r2["makp"] = "";
                        }
                        r2["tenkp"] = cbKhoa.Text.Trim();
                        try
                        {
                            r2["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                        }
                        catch
                        {
                            r2["mabs"] = "";
                        }
                        r2["tenbs"] = cbBacsi.Text.Trim();
                        m_dshoadon.Tables[0].Rows.Add(r2);
                    }
                    if (m_dshoadon.Tables[0].Rows.Count > 0)
                    {
                        f_Load_Chitiet();
                        break;
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
                m_dshoadon.Tables[0].Rows.Clear();
                decimal adongia = 0, asoluong = 0, amien = 0, athucthu = 0;
                adongia = 0;
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
                amien = 0;
                athucthu = asoluong * adongia - amien;

                DataRow arv = m_dsgiavp.Tables[0].Select("id="+m_id_gia)[0];

                DataRow r = m_dshoadon.Tables[0].NewRow();
                r["id"] = 0;
                r["chon"] = 1;
                r["idcd"] = 0;
                r["mavp"] = arv["id"].ToString();
                r["ma"] = arv["ma"].ToString();
                r["ten"] = arv["ten"].ToString();
                r["dvt"] = arv["dvt"].ToString();
                r["soluong"] = asoluong;
                r["dongia"] = adongia;
                r["mien"] = 0;
                r["thucthu"] = athucthu;
                r["madoituong"] = cbDoituong.SelectedValue.ToString();
                r["doituong"] = cbDoituong.Text.Trim();
                try
                {
                    r["makp"] = cbKhoa.SelectedValue.ToString().Trim();
                }
                catch
                {
                    r["makp"] = "";
                }
                r["tenkp"] = cbKhoa.Text.Trim();
                try
                {
                    r["mabs"] = cbBacsi.SelectedValue.ToString().Trim();
                }
                catch
                {
                    r["mabs"] = "";
                }
                r["tenbs"] = cbBacsi.Text.Trim();
                
                m_dshoadon.Tables[0].Rows.Add(r);

                f_Load_Chitiet();
                //m_id_gia = "";
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
                f_Load_Chitiet();
                f_Tinhtien();
            }
            catch
            {
            }
        }
        private decimal f_Sum_Gia()
        {
            try
            {
                decimal asotien = 0, atmp = 0;
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        try
                        {
                            atmp = decimal.Parse(c.Text.Replace(",", ""));
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        c.Text = atmp.ToString("###,###,##0.##");
                        asotien += atmp;
                    }
                }
                return asotien;
            }
            catch
            {
                return 0;
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
        private void f_Tinhtien()
        {
            try
            {
                decimal adongia = 0, asoluong = 0, atongcong = 0, atongmien = 0, atongthu = 0,atamung=0;
                adongia = f_Sum_Gia();
                txtDongia.Text = adongia.ToString("###,###,##0.##");
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
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
                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["mien"] = 0;
                    r["thanhtien"] = asoluong*adongia;
                    r["thucthu"] = asoluong * adongia;
                }
                m_dshoadon.AcceptChanges();

                try
                {
                    atongmien = decimal.Parse(toolStrip_Mien.Text.Trim().Replace(" ", ""));
                    if (atongmien < 0)
                    {
                        atongmien = 0;
                    }
                }
                catch
                {
                    atongmien = 0;
                }
                atongcong = asoluong * adongia;
                if (atongcong < atongmien)
                {
                    atongmien = 0;
                }
                toolStrip_Mien.ReadOnly = (!butLuu.Enabled);
                try
                {
                    atamung = decimal.Parse(toolStrip_Tamung.Text.Trim().Replace(" ", ""));
                    if (atamung < 0)
                    {
                        atamung = 0;
                    }
                }
                catch
                {
                    atamung = 0;
                }
                if (atongcong <= 0)
                {
                    atamung = 0;
                }
                atongthu = atongcong - atongmien;

                toolStrip_Tongcong.Text = atongcong.ToString("###,###,##0.##").Trim();
                toolStrip_Tongcong.ToolTipText = m_v.Doiso_Unicode(atongcong.ToString("##########")).Replace("  "," ");
                
                toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##").Trim();
                toolStrip_Mien.ToolTipText = m_v.Doiso_Unicode(atongmien.ToString("##########")).Replace("  ", " ");

                toolStrip_Tamung.Text = atamung.ToString("###,###,##0.##").Trim();
                toolStrip_Tamung.ToolTipText = m_v.Doiso_Unicode(atamung.ToString("##########")).Replace("  ", " ");

                if (atamung > 0)
                {
                    atongthu -= atamung; 
                }

                if (atongthu < 0)
                {
                    lbBNtra.Text = 
lan.Change_language_MessageText("BV Hoàn:");
                    atongthu = atongthu * -1;
                }
                else
                {
                    lbBNtra.Text = 
lan.Change_language_MessageText("BN Trả:");
                }
                toolStrip_Thucthu.Text = atongthu.ToString("###,###,##0.##").Trim();
                toolStrip_Thucthu.ToolTipText = m_v.Doiso_Unicode(atongthu.ToString("##########")).Replace("  ", " "); 
            }
            catch
            {
                toolStrip_Tongcong.Text = "0";
                toolStrip_Tongcong.ToolTipText = lan.Change_language_MessageText("Không đồng");
                
                toolStrip_Mien.Text = "0";
                toolStrip_Mien.ToolTipText = lan.Change_language_MessageText("Không đồng");

                toolStrip_Tamung.Text = "0";
                toolStrip_Tamung.ToolTipText = lan.Change_language_MessageText("Không đồng");

                toolStrip_Thucthu.Text = "0";
                toolStrip_Thucthu.ToolTipText = lan.Change_language_MessageText("Không đồng");

            }
        }
        private void f_Load_Thutrongngay()
        {
            try
            {
                string sql = "", ammyy = "";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                decimal asotien = 0, amien = 0, ahoan=0, asohd=0;
                sql = "select sum(b.soluong*b.dongia-b.thieu) as sotien from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id inner join medibvmmyy.v_trongoi b1 on a.id=b1.id where a.userid="+m_userid+" and to_char(a.ngay,'dd/mm/yyyy')='"+txtNgaythu.Text.Substring(0,10)+"'";
                try
                {
                    asotien = decimal.Parse(m_v.get_data_mmyy(ammyy,sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    asotien = 0;
                }

                sql = "select sum(b.sotien) as sotien from medibvmmyy.v_vienphill a left join medibvmmyy.v_mienngtru b on a.id=b.id inner join medibvmmyy.v_trongoi b1 on a.id=b1.id where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                try
                {
                    amien = decimal.Parse(m_v.get_data_mmyy(ammyy,sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    amien = 0;
                }

                sql = "select count(distinct a.id) as sohd from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id inner join medibvmmyy.v_trongoi b1 on a.id=b1.id where a.userid=" + m_userid + " and to_char(a.ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                try
                {
                    asohd = decimal.Parse(m_v.get_data_mmyy(ammyy, sql).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    asohd = 0;
                }

                asotien = asotien - amien - ahoan;

                tmn_Tongthu.Text = asohd.ToString() + "=" + asotien.ToString("###,###,##0.##") + 
lan.Change_language_MessageText("đ");
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
                sql = "select a.mabn,a.mavaovien,a.maql,b1.tamung,b2.sotien as tongmien,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.quyenso,a.sobienlai,a.loai,a.loaibn,a.id, case when b.lanin <> 0 then 1 else 0 end as chon, b.mavp, c.ma,c.ten,b.soluong,c.dvt,d.doituong,b.dongia,b.soluong*b.dongia as thanhtien, b.mien,b.soluong*b.dongia-b.mien as thucthu,b.madoituong,b.makp, e.tenkp, b.mabs,f.hoten as tenbs, 0 as idcd from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru b2 on a.id=b2.id left join medibv.v_giavp c on b.mavp=c.id left join medibv.doituong d on b.madoituong=d.madoituong left join medibv.btdkp_bv e on b.makp=e.makp left join medibv.dmbs f on b.mabs=f.ma where a.id = " + v_id;
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
                        toolStrip_Mien.Text = decimal.Parse(ads.Tables[0].Rows[0]["tongmien"].ToString()).ToString("### ### ##0.##");
                    }
                    catch
                    {
                        toolStrip_Mien.Text = "0";
                    }

                    try
                    {
                        toolStrip_Tamung.Text = decimal.Parse(ads.Tables[0].Rows[0]["tamung"].ToString()).ToString("### ### ##0.##");
                    }
                    catch
                    {
                        toolStrip_Tamung.Text = "0";
                    }

                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("mavaovien");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loai");
                    ads.Tables[0].Columns.Remove("loaibn");
                    ads.Tables[0].Columns.Remove("ngay");
                    ads.Tables[0].Columns.Remove("tamung");
                    ads.Tables[0].Columns.Remove("tongmien");
                    m_dshoadon = ads;
                    dgHoadon.DataSource = m_dshoadon.Tables[0];
                    dgHoadon.Update();
                    f_Load_Chitiet(ammyy,v_id);
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
                        asobienlai = decimal.Parse(m_v.get_data_mmyy(ammyy,"select sobienlai from medibvmmyy.v_vienphill where id = " + m_id).Tables[0].Rows[0][0].ToString()).ToString();
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
                sql = "select a.id from medibvmmyy.v_vienphill a inner join medibv.v_trongoi b on a.id=b.id where " + aexp;
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy hoá đơn ") + (v_pre < 0 ? "trước" : "sau") + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string sql = "",aexp="";
                v_tn = m_v.f_string_date(v_tn);
                if (v_tn.Length >= 10)
                {
                    v_tn = v_tn.Substring(0, 10);
                }
                else
                {
                    v_tn = txtNgaythu.Text.Substring(0, 10);
                }
                aexp = " where b.loaitrongoi=1 and a.paid=0 and a.maql = " + v_maql;
                sql = "select 0 as id, 1 as chon, a.mavp, b.ma,b.ten,a.soluong,b.dvt,c.doituong,a.dongia,a.soluong*a.dongia as thanhtien, 0 as mien,a.soluong*a.dongia as thucthu,a.madoituong,a.makp, d.tenkp, e.mabs,f.hoten as tenbs, a.id as idcd from medibvmmyy.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id left join medibv.doituong c on a.madoituong=c.madoituong left join medibv.btdkp_bv d on a.makp=d.makp left join medibv.dlogin e on a.userid=e.id left join medibv.dmbs f on e.mabs=f.ma " + aexp;
                DataSet ads = m_v.get_data_bc_1(v_tn,txtNgaythu.Text.Substring(0,10), sql);
                if (ads != null)
                {
                    m_dshoadon = ads;
                  
                    dgHoadon.DataSource = ads.Tables[0];
                    dgHoadon.Update();
                    f_Tinhtien();
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

                asql1 = "select maql, maql as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(0,9) as loaibn from medibvmmyy.tiepdon where mabn='" + amabn + "'";
                if (tmn_Cokhambenh.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number(3,9) as loaibn  from medibvmmyy.benhanpk where mabn='" + amabn + "'";
                }
                if (tmn_Cophongluu.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(4,9) as loaibn from medibvmmyy.benhancc where mabn='" + amabn + "'";
                }
                DataSet ads = null, ads1 = null;
                if (asql1 != "")
                {
                    asql1 += "  order ngay1 desc";
                    ads = m_v.get_data_bc(adt.AddMonths(-iSothang ), txtNgaythu.Value.AddMonths(1), asql1);
                }
                if (tmn_Conhanbenh.Checked)
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
                    f_Tinhtien_mon();
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
                    f_Tinhtien_mon();
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
                        butAdd_Click(null,null);
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
                    f_Tinhtien_mon();
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
                    cbDoituong.SelectedValue = r["madoituong"].ToString();
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
            if (!tmn_Luuin_Hoadon.Checked && !tmn_Luuin_Hoadon_Chitiet.Checked)
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Chọn loại hoá đơn cần in từ [Tùy chọn]!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tmn_Luuin_Hoadon.Checked)
            {
                f_Inhoadon();
            }
            if (tmn_Luuin_Hoadon_Chitiet.Checked)
            {
                f_Inhoadonchitiet();
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

        private void frmThutrongoi_SizeChanged(object sender, EventArgs e)
        {
            f_Display();
        }

        private void cbNgayvv_Validated(object sender, EventArgs e)
        {
            try
            {
                cbNgayvv_SelectedIndexChanged(null, null);
                f_Load_BHYT();
                if (m_dshoadon.Tables[0].Rows.Count <= 0 && butLuu.Enabled && (m_id == "" || m_id == "0") && tmn_Thuchidinh.Checked && cbNgayvv.Items.Count > 0)
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

        private void frmThutrongoi_VisibleChanged(object sender, EventArgs e)
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
                if (txtSoluong.Text == "" || txtSoluong.Text == "0")
                {
                    txtSoluong.Text = "1";
                }
                f_Add();
                m_table.Controls[1].Focus();
                //txtTenvp.Text = "";
                //txtSoluong.Text = "1";
                //txtDongia.Text = "0";
                //txtThucthu.Text = "0";
                //f_Filter_Giavp();
                //txtTenvp.Focus();
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

        private void txtDongia_Validated(object sender, EventArgs e)
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

        private void frmThutrongoi_KeyDown(object sender, KeyEventArgs e)
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
                pHanhchanh.Height = v_bool?25:159;
            }
            catch
            {
            }
        }
        
        private void toolStrip_Title_Click(object sender, EventArgs e)
        {
            try
            {
                pHanhchanh.Height = (pHanhchanh.Height > 100)?25:159;
                m_v.set_o_fullscreen_frmthutrongoi(m_userid, pHanhchanh.Height > 100 ? false : true);
                m_o_fullscreen = m_v.get_o_fullscreen_frmthutrongoi(m_userid);
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
                    MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                m_frmdanhsachchothutrongoi.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachchothutrongoi.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachchothutrongoi.s_mabn != "")
                    {
                        string atmp = m_frmdanhsachchothutrongoi.s_mabn;
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                        if (m_frmdanhsachchothutrongoi.s_maql != "")
                        {
                            f_Load_CB_Ngayvv(m_frmdanhsachchothutrongoi.s_ngaycd, m_frmdanhsachchothutrongoi.s_maql);
                            f_Load_Chidinh(m_frmdanhsachchothutrongoi.s_ngaycd, m_frmdanhsachchothutrongoi.s_maql);
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
                m_frmtimhoadon.s_loaihd = "4";
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
                m_frmdanhsachthutrongoi.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachthutrongoi.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachthutrongoi.s_id != "")
                    {
                        m_id = m_frmdanhsachthutrongoi.s_id;
                        f_Load_Hoadon(m_id, m_v.get_mmyy(m_frmdanhsachthutrongoi.s_ngaythu));
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
                if (tmn_Thuchidinh.Checked)
                {
                    if (cbNgayvv.Items.Count > 0 && tmn_Thuchidinh.Checked)
                    {
                        f_Load_Chidinh(cbNgayvv.Text.Substring(0, 10), cbNgayvv.SelectedValue.ToString());
                    }
                }
                else
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Tùy chọn thu theo chỉ định chưa được bật!") + "\n" + lan.Change_language_MessageText("Có muốn bật chế độ thu theo chỉ định của bác sĩ không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                            MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sử dụng chức năng này!") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hki cần!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                //dgHoadon.Columns["Column1_5"].Frozen = !tmn_Fullgrid.Checked;
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
                m_v.set_o_fullgrid_frmthutrongoi(m_userid, tmn_Fullgrid.Checked);
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
                m_v.set_o_show_hotkey_frmthutrongoi(m_userid, tmn_Hotkey_Show.Checked);
                m_v.set_o_show_hotkey_ksk_frmthutrongoi(m_userid, tmn_Hotkey_KSK_Show.Checked);
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
                m_v.set_o_show_hotkey_frmthutrongoi(m_userid, tmn_Hotkey_Show.Checked);
                m_v.set_o_show_hotkey_ksk_frmthutrongoi(m_userid, tmn_Hotkey_KSK_Show.Checked);
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
                m_v.set_o_show_hotkey_toolbar_frmthutrongoi(m_userid, tmn_Show_Hotkey.Checked);
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
            m_v.set_o_luuin_hoadon_frmthutrongoi(m_userid,tmn_Luuin_Hoadon.Checked);
        }
        private void tmn_Luuin_Hoadon_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_frmthutrongoi(m_userid, tmn_Luuin_Hoadon_Icon.Checked);
        }

        private void tmn_Xemtruockhiin_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_xemtruockhiin_frmthutrongoi(m_userid, tmn_Xemtruockhiin_Icon.Checked);
        }
        private void tmn_Luuin_Chiphi_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_chiphi_frmthutrongoi(m_userid,tmn_Luuin_Chiphi.Checked);
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

        private void tmn_Hotkey_Addall_Click(object sender, EventArgs e)
        {
            m_v.set_o_addall_hotkey_frmthutrongoi(m_userid, tmn_Hotkey_Addall.Checked);
        }

        private void tmn_Show_Hotkey_Click(object sender, EventArgs e)
        {
            m_v.set_o_show_hotkey_toolbar_frmthutrongoi(m_userid, tmn_Show_Hotkey.Checked);
            f_Load_Hotkey();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThutrongoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý kết thúc chức năng thu trọn gói!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
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

        private void toolStrip_Tamung_KeyDown(object sender, KeyEventArgs e)
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
        private void toolStrip_Tamung_Validated(object sender, EventArgs e)
        {
            f_Tinhtien();
        }
        private void pChitiet_Click(object sender, EventArgs e)
        {
            dgGia.Visible = false;
        }

        private void chkPM_KeyDown(object sender, KeyEventArgs e)
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

        private void chkYC_KeyDown(object sender, KeyEventArgs e)
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

        private void tmn_Luuin_Hoadon_Chitiet_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_hoadon_chitiet_frmthutrongoi(m_userid, tmn_Luuin_Hoadon_Chitiet.Checked);
        }
    }
}