using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmNewuser : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid = "", m_id = "", m_id_nhom = "", m_right_ = "", m_loaivp = "";
        private int i_chinhanh;
        private DataSet dsChinhanh = new DataSet();
        private bool bQuanly_chinhanh = false;
        public frmNewuser(LibVP.AccessData v_v,string v_id_nhom, string v_id, string v_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = v_v;
            m_userid = v_userid;
            m_id_nhom = v_id_nhom;
            m_id = v_id;
            m_v.f_SetEvent(this);
        }

        private void frmNewuser_Load(object sender, EventArgs e)
        {
            bQuanly_chinhanh = m_v.bQuanly_Theo_Chinhanh;
            ttStatus.Text = "";
            f_Load_CB_Nhom();
            f_Load_CB_khudt();
            f_Load_Sua();
            f_Enable(false);
            txtUsername.Focus();
            if(bQuanly_chinhanh) f_Loadchinhanh();
        }
        private void f_Loadchinhanh()
        {
            string s_ip_local = m_v.Maincode("Ip");
            dsChinhanh = m_v.get_data(" select * from " + m_v.user + ".dmchinhanh where ip='" + s_ip_local + "' order by ten");
            if (dsChinhanh.Tables[0].Select("trungtam=1").Length > 0)
            {
                dsChinhanh = m_v.get_data(" select * from " + m_v.user + ".dmchinhanh order by ten");
            }
            cbChinhanh.DisplayMember = "ten";
            cbChinhanh.ValueMember = "id";
            cbChinhanh.DataSource = dsChinhanh.Tables[0];
        }
        private void f_Load_CB_Nhom()
        {
            try
            {
                DataSet ads = m_v.f_get_v_nhomdlogin("", "", "", "", "");
                if (ads.Tables[0].Select("id=-1").Length <= 0)
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["id"] = -1;
                    r["ten"] = "...";
                    ads.Tables[0].Rows.InsertAt(r, ads.Tables[0].Rows.Count);
                }
                cbNhom.DisplayMember = "TEN";
                cbNhom.ValueMember = "ID";
                cbNhom.DataSource = ads.Tables[0];
                cbNhom.SelectedValue = m_id_nhom;
            }
            catch
            {
            }
        }

        private void f_Load_CB_khudt()
        {
            try
            {
                string sql = " select id, ten from " + m_v.user + ".dmkhudt ";
                DataSet ads = m_v.get_data(sql);
                khudt.DataSource = ads.Tables[0];
                khudt.DisplayMember = "TEN";
                khudt.ValueMember = "ID";
                
            }
            catch
            {
            }
        }

        private void f_Load_Sua()
        {
            try
            {
                if (m_id != "")
                {
                    string atmp = m_id;
                    m_id = "";
                    foreach (DataRow r in m_v.f_get_v_dlogin(atmp, "", "", "", "").Tables[0].Rows)
                    {
                        m_id = r["id"].ToString();
                        m_id_nhom = r["id_nhom"].ToString();
                        m_right_ = r["right_"].ToString();
                        m_loaivp = r["loaivp"].ToString();
                        txtUsername.Text = r["userid"].ToString();
                        txtPassword.Text = r["password_"].ToString();
                        txtPassword1.Text = r["password_"].ToString();
                        txtHoten.Text = r["hoten"].ToString();
                        i_chinhanh=int.Parse(r["chinhanh"].ToString());
                        try
                        {
                            cbNhom.SelectedValue = m_id_nhom;
                        }
                        catch
                        {
                        }
                        try
                        {
                            cbChinhanh.SelectedValue = i_chinhanh.ToString();
                        }
                        catch
                        {
                        }
                        txtUsername.Focus();
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Enable(bool v_bool)
        {
            butMoi.Enabled = true;
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool && m_id!="";
            butXoa.Enabled = !v_bool && m_id != "";
            butBoqua.Enabled = true;
            butClose.Enabled = true;

            txtUsername.Enabled = v_bool;
            txtPassword.Enabled = v_bool;
            txtPassword1.Enabled = v_bool;
            txtHoten.Enabled = v_bool;
            cbNhom.Enabled = v_bool;
            cbChinhanh.Enabled = (bQuanly_chinhanh) ? v_bool : false;
        }
        private void f_Add_Nhom()
        {
            try
            {
                frmNewgroup af = new frmNewgroup(m_v, "", m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
                f_Load_CB_Nhom();
            }
            catch
            {
            }
        }
        private void f_Moi()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtPassword1.Text = "";
            txtHoten.Text = "";
            m_id = "";
            f_Enable(true);
            txtUsername.Focus();
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập tên đăng nhập!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();
                    return;
                }
                if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập mật khẩu truy cập!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                    return;
                }
                if (txtPassword1.Text.Trim() != txtPassword.Text.Trim())
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Xác nhận lại mật khẩu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword1.Focus();
                    return;
                }
                if (txtHoten.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập họ và tên người sử dụng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHoten.Focus();
                    return;
                }
                if (cbNhom.SelectedIndex<0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Chọn nhóm người sử dụng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbNhom.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (m_id == "")
                {
                    m_id = m_v.get_id_v_dlogin.ToString();
                }
                if (cbChinhanh.SelectedIndex == -1)
                {
                    i_chinhanh = 0;
                }
                else
                {
                    i_chinhanh = int.Parse(cbChinhanh.SelectedValue.ToString());
                }
                if (i_chinhanh>0)
                {
                    m_id = i_chinhanh.ToString() + m_id.PadLeft(4, '0');//binh 29032012
                }
                try
                {
                    m_id_nhom = cbNhom.SelectedValue.ToString();
                }
                catch
                {
                }

                if (m_v.f_get_v_dlogin("","","",txtUsername.Text.Trim(), "").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Tên đăng nhập đã được người khác đăng ký, chọn tên đăng nhập khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();
                    return;
                }
                int tmp_chinhanh = (bQuanly_chinhanh) ? ((cbChinhanh.SelectedIndex < 0) ? 0 : int.Parse(cbChinhanh.SelectedValue.ToString())) : 0;
                m_v.upd_v_dlogin(decimal.Parse(m_id), decimal.Parse(m_id_nhom), txtHoten.Text, txtUsername.Text, txtPassword.Text, m_right_, m_loaivp, tmp_chinhanh);
                if (m_id_nhom == "1" || m_id_nhom == "2")
                {
                    m_v.execute_data("update medibv.v_dlogin set admin=1 where id=" + decimal.Parse(m_id));
                }
                else m_v.execute_data("update medibv.v_dlogin set admin=0 where id=" + decimal.Parse(m_id));
                f_Enable(false);
                butMoi.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            f_Enable(true);
            txtUsername.Focus();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá người sử dụng!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes && m_id != "")
                {
                    m_v.del_v_dlogin(m_id);
                    f_Moi();
                }
            }
            catch
            {
            }
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_Load_Sua();
            f_Enable(false);
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }
        private void cbNhom_KeyDown(object sender, KeyEventArgs e)
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

        private void cbNhom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbNhom.SelectedIndex == cbNhom.Items.Count - 1)
                {
                    f_Add_Nhom();
                }
            }
            catch
            {
            }
        }

        private void txtPassword1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != "" && txtPassword.Text!=txtPassword.Text)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Mật xác nhận không đúng, xác nhận lại mật khẩu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtPassword1.Focus();
                }
            }
            catch
            {
            }
        }
    }
}