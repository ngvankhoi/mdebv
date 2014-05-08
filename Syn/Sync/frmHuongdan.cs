using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmHuongdan : Form
    {
        public frmHuongdan()
        {
            InitializeComponent();
        }

        private void frmHuongdan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F10) { this.Close(); }
        }
    }
}