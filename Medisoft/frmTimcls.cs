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
    public partial class frmTimcls : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string sql, user,s_cls,stime;
        private bool be = false;
        private AccessData m;
        private DataSet ds = new DataSet();
        private DataTable dtloai = new DataTable();
        public int i_loai=0;
        public string mabn="", ngay="";
        public frmTimcls(AccessData acc,string cls)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_cls = cls;
        }

        private void namsinh_Validated(object sender, EventArgs e)
        {
            if (namsinh.Text == "") return;
            if (namsinh.Text.Length < 4) namsinh.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text));
        }

        private void frmTimcls_Load(object sender, EventArgs e)
        {
            user = m.user;stime = "'" + m.f_ngay + "'";
            sql = "select * from " + user + ".cls_loai";
            if (s_cls != "") sql += " where id in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
            sql += " order by id";
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";
            loai.DataSource = m.get_data(sql).Tables[0];
            if (loai.Items.Count == 1)
            {
                loai.SelectedIndex = 0;
                loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            else loai.SelectedIndex = -1;
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;
            sql = "select ma,ten,id from " + user + ".cls_phanloai ";
            if (loai.SelectedIndex != -1) sql += " where loai=" + int.Parse(loai.SelectedValue.ToString());
            sql+=" order by ma";
            dtloai = m.get_data(sql).Tables[0];
            listLoai.DataSource = dtloai;
            listLoai.DisplayMember = "TEN";
            listLoai.ValueMember = "MA";
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
            if ((tu.Text == "" && den.Text != "") || (tu.Text != "" && den.Text == ""))
            {
                if (tu.Text == "") tu.Focus();
                else den.Focus();
                return;
            }
            sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.loai,c.ten as tenloai,a.idcls,a.mabn,b.hoten,b.namsinh,trim(b.sonha)||' '||trim(b.thon)||' '||trim(i.tenpxa)||' '||trim(h.tenquan)||' '||g.tentt as diachi,";
            sql += "b.cholam,d.ten as may,e.ten as vung,f.hoten as tenbs,j.ten as pl1,k.ten as pl2 ";
            sql += " from xxx.cls_ketqua a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql += " inner join " + user + ".cls_loai c on a.loai=c.id ";
            sql += " inner join " + user + ".cls_may d on a.idmay=d.id ";
            sql += " inner join " + user + ".cls_noidung e on a.idvung=e.id ";
            sql += " left join " + user + ".dmbs f on a.mabs=f.ma ";
            sql += " inner join " + user + ".btdtt g on b.matt=g.matt ";
            sql += " inner join " + user + ".btdquan h on b.maqu=h.maqu ";
            sql += " inner join " + user + ".btdpxa i on b.maphuongxa=i.maphuongxa ";
            sql += " left join " + user + ".cls_phanloai j on a.idloai=j.id ";
            sql += " left join " + user + ".cls_phanloai k on a.idvungdg=k.id ";
            sql += " where a.id>0";
            if (tu.Text != "" && den.Text != "") sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (loai.SelectedIndex != -1) sql += " and a.loai=" + int.Parse(loai.SelectedValue.ToString());
            if (hoten.Text != "") sql += " and b.hotenkdau like '%" + m.Hoten_khongdau(hoten.Text) + "%'";
            if (idcls.Text != "") sql += " and a.idcls='" + idcls.Text + "'";
            if (namsinh.Text != "") sql += " and b.namsinh='" + namsinh.Text + "'";
            if (maloai.Text != "")
            {
                DataRow r = m.getrowbyid(dtloai, "ma='" + maloai.Text + "'");
                if (r != null) sql += " and (a.idloai=" + decimal.Parse(r["id"].ToString()) + " or a.idvungdg=" + decimal.Parse(r["id"].ToString()) + ")";
            }
            sql += " order by a.loai,a.idcls";
            if (idcls.Text.Trim().Length == 9) ds = m.get_data_mmyy(sql, idcls.Text.Substring(4, 2) + "/" + idcls.Text.Substring(2, 2) + "/20" + idcls.Text.Substring(0, 2), idcls.Text.Substring(4, 2) + "/" + idcls.Text.Substring(2, 2) + "/20" + idcls.Text.Substring(0, 2), false);
            else if (tu.Text == "" && den.Text == "")
            {
                string nam = "";
                foreach (DataRow r in m.get_data("select mmyy from " + user + ".table order by substr(mmyy,3,2),substr(mmyy,1,2)").Tables[0].Rows)
                    nam += r["mmyy"].ToString().Trim() + "+";
                ds = m.get_data_nam(nam, sql);
            }
            else ds = m.get_data_mmyy(sql, tu.Text, den.Text, false);
            dataGrid1.DataSource = ds.Tables[0];
            if (!be) AddGridTableStyle();
            be = true;
            butChon.Enabled = ds.Tables[0].Rows.Count > 0;
            butIn.Enabled = butChon.Enabled;
        }

        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 65;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenloai";
            TextCol.HeaderText = "Loại";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "idcls";
            TextCol.HeaderText = "ID CLS";
            TextCol.Width = 65;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mabn";
            TextCol.HeaderText = "Mã BN";
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Họ và tên";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "namsinh";
            TextCol.HeaderText = "NS";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "may";
            TextCol.HeaderText = "Máy";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "vung";
            TextCol.HeaderText = "Vùng";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenbs";
            TextCol.HeaderText = "Bác sỹ";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "pl1";
            TextCol.HeaderText = "Phân loại bệnh tật";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "pl2";
            TextCol.HeaderText = "Phân loại bệnh tật";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "diachi";
            TextCol.HeaderText = "Địa chỉ";
            TextCol.Width = 400;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "cholam";
            TextCol.HeaderText = "Điện thoại";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void loai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                sql = "select ma,ten,id from " + user + ".cls_phanloai ";
                if (loai.SelectedIndex != -1) sql += " where loai=" + int.Parse(loai.SelectedValue.ToString());
                sql += " order by ma";
                dtloai = m.get_data(sql).Tables[0];
                listLoai.DataSource = dtloai;
                SendKeys.Send("{Tab}");
            }
        }

        private void butChon_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                ngay = dataGrid1[i, 0].ToString();
                mabn = dataGrid1[i, 3].ToString();
                i_loai = int.Parse(dataGrid1[i, 12].ToString());
                m.close();this.Close();
            }
            catch { }
        }

        private void maloai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listLoai.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listLoai.Visible)
                {
                    listLoai.Focus();
                    SendKeys.Send("{Up}");
                }
                else SendKeys.Send("{Tab}");
            }
        }

        private void maloai_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == maloai)
            {
                Filt_loai(maloai.Text);
                listLoai.BrowseToPTTT(maloai, maloai, butFind, idcls.Location.X, maloai.Location.Y + maloai.Height, maloai.Width+namsinh.Width+label11.Width+hoten.Width+idcls.Width+label4.Width, maloai.Height);
            }
        }

        private void Filt_loai(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listLoai.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten LIKE '%" + ten.Trim() + "%' or ma like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void frmTimcls_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    if (butChon.Enabled) butChon_Click(sender, e);
                    break;
                case Keys.F9:
                    if (butIn.Enabled) butIn_Click(sender, e);
                    break;
                case Keys.F10:
                    butExit_Click(sender, e);
                    break;
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            else
            {
                string title = "";
                if (tu.Text != "" && den.Text != "") title = (tu.Text == den.Text) ? "Ngày :" + tu.Text : "Từ ngày :" + tu.Text + " đến " + den.Text;
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds, "rptTimcls.rpt", title, loai.Text, idcls.Text, hoten.Text, namsinh.Text, maloai.Text);
                f.ShowDialog();
            }
        }

        private void butList1_Click(object sender, EventArgs e)
        {
            if (loai.SelectedIndex == -1)
            {
                loai.Focus();
                return;
            }
            frmLphanloai f = new frmLphanloai(m, int.Parse(loai.SelectedValue.ToString()));
            f.ShowDialog();
            if (f.ret != "") maloai.Text= f.ret;
        }
    }
}