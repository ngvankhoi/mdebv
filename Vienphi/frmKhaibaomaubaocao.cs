using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmKhaibaomaubaocao : Form
    {
        private string m_userid = "", user = "";
        private LibVP.AccessData m_v=new LibVP.AccessData();

        public frmKhaibaomaubaocao(string v_userid)
        {            
            InitializeComponent();
            m_userid = v_userid;            
            m_v.f_SetEvent(this);

        }

        private void frmKhaibaomaubaocao_Load(object sender, EventArgs e)
        {
            try
            {
                user = m_v.user;
                if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState=System.Windows.Forms.FormWindowState.Normal;
                m_v.execute_data("alter table medibv.v_maubaocao alter loai type number(3)");
                f_Display_User();
                f_Load_CB_Loai();
                f_Load_DG();
                DataGrid1.CaptionText = cbLoai_Tim.Text;
                f_Load_DG();
                txtTen.Tag = "";
                butMoi_Click(null, null);
                butBoqua_Click(null, null);
            }
            catch
            {
            }
        }
        private void f_Load_DG()
        {
            try
            {
                DataSet ads = m_v.get_data("select to_char(id) id, ma, a.ten, to_char(a.loai) loai, '' tenloai from medibv.v_maubaocao a order by a.loai asc, a.ten asc");
                for (int i = 0; i < ads.Tables[0].Rows.Count; i++)
                {
                    switch (ads.Tables[0].Rows[i]["loai"].ToString())
                    {
                        case "1":
                            ads.Tables[0].Rows[i]["tenloai"] = "Bảng kê thu viện phí trực tiếp";
                            break;
                        case "2":
                            ads.Tables[0].Rows[i]["tenloai"] = "Bảng kê thanh toán viện phí nội trú, ngoại trú";
                            break;
                        case "3":
                            ads.Tables[0].Rows[i]["tenloai"] = "Bảng kê thu tạm ứnng";
                            break;
                    }
                }
                AddGridTableStyle(ads);
                txtTim_TextChanged(null, null);
            }
            catch
            {
            }
        }

        private void f_Load_CB_Loai()
        {
            try
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Tables");
                ads.Tables[0].Columns.Add("MA");
                ads.Tables[0].Columns.Add("TEN");
                ads.Tables[0].Rows.Add(new string[] { "1", "1. Bảng kê thu viện phí trực tiếp" });
                ads.Tables[0].Rows.Add(new string[] { "2", "2. Bảng kê thanh toán ra viện" });
                ads.Tables[0].Rows.Add(new string[] { "3", "3. Bảng kê thu tạm ứng" });
                ads.Tables[0].Rows.Add(new string[] { "4", "4. Bảng kê miển giảm" });
                ads.Tables[0].Rows.Add(new string[] { "5", "5. Bảng kê hoàn trả" });
                ads.Tables[0].Rows.Add(new string[] { "6", "6. Báo cáo tổng hợp" });
                ads.Tables[0].Rows.Add(new string[] { "7", "7. Báo cáo chi tiết" });
                ads.Tables[0].Rows.Add(new string[] { "8", "8. Báo cáo chi phí bệnh nhân chưa thanh toán viện phí" });
                ads.Tables[0].Rows.Add(new string[] { "9", "9. Báo cáo chi phí điều trị trẻ em" });
                ads.Tables[0].Rows.Add(new string[] { "10", "10. Báo cáo hao phí" });
                ads.Tables[0].Rows.Add(new string[] { "11", "11. Danh sách phải thu (thanh toán ra viện)" });
                ads.Tables[0].Rows.Add(new string[] { "12", "12. Báo cáo số biên lai" });
                ads.Tables[0].Rows.Add(new string[] { "13", "13. Báo cáo thanh toán ra viện" });

                cbLoai.DisplayMember = "TEN";
                cbLoai.ValueMember = "MA";
                cbLoai.DataSource = ads.Tables[0];
                cbLoai.SelectedIndex = 0;

                DataSet ads1 = new DataSet();
                ads1 = ads.Copy();
                DataRow r = ads1.Tables[0].NewRow();
                r["ma"] = "";
                r["ten"] = "Tất cả";
                ads1.Tables[0].Rows.InsertAt(r, 0);

                cbLoai_Tim.DisplayMember = "TEN";
                cbLoai_Tim.ValueMember = "MA";
                cbLoai_Tim.DataSource = ads1.Tables[0];
                cbLoai_Tim.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        private void f_Display_User()
        {
            try
            {
                DataSet ads = m_v.get_data("select id, hoten from "+user+".v_dlogin where id=" + m_userid + "");
                lblNguoiDN.Text = "Người đăng nhập: " + ads.Tables[0].Rows[0]["hoten"].ToString();
                lblNgayLV.Text = "Ngày: " + f_Cur_Date();
            }
            catch
            {
                MessageBox.Show(this, "Chưa đăng nhập. Chỉ có quyền xem thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblNguoiDN.Text = "Người đăng nhập: <????>";
                lblNgayLV.Text = "Ngày: " + f_Cur_Date();
            }
        }
        private string f_Cur_Date()
        {
            try
            {
                return System.DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + System.DateTime.Now.Year.ToString();
            }
            catch
            {
                return "";
            }
        }

      

        private void butMoi_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtTen.Tag = "";

            txtMa.Enabled = true;
            txtTen.Enabled = true;
            cbLoai.Enabled = true;

            butMoi.Enabled = false;
            butLuu.Enabled = true;
            butHuy.Enabled = false;
            butSua.Enabled = false;
            txtMa.Focus();
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            cbLoai.Enabled = true;

            butMoi.Enabled = false;
            butLuu.Enabled = true;
            butHuy.Enabled = false;
            butSua.Enabled = false;

            txtMa.Focus();
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTen.Tag.ToString() != "")
                {
                    if (MessageBox.Show(this, "Đồng ý xoá?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        m_v.execute_data("delete from medibv.v_maubaocao where to_char(id)='" + txtTen.Tag.ToString().Trim() + "'");
                        f_Load_DG();
                        butMoi_Click(null, null);
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
                CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource, DataGrid1.DataMember];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
                dv.AllowDelete = false;
                dv.AllowEdit = false;
                string aid = "", aloai = "";

                if (txtMa.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(this, "Nhập vào tên report", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }

                if (txtTen.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(this, "Nhập vào diễn giải", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                try
                {
                    aloai = cbLoai.SelectedValue.ToString();
                }
                catch
                {
                    aloai = "";
                }

                if (aloai == "")
                {
                    MessageBox.Show(this, "Chọn loại bảng kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoai.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                try
                {
                    aid = decimal.Parse(txtTen.Tag.ToString().Trim()).ToString();
                }
                catch
                {
                    aid = "";
                }
                if (aid == "")
                {
                    try
                    {
                        aid = m_v.get_data("select nvl(max(id),0)+1 from medibv.v_maubaocao").Tables[0].Rows[0][0].ToString().Trim();
                    }
                    catch
                    {
                        aid = "1";
                    }
                }

                if ((txtMa.Text.Trim() != "") && (aid != ""))
                {
                    if (m_v.upd_maubaocao(decimal.Parse(aid), txtMa.Text.Trim(), txtTen.Text.Trim(), int.Parse(cbLoai.SelectedValue.ToString().Trim())))
                    {
                        txtTen.Tag = aid;
                    }

                }
                f_Load_DG();
                txtMa.Enabled = false;
                txtTen.Enabled = false;
                cbLoai.Enabled = false;

                butMoi.Enabled = true;
                butLuu.Enabled = false;
                butHuy.Enabled = true;
                butSua.Enabled = true;
                butMoi.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void cb_loaiBC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) butLuu.Focus();
        }

        private void cb_Loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTim_TextChanged(null, null);
        }

        private void DataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(DataGrid1.Tag.ToString()) >= 0)
                {
                    DataGrid1.UnSelect(int.Parse(DataGrid1.Tag.ToString()));
                }
            }
            catch
            {
                DataGrid1.Tag = "-1";
            }

            try
            {
                DataGrid1.Tag = DataGrid1.CurrentRowIndex;
                if (DataGrid1.CurrentRowIndex >= 0)
                {
                    DataGrid1.Select(int.Parse(DataGrid1.Tag.ToString()));
                }
            }
            catch
            {
                DataGrid1.Tag = "-1";
            }

            try
            {
                txtTen.Tag = "";
                CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource, DataGrid1.DataMember];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
                dv.AllowDelete = false;
                dv.AllowEdit = false;
                int i = DataGrid1.CurrentRowIndex;
                DataRow[] rs = dv.Table.Select("id='" + DataGrid1[DataGrid1.CurrentRowIndex, 0].ToString().Trim() + "'");
                if (rs.Length > 0)
                {
                    txtMa.Text = rs[0]["ma"].ToString();
                    txtTen.Text = rs[0]["ten"].ToString();
                    txtTen.Tag = rs[0]["id"].ToString();
                    try
                    {
                        cbLoai.SelectedValue = rs[0]["loai"].ToString();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            bool b = (txtTen.Tag.ToString() == "");
            txtMa.Enabled = b;
            txtTen.Enabled = b;
            cbLoai.Enabled = b;

            butLuu.Enabled = (txtTen.Tag.ToString() == "");
            butSua.Enabled = (txtTen.Tag.ToString() != "");
            butHuy.Enabled = (txtTen.Tag.ToString() != "");
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                if (txtTim.Text != "Tìm kiếm")
                {
                    aft = "(ma like '%" + txtTim.Text + "%' or ten like '%" + txtTim.Text + "%' or tenloai like '%" + txtTim.Text + "%')";
                    if (cbLoai_Tim.SelectedValue.ToString() != "")
                    {
                        aft = aft + " and loai='" + cbLoai_Tim.SelectedValue.ToString() + "'";
                    }
                }
                else
                {
                    if (cbLoai_Tim.SelectedValue.ToString() != "")
                    {
                        aft = "loai='" + cbLoai_Tim.SelectedValue.ToString() + "'";
                    }
                }
                CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource, DataGrid1.DataMember];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
                dv.AllowEdit = false;
                dv.RowFilter = aft;
                int n1 = dv.Table.Select(aft).Length;
                //int n = 270;

                if (DataGrid1.CurrentCell.RowNumber >= n1)
                {
                    try
                    {
                        DataGrid1.CurrentRowIndex = n1 - 1;
                    }
                    catch
                    {
                    }
                }

                //if (n1 > 19)
                //{
                //    DataGrid1.TableStyles[0].GridColumnStyles[1].Width = DataGrid1.Width - n - 16;
                //}
                //else
                //{
                //    DataGrid1.TableStyles[0].GridColumnStyles[1].Width = DataGrid1.Width - n;
                //}
                DataGrid1.CaptionText = cbLoai_Tim.Text + ": " + n1.ToString();
            }
            catch
            {
                DataGrid1.CaptionText = cbLoai_Tim.Text;
            }
        }

        private void AddGridTableStyle(DataSet v_ds)
        {
            try
            {
                DataGrid1.TableStyles.Clear();
                DataGrid1.AllowSorting = true;
                DataGridColoredTextBoxColumn TextCol;
                delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
                DataGridTableStyle ts = new DataGridTableStyle();
                ts.MappingName = v_ds.Tables[0].TableName;
                ts.AlternatingBackColor = Color.LightYellow;
                ts.BackColor = Color.White;
                ts.ForeColor = Color.MidnightBlue;
                ts.GridLineColor = Color.RoyalBlue;
                ts.HeaderBackColor = SystemColors.Control;
                ts.HeaderForeColor = Color.Black;
                ts.SelectionBackColor = Color.Teal;
                ts.SelectionForeColor = Color.PaleGreen;

                ts.RowHeaderWidth = 16;
                ts.AllowSorting = true;
                ts.PreferredRowHeight = 20;

                TextCol = new DataGridColoredTextBoxColumn(de, 0);
                TextCol.MappingName = "id";
                TextCol.HeaderText = "id";
                TextCol.ReadOnly = true;
                TextCol.Alignment = HorizontalAlignment.Left;
                TextCol.Width = 0;
                TextCol.NullText = "";
                ts.GridColumnStyles.Add(TextCol);
                DataGrid1.TableStyles.Add(ts);

                TextCol = new DataGridColoredTextBoxColumn(de, 0);
                TextCol.MappingName = "ma";
                TextCol.HeaderText = "Tên report";
                TextCol.ReadOnly = true;
                TextCol.Alignment = HorizontalAlignment.Left;
                TextCol.Width = 100;
                TextCol.NullText = "";
                ts.GridColumnStyles.Add(TextCol);
                DataGrid1.TableStyles.Add(ts);

                TextCol = new DataGridColoredTextBoxColumn(de, 0);
                TextCol.MappingName = "ten";
                TextCol.HeaderText = "Diễn giải";
                TextCol.ReadOnly = true;
                TextCol.Alignment = HorizontalAlignment.Left;
                TextCol.Width = 336;
                TextCol.NullText = "";
                ts.GridColumnStyles.Add(TextCol);
                DataGrid1.TableStyles.Add(ts);

                TextCol = new DataGridColoredTextBoxColumn(de, 0);
                TextCol.MappingName = "tenloai";
                TextCol.HeaderText = "Loại bảng kê";
                TextCol.ReadOnly = true;
                TextCol.Alignment = HorizontalAlignment.Left;
                TextCol.Width = 150;
                TextCol.NullText = "";
                ts.GridColumnStyles.Add(TextCol);
                DataGrid1.TableStyles.Add(ts);

                TextCol = new DataGridColoredTextBoxColumn(de, 0);
                TextCol.MappingName = "loai";
                TextCol.HeaderText = "";
                TextCol.NullText = "";
                TextCol.ReadOnly = true;
                TextCol.Alignment = HorizontalAlignment.Center;
                TextCol.Width = 0;
                ts.GridColumnStyles.Add(TextCol);
                DataGrid1.TableStyles.Add(ts);

                DataGrid1.DataSource = v_ds.Tables[0];
            }
            catch //(Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
        public Color MyGetColorRowCol(int row, int col)
        {
            Color c = Color.Black;
            switch (col.ToString())
            {
                case "0":
                    c = Color.Black;
                    break;
                case "1":
                    c = Color.Blue;
                    break;
                case "2":
                    c = Color.Red;
                    break;
                case "3":
                    c = Color.Orange;
                    break;
                case "4":
                    c = Color.Cyan;
                    break;
                default:
                    c = Color.Black;
                    break;
            }
            return c;
        }
        public delegate Color delegateGetColorRowCol(int row, int col);
        public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
        {
            private delegateGetColorRowCol _getColorRowCol;
            private int _column;
            public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
            {
                _getColorRowCol = getcolorRowCol;
                _column = column;
            }
            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
            {
                try
                {
                    //foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
                    //backBrush = new SolidBrush(Color.GhostWhite);
                }
                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            cbLoai.Enabled = false;

            butMoi.Enabled = true;
            butLuu.Enabled = false;
            butHuy.Enabled = false;
            butSua.Enabled = false;
            butMoi.Focus();
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text == "")
                {
                    txtTim.Text = "Tìm kiếm";
                }
            }
            catch
            {
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text == "Tìm kiếm")
                {
                    txtTim.Text = "";
                }
            }
            catch
            {
            }		
        }
    }
}