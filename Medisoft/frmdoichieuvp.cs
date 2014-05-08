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
    public partial class frmdoichieuvp : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string sql, user, s_cls, stime, s_trasau = "", s_mien = "",s_dongthem="";
        private AccessData m;
        private DataSet dscq = new DataSet();
        private DataSet ds = new DataSet();
        private DataTable dtloai = new DataTable();
        private DataSet dsvp = new DataSet();
        private int songay = 7;
        public frmdoichieuvp(AccessData acc,string cls)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_cls = cls;
        }

        private void frmdoichieuvp_Load(object sender, EventArgs e)
        {
            user = m.user;stime = "'" + m.f_ngay + "'";
            dscq.ReadXml("..//..//..//xml//m_cquang.xml");
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
            s_dongthem = "";
            DataRow r1,r2 = m.getrowbyid(dscq.Tables[0], "mavp<>'' and loai=" + int.Parse(loai.SelectedValue.ToString()));
            s_dongthem = (r2 != null) ? r2["mavp"].ToString().Trim() : "";
            songay = 7;
            string s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(tu.Text).AddDays(-songay)), s_den = m.DateToString("dd/MM/yyyy", m.StringToDate(den.Text).AddDays(songay));

            decimal tcvp = 0;
            sql = "select sum(b.soluong*b.dongia-b.mien-b.thieu-b.tra) as sotien";
            sql += " from xxx.v_vienphill a inner join xxx.v_vienphict b on a.id=b.id ";
            sql += " inner join " + user + ".v_giavp c on b.mavp=c.id ";
            sql += " inner join " + user + ".v_loaivp d on c.id_loai=d.id ";
            sql += " inner join " + user + ".v_nhomvp e on d.id_nhom=e.ma ";
            sql += " where b.soluong*b.dongia-b.mien-b.thieu-b.tra>0 ";
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and d.id=" + decimal.Parse(dtloai.Rows[loai.SelectedIndex]["nhomvp"].ToString());
            DataTable temp = m.get_data_mmyy(sql, tu.Text, den.Text, false).Tables[0];
            if (temp.Rows[0]["sotien"].ToString() != "") tcvp = decimal.Parse(temp.Rows[0]["sotien"].ToString());

            sql = "select a.mabn,to_char(a.ngay,'dd/mm/yyyy') as ngay,to_char(a.id) as id,b.mavp,b.soluong*b.dongia-b.mien-b.thieu as sotien,c.hoten as tenuser,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud ";
            sql += " from xxx.v_vienphill a,xxx.v_vienphict b,"+user+".v_dlogin c,"+user+".v_giavp d,"+user+".v_loaivp e ";
            sql += " where a.id=b.id and a.userid=c.id and b.mavp=d.id and d.id_loai=e.id and b.tra=0 and e.id=" + decimal.Parse(dtloai.Rows[loai.SelectedIndex]["nhomvp"].ToString());
            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "'," + stime + ") and to_date('" + s_den + "'," + stime + ")";
            sql += " order by a.mabn,a.ngayud";
            dsvp = m.get_data_mmyy(sql, s_tu, s_den,false);

            sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.mabn,f.hoten,a.idcls,a.idvp,g.hoten as tenbs,";
            sql += "d.ten as may,e.ten as vung,000000000000.00 as vp,a.cp,a.lt,'' as ngayvp,'' as nguoivp,";
            sql += "case when h.canquang is null then 0 else h.canquang end as canquang ";
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
            sql += " order by a.idcls";
            ds=m.get_data_mmyy(sql, tu.Text, den.Text, false);

            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            else
            {
                decimal st = 0;
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    sql = "id='" + r["idvp"].ToString().Trim() + "'";
                    if (s_dongthem != "") sql = " and mavp not in (" + s_dongthem + ")";
                    r1 = m.getrowbyid(dsvp.Tables[0], sql);
                    if (r1 != null)
                    {
                        r["ngayvp"] = r1["ngay"].ToString();
                        r["nguoivp"] = r1["tenuser"].ToString();
                        st = decimal.Parse(r1["sotien"].ToString());
                        r1.Delete();
                        if (s_dongthem != "")
                        {
                            sql = "mabn='" + r["mabn"].ToString() + "' and mavp in (" + s_dongthem + ")";
                            r2 = m.getrowbyid(dsvp.Tables[0], sql);
                            if (r2 != null)
                            {
                                st += decimal.Parse(r2["sotien"].ToString());
                                r2.Delete();
                            }
                        }
                        r["vp"] = st;                       
                    }
                    else
                    {
                        sql = "mabn='" + r["mabn"].ToString() + "' and mavp not in (" + s_dongthem + ")";
                        r1 = m.getrowbyid(dsvp.Tables[0], sql);
                        if (r1 != null)
                        {
                            r["ngayvp"] = r1["ngay"].ToString();
                            r["nguoivp"] = r1["tenuser"].ToString();
                            st = decimal.Parse(r1["sotien"].ToString());
                            r1.Delete();
                            if (s_dongthem != "")
                            {
                                sql = "mabn='" + r["mabn"].ToString() + "' and mavp in (" + s_dongthem + ")";
                                r2 = m.getrowbyid(dsvp.Tables[0],sql);
                                if (r2 != null)
                                {
                                    st += decimal.Parse(r2["sotien"].ToString());
                                    r2.Delete();
                                }
                            }
                            r["vp"] = st;
                        }
                    }
                }
                DataSet tmp;
                if (rb2.Checked)
                {
                    tmp = ds.Copy();
                    ds.Clear();
                    ds.Merge(tmp.Tables[0].Select("cp<>vp","idcls"));
                }
                else if (rb3.Checked)
                {
                    tmp = ds.Copy();
                    ds.Clear();
                    ds.Merge(tmp.Tables[0].Select("substring(ngay,1,10)<>ngayvp", "idcls"));
                }
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds,"rptdoichieuvp.rpt" , (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, loai.Text,tcvp.ToString(),"","", "");
                f.ShowDialog();
            }
        }

        private void loai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
    }
}