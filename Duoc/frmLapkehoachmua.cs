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
    public partial class frmLapkehoachmua : Form
    {
        Language lan = new Language();
        private AccessData d = new AccessData();
        private string user = "", s_title = "";// s_dblink = "";
        private DataSet ds_phieu;
        private DataTable dt_phieu;
        private decimal l_id = 0;
        private int i_chinhanh = 0, i_userid = 0;
        private bool bDH_Goiy = true;

        public frmLapkehoachmua()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        public frmLapkehoachmua(int _chinhanh, int _userid,bool goiy,string title)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_chinhanh = _chinhanh; i_userid = _userid; bDH_Goiy = goiy; s_title = title;
        }

        private void frmLapkehoachmua_Load(object sender, EventArgs e)
        {
            this.Text = s_title;
            user = d.user;
            txtTungay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtDenngay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            dgvdutru.AutoGenerateColumns = false;
            readonly_dgv("slthucte");
            butin.Visible = true;
            load_chinhanh();
            load_phieu();
            chkBienban.Visible = !bDH_Goiy;
            chkKehoach.Visible = !bDH_Goiy;
            butluu.Enabled = !bDH_Goiy;
        }

        private void readonly_dgv(string columns)
        {
            dgvdutru.Columns[columns].ReadOnly = bDH_Goiy;
            if (bDH_Goiy) dgvdutru.Columns[columns].Visible = false;
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

        private void butxem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (bDH_Goiy)
                //{
                    load_grid(txtTungay.Text, txtDenngay.Text, cbosophieu.SelectedValue.ToString(),false);
                //}
                //else
                //{
                //    load_grid1(tungay.Text, denngay.Text, cbosophieu.SelectedValue.ToString(),false);
                //    dgvdutru.DataSource = ds_phieu.Tables[0];
                //}
            }
            catch { }
        }
        private void load_grid(string tungay, string denngay, string s_id, bool xemlai)
        {
            try
            {
                ds_phieu = new DataSet();
                string sql = "";
                sql = "select a.id,b.stt,a.phieu,b.mabd,c.ten,c.hamluong,c.tenhc,c.dang,b.soluong,b.soluong as slthucte,c.dongia as giamua,c.vat as vat ";
                sql += "from " + user + ".d_duyetdutrukholl a," + user + ".d_duyetdutrukhoct b, ";
                sql += "" + user + ".d_dmbd c,"+user+".d_theodoiduyetdutru d ";
                sql += "where a.id=b.id and b.mabd=c.id and a.id=d.id ";
                sql += "and d.done=3 ";
                if (s_id != "") sql += " and a.id=" + s_id + " ";
                if (tungay != "" && denngay != "")
                {
                    sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') ";
                }
                ds_phieu = d.get_data(sql);
                dgvdutru.DataSource = ds_phieu.Tables[0];
                butluu.Enabled = ds_phieu.Tables[0].Rows.Count > 0;
            }
            catch { }
        }
        /// <summary>
        /// Load chi tiet cua cac phieu da len ke hoach
        /// </summary>
        /// <param name="s_id"></param>
        private void load_daduyet(string s_id)
        {
            try
            {
                ds_phieu = new DataSet();
                string sql = "";
                sql = "select a.id,b.stt,a.phieu,b.mabd,c.ten,c.hamluong,c.tenhc,c.dang,b.soluong,b.slthucte as slthucte,c.dongia as giamua,c.vat as vat ";
                sql += "from " + user + ".d_kehoachdathang a," + user + ".d_kehoachdathangct b, ";
                sql += "" + user + ".d_dmbd c," + user + ".d_kehoachdathangtheodoi d ";
                sql += "where a.id=b.id and b.mabd=c.id and a.id=d.id ";
                if (s_id != "") sql += " and a.id=" + s_id + " ";
                ds_phieu = d.get_data(sql);
                dgvdutru.DataSource = ds_phieu.Tables[0];
                butluu.Enabled = ds_phieu.Tables[0].Rows.Count > 0;
            }
            catch { }
        }
        /// <summary>
        /// load cac phieu da len ke hoach
        /// </summary>
        /// <param name="dk"></param>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        /// <param name="xemlai"></param>
        private void load_phieu()
        {
            try
            {
                dt_phieu = new DataTable();
                string sql = "";
                sql = "select a.id,a.phieu ";
                sql += "from " + user + ".d_kehoachdathang a ";
                dt_phieu = d.get_data(sql).Tables[0];
                cbophieuduyet.DataSource = dt_phieu;
                cbophieuduyet.DisplayMember = "PHIEU";
                cbophieuduyet.ValueMember = "ID";
                if (cbophieuduyet.Items.Count > 0)
                {
                    cbophieuduyet.SelectedIndex = cbophieuduyet.Items.Count - 1;
                    load_daduyet(cbophieuduyet.SelectedValue.ToString());
                }
            }
            catch { dt_phieu = null; }
        }
        /// <summary>
        /// Load cac phieu da duoc tong hop
        /// </summary>
        /// <param name="dk"></param>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        /// <param name="xemlai"></param>
        private void load_dutru(string dk, string tungay, string denngay, bool xemlai)
        {
            try
            {
                DataTable dttmp = new DataTable();
                string sql = "";
                sql = "select a.id,a.phieu ";
                sql += "from " + user + ".d_duyetdutrukholl a, ";
                sql += "" + user + ".d_theodoiduyetdutru b ";
                sql += "where a.id=b.id and b.done=3 ";
                if (dk != "") sql += " and b.id_chinhanh=" + dk + " ";
                if (tungay.Trim().Trim('/').Trim() != "" && denngay.Trim().Trim('/').Trim() != "")
                {
                    sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" +
                        tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') ";
                }
                dttmp = d.get_data(sql).Tables[0];
                cbosophieu.DisplayMember = "PHIEU";
                cbosophieu.ValueMember = "ID";
                cbosophieu.DataSource = dttmp;
                if (cbosophieu.Items.Count > 0)
                {
                    cbosophieu.SelectedIndex = cbosophieu.Items.Count - 1;
                    load_grid(txtTungay.Text, txtDenngay.Text, cbosophieu.SelectedValue.ToString(), false);
                }
            }
            catch { dt_phieu = null; }
        }

        private void txttimkiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void butluu_Click(object sender, EventArgs e)
        {
            try
            {
                int i_dong = 0;
                foreach (DataRow dr in ds_phieu.Tables[0].Rows)
                {
                    i_dong++;
                    if (decimal.Parse(dr["soluong"].ToString()) < decimal.Parse(dr["slthucte"].ToString()))
                    {
                        MessageBox.Show("Số lượng thực tế phải luôn nhỏ hơn hoặc bằng số lượng dự trù !\n Lỗi dòng :"+i_dong+" (thuốc :" + dr["ten"].ToString() + ")");
                        return;
                    }
                }
                if (bDH_Goiy)
                {
                    if (l_id == 0) l_id = d.getidyymmddhhmiss_stt_computer;
                    string as_sophieu = i_chinhanh.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + d.get_capid((int)LibMedi.IDThongSo.ID_SoPhieuDuyetKeHoachDatHang).ToString().PadLeft(6, '0');
                    string as_ngay = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    int ai_manguon = 7;
                    if (!d.upd_d_kehoachdathang(l_id, as_ngay, decimal.Parse(as_sophieu), i_userid, 0, ai_manguon))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đặt hàng !(d_kehoachdathang)"));
                        return;
                    }
                    int stt = 0;
                    foreach (DataRow r in ds_phieu.Tables[0].Rows)
                    {
                        stt++;
                        if (!d.upd_d_kehoachdathangct(l_id, stt, int.Parse(r["mabd"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["slthucte"].ToString()), decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["vat"].ToString())))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đặt hàng !(d_kehoachdathangct)"));
                            return;
                        }
                    }
                    decimal aid_duyetdutrukho = decimal.Parse(cbosophieu.SelectedValue.ToString());
                    if (!d.upd_d_kehoachdathangtheodoi(l_id, aid_duyetdutrukho))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được kế hoạch đặt hàng !"));
                        return;
                    }
                    //update done=1 tai trung tam
                    d.execute_data("update " + user + ".d_theodoiduyetdutru set done=4 where id=" + aid_duyetdutrukho + "");
                    //end
                    //MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công !"));
                }
                else
                {
                    foreach (DataRow r in ds_phieu.Tables[0].Rows)
                    {
                        d.execute_data("update " + user + ".d_kehoachdathangct set slthucte=" + r["slthucte"].ToString() + " where id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString() + "");
                    }
                    //MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công !"));
                }
            }
            catch { }
            load_phieu();
            cbochinhanh_SelectedValueChanged(null,null);
        }

        private void butketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                sql = "select a.id,b.stt,a.phieu,b.mabd,c.hamluong,c.ma,c.tenhc as hoatchat,c.dang,c.ten as tenthuoc,c.mahang,";
                sql += "e.ten as tenhang,c.manuoc,f.ten as tennuoc,b.soluong,b.slthucte,b.giamua,b.vat,c.vtyt,c.ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,h.phieu ";
                int i = 0;
                foreach (DataRow r in d.get_data("select id from " + user + ".dmchinhanh order by id").Tables[0].Rows)
                {
                    i++;
                    sql += ",(case when g.id_chinhanh=" + r["id"].ToString() + " then " + (bDH_Goiy ? "b.soluong" : "b.slthucte") + " else 0 end) as soluong" + i.ToString();
                }
                sql += " from " + user + ".d_kehoachdathang a," + user + ".d_kehoachdathangct b, ";
                sql += "" + user + ".d_dmbd c," + user + ".d_kehoachdathangtheodoi d," + user + ".d_dmhang e,";
                sql += "" + user + ".d_dmnuoc f," + user + ".d_theodoiduyetdutru g," + user + ".d_duyetdutrukholl h ";
                sql += "where a.id=b.id and b.mabd=c.id and a.id=d.id and c.mahang=e.id and c.manuoc=f.id and ";
                sql += " d.id_duyetdutrukho=g.id and g.id=h.id";// and a.mua=0 ";
                sql += " and a.id=" + cbophieuduyet.SelectedValue.ToString() + " ";
                //sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTungay.Text + "','dd/mm/yyyy') and to_date('" + txtDenngay.Text + "','dd/mm/yyyy') ";
                DataSet ds_in = d.get_data(sql);
                if (chkBienban.Checked)
                {
                    if (chkxml.Checked) ds_in.WriteXml("..//..//dataxml//bienbandieuchinhvattu.xml", XmlWriteMode.WriteSchema);
                    if (ds_in.Tables[0].Rows.Count > 0)
                    {
                        frmReport f = new frmReport(d, ds_in, i_userid, "", "rptBienbandieuchinhvattu.rpt");
                        f.ShowDialog();
                    }
                }
                if (chkxml.Checked) ds_in.WriteXml("..//..//dataxml//kehoachnhapvattu.xml", XmlWriteMode.WriteSchema);
                if (ds_in.Tables[0].Rows.Count > 0)
                {
                    frmReport f = new frmReport(d, ds_in,i_userid, bDH_Goiy ? "DỰ KIẾN" : "THỰC TẾ", "rptKehoachnhapvattu.rpt");
                    f.ShowDialog();
                }
            }
            catch { }
        }

        private void cbochinhanh_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cbochinhanh || sender==null)
                {
                    load_dutru(cbochinhanh.SelectedValue.ToString(), txtTungay.Text, txtDenngay.Text, false);
                    //if (dt_phieu.Rows.Count <= 0) dgvdutru.DataSource = null;
                }
            }
            catch { }
        }

        private void tungay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void cbophieuduyet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbophieuduyet)
            {
                load_daduyet(cbophieuduyet.SelectedValue.ToString());
                //dgvdutru.DataSource = ds_phieu.Tables[0];
            }
        }
        //private void Load_phieuduyet()
        //{
        //    try
        //    {
        //        dt_phieu = new DataTable();
        //        string sql = "";
        //        sql = "select a.id,a.phieu ";
        //        sql += "from " + user + ".d_kehoachdathang a ";
        //        sql += " where a.mua=0 ";
        //        dt_phieu = d.get_data(sql).Tables[0];
        //    }
        //    catch { dt_phieu = null; }
        //    cbophieuduyet.DisplayMember = "PHIEU";
        //    cbophieuduyet.ValueMember = "ID";
        //    cbophieuduyet.DataSource = dt_phieu;
        //}

        private void denngay_Validated(object sender, EventArgs e)
        {
            load_dutru(cbochinhanh.SelectedValue.ToString(), txtTungay.Text, txtDenngay.Text, false);
            cbosophieu.DisplayMember = "PHIEU";
            cbosophieu.ValueMember = "ID";
            cbosophieu.DataSource = dt_phieu;
            if (dt_phieu.Rows.Count <= 0) dgvdutru.DataSource = null;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[ds_phieu.Tables[0]];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "ten like'%" + txttimkiem.Text + "%'";
        }

        private void cbosophieu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cbosophieu)
            {
                load_grid(txtTungay.Text, txtDenngay.Text, cbosophieu.SelectedValue.ToString(), false);
            }
        }
    }
}