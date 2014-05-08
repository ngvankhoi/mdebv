using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace dllvpkhoa_chidinh
{
    public partial class frmChonchinhanhthuchiencls : Form
    {
        LibMedi.AccessData m = new AccessData();
        Language lan = new Language();
        private DataSet dschinhanh = new DataSet();
        public int ichinhanh = 0;
        private int i_chinhanhtmp;
        private string s_user = "";
        public frmChonchinhanhthuchiencls(LibMedi.AccessData _m,int _ichinhanh)
        {
            InitializeComponent();
            m = _m;
            i_chinhanhtmp = _ichinhanh;
            s_user = m.user;
        }
        private void frmChonchinhanhthuchiencls_Load(object sender, EventArgs e)
        {
            string sql = " select * from " + s_user + ".dmchinhanh where id not in(" + i_chinhanhtmp + ") order by ten ";
            dschinhanh = m.get_data(sql);
            cbChinhanhden.DisplayMember = "ten";
            cbChinhanhden.ValueMember = "id";
            cbChinhanhden.DataSource = dschinhanh.Tables[0];
        }

        private void btChuyen_Click(object sender, EventArgs e)
        {
            ichinhanh = int.Parse(cbChinhanhden.SelectedValue.ToString());
            this.Close();
        }
    }
}