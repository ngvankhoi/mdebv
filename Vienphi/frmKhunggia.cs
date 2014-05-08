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
    public partial class frmKhunggia : Form
    {
        string s_user = "medibv";
        int i_userid = 0;
        AccessData v = null;
        DataSet ds = new DataSet();
        public frmKhunggia(AccessData _v, int _userid)
        {
            InitializeComponent();
            v = _v;
            i_userid = _userid;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        void load_grid(string _ngay,bool moi)
        {
            Cursor = Cursors.WaitCursor;
            string sql = "select a.id,a.ma,a.ten,a.dvt,";
            if (moi)
            {
                sql += "a.gia_th as gia_th,a.gia_bh,a.gia_cs,a.gia_dv,a.gia_nn,a.gia_ksk,a.vattu_th,a.vattu_bh,a.vattu_cs,a.vattu_dv,a.vattu_nn,a.vattu_ksk,a.thuong,a.bhyt,a.hide";
            }
            else
            {
                sql += "nvl(b.gia_th,a.gia_th) as gia_th,nvl(b.gia_bh,a.gia_bh) as gia_bh,nvl(b.gia_cs,a.gia_cs) as gia_cs,nvl(b.gia_dv,a.gia_dv) as gia_dv,nvl(b.gia_nn,a.gia_nn) as gia_nn,nvl(b.gia_ksk,a.gia_ksk) as gia_ksk," +
                    "nvl(b.vattu_th,a.vattu_th) as vattu_th,nvl(b.vattu_bh,a.vattu_bh) as vattu_bh,nvl(b.vattu_cs,a.vattu_cs) as vattu_cs,nvl(b.vattu_dv,a.vattu_dv) as vattu_dv," +
                    "nvl(b.vattu_nn,a.vattu_nn) as vattu_nn,nvl(b.vattu_ksk,a.vattu_ksk) as vattu_ksk,nvl(b.thuong,a.thuong) as thuong,nvl(b.bhyt,a.bhyt) as bhyt,nvl(b.hide,a.hide) as hide ";
            }
            sql += ",a.id_loai,c.id_nhom ";
            sql += " from " + s_user + ".v_giavp a,";
            if (!moi) { sql += "(select * from " + s_user + ".v_khunggia where to_char(ngay,'dd/mm/yyyy')='" + txtNgay.Text + "') b,"; }
            sql+= s_user + ".v_loaivp c where a.id_loai=c.id";
            if (!moi) { sql += " and a.id=b.id_vp(+) "; }
            if (chkChihiennhungdichvuconsudung.Checked)
            {
                sql += " and a.hide=0";
            }
            sql += " order by a.ten,a.dvt";
            ds = v.get_data(sql);
            dgvGiavp.DataSource = ds.Tables[0];
            dgvGiavp.ReadOnly = !moi;
            set_control(true);
            Cursor = Cursors.Default;
        }
        void set_control(bool ena)
        {
            dgvGiavp_id_vp.ReadOnly = ena;
            dgvGiavp_ma.ReadOnly = ena;
            dgvGiavp_ten.ReadOnly = ena;
            dgvGiavp_dvt.ReadOnly = ena;
        }
        void load_ngay()
        {
            string sql = "select distinct to_char(ngay,'dd/mm/yyyy') as ngay from " + s_user + ".v_khunggia b order by ngay desc";
            DataSet tmp = new DataSet();
            tmp = v.get_data(sql);
            cboNgay.DataSource = tmp.Tables[0];
            if (cboNgay.Items.Count > 0)
            {
                cboNgay.SelectedIndex = 0;
                cboNgay_SelectedIndexChanged(null, null);
            }
        }
        private void butRefresh_Click(object sender, EventArgs e)
        {
            cboNgay.BringToFront();
            if (cboNgay.SelectedIndex == -1 && cboNgay.Items.Count > 0)
            {
                cboNgay.SelectedIndex = 0;
            }
            load_grid(cboNgay.Text, false);
        }
        private void butEdit_Click(object sender, EventArgs e)
        {
            cboNgay.SendToBack();
            txtNgay.Value = v.StringToDate(cboNgay.Text);
            //load_grid(cboNgay.Text,false);
            dgvGiavp.ReadOnly = false;
            set_control(true);
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int i_table = v.tableid("", "v_khunggia");
            v.upd_eve_tables(i_table, i_userid, "ins");
            DataSet tmp = ds.GetChanges();
            if (tmp != null)
            {
                foreach (DataRow r in tmp.Tables[0].Rows)
                {
                    v.execute_data("insert into " + s_user + ".eve_upd_del(tableid,ngay,computerid,command,noidung) select " +
                    i_table + ",sysdate,-1,'ins',id_vp||'^'||gia_th||'^'||gia_bh||'^'||gia_dv||'^'||gia_nn||'^'||gia_ksk||'^'||gia_cs||'^'||vattu_th"+
                    "||'^'||vattu_bh||'^'||vattu_dv||'^'||vattu_nn||'^'||vattu_ksk||'^'||vattu_cs from " + s_user + ".v_khunggia where id_vp=" + r["id"].ToString());
                    v.upd_v_khunggia(int.Parse(r["id"].ToString()), decimal.Parse(r["gia_th"].ToString()), decimal.Parse(r["gia_bh"].ToString()),
                        decimal.Parse(r["gia_dv"].ToString()), decimal.Parse(r["gia_nn"].ToString()), decimal.Parse(r["gia_ksk"].ToString()),
                        decimal.Parse(r["gia_cs"].ToString()), decimal.Parse(r["vattu_th"].ToString()), decimal.Parse(r["vattu_bh"].ToString()),
                        decimal.Parse(r["vattu_dv"].ToString()), decimal.Parse(r["vattu_nn"].ToString()), decimal.Parse(r["vattu_ksk"].ToString()),
                        decimal.Parse(r["vattu_cs"].ToString()), int.Parse(r["thuong"].ToString()), decimal.Parse(r["bhyt"].ToString()),
                        i_userid, int.Parse(r["hide"].ToString()), txtNgay.Text);
                }
            }
            load_ngay();
            cboNgay.BringToFront();
            Cursor = Cursors.Default;
        }

        private void frmKhunggia_Load(object sender, EventArgs e)
        {
            s_user = v.user;
            dgvGiavp.AutoGenerateColumns = false;
            cboNgay.DisplayMember = "NGAY";
            cboNgay.ValueMember = "NGAY";
            Load_Treeview();
            chkChihiennhungdichvuconsudung.Checked = (v.Thongso(chkChihiennhungdichvuconsudung.Name) == "1");
            load_ngay();
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            cboNgay.SelectedIndex = -1;
            cboNgay.SendToBack();
            txtNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            load_grid(txtNgay.Text, true);
        }

        private void cboNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cboNgay || (Control)sender==null)
            {
                txtNgay.Value = v.StringToDate(cboNgay.Text);
                load_grid(cboNgay.Text, false);
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            text.Text = "";
        }

        private void txtTimngay_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == txtTimngay)
            {
                CurrencyManager manager = (CurrencyManager)BindingContext[cboNgay.DataSource];
                DataView dv = (DataView)manager.List;
                dv.RowFilter = "ngay like '%" + txtTimngay.Text + "%'";
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == txtTim)
            {
                CurrencyManager manager = (CurrencyManager)BindingContext[dgvGiavp.DataSource];
                DataView dv = (DataView)manager.List;
                string exp = "ten like '%" + txtTim.Text + "%'";
                string s_nhom = "", s_loai = "";
                if (treeView1.Tag != null)
                {
                    string _tag = treeView1.Tag.ToString();
                    string[] s_tag = _tag.Split(':');
                    s_nhom = s_tag[0];
                    s_loai = s_tag[1];
                    if (s_nhom != "?")
                    {
                        exp += " and id_nhom=" + s_nhom;
                        if (s_loai != "?")
                        {
                            exp += " and id_loai="+s_loai;
                        }
                    }
                }
                dv.RowFilter = exp;
            }
        }

        private void butApgia_Click(object sender, EventArgs e)
        {
            Language lan = new Language();
            if (MessageBox.Show(lan.Change_language_MessageText("Bạn có đồng ý chuyển khung giá ngày") + ": " + txtNgay.Text + " " +
                lan.Change_language_MessageText("vào bảng giá hiện đang sử dụng tại bệnh viện không") + "?", "Medisoft 2009",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                v.upd_eve_tables(84, i_userid, "apkhunggia");
                v.upd_eve_upd_del(84, i_userid, "apkhunggia", txtNgay.Text);
                v.execute_data("update " + s_user + ".v_khunggia set apgia=apgia+1 where to_char(ngay,'dd/mm/yyyy')='" + txtNgay.Text + "'");
                v.execute_data("delete from " + s_user + ".v_giavp_daapgia where to_char(ngay,'dd/mm/yyyy')='" + txtNgay.Text + "'");
                v.execute_data("insert into " + s_user + ".v_giavp_daapgia(id_vp,ngay ,gia_th ,gia_bh ,gia_cs ,gia_dv ,gia_nn ,vattu_th ,vattu_bh,vattu_cs ," +
                    "vattu_dv ,vattu_nn ,bhyt ,thuong ,hide ,userid ,ngayud ,gia_ksk ,vattu_ksk) select a.id,b.ngay ,a.gia_th ,a.gia_bh ,a.gia_cs ,a.gia_dv ,a.gia_nn ,a.vattu_th ,a.vattu_bh,a.vattu_cs ," +
                    "a.vattu_dv ,a.vattu_nn ,a.bhyt ,a.thuong ,a.hide ,a.userid ,a.ngayud ,a.gia_ksk ,a.vattu_ksk from " + s_user + ".v_giavp a,"+s_user+".v_khunggia b where b.id_vp=a.id and to_char(b.ngay,'dd/mm/yyyy')='" + txtNgay.Text + "'");
                string s_Sql = "select b.id_vp,b.gia_th,b.gia_bh,b.gia_dv,b.gia_cs,b.gia_ksk,b.gia_nn,b.vattu_th,b.vattu_bh,b.vattu_dv,b.vattu_cs," +
                    "b.vattu_ksk,b.vattu_nn,b.thuong,b.hide,b.bhyt from " + s_user + ".v_khunggia b,"+s_user+".v_giavp a where b.id_vp=a.id and to_char(b.ngay,'dd/mm/yyyy')='" + txtNgay.Text + "'";
                foreach (DataRow r in v.get_data(s_Sql).Tables[0].Rows)
                {
                    v.execute_data("update " + s_user + ".v_giavp a set gia_th=" + Convert.ToDecimal(r["gia_th"]).ToString() + ",gia_bh=" + Convert.ToDecimal(r["gia_bh"]).ToString() + "," +
                        "gia_dv=" + Convert.ToDecimal(r["gia_dv"]).ToString() + ",gia_cs=" + Convert.ToDecimal(r["gia_cs"]).ToString() + "," +
                        "gia_ksk=" + Convert.ToDecimal(r["gia_ksk"]).ToString() + ",gia_nn=" + Convert.ToDecimal(r["gia_nn"]).ToString() + "," +
                        "vattu_th=" + Convert.ToDecimal(r["vattu_th"]).ToString() + ",vattu_bh=" + Convert.ToDecimal(r["vattu_bh"]).ToString() + "," +
                        "vattu_dv=" + Convert.ToDecimal(r["vattu_dv"]).ToString() + ",vattu_cs=" + Convert.ToDecimal(r["vattu_cs"]).ToString() + "," +
                        "vattu_ksk=" + Convert.ToDecimal(r["vattu_ksk"]).ToString() + ",vattu_nn=" + Convert.ToDecimal(r["vattu_nn"]).ToString() + "," +
                        "thuong=" + Convert.ToInt32(r["thuong"]).ToString() + ",hide=" + Convert.ToInt32(r["hide"]).ToString() + "," +
                        "bhyt=" + Convert.ToInt32(r["bhyt"]).ToString() + " where id=" + Convert.ToInt32(r["id_vp"]).ToString());
                }
            }
        }

        void Load_Treeview()
        {
            try
            {
                treeView1.Nodes.Clear();
                TreeNode node_nhom, node_loai;
                DataSet dsloai, dsnhom;
                string s_sort = "ten";
                node_nhom = new TreeNode("Tất cả");
                node_nhom.Tag = "?:?";
                treeView1.Nodes.Add(node_nhom);

                dsnhom = v.f_get_v_nhomvp_frmgiavp();
                dsloai = v.f_get_v_loaivp_frmgiavp();
                foreach (DataRow r in dsnhom.Tables[0].Select("", s_sort))
                {
                    node_nhom = new TreeNode(r["ten"].ToString());
                    node_nhom.Tag = r["ma"].ToString() + ":?";
                    treeView1.Nodes.Add(node_nhom);
                    foreach (DataRow r1 in dsloai.Tables[0].Select("id_nhom=" + r["ma"].ToString(), s_sort))
                    {
                        node_loai = new TreeNode(r1["ten"].ToString());
                        node_loai.Tag = r["ma"].ToString() + ":" + r1["id"].ToString();
                        node_nhom.Nodes.Add(node_loai);
                    }
                }
            }
            catch
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((e.Action == TreeViewAction.ByMouse) || (e.Action == TreeViewAction.ByKeyboard))
            {
                TreeNode node = treeView1.SelectedNode;
                string s_tag= node.Tag.ToString();
                treeView1.Tag = s_tag;
                if (s_tag != null)
                {
                    string[] _tag = s_tag.Split(':');
                    string s_nhom = _tag[0];
                    string s_loai = _tag[1];
                    CurrencyManager manager = (CurrencyManager)BindingContext[dgvGiavp.DataSource];
                    DataView dv = (DataView)manager.List;
                    if (s_loai != "?")
                    {
                        dv.RowFilter = "id_loai = " + s_loai;
                    }
                    else
                    {
                        if (s_nhom == "?")
                        {
                            dv.RowFilter = "";
                        }
                        else
                        {
                            dv.RowFilter = "id_nhom = " + s_nhom;
                        }
                    }
                }
            }
        }

        private void dgvGiavp_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGiavp.DataSource != null)
            {
                int iRow = e.RowIndex;
                DataGridViewRow row = dgvGiavp.Rows[iRow];
                if (row.Cells[dgvGiavp_hide.Name].Value.ToString() == "1")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void dgvGiavp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGiavp.DataSource != null)
            {
                int iRow = e.RowIndex;
                DataGridViewRow row = dgvGiavp.Rows[iRow];
                if (row.Cells[dgvGiavp_hide.Name].Value.ToString() == "1")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.MidnightBlue;
                }
            }
        }

        private void frmKhunggia_FormClosing(object sender, FormClosingEventArgs e)
        {
            v.writeXml("v_thongso", chkChihiennhungdichvuconsudung.Name, chkChihiennhungdichvuconsudung.Checked ? "1" : "0");
        }

        private void butExcel_Click(object sender, EventArgs e)
        {
            if (cboNgay.SelectedIndex != -1 && ds != null)
            {
                v.f_export_excel(ds.Tables[0], "BANG_GIA_VIEN_PHI_AP_DUNG_NGAY_" + txtNgay.Text.Replace("/","_"));
            }
        }

        private void chkChihiennhungdichvuconsudung_CheckedChanged(object sender, EventArgs e)
        {
            cboNgay.BringToFront();
            if (cboNgay.SelectedIndex == -1 && cboNgay.Items.Count > 0)
            {
                cboNgay.SelectedIndex = 0;
            }
            load_grid(cboNgay.Text, false);
        }

        private void dgvGiavp_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int icol = e.ColumnIndex;
            int irow = e.RowIndex;
            if (icol >= 0 && irow >= 0)
            {
                string val = dgvGiavp[icol, irow].Value.ToString();
                if (val.Length >= dgvGiavp.Columns[icol].Width)
                {
                    dgvGiavp.Columns[icol].ToolTipText = val;
                }
            }
        }
    }
}