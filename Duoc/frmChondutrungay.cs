using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;

namespace Duoc
{
    public partial class frmChondutrungay : Form
    {
        Language lan;
        Bogotiengviet tv;
        private AccessData d;
        private int i_nhom;
        private string user;
        public int i_manguon = -1, iLanthu = 1;
        public string tennguon, s_makho = "";
        public DateTime m_ngay;
        private DataTable dtkho;
        public frmChondutrungay(AccessData acc,int _nhom, string _makho)
        {
            InitializeComponent();
            d = acc;
            i_nhom = _nhom;
            s_makho = _makho;
            Init();
        }

        private void frmChondutrungay_Load(object sender, EventArgs e)
        {
            user = d.user;
            solieu.Value =(decimal) DateTime.Now.Month;
            nam.Value =(decimal) DateTime.Now.Year;
            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";
            if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
            else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            manguon.SelectedIndex = -1;

            //

            string asql = "select id, ten from " + user + ".d_dmkho where dutru=1 and nhom=" + i_nhom;
            if (s_makho.Trim().Trim(',') != "") asql += " and id in(" + s_makho.Trim().Trim(',') + ")";

            dtkho = d.get_data(asql).Tables[0];
            kho.DataSource = dtkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
            lanthu_ValueChanged(null, null);
        }
        public string MMYY
        {
            get { return solieu.Value.ToString().PadLeft(2, '0') + nam.Value.ToString().Substring(2, 2); }
        }
        private void Init()
        {
            lan = new Language();
            tv = new Bogotiengviet();
            dtkho = new DataTable();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            i_manguon = (manguon.SelectedIndex != -1) ? int.Parse(manguon.SelectedValue.ToString()) : -1;
            tennguon = (manguon.SelectedIndex != -1) ? manguon.Text : "";
            iLanthu = Int16.Parse(lanthu.Value.ToString());
            m_ngay = ngay.Value;
            s_makho = "";
            //
            for (int i = 0; i < kho.Items.Count; i++)
            {
                if (kho.GetItemChecked(i))
                {
                    if (s_makho == "") s_makho = dtkho.Rows[i]["id"].ToString();
                    else
                        s_makho += ","+ dtkho.Rows[i]["id"].ToString() ;
                }
            }
            //
            d.close(); this.Close();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            tennguon = "~";
            d.close(); this.Close();
        }

        private void manguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void lanthu_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (d.get_data("select lan from " + d.user + ".d_dutrungay where lan=" + lanthu.Value.ToString() + " and mmyy='" +solieu.Value.ToString().PadLeft(2,'0')+ nam.Value.ToString().Substring(2, 2) + "'").Tables[0].Rows.Count > 0)
            //    {
            //        ngay.Enabled = false;
            //        string s_ngay = d.get_data("select to_char(ngay,'dd/mm/yyyy') as ngay from " + d.user + ".d_dutrungay where lan=" + lanthu.Value.ToString() + " and mmyy='" + solieu.Value.ToString().PadLeft(2, '0') + nam.Value.ToString().Substring(2, 2) + "'").Tables[0].Rows[0]["ngay"].ToString();
            //        ngay.Value = new DateTime(int.Parse(s_ngay.Substring(6, 4)), int.Parse(s_ngay.Substring(3, 2)), int.Parse(s_ngay.Substring(0, 2)));
            //    }
            //    else
            //    {
            //        ngay.Enabled = true;
            //    }
            //}
            //catch
            //{}
        }

        private void lanthu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void kho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void solieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void nam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
    }
}