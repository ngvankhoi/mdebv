using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Vienphi
{
    
    public partial class frmInchiphitonghop : Form
    {
        #region Khai bao
        private LibVP.AccessData m_v = new LibVP.AccessData();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private DataSet ads = new DataSet();
        private DataSet ads1=new DataSet();
        Language lan = new Language();
        private DataSet s_ads;
        private DataRow r1, r2;
        private DataRow[] dr;
        private string v_userid = "", sql = "", m_id = "", m_idhddt = "", m_ngaythu = "", m_sothe = "", m_maql = "";
        DataSet m_dshoadon = new DataSet();
        private frmPrintHD m_frmprinthd;
        private frmDanhsachinbienlaitaichinh m_danhsachthu;
        private DataSet m_dsgiavp;
        private DataSet m_dsnhomvp;
        private DataSet m_dsloaivp;
        private DataSet m_dshoadon_nhomvp = new DataSet();
        String m_mabn = "", m_mavaovien = "";
        private bool v_nhapmienchitiet;
        private decimal zsotien_datra = 0, zbhyt_datra = 0, zmien_datra = 0, zbntra_datra = 0, ztamung_datra = 0;
        private int itablekb, itablethuoc, itablecls, itablebhyt, itableds, itablettrvbhyt, itablect, itablell, iTunguyen, traituyen = 0, iTraituyen, iSothang = 1;
        private bool v_miendt_loai, v_BHYT_PL_PK, v_BHYT_PL_PK_KhongNV, v_BHYT_NT_PK, v_BHYT_NgT_PK, v_Quanglythatthuno, v_loadcho = false, v_Quanglydichvu;
        private string m_doituongmien = "";
        private decimal dBhyt_Chitra_Toida_7CN = 0;
        private decimal lTraituyen = 0;
        private string v_solanin = "1";
        private string m_id_toathuocbhyt = "", v_dongiabhyt = "", m_idkhoa = "", m_id_thvpll="";
        DataSet ads_doituong = new DataSet();
        private string s_mavp_congkham = "";
        private bool m_bnmoi = false, thutheongay = false, thutheodot_mavaovien = false,  bTunguyen, bBatbuoc, b_bhyt_100_theodoibienlai = false;
        private decimal tongtien = 0;
        private bool v_UserDuyet = false;
        #endregion

        public frmInchiphitonghop(string s_userid, bool b_userDuyet)
        {
            InitializeComponent();
            v_userid = s_userid;
            v_UserDuyet = b_userDuyet;
            m_v.f_SetEvent(this);
            f_Load_Data();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        private void f_Load_Data()
        {        
            m_frmprinthd = new frmPrintHD(m_v, v_userid);
            m_danhsachthu = new frmDanhsachinbienlaitaichinh(v_userid);
            m_danhsachthu.ShowInTaskbar = false;
            txtngayhoadon.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
            
            ads_doituong = m_v.get_data("select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong where madoituong=1 or mien=1 order by madoituong");            
            m_doituongmien = "";
            foreach (DataRow r1 in ads_doituong.Tables[0].Select("mien=1"))
            {
                m_doituongmien += ",";
                m_doituongmien += r1["madoituong"].ToString();
            }
            m_doituongmien += ",";
            m_dsgiavp = m_v.get_data("select a.id, case when b.id_nhom is null then 0 else b.id_nhom end as id_nhom,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.bhyt, case when a.ndm is null then 0 else a.ndm end as ndm, 0 as loaigia from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id union all select a1.id,case when b1.nhomvp is null then 0 else b1.nhomvp end as id_nhom,a1.ma,a1.ten || case when trim(a1.tenhc)='' then '' else '[' || trim(a1.tenhc) || ']' end as ten ,a1.dang as dvt, a1.giaban as gia_th, a1.giaban as gia_bh, a1.giaban as gia_dv,a1.giaban as gia_nn, a1.giaban as gia_cs, a1.bhyt,0 as ndm, 1 as loaigia from medibv.d_dmbd a1 inner join medibv.d_dmnhom b1 on a1.manhom=b1.id where b1.nhom=1 order by ten");
            m_dsnhomvp = m_v.get_data("select ma as id, stt, ten,viettat, to_number(0,'9') as sotien from medibv.v_nhomvp order by stt, ten");
            m_dsloaivp = m_v.get_data("select id,stt,ten,viettat,id_nhom,to_number(0,'9') as sotien from medibv.v_loaivp order by stt, ten");
            dBhyt_Chitra_Toida_7CN = m_v.Bhyt_Chitra_7cn;
            s_mavp_congkham = m_v.sys_mavp_congkhamBHYT;
            //v_BHYT_PL_PK_KhongNV = m.bPhongluu_bhyt_khambenh_khongnhapvien;
            //v_BHYT_NT_PK = m_v.bNoitru_bhyt_khambenh;
            //v_BHYT_NgT_PK = m_v.bNgoaitru_bhyt_khambenh;
        }
        private void frmInchiphitonghop_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            f_TaoTable();
            dgDanhsach.AutoGenerateColumns = false;
            dgDanhsachthu.AutoGenerateColumns = false;
            dgHoadon_bhyt.AutoGenerateColumns = false;
            dgHoadon_noitru.AutoGenerateColumns = false;
            gHoadon.Tag = 2;
            if (v_UserDuyet)
                optChuain.Visible = false;
            else
                optIn.Visible = false;
            if (v_UserDuyet)
            {
                optDuyet.Checked = true;
                gIn.Tag = 1;
                chkAll_hoadon.Visible = false;
            }
            else
                optChuain_CheckedChanged(null, null);
      
            //f_Load_DG();
            iTunguyen = m_v.iTunguyen; cmbTraituyen.SelectedIndex = 0;
            lTraituyen = (m.bTraituyen) ? m.lTraituyen_phongkham : 0;
            iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
            //toolStrip2.Hide();
            lbPhaithu.Hide();
            txtPhaithu.Hide();
            cmbTraituyen.Hide();
            try
            {
                m_v.execute_data(DateTime.Today.ToString("dd/MM/yyyy", null), DateTime.Today.ToString("dd/MM/yyyy", null), "alter table medibvmmyy.v_vienphill add hddt numeric(1) DEFAULT 0 ");
                m_v.execute_data(DateTime.Today.ToString("dd/MM/yyyy", null), DateTime.Today.ToString("dd/MM/yyyy", null), "alter table medibvmmyy.v_ttrvll add hddt numeric(1) DEFAULT 0 ");
            }
            catch
            {
            }
           
        }
        private void f_TaoTable()
        {
            s_ads = new DataSet();
            s_ads.Tables.Add("Table");
            s_ads.Tables[0].Columns.Add(new DataColumn("chon", typeof(decimal)));
            s_ads.Tables[0].Columns.Add(new DataColumn("mabn", typeof(string)));
            s_ads.Tables[0].Columns.Add(new DataColumn("hoten", typeof(string)));
            s_ads.Tables[0].Columns.Add(new DataColumn("phai", typeof(string)));
            s_ads.Tables[0].Columns.Add(new DataColumn("namsinh", typeof(string)));
            s_ads.Tables[0].Columns.Add(new DataColumn("diachi", typeof(string)));
            s_ads.Tables[0].Columns.Add(new DataColumn("chiphi", typeof(decimal)));
            s_ads.Tables[0].Columns.Add(new DataColumn("mien", typeof(decimal)));
            s_ads.Tables[0].Columns.Add(new DataColumn("idvienphi", typeof(string)));


        }
        private void txtkyhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtSBL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtngayhoadon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtnoidung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txttenDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtdiachiDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtSTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtMST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butLuu.Focus();
            }
        }

        private void txtGTGT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                butMoi.Focus();
            }
        }

        private void butTonghop_Click(object sender, EventArgs e)
        {
            //f_Load_DG();
            switch (gHoadon.Tag.ToString())
            {
                case "1":
                    f_Load_DG_Tructiep();
                    toolStrip2.Hide();
                    break;
                case "2":
                    if (gIn.Tag.ToString() == "0")
                        f_Load_DG_BHYT_NGT();
                    else
                        f_Load_DG_BHYT_NGT_Duyet();
                    toolStrip2.Show();
                    break;
                case "3":
                    f_Load_DG_noitru();
                    toolStrip2.Show();
                    break;
            }
            //f_tinhTong(int.Parse(gHoadon.Tag.ToString()));
            butMoi.PerformClick();
        }

        private void f_Load_DG()
        {
            if (dgDanhsach.DataSource != null)
            {
                s_ads.Tables[0].Rows.Clear();
            }
            sql = " select 0 as chon,a.mabn,a.hoten,a.namsinh,case when a.phai=1 then 'Nữ' else 'Nam' end as phai,c.tenkp,e.sohieu as kyhieu,a.sobienlai,sum(b.soluong*b.dongia) as chiphi,sum(mien) as mien,d.hoten as nguoithu,a.id as idvienphi,a.makp,a.diachi  ";
            sql += " from medibvmmyy.v_vienphill a, medibvmmyy.v_vienphict b,medibv.btdkp_bv c,medibv.v_dlogin d,medibv.v_quyenso  e";
            sql += " where a.id=b.id and a.makp=c.makp and a.userid=d.id and a.quyenso=e.id";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
            sql += " and a.id not in (select idvienphi from medibvmmyy.v_bienlaitaichinhct where id in(select id from medibvmmyy.v_bienlaitaichinhll))";
            sql += " group by a.makp,a.mabn,a.hoten,a.namsinh,case when a.phai=1 then 'Nữ' else 'Nam' end,c.tenkp,e.sohieu,a.sobienlai,d.hoten,a.id,a.diachi ";
            sql += " order by a.hoten";

            foreach (DataRow r in m_v.get_data_mmyy(sql, txtTN.Text, txtTN.Text, true).Tables[0].Rows)
            {
                r1 = m_v.getrowbyid(s_ads.Tables[0], "mabn='" + r["mabn"].ToString() + "'");
                if (r1 == null)
                {
                    r2 = s_ads.Tables[0].NewRow();
                    r2["chon"] = 0;
                    r2["mabn"] = r["mabn"].ToString();
                    r2["hoten"] = r["hoten"].ToString();
                    r2["phai"] = r["phai"].ToString();
                    r2["namsinh"] = r["namsinh"].ToString();
                    r2["diachi"] = r["diachi"].ToString();
                    r2["chiphi"] = decimal.Parse(r["chiphi"].ToString());
                    r2["mien"] = decimal.Parse(r["mien"].ToString());
                    r2["idvienphi"] = r["idvienphi"].ToString();
                    s_ads.Tables[0].Rows.Add(r2);
                }
                else
                {
                    dr = s_ads.Tables[0].Select("mabn='" + r["mabn"].ToString() + "'");
                    if (dr.Length > 0)
                    {
                        dr[0]["chiphi"] = decimal.Parse(dr[0]["chiphi"].ToString()) + decimal.Parse(r["chiphi"].ToString());
                        dr[0]["mien"] = decimal.Parse(dr[0]["mien"].ToString()) + decimal.Parse(r["mien"].ToString());
                        dr[0]["idvienphi"] = dr[0]["idvienphi"].ToString() + "," + r["idvienphi"].ToString();
                    }
                    s_ads.AcceptChanges();
                }
            }


            dgDanhsach.DataSource = s_ads.Tables[0];
            lbltongso.Text = s_ads.Tables[0].Rows.Count.ToString();
        }
        private void f_Load_DG_Tructiep()
        {
          
            try
            {
              
                string sql = "", aexp = "",asql="";
                //int alimit = 0;

                aexp = "where a.hddt="+gIn.Tag.ToString()+" and b1.id is null and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') ";


                sql = "select case when rownum = 1 then to_number('1') else to_number('0') end as chon, e.tenkp,a.mabn,a.hoten,a.namsinh,";
                sql += " to_char(a.ngay,'dd/mm/yyyy') as ngay, d.sohieu,";// ||' '||to_char(a.ngayud,'hh24:mi')
                sql += " a.sobienlai, sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end)-max(case when c.sotien is null then 0 else c.sotien end) as thucthu,";
                sql += " case when c.sotien is null then 0 else c.sotien end as mien,sum(b.soluong*b.dongia-case when b.thieu is null then 0 else b.thieu end) as sotien, ";
                sql += " trim(a.diachi) as diachi,a.id,trim(to_char(a.sobienlai,9999999)) as sbl ";
                sql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id ";
                sql += " left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru c ";
                sql += " on a.id=c.id left join medibv.v_quyenso d on a.quyenso=d.id ";
                sql += " inner join medibv.btdkp_bv e on a.makp=e.makp " + aexp + "";
                sql += " group by e.tenkp,a.id,a.mabn,a.hoten,a.namsinh,a.diachi,";
                sql += " to_char(a.ngay,'dd/mm/yyyy') , ";//
                sql += " d.sohieu,a.sobienlai,c.sotien order by sohieu,sobienlai";
                //asql = "select case when rownum = 1 then to_number('1') else to_number('0') end as chon,mabn,hoten,namsinh, ngay,'' as diachi,sum(thucthu) as thucthu,sum(mien) as mien,sum(sotien) as sotien,to_number('0') as id from (";
                asql = "select chon,mabn,hoten,namsinh, ngay,'' as diachi,sum(thucthu) as thucthu,sum(mien) as mien,sum(sotien) as sotien,to_number('0') as id from (";
                asql += sql;
                asql += ") as ds group by mabn,hoten,namsinh, ngay, chon";    

                //dgHoadon.DataSource = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql,alimit).Tables[0];
                dgDanhsach.DataSource = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtTN.Text.Substring(0, 10), false).Tables[0];
                dgDanhsach.Update();
                //decimal  amien = 0;//atmp = 0, asotien = 0,
                //try
                //{
                //    sql = "select sum(b.soluong*b.dongia - case when b.thieu is null then 0 else b.thieu end) as sotien from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id " + aexp + "";
                //    //foreach (DataRow r in m_v.get_data_bc(txtTN.Value, txtDN.Value, sql).Tables[0].Rows)
                //    foreach (DataRow r in m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false).Tables[0].Rows)
                //    {
                //        try
                //        {
                //            atmp = decimal.Parse(r[0].ToString());
                //        }
                //        catch
                //        {
                //            atmp = 0;
                //        }
                //        asotien += atmp;
                //    }
                //}
                //catch
                //{
                //}
                //try
                //{
                //    sql = "select sum(case when b.sotien is null then 0 else b.sotien end) as sotien from medibvmmyy.v_vienphill a inner join medibvmmyy.v_mienngtru b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id " + aexp + "";
                //    foreach (DataRow r in m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                //    {
                //        try
                //        {
                //            atmp = decimal.Parse(r[0].ToString());
                //        }
                //        catch
                //        {
                //            atmp = 0;
                //        }
                //        amien += atmp;
                //    }
                //}
                //catch
                //{
                //}
//                asotien -= amien;
//                tmn_Sotien.Text = dgHoadon.RowCount.ToString() + " " +
//lan.Change_language_MessageText("HĐ =") + asotien.ToString("###,###,##0.##") + " " +
//lan.Change_language_MessageText("Đ");
            }
            catch
            {
                //try
                //{
                //    CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                //    DataView dv = (DataView)(cm.List);
                //    dv.Table.Rows.Clear();
                //}
                //catch
                //{
                //}
                //tmn_Sotien.Text = lan.Change_language_MessageText("0 HĐ = 0 Đ");
            }
            
        }
        private void txttinnhanh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                if (txttinnhanh.Text != "Tìm kiếm")
                {
                    aft = " hoten like '%" + txttinnhanh.Text.Trim() + "%' or mabn like '%" + txttinnhanh.Text.Trim() + "%'";
                }
                CurrencyManager mc = (CurrencyManager)BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember];
                DataView dv = (DataView)mc.List;
                dv.RowFilter = aft;
                
            }
            catch
            { 
            }
        }

        private void txttinnhanh_Click(object sender, EventArgs e)
        {
            txttinnhanh.Text = "";
        }
        private void f_Checkall(DataGridView v_dgv, CheckBox v_cb)
        {
            try
            {
                int aval = v_cb.Checked ? 1 : 0;
                CurrencyManager cm = (CurrencyManager)(BindingContext[v_dgv.DataSource, v_dgv.DataMember]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Rows)
                {
                    r["chon"] = aval;
                }
            }
            catch
            {
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           // f_Checkall(dgDanhsach, chk_All);
        }

        private void dgDanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                try
                {
                    m_mabn = ""; m_mavaovien = "";
                    try
                    {
                        if (e != null)
                        {
                            if (e.ColumnIndex == 0)
                            dgDanhsach[0, e.RowIndex].Value = dgDanhsach[0, e.RowIndex].Value.ToString() == "0" ? "1" : "0";
                            DataRowView arv = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
                            m_id = (arv["id"].ToString() != "") ? arv["id"].ToString() : "0";
                            m_ngaythu = arv["ngay"].ToString();
                            m_mabn = arv["mabn"].ToString();
                            m_mavaovien = arv["mavaovien"].ToString();
                            if (dgDanhsach[0, e.RowIndex].Value.ToString() == "1")
                            {
                                txttenDV.Text = arv["donvi"].ToString();
                                txtdiachiDV.Text = arv["dcdonvi"].ToString();
                                txtTennguoinhan.Text = arv["nguoinhan"].ToString();
                                txtDiachinhan.Text = arv["dcnhan"].ToString();
                                txtMST.Text = arv["masothue"].ToString();
                                txtngayhen.Text = arv["ngayhen"].ToString();
                                txtkyhieu.Text = arv["sohieu"].ToString();
                                txtSBL1.Text = arv["sobienlai"].ToString();
                            }
                        }
                        else if (e == null && gHoadon.Tag.ToString() == "0" )
                        {
                            CurrencyManager mc = (CurrencyManager)BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember];
                            DataView dv = (DataView)mc.List;

                            for (int i = 0; i < dv.Table.Rows.Count; i++)
                            {
                                if (dv.Table.Rows[i]["chon"].ToString() == "1")
                                {
                                    txttenDV.Text = dv.Table.Rows[i]["donvi"].ToString();// dgDanhsach["cldonvi", i].Value.ToString();
                                    txtdiachiDV.Text = dv.Table.Rows[i]["dcdonvi"].ToString();
                                    txtTennguoinhan.Text = dv.Table.Rows[i]["nguoinhan"].ToString();
                                    txtDiachinhan.Text = dv.Table.Rows[i]["dcnhan"].ToString();
                                    txtMST.Text = dv.Table.Rows[i]["masothue"].ToString();
                                    txtngayhen.Text = dv.Table.Rows[i]["ngayhen"].ToString();
                                    txtkyhieu.Text = dv.Table.Rows[i]["sohieu"].ToString();
                                    txtSBL1.Text = dv.Table.Rows[i]["sobienlai"].ToString();
                                    m_id = dv.Table.Rows[i]["id"].ToString();
                                    m_ngaythu = dv.Table.Rows[i]["ngay"].ToString();
                                    m_mabn = dv.Table.Rows[i]["mabn"].ToString();
                                    m_mavaovien = dv.Table.Rows[i]["mavaovien"].ToString();
                                    break;
                                }


                            }
                            //for (int i = 0; i < dgDanhsach.RowCount; i++)
                            //{
                            //    if (dgDanhsach[0, i].Value.ToString() == "1")
                            //    {
                            //        txttenDV.Text = dgDanhsach["cldonvi", i].Value.ToString();
                            //        txtdiachiDV.Text = dgDanhsach["clDiachidv", i].Value.ToString();
                            //        txtTennguoinhan.Text = dgDanhsach["clnguoinhan", i].Value.ToString();
                            //        txtDiachinhan.Text = dgDanhsach["cldiachinhan", i].Value.ToString();
                            //        txtMST.Text = dgDanhsach["clmst", i].Value.ToString();
                            //        txtngayhen.Text = dgDanhsach["clngayhen", i].Value.ToString();
                            //        m_id = dgDanhsach["id", i].Value.ToString();
                            //        m_ngaythu = dgDanhsach["clngay", i].Value.ToString();
                            //        m_mabn = dgDanhsach["clmabn", i].Value.ToString();
                            //        m_mavaovien = dgDanhsach["clmavaovien", i].Value.ToString();
                            //        break;
                            //    }
                            //}
                        }
                        else if (gHoadon.Tag.ToString() == "1" || gHoadon.Tag.ToString() == "2")
                        {
                            DataRowView arv = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
                            txttenDV.Text = arv["donvi"].ToString();
                            txtdiachiDV.Text = arv["dcdonvi"].ToString();
                            txtTennguoinhan.Text = arv["nguoinhan"].ToString();
                            txtDiachinhan.Text = arv["dcnhan"].ToString();
                            txtMST.Text = arv["masothue"].ToString();
                            txtngayhen.Text = arv["ngayhen"].ToString();
                            txtkyhieu.Text = arv["sohieu"].ToString();
                            txtSBL1.Text = arv["sobienlai"].ToString();
                            m_id = (arv["id"].ToString() != "") ? arv["id"].ToString() : "0";
                            m_ngaythu = arv["ngay"].ToString();
                            m_mabn = arv["mabn"].ToString();
                            m_mavaovien = arv["mavaovien"].ToString();

                        }

                    }
                    catch (Exception ex)
                    {
                        m_mavaovien = "";
                        m_id = "0";
                        m_ngaythu = "";
                        m_mabn = "";
                    }

                    
                    switch (gHoadon.Tag.ToString())
                    {
                        case "1":
                            if (m_ngaythu == "")
                            {
                                m_ngaythu = DateTime.Today.ToString("dd/MM/yyyy", null);
                            }
                            f_Load_Hoadon_thutructiep(m_id, m_v.get_mmyy(m_ngaythu), m_mabn, m_ngaythu.Substring(0, 10));
                            dgDanhsachthu.Visible = true;
                            dgHoadon_bhyt.Visible = false;
                            dgHoadon_noitru.Visible = false;
                            break;
                        case "2":
                            
                            if (m_ngaythu != "" && gIn.Tag.ToString() == "0")
                                f_Load_Hoadon_thuroi_BHYT(m_id, m_v.get_mmyy(m_ngaythu), m_mabn, m_ngaythu, m_mavaovien);
                            else if (m_ngaythu != "" && gIn.Tag.ToString() != "0")
                            {
                                f_Load_Hoadon_Duyet();
                            }
                            else
                            {
                                sql = "select to_number(0) as chon,'' as mabn,'' as mavaovien,0 as maql,0 as loaiba,'' as ngaythu,'' as makp,";
                                sql += " '' as mabs,'' as maicd,'' as chandoan,'' as sothe,'' as maphu,'' as mabv,'' as quyenso,0 as sobienlai,'' as ma,'' as ten,'' as dvt,";
                                sql += " 0 as soluong,0 as dongia,0 as sotien,0 as bhyttra, 0 as bntra,'' as mavp,0 as tamung,0 as madoituong,0 as traituyen ";
                                m_dshoadon = m_v.get_data(sql);
                                dgHoadon_bhyt.DataSource = m_dshoadon.Tables[0];
                            }
                            dgDanhsachthu.Visible = false;
                            dgHoadon_bhyt.Visible = true;
                            dgHoadon_noitru.Visible = false;
                            break;
                        case "3":
                    //        if (m_ngaythu != "")
                    //            f_Load_Hoadon_noitru_chitiet(m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)));
                    //        else
                    //        {

                    //            sql = "select to_number(0) as chon,'' as mabn,'' as mavaovien,0 as maql,0 as idkhoa,0 as idtonghop,0 as mien,0 as bhyt,0 as thieu,0 as tamung,0 as nopthem,0  as chenhlech1,'' as lydo,'' as maduyet,'' as ngaythu,'' as ngayra, '' as makpra,0 as quyenso,0 as sobienlai,0 as loai,0 as loaibn,'' as ngay,'' as ma,'' as ten,'' as dvt,0 as soluong,0 as dongia,0 as giamua,0 as vat,0 as vattu,0 as sotien,0 as bhyttra, 0 as miendt, 0 as chenhlech, 0 as bntra,0 as doituong,'' as tenkp,'' as madoituong,'' as makp,0 as mavp ";
                    //            m_dshoadon = m_v.get_data(sql);
                    //            dgHoadon_noitru.DataSource=  m_dshoadon.Tables[0];
                    //        }
                    //        dgDanhsachthu.Visible = false;
                    //        dgHoadon_bhyt.Visible = false;
                    //        dgHoadon_noitru.Visible = true;
                    //        break;
                            if (m_ngaythu != "" && gIn.Tag.ToString() == "0")
                                f_Load_Hoadon_thuroi_BHYT(m_id, m_v.get_mmyy(m_ngaythu), m_mabn, m_ngaythu, m_mavaovien);
                            else if (m_ngaythu != "" && gIn.Tag.ToString() != "0")
                            {
                                f_Load_Hoadon_Duyet();
                            }
                            else
                            {
                                sql = "select to_number(0) as chon,'' as mabn,'' as mavaovien,0 as maql,0 as loaiba,'' as ngaythu,'' as makp,";
                                sql += " '' as mabs,'' as maicd,'' as chandoan,'' as sothe,'' as maphu,'' as mabv,'' as quyenso,0 as sobienlai,'' as ma,'' as ten,'' as dvt,";
                                sql += " 0 as soluong,0 as dongia,0 as sotien,0 as bhyttra, 0 as bntra,'' as mavp,0 as tamung,0 as madoituong,0 as traituyen ";
                                m_dshoadon = m_v.get_data(sql);
                                dgHoadon_bhyt.DataSource = m_dshoadon.Tables[0];
                            }
                            dgDanhsachthu.Visible = false;
                            dgHoadon_bhyt.Visible = true;
                            dgHoadon_noitru.Visible = false;
                            break;
                    }
                }
                catch
                {
                }
           // }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
                // gam 14-07-2011
            if (dgDanhsach.RowCount == 0)
                return;
            //if (gHoadon.Tag.ToString() == "2" && v_UserDuyet == false && gIn.Tag.ToString() == "0")
            if ( v_UserDuyet == false && gIn.Tag.ToString() == "0")
                // nếu user in là user tổng hợp biên lai và đang trạng thái tổng hợp thì lưu vào table v_bienlaitaichinhll và v_bienlaitaichinhct
                // nếu biên lai có thuốc và cls thì tách làm 2 biên lai
            {
                if (!kiemTra())
                    return;  
                CurrencyManager mc = (CurrencyManager)BindingContext[dgHoadon_bhyt.DataSource, dgHoadon_bhyt.DataMember];
                DataView ds = (DataView)mc.List;
                if (ds.Table.Select("cls=1 and chon=1").Length > 0)
                {
                    f_Luu(ds.Table.Select("cls=1 and chon=1"));
                }
                if (ds.Table.Select("cls=0 and chon=1").Length > 0)
                {
                    decimal dec = decimal.Parse(m_idhddt) * -1;
                    m_idhddt= dec.ToString();
                    f_Luu(ds.Table.Select("cls=0 and chon=1"));
                }
                f_in_phieuyeucauHD();
                f_Load_DG_BHYT_NGT();

            }
            //else if (gHoadon.Tag.ToString() == "2" && v_UserDuyet == false && gIn.Tag.ToString() == "1")
            else if (v_UserDuyet == false && gIn.Tag.ToString() == "1")
            {// nếu user lưu là user tổng hợp và bấm nút lưu ở trạng thái chờ duyệt thì in lại phiếu miễn và chi tiết hóa đơn
                m_frmprinthd.f_Print_Bienlaitaichinh_chitiet(!chkIN.Checked, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)));
                f_in_phieuyeucauHD();
            }
            else if (gHoadon.Tag.ToString() == "2" && v_UserDuyet == true && gIn.Tag.ToString() == "1")
            {
                // nếu user lưu là user duyệt và trạng thái chờ duyệt thì duyệt và in hóa đơn đỏ
                if (!kiemTra())
                    return;  
                CurrencyManager mc = (CurrencyManager)BindingContext[dgHoadon_bhyt.DataSource, dgHoadon_bhyt.DataMember];
                DataView ds = (DataView)mc.List;
                f_Luu(ds.Table.Select("true"));
                f_Load_DG_BHYT_NGT_Duyet();
            }
            

        }
        private bool kiemTra()
        {
            if (dgHoadon_bhyt.DataSource == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng chọn danh sách bệnh nhân để in."), m_v.s_AppName);
                return false;
            }
            if (txtngayhoadon.Text == "" || txtngayhoadon.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập ngày hóa đơn."), m_v.s_AppName);
                txtngayhoadon.Focus();
                return false;
            }
            if (txtngayhen.Text == "  /  /" || txtngayhen.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập ngày hẹn."), m_v.s_AppName);
                txtngayhen.Focus();
                return false;
            }
            else
            {
                DateTime dt1, dt2;
                try
                {
                    dt1 = Convert.ToDateTime(txtngayhoadon.Text.Substring(3, 3) + txtngayhoadon.Text.Substring(0, 3) + txtngayhoadon.Text.Substring(6, 4) + " 00:00");
                }
                catch { 
                    MessageBox.Show("Ngày hóa đơn không hợp lệ. "); 
                    txtngayhoadon.Focus();
                    txtngayhoadon.SelectAll();
                    return false; }
                try
                {
                    dt2 = Convert.ToDateTime(txtngayhen.Text.Substring(3, 3) + txtngayhen.Text.Substring(0, 3) + txtngayhen.Text.Substring(6, 4) + " 00:00");
                }
                catch { 
                    MessageBox.Show("Ngày hẹn không hợp lệ. "); 
                    txtngayhen.Focus();
                    txtngayhen.SelectAll();
                    return false; }
                if (dt2 < dt1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày hẹn không được nhỏ hơn ngày hóa đơn."), m_v.s_AppName);
                    txtngayhen.Focus();
                    txtngayhen.SelectAll();
                    return false;
                }
            }

            if (txttenDV.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập tên đơn vị."), m_v.s_AppName);
                txttenDV.Focus();
                return false;
            }
            if (txtDiachinhan.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập địa chỉ nhận."), m_v.s_AppName);
                txtDiachinhan.Focus();
                return false;
            }
            if (txtTennguoinhan.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập tên người nhận."), m_v.s_AppName);
                txtTennguoinhan.Focus();
                return false;
            }         
            
            if (gIn.Tag.ToString() == "1")
            {
                if (txtkyhieu.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập ký hiệu."), m_v.s_AppName);
                    txtkyhieu.Focus();
                    return false;
                }
                if (txtSBL1.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập số biên lai."), m_v.s_AppName);
                    txtSBL1.Focus();
                    return false;
                }
                if (m_v.get_data("select * from medibv.v_bienlaitaichinhhuy where upper(quyenso) = '"+txtkyhieu.Text.Trim().ToUpper()+"' and sobienlai="+txtSBL1.Text.Trim()).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText(" Quyển sổ:" + txtkyhieu.Text.Trim() + ",số biên lai:" + txtSBL1.Text.Trim() + " đã hủy"), m_v.s_AppName);
                    txtkyhieu.Focus();
                    return false;
                }
            }
            return true;
        }
        private void f_Luu( DataRow [] drChitiet)
        {
            try
            {
                          
                string aid = "0", mmyy = "",v_id="";
                mmyy = m_v.get_mmyy(txtNgaythu.Text);
               
                decimal asotien = 0,abntra=0,abhyttra=0,amien=0;
                foreach (DataRow r in drChitiet)
                {
                    asotien += decimal.Parse(r["sotien"].ToString() == "" ? "0" : r["sotien"].ToString());
                    abntra += decimal.Parse(r["bntra"].ToString() == "" ? "0" : r["bntra"].ToString());
                    abhyttra += decimal.Parse(r["bntra"].ToString() == "" ? "0" : r["bhyttra"].ToString());
                    amien += decimal.Parse(r["mien"].ToString() == "" ? "0" : r["mien"].ToString());
                }

                if (gIn.Tag.ToString() == "1")
                    aid = m_id;
                if (gIn.Tag.ToString() == "0" && m_idhddt != "")
                    aid = m_idhddt;
                aid = m_v.upd_v_bienlaitaichinhll(mmyy,decimal.Parse(aid), txtkyhieu.Text.Trim(), txtSBL1.Text.Trim(), 
                    txtngayhoadon.Text, txtnoidung.Text, txttenDV.Text, txtMST.Text, txtSTK.Text, txtdiachiDV.Text,
                    asotien, decimal.Parse(txtGTGT.Text), 0, 0, 
                    decimal.Parse(v_userid),txtTennguoinhan.Text,txtDiachinhan.Text,0,"",
                    int.Parse(gHoadon.Tag.ToString()), traituyen, decimal.Parse(toolStrip_Tamung.ToString()),
                    (txtngayhen.Text.Length >= 10 ? txtngayhen.Text.Substring(0, 10) : txtngayhoadon.Text),
                    decimal.Parse(toolStrip_Mien.ToString()), abhyttra);
                m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_bienlaitaichinhll set mavaovien='"+m_mavaovien+"',hdcls="+drChitiet[0]["cls"].ToString()+" where id=" + aid);
                if (gIn.Tag.ToString() == "1")
                    m_v.execute_data_mmyy(mmyy,"update medibvmmyy.v_bienlaitaichinhll set done=1,quyenso='"+txtkyhieu.Text.Trim()+"',sobienlai='"+txtSBL1.Text.Trim()+"' where id="+aid);
                m_idhddt = aid;
                if (m_idhddt != "0")
                {
                    decimal astt = 1;
                    switch (gHoadon.Tag.ToString())
                    {
                        case "1":
                            CurrencyManager mc1 = (CurrencyManager)BindingContext[dgDanhsachthu.DataSource, dgDanhsachthu.DataMember];
                            DataView dv1 = (DataView)mc1.List;
                            foreach (DataRow r in drChitiet)
                            {

                               // m_v.upd_v_bienlaitaichinhct(mmyy, decimal.Parse(m_idhddt), astt, m_mabn, "", decimal.Parse(r["thanhtien"].ToString()), 0, 0, 0, 1, 1, "");//r["idvienphi"].ToString()
                                astt += 1;

                            }
                            break;
                        case "2":
                            CurrencyManager mc0 = (CurrencyManager)BindingContext[dgHoadon_bhyt.DataSource, dgHoadon_bhyt.DataMember];
                            DataView dv0 = (DataView)mc0.List;
                            string amabn = "";
                            foreach (DataRow r in drChitiet)
                            {
                                m_v.upd_v_bienlaitaichinhct(mmyy, decimal.Parse(m_idhddt), astt, m_mabn, "", decimal.Parse(r["sotien"].ToString()),
                                    decimal.Parse(r["bhyttra"].ToString()), 0, 0, 1, 2,r["id"].ToString(), decimal.Parse(r["soluong"].ToString()),
                                    decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vat"].ToString() == "" ? "0" : r["vat"].ToString()), 
                                    decimal.Parse(r["sotien"].ToString()),decimal.Parse(r["mavp"].ToString()),decimal.Parse(r["madoituong"].ToString()));//r["idvienphi"].ToString()
                                amabn = r["mabn"].ToString();
                                if (v_id.IndexOf(r["id"].ToString() + ",") < 0)
                                    v_id += r["id"].ToString() + ",";
                                astt += 1;
                                if(gIn.Tag.ToString() == "0" && r["ttrv"].ToString() == "1")
                                    m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvct set hoadondo=" + m_idhddt + ",vat=" + r["vat"].ToString() + " where id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                                else if(gIn.Tag.ToString() == "0")
                                    m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_vienphict set hoadondo=" + m_idhddt + ",vat=" + r["vat"].ToString() + " where id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                            }
                            if(amabn != "")
                                m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_bienlaitaichinhll set mabn=" + amabn + " where id=" + m_idhddt );
                            break;
                        case "3":
                           
                            //CurrencyManager mc2 = (CurrencyManager)BindingContext[dgHoadon_noitru.DataSource, dgHoadon_noitru.DataMember];
                            //DataView dv2 = (DataView)mc2.List;
                            //foreach (DataRow r in dv2.Table.Rows)
                            //{
                            //   // m_v.upd_v_bienlaitaichinhct(mmyy, decimal.Parse(m_idhddt), astt, m_mabn, "", decimal.Parse(r["sotien"].ToString()), decimal.Parse(r["bhyttra"].ToString()), 0, 0, 1, 3, "");//r["idvienphi"].ToString()
                            //    astt += 1;

                            //}
                            //break;
                            //CurrencyManager mc2 = (CurrencyManager)BindingContext[dgHoadon_bhyt.DataSource, dgHoadon_bhyt.DataMember];
                            //DataView dv2 = (DataView)mc0.List;
                            string amabn1 = "";
                            foreach (DataRow r in drChitiet)
                            {
                                m_v.upd_v_bienlaitaichinhct(mmyy, decimal.Parse(m_idhddt), astt, m_mabn, "", decimal.Parse(r["sotien"].ToString()),
                                    decimal.Parse(r["bhyttra"].ToString()), 0, 0, 1, 2, r["id"].ToString(), decimal.Parse(r["soluong"].ToString()),
                                    decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vat"].ToString() == "" ? "0" : r["vat"].ToString()),
                                    decimal.Parse(r["sotien"].ToString()), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["madoituong"].ToString()));//r["idvienphi"].ToString()
                                amabn = r["mabn"].ToString();
                                if (v_id.IndexOf(r["id"].ToString() + ",") < 0 && r["ttrv"].ToString() == "1")
                                    v_id += r["id"].ToString() + ",";
                                else if(aid.IndexOf(r["id"].ToString() + ",") < 0 && r["ttrv"].ToString() == "0")
                                    aid +=  r["id"].ToString() + ",";
                                astt += 1;
                                if (gIn.Tag.ToString() == "0" && r["ttrv"].ToString() == "1")
                                    m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvct set hoadondo=" + m_idhddt + ",vat=" + r["vat"].ToString() + " where id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                                else if (gIn.Tag.ToString() == "0" && r["ttrv"].ToString() == "0")
                                    m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_vienphict set hoadondo=" + m_idhddt + ",vat=" + r["vat"].ToString() + " where id=" + r["id"].ToString() + " and stt=" + r["stt"].ToString());
                            }
                            if (amabn1 != "")
                                m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_bienlaitaichinhll set mabn=" + amabn1 + " where id=" + m_idhddt);
                            break;
                    }
                }
                if (m_idhddt == "0")
                {
                    f_Enable(true);
                    MessageBox.Show(lan.Change_language_MessageText("Lỗi dữ liệu"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //f_Enable(false);
                    switch (gHoadon.Tag.ToString())
                    {
                        case "1":
                            m_v.execute_data("update medibv" + mmyy + ".v_vienphill set hddt=1 where mabn='" + m_mabn + "'");
                            toolStrip2.Hide();
                            break;
                        case "2":
                            if (gIn.Tag.ToString() == "0")
                            {
                                m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvll set hddt=1 where id in (" + v_id.Trim(',') + ")");
                            }
                            break;
                        case "3":
                            //m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvll set hddt=1 where id=" + m_id);
                            //f_Load_DG_noitru();
                            //toolStrip2.Hide();
                            if (gIn.Tag.ToString() == "0" && v_id != "")
                            {
                                m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvll set hddt=1 where id in (" + v_id.Trim(',') + ")");
                            }
                            if (gIn.Tag.ToString() == "0" && aid != "")
                            {
                                m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_vienphill set hddt=1 where id in (" + aid.Trim(',') + ")");
                            }
                            break;
                    }
                    if (gIn.Tag.ToString() == "0")
                    {
                        m_frmprinthd.f_Print_Bienlaitaichinh_chitiet(!chkIN.Checked, m_idhddt, m_v.get_mmyy(m_ngaythu.Substring(0, 10)));
                    }
                    else if(gIn.Tag.ToString() == "1")
                    {
                        m_frmprinthd.f_Print_Bienlaitaichinh_1(!chkIN.Checked, m_idhddt, m_v.get_mmyy(m_ngaythu.Substring(0, 10)));
                    }
                }
                //
                
                //
                //txtkyhieu.Text = "";
                //txtSBL.Text = "";
                //txtngayhoadon.Text = "";
                //txtnoidung.Text = "";
                //txttenDV.Text = "";
                //txtdiachiDV.Text = "";
                //txtSTK.Text = "";
                //txtMST.Text = "";
                //txtGTGT.Text = "0";
                //txtngayhoadon.Text = DateTime.Now.ToString("dd/MM/yyyy",null);
                //
                //
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        private string get_id_yeucauhoadon()
        {
            string v_id = "", mmyy = "";
            mmyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
            v_id = m_v.get_data("select max(id) from medibv.yeucauhoadon").Tables[0].Rows[0][0].ToString();
            v_id = mmyy + v_id.PadLeft(6,'0');
            return v_id;

        }

        private void butDanhsachthu_Click(object sender, EventArgs e)
        {
            try
            {       
                if (m_danhsachthu.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_danhsachthu.id_bienlai != "")
                    {
                        f_Enable_hc(false);
                        f_Load_HD(m_danhsachthu.id_bienlai.Trim(','));
                        m_idhddt = m_danhsachthu.id_bienlai;
                        foreach (DataRow r in m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text), "select quyenso,sobienlai,to_char(ngayhd,'dd/mm/yyyy') as ngayhd,tendv,diachi,sotaikhoan,masothue,vat,noidung from medibvmmyy.v_bienlaitaichinhll where id=" + m_idhddt + "").Tables[0].Rows)
                        {
                            txtkyhieu.Text = r["quyenso"].ToString();
                            txtSBL1.Text = r["sobienlai"].ToString();
                            txtngayhoadon.Text = r["ngayhd"].ToString();
                            txtnoidung.Text = r["noidung"].ToString();
                            txttenDV.Text = r["tendv"].ToString();
                            txtdiachiDV.Text = r["diachi"].ToString();
                            txtSTK.Text = r["sotaikhoan"].ToString();
                            txtMST.Text = r["masothue"].ToString();
                            txtGTGT.Text = r["vat"].ToString();
                        }
                       // f_Enable(true);
                        butMoi.Enabled = true;
                        butLuu.Enabled = false;
                        butKetthuc.Enabled = true;
                        butSua.Enabled = true;
                    }
                    
                }
            }
            catch//(Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_HD(string s_id)
        {
            ads1 = m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text), "select 1 as chon,b.mabn,b.hoten,namsinh,decode(phai,'1','nam','nữ') as phai,chiphi,mien,idvienphi,sonha||' '||thon||' '||e.tenpxa||' '||tenquan||' '||tentt as diachi from medibvmmyy.v_bienlaitaichinhct a inner join medibv.btdbn b on a.mabn=b.mabn inner join medibv.btdtt c on b.matt=c.matt inner join medibv.btdquan d on b.maqu=d.maqu inner join medibv.btdpxa e on b.maphuongxa=e.maphuongxa where a.id=" + s_id + "");
            dgDanhsachthu.DataSource = ads1.Tables[0];
        }
        private void butInhoadon_Click(object sender, EventArgs e)
        {
            //m_frmprinthd.f_Print_Bienlaitaichinh(!chkIN.Checked,m_id, m_v.get_mmyy(txtNgaythu.Text));
            if (m_id == "") return;
            switch( gHoadon.Tag.ToString())
            {
                case "1":
                    m_frmprinthd.f_Print_BienlaiKB_hdtc(!chkIN.Checked, m_id, m_mabn, m_ngaythu.Substring(0, 10), m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1", "v_bienlaithuvienphi_HDTC.rpt", "", txtkyhieu.Text, txtSBL1.Text, txttenDV.Text, txtMST.Text, txtGTGT.Text);
                    break;
                case "2":
                    //m_frmprinthd.f_Print_BienlaiNGT_HDTC(!chkIN.Checked, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1", m_mabn, m_ngaythu.Substring(0, 10), m_sothe, cmbTraituyen.SelectedIndex, decimal.Parse(toolStrip_Tongcong.Text), txtkyhieu.Text, txtSBL.Text, txttenDV.Text, txtMST.Text, txtGTGT.Text);
                    break;
                case "3":
                    m_frmprinthd.f_Print_Bienlai_ThuongNT_HDTC(!chkIN.Checked, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1", txtkyhieu.Text, txtSBL1.Text, txttenDV.Text, txtMST.Text, txtGTGT.Text);                    
                    break;
            }
        }
        private void f_in_phieuyeucauHD()
        {
            try
            {
                string sql = "", aReport = "rptYeucauhoadon.rpt", mmyy = "", atenbn = "", v_id="",asotien="";
                DataSet ads = new DataSet();
                mmyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                DataRowView arv = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
                v_id = arv["id"].ToString();
                if (m_idhddt == "" && gIn.Tag.ToString() == "0")///if (v_id == "")
                    return;
                else if (m_idhddt != "" && gIn.Tag.ToString() == "0") 
                    v_id = m_idhddt;
                

                sql = "select b.hoten,a.mabn,a.tendv as donvi,a.diachi as dcdonvi,a.masothue,a.dcnhan,a.nguoinhan,a.sotien,to_char(a.ngayhen,'dd/mm/yyyy') as ngay,0 as mavaovien ";
                sql += "from medibvmmyy.v_bienlaitaichinhll a inner join medibv.btdbn b on a.mabn=b.mabn where id=" + v_id;

                ads = m_v.get_data_mmyy(mmyy, sql);
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy chứng từ ") + v_id + ". ");
                }
                else
                {
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy report ") + aReport + ".");
                        return;
                    }

                    atenbn = ads.Tables[0].Rows[0]["hoten"].ToString();
                    asotien = ads.Tables[0].Rows[0]["sotien"].ToString();

                    ads.WriteXml("..\\..\\Datareport\\rptYeucauhoadon.xml", XmlWriteMode.WriteSchema);

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
                    crystalReportViewer1.BringToFront();
                    crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                    ReportDocument cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.SetDataSource(ads);

                    cMain.DataDefinition.FormulaFields["c1"].Text = "'" + atenbn + "'";

                    cMain.DataDefinition.FormulaFields["c2"].Text = "'" + Math.Round(decimal.Parse(asotien == "" ? "0" : asotien)) + "'";
                    cMain.DataDefinition.FormulaFields["ngayin"].Text = "'ngày " + txtNgaythu.Text.Substring(0,2) + " tháng "+txtNgaythu.Text.Substring(3,2) + " năm " + txtNgaythu.Text.Substring(6,4) + "'";
                    if (chkIN.Checked)
                    {
                        cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                        //cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        crystalReportViewer1.ReportSource = cMain;
                        af.Text = "In phiếu miễn ";
                        af.Text = af.Text + " (" + aReport + ")";
                        af.ShowDialog();
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                }
            }
            catch { }



        }
        private void f_Enable(bool v_bool)
        {
            try
            {
                butMoi.Enabled = !v_bool;
                butLuu.Enabled = v_bool;
                //butInhoadon.Enabled = m_id != "" && m_id != "0";                
                butSua.Enabled = !v_bool && m_id != "" && m_id != "0";
                //butXoa.Enabled = !v_bool && m_id != "" && m_id != "0";
                butBoqua.Enabled = true;                
                //butKetthuc.Enabled = !v_bool;
            }
            catch
            {
            }
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            //f_Moi();
        }
        private void f_Moi()
        {
            f_Enable_hc(false);
           // f_Load_DG();
            if (dgDanhsachthu.DataSource != null)
            {
              //  ads1.Tables[0].Rows.Clear();
            }
            f_Enable(true);
            dgDanhsachthu.ReadOnly = false;
            txtkyhieu.Text = "";
            txtSBL1.Text = "";
            txtngayhoadon.Text = "";
            txtnoidung.Text = "";
            //txttenDV.Text = "";
            //txtdiachiDV.Text = "";
            txtSTK.Text = "";
            //txtMST.Text = "";
            txtGTGT.Text = "0";
            m_idhddt = "";
            txtngayhoadon.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void f_Enable_hc(bool bo)
        {
            txtkyhieu.Enabled = !bo;
            txtSBL1.Enabled = !bo;
            txtngayhoadon.Enabled = !bo;
            txtnoidung.Enabled = !bo;
            txttenDV.Enabled = !bo;
            txtdiachiDV.Enabled = !bo;
            txtSTK.Enabled = !bo;
            txtMST.Enabled = !bo;
            txtGTGT.Enabled = false;
            txtTennguoinhan.Enabled = !bo;
            txtDiachinhan.Enabled = !bo;
            txtngayhen.Enabled = !bo;
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            try
            {

                f_Enable_hc(false);
                dgDanhsachthu.ReadOnly = true;
                dgDanhsach.Enabled= true;
                butMoi.Enabled = true;
                butLuu.Enabled = true;
                butKetthuc.Enabled = true;
            }
            catch
            {
 
            }
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgDanhsach.RowCount == 0)
                    return;
                string mmyy = "", aid = ""; //sql = "", 
                DataRowView arv = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
                aid = arv["id"].ToString();
                mmyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                if ( gIn.Tag.ToString()== "1" && m_v.get_data("select * from medibv.v_bienlaitaichinhhuy where idbienlai=" + aid).Tables[0].Rows.Count > 0 )
                {
                    MessageBox.Show(lan.Change_language_MessageText(" Số liệu đã cập nhật, không cho phép hủy. "), m_v.s_AppName);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn hủy biên lai này không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    if (!v_UserDuyet)
                    {
                        
                        if (m_v.get_data("select * from medibv.yeucauhoadon where mavaovien='" + arv["mavaovien"].ToString()
                            + "' and mabn='" + arv["mabn"].ToString() + "'").Tables[0].Rows.Count == 0)
                        {
                            m.upd_yeucauhoadon(arv["mabn"].ToString(), decimal.Parse(arv["mavaovien"].ToString()), arv["ngayhen"].ToString(),
                                arv["donvi"].ToString(), arv["dcdonvi"].ToString(), arv["masothue"].ToString(), arv["dcnhan"].ToString(),
                                arv["nguoinhan"].ToString(), int.Parse(v_userid), 0);
                        }
                        m_v.execute_data_mmyy(mmyy, "delete from medibvmmyy.v_bienlaitaichinhct where id=" + aid);
                        m_v.execute_data_mmyy(mmyy, "delete from medibvmmyy.v_bienlaitaichinhll where id=" + aid);
                        m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvll set hddt=0 where id in (select id from medibvmmyy.v_ttrvct where hoadondo=" + aid + ")");
                        m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvct set hoadondo=0 where hoadondo=" + aid);
                        decimal s_id = decimal.Parse(aid) * -1;
                        aid = s_id.ToString();
                        m_v.execute_data_mmyy(mmyy, "delete from medibvmmyy.v_bienlaitaichinhct where id=" + aid);
                        m_v.execute_data_mmyy(mmyy, "delete from medibvmmyy.v_bienlaitaichinhll where id=" + aid);
                        m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvll set hddt=0 where id in (select id from medibvmmyy.v_ttrvct where hoadondo=" + aid + ")");
                        m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_ttrvct set hoadondo=0 where hoadondo=" + aid);
                    }
                    else
                    {
                        decimal v_idbienlai = f_get_id_bienlaitaichinhhuy();
                        m_v.upd_bienlaitaichinhhuy(v_idbienlai, arv["ngay"].ToString(), arv["sohieu"].ToString(), decimal.Parse(arv["sobienlai"].ToString() == "" ? "0" : arv["sobienlai"].ToString()), int.Parse(v_userid), decimal.Parse(aid == "" ? "0" : aid));
                        m_v.execute_data_mmyy(mmyy, "update medibvmmyy.v_bienlaitaichinhll set done=0,quyenso='',sobienlai='' where id=" + aid);
                    }
                }
                else
                {
                    return;
                }
                MessageBox.Show("Xóa dữ liệu thành công.");
                
            }
            catch
            {
                MessageBox.Show("Lỗi khi xóa được dữ liệu.");
            }
            butTonghop_Click(null,null);
        }
        private decimal f_get_id_bienlaitaichinhhuy()
        {
            decimal v_id = 0;
            try
            {
                v_id = decimal.Parse(m_v.get_data("select max(id)+1 as id from medibv.v_bienlaitaichinhhuy").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                v_id = 1;
            }
            return v_id;
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            butLuu.Enabled = true;
            butMoi.Enabled = true;
            butKetthuc.Enabled = true;
        }

        private void txttinnhanh_Leave(object sender, EventArgs e)
        {
            //txttinnhanh.Text = "Tìm kiếm";
        }

        private void optTructiep_CheckedChanged(object sender, EventArgs e)
        {
            if (optTructiep.Checked == true)
            {
                gHoadon.Tag = "1";
                butTonghop_Click(null, null);
            }
        }

        private void optBHYT_CheckedChanged(object sender, EventArgs e)
        {
            if (optBHYT.Checked == true)
            {
                gHoadon.Tag = "2";
                butTonghop_Click(null, null);
            }
        }

        private void optNoitru_CheckedChanged(object sender, EventArgs e)
        {
            if (optNoitru.Checked == true)
            {
                gHoadon.Tag = "3";                
                butTonghop_Click(null, null);
                
            }
        }
        private void f_Load_Hoadon_noitru_chitiet(string v_id, string v_mmyy)
        {
            f_Load_Hoadon_thuroi_BHYT("", "", "", "", "");
            //try
            //{
            //    if (v_id == "") return;
            //    v_id = decimal.Parse(v_id).ToString();
            //    string sql = "", ammyy = "", sql1 = "";
            //    ammyy = v_mmyy;
            //    if (ammyy == "") ammyy = m_v.get_mmyy(m_ngaythu.Substring(0, 10));

            //    sql = "select to_number(1) as chon,a.id,a1.mabn,a1.mavaovien,a1.maql,a1.idkhoa,idtonghop,a.mien,a.bhyt,a.thieu,a.tamung,a.nopthem,a.chenhlech as chenhlech1,b2.lydo,b2.maduyet,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngaythu,to_char(a1.ngayra,'dd/mm/yyyy hh24:mi') as ngayra, a.makp as makpra,a.quyenso,a.sobienlai,a.loai,a.loaibn,to_char(b.ngay,'dd/mm/yyyy') as ngay,c.ma,c.ten,c.dvt,b.soluong,b.dongia,b.giamua,b.vat,b.vattu,(b.soluong*b.dongia + b.soluong*b.dongia*vat/100) as sotien,0 as bhyttra, 0 as miendt, 0 as chenhlech, 0 as bntra,d.doituong,e.tenkp,b.madoituong,b.makp,b.mavp,thua,a1.chandoan,a1.maicd,to_number(1) as onpaid ";//binh sua lay ngay thu: lay them gioi ra
            //    sql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru b2 on a.id=b2.id left join (select id,ma,ten,dvt from medibv.v_giavp union select d0.id,d0.ma,d0.ten, d0.dang as dvt from medibv.d_dmbd d0 inner join medibv.d_dmnhom d1 on d0.manhom=d1.id where d1.nhom=1) c on b.mavp=c.id left join medibv.doituong d on b.madoituong=d.madoituong left join medibv.btdkp_bv e on b.makp=e.makp where a.id = " + v_id;

            //    DataSet ads = m_v.get_data_mmyy(ammyy, sql);
            //    sql1 = "select id, sothe, maphu, to_char(tungay,'dd/mm/yyyy') as tungay, to_char(ngay,'dd/mm/yyyy') as ngay, mabv, noigioithieu,traituyen from  medibvmmyy.v_ttrvbhyt where id=" + v_id;
            //    DataSet ads1 = m_v.get_data_mmyy(ammyy, sql1);
            //    m_dshoadon_nhomvp = m_v.get_data_mmyy(ammyy, "select * from medibvmmyy.v_ttrvnhom where id=" + v_id);
            //    m_mavaovien = m_maql = m_idkhoa = m_id_thvpll = "";

            //    if (ads.Tables[0].Rows.Count > 0)
            //    {
            //        m_mavaovien = ads.Tables[0].Rows[0]["mavaovien"].ToString();
            //        m_maql = ads.Tables[0].Rows[0]["maql"].ToString();
            //        if (ads.Tables[0].Rows[0]["idkhoa"].ToString() != "" && ads.Tables[0].Rows[0]["idkhoa"].ToString() != "0")
            //            m_idkhoa = ads.Tables[0].Rows[0]["idkhoa"].ToString();

            //        if (ads.Tables[0].Rows[0]["idtonghop"].ToString() != "" && ads.Tables[0].Rows[0]["idtonghop"].ToString() != "0")
            //            m_id_thvpll = ads.Tables[0].Rows[0]["idtonghop"].ToString();

                    //txtMabn.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(0, 2);
                    //txtMabn1.Text = ads.Tables[0].Rows[0]["mabn"].ToString().Substring(2);
                    //txtMabn1_Validated(null, null);

                    //try
                    //{
                    //    cbNgayvv.SelectedValue = ads.Tables[0].Rows[0]["maql"].ToString();
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    cbLoaidv.SelectedValue = ads.Tables[0].Rows[0]["loai"].ToString();
                    //    cbLoaidv_Validated(null, null);
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    cbKyhieu.SelectedValue = ads.Tables[0].Rows[0]["quyenso"].ToString();
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    cbLoaibn.SelectedValue = ads.Tables[0].Rows[0]["loaibn"].ToString();
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    cbKhoarv.SelectedValue = ads.Tables[0].Rows[0]["makpra"].ToString();
                    //    txtKhoarv.Text = ads.Tables[0].Rows[0]["makpra"].ToString();
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    cbLydomien.SelectedValue = ads.Tables[0].Rows[0]["lydo"].ToString();
                    //    txtLydomien.Text = ads.Tables[0].Rows[0]["lydo"].ToString();
                    //}
                    //catch
                    //{
                    //}
                    //try
                    //{
                    //    cbKymien.SelectedValue = ads.Tables[0].Rows[0]["maduyet"].ToString();
                    //    txtKymien.Text = ads.Tables[0].Rows[0]["maduyet"].ToString();
                    //}
                    //catch
                    //{
                    //}
                    //txtICD.Text = ads.Tables[0].Rows[0]["maicd"].ToString();
                    //txtChandoan.Text = ads.Tables[0].Rows[0]["chandoan"].ToString();
                    //txtSobienlai.Text = ads.Tables[0].Rows[0]["sobienlai"].ToString();
                    //txtNgaythu.Value = m_v.f_parse_date_16(ads.Tables[0].Rows[0]["ngaythu"].ToString());//binh doi ham lay ngay 10 ky tu thanh lay ngay 16 ky tu co gio
                    //txtNgayrv.Text = ads.Tables[0].Rows[0]["ngayra"].ToString();
                    //try
                    //{
                    //    cmbTraituyen.SelectedIndex = (ads1.Tables[0].Rows[0]["traituyen"].ToString().Trim() != "") ? int.Parse(ads1.Tables[0].Rows[0]["traituyen"].ToString()) : 0;
                    //    txtSothe.Text = ads1.Tables[0].Rows[0]["sothe"].ToString();
                    //    txtTN.Text = ads1.Tables[0].Rows[0]["tungay"].ToString().Substring(0, 10);
                    //    txtDN.Text = ads1.Tables[0].Rows[0]["ngay"].ToString().Substring(0, 10);
                    //    txtNDK_Ma.Text = ads1.Tables[0].Rows[0]["noigioithieu"].ToString();
                    //}
                    //catch { }
                    //try
                    //{
                    //    txtGDDuyet.Text = decimal.Parse(ads.Tables[0].Rows[0]["mien"].ToString()).ToString("###,###,##0.##");
                    //}
                    //catch
                    //{
                    //    txtGDDuyet.Text = "0";
                    //}
                    //try
                    //{
                    //    txtBNThieu.Text = decimal.Parse(ads.Tables[0].Rows[0]["thieu"].ToString()).ToString("###,###,##0.##");
                    //}
                    //catch
                    //{
                    //    txtBNThieu.Text = "0";
                    //}
                    //try
                    //{
                    //    txtTamung.Text = decimal.Parse(ads.Tables[0].Rows[0]["tamung"].ToString()).ToString("###,###,##0.##");
                    //}
                    //catch
                    //{
                    //    txtTamung.Text = "0";
                    //}
                    //try
                    //{
                    //    txtChenhlech.Text = decimal.Parse(ads.Tables[0].Rows[0]["chenhlech1"].ToString()).ToString("###,###,##0.##");
                    //}
                    //catch
                    //{
                    //    txtChenhlech.Text = "0";
                    //}
                    //try
                    //{
                    //    txtthua.Text = decimal.Parse(ads.Tables[0].Rows[0]["thua"].ToString()).ToString("###,###,##0.##");
                    //}
                    //catch
                    //{
                    //    txtthua.Text = "0";
                    //}
                    //try
                    //{
                    //    chkChuahoan.Checked = decimal.Parse(ads.Tables[0].Rows[0]["nopthem"].ToString()) > 0;
                    //    txtBNtraNO.Text = decimal.Parse(ads.Tables[0].Rows[0]["nopthem"].ToString()).ToString("###,###,##0.##");
                    //}
                    //catch
                    //{
                    //    chkChuahoan.Checked = false;
                    //    txtBNtraNO.Text = "0";
                    //}
                    //if (tmn_thanhtoantheokhoa.Checked || v_thanhtoannhieudot_trongkhoa)
                    //{
                    //    f_load_BC_Ngayrv(false);
                    //    try
                    //    {
                    //        cbNgayrv.SelectedValue = ads.Tables[0].Rows[0]["idtonghop"].ToString();
                    //    }
                    //    catch { }
                    //}
                    //ads.Tables[0].Columns.Remove("mabn");
                    //ads.Tables[0].Columns.Remove("mavaovien");
                    //ads.Tables[0].Columns.Remove("maql");
                    //ads.Tables[0].Columns.Remove("quyenso");
                    //ads.Tables[0].Columns.Remove("sobienlai");
                    //ads.Tables[0].Columns.Remove("loai");
                    //ads.Tables[0].Columns.Remove("loaibn");
                    //ads.Tables[0].Columns.Remove("ngaythu");
                    //ads.Tables[0].Columns.Remove("mien");
                    //ads.Tables[0].Columns.Remove("bhyt");
                    //ads.Tables[0].Columns.Remove("thieu");
                    //ads.Tables[0].Columns.Remove("nopthem");
                    //ads.Tables[0].Columns.Remove("tamung");
                    //ads.Tables[0].Columns.Remove("chenhlech1");
                    //ads.Tables[0].Columns.Remove("ngayra");
                    //ads.Tables[0].Columns.Remove("makpra");
                    //ads.Tables[0].Columns.Remove("lydo");
                    //ads.Tables[0].Columns.Remove("maduyet");
                    //ads.Tables[0].Columns.Remove("idkhoa");
                //    //ads.Tables[0].Columns.Remove("idtonghop");
                //    m_dshoadon = ads;
                //    dgHoadon_noitru.DataSource = m_dshoadon.Tables[0];
                //    dgHoadon_noitru.Update();
                //    //f_Tinhtien();
                //    m_id = v_id;
                //}
                ////f_Enable(m_id == "" || m_id == "0");
                //butLuu_EnabledChanged(null, null);
                //if (v_Quanglythatthuno)
                //{
                //    if (txtBNThieu.Text != "" && txtBNThieu.Text != "0")
                //    {
                //        chkBNthieu.Checked = true;
                //        chkBNthieu.Enabled = false;
                //    }
                //    else
                //    {
                //        chkBNthieu.Checked = false;
                //        chkBNthieu.Enabled = false;
                //    }

                //    if (txtthua.Text != "" && txtthua.Text != "0")
                //    {
                //        chkBNThua.Checked = true;
                //        chkBNThua.Enabled = false;
                //    }
                //    else
                //    {
                //        chkBNThua.Checked = false;
                //        chkBNThua.Enabled = false;
                //    }
                //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    m_mavaovien = "";
            //    m_maql = "";
            //}
        }

        private void f_Load_Hoadon_thutructiep(string v_id, string v_mmyy,string v_mabn,string v_ngaythu)
        {
            try
            {
                try
                {
                    v_id = decimal.Parse(v_id).ToString();
                }
                catch
                {
                    v_id = "";
                }
                if (v_id == "")
                {
                    return;
                }
                string sql = "", ammyy = "";
                ammyy = v_mmyy;
                if (ammyy == "")
                {
                    ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10));
                }
                sql = "select to_number(1) as chon,a.id,a.mabn,a.mavaovien,a.maql,b2.sotien as tongmien,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.quyenso,a.sobienlai,a.loai,a.loaibn,a.id, case when b.lanin <> 0 then 1 else 0 end as chon, b.mavp, c.ma,c.ten,c.dvt,b.soluong,b.dongia,b.soluong*b.dongia as thanhtien, b.mien,b.soluong*b.dongia-b.mien as thucthu,b.madoituong,d.doituong,b.makp, e.tenkp, b.mabs,f.hoten as tenbs, 0 as idcd,a.ghichu,bacsi,to_char(a.ngay,'dd/mm/yyyy') as ngaycd,c.id_loai,0 as id_nhom,idchidinh ";
                sql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi b1 on a.id=b1.id left join medibvmmyy.v_mienngtru b2 on a.id=b2.id left join (select id,ma,ten,dvt,id_loai from medibv.v_giavp union select d0.id,d0.ma,d0.ten, d0.dang  as dvt,to_number('0') as id_loai from medibv.d_dmbd d0 inner join medibv.d_dmnhom d1 on d0.manhom=d1.id where d1.nhom=1) c on b.mavp=c.id left join medibv.doituong d on b.madoituong=d.madoituong left join medibv.btdkp_bv e on b.makp=e.makp left join medibv.dmbs f on b.mabs=f.ma ";
                sql += " where b1.id is null and a.mabn='" + v_mabn + "' and to_char(a.ngay,'dd/mm/yyyy')='"+ v_ngaythu+"'" ;//a.id = " + v_id;

                DataSet ads = m_v.get_data_mmyy(ammyy, sql);                
                if (ads.Tables[0].Rows.Count > 0)
                {
                    ads.Tables[0].Columns.Remove("mabn");
                    ads.Tables[0].Columns.Remove("mavaovien");
                    ads.Tables[0].Columns.Remove("maql");
                    ads.Tables[0].Columns.Remove("quyenso");
                    ads.Tables[0].Columns.Remove("sobienlai");
                    ads.Tables[0].Columns.Remove("loai");
                    ads.Tables[0].Columns.Remove("loaibn");
                    ads.Tables[0].Columns.Remove("ngay");
                    ads.Tables[0].Columns.Remove("tongmien");
                   
                   // dgDanhsachthu.Update();                    
                }
                 dgDanhsachthu.DataSource = ads.Tables[0];
               
            }
            catch (Exception ex)
            {
                
            }
        }

        private void dgDanhsach_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
               dgDanhsach_CellClick(null, null);
            }
            catch
            {
            }
        }

        private void f_Load_Hoadon_thuroi_BHYT(string v_id, string v_mmyy, string m_mabn,string v_ngaythu, string v_mavaovien)
        {
            string m_mavaovien = "",aid="";
            string m_maql = "";
            int traituyen=0;
            v_id = "";
            CurrencyManager mc = (CurrencyManager)BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember];
            DataView dv = (DataView)mc.List;

            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                if (dv.Table.Rows[i]["chon"].ToString() == "1" && dv.Table.Rows[i]["ttrv"].ToString() == "1")
                    v_id += dv.Table.Rows[i]["id"].ToString() + ",";
                else if (dv.Table.Rows[i]["chon"].ToString() == "1" && dv.Table.Rows[i]["ttrv"].ToString() == "0")
                    aid += dv.Table.Rows[i]["id"].ToString() + ",";
            }
            v_id = v_id.Trim(',');
            aid = aid.Trim(',');
            try
            {
                if (v_id == "" && aid=="")
                {
                    dgHoadon_bhyt.DataSource = null;
                    toolStrip_BHYT.Text = "0";
                    toolStrip_CongkhamBHYT.Text = "0";
                    toolStrip_Mien.Text = "0";
                    toolStrip_Tamung.Text = "0";
                    toolStrip_Thucthu.Text = "0";
                    toolStrip_Tongcong.Text = "0";
                    return;
                }
                //v_id = decimal.Parse(v_id).ToString();
                string sql = "", ammyy = "";
                ammyy = v_mmyy;
                if (ammyy == "") ammyy = m_v.get_mmyy(m_ngaythu.Substring(0, 10));
                DataSet ads = new DataSet();
                DataSet ads1 = new DataSet();
                if (v_id != "")
                {
                    sql = "select to_number(1) as ttrv,to_number(1) as chon,a.id,a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp,";
                    sql += " g.quyenso,g.sobienlai,b.ma,b.ten,b.dvt,a1.stt,b.vat,";
                    sql += " a1.soluong,a1.dongia,a1.dongia as dongia1,(a1.soluong*a1.dongia) as sotien,a1.bhyttra,a1.bhyttra as bhyttra1, 0 as bntra,";
                    sql += "a1.mavp,tamung,a1.madoituong,coalesce(e.traituyen,0) as traituyen,a1.mien,b.bhyt_tt,b.bhyt,to_number(1) as cls ";
                    sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id inner join ";
                    sql += " medibvmmyy.v_ttrvct a1 on a.id=a1.id inner join ";
                    sql += " medibv.v_giavp b on a1.mavp=b.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id ";
                    sql += " where a.id in( " + v_id + ") and g.hddt=" + gIn.Tag.ToString();
                    ads = m_v.get_data_mmyy(ammyy, sql);

                    sql = "select to_number(1) as ttrv,to_number(1) as chon,a.id,a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp,";
                    sql += "g.quyenso,g.sobienlai,b.ma,b.ten||' '||b.hamluong as ten,b.dang as dvt,a1.stt,b.vat,";
                    sql += " a1.soluong,a1.dongia,a1.dongia as dongia1,(a1.soluong*a1.dongia) as sotien,a1.bhyttra,a1.bhyttra as bhyttra1, 0 as bntra,";
                    sql += " a1.mavp,tamung,a1.madoituong,coalesce(e.traituyen,0) as traituyen,a1.mien,to_number(0) bhyt_tt,";
                    sql += "to_number(0) as bhyt,to_number(0) as cls from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id";
                    sql += " inner join medibvmmyy.v_ttrvct a1 on a.id=a1.id ";
                    sql += " inner join medibv.d_dmbd b on a1.mavp=b.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id ";
                    sql += " where a.id in ( " + v_id + ") and g.hddt=" + gIn.Tag.ToString();
                    ads1 = m_v.get_data_mmyy(ammyy, sql);


                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                if(aid != "")
                {
                    sql = "select to_number(0) as ttrv,to_number(1) as chon,a.id,a.mabn,a.mavaovien,a.maql,0 as loaiba,";
                    sql += "to_char(a.ngay,'dd/mm/yyyy') as ngaythu,a.makp, a.quyenso,a.sobienlai,";
                    sql += "b.ma,b.ten,b.dvt,a1.stt,b.vat,a1.soluong,a1.dongia,a1.dongia as dongia1,";
                    sql += "(a1.soluong*a1.dongia) as sotien,to_number(0) as bhyttra,to_number(0) as bhyttra1,";
                    sql += "0 as bntra,a1.mavp,to_number(0) as tamung,a1.madoituong,to_number(0) as traituyen,";
                    sql += "a1.mien,b.bhyt_tt,b.bhyt,to_number(1) as cls from medibvmmyy.v_vienphill a inner join ";
                    sql += "medibvmmyy.v_vienphict a1 on a.id=a1.id inner join  medibv.v_giavp b on a1.mavp=b.id ";
                    sql += " where a.id in( " + aid + ") ";
                    ads1 = m_v.get_data_mmyy(ammyy, sql);
                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                    sql = "select to_number(0) as ttrv,to_number(1) as chon,a.id,a.mabn,a.mavaovien,a.maql,0 as loaiba,";
                    sql += "to_char(a.ngay,'dd/mm/yyyy') as ngaythu,a.makp, a.quyenso,a.sobienlai,";
                    sql += "b.ma,b.ten,b.dang as dvt,a1.stt,b.vat,a1.soluong,a1.dongia,a1.dongia as dongia1,";
                    sql += "(a1.soluong*a1.dongia) as sotien,to_number(0) as bhyttra,to_number(0) as bhyttra1,";
                    sql += "0 as bntra,a1.mavp,to_number(0) as tamung,a1.madoituong,to_number(0) as traituyen,";
                    sql += " a1.mien,to_number(0) as bhyt_tt,b.bhyt,to_number(1) as cls from medibvmmyy.v_vienphill a inner join ";
                    sql += " medibvmmyy.v_vienphict a1 on a.id=a1.id inner join  medibv.d_dmbd b on a1.mavp=b.id ";
                    sql += " where a.id in ( " + aid + ")";
                    ads1 = m_v.get_data_mmyy(ammyy, sql);
                    if (ads1 != null)
                    {
                        if (ads == null)
                        {
                            ads = ads1;
                        }
                        else
                        {
                            ads.Merge(ads1);
                        }
                    }
                }
                if (ads.Tables[0].Rows.Count > 0)
                {
                    m_mavaovien = ads.Tables[0].Rows[0]["mavaovien"].ToString();
                    m_maql = ads.Tables[0].Rows[0]["maql"].ToString();

                    try
                    {
                        txtTamung.Text = decimal.Parse(ads.Tables[0].Rows[0]["tamung"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        txtTamung.Text = "0";
                    }
                    cmbTraituyen.SelectedIndex = traituyen = int.Parse(ads.Tables[0].Rows[0]["traituyen"].ToString());
                    
                    //m_sothe = ads.Tables[0].Rows[0]["sothe"].ToString();
                   
                    //ads.Tables[0].Columns.Remove("mabn");
                    //ads.Tables[0].Columns.Remove("mavaovien");
                    //ads.Tables[0].Columns.Remove("maql");
                    //ads.Tables[0].Columns.Remove("quyenso");
                    //ads.Tables[0].Columns.Remove("sobienlai");
                    //ads.Tables[0].Columns.Remove("loaiba");
                    //ads.Tables[0].Columns.Remove("ngaythu");
                    //ads.Tables[0].Columns.Remove("makp");
                    //ads.Tables[0].Columns.Remove("mabs");
                    //ads.Tables[0].Columns.Remove("chandoan");
                    //ads.Tables[0].Columns.Remove("maicd");
                    //ads.Tables[0].Columns.Remove("sothe");
                    //ads.Tables[0].Columns.Remove("maphu");
                    //ads.Tables[0].Columns.Remove("mabv");
                    //ads.Tables[0].Columns.Remove("traituyen");
                    m_dshoadon = ads;
                  
                    f_Tinhtien();
                    m_id = v_id;
                }
                dgHoadon_bhyt.DataSource = m_dshoadon.Tables[0];
                //f_tinhTong(2);
               
            }
            catch (Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_HoaDon_Roi");
                m_mavaovien = "";
                m_maql = "";
            }
        }
        private void f_Load_Hoadon_Duyet()
        {
            string m_mavaovien = "", v_id = "",a_id="";
            string m_maql = "";
            int traituyen = 0;

            DataRowView r = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
            v_id = r["id"].ToString();

            try
            {
                if (v_id == "")
                {
                    dgHoadon_bhyt.DataSource = null;
                    txttongtien.Text = "";
                    return;
                }
                //v_id = decimal.Parse(v_id).ToString();
                string sql = "", ammyy = "";
                ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0,10));
                if (ammyy == "") ammyy = m_v.get_mmyy(m_ngaythu.Substring(0, 10));
                DataSet ads, ads1;

                //sql = "select to_number(1) as chon,a.id,a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp,";
                //sql += " '' mabs,a.maicd,a.chandoan,e.sothe,e.maphu,e.mabv,g.quyenso,g.sobienlai,b.ma,b.ten,b.dvt,a1.stt";
                //sql += " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra,a1.mavp,tamung,a1.madoituong,coalesce(e.traituyen,0) as traituyen,a1.mien,b.bhyt_tt,b.bhyt ";
                //sql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id inner join ";
                //sql += " medibvmmyy.v_ttrvct a1 on a.id=a1.id inner join ";
                //sql += " medibv.v_giavp b on a1.mavp=b.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id ";
                //sql += " where a.id in( " + v_id + ") and g.hddt=" + gIn.Tag.ToString();
                sql = "select to_number(1) as chon,a.id,b.mabn,to_char(b.ngayud,'dd/mm/yyyy') as ngaythu,b.quyenso,b.sobienlai,c.ma,c.ten,";
                sql += "c.dvt,a.stt,a.soluong,a.dongia,a.dongia as dongia1,(a.soluong*a.dongia) as sotien,a.bhyt as bhyttra,a.mien,c.bhyt_tt,";
                sql += "c.bhyt,b.traituyen,b.tamung,a.mavp,a.madoituong,to_number(0) as bntra,a.vat,to_number(1) as cls ";
                sql += "from medibvmmyy.v_bienlaitaichinhct a inner join medibvmmyy.v_bienlaitaichinhll b on a.id=b.id ";
                sql += "inner join medibv.v_giavp c on a.mavp=c.id where a.id in( " + v_id + ") and b.done=" +( gIn.Tag.ToString() == "1" ? "0" : gIn.Tag.ToString() == "2"?"1":"0");
                ads = m_v.get_data_mmyy(ammyy, sql);

                //sql = "select to_number(1) as chon,a.id,a.mabn,a.mavaovien,a.maql,0 as loaiba,to_char(g.ngay,'dd/mm/yyyy') as ngaythu,g.makp,";
                //sql += " '' as mabs,a.maicd,a.chandoan,e.sothe,e.maphu,e.mabv,g.quyenso,g.sobienlai,b.ma,b.ten||' '||b.hamluong as ten,b.dang as dvt,a1.stt,";
                //sql += " a1.soluong,a1.dongia,(a1.soluong*a1.dongia) as sotien,0 as bhyttra, 0 as bntra,";
                //sql += " a1.mavp,tamung,a1.madoituong,coalesce(e.traituyen,0) as traituyen,a1.mien,b.bhyt_tt,b.bhyt from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll g on a.id=g.id";
                //sql += " inner join medibvmmyy.v_ttrvct a1 on a.id=a1.id ";
                //sql += " inner join medibv.d_dmbd b on a1.mavp=b.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id ";
                //sql += " where a.id in ( " + v_id + ") and g.hddt=" + gIn.Tag.ToString();
                sql = "select to_number(1) as chon, a.id,b.mabn,to_char(b.ngayud,'dd/mm/yyyy') as ngaythu,b.quyenso,b.sobienlai,c.ma,c.ten,";
                sql += "c.dang as dvt,a.stt,a.soluong,a.dongia,a.dongia as dongia1,(a.soluong*a.dongia) as sotien,a.bhyt as bhyttra,a.mien,";
                sql += "to_number(0) as bhyt_tt,to_number(0) as bhyt,b.traituyen,b.tamung ,a.mavp,a.madoituong,to_number(0) as bntra,a.vat,to_number(0) as cls ";
                sql += "from medibvmmyy.v_bienlaitaichinhct a inner join medibvmmyy.v_bienlaitaichinhll b on a.id=b.id ";
                sql += "inner join medibv.d_dmbd c on a.mavp=c.id where a.id in( " + v_id + ") and b.done=" + (gIn.Tag.ToString() == "1" ? "0" : gIn.Tag.ToString() == "2" ? "1" : "0");
                ads1 = m_v.get_data_mmyy(ammyy, sql);

                if (ads1 != null)
                {
                    if (ads == null)
                    {
                        ads = ads1;
                    }
                    else
                    {
                        ads.Merge(ads1);
                    }
                }

                if (ads.Tables[0].Rows.Count > 0)
                {
                    //m_mavaovien = ads.Tables[0].Rows[0]["mavaovien"].ToString();
                    //m_maql = ads.Tables[0].Rows[0]["maql"].ToString();

                    try
                    {
                        txtTamung.Text = decimal.Parse(ads.Tables[0].Rows[0]["tamung"].ToString()).ToString("###,###,##0.##");
                    }
                    catch
                    {
                        txtTamung.Text = "0";
                    }
                    cmbTraituyen.SelectedIndex = traituyen = int.Parse(ads.Tables[0].Rows[0]["traituyen"].ToString());

                    //m_sothe = ads.Tables[0].Rows[0]["sothe"].ToString();

                    //ads.Tables[0].Columns.Remove("mabn");
                    //ads.Tables[0].Columns.Remove("mavaovien");
                    //ads.Tables[0].Columns.Remove("maql");
                    //ads.Tables[0].Columns.Remove("quyenso");
                    //ads.Tables[0].Columns.Remove("sobienlai");
                    //ads.Tables[0].Columns.Remove("loaiba");
                    //ads.Tables[0].Columns.Remove("ngaythu");
                    //ads.Tables[0].Columns.Remove("makp");
                    //ads.Tables[0].Columns.Remove("mabs");
                    //ads.Tables[0].Columns.Remove("chandoan");
                    //ads.Tables[0].Columns.Remove("maicd");
                    //ads.Tables[0].Columns.Remove("sothe");
                    //ads.Tables[0].Columns.Remove("maphu");
                    //ads.Tables[0].Columns.Remove("mabv");
                    //ads.Tables[0].Columns.Remove("traituyen");
                    m_dshoadon = ads;

                    f_Tinhtien();
                    m_id = v_id;
                }
                dgHoadon_bhyt.DataSource = m_dshoadon.Tables[0];
                dgHoadon_bhyt.Update();
                //f_tinhTong(2);

            }
            catch (Exception ex)
            {
                m_v.upd_v_error(ex.ToString(), m_v.s_ComputerName, "f_Load_HoaDon_Roi");
                m_mavaovien = "";
                m_maql = "";
            }
        }
        private DataSet get_congkhambhyt()
        {

            try
            {
                
                DataRow r = ads_doituong.Tables[0].Select("madoituong=1")[0];
                v_dongiabhyt = r["field_gia"].ToString();
            }
            catch
            {
            }
            DataSet ads = new DataSet();
            int solankham = 1;
            string sql = "";
            if (thutheongay)
            {
                sql = "select count(*) from medibvmmyy.benhanpk where mabn='" + m_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + m_ngaythu.Substring(0, 10) + "' and makp in (select makp from medibvmmyy.bhytkb where mabn='" + m_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "' and quyenso=0)";
                solankham = int.Parse(m_v.get_data_mmyy(m_v.get_mmyy(txtNgaythu.Text.Substring(0, 10)), sql).Tables[0].Rows[0][0].ToString());
                if (solankham == 0) solankham = 1;
            }
            s_mavp_congkham = s_mavp_congkham == "" ? "-1" : s_mavp_congkham;

            sql = "select ma,ten,dvt,to_number(" + solankham + ",0) as soluong," + v_dongiabhyt + " as dongia, to_number(0,'9') as giaban, to_number(0,'9') as gia_bh, " + solankham + "* " + v_dongiabhyt + " as sotien,to_number(0,'9') as bhyttra, to_number(0,9) as bntra, id as mavp, to_number(1) as madoituong from medibv.v_giavp where id=" + s_mavp_congkham;
            ads = m_v.get_data(sql);
            return ads;
        }
        private void f_Tinhtien()// v_asotien <=0 tính tỷ lệ bhyt chi trả dựa vào tổng chi phí trong m_dshoadon, nếu v_asotien > 0 tính tỷ lệ bhyt chi trả đựa vào tổng tiền truyền vào
        {
            try
            {
                //bool bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
                //bool bTraituyen_bhtra = m.bTraituyen_bhtra;//true: trai tuyen tinh theo: ty le the * ty le trai tuyen
                decimal asoluong = 0, adongia = 0, amien = 0, asotien = 0, abhtra = 0, abntra = 0, atongmien = 0, atongcp = 0, atongbhyttra = 0, atongbntra = 0, acongkhambhyt = 0, atamung = 0, atongsocp = 0, atyle = 0;
                //foreach (DataRow r in m_dsnhomvp.Tables[0].Rows)
                //{
                //    r["sotien"] = 0;
                //}
                              
                

                //if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && !bTraituyen_bhtra) atyle = iTraituyen;
                //else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && asotien > m_v.ma13_st(m_v.nhom_duoc))
                //{
                //    atyle = f_get_Tylebhytchitra(9999999);
                //    atyle = atyle * decimal.Parse(iTraituyen.ToString()) / 100;
                //}
                //else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && asotien <= m_v.ma13_st(m_v.nhom_duoc))
                //{
                //    atyle = decimal.Parse(iTraituyen.ToString());
                //}
                //else atyle = f_get_Tylebhytchitra(asotien + zsotien_datra);
                //decimal dtyle = 0;
                //bool bKhongcungchitra = false;
                //decimal d_dichvu_tt = 0, d_dichvu_tt_bhyt_tra = 0;
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    abhtra = 0;
                    try
                    {
                        adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
                        if (adongia < 0)
                        {
                            adongia = 0;
                        }
                    }
                    catch
                    {
                        adongia = 0;
                    }
                    try
                    {
                        asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
                    }
                    catch
                    {
                        asoluong = 0;
                    }
                    asotien = Math.Round(asoluong * adongia, 2);
                    
                    abhtra =decimal.Parse(r["bhyttra"].ToString().Trim().Replace(",", ""));//
                    amien  =decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));//                    
                    abntra = asotien - abhtra - amien;

                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["mien"] = amien;
                    r["sotien"] = asotien;
                    r["bntra"] = abntra;
                    r["bhyttra"] = abhtra;

                   

                    atongbntra += abntra;
                    atongbhyttra += abhtra;
                    atongmien += amien;
                    atongcp += asotien;
                }

                m_dshoadon.AcceptChanges();
                atamung = 0;// decimal.Parse(txtTamung.Text.Replace(",", ""));
                atongbntra = atongcp - atongbhyttra;
                
                toolStrip_CongkhamBHYT.Text = "0";
                
                atongsocp = atongbntra - atamung;
                if (atongsocp < 0)
                {
                    toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
                    txtPhaithu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
                    lbBNTra.Text = "Phải hoàn:";
                    lbPhaithu.Text = "Phải hoàn:";
                }
                else
                {
                    toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##");
                    txtPhaithu.Text = atongsocp.ToString("###,###,##0.##");
                    lbBNTra.Text = "Phải thu:";
                    lbPhaithu.Text = "Phải thu:";
                }
                toolStrip_Tamung.Text = atamung.ToString("###,###,##0.##");

                toolStrip_BHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                toolStrip_Tongcong.Text = atongcp.ToString("###,###,##0.##");
                toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##").Trim();

                toolStrip_CongkhamBHYT.Text = acongkhambhyt.ToString("###,###,##0.##");
                toolStrip_Tongcong.Text = atongcp.ToString("###,###,##0.##");
                //toolStrip_BHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                toolStrip_Thucthu.Text = atongbntra.ToString("###,###,##0.##");
                txtTamung.Text = atamung.ToString("###,###,##0.##");
                

            }
            catch(Exception ex)
            {
                toolStrip_CongkhamBHYT.Text = "0";
                toolStrip_Tongcong.Text = "0";
                toolStrip_BHYT.Text = "0";
                toolStrip_Thucthu.Text = "0";
            }
        }
        private void f_Tinhtien_bobobo()// v_asotien <=0 tính tỷ lệ bhyt chi trả dựa vào tổng chi phí trong m_dshoadon, nếu v_asotien > 0 tính tỷ lệ bhyt chi trả đựa vào tổng tiền truyền vào
        {
            try
            {
                bool bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
                bool bTraituyen_bhtra = m.bTraituyen_bhtra;//true: trai tuyen tinh theo: ty le the * ty le trai tuyen
                decimal asoluong = 0, adongia = 0, amien = 0, asotien = 0, abhtra = 0, abntra = 0, atongmien = 0, atongcp = 0, atongbhyttra = 0, atongbntra = 0, acongkhambhyt = 0, atamung = 0, atongsocp = 0, atyle = 0;
                foreach (DataRow r in m_dsnhomvp.Tables[0].Rows)
                {
                    r["sotien"] = 0;
                }

                get_tongchiphi_datra(m_mabn, m_mavaovien, txtNgaythu.Text, m_sothe);

                if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && !bTraituyen_bhtra) atyle = iTraituyen;
                else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && asotien > m_v.ma13_st(m_v.nhom_duoc))
                {
                    atyle = f_get_Tylebhytchitra(9999999);
                    atyle = atyle * decimal.Parse(iTraituyen.ToString()) / 100;
                }
                else if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bTraituyen_bhtra && asotien <= m_v.ma13_st(m_v.nhom_duoc))
                {
                    atyle = decimal.Parse(iTraituyen.ToString());
                }
                else atyle = f_get_Tylebhytchitra(asotien + zsotien_datra);
                decimal dtyle = 0;
                bool bKhongcungchitra = false;
                decimal d_dichvu_tt = 0, d_dichvu_tt_bhyt_tra = 0;
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    abhtra = 0;
                    try
                    {
                        adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
                        if (adongia < 0)
                        {
                            adongia = 0;
                        }
                    }
                    catch
                    {
                        adongia = 0;
                    }
                    try
                    {
                        asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
                    }
                    catch
                    {
                        asoluong = 0;
                    }
                    asotien = Math.Round(asoluong * adongia, 2);
                    //tinh chi phi van chuyen nhung the ma BHYT cho huong 100%
                    DataRow r1 = null;
                    try { r1 = m_dsgiavp.Tables[0].Select("id='" + r["mavp"].ToString() + "'")[0]; }
                    catch { r1 = null; }
                    //	
                    bKhongcungchitra = false; d_dichvu_tt_bhyt_tra = 0; d_dichvu_tt = 0;
                    if (r1 != null)
                    {
                        dtyle = f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());//100% tra ve 1
                        if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0 && bBHYT_Traituyen_tinh_Tyle_khac && decimal.Parse(r["bhyt"].ToString()) > decimal.Parse(r["bhyt_tt"].ToString()))
                        {
                            bKhongcungchitra = true;
                            d_dichvu_tt = asotien;
                            d_dichvu_tt_bhyt_tra = asotien * decimal.Parse(r["bhyt_tt"].ToString()) / 100;
                        }
                    }
                    if (r["madoituong"].ToString() == "1")
                    {
                        abhtra = (asotien - d_dichvu_tt) * dtyle + d_dichvu_tt_bhyt_tra;// f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                    }
                    //
                    if (r["madoituong"].ToString() == "1" && atyle != 100 && (r["bhyt_tt"].ToString() == "0" || r["bhyt_tt"].ToString() == r["bhyt"].ToString()))
                        abhtra = abhtra * (bKhongcungchitra ? 100 : atyle) / 100;
                    else if (r["madoituong"].ToString() == "1" && atyle != 100 && (r["bhyt_tt"].ToString() != "0" && r["bhyt_tt"].ToString() != r["bhyt"].ToString()))
                    {
                        abhtra = abhtra * (bKhongcungchitra ? 100 : (decimal.Parse(r["bhyt_tt"].ToString() == "" ? atyle.ToString() : r["bhyt_tt"].ToString()))) / 100;
                    }

                    else
                    {
                        amien = 0;
                        if (m_doituongmien.IndexOf("," + r["madoituong"].ToString() + ",") != -1) amien = asotien;
                    }
                    try
                    {
                        if (decimal.Parse(r["mien"].ToString().Trim().Replace(",", "")) > 0)
                        {
                            amien = decimal.Parse(r["mien"].ToString().Trim().Replace(",", ""));
                        }
                        if (amien < 0 || amien > adongia * asoluong)
                        {
                            amien = 0;
                        }

                    }
                    catch
                    {
                        amien = 0;
                    }
                    abntra = asotien - abhtra - amien;

                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["mien"] = amien;
                    r["sotien"] = asotien;
                    r["bntra"] = abntra;
                    r["bhyttra"] = abhtra;

                    try
                    {
                        string aid_nhom = m_dsgiavp.Tables[0].Select("id=" + r["mavp"].ToString())[0]["id_nhom"].ToString();
                        foreach (DataRow rn in m_dsnhomvp.Tables[0].Select("id=" + aid_nhom))
                        {
                            rn["sotien"] = (decimal.Parse(rn["sotien"].ToString()) + asotien);
                        }
                    }
                    catch
                    {
                    }

                    atongbntra += abntra;
                    atongbhyttra += abhtra;
                    atongmien += amien;
                    atongcp += asotien;
                }

                m_dshoadon.AcceptChanges();

                atamung = decimal.Parse(txtTamung.Text.Replace(",", ""));

                //atongbhyttra = atongbhyttra * f_get_Tylebhytchitra(atongbhyttra) / 100;
                atongbntra = atongcp - atongbhyttra;
                try
                {
                    acongkhambhyt = decimal.Parse(get_congkhambhyt().Tables[0].Rows[0]["sotien"].ToString());
                    toolStrip_CongkhamBHYT.Text = acongkhambhyt.ToString("###,###,##0.##");
                }
                catch
                {
                    toolStrip_CongkhamBHYT.Text = "0";
                }

                string s_ngay_7_cn = ((DateTime)(m_v.s_server_date)).DayOfWeek.ToString().ToUpper();

                if (dBhyt_Chitra_Toida_7CN != 0 && (s_ngay_7_cn == DayOfWeek.Saturday.ToString().ToUpper() || s_ngay_7_cn == DayOfWeek.Sunday.ToString().ToUpper()))
                {
                    if (atongcp + zsotien_datra > dBhyt_Chitra_Toida_7CN)
                    {
                        atongbhyttra = dBhyt_Chitra_Toida_7CN;
                        //atongbhyttra = (atongcp+zsotien_datra <= dBhyt_Chitra_Toida_7CN) ? atongcp+zsotien_datra : dBhyt_Chitra_Toida_7CN;
                        atongbntra = atongcp + zsotien_datra - atongbhyttra - zbhyt_datra - atongmien;
                    }
                }
                else if (lTraituyen != 0 && cmbTraituyen.SelectedIndex != 0 && atongbhyttra > lTraituyen)
                {
                    decimal tc = atongbhyttra + atongbntra;
                    atongbhyttra = decimal.Parse(lTraituyen.ToString());
                    atongbntra = tc - atongbhyttra - atongmien;
                }
                atongsocp = atongbntra - atamung;
                //

                //
                if (atongsocp < 0)
                {
                    toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
                    txtPhaithu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
                    lbBNTra.Text = "Phải hoàn:";
                    lbPhaithu.Text = "Phải hoàn:";
                }
                else
                {
                    toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##");
                    txtPhaithu.Text = atongsocp.ToString("###,###,##0.##");
                    lbBNTra.Text = "Phải thu:";
                    lbPhaithu.Text = "Phải thu:";
                }
                toolStrip_Tamung.Text = atamung.ToString("###,###,##0.##");

                toolStrip_BHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                toolStrip_Tongcong.Text = atongcp.ToString("###,###,##0.##");
                toolStrip_Mien.Text = atongmien.ToString("###,###,##0.##").Trim();

                toolStrip_CongkhamBHYT.Text = acongkhambhyt.ToString("###,###,##0.##");
                toolStrip_Tongcong.Text = atongcp.ToString("###,###,##0.##");
                //toolStrip_BHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                toolStrip_Thucthu.Text = atongbntra.ToString("###,###,##0.##");
                txtTamung.Text = atamung.ToString("###,###,##0.##");
                //try
                //{
                //    foreach (Control c in m_table.Controls)
                //    {
                //        if (c.Name.IndexOf("tbma_") == 0)
                //        {
                //            try
                //            {
                //                c.Text = decimal.Parse(m_dsnhomvp.Tables[0].Select("id=" + c.Name.Replace("tbma_", ""))[0]["sotien"].ToString()).ToString("###,###,##0.##");
                //                if (c.Text == "0")
                //                {
                //                    c.Text = "";
                //                }
                //            }
                //            catch
                //            {
                //                c.Text = "";
                //            }
                //            c.BackColor = (c.Text != "") ? Color.LightYellow : Color.White;
                //        }
                //    }
                //}
                //catch
                //{
                //}

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                toolStrip_CongkhamBHYT.Text = "0";
                toolStrip_Tongcong.Text = "0";
                toolStrip_BHYT.Text = "0";
                toolStrip_Thucthu.Text = "0";
            }
        }
        /*private void f_Tinhtien()
        {
            try
            {
                decimal asoluong = 0, adongia = 0, asotien = 0, abhtra = 0, abntra = 0, atongcp = 0, atongbhyttra = 0, atongbntra = 0, acongkhambhyt = 0, atamung = 0, atongsocp = 0, atyle = 0;
                foreach (DataRow r in m_dsnhomvp.Tables[0].Rows)
                {
                    r["sotien"] = 0;
                }
                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    if (r["madoituong"].ToString() == "1")
                    {
                        try
                        {
                            adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
                            if (adongia < 0)
                            {
                                adongia = 0;
                            }
                        }
                        catch
                        {
                            adongia = 0;
                        }
                        try
                        {
                            asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
                        }
                        catch
                        {
                            asoluong = 0;
                        }
                        asotien += Math.Round(asoluong * adongia, 2);
                    }
                }
                //
                get_tongchiphi_datra(m_mabn, m_mavaovien, m_ngaythu, m_sothe);
                //
                if (cmbTraituyen.SelectedIndex != 0 && iTraituyen != 0) atyle = iTraituyen;
                else atyle = f_get_Tylebhytchitra(asotien + zsotien_datra);

                foreach (DataRow r in m_dshoadon.Tables[0].Rows)
                {
                    try
                    {
                        adongia = decimal.Parse(r["dongia"].ToString().Trim().Replace(",", ""));
                        if (adongia < 0)
                        {
                            adongia = 0;
                        }
                    }
                    catch
                    {
                        adongia = 0;
                    }
                    try
                    {
                        asoluong = decimal.Parse(r["soluong"].ToString().Trim().Replace(",", ""));
                    }
                    catch
                    {
                        asoluong = 0;
                    }
                    asotien = Math.Round(asoluong * adongia, 2);

                    abhtra = asotien * f_Get_Tyle_BHYT(r["madoituong"].ToString(), r["mavp"].ToString());
                    if (r["madoituong"].ToString() == "1" && atyle != 100) abhtra = abhtra * atyle / 100;
                    else if (m_doituongmien.IndexOf("," + r["madoituong"].ToString() + ",") != -1) abhtra = asotien;
                    abntra = asotien - abhtra;

                    r["soluong"] = asoluong;
                    r["dongia"] = adongia;
                    r["sotien"] = asotien;
                    r["bntra"] = abntra;
                    r["bhyttra"] = abhtra;

                    try
                    {
                        string aid_nhom = m_dsgiavp.Tables[0].Select("id=" + r["mavp"].ToString())[0]["id_nhom"].ToString();
                        foreach (DataRow rn in m_dsnhomvp.Tables[0].Select("id=" + aid_nhom))
                        {
                            rn["sotien"] = (decimal.Parse(rn["sotien"].ToString()) + asotien);
                        }
                    }
                    catch
                    {
                    }

                    atongbntra += abntra;
                    atongbhyttra += abhtra;
                    atongcp += asotien;
                }

                m_dshoadon.AcceptChanges();

                atamung = decimal.Parse(txtTamung.Text.Replace(",", ""));

                //atongbhyttra = atongbhyttra * f_get_Tylebhytchitra(atongbhyttra) / 100;
                atongbntra = atongcp - atongbhyttra;
                try
                {
                    acongkhambhyt = decimal.Parse(get_congkhambhyt().Tables[0].Rows[0]["sotien"].ToString());
                    toolStrip_CongkhamBHYT.Text = acongkhambhyt.ToString("###,###,##0.##");
                }
                catch
                {
                    toolStrip_CongkhamBHYT.Text = "0";
                }

                string s_ngay_7_cn = ((DateTime)(m_v.s_server_date)).DayOfWeek.ToString().ToUpper();

                if (dBhyt_Chitra_Toida_7CN != 0 && (s_ngay_7_cn == DayOfWeek.Saturday.ToString().ToUpper() || s_ngay_7_cn == DayOfWeek.Sunday.ToString().ToUpper()))
                {
                    if (atongcp + zsotien_datra > dBhyt_Chitra_Toida_7CN)
                    {
                        atongbhyttra = dBhyt_Chitra_Toida_7CN;
                        //atongbhyttra = (atongcp+zsotien_datra <= dBhyt_Chitra_Toida_7CN) ? atongcp+zsotien_datra : dBhyt_Chitra_Toida_7CN;
                        atongbntra = atongcp + zsotien_datra - atongbhyttra - zbhyt_datra;
                    }
                }
                else if (lTraituyen != 0 && cmbTraituyen.SelectedIndex != 0 && atongbhyttra > lTraituyen)
                {
                    decimal tc = atongbhyttra + atongbntra;
                    atongbhyttra = decimal.Parse(lTraituyen.ToString());
                    atongbntra = tc - atongbhyttra;
                }
                atongsocp = atongbntra - atamung;
                //

                //
                if (atongsocp < 0)
                {
                    toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
                    txtPhaithu.Text = atongsocp.ToString("###,###,##0.##").Trim('-');
                    lbBNTra.Text = "Phải hoàn:";
                    lbPhaithu.Text = "Phải hoàn:";
                }
                else
                {
                    toolStrip_Thucthu.Text = atongsocp.ToString("###,###,##0.##");
                    txtPhaithu.Text = atongsocp.ToString("###,###,##0.##");
                   // lbBNTra.Text = lan.Change_language_MessageText("Phải thu:");
                    //lbPhaithu.Text = lan.Change_language_MessageText("Phải thu:");
                }
                toolStrip_Tamung.Text = atamung.ToString("###,###,##0.##");

                toolStrip_BHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                toolStrip_Tongcong.Text = atongcp.ToString("###,###,##0.##");


                //txtCongkham.Text = acongkhambhyt.ToString("###,###,##0.##");
                //txtCPBHYT.Text = atongcp.ToString("###,###,##0.##");
                //txtMienBHYT.Text = atongbhyttra.ToString("###,###,##0.##");
                //txtBNTra_BHYT.Text = atongbntra.ToString("###,###,##0.##");
                txtTamung.Text = atamung.ToString("###,###,##0.##");
                //try
                //{
                //    foreach (Control c in m_table.Controls)
                //    {
                //        if (c.Name.IndexOf("tbma_") == 0)
                //        {
                //            try
                //            {
                //                c.Text = decimal.Parse(m_dsnhomvp.Tables[0].Select("id=" + c.Name.Replace("tbma_", ""))[0]["sotien"].ToString()).ToString("###,###,##0.##");
                //                if (c.Text == "0")
                //                {
                //                    c.Text = "";
                //                }
                //            }
                //            catch
                //            {
                //                c.Text = "";
                //            }
                //            c.BackColor = (c.Text != "") ? Color.LightYellow : Color.White;
                //        }
                //    }
                //}
                //catch
                //{
                //}

            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                toolStrip_CongkhamBHYT.Text = "0";
                toolStrip_Tongcong.Text = "0";
                toolStrip_BHYT.Text = "0";
                toolStrip_Thucthu.Text = "0";
            }
        }*/
        private decimal f_Get_Tyle_BHYT(string v_madoituong, string v_mavp)
        {
            decimal atyle = 0;
            try
            {
                if (m_doituongmien.IndexOf("," + v_madoituong + ",") >= 0 || v_madoituong == "1")
                {
                    if (v_madoituong == "1")
                    {
                        atyle = decimal.Parse(m_dsgiavp.Tables[0].Select("id=" + v_mavp)[0]["bhyt"].ToString());
                        atyle = atyle / 100;
                    }
                    else
                    {
                        atyle = m_dsgiavp.Tables[0].Select("ndm=0 and id=" + v_mavp).Length > 0 ? 1 : 0;
                    }
                }
            }
            catch
            {
                atyle = 0;
            }
            return atyle;
        }
        private int f_get_Tylebhytchitra(decimal v_sotien)
        {
            int tyletmp = 100;
            if (m_sothe != "")
            {
                int maphu = m_v.get_maphu_ngtru(m_sothe, v_sotien, m_v.nhom_duoc);
                tyletmp = (maphu == 1) ? 80 : (maphu == 2) ? 95 : 100;
            }
            return tyletmp;
        }    
        private void get_tongchiphi_datra(string m_mabn, string m_mavaovien, string m_ngay, string m_sothe)
        {
            string xxx = m_v.user + m_v.mmyy(m_ngay), sql = "", sqlht = "";
            sqlht = "select * from " + xxx + ".v_hoantra where mabn='" + m_mabn + "' and loaibn in (1,3) and to_char(ngay,'dd/mm/yyyy')='" + m_ngay.Substring(0, 10) + "'";
            sql = "select b.sotien,b.mien,b.bhyt,b.tamung from " + xxx + ".v_ttrvds a inner join " + xxx + ".v_ttrvll b on a.id=b.id inner join " + xxx + ".v_ttrvbhyt c on a.id=c.id ";
            sql += " left join (" + sqlht + ") d on b.quyenso=d.quyenso and b.sobienlai=d.sobienlai and d.id is null ";
            sql += "  where b.sobienlai>0 and a.mabn='" + m_mabn + "' and to_char(b.ngay,'dd/mm/yyyy')='" + m_ngay.Substring(0, 10) + "' and c.sothe='" + m_sothe + "'";
            if (m_id != "") sql += " and a.id not in ( " + m_id+ ") ";
            if (m_mavaovien.Trim() != "") sql += " and a.mavaovien=" + m_mavaovien;
            DataSet lds = m_v.get_data(sql);
            zsotien_datra = 0; zbhyt_datra = 0; zmien_datra = 0; zbntra_datra = 0; ztamung_datra = 0;
            foreach (DataRow r in lds.Tables[0].Rows)
            {
                zsotien_datra += decimal.Parse(r["sotien"].ToString());
                zbhyt_datra += decimal.Parse(r["bhyt"].ToString());
                zmien_datra += decimal.Parse(r["mien"].ToString());
                ztamung_datra += decimal.Parse(r["tamung"].ToString());
            }
            zbntra_datra = zsotien_datra - zbhyt_datra - zmien_datra;
        }
        private void f_Load_DG_BHYT_NGT()
        {
            
            try
            {
               
                string sql = "", aexp = "";
                int alimit = 0;
                                
                aexp = "where a1.hddt="+gIn.Tag.ToString()+" and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and a1.idtonghop<0";

                sql = "select distinct a.id,to_number('1') as ttrv,case when rownum = 1 then to_number('1') else to_number('0') end as chon,case when b.phai = 1 then 'Nữ' else 'Nam' end as phai,h.dcnhan,h.dcdonvi,h.nguoinhan,h.donvi,h.masothue, a.mabn,b.hoten,b.namsinh,to_char(a1.ngay,'dd/mm/yyyy') ||' '||to_char(a1.ngayud,'hh24:mi') as ngay," +
                    " to_char(0) as sohieu,to_char(0) as sobienlai,a1.sotien,(a1.sotien - a1.bhyt - a1.mien) as thucthu,a1.bhyt mien,0 as thuoc,0 as cls,b.thon||','||b.sonha||','||g.tenpxa||','||f.tenquan||','||e.tentt as diachi," +
                    " trim(to_char(a1.sobienlai,9999999)) as sbl,a.mavaovien,a.mabn,to_char(h.ngay, 'dd/mm/yyyy hh24:mi') as ngayhen from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll a1" +
                    " on a.id=a1.id inner join medibvmmyy.v_ttrvct a2 on a.id=a2.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt e on b.matt=e.matt left join " +
                    " medibv.btdquan f on b.maqu=f.maqu left join medibv.btdpxa g on b.maphuongxa=g.maphuongxa " +
                    " left join medibv.v_quyenso d on a1.quyenso=d.id left join medibv.yeucauhoadon h on a.mavaovien=h.mavaovien  " + aexp;

                DataTable dttemp = new DataTable();
                dttemp = m_v.get_data_bc(txtTN.Value, txtTN.Value, sql, alimit).Tables[0];
                dgDanhsach.DataSource = dttemp;
                dgDanhsach.Update();
                
            }
            catch(Exception ex)
            {
               
            }
           
        }
        private void f_Load_DG_BHYT_NGT_Duyet()
        {

            try
            {

                string asql = "", aexp = "",aid="";
                int alimit = 0;
                //DataRowView r = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);
                //aid = r["id"].ToString();
                aexp = "where a.done=" + (gIn.Tag.ToString() == "1" ? "0" : gIn.Tag.ToString() == "2" ? "1":"0" )+ " and a.loai=" + gHoadon.Tag.ToString() + " and to_date(to_char(a.ngayhd,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') ";

                //asql = "select to_number(0) as chon,a.id,a.mabn,to_char(a.ngayhd,'ddd/mm/yyyyy') as ngaythu,a.quyenso,";
                //asql += "a.sobienlai,d.ma,d.ten,d.dvt,b.stt,b.soluong,b.dongia,b.sotien,0 as bhyttra, 0 as bntra,a.tamung,";
                //asql += "a.madoituong,a.traituyen,0 as mien,d.bhyt_tt,d.bhyt ";
                //asql += "from medibvmmyy.v_bienlaitaichinhll a inner join medibv.btdbn c on a.mabn=c.mabn inner join ";
                //asql += "medibvmmyy.v_bienlaitaichinhct b on a.id=b.id inner join medibv.v_giavp d on b.mavp=d.id " + aexp;
                asql = "select to_number(0) as chon,a.dcnhan,a.diachi as dcdonvi,a.nguoinhan,a.tendv as donvi,";
                asql += "a.masothue,a.mabn,b.hoten,b.namsinh,case when b.phai=0 then 'Nam' else 'Nữ' end as phai ,to_char(a.ngayud,'dd/mm/yyyy') as ngay,";
                asql += "a.quyenso as sohieu,a.sobienlai,(a.sotien-a.mien-a.bhyt) as thucthu,a.bhyt as mien,a.sotien as sotien,";
                asql += "0 as thuoc,0 as cls,a.dcnhan as diachi,a.id,to_char(a.ngayhen,'dd/mm/yyyy') as ngayhen,a.mavaovien,a.hdcls as cls ";
                asql += "from medibvmmyy.v_bienlaitaichinhll a inner join medibv.btdbn b on a.mabn=b.mabn " + aexp;

                DataTable dttemp = new DataTable();
                dttemp = m_v.get_data_bc(txtTN.Value, txtTN.Value, asql, alimit).Tables[0];
                dgDanhsach.DataSource = dttemp;
                dgDanhsach.Update();

            }
            catch (Exception ex)
            {

            }

        }
        private void f_Tinhtien_noitru()
        {
                
        }
        private void f_Load_DG_noitru()
        {
           // butTim.Enabled = false;
            try
            {
                txttinnhanh.Text = "Tìm kiếm";
                string sql = "", asql_tt = "";
                int alimit = 0;


                //string s_loaibn = "1,4";// m_v.ttrv_Loaibn_NT(m_userid);
                //if (s_loaibn.Trim() != "")
                //{
                //    string[] sloaibn = s_loaibn.Split(',');
                //    for (int i = 0; i < sloaibn.Length; i++)
                //    {
                //        if (sloaibn[i] == "0")
                //        {
                //            sql = "select to_number('0') as chon,a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,9999999)) as sobienlai from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=0";
                //            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=0";
                //        }
                //        else if (sloaibn[i] == "1")
                //        {
                //            if (sql != "") sql += " union all ";
                //            sql += "select to_number('0') as chon,a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,9999999)) as sobienlai from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where a.hddt=" + gIn.Tag.ToString() + " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=1";

                //            if (asql_tt != "") asql_tt += " union all ";
                //            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where a.hddt=" + gIn.Tag.ToString() + " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=1";
                //        }
                //        else if (sloaibn[i] == "2")
                //        {
                //            if (sql != "") sql += " union all ";
                //            sql += "select to_number('0') as chon,a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,9999999)) as sobienlai from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where a.hddt=" + gIn.Tag.ToString() + " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=2";

                //            if (asql_tt != "") asql_tt += " union all ";
                //            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=1";

                //        }
                //        else if (sloaibn[i] == "3")
                //        {
                //            if (sql != "") sql += " union all ";
                //            sql += "select to_number('0') as chon,a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,9999999)) as sobienlai from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=3";

                //            if (asql_tt != "") asql_tt += " union all ";
                //            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=1";
                //        }
                //        else if (sloaibn[i] == "4")
                //        {
                //            if (sql != "") sql += " union all ";
                //            sql += "select to_number('0') as chon,a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,9999999)) as sobienlai from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where a.hddt=" + gIn.Tag.ToString() + " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=4";

                //            if (asql_tt != "") asql_tt += " union all ";
                //            asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where a.hddt=" + gIn.Tag.ToString() + " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  and a.loaibn=1";
                //        }
                //    }
                //}
                //else
                //{
                //    sql = "select to_number('1') as chon,a1.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay, d.sohieu,a.sobienlai,a.sotien,a.bhyt,a.mien,a.thieu,a.tamung,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then a.sotien-a.bhyt-a.mien-a.thieu-a.tamung else 0 end as phaithu,case when a.sotien-a.bhyt-a.mien-a.thieu-a.tamung>0 then 0 else a.tamung - (a.sotien-a.bhyt-a.mien-a.thieu) end as phaihoan, a.nopthem, trim(b.sonha ||' '|| b.thon) as diachi,a.id,trim(to_char(a.sobienlai,9999999)) as sobienlai from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds a1 on a.id=a1.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.v_quyenso d on a.quyenso=d.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') ";

                //    asql_tt = "select sum(a.sotien-a.bhyt-a.mien-a.thieu-a.tamung) as sotien from medibvmmyy.v_ttrvll a where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') ";
                //}
                //dgHoadon.DataSource = m_v.get_data_bc(txtTN.Value, txtDN.Value, sql,alimit).Tables[0];
                string aexp = "";

                aexp = "where a1.hddt=" + gIn.Tag.ToString() + " and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') ";

                sql = "select distinct a.id,to_number('1') as ttrv, case when rownum = 1 then to_number('1') else to_number('0') end as chon,case when b.phai = 1 then 'Nữ' else 'Nam' end as phai,h.dcnhan,h.dcdonvi,h.nguoinhan,h.donvi,h.masothue, a.mabn,b.hoten,b.namsinh,to_char(a1.ngay,'dd/mm/yyyy') ||' '||to_char(a1.ngayud,'hh24:mi') as ngay," +
                    " to_char(0) as sohieu,to_char(0) as sobienlai,a1.sotien,(a1.sotien - a1.bhyt - a1.mien) as thucthu,a1.bhyt mien,0 as thuoc,0 as cls,b.thon||','||b.sonha||','||g.tenpxa||','||f.tenquan||','||e.tentt as diachi," +
                    " trim(to_char(a1.sobienlai,9999999)) as sbl,a.mavaovien,a.mabn,to_char(h.ngay, 'dd/mm/yyyy hh24:mi') as ngayhen from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll a1" +
                    " on a.id=a1.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt e on b.matt=e.matt left join " +
                    " medibv.btdquan f on b.maqu=f.maqu left join medibv.btdpxa g on b.maphuongxa=g.maphuongxa " +
                    " inner join medibvmmyy.v_ttrvct a2 on a.id=a2.id "+
                    " left join medibv.v_quyenso d on a1.quyenso=d.id left join medibv.yeucauhoadon h on a.mavaovien=h.mavaovien  " + aexp;
                sql += " union all select distinct a.id,to_number('0') as ttrv,to_number('0') as chon,case when b.phai = 1 " +
                    "then 'Nữ' else 'Nam' end as phai,h.dcnhan,h.dcdonvi,h.nguoinhan,h.donvi,h.masothue, a.mabn,b.hoten," +
                    "b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ||' '||to_char(a.ngayud,'hh24:mi') as ngay," +
                    "to_char(0) as sohieu,to_char(0) as sobienlai,a1.soluong * a1.dongia as sotien,((a1.soluong*a1.dongia) - a1.mien) as thucthu," +
                    "a1.mien,0 as thuoc,0 as cls,b.thon||','||b.sonha||','||g.tenpxa||','||f.tenquan||','||e.tentt " +
                    "as diachi,trim(to_char(a.sobienlai,9999999)) as sbl,a.mavaovien,a.mabn, " +
                    "to_char(h.ngay, 'dd/mm/yyyy hh24:mi') as ngayhen from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict a1 " +
                    "on a.id=a1.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt e on b.matt=e.matt left join " +
                    "medibv.btdquan f on b.maqu=f.maqu left join medibv.btdpxa g on b.maphuongxa=g.maphuongxa " +
                    "left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.yeucauhoadon h on a.mavaovien=h.mavaovien " +
                    "where a.hddt=0 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between " +
                    "to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')";

                    dgDanhsach.DataSource = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtTN.Text.Substring(0, 10), false).Tables[0];
   
                decimal atmp = 0, asotien = 0, amien = 0;
                try
                {
                    foreach (DataRow r in m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtTN.Text.Substring(0, 10), false).Tables[0].Rows)
                    {
                        try
                        {
                            atmp = decimal.Parse(r[0].ToString());
                        }
                        catch
                        {
                            atmp = 0;
                        }
                        asotien += atmp;
                    }
                }
                catch
                {
                }
                asotien -= amien;
                //toolStrip_Tongcong.Text = dgHoadon.RowCount.ToString() + " " + lan.Change_language_MessageText("HĐ =") + " " + asotien.ToString("###,###,##0.##") + " " + lan.Change_language_MessageText("Đ");
            }
            catch
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    dv.Table.Rows.Clear();
                }
                catch
                {
                }
                toolStrip_Tongcong.Text = "0 HĐ = 0 Đ";
            }
          //  butTim.Enabled = true;
        }

        private void optChuain_CheckedChanged(object sender, EventArgs e)
        {
            if (optChuain.Checked == true)
            {
                f_Enable_hc(false);
                gIn.Tag = "0";
                butTonghop_Click(null, null);
                dgDanhsach.Columns["Column10"].Visible = true;
                dgHoadon_bhyt.Columns["Column9"].Visible = true;
                dgDanhsach.Columns["clkyhieu"].Visible = false;
                dgDanhsach.Columns["clsobienlai"].Visible = false;
                txtkyhieu.Enabled = false;
                txtSBL1.Enabled = false;
                chkAll.Visible = true;
                txtngayhoadon.Focus();
                chkAll_hoadon.Visible = true;
            }
        }

        private void optIn_CheckedChanged(object sender, EventArgs e)
        {
            if (optIn.Checked == true)
            {
                f_Enable_hc(true);
                gIn.Tag = "2";
                butLuu.Enabled = false;
                dgDanhsach.Columns["Column10"].Visible = false;
                dgHoadon_bhyt.Columns["Column9"].Visible = false;
                dgDanhsach.Columns["clkyhieu"].Visible = true;
                dgDanhsach.Columns["clsobienlai"].Visible = true;
                chkAll.Visible = false;
                butTonghop_Click(null, null);
            }
        }

        private void dgHoadon_noitru_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal asotien = 0;
            CurrencyManager mc = (CurrencyManager)BindingContext[dgHoadon_noitru.DataSource, dgHoadon_noitru.DataMember];
            DataView dv = (DataView)mc.List;
            foreach (DataRow r in dv.Table.Rows)
            {
                if (r["chon"].ToString() == "1")
                {
                    asotien += decimal.Parse(r["bntra"].ToString());
                }
            }
            //txttongtien.Text = asotien.ToString("###,###,##0.##");
        }

        private void dgDanhsachthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    decimal atong = decimal.Parse(txttongtien.Text == "" ? "0" : txttongtien.Text);
                    dgDanhsachthu[0, e.RowIndex].Value = dgDanhsachthu[0, e.RowIndex].Value.ToString() == "0" ? "1" : "0";
                    DataRowView arv = (DataRowView)(dgDanhsachthu.CurrentRow.DataBoundItem);
                    if (dgHoadon_bhyt[0, e.RowIndex].Value.ToString() == "0")
                    {
                        atong = atong + decimal.Parse(arv["bntra"].ToString());
                    }
                    else
                    {
                        atong = atong - decimal.Parse(arv["bntra"].ToString());
                        atong = atong < 0 ? 0 : atong;
                    }
                    //txttongtien.Text = atong.ToString("###,###,##0.##");

                }
            }
            catch { }
        }

        /*private void f_tinhTong( int v_loai)
        {
            try
            {
                decimal asotien = 0;
                if (v_loai == 1 && dgDanhsachthu.DataSource != null)// tính tổng tiền thu trực tiếp
                {
                    CurrencyManager mc = (CurrencyManager)BindingContext[dgDanhsachthu.DataSource, dgDanhsachthu.DataMember];
                    DataView dv = (DataView)mc.List;
                    foreach (DataRow r in dv.Table.Select("chon = 1"))
                    {
                        asotien += decimal.Parse(r["thucthu"].ToString());
                    }
                    txttongtien.Text = asotien.ToString("###,###,##0.##");
                }
                else if (v_loai == 2 && dgHoadon_bhyt.DataSource != null)// tính tổng tiền thu BHYT
                {
                    CurrencyManager mc = (CurrencyManager)BindingContext[dgHoadon_bhyt.DataSource, dgHoadon_bhyt.DataMember];
                    DataView dv = (DataView)mc.List;
                    foreach (DataRow r in dv.Table.Select("chon = 1"))
                    {
                        asotien += decimal.Parse(r["bntra"].ToString());
                    }
                    txttongtien.Text = asotien.ToString("###,###,##0.##");
                }
                else if (v_loai == 3)// tính tồng tiền thu nội trú
                {
                    CurrencyManager mc = (CurrencyManager)BindingContext[dgHoadon_noitru.DataSource, dgHoadon_noitru.DataMember];
                    DataView dv = (DataView)mc.List;
                    foreach (DataRow r in dv.Table.Select("chon = 1"))
                    {
                        asotien += decimal.Parse(r["bntra"].ToString());
                    }
                    txttongtien.Text = asotien.ToString("###,###,##0.##");
                }
            }
            catch { }

        }*/

        private void chkBHYTall_CheckedChanged(object sender, EventArgs e)
        {
            switch (gHoadon.Tag.ToString())
            {
                case "1":
                    {
                        for (int i = 0; i < dgDanhsachthu.RowCount; i++)
                            dgDanhsachthu[0, i].Value = chkAll.Checked;
                        break;
                    }
                case "2":
                    {
                        for (int i = 0; i < dgHoadon_bhyt.RowCount; i++)
                        {
                            dgHoadon_bhyt[0, i].Value = chkAll.Checked;
                            if (chkAll.Checked)
                            {
                                dgHoadon_bhyt["cldongia", i].Value = dgHoadon_bhyt["cldongia1", i].Value.ToString();
                                dgHoadon_bhyt["clbhyttra", i].Value = dgHoadon_bhyt["clbhyttra1", i].Value.ToString();
                            }
                            else
                            {
                                dgHoadon_bhyt["cldongia", i].Value = 0;
                                dgHoadon_bhyt["clbhyttra", i].Value = 0;
                            }
                        }
                        break;
                    {

                    }
                    }
                case "3":
                    {
                        for (int i = 0; i < dgHoadon_noitru.RowCount; i++)
                            dgHoadon_noitru[0, i].Value = chkAll.Checked;
                        break;
                    }
            }
            //if (chkAll.Checked)
            //    f_tinhTong(int.Parse(gHoadon.Tag.ToString()));
            //else
            //    txttongtien.Text = "";
            f_Tinhtien();
        }

        private void dgHoadon_bhyt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    //decimal atong = decimal.Parse(txttongtien.Text == "" ? "0" : txttongtien.Text);
                    dgHoadon_bhyt[0, e.RowIndex].Value = dgHoadon_bhyt[0, e.RowIndex].Value.ToString() == "0" ? "1" : "0";
                    DataRowView arv = (DataRowView)(dgHoadon_bhyt.CurrentRow.DataBoundItem);
                    if (dgHoadon_bhyt[0, e.RowIndex].Value.ToString() == "1")
                    {
                        //atong = atong + decimal.Parse(arv["bntra"].ToString());
                        arv["dongia"] = arv["dongia1"].ToString();
                        arv["bhyttra"] = arv["bhyttra1"].ToString();
                    }
                    else
                    {
                        arv["dongia"] = 0;
                        arv["bhyttra"]=0;
                        //atong = atong - decimal.Parse(arv["bntra"].ToString());
                        //atong = atong < 0 ? 0 : atong;
                    }
                    //txttongtien.Text = atong.ToString("###,###,##0.##");

                }
                f_Tinhtien();
            }
            catch { }
        }

        private void dgHoadon_noitru_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    decimal atong = decimal.Parse(txttongtien.Text == "" ? "0" : txttongtien.Text);
                    dgHoadon_noitru[0, e.RowIndex].Value = dgHoadon_noitru[0, e.RowIndex].Value.ToString() == "0" ? "1" : "0";
                    DataRowView arv = (DataRowView)(dgHoadon_noitru.CurrentRow.DataBoundItem);
                    if (dgHoadon_bhyt[0, e.RowIndex].Value.ToString() == "0")
                    {
                        atong = atong + decimal.Parse(arv["bntra"].ToString());
                    }
                    else
                    {
                        atong = atong - decimal.Parse(arv["bntra"].ToString());
                        atong = atong < 0 ? 0 : atong;
                    }
                    txttongtien.Text = atong.ToString("###,###,##0.##");

                }
            }
            catch { }
        }

        private void optDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (optDuyet.Checked)
            {
                f_Enable_hc(true);
                txtkyhieu.Enabled = true;
                txtSBL1.Enabled = true;
                butLuu.Enabled = true;
                butXoa.Enabled = true;
                gIn.Tag = "1";
                dgDanhsach.Columns["Column10"].Visible = false;
                dgHoadon_bhyt.Columns["Column9"].Visible = false;
                chkAll.Visible = false;
                chkAll_hoadon.Visible = false;
                butTonghop_Click(null, null);
                txtkyhieu.Text = "";
                txtSBL1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ammyy = m_v.get_mmyy(txtNgaythu.Text.Substring(0,10));
            m_frmprinthd.f_Print_Bienlaitaichinh_chitiet(!chkIN.Checked, m_id, ammyy);
            //f_in_phieuyeucauHD();
            //m_frmprinthd.f_Print_BienlaiNGT_HDTC(!chkIN.Checked, m_id, m_v.get_mmyy(m_ngaythu.Substring(0, 10)), "1", m_mabn, m_ngaythu.Substring(0, 10), m_sothe, cmbTraituyen.SelectedIndex, decimal.Parse(toolStrip_Tongcong.Text), txtkyhieu.Text, txtSBL.Text, txttenDV.Text, txtMST.Text, txtGTGT.Text);
            //m_frmprinthd.f_Print_Bienlaitaichinh_1(!chkIN.Checked, m_id, ammyy);
        }

        private void chkAll_hoadon_CheckedChanged(object sender, EventArgs e)
        {
            CurrencyManager mc = (CurrencyManager)BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember];
            DataView dv = (DataView)mc.List;
            string exp = "true";
            if (txttinnhanh.Text.Trim() != "Tìm kiếm")
            {
                exp = " hoten like '%" + txttinnhanh.Text.Trim() + "%' or mabn like '%" + txttinnhanh.Text.Trim() + "%'";
            }

            foreach (DataRow r in dv.Table.Select(exp))
            {
                r["chon"] = chkAll_hoadon.Checked ? "1" : "0";
            }
            //dgDanhsach.Refresh();
            f_Load_Hoadon_thuroi_BHYT("","","","","");

        }

        private void txtTennguoinhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtDiachinhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtngayhen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void dgDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
    }
}
