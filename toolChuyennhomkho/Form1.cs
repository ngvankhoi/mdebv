using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;
namespace toolChuyennhomkho
{
    public partial class Form1 : Form
    {
        LibDuoc.AccessData d = new LibDuoc.AccessData();
        public Form1()
        {
            InitializeComponent();
        }

        private void f_load_dmnhomkho()
        {
            string asql = "select * from " + d.user + ".d_dmnhomkho where id>0 ";
            DataSet ads = d.get_data(asql);

            cmbNhomkhonguon.DataSource = ads.Tables[0].Copy();            
            cmbNhomkhonguon.DisplayMember = "TEN";
            cmbNhomkhonguon.ValueMember= "ID";

            cmbNhomkhoDich.DataSource = ads.Tables[0].Copy();
            cmbNhomkhoDich.DisplayMember = "TEN";
            cmbNhomkhoDich.ValueMember = "ID";
        }
        private void butChuyen_Click(object sender, EventArgs e)
        {
            if (cmbNhomkhoDich.SelectedValue.ToString() == cmbNhomkhonguon.SelectedValue.ToString())
            {
                MessageBox.Show("Chọn nhóm kho chuyển danh mục");
                cmbNhomkhoDich.Focus();
                return;
            }
            Cursor = Cursors.WaitCursor;
            f_chuyen_all_dm();
            Cursor = Cursors.Default;
        }

        private int f_get_maxid(string m_table)
        {
            int m_id=0;
            string asql = "select max (id) as id from " + d.user + "." + m_table + " where id >0 ";
            DataSet ads = d.get_data(asql);
            if (ads == null || ads.Tables.Count <= 0 || ads.Tables[0].Rows.Count <= 0)
            {
                m_id = 1;
            }
            else
            {
                m_id = (ads.Tables[0].Rows[0]["id"].ToString() == "") ? 1 : int.Parse(ads.Tables[0].Rows[0]["id"].ToString());
            }

            return m_id;
        }
        private void f_Chuyen_dmbd(int d_nhomkho_nguon, int d_nhomkho_dich)
        {
            int m_id = f_get_maxid("d_dmbd");
            string s_userdb = d.user;
            string asql = "select id from " + s_userdb + ".d_dmbd where nhom=" + d_nhomkho_dich;
            DataSet ads = d.get_data(asql);
            if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Danh mục d_dmbd đã chuyển.");
                return;
            }
            string s_field = d.f_get_select_field("d_dmbd", "","a");
            s_field = s_field.Replace("a.id,","a.id+"+ m_id + " as id,");
            s_field = s_field.Replace("a.nhom,", d_nhomkho_dich + " as nhom,");
            asql = " insert into " + s_userdb + ".d_dmbd ";
            asql += "select " + s_field + " from " + s_userdb + ".d_dmbd a where nhom=" + d_nhomkho_nguon;
            d.execute_data(asql);

            asql = "update " + s_userdb + ".d_dmbd set ma=null where nhom=" + d_nhomkho_dich;
            d.execute_data(asql);
            asql = "select id, ma, ten from " + s_userdb + ".d_dmbd where nhom=" + d_nhomkho_dich;
            ads = d.get_data(asql);
            string s_ma = "";
            foreach (DataRow dr in ads.Tables[0].Rows)
            {
                s_ma = d.getMabd("d_dmbd", dr["ten"].ToString(), d_nhomkho_dich);
                if (s_ma != "")
                {
                    asql = "update " + s_userdb + ".d_dmbd set ma='" + s_ma + "' where id=" + dr["id"].ToString();
                    d.execute_data(asql);
                }
                lblStatus.Text = dr["ten"].ToString();
                lblStatus.Refresh();
            }
        }

        private void f_Chuyen_dmkhac(string m_table, int d_nhomkho_nguon, int d_nhomkho_dich, string m_fieldlienket_dmbd)
        {
            int m_id = f_get_maxid(m_table);
            string s_userdb = d.user;
            string asql = "";
            asql = "select id from " + s_userdb + "." + m_table + " where nhom=" + d_nhomkho_dich;
            DataSet ads = d.get_data(asql);
            if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Danh mục " + m_table + " đã chuyển.");
                return;
            }
            string s_field = d.f_get_select_field(m_table, "", "a");
            s_field = s_field.Replace("a.id,","a.id+"+ m_id + " as id,");
            s_field = s_field.Replace("a.nhom,", d_nhomkho_dich + " as nhom,");
            asql = " insert into " + s_userdb + "." + m_table;
            asql += " select " + s_field + " from " + s_userdb + "." + m_table + " a where nhom=" + d_nhomkho_nguon + " and id>0 ";
            d.execute_data(asql);

            if (m_fieldlienket_dmbd != "")
            {
                asql = "update " + s_userdb + ".d_dmbd set " + m_fieldlienket_dmbd + "=" + m_fieldlienket_dmbd + "+" + m_id + " where nhom=" + d_nhomkho_dich + " and " + m_fieldlienket_dmbd + "<>0";
                d.execute_data(asql);
            }
        }

        private void f_chuyen_all_dm()
        {
            if (chkdmbd.Checked)
            {
                f_Chuyen_dmbd(int.Parse(cmbNhomkhonguon.SelectedValue.ToString()), int.Parse(cmbNhomkhoDich.SelectedValue.ToString()));
            }

            if (chkdmnhom.Checked)
            {
                f_Chuyen_dmkhac("d_dmnhom", int.Parse(cmbNhomkhonguon.SelectedValue.ToString()), int.Parse(cmbNhomkhoDich.SelectedValue.ToString()), "manhom");
            }
            if (chkLoai.Checked)
            {
                f_Chuyen_dmkhac("d_dmloai", int.Parse(cmbNhomkhonguon.SelectedValue.ToString()), int.Parse(cmbNhomkhoDich.SelectedValue.ToString()), "maloai");
            }

            if (chkHang.Checked)
            {
                f_Chuyen_dmkhac("d_dmhang", int.Parse(cmbNhomkhonguon.SelectedValue.ToString()), int.Parse(cmbNhomkhoDich.SelectedValue.ToString()), "mahang");
            }

            if (chkdmnuoc.Checked)
            {
                f_Chuyen_dmkhac("d_dmnuoc", int.Parse(cmbNhomkhonguon.SelectedValue.ToString()), int.Parse(cmbNhomkhoDich.SelectedValue.ToString()), "manuoc");
            }
            

            if (chkdmnx.Checked)
            {
                f_Chuyen_dmkhac("d_dmnx", int.Parse(cmbNhomkhonguon.SelectedValue.ToString()), int.Parse(cmbNhomkhoDich.SelectedValue.ToString()), "");
            }

            if (chkNhombo.Checked)
            {
                f_Chuyen_dmkhac("d_nhombo", int.Parse(cmbNhomkhonguon.SelectedValue.ToString()), int.Parse(cmbNhomkhoDich.SelectedValue.ToString()), "nhombo");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f_load_dmnhomkho();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}