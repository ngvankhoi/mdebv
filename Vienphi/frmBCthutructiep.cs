using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmBCthutructiep : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v = new LibVP.AccessData();

        private string v_user = "";

        private DataSet m_ds = new DataSet();
        private DataSet m_ds1 = new DataSet();
        private DataSet m_ds2 = new DataSet();
        private DataSet m_dsnt = new DataSet();
        private DataSet ads = new DataSet();
        private DataSet adsxml;
        private DataTable dtLoaivp;

        private decimal d_bhyt_sotien = 0;
        public frmBCthutructiep(string s_user)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            v_user = s_user;
            f_LoadData();
            m_v.f_SetEvent(this);
        }
        private void f_LoadData()
        {
            txtThuquy.Text = m_v.sys_thuquy;
            txtKetoanvp.Text = m_v.sys_ketoanvp;
            txtPhongtckt.Text = m_v.sys_phongtckt;
            try
            {
                txtNguoilapphieu.Text = m_v.get_data("select hoten from medibv.v_dlogin where id=" + v_user).Tables[0].Rows[0][0].ToString();
            }
            catch
            {
            }
            txtThang.Value = decimal.Parse(DateTime.Now.Month.ToString());
            txtNam.Value = decimal.Parse(DateTime.Now.Year.ToString());
            rdThang_CheckedChanged(null, null);
            txtTN.Value = m_v.s_server_date;
            txtDN.Value = txtTN.Value;
        }
        private void frmBCthutructiep_Load(object sender, EventArgs e)
        {
            chkHienthi.Checked = true;
            chkAll.Checked = true;
            f_Display_User();
            f_Load_Tree_UserID();
            f_Load_Tree_Quyenso();
            f_Load_Tree_Doituong();
            f_Load_tree_LoaiDV();
            f_Load_tree_LoaiBN();
            f_Load_Tree_Lydomien();
            f_Load_Tree_Field();
            f_Load_CB_Baocao();

            d_bhyt_sotien = decimal.Parse(f_Load_Bhyt_Sotien().ToString().Trim());
        }
        private void f_Display_User()
        {
            try
            {
                DataSet ads = m_v.get_data("select id, hoten from medibv.v_dlogin where id='" + v_user + "'");
                this.Text = this.Text + "/" + ads.Tables[0].Rows[0]["hoten"].ToString();
                this.Tag = ads.Tables[0].Rows[0]["hoten"].ToString();
            }
            catch
            {
                this.Tag = "";
            }
        }
        private void f_Load_Tree_UserID()
        {
            try
            {
                string aexp = "";
                if (txtTimuser.Text.Trim() != lan.Change_language_MessageText("Tìm nhanh") && txtTimuser.Text.Trim() != "")
                {
                    aexp = " upper(hoten) like '%" + txtTimuser.Text.Trim().ToUpper() + "%'";
                }
                if (m_v.sys_Loctheonguoidangnhap && m_v.get_data("select admin from medibv.v_dlogin where id=" + v_user).Tables[0].Rows[0][0].ToString() == "0")
                {
                    if (aexp != "")
                        aexp += " and id =" + v_user + "";
                    else aexp += " id =" + v_user + "";
                }
                if (aexp != "")
                {
                    aexp = " where " + aexp;
                }
                string asql = "select to_char(id) as ma,trim(hoten)||'                    ( '||userid||' )' as ten from medibv.v_dlogin " + aexp + " order by hoten";
                m_v.f_Load_Tree(tree_User, m_v.get_data(asql));
                for (int i = 0; i < tree_User.Nodes.Count; i++)
                {
                    if (tree_User.Nodes[i].Tag.ToString() == v_user)
                    {
                        tree_User.Nodes[i].Checked = true;
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Load_Tree_Quyenso()
        {
            try
            {
                string aexp = "", sql = "";
                if (txtTimso.Text.Trim() != lan.Change_language_MessageText("Tìm nhanh") && txtTimso.Text.Trim() != "")
                {
                    aexp = " and upper(sohieu) like '%" + txtTimso.Text.Trim().ToUpper() + "%'";
                }
                sql = "select id as ma, sohieu as ten from medibv.v_quyenso where 1=1 " + aexp + " order by sohieu asc";
                m_v.f_Load_Tree(tree_Quyenso, m_v.get_data(sql));
            }
            catch
            {
            }
        }
        private void f_Load_Tree_Doituong()
        {
            try
            {
                m_v.f_Load_Tree(tree_Doituong, m_v.get_data("select to_char(madoituong,'9') as ma, doituong as ten from medibv.doituong order by madoituong"));
            }
            catch
            {
            }
        }
        private void f_Load_tree_LoaiDV()
        {
            try
            {

                m_v.f_Load_Tree(tree_LoaiDV, m_v.get_data("select to_char(ma,'9') as ma, ten from medibv.v_tenloaivp order by ten asc"));
            }
            catch
            {
            }
        }
        private void f_Load_tree_LoaiBN()
        {
            try
            {                
                m_v.f_Load_Tree(tree_LoaiBN, m_v.get_data("select to_char(id,'9') ma, ten from medibv.v_loaibn order by id"));
            }
            catch
            {
            }
        }
        private void f_Load_Tree_Lydomien()
        {
            try
            {
                m_v.f_Load_Tree(tree_Lydomien, m_v.get_data("select to_char(id) as ma, ten from medibv.v_lydomien order by ten asc"));
            }
            catch
            {
            }
        }
        private void f_Load_Tree_Field()
        {
            try
            {
                m_ds1 = new DataSet();
                m_ds1.Tables.Add("Table");
                m_ds1.Tables[0].Columns.Add("MA");
                m_ds1.Tables[0].Columns.Add("TEN");
                if (rd3.Checked)
                {
                    m_ds1.Tables[0].Rows.Add(new string[] { "MABN", lan.Change_language_MessageText("Mã BN") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "HOTEN", lan.Change_language_MessageText("Họ và tên") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "DIACHI", lan.Change_language_MessageText("Địa chỉ") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "NAMSINH", lan.Change_language_MessageText("Năm sinh") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "NGAY", lan.Change_language_MessageText("Ngày thu") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "QUYENSO", lan.Change_language_MessageText("Quyển sổ") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "SOBIENLAI", lan.Change_language_MessageText("Số biên lai") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "SOCHUNGTU", lan.Change_language_MessageText("Số chứng từ") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "SOTIEN", lan.Change_language_MessageText("Số tiền") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "BHYT", lan.Change_language_MessageText("BHYT trả") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "MIEN", lan.Change_language_MessageText("Miễn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "THIEU", lan.Change_language_MessageText("Nợ") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "TRA", lan.Change_language_MessageText("Hoàn trả") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "THUCTHU", lan.Change_language_MessageText("Thực thu") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "LYDOMIEN", lan.Change_language_MessageText("Lý do miễn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "NGUOIKYMIEN", lan.Change_language_MessageText("Nhân viên nhập miễn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "GHICHU", lan.Change_language_MessageText("Ghi chú miễn") });
                }
                else
                {
                    m_ds1.Tables[0].Rows.Add(new string[] { "NGAY", rd4.Checked ? lan.Change_language_MessageText("Ngày thu") : lan.Change_language_MessageText("Khoa/Phòng khám") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "SOHOADON", lan.Change_language_MessageText("Tổng hoá đơn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "SOTIEN", lan.Change_language_MessageText("Tổng số tiền") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "BHYT", lan.Change_language_MessageText("BHYT trả") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "MIEN", lan.Change_language_MessageText("Tổng miễn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "THIEU", lan.Change_language_MessageText("Tổng nợ") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "THUCTHU", lan.Change_language_MessageText("Tổng thu") });
                }
                m_v.f_Load_Tree(tree_Field, m_ds1);
                m_v.f_Set_CheckID(tree_Field, chkHienthi.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_CB_Baocao()
        {
            try
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("MA");
                ads.Tables[0].Columns.Add("TEN");
                ads.Tables[0].Rows.Add(new string[] { "nhomvp", lan.Change_language_MessageText("Nhóm viện phí") });
                ads.Tables[0].Rows.Add(new string[] { "loaivp", lan.Change_language_MessageText("Loại viện phí") });
                ads.Tables[0].Rows.Add(new string[] { "goivp", lan.Change_language_MessageText("Chi tiết gói viện phí") });
                if (!rd5.Checked)
                {
                    ads.Tables[0].Rows.Add(new string[] { lan.Change_language_MessageText("Khoa"), lan.Change_language_MessageText("Khoa phòng") });
                }

                cbBaocao.DisplayMember = "TEN";
                cbBaocao.ValueMember = "MA";
                cbBaocao.DataSource = ads.Tables[0];
                cbBaocao.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        private void f_Load_Tree_Loai()
        {
            try
            {
                string asql = "select to_char(ma) as ma, ten from medibv.v_nhomvp order by stt asc";
                DataRow r;
                string s = cbBaocao.SelectedValue.ToString();
                switch (cbBaocao.SelectedValue.ToString())
                {
                    case "nhomvp":
                        asql = "select to_char(ma) as ma, ten from medibv.v_nhomvp order by stt asc";
                        m_ds = m_v.get_data(asql);
                        r = m_ds.Tables[0].NewRow();
                        m_ds.WriteXml("..//..//Datareport//cc.xml", XmlWriteMode.WriteSchema);
                        break;
                    case "loaivp":
                    case "goivp":
                        asql = "select to_char(id) as ma, ten from medibv.v_loaivp order by stt asc";
                        m_ds = m_v.get_data(asql);
                        r = m_ds.Tables[0].NewRow();
                        r["ma"] = "0";
                        r["ten"] = lan.Change_language_MessageText("Thuốc khoa dược");
                        m_ds.Tables[0].Rows.Add(r);
                        break;
                    case "Khoa":
                        asql = "select makp as ma, tenkp as ten from medibv.btdkp_bv order by tenkp asc";
                        m_ds = m_v.get_data(asql);
                        r = m_ds.Tables[0].NewRow();
                        r["ma"] = "";
                        r["ten"] = lan.Change_language_MessageText("Khác");
                        m_ds.Tables[0].Rows.Add(r);
                        break;
                }
                m_v.f_Load_Tree(tree_Loai, m_ds);
                m_v.f_Set_CheckID(tree_Loai, chkAll.Checked);
            }
            catch
            {
            }
        }
        private void chkUserid_CheckedChanged(object sender, EventArgs e)
        {
            m_v.f_Set_CheckID(tree_User, chkUserid.Checked);
        }

        private void txtTimuser_TextChanged(object sender, EventArgs e)
        {
            f_Load_Tree_UserID();
        }

        private void txtTimso_TextChanged(object sender, EventArgs e)
        {
            f_Load_Tree_Quyenso();
        }

        private void chkAll_So_CheckedChanged(object sender, EventArgs e)
        {
            m_v.f_Set_CheckID(tree_Quyenso, chkAll_So.Checked);
        }

        private void chkDoituong_CheckedChanged(object sender, EventArgs e)
        {
            m_v.f_Set_CheckID(tree_Doituong, chkDoituong.Checked);
        }

        private void chkLoaiBN_CheckedChanged(object sender, EventArgs e)
        {
            m_v.f_Set_CheckID(tree_LoaiBN, chkLoaiBN.Checked);
        }

        private void chkLoaiDV_CheckedChanged(object sender, EventArgs e)
        {
            m_v.f_Set_CheckID(tree_LoaiDV, chkLoaiDV.Checked);
        }

        private void chkLydomen_CheckedChanged(object sender, EventArgs e)
        {
            m_v.f_Set_CheckID(tree_Lydomien, chkLydomen.Checked);
        }
        private void chkHienthi_CheckedChanged(object sender, EventArgs e)
        {
            m_v.f_Set_CheckID(tree_Field, chkHienthi.Checked);
        }
        private void tree_Quyenso_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Quyenso.Nodes.Count; i++)
                {
                    if (tree_Quyenso.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkAll_So.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_Doituong_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Doituong.Nodes.Count; i++)
                {
                    if (tree_Doituong.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkDoituong.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_LoaiBN_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_LoaiBN.Nodes.Count; i++)
                {
                    if (tree_LoaiBN.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkLoaiBN.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_LoaiDV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_LoaiDV.Nodes.Count; i++)
                {
                    if (tree_LoaiDV.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkLoaiDV.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_Lydomien_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Lydomien.Nodes.Count; i++)
                {
                    if (tree_Lydomien.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkLydomen.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_User_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_User.Nodes.Count; i++)
                {
                    if (tree_User.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkUserid.Checked = false;
            }
            catch
            {
            }
        }

        private void cbBaocao_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Load_Tree_Loai();
        }

        private void rd5_CheckedChanged(object sender, EventArgs e)
        {
            if (rd5.Checked)
            {
                f_Load_CB_Baocao();
                f_Load_Tree_Field();
            }		
        }

        private void rd4_CheckedChanged(object sender, EventArgs e)
        {
            if (rd4.Checked)
            {
                f_Load_CB_Baocao();
                f_Load_Tree_Field();
            }
        }

        private void rd3_CheckedChanged(object sender, EventArgs e)
        {
            if (rd3.Checked)
            {
                f_Load_CB_Baocao();
                f_Load_Tree_Field();
            }
        }

        private void rdThang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtThang.Enabled = rdThang.Checked;
                txtNam.Enabled = rdThang.Checked;
                txtTN.Enabled = !txtThang.Enabled;
                txtDN.Enabled = !txtThang.Enabled;
                txtThang_ValueChanged(null, null);
            }
            catch
            {
            }
        }

        private void txtThang_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString()), 1);
                txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString()), DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString())));
            }
            catch
            {
            }
        }

        private void txtNam_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString()), 1);
                txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString()), DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString())));
            }
            catch
            {
            }
        }

        private void rdNgay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtThang.Enabled = rdThang.Checked;
                txtNam.Enabled = rdThang.Checked;
                txtTN.Enabled = !txtThang.Enabled;
                txtDN.Enabled = !txtThang.Enabled;
                txtThang_ValueChanged(null, null);
            }
            catch
            {
            }
        }

        private void tmn_Xem_Click(object sender, EventArgs e)
        {
            f_Ketxuat("EXCEL");
        }
        private void f_Ketxuat(string v_format)
        {
            try
            {
                string asql = "", asql1 = "", asqlht = "", asqlnt = "", asqlnt1 = "";
                string aloaibn = "", auserid = "", aquyenso = "", alydomien = "", abaocao = "", adoituong = "";
                string atmp = "", aexp = "", atmp1 = "", atmp2 = "", atmp_goi = "", atmpnt = "";
                //
                //decimal atyle = 0;
                //atyle = f_get_Tylebhytchitra();
                //
                aloaibn = m_v.f_Get_CheckID(tree_LoaiBN);
                auserid = m_v.f_Get_CheckID(tree_User);
                aquyenso = m_v.f_Get_CheckID(tree_Quyenso);
                alydomien = m_v.f_Get_CheckID(tree_Lydomien);
                abaocao = m_v.f_Get_CheckID(tree_Loai);
                adoituong = m_v.f_Get_CheckID(tree_Doituong);
       
                aexp = "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')";
              
                asqlht = "select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')";
                
                if (aloaibn != "")
                {
                    aexp = aexp + " and a.loaibn in(" + aloaibn + ")";
                }
                if (auserid != "")
                {
                    aexp = aexp + " and a.userid in(" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp = aexp + " and a.quyenso in(" + aquyenso + ")";
                }
                if (adoituong != "")
                {
                    aexp = aexp + " and b.madoituong in(" + adoituong + ")";
                }
                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    if (decimal.Parse(txtTuso.Text.Trim()) > decimal.Parse(txtDenso.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTuso.Focus();
                        return;
                    }
                    else
                    {
                        aexp += " and a.sobienlai >= " + txtTuso.Text.Trim() + " and a.sobienlai <= " + txtDenso.Text.Trim() + "";
                    }
                }
                //if (abaocao != "")
                //{
                //    switch (cbBaocao.SelectedValue.ToString())
                //    {
                //        case "nhomvp":
                //            aexp = aexp + " and f.id_nhom in(" + abaocao + ")";
                //            break;
                //        case "loaivp":
                //        case "goivp":
                //            aexp = aexp + " and f.id in(" + abaocao + ")";
                //            break;
                //        case "Khoa":
                //            aexp = aexp + " and i.makp in(" + abaocao + ")";
                //            break;
                //    }
                //}
                if (chkLydomen.Checked)
                {
                    if (alydomien != "")
                    {
                        aexp = aexp + " and c.lydo in(" + alydomien + ")";
                    }
                    else
                    {
                        aexp = aexp + " and c.lydo is null";
                    }
                }

                m_ds2 = m_ds1.Clone();

                //Cac field se hien thi
                for (int i = 0; i < tree_Field.Nodes.Count; i++)
                {
                    if (tree_Field.Nodes[i].Checked)
                    {
                        try
                        {
                            m_ds2.Tables[0].Rows.Add(new string[] { tree_Field.Nodes[i].Tag.ToString(), tree_Field.Nodes[i].Text.Trim() });
                        }
                        catch
                        {
                        }
                    }
                }
                //
                bool ok = false;
                for (int i = 0; i < tree_Loai.Nodes.Count; i++)
                {
                    if (tree_Loai.Nodes[i].Checked)
                    {
                        ok = true;
                        break;
                    }
                }
                
                string atable = "";
                switch (cbBaocao.SelectedValue.ToString())
                {
                    case "nhomvp":
                        //atable = "to_char(h.ma)";
                        atable = "to_char(f.id_nhom)";
                        break;
                    case "loaivp":
                    case "goivp":
                        //atable = "to_char(g.id)";
                        atable = "to_char(f.id)";
                        break;
                    case "Khoa":
                        atable = "trim(to_char(nvl(to_char(i.makp),'')))";
                        break;
                }
                atmp = "";
                atmp1 = "";
                if (ok)
                {
                    for (int i = 0; i < tree_Loai.Nodes.Count; i++)
                    {
                        if (tree_Loai.Nodes[i].Checked)
                        {
                            try
                            {
                                atmp = atmp + ",round(sum(to_number(decode(" + atable + ",'" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + "',b.soluong*b.dongia-b.tra-b.mien,0))),0) LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                atmp_goi = atmp_goi + ",round(sum(to_number(decode(" + atable + ",'" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + "',b.soluong*f.sotien,0))),0) LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                atmp1 = atmp1 + ",round(sum(to_number(decode(" + atable + ",'" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + "',b.soluong*b.dongia-b.tra-case when b.madoituong=1 then case when instr(nvl(bb.sothe,' '),'UC')>0 or instr(nvl(bb.sothe,' '),'VC')>0 or instr(nvl(bb.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end,0))),0) LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                atmp2 = atmp2 + ",round(nvl(sum(LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + "),0),0) as LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                atmpnt = atmpnt + ",sum(to_number(case when " + atable + "=" + m_ds.Tables[0].Rows[i]["MA"].ToString() + " then b.soluong*b.dongia + b.soluong*b.dongia*nvl(b.vat,0)/100 else 0 end)) as LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                m_ds2.Tables[0].Rows.Add(new string[] { "LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim(), tree_Loai.Nodes[i].Text.Trim() });
                            }
                            catch (Exception exx)
                            {
                                MessageBox.Show(exx.ToString());
                            }
                        }
                    }
                    atmp = atmp.Trim().Trim(',');
                    atmp_goi = atmp_goi.Trim().Trim(',');
                    atmp1 = atmp1.Trim().Trim(',');
                    atmp = atmp.Trim();
                    atmp_goi = atmp_goi.Trim();
                    atmp1 = atmp1.Trim();
                    if (atmp.Length > 0 || atmp_goi.Length > 0)
                    {
                        atmp = "," + atmp.Trim(',');
                        atmp_goi = "," + atmp_goi.Trim(',');
                        m_ds2.Tables[0].Rows.Add(new string[] { lan.Change_language_MessageText("LLLLTC"), lan.Change_language_MessageText("Tổng cộng") });
                    }
                    if (atmp1.Length > 0)
                    {
                        atmp1 = "," + atmp1.Trim(',');
                    }
                }
                //string asqldmbd = "select a1.id id, c1.id_loai id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, nvl(to_number(b0.id),0) id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) c1 on b1.nhomvp=c1.ma ";
                string sql_goi = "";
                //string asqldmbd = "select a1.id as idvp, c1.id_loai as id, c1.ma as id_nhom, c1.ten as tenloai, c1.stt as sttnhom, 0 as sotien from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai, a0.ten, a0.stt from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma";
                string asqldmbd = " select a.id as idvp, a.id_loai as id, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom, 0 as sotien from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                asqldmbd += " union all ";
                asqldmbd += " select a.id as idvp, 0 as id, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom, 0 as sotien from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma";
                sql_goi = " select a.id as idvp, a.id_loai as id, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom, a.sotien from medibv.v_trongoi a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma where a.id_gia=0 and a.sotien<>0";
                if (rd5.Checked)//Nhóm theo KP
                {
                    asql = "select i.tenkp ngay, i.makp, count(distinct a.id) sohoadon, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, sum(nvl(c.sotien,0)) mien, sum(nvl(b.thieu,0)) thieu, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(b.thieu,0)-to_number(decode(b.madoituong,1,nvl(b.mien,0),0)))-sum(nvl(c.sotien,0)) thucthu " + atmp + " ";
                    asql += " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join (" + asqldmbd + ") f on b.mavp=f.idvp inner join medibv.btdkp_bv i on a.makp=i.makp where aa.id is null " + aexp + " group by i.tenkp,i.makp order by i.tenkp asc,i.makp asc";//left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 as id, 0 as id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) h on g.id_nhom=h.ma 
                    asql1 = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, i.tenkp ngay, i.makp, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu lydomien, cc.ten nguoikymien, a.mabn, a.hoten, a.namsinh, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(to_number(decode(b.madoituong,1,b.mien,0)),0)-nvl(b.thieu,0))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp + " ";
                    asql1 += " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma inner join medibv.v_quyenso d on a.quyenso=d.quyenso inner join medibv.v_dlogin e on a.userid=e.id left join (" + asqldmbd + ") f on b.mavp=f.idvp inner join medibv.btdkp_bv i on a.makp=i.makp where aa.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten, a.namsinh, c.sotien, e.hoten, i.makp,i.tenkp, c.ghichu, cc.ten,  e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, i.tenkp asc, i.makp asc";//left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 as id, 0 as id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) h on g.id_nhom=h.id 

                    asqlnt = "select i.tenkp ngay, i.makp, count(distinct a.id) sohoadon, 0 sotien, 0 bhyt ,0 mien, 0 thieu, 0 thucthu " + atmp1 + " ";
                    asqlnt += "from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 on a.id=a0.id left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_ttrvbhyt bb on a.id=bb.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp inner join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp + " group by i.tenkp,i.makp order by i.tenkp asc,i.makp asc";
                    asqlnt1 = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, i.tenkp ngay, i.makp, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu lydomien, cc.ten nguoikymien, a1.mabn, a1.hoten, a1.namsinh, nvl(a.sotien,0) sotien, nvl(a.bhyt,0) bhyt, nvl(a.mien,0) mien, 0 thieu, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp1 + " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 on a.id=a0.id inner join medibv.btdbn a1 on a0.mabn=a1.mabn left join (" + asqlht + ") aa a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc c.maduyet=cc.ma inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp inner join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, a.sotien,a.bhyt,a.mien,d.sohieu, a1.mabn, a1.hoten, a1.namsinh, e.hoten, i.makp,i.tenkp, c.ghichu, cc.ten,  e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, i.tenkp asc, i.makp asc";
                }
                else
                {
                    if (rd4.Checked)//Nhóm theo ngày
                    {
                        asql = "select to_char(a.ngay,'dd/mm/yyyy') ngay, count(distinct a.id) sohoadon, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt ,sum(nvl(c.sotien,0)) mien, sum(nvl(b.thieu,0)) thieu, sum(to_number(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(b.thieu,0)-to_number(decode(b.madoituong,1,nvl(b.mien,0),0))))-sum(nvl(c.sotien,0)) thucthu " + atmp + " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp inner join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp + " group by to_char(a.ngay,'dd/mm/yyyy') order by to_char(a.ngay,'dd/mm/yyyy') asc";
                        asql1 = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu lydomien, cc.ten nguoikymien, a.mabn, a.hoten, a.namsinh, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(to_number(decode(b.madoituong,1,b.mien,0)),0)-nvl(b.thieu,0))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp + " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + asqldmbd + ") f as b.mavp=f.idvp inner join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten, a.namsinh, c.sotien, e.hoten, a.ngay, c.ghichu, cc.ten,  e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";

                        asqlnt = "select ngay, count(distinct id) as sohoadon, sum(sotien) as sotien, sum(bhyt) as bhyt, sum(mien) as mien, sum(thieu) as thieu, sum(thucthu) as thucthu " + atmp2 + " from (";
                        asqlnt += "select to_char(a.ngay,'dd/mm/yyyy') ngay, a.id , nvl(a.sotien,0) sotien, nvl(a.bhyt,0) bhyt, nvl(a.mien,0) mien, nvl(a.thieu,0) thieu, nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0) as thucthu " + atmp1 + " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 on a.id=a0.id left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_ttrvbhyt bb on a.id=bb.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp + " group by to_char(a.ngay,'dd/mm/yyyy'), a.id, nvl(a.sotien,0), nvl(a.bhyt,0), nvl(a.mien,0), nvl(a.thieu,0) order by to_char(a.ngay,'dd/mm/yyyy')) as froo group by ngay order by ngay";
                        asqlnt1 = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu lydomien, cc.ten nguoikymien, a1.mabn, a1.hoten, a1.namsinh, nvl(a.sotien,0) sotien, nvl(a.bhyt,0) bhyt, nvl(a.mien,0) mien, 0 thieu, nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp1 + " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 a.id=a0.id inner join medibv.btdbn a1 a0.mabn=a1.mabn left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + asqldmbd + ") f left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null and " + aexp + " group by a.id, a.quyenso, a.sobienlai, a.sotien,a.bhyt,a.mien,d.sohieu, a1.mabn, a1.hoten, a1.namsinh, e.hoten, a.ngay, c.ghichu, cc.ten,  e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
                    }
                    else//Nhóm theo biên lai
                    {
                        if (cbBaocao.SelectedValue.ToString() == "goivp")
                        {
                            asql = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a.mabn, a.hoten,a.diachi, a.namsinh, sum(nvl(f.sotien,0)*b.soluong-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end) as sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(b.tra) as tra, sum(to_number(nvl(f.sotien,0)*b.soluong-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end-nvl(to_number(decode(b.madoituong,1,b.mien,0)),0)-nvl(b.thieu,0)))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp_goi + " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + sql_goi + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten, a.diachi, a.namsinh, c.sotien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";// left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 from dual) h on g.id_nhom=h.ma 
                        }
                        else
                        {
                            asql = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a.mabn, a.hoten,a.diachi, a.namsinh, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) as sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(b.tra) as tra, sum(to_number(nvl(b.soluong,0)*nvl(b.dongia,0)-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end-nvl(to_number(decode(b.madoituong,1,b.mien,0)),0)-nvl(b.thieu,0)))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp + " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where '1' = '1' " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten,a.diachi, a.namsinh, c.sotien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";// left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 from dual) h on g.id_nhom=h.ma 
                        }

                        asqlnt = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai";
                        asqlnt += ", to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso";
                        asqlnt += ", d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien";
                        asqlnt += ", cc.ten nguoikymien, a1.mabn, a1.hoten, a1.thon ||' ' ||px.tenpxa||' '||q.tenquan ||' '||t.tentt as diachi, a1.namsinh, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) as sotien, nvl(a.bhyt,0) bhyt, round(nvl(a.mien,0)) mien, 0 thieu, sum(b.tra) as tra, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) - nvl(sum(b.tra),0)>=0 then nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) - nvl(sum(b.tra),0)end,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmpnt + " ";
                        asqlnt += "from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 on a.id=a0.id inner join medibv.btdbn a1  on a0.mabn=a1.mabn left join medibv.btdpxa px on a1.maphuongxa=px.maphuongxa left join medibv.btdquan q on a1.maqu=q.maqu and px.maqu=q.maqu left join medibv.btdtt t on a1.matt=t.matt and a1.matt=t.matt left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_ttrvbhyt bb on a.id=bb.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where '1' = '1' " + aexp + " ";
                        asqlnt += " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a1.mabn, a1.hoten, a1.thon, px.tenpxa, q.tenquan, t.tentt, a1.namsinh, a.sotien,a.bhyt,a.mien, a.tamung,e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";

                        //asqlnt = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a1.mabn, a1.hoten, a1.thon ||' ' ||px.tenpxa||' '||q.tenquan ||' '||t.tentt as diachi, a1.namsinh, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) as sotien, round(nvl(a.bhyt,0),0) bhyt, round(nvl(a.mien,0)) mien, 0 thieu, round(sum(b.soluong*b.dongia-b.tra) - sum(case when b.madoituong=1 then case when instr(nvl(bb.sothe,' '),'UC')>0 or instr(nvl(bb.sothe,' '),'VC')>0 or instr(nvl(bb.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end),0) as thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp1 + " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 on a.id=a0.id inner join medibv.btdbn a1  on a0.mabn=a1.mabn left join medibv.btdpxa px on a1.maphuongxa=px.maphuongxa left join medibv.btdquan q on a1.maqu=q.maqu and px.maqu=q.maqu left join medibv.btdtt t on a1.matt=t.matt and a1.matt=t.matt left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_ttrvbhyt bb on a.id=bb.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a1.mabn, a1.hoten, a1.thon, px.tenpxa, q.tenquan, t.tentt, a1.namsinh, a.sotien,a.bhyt,a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
                    }
                }
                if (m_ds2.Tables[0].Rows.Count <= 0)
                {                
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn thông tin báo cáo cần hiển thị"), m_v.s_AppName, MessageBoxButtons.OK);
                    return;
                }
                if ((chkPhongkham.Checked && chkNoitru.Checked) || (!chkPhongkham.Checked && !chkNoitru.Checked))
                {
                    if (rd4.Checked)//ngay
                    {
                        asql = asql.Replace("order by to_char(a.ngay,'dd/mm/yyyy') asc", "");
                        asqlnt = asqlnt.Replace("order by to_char(a.ngay,'dd/mm/yyyy') asc", "");
                        asql += " union all ";
                        asql += asqlnt;
                        asql = "select * from ((" + asql + ")) froo order by to_date(ngay,'dd/mm/yyyy')";

                        asql1 = asql1.Replace("order by d.sohieu asc, a.sobienlai asc, a.ngay asc", "");
                        asqlnt1 = asqlnt1.Replace("order by d.sohieu asc, a.sobienlai asc, a.ngay asc", "");
                        asql1 += " union all ";
                        asql1 += asqlnt1;
                        asql1 = "select * from ((" + asql1 + ")) froo order by to_date(ngay,'dd/mm/yyyy')";
                    }
                    else if (rd5.Checked)//kp 
                    {
                        asql = asql.Replace("order by i.tenkp asc,i.makp asc", "");
                        asqlnt = asqlnt.Replace("order by i.tenkp asc,i.makp asc", "");
                        asql += " union all ";
                        asql += asqlnt;
                        asql = "select * from ((" + asql + ")) froo order by ngay,makp";

                        asql1 = asql1.Replace("order by d.sohieu asc, a.sobienlai asc, i.tenkp asc, i.makp asc", "");
                        asqlnt1 = asqlnt1.Replace("order by d.sohieu asc, a.sobienlai asc, i.tenkp asc, i.makp asc", "");
                        asql1 += " union all ";
                        asql1 += asqlnt1;
                        asql1 = "select * from ((" + asql1 + ")) froo order by ngay,makp";
                    }
                    else
                    {
                        asql = asql.Replace("order by d.sohieu asc, a.sobienlai asc, a.ngay asc", "");
                        asqlnt = asqlnt.Replace("order by d.sohieu asc, a.sobienlai asc, a.ngay asc", "");
                        asql += " union all ";
                        asql += asqlnt;
                        asql = "select * from ((" + asql + ")) froo order by to_number(quyensoid) asc, to_number(sobienlai) asc, to_date(ngay,'dd/mm/yyyy') asc";
                    }
                }
                else
                    if (chkPhongkham.Checked)
                    {
                    }
                    else
                    {
                        if (chkNoitru.Checked)
                        {
                            asql = asqlnt;
                            asql1 = asqlnt1;
                        }
                    }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (rd4.Checked || rd5.Checked)
                {
                    DataSet ads1 = new DataSet();
                    ads1 = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    for (int i = 0; i < ads.Tables[0].Rows.Count; i++)
                    {
                        ads.Tables[0].Rows[i]["sohoadon"] = 0;
                        ads.Tables[0].Rows[i]["sotien"] = 0;
                        ads.Tables[0].Rows[i]["bhyt"] = 0;
                        ads.Tables[0].Rows[i]["mien"] = 0;
                        ads.Tables[0].Rows[i]["thieu"] = 0;
                        ads.Tables[0].Rows[i]["thucthu"] = 0;
                        try
                        {
                            foreach (DataRow r1 in ads1.Tables[0].Select("ngay='" + ads.Tables[0].Rows[i]["ngay"].ToString() + "'"))
                            {
                                ads.Tables[0].Rows[i]["sohoadon"] = decimal.Parse(ads.Tables[0].Rows[i]["sohoadon"].ToString()) + decimal.Parse(r1["sohoadon"].ToString());
                                ads.Tables[0].Rows[i]["sotien"] = decimal.Parse(decimal.Parse(ads.Tables[0].Rows[i]["sotien"].ToString()).ToString("###,###,##0")) + decimal.Parse(decimal.Parse(r1["sotien"].ToString()).ToString("###,###,##0"));
                                ads.Tables[0].Rows[i]["bhyt"] = decimal.Parse(decimal.Parse(ads.Tables[0].Rows[i]["bhyt"].ToString()).ToString("###,###,##0")) + decimal.Parse(decimal.Parse(r1["bhyt"].ToString()).ToString("###,###,##0"));
                                ads.Tables[0].Rows[i]["mien"] = decimal.Parse(decimal.Parse(ads.Tables[0].Rows[i]["mien"].ToString()).ToString("###,###,##0")) + decimal.Parse(decimal.Parse(r1["mien"].ToString()).ToString("###,###,##0"));
                                ads.Tables[0].Rows[i]["thieu"] = decimal.Parse(decimal.Parse(ads.Tables[0].Rows[i]["thieu"].ToString()).ToString("###,###,##0")) + decimal.Parse(decimal.Parse(r1["thieu"].ToString()).ToString("###,###,##0"));
                                ads.Tables[0].Rows[i]["thucthu"] = decimal.Parse(decimal.Parse(ads.Tables[0].Rows[i]["thucthu"].ToString()).ToString("###,###,##0")) + decimal.Parse(decimal.Parse(r1["thucthu"].ToString()).ToString("###,###,##0"));
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                if ((ads == null) || (ads.Tables[0].Rows.Count <= 0))
                {                 
                    MessageBox.Show(this, lan.Change_language_MessageText("Không có số liệu báo cáo"), m_v.s_AppName, MessageBoxButtons.OK);
                    return;
                }
                //Them dong tong cong vao cuoi cot
                if (atmp.Length > 0)
                {
                    try
                    {
                        ads.Tables[0].Columns.Add(lan.Change_language_MessageText("LLLLTC"), typeof(decimal));
                        foreach (DataRow r1 in ads.Tables[0].Rows)
                        {
                            r1[ads.Tables[0].Columns.Count - 1] = 0;
                            for (int i = 0; i < ads.Tables[0].Columns.Count - 1; i++)
                            {
                                if (ads.Tables[0].Columns[i].DataType.ToString() == "System.Decimal" && ads.Tables[0].Columns[i].ColumnName.IndexOf("LLLL") == 0)
                                {
                                    r1[ads.Tables[0].Columns.Count - 1] = decimal.Parse(r1[ads.Tables[0].Columns.Count - 1].ToString()) + decimal.Parse(r1[i].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                //Them dong tong cong vao cuoi dong
                DataRow r = ads.Tables[0].NewRow();
                for (int i = 0; i < ads.Tables[0].Columns.Count; i++)
                {
                    if (ads.Tables[0].Columns[i].DataType.ToString() == "System.Decimal")
                    {
                        r[i] = "0";
                    }
                }

                for (int i = 0; i < ads.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ads.Tables[0].Columns.Count; j++)
                    {
                        if (ads.Tables[0].Columns[j].DataType.ToString() == "System.Decimal")
                        {
                            try
                            {
                                r[j] = decimal.Parse(r[j].ToString()) + decimal.Parse(ads.Tables[0].Rows[i][j].ToString());
                            }
                            catch
                            {
                                r[j] = 0;
                            }
                        }
                    }
                }

                try
                {
                    r["mabn"] = lan.Change_language_MessageText("Tổng:") + " " + ads.Tables[0].Rows.Count.ToString();
                }
                catch
                {
                    try
                    {
                        r["ngay"] = lan.Change_language_MessageText("Tổng:") + " " + ads.Tables[0].Rows.Count.ToString();
                    }
                    catch
                    {
                    }
                }
                ads.Tables[0].Rows.Add(r);
                try
                {
                    if (!System.IO.Directory.Exists("..//..//Export"))
                    {
                        System.IO.Directory.CreateDirectory("..//..//Export");
                    }
                }
                catch
                {
                }
                string apath = Application.ExecutablePath;
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Replace("\\", "//");
              
                DataSet ads_HT = new DataSet();
                ads.WriteXml("..//..//Datareport//thu.xml", XmlWriteMode.WriteSchema);
                string s_loai = "";
                for (int i = 1; i < tree_Loai.Nodes.Count; i++)
                {
                    if (tree_Loai.Nodes[i].Checked)
                    {
                        try
                        {
                            s_loai += m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + ",";
                        }
                        catch
                        {
                        }
                    }
                }
                switch (cbBaocao.SelectedValue.ToString())
                {
                    case "nhomvp":                
                        asql = "select d.id_nhom as loai, mabn, quyenso, sobienlai, sum(a.sotien) as sotien from medibvmmyy.v_hoantract a,medibvmmyy.v_hoantra b,medibv.v_giavp c,medibv.v_loaivp d where a.id=b.id and c.id_loai=d.id and a.loaivp=c.id and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') ";
                        if (s_loai != "") asql += " and d.id_nhom in(" + s_loai.Trim(',') + ")";
                        asql += " group by d.id_nhom ,mabn, quyenso, sobienlai";
                        break;
                    case "loaivp":
                    case "goivp":
                        asql = "select c.id_loai as loai, mabn, quyenso, sobienlai, sum(a.sotien) as sotien from medibvmmyy.v_hoantract a,medibvmmyy.v_hoantra b,medibv.v_giavp c where a.id=b.id and a.loaivp=c.id and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')";
                        if (s_loai != "") asql += " and c.id_loai in(" + s_loai.Trim(',') + ")";
                        asql += " group by c.id_loai, mabn, quyenso, sobienlai";
                        break;
                }
                if (rd3.Checked && cbBaocao.SelectedValue.ToString().Trim()!="goivp")
                {
                    ads_HT = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    foreach (DataRow r12 in ads_HT.Tables[0].Rows)
                    {
                        foreach (DataRow r123 in ads.Tables[0].Select("mabn='" + r12["mabn"].ToString() + "' and quyenso='" + r12["quyenso"].ToString() + "' and sobienlai='" + r12["sobienlai"].ToString() + "'"))
                        {
                            string asa = "LLLL" + r12["loai"].ToString();
                            if (decimal.Parse(r123["LLLL" + r12["loai"].ToString()].ToString()) > 0 && asa == "LLLL" + r12["loai"].ToString())
                            {
                                r123["LLLL" + r12["loai"].ToString()] = decimal.Parse(r123["LLLL" + r12["loai"].ToString()].ToString()) - decimal.Parse(r12["sotien"].ToString());
                                ads.AcceptChanges();
                            }
                        }
                    }
                }
                switch (v_format)
                {
                    case "HTML":
                        f_Export_HTML(ads, m_ds2, apath + "//Export//baocaothuvienphitructiep");
                        break;
                    default:
                        f_Export_Excel(ads, m_ds2, apath + "//Export//baocaothuvienphitructiep");
                        break;
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Export_Excel(DataSet v_ds1, DataSet v_ds2, string v_filepath)
        {
            v_filepath = v_filepath + ".xls";
            try
            {
                int n = 0, n1 = 0;
                string t = "";
                if (rd3.Checked)
                {
                    t = " " + lan.Change_language_MessageText("THEO HOÁ ĐƠN");
                }
                else
                    if (rd4.Checked)
                    {
                        t = " " + lan.Change_language_MessageText("THEO NGÀY");
                    }
                    else
                        if (rd5.Checked)
                        {
                            t = " " + lan.Change_language_MessageText("THEO KHOA PHÒNG");
                        }
                t = "";

                for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                {
                    n += v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL") == 0 ? 1 : 0;
                }

                System.IO.StreamWriter sw = new System.IO.StreamWriter(v_filepath, false, System.Text.Encoding.UTF8);
                string astr = "";
                astr = "<Table border=0>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + m_v.Syte;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + m_v.Tenbv;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=40 align=center style=\"font-family: Arial; font-size: 14pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + lan.Change_language_MessageText("BÁO CÁO THU VIỆN PHÍ TRỰC TIẾP") + " " + t;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=center style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + lan.Change_language_MessageText("(Từ ngày") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày") + " " + txtDN.Text.Substring(0, 10) + ")";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + "";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "</Table>";
                sw.Write(astr);

                astr = "<Table border=1 style=\"font-family: Arial; font-size: 10pt; font-weight: normal\">";

                if ((n < v_ds2.Tables[0].Rows.Count) && (n > 0))
                {
                    astr = astr + "<tr>";
                    for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                    {
                        if (v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL") == 0)
                        {
                        }
                        else
                        {
                            astr = astr + "<th rowspan=2>";
                            astr = astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
                            astr = astr + "</th>";
                        }
                    }
                    astr = astr + "<th colspan=" + n.ToString() + ">";
                    astr = astr + lan.Change_language_MessageText("THÔNG TIN CHI TIẾT");
                    astr = astr + "</th>";

                    astr = astr + "</tr>";

                    astr = astr + "<tr>";
                    for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                    {
                        if (v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL") == 0)
                        {
                            astr = astr + "<th>";
                            astr = astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
                            astr = astr + "</th>";
                        }
                    }
                    astr = astr + "</tr>";
                }
                else
                {
                    astr = astr + "<tr>";
                    for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                    {
                        n1 = (v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL") == 0) ? 1 : 2;
                        astr = astr + "<th>";
                        astr = astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
                        astr = astr + "</th>";
                    }
                    astr = astr + "</tr>";
                }
                //Dong so thu tu
                astr = astr + "<tr>";
                for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                {
                    astr = astr + "<th>";
                    astr = astr + (i + 1).ToString();
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                sw.Write(astr);

                string at = "";
                for (int i = 0; i < v_ds1.Tables[0].Rows.Count; i++)
                {
                    astr = "<tr>";
                    for (int j = 0; j < v_ds2.Tables[0].Rows.Count; j++)
                    {
                        for (int k = 0; k < v_ds1.Tables[0].Columns.Count; k++)
                        {
                            //MessageBox.Show(v_ds1.Tables[0].Columns[k].ColumnName.ToUpper()+"="+v_ds2.Tables[0].Rows[j]["MA"].ToString().ToUpper());
                            if (v_ds1.Tables[0].Columns[k].ColumnName.ToUpper() == v_ds2.Tables[0].Rows[j]["MA"].ToString().ToUpper())
                            {
                                if (v_ds1.Tables[0].Columns[k].DataType.ToString() == "System.Decimal")
                                {
                                    try
                                    {
                                        at = decimal.Parse(v_ds1.Tables[0].Rows[i][k].ToString()).ToString("###,###,##0.##");
                                    }
                                    catch
                                    {
                                        at = "";
                                    }
                                    if (at == "0")
                                    {
                                        at = "";
                                    }
                                    if (i == v_ds1.Tables[0].Rows.Count - 1 || v_ds1.Tables[0].Columns[k].ColumnName == "LLLLTC")
                                    {
                                        astr = astr + "<td align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\">";
                                    }
                                    else
                                    {
                                        astr = astr + "<td align=right>";
                                    }
                                    astr = astr + at;
                                    astr = astr + "</td>";
                                }
                                else
                                {
                                    if (i == v_ds1.Tables[0].Rows.Count - 1 || v_ds1.Tables[0].Columns[k].ColumnName == "LLLLTC")
                                    {
                                        astr = astr + "<td align=left style=\"font-family: Arial; font-size: 10pt; font-weight: bold\">";
                                    }
                                    else
                                    {
                                        astr = astr + "<td align=left>";
                                    }
                                    string atmp = "";
                                    if ((v_ds1.Tables[0].Columns[k].ColumnName.ToUpper() == "MABN") && (i != v_ds1.Tables[0].Rows.Count - 1))
                                    {
                                        atmp = "&nbsp;";//(i+1).ToString()+" - ";
                                    }
                                    astr = astr + atmp + v_ds1.Tables[0].Rows[i][k].ToString();
                                    astr = astr + "</td>";
                                }
                                //break;
                            }
                        }
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }

                astr = "</table>";
                sw.Write(astr);

                astr = "<table boder=0>";
                astr = astr + "<tr>";
                astr = astr + "<th align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + f_GetNgay(txtNgayin.Text.Substring(0, 10));
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + "";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";                
                astr = astr + this.Tag.ToString().Trim() + "                 ";            
                astr = astr + "</th>";
                astr = astr + "</tr>";
                astr = astr + "</Table>";
                sw.Write(astr);
                sw.Close();
                //System.IO.File.Copy(v_filepath,v_filepath+".html",true);
                //MessageBox.Show(lan.Change_language_MessageText("OK");                
                System.Diagnostics.Process.Start(v_filepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Export_Excel(System.Data.DataSet v_ds, string v_filepath)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(v_filepath, false, System.Text.Encoding.UTF8);
                string astr = "";
                astr = "<Table border=1>";
                astr = astr + "<tr>";
                for (int i = 0; i < v_ds.Tables[0].Columns.Count; i++)
                {
                    astr = astr + "<th>";
                    astr = astr + v_ds.Tables[0].Columns[i].ColumnName;
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                sw.Write(astr);
                for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
                {
                    astr = "<tr>";
                    for (int j = 0; j < v_ds.Tables[0].Columns.Count; j++)
                    {
                        astr = astr + "<td>";
                        astr = astr + v_ds.Tables[0].Rows[i][j].ToString();
                        astr = astr + "</td>";
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }
                astr = "</Table>";
                sw.Write(astr);

                sw.Close();
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Export_HTML(DataSet v_ds1, DataSet v_ds2, string v_filepath)
        {
            try
            {
                v_filepath = v_filepath + ".html";
                int n = 0, n1 = 0;
                string t = "";
                if (rd3.Checked)
                {
                    t = " " +lan.Change_language_MessageText("THEO HOÁ ĐƠN");
                }
                else
                    if (rd4.Checked)
                    {
                        t = " " +   lan.Change_language_MessageText("THEO NGÀY");
                    }
                    else
                        if (rd5.Checked)
                        {
                            t = " " +lan.Change_language_MessageText("THEO KHOA PHÒNG");
                        }
                t = "";

                for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                {
                    n += v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL") == 0 ? 1 : 0;
                }

                System.IO.StreamWriter sw = new System.IO.StreamWriter(v_filepath, false, System.Text.Encoding.UTF8);
                string astr = "";
                astr = astr + "<html>";
                astr = astr + "<head>";
                astr = astr + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">";
                astr = astr +lan.Change_language_MessageText("<title>Báo cáo thu tạm ứng</title>");
                astr = astr + "</head>";

                astr = astr + "<body>";

                astr = "<Table border=0>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + m_v.Syte;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + m_v.Tenbv;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=40 align=center style=\"font-family: Arial; font-size: 14pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr +lan.Change_language_MessageText("BÁO CÁO THU VIỆN PHÍ TRỰC TIẾP") + " " + t;
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=center style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr +lan.Change_language_MessageText("(Từ ngày") + " " + txtTN.Text.Substring(0, 10) + " " +lan.Change_language_MessageText("Đến ngày") + " " + txtDN.Text.Substring(0, 10) + ")";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + "";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th align=left colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                sw.Write(astr);

                astr = "<Table border=1 style=\"font-family: Arial; font-size: 10pt; font-weight: normal; border-style: solid; border-width: 1\" cellspacing=1>";

                if ((n < v_ds2.Tables[0].Rows.Count) && (n > 0))
                {
                    astr = astr + "<tr>";
                    for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                    {
                        if (v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL") == 0)
                        {
                        }
                        else
                        {
                            astr = astr + "<th rowspan=2 style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
                            astr = astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
                            astr = astr + "</th>";
                        }
                    }
                    astr = astr + "<th colspan=" + n.ToString() + " style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
                    astr = astr +
lan.Change_language_MessageText("THÔNG TIN CHI TIẾT");
                    astr = astr + "</th>";

                    astr = astr + "</tr>";

                    astr = astr + "<tr>";
                    for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                    {
                        if (v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL") == 0)
                        {
                            astr = astr + "<th style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
                            astr = astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
                            astr = astr + "</th>";
                        }
                    }
                    astr = astr + "</tr>";
                }
                else
                {
                    astr = astr + "<tr>";
                    for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                    {
                        n1 = (v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL") == 0) ? 1 : 2;
                        astr = astr + "<th style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
                        astr = astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
                        astr = astr + "</th>";
                    }
                    astr = astr + "</tr>";
                }
                //Dong so thu tu
                astr = astr + "<tr>";
                for (int i = 0; i < v_ds2.Tables[0].Rows.Count; i++)
                {
                    astr = astr + "<th style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
                    astr = astr + (i + 1).ToString();
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                sw.Write(astr);

                string at = "";
                for (int i = 0; i < v_ds1.Tables[0].Rows.Count; i++)
                {
                    astr = "<tr>";
                    for (int j = 0; j < v_ds2.Tables[0].Rows.Count; j++)
                    {
                        for (int k = 0; k < v_ds1.Tables[0].Columns.Count; k++)
                        {
                            //MessageBox.Show(v_ds1.Tables[0].Columns[k].ColumnName.ToUpper()+"="+v_ds2.Tables[0].Rows[j]["MA"].ToString().ToUpper());
                            if (v_ds1.Tables[0].Columns[k].ColumnName.ToUpper() == v_ds2.Tables[0].Rows[j]["MA"].ToString().ToUpper())
                            {
                                if (v_ds1.Tables[0].Columns[k].DataType.ToString() == "System.Decimal")
                                {
                                    try
                                    {
                                        at = decimal.Parse(v_ds1.Tables[0].Rows[i][k].ToString()).ToString("###,###,##0.##");
                                    }
                                    catch
                                    {
                                        at = "";
                                    }
                                    if (at == "0")
                                    {
                                        at = "";
                                    }
                                    if (i == v_ds1.Tables[0].Rows.Count - 1 || v_ds1.Tables[0].Columns[k].ColumnName == "LLLLTC")
                                    {
                                        astr = astr + "<td align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
                                    }
                                    else
                                    {
                                        astr = astr + "<td align=right style=\"font-family: Arial; font-size: 10pt; border-style: solid; border-width: 1\">";
                                    }
                                    astr = astr + at;
                                    astr = astr + "&nbsp;</td>";
                                }
                                else
                                {
                                    if (i == v_ds1.Tables[0].Rows.Count - 1 || v_ds1.Tables[0].Columns[k].ColumnName == "LLLLTC")
                                    {
                                        astr = astr + "<td align=left style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
                                    }
                                    else
                                    {
                                        astr = astr + "<td align=left style=\"font-family: Arial; font-size: 10pt; border-style: solid; border-width: 1\">";
                                    }
                                    string atmp = "";
                                    if ((v_ds1.Tables[0].Columns[k].ColumnName.ToUpper() == "MABN") && (i != v_ds1.Tables[0].Rows.Count - 1))
                                    {
                                        atmp = "&nbsp;";//(i+1).ToString()+" - ";
                                    }
                                    astr = astr + atmp + v_ds1.Tables[0].Rows[i][k].ToString();
                                    astr = astr + "</td>";
                                }
                                //break;
                            }
                        }
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }

                astr = "</table>";
                sw.Write(astr);

                astr = "</th>";
                astr = astr + "</tr>";
                sw.Write(astr);

                astr = "<tr>";
                astr = astr + "<th align=left colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                sw.Write(astr);

                astr = "<table boder=0 width=\"100%\">";
                astr = astr + "<tr>";
                astr = astr + "<th align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + f_GetNgay(txtNgayin.Text.Substring(0, 10));
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + "";
                astr = astr + "</th>";
                astr = astr + "</tr>";

                astr = astr + "<tr>";
                astr = astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan=" + v_ds2.Tables[0].Rows.Count.ToString() + ">";
                astr = astr + this.Tag.ToString().Trim() + "                 ";
                astr = astr + "</th>";
                astr = astr + "</tr>";
                astr = astr + "</Table>";
                sw.Write(astr);

                astr = "</th>";
                astr = astr + "</tr>";
                astr = astr + "</Table>";
                sw.Write(astr);

                astr = astr + "</body>";
                astr = astr + "</html>";
                sw.Close();
                //System.IO.File.Copy(v_filepath,v_filepath+".html",true);
                //MessageBox.Show(lan.Change_language_MessageText("OK");                
                System.Diagnostics.Process.Start(v_filepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string f_GetNgay(string v_ngay)
        {
            try
            {
                return lan.Change_language_MessageText("Ngày") + " " + v_ngay.Substring(0, 2) + " " + lan.Change_language_MessageText("tháng") + " " + v_ngay.Substring(3, 2) + " " + lan.Change_language_MessageText("năm") + " " + v_ngay.Substring(6);
            }
            catch
            {
                return "";
            }
        }
        private void tmn_Ketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmn_Export_Click(object sender, EventArgs e)
        {
            f_Ketxuat("HTML");
        }

        private void txtTuso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            m_v.f_Set_CheckID(tree_Loai, chkAll.Checked);
        }

        #region thu vien phi truc tiep report
        
        private void tmn_In_Click(object sender, EventArgs e)
        {
            f_SQL();
            string reportname = "v_BKvienphitructiep_DT.rpt";
            if (rd4.Checked) reportname = reportname.Replace(".rpt", "") + "_ngay.rpt";
            else if (rd5.Checked)reportname = reportname.Replace(".rpt", "") + "_kp.rpt";
            //if (cbBaocao.SelectedIndex == 0)
            //{
            //    reportname = "v_BKvienphi_Tructiep.rpt";
            //}
            frmReport f = new frmReport(m_v,ads.Tables[0],reportname,"","","","","","","","","","",1,true);
            f.ShowDialog();
        }

        private void f_SQL()
        {
            try
            {
                string asql = "", asql1 = "", asqlht = "", asqlnt = "", asqlnt1 = "";
                string aloaibn = "", auserid = "", aquyenso = "", alydomien = "", abaocao = "", adoituong = "";
                string atmp = "", aexp = "", atmp1 = "", atmp2 = "", atmp_goi = "";
                aloaibn = m_v.f_Get_CheckID(tree_LoaiBN);
                auserid = m_v.f_Get_CheckID(tree_User);
                aquyenso = m_v.f_Get_CheckID(tree_Quyenso);
                alydomien = m_v.f_Get_CheckID(tree_Lydomien);
                abaocao = m_v.f_Get_CheckID(tree_Loai);
                adoituong = m_v.f_Get_CheckID(tree_Doituong);

                aexp = "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')";

                asqlht = "select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')";

                if (aloaibn != "")
                {
                    aexp = aexp + " and a.loaibn in(" + aloaibn + ")";
                }
                if (auserid != "")
                {
                    aexp = aexp + " and a.userid in(" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp = aexp + " and a.quyenso in(" + aquyenso + ")";
                }
                if (adoituong != "")
                {
                    aexp = aexp + " and b.madoituong in(" + adoituong + ")";
                }
                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    if (decimal.Parse(txtTuso.Text.Trim()) > decimal.Parse(txtDenso.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTuso.Focus();
                        return;
                    }
                    else
                    {
                        aexp += " and a.sobienlai >= " + txtTuso.Text.Trim() + " and a.sobienlai <= " + txtDenso.Text.Trim() + "";
                    }
                }
                //if (abaocao != "")
                //{
                //    switch (cbBaocao.SelectedValue.ToString())
                //    {
                //        case "nhomvp":
                //            aexp = aexp + " and f.id_nhom in(" + abaocao + ")";
                //            break;
                //        case "loaivp":
                //        case "goivp":
                //            aexp = aexp + " and f.id in(" + abaocao + ")";
                //            break;
                //    }
                //}
                if (chkLydomen.Checked)
                {
                    if (alydomien != "")
                    {
                        aexp = aexp + " and c.lydo in(" + alydomien + ")";
                    }
                    else
                    {
                        aexp = aexp + " and c.lydo is null";
                    }
                }

                m_ds2 = m_ds1.Clone();

                //Cac field se hien thi
                for (int i = 0; i < tree_Field.Nodes.Count; i++)
                {
                    if (tree_Field.Nodes[i].Checked)
                    {
                        try
                        {
                            m_ds2.Tables[0].Rows.Add(new string[] { tree_Field.Nodes[i].Tag.ToString(), tree_Field.Nodes[i].Text.Trim() });
                        }
                        catch
                        {
                        }
                    }
                }
                //
                bool ok = false;
                for (int i = 0; i < tree_Loai.Nodes.Count; i++)
                {
                    if (tree_Loai.Nodes[i].Checked)
                    {
                        ok = true;
                        break;
                    }
                }

                string atable = "";
                switch (cbBaocao.SelectedValue.ToString())
                {
                    case "nhomvp":
                        //atable = "to_char(h.ma)";
                        atable = "to_char(f.id_nhom)";
                        break;
                    case "loaivp":
                    case "goivp":
                        //atable = "to_char(g.id)";
                        atable = "to_char(f.id)";
                        break;
                    case "Khoa":
                        atable = "trim(to_char(nvl(to_char(i.makp),'')))";
                        break;
                }
                atmp = "";
                atmp1 = "";
                if (ok)
                {
                    for (int i = 0; i < tree_Loai.Nodes.Count; i++)
                    {
                        if (tree_Loai.Nodes[i].Checked)
                        {
                            try
                            {
                                atmp = atmp + ",round(sum(to_number(decode(" + atable + ",'" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + "',b.soluong*b.dongia-b.tra-b.mien,0))),0) LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                atmp_goi = atmp_goi + ",round(sum(to_number(decode(" + atable + ",'" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + "',b.soluong*f.sotien,0))),0) LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                atmp1 = atmp1 + ",round(sum(to_number(decode(" + atable + ",'" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + "',b.soluong*b.dongia-b.tra-case when b.madoituong=1 then case when instr(nvl(bb.sothe,' '),'UC')>0 or instr(nvl(bb.sothe,' '),'VC')>0 or instr(nvl(bb.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end,0))),0) LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                atmp2 = atmp2 + ",round(nvl(sum(LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim() + "),0),0) as LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim();
                                m_ds2.Tables[0].Rows.Add(new string[] { "LLLL" + m_ds.Tables[0].Rows[i]["MA"].ToString().Trim(), tree_Loai.Nodes[i].Text.Trim() });
                            }
                            catch (Exception exx)
                            {
                                MessageBox.Show(exx.ToString());
                            }
                        }
                    }
                    atmp = atmp.Trim().Trim(',');
                    atmp_goi = atmp_goi.Trim().Trim(',');
                    atmp1 = atmp1.Trim().Trim(',');
                    atmp = atmp.Trim();
                    atmp_goi = atmp_goi.Trim();
                    atmp1 = atmp1.Trim();
                    if (atmp.Length > 0 || atmp_goi.Length > 0)
                    {
                        atmp = "," + atmp.Trim(',');
                        atmp_goi = "," + atmp_goi.Trim(',');
                        m_ds2.Tables[0].Rows.Add(new string[] { lan.Change_language_MessageText("LLLLTC"), lan.Change_language_MessageText("Tổng cộng") });
                    }
                    if (atmp1.Length > 0)
                    {
                        atmp1 = "," + atmp1.Trim(',');
                    }
                }
                
                string sql_goi = "";
                string asqldmbd = " select a.id as idvp, a.id_loai as id, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom, 0 as sotien from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                asqldmbd += " union all ";
                asqldmbd += " select a.id as idvp, 0 as id, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom, 0 as sotien from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma";
                sql_goi = " select a.id as idvp, a.id_loai as id, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom, a.sotien from medibv.v_trongoi a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma where a.id_gia=0 and a.sotien<>0";
                //
                //
                if (rd3.Checked || rd4.Checked)//theo bien lai
                {                    
                    if (cbBaocao.SelectedValue.ToString() == "goivp")
                    {
                        asql = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a.mabn, a.hoten,a.diachi, a.namsinh, sum(nvl(f.sotien,0)*b.soluong-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end) as sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(to_number(nvl(f.sotien,0)*b.soluong-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end-nvl(to_number(decode(b.madoituong,1,b.mien,0)),0)-nvl(b.thieu,0)))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp_goi;
                        asql+=" from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + sql_goi + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp;
                        asql+= " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten, a.diachi, a.namsinh, c.sotien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' ";
                        asql+=" order by d.sohieu asc, a.sobienlai asc, a.ngay asc";// left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 from dual) h on g.id_nhom=h.ma 
                    }
                    else
                    {
                        asql = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a.mabn, a.hoten,a.diachi, a.namsinh, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end) as sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(to_number(nvl(b.soluong,0)*nvl(b.dongia,0)-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end-nvl(to_number(decode(b.madoituong,1,b.mien,0)),0)-nvl(b.thieu,0)))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp;
                        asql += " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where '1'='1' " + aexp;
                        asql += " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten,a.diachi, a.namsinh, c.sotien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')'";
                        asql += " order by d.sohieu asc, a.sobienlai asc, a.ngay asc";// left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 from dual) h on g.id_nhom=h.ma 
                    }

                    asqlnt = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a1.mabn, a1.hoten, a1.thon ||' ' ||px.tenpxa||' '||q.tenquan ||' '||t.tentt as diachi, a1.namsinh, round(nvl(a.sotien,0),0) sotien, round(nvl(a.bhyt,0),0) bhyt, round(nvl(a.mien,0)) mien, 0 thieu, round(sum(b.soluong*b.dongia-b.tra) - sum(case when b.madoituong=1 then case when instr(nvl(bb.sothe,' '),'UC')>0 or instr(nvl(bb.sothe,' '),'VC')>0 or instr(nvl(bb.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end),0) as thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp1;
                    asqlnt += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 on a.id=a0.id inner join medibv.btdbn a1  on a0.mabn=a1.mabn left join medibv.btdpxa px on a1.maphuongxa=px.maphuongxa left join medibv.btdquan q on a1.maqu=q.maqu and px.maqu=q.maqu left join medibv.btdtt t on a1.matt=t.matt and a1.matt=t.matt left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_ttrvbhyt bb on a.id=bb.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp;
                    asqlnt+=" group by a.id, a.quyenso, a.sobienlai, d.sohieu, a1.mabn, a1.hoten, a1.thon, px.tenpxa, q.tenquan, t.tentt, a1.namsinh, a.sotien,a.bhyt,a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')'";
                    asqlnt += " order by d.sohieu asc, a.sobienlai asc, a.ngay asc";//left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 from dual) h on g.id_nhom=h.ma
                }
               
                else//theo khoa phong
                {
                    if (cbBaocao.SelectedValue.ToString() == "goivp")
                    {
                        asql = "select b.makp, i.tenkp, to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a.mabn, a.hoten,a.diachi, a.namsinh, sum(nvl(f.sotien,0)*b.soluong-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end) as sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(to_number(nvl(f.sotien,0)*b.soluong-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end-nvl(to_number(decode(b.madoituong,1,b.mien,0)),0)-nvl(b.thieu,0)))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp_goi;
                        asql += " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + sql_goi + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp;
                        asql += " group by b.makp, i.tenkp, a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten, a.diachi, a.namsinh, c.sotien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' ";
                        asql += " order by d.sohieu asc, a.sobienlai asc, a.ngay asc";// left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 from dual) h on g.id_nhom=h.ma 
                    }
                    else
                    {
                        asql = "select b.makp, i.tenkp, to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a.mabn, a.hoten,a.diachi, a.namsinh, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end) as sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(to_number(nvl(b.soluong,0)*nvl(b.dongia,0)-case when b.thieu is null then 0 else b.thieu end - case when b.tra is null then 0 else b.tra end-nvl(to_number(decode(b.madoituong,1,b.mien,0)),0)-nvl(b.thieu,0)))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp;
                        asql += " from medibvmmyy.v_vienphill a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where '1'='1' " + aexp;
                        asql += " group by b.makp, i.tenkp, a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten,a.diachi, a.namsinh, c.sotien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')'";
                        asql += " order by d.sohieu asc, a.sobienlai asc, a.ngay asc";// left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 from dual) h on g.id_nhom=h.ma 
                    }

                    asqlnt = "select b.makp, i.tenkp, to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a1.mabn, a1.hoten, a1.thon ||' ' ||px.tenpxa||' '||q.tenquan ||' '||t.tentt as diachi, a1.namsinh, round(nvl(a.sotien,0),0) sotien, round(nvl(a.bhyt,0),0) bhyt, round(nvl(a.mien,0)) mien, 0 thieu, round(sum(b.soluong*b.dongia-b.tra) - sum(case when b.madoituong=1 then case when instr(nvl(bb.sothe,' '),'UC')>0 or instr(nvl(bb.sothe,' '),'VC')>0 or instr(nvl(bb.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end),0) as thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp1;
                    asqlnt += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 on a.id=a0.id inner join medibv.btdbn a1  on a0.mabn=a1.mabn left join medibv.btdpxa px on a1.maphuongxa=px.maphuongxa left join medibv.btdquan q on a1.maqu=q.maqu and px.maqu=q.maqu left join medibv.btdtt t on a1.matt=t.matt and a1.matt=t.matt left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_ttrvbhyt bb on a.id=bb.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp;
                    asqlnt += " group by b.makp, i.tenkp, a.id, a.quyenso, a.sobienlai, d.sohieu, a1.mabn, a1.hoten, a1.thon, px.tenpxa, q.tenquan, t.tentt, a1.namsinh, a.sotien,a.bhyt,a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')'";
                    asqlnt += " order by d.sohieu asc, a.sobienlai asc, a.ngay asc";//left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 from dual) h on g.id_nhom=h.ma
                }
                if (m_ds2.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn thông tin báo cáo cần hiển thị"), m_v.s_AppName, MessageBoxButtons.OK);
                    return;
                }
                if ((chkPhongkham.Checked && chkNoitru.Checked) || (!chkPhongkham.Checked && !chkNoitru.Checked))
                {
                    asql = asql.Replace("order by d.sohieu asc, a.sobienlai asc, a.ngay asc", "");
                    asqlnt = asqlnt.Replace("order by d.sohieu asc, a.sobienlai asc, a.ngay asc", "");
                    asql += " union all ";
                    asql += asqlnt;
                    asql = "select * from ((" + asql + ")) froo order by to_number(quyensoid) asc, to_number(sobienlai) asc, to_date(ngay,'dd/mm/yyyy') asc";
                }
                else
                    if (chkPhongkham.Checked)
                    {
                    }
                    else
                    {
                        if (chkNoitru.Checked)
                        {
                            asql = asqlnt;
                            asql1 = asqlnt1;
                        }
                    }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                
                if ((ads == null) || (ads.Tables[0].Rows.Count <= 0))
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không có số liệu báo cáo"), m_v.s_AppName, MessageBoxButtons.OK);
                    return;
                }

                if (!System.IO.Directory.Exists("..//..//Datareport")) System.IO.Directory.CreateDirectory("..//..//Datareport");
                ads.WriteXml("..//..//Datareport//v_BKthutructiep.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private string f_Load_Bhyt_Sotien()
        {
            try
            {
                return (m_v.get_data("select ten from medibv.d_thongso where id=51 and nhom=1 ").Tables[0].Rows[0][0].ToString());
            }
            catch { return "-1"; };
        }

        //private int f_get_Tylebhytchitra()
        //{
        //    //int tyletmp = 100;
        //    //decimal v_sotien = 0;
        //    //string asqlnt="";
        //    //try
        //    //{
        //    //    DataSet ads = new DataSet();
        //    //    asqlnt = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, a1.mabn, a1.hoten, a1.thon ||' ' ||px.tenpxa||' '||q.tenquan ||' '||t.tentt as diachi, a1.namsinh, round(nvl(a.sotien,0),0) sotien, round(nvl(a.bhyt,0),0) bhyt, round(nvl(a.mien,0)) mien, 0 thieu, round(sum(b.soluong*b.dongia-b.tra) - sum(case when b.madoituong=1 then case when instr(nvl(bb.sothe,' '),'UC')>0 or instr(nvl(bb.sothe,' '),'VC')>0 or instr(nvl(bb.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*" + atyle + " else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end),0) as thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp1 + " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a0 on a.id=a0.id inner join medibv.btdbn a1  on a0.mabn=a1.mabn left join medibv.btdpxa px on a1.maphuongxa=px.maphuongxa left join medibv.btdquan q on a1.maqu=q.maqu and px.maqu=q.maqu left join medibv.btdtt t on a1.matt=t.matt and a1.matt=t.matt left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_ttrvbhyt bb on a.id=bb.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id inner join (" + asqldmbd + ") f on b.mavp=f.idvp left join medibv.btdkp_bv i on b.makp=i.makp where aa.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a1.mabn, a1.hoten, a1.thon, px.tenpxa, q.tenquan, t.tentt, a1.namsinh, a.sotien,a.bhyt,a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
        //    //    ads = m_v.get_data_mmyy(asqlnt);
        //    //    foreach (DataRow r in ads.Tables[0].Rows)
        //    //    {
        //    //        v_sotien = decimal.Parse(r["sotien"].ToString());
        //    //        if ((v_sotien >= d_bhyt_sotien))
        //    //            tyletmp = 80;
        //    //        else tyletmp = 100;
        //    //    }
        //    //}
        //    //catch//(Exception ex)
        //    //{
        //    //    //MessageBox.Show(ex.ToString());
        //    //    return 100;
        //    //}
        //    //return tyletmp;
        //}    
    }
}