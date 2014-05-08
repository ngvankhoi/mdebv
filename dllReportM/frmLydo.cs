using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dllReportM
{
    public partial class frmLydo : Form
    {
        string s_lydo = "";
        public frmLydo()
        {
            InitializeComponent();
        }
        public string LyDo
        {
            get { return s_lydo; }
        }
        private void butOk_Click(object sender, EventArgs e)
        {
            Language lan = new Language();
            if (txtLydo.Text.Trim() == "")
            {
                s_lydo = "";
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập lý do") + "!", "Medisoft 2007");
                txtLydo.Focus();
                return;
            }
            s_lydo = txtLydo.Text.Trim();
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            s_lydo = "";
            this.Close();
        }
    }
}