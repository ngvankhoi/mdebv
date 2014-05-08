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
    public partial class frmBKHoantra : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_userid = "";
        private LibVP.AccessData m_v;
        private string m_menu_id = "menu_B_5_Baocaotonghop";
        private bool bKetxuatExcel = true;
        public frmBKHoantra(LibVP.AccessData v_v, string v_userid)
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
        private void frmBKHoantra_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            rdNgay.Checked = true;
            rdThang_CheckedChanged(null, null);
            txtTN.Value = m_v.s_server_date;
            txtDN.Value = txtTN.Value;

            f_Check(dgUser, m_userid);
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
                txtTN.Value = DateTime.Now;
                txtDN.Value = DateTime.Now;

                string asql = "";
                asql = "select 0 as chon,hoten,userid,id from medibv.v_dlogin ";
                if (m_v.sys_Loctheonguoidangnhap && !bAdmin) asql += " where id =" + m_userid + "";
                asql += " order by hoten";
                dgUser.DataSource = m_v.get_data(asql).Tables[0];

                asql = "select 0 as chon,a.sohieu,a.sohieubl,a.tu,a.den,a.soghi,b.hoten as userid_hoten,a.userid,a.id from medibv.v_quyenso a left join medibv.v_dlogin b on a.userid=b.id where a.hide=0 order by a.sohieu";
                dgSo.DataSource = m_v.get_data(asql).Tables[0];

                asql = "select 0 as chon, id, ten from medibv.v_loaibn order by id";
                dgLoaibn.DataSource = m_v.get_data(asql).Tables[0];

                asql = "select 0 as chon, ma as id, ten from medibv.v_tenloaivp order by ma";
                dgLoaidv.DataSource = m_v.get_data(asql).Tables[0];
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
            DataSet ads = null;
            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", aloaibn = "", aloaidv = "";
                auserid = f_Getchecked(dgUser);
                aquyenso = f_Getchecked(dgSo);
                aloaibn = f_Getchecked(dgLoaibn);
                aloaidv = f_Getchecked(dgLoaidv);

                aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
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
                // them dk checkbox thu truc tiep, tam ung, thanh toan ra vien// ok
                string str_c = "";
                if (chkTT.Checked) str_c = "'1',";
                if (chkTTRV.Checked) str_c += "'3',";//if (chkTTRV.Checked) str_c += "'2',";
                if (chkTU.Checked) str_c += "'2',"; //if (chkTU.Checked) str_c += "'3',";
                if (chkTT.Checked || chkTTRV.Checked || chkTU.Checked)
                {
                    aexp += " and a.ghichu in (" + str_c.Trim().Trim(',') + ")"; //aexp += " and a.ghichu in (" + str_c.Substring(0, str_c.Length - 1) + ")";
                }
                //
                if (rdBC_02.Checked)
                {
                    aexp += " and to_char(a.ngay,'dd/mm/yyyy') = to_char(a.ngayud,'dd/mm/yyyy')";
                }
                else
                    if(rdBC_03.Checked)
                {
                    aexp += " and to_char(a.ngay,'dd/mm/yyyy') <> to_char(a.ngayud,'dd/mm/yyyy')";
                }

                aexp = "where " + aexp.Trim();
                asql = "select a.id,a.quyenso,b.sohieu,b.sohieubl,a.sobienlai,a.sotien,to_char(a.ngay,'dd/mm/yyyy') as ngay, case when to_date(to_char(a.ngayud,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') then to_char(a.ngayud,'dd/mm/yyyy') else to_char(a.ngay,'dd/mm/yyyy') end as ngaythu,a.mabn,d.hoten,d.namsinh, trim(d.sonha||' '||d.thon) as diachi, a.mavaovien,a.maql,a.loai,a.loaibn,a.userid, c.userid as user_userid, c.hoten as user_hoten,trim(a.ghichu) as ghichu from medibvmmyy.v_hoantra a left join medibv.v_quyenso b on a.quyenso=b.id and b.hide=0 left join medibv.v_dlogin c on a.userid=c.id left join medibv.btdbn d on a.mabn=d.mabn " + aexp + " order by a.ngay";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                //
                try { ads.Tables[0].Columns.Add("BHYTTra", typeof(decimal)).DefaultValue = 0; }
                catch { }
                try { ads.Tables[0].Columns.Add("BNTra", typeof(decimal)).DefaultValue = 0; }
                catch { }
                if(chkBHYTTraBnTra.Checked)
                {
                    string s_tu = m_v.StringToDate(txtTN.Text).AddDays(-7).ToString("dd/MM/yyyy");
                    asql = "select a.mabn, b.quyenso, b.sobienlai, sum(c.bhyttra) as bhyttra, sum(c.sotien-c.bhyttra) as bntra";
                    asql += " from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on b.id=c.id ";
                    asql += " where c.idtra<>0";
                    asql += " and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + txtDN.Text + "','dd/mm/yyyy')";
                    asql += " group by a.mabn, b.quyenso, b.sobienlai ";

                    DataSet ads1 = m_v.get_data_mmyy(asql, s_tu.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    if (ads1 != null && ads1.Tables.Count > 0 && ads1.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr2;
                        foreach (DataRow dr in ads1.Tables[0].Rows)
                        {
                            dr2 = m_v.getrowbyid(ads.Tables[0], "mabn='" + dr["mabn"].ToString() + "' and quyenso=" + dr["quyenso"].ToString() + " and sobienlai=" + dr["sobienlai"].ToString());
                            if (dr2 != null)
                            {
                                dr2["BHYTTra"] = dr["bhyttra"].ToString();
                                dr2["BNTra"] = dr["bntra"].ToString();
                            }
                        }
                        ads.AcceptChanges();
                    }
                }
                //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    areport = "v_2007_bkhoantra.rpt";
                    if (rdBC_02.Checked)
                    {
                        areport = "v_2007_bkhoantra_trongngay.rpt";
                    }
                    else
                    if(rdBC_03.Checked)
                    {
                        areport = "v_2007_bkhoantra_khacngay.rpt";
                    }
                if (rdBC_01.Checked && chkBHYTTraBnTra.Checked)
                {
                    areport = "v_2007_bkhoantra_bhyt.rpt";
                    if (System.IO.File.Exists("..//..//..//report//" + areport) == false)
                    {
                        areport = "v_2007_bkhoantra.rpt";
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
                        aghichu = lan.Change_language_MessageText("Từ ngày:")+" " + txtTN.Text.Substring(0, 10) + " "+lan.Change_language_MessageText("Đến ngày:")+" " + txtDN.Text.Substring(0, 10);
                    }

                    if (!System.IO.Directory.Exists("..\\..\\Report_vp\\"))
                    {
                        System.IO.Directory.CreateDirectory("..\\Report_vp\\");
                    }
                    if (System.IO.Directory.Exists("..//..//datareport") == false) System.IO.Directory.CreateDirectory("..//..//datareport");
                    ads.WriteXml("..//..//datareport//v_2007_bkhoantra.xml", XmlWriteMode.WriteSchema);
                    //
                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapphieu.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Bảng kê hoá đơn hoàn trả.",1,chkXem.Checked?true:false);
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
        private void dgSo_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                chkAll_So.Left = dgSo.Left + 6;
            }
            catch
            {
            }
        }

        private void chkAll_User_CheckedChanged(object sender, EventArgs e)
        {
            f_Checkall(dgUser, chkAll_User);
        }

        private void chkAll_Loaibn_CheckedChanged(object sender, EventArgs e)
        {
            f_Checkall(dgLoaibn, chkAll_Loaibn);
        }

        private void chkAll_Loaidv_CheckedChanged(object sender, EventArgs e)
        {
            f_Checkall(dgLoaidv, chkAll_Loaidv);
        }

        private void chkAll_So_CheckedChanged(object sender, EventArgs e)
        {
            f_Checkall(dgSo, chkAll_So);
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
            try
            {
                string aft = "";
                string atmp = txtTimso.Text;
                if (atmp.ToLower().Trim() != 
lan.Change_language_MessageText("tìm nhanh") && atmp.ToLower().Trim() != "")
                {
                    aft = "sohieu like '%" + atmp + "%' or sohieubl like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgSo.DataSource, dgSo.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void dgSo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    f_Check(dgSo, dgSo[7, e.RowIndex].Value.ToString(), (dgSo[0, e.RowIndex].Value.ToString() == "1" ? 0 : 1));
                }
            }
            catch
            {
            }
        }

        private void dgLoaibn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    f_Check(dgLoaibn, dgLoaibn[2, e.RowIndex].Value.ToString(), (dgLoaibn[0, e.RowIndex].Value.ToString() == "1" ? 0 : 1));
                }
            }
            catch
            {
            }
        }

        private void dgLoaidv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    f_Check(dgLoaidv, dgLoaidv[2, e.RowIndex].Value.ToString(), (dgLoaidv[0, e.RowIndex].Value.ToString() == "1" ? 0 : 1));
                }
            }
            catch
            {
            }
        }

        
        private void frmBKHoantra_FormClosing(object sender, FormClosingEventArgs e)
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

        private void chkTTRV_CheckedChanged(object sender, EventArgs e)
        {
            chkBHYTTraBnTra.Enabled = chkTTRV.Checked;
            if (chkTTRV.Checked == false) chkBHYTTraBnTra.Checked = false;
        }
    }
}