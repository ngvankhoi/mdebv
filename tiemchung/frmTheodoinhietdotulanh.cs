using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tiemchung
{
    public partial class frmTheodoinhietdotulanh : Form
    {
        LibMedi.AccessData m = new LibMedi.AccessData();
        private string user = "";
        bool b_admin = true;
        int i_userid = 0;
        public frmTheodoinhietdotulanh(bool _admin,int _userid)
        {
            InitializeComponent();
            b_admin = _admin;
            i_userid = _userid;
        }
        public frmTheodoinhietdotulanh()
        {
            InitializeComponent();
        }

        private void frmTheodoinhietdotulanh_Load(object sender, EventArgs e)
        {
            numNam.Value = DateTime.Now.Year;
            cmbThang.SelectedIndex = DateTime.Now.Month - 1;
            user = m.user;
            cboDonvi.DisplayMember = "TEN";
            cboDonvi.ValueMember = "ID";
            cboDonvi.DataSource = m.get_data("select id,ten from " + user + ".dmphongthuchiencls order by ten").Tables[0];
            if (cboDonvi.Items.Count > 0)
            {
                cboDonvi.SelectedIndex = 0;
                cboDonvi.Enabled = !(cboDonvi.Items.Count == 1);
            }
            cboBuoi.SelectedIndex = 0;
            cboBuoi.Focus();
            cmbThang_SelectedIndexChanged((object)cboBuoi, null);
        }
        public void load_data(string _mm, string _yyyy, int _donvi, int _thoigian)
        {
            int i_thang = int.Parse(_mm);
            int i_nam = int.Parse(_yyyy);
            int i_songay = DateTime.DaysInMonth(i_nam, i_thang);
            string s_sql = "select ";
            for (int i = 1; i <= i_songay; i++)
            {
                if (_thoigian == 0 || _thoigian == -1) s_sql += "sum(s_" + i.ToString().PadLeft(2, '0') + ") as s_" + i.ToString().PadLeft(2, '0') + ",";
                if (_thoigian == 1 || _thoigian == -1) s_sql += "sum(c_" + i.ToString().PadLeft(2, '0') + ") as c_" + i.ToString().PadLeft(2, '0') + ",";
            }
            s_sql = s_sql.Trim(',');
            s_sql+=" from(select ";
            for (int i = 1; i <= i_songay; i++)
            {
                if (_thoigian == 0 || _thoigian == -1) s_sql += "decode(to_char(ngay,'dd'),'" + i.ToString().PadLeft(2, '0') + "',nhietdo_sang,0) as s_" + i.ToString().PadLeft(2, '0') + ",";
                if (_thoigian == 1 || _thoigian == -1) s_sql += "decode(to_char(ngay,'dd'),'" + i.ToString().PadLeft(2, '0') + "',nhietdo_chieu,0) as c_" + i.ToString().PadLeft(2, '0') + ",";
            }
            s_sql = s_sql.Trim(',');
            s_sql += " from " + user + ".theodoinhietdo where to_char(ngay,'mmyyyy')='" + _mm.PadLeft(2, '0') + _yyyy + "' and id_phongthuchiencls=" + _donvi.ToString() + ")";
            DataTable dttmp = new DataTable();
            dttmp = m.get_data(s_sql).Tables[0];
            if (dttmp.Rows.Count == 0)
            {
                DataRow nr = dttmp.NewRow();
                dttmp.Rows.Add(nr);
            }
            DataTable dt = dttmp.Clone();
            DataSet ds = new DataSet();
            ds.Merge(dttmp.Select(""));
            AddGridTableStyle(ds.Tables[0], _mm, _yyyy, _thoigian);
            dataGrid1.SetDataBinding(ds.Tables[0], ds.Tables[0].Namespace);
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
        }
        private void AddGridTableStyle(DataTable _dt, string _mm,string _yyyy, int _thoigian)
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = _dt.TableName;
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
            int i_tag = 0;
            int i_thang = int.Parse(_mm);
            int i_nam = int.Parse(_yyyy);
            int i_songay = DateTime.DaysInMonth(i_nam, i_thang);
            for (int i = 1; i <= i_songay; i++)
            {
                if (_thoigian == 0 || _thoigian == -1)
                {
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "s_" + i.ToString().PadLeft(2, '0');
                    TextCol.HeaderText = "S " + i.ToString();
                    TextCol.Width = 30;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Format = "###";
                    TextCol.ReadOnly = ((i.ToString().PadLeft(2, '0') + _mm.PadLeft(2, '0') + _yyyy) == txtNgay.Value.ToString("ddMMyyyy") ) ? false : !b_admin;
                    TextCol.TextBox.Name = "s" + i.ToString().PadLeft(2, '0');
                    TextCol.TextBox.Tag = "s" + (i_tag + i).ToString();
                    TextCol.NullText = "";
                    TextCol.TextBox.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
                    ts.GridColumnStyles.Add(TextCol);
                }
                if (_thoigian == 1 || _thoigian == -1)
                {
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "c_" + i.ToString().PadLeft(2, '0');
                    TextCol.HeaderText = "C " + i.ToString();
                    TextCol.Width = 30;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Format = "###";
                    TextCol.ReadOnly = ((i.ToString().PadLeft(2, '0') + _mm.PadLeft(2, '0') + _yyyy) == txtNgay.Value.ToString("ddMMyyyy")) ? false : !b_admin;
                    TextCol.TextBox.Name = "c" + i.ToString().PadLeft(2, '0');
                    TextCol.TextBox.Tag = "c" + (i_tag + i).ToString();
                    TextCol.NullText = "";
                    TextCol.TextBox.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
                    ts.GridColumnStyles.Add(TextCol);
                }
            }

            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(ts);
        }

        void Textbox_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox text = (System.Windows.Forms.TextBox)sender;
            text.Refresh();
            if (ActiveControl == text && text.Text.Trim()!="-")
            {
                try {
                    int t = int.Parse(text.Text);
                }
                catch { text.Text = ""; }
            }
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            foreach (DataRow r in dv.Table.Rows)
            {
                foreach (DataColumn col in dv.Table.Columns)
                {
                    if (r[col.ColumnName].ToString() != "")
                    {
                        m.upd_theodoinhietdo(int.Parse(cboDonvi.SelectedValue.ToString()), col.ColumnName.Substring(2) + "/" + cmbThang.Text.PadLeft(2, '0') + "/" + numNam.Value.ToString(), int.Parse(r[col.ColumnName].ToString()), col.ColumnName.Substring(0, 1), i_userid);
                    }
                }
            }
        }

        private void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cmbThang || ActiveControl == numNam || ActiveControl == cboDonvi || ActiveControl == cboBuoi)
            {
                if (cboDonvi.SelectedIndex == -1)
                {
                    return;
                }
                int i_buoi = -1;
                if (cboBuoi.SelectedIndex == 0)
                {
                    i_buoi = 0;
                }
                else if (cboBuoi.SelectedIndex == 1)
                {
                    i_buoi = 1;
                }
                load_data(cmbThang.Text, numNam.Value.ToString(), int.Parse(cboDonvi.SelectedValue.ToString()), i_buoi);
                butLuu.Enabled = (i_buoi != -1);
            }
        }

        private void butin_Click(object sender, EventArgs e)
        {
            int i_buoi = -1;
            if (cboBuoi.SelectedIndex == 0)
            {
                i_buoi = 0;
            }
            else if (cboBuoi.SelectedIndex == 1)
            {
                i_buoi = 1;
            }
            string s_sql = "";
            if (i_buoi == 0 || i_buoi == -1)
            {
                s_sql += s_sql == "" ? "" : " union all ";
                s_sql += " select to_char(ngay,'dd')||'s' as ngay,nhietdo_sang as nhietdo,to_number(to_char(ngay,'dd')||'0') as stt from " + user + ".theodoinhietdo where id_phongthuchiencls=" +
                    cboDonvi.SelectedValue.ToString() + " and to_char(ngay,'mmyyyy')='" + cmbThang.Text.PadLeft(2, '0') + numNam.Value.ToString() + "'";
            }
            if (i_buoi == 1 || i_buoi == -1)
            {
                s_sql += s_sql == "" ? "" : " union all ";
                s_sql += " select to_char(ngay,'dd')||'c' as ngay,nhietdo_chieu as nhietdo,to_number(to_char(ngay,'dd')||'1') as stt from " + user + ".theodoinhietdo where id_phongthuchiencls=" +
                    cboDonvi.SelectedValue.ToString() + " and to_char(ngay,'mmyyyy')='" + cmbThang.Text.PadLeft(2, '0') + numNam.Value.ToString() + "'";
            }
            string sql = "select ngay,nhietdo from (" + s_sql + ") order by stt";
            DataTable dt = m.get_data(sql).Tables[0];
            if (chkXml.Checked)
            {
                dt.DataSet.Copy().WriteXml("..//..//dataxml//theodoinhietdo.xml", XmlWriteMode.WriteSchema);
            }
            if (dt.Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, dt, "rptTheodoinhietdo.rpt", "", "", "", "", "", "", "", "", "", "");
                f.ShowDialog();
            }
        }

        private void butBieudo_Click(object sender, EventArgs e)
        {
             int i_buoi = -1;
            if (cboBuoi.SelectedIndex == 0)
            {
                i_buoi = 0;
            }
            else if (cboBuoi.SelectedIndex == 1)
            {
                i_buoi = 1;
            }
            string s_sql = "";
            if (i_buoi == 0 || i_buoi == -1)
            {
                s_sql += s_sql == "" ? "" : " union all ";
                s_sql += " select to_char(ngay,'dd')||'s' as ngay,nhietdo_sang as nhietdo,to_number(to_char(ngay,'dd')||'0') as stt from " + user + ".theodoinhietdo where id_phongthuchiencls=" +
                    cboDonvi.SelectedValue.ToString() + " and to_char(ngay,'mmyyyy')='" + cmbThang.Text.PadLeft(2, '0') + numNam.Value.ToString() + "'";
            }
            if (i_buoi == 1 || i_buoi == -1)
            {
                s_sql += s_sql == "" ? "" : " union all ";
                s_sql += " select to_char(ngay,'dd')||'c' as ngay,nhietdo_chieu as nhietdo,to_number(to_char(ngay,'dd')||'1') as stt from " + user + ".theodoinhietdo where id_phongthuchiencls=" +
                    cboDonvi.SelectedValue.ToString() + " and to_char(ngay,'mmyyyy')='" + cmbThang.Text.PadLeft(2, '0') + numNam.Value.ToString() + "'";
            }
            string sql = "select ngay,nhietdo from (" + s_sql + ") order by stt";
            DataTable dt = m.get_data(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //frmBieudo f = new frmBieudo(m, dt); gam 21/02/2012
                //f.ShowDialog();
            }
        }
    }
}