using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmYeucauhoadon : Form
    {
       string s_mabn = "",ngay="",sql="",s_tenbn="",s_computer="",s_msg="",s_diachi="",s_msthue="";
        decimal d_mavaovien = 0;
        int i_userid = 0,i_computer=0;
        DataSet ds;
        DataTable dt = new DataTable();
        LibMedi.AccessData m;
        Language lan = new Language();

        public frmYeucauhoadon(LibMedi.AccessData _m,string _mabn,string _tenbn,string _diachi,string _msthue,decimal _mavaovien,int _userid)
        {
            InitializeComponent();
            s_mabn = _mabn;
            d_mavaovien = _mavaovien;
            i_userid = _userid;
            s_tenbn = _tenbn;
            s_diachi = _diachi;
            s_msthue = _msthue;
            m = _m;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void frmYeucauhoadon_Load(object sender, EventArgs e)
        {
            s_msg = LibMedi.AccessData.Msg;
            txtMabn.Text=s_mabn;
            txtTenbn.Text=s_tenbn;
            load_data();
            i_computer = m.get_dmcomputer();
        }

        private void load_data()
        {
            
            sql = "select mabn,mavaovien,to_char(ngay,'dd/mm/yyyy') ngay,donvi,dcdonvi,masothue,dcnhan,nguoinhan from " + m.user + ".yeucauhoadon where mabn='" + s_mabn + "' and mavaovien=" + d_mavaovien;
            ds=m.get_data(sql);
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                txtTencty.Text = s_tenbn;
                txtDiachicty.Text = s_diachi;
                txtMsthue.Text = s_msthue;
                txtDiachinhan.Text = s_diachi;
                txtNguoinhan.Text = s_tenbn;
                dateNgayhen.Value = DateTime.Now.AddDays(3);
                return;
            }
            txtTencty.Text = dt.Rows[0]["donvi"].ToString();
            txtDiachicty.Text = dt.Rows[0]["dcdonvi"].ToString();
            txtMsthue.Text = dt.Rows[0]["masothue"].ToString();
            txtDiachinhan.Text = dt.Rows[0]["dcnhan"].ToString();
            txtNguoinhan.Text = dt.Rows[0]["nguoinhan"].ToString();
            ngay = dt.Rows[0]["ngay"].ToString();
            dateNgayhen.Value = new DateTime(int.Parse(ngay.Substring(6, 4)), int.Parse(ngay.Substring(3, 2)), int.Parse(ngay.Substring(0, 2)));
            //dateNgayhen.Value = DateTime.Now.AddDays(3);
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (!m.upd_yeucauhoadon(s_mabn, d_mavaovien, dateNgayhen.Text, txtTencty.Text.Trim(), txtDiachicty.Text.Trim(), txtMsthue.Text.Trim(), txtDiachinhan.Text.Trim(), txtNguoinhan.Text.Trim(), i_userid, i_computer))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin yêu cầu hóa đơn !"), s_msg);
                return;
            }
            MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công!"), s_msg);
            load_data();
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            //ds.WriteXml("..\\xml\\rptYeucauhoadon.xml");
            dllReportM.frmReport f = new dllReportM.frmReport(m,ds,"rptYeucauhoadon.rpt", txtTenbn.Text, "","","","","");
            f.ShowDialog();
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTencty_Enter(object sender, EventArgs e)
        {
            txtTencty.SelectAll();
        }

        private void txtDiachicty_Enter(object sender, EventArgs e)
        {
            txtDiachicty.SelectAll();
        }

        private void txtMsthue_Enter(object sender, EventArgs e)
        {
            txtMsthue.SelectAll();
        }

        private void txtDiachinhan_Enter(object sender, EventArgs e)
        {
            txtDiachinhan.SelectAll();
        }

        private void txtNguoinhan_Enter(object sender, EventArgs e)
        {
            txtNguoinhan.SelectAll();
        }
    }
}