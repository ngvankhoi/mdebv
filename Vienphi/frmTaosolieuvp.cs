using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmTaosolieuvp : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();
        private string m_userid = "";
        public frmTaosolieuvp(string s_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_userid = s_userid;
        }

        private void frmTaosolieuvp_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            yyyy.Maximum = DateTime.Now.Year + 1;
            yyyy.Minimum = DateTime.Now.Year - 1;
            tu.Value = DateTime.Now.Month;
            den.Value = tu.Value;
            yyyy.Value = DateTime.Now.Year;
        }

        private void tu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void den_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void yyyy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void    butOk_Click(object sender, EventArgs e)
        {
            if (TaoSolieu() != "") MessageBox.Show(lan.Change_language_MessageText("Những tháng sau chưa tạo số liệu :")+"\n" + TaoSolieu(), LibVP.AccessData.Msg);
            else MessageBox.Show(lan.Change_language_MessageText("Xong !"), LibVP.AccessData.Msg);
        }

        public string TaoSolieu()
        {
            Cursor = Cursors.WaitCursor;
            string mmyy = "", s = "";
            for (int i = Convert.ToInt16(tu.Value); i <= Convert.ToInt16(den.Value); i++)
            {
                mmyy = i.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                if (m_v.bMmyy(mmyy))
                {
                    m_v.modify_tables_vp_mmyy(mmyy);
                    m_v.modify_tables_vp();
                }
                else s += mmyy.Substring(0, 2) + "/20" + mmyy.Substring(2, 2) + ";";
            }
            Cursor = Cursors.Default;
            return s;
        }
        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}