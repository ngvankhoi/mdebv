using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmQuanlyDatabase : Form
    {
        private DAL.Accessdata acc = new DAL.Accessdata();
       // private DAL.Client m_server;
        string dblink = "";
        private DataTable dt;
        public frmQuanlyDatabase(string dblink_server)
        {
            InitializeComponent();
            //m_server = _server;
            dblink = dblink_server;
        }

        private void frmQuanlyDatabase_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            load_grid();

        }

        private void load_grid()
        {
            dt = acc.get_data("select * from " + acc.User + ".syn_manager_schema@"+dblink).Tables[0];
            dataGridView1.DataSource = dt;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dataGridView1.Update();
            dt.AcceptChanges();
            foreach (DataRow r in dt.Rows)
            {
                string sql = "update "+acc.User+".syn_manager_schema@"+dblink+" set syn="+r["syn"].ToString()+" where mmyy='"+r["mmyy"].ToString()+"'";
                acc.execute_data(sql);
            }
            load_grid();
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataTable table
        {
            get { return dt; }
        }
    }
}