using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;
namespace dllvpkhoa_chidinh
{
    public partial class frmKhambenhchupctcocq : Form
    {
        AccessData m = new AccessData();
        Language lan = new Language();
        
        private string s_mabn = "", s_ngay = "", s_user = "", s_icd10 = "", s_mach = "", s_nhietdo = "", s_huyetap = "", s_nhiptho = "";
        private int i_userid;
        private DataSet ds_ctscanner = new DataSet();
        private DataSet dskqxn = new DataSet();
        private DataSet dsicd10 = new DataSet();
        private DataSet dsdausinhton= new DataSet();
        private decimal l_mavaovien = 0, l_maql = 0;
        public frmKhambenhchupctcocq(LibMedi.AccessData _m, string _mabn, decimal _mavaovien, decimal _maql, string _ngay, DataSet _ds, string _smaicd,int _iuserid)
        {
            InitializeComponent();
            m = _m;
            s_mabn = _mabn;
            l_mavaovien = _mavaovien;
            l_maql = _maql;
            s_ngay = _ngay;
            ds_ctscanner = _ds;
            i_userid = _iuserid;
            s_icd10 = _smaicd;
            s_user = m.user;
        }

        private void frmKhambenhchupctcocq_Load(object sender, EventArgs e)
        {
            f_loathongtincls();
            f_Thongtinbn();
            f_loadkqxn();
            f_loadICD10();
            f_Dausinhton();
            txtmach.Text = s_mach;
            txtnhietdo.Text = s_nhietdo;
            txthuyetap.Text = s_huyetap;
            txtnhiptho.Text = s_nhiptho;
            f_Loadlanthuchien();
            f_Enable(true);
            f_EnableText_Check(false);

        }
        private void f_loathongtincls()
        {
            cbLoaicls.DisplayMember = "ten";
            cbLoaicls.ValueMember = "id";
            cbLoaicls.DataSource = ds_ctscanner.Tables[0];

        }
        private void f_loadICD10()
        {
            string s_chandoan = "", s_mad10cd = "";
            string sql = " select maicd,chandoan from " + m.user + m.mmyy(s_ngay) + ".benhanpk where mabn='" + s_mabn + "' and maql=" + l_maql;
            sql += " union all select maicd,chandoan from " + m.user + m.mmyy(s_ngay) + ".cdkemtheo where maql=" + l_maql;
            sql += " union all select maicd,chandoan from " + m.user + ".cdkemtheo where maql=" + l_maql;
            dsicd10 = m.get_data(sql);
            foreach (DataRow r in dsicd10.Tables[0].Rows)
            {
                s_mad10cd += r["maicd"].ToString() + ",";
                s_chandoan += r["chandoan"].ToString() + ",";
            }
            lbicd.Text = s_mad10cd;
            txtChandoan.Text = s_chandoan;
        }
        private void f_Dausinhton()
        {
            string sql = " select mach,nhietdo,huyetap from " + m.user + ".dausinhton where maql=" + l_maql;
            dsdausinhton = m.get_data(sql);
            if (dsdausinhton.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dsdausinhton.Tables[0].Rows)
                {
                    s_mach = r["mach"].ToString();
                    s_nhietdo = r["nhietdo"].ToString();
                    s_huyetap = r["huyetap"].ToString();
                }
            }
            else
            {
                sql = " select mach,nhietdo,huyetap,nhiptho from " + m.user + ".dmgiatribt ";
                dsdausinhton = m.get_data(sql);
                foreach (DataRow r in dsdausinhton.Tables[0].Rows)
                {
                    s_mach = r["mach"].ToString();
                    s_nhietdo = r["nhietdo"].ToString();
                    s_huyetap = r["huyetap"].ToString();
                    s_nhiptho = r["nhiptho"].ToString();
                }
            }
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
        private void f_loadkqxn()
        {
            //string sql = " select id,sophieu,mabn,maql,to_char(ngay,'dd/mm/yyyy') ngay,ketluan,denghi from xxx.xn_phieu where mabn='" + s_mabn + "' and maql=" + l_maql;
            //dskqxn = m.get_data_mmyy(sql, s_ngay, s_ngay, 31);
            //try
            //{
            //    foreach (DataRow dr in dskqxn.Tables[0].Rows)
            //    {
            //        txtXetnghiem.Text += dr["ketluan"].ToString();
            //    }
            //}
            //catch { throw; }
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_EnableText_Check(true);
            f_Enable(false);
            f_Cleartext();
        }
        private void f_EnableText_Check(bool t)
        {
            chkNam.Enabled = false;
            chkNu.Enabled = false;
            cbLoaicls.Enabled = t;
            
            txtChandoan.Enabled = t;
            txthuyetap.Enabled = t;
            txtmach.Enabled = t;
            txtnhietdo.Enabled = t;
            txtnhiptho.Enabled = t;

            txtketquabun.Enabled = t;
            txtketquacreatinin.Enabled = t;

            chkCanthietchupct.Enabled = t;
            chkTacdungphu.Enabled = t;
            chktiensudiung.Enabled = t;
            chkTinhtrangmatnuoc.Enabled = t;
            chkroiloanhd.Enabled = t;
            chksuythan.Enabled = t;
            chkThaiky.Enabled = t;
            chkDautuy.Enabled = t;
            chkBenhlytm.Enabled = t;
            chktinhtrangntr.Enabled = t;

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
        private void f_Enable(bool t)
        {
            butMoi.Enabled = t;
            butLuu.Enabled = !t;
            butClose.Enabled = t;
            butBoqua.Enabled = !t;
            butSua.Enabled = t;
            butXoa.Enabled = t;
        }
        private void f_Cleartext()
        {
            chkCanthietchupct.Checked = false;
            chkTacdungphu.Checked = false;
            chktiensudiung.Checked = true;
            chkTinhtrangmatnuoc.Checked = true;
            chkroiloanhd.Checked = true;
            chksuythan.Checked = true;
            chkThaiky.Checked = true;
            chkDautuy.Checked = true;
            chkBenhlytm.Checked = false;
            chktinhtrangntr.Checked = false;

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

        private void butSua_Click(object sender, EventArgs e)
        {
            if (dtNgayhoichan.Text.Substring(0, 10) != s_ngay.Substring(0,10))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cho phép sữa khi khác ngày hội chẩn."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            f_EnableText_Check(true);
            f_Enable(false);
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_EnableText_Check(false);
            f_Enable(true);
            butMoi.Focus();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (m.upd_kbct_canquangll(decimal.Parse(cbLoaicls.SelectedValue.ToString()), s_mabn, l_mavaovien, l_maql, dtNgayhoichan.Value, txtChandoan.Text.Trim(), lbicd.Text.Trim(), chkCanthietchupct.Checked ? 1 : 0, chkTacdungphu.Checked ? 1 : 0, chktiensudiung.Checked ? 1 : 0, chkTinhtrangmatnuoc.Checked ? 1 : 0, chkroiloanhd.Checked ? 1 : 0, chksuythan.Checked ? 1 : 0, chkThaiky.Checked ? 1 : 0, chkDautuy.Checked ? 1 : 0, chkBenhlytm.Checked ? 1 : 0, chktinhtrangntr.Checked ? 1 : 0, txtmach.Text.Trim() != "" ? int.Parse(txtmach.Text.Trim()) : 0, txtnhietdo.Text.Trim() != "" ? decimal.Parse(txtnhietdo.Text.Trim()) : 0, txthuyetap.Text.Trim(), txtnhiptho.Text.Trim() != "" ? int.Parse(txtnhiptho.Text.Trim()) : 0, txtketquabun.Text.Trim(), txtketquacreatinin.Text.Trim(), i_userid))
            {
                m.execute_data("delete " + s_user + ".kbct_canquangct where id=" + cbLoaicls.SelectedValue.ToString());
                if (chksonao.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chksonao.Tag.ToString()));
                if (chkXuongdatai.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkXuongdatai.Tag.ToString()));
                if (chkCotsongco.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCotsongco.Tag.ToString()));
                if (chkLongnguc.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkLongnguc.Tag.ToString()));
                if (chkCungcut.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCungcut.Tag.ToString()));
                if (chkMuixoangaxial.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkMuixoangaxial.Tag.ToString()));
                if (chkhh_ss.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkhh_ss.Tag.ToString()));
                if (chkCotsongnguc.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCotsongnguc.Tag.ToString()));
                if (chkObung.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkObung.Tag.ToString()));
                if (chkCosuongkhop.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCosuongkhop.Tag.ToString()));
                if (chkMuixoangaxial_coronal.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkMuixoangaxial_coronal.Tag.ToString()));
                if (chkVungco.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkVungco.Tag.ToString()));
                if (chkCsthatlung.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkCsthatlung.Tag.ToString()));
                if (chkDynamic.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkDynamic.Tag.ToString()));
                if (chkVungchau.Checked)
                    m.upd_kbct_canquangct(decimal.Parse(cbLoaicls.SelectedValue.ToString()), int.Parse(chkVungchau.Tag.ToString()));
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            f_Loadlanthuchien();
            f_Enable(true);
            f_EnableText_Check(false);
        }
        
        private void butXoa_Click(object sender, EventArgs e)
        {
            if (dtNgayhoichan.Text.Substring(0, 10) != s_ngay.Substring(0,10))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cho phép xóa khi khác ngày hội chẩn."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Bạn thật sự muốn hủy."), "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    string sql = " delete from " + s_user + ".kbct_canquangct where id=" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + "";
                    if (m.execute_data(sql))
                    {
                        sql = " delete from " + s_user + ".kbct_canquangll where id=" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + "";
                        m.execute_data(sql);
                    }
                    f_loadkqxn();
                    f_loathongtincls();
                    f_EnableText_Check(true);
                    f_Cleartext();
                    f_Enable(true);
                }
                else
                    return;
            }
        }
        private void f_Loadlanthuchien()
        {
            DataSet dscaclanthuchien = new DataSet();
            Treelanhc.Nodes.Clear();
            TreeNode anode = null;
            TreeNode anode1 = null;
            string s_idtmp = "";
            string xxx = s_user + m.mmyy(s_ngay);
            string sql = "  select a.id,a.mabn,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,a.chandoan,a.icd10,a.tv_canthietchupct,a.tv_tacdungphu,a.hb_tiensudiung,a.hb_tinhtrangmatnuoc,";
            sql += " a.hb_roiloanhd,a.hb_suythan,a.hb_thaiky,a.hb_dautuy,a.hb_benhlytm,a.hb_tinhtrangntr,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.ketquabun,";
            sql += " a.ketquacreatinin,d.hoten,d.namsinh,d.phai ,f.ten tencls,g.ten tenloaicls,";
            sql += " f.id_loai idloai,e.mavp ";
            sql += " from " + s_user + ".kbct_canquangll a inner join " + s_user + ".btdbn d on a.mabn=d.mabn";
            sql += " left join " + xxx + ".v_chidinh e on a.id=e.id left join " + s_user + ".v_giavp f on e.mavp=f.id left join " + s_user + ".v_loaivp g on f.id_loai=g.id ";
            sql += " where a.mavaovien =" + l_mavaovien + " and a.maql=" + l_maql + " and a.mabn='" + s_mabn + "'";
            sql += " group by a.id,a.mabn,to_char(a.ngay,'dd/mm/yyyy hh24:mi'),a.chandoan,a.icd10,a.tv_canthietchupct,a.tv_tacdungphu,a.hb_tiensudiung,";
            sql += "a.hb_tinhtrangmatnuoc, a.hb_roiloanhd,a.hb_suythan,a.hb_thaiky,a.hb_dautuy,a.hb_benhlytm,a.hb_tinhtrangntr,a.mach,a.nhietdo,a.huyetap,";
            sql += "a.nhiptho,a.ketquabun, a.ketquacreatinin,d.hoten,d.namsinh,d.phai ,f.ten,g.ten, f.id_loai,e.mavp";
            dscaclanthuchien = m.get_data(sql);// m.get_data_mmyy(sql, s_ngay, s_ngay, 31);
            if (dscaclanthuchien.Tables[0].Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow r in dscaclanthuchien.Tables[0].Rows)
                    {
                        if (s_idtmp != r["id"].ToString())
                        {
                            anode = new TreeNode(r["ngay"].ToString());
                            anode.Tag = r["id"].ToString();
                            Treelanhc.Nodes.Add(anode);
                        }
                        s_idtmp = r["id"].ToString();
                        anode1 = new TreeNode(r["tencls"].ToString());
                        anode1.Tag = r["id"].ToString() + "^" + r["mavp"].ToString();
                        anode.Nodes.Add(anode1);
                    }
                }
                catch
                {

                }
            }
        }
        private void f_LoadCTchuptheoID(decimal _l_id)
        {
            DataTable dtTheoidll = new DataTable();
            DataTable dtTheoidct = new DataTable();
            string sql = "  select a.id,a.mabn,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,a.chandoan,a.icd10,a.tv_canthietchupct,a.tv_tacdungphu,a.hb_tiensudiung,a.hb_tinhtrangmatnuoc,";
            sql += " a.hb_roiloanhd,a.hb_suythan,a.hb_thaiky,a.hb_dautuy,a.hb_benhlytm,a.hb_tinhtrangntr,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.ketquabun,";
            sql += " a.ketquacreatinin,d.hoten,d.namsinh,d.phai ,f.ten tencls,g.ten tenloaicls,";
            sql += " f.id_loai idloai,e.mavp ";
            sql += " from " + s_user + ".kbct_canquangll a left join " + s_user + ".btdbn d on a.mabn=d.mabn";
            sql += " left join xxx.v_chidinh e on a.id=e.id left join " + s_user + ".v_giavp f on e.mavp=f.id left join " + s_user + ".v_loaivp g on f.id_loai=g.id ";
            sql += " where a.id =" + _l_id;
            dtTheoidll = m.get_data_mmyy(sql, s_ngay, s_ngay, 31).Tables[0];
            if (dtTheoidll.Rows.Count > 0)
            {
                
                foreach (DataRow r in dtTheoidll.Rows)
                {
                    lbhoten.Text = r["hoten"].ToString();
                    lbNamsinh.Text += r["namsinh"].ToString();
                    chkNam.Checked = r["phai"].ToString() == "0";
                    chkNu.Checked = r["phai"].ToString() == "1";
                    lbicd.Text = r["icd10"].ToString();
                    txtChandoan.Text = r["chandoan"].ToString();
                    cbLoaicls.SelectedValue = r["id"].ToString();
                    string s_ngayhc = r["ngay"].ToString();
                    string[] format ={ "dd/MM/yyyy HH:mm" };
                    dtNgayhoichan.Value = DateTime.ParseExact(s_ngayhc, format[0], System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
                    ///II
                    chkCanthietchupct.Checked = r["tv_canthietchupct"].ToString() == "1";
                    chkTacdungphu.Checked = r["tv_tacdungphu"].ToString() == "1";
                    ///III
                    chktiensudiung.Checked = r["hb_tiensudiung"].ToString() == "1";
                    chkTinhtrangmatnuoc.Checked = r["hb_tinhtrangmatnuoc"].ToString() == "1";
                    chkroiloanhd.Checked = r["hb_roiloanhd"].ToString() == "1";
                    chksuythan.Checked = r["hb_suythan"].ToString() == "1";
                    chkThaiky.Checked = r["hb_thaiky"].ToString() == "1";
                    chkDautuy.Checked = r["hb_dautuy"].ToString() == "1";
                    chkBenhlytm.Checked = r["hb_benhlytm"].ToString() == "1";
                    chktinhtrangntr.Checked = r["hb_tinhtrangntr"].ToString() == "1";
                    ///IV
                    txtmach.Text = r["mach"].ToString();
                    txtnhietdo.Text = r["nhietdo"].ToString();
                    txthuyetap.Text = r["huyetap"].ToString();
                    txtnhiptho.Text = r["nhiptho"].ToString();
                    txtketquabun.Text = r["ketquabun"].ToString();
                    txtketquacreatinin.Text = r["ketquacreatinin"].ToString();
                    ///V
                }
                dtTheoidct = m.get_data("select a.iddmbophan from " + s_user + ".kbct_canquangct a inner join " + s_user + ".dmbophan_hoichan b on a.iddmbophan=b.id where a.id=" + _l_id + " order by a.iddmbophan ").Tables[0];
                if(dtTheoidct.Rows.Count>0)
                {
                    foreach (DataRow r1 in dtTheoidct.Rows)
                    {
                        if (chksonao.Tag.ToString() == r1["iddmbophan"].ToString())
                            chksonao.Checked = true;
                        if (chkXuongdatai.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkXuongdatai.Checked = true;
                        if (chkCotsongco.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkCotsongco.Checked = true;
                        if (chkLongnguc.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkLongnguc.Checked = true;
                        if (chkCungcut.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkCungcut.Checked = true;

                        if (chkMuixoangaxial.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkMuixoangaxial.Checked = true;
                        if (chkhh_ss.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkhh_ss.Checked = true;
                        if (chkCotsongnguc.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkCotsongnguc.Checked = true;
                        if (chkObung.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkObung.Checked = true;
                        if (chkCosuongkhop.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkCosuongkhop.Checked = true;

                        if (chkMuixoangaxial_coronal.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkMuixoangaxial_coronal.Checked = true;
                        if (chkVungco.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkVungco.Checked = true;
                        if (chkCsthatlung.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkCsthatlung.Checked = true;
                        if (chkDynamic.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkDynamic.Checked = true;
                        if (chkVungchau.Tag.ToString() == r1["iddmbophan"].ToString())
                            chkVungchau.Checked = true;
                    }
                }
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            f_print("rptCTscannercq.rpt");
        }
        private void f_print(string s_tenrp)
        {
            DataSet dsinhc = new DataSet();
            string xxx = s_user + m.mmyy(s_ngay);
            string sql = "  select a.id,a.mabn,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,a.chandoan,a.icd10,a.tv_canthietchupct,a.tv_tacdungphu,a.hb_tiensudiung,a.hb_tinhtrangmatnuoc,";
            sql += " a.hb_roiloanhd,a.hb_suythan,a.hb_thaiky,a.hb_dautuy,a.hb_benhlytm,a.hb_tinhtrangntr,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.ketquabun,";
            sql += " a.ketquacreatinin,b.iddmbophan,c.ten,d.hoten,d.namsinh,d.phai ,f.ten tencls,g.ten tenloaicls, ";
            sql += " f.id_loai idloai,(h.sonha ||' '||h.thon||' '||i.tenpxa||' '||l.tenquan||' '||m.tentt) diachi,n.nha sodtnha,n.coquan sodtcq,n.didong,n1.tennn,n2.dantoc,h.cholam,to_char(n3.ngay,'dd/mm/yyyy') ngayxn ";
            sql += " from " + s_user + ".kbct_canquangll a left join " + s_user + ".kbct_canquangct b on a.id=b.id left join " + s_user + ".dmbophan_hoichan c on b.iddmbophan=c.id ";
            sql += " left join " + s_user + ".btdbn d on a.mabn=d.mabn";
            sql += " left join " + xxx + ".v_chidinh e on a.id=e.id left join " + s_user + ".v_giavp f on e.mavp=f.id left join " + s_user + ".v_loaivp g on f.id_loai=g.id ";
            sql += " inner join " + s_user + ".btdbn h on a.mabn=h.mabn inner join " + s_user + ".btdpxa i on h.maphuongxa=i.maphuongxa inner join " + s_user + ".btdquan l on h.maqu=l.maqu ";
            sql += " inner join " + s_user + ".btdtt m on h.matt=m.matt left join " + s_user + ".dienthoai n on a.mabn=n.mabn left join " + s_user + ".btdnn n1 on h.mann=n1.mann left join " + s_user + ".btddt n2 on h.madantoc=n2.madantoc";
            sql += " left join " + xxx + ".xn_phieu n3 on a.mabn=n3.mabn and a.maql=n3.maql ";
            sql += " where a.id in(" + decimal.Parse(cbLoaicls.SelectedValue.ToString()) + ")";
            dsinhc = m.get_data(sql);/// m.get_data_mmyy(sql, s_ngay, s_ngay, 31);
            if (dsinhc.Tables[0].Rows.Count > 0)
            {
                if (!System.IO.Directory.Exists("..//xml"))
                    System.IO.Directory.CreateDirectory("..//xml");
                dsinhc.WriteXml("..//xml//rptCTscannercq.xml", XmlWriteMode.WriteSchema);
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsinhc, s_ngay.Substring(0, 10), s_tenrp);
                f.LayDauVanTay = true;
                f.MaBenhNhan = s_mabn;
                f.LoaiChungTu = (int)LibMedi.LoaiChungTuCanKyTen.PhieuKhamBenhCTXQuang;
                f.UserID = i_userid;
                f.NgayKyGiay = s_ngay;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText(" Chưa có dữ liệu."), "Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
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
    }
}