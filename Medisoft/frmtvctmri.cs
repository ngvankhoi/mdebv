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
    public partial class frmtvctmri : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string sql, user,s_cls,stime,s_order,s_trasau="",s_mien="",s_ma="",s_vung="";
        private AccessData m;
        private bool be = true;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public frmtvctmri(AccessData acc,string cls,string order)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_cls = cls; s_order = order;
        }

        private void frmtvctmri_Load(object sender, EventArgs e)
        {
            user = m.user;stime = "'" + m.f_ngay + "'";
            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                if (r["trasau"].ToString().Trim()=="1")  s_trasau += r["madoituong"].ToString() + ",";
                else if (r["madoituong"].ToString().Trim()=="3") s_mien+=r["madoituong"].ToString()+",";
            }
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

            mabs.DataSource = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            mabs.DisplayMember = "hoten";
            mabs.ValueMember = "ma";
            mabs.SelectedIndex = -1;            
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
            sql += "b.cholam,d.ten as may,e.ten as vung,f.hoten as tenbs,abs(a.cp) as cp,a.lt,k.doituong,a.cp as cpt ";
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
                if (s_mien != "") sql += " and a.cp>0 and a.madoituong not in (" + s_mien.Substring(0, s_mien.Length - 1) + ")";
            }
            else if (rTrasau.Checked && s_trasau != "") sql += " and (a.cp<0 or a.madoituong in (" + s_trasau.Substring(0, s_trasau.Length - 1) + "))";
            else if (rMien.Checked && s_mien != "") sql += " and ((a.cp=0 and a.lt>0) or a.madoituong in (" + s_mien.Substring(0, s_mien.Length - 1) + "))";
            if (mabs.SelectedIndex != -1) sql += " and a.mabs='" + mabs.SelectedValue.ToString() + "'";
            if (chkBacsi.Checked) sql += " and a.mabs is null";
            if (chkKetqua.Checked) sql += " and a.ketqua is null";
            sql += " order by " + s_order;
            ds = m.get_data_mmyy(sql, tu.Text, den.Text, false);
            dataGrid1.DataSource = ds.Tables[0];
            if (be)
            {
                AddGridTableStyle();
                lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
                lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
                be = false;
            }
            lblso.Text = "Tổng số :" + ds.Tables[0].Rows.Count.ToString();
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
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "idcls";
            TextCol.HeaderText = "ID";
            TextCol.Width = 60;
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
            TextCol.HeaderText = "Họ tên";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "namsinh";
            TextCol.HeaderText = "NS";
            TextCol.Width = 50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "may";
            TextCol.HeaderText = "Máy";
            TextCol.Width = 120;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "vung";
            TextCol.HeaderText = "Vùng";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenbs";
            TextCol.HeaderText = "Bác sĩ";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "doituong";
            TextCol.HeaderText = "Đối tượng";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "cpt";
            TextCol.HeaderText = "CP";
            TextCol.Width = 60;
            TextCol.Format = "### ### ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "lt";
            TextCol.HeaderText = "LT";
            TextCol.Width = 60;
            TextCol.Format = "### ### ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }
    }
}