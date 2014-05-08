using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmChongoi_kp : Form
    {
        private LibVP.AccessData m_v;

        private string v_makp = "";

        private DataTable dtkp = new DataTable();

        public frmChongoi_kp(LibVP.AccessData v_v)
        {
            InitializeComponent();
            m_v = v_v; 
        }
        public string s_makp
        {
            get
            {
                return v_makp;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            v_makp = "";            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmChongoi_kp_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < makp.Items.Count; i++) makp.SetItemChecked(i, false);                
            dtkp = m_v.get_data("select makp,tenkp from medibv.btdkp_bv where loai=1 order by makp").Tables[0];
            makp.DataSource = dtkp;
            makp.DisplayMember = "tenkp";
            makp.ValueMember = "makp";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v_makp = "";
            for (int i = 0; i < makp.Items.Count; i++)
                if (makp.GetItemChecked(i)) v_makp += dtkp.Rows[i]["makp"].ToString() + ",";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}