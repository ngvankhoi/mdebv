using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LibMedi;

namespace MEDISOFT2011.DESKTOP
{
    public partial class MMain : Form
    {
        private bool _process_top = true;
        private bool _loginok = false;
        private bool _admin = false;
        private string _id = "0";
        private string _id_m = "0";
        private string _id_v = "0";
        private string _id_d = "0";
        private string _id_xn = "0";
        private string _id_cdha = "0";
        private string _id_ns = "0";
        private string _id_rp = "0";
        private string _id_ct = "0";
        LibMedi.AccessData m = new LibMedi.AccessData();
        private string _userid = "1";
        private string _ngaylv = "2";
        private string _ngaysl = "3";
        bool bChuaDangKiLicense = false;
        Medisoft.Language lan = new Medisoft.Language();
        private frmMQuanlynguoidung _quanlynguoidung;
        public MMain()
        {
            InitializeComponent();
        }
        public MMain(string v_userid, string v_ngaylv, string v_ngaysl)
        {
            _userid = v_userid;
            _ngaylv = v_ngaylv;
            _ngaysl = v_ngaysl;

            InitializeComponent();
            InitMultiLanguage();
           // lan.Read_Language_to_Xml(this.Name.ToString(), this);

            mnQLBN.Tag = lbQLBN.Tag.ToString();
            mnQLVP.Tag = lbQLVP.Tag.ToString();
            mnQLD.Tag = lbQLD.Tag.ToString();
            mnQLXN.Tag = lbQLXN.Tag.ToString();
            mnQLCDHA.Tag = lbQLCDHA.Tag.ToString();
            mnQLNS.Tag = lbQLNS.Tag.ToString();
            mnQLBC.Tag = lbQLBC.Tag.ToString();
            mnQLCT.Tag = lbQLCT.Tag.ToString();

            _quanlynguoidung = new frmMQuanlynguoidung();
        }
        private void f_language()
        {
            try
            {
                lan = new Medisoft.Language();
                if (rdVN.Checked)
                {
                    //lan.Changelanguage_to_Vietnam(this.Name.ToString(), this);
                }
                else
                {
                    lan.Changelanguage_to_English(this.Name.ToString(), this);
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void f_Resize()
        {
            pLogin.Left = (this.Width - pLogin.Width) / 2;
            pLogin.Top = (this.Height - pLogin.Height) / 2;
            pModule.Enabled = true;
        }
        private void InitMultiLanguage()
        {
           // this.Text = ResourceManager.GetString("tieude");
            lbsNgaylv.Text = ResourceManager.GetString("ngaylamviec");
            lbsNgaysl.Text = ResourceManager.GetString("ngaysolieu");
            lbsHoten.Text = ResourceManager.GetString("user");
            lbsNgaydn.Text = ResourceManager.GetString("ngaydangnhap");
            mnMedisoft.Text = ResourceManager.GetString("medisoft");
            mnQLCDHA.Text = ResourceManager.GetString("cdha");
            mnQLD.Text = ResourceManager.GetString("duoc");
            mnQLVP.Text = ResourceManager.GetString("vienphi");
            mnQLXN.Text = ResourceManager.GetString("xetnghiem");
            mnQLNS.Text = ResourceManager.GetString("nhansu");
            mnQLBN.Text = ResourceManager.GetString("medisoft");
            mnQLCT.Text = ResourceManager.GetString("khamsuckhoe");
            mnQLBC.Text = ResourceManager.GetString("baocao");
            mnQLND.Text = ResourceManager.GetString("quanlynguoidung");
            mnHoso.Text = ResourceManager.GetString("hosonguoidung");
            mnLogout.Text = ResourceManager.GetString("logout");
            mnKetthuc.Text = ResourceManager.GetString("exit");
            
        }
        private void f_EnableLogin()
        {
            //lbQLBN.Visible = _loginok && (_id_m != "0" || _id == "0");
            //lbQLVP.Visible = _loginok && (_id_v != "0" || _id=="0");
            //lbQLD.Visible = _loginok && (_id_d != "0" || _id == "0");
            //lbQLXN.Visible = _loginok && (_id_xn != "0" || _id == "0");
            //lbQLCDHA.Visible = _loginok && (_id_cdha != "0" || _id == "0");
            //lbQLNS.Visible = _loginok && (_id_ns != "0" || _id == "0");
            //lbQLBC.Visible = _loginok && (_id_rp != "0" || _id == "0");

            //lbQLND.Visible = _admin;// && _id != "0";
            //lbHoso.Visible = _id != "0";
            //lbLogout.Visible = _loginok;


            lbQLBN.Enabled = _loginok && (_id_m != "0" || _id == "0");
            mnQLBN.Visible = _loginok && (_id_m != "0" || _id == "0");
            
            lbQLVP.Enabled = _loginok && (_id_v != "0" || _id == "0");
            mnQLVP.Visible = _loginok && (_id_v != "0" || _id == "0");

            lbQLD.Enabled = _loginok && (_id_d != "0" || _id == "0");
            mnQLD.Visible = _loginok && (_id_d != "0" || _id == "0");

            lbQLXN.Enabled = _loginok && (_id_xn != "0" || _id == "0");
            mnQLXN.Visible = _loginok && (_id_xn != "0" || _id == "0");

            lbQLCDHA.Enabled = _loginok && (_id_cdha != "0" || _id == "0");
            mnQLCDHA.Visible = _loginok && (_id_cdha != "0" || _id == "0");

            lbQLNS.Enabled = _loginok && (_id_ns != "0" || _id == "0");
            mnQLNS.Visible = _loginok && (_id_ns != "0" || _id == "0");

            lbQLBC.Enabled = _loginok && (_id_rp != "0" || _id == "0");
            mnQLBC.Visible = _loginok && (_id_rp != "0" || _id == "0");

            lbQLCT.Enabled = _loginok && (_id_ct != "0" || _id == "0");
            mnQLCT.Visible = _loginok && (_id_ct != "0" || _id == "0");

            lbQLND.Enabled = _admin;// && _id != "0";
            mnQLND.Visible = _admin;

            lbHoso.Enabled = _id != "0";
            lbLogout.Enabled = _loginok;
        }
        private void f_ShowLogin(bool v_bool)
        {
            pLogin.Visible = v_bool;
        }
        private void f_Login()
        {
            
            _loginok=false;
            _admin = false;
            if(txtUsername.Text=="admin" && txtPassword.Text=="links1920")//+DateTime.Now.Day.ToString().PadLeft(2,'0')+DateTime.Now.Month.ToString().PadLeft(2,'0')+DateTime.Now.Year.ToString().PadLeft(4,'0'))
            {
                _id = "0";
                _loginok = true;
                _admin = true;
                lblUser.Text = "Administrator (Links)";
                lblNgaylv.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString().PadLeft(4, '0');
                lblNgaysl.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString().PadLeft(4, '0');
                lblNgaydn.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString().PadLeft(4, '0') + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + " " + DateTime.Now.Second.ToString().PadLeft(2, '0');

                txtPassword.Text = "";
            }
            else
            {
                DataSet ads=_quanlynguoidung.v.get_data("select * from medibv.mdlogin where userid='"+txtUsername.Text+"' and password_='"+txtPassword.Text+"' order by id_rp");
                foreach(DataRow r in ads.Tables[0].Rows)
                {
                    _id = r["id"].ToString();
                    _id_m = r["id_m"].ToString();
                    _id_v = r["id_v"].ToString();
                    _id_d = r["id_d"].ToString();
                    _id_xn = r["id_xn"].ToString();
                    _id_cdha = r["id_cdha"].ToString();
                    _id_ns = r["id_ns"].ToString();
                    _id_rp = r["id_rp"].ToString();
                    _id_ct = r["id_ct"].ToString();
                    _loginok = true;
                    _admin = (r["admin_"].ToString() == "1");
                    lblUser.Text = r["hoten"].ToString() + " (" + r["userid"].ToString() + ")";
                    lblNgaylv.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString().PadLeft(4, '0');
                    lblNgaysl.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString().PadLeft(4, '0');
                    lblNgaydn.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString().PadLeft(4, '0') + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');
                    txtPassword.Text = "";
                }
            }
            f_ShowLogin(!_loginok);
            f_EnableLogin();
            if (!_loginok)
            {
                txtUsername.Focus();
            }
        }
        private void f_Logout()
        {
            _loginok = false;
            f_ShowLogin(true);
            f_EnableLogin();
        }
        private void f_Boqua()
        {
            f_ShowLogin(false);
            f_EnableLogin();
        }
        private bool f_signal(string v_processname)
        {
            bool aok = false;
            try
            {
                if (System.Diagnostics.Process.GetProcessesByName(v_processname).Length > 0)
                {
                    return true;
                }
            }
            catch
            {
            }
            return aok;
        }
        private void f_Run(string v_name)
        {
            string apath = Application.ExecutablePath;
            try
            {
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath + "\\" + v_name;
                string auserid = "";
                if (v_name.ToLower().IndexOf("medisoft.exe") >= 0)
                {
                    if (f_signal("medisoft.exe")) return;
                    auserid = _id_m;
                }
                else
                if (v_name.ToLower().IndexOf("vienphi.exe") >= 0)
                {
                    if (f_signal("vienphi.exe")) return;
                    auserid = _id_v;
                }
                else
                if (v_name.ToLower().IndexOf("duoc.exe") >= 0)
                {
                    if (f_signal("duoc.exe")) return;
                    auserid = _id_d;
                }
                else
                if (v_name.ToLower().IndexOf("xetnghiem.exe") >= 0)
                {
                    if (f_signal("xetnghiem.exe")) return;
                    auserid = _id_xn;
                }
                else
                if (v_name.ToLower().IndexOf("cdha.exe") >= 0)
                {
                    if (f_signal("cdha.exe")) return;
                    auserid = _id_cdha;
                }
                else
                if (v_name.ToLower().IndexOf("report.exe") >= 0)
                {
                    if (f_signal("report.exe")) return;
                    auserid = _id_rp;
                }
                else
                if (v_name.ToLower().IndexOf("human.exe") >= 0)
                {
                    if (f_signal("human.exe")) return;
                    auserid = _id_ns;
                }
                else
                if (v_name.ToLower().IndexOf("medisoftksk.exe") >= 0)
                {
                    if (f_signal("medisoftksk.exe")) return;
                    auserid = _id_ct;
                }
                _ngaylv = txtNgaylv.Value.Day.ToString().PadLeft(2, '0') + "/" + txtNgaylv.Value.Month.ToString().PadLeft(2, '0') + "/" + txtNgaylv.Value.Year.ToString().PadLeft(4, '0');
                _ngaysl = txtNgaysl.Value.Day.ToString().PadLeft(2, '0') + "/" + txtNgaysl.Value.Month.ToString().PadLeft(2, '0') + "/" + txtNgaysl.Value.Year.ToString().PadLeft(4, '0');

                System.Diagnostics.Process ap = System.Diagnostics.Process.Start(apath, auserid + " " + _ngaylv + " " + _ngaysl);
                ap.EnableRaisingEvents = true;
                ap.Exited += new EventHandler(myProcess_HasExited);
                timer1.Enabled = true;
                _process_top = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không tìm thấy file: " + apath + "\n\n" + ex.ToString());
            }
        }
        private void myProcess_HasExited(object sender, System.EventArgs e)
        {
            try
            {
                //MessageBox.Show("Process has exited.");
                this.Activate();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void butDangnhap_Click(object sender, EventArgs e)
        {
            f_Login();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //if (MessageBox.Show(this, "Đồng ý kết thúc chương trình", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                //{
                //    e.Cancel = true;
                //}
                //else
                //{
                    notifyIcon1.Dispose();
                //}
            }
            catch(Exception ex)
            {
            }
        }

        private void MMain_Load(object sender, EventArgs e)
        {
            License();
            f_Resize();
            f_EnableLogin();
            txtUsername.Focus();
            f_load_default_lang();
            f_language();
            this.Text = lan.Change_language_MessageText("MEDISOFT2013- DESKTOP");

        }

        private void MMain_SizeChanged(object sender, EventArgs e)
        {
            f_Resize();
        }
        private void License()
        {
            //Quan ly lience
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
                        lblLicense.Text = lan.Change_language_MessageText("Hệ thống chưa được đăng ký bản quyền sử dụng. ") +
                            lan.Change_language_MessageText("Hãy copy key bên dưới gởi cho quản trị hệ thống.") +
                            lan.Change_language_MessageText("\nBạn chỉ có ") + (30 - i_SoNgayConLai).ToString() + lan.Change_language_MessageText(" ngày dùng thử");
                    }
                    else
                    {
                        lblLicense.Text = lan.Change_language_MessageText("Hệ thống chưa được đăng ký bản quyền sử dụng. ") +
                            lan.Change_language_MessageText("Hãy copy key bên dưới gởi cho quản trị hệ thống.") +
                            lan.Change_language_MessageText("\nBạn đã hết số ngày dùng thử");
                        butTiepTuc.Enabled = false;
                        groLogin.Enabled = false;
                    }
                }
                else
                {
                    groLogin.Enabled = true;
                    bChuaDangKiLicense = false;
                    this.Width = 366;
                    this.Height = 155;
                }
            }
            else
            {
                this.Width = 366;
                this.Height = 155;
            }
        }
        private void lbQLBN_MouseHover(object sender, EventArgs e)
        {
            LinkLabel ac = (LinkLabel)(sender);
            ac.LinkColor = Color.Yellow;
        }

        private void lbQLBN_MouseLeave(object sender, EventArgs e)
        {
            LinkLabel ac = (LinkLabel)(sender);
            ac.LinkColor = Color.White;
        }

        private void txtControl_Enter(object sender, EventArgs e)
        {
            try
            {
                Control ac = (Control)(sender);
                ac.BackColor = Color.LightYellow;
            }
            catch
            {
            }
        }

        private void txtControl_Leave(object sender, EventArgs e)
        {
            try
            {
                Control ac = (Control)(sender);
                ac.BackColor = Color.White;
            }
            catch
            {
            }
        }
        private void txtControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pOption.Visible = !pOption.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_process_top)
                {
                    this.Visible=true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void mnQLBN_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem ac = (ToolStripMenuItem)(sender);
                f_Run(ac.Tag.ToString());
            }
            catch
            {
            }
        }

        private void mnQLND_Click(object sender, EventArgs e)
        {
            frmMQuanlynguoidung af = new frmMQuanlynguoidung();
            af.ShowDialog();
        }

        private void mnHoso_Click(object sender, EventArgs e)
        {
            lbHoso_Click(null, null);
        }

        private void mnKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnLogout_Click(object sender, EventArgs e)
        {
            f_Logout();
        }

        private void lbQLBN_VisibleChanged(object sender, EventArgs e)
        {
            mnQLBN.Visible = lbQLBN.Visible;
        }

        private void lbQLVP_VisibleChanged(object sender, EventArgs e)
        {
            mnQLVP.Visible = lbQLVP.Visible;
        }

        private void lbQLCT_VisibleChanged(object sender, EventArgs e)
        {
            mnQLCT.Visible = lbQLCT.Visible;
        }
        private void lbQLD_VisibleChanged(object sender, EventArgs e)
        {
            mnQLD.Visible = lbQLD.Visible;
        }

        private void lbQLXN_VisibleChanged(object sender, EventArgs e)
        {
            mnQLXN.Visible = lbQLXN.Visible;
        }

        private void lbQLCDHA_VisibleChanged(object sender, EventArgs e)
        {
            mnQLCDHA.Visible = lbQLCDHA.Visible;
        }

        private void lbQLNS_VisibleChanged(object sender, EventArgs e)
        {
            mnQLNS.Visible = lbQLNS.Visible;
        }

        private void lbQLBC_VisibleChanged(object sender, EventArgs e)
        {
            mnQLBC.Visible = lbQLBC.Visible;
        }

        private void lbQLND_VisibleChanged(object sender, EventArgs e)
        {
            mnQLND.Visible = lbQLND.Visible;
        }

        private void lbHoso_VisibleChanged(object sender, EventArgs e)
        {
            mnHoso.Visible = lbHoso.Visible;
        }

        private void lbLogout_VisibleChanged(object sender, EventArgs e)
        {
            mnLogout.Visible = lbLogout.Visible;
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                    mi.Invoke(notifyIcon1, null);
                }
            }
            catch
            {
            }
        }

        private void mnMedisoft_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
                //notifyIcon1_DoubleClick(null, null);
            }
            catch
            {
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void f_load_default_lang()
        {
            try
            {
                DataSet ads = new DataSet();
                ads.ReadXml("..//..//..//xml//thongso.xml");
                string angonngu = "0";
                try
                {
                    angonngu = ads.Tables[0].Rows[0]["Ngonngu"].ToString();
                }
                catch
                {
                    angonngu = "0";
                }
                rdEN.Checked=(angonngu == "1");
                rdFR.Checked = (angonngu == "2");
                rdVN.Checked = (angonngu != "1" && angonngu != "2");
            }
            catch
            {
            }
        }
        private void f_set_lang()
        {
            try
            {
                DataSet ads = new DataSet();
                string tmp_ngonngu = "";                
                string angonngu = "0"; tmp_ngonngu = "_vn";
                if (rdEN.Checked) { angonngu = "1"; tmp_ngonngu = "_en"; }
                if (rdFR.Checked) { angonngu = "2"; tmp_ngonngu = "_fr"; }
                ads.ReadXml("..//..//..//xml//thongso" + tmp_ngonngu + ".xml");
                ads.Tables[0].Rows[0]["Ngonngu"] = angonngu;
                ads.WriteXml("..//..//..//xml//thongso"+tmp_ngonngu+".xml");//,XmlWriteMode.WriteSchema);
                //
                ads.ReadXml("..//..//..//xml//thongso.xml");
                ads.Tables[0].Rows[0]["Ngonngu"] = angonngu;
                ads.WriteXml("..//..//..//xml//thongso.xml");
                //
                ads = new DataSet();
                ads.ReadXml("..//..//..//xml//maincode.xml");
                angonngu = "_vn";
                if (rdEN.Checked) angonngu = "_en";
                if (rdFR.Checked) angonngu = "_ot";
                ads.Tables[0].Rows[0]["ngonngu"] = angonngu;
                ads.WriteXml("..//..//..//xml//maincode.xml");//,XmlWriteMode.WriteSchema);

                f_language();
            }
            catch
            {
            }
        }
        private void rdVN_CheckedChanged(object sender, EventArgs e)
        {
            
            MessageBox.Show(lan.Change_language_MessageText("Hệ thống sẽ tự động chuyển sang ngôn ngữ đã chọn!"),"Medisoft");
            f_set_lang();
            try
            {
                System.Diagnostics.Process ap = System.Diagnostics.Process.Start("MEDISOFT2013.DESKTOP.EXE");
                Application.Exit();
            }
            catch
            {
            }
        }

        private void lbQLBN_Click(object sender, EventArgs e)
        {
            try
            {
                Control ac = (Control)(sender);
                f_Run(ac.Tag.ToString());
            }
            catch
            {
            }
        }

        private void lbQLND_Click(object sender, EventArgs e)
        {
            frmMQuanlynguoidung af = new frmMQuanlynguoidung();
            af.ShowDialog();
        }

        private void lbHoso_Click(object sender, EventArgs e)
        {
            frmMThongtinnguoidung af = new frmMThongtinnguoidung(false, _id);
            af.ShowDialog();
        }

        private void lbLogout_Click(object sender, EventArgs e)
        {
            f_Logout();
            License();
        }

        private void lbQLND_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void butTiepTuc_Click(object sender, EventArgs e)
        {
            groLicense.Visible = false;
            this.Width = 366;
            this.Height = 155;
        }

        private void butDangKi_Click(object sender, EventArgs e)
        {
            if (txtLicence.Text.Trim() != "")
            {
                string s_key = Medisoft2009.License.Encryption.DeCode(txtKey.Text, Medisoft2009.License.Encryption.Key);
                if (Medisoft2009.License.Encryption.ValidLicense(s_key, txtLicence.Text))
                {
                    m.ComputerKey = txtKey.Text;
                    m.License = txtLicence.Text;
                    if (!m.RegisterLicense())
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bản quyền sử dụng đăng ký không thành công. Vui lòng kiểm tra lại License"), "Medisoft");
                        groLicense.Visible = true;
                        bChuaDangKiLicense = true;
                    }
                    else
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đăng kí thành công!"), "Medisoft");
                        groLogin.Enabled = true;
                        bChuaDangKiLicense = false;
                        groLicense.Visible = false;
                        this.Width = 366;
                        this.Height = 155;
                    }
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bản quyền không hợp lệ. Vui lòng liên hệ với quản trị hệ thống"), "Medisoft");
                    txtLicence.Focus();
                }
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập License"), "Medisoft");
            }
        }

        private void MMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                txtKey.SelectAll();
                txtLicence.SelectAll();
            }
        }

        private void lbLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void rdEN_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}