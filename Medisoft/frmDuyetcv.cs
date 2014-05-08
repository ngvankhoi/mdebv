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
    public partial class frmDuyetcv : Form
    {
        private AccessData m = new AccessData();
        private Language lan = new Language();
        private string user = "";
        private int i_userid = 0, i_duyetcv = 0;
        private decimal l_maql = 0;
        private DataSet ds = new DataSet();

        public frmDuyetcv()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        public frmDuyetcv(int _i_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_userid = _i_userid;
        }

        private void frmDuyetcv_Load(object sender, EventArgs e)
        {
            tungay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            denngay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            //label1.Text = "DANH SÁCH BN CHỜ DUYỆT VÀ IN GIẤY CHUYỂN VIỆN";
            user = m.user;
            try { i_duyetcv = int.Parse(m.get_data("select duyetcv from " + user + ".dlogin where id=" + i_userid + "").Tables[0].Rows[0][0].ToString()); }
            catch { i_duyetcv = 0; }
            load_CB();
            dg_readonly();
            
            cbogioitinh.SelectedIndex = -1;
            txtlydocv.Enabled = false;
        }

        private void dg_readonly()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["lydo"].ReadOnly = false;
            dataGridView1.Columns["daduyet"].ReadOnly = false;
            dataGridView1.Columns["mabn"].ReadOnly = true;
            dataGridView1.Columns["hoten"].ReadOnly = true;
            dataGridView1.Columns["ngaysinh"].ReadOnly = true;
            dataGridView1.Columns["gioitinh"].ReadOnly = true;
            dataGridView1.Columns["noichuyenden"].ReadOnly = true;
            dataGridView1.Columns["chuaduyet"].ReadOnly = true;
            dataGridView1.Columns["cungtuyen"].ReadOnly = true;
            dataGridView1.Columns["ngoaituyen"].ReadOnly = true;
        }

        private void load_data()
        {
            string sql = "";
            sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,(case when c.phai=0 then 'Nam' else 'Nữ' end) as gioitinh,a.maql,c.cholam,k.tenbv,";
            sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayra,";
            sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
            sql += "h.tenquan,i.tenpxa,case when j.chandoan is null then a.chandoan else j.chandoan end as chandoan,a.maicd,";
            sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,k.tenbv as noichuyenden,k.cungtuyen,";
            sql += "j.lamsang,j.xn,j.thuoc,j.tinhtrang,j.lydo,case when j.ngay is null then to_char(a.ngay,'dd/mm/yyyy hh24:mi') else to_char(j.ngay,'dd/mm/yyyy hh24:mi') end as ngay,j.vanchuyen,j.nguoidua,j.lanin, j.sochuyenvien ";
            sql += ", to_char(l.tungay,'dd/mm/yyyy') as tungay, j.yeucau, a.sovaovien, lh.soluutru,j.daduyet ";
            sql += " from xxx.benhanpk a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
            sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
            sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
            sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
            sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
            sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
            sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
            sql += " inner join " + user + ".chuyenvien j on a.maql=j.maql ";
            sql += " left join " + user + ".tenvien k on j.mabv=k.mabv ";
            sql += " left join xxx.bhyt l on a.maql=l.maql ";
            sql += " left join " + user + ".dmbs gg on a.mabs=gg.ma ";
            sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
            sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
            sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
            sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
            sql += " left join xxx.lienhe lh on a.maql=lh.maql ";
            sql += " where true";
            if (cbotenkp.SelectedIndex != -1)
            {                
                sql += " and a.makp in ('" + cbotenkp.SelectedValue.ToString() + "') ";
            }
            if (txtmabn.Text.Trim() != "") sql += " and a.mabn='" + txtmabn.Text.Trim() + "' ";
            if (i_duyetcv == 0) sql += " and j.daduyet=1 ";
            if (chkdaduyet.Checked) sql += " and j.daduyet=1 ";
            else if (chkchuaduyet.Checked) sql += " and j.daduyet=0 ";
            if (chkcungtuyen.Checked) sql += " and k.cungtuyen=1 ";
            else if (chkngoaituyen.Checked) sql += " and k.cungtuyen=0 ";
            sql += " and to_date(to_char(j.ngay,'dd/mm/yyyy'),'dd/mmm/yyyy') between to_date('" + tungay.Text + "','dd/mm/yyyy') and to_date('" + denngay.Text + "','dd/mm/yyyy') ";
            sql += "  order by a.maql desc";
            ds = m.get_data_mmyy(sql, tungay.Text, denngay.Text, false);
            dataGridView1.DataSource = ds.Tables[0];
            int i = 0;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if (r["daduyet"].ToString() == "1") dataGridView1["daduyet", i].Value = 1;
                else dataGridView1["chuaduyet", i].Value = 1;
                if (r["cungtuyen"].ToString()=="1") dataGridView1["cungtuyen", i].Value = 1;
                else dataGridView1["ngoaituyen", i].Value = 1;
                dataGridView1["In", i].Value = 0;
                i++;
            }
        }

        private void load_CB()
        {
            string sql = "";
            sql = "select makp,tenkp from "+user+".btdkp_bv order by tenkp";
            cbotenkp.DisplayMember = "TENKP";
            cbotenkp.ValueMember = "MAKP";
            cbotenkp.DataSource = m.get_data(sql).Tables[0];
            cbotenkp.SelectedIndex = -1;
        }

        private void butluu_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                m.execute_data("update " + user + ".chuyenvien set daduyet=" + dataGridView1["daduyet", i].Value + " where maql=" + dataGridView1["maql", i].Value + "");
                m.upd_chuyenvien(decimal.Parse(dataGridView1["maql", i].Value.ToString()), dataGridView1["lydo", i].Value.ToString());
                i++;
            }
            load_data();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int current = dataGridView1.CurrentRow.Index;
                l_maql = decimal.Parse(dataGridView1["maql", current].Value.ToString());
                txtlydocv.Text = dataGridView1["lydo", current].Value.ToString();
                txtlydocv.Enabled = true;
            }
            catch { }
            
        }

        private void butketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttim_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void butin_Click(object sender, EventArgs e)
        {
            DataSet dsxml = new DataSet();
            dsxml = ds.Clone();
            int i = 0;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                dsxml.Clear();
                if (dataGridView1["In", i].Value.ToString() == "1" || dataGridView1["In", i].Value.ToString()=="True")
                {
                    if (dataGridView1["cungtuyen", i].Value.ToString() == "1" || dataGridView1["cungtuyen", i].Value.ToString()=="True")//cung tuyen
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow r1 in ds.Tables[0].Select("mabn='" + dataGridView1["mabn", i].Value.ToString() + "'"))
                            {
                                dsxml.Tables[0].Rows.Add(r1.ItemArray);
                            }
                            dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "GIẤY CHUYỂN VIỆN", "rptGiaycv.rpt", true);
                            f.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
                            //return;
                        }
                    }
                    else //khong cung tuyen
                    {
                        try
                        {
                            DataSet ds_duyet = m.get_data("select daduyet from " + user + ".chuyenvien where maql=" + l_maql + "");
                            if (ds_duyet.Tables[0].Rows[0]["daduyet"].ToString() == "1")
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow r2 in ds.Tables[0].Select("mabn='" + dataGridView1["mabn", i].Value.ToString() + "'"))
                                    {
                                        dsxml.Tables[0].Rows.Add(r2.ItemArray);
                                    }
                                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "GIẤY CHUYỂN VIỆN", "rptGiaycv.rpt", true);
                                    f.ShowDialog();
                                }
                            }
                            else
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân chưa được duyệt chuyển viện !"), LibMedi.AccessData.Msg);
                                //return;
                            }
                        }
                        catch { }
                    }
                }
                dataGridView1["In", i].Value = 0;
                i++;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1["daduyet", dataGridView1.CurrentRow.Index].Value.ToString() == "1")
            //    dataGridView1["chuaduyet", dataGridView1.CurrentRow.Index].Value = 0;
        }

        private void chkdaduyet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdaduyet.Checked) chkchuaduyet.Checked = false;
        }

        private void chkchuaduyet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkchuaduyet.Checked) chkdaduyet.Checked = false;
        }

        private void chkcungtuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcungtuyen.Checked) chkngoaituyen.Checked = false;
        }

        private void chkngoaituyen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkngoaituyen.Checked) chkcungtuyen.Checked = false;
        }
    }
}