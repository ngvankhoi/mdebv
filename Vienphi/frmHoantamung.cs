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
    public partial class frmHoantamung : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private DataSet m_ds;
        private string m_mabn = "", m_maql = "", m_tn = "", m_dn = "", m_mavaovien = "";
        private LibVP.AccessData m_v;
        

        public frmHoantamung(LibVP.AccessData v_v, string v_mabn, string v_maql, string v_tn, string v_dn,string s_mavaovien)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
                lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
                m_v = v_v;
                m_mabn = v_mabn;
                m_maql = v_maql;
                m_mavaovien = s_mavaovien;
                m_tn = v_tn;
                m_dn = v_dn;
               
            }
            catch
            {
            }
        }
        public DataSet s_ds
        {
            get
            {
                return m_ds;
            }
        }
        private void frmHoantamung_Load(object sender, EventArgs e)
        {
            f_Load_DG();
        }
        private void f_Load_DG()
        {
            try
            {
                string sql = "", m_maql_phongluu = "", asql_luu = "", asql_tiepdon = "", m_maql_tiepdon = "";
                try
                {
                    m_maql_phongluu = m_v.get_maql_benhancc(m_mavaovien, m_mabn,m_dn.Substring(0,10)).ToString();
                }
                catch
                {
                    m_maql_phongluu = "0";
                }
                try
                {
                    m_maql_tiepdon = m_v.get_maql_tiepdon(m_mavaovien, m_mabn, m_dn.Substring(0, 10)).ToString();
                }
                catch
                {
                    m_maql_tiepdon = "0";
                }

                sql = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id,d.tenkp from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id inner join medibv.btdkp_bv d on a.makp=d.makp where a.mabn='"+m_mabn+"'";
                if (m_maql != "")
                {
                    if (!tmn_Tatca.Checked)
                    {
                        sql += " and a.maql=" + m_maql;
                    }
                }

                if (m_maql_phongluu != "" && m_maql_phongluu != "0")
                {
                    asql_luu = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id,d.tenkp from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id inner join medibv.btdkp_bv d on a.makp=d.makp where a.mabn='" + m_mabn + "'";
                    if (!tmn_Tatca.Checked)
                    {
                        asql_luu += " and a.maql=" + m_maql_phongluu;
                    }                    
                }

                if (m_maql_tiepdon != "" && m_maql_tiepdon != "0")
                {
                    asql_tiepdon = "select case when a.done =1 then 0 else 1 end as chon, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay, b.sohieu, a.sobienlai,a.sotien,c.hoten||' ('||c.userid||')' as user, a.done, a.id,d.tenkp from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin c on a.userid=c.id inner join medibv.btdkp_bv d on a.makp=d.makp where a.mabn='" + m_mabn + "'";
                    if (!tmn_Tatca.Checked)
                    {
                        asql_tiepdon += " and a.maql=" + m_maql_tiepdon;
                    }   
                }

                m_ds = m_v.get_data_bc_1(m_tn, m_dn, sql);
                if (m_maql_phongluu != "" && m_maql_phongluu != "0" && m_maql != m_maql_phongluu) 
                {
                    m_ds.Merge(m_v.get_data_bc_1(m_tn, m_dn, asql_luu));
                }

                if (m_maql_tiepdon != "" && m_maql_tiepdon != "0" && m_maql != m_maql_tiepdon) 
                {
                    m_ds.Merge(m_v.get_data_bc_1(m_tn, m_dn, asql_tiepdon));
                }

                dataGridView1.DataSource = m_ds.Tables[0];
                dataGridView1.Update();
                tmn_Tong.Text = lan.Change_language_MessageText("Tồng số:")+" " + dataGridView1.RowCount.ToString();
            }
            catch
            {
                tmn_Tong.Text = "";
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
                if (tmn_Timnhanh.Text.Trim().ToLower() == lan.Change_language_MessageText("Tìm kiếm"))
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
                if (atmp.ToLower().Trim() != lan.Change_language_MessageText("Tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "ngay like '%" + atmp + "%' or sohieu like '%" + atmp + "%' or user like '%" + atmp + "%'";
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

        private void butChon_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
            }
        }

        private void tmn_Tatca_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }
    }
}