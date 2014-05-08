using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.Collections;
namespace Server
{
    public partial class frmdmTable : Form
    {
        Accessdata dal;
        DataTable dmtable;
        DataTable dtConstraints;
        Stack<syn_table> f_stack = new Stack<syn_table>();
        IList list;
        long stt = 0;
        public frmdmTable(List<Client> _listClient,DataTable _dmtable)
        {
            InitializeComponent();
            list = _listClient;
            dmtable = _dmtable;
        }

        private void dmTable_Load(object sender, EventArgs e)
        {
            dal = new Accessdata();
            mm.Value = (decimal)DateTime.Now.Month;
            yy.Value = (decimal)DateTime.Now.Year;
            dataGridView1.AutoGenerateColumns = false;
            load_table();
            //dtConstraints = dal.get_Information_constraint();
            try
            {
                cbMaytram.DisplayMember = "Dblink";
                cbMaytram.ValueMember = "Dblink";
                cbMaytram.DataSource = list;
            }
            catch
            { }
        }

        private void load_table()
        {
            if (dmtable == null)
            {
                string xxx = dal.User + mm.Value.ToString().PadLeft(2, '0') + yy.Value.ToString().Substring(2, 2);
                //dmtable = dal.get_data("select 0 as stt, schemaname,table_name from sys.all_tables where lower(schemaname)='" + dal.User + "' union " +
                //    "select schemaname as schema_name,table_name from sys.all_tables where lower(schemaname)='" + xxx + "' order by schemaname").Tables[0];
                dmtable = dal.get_data("select stt, schemaname,table_name from medibv.syn_dmtable order by stt").Tables[0];
            }
            try
            {
                dmtable.Columns.Add("chon", typeof(bool)).DefaultValue = false;
            }
            catch { }
            //dmtable.Columns.Add("done", typeof(int)).DefaultValue = 0;
            dataGridView1.DataSource = dmtable;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string f_value = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (dataGridView1[e.ColumnIndex, e.RowIndex].ValueType.ToString() == "System.Boolean")
                {
                    if (f_value == "" || f_value.ToLower() == "false")
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = true;
                    }
                    else
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = false;
                    }
                }
            }
            catch
            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            return;
            string xxx = mm.Value.ToString().PadLeft(2, '0') + yy.Value.ToString().Substring(2, 2);
            filter("");
            CurrencyManager cm =(CurrencyManager) BindingContext[dataGridView1.DataSource];
            DataView dv = (DataView) cm.List;
            foreach(DataRow row in dv.Table.Select("chon='true'","stt"))
            {
                // Kiểm tra table có peimary key không?
                if (!dal.HasPrimaryKey(row["table_name"].ToString(), row["schema_name"].ToString().Replace("xxx",xxx)))
                {
                    UI.Thongbao.Message("Syn007", 1, row["schema_name"].ToString().Replace("xxx", xxx) + "." + row["table_name"].ToString());
                    return;
                }
                //Kiểm tra foreign key
                if (!kiemtra_foreign_key(row["table_name"].ToString(), row["schema_name"].ToString().Replace("xxx",xxx)))
                {
                    return;
                }
            }
            // xử lý đồng bộ
            try
            {
                string dblink = cbMaytram.SelectedValue.ToString();
                if (dblink != "")
                {
                    foreach (DataRow row in dv.Table.Select("chon='true'", "stt"))
                    {
                        string schema = row["schema_name"].ToString();
                         schema = schema.Replace("xxx", xxx);
                        string table = row["table_name"].ToString();
                        ///Kiểm tra xem schema có tồn tại không?
                        if (dal.bShemaValid(schema))
                        {
                            if (!dal.update(schema + ".syn_" + table + "_from_" + dblink))
                            {
                                dal.upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0'), "auto", "syn_table",dblink, schema, table, DAL.Accessdata.error, "0", Environment.MachineName.ToString(), "??");
                            }
                        }
                    }
                }
            }
            catch{}
            
        }
        /// <summary>
        /// Dùng stack để lưu theo thứ tự các table.
        /// </summary>
        /// <param name="f_row"></param>
        private void push_stack(syn_table f_row)
        {
           
            DataRow[] dtr = dtConstraints.Select("r_schema='" + f_row.Schema_Name + "' and r_table='" + f_row.Table_Name + "'");
            for (int i = 0; i < dtr.Length; i++)
            {
                syn_table f_table = new syn_table(dtr[i]["table_schema"].ToString(), dtr[i]["table_name"].ToString(), f_row.Last);
                if (!f_stack.Contains(f_table))
                {
                    f_stack.Push(f_table);
                }
            }
            if (!f_stack.Contains(f_row))
            {
                f_stack.Push(f_row);
            }

        }
        /// <summary>
        /// Phương thức dùng để kiểm tra xem table được foreign key có được chọn không
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        private bool kiemtra_foreign_key(string table_name, string schema_name)
        {
            DataRow[] dtr = dtConstraints.Select("r_table='" + table_name + "' and r_schema='" + schema_name + "'");
            bool ok = true;
            string table_name1 = "",schema_name1="";
            if (dtr.Length > 0)
            {
                for (int i = 0; i < dtr.Length; i++)
                {
                    table_name1 = dtr[i]["table_name"].ToString();
                    schema_name1 = dtr[i]["table_schema"].ToString();
                    if (!kiemtrachon(table_name1, schema_name1))
                    {
                        MessageBox.Show(schema_name + "." + table_name + " foreign key to " + schema_name1 + "." + table_name1);
                        ok = false;
                        break;
                    }
                }
            }
            return ok;
        }
        /// <summary>
        /// Phương thúc được dùng để kiểm tra xem foreign key table có được chọn hay không.
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        private bool kiemtrachon(string table_name,string schema_name)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            DataView dv = (DataView)cm.List;
            DataRow[] dtr = dv.Table.Select("table_name='" + table_name + "' and schema_name='"+schema_name+"' and chon='True'");
            return dtr.Length > 0;
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            filter(txtTimkiem.Text);
        }

        private void filter(string p)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            DataView dv = (DataView)cm.List;
            if (p.Trim() == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = "table_name like '%" + p + "%' or schema_name like '%" + p + "%'";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mm_ValueChanged(object sender, EventArgs e)
        {
            if(mm.Focused)
            load_table();
        }

        private void yy_ValueChanged(object sender, EventArgs e)
        {
            if (mm.Focused)
                load_table();
        }

        private void mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("Tab");
            }
        }

        private void yy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("Tab");
            }
        }

        private void cbMaytram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("Tab");
            }
        }

        private void txtTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("Tab");
            }
        }
    }
    #region 
    public struct syn_table
    {
        string schema_name, table_name;
        int last;
       // long stt;
        public syn_table(string _schema, string _table, int _last)
        {
            schema_name = _schema;
            table_name = _table;
            last = _last;
            //stt = _stt;
        }
        public string Schema_Name
        {
            get { return schema_name; }
        }
        public string Table_Name
        {
            get { return table_name; }
        }
        public int Last
        {
            get { return last; }
        }
    }
    #endregion
}