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
    public partial class frmNewgroup : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private LibVP.AccessData m_v;
        private string m_userid="",m_id = "",m_nhom="",m_id_bv_so="",m_right_="";
        public frmNewgroup(LibVP.AccessData v_v, string v_id_nhom, string v_userid)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            v_userid = m_userid;
            m_v = v_v;
            m_id = v_id_nhom;
            m_v.f_SetEvent(this);
        }
        private void frmNewgroup_Load(object sender, EventArgs e)
        {
            ttStatus.Text = "";
            f_Load_Sua();
            f_Enable(true);
            txtMa.Focus();
        }
        private void f_Load_Sua()
        {
            try
            {
                if (m_id != "")
                {
                    string atmp = m_id;
                    m_id = "";
                    foreach (DataRow r in m_v.f_get_v_nhomdlogin(atmp, "", "", "", "").Tables[0].Rows)
                    {
                        m_id = r["id"].ToString();
                        m_nhom = r["nhom"].ToString();
                        m_id_bv_so = r["id_bv_so"].ToString();
                        m_right_ = r["right_"].ToString();
                        txtMa.Text = r["ma"].ToString();
                        txtTen.Text = r["ten"].ToString();
                        txtDiengiai.Text = r["diengiai"].ToString();
                        txtMa.Focus();
                        rdDatabase.Checked = m_nhom == rdDatabase.Tag.ToString();
                        rdApplication.Checked = m_nhom == rdApplication.Tag.ToString();
                        rdAdmin.Checked = m_nhom == rdAdmin.Tag.ToString();
                        rdUser.Checked = m_nhom == rdUser.Tag.ToString();
                        break;
                    }
                    if (m_nhom == "")
                    {
                        rdUser.Checked = true;
                    }
                }
            }
            catch
            {
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

            txtMa.Enabled = v_bool;
            txtTen.Enabled = v_bool;
            txtDiengiai.Enabled = v_bool;
            rdDatabase.Enabled = v_bool;
            rdApplication.Enabled = v_bool;
            rdAdmin.Enabled = v_bool;
            rdUser.Enabled = v_bool;
        }
        private void f_Moi()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiengiai.Text = "";
            m_id = "";
            f_Enable(true);
            txtMa.Focus();
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập mã nhóm!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập tên nhóm!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                if (m_id == "")
                {
                    m_id = m_v.get_id_v_nhomdlogin.ToString();
                }
                if (rdDatabase.Checked)
                {
                    m_nhom = rdDatabase.Tag.ToString();
                }
                if (rdApplication.Checked)
                {
                    m_nhom = rdApplication.Tag.ToString();
                }
                if (rdAdmin.Checked)
                {
                    m_nhom = rdAdmin.Tag.ToString();
                }
                if (rdUser.Checked)
                {
                    m_nhom = rdUser.Tag.ToString();
                }
                if (m_v.f_get_v_nhomdlogin("", "", txtMa.Text.Trim(), "", "").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Mã nhóm đã có, chọn mã khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                m_v.upd_v_nhomdlogin(decimal.Parse(m_id), decimal.Parse(m_nhom), txtMa.Text, txtTen.Text, txtDiengiai.Text, m_id_bv_so, m_right_);
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
            txtMa.Focus();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá nhóm người sử dụng!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes && m_id != "")
                {
                    m_v.del_v_nhomdlogin(m_id);
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
        private void txtMa_KeyDown(object sender, KeyEventArgs e)
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
        private void txtDiengiai_KeyDown(object sender, KeyEventArgs e)
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
        private void rdDatabase_KeyDown(object sender, KeyEventArgs e)
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
        private void rdApplication_KeyDown(object sender, KeyEventArgs e)
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
        private void rdAdmin_KeyDown(object sender, KeyEventArgs e)
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
        private void rdUser_KeyDown(object sender, KeyEventArgs e)
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
        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý tạo nhóm người dùng mặc định!")+"\n", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    m_v.f_macdinh_v_nhomdlogin();
                    this.Close();
                }
            }
            catch
            {
            }
        }
    }
}