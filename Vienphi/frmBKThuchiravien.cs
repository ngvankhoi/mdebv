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
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

namespace Vienphi
{
    public partial class frmBKThuchiravien : Form
    {
        Language lan = new Language();

        private string m_userid = "", m_sqlnhom = "", m_sqlloai = "",  tenfile = "";
        private string m_menu_id = "menu_B_3_Hoachatxetnghiem";
        private bool bKetxuatExcel = true;
        private DataSet ads_loai = new DataSet();
        private DataSet ads_nhom = new DataSet();
        DataSet adsTU ;
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        Excel.Range orange;

        private LibVP.AccessData m_v;
        //private LibVP.AccessData b = new LibVP.AccessData();
        public frmBKThuchiravien(LibVP.AccessData v_v, string v_userid)
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

        private void frmBKThuchiravien_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            f_Check(dgUser, m_userid);
            chkGio_CheckedChanged(null, null);
            rdBC_04_CheckedChanged(null, null);
            rdBC_05_CheckedChanged(null, null);
            //if (chk_mien.Checked && (rdBC_01.Checked || rdBC_02.Checked || rdBC_03.Checked)) chk100.Enabled = true;
            //else chk100.Enabled = false;
        }

        private void f_Load_Default()
        {
            try
            {                
                ads_nhom = m_v.get_data("select ma, stt,ten from medibv.v_nhomvp order by ma asc");
                for (int i = 0; i < ads_nhom.Tables[0].Rows.Count; i++)
                {
                    m_sqlnhom = m_sqlnhom + ",sum(case when i.ma=" + ads_nhom.Tables[0].Rows[i]["MA"].ToString() + " then a4.soluong*a4.dongia else 0 end ) LL" + i.ToString();                   
                }
                m_sqlnhom = "," + m_sqlnhom.Trim(',');
                ads_loai = m_v.get_data("select id,ma,stt,ten from medibv.v_loaivp order by id asc");
                for (int i = 0; i < ads_loai.Tables[0].Rows.Count; i++)
                {
                    m_sqlloai = m_sqlloai + ",sum(case when h.id=" + ads_loai.Tables[0].Rows[i]["ID"].ToString() + " then a4.soluong*a4.dongia else 0 end ) LL_" + i.ToString();                    
                }
                m_sqlloai = "," + m_sqlloai.Trim(',');
            }
            catch
            {
            }
        }

        private string get_ten(int i)
        {
            string[] ten ={ "Số biên lai", "Ngày", "Quyển sổ", "Mã BN", "Họ tên", "Năm sinh", "Địa chỉ", "Thẻ BHYT", "Mã BV", "Tên bệnh viện", "Người thu", "Ngày vào", "Ngày ra", "Mã ICD", "Chẩn đoán", "Tên KP", "Tổng chi phí", "BHYT", "Miễn", "Thiếu", "Tạng ứng" };
            return ten[i];
        }

        private string get_ten_loai_kp(int i)
        {
            string[] ten ={ "Số STT", "Nội dung thu"};
            return ten[i];
        }

        private string get_ten_SBL(int i)
        {
            string[] ten ={ "Số STT", "Quyển sổ", "Số biên lai" };
            return ten[i];
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

                f_Load_CB_Maubaocao();
                f_Load_Tree_Quyenso();
                f_Load_Tree_Doituong();
                f_Load_tree_LoaiBN();
                f_Load_tree_LoaiDV();
                f_Load_tree_KP();
                f_Load_Default();
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
                f_Load_Tree(tree_Khoaphong, m_v.get_data("select makp as ma, tenkp as ten from medibv.btdkp_bv where loai=0 order by loai, tenkp"));
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
           
                ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=2");
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
            DataSet ads = null, adsh = null, adst = null;
            string ammyy = "";
            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aexpt = "", aexpttrv = "", aexptamungtrongngay = "";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);

                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a1.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    aexptamungtrongngay = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a1.userid in (" + auserid + ")";
                    aexptamungtrongngay += " and a1.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a1.quyenso in (" + aquyenso + ")";
                    aexptamungtrongngay += " and a1.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a1.loai in (" + aloaidv + ")";
                    aexptamungtrongngay += " and a1.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a1.loaibn in (" + aloaibn + ")";
                    aexptamungtrongngay += " and a1.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and a4.madoituong in (" + adoituong + ")";
                    aexptamungtrongngay += " and a4.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a1.makp in (" + amakp + ")";
                    aexptamungtrongngay += " and a1.makp in (" + amakp + ")";
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
                        aexp += " and a1.sobienlai >= " + txtTS.Text.Trim() + " and a1.sobienlai <= " + txtDS.Text.Trim() + "";
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and a1.sobienlai<0";
                    }
                    else
                        if (chkInchungmien.Checked)
                        {
                            aexp += " and a1.sobienlai>0";
                        }
                }
                if (chkThatthu.Checked)
                {
                    aexpttrv += " and a1.thieu > 0";
                    aexpt += " and a4.thieu > 0";
                }
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexpttrv += " and a1.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexpttrv += " and a1.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexpttrv += " and a1.loaithu in(1)";
                }
                //else
                //{
                //    aexpttrv += " and a1.thieu <= 0 ";
                //    aexpt += " and a4.thieu <= 0 ";
                //}

                aexp = "where " + aexp.Trim();
                aexptamungtrongngay = "where " + aexptamungtrongngay.Trim();
                //gốc asql = "select a.id, a.mabn, a.mavaovien, a.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| c.tentt as diachi,c.tentt as tentt, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, a1.sotien, 0 as tamungngay, a1.tamung, sum(case when a4.madoituong=3 then a4.sotien else 0 end) as mien,sum(case when a4.madoituong=5 then a4.sotien else 0 end) as haophi, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai,0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                //thanh thúy 05/05/2011 sua miễn
                asql = "select a.id, a.mabn, a.mavaovien, a.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| c.tentt as diachi,c.tentt as tentt, ";
              //khuyen 17/02/14  " case when x.makp is null then c4.makp else x.makp end as makp, case when x.makp is null then c4.tenkp else y.tenkp end as tenkp, "+
              //khuyen 17/02/14  
                if (m_v.Mabv == "711.5.001")//bv quan doan 4
                    asql += "   a4.makp  as makp,   z.tenkp as tenkp, ";
                else
                asql += " case when x.makp is null then c4.makp else x.makp end as makp, case when x.makp is null then c4.tenkp else y.tenkp end as tenkp, ";

                asql += "  c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, a1.sotien, 0 as tamungngay, a1.tamung, nvl(a1.mien,0) as mien,";
                  asql += "  sum(case when a4.madoituong=5 then a4.sotien else 0 end) as haophi, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai,0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra ";
                 if (rdBC_13.Checked)
                {
                    asql += ",a4.vat";
                }
                else
                {
                    asql += ",0 as vat";
                }
                asql += ",b.msthue ";
                asql += " from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma ";

                asql += " left join medibv.xuatvien x on a.maql=x.maql left join medibv.btdkp_bv y on x.makp=y.makp ";
                if (m_v.Mabv == "711.5.001")//bv quan doan 4
                {
                    asql += " left join medibv.btdkp_bv z on a4.makp=z.makp ";
                }

                asql += aexp + " " + aexpttrv + "";
                asql += " group by a.id,a.mabn,a.mavaovien,a.maql,a1.loai,hs.ten,a1.loaibn,to_char(a.ngayvao,'dd/mm/yyyy') ,to_char(a.ngayra,'dd/mm/yyyy'),b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end , trim(b.sonha || ' '||b.thon) ,c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') , a1.sotien, a1.tamung, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten , d.userid, a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl,a1.mien,b.msthue, x.makp, y.tenkp ";
                if (m_v.Mabv == "711.5.001")//bv quan doan 4
                {
                    asql += " ,a4.makp ,z.tenkp ";
                }
                if (rdBC_13.Checked)
                {
                    asql += ",a4.vat ";
                }
                if (chkTT.Checked)
                {
                    asql += " union all";
                    if (!chkTTRV.Checked) asql = "";
                    //gốc asql += " select a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, a1.hoten, a1.namsinh, a1.diachi as diachi,null as tentt,  a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, sum(nvl(a4.soluong,0)*nvl(a4.dongia,0)) as sotien,0 as tamungngay, to_number('0') as tamung, sum(case when a4.madoituong=3 then a4.soluong*a4.dongia else 0 end) as mien,sum(case when a4.madoituong=5 then a4.soluong*a4.dongia else 0 end) as haophi, sum(to_number((case when a4.madoituong =1 then nvl(a4.mien,0) else 0 end))) as bhyt, to_number('0') as nopthem, a4.thieu, to_number('0') as thua, to_number('0') as chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai,0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                    //thanh thúy 05/05/2011 sửa miẽn
                    asql += " select a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, a1.hoten, a1.namsinh, a1.diachi as diachi,null as tentt,  a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, sum(nvl(a4.soluong,0)*nvl(a4.dongia,0)) as sotien," +
                        "0 as tamungngay, to_number('0') as tamung, sum(nvl(a4.mien,0)) as mien,sum(case when a4.madoituong=5 then a4.soluong*a4.dongia else 0 end) as haophi, sum(to_number((case when a4.madoituong =1 then nvl(a4.mien,0) else 0 end))) as bhyt, to_number('0') as nopthem, a4.thieu, to_number('0') as thua, to_number('0') as chenhlech, d.hoten as user_hoten, " +
                        "d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai,0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra ";
                    if (rdBC_13.Checked)
                    {
                        asql += ",a4.vat,bn.msthue";
                    }
                    else
                    {
                        asql += ",0 as vat,bn.msthue";
                    }
                    asql += " from medibvmmyy.v_vienphill a1 left join medibvmmyy.v_vienphict a4 on a1.id = a4.id  left join medibvmmyy.v_mienngtru c on a1.id=c.id left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma left join medibv.btdbn bn on a1.mabn=bn.mabn " + aexp + " " + aexpt + "";
                    asql += " group by a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy'), to_char(a1.ngay,'dd/mm/yyyy'), a1.hoten, a1.namsinh, a1.diachi, a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy'), a4.mien, a4.thieu, d.hoten, d.userid,a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl, c.sotien,a4.mien,bn.msthue ";
                    if (rdBC_13.Checked)
                    {
                        asql += ",a4.vat ";
                    }
                }
                //ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (chkTU.Checked)
                {
                    asql += " union all";                    
                    asql += " select a1.id, a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| c.tentt as diachi," +
                        "c.tentt as tentt, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, 0 as sotien, a1.sotien as tamungngay, 0 as tamung, 0 as mien,0 as haophi, 0 as bhyt, 0 as nopthem, 0 as thieu, 0 as thua, 0 as chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso,0 as sobienlai, a1.sobienlai as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,0 as tra,0 as vat,b.msthue ";
                    asql += " from medibvmmyy.v_tamung a1 left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma " + aexptamungtrongngay + " " + aexpttrv + " ";
                    asql += " group by a1.id,a1.mabn,a1.mavaovien,a1.maql,a1.loai,hs.ten,a1.loaibn,to_char(a1.ngay,'dd/mm/yyyy') ,b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end , trim(b.sonha || ' '||b.thon) ,c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat , a1.sotien, d.hoten , d.userid, a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl,b.msthue";
                }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                //adsTU = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                //ads.Tables[0].Merge(adsTU.Tables[0]);

                //hoantra:start
                asql = "select a1.id,a1.quyenso,a1.sobienlai,to_char(a1.ngay,'dd/mm/yyyy') as ngay, to_char(a1.ngayud,'dd/mm/yyyy') as ngayud,a1.mabn,a1.mavaovien,a1.maql,a1.loai,a1.loaibn,a1.userid from medibvmmyy.v_hoantra a1 where a1.sotien >0 and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                if (auserid != "")
                {
                    asql += " and a1.userid in (" + auserid + ")";
                }
                //if (aquyenso != "")
                //{
                //    asql += " and a1.quyenso in (" + aquyenso + ")";
                //}
                if (txtTS.Text != "")
                {
                    asql += " and a1.sobienlai >=" + txtTS.Text + "";
                }
                if (txtDS.Text != "")
                {
                    asql += " and a1.sobienlai <=" + txtDS.Text + "";
                }

                adsh = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (ads != null && adsh != null)
                {
                    //bohoan:start
                    if (rdBC_02.Checked || chkKhonginhoantra.Checked)
                    {
                        foreach (DataRow r in adsh.Tables[0].Rows)
                        {
                            try
                            {
                                while (ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "' and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + " and loaibn=" + r["loaibn"].ToString()).Length > 0)
                                {
                                    DataRow r1 = ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "' and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + " and loaibn=" + r["loaibn"].ToString())[0];
                                    ads.Tables[0].Rows.Remove(r1);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    //bohoan:end

                    //conghoan:start
                    if (rdBC_03.Checked || (!chkKhonginhoantra.Checked && !rdBC_02.Checked))
                    {
                        foreach (DataRow r in adsh.Tables[0].Rows)
                        {
                            try
                            {
                                ammyy = m_v.get_mmyy(r["ngayud"].ToString());

                                asql = "select a.id, a.mabn, a.mavaovien, a.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| c.tentt as diachi,c.tentt, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, sum(nvl(a4.soluong,0)*nvl(a4.dongia,0)) as sotien, to_number('0') as tamungngay, a1.tamung, a1.mien, to_number('0') as haophi, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai, 0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                                asql += " from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma ";
                                asql += "where " + "a1.quyenso=" + r["quyenso"].ToString() + " and a1.sobienlai=" + r["sobienlai"].ToString() + " and a.mabn='" + r["mabn"].ToString() + "' and a.mavaovien=" + r["mavaovien"].ToString() + " and a.maql=" + r["maql"].ToString() + " and a1.loai=" + r["loai"].ToString() + " and a1.loaibn=" + r["loaibn"].ToString();
                                asql += " group by a.id,a.mabn,a.mavaovien,a.maql,a1.loai,hs.ten,a1.loaibn,to_char(a.ngayvao,'dd/mm/yyyy') ,to_char(a.ngayra,'dd/mm/yyyy'),b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end , trim(b.sonha || ' '||b.thon) ,c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') , a1.sotien, a1.tamung, a1.mien, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten , d.userid, a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl";
                                if (chkTT.Checked)
                                {
                                    asql += " union all";
                                    if (!chkTTRV.Checked) asql = "";

                                    asql += " select a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, a1.hoten, a1.namsinh, a1.diachi as diachi,null as tentt, a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, sum(nvl(a4.soluong,0)*nvl(a4.dongia,0)) as sotien, to_number('0') as tamungngay, to_number('0') as tamung, case when c.sotien is null then 0 else c.sotien end as mien, to_number('0') as haophi, sum(to_number((case when a4.madoituong =1 then nvl(a4.mien,0) else 0 end))) as bhyt, to_number('0') as nopthem, a4.thieu, to_number('0') as thua, to_number('0') as chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai, 0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                                    asql += " from medibvmmyy.v_vienphill a1 left join medibvmmyy.v_vienphict a4 on a1.id = a4.id  left join medibvmmyy.v_mienngtru c on a1.id=c.id left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma ";
                                    asql += "where " + "a1.quyenso=" + r["quyenso"].ToString() + " and a1.sobienlai=" + r["sobienlai"].ToString() + " and a1.mabn='" + r["mabn"].ToString() + "' and a1.mavaovien=" + r["mavaovien"].ToString() + " and a1.maql=" + r["maql"].ToString() + " and a1.loai=" + r["loai"].ToString() + " and a1.loaibn=" + r["loaibn"].ToString();
                                    asql += " group by a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy'), to_char(a1.ngay,'dd/mm/yyyy'), a1.hoten, a1.namsinh, a1.diachi, a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy'), a4.mien, a4.thieu, d.hoten, d.userid,a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl, c.sotien";
                                }

                                adst = m_v.get_data_mmyy(ammyy, asql);

                                foreach (DataRow r1 in adst.Tables[0].Rows)
                                {
                                    if (ads.Tables[0].Select("quyenso=" + r1["quyenso"].ToString() + " and sobienlai=" + r1["sobienlai"].ToString() + " and mabn='" + r1["mabn"].ToString() + "' and mavaovien=" + r1["mavaovien"].ToString() + " and maql=" + r1["maql"].ToString() + " and loai=" + r1["loai"].ToString() + " and loaibn=" + r1["loaibn"].ToString() + " and userid=" + r1["userid"].ToString()).Length <= 0)
                                    {
                                        ads.Tables[0].Rows.Add(r1.ItemArray);
                                    }

                                    foreach (DataRow r2 in ads.Tables[0].Select("quyenso=" + r1["quyenso"].ToString() + " and sobienlai=" + r1["sobienlai"].ToString() + " and mabn='" + r1["mabn"].ToString() + "' and mavaovien=" + r1["mavaovien"].ToString() + " and maql=" + r1["maql"].ToString() + " and loai=" + r1["loai"].ToString() + " and loaibn=" + r1["loaibn"].ToString()))
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
                    //conghoan:end
                }
                //hoantra:end
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads;
        }
        /// <summary>
        /// Bo- khong dung
        /// </summary>
        /// <returns></returns>
        private DataSet f_Get_Data_bo()
        {
            DataSet ads = null, adsh = null,adst=null;
            string ammyy = "";
            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "", aexpt = "", aexpttrv = "", aexptamungtrongngay="";
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
                    aexp = "to_date(to_char(a1.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    aexptamungtrongngay = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and a1.userid in (" + auserid + ")";
                    aexptamungtrongngay += " and a1.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a1.quyenso in (" + aquyenso + ")";
                    aexptamungtrongngay += " and a1.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a1.loai in (" + aloaidv + ")";
                    aexptamungtrongngay += " and a1.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a1.loaibn in (" + aloaibn + ")";
                    aexptamungtrongngay += " and a1.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and a4.madoituong in (" + adoituong + ")";
                    aexptamungtrongngay += " and a4.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a1.makp in (" + amakp + ")";
                    aexptamungtrongngay += " and a1.makp in (" + amakp + ")";
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
                        aexp += " and a1.sobienlai >= " + txtTS.Text.Trim() + " and a1.sobienlai <= " + txtDS.Text.Trim() + "";
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and a1.sobienlai<0";
                    }
                    else
                    if (chkInchungmien.Checked)
                    {
                        aexp += " and a1.sobienlai>0";
                    }
                }
                if (chkThatthu.Checked)
                {
                    aexpttrv += " and a1.thieu > 0";
                    aexpt += " and a4.thieu > 0";
                }

                //else
                //{
                //    aexpttrv += " and a1.thieu <= 0 ";
                //    aexpt += " and a4.thieu <= 0 ";
                //}
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexpttrv += " and a1.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexpttrv += " and a1.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexpttrv += " and a1.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();
                aexptamungtrongngay = "where " + aexptamungtrongngay.Trim();
                //gốc asql = "select a.id, a.mabn, a.mavaovien, a.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| c.tentt as diachi,c.tentt as tentt, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, a1.sotien, 0 as tamungngay, a1.tamung, sum(case when a4.madoituong=3 then a4.sotien else 0 end) as mien,sum(case when a4.madoituong=5 then a4.sotien else 0 end) as haophi, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai,0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                //thanh thúy 05/05/2011 sua miễn
                asql = "select a.id, a.mabn, a.mavaovien, a.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| c.tentt as diachi,c.tentt as tentt, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, a1.sotien, 0 as tamungngay, a1.tamung, nvl(a1.mien,0) as mien,"+
                    "sum(case when a4.madoituong=5 then a4.sotien else 0 end) as haophi, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai,0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra,a4.vat,b.msthue ";
                asql += " from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma " + aexp + " " + aexpttrv + "";
                asql += " group by a.id,a.mabn,a.mavaovien,a.maql,a1.loai,hs.ten,a1.loaibn,to_char(a.ngayvao,'dd/mm/yyyy') ,to_char(a.ngayra,'dd/mm/yyyy'),b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end , trim(b.sonha || ' '||b.thon) ,c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') , a1.sotien, a1.tamung, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten , d.userid, a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl,a1.mien,a4.vat,b.msthue";
                if (chkTT.Checked)
                {
                    asql += " union all";
                    if (!chkTTRV.Checked) asql = "";
                    //gốc asql += " select a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, a1.hoten, a1.namsinh, a1.diachi as diachi,null as tentt,  a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, sum(nvl(a4.soluong,0)*nvl(a4.dongia,0)) as sotien,0 as tamungngay, to_number('0') as tamung, sum(case when a4.madoituong=3 then a4.soluong*a4.dongia else 0 end) as mien,sum(case when a4.madoituong=5 then a4.soluong*a4.dongia else 0 end) as haophi, sum(to_number((case when a4.madoituong =1 then nvl(a4.mien,0) else 0 end))) as bhyt, to_number('0') as nopthem, a4.thieu, to_number('0') as thua, to_number('0') as chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai,0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                    //thanh thúy 05/05/2011 sửa miẽn
                    asql += " select a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, a1.hoten, a1.namsinh, a1.diachi as diachi,null as tentt,  a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, sum(nvl(a4.soluong,0)*nvl(a4.dongia,0)) as sotien,"+
                        "0 as tamungngay, to_number('0') as tamung, sum(nvl(a4.mien,0)) as mien,sum(case when a4.madoituong=5 then a4.soluong*a4.dongia else 0 end) as haophi, sum(to_number((case when a4.madoituong =1 then nvl(a4.mien,0) else 0 end))) as bhyt, to_number('0') as nopthem, a4.thieu, to_number('0') as thua, to_number('0') as chenhlech, d.hoten as user_hoten, "+
                        "d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai,0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra,a4.vat,bn.msthue ";
                    asql += " from medibvmmyy.v_vienphill a1 left join medibvmmyy.v_vienphict a4 on a1.id = a4.id  left join medibvmmyy.v_mienngtru c on a1.id=c.id left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma left join medibv.btdbn bn on a1.mabn=bn.mabn " + aexp + " " + aexpt + "";
                    asql += " group by a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy'), to_char(a1.ngay,'dd/mm/yyyy'), a1.hoten, a1.namsinh, a1.diachi, a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy'), a4.mien, a4.thieu, d.hoten, d.userid,a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl, c.sotien,a4.mien,a4.vat,bn.msthue ";
                }
                //ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (chkTU.Checked)
                {
                    asql += " union all";
                    asql += " select a1.id, a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| c.tentt as diachi,"+
                        "c.tentt as tentt, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, 0 as sotien, a1.sotien as tamungngay, 0 as tamung, 0 as mien,0 as haophi, 0 as bhyt, 0 as nopthem, 0 as thieu, 0 as thua, 0 as chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso,0 as sobienlai, a1.sobienlai as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,0 as tra,0 as vat,b.msthue ";
                    asql += " from medibvmmyy.v_tamung a1 left join medibv.btdbn b on a1.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma " + aexptamungtrongngay + " " + aexpttrv + " ";
                    asql += " group by a1.id,a1.mabn,a1.mavaovien,a1.maql,a1.loai,hs.ten,a1.loaibn,to_char(a1.ngay,'dd/mm/yyyy') ,b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end , trim(b.sonha || ' '||b.thon) ,c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat , a1.sotien, d.hoten , d.userid, a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl,b.msthue";
                } 
                if (chkBHYTKB.Checked)
                {
                    asql += " union all";
                    if (!chkTT.Checked && !chkTTRV.Checked)
                    {
                        asql = "";
                    }
                    asql += " select a1.id, a1.mabn, a1.mavaovien,a1.maql,0 as loai,h.tenloai as ten_loaivp,a1.loaiba as loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, bn.hoten,case when bn.ngaysinh is null then bn.namsinh else to_char(bn.ngaysinh,'dd/mm/yyyy') end as namsinh,trim(bn.sonha || ' '||bn.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| cn.tentt as diachi,"+
                        "cn.tentt as tentt,a1.makp,d.tenkp,d.viettat,to_char(a1.ngay,'dd/mm/yyyy') as ngay,sum(c.soluong*c.giaban) as sotien,0 as tamungngay,0 as tamung,0 as mien,0 as haophi,0 as bhyt, 0 as nopthem,0 as thieu,0 as thua,0 as chenhlech,e.hoten as user_hoten,e.userid as user_username,a1.userid,a1.quyenso,a1.sobienlai,a1.sobienlai as bienlaitamung,f.sohieu,f.sohieubl,to_number(0,'9') as hoan,0 as tra,0 as vat,bn.msthue";
                    asql += " from medibvmmyy.bhytkb a1 inner join medibvmmyy.bhytthuoc c on a1.id=c.id inner join medibv.btdbn bn on a1.mabn=bn.mabn left join medibv.btdtt cn on bn.matt=cn.matt left join medibv.btdquan c1 on bn.maqu=c1.maqu left join medibv.btdpxa c2 on bn.maphuongxa=c2.maphuongxa";
                    asql += " left join medibv.btdkp_bv d on a1.makp=d.makp left join medibv.v_dlogin e on a1.userid=e.id left join medibv.v_quyenso f on a1.quyenso=f.id and f.hide=0 ";
                    asql += " inner join (select a.id, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                    asql += " union all ";
                    asql += " select a.id, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mabd=h.id";
                    asql += " " + aexp + "";
                    asql += " group by a1.mabn, a1.mavaovien,a1.maql,h.tenloai,a1.loaiba, to_char(a1.ngay,'dd/mm/yyyy'), to_char(a1.ngay,'dd/mm/yyyy'), bn.hoten,bn.ngaysinh,bn.namsinh,bn.sonha,bn.thon,c2.tenpxa,c1.tenquan,cn.tentt,cn.tentt,a1.makp,d.tenkp,d.viettat,e.userid,to_char(a1.ngay,'dd/mm/yyyy') ,c.soluong,c.giaban,a1.id,e.hoten,a1.userid,a1.quyenso,bn.msthue,a1.sobienlai,f.sohieu,f.sohieubl";

                    asql += " union all";

                    asql += " select a1.id, a1.mabn, a1.mavaovien,a1.maql,0 as loai,h.tenloai as ten_loaivp,a1.loaiba as loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, bn.hoten,case when bn.ngaysinh is null then bn.namsinh else to_char(bn.ngaysinh,'dd/mm/yyyy') end as namsinh,trim(bn.sonha || ' '||bn.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| cn.tentt as diachi," +
                        "cn.tentt as tentt,a1.makp,d.tenkp,d.viettat,to_char(a1.ngay,'dd/mm/yyyy') as ngay,sum(c.soluong*c.dongia) as sotien,0 as tamungngay,0 as tamung,0 as mien,0 as haophi,0 as bhyt, 0 as nopthem,0 as thieu,0 as thua,0 as chenhlech,e.hoten as user_hoten,e.userid as user_username,a1.userid,a1.quyenso,a1.sobienlai,a1.sobienlai as bienlaitamung,f.sohieu,f.sohieubl,to_number(0,'9') as hoan,0 as tra,0 as vat,bn.msthue";
                    asql += " from medibvmmyy.bhytkb a1 inner join medibvmmyy.bhytcls c on a1.id=c.id inner join medibv.btdbn bn on a1.mabn=bn.mabn left join medibv.btdtt cn on bn.matt=cn.matt left join medibv.btdquan c1 on bn.maqu=c1.maqu left join medibv.btdpxa c2 on bn.maphuongxa=c2.maphuongxa";
                    asql += " left join medibv.btdkp_bv d on a1.makp=d.makp left join medibv.v_dlogin e on a1.userid=e.id left join medibv.v_quyenso f on a1.quyenso=f.id and f.hide=0 ";
                    asql += " inner join (select a.id, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                    asql += " union all ";
                    asql += " select a.id, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                    asql += " " + aexp + "";
                    asql += " group by a1.mabn, a1.mavaovien,a1.maql,h.tenloai,a1.loaiba, to_char(a1.ngay,'dd/mm/yyyy'), to_char(a1.ngay,'dd/mm/yyyy'), bn.hoten,bn.ngaysinh,bn.namsinh,bn.sonha,bn.thon,c2.tenpxa,c1.tenquan,cn.tentt,cn.tentt,a1.makp,d.tenkp,d.viettat,e.userid,to_char(a1.ngay,'dd/mm/yyyy') ,c.soluong,c.dongia,a1.id,e.hoten,a1.userid,a1.quyenso,bn.msthue,a1.sobienlai,f.sohieu,f.sohieubl";
                }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                //adsTU = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                //ads.Tables[0].Merge(adsTU.Tables[0]);
                                
                //hoantra:start
                asql = "select a1.id,a1.quyenso,a1.sobienlai,to_char(a1.ngay,'dd/mm/yyyy') as ngay, to_char(a1.ngayud,'dd/mm/yyyy') as ngayud,a1.mabn,a1.mavaovien,a1.maql,a1.loai,a1.loaibn,a1.userid from medibvmmyy.v_hoantra a1 where a1.sotien >0 and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                if (auserid != "")
                {
                    asql += " and a1.userid in (" + auserid + ")";
                }
                //if (aquyenso != "")
                //{
                //    asql += " and a1.quyenso in (" + aquyenso + ")";
                //}
                if (txtTS.Text != "")
                {
                    asql += " and a1.sobienlai >=" + txtTS.Text + "";
                }
                if (txtDS.Text != "")
                {
                    asql += " and a1.sobienlai <=" + txtDS.Text + "";
                }
                
                adsh = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (ads != null && adsh!=null)
                {
                    //bohoan:start
                    if (rdBC_02.Checked || chkKhonginhoantra.Checked)
                    {
                        foreach (DataRow r in adsh.Tables[0].Rows)
                        {
                            try
                            {
                                while(ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "' and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + " and loaibn=" + r["loaibn"].ToString()).Length>0)
                                {
                                    DataRow r1 = ads.Tables[0].Select("quyenso=" + r["quyenso"].ToString() + " and sobienlai=" + r["sobienlai"].ToString() + " and mabn='" + r["mabn"].ToString() + "' and mavaovien=" + r["mavaovien"].ToString() + " and maql=" + r["maql"].ToString() + " and loai=" + r["loai"].ToString() + " and loaibn=" + r["loaibn"].ToString())[0];
                                    ads.Tables[0].Rows.Remove(r1);
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    //bohoan:end

                    //conghoan:start
                    if (rdBC_03.Checked || (!chkKhonginhoantra.Checked && !rdBC_02.Checked))
                    {
                        foreach (DataRow r in adsh.Tables[0].Rows)
                        {
                            try
                            {
                                ammyy = m_v.get_mmyy(r["ngayud"].ToString());
                                
                                asql = "select a.id, a.mabn, a.mavaovien, a.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) ||' '|| c2.tenpxa ||' '|| c1.tenquan ||' '|| c.tentt as diachi,c.tentt, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, sum(nvl(a4.soluong,0)*nvl(a4.dongia,0)) as sotien, to_number('0') as tamungngay, a1.tamung, a1.mien, to_number('0') as haophi, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai, 0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                                asql += " from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma ";
                                asql += "where " + "a1.quyenso=" + r["quyenso"].ToString() + " and a1.sobienlai=" + r["sobienlai"].ToString() + " and a.mabn='" + r["mabn"].ToString() + "' and a.mavaovien=" + r["mavaovien"].ToString() + " and a.maql=" + r["maql"].ToString() + " and a1.loai=" + r["loai"].ToString() + " and a1.loaibn=" + r["loaibn"].ToString();
                                asql += " group by a.id,a.mabn,a.mavaovien,a.maql,a1.loai,hs.ten,a1.loaibn,to_char(a.ngayvao,'dd/mm/yyyy') ,to_char(a.ngayra,'dd/mm/yyyy'),b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end , trim(b.sonha || ' '||b.thon) ,c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') , a1.sotien, a1.tamung, a1.mien, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten , d.userid, a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl";
                                if (chkTT.Checked)
                                {
                                    asql += " union all";
                                    if (!chkTTRV.Checked) asql = "";
                                    
                                    asql += " select a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy') as ngayvao, to_char(a1.ngay,'dd/mm/yyyy') as ngayra, a1.hoten, a1.namsinh, a1.diachi as diachi,null as tentt, a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay, sum(nvl(a4.soluong,0)*nvl(a4.dongia,0)) as sotien, to_number('0') as tamungngay, to_number('0') as tamung, case when c.sotien is null then 0 else c.sotien end as mien, to_number('0') as haophi, sum(to_number((case when a4.madoituong =1 then nvl(a4.mien,0) else 0 end))) as bhyt, to_number('0') as nopthem, a4.thieu, to_number('0') as thua, to_number('0') as chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai, 0 as bienlaitamung, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                                    asql += " from medibvmmyy.v_vienphill a1 left join medibvmmyy.v_vienphict a4 on a1.id = a4.id  left join medibvmmyy.v_mienngtru c on a1.id=c.id left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 inner join medibv.v_tenloaivp hs on a1.loai=hs.ma ";
                                    asql += "where " + "a1.quyenso=" + r["quyenso"].ToString() + " and a1.sobienlai=" + r["sobienlai"].ToString() + " and a1.mabn='" + r["mabn"].ToString() + "' and a1.mavaovien=" + r["mavaovien"].ToString() + " and a1.maql=" + r["maql"].ToString() + " and a1.loai=" + r["loai"].ToString() + " and a1.loaibn=" + r["loaibn"].ToString();
                                    asql += " group by a1.id , a1.mabn, a1.mavaovien, a1.maql, a1.loai, hs.ten, a1.loaibn, to_char(a1.ngay,'dd/mm/yyyy'), to_char(a1.ngay,'dd/mm/yyyy'), a1.hoten, a1.namsinh, a1.diachi, a1.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy'), a4.mien, a4.thieu, d.hoten, d.userid,a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl, c.sotien";
                                }

                                adst = m_v.get_data_mmyy(ammyy, asql);

                                foreach (DataRow r1 in adst.Tables[0].Rows)
                                {
                                    if (ads.Tables[0].Select("quyenso=" + r1["quyenso"].ToString() + " and sobienlai=" + r1["sobienlai"].ToString() + " and mabn='" + r1["mabn"].ToString() + "' and mavaovien=" + r1["mavaovien"].ToString() + " and maql=" + r1["maql"].ToString() + " and loai=" + r1["loai"].ToString() + " and loaibn=" + r1["loaibn"].ToString() + " and userid=" + r1["userid"].ToString()).Length <= 0)
                                    {
                                        ads.Tables[0].Rows.Add(r1.ItemArray);
                                    }

                                    foreach (DataRow r2 in ads.Tables[0].Select("quyenso=" + r1["quyenso"].ToString() + " and sobienlai=" + r1["sobienlai"].ToString() + " and mabn='" + r1["mabn"].ToString() + "' and mavaovien=" + r1["mavaovien"].ToString() + " and maql=" + r1["maql"].ToString() + " and loai=" + r1["loai"].ToString() + " and loaibn=" + r1["loaibn"].ToString()))
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
                    //conghoan:end
                }
                //hoantra:end
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads;
        }

        private void f_Get_Data_Loaivp_khoaphong()
        {
            DataSet ads = null, ads1 = null;
            System.Data.DataTable dtkp = new System.Data.DataTable();
            DataColumn dc;
            DataRow r2, r3;
            DataRow[] dr;
            try
            {
                string asql = "", aexp = "", aexp_tu = "", aexpbh = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);

                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }

                ads1 = new DataSet();
                ads1.Tables.Add("Table");
                ads1.Tables[0].Columns.Add(new DataColumn("stt", typeof(decimal)));
                ads1.Tables[0].Columns.Add(new DataColumn("id_loai", typeof(decimal)));
                ads1.Tables[0].Columns.Add(new DataColumn("id_nhom", typeof(decimal)));
                ads1.Tables[0].Columns.Add(new DataColumn("sttnhom", typeof(decimal)));
                ads1.Tables[0].Columns.Add(new DataColumn("tenloaivp", typeof(string)));
                asql = "select * from medibv.btdkp_bv ";
                if (amakp != "") asql += "where  makp in (" + amakp + ")";
                asql += " order by loai desc, tenkp asc, makp asc";
                dtkp = m_v.get_data(asql).Tables[0];
                foreach (DataRow r in dtkp.Rows)
                {
                    dc = new DataColumn();
                    dc.ColumnName = "KP_" + r["makp"].ToString();
                    dc.DataType = Type.GetType("System.String");
                    ads1.Tables[0].Columns.Add(dc);
                }
                #region
                ads1.Tables[0].Columns.Add(new DataColumn("BHYTTRA", typeof(decimal)));
                #endregion
                ads1.Tables[0].Columns.Add(new DataColumn("tong", typeof(decimal)));
               
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(b.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                aexpbh = aexp;
                if (auserid != "")
                {
                    aexp += " and b.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and b.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and b.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and b.loaibn in (" + aloaibn + ")";
                }
                aexp_tu = aexp;
                if (adoituong != "")
                {
                    aexp += " and c.madoituong in (" + adoituong + ")";
                    aexp_tu += " and b.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and c.makp in (" + amakp + ")";
                    aexp_tu += " and b.makp in (" + amakp + ")";
                }
                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    if (decimal.Parse(txtTS.Text.Trim()) > decimal.Parse(txtDS.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTS.Focus();
                        return;
                    }
                    else
                    {
                        aexp += " and b.sobienlai>=" + txtTS.Text.Trim() + " and b.sobienlai<=" + txtDS.Text.Trim();
                        aexp_tu += " and b.sobienlai>=" + txtTS.Text.Trim() + " and b.sobienlai<=" + txtDS.Text.Trim();
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and b.sobienlai<0";
                        aexp_tu += " and b.sobienlai<0";
                    }
                    else
                    if(chkInchungmien.Checked)
                    {
                        aexp += " and b.sobienlai>0";
                        aexp_tu += " and b.sobienlai>0";
                    }
                }
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp += " and b.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp += " and b.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp += " and b.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();
                aexp_tu = "where " + aexp_tu.Trim();
                aexpbh = "where " + aexpbh.Trim();

                asql = "select h.id_nhom, h.sttnhom, h.id_loai as id, nvl(h.tenloai,h.tennhom) as ten, c.makp,sum(c.soluong*c.dongia-c.bhyttra) as sotien,sum(c.bhyttra) as bhyttra";
                asql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on b.id=c.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id";
                asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                //
                asql += " inner join (select a.id, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                asql += " union all ";
                asql += " select a.id, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                //
                asql += " " + aexp + "";
                if (chkThatthu.Checked)
                {
                    asql += " and b.thieu > 0 ";
                }
                asql += " group by h.id_nhom, h.sttnhom, h.id_loai, nvl(h.tenloai,h.tennhom), c.makp";
                if (chkTT.Checked)
                {
                    asql += " union all";
                    if (!chkTTRV.Checked) asql = "";
                    asql += " select h.id_nhom, h.sttnhom, h.id_loai as id, nvl(h.tenloai,h.tennhom) as ten, c.makp, sum(c.soluong*c.dongia) as sotien,0 as bhyttra";
                    asql += " from medibvmmyy.v_vienphill b inner join medibvmmyy.v_vienphict c on b.id=c.id ";
                    asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                    asql += " inner join (select a.id, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                    asql += " union all ";
                    asql += " select a.id, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                    asql += " " + aexp + "";
                    asql += " group by h.id_nhom, h.sttnhom, h.id_loai, nvl(h.tenloai,h.tennhom), c.makp";
                }
                if (chkTU.Checked)
                {
                    asql += " union all";
                    asql += " select '999' as id_nhom, '999' as sttnhom, '999' as id, null ten, b.makp, sum(nvl(b.sotien,0)) as sotien,0 as bhyttra";
                    asql += " from medibvmmyy.v_tamung b left join medibvmmyy.v_hoantra c on b.quyenso=c.quyenso and b.sobienlai=c.sobienlai";
                    asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                    asql += " " + aexp_tu + "";
                    asql += " group by b.makp";
                }

                if (chkBHYTKB.Checked)
                {
                    asql += " union all";
                    if (!chkTT.Checked && !chkTTRV.Checked)
                    {
                        asql = "";
                    }
                    asql += " select h.id_nhom, h.sttnhom, h.id_loai as id, nvl(h.tenloai,h.tennhom) as ten, b.makp, sum(c.soluong*c.giaban) as sotien,0 as bhyttra";
                    asql += " from medibvmmyy.bhytkb b inner join medibvmmyy.bhytthuoc c on b.id=c.id ";
                    asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                    asql += " inner join (select a.id, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                    asql += " union all ";
                    asql += " select a.id, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mabd=h.id";
                    asql += " " + aexpbh + "";
                    asql += " group by h.id_nhom, h.sttnhom, h.id_loai, nvl(h.tenloai,h.tennhom), b.makp";

                    asql += " union all";

                    asql += " select h.id_nhom, h.sttnhom, h.id_loai as id, nvl(h.tenloai,h.tennhom) as ten, b.makp, sum(c.soluong*c.dongia) as sotien,0 as bhyttra";
                    asql += " from medibvmmyy.bhytkb b inner join medibvmmyy.bhytcls c on b.id=c.id ";
                    asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                    asql += " inner join (select a.id, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                    asql += " union all ";
                    asql += " select a.id, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                    asql += " " + aexpbh + "";
                    asql += " group by h.id_nhom, h.sttnhom, h.id_loai, nvl(h.tenloai,h.tennhom), b.makp";
                }

                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                decimal astt = 1;
                foreach (DataRow r1 in ads.Tables[0].Rows)
                {
                    r2 = m_v.getrowbyid(ads1.Tables[0], "id_loai=" + r1["id"].ToString() + " and id_nhom=" + r1["id_nhom"].ToString() + "");
                    if (r2 == null)
                    {
                        r3 = ads1.Tables[0].NewRow();
                        r3["stt"] = astt;

                        r3["id_loai"] = r1["id"].ToString();
                        r3["id_nhom"] = r1["id_nhom"].ToString();
                        r3["sttnhom"] = r1["sttnhom"].ToString();
                        if (r1["id"].ToString() == "999") r3["tenloaivp"] = "Thu tạm ứng";
                        else r3["tenloaivp"] = r1["ten"].ToString();
                        foreach (DataRow rr in dtkp.Rows)
                        {
                            r3["KP_" + rr["makp"].ToString()] = 0;
                        }
                        r3["KP_" + r1["makp"].ToString()] = decimal.Parse(r1["sotien"].ToString());
                        r3["BHYTTRA"] = r1["BHYTTRA"].ToString();
                        astt += 1;
                        ads1.Tables[0].Rows.Add(r3);
                    }
                    else
                    {
                        dr = ads1.Tables[0].Select("id_loai=" + r1["id"].ToString() + " and id_nhom=" + r1["id_nhom"].ToString());
                        if (dr.Length > 0)
                        {
                            dr[0]["KP_" + r1["makp"].ToString()] = decimal.Parse(dr[0]["KP_" + r1["makp"].ToString()].ToString()) + decimal.Parse(r1["sotien"].ToString());
                            dr[0]["BHYTTRA"] = decimal.Parse(dr[0]["BHYTTRA"].ToString()) + decimal.Parse(r1["bhyttra"].ToString());
                        }
                    }
                }

                /////truhoantra:start

                asql = "select a1.id,a1.quyenso,a1.sobienlai,to_char(a1.ngay,'dd/mm/yyyy') as ngay, to_char(a1.ngayud,'dd/mm/yyyy') as ngayud,a1.mabn,a1.mavaovien,a1.maql,a1.loai,a1.loaibn,a1.userid from medibvmmyy.v_hoantra a1 where a1.sotien >0 and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                if (auserid != "")
                {
                    asql += " and a1.userid in (" + auserid + ")";
                }
                //if (aquyenso != "")
                //{
                //    asql += " and a1.quyenso in (" + aquyenso + ")";
                //}
                if (txtTS.Text != "")
                {
                    asql += " and a1.sobienlai >=" + txtTS.Text + "";
                }
                if (txtDS.Text != "")
                {
                    asql += " and a1.sobienlai <=" + txtDS.Text + "";
                }

                if (chkKhonginhoantra.Checked && (chkTT.Checked || chkTTRV.Checked))
                {
                    string ammyytt = "";
                    DataSet adsh = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    DataSet adstt = null;

                    foreach (DataRow r in adsh.Tables[0].Rows)
                    {
                        try
                        {
                            ammyytt = m_v.get_mmyy(r["ngayud"].ToString());

                            asql = "select h.id_nhom, h.sttnhom, h.id_loai as id, nvl(h.tenloai,h.tennhom) as ten, c.makp,sum(c.tra-c.bhyttra) as sotien";
                            asql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on b.id=c.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id";
                            asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                            //
                            asql += " inner join (select a.id, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                            asql += " union all ";
                            asql += " select a.id, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                            asql += " " + aexp + "";
                            asql += " and " + "b.quyenso=" + r["quyenso"].ToString() + " and b.sobienlai=" + r["sobienlai"].ToString() + " and a.mabn='" + r["mabn"].ToString() + "' and a.mavaovien=" + r["mavaovien"].ToString() + " and a.maql=" + r["maql"].ToString() + " and b.loai=" + r["loai"].ToString() + " and b.loaibn=" + r["loaibn"].ToString();
                            if (chkThatthu.Checked)
                                asql += " and b.thieu > 0 ";
                            //else 
                            //    asql += " and b.thieu <= 0 ";
                            asql += " group by h.id_nhom, h.sttnhom, h.id_loai, nvl(h.tenloai,h.tennhom), c.makp,c.madoituong";
                            if (chkTT.Checked)
                            {
                                asql += " union all";
                                if (!chkTTRV.Checked)
                                    asql = "";
                                asql += " select h.id_nhom, h.sttnhom, h.id_loai as id, nvl(h.tenloai,h.tennhom) as ten, c.makp, sum(c.tra) as sotien";
                                asql += " from medibvmmyy.v_vienphill b inner join medibvmmyy.v_vienphict c on b.id=c.id ";
                                asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                                asql += " inner join (select a.id, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                                asql += " union all ";
                                asql += " select a.id, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                                asql += " " + aexp + "";
                                asql += " and " + "b.quyenso=" + r["quyenso"].ToString() + " and b.sobienlai=" + r["sobienlai"].ToString() + " and b.mabn='" + r["mabn"].ToString() + "' and b.mavaovien=" + r["mavaovien"].ToString() + " and b.maql=" + r["maql"].ToString() + " and b.loai=" + r["loai"].ToString() + " and b.loaibn=" + r["loaibn"].ToString();
                                asql += " group by h.id_nhom, h.sttnhom, h.id_loai, nvl(h.tenloai,h.tennhom), c.makp";
                            }
                            if (chkTU.Checked)
                            {
                                asql += " union all";
                                asql += " select '999' as id_nhom, '999' as sttnhom, '999' as id, null ten, b.makp, sum(nvl(b.sotien,0)) as sotien";
                                asql += " from medibvmmyy.v_tamung b left join medibvmmyy.v_hoantra c on b.quyenso=c.quyenso and b.sobienlai=c.sobienlai";
                                asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                                asql += " " + aexp_tu + "";
                                asql += " and " + "b.quyenso=" + r["quyenso"].ToString() + " and b.sobienlai=" + r["sobienlai"].ToString() + " and b.mabn='" + r["mabn"].ToString() + "' and b.mavaovien=" + r["mavaovien"].ToString() + " and b.maql=" + r["maql"].ToString() + " and b.loai=" + r["loai"].ToString() + " and b.loaibn=" + r["loaibn"].ToString();
                                if (chkKhonginhoantra.Checked) asql += " and c.id is null";
                                asql += " group by b.makp";
                            }
                            adstt = m_v.get_data_mmyy(ammyytt, asql);
                            foreach (DataRow r1 in adstt.Tables[0].Rows)
                            {
                                r2 = m_v.getrowbyid(ads1.Tables[0], "id_loai=" + r1["id"].ToString() + " and id_nhom=" + r1["id_nhom"].ToString() + "");
                                if (r2 == null)
                                {
                                    r3 = ads1.Tables[0].NewRow();
                                    r3["stt"] = astt;

                                    r3["id_loai"] = r1["id"].ToString();
                                    r3["id_nhom"] = r1["id_nhom"].ToString();
                                    r3["sttnhom"] = r1["sttnhom"].ToString();
                                    if (r1["id"].ToString() == "999") r3["tenloaivp"] = "Thu tạm ứng";
                                    else r3["tenloaivp"] = r1["ten"].ToString();
                                    foreach (DataRow rr in dtkp.Rows)
                                    {
                                        r3["KP_" + rr["makp"].ToString()] = 0;
                                    }
                                    r3["KP_" + r1["makp"].ToString()] = (-1) * decimal.Parse(r1["sotien"].ToString());
                                    astt += 1;
                                    ads1.Tables[0].Rows.Add(r3);
                                }
                                else
                                {
                                    dr = ads1.Tables[0].Select("id_loai=" + r1["id"].ToString() + " and id_nhom=" + r1["id_nhom"].ToString());
                                    if (dr.Length > 0)
                                    {
                                        dr[0]["KP_" + r1["makp"].ToString()] = decimal.Parse(dr[0]["KP_" + r1["makp"].ToString()].ToString()) - decimal.Parse(r1["sotien"].ToString());
                                    }
                                }
                            }
                        }
                        catch {}
                    }
                }
                /////truhoantra:end

                if (ads1.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
                    return;
                }
               // ads.WriteXml("E:\\tt.xml",XmlWriteMode.WriteSchema);
                ads.Dispose();
                ads = new DataSet();
                ads.Merge(ads1.Tables[0].Select("true", "sttnhom"));
                ads.Tables[0].Columns.Remove("id_loai");
                ads.Tables[0].Columns.Remove("id_nhom");
                ads.Tables[0].Columns.Remove("sttnhom");
                astt = 1;
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    r["stt"] = astt;
                    astt++;
                }
                
                //remove blank
                try
                {
                    for (int i = 0; i < ads.Tables[0].Columns.Count; i++)
                    {
                        if (ads.Tables[0].Columns[i].ColumnName.IndexOf("KP_") == 0)
                        {
                            if (!(ads.Tables[0].Select(ads.Tables[0].Columns[i].ColumnName + " <> '0'").Length > 0))
                            {
                                while (dtkp.Select("makp='" + ads.Tables[0].Columns[i].ColumnName.Replace("KP_", "") + "'").Length > 0)
                                {
                                    dtkp.Rows.Remove(dtkp.Select("makp='" + ads.Tables[0].Columns[i].ColumnName.Replace("KP_", "") + "'")[0]);
                                }
                                ads.Tables[0].Columns.RemoveAt(i);
                                i = i - 1;
                            }
                        }
                    }
                }
                catch {}
                try
                {
                    while (ads.Tables[0].Select("tong=0").Length > 0)
                    {
                        DataRow r1 = ads.Tables[0].Select("tong=0")[0];
                        ads.Tables[0].Rows.Remove(r1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

               // ads.WriteXml("E:\\tt2.xml", XmlWriteMode.WriteSchema);
                 exp_excel_loaikp(false, ads, dtkp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Get_Data_Loaivp_khoaphong_soca()
        {
            DataSet ads = null;
            System.Data.DataTable dtkp = new System.Data.DataTable();
            DataRow r2, r3;
            DataRow[] dr;
            try
            {
                string asql = "", aexp = "", aexp_tu = "", aexpbh="", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";

                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);

                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }

                asql = "select * from medibv.btdkp_bv ";
                if (amakp != "") asql += "where  makp in (" + amakp + ")";
                asql += " order by loai desc, tenkp asc, makp asc";
                dtkp = m_v.get_data(asql).Tables[0];

                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(b.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                aexpbh = aexp;

                if (auserid != "")
                {
                    aexp += " and b.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and b.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and b.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and b.loaibn in (" + aloaibn + ")";
                }
                aexp_tu = aexp;
                if (adoituong != "")
                {
                    aexp += " and c.madoituong in (" + adoituong + ")";
                    aexp_tu += " and b.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and c.makp in (" + amakp + ")";
                    aexp_tu += " and b.makp in (" + amakp + ")";
                }
                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    if (decimal.Parse(txtTS.Text.Trim()) > decimal.Parse(txtDS.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTS.Focus();
                        return;
                    }
                    else
                    {
                        aexp += " and b.sobienlai>=" + txtTS.Text.Trim() + " and b.sobienlai<=" + txtDS.Text.Trim();
                        aexp_tu += " and b.sobienlai>=" + txtTS.Text.Trim() + " and b.sobienlai<=" + txtDS.Text.Trim();
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and b.sobienlai<0";
                        aexp_tu += " and b.sobienlai<0";
                    }
                    else
                        if (chkInchungmien.Checked)
                        {
                            aexp += " and b.sobienlai>0";
                            aexp_tu += " and b.sobienlai>0";
                        }
                }
                string aexp1 = "";
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp1 += " and b.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp1 += " and b.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp1 += " and b.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();
                aexp_tu = "where " + aexp_tu.Trim();
                aexpbh = "where " + aexpbh.Trim();
                asql = "select h.id,h.ten, h.id_nhom, h.sttnhom, h.tennhom as tennhom, h.id_loai as id_loai, nvl(h.tenloai,h.tennhom) as tenloai, c.makp, d.tenkp as tenkp, sum(c.soluong) as soca,sum(c.soluong*c.dongia-c.bhyttra) as sotien";
                asql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on b.id=c.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id";
                asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                //
                asql += " inner join (select a.id, a.ten, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                asql += " union all ";
                asql += " select a.id,a.ten, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                //
                asql += " " + aexp + aexp1 + "";
                if (chkThatthu.Checked)
                {
                    asql += " and b.thieu > 0 ";
                }
                asql += " group by h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom, h.id_loai, nvl(h.tenloai,h.tennhom), c.makp, d.tenkp";
                if (chkTT.Checked)
                {
                    asql += " union all";
                    if (!chkTTRV.Checked) asql = "";
                    asql += " select h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom as tennhom, h.id_loai as id_loai, nvl(h.tenloai,h.tennhom) as tenloai, c.makp, d.tenkp as tenkp, sum(c.soluong) as soca, sum(c.soluong*c.dongia) as sotien";
                    asql += " from medibvmmyy.v_vienphill b inner join medibvmmyy.v_vienphict c on b.id=c.id ";
                    asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                    asql += " inner join (select a.id, a.ten,a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                    asql += " union all ";
                    asql += " select a.id, a.ten, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                    asql += " " + aexp + "";
                    asql += " group by h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom, h.id_loai, nvl(h.tenloai,h.tennhom), c.makp, d.tenkp";
                }
                if (chkBHYTKB.Checked)
                {
                    asql += " union all";
                    if (!chkTT.Checked && !chkTTRV.Checked)
                    {
                        asql = "";
                    }
                    asql += " select h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom as tennhom, h.id_loai as id_loai, nvl(h.tenloai,h.tennhom) as tenloai, b.makp, d.tenkp as tenkp, sum(c.soluong) as soca, sum(c.soluong*c.giaban) as sotien";
                    asql += " from medibvmmyy.bhytkb b inner join medibvmmyy.bhytthuoc c on b.id=c.id ";
                    asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                    asql += " inner join (select a.id, a.ten,a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                    asql += " union all ";
                    asql += " select a.id, a.ten, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mabd=h.id";
                    asql += " " + aexpbh + "";
                    asql += " group by h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom, h.id_loai, nvl(h.tenloai,h.tennhom), b.makp, d.tenkp";

                    asql += " union all";

                    asql += " select h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom as tennhom, h.id_loai as id_loai, nvl(h.tenloai,h.tennhom) as tenloai, b.makp, d.tenkp as tenkp, sum(c.soluong) as soca, sum(c.soluong*c.dongia) as sotien";
                    asql += " from medibvmmyy.bhytkb b inner join medibvmmyy.bhytcls c on b.id=c.id ";
                    asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                    asql += " inner join (select a.id, a.ten,a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                    asql += " union all ";
                    asql += " select a.id, a.ten, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                    asql += " " + aexpbh + "";
                    asql += " group by h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom, h.id_loai, nvl(h.tenloai,h.tennhom), b.makp, d.tenkp";
                }

                if (chkTU.Checked)
                {
                    //asql += " union all";
                    //asql += " select '999' as id_nhom, '999' as sttnhom, '999' as id, null ten, b.makp, sum(nvl(b.sotien,0)) as sotien";
                    //asql += " from medibvmmyy.v_tamung b left join medibvmmyy.v_hoantra c on b.quyenso=c.quyenso and b.sobienlai=c.sobienlai";
                    //asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id ";
                    //asql += " " + aexp_tu + "";
                    //asql += " group by b.makp";
                }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);

                /////truhoantra:start

                asql = "select a1.id,a1.quyenso,a1.sobienlai,to_char(a1.ngay,'dd/mm/yyyy') as ngay, to_char(a1.ngayud,'dd/mm/yyyy') as ngayud,a1.mabn,a1.mavaovien,a1.maql,a1.loai,a1.loaibn,a1.userid from medibvmmyy.v_hoantra a1 where a1.sotien >0 and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                if (auserid != "")
                {
                    asql += " and a1.userid in (" + auserid + ")";
                }
                //if (aquyenso != "")
                //{
                //    asql += " and a1.quyenso in (" + aquyenso + ")";
                //}
                if (txtTS.Text != "")
                {
                    asql += " and a1.sobienlai >=" + txtTS.Text + "";
                }
                if (txtDS.Text != "")
                {
                    asql += " and a1.sobienlai <=" + txtDS.Text + "";
                }

                if (chkKhonginhoantra.Checked && (chkTT.Checked || chkTTRV.Checked))
                {
                    string ammyytt = "";
                    DataSet adsh = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    DataSet adstt = null;

                    foreach (DataRow r in adsh.Tables[0].Rows)
                    {
                        try
                        {
                            ammyytt = m_v.get_mmyy(r["ngayud"].ToString());

                            asql = "select h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom as tennhom, h.id_loai as id_loai, nvl(h.tenloai,h.tennhom) as tenloai, c.makp, d.tenkp as tenkp,sum(c.soluong) as soca,sum(c.soluong*c.dongia-c.bhyttra) as sotien";
                            asql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on b.id=c.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id";
                            asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                            //
                            asql += " inner join (select a.id, a.ten, a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                            asql += " union all ";
                            asql += " select a.id, a.ten, 0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                            //
                            asql += " " + aexp + aexp1+ "";
                            asql += " and " + "b.quyenso=" + r["quyenso"].ToString() + " and b.sobienlai=" + r["sobienlai"].ToString() + " and a.mabn='" + r["mabn"].ToString() + "' and a.mavaovien=" + r["mavaovien"].ToString() + " and a.maql=" + r["maql"].ToString() + " and b.loai=" + r["loai"].ToString() + " and b.loaibn=" + r["loaibn"].ToString();
                            if (chkThatthu.Checked)
                            {
                                asql += " and b.thieu > 0 ";
                            }
                            asql += " group by h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom, h.id_loai, nvl(h.tenloai,h.tennhom), c.makp, d.tenkp";
                            if (chkTT.Checked)
                            {
                                asql += " union all";
                                if (!chkTTRV.Checked) asql = "";
                                asql += " select h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom as tennhom, h.id_loai as id_loai, nvl(h.tenloai,h.tennhom) as tenloai, c.makp, d.tenkp as tenkp,sum(c.soluong) as soca, sum(c.soluong*c.dongia) as sotien";
                                asql += " from medibvmmyy.v_vienphill b inner join medibvmmyy.v_vienphict c on b.id=c.id ";
                                asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
                                asql += " inner join (select a.id, a.ten,a.id_loai, c.ma as id_nhom, c.stt as sttnhom, b.ten as tenloai, c.ten as tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma";
                                asql += " union all ";
                                asql += " select a.id, a.ten,0 as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as h on c.mavp=h.id";
                                asql += " " + aexp + "";
                                asql += " and " + "b.quyenso=" + r["quyenso"].ToString() + " and b.sobienlai=" + r["sobienlai"].ToString() + " and b.mabn='" + r["mabn"].ToString() + "' and b.mavaovien=" + r["mavaovien"].ToString() + " and b.maql=" + r["maql"].ToString() + " and b.loai=" + r["loai"].ToString() + " and b.loaibn=" + r["loaibn"].ToString();
                                asql += " group by h.id,h.ten,h.id_nhom, h.sttnhom, h.tennhom, h.id_loai, nvl(h.tenloai,h.tennhom), c.makp, d.tenkp";
                            }

                            if (chkTU.Checked)
                            {
                                //asql += " union all";
                                //asql += " select '999' as id_nhom, '999' as sttnhom, '999' as id, null ten, b.makp, sum(nvl(b.sotien,0)) as sotien";
                                //asql += " from medibvmmyy.v_tamung b left join medibvmmyy.v_hoantra c on b.quyenso=c.quyenso and b.sobienlai=c.sobienlai";
                                //asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id ";
                                //asql += " " + aexp_tu + "";
                                //asql += " and " + "b.quyenso=" + r["quyenso"].ToString() + " and b.sobienlai=" + r["sobienlai"].ToString() + " and b.mabn='" + r["mabn"].ToString() + "' and b.mavaovien=" + r["mavaovien"].ToString() + " and b.maql=" + r["maql"].ToString() + " and b.loai=" + r["loai"].ToString() + " and b.loaibn=" + r["loaibn"].ToString();
                                //if (chkKhonginhoantra.Checked) asql += " and c.id is null";
                                //asql += " group by b.makp";
                            }
                            adstt = m_v.get_data_mmyy(ammyytt, asql);
                            foreach (DataRow r1 in adstt.Tables[0].Rows)
                            {
                                r2 = m_v.getrowbyid(ads.Tables[0], "id_loai=" + r1["id_loai"].ToString() + " and id_nhom=" + r1["id_nhom"].ToString() + " and id=" + r1["id"].ToString() + " and makp='" + r1["makp"].ToString() + "'");
                                if (r2 == null)
                                {
                                    r3 = ads.Tables[0].NewRow();
                                    r3["id"] = r1["id"].ToString();
                                    r3["ten"] = r1["ten"].ToString();
                                    r3["id_nhom"] = r1["id_nhom"].ToString();
                                    r3["sttnhom"] = r1["sttnhom"].ToString();
                                    r3["tennhom"] = r1["tennhom"].ToString();
                                    r3["id_loai"] = r1["id_loai"].ToString();
                                    r3["tenloai"] = r1["tenloai"].ToString();
                                    r3["makp"] = r1["makp"].ToString();
                                    r3["tenkp"] = r1["tenkp"].ToString();
                                    r3["sotien"] = (-1) * decimal.Parse(r1["sotien"].ToString());
                                    r3["soca"] = (-1) * decimal.Parse(r1["soca"].ToString());
                                    ads.Tables[0].Rows.Add(r3);
                                }
                                else
                                {
                                    dr = ads.Tables[0].Select("id_loai=" + r1["id_loai"].ToString() + " and id_nhom=" + r1["id_nhom"].ToString() + " and id=" + r1["id"].ToString() + " and makp='" + r1["makp"].ToString() + "'");
                                    if (dr.Length > 0)
                                    {
                                        dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) - decimal.Parse(r1["sotien"].ToString());
                                        dr[0]["soca"] = decimal.Parse(dr[0]["soca"].ToString()) - decimal.Parse(r1["soca"].ToString());
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                /////truhoantra:end

                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
                    return;
                }
                if (chkXML.Checked)
                {
                    ads.WriteXml("frmbkthuchiravien_12.xml", XmlWriteMode.WriteSchema);
                }
                string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";

                areport = this.Name.ToLower() + "_12.rpt";
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

                //frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện khoa phòng (số ca)", 1, chkXemkhiin.Checked ? true : false);
                frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện khoa phòng (số ca)", 1, chkXemkhiin.Checked ? true : false);
                fa.KetxuatExcel = bKetxuatExcel;
                fa.ShowDialog();

                //exp_excel_loaikp(false, ads, dtkp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private decimal f_Tongmien()
        {
            decimal s_mien = 0;
            DataSet ads = new DataSet();
            try
            {
                string asql = "", aexp = "", aexp_tu = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(b.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }

                if (auserid != "")
                {
                    aexp += " and b.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and b.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and b.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and b.loaibn in (" + aloaibn + ")";
                }
                aexp_tu = aexp;
                if (adoituong != "")
                {
                    aexp += " and c.madoituong in (" + adoituong + ")";
                    aexp_tu += " and b.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and c.makp in (" + amakp + ")";
                    aexp_tu += " and b.makp in (" + amakp + ")";
                }
                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    if (decimal.Parse(txtTS.Text.Trim()) > decimal.Parse(txtDS.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTS.Focus();
                    }
                    else
                    {
                        aexp += " and b.sobienlai>=" + txtTS.Text.Trim() + " and b.sobienlai<=" + txtDS.Text.Trim();
                        aexp_tu += " and b.sobienlai>=" + txtTS.Text.Trim() + " and b.sobienlai<=" + txtDS.Text.Trim();
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and b.sobienlai<0";
                        aexp_tu += " and b.sobienlai<0";
                    }
                    else
                    if(chkInchungmien.Checked)
                    {
                        aexp += " and b.sobienlai>0";
                        aexp_tu += " and b.sobienlai>0";
                    }
                }
                aexp = "where " + aexp.Trim();
                aexp_tu = "where " + aexp_tu.Trim();
                asql = "select nvl(sum(mien),0) as mien from medibvmmyy.v_ttrvll b " + aexp;
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                DataRow[] r = ads.Tables[0].Select();
                for (int i = 0; i < r.Length; i++)
                {
                    s_mien += decimal.Parse(r[i]["mien"].ToString());
                }
            }
            catch
            { 
            }
            return s_mien;
        }
        #region 170611
        private decimal f_Tongbhyttra()
        {
            decimal s_bhyttra = 0;
            DataSet ads = new DataSet();
            try
            {
                string asql = "", aexp = "", aexp_tu = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(b.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }

                if (auserid != "")
                {
                    aexp += " and b.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and b.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and b.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and b.loaibn in (" + aloaibn + ")";
                }
                aexp_tu = aexp;
                if (adoituong != "")
                {
                    aexp += " and c.madoituong in (" + adoituong + ")";
                    aexp_tu += " and b.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and c.makp in (" + amakp + ")";
                    aexp_tu += " and b.makp in (" + amakp + ")";
                }
                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    if (decimal.Parse(txtTS.Text.Trim()) > decimal.Parse(txtDS.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTS.Focus();
                    }
                    else
                    {
                        aexp += " and b.sobienlai>=" + txtTS.Text.Trim() + " and b.sobienlai<=" + txtDS.Text.Trim();
                        aexp_tu += " and b.sobienlai>=" + txtTS.Text.Trim() + " and b.sobienlai<=" + txtDS.Text.Trim();
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and b.sobienlai<0";
                        aexp_tu += " and b.sobienlai<0";
                    }
                    else
                        if (chkInchungmien.Checked)
                        {
                            aexp += " and b.sobienlai>0";
                            aexp_tu += " and b.sobienlai>0";
                        }
                }
                aexp = "where " + aexp.Trim();
                aexp_tu = "where " + aexp_tu.Trim();
                asql = "select nvl(sum(d.bhyttra),0) as bhyttra from medibvmmyy.v_ttrvll b inner join medibvmmyy.v_ttrvct d on b.id=d.id " + aexp;
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                DataRow[] r = ads.Tables[0].Select();
                for (int i = 0; i < r.Length; i++)
                {
                    s_bhyttra += decimal.Parse(r[i]["bhyttra"].ToString());
                }
            }
            catch
            {
            }
            return s_bhyttra;
        }

        #endregion
        private void f_Get_Data_SBL()
        {
            DataSet ads = null, ads1 = null;
            System.Data.DataTable dtkp = new System.Data.DataTable();
            DataColumn dc;
            DataRow r2, r3;
            DataRow[] dr;
            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);

                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }

                ads1 = new DataSet();
                ads1.Tables.Add("Table");
                ads1.Tables[0].Columns.Add(new DataColumn("stt", typeof(decimal)));
                ads1.Tables[0].Columns.Add(new DataColumn("sohieu", typeof(string)));
                ads1.Tables[0].Columns.Add(new DataColumn("sobienlai", typeof(decimal)));
                asql = "select * from medibv.btdkp_bv ";
                if (amakp != "") asql += "where  makp in (" + amakp + ")";
                asql += " order by makp";
                dtkp = m_v.get_data(asql).Tables[0];
                foreach (DataRow r in dtkp.Rows)
                {
                    dc = new DataColumn();
                    dc.ColumnName = "KP_" + r["makp"].ToString();
                    dc.DataType = Type.GetType("System.String");
                    ads1.Tables[0].Columns.Add(dc);
                }
                ads1.Tables[0].Columns.Add(new DataColumn("tong", typeof(decimal)));

                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(b.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }

                if (auserid != "")
                {
                    aexp += " and b.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and b.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and b.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and b.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and c.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and c.makp in (" + amakp + ")";
                }
                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    if (decimal.Parse(txtTS.Text.Trim()) > decimal.Parse(txtDS.Text.Trim()))
                    {
                        MessageBox.Show(this, "Số biên lai cần báo cáo không hợp lệ", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTS.Focus();
                        return;
                    }
                    else
                    {
                        aexp += " and b.sobienlai >= " + txtTS.Text.Trim() + " and b.sobienlai <=" + txtDS.Text.Trim() + "";
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and b.sobienlai<0";
                    }
                    else
                    if(chkInchungmien.Checked)
                    {
                        aexp += " and b.sobienlai>0";
                    }
                }
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp += " and b.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp += " and b.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp += " and b.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();
                if (chkHoantra.Checked)
                    asql = " select b.sobienlai,f.sohieu,c.makp,sum(c.soluong*c.dongia-c.tra) as sotien ";
                else
                    asql = " select b.sobienlai,f.sohieu,c.makp,sum(c.soluong*c.dongia) as sotien ";

                asql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on b.id=c.id ";
                asql += " left join medibv.btdkp_bv d on b.makp=d.makp left join medibv.v_dlogin e on b.userid=e.id left join medibv.v_quyenso f on b.quyenso=f.id and f.hide=0 ";
              //  asql += " inner join (select id, id_loai,ten from medibv.v_giavp union all select id, id_loai,ten from (select a1.id as id, c1.id_loai as id_loai,a1.ten from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai,a0.ten from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) g on c.mavp=g.id ";
              //  asql += " left join (select id, id_nhom,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ten from dual) h on h.id=g.id_loai ";
                asql += " " + aexp + "";
                asql += " group by b.sobienlai,f.sohieu,c.makp";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                decimal astt = 1;
                foreach (DataRow r1 in ads.Tables[0].Rows)
                {
                    r2 = m_v.getrowbyid(ads1.Tables[0], "sobienlai=" + r1["sobienlai"].ToString() + " ");
                    if (r2 == null)
                    {
                        r3 = ads1.Tables[0].NewRow();
                        r3["stt"] = astt;
                        r3["sohieu"] = r1["sohieu"].ToString();
                        r3["sobienlai"] = decimal.Parse(r1["sobienlai"].ToString());
                        foreach (DataRow rr in dtkp.Rows)
                        {
                            r3["KP_" + rr["makp"].ToString()] = 0;
                        }
                        r3["KP_" + r1["makp"].ToString()] = decimal.Parse(r1["sotien"].ToString());
                        astt += 1;
                        ads1.Tables[0].Rows.Add(r3);

                    }
                    else
                    {
                        dr = ads1.Tables[0].Select("sobienlai=" + r1["sobienlai"].ToString() + "");
                        if (dr.Length > 0)
                        {
                            dr[0]["KP_" + r1["makp"].ToString()] = decimal.Parse(dr[0]["KP_" + r1["makp"].ToString()].ToString()) + decimal.Parse(r1["sotien"].ToString());
                        }
                    }
                }

                if (ads1.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
                    return;
                }
                //ads1.WriteXml("c:/dkhfd.xml",XmlWriteMode.WriteSchema);
                exp_excel_SBL(false, ads1, dtkp);

            }
            catch //(Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
        }

        private void f_Xem_LoaiVP()
        {
            string acurdir = System.Environment.CurrentDirectory;
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;
            
            try
            {
                DataSet ads = f_Get_Data_Loaivp();

                if (ads != null)
                {
                    string s_messsage = "Không có số liệu!";
                    if(chkHoantra.Checked)s_messsage = "Không có số liệu hoàn trả!";
                    if (ads.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(s_messsage, LibVP.AccessData.Msg);
                        return;
                    }

                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bangkevpnoitru_loai.rpt";

                    asyt = m_v.Syte + "^" + f_Get_CheckTEN(tree_Khoaphong);
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
                    ads.WriteXml("..//..//Datareport//v_BKthuchiravien_loai.xml", XmlWriteMode.WriteSchema);

                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện theo loại viện phí", 1, chkXemkhiin.Checked ? true : false); 
                    //frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                                
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

        private DataSet f_Get_Data_Nhomvp()
        {
            DataSet ads = null;
           
            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);


                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a1.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (chkHoantra.Checked)
                {
                    aexp += " and aaaa.id is not null";
                }
                else
                    if (chkKhonginhoantra.Checked)
                    {
                        aexp += " and aaaa.id is null";
                    }

                if (auserid != "")
                {
                    aexp += " and a1.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a1.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a1.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a1.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and a4.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a1.makp in (" + amakp + ")";
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
                        aexp += " and a1.sobienlai >= " + txtTS.Text.Trim() + " and a1.sobienlai <=" + txtDS.Text.Trim() + "";
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and a1.sobienlai<0";
                    }
                    else
                    if (chkInchungmien.Checked)
                    {
                        aexp += " and a1.sobienlai>0";
                    }
                }
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp += " and a1.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp += " and a1.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp += " and a1.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();

                asql = " select a.id, a1.quyenso quyensoid, a1.sobienlai, to_char(a1.ngay,'dd/mm/yyyy') ngay, e.sohieu quyenso, a.mabn, b.hoten,b.namsinh,c2.tenpxa||' '|| c1.tenquan ||' '|| c.tentt as diachi,j.sothe mabhyt, k.mabv, k.tenbv, d.hoten nguoithu, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, a.maicd,a.chandoan, c4.tenkp, nvl(a1.sotien,0) tongcp,nvl(a1.bhyt,0) bhyt, nvl(a1.mien,0) mien, nvl(a1.thieu,0) thieu,nvl(a1.tamung,0) tamung  " + m_sqlnhom + " ";
                asql += " from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 ";
                asql += " inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) g on a4.mavp=g.id";
                asql += " left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) h on h.id=g.id_loai left join (select ma from medibv.v_nhomvp union all select 0 from dual) i on i.ma=h.id_nhom";
                asql += " left join medibvmmyy.v_ttrvbhyt j on a.id=j.id ";
                asql += " left join (select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) aaaa on a1.quyenso=aaaa.quyenso and a1.sobienlai=aaaa.sobienlai ";
                asql += " left join (select mabv, tenbv from medibv.dmnoicapbhyt) k on j.mabv=k.mabv";
                asql += " " + aexp + "";
                asql += " group by a.id, a1.quyenso, a1.sobienlai, to_char(a1.ngay,'dd/mm/yyyy'), e.sohieu, a.mabn, b.hoten, b.cholam, b.namsinh,c2.tenpxa||' '|| c1.tenquan ||' '|| c.tentt,j.sothe, k.mabv, k.tenbv,nvl(a1.bhyt,0), nvl(a1.mien,0), nvl(a1.thieu,0),d.hoten, d.hoten ||' ('||to_char(d.userid)||')', to_char(a.ngayvao,'dd/mm/yyyy'), to_char(a.ngayra,'dd/mm/yyyy'), a.chandoan, a.maicd, c4.tenkp, nvl(a1.sotien,0), nvl(a1.tamung,0)";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                ads.Tables[0].Columns.Remove("id");
                ads.Tables[0].Columns.Remove("quyensoid");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads;
        }

        private void f_Xem_NhomVP()
        {
            string acurdir = System.Environment.CurrentDirectory;
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;
            try
            {
                DataSet ads = f_Get_Data_Nhomvp();

                if (ads != null)
                {
                    if (ads.Tables[0].Rows.Count == 0)
                    {
                        string s_messsage = "Không có số liệu!";
                        if (chkHoantra.Checked) s_messsage = "Không có số liệu hoàn trả!";

                        MessageBox.Show(s_messsage, LibVP.AccessData.Msg);
                        return;
                    }

                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bangkevpnoitru_nhom.rpt";

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
                    ads.WriteXml("..//..//Datareport//v_BKthuchiravien_nhom.xml", XmlWriteMode.WriteSchema);

                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện theo loại viện phí", 1, chkXemkhiin.Checked ? true : false); 
                    //frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();

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

        private void f_Xem()
        {
            string acurdir = System.Environment.CurrentDirectory;
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;
            //try
            //{
                DataSet ads = f_Get_Data();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {                    
                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bkthuchiravien.rpt";
                    if (rdBC_03.Checked)
                    {
                        areport = "v_2007_bkthuchiravien_conghoan.rpt";
                    }
                    if (rdBC_13.Checked)
                    {
                        areport = "BanKeBienLaiThuTienVienPhi_thuchiravien.rpt";
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
                            aghichu =lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 16) + " " +lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 16);
                        }
                        else
                        {
                            aghichu =lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " +   lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                        }
                    }

                    if (!System.IO.Directory.Exists("..//..//Datareport//"))
                    {
                        System.IO.Directory.CreateDirectory("..//..//Datareport//");
                    }
                    ads.WriteXml("..//..//Datareport//v_BKthuchiravien.xml", XmlWriteMode.WriteSchema);
                                    
                    if ((chkInrieng.Checked == false && chkInchung.Checked == false) || chkInrieng.Checked)
                    {
                        frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện", 1, chkXemkhiin.Checked ? true : false); 
                        //frmReport fa = new frmReport(b, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện", 1, chkXemkhiin.Checked ? true : false);
                        fa.KetxuatExcel = bKetxuatExcel;
                        fa.ShowDialog();
                    }
                    if (chkInchung.Checked)
                    {
                        areport = areport.Replace(".rpt", "_inchung_nx.rpt");
                        frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện", 1, chkXemkhiin.Checked ? true : false);
                        fa.KetxuatExcel = bKetxuatExcel;
                        //frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện", 1, chkXemkhiin.Checked ? true : false);
                        fa.ShowDialog();
                    }
                }
            //}
            //catch(Exception ex)
            //{
            //    ex.ToString();
            //}
            //finally
            //{
            //    System.Environment.CurrentDirectory = acurdir;
            //    tmn_Export.Enabled = true;
            //    tmn_Xem.Enabled = true;
            //}
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

        private DataSet f_BK_VTTH()
        {
            DataSet ads = null;

            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);


                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a1.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (chkHoantra.Checked)
                {
                    aexp += " and aaaa.id is not null";
                }
                else
                    if (chkKhonginhoantra.Checked)
                    {
                        aexp += " and aaaa.id is null";
                    }

                if (auserid != "")
                {
                    aexp += " and a1.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a1.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a1.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a1.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and a4.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a1.makp in (" + amakp + ")";
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
                        aexp += " and a1.sobienlai >= " + txtTS.Text.Trim() + " and a1.sobienlai <= " + txtDS.Text.Trim() + "";
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and a1.sobienlai<0";
                    }
                    else
                    if (chkInchungmien.Checked)
                    {
                        aexp += " and a1.sobienlai>0";
                    }
                }
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp += " and a1.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp += " and a1.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp += " and a1.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();

                asql = " select e.ten as nhomvp,c.ten,c.dang,sum(b.soluong) as soluong,sum(b.dongia) as dongia ";
                asql += "  from medibvmmyy.v_ttrvll a1 inner join medibvmmyy.v_ttrvct b on a1.id=b.id inner join medibv.d_dmbd c on b.mavp=c.id  inner join medibv.d_dmnhom d on c.manhom=d.id inner join medibv.v_nhomvp e on e.ma=d.nhomvp";
                asql += "  left join (select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) aaaa on a1.quyenso=aaaa.quyenso and a1.sobienlai=aaaa.sobienlai";
                asql += " " + aexp + "";
                asql += " group by e.ten,c.ten,c.dang";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads;
        }

        private DataSet f_Get_Data_Loaivp()
        {
            DataSet ads = null;
            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(a1.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (chkHoantra.Checked)
                {
                    aexp += " and aaaa.id is not null";
                }
                else
                    if (chkKhonginhoantra.Checked)
                    {
                        aexp += " and aaaa.id is null";
                    }

                if (auserid != "")
                {
                    aexp += " and a1.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and a1.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and a1.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and a1.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and a4.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and a1.makp in (" + amakp + ")";
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
                        aexp += " and a1.sobienlai >= " + txtTS.Text.Trim() + " and a1.sobienlai <= " + txtDS.Text.Trim() + "";
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and a1.sobienlai<0";
                    }
                    else
                    if (chkInchungmien.Checked)
                    {
                        aexp += " and a1.sobienlai>0";
                    }
                }
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp += " and a1.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp += " and a1.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp += " and a1.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();

                asql = " select a.id, a1.quyenso quyensoid, a1.sobienlai, to_char(a1.ngay,'dd/mm/yyyy') ngay, e.sohieu quyenso, a.mabn, b.hoten,b.namsinh,c2.tenpxa||' '|| c1.tenquan ||' '|| c.tentt as diachi,j.sothe mabhyt, k.mabv, k.tenbv, d.hoten nguoithu, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, a.maicd,a.chandoan, c4.tenkp, nvl(a1.sotien,0) tongcp,nvl(a1.bhyt,0) bhyt, nvl(a1.mien,0) mien, nvl(a1.thieu,0) thieu,nvl(a1.tamung,0) tamung " + m_sqlloai + " ";
                asql += " from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id and e.hide=0 ";
                asql += " inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) g on a4.mavp=g.id ";
                asql += " left join (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) h on h.id=g.id_loai left join (select ma from medibv.v_nhomvp union all select 0 from dual) i on i.ma=h.id_nhom ";
                asql += " left join medibvmmyy.v_ttrvbhyt j on a.id=j.id";
                asql += " left join (select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) aaaa on a1.quyenso=aaaa.quyenso and a1.sobienlai=aaaa.sobienlai ";
                asql += " left join (select mabv, tenbv from medibv.dmnoicapbhyt) k on j.mabv=k.mabv";
                asql += " " + aexp + "";
                asql += " group by a.id, a1.quyenso, a1.sobienlai, to_char(a1.ngay,'dd/mm/yyyy'), e.sohieu, a.mabn, b.hoten, b.namsinh,c2.tenpxa||' '|| c1.tenquan ||' '|| c.tentt,j.sothe, k.mabv, k.tenbv,nvl(a1.bhyt,0), nvl(a1.mien,0), nvl(a1.thieu,0),d.hoten,to_char(a.ngayvao,'dd/mm/yyyy'), to_char(a.ngayra,'dd/mm/yyyy'), a.chandoan, a.maicd, c4.tenkp, nvl(a1.sotien,0), nvl(a1.tamung,0)";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
            }
            catch 
            {
            
            }
            return ads;
        }

        private void f_Checkall(DataGridView v_dgv, System.Windows.Forms.CheckBox v_cb)
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
            if (rdBC_01.Checked || rdBC_02.Checked || rdBC_03.Checked || rdBC_13.Checked)
            {
                f_Xem();
            }
            else if (rdBC_04.Checked)
            {
                f_Xem_LoaiVP();
            }
            else if (rdBC_05.Checked)
            {
                f_Xem_NhomVP();
            }
            else if (rdBC_06.Checked)
            {
                f_Xem_Thuoc_VTTH();
            }
            else if (rdBC_07.Checked)
            {
                f_BCLoai_VP();
            }
            else if (rdBC_08.Checked)
            {
                f_BCNhom_VP();
            }
            else if (rdBC_09.Checked)
            {
                f_Get_Data_Loaivp_khoaphong();
            }
            else if (rdBC_10.Checked)
            {
                f_Xem_TonghopthuVP();
            }
            else if (rdBC_11.Checked)
            {
                f_Get_Data_SBL();
            }
            else if (rdBC_12.Checked)
            {
                f_Get_Data_Loaivp_khoaphong_soca();
            }
        }

        private void f_BCNhom_VP()
        {
            try
            {
                DataSet ads = f_BC_Nhom();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
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

                    asyt = m_v.Syte + "^" + f_Get_CheckTEN(tree_Khoaphong);
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                    if (chkXML.Checked)
                    {
                        ads.WriteXml("..//..//Datareport/v_BCthutructiep_nhomVP.xml", XmlWriteMode.WriteSchema);
                    }
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
                    //frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu trực tiếp theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();
                    fa.Close();
                    fa.Dispose();
                }
            }
            catch
            {
            }
        }

        private DataSet f_BC_Nhom()
        {
            DataSet ads = null,  ads_tu = null;

            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                string aexp_mien_thieu = "";
                decimal  st1, st2;

                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);


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
                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    aexp += " and a.sobienlai >= " + txtTS.Text.Trim() + " and a.sobienlai <= " + txtDS.Text.Trim() + "";
                }
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp += " and a.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp += " and a.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp += " and a.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();

                aexp_mien_thieu = aexp;

                asql += " select 1 as stt, f.id_nhom as idnhom, to_char(f.ma) as ma, f.ten, sum(b.soluong- case when b.tra>0 then 1 else 0 end) as soluong,sum(b.soluong*b.dongia -b.tra) as sotien,sum(b.soluong*b.giamua) as sotiengiamua";
                asql += "  from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                asql += " inner join (select a.id, a.ten, b.id_nhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id union all select a.id, a.ten, b.nhomvp as id_nhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id) e on e.id=b.mavp";
                asql += " inner join (select stt, ma as id_nhom, ma, ten from medibv.v_nhomvp union all select distinct 0 stt, 0 as id_nhom, 0 as ma,'' ten from dual) f on e.id_nhom=f.ma";
                asql += " " + aexp + "";
                asql += " group by f.id_nhom,to_char(f.ma),f.ten ";
                asql += " union all ";

                //asql += "  select 2 as stt, 0 as idnhom, to_char(c.id) as ma, c.hoten, 0 as soluong, sum(b.soluong*b.dongia -b.tra) as sotien, sum(b.soluong*b.giamua) as sotiengiamua";
                //asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id  left join medibv.v_dlogin c on a.userid=c.id  ";
                //asql += " inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id";
                //asql += " left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp ";
                //asql += " " + aexp + "";
                //asql += " group by to_char(c.id),c.hoten";

                asql += "select 2 as stt, 0 as idnhom, to_char(c.id) as ma, c.hoten, 0 as soluong, sum(b.soluong*b.dongia -b.tra) as sotien, sum(b.soluong*b.giamua) as sotiengiamua ";
                asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id  left join medibv.v_dlogin c on a.userid=c.id ";
                asql += " " + aexp + "";
                asql += " group by to_char(c.id),c.hoten ";

                //Binh Lay so tien thieu - mien cua BN rieng
                //mien
                asql += " union all";
                asql += " select 3 as stt,to_number('-98') as idnhom,'Mien' as ma,'Miễn' as ten";
                asql += " ,to_number('0')  as soluong ,sum(a.mien)*-1 as sotien,sum(a.mien)*-1 as sotiengiamua";
                asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                asql += " " + aexp_mien_thieu + "";
                asql += " and a.mien>0";
                //thieu
                asql += " union all";
                asql += " select 3 as stt,to_number('-99') as idnhom,'Thieu' as ma,'Thiếu' as ten";
                asql += " ,to_number('0')  as soluong ,sum(a.thieu)*-1 as sotien,sum(a.thieu)*-1 as sotiengiamua";
                asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                asql += " " + aexp_mien_thieu + "";
                asql += " and a.thieu>0";
                //end binh 
                if (chkTU.Checked)
                {
                    asql += " union all";
                    asql += " select 1 as stt,0 as idnhom,to_char(userid) as ma,to_char('Thu tiền tạm ứng') as ten, 0 as soluong,sum(sotien) as sotien,to_number('0') as sotiengiamua";//binh
                    asql += " from medibvmmyy.v_tamung where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(userid)";
                }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (chkTU.Checked)
                {
                    asql = "select 1 as stt,0 as idnhom,to_char(userid) as ma,to_char('Thu tiền tạm ứng') as ten, 0 as soluong,sum(sotien) as sotien";
                    if (chkGio.Checked)
                    {
                        asql += " from medibvmmyy.v_tamung where to_date(to_char(ngayud,'dd/mm/yyyy'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                    }
                    else
                    {
                        asql += " from medibvmmyy.v_tamung where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    }
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(userid)";
                    ads_tu = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    if (ads_tu != null)
                    {
                        if (ads == null)
                        {
                            ads = ads_tu;
                        }
                        else
                        {
                            foreach (DataRow r1 in ads.Tables[0].Select("stt=2"))
                            {
                                foreach (DataRow r_tu in ads_tu.Tables[0].Select("ma=" + r1["ma"].ToString() + ""))
                                {
                                    st1 = 0; st2 = 0;
                                    st1 = decimal.Parse(r_tu["sotien"].ToString());
                                    st2 = decimal.Parse(r1["sotien"].ToString());

                                    st2 = st2 + st1;

                                    r1["sotien"] = st2;
                                    ads.AcceptChanges();
                                }
                            }

                        }
                    }
                }
            }
            catch
            {
            }
            return ads;
        }

        private DataSet f_BC_Loai()
        {
            DataSet ads = null,  ads_tu = null;
            // DataRow r4;
            try
            {
                string asql = "",  aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                string aexp_mien_thieu = "";
                decimal  st1, st2;
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);


                amakp = f_Get_CheckID(tree_Khoaphong);

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

                if (txtTS.Text != "" && txtDS.Text != "")
                {
                    aexp += " and a.sobienlai >= " + txtTS.Text.Trim() + " and a.sobienlai <= " + txtDS.Text.Trim() + "";
                }
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp += " and a.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp += " and a.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp += " and a.loaithu in(1)";
                }
                aexp_mien_thieu = aexp;
                if (adoituong != "")
                {
                    aexp += " and b.madoituong in(" + adoituong + ")";
                }
                
                aexp = "where " + aexp.Trim();
                aexp_mien_thieu = "where " + aexp_mien_thieu.Trim();
                asql += " select 1 as stt,f.id,f.ma,f.ten";
                asql += " ,sum(b.soluong- case when b.tra>0 then 1 else 0 end)  as soluong ,sum(b.soluong*b.dongia -b.tra) as sotien,sum(b.soluong*b.giamua) as sotiengiamua, 0 as sotiendichvu";
                asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                asql += " inner join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma) froo) e on e.id=b.mavp";
                asql += " inner join (select id, id_nhom,ma,ten from medibv.v_loaivp union all select 0 id, 0 id_nhom,'' ma,'' ten from dual) f on e.id_loai=f.id";
                asql += " " + aexp + "";            
                asql += " group by f.ma,f.id,f.ten";
                asql += " union all ";
                asql += "select 2 as stt, 0 as idnhom, to_char(c.id) as ma, c.hoten, 0 as soluong, sum(b.soluong*b.dongia -b.tra) as sotien, sum(b.soluong*b.giamua) as sotiengiamua, 0 as sotiendichvu ";
                asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id  left join medibv.v_dlogin c on a.userid=c.id ";
                asql += " " + aexp + "";
                asql += " group by to_char(c.id),c.hoten ";
                
                //Binh Lay so tien thieu - mien cua BN rieng
                //mien
                asql += " union all";
                asql += " select 3 as stt,to_number('-98') as id,'Mien' as ma,'Miễn' as ten";
                asql += " ,to_number('0')  as soluong ,sum(a.mien)*-1 as sotien,sum(a.mien)*-1 as sotiengiamua,0 as sotiendichvu";
                asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                asql += " " + aexp_mien_thieu + "";
                asql += " and a.mien>0";
                //thieu
                asql += " union all";
                asql += " select 3 as stt,to_number('-99') as id,'Thieu' as ma,'Thiếu' as ten";
                asql += " ,to_number('0')  as soluong ,sum(a.thieu)*-1 as sotien,sum(a.thieu)*-1 as sotiengiamua,0 as sotiendichvu";
                asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_dlogin d on a.userid=d.id ";
                asql += " " + aexp_mien_thieu + "";
                asql += " and a.thieu>0";     
                // bhyt
                asql += " union all";
                asql += " select 3 as stt,to_number('-97') as id,'BHYT' as ma,'BHYT' as ten";
                asql += " ,to_number('0')  as soluong ,sum(case when b.madoituong=1 then case when instr(nvl(cc.sothe,' '),'UC')>0 or instr(nvl(cc.sothe,' '),'VC')>0 or instr(nvl(cc.sothe,' '),'TC')>0 then (case when b.tra>0 then 0 else b.soluong end)*b.dongia*0.8 else (case when b.tra>0 then 0 else b.soluong end)*b.dongia end else 0 end)*-1 as sotien, to_number('0') as sotiengiamua,0 as sotiendichvu";
                asql += " from medibvmmyy.v_ttrvds ds inner join medibvmmyy.v_ttrvll a on ds.id=a.id inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c1 on a.id=c1.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id  left join medibv.v_dlogin c on a.userid=c.id";
                asql += " " + aexp_mien_thieu + "";
                asql += " and a.bhyt>0";
            //end binh                
                if (chkTU.Checked)
                {
                    asql += " union all";
                    asql += " select 1 as stt,0 as id,to_char(userid) as ma,to_char('Thu tiền tạm ứng') as ten, 0 as soluong,sum(sotien) as sotien,to_number('0') as sotiengiamua,0 as sotiendichvu";//binh
                    asql += " from medibvmmyy.v_tamung where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(userid)";
                }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
                if (chkTU.Checked)
                {
                    asql = "select 1 as stt,0 as idnhom,to_char(userid) as ma,to_char('Thu tiền tạm ứng') as ten, 0 as soluong,sum(sotien) as sotien";
                    asql += " from medibvmmyy.v_tamung where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    if (auserid != "") asql += " and userid in (" + auserid + ")";
                    asql += " group by to_char(userid)";
                    ads_tu = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    if (ads_tu != null)
                    {
                        if (ads == null)
                        {
                            ads = ads_tu;
                        }
                        else
                        {
                            foreach (DataRow r1 in ads.Tables[0].Select("stt=2"))
                            {
                                foreach (DataRow r_tu in ads_tu.Tables[0].Select("ma=" + r1["ma"].ToString() + ""))
                                {
                                    st1 = 0; st2 = 0;
                                    st1 = decimal.Parse(r_tu["sotien"].ToString());
                                    st2 = decimal.Parse(r1["sotien"].ToString());

                                    st2 = st2 + st1;

                                    r1["sotien"] = st2;
                                    ads.AcceptChanges();
                                }
                            }

                        }
                    }
                }
            }
            catch
            {
            }
            return ads;
        }

        private void f_BCLoai_VP()
        {
            try
            {
                DataSet ads = f_BC_Loai();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
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

                    asyt = m_v.Syte + "^" + f_Get_CheckTEN(tree_Khoaphong);
                    abv = m_v.Tenbv;

                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayin.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayin.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayin.Value.Year.ToString();
                    anguoiin = txtNguoilapphieu.Text.Trim();
                    if (System.IO.Directory.Exists("..\\..\\Datareport"))
                    {
                        ads.WriteXml("..\\..\\Datareport\\v_BCthutructiep_LoaiVP.xml", XmlWriteMode.WriteSchema);
                    }
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

        private void f_Xem_Thuoc_VTTH()
        {
            string acurdir = System.Environment.CurrentDirectory;
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;

            try
            {
                DataSet ads = f_BK_VTTH();

                if (ads != null)
                {
                    if (ads.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
                        return;
                    }

                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bangkevpnoitru_vtth.rpt";

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
                    if (!System.IO.Directory.Exists("..//..//Datareport//"))
                    {
                        System.IO.Directory.CreateDirectory("..//..//Datareport//");
                    }
                    ads.WriteXml("..//..//Datareport//v_2007_bangkevpnoitru_vtth.xml", XmlWriteMode.WriteSchema);

               
                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();

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

        private void f_Xem_TonghopthuVP()
        {
            string acurdir = System.Environment.CurrentDirectory;
            tmn_Export.Enabled = false;
            tmn_Xem.Enabled = false;
            try
            {
                DataSet ads = f_BK_TonghopthuVP();
                if (ads != null)
                {
                    if (ads.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
                        return;
                    }

                    string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_2007_bangtonghopthuvienphi.rpt";
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
                    if (chkXML.Checked)
                    {
                        if (!System.IO.Directory.Exists("..//..//Datareport//"))
                        {
                            System.IO.Directory.CreateDirectory("..//..//Datareport//");
                        }
                        ads.WriteXml("..//..//Datareport//v_2007_bangtonghopthuvienphi.xml", XmlWriteMode.WriteSchema);
                    }

                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo thu chi ra viện theo loại viện phí", 1, chkXemkhiin.Checked ? true : false);
                    fa.KetxuatExcel = bKetxuatExcel;
                    fa.ShowDialog();

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

        private DataSet f_BK_TonghopthuVP()
        {
            DataSet ads = null;
            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", adoituong = "", aloaibn = "", aloaidv = "", amakp = "";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Get_CheckID(tree_Quyenso);
                adoituong = f_Get_CheckID(tree_Doituong);
                aloaibn = f_Get_CheckID(tree_Loaibn);
                aloaidv = f_Get_CheckID(tree_Loaidv);
                amakp = f_Get_CheckID(tree_Khoaphong);
                string asqlht = "select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                if (amakp != "")
                {
                    amakp = amakp.Replace(",", "','");
                    amakp = "'" + amakp + "'";
                }
                if (chkGio.Checked)
                {
                    aexp = "to_date(to_char(b.ngayud,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') between to_date('" + txtTN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi') and to_date('" + txtDN.Text.Substring(0, 16) + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp = "to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                }
                if (auserid != "")
                {
                    aexp += " and b.userid in (" + auserid + ")";
                }
                if (aquyenso != "")
                {
                    aexp += " and b.quyenso in (" + aquyenso + ")";
                }
                if (aloaidv != "")
                {
                    aexp += " and b.loai in (" + aloaidv + ")";
                }
                if (aloaibn != "")
                {
                    aexp += " and b.loaibn in (" + aloaibn + ")";
                }
                if (adoituong != "")
                {
                    aexp += " and c.madoituong in (" + adoituong + ")";
                }
                if (amakp != "")
                {
                    aexp += " and c.makp in (" + amakp + ")";
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
                        aexp += " and b.sobienlai >= " + txtTS.Text.Trim() + " and b.sobienlai <= " + txtDS.Text.Trim() + "";
                    }
                }
                if (!((chkInchungmien.Checked && chk100.Checked) || (!chkInchungmien.Checked && !chk100.Checked)))
                {
                    if (chk100.Checked)
                    {
                        aexp += " and b.sobienlai<0";
                    }
                    else
                    if (chkInchungmien.Checked)
                    {
                        aexp += " and b.sobienlai>0";
                    }
                }
                string aexp1 = "";
                if (chkBHYTKB.Checked && chkTTRV.Checked)
                {
                    aexp1 = " and b.loaithu in(0,1)";
                }
                else if (chkBHYTKB.Checked == false && chkTTRV.Checked)
                {
                    aexp1 = " and b.loaithu in(0)";
                }
                else if (chkBHYTKB.Checked && chkTTRV.Checked == false)
                {
                    aexp1 = " and b.loaithu in(1)";
                }
                aexp = "where " + aexp.Trim();
                asql = "select makp,tenkp,sum(soca) as soca,sum(sotien) as sotien,sum(thatthu) as thatthu from (";
                asql += " select c.makp,d.tenkp,count(to_number(a.id)) as soca,sum(c.soluong*c.dongia-c.tra) - sum(case when c.madoituong=1 then case when instr(nvl(cc.sothe,' '),'UC')>0 or instr(nvl(cc.sothe,' '),'VC')>0 or instr(nvl(cc.sothe,' '),'TC')>0 then (case when c.tra>0 then 0 else c.soluong end)*c.dongia*0.8 else (case when c.tra>0 then 0 else c.soluong end)*c.dongia end else 0 end) as sotien,sum(thieu) as thatthu ";
                asql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on a.id=c.id left join medibvmmyy.v_ttrvbhyt cc on a.id=cc.id inner join medibv.btdkp_bv d on c.makp=d.makp";
                asql += " " + aexp + aexp1 + "";
                if (chkThatthu.Checked) asql += " and b.thieu > 0 ";
                asql += " group by c.makp,d.tenkp";
                if (chkTT.Checked)
                {
                    asql += " union all";
                    asql += " select c.makp,d.tenkp,count(to_number(b.id)) as soca,sum(c.soluong*c.dongia-c.tra-c.mien) as sotien,to_number('0') as thatthu";
                    asql += " from medibvmmyy.v_vienphill b inner join medibvmmyy.v_vienphict c on c.id=b.id inner join medibv.btdkp_bv d on c.makp=d.makp";
                    asql += " " + aexp + "";
                    asql += " group by c.makp,d.tenkp";
                }
                asql += " ) froo group by makp,tenkp having sum(sotien)>0";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads;
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
                if (txtTimso.Text.Trim().ToLower() == lan.Change_language_MessageText("tìm nhanh"))
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
                    txtTimso.Text = lan.Change_language_MessageText("Tìm nhanh");
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
  
        private void frmBKThuchiravien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void tree_Doituong_AfterSelect(object sender, TreeViewEventArgs e)
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

        private void tree_Loaibn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Loaibn.Nodes.Count; i++)
                {
                    if (tree_Loaibn.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkAll_Loaibn.Checked = false;
            }
            catch
            {
            }
        }

        private void tree_Loaidv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Loaidv.Nodes.Count; i++)
                {
                    if (tree_Loaidv.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkAll_Loaidv.Checked = false;
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
                txtDN.Location = new System.Drawing.Point(419, 4);
                label1.Location = new System.Drawing.Point(351, 4);                
                txtTN.CustomFormat = "dd/MM/yyyy HH:mm";
                txtDN.CustomFormat = "dd/MM/yyyy HH:mm";
            }
            else
            {
                txtTN.Width = 85;
                txtDN.Width = 85;
                txtDN.Location = new System.Drawing.Point(391, 4);
                label1.Location = new System.Drawing.Point(323, 4);
                
                txtTN.CustomFormat = "dd/MM/yyyy HH:mm";
                txtDN.CustomFormat = "dd/MM/yyyy HH:mm";
            }
        }

        private void lbl_loai_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            bKetxuatExcel = m_v.f_quyenchitiet_export(aquyenchitiet);
            if (bKetxuatExcel==false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền kết xuất excel!"));
                return;
            }
            DataSet ads = f_Get_Data_Loaivp();
            if (ads != null)
            {
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
                    return;
                }
                exp_excel(false, ads,true);
            }
        }

        private void exp_excel(bool print,DataSet ads_l,bool co)
        {

            m_v.check_process_Excel();

            int k = 22, be = 4, dong = 6, sodong = ads_l.Tables[0].Rows.Count + dong, socot = ads_l.Tables[0].Columns.Count - 1, dongke = sodong - 1;

            tenfile = m_v.f_export_excel(ads_l.Tables[0], "BCCHITIETVP");
            oxl = new Excel.Application();
            owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
            osheet = (Excel._Worksheet)owb.ActiveSheet;
            oxl.ActiveWindow.DisplayGridlines = true;

            for (int i = 0; i < be; i++) osheet.get_Range(m_v.getIndex(i) + "1", m_v.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
            osheet.get_Range(m_v.getIndex(16) + "4", m_v.getIndex(socot) + sodong.ToString()).NumberFormat = "###,###,###,##0";            
            osheet.get_Range(m_v.getIndex(0) + "5", m_v.getIndex(socot) + dongke.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;

            for (int i = 0; i < 21; i++)
                osheet.Cells[dong - 1, i + 1] = get_ten(i);
            if (co)
            {
                foreach (DataRow r in ads_loai.Tables[0].Select("true", "id")) osheet.Cells[dong - 1, k++] = r["ten"].ToString();
            }
            else
            {
                foreach (DataRow r in ads_nhom.Tables[0].Select("true", "ma")) osheet.Cells[dong - 1, k++] = r["ten"].ToString();
            }
           
           // osheet.get_Range(m_v.getIndex(8) + "5", m_v.getIndex(socot - 1) + dongke.ToString()).Font.ColorIndex = 5;
            orange = osheet.get_Range(m_v.getIndex(0) + "5", m_v.getIndex(socot) + sodong.ToString());

            orange.Font.Name = "Arial";
            orange.Font.Size = 8;
            orange.EntireColumn.AutoFit();
            oxl.ActiveWindow.DisplayZeros = false;
            osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
            osheet.PageSetup.CenterFooter = "Trang : &P/&N";

            osheet.Cells[1, 1] = m_v.Syte;
            osheet.Cells[2, 1] = m_v.Tenbv;

            orange = osheet.get_Range(m_v.getIndex(0) + "1", m_v.getIndex(2) + "1");
            orange = osheet.get_Range(m_v.getIndex(1) + "1", m_v.getIndex(2) + "1");

            orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
            if (co)
            {
                osheet.Cells[1, 8] = "BÁO CÁO CHI TIẾT THEO LOẠI VIỆN PHÍ";
            }
            else
            {
                osheet.Cells[1, 8] = "BÁO CÁO CHI TIẾT THEO NHÓM VIỆN PHÍ";
            }
            osheet.Cells[2, 8] = (txtTN.Text == txtDN.Text) ? "Tháng " + txtTN.Text : "Từ ngày " + txtDN.Text + " đến ngày" + txtDN.Text;
            orange = osheet.get_Range(m_v.getIndex(3) + "1", m_v.getIndex(socot - 1) + "2");

            orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
            orange.Font.Size = 12;
            orange.Font.Bold = true;

            if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            else oxl.Visible = true;
        }

        private void exp_excel_loaikp(bool print, DataSet ads_l, System.Data.DataTable dtkp)
        {
            try
            {
                decimal s_mien_ = 0,s_bhyttra=0;
                m_v.check_process_Excel();

                int k = 3, be = 4, dong = 6, sodong = ads_l.Tables[0].Rows.Count + dong, socot = ads_l.Tables[0].Columns.Count - 1, dongke = sodong + 2, sss = sodong - 1;

                tenfile = m_v.f_export_excel(ads_l.Tables[0], "BCCHITIETVP");
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;

                for (int i = 0; i < be; i++) osheet.get_Range(m_v.getIndex(i) + "1", m_v.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
                osheet.get_Range(m_v.getIndex(3) + "4", m_v.getIndex(socot) + sodong.ToString()).NumberFormat = "###,###,###,##0";
                osheet.get_Range(m_v.getIndex(0) + "5", m_v.getIndex(socot) + dongke.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;

                for (int i = 0; i < 2; i++)
                    osheet.Cells[dong - 1, i + 1] = get_ten_loai_kp(i);
                foreach (DataRow r in dtkp.Select("true", "makp")) osheet.Cells[dong - 1, k++] = r["tenKP"].ToString();
                
                osheet.Cells[sodong, 2] = "Tổng cộng";
                osheet.Cells[sodong + 1, 2] = "Tổng miễn";
                osheet.Cells[sodong + 2, 2] = "Tổng thực thu";
                osheet.Cells[dong - 1, socot + 1] = "Tổng cộng";
                //decimal bhyttra = 0, tongcong = 0;
                for (int i = 3; i < dtkp.Rows.Count + 5; i++)//4=5
                {
                    osheet.Cells[sodong, i] = "=SUM(" + m_v.getIndex(i - 1) + dong.ToString() + ":" + m_v.getIndex(i - 1) + sss.ToString() + ")";
                    
                }
                for (int j = 6; j < sodong ; j++)//for (int j = 6; j < sodong-1; j++)
                {
                    osheet.Cells[dong++, socot+1] = "=SUM(" + m_v.getIndex(2) + j.ToString() + ":" + m_v.getIndex(socot - 1) + j.ToString() + ")";
                }
                s_mien_ = f_Tongmien();
                s_bhyttra = f_Tongbhyttra();

                osheet.Cells[dong + 1, socot + 1] = "=" + s_mien_;
                for (int j = 7; j < sodong; j++)//sua
                {
                    osheet.Cells[dong + 2, socot + 1] = "=SUM(" + m_v.getIndex(2) + j.ToString() + ":" + m_v.getIndex(socot - 1) + j.ToString() + ")" + "-" + s_mien_ + "-" + s_bhyttra;
                }
                
                for (int i = 4; i < dtkp.Rows.Count +5; i++)// sua4=5
                {
                    //osheet.Cells[dong + 2, socot + 1] = "=SUM(" + m_v.getIndex(i - 1) + dong.ToString() + ":" + m_v.getIndex(i - 1) + (sss + 1).ToString() + ")" + "-" + s_mien_; // code cu
                    osheet.Cells[dong + 2, socot + 1] = "=SUM(" + m_v.getIndex(i - 1) + dong.ToString() + ":" + m_v.getIndex(i - 1) + (sss + 1).ToString() + ")" + "-" + s_mien_ + "-" + s_bhyttra;
                   // osheet.Cells[dong + 2, socot + 1] = "=SUM(" + m_v.getIndex(i - 1) + dong.ToString() + ":" + m_v.getIndex(i - 1) + (sss + 1).ToString() + ")" + "-" + s_mien_;
                }
                orange = osheet.get_Range(m_v.getIndex(0) + "5", m_v.getIndex(socot) + Convert.ToString(sodong+2));

                orange.Font.Name = "Arial";
                orange.Font.Size = 8;
                orange.EntireColumn.AutoFit();
                oxl.ActiveWindow.DisplayZeros = false;
                //osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                //osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                //osheet.PageSetup.CenterFooter = "Trang : &P/&N";

                osheet.Cells[1, 1] = m_v.Syte;
                osheet.Cells[2, 1] = m_v.Tenbv;

                orange = osheet.get_Range(m_v.getIndex(0) + "1", m_v.getIndex(2) + "1");
                orange = osheet.get_Range(m_v.getIndex(1) + "1", m_v.getIndex(2) + "1");

                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                if (!chkThatthu.Checked) osheet.Cells[1, 8] = "BẢNG TỔNG HỢP THU TIỀN VIỆN PHÍ";
                else osheet.Cells[1, 8] = "BẢNG TỔNG HỢP THẤT THU";

                if (rdThang.Checked)
                {
                    osheet.Cells[2, 8] = "Tháng " + txtThang.Value.ToString() + " năm " + txtNam.Value.ToString() + "";
                }
                else if (rdNgay.Checked)
                {
                    if (chkGio.Checked)
                        osheet.Cells[2, 8] = (txtTN.Text.Substring(0, 10) == txtDN.Text.Substring(0, 10)) ? "Ngày " + txtTN.Text.Substring(0, 2) + " tháng " + txtTN.Text.Substring(3, 2) + " năm " + txtTN.Text.Substring(6, 4) + "" : "Từ ngày " + txtTN.Text.Substring(0, 16) + " đến ngày" + txtDN.Text.Substring(0, 16);
                    else
                        osheet.Cells[2, 8] = (txtTN.Text.Substring(0, 10) == txtDN.Text.Substring(0, 10)) ? "Ngày " + txtTN.Text.Substring(0, 2) + " tháng " + txtTN.Text.Substring(3, 2) + " năm " + txtTN.Text.Substring(6, 4) + "" : "Từ ngày " + txtTN.Text.Substring(0, 10) + " đến ngày" + txtDN.Text.Substring(0, 10);
                }
                orange = osheet.get_Range(m_v.getIndex(3) + "1", m_v.getIndex(socot - 1) + "2");

                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size = 12;
                orange.Font.Bold = true;

                orange = osheet.get_Range(m_v.getIndex(0) + ""+ sodong.ToString(), m_v.getIndex(socot - 0) + "" + (sodong+3).ToString());
                orange.Font.Size = 8;
                orange.Font.Bold = true;

                orange = osheet.get_Range(m_v.getIndex(socot - 0) + "3", m_v.getIndex(socot - 0) + "" + (sodong + 3).ToString());
                orange.Font.Size = 8;
                orange.Font.Bold = true;

                orange = osheet.get_Range(m_v.getIndex(socot) + "" + sodong.ToString(), m_v.getIndex(socot) + "" + (sodong).ToString());
                orange.Font.Size = 8;
                orange.Font.Bold = true;
                orange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red); 

                if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                else oxl.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exp_excel_SBL(bool print, DataSet ads_l, System.Data.DataTable dtkp)
        {
            try
            {
                m_v.check_process_Excel();

                int k = 4, be = 4, dong = 6, sodong = ads_l.Tables[0].Rows.Count + dong, socot = ads_l.Tables[0].Columns.Count - 1, dongke = sodong, sss = sodong - 1;

                tenfile = m_v.f_export_excel(ads_l.Tables[0], "BCCHITIETVP");
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;

                for (int i = 0; i < be; i++) osheet.get_Range(m_v.getIndex(i) + "1", m_v.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
                osheet.get_Range(m_v.getIndex(3) + "4", m_v.getIndex(socot) + sodong.ToString()).NumberFormat = "###,###,###,##0";
                osheet.get_Range(m_v.getIndex(0) + "5", m_v.getIndex(socot) + dongke.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;

                for (int i = 0; i < 3; i++)
                    osheet.Cells[dong - 1, i + 1] = get_ten_SBL(i);

                foreach (DataRow r in dtkp.Select("true", "makp")) osheet.Cells[dong - 1, k++] = r["tenKP"].ToString();

                osheet.Cells[sodong, 2] = "Tổng cộng";
                osheet.Cells[dong - 1, socot + 1] = "Tổng cộng";
                for (int i = 4; i < dtkp.Rows.Count + 5; i++)
                {
                    osheet.Cells[sodong, i] = "=SUM(" + m_v.getIndex(i - 1) + dong.ToString() + ":" + m_v.getIndex(i - 1) + sss.ToString() + ")";
                }

                for (int j = 6; j < sodong; j++)
                {
                    osheet.Cells[dong++, socot + 1] = "=SUM(" + m_v.getIndex(3) + j.ToString() + ":" + m_v.getIndex(socot - 1) + j.ToString() + ")";
                }


                orange = osheet.get_Range(m_v.getIndex(0) + "5", m_v.getIndex(socot) + sodong.ToString());

                orange.Font.Name = "Arial";
                orange.Font.Size = 8;
                orange.EntireColumn.AutoFit();
                oxl.ActiveWindow.DisplayZeros = false;
                osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";

                osheet.Cells[1, 1] = m_v.Syte;
                osheet.Cells[2, 1] = m_v.Tenbv;

                orange = osheet.get_Range(m_v.getIndex(0) + "1", m_v.getIndex(2) + "1");
                orange = osheet.get_Range(m_v.getIndex(1) + "1", m_v.getIndex(2) + "1");

                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                osheet.Cells[1, 8] = "BẢNG KÊ CHI TIẾT HOÁ ĐƠN THU TIỀN";
                if (rdThang.Checked)
                {
                    osheet.Cells[2, 8] = "Tháng " + txtThang.Value.ToString() + " năm " + txtNam.Value.ToString() + "";
                }
                else if (rdNgay.Checked)
                {
                    if (chkGio.Checked)
                        osheet.Cells[2, 8] = (txtTN.Text.Substring(0, 10) == txtDN.Text.Substring(0, 10)) ? "Ngày " + txtTN.Text.Substring(0, 2) + " tháng " + txtTN.Text.Substring(3, 2) + " năm " + txtTN.Text.Substring(6, 4) + "" : "Từ ngày " + txtTN.Text.Substring(0, 16) + " đến ngày" + txtDN.Text.Substring(0, 16);
                    else
                        osheet.Cells[2, 8] = (txtTN.Text.Substring(0, 10) == txtDN.Text.Substring(0, 10)) ? "Ngày " + txtTN.Text.Substring(0, 2) + " tháng " + txtTN.Text.Substring(3, 2) + " năm " + txtTN.Text.Substring(6, 4) + "" : "Từ ngày " + txtTN.Text.Substring(0, 10) + " đến ngày" + txtDN.Text.Substring(0, 10);
                }
                orange = osheet.get_Range(m_v.getIndex(3) + "1", m_v.getIndex(socot - 1) + "2");

                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size = 12;
                orange.Font.Bold = true;

                if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                else oxl.Visible = true;
            }
            catch
            {
            }
        }

        private void lbl_nhom_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            bKetxuatExcel = m_v.f_quyenchitiet_export(aquyenchitiet);
            if (bKetxuatExcel == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền kết xuất excel!"));
                return;
            } 
            DataSet ads = f_Get_Data_Nhomvp();
            if (ads != null)
            {
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có số liệu!", LibVP.AccessData.Msg);
                    return;
                }
                exp_excel(false, ads,false);
            }
        }

        private void rdBC_04_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBC_04.Checked) lbl_loai.Enabled = true;
            else lbl_loai.Enabled = false;            
        }

        private void rdBC_05_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBC_05.Checked) lbl_nhom.Enabled = true;
            else lbl_nhom.Enabled = false;
        }

        private void chkThatthu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThatthu.Checked)
            {
                chkTU.Checked = false;
                chkTT.Checked = false;
            }
        }

        private void rdBC_01_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdBC_01.Checked)
            {
                //chkInchungmien.Enabled = false;
                //chkInchungmien.Checked = false;
            }
        }

        private void rdBC_03_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdBC_03.Checked)
            {
                //chkInchungmien.Enabled = false;
                //chkInchungmien.Checked = false;
            }
        }

        private void rdBC_02_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdBC_02.Checked)
            {
                //chkInchungmien.Enabled = false;
                //chkInchungmien.Checked = false;
            }
        }

        private void chk100_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk100.Checked && (rdBC_01.Checked || rdBC_02.Checked || rdBC_03.Checked || rdBC_09.Checked)) chkInchungmien.Enabled = true;
            //else chkInchungmien.Enabled = false;
        }

        private void chk_mien_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_mien.Checked && (rdBC_01.Checked || rdBC_02.Checked || rdBC_03.Checked)) chk100.Enabled = true;
            //else chk100.Enabled = false;
        }

        private void dgUser_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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

        private void rdBC_09_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkTTRV_CheckedChanged(object sender, EventArgs e)
        {
            chkTU.Enabled = chkTTRV.Checked || chkBHYTKB.Checked;
            chkTU.Checked = (chkTU.Enabled == false) ? false : chkTU.Checked;
        }
    }
}