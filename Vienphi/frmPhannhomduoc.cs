using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmPhannhomduoc : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_loaikho="",m_nhomvp="";
        public frmPhannhomduoc(LibVP.AccessData v_v, string v_userid)
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
            f_Load_Tree();
            ttStatus.Text = "";
        }
        private void f_Load_Tree()
        {
            try
            {
                DataSet ads_nhombhyt = m_v.f_get_v_nhombhyt("", "", "", "", "");
                DataSet ads_nhomvp = m_v.f_get_v_nhomvp("","","","", "", "", "");
                DataSet ads_nhomduoc = m_v.f_get_d_dmnhom_frmphannhomduoc();


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
                if (ads_nhomduoc.Tables[0].Select("nhomvp=-999").Length>0)
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

                cbLoaikho.DisplayMember = "ten";
                cbLoaikho.ValueMember = "id";
                cbLoaikho.DataSource = m_v.f_get_d_loaikho_frmphannhomduoc().Tables[0];
                if (m_loaikho != "")
                {
                    try
                    {
                        cbLoaikho.SelectedValue = m_loaikho;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        cbLoaikho.SelectedValue = "1";
                    }
                    catch
                    {
                    }
                }

                cbNhomvp.DisplayMember = "ten";
                cbNhomvp.ValueMember = "ma";
                cbNhomvp.DataSource = ads_nhomvp.Tables[0];
                if (m_nhomvp != "")
                {
                    try
                    {
                        cbNhomvp.SelectedValue = m_nhomvp;
                    }
                    catch
                    {
                    }
                }

                dataGridView1.DataSource = ads_nhomduoc.Tables[0];
                toolStrip_Tim_TextChanged(null, null);
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
            f_Load_Tree();
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataRowView r = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                cbNhomvp.SelectedValue = r["nhomvp"].ToString();
            }
            catch
            {
                cbNhomvp.SelectedIndex = -1;
            }
        }
        private void toolStrip_Tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "", aid_nhombhyt = "", aid_nhomvp = "",anhom="";
                if (toolStrip_Tim.Text != "")
                {
                    aft = "(ten like '%" + toolStrip_Tim.Text.Replace("'","''") + "%')";
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
                try
                {
                    anhom = int.Parse(cbLoaikho.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    anhom = "";
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
                    aft += "nhomvp=" + aid_nhomvp;
                }
                if (anhom != "")
                {
                    if (aft != "")
                    {
                        aft += " and ";
                    }
                    aft += "nhom=" + anhom;
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                toolStrip_Title.Text = "Danh sách nhóm dược (" + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                toolStrip_Title.Text = "Danh sách nhóm dược"+" ";
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
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = Color.Red;
                toolStrip_Tim_TextChanged(null, null);
                if (e.Node.Tag.ToString() == "-999:-999")
                {
                    ttHint.Text = e.Node.Text.ToString();
                }
                else
                if (e.Node.Tag.ToString() == "-1:-1")
                {
                    ttHint.Text = e.Node.Text.ToString();
                }
                else
                {
                    ttHint.Text = (e.Node.Parent == null) ? lan.Change_language_MessageText("Nhóm viện phí BHYT") : lan.Change_language_MessageText("Nhóm viện phí");
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
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void cbLoaikho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                toolStrip_Tim_TextChanged(null, null);
            }
            catch
            {
            }
        }

        private void butSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý lưu nhóm viện phí tượng ứng với nhóm dược?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    DataRowView r = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                    m_v.f_set_d_dmnhom_nhomvp_frmphannhomduoc(r["id"].ToString(),cbNhomvp.SelectedValue.ToString());
                    m_loaikho = cbLoaikho.SelectedValue.ToString();
                    m_nhomvp = cbNhomvp.SelectedValue.ToString();
                    f_Load_Tree();
                }
            }
            catch
            {
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1_CurrentCellChanged(null, null);
        }
    }
}