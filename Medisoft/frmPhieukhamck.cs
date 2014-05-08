using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmPhieukhamck : Form
    {
        decimal d_maql = 0;
        int i_userid = 0;
        string s_ngay = "",sql="",hoten="",benhvien="",namsinh="",tuoi="",phai="",diachi="",bacsi="";
        Language lan = new Language();
        DataSet ds;
        LibMedi.AccessData m;

        public frmPhieukhamck(LibMedi.AccessData _m, decimal _maql,string _hoten,string _benhvien,string _namsinh,string _tuoi, string _phai, 
                string _diachi,string _bacsi,string _ngay,int _userid)
        {
            InitializeComponent();
            d_maql = _maql;
            m = _m; hoten = _hoten; benhvien = _benhvien; namsinh = _namsinh; tuoi = _tuoi; phai = _phai; diachi = _diachi.Trim().Trim(','); bacsi = _bacsi;
            s_ngay = _ngay;
            i_userid = _userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void frmPhieukhamck_Load(object sender, EventArgs e)
        {
            sql = "select a.mabn,a.ngay,c.tenkp,d.ten chinhanh, b.yeucau,a.chandoan,a.mavaovien ";
            sql += " from " + m.user + m.mmyy(s_ngay) + ".benhanpk a left join " + m.user + ".khamchuyenkhoa b on a.maql=b.maql left join " + m.user + ".btdkp_bv c on a.makp=c.makp left join " + m.user + ".dmchinhanh d on c.chinhanh=d.id ";
            sql += " where a.maql="+d_maql;
            ds = m.get_data(sql);
            txtHoten.Text = hoten;
            txtMabn.Text = ds.Tables[0].Rows[0]["mabn"].ToString();
            txtTuoi.Text = tuoi;
            txtGioitinh.Text = phai;
            txtdiachi.Text = diachi;
            txtYeucau.Text = ds.Tables[0].Rows[0]["yeucau"].ToString();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            //if (!m.upd_khamchuyenkhoa(txtMabn.Text, decimal.Parse(ds.Tables[0].Rows[0]["mavaovien"].ToString()), d_maql,s_ngay, txtYeucau.Text, i_userid))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin!"), LibMedi.AccessData.Msg);
            //}
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            butLuu_Click(null, null);
            if(chkXml.Checked) ds.WriteXml("..//dataxml//rptPhieukhamck.xml", XmlWriteMode.WriteSchema);
            dllReportM.frmReport f = new dllReportM.frmReport(m, ds.Tables[0], "rptPhieukhamck.rpt",benhvien,hoten,namsinh,tuoi,phai,diachi,s_ngay,bacsi, txtYeucau.Text, "");
            f.ShowDialog();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}