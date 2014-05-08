using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmPhieusanglocBLGD : Form
    {
        string sql = "", s_mabn = "", s_lydokham = "", s_gioitinh = "", ngay, s_hoten = "", s_msg = "",s_khoa="",s_thon="",s_matt="",s_maphuong="",s_maqu="";
        LibMedi.AccessData m;
        Language lan = new Language();
        DataTable dt = new DataTable();
        DataTable dttam = new DataTable();
        Decimal d_mavaovien=0, d_maql = 0;
        int i_userid = 0,i_tuoi;

        public frmPhieusanglocBLGD(LibMedi.AccessData _m,string _mabn,string _hoten,decimal _mavaovien,decimal _maql,int _tuoi,string _lydokham, string _gioitinh, string _ngay,string _khoa,int _userid,string _thon,string _matt,string _maphuong,string _maqu)
        {
            InitializeComponent();
            m = _m;
            s_thon = _thon; s_matt = _matt; s_maphuong = _maphuong; s_maqu = _maqu;
            d_maql = _maql;
            d_mavaovien = _mavaovien;
            s_mabn = _mabn;
            s_hoten = _hoten;
            s_lydokham = _lydokham;
            i_tuoi = _tuoi;
            s_gioitinh = _gioitinh;
            ngay = _ngay;
            i_userid = _userid;
            s_khoa = _khoa;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            decimal stt;
            sql = "select sott,baolucgiadinh from "+m.user+".blgd_sangloc where mavaovien="+d_mavaovien;
            dttam = m.get_data(sql).Tables[0];
            if (dttam.Rows.Count == 0)
            {
                stt = m.sttSangLocBLGD;
            }
            else
            {
                stt = decimal.Parse(dttam.Rows[0]["sott"].ToString());
            }
            if (!m.upd_blgd_sangloc(stt, s_mabn, d_mavaovien, d_maql, ngay, radioCo.Checked ? 1 : 0, chkBaoluc.Checked ? 1 : 0, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được phiếu sàng lọc nạn nhân bạo lực gia đình!"), s_msg);
                return;
            }
            if (chkBaoluc.Checked)
            {
                m.upd_tainantt(s_mabn, decimal.Parse(d_maql.ToString()), ngay, 1, -1, 8, 0, 3, 7, s_thon, s_matt, s_maqu, s_maphuong, "", "", "", "", "");
                butThongtinblgd_Click(null, null);
            }
            butIn.Focus();
            //MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công!"), s_msg);
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            sql = "select mavaovien from " + m.user + ".blgd_sangloc where mavaovien="+d_mavaovien ;
            if (m.get_data(sql).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Phiếu sàng lọc nạn nhân bạo lực gia đình chưa lưu, không thể xóa!"), s_msg);
                return;
            }
            if (MessageBox.Show(lan.Change_language_MessageText("Bạn muốn xóa Phiếu sàng lọc nạn nhân bạo lực gia đình này?"), s_msg, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                if (!m.execute_data("delete from " + m.user + ".blgd_sangloc where mabn='" + s_mabn + "' and mavaovien=" + d_mavaovien))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Xóa không thành công!"), s_msg);
                    return;
                }
                MessageBox.Show(lan.Change_language_MessageText("Xóa thành công!"), s_msg);
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            DataSet dssangloc = new DataSet();
            sql = "select mabn,ngay,tthonnhan,baolucgiadinh from " + m.user + ".blgd_sangloc where mavaovien=" + d_mavaovien;
            dssangloc=m.get_data(sql);
            if (dssangloc.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Phiếu sàng lọc nạn nhân bạo lực gia đình chưa lưu!"), s_msg);
                return;
            }
            //dssangloc.WriteXml("..\\xml\\rptPhieusanglocBLGD.xml");
            dllReportM.frmReport f = new dllReportM.frmReport(m, dssangloc, "rptPhieusanglocBLGD.rpt", i_tuoi.ToString(), s_gioitinh, s_hoten, txtKhoa.Text, s_lydokham, "");
            f.ShowDialog();
        }

        private void frmPhieusanglocBLGD_Load(object sender, EventArgs e)
        {
            txtMabn.Text = s_mabn;
            txtMakp.Text = s_khoa;
            txtNgay.Text = ngay;
            txtTuoi.Text = i_tuoi.ToString();
            txtLydokham.Text = s_lydokham;
            txtHoten.Text = s_hoten;
            txtGioitinh.Text = s_gioitinh;
            sql = "select tenkp from "+m.user+".btdkp_bv where makp ='"+s_khoa+"'";
            txtKhoa.Text = m.get_data(sql).Tables[0].Rows[0][0].ToString();
            sql = "select tthonnhan,baolucgiadinh from "+m.user+".blgd_sangloc where mavaovien="+d_mavaovien;
            dt = m.get_data(sql).Tables[0];
            if (dt.Rows.Count != 0)
            {
                radioCo.Checked = dt.Rows[0]["tthonnhan"].ToString() == "1" ? true : false;
                chkBaoluc.Checked = dt.Rows[0]["baolucgiadinh"].ToString() == "1" ? true : false;
            }
        }

        private void butThongtinblgd_Click(object sender, EventArgs e)
        {
            //butLuu_Click(null, null);
            sql = "select sott,baolucgiadinh from " + m.user + ".blgd_sangloc where mavaovien=" + d_mavaovien;
            dttam = m.get_data(sql).Tables[0];
            if (dttam.Rows.Count > 0)
            {
                if (dttam.Rows[0]["baolucgiadinh"].ToString().Trim() == "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này không bị bạo lực gia đình!"), s_msg);
                    return;
                }
                frmThongtinBLGD f = new frmThongtinBLGD(m, txtMabn.Text, d_mavaovien, d_maql, m.mmyy(ngay), i_userid, ngay);
                f.ShowInTaskbar = false;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân chưa lập phiếu sàng lọc Bạo lực gia đình!"), s_msg);
                return;
            }
        }

        private void chkBaoluc_CheckedChanged(object sender, EventArgs e)
        {
            butThongtinblgd.Enabled = chkBaoluc.Checked;
        }
    }
}