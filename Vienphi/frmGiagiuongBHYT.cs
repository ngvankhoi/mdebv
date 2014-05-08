using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmGiagiuongBHYT : Form
    {
        int userid = 0;
        LibVP.AccessData vp;
        Language lan = new Language();
        string sql = "", user = "";
        DataSet ds = new DataSet();

        public frmGiagiuongBHYT(LibVP.AccessData _vp,int _userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
            lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
            vp = _vp; userid = _userid;
        }

        private void frmGiagiuongBHYT_Load(object sender, EventArgs e)
        {
            user = vp.user;
            dataGridView1.AutoGenerateColumns = false;
            sql = "select * from "+user+".v_giagiuongbhyt order by id";
            ds = vp.get_data(sql);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(lan.Change_language_MessageText("Lỗi dữ liệu nhập!"),LibVP.AccessData.Msg);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butCapnhat_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in ds.Tables[0].GetChanges().Rows)
            {
                vp.execute_data("update " + user + ".v_giagiuongbhyt set dongia=" + r["dongia"].ToString() + " where id=" + r["id"].ToString());
                
            }
            MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công!"), LibVP.AccessData.Msg);
        }
    }
}