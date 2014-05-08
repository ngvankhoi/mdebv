using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmChonchinhanh : Form
    {
        string s_id = "";
        string s_user = "medibv";
        DataSet dschinhanh = null;
        LibVP.AccessData v = null;
        public frmChonchinhanh()
        {
            InitializeComponent();
            v = new LibVP.AccessData();
        }
        public frmChonchinhanh(LibVP.AccessData _v)
        {
            InitializeComponent();
            v = _v;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            s_id = "";
            this.Close();
        }

        private void butDongy_Click(object sender, EventArgs e)
        {
            Language lan = new Language();
            
            for (int i = 0; i < chkChinhanh.Items.Count; i++)
            {
                if (chkChinhanh.GetItemChecked(i))
                {
                    s_id += dschinhanh.Tables[0].Rows[i]["id"].ToString() + ",";
                }
            }
            s_id = s_id.Trim(',');
            if (s_id == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng chọn chi nhánh chuyển"), lan.Change_language_MessageText("Viện phí"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void frmChonchinhanh_Load(object sender, EventArgs e)
        {
            s_id = "";
            s_user = v.user;
            dschinhanh = new DataSet();
            string s_sql = "select id,ten,ip,database from " + s_user + ".dmchinhanh where trungtam=0 and trim(coalesce(database,''))<>'' order by ten";
            dschinhanh = v.get_data(s_sql);
            chkChinhanh.DataSource = dschinhanh.Tables[0];
            chkChinhanh.DisplayMember = "TEN";
            chkChinhanh.ValueMember = "ID";
        }
        public string IDChiNhanh
        {
            get { return s_id; }
        }
    }
}