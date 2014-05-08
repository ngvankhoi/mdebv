using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Medisoft2009.License;

namespace MediLicense
{
    public partial class frmLicense : XtraForm
    {
        public frmLicense()
        {
            InitializeComponent();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Application.Exit();   
        }

        private void butCont_Click(object sender, EventArgs e)
        {
            txtKey.Text = "";
            txtCode.Text = "";
        }

        private void butGenerate_Click(object sender, EventArgs e)
        {
            string stemp = txtKey.Text;
            stemp = Encryption.DeCode(stemp, Encryption.Key);
            txtCode.Text = Encryption.Generate(stemp);
        }
    }
}