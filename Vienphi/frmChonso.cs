using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmChonso : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid = "", v_loai = "";
        private bool bTtrv_dichvu, bTtrv_thatthu, bTt_gtgt, bTT_Tachhoadon, bBHYT_Tachhoadon, bTTRV_Tachhoadon,bBhyt_dichvu;
        private DataSet ads = new DataSet();

        //public frmChonso(LibVP.AccessData v_v, string v_userid)
        //{
        //    m_v = v_v;
        //    m_userid = v_userid;
        //    InitializeComponent();
        //    lan.Read_Language_to_Xml(this.Name.ToString(), this);
        //    lan.Changelanguage_to_English(this.Name.ToString(), this);
        //}
        public frmChonso(LibVP.AccessData v_v, string v_userid,string s_loai,string s_ngay)
        {
            m_v = v_v;
            m_userid = v_userid;
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            v_loai = s_loai;
            txtNgaythu.Value = new DateTime(int.Parse(s_ngay.Substring(6, 4)), int.Parse(s_ngay.Substring(3, 2)), int.Parse(s_ngay.Substring(0, 2)), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }
     
        public string s_ngay
        {
            get
            {
                return txtNgaythu.Text.Substring(0,16);
            }
        }
        public string s_loaidv
        {
            get
            {
                 return (cbLoai.SelectedIndex!=-1)?cbLoai.SelectedValue.ToString():"";
            }
        }

        public string s_quyenso
        {
            get
            {
                return (cbKyhieu.SelectedIndex!=-1)?cbKyhieu.SelectedValue.ToString():"";
            }
        }
        public string s_quyenso_thatthu
        {
            get
            {
                 if (!bTtrv_thatthu) return "";
                 else return (cbThatthu.SelectedIndex!=-1)?cbThatthu.SelectedValue.ToString():"";
            }
        }
        public string s_quyenso_thua
        {
            get
            {
                if (!bTtrv_thatthu) return "";
                else return (cbThua.SelectedIndex!=-1)?cbThua.SelectedValue.ToString():"";
            }
        }

        public string s_quyenso_dichvu
        {
            get
            {
                if ((v_loai == "0" && bTT_Tachhoadon) || (v_loai == "1" && bTTRV_Tachhoadon) || 
                    (v_loai == "2" && bBHYT_Tachhoadon) || (v_loai == "2" && bBhyt_dichvu)) 
                {
                    return (dichvu.SelectedIndex != -1) ? dichvu.SelectedValue.ToString() : "";
                }
                else if (v_loai == "1")
                {
                    
                    if (!bTtrv_dichvu) return "";
                    else return (dichvu.SelectedIndex != -1) ? dichvu.SelectedValue.ToString() : "";
                }
                else if (v_loai == "0")
                {
                    if (!bTt_gtgt) return "";
                    else return (dichvu.SelectedIndex != -1) ? dichvu.SelectedValue.ToString() : "";
                }
                else return "";
            }
        }
        public string s_tenquyenso
        {
            get
            {
               return cbKyhieu.Text.ToString();
            }
        }
        public string s_tenquyenso_thatthu
        {
            get
            {
                return cbThatthu.Text.ToString();
            }
        }
        public string s_tenquyenso_thua
        {
            get
            {
                 return cbThua.Text.ToString();
            }
        }

        private void f_Load_Data()
        {
            try
            {
                string sql = "";
                sql = "select ma,ten from medibv.v_tenloaivp order by ma";
                cbLoai.DataSource = m_v.get_data(sql).Tables[0];
                cbLoai.DisplayMember = "ten";
                cbLoai.ValueMember = "ma";

                
                if ((v_loai == "0" && bTT_Tachhoadon) || (v_loai == "1" && bTTRV_Tachhoadon) || (v_loai == "2" && bBHYT_Tachhoadon))
                {
                    sql = "select id,sohieu,loai,userid,tu,den,soghi,dangsd,dichvu from medibv.v_quyenso where dichvu=0 and dangsd=1 ";
                    sql += " order by sohieu desc";
                }
                else
                {
                    sql = "select id,sohieu,loai,userid,tu,den,soghi,dangsd,dichvu from medibv.v_quyenso where dangsd=1 ";
                    sql += " order by sohieu desc";
                }
                ads = m_v.get_data(sql);               
               
                 if (v_loai == "1")
                 {
                     cbKyhieu.DisplayMember = "sohieu";
                     cbKyhieu.ValueMember = "id";
                     cbKyhieu.DataSource = ads.Tables[0];

                     if (bTtrv_thatthu)
                     {
                         cbThatthu.DisplayMember = "sohieu";
                         cbThatthu.ValueMember = "id";
                         cbThatthu.DataSource = ads.Tables[0].Copy();

                         cbThua.DisplayMember = "sohieu";
                         cbThua.ValueMember = "id";
                         cbThua.DataSource = ads.Tables[0].Copy();

                         panel3.Visible = true;
                     }
                     if (bTtrv_dichvu)
                     {
                         dichvu.DisplayMember = "sohieu";
                         dichvu.ValueMember = "id";
                         dichvu.DataSource = ads.Tables[0].Copy();
                         ldichvu.Visible = dichvu.Visible = true;
                     }
                     else if (bTTRV_Tachhoadon)
                     {
                         string asql = "select id,sohieu,loai,userid,tu,den,soghi,dangsd,dichvu from medibv.v_quyenso where dichvu=1 and dangsd=1 order by sohieu desc";
                         dichvu.DisplayMember = "sohieu";
                         dichvu.ValueMember = "id";
                         dichvu.DataSource = m_v.get_data(asql).Tables[0];
                         ldichvu.Visible = dichvu.Visible = true;
                         ldichvu.Text = "Quyển sổ dịch vụ:";
                     }
                 }
                 else
                 {
                     cbKyhieu.DisplayMember = "sohieu";
                     cbKyhieu.ValueMember = "id";
                     cbKyhieu.DataSource = ads.Tables[0];
                     if (v_loai == "0" && bTt_gtgt)
                     {
                         dichvu.DisplayMember = "sohieu";
                         dichvu.ValueMember = "id";
                         dichvu.DataSource = ads.Tables[0].Copy();
                         ldichvu.Visible = dichvu.Visible = true;
                         ldichvu.Text = "Biên lai GTGT :";
                     }
                     if ((v_loai == "0" && bTT_Tachhoadon) || (v_loai == "2" && bBHYT_Tachhoadon) || (v_loai == "2" && bBhyt_dichvu))
                     {
                         string asql = "select id,sohieu,loai,userid,tu,den,soghi,dangsd,dichvu from medibv.v_quyenso where dichvu=1 and dangsd=1 order by sohieu desc";
                         dichvu.DisplayMember = "sohieu";
                         dichvu.ValueMember = "id";
                         dichvu.DataSource = m_v.get_data(asql).Tables[0];
                         ldichvu.Visible = dichvu.Visible = true;
                         ldichvu.Text = "Quyển sổ dịch vụ:";
                     }
                     panel3.Visible = false;
                     //panel2.Location = new System.Drawing.Point(100, 97);
                     //this.Size = new System.Drawing.Size(398, 272);                     
                 }
                chkDungchungso.Checked = m_v.sys_dungchungso;              
                chkTuden.Checked = m_v.sys_SBLtu_den;
            }
            catch
            {
            }
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            m_v.Disconnect();
            System.GC.Collect();
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string angaykhoaso = m_v.f_ngaykhoaso(m_userid);
                string atmp = f_Get_Sobienlai();
                if (atmp.Split(':')[1] == "1")//Hết số
                {
                    MessageBox.Show(this, "Hết sổ, đề nghị chọn sổ mới!",m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoai.Focus();
                    return;
                }
                if (s_loaidv == "" || s_quyenso == "")
                {
                    MessageBox.Show(this, "Chọn quyển sổ cần thu rồi nhấn nút chọn", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoai.Focus();
                    return;
                }
                atmp = f_Get_Sobienlai_dichvu();
                if (s_quyenso_dichvu == "" && ((v_loai == "0" && bTT_Tachhoadon) ||
                        (v_loai == "1" && bTTRV_Tachhoadon) || (v_loai == "2" && bBHYT_Tachhoadon) || (v_loai == "2" && bBhyt_dichvu)))
                {
                    MessageBox.Show(this, "Chọn quyển sổ dịch vụ cần thu rồi nhấn nút chọn", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoai.Focus();
                    return;
                }
                if (v_loai == "1")
                {
                    atmp = f_Get_Sobienlai_thatthu();
                    if (atmp.Split(':')[1] == "1")//Hết số
                    {
                        MessageBox.Show(this, "Quyển số thất thu hết sổ, đề nghị chọn sổ mới!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoai.Focus();
                        return;
                    }
                    if (s_loaidv == "" || (s_quyenso_thatthu == "" && bTtrv_thatthu))
                    {
                        MessageBox.Show(this, "Chọn quyển sổ cần thu rồi nhấn nút chọn", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoai.Focus();
                        return;
                    }
                    //----------------------------------------------
                    atmp = f_Get_Sobienlai_thua();
                    if (atmp.Split(':')[1] == "1")//Hết số
                    {
                        MessageBox.Show(this, "Quyển số thừa hết sổ, đề nghị chọn sổ mới!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoai.Focus();
                        return;
                    }
                    if (s_loaidv == "" || (s_quyenso_thua == "" && bTtrv_thatthu))
                    {
                        MessageBox.Show(this, "Chọn quyển sổ cần thu rồi nhấn nút chọn", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoai.Focus();
                        return;
                    }
                    atmp = f_Get_Sobienlai_dichvu();
                    if (atmp.Split(':')[1] == "1")//Hết số
                    {
                        MessageBox.Show(this, "Quyển số thừa hết sổ, đề nghị chọn sổ mới!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dichvu.Focus();
                        return;
                    }
                    if (s_loaidv == "" || (s_quyenso_dichvu == "" && (bTtrv_dichvu || bTt_gtgt)))
                    {
                        MessageBox.Show(this, "Chọn quyển sổ cần thu rồi nhấn nút chọn", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoai.Focus();
                        return;
                    }
                }
                if (angaykhoaso != "xx/xx/xxxx" && angaykhoaso.Trim() != "")
                {
                    if (m_v.f_parse_date(angaykhoaso) >= txtNgaythu.Value)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Ngày làm việc phải > ") + angaykhoaso, lan.Change_language_MessageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNgaythu.Focus();
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        System.GC.Collect();
                        this.Close();
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    System.GC.Collect();
                    this.Close();
                }
                f_capnhat_db(m_v.mmyy(txtNgaythu.Text.Substring(0, 10)));
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string f_Get_Sobienlai()
        {
            try
            {
                string art = "0:2";
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" + cbKyhieu.SelectedValue.ToString()).Tables[0].Rows)
                {
                    art = r["soghi"].ToString();
                    if (decimal.Parse(r["soghi"].ToString()) > decimal.Parse(r["den"].ToString()))
                    {
                        art += ":1";
                    }
                    else
                    {
                        art += ":0";
                    }
                    break;
                }
                return art;
            }
            catch
            {
                return "0:2";
            }
        }
        private string f_Get_Sobienlai_thatthu()
        {
            try
            {
                string art = "0:2";
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" + cbThatthu.SelectedValue.ToString()).Tables[0].Rows)
                {
                    art = r["soghi"].ToString();
                    if (decimal.Parse(r["soghi"].ToString()) > decimal.Parse(r["den"].ToString()))
                    {
                        art += ":1";
                    }
                    else
                    {
                        art += ":0";
                    }
                    break;
                }
                return art;
            }
            catch
            {
                return "0:2";
            }
        }
        
        private string f_Get_Sobienlai_thua()
        {
            try
            {
                string art = "0:2";
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" + cbThua.SelectedValue.ToString()).Tables[0].Rows)
                {
                    art = r["soghi"].ToString();
                    if (decimal.Parse(r["soghi"].ToString()) > decimal.Parse(r["den"].ToString()))
                    {
                        art += ":1";
                    }
                    else
                    {
                        art += ":0";
                    }
                    break;
                }
                return art;
            }
            catch
            {
                return "0:2";
            }
        }
        private string f_Get_Sobienlai_dichvu()
        {
            try
            {
                string art = "0:2";
                foreach (DataRow r in m_v.get_data("select soghi+1 as soghi, den from medibv.v_quyenso where id=" + dichvu.SelectedValue.ToString()).Tables[0].Rows)
                {
                    art = r["soghi"].ToString();
                    if (decimal.Parse(r["soghi"].ToString()) > decimal.Parse(r["den"].ToString()))
                    {
                        art += ":1";
                    }
                    else
                    {
                        art += ":0";
                    }
                    break;
                }
                return art;
            }
            catch
            {
                return "0:2";
            }
        }
        private void frmChonso_Load(object sender, EventArgs e)
        {
            bTt_gtgt = (v_loai=="0")?m_v.tt_bienlai_gtgt(m_userid) != "":false;
            bTtrv_dichvu = m_v.ttrv_bienlai_dichvu(m_userid) != "";
            bTtrv_thatthu = m_v.ttrv_Quanlythathu(m_userid);
            bTT_Tachhoadon = m_v.tt_tachhoadon_dichvu(m_userid) != "";
            bBHYT_Tachhoadon = m_v.bhyt_tachhoadon_dichvu(m_userid) != "";
            bTTRV_Tachhoadon = m_v.ttrv_tachhoadon_dichvu(m_userid) != "";
            bBhyt_dichvu = m_v.bhyt_bienlai_dichvu(m_userid) == "1";
            f_Load_Data();
            m_v.f_SetEvent(this);
            f_Filter_Quyenso();
        }

        private void txtNgaythu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}{F4}");
        }

        private void cbLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}{F4}");
        }

        private void cbKyhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkLocso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTuden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkDungchungso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void f_Filter_Quyenso()
        {
            try
            {
                string aft = "";
                if (chkLocso.Checked)
                {
                    aft = "loai like '%" + cbLoai.SelectedValue.ToString() + "%'";
                }
                if (!chkDungchungso.Checked)
                {
                    if (aft != "")
                    {
                        aft += " and ";
                    }
                    aft += "userid = " + m_userid;
                }
                if (chkTuden.Checked)
                {
                    if (aft != "")
                    {
                        aft += " and ";
                    }
                    aft += "( soghi >= tu-1 ) and ( soghi < den )";
                }
                
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbKyhieu.DataSource]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;

                if ((v_loai == "0" && bTT_Tachhoadon) || (v_loai == "1" && bTTRV_Tachhoadon) || (v_loai == "2" && bBHYT_Tachhoadon))
                {
                    CurrencyManager cm4 = (CurrencyManager)(BindingContext[dichvu.DataSource]);
                    DataView dv4 = (DataView)(cm4.List);
                    dv4.RowFilter = aft;
                }
                if (bTtrv_thatthu && v_loai == "1")
                {
                    CurrencyManager cm2 = (CurrencyManager)(BindingContext[cbThatthu.DataSource]);
                    DataView dv2 = (DataView)(cm2.List);
                    dv2.RowFilter = aft;

                    CurrencyManager cm1 = (CurrencyManager)(BindingContext[cbThua.DataSource]);
                    DataView dv1 = (DataView)(cm1.List);
                    dv1.RowFilter = aft;
                }
                
                if ((bTtrv_dichvu && v_loai == "1") || (bTt_gtgt && v_loai == "0") || (v_loai == "0" && bTT_Tachhoadon) || (v_loai == "2" && bBHYT_Tachhoadon) || (v_loai == "2" && bBhyt_dichvu))
                {
                    CurrencyManager cm3 = (CurrencyManager)(BindingContext[dichvu.DataSource]);
                    DataView dv3 = (DataView)(cm3.List);
                    dv3.RowFilter = aft;
                }
            }
            catch
            {
            }
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Filter_Quyenso();
        }

        private void chkLocso_CheckedChanged(object sender, EventArgs e)
        {
            f_Filter_Quyenso();
        }

        private void chkTuden_CheckedChanged(object sender, EventArgs e)
        {
            f_Filter_Quyenso();
        }

        private void chkDungchungso_CheckedChanged(object sender, EventArgs e)
        {
            f_Filter_Quyenso();
        }

        private void frmChonso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)   this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtNgaythu.Enabled = !txtNgaythu.Enabled;
        }
        private void f_capnhat_db(string mmyy)
        {
            string xxx = m_v.user + mmyy;
            string asql = "";
            DataSet lds = new DataSet();
            asql = "select khuyenmai from " + xxx + ".v_vienphict where 1=2";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + xxx + ".v_vienphict add khuyenmai numeric(7) default 0";
                m_v.execute_data(false, asql);
            }
        }

        private void dichvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((v_loai == "0" && bTT_Tachhoadon) || (v_loai == "1" && bTTRV_Tachhoadon) || (v_loai == "2" && bBHYT_Tachhoadon))
            {
                f_Filter_Quyenso();
            }
        }
    }
}