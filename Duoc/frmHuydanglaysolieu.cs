using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Duoc
{
    public partial class frmHuydanglaysolieu : Form
    {
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private bool badmin;
        public frmHuydanglaysolieu( bool admin)
        {
            InitializeComponent();
            badmin = admin;
        }

        private void frmHuydanglaysolieu_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            load_gird();
            //butOk.Enabled = badmin;
        }
        private void load_gird()
        {
            DataTable dt = new DataTable();
            string user = d.user;
            string sql = "select to_number('0') as chon,d.hoten as tenuser,b.id as makp,b.ten as tenkp,c.id as sophieu,c.ten as phieu,a.computer,to_char(a.ngay,'dd/mm/yyyy') as ngay from "+user+".d_danglaysolieu a ";
            sql += " left join " + user + ".d_duockp b on a.makp=b.id left join " + user + ".d_loaiphieu c on a.phieu=c.id left join " + user + ".d_dlogin d on a.userid=d.id";
            sql += " where a.computer<>'" + System.Environment.MachineName + "'";
            dt = d.get_data(sql).Tables[0];
            dataGridView1.DataSource = dt;
            
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
                DataView dv = (DataView)cm.List;
                foreach (DataRow r in dv.Table.Select("chon=1"))
                {
                    d.del_danglaysolieu(int.Parse(r["makp"].ToString()), int.Parse(r["sophieu"].ToString()), r["ngay"].ToString());
                }
                load_gird();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}