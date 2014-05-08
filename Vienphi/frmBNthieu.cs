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
    public partial class frmBNthieu : Form
    {
        private AccessData m_v;
        private string m_userid = "", amabn = "", sql = "", v_ngaytra = "";
        private DataSet m_ds = new DataSet();
        public frmBNthieu(AccessData v_v,string s_userid,string s_mabn,string s_ngaytra)
        {
            InitializeComponent();
            m_v = v_v;
            m_userid = s_userid;
            amabn = s_mabn;
            v_ngaytra = s_ngaytra;
        }
        public DataSet s_ds
        {
            get
            {
                return m_ds;
            }
        }
        private void frmBNthieu_Load(object sender, EventArgs e)
        {
            f_Load_DataGrid();
        }
        private void f_Load_DataGrid()
        {
            sql = "select 1 as chon,mabn,to_char(ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(ngayra,'dd/mm/yyyy hh24:mi') as ngayra,to_char(ngaythu,'dd/mm/yyyy hh24:mi') as ngaythu,sotien,sotientra,id from medibv.v_ttrvthatthu where mabn='" + amabn + "'  and sotien<>sotientra ";
            m_ds=m_v.get_data(sql);
            dataGridView1.DataSource = m_ds.Tables[0];
        }
     

        private void toolStrip_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager mc = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
                DataView dv = (DataView)mc.List;
                foreach (DataRow r in dv.Table.Rows)
                {
                    m_v.execute_data("update medibv.v_ttrvthatthu set sotientra=" + r["sotientra"].ToString() + ",useridtra=" + m_userid + ",ngaytra=to_date('" + v_ngaytra.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') where id=" + r["id"].ToString() + "");
                   
                }
                // f_Load_DataGrid();                
            }
            catch
            {
 
            }
        }

        private void toolStrip_Boqua_Click(object sender, EventArgs e)            
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}