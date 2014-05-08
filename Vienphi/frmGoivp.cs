using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmGoivp : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private DataSet m_dsloaivp;
        private string m_userid = "",m_id_gia="";
        public frmGoivp(LibVP.AccessData v_v, string v_userid, string v_id_gia)
        {
            InitializeComponent();


            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
            lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
            m_v = v_v;
            m_id_gia = v_id_gia;
            m_userid = v_userid;
            m_v.f_SetEvent(this);
        }

        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            f_Load_DG();
            f_Load_Tree();
            ttStatus.Text = "";
        }
        private void f_Load_DG()
        {
            try
            {
                txtTim.Text = lan.Change_language_MessageText("Tìm kiếm");
                string sql = "select  case when c.id_loai is null then 0 else 1 end as chon, case when c.stt is null then 1 else c.stt end as stt, a.ma, a.ten,sum(case when c.sotien is null then 0 else c.sotien end) as sotien,b.ten as tennhom, a.id, a.id_nhom from medibv.v_loaivp a left join medibv.v_nhomvp b on a.id_nhom=b.ma left join (select aa.stt, aa.id_loai, sum(aa.sotien) as sotien from medibv.v_trongoi aa left join medibv.v_giavp bb on aa.id=bb.id where hide=0 and aa.id=" + m_id_gia + " and aa.id_gia=0 group by aa.stt,aa.id_loai) as c on a.id=c.id_loai group by case when c.id_loai is null then 0 else 1 end, a.ma, c.stt, a.ten,b.ten, a.id, a.id_nhom";
                m_dsloaivp = m_v.get_data(sql);
                dataGridView1.DataSource = m_dsloaivp.Tables[0];
                txtTim_TextChanged(null, null);
                f_Tinhtien();
            }
            catch
            {
            }
        }
        private void f_Load_Tree()
        {
            try
            {
                try
                {
                    foreach (DataRow r in m_v.get_data("select ma, ten, dvt from medibv.v_giavp where  hide=0 and  id=" + m_id_gia).Tables[0].Rows)
                    {
                        lbName.Text = r["ma"].ToString().Trim() + " - " + r["ten"].ToString().Trim() + " (" + r["dvt"].ToString().Trim()+")";
                        break;
                    }
                }
                catch
                {
                    lbName.Text = "???";
                }
                treeView1.Nodes.Clear();
                TreeNode anode;
                DataSet adsnhom;
                anode = new TreeNode(
lan.Change_language_MessageText("Tất cả"));
                anode.Tag = "?";
                anode.ImageIndex = 2;
                anode.SelectedImageIndex = 2;
                treeView1.Nodes.Add(anode);

                adsnhom = m_v.get_data("select ma, ten, stt from medibv.v_nhomvp order by stt");
                foreach (DataRow r in adsnhom.Tables[0].Rows)
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["ma"].ToString();
                    anode.ImageIndex = 0;
                    anode.SelectedImageIndex = 0;
                    treeView1.Nodes.Add(anode);
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
                if (txtTim.Text.Trim() != "" && txtTim.Text.Trim() != lan.Change_language_MessageText("Tìm kiếm"))
                {
                    aft = "(ma like '%" + txtTim.Text.Replace("'", "''") + "%' or ten like '%" + txtTim.Text.Replace("'", "''") + "%' or tennhom like '%" + txtTim.Text.Replace("'", "''") + "%')";
                }
                try
                {
                    if (treeView1.SelectedNode.Tag.ToString() != "?")
                    {
                        if (aft != "")
                        {
                            aft += " and ";
                        }
                        aft += " id_nhom=" + treeView1.SelectedNode.Tag.ToString();
                    }
                }
                catch
                {
                }

                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch
            {
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
                DataSet ads = m_dsloaivp;
                int n=ads.Tables[0].Select("chon=1").Length;
                if(n>0)
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật phân bổ gói viện phí (") + n.ToString() + " Mục)?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        butLuu.Enabled = false;
                        ttStatus.Text = "Đang cập nhật, xin chờ ...!";
                        decimal i=0, aid = 0,aid_nhom=0,aid_loai=0,aid_gia=0,asotien=0,astt=1,adongia=0;
                        try
                        {
                            aid = decimal.Parse(m_id_gia);
                        }
                        catch
                        {
                            aid=0;
                        }
                        if (aid == 0)
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Chưa chọn giá viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        m_v.execute_data("delete from medibv.v_trongoi where id_gia =0 and  id = "+aid.ToString());
                        foreach (DataRow r in ads.Tables[0].Select("chon=1"))
                        {
                            i++;
                            try
                            {
                                aid_nhom = decimal.Parse(r["id_nhom"].ToString());
                            }
                            catch
                            {
                                aid_nhom = 0;
                            }
                            try
                            {
                                aid_loai = decimal.Parse(r["id"].ToString());
                            }
                            catch
                            {
                                aid_loai = 0;
                            }
                            try
                            {
                                astt = decimal.Parse(r["stt"].ToString());
                            }
                            catch
                            {
                                astt = 1;
                            }
                            try
                            {
                                asotien = decimal.Parse(r["sotien"].ToString());
                            }
                            catch
                            {
                                asotien = 0;
                            }
                            adongia += asotien;
                            try
                            {
                                ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:")+" " + i.ToString() + "/" + n.ToString() + " !";
                                statusStrip1.Refresh();
                                m_v.execute_data("insert into medibv.v_trongoi (id,id_nhom,id_loai,id_gia,sotien,stt) values(" + aid.ToString() + "," + aid_nhom.ToString() + "," + aid_loai.ToString() + "," + aid_gia.ToString() + "," + asotien.ToString() + "," + astt.ToString() + ") ");
                            }
                            catch
                            {
                            }
                        }
                        m_v.execute_data("update medibv.v_giavp set loaitrongoi=1, gia_th=" + adongia.ToString() + ",gia_bh=" + adongia.ToString() + ",gia_dv=" + adongia.ToString() + ", gia_nn=" + adongia.ToString() + ",gia_cs=" + adongia.ToString() + ",vattu_th=0, vattu_bh=0,vattu_dv=0,vattu_nn=0,vattu_cs=0 where id = " + aid.ToString());
                        m_v.execute_data("update medibv.v_giavp set loaitrongoi=0 where loaitrongoi=1 and id not in (select distinct id from medibv.v_trongoi where id_gia = 0)");
                        ttStatus.Text = "Cập nhật xong!";
                        f_Load_DG();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    f_Check(dataGridView1, dataGridView1[6, e.RowIndex].Value.ToString(), (dataGridView1[0, e.RowIndex].Value.ToString() == "1" ? 0 : 1));
                    f_Tinhtien();
                }
            }
            catch
            {
            }
        }
        private void f_Check(DataGridView v_dgv, string v_id, int v_val)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[v_dgv.DataSource, v_dgv.DataMember]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("id=" + v_id))
                {
                    r["chon"] = v_val;
                }
                v_dgv.Update();
            }
            catch
            {
            }
        }
        private void f_Tinhtien()
        {
            try
            {
                decimal atmp=0,asotien=0,astt=0;
                foreach (DataRow r in m_dsloaivp.Tables[0].Rows)
                {
                    try
                    {
                        atmp = decimal.Parse(r["sotien"].ToString());
                    }
                    catch
                    {
                        atmp = 0;
                    }
                    if (atmp < 0)
                    {
                        atmp = 0;
                    }
                    try
                    {
                        astt = decimal.Parse(r["stt"].ToString());
                    }
                    catch
                    {
                        astt = 0;
                    }
                    if (astt < 0)
                    {
                        astt = 1;
                    }
                    r["stt"] = astt;
                    r["sotien"] = atmp;
                    if(r["chon"].ToString()=="1")
                    {
                        asotien += atmp;
                    }
                }
                lbSotien.Text = 
                    lan.Change_language_MessageText("Giá trọn gói:")+" " + asotien.ToString("###,###,##0.##") + " "+
lan.Change_language_MessageText("đồng");
            }
            catch
            {
                lbSotien.Text = 
lan.Change_language_MessageText("Giá trọn gói: 0 đồng");
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 4)
                {
                    f_Tinhtien();
                }
            }
            catch
            {
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text.Trim().ToLower() == 
lan.Change_language_MessageText("Tìm kiếm"))
                {
                    txtTim.Text = "";
                }
                f_Filter();
            }
            catch
            {
            }
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text.Trim() == "")
                {
                    txtTim.Text = 
lan.Change_language_MessageText("Tìm kiếm");
                }
                f_Filter();
            }
            catch
            {
            }
        }

        private void txtTim_Click(object sender, EventArgs e)
        {

        }
    }
}