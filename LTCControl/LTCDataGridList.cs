using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LTCControl
{
    public partial class LTCDataGridList : UserControl
    {
        public DataSet m_ds;
        private string m_col_field_delimiter = "";
        public LTCDataGridList()
        {
            InitializeComponent();
        }

        private void LTCDataGridList_Load(object sender, EventArgs e)
        {

        }

        public void f_set_ds(DataSet v_ds, string v_col_text_delimiter, string v_col_field_delimiter, string v_field_fill)
        {
            f_set_ds(v_ds, v_col_text_delimiter, v_col_field_delimiter, v_field_fill, true);
        }
        public void f_set_ds(DataSet v_ds, string v_col_text_delimiter, string v_col_field_delimiter, string v_field_fill, bool v_visible_chon)
        {
            try
            {

                m_ds = v_ds;
                m_col_field_delimiter = v_col_field_delimiter;

                m_ds.Tables[0].Columns.Add("_sel_");
                m_ds.Tables[0].Columns.Add("_stt_");
                int astt = 0;
                foreach (DataRow r in m_ds.Tables[0].Rows)
                {
                    astt += 1;
                    r["_sel_"] = "0";
                    r["_stt_"] = astt.ToString();
                }
                dgData.DataSource = null;
                dgData.DataMember = m_ds.Tables[0].TableName;
                dgData.DataSource = m_ds.Tables[0];
                dgData.AutoGenerateColumns = false;
                string[] acols_text = v_col_text_delimiter.Split('~');
                string[] acols_field = v_col_field_delimiter.Split('~');

                dgData.Columns.Clear();
                DataGridViewCheckBoxColumn adgc_chon = new DataGridViewCheckBoxColumn();
                adgc_chon.DataPropertyName = "_sel_";
                adgc_chon.HeaderText = "";
                adgc_chon.ToolTipText = "Chọn";
                adgc_chon.Name = "_sel_";
                adgc_chon.Resizable = DataGridViewTriState.False;
                adgc_chon.SortMode = DataGridViewColumnSortMode.Automatic;
                adgc_chon.Width = 20; 
                adgc_chon.TrueValue = "1";
                adgc_chon.FalseValue = "0";
                adgc_chon.IndeterminateValue = "0";
                adgc_chon.ReadOnly = false;
                adgc_chon.Frozen = true;
                if (v_visible_chon)
                {
                    //adgc_chon.Visible = v_visible_chon;
                    dgData.Columns.Add(adgc_chon);
                    chkAll.Visible = true;
                }
                else
                {
                    chkAll.Visible = false;
                }

                DataSet ads_field = new DataSet();
                ads_field.Tables.Add("Table");
                ads_field.Tables[0].Columns.Add("ID");
                ads_field.Tables[0].Columns.Add("TEN");
                ads_field.Tables[0].Rows.Add(new string[] { "", "All" });

                DataGridViewTextBoxColumn adgc_;
                for (int i = 0; i < acols_field.Length; i++)
                {
                    adgc_ = new DataGridViewTextBoxColumn();
                    adgc_.AutoSizeMode = (acols_field[i].ToUpper() == v_field_fill.ToUpper()?DataGridViewAutoSizeColumnMode.Fill:DataGridViewAutoSizeColumnMode.AllCells);
                    adgc_.DataPropertyName = acols_field[i]; 
                    adgc_.HeaderText = acols_text[i];
                    adgc_.Name = "_c_"+i.ToString();
                    adgc_.ReadOnly = true;
                    dgData.Columns.Add(adgc_);

                    ads_field.Tables[0].Rows.Add(new string[] { acols_field[i], acols_text[i] });
                }

                adgc_ = new DataGridViewTextBoxColumn();
                adgc_.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                adgc_.DataPropertyName = "_stt_";
                adgc_.HeaderText = "";
                adgc_.Name = "_stt_";
                adgc_.ReadOnly = true;
                adgc_.Visible = false;
                dgData.Columns.Add(adgc_);

                dgData.AllowUserToAddRows = false;
                dgData.RowHeadersVisible = false;
                dgData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                toolTip1.SetToolTip(lbTitle,"Tổng số"+": "+m_ds.Tables[0].Rows.Count.ToString());

                cbFilter.DataSource = ads_field.Tables[0];
                cbFilter.DisplayMember = "TEN";
                cbFilter.ValueMember = "ID";
                cbFilter.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string f_get_check(string v_fieldname)
        {
            string art = "";
            try
            {
                dgData.Update();
                dgData.Refresh();
                foreach (DataRow r in m_ds.Tables[0].Select("_sel_='1'"))
                {
                    if (art != "")
                    {
                        art += ",";
                    }
                    art += r[v_fieldname].ToString();
                }
                if (m_ds.Tables[0].Columns[v_fieldname].DataType.ToString() == "System.String")
                {
                    art = art.Replace(",","','");
                    if (art != "")
                    {
                        art = "'" + art + "'";
                    }
                }
            }
            catch
            {
            }
            return art;
        }
        public void f_set_check(string v_fieldname, string v_fieldval_dilimiter)
        {
            string art = "";
            try
            {
                foreach (DataRow r in m_ds.Tables[0].Select(""))
                {
                    r["_sel_"] = "0";
                    foreach (string atmp in v_fieldval_dilimiter.Split('~'))
                    {
                        if (atmp.ToString().ToUpper() == r[v_fieldname].ToString().ToUpper())
                        {
                            r["_sel_"] = "1";
                            break;
                        }
                    }
                }
                dgData.Update();
                dgData.Refresh();
            }
            catch
            {
            }
        }
        public void f_set_uncheck(string v_fieldname, string v_fieldval_dilimiter)
        {
            string art = "";
            try
            {
                foreach (DataRow r in m_ds.Tables[0].Select(""))
                {
                    r["_sel_"] = "1";
                    foreach (string atmp in v_fieldval_dilimiter.Split('~'))
                    {
                        if (atmp.ToString().ToUpper() == r[v_fieldname].ToString().ToUpper())
                        {
                            r["_sel_"] = "0";
                            break;
                        }
                    }
                }
                dgData.Update();
                dgData.Refresh();
            }
            catch
            {
            }
        }

        private string f_build_filter()
        {
            string afilter = "";
            string aval = txtFilter.Text.Replace("'", "''");
            string aval_num = "";
            try
            {
                if (aval == "Search")
                {
                    aval = "";
                }
                try
                {
                    aval_num = decimal.Parse(aval).ToString();
                }
                catch
                {
                    aval_num = "";
                }
                if (cbFilter.SelectedValue.ToString() == "")
                {
                    foreach (string afield in m_col_field_delimiter.Split('~'))
                    {
                        if (m_ds.Tables[0].Columns[afield].DataType.ToString() == "System.String")
                        {
                            if (afilter != "")
                            {
                                afilter += " or ";
                            }
                            afilter += afield + " like '%" + aval + "%'";
                        }
                        else
                            if (aval_num != "")
                            {
                                if (afilter != "")
                                {
                                    afilter += " or ";
                                }
                                afilter += afield + " = " + aval_num + "";
                            }
                    }
                }
                else
                {
                    if (m_ds.Tables[0].Columns[cbFilter.SelectedValue.ToString()].DataType.ToString() == "System.String")
                    {
                        if (afilter != "")
                        {
                            afilter += " or ";
                        }
                        afilter += cbFilter.SelectedValue.ToString() + " like '%" + aval + "%'";
                    }
                    else
                        if (aval_num != "")
                        {
                            if (afilter != "")
                            {
                                afilter += " or ";
                            }
                            afilter += cbFilter.SelectedValue.ToString() + " = " + aval_num + "";
                        }
                }
            }
            catch
            {
            }
            return afilter;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string afilter = f_build_filter();
                string aval_chon = chkAll.Checked ? "1" : "0";
                foreach (DataRow r in m_ds.Tables[0].Select(afilter))
                {
                    r["_sel_"] = aval_chon;
                }
            }
            catch
            {
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string afilter = f_build_filter();
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgData.DataSource, dgData.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = afilter;
                toolTip1.SetToolTip(lbTitle,"Tổng số" + ": "+dv.Table.Select(afilter).Length.ToString()+"/"+dv.Table.Rows.Count.ToString());
            }
            catch
            {
            }
        }

        private void txtFilter_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtFilter.Text == "")
                {
                    txtFilter.Text = "Search";
                }
                txtFilter.BackColor = Color.White;
            }
            catch
            {
            }
        }
        private void txtFilter_Enter(object sender, EventArgs e)
        {
            try
            {
                if(txtFilter.Text=="Search")
                {
                    txtFilter.Text = "";
                }
                txtFilter.BackColor = Color.Yellow;
            }
            catch
            {
            }
        }
        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}");
            }
            try
            {
                int i = dgData.CurrentRow.Index;
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (i > 0)
                        {
                            dgData.ClearSelection();
                            dgData.Rows[i - 1].Selected = true;
                        }
                        break;
                    case Keys.Down:
                        if (i < dgData.Rows.Count - 1)
                        {
                            dgData.ClearSelection();
                            dgData.Rows[i + 1].Selected = true;
                        }
                        break;
                }
            }
            catch
            {
            }
        }

        private void cbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void splFilter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                cbFilter.DropDownWidth = txtFilter.Width + cbFilter.Width + splFilter.Width;
            }
            catch
            {
            }
        }

        private void dgData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewCheckBoxCell Check = (DataGridViewCheckBoxCell)dgData.Rows[e.RowIndex].Cells[0];
                if (e.ColumnIndex == 0)
                {
                    m_ds.Tables[0].Select("_stt_='" + dgData["_stt_", e.RowIndex].Value.ToString()+"'")[0]["_sel_"] = (Check.Value.ToString() == "1" ? "0" : "1");
                }
            }
            catch
            {
            }
        }
    }
}
