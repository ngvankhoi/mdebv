using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDanhsachthutrongoi : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_quyenso="",m_id="",m_ngaythu="";
        public frmDanhsachthutrongoi(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();


                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");
                m_v = v_v;
                m_userid = v_userid;
                m_v.f_SetEvent(this);
                f_Load_Data();
            }
            catch
            {
            }
        }
        public string s_quyenso
        {
            set
            {
                m_quyenso=value;
            }
        }
        public DateTime s_ngay
        {
            set
            {
                txtTN.Value = value;
                txtDN.Value = value;
            }
        }
        public string s_id
        {
            get
            {
                return m_id;
            }
        }
        public string s_ngaythu
        {
            get
            {
                return m_ngaythu;
            }
        }
        private void f_Load_Data()
        {
            try
            {
                try
                {
                    tmn_Title.Text = m_v.get_data("select hoten from medibv.v_dlogin where id=" + m_userid).Tables[0].Rows[0][0].ToString().ToUpper();
                }
                catch
                {
                    tmn_Title.Text = "";
                }
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmdanhsachthutrongoi(m_userid);
                f_Set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmdanhsachthutrongoi(m_userid).ToString());
            }
            catch
            {
            }
        }
        private void f_Load_DG()
        {
            butTim.Enabled = false;
            try
            {
                tmn_Timnhanh.Text = 
lan.Change_language_MessageText("Tìm kiếm");
                string sql = "", aexp = "";
                int alimit = 0;
                try
                {
                    alimit = int.Parse(txtLimit.Value.ToString());
                }
                catch
                {
                    alimit = 0;
                }
                aexp = "where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid;
                sql = "select a.mabn,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,case when c.sotien is null then 0 else c.sotien end as mien,sum(b.soluong*b.dongia-case when b.thieu is null then 0 else b.thieu end) as sotien, max(b1.tamung) as tamung, trim(a.diachi) as diachi,a.id,trim(to_char(a.sobienlai,9999999)) as sbl from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id " + aexp + " group by a.id,a.mabn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu,a.sobienlai,c.sotien order by sohieu,sobienlai";
                //dgHoadon.DataSource = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql,alimit).Tables[0];
                dgHoadon.DataSource = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false).Tables[0];
                dgHoadon.Update();
                decimal atmp=0, asotien = 0,amien=0,atamung=0;
                try
                {
                    sql = "select sum(b.sotien) as sotien, sum(b.tamung) as tamung from medibvmmyy.v_vienphill a left join medibvmmyy.v_trongoi b on a.id=b.id " + aexp + "";
                    //foreach (DataRow r in m_v.get_data_bc(txtTN.Value, txtDN.Value, sql).Tables[0].Rows)
                    foreach (DataRow r in m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false).Tables[0].Rows)
                    {
                        try
                        {
                            atmp = decimal.Parse(r["sotien"].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        asotien += atmp;
                        try
                        {
                            atmp = decimal.Parse(r["tamung"].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        atamung += atmp;
                    }
                }
                catch
                {
                }
                try
                {
                    sql = "select sum(case when b.sotien is null then 0 else b.sotien end) as sotien from medibvmmyy.v_vienphill a inner join medibvmmyy.v_mienngtru b on a.id=b.id inner join medibv.v_trongoi c on a.id=c.id " + aexp + "";
                    //foreach (DataRow r in m_v.get_data_bc(txtTN.Value, txtDN.Value, sql).Tables[0].Rows)
                    foreach (DataRow r in m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false).Tables[0].Rows)
                    {
                        try
                        {
                            atmp = decimal.Parse(r[0].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        amien += atmp;
                    }
                }
                catch
                {
                }
                asotien -= amien;
                asotien -= atamung;
                tmn_Sotien.Text = dgHoadon.RowCount.ToString() +" "+ lan.Change_language_MessageText("HĐ =")+" " + asotien.ToString("###,###,##0.##") + " "+lan.Change_language_MessageText("Đ");
            }
            catch
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    dv.Table.Rows.Clear();
                }
                catch
                {
                }
                tmn_Sotien.Text = lan.Change_language_MessageText("0 HĐ = 0 Đ");
            }
            butTim.Enabled = true;
        }

        private void tmn_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tmn_Chon_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                m_id = arv["id"].ToString();
                m_ngaythu = arv["ngay"].ToString();
            }
            catch
            {
                m_id = "";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tmn_Inhoadon_Click(object sender, EventArgs e)
        {

        }

        private void tmn_Inchiphi_Click(object sender, EventArgs e)
        {

        }

        private void frmDanhsachthutrongoi_Load(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void txtTN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtDN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butTim.Focus();
                }
            }
            catch
            {
            }
        }

        private void frmDanhsachthutrongoi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    m_id = "";
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void txtTN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTN.Value > txtDN.Value)
                {
                    txtDN.Value = txtTN.Value;
                }
            }
            catch
            {
            }
        }

        private void txtDN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDN.Value < txtTN.Value)
                {
                    txtTN.Value = txtDN.Value;
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
                string atmp = tmn_Timnhanh.Text.Trim();
                if (atmp.ToLower().Trim() != 
lan.Change_language_MessageText("Tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "mabn like '%" + atmp + "%' or hoten like '%" + atmp + "%' or namsinh like '%" + atmp + "%' or ngay like '%" + atmp + "%' or sohieu like '%" + atmp + "%' or diachi like '%" + atmp + "%' or sbl like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch
            {
            }
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

        private void tmn_Timnhanh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int aid = 0;
                if (e.KeyCode == Keys.Up)
                {
                    if (dgHoadon.CurrentCell.RowIndex > 0)
                    {
                        aid = dgHoadon.CurrentCell.RowIndex - 1;
                        dgHoadon.Rows[aid].Selected = true;
                        dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                        SendKeys.Send("{End}");
                    }
                    else
                        if (dgHoadon.RowCount > 0)
                        {
                            aid = dgHoadon.RowCount - 1;
                            dgHoadon.Rows[aid].Selected = true;
                            dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                }
                else
                    if (e.KeyCode == Keys.Down)
                    {
                        if (dgHoadon.CurrentCell.RowIndex < dgHoadon.Rows.Count - 1)
                        {
                            aid = dgHoadon.CurrentCell.RowIndex + 1;
                            dgHoadon.Rows[aid].Selected = true;
                            dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                        else
                            if (dgHoadon.RowCount > 0)
                            {
                                aid = 0;
                                dgHoadon.Rows[aid].Selected = true;
                                dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                                SendKeys.Send("{End}");
                            }
                    }
            }
            catch
            {
            }
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void txtLimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butTim.Focus();
                }
            }
            catch
            {
            }
        }
        private void f_Set_Fullgrid()
        {
            try
            {
                dgHoadon.Columns["Column_6"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_5"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_4"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_3"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_2"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_1"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_0"].Frozen = !tmn_Fullgrid.Checked;
            }
            catch
            {
            }
        }
        private void tmn_Fullgrid_Click(object sender, EventArgs e)
        {
            try
            {
                f_Set_Fullgrid();
                m_v.set_o_fullgrid_frmdanhsachthutrongoi(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void dgHoadon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tmn_Chon_Click(null, null);
        }
    }
}