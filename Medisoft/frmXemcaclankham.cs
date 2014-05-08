using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmXemcaclankham : Form
    {
        string s_ten = "";
        DataTable dt = new DataTable();
        Language lan = new Language();

        public frmXemcaclankham(string _ten,DataTable _dt)
        {
            InitializeComponent();
            s_ten = _ten;
            dt = _dt;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void frmXemcaclankham_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            label1.Text = s_ten;
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}