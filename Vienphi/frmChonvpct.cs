﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmChonvpct : Form
    {
        Language lan = new Language();
        private LibVP.AccessData m_v;
        private DataSet m_dsgiavp;
        private string m_mavp_chon = "";
        private string m_userid="";
        private string m_field_gia = "gia_th";
        private bool m_reset = false;

        public frmChonvpct(LibVP.AccessData v_v, string v_userid,string v_field_gia, DataSet v_dsgiavp)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            
            m_v = v_v;
            m_userid = v_userid;
            m_dsgiavp = v_dsgiavp;
            m_field_gia = v_field_gia.ToUpper();
            if (!(m_field_gia == "GIA_TH" || m_field_gia == "GIA_BH" || m_field_gia == "GIA_DV" || m_field_gia == "GIA_NN" || m_field_gia == "GIA_CS" || m_field_gia == "GIA_KSK"))
            {
                m_field_gia = "GIA_TH";
            }
            //m_v.f_SetEvent(this);
        }
        public bool s_reset
        {
            get
            {
                return m_reset;
            }
        }
        public string s_title
        {
            set
            {
                tmn_Title.Text=value.ToUpper().Trim();
            }
        }
        public bool s_chochon
        {
            set
            {
                tmn_Chon.Enabled = value;
            }
        }
        public string s_field_gia
        {
            set
            {
                m_field_gia = value.ToUpper();
                if (!(m_field_gia == "GIA_TH" || m_field_gia == "GIA_BH" || m_field_gia == "GIA_DV" || m_field_gia == "GIA_NN" || m_field_gia == "GIA_CS" || m_field_gia == "GIA_KSK"))
                {
                    m_field_gia = "GIA_TH";
                }
            }
        }
        public string s_mavp
        {
            get
            {
                return m_mavp_chon;
            }
        }
        private void frmChonvpct_Load(object sender, EventArgs e)
        {
            f_Load_DM();
            f_Load_Tree();
            f_Enable(false);
        }
        private void f_Enable(bool v_bool)
        {
            //tmn_Chon.Enabled = true;
            tmn_Clear.Enabled = true;
            tmn_Boqua.Enabled = true;
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
        private void f_Tinhtien()
        {
            try
            {
                decimal asotien = 0;
                foreach (TabPage atp in tabControl1.TabPages)
                {
                    foreach (Control c in atp.Controls)
                    {
                        try
                        {
                            CheckBox c1 = (CheckBox)(c);
                            if (c1.Checked)
                            {
                                asotien += decimal.Parse(m_dsgiavp.Tables[0].Select("id=" + c1.Tag.ToString())[0][m_field_gia].ToString().Trim().Replace(" ", ""));
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                tmn_Sotien.Text=asotien.ToString("### ### ##0.##");
            }
            catch
            {
                tmn_Sotien.Text = "0";
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
        public int f_GetWidthStringInPixel(System.Windows.Forms.CheckBox v_cb, string v_str)
        {
            try
            {
                int aWidth = 0;
                Graphics g = Graphics.FromHwnd(v_cb.Handle);
                StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
                SizeF size;
                size = g.MeasureString(v_str, v_cb.Font, 500, sf);
                //MessageBox.Show(size.Width.ToString());
                aWidth = (int)(size.Width) + 40;
                g.Dispose();
                return aWidth;
            }
            catch
            {
                return 0;
            }
        }
        private int f_XedichPixel(string v_str)
        {
            try
            {
                return v_str.Length * 1 / 10;
            }
            catch
            {
                return 0;
            }
        }
        private void f_Load_DM()
        {
            try
            {
                m_reset = false;
                tmn_Sotien.Text = "0";
                string atmp = "",aexp="";
                TabPage aTab = new TabPage("Test");
                CheckBox acheck = new CheckBox();
                int aleft = 3, atop = 3, awidth = 200, aheight = 26, amaxw = 350;
                int atabindex = 1;
                int aitemindex = 1;
                tabControl1.TabPages.Clear();

                foreach (DataRow r in m_dsgiavp.Tables[0].Select(aexp,"tennhom,id_nhom,tenloai,id_loai,ten"))
                {
                    try
                    {
                        if (r["id_loai"].ToString().Trim() != atmp)
                        {
                            atmp = r["id_loai"].ToString().Trim();
                            aTab = new TabPage(atabindex.ToString() + ". " + r["tenloai"].ToString().Trim() + "  ");
                            aTab.ForeColor = SystemColors.ControlText;
                            aTab.AutoScroll = true;
                            aTab.Tag = r["id_loai"].ToString().Trim();
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
                            toolTip1.SetToolTip(acheck, r["ten"].ToString().Trim() + " (" + decimal.Parse(r[m_field_gia].ToString()).ToString("### ### ##0.##").Trim() + "đ)");
                            atmp1 = r["ten"].ToString();

                            acheck.Text = aitemindex.ToString() + ". " + atmp1;
                            //amaxw = f_GetWidthStringInPixel(acheck, acheck.Text);
                            //awidth = awidth < amaxw ? amaxw : awidth;
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
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        DataSet adsloai, adsnhom;
        private void f_Load_Tree()
        {
            try
            {
                treeView1.Nodes.Clear();
                TreeNode anode, anode1;
                
                string asort = "ten";
                anode = new TreeNode("Tất cả");
                anode.Tag = "";
                //anode.ImageIndex = 2;
                //anode.SelectedImageIndex = 2;
                treeView1.Nodes.Add(anode);

                adsnhom = m_v.f_get_v_nhomvp_frmgiavp();
                adsloai = m_v.f_get_v_loaivp_frmgiavp();
                int i = 0;
                foreach (DataRow r in adsnhom.Tables[0].Select("", asort))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = "";// r["ma"].ToString() + ":?";
                    //anode.ImageIndex = 0;
                    //anode.SelectedImageIndex = 0;
                    treeView1.Nodes.Add(anode);
                    foreach (DataRow r1 in adsloai.Tables[0].Select("id_nhom=" + r["ma"].ToString(), asort))
                    {
                        if (m_dsgiavp.Tables[0].Select("id_loai=" + r1["id"].ToString()).Length > 0)
                        {
                            anode1 = new TreeNode(r1["ten"].ToString());
                            anode1.Tag = r1["id"].ToString();
                            //anode1.ImageIndex = 1;
                            //anode1.SelectedImageIndex = 1;
                            anode.Nodes.Add(anode1);
                            i++;
                        }
                    }
                    if (r["ten"].ToString().Trim() == "Thuốc")
                    {
                        //foreach (DataRow r1 in adsloai.Tables[0].Select("id_nhom=" + r["ma"].ToString(), asort))
                        //{
                            if (m_dsgiavp.Tables[0].Select("id_loai=-999").Length > 0)
                            {
                                anode1 = new TreeNode("Thuốc");
                                anode1.Tag = "-999";// r1["id"].ToString();
                                //anode1.ImageIndex = 1;
                                //anode1.SelectedImageIndex = 1;
                                anode.Nodes.Add(anode1);
                                i++;
                            }
                        //}
                    }
                }

                if (adsnhom.Tables[0].Select("ma=-1").Length < 0)
                {
                    DataRow ar = adsnhom.Tables[0].NewRow();
                    ar["ma"] = -1;
                    ar["ten"] = "...";
                    ar["idnhombhyt"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar, adsnhom.Tables[0].Rows.Count);
                }
                if (adsloai.Tables[0].Select("id=-1").Length < 0)
                {
                    DataRow ar1 = adsnhom.Tables[0].NewRow();
                    ar1["id"] = -1;
                    ar1["ten"] = "...";
                    ar1["id_nhom"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar1, adsloai.Tables[0].Rows.Count);
                }
            }
            catch
            {
            }
        }


        private void toolStrip_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DM();
        }
        private void butChon_Click(object sender, EventArgs e)
        {
            m_mavp_chon=f_GetItem();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void butClear_Click(object sender, EventArgs e)
        {
            try
            {
                m_mavp_chon = "";
                f_SetItem("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            m_mavp_chon = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                CheckBox c = (CheckBox)(sender);
                c.ForeColor = c.Checked ? Color.Red : SystemColors.ControlText;
                f_Tinhtien();
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

        private void tmn_Display_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.Multiline = !tabControl1.Multiline;
                tmn_Display.ToolTipText = (tabControl1.Multiline ? 
lan.Change_language_MessageText("Hiển thị một dòng") : 
lan.Change_language_MessageText("Hiển thị nhiều dòng"));
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
        private void frmChonvpct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    butBoqua_Click(null, null);
                }
            }
            catch
            {
            }
        }

        private void txtTimnhanh_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == this.txtTimnhanh.Control)
            {
                try
                {
                    chkAll.Checked = false;
                    for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    {
                        foreach (Control c in tabControl1.TabPages[i].Controls)
                        {
                            CheckBox chk = (CheckBox)(c);
                            if (chk.Text.ToUpper().IndexOf(txtTimnhanh.Text.ToUpper()) > 0)
                            {
                                chkAll.Text = chk.Text;
                                chkAll.Visible = true;
                                chkAll.Tag = chk.Tag.ToString();
                                tabControl1.SelectedTab.ScrollControlIntoView(c);
                                break;
                            }
                            else
                                chkAll.Visible = true;
                        }
                    }

                }
                catch
                {
                }
            }
        }

        private void txtTimnhanh_Leave(object sender, EventArgs e)
        {
            txtTimnhanh.Text = "Tìm kiếm";
        }

        private void txtTimnhanh_Click(object sender, EventArgs e)
        {
            txtTimnhanh.Text = "";
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl != chkAll) return;
            try
            {
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    foreach (Control c in tabControl1.TabPages[i].Controls)
                    {
                        CheckBox ck = (CheckBox)(c);
                        if (c.Tag.ToString() == chkAll.Tag.ToString())
                        {

                            chkAll.ForeColor = chkAll.Checked ? Color.Red : Color.Blue;
                            ck.Checked = chkAll.Checked;
                            ck.ForeColor = ck.Checked ? Color.Red : Color.Blue;
                            break;
                        }

                    }
                }
            }
            catch
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag.ToString() != "")
                {
                    for (int i = 0; i < tabControl1.TabCount; i++)
                    {
                        if (tabControl1.TabPages[i].Tag.ToString().Trim() == e.Node.Tag.ToString().Trim())
                        {
                            tabControl1.SelectedTab = tabControl1.TabPages[i];
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}