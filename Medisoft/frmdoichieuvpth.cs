using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

namespace Medisoft
{
    public partial class frmdoichieuvpth : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string sql, user, s_cls, stime, s_trasau = "", s_mien = "";
        private AccessData m;
        private DataSet ds = new DataSet();
        private System.Data.DataTable dtloai = new System.Data.DataTable();
        private DataSet dsvp = new DataSet();
        private int songay = 7;
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        public frmdoichieuvpth(AccessData acc,string cls)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_cls = cls;
        }

        private void frmdoichieuvpth_Load(object sender, EventArgs e)
        {
            user = m.user;stime = "'" + m.f_ngay + "'";
            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                if (r["trasau"].ToString().Trim() == "1") s_trasau += r["madoituong"].ToString() + ",";
                else if (r["madoituong"].ToString().Trim() == "3") s_mien += r["madoituong"].ToString() + ",";
            }
            sql = "select * from " + user + ".cls_loai";
            if (s_cls != "") sql += " where id in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
            sql += " order by id";
            dtloai = m.get_data(sql).Tables[0];
            loai.DataSource = dtloai;
            loai.DisplayMember = "ten";
            loai.ValueMember = "id";
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;
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
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
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
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
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
                MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"), LibMedi.AccessData.Msg);
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
            if (loai.SelectedIndex == -1)
            {
                loai.Focus();
                return;
            }
            if (tu.Text == "" || den.Text == "")
            {
                if (tu.Text == "") tu.Focus();
                else den.Focus();
                return;
            }
            ds.Clear();
            songay = 7;

            sql = "select a.mabn,a.hoten,sum(b.soluong*b.dongia-b.mien-b.thieu-b.tra) as sotien";
            sql += " from xxx.v_vienphill a inner join xxx.v_vienphict b on a.id=b.id ";
            sql += " inner join " + user + ".v_giavp c on b.mavp=c.id ";
            sql += " inner join " + user + ".v_loaivp d on c.id_loai=d.id ";
            sql += " inner join " + user + ".v_nhomvp e on d.id_nhom=e.ma ";
            sql += " where b.soluong*b.dongia-b.mien-b.thieu-b.tra>0 ";
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and d.id=" + decimal.Parse(dtloai.Rows[loai.SelectedIndex]["nhomvp"].ToString());
            sql += " group by a.mabn,a.hoten";
            sql += " order by a.mabn,a.hoten";
            dsvp = m.get_data_mmyy(sql, tu.Text, den.Text, false);

            sql = "select a.mabn,f.hoten,sum(a.lt) as lt,sum(a.cp) as cp,000000000000.00 as vp";
            sql += " from xxx.cls_ketqua a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql += " inner join " + user + ".cls_loai c on a.loai=c.id ";
            sql += " left join " + user + ".cls_may d on a.idmay=d.id";
            sql += " left join " + user + ".cls_noidung e on a.idvung=e.id";
            sql += " left join " + user + ".btdbn f on a.mabn=f.mabn";
            sql += " left join " + user + ".dmbs g on a.mabs=g.ma";
            sql += " left join xxx.cls_motact h on a.id=h.id ";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (loai.SelectedIndex != -1) sql += " and a.loai=" + int.Parse(loai.SelectedValue.ToString());
            if (s_trasau != "") sql += " and a.madoituong not in (" + s_trasau.Substring(0, s_trasau.Length - 1) + ")";
            if (s_mien != "") sql += " and a.madoituong not in (" + s_mien.Substring(0, s_mien.Length - 1) + ")";
            sql += " group by a.mabn,f.hoten";
            sql += " order by a.mabn,f.hoten";
            DataSet dstmp=m.get_data_mmyy(sql, tu.Text, den.Text, false);
            ds = dstmp.Copy();
            ds.Clear();
            if (dstmp.Tables[0].Rows.Count == 0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            else
            {
                DataRow r1,r2;
                DataRow[] dr;
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    r1 = m.getrowbyid(ds.Tables[0], "mabn='" + r["mabn"].ToString() + "'");
                    if (r1 == null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["mabn"] = r["mabn"].ToString();
                        r2["hoten"] = r["hoten"].ToString();
                        r2["cp"] = r["cp"].ToString();
                        r2["lt"] = r["lt"].ToString();
                        r2["vp"] = 0;
                        foreach (DataRow r3 in dsvp.Tables[0].Select("mabn='" + r["mabn"].ToString() + "'"))
                            r2["vp"] = decimal.Parse(r2["vp"].ToString()) + decimal.Parse(r3["sotien"].ToString());
                        ds.Tables[0].Rows.Add(r2);
                    }
                    else
                    {
                        dr = ds.Tables[0].Select("mabn='" + r["mabn"].ToString() + "'");
                        if (dr.Length > 0)
                        {
                            dr[0]["cp"] = decimal.Parse(dr[0]["cp"].ToString()) + decimal.Parse(r["cp"].ToString());
                            dr[0]["lt"] = decimal.Parse(dr[0]["lt"].ToString()) + decimal.Parse(r["lt"].ToString());
                        }
                    }
                }
                foreach (DataRow r in dsvp.Tables[0].Rows)
                {
                    r1 = m.getrowbyid(ds.Tables[0], "mabn='" + r["mabn"].ToString() + "'");
                    if (r1 == null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["mabn"] = r["mabn"].ToString();
                        r2["hoten"] = r["hoten"].ToString();
                        r2["cp"] = 0;
                        r2["lt"] = 0;
                        r2["vp"] = 0;
                        foreach (DataRow r3 in dsvp.Tables[0].Select("mabn='" + r["mabn"].ToString() + "'"))
                            r2["vp"] = decimal.Parse(r2["vp"].ToString()) + decimal.Parse(r3["sotien"].ToString());
                        ds.Tables[0].Rows.Add(r2);
                    }
                }

                if (rb2.Checked)
                {
                    dstmp.Clear();
                    dstmp = ds.Copy();
                    ds.Clear();
                    ds.Merge(dstmp.Tables[0].Select("cp<>vp", "mabn"));
                }

                m.check_process_Excel();
                string tenfile = m.Export_Excel(ds, "doichieu");
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;
                oxl.ActiveWindow.DisplayZeros = false;
                for (int i = 0; i < 5; i++) osheet.Cells[1, i + 1] = get_ten(i);
                int socot = ds.Tables[0].Rows.Count + 1;
                osheet.get_Range(m.getIndex(0) + "1", m.getIndex(ds.Tables[0].Columns.Count - 1) + socot.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                oxl.Visible = true;
            }
        }

        private string get_ten(int i)
        {
            string[] map ={ "Mã BN", "Họ và tên", "Lý thuyết", "Chí phí", "Viện phí" };
            return map[i];
        }

        private void loai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
    }
}