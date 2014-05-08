using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmQuanlyuser : Form
    {
        //
        private LibVP.AccessData m_v;
        string s_lbQuyen = "";
        private string m_userid = "",m_id_copy = "",m_loai_copy = "";
        private DataSet m_dsquyen;
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        public frmQuanlyuser(LibVP.AccessData v_v, TreeNode v_node, string v_userid)
        {
            InitializeComponent();


            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            //
            lan.Read_ContextMenuStrip_to_Xml(this.Name.ToString() + "_" + "contextMenuStrip1", contextMenuStrip1);
            lan.Change_ContextMenuStrip_to_English(this.Name.ToString() + "_" + "contextMenuStrip1", contextMenuStrip1);
            //
            lan.Read_ContextMenuStrip_to_Xml(this.Name.ToString() + "_" + "contextMenuStrip2", contextMenuStrip2);
            lan.Change_ContextMenuStrip_to_English(this.Name.ToString() + "_" + "contextMenuStrip2", contextMenuStrip2);
            m_v = v_v;
            m_userid = v_userid;
            m_v.f_SetEvent(this);
            treeView2.Nodes.Add(v_node);
        }
        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            f_Load_User();
            ttStatus.Text = "";
            s_lbQuyen = lan.Change_language_MessageText("Chức năng sử dụng (");
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_Load_Quyen()
        {
            ttStatus.Text = "";
            try
            {
                string aid = "",aloai="N";
                try
                {
                    aid = treeView1.SelectedNode.Tag.ToString().Split(':')[treeView1.SelectedNode.Parent == null ? 0 : 1];
                    aloai = treeView1.SelectedNode.Parent == null ? "N" : "U";
                }
                catch
                {
                    aid = "";
                }
                if (aloai == "N")
                {
                    m_dsquyen = m_v.f_get_v_phanquyennhom(aid);
                }
                else
                {
                    m_dsquyen = m_v.f_get_v_phanquyen(aid);
                }
                foreach (TreeNode anode in treeView2.Nodes)
                {
                    anode.Checked = f_Chon(anode.Tag.ToString());
                    try
                    {
                        if (m_dsquyen.Tables[0].Select("menuname='" + anode.Tag.ToString() + "'").Length <= 0 && anode.Nodes.Count<=0)
                        {
                            DataRow r = m_dsquyen.Tables[0].NewRow();
                            r[0] = 0;
                            r["menuname"] = anode.Tag.ToString();
                            r["chon"] = 0;
                            r["chitiet"] = "000" + r["chon"].ToString() + "00";
                            m_dsquyen.Tables[0].Rows.Add(r);
                        }
                    }
                    catch
                    {
                    }
                    if (anode.Nodes.Count > 0)
                    {
                        if (m_dsquyen.Tables[0].Select("menuname='" + anode.Tag.ToString() + "'").Length > 0)
                        {
                            DataRow r1 = m_dsquyen.Tables[0].Select("menuname='" + anode.Tag.ToString() + "'")[0];
                            m_dsquyen.Tables[0].Rows.Remove(r1);
                        }
                        f_Set_Quyen(anode);
                    }
                }
                f_Set_Quyen_Chitiet();
            }
            catch
            {
            }
        }
        private void f_Set_Quyen(TreeNode v_node)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = f_Chon(anode.Tag.ToString());
                    try
                    {
                        if (m_dsquyen.Tables[0].Select("menuname='" + anode.Tag.ToString() + "'").Length <= 0 && anode.Nodes.Count<=0)
                        {
                            DataRow r = m_dsquyen.Tables[0].NewRow();
                            r[0] = 0;
                            r["menuname"] = anode.Tag.ToString();
                            r["chon"] = 0;
                            r["chitiet"] = "000" + r["chon"].ToString() + "00";
                            m_dsquyen.Tables[0].Rows.Add(r);
                        }
                    }
                    catch
                    {
                    }
                    if (anode.Nodes.Count > 0)
                    {
                        if (m_dsquyen.Tables[0].Select("menuname='" + anode.Tag.ToString() + "'").Length > 0)
                        {
                            DataRow r1 = m_dsquyen.Tables[0].Select("menuname='" + anode.Tag.ToString() + "'")[0];
                            m_dsquyen.Tables[0].Rows.Remove(r1);
                        }
                        f_Set_Quyen(anode);
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Chon_All()
        {
            butQuyen_All.Enabled = false;
            try
            {
                ttProgress.Visible = true;
                ttProgress.Value = 0;
                ttProgress.Maximum = m_dsquyen.Tables[0].Rows.Count;
                foreach (TreeNode anode in treeView2.Nodes)
                {
                    anode.Checked = butQuyen_All.Checked;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode, butQuyen_All.Checked);
                    }
                    if (ttProgress.Value < ttProgress.Maximum)
                    {
                        ttProgress.Value = ttProgress.Value + 1;
                        statusStrip1.Refresh();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                ttProgress.Visible = false;
                butQuyen_All.Enabled = true;
            }
        }
        private void f_Chon_Quyen(TreeNode v_node,bool v_bool)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = v_bool;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode,v_bool);
                    }
                    if (ttProgress.Value < ttProgress.Maximum)
                    {
                        ttProgress.Value = ttProgress.Value + 1;
                        statusStrip1.Refresh();
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Load_User()
        {
            try
            {
                TreeNode anode, anode1;
                treeView1.Nodes.Clear();
                treeView1.ItemHeight = 18;
                DataSet ads = m_v.f_get_v_nhomdlogin("","","","","");
                if (ads == null)
                {
                    m_v.f_create_v_nhomdlogin();
                    ads = m_v.f_get_v_nhomdlogin("", "", "", "", "");
                }
                DataSet ads1 = m_v.f_get_v_dlogin("", "", "", "", "");

                if (ads.Tables[0].Rows.Count == 0)
                {
                    m_v.f_macdinh_v_nhomdlogin();
                    ads = m_v.f_get_v_nhomdlogin("", "", "", "", "");
                }
                foreach (DataRow r in ads.Tables[0].Select("", "nhom"))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["id"].ToString() + ":?";
                    anode.ImageIndex = (r["nhom"].ToString()=="1" || r["nhom"].ToString()=="2")?0:1;
                    anode.SelectedImageIndex = anode.ImageIndex;
                    treeView1.Nodes.Add(anode);
                    foreach (DataRow r1 in ads1.Tables[0].Select("id_nhom="+r["id"].ToString(),"hoten"))
                    {
                        anode1 = new TreeNode(r1["hoten"].ToString() + " (" + r1["userid"].ToString()+")");
                        anode1.Tag = r["id"].ToString() + ":" + r1["id"].ToString();
                        anode1.ImageIndex = (r["nhom"].ToString() == "1" || r["nhom"].ToString() == "2") ? 2 : 3;
                        anode1.SelectedImageIndex = anode1.ImageIndex;
                        anode.Nodes.Add(anode1);
                    }
                }

                anode = new TreeNode(lan.Change_language_MessageText("Nhóm hệ thống"));
                anode.Tag = "-1:?";
                anode.ImageIndex = 4;
                anode.SelectedImageIndex = 4;
                treeView1.Nodes.Add(anode);
                
                anode1 = new TreeNode(lan.Change_language_MessageText(
"Quản trị cơ sở dữ liệu"));
                anode1.Tag = "-1:-1";
                anode1.ImageIndex = 5;
                anode1.SelectedImageIndex = 5;
                anode.Nodes.Add(anode1);
                
                anode1 = new TreeNode(lan.Change_language_MessageText("Quản trị hệ thống"));
                anode1.Tag = "-1:-2";
                anode1.ImageIndex = 5;
                anode1.SelectedImageIndex = 5;
                anode.Nodes.Add(anode1);
                
                anode1 = new TreeNode(lan.Change_language_MessageText("Quản trị khoa phòng"));
                anode1.Tag = "-1:-3";
                anode1.ImageIndex = 5;
                anode1.SelectedImageIndex = 5;
                anode.Nodes.Add(anode1);
                
                anode1 = new TreeNode(lan.Change_language_MessageText("Nhân viên"));
                anode1.Tag = "-1:-4";
                anode1.ImageIndex = 5;
                anode1.SelectedImageIndex = 5;
                anode.Nodes.Add(anode1);

                treeView1.ExpandAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool f_Chon(string v_menuname)
        {
            bool art = false;
            try
            {
                art = m_dsquyen.Tables[0].Select("menuname='" + v_menuname + "'")[0]["chon"].ToString() == "1";
            }
            catch
            {
                art = false;
            }
            return art;
        }
        private void f_Copy()
        {
            try
            {
                string aid = "", aloai = "N";
                try
                {
                    int i = treeView1.SelectedNode.Parent == null ? 0 : 1;
                    aid = treeView1.SelectedNode.Tag.ToString().Split(':')[i];
                    aloai = treeView1.SelectedNode.Parent == null ? "N" : "U";
                }
                catch
                {
                    aid = "";
                }
                m_id_copy = aid;
                m_loai_copy = aloai;
            }
            catch
            {
            }
            finally
            {
                butPastets.Enabled = m_id_copy != "";
                toolStripMenuItem12.Enabled = butPastets.Enabled;
            }
        }
        private void f_Paste()
        {
            try
            {
                string aid = "", aloai = "N";
                try
                {
                    int i = (treeView1.SelectedNode.Parent == null ? 0 : 1);
                    aid = treeView1.SelectedNode.Tag.ToString().Split(':')[i];
                    aloai = treeView1.SelectedNode.Parent == null ? "N" : "U";
                }
                catch
                {
                    aid = "";
                }
                if (m_id_copy != "" && aid != "")
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý paste quyền cho đối tượng đang chọn!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        m_v.copy_phanquyen(m_id_copy,m_loai_copy,aid,aloai);
                        f_Load_Quyen();
                    }
                }
            }
            catch
            {
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void butThemuser_Click(object sender, EventArgs e)
        {
            try
            {
                string aid_nhom = "";
                try
                {
                    aid_nhom = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                }
                catch
                {
                }
                frmNewuser af = new frmNewuser(m_v,aid_nhom, "",m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
                f_Load_User();
            }
            catch
            {
            }
        }
        private void butThemnhom_Click(object sender, EventArgs e)
        {
            try
            {
                
                frmNewgroup af = new frmNewgroup(m_v, "",m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
                f_Load_User();
            }
            catch
            {
            }
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] == "?")
                {
                    frmNewgroup af = new frmNewgroup(m_v, treeView1.SelectedNode.Tag.ToString().Split(':')[0], m_userid);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_User();
                }
                else
                {
                    frmNewuser af = new frmNewuser(m_v, treeView1.SelectedNode.Tag.ToString().Split(':')[0],treeView1.SelectedNode.Tag.ToString().Split(':')[1],m_userid);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_User();
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
                f_Load_Quyen();
                butQuyen_All.Checked = false;
                toolStripMenuItem13.Checked = false;
                toolStripMenuItem14.Checked = false;
                e.Node.ForeColor = Color.Red;
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
        private void ttUser_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_User();
        }
        private void f_Luu_Quyen()
        {
            ttQuyen_Luu.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            try
            {
                ttProgress.Minimum = 0;
                ttProgress.Value = 0;
                ttProgress.Maximum = m_dsquyen.Tables[0].Rows.Count;
                ttProgress.Visible = true;
                ttStatus.Text = lan.Change_language_MessageText("Đang lưu, xin chờ!");
                statusStrip1.Refresh();
                string aid = "", aloai = "";
                try
                {
                    int i = treeView1.SelectedNode.Parent == null ? 0 : 1;
                    aid = treeView1.SelectedNode.Tag.ToString().Split(':')[i];
                    aloai = treeView1.SelectedNode.Parent == null ? "N" : "U";
                }
                catch
                {
                    aid = "";
                }
                if (aid != "" && aid != "?")
                {
                    if (aloai == "N")
                    {
                        m_v.del_v_phanquyennhom(aid);
                        foreach (DataRow r in m_dsquyen.Tables[0].Rows)
                        {
                            m_v.upd_v_phanquyennhom(decimal.Parse(aid), r["menuname"].ToString(), decimal.Parse(r["chon"].ToString()), r["chitiet"].ToString());
                            ttProgress.Value = ttProgress.Value + 1;
                            statusStrip1.Refresh();
                        }
                    }
                    else
                    {
                        m_v.del_v_phanquyen(aid);
                        foreach (DataRow r in m_dsquyen.Tables[0].Rows)
                        {
                            m_v.upd_v_phanquyen(decimal.Parse(aid), r["menuname"].ToString(), decimal.Parse(r["chon"].ToString()), r["chitiet"].ToString());
                            ttProgress.Value = ttProgress.Value + 1;
                            statusStrip1.Refresh();
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                ttQuyen_Luu.Enabled = true;
                ttProgress.Visible = false;
                ttStatus.Text = lan.Change_language_MessageText("Lưu thành công!");
                this.Cursor = Cursors.Default;
            }
        }
        private void f_Set_Quyen_Chitiet()
        {
            try
            {
                string atmp = "";
                try
                {
                    atmp = m_dsquyen.Tables[0].Select("menuname='" + treeView2.SelectedNode.Tag.ToString() + "'")[0]["chitiet"].ToString().Trim();
                }
                catch
                {
                }
                atmp = atmp.PadRight(6, '0');
                chkThem.Checked = atmp.Substring(0, 1) == "1";
                chkXoa.Checked = atmp.Substring(1, 1) == "1";
                chkSua.Checked = atmp.Substring(2, 1) == "1";
                chkXem.Checked = treeView2.SelectedNode.Checked;
                chkIn.Checked = atmp.Substring(4, 1) == "1";
                chkExport.Checked = atmp.Substring(5, 1) == "1";
            }
            catch
            {
                chkThem.Checked = false;
                chkXoa.Checked = false;
                chkSua.Checked = false;
                chkXem.Checked = false;
                chkIn.Checked = false;
                chkExport.Checked = false;
            }
        }
        private void ttQuyen_Luu_Click(object sender, EventArgs e)
        {
            f_Luu_Quyen();
        }
        private void ttUser_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] == "?")
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá nhóm người dùng: <") + treeView1.SelectedNode.Text+">?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_nhomdlogin(treeView1.SelectedNode.Tag.ToString().Split(':')[0]))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho phép xoá!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá người dùng: <") + treeView1.SelectedNode.Text+">?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (!m_v.del_v_dlogin(treeView1.SelectedNode.Tag.ToString().Split(':')[1]))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho phép xoá!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                try
                {
                    if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                    {
                        f_Chon_Quyen(e.Node, e.Node.Checked);
                    }
                }
                catch
                {
                }

                if (m_dsquyen.Tables[0].Select("menuname='" + e.Node.Tag.ToString() + "'").Length <= 0 && e.Node.Nodes.Count <= 0)
                {
                    DataRow r = m_dsquyen.Tables[0].NewRow();
                    r[0] = 0;
                    r["menuname"] = e.Node.Tag.ToString();
                    r["chon"] = e.Node.Checked ? 1 : 0;
                    r["chitiet"] = "000" + r["chon"].ToString() + "00";
                    m_dsquyen.Tables[0].Rows.Add(r);
                }
                else
                {
                    string atmp = "";
                    DataRow r1 = m_dsquyen.Tables[0].Select("menuname='" + e.Node.Tag.ToString() + "'")[0];
                    if (e.Node.Nodes.Count > 0)
                    {
                        m_dsquyen.Tables[0].Rows.Remove(r1);
                    }
                    else
                    {
                        atmp = r1["chitiet"].ToString().PadRight(6, '0');
                        r1["chon"] = e.Node.Checked ? 1 : 0;
                        r1["chitiet"] = atmp.Substring(0, 3) + r1["chon"].ToString() + atmp.Substring(4);
                    }
                }
            }
            catch
            {
                //lbQuyen.Text = "Chức năng sử dụng";
            }
            //English sua 130707. Do lam cham chuong trinh
            //lbQuyen.Text = lan.Change_language_MessageText("Chức năng sử dụng (") + m_dsquyen.Tables[0].Select("chon=1").Length.ToString() + "/" + m_dsquyen.Tables[0].Rows.Count.ToString() + ")";
            lbQuyen.Text = s_lbQuyen + m_dsquyen.Tables[0].Select("chon=1").Length.ToString() + "/" + m_dsquyen.Tables[0].Rows.Count.ToString() + ")";
            //End English.
            
        }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            f_Set_Quyen_Chitiet();
            e.Node.ForeColor = Color.Red;
        }
        private void butQuyen_All_Click(object sender, EventArgs e)
        {
            ttStatus.Text = "";
            butQuyen_All.Checked = !butQuyen_All.Checked;
            toolStripMenuItem13.Checked = butQuyen_All.Checked;
            butQuyen_All.ToolTipText = butQuyen_All.Checked ? lan.Change_language_MessageText("Bỏ chọn tất cả")+" " : lan.Change_language_MessageText("Chọn tất cả");
            toolStripMenuItem13.Text = butQuyen_All.ToolTipText;
            f_Chon_All();
            f_Set_Quyen_Chitiet();

        }
        private void butCopyts_Click(object sender, EventArgs e)
        {
            f_Copy();
        }
        private void butPastets_Click(object sender, EventArgs e)
        {
            f_Paste();
        }
        private void ttQuyen_Chitiet_Click(object sender, EventArgs e)
        {

        }
        private void ttQuyen_Default_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            try
            {
                ttStatus.Text = "";
                ttProgress.Visible = true;
                ttProgress.Value = 0;
                ttProgress.Maximum = m_dsquyen.Tables[0].Rows.Count;

                toolStripMenuItem14.Checked = !toolStripMenuItem14.Checked;
                f_Chon_Quyen(treeView2.SelectedNode,toolStripMenuItem14.Checked);
                ttProgress.Value = ttProgress.Maximum;
            }
            catch
            {
            }
            finally
            {
                ttProgress.Visible = false;
            }
            f_Set_Quyen_Chitiet();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            treeView2.ExpandAll();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            treeView2.CollapseAll();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                toolStripMenuItem14.Checked = treeView2.SelectedNode.Checked;
                toolStripMenuItem14.Text = toolStripMenuItem14.Checked ?lan.Change_language_MessageText("Bỏ chọn tất cả mục đang chọn") :lan.Change_language_MessageText("Chọn tất cả mục đang chọn");
            }
            catch
            {
            }
        }

        private void chkThem_Click(object sender, EventArgs e)
        {
            try
            {
                string atmp = "";
                atmp += chkThem.Checked?"1":"0";
                atmp += chkXoa.Checked ? "1" : "0";
                atmp += chkSua.Checked ? "1" : "0";
                atmp += chkXem.Checked ? "1" : "0";
                atmp += chkIn.Checked ? "1" : "0";
                atmp += chkExport.Checked ? "1" : "0";
                treeView2.SelectedNode.Checked = chkXem.Checked;
                m_dsquyen.Tables[0].Select("menuname='" + treeView2.SelectedNode.Tag.ToString() + "'")[0]["chitiet"] = atmp;
            }
            catch
            {
            }
        }

        private void chkThem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkThem.ForeColor=chkThem.Checked?Color.ForestGreen:Color.DimGray;
                chkXoa.ForeColor = chkXoa.Checked ? Color.ForestGreen : Color.DimGray;
                chkSua.ForeColor = chkSua.Checked ? Color.ForestGreen : Color.DimGray;
                chkXem.ForeColor = chkXem.Checked ? Color.ForestGreen : Color.DimGray;
                chkIn.ForeColor = chkIn.Checked ? Color.ForestGreen : Color.DimGray;
                chkExport.ForeColor = chkExport.Checked ? Color.ForestGreen : Color.DimGray;
            }
            catch
            {
            }
        }

        private void treeView2_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeView2.SelectedNode.ForeColor = Color.Black;
            }
            catch
            {
            }
        }

        private void ttQuyen_Boqua_Click(object sender, EventArgs e)
        {

        }
    }
}