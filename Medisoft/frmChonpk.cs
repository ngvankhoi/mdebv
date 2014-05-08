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
    public partial class frmChonpk : Medisoft.frmChonkp
    {
        //public AccessData m;
        //public string s_makp = "", s_mabs = "", s_pk = "";
        public frmChonpk()
        {
            InitializeComponent();
            base.init();
        }
        //TU:07/04/2011
        public frmChonpk(AccessData acc, string _makp, string _mabs,string _pk,int _chinhanh)
        {
            InitializeComponent();
            //base.init();
            //Language lan = new Language();
            //lan.Read_Language_to_Xml(this.Name.ToString(), this);
            //lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_makp = _makp; s_mabs = _mabs; s_pk = _pk; i_chinhanh = _chinhanh;
        }

        private void frmChonpk_Load(object sender, EventArgs e)
        {
            phong.Visible = false;
            label2.Text = "Phòng";
        }
        //end TU
    }
}

