using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Vienphi
{
    public partial class frmThutamung : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_cur_yy = "";
        private DateTime m_cur_ngay = DateTime.Now;
        private string m_cur_loaidv = "";
        private string m_cur_quyenso = "";

        private TableLayoutPanel m_table;
        private string m_id = "", m_mavaovien = "", m_maql = "", m_userid = "", m_idkhoa = "";
        private LibVP.AccessData m_v;
        private int i_maxlength_mabn = 8;
        private bool bKhongchoxem_tongthu = false, bchondoituong = false, bQuanly_Theo_Chinhanh = false,m_Docmavach = false;

        private DataSet m_dshoadon;
        private DataSet m_dsdanhsach;

        //private frmDanhsachthutamung m_frmdanhsachthutamung;
        //private frmDanhsachchothutamung m_frmdanhsachchothutamung;
        //private frmTimhoadon m_frmtimhoadon;
        //private frmTimbenhnhan m_frmtimbenhnhan;
        //private frmHoantra m_frmhoantra;
        private frmPrintHD m_frmprinthd;

        //var
        private bool m_bnmoi = false;
        //option
        private int itablell,iSothang=1;
        private decimal idduyet = 0;
        private bool bLoadLanvao_saucung = true;
        public frmThutamung(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Read_dtgrid_to_Xml(dgDanhsach, this.Name + "_" + "dgDanhsach");
                lan.Change_dtgrid_HeaderText_to_English(dgDanhsach, this.Name + "_" + "dgDanhsach");

                m_v = v_v;
                m_userid = v_userid;
                
                m_v.f_SetEvent(this);
                f_Load_Data();
            }
            catch
            {
            }
        }

        private DateTime f_Cur_Date(string v_ngay)
        {
            try
            {
                return new DateTime(int.Parse(v_ngay.Substring(6, 4)), int.Parse(v_ngay.Substring(3, 2)), int.Parse(v_ngay.Substring(0, 2)), int.Parse(DateTime.Now.Hour.ToString()), int.Parse(DateTime.Now.Minute.ToString()), 0, 0);
            }
            catch
            {
                return DateTime.Now;
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
        private void frmThutamung_Load(object sender, EventArgs e)
        {
            try
            {
                i_maxlength_mabn = LibVP.AccessData.i_maxlength_mabn;
                bQuanly_Theo_Chinhanh = m_v.bQuanly_Theo_Chinhanh;
                m_Docmavach = m_v.tt_Quanlymavach(m_userid);
                if (m_Docmavach)
                {
                    txtMabn.MaxLength = i_maxlength_mabn;
                    txtMabn1.MaxLength = i_maxlength_mabn;
                }
                //string s_mask="";
                //if (bQuanly_Theo_Chinhanh)
                //{
                //    txtMabn1.Mask = s_mask.PadLeft(6, '0');
                //}
                //else
                //{
                //    txtMabn1.Mask = s_mask.PadLeft(6 , '0');
                //}
                //
                m_v.execute_data("delete from medibv.dmtables where tables='v_tamung'");
                itablell = m_v.tableid(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 16)), "v_tamung");
                f_Load_DG_Hoadon();
                f_Load_DG_Danhsach();
                f_Enable(false);
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
                }
                cbLoaidv_SelectedIndexChanged(null,null);
                //
                try
                {
                    iSothang = int.Parse(m_v.sys_sothang);
                }
                catch { iSothang = 1; }
                //
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
                tmn_Nhapsotienchitiet.Enabled = false;
                tmn_Nhapsotienchitiet.Checked = m_v.sys_nhapsotienchitiet_tu;

                bool asys_suatuychon = m_v.sys_quyen_suatuychon(m_userid);
                tmn_Cotiepdon.Enabled = asys_suatuychon;
                tmn_Cokhambenh.Enabled = asys_suatuychon;
                tmn_Cophongluu.Enabled = asys_suatuychon;
                tmn_Conhanbenh.Enabled = asys_suatuychon;
                tmn_ngoaitru.Enabled = asys_suatuychon;

                tmn_Cotiepdon.Checked = m_v.tu_cotiepdon(m_userid);
                tmn_Cokhambenh.Checked = m_v.tu_cokhambenh(m_userid);
                tmn_Cophongluu.Checked = m_v.tu_conamluu(m_userid);
                tmn_Conhanbenh.Checked = m_v.tu_conhanbenh(m_userid);
                tmn_ngoaitru.Checked = m_v.tu_congoaitru(m_userid);

                if (!tmn_Cotiepdon.Checked && !tmn_Cokhambenh.Checked && ! tmn_Cophongluu.Checked && !tmn_Conhanbenh.Checked && !tmn_ngoaitru.Checked)
                {
                    tmn_Conhanbenh.Checked = true;
                    m_v.upd_v_optionform(decimal.Parse(m_userid), 1, "TU_008", lan.Change_language_MessageText("Có nhận bệnh"), "1");
                }
                tmn_Xemlaihoadon.Checked = m_v.get_o_xemlaihoadon_frmthutamung(m_userid);
                tmn_Xemlaidanhsach.Checked = m_v.get_o_xemlaidanhsach_frmthutamung(m_userid);


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

                cbKhoaTD.DataSource = ads.Tables[0];
                cbKhoaTD.DisplayMember = "tenkp";
                cbKhoaTD.ValueMember = "makp";

                cbKhoa.DataSource = ads.Tables[0].Copy();
                cbKhoa.DisplayMember = "tenkp";
                cbKhoa.ValueMember = "makp";

                cbDoituong.DataSource = m_v.get_data("select madoituong,doituong,field_gia,mien from medibv.doituong order by madoituong").Tables[0];
                cbDoituong.DisplayMember = "doituong";
                cbDoituong.ValueMember = "madoituong";

                cbDoituongTD.DataSource = m_v.get_data("select madoituong,doituong from medibv.doituong order by madoituong").Tables[0];
                cbDoituongTD.DisplayMember = "doituong";
                cbDoituongTD.ValueMember = "madoituong";

                cbLoaidv.DataSource = m_v.get_data("select ma,ten from medibv.v_tenloaivp order by ma").Tables[0];
                cbLoaidv.DisplayMember = "ten";
                cbLoaidv.ValueMember = "ma";
                
                sql = "select id,sohieu,loai,userid,* from medibv.v_quyenso";
                if (!tmn_Dungchungso.Checked)
                {
                    sql += " where userid = " + m_userid;
                }
                sql += " order by ngayud desc";
                cbKyhieu.DataSource = m_v.get_data(sql).Tables[0];
                cbKyhieu.DisplayMember = "sohieu";
                cbKyhieu.ValueMember = "id";

                string sql1 = "";
                sql = "select id, stt, ten from medibv.v_loaibn";
                if (tmn_Cotiepdon.Checked) sql1 += "0";
                if (tmn_Cokhambenh.Checked) sql1 += ",3";
                if (tmn_Cophongluu.Checked) sql1 += ",4";
                if (tmn_Conhanbenh.Checked) sql1 += ",1";
                if (tmn_ngoaitru.Checked) sql1 += ",2";
                if (sql1 != "") sql += " where id in(" + sql1.Trim().Trim(',') + ")";
                sql += " order by ten";
                cbLoaibn.DataSource = m_v.get_data(sql).Tables[0];
                cbLoaibn.DisplayMember = "ten";
                cbLoaibn.ValueMember = "id";
                cbLoaibn.SelectedIndex = 0;

                cbGioitinh.DataSource = m_v.get_data("select ma, ten from medibv.dmphai order by ma desc").Tables[0];
                cbGioitinh.DisplayMember = "ten";
                cbGioitinh.ValueMember = "ma";

                cbTuoi.DataSource = m_v.f_get_dmtuoi().Tables[0];
                cbTuoi.DisplayMember = "ten";
                cbTuoi.ValueMember = "id";

                sql = "select 0 as id, 0 as chon, 0 as mavp, '' as ma,'' as ten,'' as dvt,0 as soluong, 0 as dongia, 0 as thanhtien, 0 as mien,0 as thucthu,0 as madoituong,'' as doituong,'' as makp, '' as tenkp, '' as mabs,'' as tenbs, 0 as idcd";
                m_dshoadon = m_v.get_data(sql);
                m_dshoadon.Tables[0].Rows.Clear();
                dgHoadon.DataSource = m_dshoadon.Tables[0];

                m_frmprinthd = new frmPrintHD(m_v,m_userid);

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmthutamung(m_userid);
                tmn_FullgridHD.Checked = m_v.get_o_fullgridhd_frmthutamung(m_userid);
                f_Set_Fullgrid();
                f_Set_FullgridHD();

                f_Display();

                //Option
                tmn_Luuin_Hoadon.Checked = m_v.get_o_luuin_hoadon_frmthutamung(m_userid);
                tmn_Luuin_Hoadon_Chitiet.Checked = m_v.get_o_luuin_hoadon_chitiet_frmthutamung(m_userid);

                tmn_Luuin_Hoadon_Icon.Checked = m_v.get_o_luuin_frmthutamung(m_userid);
                tmn_Xemtruockhiin_Icon.Checked = m_v.get_o_xemtruockhiin_frmthutamung(m_userid);

                panel5.Height = m_v.get_o_dgheight_frmthutamung(m_userid);
                f_Load_PChitiet();
            }
            catch
            {
            }
        }
        private void f_Load_PChitiet()
        {
            try
            {
                if (!tmn_Nhapsotienchitiet.Checked)
                {
                    pCT.Visible = false;
                    splitter2.Visible = false;
                    return;
                }
                else
                {
                    pCT.Visible = true;
                    splitter2.Visible = true;

                    pCT.Width = m_v.get_o_pchitiet_width_frmthutamung(m_userid);
                    if (pCT.Width < 50)
                    {
                        pCT.Width = 240;
                    }
                }
                pCT.Controls.Clear();

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

                DataSet ads = m_v.get_data("select a.id,a.viettat,a.ten from medibv.v_loaivp a order by a.ten");
                int ai = 0, arow = 0, acol = 0;
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    ai++;
                    m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));

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
                    atb.Validated += new System.EventHandler(this.txt_Validated);
                    atb.ReadOnly = false;
                    atb.TextAlign = HorizontalAlignment.Right;
                    m_table.Controls.Add(atb, acol + 1, arow);
                    arow++;
                }
                m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                alb = new Label();
                alb.Name = "_blank";
                alb.Text = "";
                alb.AutoSize = true;
                alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
                alb.TextAlign = ContentAlignment.MiddleRight;
                m_table.Controls.Add(alb, 0, ai);

                pCT.Controls.Add(m_table);
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
                c.BackColor = Color.White;
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
            f_Tinhtien();
        }
        private void f_Tinhtien()
        {
            try
            {
                decimal asotien = 0, asotienct = 0;
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        try
                        {
                            asotienct = decimal.Parse(c.Text.Replace(",",""));
                        }
                        catch
                        {
                            asotienct = 0;
                        }
                        if (asotienct < 0)
                        {
                            asotienct = 0;
                        }
                        c.Text = asotienct.ToString("###,###,###");
                        asotien += asotienct;
                    }
                }
                txtSotien.Text = asotien.ToString("###,###,##0");
            }
            catch
            {
                txtSotien.Text = "0";
            }
        }
        private void f_Load_Hanhchanh(string v_mabn)
        {
           try
            {
                string mmyy = m_v.mmyy(txtNgaythu.Text).ToString();
                bool aok = false;
                string sql = "";
                m_bnmoi = true;
                sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.phai,a.sonha,a.thon,a.cholam,b.tentt as tinh, c.tenquan as quan, d.tenpxa as xa";
                sql += ",coalesce(a1.madoituong,2) as madoituong,coalesce(a1.sotien,0) as sotien ";
                sql += "from medibv.btdbn a left join medibv" + mmyy + ".v_tamungcd a1 on a.mabn = a1.mabn left join medibv.btdtt b on a.matt=b.matt left join medibv.btdquan c on a.maqu=c.maqu left join medibv.btdpxa d on a.maphuongxa=d.maphuongxa where a.mabn='" + v_mabn + "' order by a1.ngayud desc";
                f_Clear_HC();
                //Thuy 19.01.12
                if (bchondoituong) cbDoituong.Enabled = true; 
                bchondoituong = m_v.bchophepchondoituong(m_userid);
                //end Thuy 19.01.12
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
                    if(r["thon"].ToString().Trim()!="")
                    {
                        if (r["sonha"].ToString().Trim() != "")
                        {
                            txtDiachi.Text=txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + " " + r["thon"].ToString().Trim();
                    }
                    if (r["xa"].ToString().Trim() != "" && r["xa"].ToString().Trim().ToLower() != "không xác định")
                    {
                        if (txtDiachi.Text != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + " " + r["xa"].ToString().Trim();
                    }
                    if (r["quan"].ToString().Trim() != "" && r["quan"].ToString().Trim().ToLower() != "không xác định")
                    {
                        if (txtDiachi.Text != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + " " + r["quan"].ToString().Trim();
                    }
                    if (r["tinh"].ToString().Trim() != "" && r["tinh"].ToString().Trim().ToLower() != "không xác định")
                    {
                        if (txtDiachi.Text != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + " " + r["tinh"].ToString().Trim();
                    }

                    if (r["cholam"].ToString().Trim() != "")
                    {
                        if (txtDiachi.Text.Trim() != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + " ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + "(" + r["cholam"].ToString().Trim()+")";
                    }
                    txtDiachi.Text = txtDiachi.Text.Trim();
                    if (m_id == "")
                    {
                        f_Load_CB_Ngayvv(txtNgaythu.Text.Substring(0, 10), "");
                    }
                    else
                    {
                        f_Load_CB_Ngayvv(txtNgaythu.Text.Substring(0,10), m_maql);
                    }
                    if (cbNgayvv.Items.Count <= 0)
                    {
                        //try
                        //{
                        //    cbLoaibn.SelectedValue = "0";
                        //}
                        //catch
                        //{
                        //}
                        try
                        {
                            cbDoituong.SelectedValue = "1";
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
                    //Thuy 19.01.12
                    else
                    {
                        cbDoituong.SelectedValue = r["madoituong"].ToString();
                    }
                    //end Thuy 19.01.12
                    txtNgaysinh_Validated(null, null);
                    if (tmn_Xemlaihoadon.Checked)
                        {
                        f_Load_DG_Hoadon();
                    }
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
                        if (tmn_Nhapsotienchitiet.Checked)
                        {
                            m_table.Controls[1].Focus();
                        }
                        else
                        {
                            txtSotien.Focus();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Load_DG_Hoadon()
        {
            try
            {
                string sql = "",aexp="",atn="",amaql="";
                decimal asotien = 0, asotien_chiphi = 0, acongno = 0, asotien_chiphi_thuoc = 0;
                try
                {
                    atn = cbNgayvv.Text.Substring(0, 10);
                    amaql = decimal.Parse(cbNgayvv.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    atn = txtNgaythu.Text.Substring(0,10);
                    amaql = "";
                }
                aexp = "where a.mabn ='" + txtMabn.Text + txtMabn1.Text + "'";
                if (amaql != "" && !tmn_All.Checked)
                {
                    aexp += " and a.maql=" + amaql;
                }
                sql = "select case when g.id is null then 0 else 1 end as huy, to_char(a.ngay,'dd/mm/yyyy') as ngay,b.sohieu,";
                sql += "a.sobienlai,a.sotien,f.tenkp,d.ten as tenloaidv, e.ten as tenloaibn,a.lanin,c.hoten||' ('||c.userid||')'";
                sql += " as user,a.id from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join ";
                sql += "medibv.v_dlogin c on a.userid=c.id left join medibv.v_tenloaivp d on a.loai=d.ma left join medibv.v_loaibn ";
                sql += "e on a.loaibn=e.id left join medibv.btdkp_bv f on a.makp=f.makp left join medibvmmyy.v_hoantra g on a.mabn=g.mabn ";
                sql += "and a.maql=g.maql and a.mavaovien=g.mavaovien and a.loaibn=g.loaibn and a.loai=g.loai and a.quyenso=g.quyenso ";
                sql += "and a.sobienlai=g.sobienlai " + aexp;
                sql += " and a.id not in (select id from medibvmmyy.v_huybienlai " + aexp + ")";//gam 25/11/2011
                m_dshoadon = m_v.get_data_bc_1(atn,txtNgaythu.Text.Substring(0,10),sql);
                dgHoadon.DataSource = m_dshoadon.Tables[0];
                
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    asotien += decimal.Parse(r["sotien"].ToString());
                }
                tmn_Tamung.Text = asotien.ToString("###,###,##0.##");
                try
                {
                    sql = "select mabn,sum(soluong*dongia) as sotien from medibvmmyy.v_chidinh where paid=0 and mabn='" + txtMabn.Text + txtMabn1.Text + "'";
                    if(m_mavaovien.Trim()!="" && m_mavaovien.Trim()!="0") sql+=" and mavaovien=" + m_mavaovien;
                    sql += " group by mabn";
                    asotien_chiphi =decimal.Parse(m_v.get_data_bc_1(atn, txtNgaythu.Text.Substring(0, 10), sql).Tables[0].Rows[0]["sotien"].ToString());
                }
                catch
                {
                    asotien_chiphi = 0;
                }
                try
                {
                    sql = "select mabn,sum(soluong*giaban) as sotien from medibvmmyy.d_tienthuoc where done=0 and mabn='" + txtMabn.Text + txtMabn1.Text + "'";// and mavaovien=" + m_mavaovien + " group by mabn";
                    if (m_mavaovien.Trim() != "" && m_mavaovien.Trim() != "0") sql += " and mavaovien=" + m_mavaovien;
                    sql += " group by mabn";
                    asotien_chiphi_thuoc = decimal.Parse(m_v.get_data_bc_1(atn, txtNgaythu.Text.Substring(0, 10), sql).Tables[0].Rows[0]["sotien"].ToString());
                }
                catch
                {
                    asotien_chiphi_thuoc = 0;
                }
                asotien_chiphi = asotien_chiphi + asotien_chiphi_thuoc;
                acongno = asotien_chiphi - asotien;

                tmn_Chiphi.Text = asotien_chiphi.ToString("###,###,##0.##");
                tmn_Congno.Text = acongno.ToString("###,###,##0.##");
                
            }
            catch
            {
                tmn_Tamung.Text = "0";
            }
        }        
        private void f_Load_DG_Danhsach()
        {
            try
            {
                tmn_Tim.Text = lan.Change_language_MessageText("Tìm kiếm");
                string sql = "", aexp = "",atn="";
                atn = txtNgaythu.Text.Substring(0, 10);
                aexp = "where to_char(a.ngay,'dd/mm/yyyy') ='" + txtNgaythu.Text.Substring(0, 10) + "'"; ;
                sql = "select case when i.id is null then 0 else 1 end as huy, a.mabn,g.hoten,case when g.ngaysinh is null ";
                sql += "then g.namsinh else to_char(g.ngaysinh,'dd/mm/yyyy') end as namsinh,h.ten as gioitinh,a.id,";
                sql += "to_char(a.ngay,'dd/mm/yyyy') as ngay,b.sohieu,a.sobienlai,a.sotien,f.tenkp,d.ten as tenloaidv, ";
                sql += "e.ten as tenloaibn,a.lanin,c.hoten||' ('||c.userid||')' as user, trim(g.sonha||' '||g.thon) as diachi,";
                sql += "to_char(a.sobienlai,'9999999') as sbl from medibvmmyy.v_tamung a left join medibv.v_quyenso b on ";
                sql += "a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id left join medibv.v_tenloaivp d on a.loai=d.ma ";
                sql += "left join medibv.v_loaibn e on a.loaibn=e.id left join medibv.btdkp_bv f on a.makp=f.makp left join ";
                sql += "medibv.btdbn g on a.mabn=g.mabn left join medibv.dmphai h on g.phai=h.ma left join medibvmmyy.v_hoantra i ";
                sql += "on a.mabn=i.mabn and a.mavaovien=i.mavaovien and a.maql=i.maql and a.loai=i.loai and a.quyenso=i.quyenso ";
                sql += "and a.sobienlai=i.sobienlai " + aexp;
                sql += " and a.id not in (select id from medibvmmyy.v_huybienlai where tables='v_tamung')";//gam 25/11/2011
                m_dsdanhsach = m_v.get_data_bc_1(atn, txtNgaythu.Text.Substring(0, 10), sql);
                dgDanhsach.DataSource = m_dsdanhsach.Tables[0];
                decimal asotien = 0, asotienhuy = 0;
                foreach (DataRow r in m_dsdanhsach.Tables[0].Rows)
                {
                    if (r["huy"].ToString() == "1")
                    {
                        asotienhuy += decimal.Parse(r["sotien"].ToString());
                    }
                    else
                    {
                        asotien += decimal.Parse(r["sotien"].ToString());
                    }
                }

                tmn_Sotienthu.Text = (bKhongchoxem_tongthu) ? "" : asotien.ToString("###,###,##0.##");
                tmn_Sotienhuy.Text = (bKhongchoxem_tongthu) ? "" : asotienhuy.ToString("###,###,##0.##");

                tmn_Sohoadonthu.Text = (bKhongchoxem_tongthu) ? "" : m_dsdanhsach.Tables[0].Select("huy=0").Length.ToString();
                tmn_Sohoadonhuy.Text = (bKhongchoxem_tongthu) ? "" : m_dsdanhsach.Tables[0].Select("huy=1").Length.ToString();
                tmn_Tim_TextChanged(null, null);
            }
            catch
            {
                tmn_Sotienthu.Text = "0";
                tmn_Sotienhuy.Text = "0";

                tmn_Sohoadonthu.Text = "0";
                tmn_Sohoadonhuy.Text = "0";
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
                txtDiachi.Text = "";
                txtSothe.Text = "";

                txtTN.Text = "";
                txtDN.Text = "";
                txtNDK_Ma.Text = "";
                txtNDK_Ten.Text = "";
                txtKhoa.Text = "";
                txtKhoaTD.Text = "";

                tmn_Chiphi.Text = "";
                tmn_Tamung.Text = "";
                tmn_Congno.Text = "";
                //try
                //{
                //    cbLoaibn.SelectedValue = "0";
                //}
                //catch
                //{
                //}
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
                    cbKhoaTD.SelectedIndex = -1;
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
                    cbNgayvv.DataSource=null;
                    cbNgayvv.SelectedIndex = -1;
                }
                catch
                {
                }
                txtSotien.Text = "";
            }
            catch
            {
            }
        }
        private void f_Enable_HC(bool v_bool)
        {
            try
            {
                cbLoaidv.Enabled = false;
                txtNgaythu.Enabled = false;
                cbKyhieu.Enabled = false;
                //txtSobienlai.ReadOnly = true;
                txtHoten.ReadOnly = !v_bool;
                txtNgaysinh.ReadOnly = !v_bool;
                txtTuoi.ReadOnly = !v_bool;
                cbTuoi.Enabled = v_bool;
                cbGioitinh.Enabled = v_bool;
                txtDiachi.ReadOnly = !v_bool;
                txtSothe.ReadOnly = !v_bool;
                txtTN.ReadOnly = !v_bool;
                txtDN.ReadOnly = !v_bool;
                txtNDK_Ma.ReadOnly = !v_bool;
                txtNDK_Ten.ReadOnly = !v_bool;
                //cbLoaibn.Enabled = false;
                cbDoituongTD.Enabled = false;
                cbKhoaTD.Enabled = false;
                txtKhoaTD.Enabled = false;
                cbKhoa.Enabled = false;
                txtKhoa.Enabled = false;
                //cbDoituong.Enabled = false;
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
                butSua.Enabled = !v_bool && m_id != "" && m_id != "0";
                butXoa.Enabled = !v_bool && m_id != "" && m_id != "0";
                butBoqua.Enabled = true;
                butPre.Enabled = !v_bool;
                butNext.Enabled = !v_bool;
                butKetthuc.Enabled = !v_bool;

                txtKhoa.Enabled = v_bool;
                cbKhoa.Enabled = v_bool;
                cbDoituong.Enabled = v_bool;
                //txtSotien.ReadOnly = !v_bool;

                txtSotien.ReadOnly = !butLuu.Enabled;
                if (tmn_Nhapsotienchitiet.Checked)
                {
                    txtSotien.ReadOnly = true;
                    foreach (Control c in m_table.Controls)
                    {
                        if (c.Name.IndexOf("tbma_") == 0)
                        {
                            TextBox atb = (TextBox)(c);
                            atb.ReadOnly = !v_bool;
                        }
                    }
                }
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
                    return;
                }

                m_bnmoi = true;
                m_id = "";
                m_mavaovien = "";
                m_maql = "";
                bLoadLanvao_saucung = true;
                m_dshoadon.Tables[0].Rows.Clear();
                f_Clear_HC();
                f_Enable(true);
                f_Enable_HC(true);
                txtNgaythu.Value = m_cur_ngay;
                cbNgayvv.DataSource = null;
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
                    cbLoaidv.Enabled = false;
                    cbLoaidv.Focus();
                    return;
                }
                else
                    if (atmp.Split(':')[1] == "2")//Lỗi
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không tìm thấy quyển sổ thu viện phí!")+"\n"+lan.Change_language_MessageText("Đề nghị chọn sổ"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtMabn.Text = m_cur_yy;
                txtMabn1.Text = "";
                //txtMabn.Focus();
                cbLoaibn.DroppedDown = true;
                cbLoaibn.Focus();
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

                if (cbNgayvv.SelectedIndex < 0)
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Bệnh nhân này chưa nhập khoa nên không thu tạm ứng được. Vui lòng nhập khoa!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbNgayvv.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }

                string ammyy = "", aid = "", aquyenso = "", asobienlai = "", angay = "", amabn = "", amavaovien = "", amaql = "", aidkhoa = "", amakp = "", aloai = "", aloaibn = "",amadoituong="",asotien="", auserid = "";
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
                amabn=txtMabn.Text.Trim()+txtMabn1.Text.Trim();
                if (amabn == "" && txtHoten.Text == "")
                {
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
                try
                {
                    amadoituong = decimal.Parse(cbDoituong.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    amadoituong = "2";
                }
                txtSotien_Validated(null, null);
                try
                {
                    asotien = decimal.Parse(txtSotien.Text.Trim().Replace(",","")).ToString();
                }
                catch
                {
                    asotien = "";
                }
                if (asotien == "")
                {
                    butLuu.Enabled = true;
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập số tiền!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSotien.Focus();
                    return;
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
                if (m_maql == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Bệnh nhân chưa hoàn tất thủ tục!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    butLuu.Enabled = true;
                    txtMabn.Focus();
                    return;
                }
                if (m_v.f_parse_date(cbNgayvv.Text.Substring(0,10))>txtNgaythu.Value)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Đề nghị chọn ngày thu >= ngày bệnh nhân vào viện (")+cbNgayvv.Text.Substring(0,10)+")!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    butLuu.Enabled = true;
                    lbKyhieu_Click(null,null);
                    txtNgaythu.Focus();
                    return;
                }
                if (m_mavaovien == "")
                {
                    m_mavaovien = m_maql;
                }
                if (m_idkhoa != "")
                {
                    aidkhoa = m_idkhoa;
                }
                else
                {
                    aidkhoa = "0";
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
                            cbLoaidv.Enabled = false;
                            lbKyhieu_Click(null, null);
                            cbKyhieu.Focus();
                            SendKeys.Send("{F4}");
                            return;
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
                
                if (aid != "0")
                {
                    string s = m_v.fields(m_v.user + ammyy + ".v_tamung", "id=" + aid + " and mabn='" + amabn + "'");
                    m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "upd", s);
                }
             

                asobienlai = txtSobienlai.Text.Trim();
                aid = m_v.upd_v_tamung(ammyy, decimal.Parse(aid), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, decimal.Parse(aloai), amakp, decimal.Parse(amadoituong), decimal.Parse(aloaibn), decimal.Parse(asotien), decimal.Parse(auserid));
                m_v.upd_v_tamung(decimal.Parse(aid), amabn, decimal.Parse(amavaovien), decimal.Parse(amaql), decimal.Parse(aidkhoa), decimal.Parse(aquyenso), decimal.Parse(asobienlai), angay, decimal.Parse(aloai), amakp, decimal.Parse(amadoituong), decimal.Parse(aloaibn), decimal.Parse(asotien), decimal.Parse(auserid));
                m_v.upd_v_quyenso(decimal.Parse(aquyenso), decimal.Parse(asobienlai), true);
                if (!asua && idduyet != 0)
                {
                    m_v.execute_data(m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(txtNgaythu.Text.Substring(0, 10)).AddMonths(-1)), txtNgaythu.Text.Substring(0, 10), "update medibvmmyy.v_tamungcd set done=1,idduyet=" + aid + " where id=" + idduyet);                    
                    m_v.execute_data(" update " + m_v.user + ammyy + ".v_tamung set idtonghop=" + idduyet + " where id=" + aid);
                    m_v.execute_data(" update " + m_v.user + ".v_tamung set idtonghop=" + idduyet + " where id=" + aid);
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
                    if (tmn_Nhapsotienchitiet.Checked)
                    {
                        m_v.execute_data_mmyy(ammyy,"delete from medibvmmyy.v_tamungct where id=" + aid);
                        decimal asotienct = 0;
                        foreach (Control c in m_table.Controls)
                        {
                            if (c.Name.IndexOf("tbma_") == 0)
                            {
                                try
                                {
                                    asotienct = decimal.Parse(c.Text.Replace(",", ""));
                                }
                                catch
                                {
                                    asotienct = 0;
                                }
                                if (asotienct > 0)
                                {
                                    m_v.upd_v_tamungct(ammyy, decimal.Parse(aid), decimal.Parse(c.Name.Replace("tbma_", "")), asotienct);
                                }
                            }
                        }
                    }
                    f_Enable(false);
                    f_Enable_HC(false);
                    if (tmn_Luuin_Hoadon_Icon.Checked)
                    {
                        if (asua)
                        {
                            if (tmn_Luuin_Hoadon.Checked)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại hoá đơn vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inhoadon();
                                }
                            }
                            if (tmn_Luuin_Hoadon_Chitiet.Checked)
                            {
                                if (MessageBox.Show(this, lan.Change_language_MessageText("Thông tin thay đổi đã được cập nhật!") + "\n" + lan.Change_language_MessageText("Có muốn in lại hoá đơn chi tiết vừa sửa không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    f_Inhoadonchitiet();
                                }
                            }
                        }
                        else
                        {
                            if (tmn_Luuin_Hoadon.Checked)
                            {
                                f_Inhoadon();
                            }
                            if (tmn_Luuin_Hoadon_Chitiet.Checked)
                            {
                                f_Inhoadonchitiet();
                            }
                        }
                    }
                    if (tmn_Xemlaihoadon.Checked)
                    {
                        f_Load_DG_Hoadon();
                    }
                    if (tmn_Xemlaidanhsach.Checked)
                    {
                        f_Load_DG_Danhsach();
                    }
                    f_Focus();
                    butMoi.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Sua()
        {
            try
            {
                if (m_v.tu_suahoadon(m_userid))
                {
                    if(m_v.dahoantra(txtMabn.Text+txtMabn1.Text,m_mavaovien,m_maql,cbKyhieu.SelectedValue.ToString(),txtSobienlai.Text,cbLoaidv.SelectedValue.ToString(),cbLoaibn.SelectedValue.ToString()))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép sửa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        f_Enable(true);
                        f_Enable_HC(false);
                        if (tmn_Nhapsotienchitiet.Checked)
                        {
                            m_table.Controls[1].Focus();
                        }
                        else
                        {
                            txtSotien.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (m_v.tu_xoahoadon(m_userid))
                {
                    string ammyy = txtNgaythu.Value.Month.ToString().PadLeft(2, '0') + txtNgaythu.Value.Year.ToString().Substring(2);
                    if (m_v.dadung_v_tamung(ammyy, m_id) != 0 && m_v.tu_xoahoadon_dain(m_userid) == false)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá hoá đơn này!") + "\n" + lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Hoá đơn đã in không được xoá, chỉ được phép hoàn trả") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        if (m_v.dahoantra(txtMabn.Text + txtMabn1.Text, m_mavaovien, m_maql, cbKyhieu.SelectedValue.ToString(), txtSobienlai.Text, cbLoaidv.SelectedValue.ToString(), cbLoaibn.SelectedValue.ToString()))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả, không cho phép xoá.") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (MessageBox.Show(this, lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Nếu xoá xem như hoá đơn chưa phát sinh, sẽ không có trong báo cáo") + "\n" + lan.Change_language_MessageText("Nếu hoàn xem như hoá đơn đã phát sinh và không có giá trị sử dụng, có trong báo cáo hoàn.") + "\n" + lan.Change_language_MessageText("Đồng ý xoá hoá đơn này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                //son web                                
                                if (m_id != "0")
                                {
                                    string s = m_v.fields(m_v.user + ammyy + ".v_tamung", "id=" + m_id + " and mabn='" + txtMabn.Text+txtMabn1.Text + "'");
                                    m_v.upd_eve_tables(ammyy, itablell, int.Parse(m_userid), "del");
                                    m_v.upd_eve_upd_del(ammyy, itablell, int.Parse(m_userid), "del", s);
                                }
                                string s_ngayhuyblai = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                                
                                //if(!m_v.del_v_tamung(ammyy, m_id))
                                if (m_v.dadung_v_tamung(ammyy, m_id)!= 0 && m_v.tu_xoahoadon_dain(m_userid)==false)
                                {
                                    MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá hoá đơn này!") + "\n" + lan.Change_language_MessageText("Ghi chú:") + "\n" + lan.Change_language_MessageText("Hoá đơn đã in không được xoá, chỉ được phép hoàn trả") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    m_v.del_v_tamung(ammyy, m_id);
                                    if (MessageBox.Show(this, "Có muốn hoá đơn đã xoá này có trong báo cáo hoá đơn đã dùng không ?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        m_v.upd_huybienlai(ammyy, decimal.Parse(m_id), "v_tamung", int.Parse(cbLoaidv.SelectedValue.ToString()), txtMabn.Text + txtMabn1.Text, txtHoten.Text, txtKhoa.Text, s_ngayhuyblai, decimal.Parse(cbKyhieu.SelectedValue.ToString()), decimal.Parse(txtSobienlai.Text.Trim()), "Hủy biên lai thu tạm ứng", int.Parse(m_userid), (txtSotien.Text.Trim() == "") ? 0 : decimal.Parse(txtSotien.Text));
                                    }
                                    f_Load_DG_Danhsach();
                                    f_Load_DG_Hoadon();
                                    f_Clear_HC();
                                    f_Enable(false);
                                    f_Enable_HC(false);
                                    butMoi.Focus();
                                }
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
                    m_frmprinthd.f_Print_BienlaiTU(!tmn_Xemtruockhiin_Icon.Checked,m_id,m_v.get_mmyy(txtNgaythu.Text.Substring(0,10)));
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
                    m_frmprinthd.f_Print_BienlaiTU_Chitiet(!tmn_Xemtruockhiin_Icon.Checked, m_id, m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)));
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
                m_frmhoantra.s_loaihd = "2";
                if (m_id != "")
                {
                    m_frmhoantra.s_sohoadon = txtSobienlai.Text;
                    m_frmhoantra.s_ngay = txtNgaythu.Value;
                }
                m_frmhoantra.s_quyenso = cbKyhieu.SelectedValue.ToString();
                m_frmhoantra.s_ngaythu = txtNgaythu.Text.Substring(0, 10);
                m_frmhoantra.s_ngayhoan = m_v.f_ngay10(m_cur_ngay);
                m_frmhoantra.s_loaihd = m_v.s_loaiform_thutamung;
                m_frmhoantra.ShowDialog();
                f_Load_DG_Danhsach();
                f_Load_DG_Hoadon();
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
                sql = "select a.mabn,a.mavaovien,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.quyenso,a.sobienlai,a.loai,a.loaibn,a.id, case when a.lanin <> 0 then 1 else 0 end as lanin,a.sotien,a1.sotien as sotienct,a1.loaivp,a.makp,a.madoituong from medibvmmyy.v_tamung a left join medibvmmyy.v_tamungct a1 on a.id=a1.id where a.id = " + v_id;

                DataSet ads = m_v.get_data_mmyy(ammyy, sql);
                
                m_mavaovien = "";
                m_maql = "";
                if (ads.Tables[0].Rows.Count > 0)
                {
                    txtMabn.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(0, 2);
                    txtMabn1.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(2);
                    txtMabn1_Validated(null, null);

                    m_mavaovien = ads.Tables[0].Rows[0]["mavaovien"].ToString();
                    m_maql = ads.Tables[0].Rows[0]["maql"].ToString();

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
                        cbDoituong.SelectedValue = ads.Tables[0].Rows[0]["madoituong"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbKhoa.SelectedValue = ads.Tables[0].Rows[0]["makp"].ToString();
                        txtKhoa.Text = ads.Tables[0].Rows[0]["makp"].ToString();
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
                    txtSotien.Text = decimal.Parse(ads.Tables[0].Rows[0]["sotien"].ToString()).ToString("###,###,##0.##");

                    if (ads.Tables[0].Rows[0]["ngay"].ToString().Length > 10)
                        txtNgaythu.Value = m_v.f_parse_date_16(ads.Tables[0].Rows[0]["ngay"].ToString());
                    else
                        txtNgaythu.Value = f_Cur_Date(ads.Tables[0].Rows[0]["ngay"].ToString());

                    if (tmn_Nhapsotienchitiet.Checked)
                    {
                        decimal asotienct = 0;
                        foreach (Control c in m_table.Controls)
                        {
                            if (c.Name.IndexOf("tbma_") == 0)
                            {
                                try
                                {
                                    asotienct = decimal.Parse(ads.Tables[0].Select("loaivp=" + c.Name.Replace("tbma_", ""))[0]["sotienct"].ToString());
                                }
                                catch
                                {
                                    asotienct = 0;
                                }
                                c.Text = asotienct.ToString("###,###,###");
                                TextBox atb = (TextBox)(c);
                                atb.ReadOnly = true;
                            }
                        }
                    }
                    m_id = v_id;
                }
                f_Enable(m_id == "" || m_id == "0");
                f_Focus();
                butLuu_EnabledChanged(null, null);
            }
            catch
            {
                m_id = "";
                m_mavaovien = "";
                m_maql = "";
            }
        }
        private void f_Load_Hoadon_NextPre(int v_pre)
        {
            try
            {
                int aid = 0;
                aid = dgDanhsach.CurrentCell.RowIndex + v_pre;
                if (aid < 0)
                {
                    aid = 0;
                }
                if (dgDanhsach.RowCount > aid)
                {
                    dgDanhsach.Rows[aid].Selected = true;
                    dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                    DataRowView arv = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
                    f_Load_Hoadon(arv["id"].ToString(), m_v.get_mmyy(arv["ngay"].ToString()));
                }
            }
            catch
            {
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
        private void f_Load_CB_Ngayvv(string v_tn, string v_maql)
        {
            try
            {
                string sql = "",amabn="";
                amabn = txtMabn.Text + txtMabn1.Text;
                DateTime adt = txtNgaythu.Value;
                v_tn = m_v.f_string_date(v_tn);
                
                if (v_tn.Length >= 10)
                {
                    adt = m_v.f_parse_date(v_tn.Substring(0,10));
                }

                switch (cbLoaibn.SelectedValue.ToString())
                {
                    case "0": sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number('0') as loaibn from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                        break;
                    case "2": sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number('2') as loaibn from medibv.benhanngtr where ngayrv is null and mabn='" + amabn + "'";
                        break;
                    case "3": sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number('3') as loaibn  from medibvmmyy.benhanpk where mabn='" + amabn + "' and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                        break;
                    case "4": sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number('4') as loaibn from medibvmmyy.benhancc where ngayrv is null and mabn='" + amabn + "' and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtNgaythu.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                        break;
                    default: sql = "select a.maql, a.mavaovien, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(a.ngay,'yyyymmddhh24:mi') as ngay1, a.makp, a.madoituong, a.loaiba as loaibn from medibv.benhandt a left join medibv.xuatvien b on a.maql=b.maql where b.maql is null and a.mabn='" + amabn + "' order by ngay1 desc";
                        break;
                }

                #region Load BN Old
                /*
                sql = "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number(loaiba,9) as loaibn from medibv.benhandt where mabn='" + amabn + "' order by ngay1 desc";

                if (tmn_Cotiepdon.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, maql as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number('0') as loaibn from medibvmmyy.tiepdon where mabn='" + amabn + "'";
                }
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
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(4,9) as loaibn from medibvmmyy.benhancc where mabn='" + amabn + "'";
                }
                //son web
                if (tmn_ngoaitru.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number('2') as loaibn from medibv.benhanngtr where mabn='" + amabn + "'";
                }

                DataSet ads = null, ads1 = null, ads2 = null;
                if (asql1 != "")
                {
                    asql1 += "  order by ngay1 desc,maql desc";
                    ads1 = m_v.get_data_mmyy(asql1, m_v.DateToString("dd/MM/yyyy", adt.AddMonths(-1)), txtNgaythu.Text.Substring(0, 10), true);
                }
                */
                #endregion

                DataSet ads = null, ads2 = null;
               
                ads = m_v.get_data_mmyy(sql, m_v.DateToString("dd/MM/yyyy", adt.AddMonths(-iSothang)), txtNgaythu.Text.Substring(0, 10), true);
               
                ads2 = ads.Clone();
                foreach (DataRow r in ads.Tables[0].Select("true", "ngay1 desc,maql desc"))
                {
                    ads2.Tables[0].Rows.Add(r.ItemArray);
                    //if (bLoadLanvao_saucung) break;
                }
                cbNgayvv.DisplayMember = "ngay";
                cbNgayvv.ValueMember = "maql";
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
                if(cbNgayvv.Items.Count>0)
                {
                    //LOAD PHAN CHI DINH TAM UNG
                    v_maql=cbNgayvv.SelectedValue.ToString();
                    idduyet = 0;
                    decimal st = 0;
                    foreach (DataRow r0 in m_v.get_data_mmyy("select * from medibvmmyy.v_tamungcd where mabn='" + txtMabn.Text+ txtMabn1.Text + "' and maql=" + v_maql + " and done=0 order by ngayud desc ", m_v.DateToString("dd/MM/yyyy", adt.AddMonths(-1)), txtNgaythu.Text.Substring(0, 10), true).Tables[0].Rows)//Thuy 19.01.12
                    {
                        idduyet = decimal.Parse(r0["id"].ToString());
                        st = decimal.Parse(r0["sotien"].ToString());
                        cbKhoa.SelectedValue = r0["makp"].ToString();
                        //lanthu.Value = decimal.Parse(r0["lan"].ToString());
                        break;
                    }
                    txtSotien.Text = st.ToString("###,###,###,###");
                    txtSotien.Enabled = !(m_v.tu_theochidinh_khongsuatien(m_userid) && st > 0);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            f_Luu();
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
                }
                f_Enable_HC(false);
                f_Enable(false);
                butMoi.Focus();
            }
            catch
            {
            }
        }
        private void cbDoituongTD_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    SendKeys.Send("{Tab}");
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
                    SendKeys.Send("{Tab}");
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
                txtMabn1.Text = txtMabn1.Text.PadLeft(6, '0');
            }
            catch
            {
                txtMabn1.Text = "";
            }
            if (m_Docmavach)
            {
                string s = txtMabn1.Text;
                if (s.Length > 6)
                {
                    txtMabn.Text = s.Substring(0, 2);
                    txtMabn1.Text = s.Substring(2);
                    txtMabn1.Text = txtMabn1.Text.PadLeft(6, '0');
                }
            }
            if (txtMabn.Text.Trim()!="" && txtMabn1.Text.Trim() != "")
            {
              //  cbLoaibn.Text = "Nội trú";
                f_Load_Hanhchanh(txtMabn.Text + txtMabn1.Text);
            }
        }

        private void cbNgayvv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNgayvv.DataSource]);
                DataView dv = (DataView)(cm.List);
                m_mavaovien = "";
                m_maql = "";
                foreach (DataRow r in dv.Table.Select("maql='" + cbNgayvv.SelectedValue.ToString()+"'"))
                {
                    cbKhoaTD.SelectedValue = r["makp"].ToString();
                    
                    cbKhoa.SelectedValue = r["makp"].ToString();

                    //cbDoituong.SelectedValue = r["madoituong"].ToString();
                    cbDoituongTD.SelectedValue = r["madoituong"].ToString();
                    m_mavaovien = decimal.Parse(r["mavaovien"].ToString()).ToString();
                    m_maql = decimal.Parse(r["maql"].ToString()).ToString();
                    break;
                }
                string sql = "select id, makp from medibv.hiendien where mabn='" + txtMabn.Text + txtMabn1.Text + "' and maql=" + cbNgayvv.SelectedValue.ToString() + "";
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    cbKhoa.SelectedValue = r["makp"].ToString();
                    m_idkhoa = r["id"].ToString();
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
                toolStripSplitButton1.ShowDropDown();
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

        private void frmThutamung_SizeChanged(object sender, EventArgs e)
        {
            f_Display();
        }

        private void cbNgayvv_Validated(object sender, EventArgs e)
        {
            try
            {
                cbNgayvv_SelectedIndexChanged(null, null);
                f_Load_BHYT();
                if (tmn_Xemlaihoadon.Checked && cbNgayvv.Items.Count>1)
                {
                    f_Load_DG_Hoadon();

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
                txtNgaythu.Enabled = false;//= cbLoaidv.Enabled;
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

        private void cbKyhieu_Validated(object sender, EventArgs e)
        {
            try
            {
                string atmp = f_Get_Sobienlai();
                txtSobienlai.Text = atmp.Split(':')[0];
                if (atmp.Split(':')[1] == "1")//Hết số
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Hết sổ, đề nghị chọn sổ mới!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKyhieu.Focus();
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

        private void frmThutamung_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }

        private void cbDoituong_Validated(object sender, EventArgs e)
        {
            try
            {
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
        
        private void frmThutamung_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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
                frmDanhsachchothutamung m_frmdanhsachchothutamung = new frmDanhsachchothutamung(m_v, m_userid);
                m_frmdanhsachchothutamung.ShowInTaskbar = false;
                m_frmdanhsachchothutamung.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachchothutamung.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachchothutamung.s_mabn != "")
                    {
                        string atmp = m_frmdanhsachchothutamung.s_mabn;
                        cbLoaibn.SelectedValue = m_frmdanhsachchothutamung.loaiba;
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                        if (m_frmdanhsachchothutamung.s_maql != "")
                        {
                            f_Load_CB_Ngayvv(m_frmdanhsachchothutamung.s_ngaycd, m_frmdanhsachchothutamung.s_maql);
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
                m_frmtimhoadon.s_loaihd = "2";
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
                frmDanhsachthutamung m_frmdanhsachthutamung = new frmDanhsachthutamung(m_v, m_userid);
                m_frmdanhsachthutamung.ShowInTaskbar = false;
                m_frmdanhsachthutamung.s_ngay = txtNgaythu.Value;
                if (m_frmdanhsachthutamung.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmdanhsachthutamung.s_id != "")
                    {
                        m_id = m_frmdanhsachthutamung.s_id;
                        f_Load_Hoadon(m_id, m_v.get_mmyy(m_frmdanhsachthutamung.s_ngaythu));
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
        
        private void f_Set_FullgridHD()
        {
            try
            {
                dgHoadon.Columns["Column1_4"].Frozen = !tmn_FullgridHD.Checked;
                dgHoadon.Columns["Column1_3"].Frozen = !tmn_FullgridHD.Checked;
                dgHoadon.Columns["Column1_2"].Frozen = !tmn_FullgridHD.Checked;
                dgHoadon.Columns["Column1_1"].Frozen = !tmn_FullgridHD.Checked;
            }
            catch
            {
            }
        }
        private void f_Set_Fullgrid()
        {
            try
            {
                dgDanhsach.Columns["Column2_4"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_3"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_2"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_1"].Frozen = !tmn_Fullgrid.Checked;
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
                m_v.set_o_fullgrid_frmthutamung(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }
        
        private void tmn_Luuin_Hoadon_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_hoadon_frmthutamung(m_userid,tmn_Luuin_Hoadon.Checked);
        }
        private void tmn_Luuin_Hoadon_Chitiet_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_hoadon_chitiet_frmthutamung(m_userid, tmn_Luuin_Hoadon_Chitiet.Checked);
        }

        private void tmn_Luuin_Hoadon_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_luuin_frmthutamung(m_userid, tmn_Luuin_Hoadon_Icon.Checked);
        }

        private void tmn_Xemtruockhiin_Icon_Click(object sender, EventArgs e)
        {
            m_v.set_o_xemtruockhiin_frmthutamung(m_userid, tmn_Xemtruockhiin_Icon.Checked);
        }

        private void txtKhoaTD_KeyDown(object sender, KeyEventArgs e)
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

        private void cbKhoaTD_KeyDown(object sender, KeyEventArgs e)
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

        private void cbKhoa_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSotien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSotien_Validated(null, null);
                    if (txtSotien.Text != "")
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
            }
            catch
            {
            }
        }

        private void txtSotien_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal atmp = decimal.Parse(txtSotien.Text.Trim().Replace(",",""));
                if (atmp < 0)
                {
                    atmp = 0;
                }
                if (atmp >= 1 && atmp <= 10)
                {
                    atmp = atmp * 1000000;
                }
                else
                    if (atmp > 10 && atmp <= 100)
                    {
                        atmp = atmp * 1000;
                    }
                    else
                    if(atmp>100 && atmp<1000)
                    {
                        atmp = atmp * 1000;
                    }
                txtSotien.Text = atmp.ToString("###,###,##0.##");
            }
            catch
            {
                txtSotien.Text = "";
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
                if (this.ActiveControl == txtKhoa)
                {
                    cbKhoa.SelectedValue = txtKhoa.Text;
                }
            }
            catch
            {
            }
        }

        private void tmn_Refresh_BN_Click(object sender, EventArgs e)
        {
            f_Load_DG_Hoadon();
        }

        private void tmn_Refresh_TTN_Click(object sender, EventArgs e)
        {
            f_Load_DG_Danhsach();
        }

        private void tmn_Xemlaihoadon_Click(object sender, EventArgs e)
        {
            m_v.set_o_xemlaihoadon_frmthutamung(m_userid, tmn_Xemlaihoadon.Checked);
        }

        private void tmn_Xemlaidanhsach_Click(object sender, EventArgs e)
        {
            m_v.set_o_xemlaidanhsach_frmthutamung(m_userid, tmn_Xemlaidanhsach.Checked);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m_v.Disconnect();
            System.GC.Collect();           
            this.Close();
        }
        
        private void frmThutamung_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý kết thúc chức năng thu tạm ứng!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                m_v.set_o_pchitiet_width_frmthutamung(m_userid, pCT.Width);
                e.Cancel=true;
            }
        }

        private void dgDanhsach_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (butLuu.Enabled == false)
                {
                    DataRowView arv = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
                    f_Load_Hoadon(arv["id"].ToString(), m_v.get_mmyy(arv["ngay"].ToString()));
                }
            }
            catch
            {
            }
        }

        private void dgHoadon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                //f_Load_Hoadon(arv["id"].ToString(), m_v.get_mmyy(arv["ngay"].ToString()));
            }
            catch
            {
            }
        }
        private void f_Focus()
        {
            try
            {
                for (int i = 0; i < dgHoadon.RowCount; i++)
                {
                    if (dgHoadon["Column1_9", i].Value.ToString() == m_id)
                    {
                        dgHoadon.Rows[i].Selected = true;
                        dgHoadon.CurrentCell = dgHoadon.Rows[i].Cells[1];
                        break;
                    }
                }
                for (int i = 0; i < dgDanhsach.RowCount; i++)
                {
                    if (dgDanhsach["Column2_14", i].Value.ToString() == m_id)
                    {
                        dgDanhsach.Rows[i].Selected = true;
                        dgDanhsach.CurrentCell = dgDanhsach.Rows[i].Cells[1];
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        private void tmn_All_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tmn_All.ForeColor = tmn_All.Checked ? Color.Red : Color.DarkGray;
                f_Load_DG_Hoadon();
            }
            catch
            {
            }
        }

        private void frmThutamung_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_v.set_o_dgheight_frmthutamung(m_userid, panel5.Height);
        }

        private void tmn_FullgridHD_Click(object sender, EventArgs e)
        {
            try
            {
                f_Set_FullgridHD();
                m_v.set_o_fullgridhd_frmthutamung(m_userid, tmn_FullgridHD.Checked);
            }
            catch
            {
            }
        }

        private void tmn_All_Click(object sender, EventArgs e)
        {

        }
        private void tmn_Tim_Enter(object sender, EventArgs e)
        {
            try
            {
                string s_tim = lan.Change_language_MessageText("Tìm kiếm");
                if (tmn_Tim.Text.Trim().ToLower() == s_tim.ToLower())
                {
                    tmn_Tim.Text = "";
                }
            }
            catch
            {
            }
        }

        private void tmn_Tim_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tmn_Tim.Text.Trim().ToLower() == "")
                {
                    //tmn_Tim.Text = lan.Change_language_MessageText("Tìm kiếm");
                    string s_tim = lan.Change_language_MessageText("Tìm kiếm");
                    tmn_Tim.Text = s_tim.ToLower();
                }
            }
            catch
            {
            }
        }

        private void tmn_Tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                string atmp = tmn_Tim.Text;
                string s_tim = lan.Change_language_MessageText("Tìm kiếm");                
                if (atmp.ToLower().Trim() != s_tim.ToLower() && atmp.ToLower().Trim() != "")
                {
                    aft = "mabn like '%" + atmp + "%' or hoten like '%" + atmp + "%' or namsinh like '%" + atmp + "%' or ngay like '%" + atmp + "%' or sohieu like '%" + atmp + "%' or diachi like '%" + atmp + "%' or sbl like '%" + atmp + "%' or gioitinh like '%" + atmp + "%' or tenkp like '%" + atmp + "%' or tenloaidv like '%" + atmp + "%' or tenloaibn like '%" + atmp + "%' or user like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch
            {
            }
        }

        private void txtSotien_ReadOnlyChanged(object sender, EventArgs e)
        {
            try
            {
                txtSotien.ForeColor = txtSotien.ReadOnly ? Color.DarkOrange : Color.Red;
            }
            catch
            {
            }
        }

        private void tmn_Tim_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                {
                    int aid = 0;
                    aid = dgDanhsach.CurrentCell.RowIndex + -1;
                    if (aid < 0)
                    {
                        aid = 0;
                    }
                    if (dgDanhsach.RowCount > aid)
                    {
                        dgDanhsach.Rows[aid].Selected = true;
                        dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                    }
                }
                else
                    if(e.KeyCode==Keys.Down)
                    {
                        int aid = 0;
                        aid = dgDanhsach.CurrentCell.RowIndex + 1;
                        if (aid < 0)
                        {
                            aid = 0;
                        }
                        if (dgDanhsach.RowCount > aid)
                        {
                            dgDanhsach.Rows[aid].Selected = true;
                            dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                        }
                    }
                    else
                        if(e.KeyCode==Keys.Enter)
                        {
                            dgDanhsach_CellMouseDoubleClick(null, null);
                        }
            }
            catch
            {
            }
        }

        private void cbKhoaTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKhoaTD.Text = cbKhoaTD.SelectedValue.ToString();
            }
            catch
            {
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
            //e.Handled = "0123456789\b".IndexOf(txtMabn.Text) != -1;
            //try
            //{
            //    txtMabn.Text = txtMabn.Text.Trim();
            //}
            //catch
            //{
            //}
        }

        private void label26_Click(object sender, EventArgs e)
        {
            bLoadLanvao_saucung = !bLoadLanvao_saucung;
        }
    }
}