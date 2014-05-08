using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmDausinhton : frmDausinhton_chung
    {
        public frmDausinhton()
        {
            InitializeComponent();
            base.Init();
        }

        public frmDausinhton(LibMedi.AccessData _aac,string _s_makp,int _userid)
        {
            InitializeComponent();
            base.acc = _aac;
            base.s_Makp = _s_makp;
            base.iuserid = _userid; 
            base.Init();
        }

        public frmDausinhton(LibMedi.AccessData _acc,string _s_makp,string _s_mabn)
        {
            InitializeComponent();
            base.acc = _acc;
            base.s_Makp = _s_makp;
            base.s_Mabn = _s_mabn;
            base.Init();
        }

        private void frmDausinhton_Load(object sender, EventArgs e)
        {
            base.Load_form();
        }
    }
}