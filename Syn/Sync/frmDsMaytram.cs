using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmDsMaytram : Form
    {
        List<DAL.Client> list = new List<DAL.Client>();
        DAL.Client _server;
        private DataSet dsxml;
        int i_khoang_cach_ngay;
        string mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
        public frmDsMaytram(DAL.Client m_server )
        {
            InitializeComponent();
            _server = m_server;
        }
        public frmDsMaytram(DataSet dmtable,int _khoang_cach_ngay)
        {
            InitializeComponent();
            //_server = m_server;
            dsxml = dmtable;
            i_khoang_cach_ngay = _khoang_cach_ngay;
        }

        private void frmDsMaytram_Load(object sender, EventArgs e)
        {
            load_listview();
            //load_table();
        }

        private void load_table()
        {
            if (!System.IO.File.Exists("..//..//..//xml//upd_table.xml"))
            {
                MessageBox.Show("Không tìm thấy file table.xml", "System");
                return;
            }
            dsxml.ReadXml("..//..//..//xml//upd_table.xml", XmlReadMode.ReadSchema);
        }
        private void load_listview()
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Clear();
            }
            list = DAL.Manager.listClient();
            for (int i = 0; i < list.Count; i++)
            {
                DAL.Client client = list[i];
                ListViewItem item = new ListViewItem(client.Host);
                item.SubItems.Add(client.Port);
                item.SubItems.Add(client.Userdb);
                item.SubItems.Add(client.Passworddb);
                item.SubItems.Add(client.DatabaseName);
                item.SubItems.Add(client.ServerName);
                item.SubItems.Add(client.ID.ToString());
                item.SubItems.Add(client.DbLink);
                item.SubItems.Add(client.ImagePath);
                item.SubItems.Add(client.ImagePath_BN);
                item.SubItems.Add(client.ImagePath_Chungtu);
                listView1.Items.Add(item);
                //list.Add(client);
            }
        }

        private void conXoa_Click(object sender, EventArgs e)
        {
            DAL.Accessdata dal = new DAL.Accessdata();
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    DAL.Client _client = list.Find
                        (
                         delegate(DAL.Client d_client) { return d_client.Host == item.Text; }
                        );
                    if (MessageBox.Show("Bạn muốn xóa máy trạm :" + _client.Host, "Server", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (dal.XoaClient(_client))
                        {
                            //dal.XoaClient(_client);
                            DateTime tn = DateTime.Now.AddDays(-(double)i_khoang_cach_ngay);
                            DateTime dn = DateTime.Now.AddDays((double)i_khoang_cach_ngay);
                            for (int j = tn.Year; j <= dn.Year; j++)
                            {
                                for (int i = tn.Month; i <= dn.Month; i++)
                                {
                                    string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                                    foreach (DataRow row in dsxml.Tables[0].Rows)
                                    {
                                      dal.dropFunction(row["schema_name"].ToString().Replace("xxx", mmyy) + ".syn_" + row["table_name"].ToString() + "_from_" + _client.ServerName.ToLower());
                                    }
                                }
                            }
                            //foreach (System.Data.DataRow row in dsxml.Tables[0].Rows)
                            //{
                            //    schema = row["schema_name"].ToString();
                            //    schema = schema.Replace("xxx", mmyy);
                            //    table = row["table_name"].ToString();
                            //    for (int i = 0; i < list.Count; i++)
                            //    {
                            //        dal.dropFunction(schema + ".syn_" + table + "_from_" + _client.ServerName.ToUpper());
                            //    }
                            //}
                        }
                    }
                }
                load_listview();
            }
        }

        
    }
}