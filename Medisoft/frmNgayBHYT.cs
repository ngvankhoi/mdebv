using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmNgayBHYT : Form
    {
        private string v_ngayvv = "", v_hoten = "", v_mabn="",v_nam="";
        public string v_Tungay = "", v_Tungay1 = "", v_Tungay2 = "", v_Tungay3 = "", v_Denngay = "";
        private Language lang = new Language();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private bool bSothe_ngay_huong = false, bTungay = false, bDenngay_sothe = false,b_moi=false;
        public frmNgayBHYT(string mabn,string hoten, string ngayvv,string nam,string tungay,string denngay,string sothe)
        {
            InitializeComponent();
            v_mabn = mabn;
            v_hoten = hoten;
            v_ngayvv = ngayvv;
            v_nam = nam;
            if (tungay != "") txtTungay.Text = tungay;
            if (denngay != "") txtDenngay.Text = denngay;
            if (sothe != "") txtsothe.Text = sothe;
            if (tungay == "" && denngay == "" && sothe == "")
                b_moi = true;
        }

        private void txtTungay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTungay1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTungay2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTungay3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtDenngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool kiemTra()
        {
            DateTime dt ;
            IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-CA", true);
            try
            {
                if(txtTungay.Text != "")
                dt = DateTime.ParseExact(txtTungay.Text,"dd/MM/yyyy",theCultureInfo);
            }
            catch 
            { 
                MessageBox.Show(lang.Change_language_MessageText("Ngày không hợp lệ."));
                txtTungay.Focus();
                return false;
            }
            try
            {
                if (txtTungay1.Text != "")
                dt = DateTime.ParseExact(txtTungay1.Text, "dd/MM/yyyy", theCultureInfo);
            }
            catch
            {
                MessageBox.Show(lang.Change_language_MessageText("Ngày không hợp lệ."));
                txtTungay1.Focus();
                return false;
            }
            try
            {
                if (txtTungay2.Text != "")
                dt = DateTime.ParseExact(txtTungay2.Text, "dd/MM/yyyy", theCultureInfo);
            }
            catch
            {
                MessageBox.Show(lang.Change_language_MessageText("Ngày không hợp lệ."));
                txtTungay2.Focus();
                return false;
            }
            try
            {
                if (txtTungay3.Text != "")
                dt = DateTime.ParseExact(txtTungay3.Text, "dd/MM/yyyy", theCultureInfo);
            }
            catch
            {
                MessageBox.Show(lang.Change_language_MessageText("Ngày không hợp lệ."));
                txtTungay3.Focus();
                return false;
            }
            try
            {
                if (txtDenngay.Text != "")
                dt = DateTime.ParseExact(txtDenngay.Text, "dd/MM/yyyy", theCultureInfo);
            }
            catch
            {
                MessageBox.Show(lang.Change_language_MessageText("Ngày không hợp lệ."));
                txtDenngay.Focus();
                return false;
            }
            return true;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (kiemTra())
            {
                v_Tungay = txtTungay.Text;
                v_Denngay = txtDenngay.Text;
                v_Tungay1 = txtTungay1.Text;
                v_Tungay2 = txtTungay2.Text;
                v_Tungay3 = txtTungay3.Text;
                this.Close();
            }
        }

        private void frmNgayBHYT_Load(object sender, EventArgs e)
        {
            txtmabn.Text = v_mabn;
            txthoten.Text = v_hoten;
            bTungay = m.bBHYT_tungay;
            bDenngay_sothe = m.bDenngay_sothe;
            bSothe_ngay_huong = m.bSothe_ngay_huong;
            if(!b_moi)load_bhyt();
        }
        private void load_bhyt()
        {
            string so = m.sothe(1);
            string sql = "";
            if (int.Parse(so.Substring(0, 2)) > 0 && v_ngayvv != "")
            {
                if (so.Substring(2, 1) == "1" && bDenngay_sothe)
                    sql = "select * from xxx.bhyt where mabn='" + v_mabn + "' and denngay>=to_timestamp('" + v_ngayvv + "','" + m.f_ngay + "') order by maql desc";
                else
                    sql = "select * from xxx.bhyt where mabn='" + v_mabn + "' order by maql desc";
                DataSet lds = m.get_data_nam_dec(v_nam, sql);
                if (lds != null && lds.Tables.Count > 0)
                {
                    foreach (DataRow r in lds.Tables[0].Rows)
                    {
                        txtsothe.Text = r["sothe"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            txtTungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            txtDenngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                txtTungay1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                txtTungay2.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                txtTungay3.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        break;
                    }
                }
                if (txtsothe.Text == "")
                {
                    if (so.Substring(2, 1) == "1" && bDenngay_sothe)
                        sql = "select * from " + m.user + ".bhyt where mabn='" + v_mabn + "' and denngay>=to_timestamp('" + v_ngayvv + "','" + m.f_ngay + "')" + " order by maql desc";
                    else
                        sql = "select * from " + m.user + ".bhyt where mabn='" + v_mabn + "' order by maql desc";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    {
                        txtsothe.Text = r["sothe"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            txtTungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            txtDenngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                txtTungay1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                txtTungay2.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                txtTungay3.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        break;
                    }
                }
                
            }
            else
            {
                txtTungay1.Text = txtTungay2.Text = txtTungay3.Text = txtsothe.Text = v_Denngay = v_Tungay = "";
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            v_Tungay = "";
            v_Denngay = "";
            v_Tungay1 = "";
            v_Tungay2 = "";
            v_Tungay3 = "";
            this.Close();
        }

    }
}