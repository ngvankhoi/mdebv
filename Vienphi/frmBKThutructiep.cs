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

namespace Vienphi
{
    public partial class frmBKThutructiep : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_userid = "";
        private string m_menu_id = "menu_B_1_Danhsachbenhnhan";
        private bool bKetxuatExcel = true;
        private LibVP.AccessData m_v;
        private string m_idcomputer = "";
        public frmBKThutructiep(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                m_userid = v_userid;
                m_v = v_v;
                f_Load_Data();               
                m_v.f_SetEvent(this);
            }
            catch
            {
            }
        }
        private void frmBKThutructiep_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            f_Check(dgUser, m_userid);
            f_Load_CB_Maubaocao();
            m_idcomputer = m_v.get_dmcomputer().ToString().PadLeft(6, '0');
            chkGio_CheckedChanged(null,null);            
            chkkhoacuoi.Checked = m_v.Thongso("bangkethutt_khoacuoi") == "1";
            radCothe_CheckedChanged(null, null);
            
            if (!System.IO.Directory.Exists("..\\..\\Datareport\\"))
            {
                System.IO.Directory.CreateDirectory("..\\..\\Datareport\\");
            }
            if (!System.IO.Directory.Exists("..\\..\\..\\Report\\"))
            {
                System.IO.Directory.CreateDirectory("..\\..\\..\\Report\\");
            }
        }
        private DataSet f_Get_Maubaocaotructiep()
        {
            //v_maubaocao 
            //loai=7: Báo cáo chi tiết
            DataSet ads = new DataSet();
            try
            {     
                ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=1");
                DataRow r = ads.Tables[0].NewRow();
                r["ma"] = "";
                r["ten"] = lan.Change_language_MessageText("Mẫu báo cáo chung");
                ads.Tables[0].Rows.InsertAt(r, 0);
            }
            catch
            {
            }
            return ads;
        }
        private void f_Load_CB_Maubaocao()
        {
            try
            {
                DataSet ads = new DataSet();
                ads = f_Get_Maubaocaotructiep();
                cbMaubaocao.DisplayMember = "TEN";
                cbMaubaocao.ValueMember = "MA";
                cbMaubaocao.DataSource = ads.Tables[0];
                cbMaubaocao.SelectedIndex = 0;
            }
            catch
            {
            }
        }


        private void f_Load_Tree_Doituong()
        {
            try
            {
                f_Load_Tree(tree_Doituong, m_v.get_data("select to_char(madoituong) as ma, doituong as ten from medibv.doituong order by madoituong"));
            }
            catch
            {
            }
        }
        private void f_Load_Tree_Quyenso()
        {
            try
            {
                string aexp = "", sql = "";
                if (txtTimso.Text.Trim() != lan.Change_language_MessageText("Tìm nhanh") && txtTimso.Text.Trim() != "")
                {
                    aexp = " and upper(sohieu) like '%" + txtTimso.Text.Trim().ToUpper() + "%'";
                }
                sql = "select id as ma, sohieu as ten from medibv.v_quyenso where hide=0 " + aexp + " order by sohieu asc";
                f_Load_Tree(tree_Quyenso, m_v.get_data(sql));
            }
            catch
            {
            }
        }
        private void f_Load_Tree(TreeView v_tree, DataSet v_ds)
        {
            try
            {
                TreeNode anode;
                v_tree.Nodes.Clear();
                v_tree.Sorted = false;
                for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
                {
                    anode = new TreeNode(v_ds.Tables[0].Rows[i]["ten"].ToString());
                    anode.Tag = v_ds.Tables[0].Rows[i]["ma"].ToString();
                    v_tree.Nodes.Add(anode);
                }
            }
            catch
            {
            }
        }
        private void f_Load_tree_LoaiDV()
        {
            try
            {

                f_Load_Tree(tree_LoaiDV, m_v.get_data("select to_char(ma,'9') as ma, ten from medibv.v_tenloaivp order by ten asc"));
            }
            catch
            {
            }
        }

        private void f_Load_tree_LoaiBN()
        {
            try
            {
                DataSet ads = new DataSet();
                ads = m_v.get_data("select to_char(id,'9') ma, ten from medibv.v_loaibn order by id");
                f_Load_Tree(tree_LoaiBN, ads);
            }
            catch
            {
            }
        }
        private void f_Load_tree_KP()
        {
            try
            {
                f_Load_Tree(tree_KP, m_v.get_data("select makp as ma, tenkp as ten from medibv.btdkp_bv order by loai, tenkp"));
            }
            catch
            {
            }
        }
        private void f_Load_tree_LoaiVP()
        {
            try
            {
                f_Load_Tree(tree_LoaiVP, m_v.get_data("select id as ma, ten as ten from medibv.v_loaivp order by id, ten"));
            }
            catch
            {
            }
        }
   
        private void f_Load_Data()
        {
            try
            {               
                txtThuquy.Text = m_v.sys_thuquy;
                txtKetoanvp.Text = m_v.sys_ketoanvp;
                txtPhongtckt.Text = m_v.sys_phongtckt;
                bool bAdmin = false;    
                try
                {
                    foreach (DataRow rr in m_v.get_data("select hoten, admin from medibv.v_dlogin where id=" + m_userid).Tables[0].Rows)
                    {
                        txtNguoilapphieu.Text = rr["hoten"].ToString();
                        bAdmin = rr["admin"].ToString() == "1";
                        break;
                    }
                }
                catch
                {
                }
                txtThang.Value = decimal.Parse(DateTime.Now.Month.ToString());
                txtNam.Value = decimal.Parse(DateTime.Now.Year.ToString());
                rdThang_CheckedChanged(null, null);
                txtTN.Value = m_v.s_server_date;
                txtDN.Value = txtTN.Value;

                string asql = "";
                asql = "select 0 as chon,hoten,userid,id from medibv.v_dlogin ";
                if (m_v.sys_Loctheonguoidangnhap && !bAdmin) asql += " where id =" + m_userid + "";
                asql += " order by hoten";
                dgUser.DataSource = m_v.get_data(asql).Tables[0];
             
                f_Load_Tree_Quyenso();
                f_Load_Tree_Doituong();
                f_Load_tree_LoaiBN();
                f_Load_tree_LoaiDV();
                f_Load_tree_KP();
                f_Load_tree_LoaiVP();
               
            }
            catch
            {
            }
        }
       
        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_Data();
        }
        private string f_Getchecked(DataGridView v_dgv)
        {
            try
            {
                string aid="";
                CurrencyManager cm = (CurrencyManager)(BindingContext[v_dgv.DataSource, v_dgv.DataMember]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Rows)
                {
                    if (r["chon"].ToString() == "1")
                    {
                        aid += ",";
                        aid += r["id"].ToString().Trim();
                    }
                }
                aid = aid.Trim(',');
                return aid;
            }
            catch
            {
                return "";
            }
        }
        private DataSet f_Get_Data()
        {
            DataSet ads = null, adsh = null,adst=null;
            string ammyy = "";
            try
            {
                string asql = "",  aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aloaivp = "";
                
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);

                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_LoaiBN);
                aloaidv = f_Get_CheckID(tree_LoaiDV);
                amakp = f_Get_CheckID(tree_KP);
                aloaivp = f_Get_CheckID(tree_LoaiVP);
                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and b.madoituong in("+adoituong+")";
                }
                if (amakp != "" && chkkhoacuoi.Checked )
                {
                    aexp += " and a.makp in (" + amakp + ")";
                }
                else if (amakp != "" && chkkhoacuoi.Checked==false)
                {
                    aexp += " and b.makp in (" + amakp + ")";
                }
             
                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    if (decimal.Parse(txtTuso.Text.Trim()) > decimal.Parse(txtDenso.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTuso.Focus();
                        return null;
                    }
                    else
                    {
                        aexp += " and a.sobienlai between " + txtTuso.Text.Trim() + " and " + txtDenso.Text.Trim() + "";
                    }
                }

                aexp = "where " + aexp.Trim();

                asql = "select a.id, a.mabn, a.mavaovien, a.maql, a.loai, i.ten as ten_loaivp, a.loaibn, a.hoten, a.namsinh, a.diachi, to_char(a.ngay,'dd/mm/yyyy') as ngay, nvl(sum((b.soluong*b.dongia)),0) as sotien, 0 as tamung,"+
                    "sum(to_number((case when b.madoituong=1 then nvl(b.mien,0) else 0 end))) as bhyt, case when c.sotien is null then 0 else c.sotien end as mien, thieu, sum(b.tra) tra, d.hoten as user_hoten, "+
                    " d.userid as user_username, a.userid, a.quyenso, a.sobienlai, e.sohieu, e.sohieubl, to_number(0,'9') as hoan, g.tenkp,b.vat,j.msthue";
                asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 ";// inner join medibv.v_giavp f on b.mavp=f.id inner join medibv.btdkp_bv g on a.makp=g.makp inner join medibv.v_tenloaivp i on a.loai=i.ma " + aexp + "";
                asql += " inner join (select id as mavp,id_loai from medibv.v_giavp union all ( select a.id as mavp,b.loaivp as id_loai from medibv.d_dmbd a left join medibv.d_dmnhom b on a.manhom=b.id)) f on b.mavp=f.mavp left join medibv.btdbn j on a.mabn=j.mabn ";                
                if(chkkhoacuoi.Checked==false) asql += " left join medibv.btdkp_bv g on b.makp=g.makp";
                else asql += " left join medibv.btdkp_bv g on a.makp=g.makp";
                asql += " inner join medibv.v_tenloaivp i on a.loai=i.ma " + aexp + "";
                if (aloaivp != "") asql += " and f.id_loai in(" + aloaivp + ")";         
                if (radCothe.Checked) asql += " and a.done=2 ";
                if (radKhongthe.Checked) asql += " and a.done<>2 ";
                asql += " group by a.id,a.mabn,a.mavaovien,a.maql,a.loai,i.ten,a.loaibn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy'),case when c.sotien is null then 0 else c.sotien end,thieu,d.hoten, d.userid,a.userid, a.quyenso, a.sobienlai, e.sohieu, e.sohieubl,g.tenkp,b.vat,j.msthue ";
                if (chkTTRV.Checked)
                {
                    asql += " union all";
                    asql += " select a.id,c.mabn,c.mavaovien,c.maql,a.loai,i.ten as ten_loaivp,a.loaibn,k.hoten,k.namsinh,k.sonha||' '||k.thon ||' '||l.tenpxa||' '||m.tenquan ||' '||n.tentt as diachi,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong*b.dongia) as sotien,a.tamung,"+
                        "a.bhyt, a.mien,thieu,sum(b.tra) as tra,f.hoten as user_hoten, f.userid as user_username,a.userid, a.quyenso, a.sobienlai, g.sohieu, g.sohieubl,to_number(0,'9') as hoan,h.tenkp,b.vat,k.msthue ";
                    asql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibvmmyy.v_ttrvds c on a.id=c.id left join medibvmmyy.v_miennoitru d on a.id=d.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id left join medibv.v_dlogin f on a.userid=f.id left join medibv.v_quyenso g on a.quyenso=g.id and g.hide=0 ";
                    if (chkkhoacuoi.Checked == false) asql += "left join medibv.btdkp_bv h on b.makp=h.makp";
                    else asql += "left join medibv.btdkp_bv h on a.makp=h.makp";
                    asql += " inner join medibv.v_tenloaivp i on a.loai=i.ma inner join medibv.btdbn k on c.mabn=k.mabn inner join medibv.btdtt n on k.matt=n.matt inner join medibv.btdquan m on k.maqu=m.maqu inner join medibv.btdpxa l on k.maphuongxa=l.maphuongxa ";
                    asql += " inner join (select id as mavp,id_loai from medibv.v_giavp union all ( select a.id as mavp,b.loaivp as id_loai from medibv.d_dmbd a left join medibv.d_dmnhom b on a.manhom=b.id )) q on b.mavp=q.mavp";
                    asql += " " + aexp + "";
                    if (aloaivp != "") asql += " and q.id_loai in(" + aloaivp + ")";
                    asql += " group by a.id,c.mabn,c.mavaovien,c.maql,a.loai,i.ten,a.loaibn,k.hoten,k.namsinh,k.sonha||' '||k.thon ||' '||l.tenpxa||' '||m.tenquan ||' '||n.tentt,to_char(a.ngay,'dd/mm/yyyy'),a.tamung,a.bhyt,a.mien,thieu,f.hoten, f.userid,a.userid, a.quyenso, a.sobienlai, g.sohieu, g.sohieubl,h.tenkp,b.vat,k.msthue ";
                }
                ads = m_v.get_data_mmyy(asql,txtTN.Text.Substring(0,10), txtDN.Text.Substring(0,10),true);
                #region
                if (rdBC_02.Checked || rdBC_03.Checked)//Bo hoan, Cong hoàn
                {
                    adsh = new DataSet();
                    asql = "select a.id,a.quyenso,a.sobienlai,to_char(a.ngay,'dd/mm/yyyy') as ngay, to_char(a.ngayud,'dd/mm/yyyy') as ngayud,a.mabn,a.mavaovien,a.maql,a.loai,a.loaibn,a.userid from medibvmmyy.v_hoantra a ";
                    //asql += " "+aexp+"";
                    asql += " where to_date(to_char(a.ngayud,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    adsh = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    if (ads != null && adsh!=null)
                    {
                        if (rdBC_02.Checked)//Bo hoan
                        {
                            foreach (DataRow r in adsh.Tables[0].Rows)
                            {
                                try
                                {

                                    foreach(DataRow r1 in ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "' and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() ))
                                    {
                                        ads.Tables[0].Rows.Remove(r1);
                                    }
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                        else
                        if (rdBC_03.Checked)//Cong hoan
                        {
                            foreach (DataRow r in adsh.Tables[0].Rows)
                            {
                                try
                                {
                                    ammyy = m_v.get_mmyy(r["ngayud"].ToString());
                                    aexp = "where " + "a.quyenso=" + r["quyenso"].ToString() + " and a.sobienlai=" + r["sobienlai"].ToString() + " and a.mabn='" + r["mabn"].ToString() + "' and a.mavaovien=" + r["mavaovien"].ToString() + " and a.maql=" + r["maql"].ToString() + " and a.loai=" + r["loai"].ToString() + " and a.loaibn=" + r["loaibn"].ToString();

                                    asql = "select a.id,a.mabn,a.mavaovien,a.maql,a.loai,i.ten as ten_loaivp,a.loaibn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong*b.dongia) as sotien,0 as tamung,0 as bhyt,case when c.sotien is null then 0 else c.sotien end as mien,thieu,sum(b.tra)as tra,d.hoten as user_hoten, d.userid as user_username,a.userid, a.quyenso, a.sobienlai, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(b.tra)as tra,k.tenkp ";
                                    asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 inner join medibv.v_giavp f on b.mavp=f.id inner join medibv.v_tenloaivp i on a.loai=i.ma  inner join medibv.btdkp_bv k on a.makp=k.makp " + aexp + "";
                                    if (aloaivp != "") asql += " and f.id_loai in(" + aloaivp + ")";
                                    asql += " group by a.id,a.mabn,a.mavaovien,a.maql,a.loai,i.ten,a.loaibn,a.hoten,a.namsinh,a.diachi,to_char(a.ngay,'dd/mm/yyyy'),case when c.sotien is null then 0 else c.sotien end,thieu,d.hoten, d.userid,a.userid, a.quyenso, a.sobienlai, e.sohieu, e.sohieubl,k.tenkp";

                                    if (chkTTRV.Checked)
                                    {
                                        aexp = "where " + "a.quyenso=" + r["quyenso"].ToString() + " and a.sobienlai=" + r["sobienlai"].ToString() + " and c.mabn='" + r["mabn"].ToString() + "' and c.mavaovien=" + r["mavaovien"].ToString() + " and c.maql=" + r["maql"].ToString() + " and a.loai=" + r["loai"].ToString() + " and a.loaibn=" + r["loaibn"].ToString();
                                        asql += " union all";

                                        asql += " select a.id,c.mabn,c.mavaovien,c.maql,a.loai,i.ten as ten_loaivp,a.loaibn,k.hoten,k.namsinh,k.sonha||' '||k.thon ||' '||l.tenpxa||' '||m.tenquan ||' '||n.tentt as diachi,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong*b.dongia) as sotien,a.tamung,a.bhyt, a.mien,thieu,sum(b.tra)as tra,f.hoten as user_hoten, f.userid as user_username,a.userid, a.quyenso, a.sobienlai, g.sohieu, g.sohieubl,to_number(0,'9') as hoan,sum(b.tra)as tra,h.tenkp ";
                                        asql += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibvmmyy.v_ttrvds c on a.id=c.id left join medibvmmyy.v_miennoitru d on a.id=d.id left join medibvmmyy.v_ttrvbhyt e on a.id=e.id left join medibv.v_dlogin f on a.userid=f.id left join medibv.v_quyenso g on a.quyenso=g.id and g.hide=0 inner join medibv.btdkp_bv h on a.makp=h.makp  inner join medibv.v_tenloaivp i on a.loai=i.ma inner join medibv.btdbn k on c.mabn=k.mabn inner join medibv.btdtt n on k.matt=n.matt inner join medibv.btdquan m on k.maqu=m.maqu inner join medibv.btdpxa l on k.maphuongxa=l.maphuongxa ";
                                        asql += " inner join (select id as mavp,id_loai from medibv.v_giavp union all ( select a.id as mavp,b.loaivp as id_loai from medibv.d_dmbd a left join medibv.d_dmnhom b on a.manhom=b.id ) q on b.mavp=q.mavp) ";
                                        asql += " " + aexp + "";
                                        if (aloaivp != "") asql += " and q.id_loai in(" + aloaivp + ")";
                                        asql += " group by a.id,c.mabn,c.mavaovien,c.maql,a.loai,i.ten,a.loaibn,k.hoten,k.namsinh,k.sonha||' '||k.thon ||' '||l.tenpxa||' '||m.tenquan ||' '||n.tentt,to_char(a.ngay,'dd/mm/yyyy'),a.tamung,a.bhyt,a.mien,thieu,f.hoten, f.userid,a.userid, a.quyenso, a.sobienlai, g.sohieu, g.sohieubl,h.tenkp ";

                                    }

                                    adst = m_v.get_data_mmyy(ammyy, asql);

                                    foreach (DataRow r1 in adst.Tables[0].Rows)
                                    {
                                        if (ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "' and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + " and loaibn=" + r["loaibn"].ToString() + " and userid=" + r["userid"].ToString()).Length <= 0)
                                        {
                                            ads.Tables[0].Rows.Add(r1.ItemArray);
                                        }

                                        foreach (DataRow r2 in ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "' and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + " and loaibn=" + r["loaibn"].ToString()))
                                        {
                                            r2["hoan"] = (r2["ngay"].ToString() == r["ngay"].ToString() ? 1 : 2);
                                            r2["ngay"] = r["ngay"].ToString();
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         
            return ads;
        }
        private DataSet f_BC_Nhom()
        {
            DataSet ads = null, ads_sk = null;
            DataRow r4, r5;
            DataRow[] dr;
            try
            {
                string asql = "", asql_sk = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                string aexp_mien_thieu = "";//binh

                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_LoaiBN);
                aloaidv = f_Get_CheckID(tree_LoaiDV);
                amakp = f_Get_CheckID(tree_KP);
                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a.loaibn in (" + aloaibn + ")";
                }
                
                if (amakp != "")
                {
                    aexp += " and a.makp in (" + amakp + ")";
                }
                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    aexp += " and a.sobienlai between " + txtTuso.Text.Trim() + " and " + txtDenso.Text.Trim() + "";
                }
                aexp_mien_thieu = aexp;
                if (adoituong != "")
                {
                    aexp += " and b.madoituong in(" + adoituong + ")";
                }
                aexp = "where " + aexp.Trim();
                aexp_mien_thieu = "where " + aexp_mien_thieu.Trim();//bi
                //v_giavp
                asql = " select stt,idnhom,ma,ten,sum(soluong) as soluong,sum(sotien) as sotien,sum(sotiengiamua) as sotiengiamua, sum(tyle) as sotiendichvu, sum(bhyttra) as bhyttra, sum(bntra) as bntra from (";
                asql += " select 1 as stt,g.ma as idnhom,g.matat as ma,g.ten";
                asql += ",sum(b.soluong- case when b.tra>0 then b.soluong else 0 end)  as soluong";
                asql += ",sum(b.soluong*b.dongia - b.tra) as sotien";
                asql += " ,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";//binh
                asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id ";//inner join medibv.v_giavp e on e.id=b.mavp inner join ";//medibv.v_loaivp f on e.id_loai=f.id inner join medibv.v_nhomvp g on g.ma=f.id_nhom";//binh
                //asql += " inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp";//binh
                asql += " inner join (select id, id_loai from medibv.v_giavp union all ( select a1.id as id, b1.loaivp as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id )) e on e.id=b.mavp";//gam
                asql += " inner join (select id, id_nhom,ma,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ma,'' ten from dual) f on e.id_loai=f.id";//binh
                asql += " inner join medibv.v_nhomvp g on g.ma=f.id_nhom ";//binh
                asql += " " + aexp + "";
                if (radCothe.Checked) asql += " and a.done=2 ";
                if (radKhongthe.Checked) asql += " and a.done<>2 ";
                asql += " group by g.matat,g.ten,g.ma";
                if ((adoituong == "" && chkMien.Checked) || (adoituong != "" && chkMien.Checked && m_v.get_data("select madoituong from medibv.doituong where mien>0 and madoituong in(" + adoituong + ")").Tables[0].Rows.Count > 0))
                {
                    asql += " union all";
                    asql += " select 8 as stt,to_number('-98') as id,'Mien' as ma,'Miễn' as ten ,to_number('0')  as soluong ,sum(b.sotien)*-1 as sotien,to_number('0') as sotiengiamua, to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_mienngtru b left join medibvmmyy.v_vienphill a on a.id=b.id inner join medibv.v_dlogin c on a.userid=c.id  ";
                    asql += " " + aexp_mien_thieu + "";

                    //bhyt ngoai tru
                    asql += " union all";
                    asql += " select 8 as stt,to_number('-97') as id,'BHYT' as ma,'BHYT' as ten ,to_number('0')  as soluong ,sum(to_number((case when b.madoituong=1 then nvl(b.mien,0) else 0 end)))*-1 as sotien,to_number('0') as sotiengiamua, to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 ";
                    asql += " " + aexp_mien_thieu + "";
                    //
                    //tinh theo user mien giam
                    // mien ngoai tru
                    asql += " union all";
                    asql += " select 6 as stt,0 as id, to_char(c.id) as ma,c.hoten as ten ,to_number('0')  as soluong, sum(b.sotien)*-1 as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_mienngtru b inner join medibvmmyy.v_vienphill a on a.id=b.id inner join medibv.v_dlogin c on a.userid=c.id  ";
                    asql += " " + aexp_mien_thieu + "";
                    asql += " group by to_char(c.id),c.hoten";

                    // bhyt ngoai tru
                    asql += " union all";
                    asql += " select 6 as stt,0 as id, to_char(d.id) as ma,d.hoten as ten ,to_number('0')  as soluong ,sum(to_number((case when b.madoituong=1 then nvl(b.mien,0) else 0 end)))*-1 as sotien,to_number('0') as sotiengiamua, to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 ";
                    asql += " " + aexp_mien_thieu + "";
                    asql += " group by to_char(d.id),d.hoten";
                    //
                }
                 
                if (chkTTRV.Checked)
                {
                    asql += " union all ";
                    asql += " select 1 as stt,f.id_nhom as idnhom,g.matat as ma,g.ten ,sum(b.soluong- case when b.tra>0 then b.soluong else 0 end)  as soluong";
                    asql += " ,sum(b.soluong*b.dongia-b.tra) as sotien";

                    asql += " ,sum((b.soluong- case when b.tra>0 then b.soluong else 0 end)*b.giamua) as sotiengiamua,sum((b.soluong*b.dongia -b.tra) - ((b.soluong - (case when b.tra>0 then b.soluong else 0 end))*case when b.giamua>0 then b.giamua else b.dongia end)) as tyle, sum(b.bhyttra) as bhyttra, sum(case when b.madoituong=1 then b.sotien-b.bhyttra else 0 end) as bntra ";
                    asql += "  from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_dlogin d on a.userid=d.id ";
                    //asql += " inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp";
                    asql += " inner join (select id, id_loai from medibv.v_giavp union all ( select a1.id as id, b1.loaivp as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id )) e on e.id=b.mavp";//gam
                    asql += " inner join (select id, id_nhom,ma,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ma,'' ten from dual) f on e.id_loai=f.id  inner join medibv.v_nhomvp g on g.ma=f.id_nhom";
                    asql += " " + aexp + "";
                    asql += " group by f.id_nhom,g.matat,g.ten";
                    asql += " union all ";
                    asql += "  select 6 as stt,0 as idnhom,to_char(c.id) as ma,c.hoten,0 as soluong";
                    
                    //asql += " ,sum(b.soluong*b.dongia-b.tra-b.bhyttra) as sotien";
                    asql += " ,sum(b.soluong*b.dongia - b.tra -(case when b.madoituong=1 and tra>0 then 0 else bhyttra end))-a.mien-a.thieu as sotien";                                        
                    asql += " ,sum((b.soluong- case when b.tra>0 then b.soluong else 0 end)*b.giamua) as sotiengiamua,sum((b.soluong*b.dongia -b.tra) - ((b.soluong - (case when b.tra>0 then b.soluong else 0 end))*case when b.giamua>0 then b.giamua else b.dongia end)) as tyle, sum(b.bhyttra) as bhyttra, sum(case when b.madoituong=1 then b.sotien-b.bhyttra else 0 end) as bntra  ";
                    asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c1 on a.id=c1.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id  left join medibv.v_dlogin c on a.userid=c.id";
                    asql += " " + aexp + "";
                    asql += " group by c.id,c.hoten, a.mien, a.thieu ";
                    //Binh Lay so tien thieu - mien cua BN rieng
                    if ((adoituong == "" && chkMien.Checked) || (adoituong != "" && chkMien.Checked && m_v.get_data("select madoituong from medibv.doituong where mien>0 and madoituong in(" + adoituong + ")").Tables[0].Rows.Count > 0))
                    {
                        //mien
                        asql += " union all";
                        asql += " select 8 as stt,to_number('-98') as id,'Mien' as ma,'Miễn' as ten";
                        asql += " ,to_number('0')  as soluong ,sum(a.mien)*-1 as sotien,sum(a.mien)*-1 as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                        asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                        asql += " " + aexp_mien_thieu + "";
                        asql += " and a.mien>0";
                        //thieu
                        asql += " union all";
                        asql += " select 8 as stt,to_number('-99') as id,'Thieu' as ma,'Thiếu' as ten";
                        asql += " ,to_number('0')  as soluong ,sum(a.thieu)*-1 as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra";
                        asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                        asql += " " + aexp_mien_thieu + "";
                        asql += " and a.thieu>0";
                        //end binh  
                        asql += " union all";
                        asql += " select 8 as stt,to_number('-97') as id,'BHYT' as ma,'BHYT' as ten";
                        //asql += " ,to_number('0')  as soluong ,sum(case when b.madoituong=1 then case when instr(nvl(cc.sothe,' '),'UC')>0 or instr(nvl(cc.sothe,' '),'VC')>0 or instr(nvl(cc.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end)*-1 as sotien, to_number('0') as sotiengiamua,to_number('0') as tyle";
                        asql += " ,to_number('0')  as soluong,  sum(case when b.madoituong=1 then (case when b.tra>0 then 0 else b.bhyttra end) else 0 end)*-1 as sotien, to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra ";
                        asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c1 on a.id=c1.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id  left join medibv.v_dlogin c on a.userid=c.id";
                        asql += " " + aexp_mien_thieu + "";
                        asql += " and a.bhyt>0";
                    }
                                        
                }
                if (chkTU.Checked)
                {
                    asql += " union all";
                    asql += " select 2 as stt,0 as idnhom,to_char(userid) as ma,to_char('Thu tiền tạm ứng') as ten, 0 as soluong,sum(sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_tamung where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(userid)";
                    //
                    asql += " union all";
                    asql += " select 3 as stt,0 as idnhom,to_char(userid) as ma,to_char('Hoàn tiền tạm ứng') as ten, 0 as soluong,-1*sum(sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_hoantra where ghichu='2' and  to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(userid)";
                    //
                    asql += " union all";
                    asql += " select 3 as stt,0 as idnhom,to_char(a.userid) as ma,to_char('Hoàn tiền tạm ứng') as ten, 0 as soluong,-1*sum(b.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_ttrvll a, medibv.vv_tamung"+m_idcomputer+" b where a.id=b.idttrv and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(a.userid)";
                    //
                    //cong vao user thu
                    //asql += " union all";
                    //asql += " select 6 as stt,0 as id,to_char(a.userid) as ma,b.hoten as ten, 0 as soluong,sum(a.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra";//binh
                    //asql += " from medibvmmyy.v_tamung a inner join medibv.v_dlogin b on a.userid=b.id where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    //if (auserid != "") asql += " and a.userid in (" + auserid + ")";
                    //asql += " group by to_char(a.userid), b.hoten";
                    ////Hoan tien tam ung
                    //asql += " union all";
                    //asql += " select 6 as stt,0 as id,to_char(a.userid) as ma,b.hoten as ten, 0 as soluong,-1* sum(a.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra";//binh
                    //asql += " from medibvmmyy.v_hoantra a inner join medibv.v_dlogin b on a.userid=b.id where ghichu='2' and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    //if (auserid != "") asql += " and a.userid in (" + auserid + ")";
                    //asql += " group by to_char(a.userid), b.hoten";
                    ////Hoan tien tam ung khi thanh toan ra vien                    
                    //asql += " union all";
                    //asql += " select 6 as stt,0 as id,to_char(a.userid) as ma,c.hoten as ten, 0 as soluong,-1*sum(b.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra ";
                    //asql += " from medibvmmyy.v_ttrvll a, medibv.vv_tamung" + m_idcomputer + " b, medibv.v_dlogin c where a.id=b.idttrv and a.userid=c.id and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    //if (auserid != "") asql += " and a.userid in (" + auserid + ")";
                    //asql += " group by to_char(a.userid),c.hoten";
                    //
                }
                asql += " union all ";
                asql += " select 6 as stt,0 as idnhom,to_char(c.id) as ma,c.hoten,0 as soluong,sum(b.soluong*b.dongia - b.thieu - b.tra) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b  on a.id=b.id left join medibv.v_dlogin c on a.userid=c.id";
                asql += " " + aexp + "";
                if (radCothe.Checked) asql += " and a.done=2 ";
                if (radKhongthe.Checked) asql += " and a.done<>2 ";
                asql += " group by c.id,c.hoten";
                asql += ")a group by stt,idnhom,ma,ten";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (chkKhamsuckhoe.Checked)
                {
                    asql = "select to_char(ngayud,'mmyyyy') as mmyy from medibv.ct_doan where id in(select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) group by to_char(ngayud,'mmyyyy')";
                    asql_sk = "  select 5 as stt,f.iddoan as idnhom,'' as ma,g.ten||'( '|| f.ten ||' )' as ten,to_number(0) as soluong,sum(a.dongia) as sotien,to_number('0') as sotiengiamua";
                    asql_sk += " from medibvmmyy.ct_chitiet a inner join medibv.ct_giavp b on a.mavp=b.id inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id inner join medibvmmyy.ct_ketqua e on a.id=e.id inner join medibv.ct_donvi f on e.iddonvi=f.id inner join medibv.ct_doan g on f.iddoan=g.id";
                    asql_sk += " where quyettoan>0 and ketqua is not null and ketqua <> '' and to_date(to_char(ngayqt,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and f.iddoan in (select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy'))";
                    asql_sk += " group by f.iddoan,g.ten||'( '|| f.ten ||' )' ";
                    foreach (DataRow r in m_v.get_data(asql).Tables[0].Rows)
                    {
                        ads_sk = m_v.get_data_mmyy(r["mmyy"].ToString().Substring(0, 2).ToString() + r["mmyy"].ToString().Substring(4, 2).ToString() + "", asql_sk);
                        if (ads_sk != null && ads_sk.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow r1 in ads_sk.Tables[0].Rows)
                            {
                                r4 = m_v.getrowbyid(ads.Tables[0], "stt=7 and ten='" + r1["ten"].ToString() + "'");
                                if (r4 == null)
                                {
                                    r5 = ads.Tables[0].NewRow();
                                    r5["stt"] = 7;
                                    r5["idnhom"] = decimal.Parse(r1["idnhom"].ToString());
                                    r5["ma"] = r1["ma"].ToString();
                                    r5["ten"] = r1["ten"].ToString();
                                    r5["soluong"] = 0;
                                    r5["sotien"] = decimal.Parse(r1["sotien"].ToString());
                                    r5["sotiengiamua"] = 0;
                                    r5["sotiendichvu"] = 0;
                                    ads.Tables[0].Rows.Add(r5);
                                }
                                else
                                {
                                    dr = ads.Tables[0].Select("stt=7 and ten='" + r1["ten"].ToString() + "'");
                                    if (dr.Length > 0)
                                    {
                                        dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }

                if (chkKhamsuckhoe.Checked)
                {
                    asql = "select to_char(ngayud,'mmyyyy') as mmyy from medibv.ct_doan where id in(select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) group by to_char(ngayud,'mmyyyy')";
                    asql_sk = " select 1 as stt,e.ma as idnhom,e.matat,e.ten,count(c.id) as soluong,sum(a.dongia) as sotien,to_number('0') as sotiengiamua ";//binh
                    asql_sk += " from medibvmmyy.ct_chitiet a inner join medibvmmyy.ct_ketqua e on a.id=e.id inner join medibv.ct_donvi f on e.iddonvi=f.id inner join medibv.ct_doan g on f.iddoan=g.id inner join medibv.ct_giavp b on a.mavp=b.id inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id inner join medibv.v_nhomvp e on d.id_nhom=e.ma";
                    asql_sk += " where quyettoan>0 and to_date(to_char(ngayqt,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and f.iddoan in(select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy'))";                  
                    asql_sk += " group by e.ma,e.matat,e.ten";
                    foreach (DataRow r in m_v.get_data(asql).Tables[0].Rows)
                    {
                        ads_sk = m_v.get_data_mmyy(r["mmyy"].ToString().Substring(0, 2).ToString() + r["mmyy"].ToString().Substring(4, 2).ToString() + "", asql_sk);
                        if (ads_sk != null && ads_sk.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow r1 in ads_sk.Tables[0].Rows)
                            {
                                r4 = m_v.getrowbyid(ads.Tables[0], "stt=1 and idnhom=" + r1["idnhom"].ToString() + "");
                                if (r4 == null)
                                {
                                    r5 = ads.Tables[0].NewRow();
                                    r5["stt"] = 1;
                                    r5["idnhom"] = decimal.Parse(r1["idnhom"].ToString());
                                    r5["ma"] = r1["ma"].ToString();
                                    r5["ten"] = r1["ten"].ToString();
                                    r5["soluong"] = decimal.Parse(r1["soluong"].ToString());
                                    r5["sotien"] = decimal.Parse(r1["sotien"].ToString());
                                    r5["sotiengiamua"] = decimal.Parse(r1["sotiengiamua"].ToString());
                                    r5["sotiendichvu"] = 0;
                                    ads.Tables[0].Rows.Add(r5);
                                }
                                else
                                {
                                    dr = ads.Tables[0].Select("stt=1 and idnhom=" + r1["idnhom"].ToString() + "");
                                    if (dr.Length > 0)
                                    {
                                        dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r1["soluong"].ToString());
                                        dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                //if (chkTU.Checked)
                //{
                //    asql = "select 2 as stt,0 as idnhom,to_char(userid) as ma,to_char('Thu tiền tạm ứng') as ten, 0 as soluong,sum(sotien) as sotien,to_number('0') as sotiengiamua ";//binh
                //    if (chkGio.Checked)
                //    {
                //        asql += " from medibvmmyy.v_tamung where to_date(to_char(ngayud,'dd/mm/yyyy'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                //    }
                //    else
                //    {
                //        asql += " from medibvmmyy.v_tamung where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                //    }
                //    if (auserid != "") asql += " and userid in (" + auserid + ")";
                //    asql += " group by to_char(userid)";
                //    //
                //    //
                //    asql += " union all";
                //    asql += " select 3 as stt,0 as idnhom,to_char(userid) as ma,to_char('Hoàn tiền tạm ứng') as ten, 0 as soluong,-1*sum(sotien) as sotien,to_number('0') as sotiengiamua ";
                //    asql += " from medibvmmyy.v_hoantra where ghichu='2' and  to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                //    if (auserid != "") asql += " and userid in (" + auserid + ")";
                //    asql += " group by to_char(userid)";
                //    //
                //    //
                //    asql += " union all";
                //    asql += " select 3 as stt,0 as idnhom,to_char(a.userid) as ma,to_char('Hoàn tiền tạm ứng') as ten, 0 as soluong,-1*sum(b.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle ";
                //    asql += " from medibvmmyy.v_ttrvll a, medibv.vv_tamung" + m_idcomputer + " b where a.id=b.idttrv and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                //    if (auserid != "") asql += " and userid in (" + auserid + ")";
                //    asql += " group by to_char(a.userid)";
                //    ads_tu = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                //    if (ads_tu != null)
                //    {
                //        if (ads == null)
                //        {
                //            ads = ads_tu;                            
                //        }
                //        else 
                //        {                         
                //            foreach (DataRow r1 in ads.Tables[0].Select("stt=2"))
                //            {
                //                foreach (DataRow r_tu in ads_tu.Tables[0].Select("ma=" + r1["ma"].ToString() + "")) 
                //                {
                //                    st1 = 0; st2 = 0;
                //                    st1 = decimal.Parse(r_tu["sotien"].ToString());
                //                    st2 = decimal.Parse(r1["sotien"].ToString());
                //                    st2 = st2 + st1;
                //                    r1["sotien"] = st2;
                //                    ads.AcceptChanges();
                //                }
                //            }
                            
                //        }
                //    }
                //}
            }
            catch
            {
            }
            //ads.WriteXml(@"..\nhomvp.xml", XmlWriteMode.WriteSchema);
            return ads;
        }
        private DataSet f_BC_Loai_Chitiet()
        {
            DataSet ads = null, ads_sk = null;
            DataRow r4, r5;
            DataRow[] dr;
            try
            {
                string asql = "", asql_sk = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aloaivp = "";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_LoaiBN);
                aloaidv = f_Get_CheckID(tree_LoaiDV);
                aloaivp = f_Get_CheckID(tree_LoaiVP);
                amakp = f_Get_CheckID(tree_KP);
                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = " to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and b.madoituong in(" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a.makp in (" + amakp + ")";
                }
                if (aloaivp != "")
                {
                    aexp += " and e.id_loai in(" + aloaivp + ")";
                }

                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    aexp += " and a.sobienlai between " + txtTuso.Text.Trim() + " and " + txtDenso.Text.Trim() + "";
                }
                aexp = "where " + aexp.Trim();
                string aexp_mien = "";
                
                ////***************__________
                if (chkTTRV.Checked)
                {
                    asql = "select idloai,idgia,ma, tenloai,sum(soluong)as soluong,sum(sotien) as sotien,tengia, mien from ( ";
                    asql += " select f.id as idloai,e.id as idgia,e.ma,f.ten as tenloai,sum(b.soluong-case when b.tra>0 then b.soluong else 0 end)as soluong";
                    asql += " ,sum(b.soluong*b.dongia-b.tra) as sotien";
                    asql += " , e.ten as tengia, to_number('0') as mien";
                }
                else
                {
                    asql = " select f.id as idloai,e.id as idgia,e.ma,f.ten as tenloai,sum(b.soluong-case when b.tra>0 then b.soluong else 0 end)as soluong,sum(b.soluong*b.dongia-b.tra) as sotien, e.ten as tengia, to_number('0') as mien";
                }
                asql+=" from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibv.v_dlogin d on a.userid=d.id ";
                //asql += " inner join (select id, id_loai,ma,ten from medibv.v_giavp union all select id, id_loai,ma,ten from (select a1.id as id, c1.id_loai as id_loai,a1.ma,a1.ten from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id ";
                //asql += " left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp ";
                asql += "inner join (select id, id_loai,ma,ten from medibv.v_giavp union all (select a1.id as id, b1.loaivp as id_loai,a1.ma,a1.ten from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id ))e on e.id=b.mavp ";
                asql += " inner join (select id, id_nhom,ma,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ma,'' ten from dual) f on e.id_loai=f.id";
                asql += " " + aexp + " ";
                if (radCothe.Checked) asql += " and a.done=2 ";
                if (radKhongthe.Checked) asql += " and a.done<>2 ";
                asql += " group by f.id,e.id,e.ma,f.ten,e.ten";
                if ((adoituong == "" && chkMien.Checked) || (chkMien.Checked && adoituong != "" && aexp_mien != ""))
                {
                    // miễn ngoại trú
                    asql += " union all";
                    asql += " select to_number('0') as idloai,to_number('0') as idgia,'' as ma,'' as tenloai,to_number('0') as soluong,to_number('0') as sotien,'' as tengia, sum(a.sotien) as mien";
                    asql += " from medibvmmyy.v_mienngtru a left join medibvmmyy.v_vienphill b on a.id=b.id inner join medibv.v_dlogin c on b.userid=c.id ";
                    asql += " where  to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid.Trim() != "") asql += " and b.userid in (" + auserid + ")";
                    // bhyt ngoại trú ---sum(to_number((case when b.madoituong=1 then nvl(b.mien,0) else 0 end)))
                    asql += " union all";
                    asql += " select to_number('0') as idloai,to_number('0') as idgia,'' as ma,'' as tenloai,to_number('0') as soluong,to_number('0') as sotien,'' as tengia,sum(to_number((case when b.madoituong=1 then nvl(b.mien,0) else 0 end))) as mien ";
                    asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 ";
                    if (auserid.Trim() != "") asql += " and a.userid in (" + auserid + ")";
                }
               //--------****************----------------
                if (chkTTRV.Checked)//319828  : 27: Cls,  
                {
                    asql += " union all";
                    asql += "  select f.id as idloai,e.id as idgia,e.ma,f.ten as tenloai,sum(b.soluong-case when b.tra>0 then b.soluong else 0 end)as soluong";
                    asql += " ,sum(b.soluong*b.dongia-b.tra) as sotien";
                    asql += " , e.ten as tengia, to_number('0') as mien ";
                    asql += "  from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id inner join medibv.v_dlogin d on a.userid=d.id ";
                    //asql += " inner join (select id, id_loai,ma,ten from medibv.v_giavp union all select id, id_loai,ma,ten from (select a1.id as id, c1.id_loai as id_loai,a1.ma,a1.ten from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp ";
                    asql += " inner join (select id, id_loai,ma,ten from medibv.v_giavp union all ( select a1.id as id, b1.loaivp as id_loai,a1.ma,a1.ten from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id )) e on e.id=b.mavp ";
                    asql += " inner join (select id, id_nhom,ma,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ma,'' ten from dual) f on e.id_loai=f.id";
                    asql += " " + aexp + " ";
                    asql += " group by f.id,e.id,e.ma,f.ten,e.ten";
                    if ((adoituong == "" && chkMien.Checked) || (chkMien.Checked && adoituong != "" && aexp_mien != ""))
                    {
                        asql += " union all";
                        asql += " select to_number('0') as idloai,to_number('0') as idgia,'' as ma,'' as tenloai,to_number('0') as soluong,to_number('0') as sotien,'' as tengia,sum(mien) as mien";
                        asql += "  from medibvmmyy.v_ttrvll where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                        if (auserid.Trim() != "") asql += " and userid in (" + auserid + ")";

                        asql += " union all";
                        asql += " select to_number('0') as idloai,to_number('0') as idgia,'' as ma,'' as tenloai,to_number('0') as soluong,to_number('0') as sotien,'' as tengia,sum(thieu) as mien";
                        asql += "  from medibvmmyy.v_ttrvll where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                        if (auserid.Trim() != "") asql += " and userid in (" + auserid + ")";

                        asql += " union all";
                        asql += " select to_number('0') as idloai,to_number('0') as idgia,'' as ma,'' as tenloai,to_number('0') as soluong,to_number('0') as sotien,'' as tengia,sum(case when b.madoituong=1 then case when instr(nvl(cc.sothe,' '),'UC')>0 or instr(nvl(cc.sothe,' '),'VC')>0 or instr(nvl(cc.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end) as mien";
                        asql += "  from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id inner join medibv.v_dlogin d on a.userid=d.id ";
                        asql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                        if (auserid.Trim() != "") asql += " and a.userid in (" + auserid + ")";
                    }
                    asql += ") a group by idloai, idgia,ma,tenloai, tengia, mien ";
                }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                #region Kham suc khoe
                if (chkKhamsuckhoe.Checked)
                {
                    asql = "select to_char(ngayud,'mmyyyy') as mmyy from medibv.ct_doan where id in(select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) group by to_char(ngayud,'mmyyyy')";
                    asql_sk = " select d.id as idloai,c.id as idgia,c.ma,d.ten as tenloai,to_number(count(c.id))as soluong,sum(a.dongia) as sotien,c.ten as tengia,to_number('0') as mien";
                    asql_sk += " from medibvmmyy.ct_chitiet a inner join medibvmmyy.ct_ketqua e on a.id=e.id inner join medibv.ct_donvi f on e.iddonvi=f.id inner join medibv.ct_giavp b on a.mavp=b.id inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id";
                    asql_sk += " where quyettoan>0 and ketqua is not null and ketqua <> '' and to_date(to_char(ngayqt,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and f.iddoan in(select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy'))";
                    if (aloaivp != "") asql_sk += " and c.id_loai in(" + aloaivp + ")";
                    asql_sk += " group by d.id,c.id,c.ma,d.ten,c.ten";
                    foreach (DataRow r in m_v.get_data(asql).Tables[0].Rows)
                    {
                        ads_sk = m_v.get_data_mmyy(r["mmyy"].ToString().Substring(0, 2).ToString() + r["mmyy"].ToString().Substring(4, 2).ToString() + "", asql_sk);
                        foreach (DataRow r1 in ads_sk.Tables[0].Rows)
                        {
                            r4 = m_v.getrowbyid(ads.Tables[0], "idloai=" + r1["idloai"].ToString() + " and idgia=" + r1["idgia"].ToString() + "");
                            if (r4 == null)
                            {
                                r5 = ads.Tables[0].NewRow();
                                r5["idloai"] = r1["idloai"].ToString();
                                r5["idgia"] = r1["idgia"].ToString();
                                r5["ma"] = r1["ma"].ToString();
                                r5["tenloai"] = r1["tenloai"].ToString();
                                r5["soluong"] = decimal.Parse(r1["soluong"].ToString());
                                r5["sotien"] = decimal.Parse(r1["sotien"].ToString());
                                r5["tengia"] = r1["tengia"].ToString();
                                r5["mien"] = decimal.Parse(r1["mien"].ToString());
                                ads.Tables[0].Rows.Add(r5);
                            }
                            else
                            {
                                dr = ads.Tables[0].Select("idloai=" + r1["idloai"].ToString() + " and idgia=" + r1["idgia"].ToString() + "");
                                if (dr.Length > 0)
                                {
                                    dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r1["soluong"].ToString());
                                    dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString());
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            catch
            {
            }
            return ads;
        }
       
        private DataSet f_BC_Loai()
        {
            DataSet ads = null, ads_sk = null;
            DataRow r4, r5;
            DataRow[] dr;
            try
            {
                string asql = "", asql_sk = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aloaivp = "";
                string aexp_mien_thieu = "";//binh
                decimal  st1, st2;
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_LoaiBN);
                aloaidv = f_Get_CheckID(tree_LoaiDV);
                aloaivp = f_Get_CheckID(tree_LoaiVP);
                amakp = f_Get_CheckID(tree_KP);
                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a.loaibn in (" + aloaibn + ")";
                }                
                if (amakp != "")
                {
                    aexp += " and a.makp in (" + amakp + ")";
                }               
                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    aexp += " and a.sobienlai between " + txtTuso.Text.Trim() + " and " + txtDenso.Text.Trim() + "";
                }
                if (adoituong != "")
                {
                    aexp_mien_thieu = aexp;//binh
                    aexp += " and b.madoituong in(" + adoituong + ")";
                }
                else
                {
                    aexp_mien_thieu = aexp;//binh
                }
                aexp = "where " + aexp.Trim();
                aexp_mien_thieu = "where " + aexp_mien_thieu.Trim();
                asql = "select stt,id,ma,ten ,sum (soluong) as soluong, sum(sotien) as sotien,sum(sotiengiamua) as sotiengiamua,sum(tyle) as sotiendichvu, sum(bhyttra) as bhyttra, sum(bntra) as bntra from (";
                asql += " select 1 as stt,f.id,f.ma,f.ten";
                asql += " ,sum(b.soluong- case when b.tra>0 then b.soluong else 0 end)  as soluong";
                asql += " ,sum(b.soluong*b.dongia - b.tra) as sotien";//binh
                //asql += " ,nvl(sum((b.soluong*b.dongia)),0) as sotien";
                asql += " ,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra";//binh
                asql += "  from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibv.v_dlogin d on a.userid=d.id ";//inner join medibv.v_giavp e on e.id=b.mavp inner join medibv.v_loaivp f on e.id_loai=f.id";//binh
                //asql += " inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp";//binh
                asql += " inner join (select id, id_loai from medibv.v_giavp union all ( select a1.id as id, b1.loaivp as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id )) e on e.id=b.mavp";//gam
                asql += " inner join (select id, id_nhom,ma,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ma,'' ten from dual) f on e.id_loai=f.id";//binh
                asql += " " + aexp + " ";
                if (aloaivp != "") asql += " and e.id_loai in(" + aloaivp + ")";
                if (radCothe.Checked) asql += " and a.done=2 ";
                if (radKhongthe.Checked) asql += " and a.done<>2 ";
                asql += "group by f.ma,f.id,f.ten";
                asql += " union all";
                asql += " select 6 as stt,0 as id,to_char(c.id) as ma,c.hoten,0 as soluong";
                asql += " ,sum(b.soluong*b.dongia - b.thieu - b.tra) as sotien";//binh
                //asql += " ,nvl(sum((b.soluong*b.dongia)),0) as sotien";
                asql += " ,to_number('0',9) as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra";//binh
                //asql += " select 6 as stt,0 as id,to_char(c.id) as ma,c.hoten,0 as soluong,sum(b.soluong*b.dongia - b.thieu - b.tra) as sotien,sum(b.soluong*b.dongia - b.thieu - b.tra) as sotiengiamua";//khanh
                asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b  on a.id=b.id left join medibv.v_dlogin c on a.userid=c.id";// inner join medibv.v_giavp d on b.mavp=d.id ";//binh
                asql += " inner join (select id, id_loai from medibv.v_giavp union all ( select a1.id as id, b1.loaivp as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id )) e on e.id=b.mavp";//gam
                //asql += " left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp";//binh
                asql += " inner join (select id, id_nhom,ma,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ma,'' ten from dual) f on e.id_loai=f.id";//binh
                asql += " " + aexp + "";
                if (aloaivp != "") asql += " and d.id_loai in(" + aloaivp + ")";
                if (radCothe.Checked) asql += " and a.done=2 ";
                if (radKhongthe.Checked) asql += " and a.done<>2 ";
                 asql += " group by c.id,c.hoten";
                if ((adoituong == "" && chkMien.Checked) || (adoituong != "" && chkMien.Checked && m_v.get_data("select madoituong from medibv.doituong where mien>0 and madoituong in(" + adoituong + ")").Tables[0].Rows.Count > 0))
                {
                    // mien ngoai tru
                    asql += " union all";
                    asql += " select 8 as stt,to_number('-98') as id,'Mien' as ma,'Miễn' as ten ,to_number('0')  as soluong, sum(b.sotien)*-1 as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_mienngtru b left join medibvmmyy.v_vienphill a on a.id=b.id inner join medibv.v_dlogin c on a.userid=c.id  ";
                    asql += " " + aexp_mien_thieu + " group by to_char(c.id),c.hoten ";

                    // bhyt ngoai tru
                    asql += " union all";
                    asql += " select 8 as stt,to_number('-97') as id,'BHYT' as ma,'BHYT' as ten ,to_number('0')  as soluong ,sum(to_number((case when b.madoituong=1 then nvl(b.mien,0) else 0 end)))*-1 as sotien,to_number('0') as sotiengiamua, to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 ";
                    asql += " " + aexp_mien_thieu + " group by to_char(d.id),d.hoten "; // gam 09-05-2011
                    //
                    //tinh theo user mien giam
                    // mien ngoai tru
                    asql += " union all";
                    asql += " select 6 as stt,0 as id, to_char(c.id) as ma,c.hoten as ten ,to_number('0')  as soluong, "+
                        //"sum(b.sotien)*-1 as sotien,"+
                        "case when sum(d.khuyenmai)=0 then  sum(b.sotien)*-1  else to_number('0') end as sotien," +
                        "to_number('0') as sotiengiamua,to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_mienngtru b inner join medibvmmyy.v_vienphill a on a.id=b.id inner join medibv.v_dlogin c on a.userid=c.id  ";
                    asql += " inner join medibvmmyy.v_vienphict d on a.id=b.id";
                    asql += " " + aexp_mien_thieu + "";
                    asql += " group by to_char(c.id),c.hoten";

                    // bhyt ngoai tru
                    asql += " union all";
                    asql += " select 6 as stt,0 as id, to_char(d.id) as ma,d.hoten as ten ,to_number('0')  as soluong ,"+
                        //"sum(to_number((case when b.madoituong=1 then nvl(b.mien,0) else 0 end)))*-1 as sotien,"+// gam 09-05-2011
                        "case when b.khuyenmai=0 then sum(to_number((case when b.madoituong=1 then nvl(b.mien,0) else 0 end)))*-1 else to_number('0') end as sotien," +
                        "to_number('0') as sotiengiamua, to_number('0') as tyle, to_number('0') as bhyttra, to_number('0') as bntra ";
                    asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 ";
                    asql += " " + aexp_mien_thieu + "";
                    asql += " group by to_char(d.id),d.hoten,b.khuyenmai";
                }
               
                if (chkTTRV.Checked)
                {
                    asql += " union all";
                    asql += " select 1 as stt,f.id,f.ma,f.ten";
                    asql += " ,sum(b.soluong- case when b.tra>0 then b.soluong else 0 end)  as soluong ";
                   
                    asql += ",sum(b.soluong*b.dongia -b.tra) as sotien";//binh                    
                    asql += " ,sum((b.soluong - (case when b.tra>0 then b.soluong else 0 end))*b.giamua) as sotiengiamua,sum((b.soluong*b.dongia -b.tra) - ((b.soluong - (case when b.tra>0 then b.soluong else 0 end))*case when b.giamua>0 then b.giamua else b.dongia end)) as tyle, sum(b.bhyttra) as bhyttra, sum(case when b.madoituong=1 then b.sotien-b.bhyttra else 0 end) as bntra ";
                    asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id inner join medibv.v_dlogin d on a.userid=d.id ";
                    //asql += " inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp";
                    asql += " inner join (select id, id_loai from medibv.v_giavp union all ( select a1.id as id, b1.loaivp as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id )) e on e.id=b.mavp";
                    asql += " inner join (select id, id_nhom,ma,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ma,'' ten from dual) f on e.id_loai=f.id";
                    asql += " " + aexp + "";
                    if (aloaivp != "") asql += " and e.id_loai in(" + aloaivp + ")";
                    asql += " group by f.ma,f.id,f.ten";
                    //thong ke theo nguoi thu
                    asql += " union all ";
                    //asql += " select 6 as stt,0 as id,to_char(c.id) as ma,c.hoten,0 as soluong, sum(b.soluong*b.dongia - b.tra) as sotien, sum((b.soluong-(case when b.tra>0 then b.soluong else 0 end))* case when b.giamua>0 then b.giamua else b.dongia end) as sotiengiamua ";
                    //asql += " select 6 as stt,0 as id,to_char(c.id) as ma,c.hoten,0 as soluong, sum(b.soluong*b.dongia - b.tra) as sotien ";
                    asql += " select 6 as stt,0 as id,to_char(c.id) as ma,c.hoten,0 as soluong";

                    asql += " ,sum(b.soluong*b.dongia - b.tra -(case when b.madoituong=1 and tra>0 then 0 else bhyttra end))-a.mien-a.thieu as sotien";                    
                    asql += " , sum((b.soluong-(case when b.tra>0 then b.soluong else 0 end))* b.giamua) as sotiengiamua,sum((b.soluong*b.dongia -b.tra) - ((b.soluong - (case when b.tra>0 then b.soluong else 0 end))*case when b.giamua>0 then b.giamua else b.dongia end)) as tyle, sum(b.bhyttra) as bhyttra , sum(case when b.madoituong=1 then b.sotien-b.bhyttra else 0 end) as bntra ";
                    asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibv.v_dlogin c on a.userid=c.id ";
                    //asql += "  inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp";
                    asql += "  inner join (select id, id_loai from medibv.v_giavp union all (select a1.id as id, b1.loaivp as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id )) e on e.id=b.mavp";//gam
                    asql += " " + aexp + "";
                    if (aloaivp != "") asql += " and e.id_loai in(" + aloaivp + ")";
                    asql += " group by c.id,c.hoten,a.mien, a.thieu";
                   //Binh Lay so tien thieu - mien cua BN len
                    if ((adoituong == "" && chkMien.Checked) || (adoituong != "" && chkMien.Checked && m_v.get_data("select madoituong from medibv.doituong where mien>0 and madoituong in(" + adoituong + ")").Tables[0].Rows.Count > 0))
                    {
                        //mien noi tru
                        asql += " union all";
                        asql += " select 8 as stt,to_number('-98') as id,'Mien' as ma,'Miễn' as ten";
                        asql += " ,to_number('0')  as soluong ,sum(a.mien)*-1 as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra ";
                        asql += " from medibvmmyy.v_ttrvll a left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                        asql += " " + aexp_mien_thieu + "";
                        asql += " and a.mien>0";
                        //thieu
                        asql += " union all";
                        asql += " select 8 as stt,to_number('-99') as id,'Thieu' as ma,'Thiếu' as ten";
                        asql += " ,to_number('0')  as soluong ,sum(a.thieu)*-1 as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra ";
                        asql += " from medibvmmyy.v_ttrvll a left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                        asql += " " + aexp_mien_thieu + "";
                        asql += " and a.thieu>0";

                        //bhyt noi tru
                        asql += " union all";
                        asql += " select 8 as stt,to_number('-97') as id,'BHYT' as ma,'BHYT' as ten";
                        //asql += " ,to_number('0')  as soluong,  sum(case when b.madoituong=1 then case when instr(nvl(cc.sothe,' '),'UC')>0 or instr(nvl(cc.sothe,' '),'VC')>0 or instr(nvl(cc.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end)*-1 as sotien, to_number('0') as sotiengiamua,to_number('0') as tyle";
                        asql += " ,to_number('0')  as soluong,  sum(case when b.madoituong=1 then (case when b.tra>0 then 0 else b.bhyttra end) else 0 end)*-1 as sotien, to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra ";
                        asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id inner join medibv.v_dlogin d on a.userid=d.id ";
                        asql += " " + aexp_mien_thieu + "";
                        //asql += " and a.bhyt>0";
                        
                    }
                }
                if (chkTU.Checked)
                {
                    asql += " union all";
                    asql += " select 2 as stt,0 as id,to_char(userid) as ma,to_char('Thu tiền tạm ứng') as ten, 0 as soluong,sum(sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra";//binh
                    asql += " from medibvmmyy.v_tamung where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(userid)";
                    //Hoan tien tam ung
                    asql += " union all";
                    asql += " select 3 as stt,0 as id,to_char(userid) as ma,to_char('Hoàn tiền tạm ứng') as ten, 0 as soluong,-1* sum(sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra";//binh
                    asql += " from medibvmmyy.v_hoantra where ghichu='2' and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(userid)";
                    //Hoan tien tam ung khi thanh toan ra vien                    
                    asql += " union all";
                    asql += " select 3 as stt,0 as id,to_char(a.userid) as ma,to_char('Hoàn tiền tạm ứng') as ten, 0 as soluong,-1*sum(b.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra ";
                    asql += " from medibvmmyy.v_ttrvll a, medibv.vv_tamung" + m_idcomputer + " b where a.id=b.idttrv and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(a.userid)";
                    //
                    //cong vao user thu
                    //asql += " union all";
                    //asql += " select 6 as stt,0 as id,to_char(a.userid) as ma,b.hoten as ten, 0 as soluong,sum(a.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra";//binh
                    //asql += " from medibvmmyy.v_tamung a inner join medibv.v_dlogin b on a.userid=b.id where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    //if (auserid != "") asql += " and a.userid in (" + auserid + ")";
                    //asql += " group by to_char(a.userid), b.hoten";
                    ////Hoan tien tam ung
                    //asql += " union all";
                    //asql += " select 6 as stt,0 as id,to_char(a.userid) as ma,b.hoten as ten, 0 as soluong,-1* sum(a.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra";//binh
                    //asql += " from medibvmmyy.v_hoantra a inner join medibv.v_dlogin b on a.userid=b.id where ghichu='2' and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    //if (auserid != "") asql += " and a.userid in (" + auserid + ")";
                    //asql += " group by to_char(a.userid), b.hoten";
                    ////Hoan tien tam ung khi thanh toan ra vien                    
                    //asql += " union all";
                    //asql += " select 6 as stt,0 as id,to_char(a.userid) as ma,c.hoten as ten, 0 as soluong,-1*sum(b.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle, 0 as bhyttra, 0 as bntra ";
                    //asql += " from medibvmmyy.v_ttrvll a, medibv.vv_tamung" + m_idcomputer + " b, medibv.v_dlogin c where a.id=b.idttrv and a.userid=c.id and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    //if (auserid != "") asql += " and a.userid in (" + auserid + ")";
                    //asql += " group by to_char(a.userid),c.hoten";
                }
                asql += ") a group by stt,id,ma,ten";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (chkKhamsuckhoe.Checked)
                {
                    asql = "select to_char(ngayud,'mmyyyy') as mmyy from medibv.ct_doan where id in(select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) group by to_char(ngayud,'mmyyyy')";
                    asql_sk = "  select 7 as stt,f.iddoan as id,'' as ma,g.ten||'( '|| f.ten ||' )' as ten,to_number(0) as soluong,sum(a.dongia) as sotien,to_number('0') as sotiengiamua";
                    asql_sk += " from medibvmmyy.ct_chitiet a inner join medibv.ct_giavp b on a.mavp=b.id inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id inner join medibvmmyy.ct_ketqua e on a.id=e.id inner join medibv.ct_donvi f on e.iddonvi=f.id inner join medibv.ct_doan g on f.iddoan=g.id";
                    asql_sk += "  where quyettoan>0 and ketqua is not null and ketqua<>'' and to_date(to_char(ngayqt,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and f.iddoan in (select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy'))";
                    asql_sk += " group by f.iddoan,g.ten||'( '|| f.ten ||' )' ";
                    foreach (DataRow r in m_v.get_data(asql).Tables[0].Rows)
                    {
                        ads_sk = m_v.get_data_mmyy(r["mmyy"].ToString().Substring(0, 2).ToString() + r["mmyy"].ToString().Substring(4, 2).ToString() + "", asql_sk);
                        if (ads_sk != null && ads_sk.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow r1 in ads_sk.Tables[0].Rows)
                            {
                                r4 = m_v.getrowbyid(ads.Tables[0], "stt=7 and ten='" + r1["ten"].ToString() + "'");
                                if (r4 == null)
                                {
                                    r5 = ads.Tables[0].NewRow();
                                    r5["stt"] = 7;
                                    r5["id"] = decimal.Parse(r1["id"].ToString());
                                    r5["ma"] = r1["ma"].ToString();
                                    r5["ten"] = r1["ten"].ToString();
                                    r5["soluong"] = 0;
                                    r5["sotien"] = decimal.Parse(r1["sotien"].ToString());
                                    r5["sotiengiamua"] = 0;
                                    r5["sotiendichvu"] = 0;
                                    ads.Tables[0].Rows.Add(r5);
                                }
                                else
                                {
                                    dr = ads.Tables[0].Select("stt=7 and ten='" + r1["ten"].ToString() + "'");
                                    if (dr.Length > 0)
                                    {
                                        dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                if (chkKhamsuckhoe.Checked)
                {
                    asql = "select to_char(ngayud,'mmyyyy') as mmyy from medibv.ct_doan where id in(select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) group by to_char(ngayud,'mmyyyy')";
                    asql_sk = " select 1 as stt,d.id,d.ma,d.ten,to_number(count(c.id)) as soluong,sum(a.dongia) as sotien,to_number('0') as sotiengiamua";//binh
                    asql_sk += " from medibvmmyy.ct_chitiet a inner join medibvmmyy.ct_ketqua e on a.id=e.id inner join medibv.ct_donvi f on e.iddonvi=f.id inner join medibv.ct_doan g on f.iddoan=g.id inner join medibv.ct_giavp b on a.mavp=b.id inner join medibv.v_giavp c on b.mavp=c.id inner join medibv.v_loaivp d on c.id_loai=d.id ";
                    asql_sk += " where quyettoan>0 and ketqua is not null and ketqua<>'' and to_date(to_char(ngayqt,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and f.iddoan in (select id from medibv.ct_doanqt where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy'))";
                    if (aloaivp != "") asql_sk += " and c.id_loai in(" + aloaivp + ")";
                    asql_sk += " group by d.id,d.ma,d.ten";
                    foreach (DataRow r in m_v.get_data(asql).Tables[0].Rows)
                    {                        
                        ads_sk = m_v.get_data_mmyy(r["mmyy"].ToString().Substring(0, 2).ToString() + r["mmyy"].ToString().Substring(4, 2).ToString() + "", asql_sk);
                        if (ads_sk != null && ads_sk.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow r1 in ads_sk.Tables[0].Rows)
                            {
                                r4 = m_v.getrowbyid(ads.Tables[0], "stt=1 and id=" + r1["id"].ToString() + "");
                                if (r4 == null)
                                {
                                    r5 = ads.Tables[0].NewRow();
                                    r5["stt"] = 1;
                                    r5["id"] = decimal.Parse(r1["id"].ToString());
                                    r5["ma"] = r1["ma"].ToString();
                                    r5["ten"] = r1["ten"].ToString();
                                    r5["soluong"] = decimal.Parse(r1["soluong"].ToString());
                                    r5["sotien"] = decimal.Parse(r1["sotien"].ToString());
                                    r5["sotiengiamua"] = decimal.Parse(r1["sotiengiamua"].ToString());
                                    r5["sotiendichvu"] = 0;
                                    ads.Tables[0].Rows.Add(r5);
                                }
                                else
                                {
                                    dr = ads.Tables[0].Select("stt=1 and id=" + r1["id"].ToString() + "");
                                    if (dr.Length > 0)
                                    {
                                        dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r1["soluong"].ToString());
                                        dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                ////bbb
                //if (chkTU.Checked)
                //{
                //    asql = "select 2 as stt,0 as idnhom,to_char(userid) as ma,to_char('Thu tiền tạm ứng') as ten, 0 as soluong,sum(sotien) as sotien,to_number('0') as sotiengiamua, to_number('0') as tyle ";//binh
                //    asql += " from medibvmmyy.v_tamung where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                //    if (auserid != "") asql += " and userid in (" + auserid + ")";
                //    asql += " group by to_char(userid)";
                //    //
                //    //Hoan tien tam ung
                //    asql += " union all";
                //    asql += " select 3 as stt,0 as id,to_char(userid) as ma,to_char('Hoàn tiền tạm ứng') as ten, 0 as soluong,-1* sum(sotien) as sotien,to_number('0') as sotiengiamua, to_number('0') as tyle ";//binh
                //    asql += " from medibvmmyy.v_hoantra where ghichu='2' and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                //    if (auserid != "") asql += " and userid in (" + auserid + ")";
                //    asql += " group by to_char(userid)";
                //    //Hoan tien tam ung khi thanh toan ra vien
                //    asql += " union all";
                //    asql += " select 3 as stt,0 as id,to_char(a.userid) as ma,to_char('Hoàn tiền tạm ứng') as ten, 0 as soluong,-1*sum(b.sotien) as sotien,to_number('0') as sotiengiamua,to_number('0') as tyle ";
                //    asql += " from medibvmmyy.v_ttrvll a, medibv.vv_tamung" + m_idcomputer + " b where a.id=b.idttrv and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                //    if (auserid != "") asql += " and userid in (" + auserid + ")";
                //    asql += " group by to_char(a.userid)";
                //    //
                //    ads_tu = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                //    if (ads_tu != null && ads_tu.Tables[0].Rows.Count > 0) 
                //    {
                //        if (ads == null)
                //        {
                //            ads = ads_tu;
                //        }
                //        else
                //        {
                //            foreach (DataRow r1 in ads.Tables[0].Select("stt=6"))
                //            {
                //                string s_idnvthu = ""; bool bCo = false;
                //                foreach (DataRow r_tu in ads_tu.Tables[0].Select("ma=" + r1["ma"].ToString() + ""))
                //                {
                //                    st1 = 0; st2 = 0;
                //                    st1 = decimal.Parse(r_tu["sotien"].ToString());
                //                    st2 = decimal.Parse(r1["sotien"].ToString());
                //                    st2 = st2 + st1;
                //                    r1["sotien"] = st2;
                //                    bCo = true;
                //                    ads.AcceptChanges();
                //                }
                //                if (bCo == false) s_idnvthu = r1["ma"].ToString();
                //            }

                //        }
                //    }
                //}
                           
            }
            catch
            {
            }
            
            return ads;
        }

        private DataSet f_BC_doanhthu()
        {
            DataSet ads = null;

            try
            {
                string asql = "",  aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aloaivp = "";                
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_LoaiBN);
                aloaidv = f_Get_CheckID(tree_LoaiDV);
                aloaivp = f_Get_CheckID(tree_LoaiVP);
                amakp = f_Get_CheckID(tree_KP);
                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and b.madoituong in(" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a.makp in (" + amakp + ")";
                }

                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    aexp += " and a.sobienlai between " + txtTuso.Text.Trim() + " and " + txtDenso.Text.Trim() + "";
                }
                aexp = "where " + aexp.Trim();

                asql = "select f.id,f.ten,g.makp,g.tenkp,h.ma as idnhom,h.ten as tennhom";
                if (chkMien.Checked)
                {
                    asql += " ,sum((b.soluong- case when b.tra>0 then 1 else 0 end)-case when b.mien>0 then 1 else 0 end)  as soluong";
                }
                else
                {
                    asql += " ,sum(b.soluong- case when b.tra>0 then 1 else 0 end)  as soluong";
                }
                asql += " ,sum(b.soluong*b.dongia - b.thieu - b.tra - b.mien) as sotien ";
                asql += "  from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id inner join medibv.v_giavp e on e.id=b.mavp inner join medibv.v_loaivp f on e.id_loai=f.id inner join medibv.btdkp_bv g on b.makp=g.makp inner join medibv.v_nhomvp h on f.id_nhom=h.ma";
                asql += " " + aexp + " ";
                if (aloaivp != "") asql += " and e.id_loai in(" + aloaivp + ")";
                if (radCothe.Checked) asql += " and a.done=2 ";
                if (radKhongthe.Checked) asql += " and a.done<>2 ";
                asql += "group by f.id,f.ten,g.makp,g.tenkp,h.ma,h.ten";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);                         
            }
            catch
            {
            }
            return ads;
        }
        private DataSet f_BC_doanhthu_BV()
        {
            DataSet ads = null;

            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aloaivp = "";
                
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_LoaiBN);
                aloaidv = f_Get_CheckID(tree_LoaiDV);
                aloaivp = f_Get_CheckID(tree_LoaiVP);

                amakp = f_Get_CheckID(tree_KP);

                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and b.madoituong in(" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a.makp in (" + amakp + ")";
                }

                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    aexp += " and a.sobienlai between " + txtTuso.Text.Trim() + " and " + txtDenso.Text.Trim() + "";
                }
                aexp = "where " + aexp.Trim();

                asql = "select i.makp,i.tenkp ,k.ten";
                if (chkMien.Checked)
                {
                    asql += " ,sum((b.soluong- case when b.tra>0 then 1 else 0 end)-case when b.mien>0 then 1 else 0 end)  as soluong";
                }
                else
                {
                    asql += " ,sum(b.soluong- case when b.tra>0 then 1 else 0 end)  as soluong";
                }
                asql += " ,sum(b.soluong*b.dongia - b.thieu - b.tra - b.mien) as sotien ";
                asql += "  from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id left join medibv.v_dlogin d on a.userid=d.id inner join medibv.v_giavp e on e.id=b.mavp inner join medibv.v_loaivp f on e.id_loai=f.id inner join medibv.btdkp_bv g on b.makp=g.makp inner join medibv.v_nhomvp h on f.id_nhom=h.ma ";
                asql += " inner join medibv.v_nhomkhoabvct i on i.makp=g.makp inner join medibv.v_nhomkhoabvll k on i.id=k.id";
                asql += " " + aexp + " ";
                if (aloaivp != "") asql += " and e.id_loai in(" + aloaivp + ")";
                if (radCothe.Checked) asql += " and a.done=2 ";
                if (radKhongthe.Checked) asql += " and a.done<>2 ";
                asql += " group by  i.makp,i.tenkp,k.ten order by k.ten";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
            }
            catch
            {
            }
            return ads;
        }
        private void f_Xem()
        {
            string acurdir = System.Environment.CurrentDirectory;
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;
            try
            {
                DataSet ads = f_Get_Data();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {                    
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutructiep.rpt";
                    if (rdBC_03.Checked)
                    {
                        areport = "v_2007_bkthutructiep_conghoan.rpt";                      
                    }
                    if (rd_BC14.Checked)
                    {
                        areport = "BanKeBienLaiThuTienVienPhi.rpt";
                    }
                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    angayin = lan.Change_language_MessageText("Ngày")+" " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " "+lan.Change_language_MessageText("tháng")+" " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " "+lan.Change_language_MessageText("năm")+" " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                    if (rdThang.Checked)
                    {
                        aghichu = lan.Change_language_MessageText("Tháng:")+" " + txtThang.Value.ToString().PadLeft(2, '0') + " "+lan.Change_language_MessageText("Năm:")+" " + txtNam.Value.ToString();
                    }
                    else 
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)
                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)
                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                    }
                    ads.WriteXml("..\\..\\Datareport\\v_BKthutructiep.xml",XmlWriteMode.WriteSchema);
                    if ((chkInrieng.Checked == false && chkInchung.Checked == false) || chkInrieng.Checked)
                    {
                        frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu viện phí trực tiếp", 1, chkXemkhiin.Checked ? true : false);
                        fa.KetxuatExcel = bKetxuatExcel;
                        fa.ShowDialog();
                    }
                    if (chkInchung.Checked)
                    {
                        areport = areport.Replace(".rpt", "_inchung.rpt");
                        frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu viện phí trực tiếp", 1, chkXemkhiin.Checked ? true : false);
                        fa.KetxuatExcel = bKetxuatExcel;
                        fa.ShowDialog();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acurdir;
                tmn_Export.Enabled = true;
                tmn_Xem.Enabled = true;
            }
        }

        private void f_Doanhthu()
        {
            try
            {
                DataSet ads = f_BC_doanhthu();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutructiep_doanhthu.rpt";

                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                 
                    ads.WriteXml("..//..//Datareport/v_BCthutructiep_doanhthu.xml", XmlWriteMode.WriteSchema);
                    if (rdThang.Checked)
                    {

                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                    }
           
                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void f_Doanhthu_bv()
        {
            try
            {
                DataSet ads = f_BC_doanhthu_BV();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutructiep_doanhthu_bv.rpt";

                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
               
                    ads.WriteXml("..//..//Datareport/v_BCthutructiep_doanhthu_bv.xml", XmlWriteMode.WriteSchema);
                    if (rdThang.Checked)
                    {

                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                    }

              
                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private DataSet ads_thongkesothe()
        {
            DataSet ads = null, ds_trongoi=null;                        
            try
            {
                ds_trongoi=new DataSet();
                ds_trongoi.Tables.Add("Table");
                ds_trongoi.Tables[0].Columns.Add(new DataColumn("id",typeof(decimal)));
                ds_trongoi.Tables[0].Columns.Add(new DataColumn("mabn",typeof(string)));
                ds_trongoi.Tables[0].Columns.Add(new DataColumn("hoten",typeof(string)));
                ds_trongoi.Tables[0].Columns.Add(new DataColumn("tentrongoi", typeof(string)));                
                ds_trongoi.Tables[0].Columns.Add(new DataColumn("id_trongoi", typeof(decimal)));
                ds_trongoi.Tables[0].Columns.Add(new DataColumn("sotien", typeof(decimal)));
                ds_trongoi.Tables[0].Columns.Add(new DataColumn("mien", typeof(decimal)));


                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aloaivp = "";

                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);

                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_LoaiBN);
                aloaidv = f_Get_CheckID(tree_LoaiDV);
                amakp = f_Get_CheckID(tree_KP);
                aloaivp = f_Get_CheckID(tree_LoaiVP);
                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and b.madoituong in(" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a.makp in (" + amakp + ")";
                }

                if (txtTuso.Text != "" && txtDenso.Text != "")
                {
                    if (decimal.Parse(txtTuso.Text.Trim()) > decimal.Parse(txtDenso.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTuso.Focus();
                        return null;
                    }
                    else
                    {
                        aexp += " and a.sobienlai between " + txtTuso.Text.Trim() + " and " + txtDenso.Text.Trim() + "";
                    }
                }

                aexp = "where " + aexp.Trim();

                asql = " select a.id,a.mabn,a.hoten,d.idtrongoi as id_trongoi,sum(b.soluong*b.dongia) as sotien, case when e.sotien is null then 0 else e.sotien end as mien";
                asql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru e on a.id=e.id inner join medibv.v_giavp c on b.mavp=c.id inner join medibvmmyy.v_chidinh d on d.id=b.idchidinh ";
                asql += " "+aexp +" and a.done=2 ";
                asql += " group by a.id,a.mabn,a.hoten,d.idtrongoi ,case when e.sotien is null then 0 else e.sotien end";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                foreach(DataRow r in ads.Tables[0].Rows)
                {
                    foreach (DataRow rr in m_v.get_data("select a.id,a.ma,a.ten from medibv.v_giavp a inner join medibv.v_trongoi b on a.id=b.id inner join medibv.v_giavp c on b.id_gia=c.id where a.id="+r["id_trongoi"].ToString()+" group by a.id,a.ma,a.ten").Tables[0].Rows)
                    {
                        DataRow dr=ds_trongoi.Tables[0].NewRow();
                        dr["id"]=r["id"].ToString();
                        dr["mabn"]=r["mabn"].ToString();
                        dr["hoten"]=r["hoten"].ToString();
                        dr["tentrongoi"]=rr["ten"].ToString();
                        dr["id_trongoi"] = rr["id"].ToString();
                        dr["sotien"] = r["sotien"].ToString();
                        dr["mien"] = r["mien"].ToString();
                        ds_trongoi.Tables[0].Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return ds_trongoi;
        }

        private void f_thongkesothe()
        {
            try
            {
                DataSet ads = ads_thongkesothe();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutructiep_sothe.rpt";

                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
               
                    ads.WriteXml("..//..//Datareport/v_2007_bkthutructiep_sothe.xml", XmlWriteMode.WriteSchema);
                    if (rdThang.Checked)
                    {

                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                    }

                  
                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void f_Export()
        {
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;
            string acurdir = System.Environment.CurrentDirectory;
            try
            {
                DataSet ads = f_Get_Data();
                if (ads != null)
                {
                    frmPreviewdata af = new frmPreviewdata("", ads, "");
                    af.ShowInTaskbar = false;
                    af.WindowState = FormWindowState.Maximized;
                    af.ShowDialog();
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acurdir;
                tmn_Export.Enabled = true;
                tmn_Xem.Enabled = true;
            }
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
        private void f_Check(DataGridView v_dgv, string v_val)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[v_dgv.DataSource, v_dgv.DataMember]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("id="+v_val))
                {
                    r["chon"] = 1;
                }
                v_dgv.Update();
            }
            catch
            {
            }
        }
        private void f_Check(DataGridView v_dgv, string v_id, int v_val)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[v_dgv.DataSource, v_dgv.DataMember]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("id=" + v_id))
                {
                    r["chon"] = v_val;
                }
                v_dgv.Update();
            }
            catch
            {
            }
        }

        private void chkAll_User_CheckedChanged(object sender, EventArgs e)
        {
            f_Checkall(dgUser, chkAll_User);
        }
    
        private void chkAll_So_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_Quyenso, chkAll_So.Checked);
        }
    
        private void txtThang_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtNam_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void rdThang_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void rdNgay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtTN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtDN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void tmn_Ketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdThang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtThang.Enabled = rdThang.Checked;
                txtNam.Enabled = rdThang.Checked;
                txtTN.Enabled = !txtThang.Enabled;
                txtDN.Enabled = !txtThang.Enabled;
                txtThang_ValueChanged(null, null);
            }
            catch
            {
            }
        }

        private void txtThang_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString()), 1);
                txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString()), DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()), int.Parse(txtThang.Value.ToString())));
            }
            catch
            {
            }
        }

        private void txtTN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTN.Value > txtDN.Value)
                {
                    txtDN.Value = txtTN.Value;
                }
            }
            catch
            {
            }
        }

        private void txtDN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDN.Value < txtTN.Value)
                {
                    txtTN.Value = txtDN.Value;
                }
            }
            catch
            {
            }
        }

       
        private void tmn_Xem_Click(object sender, EventArgs e)
        {
            //
            Tao_view(txtTN.Text, txtDN.Text);
            //
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            bKetxuatExcel = m_v.f_quyenchitiet_export(aquyenchitiet);            
            //
            tmn_Xem.Enabled = false;
            progressBar1.Value = 1;
            timer1.Enabled = true;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (rdBC_01.Checked || rdBC_02.Checked || rdBC_03.Checked || rd_BC14.Checked)
                {
                   f_Xem();
                }
                else if(rdBC_04.Checked)
                {
                  f_BCLoai_VP();
                }
                else if (rdBC_05.Checked)
                {
                    f_BCNhom_VP();
                }
                else if (rdBC_06.Checked)
                {
                    f_Chitiet_TheoloaiVP();
                }         
                else if (rdBC09.Checked)
                {
                    f_Doanhthu();
                }
                else if (rdBC10.Checked)
                {
                    f_Doanhthu_bv();
                }
                else if (radBKthe.Checked)
                {
                    f_thongkesothe();
                }
                else if (rd_BC12.Checked)
                {
                    f_Doanhthu_Hathanh();
                }
                else if (rd_BC13.Checked)
                {
                    f_QuanDanMienDong();
                }
            }
            catch
            { 
            }
            tmn_Xem.Enabled = true;
            this.Cursor = Cursors.Default;
            timer1.Enabled = false;
            progressBar1.Value = progressBar1.Minimum;
            
        }
        private void f_QuanDanMienDong()
        {
            try
            {
                DataSet ads = new DataSet();
                DataSet ads1 = new DataSet();
                DataRow r1, r2;
                DataRow []dr;
                try
                {
                    string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aloaivp = "";

                    auserid = f_Getchecked(dgUser);
                    aquyenso = f_Get_CheckID(tree_Quyenso);
                    adoituong = f_Get_CheckID(tree_Doituong);
                    aloaibn = f_Get_CheckID(tree_LoaiBN);
                    aloaidv = f_Get_CheckID(tree_LoaiDV);
                    aloaivp = f_Get_CheckID(tree_LoaiVP);

                    amakp = f_Get_CheckID(tree_KP);

                    if (amakp != "")
                    {
                        amakp = amakp.Replace(",", "','");
                        amakp = "'" + amakp + "'";
                    }
                    if (chkGio.Checked)
                    {
                        aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                    }
                    else
                    {
                        aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    }
                    aexp = "where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";

                    ads.Tables.Add("Table");
                    ads.Tables[0].Columns.Add(new DataColumn("stt", typeof(string)));
                    ads.Tables[0].Columns.Add(new DataColumn("noidung", typeof(string)));
                    ads.Tables[0].Columns.Add(new DataColumn("makp", typeof(string)));
                    ads.Tables[0].Columns.Add(new DataColumn("bhytca", typeof(decimal)));
                    ads.Tables[0].Columns.Add(new DataColumn("bhytsotien", typeof(decimal)));
                    ads.Tables[0].Columns.Add(new DataColumn("dvca", typeof(decimal)));
                    ads.Tables[0].Columns.Add(new DataColumn("dvsotien", typeof(decimal)));

                    #region Ngoai tru
                    r2 = ads.Tables[0].NewRow();
                    r2["stt"] = "I";
                    r2["noidung"] = "NGOẠI TRÚ";
                    ads.Tables[0].Rows.Add(r2);

                    asql = "select to_char(a.makp)||'_KP' as makp,c.tenkp,count(a.maql) as soca,sum(1*" + m_v.sCongkham_BHYT + ") as sotien ";
                    asql += "from medibvmmyy.benhanpk a inner join medibv.btdkp_bv c on a.makp=c.makp ";
                    asql += "where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += " and a.chandoan<>'' and a.madoituong=1 group by to_char(a.makp)||'_KP',c.tenkp";
                    decimal astt = 1;
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = astt.ToString();
                            r2["noidung"] = r["tenkp"].ToString();
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = decimal.Parse(r["soca"].ToString());
                            r2["bhytsotien"] = decimal.Parse(r["sotien"].ToString());
                            r2["dvca"] = 0;
                            r2["dvsotien"] = 0;
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["bhytca"] = decimal.Parse(dr[0]["bhytca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["bhytsotien"] = decimal.Parse(dr[0]["bhytsotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                            }
                        }
                    }
                    asql = "select to_char(a.makp)||'_KP' as makp,c.tenkp,count(a.maql) as soca,sum(nvl(d.gia_th,0)) as sotien";
                    asql += " from medibvmmyy.benhanpk a inner join medibv.btdkp_bv c on a.makp=c.makp left join medibv.v_giavp d on c.mavp=d.id";
                    asql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += " and a.chandoan<>'' and a.madoituong=2 group by to_char(a.makp)||'_KP',c.tenkp";
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = astt.ToString();
                            r2["noidung"] = r["tenkp"].ToString();
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = 0;
                            r2["bhytsotien"] = 0;
                            r2["dvca"] = decimal.Parse(r["soca"].ToString());
                            r2["dvsotien"] = decimal.Parse(r["sotien"].ToString());
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["dvca"] = decimal.Parse(dr[0]["dvca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["dvsotien"] = decimal.Parse(dr[0]["dvsotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                            }
                        }
                    }
                    #endregion

                    r2 = ads.Tables[0].NewRow();
                    r2["stt"] = "II";
                    r2["noidung"] = "CẬN LÂM SÀNG";
                    ads.Tables[0].Rows.Add(r2);

                    #region CDHA
                    asql = "select d.ten as tenkp,to_char(a.id_loai) ||'_cdha' as makp,count(b.id) as soca,sum(c.gia) as sotien";
                    asql += " from medibvmmyy.cdha_bnll a inner join medibvmmyy.cdha_bnct b on a.id=b.id ";
                    asql += " inner join medibv.cdha_kythuat e on to_number(a.id_loai)=e.id_loaicdha and b.makt=e.makt";
                    asql += " inner join medibvmmyy.cdha_kqvp c on a.id=c.id and a.id_loai=c.id_loaicdha and e.id_vp=c.mavp inner join medibv.cdha_loai d on a.id_loai=d.id";
                    asql += " where a.madoituong=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += " group by d.ten,to_char(a.id_loai) ||'_cdha'";
                    astt = 1;
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = astt.ToString();
                            r2["noidung"] = r["tenkp"].ToString();
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = decimal.Parse(r["soca"].ToString());
                            r2["bhytsotien"] = decimal.Parse(r["sotien"].ToString());
                            r2["dvca"] = 0;
                            r2["dvsotien"] = 0;
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["bhytca"] = decimal.Parse(dr[0]["bhytca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["bhytsotien"] = decimal.Parse(dr[0]["bhytsotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                            }
                        }
                    }
                    asql = "select d.ten as tenkp,to_char(a.id_loai) ||'_cdha' as makp,count(b.id) as soca,sum(c.gia) as sotien";
                    asql += " from medibvmmyy.cdha_bnll a inner join medibvmmyy.cdha_bnct b on a.id=b.id ";
                    asql += " inner join medibv.cdha_kythuat e on to_number(a.id_loai)=e.id_loaicdha and b.makt=e.makt";
                    asql += " inner join medibvmmyy.cdha_kqvp c on a.id=c.id and a.id_loai=c.id_loaicdha and  e.id_vp=c.mavp inner join medibv.cdha_loai d on a.id_loai=d.id";
                    asql += " where a.madoituong=2 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += "  group by d.ten,to_char(a.id_loai) ||'_cdha'";
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = astt.ToString();
                            r2["noidung"] = r["tenkp"].ToString();
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = 0;
                            r2["bhytsotien"] = 0;
                            r2["dvca"] = decimal.Parse(r["soca"].ToString());
                            r2["dvsotien"] = decimal.Parse(r["sotien"].ToString());
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["dvca"] = decimal.Parse(dr[0]["dvca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["dvsotien"] = decimal.Parse(dr[0]["dvsotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                            }
                        }
                    }
                    #endregion

                    #region Xét  nghiệm
                    asql = "select to_char(id_bv_so)||'_XN' as makp, soxn as tenkp, count(*) soca, sum(sotien) as sotien from (";
                    asql += " select distinct a.id, e.id_bv_so, f.ten soxn, c.id_bv_ten, nvl(g.gia_bh,0) as sotien ";
                    asql += " from medibvmmyy.xn_phieu a inner join medibvmmyy.xn_ketqua b on a.id=b.id inner join medibv.xn_bv_chitiet c on b.id_ten=c.id inner join medibv.xn_bv_ten e on c.id_bv_ten=e.id inner join medibv.xn_bv_so f on e.id_bv_so=f.id left join medibv.v_giavp g on b.idvienphi=g.id";
                    asql += " where a.madoituong=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and  to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += " group by  a.id, e.id_bv_so, f.ten, c.id_bv_ten, nvl(g.gia_bh,0)) tmp";
                    asql += " group by to_char(id_bv_so)||'_XN', tenkp";
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = astt.ToString();
                            r2["noidung"] = r["tenkp"].ToString();
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = decimal.Parse(r["soca"].ToString());
                            r2["bhytsotien"] = decimal.Parse(r["sotien"].ToString());
                            r2["dvca"] = 0;
                            r2["dvsotien"] = 0;
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["bhytca"] = decimal.Parse(dr[0]["bhytca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["bhytsotien"] = decimal.Parse(dr[0]["bhytsotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                            }
                        }
                    }
                    asql = "select to_char(id_bv_so)||'_XN' as makp, soxn as tenkp, count(*) soca, sum(sotien) as sotien from (";
                    asql += " select distinct a.id, e.id_bv_so, f.ten soxn, c.id_bv_ten, nvl(g.gia_th,0) as sotien ";
                    asql += " from medibvmmyy.xn_phieu a inner join medibvmmyy.xn_ketqua b on a.id=b.id inner join medibv.xn_bv_chitiet c on b.id_ten=c.id inner join medibv.xn_bv_ten e on c.id_bv_ten=e.id inner join medibv.xn_bv_so f on e.id_bv_so=f.id left join medibv.v_giavp g on b.idvienphi=g.id";
                    asql += " where a.madoituong=2 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and  to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += " group by  a.id, e.id_bv_so, f.ten, c.id_bv_ten, nvl(g.gia_th,0)) tmp";
                    asql += " group by to_char(id_bv_so)||'_XN', tenkp";
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = astt.ToString();
                            r2["noidung"] = r["tenkp"].ToString();
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = 0;
                            r2["bhytsotien"] = 0;
                            r2["dvca"] = decimal.Parse(r["soca"].ToString());
                            r2["dvsotien"] = decimal.Parse(r["sotien"].ToString());
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["dvca"] = decimal.Parse(dr[0]["dvca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["dvsotien"] = decimal.Parse(dr[0]["dvsotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                            }
                        }
                    }
                    #endregion

                    #region So lieu Noi tru
                    r2 = ads.Tables[0].NewRow();
                    r2["stt"] = "III";
                    r2["noidung"] = "NỘI TRÚ";
                    ads.Tables[0].Rows.Add(r2);
                    asql = "select makp, tenkp, sum((case when madoituong=1 then 1 else 0 end)) as socabhyt, sum((case when madoituong=1 then 0 else 1 end)) as soca, sum(bntra) as bntra, sum(bhyttra) as bhyttra from(";
                    asql += " select to_char(c.makp)||'_NT' as makp, e.tenkp, a.id, a.mabn, c.madoituong, sum(c.soluong*c.dongia) - sum(case when c.madoituong=1 then case when instr(nvl(d.sothe,' '),'UC')>0 or instr(nvl(d.sothe,' '),'VC')>0 or instr(nvl(d.sothe,' '),'TC')>0 then (case when c.tra>0 then 0 else c.soluong end)*c.dongia*0.8 else (case when c.tra>0 then 0 else c.soluong end)*c.dongia end else 0 end) as bntra,";
                    asql += " sum(case when c.madoituong=1 then case when instr(nvl(d.sothe,' '),'UC')>0 or instr(nvl(d.sothe,' '),'VC')>0 or instr(nvl(d.sothe,' '),'TC')>0 then (case when c.tra>0 then 0 else c.soluong end)*c.dongia*0.8 else (case when c.tra>0 then 0 else c.soluong end)*c.dongia end else 0 end) as bhyttra";
                    asql += " from medibvmmyy.v_ttrvds a inner join medibv.btdbn aa on a.mabn=aa.mabn inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on a.id=c.id inner join medibv.v_giavp cc on c.mavp=cc.id inner join medibv.v_loaivp ccc on cc.id_loai=ccc.id left join medibvmmyy.v_ttrvbhyt d on a.id=d.id left join medibv.btdkp_bv e on c.makp=e.makp";
                    asql += " left join medibvmmyy.v_hoantra g on b.quyenso=g.quyenso and b.sobienlai=g.sobienlai ";
                    asql += " where g.id is null and c.madoituong in(1,2) and b.loaibn <> 3 and ccc.id_nhom not in(1,4,5,9)";//khong tinh tien thuoc, tien xet nghiem, cdha
                    asql += " and " + m_v.for_ngay("b.ngay", "'dd/mm/yyyy'") + " between ";
                    asql += " to_date('" + txtTN.Text.Substring(0,10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0,10) + "','dd/mm/yyyy')";
                    asql += " group by to_char(c.makp)||'_NT', e.tenkp, a.id, a.mabn, c.madoituong) as froo group by makp, tenkp";
                    astt = 1;
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = astt.ToString();
                            r2["noidung"] = r["tenkp"].ToString();
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = decimal.Parse(r["socabhyt"].ToString());
                            r2["bhytsotien"] = decimal.Parse(r["bhyttra"].ToString());
                            r2["dvca"] = decimal.Parse(r["soca"].ToString());
                            r2["dvsotien"] = decimal.Parse(r["bntra"].ToString());
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["dvca"] = decimal.Parse(dr[0]["dvca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["dvsotien"] = decimal.Parse(dr[0]["dvsotien"].ToString()) + decimal.Parse(r["bntra"].ToString());
                                dr[0]["bhytca"] = decimal.Parse(dr[0]["bhytca"].ToString()) + decimal.Parse(r["socabhyt"].ToString());
                                dr[0]["bhytsotien"] = decimal.Parse(dr[0]["bhytsotien"].ToString()) + decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                    }
                    #endregion

                    #region THUOC
                    r2 = ads.Tables[0].NewRow();
                    r2["stt"] = "IV";
                    r2["noidung"] = "THUỐC";
                    ads.Tables[0].Rows.Add(r2);
                    asql = "select 'THUOC' as makp, nvl(sum((case when madoituong=1 then 1 else 0 end)),0) as socabhyt, nvl(sum((case when madoituong=1 then 0 else 1 end)),0) as soca, nvl(sum(bntra),0) as bntra, nvl(sum(bhyttra),0) as bhyttra from(";
                    asql += " select a.id , a.mabn, c.madoituong, sum(c.soluong*c.dongia) - sum(case when c.madoituong=1 then case when instr(nvl(d.sothe,' '),'UC')>0 or instr(nvl(d.sothe,' '),'VC')>0 or instr(nvl(d.sothe,' '),'TC')>0 then (case when c.tra>0 then 0 else c.soluong end)*c.dongia*0.8 else (case when c.tra>0 then 0 else c.soluong end)*c.dongia end else 0 end) as bntra,";
                    asql += " sum(case when c.madoituong=1 then case when instr(nvl(d.sothe,' '),'UC')>0 or instr(nvl(d.sothe,' '),'VC')>0 or instr(nvl(d.sothe,' '),'TC')>0 then (case when c.tra>0 then 0 else c.soluong end)*c.dongia*0.8 else (case when c.tra>0 then 0 else c.soluong end)*c.dongia end else 0 end) as bhyttra";
                    asql += " from medibvmmyy.v_ttrvds a inner join medibv.btdbn aa on a.mabn=aa.mabn inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on a.id=c.id inner join medibv.d_dmbd cc on c.mavp=cc.id left join medibvmmyy.v_ttrvbhyt d on a.id=d.id";
                    asql += " left join medibvmmyy.v_hoantra g on b.quyenso=g.quyenso and b.sobienlai=g.sobienlai ";
                    asql += " where g.id is null and c.madoituong in(1,2)";
                    asql += " and " + m_v.for_ngay("b.ngay", "'dd/mm/yyyy'") + " between ";
                    asql += " to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += " group by a.id , a.mabn, c.madoituong) as froo";
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = 1;
                            r2["noidung"] = "Thuốc bệnh viện";
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = decimal.Parse(r["socabhyt"].ToString());
                            r2["bhytsotien"] = decimal.Parse(r["bhyttra"].ToString());
                            r2["dvca"] = decimal.Parse(r["soca"].ToString());
                            r2["dvsotien"] = decimal.Parse(r["bntra"].ToString());
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["dvca"] = decimal.Parse(dr[0]["dvca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["dvsotien"] = decimal.Parse(dr[0]["dvsotien"].ToString()) + decimal.Parse(r["bntra"].ToString());
                                dr[0]["bhytca"] = decimal.Parse(dr[0]["bhytca"].ToString()) + decimal.Parse(r["socabhyt"].ToString());
                                dr[0]["bhytsotien"] = decimal.Parse(dr[0]["bhytsotien"].ToString()) + decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                    }
                    //
                    asql = "select 'THUOC' as makp, nvl(sum((case when madoituong=1 then 1 else 0 end)),0) as socabhyt, nvl(sum((case when madoituong=1 then 0 else 1 end)),0) as soca, nvl(sum(bntra),0) as bntra, nvl(sum(bhyttra),0) as bhyttra from(";
                    asql += " select a.id , a.mabn, b.madoituong, sum(b.soluong*b.dongia) - sum(case when b.madoituong=1 then case when instr(nvl(d.sothe,' '),'UC')>0 or instr(nvl(d.sothe,' '),'VC')>0 or instr(nvl(d.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end) as bntra,";
                    asql += " sum(case when b.madoituong=1 then case when instr(nvl(d.sothe,' '),'UC')>0 or instr(nvl(d.sothe,' '),'VC')>0 or instr(nvl(d.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end) as bhyttra";
                    asql += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.d_dmbd cc on b.mavp=cc.id left join medibvmmyy.v_bhyt d on a.id=d.id";
                    asql += " left join medibvmmyy.v_hoantra g on a.quyenso=g.quyenso and a.sobienlai=g.sobienlai ";
                    asql += " where g.id is null and b.madoituong in(1,2)";
                    asql += " and " + m_v.for_ngay("a.ngay", "'dd/mm/yyyy'") + " between ";
                    asql += " to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += " group by a.id , a.mabn, b.madoituong) as froo";
                    foreach (DataRow r in m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0].Rows)
                    {
                        r1 = m_v.getrowbyid(ads.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 == null)
                        {
                            r2 = ads.Tables[0].NewRow();
                            r2["stt"] = 1;
                            r2["noidung"] = "Thuốc bệnh viện";
                            r2["makp"] = r["makp"].ToString();
                            r2["bhytca"] = decimal.Parse(r["socabhyt"].ToString());
                            r2["bhytsotien"] = decimal.Parse(r["bhyttra"].ToString());
                            r2["dvca"] = decimal.Parse(r["soca"].ToString());
                            r2["dvsotien"] = decimal.Parse(r["bntra"].ToString());
                            ads.Tables[0].Rows.Add(r2);
                            astt++;
                        }
                        else
                        {
                            dr = ads.Tables[0].Select("makp='" + r["makp"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                dr[0]["dvca"] = decimal.Parse(dr[0]["dvca"].ToString()) + decimal.Parse(r["soca"].ToString());
                                dr[0]["dvsotien"] = decimal.Parse(dr[0]["dvsotien"].ToString()) + decimal.Parse(r["bntra"].ToString());
                                dr[0]["bhytca"] = decimal.Parse(dr[0]["bhytca"].ToString()) + decimal.Parse(r["socabhyt"].ToString());
                                dr[0]["bhytsotien"] = decimal.Parse(dr[0]["bhytsotien"].ToString()) + decimal.Parse(r["bhyttra"].ToString());
                            }
                        }
                    }
                    #endregion
                }
                catch
                {
                }

                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_doanhthu.rpt";
                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                    ads.WriteXml("..//..//Datareport//v_2007_doanhthu.xml", XmlWriteMode.WriteSchema);
                    if (rdThang.Checked)
                    {
                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                    }
                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void f_Doanhthu_Hathanh()
        {
            try
            {
                DataSet ads = null;

                try
                {
                    string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aloaivp = "";

                    auserid = f_Getchecked(dgUser);
                    aquyenso = f_Get_CheckID(tree_Quyenso);
                    adoituong = f_Get_CheckID(tree_Doituong);
                    aloaibn = f_Get_CheckID(tree_LoaiBN);
                    aloaidv = f_Get_CheckID(tree_LoaiDV);
                    aloaivp = f_Get_CheckID(tree_LoaiVP);

                    amakp = f_Get_CheckID(tree_KP);

                    if (amakp != "")
                    {
                        amakp = amakp.Replace(",", "','");
                        amakp = "'" + amakp + "'";
                    }
                    if (chkGio.Checked)
                    {
                        aexp = "to_date(to_char(a.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                    }
                    else
                    {
                        aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    }
                    if (auserid != "")
                    {
                        aexp += " and a.userid in (" + auserid + ")";
                    }
                    if (aquyenso != "")
                    {
                        aexp += " and a.quyenso in (" + aquyenso + ")";
                    }
                    if (aloaidv != "")
                    {
                        aexp += " and a.loai in (" + aloaidv + ")";
                    }
                    if (aloaibn != "")
                    {
                        aexp += " and a.loaibn in (" + aloaibn + ")";
                    }
                    if (adoituong != "")
                    {
                        aexp += " and b.madoituong in(" + adoituong + ")";
                    }
                    if (amakp != "")
                    {
                        aexp += " and b.makp in (" + amakp + ")";
                    }

                    if (txtTuso.Text != "" && txtDenso.Text != "")
                    {
                        aexp += " and a.sobienlai between " + txtTuso.Text.Trim() + " and " + txtDenso.Text.Trim() + "";
                    }
                    aexp = "where " + aexp.Trim();

                    if (chkTTRV.Checked)
                        asql = " select  id,ten,mavp,tenvp,sum(soluong) as soluong,sum(sotien) as sotien from (select k.id,k.ten,i.mavp,i.tenvp";
                    else
                        asql = "select k.id,k.ten,i.mavp,i.tenvp";
                    if (chkMien.Checked)
                        asql += " ,sum((b.soluong- case when b.tra>0 then 1 else 0 end)-case when b.mien>0 then 1 else 0 end)  as soluong";
                    else
                        asql += " ,sum(b.soluong- case when b.tra>0 then 1 else 0 end)  as soluong";

                    asql += " ,sum(b.soluong*b.dongia - b.thieu - b.tra - b.mien) as sotien ";
                    asql += " from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id ";
                    asql += " left join medibv.v_dlogin d on a.userid=d.id inner join medibv.v_nhomkhoabv1ct i on i.mavp=b.mavp inner join medibv.v_nhomkhoabv1ll k on i.id=k.id inner join medibv.v_giavp e on e.id=b.mavp and i.mavp=e.id";
                    asql += " " + aexp + " ";
                    if (aloaivp != "") asql += " and e.id_loai in(" + aloaivp + ")";
                    if (radCothe.Checked) asql += " and a.done=2 ";
                    if (radKhongthe.Checked) asql += " and a.done<>2 ";
                    asql += " group by  k.id,k.ten,i.mavp,i.tenvp";

                    if (chkTTRV.Checked)
                    {
                        asql += " union all ";
                        asql += " select k.id,k.ten,i.mavp,i.tenvp,sum(b.soluong- case when b.tra>0 then 1 else 0 end)  as soluong,sum(b.soluong*b.dongia- b.tra) as sotien ";
                        asql += " from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join medibvmmyy.v_ttrvct b on a.id=b.id  ";
                        asql += " left join medibv.v_dlogin d on a.userid=d.id inner join medibv.v_nhomkhoabv1ct i on i.mavp=b.mavp inner join medibv.v_nhomkhoabv1ll k on i.id=k.id inner join medibv.v_giavp e on e.id=b.mavp and i.mavp=e.id";
                        asql += " " + aexp + " ";
                        if (aloaivp != "") asql += " and e.id_loai in(" + aloaivp + ")";
                        asql += " group by  k.id,k.ten,i.mavp,i.tenvp";
                        asql += " ) a group by id,ten,mavp,tenvp";
                    }
                    ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                }
                catch
                {
                }

                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutructiep_DT_KPBV.rpt";

                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();

                    ads.WriteXml("..//..//Datareport/v_2007_bkthutructiep_DT_KPBV.xml", XmlWriteMode.WriteSchema);
                    if (rdThang.Checked)
                    {

                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                    }


                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void f_Chitiet_TheoloaiVP()
        {
            try
            {
                DataSet ads = f_BC_Loai_Chitiet();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutructiep_loai_chitiet_khonghoan.rpt";

                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    asyt = m_v.Syte + "^" + f_Get_CheckTEN(tree_KP);
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                    ads.WriteXml("..//..//Datareport/v_BCthutructiep_Loai_chitiet_khonghoan.xml", XmlWriteMode.WriteSchema);
                    if (rdThang.Checked)
                    {

                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                    }

                   
                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp chi tiết theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                }
            }
            catch
            {
            }
        }
    
        private void f_BCNhom_VP()
        {
            try
            {
                DataSet ads = f_BC_Nhom();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutructiep_nhomvp.rpt";
                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    asyt = m_v.Syte + "^" + f_Get_CheckTEN(tree_KP);
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                    ads.WriteXml("..//..//Datareport/v_BCthutructiep_nhomVP.xml", XmlWriteMode.WriteSchema);
                    if (rdThang.Checked)
                    {

                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                    }



                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();

                }
            }
            catch
            {
            }
        }

        private void f_BCLoai_VP()
        {
            try
            {
                DataSet ads = f_BC_Loai();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutructiep_loaivp.rpt";
                    
                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    asyt = m_v.Syte + "^" + f_Get_CheckTEN(tree_KP);
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                    ads.WriteXml("..//..//Datareport/v_BCthutructiep_LoaiVP.xml", XmlWriteMode.WriteSchema);                   
                    if (rdThang.Checked)
                    {
                        
                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 16);
                        }
                        else
                        {
                            if (txtTN.Value != txtDN.Value)

                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            else
                                aghichu = lan.Change_language_MessageText("Ngày:") + " " + txtTN.Text.Substring(0, 10);
                        }
                 
                    }
                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
        private void txtNguoilapphieu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtKetoanvp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtThuquy_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtPhongtckt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtNgayin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtTimuser_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtTimuser.Text.Trim().ToLower() == 
lan.Change_language_MessageText("tìm nhanh"))
                {
                    txtTimuser.Text = "";
                }
            }
            catch
            {
            }
        }

        private void txtTimuser_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTimuser.Text.Trim() == "")
                {
                    txtTimuser.Text = 
lan.Change_language_MessageText("Tìm nhanh");
                }
            }
            catch
            {
            }
        }
        private void txtTimso_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtTimso.Text.Trim().ToLower() == 
lan.Change_language_MessageText("tìm nhanh"))
                {
                    txtTimso.Text = "";
                }
            }
            catch
            {
            }
        }

        private void txtTimso_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTimso.Text.Trim() == "")
                {
                    txtTimso.Text = 
lan.Change_language_MessageText("Tìm nhanh");
                }
            }
            catch
            {
            }
        }

        private void txtTimuser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                string atmp = txtTimuser.Text;
                if (atmp.ToLower().Trim() != 
lan.Change_language_MessageText("tìm nhanh") && atmp.ToLower().Trim() != "")
                {
                    aft = "hoten like '%" + atmp + "%' or userid like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgUser.DataSource, dgUser.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtTimso_TextChanged(object sender, EventArgs e)
        {
            f_Load_Tree_Quyenso();
        }

        private void tmn_Export_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_export(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền kết xuất số liệu!"));
                return;
            }
            f_Export();
        }

        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    f_Check(dgUser, dgUser[3, e.RowIndex].Value.ToString(), (dgUser[0, e.RowIndex].Value.ToString() == "1" ? 0 : 1));
                }
            }
            catch
            {
            }
        }
   

        private void frmBKThutructiep_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                m_v.sys_thuquy = txtThuquy.Text;
                m_v.sys_ketoanvp = txtKetoanvp.Text;
                m_v.sys_phongtckt = txtPhongtckt.Text;
            }
            catch
            {
            }
        }
        private string f_Get_CheckID(TreeView v_tree)
        {
            try
            {
                string r = "";
                for (int i = 0; i < v_tree.Nodes.Count; i++)
                {
                    if (v_tree.Nodes[i].Checked) r = r.Trim().Trim(',') + "," + v_tree.Nodes[i].Tag.ToString();
                }
                r = r.Trim().Trim(',');
                return r;
            }
            catch
            {
                return "";
            }
        }
        private string f_Get_CheckTEN(TreeView v_tree)
        {
            try
            {
                string r = "";
                for (int i = 0; i < v_tree.Nodes.Count; i++)
                {
                    if (v_tree.Nodes[i].Checked) r = r.Trim().Trim(',') + "," + v_tree.Nodes[i].Text;
                }
                r = r.Trim().Trim(',');
                return r;
            }
            catch
            {
                return "";
            }
        }
        private void f_Set_CheckID(TreeView v_tree, bool v_b)
        {
            try
            {
                for (int i = 0; i < v_tree.Nodes.Count; i++)
                {
                    v_tree.Nodes[i].Checked = v_b;
                }
            }
            catch
            {
            }
        }

        private void chkLoaiDV_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_LoaiDV, chkLoaiDV.Checked);
        }

        private void chkLoaiBN_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_LoaiBN, chkLoaiBN.Checked);
        }

        private void chkDoituong_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_Doituong, chkDoituong.Checked);
        }

        private void tree_Doituong_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Doituong.Nodes.Count; i++)
                {
                    if (tree_Doituong.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkDoituong.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_LoaiBN_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_LoaiBN.Nodes.Count; i++)
                {
                    if (tree_LoaiBN.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkLoaiBN.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_LoaiDV_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_LoaiDV.Nodes.Count; i++)
                {
                    if (tree_LoaiDV.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkLoaiDV.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_Quyenso_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Quyenso.Nodes.Count; i++)
                {
                    if (tree_Quyenso.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkAll_So.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_KP_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_KP.Nodes.Count; i++)
                {
                    if (tree_KP.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkKhoaphong.Checked = false;
            }
            catch
            {
            }
        }

        private void txtTuso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");                
            }
        }

        private void chkLoaiVP_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_LoaiVP, chkLoaiVP.Checked);
        }

        private void tree_LoaiVP_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_LoaiVP.Nodes.Count; i++)
                {
                    if (tree_LoaiVP.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkLoaiVP.Checked = false;
            }
            catch
            {
            }
        }

        private void chkKhoaphong_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_KP, chkKhoaphong.Checked);
        }

        private void chkGio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGio.Checked)
            {
                txtTN.Width = 113;
                txtDN.Width = 113;
                txtDN.Location = new Point(419, 4);
                label1.Location = new Point(351, 4);
                txtTN.CustomFormat = "dd/MM/yyyy HH:mm";
                txtDN.CustomFormat = "dd/MM/yyyy HH:mm";
            }
            else
            {
                txtTN.Width = 85;
                txtDN.Width = 85;
                txtDN.Location = new Point(391, 4);
                label1.Location = new Point(323, 4);
            }
        }

        private void lblKhaibao_Click(object sender, EventArgs e)
        {
            frmKhaibaokhoaphongbenhvien f = new frmKhaibaokhoaphongbenhvien();
            f.Show();
        }

        private void rdBC10_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBC10.Checked) lblKhaibao.Enabled = true;
            else lblKhaibao.Enabled = false;
        }

        private void radCothe_CheckedChanged(object sender, EventArgs e)
        {
            if (radCothe.Checked)
            {
                radBKthe.Enabled = true;
                radBKthe.Checked = true;
            }
            else
            {
                radBKthe.Enabled = false;
                rdBC_01.Checked = true;
            }
        }

        private void rd_BC12_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_BC12.Checked) label11.Enabled = true;
            else label11.Enabled = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            frmKhaibaoKP_theogiaV f = new frmKhaibaoKP_theogiaV();
            f.Show();
        }

        private void Tao_view(string v_tu, string v_den)
        {


            DateTime dt1 = m_v.StringToDate(v_tu).AddMonths(-4);
            DateTime dt2 = m_v.StringToDate(v_tu).AddMonths(4);
            if (dt1 > dt2) dt1 = dt2;
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "", sql = "", sql_tu="";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (m_v.bMmyy(mmyy))
                    {
                        sql += (sql == "") ? "" : " union all ";
                        sql += " select id, quyenso, sobienlai, ngay from medibv" + mmyy + ".v_ttrvll ";
                        //
                        sql_tu += (sql_tu == "") ? "" : " union all ";
                        sql_tu += " select id, mabn, quyenso, sobienlai,sotien, ngay, idttrv from medibv" + mmyy + ".v_tamung ";
                    }
                }
            }
            sql = " create or replace view medibv.vv_ttrvll" + m_idcomputer + " as " + sql;
            m_v.execute_data(sql);
            sql_tu = " create or replace view medibv.vv_tamung" + m_idcomputer + " as " + sql_tu;
            m_v.execute_data(sql_tu);

        }

        private void chkkhoacuoi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkkhoacuoi_Click(object sender, EventArgs e)
        {
            m_v.writeXml("thongso", "bangkethutt_khoacuoi", chkkhoacuoi.Checked ? "1" : "0");
        }
    }
}