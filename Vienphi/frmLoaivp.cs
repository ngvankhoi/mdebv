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
    public partial class frmLoaivp : Form
    {
        private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_menu_id = "menuC_1_3_Loaivp";
        private AccessData m_v;        
        private DataSet ds = new DataSet();
        private string m_id="",m_userid="";
        int itable;
        public frmLoaivp(LibVP.AccessData v_v, string v_userid)
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
            itable = m_v.tableid("", "v_loaivp");
            f_Load_CB_Nhomvp();
            f_Enable(false);
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_Load_CB_Nhomvp()
        {
            try
            {
                DataSet ads_loaivp = m_v.f_get_v_loaivp_frmloaivp();
                if (ads_loaivp.Tables[0].Rows.Count <= 0)
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Chưa khai phân loại viện phí!")+"\n"+lan.Change_language_MessageText("Có muốn hệ thống tạo loại mặc định không?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        m_v.f_default_nhombhyt();
                        m_v.f_default_nhomvp();
                        m_v.f_default_loaivp();
                        ads_loaivp = m_v.f_get_v_loaivp_frmloaivp();
                    }
                }
                DataSet ads_nhombhyt = m_v.f_get_v_nhombhyt("", "", "", "", "");
                cbNhombhyt.DisplayMember = "TEN";
                cbNhombhyt.ValueMember = "ID";
                cbNhombhyt.DataSource = ads_nhombhyt.Tables[0];

                DataSet ads_nhomvp = m_v.f_get_v_nhomvp("","","","", "", "", "");

                treeView1.Nodes.Clear();
                TreeNode anode,anode1;
                foreach (DataRow r in ads_nhombhyt.Tables[0].Select("", "ten"))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.ImageIndex = 0;
                    anode.SelectedImageIndex = 1;
                    anode.Tag = r["id"].ToString()+":?";
                    foreach (DataRow r1 in ads_nhomvp.Tables[0].Select("idnhombhyt="+r["id"].ToString(), "ten"))
                    {
                        anode1 = new TreeNode(r1["ten"].ToString());
                        anode1.ImageIndex = 2;
                        anode1.SelectedImageIndex = 3;
                        anode1.Tag = r["id"].ToString()+":"+r1["ma"].ToString();
                        anode.Nodes.Add(anode1);
                    }
                    treeView1.Nodes.Add(anode);
                }
                if (ads_loaivp.Tables[0].Select("id_nhom=-999").Length>0)
                {
                    anode = new TreeNode(lan.Change_language_MessageText("{Chưa khai nhóm viện phí}"));
                    anode.Tag = "-999:-999";
                    anode.ImageIndex = 4;
                    anode.SelectedImageIndex = 4;
                    treeView1.Nodes.Add(anode);
                }
                if (treeView1.Nodes.Count > 1)
                {
                    anode = new TreeNode(lan.Change_language_MessageText("{Tất cả}"));
                    anode.Tag = "-1:-1";
                    anode.ImageIndex = 5;
                    anode.SelectedImageIndex = 5;
                    treeView1.Nodes.Add(anode);
                }
                if (treeView1.Nodes.Count > 0)
                {
                    treeView1.SelectedNode = treeView1.Nodes[treeView1.Nodes.Count - 1];
                }

                if (ads_nhomvp.Tables[0].Select("ma=-1").Length <= 0)
                {
                    DataRow r = ads_nhomvp.Tables[0].NewRow();
                    r["ma"] = -1;
                    r["ten"] = "...";
                    ads_nhomvp.Tables[0].Rows.InsertAt(r, ads_nhomvp.Tables[0].Rows.Count);
                }
                cbNhomvp.DisplayMember = "TEN";
                cbNhomvp.ValueMember = "MA";
                cbNhomvp.DataSource = ads_nhomvp.Tables[0];

                dataGridView1.DataSource = ads_loaivp.Tables[0];
                toolStrip_Tim_TextChanged(null, null);
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
        private void f_Load_Sua()
        {
            try
            {
                DataRowView arv = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                foreach (DataRow r in m_v.f_get_v_loaivp(arv["id"].ToString(),"","","","","","").Tables[0].Rows)
                {
                    m_id = r["id"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtSTT.Text = r["stt"].ToString();
                    txtMa.Text = r["ma"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    txtViettat.Text = r["viettat"].ToString();
                    txtComputer.Text = r["computer"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    try
                    {
                        cbNhomvp.SelectedValue = r["id_nhom"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbNhombhyt.SelectedValue = f_get_id_nhombhyt(r["id_nhom"].ToString());
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
                    m_id = r["id"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtSTT.Text = r["stt"].ToString();
                    txtMa.Text = r["ma"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    txtViettat.Text = r["viettat"].ToString();
                    txtComputer.Text = r["computer"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    txtGuuTN.Text = r["computervp"].ToString();
                    try
                    {
                        cbNhomvp.SelectedValue = r["id_nhom"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbNhombhyt.SelectedValue = f_get_id_nhombhyt(r["id_nhom"].ToString());
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
            butBrown.Enabled = v_bool;

            txtID.Enabled = false;
            txtSTT.Enabled = v_bool;
            txtMa.Enabled = v_bool;
            txtTen.Enabled = v_bool;
            txtViettat.Enabled = v_bool;
            txtComputer.Enabled = v_bool;
            cbNhomvp.Enabled = v_bool;
            cbNhombhyt.Enabled = false;
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
                txtID.Text = "";//m_v.get_id_v_loaivp.ToString();
                txtSTT.Text = m_v.get_stt_v_loaivp.ToString();
                chkReadonly.Checked = false;
                txtMa.Text = "";
                txtTen.Text = "";
                txtViettat.Text = "";
                txtComputer.Text = "";
                m_id = "";
                if (cbNhomvp.SelectedIndex < 0)
                {
                    try
                    {
                        if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                        {
                            cbNhomvp.SelectedValue = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                        }
                        else
                        {
                            cbNhomvp.SelectedIndex = 0;
                        }
                    }
                    catch
                    {
                    }
                }
                f_Enable(true);
                txtMa.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    aid_nhombhyt = "";
                }
                frmNewnhomvp af = new frmNewnhomvp(m_v,"",aid_nhombhyt, m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog();
                f_Load_CB_Nhomvp();
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
            f_Load_CB_Nhomvp();
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            f_Load_View();
        }
        private void toolStrip_Tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "", aid_nhombhyt = "", aid_nhomvp = "";
                if (toolStrip_Tim.Text != "")
                {
                    aft = "(ten like '%" + toolStrip_Tim.Text.Replace("'","''") + "%' or viettat like '%" + toolStrip_Tim.Text.Replace("'","''") + "%'or matat like '%" + toolStrip_Tim.Text.Replace("'","''") + "%')";
                }
                try
                {
                    aid_nhombhyt = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                }
                catch
                {
                    aid_nhombhyt = "";
                }
                try
                {
                    aid_nhomvp = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                }
                catch
                {
                    aid_nhomvp = "";
                }
                if (aid_nhombhyt == "-1" || aid_nhombhyt == "?")
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
                if (aid_nhomvp == "-1" || aid_nhomvp == "?")
                {
                    aid_nhomvp = "";
                }
                if (aid_nhomvp != "")
                {
                    if (aft != "")
                    {
                        aft += " and ";
                    }
                    aft += "id_nhom=" + aid_nhomvp;
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách loại viện phí (") + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách loại viện phí (");
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
               
                if (m_id !="")
                {
                    m_v.upd_eve_tables(itable, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(itable, int.Parse(m_userid), "upd", m_v.fields("medibv.v_loaivp", "id=" + m_id));
                }
                else m_v.upd_eve_tables(itable, int.Parse(m_userid), "ins");

                string aid_nhomvp = "";
                if (txtSTT.Text.Trim() == "")
                {
                    txtSTT.Text=m_v.get_stt_v_loaivp.ToString();
                }
                if (txtMa.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập mã loại viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Nhập tên loại viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }

                try
                {
                    aid_nhomvp = cbNhomvp.SelectedValue.ToString();
                }
                catch
                {
                    aid_nhomvp = "";
                }
                if (aid_nhomvp.Trim() == "" || aid_nhomvp == "-1")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Chọn nhóm viện phí tương ứng!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbNhomvp.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }

                if (m_id == "")
                {
                    m_id = m_v.get_id_v_loaivp.ToString();
                }
                else
                {
                    if (m_v.dadung_v_loaivp(m_id) == -1)
                    {
                        if (!m_v.is_dba_admin(m_userid))
                        {
                            MessageBox.Show(this,
lan.Change_language_MessageText("Hệ thống không cho sửa nội dung này!") + "\n" +
lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                if (m_v.f_get_v_loaivp("","", "", txtMa.Text, "","", "").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Mã loại đã tồn tại, chọn mã khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (m_v.f_get_v_loaivp("","","","",txtTen.Text.Trim(),"","").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Tên loại đã tồn tại, chọn tên khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                m_v.upd_v_loaivp(decimal.Parse(m_id),decimal.Parse(aid_nhomvp),decimal.Parse(txtSTT.Text),txtMa.Text.Trim(),txtTen.Text.Trim(),txtViettat.Text.Trim(),decimal.Parse(m_userid),txtComputer.Text.Trim(),chkReadonly.Checked?1:0,txtGuuTN.Text);
                f_Enable(false);
                f_Load_CB_Nhomvp();
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
                if (m_v.dadung_v_loaivp(m_id) != 0)
                {
                    MessageBox.Show(this,
lan.Change_language_MessageText( "Hệ thống không cho xoá loại viện phí này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá loại viện phí ?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {                        
                        if (m_id != "0")
                        {
                            m_v.upd_eve_tables(itable, int.Parse(m_userid), "del");
                            m_v.upd_eve_upd_del(itable, int.Parse(m_userid), "del", m_v.fields(m_v.user + ".v_loaivp", "id=" + m_id));
                        }

                        if (!m_v.del_v_loaivp(m_id))
                        {
                            MessageBox.Show(this, 
lan.Change_language_MessageText("Hệ thống không cho xoá loại viện phí này!")+"\n"+
lan.Change_language_MessageText("Liên hệ với quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            f_Load_CB_Nhomvp();
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
        private void cbNhomvp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbNhomvp.SelectedIndex == cbNhomvp.Items.Count - 1)
                {
                    f_Add_Nhomvp();
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
                if (e.Node.Tag.ToString() == "-999:-999")
                {
                    ttStatus.Text = e.Node.Text.ToString();
                }
                else
                if (e.Node.Tag.ToString() == "-1:-1")
                {
                    ttStatus.Text = e.Node.Text.ToString();
                }
                else
                {
                    ttStatus.Text = (e.Node.Parent == null) ? 
lan.Change_language_MessageText("Nhóm viện phí BHYT") : 
lan.Change_language_MessageText("Nhóm viện phí");
                }
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

        private void cbNhomvp_KeyDown(object sender, KeyEventArgs e)
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

        private void txtComputer_KeyDown(object sender, KeyEventArgs e)
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

        private void butBrown_Click(object sender, EventArgs e)
        {
            try
            {
                frmChonmay af = new frmChonmay(m_v, txtComputer.Text);
                af.ShowInTaskbar = false;
                if (af.ShowDialog(this) == DialogResult.OK)
                {
                    txtComputer.Text = af.s_computer;
                }
                af.Dispose();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
        private void f_In()
        {
            try
            {
                DataSet ads = new DataSet();
                string sql = "";
                sql = "select a.id, a.stt, a.ma, a.ten, a.id_nhom, b.stt as stt_nhom, b.ten as ten_nhom from medibv.v_loaivp a left join medibv.v_nhomvp b on a.id_nhom=b.ma order by b.stt, b.ten,a.stt,a.ten";
                ads = m_v.get_data(sql);
                //ads.WriteXml("..//..//Datareport//v_loaivp.xml", XmlWriteMode.WriteSchema);
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

                string areport = "v_2007_loaivp.rpt";
                ReportDocument cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = 
lan.Change_language_MessageText("Phân loại viện phí (")+areport+")";
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

        private void butGuuTN_Click(object sender, EventArgs e)
        {
            try
            {
                frmChonmay af = new frmChonmay(m_v, txtGuuTN.Text);
                af.ShowInTaskbar = false;
                if (af.ShowDialog(this) == DialogResult.OK)
                {
                    txtGuuTN.Text = af.s_computer;
                }
                af.Dispose();
            }
            catch
            {
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}