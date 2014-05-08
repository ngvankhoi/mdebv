using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDanhsachinbienlaitaichinh : Form
    {
        private LibVP.AccessData m_v = new LibVP.AccessData();
        private string v_userid = "", sql = "";
        private DataSet ads=new DataSet();
        public string v_id = "", id_bienlai = "";
        public frmDanhsachinbienlaitaichinh(string s_userid)
        {
            v_userid = s_userid;
            InitializeComponent();
            //f_Load_DG();
        }

        private void frmDanhsachinbienlaitaichinh_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState=System.Windows.Forms.FormWindowState.Normal;
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }
        private void f_Load_DG()
        {
            
            sql = " select 0 as chon,quyenso,sobienlai,ngayhd,noidung,tendv,masothue,sotaikhoan,diachi,id from medibvmmyy.v_bienlaitaichinhll where to_date(to_char(ngayhd,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
            //ads=m_v.get_data_bc(txtTN.Value,txtDN.Value,sql);
            ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
            dgHoadon.DataSource = ads.Tables[0];
        }

        private void dgHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgHoadon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void f_chon()
        {
            try
            {
                //CurrencyManager mc=(CurrencyManager) BindingContext[dataGridView1.DataSource,dataGridView1.DataMember];
                //DataView dv = (DataView)mc.List;

                //foreach (DataRow r in dv.Table.Rows)
                //{
                //    v_id += r["idvienphi"].ToString() + ",";
                //}
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                id_bienlai = arv["id"].ToString();
            }
            catch
            {
 
            }
        }

        private void tmn_Chon_Click(object sender, EventArgs e)
        {
            f_chon();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtTimnhanh_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager mc=(CurrencyManager) BindingContext[dgHoadon.DataSource,dgHoadon.DataMember];
            DataView dv = (DataView)mc.List;
            dv.RowFilter = "tendv like '%"+txtTimnhanh.Text.Trim()+"%'";
        }

        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgHoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
            sql = "select a.mabn,hoten,tenkp,chiphi,idvienphi from medibvmmyy.v_bienlaitaichinhct a,medibv.btdbn b,medibv.btdkp_bv c where a.mabn=b.mabn and a.makp=c.makp and id=" + arv["id"].ToString() + "";
            dataGridView1.DataSource = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql).Tables[0];
        }
    }
}