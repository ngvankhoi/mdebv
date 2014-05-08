using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmHotkey : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_loai="",m_userid="",m_loai_hotkey="";
        public frmHotkey(LibVP.AccessData v_v, string v_userid, string v_loai, string v_loai_ksk)
        {
            m_v = v_v;
            m_loai = v_loai;
            m_userid = v_userid;
            m_loai_hotkey = v_loai_ksk;
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        public string s_hotkey
        {
            get
            {
                return cbHotkey.Text;
            }
        }
        public string s_ghichu
        {
            get
            {
                return txtGhichu.Text;
            }
        }
        private void cbHotkey_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string atable = m_loai_hotkey == "1" ? "_ksk" : "";
                txtGhichu.Text = m_v.get_data("select ghichu from medibv.v_optionhotkey" + atable + " where hotkey='"+cbHotkey.Text+"' and loai=" + m_loai + " and userid = " + m_userid +" limit 1").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                txtGhichu.Text = "";
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmHotkey_Load(object sender, EventArgs e)
        {
            try
            {
                cbHotkey.SelectedIndex = 0;
                cbHotkey_SelectedIndexChanged(null, null);
            }
            catch
            {
            }
        }

        private void cbHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtGhichu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }
    }
}