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
    public partial class frmChitiethd : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_id = "", m_mmyy = "", m_loaihd="";
        private LibVP.AccessData m_v;
        public frmChitiethd(LibVP.AccessData v_v, string v_id, string v_loaihd, string v_mmyy)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                m_v = v_v;
                m_id = v_id;
                m_loaihd = v_loaihd;
                m_mmyy = v_mmyy;
            }
            catch
            {
            }
        }
        public string s_ngayhd
        {
            set
            {
                lbNgay.Text = value;
            }
        }
        public string s_kyhieu
        {
            set
            {
                lbKyhieu.Text = value;
            }
        }
        public string s_sobienlai
        {
            set
            {
                lbNgay.Text = value;
            }
        }
        public string s_benhnhan
        {
            set
            {
                lbMabn.Text = value;
            }
        }
        public string s_diachi
        {
            set
            {
                lbDiachi.Text = value;
            }
        }
        public string s_nhanvien
        {
            set
            {
                lbNhanvien.Text = value;
            }
        }
        public string s_title_form
        {
            set
            {
                this.Text = value;
            }
        }
        private void frmChitiethd_Load(object sender, EventArgs e)
        {
            f_Load_DG();
        }
        private void f_Load_DG()
        {
            try
            {
                string sql = "";
                switch (m_loaihd)
                {
                    case "1"://TT
                        sql = "select b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as sotien, case when c.sotien is null then 0 else c.sotien end as mien from medibvmmyy.v_vienphict a left join (select id,ma,ten,dvt from medibv.v_giavp  union all select id,ma,ten,dang as dvt from medibv.d_dmbd) b on a.mavp=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibvmmyy.v_trongoi d on a.id=c.id where c.id is null and a.id=" + m_id + " order by b.ten";
                        break;
                    case "3"://NT
                        sql = "select b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as sotien, to_number(0,'9') as mien from medibvmmyy.v_ttrvct a left join (select id,ma,ten,dvt from medibv.v_giavp union all select id,ma,ten,dang as dvt from medibv.d_dmbd) b on a.mavp=b.id left join medibvmmyy.v_ttrvll c on a.id=c.id where a.id=" + m_id + " order by b.ten";
                        break;
                    case "4"://tg
                        sql = "select b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as sotien, case when c.sotien is null then 0 else c.sotien end as mien from medibvmmyy.v_vienphict a left join (select id,ma,ten,dvt from medibv.v_giavp  union all select id,ma,ten,dang as dvt from medibv.d_dmbd) b on a.mavp=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id inner join medibvmmyy.v_trongoi d on a.id=d.id where a.id=" + m_id + " order by b.ten";
                        break;
                }
                dataGridView1.DataSource = m_v.get_data_mmyy(m_mmyy,sql).Tables[0];
                tmn_Tong.Text = 
lan.Change_language_MessageText("Tổng số:")+" " + dataGridView1.RowCount.ToString() + " mục";
                dataGridView1.Update();
            }
            catch
            {
                tmn_Tong.Text = "";
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void tmn_Timnhanh_Enter(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.LightYellow;
                if (tmn_Timnhanh.Text.Trim().ToLower() == 
lan.Change_language_MessageText("Tìm kiếm"))
                {
                    tmn_Timnhanh.Text = "";
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_Leave(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.White;
                if (tmn_Timnhanh.Text.Trim() == "")
                {
                    tmn_Timnhanh.Text = 
lan.Change_language_MessageText("Tìm kiếm");
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                string atmp = tmn_Timnhanh.Text;
                if (atmp.ToLower().Trim() != "Tìm kiếm" && atmp.ToLower().Trim() != "")
                {
                    aft = "ma like '%" + atmp + "%' or ten like '%" + atmp + "%' or dvt like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}