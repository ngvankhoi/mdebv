using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmtksocavung : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string sql, user,s_cls,stime;
        private AccessData m;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public frmtksocavung(AccessData acc,string cls)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_cls = cls;
        }

        private void frmtksocavung_Load(object sender, EventArgs e)
        {
            user = m.user;stime = "'" + m.f_ngay + "'";
            ds.ReadXml("..//..//..//xml//m_socamay.xml");
            sql = "select * from " + user + ".cls_loai";
            if (s_cls != "") sql += " where id in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
            sql += " order by id";
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";
            loai.DataSource = m.get_data(sql).Tables[0];
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;

            may.DisplayMember = "TEN";
            may.ValueMember = "ID";

            load_loai();
        }

        private void tu_Validated(object sender, EventArgs e)
        {
            if (tu.Text == "")
            {
                den.Text = "";
                return;
            }
            tu.Text = tu.Text.Trim();
            if (tu.Text.Length == 6) tu.Text = tu.Text + DateTime.Now.Year.ToString();
            if (!m.bNgay(tu.Text))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
                tu.Focus();
                return;
            }
            tu.Text = m.Ktngaygio(tu.Text, 10);
            if (den.Text == "") den.Text = tu.Text;
        }

        private void den_Validated(object sender, EventArgs e)
        {
            if (den.Text == "")
            {
                tu.Text = "";
                return;
            }
            den.Text = den.Text.Trim();
            if (den.Text.Length == 6) den.Text = den.Text + DateTime.Now.Year.ToString();
            if (!m.bNgay(den.Text))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
                den.Focus();
                return;
            }
            den.Text = m.Ktngaygio(den.Text, 10);
            if (tu.Text == "")
            {
                tu.Focus();
                return;
            }
            if (!m.bNgay(den.Text, tu.Text))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"), LibMedi.AccessData.Msg);
                den.Focus();
                return;
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            load_grid();
        }

        private void load_grid()
        {
            if (tu.Text == "" || den.Text == "")
            {
                if (tu.Text == "") tu.Focus();
                else den.Focus();
                return;
            }
            ds.Clear();
            sql = "select a.idvung,count(*) as so ";
            sql += " from xxx.cls_ketqua a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql += " inner join " + user + ".cls_loai c on a.loai=c.id ";
            sql += " inner join " + user + ".cls_may d on a.idmay=d.id ";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (loai.SelectedIndex != -1) sql += " and a.loai=" + int.Parse(loai.SelectedValue.ToString());
            if (may.SelectedIndex != -1) sql += " and a.idmay=" + int.Parse(may.SelectedValue.ToString());
            sql += " group by a.idvung";
            DataRow r1,r2,r3;
            DataRow [] dr;
            foreach(DataRow r in m.get_data_mmyy(sql, tu.Text, den.Text, false).Tables[0].Select("true","idvung"))
            {
                r1 = m.getrowbyid(ds.Tables[0], "id=" + int.Parse(r["idvung"].ToString()));
                if (r1 == null)
                {
                    r2 = ds.Tables[0].NewRow();
                    r2["id"] = r["idvung"].ToString();
                    r3 = m.getrowbyid(dt, "id=" + int.Parse(r["idvung"].ToString()));
                    if (r3 != null) r2["ten"] = r3["ten"].ToString();
                    r2["so"] = r["so"].ToString();
                    ds.Tables[0].Rows.Add(r2);
                }
                else
                {
                    dr = ds.Tables[0].Select("id=" + int.Parse(r["idvung"].ToString()));
                    if (dr.Length > 0) dr[0]["so"] = decimal.Parse(dr[0]["so"].ToString()) + decimal.Parse(r["so"].ToString());
                }
            }
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            else
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds,"rpttksocavung.rpt" , (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, loai.Text, may.Text,"","", "");
                f.ShowDialog();
            }
        }

        private void loai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == loai) load_loai();
        }

        private void load_loai()
        {
            if (loai.SelectedIndex==-1) return;
            may.DataSource = m.get_data("select * from " + user + ".cls_may where loai=" + int.Parse(loai.SelectedValue.ToString()) + " order by id").Tables[0];
            dt = m.get_data("select a.*,b.noidung from " + user + ".cls_noidung a left join " + user + ".cls_mota b on a.id=b.id where a.loai=" + int.Parse(loai.SelectedValue.ToString()) + " order by a.ma").Tables[0];
            may.SelectedIndex = -1;
        }
    }
}