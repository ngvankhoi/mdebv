using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmMatkhau : Form
    {
        private string email = "";
        public string pass = "";
        public frmMatkhau(string _email)
        {
            InitializeComponent();
            email = _email;
        }

        private void frmMatkhau_Load(object sender, EventArgs e)
        {
            txtMail.Text = email;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            pass = txtPass.Text.Trim();
            this.Close();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
    }
}