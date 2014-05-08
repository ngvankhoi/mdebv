using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmRight_BV : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private DataSet ads;
        private AccessData m;
        private string user = "";
        public frmRight_BV(AccessData m_m,TreeNode tn)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m = m_m; if (m.bBogo) tv.GanBogo(this, textBox111);
            treeView1.Nodes.Add(tn);
        }

        private void frmRight_BV_Load(object sender, EventArgs e)
        {
            user = m.user;
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = FormWindowState.Normal;
            try
            {
                ads = m.get_data("select * from " + user + ".m_menuitem order by id");
                int i = int.Parse(ads.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                m.execute_data(" create table " + user + ".m_menuitem(id varchar(20),id_goc varchar(20),stt numeric(5) default 0,id_menu varchar(20),ten text  ,constraint pk_m_menuitem primary key(id)) WITH OIDS;");
                ads = m.get_data("select * from " + user + ".m_menuitem order by id");
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
                        r = m.getrowbyid(ads.Tables[0], "id='" + v_node.Parent.Tag.ToString().PadLeft(3, '0') + "'");
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
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0) f_Set_Right(anode);
                else
                {
                    if (ads.Tables[0].Select("id='" + anode.Tag.ToString() + "'").Length > 0) 
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
                        if (ads.Tables[0].Select("id='" + anode.Tag.ToString() + "'").Length > 0) 
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

        private void butAll_Click(object sender, EventArgs e)
        {
            butAll.Text = butAll.Text == "Chọn cả" ? "Bỏ cả" : "Chọn cả";
            if (butAll.Text == "Chọn cả") f_Set_All(false);
            else f_Set_All(true);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
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
                    r = m.getrowbyid(ads.Tables[0], "id='" + e.Node.Tag.ToString().PadLeft(3, '0') + "'");
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

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            m.execute_data("delete from " + user + ".m_menuitem");
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                m.execute_data("delete from " + user + ".m_menuitem");
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    m.upd_m_menuitem(r["id"].ToString(), r["id_menu"].ToString(), r["id_goc"].ToString(), decimal.Parse(r["stt"].ToString()), r["ten"].ToString());
                }
                foreach (DataRow r1 in m.get_data("select * from medibv.dlogin").Tables[0].Rows)
                {
                    string s = "";
                    foreach (DataRow r2 in m.get_data("select * from medibv.m_menuitem").Tables[0].Rows)
                    {
                        if (r1["right_"].ToString().IndexOf(r2["id_menu"].ToString() + "+") > -1)
                        {
                            s += r2["id_menu"].ToString() + "+";
                        }
                    }
                    m.execute_data("update medibv.dlogin set right_='" + s + "' where id=" + r1["id"].ToString() + "");
                }
                MessageBox.Show(lan.Change_language_MessageText("Lưu thành công"), LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }              
    }
}