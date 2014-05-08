using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmDanhsachthuchiravien : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_quyenso="",m_id="",m_ngaythu="";
        private bool bKhongchoxem_tongthu = false;
        public frmDanhsachthuchiravien(LibVP.AccessData v_v, string v_userid)
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
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmdanhsachthuchiravien(m_userid);
                f_Set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmdanhsachthuchiravien(m_userid).ToString());
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
                tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                string sql = "", asql_tt = "";
                int alimit = 0;
                try
                {
                    alimit = int.Parse(txtLimit.Value.ToString());
                }
                catch
                {
                    alimit = 0;
                }

                string s_loaibn = m_v.ttrv_Loaibn_NT(m_userid);
                if (s_loaibn.Trim() != "")
                {
                    string[] sloaibn = s_loaibn.Split(',');                   
                    for (int i = 0; i < sloaibn.Length; i++)
                    {
                        if (sloaibn[i] == "0")
                        {
                            sql = "select a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,";
                            if(bKhongchoxem_tongthu)
                                sql += " 0 as sotien, 0 as bhyt, 0 as mien, 0 as thieu, 0 as tamung,0 as phaithu, 0 as phaihoan, 0 as nopthem, ";
                            else
                                sql+=" a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, ";
                            sql+=" trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,'9999999')) as sbl from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=0";
                            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=0";
                        }
                        else if (sloaibn[i] == "1")
                        {
                            if (sql != "") sql += " union all ";
                            sql += "select a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,";
                            if (bKhongchoxem_tongthu)
                                sql += " 0 as sotien, 0 as bhyt, 0 as mien, 0 as thieu, 0 as tamung,0 as phaithu, 0 as phaihoan, 0 as nopthem, ";
                            else
                                sql+=" a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, ";
                            //
                            sql+=" trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,'9999999')) as sbl ";
                            sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=1";

                            if (asql_tt != "") asql_tt += " union all ";
                            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=1";
                        }
                        else if (sloaibn[i] == "2")
                        {
                            if (sql != "") sql += " union all ";
                            sql += "select a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,";
                            if (bKhongchoxem_tongthu)
                                sql += " 0 as sotien, 0 as bhyt, 0 as mien, 0 as thieu, 0 as tamung,0 as phaithu, 0 as phaihoan, 0 as nopthem, ";
                            else
                                sql+=" a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, ";
                            //
                            sql += " trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,'9999999')) as sbl from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=2";

                            if (asql_tt != "") asql_tt += " union all ";
                            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=1";

                        }
                        else if (sloaibn[i] == "3")
                        {
                            if (sql != "") sql += " union all ";
                            sql += "select a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,";
                            if (bKhongchoxem_tongthu)
                                sql += " 0 as sotien, 0 as bhyt, 0 as mien, 0 as thieu, 0 as tamung,0 as phaithu, 0 as phaihoan, 0 as nopthem, ";
                            else
                                sql+=" a.sobienlai,a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, ";
                            sql += " trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,'9999999')) as sbl from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=3";

                            if (asql_tt != "") asql_tt += " union all ";
                            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=1";
                        }
                        else if (sloaibn[i] == "4")
                        {
                            if (sql != "") sql += " union all ";
                            sql += "select a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,";
                            if (bKhongchoxem_tongthu)
                                sql += " 0 as sotien, 0 as bhyt, 0 as mien, 0 as thieu, 0 as tamung,0 as phaithu, 0 as phaihoan, 0 as nopthem, ";
                            else
                                sql+=" a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem,";
                            sql += " trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,'9999999')) as sbl from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=4";

                            if (asql_tt != "") asql_tt += " union all ";
                            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + " and a.loaibn=1";
                        }
                    }
                }
                else
                {
                    sql = "select a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,";
                    if (bKhongchoxem_tongthu)
                        sql += " 0 as sotien, 0 as bhyt, 0 as mien, 0 as thieu, 0 as tamung,0 as phaithu, 0 as phaihoan, 0 as nopthem, ";
                    else
                        sql+=" a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, ";
                    sql += " trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,'9999999')) as sbl from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + "";
                    
                    asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a.userid=" + m_userid + "";
                }                                                
                //dgHoadon.DataSource = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql,alimit).Tables[0];
                dgHoadon.DataSource = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false).Tables[0];
                dgHoadon.Update();
                decimal atmp=0, asotien = 0,amien=0;
                try
                {
                    foreach (DataRow r in m_v.get_data_mmyy(asql_tt,txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false).Tables[0].Rows)// gam 31-05-2011
                    {
                        try
                        {
                            atmp = decimal.Parse(r[0].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        asotien += atmp;
                    }
                }
                catch
                {
                }
                asotien -= amien;
                tmn_Sotien.Text = (bKhongchoxem_tongthu) ? "" : dgHoadon.RowCount.ToString() + " " + lan.Change_language_MessageText("HĐ =") + " " + asotien.ToString("###,###,##0.##") + " " + lan.Change_language_MessageText("Đ");
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

        private void frmDanhsachthuchiravien_Load(object sender, EventArgs e)
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

        private void frmDanhsachthuchiravien_KeyDown(object sender, KeyEventArgs e)
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
                string s_tim = lan.Change_language_MessageText("Tìm kiếm");
                if (atmp.ToLower().Trim() != s_tim.ToLower() && atmp.ToLower().Trim() != "")
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
            tmn_Timnhanh.Text = "";         
        }

        private void tmn_Timnhanh_Leave(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.White;
                if (tmn_Timnhanh.Text.Trim() == "")
                {
                    tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
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
                m_v.set_o_limit_frmdanhsachthuchiravien(m_userid, txtLimit.Value.ToString());
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
                m_v.set_o_fullgrid_frmdanhsachthuchiravien(m_userid, tmn_Fullgrid.Checked);
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