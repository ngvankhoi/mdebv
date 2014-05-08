using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dllDanhmucMedisoft
{
    public partial class frmDmtheuudai : Form
    {
        LibMedi.AccessData v = new LibMedi.AccessData();
        DataTable dtthe = new DataTable();
        Language lan = new Language();
        DataTable dtnhommien = new DataTable();
        string sql = "", s_msg = "";
        int id = 0;
        bool bMoi = false;

        public frmDmtheuudai()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void frmDmtheuudai_Load(object sender, EventArgs e)
        {
            load_grid1();
            AddGridTableStyle();
            EnaObject(false);
            s_msg = LibMedi.AccessData.Msg;
            //sql = "select 0 id,'' ten,0 tyle,0 sudung from dual";
            //dtnhommien = v.get_data(sql).Tables[0];
            //dataGrid1.DataSource = dtnhommien;
            load_grid();
            AddGridTableStyle1();
            dataGrid3_CurrentCellChanged(null, null);

        }
        private void EnaObject(bool v_bool)
        {
            butMoi.Enabled = !v_bool;
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool;
            butXoa.Enabled = !v_bool;
            butBoqua.Enabled = v_bool;
            chkSudung.Enabled = v_bool;
            txtTen.Enabled = v_bool;
            dataGrid1.Enabled = v_bool;
        }

        private void AddGridTableStyle()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtthe.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "id";
            TextCol.Width = 20;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Loại thẻ";
            TextCol.Width = 300;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sudung";
            TextCol.HeaderText = "Sử dụng";
            TextCol.Width = 50;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

        }
        private void AddGridTableStyle1()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtnhommien.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "id";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Nhóm miễn giảm";
            TextCol.Width = 200;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tyle";
            TextCol.HeaderText = "Tỷ lệ";
            TextCol.Width = 50;
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sudung";
            TextCol.HeaderText = "Sử dụng";
            TextCol.Width = 50;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
        }

        private void dataGrid3_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGrid3.CurrentCell.RowNumber;
                txtTen.Text = dataGrid3[i, 1].ToString();
                id = int.Parse(dataGrid3[i, 0].ToString());
                chkSudung.Checked = int.Parse(dataGrid3[i, 2].ToString()) == 1 ? true : false;
                load_grid();
            }
            catch
            {
                txtTen.Text = "";
            }
        }

        /// <summary>
        /// load luoi dmloaithe
        /// </summary>
        private void load_grid1()
        {
            sql = "select * from " + v.user + ".v_dmloaithe_uudai";
            dtthe = v.get_data(sql).Tables[0];
            dataGrid3.DataSource = dtthe;
        }

        /// <summary>
        /// load luoi ty le
        /// </summary>
        private void load_grid()
        {

            sql = "select a.id,a.ten,nvl(b.tyle,0) tyle,a.sudung from " + v.user + ".v_nhommien a left join " + v.user + ".v_dmloaithe_tyleuudai b on a.id=b.id_nhommien and b.idthe=" + id + " order by a.id";
            dtnhommien = v.get_data(sql).Tables[0];
            dataGrid1.DataSource = dtnhommien;
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            EnaObject(true);
            id = 0;
            load_grid();
            txtTen.Text = "";
            txtTen.Focus();
            bMoi = true;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (bMoi)
            {
                sql = "select max(id)+1 from "+v.user+".v_dmloaithe_uudai";
                dt = v.get_data(sql).Tables[0];
                if (dt.Rows[0][0].ToString().Trim() == "")
                    id = 1;
                else
                    id = int.Parse(dt.Rows[0][0].ToString());
            }
            try
            {
                for (int i = 0; i < dtnhommien.Rows.Count; i++)
                {
                    if (int.Parse(dtnhommien.Rows[i]["tyle"].ToString()) < 0 || int.Parse(dtnhommien.Rows[i]["tyle"].ToString()) > 100)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ miễn giảm không hợp lệ !"),s_msg);
                        return;
                    }
                }
            }
            catch { return; }

            if (!v.upd_v_dmloaithe_uudai(id, txtTen.Text.Trim(), chkSudung.Checked ? 1 : 0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin loại thẻ ưu đãi !"),s_msg);
                return;
            }
            for (int i = 0; i < dtnhommien.Rows.Count; i++)
            {
                if (!v.upd_v_dmloaithe_tyleuudai(id, int.Parse(dtnhommien.Rows[i]["tyle"].ToString()), int.Parse(dtnhommien.Rows[i]["id"].ToString())))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được tỷ lệ !"), s_msg);
                    return;
                }
            }

            load_grid1();
            dataGrid3_CurrentCellChanged(null, null);
            EnaObject(false);
            bMoi = false;
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            EnaObject(true);
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            EnaObject(false);
            bMoi = false;
            dataGrid3_CurrentCellChanged(null, null);
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn xóa loại thẻ này không?"),s_msg, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    v.execute_data("delete from " + v.user + ".v_dmloaithe_tyleuudai where idthe=" + id);
                    v.execute_data("delete from " + v.user + ".v_dmloaithe_uudai where id=" + id);
                    MessageBox.Show(lan.Change_language_MessageText("Xóa thành công!"),s_msg);
                    load_grid1();
                    dataGrid3_CurrentCellChanged(null, null);
                }
            }
        }
    }
}