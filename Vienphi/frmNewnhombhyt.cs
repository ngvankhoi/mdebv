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
    public partial class frmNewnhombhyt : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_id = "",m_userid="";
        public frmNewnhombhyt(LibVP.AccessData v_v, string v_id, string v_userid)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = v_v;
            m_userid = v_userid;
            m_id = v_id;
            m_v.f_SetEvent(this);
        }
        private void frmNewnhombhyt_Load(object sender, EventArgs e)
        {
            ttStatus.Text = "";
            f_Load_Sua();
            f_Enable(true);
            txtStt.Focus();
            if (txtStt.Text == "")
            {
                f_Moi();
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
                    foreach (DataRow r in m_v.f_get_v_nhombhyt(atmp,"","","","").Tables[0].Rows)
                    {
                        m_id = r["id"].ToString();
                        txtID.Text = r["id"].ToString();
                        txtStt.Text = r["stt"].ToString();
                        txtTen.Text = r["ten"].ToString();
                        txtViettat.Text = r["viettat"].ToString();
                        chkReadonly.Checked = r["readonly"].ToString()=="1";
                        txtStt.Focus();
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
            butMoi.Enabled = true;
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool && m_id!="";
            butXoa.Enabled = !v_bool && m_id != "";
            butBoqua.Enabled = true;
            butClose.Enabled = true;

            txtStt.Enabled = v_bool;
            txtID.Enabled = false;
            txtTen.Enabled = v_bool;
            txtViettat.Enabled = v_bool;
            chkReadonly.Enabled = v_bool;
        }
        private void f_Moi()
        {
            txtStt.Text = m_v.get_stt_v_nhombhyt.ToString();
            txtID.Text = "";
            txtTen.Text = "";
            txtViettat.Text = "";
            m_id = "";
            chkReadonly.Checked = false;
            f_Enable(true);
            txtStt.Focus();
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        public void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Trim() == "")
                {
                }
                if (txtStt.Text.Trim() == "")
                {
                    txtStt.Text = m_v.get_stt_v_nhombhyt.ToString();
                }
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập tên nhóm viện phí BHYT!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                if (m_id == "")
                {
                    m_id = m_v.get_id_v_nhombhyt.ToString();
                }
                else
                {
                    try
                    {
                        if (m_v.dadung_v_nhombhyt(m_id) == -1)
                        {
                            if (!m_v.is_dba_admin(m_userid))
                            {
                                MessageBox.Show(this, 
lan.Change_language_MessageText("Thông tin này chỉ xem, không cho phép cập nhật!")+"\n"+
lan.Change_language_MessageText("Liên hệ vơi quản trị hệ thống để được trợ giúp."), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                if (m_v.f_get_v_nhombhyt("","",txtTen.Text.Trim(),"","").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Tên nhóm đã tồn tại, chọn tên khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                m_v.upd_v_nhombhyt(decimal.Parse(m_id), decimal.Parse(txtStt.Text.Trim()), txtTen.Text, txtViettat.Text,chkReadonly.Checked?1:0);
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
            txtStt.Focus();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.dadung_v_nhombhyt(m_id) != 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá sổ xét nghiệm này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá sổ xét nghiệm?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_nhombhyt(m_id))
                        {
                            MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá sổ xét nghiệm này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            f_Moi();
                        }
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
        private void txtSt_KeyDown(object sender, KeyEventArgs e)
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
        private void txtViettat_KeyDown(object sender, KeyEventArgs e)
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
        private void chkReadonly_KeyDown(object sender, KeyEventArgs e)
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
    }
}