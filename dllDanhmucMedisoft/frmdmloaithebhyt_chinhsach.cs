using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dllDanhmucMedisoft
{
    public partial class frmdmloaithebhyt_chinhsach : Form
    {
        LibMedi.AccessData m = new LibMedi.AccessData();
        Language lan = new Language();
        string sql = "", s_msg = "";
        int id = 0;
        bool bSua = false;
        DataTable dt;
        string ma = "";
        private int i_id = 0;
        public frmdmloaithebhyt_chinhsach()
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
            TextCol.Width =50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tu";
            TextCol.HeaderText = "Vị trí từ";
            TextCol.Width = 50;
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

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "trongtinh";
            TextCol.HeaderText = "Tỷ lệ trong tỉnh";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngoaitinh";
            TextCol.HeaderText = "Tỷ lệ ngoài tỉnh";
            TextCol.Width = 165;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "Id";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);


        }

        private void load_grid()
        {
            dt = m.get_data("select * from " + m.user + ".dmloaibhyt_chinhsach order by ma").Tables[0];
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
            i_id = 0;
            ten.Text = "";
            //cmbLoai.SelectedIndex = 0;
        }
        private void ena_object(bool ena)
        {
            ten.Enabled = ena;
            txtTu.Enabled = ena;
            txtDen.Enabled = ena;
            txtChieudai.Enabled = ena;
            txtTyletrongtinh.Enabled = ena;
            txtTylengoaitinh.Enabled = ena;
            chkKhongdung.Enabled = ena;
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
            if (txtTyletrongtinh.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập tỷ lệ chi trả trong tỉnh !"));
                txtTyletrongtinh.Focus();
                return;
            }
            if (txtTylengoaitinh.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập tỷ lệ chi trả chi trả ngoài tỉnh !"));
                txtTylengoaitinh.Focus();
                return;
            }
            if (decimal.Parse(txtTyletrongtinh.Text.Trim()) > 100 || decimal.Parse(txtTyletrongtinh.Text.Trim()) < 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ chi trả trong tỉnh không hợp lệ !"));
                txtTyletrongtinh.Focus();
                return;
            }
            if (decimal.Parse(txtTylengoaitinh.Text.Trim()) > 100 || decimal.Parse(txtTylengoaitinh.Text.Trim()) < 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ chi trả ngoài tỉnh không hợp lệ !"));
                txtTylengoaitinh.Focus();
                return;
            }
            if (i_id == 0) i_id = get_id();
            if (!m.upd_dmloaibhyt_chinhsach(i_id,ten.Text, int.Parse(txtTu.Text.Trim()), int.Parse(txtDen.Text.Trim()), int.Parse(txtChieudai.Text.Trim()), int.Parse(txtTyletrongtinh.Text.Trim()), int.Parse(txtTylengoaitinh.Text.Trim()),int.Parse(chkKhongdung.Checked ? "1" : "0")))
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin danh mục!"),s_msg);
            load_grid();
            ena_object(false);
            dataGrid1_CurrentCellChanged(null, null);
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();
        }
        private int get_id()
        {
            string s_id = "";
            try
            {
                s_id = m.get_data("select max(id)+1 as id from ( select max(id) as id from medibv.dmloaibhyt_chinhsach union all select to_number('1') as id from dual)").Tables[0].Rows[0][0].ToString();
            }
            catch { s_id = "1"; }
            return int.Parse(s_id);
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
                txtTyletrongtinh.Text = dataGrid1[i, 4].ToString();
                txtTylengoaitinh.Text = dataGrid1[i, 5].ToString();
                i_id = int.Parse(dataGrid1[i, 6].ToString() == "" ? "0" : dataGrid1[i, 6].ToString());
                
                ma = ten.Text;
            }
            catch { }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn xóa không ?"),"",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                m.execute_data("delete from " + m.user + ".dmloaibhyt_chinhsach where id=" + i_id);
                load_grid();
                ena_object(false);
                dataGrid1_CurrentCellChanged(null, null);
            }
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

        private void txtTyletrongtinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtTylengoaitinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtTyletrongtinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//&& e.KeyChar != '.'
            {
                e.Handled = true;
            }
        }
        }
    }
