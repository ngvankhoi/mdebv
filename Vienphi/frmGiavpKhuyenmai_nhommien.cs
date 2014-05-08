using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmGiavpKhuyenmai_nhommien : Form
    {
        LibVP.AccessData v;
        Language lan = new Language();
        int i_userid = 0;
        string sql = "";
        DataTable dt = new DataTable();
        DataTable dtdotkm = new DataTable();

        public frmGiavpKhuyenmai_nhommien(LibVP.AccessData _v, int _userid)
        {
            InitializeComponent();
            v = _v;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            lan.Read_dtgrid_to_Xml(dataGridView2, this.Name + "_" + "dataGridView2");
            lan.Change_dtgrid_HeaderText_to_English(dataGridView2, this.Name + "_" + "dataGridView2");
            i_userid = _userid;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiavpKhuyenmai_nhommien_Load(object sender, EventArgs e)
        {
            sql = "select * from " + v.user + ".v_dot_khuyenmai where loai=1" ;
            dtdotkm = v.get_data(sql).Tables[0];
            cmbDotkm.DataSource = dtdotkm;
            cmbDotkm.DisplayMember = "ten";
            cmbDotkm.ValueMember = "id";
            if (dtdotkm.Rows.Count != 0)
            {
                cmbDotkm.SelectedIndex = 0;
                cmbDotkm_SelectedIndexChanged(null, null);
            }
        }

        private void load_grid()
        {
            if (dtdotkm.Rows.Count != 0)
            {
                try
                {
                    sql = "select b.id,b.ten,nvl(a.tyle,0) tyle,b.sudung from " + v.user + ".v_nhommien b left join " + v.user + ".v_km_nhommien a on a.id_nhommien=b.id and a.iddot=" + cmbDotkm.SelectedValue +" order by b.id";
                    dt = v.get_data(sql).Tables[0];
                    dataGridView2.DataSource = dt;
                }
                catch { }
            }
        }

        private void cmbDotkm_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid();
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ không hợp lệ!"),v.s_AppName);
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            load_grid();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (int.Parse(dt.Rows[i]["tyle"].ToString()) > 100 || int.Parse(dt.Rows[i]["tyle"].ToString()) < 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ không hợp lệ!"), v.s_AppName);
                        return;
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!v.upd_v_km_nhommien(int.Parse(cmbDotkm.SelectedValue.ToString()), int.Parse(dt.Rows[i]["id"].ToString()), int.Parse(dt.Rows[i]["tyle"].ToString()), i_userid))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được tỷ lệ khuyến mại!"), v.s_AppName);
                        return;
                    }
                }
                MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công!"), v.s_AppName);
            }
            catch {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được tỷ lệ khuyến mại!"), v.s_AppName);
            }
        }
    }
}