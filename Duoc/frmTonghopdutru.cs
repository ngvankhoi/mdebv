using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;

namespace Duoc
{
    public partial class frmTonghopdutru : Form
    {
        Language lan = new Language();
        private AccessData d = new AccessData();
        private string user = "", s_dblink = "";
        private DataSet ds_phieu;
        //private DataTable dt_phieu;
        private decimal l_id = 0;
        private int i_chinhanh = 0, i_userid = 0;

        public frmTonghopdutru()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        public frmTonghopdutru(int _chinhanh, int _userid)
        {
            InitializeComponent();
            i_chinhanh = _chinhanh; i_userid = _userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void frmTonghopdutru_Load(object sender, EventArgs e)
        {
            user = d.user;
            tungay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            denngay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            dgvdutru.AutoGenerateColumns = false;
            load_chinhanh();
            load_daduyet();
        }
        void load_daduyet()
        {
            DataTable dt_phieu = new DataTable();
            string sql = "";
            sql = "select a.id,a.phieu ";
            sql += "from " + user + ".d_duyetdutrukholl a, ";
            sql += "" + user + ".d_theodoiduyetdutru b ";
            sql += "where a.id=b.id and b.done=1 ";
            if (tungay.Text != "" && denngay.Text != "") sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay.Text + "','dd/mm/yyyy') and to_date('" + denngay.Text + "','dd/mm/yyyy')";
            dt_phieu = d.get_data(sql).Tables[0];
            cbophieuduyet.DisplayMember = "PHIEU";
            cbophieuduyet.ValueMember = "ID";
            cbophieuduyet.DataSource = dt_phieu;
        }
        private void butxem_Click(object sender, EventArgs e)
        {
            try
            {
                load_gird(cbosophieu.SelectedValue.ToString(), tungay.Text, denngay.Text,false);
                dgvdutru.DataSource = ds_phieu.Tables[0];
            }
            catch { }
        }
        /// <summary>
        /// lay ca phieu chua duyet theo tung chi nhanh
        /// </summary>
        /// <param name="dk"></param>
        /// <param name="s_tungay"></param>
        /// <param name="s_denngay"></param>
        /// <param name="xemlai"></param>
        private void load_phieu(string dk,string s_tungay,string s_denngay,bool xemlai)
        {
            //try
            //{
                
            //}
            //catch { dt_phieu = null; }
        }
        private void load_gird(string dk,string s_tungay,string s_denngay,bool xemlai)
        {
            try
            {
                ds_phieu = new DataSet();
                s_dblink = d.getDBLink(int.Parse(cbochinhanh.SelectedValue.ToString()));
                if (s_dblink.Trim('@') != "") s_dblink = "@" + s_dblink.Trim('@');
                string sql = "";
                sql = "select 0 as chon,a.id,a.phieu,b.mabd,d.ten,d.hamluong,d.tenhc,d.dang,b.soluong,b.soluong as sldutru,c.id_dutru,c.makho,c.id_chinhanh ";
                sql += "from " + user + ".d_duyetdutrukholl" + s_dblink + " a," + user + ".d_duyetdutrukhoct" + s_dblink + " b, ";
                sql += "" + user + ".d_theodoiduyetdutru" + s_dblink + " c,";
                sql += "" + user + ".d_dmbd" + s_dblink + " d ";
                sql += "where a.id=b.id and a.id=c.id and b.mabd=d.id ";
                //if (xemlai) { sql += " and (c.done=1 or c.done=0) "; butluu.Enabled = false; }
                //else { 
                sql += " and c.done=0 "; //butluu.Enabled = true; }
                if (dk != "") sql += " and a.id=" + dk + " ";
                if (s_tungay != "" && s_denngay != "")
                {
                    sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + 
                        s_denngay + "','dd/mm/yyyy')";
                }
                ds_phieu = d.get_data(sql);
            }
            catch { }
        }
        private void load_chinhanh()
        {
            try
            {
                cbochinhanh.DisplayMember = "TEN";
                cbochinhanh.ValueMember = "ID";
                cbochinhanh.DataSource = d.get_data("select id,ten from " + user + ".dmchinhanh").Tables[0];
            }
            catch { }
        }

        private void cbochinhanh_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cbochinhanh || sender==null)
                {
                    load_chuaduyet(int.Parse(cbochinhanh.SelectedValue.ToString()));
                }
            }
            catch { }
        }
        void load_chuaduyet(int _id_chinhanh)
        {
            DataTable dt_phieu = new DataTable();
            s_dblink = d.getDBLink(_id_chinhanh);
            if (s_dblink.Trim('@') != "") s_dblink = "@" + s_dblink.Trim('@');
            string sql = "";
            sql = "select a.id,a.phieu ";
            sql += "from " + user + ".d_duyetdutrukholl" + s_dblink + " a, ";
            sql += "" + user + ".d_theodoiduyetdutru" + s_dblink + " b ";
            sql += " where a.id=b.id and b.done=0 ";
            sql += " and b.id_chinhanh=" + _id_chinhanh.ToString() + " ";
            if (tungay.Text.Trim().Trim('/').Trim() != "" && denngay.Text.Trim().Trim('/').Trim() != "")
            {
                sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay.Text +
                    "','dd/mm/yyyy') and to_date('" + denngay.Text + "','dd/mm/yyyy')";
            }
            dt_phieu = d.get_data(sql).Tables[0];
            cbosophieu.DisplayMember = "PHIEU";
            cbosophieu.ValueMember = "ID";
            cbosophieu.DataSource = dt_phieu;
            if (cbosophieu.Items.Count > 0)
            {
                cbosophieu.SelectedIndex = 0;
                butxem_Click(null, null);
            }
        }
        private void txttimkiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void butluu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds_phieu.Tables[0].Select("chon=1").Length <= 0) return;
                if (l_id == 0) l_id = d.getidyymmddhhmiss_stt_computer;
                string as_sophieu = i_chinhanh.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + d.get_capid((int)LibMedi.IDThongSo.ID_SoPhieuDuyetDuTruKho).ToString().PadLeft(6, '0');
                string as_ngay = DateTime.Now.Date.ToString("dd/MM/yyyy");
                if (!d.upd_d_duyetdutrukholl(l_id, decimal.Parse(as_sophieu), as_ngay, i_userid))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin duyệt (d_duyetdutrukholl)!"));
                    return;
                }
                int stt = 0;
                foreach (DataRow r in ds_phieu.Tables[0].Select("chon=1"))
                {
                    stt++;
                    if (!d.upd_d_duyetdutrukhoct(l_id, stt, int.Parse(r["mabd"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["sldutru"].ToString())))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin duyệt (d_duyetdutrukhoct)!"));
                        return;
                    }
                }
                decimal aid_dutrukho = decimal.Parse(ds_phieu.Tables[0].Rows[0]["id"].ToString());
                int ai_makho = int.Parse(ds_phieu.Tables[0].Rows[0]["makho"].ToString());
                int ai_id_chinhanh = int.Parse(cbochinhanh.SelectedValue.ToString());
                if (!d.upd_d_theodoiduyetdutru(l_id, aid_dutrukho, ai_makho, ai_id_chinhanh, 3))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin theo dõi duyệt !"));
                    return;
                }
                //update done=1 cho cac chi nhanh
                s_dblink = d.getDBLink(ai_id_chinhanh);
                if (s_dblink.Trim('@') != "") s_dblink = "@" + s_dblink.Trim('@');
                //if (s_dblink != "")
                //{
                    //decimal aid = decimal.Parse(ds_phieu.Tables[0].Rows[0]["id"].ToString());
                    d.execute_data("update " + user + ".d_theodoiduyetdutru" + s_dblink + " set done=1 where id=" + aid_dutrukho.ToString());
                //}
                //else
                //{
                //    //decimal aid = decimal.Parse(ds_phieu.Tables[0].Rows[0]["id"].ToString());
                //    d.execute_data("update " + user + ".d_theodoiduyetdutru set done=1 where id=" + aid_dutrukho.ToString());
                //}
                //end update
                //MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công !"));                
            }
            catch { }
            cbochinhanh_SelectedValueChanged(null, null);
            load_daduyet();
        }

        private void butketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tungay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void cbophieuduyet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbophieuduyet)
            {
                load_gird(cbophieuduyet.SelectedValue.ToString(), "", "", true);
                dgvdutru.DataSource = ds_phieu.Tables[0];
            }
        }
        //private void Load_phieuduyet()
        //{
        //    try
        //    {
        //        LibMedi.AccessData m = new LibMedi.AccessData();
        //        load_phieu(m.i_Chinhanh_hientai.ToString(), "", "", true);
        //        cbophieuduyet.DisplayMember = "PHIEU";
        //        cbophieuduyet.ValueMember = "ID";
        //        cbophieuduyet.DataSource = dt_phieu;
        //    }
        //    catch { }
        //}

        private void denngay_Validated(object sender, EventArgs e)
        {
            load_chuaduyet(int.Parse(cbochinhanh.SelectedValue.ToString()));
        }

        private void dgvdutru_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cbosophieu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cbosophieu)
            {
                load_chuaduyet(int.Parse(cbochinhanh.SelectedValue.ToString()));
            }
        }
    }
}