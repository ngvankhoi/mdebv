using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmGioihanVP : Form
    {
        private LibVP.AccessData m_v=LibVP.AccessData.GetImplement();
        private decimal m_userid ;
        private string m_thongso = "";
        private DataSet m_dsgiavp = new DataSet();
       
        public frmGioihanVP(decimal s_userid,string s_tenuser)
        {
            InitializeComponent();
            m_userid = s_userid;
            toolStrip_ten.Text = s_tenuser;
        }

        public frmGioihanVP(decimal s_userid, string s_tenuser, string s_thongso)
        {
            InitializeComponent();
            m_userid = s_userid;
            toolStrip_ten.Text = s_tenuser;
            m_thongso = s_thongso;
        }

        private void frmGioihanVP_Load(object sender, EventArgs e)
        {
            f_LoadDM();
            f_SetItem(m_v.tt_gioihan_mavp(m_userid.ToString()));
        }
        private void f_LoadDM()
        {
            try
            {
                m_dsgiavp = m_v.get_data("select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs, trim(b.ten) as tenloai,b.id as id_loai, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id order by b.ten,b.stt, b.id, a.ten,a.stt");

               
                string atmp = "";
                TabPage aTab = new TabPage("Test");
                CheckBox acheck = new CheckBox();
                int aleft = 3, atop = 3, awidth = 200, aheight = 26, amaxw = 350;
                int atabindex = 1;
                int aitemindex = 1;
                tabControl1.TabPages.Clear();

                foreach (DataRow r in m_dsgiavp.Tables[0].Rows)
                {
                    if (r["id_loai"].ToString().Trim() != atmp)
                    {
                        atmp = r["id_loai"].ToString().Trim();
                        aTab = new TabPage(atabindex.ToString() + ". " + r["tenloai"].ToString().Trim() + "  ");
                        aTab.ForeColor = SystemColors.ControlText;
                        aTab.AutoScroll = true;
                        tabControl1.TabPages.Add(aTab);
                        atop = 3;
                        aleft = 3;
                        atabindex += 1;
                        aitemindex = 1;
                    }
                    if (r["id_loai"].ToString().Trim() == atmp)
                    {
                        string atmp1 = r["ten"].ToString();
                        acheck = new CheckBox();
                        acheck.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
                        acheck.MouseHover += new System.EventHandler(this.checkBox_MouseHover);
                        acheck.MouseLeave += new System.EventHandler(this.checkBox_MouseLeave);

                        acheck.Name = r["id"].ToString();
                        acheck.Tag = r["id"].ToString();
                      //  toolTip1.SetToolTip(acheck, r["ten"].ToString().Trim() + " (" + decimal.Parse(r[m_field_gia].ToString()).ToString("### ### ##0.##").Trim() + "đ)");
                        atmp1 = r["ten"].ToString();

                        acheck.Text = aitemindex.ToString() + ". " + atmp1;
                        acheck.Width = amaxw;
                        acheck.Height = aheight;
                        acheck.Left = aleft;
                        acheck.Top = atop;
                        aTab.Controls.Add(acheck);
                        acheck.BringToFront();
                        aitemindex += 1;

                        atop = atop + acheck.Height;
                        if (atop > tabControl1.Height - 70)
                        {
                            atop = 3;
                            aleft = aleft + awidth;
                        }
                    }
                }
            }
            catch
            {
 
            }
        }
        private string f_GetItem()
        {
            try
            {
                string r = "";
                foreach (TabPage atp in tabControl1.TabPages)
                {
                    foreach (Control c in atp.Controls)
                    {
                        try
                        {
                            CheckBox c1 = (CheckBox)(c);
                            if (c1.Checked)
                            {
                                r = r.Trim().Trim(',') + "," + c1.Tag.ToString();
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                r = r.Trim().Trim(',');
                return r;
            }
            catch
            {
                return "";
            }
        }

        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                CheckBox c = (CheckBox)(sender);
                c.ForeColor = c.Checked ? Color.Red : SystemColors.ControlText;                
            }
            catch
            {
            }
        }
        private void checkBox_MouseHover(object sender, System.EventArgs e)
        {
            try
            {
                CheckBox c = (CheckBox)(sender);
                c.ForeColor = c.Checked ? Color.Brown : Color.Blue;
            }
            catch
            {
            }
        }
        private void checkBox_MouseLeave(object sender, System.EventArgs e)
        {
            try
            {
                CheckBox c = (CheckBox)(sender);
                c.ForeColor = c.Checked ? Color.Red : SystemColors.ControlText;//Color.FromArgb(0,51,0)
            }
            catch
            {
            }
        }

        private void tmn_Chonall_Click(object sender, EventArgs e)
        {
            try
            {
                f_SetItem(tabControl1.SelectedTab, true);
            }
            catch
            {
            }
        }

        private void tmn_Bochonall_Click(object sender, EventArgs e)
        {
            try
            {
                f_SetItem(tabControl1.SelectedTab, false);
            }
            catch
            {
            }
        }
        private void f_SetItem(string v_mavp)
        {
            string amavp = v_mavp.Trim() + ",";
            try
            {
                foreach (TabPage atp in tabControl1.TabPages)
                {
                    foreach (Control c in atp.Controls)
                    {
                        try
                        {
                            CheckBox c1 = (CheckBox)(c);
                            c1.Checked = amavp.IndexOf(c1.Tag.ToString() + ",") >= 0;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void f_SetItem(TabPage v_tp, bool v_bool)
        {
            try
            {
                foreach (Control c in v_tp.Controls)
                {
                    try
                    {
                        CheckBox c1 = (CheckBox)(c);
                        c1.Checked = v_bool;
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Luu_Click(object sender, EventArgs e)
        {
            string mavp = "";
            try
            {
                foreach (TabPage atp in tabControl1.TabPages)
                {
                    foreach (Control c in atp.Controls)
                    {
                        try
                        {
                            CheckBox c1 = (CheckBox)(c);
                            if (c1.Checked) mavp+= c1.Tag.ToString() + ",";
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }

            if (m_thongso == "") m_v.upd_v_optionform(m_userid, 1, "TT_005_MAVP", "TT_005_MAVP", mavp);
            else m_v.upd_v_optionform(m_userid, 1, m_thongso, m_thongso, mavp);
        }
    }
}