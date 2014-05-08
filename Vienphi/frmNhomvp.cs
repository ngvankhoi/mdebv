using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using LibVP;

namespace Vienphi
{
    public partial class frmNhomvp : Form
    {
        private string m_menu_id = "menu_C_1_3_Nhomvp";
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_id="",m_userid="";
        public frmNhomvp(LibVP.AccessData v_v, string v_userid)
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
            f_Load_CB_Nhombhyt();
            f_Enable(false);
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_Load_CB_Nhombhyt()
        {
            try
            {
                DataSet ads_nhomvp = m_v.f_get_v_nhomvp_frmnhomvp();
                if (ads_nhomvp.Tables[0].Rows.Count <= 0)
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Chưa khai nhóm viện phí!")+"\n"+lan.Change_language_MessageText("Có muốn hệ thống tạo nhóm mặc định không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        m_v.f_default_nhombhyt();
                        m_v.f_default_nhomvp();
                        ads_nhomvp = m_v.f_get_v_nhomvp_frmnhomvp();
                    }
                }
                DataSet ads = m_v.f_get_v_nhombhyt("", "", "", "", "");

                treeView1.Nodes.Clear();
                TreeNode anode;
                foreach (DataRow r in ads.Tables[0].Select("","ten"))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.ImageIndex = 0;
                    anode.SelectedImageIndex = 1;
                    anode.Tag = r["id"].ToString();
                    treeView1.Nodes.Add(anode);
                }
                if (ads_nhomvp.Tables[0].Select("idnhombhyt=-999").Length>0)
                {
                    anode = new TreeNode(lan.Change_language_MessageText("{Chưa khai nhóm BHYT}"));
                    anode.Tag = "-1";
                    anode.ImageIndex = 2;
                    anode.SelectedImageIndex = 2;
                    treeView1.Nodes.Add(anode);
                }
                if (treeView1.Nodes.Count > 1)
                {
                    anode = new TreeNode(
lan.Change_language_MessageText("{Tất cả}"));
                    anode.Tag = "-1";
                    anode.ImageIndex = 3;
                    anode.SelectedImageIndex = 3;
                    treeView1.Nodes.Add(anode);
                }
                if (treeView1.Nodes.Count > 0)
                {
                    treeView1.SelectedNode = treeView1.Nodes[treeView1.Nodes.Count - 1];
                }

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

                dataGridView1.DataSource = ads_nhomvp.Tables[0];
                toolStrip_Tim_TextChanged(null, null);
            }
            catch
            {
            }
        }
        private void f_Load_Sua()
        {
            try
            {
                DataRowView arv = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                foreach (DataRow r in m_v.f_get_v_nhomvp(arv["id"].ToString(),"","", "","","","").Tables[0].Rows)
                {
                    m_id = r["ma"].ToString();
                    txtID.Text = r["ma"].ToString();
                    txtSTT.Text = r["stt"].ToString();
                    txtMa.Text = r["matat"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    txtViettat.Text = r["viettat"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    try
                    {
                        cbNhombhyt.SelectedValue = r["idnhombhyt"].ToString();
                    }
                    catch
                    {
                    }
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
                    txtID.Text = r["ma"].ToString();
                    txtSTT.Text = r["stt"].ToString();
                    txtMa.Text = r["matat"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    txtViettat.Text = r["viettat"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    try
                    {
                        cbNhombhyt.SelectedValue = r["idnhombhyt"].ToString();
                    }
                    catch
                    {
                    }
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
            txtSTT.Enabled = false;// v_bool;
            txtMa.Enabled = v_bool;
            txtTen.Enabled = v_bool;
            txtViettat.Enabled = v_bool;
            cbNhombhyt.Enabled = v_bool;
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
                txtSTT.Text = m_v.get_stt_v_nhomvp.ToString();
                chkReadonly.Checked = false;
                txtMa.Text = "";
                txtTen.Text = "";
                txtViettat.Text = "";
                if (cbNhombhyt.SelectedIndex < 0)
                {
                    try
                    {
                        cbNhombhyt.SelectedValue = treeView1.SelectedNode.Tag.ToString();
                    }
                    catch
                    {
                        cbNhombhyt.SelectedIndex = 0;
                    }
                }
                if (cbNhombhyt.SelectedIndex < 0)
                {
                    cbNhombhyt.SelectedIndex = 0;
                }
                m_id = "";
                f_Enable(true);
                txtMa.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void toolStrip_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_CB_Nhombhyt();
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            f_Load_View();
        }
        private void toolStrip_Tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "",aid_nhombhyt="";
                if (toolStrip_Tim.Text != "")
                {
                    aft = "(ten like '%" + toolStrip_Tim.Text.Replace("'","''") + "%' or viettat like '%" + toolStrip_Tim.Text.Replace("'","''") + "%'or matat like '%" + toolStrip_Tim.Text.Replace("'","''") + "%')";
                }
                try
                {
                    aid_nhombhyt = treeView1.SelectedNode.Tag.ToString();
                }
                catch
                {
                    aid_nhombhyt = "";
                }
                if(aid_nhombhyt=="-1")
                {
                    aid_nhombhyt = "";
                }
                if (aid_nhombhyt != "")
                {
                    if (aft != "")
                    {
                        aft += " and ";
                    }
                    aft += "idnhombhyt=" + aid_nhombhyt;
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách nhóm viện phí (") + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách nhóm viện phí");
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
                string aid_nhombhyt = "";
                if (txtSTT.Text.Trim() == "")
                {
                    txtSTT.Text=m_v.get_stt_v_nhomvp.ToString();
                }
                if (txtMa.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập mã nhóm viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập tên nhóm viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }

                try
                {
                    aid_nhombhyt = cbNhombhyt.SelectedValue.ToString();
                }
                catch
                {
                    aid_nhombhyt = "";
                }
                if (aid_nhombhyt.Trim() == "" || aid_nhombhyt == "-1")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn nhóm BHYT tương ứng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbNhombhyt.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }

                if (m_id == "")
                {
                    m_id = m_v.get_id_v_nhomvp.ToString();
                }
                else
                {
                    if (m_v.dadung_v_nhomvp(m_id) == -1)
                    {
                        if (!m_v.is_dba_admin(m_userid))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho sửa nội dung này!") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                if (m_v.f_get_v_nhomvp("", "", "", "", txtMa.Text, "", "").Tables[0].Select("ma <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Mã nhóm đã tồn tại, chọn mã khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (m_v.f_get_v_nhomvp("","","",txtTen.Text.Trim(),"", "", "").Tables[0].Select("ma <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Tên nhóm đã tồn tại, chọn tên khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                m_v.upd_v_nhomvp(decimal.Parse(m_id),decimal.Parse(txtSTT.Text),txtTen.Text,txtMa.Text,txtViettat.Text,decimal.Parse(aid_nhombhyt),chkReadonly.Checked?1:0);
                f_Enable(false);
                f_Load_CB_Nhombhyt();
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
            txtSTT.Focus();
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
                if (m_v.dadung_v_nhomvp(m_id) != 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá nhóm viện phí này !")+"\n"+lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá nhóm viện phí ?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_nhomvp(m_id))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá nhóm viện phí này !")+"\n"+lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            f_Load_CB_Nhombhyt();
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
                afo.Title = lan.Change_language_MessageText("Chọn file dữ liệu đã download từ Medisoft Center Update");
                afo.ShowDialog();
                if (afo.FileName != "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Cập nhật thành công!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (cbNhombhyt.SelectedIndex == cbNhombhyt.Items.Count - 1)
                {
                    f_Add_Nhombhyt();
                }
            }
            catch
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = Color.Red;
                toolStrip_Tim_TextChanged(null, null);
            }
            catch
            {
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeView1.SelectedNode.ForeColor = Color.Black;
            }
            catch
            {
            }
        }

        private void butNhomduoc_Click(object sender, EventArgs e)
        {
            try
            {
                frmPhannhomduoc af = new frmPhannhomduoc(m_v,m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
            }
            catch
            {
            }
        }
        private void f_In()
        {
            try
            {
                DataSet ads = new DataSet();
                string sql = "";
                sql = "select ma, ten, stt from medibv.v_nhomvp order by stt";
                ads = m_v.get_data(sql);
                //ads.WriteXml("..//..//Datareport//v_nhomvp.xml", XmlWriteMode.WriteSchema);
                //return;

                CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crystalReportViewer1.ActiveViewIndex = -1;
                crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
                crystalReportViewer1.DisplayGroupTree = false;
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                crystalReportViewer1.Name = "crystalReportViewer1";
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
                crystalReportViewer1.TabIndex = 85;

                System.Windows.Forms.Form af = new System.Windows.Forms.Form();
                af.WindowState = FormWindowState.Maximized;
                af.Controls.Add(crystalReportViewer1);
                crystalReportViewer1.BringToFront();
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                string areport = "v_2007_nhomvp.rpt";
                ReportDocument cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = lan.Change_language_MessageText("Phân nhóm viện phí (") + areport + ")";
                af.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            f_In();
        }
    }
}