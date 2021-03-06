using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using LibVienphi;
using LibMedi;
using System.IO;
using Paint;


namespace Medisoft
{
    public partial class frmHSBenhan_NGTMat : Form
    {
        private Language lan = new Language();
        private LibMedi.AccessData m;
        private decimal l_maql, l_id, l_idkhoa, l_idthuchien, l_mavaovien;
        private bool b_sovaovien, b_soluutru, bAdmin;
        private string sql, s_makp, s_mabs, user, xxx, s_tenkp, s_sovaovien, s_nhomkho, s_userid, s_ngayvk;
        private string pathImage = "", FileType = "";
        private int i_userid, i_madoituong, itable, i_loai, i_maba, i_mabv, i_chinhanh = 0, i_traituyen = 0;
        private DataTable dtnv = new DataTable();
        private DataTable dtg = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataSet ds = new DataSet();
        private DataSet ds1;
        private DataSet dscd = new DataSet();
        private DataSet dsct = new DataSet();
        private DataTable dtba = new DataTable();
        private DataTable dt = new DataTable();
        private DataTable dthinh = new DataTable();
        private DataTable dticd = new DataTable();
        private byte[] image;
        private Bitmap map;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private int i_maxlength_mabn = 8;

        public frmHSBenhan_NGTMat(LibMedi.AccessData acc, string _makp, string _tenkp, string _mabs, int userid, string _nhomkho, string suserid, bool _soluutru, bool _sovaovien, bool _admin, int _loai, int _maba, int _mabv)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_makp = _makp; s_tenkp = _tenkp; s_mabs = _mabs; i_userid = userid; s_nhomkho = _nhomkho; i_mabv = _mabv;
            s_userid = suserid; b_sovaovien = _sovaovien; b_soluutru = _soluutru; bAdmin = _admin; i_loai = _loai; i_maba = _maba;
        }
        public frmHSBenhan_NGTMat(LibMedi.AccessData acc, string _makp, string _tenkp, string _mabs, int userid, string _nhomkho, string suserid, bool _soluutru, bool _sovaovien, bool _admin, int _loai, int _maba, int _mabv,int _i_chinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_makp = _makp; s_tenkp = _tenkp; s_mabs = _mabs; i_userid = userid; s_nhomkho = _nhomkho; i_mabv = _mabv;
            s_userid = suserid; b_sovaovien = _sovaovien; b_soluutru = _soluutru; bAdmin = _admin; i_loai = _loai; i_maba = _maba;
            i_chinhanh = _i_chinhanh;
        }

        private void barChidinh_Click(object sender, EventArgs e)
        {
            //string stuoi = m.get_tuoivao(l_maql).Trim();
            //frmChonthongsovp ff = new frmChonthongsovp(m, s_makp, i_userid);
            //ff.ShowDialog(this);
            //if (ff.s_makp != "")
            //{
            //    frmChidinh f = new frmChidinh(m, mabn.Text, hoten.Text, stuoi, ngayvk.Text + " " + giovk.Text, s_makp, s_tenkp, i_madoituong, 1, l_maql, l_idkhoa, i_userid, "nhapkhoa", sothe.Text, "", (s_mabs != "") ? s_mabs : mabsnb.Text, cd_kkb.Text, bAdmin, l_maql, 3, 0, true);
            //    f.ShowDialog(this);
            //    load_chidinh();
            //}
        }

        private void barDieutri_Click(object sender, EventArgs e)
        {
            frmTodieutri f = new frmTodieutri(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin, false, 0, null, i_madoituong);//,(rb2.Checked)?true:false
            f.ShowDialog(this);
        }

        private void barChamsoc_Click(object sender, EventArgs e)
        {
            frmChamsoc f = new frmChamsoc(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void barMau_Click(object sender, EventArgs e)
        {
            frmTruyenmau f = new frmTruyenmau(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void barDich_Click(object sender, EventArgs e)
        {
            frmTruyendich f = new frmTruyendich(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void barChonkhoa_Click(object sender, EventArgs e)
        {
            
        }

        private void barDausinhton_Click(object sender, EventArgs e)
        {
            frmDausinhton_pk f = new frmDausinhton_pk(m, s_makp, l_maql, m.user + ".benhanngtr", 2, mabn.Text, (decimal)l_mavaovien, ngay.Text, mabs.Text);//
            f.ShowDialog(this);
        }

        private void barPhanUng_Click(object sender, EventArgs e)
        {
            frmPuthuoc f = new frmPuthuoc(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void barPttt_Click(object sender, EventArgs e)
        {
            //string stuoi = m.get_tuoivao(l_maql).Trim();
            //frmPttt_ba f = new frmPttt_ba(m, s_makp, mabn.Text, hoten.Text, stuoi, phai.Text, diachi.Text, sothe.Text, "", ngay.Text, cd_kkb.Text, icd_kkb.Text, "P", i_userid, (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), "", "", "", "", "", 0, 0, 0, 0, 0, DateTime.Now.Date.ToString("dd/MM/yyyy"), 0, 0);
            //f.ShowDialog(this);
        }

        private void barKetthuc_Click(object sender, EventArgs e)
        {
            m.close();//v.close();
            System.GC.Collect();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHSBenhan_NGTMat_Load(object sender, EventArgs e)
        {
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            user = m.user;
            dtdt = m.get_data("select * from " + user + ".doituong").Tables[0];
            dt = m.get_data("select ten,id,loai,stt from " + user + ".ba_danhmuc order by ten").Tables[0];
            list1.DisplayMember = "TEN";
            list1.ValueMember = "TEN";
            list1.DataSource = dt;

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
            listICD.DisplayMember = "CICD10";
            listICD.ValueMember = "VVIET";
            listICD.DataSource = dticd;
            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
            listNv.DisplayMember = "MA";
            listNv.ValueMember = "HOTEN";
            listNv.DataSource = dtnv;

            pathImage = m.pathImage; FileType = m.FileType;
            pic.Visible = m.bHinh || m.bChonhinh;
            //listNv1.DisplayMember = "MA";
            //listNv1.ValueMember = "HOTEN";
            //listNv1.DataSource = m.get_data("select  ma, hoten, nhom, viettat, makp, mapk, password_  from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];

            sql = "select * from " + user + ".dmbenhan_bv where maba=" + i_maba;
            dtba = m.get_data(sql).Tables[0];

            xem.SelectedIndex = 0;
            list.DisplayMember = "HOTEN";
            list.ValueMember = "MAQL";
            load_list();
            list.ColumnWidths[0] = 70;
            list.ColumnWidths[1] = 150;
            list.ColumnWidths[2] = 0;
            list.SetSensive(2, 0, Color.Red);
            dscd.ReadXml("..\\..\\..\\xml\\m_bachidinh.xml");
            for (int i = 0; i < chonin.Items.Count; i++) chonin.SetItemCheckState(i, CheckState.Checked);
        }

        private void load_list()
        {
            Cursor = Cursors.WaitCursor;
            if (rb1.Checked)
            {
                xem.Enabled = false;
                butChon.Enabled = false;
                #region Bo
                //sql="select a.mabn,trim(b.hoten)||'('||trim(to_char(to_char(sysdate,'yyyy')-b.namsinh))||')' as ten,a.nhapkhoa,b.hoten,";
                //sql+="b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                //sql+="to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,";
                //sql+="h.giuong,a.id,a.maql,g.sothe,d.chandoan as chandoanvv,h.maicd,h.chandoan as chandoanvk,d.mabs,d.madoituong,";
                //sql+="d.sovaovien,to_char(sysdate,'dd/mm/yyyy hh24:mi') as ngayrv,h.tuoivao,h.chandoan";
                //sql+=",'' as chandoanrv,'' as maicdrv";
                //sql += " from " + user + ".btdbn b," + user + ".hiendien a," + user + ".benhandt d," + user + ".bhyt g," + user + ".nhapkhoa h ," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n";
                //sql+=" where a.id=h.id(+) and a.mabn=b.mabn and a.maql=g.maql(+) ";
                //sql+=" and a.maql=d.maql and d.loaiba=2 and a.xuatkhoa=0 ";
                //sql+=" and b.matt=j.matt and b.maqu=m.maqu and b.maphuongxa=n.maphuongxa ";
                //sql+=" and a.makp='"+s_makp+"'";
                //sql+=" and (g.sudung is null or g.sudung=1)";
                //sql+=" order by a.ngay desc";
                #endregion
                sql = "select d.mabn,trim(b.hoten)||'('||trim(to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)))||')' as ten,b.hoten,b.namsinh,b.phai,";
                sql += "trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                sql += "to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,d.maql,d.mavaovien,g.sothe,";
                sql += "d.chandoan as chandoanvv,d.maicd,d.chandoan as chandoanvk,d.mabs,d.madoituong,d.sovaovien,to_char(d.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
                sql += "d.chandoan,d.chandoanrv as chandoanrv,d.maicdrv as maicdrv,g.traituyen,to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)) as tuoivao ";
                sql += "from " + user + ".btdbn b," + user + ".benhanngtr d," + user + ".bhyt g," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n ";
                sql += "where b.mabn=d.mabn and d.maql=g.maql(+) and d.ngayrv is null  ";
                sql += "and b.matt=j.matt and b.maqu=m.maqu(+) and b.maphuongxa=n.maphuongxa(+)  and d.makp='" + s_makp + "' and (g.sudung is null or g.sudung=1) ";
                sql += "order by d.ngay desc ";
            }
            else
            {
                sql = "select d.mabn,trim(b.hoten)||'('||trim(to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)))||')' as ten,b.hoten,b.namsinh,b.phai,";
                sql += "trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                sql += "to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,d.maql,d.mavaovien,g.sothe,";
                sql += "d.chandoan as chandoanvv,d.maicd,d.chandoan as chandoanvk,d.mabs,d.madoituong,d.sovaovien,to_char(d.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
                sql += "d.chandoan,d.chandoanrv as chandoanrv,d.maicdrv as maicdrv,g.traituyen,to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)) as tuoivao ";
                sql += "from " + user + ".btdbn b," + user + ".benhanngtr d," + user + ".bhyt g," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n ";
                sql += "where b.mabn=d.mabn and d.maql=g.maql(+) and d.ngayrv is not null  ";
                sql += "and b.matt=j.matt and b.maqu=m.maqu(+) and b.maphuongxa=n.maphuongxa(+)  and d.makp='" + s_makp + "' and (g.sudung is null or g.sudung=1) ";
                sql += "order by d.ngay desc ";
                #region Bo
                //xem.Enabled=butChon.Enabled=butKhoa.Enabled=butIn.Enabled=true;
                //butChidinh.Enabled=butChamsoc.Enabled=butDieutri.Enabled=true;
                //sql="select h.mabn,trim(b.hoten)||'('||trim(to_char(to_char(sysdate,'yyyy')-b.namsinh))||')' as ten,1 as nhapkhoa,b.hoten,";
                //sql+="b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||' '||trim(n.tenpxa)||' '||trim(m.tenquan)||' '||trim(j.tentt) as diachi,";
                //sql+="to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(h.ngay,'dd/mm/yyyy hh24:mi') as ngayvk,";
                //sql+="h.giuong,a.id,h.maql,g.sothe,d.chandoan as chandoanvv,h.maicd,h.chandoan as chandoanvk,d.mabs,d.madoituong,";
                //sql+="d.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,h.tuoivao,h.chandoan";
                //sql+=",a.chandoan as chandoanrv,a.maicd as maicdrv";
                //sql += " from " + user + ".xuatkhoa a," + user + ".btdbn b," + user + ".benhandt d," + user + ".bhyt g," + user + ".nhapkhoa h ," + user + ".btdtt j," + user + ".btdquan m," + user + ".btdpxa n";
                //sql+=" where a.id=h.id and h.mabn=b.mabn and h.maql=g.maql(+) ";
                //sql+=" and h.maql=d.maql and d.loaiba=2 ";
                //sql+=" and b.matt=j.matt and b.maqu=m.maqu and b.maphuongxa=n.maphuongxa ";
                //sql+=" and h.makp='"+s_makp+"'";
                //sql+=" and (g.sudung is null or g.sudung=1)";
                //sql+=" order by a.ngay desc";
                #endregion
            }
            ds = m.get_data(sql);
            list.DataSource = ds.Tables[0];
            Cursor = Cursors.Default;
            if (list.Items.Count > 0 && mabn.Text == "")
            {
                //this.groupBox1.Location = new Point(5, 91);//236
                //this.groupBox1.Size = new Size(1008, 550);//419
                this.groupBox1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y);
                this.groupBox1.Size = new Size(tabControl1.Right, tabControl1.Bottom);
            }
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            DataRow r = m.getrowbyid(ds.Tables[0], "maql=" + decimal.Parse(list.SelectedValue.ToString()));
            if (r != null) get_mabn(r["mabn"].ToString(), decimal.Parse(r["maql"].ToString()));
            //Lấy dấu sinh tồn
            if (m.bDausinhton_khambenh)
            {
                if (m.get_data("select mabn from " + user + m.mmyy(ngay.Text.Substring(0, 10)) + ".d_dausinhton where mabn='" + mabn.Text.Trim() + "'").Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("Đề nghị lấy dấu sinh tồn của bệnh nhân! ", LibMedi.AccessData.Msg);
                    butDausinhton_Click(sender, e);
                }
            }
            //end
            this.groupBox1.Location = new Point(0, 30);
            this.groupBox1.Size = new Size(206, 253);
        }
        
        private void ena_object(bool ena)
        {
            if (rb1.Checked || bAdmin)
            {
                txtledao.Enabled = txtmimat.Enabled = txtketmac.Enabled = txtthmathot.Enabled = txtgiacmac.Enabled = !ena;
                txtcungmac.Enabled = txttienphong.Enabled = txtmongmat.Enabled = txtdongtupxa.Enabled = !ena;
                txtthuytinhthe.Enabled = txtthuytinhdich.Enabled = txtsoianhdongtu.Enabled = txtthnhancau.Enabled = !ena;
                txthomat.Enabled = txtdaymat.Enabled = txtChandoan.Enabled= !ena;
                txtledao_mt.Enabled = txtmimat_mt.Enabled = txtketmac_mt.Enabled = txtthmathot_mt.Enabled = txtgiacmac_mt.Enabled = !ena;
                txtcungmac_mt.Enabled = txttienphong_mt.Enabled = txtmongmat_mt.Enabled = txtdongtupxa_mt.Enabled = !ena;
                txtthuytinhthe_mt.Enabled = txtthuytinhdich_mt.Enabled = txtsoianhdongtu_mt.Enabled = txtthnhancau_mt.Enabled = !ena;
                txthomat_mt.Enabled = txtdaymat_mt.Enabled = !ena;
                vv_ck_mp.Enabled = vv_ck_mt.Enabled = vv_kk_mp.Enabled = vv_kk_mt.Enabled = vv_na_mp.Enabled=!ena;
                vv_na_mt.Enabled = vv_tt_mp.Enabled = vv_tt_mt.Enabled = !ena;
                lydo.Enabled = !ena; hb_benhly.Enabled = !ena; hb_giadinh.Enabled = !ena; hb_banthan.Enabled = !ena; kb_toanthan.Enabled = !ena;
                tk_benhly.Enabled = !ena; tk_tomtat.Enabled = !ena; tk_tinhtrang.Enabled = !ena; tk_dieutri.Enabled = !ena;
                manguoigiao.Enabled = !ena; nguoigiao.Enabled = !ena; manguoinhan.Enabled = !ena; nguoinhan.Enabled = !ena;
                list.Enabled = ena; butChuyenphong.Enabled = !ena;
                if (i_loai == 0 || i_loai == 2) butChamsoc.Enabled = !ena;
                butKhoa.Enabled = !ena; xem.Enabled = !ena; butDausinhton.Enabled = !ena; butChidinh.Enabled = !ena;
                if (i_loai == 0 || i_loai == 1) butDieutri.Enabled = !ena;
                butAn.Enabled = !ena; butMau.Enabled = !ena; butLoc.Enabled = !ena; butDich.Enabled = !ena; butDausinhton.Enabled = !ena; butPhanung.Enabled = !ena;
                butChon.Enabled = !ena; butPttt.Enabled = !ena; butKethuc.Enabled = ena;
                butLuu.Enabled = !ena; butBoqua.Enabled = !ena; butIn.Enabled = ena; tim.Enabled = ena;
                butVao.Enabled = ena; butRa.Enabled = !ena; butphanungthuocohai.Enabled = !ena;
            }
        }

        private void get_mabn(string _mabn, decimal id)
        {
            lydo.Text = ""; hb_benhly.Text = ""; hb_banthan.Text = ""; hb_giadinh.Text = ""; kb_toanthan.Text = "";
            txtChandoan.Text = ""; vv_ck_mp.Text = ""; vv_ck_mt.Text = ""; vv_kk_mp.Text = ""; vv_kk_mt.Text = "";
            vv_na_mp.Text = ""; vv_na_mt.Text = ""; vv_tt_mp.Text = ""; vv_tt_mt.Text = "";
            txtledao.Text = txtmimat.Text = txtketmac.Text = txtthmathot.Text = txtgiacmac.Text = "";
            txtcungmac.Text = txttienphong.Text = txtmongmat.Text = txtdongtupxa.Text = "";
            txtthuytinhthe.Text = txtthuytinhdich.Text = txtsoianhdongtu.Text = txtthnhancau.Text = "";
            txthomat.Text = txtdaymat.Text = "";
            txtledao_mt.Text = txtmimat_mt.Text = txtketmac_mt.Text = txtthmathot_mt.Text = txtgiacmac_mt.Text = "";
            txtcungmac_mt.Text = txttienphong_mt.Text = txtmongmat_mt.Text = txtdongtupxa_mt.Text = "";
            txtthuytinhthe_mt.Text = txtthuytinhdich_mt.Text = txtsoianhdongtu_mt.Text = txtthnhancau_mt.Text = "";
            txthomat_mt.Text = txtdaymat_mt.Text = "";
            sql = "mabn='" + _mabn + "'";
            if (id != 0) sql += " and maql=" + id;
            DataRow r = m.getrowbyid(ds.Tables[0], sql);
            if (r != null)
            {
                mabn.Text = r["mabn"].ToString();
                hoten.Text = r["hoten"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                phai.Text = (r["phai"].ToString() == "0") ? "Nam" : "Nữ";
                diachi.Text = r["diachi"].ToString();
                sothe.Text = r["sothe"].ToString();
                i_traituyen = (r["traituyen"].ToString() != "") ? int.Parse(r["traituyen"].ToString()) : 0;
                ngay.Text = r["ngayvv"].ToString();
                tungay.Text = ngay.Text.Substring(0, 10);
                chandoan.Text = r["chandoanvv"].ToString();
                s_ngayvk = r["ngayvk"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                l_maql = decimal.Parse(r["maql"].ToString());
                l_idkhoa = decimal.Parse(r["maql"].ToString());
                i_madoituong = int.Parse(r["madoituong"].ToString());
                s_sovaovien = r["sovaovien"].ToString();
                if (rb2.Checked)
                {
                    ngayrv.Text = r["ngayrv"].ToString().Substring(0, 10);
                    giorv.Text = r["ngayrv"].ToString().Substring(11);
                    denngay.Text = ngayrv.Text.Substring(0, 10);
                }
                load_data();
                ena_object(false);
                sql="select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.ten,c.hoten from "+xxx+".pttt a,";
                sql+=""+user+".dmmete b,"+user+".dmbs c where a.phuongphap=b.ma and a.ptv=c.ma and maql="+l_maql;
                foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(r1.ItemArray);
                }
                if (pic.Visible)
                {
                    foreach (DataRow r2 in m.get_data("select * from " + user + ".btdbn where mabn='" + _mabn + "'").Tables[0].Rows)
                    {
                        //try
                        //{
                        //    image = new byte[0];
                        //    image = (byte[])(r2["image"]);
                        //    memo = new MemoryStream(image);
                        //    map = new Bitmap(Image.FromStream(memo));
                        //    pic.Image = (Bitmap)map;
                        //    pic.Tag = image;
                        //}
                        //catch
                        //{
                        //    pic.Tag = "0000.bmp";
                        //    fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        //    map = new Bitmap(Image.FromStream(fstr));
                        //    pic.Image = (Bitmap)map;
                        //    image = new byte[fstr.Length];
                        //    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        //    fstr.Close();
                        //    pic.Tag = image;
                        //}

                        if (pic.Visible)
                        {
                            bool error = false;
                            try
                            {
                                if (pathImage != "")
                                {
                                    error = true;
                                    //string paa = pathImage.Trim('\\').Replace("\\", "//") + "//" + mabn.Text;
                                    pic.Tag = (System.IO.File.Exists(pathImage.Trim('\\').Replace("\\", "//") + "//" + mabn.Text + "." + FileType)) ? pathImage + "//" + mabn.Text + "." + FileType : "0000.bmp";
                                }
                                else
                                {
                                    image = new byte[0];
                                    image = (byte[])(r["image"]);
                                    memo = new MemoryStream(image);
                                    map = new Bitmap(Image.FromStream(memo));
                                    pic.Image = (Bitmap)map;
                                    pic.Tag = image;
                                }
                            }
                            catch
                            {
                                error = true;
                                pic.Tag = "0000.bmp";
                            }
                            if (error)
                            {
                                fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                map = new Bitmap(Image.FromStream(fstr));
                                pic.Image = (Bitmap)map;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                mabn.Focus();
            }
        }

        private void load_data()
        {
            Cursor = Cursors.WaitCursor;
            bool bFound = false; xxx = user + m.mmyy(ngay.Text);
            l_idthuchien = m.get_idthuchien(ngay.Text, l_maql, s_makp, l_maql);//l_idkhoa
            DataRow r1;
            if (l_idthuchien != 0)
            {
                l_id = m.get_idchung(ngay.Text, l_idthuchien);
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_chung where id=" + l_id).Tables[0].Rows)
                {
                    lydo.Text = r["lydo"].ToString();
                    hb_benhly.Text = r["hb_benhly"].ToString();
                    hb_banthan.Text = r["hb_banthan"].ToString();
                    hb_giadinh.Text = r["hb_giadinh"].ToString();
                    kb_toanthan.Text = r["kb_toanthan"].ToString();
                    tk_benhly.Text = r["tk_benhly"].ToString();
                    tk_tomtat.Text = r["tk_tomtat"].ToString();
                    tk_tinhtrang.Text = r["tk_tinhtrang"].ToString();
                    tk_dieutri.Text = r["tk_dieutri"].ToString();
                    manguoigiao.Text = r["nguoigiao"].ToString();
                    manguoinhan.Text = r["nguoinhan"].ToString();
                    txtChandoan.Text = r["phanbiet"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    r1 = m.getrowbyid(dtnv, "ma='" + manguoigiao.Text + "'");
                    if (r1 != null) nguoigiao.Text = r1["hoten"].ToString();
                    r1 = m.getrowbyid(dtnv, "ma='" + manguoinhan.Text + "'");
                    if (r1 != null) nguoinhan.Text = r1["hoten"].ToString();
                    r1 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    break;
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".bavv_mat where maql=" + l_maql).Tables[0].Rows)
                {
                    vv_kk_mp.Text = r["tlkk_mp"].ToString();
                    vv_kk_mt.Text = r["tlkk_mt"].ToString();
                    vv_ck_mp.Text = r["tlck_mp"].ToString();
                    vv_ck_mt.Text = r["tlck_mt"].ToString();
                    vv_na_mp.Text = r["na_mp"].ToString();
                    vv_na_mt.Text = r["na_mt"].ToString();
                    vv_tt_mp.Text = r["tt_mp"].ToString();
                    vv_tt_mt.Text = r["tt_mt"].ToString();
                    bFound = true;
                    break;
                }
                foreach (DataRow r in m.get_data("select * from " + user + ".bavv_mat where maql=" + l_maql).Tables[0].Rows)
                {
                    txtledao.Text = r["ledao_mp"].ToString();
                    txtmimat.Text = r["mimat_mp"].ToString();
                    txtketmac.Text = r["ketmac_mp"].ToString();
                    txtthmathot.Text = r["thmathot_mp"].ToString();
                    txtgiacmac.Text = r["giacmac_mp"].ToString();
                    txtcungmac.Text = r["cungmac_mp"].ToString();
                    txttienphong.Text = r["tienphong_mp"].ToString();
                    txtmongmat.Text = r["mongmat_mp"].ToString();
                    txtdongtupxa.Text = r["dongtupxa_mp"].ToString();
                    txtthuytinhthe.Text = r["thuytinhthe_mp"].ToString();
                    txtthuytinhdich.Text = r["thuytinhdich_mp"].ToString();
                    txtsoianhdongtu.Text = r["soianhdongtu_mp"].ToString();
                    txtthnhancau.Text = r["thnhancau_mp"].ToString();
                    txthomat.Text = r["homat_mp"].ToString();
                    txtdaymat.Text = r["daymat_mp"].ToString();
                    txtledao_mt.Text = r["ledao_mt"].ToString();
                    txtmimat_mt.Text = r["mimat_mt"].ToString();
                    txtketmac_mt.Text = r["ketmac_mt"].ToString();
                    txtthmathot_mt.Text = r["thmathot_mt"].ToString();
                    txtgiacmac_mt.Text = r["giacmac_mt"].ToString();
                    txtcungmac_mt.Text = r["cungmac_mt"].ToString();
                    txttienphong_mt.Text = r["tienphong_mt"].ToString();
                    txtmongmat_mt.Text = r["mongmat_mt"].ToString();
                    txtdongtupxa_mt.Text = r["dongtupxa_mt"].ToString();
                    txtthuytinhthe_mt.Text = r["thuytinhthe_mt"].ToString();
                    txtthuytinhdich_mt.Text = r["thuytinhdich_mt"].ToString();
                    txtsoianhdongtu_mt.Text = r["soianhdongtu_mt"].ToString();
                    txtthnhancau_mt.Text = r["thnhancau_mt"].ToString();
                    txthomat_mt.Text = r["homat_mt"].ToString();
                    txtdaymat_mt.Text = r["daymat_mt"].ToString();
                    bFound = true;
                    break;
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_kbdausinhton where id=" + l_id).Tables[0].Rows)
                {
                    mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                    nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                    huyetap.Text = r["huyetap"].ToString();
                    nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                    cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                    chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                    tinh_bmi();
                    break;
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ba_tkhoso where id=" + l_id).Tables[0].Rows)
                {
                    switch (int.Parse(r["ma"].ToString()))
                    {
                        case 1: st1.Value = decimal.Parse(r["so"].ToString()); break;
                        case 2: st2.Value = decimal.Parse(r["so"].ToString()); break;
                        case 3: st3.Value = decimal.Parse(r["so"].ToString()); break;
                        case 4: st4.Value = decimal.Parse(r["so"].ToString()); break;
                        case 5: st5.Value = decimal.Parse(r["so"].ToString()); khac.Text = r["khac"].ToString(); break;
                        case 6: st6.Value = decimal.Parse(r["so"].ToString()); break;
                    }
                }
            }
            else
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".bavv_chung where maql=" + l_maql).Tables[0].Rows)
                {
                    lydo.Text = r["lydo"].ToString();
                    hb_benhly.Text = r["hb_benhly"].ToString();
                    hb_banthan.Text = r["hb_banthan"].ToString();
                    hb_giadinh.Text = r["hb_giadinh"].ToString();
                    kb_toanthan.Text = r["kb_toanthan"].ToString();
                    txtChandoan.Text = r["sobo"].ToString();
                    bFound = true;
                    break;
                }
                foreach (DataRow r in m.get_data("select * from " + xxx + ".bavv_mat where maql=" + l_maql).Tables[0].Rows)
                {
                    vv_kk_mp.Text = r["tlkk_mp"].ToString();
                    vv_kk_mt.Text = r["tlkk_mt"].ToString();
                    vv_ck_mp.Text = r["tlck_mp"].ToString();
                    vv_ck_mt.Text = r["tlck_mt"].ToString();
                    vv_na_mp.Text = r["na_mp"].ToString();
                    vv_na_mt.Text = r["na_mt"].ToString();
                    vv_tt_mp.Text = r["tt_mp"].ToString();
                    vv_tt_mt.Text = r["tt_mt"].ToString();
                    bFound = true;
                    break;
                }
                if (bFound)
                {
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".bavv_dausinhton where maql=" + l_maql).Tables[0].Rows)
                    {
                        mach.Text = (r["mach"].ToString() != "0") ? r["mach"].ToString() : "";
                        nhietdo.Text = (r["nhietdo"].ToString() != "0") ? r["nhietdo"].ToString() : "";
                        huyetap.Text = r["huyetap"].ToString();
                        nhiptho.Text = (r["nhiptho"].ToString() != "0") ? r["nhiptho"].ToString() : "";
                        cannang.Text = (r["cannang"].ToString() != "0") ? r["cannang"].ToString() : "";
                        chieucao.Text = (r["chieucao"].ToString() != "0") ? r["chieucao"].ToString() : "";
                        tinh_bmi();
                        break;
                    }
                }
            }
            if (mabs.Text == "" && s_mabs != "")
            {
                mabs.Text = s_mabs;
                r1 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                if (r1 != null)
                {
                    tenbs.Text = r1["hoten"].ToString();
                    tenbs_pass.Text = r1["password_"].ToString();
                }
                else tenbs.Text = "";
            }

            load_chidinh();
            Cursor = Cursors.Default;
        }

        private void tinh_bmi()
        {
            decimal cn = (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0;
            decimal cc = (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0;
            decimal _bmi = 0;
            if (cn != 0 && cc != 0) _bmi = cn / (cc / 100 * cc / 100);
            else _bmi = 0;
            bmi.Text = _bmi.ToString("####0.00");
        }

        private void load_chidinh()
        {
            string tu = ngay.Text.Substring(0, 10), den = (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10);
            sql = "select nvl(e.stt,0) as stt,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,d.hoten as tenbs,b.ten,' ' as ketqua ";
            sql += ",b.id_loai ";
            sql += " from xxx.v_chidinh a," + user + ".v_giavp b," + user + ".btdkp_bv c," + user + ".dmbs d," + user + ".dmchidinh e ";
            sql += " where a.mavp=b.id and a.makp=c.makp(+) and a.mabs=d.ma(+) and b.id_loai=e.idloaivp(+) and a.mabn='" + mabn.Text + "'";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy')";
            if (i_chinhanh != 0) sql += " and (khu=0 or khu=" + i_chinhanh + ") ";
            sql += " order by a.ngay,b.stt";
            dscd = m.get_data_mmyy(sql, tu, den, false);
            //st1.Value = dscd.Tables[0].Select("stt=2").Length;
            //st2.Value = dscd.Tables[0].Select("stt=3").Length;
            //st3.Value = dscd.Tables[0].Select("stt=5").Length;
            //st4.Value = dscd.Tables[0].Select("stt>=10 and stt<=20").Length;
            //st6.Value = dscd.Tables[0].Rows.Count;

            //Tu:26/05/2011
            st1.Value = dscd.Tables[0].Select("id_loai=75 or id_loai=76").Length;
            st2.Value = dscd.Tables[0].Select("id_loai=8").Length;
            st3.Value = dscd.Tables[0].Select("id_loai=65").Length;
            st4.Value = dscd.Tables[0].Select("id_loai=77 or id_loai=78 or id_loai=79 or id_loai=80 or id_loai=81 or id_loai=82").Length;
            st6.Value = dscd.Tables[0].Rows.Count;
            //end
            DataTable tmp = m.get_data("select b.stt from " + user + m.mmyy(ngay.Text) + ".ba_scan a," + user + ".ba_loaiphieu b where a.loai=b.id and a.id=" + l_id).Tables[0];
            st1.Value += tmp.Select("stt=2").Length;
            st2.Value += tmp.Select("stt=3").Length;
            st3.Value += tmp.Select("stt=5").Length;
            st4.Value += tmp.Select("stt>=10 and stt<=20").Length;
            st6.Value += tmp.Rows.Count;
            st5.Value = st6.Value - st1.Value - st2.Value - st3.Value - st4.Value;
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    DataRow r = m.getrowbyid(ds.Tables[0], "id=" + decimal.Parse(list.SelectedValue.ToString()));
            //    if (r != null) get_mabn(r["mabn"].ToString(), decimal.Parse(r["id"].ToString()));
            //}
            if (e.KeyCode == Keys.Escape)
            {
                this.groupBox1.Location = new Point(0, 30);
                this.groupBox1.Size = new Size(206, 253);
            }
        }

        private void butKhoa_Click(object sender, EventArgs e)
        {
            sql = "select a.mabn,a.hoten,a.phai,a.namsinh,a.cholam,a.sonha,a.thon,a.mann,a.matt,a.maqu,a.maphuongxa,";
            sql += "b.dentu,b.nhantu,b.madoituong,f.tuoivao as tuoi,c.sothe,to_char(c.denngay,'dd/mm/yyyy') as denngay,";
            sql += "g.mabv as madstt,g.tenbv as tendstt,d.maicd as icdnoichuyen,d.chandoan as cdnoichuyen,";
            sql += "c.mabv as noicap,b.chandoan,b.maicd,b.mabs,i.hoten as tenbs,b.soluutru,b.maql as mangtr ";
            //sql += " from btdbn a,benhandt b,bhyt c,noigioithieu d,xuatvien e,lienhe f,dstt g,dmnoicapbhyt h,dmbs i ";
            sql += " from " + user + ".btdbn a," + user + ".benhanngtr b," + xxx + ".bhyt c," + user + ".noigioithieu d," + user + ".lienhe f," + user + ".dstt g," + user + ".dmnoicapbhyt h," + user + ".dmbs i ";//,xuatvien e
            sql += " where a.mabn=b.mabn and b.maql=c.maql(+) and b.maql=d.maql(+) and b.maql=f.maql ";
            sql += " and d.mabv=g.mabv(+) and c.mabv=h.mabv(+) and b.mabs=i.ma(+) ";//and b.maql=e.maql(+) 
            sql += " and a.mabn='" + mabn.Text + "' and b.maql=" + l_maql;
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                frmKhambenh_nt f2 = new frmKhambenh_nt(m, s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, mabn.Text, hoten.Text, int.Parse(r["phai"].ToString()), r["namsinh"].ToString(), r["mann"].ToString(), ngay.Text, r["sonha"].ToString(), r["thon"].ToString(), r["cholam"].ToString(), r["matt"].ToString(), r["maqu"].ToString().Substring(0, 3), r["maqu"].ToString().Substring(3), r["maphuongxa"].ToString().Substring(0, 5), r["maphuongxa"].ToString().Substring(5), r["tuoi"].ToString().Substring(0, 3), int.Parse(r["tuoi"].ToString().Substring(3)),
                    decimal.Parse(r["mangtr"].ToString()), l_id, s_makp, ngay.Text, s_makp + ",", int.Parse(r["dentu"].ToString()),
                    int.Parse(r["nhantu"].ToString()), int.Parse(r["madoituong"].ToString()), r["sothe"].ToString(),
                    r["denngay"].ToString(), r["madstt"].ToString(), r["tendstt"].ToString(), r["icdnoichuyen"].ToString(),
                    r["cdnoichuyen"].ToString(), r["noicap"].ToString(), r["chandoan"].ToString(), r["maicd"].ToString(),
                    r["mabs"].ToString(), r["tenbs"].ToString(), r["soluutru"].ToString(), r["sonha"].ToString().Trim() + " " + r["thon"].ToString(), 0,i_chinhanh,l_mavaovien);
                f2.ShowDialog(this);
                if (f2.bravien) butRa_Click(sender, e);
                break;
            }
        }

        private void butChidinh_Click(object sender, EventArgs e)
        {
            if (txtChandoan.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán !"), LibMedi.AccessData.Msg);
                return;
            }
            string stuoi = m.get_tuoivao(l_maql).Trim();
            dllvpkhoa_chidinh.frmChonthongsovp ff = new dllvpkhoa_chidinh.frmChonthongsovp(m, s_makp, i_userid);
            ff.ShowDialog(this);
            if (ff.s_makp != "")
            {
                dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, mabn.Text, hoten.Text, stuoi, ngay.Text, s_makp, s_tenkp, i_madoituong, 1,l_mavaovien , l_maql, l_idkhoa, i_userid, "medibv.benhanngtr", sothe.Text, "", 2, (s_mabs != "") ? s_mabs : "", "", "",i_traituyen,true,i_chinhanh);//bAdmin, l_maql, 3, 0, ff.s_ngay);
                f.ShowDialog(this);
                load_chidinh();
            }
        }

        private void butDieutri_Click(object sender, EventArgs e)
        {
            frmTodieutri f = new frmTodieutri(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin, false, 0, null, i_madoituong);//,(rb2.Checked)?true:false
            f.ShowDialog(this);
        }

        private void butChamsoc_Click(object sender, EventArgs e)
        {
            frmChamsoc f = new frmChamsoc(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butMau_Click(object sender, EventArgs e)
        {
            frmTruyenmau f = new frmTruyenmau(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butLoc_Click(object sender, EventArgs e)
        {
            frmLocmau f = new frmLocmau(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butDich_Click(object sender, EventArgs e)
        {
            frmTruyendich f = new frmTruyendich(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butDausinhton_Click(object sender, EventArgs e)
        {
            frmDausinhton_pk f = new frmDausinhton_pk(m, s_makp, l_maql, m.user + ".benhanngtr", 2, mabn.Text, (decimal)l_mavaovien, ngay.Text, mabs.Text);//
            f.ShowDialog(this);
        }

        private void butPttt_Click(object sender, EventArgs e)
        {
            string stuoi = m.get_tuoivao(l_maql).Trim();
            frmPttt_ba f = new frmPttt_ba(m, s_makp, mabn.Text, hoten.Text, stuoi, phai.Text, diachi.Text,
                sothe.Text, "", ngay.Text, "", "", "P", i_userid, 
                (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), "", 
                "", "", "", "", 0, 0, 0, 0, 0, DateTime.Now.Date.ToString("dd/MM/yyyy"), 0, 0,2);
            f.ShowDialog(this);
        }

        private void butPhanung_Click(object sender, EventArgs e)
        {
            frmPuthuoc f = new frmPuthuoc(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
            f.ShowDialog(this);
        }

        private void butKethuc_Click(object sender, EventArgs e)
        {
            m.close();//v.close();
            System.GC.Collect();
            this.Close();
        }

        private void butVao_Click(object sender, EventArgs e)
        {
            frmNgoaitru f0 = new frmNgoaitru(m, s_makp + ",", s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_nhomkho, s_mabs, i_madoituong.ToString());
            f0.ShowDialog(this);
            if (f0.bUpdate) load_list();
        }

        private void butRa_Click(object sender, EventArgs e)
        {
            frmNgoaitru f0 = new frmNgoaitru(m, s_makp + ",", s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_nhomkho, s_mabs, i_madoituong.ToString(),mabn.Text);
            f0.ShowDialog(this);
            if (f0.bUpdate)
            {
                load_list();
                DataRow r1;
                //foreach(DataRow r in m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,chandoan,maicd,mabs from "+user+".xuatvien where maql="+l_maql).Tables[0].Rows)
                foreach (DataRow r in m.get_data("select to_char(ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,chandoanrv,maicdrv,mabs from " + user + ".benhanngtr where maql=" + l_maql).Tables[0].Rows)
                {
                    mabs.Text = r["mabs"].ToString();
                    r1 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                    if (r1 != null)
                    {
                        tenbs.Text = r1["hoten"].ToString();
                        tenbs_pass.Text = r1["password_"].ToString();
                    }
                    //cd_kkb.Text = r["chandoanrv"].ToString();
                    //icd_kkb.Text = r["maicdrv"].ToString();
                    //ngayrv.Text = r["ngayrv"].ToString().Substring(0, 10);
                    //giorv.Text = r["ngayrv"].ToString().Substring(11);
                    //denngay.Text = r["ngayrv"].ToString();
                    //chandoanrv.Text = r["chandoanrv"].ToString();
                    //icdrv.Text = r["maicdrv"].ToString();
                    break;
                }
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            //if (!kiemtra()) return;
            xxx = user + m.mmyy(ngay.Text);
            bool bNhapkhoa = m.getrowbyid(ds.Tables[0], "nhapkhoa=0 and mabn='" + mabn.Text + "'") != null;
            if (bNhapkhoa)
            {
                string s_tenkp = m.bHiendien(l_maql);
                if (s_tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang hiện diện trong khoa {") + s_tenkp.Trim().ToUpper() + lan.Change_language_MessageText("}" + "\nKhông thể thêm được phải xuất bệnh nhân này ra trước khi nhập khoa !"), LibMedi.AccessData.Msg);
                    //butBoqua_Click(null, null);
                    return;
                }
            }
            //upd_nhapkhoa();
            l_idthuchien = m.get_idthuchien_maql(ngay.Text, l_maql);
            if (l_idthuchien == 0)
            {
                l_idthuchien = m.getidyymmddhhmiss_stt_computer;//get_capid(-300);
                m.upd_ba_thuchien(ngay.Text, l_idthuchien, mabn.Text, l_maql, l_idkhoa, s_makp, "", "", chandoan.Text);
            }
            l_id = m.get_idchung(ngay.Text, l_idthuchien);
            if (l_id == 0) l_id = m.getidyymmddhhmiss_stt_computer;//get_capid(-301);
            if (!m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, 1, hb_benhly.Text, hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", "",
            "", "", "", "", "", "", "", "", "", "", "", txtChandoan.Text,
            "", "", "", tk_benhly.Text, tk_tomtat.Text, "", tk_tinhtrang.Text, tk_dieutri.Text, manguoigiao.Text, manguoinhan.Text, mabs.Text, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                return;
            }
            m.upd_ba_kbdausinhton(ngay.Text, mabn.Text, l_id, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "" && nhietdo.Text.Trim() != ".") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0, (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0);
            m.upd_bavv_mat(ngay.Text, l_maql, vv_kk_mp.Text, vv_kk_mp.Text, vv_ck_mp.Text, vv_ck_mt.Text
                , vv_na_mp.Text, vv_na_mt.Text, vv_tt_mp.Text, vv_tt_mt.Text, new byte[] { },
                "","");
            m.upd_bavv_mat(l_maql,txtledao.Text,txtmimat.Text,txtketmac.Text,txtthmathot.Text,txtgiacmac.Text,
                txtcungmac.Text,txttienphong.Text,txtmongmat.Text,txtdongtupxa.Text,txtthuytinhthe.Text,
                txtthuytinhdich.Text, txtsoianhdongtu.Text, txtthnhancau.Text, txthomat.Text, txtdaymat.Text,
                txtledao_mt.Text, txtmimat_mt.Text, txtketmac_mt.Text, txtthmathot_mt.Text, txtgiacmac_mt.Text,
                txtcungmac_mt.Text, txttienphong_mt.Text, txtmongmat_mt.Text, txtdongtupxa_mt.Text,
                txtthuytinhthe_mt.Text, txtthuytinhdich_mt.Text, txtsoianhdongtu_mt.Text, txtthnhancau_mt.Text,
                txthomat_mt.Text, txtdaymat_mt.Text);
            //Tu:21/05/2011 insert vao bang theodoitsu
            try
            {
                DataSet ds_tiendu = m.get_data("select noidung from " + user + ".theodoitsu where mabn='" + mabn.Text + "'");
                string s_tiensubenh = "";
                if (ds_tiendu != null && ds_tiendu.Tables[0].Rows.Count > 0)
                    s_tiensubenh = ds_tiendu.Tables[0].Rows[0][0].ToString();
                //DataRow dr = m.getrowbyid(dticd, "cicd10='" + icd_kkb.Text.Trim() + "' and tiensubenh=1");
                //if (dr != null)
                //{
                //    int i = 0;
                //    if (s_tiensubenh != "")
                //    {
                //        foreach (string tsu in s_tiensubenh.Split(';'))
                //        {
                //            string s_tsu_tmp = "(" + icd_kkb.Text + ")" + cd_kkb.Text + ";" + "(" + icd_kemtheo.Text + ")" + cd_kemtheo.Text;
                //            if (tsu.Trim() != s_tsu_tmp.Split(';').GetValue(i).ToString())
                //                s_tiensubenh = s_tiensubenh + s_tsu_tmp;
                //            i++;
                //        }
                //    }
                //    //s_tiensubenh = s_tiensubenh + ";" + "(" + icd_chinh.Text + ")" + cd_chinh.Text + ";" + "(" + icd_kemtheo.Text + ")" + phanbiet.Text;
                //    else s_tiensubenh = "(" + icd_kkb.Text + ")" + cd_kkb.Text + ";" + "(" + icd_kemtheo.Text + ")" + cd_kemtheo.Text;
                //    m.upd_theodoitsu(mabn.Text, s_tiensubenh);
                //    decimal i_stt_tsu = 0;
                //    try { i_stt_tsu = decimal.Parse(m.get_data("select (max(stt)+1) from " + user + ".dmtheodoi").Tables[0].Rows[0][0].ToString()); }
                //    catch { i_stt_tsu = 1; }
                //    m.upd_dmtheodoi(icd_kkb.Text, i_stt_tsu, cd_kkb.Text);
                //}
                if (txtChandoan.Text != "")
                {
                    if (s_tiensubenh != "") s_tiensubenh = s_tiensubenh + ";" + txtChandoan.Text;
                    else s_tiensubenh = txtChandoan.Text;
                    m.upd_theodoitsu(mabn.Text, s_tiensubenh,ngay.Text,"",1);
                }
                //DataRow dr1 = m.getrowbyid(dticd, "cicd10='" + icd_kkb.Text.Trim() + "' and benhmantinh=1");
                //if (dr1 != null)
                //    m.upd_benhmantinh(mabn.Text, cd_kkb.Text, icd_kkb.Text, "", i_userid);
            }
            catch { }
            //end Tu
            m.execute_data("delete from " + xxx + ".ba_tkhoso where id=" + l_id);
            if (st1.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 1, "", st1.Value);
            if (st2.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 2, "", st2.Value);
            if (st3.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 3, "", st3.Value);
            if (st4.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 4, "", st4.Value);
            if (st5.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 5, khac.Text, st5.Value);
            if (st6.Value != 0) m.upd_ba_tkhoso(ngay.Text, mabn.Text, l_id, 6, "", st6.Value);
            ena_object(true);
            if (bNhapkhoa) load_list();
        }

        private void butHinh_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "") return;
            if (l_maql == 0)
            {
                butLuu_Click(sender, e);
                ena_object(false);
            }
            frmBAMAT f = new frmBAMAT(m,l_maql,ngay.Text);
            f.ShowDialog();
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ena_object(true);

            if (list.Items.Count > 0)
            {
                this.groupBox1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y);
                this.groupBox1.Size = new Size(tabControl1.Right, tabControl1.Bottom);
            }
        }

        private void butChon_Click(object sender, EventArgs e)
        {
            if ((xem.SelectedIndex == 12 || xem.SelectedIndex == 0) && (l_id == 0))
            {
                //if (!kiemtra()) return;
                xxx = user + m.mmyy(ngay.Text);
                bool bNhapkhoa = m.getrowbyid(ds.Tables[0], "nhapkhoa=0 and mabn='" + mabn.Text + "'") != null;
                if (bNhapkhoa)
                {
                    string s_tenkp = m.bHiendien(l_maql);
                    if (s_tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang hiện diện trong khoa {") + s_tenkp.Trim().ToUpper() + lan.Change_language_MessageText("}" + "\nKhông thể thêm được phải xuất bệnh nhân này ra trước khi nhập khoa !"), LibMedi.AccessData.Msg);
                        butBoqua_Click(null, null);
                        return;
                    }
                    //upd_nhapkhoa();
                }
                m.execute_data("update " + user + ".benhandt set mabs='" + mabs.Text + "' where maql=" + l_maql);
                l_idthuchien = m.get_idthuchien(ngay.Text, l_idkhoa);
                if (l_idthuchien == 0)
                {
                    l_idthuchien = m.getidyymmddhhmiss_stt_computer;//get_capid(-300);
                    m.upd_ba_thuchien(ngay.Text, l_idthuchien, mabn.Text, l_maql, l_idkhoa, s_makp, "", "", chandoan.Text);
                }
                l_id = m.get_idchung(ngay.Text, l_idthuchien);
                if (l_id == 0) l_id = m.getidyymmddhhmiss_stt_computer;//get_capid(-301);
                m.upd_ba_chung(ngay.Text, mabn.Text, l_id, l_idthuchien, lydo.Text, 1, hb_benhly.Text, hb_banthan.Text, hb_giadinh.Text, kb_toanthan.Text, "", "",
                    "", "", "", "", "", "", "", "", "", "", "", "",
                    "", "", "", tk_benhly.Text, tk_tomtat.Text, "", tk_tinhtrang.Text, tk_dieutri.Text, manguoigiao.Text, manguoinhan.Text, mabs.Text, i_userid);
            }
            if (xem.SelectedIndex == 10 && i_loai == 1) return;
            switch (xem.SelectedIndex)
            {
                case 0: frmVanchuyen f0 = new frmVanchuyen(m, mabn.Text, l_maql, l_idkhoa, l_idthuchien, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f0.ShowDialog(this);
                    break;
                case 2: frmHoichancc f2 = new frmHoichancc(m, ds, 0, l_idthuchien, mabn.Text, s_makp, s_tenkp, i_userid, bAdmin, ngay.Text);
                    f2.ShowDialog(this);
                    break;
                case 3: frmKiemsoatcc f3 = new frmKiemsoatcc(m, mabn.Text, l_maql, l_idkhoa, l_idthuchien, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f3.ShowDialog(this);
                    break;
                case 4: frmHoichan f4 = new frmHoichan(m, ds, 0, l_idthuchien, mabn.Text, s_makp, s_tenkp, i_userid, bAdmin, ngay.Text);
                    f4.ShowDialog(this);
                    break;
                case 5: frmKiemsoat f5 = new frmKiemsoat(m, mabn.Text, l_maql, l_idkhoa, l_idthuchien, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f5.ShowDialog(this);
                    break;
                case 6: frmHcthuoc f6 = new frmHcthuoc(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f6.ShowDialog(this);
                    break;
                case 7: frmDanhgia f7 = new frmDanhgia(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f7.ShowDialog(this);
                    break;
                case 8: frmCamdoan f8 = new frmCamdoan(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f8.ShowDialog(this);
                    break;
                case 9: frmLinhmau f9 = new frmLinhmau(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f9.ShowDialog(this);
                    break;
                case 10: frmGiaonhan f10 = new frmGiaonhan(m, mabn.Text, l_maql, l_idkhoa, l_idthuchien, l_id, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f10.ShowDialog(this);
                    break;
                case 11: frmSoket f11 = new frmSoket(m, mabn.Text, l_maql, l_idkhoa, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_userid, chandoan.Text, s_tenkp, bAdmin);
                    f11.ShowDialog(this);
                    break;
                case 12: frmBascan f12 = new frmBascan(m, 0, mabn.Text, l_maql, l_idkhoa, l_id, s_sovaovien, s_makp, hoten.Text, namsinh.Text, phai.Text, diachi.Text, ngay.Text, sothe.Text, "", "", (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10), s_mabs, i_userid, s_nhomkho, s_userid, chandoan.Text, s_tenkp);
                    f12.ShowDialog(this);
                    break;
                case 13: frmXemthuoc f13 = new frmXemthuoc(m, l_maql, hoten.Text, "", "");
                    f13.ShowDialog(this);
                    break;
                case 14: frmCongkhaiMabn f14 = new frmCongkhaiMabn(mabn.Text);
                    f14.ShowDialog(this);
                    break;
                case 15: frmCongnoMabn f15 = new frmCongnoMabn(m, mabn.Text, l_maql, DateTime.Now.Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"));
                    f15.ShowDialog(this);
                    break;
                case 19:
                    if (mabn.Text == "" || hoten.Text == "") return;
                    int ituoi = (namsinh.Text != "") ? DateTime.Now.Year - int.Parse(namsinh.Text) : 0;
                    frmCanlamsan.frmXemCanLamSan_medi f = new frmCanlamsan.frmXemCanLamSan_medi(mabn.Text, hoten.Text, (ituoi != 0) ? ituoi.ToString() : "", diachi.Text);
                    f.ShowDialog(this);
                    break;
            }
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == rb1) load_list();
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == rb2) load_list();
        }

        private void vv_kk_mp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void vv_kk_mt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vv_na_mp_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vv_na_mt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vv_ck_mp_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vv_ck_mt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vv_tt_mp_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vv_tt_mt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtledao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtmimat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtketmac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthmathot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtgiacmac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtcungmac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txttienphong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtmongmat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtdongtupxa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthuytinhthe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthuytinhdich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtsoianhdongtu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthnhancau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txthomat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtdaymat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtledao_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtmimat_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtketmac_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthmathot_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtgiacmac_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtcungmac_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txttienphong_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtmongmat_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtdongtupxa_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthuytinhthe_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthuytinhdich_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtsoianhdongtu_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthnhancau_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txthomat_mt_TextChanged(object sender, EventArgs e)
        {
        }

        private void txthomat_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtdaymat_mt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void butphanungthuocohai_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "") return;
            //l_maql = m.get_maql_mmyy(2, mabn.Text, makp.Text, ngayvv.Text, false);
            //if (l_maql == 0)
            //{
            //    butLuu_Click(sender, e);
            //    if (!bExit) return;
            //    ena_but(false);
            //}
            frmPhanungthuoccohai f = new frmPhanungthuoccohai(m, s_makp, "", mabn.Text, i_userid, txtChandoan.Text, s_userid, l_mavaovien, l_maql, ngay.Text, i_loai, i_maba, i_mabv,2);
            f.ShowDialog();
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "") return;
            if (chonin.CheckedItems.Count == 0)
                for (int i = 0; i < chonin.Items.Count; i++) chonin.SetItemCheckState(i, CheckState.Checked);
            for (int i = 0; i < chonin.Items.Count; i++)
                if (chonin.GetItemChecked(i)) page(i);
        }
        #region Page
        private void page(int loai)
        {
            DataSet dsxml = new DataSet();
            if (chkXML.Checked)
                if (!Directory.Exists("..\\xml")) Directory.CreateDirectory("..\\xml");
            if (chonin.GetItemChecked(1) || chonin.GetItemChecked(2) || chonin.GetItemChecked(3))
            {
                dsxml = get_data();
                if (chkXML.Checked) dsxml.WriteXml("..\\xml\\page2.xml", XmlWriteMode.WriteSchema);
            }
            switch (loai)
            {
                case 0: page_1(); break;
                case 1: page_2(dsxml); break;
            }
        }
        private void page_1()
        {
            ds1 = new DataSet();
            string tenfile = "BenhAnNgoaiKhoa", m_manuoc = "", m_tennuoc = "", stuoi = m.get_tuoivao(l_maql).Trim(), m_songaydt = "", m_cd_noichuyenden = "", m_icd_noichuyenden = "", m_tdvh = "", m_ngaybong = "";
            string m_songaydieutrivaokhoa = "", m_chuyenkhoa1 = "", m_ngaychuyenkhoa1 = "", m_songaydieutrichuyenkhoa1 = "", m_chuyenkhoa2 = "", m_ngaychuyenkhoa2 = "", m_songaydieutrichuyenkhoa2 = "";
            string m_chuyenkhoa3 = "", m_ngaychuyenkhoa3 = "", m_songaydieutrichuyenkhoa3 = "", m_ngaytuvong = "", m_tinhtrangtuvong = "", m_thoidiemtuvong = "", m_nguyennhantuvong = "", m_icdnguyennhantuvong = "";
            string m_cokhamnghiemtuthi = "", m_chandoantuthi = "", m_icdchandoantuthi = "", m_nguyennhantaibienbienchung = "", m_tongsongaydieutrisauphauthuat = "", m_tongsolanphauthuat = "", m_chandoantruocphauthuat = "";
            string m_icdchandoantruocphauthuat = "", m_chandoansauphauthuat = "", m_icdchandoansauphauthuat = "", m_tinhtrangphauthuat = "";
            sql = "select a.mabn,a.makp,a.soluutru,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
            sql += "to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh,c.phai,c.sonha,c.thon,c.matt,c.maqu,c.maphuongxa,c.mann,d.tennn,c.madantoc,e.dantoc as tendantoc,";
            sql += "f.tentt,g.tenquan,h.tenpxa,c.cholam,a.madoituong,i.sothe,to_char(i.denngay,'dd/mm/yyyy') as denngay,";
            sql += "j.hoten as qh_hoten,j.dienthoai as qh_dienthoai,a.nhantu,a.dentu,";//,a.lanthu
            sql += "nvl(m.loaibv,0) as loaibv,n.tenbv,nvl(a.ttlucrv,0) as ttlucrv,a.chandoan as chandoanvv,a.maicd as maicdvv,";
            sql += "a.chandoanrv as chandoanrv,a.maicdrv as maicdrv,a.taibien,a.bienchung,a.giaiphau,nvl(a.ketqua,0) as ketqua,";
            sql += "nvl(s.ten,a.giaiphau) as giaiphau,t.chandoan as chandoannn,t.maicd as maicdnn";
            sql += " from " + user + ".benhanngtr a," + user + ".btdbn c," + user + ".btdnn_bv d," + user + ".btddt e," + user + ".btdtt f," + user + ".btdquan g," + user + ".btdpxa h," + user + ".bhyt i,";
            sql += " " + user + ".quanhe j," + user + ".chuyenvien m," + user + ".tenvien n," + user + ".gphaubenh s," + user + ".cdnguyennhan t";
            sql += " where a.mabn=c.mabn and c.mann=d.mann and c.madantoc=e.madantoc ";//a.maql=b.maql(+) and 
            sql += " and c.matt=f.matt and c.maqu=g.maqu and c.maphuongxa=h.maphuongxa ";
            sql += " and a.maql=i.maql(+) and a.maql=j.maql(+) and a.maql=m.maql(+) and m.mabv=n.mabv(+) ";
            sql += " and a.giaiphau=s.ma(+) and a.maql=t.maql(+)";
            sql += " and a.maql=" + l_maql;//and a.loaiba=2
            //= m.get_data(sql);
            DataTable dt1 = m.get_data(sql).Tables[0]; dt1.TableName = "dt1";
            ds1.Tables.Add(dt1.Copy());
            tenfile = "rPage98_mat";
            bool bFile = false;
            if (ds1.Tables[0].Rows.Count == 0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            else
            {
                if (chkXML.Checked) ds1.WriteXml("..\\xml\\page1.xml", XmlWriteMode.WriteSchema);
                DataColumn dc = new DataColumn("Image", typeof(byte[]));
                ds1.Tables[0].Columns.Add(dc);
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    //DataRow r2 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                    DataTable dthinh = m.get_data("select * from " + xxx + ".bavv_mat where maql=" + l_maql + " ").Tables[0];
                    DataRow r2 = m.getrowbyid(dthinh, "maql=" + l_maql + "");
                    System.IO.FileStream file;
                    bFile = r2 != null;
                    if (bFile)
                    {
                        image = new byte[0];
                        try
                        {
                            image = (byte[])(r2["hinh"]);
                            if (image.Length == 0)
                            {
                                file = new FileStream("bangmat_01.bmp", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                image = new byte[file.Length];
                                file.Read(image, 0, System.Convert.ToInt32(file.Length));
                                //image = (byte[])(image);
                            }
                        }
                        catch { }
                    }
                    if (bFile) r["image"] = image;
                    if (r["ngayrv"].ToString() != "") m_songaydt = m.songay(m.StringToDate(r["ngayrv"].ToString()), m.StringToDate(r["ngayvv"].ToString()), 1).ToString();
                    if (m.get_data("select * from " + user + ".chuyenkhoa where maql=" + l_maql).Tables[0].Rows.Count != 0)
                    {
                        DataTable dtck = new DataTable();
                        dtck = m.get_data("select khoaden,to_char(ngaychuyen,'dd/mm/yyyy hh24:mi') as ngaychuyen from " + user + ".chuyenkhoa where maql=" + l_maql + " order by ngaychuyen").Tables[0];
                        m_chuyenkhoa1 = dtck.Rows[0]["khoaden"].ToString();
                        m_ngaychuyenkhoa1 = dtck.Rows[0]["ngaychuyen"].ToString();
                        //m_songaydieutrivaokhoa = m.songay(m.StringToDate(m_ngaychuyenkhoa1.Substring(0, 10)), m.StringToDate(ngayvk.Text.Substring(0, 10)), 1).ToString();
                        m_songaydieutrivaokhoa = m.songay(m.StringToDate(m_ngaychuyenkhoa1.Substring(0, 10)), m.StringToDate(s_ngayvk.Substring(0, 10)), 1).ToString();
                        if (dtck.Rows.Count > 1)
                        {
                            m_chuyenkhoa2 = dtck.Rows[1]["khoaden"].ToString();
                            m_ngaychuyenkhoa2 = dtck.Rows[1]["ngaychuyen"].ToString();
                            m_songaydieutrichuyenkhoa1 = m.songay(m.StringToDate(m_ngaychuyenkhoa2.Substring(0, 10)), m.StringToDate(m_ngaychuyenkhoa1.Substring(0, 10)), 0).ToString();
                        }
                        else if (m_ngaychuyenkhoa1 != "" && r["ngayrv"].ToString() != "") m_songaydieutrichuyenkhoa1 = m.songay(m.StringToDate(r["ngayrv"].ToString()), m.StringToDate(m_ngaychuyenkhoa1.Substring(0, 10)), 0).ToString();
                        if (dtck.Rows.Count > 2)
                        {
                            m_chuyenkhoa3 = dtck.Rows[2]["khoaden"].ToString();
                            m_ngaychuyenkhoa3 = dtck.Rows[2]["ngaychuyen"].ToString();
                            m_songaydieutrichuyenkhoa2 = m.songay(m.StringToDate(m_ngaychuyenkhoa3.Substring(0, 10)), m.StringToDate(m_ngaychuyenkhoa2.Substring(0, 10)), 0).ToString();
                            if (r["ngayrv"].ToString() != "") m_songaydieutrichuyenkhoa3 = m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0, 10)), m.StringToDate(m_ngaychuyenkhoa3.Substring(0, 10)), 0).ToString();
                        }
                        else if (m_ngaychuyenkhoa2 != "" && r["ngayrv"].ToString() != "") m_songaydieutrichuyenkhoa2 = m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0, 10)), m.StringToDate(m_ngaychuyenkhoa2.Substring(0, 10)), 0).ToString();
                    }
                    else if (r["ngayrv"].ToString() != "") m_songaydieutrivaokhoa = m.songay(m.StringToDate(r["ngayrv"].ToString().Substring(0, 10)), m.StringToDate(s_ngayvk.Substring(0, 10)), 1).ToString();

                    if (m.get_data("select * from " + user + ".tuvong where maql=" + l_maql).Tables[0].Rows.Count != 0)
                    {
                        m_ngaytuvong = r["ngayrv"].ToString();
                        DataTable dttv = new DataTable();
                        dttv = m.get_data("select chandoan,maicd,nguyennhan,benhly,khamtuthi from " + user + ".tuvong where maql=" + l_maql).Tables[0];
                        m_tinhtrangtuvong = dttv.Rows[0]["nguyennhan"].ToString();
                        m_cokhamnghiemtuthi = dttv.Rows[0]["khamtuthi"].ToString();
                        if (m_cokhamnghiemtuthi == "1")
                        {
                            m_chandoantuthi = dttv.Rows[0]["chandoan"].ToString();
                            m_icdchandoantuthi = m.Maicd_rpt(dttv.Rows[0]["maicd"].ToString());
                        }
                        m_nguyennhantuvong = r["chandoanrv"].ToString();
                        m_icdnguyennhantuvong = m.Maicd_rpt(r["maicdrv"].ToString());
                    }
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".noigioithieu where maql=" + l_maql).Tables[0].Rows)
                    {
                        m_cd_noichuyenden = r1["chandoan"].ToString();
                        m_icd_noichuyenden = r1["maicd"].ToString();
                    }

                    if (r["madantoc"].ToString() == "55")
                    {
                        foreach (DataRow r1 in m.get_data("select a.ma,a.ten from " + user + ".dmquocgia a," + user + ".nuocngoai b where a.ma=b.id_nuoc and b.mabn='" + mabn.Text + "'").Tables[0].Rows)
                        {
                            m_manuoc = r1["ma"].ToString();
                            m_tennuoc = r1["ten"].ToString();
                            break;
                        }
                    }
                    sql = "select * from " + user + ".bavv_mat where maql=" + l_maql + " ";
                    DataTable dt2 = m.get_data(sql).Tables[0]; dt2.TableName = "dt2";
                    ds1.Tables.Add(dt2.Copy());
                    ds1.WriteXml(@"c:\ngtrumat.xml",XmlWriteMode.WriteSchema);
                    string s_chinhanh = "";
                    for (int i = 0; i < 2; i++)
                    {
                        dllReportM.frmReport f = new dllReportM.frmReport(m, ds1, tenfile, "NNT", s_tenkp, "", r["soluutru"].ToString(), m.Mabv + "/" + mabn.Text.Substring(0, 2) + "/" + mabn.Text.Substring(2), hoten.Text, r["ngaysinh"].ToString(), (stuoi.Substring(3) == "0") ? stuoi.Substring(1, 3) : "000", r["phai"].ToString(),
                        r["tennn"].ToString(), r["mann"].ToString(), r["tendantoc"].ToString(), r["madantoc"].ToString(), m_tennuoc, m_manuoc, r["sonha"].ToString(), r["thon"].ToString(),
                        r["tenpxa"].ToString(), r["tenquan"].ToString(), r["maqu"].ToString(), r["tentt"].ToString(), r["matt"].ToString(), r["cholam"].ToString(), r["madoituong"].ToString(),
                        r["denngay"].ToString(), r["sothe"].ToString(), r["qh_hoten"].ToString(), r["qh_dienthoai"].ToString(), m_ngaybong, r["ngayvv"].ToString(),
                        r["nhantu"].ToString(), r["dentu"].ToString(), "", r["makp"].ToString(), s_ngayvk.Substring(0, 10) + " " + s_ngayvk.Substring(11),
                        m_songaydieutrivaokhoa, m_chuyenkhoa1, m_ngaychuyenkhoa1, m_songaydieutrichuyenkhoa1, m_chuyenkhoa2, m_ngaychuyenkhoa2, m_songaydieutrichuyenkhoa2, m_chuyenkhoa3, m_ngaychuyenkhoa3, m_songaydieutrichuyenkhoa3,
                        r["loaibv"].ToString(), r["tenbv"].ToString(), r["ngayrv"].ToString(), r["ttlucrv"].ToString(), m_songaydt,
                        m_cd_noichuyenden, m.Maicd_rpt(m_icd_noichuyenden), r["chandoanvv"].ToString(), m.Maicd_rpt(r["maicdvv"].ToString()),
                        "", "", "0", "0", r["chandoanrv"].ToString(),//m.Maicd_rpt(icd_kkb.Text)
                        m.Maicd_rpt(r["maicdrv"].ToString()), "", "",//m.Maicd_rpt(icd_kemtheo.Text)
                        r["taibien"].ToString(), r["bienchung"].ToString(), r["ketqua"].ToString(), r["giaiphau"].ToString(), m_ngaytuvong, m_tinhtrangtuvong, m_thoidiemtuvong,
                        m_nguyennhantuvong, m_icdnguyennhantuvong, m_cokhamnghiemtuthi, m_chandoantuthi, m_icdchandoantuthi, m_nguyennhantaibienbienchung, m_tongsongaydieutrisauphauthuat,
                        m_tongsolanphauthuat, r["chandoannn"].ToString(), m.Maicd_rpt(r["maicdnn"].ToString()), m_chandoantruocphauthuat, m_icdchandoantruocphauthuat, m_chandoansauphauthuat,
                        m_icdchandoansauphauthuat, m_tinhtrangphauthuat, m_tdvh, "",
                        lydo.Text, hb_benhly.Text, hb_giadinh.Text, hb_banthan.Text, kb_toanthan.Text, "", "", "", "", "", "", "", "",
                            "", "", "", "", "", tungay.Text, denngay.Text, s_ngayvk.Substring(0, 10), s_ngayvk.Substring(11), tenbs.Text, "", "", "", "", "", "", "", "", txtChandoan.Text);//chandoanrv.Text,m.Maicd_rpt(icdrv.Text)
                        f.ShowDialog();//r["lanthu"].ToString()
                        tenfile = tenfile + 1;
                    }
                }
            }
        }

        private void page_2(DataSet ds1)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds1, "", "rPage99_mat.rpt");
                f.ShowDialog();
            }
        }

        private DataSet get_data()
        {
            string c01 = "", c02 = "", c03 = "", c04 = "", xn01 = "", xn02 = "", xn03 = "", xn04 = "", xn05 = "";
            foreach (DataRow r in dscd.Tables[0].Rows)
            {
                xn01 += r["ngay"].ToString().Trim() + "\n";
                xn02 += r["tenkp"].ToString().Trim() + "\n";
                xn03 += r["tenbs"].ToString().Trim() + "\n";
                xn04 += r["ten"].ToString().Trim() + "\n";
                xn05 += r["ketqua"].ToString().Trim() + "\n";
            }
            sql = "select a.*,b.mach,b.nhietdo,b.huyetap,b.nhiptho,b.cannang,'' as c01,'' as c02,'' as c03,'' as c04,";
            sql += "'' as xn01,'' as xn02,'' as xn03,'' as xn04,'' as xn05,";
            sql += "'' as chandoan,'' as chandoankem,'' as phanbiet,'' as bacsiba,0 as pt,0 as tt,'' as tennguoigiao,'' as tennguoinhan,'' as bacsi,";
            sql += "'' as ngayba,'' as ngaydt,0 as xq,0 as ct,0 as sa,0 as xn,0 as stkhac,'' as loaikhac,0 as tong,";
            sql += "0 as k01,0 as k02,0 as k03,0 as k04,0 as k05,0 as k06,'' as t01,'' as t02,'' as t03,'' as t04,'' as t05,'' as t06";
            sql += " from " + xxx + ".ba_chung a," + xxx + ".ba_kbdausinhton b where a.id=b.id(+) and a.id=" + l_id;
            DataSet ds1 = m.get_data(sql);
            bool bFile = false;
            if (ds1.Tables[0].Rows.Count != 0)
            {
                DataColumn dc = new DataColumn("Image", typeof(byte[]));
                ds1.Tables[0].Columns.Add(dc);
                DataRow r1 = m.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                bFile = r1 != null;
                if (bFile)
                {
                    image = new byte[0];
                    try
                    {
                        image = (byte[])(r1["image"]);
                    }
                    catch { }
                }
                string s = "";
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    if (hb_banthan.Text != "") s += hb_banthan.Text.Trim() + "\n";
                    r["hb_banthan"] = s;
                    s = "";
                    //if (kb_tomtat.Text != "") s += kb_tomtat.Text.Trim();
                    r["kb_tomtat"] = s;
                    //r["chandoan"] = cd_kkb.Text;
                    //r["chandoankem"] = cd_kemtheo.Text;
                    //r["phanbiet"] = phanbiet.Text;
                    r["xn01"] = xn01; r["xn02"] = xn02;
                    r["xn03"] = xn03; r["xn04"] = xn04; r["xn05"] = xn05;
                    r["c01"] = c01; r["c02"] = c02;
                    r["c03"] = c03; r["c04"] = c04;
                    //r["bacsiba"] = tenbsnb.Text;
                    r["bacsi"] = tenbs.Text;
                    r["ngayba"] = s_ngayvk.Substring(0,10) + " " + s_ngayvk.Substring(11);
                    r["ngaydt"] = ngayrv.Text + " " + giorv.Text;
                    r["tennguoigiao"] = nguoigiao.Text;
                    r["tennguoinhan"] = nguoinhan.Text;
                    r["xq"] = st1.Value; r["ct"] = st2.Value;
                    r["sa"] = st3.Value; r["xn"] = st4.Value;
                    r["loaikhac"] = khac.Text; r["stkhac"] = st5.Value;
                    r["tong"] = st6.Value;
                    if (bFile) r["image"] = image;
                }
            }
            return ds1;
        }
        #endregion

        private void st3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void list_MouseEnter(object sender, EventArgs e)
        {
            if (list.Items.Count > 0 && mabn.Text == "")
            {
                this.groupBox1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y);
                this.groupBox1.Size = new Size(tabControl1.Right, tabControl1.Bottom);
            }
        }

        private void tim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.groupBox1.Location = new Point(0, 30);
                this.groupBox1.Size = new Size(206, 253);
            }
        }

        private void chieucao_Validated(object sender, EventArgs e)
        {
            tinh_bmi();
        }

        private void butVantay_Click(object sender, EventArgs e)
        {

            lay_mabn_vantay();
        }
        void lay_mabn_vantay()
        {
            string tmp_mabn = mabn.Text.Trim();
            string ma_vantay = "";
            FingerApp.FrmNhanDang fnhandang = new FingerApp.FrmNhanDang(ptb);
            fnhandang.ShowDialog();
            ma_vantay = fnhandang.mabn;
            if (ma_vantay.Length == i_maxlength_mabn)
            {
                mabn.Text = ma_vantay;
                //mabn_Validated(null, null);
                //ngayvk.Focus();
                SendKeys.Send("{Home}");
            }
        }

        private void butgoibenh_Click(object sender, EventArgs e)
        {
            int stt = 0;
            string sott = "";
            if (list.Items.Count > 0)
            {
                DataRow r1 = m.getrowbyid(ds.Tables[0], "stt=" + decimal.Parse(list.SelectedValue.ToString()));
                if (r1 != null) stt = (r1["sovaovien"].ToString() == "") ? 0 : int.Parse(r1["sovaovien"].ToString());
                if (stt != 0)
                {
                    sott = stt.ToString(); 
                }
            }
            if (sott == "") return;
            tu.Value = stt;
            den.Value = stt;
            tu.Update(); den.Update();
            //if (bBangDienPhongKham) 
                m.goi_kham(ngay.Text, s_makp, sott, sott, true);
            string input = "";
            string s_khoitao = "T00_0";
            //if (bPhongkham_bangdien_kontum)
            //{
            //    s_khoitao = "[L0F";
            //}
            input = Microsoft.VisualBasic.Strings.Chr(2) + s_khoitao + sott.PadLeft(3, '0') + Microsoft.VisualBasic.Strings.Chr(3);
            if (!MSComm1.IsOpen) { OpenPort(); }
            MSComm1.Write(input);
        }
        void OpenPort()
        {
            ///Baudrate, parity, databit,topbit
            string setting = "9600,n,8,1";
            string ports = "COM1", _Parity = "";
            try
            {
                DataSet dsCom = new DataSet();
                dsCom.ReadXml(@"..\..\..\xml\m_cauhinh.xml", XmlReadMode.ReadSchema);
                ports = dsCom.Tables[0].Rows[0]["port"].ToString().ToUpper();
                setting = dsCom.Tables[0].Rows[0]["config"].ToString();
            }
            catch
            {
                //bBangDienPhongKham = false;
                MessageBox.Show(lan.Change_language_MessageText("Không thể xuất số thứ tự ra bảng điện."));
                return;
            }
            bool error = false;
            string[] set = setting.Split(',');
            switch (set[1].ToString())
            {
                case "n":
                    _Parity = "None";
                    break;
                case "e":
                    _Parity = "Even";
                    break;
                case "o":
                    _Parity = "Odd";
                    break;
            }
            if (MSComm1.IsOpen) MSComm1.Close();
            MSComm1.BaudRate = int.Parse(set[0].ToString());
            MSComm1.DataBits = int.Parse(set[2].ToString());
            MSComm1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), set[3].ToString());
            MSComm1.Parity = (Parity)Enum.Parse(typeof(Parity), _Parity);
            MSComm1.PortName = ports;

            try
            {
                // Open the port
                MSComm1.Open();
            }
            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }
            if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}