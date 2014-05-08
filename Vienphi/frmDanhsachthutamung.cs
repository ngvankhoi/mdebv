using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDanhsachthutamung : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_quyenso="",m_id="",m_ngaythu="";
        private bool bKhongchoxem_tongthu = false;
        public frmDanhsachthutamung(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();


                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgDanhsach, this.Name + "_" + "dgDanhsach");
                lan.Change_dtgrid_HeaderText_to_English(dgDanhsach, this.Name + "_" + "dgDanhsach");
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
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmdanhsachthutamung(m_userid);
                f_Set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmdanhsachthutamung(m_userid).ToString());
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

                sql = "select a.mabn,g.hoten,case when g.ngaysinh is null then g.namsinh else to_char(g.ngaysinh,'dd/mm/yyyy') ";
                sql += "end as namsinh,h.ten as gioitinh,a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.sohieu,a.sobienlai,a.sotien,";
                sql += "f.tenkp,d.ten as tenloaidv, e.ten as tenloaibn,a.lanin,c.hoten||' ('||c.userid||')' as user, trim(g.sonha||' '||g.thon)";
                sql += " as diachi from medibvmmyy.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join medibv.v_dlogin";
                sql += " c on a.userid=c.id left join medibv.v_tenloaivp d on a.loai=d.ma left join medibv.v_loaibn e on a.loaibn=e.id ";
                sql += "left join medibv.btdkp_bv f on a.makp=f.makp left join medibv.btdbn g on a.mabn=g.mabn left join medibv.dmphai ";
                sql += "h on g.phai=h.ma " + aexp;
                sql += " and a.id not in (select id from medibvmmyy.v_huybienlai where tables='v_tamung')";//gam 25/11/2011
                sql += " order by a.ngay,b.sohieu,a.sobienlai,g.hoten";
                
                //dgDanhsach.DataSource = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql, alimit).Tables[0];
                dgDanhsach.DataSource = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false).Tables[0];
                dgDanhsach.Update();
            }
            catch
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    dv.Table.Rows.Clear();
                }
                catch
                {
                }
                tmn_Sotien.Text = (bKhongchoxem_tongthu) ? "" : lan.Change_language_MessageText("0 HĐ = 0 Đ");
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
                DataRowView arv = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
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

        private void frmDanhsachthutamung_Load(object sender, EventArgs e)
        {
            bKhongchoxem_tongthu = m_v.sys_khongchoxem_tongthu == "1";
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

        private void frmDanhsachthutamung_KeyDown(object sender, KeyEventArgs e)
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
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember]);
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
                    if (dgDanhsach.CurrentCell.RowIndex > 0)
                    {
                        aid = dgDanhsach.CurrentCell.RowIndex - 1;
                        dgDanhsach.Rows[aid].Selected = true;
                        dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                        SendKeys.Send("{End}");
                    }
                    else
                        if (dgDanhsach.RowCount > 0)
                        {
                            aid = dgDanhsach.RowCount - 1;
                            dgDanhsach.Rows[aid].Selected = true;
                            dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                }
                else
                    if (e.KeyCode == Keys.Down)
                    {
                        if (dgDanhsach.CurrentCell.RowIndex < dgDanhsach.Rows.Count - 1)
                        {
                            aid = dgDanhsach.CurrentCell.RowIndex + 1;
                            dgDanhsach.Rows[aid].Selected = true;
                            dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                        else
                            if (dgDanhsach.RowCount > 0)
                            {
                                aid = 0;
                                dgDanhsach.Rows[aid].Selected = true;
                                dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
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
                dgDanhsach.Columns["Column2_4"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_3"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_2"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_1"].Frozen = !tmn_Fullgrid.Checked;
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
                m_v.set_o_fullgrid_frmdanhsachthutamung(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void dgDanhsach_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tmn_Chon_Click(null, null);
        }
    }
}