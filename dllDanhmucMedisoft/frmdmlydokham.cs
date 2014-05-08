using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dllDanhmucMedisoft
{
    public partial class frmdmlydokham : Form
    {
        LibMedi.AccessData m = new LibMedi.AccessData();
        Language lan = new Language();
        string sql = "";
        int id = 0;
        bool bSua = false;
        DataTable dt;
        public frmdmlydokham()
        {
            InitializeComponent();
        }

        private void frmdmlydokham_Load(object sender, EventArgs e)
        {
            cmbLoai.SelectedIndex = 0;
            load_grid();
            AddGridTableStyle();
            dataGrid1_CurrentCellChanged(null, null);
        }
        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt.TableName;
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
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Tên";
            TextCol.Width = 450;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "danhmuc";
            TextCol.HeaderText = "loại";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "ID";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "x";
            TextCol.HeaderText = "x";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);


        }

        private void load_grid()
        {
            dt = m.get_data("select id,ten,case when danhmuc=0 then 'Lựa chọn' else case when danhmuc=1 then 'Lấy danh mục' else 'Nhập tự do' end end danhmuc,danhmuc x from " + m.user + ".dmlydokham ").Tables[0];
            dataGrid1.DataSource = dt;
        }
        /*Lựa chọn
Lấy danh mục
Nhập tự do*/

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            id = 0;//binh 200611
            emp_detail();
            ena_object(true);
            ten.Focus();
        }

        public void emp_detail()
        {
            ten.Text = "";
            cmbLoai.SelectedIndex = 0;
        }
        private void ena_object(bool ena)
        {
            dataGrid1.Enabled = !ena;
            ten.Enabled = ena;
            cmbLoai.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butHuy.Enabled = !ena;
            butKetthuc.Enabled = !ena;
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            ena_object(true);
            ten.Focus();
            bSua = true;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            
            ena_object(false);
            dataGrid1_CurrentCellChanged(null, null);
            bSua = false;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (ten.Text.Trim() == "")
            {
                ten.Focus();
                return;
            }
            if(id==0)// if (!bSua)
            {
                sql = "select max(id)+1 from " + m.user + ".dmlydokham";
                dt = m.get_data(sql).Tables[0];
                if (dt.Rows[0][0].ToString().Trim() == "")
                    id = 1;
                else id = int.Parse(dt.Rows[0][0].ToString());
            }
            if (!m.upd_dmlydokham(id, ten.Text.Trim(), cmbLoai.SelectedIndex))
                MessageBox.Show("Không cập nhật được thông tin danh mục!", "Medisoft");
            load_grid();
            ena_object(false);
            dataGrid1_CurrentCellChanged(null, null);
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();
        }

        private void ref_text()
        {
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                ten.Text = dataGrid1[i, 0].ToString();
                cmbLoai.SelectedIndex = int.Parse(dataGrid1[i, 3].ToString());
                id = int.Parse(dataGrid1[i, 2].ToString());
            }
            catch { }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn có đồng ý xóa không?"), "Medisoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.No) return;
            sql = "select mmyy from " + m.user + ".table order by substr(mmyy,3,2) desc, substr(mmyy,1,2) desc";
            dt = m.get_data(sql).Tables[0];
            sql = "";
            int i_max = dt.Rows.Count;
            if (i_max > 2) i_max = 2;
            for (int i = 0; i < i_max; i++)
            {
                if (i > 0)
                    sql += " union all ";
                sql += "select maql from " + m.user + dt.Rows[i]["mmyy"].ToString() + ".lydokham where id_lydokham like '%+" + id + "+%'";
            }
            DataSet lds=m.get_data(sql);
            if (lds != null && lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Mục này đã được sử dụng, không thể xóa!"), "Medisoft");
                return;
            }
            m.execute_data("delete from " + m.user + ".dmlydokham where id=" + id);
            MessageBox.Show("Xóa thành công!", "Medisoft");
            load_grid();
            ena_object(false);
            dataGrid1_CurrentCellChanged(null, null);
        }

        private void ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}