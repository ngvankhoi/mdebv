using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmDmTableAuto : Form
    {
        private DAL.Accessdata acc = new DAL.Accessdata();
        private DAL.Client m_server;
        public frmDmTableAuto(DAL.Client _server)
        {
            InitializeComponent();
            m_server = _server;
        }

        private void frmDmTableAuto_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            load_grid("medibv");
        }

        private void load_grid(string schema)
        {
            string sql = "select schemaname as schema,tablename as table,'' as key from pg_tables@"+m_server.DbLink+" where schemaname='"+schema+"'";
            dataGridView1.DataSource = acc.get_data(sql).Tables[0].Clone(); ;
            list1.DisplayMember = "table";
            list1.ValueMember = "table";
            list1.DataSource = acc.get_data(sql).Tables[0];

        }

        private void txtTableName_TextChanged(object sender, EventArgs e)
        {
            filter_table(txtTableName.Text);
            list1.BrowseToText(txtTableName, txtSchema, txtSchema.Location.X , txtTableName.Location.Y +16, txtSchema.Width + txtTableName.Width+label2.Width+10, 30);
        }

        private void filter_table(string p)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[list1.DataSource];
            DataView dv = (DataView)cm.List;
            string dk = "table like '%" + p + "%'";
            dv.RowFilter = dk;
            if (p.Trim() == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = dk;
            }
        }

        private void txtTableName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                list1.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                list1.Hide();
                SendKeys.Send("{Tab}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            DataView dv = (DataView)cm.List;
            DataRow row = dv.Table.NewRow();
            row["schema"] = txtSchema.Text;
            row["table"] = txtTableName.Text;
            row["key"] = get_primarykey( txtSchema.Text,txtTableName.Text);
            dv.Table.Rows.Add(row);
            dv.Table.AcceptChanges();
            dataGridView1.Refresh();
        }

        private string get_primarykey(string schema, string tables)
        {
            string sql = " select column_name from information_schema.key_column_usage@" + m_server.DbLink + " where constraint_name like '%pk_%' and constraint_schema='" + schema + "' and table_name='" + tables + "'";
            string s_keys = "";
            foreach (DataRow r in acc.get_data(sql).Tables[0].Rows)
            {
                if (s_keys == "")
                {
                    s_keys = r["column_name"].ToString();
                }
                else
                {
                    s_keys += r["column_name"].ToString();
                }

            }
            return s_keys;
        }

        private void txtSchema_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtSchema_Validated(object sender, EventArgs e)
        {
            load_grid(txtSchema.Text);
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}