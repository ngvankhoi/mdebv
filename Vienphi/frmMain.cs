using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmMain : Form
    {
        private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_userid = "", m_ngay10 = "", m_ngay16 = "";        
        private int ichinhanh = 0;
        private bool bCncenter = true;
        private DataSet dscbchinhanh;
        private LibVP.AccessData m_v;
        private bool bAdmin = false;
        private string __userid = "";
        private string __ngaylv = "";
        private string __ngaysl = "";
        public ProgressBar ProgressBar { get { return Main_progressBar; } }
        public frmMain(string v_userid, string v_ngaylv, string v_ngaysl)
        {
            __userid = v_userid;
            __ngaylv = v_ngaylv;
            __ngaysl = v_ngaysl;
            InitializeComponent();
            lan.Read_MainMenu_to_Xml(this.Name.ToString() + "menuStrip1", this.menuStrip1);
            lan.Change_mainmenu_to_English(this.Name.ToString() + "menuStrip1", this.menuStrip1);
            //
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = new LibVP.AccessData();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            int i = m_v.check_process("Vienphi"), iProcess = int.Parse(m_v.sys_sokichhoat);
            if (i > iProcess)
            {
                MessageBox.Show(this,"Số chương trình kích hoạt : " + i.ToString() + " nhiều hơn cho phép :" + iProcess.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Application.Exit();
            }
            this.Text = this.Text + " - Version: " + ProductVersion;
            if (m_v.i_Chinhanh_hientai > 0) this.Text += " - CN: " + m_v.i_Chinhanh_hientai;

            //tan_start:18/10/2013
            if (__userid != "")
            {
                f_LoginFull();
            }

            if (m_userid == "")
            {
                f_Login(true);
            }
            //tan_end:18/10/2013

            //thang 070511
            string sql = "";
            sql = "SELECT relname FROM pg_class  WHERE relname = 'v_dmloaibc'";
            DataSet lds = m_v.get_data(sql);
            if (lds == null || lds.Tables[0].Rows.Count == 0)
            {
                sql = "create table medibv.v_dmloaibc (id serial,maloai_bc numeric default 0,tenloaibc varchar(100), primary key (id) )";
                m_v.execute_data(sql);
                sql = ",Bó bột,SĐ Kế hoạch";
                string[] arr_string = sql.Split(',');
                for (int i1 = 0; i1 < arr_string.Length; i1++)
                {
                    m_v.execute_data("insert into medibv.v_dmloaibc(maloai_bc,tenloaibc) values(" + i1.ToString() + ",'" + arr_string[i1].ToString() + "')");
                }
            }
            if (m_v.bhyt_thuBHYT_tructiep(m_userid))
            {
                toolStripMenuItem18.Text = "&2. Thu viện phí";
            }
            else
            {
                toolStripMenuItem18.Text="&2. Thu viện phí BHYT Ngoại trú";
            }


        }

        private void f_load_chinhanh()
        {
            string sql1 = "";
            try
            {
                sql1 = " select id,ten,ip,trungtam,database from medibv.dmchinhanh where  trim(coalesce(ip,''))<>'' and trim(coalesce(database,''))<>'' and id=" + ichinhanh + " order by ten";
                dscbchinhanh = m_v.get_data(sql1);
            }
            catch
            {

            }
        }
        //Thuy_start:18/10/2013
        private void f_LoginFull()
        {
            try
            {
                m_userid = __userid;
                m_ngay10 = __ngaylv.Substring(0, 10);
                m_ngay16 = __ngaysl;
                //ichinhanh = af.i_chinhanh;
                if (m_v.bQuanly_Theo_Chinhanh)
                {
                    f_load_chinhanh();
                    bCncenter = m_v.bServercenter(ichinhanh) || dscbchinhanh.Tables[0].Rows.Count == 0;
                }
                //Kiem tra lai cau truc dau thang' truoc khi su dung
                if (m_v.DateToString("dd/MM/yyyy", m_v.s_server_date).Substring(0, 2) == "01")
                {
                    frmTaosolieuvp f = new frmTaosolieuvp(m_userid);
                    f.TaoSolieu();
                }
                //End kiem tra
                lbHoten.Text = m_v.f_get_v_dlogin(m_userid, "", "", "", "").Tables[0].Rows[0]["hoten"].ToString();
                bAdmin = m_v.f_get_v_dlogin(m_userid, "", "", "", "").Tables[0].Rows[0]["admin"].ToString() == "1";
                menu_C_5_Tamngung.Text = "Log Off " + lbHoten.Text.Trim() + "";
                lbHoten.Text = lan.Change_language_MessageText("Nhân viên:") + " " + lbHoten.Text;
                lbNgaylv.Text = lan.Change_language_MessageText("Ngày làm việc:") + " " + m_ngay16;
                lbNgay.Text = lan.Change_language_MessageText("Ngày đăng nhập:") + " " + m_v.s_curdd_mm_yyyy_hh24_mi;
                //
                //this.Text = lan.Change_language_MessageText("Quản lý viện phí") + " - CN" + m_v.i_Chinhanh_hientai;
                this.Text = lan.Change_language_MessageText("Quản lý viện phí");// +" - CN" + m_v.i_Chinhanh_hientai;
                //
            }
            catch
            {
                lbHoten.Text = "";
            }
            f_set_right();
        }
        //Thuy_end:18/10/2013
        private void f_Login(bool v_landau)
        {
            try
            {
                frmLogin af = new frmLogin(m_v, v_landau, m_userid);
                af.ShowInTaskbar = false;
                af.TopMost = true;
                DialogResult ars = af.ShowDialog(this);
                if (af.s_userid == "")
                {
                    Application.Exit();
                }
                else
                {
                    if (ars == DialogResult.Yes)
                    {
                        m_userid = af.s_userid;
                        m_ngay10 = af.s_ngay10;
                        m_ngay16 = af.s_ngay16;
                        ichinhanh = af.i_chinhanh;
                    }
                    else
                    {
                        Application.Exit();
                    }
                    //Kiem tra lai cau truc dau thang' truoc khi su dung
                    if (m_v.DateToString("dd/MM/yyyy",m_v.s_server_date).Substring(0, 2) == "01")
                    {
                        frmTaosolieuvp f = new frmTaosolieuvp(af.s_userid);
                        f.TaoSolieu();
                    }
                    //End kiem tra
                }
                lbHoten.Text = m_v.f_get_v_dlogin(m_userid, "", "", "", "").Tables[0].Rows[0]["hoten"].ToString();
                bAdmin = m_v.f_get_v_dlogin(m_userid, "", "", "", "").Tables[0].Rows[0]["admin"].ToString() == "1";
                menu_C_5_Tamngung.Text = "Log Off " + lbHoten.Text.Trim() + "";
                lbHoten.Text = lan.Change_language_MessageText("Nhân viên:")+" " + lbHoten.Text;
                lbNgaylv.Text = lan.Change_language_MessageText("Ngày làm việc:")+" " + m_ngay16;
                lbNgay.Text = lan.Change_language_MessageText("Ngày đăng nhập:")+" " + m_v.s_curdd_mm_yyyy_hh24_mi;
            }
            catch
            {
                lbHoten.Text = "";
            }
            f_set_right();
        }
    
        private void f_Add_Node(TreeNode v_node, ToolStripMenuItem v_item)
        {
            TreeNode anode;
            foreach (ToolStripItem ait in v_item.DropDownItems)
            {
                if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                    anode = new TreeNode(amenu.Text.Replace("&", ""));
                    anode.Tag = amenu.Name;
                    v_node.Nodes.Add(anode);
                    if (amenu.DropDownItems.Count > 0)
                    {
                        f_Add_Node(anode, amenu);
                    }
                }
            }
        }
        private TreeNode f_get_menu()
        {
            TreeNode anode, anode1;
            anode = new TreeNode(lan.Change_language_MessageText("Chức năng"));
            anode.Tag = "1";
            foreach (ToolStripItem ait in menuStrip1.Items)
            {
                if (ait == menu_D_Cuaso) break;
                if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                    anode1 = new TreeNode(amenu.Text.Replace("&", ""));
                    anode1.Tag = amenu.Name;
                    anode.Nodes.Add(anode1);
                    if (amenu.DropDownItems.Count > 0)
                    {
                        f_Add_Node(anode1, amenu);
                    }
                }
            }
            anode.ExpandAll();
            return anode;
        }
        private void f_Set_Node(DataSet v_ds, ToolStripMenuItem v_item)
        {
            foreach (ToolStripItem ait in v_item.DropDownItems)
            {
                if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                    try
                    {
                        amenu.Visible = v_ds.Tables[0].Select("menuname='" + amenu.Name + "'")[0]["chon"].ToString().Trim() == "1";
                    }
                    catch
                    {
                        amenu.Visible = false;
                    }
                    if (amenu.DropDownItems.Count > 0)
                    {
                        amenu.Visible = true;
                        f_Set_Node(v_ds, amenu);
                    }
                }
            }   
        }
        private void f_set_right()
        {
            try
            {
                DataSet ads = m_v.f_get_v_phanquyen(m_userid);
                foreach (ToolStripItem ait in menuStrip1.Items)
                {
                    if (ait == menu_D_Cuaso) break;
                    if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                    {
                        ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                        try
                        {
                            amenu.Enabled = ads.Tables[0].Select("menuname='" + amenu.Name + "'")[0]["chon"].ToString().Trim() == "1";
                        }
                        catch
                        {
                            amenu.Enabled = false;
                        }
                        if (amenu.DropDownItems.Count > 0)
                        {
                            amenu.Enabled = true;
                            f_Set_Node(ads, amenu);
                        }
                    }
                }
                if (m_userid == LibVP.AccessData.s_links_userid)
                {
                    menu_C_4_Quanlynguoidung.Visible = true;
                }
            }
            catch
            {
            }
            menu_C_5_Tamngung.Visible = true;
        }          
        private void f_CloseAll()
        {
            try
            {
                foreach (System.Windows.Forms.Form af in this.MdiChildren)
                {
                    af.Close();
                }
            }
            catch
            {
            }
        }
        private void menu_F_Ketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu_E_2_Vechuongtrinh_Click(object sender, EventArgs e)
        {
            frmAbout af = new frmAbout("Vienphi");
            af.ShowInTaskbar = false;
            af.ShowDialog(this);
        }
        private void menuD_1_1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }
        private void menuD_1_2_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }
        private void menuD_1_3_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }
        private void menuD_1_4_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }
        private void menu_C_Tienich_Click(object sender, EventArgs e)
        {
        }
        private void menu_C_1_Danhmuc_Click(object sender, EventArgs e)
        {
        }
        private void menu_C_1_1_Xetnghiem_Click(object sender, EventArgs e)
        {
            frmGiavp af = new frmGiavp(m_v, m_userid, ichinhanh);
             af.ShowInTaskbar = false;
             af.MdiParent = this;
             af.Show();
        }

        private void menu_C_5_Tamngung_Click(object sender, EventArgs e)
        {
            f_CloseAll();
            f_Login(false);

            if (m_v.bhyt_thuBHYT_tructiep(m_userid))
            {
                toolStripMenuItem18.Text = "&2. Thu viện phí";
            }
            else
            {
                toolStripMenuItem18.Text = "&2. Thu viện phí BHYT Ngoại trú";
            }
        }

        private void menu_C_6_Doimatkhau_Click(object sender, EventArgs e)
        {
            try
            {
                frmDoimatkhau af = new frmDoimatkhau(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog();
            }
            catch
            {
            }
        }

        private void menu_C_7_Loihethong_Click(object sender, EventArgs e)
        {
            try
            {
                frmKetxuatloi af = new frmKetxuatloi(m_v);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menuC_5_QuanlyDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                frmQuanlydatabase af = new frmQuanlydatabase(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_4_Quanlynguoidung_Click(object sender, EventArgs e)
        {
            try
            {
                frmQuanlyuser af = new frmQuanlyuser(m_v, f_get_menu(), m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
                f_set_right();
            }
            catch
            {
            }
        }

        private void menu_C_1_3_Vitrung_Click(object sender, EventArgs e)
        {
            try
            {
                frmDSDuyet af = new frmDSDuyet(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_1_4_Khangsinh_Click(object sender, EventArgs e)
        {
            try
            {
                frmLydomien af = new frmLydomien(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            try
            {
                frmDMLydonopthem af = new frmDMLydonopthem(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                frmLydothieu af = new frmLydothieu(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_1_5_Loaibn_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoaibn af = new frmLoaibn(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_1_6_Tenloaivp_Click(object sender, EventArgs e)
        {
            try
            {
                frmTenloaivp af = new frmTenloaivp(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_2_3_Viettat_Click(object sender, EventArgs e)
        {
            try
            {
                frmViettat af = new frmViettat(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_1_2_Nhombhyt_Click(object sender, EventArgs e)
        {
            try
            {
                frmNhombhyt af = new frmNhombhyt(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_1_3_Nhomvp_Click(object sender, EventArgs e)
        {
            try
            {
                frmNhomvp af = new frmNhomvp(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menuC_1_3_Loaivp_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoaivp af = new frmLoaivp(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_1_1_Phannhomduoc_Click(object sender, EventArgs e)
        {
            try
            {
                
                frmPhannhomduoc af = new frmPhannhomduoc(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_2_1_Khaibaoso_Click(object sender, EventArgs e)
        {
            try
            {
                frmQuyenso af = new frmQuyenso(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_C_2_Capnhatgia_Click(object sender, EventArgs e)
        {
            try
            {
                frmCapnhatgiavp af = new frmCapnhatgiavp(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_A_1_Laymau_Click(object sender, EventArgs e)
        {
            try
            {   
                frmChonso af0 = new frmChonso(m_v, m_userid,"0",m_ngay10);
                af0.ShowInTaskbar = false;
                af0.Text = lan.Change_language_MessageText("THU VIỆN PHÍ TRỰC TIẾP");
                if ((af0.ShowDialog() == DialogResult.OK) && (af0.s_quyenso != "") && (af0.s_loaidv != ""))
                {
                    f_createview_thuvp(m_v.mmyy(af0.s_ngay));
                    if (m_v.tt_Thutheonamhinh(m_userid))
                    {
                        frmThutructiep_new af = new frmThutructiep_new(m_v, m_userid);
                        af.ShowInTaskbar = false;
                        af.MdiParent = this;
                        af.WindowState = FormWindowState.Maximized;                        
                        af.s_loaidv = af0.s_loaidv;
                        af.s_quyenso = af0.s_quyenso;
                        af.s_quyenso_dichvu = af0.s_quyenso_dichvu;
                        af.s_ngay = af0.s_ngay;
                        af.Show();
                    }
                    else
                    {
                        frmThutructiep af = new frmThutructiep(m_v, m_userid);
                        //frmThutructiep_touchfing af = new frmThutructiep_touchfing(m_v, m_userid);
                        af.ShowInTaskbar = false;
                        af.MdiParent = this;
                        af.WindowState = FormWindowState.Maximized;
                        af.s_loaidv = af0.s_loaidv;
                        af.s_quyenso = af0.s_quyenso;
                        af.s_quyenso_dichvu = af0.s_quyenso_dichvu;
                        af.s_ngay = af0.s_ngay;
                        af.Show();
                    }
                }
            }
            catch
            {
            }
        }

        private void menu_A_2_Phieuxetnghiem_Click(object sender, EventArgs e)
        {
            try
            {
                frmChonso af0 = new frmChonso(m_v, m_userid, "3", m_ngay10);
                af0.ShowInTaskbar = false;
                af0.Text = lan.Change_language_MessageText("THU TIỀN TẠM ỨNG");
                if (af0.ShowDialog() == DialogResult.OK)
                {
                    f_createview_thuvp(m_v.mmyy(af0.s_ngay));
                    frmThutamung af = new frmThutamung(m_v, m_userid);
                    af.ShowInTaskbar = false;
                    af.MdiParent = this;
                    af.s_loaidv = af0.s_loaidv;
                    af.s_quyenso = af0.s_quyenso;
                    af.s_ngay = af0.s_ngay;
                    af.WindowState = FormWindowState.Maximized;
                    af.Show();
                }
            }
            catch
            {
            }
        }

        private void menu_A_3_Khangsinhdo_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_v.ttrv_Quanlythathu(m_userid))
                {
                    frmChonso af0 = new frmChonso(m_v, m_userid, "1",m_ngay10);
                    af0.ShowInTaskbar = false;
                    af0.Text = lan.Change_language_MessageText("THU - CHI THANH TOÁN RA VIỆN");
                    if (af0.ShowDialog() == DialogResult.OK && af0.s_quyenso != "")
                    {
                        f_createview_thuvp(m_v.mmyy(af0.s_ngay));
                        frmThuchiravien af = new frmThuchiravien(m_v, m_userid);
                        af.ShowInTaskbar = false;
                        af.MdiParent = this;
                        af.s_loaidv = af0.s_loaidv;
                        af.s_quyenso = af0.s_quyenso;
                        af.s_quyenso_thatthu = af0.s_quyenso_thatthu;
                        af.s_quyenso_thua = af0.s_quyenso_thua;
                        af.s_quyenso_dichvu = af0.s_quyenso_dichvu;
                        af.s_ngay = af0.s_ngay;
                        af.WindowState = FormWindowState.Maximized;
                        af.Show();
                    }
                }
                else
                {
                    frmChonso af0 = new frmChonso(m_v, m_userid,"1",m_ngay10);
                    af0.ShowInTaskbar = false;
                    af0.Text = lan.Change_language_MessageText("THU - CHI THANH TOÁN RA VIỆN");
                    if (af0.ShowDialog() == DialogResult.OK && af0.s_quyenso != "")
                    {
                        f_createview_thuvp(m_v.mmyy(af0.s_ngay));
                        frmThuchiravien af = new frmThuchiravien(m_v, m_userid);
                        af.ShowInTaskbar = false;
                        af.MdiParent = this;
                        af.s_loaidv = af0.s_loaidv;
                        af.s_quyenso = af0.s_quyenso;
                        af.s_quyenso_dichvu = af0.s_quyenso_dichvu;
                        af.s_ngay = af0.s_ngay;
                        af.WindowState = FormWindowState.Maximized;
                        af.Show();
                    }
                }
            }
            catch
            {
            }
        }

        private void menu_B_1_Danhsachbenhnhan_Click(object sender, EventArgs e)
        {
            try
            {
                frmBKThutructiep af = new frmBKThutructiep(m_v,m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.WindowState = FormWindowState.Maximized;
                af.Show();
            }
            catch
            {
            }
        }
        private void menu_B_2_Baocaotieuban_Click(object sender, EventArgs e)
        {
            try
            {
                frmBKThutamung af = new frmBKThutamung(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.WindowState = FormWindowState.Maximized;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_B_3_Hoachatxetnghiem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBKThuchiravien af = new frmBKThuchiravien(m_v, m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.WindowState = FormWindowState.Maximized;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_B_5_Baocaotonghop_Click(object sender, EventArgs e)
        {
            try
            {
                frmBKHoantra af = new frmBKHoantra(m_v,m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.WindowState = FormWindowState.Maximized;
                af.Show();
            }
            catch
            {
            }
        }

        private void menu_B_6_BocaoBYT_Click(object sender, EventArgs e)
        {
            try
            {
               // frmBaocaothutructiep af = new frmBaocaothutructiep(m_userid);
                frmBCthutructiep af = new frmBCthutructiep(m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaocaothutamung af = new frmBaocaothutamung(m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaocaothanhtoanravien af = new frmBaocaothanhtoanravien(m_userid);
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                frmTokhainopthue af = new frmTokhainopthue(m_userid.ToString());
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaocaochitiet f = new frmBaocaochitiet(m_userid.ToString());
                f.MdiParent = this;
                f.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                DLLBCTonghop.frmQuanlybenhvien af = new DLLBCTonghop.frmQuanlybenhvien("vp_treemenu");
                af.ShowInTaskbar = false;
                af.MdiParent = this;
                af.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmBaocaosobienlai f = new frmBaocaosobienlai(m_userid.ToString());
                f.MdiParent = this;
                f.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem12_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmBaocaomien af = new frmBaocaomien(m_userid.ToString());
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaocaotreem af = new frmBaocaotreem(m_userid.ToString());
                af.MdiParent = this;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaocaochiphichuathanhtoan f = new frmBaocaochiphichuathanhtoan(m_userid.ToString());
                f.MdiParent = this;
                f.Show();
            }
            catch
            {
            }
        }

   

        private void menu_B_4_BaocaoASTS_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaocaotonghop f = new frmBaocaotonghop(m_userid.ToString());
                f.MdiParent = this;
                f.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimhoadon f = new frmTimhoadon(m_v,m_userid.ToString());
                f.MdiParent = this;
                f.ShowInTaskbar = false;
                f.s_is_sub = false;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            catch
            {
            }
        }

        private void menu_A_4_Timbenhnhan_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimbenhnhan f = new frmTimbenhnhan(m_v, m_userid.ToString());
                f.MdiParent = this;
                f.ShowInTaskbar = false;
                f.s_is_sub = false;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                frmHoantra f = new frmHoantra(m_v, m_userid.ToString());
                f.MdiParent = this;
                f.ShowInTaskbar = false;
                f.s_is_sub = false;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            catch
            {
            }
        }

        private void menu_C_3_Cauhinhhethong_Click(object sender, EventArgs e)
        {
              frmSystem f = new frmSystem(m_v, m_userid.ToString());
              f.MdiParent = this;
              f.ShowInTaskbar = false;               
              f.Show();
        }

        private void menu_C_3_Giamsat_Click(object sender, EventArgs e)
        {

        }

        private void menu_C_3_Tuychon_Click(object sender, EventArgs e)
        {
            try
            {
               frmOption f = new frmOption(m_v, m_userid.ToString());
               f.MdiParent = this;
               f.ShowInTaskbar = false;
               f.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                frmSuahoadon f = new frmSuahoadon(m_v, m_userid.ToString());
                f.MdiParent = this;
                f.ShowInTaskbar = false;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                frmChonso af0 = new frmChonso(m_v, m_userid, "4", m_ngay10);
                af0.ShowInTaskbar = false;
                af0.Text =lan.Change_language_MessageText("THU VIỆN PHÍ TRỌN GÓI");
                if (af0.ShowDialog() == DialogResult.OK && af0.s_quyenso != "")
                {
                    frmThutrongoi af = new frmThutrongoi(m_v, m_userid);
                    af.ShowInTaskbar = false;
                    af.MdiParent = this;
                    af.s_loaidv = af0.s_loaidv;
                    af.s_quyenso = af0.s_quyenso;
                    af.s_ngay = af0.s_ngay;
                    af.WindowState = FormWindowState.Maximized;
                    af.Show();
                }
            }
            catch
            {
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            try
            {
                frmSolien f = new frmSolien(m_v, m_userid.ToString());
                f.MdiParent = this;
                f.ShowInTaskbar = false;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            try
            {
                frmChonso af0 = new frmChonso(m_v, m_userid, "5", m_ngay10);
                af0.ShowInTaskbar = false;
                af0.Text = lan.Change_language_MessageText("LẬP PHIẾU CHI");
                if (af0.ShowDialog() == DialogResult.OK && af0.s_quyenso != "")
                {
                    frmPhieuchi af = new frmPhieuchi(m_v, m_userid);
                    af.ShowInTaskbar = false;
                    af.MdiParent = this;
                    af.s_loaidv = af0.s_loaidv;
                    af.s_quyenso = af0.s_quyenso;
                    af.s_ngay = af0.s_ngay;
                    af.WindowState = FormWindowState.Maximized;
                    af.Show();
                }
            }
            catch
            {
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            try
            {
                frmChonso af0 = new frmChonso(m_v, m_userid, "2", m_ngay10);
                af0.ShowInTaskbar = false;
                af0.Text = lan.Change_language_MessageText("VIỆN PHÍ BHYT NGOẠI TRÚ");
                if (af0.ShowDialog() == DialogResult.OK && af0.s_quyenso != "")
                {
                    //if (m_v.bhyt_thuBHYT_tructiep(m_userid) == false)
                    //{
                        f_createview_thuvp(m_v.mmyy(af0.s_ngay));
                        frmVienphiBHYT af = new frmVienphiBHYT(m_v, m_userid);
                        af.ShowInTaskbar = false;
                        af.MdiParent = this;
                        af.s_loaidv = af0.s_loaidv;
                        af.s_quyenso = af0.s_quyenso;
                        af.s_quyenso_dichvu = af0.s_quyenso_dichvu;
                        af.s_ngay = af0.s_ngay;
                        af.WindowState = FormWindowState.Maximized;
                        af.Show();
                    //}
                    //else
                    //{
                    //    f_createview_thuvp(m_v.mmyy(af0.s_ngay));
                    //    frmVienphiBHYT_hepa af = new frmVienphiBHYT_hepa(m_v, m_userid);
                    //    af.ShowInTaskbar = false;
                    //    af.MdiParent = this;
                    //    af.s_loaidv = af0.s_loaidv;
                    //    af.s_quyenso = af0.s_quyenso;
                    //    af.s_quyenso_dichvu = af0.s_quyenso_dichvu;
                    //    af.s_ngay = af0.s_ngay;
                    //    af.WindowState = FormWindowState.Maximized;
                    //    af.Show();
                    //}
                }
            }
            catch
            {
            }
        }

        private void menu_C_2_Khaibaosudung_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
           
            try
            {               
                frmEvent_new f = new frmEvent_new(m_v);
                f.MdiParent = this;
                f.ShowInTaskbar = false;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            catch
            {
            }
        }

        private void menuD_1_5_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr) chform.Close();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            try
            {
                frmInchiphitonghop af = new frmInchiphitonghop(m_userid,false);
                af.MdiParent = this;
                af.ShowInTaskbar = false;            
                af.Show();                
            }
            catch
            {
            }
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            try
            {
                frmSuahc af = new frmSuahc(m_v, "",-int.Parse(m_userid), false, "");
                af.MdiParent = this;
                af.ShowInTaskbar = false;
                af.Show();
            }
            catch
            { 
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
        
        }

        private void menu_E_1_Huongdan_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmTaosolieuvp af = new frmTaosolieuvp(m_userid);
                af.MdiParent = this;
                af.ShowInTaskbar = false;
                af.Show();
            }
            catch
            {
            }
        }

        private void khaiBáoMẫuBáoCáoTheoBệnhViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmKhaibaomaubaocao af = new frmKhaibaomaubaocao(m_userid);
                af.MdiParent = this;
                af.ShowInTaskbar = false;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            try
            {
                frmChitietmiengiam af = new frmChitietmiengiam(m_userid);
                af.MdiParent = this;
                af.ShowInTaskbar = false;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            try
            {
               // frmBCthutructiep af = new frmBCthutructiep(m_userid);
                frmBCtamung af = new frmBCtamung(m_userid);
                af.MdiParent = this;
                af.ShowInTaskbar = false;
                af.Show();
            }
            catch
            {
            }
        }

        private void toolStripMenuItem23_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmMiendoituong af = new frmMiendoituong(m_userid);
                af.MdiParent = this;
                af.ShowInTaskbar = false;
                af.Show();
            }
            catch
            { 
            }
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            frmDoanhthu_domedic af = new frmDoanhthu_domedic(m_v);
            af.MdiParent = this;
            af.ShowInTaskbar = false;
            af.Show();
        }

        private void ToolStripMenuItem_nhomtrongoi_Click(object sender, EventArgs e)
        {
            frmNhomtrongoi af = new frmNhomtrongoi(m_v);
            af.MdiParent = this;
            af.ShowInTaskbar = false;
            af.Show();
        }

        private void ToolStripMenuItem_trongoitheogia_Click(object sender, EventArgs e)
        {
            frmGiatrongoinhom af = new frmGiatrongoinhom(m_v, m_userid);
            af.MdiParent = this;
            af.ShowInTaskbar = false;
            af.Show();
        }

        private void sửaĐốiTượngTạmỨngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuadoituongtamung af = new frmSuadoituongtamung(m_v);
            af.MdiParent = this;
            af.ShowInTaskbar = false;
            af.Show();
        }

        private void cậpNhậtTồnKhoTủTrựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHieuchinh_Stt_tonkho f = new frmHieuchinh_Stt_tonkho(m_v);
            f.ShowDialog();
        }

        private void f_createview_thuvp(string mmyy)
        {

            string suser = m_v.user;
            string xxx = suser + mmyy;
            string asql = "create or replace view " + suser + ".vv_bienlaithuvienphi_" + m_v.get_dmcomputer().ToString().PadLeft(4, '0') + " as ";
            asql += " select distinct quyenso, sobienlai from " + xxx + ".v_vienphill ";
            asql += " union all ";
            asql += " select distinct quyenso, sobienlai from " + xxx + ".v_ttrvll ";
            asql += " union all ";
            asql += " select distinct quyenso, sobienlai from " + xxx + ".v_tamung ";
            m_v.execute_data(asql);
        }

        private void menu_C_1_7_giavpdasua_Click(object sender, EventArgs e)
        {
            frmGiavp_luu af = new frmGiavp_luu(m_v, m_userid);
            af.ShowInTaskbar = false;
            af.MdiParent = this;
            af.Show();
        }

        private void mnuTheodoitomtamung_Click(object sender, EventArgs e)
        {
            frmDanhsachtontamung af = new frmDanhsachtontamung(m_v, m_userid);
            af.ShowInTaskbar = false;
            af.MdiParent = this;
            af.Show();
        }

        private void mnukhaibaodotkhuyenmai_Click(object sender, EventArgs e)
        {
            frmDotKhuyenMai af = new frmDotKhuyenMai(m_v, m_userid);
            af.ShowInTaskbar = false;
            af.MdiParent = this;
            af.Show();
        }

        private void mnuKhaibaogiakhuyenmai_Click(object sender, EventArgs e)
        {
            frmGiavpKhuyenMai af = new frmGiavpKhuyenMai(m_v, m_userid);
            af.ShowInTaskbar = false;
            af.MdiParent = this;
            af.Show();
        }

        private void mnNhommiengiam_Click(object sender, EventArgs e)
        {
            frmDmnhommien af = new frmDmnhommien();
            af.ShowInTaskbar = false;
            af.MdiParent = this;
            af.Show();
        }

        private void nmTylekmnhommien_Click(object sender, EventArgs e)
        {
            frmGiavpKhuyenmai_nhommien af = new frmGiavpKhuyenmai_nhommien(m_v, int.Parse(m_userid));
            af.ShowInTaskbar = false;
            af.MdiParent = this;
            af.Show();
        }

        private void mn_giavp_thoigian_Click(object sender, EventArgs e)
        {
            frmKhaibaogiavp_thoigian af = new frmKhaibaogiavp_thoigian(m_v, m_userid);
            af.ShowInTaskbar = false;
            af.MdiParent = this;
            af.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void duyệtHóaĐơnĐỏToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmInchiphitonghop af = new frmInchiphitonghop(m_userid,true);
                af.MdiParent = this;
                af.ShowInTaskbar = false;
                af.Show();
            }
            catch
            {
            }
        }

        private void tmnBKhoadontaichinh_Click(object sender, EventArgs e)
        {
            frmBKhoadontaichinh af = new frmBKhoadontaichinh(m_v, m_userid);
            af.MdiParent = this;
            af.ShowInTaskbar = false;
            af.Show();
        }

        private void mnuDuyetdonBHYT_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmDuyetbhyt")) return;
            int d_userid = int.Parse(m_userid) * -1;
            intsert_uservp_duoc(int.Parse(m_userid));
            LibDuoc.AccessData d=new LibDuoc.AccessData();
            DataTable dtdon=new DataTable();
            int i_nhomkho=m_v.nhom_duoc;
            frmChonkho f=new frmChonkho(d,i_nhomkho,m_v.mmyy(m_v.ngayhienhanh_server.Substring(0,10)));
            f.ShowDialog();
            if (f.i_makho > 0)
            {
                frmDuyetbhyt f1 = new frmDuyetbhyt(d, i_nhomkho, f.i_makho.ToString(), "", f.s_ngay, d_userid, f.mmyy, true, 1, 3, true, "", true, 0);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void mnuDuyetdonBanle_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmXuatban")) return;
            LibDuoc.AccessData d = new LibDuoc.AccessData();
            intsert_uservp_duoc(int.Parse(m_userid));
            int d_userid = int.Parse(m_userid) * -1;
            int i_loai = 7;
            int i_nhomkho = m_v.nhom_nhathuoc;
            string s_ngay = m_v.Ngaygio_hienhanh.Substring(0, 10), s_kho = d.get_dmkho(i_loai), s_loaint = "";
            string s_mmyy = m_v.mmyy(s_ngay);
            
            frmChonkhoxb f = new frmChonkhoxb(d, i_nhomkho, s_kho, s_kho + ",", s_mmyy, s_ngay, "Quầy", true, s_loaint);
            f.ShowDialog(this);
            if (f.i_makho > 0)
            {
                frmDuyetdon f1 = new frmDuyetdon(d, i_nhomkho, s_kho, s_ngay, d_userid, s_mmyy, f.i_quaythu, s_kho, "", m_userid, "", "");
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void intsert_uservp_duoc(int v_userid)
        {
            int i_nhomkho = m_v.nhom_duoc;

            string sql = "select id from medibv.d_dlogin where id=-" + v_userid;
            if (m_v.get_data(sql).Tables[0].Rows.Count <= 0)
            {
                sql = "select id, userid, hoten, password_, chinhanh from medibv.v_dlogin where id=" + v_userid;
                DataSet lds = m_v.get_data(sql);
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    sql = "insert into medibv.d_dlogin (id, userid, hoten, nhomkho, password_, chinhanh) values (-" + v_userid + ",'" + lds.Tables[0].Rows[0]["userid"].ToString() + "','" + lds.Tables[0].Rows[0]["hoten"].ToString() + "'," + i_nhomkho + ",'" + lds.Tables[0].Rows[0]["password_"].ToString() + "'," + lds.Tables[0].Rows[0]["chinhanh"].ToString() + ")";
                    m_v.execute_data(sql);
                }
            }
        }

        private bool IsLoaded(string frm)
        {
            Form[] afrm = this.MdiChildren;
            foreach (Form f in afrm)
            {
                if (f.Name.Equals(frm)) { f.Activate(); return true; }
            }
            return false;
        }

        private void tmn_danhsachmau38_Click(object sender, EventArgs e)
        {
            frmDanhsachinmau38 f = new frmDanhsachinmau38(m_v, m_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void nmGiagiuongBHYT_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmGiagiuongBHYT")) return;
            frmGiagiuongBHYT f = new frmGiagiuongBHYT(m_v, int.Parse(m_userid));
            f.MdiParent = this;
            f.Show();
        }

        private void menu_C_10_Chuyensolieu_Click(object sender, EventArgs e)
        {
            frmChuyenDataksk f = new frmChuyenDataksk("");
            f.MdiParent = this;
            f.Show();
        }

        private void mnuKhaiBaoDotApGia_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmKhunggia")) return;
            frmKhunggia f = new frmKhunggia(m_v, int.Parse(m_userid));
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmDuyetcls f = new frmDuyetcls(m_v, int.Parse(m_userid));
            f.MdiParent = this;
            f.Show();
        }

        private void menu_A_Xetnghiem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
   }
}