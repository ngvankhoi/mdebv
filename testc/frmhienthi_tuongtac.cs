using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace testc
{
    public partial class frmhienthi_tuongtac : Form
    {
        public frmhienthi_tuongtac(string stieude,string sdiengiai)
        {
            InitializeComponent();
            lblTieude.Text = stieude;
            lblDiengiai.Text = sdiengiai;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDiengiai_Click(object sender, EventArgs e)
        {

        }

        private void frmhienthi_tuongtac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmhienthi_tuongtac_Load(object sender, EventArgs e)
        {

        }
    }
}