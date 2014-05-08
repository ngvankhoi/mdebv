using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmOptiondoituong : Form
    {
        decimal s_userid;
        string s_option="";
        private LibVP.AccessData m_v=new LibVP.AccessData();
        private DataSet ads = new DataSet();
        private string s_doituong = "";
        public frmOptiondoituong(decimal auserid)
        {
            InitializeComponent();            
            s_userid = auserid;
            m_v.f_SetEvent(this);
        }
        public frmOptiondoituong(decimal auserid,string aoption)
        {
            InitializeComponent();
            s_userid = auserid;
            s_option = aoption;
            m_v.f_SetEvent(this);
        }
        private void frmOptiondoituong_Load(object sender, EventArgs e)
        {
            string s = "";
            try
            {
                string sql = "";
                if (s_option == "")
                {
                    sql = "select giatri from medibv.v_optionform where userid=" + s_userid + " and ma='TT_026'";
                }
                else
                {
                    sql = "select giatri from medibv.v_optionform where userid=" + s_userid + " and ma='"+s_option+"'";
                }
                 s= m_v.get_data(sql).Tables[0].Rows[0]["giatri"].ToString();
            }
            catch
            {
                s = "0";
            }
            ads = m_v.get_data("select madoituong,doituong from medibv.doituong order by madoituong");
            listDT.DataSource = ads.Tables[0];
            listDT.DisplayMember = "doituong";
            listDT.ValueMember = "madoituong";

            for(int i=0;i<listDT.Items.Count;i++)
                if (s.IndexOf(ads.Tables[0].Rows[i]["madoituong"].ToString() + ",") != -1) listDT.SetItemCheckState(i, CheckState.Checked);//gam 28/11/2011 
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            s_doituong = "";
            for (int i=0; i < listDT.Items.Count; i++)
            {
                if (listDT.GetItemChecked(i))
                {
                    //s_doituong += ads.Tables[0].Rows[i]["madoituong"].ToString().PadLeft(2,'0') + ",";//gam 18/10/2011 comment 
                    s_doituong += ads.Tables[0].Rows[i]["madoituong"].ToString() + ",";
                }
            }
            if (s_option != "")
            {
                m_v.upd_v_optionform(s_userid, 1, s_option, "Đối tượng thu", s_doituong.Trim());
            }
            else
            {
                m_v.upd_v_optionform(s_userid, 1, "TT_026", "Đối tượng thu", s_doituong.Trim());
            }
            this.Close();
        }
    }
}