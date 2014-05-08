using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmPhieutheodoitapVLTL : Form
    {
        LibMedi.AccessData m;
        Language lan = new Language();
        string sql = "",s_mabn="",s_hoten="",s_tuoi="",s_phai="",s_diachi="",s_dienthoai="",s_chandoan="",s_doituong="",s_bacsi="",s_ngay="",user="",s_mabs="";
        int i_userid = 0,i_chinhanh=0;
        decimal d_mavaovien = 0, d_maql = 0,d_id=0;
        bool bNew = false;
        DataSet ds;
        DataSet dsBacsi;

        public frmPhieutheodoitapVLTL(LibMedi.AccessData _m, string _mabn, string _hoten, string _tuoi,string _phai, string _diachi,string _dienthoai,string _chandoan,string _doituong,string _mabacsi,decimal _mavv,decimal _maql,int _userid,string _ngay,int _chinhanh)
        {
            InitializeComponent();
            m = _m;
            s_mabn = _mabn; s_hoten = _hoten; s_tuoi = _tuoi; s_phai = _phai; s_diachi = _diachi; s_dienthoai = _dienthoai; s_chandoan = _chandoan; s_doituong = _doituong; s_mabs = _mabacsi; s_ngay = _ngay;
            d_mavaovien = _mavv; d_maql = _maql;
            i_userid = _userid;i_chinhanh=_chinhanh ;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        
        private void frmPhieutheodoitapVLTL_Load(object sender, EventArgs e)
        {
            user = m.user;
            txtMabn.Text = s_mabn; txtHoten.Text = s_hoten; txtTuoi.Text = s_tuoi; txtGioitinh.Text = s_phai;
            txtDiachi.Text = s_diachi; txtDienthoai.Text = s_dienthoai; txtDoituong.Text = s_doituong;// txtMabs.Text = s_mabs;
            txtChandoan.Text = s_chandoan;

            sql = "select ma,hoten from "+user+".dmbs where chinhanh="+i_chinhanh;
            dsBacsi = m.get_data(sql);
            listBS.DataSource = dsBacsi.Tables[0];
            listBS.DisplayMember = "ma";
            listBS.ValueMember = "hoten";
            txtMabs.Text = s_mabs;
            txtMabs_Validated(null, null);
            load_data();
            
            //cmbNgay.DataSource = ds.Tables[0];
            cmbNgay.DisplayMember = "ngay";
            cmbNgay.ValueMember = "id";

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbNgay.SelectedIndex = 0;
                ena_object(false);
            }
            else
            {
                butMoi_Click(null, null);
                //ena_object(true);
                //emp_detail();
            }
        }

        private void load_data()
        {
            sql = "select id,mabn,to_char(ngay,'dd/mm/yyyy hh24:mi') ngay,mabs,sieuam,keodan,dien,tutruong,apsuat,khac from " + user + ".theodoivltl where mabn='" + s_mabn + "' and mavaovien=" + d_mavaovien.ToString() + " and maql=" + d_maql + " order by ngay";
            ds = m.get_data(sql);
            cmbNgay.DataSource = ds.Tables[0];
        }

        private void cmbNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow r;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    r = m.getrowbyid(ds.Tables[0], "id=" + cmbNgay.SelectedValue);
                    if (r == null)
                    {
                        r = m.getrowbyid(ds.Tables[0], "id=" + ds.Tables[0].Rows[0]["id"].ToString());
                        d_id = decimal.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                    }
                    d_id = decimal.Parse(r["id"].ToString());
                    txtNgay.Value = m.StringToDateTime(r["ngay"].ToString());
                    txtSieuam.Text = r["sieuam"].ToString();
                    txtKeocs.Text = r["keodan"].ToString();
                    txtDien.Text = r["dien"].ToString();
                    txtTutruong.Text = r["tutruong"].ToString();
                    txtApsuat.Text = r["apsuat"].ToString();
                    txtKhac.Text = r["khac"].ToString();
                    txtMabs.Text = r["mabs"].ToString();
                    txtMabs_Validated(null, null);
                }
                else
                {
                    emp_detail();
                }
            }
            catch { }
        }

        private void emp_detail()
        {
            txtNgay.Value = m.StringToDateTime(s_ngay);

            txtSieuam.Text = "";
            txtKeocs.Text = "";
            txtDien.Text = "";
            txtTutruong.Text = "";
            txtApsuat.Text = "";
            txtKhac.Text = "";
            txtMabs.Text = s_mabs;
            txtMabs_Validated(null, null);
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            ena_object(true);
            emp_detail();
            bNew = true;
            txtNgay.Value = m.StringToDateTime(m.ngayhienhanh_server);
        }

        private void ena_object(bool ena)
        {
            txtNgay.Visible = ena;
            cmbNgay.Visible = !ena;
            butMoi.Enabled = !ena;
            butHuy.Enabled = !ena;
            butIn.Enabled = !ena;
            butLuu.Enabled = ena;
            butSua.Enabled = !ena;
            txtMabs.Enabled = ena;
            txtChidinh.Enabled = ena;
            txtSieuam.Enabled = ena;
            txtTutruong.Enabled = ena;
            txtDien.Enabled = ena;
            txtKeocs.Enabled = ena;
            txtKhac.Enabled = ena;
            txtApsuat.Enabled = ena;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            bNew = false;
            ena_object(false);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbNgay.SelectedIndex = 0;
                //cmbNgay_SelectedIndexChanged(null, null);
            }
            else
                d_id = 0;
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            bNew = false;
            ena_object(true);
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (!m.bNgay(txtNgay.Text)) 
            {

                return;
            }
            if (txtMabs.Text.Trim() == "" || txtChidinh.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ!"), LibMedi.AccessData.Msg);
                txtMabs.Focus();
                return;
            }
            if (bNew)
            {
                d_id = m.getidyymmddhhmiss_stt_computer_khudt(0);
            }
            if (!m.upd_theodoivltl(d_id, s_mabn, d_mavaovien, d_maql, txtNgay.Text,txtMabs.Text.Trim(), txtSieuam.Text.Trim(), txtKeocs.Text.Trim(), txtDien.Text.Trim(), txtTutruong.Text.Trim(), txtApsuat.Text.Trim(), txtKhac.Text.Trim(), i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin!"), LibMedi.AccessData.Msg);
                return;
            }
            load_data();
            cmbNgay.SelectedIndex = 0;
            ena_object(false);
        }

        private void txtMabs_Validated(object sender, EventArgs e)
        {
            if (txtMabs.Text != "")
            {
                DataRow r = m.getrowbyid(dsBacsi.Tables[0], "ma='" + txtMabs.Text.Trim() + "'");
                if (r != null) txtChidinh.Text = r["hoten"].ToString();
                else txtChidinh.Text = "";
            }
        }

        private void txtChidinh_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtChidinh)
            {
                Filt_tenbs(txtChidinh.Text);

                listBS.BrowseToICD10(txtChidinh, txtMabs, txtSieuam, txtMabs.Location.X, txtMabs.Location.Y + txtMabs.Height - 2, txtMabs.Width + txtChidinh.Width + 2, txtChidinh.Height);

            }	
        }

        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBS.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txtChidinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }	
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(lan.Change_language_MessageText("Bạn có đồng ý xóa thông tin này?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                m.execute_data("delete from "+user+".theodoivltl where id="+d_id);
            }
            load_data();
            if (ds.Tables[0].Rows.Count == 0)
            {
                ena_object(true);
                emp_detail();
            }
            else
            {
                ena_object(false);
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibMedi.AccessData.Msg);
                return;
            }
            DataSet dstmp=new DataSet();
            dstmp.Tables.Add(ds.Tables[0].Clone());
           
            dstmp.Tables[0].Columns.Add("hoten");
            dstmp.Tables[0].Columns["hoten"].DefaultValue = s_hoten;
            dstmp.Tables[0].Columns.Add("tuoi");
            dstmp.Tables[0].Columns["tuoi"].DefaultValue = s_tuoi;
            dstmp.Tables[0].Columns.Add("gioi");
            dstmp.Tables[0].Columns["gioi"].DefaultValue = s_phai;
            dstmp.Tables[0].Columns.Add("diachi");
            dstmp.Tables[0].Columns["diachi"].DefaultValue = s_diachi;
            dstmp.Tables[0].Columns.Add("dienthoai");
            dstmp.Tables[0].Columns["dienthoai"].DefaultValue = s_dienthoai;
            dstmp.Tables[0].Columns.Add("doituong");
            dstmp.Tables[0].Columns["doituong"].DefaultValue = s_doituong;
            dstmp.Tables[0].Columns.Add("bacsi");
            dstmp.Tables[0].Columns["bacsi"].DefaultValue = txtChidinh.Text.Trim();
            dstmp.Tables[0].Columns.Add("chandoan");
            dstmp.Tables[0].Columns["chandoan"].DefaultValue = s_chandoan;
            DataRow r = dstmp.Tables[0].NewRow();
            DataRow r1=m.getrowbyid( ds.Tables[0],"id="+d_id);
            //id,mabn,to_char(ngay,'dd/mm/yyyy hh24:mi') ngay,mabs,sieuam,keodan,dien,tutruong,apsuat,khac

            for (int i = 0; i < r1.Table.Columns.Count; i++)
            {
                r[i] = r1[i];
            }
            dstmp.Tables[0].Rows.Add(r);
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\..\\dataxml")) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                dstmp.WriteXml("..\\..\\dataxml\\rptPhieutheodoivltl.xml", XmlWriteMode.WriteSchema);
            }
            dllReportM.frmReport f = new dllReportM.frmReport(m, dstmp.Tables[0], "rptPhieutheodoivltl.rpt", "", "", "","","","","", "", "", "");
            f.ShowDialog();
            dllReportM.frmReport f1 = new dllReportM.frmReport(m, ds.Tables[0], "rptPhieutheodoivltl1.rpt", "", "", "", "", "", "", "", "", "", "");
            f1.ShowDialog();
        }

    }
}