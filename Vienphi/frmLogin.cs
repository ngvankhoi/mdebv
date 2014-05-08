using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LibVP;
namespace Vienphi
{
    public partial class frmLogin : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_userid = "";
        private string m_userid_off = "";
        private int ichinhanh = 0;
        private bool m_landau = true;
        private AccessData m_v;
        bool bChuaDangKiLicense = false;
        private LibMedi.AccessData m;
    
        public frmLogin(AccessData v_v, bool v_landau, string v_userid_off)
        {
            if (v_landau) this.Size = new System.Drawing.Size(291, 209);
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = v_v;
            m_landau = v_landau;
            m_userid_off = v_userid_off;
            m_v.f_SetEvent(this);
            m_v.f_upd_v_khoaso();
        }
        public string s_userid
        {
            get
            {
                return m_userid;
            }
        }
        public string s_ngay10
        {
            get
            {
                return txtNgay.Text.Substring(0,10);
            }
        }
        public string s_ngay16
        {
            get
            {
                return txtNgay.Text.Substring(0, 16);
            }
        }
        public int i_chinhanh
        {
            get
            {
                return ichinhanh;
            }
        }
        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m_userid = "";
            this.DialogResult = DialogResult.Cancel;
            m_v.Disconnect();
            System.GC.Collect();   
            this.Close();
        }
        private void butDongy_Click(object sender, EventArgs e)
        {
            try
            {          
                if (txtUsername.Text.Trim() == "")
                {
                    txtUsername.Focus();
                    return;
                }
                if (txtPassword.Text.Trim() == "")
                {
                    txtPassword.Focus();
                    return;
                }
                string ddmmyy = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().PadLeft(4, '0').Substring(2);
                if (txtUsername.Text == LibVP.AccessData.s_links_username && txtPassword.Text == LibVP.AccessData.s_links_password.Trim()+ddmmyy)
                {
                    m_userid = LibVP.AccessData.s_links_userid;
                    this.DialogResult = DialogResult.Yes;
                    if (System.IO.Directory.Exists("..\\..\\Datareport") == false) System.IO.Directory.CreateDirectory("..\\..\\Datareport");
                    this.Close();
                }
                else
                {
                    try
                    {
                        //m_userid = m_v.f_get_v_dlogin("", "", "", txtUsername.Text, txtPassword.Text).Tables[0].Rows[0]["id"].ToString();
                        //ichinhanh = int.Parse(m_v.f_get_v_dlogin("", "", "", txtUsername.Text, txtPassword.Text).Tables[0].Rows[0]["chinhanh"].ToString());
                        DataSet dstmp = new DataSet();
                        dstmp = m_v.f_get_v_dlogin("", "", "", txtUsername.Text, txtPassword.Text);
                        if (dstmp.Tables[0].Rows.Count > 0)
                        {
                            m_userid = dstmp.Tables[0].Rows[0]["id"].ToString();
                            ichinhanh = int.Parse(dstmp.Tables[0].Rows[0]["chinhanh"].ToString());
                        }
                        else
                        {
                            m_userid = "";
                            //MessageBox.Show( lan.Change_language_MessageText("Thông tin đăng nhập không hợp lệ!"), lan.Change_language_MessageText(m_v.s_AppName), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                    }
                    if (m_userid != "")
                    {
                        this.DialogResult = DialogResult.Yes;
                        if (System.IO.Directory.Exists("..\\..\\Datareport") == false) System.IO.Directory.CreateDirectory("..\\..\\Datareport");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Thông tin đăng nhập không hợp lệ!"),lan.Change_language_MessageText(m_v.s_AppName), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Focus();
                    }
                }
                //try
                //{
                //    int i = m_v.get_data("select kythuat from medibv.v_giavp limit 1").Tables[0].Rows.Count;
                //}
                //catch
                //{

                //    Cursor = Cursors.WaitCursor;
                //    m_v.modify_tables_vp_mmyy(m_v.get_mmyy(m_v.ngayhienhanh_server));
                //    Cursor = Cursors.Default;
                //}
                //try
                //{
                //    int i = m_v.get_data("select tuyentw,tuyentinh,tuyenhuyen,tuyenxa from medibv.v_giavp limit 1").Tables[0].Rows.Count;
                //}
                //catch
                //{

                //    Cursor = Cursors.WaitCursor;
                //    m_v.modify_tables_vp_mmyy(m_v.get_mmyy(m_v.ngayhienhanh_server));
                //    Cursor = Cursors.Default;
                //}
            }
            catch
            {
                m_userid = "";
                //MessageBox.Show(this, lan.Change_language_MessageText("Thông tin đăng nhập không hợp lệ!"), lan.Change_language_MessageText(m_v.s_AppName), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
            }
            
        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
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
        private void frmLogin_Load(object sender, EventArgs e)
        {
            f_capnhat_db();//
            try
            {
                m = new LibMedi.AccessData();
                groLogin.BringToFront();
                groLicense.Visible = false;
                bool bQuanLyLicense = m.QuanLyLicense;
                if (bQuanLyLicense)
                {
                    m.RegisterDateStart();
                    if (m.DaDangKiLicense == false)
                    {
                        string s_NgayHeThong = m.ngayhienhanh_server;
                        DateTime dtNgayHeThong = m.StringToDate(s_NgayHeThong);
                        string s_NgayBatDau = m.RegisterGetDateStart;
                        DateTime dtNgayBatDau = m.StringToDate(s_NgayBatDau.Substring(0, 10));
                        TimeSpan tp = dtNgayHeThong - dtNgayBatDau;
                        int i_SoNgayConLai = tp.Days;
                        txtKey.Text = Medisoft2009.MACAddress.MedisoftMAC.KeyInfo;
                        groLicense.Visible = true;
                        groLicense.BringToFront();
                        bChuaDangKiLicense = true;
                        if (i_SoNgayConLai <= 30)
                        {
                            lblLicense.Text = "Hệ thống chưa được đăng ký bản quyền sử dụng. " +
                                "Hãy copy key bên dưới gởi cho quản trị hệ thống." +
                                "\nBạn chỉ có " + (30 - i_SoNgayConLai).ToString() + " ngày dùng thử";
                        }
                        else
                        {
                            lblLicense.Text = "Hệ thống chưa được đăng ký bản quyền sử dụng. " +
                                "Hãy copy key bên dưới gởi cho quản trị hệ thống." +
                                "\nBạn đã hết số ngày dùng thử";
                            butTiepTuc.Enabled = false;
                            groLogin.Enabled = false;
                        }
                    }
                    else
                    {
                        groLogin.Enabled = true;
                        bChuaDangKiLicense = false;
                        this.Width = 292;
                        this.Height = 146;
                    }
                }
                else
                {
                    this.Width = 292;
                    this.Height = 146;
                }
                try
                {
                    bool update = m_v.bAutoupdate && m_v.Path_medisoft != "";
                    if (update)
                    {
                        string file = "Vienphi", path = m_v.Path_medisoft + "\\" + file + "\\bin\\debug";
                        if (!m_v.bUpdate(System.IO.Directory.GetCurrentDirectory(), path, file))
                        {
                            m_v.writeXml("thongso", "version", "Version " + m_v.f_modify(m_v.file_exe(path, file)));
                            m_v.writeXml("thongso", "file", file);
                            m_userid_off = "";                            
                            Application.Exit();
                            string filerun = @m_v.path_medisofthis() + "\\version\\bin\\debug\\version.exe";
                            run f = new run(filerun);
                            f.Launch();
                         }
                    }
                }
                catch
                {
                }
                
                if (m_userid_off != "")
                {
                    foreach (DataRow r in m_v.f_get_v_dlogin(m_userid_off, "", "", "", "").Tables[9].Rows)
                    {
                        txtUsername.Text = r["username"].ToString();
                        break;
                    }
                }
            }
            catch
            {
            }
            //if (m_v.get_data("select * from medibv.thongso where id=-2").Tables[0].Rows.Count > 0)
            //    f_Check_License();///Dung license
            //else
            //    f_Uncheck_License();//Khong dung license

        }
        //private void f_EnabledLogin(bool v_bool)
        //{
        //    lbMay.Visible = !v_bool;
        //    txtMay.Visible = !v_bool;
        //    lbLicense.Visible = !v_bool;
        //    txtLicense.Visible = !v_bool;
        //    chkTrial.Visible = !v_bool;

        //    txtUsername.Enabled = v_bool;
        //    txtPassword.Enabled = v_bool;
        //    butDongy.Enabled = v_bool;
        //}
        //private void f_Uncheck_License()
        //{
        //    try
        //    {
        //        f_EnabledLogin(true);
        //        this.Activate();
        //        SendKeys.Send("{Tab}");
        //    }
        //    catch
        //    {
        //    }
        //}
        //private void f_Check_License()
        //{
        //    try
        //    {
        //        txtMay.Text = m_v.s_computer_key;
        //        if (!m_v.is_licensed)
        //        {
        //            f_EnabledLogin(false);
        //            chkTrial.Visible = true;
        //            txtLicense.Focus();
        //        }
        //        else
        //        {
        //            f_EnabledLogin(true);
        //            this.Activate();
        //            txtUsername.Focus();
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        //private void chkTrial_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        f_EnabledLogin(chkTrial.Checked);
        //        if (chkTrial.Checked)
        //        {
        //            txtUsername.Focus();
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        private void chkTrial_KeyDown(object sender, KeyEventArgs e)
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
        private void txtMay_KeyDown(object sender, KeyEventArgs e)
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
        //private void txtLicense_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            txtLicense_Validated(null, null);
        //            if (!txtLicense.Visible)
        //            {
        //                txtUsername.Focus();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        //private void txtLicense_Validated(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!chkTrial.Checked)
        //        {
        //            m_v.set_licensed(txtLicense.Text);
        //            f_Check_License();
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
  

        private void txtNgay_KeyDown(object sender, KeyEventArgs e)
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
        private void f_capnhat_db()
        {
            LibMedi.AccessData m = new LibMedi.AccessData();
            m.f_capnhat_db_danhmuc("Vienphi.exe");
                           
        }
        private void f_capnhat_db__()
        {
            string s_user = m_v.user;
            string asql = "select paid from " + s_user + ".xuatvien where maql=0";
            DataSet lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + s_user + ".xuatvien add paid numeric(1) default 0";
                m_v.execute_data(false, asql);
            }

            asql = "select sothe from " + s_user + ".v_giavp where id=0";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".v_giavp add sothe varchar(100) ";
                m_v.execute_data(false, asql);
            }
            asql = "select sothe from " + s_user + ".d_dmbd where id=0";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".d_dmbd add sothe varchar(100) ";
                m_v.execute_data(false, asql);
            }

            asql = "select bhyt_tt from " + s_user + ".v_giavp where id=0";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".v_giavp add bhyt_tt numeric(5,2) default 0 ";
                m_v.execute_data(false, asql);

                asql = " update " + s_user + ".v_giavp set bhyt_tt=bhyt ";
                m_v.execute_data(false, asql);
            }

            asql = "select iddot from " + s_user + ".v_giavp_khuyenmai where 1=2";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                m_v.execute_data(false, "CREATE table " + s_user + ".v_dot_khuyenmai (id numeric(7), ten text, userid number(7) default 0, tungay timestamp DEFAULT now(), denngay timestamp DEFAULT now(), tugio varchar(5), dengio varchar(5), hide number(1) default 0, ngayud timestamp DEFAULT now(),CONSTRAINT pk_v_dot_khuyenmai PRIMARY KEY (id) USING INDEX TABLESPACE medi_index)");
                m_v.execute_data(false, "CREATE table " + s_user + ".v_giavp_khuyenmai (iddot numeric(7), idvp number(7), tylekhuyenmai numeric(5,2), default 0, sotienkhuyenmai  numeric(15,4), userid number(7) default 0, ngayud timestamp DEFAULT now(),CONSTRAINT pk_v_giavp_khuyenmai PRIMARY KEY (iddot, idvp) USING INDEX TABLESPACE medi_index)");
            }
            asql = "select theogio from " + s_user + ".v_dot_khuyenmai where id=0";
            lds = m_v.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".v_dot_khuyenmai theogio bhyt_tt numeric(1) default 0 ";
                m_v.execute_data(false, asql);
            }
        }

        private void butDangKi_Click(object sender, EventArgs e)
        {
            if (txtLicense.Text.Trim() != "")
            {
                string s_key = Medisoft2009.License.Encryption.DeCode(txtKey.Text, Medisoft2009.License.Encryption.Key);
                if (Medisoft2009.License.Encryption.ValidLicense(s_key, txtLicense.Text))
                {
                    m.ComputerKey = txtKey.Text;
                    m.License = txtLicense.Text;
                    if (!m.RegisterLicense())
                    {
                        MessageBox.Show("Bản quyền sử dụng đăng ký không thành công. Vui lòng kiểm tra lại License", "Medisoft");
                        groLicense.Visible = true;
                        bChuaDangKiLicense = true;
                    }
                    else
                    {
                        MessageBox.Show("Đăng kí thành công!","Medisoft");
                        groLogin.Enabled = true;
                        bChuaDangKiLicense = false;
                        groLicense.Visible = false;
                        this.Width = 292;
                        this.Height = 146;
                    }
                }
                else
                {
                    MessageBox.Show("Bản quyền không hợp lệ. Vui lòng liên hệ với quản trị hệ thống", "Medisoft");
                    txtLicense.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập License", "Medisoft");
            }
        }

        private void butTiepTuc_Click(object sender, EventArgs e)
        {
            groLicense.Visible = false;
            this.Width = 292;
            this.Height = 146;
        }
    }
}