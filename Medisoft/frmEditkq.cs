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
    public partial class frmEditkq : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private int stt;
        private DataTable dt;
        public string _dongia="", _lamthem="", _ketqua="", _ghichu = "";
        public bool bOk = false;
        public frmEditkq(AccessData acc,int tt,DataTable dta,string title)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 

            m = acc; stt = tt; dt = dta; this.Text = title;
            if (m.bBogo) tv.GanBogo(this, textBox111);
        }

        private void frmEditkq_Load(object sender, EventArgs e)
        {
            DataRow r = m.getrowbyid(dt, "stt=" + stt);
            if (r != null)
            {
                decimal st = (r["dongia"].ToString() == "") ? 0 : decimal.Parse(r["dongia"].ToString());
                dongia.Text = st.ToString("#,###,###,###");
                if (r["ngoaihd"].ToString().Trim() == "1") lamthem.Text = r["lamthem"].ToString();
                else lamthem.Enabled = false;
                ketqua.Text = r["ketqua"].ToString();
                ghichu.Text = r["ghichu"].ToString();
            }
        }

        private void dongia_Validated(object sender, EventArgs e)
        {
            decimal st = (dongia.Text == "") ? 0 : decimal.Parse(dongia.Text);
            dongia.Text = st.ToString("#,###,###,###");
        }

        private void dongia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{End}");
        }

        private void dongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            m.MaskDigit(e);
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            _dongia = dongia.Text; _lamthem = lamthem.Text; _ketqua = ketqua.Text; _ghichu = ghichu.Text;
            bOk = true;
            m.close();this.Close();
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ketqua.Text = "Bình thường";
        }
    }
}