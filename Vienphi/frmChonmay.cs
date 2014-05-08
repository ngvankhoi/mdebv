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
    public partial class frmChonmay : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_computer="";
        private LibVP.AccessData m_v;
        public frmChonmay(LibVP.AccessData v_v,string v_computer)
        {
            try
            {
                InitializeComponent();

                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                m_v = v_v;
                m_computer
                = v_computer;
            }
            catch
            {
            }
        }
        public string s_computer
        {
            get
            {
                return m_computer;
            }
        }
        private void frmChonmay_Load(object sender, EventArgs e)
        {
            
            f_Load_DG();
        }
        private void f_Load_DG()
        {
            try
            {
                DataSet ads = m_v.f_get_dmcomputer();
                dataGridView1.DataSource = ads.Tables[0];
                //for (int i = 0; i < ads.Tables[0].Rows.Count; i++)
                //{
                //    if(dataGridView1["computer",i]==m_computer)
                //    {
                //    }
                //}
                lbDG.Text = lan.Change_language_MessageText("Danh sách máy tính sử dụng Medisoft (") + ads.Tables[0].Rows.Count.ToString() + ")";
            }
            catch
            {
                lbDG.Text = lan.Change_language_MessageText("Danh sách máy tính sử dụng Medisoft");
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butChon_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView r = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                m_computer = r["computer"].ToString();
                this.Close();
            }
            catch
            {
            }
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }
    }
}