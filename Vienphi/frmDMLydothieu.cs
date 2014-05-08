using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmLydothieu : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private DataSet m_dsds;
        private string m_id="",m_userid="";
        public frmLydothieu(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
            lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
            m_v = v_v;
            m_userid = v_userid;
            m_v.f_SetEvent(this);
        }

        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            f_Load_DG();
            f_Enable(false);
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_Load_DG()
        {
            try
            {
                m_dsds = m_v.f_get_v_dmlydothieu("","","");
                dataGridView1.DataSource = m_dsds.Tables[0];
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách lý do thiếu (") + m_dsds.Tables[0].Rows.Count.ToString() + ")";
                toolStrip_Title.Tag = m_dsds.Tables[0].Rows.Count.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_Sua()
        {
            try
            {
                DataRowView arv = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                foreach (DataRow r in m_v.f_get_v_dmlydothieu(arv["id"].ToString(), "", "").Tables[0].Rows)
                {
                    m_id = r["id"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    break;
                }
            }
            catch
            {
            }
        }
        private void f_Load_View()
        {
            try
            {
                if (!butLuu.Enabled)
                {
                    DataRowView r = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                    m_id = r["id"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    f_Enable(false);
                }
            }
            catch//(Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
        private void f_Enable(bool v_bool)
        {
            butMoi.Enabled = !v_bool;
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool && m_id != "";
            butXoa.Enabled = !v_bool && m_id != "";
            butBoqua.Enabled = true;

            txtID.Enabled = false;// v_bool;
            txtTen.Enabled = v_bool;
            chkReadonly.Enabled = v_bool;
        }
        private void f_Moi()
        {
            try
            {
                txtID.Text = m_v.get_id_v_dmlydothieu.ToString();
                txtTen.Text = "";
                chkReadonly.Checked = false;
                m_id = "";
                f_Enable(true);
                txtTen.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            f_Load_View();
        }
        private void toolStrip_Tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                if (toolStrip_Tim.Text != "")
                {
                    aft = "ten like '%" + toolStrip_Tim.Text.Replace("'","''") + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách lý do thiếu (") + dv.Table.Select(aft).Length.ToString() + "/" + toolStrip_Title.Tag.ToString() + ")";
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
            try
            {
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập lý do thiếu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                if (m_id == "")
                {
                    if (txtID.Text != "")
                    {
                        m_id = txtID.Text.Trim();
                    }
                    else
                    {
                        m_id = m_v.get_id_v_dmlydothieu.ToString();
                    }
                }
                else
                {
                    if (m_v.dadung_v_dmlydothieu(m_id) == -1)
                    {
                        if (!m_v.is_dba_admin(m_userid))
                        {
                            MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho sữa nội dung này!")+"\n"+
lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                m_v.upd_v_dmlydothieu(decimal.Parse(m_id), txtTen.Text,chkReadonly.Checked?1:0);
                f_Enable(false);
                f_Load_DG();
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
            txtTen.Focus();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.dadung_v_dmlydothieu(m_id) != 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá lý do thiếu này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá lý do thiếu?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_dmlydothieu(m_id))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá lý do thiếu này!") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            f_Load_DG();
                            butBoqua_Click(null, null);
                        }
                    }
            }
            catch
            {
            }
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            try
            {
                f_Load_Sua();
                f_Enable(false);
                butMoi.Focus();
            }
            catch
            {
            }
        }
        private void txtID_KeyDown(object sender, KeyEventArgs e)
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

        private void butMedisoftcenter_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedisoftcenterupdate af = new frmMedisoftcenterupdate(m_v, m_userid, "DMVT");
                af.TopMost = true;
                af.ShowDialog();
            }
            catch
            {
            }
        }
        private void butLocal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog afo = new OpenFileDialog();
                afo.RestoreDirectory = true;
                afo.Filter = "Microsoft XML Document (*.XML)|*.xml";
                afo.Title = lan.Change_language_MessageText("Chọn file dữ liệu đã download từ Medisoft Center Update");
                afo.ShowDialog();
                if (afo.FileName != "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Cập nhật thành công!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void toolStrip_Title_Click(object sender, EventArgs e)
        {

        }
    }
}