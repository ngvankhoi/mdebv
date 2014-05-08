using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dllvpkhoa_chidinh
{
    public partial class frmSongaycholai : Form
    {
        public frmSongaycholai()
        {
            InitializeComponent();
        }
        private DialogResult mresult = DialogResult.Cancel;
        public DialogResult Result
        {
            get { return mresult; }
            protected set { mresult=value;}
        }

        public int ingay = 0;

        private void btCancel_Click(object sender, EventArgs e)
        {
            mresult = DialogResult.Cancel;
            this.Dispose();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            ingay = int.Parse(txtSongay.Value.ToString());
            mresult = DialogResult.OK;
            this.Dispose();
        }
    }
}