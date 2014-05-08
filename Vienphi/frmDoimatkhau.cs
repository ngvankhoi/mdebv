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
    public partial class frmDoimatkhau : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_id = "",m_right_="",m_loaivp="";
        public frmDoimatkhau(LibVP.AccessData v_v,string v_userid)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = v_v;
            m_userid = v_userid;
            m_id = v_userid;
            m_v.f_SetEvent(this);
        }

        private void frmDoimatkhau_Load(object sender, EventArgs e)
        {
            f_Load_CB_Nhom();
            f_Load_Sua();
            f_Enable(true);
            txtPassword_old.Focus();
        }
        private void f_Load_CB_Nhom()
        {
            try
            {
                DataSet ads = m_v.f_get_v_nhomdlogin("", "", "", "", "");
                cbNhom.DisplayMember = "TEN";
                cbNhom.ValueMember = "ID";
                cbNhom.DataSource = ads.Tables[0];
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
                        m_right_ = r["right_"].ToString();
                        m_loaivp = r["loaivp"].ToString();
                        txtUsername.Text =  r["userid"].ToString();
                        txtPassword.Text = "";// r["password_"].ToString();
                        txtPassword1.Text = "";// r["password_"].ToString();
                        txtHoten.Text = r["hoten"].ToString();
                        try
                        {
                            cbNhom.SelectedValue = r["id_nhom"].ToString();
                        }
                        catch
                        {
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Enable(bool v_bool)
        {
            butLuu.Enabled = v_bool;
            butBoqua.Enabled = true;

            txtUsername.Enabled = false;
            txtPassword_old.Enabled = true;
            txtPassword.Enabled = true;
            txtPassword1.Enabled = true;
            txtHoten.Enabled = false;
            cbNhom.Enabled = false;
            butLuu.Enabled = false;
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string aid_nhom="";
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
                try
                {
                    aid_nhom = cbNhom.SelectedValue.ToString();
                }
                catch
                {
                    aid_nhom = "";
                }

                if (m_v.f_get_v_dlogin("","","",txtUsername.Text.Trim(), "").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Tên đăng nhập đã được người khác đăng ký, chọn tên đăng nhập khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();
                    return;
                }
                m_v.upd_v_dlogin(decimal.Parse(m_id),decimal.Parse(aid_nhom), txtHoten.Text,txtUsername.Text, txtPassword.Text,m_right_,m_loaivp);
                f_Enable(false);
                if (m_v.f_get_v_dlogin(m_id, "", "", txtUsername.Text, txtPassword.Text).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Mật khẩu đã được thay đổi!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Không cập nhật được dữ liệu, mật khẩu chưa được thay đổi!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
        private void txtPassword1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != "" && txtPassword.Text!=txtPassword.Text)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Mật xác nhận không đúng, xác nhận lại mật khẩu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtPassword1.Focus();
                }
            }
            catch
            {
            }
        }

        private void txtPassword_old_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPassword_old_Validated(null, null);
                    if (!butLuu.Enabled)
                    {
                        MessageBox.Show(this, 
lan.Change_language_MessageText("Mật khẩu củ nhập vào không đúng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword_old.Focus();
                        return;
                    }
                    else
                    {
                        txtPassword.Focus();
                    }
                }
            }
            catch
            {
            }
        }
        private void txtPassword_old_Validated(object sender, EventArgs e)
        {
            try
            {
                butLuu.Enabled = m_v.f_get_v_dlogin("", "", "",txtUsername.Text, txtPassword_old.Text).Tables[0].Rows.Count >= 1;
            }
            catch
            {
                butLuu.Enabled = false;
            }
        }
    }
}