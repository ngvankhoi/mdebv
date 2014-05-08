using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;
namespace dllDanhmucMedisoft
{
    public partial class frmTrieuchung : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        DataSet ds = new DataSet();
        AccessData m = new AccessData();
        int i_userid = 0;
        public frmTrieuchung(int userid)
        {
            InitializeComponent();
            i_userid = userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }
        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
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
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "STT";
            TextCol.Width = 35;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Tên";
            TextCol.Width = 320;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void frmTrieuchung_Load(object sender, EventArgs e)
        {
            cboLoai.DataSource = m.get_data("select * from " + m.user + ".trieuchungl order by stt").Tables[0];
            cboLoai.DisplayMember = "TEN";
            cboLoai.ValueMember = "ID";
            if (cboLoai.Items.Count > 0)
            {
                cboLoai.SelectedIndex = 0;
                load_grid(int.Parse(cboLoai.SelectedValue.ToString()));
            }
            else load_grid(0);
            AddGridTableStyle();
            ref_text();
            butThem.Focus();
        }
        void load_grid(int i_loai)
        {
            string user = m.user;
            ds = m.get_data("select * from " + user + ".trieuchungct where idloai=" + i_loai);
            dataGrid1.DataSource = ds.Tables[0];
        }
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();
        }
        void ref_text()
        {
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                txtStt.Value = decimal.Parse(dataGrid1[i, 0].ToString());
                txtId.Text = dataGrid1[i, 1].ToString();
                txtLoai.Text = dataGrid1[i, 2].ToString();
            }
            catch { }
        }

        private void txtLoai_Enter(object sender, EventArgs e)
        {
            txtLoai.SelectAll();
            txtLoai.BackColor = SystemColors.Info;
        }

        private void txtLoai_Leave(object sender, EventArgs e)
        {
            txtLoai.BackColor = Color.White;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            string user=m.user;
            int i_id = txtId.Text == "" ? 0 : int.Parse(txtId.Text);
            if (i_id == 0)
            {
                foreach (DataRow r in m.get_data("select max(id) id from " + user + ".trieuchungct").Tables[0].Rows)
                    i_id = r["id"].ToString().Trim() == "" ? 1 : int.Parse(r["id"].ToString()) + 1;
            }
            if (!m.upd_trieuchungct(i_id,int.Parse(cboLoai.SelectedValue.ToString()),(int)txtStt.Value, txtLoai.Text.Trim(),i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin"), LibMedi.AccessData.Msg);
                return;
            }
            load_grid(int.Parse(cboLoai.SelectedValue.ToString()));
            dataGrid1.Enabled = true;
            cboLoai.Enabled = true;
            txtStt.Enabled = false;
            txtLoai.Enabled = false;
            butThem.Focus();
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            dataGrid1.Enabled = false;
            cboLoai.Enabled = false;
            txtStt.Enabled = true;
            txtLoai.Enabled=true;
            txtLoai.Text = "";
            txtId.Text = "";
            txtLoai.Focus();
            foreach (DataRow r in m.get_data("select max(stt) stt from " + m.user + ".trieuchungct").Tables[0].Rows)
                txtStt.Value = r["stt"].ToString().Trim() == "" ? 1 : decimal.Parse(r["stt"].ToString()) + 1;
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            dataGrid1.Enabled = false;
            cboLoai.Enabled = false;
            ref_text();
            txtStt.Enabled = true;
            txtLoai.Enabled = true;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            txtStt.Enabled = false;
            txtLoai.Enabled = false;
            dataGrid1.Enabled = true;
            cboLoai.Enabled = true;
            ref_text();
        }

        private void txtLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            string user=m.user;
            if(MessageBox.Show(lan.Change_language_MessageText("Bạn có thật sự muốn xóa thông tin này không?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            {
                m.execute_data("delete from "+user+".trieuchungct where id="+txtId.Text);
            }
            load_grid(int.Parse(cboLoai.SelectedValue.ToString()));
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cboLoai) load_grid(int.Parse(cboLoai.SelectedValue.ToString()));
        }
    }
}