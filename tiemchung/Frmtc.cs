using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using LibBaocao;

namespace tiemchung
{
    public partial class frmtc : Form
    {
        LibTiemchung tc = new LibTiemchung();
        LibMedi.AccessData m = new LibMedi.AccessData();
        DataSet ttbn = new DataSet();
        DataSet dsts = new DataSet();
        private DataTable dtlist = new DataTable();
        private DataTable dtletet = new DataTable();
        private Language lan = new Language();
        DataSet dshs = new DataSet();
        private int songay = 30, iTreem6, iTreem15, iKhamnhi, i_sokham, hh1, hh2, hh3, mm1, mm2, mm3, imavp_congkham, iTraituyen,i_userid=0;
        private bool b_Edit = false, b_Hoten = false, bAdmin, bAdmin_hethong, bHiends, b_soluutru, bLuutru_Mabn, b_sovaovien, bXutri_noitru, bXutri_ngoaitru, bChuyenkhoasan, bKhamthai, bTiepdon, bDanhmuc_nhathuoc, bBacsy, bSoluutru, bTudong = false, bChuky = false, bGoi, bRight, bDangky_homqua, bDuyet_khambenh, bSothe_ngay_huong, bChuyenkham_chandoan, bXutri_hen_koin, bTraituyen, bPhongkham_bangdien_hanoi, bPhongkham_bangdien_kontum, bXem_tatca = false,bTreem=false;
        private string xxx, user, nam, s_userid, s_makp = "", s_mabn="", s_ngayvv, sql, s_madoituong, s_mabs, s_nhomkho = "", ngaysrv, FileType, u00 = "U00", s_ngaydk = "", maso = "", sNhapvien_kocongkham_madoituong, s_mavp_kham = "", ngay_reset_phieu38 = "", s_msg = "", ngays,tu;
        //private short s_port = 1;
        //private int i_userid, i_mabv, i_maba, i_bangoaitru, iChidinh, iHaophi;
        private decimal l_maql = 0, l_matd = 0;//, d_id = 0, lTraituyen = 0;
        //private decimal Congkham = 0, bhyttra, bntra;
        private bool bPhongkham_khongduocxutri_chuyenvien = false, bThuphi_kham, bChuathanhtoan_khongcho_nhanbenh = false, bDainmau38_khongcho_chidinh_cls = false;
        private bool b_khambenh, b_bacsi, b_trongngoai, bDenngay_sothe, bChandoan, b701424, bNew, bSuadoituong, bPhongkham_chidinh, bSothe_mabn, bInchitiet, bDichvu_vpkb, bIn = false, bCongkham, bClear, bChuyenkham_dscho, bXutri_phongluu, bChuyenkham_thuphi, bTaikham_v_chidinh, bTaikham_chiphi_inrieng, bPhongkham_chandoan, bChuyenkham_tinhcongkham = false, bChuyenkham_tinh_congkham_dtthuphi = false, bXemlai_toa = false, bChandoan_kemtheo_icd10 = true;
        //private bool bNgtru_dt_makp, , bNhapvien_kocongkham;
        //private bool bTaikham_hen;
        //private int dt_ngtru = 0, Taikham_songay;
        //private string makp_kho_dt, madoituong_hen;
        //private bool bHaophi, bHaophi_doituongvao;
        private string s_icd_noichuyenden, s_icd_chinh, s_icd_kemtheo, s_mabv, s_noicap, s_chonxutri = "", s_tungay, d_mmyy, khoa_save = "", xutri_save = "", pathImage, s_ngaymakp = "", ngay1, ngay2, ngay3;

        public frmtc()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        
        public frmtc(string _s_nhomkho)
        {
            InitializeComponent();
            s_nhomkho = _s_nhomkho;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        public frmtc(string _s_nhomkho,string _mabn,decimal _matd,int _userid)
        {
            InitializeComponent();
            s_nhomkho = _s_nhomkho;
            l_matd = _matd;
            s_mabn = _mabn;
            i_userid = _userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        
        private void btKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (s_mabn != "" && mabn3.Text!="" && mabn2.Text!="")
            {                
                string benh = "";
                string diung = "";
                string phanung = "";
                string dongkinh = "";
                string ungthu = "";
                string benh3thang = "";
                string benh1nam = "";
                string thai = "";
                string vacxin = "";
                //string khongro="#";
                #region bệnh
                if (rdkbenh.Checked)
                {
                    benh = "0";

                }
                else if (rdkrbenh.Checked)
                {
                    benh = "1";
                }
                else if (rdcbenh.Checked)
                {
                    if (txtbenh.Text.ToString() == "")
                    {
                        benh = " ";
                    }
                    else
                    {
                        benh = txtbenh.Text;
                    }
                }
                # endregion end bệnh
                #region dị ứng
                if (rdc2.Checked)
                {
                    if (txtdiung.Text.ToString() == "") { diung = " "; }
                    else { diung = txtdiung.Text; }
                }
                else if (rdk2.Checked) { diung = "0"; }
                else if (rdkr2.Checked) { diung = "1"; }
                #endregion dị ứng
                #region phản ứng
                if (rdc3.Checked)
                {
                    if (txtphanung.Text.ToString() == "") { phanung = " "; }
                    else { phanung = txtphanung.Text; }
                }
                else if (rdk3.Checked) { phanung = "0"; }
                else if (rdkr3.Checked) { phanung = "1"; }
                #endregion phản ứng
                #region động kinh
                if (rdc4.Checked)
                {
                    if (txtdongkinh.Text.ToString() == "") { dongkinh = " "; }
                    else { dongkinh = txtdongkinh.Text; }
                }
                else if (rdk4.Checked) { dongkinh = "0"; }
                else if (rdkr4.Checked) { dongkinh = "1"; }
                #endregion động kinh
                #region ung thư
                if (rdc5.Checked)
                {
                    if (txtungthu.Text.ToString() == "") { ungthu = " "; }
                    else { ungthu = txtungthu.Text; }
                }
                else if (rdk5.Checked) { ungthu = "0"; }
                else if (rdkr5.Checked) { ungthu = "1"; }
                #endregion ung thư
                #region bệnh 3 tháng
                if (rdc6.Checked)
                {
                    if (txtbenh3thang.Text.ToString() == "") { benh3thang = " "; }
                    else { benh3thang = txtbenh3thang.Text; }
                }
                else if (rdk6.Checked) { benh3thang = "0"; }
                else if (rdkr6.Checked) { benh3thang = "1"; }
                #endregion bệnh 3 tháng
                #region bệnh 1 năm
                if (rdc7.Checked)
                {
                    if (txtbenh1nam.Text.ToString() == "") { benh1nam = " "; }
                    else { benh1nam = txtbenh1nam.Text; }
                }
                else if (rdk7.Checked) { benh1nam = "0"; }
                else if (rdkr7.Checked) { benh1nam = "1"; }
                #endregion bệnh 1 năm
                #region thai
                if (rdc8.Checked)
                {
                    if (txtthai.Text.ToString() == "") { thai = " "; }
                    else { thai = txtthai.Text; }
                }
                else if (rdk8.Checked) { thai = "0"; }
                else if (rdkr8.Checked) { thai = "1"; }
                #endregion thai
                #region vacxin
                if (rdc9.Checked)
                {
                    if (txtvacxin.Text.ToString() == "") { vacxin = " "; }
                    else { vacxin = txtvacxin.Text; }
                }
                else if (rdk9.Checked) { vacxin = "0"; }
                else if (rdkr9.Checked) { vacxin = "1"; }
                #endregion vacxin
                if (bNew)
                {
                    l_maql = m.get_maqltc(s_mabn, txtNgay.Text);
                }
                tc.upd_tiemchung(s_mabn, (decimal)l_maql, (decimal)l_matd, txtNgay.Text, benh, diung, phanung, dongkinh, ungthu, benh3thang, benh1nam, thai, vacxin, txtGhichu.Text.Trim(), i_userid);
                btLuu.Enabled = false;
                panelCauhoi.Enabled = false;
            } 
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập mã bệnh nhân!"),s_msg);
                ReFesh();
            }
            butRef_Click(null, null);
            load_tree_tc();
        }

        private void rdcbenh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdcbenh.Checked)
            {
                txtbenh.Visible = true;
            }
            else
            {
                txtbenh.Visible = false;
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (treevLanTC.SelectedNode == null) return;
            panelCauhoi.Enabled = true;
            txtNgay.Value =m.StringToDateTime(treevLanTC.SelectedNode.Text);
            foreach (DataRow r in dshs.Tables[0].Select("ngay='" + txtNgay.Text + "'"))
            {
                //bệnh
                bNew = false;
                l_maql = decimal.Parse(r["maql"].ToString());
                l_matd = decimal.Parse(r["mavaovien"].ToString());
                if (r["benh"].ToString() == "0") { rdkbenh.Checked = true; }
                else if (r["benh"].ToString() == "1") { rdkrbenh.Checked = true; }
                else
                {
                    rdcbenh.Checked = true;
                    txtbenh.Text = r["benh"].ToString();
                }
                //
                //dị ứng
                if (r["diung"].ToString() == "0") { rdk2.Checked = true; }
                else if (r["diung"].ToString() == "1") { rdkr2.Checked = true; }
                else { rdc2.Checked = true; txtdiung.Text = r["diung"].ToString(); }//
                //phản ứng thuốc
                if (r["phanungthuoc"].ToString() == "0") { rdk3.Checked = true; }
                else if (r["phanungthuoc"].ToString() == "1") { rdkr3.Checked = true; }
                else { rdc3.Checked = true; txtphanung.Text = r["phanungthuoc"].ToString(); }//
                //dộng kinh
                if (r["dongkinh"].ToString() == "0") { rdk4.Checked = true; }
                else if (r["dongkinh"].ToString() == "1") { rdkr4.Checked = true; }
                else { rdc4.Checked = true; txtdongkinh.Text = r["dongkinh"].ToString(); }//
                //ung thư
                if (r["ungthu"].ToString() == "0") { rdk5.Checked = true; }
                else if (r["ungthu"].ToString() == "1") { rdkr5.Checked = true; }
                else { rdc5.Checked = true; txtungthu.Text = r["ungthu"].ToString(); }//
                //bệnh 3 tháng
                if (r["benhbathang"].ToString() == "0") { rdk6.Checked = true; }
                else if (r["benhbathang"].ToString() == "1") { rdkr6.Checked = true; }
                else { rdc6.Checked = true; txtbenh3thang.Text = r["benhbathang"].ToString(); }//
                //bệnh 1 năm
                if (r["benhmotnam"].ToString() == "0") { rdk7.Checked = true; }
                else if (r["benhmotnam"].ToString() == "1") { rdkr7.Checked = true; }
                else { rdc7.Checked = true; txtbenh1nam.Text = r["benhmotnam"].ToString(); }//
                //thai
                if (r["thai"].ToString() == "0") { rdk8.Checked = true; }
                else if (r["thai"].ToString() == "1") { rdkr8.Checked = true; }
                else { rdc8.Checked = true; txtthai.Text = r["thai"].ToString(); }//
                //vac xin
                if (r["vacxin"].ToString() == "0") { rdk9.Checked = true; }
                else if (r["vacxin"].ToString() == "1") { rdkr9.Checked = true; }
                else { rdc9.Checked = true; txtvacxin.Text = r["vacxin"].ToString(); }//
                bTreem = _bTreem(namsinh.Text, treevLanTC.SelectedNode.Text.Substring(0,10));
                txtGhichu.Text = r["nhanxet"].ToString();
                if (bTreem)
                {
                    label12.Visible = txtthai.Visible = panel9.Visible = false;
                }
                else
                {
                    label12.Visible = txtthai.Visible = panel9.Visible = true;
                }
           }        

        }

        private bool _bTreem(string _namsinh,string _ngaykham)
        {
            if (m.StringToDate(_ngaykham).Year - int.Parse(_namsinh) < iTreem15)
                return true;
            else return false;
        }

        private void rdc2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdc2.Checked)
            {
                txtdiung.Visible = true;
            }
            else
            {
                txtdiung.Visible = false;
            }
        }

        private void rdc3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdc3.Checked)
            {
                txtphanung.Visible = true;
            }
            else
            {
                txtphanung.Visible = false;
            }
        }

        private void rdc4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdc4.Checked)
            {
                txtdongkinh.Visible = true;
            }
            else
            {
                txtdongkinh.Visible = false;
            }
        }

        private void rdc5_CheckedChanged(object sender, EventArgs e)
        {
            if (rdc5.Checked)
            {
                txtungthu.Visible = true;
            }
            else
            {
                txtungthu.Visible = false;
            }
        }

        private void rdc6_CheckedChanged(object sender, EventArgs e)
        {
            if (rdc6.Checked)
            {
                txtbenh3thang.Visible = true;
            }
            else
            {
                txtbenh3thang.Visible = false;
            }
        }

        private void rdc7_CheckedChanged(object sender, EventArgs e)
        {
            if (rdc7.Checked)
            {
                txtbenh1nam.Visible = true;
            }
            else
            {
                txtbenh1nam.Visible = false;
            }
        }

        private void rdc8_CheckedChanged(object sender, EventArgs e)
        {
            if (rdc8.Checked)
            {
                txtthai.Visible = true;
            }
            else
            {
                txtthai.Visible = false;
            }
        }

        private void rdc9_CheckedChanged(object sender, EventArgs e)
        {
            if (rdc9.Checked)
            {
                txtvacxin.Visible = true;
            }
            else
            {
                txtvacxin.Visible = false;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            danhsach.Visible = true;
            ReFesh();
            panelCauhoi.Enabled = true;
            btLuu.Enabled = true;
            mabn2.Focus();
            //Enable
            panel1.Enabled = panel2.Enabled = panel3.Enabled = panel5.Enabled = panel6.Enabled = true;
            panel7.Enabled = panel8.Enabled = panel9.Enabled = panel10.Enabled = true;
            //
        }

        private void ReFesh()
        {           
            rdkbenh.Checked = true; rdk2.Checked = true; rdk3.Checked = true; rdk4.Checked = true; rdk5.Checked = true; rdk6.Checked = true; rdk7.Checked = true; rdk8.Checked = true; rdk9.Checked = true;
            
        }
        private void empText()
        {
            txtbenh.Text = "";
            txtbenh1nam.Text = "";
            txtbenh3thang.Text = "";
            txtdiung.Text = "";
            txtdongkinh.Text = "";
            txtphanung.Text = "";
            txtthai.Text = "";
            txtungthu.Text = "";
            txtvacxin.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReFesh();
            btLuu.Enabled = false;
            danhsach.Enabled = true;
            maskedBox1.Text = ""; txtten.Text = ""; mabn3.Text = "";
        }

        private void ngaysinh_Validated(object sender, EventArgs e)
        {       
        } 
        private void btXoa_Click(object sender, EventArgs e)
        {
            int tmp = treevLanTC.SelectedNode.Index;
            treevLanTC.Nodes[tmp].Remove();

        }

        private void butRef_Click(object sender, EventArgs e)
        {
            load_ref();
            list.Focus();
        }
        private bool load_tim_mabn()
        {
            string s_mann = mann.Text;
            load_btdnn(1);
            tennn.SelectedValue = s_mann;
            if (!b_Edit)
            {
                s_ngayvv = "";
                s_mabn = mabn2.Text + mabn3.Text;
                DataTable dt = m.get_Timmabn(txtten.Text, maskedBox1.Text, namsinh.Text, s_mabn).Tables[0];
                
            }
            return false;
        }
        private void load_btdnn(int i)
        {
            if (i == 0) tennn.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv order by mann").Tables[0];
            else
            {
                if (namsinh.Text != "")
                {
                    if (DateTime.Now.Year - int.Parse(namsinh.Text) < iTreem6)
                        tennn.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv where mannbo='01' order by mann").Tables[0];
                    else if (DateTime.Now.Year - int.Parse(namsinh.Text) < iTreem15)
                    {
                        bTreem = true;
                        tennn.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
                    }
                    else
                    {
                        bTreem = false;
                        tennn.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];
                    }
                }
            }
        }
        private void load_dm()
        {
            
            if (m.Mabv.Length > 3) 
                //mabn1.Text = m.Mabv_so.ToString();
            mabn2.Text = DateTime.Now.Year.ToString().Substring(2, 2);

            tennn.DisplayMember = "TENNN";
            tennn.ValueMember = "MANN";
            load_btdnn(0);

            tendantoc.DisplayMember = "DANTOC";
            tendantoc.ValueMember = "MADANTOC";
            tendantoc.DataSource = m.get_data("select * from " + m.user + ".btddt order by madantoc").Tables[0];
            tendantoc.SelectedValue = "25";

            tentinh.DisplayMember = "TENTT";
            tentinh.ValueMember = "MATT";
            tentinh.DataSource = m.get_data("select * from " + m.user + ".btdtt order by tentt").Tables[0];
            tentinh.SelectedValue = m.Mabv.Substring(0, 3);

            tenquan.DisplayMember = "TENQUAN";
            tenquan.ValueMember = "MAQU";
            load_quan();

            tenpxa.DisplayMember = "TENPXA";
            tenpxa.ValueMember = "MAPHUONGXA";
            load_pxa();

            tennuoc.DisplayMember = "TEN";
            tennuoc.ValueMember = "MA";            
            tennuoc.DataSource = m.get_data("select * from " + m.user + ".dmquocgia order by ma").Tables[0];
            tennuoc.SelectedIndex = -1;

            tentqx.DisplayMember = "TEN";
            tentqx.ValueMember = "MAPHUONGXA";

            //danhsach.Visible = bHiends;
           // if (bHiends)
            //{
                list.DisplayMember = "HOTEN";
                list.ValueMember = "STT";
                list.ColumnWidths[0] = 40;
                list.ColumnWidths[1] = 70;
                list.ColumnWidths[2] = list.Width - 190;
                list.ColumnWidths[3] = 0;
                list.ColumnWidths[4] = 0;
                list.ColumnWidths[5] = 0;
                list.ColumnWidths[6] = 90;
                list.ColumnWidths[7] = 0;
                list.SetSensive2(5, '3', Color.DarkRed);                
                list.SetSensive1(4, '?', Color.Blue);
                list.SetSensive(5, '1', Color.Red);
                //list.SetSensive(5);
                load_ref();
                if (list.Items.Count == 0) danhsach.Visible = true;
                else list.Focus();
            //}
        }
        private void load_ref()
        {
            string _ngay = m.f_ngay;
            ngays = m.ngayhienhanh_server.Substring(0, 10); tu = m.DateToString("dd/MM/yyyy", m.StringToDate(ngays).AddDays(-1));
            sql = "select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten,";
            sql += " case when a.noitiepdon=16 then 'x' else 'y' end as noitiepdon,";
            sql += " a.done,case when a.done='?' then '2' else case when a.done='d' then '3' else case when a.noitiepdon=16 then '1' else '4' end end end as tt,";
            sql += " case when a.done='?' then 'Đi tiêm chủng' else case when a.done='d' then 'Có kết quả' else case when a.noitiepdon=16 then 'Tái khám' else 'Chờ khám' end end end as tk,";
            sql += " a.makp,to_char(a.ngay,'yymmddhh24:mi') as yymmdd,a.oid as stt,a.mavaovien";
            sql += " from xxx.tiepdon a," + user + ".btdbn b, medibv.btdkp_bv c   ";
            sql += " where a.mabn=b.mabn and (a.done is null or a.done in ('?','d')) and a.makp=c.makp and c.tiemchung=1 and a.mavaovien not in(select mavaovien from "+m.user+".benhantc)";
            if (bDangky_homqua) sql += " and " + m.for_ngay("a.ngay", "'" + _ngay + "'") + " between to_date('" + tu.Substring(0, 10) + "','" + _ngay + "') and to_date('" + ngays.Substring(0, 10) + "','" + _ngay + "')";
            else sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + ngays.Substring(0, 10) + "'";
            //sql += " and a.noitiepdon in (0,1,5,16,9,10,11,12,15) ";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            sql += " order by tt,makp,yymmdd,mabn";
            dtlist = m.get_data_mmyy(sql, tu, ngays, false).Tables[0];
            list.DataSource = dtlist;
            lblso.Text = list.Items.Count.ToString();
        }
        private void load_quan()
        {
            tenquan.DataSource = m.get_data("select * from " + m.user + ".btdquan where matt='" + tentinh.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
        }

        private void load_pxa()
        {
            tenpxa.DataSource = m.get_data("select * from " + m.user + ".btdpxa where maqu='" + tenquan.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
        }

        private void mabn2_Validated(object sender, EventArgs e)
        {
            mabn2.Text = mabn2.Text.PadLeft(2, '0');
        }

        bool ok = false;
        private void mabn3_Validated(object sender, EventArgs e)
        {
            ok = false;
            ReFesh();
            empText();
            nam = "";
            if (bChuyenkhoasan) phai.SelectedIndex = 1;
            //load_btdnn(0);
            if (mabn3.Text == "") return;
            bNew = true;
            mabn3.Text = mabn3.Text.PadLeft(6, '0');
            s_mabn = mabn2.Text + mabn3.Text;
            DataSet dsbn = new DataSet();
            dsbn = m.get_data("select mabn from " + m.user + ".btdbn where mabn='" + s_mabn + "'");
            if (dsbn.Tables[0].Rows.Count == 0) { MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy thông tin bệnh nhân!"),s_msg); return; }

            emp_text(true);
            if (load_mabn())
            {
                if (bPhongkham_chidinh && dtpNgay.Text != "")
                {
                    if (!kiemtra_dk(dtpNgay.Text))
                    {
                        bool bExit = true;
                        if (bDangky_homqua)
                            bExit = !kiemtra_dk(m.DateToString("dd/MM/yyyy", m.StringToDate(dtpNgay.Text).AddDays(-1)));
                        if (bExit)
                        {
                            //MessageBox.Show(lan.Change_language_MessageText("Người bệnh chưa được chỉ định khám ") + " " + tenkp.Text, LibMedi.AccessData.Msg);
                            button1_Click(sender, e);
                            return;
                        }
                    }
                }               
                SendKeys.Send("{Home}");
            }
            try
            {
                if (m.getrowbyid(dshs.Tables[0], "mabn like '" + s_mabn + "%'") != null)
                {
                    ok = true;
                }
            }
            catch { }
            load_tree_tc();
            //Enable
            panel1.Enabled = panel2.Enabled = panel3.Enabled = panel5.Enabled = panel6.Enabled = true;
            panel7.Enabled = panel8.Enabled = panel9.Enabled = panel10.Enabled = true;
            if (DateTime.Now.Year - int.Parse(namsinh.Text) < iTreem15)
            {
                bTreem = true;
            }
            if (bTreem)
            {
                label12.Visible = txtthai.Visible = panel9.Visible = false;
            }
            else
            {
                label12.Visible = txtthai.Visible = panel9.Visible = true;
            }
            txtGhichu.Text = "";
        }

        private void load_tree_tc()
        {
            try
            {
                treevLanTC.Nodes.Clear();
                dshs = m.get_data("select to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,a.*,b.hoten from " + m.user + ".benhantc a," + m.user + ".dlogin b  where mabn='" + s_mabn + "' and a.nguoinhap=b.id order by a.ngay desc ");
                for (int i = 0; i < dshs.Tables[0].Rows.Count; i++)
                {
                    treevLanTC.Nodes.Add(dshs.Tables[0].Rows[i]["ngay"].ToString());
                }
                if (dshs.Tables[0].Rows.Count != 0 && ok)
                {
                    treevLanTC.SelectedNode = treevLanTC.Nodes[0];
                }
            }
            catch //(Exception exx)
            { }
        }

        private bool kiemtra_dk(string ngay)
        {
            if (m.bMmyy(ngay))
            {
                sql = "select * from " + user + m.mmyy(ngay) + ".tiepdon ";
                sql += " where to_char(ngay,'dd/mm/yyyy')='" + ngay + "'";
                sql += " and noitiepdon in (0,1,5,16,9,10,11,12,15) ";//and makp='" + makp.Text + "'";
                sql += " and mabn='" + mabn2.Text + mabn3.Text + "'";
                return m.get_data(sql).Tables[0].Rows.Count > 0;
            }
            else return false;
        }

        private bool load_mabn()
        {
            bool ret = false;
            foreach (DataRow r in m.get_data("select * from " + m.user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
            {
                txtten.Text = r["hoten"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                if (r["ngaysinh"].ToString() != "")
                {
                    maskedBox1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngaysinh"].ToString()));
                    string tuoivao = m.Tuoivao("", maskedBox1.Text);
                    tuoi.Text = tuoivao.Substring(2).PadLeft(3, '0');
                    loaituoi.SelectedIndex = int.Parse(tuoivao.Substring(0, 1));
                }
                else
                {
                    tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
                    loaituoi.SelectedIndex = 0;
                }
                manuoc.Text = tennuoc.SelectedValue.ToString();
                nam = r["nam"].ToString().Trim();
                phai.SelectedIndex = int.Parse(r["phai"].ToString());
                tennn.SelectedValue = r["mann"].ToString();
                mann.Text = r["mann"].ToString();
                tendantoc.SelectedValue = r["madantoc"].ToString();
                madantoc.Text = r["madantoc"].ToString();
                sonha.Text = r["sonha"].ToString();
                thon.Text = r["thon"].ToString();
                cholam.Text = r["cholam"].ToString();
                tentinh.SelectedValue = r["matt"].ToString();
                matt.Text = r["matt"].ToString();
                tenquan.SelectedValue = r["maqu"].ToString();
                maqu2.Text = r["maqu"].ToString();
                tenpxa.SelectedValue = r["maphuongxa"].ToString();
                mapxa2.Text = r["maphuongxa"].ToString();

                if (int.Parse(tuoi.Text) > 12 && r["phai"].ToString() == "1")
                { panelCau9.Visible = true; }
                else { panelCau9.Visible = false; }
                ret = true;
                break;
            }
            //if (ret)
            //{
            //    sql = "select b.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".hiendien a," + user + ".btdkp_bv b," + user + ".benhandt c where a.maql=c.maql and a.makp=b.makp and a.nhapkhoa=1 and a.xuatkhoa=0 and c.loaiba=1";
            //    sql += " and a.mabn='" + s_mabn + "'";
            //}
            if (ret && manuoc.Enabled)
                foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue = r1["id_nuoc"].ToString();
            return ret;
        }
        private void emp_text(bool skip)
        {
            bIn = false;
            ena_but(true);
            if (!skip)
            {
                mabn2.Text = DateTime.Now.Year.ToString().Substring(2, 2);
                mabn3.Text = "";
            }
            s_ngaymakp = "";
            //this.toolTip1.SetToolTip(this.treeView1, "Ctrl + T : Đơn thuốc");
            loaituoi.SelectedIndex = 0;
            txtten.Text = "";
            maskedBox1.Text = "";
            namsinh.Text = "";
            tuoi.Text = "";
            sonha.Text = "";
            thon.Text = "";
            cholam.Text = "";
            tentqx.SelectedIndex = -1;
            tqx.Text = "";
            l_maql = 0;
            
            //l_matd = 0;
            b_Edit = false;

            tentinh.SelectedValue = m.Mabv.Substring(0, 3);
            tendantoc.SelectedValue = "25";
            tennuoc.SelectedValue = "VN";         
            load_quan();
            load_pxa();
            emp_vv();
            emp_rv();
        }
        private void ena_but(bool ena)
        {
            btLuu.Enabled = ena;
            button1.Enabled = ena;
            //icd_chinh.Enabled = ena;
            //cd_chinh.Enabled = ena;
            //xutri.Enabled = ena;
            //maxutri.Enabled = ena;
            //icd_kemtheo.Enabled = ena;
            //cd_kemtheo.Enabled = ena;
            //butIn.Enabled = !ena;
            //if (bInchitiet) butInchitiet.Enabled = !ena;
            //butTiep.Enabled=butKetthuc.Enabled=butIncv.Enabled = !ena;
            //lydo.Enabled = ena;
        }
        private void emp_vv()
        {
            s_ngayvv = m.ngayhienhanh_server;
            dtpNgay.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
            s_ngayvv = "";//ngayvv.Text;
            quanhe.Text = "";
            qh_hoten.Text = "";
            qh_diachi.Text = "";
            qh_dienthoai.Text = "";
            s_icd_noichuyenden = "";
        }

        private void emp_rv()
        {

            s_icd_chinh = "";

            s_icd_kemtheo = "";
            khoa_save = ""; xutri_save = "";
            s_mabv = ""; s_noicap = "";

        }

        private void mabn3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReFesh();
                int yyyy = int.Parse(namsinh.Text.ToString());
                string sql = "select phai," + yyyy + "-to_number(namsinh) as tuoi from medibv.btdbn where mabn='" + s_mabn + "'";
                ttbn = m.get_data(sql);

                if (int.Parse(ttbn.Tables[0].Rows[0]["tuoi"].ToString()) > 12 && ttbn.Tables[0].Rows[0]["phai"].ToString() == "1")
                { panelCau9.Visible = true; }
                else { panelCau9.Visible = false; }
                for (int i = 0; i < treevLanTC.Nodes.Count; i++)
                {
                    treevLanTC.Nodes[i].Remove();
                }
                dshs = m.get_data("select * from " + m.user + ".benhantc where mabn='" + s_mabn + "'");
                if (dshs.Tables.Count == 0 || dshs.Tables[0].Rows.Count <= 0)
                {
                    // MessageBox.Show("Không có số liệu"); return;
                }
                for (int i = 0; i < dshs.Tables[0].Rows.Count; i++)
                {
                    treevLanTC.Nodes.Add(dshs.Tables[0].Rows[i]["ngay"].ToString());
                }
            }
        }

        private void frmtc_Load(object sender, EventArgs e)
        {
            s_msg = LibMedi.AccessData.Msg;
            iTreem6 = m.iTreem6;
            iTreem15 = m.iTreem15;

            // btThem.Enabled = false;
            btLuu.Enabled = false;
            user = m.user;
            //dtpNgay.Text = m.Ngaygio_hienhanh;
            mabn3.Focus();
            load_dm();
            load_tiepdon(m.Ngayhienhanh, true);

            //Enable
            panel1.Enabled = panel2.Enabled = panel3.Enabled = panel5.Enabled = panel6.Enabled = false;
            panel7.Enabled = panel8.Enabled = panel9.Enabled = panel10.Enabled = false;
            //
            cbophongtc.DisplayMember = "TENKP";
            cbophongtc.ValueMember = "MAKP";
            cbophongtc.DataSource = m.get_data("select makp,tenkp from " + user + ".btdkp_bv where loai=1").Tables[0];

            dsts.ReadXml("..//..//..//xml//thongso.xml");
            cbophongtc.SelectedValue = dsts.Tables[0].Rows[0]["cbophongtc"].ToString();
            if (s_mabn != "")
            {
                mabn2.Text = s_mabn.Substring(0, 2);
                mabn3.Text = s_mabn.Substring(2);
                mabn3_Validated(null, null);
                danhsach.Enabled = false;
            }
            
        }

        private void phai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (phai.SelectedIndex == -1) phai.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void tennuoc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                manuoc.Text = tennuoc.SelectedValue.ToString();
            }
            catch { manuoc.Text = ""; }
        }
        private void ena_nuoc(bool ena)
        {
            manuoc.Enabled = ena;
            tennuoc.Enabled = ena;
        }
        private void tendantoc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                madantoc.Text = tendantoc.SelectedValue.ToString();
                if (madantoc.Text == "55") ena_nuoc(true);
                else
                {
                    ena_nuoc(false);
                    tennuoc.SelectedValue = "VN";
                }
            }
            catch { madantoc.Text = ""; }
        }

        private void tenquan_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                maqu1.Text = tenquan.SelectedValue.ToString().Substring(0, 3);
                maqu2.Text = tenquan.SelectedValue.ToString().Substring(3, 2);
                load_pxa();
            }
            catch
            {
                maqu1.Text = "";
                maqu2.Text = "";
            }
        }

        private void tentqx_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                tentinh.SelectedValue = tentqx.SelectedValue.ToString().Substring(0, 3);
                tenquan.SelectedValue = tentqx.SelectedValue.ToString().Substring(0, 5);
                tenpxa.SelectedValue = tentqx.SelectedValue.ToString();
            }
            catch { tqx.Text = ""; }
        }

        private void tentinh_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                matt.Text = tentinh.SelectedValue.ToString();
                load_quan();
            }
            catch { matt.Text = ""; }
        }

        private void tenpxa_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                mapxa1.Text = tenpxa.SelectedValue.ToString().Substring(0, 5);
                mapxa2.Text = tenpxa.SelectedValue.ToString().Substring(5, 2);
            }
            catch
            {
                mapxa1.Text = "";
                mapxa2.Text = "";
            }
        }

        private void tennn_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                mann.Text = tennn.SelectedValue.ToString();
            }
            catch { mann.Text = ""; }
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            empText();
            gan_mabn();
            l_matd = decimal.Parse(m.getrowbyid(dtlist, "mabn='" + s_mabn + "'")["mavaovien"].ToString());
        }
        private void gan_mabn()
        {
            try
            {
                DataRow r1 = m.getrowbyid(dtlist, "stt=" + decimal.Parse(list.SelectedValue.ToString()));
                s_mabn = (r1 != null) ? r1["mabn"].ToString() : "";
                if (s_mabn != "")
                {
                    mabn2.Text = s_mabn.Substring(0, 2);
                    mabn3.Text = s_mabn.Substring(2);
                    mabn3_Validated(null, null);
                    //string ngaysrv = m.ngayhienhanh_server, zzz = user + m.mmyy(ngaysrv), s = "";
                    //sql = "select mavaovien,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + m.user + ".benhantc where mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + ngaysrv.Substring(0, 10) + "'";
                    //foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    //{
                    //    l_matd = decimal.Parse(r["mavaovien"].ToString());
                    //    l_maql = decimal.Parse(r["maql"].ToString());
                    //    s_ngayvv = dtpNgay.Text;
                    //    dtpNgay.Text = r["ngay"].ToString().Substring(0, 10);
                    //    giovv.Text = (r["ngay"].ToString().Length <= 10) ? giovv.Text : r["ngay"].ToString().Substring(11);
                    //    s = s_ngayvv;
                    //    break;
                    //}
                    //if (s != "")
                    //{
                    //    load_vv_maql(true);
                    //    dtpNgay.Text = s;
                    //}
                    //else
                    //{
                    //    load_tiepdon(m.Ngayhienhanh, false);
                    //    if (l_matd == 0) giovv_Validated(null, null);
                    //}
                }
                else
                {
                    danhsach.Visible = true;
                    mabn2.Focus();
                }
                btThem_Click(null, null);
            }
            catch (Exception ex)
            {
                danhsach.Visible = true;
            }
        }
        private void load_tiepdon(string m_ngay, bool skip)
        {
             s_ngaydk = "";
            string xxx = user + m.mmyy(m_ngay);
            string _ngay = m.f_ngay;
            string ngays = m_ngay, tu = m.DateToString("dd/MM/yyyy", m.StringToDate(ngays).AddDays(-1));

            sql = "select * from xxx.tiepdon where ";
            if (bDangky_homqua) sql += "" + m.for_ngay("ngay", "'" + _ngay + "'") + " between to_date('" + tu.Substring(0, 10) + "','" + _ngay + "') and to_date('" + ngays.Substring(0, 10) + "','" + _ngay + "')";
            else sql += " to_char(ngay,'dd/mm/yyyy')='" + ngays.Substring(0, 10) + "'";
            if (s_makp.ToString() != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            sql += " and noitiepdon in (0,1,5,16,9,10,11,12,15) and (done is null or done in ('?','d')) order by ngay desc";
            foreach (DataRow r in m.get_data_mmyy(sql, tu, m_ngay, false).Tables[0].Rows)
            {
                s_ngaydk = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                if (skip)
                {
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                    dtpNgay.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = m.ngayhienhanh_server.Substring(11);
                }
                string stuoi = r["tuoivao"].ToString();
                if (stuoi.Length == 4)
                {
                    tuoi.Text = stuoi.Substring(0, 3);
                    loaituoi.SelectedIndex = Math.Min(int.Parse(stuoi.Substring(3, 1)), 3);
                }
                //l_maql = decimal.Parse(r["maql"].ToString());
                //l_matd = decimal.Parse(r["mavaovien"].ToString());
               
                break;
            }           
        }
        private void load_vv_maql(bool skip)
        {
            //emp_vv();
            emp_rv();
            if (dtpNgay.Text == "") return;
            ena_but(true);
            DataRow r1;
            string s_xutri = "", xxx = user + m.mmyy(dtpNgay.Text);
            sql = "select a.*,b.soluutru,c.chandoan as k_chandoan,c.maicd as k_maicd from " + xxx + ".benhanpk a inner join " + xxx + ".lienhe b on a.maql=b.maql left join " + xxx + ".cdkemtheo c on a.maql=c.maql where a.maql=" + l_maql;
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                if (!skip)
                {
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                    dtpNgay.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
                }
                l_matd = decimal.Parse(r["mavaovien"].ToString());
               s_xutri = m.get_xutri(dtpNgay.Text, l_maql, 0).ToString().Trim().PadLeft(2, '0');
                if (s_xutri == "" && r["ttlucrv"].ToString().PadLeft(2, '0') != "00") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
                else
                {
                    //if (s_xutri.IndexOf("03,") != -1 && bTaikham_hen)
                    //{
                        //if (madoituong_hen == "" || madoituong_hen.IndexOf(madoituong.Text.ToString().PadLeft(2, '0')) != -1)
                        //{
                        //    hen.Visible = true;
                        //    foreach (DataRow r2 in m.get_data("select * from " + xxx + ".hen where maql=" + l_maql).Tables[0].Rows)
                        //    {
                        //        hen_ngay.Value = decimal.Parse(r2["songay"].ToString());
                        //        hen_ghichu.Text = r2["ghichu"].ToString();
                        //        hen_loai.SelectedIndex = int.Parse(r2["loai"].ToString());
                        //        chkTiepdon.Checked = r2["tiepdon"].ToString() == "1";
                        //        break;
                        //    }
                        //}
                    //}
                    if (s_xutri.IndexOf("05,") != -1 || s_xutri.IndexOf("02,") != -1 || s_xutri.IndexOf("08,") != -1)
                    {
                        //khoa.Text = m.get_xutri(ngayvv.Text, l_maql, 1).ToString();
                        //tenkhoa.SelectedValue = khoa.Text;
                        // khoa_save = khoa.Text;
                        xutri_save = s_xutri;
                        // khoa.Enabled = true;
                        // tenkhoa.Enabled = true;
                        //    sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
                        //    if (s_chonxutri.IndexOf("08,") != -1) sql += " and loai=1";
                        //    else if (s_chonxutri.IndexOf("05,") != -1) sql += " and loai=0";
                        //    else if (s_chonxutri.IndexOf("02,") != -1)
                        //    {
                        //        //sql += " and makp<>'" + makp.Text + "'";
                        //        sql += "  and (maba like '%20%'";
                        //        sql += " or maba like '%21%'";
                        //        sql += " or maba like '%22%'";
                        //        sql += " or maba like '%23%')";
                        //    }
                        //    //else if (s_chonxutri.IndexOf("02,") == -1) sql += " and makp<>'" + makp.Text + "'";
                        //    //sql += " order by makp";
                        //   // tenkhoa.DataSource = m.get_data(sql).Tables[0];
                        //   // tenkhoa.SelectedValue = khoa.Text;
                        //}
                        //else loaibv.Enabled = s_xutri.IndexOf("06,") != -1;
                    }
                    //if (s_xutri!="00") maxutri.Text = s_xutri;
                    //if (maxutri.Text == "" && s_mabs!="")
                    //{
                    //    mabs.Text = s_mabs;
                    //    r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    //    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    //    else tenbs.Text = "";
                    //}
                    //soluutru.Text = r["soluutru"].ToString();
                    //bienchung.Checked = int.Parse(r["bienchung"].ToString()) == 1;
                    //taibien.Checked = int.Parse(r["taibien"].ToString()) != 0;
                    //if (taibien.Checked) cmbTaibien.SelectedValue = int.Parse(r["taibien"].ToString());
                    //giaiphau.Checked = int.Parse(r["giaiphau"].ToString()) != 0;
                    //if (giaiphau.Checked) gphaubenh.SelectedValue = int.Parse(r["giaiphau"].ToString());
                    ////if (s_xutri != "")
                    //{
                    //    for (int i = 0; i <= xutri.Items.Count; i++)
                    //        if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i - 1, CheckState.Checked);
                    //}
                    //if (loaibv.Enabled)
                    //{
                    //    foreach (DataRow r2 in m.get_data("select * from " + user + ".chuyenvien where maql=" + l_maql).Tables[0].Rows)
                    //    {
                    //        tenloaibv.SelectedValue = r2["loaibv"].ToString();
                    //        mabv.Text = r2["mabv"].ToString();
                    //        load_mabv(loaibv.Text);
                    //        tenbv.SelectedValue = mabv.Text;
                    //        s_mabv = mabv.Text;
                    //    }
                    //}
                    //s_icd_noichuyenden = icd_noichuyenden.Text;
                    //s_icd_chinh = icd_chinh.Text;
                    //s_icd_kemtheo = icd_kemtheo.Text;
                    //if (!bAdmin && cd_chinh.Text!="" && mabs.Text!="" && maxutri.Text!="") ena_but(false);
                    break;
                }
                load_vv();
            }
        }
        private void load_vv()
        {            
            string xxx = m.user + m.mmyy(dtpNgay.Text);
            foreach (DataRow r in m.get_data("select * from " + xxx + ".quanhe where maql=" + l_maql).Tables[0].Rows)
            {
                quanhe.Text = r["quanhe"].ToString();
                qh_hoten.Text = r["hoten"].ToString();
                qh_diachi.Text = r["diachi"].ToString();
                qh_dienthoai.Text = r["dienthoai"].ToString();
                break;
            }
            foreach (DataRow r in m.get_data("select * from " + xxx + ".lienhe where maql=" + l_maql).Tables[0].Rows)
            {
                //bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
                //loai.SelectedIndex=int.Parse(r["loai"].ToString());
                break;
            }
            string stuoi = m.get_tuoivao(dtpNgay.Text, l_maql).Trim();
            if (stuoi.Length == 4)
            {
                tuoi.Text = stuoi.Substring(0, 3);
                loaituoi.SelectedIndex = Math.Min(int.Parse(stuoi.Substring(3, 1)), 3);
            }           
            //load_phauthuat();
            //load_tainantt();
            //load_chidinh();
            //load_thuocdan();
            //load_baohiem();
        }
        private void giovv_Validated(object sender, EventArgs e)
        {
          
            string sgio = (giovv.Text.Trim() == "") ? "00:00" : giovv.Text.Trim();
            giovv.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giovv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),s_msg);
                giovv.Focus();
                return;
            }
            if (!m.bMmyy(m.mmyy(dtpNgay.Text))) return;
            s_mabn = mabn2.Text + mabn3.Text;
            string s = dtpNgay.Text + " " + giovv.Text;
            if (s != s_ngayvv)
            {
                if (bTudong)
                {
                    DataRow r = m.getrowbyid(dtletet, "ngay='" + dtpNgay.Text.Substring(0, 5) + "'");
                    bool bLetet = r != null;
                    hh1 = int.Parse(s.Substring(11, 2));//hh1 = int.Parse(ngayvv.Text.Substring(11, 2));
                    mm1 = int.Parse(s.Substring(14, 2));//mm1 = int.Parse(ngayvv.Text.Substring(14, 2));
                    DateTime dtime = m.StringToDate(dtpNgay.Text.Substring(0, 10));
                    string ddd = dtime.DayOfWeek.ToString().Substring(0, 3);
                   
                }
                if (tuoi.Text != "")
                {
                    if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                    {
                        tuoi.Text = Convert.ToString(int.Parse(dtpNgay.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                        loaituoi.SelectedIndex = 0;
                    }
                }
                //l_maql = (tenkp.Items.Count==1 && tenkp.SelectedIndex!=-1)?m.get_maql_benhanpk(s_mabn,tenkp.SelectedValue.ToString(),s):m.get_maql_benhanpk(s_mabn,s);
                bNew = l_maql == 0;
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    dtpNgay.Text = s.Substring(0,10);
                    giovv.Text = s.Substring(11);
                }
                else
                {
                    if (dtpNgay.Text.Substring(0, 10) == m.Ngayhienhanh)
                    {
                        string m_ngay = m.get_ngaytiepdon(s_mabn,s);
                        if (m_ngay != "")
                        {
                            if (!m.bNgaygio(s, m_ngay) && !bDangky_homqua)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được nhỏ ngày giờ tiếp đón !(" + m_ngay + ")"),s_msg);
                                dtpNgay.Focus();
                                return;
                            }
                        }
                    }
                    emp_vv();
                    emp_rv();
                    dtpNgay.Text = s.Substring(0,10);
                    giovv.Text = s.Substring(11);
                    if (dtpNgay.Text != "") load_tiepdon(dtpNgay.Text.Substring(0, 10), false);
                    //if (bLuutru_Mabn) soluutru.Text = mabn2.Text + mabn3.Text;
                    //else if (soluutru.Text == "" && b_sovaovien) soluutru.Text = sovaovien.Text;
                    //l_maql = 0;
                    //if (!bSuadoituong)
                    //{
                    //    madoituong.Enabled = false;
                    //    tendoituong.Enabled = false;
                    //}
                }
                s_ngayvv = s;
            }
       
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                danhsach.Visible = false;
                mabn2.Focus();
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) gan_mabn();
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                    DataView dv = (DataView)cm.List;
                    if (tim.Text != "")
                        dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                    else
                        dv.RowFilter = "";
                }
                catch { }
            }
        }

        private void tim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) list.Focus();
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void lbTieuDe_MouseHover(object sender, EventArgs e)
        {
            //lbTieuDe.BackColor = Color.BlueViolet;
        }

        private void txtten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void loaituoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void mann_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tennn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void frmtc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void madantoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tendantoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void manuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tennuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void sonha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void thon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tqx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tentqx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void matt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tentinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void maqu2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tenquan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void mapxa2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tenpxa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cholam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void quanhe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void qh_hoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void qh_diachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void qh_dienthoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btLuu.Focus();
        }

        private void butchidinh_Click(object sender, EventArgs e)
        {
           
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dss = new DataSet();
                DataTable dttam = new DataTable(); dttam = dshs.Tables[0].Clone();
                if (l_matd != 0 && l_maql != 0)
                {
                    sql = "";
                }
                string title = "";
                if (bTreem)
                {
                    title = lan.Change_language_MessageText("dành cho trẻ em và thiếu niên");
                }
                else
                    title = lan.Change_language_MessageText("dành cho người lớn");

                DataRow r = m.getrowbyid(dshs.Tables[0], "ngay='" + treevLanTC.SelectedNode.Text.ToString() + "'");
                DataRow rr = dttam.NewRow();
                for (int i = 0; i < dshs.Tables[0].Columns.Count; i++)
                {

                    rr[i] = r[i];
                }
                dttam.Columns.Add("treem");
                //try
                //{
                //    dttam.Rows.Add(m.getrowbyid(dshs.Tables[0],"ngay='" + treevLanTC.SelectedNode.Text.ToString() + "'"));
                //}
                //catch (Exception exx){ 

                //}
                dttam.Rows.Add(rr);
                dttam.Rows[0]["treem"] = bTreem ? "1" : "0";

                dttam.AcceptChanges();
                if (chkxml.Checked)
                    dttam.WriteXml("..\\xml\\rptSangloctc.xml");
                dss.Tables.Add(dttam);
                dllReportM.frmReport f = new dllReportM.frmReport(m, dss, "rptSangloctc.rpt", title, txtten.Text, maskedBox1.Text.Trim() == "" ? namsinh.Text : maskedBox1.Text.Trim(), s_mabn, "", "");
                f.ShowDialog();
            }
            catch { }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
