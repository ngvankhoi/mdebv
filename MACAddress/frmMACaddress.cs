using System;
using System.Data;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Medisoft2009.MACAddress
{
    public partial class frmMACaddress : Form
    {
        public frmMACaddress()
        {
            InitializeComponent();
        }

        private void frmMACaddress_Load(object sender, EventArgs e)
        {
            lblCach1.Text = MedisoftMAC.MACAddress;
            aq.Text = MedisoftMAC.KeyInfo; 
        }
    }
}