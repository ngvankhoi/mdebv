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
    public partial class frmNewbaocao : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_id = "",m_id_cha;
        public frmNewbaocao(LibVP.AccessData v_v, string v_id, string v_id_cha, string v_userid)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = v_v;
            m_userid = v_userid;
            m_id = v_id;
            m_id_cha = v_id_cha;
            m_v.f_SetEvent(this);
        }

        private void frmNewbaocao_Load(object sender, EventArgs e)
        {
            ttStatus.Text = "";
            listDieukien.ItemHeight = 15;
            f_Load_CB_Cha();
            f_Load_Sua();
            f_Enable(true);
            txtStt.Focus();
            if (txtStt.Text == "")
            {
                f_Moi();
            }
        }
        private void f_Load_CB_Cha()
        {
            try
            {
                DataSet ads = m_v.f_get_v_treebaocao("", "", "", "", "", "","");
                if (ads.Tables[0].Select("id=0").Length <= 0)
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["id"] = 0;
                    r["id_cha"] = 0;
                    r["ten"] = 
lan.Change_language_MessageText("(Gốc)");
                    ads.Tables[0].Rows.InsertAt(r,0);
                }
                if (m_id != "" && m_id!="0")
                {
                    try
                    {
                        DataRow r = ads.Tables[0].Select("id=" + m_id)[0];
                        ads.Tables[0].Rows.Remove(r);
                    }
                    catch
                    {
                    }
                }
                cbCha.DisplayMember = "TEN";
                cbCha.ValueMember = "ID";
                cbCha.DataSource = ads.Tables[0];
                cbCha.SelectedValue = m_id_cha;
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
                    foreach (DataRow r in m_v.f_get_v_treebaocao(atmp,"","","","","","").Tables[0].Rows)
                    {
                        m_id = r["id"].ToString();
                        txtStt.Text = r["stt"].ToString();
                        txtTen.Text = r["ten"].ToString();
                        txtSQL.Text = r["sql"].ToString();
                        txtTenreport.Text = r["tenreport"].ToString();
                        chkReadonly.Checked = r["readonly"].ToString()=="1";
                        try
                        {
                            cbCha.SelectedValue = r["id_cha"].ToString();
                        }
                        catch
                        {
                        }
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
            txtTen.Enabled = v_bool;
            txtSQL.Enabled = v_bool;
            txtTenreport.Enabled = v_bool;
            cbCha.Enabled = v_bool;
            chkReadonly.Enabled = v_bool;
        }
        private void f_Moi()
        {
            string aid_cha = "0";
            try
            {
                aid_cha = cbCha.SelectedValue.ToString();
            }
            catch
            {
                aid_cha = "0";
            }
            txtStt.Text = m_v.get_stt_v_treebaocao(aid_cha).ToString();
            txtTen.Text = "";
            txtSQL.Text = "";
            txtTenreport.Text = "";
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
                string aid_cha = "";
                if (txtStt.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập số thứ tự!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStt.Focus();
                    return;
                }
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập tên báo cáo!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                if (txtSQL.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập câu truy vấn SQL!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSQL.Focus();
                    return;
                }
                try
                {
                    aid_cha = cbCha.SelectedValue.ToString();
                }
                catch
                {
                    aid_cha = "0";
                }
                if (aid_cha.Trim() == "" || aid_cha=="-1")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Chọn mục chứa báo cáo!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbCha.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }

                if (m_id == "")
                {
                    m_id = m_v.get_id_v_treebaocao.ToString();
                }
                else
                {
                    try
                    {
                        if (m_v.dadung_v_treebaocao(m_id) == -1)
                        {
                            MessageBox.Show(this, 
lan.Change_language_MessageText("Thông tin này chỉ xem, không cho phép cập nhật!")+"\n"+
lan.Change_language_MessageText("Liên hệ vơi quản trị hệ thống để được trợ giúp."), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    catch
                    {

                    }
                }
                m_v.upd_v_treebaocao(decimal.Parse(m_id), decimal.Parse(aid_cha), decimal.Parse(txtStt.Text.Trim()), txtTen.Text, txtSQL.Text, txtTenreport.Text,chkReadonly.Checked?1:0);
                f_Enable(false);
                f_Load_CB_Cha();
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
                if (m_v.dadung_v_treebaocao(m_id) != 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá báo cáo này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá báo cáo này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_treebaocao(m_id))
                        {
                            MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá báo cáo này!")+"\n"+
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
        private void cbSo_KeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }
        private void butBrown_Click(object sender, EventArgs e)
        {
            try
            {
                string atmp = Application.ExecutablePath;
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp += "\\Report";
                if (!System.IO.Directory.Exists(atmp))
                {
                    System.IO.Directory.CreateDirectory(atmp);
                }
                OpenFileDialog adg = new OpenFileDialog();
                adg.InitialDirectory = atmp;
                adg.Filter = "Crystal Report Document (*.RPT)|*.RPT";
                adg.RestoreDirectory = true;
                adg.CheckFileExists = true;
                adg.Multiselect = false;
                adg.Title = 
lan.Change_language_MessageText("Chọn tên report dùng để in báo cáo!");
                adg.ShowDialog();
                if (adg.FileName != "")
                {
                    txtTenreport.Text = adg.FileName.Split('\\')[adg.FileName.Split('\\').Length - 1];
                }
                adg.Dispose();
            }
            catch
            {
            }
        }

        private void butGetdata_Click(object sender, EventArgs e)
        {
            butGetdata.Enabled = false;
            try
            {
                string sql = "";
                if (txtSQL.SelectedText.Trim() != "")
                {
                    sql = txtSQL.SelectedText.Trim();
                }
                else
                {
                    sql = txtSQL.Text.Trim();
                }
                DataSet ads = m_v.get_data(sql);
                if (ads != null && ads.Tables.Count>0)
                {
                    frmPreviewdata af = new frmPreviewdata(
lan.Change_language_MessageText("Kết quả truy vấn dữ liệu"), ads,"");
                    af.Size = this.Size;
                    af.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Câu truy vấn không đúng!"), m_v.s_AppName, MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show(this, 
lan.Change_language_MessageText("Câu truy vấn không đúng!"), m_v.s_AppName, MessageBoxButtons.OK);
            }
            finally
            {
                butGetdata.Enabled = true;
            }
        }
        private void butGetdataall_Click(object sender, EventArgs e)
        {
            butGetdataall.Enabled = false;
            try
            {
                string sql = "";
                if (txtSQL.SelectedText.Trim() != "")
                {
                    sql = txtSQL.SelectedText.Trim();
                }
                else
                {
                    sql = txtSQL.Text.Trim();
                }
                DataSet ads = m_v.get_data_all(sql);
                if (ads != null && ads.Tables.Count > 0)
                {
                    frmPreviewdata af = new frmPreviewdata(
lan.Change_language_MessageText("Kết quả truy vấn dữ liệu"), ads, "");
                    af.Size = this.Size;
                    af.ShowDialog(this);
                    af.Size = this.Size;
                    af.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Câu truy vấn không đúng!"), m_v.s_AppName, MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show(this, 
lan.Change_language_MessageText("Câu truy vấn không đúng!"), m_v.s_AppName, MessageBoxButtons.OK);
            }
            finally
            {
                butGetdataall.Enabled = true;
            }
        }

        private void txtStt_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtStt.Text.Trim() == "")
                {
                    string aid_cha = "0";
                    try
                    {
                        aid_cha = cbCha.SelectedValue.ToString();
                    }
                    catch
                    {
                        aid_cha = "0";
                    }
                    txtStt.Text = m_v.get_stt_v_treebaocao(aid_cha).ToString();
                }
            }
            catch
            {
            }
        }
    }
}