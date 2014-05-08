using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmKhaibaomaychu : Form
    {
        private bool bKhaibao = false;
        public frmKhaibaomaychu(bool khaibao)
        {
            InitializeComponent();
            bKhaibao = khaibao;
        }
        public DAL.Client CLient
        {
            get { return clientUI1.Client; }
            set { clientUI1.Client = value; }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // xóa database link trước khi tạo
            clientUI1.Client.XoaDBLink();
            // tạo database link
            if (!clientUI1.Client.TaoDBLink())
            {
                UI.Thongbao.Message("MC001");
                return;
            }
            DataTable dtxml = new DataTable("synmaychu");
            dtxml.Columns.Add("Host", typeof(string));
            dtxml.Columns.Add("Port", typeof(string));
            dtxml.Columns.Add("User", typeof(string));
            dtxml.Columns.Add("Password", typeof(string));
            dtxml.Columns.Add("Database", typeof(string));
            dtxml.Columns.Add("Servername", typeof(string));
            dtxml.Columns.Add("Dblink", typeof(string));
            DataRow row = dtxml.NewRow();
            row["Host"] = clientUI1.Client.Host;
            row["Port"] = clientUI1.Client.Port;
            row["User"] = clientUI1.Client.Userdb;
            row["Password"] = clientUI1.Client.Passworddb;
            row["Database"] = clientUI1.Client.DatabaseName;
            row["Servername"] = clientUI1.Client.ServerName;
            row["Dblink"] = clientUI1.Client.DbLink;
            dtxml.Rows.Add(row);
            dtxml.WriteXml("..//..//..//xml//syn_thongso.xml", XmlWriteMode.WriteSchema);
            this.Close();
        }

        private void frmKhaibaomaychu_Load(object sender, EventArgs e)
        {
            clientUI1.Visitable = false;
            clientUI1.Init();
           if(bKhaibao)clientUI1.emptyText();
           //clientUI1.Enable = bKhaibao;
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}