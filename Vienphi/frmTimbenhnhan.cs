using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmTimbenhnhan : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_mabn="",m_maql="";
        private bool m_is_sub = true;
        private int i_maxlength_mabn = 8;
        public frmTimbenhnhan(LibVP.AccessData v_v, string v_userid)
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
                f_Clear();
            }
            catch
            {
            }
        }
        public string s_mabn
        {
            get
            {
                return m_mabn;
            }
        }
        public string s_maql
        {
            get
            {
                return m_maql;
            }
        }
        public bool s_is_sub
        {
            set
            {
                m_is_sub = value;
                tmn_Chon.Text = (m_is_sub ? lan.Change_language_MessageText(
"&Chọn") : lan.Change_language_MessageText(
"Xem c&hi tiết"));
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
        private void f_Load_DG()
        {
            butTim.Enabled = false;
            try
            {
                tmn_Timnhanh.Text = 
lan.Change_language_MessageText("Tìm kiếm");
                string sql = "", aexp = "", alimit = "", adk = " or ", atmp1="";
                alimit = (txtLimit.Value.ToString() != "0" ? " limit " + txtLimit.Value.ToString() : ""); 
                aexp = "";
                if (rdAnd.Checked)
                {
                    adk = " and ";
                }
                if (txtMabn.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " a.mabn like '" + txtMabn.Text + "%'";
                }
                if (txtMabn1.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " a.mabn like '%" + txtMabn1.Text + "%'";
                }
                if (txtHoten.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " a.hoten like '%" + txtHoten.Text + "%'";
                }
                if (txtNgaysinh.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " (a.namsinh like '%" + txtNgaysinh.Text + "%'";
                    aexp += " or to_char(a.ngaysinh,'dd/mm/yyyy') like '%" + txtNgaysinh.Text + "%')";
                }
                if (txtDiachi.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " (a.sonha like '%" + txtDiachi.Text + "%'";
                    aexp += " or a.thon like '%" + txtDiachi.Text + "%'";
                    aexp += " or a.cholam like '%" + txtDiachi.Text + "%'";
                    aexp += " or c.tentt like '%" + txtDiachi.Text + "%'";
                    aexp += " or d.tenquan like '%" + txtDiachi.Text + "%'";
                    aexp += " or e.tenpxa like '%" + txtDiachi.Text + "%')";
                }
                atmp1 = "";
                try
                {
                    if (cbGioitinh.SelectedIndex >= 0)
                    {
                        atmp1 = "a.phai = " + cbGioitinh.SelectedValue.ToString();
                    }
                }
                catch
                {
                    atmp1 = "";
                }
                if (atmp1 != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += atmp1;
                }

                if (txtDT_Nha.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " f.nha like '%" + txtDT_Nha.Text + "%'";
                }
                if (txtDT_Coquan.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " f.coquan like '%" + txtDT_Coquan.Text + "%'";
                }
                if (txtDT_Didong.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " f.didong like '%" + txtDT_Didong.Text + "%'";
                }
                if (txtEmail.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " f.email like '%" + txtEmail.Text + "%'";
                }
                if (txtSothe.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " g.sothe like '%" + txtSothe.Text + "%'";
                }
                if (txtNDKKCB.Text != "")
                {
                    if (aexp != "")
                    {
                        aexp += adk;
                    }
                    aexp += " g.tenbv like '%" + txtNDKKCB.Text + "%'";
                }
                if (aexp != "")
                {
                    aexp = " where " + aexp;
                }
                else
                {
                    if (alimit == "")
                    {
                        txtLimit.Value = 1000;
                        alimit = " limit 1000";
                    }
                }
                sql = "select distinct a.mabn,g.sothe,a.hoten, case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end as ngaysinh,b.ten as phai,case when g.tungay is null then '' else to_char(g.tungay,'dd/mm/yyyy') end as tn,case when g.denngay is null then '' else to_char(g.denngay,'dd/mm/yyyy') end as dn, g.mabv, h.tenbv ,a.sonha,a.thon,e.tenpxa as xa, d.tenquan as quan, c.tentt as tinh,a.cholam,f.nha as dt_nha, f.coquan as dt_coquan,f.didong as dt_didong,f.email from medibv.btdbn a left join medibv.dmphai b on a.phai=b.ma left join medibv.btdtt c on a.matt=c.matt left join medibv.btdquan d on a.maqu=d.maqu left join medibv.btdpxa e on a.maphuongxa=e.maphuongxa left join medibv.dienthoai f on a.mabn=f.mabn left join medibv.bhyt g on a.mabn=g.mabn left join medibv.dmnoicapbhyt h on g.mabv=h.mabv " + aexp + " order by a.hoten, a.mabn" + alimit;
                dgHoadon.DataSource = m_v.get_data(sql).Tables[0];

                tmn_Sotien.Text = 
lan.Change_language_MessageText("TỔNG SỐ:")+" " + dgHoadon.RowCount.ToString();
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
                tmn_Sotien.Text = "";
            }
            butTim.Enabled = true;
        }
        private void f_Load_Data()
        {
            try
            {
                cbGioitinh.DataSource = m_v.get_data("select ma,ten from medibv.dmphai order by ma desc").Tables[0];
                cbGioitinh.DisplayMember = "ten";
                cbGioitinh.ValueMember = "ma";

                foreach (DataRow r in m_v.get_data("select distinct tenbv from medibv.dmnoicapbhyt").Tables[0].Rows)
                {
                    txtNDKKCB.AutoCompleteCustomSource.Add(r[0].ToString());
                }
                txtNDKKCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNDKKCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmtimbenhnhan(m_userid);
                f_Set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmtimbenhnhan(m_userid).ToString());
            }
            catch
            {
            }
        }
        private void f_Clear()
        {
            try
            {
                txtMabn.Text = "";
                txtMabn1.Text = "";
                txtHoten.Text = "";
                txtNgaysinh.Text = "";
                txtDiachi.Text = "";
                txtSothe.Text = "";
                txtNDKKCB.Text = "";
                cbGioitinh.Text = "";
                try
                {
                    cbGioitinh.SelectedIndex = -1;
                }
                catch
                {
                }
                txtDT_Nha.Text = "";
                txtDT_Coquan.Text = "";
                txtDT_Didong.Text = "";
                txtEmail.Text = "";
                try
                {
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    dv.Table.Rows.Clear();
                }
                catch
                {
                }
                tmn_Sotien.Text = "";
            }
            catch
            {
            }
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
                m_mabn = arv["mabn"].ToString();
                m_maql = "";
            }
            catch
            {
                m_mabn = "";
                m_maql = "";
            }
            if (m_is_sub)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Xem chi tiết!"));
            }
        }

        private void frmTimbenhnhan_Load(object sender, EventArgs e)
        {
            i_maxlength_mabn = LibVP.AccessData.i_maxlength_mabn;
            string s_mask="000000";
            txtMabn1.Mask = s_mask.PadLeft(i_maxlength_mabn - 2, '0');
            //f_Load_DG();
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
                    f_Load_DG();
                }
            }
            catch
            {
            }
        }

        private void frmTimbenhnhan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    m_mabn = "";
                    m_maql = "";
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
                string atmp = tmn_Timnhanh.Text;
                if (atmp.ToLower().Trim() != lan.Change_language_MessageText(
"Tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "mabn like '%" + atmp + "%' or hoten like '%" + atmp + "%' or ngaysinh like '%" + atmp + "%' or phai like '%" + atmp + "%' or sonha like '%" + atmp + "%' or thon like '%" + atmp + "%' or cholam like '%" + atmp + "%' or xa like '%" + atmp + "%' or quan like '%" + atmp + "%' or tinh like '%" + atmp + "%' or dt_nha like '%" + atmp + "%' or dt_coquan like '%" + atmp + "%' or dt_didong like '%" + atmp + "%' or email like '%" + atmp + "%'";
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

        private void butClear_Click(object sender, EventArgs e)
        {
            f_Clear();
        }

        private void tmn_Inhanhchanh_Click(object sender, EventArgs e)
        {

        }

        private void tmn_In_Click(object sender, EventArgs e)
        {

        }

        private void tmn_Excel_Click(object sender, EventArgs e)
        {

        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtMabn1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMabn1_Validated(null, null);
                    if (txtMabn.Text.Length == 2 && txtMabn1.Text.Length == 6)
                    {
                        butTim_Click(null, null);
                    }
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtHoten_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNgaysinh_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
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

        private void cbGioitinh_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSothe_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNDKKCB_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDT_Nha_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDT_Coquan_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDT_Didong_KeyDown(object sender, KeyEventArgs e)
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

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
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

        private void rdAnd_KeyDown(object sender, KeyEventArgs e)
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

        private void rdOr_KeyDown(object sender, KeyEventArgs e)
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
        private void f_Set_Fullgrid()
        {
            try
            {
                dgHoadon.Columns["Column6"].Frozen = !tmn_Fullgrid.Checked;
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
                m_v.set_o_fullgrid_frmtimbenhnhan(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void dgHoadon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tmn_Chon_Click(null, null);
        }
        private void txtMabn_Validated(object sender, EventArgs e)
        {
            try
            {
                txtMabn.Text = txtMabn.Text.Trim();
                if (txtMabn.Text.Trim().Length > 0)
                {
                    txtMabn.Text = txtMabn.Text.Trim().PadLeft(2, '0');
                }
            }
            catch
            {
                txtMabn.Text = "";
            }
        }

        private void txtMabn1_Validated(object sender, EventArgs e)
        {
            try
            {
                txtMabn1.Text = txtMabn1.Text.Trim();
                if (txtMabn1.Text.Trim().Length > 0)
                {
                    txtMabn1.Text = txtMabn1.Text.Trim().PadLeft(i_maxlength_mabn - 2, '0');//.PadLeft(6, '0');
                }
            }
            catch
            {
                txtMabn1.Text = "";
            }
        }
    }
}