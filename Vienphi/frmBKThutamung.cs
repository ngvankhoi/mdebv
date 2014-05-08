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
    public partial class frmBKThutamung : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_userid = "";
        private LibVP.AccessData m_v;
        private string m_menu_id = "menu_B_2_Baocaotieuban";
        private bool bKetxuatExcel = true;
        
        public frmBKThutamung(LibVP.AccessData v_v, string v_userid)
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
        private void frmBKThutamung_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            f_Check(dgUser, m_userid);
            chkGio_CheckedChanged(null, null);
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

                string sql = "";
                sql = "select 0 as chon,hoten,userid,id from medibv.v_dlogin ";
                if (m_v.sys_Loctheonguoidangnhap && !bAdmin) sql += " where id =" + m_userid + "";
                sql += " order by hoten";
                dgUser.DataSource = m_v.get_data(sql).Tables[0];  
             
                f_Load_CB_Maubaocao();
                f_Load_Tree_Quyenso();
                f_Load_Tree_Doituong();
                f_Load_tree_LoaiBN();
                f_Load_tree_LoaiDV();
                f_Load_tree_KP();
            }
            catch
            {
            }
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
         private DataSet f_Get_Maubaocaotructiep()
        {
            	//v_maubaocao 
			//loai=1: Báo cáo thu viện phí trực tiếp (v_vienphill, v_vienphict, v_mienngtru, v_bhyt)
			//loai=2: Báo cáo thanh toán ra viện ngoại trú + nội trú (v_ttrvll, v_ttrvct, v_ttrvbhyt, v_ttrvds, v_miennoitru)
			//loai=3: Báo cáo thu tạm ứng
			//loai=4: Báo cáo miễn giảm
            DataSet ads = new DataSet();
            try
            {
                //try
                //{
                //    int n = 0;
                //    n = m_v.get_data("select * from medibv.v_maubaocao where rownum<=2").Tables[0].Rows.Count;
                //}
                //catch
                //{
                //    m_v.execute_data("create table " + m_v.s_schemaroot + ".v_maubaocao(id numeric(3), ma text, ten text, loai numeric(1), constraint pk_v_maubaocao primary key(id)) with oids");
                //    m_v.execute_data("alter table " + m_v.s_schemaroot + ".v_maubaocao owner to " + m_v.s_database + "");
                //}
                ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=3");
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
        private void f_Load_tree_LoaiDV()
        {
            try
            {

                f_Load_Tree(tree_Loaidv, m_v.get_data("select to_char(ma,'9') as ma, ten from medibv.v_tenloaivp order by ten asc"));
            }
            catch
            {
            }
        }
        private void f_Load_tree_LoaiBN()
        {
            try
            {                
                f_Load_Tree(tree_Loaibn, m_v.get_data("select to_char(id,'9') ma, ten from medibv.v_loaibn order by id"));
            }
            catch
            {
            }
        }
        private void f_Load_tree_KP()
        {
            try
            {
                f_Load_Tree(tree_Khoaphong, m_v.get_data("select makp as ma, tenkp as ten from medibv.btdkp_bv order by loai, tenkp"));
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
                string sql = "", aexp = "",aexpht = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "",amakp="";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);

                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);

                if (amakp != "")
                {
                    amakp = amakp.Replace(",","','");
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
                aexpht = aexp;//gam 12/09/2011 điều kiện lấy biên lai hoàn trả bỏ bớt đk madoituong
                if (auserid != "")
                {
                    aexp += " and a.userid in (" + auserid + ")";
                }
                if (adoituong != "")
                {  
                    aexp += " and a.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexpht += " and a.makp in (" + amakp + ")";//gam 12/09/2011
                    aexp += " and a.makp in (" + amakp + ")";
                }
                aexp += " and a.id not in (select id from medibvmmyy.v_huybienlai where tables='v_tamung')";//gam 05/12/2011 không lấy hóa đơn đã hủy lên báo cáo
                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    if (decimal.Parse(txtTS.Text.Trim()) > decimal.Parse(txtDS.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTS.Focus();
                        return null;
                    }
                    else
                    {
                        aexp += " and a.sobienlai between " + txtTS.Text.Trim() + " and " + txtDS.Text.Trim() + "";
                    }
                }
                if (rbt_tamung.Checked)
                {
                    aexp += " and a.done = 0";
                }
                aexp = "where " + aexp.Trim();
                aexpht = "where " + aexpht.Trim();
                sql = "select a.id,a.mabn,a.mavaovien,a.maql,a.loai,a.loaibn,b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) as diachi, c.tentt, c1.tenquan, c2.tenpxa, c3.madoituong, c3.doituong, c4.makp,c4.tenkp, c4.viettat, to_char(a.ngay,'dd/mm/yyyy') as ngay,a.sotien,d.hoten as user_hoten, d.userid as user_username,a.userid, a.quyenso, a.sobienlai, e.sohieu, e.sohieubl,";
                //sql += " to_number(0,'9') as hoan ";//trang 18/10/2011 tính lại hoàn trong ngày, khác ngày va chua hoàn 
                sql += " case when (to_date(to_char(a.ngaytra,'dd/mm/yyyy'),'dd/mm/yyyy') is null) then 0 else case when(to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')=to_date(to_char(a.ngaytra,'dd/mm/yyyy'),'dd/mm/yyyy'))then 1 else 2 end end as hoan ";
                //end trang
                sql += "from medibvmmyy.v_tamung a left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.doituong c3 on a.madoituong=c3.madoituong left join medibv.btdkp_bv c4 on a.makp=c4.makp left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 " + aexp + "";
                ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);

                if (rdBC_02.Checked || rdBC_03.Checked)//Bo hoan, Cong hoàn
                {
                    sql = "select a.id,a.quyenso,a.sobienlai,to_char(a.ngay,'dd/mm/yyyy') as ngay, to_char(a.ngayud,'dd/mm/yyyy') as ngayud,a.mabn,a.mavaovien,a.maql,a.loai,a.loaibn,a.userid from medibvmmyy.v_hoantra a " + aexpht;//gam 12/09/2011
                    //Thuy 26.12.2011
                    if (chkhoanhdtructiep.Checked)
                    {
                        sql += " and a.ghichu != 'TTRV'";
                    }//end Thuy
                    adsh = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    if (ads != null && adsh!=null)
                    {
                        if (rdBC_02.Checked)//Bo hoan
                        {
                            foreach (DataRow r in adsh.Tables[0].Rows) //0904705996
                            {
                                try
                                {
                                    foreach (DataRow r1 in ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "'"))//and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + "  and userid=" + r["userid"].ToString()
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
                                    aexp = "where " + "a.quyenso=" + r["quyenso"].ToString() + " and a.sobienlai=" + r["sobienlai"].ToString() + " and a.mabn='" + r["mabn"].ToString() + "'";// and a.mavaovien=" + r["mavaovien"].ToString() + " and a.maql=" + r["maql"].ToString() + " and a.loai=" + r["loai"].ToString();// +" and a.loaibn=" + r["loaibn"].ToString();
                                    if (adoituong != "")
                                    {
                                        aexp += " and a.madoituong in (" + adoituong + ")";
                                    }
                                    if (amakp != "")
                                    {
                                        aexp += " and a.makp in (" + amakp + ")";
                                    }
                                    sql = "select a.id,a.mabn,a.mavaovien,a.maql,a.loai,a.loaibn,b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) as diachi, c.tentt, c1.tenquan, c2.tenpxa, c3.madoituong, c3.doituong, c4.makp,c4.tenkp, c4.viettat, to_char(a.ngay,'dd/mm/yyyy') as ngay,a.sotien,d.hoten as user_hoten, d.userid as user_username,a.userid, a.quyenso, a.sobienlai, e.sohieu, e.sohieubl, to_number(1,'9') as hoan from medibvmmyy.v_tamung a left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.doituong c3 on a.madoituong=c3.madoituong left join medibv.btdkp_bv c4 on a.makp=c4.makp left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 " + aexp + "";
                                    adst = m_v.get_data_mmyy(ammyy, sql);

                                    foreach (DataRow r1 in adst.Tables[0].Rows)
                                    {
                                        if (ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "' and userid=" + r["userid"].ToString()).Length <= 0)// + " and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + " and loaibn=" + r["loaibn"].ToString()
                                        {
                                            ads.Tables[0].Rows.Add(r1.ItemArray);
                                        }

                                        foreach (DataRow r2 in ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "'"))// and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + " and loaibn=" + r["loaibn"].ToString()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads;
        }

        private DataSet f_Get_Data_TU()
        {
            DataSet ads_tu = new DataSet();
            
            try
            {
                string sql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "",amakp="";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);

                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);

                if (amakp != "")
                {
                    amakp = amakp.Replace(",","','");
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
                    aexp += " and a.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a.makp in (" + amakp + ")";
                }
                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    if (decimal.Parse(txtTS.Text.Trim()) > decimal.Parse(txtDS.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTS.Focus();
                        return null;
                    }
                    else
                    {
                        aexp += " and a.sobienlai between " + txtTS.Text.Trim() + " and " + txtTS.Text.Trim() + "";
                    }
                }
                
                aexp = "where " + aexp.Trim();
                //gam 24/08/2011
                sql = "select distinct a.id,a1.mabn,a1.mavaovien,a1.maql,a.loai,a.loaibn,b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) as diachi, c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat, to_char(a.ngay,'dd/mm/yyyy') as ngay,a.tamung as sotien";
                sql +=" ,d.hoten as user_hoten, d.userid as user_username,a.userid, a.quyenso, a.sobienlai, e.sohieu, e.sohieubl, to_number(0,'9') as hoan";
                sql += " from medibvmmyy.v_ttrvct a2 inner join medibvmmyy.v_ttrvll a on a2.id = a.id inner join medibvmmyy.v_ttrvds a1 on a1.id = a.id left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa ";
                sql += " left join medibv.doituong c3 on a2.madoituong=c3.madoituong left join medibv.btdkp_bv c4 on a.makp=c4.makp left join medibv.v_dlogin d on a.userid=d.id left join medibv.v_quyenso e on a.quyenso=e.id and e.hide=0 " + aexp + " and (a.loaibn<>3 and to_number(a.idtonghop)>0) and a.tamung > 0";
                //end gam
                ads_tu = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads_tu;
        }

        private void f_Datamung()
        {
            string areport = "";
            string acurdir = System.Environment.CurrentDirectory;
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;
            try
            {
                DataSet ads_tu = f_Get_Data_TU();
                if (ads_tu != null)
                {
                    string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutamung.rpt";
                    
                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\Report_vp\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                    if (rdThang.Checked)
                    {
                        aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                    }
                    else
                    {
                        if (chkGio.Checked)
                        {
                            aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                        }
                        else
                        {
                            aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                        }
                    }

                    if (!System.IO.Directory.Exists("..//..//Datareport//"))
                    {
                        System.IO.Directory.CreateDirectory("..//..//Datareport//");
                    }
                    ads_tu.WriteXml("..//..//Datareport//v_BKtamung.xml", XmlWriteMode.WriteSchema);

                    if (!System.IO.Directory.Exists("..\\..\\Report_vp\\"))
                    {
                        System.IO.Directory.CreateDirectory("..\\Report_vp\\");
                    }
                    if (ads_tu.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                        return;
                    }


                    if ((chkInrieng.Checked == false && chkInchung.Checked == false) || chkInrieng.Checked)
                    {
                        frmReport fa = new frmReport(m_v, ads_tu.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu viện phí trực tiếp", 1, chkXemkhiin.Checked ? true : false);
                        fa.KetxuatExcel = bKetxuatExcel;
                        fa.ShowDialog();
                    }
                    if (chkInchung.Checked)
                    {
                        areport = areport.Replace(".rpt", "_inchung.rpt");
                        frmReport fa = new frmReport(m_v, ads_tu.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu viện phí trực tiếp", 1, chkXemkhiin.Checked ? true : false);
                        fa.KetxuatExcel = bKetxuatExcel;
                        fa.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(areport + "\n" + ex.ToString());
            }
            finally
            {
                System.Environment.CurrentDirectory = acurdir;
                tmn_Export.Enabled = true;
                tmn_Xem.Enabled = true;
            }
        }

        private void f_Xem()
        {
            string areport = "";
            string acurdir = System.Environment.CurrentDirectory;
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;
            try
            {
                DataSet ads = f_Get_Data();
                if (ads != null)
                {                    
                    string  asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthutamung.rpt";
                    if (rdBC_03.Checked)
                    {
                        areport = "v_2007_bkthutamung_conghoan.rpt";
                    }

                    if (cbMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cbMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\Report_vp\\" + areportt))
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
                            aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                        }
                        else
                        {
                            aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                        }
                    }

                    if (!System.IO.Directory.Exists("..//..//Datareport//"))
                    {
                        System.IO.Directory.CreateDirectory("..//..//Datareport//");
                    }
                    ads.WriteXml("..//..//Datareport//v_BKtamung.xml", XmlWriteMode.WriteSchema);

                    if (!System.IO.Directory.Exists("..\\..\\Report_vp\\"))
                    {
                        System.IO.Directory.CreateDirectory("..\\Report_vp\\");
                    }
                    if (ads.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                        return ;
                    }
               

                    if ((chkInrieng.Checked == false && chkInchung.Checked == false) || chkInrieng.Checked)
                    {
                        frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu viện phí trực tiếp",1,chkXemkhiin.Checked?true:false);
                        fa.KetxuatExcel = bKetxuatExcel;
                        fa.ShowDialog();
                    }
                    if (chkInchung.Checked)
                    {
                        areport = areport.Replace(".rpt", "_inchung.rpt");
                        frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu viện phí trực tiếp",1,chkXemkhiin.Checked?true:false);
                        fa.KetxuatExcel = bKetxuatExcel;
                        fa.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(areport + "\n" + ex.ToString());
            }
            finally
            {
                System.Environment.CurrentDirectory = acurdir;
                tmn_Export.Enabled = true;
                tmn_Xem.Enabled = true;
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
                dv.Table.AcceptChanges();
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
                dv.Table.AcceptChanges();
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
                dv.Table.AcceptChanges();
                v_dgv.Update();
            }
            catch
            {
            }
        }
        private void f_Check1(DataGridView v_dgv, string v_val)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[v_dgv.DataSource, v_dgv.DataMember]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("id='" + v_val + "'"))
                {
                    r["chon"] = 1;
                }
                dv.Table.AcceptChanges();
                v_dgv.Update();
            }
            catch
            {
            }
        }
        private void f_Check1(DataGridView v_dgv, string v_id, int v_val)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[v_dgv.DataSource, v_dgv.DataMember]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("id='" + v_id + "'"))
                {
                    r["chon"] = v_val;
                }
                dv.Table.AcceptChanges();
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

        private void chkAll_Doituong_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_Doituong, chkAll_Doituong.Checked);
        }

        private void chkAll_Loaibn_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_Loaibn, chkAll_Loaibn.Checked);
        }

        private void chkAll_Loaidv_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_Loaidv, chkAll_Loaidv.Checked);
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
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            bKetxuatExcel = m_v.f_quyenchitiet_export(aquyenchitiet);
            //
            if (rbt_datamung.Checked)
                f_Datamung();
            else
                f_Xem();
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
                if (txtTimuser.Text.Trim().ToLower() == "tìm nhanh")
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
                if (txtTimso.Text.Trim().ToLower() == "tìm nhanh")
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
                if (atmp.ToLower().Trim() != "tìm nhanh" && atmp.ToLower().Trim() != "")
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
            bKetxuatExcel = m_v.f_quyenchitiet_export(aquyenchitiet);
            if (bKetxuatExcel == false)
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
                    f_Check(dgUser, dgUser[3, e.RowIndex].Value.ToString(), (dgUser[0, e.RowIndex].Value.ToString() == "1"?0:1));
                }
            }
            catch
            {
            }
        }
                    
        private void frmBKThutamung_FormClosing(object sender, FormClosingEventArgs e)
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

        private void chkAll_KP_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_Khoaphong, chkAll_KP.Checked);
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

        private void tree_Khoaphong_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Khoaphong.Nodes.Count; i++)
                {
                    if (tree_Khoaphong.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkAll_KP.Checked = false;
            }
            catch
            {
            }
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
                chkAll_Doituong.Checked = false;
            }
            catch
            {
            }
        }

        private void txtTS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void chkGio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGio.Checked)
            {
                txtTN.Width = 113;
                txtDN.Width = 113;
                txtTN.CustomFormat = "dd/MM/yyyy HH:mm";
                txtDN.CustomFormat = "dd/MM/yyyy HH:mm";               
            }
            else
            {
                txtTN.Width = 85;
                txtDN.Width = 85;
                txtTN.CustomFormat = "dd/MM/yyyy HH:mm";
                txtDN.CustomFormat = "dd/MM/yyyy HH:mm";
            }
        }

    
    }
}