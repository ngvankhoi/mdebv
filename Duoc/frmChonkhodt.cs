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
    public partial class frmChonkhodt : Form
    {
        Language lan;
        Bogotiengviet tv;
        private AccessData d;
        private int i_nhom;
        private string user;
        public int i_manguon = -1;
        public string tennguon, s_makho = "",s_tenkho="",s_mmyy="";
        public DateTime m_ngay;
        private DataTable dtkho;
        public frmChonkhodt(AccessData acc, int _nhom, string _makho)
        {
            InitializeComponent();
            d = acc;
            i_nhom = _nhom;
            s_makho = _makho;
            Init();
        }
        private void Init()
        {
            lan = new Language();
            tv = new Bogotiengviet();
            dtkho = new DataTable();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        private void frmChonkhodt_Load(object sender, EventArgs e)
        {
            user = d.user;
            solieu.Value = (decimal)DateTime.Now.Month;
            nam.Value = (decimal)DateTime.Now.Year;
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
            cmbKho.DataSource = dtkho;
            cmbKho.DisplayMember = "TEN";
            cmbKho.ValueMember = "ID";
        }

        private void solieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void nam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void manguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void kho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                i_manguon = (manguon.SelectedIndex != -1) ? int.Parse(manguon.SelectedValue.ToString()) : -1;
                tennguon = (manguon.SelectedIndex != -1) ? manguon.Text : "";
                m_ngay = ngay.Value;
                s_makho = s_tenkho = "";
                s_makho = cmbKho.SelectedValue.ToString();
                s_tenkho = cmbKho.Text;
                s_mmyy = solieu.Value.ToString().PadLeft(2, '0') + nam.Value.ToString().Substring(2, 2);
                //
            }
            catch
            {
                m_ngay = ngay.Value;
            }
            //
            d.close(); this.Close();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            tennguon = "~";
            d.close(); this.Close();
        }
    }
}