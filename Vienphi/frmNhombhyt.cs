﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmNhombhyt : Form
    {
        private string m_menu_id = "menu_C_1_2_Nhombhyt";
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private DataSet m_dsds;
        private string m_id="",m_userid="";
        int itable;
        public frmNhombhyt(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
           // lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
            //lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
            m_v = v_v;
            m_userid = v_userid;
            m_v.f_SetEvent(this);
        }

        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            itable = m_v.tableid("", "v_nhombhyt");
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
                m_dsds = m_v.f_get_v_nhombhyt("","","","","");
                if (m_dsds.Tables[0].Rows.Count <= 0)
                {
                    if (MessageBox.Show(this,lan.Change_language_MessageText("Chưa khai nhóm viện phí BHYT!") + "\n" + lan.Change_language_MessageText("Có muốn hệ thống tạo nhóm BHYT mặc định không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        m_v.f_default_nhombhyt();
                        m_dsds = m_v.f_get_v_nhombhyt("", "", "", "", "");
                    }
                }
                dataGridView1.DataSource = m_dsds.Tables[0];
                toolStrip_Tim_TextChanged(null, null);
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
                foreach (DataRow r in m_v.f_get_v_nhombhyt(arv["id"].ToString(),"","", "","").Tables[0].Rows)
                {
                    m_id = r["id"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    txtViettat.Text = r["viettat"].ToString();
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
                    txtViettat.Text = r["viettat"].ToString();
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

            txtID.Enabled = false;
            txtSTT.Enabled = v_bool;
            txtTen.Enabled = v_bool;
            txtViettat.Enabled = v_bool;
            chkReadonly.Enabled = v_bool;
        }
        private void f_Moi()
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_them(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền thêm!"));
                return;
            }
            try
            {
                txtID.Text = "";
                txtSTT.Text = m_v.get_stt_v_nhombhyt.ToString();
                chkReadonly.Checked = false;
                txtTen.Text = "";
                txtViettat.Text = "";
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
                    aft = "ten like '%" + toolStrip_Tim.Text.Replace("'","''") + "%' or viettat like '%" + toolStrip_Tim.Text.Replace("'","''") + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách nhóm viện phí BHYT (") + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách nhóm viện phí BHYT (");
            }
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_them(aquyenchitiet) && (m_id == "" || m_id == "0"))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền thêm mới!"));
                return;
            }
            else if (!m_v.f_quyenchitiet_sua(aquyenchitiet) && (m_id != "" && m_id != "0"))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền sửa!"));
                return;
            }
            try
            {
                if (txtSTT.Text.Trim() == "")
                {
                    txtSTT.Text=m_v.get_stt_v_nhombhyt.ToString();
                }
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập tên nhóm viện phí BHYT!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                if (m_id == "")
                {
                    m_id = m_v.get_id_v_nhombhyt.ToString();
                }
                else
                {
                    if (m_v.dadung_v_nhombhyt(m_id) == -1)
                    {
                        if (!m_v.is_dba_admin(m_userid))
                        {
                            MessageBox.Show(this,lan.Change_language_MessageText("Hệ thống không cho sửa nội dung này!") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }

                
                if (m_id != "")
                {
                    m_v.upd_eve_tables(itable, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(itable, int.Parse(m_userid), "upd", m_v.fields("medibv.v_nhombhyt", "id=" + m_id));
                }
                else m_v.upd_eve_tables(itable, int.Parse(m_userid), "ins");

                m_v.upd_v_nhombhyt(Decimal.Parse(m_id),Decimal.Parse(txtSTT.Text),txtTen.Text, txtViettat.Text,chkReadonly.Checked?1:0);
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
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_sua(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền sửa!"));
                return;
            }
            f_Enable(true);
            txtID.Focus();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_xoa(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền xóa!"));
                return;
            }
            try
            {
                if (m_v.dadung_v_nhombhyt(m_id) != 0)
                {
                    MessageBox.Show(this,
lan.Change_language_MessageText("Hệ thống không cho xoá nhóm viện phí BHYT này!") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá nhóm viện phí BHYT?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_nhombhyt(m_id))
                        {
                            MessageBox.Show(this,
lan.Change_language_MessageText("Hệ thống không cho xoá nhóm viện phí BHYT này!") + "\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void txtSTT_KeyDown(object sender, KeyEventArgs e)
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

        private void butMedisoftcenter_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedisoftcenterupdate af = new frmMedisoftcenterupdate(m_v, m_userid, "DMBP");
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
                afo.Title = 
lan.Change_language_MessageText("Chọn file dữ liệu đã download từ Medisoft Center Update");
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
    }
}