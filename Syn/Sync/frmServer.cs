using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.Net;
using System.Net.Mail;
using System.Net.Sockets;

namespace Server
{
    public partial class frmServer : Form
    {
        DAL.Client m_server = new DAL.Client();
        DAL.Accessdata m = new DAL.Accessdata();        
        //
        List<DAL.Client> list;
        DataSet dsxml = new DataSet();
        DataSet dsxml_chungtu = new DataSet();
        DataSet dsxml_ksk = new DataSet();
        DataSet dsxml_del = new DataSet();
        DataTable dtmmyy;
        private bool bButketthuc = false;
        string mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
        private int gio, gio_mail, iNgayNhacMail = 2, gio_hinhbn = 1, gio_hinhcdha = 3, gio_hinhchungtu=4;

        private int phut, phut_mail, phut_hinhbn = 0, phut_hinhcdha = 0, phut_hinhchungtu = 0;
        private int auto;
        private int p = 0;
        private int i_khoang_cach_ngay = 3;
        bool bgif = false, bMailTuDong = false, bSynHinhBN = false, bSynHinhCDHA = false, bSynHinhChungTu = false;
        bool bHinhBN_Overwrite = false, bHinhCDHA_OvweWrite = false, bHinhChungTu_Overwrite = false;
        int mailfailed = 0;
        public frmServer()
        {
            InitializeComponent();
            this.Text += " - " + m.Maincode("Ip") + " - " + m.Maincode("Database");
        }
        #region load thông tin máy server trung tâm
        private void load_Server()
        {
            DataTable dtxml = new DataTable("synmaychu");
            if (System.IO.File.Exists("..//..//..//xml//syn_thongso.xml"))
            {
                dtxml.ReadXml("..//..//..//xml//syn_thongso.xml");
                if (dtxml.Rows.Count > 0)
                {
                    m_server.Host = dtxml.Rows[0]["Host"].ToString();
                    m_server.Port = dtxml.Rows[0]["Port"].ToString();
                    m_server.Userdb = dtxml.Rows[0]["User"].ToString();
                    m_server.Passworddb = dtxml.Rows[0]["Password"].ToString();
                    m_server.DatabaseName = dtxml.Rows[0]["Database"].ToString();
                    m_server.ServerName = dtxml.Rows[0]["Servername"].ToString();
                    m_server.DbLink = dtxml.Rows[0]["Dblink"].ToString();
                }
            }
            else
            {
                if (MessageBox.Show("Bạn chưa cấu hình máy chủ \n Bạn có muốn cấu hình không ?", "Synchronize", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    frmLogin f1 = new frmLogin();
                    f1.ShowDialog();
                    if (f1.accept)
                    {
                        frmKhaibaomaychu f = new frmKhaibaomaychu(true);
                        f.ShowDialog();
                        m_server = f.CLient;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                    Application.Exit();
            }
        }
        #endregion
        private void load_listview()
        {
           list = DAL.Manager.listClient();
        }

        private void load_table()
        {
            dsxml = DAL.Manager.SynTable("");
            dsxml_chungtu = DAL.Manager.SynTable_chungtu("");
            dsxml_ksk = DAL.Manager.SynTable_KSK("");
            if (!System.IO.File.Exists("..//..//..//xml//del_table.xml"))
            {
                MessageBox.Show("Không tìm thấy file del_table.xml", "System");
                return;
            }
            dsxml_del.ReadXml("..//..//..//xml//del_table.xml", XmlReadMode.ReadSchema);
        }
        private void Use_Notify()
        {
            noticIcon.BalloonTipText = "Design by LinksToancau";
            noticIcon.BalloonTipTitle = "Synchronize";
            noticIcon.ShowBalloonTip(1);
        }
        private void Login()
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
        }
        private void mnumaytram_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            frmLogin f1 = new frmLogin();
            f1.ShowDialog();
            txtText.Visible = false;
            proStatus.Visible = false;
            
            if (f1.accept)
            {
                frmKhaibaomaytram f = new frmKhaibaomaytram( list,dsxml,i_khoang_cach_ngay);
                f.ShowDialog();
                load_table();
                load_listview();
            }
            else
            {
                UI.Thongbao.Message("MC003");
                return;
            }
            syn_time.Start();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            init();
            //load_Server();// bỏ vì dùng trực tiếp postgres 8.3
            load_listview();
            load_table();
            Use_Notify();
            syn_time.Start();
            image_time.Start();
            
        }
        /// <summary>
        /// phương thức tạo database nếu chưa được tạo
        /// </summary>
        private void init()
        {
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {
                try
                {
                    int i = acc.get_data("select * from " + acc.User + ".client where 1=0").Tables[0].Rows.Count;
                }
                catch
                {
                    acc.TaoTable();
                }
                gio = acc.Gio_bat_dau;
                phut = acc.Phut_bat_dau;
                auto = acc.Khoang_thoi_gian_dong_bo;
                bMailTuDong = acc.TuDong_Mail;
                gio_mail = acc.Gio_bat_dau_mail;
                phut_mail = acc.Phut_bat_dau_mail;
                iNgayNhacMail = acc.NgayNhacMail;
                //
                bSynHinhBN = acc.Dongbo_HinhBN;
                gio_hinhbn = acc.Gio_bat_dau_dongbo_hinhbn;
                phut_hinhbn = acc.Phut_bat_dau_dongbo_hinhbn;
                bSynHinhCDHA = acc.Dongbo_HinhCDHA;
                gio_hinhcdha = acc.Gio_bat_dau_dongbo_hinhCDHA;
                phut_hinhcdha = acc.Phut_bat_dau_dongbo_hinhcdha;
                bSynHinhChungTu = acc.Dongbo_HinhChungtu;
                gio_hinhchungtu  = acc.Gio_bat_dau_dongbo_hinhChungtu;
                phut_hinhchungtu = acc.Phut_bat_dau_dongbo_hinhChungtu;
                //
                bHinhBN_Overwrite = acc.HinhBN_GhiDe;
                bHinhCDHA_OvweWrite = acc.HinhCDHA_GhiDe;
                bHinhChungTu_Overwrite = acc.HinhChungTu_GhiDe;
                
                //
                i_khoang_cach_ngay = acc.Khoang_cach_ngay;
                noticIcon.Text = "SERVER: " + acc.Maincode("Ip");
            }
        }

        private void mnuMaychu_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            frmLogin f1 = new frmLogin();
            f1.ShowDialog();
            if (f1.accept)
            {
                frmKhaibaomaychu f = new frmKhaibaomaychu(false);
                f.CLient = m_server;
                f.ShowInTaskbar = false;
                f.ShowDialog();
                m_server = f.CLient;
                syn_time.Start();
            }
            else
            {
                UI.Thongbao.Message("MC003");
                syn_time.Start();
                return;
            }
        }

        private void mnuTaoTable_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            frmLogin f = new frmLogin();
            f.ShowDialog();
            syn_time.Start();
            if (f.accept)
            {
                DAL.Manager.TaoTable();
                load_table();
            }
            else
            {
                UI.Thongbao.Message("MC003");
                return;
            }
        }

        private void mnuLaydata_Click(object sender, EventArgs e)
        {
            //if (list.Count > 0)
            //{
            //    //DAL.Manager.DongBo(dtTable.Tables[0], list, m_server,true);
            //}
            #region bo phan nay
            //try
            //{

            //    if (!System.IO.File.Exists("..//..//..//xml//table.xml"))
            //    {
            //        MessageBox.Show("Không tìm thấy file table.xml", "System");
            //        return;
            //    }
            //    string mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
            //    ds = new DataSet();
            //    ds.ReadXml("..//..//..//xml/table.xml");

            //    string schema = "", table = "", field = "", key = "";

            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        schema = row["schema"].ToString();
            //        schema = schema.Replace("xxx", mmyy);
            //        table = row["tablename"].ToString();
            //        field = row["field"].ToString();
            //        key = row["key"].ToString();

            //        for (int i = 0; i < list.Count; i++)
            //        {
            //            acc.Syschronise2Server(schema, table, key, field, list[i], Server);
            //        }
            //    }
            //}
            //catch
            //{ }
            #endregion
        }

        private void mnuThemfield_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.accept)
            {
                //Thực hiện thêm file chuyển đi vào các table trên máy trung tâm.
                string valueDefault = "0";
                // update tren server trung tam
                #region bỏ : maincode chỉ trực tiếp vào server trung tâm
                //DAL.Manager.ThemField(dsxml.Tables[0], valueDefault, m_server, dtmmyy);
                //// update trên các máy trạm
                //for (int i = 0; i < list.Count; i++)
                //{
                //    DAL.Manager.ThemField(dsxml.Tables[0], valueDefault, list[i], dtmmyy);
                //}
                #endregion
                using (DAL.Accessdata acc = new DAL.Accessdata())
                {
                    try
                    {
                        acc.Add_chuyendi_to_table(dsxml.Tables[0], valueDefault.PadLeft(300,'0'), null, i_khoang_cach_ngay);
                        acc.Add_chuyendi_to_table(dsxml_chungtu.Tables[0], valueDefault.PadLeft(300, '0'), null, i_khoang_cach_ngay);
                        for (int i = 0; i < list.Count; i++)
                        {
                            acc.Add_chuyendi_to_table(dsxml.Tables[0], valueDefault.PadLeft(300,'0'), list[i], i_khoang_cach_ngay);
                            acc.Add_chuyendi_to_table(dsxml_chungtu.Tables[0], valueDefault.PadLeft(300, '0'), list[i], i_khoang_cach_ngay);
                        }
                    }
                    finally
                    {
                        
                    }
                }
            }
            else
            {
                UI.Thongbao.Message("MC003");
                return;
            }
        }

        private void mnuupdatecd_Click(object sender, EventArgs e)
        {
            //Thực hiện thêm file chuyển đi vào các table trên máy trung tâm.
            string valueDefault = "1";
            valueDefault = valueDefault.PadLeft(300, '1');
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {
                acc.Set_chuyendi_to_1(dsxml.Tables[0], valueDefault, null, i_khoang_cach_ngay);
                acc.Set_chuyendi_to_1(dsxml_chungtu.Tables[0], valueDefault, null, i_khoang_cach_ngay);
                for (int i = 0; i < list.Count; i++)
                {
                    acc.Set_chuyendi_to_1(dsxml.Tables[0], valueDefault, list[i], i_khoang_cach_ngay);
                    acc.Set_chuyendi_to_1(dsxml_chungtu.Tables[0], valueDefault, list[i], i_khoang_cach_ngay);
                }
            }
        }

        private void mnuKetthuc_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.accept)
            {
                bButketthuc = true;
                f.Close();
                Application.Exit();
            }
            else
            {
                UI.Thongbao.Message("MC003");
                return;
            }
        }

        private void mnudayData_Click(object sender, EventArgs e)
        {

        }

        private void Server_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                this.ShowInTaskbar = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void mnuThongso_Click(object sender, EventArgs e)
        {
            frmLogin f1 = new frmLogin();
            f1.ShowDialog();
            txtText.Visible = false;
            proStatus.Visible = false;
            if (f1.accept)
            {
                frmThongso f = new frmThongso();
                f.MdiParent = this;
                f.Show();
                init();
            }
            else
            {
                UI.Thongbao.Message("MC003");
                return;
            }
        }
        bool b_ngaymoi = false, b_ngaymoi_mail = false, b_Ngaymoi_HinhBN = false, b_Ngaymoi_HinhCDHA = false, b_Ngaymoi_HinhChungtu = false;
        string s_ngayhientai = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            p += 1;
            //Đồng bộ cuối ngày
            if (s_ngayhientai != m.ngayhienhanh_server.Substring(0, 10)) // DateTime.Now.ToString("dd/MM/yyyy"))
            {
                s_ngayhientai = m.ngayhienhanh_server.Substring(0, 10);// DateTime.Now.ToString("dd/MM/yyyy");
                b_ngaymoi = true;
                b_ngaymoi_mail = true;
                b_Ngaymoi_HinhBN = true;
                b_Ngaymoi_HinhCDHA = true;
                b_Ngaymoi_HinhChungtu = true;
            }
            string s_date_syn = DateTime.Now.ToString("dd/MM/yyyy") + " " + gio.ToString().PadLeft(2, '0') + ":" + phut.ToString().PadLeft(2, '0');
            DateTime date_syn = DateTime.ParseExact(s_date_syn, "dd/MM/yyyy HH:mm", System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
            if (DateTime.Compare(DateTime.Now, date_syn) >= 0 && b_ngaymoi)
            {
                syn_time.Stop();
                if (list.Count > 0)
                {
                    try
                    {
                        Dongbo(-1,"","");//dong bo cuoi ngay
                        //Dongbo_chungtu(true);
                    }
                    catch { }
                }
                b_ngaymoi = false;
                syn_time.Start();
            }
            //Gui mail
            string s_date_mail = DateTime.Now.ToString("dd/MM/yyyy") + " " + gio_mail.ToString().PadLeft(2, '0') + ":" + phut_mail.ToString().PadLeft(2, '0');
            DateTime date_mail = DateTime.ParseExact(s_date_mail, "dd/MM/yyyy HH:mm", System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
            if (DateTime.Compare(DateTime.Now, date_mail) >= 0 && b_ngaymoi_mail)
            {
                syn_time.Stop();
                if (list.Count > 0)
                {
                    try
                    {
                        DataTable dtDSBNHen;
                        s_ngayhientai = (s_ngayhientai == "") ? m.ngayhienhanh_server.Substring(0, 10) : s_ngayhientai;
                        dtDSBNHen = load_dbBNCanGuiEmail(s_ngayhientai).Tables[0];
                        if (dtDSBNHen.Rows.Count > 0)
                        {
                            GuiMailHen(dtDSBNHen);
                        }
                    }
                    catch { }
                }
                b_ngaymoi_mail = false;
                syn_time.Start();
            }
            //Dong bo hinh BN            
            if (bSynHinhBN)
            {
                string s_date_hinhbn = DateTime.Now.ToString("dd/MM/yyyy") + " " + gio_hinhbn.ToString().PadLeft(2, '0') + ":" + phut_hinhbn.ToString().PadLeft(2, '0');
                DateTime date_hinhbn = DateTime.ParseExact(s_date_hinhbn, "dd/MM/yyyy HH:mm", System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
                if (DateTime.Compare(DateTime.Now, date_hinhbn) >= 0 && b_Ngaymoi_HinhBN)
                {
                    syn_time.Stop();
                    DongBo_HinhBN();
                    b_Ngaymoi_HinhBN = false;
                    syn_time.Start();
                }
            }
            //Dong bo hinh BN            
            if (bSynHinhCDHA)
            {
                string s_date_hinhcdha = DateTime.Now.ToString("dd/MM/yyyy") + " " + gio_hinhcdha.ToString().PadLeft(2, '0') + ":" + phut_hinhcdha.ToString().PadLeft(2, '0');
                DateTime date_hinhcdha = DateTime.ParseExact(s_date_hinhcdha, "dd/MM/yyyy HH:mm", System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
                if (DateTime.Compare(DateTime.Now, date_hinhcdha ) >= 0 && b_Ngaymoi_HinhChungtu)
                {
                    syn_time.Stop();
                    DongBo_HinhCDHA(3);
                    b_Ngaymoi_HinhCDHA = false;
                    syn_time.Start();
                }
            }
            //Dong bo hinh BN            
            if (bSynHinhChungTu)
            {
                string s_date_hinhchungtu = DateTime.Now.ToString("dd/MM/yyyy") + " " + gio_hinhchungtu.ToString().PadLeft(2, '0') + ":" + phut_hinhchungtu.ToString().PadLeft(2, '0');
                DateTime date_hinhchungtu = DateTime.ParseExact(s_date_hinhchungtu, "dd/MM/yyyy HH:mm", System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
                if (DateTime.Compare(DateTime.Now, date_hinhchungtu) >= 0 && b_Ngaymoi_HinhChungtu)
                {
                    syn_time.Stop();
                    DongBo_HinhCDHA(3);
                    b_Ngaymoi_HinhChungtu = false;
                    syn_time.Start();
                }
            }
            // đồng bộ liên tục
            if (p >= auto)
            {
                p = 0;
                if (list.Count > 0)
                {
                    syn_time.Stop();
                    try
                    {
                        Dongbo(0,"","");
                    }
                    catch { }
                    syn_time.Start();
                }
            }
            //

            //
        }//linh 171011

        private void mnuSLCuoiNgay_Click(object sender, EventArgs e)
        {//linh 171011
            if (list.Count > 0)
            {
                //
                dsxml = DAL.Manager.SynTable("");
                dsxml_chungtu = DAL.Manager.SynTable_chungtu("");
                dsxml_ksk = DAL.Manager.SynTable_KSK("");
                //
                txtText.Visible = true;
                proStatus.Visible = true;
                syn_time.Stop();
                Dongbo(-1,"","");

                //if (m.ChiNhanhTrungTam)
                //{
                //    Dongbo_khamsuckhoe(0);//chi cho chay tai server cong ty// chi nhanh thi tuy theo hop dong
                //}
                //else
                //{
                //    Dongbo_chungtu(true);
                //    //
                //}
                //
                syn_time.Start();
            }
        }

        private void conXoa_Click(object sender, EventArgs e)
        {
            //DAL.Accessdata dal = new DAL.Accessdata();
            //string schema = "", table = "";
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    foreach (ListViewItem item in listView1.SelectedItems)
            //    {
            //        DAL.Client _client = list.Find
            //            (
            //             delegate(DAL.Client d_client) { return d_client.Host == item.Text; }
            //            );
            //        if (MessageBox.Show("Bạn muốn xóa máy trạm :" + _client.Host, "Server", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //        {
            //            if (_client.XoaDBLink())
            //            {
            //                DAL.Manager.XoaClient(_client, m_server);
            //                foreach (System.Data.DataRow row in dsxml.Tables[0].Rows)
            //                {
            //                    schema = row["schema"].ToString();
            //                    schema = schema.Replace("xxx", mmyy);
            //                    table = row["tablename"].ToString();
            //                    for (int i = 0; i < list.Count; i++)
            //                    {
            //                        dal.dropFunction(schema + ".syn_" + table + "_from_" + _client.ServerName.ToUpper());
            //                    }
            //                }
            //                list.Remove(_client);
            //            }
            //        }
            //    }
            //    load_listview();
            //}
        }

        private void conThem_Click(object sender, EventArgs e)
        {
            mnumaytram_Click(sender, e);
        }

        private void mnuEvent_Click(object sender, EventArgs e)
        {
            txtText.Visible = false;
            proStatus.Visible = false;
            frmEventlog f = new frmEventlog(m_server);
            //f.MdiParent = this;
            f.ShowDialog();
            txtText.Visible = true;
            proStatus.Visible = true;
        }

        private void mnuCreateFunction_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.accept)
            {
                #region đoạn xử lý cho edb 
                //string schema = "", table = "", field = "", key = "";
                //bool done = false;
                //DAL.Accessdata acc = new DAL.Accessdata();
                //foreach (DataRow r in dtmmyy.Rows)
                //{
                //    done = true;
                //    mmyy = r["mmyy"].ToString();
                //    foreach (System.Data.DataRow row in dsxml.Tables[0].Rows)
                //    {
                //        schema = row["schema"].ToString();
                //        schema = schema.Replace("xxx", mmyy);
                //        table = row["tablename"].ToString();
                //        for (int i = 0; i < list.Count; i++)
                //        {
                //            acc.CreateFunction(list[i], schema, table);
                //        }
                //    }
                //}
                //if (!done)
                //{
                //    mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
                //    foreach (System.Data.DataRow row in dsxml.Tables[0].Rows)
                //    {
                //        schema = row["schema"].ToString();
                //        schema = schema.Replace("xxx", mmyy);
                //        table = row["tablename"].ToString();
                //        for (int i = 0; i < list.Count; i++)
                //        {
                //            acc.CreateFunction(list[i], schema, table);
                //        }
                //    }
                //}
                #endregion
                try
                {
                    syn_time.Stop();// dung chay dong bo
                    using (DAL.Accessdata acc = new DAL.Accessdata())
                    {
                        DateTime tn = DateTime.Now.AddDays(-(double)i_khoang_cach_ngay);
                        DateTime dn = DateTime.Now.AddDays((double)i_khoang_cach_ngay);
                        for (int j = tn.Year; j <= dn.Year; j++)
                        {
                            for (int i = tn.Month; i <= dn.Month; i++)
                            {
                                string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                                foreach (DataRow row in dsxml.Tables[0].Rows)
                                {
                                    if (acc.bShemaValid(row["schema_name"].ToString().Replace("xxx", mmyy)))
                                    {
                                        for (int l = 0; l < list.Count; l++)
                                        {
                                            acc.CreateFunction(list[l], row["schema_name"].ToString().Replace("xxx", mmyy), row["table_name"].ToString());
                                        }
                                    }
                                }
                                foreach (DataRow row in dsxml_chungtu.Tables[0].Rows)
                                {
                                    if (acc.bShemaValid(row["schema_name"].ToString().Replace("xxx", mmyy)))
                                    {
                                        for (int l = 0; l < list.Count; l++)
                                        {
                                            acc.CreateFunction(list[l], row["schema_name"].ToString().Replace("xxx", mmyy), row["table_name"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Synchrinize");
                }
                finally
                {
                    syn_time.Start();// chay lai
                }
            }
            else
            {
                UI.Thongbao.Message("MC003");
                return;
            }
        }
        /// <summary>
        /// Phương thức sử dụng tạo function 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tao_Function_Dong_Bo( string mmyy)
        {
            try
            {
                syn_time.Stop();// dung chay dong bo
                using (DAL.Accessdata acc = new DAL.Accessdata())
                {
                    //DateTime tn = DateTime.Now.AddDays(-(double)i_khoang_cach_ngay);
                    //DateTime dn = DateTime.Now.AddDays((double)i_khoang_cach_ngay);
                    //for (int j = tn.Year; j <= dn.Year; j++)
                    //{
                    //    for (int i = tn.Month; i <= dn.Month; i++)
                    //    {
                    //        string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                            foreach (DataRow row in dsxml.Tables[0].Rows)
                            {
                                if (acc.bShemaValid(row["schema_name"].ToString().Replace("xxx", mmyy)))
                                {
                                    for (int l = 0; l < list.Count; l++)
                                    {
                                        acc.CreateFunction(list[l], row["schema_name"].ToString().Replace("xxx", mmyy), row["table_name"].ToString());
                                    }
                                }
                            }
                            foreach (DataRow row in dsxml_chungtu.Tables[0].Rows)
                            {
                                if (acc.bShemaValid(row["schema_name"].ToString().Replace("xxx", mmyy)))
                                {
                                    for (int l = 0; l < list.Count; l++)
                                    {
                                        acc.CreateFunction(list[l], row["schema_name"].ToString().Replace("xxx", mmyy), row["table_name"].ToString());
                                    }
                                }
                            }
                    //    }
                    //}
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Synchrinize");
            }
            finally
            {
                syn_time.Start();// chay lai
            }
        }
        private void mnuUpdate_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            load_table();
            txtText.Visible = true;
            proStatus.Visible = true;
            try
            {
                Dongbo(0,"","");
            }
            catch { }
            syn_time.Start();
        }
        /// <summary>
        /// Dong bo du lieu
        /// </summary>
        /// <param name="i_loaidongbo">-1: Dong bo tat ca; 0: Tuc thoi, 1: Cuoi ngay; 2: Kham suc khoe</param>               
        private void Dongbo(int i_loaidongbo, string s_tu, string s_den)
        {
            this.Cursor = Cursors.WaitCursor;
            lblstatuss.Text = "Running ...";
            load_listview();
            string schema = "", table = "";
            string exp = "";
            if (i_loaidongbo == -1) exp = "";
            else exp = "lastday=" + i_loaidongbo;
            DataRow[] dtr = dsxml.Tables[0].Select(exp , "stt");//: dsxml.Tables[0].Select("lastday=0", "stt"));
            string Server_Error_Connection = "";
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {

                DateTime tn = (s_tu == "") ? DateTime.Now.AddDays(-(double)i_khoang_cach_ngay) : DateTime.ParseExact(s_tu, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
                DateTime dn = (s_den == "") ? DateTime.Now.AddDays((double)i_khoang_cach_ngay) : DateTime.ParseExact(s_den, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
                int y1 = tn.Year, y2 = dn.Year;
                int m1 = tn.Month, m2 = dn.Month;
                int itu = 0, iden = 0;
                for (int j = y1; j <= y2; j++)
                {
                    itu = (j == y1) ? m1 : 1;
                    iden = (j == y2) ? m2 : 12;
                    for (int i = itu; i <= iden; i++)
                    {
                        string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                        for (int ii = 0; ii < list.Count; ii++)
                        {
                            if (Server_Error_Connection != "" && list[ii].Host == Server_Error_Connection)
                            {
                                txtText.Text += "Connection Failed: " + Server_Error_Connection+"\n";
                                continue;
                            }
                            for (int jj = 0; jj < dtr.Length; jj++)
                            {
                                if (Server_Error_Connection != "" && list[ii].Host == Server_Error_Connection)
                                {
                                    txtText.Text += "Connection Failed: " + Server_Error_Connection + "\n";
                                    break;
                                }
                                schema = dtr[jj]["schema_name"].ToString();
                                schema = schema.Replace("xxx", mmyy);
                                table = dtr[jj]["table_name"].ToString();
                                
                                //Kiểm tra xem schema có tồn tại không? 
                                if(acc.bShemaValid(schema))
                                {
                                    Application.DoEvents();
                                    statusServer.Text = list[ii].Host + "-" + list[ii].DatabaseName;                                    
                                    lblstatuss.Text = schema + "." + table;
                                    //table = "btdbn_uudai";
                                    acc.update(list[ii], schema, table, txtText, Trangthai, proStatus, ref Server_Error_Connection);
                                    statusServer.Text = "";
                                    lblstatuss.Text = "";
                                }
                            }
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                lblstatuss.Text = "Finished ";
            }
        }

        private void Dongbo_chungtu(bool full)
        {
            if (dsxml_chungtu == null || dsxml_chungtu.Tables.Count <= 0 || dsxml_chungtu.Tables[0].Rows.Count <= 0) return;
            this.Cursor = Cursors.WaitCursor;
            lblstatuss.Text = "Running ...";
            load_listview();
            string schema = "", table = "", dieukien="";
            DataRow[] dtr = ((full == true) ? dsxml_chungtu.Tables[0].Select("lastday=1", "stt") : dsxml_chungtu.Tables[0].Select("lastday=0", "stt"));
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {
                DateTime tn = DateTime.Now.AddDays(-(double)i_khoang_cach_ngay);
                DateTime dn = DateTime.Now.AddDays((double)i_khoang_cach_ngay);
                int y1 = tn.Year, y2 = dn.Year;
                int m1 = tn.Month, m2 = dn.Month;
                int itu = 0, iden = 0;
                for (int j = y1; j <= y2; j++)
                {
                    itu = (j == y1) ? m1 : 1;
                    iden = (j == y2) ? m2 : 12;
                    for (int i = itu; i <= iden ; i++)
                    {
                        string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);                        
                        for (int ii = 0; ii < list.Count; ii++)
                        {
                            for (int jj = 0; jj < dtr.Length; jj++)
                            {
                                schema = dtr[jj]["schema_name"].ToString();
                                schema = schema.Replace("xxx", mmyy);
                                table = dtr[jj]["table_name"].ToString();
                                dieukien = dtr[jj]["dieukien"].ToString();
                                dieukien = dieukien.Replace("xxx", mmyy);
                                //Kiểm tra xem schema có tồn tại không? 
                                if(acc.bShemaValid(schema))
                                {
                                    Application.DoEvents();
                                    statusServer.Text = list[ii].Host + "-" + list[ii].DatabaseName;
                                    lblstatuss.Text = schema + "." + table;

                                    acc.update_chungtu(list[ii], schema, table, txtText, Trangthai, proStatus,dieukien);
                                    statusServer.Text = "";
                                    lblstatuss.Text = "";
                                }
                            }
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                lblstatuss.Text = "Finished ";
            }
        }

        public void Dongbo_khamsuckhoe(long m_iddoanksk)
        {
            if (dsxml_chungtu == null || dsxml_chungtu.Tables.Count <= 0 || dsxml_chungtu.Tables[0].Rows.Count <= 0) return;
            this.Cursor = Cursors.WaitCursor;
            lblstatuss.Text = "Running ...";
            load_listview();
            string schema = "", table = "", dieukien = "";
            if (dsxml_ksk == null || dsxml_ksk.Tables.Count <= 0 || dsxml_ksk.Tables[0].Rows.Count <= 0) return;
            DataRow[] dtr = dsxml_ksk.Tables[0].Select("lastday=2", "stt");
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {
                DateTime tn = DateTime.Now.AddDays(-(double)i_khoang_cach_ngay);
                DateTime dn = DateTime.Now.AddDays((double)i_khoang_cach_ngay);
                int y1 = tn.Year, y2 = dn.Year;
                int m1 = tn.Month, m2 = dn.Month;
                int itu = 0, iden = 0;
                for (int j = y1; j <= y2; j++)
                {
                    itu = (j == y1) ? m1 : 1;
                    iden = (j == y2) ? m2 : 12;
                    for (int i = itu; i <= iden; i++)
                    {
                        string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                        for (int ii = 0; ii < list.Count; ii++)
                        {
                            for (int jj = 0; jj < dtr.Length; jj++)
                            {
                                schema = dtr[jj]["schema_name"].ToString();
                                schema = schema.Replace("xxx", mmyy);
                                table = dtr[jj]["table_name"].ToString();
                                dieukien = dtr[jj]["dieukien"].ToString();
                                dieukien = dieukien.Replace("xxx", mmyy);
                                if (m_iddoanksk == 0) dieukien = "";//binh 08032012
                                //Kiểm tra xem schema có tồn tại không? 
                                if (acc.bShemaValid(schema))
                                {
                                    Application.DoEvents();
                                    statusServer.Text = list[ii].Host + "-" + list[ii].DatabaseName;
                                    lblstatuss.Text = schema + "." + table;

                                    acc.update_chungtu(list[ii], schema, table, txtText, Trangthai, proStatus, dieukien);
                                    statusServer.Text = "";
                                    lblstatuss.Text = "";
                                }
                            }
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                lblstatuss.Text = "Finished ";
            }
        }

        private void load_icon(bool p)
        {
            try
            {
                if (p)
                {
                    noticIcon.Icon = new Icon("down.ico");
                }
                else
                {
                    noticIcon.Icon = new Icon("StockIndexDown.ico");
                }
            }
            catch
            { }
        }

        private void conXemdsmaytram_Click(object sender, EventArgs e)
        {
            txtText.Visible = false ;
            proStatus.Visible = false ;
            syn_time.Stop ();

            frmDsMaytram f = new frmDsMaytram(dsxml,i_khoang_cach_ngay);
            //f.MdiParent = this;
            f.ShowDialog();
            list = DAL.Manager.listClient();
            syn_time.Start();

        }

        private void mnuModifyField_Click(object sender, EventArgs e)
        {
            frmLogin f1 = new frmLogin();
            f1.ShowDialog();
            if (f1.accept)
            {
                frmQuanlyDatabase f = new frmQuanlyDatabase(m_server.DbLink);
                //f.MdiParent = this;
                f.ShowDialog();
                load_table();
            }
            else
            {
                UI.Thongbao.Message("MC003");
                return;
            }
        }

        private void tableDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConstraint f = new frmConstraint();
            f.MdiParent = this;
            f.Show();
        }

        private void tableUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdmTable f = new frmdmTable(list,dsxml.Tables[0]);
            //f.MdiParent = this;
            f.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (bgif)
            {
                bgif = false;
                load_icon(bgif);
            }
            else
            {
                bgif = true;
                load_icon(bgif);
            }
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bButketthuc)
            {
                frmLogin f = new frmLogin();
                f.ShowDialog();
                if (f.accept)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void mnuExportColumn_Click(object sender, EventArgs e)
        {
            DAL.Accessdata ac = new DAL.Accessdata();
            DataTable dttemp = new DataTable();
            DataSet dstem = new DataSet();
            dstem.ReadXml("..//..//..//xml//upd_table.xml",XmlReadMode.ReadSchema);
            dttemp = dstem.Tables[0];
            dttemp.Rows.Clear();
            string schemas = "medibv";
            DataTable dt1 = ac.get_data("select tablename from pg_tables@"+m_server.DbLink+" where schemaname='"+schemas+"'").Tables[0];
            string keys = "";
            string field = "";
            string tablename = "";
           // string schemas = "medibv";
            foreach (DataRow r in dt1.Rows)
            {
                keys = "";
                field = "";
                tablename = r["tablename"].ToString();
                //lay key
                DataTable dt = ac.get_data("select column_name from information_schema.key_column_usage@" + m_server.DbLink + " where constraint_schema='" + schemas + "' and table_name='" + tablename + "' and constraint_name like '%pk%' ").Tables[0];
                foreach (DataRow r1 in dt.Rows)
                {
                    if (keys == "")
                    {
                        keys = r1["column_name"].ToString();
                    }
                    else
                    {
                        keys += "," + r1["column_name"].ToString();
                    }
                }
                dt = ac.get_data("select column_name from information_schema.columns@"+m_server.DbLink+" where table_schema='"+schemas+"' and table_name='"+tablename+"'").Tables[0];
                foreach (DataRow r1 in dt.Rows)
                {
                    if (field == "")
                    {
                        field = r1["column_name"].ToString();
                    }
                    else
                    {
                        field += "," + r1["column_name"].ToString();
                    }
                }
                DataRow row = dttemp.NewRow();
                row["schema"] = "medibv";
                row["tablename"] = tablename;
                row["key"] = keys;
                row["field"] = field;
                row["lastday"]=0;
                dttemp.Rows.Add(row);
            }
            dttemp.WriteXml("..//..//..//xml//tableField.xml", XmlWriteMode.WriteSchema);
            dttemp.Rows.Clear();
             schemas = "medibv"+DateTime.Now.Month.ToString().PadLeft(2,'0')+DateTime.Now.Year.ToString().Substring(2,2);
             dt1 = ac.get_data("select tablename from pg_tables@" + m_server.DbLink + " where schemaname='" + schemas + "'").Tables[0];
             foreach (DataRow r in dt1.Rows)
             {
                 keys = "";
                 field = "";
                 tablename = r["tablename"].ToString();
                 //lay key
                 DataTable dt = ac.get_data("select column_name from information_schema.key_column_usage@" + m_server.DbLink + " where constraint_schema='" + schemas + "' and table_name='" + tablename + "' and constraint_name like '%pk%' ").Tables[0];
                 foreach (DataRow r1 in dt.Rows)
                 {
                     if (keys == "")
                     {
                         keys = r1["column_name"].ToString();
                     }
                     else
                     {
                         keys += "," + r1["column_name"].ToString();
                     }
                 }
                 dt = ac.get_data("select column_name from information_schema.columns@" + m_server.DbLink + " where table_schema='" + schemas + "' and table_name='" + tablename + "'").Tables[0];
                 foreach (DataRow r1 in dt.Rows)
                 {
                     if (field == "")
                     {
                         field = r1["column_name"].ToString();
                     }
                     else
                     {
                         field += "," + r1["column_name"].ToString();
                     }
                 }
                 DataRow row = dttemp.NewRow();
                 row["schema"] = "medibvxxx";
                 row["tablename"] = tablename;
                 row["key"] = keys;
                 row["field"] = field;
                 row["lastday"] = 0;
                 dttemp.Rows.Add(row);
             }
             dttemp.WriteXml("..//..//..//xml//tableFieldMMYY.xml", XmlWriteMode.WriteSchema);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuTrigger_Click(object sender, EventArgs e)
        {
            DAL.Accessdata acc = new DAL.Accessdata();
            acc.create_del_table_on_client(list[0], "medibv", "deltable");
        }

        private void sửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.StartInfo.FileName = "help.chm";
                pro.Start();
            }
            catch { }
            
        }

        private void copyPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            DongBo_HinhBN();
            syn_time.Start();
        }

        private void ngừngĐồngBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            lblstatuss.Text = "Stopped";
        }

        private void chạyĐồngBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syn_time.Start();
            lblstatuss.Text = "Running...";
        }

        private void mnu31_Click(object sender, EventArgs e)
        {
            //return;
            frmdmTable f = new frmdmTable(list,dsxml.Tables[0]);
            f.ShowDialog();
        }
        
        private void function_create_time_Tick(object sender, EventArgs e)
        {
            mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
            DAL.Accessdata dal = new DAL.Accessdata();
            if (!dal.Da_tao_function(mmyy,"syn_manager_schema"))
            {
                Tao_Function_Dong_Bo(mmyy);
                dal.udp_syn_manager_schema(mmyy, 1, "syn_manager_schema");
            }
        }

        private void dropNotNullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string valueDefault = "0";
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {
                try
                {
                    acc.drop_notnull_chuyendi_to_table(dsxml.Tables[0], valueDefault.PadLeft(300, '0'), null, i_khoang_cach_ngay);
                    acc.drop_notnull_chuyendi_to_table(dsxml_chungtu.Tables[0], valueDefault.PadLeft(300, '0'), null, i_khoang_cach_ngay);
                    for (int i = 0; i < list.Count; i++)
                    {
                        acc.drop_notnull_chuyendi_to_table(dsxml.Tables[0], valueDefault.PadLeft(300, '0'), list[i], i_khoang_cach_ngay);
                        acc.drop_notnull_chuyendi_to_table(dsxml_chungtu.Tables[0], valueDefault.PadLeft(300, '0'), list[i], i_khoang_cach_ngay);
                    }
                }
                finally
                {

                }
            }
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            string note="Syn...";
            if (txtText.Text != "") { note = txtText.Text; }
            noticIcon.Text = note;
            Application.DoEvents();
        }

        private void đồngBộKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            p = 0;
            frmThucong f = new frmThucong();
            f.ShowDialog();
            syn_time.Start();

        }

        private void mnuDongBoKSK_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            p = 0;
            frmDongBoKSK f = new frmDongBoKSK();
            f.ShowDialog();
            syn_time.Start();
        }

        private void mnuAddFieldChuyendi_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.accept)
            {
                //Thực hiện thêm file chuyển đi vào các table trên máy trung tâm.
                string valueDefault = "0";
                // update tren server trung tam
                #region bỏ : maincode chỉ trực tiếp vào server trung tâm
                //DAL.Manager.ThemField(dsxml.Tables[0], valueDefault, m_server, dtmmyy);
                //// update trên các máy trạm
                //for (int i = 0; i < list.Count; i++)
                //{
                //    DAL.Manager.ThemField(dsxml.Tables[0], valueDefault, list[i], dtmmyy);
                //}
                #endregion
                using (DAL.Accessdata acc = new DAL.Accessdata())
                {
                    try
                    {
                        acc.Add_chuyendi_to_table(dsxml.Tables[0], valueDefault.PadLeft(300, '0'), null, i_khoang_cach_ngay);
                        for (int i = 0; i < list.Count; i++)
                        {
                            acc.Add_chuyendi_to_table(dsxml.Tables[0], valueDefault.PadLeft(300, '0'), list[i], i_khoang_cach_ngay);
                        }
                    }
                    finally
                    {

                    }
                    //
                    try
                    {
                        if (dsxml_chungtu.Tables.Count > 0)
                        {
                            acc.Add_chuyendi_to_table(dsxml_chungtu.Tables[0], valueDefault.PadLeft(300, '0'), null, i_khoang_cach_ngay);
                            for (int i = 0; i < list.Count; i++)
                            {
                                acc.Add_chuyendi_to_table(dsxml_chungtu.Tables[0], valueDefault.PadLeft(300, '0'), list[i], i_khoang_cach_ngay);
                            }
                        }
                    }
                    finally
                    {

                    }

                    try
                    {
                        if (dsxml_ksk.Tables.Count > 0)
                        {
                            acc.Add_chuyendi_to_table(dsxml_ksk.Tables[0], valueDefault.PadLeft(300, '0'), null, i_khoang_cach_ngay);
                            for (int i = 0; i < list.Count; i++)
                            {
                                acc.Add_chuyendi_to_table(dsxml_ksk.Tables[0], valueDefault.PadLeft(300, '0'), list[i], i_khoang_cach_ngay);
                            }
                        }
                    }
                    finally
                    {

                    }
                }
            }
            else
            {
                UI.Thongbao.Message("MC003");
                return;
            }
            syn_time.Start();
        }

        private void mnuChuyendulieu_Click(object sender, EventArgs e)
        {

        }

        private void mnuCauHinhEmail_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            frmCauHinhMail f = new frmCauHinhMail();
            f.ShowDialog();
            syn_time.Start();
        }


        /// <summary>
        /// Dựa trên dach sách được chọn trên lưới, gửi mail tới những bệnh nhân có email, đồng thời update d_thuocbhytll.guimail=1
        /// </summary>
        private void GuiMailHen(DataTable dtDSBN)
        {
            string s_Email = "", s_Port = "", s_SMTP = "";
            string sPassWordMail = ""; //Mật khẩu đăng nhập email
            string sNoiDungMail = "", s_chude = "", s_logo = "";   // Nội dung email
            Loai_Mail(ref s_Email, ref sPassWordMail, ref s_SMTP, ref s_Port, ref s_logo);
            //frmMatkhau f = new frmMatkhau(txtFrom.Text.Trim());
            //f.ShowDialog();
            //sPassWordMail = f.pass; 
            int iCount = 0, i_stt = 0;
            proStatus.Maximum = dtDSBN.Select("email<>''").Length;
            iCount = dtDSBN.Select("email<>''").Length;
            proStatus.Value = 0;
            Application.DoEvents();
            mailfailed = 0;
            //sNoiDungMail = s_logo + "<br/><br/>" + sNoiDungMail;
            string s_noidungmail_mau = "";
            LoadNoiDungEMail(1, ref s_noidungmail_mau, ref s_chude);
            if (sNoiDungMail.Trim() == "")
            {
                MessageBox.Show("Chưa khai báo nội dung để gửi mail tự động, nên không gửi mail được.");
                return;
            }
            foreach (DataRow r in dtDSBN.Select("email<>''"))
            {
                Application.DoEvents();
                //
                i_stt += 1;
                Trangthai.Text = i_stt.ToString() + "/" + iCount.ToString();
                //sNoiDungMail = txtNoidung.Text;
                sNoiDungMail = s_noidungmail_mau.Replace("m_mabenhnhan", r["mabn"].ToString());
                sNoiDungMail = sNoiDungMail.Replace("m_hotenbenhnhan", r["hoten"].ToString());
                //sNoiDungMail = sNoiDungMail.Replace("m_bacsi", txtTenBacSi.Text.Trim());

                m.execute_data_mmyy("update xxx.d_thuocbhytll set guimail=4 where id=" + r["id"].ToString(), s_ngayhientai, s_ngayhientai, true);
                //
                if (iNgayNhacMail <= 0) iNgayNhacMail = 2;
                //
                DateTime dt = m.StringToDate(s_ngayhientai).AddDays(iNgayNhacMail);
                //if (dt.DayOfWeek.ToString().ToLower().Substring(0,3) == "sun")//chu nhat
                //{
                //    dt = dt.AddDays(1);
                //}
                int tmp_themngay = m.i_themngay_letet(m.DateToString("dd/MM/yyyy", dt), 0);
                if (tmp_themngay > 0) dt.AddDays(tmp_themngay);
                tmp_themngay = 0;
                tmp_themngay = m.i_themngay_nghi(m.DateToString("dd/MM/yyyy", dt), 0);
                if (tmp_themngay > 0) dt.AddDays(tmp_themngay);
                //
                if (sNoiDungMail.IndexOf("dd/mm/yyyy") >= 0) sNoiDungMail = sNoiDungMail.Replace("dd/mm/yyyy", dt.Day.ToString().PadLeft(2, '0') + " tháng " + dt.Month.ToString().PadLeft(2, '0') + " năm " + dt.Year.ToString());
                else sNoiDungMail = sNoiDungMail + "\n\n" + "Ngày tái khám : " + dt.Day.ToString().PadLeft(2, '0') + " tháng " + dt.Month.ToString().PadLeft(2, '0') + " năm " + dt.Year.ToString() + "\n";
                //
                sNoiDungMail = sNoiDungMail.Replace("\n", "<br/>");
                f_sendmail(r["mabn"].ToString(), r["email"].ToString(), sPassWordMail, sNoiDungMail, s_SMTP, s_Port, s_Email, s_chude, r["id"].ToString());
                proStatus.Value++;
                proStatus.Text = proStatus.Value.ToString() + "/" + proStatus.Maximum.ToString() + " - Failed: " + mailfailed;
            }
        }

        private void mnuGuimail_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            if (m.ChiNhanhTrungTam == false)
            {
                MessageBox.Show("Bạn chưa được quyền vào khai báo nội dung này, chỉ có ở văn phòng công ty mới được khai báo.");
                syn_time.Start();
                return;
            }            
            DataTable dtDSBNHen;
            s_ngayhientai = (s_ngayhientai == "") ? m.ngayhienhanh_server.Substring(0, 10) : s_ngayhientai;
            dtDSBNHen = load_dbBNCanGuiEmail(s_ngayhientai).Tables[0];
            Trangthai.Text = dtDSBNHen.Rows.Count.ToString();//
            GuiMailHen(dtDSBNHen);
            syn_time.Start();
        }

        private DataSet load_dbBNCanGuiEmail(string s_NgayNhacBN)
        {
            s_NgayNhacBN = (s_NgayNhacBN == "") ? m.ngayhienhanh_server.Substring(0, 10) : s_NgayNhacBN;
            if (iNgayNhacMail <= 0) iNgayNhacMail = 2;
            string sSQL = " select distinct 0 as chon,a.mabn,b.hoten,b.namsinh,b1.ten as gioitinh,";
            sSQL += " to_char(a.ngay+a.songayhen,'dd/mm/yyyy') as ngayhen";
            sSQL += ", a.maicd,a.chandoan,c.email,a.id ";
            sSQL += " from xxx.d_thuocbhytll a inner join medibv.btdbn b on a.mabn=b.mabn inner join medibv.dmphai b1 on b.phai=b1.ma ";
            sSQL += " left join medibv.dienthoai c on b.mabn=c.mabn ";
            sSQL += " where to_date(to_char(a.ngay+cast(to_char(a.songayhen-" + iNgayNhacMail + ")||' days' as interval),'dd/mm/yyyy'),'dd/mm/yyyy') = to_date('" + s_NgayNhacBN + "','dd/mm/yyyy')";
            sSQL += " and c.email is not null ";
            sSQL += " and a.guimail=0 ";
            sSQL += " order by mabn, to_char(a.ngay+cast(to_char(a.songayhen)||' days' as interval),'dd/mm/yyyy') ";

            DataSet dsDanhSachHen = m.get_data_mmyy(sSQL, s_NgayNhacBN, s_NgayNhacBN, true);

            return dsDanhSachHen;
        }
        private void Loai_Mail(ref string s_Email, ref string s_Password, ref string s_smtp, ref string s_port, ref string s_logo)
        {
            DataSet lds = new DataSet();
            lds.ReadXml("..//..//..//xml//cauhinhmail.xml");
            foreach (DataRow dr in lds.Tables[0].Rows)
            {
                s_Email = dr["from"].ToString();
                s_Password = dr["password"].ToString();
                s_smtp = dr["smtpserver"].ToString();
                s_port= dr["port"].ToString();
                s_logo = dr["logo"].ToString();
            }
        }

        private void LoadNoiDungEMail(int i_LoaiMail, ref string s_NoiDung, ref string s_chude)
        {
            string asql = "select * from medibv.dmemail where loai=" + i_LoaiMail;
            DataSet lds = m.get_data(asql);
            s_NoiDung = ""; s_chude = "";
            foreach (DataRow dr in lds.Tables[0].Rows)
            {
                s_NoiDung = dr["noidung"].ToString();
                s_chude = dr["tieude"].ToString();
                break;
            }

        }

        private void f_sendmail(string _mabn, string _email, string _pass, string _noidung, string _smtp, string _port, string _emailFrom, string _chude, string _IDHen)
        {
            string sql = "";
            bool sendok = false;

            sendok = sendEmail(_smtp.Trim(), _port.Trim(), _emailFrom.Trim(), _pass, _email, _chude, _noidung);
            
        }

        private bool sendEmail(string server, string port, string user, string pass, string to, string subject, string body)
        {
            try
            {
                string mMailServer = server;
                int mPort = int.Parse(port);

                NetworkCredential nc = new NetworkCredential(user, pass);

                MailMessage message = new MailMessage(user.Trim(), to.Trim(), subject.Trim(), body.Trim());
                message.Priority = MailPriority.High;
                //True: html document; False: plain text
                message.IsBodyHtml = true;

                SmtpClient mySmtpClient = new SmtpClient(mMailServer, mPort);

                //mySmtpClient.UseDefaultCredentials = true;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Credentials = nc;

                mySmtpClient.Send(message);

                return true;
            }
            catch (FormatException ex)
            {
                return false;
            }
            catch (SmtpException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        private void mnuDongBoHinhAnh_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            DongBo_HinhCDHA(3);
            syn_time.Stop();
        }

        private void DongBo_HinhCDHA(int iSongay)
        {
            if (iSongay == 0) iSongay = 3;
            string path_dest_cdha = m.get_DuongDan_HinhAnhCDHA();
            string NewPathSource = "", NewDir = "";
            int iNgayHienTai = int.Parse(m.ngayhienhanh_server.Substring(0, 2));
            int iThangHienTai = int.Parse(m.ngayhienhanh_server.Substring(3, 2));
            int iNamHienTai = int.Parse(m.ngayhienhanh_server.Substring(6, 4));
            for (int ii = 0; ii < list.Count; ii++)
            {
                iNgayHienTai = int.Parse(m.ngayhienhanh_server.Substring(0, 2));
                NewPathSource = list[ii].ImagePath;
                if (NewPathSource.Trim() != "")
                {
                    //copy hinh BN: 4 ngay gan nhat
                    for (int j = 0; j < iSongay; j++)
                    {
                        if (j != 0)
                        {
                            iNgayHienTai -= 1;
                            if (iNgayHienTai < 0)
                            {
                                iNgayHienTai = 1;
                                iThangHienTai = iThangHienTai - 1;
                                if (iThangHienTai < 0) iNamHienTai = iNamHienTai - 1;
                            }
                        }
                        NewDir = iNamHienTai.ToString().Substring(2, 2).PadLeft(2, '0') + iThangHienTai.ToString().PadLeft(2, '0') + iNgayHienTai.ToString().PadLeft(2, '0');
                        NewPathSource = list[ii].ImagePath + "\\" + NewDir;
                        if (System.IO.Directory.Exists(NewPathSource))
                        {
                            
                            if (System.IO.Directory.Exists(path_dest_cdha + "\\" + NewDir) == false) System.IO.Directory.CreateDirectory(path_dest_cdha + "\\" + NewDir);
                            //path_dest_cdha = path_dest_cdha + "\\" + NewDir;
                            DAL.Manager.copyfile(NewPathSource, path_dest_cdha + "\\" + NewDir, bHinhCDHA_OvweWrite, Trangthai);
                        }
                    }
                }
            }
        }
        private void DongBo_HinhBN()
        {
            DAL.Accessdata m = new DAL.Accessdata();
            string path_dest = m.get_DuongDan_HinhAnhBN();
            string path_src = "";
            for (int ii = 0; ii < list.Count; ii++)
            {
                path_src = list[ii].ImagePath_BN;
                if (path_src!=null && path_src!="" && System.IO.Directory.Exists(path_src))
                {
                    //copy hinh BN
                    DAL.Manager.copyfile(path_src, path_dest, bHinhBN_Overwrite, Trangthai);
                }
            }
        }

        private void DongBo_HinhChungtu()
        {
            DAL.Accessdata m = new DAL.Accessdata();
            string path_dest_bn = m.get_DuongDan_HinhAnhChungTu();
            string path_src = "";
            if (path_dest_bn != "" && System.IO.Directory.Exists(path_dest_bn))
            {
                for (int ii = 0; ii < list.Count; ii++)
                {
                    path_src = list[ii].ImagePath_Chungtu;
                    if (path_src!=null && path_src != "" && System.IO.Directory.Exists(path_src))
                    {
                        //copy hinh BN
                        DAL.Manager.copyfile(path_src, path_dest_bn, bHinhChungTu_Overwrite, Trangthai);
                    }
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            DongBo_HinhChungtu();
            syn_time.Start();
        }

        private void đồngBộTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDongbotheongay_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            load_table();
            txtText.Visible = true;
            proStatus.Visible = true;
            try
            {
                frmchonngay ff = new frmchonngay();
                ff.ShowDialog();
                Dongbo(0, ff.s_tu, ff.s_den);
            }
            catch { }
            syn_time.Start();
        }

        private void mnuChuyenlaiKQXN_Thangcu_Click(object sender, EventArgs e)
        {
            syn_time.Stop();
            frmDoingay f = new frmDoingay();
            f.ShowDialog();
            if (f.bChon)
            {
                string ammyy = f.mMmyy;
                Dongbo_lai_kqxn(ammyy);

            }

            syn_time.Start();
        }

        private void Dongbo_lai_kqxn(string mmyy)
        {
            
            this.Cursor = Cursors.WaitCursor;
            lblstatuss.Text = "Running ...";
            
            string schema = "", table = "", dieukien = "";
            //DataRow[] dtr = ((full == true) ? dsxml_chungtu.Tables[0].Select("lastday=1", "stt") : dsxml_chungtu.Tables[0].Select("lastday=0", "stt"));
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {
                schema = "medibv" + mmyy;
                table = "xn_ketqua";
                for (int ii = 0; ii < list.Count; ii++)
                {
                    //Kiểm tra xem schema có tồn tại không? 
                    if (acc.bShemaValid(schema))
                    {
                        Application.DoEvents();
                        statusServer.Text = list[ii].Host + "-" + list[ii].DatabaseName;
                        lblstatuss.Text = schema + "." + table;
                        
                        acc.update_lai_ketqua_xn(list[ii], schema, table, txtText, Trangthai, proStatus, ref dieukien);
                        statusServer.Text = "";
                        lblstatuss.Text = "";
                    }
                }
                this.Cursor = Cursors.Default;
                lblstatuss.Text = "Finished ";
            }
        }
    }
}