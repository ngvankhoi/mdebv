using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;
namespace Medisoft
{
    public partial class frmChonkhodt : Form
    {
        Language lan;
        Bogotiengviet tv;
        private AccessData d;
        private int i_userid;
        private string user;
        public int i_manguon = -1, i_nhom = 0, i_makp = 0, i_matutruc = 0, i_makho = 0;
        public string s_tennguon, sql, s_tenkho = "", s_mmyy = "", s_nhomkho = "", s_makp = "", s_tenkhoa, s_ngay = "";
        //public DateTime m_ngay;
        private DataTable dtkho,dtmakp;
        public frmChonkhodt(AccessData acc,string _nhomkho,string _makp)
        {
            InitializeComponent();
            d = acc;
            s_nhomkho = (_nhomkho == "" ? "-1" : _nhomkho.Trim(','));
            s_makp = _makp;
            Init();
        }
        private void Init()
        {
            lan = new Language();
            tv = new Bogotiengviet();
            dtkho = new DataTable();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        private void frmChonkhodt_Load(object sender, EventArgs e)
        {
            user = d.user;
            s_ngay = d.Ngay_hethong;
            solieu.Value = (decimal)DateTime.Now.Month;
            nam.Value = (decimal)DateTime.Now.Year;
            cmbNhom.DisplayMember = "TEN";
            cmbNhom.ValueMember = "ID";
            cmbKhoa.DisplayMember = "TEN";
            cmbKhoa.ValueMember = "ID";
            cmbKho.DisplayMember = "TEN";
            cmbKho.ValueMember = "ID";
            cmbTutruc.DisplayMember = "TEN";
            cmbTutruc.ValueMember = "ID";
            load_nhom();
        }
        private void load_nhom()
        {
            sql = "select * from " + user + ".d_dmnhomkho ";
            if (s_nhomkho != "") sql += " where id in (" + s_nhomkho + ")";
            sql += " order by stt";
            cmbNhom.DataSource = d.get_data(sql).Tables[0];
            if (cmbNhom.SelectedIndex != -1)
            {
                load_makp();
                load_makho();
            }
        }

        private void load_makho()
        {
            if (cmbKhoa.SelectedIndex != -1 && cmbNhom.SelectedIndex != -1)
            {
                try
                {
                    sql = "select * from " + user + ".d_dmkho where hide=0 and nhom="+cmbNhom.SelectedValue.ToString();
                    //sql += " and id in (" + i_makho.ToString() + ")";
                    dtkho = d.get_data(sql).Tables[0];
                    cmbKho.DataSource = dtkho;
                }
                catch { }
            }
        }

        private void load_matutruc()
        {
            if (cmbKhoa.SelectedIndex != -1)
            {
              DataRow  r = d.getrowbyid(dtmakp, "id=" + int.Parse(cmbKhoa.SelectedValue.ToString()));
                if (r != null)
                {
                    string s = r["tutruc"].ToString();
                    sql = "select * from " + user + ".d_duockp ";
                    sql += " where id in (" + int.Parse(r["id"].ToString()) + ", " + int.Parse(r["matutruc"].ToString());
                    if (s != "") sql += "," + s;
                    sql += ")";
                    //if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
                    sql += " order by id";
                    cmbTutruc.DataSource = d.get_data(sql).Tables[0];
                    cmbTutruc.SelectedIndex = 0;
                }
            }
        }
        private void load_makp()
        {
            if (cmbNhom.SelectedIndex != -1)
            {
                sql = "select a.id,a.ten,a.ma,tutruc,matutruc from " + user + ".d_duockp a left join " + user + ".btdkp_bv b on a.makp=b.makp where a.nhom like '%" + int.Parse(cmbNhom.SelectedValue.ToString()) + ",%'";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    if (s.Length > 3) s = s.Substring(0, s.Length - 3);
                    sql += " and a.makp in ('" + s + "')";
                }
                sql += " order by a.stt";
                dtmakp = d.get_data(sql).Tables[0];
                cmbKhoa.DataSource = dtmakp;
                load_matutruc();
            }
        }

        private void solieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void nam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void manguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void kho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (kp.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn mã khoa phòng"),d.Msg);
                return;
            }
            try
            {
                s_ngay = ngay.Text.Substring(0, 10);
                s_tenkho = "";
                i_makho = int.Parse(cmbKho.SelectedValue.ToString());
                s_tenkho = cmbKho.Text;
                s_mmyy = solieu.Value.ToString().PadLeft(2, '0') + nam.Value.ToString().Substring(2, 2);
                i_nhom = int.Parse(cmbNhom.SelectedValue.ToString());
                i_makp = int.Parse(cmbKhoa.SelectedValue.ToString());
                i_matutruc = int.Parse(cmbTutruc.SelectedValue.ToString());
                s_tenkhoa = cmbKhoa.Text;
                //
            }
            catch
            {
                //m_ngay = ngay.Value;
            }
            //
            d.close(); this.Close();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            i_makp = -1;
            i_matutruc = -1;
            s_tennguon = "~";
            d.close(); this.Close();
        }

        private void cmbNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbNhom)
            {
                load_makp();
                load_makho();
            }
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbKhoa)
            {
                load_matutruc();
                if (cmbKhoa.SelectedIndex != -1) kp.Text = dtmakp.Rows[cmbKhoa.SelectedIndex]["ma"].ToString();
                load_makho();
            }
        }

        private void kp_Validated(object sender, EventArgs e)
        {
            try
            {
                DataRow r = d.getrowbyid(dtmakp, "ma='" + kp.Text.Trim() + "'");
                if (r != null) cmbKhoa.SelectedValue = r["id"].ToString();
                else cmbKhoa.SelectedIndex = -1;
            }
            catch { }
        }

        private void cmbNhom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void kp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cmbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void cmbKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void cmbTutruc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void kp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}