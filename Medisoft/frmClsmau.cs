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
    public partial class frmClsmau : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private DataTable dt = new DataTable();
        private int loai, vung;
        private string chandoan, mabs,sql,user;
        public string ret = "";
        public frmClsmau(AccessData acc,int _loai,int _vung,string _chandoan,string _mabs)
        {
            InitializeComponent();
            m = acc; loai = _loai; vung = _vung; chandoan = _chandoan; mabs = _mabs;
        }

        private void frmClsmau_Load(object sender, EventArgs e)
        {
            user = m.user;
            sql = "select a.id,trim(b.hoten)||' - '||trim(a.chandoan) as ghichu,a.ten from " + user + ".cls_mau a inner join " + user + ".dmbs b on a.mabs=b.ma ";
            sql += " where loai=" + loai + " and vung=" + vung;
            if (mabs != "") sql += " and a.mabs='" + mabs + "'";
            if (chandoan != "") sql += " and a.chandoan='" + chandoan + "'";
            sql += " order by mabs,id";
            dt = m.get_data(sql).Tables[0];
            mau.DataSource = dt;
            mau.DisplayMember = "ghichu";
            mau.ValueMember = "id";
            if (mau.Items.Count > 0)
            {
                mau.SelectedIndex = 0;
                ten.Text=dt.Rows[mau.SelectedIndex]["ten"].ToString();
            }
        }

        private void mau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butChon_Click(object sender, EventArgs e)
        {
            ret = ten.Text;
            m.close();this.Close();
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void mau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == mau && mau.SelectedIndex != -1) ten.Text = dt.Rows[mau.SelectedIndex]["ten"].ToString();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkAll)
            {
                sql = "select a.id,trim(b.hoten)||' - '||trim(a.chandoan) as ghichu,a.ten from " + user + ".cls_mau a inner join " + user + ".dmbs b on a.mabs=b.ma ";
                sql += " where loai=" + loai + " and vung=" + vung;
                if (!chkAll.Checked)
                {
                    if (mabs != "") sql += " and a.mabs='" + mabs + "'";
                    if (chandoan != "") sql += " and a.chandoan='" + chandoan + "'";
                }
                sql += " order by mabs,id";
                dt = m.get_data(sql).Tables[0];
                mau.DataSource = dt;
                if (mau.Items.Count > 0)
                {
                    mau.SelectedIndex = 0;
                    ten.Text = dt.Rows[mau.SelectedIndex]["ten"].ToString();
                }
            }
        }
    }
}