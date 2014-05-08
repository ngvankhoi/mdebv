using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmSuahoadon : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private bool m_found = false;
        private LibVP.AccessData m_v;
        private string m_userid="",m_quyenso="",m_id="",m_ngaythu="";
        private bool m_is_sub = true;
        private DataSet m_dshoadon=null;
        public frmSuahoadon(LibVP.AccessData v_v, string v_userid)
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
                chkTamung.Checked = false;
                chkTTRV.Checked = false;
                foreach (string atmp in value.Split(','))
                {
                    if (atmp == "1")
                    {
                        chkTructiep.Checked = true;
                    }
                    else
                    if (atmp == "2")
                    {
                        chkTamung.Checked = true;
                    }
                    else
                    if (atmp == "3")
                    {
                        chkTTRV.Checked = true;
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
            m_found = true;
            try
            {
                tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                txtSobienlai_Validated(null, null);
                txtTuso_Validated(null, null);
                txtDenso_Validated(null, null);

                string asqltt = "", asqlnt="",asqltu="", aexptt = "", aexpnt="",aexptu="", adk = " or ",atmp1="";
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
                }
                if (txtMabn1.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.mabn like '%" + txtMabn1.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "a.mabn like '%" + txtMabn1.Text + "%'";

                    aexptu += adk;
                    aexptu += "a.mabn like '%" + txtMabn1.Text + "%'";
                }
                if (txtHoten.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.hoten like '%" + txtHoten.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "c.hoten like '%" + txtHoten.Text + "%'";

                    aexptu += adk;
                    aexptu += "b.hoten like '%" + txtHoten.Text + "%'";
                }
                if (txtNamsinh.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.namsinh like '%" + txtNamsinh.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "c.namsinh like '%" + txtNamsinh.Text + "%'";

                    aexptu += adk;
                    aexptu += "b.namsinh like '%" + txtNamsinh.Text + "%'";
                }
                if (txtDiachi.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.diachi like '%" + txtDiachi.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "(c.sonha like '%" + txtDiachi.Text + "%' or c.thon like '%" + txtDiachi.Text + "%' or c.cholam like '%" + txtDiachi.Text + "%')";

                    aexptu += adk;
                    aexptu += "(b.sonha like '%" + txtDiachi.Text + "%' or b.thon like '%" + txtDiachi.Text + "%' or b.cholam like '%" + txtDiachi.Text + "%')";
                }
                if (txtNgaythu.Text != "")
                {
                    aexptt += adk;
                    aexptt += "to_char(a.ngay,'dd/mm/yyyy') like '%" + txtNgaythu.Text + "%'";

                    aexpnt += adk;
                    aexpnt += "to_char(b.ngay,'dd/mm/yyyy') like '%" + txtNgaythu.Text + "%'";

                    aexptu += adk;
                    aexptu += "to_char(a.ngay,'dd/mm/yyyy') like '%" + txtNgaythu.Text + "%'";
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
                }
                if (txtTuso.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.sobienlai >= " + txtTuso.Text.Trim();

                    aexpnt += adk;
                    aexpnt += "b.sobienlai >= " + txtTuso.Text.Trim();

                    aexptu += adk;
                    aexptu += "a.sobienlai >= " + txtTuso.Text.Trim();
                }
                if (txtDenso.Text != "")
                {
                    aexptt += adk;
                    aexptt += "a.sobienlai <= " + txtDenso.Text.Trim();
                    
                    aexpnt += adk;
                    aexpnt += "b.sobienlai <= " + txtDenso.Text.Trim();

                    aexptu += adk;
                    aexptu += "a.sobienlai <= " + txtDenso.Text.Trim();
                }
                asqltt = "select 0 as chon, a.mabn,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') as ngay, d.sohieu,a.sobienlai, a.sobienlai as sobienlaimoi, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then to_number(0,'0') else c.sotien end as mien,sum(b.soluong*b.dongia-case when b.thieu is null then to_number(0,'0') else b.thieu end) as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'Thu trực tiếp' as ghichu from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " and b1.id is null group by a.id,a.mabn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy'), d.sohieu,a.sobienlai,c.sotien,e.userid,e.hoten order by sohieu,sobienlai";
                asqlnt = "select 0 as chon, a.mabn,c.hoten,c.namsinh,to_char(b.ngay,'dd/mm/yyyy') as ngay, d.sohieu,b.sobienlai, b.sobienlai as sobienlaimoi, (b.sotien-b.mien-b.bhyt-b.thieu) as thucthu,case when b.mien is null then to_number(0,'0') else b.mien end as mien,b.sotien, trim(c.sonha || ' ' || c.thon || ' ' ||c.cholam) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(b.sobienlai,9999999)) as sbl,'Thanh toán ra viện' as ghichu from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll b on a.id=b.id left join medibv.btdbn c on a.mabn=c.mabn left join medibv.v_quyenso d on b.quyenso=d.id left join medibv.v_dlogin e on b.userid=e.id " + aexpnt + " order by sohieu,sobienlai";
                asqltu = "select 0 as chon, a.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') as ngay, c.sohieu,a.sobienlai, a.sobienlai as sobienlaimoi, a.sotien as thucthu,to_number(0,'0') as mien,a.sotien, trim(b.sonha || ' ' || b.thon || ' ' || b.cholam) as diachi,d.userid as user_nv,d.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'Tạm ứng' as ghichu from medibvmmyy.v_tamung a left join medibv.btdbn b on a.mabn=b.mabn left join medibv.v_quyenso c on a.quyenso=c.id left join medibv.v_dlogin d on a.userid=d.id " + aexptu + " order by sohieu,sobienlai";

                DataSet adstt = null;
                DataSet adsnt = null;
                DataSet adstu = null;
                DataSet adstg = null;
                DataSet ads = null;

                if (chkTructiep.Checked)
                {
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
                if (chkTrongoi.Checked)
                {
                    asqltt = "select 0 as chon, a.mabn,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') as ngay, d.sohieu,a.sobienlai, a.sobienlai as sobienlaimoi, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then to_number(0,'0') else c.sotien end as mien,sum(b.soluong*b.dongia-case when b.thieu is null then to_number(0,'0') else b.thieu end) as sotien, trim(a.diachi) as diachi,e.userid as user_nv,e.hoten as hoten_nv,a.id,trim(to_char(a.sobienlai,9999999)) as sbl,'Thu trực tiếp' as ghichu from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id " + aexptt + " group by a.id,a.mabn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy'), d.sohieu,a.sobienlai,c.sotien,e.userid,e.hoten order by sohieu,sobienlai";
                    adstg = m_v.get_data_bc(txtTN.Value, txtDN.Value, asqltt, alimit);
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
                if (adstg != null)
                {
                    if (ads == null)
                    {
                        ads = adstg;
                    }
                    else
                    {
                        ads.Merge(adstg);
                    }
                }
                m_dshoadon = ads;
                dgHoadon.DataSource = m_dshoadon.Tables[0];           
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
                tmn_Sotien.Text = dgHoadon.RowCount.ToString() + " "+lan.Change_language_MessageText("HĐ =")+" " + asotien.ToString("###,###,##0.##") + " "+lan.Change_language_MessageText("Đ");
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

                tmn_Sotien.Text = lan.Change_language_MessageText("0 HĐ = 0 Đ");
            }
            butTim.Enabled = true;
            tmn_Chuyenso.Enabled = false;
            tmn_Chuyenngay.Enabled = false;
            tmn_Luu.Enabled = false;
            tmn_Boqua.Enabled = false;
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

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmsuahoadon(m_userid);
                f_Set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmsuahoadon(m_userid).ToString());
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
                if (m_dshoadon != null)
                {
                    m_dshoadon.Tables[0].Rows.Clear();
                    tmn_Sotien.Text = "";
                    tmn_Chuyenso.Enabled = false;
                    tmn_Chuyenngay.Enabled = false;
                    tmn_Luu.Enabled = false;
                    tmn_Boqua.Enabled = false;
                }
            }
            catch
            {
            }
        }
        private void frmSuahoadonthutructiep_Load(object sender, EventArgs e)
        {
            
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

        private void frmSuahoadonthutructiep_KeyDown(object sender, KeyEventArgs e)
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
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void tmn_Timnhanh_Enter(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.LightYellow;
                if (tmn_Timnhanh.Text.Trim().ToLower() == lan.Change_language_MessageText("Tìm kiếm"))
                {
                    tmn_Timnhanh.Text = "";
                }
            }
            catch
            {
            }
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
            m_found = false;
            f_CLear();
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            chkAll.Checked = false;
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
                dgHoadon.Columns["Column7"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column6"].Frozen = !tmn_Fullgrid.Checked;
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
                m_v.set_o_fullgrid_frmsuahoadon(m_userid, tmn_Fullgrid.Checked);
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
        private void tmn_Ketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmn_Luu_Click(object sender, EventArgs e)
        {                        
            try
            {                   
                int n = m_dshoadon.Tables[0].Select("chon=1").Length;
                if (n > 0)
                {
                    if (chkTructiep.Checked)
                    {
                        if (!m_v.tt_suahoadon(m_userid))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu trực tiếp.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                        if (chkTamung.Checked)
                        {
                            if (!m_v.tu_suahoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu tạm ứng.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                            if (chkTTRV.Checked)
                            {
                                if (!m_v.ttrv_suahoadon(m_userid))
                                {
                                    MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu chi ra viện.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                             }
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý lưu những hoá đơn được chọn đã thai đổi (") + n.ToString() + " Hoá đơn)?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        string ammyy = "",sql="",atable="";
                        if (chkTructiep.Checked)
                        {
                            atable = "v_vienphill";
                        }
                        else
                        if (chkTamung.Checked)
                        {
                            atable = "v_tamung";
                        }
                        else
                        if (chkTTRV.Checked)
                        {
                            atable = "v_ttrvll";
                        }
                        foreach (DataRow r in m_dshoadon.Tables[0].Select("chon=1"))
                        {
                            ammyy = m_v.get_mmyy(r["ngay"].ToString());
                            sql = "update medibvmmyy." + atable + " set sobienlai="+r["sobienlaimoi"].ToString()+" where id = "+r["id"].ToString();
                            m_v.execute_data_mmyy(ammyy,sql);
                        }
                        f_Load_DG();
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            butTim_Click(null, null);
        }

        private void tmn_Chitiet_Click(object sender, EventArgs e)
        {
            try
            {
                string aloaihd = "", atitle = "", aid = "", angaythu = "";
                if (chkTructiep.Checked)
                {
                    aloaihd = "1";
                }
                else if (chkTTRV.Checked)
                {
                    aloaihd = "3";
                }
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                aid = arv["id"].ToString();
                angaythu = arv["ngay"].ToString().Substring(0,10);
                atitle = lan.Change_language_MessageText(
"HOÁ ĐƠN:")+" " + arv["sohieu"].ToString() + " - " + arv["sobienlai"].ToString().PadLeft(7, '0') + " "+lan.Change_language_MessageText(
"- NGÀY LẬP:")+" " + m_ngaythu;
                if (aid != "" && angaythu != "")
                {
                    if (chkTamung.Checked)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn thu tạm ứng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        frmChitiethd af = new frmChitiethd(m_v, aid, aloaihd, m_v.get_mmyy(angaythu));
                        af.s_kyhieu = lan.Change_language_MessageText("Ký hiệu: ") + arv["sohieu"].ToString();
                        af.s_sobienlai = lan.Change_language_MessageText("Số hoá đơn: ") + arv["sobienlai"].ToString();
                        af.s_ngayhd = lan.Change_language_MessageText("Ngáy hoá đơn: ") + arv["ngay"].ToString();
                        af.s_benhnhan = lan.Change_language_MessageText("Mã BN: ") + arv["mabn"].ToString() + " - Họ và tên: " + arv["hoten"].ToString() + " - Năm sinh: " + arv["namsinh"].ToString();
                        af.s_diachi = lan.Change_language_MessageText("Địa chỉ: ") + arv["diachi"].ToString();
                        af.s_nhanvien = lan.Change_language_MessageText("Nhân viên thu ngân: ") + arv["hoten_nv"].ToString();
                        af.s_title_form = (chkTructiep.Checked ? lan.Change_language_MessageText("Chi tiết hoá đơn thu trực tiếp") : lan.Change_language_MessageText("Chi tiết hoá đơn thanh toán ra viện"));
                        af.ShowInTaskbar = false;
                        af.TopMost = true;
                        af.ShowDialog(this);
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Chuyenso_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkTructiep.Checked)
                {
                    if (!m_v.tt_suahoadon(m_userid))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu trực tiếp.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                    if (chkTamung.Checked)
                    {
                        if (!m_v.tu_suahoadon(m_userid))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu tạm ứng.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                        if (chkTTRV.Checked)
                        {
                            if (!m_v.ttrv_suahoadon(m_userid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu chi ra viện.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                frmDoiso af = new frmDoiso(m_v, m_userid);
                af.ShowInTaskbar = false;
                if (af.ShowDialog() == DialogResult.OK)
                {
                    string aquyenso = af.s_quyenso,ammyy="",sql="";
                    if (aquyenso != "" && m_dshoadon.Tables[0].Select("chon=1").Length > 0 && MessageBox.Show(this, "Đồng ý đổi quyển sổ các hoá đơn đang chọn sang quyển sổ: [" + af.s_tenquyenso + "] ?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        foreach (DataRow r in m_dshoadon.Tables[0].Select("chon=1"))
                        {
                            ammyy = m_v.get_mmyy(r["ngay"].ToString());
                            if (chkTructiep.Checked)
                            {
                                sql = "update medibvmmyy.v_vienphill set quyenso=" + aquyenso + " where id=" + r["id"].ToString();
                            }
                            else
                                if (chkTamung.Checked)
                                {
                                    sql = "update medibvmmyy.v_tamung set quyenso=" + aquyenso + " where id=" + r["id"].ToString();
                                }
                                else
                                    if (chkTTRV.Checked)
                                    {
                                        sql = "update medibvmmyy.v_ttrvll set quyenso=" + aquyenso + " where id=" + r["id"].ToString();
                                    }
                            m_v.execute_data_mmyy(ammyy, sql);
                        }
                        f_Load_DG();
                    }
                }
            }
            catch
            {
            }
        }
        private void tmn_Chuyenngay_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkTructiep.Checked)
                {
                    if (!m_v.tt_suahoadon(m_userid))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu trực tiếp.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (chkTamung.Checked)
                {
                    if (!m_v.tu_suahoadon(m_userid))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu tạm ứng.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (chkTTRV.Checked)
                {
                    if (!m_v.ttrv_suahoadon(m_userid))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu chi ra viện.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (chkTrongoi.Checked)
                {
                    if (!m_v.tg_suahoadon(m_userid))
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Chưa được phân quyền sửa thông tin hoá đơn thu trọn gói.") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị khi có nhu cầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                frmDoingay af = new frmDoingay(m_v,m_userid);
                af.ShowInTaskbar = false;
                if (af.ShowDialog() == DialogResult.OK)
                {
                    string ammyy = "", ammyynew = "",angaymoi="",sql="",aschemaroot="";
                    angaymoi = af.s_ngay;
                    ammyynew = m_v.get_mmyy(angaymoi);
                    aschemaroot = m_v.s_schemaroot;
                    if (m_dshoadon.Tables[0].Select("chon=1").Length > 0 && MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý đổi ngày các hoá đơn đang chọn thành ngày: [") + angaymoi + "] ?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        foreach (DataRow r in m_dshoadon.Tables[0].Select("chon=1"))
                        {
                            ammyy = m_v.get_mmyy(r["ngay"].ToString());
                            if (ammyy == ammyynew)
                            {
                                if (chkTructiep.Checked || chkTrongoi.Checked)
                                {
                                    sql = "update medibvmmyy.v_vienphill set ngay=to_date('" + angaymoi + "','dd/mm/yyyy') where id=" + r["id"].ToString();
                                }
                                else if (chkTamung.Checked)
                                {
                                    sql = "update medibvmmyy.v_tamung set ngay=to_date('" + angaymoi + "','dd/mm/yyyy') where id=" + r["id"].ToString();
                                }
                                else if (chkTTRV.Checked)
                                {
                                    sql = "update medibvmmyy.v_ttrvll set ngay=to_date('" + angaymoi + "','dd/mm/yyyy') where id=" + r["id"].ToString();
                                }
                                m_v.execute_data_mmyy(ammyy, sql);
                            }
                            else
                            {
                                if (chkTructiep.Checked || chkTrongoi.Checked)
                                {
                                    sql = "update medibvmmyy.v_vienphill set ngay=to_date('" + angaymoi + "','dd/mm/yyyy') where id=" + r["id"].ToString();
                                }
                                else if (chkTamung.Checked)
                                {
                                    sql = "update medibvmmyy.v_tamung set ngay=to_date('" + angaymoi + "','dd/mm/yyyy') where id=" + r["id"].ToString();
                                }
                                else if (chkTTRV.Checked)
                                {
                                    sql = "update medibvmmyy.v_ttrvll set ngay=to_date('" + angaymoi + "','dd/mm/yyyy') where id=" + r["id"].ToString();
                                }
                                m_v.execute_data_mmyy(ammyy, sql);


                                if (chkTructiep.Checked || chkTrongoi.Checked)
                                {
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_vienphill(id,quyenso,sobienlai,ngay,mabn,mavaovien,maql,idkhoa,makp,hoten,phai,namsinh,diachi,loai,loaibn,lanin,userid,ngayud,masothue) select id,quyenso,sobienlai,ngay,mabn,mavaovien,maql,idkhoa,makp,hoten,phai,namsinh,diachi,loai,loaibn,lanin,userid,ngayud,masothue from " + aschemaroot + ammyy + ".v_vienphill where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_vienphict(id,stt,madoituong,mavp,ten,soluong,dongia,mien,thieu,vattu,mabs,makp,tra,ngaytra,lanin,done) select id,stt,madoituong,mavp,ten,soluong,dongia,mien,thieu,vattu,mabs,makp,tra,ngaytra,lanin,done from " + aschemaroot + ammyy + ".v_vienphict where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_mienngtru(id,sotien,ghichu,maduyet,lydo) select id,sotien,ghichu,maduyet,lydo from " + aschemaroot + ammyy + ".v_mienngtru where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    if (chkTrongoi.Checked)
                                    {
                                        sql = "insert into " + aschemaroot + ammyynew + ".v_trongoi(id,sotien,tamung,hoantra,pm,yc,ghichu) select id,sotien,tamung,hoantra,pm,yc,ghichu from " + aschemaroot + ammyy + ".v_trongoi where id=" + r["id"].ToString();
                                        m_v.execute_data(sql);
                                        sql = "insert into " + aschemaroot + ammyynew + ".v_nhom(id,ma,sotien) select id,ma,sotien from " + aschemaroot + ammyy + ".v_nhom where id=" + r["id"].ToString();
                                        m_v.execute_data(sql);
                                    }
                                    
                                    //Xoa trong thang cu
                                    sql = "delete from " + aschemaroot + ammyy + ".v_vienphict where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "delete from " + aschemaroot + ammyy + ".v_mienngtru where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "delete from " + aschemaroot + ammyy + ".v_vienphill where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    if (chkTrongoi.Checked)
                                    {
                                        sql = "delete from " + aschemaroot + ammyy + ".v_nhom where id=" + r["id"].ToString();
                                        m_v.execute_data(sql);
                                        sql = "delete from " + aschemaroot + ammyy + ".v_trongoi where id=" + r["id"].ToString();
                                        m_v.execute_data(sql);
                                    }
                                }
                                else if (chkTamung.Checked)
                                {
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_tamung(id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,userid,ngayud,done,lanin,loaibn,idttrv) select id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,userid,ngayud,done,lanin,loaibn,idttrv from " + aschemaroot + ammyy + ".v_tamung where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_tamungct(id,loaivp,sotien) select id,loaivp,sotien from " + aschemaroot + ammyy + ".v_tamungct where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    //Xoa trong thang cu
                                    sql = "delete from " + aschemaroot + ammyy + ".v_tamung where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "delete from " + aschemaroot + ammyy + ".v_tamungct where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                }
                                else if (chkTTRV.Checked)
                                {
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_ttrvds(id,mabn,mavaovien,maql,idkhoa,giuong,ngayvao,ngayra,chandoan,maicd) select id,mabn,mavaovien,maql,idkhoa,giuong,ngayvao,ngayra,chandoan,maicd from " + aschemaroot + ammyy + ".v_ttrvds where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_ttrvll(id,loaibn,loai,quyenso,sobienlai,ngay,makp,sotien,tamung,mien,bhyt,userid,ngayud,nopthem,thieu,vattu,lanin,idtonghop,chenhlech) select id,loaibn,loai,quyenso,sobienlai,ngay,makp,sotien,tamung,mien,bhyt,userid,ngayud,nopthem,thieu,vattu,lanin,idtonghop,chenhlech from " + aschemaroot + ammyy + ".v_ttrvll where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_ttrvct(id,stt,ngay,makp,madoituong,mavp,soluong,dongia,vat,vattu,sotien) select id,stt,ngay,makp,madoituong,mavp,soluong,dongia,vat,vattu,sotien from " + aschemaroot + ammyy + ".v_ttrvct where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_ttrvpttt(id,ngay,songay_tpt,songay_spt,mavp,so,loaipt,tenpt) select id,ngay,songay_tpt,songay_spt,mavp,so,loaipt,tenpt from " + aschemaroot + ammyy + ".v_ttrvpttt where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_ttrvptttct(id,stt,songay,dongia,loaipt) select id,stt,songay,dongia,loaipt from " + aschemaroot + ammyy + ".v_ttrvptttct where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "insert into " + aschemaroot + ammyynew + ".v_miennoitru(id,lydo,ghichu,maduyet) select id,lydo,ghichu,maduyet from " + aschemaroot + ammyy + ".v_miennoitru where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    //Xoa trong thang cu
                                    sql = "delete from " + aschemaroot + ammyy + ".v_ttrvct where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "delete from " + aschemaroot + ammyy + ".v_ttrvptttct where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "delete from " + aschemaroot + ammyy + ".v_ttrvpttt where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "delete from " + aschemaroot + ammyy + ".v_miennoitru where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "delete from " + aschemaroot + ammyy + ".v_ttrvds where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                    sql = "delete from " + aschemaroot + ammyy + ".v_ttrvll where id=" + r["id"].ToString();
                                    m_v.execute_data(sql);
                                }
                            }
                        }
                        f_Load_DG();
                    }
                }
            }
            catch
            {
            }
        }

        private void dgHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (dgHoadon[e.ColumnIndex, e.RowIndex].Value.ToString() == "1")
                    {
                        m_dshoadon.Tables[0].Rows[e.RowIndex]["chon"] = 0;
                    }
                    else
                    {
                        m_dshoadon.Tables[0].Rows[e.RowIndex]["chon"] = 1;
                    }

                    tmn_Chuyenso.Enabled = (m_dshoadon.Tables[0].Select("chon = 1").Length > 0);
                    tmn_Chuyenngay.Enabled = tmn_Chuyenso.Enabled;
                    tmn_Luu.Enabled = tmn_Chuyenso.Enabled;
                    tmn_Boqua.Enabled = tmn_Chuyenso.Enabled;
                   
                }
 
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
                tmn_Chuyenso.Enabled = (m_dshoadon.Tables[0].Select("chon = 1").Length > 0);
                tmn_Chuyenngay.Enabled = tmn_Chuyenso.Enabled;
                tmn_Luu.Enabled = tmn_Chuyenso.Enabled;
                tmn_Boqua.Enabled = tmn_Chuyenso.Enabled;
            }
            catch
            {
                tmn_Luu.Enabled = false;
                tmn_Boqua.Enabled = false;
                tmn_Chuyenngay.Enabled = false;
                tmn_Chuyenso.Enabled = false;
            }
        }

        private void chkTructiep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTructiep.Checked && m_found)
            {
                butTim_Click(null, null);
            }
        }

        private void chkTamung_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTamung.Checked &&m_found)
            {
                butTim_Click(null, null);
            }
        }

        private void chkTTRV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTTRV.Checked && m_found)
            {
                butTim_Click(null, null);
            }
        }

        private void chkTrongoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrongoi.Checked && m_found)
            {
                butTim_Click(null, null);
            }
        }               
    }
}