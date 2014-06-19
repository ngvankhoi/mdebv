using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmKhaibaoKP_theogiaV : Form
    {
        private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();

        private DataTable dtkhoa = new DataTable();
        private DataTable dt = new DataTable();
        //private DataTable dt_K = new DataTable();

        private string s_khoa;
        private int i_id;
        //private bool flag;
        public frmKhaibaoKP_theogiaV()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v.f_SetEvent(this);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void frmKhaibaoKP_theogiaV_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            try
            {
                int i = int.Parse(m_v.get_data("select id from medibv.v_nhomkhoabv1ll limit 1").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                m_v.execute_data("CREATE TABLE medibv.v_nhomkhoabv1ll(id numeric(3) NOT NULL DEFAULT 0,ma varchar(10),ten text,  stt numeric(3) DEFAULT 0,mavp text,ngayud timestamp DEFAULT now(), CONSTRAINT pk_v_nhomkhoabv1ll PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS;");
                m_v.execute_data("CREATE TABLE medibv.v_nhomkhoabv1ct(id numeric(3) NOT NULL DEFAULT 0,mavp varchar(10),tenvp text,CONSTRAINT pk_v_nhomkhoabv1ct PRIMARY KEY (id,mavp) USING INDEX TABLESPACE medi_index) ");
                m_v.execute_data("alter table medibv.v_nhomkhoabv1ll rename column makp to mavp");
            }
            load_grid();
            AddGridTableStyle();
            f_Load_Tree();
            //dt_K = m_v.get_data("select mavp from medibv.v_nhomkhoabv1ll order by stt").Tables[0];
            butMoi_Click(null, null);

            ref_text();
        }
        private void f_Load_Tree()
        {
            treeView1.Nodes.Clear();
            TreeNode anode, anode1;
            DataSet adsloai, adsgia;

            adsgia = m_v.f_get_v_giavp_frmgiavp();
            adsloai = m_v.f_get_v_loaivp_frmgiavp();
            foreach (DataRow r in adsloai.Tables[0].Rows)
            {
                anode = new TreeNode(r["ten"].ToString());
                anode.Tag = r["id"].ToString() + ":?";
                treeView1.Nodes.Add(anode);
                foreach (DataRow r1 in adsgia.Tables[0].Select("id_loai="+r["id"].ToString()))
                {
                    anode1 = new TreeNode(r1["ten"].ToString());
                    anode1.Tag = r1["id"].ToString();
                    anode.Nodes.Add(anode1);
                    //treeView1.SelectedNode = anode1;
                }
            }
            //treeView1.ExpandAll();
            
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
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "STT";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã";
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Nội dung";
            TextCol.Width = 280;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mavp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);    
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            //flag = true;
            try
            {
                txtStt.Value = decimal.Parse(m_v.get_data("select max(stt) from medibv.v_nhomkhoabv1ll").Tables[0].Rows[0][0].ToString()) + 1;
            }
            catch
            {
                txtStt.Value = 1; 
            }
            i_id = 0;
            txtMa.Text = "";
            txtTen.Text = "";
            txtRight.Text = "";
            f_Set_All(false);
            ena_object(true);
            txtStt.Focus();
        }
        private bool kiemtra()
        {
            if (txtMa.Text == "")
            {
                txtMa.Focus();
                return false;
            }
            if (txtTen.Text == "")
            {
                txtTen.Focus();
                return false;
            }
            s_khoa = "";
            f_Get_Right();
            return true;
        }
        private void ena_object(bool ena)
        {
            dataGrid1.Enabled = !ena;
            treeView1.Enabled = ena;          
            txtStt.Enabled = ena;
            txtMa.Enabled = ena;
            txtTen.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butXoa.Enabled = !ena;
            butKetthuc.Enabled = !ena;
        }
        private void txtStt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            if (!kiemtra()) return;

            if (i_id == 0)
            {
                try
                {
                    i_id = int.Parse(m_v.get_data("select max(id) from medibv.v_nhomkhoabv1ll").Tables[0].Rows[0][0].ToString()) + 1;
                }
                catch 
                {
                    i_id = 1; 
                }
            }

            foreach (DataRow r in dt.Rows)
            {
                if (i_id != 0 && txtTen.Text != "")
                {
                    if (r["mavp"].ToString().Equals(s_khoa))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nội dung đã chọn ! "), m_v.s_AppName);
                        return;
                    }
                }
            }           
            
            if (!m_v.upd_v_nhomkhoabv1ll(i_id, txtMa.Text, txtTen.Text, int.Parse(txtStt.Value.ToString()), s_khoa))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin !"), m_v.s_AppName);
                return;
            }
            f_Get_Right1(i_id);            
            
            load_grid();
            ena_object(false);
            ref_text();
        }
        private void ref_text()
        {
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                txtStt.Value = decimal.Parse(dataGrid1[i, 0].ToString());
                txtMa.Text = dataGrid1[i, 1].ToString();
                txtTen.Text = dataGrid1[i, 2].ToString();
                txtRight.Text = dataGrid1[i, 4].ToString();
                f_Set_Right();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void f_Set_Right()
        {
            try
            {
                foreach (TreeNode anode in treeView1.Nodes)
                {
                    if (anode.Nodes.Count > 0) f_Set_Right(anode);
                    else
                    {
                        if (txtRight.Text.Trim().IndexOf(anode.Tag.ToString() + "+") != -1)
                        {
                            anode.Checked = true;
                        }
                        else anode.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void f_Set_Right(TreeNode v_node)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    if (anode.Nodes.Count > 0) f_Set_Right(anode);
                    else
                    {
                        if (txtRight.Text.Trim().IndexOf(anode.Tag.ToString() + "+") != -1)
                        {
                            anode.Checked = true;
                        }
                        else anode.Checked = false;
                    }
                }
            }
            catch
            {
            }
        }

        private void load_grid()
        {
            dt = m_v.get_data("select * from medibv.v_nhomkhoabv1ll order by stt").Tables[0];
            dataGrid1.DataSource = dt;
        }

        private void txtMa_Validated(object sender, EventArgs e)
        {
            if (txtMa.Text != "")
            {
                DataRow r1 = m_v.getrowbyid(dt, "ma='" + txtMa.Text + "'");
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã này đã nhập !"), m_v.s_AppName);
                    txtMa.Focus();
                    return;
                }
                if (txtTen.Text == "") txtTen.Text = txtMa.Text;
            }
        }

        private void txtTen_Validated(object sender, EventArgs e)
        {
            if (i_id == 0 && txtTen.Text != "")
            {
                DataRow r1 = m_v.getrowbyid(dt, "ten='" + txtTen.Text + "'");
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nội dung đã nhập !"), m_v.s_AppName);
                    txtTen.Focus();
                }
            }
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            //flag = false;
            if (dt.Rows.Count == 0) return;
            i_id = int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString());
            ena_object(true);
            txtStt.Focus();
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy !"), m_v.s_AppName);
                return;
            }
            if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_v.execute_data("delete from medibv.v_nhomkhoabv1ll where id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString()));
                m_v.execute_data("delete from medibv.v_nhomkhoabv1ct where id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString()));
                load_grid();
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();

        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ref_text();
            ena_object(false);

        }
        private void f_Get_Right()
        {
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
                            s_khoa += anode.Tag.ToString() + "+";
                        }
                    }
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
                treeView1.SelectedNode.ForeColor = Color.Red;
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.ForeColor = Color.Red;
                }
                if (treeView1.SelectedNode.Parent.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Parent.ForeColor = Color.Red;
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
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.ForeColor = Color.Black;
                }
                if (treeView1.SelectedNode.Parent.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Parent.ForeColor = Color.Black;
                }
            }
            catch
            {
            }
        }

        private void f_Get_Right1(int aid)
        {
            foreach (TreeNode anode in treeView1.Nodes)
            {
                if (anode.Nodes.Count > 0)
                {
                    f_Get_Right1(anode,aid);
                }
            }
        }
        private void f_Get_Right1(TreeNode v_node,int aid)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    if (anode.Nodes.Count > 0)
                    {
                        f_Get_Right1(anode,aid);
                    }
                    else
                    {
                        if (anode.Checked)
                        {
                            m_v.upd_v_nhomkhoabv1ct(i_id,anode.Tag.ToString(),anode.Text.Trim());
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

        private void txtRight_Validating(object sender, CancelEventArgs e)
        {
            if (i_id != 0 && txtTen.Text != "")
            {
                DataRow r1 = m_v.getrowbyid(dt, "mavp='" + txtRight.Text + "'");
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nội dung đã chọn !"), m_v.s_AppName);
                    txtTen.Focus();
                }
            }
        }

        private void txtRight_Validated(object sender, EventArgs e)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (i_id != 0 && txtTen.Text != "")
                {
                    if (r["mavp"].ToString().Trim().IndexOf("+").Equals(s_khoa.Trim().IndexOf("+")))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nội dung đã chọn ! "), m_v.s_AppName);
                        return;
                    }
                }
            } 
        }

    }
}