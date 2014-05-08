using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmChonvienphi : Form
    {
        Language lan = new Language();
        LibMedi.AccessData m;
        DataTable dtvp=new DataTable();
        DataTable dttam = new DataTable();
        public string s_mavp = "";
        string[] mavp;

        public frmChonvienphi(LibMedi.AccessData _m, DataTable _dtvp,string _mavp )
        {
            InitializeComponent();
            m = _m;
            dtvp = _dtvp;
            s_mavp = _mavp;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            
        }
        private void load_treeview()
        {
            treeView1.Nodes.Clear();
            TreeNode nodenhom = new TreeNode();
            TreeNode nodeloai = new TreeNode();
            TreeNode nodegia = new TreeNode();
            int nhom = 0, loai = 0;
            foreach (DataRow r1 in dtvp.Rows)
            {
                if (nhom != int.Parse(r1["id_nhom"].ToString()))
                {
                    nhom = int.Parse(r1["id_nhom"].ToString());
                    nodenhom = treeView1.Nodes.Add("nhom", r1["nhom"].ToString());
                }
                if (loai != int.Parse(r1["id_loai"].ToString()))
                {
                    loai = int.Parse(r1["id_loai"].ToString());
                    nodeloai = nodenhom.Nodes.Add("loai", r1["loai"].ToString());
                }
                nodegia = nodeloai.Nodes.Add("vp", r1["ten"].ToString());
                nodegia.Tag = r1["id"].ToString().Trim();
            }
            treeView1.ExpandAll();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            NodeTextSearch1();
        }

        private void NodeTextSearch1()
        {
            ClearBackColor1();
            FindByText1();
        }
        private void ClearBackColor1()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearRecursive1(n);
            }
        }
        private void ClearRecursive1(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive1(tn);
            }
        }
        private void FindByText1()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive1(n);
            }
        }
        private void FindRecursive1(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (txtTim.Text.Trim() == "") tn.BackColor = Color.White;
                else if (tn.Text.ToLower().IndexOf(this.txtTim.Text.ToLower().Trim()) != -1)
                    tn.BackColor = Color.Yellow;
                FindRecursive1(tn);
            }
        }

        
        private void f_Get_Right(TreeNode v_node)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    if (anode.Nodes.Count > 0)
                    {
                        f_Get_Right(anode);
                    }
                    else
                    {
                        if (anode.Checked)
                        {
                            s_mavp += anode.Tag.ToString() + ",";
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Set_Right(TreeNode v_node)
        {

            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    if (anode.Nodes.Count > 0)
                    {
                        f_Set_Right(anode);
                    }
                    else
                    {
                        for (int i = 0; i < mavp.Length; i++)
                        {
                            if (anode.Tag.ToString() == mavp[i])
                            {
                                anode.Checked = true;
                                break;
                            }
                            else
                                anode.Checked = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Chon(TreeNode v_node, bool v_bool)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = v_bool;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon(anode, v_bool);
                    }
                }
            }
            catch
            {
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            txtTim.Text = "";
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                {
                    f_Chon(e.Node, e.Node.Checked);
                }
            }
            catch
            {
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChonvienphi_Load(object sender, EventArgs e)
        {
            dttam = dtvp.Copy();
            load_treeview();
            mavp = s_mavp.Split(',');
            foreach (TreeNode anode in treeView1.Nodes)
            {
                anode.Checked = false;
                if (anode.Nodes.Count > 0)
                    f_Set_Right(anode);
                else
                {
                    for (int i = 0; i < mavp.Length; i++)
                    {
                        if (anode.Tag.ToString() == mavp[i])
                        {
                            anode.Checked = true;
                        }
                        else
                        {
                            anode.Checked = false;
                        }
                    }
                }
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            s_mavp = "";
            try
            {
                foreach (TreeNode anode in treeView1.Nodes)
                {
                    if (anode.Nodes.Count > 0)
                    {
                        f_Get_Right(anode);
                    }
                    //if (anode.Checked && anode.Name != "loai" && anode.Name != "nhom")
                    //{
                    //    s_mavp += anode.Tag.ToString() + ",";
                    //}

                }
            }
            catch
            {
            }
        }
    }
}