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
    public partial class frmBCtamung : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_userid = "";
    
        private string m_field_dt = "";
        private DataSet m_ds2 = new DataSet();
        private DataSet m_dsdt = new DataSet();
        private LibVP.AccessData m_v = new LibVP.AccessData();

        public frmBCtamung(string v_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_userid = v_userid;
        }

        private void frmBCtamung_Load(object sender, EventArgs e)
        {
            f_Load_Tree_Field();
            f_Load_Tree_Khoa();
            f_Load_Tree_Doituong();
            f_Load_Tree_UserID();
            f_Load_Tree_Quyenso();
            f_Load_tree_LoaiDV();
            f_Load_tree_LoaiBN();
        }
        private void f_Load_Tree_UserID()
        {
            try
            {
                string aexp = "";
                if (txtTimuser.Text.Trim() != lan.Change_language_MessageText("Tìm kiếm") && txtTimuser.Text.Trim() != "")
                {
                    aexp = " upper(hoten) like '%" + txtTimuser.Text.Trim().ToUpper() + "%'";
                }
                if (aexp != "")
                {
                    aexp = " where " + aexp;
                }
                string sql = "select to_char(id) as ma,trim(hoten)||'                    ( '||userid||' )' as ten from medibv.v_dlogin " + aexp + " order by hoten";
                m_v.f_Load_Tree(tree_User, m_v.get_data(sql));
                for (int i = 0; i < tree_User.Nodes.Count; i++)
                {
                    if (tree_User.Nodes[i].Tag.ToString() == m_userid)
                    {
                        tree_User.Nodes[i].Checked = true;
                        break;
                    }
                }
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
                if (txtTimso.Text.Trim() != lan.Change_language_MessageText("Tìm kiếm") && txtTimso.Text.Trim() != "")
                {
                    aexp = " and upper(sohieu) like '%" + txtTimso.Text.Trim().ToUpper() + "%'";
                }
                sql = "select id as ma, sohieu as ten from medibv.v_quyenso where 1=1 " + aexp + " order by sohieu asc";
                m_v.f_Load_Tree(tree_Quyenso, m_v.get_data(sql));
            }
            catch
            {
            }
        }
        private void f_Load_Tree_Field()
        {
            try
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("MA");
                ads.Tables[0].Columns.Add("TEN");
                if (rd1.Checked)
                {
                    ads.Tables[0].Rows.Add(new string[] { "MABN", lan.Change_language_MessageText("Mã BN") });
                    ads.Tables[0].Rows.Add(new string[] { "HOTEN", lan.Change_language_MessageText("Họ và tên") });
                    ads.Tables[0].Rows.Add(new string[] { "NAMSINH", lan.Change_language_MessageText("Năm sinh") });
                    ads.Tables[0].Rows.Add(new string[] { "DIACHI", lan.Change_language_MessageText("Địa chỉ") });
                    ads.Tables[0].Rows.Add(new string[] { "CHOLAM", lan.Change_language_MessageText("Chổ làm") });
                    ads.Tables[0].Rows.Add(new string[] { "NGAY", lan.Change_language_MessageText("Ngày thu") });
                    ads.Tables[0].Rows.Add(new string[] { "QUYENSO", lan.Change_language_MessageText("Quyển sổ") });
                    ads.Tables[0].Rows.Add(new string[] { "SOBIENLAI", lan.Change_language_MessageText("Số biên lai") });
                    ads.Tables[0].Rows.Add(new string[] { "SOCHUNGTU", lan.Change_language_MessageText("Số chứng từ") });
                    ads.Tables[0].Rows.Add(new string[] { "SOTIEN", lan.Change_language_MessageText("Số tiền") });
                    ads.Tables[0].Rows.Add(new string[] { "DOITUONG", lan.Change_language_MessageText("Đối tượng") });
                    ads.Tables[0].Rows.Add(new string[] { "KHOA", lan.Change_language_MessageText("Khoa") });
                    ads.Tables[0].Rows.Add(new string[] { "NGUOITHU", lan.Change_language_MessageText("Nhân viên thu ngân") });
                }
                else
                    if (rd2.Checked)
                    {
                        ads.Tables[0].Rows.Add(new string[] { "NGAY", lan.Change_language_MessageText("Ngày thu") });
                        ads.Tables[0].Rows.Add(new string[] { "SOHOADON", lan.Change_language_MessageText("Tổng hoá đơn") });
                        ads.Tables[0].Rows.Add(new string[] { "SOTIEN", lan.Change_language_MessageText("Tổng số tiền") });
                        foreach (DataRow r in m_dsdt.Tables[0].Rows)
                        {
                            ads.Tables[0].Rows.Add(new string[] { "DOITUONG_" + r["ma"].ToString(), lan.Change_language_MessageText("Trong đó:") + " " + r["ten"].ToString() });
                        }
                    }
                    else
                        if (rd3.Checked)
                        {
                            ads.Tables[0].Rows.Add(new string[] { "NGAY", lan.Change_language_MessageText("Mã KP") });
                            ads.Tables[0].Rows.Add(new string[] { "TENKP", lan.Change_language_MessageText("Tên khoa phòng") });
                            ads.Tables[0].Rows.Add(new string[] { "SOHOADON", lan.Change_language_MessageText("Tổng hoá đơn") });
                            ads.Tables[0].Rows.Add(new string[] { "SOTIEN", lan.Change_language_MessageText("Tổng số tiền") });
                            foreach (DataRow r in m_dsdt.Tables[0].Rows)
                            {
                                ads.Tables[0].Rows.Add(new string[] { "DOITUONG_" + r["ma"].ToString(), lan.Change_language_MessageText("Trong đó:") + " " + r["ten"].ToString() });
                            }
                        }
                        else
                            if (rd4.Checked)
                            {
                                ads.Tables[0].Rows.Add(new string[] { "NGAY", lan.Change_language_MessageText("Tên đăng nhập") });
                                ads.Tables[0].Rows.Add(new string[] { "NGUOITHU", lan.Change_language_MessageText("Họ tên nhân viên thu ngân") });
                                ads.Tables[0].Rows.Add(new string[] { "SOHOADON", lan.Change_language_MessageText("Tổng hoá đơn") });
                                ads.Tables[0].Rows.Add(new string[] { "SOTIEN", lan.Change_language_MessageText("Tổng số tiền") });
                                foreach (DataRow r in m_dsdt.Tables[0].Rows)
                                {
                                    ads.Tables[0].Rows.Add(new string[] { lan.Change_language_MessageText("DOITUONG_") + r["ma"].ToString(), lan.Change_language_MessageText("Trong đó:") + " " + r["ten"].ToString() });
                                }
                            }
                m_v.f_Load_Tree(tree_Field, ads);
                m_v.f_Set_CheckID(tree_Field, chkHienthi.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Load_Tree_Khoa()
        {
            try
            {
                string sql = "select to_char(makp) as ma, tenkp as ten from medibv.btdkp_bv where loai= 0 order by tenkp asc";
                m_v.f_Load_Tree(tree_KP, m_v.get_data(sql));
                m_v.f_Set_CheckID(tree_KP, chkAll2.Checked);
            }
            catch
            {
            }
        }
        private void f_Load_Tree_Doituong()
        {
            try
            {
                string sql = "select to_char(madoituong) as ma, doituong as ten from medibv.doituong order by madoituong asc";
                m_dsdt = m_v.get_data(sql);
                m_v.f_Load_Tree(tree_Doituong, m_dsdt);
                m_v.f_Set_CheckID(tree_Doituong, chkDoituong.Checked);
                m_field_dt = "";
                foreach (DataRow r in m_dsdt.Tables[0].Rows)
                {
                    m_field_dt += " ,sum(nvl(to_number(decode(a.madoituong," + r["ma"].ToString() + ",a.sotien,0)),0)) doituong_" + r["ma"].ToString();
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

                m_v.f_Load_Tree(tree_LoaiDV, m_v.get_data("select to_char(ma,'9') as ma, ten from medibv.v_tenloaivp order by ten asc"));
            }
            catch
            {
            }
        }
        private void f_Load_tree_LoaiBN()
        {
            try
            {
                m_v.f_Load_Tree(tree_LoaiBN, m_v.get_data("select to_char(id,'9') ma, ten from medibv.v_loaibn order by id"));
            }
            catch
            {
            }
        }

    }
}