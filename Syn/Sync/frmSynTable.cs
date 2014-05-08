using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
namespace Server
{
    public partial class frmSynTable : Form
    {
        IList<Client> list;
        public frmSynTable(List<Client> _list)
        {
            InitializeComponent();
            list = _list;
        }

        private void frmSynTable_Load(object sender, EventArgs e)
        {
            cbServer.DisplayMember = "Dblink";
            cbServer.DisplayMember = "Dblink";
            cbServer.DataSource = list;
        }
    }
}