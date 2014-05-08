using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmOption : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid = "", m_userid_copy = "";
        private DataSet dsLoaibn = new DataSet();
        private DataSet dsdoituong = new DataSet();
        private DataSet dsbhyt_hd = new DataSet();
        private DataSet dsttrv_hd = new DataSet();
        private DataSet dsLoaibn_NT = new DataSet();
        private DataSet dskhoa_thu = new DataSet();
        private DataSet dsttrv_030 = new DataSet();
        private DataSet dstt_039 = new DataSet();
        private DataTable dtDoituongthu_NT = new DataTable();

        public frmOption(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = v_v;
            m_userid = v_userid;
            f_Load_Data();
            m_v.f_SetEvent(this);
        }

        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            f_Load_Option();
            TT_038.Enabled = TT_010.Checked;
            this.Refresh();

        }
        private void f_Load_Data()
        {
            try
            {
                if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                cbUser.DataSource = m_v.get_data("select id, hoten||' ('||userid||')' as hoten from medibv.v_dlogin order by hoten").Tables[0];
                cbUser.DisplayMember = "hoten";
                cbUser.ValueMember = "id";
                cbUser.SelectedValue = m_userid;
                if (!m_v.is_app_admin(m_userid))
                {
                    cbUser.SelectedValue = m_userid;
                    cbUser.Enabled = m_v.is_app_admin(m_userid);
                    butCopy.Enabled = cbUser.Enabled;
                    butPaste.Enabled = false;
                    tmn_Luu.Enabled = cbUser.Enabled;
                    toolStrip_Macdinh.Enabled = cbUser.Enabled;
                    tmn_Boqua.Enabled = cbUser.Enabled;

                    foreach (Control c in tabControl1.Controls)
                    {
                        foreach (Control c1 in c.Controls)
                        {
                            if (c1.GetType().ToString() == "System.Windows.Forms.CheckBox")
                            {
                                CheckBox chk = (CheckBox)c1;
                                chk.Enabled = cbUser.Enabled;
                            }
                            if (c1.GetType().ToString() == "System.Windows.Forms.Label")
                            {
                                Label lbl = (Label)c1;
                                lbl.Enabled = cbUser.Enabled;
                            }
                        }
                    }
                }

                dtDoituongthu_NT = m_v.get_data("select madoituong,doituong from medibv.doituong order by madoituong").Tables[0];
                chkDoituongthu.DataSource = dtDoituongthu_NT;
                chkDoituongthu.ValueMember = "madoituong";
                chkDoituongthu.DisplayMember = "doituong";

                dsdoituong = m_v.get_data("select madoituong,doituong from medibv.doituong order by madoituong");
                chktachhoadon.DataSource = dsdoituong.Tables[0];
                chktachhoadon.ValueMember = "madoituong";
                chktachhoadon.DisplayMember = "doituong";

                dsbhyt_hd = m_v.get_data("select madoituong,doituong from medibv.doituong order by madoituong");
                chkDoituong.DataSource = dsbhyt_hd.Tables[0];
                chkDoituong.ValueMember = "madoituong";
                chkDoituong.DisplayMember = "doituong";

                dsttrv_hd = m_v.get_data("select madoituong,doituong from medibv.doituong order by madoituong");
                chkTTRV_035.DataSource = dsttrv_hd.Tables[0];
                chkTTRV_035.ValueMember = "madoituong";
                chkTTRV_035.DisplayMember = "doituong";

                dsLoaibn = m_v.get_data("select * from " + m_v.user + ".v_loaibn");
                chkLoaibn.DataSource = dsLoaibn.Tables[0];
                chkLoaibn.ValueMember = "TEN";
                chkLoaibn.DisplayMember = "TEN";
                
                dsLoaibn_NT = m_v.get_data("select * from " + m_v.user + ".v_loaibn");
                chkLoaibn_NT.DataSource = dsLoaibn_NT.Tables[0];
                chkLoaibn_NT.ValueMember = "TEN";
                chkLoaibn_NT.DisplayMember = "TEN";

                dskhoa_thu = m_v.get_data("select * from " + m_v.user + ".btdkp_bv order by loai, tenkp");
                chkkhoaphong.DataSource = dskhoa_thu.Tables[0];
                chkkhoaphong.ValueMember = "MAKP";
                chkkhoaphong.DisplayMember = "TENKP";

                dsttrv_030 = m_v.get_data("select * from " + m_v.user + ".v_nhomvp order by ma");
                cTTRV_030.DataSource = dsttrv_030.Tables[0];
                cTTRV_030.ValueMember = "MA";
                cTTRV_030.DisplayMember = "TEN";

                dstt_039 = m_v.get_data("select * from " + m_v.user + ".v_nhomvp order by ma");
                chk_TT_039.DataSource = dstt_039.Tables[0];
                chk_TT_039.ValueMember = "MA";
                chk_TT_039.DisplayMember = "TEN";

                chkKP.DataSource = dskhoa_thu.Tables[0].Copy();
                chkKP.ValueMember = "MAKP";
                chkKP.DisplayMember = "TENKP";  
            }
            catch
            {
            }
        }
        private void f_Load_Option()
        {
            try
            {
                DataSet ads = m_v.get_data("select * from medibv.v_optionform where loai=1 and userid=" + cbUser.SelectedValue.ToString());
                TT_001.Checked = get_check("TT_001",ads);
                TT_002.Checked = get_check("TT_002", ads);
                TT_003.Checked = get_check("TT_003", ads);
                TT_103.Enabled = TT_003.Checked;
                TT_004.Checked = get_check("TT_004", ads);
                TT_005.Checked = get_check("TT_005", ads);
                TT_006.Checked = get_check("TT_006", ads);
                TT_007.Checked = get_check("TT_007", ads);
                TT_008.Checked = get_check("TT_008", ads);
                TT_009.Checked = get_check("TT_009", ads);
                TT_010.Checked = get_check("TT_010", ads);
                TT_038.Checked = get_check("TT_038", ads);
                TT_011.Checked = get_check("TT_011", ads);
                TT_012.Checked = get_check("TT_012", ads);
                TT_013.Checked = get_check("TT_013", ads);
                TT_014.Checked = get_check("TT_014", ads);
                TT_015.Checked = get_check("TT_015", ads);
                TT_016.Checked = get_check("TT_016", ads);
                TT_017.Checked = get_check("TT_017", ads);
                TT_018.Checked = get_check("TT_018", ads);
                TT_019.Checked = get_check("TT_019", ads);
                chkTachbienlai_nhomvp.Checked = get_check("chkTachbienlai_nhomvp", ads);
                chkTachbienlai_loaivp.Checked = get_check("chkTachbienlai_loaivp", ads);
                chkinHDtheo_nhom.Checked = get_check("chkinHDtheo_nhom", ads);
                chkinHDtheo_loai.Checked = get_check("chkinHDtheo_loai", ads);
                chkInchitiet.Checked = get_check("chkInchitiet", ads);
                TT_020.Checked = get_check("TT_020", ads);
                TT_021.Checked = get_check("TT_021", ads);
                TT_022.Checked = get_check("TT_022", ads);
                TT_023.Checked = get_check("TT_023", ads);
                TT_024.Checked = get_check("TT_024", ads);
                TT_025.Checked = get_check("TT_025", ads);

                TT_027.Checked = (m_v.tt_Loaibn_thutructiep(cbUser.SelectedValue.ToString()) != "");
                chkLoaibn.Visible = false;

                TT_106.Checked = (m_v.tt_tachhoadon_dichvu(cbUser.SelectedValue.ToString()) != "");
                chktachhoadon.Visible = false;

                TT_028.Checked = get_check("TT_028", ads);
                TT_029.Checked = get_check("TT_029", ads);
                TT_030.Checked = get_check("TT_030", ads);
                TT_031.Checked = get_check("TT_031", ads);
                TT_032.Checked = get_check("TT_032", ads);

                TT_035.Checked = (m_v.tt_khoathututruc(cbUser.SelectedValue.ToString()) != "");
                TT_036.Checked = get_check("TT_036", ads);
                TT_037.Checked = get_check("TT_037", ads);
                TT_039.Checked = (m_v.tt_bienlai_gtgt(cbUser.SelectedValue.ToString()) != "");
                chkKP.Visible = false;
                chk_TT_039.Visible = false;
                //
                TT_101.Checked = get_check("TT_101", ads);
                TT_102.Checked = get_check("TT_102", ads);
                TT_103.Checked = get_check("TT_103", ads);
                TT_104.Checked = get_check("TT_104", ads);
                TT_107.Checked = get_check("TT_107", ads);
                chkThuTungDonThuoc.Checked = get_check("chkThuTungDonThuoc", ads);//Thuy 20.06.2012
                TT_040.Checked = get_check("TT_040", ads);
                TT_041.Checked = get_check("TT_041", ads);
                TT_108.Checked = get_check("TT_108", ads);
                TT_109.Checked = get_check("TT_109", ads);

                string v_val = get_values_option("TT_042", ads);
                TT_042.Value = (v_val == "") ? 1 : decimal.Parse(v_val);
                TT_043.Checked = get_check("TT_043", ads);
                //Trọn gói
                TG_001.Checked = get_check("TG_001", ads);
                TG_002.Checked = get_check("TG_002", ads);
                TG_003.Checked = get_check("TG_003", ads);
                TG_004.Checked = get_check("TG_004", ads);
                TG_005.Checked = get_check("TG_005", ads);
                TG_006.Checked = get_check("TG_006", ads);
                TG_007.Checked = get_check("TG_007", ads);
                TG_008.Checked = get_check("TG_008", ads);
                TG_009.Checked = get_check("TG_009", ads);
                TG_010.Checked = get_check("TG_010", ads);
                TG_011.Checked = get_check("TG_011", ads);
                TG_012.Checked = get_check("TG_012", ads);
                TG_013.Checked = get_check("TG_013", ads);
                TG_014.Checked = get_check("TG_014", ads);
                TG_015.Checked = get_check("TG_015", ads);
                TG_016.Checked = get_check("TG_016", ads);

                TU_001.Checked = get_check("TU_001", ads);
                TU_002.Checked = get_check("TU_002", ads);
                TU_003.Checked = get_check("TU_003", ads);
                TU_004.Checked = get_check("TU_004", ads);
                TU_005.Checked = get_check("TU_005", ads);
                TU_006.Checked = get_check("TU_006", ads);
                TU_007.Checked = get_check("TU_007", ads);
                TU_008.Checked = get_check("TU_008", ads);
                TU_009.Checked = get_check("TU_009", ads);
                TU_010.Checked = get_check("TU_010", ads);
                TU_011.Checked = get_check("TU_011", ads);

                TTRV_001.Checked = get_check("TTRV_001", ads);
                TTRV_002.Checked = get_check("TTRV_002", ads);
                TTRV_003.Checked = get_check("TTRV_003", ads);
                TTRV_004.Checked = get_check("TTRV_004", ads);
                TTRV_005.Checked = get_check("TTRV_005", ads);
                TTRV_006.Checked = get_check("TTRV_006", ads);
                TTRV_007.Checked = get_check("TTRV_007", ads);
                TTRV_008.Checked = get_check("TTRV_008", ads);
                TTRV_009.Checked = get_check("TTRV_009", ads);
                TTRV_010.Checked = get_check("TTRV_010", ads);
                TTRV_011.Checked = get_check("TTRV_011", ads);
                TTRV_012.Checked = get_check("TTRV_012", ads);
                TTRV_013.Checked = get_check("TTRV_013", ads);
                TTRV_014.Checked = get_check("TTRV_014", ads);
                TTRV_015.Checked = get_check("TTRV_015", ads);
                TTRV_016.Checked = get_check("TTRV_016", ads);
                TTRV_017.Checked = (m_v.ttrv_Loaibn_NT(cbUser.SelectedValue.ToString()) != "");
                chkLoaibn_NT.Visible = false;
                TTRV_018.Checked = get_check("TTRV_018", ads);
                TTRV_019.Checked = get_check("TTRV_019", ads);
                TTRV_020.Checked = get_check("TTRV_020", ads);
                TTRV_021.Checked = (m_v.ttrv_Doituongthu(cbUser.SelectedValue.ToString()) != "");
                chkDoituongthu.Visible = false;
                TTRV_022.Checked = get_check("TTRV_022", ads);
                TTRV_023.Checked = (m_v.ttrv_khoathu(cbUser.SelectedValue.ToString()) != "");
                chkkhoaphong.Visible = false;
                TTRV_024.Checked = get_check("TTRV_024", ads);
                TTRV_025.Checked = get_check("TTRV_025", ads);
                TTRV_026.Checked = get_check("TTRV_026", ads);
                TTRV_029.Checked = get_check("TTRV_029", ads);
                TTRV_030.Checked = (m_v.ttrv_bienlai_dichvu(cbUser.SelectedValue.ToString()) != "");
                cTTRV_030.Visible = false;
                TTRV_031.Checked = get_check("TTRV_031", ads);
                TTRV_032.Checked = get_check("TTRV_032", ads);
                TTRV_033.Checked = get_check("TTRV_033", ads);
                TTRV_034.Checked = get_check("TTRV_034", ads);
                TTRV_035.Checked = (m_v.ttrv_tachhoadon_dichvu(cbUser.SelectedValue.ToString()) != "");
                chkTTRV_035.Visible = false;
                TTRV_036.Checked = get_check("TTRV_036", ads);
                TTRV_037.Checked = get_check("TTRV_037", ads);//Thuy 13.09.2012
                TTRV_038.Checked = get_check("TTRV_038", ads);//Thuy 01.10.2012
                
                //
                PC_001.Checked = get_check("PC_001", ads);
                PC_002.Checked = get_check("PC_002", ads);
                PC_003.Checked = get_check("PC_003", ads);
                PC_004.Checked = get_check("PC_004", ads);

                HT_001.Checked = get_check("HT_001", ads);
                HT_002.Checked = get_check("HT_002", ads);

                BHYT_000.Checked = get_check("BHYT_000", ads);

                BHYT_001.Checked = get_check("BHYT_001", ads);
                BHYT_002.Checked = get_check("BHYT_002", ads);
                BHYT_003.Checked = get_check("BHYT_003", ads);
                BHYT_004.Checked = get_check("BHYT_004", ads);
                BHYT_007.Checked = get_check("BHYT_007", ads);
                BHYT_008.Checked = get_check("BHYT_008", ads);
                BHYT_009.Checked = get_check("BHYT_009", ads);
                BHYT_010.Checked = get_check("BHYT_010", ads);
                BHYT_011.Checked = get_check("BHYT_011", ads);
                BHYT_012.Checked = get_check("BHYT_012", ads);
                BHYT_013.Checked = get_check("BHYT_013", ads);
                BHYT_014.Checked = get_check("BHYT_014", ads);
                BHYT_015.Checked = get_check("BHYT_015", ads);
                BHYT_016.Checked = get_check("BHYT_016", ads);
                BHYT_017.Checked = get_check("BHYT_017", ads);
                BHYT_018.Checked = get_check("BHYT_018", ads);
                BHYT_019.Checked = get_check("BHYT_019", ads);
                BHYT_020.Checked = get_check("BHYT_020", ads);
                BHYT_021.Checked = get_check("BHYT_021", ads);
                BHYT_022.Checked = get_check("BHYT_022", ads);
                BHYT_023.Checked = get_check("BHYT_023", ads);

                BHYT_025.Checked = (m_v.bhyt_tachhoadon_dichvu(cbUser.SelectedValue.ToString()) != "");
                chkDoituong.Visible = false;

                BHYT_027.Checked = get_check("BHYT_027", ads);

                BHYT_030.Checked = get_check("BHYT_030", ads);
                BHYT_028.Checked = get_check("BHYT_028", ads);
                BHYT_031.Checked = get_check("BHYT_031", ads);
                BHYT_032.Checked = get_check("BHYT_032", ads);
                BHYT_041.Checked = get_check("BHYT_041", ads);
                chkchondoituong.Checked = get_check("chkchondoituong",ads);
            }
            catch
            {
            }
        }
        private bool get_check(string v_ma, DataSet v_ds)
        {
            try
            {
                return v_ds.Tables[0].Select("ma='" + v_ma + "'")[0]["giatri"].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        private string get_values_option(string v_ma, DataSet v_ds)
        {
            try
            {
                return v_ds.Tables[0].Select("ma='" + v_ma + "'")[0]["giatri"].ToString();
            }
            catch
            {
                return "1";
            }
        }

        private void f_Luu()
        {
            try
            {
                decimal auserid = decimal.Parse(cbUser.SelectedValue.ToString());
                m_v.upd_v_optionform(auserid, 1, "TT_001", TT_001.Text, TT_001.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_002", TT_002.Text, TT_002.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_003", TT_003.Text, TT_003.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_004", TT_004.Text, TT_004.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_005", TT_005.Text, TT_005.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_006", TT_006.Text, TT_006.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_007", TT_007.Text, TT_007.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_008", TT_008.Text, TT_008.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_009", TT_009.Text, TT_009.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_010", TT_010.Text, TT_010.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_038", TT_038.Text, TT_038.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_011", TT_011.Text, TT_011.Checked ? "1" : "0");
               
                m_v.upd_v_optionform(auserid, 1, "TT_012", TT_012.Text, TT_012.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_013", TT_013.Text, TT_013.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_014", TT_014.Text, TT_014.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_015", TT_015.Text, TT_015.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_016", TT_016.Text, TT_016.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_017", TT_017.Text, TT_017.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_018", TT_018.Text, TT_018.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_019", TT_019.Text, TT_019.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_108", TT_108.Text, TT_108.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_109", TT_109.Text, TT_109.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "chkTachbienlai_nhomvp", chkTachbienlai_nhomvp.Text, (chkTachbienlai_nhomvp.Checked && chkTachbienlai_nhomvp.Visible == true) ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "chkTachbienlai_loaivp", chkTachbienlai_loaivp.Text, (chkTachbienlai_loaivp.Checked && chkTachbienlai_loaivp.Visible == true) ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "chkinHDtheo_nhom", chkinHDtheo_nhom.Text, (chkinHDtheo_nhom.Checked && chkinHDtheo_nhom.Visible == true) ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "chkinHDtheo_loai", chkinHDtheo_loai.Text, (chkinHDtheo_loai.Checked && chkinHDtheo_loai.Visible == true) ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "chkInchitiet", chkInchitiet.Text, (chkInchitiet.Checked && chkInchitiet.Visible == true)  ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_020", TT_020.Text, (TT_020.Checked && TT_020.Visible == true) ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_021", TT_021.Text, TT_021.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_022", TT_022.Text, TT_022.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_023", TT_023.Text, TT_023.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_024", TT_024.Text, TT_024.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_025", TT_025.Text, TT_025.Checked ? "1" : "0");                
                if (chkLoaibn.Visible) lblLoaibn_Click(null, null);       
                m_v.upd_v_optionform(auserid, 1, "TT_028", TT_028.Text, TT_028.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_029", TT_029.Text, TT_029.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_030", TT_030.Text, TT_030.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_031", TT_031.Text, TT_031.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_032", TT_032.Text, TT_032.Checked ? "1" : "0");
                if (chkKP.Visible) lbl_TT011_Click(null, null);
                m_v.upd_v_optionform(auserid, 1, "TT_036", TT_036.Text, TT_036.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_037", TT_037.Text, TT_037.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TT_039", TT_039.Text, TT_039.Checked ? "1" : "");
                //
                m_v.upd_v_optionform(auserid, 1, "TT_101", TT_101.Text, TT_101.Checked ? "1" : "");
                m_v.upd_v_optionform(auserid, 1, "TT_102", TT_102.Text, TT_102.Checked ? "1" : "");
                m_v.upd_v_optionform(auserid, 1, "TT_103", TT_103.Text, TT_103.Checked ? "1" : "");
                m_v.upd_v_optionform(auserid, 1, "TT_104", TT_104.Text, TT_104.Checked ? "1" : "");
                if (chktachhoadon.Visible) lblDichvu_Click(null, null);
                m_v.upd_v_optionform(auserid, 1, "TT_107", TT_107.Text, TT_107.Checked ? "1" : "");
                m_v.upd_v_optionform(auserid, 1, "chkThuTungDonThuoc", chkThuTungDonThuoc.Text, chkThuTungDonThuoc.Checked ? "1" : "");//Thuy 20.06.2012
                m_v.upd_v_optionform(auserid, 1, "TT_040", TT_040.Text, TT_040.Checked ? "1" : "");
                m_v.upd_v_optionform(auserid, 1, "TT_041", TT_041.Text, TT_041.Checked ? "1" : "");
                m_v.upd_v_optionform(auserid, 1, "TT_042", "Số Bản IN HDCT", TT_042.Value.ToString());
                m_v.upd_v_optionform(auserid, 1, "TT_043", "In giay de nghi mien", TT_043.Checked ? "1" : "0");
                string ten = "";
                /*for (int i = 0; i < chk_TT_039.Items.Count; i++)
                    if (chk_TT_039.GetItemChecked(i)) ten += dstt_039.Tables[0].Rows[i]["ma"].ToString().PadLeft(3, '0') + ",";
                m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TT_039", TT_039.Text, ten);*/
                ///TRỌN GÓI
                m_v.upd_v_optionform(auserid, 1, "TG_001", TG_001.Text, TG_001.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_002", TG_002.Text, TG_002.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_003", TG_003.Text, TG_003.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_004", TG_004.Text, TG_004.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_005", TG_005.Text, TG_005.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_006", TG_006.Text, TG_006.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_007", TG_007.Text, TG_007.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_008", TG_008.Text, TG_008.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_009", TG_009.Text, TG_009.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_010", TG_010.Text, TG_010.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_011", TG_011.Text, TG_011.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_012", TG_012.Text, TG_012.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_013", TG_013.Text, TG_013.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_014", TG_014.Text, TG_014.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_015", TG_015.Text, TG_015.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TG_016", TG_016.Text, TG_016.Checked ? "1" : "0");

                m_v.upd_v_optionform(auserid, 1, "TU_001", TU_001.Text, TU_001.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_002", TU_002.Text, TU_002.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_003", TU_003.Text, TU_003.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_004", TU_004.Text, TU_004.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_005", TU_005.Text, TU_005.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_006", TU_006.Text, TU_006.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_007", TU_007.Text, TU_007.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_008", TU_008.Text, TU_008.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_009", TU_009.Text, TU_009.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_010", TU_010.Text, TU_010.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TU_011", TU_011.Text, TU_011.Checked ? "1" : "0");

                m_v.upd_v_optionform(auserid, 1, "TTRV_001", TTRV_001.Text, TTRV_001.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_002", TTRV_002.Text, TTRV_002.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_003", TTRV_003.Text, TTRV_003.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_004", TTRV_004.Text, TTRV_004.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_005", TTRV_005.Text, TTRV_005.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_006", TTRV_006.Text, TTRV_006.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_007", TTRV_007.Text, TTRV_007.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_008", TTRV_008.Text, TTRV_008.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_009", TTRV_009.Text, TTRV_009.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_010", TTRV_010.Text, TTRV_010.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_011", TTRV_011.Text, TTRV_011.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_012", TTRV_012.Text, TTRV_012.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_013", TTRV_013.Text, TTRV_013.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_014", TTRV_014.Text, TTRV_014.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_015", TTRV_015.Text, TTRV_015.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_016", TTRV_016.Text, TTRV_016.Checked ? "1" : "0");
                if (chkLoaibn_NT.Visible) lblLoai_NT_Click(null, null);
                m_v.upd_v_optionform(auserid, 1, "TTRV_018", TTRV_018.Text, TTRV_018.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_019", TTRV_019.Text, TTRV_019.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_020", TTRV_020.Text, TTRV_020.Checked ? "1" : "0");
                if (chkDoituongthu.Visible) lblDoituongthu_Click(null, null);
                m_v.upd_v_optionform(auserid, 1, "TTRV_022", TTRV_022.Text, TTRV_022.Checked ? "1" : "0");
                if (chkkhoaphong.Visible) lblKhoathutien_Click(null, null);
                m_v.upd_v_optionform(auserid, 1, "TTRV_024", TTRV_024.Text, TTRV_024.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_025", TTRV_025.Text, TTRV_025.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_026", TTRV_026.Text, TTRV_026.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_027", TTRV_029.Text, TTRV_029.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_028", TTRV_028.Text, TTRV_028.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_029", TTRV_029.Text, TTRV_029.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_030", TTRV_030.Text, TTRV_030.Checked ? "1" : "0");
                ten = "";
                for (int i = 0; i < cTTRV_030.Items.Count; i++)
                    if (cTTRV_030.GetItemChecked(i)) ten += dsttrv_030.Tables[0].Rows[i]["ma"].ToString().PadLeft(3, '0') + ",";
                m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TTRV_030", TTRV_030.Text, ten);
                m_v.upd_v_optionform(auserid, 1, "TTRV_031", TTRV_031.Text, TTRV_031.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_032", TTRV_032.Text, TTRV_032.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_033", TTRV_033.Text, TTRV_033.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "TTRV_034", TTRV_034.Text, TTRV_034.Checked ? "1" : "0");

                m_v.upd_v_optionform(auserid, 1, "TTRV_035", TTRV_035.Text, TTRV_035.Checked ? "1" : "0");//gam 
                ten = "";
                for (int i = 0; i < chkTTRV_035.Items.Count; i++)
                    if (chkTTRV_035.GetItemChecked(i)) ten += dsttrv_hd.Tables[0].Rows[i]["madoituong"].ToString() + ",";
                m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TTRV_035", TTRV_035.Text, ten);
                //
                m_v.upd_v_optionform(auserid, 1, "TTRV_036", TTRV_036.Text, TTRV_036.Checked ? "1" : "0");//binh 120912 
                m_v.upd_v_optionform(auserid, 1, "TTRV_037", TTRV_037.Text, TTRV_037.Checked ? "1" : "0");//Thuy 13.09.2012  
                m_v.upd_v_optionform(auserid, 1, "TTRV_038", TTRV_038.Text, TTRV_038.Checked ? "1" : "0");//Thuy 13.09.2012
                //Phieu chi
                m_v.upd_v_optionform(auserid, 1, "PC_001", PC_001.Text, PC_001.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "PC_002", PC_002.Text, PC_002.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "PC_003", PC_003.Text, PC_003.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "PC_004", PC_004.Text, PC_004.Checked ? "1" : "0");

                m_v.upd_v_optionform(auserid, 1, "HT_001", HT_001.Text, HT_001.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "HT_002", HT_002.Text, HT_002.Checked ? "1" : "0");


                m_v.upd_v_optionform(auserid, 1, "BHYT_000", BHYT_000.Text, BHYT_000.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_001", BHYT_001.Text, BHYT_001.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_002", BHYT_002.Text, BHYT_002.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_003", BHYT_003.Text, BHYT_003.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_004", BHYT_004.Text, BHYT_004.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_007", BHYT_007.Text, BHYT_007.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_008", BHYT_008.Text, BHYT_008.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_009", BHYT_009.Text, BHYT_009.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_010", BHYT_010.Text, BHYT_010.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_011", BHYT_011.Text, BHYT_011.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_012", BHYT_012.Text, BHYT_012.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_013", BHYT_013.Text, BHYT_013.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_014", BHYT_014.Text, BHYT_014.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_015", BHYT_015.Text, BHYT_015.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_016", BHYT_016.Text, BHYT_016.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_017", BHYT_017.Text, BHYT_017.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_018", BHYT_018.Text, BHYT_018.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_019", BHYT_019.Text, BHYT_019.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_020", BHYT_020.Text, BHYT_020.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_021", BHYT_021.Text, BHYT_021.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_022", BHYT_022.Text, BHYT_022.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_023", BHYT_023.Text, BHYT_023.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_027", BHYT_027.Text, BHYT_027.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_030", BHYT_030.Text, BHYT_030.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_028", BHYT_028.Text, BHYT_028.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_031", BHYT_031.Text, BHYT_031.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "BHYT_032", BHYT_032.Text, BHYT_032.Checked ? "1" : "0");

                m_v.upd_v_optionform(auserid, 1, "BHYT_041", BHYT_041.Text, BHYT_041.Checked ? "1" : "0");
                m_v.upd_v_optionform(auserid, 1, "chkchondoituong", chkchondoituong.Text, chkchondoituong.Checked ? "1" : "0");//Thuy 19.01.12
            }
            catch(Exception ex)
            {
            }
        }
        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            f_Load_Data();
        }

        private void tmn_Luu_Click(object sender, EventArgs e)
        {
            tmn_Luu.Enabled = false;
            f_Luu();
            f_Load_Option();
            tmn_Luu.Enabled = true;
            MessageBox.Show(lan.Change_language_MessageText("Lưu thành công"),m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tmn_Ketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Load_Option();
        }

        private void butCopy_Click(object sender, EventArgs e)
        {
            try
            {
                m_userid_copy = cbUser.SelectedValue.ToString();
            }
            catch
            {
            }
            butPaste.Enabled = m_userid_copy != "";
        }

        private void butPaste_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_userid_copy != cbUser.SelectedValue.ToString() && m_userid_copy != "")
                {
                    string auser = m_v.get_data("select hoten||' ('|| userid||')' as hoten from medibv.v_dlogin where id=" + m_userid_copy).Tables[0].Rows[0][0].ToString();
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý thiết lập thông số cho:")+" "+"\n"+ "[" + cbUser.Text + "] = [" + auser + "]"+"\n"+lan.Change_language_MessageText("Lưu ý:")+" "+ "\n"+lan.Change_language_MessageText("Thao tác này không thể phục hồi được!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        m_v.execute_data("delete from medibv.v_optionform where userid="+cbUser.SelectedValue.ToString());
                        m_v.execute_data("delete from medibv.v_optionhotkey where userid=" + cbUser.SelectedValue.ToString());
                        m_v.execute_data("delete from medibv.v_optionhotkey_ksk where userid=" + cbUser.SelectedValue.ToString());
                        m_v.execute_data("insert into medibv.v_optionform(userid,loai,ma,ten,giatri) select "+cbUser.SelectedValue.ToString()+" as id, loai,ma,ten,giatri from medibv.v_optionform where userid=" + m_userid_copy);
                        m_v.execute_data("insert into medibv.v_optionhotkey(userid,loai,hotkey,id,ghichu) select " + cbUser.SelectedValue.ToString() + " as id, loai,hotkey,id,ghichu from medibv.v_optionhotkey where userid=" + m_userid_copy);
                        m_v.execute_data("insert into medibv.v_optionhotkey_ksk(userid,loai,hotkey,id,ghichu) select " + cbUser.SelectedValue.ToString() + " as id, loai,hotkey,id,ghichu from medibv.v_optionhotkey_ksk where userid=" + m_userid_copy);
                        f_Load_Option();
                    }
                }
            }
            catch
            {
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTachbienlai_nhomvp.Checked)
            {
                chkTachbienlai_loaivp.Checked = !chkTachbienlai_nhomvp.Checked;
                chkinHDtheo_loai.Checked = false;
                chkinHDtheo_nhom.Checked = false;
            }
        }

        private void chkTachbienlai_loaivp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTachbienlai_loaivp.Checked)
            {
                chkTachbienlai_nhomvp.Checked = !chkTachbienlai_loaivp.Checked;
                chkinHDtheo_loai.Checked = false;
                chkinHDtheo_nhom.Checked = false;
            }
        }

        private void chkinHDtheo_nhom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkinHDtheo_nhom.Checked)
            {
                chkinHDtheo_loai.Checked = !chkinHDtheo_nhom.Checked;
                chkTachbienlai_loaivp.Checked = false;
                chkTachbienlai_nhomvp.Checked = false;
            }
        }

        private void chkinHDtheo_loai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkinHDtheo_loai.Checked)
            {
                chkinHDtheo_nhom.Checked = !chkinHDtheo_loai.Checked;
                chkTachbienlai_loaivp.Checked = false;
                chkTachbienlai_nhomvp.Checked = false;
            }
        }

        private void TT_024_CheckedChanged(object sender, EventArgs e)
        {
            if (TT_024.Checked)
            {
               // TT_025.Enabled = true;
                TT_025.Checked = true;
            }
            else
            {
               // TT_025.Enabled = false;
                TT_025.Checked = false;
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            try
            {
                decimal auserid = decimal.Parse(cbUser.SelectedValue.ToString());
                frmOptiondoituong af = new frmOptiondoituong(auserid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
            }
            catch 
            {
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                decimal auserid = decimal.Parse(cbUser.SelectedValue.ToString());
                string atenuser = cbUser.Text;
                frmGioihanVP af = new frmGioihanVP(auserid, atenuser);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
            }
            catch
            {
            }
        }

 

        private void lblLoaibn_Click(object sender, EventArgs e)
        {
            chkLoaibn.Visible = !chkLoaibn.Visible;
            if (!chkLoaibn.Visible)
            {
                string ten = "";
                for (int i = 0; i < chkLoaibn.Items.Count; i++)
                {
                    if (chkLoaibn.GetItemChecked(i)) ten += dsLoaibn.Tables[0].Rows[i]["id"].ToString() + ",";
                }
                ten = ten.Trim(',');
                if (ten != "") m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TT_027", TT_027.Text, ten);
                else m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TT_027'");
            }
        }

        private void TT_027_CheckedChanged(object sender, EventArgs e)
        {
            lblLoaibn.Enabled = TT_027.Checked;
        }

        private void chkLoaibn_VisibleChanged(object sender, EventArgs e)
        {
            if (chkLoaibn.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TT_027'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                string[] sten = stemp.Split(',');
                for (int i = 0; i < chkLoaibn.Items.Count; i++)
                {
                    chkLoaibn.SetItemChecked(i, false);
                    for (int j = 0; j < sten.Length; j++)
                    {
                        if (m_v.getrowbyid(dsLoaibn.Tables[0], "id=" + sten[j]) != null && sten[j] == i.ToString()) chkLoaibn.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void lblLoai_NT_Click(object sender, EventArgs e)
        {
            chkLoaibn_NT.Visible = !chkLoaibn_NT.Visible;
            if (chkLoaibn_NT.Visible) chkLoaibn_NT.BringToFront();
            if (!chkLoaibn_NT.Visible)
            {
                string ten = "";
                for (int i = 0; i < chkLoaibn_NT.Items.Count; i++)
                {
                    if (chkLoaibn_NT.GetItemChecked(i)) ten += dsLoaibn_NT.Tables[0].Rows[i]["id"].ToString() + ",";
                }
                ten = ten.Trim(',');
                if (ten != "") m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TTRV_017", TTRV_017.Text, ten);
                else m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_017'");
            }
        }

        private void TTRV_017_CheckedChanged(object sender, EventArgs e)
        {
            lblLoai_NT.Enabled = TTRV_017.Checked;
        }

        private void chkLoaibn_NT_VisibleChanged(object sender, EventArgs e)
        {
            if (chkLoaibn_NT.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_017'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                string[] sten = stemp.Split(',');
                for (int i = 0; i < chkLoaibn_NT.Items.Count; i++)
                {
                    chkLoaibn_NT.SetItemChecked(i, false);
                    for (int j = 0; j < sten.Length; j++)
                    {
                        if (m_v.getrowbyid(dsLoaibn_NT.Tables[0], "id=" + sten[j]) != null && sten[j] == i.ToString()) chkLoaibn_NT.SetItemChecked(i, true);
                    }
                }
            }
        }

   

        private void toolStrip_Macdinh_Click(object sender, EventArgs e)
        {
            try
            {
                //thu truc tiep
                TT_012.Checked = false;
                TT_018.Checked = true;
                TT_013.Checked = false;
                TT_014.Checked = true;
                TT_015.Checked = false;
                TT_016.Checked = false;
                TT_005.Checked = false;
                TT_006.Checked = false;
                TT_007.Checked = false;
                TT_008.Checked = false;
                TT_009.Checked = false;
                TT_038.Enabled=TT_010.Checked = true;
                TT_011.Checked = false;
                TT_017.Checked = false;
                TT_019.Checked = false;
                TT_001.Checked = false;
                TT_002.Checked = false;
                TT_003.Checked = false;
                TT_004.Checked = false;
                TT_023.Checked = false;
                TT_021.Checked = false;
                TT_022.Checked = false;


                TT_024.Checked = false;
                TT_027.Checked = true;
                chkLoaibn.SetItemChecked(0, true);
                chkLoaibn.SetItemChecked(4, true);
                TT_028.Checked = false;
                TT_029.Checked = false;
                TT_030.Checked = false;
                TT_031.Checked = false;
                chkTachbienlai_loaivp.Checked = false;
                chkTachbienlai_nhomvp.Checked = false;
                //tron gói
                TG_001.Checked = false;
                TG_002.Checked = false;
                TG_003.Checked = false;
                TG_004.Checked = false;
                TG_005.Checked = false;
                TG_006.Checked = false;
                TG_007.Checked = false;
                TG_008.Checked = false;
                TG_009.Checked = false;
                TG_010.Checked = true;
                TG_011.Checked = false;
                TG_012.Checked = false;
                TG_013.Checked = false;
                TG_014.Checked = true;
                TG_015.Checked = false;
                TG_006.Checked = false;

                //thu BHYT
                BHYT_000.Checked = false;
                BHYT_001.Checked = false;
                BHYT_002.Checked = false;
                BHYT_003.Checked = false;
                BHYT_004.Checked = false;

                BHYT_007.Checked = true;
                BHYT_008.Checked = false;
                BHYT_009.Checked = false;

                BHYT_010.Checked = true;
                BHYT_011.Checked = false;
                BHYT_012.Checked = false;
                BHYT_013.Checked = false;
                BHYT_014.Checked = false;
                BHYT_015.Checked = true;
                BHYT_016.Checked = true;

                TU_001.Checked = false;
                TU_002.Checked = false;
                TU_003.Checked = false;
                TU_004.Checked = false;
                TU_005.Checked = false;
                TU_006.Checked = false;
                TU_007.Checked = true;
                TU_008.Checked = true;
                TU_009.Checked = false;

                TTRV_001.Checked = false;
                TTRV_002.Checked = false;
                TTRV_003.Checked = false;
                TTRV_004.Checked = false;
                TTRV_005.Checked = false;
                TTRV_006.Checked = false;
                TTRV_007.Checked = false;
                TTRV_008.Checked = true;
                TTRV_009.Checked = true;
                TTRV_010.Checked = false;
                TTRV_011.Checked = false;
                TTRV_012.Checked = false;
                TTRV_013.Checked = false;
                TTRV_014.Checked = true;
                TTRV_015.Checked = true;
                TTRV_016.Checked = true;
                TTRV_017.Checked = true;
                TTRV_034.Checked = true;
                chkLoaibn_NT.SetItemChecked(1, true);
            }
            catch
            {
 
            }
        }

        private void TTRV_010_CheckedChanged(object sender, EventArgs e)
        {
            if (TTRV_010.Checked)
            {
                TTRV_014.Checked = false;
            }
            else if (TTRV_014.Checked)
            {
                TTRV_010.Checked = false;
                TTRV_011.Checked = false;
                TTRV_012.Checked = false;
                TTRV_013.Checked = false;
            }
        }

        private void TTRV_011_CheckedChanged(object sender, EventArgs e)
        {
            if (TTRV_011.Checked)
            {
                TTRV_014.Checked = false;
            }
            else if (TTRV_014.Checked)
            {
                TTRV_010.Checked = false;
                TTRV_011.Checked = false;
                TTRV_012.Checked = false;
                TTRV_013.Checked = false;
            }
        }

        private void TTRV_012_CheckedChanged(object sender, EventArgs e)
        {
            if (TTRV_012.Checked)
            {
                TTRV_014.Checked = false;
            }
            else if (TTRV_014.Checked)
            {
                TTRV_010.Checked = false;
                TTRV_011.Checked = false;
                TTRV_012.Checked = false;
                TTRV_013.Checked = false;
            }
        }

        private void TTRV_013_CheckedChanged(object sender, EventArgs e)
        {
            if (TTRV_013.Checked)
            {
                TTRV_014.Checked = false;
            }
            else if (TTRV_014.Checked)
            {
                TTRV_010.Checked = false;
                TTRV_011.Checked = false;
                TTRV_012.Checked = false;
                TTRV_013.Checked = false;
            }
        }

        private void TTRV_014_CheckedChanged(object sender, EventArgs e)
        {
            if (TTRV_014.Checked)
            {
                TTRV_010.Checked = false;
                TTRV_011.Checked = false;
                TTRV_012.Checked = false;
                TTRV_013.Checked = false;
                //
                TTRV_029.Checked = false;
            }
        }

        private void TT_030_CheckedChanged(object sender, EventArgs e)
        {
            if (TT_030.Checked) TT_032.Checked = false;            
        }

        private void TT_032_CheckedChanged(object sender, EventArgs e)
        {
            if (TT_032.Checked) TT_030.Checked = false;            
        }

        private void lblDoituongthu_Click(object sender, EventArgs e)
        {
            chkDoituongthu.Visible = !chkDoituongthu.Visible;
            if (chkDoituongthu.Visible) chkDoituongthu.BringToFront();
            if (!chkDoituongthu.Visible)
            {
                string ten = "";
                for (int i = 0; i < chkDoituongthu.Items.Count; i++)
                {
                    if (chkDoituongthu.GetItemChecked(i)) ten += dtDoituongthu_NT.Rows[i]["madoituong"].ToString() + ",";
                }
                ten = ten.Trim(',');
                if (ten != "") m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TTRV_021", TTRV_021.Text, ten);
                else m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_021'");
            }
        }

        private void TTRV_021_CheckedChanged(object sender, EventArgs e)
        {
            lblDoituongthu.Enabled = TTRV_021.Checked;
        }

        private void chkDoituongthu_VisibleChanged(object sender, EventArgs e)
        {
            if (chkDoituongthu.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_021'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                stemp = stemp + ",";

                for (int i = 0; i < dtDoituongthu_NT.Rows.Count; i++)
                {                    
                    if (stemp.IndexOf(dtDoituongthu_NT.Rows[i]["madoituong"].ToString().Trim() + ",") != -1)
                        chkDoituongthu.SetItemCheckState(i, CheckState.Checked);
                    else
                        chkDoituongthu.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void TTRV_023_CheckedChanged(object sender, EventArgs e)
        {
            lblKhoathutien.Enabled = TTRV_023.Checked;
        }

        private void lblKhoathutien_Click(object sender, EventArgs e)
        {
            chkkhoaphong.Visible = !chkkhoaphong.Visible;
            if (chkkhoaphong.Visible) chkkhoaphong.BringToFront();
            if (!chkkhoaphong.Visible)
            {
                string ten = "";
                for (int i = 0; i < chkkhoaphong.Items.Count; i++)
                {
                    if (chkkhoaphong.GetItemChecked(i)) ten += "'" + dskhoa_thu.Tables[0].Rows[i]["makp"].ToString() + "',";
                }
                ten = ten.Trim(',');
                if (ten != "") m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TTRV_023", TTRV_023.Text, ten);
                else m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_023'");
            }
        }

        private void chkkhoaphong_VisibleChanged(object sender, EventArgs e)
        {
            if (chkkhoaphong.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_023'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                stemp = stemp + ",";

                for (int i = 0; i < dskhoa_thu.Tables[0].Rows.Count; i++)
                {
                    if (stemp.IndexOf("'" + dskhoa_thu.Tables[0].Rows[i]["makp"].ToString().Trim() + "',") != -1)
                        chkkhoaphong.SetItemCheckState(i, CheckState.Checked);
                    else
                        chkkhoaphong.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void lbl_TT011_Click(object sender, EventArgs e)
        {
            chkKP.Visible = !chkKP.Visible;
            if (!chkKP.Visible)
            {
                string ten = "";
                for (int i = 0; i < chkKP.Items.Count; i++)
                {
                    if (chkKP.GetItemChecked(i)) ten += "'" + dskhoa_thu.Tables[0].Rows[i]["makp"].ToString() + "',";
                }
                ten = ten.Trim(',');
                if (ten != "") m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TT_035", TT_035.Text, ten);
                else m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TT_035'");
            }
        }

        private void chkKP_VisibleChanged(object sender, EventArgs e)
        {
            if (chkKP.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TT_035'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                stemp = stemp + ",";
                for (int i = 0; i < dskhoa_thu.Tables[0].Rows.Count; i++)
                {
                    if (stemp.IndexOf("'" + dskhoa_thu.Tables[0].Rows[i]["makp"].ToString().Trim() + "',") != -1)
                        chkKP.SetItemCheckState(i, CheckState.Checked);                                    
                    else
                        chkKP.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void TT_035_CheckedChanged(object sender, EventArgs e)
        {
            lbl_TT011.Enabled = TT_035.Checked;
        }

        private void TTRV_025_CheckedChanged(object sender, EventArgs e)
        {
            if (TTRV_025.Checked)
            {
                TTRV_005.Checked = true;
                TTRV_006.Checked = true;
                TTRV_005.Enabled = false;
                TTRV_006.Enabled = false;
            }
            else 
            {
                TTRV_005.Enabled = true;
                TTRV_006.Enabled = true;
            }
        }

        private void BHYT_015_CheckedChanged(object sender, EventArgs e)
        {
            if (BHYT_015.Checked)
            {
                //BHYT_010.Checked = false;
            }
            //BHYT_010.Enabled = !BHYT_015.Checked;
            BHYT_019.Enabled = BHYT_015.Checked;
        }

        private void TT_025_CheckedChanged(object sender, EventArgs e)
        {
            if (!TT_025.Checked) TT_024.Checked = false;
        }

        private void TT_010_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == TT_010) TT_038.Enabled = TT_010.Checked;
        }

        private void lTTRV_030_Click(object sender, EventArgs e)
        {
            cTTRV_030.Visible = !cTTRV_030.Visible;
            if (cTTRV_030.Visible) cTTRV_030.BringToFront();
            if (!cTTRV_030.Visible)
            {
                string ten = "";
                for (int i = 0; i < cTTRV_030.Items.Count; i++)
                {
                    if (cTTRV_030.GetItemChecked(i)) ten += dsttrv_030.Tables[0].Rows[i]["ma"].ToString().PadLeft(3,'0') + ",";
                }
                if (ten != "")
                {
                    m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TTRV_030", TTRV_030.Text, ten);
                    m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_035'");
                }
                else 
                    m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_030'");
            }
        }

        private void cTTRV_030_VisibleChanged(object sender, EventArgs e)
        {           
            if (cTTRV_030.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_030'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                for (int i = 0; i < dsttrv_030.Tables[0].Rows.Count; i++)
                {
                    if (stemp.IndexOf(dsttrv_030.Tables[0].Rows[i]["ma"].ToString().PadLeft(3,'0')) != -1)
                        cTTRV_030.SetItemCheckState(i, CheckState.Checked);
                    else
                        cTTRV_030.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void TTRV_030_CheckedChanged(object sender, EventArgs e)
        {
            lTTRV_030.Enabled = TTRV_030.Checked;
            if (TTRV_030.Checked)
            {
                TTRV_035.Checked = false;
            }
        }

        private void chk_TT_039_VisibleChanged(object sender, EventArgs e)
        {
            if (chk_TT_039.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TT_039'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                for (int i = 0; i < dstt_039.Tables[0].Rows.Count; i++)
                {
                    if (stemp.IndexOf(dstt_039.Tables[0].Rows[i]["ma"].ToString().PadLeft(3, '0')) != -1)
                        chk_TT_039.SetItemCheckState(i, CheckState.Checked);
                    else
                        chk_TT_039.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void lbl_TT_039_Click(object sender, EventArgs e)
        {
            chk_TT_039.Visible = !chk_TT_039.Visible;
            if (!chk_TT_039.Visible)
            {
                string ten = "";
                for (int i = 0; i < chk_TT_039.Items.Count; i++)
                {
                    if (chk_TT_039.GetItemChecked(i)) ten += dstt_039.Tables[0].Rows[i]["ma"].ToString().PadLeft(3, '0') + ",";
                }
                if (ten != "") m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TT_039", TT_039.Text, ten);
                else m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TT_039'");
            }
        }

        private void TT_039_CheckedChanged(object sender, EventArgs e)
        {
            lbl_TT_039.Enabled = TT_039.Checked;
        }

        private void BHYT_020_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == BHYT_020 && BHYT_020.Checked) BHYT_021.Checked = false;
        }

        private void BHYT_021_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == BHYT_021 && BHYT_021.Checked) BHYT_020.Checked = false;
        }

        private void TTRV_031_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == TTRV_031 && TTRV_031.Checked) TTRV_032.Checked = false;
        }

        private void TTRV_032_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == TTRV_032 && TTRV_032.Checked) TTRV_031.Checked = false;
        }

        private void TT_101_Click(object sender, EventArgs e)
        {
            if (TT_101.Checked) TT_102.Checked = false;
        }

        private void TT_102_Click(object sender, EventArgs e)
        {
            if (TT_102.Checked) TT_101.Checked = false;
        }

        private void BHYT_022_Click(object sender, EventArgs e)
        {
            if(BHYT_022.Checked) BHYT_017.Checked = false;
        }

        private void BHYT_017_Click(object sender, EventArgs e)
        {
            if (BHYT_017.Checked) BHYT_022.Checked = false;
        }

        private void TT_003_Click(object sender, EventArgs e)
        {
            TT_103.Enabled = TT_003.Checked;
        }

        private void TTRV_029_CheckedChanged(object sender, EventArgs e)
        {
            if (TTRV_014.Checked) TTRV_029.Checked = false;
        }

        private void TU_003_CheckedChanged(object sender, EventArgs e)
        {
            TU_011.Enabled = TU_003.Checked;
            if (TU_003.Checked == false) TU_011.Checked=false;
        }

        private void label28_Click(object sender, EventArgs e)
        {
            try
            {
                decimal auserid = decimal.Parse(cbUser.SelectedValue.ToString());
                frmOptiondoituong af = new frmOptiondoituong(auserid,"BHYT_024");
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
            }
            catch
            {
            }
        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void chkTachbienlai_dichvu_CheckedChanged(object sender, EventArgs e)
        {
            lblDichvu.Enabled = true;
        }

        private void lblDichvu_Click(object sender, EventArgs e)
        {
            chktachhoadon.Visible = !chktachhoadon.Visible;
            if (!chktachhoadon.Visible)
            {
                string ten = "";
                for (int i = 0; i < chktachhoadon.Items.Count; i++)
                {
                    if (chktachhoadon.GetItemChecked(i)) ten += dsdoituong.Tables[0].Rows[i]["madoituong"].ToString() + ",";
                }
                ten = ten.Trim(',');
                if (ten != "")
                    m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TT_106", TT_106.Text, ten);
                else
                    m_v.execute_data("delete from "+ m_v.user+".v_optionform where userid="+cbUser.SelectedValue.ToString()+" and loai=1 and ma='TT_106'");
            }
        }

        private void chktachhoadon_VisibleChanged(object sender, EventArgs e)
        {
            if (chktachhoadon.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select array(select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TT_106')");
                stemp = dstmp.Tables[0].Rows[0][0].ToString();
                stemp = stemp.Trim('}');
                stemp = stemp.Trim('{');
                stemp = stemp.Replace("\"", "");
                if (stemp != "")
                {
                    stemp = stemp + ",";
                    for (int i = 0; i < chktachhoadon.Items.Count; i++)
                    {
                        chktachhoadon.SetItemChecked(i, false);
                    }
                    for (int i = 0; i < chktachhoadon.Items.Count; i++)
                    {
                        DataRowView r = (DataRowView)chktachhoadon.Items[i];
                        string s_id = r[0].ToString() + ",";
                        if (stemp.IndexOf(s_id) > -1)
                        {
                            chktachhoadon.SetItemChecked(i, true);
                        }
                    }
                }
            }

        }

        private void lbltachhoadon_Click(object sender, EventArgs e)
        {
            chkDoituong.Visible = !chkDoituong.Visible;
            if (!chkDoituong.Visible)
            {
                string ten = "";
                for (int i = 0; i < chkDoituong.Items.Count; i++)
                {
                    if (chkDoituong.GetItemChecked(i)) ten += dsbhyt_hd.Tables[0].Rows[i]["madoituong"].ToString() + ",";
                }
                ten = ten.Trim(',');
                if (ten != "")
                    m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "BHYT_025", BHYT_025.Text, ten);
                else
                    m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='BHYT_025'");
            }
        }

        private void BHYT_025_CheckedChanged(object sender, EventArgs e)
        {
            if (BHYT_025.Checked)
                lbltachhoadon.Enabled = true;
            else
                lbltachhoadon.Enabled = false;
        }

        private void chkDoituong_VisibleChanged(object sender, EventArgs e)
        {
            if (chkDoituong.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='BHYT_025'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                string[] sten = stemp.Split(',');
                for (int i = 0; i < chkDoituong.Items.Count; i++)
                {
                    chkDoituong.SetItemChecked(i, false);
                    for (int j = 0; j < sten.Length; j++)
                    {
                        int a = i + 1;
                        if (m_v.getrowbyid(dsbhyt_hd.Tables[0], "madoituong=" + sten[j]) != null && sten[j] == a.ToString() ) chkDoituong.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void lblTachHD_ttrv_Click(object sender, EventArgs e)
        {
            chkTTRV_035.Visible = !chkTTRV_035.Visible;
            if (!chkTTRV_035.Visible)
            {
                string ten = "";
                for (int i = 0; i < chkTTRV_035.Items.Count; i++)
                {
                    if (chkTTRV_035.GetItemChecked(i)) ten += dsttrv_hd.Tables[0].Rows[i]["madoituong"].ToString() + ",";
                }
                ten = ten.Trim(',');
                if (ten != "")
                {
                    m_v.upd_optionform(decimal.Parse(cbUser.SelectedValue.ToString()), 1, "TTRV_035", TTRV_035.Text, ten);
                    m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_030'");
                }
                else
                    m_v.execute_data("delete from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_035'");
            }
            
        }

        private void TTRV_035_CheckedChanged(object sender, EventArgs e)
        {
            lblTachHD_ttrv.Enabled = TTRV_035.Checked;
            if (TTRV_035.Checked)
            {
                TTRV_030.Checked = false;
            }
            
        }

        private void chkTTRV_035_VisibleChanged(object sender, EventArgs e)
        {
            if (chkTTRV_035.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_optionform where userid=" + cbUser.SelectedValue.ToString() + " and loai=1 and ma='TTRV_035'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                string[] sten = stemp.Split(',');
                string madoituong = "";
                for (int i = 0; i < chkTTRV_035.Items.Count; i++)
                {
                    chkTTRV_035.SetItemChecked(i, false);
                    for (int j = 0; j < sten.Length; j++)
                    {
                        DataRowView drv = (DataRowView)(chkTTRV_035.Items[i]);
                        madoituong = drv["madoituong"].ToString();
                        if (madoituong == sten[j])
                        {
                            chkTTRV_035.SetItemChecked(i, true);
                        }
                        //int a = i + 1;
                        //if (m_v.getrowbyid(dsttrv_hd.Tables[0], "madoituong=" + sten[j]) != null && sten[j] == a.ToString()) chkTTRV_035.SetItemChecked(i, true);
                    }
                }
            }
        }

       
        private void lblGHVP_NoiTru_Click(object sender, EventArgs e)
        {
            try
            {
                decimal auserid = decimal.Parse(cbUser.SelectedValue.ToString());
                string atenuser = cbUser.Text;
                frmGioihanVP af = new frmGioihanVP(auserid, atenuser);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
            }
            catch
            {
            }
        }

        private void TT_016_CheckedChanged(object sender, EventArgs e)
        {
            lblGHVP_Noitru.Visible = TT_016.Checked;
        }

        private void lblGHVP_Noitru_Click_1(object sender, EventArgs e)
        {
            try
            {
                decimal auserid = decimal.Parse(cbUser.SelectedValue.ToString());
                string atenuser = cbUser.Text;
                string m_tso = "TT_016_MAVP";
                frmGioihanVP af = new frmGioihanVP(auserid, atenuser, m_tso);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
            }
            catch
            {
            }
        }

        private void TT_005_CheckedChanged(object sender, EventArgs e)
        {
            lblGHVP_Noitru.Enabled = lblGHVP_Noitru.Visible && TT_005.Checked;
            label3.Enabled = TT_005.Checked;
        }

        private void TT_011_CheckedChanged(object sender, EventArgs e)
        {
            TT_040.Enabled = TT_041.Enabled = TT_011.Checked;
            if (TT_011.Checked == false) { TT_040.Checked = false; TT_041.Checked = false; }
        }

        private void TT_107_CheckedChanged(object sender, EventArgs e)
        {
            if (TT_107.Checked)
                TT_036.Checked = false;
        }

        private void TT_036_CheckedChanged(object sender, EventArgs e)
        {
            if (TT_036.Checked)
                TT_107.Checked = false;
        }        
    }
}