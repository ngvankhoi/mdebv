using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DAL
{
    public partial class frmProgressBar : Form
    {
        public frmProgressBar()
        {
            InitializeComponent();
        }
        public int Value
        {
            set { progressBar1.Value = value; }
        }
        public int Step
        {
            set { progressBar1.Step = value; }
        }
        public int Maximum
        {
            set { progressBar1.Maximum = value; }
        }
        public void PerformStep()
        {
            progressBar1.PerformStep();
        }
        public string Status
        {
            set
            {
                lblstatus.Refresh();
                lblstatus.Text = value;
            }
        }
        private void frmProgressBar_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Step = 5;
            progressBar1.Maximum = 100;
        }
    }
}