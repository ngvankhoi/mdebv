using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dllvpkhoa_chidinh
{
    public partial class frmBienbanhoichancls : Form
    {
        LibMedi.AccessData m=new LibMedi.AccessData();
        Language lan = new Language();
        private string s_mabn = "", s_ngay = "", s_user = "";
        private decimal l_mavaovien, l_maql;
        private int i_userid;
        private DataSet dshoichan;
        private DataSet dskqcls = new DataSet();
        private DataSet dskqxn = new DataSet();
        public frmBienbanhoichancls()
        {
            InitializeComponent();
        }
        public frmBienbanhoichancls(LibMedi.AccessData _m, string smabn, decimal lmavaovien, decimal lmaql,string sngay,DataSet dshc,int iuserid)
        {
            m = _m;
            s_mabn = smabn;
            l_mavaovien = lmavaovien;
            l_maql = lmaql;
            s_ngay = sngay;
            dshoichan = new DataSet();
            dshoichan = dshc;
            s_user = _m.user;
            i_userid = iuserid;
            InitializeComponent();
        }
        private void frmBienbanhoichancls_Load(object sender, EventArgs e)
        {
            f_loathongtincls();
            f_Thongtinbn();
            f_loadketquacls();
            f_loadkqxn();
            f_Loadlanhoichan();
            f_Enable(true);
            f_EnableText_Check(false);
            
            
        }
        private void f_loathongtincls()
        {
            cbLoaicls.DisplayMember = "ten";
            cbLoaicls.ValueMember = "id";
            cbLoaicls.DataSource = dshoichan.Tables[0];
            
        }
        private void f_Thongtinbn()
        {
            string sql = "select * from " + s_user + ".btdbn where mabn='" + s_mabn + "'";
            foreach (DataRow dr in m.get_data(sql).Tables[0].Rows)
            {
                lbhoten.Text = dr["hoten"].ToString();
                lbNamsinh.Text += dr["namsinh"].ToString();
                chkNam.Checked = dr["phai"].ToString() == "0";
                chkNu.Checked = dr["phai"].ToString() == "1";
            }
        }
        private void f_Enable(bool t)
        {
            butMoi.Enabled = t;
            butLuu.Enabled = !t;
            butClose.Enabled = t;
            butBoqua.Enabled = !t;
            butSua.Enabled = t;
            butXoa.Enabled = t;
        }
        private void f_EnableText_Check(bool t)
        {
            chkNam.Enabled = false;
            chkNu.Enabled = false;
            cbLoaicls.Enabled = t;
            txtTtlamsang.Enabled = t;
            txtChandoan.Enabled = t;
            txtXquang.Enabled = false;
            txtSieuam.Enabled = false;
            txtXetnghiem.Enabled = false;

            chksdthuoccqco.Enabled = t;
            chksdthuoccqkhong.Enabled = t;
            
            chksonao.Enabled = t;
            chkXuongdatai.Enabled = t;
            chkCotsongco.Enabled = t;
            chkLongnguc.Enabled = t;
            chkCungcut.Enabled = t;

            chkMuixoangaxial.Enabled = t;
            chkhh_ss.Enabled = t;
            chkCotsongnguc.Enabled = t;
            chkObung.Enabled = t;
            chkCosuongkhop.Enabled = t;

            chkMuixoangaxial_coronal.Enabled = t;
            chkVungco.Enabled = t;
            chkCsthatlung.Enabled = t;
            chkDynamic.Enabled = t;
            chkVungchau.Enabled = t;
        }
        private void f_loadketquacls()
        {
            string sidloaicls = "";
            string sql = " select a.id_loai idloaicdha,a.id,a.maql,a.makp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngaythuchien,a.loaibn,a.ketluan,a.id_loai idloaicls,d.tenkt,c.ten tenloaicls";
            sql += " from xxx.cdha_bnll a  inner join xxx.cdha_bnct b on a.id=b.id inner join medibv.cdha_loai c on a.id_loai=c.id";
            sql += " inner join medibv.cdha_kythuat d on b.makt=d.makt";
            sql += " where a.mabn='" + s_mabn + "' and a.maql=" + l_maql;
            dskqcls = m.get_data_mmyy(sql, s_ngay, s_ngay, 31);
            try
            {
                foreach (DataRow dr in dskqcls.Tables[0].Rows)
                {
                    sidloaicls = dr["idloaicls"].ToString();
                    if (sidloaicls == "02")
                        txtXquang.Text += dr["ketluan"].ToString();
                    else if (sidloaicls == "01")
                        txtSieuam.Text += dr["ketluan"].ToString();
                }
            }
            catch { throw; }
        }
        private void f_loadkqxn()
        {//a.id,a.sophieu,mabn,maql,to_char(ngay,'dd/mm/yyyy') ngay,ketluan,denghi
            //string sql = "select array( select  d.ten||' ('||b.ketqua||')' as tenvp from xxx.xn_phieu a, xxx.xn_ketqua b, "+m.user+".xn_bv_chitiet c,"+m.user+".xn_ten d"+
            //    "where a.mabn='" +
            //    s_mabn + "' and a.id=b.id and b.id_ten=c.id and c.id_ten=d.id and a.maql=" + l_maql+" and b.ketqua<>'')";
            //dskqxn = m.get_data_mmyy(sql, s_ngay, s_ngay, 31);
            //try
            //{
            //    txtXetnghiem.Text += dskqxn.Tables[0].Rows[0][0].ToString().Trim().Trim('{');
            //    //foreach (DataRow dr in dskqxn.Tables[0].Rows)
            //    //{
            //    //    txtXetnghiem.Text += dr["ketluan"].ToString();
            //    //}
            //}
            ////catch { throw; }
            //string asql = "select d.ten,e.id_vienphi,b.ketqua,b.ghichu from xxx.xn_phieu a inner join xxx.xn_ketqua b on a.id=b.id inner join medibv.xn_bv_chitiet c on b.id_ten=c.id inner join medibv.xn_ten d on c.id_ten=d.id inner join medibv.xn_bv_ten e on c.id_bv_ten=e.id where a.maql=" + l_maql.ToString() + "' order by d.stt,c.stt";
            //DataSet ads = m.get_data_mmyy(asql, s_ngay, s_ngay, false);
            //string aketqua = "";
            //foreach (DataRow r in ads.Tables[0].Rows)
            //{
                //aketqua += r["ketqua"].ToString().Trim();
                //foreach (DataRow r1 in ads.Tables[0].Select("id_vienphi=" + r["mavpm"].ToString()))
                //{
                //    if (r1["ketqua"].ToString().Trim() != "")
                //    {
                //        if (aketqua != "") aketqua += "\n";
                //        if (r["ten"].ToString().ToUpper().Trim() != r1["ten"].ToString().ToUpper().Trim())
                //        {
                //            aketqua += r1["ten"].ToString() + "    :    " + r1["ketqua"].ToString();
                //        }
                //        else
                //        {
                //            aketqua += r1["ketqua"].ToString();
                //        }
                //    }
                //}
            //}
                //txtXetnghiem.Text = aketqua;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (m.upd_hoichan_cdha(decimal.Parse(cbLoaicls.SelectedValue.ToString()), s_mabn, l_mavaovien, l_maql, dtNgayhoichan.Value, txtTtlamsang.Text.Trim(), txtChandoan.Text.Trim(), txtXquang.Text.Trim(), txtSieuam.Text.Trim(), txtXetnghiem.Text.Trim(), chksdthuoccqco.Checked ? 1 : 0, chksdthuoccqkhong.Checked ? 1 : 0, i_userid))
            {
                m.execute_data("delete " + s_user + ".hoichan_cdha_ct where id=" + cbLoaicls.SelectedValue.ToString());
                if (chksonao.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chksonao.Tag.ToString()));
                if (chkXuongdatai.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkXuongdatai.Tag.ToString()));
                if (chkCotsongco.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCotsongco.Tag.ToString()));
                if (chkLongnguc.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkLongnguc.Tag.ToString()));
                if (chkCungcut.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCungcut.Tag.ToString()));
                if (chkMuixoangaxial.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkMuixoangaxial.Tag.ToString()));
                if (chkhh_ss.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkhh_ss.Tag.ToString()));
                if (chkCotsongnguc.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCotsongnguc.Tag.ToString()));
                if (chkObung.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkObung.Tag.ToString()));
                if (chkCosuongkhop.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCosuongkhop.Tag.ToString()));
                if (chkMuixoangaxial_coronal.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkMuixoangaxial_coronal.Tag.ToString()));
                if (chkVungco.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkVungco.Tag.ToString()));
                if (chkCsthatlung.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCsthatlung.Tag.ToString()));
                if (chkDynamic.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkDynamic.Tag.ToString()));
                if (chkVungchau.Checked)
                    m.upd_hoichan_cdha_ct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkVungchau.Tag.ToString()));
            }
            f_Loadlanhoichan();
            f_Enable(true);
            f_EnableText_Check(false);
        }
        private void chksdthuoccqco_CheckedChanged(object sender, EventArgs e)
        {
            if (chksdthuoccqkhong.Checked == true)
                chksdthuoccqkhong.Checked = false;
        }
        private void chksdthuoccqkhong_CheckedChanged(object sender, EventArgs e)
        {
            if (chksdthuoccqco.Checked == true)
                chksdthuoccqco.Checked = false;
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_EnableText_Check(true);
            f_Enable(false);
            f_Cleartext();
            txtTtlamsang.Focus();
        }
        private void f_Cleartext()
        {
            txtTtlamsang.Text = "";
            txtChandoan.Text = "";
            chksdthuoccqco.Checked = false;
            chksdthuoccqkhong.Checked = false;
            chksonao.Checked = false;
            chkXuongdatai.Checked = false;
            chkCotsongco.Checked = false;
            chkLongnguc.Checked = false;
            chkCungcut.Checked = false;

            chkMuixoangaxial.Checked = false;
            chkhh_ss.Checked = false;
            chkCotsongnguc.Checked = false;
            chkObung.Checked = false;
            chkCosuongkhop.Checked = false;

            chkMuixoangaxial_coronal.Checked = false;
            chkVungco.Checked = false;
            chkCsthatlung.Checked = false;
            chkDynamic.Checked = false;
            chkVungchau.Checked = false;
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            f_EnableText_Check(true);
            f_Enable(false);
            txtTtlamsang.Focus();
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_EnableText_Check(false);
            f_Enable(true);
            butMoi.Focus();
        }
        private void cbLoaicls_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dshc = new DataSet();
            string sql = " select a.id,a.mabn,to_char(a.ngayhoichan,'dd/mm/yyyy hh24:mi') ngayhoichan,a.lamsang,a.chandoan,a.xquang,a.sieuam,a.xetnghiem,a.sdthuoccanquangco thuocco,a.sdthuoccanquangkhong thuock";
            sql += " from " + s_user + ".hoichan_cdha a ";
            sql += " where a.id=" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + "";
            dshc = m.get_data(sql);
            if (dshc.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dshc.Tables[0].Rows)
                {

                    txtTtlamsang.Text = r["lamsang"].ToString();
                    txtChandoan.Text = r["chandoan"].ToString();
                    txtXquang.Text = r["xquang"].ToString();
                    txtSieuam.Text = r["sieuam"].ToString();
                    txtXetnghiem.Text = r["xetnghiem"].ToString();
                    chksdthuoccqco.Checked = r["thuocco"].ToString() == "1";
                    chksdthuoccqkhong.Checked = r["thuock"].ToString() == "1";
                }
                sql = " select a.iddmbophan,b.ten from " + s_user + ".hoichan_cdha_ct a inner join " + s_user + ".dmbophan_hoichan b on a.iddmbophan=b.id";
                sql += " where a.id =" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + "";
                try
                {
                    foreach (DataRow dr in m.get_data(sql).Tables[0].Rows)
                    {
                        if (chksonao.Tag.ToString() == dr["iddmbophan"].ToString())
                            chksonao.Checked = true;
                        if (chkXuongdatai.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkXuongdatai.Checked = true;
                        if (chkCotsongco.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCotsongco.Checked = true;
                        if (chkLongnguc.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkLongnguc.Checked = true;
                        if (chkCungcut.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCungcut.Checked = true;
                        if (chkMuixoangaxial.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkMuixoangaxial.Checked = true;
                        if (chkhh_ss.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkhh_ss.Checked = true;
                        if (chkCotsongnguc.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCotsongnguc.Checked = true;
                        if (chkObung.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkObung.Checked = true;
                        if (chkCosuongkhop.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCosuongkhop.Checked = true;
                        if (chkMuixoangaxial_coronal.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkMuixoangaxial_coronal.Checked = true;
                        if (chkVungco.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkVungco.Checked = true;
                        if (chkCsthatlung.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCsthatlung.Checked = true;
                        if (chkDynamic.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkDynamic.Checked = true;
                        if (chkVungchau.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkVungchau.Checked = true;
                    }
                }
                catch { return; }
            }
            else
            {
                f_Cleartext();
                return;
            }
        }
        private void butIn_Click(object sender, EventArgs e)
        {
            f_print("rptBienbanhoichan.rpt");
        }
        private void f_print(string s_tenrp)
        {
            DataSet dsinhc = new DataSet();
            String xxx = s_user + m.mmyy(s_ngay);
            string sql = " select a.id,a.mabn,to_char(a.ngayhoichan,'dd/mm/yyyy hh24:mi') ngayhoichan,a.lamsang,a.chandoan,a.xquang,a.sieuam,a.xetnghiem,a.sdthuoccanquangco thuocco,a.sdthuoccanquangkhong thuock,b.iddmbophan,c.ten,d.hoten,d.namsinh,d.phai";
            sql += " ,f.ten tencls,g.ten tenloaicls,f.id_loai idloai,";
            sql += " (h.sonha ||' '||h.thon||' '||i.tenpxa||' '||l.tenquan||' '||m.tentt) diachi,n.nha sodtnha,n.coquan sodtcq,n.didong,n1.tennn,n2.dantoc,h.cholam ";
            sql += " from " + s_user + ".hoichan_cdha a left join " + s_user + ".hoichan_cdha_ct b on a.id=b.id left join " + s_user + ".dmbophan_hoichan c on b.iddmbophan=c.id ";
            sql += " left join " + s_user + ".btdbn d on a.mabn=d.mabn";
            sql += " left join " + xxx + ".v_chidinh e on a.id=e.id left join " + s_user + ".v_giavp f on e.mavp=f.id left join " + s_user + ".v_loaivp g on f.id_loai=g.id ";
            sql += " inner join " + s_user + ".btdbn h on a.mabn=h.mabn inner join " + s_user + ".btdpxa i on h.maphuongxa=i.maphuongxa inner join " + s_user + ".btdquan l on h.maqu=l.maqu ";
            sql += " inner join " + s_user + ".btdtt m on h.matt=m.matt left join " + s_user + ".dienthoai n on a.mabn=n.mabn left join " + s_user + ".btdnn n1 on h.mann=n1.mann left join " + s_user + ".btddt n2 on h.madantoc=n2.madantoc";
            sql += " left join " + xxx + ".xn_phieu n3 on a.mabn=n3.mabn and a.maql=n3.maql ";
            sql += " where a.id in(" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + ")";
            dsinhc = m.get_data_mmyy(sql, s_ngay, s_ngay, 31);
            if (dsinhc.Tables[0].Rows.Count > 0)
            {
                if (!System.IO.Directory.Exists("..//xml"))
                    System.IO.Directory.CreateDirectory("..//xml");
                dsinhc.WriteXml("..//xml//rptBienbanhoichan.xml", XmlWriteMode.WriteSchema);
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsinhc, s_ngay.Substring(0, 10), s_tenrp);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText(" Chưa có dữ liệu."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Bạn thật sự muốn xóa biên bản hội chẩn này."), "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl==DialogResult.Yes)
            {
                string sql = " delete from " + s_user + ".hoichan_cdha_ct where id=" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + "";
                if (m.execute_data(sql))
                {
                    sql = " delete from " + s_user + ".hoichan_cdha where id=" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + "";
                    m.execute_data(sql);
                }
                f_loadketquacls();
                f_loadkqxn();
                f_loathongtincls();
                f_EnableText_Check(true);
                f_Cleartext();
                f_Enable(true);
            }
            else
                return;
        }
        private void f_Loadlanhoichan()
        {
            DataSet dscaclanhc = new DataSet();
            Treelanhc.Nodes.Clear();
            TreeNode anode = null;
            TreeNode anode1 = null;
            string s_idtmp = "";
            string s_sql = " select a.id,c.ten,b.mavp,a.mabn,to_char(ngayhoichan,'dd/mm/yyyy') ngay from " + s_user + ".hoichan_cdha a inner join " + s_user + m.mmyy(s_ngay) + ".v_chidinh b on a.id=b.id inner join " + s_user + ".v_giavp c on b.mavp=c.id ";
            s_sql += " where b.mavaovien=" + l_mavaovien + " order by c.ten";
            dscaclanhc = m.get_data(s_sql);// m.get_data_mmyy(s_sql, s_ngay, s_ngay, true);
            if (dscaclanhc.Tables[0].Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow r in dscaclanhc.Tables[0].Rows)
                    {
                        if (s_idtmp != r["id"].ToString())
                        {
                            anode = new TreeNode(r["ngay"].ToString());
                            anode.Tag = r["id"].ToString();
                            Treelanhc.Nodes.Add(anode);
                        }
                        s_idtmp = r["id"].ToString();
                        anode1 = new TreeNode(r["ten"].ToString());
                        anode1.Tag = r["id"].ToString() + "^" + r["mavp"].ToString();
                        anode.Nodes.Add(anode1);
                    }
                }
                catch { }
            }
        }

        private void Treelanhc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            decimal l_tmpid = 0;
            try
            {
                Treelanhc.SelectedNode.ForeColor = Color.Red;
                if (Treelanhc.SelectedNode.Parent != null)
                {
                    Treelanhc.SelectedNode.Parent.ForeColor = Color.Red;
                    if (Treelanhc.SelectedNode.Parent.Parent != null)
                    {
                        Treelanhc.SelectedNode.Parent.Parent.ForeColor = Color.Red;
                    }
                }
            }
            catch
            {
            }
            TreeNode anode = null;
            TreeNode anode1 = null;

            anode = Treelanhc.SelectedNode;
            if (anode.Nodes.Count == 0 && anode.Parent != null) anode1 = anode.Parent;
            if (anode.Parent == null && anode.Nodes.Count > 0) anode = anode.Nodes[0];
            if (anode1 == null) anode1 = anode;
            if (anode1 != null)
            {
                l_tmpid = decimal.Parse(anode1.Tag.ToString().Split('^')[0].ToString());
            }
            f_LoadCTchuptheoID(l_tmpid);
        }
        private void f_LoadCTchuptheoID(decimal lid)
        {
            DataSet dshc = new DataSet();
            string sql = " select a.id,a.mabn,to_char(a.ngayhoichan,'dd/mm/yyyy hh24:mi') ngayhoichan,a.lamsang,a.chandoan,a.xquang,a.sieuam,a.xetnghiem,a.sdthuoccanquangco thuocco,a.sdthuoccanquangkhong thuock";
            sql += " from " + s_user + ".hoichan_cdha a ";
            sql += " where a.id =" + lid + "";
            dshc = m.get_data(sql);
            if (dshc.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dshc.Tables[0].Rows)
                {

                    txtTtlamsang.Text = r["lamsang"].ToString();
                    txtChandoan.Text = r["chandoan"].ToString();
                    txtXquang.Text = r["xquang"].ToString();
                    txtSieuam.Text = r["sieuam"].ToString();
                    txtXetnghiem.Text = r["xetnghiem"].ToString();
                    chksdthuoccqco.Checked = r["thuocco"].ToString() == "1";
                    chksdthuoccqkhong.Checked = r["thuock"].ToString() == "1";
                }
                sql = " select a.iddmbophan,b.ten from " + s_user + ".hoichan_cdha_ct a inner join " + s_user + ".dmbophan_hoichan b on a.iddmbophan=b.id";
                sql += " where a.id in(" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + ")";
                try
                {
                    foreach (DataRow dr in m.get_data(sql).Tables[0].Rows)
                    {
                        if (chksonao.Tag.ToString() == dr["iddmbophan"].ToString())
                            chksonao.Checked = true;
                        if (chkXuongdatai.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkXuongdatai.Checked = true;
                        if (chkCotsongco.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCotsongco.Checked = true;
                        if (chkLongnguc.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkLongnguc.Checked = true;
                        if (chkCungcut.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCungcut.Checked = true;
                        if (chkMuixoangaxial.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkMuixoangaxial.Checked = true;
                        if (chkhh_ss.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkhh_ss.Checked = true;
                        if (chkCotsongnguc.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCotsongnguc.Checked = true;
                        if (chkObung.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkObung.Checked = true;
                        if (chkCosuongkhop.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCosuongkhop.Checked = true;
                        if (chkMuixoangaxial_coronal.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkMuixoangaxial_coronal.Checked = true;
                        if (chkVungco.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkVungco.Checked = true;
                        if (chkCsthatlung.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkCsthatlung.Checked = true;
                        if (chkDynamic.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkDynamic.Checked = true;
                        if (chkVungchau.Tag.ToString() == dr["iddmbophan"].ToString())
                            chkVungchau.Checked = true;
                    }
                }
                catch { return; }
            }
            else
            {
                f_Cleartext();
                return;
            }
        }
    }
}