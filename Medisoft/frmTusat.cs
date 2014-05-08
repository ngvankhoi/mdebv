using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmTusat : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        //private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private string user = "";
        private int i_userid;
        private decimal l_maql, l_mavaovien;
        public frmTusat(decimal maql, string s_mabn, string s_ngay, string s_hoten, string s_namsinh, string s_mann, string s_diachi, int userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            if (m.bBogo) tv.GanBogo(this, textBox111);
            mabn.Text = s_mabn;
            hoten.Text = s_hoten;
            namsinh.Text = s_namsinh;
            mann.Text = s_mann;
            diachi.Text = s_diachi;
            l_maql = maql;            
            ngay.Text = s_ngay.Substring(0, 10);
            gio.Text = s_ngay.Substring(11);
            i_userid = userid;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void frmTusat_Load(object sender, EventArgs e)
        {
            user = m.user;
            load_dm();
        }

        private void load_dm()
        {
            nguyennhan.DisplayMember = "TEN";
            nguyennhan.ValueMember = "ID";
            nguyennhan.DataSource = m.get_data("select * from "+user+".tusatnguyennhan order by id").Tables[0];

            hinhthuc.DisplayMember = "TEN";
            hinhthuc.ValueMember = "ID";
            hinhthuc.DataSource = m.get_data("select * from " + user + ".tusathinhthuc order by id").Tables[0];
            
            tinhtrang.DisplayMember = "TEN";
            tinhtrang.ValueMember = "ID";
            tinhtrang.DataSource = m.get_data("select * from " + user + ".tusattinhtrang order by id").Tables[0];
		}

        private void ngay_Validated(object sender, EventArgs e)
        {
            if (ngay.Text == "")
            {
                ngay.Focus();
                return;
            }
            ngay.Text = ngay.Text.Trim();
            if (ngay.Text.Length == 6) ngay.Text = ngay.Text + DateTime.Now.Year.ToString();
            if (ngay.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"));
                ngay.Focus();
                return;
            }
            if (!m.bNgay(ngay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngay.Focus();
                return;
            }
        }

        private void gio_Validated(object sender, EventArgs e)
        {
            string sgio = (gio.Text.Trim() == "") ? "00:00" : gio.Text.Trim();
            gio.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(gio.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                gio.Focus();
                return;
            }
            SendKeys.Send("{F4}");
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (!kiemtra()) return;
            int itable = m.tableid("", "tusat");
            if (m.get_data("select * from " + user +".tusat where maql=" + l_maql).Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + ngay.Text + " " + gio.Text + "^" + nguyennhan.SelectedIndex.ToString() + "^" + hinhthuc.SelectedIndex.ToString() + "^" + tinhtrang.SelectedIndex.ToString() + "^" + ghichu.Text);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            m.upd_tusat(mabn.Text.Trim(), l_mavaovien, l_maql, ngay.Text + " " + gio.Text, decimal.Parse(nguyennhan.SelectedValue.ToString()), decimal.Parse(hinhthuc.SelectedValue.ToString()), decimal.Parse(tinhtrang.SelectedValue.ToString()), ghichu.Text.Trim(),i_userid);
            m.close();this.Close();
        }
        private bool kiemtra()
        {
            string sql = "select * from " + user +".tusat where mabn='" + mabn.Text + "'  and maql=" + l_maql;
            if (m.get_data(sql).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh ") + hoten.Text + lan.Change_language_MessageText(" tự sát ngày ") + ngay.Text + " " + gio.Text + "\n"+lan.Change_language_MessageText("Đã nhập !"), LibMedi.AccessData.Msg);
                return false;
            }
            return true;
        }
    }
}