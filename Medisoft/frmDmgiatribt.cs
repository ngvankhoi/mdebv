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
    public partial class frmDmgiatribt : Form
    {
        Language lan = new Language();
        LibMedi.AccessData medi = new AccessData();
        private string s_sql = "", s_user = "";
        private DataSet ds;
        private int i_id = 0;
        public frmDmgiatribt(LibMedi.AccessData m)
        {
            InitializeComponent();
            s_user = m.user;
        }
        private void frmDmgiatribt_Load(object sender, EventArgs e)
        {
            dtgvGiatribt.AutoGenerateColumns = false;
            f_LoadGrid();
            butMoi.Focus();
        }
        private void f_LoadGrid()
        {
            s_sql = " select id,mach,nhietdo,huyetap,nhiptho,cannang,chieucao from " + s_user + ".dmgiatribt order by id";
            ds = new DataSet();
            ds = medi.get_data(s_sql);
            dtgvGiatribt.DataSource = ds.Tables[0];
        }
        private void f_EnableMacdinh(bool en)
        {
            butMoi.Enabled = en;
            butSua.Enabled = en;
            butBoqua.Enabled = !en;
            butLuu.Enabled = !en;
            butXoa.Enabled = en;
            butClose.Enabled = en;
        }
        
        private void dtgvGiatribt_CurrentCellChanged(object sender, EventArgs e)
        {
            if (ActiveControl == dtgvGiatribt)
            {
                try
                {
                    DataRowView r = (DataRowView)(dtgvGiatribt.CurrentRow.DataBoundItem);
                    txtid.Text = r["id"].ToString();
                    txtMach.Text = r["mach"].ToString();
                    txtNhietdo.Text = r["nhietdo"].ToString();
                    txtHuyetap.Text = r["huyetap"].ToString();
                    txtNhiptho.Text = r["nhiptho"].ToString();
                    txtCannang.Text = r["cannang"].ToString();
                    txtChieucao.Text = r["chieucao"].ToString();
                }
                catch { }
                f_EnableMacdinh(true);
                f_Enabletext(false);
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }
        private void f_Cleartext()
        {
            txtid.Text = "";
            txtMach.Text = "";
            txtNhietdo.Text = "";
            txtHuyetap.Text = "";
            txtNhiptho.Text = "";
            txtCannang.Text = "";
            txtChieucao.Text = "";
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            //f_Cleartext();
            f_EnableMacdinh(false);
            f_Enabletext(true);
            txtMach.Focus();
        }
        private void f_Enabletext(bool t)
        {
            txtMach.Enabled = t;
            txtNhietdo.Enabled = t;
            txtHuyetap.Enabled = t;
            txtNhiptho.Enabled = t;
            txtCannang.Enabled = t;
            txtChieucao.Enabled = t;

        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_EnableMacdinh(true);
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            //if (txtid.Text.Trim().ToString() == "")
            //    i_id = medi.get_capid_table("dmgiatribt");
            //else
            //    i_id = int.Parse(txtid.Text.Trim().ToString());
            //
            i_id = 1;//chi cho nhap 1 record
            //
            if (medi.upd_dmgiatribt(i_id, txtMach.Text.Trim(),txtNhietdo.Text.Trim(),txtHuyetap.Text.Trim().ToString(),txtNhiptho.Text.Trim().ToString(),txtCannang.Text.Trim().ToString(),txtChieucao.Text.Trim().ToString()))
            {
                f_LoadGrid();
                f_EnableMacdinh(true);
                f_Enabletext(true);
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Cập nhật không thành công."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMach.Focus();
                return;
            }
            butMoi.Focus();
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim().ToString() == "")
                i_id = medi.get_capid_table("dmgiatribt");
            else
                i_id = int.Parse(txtid.Text.Trim().ToString());
            if (medi.upd_dmgiatribt(i_id, txtMach.Text.Trim(), txtNhietdo.Text.Trim(), txtHuyetap.Text.Trim().ToString(), txtNhiptho.Text.Trim().ToString(), txtCannang.Text.Trim().ToString(), txtChieucao.Text.Trim().ToString()))
            {
                f_LoadGrid();
                f_EnableMacdinh(false);
                f_Enabletext(true);
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Cập nhật không thành công."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMach.Focus();
                return;
            }
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "") return;
            DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn có đồng ý xóa không?"), "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.No) return;
            if (medi.execute_data("delete from " + s_user + ".dmgiatribt where id=" + int.Parse(txtid.Text.Trim().ToString())))
            {
                f_LoadGrid();
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Cập nhật không thành công."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMach.Focus();
                return;
            }
        }
        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNhietdo.Focus();
        }
        private void txtChieucao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                butLuu.Focus();
        }

        private void txtNhietdo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtHuyetap.Focus();
        }

        private void txtHuyetap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNhiptho.Focus();
        }

        private void txtCannang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtChieucao.Focus();
        }

        private void txtNhiptho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCannang.Focus();
        }
    }
}