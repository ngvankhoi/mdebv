using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;
namespace dllModify_table
{
    public partial class frmModifyScheam : Form
    {
        LibMedi.AccessData m = new LibMedi.AccessData();
        DataSet dsColumnAlter;
        decimal d_idcolumn = 0;
        bool bAllow = false;
        public frmModifyScheam()
        {
            InitializeComponent();
            this.Text += "-" + m.Maincode("Database");
        }

        private void frmModifyScheam_Load(object sender, EventArgs e)
        {
            //
            f_capnhat_db();
            //
            mm_tao.Value = DateTime.Now.Month;
            yyyy_tao.Value = DateTime.Now.Year;
            if (mm_tao.Value == 1)
            {
                mm.Value = 12;
                yyyy.Value = yyyy_tao.Value - 1;
            }
            else
            {
                mm.Value = mm_tao.Value - 1;
                yyyy.Value = yyyy_tao.Value;
            }
            cbSchema.SelectedIndex = 0;
            f_load_alter_table("xxx");
            ena_alter_obj(false);
        }

        private void ButClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_capnhat_db()
        {
            string asql = "create table medibv.alter_table (id serial, schema_name varchar(60) , table_name varchar(60),command_ct varchar(30), field_name varchar(60), data_type varchar(128), default_value varchar(300), constraint pk_alter_table primary key (id))";
            m.execute_data(asql);
        }

        private void f_get_cautruc_chuan(string a_database_name, string a_schemaname, string a_mmyy)
        {
            string s_userdb = m.user;
             string asql = "";
             asql = " insert into medibv.alter_table (schema_name, table_name,field_name, command_ct,  data_type, default_value) ";
             asql += " select '" + ((a_mmyy == "") ? s_userdb : "xxx") + "' as table_schema, table_name, column_name, 'add' as cmd_ct, ";
             asql += " case when data_type='character varying' then data_type||'('||character_maximum_length||')' ";
             asql += " else case when data_type='numeric' and substr(column_default,1,7)='nextval' then 'serial' ";
             asql += " else case when data_type='numeric' and numeric_precision is not null then data_type||'('||numeric_precision||','||numeric_scale||')' else data_type end end end as type,  ";
             asql += " case when substr(column_default,1,7)='nextval' then '' else column_default end as default_value ";
             asql += " from information_schema.columns where table_catalog='" + a_database_name + "' and table_schema='" + a_schemaname + a_mmyy + "'";// and column_name not in('chuyendi', 'ngayud')";
             asql += " and is_updatable='YES'";
             asql += " and column_name not in('chuyendi') and '" + ((a_mmyy == "") ? s_userdb : "xxx") + "'||'-'||table_name||'-'||column_name not in (select '" + ((a_mmyy == "") ? s_userdb : "xxx") + "'||'-'||table_name||'-'||field_name from medibv.alter_table where commend_ct='add')";
             m.execute_data(asql);
        }

        private void butGet_cautruc_cu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string s_dbname=m.Maincode("Database");
            string a_mmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().Substring(2,2);            
            m.f_get_cautruc_chuan(s_dbname, m.user, a_mmyy);
            if (chkmedibv.Checked)
            {
                m.f_get_cautruc_chuan(s_dbname, m.user, "");
            }
            MessageBox.Show("Đã lấy cấu trúc lưu vào database.");
            Cursor = Cursors.Default;
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            string a_mmyy = mm_tao.Value.ToString().PadLeft(2, '0') + yyyy_tao.Value.ToString().Substring(2, 2);
            Cursor = Cursors.WaitCursor;
            if (m.bMmyy(a_mmyy) == false)
            {
                MessageBox.Show("Số liệu tháng " + mm_tao.Value.ToString().PadLeft(2, '0') + " năm " + yyyy_tao.Value.ToString() + " chưa tạo.");
                Cursor = Cursors.Default;
                return;
            }
            if (chkmedibv.Checked)
            {
                m.modify_schema_root_new();
            }
            m.modify_schema_mmyy_new(a_mmyy);
            MessageBox.Show("Đã modify xong cấu trúc.");
            Cursor = Cursors.Default;
        }

        private void cbSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbSchema || sender == null)
            {
                f_load_alter_table((cbSchema.Text.ToLower() == "mmyy") ? "xxx" : cbSchema.Text.ToLower());
                txtTim_TextChanged(null, null);
            }
        }


        private void f_load_alter_table(string s_SchemaName)
        {
            if (s_SchemaName.ToLower() == "mmyy") s_SchemaName = "xxx";
            string asql = "select * from medibv.alter_table where schema_name='" + s_SchemaName + "'";
            dsColumnAlter = m.get_data(asql);
            dataGridView1.DataSource = dsColumnAlter.Tables[0];
        }

        private void txtTblName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentCell.RowIndex;

                d_idcolumn = decimal.Parse(dataGridView1[0, i].Value.ToString());
                DataRow r = m.getrowbyid(dsColumnAlter.Tables[0], "id='" + d_idcolumn + "'");
                if (r != null)
                {
                    txtTblName.Text = r["table_name"].ToString();
                    txtColumnName.Text = r["field_name"].ToString();
                    txtDatatype.Text = r["data_type"].ToString();
                    txtDefaultValue.Text = r["default_value"].ToString();
                    txtDefaultValue.Tag = r["default_value"].ToString();
                    cbCommand.Text = r["command_ct"].ToString();

                    ena_alter_obj(false);
                }
            }
            catch { }
        }

        private void butSuaAlter_Click(object sender, EventArgs e)
        {
            if (bAllow == false)
            {
                MessageBox.Show("Chưa được phép sửa.");
                return;
            }
            ena_alter_obj(true);
            cbCommand.Focus();
        }


        private void ena_alter_obj(bool ena)
        {
            dataGridView1.Enabled = !ena;

            cbSchema.Enabled = !ena;
            txtTim.Enabled = !ena;
            txtTblName.Enabled = false;// ena;
            txtColumnName.Enabled = false;// ena;
            txtDatatype.Enabled = ena;
            txtDefaultValue.Enabled = ena;
            cbCommand.Enabled = ena;

            butSuaAlter.Enabled = !ena;
            butBoquaAlter.Enabled = ena;
            butLuuAltertable.Enabled = ena;
        }

        private void emp_alter_obj()
        {
            txtTblName.Text = "";
            txtColumnName.Text = "";
            txtDatatype.Text = "";
            txtDefaultValue.Text = "";
            txtDefaultValue.Tag = "";
            cbCommand.SelectedIndex = 0;
        }

        private void butBoquaAlter_Click(object sender, EventArgs e)
        {
            ena_alter_obj(false);
            dataGridView1.Focus();
        }

        private void butLuuAltertable_Click(object sender, EventArgs e)
        {
            if (txtTblName.Text == "")
            {
                MessageBox.Show("Đề nghị nhập Table Name");
                txtTblName.Focus();
                return;
            }
            if (txtColumnName.Text == "")
            {
                MessageBox.Show("Đề nghị nhập Column Name");
                txtColumnName.Focus();
                return;
            }
            if (cbCommand.Text == "")
            {
                MessageBox.Show("Đề nghị chọn command");
                cbCommand.Focus();
                return;
            }
            if (txtDatatype.Text == "")
            {
                MessageBox.Show("Đề nghị nhập Data Type");
                txtDatatype.Focus();
                return;
            }
            //
            m.upd_alter_table(d_idcolumn == 0, d_idcolumn, (cbSchema.Text.ToLower() == "mmyy") ? "xxx" : cbSchema.Text, txtTblName.Text, txtColumnName.Text, cbCommand.Text, txtDatatype.Text, txtDefaultValue.Text);
            //
            f_load_alter_table((cbSchema.Text.ToLower() == "mmyy") ? "xxx" : cbSchema.Text);
            ena_alter_obj(false);
            dataGridView1.Focus();
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            txtTim.Text = "";
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (txtTim.Text == "") txtTim.Text = "Tìm kiếm";
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text.Trim() == "Tìm kiếm") { txtTim.Text = ""; return; }
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "table_name like '%" + txtTim.Text.Trim() + "%' or field_name like '%" + txtTim.Text.Trim() + "%'";
            }
            catch { }
        }

        private void butTaolai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frmModifyScheam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M && e.Alt && e.Shift && e.Control)
            {
                bAllow = !bAllow;
            }
        }

        private void cbCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbCommand || sender == null)
            {
                if (cbCommand.Text == "alter column")
                {
                    txtDefaultValue.Text = "";
                    txtDefaultValue.Enabled = false;
                }
                else
                {
                    txtDefaultValue.Text = txtDefaultValue.Tag.ToString();
                    txtDefaultValue.Enabled = true;
                }
            }
        }

        private void butHuy_altertable_Click(object sender, EventArgs e)
        {
            if (bAllow == false)
            {
                MessageBox.Show("Chưa được phép huỷ.");
                return;
            }
            if (d_idcolumn <= 0)
            {
                MessageBox.Show("Chọn column cần huỷ.");
                dataGridView1.Focus();
                return;
            }
            string asql = "delete from medibv.alter_table where id=" + d_idcolumn;// table_name='" + txtTblName.Text + "' and field_name='" + txtColumnName.Text + "' and command_ct='" + cbCommand.Text + "' and schema_name='" + ((cbSchema.Text.ToLower() == "mmyy") ? "xxx" : "medibv");
            m.execute_data(asql);
            cbSchema_SelectedIndexChanged(null, null);
            ena_alter_obj(false);
            dataGridView1.Focus();
        }


    }
}