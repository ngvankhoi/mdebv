using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmConstraint : Form
    {
        private DataSet dsxml = new DataSet();
        public frmConstraint()
        {
            InitializeComponent();
        }

        private void frmConstraint_Load(object sender, EventArgs e)
        {
            load_data();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dsxml.Tables[0];
        }

        private void load_data()
        {
            if (!System.IO.File.Exists("..//..//..//xml//tabledel.xml"))
            {
                MessageBox.Show("Không tìm thấy file table.xml", "System");
                return;
            }
            dsxml.ReadXml("..//..//..//xml//tabledel.xml", XmlReadMode.ReadSchema);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dsxml.AcceptChanges();
            dsxml.WriteXml("..//..//..//xml//tabledel.xml", XmlWriteMode.WriteSchema);
            load_data();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i_row = dataGridView1.CurrentCell.RowIndex;
                int i_col = dataGridView1.CurrentCell.ColumnIndex;
                textBox1.Text = dataGridView1[0, i_row].Value.ToString();
                textBox2.Text = dataGridView1[1, i_row].Value.ToString();
                textBox3.Text = dataGridView1[2, i_row].Value.ToString();
                textBox4.Text = dataGridView1[3, i_row].Value.ToString();
            }
            catch
            { }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            update_data();
        }
        private void update_data()
        {
            try
            {
                int i_row = dataGridView1.CurrentCell.RowIndex;
                int i_col = dataGridView1.CurrentCell.ColumnIndex;
                dataGridView1[0, i_row].Value = textBox1.Text;
                dataGridView1[1, i_row].Value = textBox2.Text;
                dataGridView1[2, i_row].Value = textBox3.Text;
                dataGridView1[3, i_row].Value = textBox4.Text;
            }
            catch
            { }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            update_data();
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            update_data();
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            update_data();
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}