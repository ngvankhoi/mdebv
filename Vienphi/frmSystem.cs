using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Vienphi
{
    public partial class frmSystem : Form
    {
        Language lan = new Language();
        private LibVP.AccessData m_v;
        private string m_userid="";
        private DataTable dsloaibnmien = new DataTable();

        public frmSystem(LibVP.AccessData v_v, string v_userid)
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
           // if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
           // this.Refresh();
        
            chkChonhinhBN_CheckedChanged(null, null);
            if(m_userid=="156")
            {
                chkSys_write_xml.Enabled=true;
                chkSys_write_xml.Visible=true;
            }

        }
        private void f_Load_Data()
        {
            try
            {
                try
                {
                    cbKhoakhongkham.ValueMember = "makp";
                    cbKhoakhongkham.DisplayMember = "tenkp";
                    cbKhoakhongkham.DataSource = m_v.get_data("select makp,tenkp from medibv.btdkp_bv order by loai, tenkp").Tables[0];
                    cbKhoakhongkham.SelectedValue = m_v.sys_makp_khongkham;
                   
                }
                catch
                {
                    cbKhoakhongkham.SelectedIndex = 0;
                }
                dsloaibnmien = m_v.get_data("select * from " + m_v.user + ".v_loaibn").Tables[0];
                chkLoaibnmien.DataSource = dsloaibnmien;
                chkLoaibnmien.ValueMember = "TEN";
                chkLoaibnmien.DisplayMember = "TEN";
                

                try
                {
                    cbCongkhambhyt.ValueMember = "id";
                    cbCongkhambhyt.DisplayMember = "ten";
                    cbCongkhambhyt.DataSource = m_v.get_data("select id, ten from medibv.v_giavp order by ten asc").Tables[0];
                    cbCongkhambhyt.SelectedValue = m_v.sys_mavp_congkhamBHYT;

                }
                catch
                {
                    cbCongkhambhyt.SelectedIndex = 0;
                }
                try
                {
                    cbLoaifile.Text = m_v.sys_TypeFile;
                }
                catch
                {
                    cbLoaifile.Text = "JPEG";
                }
             
                chkMientheoloaibn.Checked = (m_v.sys_Loaibn_mien() != "");
                chkLoaibnmien.Visible = false;

                chkChonhinhBN.Checked = m_v.sys_ChonhinhBN;
                txtPathImageBN.Text = m_v.sys_Pathimage;
                chkkhuyenmai.Checked = m_v.sys_khuyenmai;
                txtSolanin.Value = decimal.Parse(m_v.sys_solanin);
                chkDungchungso.Checked = m_v.sys_dungchungso;
                chkSBLtuden.Checked = m_v.sys_SBLtu_den;
                chkNhapsotienchitiet_tu.Checked = m_v.sys_nhapsotienchitiet_tu;
                chkHoantramon_TT.Checked = m_v.sys_hoantramon_tt;

                txtReport_Tructiep_thuong.Text=m_v.sys_report_thutructiep;
                txtReport_Tructiep_dacthu.Text = m_v.sys_report_thutructiep_thuong;
                txtReport_Tructiep_gtgt.Text = m_v.sys_report_thutructiep_gtgt;
                txtReport_Tamung.Text = m_v.sys_report_thutamung;
                txtReport_Ravien.Text = m_v.sys_report_ravien;
                txtReport_Ravien_Thuong.Text = m_v.sys_report_ravien_thuong;
                txtReport_Ravien_Chi.Text = m_v.sys_report_ravien_chi;
                //Them thong so in chi tiet trong thanh toan ra vien.
                chkReport_Ravien.Checked = (m_v.sys_report_ravien_ct=="1"?true:false);
                chkReport_Ravien_Thuong.Checked = (m_v.sys_report_ravien_thuong_ct=="1"?true:false);
                chkReport_Ravien_Chi.Checked = (m_v.sys_report_ravien_chi_ct=="1"?true:false);
                chkSys_write_xml.Checked=(m_v.sys_write_xml=="1"?true:false);
                //End.
                txtReport_Trongoi.Text = m_v.sys_report_trongoi;
                txtReport_Phieuchi.Text = m_v.sys_report_phieuchi;
                txtReport_BHYT.Text = m_v.sys_report_bhyt;
                txtInbienlaihoan.Text = m_v.sys_report_inhoantra;

                ttrv_thuoc_vienphi.Checked = m_v.sys_ttrv_thuoc_vienphi;

                txtketoantruong.Text=m_v.sys_ketoantruong ;
                txtthuquy.Text = m_v.sys_thuquy;
                txtketoanvienphi.Text = m_v.sys_ketoanvp;
                txtmausobienlai.Text = m_v.sys_maubienlai;
                txtmasothue.Text = m_v.sys_masothue;
                txtsotaikhoan.Text = m_v.sys_sotaikhoan;
                txtdiachi.Text = m_v.sys_diachi;                
                txtSokichhoat.Value = decimal.Parse(m_v.sys_sokichhoat);
                chkDoctinnhan.Checked = m_v.sys_doctinnhan;
                chkChukyDT.Checked = m_v.sys_Chuky;
                chkLocnguoithu.Checked = m_v.sys_Loctheonguoidangnhap;
                txtsothang.Value = decimal.Parse(m_v.sys_sothang);
                nrcMienGiam.Value = m_v.TiLeGiam;
                chkReport_Ravien_ct.Checked = m_v.sys_report_ravien_ct=="1";
            }
            catch
            {
            }
        }
        private void f_Luu()
        {
            try
            {
                m_v.TiLeGiam = (int)nrcMienGiam.Value;
                m_v.sys_dungchungso = chkDungchungso.Checked;
                m_v.sys_SBLtu_den = chkSBLtuden.Checked;
                m_v.sys_khuyenmai = chkkhuyenmai.Checked;
                m_v.sys_solanin = txtSolanin.Value.ToString();
                m_v.sys_doctinnhan = chkDoctinnhan.Checked;
                //m_v.sys_Xoatemp = txtTemp.Text;
                //try
                //{
                //    if ((Environment.GetEnvironmentVariable("TEMP") != txtTemp.Text) && (txtTemp.Text != ""))
                //    {
                //        if (!Directory.Exists(txtTemp.Text))
                //        {
                //            Directory.CreateDirectory(txtTemp.Text);
                //        }
                //        Environment.SetEnvironmentVariable("TEMP", txtTemp.Text, EnvironmentVariableTarget.User);
                //    }
                //}
                //catch
                //{
                //}               
                if (chkLoaibnmien.Visible) lblLoaibn_Click(null, null);

                m_v.sys_ChonhinhBN = chkChonhinhBN.Checked;
                m_v.sys_Pathimage = txtPathImageBN.Text.Trim();
                try
                {
                    m_v.sys_TypeFile = cbLoaifile.Text;
                }
                catch
                {
                    m_v.sys_TypeFile = "JPEG";
                }
                m_v.sys_nhapsotienchitiet_tu = chkNhapsotienchitiet_tu.Checked;
                try
                {
                    m_v.sys_makp_khongkham = cbKhoakhongkham.SelectedValue.ToString();
                }
                catch
                {
                    m_v.sys_makp_khongkham="01";
                }

                try
                {
                    m_v.sys_mavp_congkhamBHYT = cbCongkhambhyt.SelectedValue.ToString();
                }
                catch
                {
                    m_v.sys_mavp_congkhamBHYT = "0000";
                }

                m_v.sys_hoantramon_tt = chkHoantramon_TT.Checked;
                m_v.sys_report_thutructiep = txtReport_Tructiep_thuong.Text;
                m_v.sys_report_thutructiep_thuong = txtReport_Tructiep_dacthu.Text;
                m_v.sys_report_thutructiep_gtgt = txtReport_Tructiep_gtgt.Text;
                m_v.sys_report_thutamung = txtReport_Tamung.Text;
                m_v.sys_report_ravien = txtReport_Ravien.Text;
                m_v.sys_report_ravien_thuong = txtReport_Ravien_Thuong.Text;
                m_v.sys_report_ravien_chi = txtReport_Ravien_Chi.Text;
                //Them check in chi tiet.
                m_v.sys_report_ravien_ct = (chkReport_Ravien.Checked==true?"1":"0");
                m_v.sys_report_ravien_thuong_ct = (chkReport_Ravien_Thuong.Checked==true?"1":"0");
                m_v.sys_report_ravien_chi_ct = (chkReport_Ravien_Chi.Checked==true?"1":"0");
                m_v.sys_write_xml = (chkSys_write_xml.Checked == true ? "1" : "0");
                //End.
                m_v.sys_ttrv_thuoc_vienphi = ttrv_thuoc_vienphi.Checked;
                m_v.sys_report_phieuchi = txtReport_Phieuchi.Text;
                m_v.sys_report_trongoi = txtReport_Trongoi.Text;
                m_v.sys_report_bhyt = txtReport_BHYT.Text;
                m_v.sys_ketoantruong = txtketoantruong.Text;
                m_v.sys_report_inhoantra = txtInbienlaihoan.Text;
                m_v.sys_thuquy = txtthuquy.Text;
                m_v.sys_ketoanvp = txtketoanvienphi.Text;
                m_v.sys_maubienlai = txtmausobienlai.Text;
                m_v.sys_masothue = txtmasothue.Text;
                m_v.sys_sotaikhoan = txtsotaikhoan.Text;
                m_v.sys_diachi = txtdiachi.Text;
                m_v.sys_sokichhoat = txtSokichhoat.Value.ToString();
                m_v.sys_Chuky = chkChukyDT.Checked;
                m_v.sys_Loctheonguoidangnhap = chkLocnguoithu.Checked;//Loc theo nguoi dang nhap trong cac bao cao
                m_v.sys_sothang = txtsothang.Value.ToString();
                m_v.sys_report_ravien_ct = chkReport_Ravien_ct.Checked ? "1" : "0";
                m_v.sys_khongchoxem_tongthu = chkKhongxemtongthu.Checked ? "1" : "0";
            }
            catch
            {
            }
        }

        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            f_Load_Data();
        }

        private void tmn_Luu_Click(object sender, EventArgs e)
        {
            f_Luu();
        }

        private void tmn_Ketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmn_Khoasolieu_Click(object sender, EventArgs e)
        {
            try
            {
                frmKhoasolieu af = new frmKhoasolieu();
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
            }
            catch { }
        }

   

        private void chkChonhinhBN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChonhinhBN.Checked)
            {
                txtPathImageBN.Enabled = true;
                butImageBN.Enabled = true;
            }
            else
            {
                txtPathImageBN.Enabled = false;
                butImageBN.Enabled = false;
            }
        }

        private void butImageBN_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog af = new SaveFileDialog();
                af.ShowDialog();
                txtPathImageBN.Text = af.FileName.ToString();                
            }
            catch
            { 
            }
        }

        private void toolStrip_Macdinh_Click(object sender, EventArgs e)
        {
            try
            {
                chkDungchungso.Checked = false;
                chkSBLtuden.Checked = true;
                chkkhuyenmai.Checked = false;
                txtSolanin.Value = 2;
                chkChonhinhBN.Checked = false;
                txtPathImageBN.Text = "";
                txtReport_Tructiep_thuong.Text = "v_bienlaithuvienphi.rpt";
                txtReport_Tructiep_dacthu.Text = "v_bienlaithuvienphi_thuong.rpt";
                txtReport_Trongoi.Text = "v_bienlaithuvienphitrongoi.rpt";
                txtReport_BHYT.Text = "v_bienlaithuvienphibhyt.rpt";
                txtReport_Tamung.Text = "v_bienlaitamung.rpt";

                txtReport_Ravien.Text = "v_bienlaithuvienphint.rpt";
                txtReport_Ravien_Thuong.Text = "v_bienlaithuvienphint_thuong.rpt";
                txtReport_Ravien_Chi.Text = "v_bienlaithuvienphint_thuchi.rpt";

                txtReport_Phieuchi.Text = "v_phieuchi.rpt";
                txtInbienlaihoan.Text = "v_phieuchi_hoantra.rpt";
            }
            catch
            { 
            }
        }

        private void lblLoaibn_Click(object sender, EventArgs e)
        {
            chkLoaibnmien.Visible = !chkLoaibnmien.Visible;
            if (!chkLoaibnmien.Visible)
            {
                string ten = "";
                for (int i = 0; i < chkLoaibnmien.Items.Count; i++)
                {
                    if (chkLoaibnmien.GetItemChecked(i)) ten += dsloaibnmien.Rows[i]["id"].ToString() + ",";
                }
               // ten = ten.Trim(',');
                if (ten != "") m_v.upd_v_option("chkMientheoloaibn", ten);
                else m_v.execute_data("delete from " + m_v.user + ".v_option where ma='chkMientheoloaibn'");
            }
        }

        private void chkMientheoloaibn_CheckedChanged(object sender, EventArgs e)
        {
            lblLoaibn.Enabled = chkMientheoloaibn.Checked;
        }

        private void chkLoaibnmien_VisibleChanged(object sender, EventArgs e)
        {
            if (chkLoaibnmien.Visible)
            {
                DataSet dstmp = new DataSet();
                string stemp = "";
                dstmp = m_v.get_data("select giatri from " + m_v.user + ".v_option where ma='chkMientheoloaibn'");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    stemp = r["giatri"].ToString();
                    break;
                }
                for (int i = 0; i < chkLoaibnmien.Items.Count; i++)
                    if (stemp.IndexOf(dsloaibnmien.Rows[i]["id"].ToString() + ",") != -1) chkLoaibnmien.SetItemCheckState(i, CheckState.Checked);
            }
        }
    }
}