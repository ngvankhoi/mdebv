using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmFinmabn : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private DataTable dt = new DataTable();
        public string m_mabn;

        public frmFinmabn(DataTable dta)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            dt = dta;
        }

        private void frmFinmabn_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            dataGridView1.DataSource = dt;                  
        }
      

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m_mabn = "";
            this.Close();
        }

        private void butChon_Click(object sender, EventArgs e)
        {
            f_Getmabn();            
            this.Close();
        }

        private void frmFinmabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10 || e.KeyCode == Keys.Escape) butKetthuc_Click(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            f_Getmabn();
        }
        private void f_Getmabn()
        {
            try
            {
                CurrencyManager mc = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
                DataView dv = (DataView)mc.List;
                m_mabn = dv.Table.Rows[0]["mabn"].ToString();
            }
            catch
            {
            }
        }

 

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
 f_Getmabn();
        }
    }
}