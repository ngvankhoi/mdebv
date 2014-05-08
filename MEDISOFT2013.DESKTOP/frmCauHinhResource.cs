using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MEDISOFT2011.DESKTOP
{
    public partial class frmCauHinhResource : DevExpress.XtraEditors.XtraForm
    {
      
        public frmCauHinhResource()
        {
            InitializeComponent();
        }
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtDirectoryPathResource.Text = folderBrowserDialog1.SelectedPath;
            }
         
        }
        private void butForm_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtDirectoryForm.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (txtDirectoryForm.Text == "")
            {
                butForm.Focus();
                return;
            }
            if (txtDirectoryPathResource.Text == "")
            {
                butResource.Focus();
                return;
            }

            CauHinhResouce pro = new CauHinhResouce(this);
            pro.CreateResource(txtDirectoryForm.Text,txtDirectoryPathResource.Text);

        }
    }
}