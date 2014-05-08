using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmDmemail : Form
    {
        DAL.Accessdata m;
        DataSet ds;
        string sql = "",user="";
        int i_userid = 0,id=0;
        bool bNew = false;

        public frmDmemail(DAL.Accessdata _m,int _userid)
        {
            InitializeComponent();
            m = _m;
            i_userid = _userid;
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void load_grid()
        {

            sql = "select * from " + user + ".dmemail order by id";
            ds = m.get_data(sql);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void frmDmemail_Load(object sender, EventArgs e)
        {
            user = m.userid;
            dataGridView1.AutoGenerateColumns = false;
            load_grid();
            dataGridView1_CellClick(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_chitiet();
        }

        private void load_chitiet()
        {
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                emp_text();
                return;
            }
            int index = dataGridView1.CurrentRow.Index;
            id = int.Parse(dataGridView1["c_id", index].Value.ToString());
            txtTen.Text = dataGridView1["c_ten", index].Value.ToString();
            txtTieude.Text = dataGridView1["c_tieude", index].Value.ToString();
            txtNoidung.Text = dataGridView1["c_noidung", index].Value.ToString();
        }

        private void emp_text()
        {
            txtTen.Text = "";
            txtTieude.Text = "";
            txtNoidung.Text = "";
        }

        private void ena_obj(bool ena)
        {
            txtTen.Enabled = ena;
            txtTieude.Enabled = ena;
            txtNoidung.Enabled = ena;
            butNew.Enabled = !ena;
            butSave.Enabled = ena;
            butEdit.Enabled = !ena;
            butDel.Enabled = !ena;
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            bNew = true;
            emp_text();
            ena_obj(true);
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            bNew = false;
            ena_obj(true);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            bNew = false;
            dataGridView1_CellClick(null, null);
            ena_obj(false);
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có đồng ý xóa Email?", "Medisoft THIS", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                sql="delete "+user+".dmemail where id="+id;
                m.execute_data(sql);
            }
            load_grid();
            dataGridView1_CellClick(null, null);
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (bNew)
            {
                try
                {
                    id = int.Parse(m.get_data("select max(id)+1 from " + user + ".dmemail").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    id = 1;
                }
            }
            if (!m.upd_dmemail(id, txtTen.Text.Trim(), txtTieude.Text.Trim(), txtNoidung.Text, i_userid, cmbloai.SelectedIndex))
            {
                MessageBox.Show("Không cập nhật được thông tin");
                return;
            }
            ena_obj(false);
            bNew = false;
            load_grid();
        }

        private void cmbloai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}