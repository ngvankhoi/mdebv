using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;

namespace Duoc
{
    public partial class frmRight_BV : Form
    {
        private DataSet ads;
        private AccessData d;
        private string user = "";
        private int i_nhomkho;
        public frmRight_BV(AccessData d_d, TreeNode tn, int s_nhomkho)
        {
            InitializeComponent();
            d = d_d;
            i_nhomkho = s_nhomkho;
            try
            {
                treeView1.Nodes.Add(tn);
            }
            catch
            { 
            }
        }

        private void frmRight_BV_Load(object sender, EventArgs e)
        {
            user = d.user;
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = FormWindowState.Normal;
            try
            {
                ads = d.get_data("select * from " + user + ".d_menuitem order by id");
                int i = int.Parse(ads.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                d.execute_data(" create table " + user + ".d_menuitem(id varchar(5),id_goc varchar(5),stt numeric(5) default 0,id_menu varchar(5),ten text  ,constraint pk_d_menuitem primary key(id)) WITH OIDS;");
                ads = d.get_data("select * from " + user + ".d_menuitem order by id");
            }
            f_Set_Right();
        }
        private void f_Add_Idmenu_Cha(TreeNode v_node)
        {
            DataRow r;
            if (v_node.Parent != null)
            {
                if (ads.Tables[0].Select("id='" + v_node.Parent.Tag.ToString().PadLeft(3, '0') + "'").Length <= 0)
                {
                    r = ads.Tables[0].NewRow();
                    r["id"] = v_node.Parent.Tag.ToString().PadLeft(3, '0');
                    r["id_menu"] = v_node.Parent.Tag.ToString().PadLeft(3, '0');
                    r["ten"] = v_node.Parent.Text;
                    r["stt"] = v_node.Parent.Index;
                    if (v_node.Parent.Parent != null)
                    {
                        if (v_node.Parent.Parent.Tag.ToString() == "menuChucnang")
                        {
                            r["id_goc"] = "-1";
                        }
                        else r["id_goc"] = v_node.Parent.Parent.Tag.ToString().PadLeft(3, '0');
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                if (v_node.Parent != null)
                {
                    f_Add_Idmenu_Cha(v_node.Parent);
                }
            }
        }
        private void f_Remove_Idmenu_Cha(TreeNode v_node)
        {
            DataRow r;
            if (v_node.Parent != null)
            {
                foreach (TreeNode anode in v_node.Parent.Nodes)
                {
                    if (!bCheck_Menu_Con(v_node.Parent))
                    {
                        r = d.getrowbyid(ads.Tables[0], "id='" + v_node.Parent.Tag.ToString().PadLeft(3, '0') + "'");
                        if (r != null) ads.Tables[0].Rows.Remove(r);
                        break;
                    }
                    else break;

                }
                if (v_node.Parent != null)
                {
                    f_Remove_Idmenu_Cha(v_node.Parent);
                }
            }

        }
        private bool bCheck_Menu_Con(TreeNode v_node)
        {
            foreach (TreeNode anode in v_node.Nodes)
            {
                if (anode.Checked)
                {
                    return true;
                }
            }
            return false;
        }
        private void f_Set_Right()
        {
            Application.DoEvents();
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0) f_Set_Right(anode);
                else
                {
                    if (ads.Tables[0].Select("id=" + anode.Tag.ToString()).Length > 0)
                    {
                        anode.Checked = true;
                    }
                }
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
                        if (ads.Tables[0].Select("id='" + anode.Tag.ToString()+"'").Length > 0)
                        {
                            anode.Checked = true;
                        }
                    }
                }
            }
            catch
            {
            }

        }
        private void f_Set_All(bool bAll)
        {
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    f_Chon_Quyen(anode, bAll);
                }
            }
        }
        private void f_Chon_Quyen(TreeNode v_node, bool v_bool)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = v_bool;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode, v_bool);
                    }
                }
            }
            catch
            {
            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            butAll.Text = butAll.Text == "Chọn cả" ? "Bỏ cả" : "Chọn cả";
            if (butAll.Text == "Chọn cả") f_Set_All(false);
            else f_Set_All(true);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                DataRow r;
                if (ads.Tables[0].Select("id='" + e.Node.Tag.ToString().PadLeft(3, '0') + "'").Length <= 0)
                {
                    if (e.Node.Checked)
                    {
                        r = ads.Tables[0].NewRow();
                        r["id"] = e.Node.Tag.ToString().PadLeft(3, '0');
                        r["id_menu"] = e.Node.Tag.ToString().PadLeft(3, '0');
                        r["ten"] = e.Node.Text;
                        r["stt"] = e.Node.Index;
                        if (e.Node.Parent != null)
                        {
                            if (e.Node.Parent.Tag.ToString() == "menuChucnang")
                            {
                                r["id_goc"] = "-1";
                            }
                            else
                            {
                                r["id_goc"] = e.Node.Parent.Tag.ToString().PadLeft(3, '0');
                            }
                        }
                        ads.Tables[0].Rows.Add(r);
                    }
                }
                else
                {
                    if (!e.Node.Checked)
                    {
                        r = d.getrowbyid(ads.Tables[0], "id='" + e.Node.Tag.ToString().PadLeft(3, '0') + "'");
                        if (r != null)
                        {
                            ads.Tables[0].Rows.Remove(r);
                        }
                    }

                }

                try
                {
                    if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                    {
                        f_Chon_Quyen(e.Node, e.Node.Checked);
                        if (e.Node.Checked)
                        {
                            f_Add_Idmenu_Cha(e.Node);
                        }
                        else
                        {
                            f_Remove_Idmenu_Cha(e.Node);

                        }
                    }
                }
                catch
                {
                }
            }
            catch
            { 
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            d.close();this.Close();
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            d.execute_data("delete from " + user + ".d_menuitem");
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                d.execute_data("delete from " + user + ".d_menuitem");
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    d.upd_d_menuitem(r["id"].ToString(), r["id_menu"].ToString(), r["id_goc"].ToString(), decimal.Parse(r["stt"].ToString()), r["ten"].ToString());
                }
                foreach (DataRow r1 in d.get_data("select * from medibv.d_dlogin where nhomkho=" + i_nhomkho).Tables[0].Rows) 
                {
                    string s = "";
                    foreach (DataRow r2 in d.get_data("select * from medibv.d_menuitem").Tables[0].Rows)
                    {
                        if (r1["right_"].ToString().IndexOf(r2["id_menu"].ToString() + "+") > -1)
                        {
                            s += r2["id_menu"].ToString() + "+";
                        }
                    }
                    d.execute_data("update medibv.d_dlogin set right_='" + s + "' where id=" + r1["id"].ToString() + " and nhomkho=" + i_nhomkho + "");
                }
                //MessageBox.Show(lan.Change_language_MessageText("Lưu thành công", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
                butKetthuc.Focus();
            }
            catch
            { 
            }
        }              
    }
}