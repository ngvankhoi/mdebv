using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dllDanhmucMedisoft
{
    public partial class frmdmloaithebhyt : Form
    {
        LibMedi.AccessData m = new LibMedi.AccessData();
        Language lan = new Language();
        string sql = "", s_msg = "";
        int id = 0;
        bool bSua = false;
        DataTable dt;
        string ma = "";
        public frmdmloaithebhyt()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

        }

        private void frmdmloaithebhyt_Load(object sender, EventArgs e)
        {
            //cmbLoai.SelectedIndex = 0;
            load_grid();
            AddGridTableStyle();
            s_msg = LibMedi.AccessData.Msg;
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
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tu";
            TextCol.HeaderText = "Vị trí từ";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "den";
            TextCol.HeaderText = "Đến vị trí";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chieudai";
            TextCol.HeaderText = "Chiều dài thẻ";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);


        }

        private void load_grid()
        {
            dt = m.get_data("select * from " + m.user + ".dmloaibhyt ").Tables[0];
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
            emp_detail();
            ena_object(true);
            ten.Focus();
        }

        public void emp_detail()
        {
            ten.Text = "";
            //cmbLoai.SelectedIndex = 0;
        }
        private void ena_object(bool ena)
        {
            ten.Enabled = ena;
            txtTu.Enabled = ena;
            txtDen.Enabled = ena;
            txtChieudai.Enabled = ena;
            //cmbLoai.Enabled = ena;
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
            ten.Enabled = false;
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
            if (int.Parse(txtTu.Text.Trim()) > int.Parse(txtDen.Text.Trim()) || int.Parse(txtTu.Text.Trim()) > int.Parse(txtChieudai.Text.Trim()) || int.Parse(txtDen.Text.Trim()) > int.Parse(txtChieudai.Text.Trim()))
            {
                MessageBox.Show(lan.Change_language_MessageText("Vị trí không hợp lệ!"), s_msg);
                return;
            }

            if (!m.upd_dmloaibhyt(ten.Text, int.Parse(txtTu.Text.Trim()), int.Parse(txtDen.Text.Trim()), int.Parse(txtChieudai.Text.Trim())))
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin danh mục!"),s_msg);
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
                txtTu.Text = dataGrid1[i, 1].ToString();
                txtDen.Text = dataGrid1[i, 2].ToString();
                txtChieudai.Text = dataGrid1[i, 3].ToString();
                ma = ten.Text;
            }
            catch { }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            //sql = "select mmyy from " + m.user + ".table";
            //dt = m.get_data(sql).Tables[0];
            //sql = "";
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (i > 0)
            //        sql += " union all ";
            //    sql += "select * from " + m.user + dt.Rows[i]["mmyy"].ToString() + ".lydokham where id_lydokham like '%+" + id + "+%'";
            //}
            //if (m.get_data(sql).Tables[0].Rows.Count > 0)
            //{
            //    MessageBox.Show("Mục này đã được sử dụng, không thể xóa!", "Medisoft");
            //    return;
            //}
            m.execute_data("delete from " + m.user + ".dmloaibhyt where ma='" + ma+"'");
            MessageBox.Show(lan.Change_language_MessageText("Xóa thành công!"), s_msg);
            load_grid();
            ena_object(false);
            dataGrid1_CurrentCellChanged(null, null);
        }

        private void txtTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void ten_Validated(object sender, EventArgs e)
        {
            ten.Text = ten.Text.ToUpper();
        }

    }
}