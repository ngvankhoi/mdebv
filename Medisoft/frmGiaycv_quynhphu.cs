using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmGiaycv_quynhphu : Medisoft.frmGiaycv
    {
        public frmGiaycv_quynhphu(AccessData acc,string makp,int userid,string _mabn,int _loai):base(acc,makp,userid,_mabn,_loai)
        {
            InitializeComponent();
        }

        void rab1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rab1.Checked)
            {
                lydo.Text = rab1.Text;
               // rab13.Enabled = false;
                rab11.Checked = true;
            }
            else
            {
                lydo.Text = rab1.Text;
               // rab13.Enabled = true;
            }
        }
        void rab11_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rab11.Checked)
                vanchuyen.Text = rab11.Text;
            if (rab12.Checked)
                vanchuyen.Text = rab11.Text;
            if (rab13.Checked)
                vanchuyen.Text = rab11.Text;
        }
    }
}

