using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDSDuyet : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        DataTable dtbs = new DataTable();
        DataTable dtnhommien = new DataTable();
        DataTable dttam = new DataTable();
        private DataSet m_dsds;
        private string m_id="",m_userid="",sql;
        bool bMoi = true;
        
        public frmDSDuyet(LibVP.AccessData v_v, string v_userid)
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
            sql = "select * from "+m_v.user+".dmbs ";
            dtbs = m_v.get_data(sql).Tables[0];
            listDmbs.DataSource = dtbs;
            listDmbs.DisplayMember = "hoten";
            listDmbs.ValueMember = "hoten";
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
                m_dsds = m_v.f_get_v_dsduyet("","","");
                dataGridView1.DataSource = m_dsds.Tables[0];
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách nhân viên duyệt miễn giảm (") + m_dsds.Tables[0].Rows.Count.ToString() + ")";
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
                foreach (DataRow r in m_v.f_get_v_dsduyet(arv["id"].ToString(), "", "").Tables[0].Rows)
                {
                    m_id = r["ma"].ToString();
                    txtMa.Text = r["ma"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    txtMabs.Text = r["mabs"].ToString();
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
                    m_id = r["ma"].ToString();
                    txtMa.Text = r["ma"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    txtMabs.Text = r["mabs"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    f_Enable(false);
                    sql = "select c.id,c.ten,nvl(a.tyle,0) tyle from (select * from " + m_v.user + ".v_dsduyet a ," + m_v.user + ".v_tyleduyetmien b where a.ma=b.ma and b.ma="+m_id+") a right join " + m_v.user + ".v_nhommien c on a.id_nhommien=c.id ";
                    //sql = "select c.id,c.ten,b.tyle from " + m_v.user + ".v_dsduyet a ," + m_v.user + ".v_tyleduyetmien b ," + m_v.user + ".v_nhommien c where b.id_nhommien=c.id and a.ma=b.ma and b.ma="+m_id;
                    dttam = m_v.get_data(sql).Tables[0];
                    //dataGridView2.DataSource = null;
                    if (dttam.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = dttam;
                        bMoi = false;
                    }
                    else
                    {
                        sql = "select id,ten,'0' tyle from " + m_v.user + ".v_nhommien ";
                        dtnhommien = m_v.get_data(sql).Tables[0];
                        dataGridView2.DataSource = dtnhommien;
                        bMoi = true;
                    }
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

            txtMabs.Enabled = v_bool;
            txtMa.Enabled = v_bool;
            txtTen.Enabled = v_bool;
            chkReadonly.Enabled = v_bool;
        }
        private void f_Moi()
        {
            try
            {
                txtMa.Text = m_v.get_id_v_dsduyet.ToString();
                txtTen.Text = "";
                txtMabs.Text = "";
                chkReadonly.Checked = false;
                m_id = "";
                f_Enable(true);
                txtTen.Focus();
                sql = "select id,ten,'0' tyle from " + m_v.user + ".v_nhommien";
                dtnhommien = m_v.get_data(sql).Tables[0];
                dataGridView2.DataSource = dtnhommien;
                bMoi = true;
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
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách nhân viên duyệt miễn giảm (") + dv.Table.Select(aft).Length.ToString() + "/" + toolStrip_Title.Tag.ToString() + ")";
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
                            lan.Change_language_MessageText("Nhập họ và tên!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                if (m_id == "")
                {
                    if (txtMa.Text != "")
                    {
                        m_id = txtMa.Text.Trim();
                    }
                    else
                    {
                        m_id = m_v.get_id_v_dsduyet.ToString();
                    }
                }
                if (dtbs.Select("ma = '" + txtMabs.Text.Trim() + "'").Length == 0 || dtbs.Select("hoten='" + txtTen.Text.Trim() + "'").Length == 0)
                {
                    //MessageBox.Show(this,
                    //        lan.Change_language_MessageText("Bác sĩ không hợp lệ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                    txtMabs.Text = "";
                }
                if (m_v.dadung_v_dsduyet(txtMabs.Text.Trim()) == -1)
                {
                    if (!m_v.is_dba_admin(m_userid))
                    {
                        MessageBox.Show(this,
                                lan.Change_language_MessageText("Hệ thống không cho sửa nội dung này!") + "\n" +
                                lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                if (bMoi)
                {
                    for (int i = 0; i < dtnhommien.Rows.Count; i++)
                    {
                        try
                        {
                            if (int.Parse(dtnhommien.Rows[i]["tyle"].ToString()) > 100 || int.Parse(dtnhommien.Rows[i]["tyle"].ToString()) < 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ '" + dtnhommien.Rows[i]["ten"].ToString() + "' không hợp lệ!"), m_v.s_AppName);
                                return;
                            }
                        }
                        catch {
                            MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ '" + dtnhommien.Rows[i]["ten"].ToString() + "' không hợp lệ!"), m_v.s_AppName);
                            return;
                        }
                    }
                }
                else {
                    for (int i = 0; i < dttam.Rows.Count; i++)
                    {
                        try
                        {
                            if (int.Parse(dttam.Rows[i]["tyle"].ToString()) > 100 || int.Parse(dttam.Rows[i]["tyle"].ToString()) < 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ '" + dttam.Rows[i]["ten"].ToString() + "' không hợp lệ!"), m_v.s_AppName);
                                return;
                            }
                        }
                        catch
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ '" + dttam.Rows[i]["ten"].ToString() + "' không hợp lệ!"), m_v.s_AppName);
                            return;
                        }
                    }
                }
                m_v.upd_v_dsduyet(txtMa.Text, txtTen.Text, chkReadonly.Checked ? 1 : 0,txtMabs.Text.Trim());
                if (bMoi)
                {
                    for (int i = 0; i < dtnhommien.Rows.Count; i++)
                    {

                        m_v.upd_v_tyleduyetmien(int.Parse(m_id), int.Parse(dtnhommien.Rows[i]["id"].ToString()), int.Parse(dtnhommien.Rows[i]["tyle"].ToString()));
                       
                    }
                }
                else
                {
                    for (int i = 0; i < dttam.Rows.Count; i++)
                    {
                        
                            m_v.upd_v_tyleduyetmien(int.Parse(m_id), int.Parse(dttam.Rows[i]["id"].ToString()), int.Parse(dttam.Rows[i]["tyle"].ToString()));
                        
                    }
                }
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
            txtMa.Focus();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.dadung_v_dsduyet(m_id) != 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá nhân viên duyệt miễn giảm này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá nhân viên duyệt miễn giảm?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_dsduyet(m_id))
                        {
                            MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá nhân viên duyệt miễn giảm này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dataGridView1_CurrentCellChanged(null, null);
            }
            catch
            {
            }
        }

        

        private void txtStt_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listDmbs.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listDmbs.Visible)
                {
                    listDmbs.Focus();
                    SendKeys.Send("{Down}");
                }
                else SendKeys.Send("{Tab}");
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

        private void txtTen_Validated(object sender, EventArgs e)
        {
            if (!listDmbs.Focused)
            {
                listDmbs.Hide();
            }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            Filt_dmbs(txtTen.Text);
            listDmbs.BrowseToText(txtTen, txtMabs, txtTen.Location.X, txtTen.Location.Y + txtTen.Height, txtTen.Width + txtTen.Width + 2, txtTen.Height);
        }
        private void Filt_dmbs(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listDmbs.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "hoten LIKE '%" + ten.Trim() + "%' or ma LIKE '%" + ten.Trim() + "%' ";
        }

        private void txtMabs_TextChanged(object sender, EventArgs e)
        {
            //Filt_dmbs(txtTen.Text);
            //listDmbs.BrowseToText(txtTen, txtMabs, txtTen.Location.X, txtTen.Location.Y + txtTen.Height, txtTen.Width + txtTen.Width + 2, txtTen.Height);
        }

        private void txtMabs_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    txtTen.Text = dtbs.Select("ma=" + txtMabs.Text.Trim())[0]["hoten"].ToString();
            //}
            //catch {
            //    txtTen.Text = "";
            //}
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ không hợp lệ!"), m_v.s_AppName);
        }
    }
}