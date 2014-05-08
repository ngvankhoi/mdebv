using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmCauhinhOutput : Form
    {
        LibMedi.AccessData m;
        private bool bok = false;
        public frmCauhinhOutput(LibMedi.AccessData acc)
        {
            InitializeComponent();
            m = acc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bok = true;
            m.writeXml("thongso", "x_lcd", tdx.Value.ToString());
            m.writeXml("thongso", "y_lcd", tdy.Value.ToString()); 
            m.writeXml("thongso", "r_lcd", tdR.Value.ToString());
            m.writeXml("thongso", "c_lcd", tdC.Value.ToString());
            m.writeXml("thongso", "t_lcd", tdt.Value.ToString());
            this.Close();
        }
        
        public int X
        {
            get 
            {
                return (int)tdx.Value;
            }
        }
        public int Y
        {
            get 
            {
                return (int)tdy.Value;
            }
        }
        public int R
        {
            get
            {
                return (int)tdR.Value;
            }
        }
        public int H
        {
            get
            {
                return (int)tdC.Value;
            }
        }
        public bool bOK
        {
            get { return bok; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bok = false;
            this.Close();
        }

        private void frmCauhinhOutput_Load(object sender, EventArgs e)
        {
            try
            {
                tdx.Value = decimal.Parse(m.Thongso("x_lcd"));
                tdy.Value = decimal.Parse(m.Thongso("y_lcd"));
                tdR.Value = decimal.Parse(m.Thongso("r_lcd"));
                tdC.Value = decimal.Parse(m.Thongso("c_lcd"));
                tdt.Value = decimal.Parse(m.Thongso("t_lcd"));
            }
            catch
            { }

        }
    }
}