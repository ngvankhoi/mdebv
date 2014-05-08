using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmCapnhatgiavp : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m_v;        
        private DataSet m_dsgiavp;
        private string m_userid = "";
        int itablell;
        public frmCapnhatgiavp(LibVP.AccessData v_v, string v_userid)
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

            itablell= m_v.tableid("", "v_giavp");
            f_Load_DG();
            f_Set_Fullgrid();
            f_Load_Tree();
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_Load_DG()
        {
            try
            {
                string sql = "select a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt,a.id,a.id_loai,b.id_nhom from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id order by a.stt,a.ten";
                m_dsgiavp = m_v.get_data(sql);
                dataGridView1.DataSource = m_dsgiavp.Tables[0];
                txtTim_TextChanged(null, null);
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_Tree()
        {
            try
            {
                treeView1.Nodes.Clear();
                TreeNode anode, anode1;
                DataSet adsloai, adsnhom;
                string asort = "ten";
                asort = "stt";
                anode = new TreeNode(lan.Change_language_MessageText("Tất cả"));
                anode.Tag = "?:?";
                anode.ImageIndex = 2;
                anode.SelectedImageIndex = 2;
                treeView1.Nodes.Add(anode);

                adsnhom = m_v.f_get_v_nhomvp_frmgiavp();
                adsloai = m_v.f_get_v_loaivp_frmgiavp();
                foreach (DataRow r in adsnhom.Tables[0].Select("",asort))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["ma"].ToString() + ":?";
                    anode.ImageIndex = 0;
                    anode.SelectedImageIndex = 0;
                    treeView1.Nodes.Add(anode);
                    foreach (DataRow r1 in adsloai.Tables[0].Select("id_nhom=" + r["ma"].ToString(),asort))
                    {
                        anode1 = new TreeNode(r1["ten"].ToString());
                        anode1.Tag = r["ma"].ToString() + ":" + r1["id"].ToString();
                        anode1.ImageIndex = 1;
                        anode1.SelectedImageIndex = 1;
                        anode.Nodes.Add(anode1);
                    }
                }

                if (adsnhom.Tables[0].Select("ma=-1").Length < 0)
                {
                    DataRow ar = adsnhom.Tables[0].NewRow();
                    ar["ma"] = -1;
                    ar["ten"] = "...";
                    ar["idnhombhyt"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar, adsnhom.Tables[0].Rows.Count);
                }
                if (adsloai.Tables[0].Select("id=-1").Length < 0)
                {
                    DataRow ar1 = adsnhom.Tables[0].NewRow();
                    ar1["id"] = -1;
                    ar1["ten"] = "...";
                    ar1["id_nhom"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar1,adsloai.Tables[0].Rows.Count);
                }
            }
            catch
            {
            }
        }
        private void f_Filter()
        {
            try
            {
                string aft = "";
                if (txtTim.Text != "")
                {
                    aft = "(ma like '%" + txtTim.Text.Replace("'", "''") + "%' or ten like '%" + txtTim.Text.Replace("'", "''") + "%' or dvt like '%" + txtTim.Text.Replace("'", "''") + "%')";
                }
                try
                {
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "-1")
                    {
                        if (aft != "")
                        {
                            aft += " and ";
                        }
                        aft += " id_nhom=" + treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                    }
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                    {
                        if (aft != "")
                        {
                            aft += " and ";
                        }
                        aft += " id_loai=" + treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    }
                }
                catch
                {
                }

                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                lbTitle.Text = lan.Change_language_MessageText("Giá viện phí (") + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                lbTitle.Text = lan.Change_language_MessageText("Giá viện phí");
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
            f_Load_Tree();
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            f_Filter();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            f_Filter();
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
        private void butIn_Click(object sender, EventArgs e)
        {

        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            try
            {
                f_Load_DG();
            }
            catch
            {
            }
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ads = m_dsgiavp;//.GetChanges();
                int n=ads.Tables[0].Rows.Count;

                if(n>0)
                {
                    int i = 0;
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật giá viện phí đã thay đổi (") + n.ToString() + " Mục)?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        butLuu.Enabled = false;
                        ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật, xin chờ ...!");
                        foreach (DataRow r in ads.Tables[0].Rows)
                        {
                            i++;
                            try
                            {                               
                                    string s = m_v.fields(m_v.user+ ".v_giavp", "id=" + r["id"].ToString());
                                    m_v.upd_eve_tables(itablell, int.Parse(m_userid), "upd");
                                    m_v.upd_eve_upd_del(itablell, int.Parse(m_userid), "upd", s);
                             
                                ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:")+" " + i.ToString() + "/" + n.ToString() + " !";
                                statusStrip1.Refresh();
                                m_v.execute_data("update medibv.v_giavp set stt=" + (int.Parse(r["stt"].ToString()) > 0 ? r["stt"].ToString() : "1") + ",gia_th=" + (decimal.Parse(r["gia_th"].ToString()) > 0 ? r["gia_th"].ToString() : "0") + ",gia_bh=" + (decimal.Parse(r["gia_bh"].ToString()) > 0 ? r["gia_bh"].ToString() : "0") + ",gia_dv=" + (decimal.Parse(r["gia_dv"].ToString()) > 0 ? r["gia_dv"].ToString() : "0") + ",gia_nn=" + (decimal.Parse(r["gia_nn"].ToString()) > 0 ? r["gia_nn"].ToString() : "0") + ",gia_cs=" + (decimal.Parse(r["gia_cs"].ToString()) > 0 ? r["gia_cs"].ToString() : "0") + ",vattu_th=" + (decimal.Parse(r["vattu_th"].ToString()) > 0 ? r["vattu_th"].ToString() : "0") + ",vattu_bh=" + (decimal.Parse(r["vattu_bh"].ToString()) > 0 ? r["vattu_bh"].ToString() : "0") + ",vattu_dv=" + (decimal.Parse(r["vattu_dv"].ToString()) > 0 ? r["vattu_dv"].ToString() : "0") + ",vattu_nn=" + (decimal.Parse(r["vattu_nn"].ToString()) > 0 ? r["vattu_nn"].ToString() : "0") + ",vattu_cs=" + (decimal.Parse(r["vattu_cs"].ToString()) > 0 ? r["vattu_cs"].ToString() : "0") + ",bhyt=" + (decimal.Parse(r["bhyt"].ToString()) >= 0 && decimal.Parse(r["bhyt"].ToString()) <=100 ? r["bhyt"].ToString() : "0") + " where id="+r["id"].ToString());
                            }
                            catch
                            {
                            }
                        }
                        ttStatus.Text = lan.Change_language_MessageText("Cập nhật xong!");
                        butLuu.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void f_Set_Fullgrid()
        {
            try
            {
                dataGridView1.Columns["Column_6"].Frozen = !tmn_Fullgrid.Checked;
                dataGridView1.Columns["Column_5"].Frozen = !tmn_Fullgrid.Checked;
                dataGridView1.Columns["Column_4"].Frozen = !tmn_Fullgrid.Checked;
                dataGridView1.Columns["Column_3"].Frozen = !tmn_Fullgrid.Checked;
            }
            catch
            {
            }
        }
        private void tmn_Fullgrid_Click(object sender, EventArgs e)
        {
            f_Set_Fullgrid();
        }
    }
}