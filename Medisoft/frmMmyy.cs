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
    public partial class frmMmyy : Form
    {
        Language lan = new Language();
        private AccessData m;
        private int i_userid;
        public frmMmyy(AccessData acc,int userid)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_userid = userid;
        }

        private void mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void frmMmyy_Load(object sender, EventArgs e)
        {
            yyyy.Maximum = DateTime.Now.Year + 1;
            yyyy.Minimum = DateTime.Now.Year - 1;
            tu.Value = DateTime.Now.Month;
            den.Value = tu.Value;
            yyyy.Value = DateTime.Now.Year;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string mmyy = "", s = "";
            for (int i = Convert.ToInt16(tu.Value); i <= Convert.ToInt16(den.Value); i++)
            {
                mmyy = i.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                if (m.bMmyy(mmyy)) m.modify_schema(mmyy, i_userid);
                else s += mmyy.Substring(0, 2) + "/20" + mmyy.Substring(2, 2) + ";";
            }
            Cursor = Cursors.Default;
            if (s != "") MessageBox.Show("Những tháng sau chưa tạo số liệu :\n" + s,LibMedi.AccessData.Msg);
            else MessageBox.Show("Xong !", LibMedi.AccessData.Msg);
        }
    }
}