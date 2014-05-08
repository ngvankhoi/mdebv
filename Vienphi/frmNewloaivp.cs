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
    public partial class frmNewloaivp : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_id = "",m_id_nhomvp="";
        public frmNewloaivp(LibVP.AccessData v_v, string v_id, string v_id_nhomvp,string v_userid)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m_v = v_v;
            m_id = v_id;
            m_userid = v_userid;
            m_id_nhomvp = v_id_nhomvp;
            m_v.f_SetEvent(this);
        }

        private void frmNewloaivp_Load(object sender, EventArgs e)
        {
            ttStatus.Text = "";
            f_Load_CB_Nhombhyt();
            f_Load_CB_Nhomvp();
            f_Load_Sua();
            f_Enable(true);
            txtStt.Focus();
            if (txtStt.Text == "")
            {
                f_Moi();
            }
        }
        private void f_Load_CB_Nhombhyt()
        {
            try
            {
                m_id_nhomvp=f_get_id_nhombhyt(m_id_nhomvp);
                DataSet ads = m_v.f_get_v_nhombhyt("", "", "", "", "");
                if (ads.Tables[0].Select("id=-1").Length <= 0)
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["id"] = -1;
                    r["ten"] = "...";
                    ads.Tables[0].Rows.InsertAt(r, ads.Tables[0].Rows.Count);
                }
                cbNhombhyt.DisplayMember = "TEN";
                cbNhombhyt.ValueMember = "ID";
                cbNhombhyt.DataSource = ads.Tables[0];
                cbNhombhyt.SelectedValue = m_id_nhomvp;
            }
            catch
            {
            }
        }
        private void f_Load_CB_Nhomvp()
        {
            try
            {
                DataSet ads = m_v.f_get_v_nhomvp("", "", "", "", "", "","");
                if (ads.Tables[0].Select("ma=-1").Length <= 0)
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["ma"] = -1;
                    r["ten"] = "...";
                    ads.Tables[0].Rows.InsertAt(r, ads.Tables[0].Rows.Count);
                }
                cbNhomvp.DisplayMember = "TEN";
                cbNhomvp.ValueMember = "MA";
                cbNhomvp.DataSource = ads.Tables[0];
                cbNhomvp.SelectedValue = m_id_nhomvp;
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
                    foreach (DataRow r in m_v.f_get_v_loaivp(atmp,"","","","","","").Tables[0].Rows)
                    {
                        m_id = r["id"].ToString();
                        m_id_nhomvp = r["id_nhom"].ToString();
                        txtStt.Text = r["stt"].ToString();
                        txtMa.Text = r["ma"].ToString();
                        txtTen.Text = r["ten"].ToString();
                        txtViettat.Text = r["viettat"].ToString();
                        chkReadonly.Checked = r["readonly"].ToString() == "1";
                        txtStt.Focus();
                        break;
                    }
                }
                try
                {
                    cbNhombhyt.SelectedValue = f_get_id_nhombhyt(m_id_nhomvp);
                }
                catch
                {
                }
                try
                {
                    cbNhomvp.SelectedValue = m_id_nhomvp;
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private string f_get_id_nhombhyt(string v_id_nhom)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNhomvp.DataSource]);
                DataView dv = (DataView)(cm.List);
                return dv.Table.Select("ma=" + cbNhomvp.SelectedValue.ToString())[0]["idnhombhyt"].ToString();
            }
            catch
            {
                return "";
            }
        }
        private void f_Add_Nhombhyt()
        {
            try
            {
                frmNewnhombhyt af = new frmNewnhombhyt(m_v, "", m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog();
                f_Load_CB_Nhombhyt();
            }
            catch
            {
            }
        }
        private void f_Add_Nhomvp()
        {
            try
            {
                string aid_nhombhyt = "";
                try
                {
                    aid_nhombhyt = cbNhombhyt.SelectedValue.ToString();
                }
                catch
                {
                }
                frmNewnhomvp af = new frmNewnhomvp(m_v, "", aid_nhombhyt,m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog();
                f_Load_CB_Nhomvp();
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
            txtMa.Enabled = v_bool;
            txtTen.Enabled = v_bool;
            txtViettat.Enabled = v_bool;
            cbNhombhyt.Enabled = false;// v_bool;
            cbNhomvp.Enabled = v_bool;
            chkReadonly.Enabled = v_bool;
        }
        private void f_Moi()
        {
            txtStt.Text = m_v.get_stt_v_loaivp.ToString();
            txtMa.Text = "";
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
                string aid_nhom = "",acomputer="";
                if (txtMa.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập mã số!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập tên loại!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                try
                {
                    aid_nhom = cbNhomvp.SelectedValue.ToString();
                }
                catch
                {
                    aid_nhom = "";
                }
                if (aid_nhom.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Chọn nhóm viện phí tương ứng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbNhomvp.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                if (txtStt.Text.Trim() == "")
                {
                    txtStt.Text = m_v.f_get_stt_v_loaivp(aid_nhom).ToString();
                }

                if (m_id == "")
                {
                    m_id = m_v.get_id_v_loaivp.ToString();
                }
                else
                {
                    try
                    {
                        if (m_v.dadung_v_loaivp(m_id) == -1)
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
                if (m_v.f_get_v_loaivp("", "", "", txtMa.Text.Trim(),"","","").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Mã đã tồn tại, chọn mã số khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (m_v.f_get_v_loaivp("", "", "", "", txtTen.Text.Trim(),"", "").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Tên đã tồn tại, chọn tên khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                m_v.upd_v_loaivp(decimal.Parse(m_id), decimal.Parse(aid_nhom), decimal.Parse(txtStt.Text.Trim()), txtMa.Text,txtTen.Text,txtViettat.Text.Trim(),decimal.Parse(m_userid),acomputer, chkReadonly.Checked ? 1 : 0,acomputer);
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
                if (m_v.dadung_v_loaivp(m_id) != 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá loại xét nghiệm này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá loại xét nghiệm?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_loaivp(m_id))
                        {
                            MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá loại xét nghiệm này!")+"\n"+
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
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }
        private void cbNhombhyt_KeyDown(object sender, KeyEventArgs e)
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
        private void txtTieuban_KeyDown(object sender, KeyEventArgs e)
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
        private void cbNhombhyt_Validated(object sender, EventArgs e)
        {
            f_Load_CB_Nhomvp();
        }
        private void cbNhom_KeyDown(object sender, KeyEventArgs e)
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

        private void cbNhombhyt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //if (cbNhombhyt.SelectedIndex == cbNhombhyt.Items.Count - 1)
                //{
                //    f_Add_Nhombhyt();
                //}
            }
            catch
            {
            }
        }
        private void cbNhom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbNhomvp.SelectedIndex == cbNhomvp.Items.Count - 1)
                {
                    f_Add_Nhomvp();
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        private void cbNhomvp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbNhombhyt.SelectedValue = f_get_id_nhombhyt(cbNhomvp.SelectedValue.ToString());
            }
            catch
            {
            }
        }
    }
}