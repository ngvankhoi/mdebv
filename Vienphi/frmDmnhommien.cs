using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDmnhommien : Form
    {
        LibVP.AccessData v = new LibVP.AccessData();
        Language lan = new Language();
        string sql = "", strRight = "", s_tam = "", s_msg = "";
        bool bMoi = false;
        int id = 0;
        DataTable dt=new DataTable();
        DataTable dtloaivp = new DataTable();

        public frmDmnhommien()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDmnhommien_Load(object sender, EventArgs e)
        {
            sql = "select distinct a.id,a.ten,a.id_nhom,b.ten tennhom from " + v.user + ".v_loaivp a, " + v.user + ".v_nhomvp b where a.id_nhom=b.ma order by b.ten,a.ten ";
            dtloaivp = v.get_data(sql).Tables[0];

            sql = "select * from "+v.user+".v_nhommien";
            dt = v.get_data(sql).Tables[0];
            dataGrid3.DataSource = dt;
            AddGridTableStyle();

            load_treeview();
            f_Enable(false);
        }

        private void load_treeview()
        {
            treeView1.Nodes.Clear();
            TreeNode nodenhom = new TreeNode();
            TreeNode nodeloai = new TreeNode();
            int nhom = 0;
            foreach (DataRow r1 in dtloaivp.Select("","id_nhom"))// .Rows)
            {
                if (nhom != int.Parse(r1["id_nhom"].ToString()))
                {
                    nhom = int.Parse(r1["id_nhom"].ToString());
                    nodenhom = treeView1.Nodes.Add(r1["id_nhom"].ToString(), v.getrowbyid(dtloaivp, "id_nhom=" + nhom)["tennhom"].ToString());
                }
                
                nodeloai = nodenhom.Nodes.Add(r1["id"].ToString(), r1["ten"].ToString());
                nodeloai.Tag = r1["id"].ToString().Trim();
            }
            treeView1.ExpandAll();
        }
        private void f_Get_Right()
        {
            strRight = "+";
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    f_Get_Right(anode);
                }
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
                            strRight += anode.Tag.ToString() + "+";
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Set_Right()
        {
            
            foreach (TreeNode anode in treeView1.Nodes)
            {
                anode.Checked = false;
                if (anode.Nodes.Count > 0)
                    f_Set_Right(anode);
                else
                {
                    if (strRight.IndexOf("+" + anode.Tag.ToString() + "+") != -1)
                    {
                        anode.Checked = true;
                    }
                    else
                        anode.Checked = false;
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
                        if (strRight.IndexOf("+" + anode.Tag.ToString() + "+") != -1)
                        {
                            anode.Checked = true;
                        }
                        else
                            anode.Checked = false;
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Enable(bool v_bool)
        {
            butMoi.Enabled = !v_bool;
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool ;
            butXoa.Enabled = !v_bool ;
            butBoqua.Enabled = v_bool;
            chkSudung.Enabled = v_bool;
            txtTen.Enabled = v_bool;
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            txtTen.Text = "";
            clearNode();
            f_Enable(true);
            bMoi = true;
        }
        private void clearNode()
        {
            f_Set_All(false);
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            DataTable dttam = new DataTable();
            f_Get_Right();
            if (!kiemtratrung(dt,strRight,id))
            {
                return;
            }
            sql = "select max(id)+1 from "+v.user+".v_nhommien";
            dttam = v.get_data(sql).Tables[0];
            if (bMoi)
            {
                if (dttam.Rows[0][0].ToString().Trim() == "")
                {
                    id = 1;
                }
                else
                    id = int.Parse(dttam.Rows[0][0].ToString());
            }
            else
            {
                sql = "select * from " + v.user + ".v_km_nhommien where id_nhommien=" + id;
                if (v.get_data(sql).Tables[0].Rows.Count > 0 && s_tam!=strRight)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhóm miễn này đã được sử dụng, không thể sửa!"), v.s_AppName);
                    return;
                }
            }
            if (!v.upd_v_nhommien(id, txtTen.Text.Trim(), strRight,chkSudung.Checked?1:0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin nhóm miễn"), v.s_AppName);
                return;
            }
            bMoi = false;
            f_Enable(false);
            load_grid();
            dataGrid3_CurrentCellChanged(null, null);
        }

        private void f_Set_All(bool bAll)
        {
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    anode.Checked = bAll;
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

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
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
        }

        private void AddGridTableStyle()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "id";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Nhóm miễn giảm";
            TextCol.Width = 350;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loaivp";
            TextCol.HeaderText = "loaivp";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sudung";
            TextCol.HeaderText = "Sử dụng";
            TextCol.Width = 50;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

        }

        private void dataGrid3_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGrid3.CurrentCell.RowNumber;
                txtTen.Text = dataGrid3[i, 1].ToString();
                strRight = dataGrid3[i, 2].ToString();
                s_tam = strRight;
                id = int.Parse(dataGrid3[i, 0].ToString());
                chkSudung.Checked = int.Parse(dataGrid3[i, 3].ToString())==1?true:false;
                f_Set_Right();
            }
            catch {
                txtTen.Text = "";
                strRight = "";
                f_Set_All(false);
            }
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            

            f_Enable(true);
            bMoi = false;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_Enable(false);
            bMoi = false;
            dataGrid3_CurrentCellChanged(null, null);
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select * from " + v.user + ".v_tyleduyetmien where id_nhommien=" + id;
                if (v.get_data(sql).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin nhóm miễn này đã được sử dụng, không thể xóa"), v.s_AppName);
                    return;
                }
                if (MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn xóa thông tin nhóm miễn này?"), v.s_AppName, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    sql = "delete from " + v.user + ".v_nhommien where id=" + id;
                    v.execute_data(sql);
                    load_grid();
                    dataGrid3_CurrentCellChanged(null, null);
                }
            }
            catch { }
        }
        private void load_grid()
        {
            sql = "select * from " + v.user + ".v_nhommien";
            dt = v.get_data(sql).Tables[0];
            dataGrid3.DataSource = dt;
        }

        private bool kiemtratrung(DataTable _dt,string _loaivp, int _id)
        {
            string [] s_tam = _loaivp.Trim('+').Split('+');
            try
            {
                foreach (DataRow r in dt.Rows)
                {
                    if ((int.Parse(r["id"].ToString()) != _id) && int.Parse(r["sudung"].ToString())==1 && chkSudung.Checked)
                    {
                        for (int i = 0; i < s_tam.Length; i++)
                        {
                            if (r["loaivp"].ToString().IndexOf("+" + s_tam[i] + "+") != -1)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Dịch vụ '" + v.getrowbyid(dtloaivp, "id=" + s_tam[i])["ten"].ToString() + "' đã được chọn trong nhóm '" + r["ten"].ToString() + "'"), v.s_AppName);
                                return false;
                            }
                        }
                    }
                }
            }
            catch {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin nhóm miễn"), v.s_AppName);
                return false;
            }
            return true;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // MessageBox.Show(strRight);
        }
    }
}