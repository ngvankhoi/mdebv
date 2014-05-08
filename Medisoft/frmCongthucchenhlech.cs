using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmCongthucchenhlech : Form
    {
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private DataSet ds = new DataSet();
        private DataTable dtgia;
        private DataTable dtloaivp;
        public frmCongthucchenhlech()
        {
            InitializeComponent();
        }
        
        private void frmCongthucchenhlech_Load(object sender, EventArgs e)
        {
            string sql = "select id,ten as loaivp from medibv.v_loaivp order by ten";

            dtloaivp = m.get_data(sql).Tables[0];


            sql = "select 'gia_th' as ten from dual union all select 'gia_bh' as ten from dual union all ";
            sql += "select 'gia_cs' as ten from dual union all select 'gia_dv' as ten from dual union all select 'gia_nn' as ten from dual";
            dtgia = m.get_data(sql).Tables[0];

            clloaivp.DisplayMember = "loaivp";
            clloaivp.ValueMember = "loaivp";
            clloaivp.DataSource = dtloaivp;

            clgia_1.DisplayMember = "ten";
            clgia_1.ValueMember = "ten";
            clgia_1.DataSource = dtgia;

            clgia_2.DisplayMember = "ten";
            clgia_2.ValueMember = "ten";
            clgia_2.DataSource = dtgia;

            sql = "select to_number('0') as id , 'Đúng tuyến' as ten from dual union all select to_number('1') as id , 'Trái tuyến' as ten from dual";
            cbloai.DisplayMember = "ten";
            cbloai.ValueMember = "id";
            cbloai.DataSource = m.get_data(sql).Tables[0];

        }

        private void load_gird()
        {
            string sql = "select b.ten as loaivp, a.gia_1,a.gia_2 from medibv.congthucchenhlech a inner join medibv.v_loaivp b on a.id_loaivp = b.id where loai="+ cbloai.SelectedValue.ToString();
            ds = m.get_data(sql);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DataRow r_tam;
            string s_idloaivp;
            m.execute_data("delete from medibv.congthucchenhlech where loai="+cbloai.SelectedValue.ToString());
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                r_tam = m.getrowbyid(dtloaivp, "loaivp='" + dataGridView1["clloaivp", i].Value.ToString() + "'");
                s_idloaivp = r_tam["id"].ToString();
                m.upd_congthucchenhlech(int.Parse(s_idloaivp), int.Parse(cbloai.SelectedValue.ToString()), dataGridView1["clgia_1", i].Value.ToString(), dataGridView1["clgia_2", i].Value.ToString());
            }
            load_gird();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_gird();
        }
    }
}