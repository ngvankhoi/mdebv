using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmEventlog : Form
    {
        DAL.Client m_server;
        public frmEventlog(DAL.Client server)
        {
            InitializeComponent();
            m_server = server;
        }
        public frmEventlog()
        {
            InitializeComponent();
           // m_server = server;
        }
        private void frmEventlog_Load(object sender, EventArgs e)
        {
            load_event();
        }

        private void load_event()
        {
            try
            {
                using (DAL.Accessdata acc = new DAL.Accessdata())
                {
                    foreach (DataRow row in acc.getEvent().Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        if (row["code"].ToString() == "0")
                        {
                            item.ImageIndex = 0;
                            item.Text = "Lỗi";
                        }
                        item.SubItems.Add(row["ngay"].ToString());
                        item.SubItems.Add(row["thoigian"].ToString());
                        item.SubItems.Add(row["event"].ToString());
                        item.SubItems.Add(row["schema_"].ToString());
                        item.SubItems.Add(row["tablename"].ToString());
                        item.SubItems.Add(row["ten"].ToString());
                        item.SubItems.Add(row["srvSend"].ToString());
                        item.SubItems.Add(row["srvReceive"].ToString());
                        item.SubItems.Add(row["computer"].ToString());

                        listView2.Items.Add(item);
                    }
                }
            }
            catch { }
        }

        private void conrefresh_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
            {
                listView2.Items.Clear();
                load_event();
            }

        }

        private void frmEventlog_Load_1(object sender, EventArgs e)
        {
            load_event();
        }

        private void xóaTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DAL.Accessdata acc = new DAL.Accessdata();
            acc.delEventlog();
            load_event();
        }

        private void conrefresh_Click_1(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
            {
                listView2.Items.Clear();
                load_event();
            }
        }
    }
}