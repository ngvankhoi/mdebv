using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDoiso : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid = "";
        public frmDoiso(LibVP.AccessData v_v, string v_userid)
        {
            m_v = v_v;
            m_userid = v_userid;
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            f_Load_Data();
        }
        public string s_quyenso
        {
            get
            {
                try
                {
                    return cbKyhieu.SelectedValue.ToString();
                }
                catch
                {
                    return "";
                }
            }
        }
        public string s_tenquyenso
        {
            get
            {
                try
                {
                    return cbKyhieu.Text.ToString();
                }
                catch
                {
                    return "";
                }
            }
        }
        private void f_Load_Data()
        {
            try
            {
                string sql = "";
                sql = "select id,sohieu,loai,userid from medibv.v_quyenso";
                if (!m_v.sys_dungchungso)
                {
                    sql += " where userid = " + m_userid;
                }
                sql += " order by sohieu desc";
                cbKyhieu.DataSource = m_v.get_data(sql).Tables[0];
                cbKyhieu.DisplayMember = "sohieu";
                cbKyhieu.ValueMember = "id";
            }
            catch
            {
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

        private void frmDoiso_Load(object sender, EventArgs e)
        {
        }

        private void cbKyhieu_KeyDown(object sender, KeyEventArgs e)
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