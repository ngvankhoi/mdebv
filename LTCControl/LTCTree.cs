using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LTCControl
{
    public partial class LTCTree : UserControl
    {
        public DataSet m_ds;

        public LTCTree()
        {
            InitializeComponent();
        }

        private void LTCTree_Load(object sender, EventArgs e)
        {

        }

        public void f_set_ds(DataSet v_ds, decimal v_cap)
        {
            try
            {
                m_ds = v_ds;
                f_load_tree(v_cap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void f_load_tree(decimal v_cap)
        {
            try
            {
                TreeNode anode,anode1,anode2;
                if (v_cap == 0)
                {
                    foreach (DataRow r in m_ds.Tables[0].Select("id_cha='0'", "ten"))
                    {
                        anode = new TreeNode();
                        anode.Tag = r["id"].ToString();
                        anode.Text = r["ten"].ToString();
                        //anode.ImageIndex = 0;
                        //anode.SelectedImageIndex = 1;
                        f_add_node(anode, m_ds, r);
                        treeData.Nodes.Add(anode);
                    }
                }
                else
                {
                    string aidt1 = "",aidt1_="";
                    anode = new TreeNode();
                    foreach (DataRow r in m_ds.Tables[0].Select("","ten1,id1"))
                    {
                        if (r["id1"].ToString() != aidt1)
                        {
                            if (aidt1 != "")
                            {
                                treeData.Nodes.Add(anode);
                            }
                            aidt1 = r["id1"].ToString();

                            anode = new TreeNode();
                            anode.Tag = r["id1"].ToString();
                            anode.Text = r["ten1"].ToString();
                        }
                        if (v_cap == 2)
                        {
                            if (r["id1"].ToString() == aidt1)
                            {
                                anode1 = new TreeNode();
                                anode1.Tag = r["id2"].ToString();
                                anode1.Text = r["ten2"].ToString();
                                anode.Nodes.Add(anode1);
                            }
                        }
                        aidt1_ = r["id1"].ToString();
                    }
                    treeData.Nodes.Add(anode);

                }
                treeData.CheckBoxes = true;
                treeData.ExpandAll();
            }
            catch
            {
            }
        }
        private void f_add_node(TreeNode v_node, DataSet v_ds, DataRow v_r)
        {
            try
            {
                TreeNode anode;
                foreach (DataRow r in v_ds.Tables[0].Select("id_cha='" + v_r["id"].ToString() + "'", "stt"))
                {
                    anode = new TreeNode();
                    anode.Tag = r["id"].ToString();
                    anode.Text = r["ten"].ToString();
                    if (v_ds.Tables[0].Select("id_cha='" + r["id"].ToString() + "'").Length > 0)
                    {
                        //anode.ImageIndex = 0;
                        //anode.SelectedImageIndex = 1;
                        f_add_node(anode, v_ds, r);
                    }
                    else
                    {
                        //anode.ImageIndex = 4;
                        //anode.SelectedImageIndex = 5;
                    }
                    v_node.Nodes.Add(anode);
                }
            }
            catch
            {
            }
        }

        public string f_get_check(decimal v_cap)
        {
            string art = "";
            try
            {
                foreach (TreeNode anode in treeData.Nodes)
                {
                    if (v_cap == 1)
                    {
                        if (anode.Checked)
                        {
                            if (art != "")
                            {
                                art += ",";
                            }
                            art += anode.Tag.ToString();
                        }
                    }
                    if (v_cap == 2)
                    {
                        foreach (TreeNode anode1 in anode.Nodes)
                        {
                            if (anode1.Checked)
                            {
                                if (art != "")
                                {
                                    art += ",";
                                }
                                art += anode1.Tag.ToString();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return art;
        }

        private string f_build_filter()
        {
            string afilter = "";
            string aval = txtFilter.Text.Replace("'", "''");
            try
            {

            }
            catch
            {
            }
            return afilter;
        }

        private void treeData_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                f_check(e.Node);
            }
            catch
            {
            }
        }
        private void f_check(TreeNode v_node)
        {
            try
            {

                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = v_node.Checked;
                    if (anode.Nodes.Count > 0)
                    {
                        f_check(anode);
                    }
                }
            }
            catch
            {
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach(TreeNode anode in treeData.Nodes)
                {
                    anode.Checked = chkAll.Checked;
                }
            }
            catch
            {
            }
        }
    }
}
