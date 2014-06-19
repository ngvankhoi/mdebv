
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using LibVP;
using System.Threading;


namespace Vienphi
{
    public partial class frmGiavp : Form
    {
        //linh 
        bool bLocal = true;
        string s_query_vp = "";
        private string m_id_gia = "";
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_menu_id = "menu_C_1_1_Giavp";
        private LibVP.AccessData m_v = AccessData.GetImplement();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private string m_userid = "", m_id_loai = "", m_id = "", sql, user, sdbclient = "";
        private int itable, ichinhanh;
        private bool bCncenter = false;
        private bool bKhoan = false;
        private bool bQuanly_theokhu = false, bChenhlech_laygiaphuthu = false;
        DataSet dscoso = new DataSet();
        DataSet dsphthuchien = new DataSet();
        DataSet dscbchinhanh = new DataSet();
        public frmGiavp(LibVP.AccessData v_v, string v_userid, int _ichinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = v_v;
            m_userid = v_userid;
            ichinhanh = _ichinhanh;
            m_v.f_SetEvent(this);
        }
        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            //linh
            user = m.user;
            bCncenter = m_v.bServercenter(ichinhanh);
            sdbclient = "";
            f_load_chinhanh();
            cbchinhanh.Enabled = false;
            if (cbchinhanh.Items.Count > 0)
            {
                cbchinhanh.SelectedValue = ichinhanh;
                cbchinhanh.Enabled = (cbchinhanh.Items.Count > 1 && bCncenter);
                sdbclient = m_v.get_Tendatabase(ichinhanh).Trim('@');
            }
            else
            {
                sdbclient = "";
            }
            check_local(ichinhanh);
            bChenhlech_laygiaphuthu = m_v.bChenhlech_laygiaphuthu;
            //f_capnhat_db_danhmuc();
            DataTable dttemp = new DataTable();
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            //end linh
            try
            {
                dttemp = m_v.get_data("select * from " + user + ".v_dmloaibc" + sdbclient + " order by id").Tables[0];
                cboLoaiBC.DataSource = dttemp;
                cboLoaiBC.DisplayMember = "tenloaibc";
                cboLoaiBC.ValueMember = "maloai_bc";
            }
            catch { }
            bKhoan = m.bKhoan_vtth;
            bQuanly_theokhu = m_v.bQuanly_theokhu;
            itable = m_v.tableid("", "v_giavp");
            try
            {
                dscoso = m_v.get_data(" select id,ten from " + user + ".dmchinhanh" + sdbclient + " order by id ");
                chklistCosoduocthay.DataSource = dscoso.Tables[0];
                chklistCosoduocthay.DisplayMember = "ten";
                chklistCosoduocthay.ValueMember = "id";
            }
            catch { }
            // hien them: mau thu
            try
            {
                cmbMauthu.DisplayMember = "ten";
                cmbMauthu.ValueMember = "id";
                cmbMauthu.DataSource = m_v.get_data("select -1 as id, '    ' as ten union all select id,ten from " + user + ".xn_mauthu" + sdbclient + " order by ten").Tables[0];
            }
            catch
            { }
            // end hien
            try
            {
                cbVatchuamau.DisplayMember = "ten";
                cbVatchuamau.ValueMember = "id";
                cbVatchuamau.DataSource = m_v.get_data("select -1 as id, '    ' as ten union all select id,ten from medibv.xn_dmvatchuabp" + sdbclient + " order by ten").Tables[0];
            }
            catch
            { }
            //linh
            //if (dscoso.Tables[0].Rows.Count > 0)
            //{
            //bCncenter = m_v.bServercenter(ichinhanh);
            //sdbclient = m_v.get_Tendatabase(ichinhanh).Replace("@", "");
            //    f_load_chinhanh();
            //}
            if (bCncenter || cbchinhanh.Items.Count == 0)
            {
                butMoi.Visible = true;
                butChuyen.Text = "Chuyển dữ liệu";
                if (cbchinhanh.Items.Count == 0)
                {
                    butChuyen.Visible = false;
                }
            }
            else
            {
                butMoi.Visible = false;
                butChuyen.Text = "Lấy dữ liệu";
            }
            //end linh
            sql = "select id,ma,ten,dvt,gia_th,gia_bh,gia_dv,gia_nn,gia_cs,gia_ksk,bhyt,0 as sotienkhuyenmai,0 as tylekhuyenmai, '' as tendot, 0 as iddot  from medibv.v_giavp where hide=0 order by ten";
            dtgridviewGiavp.DataSource = m_v.get_data(sql).Tables[0];
            f_Load_coso();
            f_Load_File_Phongthuchiencls();
            f_Load_DG();
            f_Load_Tree();
            f_Load_Kythuatcao();
            f_Enable(false);
            lan.Read_dtgrid2002_to_Xml(DtgGiavp, this.Name + "_" + "DataGrid1");
            lan.Change_dtgrid2002_HeaderText_to_English(DtgGiavp, this.Name + "_" + "DataGrid1");
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        bool check_local(int i_idchinhanh)
        {
            string IP_Local = m.Maincode("Ip");
            DataRow rcn = m.getrowbyid(dscbchinhanh.Tables[0], "id=" + i_idchinhanh.ToString());
            if (rcn != null)
            {
                string IP = rcn["ip"].ToString();
                bLocal = (IP == IP_Local);
            }
            else
            {
                bLocal = true;
            }
            if (bLocal)
            {
                sdbclient = "";
            }
            return bLocal;
        }
        private void f_Load_coso()
        {
            try
            {
                //linh
                //string s_sql = "select id,ten,ip,trungtam,database from " + user + ".dmchinhanh" + sdbclient + "";
                //s_sql += " order by ten";
                //dscoso = m_v.get_data(s_sql);//linh bỏ where 1=0");
                //DataRow r = dscoso.Tables[0].NewRow();
                //r["id"] = 0;
                //r["ten"] = "";
                //dscoso.Tables[0].Rows.Add(r);
                //foreach (DataRow dr in m_v.get_data(" select id,ten from " + user + ".dmchinhanh order by id ").Tables[0].Rows)
                //{
                //    dscoso.Tables[0].Rows.Add(dr.ItemArray);
                //}
                //end
                cbChdencoso.DataSource = dscoso.Tables[0].Copy();
                cbChdencoso.DisplayMember = "ten";
                cbChdencoso.ValueMember = "id";
            }
            catch { }

        }
        private void f_load_chinhanh()
        {
            try
            {
                if (bCncenter)
                    sql = " select id,ten,ip,trungtam,database from " + user + ".dmchinhanh" + sdbclient + " where trim(coalesce(ip,''))<>'' and trim(coalesce(database,''))<>'' order by ten";
                else
                    sql = " select id,ten,ip,trungtam,database from " + user + ".dmchinhanh" + sdbclient + " where  trim(coalesce(ip,''))<>'' and trim(coalesce(database,''))<>'' and id=" + ichinhanh + " order by ten";
                dscbchinhanh = m_v.get_data(sql);
                cbchinhanh.DisplayMember = "TEN";
                cbchinhanh.ValueMember = "ID";
                cbchinhanh.DataSource = dscbchinhanh.Tables[0];
            }
            catch
            {

            }
        }
        private void f_Load_File_Phongthuchiencls()
        {
            try
            {
                dsphthuchien = m_v.get_data(" select id,ten from " + user + ".dmphongthuchiencls" + sdbclient + " order by id ");
                chklistPhthuchiencls.DataSource = dsphthuchien.Tables[0];
                chklistPhthuchiencls.DisplayMember = "ten";
                chklistPhthuchiencls.ValueMember = "id";
            }
            catch { }
        }
        private void f_Load_File_Phongthuchiencls(int i_loaivp)
        {
            //DataSet dsphthuchien = new DataSet();
            try
            {
                dsphthuchien = m_v.get_data(" select id,ten from " + user + ".dmphongthuchiencls" + sdbclient + " where id_loaivp like '%" +
                    i_loaivp + "%' order by ten");
                chklistPhthuchiencls.DataSource = dsphthuchien.Tables[0];
                chklistPhthuchiencls.DisplayMember = "ten";
                chklistPhthuchiencls.ValueMember = "id";
            }
            catch { }
        }
        private void f_Load_DG()
        {
            //linh bỏ
            //if (dscbchinhanh.Tables[0].Rows.Count > 0)
            //{
            //if (bCncenter)
            //{
            try
            {
                if (sdbclient != "")
                {
                    sdbclient = "@" + sdbclient.Trim('@');
                }//s_query_vp xài chung cho ham f_load_dg1
                s_query_vp = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,gia_ksk,a.vattu_th,";
                s_query_vp += "a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,";
                s_query_vp += "b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt, c.ten as ten_loaibn,a.id_mauthu,a.kqtaicho,";
                s_query_vp += "case when a.theobs is null then 0 else a.theobs end as theobs, case when a.trongoi is null then 0 else a.trongoi end as trongoi,";
                s_query_vp += "case when a.loaitrongoi is null then 0 else a.loaitrongoi end as loaitrongoi,case when a.chenhlech is null then 0 else a.chenhlech end as chenhlech,";
                s_query_vp += "case when a.thuong is null then 0 else a.thuong end as thuong,case when a.ndm is null then 0 else a.ndm end as ndm,";
                s_query_vp += "a.locthe,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,case when a.loaibn is null then 0 else a.loaibn end as loaibn,";
                s_query_vp += "case when b.id is null then -999 else b.id end as id_loai,b.id_nhom,'' as blank,tylekhuyenmai,hide,a.readonly,a.kythuat,a.giavtth,a.vat ";
                s_query_vp += ",a.kcct, a.sothe, a.bhyt_tt,a.tuyentw,a.tuyentinh,a.tuyenhuyen,a.tuyenxa,a.maloai_bc,a.dichvu,a.hoichan,a.giaycamdoan,"+
                    "substr(lpad(a.tgtrakq,10,'0'),2,7) as thoigiantrakq,substr(lpad(a.tgtrakq,10,'0'),10,1) as giongay,a.gioitinh,a.tutuoi,a.dentuoi,a.batbuocthutien,a.coso,a.cosothay,"+
                    "a.phongthuchiencls,a.xamlan,f.id_mavp_chong,a.phuthu_dv,a.phuthu_th,a.phuthu_nn,a.phuthu_cs,a.id_vatchuamau,a.thoigiantrakq,"+
                    "a.ctscannercq, ";
                s_query_vp += "a.guingoai,a.guimau,a.guinguoi,substr(lpad(a.tgtrakq,10,'0'),1,1) as loaithoigiantrakq";//end linh
                s_query_vp += ", a.chuyenchungtu ";
                s_query_vp += " from " + user + ".v_giavp" + sdbclient + " a left join " + user + ".v_loaivp" + sdbclient + " b on a.id_loai=b.id left join " +
                    user + ".v_loaibn" + sdbclient + " c on a.loaibn=c.id ";
                s_query_vp += " left join " + user + ".v_nhomvp" + sdbclient + " d on b.id_nhom=d.ma left join " +
                    user + ".v_nhombhyt" + sdbclient + " e on d.idnhombhyt=e.id ";
                s_query_vp += " left join " + user + ".v_giavp_chong" + sdbclient + " f on a.id=f.id_mavp";
                //s_query_vp += " order by a.stt,a.ten";
                AddGridTableStyle(m_v.get_data(s_query_vp + " order by a.stt,a.ten"));
                txtTim_TextChanged(null, null);
            }
            catch
            {
            }
            //}
            //else
            //{
            //    if (sdbclient != "")
            //    {
            //        string stenclient = "@" + sdbclient;
            //        s_query_vp = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,gia_ksk,a.vattu_th,";
            //        s_query_vp += "a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,";
            //        s_query_vp += "b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt, c.ten as ten_loaibn,a.id_mauthu,a.kqtaicho,";
            //        s_query_vp += "case when a.theobs is null then 0 else a.theobs end as theobs, case when a.trongoi is null then 0 else a.trongoi end as trongoi,";
            //        s_query_vp += "case when a.loaitrongoi is null then 0 else a.loaitrongoi end as loaitrongoi,case when a.chenhlech is null then 0 else a.chenhlech end as chenhlech,";
            //        s_query_vp += "case when a.thuong is null then 0 else a.thuong end as thuong,case when a.ndm is null then 0 else a.ndm end as ndm,";
            //        s_query_vp += "a.locthe,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,case when a.loaibn is null then 0 else a.loaibn end as loaibn,";
            //        s_query_vp += "case when b.id is null then -999 else b.id end as id_loai,b.id_nhom,'' as blank,tylekhuyenmai,hide,a.readonly,a.kythuat,a.giavtth,a.vat ";
            //        s_query_vp += ",a.kcct, a.sothe, a.bhyt_tt,a.tuyentw,a.tuyentinh,a.tuyenhuyen,a.tuyenxa,a.maloai_bc,a.dichvu,a.hoichan,a.giaycamdoan,substr(a.tgtrakq,1,2) thoigiantrakq,substr(a.tgtrakq,3,1) giongay,a.gioitinh,a.tutuoi,a.dentuoi,a.batbuocthutien,a.coso,a.cosothay,a.phongthuchiencls,a.xamlan,f.id_mavp_chong,a.phuthu_dv,a.phuthu_th,a.phuthu_nn,a.phuthu_cs,a.id_vatchuamau,a.thoigiantrakq,a.ctscannercq ";
            //        s_query_vp += " from " + user + ".v_giavp" + stenclient + " a left join " + user + ".v_loaivp" + stenclient + " b on a.id_loai=b.id left join " + user + ".v_loaibn" + stenclient + " c on a.loaibn=c.id ";
            //        s_query_vp += " left join " + user + ".v_nhomvp" + stenclient + " d on b.id_nhom=d.ma left join " + user + ".v_nhombhyt" + stenclient + " e on d.idnhombhyt=e.id ";
            //        s_query_vp += " left join " + user + ".v_giavp_chong" + stenclient + " f on a.id=f.id_mavp";
            //        s_query_vp += " order by a.stt,a.ten";
            //        AddGridTableStyle(m_v.get_data(s_query_vp));
            //        txtTim_TextChanged(null, null);
            //    }
            //    else
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText(" Tên Database của cơ sở này chưa có, đề nghị hãy kiểm tra lại."), "Vienphi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }
            //}
            //}
            //else
            //{
            //    try
            //    {
            //        s_query_vp = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,gia_ksk,a.vattu_th,";
            //        s_query_vp += "a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,";
            //        s_query_vp += "b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt, c.ten as ten_loaibn,a.id_mauthu,a.kqtaicho,";
            //        s_query_vp += "case when a.theobs is null then 0 else a.theobs end as theobs, case when a.trongoi is null then 0 else a.trongoi end as trongoi,";
            //        s_query_vp += "case when a.loaitrongoi is null then 0 else a.loaitrongoi end as loaitrongoi,case when a.chenhlech is null then 0 else a.chenhlech end as chenhlech,";
            //        s_query_vp += "case when a.thuong is null then 0 else a.thuong end as thuong,case when a.ndm is null then 0 else a.ndm end as ndm,";
            //        s_query_vp += "a.locthe,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,case when a.loaibn is null then 0 else a.loaibn end as loaibn,";
            //        s_query_vp += "case when b.id is null then -999 else b.id end as id_loai,b.id_nhom,'' as blank,tylekhuyenmai,hide,a.readonly,a.kythuat,a.giavtth,a.vat ";
            //        s_query_vp += ",a.kcct, a.sothe, a.bhyt_tt,a.tuyentw,a.tuyentinh,a.tuyenhuyen,a.tuyenxa,a.maloai_bc,a.dichvu,a.hoichan,a.giaycamdoan,substr(a.tgtrakq,1,2) thoigiantrakq,substr(a.tgtrakq,3,1) giongay,a.gioitinh,a.tutuoi,a.dentuoi,a.batbuocthutien,a.coso,a.cosothay,a.phongthuchiencls,a.xamlan,f.id_mavp_chong,a.phuthu_dv,a.phuthu_th,a.phuthu_nn,a.phuthu_cs,a.id_vatchuamau,a.thoigiantrakq,a.ctscannercq ";
            //        s_query_vp += " from " + user + ".v_giavp a left join " + user + ".v_loaivp b on a.id_loai=b.id left join " + user + ".v_loaibn c on a.loaibn=c.id ";
            //        s_query_vp += " left join " + user + ".v_nhomvp d on b.id_nhom=d.ma left join " + user + ".v_nhombhyt e on d.idnhombhyt=e.id ";
            //        s_query_vp += " left join " + user + ".v_giavp_chong f on a.id=f.id_mavp";
            //        s_query_vp += " order by a.stt,a.ten";
            //        AddGridTableStyle(m_v.get_data(s_query_vp));
            //        txtTim_TextChanged(null, null);
            //    }
            //    catch
            //    {
            //    }
            //}
        }

        public Color MyGetColorRowCol(int row, int col)
        {
            return (this.DtgGiavp[row, 30].ToString().Trim() == "1") ? Color.Red : (this.DtgGiavp[row, 31].ToString().Trim() == "1") ? Color.Blue : Color.Black;
        }
        private void AddGridTableStyle(DataSet v_ds)
        {
            try
            {
                if (DtgGiavp.TableStyles.Count <= 0)
                {
                    DtgGiavp.TableStyles.Clear();
                    DtgGiavp.AllowSorting = true;

                    DataGridColoredTextBoxColumn TextCol;
                    delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
                    DataGridTableStyle ts = new DataGridTableStyle();
                    ts.MappingName = v_ds.Tables[0].TableName;
                    ts.AlternatingBackColor = Color.LightYellow;
                    ts.BackColor = Color.White;
                    ts.ForeColor = Color.MidnightBlue;
                    ts.GridLineColor = Color.RoyalBlue;
                    ts.HeaderBackColor = SystemColors.Control;
                    ts.HeaderForeColor = Color.Black;
                    ts.SelectionBackColor = Color.Teal;
                    ts.SelectionForeColor = Color.PaleGreen;

                    ts.RowHeaderWidth = 16;
                    ts.AllowSorting = true;
                    ts.PreferredRowHeight = 20;

                    //0
                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "id";
                    TextCol.HeaderText = "ID";
                    TextCol.Width = 43;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //1
                    TextCol = new DataGridColoredTextBoxColumn(de, 1);
                    TextCol.MappingName = "stt";
                    TextCol.HeaderText = "Stt";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 40;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //2
                    TextCol = new DataGridColoredTextBoxColumn(de, 2);
                    TextCol.MappingName = "ma";
                    TextCol.HeaderText = "Mã số";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 60;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //3
                    TextCol = new DataGridColoredTextBoxColumn(de, 3);
                    TextCol.MappingName = "ten";
                    TextCol.HeaderText = "Nội dung";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 180;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //4
                    TextCol = new DataGridColoredTextBoxColumn(de, 4);
                    TextCol.MappingName = "dvt";
                    TextCol.HeaderText = "ĐVT";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 49;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //5
                    TextCol = new DataGridColoredTextBoxColumn(de, 5);
                    TextCol.MappingName = "gia_th";
                    TextCol.HeaderText = "Đơn giá"; //"Giá DV";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 84;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //6
                    TextCol = new DataGridColoredTextBoxColumn(de, 6);
                    TextCol.MappingName = "gia_bh";
                    TextCol.HeaderText = "Giá BHYT";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //7
                    TextCol = new DataGridColoredTextBoxColumn(de, 7);
                    TextCol.MappingName = "gia_dv";
                    TextCol.HeaderText = "Giá DV";// "Giá ngoài giờ";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //8
                    TextCol = new DataGridColoredTextBoxColumn(de, 8);
                    TextCol.MappingName = "gia_nn";
                    TextCol.HeaderText = "Giá NN";// "Giá ngày nghỉ";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //9
                    TextCol = new DataGridColoredTextBoxColumn(de, 9);
                    TextCol.MappingName = "gia_cs";
                    TextCol.HeaderText = "Giá CS";// "Giá ngày lễ";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //10
                    TextCol = new DataGridColoredTextBoxColumn(de, 10);
                    TextCol.MappingName = "gia_ksk";
                    TextCol.HeaderText = "Giá KSK";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //11                 
                    TextCol = new DataGridColoredTextBoxColumn(de, 11);
                    TextCol.MappingName = "vattu_th";
                    TextCol.HeaderText = "Vật tư";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //12
                    TextCol = new DataGridColoredTextBoxColumn(de, 12);
                    TextCol.MappingName = "vattu_bh";
                    TextCol.HeaderText = "Vật tư BHYT";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //13
                    TextCol = new DataGridColoredTextBoxColumn(de, 13);
                    TextCol.MappingName = "vattu_dv";
                    TextCol.HeaderText = "Vật tư DV";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 80;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //14
                    TextCol = new DataGridColoredTextBoxColumn(de, 14);
                    TextCol.MappingName = "vattu_nn";
                    TextCol.HeaderText = "Vật tư NN";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 100;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //15
                    TextCol = new DataGridColoredTextBoxColumn(de, 15);
                    TextCol.MappingName = "vattu_cs";
                    TextCol.HeaderText = "Vật tư CS";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 100;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //16
                    TextCol = new DataGridColoredTextBoxColumn(de, 16);
                    TextCol.MappingName = "vattu_ksk";
                    TextCol.HeaderText = "Vật tư KSK";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 100;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //17
                    TextCol = new DataGridColoredTextBoxColumn(de, 17);
                    TextCol.MappingName = "bhyt";
                    TextCol.HeaderText = "BHYT Trả";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 72;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //18
                    TextCol = new DataGridColoredTextBoxColumn(de, 18);
                    TextCol.MappingName = "ten_loaivp";
                    TextCol.HeaderText = "Loại viện phí";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 94;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //19
                    TextCol = new DataGridColoredTextBoxColumn(de, 19);
                    TextCol.MappingName = "ten_nhomvp";
                    TextCol.HeaderText = "Nhóm viện phí";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 102;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //20
                    TextCol = new DataGridColoredTextBoxColumn(de, 20);
                    TextCol.MappingName = "ten_nhombhyt";
                    TextCol.HeaderText = "Nhóm VP BHYT";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 102;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //21
                    TextCol = new DataGridColoredTextBoxColumn(de, 21);
                    TextCol.MappingName = "ten_loaibn";
                    TextCol.HeaderText = "Loại bệnh nhân";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 100;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //22
                    TextCol = new DataGridColoredTextBoxColumn(de, 22);
                    TextCol.MappingName = "theobs";
                    TextCol.HeaderText = "Thu theo Bác sĩ";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 100;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //23
                    TextCol = new DataGridColoredTextBoxColumn(de, 23);
                    TextCol.MappingName = "trongoi";
                    TextCol.HeaderText = "Trọn gói";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 60;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //24
                    TextCol = new DataGridColoredTextBoxColumn(de, 24);
                    TextCol.MappingName = "loaitrongoi";
                    TextCol.HeaderText = "Loại trọn gói";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 90;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //25
                    TextCol = new DataGridColoredTextBoxColumn(de, 25);
                    TextCol.MappingName = "chenhlech";
                    TextCol.HeaderText = "Tính chênh lệch BHYT";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 120;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //26
                    TextCol = new DataGridColoredTextBoxColumn(de, 26);
                    TextCol.MappingName = "thuong";
                    TextCol.HeaderText = "In hoá đơn thường";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 100;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //27
                    TextCol = new DataGridColoredTextBoxColumn(de, 27);
                    TextCol.MappingName = "ndm";
                    TextCol.HeaderText = "Miễn ngoài danh mục";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 120;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //28
                    TextCol = new DataGridColoredTextBoxColumn(de, 28);
                    TextCol.MappingName = "locthe";
                    TextCol.HeaderText = "Lọc thẻ";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 100;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //29                    
                    TextCol = new DataGridColoredTextBoxColumn(de, 29);
                    TextCol.MappingName = "tylekhuyenmai";
                    TextCol.HeaderText = "Tỷ lệ khuyến mãi";
                    TextCol.Width = 100;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //30
                    TextCol = new DataGridColoredTextBoxColumn(de, 30);
                    TextCol.MappingName = "hide";
                    TextCol.HeaderText = "Không dùng";
                    TextCol.Width = 80;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //31
                    TextCol = new DataGridColoredTextBoxColumn(de, 31);
                    TextCol.MappingName = "readonly";
                    TextCol.HeaderText = "Read only";
                    TextCol.Width = 80;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //32
                    TextCol = new DataGridColoredTextBoxColumn(de, 32);
                    TextCol.MappingName = "ngayud";
                    TextCol.HeaderText = "Ngày cập nhật";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 102;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //33
                    TextCol = new DataGridColoredTextBoxColumn(de, 33);
                    TextCol.MappingName = "id_loai";
                    TextCol.HeaderText = "id_loai";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 0;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //34
                    TextCol = new DataGridColoredTextBoxColumn(de, 34);
                    TextCol.MappingName = "id_nhom";
                    TextCol.HeaderText = "id_nhom";
                    TextCol.Width = 0;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //35
                    TextCol = new DataGridColoredTextBoxColumn(de, 35);
                    TextCol.MappingName = "loaibn";
                    TextCol.HeaderText = "loaibn";
                    TextCol.Width = 0;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //36
                    TextCol = new DataGridColoredTextBoxColumn(de, 36);
                    TextCol.MappingName = "blank";
                    TextCol.HeaderText = "";
                    TextCol.Width = 0;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //37
                    TextCol = new DataGridColoredTextBoxColumn(de, 37);
                    TextCol.MappingName = "kythuat";
                    TextCol.HeaderText = "Kỹ thuật cao";
                    TextCol.Width = 60;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //38
                    TextCol = new DataGridColoredTextBoxColumn(de, 38);
                    TextCol.MappingName = "giavtth";
                    TextCol.HeaderText = "ĐM VTTH";
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 100;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,###";
                    TextCol.ReadOnly = true;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //39
                    TextCol = new DataGridColoredTextBoxColumn(de, 39);
                    TextCol.MappingName = "vat";
                    TextCol.HeaderText = "Tr đó VAT";
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 50;
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //40
                    TextCol = new DataGridColoredTextBoxColumn(de, 37);
                    TextCol.MappingName = "dichvu";
                    TextCol.HeaderText = "Dịch vụ";
                    TextCol.Width = 0;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                    //41
                    TextCol = new DataGridColoredTextBoxColumn(de, 15);
                    TextCol.MappingName = "thoigiantrakq";
                    TextCol.HeaderText = "Thời gian tra kết quả";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 100;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DtgGiavp.TableStyles.Add(ts);
                }
                DtgGiavp.DataSource = v_ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region Datagrid Colored Collum
        public Color MyGetColorRowCol11(int row, int col)
        {
            Color c = Color.Navy;
            switch (col.ToString())
            {
                case "0":
                    c = Color.Navy;
                    break;
                case "1":
                    c = Color.DimGray;
                    break;
                case "30":
                    c = Color.Red;
                    break;
                default:
                    c = Color.Navy;
                    break;
            }
            return c;
        }


        public delegate Color delegateGetColorRowCol(int row, int col);
        public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
        {
            private delegateGetColorRowCol _getColorRowCol;
            private int _column;
            public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
            {
                _getColorRowCol = getcolorRowCol;
                _column = column;
            }
            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
            {
                try
                {
                    foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
                    //backBrush = new SolidBrush(Color.GhostWhite);
                }
                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }

        #endregion

        private void f_Load_DG1(string v_id)
        {
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            try
            {
                if (m_id != "")
                {
                    //linh
                    //sql = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,gia_ksk,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,"+
                    //    "vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt, "+
                    //    "c.ten as ten_loaibn,a.id_mauthu,a.kqtaicho,case when a.theobs is null then 0 else a.theobs end as theobs, "+
                    //    "case when a.trongoi is null then 0 else a.trongoi end as trongoi, case when a.loaitrongoi is null then 0 else a.loaitrongoi end as loaitrongoi,"+
                    //    "case when a.chenhlech is null then 0 else a.chenhlech end as chenhlech,case when a.thuong is null then 0 else a.thuong end as thuong,"+
                    //    "case when a.ndm is null then 0 else a.ndm end as ndm,a.locthe,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,"+
                    //    "case when a.loaibn is null then 0 else a.loaibn end as loaibn,case when b.id is null then -999 else b.id end as id_loai,b.id_nhom,"+
                    //    "'' as blank,tylekhuyenmai,hide,a.readonly,a.kythuat,a.giavtth,a.vat,a.kcct, a.sothe, a.bhyt_tt,a.tuyentw,a.tuyentinh,a.tuyenhuyen,"+
                    //    "a.tuyenxa,a.maloai_bc,a.dichvu,a.hoichan,a.giaycamdoan,substr(a.tgtrakq,1,2) thoigiantrakq,substr(a.tgtrakq,3,1) giongay,a.gioitinh,"+
                    //    "a.tutuoi,a.dentuoi,a.batbuocthutien,a.coso,a.cosothay,a.phongthuchiencls,a.xamlan,f.id_mavp_chong,a.phuthu_dv,a.phuthu_th,"+
                    //    "a.phuthu_nn,a.phuthu_cs,a.id_vatchuamau,a.thoigiantrakq,a.ctscannercq, ";
                    //sql += "a.guingoai,a.guimau,a.guinguoi";
                    //sql += " from medibv.v_giavp" + sdbclient + " a left join medibv.v_loaivp" + sdbclient + " b on a.id_loai=b.id " +
                    //    "left join medibv.v_loaibn" + sdbclient + " c on a.loaibn=c.id left join medibv.v_nhomvp" + sdbclient + " d on b.id_nhom=d.ma " +
                    //    "left join medibv.v_nhombhyt" + sdbclient + " e on d.idnhombhyt=e.id left join medibv.v_giavp_chong" + sdbclient + " f on a.id=f.id_mavp " +
                    string s_sql = s_query_vp + " where a.id=" + m_id + " order by a.stt,a.ten";
                    CurrencyManager cm = (CurrencyManager)(BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    foreach (DataRow r in m_v.get_data(s_sql).Tables[0].Rows)
                    {
                        if (dv.Table.Select("id=" + r["id"].ToString()).Length > 0)
                        {
                            DataRow r1 = dv.Table.Select("id=" + r["id"].ToString())[0];
                            for (int j = 0; j < dv.Table.Columns.Count; j++)
                            {
                                r1[j] = r[j];
                            }
                        }
                        else
                        {
                            dv.Table.Rows.Add(r.ItemArray);
                        }
                    }
                    txtTim_TextChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void f_Load_Tree()
        {
            try
            {
                treeView1.Nodes.Clear();
                TreeNode anode, anode1;
                DataSet adsloai, adsnhom;
                string asort = "ten";
                if (toolStripMenuItem2.Checked)
                {
                    asort = "stt";
                }
                anode = new TreeNode(lan.Change_language_MessageText("Tất cả"));
                anode.Tag = "?:?";
                //anode.ImageIndex = 2;
                //anode.SelectedImageIndex = 2;
                treeView1.Nodes.Add(anode);

                adsnhom = m_v.f_get_v_nhomvp_frmgiavp();
                adsloai = m_v.f_get_v_loaivp_frmgiavp();
                foreach (DataRow r in adsnhom.Tables[0].Select("", asort))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["ma"].ToString() + ":?";
                    //anode.ImageIndex = 0;
                    //anode.SelectedImageIndex = 0;
                    treeView1.Nodes.Add(anode);
                    foreach (DataRow r1 in adsloai.Tables[0].Select("id_nhom=" + r["ma"].ToString(), asort))
                    {
                        anode1 = new TreeNode(r1["ten"].ToString());
                        anode1.Tag = r["ma"].ToString() + ":" + r1["id"].ToString();
                        //anode1.ImageIndex = 1;
                        //anode1.SelectedImageIndex = 1;
                        anode.Nodes.Add(anode1);
                    }
                }

                if (adsnhom.Tables[0].Select("ma=-1").Length < 0)
                {
                    DataRow ar = adsnhom.Tables[0].NewRow();
                    ar["ma"] = -1;
                    ar["ten"] = "...";
                    ar["idnhombhyt"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar, adsnhom.Tables[0].Rows.Count);
                }
                if (adsloai.Tables[0].Select("id=-1").Length < 0)
                {
                    DataRow ar1 = adsnhom.Tables[0].NewRow();
                    ar1["id"] = -1;
                    ar1["ten"] = "...";
                    ar1["id_nhom"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar1, adsloai.Tables[0].Rows.Count);
                }
                cbNhombhyt.DisplayMember = "TEN";
                cbNhombhyt.ValueMember = "ID";
                cbNhombhyt.DataSource = m_v.f_get_v_nhombhyt_frmgiavp().Tables[0];

                cbNhomvp.DisplayMember = "TEN";
                cbNhomvp.ValueMember = "MA";
                cbNhomvp.DataSource = adsnhom.Tables[0];

                cbLoaivp.DisplayMember = "TEN";
                cbLoaivp.ValueMember = "ID";
                cbLoaivp.DataSource = adsloai.Tables[0];

                cbLoaibn.DisplayMember = "TEN";
                cbLoaibn.ValueMember = "ID";
                cbLoaibn.DataSource = m_v.f_get_v_loaibn_frmgiavp().Tables[0];
            }
            catch
            {
            }
        }
        private void f_Load_Kythuatcao()
        {
            try
            {
                DataSet adsKTC = new DataSet();
                adsKTC.Tables.Add("Table");
                adsKTC.Tables[0].Columns.Add("id");
                adsKTC.Tables[0].Columns.Add("ten");
                adsKTC.Tables[0].Rows.Add(new string[] { "-1", " " });
                adsKTC.Tables[0].Rows.Add(new string[] { "0", lan.Change_language_MessageText("Dịch vụ kỹ thuật cao, chi phí lớn") });
                adsKTC.Tables[0].Rows.Add(new string[] { "1", lan.Change_language_MessageText("Chăm sóc thai sản, sinh đẻ") });
                adsKTC.Tables[0].Rows.Add(new string[] { "2", lan.Change_language_MessageText("Thuốc chống thải ghép, ngoài danh mục") });

                cbKythuatcao.DisplayMember = "TEN";
                cbKythuatcao.ValueMember = "ID";
                cbKythuatcao.DataSource = adsKTC.Tables[0];
                try
                {
                    cbKythuatcao.SelectedValue = "-1";
                }
                catch
                {

                }

            }
            catch
            {

            }
        }
        private void f_Filter()
        {
            try
            {
                string aft = "";
                if (txtTim.Text != "")
                {
                    aft = "(ma like '%" + txtTim.Text.Replace("'", "''") + "%' or ten like '%" + txtTim.Text.Replace("'", "''") + "%' or dvt like '%" + txtTim.Text.Replace("'", "''") + "%')";
                }
                try
                {
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "-1")
                    {
                        if (aft != "")
                        {
                            aft += " and ";
                        }
                        aft += " id_nhom=" + treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                        cbNhomvp.SelectedValue = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                        cbNhomvp_SelectedIndexChanged(null, null);
                    }
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                    {
                        if (aft != "")
                        {
                            aft += " and ";
                        }
                        aft += " id_loai=" + treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                        cbLoaivp.SelectedValue = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    }
                }
                catch
                {
                }

                //CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                CurrencyManager cm = (CurrencyManager)(BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                lbTitle.Text = lan.Change_language_MessageText("Giá viện phí") + " (" + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                lbTitle.Text = lan.Change_language_MessageText("Giá viện phí");
            }
        }
        private void f_Moi()
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_them(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền thêm!"));
                return;
            }
            try
            {
                txtID.Text = "";//m_v.get_id_v_giavp.ToString();
                txtSTT.Text = m_v.get_stt_v_giavp.ToString();
                chkReadonly.Checked = false;
                chkNDM.Checked = false;
                chkTheobs.Checked = false;
                chkThuong.Checked = false;
                chkTrongoi.Checked = false;
                chkLoaitrongoi.Checked = false;
                chkKhongdung.Checked = false;
                chkChenhlech.Checked = false;
                chkkhongcungchitra.Checked = false;
                chkchuyenchungtu.Checked = false;

                vat.Text = giavtth.Text = txtMa.Text = "";
                txtBHYT.Text = "";
                txtTen.Text = "";
                txtDVT.Text = "";
                txtGia_th.Text = "";
                txtGia_bh.Text = "";
                txtGia_dv.Text = "";
                txtGia_nn.Text = "";
                txtGia_cs.Text = "";
                txtGia_KSK.Text = "";
                txtVattu_th.Text = "";
                txtVattu_bh.Text = "";
                txtVattu_dv.Text = "";
                txtVattu_nn.Text = "";
                txtVattu_cs.Text = "";
                txtVattu_KSK.Text = "";
                cbLoaibn.SelectedIndex = 0;
                txtsothe.Text = "";
                bhyttraituyen.Text = "";

                txtPtthuphi.Text = "";
                txtPtdichvu.Text = "";
                txtPtnuocngoai.Text = "";
                txtPtcs.Text = "";

                txtGia_nn.Text = "";
                txtGia_cs.Text = "";
                txtGia_KSK.Text = "";
                m_id = "";
                if (cbNhomvp.SelectedIndex < 0)
                {
                    try
                    {
                        if (treeView1.SelectedNode.Tag.ToString() != "-1:-1" && treeView1.SelectedNode.Tag.ToString() != "-999:-999")
                        {
                            cbNhomvp.SelectedValue = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                        }
                        else
                        {
                            cbNhomvp.SelectedIndex = 0;
                        }
                    }
                    catch
                    {
                    }
                }
                if (cbLoaivp.SelectedIndex < 0)
                {
                    try
                    {
                        if (treeView1.SelectedNode.Tag.ToString() != "-1:-1" && treeView1.SelectedNode.Tag.ToString() != "-999:-999")
                        {
                            cbLoaivp.SelectedValue = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                        }
                        else
                        {
                            cbLoaivp.SelectedIndex = 0;
                        }
                    }
                    catch
                    {
                    }
                }
                f_Enable(true);
                chkTrongoi_CheckedChanged(null, null);
                chkLoaitrongoi_CheckedChanged(null, null);
                txtSTT.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string f_get_id_nhombhyt(string v_id_nhom)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNhomvp.DataSource]);
                DataView dv = (DataView)(cm.List);
                return dv.Table.Select("ma=" + cbNhomvp.SelectedValue.ToString())[0]["idnhombhyt"].ToString();
            }
            catch
            {
                return "";
            }
        }
        private string f_get_ma_nhomvp(string v_id_loai)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbLoaivp.DataSource]);
                DataView dv = (DataView)(cm.List);
                return dv.Table.Select("id=" + cbLoaivp.SelectedValue.ToString())[0]["id_nhom"].ToString();
            }
            catch
            {
                return "";
            }
        }
        private void f_Load_Sua()
        {
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
                dv.AllowDelete = false;
                dv.AllowEdit = false;
                DataRow[] rs = dv.Table.Select("id=" + DtgGiavp[DtgGiavp.CurrentRowIndex, 0].ToString().Trim() + "");
                sql = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.bhyt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.vattu_th,a.vattu_bh,a.vattu_dv," +
                    "a.vattu_nn,a.vattu_cs,a.trongoi,a.loaitrongoi,a.loaibn,a.theobs,a.ndm,a.chenhlech,a.thuong,a.locthe,a.id_loai,b.id_nhom," +
                    "c.idnhombhyt,a.tylekhuyenmai,a.gia_ksk,a.vattu_ksk,a.hide,a.kythuat,a.giavtth,a.vat, a.kcct " +
                    " from medibv.v_giavp" + sdbclient + " a left join medibv.v_loaivp" + sdbclient + " b on a.id_loai=b.id left join medibv.v_nhomvp" + sdbclient + " c on b.id_nhom=c.ma where a.id=" + rs[0]["id"].ToString();
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    m_id = r["id"].ToString();
                    m_id_loai = r["id_loai"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtSTT.Text = r["stt"].ToString();
                    txtMa.Text = r["ma"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    txtDVT.Text = r["dvt"].ToString();
                    txtBHYT.Text = r["bhyt"].ToString();
                    txtGia_th.Text = r["gia_th"].ToString();
                    txtGia_bh.Text = r["gia_bh"].ToString();
                    txtGia_dv.Text = r["gia_dv"].ToString();
                    txtGia_nn.Text = r["gia_nn"].ToString();
                    txtGia_cs.Text = r["gia_cs"].ToString();
                    txtGia_KSK.Text = r["gia_ksk"].ToString();
                    txtVattu_th.Text = r["vattu_th"].ToString();
                    txtVattu_bh.Text = r["vattu_bh"].ToString();
                    txtVattu_dv.Text = r["vattu_dv"].ToString();
                    txtVattu_nn.Text = r["vattu_nn"].ToString();
                    txtVattu_cs.Text = r["vattu_cs"].ToString();
                    lblVattu_KSK.Text = r["vattu_ksk"].ToString();
                    txtLocthe.Text = r["locthe"].ToString();
                    txtkhuyenmai.Text = r["tylekhuyenmai"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    chkNDM.Checked = r["ndm"].ToString() == "1";
                    chkTheobs.Checked = r["theobs"].ToString() == "1";
                    chkThuong.Checked = r["thuong"].ToString() == "1";
                    chkChenhlech.Checked = r["chenhlech"].ToString() == "1";
                    chkTrongoi.Checked = r["trongoi"].ToString() == "1";
                    chkLoaitrongoi.Checked = r["loaitrongoi"].ToString() == "1";
                    chkKhongdung.Checked = r["hide"].ToString() == "1";
                    try
                    {
                        cbLoaivp.SelectedValue = r["id_loai"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbNhomvp.SelectedValue = r["id_nhom"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbNhombhyt.SelectedValue = r["idnhombhyt"].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        cbKythuatcao.SelectedValue = r["kythuat"].ToString();
                    }
                    catch
                    {
                    }
                    txtGia_th_Validated(null, null);
                    txtGia_bh_Validated(null, null);
                    txtGia_dv_Validated(null, null);
                    txtGia_nn_Validated(null, null);
                    txtGia_cs_Validated(null, null);
                    txtGia_KSK_Validated(null, null);
                    txtVattu_th_Validated(null, null);
                    txtVattu_bh_Validated(null, null);
                    txtVattu_dv_Validated(null, null);
                    txtVattu_nn_Validated(null, null);
                    txtVattu_cs_Validated(null, null);
                    txtVattu_KSK_Validated(null, null);
                    txtBHYT_Validated(null, null);
                    txtkhuyenmai_Validated(null, null);
                    decimal gia = (r["giavtth"].ToString() != "") ? decimal.Parse(r["giavtth"].ToString()) : 0;
                    giavtth.Text = gia.ToString("###,###,###,###");
                    vat.Text = r["vat"].ToString();
                    break;
                }
                chkTrongoi_CheckedChanged(null, null);
                chkLoaitrongoi_CheckedChanged(null, null);
            }
            catch
            {
            }
        }

        private void f_load_GridView()
        {
            try
            {
                string s_xungdot = "";
                chklistGioitinh.SetItemChecked(0, false);
                chklistGioitinh.SetItemChecked(1, false);
                for (int i = 0; i < chklistCosoduocthay.Items.Count; i++)
                {
                    chklistCosoduocthay.SetItemChecked(i, false);
                }
                for (int j = 0; j < chklistPhthuchiencls.Items.Count; j++)
                {
                    chklistPhthuchiencls.SetItemChecked(j, false);
                }
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DtgGiavp.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id='" + DtgGiavp[DtgGiavp.CurrentRowIndex, 0].ToString().Trim() + "'");
                    if (rs.Length > 0)
                    {
                        m_id = rs[0]["id"].ToString();
                        m_id_loai = rs[0]["id_loai"].ToString();
                        txtID.Text = rs[0]["id"].ToString();
                        txtSTT.Text = rs[0]["stt"].ToString();
                        txtMa.Text = rs[0]["ma"].ToString();
                        txtTen.Text = rs[0]["ten"].ToString();
                        txtDVT.Text = rs[0]["dvt"].ToString();
                        txtBHYT.Text = rs[0]["bhyt"].ToString();
                        txtGia_th.Text = rs[0]["gia_th"].ToString();
                        txtGia_bh.Text = rs[0]["gia_bh"].ToString();
                        txtGia_dv.Text = rs[0]["gia_dv"].ToString();
                        txtGia_nn.Text = rs[0]["gia_nn"].ToString();
                        txtGia_cs.Text = rs[0]["gia_cs"].ToString();
                        txtGia_KSK.Text = rs[0]["gia_ksk"].ToString();
                        txtVattu_th.Text = rs[0]["vattu_th"].ToString();
                        txtVattu_bh.Text = rs[0]["vattu_bh"].ToString();
                        txtVattu_dv.Text = rs[0]["vattu_dv"].ToString();
                        txtVattu_nn.Text = rs[0]["vattu_nn"].ToString();
                        txtVattu_cs.Text = rs[0]["vattu_cs"].ToString();
                        txtVattu_KSK.Text = rs[0]["vattu_ksk"].ToString();
                        txtLocthe.Text = rs[0]["locthe"].ToString();
                        txtsothe.Text = rs[0]["sothe"].ToString();
                        // gam
                        txtPtthuphi.Text = rs[0]["phuthu_th"].ToString();
                        txtPtdichvu.Text = rs[0]["phuthu_dv"].ToString();
                        txtPtnuocngoai.Text = rs[0]["phuthu_nn"].ToString();
                        txtPtcs.Text = rs[0]["phuthu_cs"].ToString();
                        // end gam
                        txtkhuyenmai.Text = rs[0]["tylekhuyenmai"].ToString();
                        chkReadonly.Checked = rs[0]["readonly"].ToString() == "1";
                        chkNDM.Checked = rs[0]["ndm"].ToString() == "1";
                        chkTheobs.Checked = rs[0]["theobs"].ToString() == "1";
                        chkThuong.Checked = rs[0]["thuong"].ToString() == "1";
                        chkChenhlech.Checked = rs[0]["chenhlech"].ToString() == "1";
                        chkTrongoi.Checked = rs[0]["trongoi"].ToString() == "1";
                        chkLoaitrongoi.Checked = rs[0]["loaitrongoi"].ToString() == "1";
                        chkKhongdung.Checked = rs[0]["hide"].ToString() == "1";
                        chkkhongcungchitra.Checked = rs[0]["kcct"].ToString() == "1";
                        chkTuyentw.Checked = rs[0]["tuyentw"].ToString() == "1";
                        chkTuyentinh.Checked = rs[0]["tuyentinh"].ToString() == "1";
                        chkTuyenhuyen.Checked = rs[0]["tuyenhuyen"].ToString() == "1";
                        chkTuyenxa.Checked = rs[0]["tuyenxa"].ToString() == "1";
                        chkDichvu.Checked = rs[0]["dichvu"].ToString() == "1";
                        //linh
                        chkGuiNguoi.Checked = rs[0]["guinguoi"].ToString() == "1";
                        chkGuimau.Checked = rs[0]["guimau"].ToString() == "1";
                        chkGuingoai.Checked = rs[0]["guingoai"].ToString() == "1";
                        ///Dong them
                        try
                        {
                            double tg=double.Parse(rs[0]["thoigiantrakq"].ToString().Trim('-'));
                            if (tg == 0)
                            {
                                txtThoigiantrakq.Text = "";
                                cboLoaithoigiantrakq.SelectedIndex = 0;
                                //cbThoigiankq.SelectedIndex = 0;
                                cbThoigiankq.SelectedIndex = -1;
                            }
                            else
                            {
                                txtThoigiantrakq.Text = tg.ToString();
                                string s_giongay = rs[0]["giongay"].ToString().Trim('-');
                                if (s_giongay != "")
                                {
                                    cbThoigiankq.SelectedIndex = int.Parse(s_giongay);
                                }
                                else
                                {
                                    cbThoigiankq.SelectedIndex = -1;
                                }
                                string s_loaitg = rs[0]["loaithoigiantrakq"].ToString();
                                if (s_loaitg != "")
                                {
                                    cboLoaithoigiantrakq.SelectedIndex = int.Parse(s_loaitg);
                                }
                                else
                                {
                                    cboLoaithoigiantrakq.SelectedIndex = -1;
                                }
                            }
                        }
                        catch
                        {
                            txtThoigiantrakq.Text = "";
                            cbThoigiankq.SelectedIndex = -1;
                            cboLoaithoigiantrakq.SelectedIndex = -1;
                        }
                        //end linh
                        chkHoichan.Checked = rs[0]["hoichan"].ToString() == "1";
                        chkcamdoan.Checked = rs[0]["giaycamdoan"].ToString() == "1";
                        chkCTscannercocq.Checked = rs[0]["ctscannercq"].ToString() == "1";
                        txtTuoitu.Text = rs[0]["tutuoi"].ToString();
                        txtTuoiden.Text = rs[0]["dentuoi"].ToString();
                        string s_gt = rs[0]["gioitinh"].ToString();
                        if (s_gt != "")
                        {
                            string []arr_gt=s_gt.Trim().Trim(',').Split(',');
                            for (int j = 0; j < arr_gt.Length; j++)
                            {
                                chklistGioitinh.SetItemChecked(int.Parse(arr_gt[j]), true);
                            }
                        }
                        chkBatbuocthutien.Checked = rs[0]["batbuocthutien"].ToString() == "1";
                        chkxamlan.Checked = rs[0]["xamlan"].ToString() == "1";
                        cbChdencoso.SelectedValue = rs[0]["coso"].ToString();

                        string s_cosothay = "," + rs[0]["cosothay"].ToString().Trim().Trim(',') + ",";
                        if (s_cosothay.Trim().Trim(',') != "")
                        {
                            for (int j = 0; j < dscoso.Tables[0].Rows.Count; j++)
                                if (s_cosothay.IndexOf("," + dscoso.Tables[0].Rows[j]["id"].ToString().Trim() + ",") != -1) chklistCosoduocthay.SetItemCheckState(j, CheckState.Checked);
                                else chklistCosoduocthay.SetItemCheckState(j, CheckState.Unchecked);
                        }
                        string s_phongthuchiencls = "," + rs[0]["phongthuchiencls"].ToString().Trim().Trim(',') + ",";
                        if (s_phongthuchiencls.Trim().Trim(',') != "")
                        {
                            for (int j = 0; j < dsphthuchien.Tables[0].Rows.Count; j++)
                                if (s_phongthuchiencls.IndexOf("," + dsphthuchien.Tables[0].Rows[j]["id"].ToString().Trim() + ",") != -1) chklistPhthuchiencls.SetItemCheckState(j, CheckState.Checked);
                                else chklistPhthuchiencls.SetItemCheckState(j, CheckState.Unchecked);
                        }

                        s_xungdot = rs[0]["id_mavp_chong"].ToString();
                        if (s_xungdot != "")
                            textxungdot.ForeColor = Color.Red;
                        else
                            textxungdot.ForeColor = Color.Black;
                        ///End Dong
                        try
                        {
                            cbLoaivp.SelectedValue = rs[0]["id_loai"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            cbNhomvp.SelectedValue = rs[0]["id_nhom"].ToString();
                        }
                        catch
                        {
                        }
                        // gam
                        try
                        {
                            cbVatchuamau.SelectedValue = rs[0]["id_vatchuamau"].ToString();
                        }
                        catch
                        {
                        }
                        // end gam
                        try
                        {
                            cbNhombhyt.SelectedValue = f_get_id_nhombhyt(rs[0]["id_nhom"].ToString());
                        }
                        catch
                        {
                        }
                        try
                        {
                            cbKythuatcao.SelectedValue = rs[0]["kythuat"].ToString();
                        }
                        catch
                        {
                        }
                        //maloai_bc
                        try
                        {
                            cboLoaiBC.SelectedValue = rs[0]["maloai_bc"].ToString();
                        }
                        catch
                        {
                        }
                        // hien: mau thu,ket qua tai cho

                        try
                        {
                            chkNhapkqtainoilaymau.Checked = (rs[0]["kqtaicho"].ToString() == "1");
                            cmbMauthu.SelectedValue = rs[0]["id_mauthu"].ToString();
                        }
                        catch { }

                        try
                        {
                            chkchuyenchungtu.Checked = rs[0]["chuyenchungtu"].ToString() == "1";
                        }
                        catch
                        {
                        }
                        // end hien
                        txtGia_th_Validated(null, null);
                        txtGia_bh_Validated(null, null);
                        txtGia_dv_Validated(null, null);
                        txtGia_nn_Validated(null, null);
                        txtGia_cs_Validated(null, null);
                        txtGia_KSK_Validated(null, null);
                        txtVattu_th_Validated(null, null);
                        txtVattu_bh_Validated(null, null);
                        txtVattu_dv_Validated(null, null);
                        txtVattu_nn_Validated(null, null);
                        txtVattu_cs_Validated(null, null);
                        txtVattu_KSK_Validated(null, null);
                        txtBHYT_Validated(null, null);
                        txtPtthuphi_Validated(null, null);
                        txtPtdichvu_Validated(null, null);
                        txtPtnuocngoai_Validated(null, null);
                        txtPtcs_Validated(null, null);
                        f_Enable(false);
                        chkTrongoi_CheckedChanged(null, null);
                        chkLoaitrongoi_CheckedChanged(null, null);
                        decimal gia = (rs[0]["giavtth"].ToString() != "") ? decimal.Parse(rs[0]["giavtth"].ToString()) : 0;
                        giavtth.Text = gia.ToString("###,###,###,###");
                        vat.Text = rs[0]["vat"].ToString();
                        bhyttraituyen.Text = rs[0]["bhyt_tt"].ToString();
                    }
                }
            }
            catch
            {
            }
        }

        private void f_Enable(bool v_bool)
        {
            //linh
            //if (bCncenter)
            butMoi.Enabled = !v_bool;
            //else
            //    butMoi.Enabled = false;
            butMoi.Visible = (bCncenter || cbchinhanh.Items.Count == 0);
            //end linh
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool && m_id != "";
            butXoa.Enabled = !v_bool && m_id != "";
            butChuyen.Enabled = !v_bool;
            butBoqua.Enabled = true;
            txtID.Enabled = false;
            if (bKhoan) giavtth.Enabled = v_bool;
            vat.Enabled = txtSTT.Enabled = v_bool;
            txtMa.Enabled = false;// v_bool;
            txtTen.Enabled = v_bool;
            txtDVT.Enabled = v_bool;
            txtBHYT.Enabled = v_bool;

            txtGia_th.Enabled = v_bool;
            txtGia_bh.Enabled = v_bool;
            txtGia_dv.Enabled = v_bool;
            txtGia_nn.Enabled = v_bool;
            txtGia_cs.Enabled = v_bool;
            txtGia_KSK.Enabled = v_bool;
            txtVattu_th.Enabled = v_bool;
            txtVattu_bh.Enabled = v_bool;
            txtVattu_dv.Enabled = v_bool;
            txtVattu_nn.Enabled = v_bool;
            txtVattu_cs.Enabled = v_bool;
            txtVattu_KSK.Enabled = v_bool;
            txtLocthe.Enabled = v_bool;
            txtkhuyenmai.Enabled = v_bool;
            chkChenhlech.Enabled = v_bool;
            chkNDM.Enabled = v_bool;
            chkReadonly.Enabled = v_bool;
            chkTheobs.Enabled = v_bool;
            chkThuong.Enabled = v_bool;
            chkKhongdung.Enabled = v_bool;
            chkTrongoi.Enabled = v_bool;
            chkLoaitrongoi.Enabled = v_bool;
            cbNhomvp.Enabled = v_bool;
            cbLoaivp.Enabled = v_bool;
            cbLoaibn.Enabled = v_bool;
            cbKythuatcao.Enabled = v_bool;
            chkkhongcungchitra.Enabled = v_bool;
            cbNhombhyt.Enabled = v_bool;
            txtsothe.Enabled = v_bool;
            bhyttraituyen.Enabled = v_bool;
            cboLoaiBC.Enabled = v_bool;

            chkHoichan.Enabled = v_bool;
            chkcamdoan.Enabled = v_bool;
            txtThoigiantrakq.Enabled = v_bool;
            txtTuoiden.Enabled = v_bool;
            txtTuoitu.Enabled = v_bool;
            chklistGioitinh.Enabled = v_bool;
            chkBatbuocthutien.Enabled = v_bool;
            lbKythuatxungdot.Enabled = v_bool;
            cbChdencoso.Enabled = v_bool;
            chklistPhthuchiencls.Enabled = v_bool;
            chklistCosoduocthay.Enabled = v_bool;
            chkxamlan.Enabled = v_bool;
            chkCTscannercocq.Enabled = v_bool;
            chkDichvu.Enabled = v_bool;

            chkTuyentinh.Enabled = v_bool;
            chkTuyentw.Enabled = v_bool;
            chkTuyenhuyen.Enabled = v_bool;
            chkTuyenxa.Enabled = v_bool;
            //linh
            cbThoigiankq.Enabled = v_bool;
            txtThoigiantrakq.Enabled = v_bool;
            cboLoaithoigiantrakq.Enabled = v_bool;
            //if (bCncenter)
            //    cbchinhanh.Enabled = v_bool;
            //else
            //    cbchinhanh.Enabled = false;
            chkGuingoai.Enabled = v_bool;
            chkGuiNguoi.Enabled = v_bool;
            chkGuimau.Enabled = v_bool;
            chkNhapkqtainoilaymau.Enabled = v_bool;
            //end linh
            cmbMauthu.Enabled = v_bool;
            cbVatchuamau.Enabled = v_bool;
            txtPtthuphi.Enabled = v_bool;
            txtPtdichvu.Enabled = v_bool;
            txtPtnuocngoai.Enabled = v_bool;
            txtPtcs.Enabled = v_bool;

            chkchuyenchungtu.Enabled = v_bool;
            DtgGiavp.Enabled = !v_bool;

        }
        private void f_Enable_readonly(bool v_bool)
        {
            txtID.Enabled = false;
            if (bKhoan) giavtth.Enabled = v_bool;
            vat.Enabled = txtSTT.Enabled = v_bool;
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            txtDVT.Enabled = false;

            txtBHYT.Enabled = v_bool;

            txtGia_th.Enabled = v_bool;
            txtGia_bh.Enabled = v_bool;
            txtGia_dv.Enabled = v_bool;
            txtGia_nn.Enabled = v_bool;
            txtGia_cs.Enabled = v_bool;
            txtGia_KSK.Enabled = v_bool;
            txtVattu_th.Enabled = v_bool;
            txtVattu_bh.Enabled = v_bool;
            txtVattu_dv.Enabled = v_bool;
            txtVattu_nn.Enabled = v_bool;
            txtVattu_cs.Enabled = v_bool;
            txtVattu_KSK.Enabled = v_bool;
            txtLocthe.Enabled = v_bool;
            txtkhuyenmai.Enabled = v_bool;
            chkChenhlech.Enabled = true;//v_bool;
            chkNDM.Enabled = true;//v_bool;
            chkReadonly.Enabled = v_bool;
            chkTheobs.Enabled = true;// v_bool;
            chkThuong.Enabled = true;//v_bool;
            chkKhongdung.Enabled = true;//v_bool;
            chkTrongoi.Enabled = v_bool;
            chkLoaitrongoi.Enabled = v_bool;
            cbNhomvp.Enabled = false;
            cbLoaivp.Enabled = false;
            cbLoaibn.Enabled = false;
            cbKythuatcao.Enabled = false;
            chkkhongcungchitra.Enabled = v_bool;
            cbNhombhyt.Enabled = false;
            txtsothe.Enabled = v_bool;
            bhyttraituyen.Enabled = v_bool;

            cbVatchuamau.Enabled = v_bool;
            cmbMauthu.Enabled = v_bool;
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            Cursor = Cursors.WaitCursor;
            m_v.execute_data("update medibv.v_giavp" + sdbclient + " set locthe=null where locthe=''");
            Cursor = Cursors.Default;
            this.Dispose();
        }
        private void butRefresh_Click(object sender, EventArgs e)
        {
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            Cursor = Cursors.WaitCursor;
            m_v.execute_data("update medibv.v_giavp" + sdbclient + " set locthe=null where locthe=''");
            f_Load_DG();
            f_Load_Tree();
            Cursor = Cursors.Default;
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            f_Filter();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            f_Filter();
            try
            {
                treeView1.SelectedNode.ForeColor = Color.Red;
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.ForeColor = Color.Red;
                }
                if (treeView1.SelectedNode.Parent.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Parent.ForeColor = Color.Red;
                }
            }
            catch
            {
            }
        }
        private void butSualoai_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] == "?")
                {
                    frmNewnhomvp af = new frmNewnhomvp(m_v, treeView1.SelectedNode.Tag.ToString().Split(':')[1], treeView1.SelectedNode.Tag.ToString().Split(':')[0], m_userid);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_Tree();
                }
                else
                {
                    frmNewloaivp af = new frmNewloaivp(m_v, treeView1.SelectedNode.Tag.ToString().Split(':')[1], treeView1.SelectedNode.Tag.ToString().Split(':')[0], m_userid);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_Tree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,lan.Change_language_MessageText( "Chọn nội dung cần sửa từ danh sách")+"!\nError: " + ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void butNewnhom_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewnhomvp af = new frmNewnhomvp(m_v, "", "", m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
                f_Load_Tree();
            }
            catch
            {
            }
        }
        private void butNewloai_Click(object sender, EventArgs e)
        {
            try
            {
                string aid_nhom = "";
                try
                {
                    aid_nhom = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                }
                catch
                {
                    aid_nhom = "";
                }
                frmNewloaivp af = new frmNewloaivp(m_v, "", aid_nhom, m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
                f_Load_Tree();
            }
            catch
            {
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = !toolStripMenuItem1.Checked;
            if (toolStripMenuItem1.Checked)
            {
                toolStripMenuItem2.Checked = false;
            }
            f_Load_Tree();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = !toolStripMenuItem2.Checked;
            if (toolStripMenuItem2.Checked)
            {
                toolStripMenuItem1.Checked = false;
            }
            f_Load_Tree();
        }
        private void butXoaloai_Click(object sender, EventArgs e)
        {
            try
            {
                string aid = "";
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] == "?")
                {
                    aid = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                    if (m_v.dadung_v_nhomvp(aid) != 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá nhóm viện phí này") + "!\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống khi có nhu cầu") + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá nhóm viện phí") + "?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            if (!m_v.del_v_nhomvp(aid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá nhóm viện phí này") + "!\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống khi có nhu cầu") + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                f_Load_Tree();
                            }
                        }
                }
                else
                {
                    aid = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    if (m_v.dadung_v_loaivp(aid) != 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá loại viện phí này") + "!\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống khi có nhu cầu") + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá loại viện phí") + "?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            if (!m_v.del_v_loaivp(aid))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Hệ thống không cho xoá giá viện phí này") + "!\n" + lan.Change_language_MessageText("Liên hệ với quản trị hệ thống khi có nhu cầu") + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                f_Load_Tree();
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Chọn nội dung cần sửa từ danh sách") + "!\nError: " + ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void butMedisoftcenter_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedisoftcenterupdate af = new frmMedisoftcenterupdate(m_v, m_userid, "DMXN");
                af.TopMost = true;
                af.ShowDialog();
            }
            catch
            {
            }
        }
        private void butLocal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog afo = new OpenFileDialog();
                afo.RestoreDirectory = true;
                afo.Filter = "Microsoft XML Document (*.XML)|*.xml";
                afo.Title = "Chọn file dữ liệu đã download từ Medisoft Center Update";
                afo.ShowDialog();
                if (afo.FileName != "")
                {
                    MessageBox.Show(this, "Cập nhật thành công!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeView1.SelectedNode.ForeColor = Color.Black;
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.ForeColor = Color.Black;
                }
                if (treeView1.SelectedNode.Parent.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Parent.ForeColor = Color.Black;
                }
            }
            catch
            {
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] == "?")
                {
                    cmenu_Sua.Text = lan.Change_language_MessageText("Sửa nhóm") + ": ";
                    menu_Xoaloai.Text = lan.Change_language_MessageText("Xoá nhóm") + ": ";
                }
                else
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?")
                    {
                        cmenu_Sua.Text = lan.Change_language_MessageText("Sửa loại") + ": ";
                        menu_Xoaloai.Text = lan.Change_language_MessageText("Xoá loại") + ": ";
                    }
                cmenu_Sua.Text += "[" + treeView1.SelectedNode.Text + "]";
                menu_Xoaloai.Text += "[" + treeView1.SelectedNode.Text + "]";
            }
            catch
            {
            }
        }
        private void f_In()
        {
            try
            {
                string sql = "", aexp = "";
                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "-1")
                    {
                        if (aexp != "")
                        {
                            aexp += " and ";
                        }
                        aexp += " c.ma=" + treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                    }
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                    {
                        if (aexp != "")
                        {
                            aexp += " and ";
                        }
                        aexp += " b.id=" + treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    }
                }
                if (aexp != "")
                {
                    aexp = " and " + aexp;
                }
                sql = "select a.id, a.ma, a.ten, a.dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.bhyt, a.ndm, b.id as id_loai, b.stt as stt_loai," +
                    "b.ten as ten_loai, c.ma as id_nhom, c.stt as stt_nhom, c.ten as ten_nhom,a.kythuat,a.giavtth,a.vat, a.hide, a.kcct " +
                    "from medibv.v_giavp" + sdbclient + " a left join medibv.v_loaivp" + sdbclient + " b on a.id_loai=b.id left join medibv.v_nhomvp" + sdbclient + " c on b.id_nhom=c.ma where a.hide=0 " + aexp +
                    " order by c.stt, b.stt, a.stt";
                DataSet ads = m_v.get_data(sql);
                //ads.WriteXml("..//..//Datareport//v_banggiavp.xml",XmlWriteMode.WriteSchema);
                CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crystalReportViewer1.ActiveViewIndex = -1;
                crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
                crystalReportViewer1.DisplayGroupTree = false;
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                crystalReportViewer1.Name = "crystalReportViewer1";
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
                crystalReportViewer1.TabIndex = 85;

                System.Windows.Forms.Form af = new System.Windows.Forms.Form();
                af.WindowState = FormWindowState.Maximized;
                af.Controls.Add(crystalReportViewer1);
                af.Text = lan.Change_language_MessageText("Bảng giá viện phí");
                crystalReportViewer1.BringToFront();
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                areport = "v_2007_giavp.rpt";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;
                angayin = lan.Change_language_MessageText("Ngày")+" " + DateTime.Now.Day.ToString().PadLeft(2, '0') +
                    " "+lan.Change_language_MessageText("tháng")+" " + DateTime.Now.Month.ToString().PadLeft(2, '0') + 
                    " "+lan.Change_language_MessageText("năm")+" " + DateTime.Now.Year.ToString();
                anguoiin = "";
                aghichu = "";

                ReportDocument cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = lan.Change_language_MessageText("Giá viện phí") + " (" + areport + ")";
                af.ShowDialog();
            }
            catch
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Lỗi máy in"), lan.Change_language_MessageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void butIn_Click(object sender, EventArgs e)
        {
            f_In();
        }
        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            //string sdatabase = "@" + sdbclient.Replace("@", "");
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_xoa(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền xóa!"));
                return;
            }
            try
            {
                m_v.databaselinks_name = sdbclient;//linh
                if (m_v.dadung_v_giavp(m_id) != 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Tên viện phí này đã dùng không thể xoá") + "!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá giá viện phí")+"?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (m_id != "0")
                        {
                            m_v.upd_eve_tables(itable, int.Parse(m_userid), "del");
                            m_v.upd_eve_upd_del(itable, int.Parse(m_userid), "del", m_v.fields(m_v.user + ".v_giavp", "id=" + m_id));
                        }
                        //if (bCncenter)
                        //{
                            if (!m_v.del_v_giavp(m_id))
                            {
                                MessageBox.Show(this, lan.Change_language_MessageText("Tên viện phí này đã dùng không thể xoá")+"!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                f_Load_DG();
                                butBoqua_Click(null, null);
                            }
                        //}
                        //else
                        //{
                        //    if (!m_v.del_v_giavp_client(m_id, sdatabase))
                        //    {
                        //        MessageBox.Show(this, "Tên viện phí này đã dùng không thể xoá!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //    else
                        //    {
                        //        f_Load_DG();
                        //        butBoqua_Click(null, null);
                        //    }
                        //}
                    }
                m_v.databaselinks_name = "";//linh
            }
            catch
            {
            }
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_sua(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền sửa!"));
                return;
            }
            f_Enable(true);
            if (chkReadonly.Checked) f_Enable_readonly(true);
            txtSTT.Focus();
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            try
            {
                f_Load_Sua();
                f_Enable(false);
                butMoi.Focus();
            }
            catch
            {
            }
        }
        private void cbNhomvp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbLoaivp.DataSource]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = "id_nhom=" + cbNhomvp.SelectedValue.ToString();
                if (cbLoaivp.Items.Count == 2)
                {
                    cbLoaivp.SelectedIndex = 0;
                }
                else
                {

                    try
                    {
                        cbLoaivp.SelectedValue = m_id_loai;
                    }
                    catch
                    {
                    }
                }
                cbNhombhyt.SelectedValue = f_get_id_nhombhyt(cbNhombhyt.SelectedValue.ToString());
            }
            catch
            {
            }
        }
        
        private void butLuu_Click(object sender, EventArgs e)
        {
            //linh
            if (!test()) return;
            //string sdatabase = (sdbclient != "" ? "@" + sdbclient.Replace("@", "") : "");
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            m_v.databaselinks_name = sdbclient;
            //end linh
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_them(aquyenchitiet) && (m_id == "" || m_id == "0"))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền thêm mới!"));
                return;
            }
            else if (!m_v.f_quyenchitiet_sua(aquyenchitiet) && (m_id != "" && m_id != "0"))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền sửa!"));
                return;
            }
            try
            {
                string aid_loaivp = "";
                try
                {
                    aid_loaivp = cbLoaivp.SelectedValue.ToString();
                }
                catch
                {
                    aid_loaivp = "";
                }
                if (txtSTT.Text.Trim() == "")
                {
                    txtSTT.Text = m_v.f_get_stt_v_giavp(aid_loaivp).ToString();
                }
                if (txtMa.Text.Trim() == "")
                {
                    MessageBox.Show(this, "Nhập mã viện phí!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, "Nhập tên giá viện phí!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }

                if (aid_loaivp.Trim() == "" || aid_loaivp == "-1")
                {
                    MessageBox.Show(this, "Chọn loại viện phí tương ứng!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaivp.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                txtkhuyenmai.Text = (txtkhuyenmai.Text.Trim() == "") ? "0" : txtkhuyenmai.Text.Trim();
                if (m_id == "")
                {
                    m_id = "-" + m_v.get_id_v_giavp.ToString();
                }
                else
                {
                    if (m_v.dadung_v_giavp(m_id) == -1)
                    {
                        if (!m_v.is_dba_admin(m_userid))
                        {
                            MessageBox.Show(this, "Hệ thống không cho sửa nội dung này!\nLiên hệ quản trị hệ thống khi có nhu cầu!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    //linh
                    //kiem tra dmchinhanh co hay khong
                    //if (dscbchinhanh.Tables[0].Rows.Count > 0)
                    //{
                    foreach (DataRow r in m_v.get_data("select * from " + m_v.user + ".v_giavp" + sdbclient + " where id=" + m_id).Tables[0].Rows)
                    {
                        //if (bCncenter)
                        m_v.upd_v_giavp_luu(decimal.Parse(m_id), decimal.Parse(aid_loaivp), decimal.Parse(txtSTT.Text), txtMa.Text.Trim(), txtTen.Text.Trim(), txtDVT.Text, decimal.Parse(r["gia_th"].ToString()), decimal.Parse(r["gia_bh"].ToString()), decimal.Parse(r["gia_dv"].ToString()), decimal.Parse(r["gia_nn"].ToString()), decimal.Parse(r["gia_cs"].ToString()), decimal.Parse(r["vattu_th"].ToString()), decimal.Parse(r["vattu_bh"].ToString()), decimal.Parse(r["vattu_dv"].ToString()), decimal.Parse(r["vattu_nn"].ToString()), decimal.Parse(r["vattu_cs"].ToString()), decimal.Parse(r["bhyt"].ToString()), decimal.Parse(cbLoaibn.SelectedValue.ToString()), chkTheobs.Checked ? 1 : 0, chkThuong.Checked ? 1 : 0, chkTrongoi.Checked ? 1 : 0, chkLoaitrongoi.Checked ? 1 : 0, chkChenhlech.Checked ? 1 : 0, chkNDM.Checked ? 1 : 0, txtLocthe.Text.Trim(), chkReadonly.Checked ? 1 : 0, decimal.Parse(m_userid), decimal.Parse(txtkhuyenmai.Text), decimal.Parse(r["gia_ksk"].ToString()), decimal.Parse(r["vattu_ksk"].ToString()), (chkKhongdung.Checked) ? 1 : 0, decimal.Parse(cbKythuatcao.SelectedValue.ToString()));
                    }
                    //else
                    //m_v.upd_v_giavp_luu_client(decimal.Parse(m_id), decimal.Parse(aid_loaivp), decimal.Parse(txtSTT.Text), txtMa.Text.Trim(), txtTen.Text.Trim(), txtDVT.Text, decimal.Parse(r["gia_th"].ToString()), decimal.Parse(r["gia_bh"].ToString()), decimal.Parse(r["gia_dv"].ToString()), decimal.Parse(r["gia_nn"].ToString()), decimal.Parse(r["gia_cs"].ToString()), decimal.Parse(r["vattu_th"].ToString()), decimal.Parse(r["vattu_bh"].ToString()), decimal.Parse(r["vattu_dv"].ToString()), decimal.Parse(r["vattu_nn"].ToString()), decimal.Parse(r["vattu_cs"].ToString()), decimal.Parse(r["bhyt"].ToString()), decimal.Parse(cbLoaibn.SelectedValue.ToString()), chkTheobs.Checked ? 1 : 0, chkThuong.Checked ? 1 : 0, chkTrongoi.Checked ? 1 : 0, chkLoaitrongoi.Checked ? 1 : 0, chkChenhlech.Checked ? 1 : 0, chkNDM.Checked ? 1 : 0, txtLocthe.Text.Trim(), chkReadonly.Checked ? 1 : 0, decimal.Parse(m_userid), decimal.Parse(txtkhuyenmai.Text), decimal.Parse(r["gia_ksk"].ToString()), decimal.Parse(r["vattu_ksk"].ToString()), (chkKhongdung.Checked) ? 1 : 0, decimal.Parse(cbKythuatcao.SelectedValue.ToString()), sdatabase);
                    //    }
                    //}
                    //else
                    //{
                    //    foreach (DataRow r in m_v.get_data("select * from " + m_v.user + ".v_giavp" + sdbclient + " where id=" + m_id).Tables[0].Rows)
                    //    {
                    //        m_v.upd_v_giavp_luu(decimal.Parse(m_id), decimal.Parse(aid_loaivp), decimal.Parse(txtSTT.Text), txtMa.Text.Trim(), txtTen.Text.Trim(), txtDVT.Text, decimal.Parse(r["gia_th"].ToString()), decimal.Parse(r["gia_bh"].ToString()), decimal.Parse(r["gia_dv"].ToString()), decimal.Parse(r["gia_nn"].ToString()), decimal.Parse(r["gia_cs"].ToString()), decimal.Parse(r["vattu_th"].ToString()), decimal.Parse(r["vattu_bh"].ToString()), decimal.Parse(r["vattu_dv"].ToString()), decimal.Parse(r["vattu_nn"].ToString()), decimal.Parse(r["vattu_cs"].ToString()), decimal.Parse(r["bhyt"].ToString()), decimal.Parse(cbLoaibn.SelectedValue.ToString()), chkTheobs.Checked ? 1 : 0, chkThuong.Checked ? 1 : 0, chkTrongoi.Checked ? 1 : 0, chkLoaitrongoi.Checked ? 1 : 0, chkChenhlech.Checked ? 1 : 0, chkNDM.Checked ? 1 : 0, txtLocthe.Text.Trim(), chkReadonly.Checked ? 1 : 0, decimal.Parse(m_userid), decimal.Parse(txtkhuyenmai.Text), decimal.Parse(r["gia_ksk"].ToString()), decimal.Parse(r["vattu_ksk"].ToString()), (chkKhongdung.Checked) ? 1 : 0, decimal.Parse(cbKythuatcao.SelectedValue.ToString()));
                    //    }
                    //}
                    //end linh
                    m_v.upd_eve_tables(itable, int.Parse(m_userid), "upd");
                    m_v.upd_eve_upd_del(itable, int.Parse(m_userid), "upd", m_v.fields(m_v.user + ".v_giavp", "id=" + m_id));
                }
                if (m_v.f_get_v_giavp("", "", "", txtMa.Text, "", "", "").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this,lan.Change_language_MessageText( "Mã viện phí đã tồn tại, chọn mã khác")+"!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                    return;
                }
                if (m_v.f_get_v_giavp("", "","", "", txtTen.Text.Trim(), "", "").Tables[0].Select("id <> " + m_id).Length > 0)
                {
                    MessageBox.Show(this,lan.Change_language_MessageText( "Tên viện phí đã tồn tại, chọn tên khác")+"!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                string s_gt = "", s_cosothay = "", s_Phongthuchiencls = "", s_thoigiankq = "";
                for (int i = 0; i < chklistGioitinh.Items.Count; i++)
                {
                    if (chklistGioitinh.GetItemChecked(i))
                    {
                        s_gt += i + ",";
                    }
                }
                if (s_gt != "")
                    s_gt = s_gt.Substring(0, s_gt.Length - 1);
                /// coso duoc thay
                for (int i = 0; i < chklistCosoduocthay.Items.Count; i++)
                    if (chklistCosoduocthay.GetItemChecked(i))
                        s_cosothay += dscoso.Tables[0].Rows[i]["id"].ToString().Trim() + ",";
                if (s_cosothay != "")
                    s_cosothay = s_cosothay.Substring(0, s_cosothay.Length - 1);
                // Phong thuc hien cls
                s_Phongthuchiencls="";
                for (int i = 0; i < chklistPhthuchiencls.Items.Count; i++)
                {
                    if (chklistPhthuchiencls.GetItemChecked(i))
                    {
                        s_Phongthuchiencls += dsphthuchien.Tables[0].Rows[i]["id"].ToString().Trim() + ",";
                    }
                }
                //linh
                //if (s_Phongthuchiencls != "")
                //    s_Phongthuchiencls = s_Phongthuchiencls.Substring(0, s_Phongthuchiencls.Length - 1);
                s_Phongthuchiencls = s_Phongthuchiencls.Trim(',');
                //txtThoigiantrakq.Text = txtThoigiantrakq.Text.Trim().PadLeft(7, '0');
                try
                {
                    double tg = double.Parse(txtThoigiantrakq.Text);
                    if (tg == 0)
                    {
                        txtThoigiantrakq.Text = "";
                    }
                    s_thoigiankq = txtThoigiantrakq.Text.Trim() == "" ? "" : (cboLoaithoigiantrakq.SelectedIndex.ToString() + txtThoigiantrakq.Text.Trim().PadLeft(7, '0') + "-" + cbThoigiankq.SelectedIndex.ToString());
                }
                catch { s_thoigiankq = ""; }
                //end linh
                txtGia_th_Validated(null, null);
                txtGia_bh_Validated(null, null);
                txtGia_dv_Validated(null, null);
                txtGia_nn_Validated(null, null);
                txtGia_cs_Validated(null, null);
                txtGia_KSK_Validated(null, null);
                txtVattu_th_Validated(null, null);
                txtVattu_bh_Validated(null, null);
                txtVattu_dv_Validated(null, null);
                txtVattu_nn_Validated(null, null);
                txtVattu_cs_Validated(null, null);
                txtVattu_KSK_Validated(null, null);
                txtBHYT_Validated(null, null);
                txtSTT_Validated(null, null);
                txtkhuyenmai_Validated(null, null);
                //linh
                //if khong co  co so
                //if (dscbchinhanh.Tables[0].Rows.Count > 0)
                //{
                //    if (bCncenter) ///kiem tra them co phai la chi nhanh trung tam cua he pha hay khong.
                //    {
                //        m_v.upd_v_giavp(decimal.Parse(m_id), decimal.Parse(aid_loaivp), decimal.Parse(txtSTT.Text), txtMa.Text.Trim(), txtTen.Text.Trim(), txtDVT.Text, decimal.Parse(txtGia_th.Text.Replace(",", "")), decimal.Parse(txtGia_bh.Text.Replace(",", "")), decimal.Parse(txtGia_dv.Text.Replace(",", "")), decimal.Parse(txtGia_nn.Text.Replace(",", "")), decimal.Parse(txtGia_cs.Text.Replace(",", "")), decimal.Parse(txtVattu_th.Text.Replace(",", "")), decimal.Parse(txtVattu_bh.Text.Replace(",", "")), decimal.Parse(txtVattu_dv.Text.Replace(",", "")), decimal.Parse(txtVattu_nn.Text.Replace(",", "")), decimal.Parse(txtVattu_cs.Text.Replace(",", "")), decimal.Parse(txtBHYT.Text.Replace(",", "")), decimal.Parse(cbLoaibn.SelectedValue.ToString()), chkTheobs.Checked ? 1 : 0, chkThuong.Checked ? 1 : 0, chkTrongoi.Checked ? 1 : 0, chkLoaitrongoi.Checked ? 1 : 0, chkChenhlech.Checked ? 1 : 0, chkNDM.Checked ? 1 : 0, txtLocthe.Text.Trim(), chkReadonly.Checked ? 1 : 0, decimal.Parse(m_userid), decimal.Parse(txtkhuyenmai.Text), decimal.Parse(txtGia_KSK.Text.Replace(",", "")), decimal.Parse(txtVattu_KSK.Text.Replace(",", "")), (chkKhongdung.Checked) ? 1 : 0, decimal.Parse(cbKythuatcao.SelectedValue.ToString()), txtsothe.Text, ((vat.Text != "") ? decimal.Parse(vat.Text) : 0), ((chkkhongcungchitra.Checked) ? 1 : 0), ((bhyttraituyen.Text == "") ? 0 : decimal.Parse(bhyttraituyen.Text)), ((chkTuyentw.Checked) ? 1 : 0), ((chkTuyentinh.Checked) ? 1 : 0), ((chkTuyenhuyen.Checked) ? 1 : 0), ((chkTuyenxa.Checked) ? 1 : 0), ((chkDichvu.Checked) ? 1 : 0), (chkHoichan.Checked) ? 1 : 0, chkcamdoan.Checked ? 1 : 0, s_thoigiankq, s_gt, ((txtTuoitu.Text.Trim() != "") ? decimal.Parse(txtTuoitu.Text.Trim()) : 0), ((txtTuoiden.Text.Trim() != "") ? decimal.Parse(txtTuoiden.Text.Trim()) : 0), chkBatbuocthutien.Checked ? 1 : 0, decimal.Parse(cbChdencoso.SelectedValue.ToString()), s_cosothay, s_Phongthuchiencls);
                //        if (chkxamlan.Checked)
                //        {
                //            m_v.execute_data(" update " + user + ".v_giavp set xamlan=1 where id=" + decimal.Parse(m_id));
                //        }
                //        if (!chkxamlan.Checked)
                //        {
                //            m_v.execute_data(" update " + user + ".v_giavp set xamlan=0 where id=" + decimal.Parse(m_id));
                //        }
                //        if (chkCTscannercocq.Checked)
                //        {
                //            m_v.execute_data(" update " + user + ".v_giavp set ctscannercq=1 where id=" + decimal.Parse(m_id));
                //        }
                //        //hien
                //        try
                //        {
                //            m_v.execute_data("update " + user + ".v_giavp set id_mauthu=" + cmbMauthu.SelectedValue.ToString());
                //        }
                //        catch (Exception er)
                //        {
                //            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được mẫu thử :") + er.Message, "Dược");
                //        }
                //        // gam
                //        try
                //        {
                //            if (cbVatchuamau.SelectedIndex != -1)
                //            {
                //                m_v.execute_data("update " + user + ".v_giavp set id_vatchuamau=" + cbVatchuamau.SelectedValue.ToString() + " where id=" + decimal.Parse(m_id));
                //            }
                //            m_v.execute_data("update " + user + ".v_giavp set phuthu_th=" + ((txtPtthuphi.Text != "") ? decimal.Parse(txtPtthuphi.Text) : 0) +
                //                ",phuthu_dv=" + ((txtPtdichvu.Text != "") ? decimal.Parse(txtPtdichvu.Text) : 0) +
                //                ",phuthu_nn=" + ((txtPtnuocngoai.Text != "") ? decimal.Parse(txtPtnuocngoai.Text) : 0) +
                //                ",phuthu_cs=" + ((txtPtcs.Text != "") ? decimal.Parse(txtPtcs.Text) : 0) +
                //                " where id=" + decimal.Parse(m_id));
                //        }
                //        catch (Exception er)
                //        {
                //        }
                //        if (bKhoan)
                //            m_v.execute_data("update " + user + ".v_giavp set giavtth=" + ((giavtth.Text != "") ? decimal.Parse(giavtth.Text) : 0) + " where id=" + decimal.Parse(m_id));
                //        m_v.execute_data("update " + user + ".v_giavp set maloai_bc=" + ((cboLoaiBC.SelectedIndex == -1) ? "0" : cboLoaiBC.SelectedValue.ToString()) + " where id=" + decimal.Parse(m_id));
                //    }
                //    else
                //    {
                //        m_v.upd_v_giavp_client(decimal.Parse(m_id), decimal.Parse(aid_loaivp), decimal.Parse(txtSTT.Text), txtMa.Text.Trim(), txtTen.Text.Trim(), txtDVT.Text, decimal.Parse(txtGia_th.Text.Replace(",", "")), decimal.Parse(txtGia_bh.Text.Replace(",", "")), decimal.Parse(txtGia_dv.Text.Replace(",", "")), decimal.Parse(txtGia_nn.Text.Replace(",", "")), decimal.Parse(txtGia_cs.Text.Replace(",", "")), decimal.Parse(txtVattu_th.Text.Replace(",", "")), decimal.Parse(txtVattu_bh.Text.Replace(",", "")), decimal.Parse(txtVattu_dv.Text.Replace(",", "")), decimal.Parse(txtVattu_nn.Text.Replace(",", "")), decimal.Parse(txtVattu_cs.Text.Replace(",", "")), decimal.Parse(txtBHYT.Text.Replace(",", "")), decimal.Parse(cbLoaibn.SelectedValue.ToString()), chkTheobs.Checked ? 1 : 0, chkThuong.Checked ? 1 : 0, chkTrongoi.Checked ? 1 : 0, chkLoaitrongoi.Checked ? 1 : 0, chkChenhlech.Checked ? 1 : 0, chkNDM.Checked ? 1 : 0, txtLocthe.Text.Trim(), chkReadonly.Checked ? 1 : 0, decimal.Parse(m_userid), decimal.Parse(txtkhuyenmai.Text), decimal.Parse(txtGia_KSK.Text.Replace(",", "")), decimal.Parse(txtVattu_KSK.Text.Replace(",", "")), (chkKhongdung.Checked) ? 1 : 0, decimal.Parse(cbKythuatcao.SelectedValue.ToString()), txtsothe.Text, ((vat.Text != "") ? decimal.Parse(vat.Text) : 0), ((chkkhongcungchitra.Checked) ? 1 : 0), ((bhyttraituyen.Text == "") ? 0 : decimal.Parse(bhyttraituyen.Text)), ((chkTuyentw.Checked) ? 1 : 0), ((chkTuyentinh.Checked) ? 1 : 0), ((chkTuyenhuyen.Checked) ? 1 : 0), ((chkTuyenxa.Checked) ? 1 : 0), ((chkDichvu.Checked) ? 1 : 0), (chkHoichan.Checked) ? 1 : 0, chkcamdoan.Checked ? 1 : 0, s_thoigiankq, s_gt, ((txtTuoitu.Text.Trim() != "") ? decimal.Parse(txtTuoitu.Text.Trim()) : 0), ((txtTuoiden.Text.Trim() != "") ? decimal.Parse(txtTuoiden.Text.Trim()) : 0), chkBatbuocthutien.Checked ? 1 : 0, decimal.Parse(cbChdencoso.SelectedValue.ToString()), s_cosothay, s_Phongthuchiencls, sdatabase);
                //        if (chkxamlan.Checked)
                //        {
                //            m_v.execute_data(" update " + user + ".v_giavp" + sdatabase + " set xamlan=1 where id=" + decimal.Parse(m_id));
                //        }
                //        if (!chkxamlan.Checked)
                //        {
                //            m_v.execute_data(" update " + user + ".v_giavp" + sdatabase + " set xamlan=0 where id=" + decimal.Parse(m_id));
                //        }
                //        if (chkCTscannercocq.Checked)
                //        {
                //            m_v.execute_data(" update " + user + ".v_giavp" + sdatabase + " set ctscannercq=1 where id=" + decimal.Parse(m_id));
                //        }
                //        //hien
                //        try
                //        {
                //            m_v.execute_data("update " + user + ".v_giavp" + sdatabase + " set id_mauthu=" + cmbMauthu.SelectedValue.ToString());
                //        }
                //        catch (Exception er)
                //        {
                //            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được mẫu thử :") + er.Message, "Dược");
                //        }
                //        // gam
                //        try
                //        {
                //            if (cbVatchuamau.SelectedIndex != -1)
                //            {
                //                m_v.execute_data("update " + user + ".v_giavp" + sdatabase + " set id_vatchuamau=" + cbVatchuamau.SelectedValue.ToString() + " where id=" + decimal.Parse(m_id));
                //            }
                //            m_v.execute_data("update " + user + ".v_giavp" + sdatabase + " set phuthu_th=" + ((txtPtthuphi.Text != "") ? decimal.Parse(txtPtthuphi.Text) : 0) +
                //                ",phuthu_dv=" + ((txtPtdichvu.Text != "") ? decimal.Parse(txtPtdichvu.Text) : 0) +
                //                ",phuthu_nn=" + ((txtPtnuocngoai.Text != "") ? decimal.Parse(txtPtnuocngoai.Text) : 0) +
                //                ",phuthu_cs=" + ((txtPtcs.Text != "") ? decimal.Parse(txtPtcs.Text) : 0) +
                //                " where id=" + decimal.Parse(m_id));
                //        }
                //        catch (Exception er)
                //        {
                //        }
                //        if (bKhoan)
                //            m_v.execute_data("update " + user + ".v_giavp" + sdatabase + " set giavtth=" + ((giavtth.Text != "") ? decimal.Parse(giavtth.Text) : 0) + " where id=" + decimal.Parse(m_id));
                //        m_v.execute_data("update " + user + ".v_giavp" + sdatabase + " set maloai_bc=" + ((cboLoaiBC.SelectedIndex == -1) ? "0" : cboLoaiBC.SelectedValue.ToString()) + " where id=" + decimal.Parse(m_id));
                //    }
                //}
                //else
                //{
                //end linh
                decimal d_ktcao = decimal.Parse(cbKythuatcao.SelectedValue.ToString());
                decimal d_loaibn = -1;
                try
                {
                    d_loaibn = decimal.Parse(cbLoaibn.SelectedValue.ToString());
                }
                catch { d_loaibn = -1; }
                decimal d_chuyendencoso = -1;
                try
                {
                    d_chuyendencoso = decimal.Parse(cbChdencoso.SelectedValue.ToString());
                }
                catch { d_chuyendencoso = -1; }
                m_v.upd_v_giavp(decimal.Parse(m_id), decimal.Parse(aid_loaivp), decimal.Parse(txtSTT.Text), txtMa.Text.Trim(), txtTen.Text.Trim(),
                    txtDVT.Text, decimal.Parse(txtGia_th.Text.Replace(",", "")), decimal.Parse(txtGia_bh.Text.Replace(",", "")),
                    decimal.Parse(txtGia_dv.Text.Replace(",", "")), decimal.Parse(txtGia_nn.Text.Replace(",", "")),
                    decimal.Parse(txtGia_cs.Text.Replace(",", "")), decimal.Parse(txtVattu_th.Text.Replace(",", "")),
                    decimal.Parse(txtVattu_bh.Text.Replace(",", "")), decimal.Parse(txtVattu_dv.Text.Replace(",", "")),
                    decimal.Parse(txtVattu_nn.Text.Replace(",", "")), decimal.Parse(txtVattu_cs.Text.Replace(",", "")),
                    decimal.Parse(txtBHYT.Text.Replace(",", "")), d_loaibn, chkTheobs.Checked ? 1 : 0,
                    chkThuong.Checked ? 1 : 0, chkTrongoi.Checked ? 1 : 0, chkLoaitrongoi.Checked ? 1 : 0, chkChenhlech.Checked ? 1 : 0,
                    chkNDM.Checked ? 1 : 0, txtLocthe.Text.Trim(), chkReadonly.Checked ? 1 : 0, decimal.Parse(m_userid),
                    decimal.Parse(txtkhuyenmai.Text), decimal.Parse(txtGia_KSK.Text.Replace(",", "")), decimal.Parse(txtVattu_KSK.Text.Replace(",", "")),
                    (chkKhongdung.Checked) ? 1 : 0, d_ktcao, txtsothe.Text,
                    ((vat.Text != "") ? decimal.Parse(vat.Text) : 0), ((chkkhongcungchitra.Checked) ? 1 : 0),
                    ((bhyttraituyen.Text == "") ? 0 : decimal.Parse(bhyttraituyen.Text)), ((chkTuyentw.Checked) ? 1 : 0),
                    ((chkTuyentinh.Checked) ? 1 : 0), ((chkTuyenhuyen.Checked) ? 1 : 0), ((chkTuyenxa.Checked) ? 1 : 0),
                    ((chkDichvu.Checked) ? 1 : 0), (chkHoichan.Checked) ? 1 : 0, chkcamdoan.Checked ? 1 : 0, s_thoigiankq, s_gt,
                    ((txtTuoitu.Text.Trim() != "") ? decimal.Parse(txtTuoitu.Text.Trim()) : 0),
                    ((txtTuoiden.Text.Trim() != "") ? decimal.Parse(txtTuoiden.Text.Trim()) : 0), chkBatbuocthutien.Checked ? 1 : 0,
                    d_chuyendencoso, s_cosothay, s_Phongthuchiencls);
                //linh
                m_v.execute_data("update medibv.dmgiuong set gia_th=" + decimal.Parse(txtGia_th.Text.Replace(",", "")) + ", gia_bh=" +
                    decimal.Parse(txtGia_bh.Text.Replace(",", "")) + ", gia_cs=" + decimal.Parse(txtGia_cs.Text.Replace(",", ""))
                    + ",gia_dv=" + decimal.Parse(txtGia_dv.Text.Replace(",", "")) + ",gia_nn=" +
                    decimal.Parse(txtGia_nn.Text.Replace(",", "")) + " where id="+decimal.Parse(m_id));//gam 29/02/2012 nếu sửa giá giường thì update lai gia trong dmgiuong => tranh tính sai giá
                int id_mauthu = -1, id_vatchuamau = -1;
                if (cbVatchuamau.SelectedIndex != -1)
                {
                    id_vatchuamau = int.Parse(cbVatchuamau.SelectedValue.ToString());
                }
                if (cmbMauthu.SelectedIndex != -1)
                {
                    id_mauthu = int.Parse(cmbMauthu.SelectedValue.ToString());
                }
                //if (chkxamlan.Checked)
                //{
                //    m_v.execute_data(" update " + user + ".v_giavp" + sdbclient + " set xamlan=1 where id=" + decimal.Parse(m_id));
                //}
                //if (!chkxamlan.Checked)
                //{
                //    m_v.execute_data(" update " + user + ".v_giavp" + sdbclient + " set xamlan=0 where id=" + decimal.Parse(m_id));
                //}
                //if (chkCTscannercocq.Checked)
                //{
                //    m_v.execute_data(" update " + user + ".v_giavp" + sdbclient + " set ctscannercq=1 where id=" + decimal.Parse(m_id));
                //}
                //hien
                //try
                //{
                //    m_v.execute_data("update " + user + ".v_giavp" + sdbclient + " set id_mauthu=" + cmbMauthu.SelectedValue.ToString());
                //}
                //catch (Exception er)
                //{
                //    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được mẫu thử :") + er.Message, "Dược");
                //}
                // gam
                try
                {
                    //if (cbVatchuamau.SelectedIndex != -1)
                    //{
                    //    m_v.execute_data("update " + user + ".v_giavp" + sdbclient + " set id_vatchuamau=" + cbVatchuamau.SelectedValue.ToString() + " where id=" + decimal.Parse(m_id));
                    //}
                    m_v.execute_data(" update " + user + ".v_giavp" + sdbclient + " set xamlan=" + (chkxamlan.Checked ? "1" : "0") + "," +
                        "guingoai=" + (chkGuingoai.Checked ? "1" : "0") + ",guinguoi=" + (chkGuiNguoi.Checked ? "1" : "0") + "," +
                        "guimau=" + (chkGuimau.Checked ? "1" : "0") + ",ctscannercq=" + (chkCTscannercocq.Checked ? "1" : "0") + "," +
                        "kqtaicho=" + (chkNhapkqtainoilaymau.Checked ? "1" : "0") + "," +
                        "id_mauthu=" + id_mauthu.ToString() + ",id_vatchuamau=" + id_vatchuamau.ToString() + "," +
                        " phuthu_th=" + ((txtPtthuphi.Text != "") ? decimal.Parse(txtPtthuphi.Text) : 0) +
                        ",phuthu_dv=" + ((txtPtdichvu.Text != "") ? decimal.Parse(txtPtdichvu.Text) : 0) +
                        ",phuthu_nn=" + ((txtPtnuocngoai.Text != "") ? decimal.Parse(txtPtnuocngoai.Text) : 0) +
                        ",phuthu_cs=" + ((txtPtcs.Text != "") ? decimal.Parse(txtPtcs.Text) : 0) +
                        " where id=" + decimal.Parse(m_id));
                }
                catch (Exception er)
                {
                }
                //end linh
                if (bKhoan)
                    m_v.execute_data("update " + user + ".v_giavp" + sdbclient + " set giavtth=" + ((giavtth.Text != "") ? decimal.Parse(giavtth.Text) : 0) + " where id=" + decimal.Parse(m_id));
                m_v.execute_data("update " + user + ".v_giavp" + sdbclient + " set maloai_bc=" + ((cboLoaiBC.SelectedIndex == -1) ? "0" : cboLoaiBC.SelectedValue.ToString()) + ", chuyenchungtu=" + (chkchuyenchungtu.Checked ? "1" : "0") + " where id=" + decimal.Parse(m_id));
                f_Enable(false);
                f_Load_DG1(m_id);
                butMoi.Focus();
                m_v.databaselinks_name = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void txtSTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (txtMa.Text == "")
            //        {
            //            txtMa.Text = m_v.f_get_mavp(txtTen.Text);
            //        }
            //        SendKeys.Send("{Tab}");
            //    }
            //}
            //catch
            //{
            //}
            try
            {
                int aid = 0;
                if (e.KeyCode == Keys.Enter)
                {
                    //f_Get_Item();
                    if (txtTen.Text != "")
                    {
                        //txtSoluong.SelectAll();
                        SendKeys.Send("{Tab}");
                    }
                }
                else
                if (e.KeyCode == Keys.Up)
                {
                    dtgridviewGiavp.Visible = true;
                    if (dtgridviewGiavp.CurrentCell.RowIndex > 0)
                    {
                        aid = dtgridviewGiavp.CurrentCell.RowIndex - 1;
                        dtgridviewGiavp.Rows[aid].Selected = true;
                        dtgridviewGiavp.CurrentCell = dtgridviewGiavp.Rows[aid].Cells[1];
                        SendKeys.Send("{End}");
                    }
                    else
                        if (dtgridviewGiavp.RowCount > 0)
                        {
                            aid = dtgridviewGiavp.RowCount - 1;
                            dtgridviewGiavp.Rows[aid].Selected = true;
                            dtgridviewGiavp.CurrentCell = dtgridviewGiavp.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                }
                else
                    if (e.KeyCode == Keys.Down)
                    {
                        dtgridviewGiavp.Visible = true;
                        if (dtgridviewGiavp.CurrentCell.RowIndex < dtgridviewGiavp.Rows.Count - 1)
                        {
                            aid = dtgridviewGiavp.CurrentCell.RowIndex + 1;
                            dtgridviewGiavp.Rows[aid].Selected = true;
                            dtgridviewGiavp.CurrentCell = dtgridviewGiavp.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                        else
                            if (dtgridviewGiavp.RowCount > 0)
                            {
                                aid = 0;
                                dtgridviewGiavp.Rows[aid].Selected = true;
                                dtgridviewGiavp.CurrentCell = dtgridviewGiavp.Rows[aid].Cells[1];
                                SendKeys.Send("{End}");
                            }
                    }
                    else
                if (e.KeyCode == Keys.Escape)
                {
                    dtgridviewGiavp.Visible = !dtgridviewGiavp.Visible;
                }
            }
            catch
            {
            }
        }

        private void txtDVT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDVT.Text.Trim() == "")
                    {
                        txtDVT.Text = "Lần";
                    }
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtGia_th_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGia_th_Validated(null, null);
                    if (txtGia_bh.Text.Trim() == "")
                    {
                        txtGia_bh.Text = txtGia_th.Text;
                    }
                    if (txtGia_dv.Text.Trim() == "")
                    {
                        txtGia_dv.Text = txtGia_th.Text;
                    }
                    if (txtGia_nn.Text.Trim() == "")
                    {
                        txtGia_nn.Text = txtGia_th.Text;
                    }
                    if (txtGia_cs.Text.Trim() == "")
                    {
                        txtGia_cs.Text = txtGia_th.Text;
                    }
                    if (txtGia_KSK.Text.Trim() == "")
                    {
                        txtGia_KSK.Text = txtGia_th.Text;
                    }
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtGia_bh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtGia_dv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtGia_nn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void txtVattu_th_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtVattu_th_Validated(null, null);
                    if (txtVattu_bh.Text == "")
                    {
                        txtVattu_bh.Text = txtVattu_th.Text;
                    }
                    if (txtVattu_dv.Text == "")
                    {
                        txtVattu_dv.Text = txtVattu_th.Text;
                    }
                    if (txtVattu_nn.Text == "")
                    {
                        txtVattu_nn.Text = txtVattu_th.Text;
                    }
                    if (txtVattu_cs.Text == "")
                    {
                        txtVattu_cs.Text = txtVattu_th.Text;
                    }
                    if (txtVattu_KSK.Text == "")
                    {
                        txtVattu_KSK.Text = txtVattu_th.Text;
                    }
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtVattu_bh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtVattu_dv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtVattu_nn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTrongoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void cbNhombhyt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void cbNhomvp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void cbLoaivp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}{F4}");
        }
        private void cbLoaibn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTheobs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkNDM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkReadonly_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");// butLuu.Focus();
                }
            }
            catch
            {
            }
        }

        private void chkChenhlech_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkThuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void f_Add_Nhomvp()
        {
            try
            {
                string aid_nhombhyt = "";
                try
                {
                    aid_nhombhyt = cbNhombhyt.SelectedValue.ToString();
                }
                catch
                {
                    aid_nhombhyt = "";
                }
                frmNewnhomvp af = new frmNewnhomvp(m_v, "", aid_nhombhyt, m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog();
                f_Load_Tree();
                txtTim_TextChanged(null, null);
            }
            catch
            {
            }
        }
        private void f_Add_Loaivp()
        {
            try
            {
                string aid_nhom = "";
                try
                {
                    aid_nhom = cbNhomvp.SelectedValue.ToString();
                }
                catch
                {
                    aid_nhom = "";
                }
                frmNewloaivp af = new frmNewloaivp(m_v, "", aid_nhom, m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog();
                f_Load_Tree();
                txtTim_TextChanged(null, null);
            }
            catch
            {
            }
        }
        private void cbNhomvp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbNhomvp.SelectedValue.ToString() == "-1")
                {
                    f_Add_Nhomvp();
                }
            }
            catch
            {
            }
        }

        private void txtGia_cs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtVattu_cs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtLocthe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtGia_th_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtGia_th.Text.Trim().Replace(" ", "").Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtGia_th.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtGia_th.Text = "0";
            }
            if (txtGia_th.Text.Trim() == "")
            {
                txtGia_th.Text = "0";
            }
        }

        private void txtGia_bh_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtGia_bh.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtGia_bh.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtGia_bh.Text = "0";
            }
            if (txtGia_bh.Text.Trim() == "")
            {
                txtGia_bh.Text = "0";
            }
        }

        private void txtGia_dv_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtGia_dv.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtGia_dv.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtGia_dv.Text = "0";
            }
            if (txtGia_dv.Text.Trim() == "")
            {
                txtGia_dv.Text = "0";
            }
        }

        private void txtGia_nn_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtGia_nn.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtGia_nn.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtGia_nn.Text = "0";
            }
            if (txtGia_nn.Text.Trim() == "")
            {
                txtGia_nn.Text = "0";
            }
        }

        private void txtGia_cs_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtGia_cs.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtGia_cs.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtGia_cs.Text = "0";
            }
            if (txtGia_cs.Text.Trim() == "")
            {
                txtGia_cs.Text = "0";
            }
        }

        private void txtVattu_th_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtVattu_th.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtVattu_th.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtVattu_th.Text = "0";
            }
            if (txtVattu_th.Text.Trim() == "")
            {
                txtVattu_th.Text = "0";
            }
        }

        private void txtVattu_bh_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtVattu_bh.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtVattu_bh.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtVattu_bh.Text = "0";
            }
            if (txtVattu_bh.Text.Trim() == "")
            {
                txtVattu_bh.Text = "0";
            }
        }

        private void txtVattu_dv_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtVattu_dv.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtVattu_dv.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtVattu_dv.Text = "0";
            }
            if (txtVattu_dv.Text.Trim() == "")
            {
                txtVattu_dv.Text = "0";
            }
        }

        private void txtVattu_nn_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtVattu_nn.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtVattu_nn.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtVattu_nn.Text = "0";
            }
            if (txtVattu_nn.Text.Trim() == "")
            {
                txtVattu_nn.Text = "0";
            }
        }

        private void txtVattu_cs_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtVattu_nn.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtVattu_nn.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtVattu_nn.Text = "0";
            }
            if (txtVattu_cs.Text.Trim() == "")
            {
                txtVattu_cs.Text = "0";
            }
        }

        private void txtBHYT_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtBHYT.Text.Trim().Replace(" ", ""));
                if (anum < 0 || anum > 100)
                {
                    anum = 0;
                }
                txtBHYT.Text = anum.ToString("###,###,##0.##");
                chkkhongcungchitra.Enabled = anum == 100;
            }
            catch
            {
                txtBHYT.Text = "0";
            }
            if (txtBHYT.Text.Trim() == "")
            {
                txtBHYT.Text = "0";
            }
        }

        private void txtSTT_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtSTT.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 1;
                }
                txtSTT.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtSTT.Text = "1";
            }
            if (txtSTT.Text.Trim() == "")
            {
                txtSTT.Text = "1";
            }
        }

        private void lbTrongoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_id != "")
                {
                    frmGoivpct af = new frmGoivpct(m_v, m_userid, m_id);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_DG1(m_id);
                    f_load_GridView();
                }
                else
                {
                    MessageBox.Show(this,lan.Change_language_MessageText( "Lưu giá trước khi khai báo chi tiết trọn gói")+"!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
        private void lbLoaitrongoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_id != "")
                {
                    frmGoivp af = new frmGoivp(m_v, m_userid, m_id);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_DG1(m_id);
                    f_load_GridView();
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Lưu giá trước khi khai báo chi tiết loại trọn gói")+"!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void chkTrongoi_CheckedChanged(object sender, EventArgs e)
        {
            lbTrongoi.Enabled = chkTrongoi.Checked && butLuu.Enabled;
        }

        private void chkLoaitrongoi_CheckedChanged(object sender, EventArgs e)
        {
            lbLoaitrongoi.Enabled = chkLoaitrongoi.Checked && butLuu.Enabled;
        }

        private void chkTheobs_Click(object sender, EventArgs e)
        {
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            try
            {
                string aval = chkTheobs.Checked ? "1" : "0";
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DtgGiavp.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    m_v.execute_data("update medibv.v_giavp"+sdbclient+" set theobs=" + aval + " where id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    if (rs.Length > 0)
                    {
                        rs[0]["theobs"] = aval;
                    }
                    f_Load_DG1(m_id);
                }
            }
            catch
            {
            }
        }
        private void chkThuong_Click(object sender, EventArgs e)
        {
            try
            {
                sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
                string aval = chkThuong.Checked ? "1" : "0";
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DtgGiavp.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    m_v.execute_data("update medibv.v_giavp" + sdbclient + " set thuong=" + aval + " where id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    if (rs.Length > 0)
                    {
                        rs[0]["thuong"] = aval;
                    }
                    f_Load_DG1(m_id);
                }
            }
            catch
            {
            }
        }
        private void chkNDM_Click(object sender, EventArgs e)
        {
            try
            {
                sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
                string aval = chkNDM.Checked ? "1" : "0";
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DtgGiavp.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    m_v.execute_data("update medibv.v_giavp" + sdbclient + " set ndm=" + aval + " where id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    if (rs.Length > 0)
                    {
                        rs[0]["ndm"] = aval;
                    }
                    f_Load_DG1(m_id);
                }
            }
            catch
            {
            }
        }
        private void chkChenhlech_Click(object sender, EventArgs e)
        {
            try
            {
                sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
                string aval = chkChenhlech.Checked ? "1" : "0";
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DtgGiavp.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    m_v.execute_data("update medibv.v_giavp"+sdbclient+" set chenhlech=" + aval + " where id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    if (rs.Length > 0)
                    {
                        rs[0]["chenhlech"] = aval;
                    }
                    f_Load_DG1(m_id);
                }
            }
            catch
            {
            }
        }

        private void txtkhuyenmai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtGia_KSK_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtGia_KSK.Text.Trim().Replace(" ", "").Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtGia_KSK.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtGia_KSK.Text = "0";
            }
            if (txtGia_KSK.Text.Trim() == "")
            {
                txtGia_KSK.Text = "0";
            }
        }

        private void txtGia_KSK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtVattu_KSK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtVattu_KSK_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtVattu_KSK.Text.Trim().Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtVattu_KSK.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtVattu_KSK.Text = "0";
            }
            if (txtVattu_KSK.Text.Trim() == "")
            {
                txtVattu_KSK.Text = "0";
            }
        }

        private void txtkhuyenmai_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtkhuyenmai.Text.Trim().Replace(" ", ""));
                if (anum < 0 || anum > 100)
                {
                    anum = 0;
                }

                txtkhuyenmai.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtkhuyenmai.Text = "0";
            }
            if (txtkhuyenmai.Text.Trim() == "")
            {
                txtkhuyenmai.Text = "0";
            }
        }

        private void chkLoaitrongoi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void chkKhongdung_Click(object sender, EventArgs e)
        {
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            try
            {
                string aval = chkKhongdung.Checked ? "1" : "0";
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DtgGiavp.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    m_v.execute_data("update medibv.v_giavp"+sdbclient+" set hide=" + aval + " where id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    if (rs.Length > 0)
                    {
                        rs[0]["hide"] = aval;
                    }
                    f_Load_DG1(m_id);
                }
            }
            catch
            {
            }
        }

        private void chkReadonly_Click(object sender, EventArgs e)
        {
            try
            {

                sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
                string aval = chkReadonly.Checked ? "1" : "0";
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DtgGiavp.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    m_v.execute_data("update medibv.v_giavp"+sdbclient+" set readonly=" + aval + " where id=" + DtgGiavp[i, 0].ToString().Trim() + "");
                    if (rs.Length > 0)
                    {
                        rs[0]["readonly"] = aval;
                    }
                    f_Load_DG1(m_id);
                }
            }
            catch
            {
            }
        }

        private void DtgGiavp_CurrentCellChanged(object sender, EventArgs e)
        {
            f_load_GridView();
        }

        private void cbKythuatcao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void giavtth_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal gia = (giavtth.Text != "") ? decimal.Parse(giavtth.Text) : 0;
                giavtth.Text = gia.ToString("###,###,###,###");
            }
            catch { }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            txtTim.Text = "";
        }

        private void vat_KeyPress(object sender, KeyPressEventArgs e)
        {
            m.MaskDecimal(e);
        }

        private void txtsothe_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cboLoaiBC.Focus();
                }
            }
            catch { }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_Validated(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                txtMa.Text = m_v.f_get_mavp(txtTen.Text);
            }
        }

        private void cboLoaiBC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) butLuu.Focus();// SendKeys.Send("{Tab}{F4}");
            }
            catch { }
        }

        private void cboLoaiBC_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void chkDichvu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDichvu.Checked)
            {
                chkThuong.Checked = false;
            }
        }

        private void chkThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThuong.Checked)
            {
                chkDichvu.Checked = false;
            }
        }
        /// <summary>
        /// Linh: Tốn quá nhiều session, quá vô lý
        /// </summary>
        public void f_capnhat_db_danhmuc()
        {
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
            string asql = "";
            DataSet lds = new DataSet();
            DataSet ds = new DataSet();
            asql = "select dichvu from " + m_v.user + ".v_giavp" + sdbclient + " where id=0";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_giavp" + sdbclient + " add dichvu numeric(1) default 0";
                m_v.execute_data(asql);
            }
            asql = " select maloai_bc from " + m_v.user + ".v_giavp" + sdbclient + " where 1=2";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_giavp" + sdbclient + " add maloai_bc numeric default 0";
                m_v.execute_data(asql);
            }
            //Dong them filed
            asql = " select hoichan from " + m_v.user + ".v_giavp" + sdbclient + " where id=0";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_giavp" + sdbclient + " add hoichan numeric(1) default 0 ";
                m_v.execute_data(asql);
            }
            asql = " select giaycamdoan from " + m_v.user + ".v_giavp" + sdbclient + " where id=0";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_giavp" + sdbclient + " add giaycamdoan numeric(1) default 0 ";
                m_v.execute_data(asql);
            }
            asql = " select gioitinh from " + m_v.user + ".v_giavp" + sdbclient + " where id=0";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_giavp" + sdbclient + " add gioitinh character varying(10) default null ";
                m_v.execute_data(asql);
            }
            asql = " select tutuoi from " + m_v.user + ".v_giavp" + sdbclient + " where id=0";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_giavp" + sdbclient + " add tutuoi numeric(3) default 0 ";
                m_v.execute_data(asql);
            }
            asql = " select dentuoi from " + m_v.user + ".v_giavp" + sdbclient + " where id=0";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = "alter table " + m_v.user + ".v_giavp" + sdbclient + " add dentuoi numeric(3) default 0 ";
                m_v.execute_data(asql);
            }
            asql = " select batbuocthutien,coso,cosothay,kpthuchien from " + m_v.user + ".v_giavp" + sdbclient + " where id=0";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = " alter table " + m_v.user + ".v_giavp" + sdbclient + " add batbuocthutien numeric(1,0) default 0;\n ";
                asql += " alter table " + m_v.user + ".v_giavp" + sdbclient + " add coso numeric(3,0) default 0;\n ";
                asql += " alter table " + m_v.user + ".v_giavp" + sdbclient + " add cosothay character varying(50) default null;\n ";
                asql += " alter table " + m_v.user + ".v_giavp" + sdbclient + " add phongthuchiencls character varying(50) default null ";
                m_v.execute_data(asql);
            }
            asql = " select tgtrakq from " + m_v.user + ".v_giavp" + sdbclient + " where 1=2";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = " alter table " + m_v.user + ".v_giavp" + sdbclient + " add tgtrakq character varying(10) default null ";
                m_v.execute_data(asql);
            }
            asql = " select xamlan from " + m_v.user + ".v_giavp" + sdbclient + " where 1=2";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = " alter table " + m_v.user + ".v_giavp" + sdbclient + " add xamlan numeric(1,0) default 0 ";
                m_v.execute_data(asql);
            }

            //hepa: day cac field
            asql = " select thoigiantrakq, manhom, machuyenkhoa, phuthu_th, phuthu_dv, phuthu_nn, phuthu_cs, id_vatchuamau from " +
                m_v.user + ".v_giavp" + sdbclient + " where 1=2";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = " alter table medibv.v_giavp" + sdbclient + " add machuyenkhoa varchar(20)";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp" + sdbclient + " add manhom varchar(20)";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp" + sdbclient + " add phuthu_th number(10) default 0";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp" + sdbclient + " add phuthu_dv number(10)  default 0";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp" + sdbclient + " add phuthu_nn number(10)  default 0";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp" + sdbclient + " add phuthu_cs number(10)  default 0 ";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp" + sdbclient + " add id_vatchuamau number(5)  default 0 ";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp" + sdbclient + " add thoigiantrakq varchar(50)";
                m_v.execute_data(asql);
            }
            asql = " select ctscannercq from " + m_v.user + ".v_giavp" + sdbclient + " where 1=2";
            ds = m_v.get_data(asql);
            if (ds == null || ds.Tables.Count <= 0)
            {
                asql = " alter table " + m_v.user + ".v_giavp" + sdbclient + " add ctscannercq numeric(1,0) default 0 ";
                m_v.execute_data(asql);
            }
            //End dong
        }
        private void txtTuoiden_Validated(object sender, EventArgs e)
        {
            if (decimal.Parse(txtTuoitu.Text.Trim()) > decimal.Parse(txtTuoiden.Text.Trim()))
                MessageBox.Show(lan.Change_language_MessageText("Từ tuổi không được lớn hơn đến tuổi")+"..!! ", lan.Change_language_MessageText("Vienphi"), MessageBoxButtons.OK, MessageBoxIcon.Question);
            txtTuoiden.Focus();
        }
        private void lbKythuatxungdot_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_id != "")
                {
                    frmKythuatxungdot af = new frmKythuatxungdot(m_v, m_userid, m_id);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_DG1(m_id);
                    f_load_GridView();
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn giá viện phí trước khi lưu")+" !", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
        private void cbLoaivp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //binh f_Load_File_Phongthuchiencls(int.Parse(cbLoaivp.SelectedValue.ToString()));
        }

        private void txtThoigiantrakq_Validated(object sender, EventArgs e)
        {
            //linh
            //txtThoigiantrakq.Text = txtThoigiantrakq.Text.PadLeft(7, '0');
            //if (txtThoigiantrakq.Text.Trim() != "00")
            //{
            //    cbThoigiankq.Enabled = true;
            //}
            //end linh
        }

        private void txtThoigiantrakq_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == txtThoigiantrakq)
            {
                try { int.Parse(txtThoigiantrakq.Text); }
                catch
                {
                    txtThoigiantrakq.Text = "00";
                    txtThoigiantrakq.SelectAll();
                }
            }
        }

        private void txtThoigiantrakq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbThoigiankq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTuoitu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTuoiden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkxamlan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cbChdencoso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTuyentinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTuyentw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkBatbuocthutien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTuyenxa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkkhongcungchitra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTuyenhuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkDichvu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkcamdoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkHoichan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void bhyttraituyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cmbMauthu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkNhapkqtainoilaymau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkNhapkqtainoilaymau_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
                string aval = chkNhapkqtainoilaymau.Checked ? "1" : "0";
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DtgGiavp.DataSource, DtgGiavp.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DtgGiavp.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id=" + DtgGiavp[i, 0].ToString().Trim() + "");

                    if (rs.Length > 0)
                    {
                        m_v.execute_data("update " + user + ".v_giavp"+sdbclient+" set kqtaicho=" + aval + " where id=" + DtgGiavp[i, 0].ToString().Trim());
                        rs[0]["kqtaicho"] = aval;
                    }
                    f_Load_DG1(m_id);
                }
            }
            catch
            {
            }
        }

        private void txtPtthuphi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtPtdichvu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtPtnuocngoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtPtcs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtPtthuphi_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtPtthuphi.Text.Trim().Replace(" ", "").Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtPtthuphi.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtPtthuphi.Text = "0";
            }
            if (txtGia_th.Text.Trim() == "")
            {
                txtPtthuphi.Text = "0";
            }
        }

        private void txtPtdichvu_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtPtdichvu.Text.Trim().Replace(" ", "").Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtPtdichvu.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtPtdichvu.Text = "0";
            }
            if (txtGia_th.Text.Trim() == "")
            {
                txtPtdichvu.Text = "0";
            }
        }

        private void txtPtnuocngoai_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtPtnuocngoai.Text.Trim().Replace(" ", "").Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtPtnuocngoai.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtPtnuocngoai.Text = "0";
            }
            if (txtGia_th.Text.Trim() == "")
            {
                txtPtnuocngoai.Text = "0";
            }
        }

        private void txtPtcs_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal anum = decimal.Parse(txtPtcs.Text.Trim().Replace(" ", "").Replace(" ", ""));
                if (anum < 0)
                {
                    anum = 0;
                }
                txtPtcs.Text = anum.ToString("###,###,##0.##");
            }
            catch
            {
                txtPtcs.Text = "0";
            }
            if (txtGia_th.Text.Trim() == "")
            {
                txtPtcs.Text = "0";
            }
        }

        //linh
        private void cbchinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbchinhanh || sender == null)
            {
                ichinhanh = int.Parse(cbchinhanh.SelectedValue.ToString());
                DataRow rcn = m_v.getrowbyid(dscbchinhanh.Tables[0], "id=" + ichinhanh.ToString());
                if (rcn != null)
                {
                    bCncenter = rcn["trungtam"].ToString() == "1";
                    sdbclient = rcn["database"].ToString().Trim('@');
                }
                check_local(ichinhanh);
                //linh
                //sdbclient = m_v.get_Tendatabase(int.Parse(cbchinhanh.SelectedValue.ToString()));
                //bCncenter = m_v.bServercenter(int.Parse(cbchinhanh.SelectedValue.ToString()));
                //end linh
                f_Load_DG();
                f_Enable(true);
                if (bCncenter)
                {
                    butMoi.Visible = true;
                    butChuyen.Text = lan.Change_language_MessageText("Chuyển dữ liệu");
                }
                else
                {
                    butMoi.Visible = false;
                    butChuyen.Text = lan.Change_language_MessageText("Lấy dữ liệu");
                }
            }
            //linh
            //else
            //{
            //    sdbclient = m_v.get_Tendatabase(ichinhanh);
            //    bCncenter = m_v.bServercenter(ichinhanh);
            //    f_Load_DG();
            //}
            //end linh
        }

        private void butChuyen_Click(object sender, EventArgs e)
        {
            sdbclient = sdbclient == "" ? "" : "@" + sdbclient;
            if (bCncenter)
            {
                frmChonchinhanh fchon = new frmChonchinhanh(m_v);
                fchon.ShowDialog();
                string s_idchinhanhchuyen = fchon.IDChiNhanh;
                if (s_idchinhanhchuyen.Trim() != "")
                {
                    foreach (string s_chinhanh in s_idchinhanhchuyen.Split(','))
                    {
                        DataRow rcn = m.getrowbyid(dscbchinhanh.Tables[0], "id=" + s_chinhanh);
                        if (rcn != null)
                        {
                            string databaselink = rcn["database"].ToString().Trim('@');
                            if (databaselink != "")
                            {
                                databaselink = "@" + databaselink.Trim('@');
                                string s_sql = "insert into " + user + ".v_giavp" + databaselink + " select * from " + user + ".v_giavp"+sdbclient+" where id not in(select id from " + user + ".v_giavp" + databaselink + ")";
                                m_v.execute_data(s_sql);
                            }
                        }
                    }
                }
            }
            else
            {
                sdbclient = sdbclient == "" ? "" : "@" + sdbclient.Trim('@');
                string s_sql = "select database from " + user + ".dmchinhanh where trungtam=1 and trim(coalesce(database,''))<>''";
                foreach (DataRow rcn in m_v.get_data(s_sql).Tables[0].Rows)
                {
                    string databaselink = rcn["database"].ToString().Trim('@');
                    if (databaselink != "")
                    {
                        databaselink = "@" + databaselink.Trim('@');
                        s_sql = "insert into " + user + ".v_giavp" + sdbclient + " select * from " + user + ".v_giavp" + databaselink + " where id not in(select id from " + user + ".v_giavp" + sdbclient + ")";
                        m_v.execute_data(s_sql);
                    }
                }
                cbchinhanh_SelectedIndexChanged(null, null);
            }
        }
        private void chkGuingoai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGuingoai.Checked)
            {
                chkGuimau.Checked = false;
                chkGuiNguoi.Checked = false;
            }
        }

        private void chkGuimau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGuimau.Checked)
            {
                chkGuingoai.Checked = false;
                chkGuiNguoi.Checked = false;
            }
        }

        private void chkGuiNguoi_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkGuiNguoi.Checked)
            //{
            //    chkGuimau.Checked = false;
            //    chkGuingoai.Checked = false;
            //}            
        }
        //Khuong
        private void txtThoigiantrakq_KeyPress(object sender, KeyPressEventArgs e)
        {
            string decimalString = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            char decimalChar = Convert.ToChar(decimalString);
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) { }
            else if (e.KeyChar == char.Parse(decimalString) && txtThoigiantrakq.Text.IndexOf(decimalString) == -1) { }
            else
            {
                e.Handled = true;
            }
        }

        private void cbThoigiankq_Validating(object sender, CancelEventArgs e)
        {
            if (cbThoigiankq.SelectedIndex == -1)
            {
                cbThoigiankq.SelectedIndex = 0;
            }
        }

        private void cboLoaithoigiantrakq_Validating(object sender, CancelEventArgs e)
        {
            if (cboLoaithoigiantrakq.SelectedIndex == -1)
            {
                cboLoaithoigiantrakq.SelectedIndex = 0;
            }
        }
        bool test()
        {
            if (chkGuimau.Checked || chkGuiNguoi.Checked)
            {
                if (cbChdencoso.SelectedIndex == -1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng chọn cơ sở gởi đến") + ".", "Medisoft");
                    cbChdencoso.Focus();
                    SendKeys.Send("{F4}");
                    return false;
                }
            }
            if (cbChdencoso.SelectedIndex > -1)
            {
                string id_cosochuyenden = cbChdencoso.SelectedValue.ToString();
                for (int i = 0; i < chklistCosoduocthay.Items.Count; i++)
                {
                    if (chklistCosoduocthay.GetItemChecked(i))
                    {
                        if (dscoso.Tables[0].Rows[i]["id"].ToString() == id_cosochuyenden)
                        {
                            return true;
                        }
                    }
                }
                MessageBox.Show(lan.Change_language_MessageText("Cơ sở được chuyển đến phải nằm trong danh sách các cơ sở thực hiện được") + ".", "Medisoft");
                cbChdencoso.Focus();
                SendKeys.Send("{F4}");
                return false;
            }
            if (chkGuingoai.Checked)
            {
                cbChdencoso.Text = "";
                cbChdencoso.SelectedIndex = -1;
            }
            return true;
        }

        private void f_check_guinguoi_guimau_chungtu()
        {
            if (chkchuyenchungtu.Checked)
            {
                chkGuimau.Checked = false;
                chkGuingoai.Checked = false;
                chkGuiNguoi.Checked = false;
            }
            else if (chkGuimau.Checked)
            {
                chkchuyenchungtu.Checked = false;
                chkGuingoai.Checked = false;
                chkGuiNguoi.Checked = false;
            }
            if (chkGuingoai.Checked)
            {
                chkGuimau.Checked = false;
                chkchuyenchungtu.Checked = false;
                chkGuiNguoi.Checked = false;
            }
            if (chkGuiNguoi.Checked)
            {
                chkGuimau.Checked = false;
                chkGuingoai.Checked = false;
                chkchuyenchungtu.Checked = false;
            }
        }

        private void chkGuiNguoi_Click(object sender, EventArgs e)
        {
            f_check_guinguoi_guimau_chungtu();
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == txtTen)
                {
                    //f_Filter_Giavp();
                }
            }
            catch
            {
            }
        }
        private void f_Filter_Giavp()
        {
            try
            {
                string aft = "";
                if (txtTen.Text != "")
                {
                    aft = "ma like '%" + txtTen.Text.Trim() + "%' or ten like '%" + txtTen.Text.Trim() + "%' or dvt like '%" + txtTen.Text.Trim() + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dtgridviewGiavp.DataSource, dtgridviewGiavp.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                //Column2_3.HeaderText = "Tên viện phí (Tìm thấy: " + dv.Table.Select(aft).Length.ToString() + ")";
                if (dtgridviewGiavp.Visible == false && this.ActiveControl == txtTen)
                {
                    dtgridviewGiavp.Visible = true;
                }
            }
            catch
            {
                //Column2_3.HeaderText = "Tên viện phí (Tìm thấy: " + m_dsgiavp.Tables[0].Rows.Count.ToString() + ")";
            }
        }

        private void dtgridviewGiavp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl != txtTen)
                {
                    dtgridviewGiavp.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void dtgridviewGiavp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) dtgridviewGiavp.Focus();
                if (e.KeyCode == Keys.Enter)
                {
                    f_Get_Item();
                    SendKeys.Send("{Tab}");
                    dtgridviewGiavp.Visible = false;
                }
                else
                    if (e.KeyCode == Keys.Escape)
                    {
                        dtgridviewGiavp.Visible = false;
                    }
            }
            catch
            {
            }
        }

        private void dtgridviewGiavp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void f_Get_Item()
        {
            try
            {
                DataRowView arv = (DataRowView)(dtgridviewGiavp.CurrentRow.DataBoundItem);
                m_id_gia = arv["id"].ToString();
                txtMa.Text = arv["ma"].ToString();
                txtTen.Text = arv["ten"].ToString();

            }
            catch (Exception ex)
            {
                m_id_gia = "";
                //MessageBox.Show(ex.ToString());
            }
        }

        private void cbChdencoso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}