using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmHoantract : Form
    {
        private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_id = "", m_mmyy = "", m_ngayhoan = "", m_userid = "", v_loai = "";
        private AccessData m_v;               
        private int itable, itablect;
        private frmPrintHD frmInhoantra;
        private string m_mabn = "", m_mavaovien = "",m_ngay="";
        private decimal m_congkham = 0;

        private DataSet m_ds = null;
        //public frmHoantract(LibVP.AccessData v_v, string v_userid)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        lan.Read_Language_to_Xml(this.Name.ToString(), this);
        //        lan.Changelanguage_to_English(this.Name.ToString(), this);
        //        lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
        //        lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");                
        //        m_v = v_v;
        //        m_userid = v_userid;
        //    }
        //    catch
        //    {
        //    }
        //}

        public frmHoantract(LibVP.AccessData v_v, string v_userid,string v_mabn, string v_mavaovien,string ngay)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
                lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
                m_v = v_v;
                m_userid = v_userid;
                m_mabn = v_mabn;
                m_mavaovien = v_mavaovien;
                m_ngay = ngay;
            }
            catch
            {
            }
        }
        public string s_ngayhoan
        {
            set
            {
                m_ngayhoan = value;
            }
        }
        public string s_loai
        {
            set
            {
                v_loai = value;
            }
        }
        public string s_id
        {
            set
            {
                m_id = value;
            }
        }
        public string s_mmyy
        {
            set
            {
                m_mmyy = value;
            }
        }
        public string s_ngayhd
        {
            set
            {
                lbNgay.Text = value;
            }
        }
        public string s_kyhieu
        {
            set
            {
                lbKyhieu.Text = value;
            }
        }
        public string s_sobienlai
        {
            set
            {
                lbSobienlai.Text = value;
            }
        }
        public string s_benhnhan
        {
            set
            {
                lbMabn.Text = value;
            }
        }
        public string s_diachi
        {
            set
            {
                lbDiachi.Text = value;
            }
        }
        public string s_nhanvien
        {
            set
            {
                lbNhanvien.Text = value;
            }
        }
        public string s_title_form
        {
            set
            {
                this.Text = value;
            }
        }
        private void frmHoantract_Load(object sender, EventArgs e)
        {
            itable = m_v.tableid(m_v.get_mmyy(m_ngayhoan), "v_hoantra");
            itablect = m_v.tableid(m_v.get_mmyy(m_ngayhoan), "v_hoantract");

            f_Load_DG();
        }
        private void f_Load_DG()
        {
            try
            {
                string sql = "", asqlnt = "";                
                sql = "select to_number(0,'9') as chon, b1.ma,b.idtra,b1.ten,b1.dvt,b.soluong,b.dongia,b.soluong*b.dongia-b.mien-b.thieu as sotien,b.tra, b.id,b.stt,b.mavp, a.mabn,a.hoten,a.mavaovien,a.maql,a.loai,a.loaibn,a.makp,a.quyenso,a.sobienlai,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.idchidinh from medibvmmyy.v_vienphill a left join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_trongoi c on a.id=c.id left join (select id,ma,ten,dvt from medibv.v_giavp  union all select id,ma,ten,dang as dvt from medibv.d_dmbd) b1 on b.mavp=b1.id where c.id is null and a.id=" + m_id;
                asqlnt = "select to_number(0,'9') as chon, b1.ma,c.idtra,case when c.phuthu = 1 then 'Phụ thu '||b1.ten else b1.ten end as ten,b1.dvt,c.soluong,c.dongia,c.soluong*c.dongia as sotien,c.tra, c.id,c.stt,c.mavp, a.mabn,bn.hoten,a.mavaovien,a.maql,b.loai,b.loaibn,b.makp,b.quyenso,b.sobienlai,to_char(b.ngay,'dd/mm/yyyy') as ngay, c.idtonghop as idchidinh from medibv.btdbn bn inner join medibvmmyy.v_ttrvds a  on bn.mabn=a.mabn inner join medibvmmyy.v_ttrvll b on a.id=b.id inner join medibvmmyy.v_ttrvct c on a.id=c.id inner join (select id,ma,ten,dvt from medibv.v_giavp  union all select id,ma,ten,dang as dvt from medibv.d_dmbd) b1 on c.mavp=b1.id where  a.id=" + m_id;
                if (v_loai == "1")
                {
                    m_ds = m_v.get_data_mmyy(m_mmyy, sql);
                }
                else
                {
                    m_ds = m_v.get_data_mmyy(m_mmyy, asqlnt);
                }
                dataGridView1.DataSource = m_ds.Tables[0];
                tmn_Tong.Text = lan.Change_language_MessageText("Tổng số:")+" " + dataGridView1.RowCount.ToString() + " mục";
                dataGridView1.Update();
                butHoan.Enabled = (m_ds.Tables[0].Select("chon = 1 and tra=0").Length > 0 && m_id != "" && m_id != "0");

                frmInhoantra = new frmPrintHD(m_v, m_userid);
            }
            catch
            {
                butHoan.Enabled = false;
                tmn_Tong.Text = "";
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void tmn_Timnhanh_Enter(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.LightYellow;
                if (tmn_Timnhanh.Text.Trim().ToLower() == lan.Change_language_MessageText("Tìm kiếm"))
                {
                    tmn_Timnhanh.Text = "";
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_Leave(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.White;
                if (tmn_Timnhanh.Text.Trim() == "")
                {
                    tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                string atmp = tmn_Timnhanh.Text;
                if (atmp.ToLower().Trim() != lan.Change_language_MessageText("Tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "ma like '%" + atmp + "%' or ten like '%" + atmp + "%' or dvt like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void butHoan_Click(object sender, EventArgs e)
        {
            butHoan.Enabled = false;
            try
            {
                DataRowView arv = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                string aghichu = "", aidht = "", ammyy = "",ammyyhd="";
                if (v_loai == "1")
                {
                    aghichu = "1";// "Thu trực tiếp";
                }
                else
                {
                    aghichu = "3";// "Thu chi ra viện";
                }
                ammyy = m_v.get_mmyy(m_ngayhoan);
                ammyyhd = m_v.get_mmyy(arv["ngay"].ToString());
                string s_amavp = "", s_tenvp = "";
                if (m_ds.Tables[0].Select("chon=1 and tra=0").Length > 0)
                {
                    if (m_v.dahoantra(arv["mabn"].ToString(), arv["mavaovien"].ToString(), arv["maql"].ToString(), arv["quyenso"].ToString(), arv["sobienlai"].ToString(), arv["loai"].ToString(), arv["loaibn"].ToString()))
                    {
                        decimal aconlai = 0;
                        try
                        {
                            aconlai = decimal.Parse(m_v.get_data_mmyy(ammyyhd, "select sum(soluong*dongia-mien-thieu-tra) from medibvmmyy.v_vienphict where id=" + m_id).Tables[0].Rows[0][0].ToString());
                        }
                        catch
                        {
                            aconlai = 0;
                        }
                        if (aconlai <= 0)
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Hoá đơn đã hoàn trả rồi, không được hoàn trả nữa!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    foreach (DataRow r0 in m_ds.Tables[0].Select("chon=1"))
                    {
                        foreach (DataRow r12 in m_v.get_data_mmyy(ammyyhd, "select * from medibvmmyy.v_chidinh a,medibv.v_giavp b where a.mavp=b.id and a.done=1 and a.hide=0 and a.mavp=" + r0["mavp"].ToString() + " and maql=" + arv["maql"].ToString() + " and mabn='" + arv["mabn"].ToString() + "'").Tables[0].Rows)
                        {
                            s_amavp = r0["ten"].ToString();
                            s_tenvp += "- " + s_amavp + "\n";
                        }
                    }
                    if (s_tenvp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Các dịch vụ này bệnh nhân đã làm không hoàn trả được !")+" \n" + s_tenvp + "", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý hoàn trả ") + m_ds.Tables[0].Select("chon=1 and tra=0").Length.ToString() + " "+lan.Change_language_MessageText("mục chọn trong hoá đơn này?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        decimal asotien = 0, atmp = 0;
                        foreach (DataRow r0 in m_ds.Tables[0].Select("chon=1 and tra=0"))
                        {
                            try
                            {
                                atmp = decimal.Parse(r0["sotien"].ToString());
                            }
                            catch
                            {
                                atmp = 0;
                            }
                            asotien += atmp;
                        }
                        if (aidht != "")
                        {
                            string s = m_v.fields("medibv" + ammyy + ".v_hoantra", "id=" + aidht);
                            m_v.upd_eve_tables(ammyy, itable, int.Parse(m_userid), "upd");
                            m_v.upd_eve_upd_del(ammyy, itable, int.Parse(m_userid), "upd", s);
                        }
                        else m_v.upd_eve_tables(ammyy, itable, int.Parse(m_userid), "ins");
                        aidht = m_v.upd_v_hoantra(ammyy, 0, decimal.Parse(arv["quyenso"].ToString()), decimal.Parse(arv["sobienlai"].ToString()), m_ngayhoan, arv["ngay"].ToString().Substring(0, 10), arv["mabn"].ToString().Trim(), decimal.Parse(arv["mavaovien"].ToString()), decimal.Parse(arv["maql"].ToString()), arv["hoten"].ToString().Trim(), arv["makp"].ToString(), asotien, aghichu, decimal.Parse(m_userid), decimal.Parse(arv["loai"].ToString()), decimal.Parse(arv["loaibn"].ToString()));
                        if (aidht != "0")
                        {
                            foreach (DataRow r1 in m_ds.Tables[0].Select("chon=1 and tra=0"))
                            {
                                if (aidht != "")
                                {
                                    m_v.upd_eve_tables(ammyy, itablect, int.Parse(m_userid), "upd");
                                    m_v.upd_eve_upd_del(ammyy, itablect, int.Parse(m_userid), "upd", m_v.fields("medibv" + ammyy + ".v_hoantract", "id=" + aidht));
                                }
                                m_v.upd_v_hoantract(ammyy, decimal.Parse(aidht), decimal.Parse(r1["mavp"].ToString()), decimal.Parse(r1["sotien"].ToString()));
                                if (v_loai == "1")
                                {
                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_vienphict set tra = soluong*dongia-mien-thieu,ngaytra=to_date('" + m_ngayhoan.Substring(0, 10) + "','dd/MM/yyyy'),useridtra=" + m_userid + " where id=" + m_id + " and mavp=" + r1["mavp"].ToString() + " and stt=" + r1["stt"].ToString());
                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_vienphict set idtra = " + aidht + " where id=" + m_id + " and mavp=" + r1["mavp"].ToString() + " and stt=" + r1["stt"].ToString());
                                }
                                else
                                {
                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_ttrvct set tra = soluong*dongia,ngaytra=to_date('" + m_ngayhoan.Substring(0, 10) + "','dd/MM/yyyy') where id=" + m_id + " and mavp=" + r1["mavp"].ToString() + " and stt=" + r1["stt"].ToString());
                                    m_v.execute_data_mmyy(ammyyhd, "update medibvmmyy.v_ttrvct set idtra =" + aidht + " where id=" + m_id + " and mavp=" + r1["mavp"].ToString() + " and stt=" + r1["stt"].ToString());
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn những nội dung cần hoàn trả từ danh sách!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            finally
            {
                f_Load_DG();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() == "1")
                    {
                        m_ds.Tables[0].Rows[e.RowIndex]["chon"] = 0;
                    }
                    else
                    {
                        m_ds.Tables[0].Rows[e.RowIndex]["chon"] = 1;
                    }
                    foreach (DataRow r in m_ds.Tables[0].Select("tra > 0"))
                    {
                        r["chon"] = 0;
                    }
                    m_ds.AcceptChanges();
                    dataGridView1.Update();
                    dataGridView1.Columns["Column3"].ToolTipText = lan.Change_language_MessageText("Đánh dấu những mục cần hoàn:")+" " + m_ds.Tables[0].Select("chon = 1 and tra=0").Length.ToString() + "/" + m_ds.Tables[0].Rows.Count.ToString();
                    butHoan.Enabled = (m_ds.Tables[0].Select("chon = 1 and tra=0").Length > 0 && m_id != "" && m_id != "0");
                }
            }
            catch
            {
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataRowView arv = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
            string m_idtra = arv["idtra"].ToString();

            if (tmn_InChiTietHoaDon1.Checked)
            {
                frmInhoantra.f_Print_PhieuChi_Hoantra_Chitiet(!tmn_xemtruockhiin1.Checked, m_idtra, m_v.get_mmyy(m_ngayhoan));
            }
            else
            {
                frmInhoantra.f_Print_PhieuChi_Hoantra(!tmn_xemtruockhiin1.Checked, m_idtra, m_v.get_mmyy(m_ngayhoan));
            }

        }
    }
}