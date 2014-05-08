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
    public partial class frmtkcamay : Form
    {
        Language lan = new Language();
        private string sql, user,s_cls,stime;
        private AccessData m;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public frmtkcamay(AccessData acc,string cls)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_cls = cls;
        }

        private void frmtkcamay_Load(object sender, EventArgs e)
        {
            user = m.user;stime = "'" + m.f_ngay + "'";

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
            cmbma.DisplayMember = "TEN";
            cmbma.ValueMember = "ID";
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
                MessageBox.Show("Ngày không hợp lệ !",LibMedi.AccessData.Msg);
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
                MessageBox.Show("Ngày không hợp lệ !", LibMedi.AccessData.Msg);
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
                MessageBox.Show("Đến ngày không được nhỏ hơn từ ngày !", LibMedi.AccessData.Msg);
                den.Focus();
                return;
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            s_ma = ""; s_vung = "";
            for(int i=0;i<cmbma.Items.Count;i++)
                if (cmbma.GetItemChecked(i))
                {
                    s_ma += dt.Rows[i]["id"].ToString().Trim() + ",";
                    s_vung += dt.Rows[i]["ten"].ToString().Trim() + ",";
                }
            sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.loai,c.ten as tenloai,a.idcls,a.mabn,b.hoten,b.namsinh,trim(b.sonha)||' '||trim(b.thon)||' '||trim(i.tenpxa)||' '||trim(h.tenquan)||' '||g.tentt as diachi,";
            sql += "b.cholam,d.ten as may,e.ten as vung,f.hoten as tenbs,a.cp,a.lt,k.doituong ";
            sql += " from xxx.cls_ketqua a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql += " inner join " + user + ".cls_loai c on a.loai=c.id ";
            sql += " inner join " + user + ".cls_may d on a.idmay=d.id ";
            sql += " inner join " + user + ".cls_noidung e on a.idvung=e.id ";
            sql += " left join " + user + ".dmbs f on a.mabs=f.ma ";
            sql += " inner join " + user + ".btdtt g on b.matt=g.matt ";
            sql += " inner join " + user + ".btdquan h on b.maqu=h.maqu ";
            sql += " inner join " + user + ".btdpxa i on b.maphuongxa=i.maphuongxa ";
            sql += " left join xxx.cls_motact j on a.id=j.id ";
            sql += " left join " + user + ".doituong k on a.madoituong=k.madoituong ";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (loai.SelectedIndex != -1) sql += " and a.loai=" + int.Parse(loai.SelectedValue.ToString());
            if (may.SelectedIndex != -1) sql += " and a.idmay=" + int.Parse(may.SelectedValue.ToString());
            if (s_ma!="") sql += " and a.idvung in ("+s_ma.Substring(0,s_ma.Length-1)+")";
            if (rb1.Checked) sql += " and j.canquang=1";
            else if (rb2.Checked) sql += " and (j.canquang=0 or j.canquang is null)";
            if (rThuphi.Checked) 
            {
                if (s_trasau!="") sql += " and a.cp>0 and a.madoituong not in (" + s_trasau.Substring(0, s_trasau.Length - 1) + ")";
                if (s_mien != "") sql += " and a.madoituong not in (" + s_mien.Substring(0, s_mien.Length - 1) + ")";
            }
            else if (rTrasau.Checked && s_trasau != "") sql += " and (a.cp<0 or a.madoituong in (" + s_trasau.Substring(0, s_trasau.Length - 1) + "))";
            else if (rMien.Checked && s_mien != "") sql += " and a.madoituong in (" + s_mien.Substring(0, s_mien.Length - 1) + ")";
            if (mabs.SelectedIndex != -1) sql += " and a.mabs='" + mabs.SelectedValue.ToString() + "'";
            sql += " order by " + s_order;
            ds = m.get_data_mmyy(sql, tu.Text, den.Text, false);
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show("Không có số liệu !", LibMedi.AccessData.Msg);
            else
            {
                frmReport f = new frmReport(m, ds, s_report, (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, loai.Text, may.Text, s_vung,(mabs.SelectedIndex!=-1)?mabs.Text:"", "");
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
            cmbma.DataSource = dt;
            cmbma.DisplayMember = "TEN";
            cmbma.ValueMember = "ID";
            may.SelectedIndex = -1;
        }
    }
}