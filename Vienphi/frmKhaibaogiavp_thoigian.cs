using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;
using LibMedi;

namespace Vienphi
{
    public partial class frmKhaibaogiavp_thoigian : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData v;
        private DataSet m_dsgiavp, dsloaitg;
        private string m_userid = "", s_user = "";
        int itablell;
        public frmKhaibaogiavp_thoigian(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            lan.Read_dtgrid_to_Xml(dtgvGiavp, this.Name + "_" + "dataGridView1");
            lan.Change_dtgrid_HeaderText_to_English(dtgvGiavp, this.Name + "_" + "dataGridView1");
            v = v_v;
            m_userid = v_userid;
            s_user = v_v.user;
            v.f_SetEvent(this);
        }
        private void f_Load_DG()
        {
            try
            {
                if (chkgiavp.Checked)
                {
                    string sql = "select 0 as chon,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,a.vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt,a.id,a.id_loai,b.id_nhom from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id  order by a.stt,a.ten";
                    m_dsgiavp = v.get_data(sql);
                    dtgvGiavp.DataSource = m_dsgiavp.Tables[0];
                    txtTim_TextChanged(null, null);
                }
                else if (chkgiavptg.Checked)
                {
                    string sql = "select 0 as chon,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,a.vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt,a.id,a.id_loai,b.id_nhom from medibv.v_giavp_new a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id where a.idloaitg=" + int.Parse(cbloaitg.SelectedValue.ToString()) + " order by a.stt,a.ten";
                    m_dsgiavp = v.get_data(sql);
                    dtgvGiavp.DataSource = m_dsgiavp.Tables[0];
                    txtTim_TextChanged(null, null);
                }
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

                adsnhom = v.f_get_v_nhomvp_frmgiavp();
                adsloai = v.f_get_v_loaivp_frmgiavp();
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

                CurrencyManager cm = (CurrencyManager)(BindingContext[dtgvGiavp.DataSource, dtgvGiavp.DataMember]);
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
                int n = 0, n1 = 0;
                CurrencyManager cm = (CurrencyManager)BindingContext[dtgvGiavp.DataSource, dtgvGiavp.DataMember];
                DataView dv = (DataView)cm.List;
                n = dv.Table.Select("chon=1").Length;
                n1 = dv.Table.Select("chon=0").Length;
                DataSet ads = new DataSet();
                ads = m_dsgiavp.Copy();
                //int n = ads.Tables[0].Rows.Count;
                if (n > 0)
                {
                    int i = 0;
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật giá viện phí đã thay đổi (") + n.ToString() + " Mục)?", v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        butLuu.Enabled = false;
                        ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật, xin chờ ...!");
                        foreach (DataRow r in dv.Table.Select("chon=1"))
                        {
                            i++;
                            try
                            {
                                string s = v.fields(v.user + ".v_giavp_new", "id=" + r["id"].ToString());
                                v.upd_eve_tables(itablell, int.Parse(m_userid), "upd");
                                v.upd_eve_upd_del(itablell, int.Parse(m_userid), "upd", s);
                                ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:") + " " + i.ToString() + "/" + n.ToString() + " !";
                                statusStrip1.Refresh();
                                if (r["chon"].ToString() == "1")
                                {
                                    if (!v.upd_v_giavp_new(decimal.Parse(r["id"].ToString()), decimal.Parse(r["id_loai"].ToString()), (decimal.Parse(r["stt"].ToString()) > 0 ? decimal.Parse(r["stt"].ToString()) : 1), r["ma"].ToString(), r["ten"].ToString(), r["dvt"].ToString(), (decimal.Parse(r["bhyt"].ToString()) >= 0 && decimal.Parse(r["bhyt"].ToString()) <= 100 ? decimal.Parse(r["bhyt"].ToString()) : 0), (decimal.Parse(r["gia_th"].ToString()) > 0 ? decimal.Parse(r["gia_th"].ToString()) : 0), (decimal.Parse(r["gia_bh"].ToString()) > 0 ? decimal.Parse(r["gia_bh"].ToString()) : 0), (decimal.Parse(r["gia_dv"].ToString()) > 0 ? decimal.Parse(r["gia_dv"].ToString()) : 0), (decimal.Parse(r["gia_nn"].ToString()) > 0 ? decimal.Parse(r["gia_nn"].ToString()) : 0), (decimal.Parse(r["gia_ksk"].ToString()) > 0 ? decimal.Parse(r["gia_ksk"].ToString()) : 0), (decimal.Parse(r["gia_cs"].ToString()) > 0 ? decimal.Parse(r["gia_cs"].ToString()) : 0), (decimal.Parse(r["vattu_th"].ToString()) > 0 ? decimal.Parse(r["vattu_th"].ToString()) : 0), (decimal.Parse(r["vattu_bh"].ToString()) > 0 ? decimal.Parse(r["vattu_bh"].ToString()) : 0), (decimal.Parse(r["vattu_dv"].ToString()) > 0 ? decimal.Parse(r["vattu_dv"].ToString()) : 0), (decimal.Parse(r["vattu_nn"].ToString()) > 0 ? decimal.Parse(r["vattu_nn"].ToString()) : 0), (decimal.Parse(r["vattu_cs"].ToString()) > 0 ? decimal.Parse(r["vattu_cs"].ToString()) : 0), (decimal.Parse(r["vattu_ksk"].ToString()) > 0 ? decimal.Parse(r["vattu_ksk"].ToString()) : 0), decimal.Parse(m_userid), decimal.Parse(cbloaitg.SelectedValue.ToString())))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText(" Không cập được giá viện phí này. "), "Vienphi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        ttStatus.Text = lan.Change_language_MessageText("Cập nhật xong!");
                        butLuu.Enabled = true;
                    }
                }
                else
                {
                    int j = 0;
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật giá viện phí đã thay đổi (") + n1.ToString() + " Mục)?", v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        butLuu.Enabled = false;
                        ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật, xin chờ ...!");
                        foreach (DataRow r in dv.Table.Select("chon=0"))
                        {
                            j++;
                            try
                            {
                                string s = v.fields(v.user + ".v_giavp_new", "id=" + r["id"].ToString());
                                v.upd_eve_tables(itablell, int.Parse(m_userid), "upd");
                                v.upd_eve_upd_del(itablell, int.Parse(m_userid), "upd", s);
                                ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:") + " " + j.ToString() + "/" + n1.ToString() + " !";
                                statusStrip1.Refresh();
                                if (r["chon"].ToString() == "0")
                                {
                                    if (!v.upd_v_giavp_new(decimal.Parse(r["id"].ToString()), decimal.Parse(r["id_loai"].ToString()), (decimal.Parse(r["stt"].ToString()) > 0 ? decimal.Parse(r["stt"].ToString()) : 1), r["ma"].ToString(), r["ten"].ToString(), r["dvt"].ToString(), (decimal.Parse(r["bhyt"].ToString()) >= 0 && decimal.Parse(r["bhyt"].ToString()) <= 100 ? decimal.Parse(r["bhyt"].ToString()) : 0), (decimal.Parse(r["gia_th"].ToString()) > 0 ? decimal.Parse(r["gia_th"].ToString()) : 0), (decimal.Parse(r["gia_bh"].ToString()) > 0 ? decimal.Parse(r["gia_bh"].ToString()) : 0), (decimal.Parse(r["gia_dv"].ToString()) > 0 ? decimal.Parse(r["gia_dv"].ToString()) : 0), (decimal.Parse(r["gia_nn"].ToString()) > 0 ? decimal.Parse(r["gia_nn"].ToString()) : 0), (decimal.Parse(r["gia_ksk"].ToString()) > 0 ? decimal.Parse(r["gia_ksk"].ToString()) : 0), (decimal.Parse(r["gia_cs"].ToString()) > 0 ? decimal.Parse(r["gia_cs"].ToString()) : 0), (decimal.Parse(r["vattu_th"].ToString()) > 0 ? decimal.Parse(r["vattu_th"].ToString()) : 0), (decimal.Parse(r["vattu_bh"].ToString()) > 0 ? decimal.Parse(r["vattu_bh"].ToString()) : 0), (decimal.Parse(r["vattu_dv"].ToString()) > 0 ? decimal.Parse(r["vattu_dv"].ToString()) : 0), (decimal.Parse(r["vattu_nn"].ToString()) > 0 ? decimal.Parse(r["vattu_nn"].ToString()) : 0), (decimal.Parse(r["vattu_cs"].ToString()) > 0 ? decimal.Parse(r["vattu_cs"].ToString()) : 0), (decimal.Parse(r["vattu_ksk"].ToString()) > 0 ? decimal.Parse(r["vattu_ksk"].ToString()) : 0), decimal.Parse(m_userid), decimal.Parse(cbloaitg.SelectedValue.ToString())))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText(" Không cập được giá viện phí này. "), "Vienphi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                            catch
                            {
                                throw;
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
                dtgvGiavp.Columns["Column_6"].Frozen = !tmn_Fullgrid.Checked;
                dtgvGiavp.Columns["Column_5"].Frozen = !tmn_Fullgrid.Checked;
                dtgvGiavp.Columns["Column_4"].Frozen = !tmn_Fullgrid.Checked;
                dtgvGiavp.Columns["Column_3"].Frozen = !tmn_Fullgrid.Checked;
            }
            catch
            {
            }
        }
        private void tmn_Fullgrid_Click(object sender, EventArgs e)
        {
            f_Set_Fullgrid();
        }
        private void frmKhaibaogiavp_thoigian_Load(object sender, EventArgs e)
        {
            f_capnhat_database();
            itablell = v.tableid("", "v_giavp");
            f_Load_DG();
            f_Set_Fullgrid();
            f_Load_Tree();
            f_Load_Loaitg();
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_capnhat_database()
        {
            DataSet ds = new DataSet();
            string asql = " select id,ten from " + s_user + ".dmloaitg ";
            ds = v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                v.execute_data("CREATE TABLE " + s_user + ".dmloaitg (id numeric(1,0) not null, ten character varying(250),CONSTRAINT pk_dmloaitg PRIMARY KEY (id) USING INDEX TABLESPACE medi_index ) WITH OIDS;ALTER TABLE " + s_user + ".dmloaitg OWNER TO medisoft;");
            }
            asql = " select id,ten from " + s_user + ".v_giavp_new ";
            ds = v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                string s_sql = "";
                s_sql = " CREATE TABLE " + s_user + ".v_giavp_new (id numeric (7,0),id_loai numeric(3,0), stt numeric(5,0),ma text,ten text,dvt character varying(20),bhyt numeric(7,2),";
                s_sql += " gia_th numeric(10,0),gia_bh numeric(10,0),gia_cs numeric(10,0),gia_dv numeric(10,0),gia_nn numeric(10,0),gia_ksk numeric(10,0),";
                s_sql += " vattu_th numeric(10,0),vattu_bh numeric(10,0),vattu_dv numeric(10,0),vattu_nn numeric(10,0),vattu_cs numeric(10,0),vattu_ksk numeric(10,0), userid numeric(5,0),idloaitg numeric(1,0),ngayud timestamp,";
                s_sql += " CONSTRAINT pk_v_giavp_new PRIMARY KEY (id,idloaitg),";
                s_sql += " CONSTRAINT fk_v_giavp_new_v_giavp FOREIGN KEY (id)  REFERENCES " + s_user + ".v_giavp (id),";
                s_sql += " CONSTRAINT fk_v_giavp_new_dmloaitg FOREIGN KEY (idloaitg)  REFERENCES " + s_user + ".dmloaitg (id)";
                s_sql += " MATCH SIMPLE  ON UPDATE NO ACTION ON DELETE SET NULL)WITH OIDS;";
                s_sql += " ALTER TABLE " + s_user + ".v_giavp_new OWNER TO medisoft;";
                v.execute_data(s_sql);
            }
        }
        private void f_Load_Loaitg()
        {
            dsloaitg = new DataSet();
            try
            {
                //dsloaitg = v.get_data(" select id,ten from " + s_user + ".dmloaitg where 1=0");
                //DataRow r = dsloaitg.Tables[0].NewRow();
                //r["id"] = 0;
                //r["ten"] = "";
                //dsloaitg.Tables[0].Rows.Add(r);
                //foreach (DataRow dr in v.get_data(" select id,ten from " + s_user + ".dmloaitg order by id ").Tables[0].Rows)
                //{
                //    dsloaitg.Tables[0].Rows.Add(dr.ItemArray);
                //}
                dsloaitg = v.get_data(" select id,ten from " + s_user + ".dmloaitg where id<>0 order by id ");
                cbloaitg.DisplayMember = "ten";
                cbloaitg.ValueMember = "id";
                cbloaitg.DataSource = dsloaitg.Tables[0];
            }
            catch { }
        }

        private void chkgiavptg_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkgiavp.Checked)
            {
                chkgiavp.Checked = false;
                chkgiavptg.Checked = true;
            }
            else
                chkgiavp.Checked = false;
            f_Load_DG();
        }

        private void chkgiavp_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkgiavptg.Checked)
            {
                chkgiavptg.Checked = false;
                chkgiavp.Checked = true;
            }
            else
                chkgiavptg.Checked = false;
            f_Load_DG();
        }

        private void cbloaitg_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
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
                CurrencyManager cm = (CurrencyManager)(BindingContext[dtgvGiavp.DataSource, dtgvGiavp.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                DataSet dstmp=new DataSet();
                dstmp = dv.DataViewManager.DataSet;
                int aval = chkAll.Checked ? 1 : 0;
                foreach (DataRow r in dstmp.Tables[0].Select(aft))
                {
                    r["chon"] = aval;
                }
                dtgvGiavp.Update();
            }
            catch
            {
                butLuu.Enabled = false;
            }
        }
    }
}