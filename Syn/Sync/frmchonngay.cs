using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmchonngay : Form
    {
        public string s_tu = "";
        public string s_den = "";
        public frmchonngay()
        {
            InitializeComponent();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            s_tu = txtTu.Text;
            s_den = txtDen.Text;
            this.Close();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            s_tu = "";
            s_den = "";
            this.Close();
        }

        private void frmchonngay_Load(object sender, EventArgs e)
        {
            txtTu.Value = DateTime.Now;
            txtTu.Value = DateTime.Now;
        }
    }
}