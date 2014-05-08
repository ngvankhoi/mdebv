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
    public partial class frmDmthuocBYT : Form
    {
        private AccessData d = new AccessData();
        private Language lan = new Language();
        private string user = "";
        private DataSet ds_dmbd = new DataSet();

        public frmDmthuocBYT()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void frmDmthuocBYT_Load(object sender, EventArgs e)
        {
            user = d.user;
            readonly_columns1("hoatchat,duongdung");
            readonly_columns2("hoatchat05,duongdung05");
        }

        private void readonly_columns1(string columns)
        {
            dgthuoc.AutoGenerateColumns = false;
            foreach (string st in columns.Split(','))
            {
                dgthuoc.Columns[st].ReadOnly = true;
            }
        }

        private void readonly_columns2(string columns)
        {
            dgthuoc05.AutoGenerateColumns = false;
            foreach (string st in columns.Split(','))
            {
                dgthuoc05.Columns[st].ReadOnly = true;
            }
        }

        private void Load_CB(DataGridView dgv)
        {
            if (dgv.Name.Trim() == "dgthuoc") cboloaithuoc.DataSource = null;
            else if (dgv.Name.Trim() == "dgthuoc05")
            {
                string sql = "";
                sql = "select id,ten from " + user + ".d_dmloaithuoc order by id";
                cboloaithuoc.DisplayMember = "TEN";
                cboloaithuoc.ValueMember = "ID";
                cboloaithuoc.DataSource = d.get_data(sql).Tables[0];
            }
        }

        private void Load_data(DataGridView dgv,string dk,string loaithuoc)
        {
            ds_dmbd.Clear();
            string sql = "";
            if (dgv.Name.Trim() == "dgthuoc")
            {
                sql = "select id,ma,(ten||'-'||hamluong) as hoatchat,duongdung,ketoa,stt05 as stt,sttbyt,tuyen from " + user + ".d_dmbd ";
                if (dk != "") sql += "where (lower(ten) like'%" + dk + "%' or lower(hamluong) like '%" + dk + "%' or lower(duongdung) like '%" + dk + "%') ";
                sql += "order by stt";
            }
            else if (dgv.Name.Trim() == "dgthuoc05")
            {
                sql = "select id as id05,ma,(ten||'-'||hamluong) as hoatchat05,duongdung as duongdung05,ketoa,stt05 as stt,sttbyt,tuyen from " + user + ".d_dmbd ";
                if (dk != "") sql += "where (lower(ten) like'%" + dk + "%' or lower(hamluong) like'%" + dk + "%' or lower(duongdung) like '%" + dk + "%') ";
                if (loaithuoc != "") sql += "where idloaithuoc=" + loaithuoc.Trim() + " ";
                sql += "order by stt";
            }
            ds_dmbd = d.get_data(sql);
            dgv.DataSource = ds_dmbd.Tables[0];
            int i=0;
            foreach (DataRow r in ds_dmbd.Tables[0].Rows)
            {
                if(dgv.Name.Trim() == "dgthuoc")
                {
                    if (r["ketoa"].ToString() == "1")
                    {
                        dgthuoc["chon",i].Value = "true";
                    }
                }
                if (dgv.Name.Trim() == "dgthuoc05")
                {
                    if (r["tuyen"].ToString() == "1")
                    {
                        dgthuoc05["tuyentu", i].Value = "true";
                        dgthuoc05["tuyentinh", i].Value = "true";
                        dgthuoc05["tuyenhuyen", i].Value = "true";
                        dgthuoc05["tuyenxa", i].Value = "true";
                    }
                    else if (r["tuyen"].ToString() == "2")
                    {
                        dgthuoc05["tuyentinh", i].Value = "true";
                        dgthuoc05["tuyenhuyen", i].Value = "true";
                        dgthuoc05["tuyenxa", i].Value = "true";
                    }
                    else if (r["tuyen"].ToString() == "3")
                    {
                        dgthuoc05["tuyenhuyen", i].Value = "true";
                        dgthuoc05["tuyenxa", i].Value = "true";
                    }
                    else if (r["tuyen"].ToString() == "4")
                    {
                        dgthuoc05["tuyenxa", i].Value = "true";
                    }
                }
                i++;
            }
        }

        private void cbodm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbodm)
            {
                if (cbodm.SelectedIndex == 0)
                {
                    dgthuoc.Visible = true;
                    dgthuoc05.Visible = false;
                    Load_CB(dgthuoc);
                    Load_data(dgthuoc,"","");
                }
                else if (cbodm.SelectedIndex == 1)
                {
                    dgthuoc.Visible = false;
                    dgthuoc05.Visible = true;
                    Load_CB(dgthuoc05);
                    Load_data(dgthuoc05,"","");
                }
            }
        }

        private void butketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butluu_Click(object sender, EventArgs e)
        {
            if (dgthuoc.Visible)
            {
                for (int i = 0; i < dgthuoc.RowCount; i++)
                {
                    if (dgthuoc["chon", i].Value != null)
                    {
                        d.execute_data("update " + user + ".d_dmbd set ketoa=1 where id=" + dgthuoc["id", i].Value + "");
                    }
                }
                Load_data(dgthuoc,"","");
            }
            else if (dgthuoc05.Visible)
            {
                for (int i = 0; i < dgthuoc05.RowCount; i++)
                {
                    int i_stt = (dgthuoc05["stt", i].Value == null) ? 0 : int.Parse(dgthuoc05["stt", i].Value.ToString());
                    int i_tuyen = (dgthuoc05["tuyentu", i].Value != null) ? 1 : (dgthuoc05["tuyentinh", i].Value != null) ? 2 : (dgthuoc05["tuyenhuyen", i].Value != null) ? 3 : (dgthuoc05["tuyenxa", i].Value != null) ? 4 : 0;
                    d.execute_data("update " + user + ".d_dmbd set stt05=" + i_stt + ",sttbyt=" + i_stt + ",tuyen=" + i_tuyen + " where id=" + dgthuoc05["id05", i].Value + "");
                }
                Load_data(dgthuoc05,"","");
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            if (dgthuoc.Visible)
                Load_data(dgthuoc,txttimkiem.Text.ToLower(),"");
            else if (dgthuoc05.Visible) Load_data(dgthuoc05,txttimkiem.Text.ToLower(),"");
        }

        private void txttimkiem_MouseClick(object sender, MouseEventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void cboloaithuoc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cboloaithuoc)
                Load_data(dgthuoc05, "", cboloaithuoc.SelectedValue.ToString());
        }
    }
}