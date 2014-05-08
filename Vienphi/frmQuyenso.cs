using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmQuyenso : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private DataSet m_dsds;
        private string m_id = "", m_userid = "";
        private int itable;
        private bool bQuanly_chinhanh = false;
        public frmQuyenso(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            
//            lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
  //          lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1"); 
            m_v = v_v;
            m_userid = v_userid;
            m_v.f_SetEvent(this);
            
        }

        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            f_capnhat_db_danhmuc();
            bQuanly_chinhanh = m_v.bQuanly_Theo_Chinhanh;
            itable = m_v.tableid("", "v_quyenso");
            f_Load_Tree_Loai();
            f_Load_DG();
            if(bQuanly_chinhanh)f_loadchinhanh();
            f_Enable(false);
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_loadchinhanh()
        {
            DataSet dschinhanh = new DataSet();
            string sql = " select * from " + m_v.user + ".dmchinhanh order by ten ";
            dschinhanh = m_v.get_data(sql);
            cbchinhanh.DisplayMember = "ten";
            cbchinhanh.ValueMember = "id";
            cbchinhanh.DataSource = dschinhanh.Tables[0];
        }
        private void f_Load_Tree_Loai()
        {
            try
            {
                treeLoai.Nodes.Clear();
                treeLoai.CheckBoxes = true;
                treeLoai.ShowLines = false;
                treeLoai.ShowRootLines = false;
                TreeNode anode;
                foreach (DataRow r in m_v.get_data("select ma, ten from " + m_v.user + ".v_tenloaivp order by ten").Tables[0].Rows)
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["ma"].ToString();
                    treeLoai.Nodes.Add(anode);
                }
            }
            catch
            {
            }
        }
        private void f_Load_DG()
        {
            try
            {
               
                    string sql = "";
                    sql = "select a.id,a.sohieubl,a.sohieu,a.tu,a.den,a.soghi,case when a.dangsd is null then 0 else a.dangsd end as dangsd, case when a.khambenh is null then 0 else a.khambenh end as khambenh, a.loai, b.hoten,to_char(a.ngaylinh,'dd/mm/yyyy') as ngaylinh, a.userid,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.dichvu,a.chinhanh,a.hide from " + m_v.user + ".v_quyenso a inner join " + m_v.user + ".v_dlogin b on a.userid=b.id" + (m_v.sys_dungchungso ? "" : " and a.userid=" + m_userid);
               
                m_dsds = m_v.get_data(sql);
                if (m_dsds == null)
                {
                    m_v.execute_data("alter table " + m_v.user + ".v_quyenso add sohieubl text");
                    m_v.execute_data("update " + m_v.user + ".v_quyenso set sohieubl=sohieu where sohieubl is null");
                    m_v.execute_data("alter table " + m_v.user + ".v_quyenso add soghiam numeric(7) default -1"); 
                    m_dsds = m_v.get_data(sql);
                }
                dataGridView1.DataSource = m_dsds.Tables[0];
                toolStrip_Tim_TextChanged(null, null);
            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_Sua()
        {
            try
            {
                DataRowView arv = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                string sql = "";
                sql = "select a.id,a.sohieubl,a.sohieu,a.tu,a.den,a.soghi,case when a.dangsd is null then 0 else a.dangsd end as dangsd, case when a.khambenh is null then 0 else a.khambenh end as khambenh, a.loai, b.hoten,to_char(a.ngaylinh,'dd/mm/yyyy') as ngaylinh, a.userid from medibv.v_quyenso a left join medibv.v_dlogin b on a.userid=b.id where a.id="+arv["id"].ToString();
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    m_id = r["id"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtSohieubl.Text = r["sohieubl"].ToString();
                    txtSohieu.Text = r["sohieu"].ToString();
                    txtTuso.Text = r["tu"].ToString();
                    txtDenso.Text = r["den"].ToString();
                    txtSoghi.Text = r["soghi"].ToString();
                    txtNgaylinh.Value = m_v.f_parse_date(r["ngaylinh"].ToString());
                    f_Set_id_loai(r["loai"].ToString());
                    chkDangsd.Checked = r["dangsd"].ToString() == "1";
                    chkKhambenh.Checked = r["khambenh"].ToString() == "1";
                    chkHide.Checked = r["hide"].ToString() == "1";
                    txtTuso_Validated(null, null);
                    txtDenso_Validated(null, null);
                    txtSoghi_Validated(null, null);
                    break;
                }
            }
            catch
            {
            }
        }
        private void f_Load_View()
        {
            try
            {
                if (!butLuu.Enabled)
                {
                    DataRowView r = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                    m_id = r["id"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtSohieubl.Text = r["sohieubl"].ToString();
                    txtSohieu.Text = r["sohieu"].ToString();
                    txtTuso.Text = r["tu"].ToString();
                    txtDenso.Text = r["den"].ToString();
                    txtSoghi.Text = r["soghi"].ToString();
                    txtNgaylinh.Value = m_v.f_parse_date(r["ngaylinh"].ToString());
                    f_Set_id_loai(r["loai"].ToString());
                    chkDangsd.Checked = r["dangsd"].ToString() == "1";
                    chkHide.Checked = r["hide"].ToString() == "1";
                    chkKhambenh.Checked = r["khambenh"].ToString() == "1";
                    chkDichvu.Checked = r["dichvu"].ToString() == "1";
                    cbchinhanh.SelectedValue = r["chinhanh"].ToString();
                    txtTuso_Validated(null, null);
                    txtDenso_Validated(null, null);
                    txtSoghi_Validated(null, null);
                    f_Enable(false);
                }
            }
            catch//(Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
        private void f_Enable(bool v_bool)
        {
            butMoi.Enabled = !v_bool;
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool && m_id != "";
            butXoa.Enabled = !v_bool && m_id != "";
            butBoqua.Enabled = true;

            txtID.Enabled = false;
            txtSohieubl.Enabled = v_bool;
            txtSohieu.Enabled = v_bool;
            txtTuso.Enabled = v_bool;
            txtDenso.Enabled = v_bool;
            txtSoghi.Enabled = v_bool;
            txtNgaylinh.Enabled = v_bool;
            chkDangsd.Enabled = v_bool;
            chkKhambenh.Enabled = v_bool;
            chkDichvu.Enabled = v_bool;
            treeLoai.Enabled = v_bool;
            chkHide.Enabled = v_bool;
            cbchinhanh.Enabled = (bQuanly_chinhanh) ? v_bool : false;
        }
        private void f_Moi()
        {
            try
            {
                txtID.Text = "";
                txtSohieubl.Text = "";
                txtSohieu.Text = "";
                txtTuso.Text = "";
                txtDenso.Text = "";
                txtSoghi.Text = "";
                txtNgaylinh.Value = DateTime.Now;
                chkDangsd.Checked = false;
                chkKhambenh.Checked = false;
                f_Set_id_loai("");
                m_id = "";
                f_Enable(true);
                txtSohieubl.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void toolStrip_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            f_Load_View();
        }
        private void toolStrip_Tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                if (toolStrip_Tim.Text != "")
                {
                    aft = "sohieubl like '%" + toolStrip_Tim.Text.Replace("'","''") + "%' or sohieu like '%" + toolStrip_Tim.Text.Replace("'","''") + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách quyển sổ (") + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách quyển sổ");
            }
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private string f_Get_id_loai()
        {
            string r = "";
            try
            {
                foreach (TreeNode anode in treeLoai.Nodes)
                {
                    if (anode.Checked)
                    {
                        if (r.Length > 0)
                        {
                            r += ",";
                        }
                        r += anode.Tag.ToString();
                    }
                }
            }
            catch
            {
            }
            return r;
        }
        private void f_Set_id_loai(string v_id)
        {
            try
            {

                foreach (TreeNode anode in treeLoai.Nodes)
                {
                    anode.Checked = false;
                    foreach (string atmp in v_id.Split(','))
                    {
                        if (atmp == anode.Tag.ToString())
                        {
                            anode.Checked = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string aloai = f_Get_id_loai();
                if (txtSohieubl.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập ký hiệu sổ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSohieubl.Focus();
                    return;
                }
                if (txtSohieu.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập tên sổ!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSohieu.Focus();
                    return;
                }
                txtTuso_Validated(null, null);
                txtDenso_Validated(null, null);
                txtSoghi_Validated(null, null);
                decimal ats = 0, ads = 0, asoghi=0;
                ats = decimal.Parse(txtTuso.Text.Replace(" ",""));
                ads = decimal.Parse(txtDenso.Text.Replace(" ", ""));
                asoghi = decimal.Parse(txtSoghi.Text.Replace(" ", ""));
                if (asoghi > ads || asoghi < ats - 1)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Số liệu từ số, đến số, số ghi không hợp lệ!"), m_v.s_AppName, MessageBoxButtons.OK);
                    //\nĐiều kiện: [Từ số] <= [Số ghi -1]  <= [Đến số]"), m_v.s_AppName, MessageBoxButtons.OK);
                    txtSoghi.Focus();
                    return;
                }
                if (m_id == "")
                {
                    m_id = m_v.get_id_v_quyenso.ToString();
                }
                else
                {
                    if (m_v.dadung_v_quyenso(m_id) == -1)
                    {
                        if (!m_v.is_dba_admin(m_userid))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho sửa nội dung này!") + "\n" + lan.Change_language_MessageText("Liên hệ quản trị hệ thống để được trợ giúp!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                int tmp_chinhanh = (bQuanly_chinhanh) ? ((cbchinhanh.SelectedIndex < 0) ? 0 : int.Parse(cbchinhanh.SelectedValue.ToString())) : 0;
                m_v.upd_v_quyenso(decimal.Parse(m_id),txtSohieubl.Text.Trim(),txtSohieu.Text.Trim(),ats,ads,asoghi,aloai,chkKhambenh.Checked?1:0,chkDangsd.Checked?1:0,decimal.Parse(m_userid),txtNgaylinh.Text.Substring(0,10),chkHide.Checked?1:0);
                m_v.execute_data("update " + m_v.user + ".v_quyenso set dichvu=" + (chkDichvu.Checked ? "1" : "0") + " where id=" + m_id);
                m_v.execute_data(" update " + m_v.user + ".v_quyenso set chinhanh=" + tmp_chinhanh + " where id=" + m_id);
                f_Enable(false);
                f_Load_DG();
                butMoi.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            f_Enable(true);
            txtID.Focus();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.dadung_v_quyenso(m_id) != 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Quyển sổ này đã dùng không thể xoá !"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá quyển sổ này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (m_id != "0")
                        {
                            string s = m_v.fields(m_v.user+".v_quyenso", "id=" + m_id);
                            m_v.upd_eve_tables(itable, int.Parse(m_userid), "del");
                            m_v.upd_eve_upd_del(itable, int.Parse(m_userid), "del", s);
                        }

                        if (!m_v.del_v_quyenso(m_id))
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Quyển sổ này đã dùng không thể xoá !"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            f_Load_DG();
                            butBoqua_Click(null, null);
                        }
                    }
            }
            catch
            {
            }
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            try
            {
                f_Load_Sua();
                f_Enable(false);
                butMoi.Focus();
            }
            catch
            {
            }
        }
        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }
        private void txtSTT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtSohieubl_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSohieu.Text == "")
                    {
                        txtSohieu.Text = txtSohieubl.Text;
                    }
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtSohieu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSohieubl.Text == "")
                    {
                        txtSohieubl.Text = txtSohieu.Text;
                    }
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void chkReadonly_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butLuu.Focus();
                }
            }
            catch
            {
            }
        }

        private void butMedisoftcenter_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedisoftcenterupdate af = new frmMedisoftcenterupdate(m_v, m_userid, "DMBP");
                af.TopMost = true;
                af.ShowDialog();
            }
            catch
            {
            }
        }
        private void butLocal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog afo = new OpenFileDialog();
                afo.RestoreDirectory = true;
                afo.Filter = "Microsoft XML Document (*.XML)|*.xml";
                afo.Title = lan.Change_language_MessageText("Chọn file dữ liệu đã download từ Medisoft Center Update");
                afo.ShowDialog();
                if (afo.FileName != "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Cập nhật thành công!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void txtTuso_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtDenso_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtSoghi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtNgaylinh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void treeLoai_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void chkKhambenh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void chkDangsd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butLuu.Focus();
                }
            }
            catch
            {
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            f_Load_View();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            f_Load_View();
        }

        private void txtTuso_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal n = decimal.Parse(txtTuso.Text.Trim().Replace(" ", ""));
                if (n <= 0)
                {
                    n = 0;
                }
                txtTuso.Text = n.ToString("### ### ##0");
                if (txtSoghi.Text == "")
                {
                    txtSoghi.Text = (n-1).ToString("### ### ##0");
                }
            }
            catch
            {
                txtTuso.Text = "0";
            }
        }

        private void txtDenso_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal n = decimal.Parse(txtDenso.Text.Trim().Replace(" ", ""));
                if (n <= 0)
                {
                    n = 0;
                }
                txtDenso.Text = n.ToString("### ### ##0");
            }
            catch
            {
                txtDenso.Text = "0";
            }
        }

        private void txtSoghi_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal n = decimal.Parse(txtSoghi.Text.Trim().Replace(" ", ""));
                txtSoghi.Text = n.ToString("### ### ##0");
            }
            catch
            {
                txtSoghi.Text = "0";
            }
        }

        private void txtSohieubl_Validated(object sender, EventArgs e)
        {
        }
        public void f_capnhat_db_danhmuc()
        {
            string asql = "";
            DataSet lds = new DataSet();
            asql = "select dichvu from " + m_v.user + ".v_quyenso where id=0";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_quyenso add dichvu numeric(1) default 0";
                m_v.execute_data(asql);
            }
            ///30/06/2011
            asql = "select chinhanh from " + m_v.user + ".v_quyenso where 1=2";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_quyenso add chinhanh numeric(2,0) default 0";
                m_v.execute_data(asql);
            }

        }
    }
}