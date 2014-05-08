using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmNhomtrongoi : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private AccessData m_v;
        private DataTable dt = new DataTable();
        private DataTable dtnhom = new DataTable();
        private string sql, s_nhom;

        public frmNhomtrongoi(LibVP.AccessData v_v)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m_v = v_v;
        }

        private void frmNhomtrongoi_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            sql = "select distinct a.* from medibv.v_nhomvp a,medibv.v_loaivp b where a.ma=b.id_nhom";          
            sql += " order by a.stt";
            dt = m_v.get_data(sql).Tables[0];

            cbten.DisplayMember = "TEN";
            cbten.ValueMember = "MA";
            cbten.DataSource = dt;

            if (cbten.Items.Count > 0)
            {
                cbten.SelectedIndex = 0;
                txtTen.Text = dt.Rows[cbten.SelectedIndex]["matat"].ToString();
            }           
            load_nhom();
        }

        private void load_nhom()
        {
            if (cbten.SelectedIndex != -1)
            {
                sql = "select distinct a.* from medibv.v_nhomvp a,medibv.v_loaivp b where a.ma=b.id_nhom";
                sql += " and a.ma<>" + int.Parse(cbten.SelectedValue.ToString());
                sql += " order by a.stt";
                dtnhom = m_v.get_data(sql).Tables[0];
                trongoi.DataSource = dtnhom;
                trongoi.DisplayMember = "TEN";
                trongoi.ValueMember = "MA";

                txtTen.Text = dt.Rows[cbten.SelectedIndex]["matat"].ToString();
                s_nhom = dt.Rows[cbten.SelectedIndex]["trongoi"].ToString().Trim();

                for (int i = 0; i < trongoi.Items.Count; i++)
                    if (s_nhom.IndexOf(dtnhom.Rows[i]["ma"].ToString().PadLeft(3, '0') + ",") != -1) trongoi.SetItemCheckState(i, CheckState.Checked);
                    else trongoi.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cbten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbten) load_nhom();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTen_Validated(object sender, EventArgs e)
        {
            try
            {
                DataRow r = m_v.getrowbyid(dt, "matat='" + txtTen.Text + "'");
                if (r != null)
                {
                    cbten.SelectedValue = r["ma"].ToString();
                    load_nhom();
                }
                else cbten.SelectedIndex = -1;
            }
            catch 
            { 
                cbten.SelectedIndex = -1; 
            }
        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (cbten.SelectedIndex == -1 && cbten.Items.Count > 0) cbten.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            s_nhom = "";
            for (int i = 0; i < trongoi.Items.Count; i++)
                if (trongoi.GetItemChecked(i)) s_nhom += dtnhom.Rows[i]["ma"].ToString().PadLeft(3, '0') + ",";
            if (s_nhom == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn nhóm trọn gói !"), m_v.s_AppName);
                trongoi.Focus();
                return;
            }
            m_v.execute_data("update medibv.v_nhomvp set trongoi='" + s_nhom + "' where ma=" + int.Parse(cbten.SelectedValue.ToString()));
            dt.Rows[cbten.SelectedIndex]["trongoi"] = s_nhom.ToString();
        }
    }
}