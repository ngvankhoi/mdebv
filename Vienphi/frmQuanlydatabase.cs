using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmQuanlydatabase : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid = "";
        public frmQuanlydatabase(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m_v = v_v;
            m_userid = v_userid;
        }

        private void frmQuanlydatabase_Load(object sender, EventArgs e)
        {
            f_Visible_ToolStrip2();
            m_v.upd_table();
            f_Load_Tree();
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_Load_Tree()
        {
            try
            {
                treeView1.Nodes.Clear();
                ttDB_lbDatabase.Text = ""+m_v.s_database;
                string aschema = "";
                TreeNode anode=null, anode1=null;
                foreach (DataRow r in m_v.f_get_sys_schema().Tables[0].Rows)
                {
                    if (aschema != r["schemaname"].ToString())
                    {
                        aschema = r["schemaname"].ToString();
                        anode = new TreeNode(r["schemaname"].ToString());
                        anode.Tag = r["schemaname"].ToString();
                        anode.ImageIndex = 0;
                        anode.SelectedImageIndex = 1;
                        treeView1.Nodes.Add(anode);
                    }
                    anode1 = new TreeNode(r["tablename"].ToString());
                    anode1.Tag = r["tablename"].ToString();
                    anode1.ImageIndex = 2;
                    anode.Nodes.Add(anode1);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_DG()
        {
            string aschemaname = "", atablename = "";
            try
            {
                if (treeView1.SelectedNode.Parent == null)
                {
                    aschemaname = treeView1.SelectedNode.Tag.ToString().Trim();
                    atablename = "";
                }
                else
                {
                    aschemaname = treeView1.SelectedNode.Parent.Tag.ToString();
                    atablename = treeView1.SelectedNode.Tag.ToString();
                }
            }
            catch
            {
            }
            try
            {
                DataSet ads = m_v.f_get_sys_table_structure(aschemaname, atablename);
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = ads.Tables[0];
                dataGridView1.Columns[dataGridView1.Columns.Count-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                toolStrip_DGTitle.Text = ads.Tables[0].Rows.Count.ToString();
            }
            catch
            {
                toolStrip_DGTitle.Text = "";
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            f_Load_DG();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_Tree();
        }
        private void butF5_Click(object sender, EventArgs e)
        {
            try
            {                            
                if (m_v.is_dba_admin(m_userid) || m_userid == LibVP.AccessData.s_links_userid)
                {
                    string sql = txtSQL.Text.Trim();
                    if (txtSQL.SelectedText.Trim().Length > 0)
                    {
                        sql = txtSQL.SelectedText.Trim();
                    }
                    DataSet ads = m_v.get_data(sql);
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = ads.Tables[0];
                    dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    toolStrip_DGTitle.Text = ads.Tables[0].Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chỉ nhân viên thuộc nhóm Quản trị cơ sở dữ liệu mới được phép!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                toolStrip_DGTitle.Text = "";
                MessageBox.Show(ex.ToString());
            }
        }

        private void butExcel_Click(object sender, EventArgs e)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                string afile = "";
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Filter = "Microsoft Excel Document|.xls";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.ShowDialog();
                afile=saveFileDialog1.FileName;
                if (afile != "")
                {
                    if (afile.ToLower().LastIndexOf(".xls") != afile.Length - 4)
                    {
                        afile = afile + ".xls";
                    }
                }
                if (afile!= "")
                {
                    if (System.IO.File.Exists(afile))
                    {
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Đã tồn tại:")+ "\n" + afile +"\n" +lan.Change_language_MessageText("Đồng ý lưu?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            saveFileDialog1.ShowDialog();
                            return;
                        }
                    }
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    DataSet ads = new DataSet();
                    ads.Tables.Add(dv.Table.Copy());
                    m_v.f_export_excel(ads.Tables[0],afile);
                }
                saveFileDialog1.Dispose();
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }

        private void butXML_Click(object sender, EventArgs e)
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                string afile = "";
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Filter = "Microsoft XML Document|.xml";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.ShowDialog();
                afile = saveFileDialog1.FileName;
                if (afile != "")
                {
                    if (afile.ToLower().LastIndexOf(".xml") != afile.Length - 4)
                    {
                        afile = afile + ".xml";
                    }
                }
                if (afile != "")
                {
                    if (System.IO.File.Exists(afile))
                    {
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Đã tồn tại:")+"\n" + afile +"\n"+ lan.Change_language_MessageText("Đồng ý lưu?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            saveFileDialog1.ShowDialog();
                            return;
                        }
                    }
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    DataSet ads = new DataSet();
                    ads.Tables.Add(dv.Table.Copy());
                    ads.WriteXml(afile,XmlWriteMode.WriteSchema);
                }
                saveFileDialog1.Dispose();
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }

        private void butThemuser_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.is_dba_admin(m_userid))
                {
                    frmNewdatabase af = new frmNewdatabase(m_v, m_userid);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);

                    f_Load_Tree();
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chỉ nhân viên thuộc nhóm Quản trị cơ sở dữ liệu mới được phép!"), m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void butSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.is_dba_admin(m_userid) || LibVP.AccessData.s_links_userid==m_userid)
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật cấu trúc cơ sở dữ liệu và nội dung của nó!"), lan.Change_language_MessageText(m_v.s_AppName), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        ttStatus.Text = lan.Change_language_MessageText("Đang cập nhât, xin chờ ...");
                        butSua.Enabled = false;
                        this.Update();
                        
                        m_v.create_tables_vp();
                        
                        m_v.modify_tables_vp();
                        m_v.f_create_v_optionhotkey();
                        m_v.f_create_v_optionhotkey_ksk();
                        m_v.f_create_v_optionlien();
                        f_Load_Tree();
                        f_Load_Tree();
                        ttStatus.Text = lan.Change_language_MessageText("Cập nhật xong!");
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chỉ nhân viên thuộc nhóm Quản trị cơ sở dữ liệu mới được phép!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                ttStatus.Text = lan.Change_language_MessageText(
"Cập nhật xong!");
                butSua.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
        }

        private void butSQL_Click(object sender, EventArgs e)
        {
            butSQL.Checked = !butSQL.Checked;
            f_Visible_ToolStrip2();
        }
        private void f_Visible_ToolStrip2()
        {
            panel2.Visible = butSQL.Checked;
            splitter1.Visible = butSQL.Checked;
            if (panel2.Visible)
            {
                splitter1.SendToBack();
                panel2.SendToBack();
            }
            else
            {
            }
        }

        private void toolStripXoacautruc_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.is_dba_admin(m_userid))
                {
                    if (treeView1.SelectedNode.Parent == null)
                    {
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá cấu trúc cơ sở dữ liệu (schema) <") + treeView1.SelectedNode.Text + "> và nội dung của nó!", "Thóng báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            m_v.drop_schema(treeView1.SelectedNode.Text.ToString());
                            f_Load_Tree();
                        }
                    }
                    else if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Parent == null)
                    {
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá cấu trúc bảng(table) <") + treeView1.SelectedNode.Text + "> và nội dung của nó!", "Thóng báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            m_v.drop_table(treeView1.SelectedNode.Parent.Text.ToString(), treeView1.SelectedNode.Text.ToString());
                            f_Load_Tree();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chỉ nhân viên thuộc nhóm Quản trị cơ sở dữ liệu mới được phép!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void butF6_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.is_dba_admin(m_userid) || m_userid == LibVP.AccessData.s_links_userid)
                {
                    string sql = txtSQL.Text.Trim();
                    if (txtSQL.SelectedText.Trim().Length > 0)
                    {
                        sql = txtSQL.SelectedText.Trim();
                    }
                    if (sql != "")
                    {
                        m_v.execute_data(sql);
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chỉ nhân viên thuộc nhóm Quản trị cơ sở dữ liệu mới được phép!"), m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void txtSQL_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    butF5_Click(null, null);
                }
                else
                if (e.KeyCode == Keys.F6)
                {
                    butF6_Click(null, null);
                }
            }
            catch
            {
            }
        }
    }
}