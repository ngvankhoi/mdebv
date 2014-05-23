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
    public partial class frmKhaibaogiavp_truoc : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData v;
        private DataSet m_dsgiavp, dschinhanh;
        private string m_userid = "", s_user = "", sdbclient = "";
        private int ichinhanh=0;
        private bool bCncenter = false;
        
        int itablell;
        public frmKhaibaogiavp_truoc(LibVP.AccessData v_v, string v_userid, int _chinhanh)
        {
            InitializeComponent();
            ichinhanh = _chinhanh;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            //lan.Read_dtgrid_to_Xml(dtgvGiavp, this.Name + "_" + "dataGridView1");
            //lan.Change_dtgrid_HeaderText_to_English(dtgvGiavp, this.Name + "_" + "dataGridView1");
            v = v_v;
            m_userid = v_userid;
            s_user = v_v.user;
            v.f_SetEvent(this);
        }

        private void f_Load_Dongia_goc()
        {
            try
            {
                //if (chkgiavp.Checked)
                //{
                //    string sql = "select 0 as chon,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.phuthu_th,a.phuthu_dv,a.phuthu_nn,a.phuthu_cs,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt,a.id,a.id_loai,b.id_nhom, to_char(a.ngayud,'dd/mm/yyyyy') as ngayhieuluc from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id  order by a.stt,a.ten";
                //    m_dsgiavp = v.get_data(sql);
                //    dtgvGiavp.DataSource = m_dsgiavp.Tables[0];
                //    txtTim_TextChanged(null, null);
                //}
                //else if (chkgiavptg.Checked)
                //{
                if (cbchinhanh.SelectedIndex == -1) return;
                sdbclient = "";
                if (cbchinhanh.SelectedValue.ToString() != ichinhanh.ToString())
                {
                    DataRow r = v.getrowbyid(dschinhanh.Tables[0], "id=" + cbchinhanh.SelectedValue.ToString());
                    if (r != null) sdbclient = r["database"].ToString();
                    sdbclient = "@" + sdbclient.Trim('@');
                }
                //
                string sql = "select 0 as chon,a.stt,a.ma,a.ten,a.dvt,";
                sql += " a.gia_th,";//a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.phuthu_th,a.phuthu_dv,a.phuthu_nn,a.phuthu_cs,";
                sql += " a.gia_bh,";
                sql += " a.gia_dv,";
                sql += " a.gia_nn,";
                sql += " a.gia_cs,";
                sql += " a.gia_ksk,";
                sql += " a.phuthu_th,";
                sql += " a.phuthu_dv,";
                sql += " a.phuthu_nn,";
                sql += " a.phuthu_cs,";
                sql += " case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt,a.id,a.id_loai,b.id_nhom, to_char(now(),'dd/mm/yyyy') as ngayhieuluc ";

                sql += " from medibv.v_giavp" + sdbclient + " a left join medibv.v_loaivp" + sdbclient + " b on a.id_loai=b.id left join medibv.v_nhomvp" + sdbclient + " d on b.id_nhom=d.ma left join medibv.v_nhombhyt" + sdbclient + " e on d.idnhombhyt=e.id ";
                sql += " where hide=0 ";                                
                sql += " order by a.stt,a.ten";
                //
                m_dsgiavp = v.get_data(sql);
                dtgvGiavp.DataSource = m_dsgiavp.Tables[0];
                txtTim_TextChanged(null, null);
                //}
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_DG(string vNgayHieuluc)
        {
            try
            {
                //if (chkgiavp.Checked)
                //{
                //    string sql = "select 0 as chon,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.phuthu_th,a.phuthu_dv,a.phuthu_nn,a.phuthu_cs,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt,a.id,a.id_loai,b.id_nhom, to_char(a.ngayud,'dd/mm/yyyyy') as ngayhieuluc from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id  order by a.stt,a.ten";
                //    m_dsgiavp = v.get_data(sql);
                //    dtgvGiavp.DataSource = m_dsgiavp.Tables[0];
                //    txtTim_TextChanged(null, null);
                //}
                //else if (chkgiavptg.Checked)
                //{
                sdbclient = "";
                if (cbchinhanh.SelectedValue.ToString() != ichinhanh.ToString())
                {
                    DataRow r = v.getrowbyid(dschinhanh.Tables[0], "id=" + cbchinhanh.SelectedValue.ToString());
                    if (r != null) sdbclient = r["database"].ToString();
                    sdbclient = "@" + sdbclient.Trim('@');
                }
                //
                string sql = "select 0 as chon,a.stt,a.ma,a.ten,a.dvt,";
                sql += " case when aa.gia_th is null then a.gia_th else aa.gia_th end as gia_th,";//a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.gia_ksk,a.phuthu_th,a.phuthu_dv,a.phuthu_nn,a.phuthu_cs,";
                sql += " case when aa.gia_bh is null then a.gia_bh else aa.gia_bh end as gia_bh,";
                sql += " case when aa.gia_dv is null then a.gia_dv else  aa.gia_dv end as gia_dv,";
                sql += " case when aa.gia_nn is null then a.gia_nn else  aa.gia_nn end as gia_nn,";
                sql += " case when aa.gia_cs is null then a.gia_cs else  aa.gia_cs end as gia_cs,";
                sql += " a.gia_ksk,";
                sql += " case when aa.phuthu_th is null then a.phuthu_th else  aa.phuthu_th end as phuthu_th,";
                sql += " case when aa.phuthu_dv is null then a.phuthu_dv else  aa.phuthu_dv end as phuthu_dv,";
                sql += " case when aa.phuthu_nn is null then a.phuthu_nn else  aa.phuthu_nn end as phuthu_nn,";
                sql += " case when aa.phuthu_cs is null then a.phuthu_cs else  aa.phuthu_cs end as phuthu_cs,";
                sql += " case when aa.bhyt is null then a.bhyt else aa.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt,a.id,a.id_loai,b.id_nhom, to_char(aa.ngayhieuluc,'dd/mm/yyyy') as ngayhieuluc ";

                sql += " from medibv.v_giavp" + sdbclient + " a left join medibv.v_giavp_truoc" + sdbclient + " aa on a.id=aa.id left join medibv.v_loaivp" + sdbclient + " b on a.id_loai=b.id left join medibv.v_nhomvp" + sdbclient + " d on b.id_nhom=d.ma left join medibv.v_nhombhyt" + sdbclient + " e on d.idnhombhyt=e.id ";
                sql += " where 1=1 ";
                if (chkgiavptg.Checked == false) sql += " and(aa.id is null or aa.done=0) ";
                if (vNgayHieuluc.Trim() != "") sql += " and to_char(aa.ngayhieuluc,'dd/mm/yyyy')='" + vNgayHieuluc + "'";
                sql += " order by a.stt,a.ten";
                //
                m_dsgiavp = v.get_data(sql);
                dtgvGiavp.DataSource = m_dsgiavp.Tables[0];
                txtTim_TextChanged(null, null);
                //}
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
                //asort = "stt";
                anode = new TreeNode(lan.Change_language_MessageText("Tất cả"));
                anode.Tag = "?:?";
                anode.ImageIndex = 2;
                anode.SelectedImageIndex = 2;
                treeView1.Nodes.Add(anode);

                adsnhom = v.f_get_v_nhomvp_frmgiavp_cochitiet();
                adsloai = v.f_get_v_loaivp_frmgiavp_cochitiet();
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
                    adsloai.Tables[0].Rows.InsertAt(ar1, adsloai.Tables[0].Rows.Count);
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
            Cursor = Cursors.WaitCursor;
            if (chkgiavptg.Checked) f_Load_NgayHieuluc();
            if (chkgiavp.Checked) f_Load_Dongia_goc();
            else f_Load_DG(cbNgayHieuluc.Text);
            
            f_Load_Tree();
            Cursor = Cursors.Default;
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
                if (chkgiavptg.Checked && cbNgayHieuluc.SelectedIndex >= 0) f_Load_DG(cbNgayHieuluc.Text);
                else if (chkgiavptg.Checked && cbNgayHieuluc.SelectedIndex < 0) f_Load_DG("");
                else f_Load_Dongia_goc();
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
                if(txtNgayhieuluc.Text.Trim().Length!=10)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập ngày hiệu lực."));
                    txtNgayhieuluc.Focus();
                    return;
                }
                if (v.bNgay(txtNgayhieuluc.Text) == false) 
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ, đề nghị nhập lại ngày hiệu lực."));
                    txtNgayhieuluc.Focus();
                    return;
                }
                if (v.StringToDate(txtNgayhieuluc.Text) <= v.StringToDate(v.ngayhienhanh_server.Substring(0, 10)))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày hiệu lực phải lớn hơn ngày hiện tại."));
                    txtNgayhieuluc.Focus();
                    return;
                }
                if (cbchinhanh.Items.Count >0 && cbchinhanh.SelectedIndex < 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn chi nhánh."));
                    cbchinhanh.Focus();
                    return;
                }
                CurrencyManager cm = (CurrencyManager)BindingContext[dtgvGiavp.DataSource, dtgvGiavp.DataMember];
                DataView dv = (DataView)cm.List;
                n = dv.Table.Select("chon=1").Length;
                n1 = dv.Table.Select("chon=0").Length;
                DataSet ads = new DataSet();
                ads = m_dsgiavp.GetChanges();// m_dsgiavp.Copy();
                //int n = ads.Tables[0].Rows.Count;
                if (ads.Tables[0].Rows.Count >0 )//if (n > 0)
                {
                    int i = 0;
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật giá viện phí đã thay đổi (") + n.ToString() + " Mục)?", v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        butLuu.Enabled = false;
                        ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật, xin chờ ...!");
                        foreach (DataRow r in ads.Tables[0].Rows) //foreach (DataRow r in dv.Table.Select("chon=true"))
                        {
                            i++;
                            try
                            {
                                string s = v.fields(v.user + ".v_giavp_truoc", "id=" + r["id"].ToString());
                                v.upd_eve_tables(itablell, int.Parse(m_userid), "upd");
                                v.upd_eve_upd_del(itablell, int.Parse(m_userid), "upd", s);
                                ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:") + " " + i.ToString() + "/" + n.ToString() + " !";
                                statusStrip1.Refresh();
                                
                                v.databaselinks_name = "";//binh140911
                                //if (!v.upd_v_giavp_truoc(decimal.Parse(r["id"].ToString()), decimal.Parse(r["id_loai"].ToString()), (decimal.Parse(r["stt"].ToString()) > 0 ? decimal.Parse(r["stt"].ToString()) : 1), r["ma"].ToString(), r["ten"].ToString(), r["dvt"].ToString(), (decimal.Parse(r["bhyt"].ToString()) >= 0 && decimal.Parse(r["bhyt"].ToString()) <= 100 ? decimal.Parse(r["bhyt"].ToString()) : 0), (decimal.Parse(r["gia_th"].ToString()) > 0 ? decimal.Parse(r["gia_th"].ToString()) : 0), (decimal.Parse(r["gia_bh"].ToString()) > 0 ? decimal.Parse(r["gia_bh"].ToString()) : 0), (decimal.Parse(r["gia_dv"].ToString()) > 0 ? decimal.Parse(r["gia_dv"].ToString()) : 0), (decimal.Parse(r["gia_nn"].ToString()) > 0 ? decimal.Parse(r["gia_nn"].ToString()) : 0), (decimal.Parse(r["gia_ksk"].ToString()) > 0 ? decimal.Parse(r["gia_ksk"].ToString()) : 0), (decimal.Parse(r["gia_cs"].ToString()) > 0 ? decimal.Parse(r["gia_cs"].ToString()) : 0), (decimal.Parse(r["phuthu_th"].ToString()) > 0 ? decimal.Parse(r["phuthu_th"].ToString()) : 0), (decimal.Parse(r["phuthu_dv"].ToString()) > 0 ? decimal.Parse(r["phuthu_dv"].ToString()) : 0), (decimal.Parse(r["phuthu_nn"].ToString()) > 0 ? decimal.Parse(r["phuthu_nn"].ToString()) : 0), (decimal.Parse(r["phuthu_cs"].ToString()) > 0 ? decimal.Parse(r["phuthu_cs"].ToString()) : 0), decimal.Parse(m_userid), cbchinhanh.SelectedValue.ToString(), txtNgayhieuluc.Text))
                                //{
                                //    MessageBox.Show(lan.Change_language_MessageText("Không cập được giá viện phí này. "), "Vienphi2007", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    return;
                                //}
                                v.execute_data("update medibv.v_giavp_truoc set chiupdategia=1 where id=" + r["id"].ToString() + " and to_char(ngayhieuluc,'dd/mm/yyyy')='" + txtNgayhieuluc.Text + "'");
                                //
                                //if (cbchinhanh.SelectedIndex >= 0 && cbchinhanh.SelectedValue.ToString()!=ichinhanh.ToString())
                                //{
                                    foreach (DataRow drch in dschinhanh.Tables[0].Rows)
                                    {
                                        if (drch["matmang"].ToString() != "0") continue;
                                        sdbclient = v.get_Tendatabase(int.Parse(drch["id"].ToString()));//int.Parse(cbchinhanh.SelectedValue.ToString())).Trim('@');
                                        if (sdbclient.Trim('@') != "")//cap nhat truc tiep chi nhanh
                                        {
                                            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
                                            if (sdbclient == "") continue;
                                            v.databaselinks_name = sdbclient;
                                            //if (!v.upd_v_giavp_truoc(decimal.Parse(r["id"].ToString()), decimal.Parse(r["id_loai"].ToString()), (decimal.Parse(r["stt"].ToString()) > 0 ? decimal.Parse(r["stt"].ToString()) : 1), r["ma"].ToString(), r["ten"].ToString(), r["dvt"].ToString(), (decimal.Parse(r["bhyt"].ToString()) >= 0 && decimal.Parse(r["bhyt"].ToString()) <= 100 ? decimal.Parse(r["bhyt"].ToString()) : 0), (decimal.Parse(r["gia_th"].ToString()) > 0 ? decimal.Parse(r["gia_th"].ToString()) : 0), (decimal.Parse(r["gia_bh"].ToString()) > 0 ? decimal.Parse(r["gia_bh"].ToString()) : 0), (decimal.Parse(r["gia_dv"].ToString()) > 0 ? decimal.Parse(r["gia_dv"].ToString()) : 0), (decimal.Parse(r["gia_nn"].ToString()) > 0 ? decimal.Parse(r["gia_nn"].ToString()) : 0), (decimal.Parse(r["gia_ksk"].ToString()) > 0 ? decimal.Parse(r["gia_ksk"].ToString()) : 0), (decimal.Parse(r["gia_cs"].ToString()) > 0 ? decimal.Parse(r["gia_cs"].ToString()) : 0), (decimal.Parse(r["phuthu_th"].ToString()) > 0 ? decimal.Parse(r["phuthu_th"].ToString()) : 0), (decimal.Parse(r["phuthu_dv"].ToString()) > 0 ? decimal.Parse(r["phuthu_dv"].ToString()) : 0), (decimal.Parse(r["phuthu_nn"].ToString()) > 0 ? decimal.Parse(r["phuthu_nn"].ToString()) : 0), (decimal.Parse(r["phuthu_cs"].ToString()) > 0 ? decimal.Parse(r["phuthu_cs"].ToString()) : 0), decimal.Parse(m_userid), cbchinhanh.SelectedValue.ToString(), txtNgayhieuluc.Text))
                                            //{
                                            //    MessageBox.Show(lan.Change_language_MessageText(" Không cập được giá viện phí này vào chi nhánh: ") + cbchinhanh.Text, "Vienphi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            //    return;
                                            //}
                                            //v.execute_data("update medibv.v_giavp_truoc" + sdbclient + " set chiupdategia=1 where id=" + r["id"].ToString() + " and to_char(ngayhieuluc,'dd/mm/yyyy')='" + txtNgayhieuluc.Text + "'");
                                        }
                                    }
                                //}
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
                        foreach (DataRow r in ads.Tables[0].Rows) //foreach (DataRow r in dv.Table.Select("chon=0"))
                        {
                            j++;
                            try
                            {
                                string s = v.fields(v.user + ".v_giavp_truoc", "id=" + r["id"].ToString());
                                v.upd_eve_tables(itablell, int.Parse(m_userid), "upd");
                                v.upd_eve_upd_del(itablell, int.Parse(m_userid), "upd", s);
                                ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:") + " " + j.ToString() + "/" + n1.ToString() + " !";
                                statusStrip1.Refresh();
                                //if (r["chon"].ToString() == "0")
                                //{
                                //    if (!v.upd_v_giavp_truoc(decimal.Parse(r["id"].ToString()), decimal.Parse(r["id_loai"].ToString()), (decimal.Parse(r["stt"].ToString()) > 0 ? decimal.Parse(r["stt"].ToString()) : 1), r["ma"].ToString(), r["ten"].ToString(), r["dvt"].ToString(), (decimal.Parse(r["bhyt"].ToString()) >= 0 && decimal.Parse(r["bhyt"].ToString()) <= 100 ? decimal.Parse(r["bhyt"].ToString()) : 0), (decimal.Parse(r["gia_th"].ToString()) > 0 ? decimal.Parse(r["gia_th"].ToString()) : 0), (decimal.Parse(r["gia_bh"].ToString()) > 0 ? decimal.Parse(r["gia_bh"].ToString()) : 0), (decimal.Parse(r["gia_dv"].ToString()) > 0 ? decimal.Parse(r["gia_dv"].ToString()) : 0), (decimal.Parse(r["gia_nn"].ToString()) > 0 ? decimal.Parse(r["gia_nn"].ToString()) : 0), (decimal.Parse(r["gia_ksk"].ToString()) > 0 ? decimal.Parse(r["gia_ksk"].ToString()) : 0), (decimal.Parse(r["gia_cs"].ToString()) > 0 ? decimal.Parse(r["gia_cs"].ToString()) : 0), (decimal.Parse(r["phuthu_th"].ToString()) > 0 ? decimal.Parse(r["phuthu_th"].ToString()) : 0), (decimal.Parse(r["phuthu_dv"].ToString()) > 0 ? decimal.Parse(r["phuthu_dv"].ToString()) : 0), (decimal.Parse(r["phuthu_nn"].ToString()) > 0 ? decimal.Parse(r["phuthu_nn"].ToString()) : 0), (decimal.Parse(r["phuthu_cs"].ToString()) > 0 ? decimal.Parse(r["phuthu_cs"].ToString()) : 0), decimal.Parse(m_userid), cbchinhanh.SelectedValue.ToString(),txtNgayhieuluc.Text))
                                //    {
                                //        MessageBox.Show(lan.Change_language_MessageText(" Không cập được giá viện phí này. "), "Vienphi2007", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //        return;
                                ////    }
                                //}
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
                butLuu.Enabled = true;
            }
            v.databaselinks_name = "";//binh140911
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
            bCncenter = v.bServercenter(ichinhanh);
            sdbclient = "";
            itablell = v.tableid("", "v_giavp");            
            
            f_Set_Fullgrid();
            f_Load_Tree();
            f_Load_chinhanh();
            if (bCncenter || cbchinhanh.Items.Count == 0)
            {
                butChuyen.Enabled = butLuu.Enabled = true;   
                
            }
            else
            {
                butChuyen.Enabled = butLuu.Enabled = false;
            }
            f_Load_Dongia_goc();
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        
        private void f_Load_chinhanh()
        {
            dschinhanh = new DataSet();
            try
            {               
                dschinhanh = v.get_data(" select * from " + s_user + ".dmchinhanh where id>0 and matmang=0 order by id ");
                cbchinhanh.DisplayMember = "ten";
                cbchinhanh.ValueMember = "id";
                cbchinhanh.DataSource = dschinhanh.Tables[0];
                cbchinhanh.Enabled = (cbchinhanh.Items.Count > 1 && bCncenter);
                sdbclient = v.get_Tendatabase(ichinhanh).Trim('@');
                cbchinhanh.SelectedValue = ichinhanh;
                if (cbchinhanh.SelectedIndex >= 0) cbchinhanh_SelectedIndexChanged(null, null);
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
            {
                chkgiavp.Checked = false;
            }
            //
            butLuu.Enabled = (bCncenter == false) ? false : chkgiavp.Checked;
        }

        private void chkgiavp_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkgiavptg.Checked)
            {
                chkgiavptg.Checked = false;
                chkgiavp.Checked = true;
            }
            else
            {
                chkgiavptg.Checked = false;
            }
            butLuu.Enabled = (bCncenter == false) ? false : chkgiavp.Checked;
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

        private void butChuyen_Click(object sender, EventArgs e)
        {
            
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            if (bCncenter)
            {
                frmChonchinhanh fchon = new frmChonchinhanh(v);
                fchon.ShowDialog();
                string s_idchinhanhchuyen = fchon.IDChiNhanh, s_sql = "";
                if (s_idchinhanhchuyen.Trim() != "")
                {
                    foreach (string s_chinhanh in s_idchinhanhchuyen.Split(','))
                    {
                        DataRow rcn = v.getrowbyid(dschinhanh.Tables[0], "id=" + s_chinhanh);
                        if (rcn != null)
                        {
                            string databaselink = rcn["database"].ToString().Trim('@');
                            if (databaselink != "")
                            {
                                databaselink = "@" + databaselink.Trim('@');
                                //string s_field = v.f_get_field_name("", "v_giavp_truoc" + databaselink, "");
                                //s_field = s_field.Replace("idchinhanh", s_chinhanh + " as idchinhanh ");
                                //s_sql = "insert into medibv.v_giavp_truoc" + databaselink + " select " + s_field + " from medibv.v_giavp_truoc where done=0 and id not in(select id from medibv.v_giavp_truoc" + databaselink + " where done=0)";
                                //v.execute_data(s_sql);                               
                                s_sql = "select to_char(a.ngayhieuluc, 'dd/mm/yyyy') as ngayhl, a.* from medibv.v_giavp_truoc a where done = 0";                                
                                DataSet lds = v.get_data(s_sql);
                                //
                                v.databaselinks_name = databaselink;
                                decimal d_id = 0;
                                decimal d_idloai = 0;
                                decimal d_stt = 0;
                                decimal d_bhyt = 0;
                                decimal d_giath = 0;
                                decimal d_giabh = 0;
                                decimal d_giadv = 0;
                                decimal d_giann = 0;
                                decimal d_giaksk = 0;
                                decimal d_giacs = 0;
                                decimal d_ptth = 0;//phu thu
                                decimal d_ptdv = 0;
                                decimal d_ptnn = 0;
                                decimal d_ptcs = 0;
                                decimal d_userid = 0;
                                int i_tuyen = 0;
                                int i_bbhoichan = 0;
                                int i_giaycamdoan = 0;
                                int i_hsngoaitru = 0;
                                int i_kythuatcao = -1;
                                foreach (DataRow r1 in lds.Tables[0].Rows)
                                {

                                    d_id = (r1["id"].ToString() == "") ? 0 : decimal.Parse(r1["id"].ToString());
                                    d_idloai = (r1["id_loai"].ToString() == "") ? 0 : decimal.Parse(r1["id_loai"].ToString());
                                    d_stt = (r1["stt"].ToString() == "") ? 0 : decimal.Parse(r1["stt"].ToString());
                                    d_bhyt = (r1["bhyt"].ToString() == "") ? 0 : decimal.Parse(r1["bhyt"].ToString());
                                    d_giath = (r1["gia_th"].ToString() == "") ? 0 : decimal.Parse(r1["gia_th"].ToString());
                                    d_giabh = (r1["gia_bh"].ToString() == "") ? 0 : decimal.Parse(r1["gia_bh"].ToString());
                                    d_giadv = (r1["gia_dv"].ToString() == "") ? 0 : decimal.Parse(r1["gia_dv"].ToString());
                                    d_giann = (r1["gia_nn"].ToString() == "") ? 0 : decimal.Parse(r1["gia_nn"].ToString());
                                    d_giaksk = (r1["gia_ksk"].ToString() == "") ? 0 : decimal.Parse(r1["gia_ksk"].ToString());
                                    d_giacs = (r1["gia_cs"].ToString() == "") ? 0 : decimal.Parse(r1["gia_cs"].ToString());
                                    d_ptth = (r1["phuthu_th"].ToString() == "") ? 0 : decimal.Parse(r1["phuthu_th"].ToString());//phu thu
                                    d_ptdv = (r1["phuthu_dv"].ToString() == "") ? 0 : decimal.Parse(r1["phuthu_dv"].ToString());
                                    d_ptnn = (r1["phuthu_nn"].ToString() == "") ? 0 : decimal.Parse(r1["phuthu_nn"].ToString());
                                    d_ptcs = (r1["phuthu_cs"].ToString() == "") ? 0 : decimal.Parse(r1["phuthu_cs"].ToString());
                                    d_userid = (r1["userid"].ToString() == "") ? 0 : decimal.Parse(r1["userid"].ToString());
                                    i_tuyen = (r1["tuyen"].ToString() == "") ? 7 : int.Parse(r1["tuyen"].ToString());
                                    i_bbhoichan = (r1["hoichan"].ToString() == "") ? 0 : int.Parse(r1["hoichan"].ToString());
                                    i_giaycamdoan = (r1["giaycamdoan"].ToString() == "") ? 0 : int.Parse(r1["giaycamdoan"].ToString());
                                    i_hsngoaitru = (r1["hsngoaitru"].ToString() == "") ? 0 : int.Parse(r1["hsngoaitru"].ToString());
                                    i_kythuatcao = (r1["kythuat"].ToString() == "") ? 0 : int.Parse(r1["kythuat"].ToString());
                                    //
                                    v.upd_v_giavp_truoc(d_id, d_idloai, d_stt, r1["ma"].ToString(), r1["ten"].ToString(), r1["dvt"].ToString(),
                                        d_bhyt, d_giath, d_giabh, d_giadv, d_giann, d_giaksk, d_giacs, d_ptth, d_ptdv, d_ptnn, d_ptcs, d_userid, s_chinhanh, r1["ngayhl"].ToString(),
                                        i_tuyen, r1["cnapdung"].ToString(), r1["tiepnhancv_cn1"].ToString(), r1["tiepnhancv_cn2"].ToString(), r1["tiepnhancv_cn3"].ToString(), r1["tiepnhancv_cn4"].ToString(), r1["tiepnhancv_cn5"].ToString(), r1["tiepnhancv_cn6"].ToString(),
                                        i_bbhoichan, i_giaycamdoan, i_hsngoaitru, i_kythuatcao, "", r1["doituongapdung"].ToString(), r1["maluong"].ToString());
                                }
                                v.databaselinks_name = "";
                            }
                        }
                    }
                    v.databaselinks_name = "";
                }
            }            
        }

        private void cbchinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbchinhanh || sender == null)
            {
                Cursor = Cursors.WaitCursor;
                if (chkgiavptg.Checked) f_Load_NgayHieuluc();
                if (chkgiavp.Checked) f_Load_Dongia_goc();
                else f_Load_DG(cbNgayHieuluc.Text);

                Cursor = Cursors.Default;
            }
        }

        private void butImpExcel_Click(object sender, EventArgs e)
        {
            frmDsexcel f = new frmDsexcel(v, m_userid);
            if (txtNgayhieuluc.Text.Trim() != "/  /") f.s_ngayhieuluc = txtNgayhieuluc.Text;
            f.LoaiImport = (int)LibVP.AccessData.IDLoaiImport.Import_DMKT_gia;
            f.ShowDialog();
            if (f.s_ngayhieuluc.Trim() != "") txtNgayhieuluc.Text = f.s_ngayhieuluc;
        }

        private void chkgiavptg_Click(object sender, EventArgs e)
        {
            cbNgayHieuluc.Enabled = chkgiavptg.Checked;
            f_Load_NgayHieuluc();
            if (cbNgayHieuluc.Items.Count > 0) cbNgayHieuluc.SelectedIndex = 0;
            if (cbNgayHieuluc.SelectedIndex >= 0)
            {
                f_Load_DG(cbNgayHieuluc.Text);
            }
            else
            {
                f_Load_DG("");
            }
        }
        private void f_Load_NgayHieuluc()
        {
            sdbclient = "";
            if (cbchinhanh.SelectedValue.ToString() != ichinhanh.ToString())
            {
                DataRow r = v.getrowbyid(dschinhanh.Tables[0], "id=" + cbchinhanh.SelectedValue.ToString());
                if (r != null) sdbclient = r["database"].ToString();
                sdbclient = "@" + sdbclient.Trim('@');
            }
            //
            string asql = "select distinct to_char(ngayhieuluc,'dd/mm/yyyy') as ngayhieuluc, to_char(ngayhieuluc,'yyyymmdd') as ngayhieuluc1 from medibv.v_giavp_truoc" + sdbclient + " order by to_char(ngayhieuluc,'yyyymmdd') desc ";
            DataSet lds = v.get_data(asql);
            cbNgayHieuluc.DataSource = lds.Tables[0];
            cbNgayHieuluc.DisplayMember = "ngayhieuluc";
            cbNgayHieuluc.ValueMember = "ngayhieuluc";
            
        }

        private void cbNgayHieuluc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.ActiveControl == cbNgayHieuluc || sender == null)
            //{
                if (cbNgayHieuluc.SelectedIndex >= 0) f_Load_DG(cbNgayHieuluc.Text);
                else f_Load_DG("");
            //}
        }

        private void chkgiavp_Click(object sender, EventArgs e)
        {
            if (chkgiavp.Checked)
            {
                f_Load_Dongia_goc();
            }
        }
    }
}