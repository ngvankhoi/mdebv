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
    public partial class frmSuadoituongtamung : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private AccessData m_v;
        private CurrencyManager objStudentCM;
        private DataGridTableStyle ts;

        private DataSet ds = new DataSet();
        private DataSet dsngay = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable dtloaibn = new DataTable();
        private DataTable dtgia = new DataTable();
        private DataTable dtkp = new DataTable();

        private decimal l_maql, l_idkhoa, maql_phongluu,l_mavaovien;
        private int i_loaiba;
        private bool b_ndot, bVienphi_phongluu = false;
        private DataRow r;
        private string s_makp = "", sql, s_ngayvao;

        public frmSuadoituongtamung(AccessData v_v)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m_v = v_v;
            i_loaiba = 1;
        }

        private void frmSuadoituongtamung_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            dtkp = m_v.get_data("select * from medibv.btdkp_bv").Tables[0];
            theo.SelectedIndex = 0;
            ena_madt();
            b_ndot = m_v.bThanhtoan_khoa;
            ngayvv.Enabled = b_ndot;

            sql = "select 0 as loai,id,gia_th,gia_bh,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_dv,vattu_nn,bhyt,to_char(ngayud,'yyyymmddhh24mi') as ngaygio,to_char(ngayud,'yyyymmdd') as ngay from medibv.v_giavp_luu";
            sql += " union all ";
            sql += "select 1 as loai,id,gia_th,gia_bh,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_dv,vattu_nn,bhyt,to_char(ngayud,'yyyymmddhh24mi') as ngaygio,to_char(ngayud,'yyyymmdd') as ngay from medibv.v_giavp";
            dtgia = m_v.get_data(sql).Tables[0];
            dt = m_v.get_data("select * from medibv.doituong order by madoituong").Tables[0];

            //cboLoaiBN.DisplayMember = "TEN";
            //cboLoaiBN.DisplayMember = "ID";
            //cboLoaiBN.DataSource = m_v.get_data("select id, ten from medibv.v_loaibn order by id").Tables[0];

            cboLoaibnMoi.DisplayMember = "TEN";
            cboLoaibnMoi.ValueMember = "ID";
            load_loaibnmoi();

            madtcu.DisplayMember = "DOITUONG";
            madtcu.ValueMember = "MADOITUONG";
            madtcu.DataSource = dt;

            madtmoi.DisplayMember = "DOITUONG";
            madtmoi.ValueMember = "MADOITUONG";
            load_madtmoi();

            dsngay.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
            ngayvao.DisplayMember = "NGAYVAO";
            ngayvao.ValueMember = "NGAYVAO";
            ngayvao.DataSource = dsngay.Tables[0];
            ds.ReadXml("..\\..\\..\\xml\\m_suamadt.xml");
            butTiep_Click(null, null);
            AddGridTableStyle();
           
        }

        private void AddGridTableStyle()
        {
            int IntAvgCharWidth;
            ts = new DataGridTableStyle();
            IntAvgCharWidth = (int)(System.Drawing.Graphics.FromHwnd(this.Handle).MeasureString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", this.Font).Width / 26);
            objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
            ts.MappingName = ds.Tables[0].TableName;

            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;

            ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["ngay"]));
            ts.GridColumnStyles[0].MappingName = "ngay";
            ts.GridColumnStyles[0].HeaderText = "Ngày";
            ts.GridColumnStyles[0].Width = 70;
            ts.ReadOnly = true;
            ts.GridColumnStyles[0].Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles[0].NullText = string.Empty;

            ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["sotien"]));
            ts.GridColumnStyles[1].MappingName = "sotien";
            ts.GridColumnStyles[1].HeaderText = "";
            ts.GridColumnStyles[1].Width = 0;
            ts.ReadOnly = true;
            ts.GridColumnStyles[1].Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles[1].NullText = string.Empty;

            ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["dvt"]));
            ts.GridColumnStyles[2].MappingName = "dvt";
            ts.GridColumnStyles[2].HeaderText = "";
            ts.GridColumnStyles[2].Width = 0;
            ts.ReadOnly = true;
            ts.GridColumnStyles[2].Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles[2].NullText = string.Empty;

            ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["ten"]));
            ts.GridColumnStyles[3].MappingName = "ten";
            ts.GridColumnStyles[3].HeaderText = "Số tiền";
            ts.GridColumnStyles[3].Width = 100;
            ts.ReadOnly = true;
            ts.GridColumnStyles[3].Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles[3].NullText = string.Empty;
            
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["doituongcu"]));
            ts.GridColumnStyles[4].MappingName = "doituongcu";
            ts.GridColumnStyles[4].HeaderText = "Đối tượng củ";
            ts.GridColumnStyles[4].Width = 120;
            ts.ReadOnly = true;
            ts.GridColumnStyles[4].Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles[4].NullText = string.Empty;

            ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dt, 1, 1));
            ts.GridColumnStyles[5].MappingName = "doituong";
            ts.GridColumnStyles[5].HeaderText = "Đối tượng mới";
            ts.GridColumnStyles[5].Width = 200;
            ts.GridColumnStyles[5].Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles[5].NullText = string.Empty;
            dataGrid1.CaptionText = string.Empty;

            ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["kp"]));
            ts.GridColumnStyles[6].MappingName = "kp";
            ts.GridColumnStyles[6].HeaderText = "Khoa";
            ts.GridColumnStyles[6].Width = 235;
            ts.ReadOnly = true;
            ts.GridColumnStyles[6].Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles[6].NullText = string.Empty;

            dataGrid1.DataSource = ds;
            dataGrid1.DataMember = ds.Tables[0].TableName;
            dataGrid1.TableStyles.Add(ts);
        }
        private void load_madtmoi()
        {
            sql = "select * from medibv.doituong where madoituong<>" + int.Parse(madtcu.SelectedValue.ToString()) + " order by madoituong";
            madtmoi.DataSource = m_v.get_data(sql).Tables[0];
        }
        private void load_loaibnmoi()
        {
            //sql = "select * from medibv.v_loaibn where id<>" + int.Parse(cboLoaiBN.SelectedValue.ToString()) + " order by id";
            //cboLoaibnMoi.DataSource = m_v.get_data(sql).Tables[0];
        }
        private void ena_madt()
        {
            madtcu.Enabled = theo.SelectedIndex == 0;
            madtmoi.Enabled = madtcu.Enabled;
        }

        private void ngayvao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == ngayvao)
            {
                if (ngayvao.Items.Count > 0)
                {
                    ngayra.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString().Substring(0, 10);
                    makp.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
                    tenkp.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
                    l_maql = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
                    l_idkhoa = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["idkhoa"].ToString());
                    ngayvv.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(0, 10);
                }
            }
        }

        private void ngayra_Validated(object sender, EventArgs e)
        {
            if (ngayra.Text.Trim().Length != 10) return;
            ngayra.Text = ngayra.Text.Trim();
            if (ngayra.Text.Length == 6) ngayra.Text = ngayra.Text + DateTime.Now.Year.ToString();
            if (ngayra.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ !"), m_v.s_AppName);
                ngayra.Focus();
                return;
            }
            if (!m_v.bNgay(ngayra.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"),m_v.s_AppName);
                ngayra.Focus();
                return;
            }
            ngayra.Text = m_v.Ktngaygio(ngayra.Text, 10);
        }

        private void theo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == theo) ena_madt();
        }

        private void madtcu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == madtcu) load_madtmoi();		
        }

        private void mabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void mabn_Validated(object sender, EventArgs e)
        {
            int i = 0; decimal o_maql;
            hoten.Text = ""; l_maql = 0; l_idkhoa = 0; dsngay.Clear();
            if (mabn.Text == "" || mabn.Text.Trim().Length < 3) return;
            if (mabn.Text.Trim().Length != 8) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
            if (b_ndot)
            {
                sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,a.id,a.giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy hh24:mi'),to_char(b.ngay,'dd/mm/yyyy hh24:mi')) ngayra,a.makp,d.tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa,nvl(b.mabs,a.mabs) as mabs ";
                sql += " from medibv.nhapkhoa a left join medibv.xuatkhoa b on a.id=b.id inner join medibv.btdbn c on a.mabn=c.mabn inner join medibv.btdkp_bv d on a.makp=d.makp left join medibv.btdtt e on c.matt=e.matt left join medibv.btdquan f on c.maqu=f.maqu left join medibv.btdpxa g on c.maphuongxa=g.maphuongxa inner join medibv.benhandt h on a.maql=h.maql ";
                sql += " where a.mabn='" + mabn.Text + "' and h.loaiba=" + i_loaiba;
                if (s_makp != "") sql += " and a.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
                sql += " order by a.id desc";
            }
            else
            {
                sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 id,' ' giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy hh24:mi'),to_char(b.ngay,'dd/mm/yyyy hh24:mi')) ngayra,decode(b.makp,null,a.makp,b.makp) makp,decode(b.makp,null,h.tenkp,d.tenkp) tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa,nvl(b.mabs,a.mabs) as mabs ";
                sql += " from medibv.benhandt a left join medibv.xuatvien b on a.maql=b.maql  inner join medibv.btdbn c on a.mabn=c.mabn left join medibv.btdkp_bv d on b.makp=d.makp   left join medibv.btdtt e on c.matt=e.matt left join medibv.btdquan f on c.maqu=f.maqu left join medibv.btdpxa g on c.maphuongxa=g.maphuongxa inner join medibv.btdkp_bv h on a.makp=h.makp";
                sql += " where a.mabn='" + mabn.Text + "' and a.loaiba=" + i_loaiba + " order by a.maql desc";
            }
            foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
            {
                if (i == 0)
                {
                    hoten.Text = r["hoten"].ToString();
                    namsinh.Text = r["namsinh"].ToString();
                    s_ngayvao = r["ngayvao"].ToString();
                    ngayra.Text = r["ngayra"].ToString().Substring(0, 10);
                    diachi.Text = r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim();
                    makp.Text = r["makp"].ToString();
                    tenkp.Text = r["tenkp"].ToString();
                    l_maql = decimal.Parse(r["maql"].ToString());
                    l_idkhoa = decimal.Parse(r["id"].ToString());
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                }
                o_maql = decimal.Parse(r["maql"].ToString());
                m_v.updrec_ravien(dsngay, mabn.Text, o_maql, decimal.Parse(r["id"].ToString()),
                    hoten.Text, r["namsinh"].ToString(), (r["phai"].ToString() == "0") ? "Nam" : "Nữ", r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + ", " + r["tenpxa"].ToString().Trim() + ", " + r["tenquan"].ToString().Trim() + ", " + r["tentt"].ToString().Trim(),
                    0, "", "", "", "", "", "", r["giuong"].ToString(), r["makp"].ToString(), r["tenkp"].ToString(), r["ngayvao"].ToString(), r["ngayra"].ToString(), r["chandoan"].ToString(), r["maicd"].ToString(), "", 0, 0, 0, "", r["mabs"].ToString(), "", "", true, "", "", "");
                i++;
            }
            if (l_maql == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"), m_v.s_AppName);
                mabn.Focus();
            }
            else ngayvao.SelectedValue = s_ngayvao;
            if (ngayvao.SelectedIndex != -1) ngayvv.Text = ngayvao.Text.Substring(0, 10);
        }

        private void ngayvao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void ngayvv_Validated(object sender, EventArgs e)
        {
            if (ngayvv.Text == "")
            {
                ngayvv.Focus();
                return;
            }
            ngayvv.Text = ngayvv.Text.Trim();
            if (ngayvv.Text.Length == 6) ngayvv.Text = ngayvv.Text + DateTime.Now.Year.ToString();
            if (ngayvv.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),m_v.s_AppName);
                ngayvv.Focus();
                return;
            }
            if (!m_v.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),m_v.s_AppName);
                ngayvv.Focus();
                return;
            }
            ngayvv.Text = m_v.Ktngaygio(ngayvv.Text, 10);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ena_but(false);
            butSua.Enabled = true;
        }
        private void ena_but(bool ena)
        {
            butTiep.Enabled = !ena;
            butSua.Enabled = ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butKetthuc.Enabled = !ena;
        }

        private void butTiep_Click(object sender, EventArgs e)
        {
            ds.Clear();
            mabn.Text = "";
            hoten.Text = "";
            namsinh.Text = "";
            ngayra.Text = m_v.Ngaygio_hienhanh.Substring(0, 10);
            tenkp.Text = "";
            makp.Text = "";
            diachi.Text = "";
            l_maql = 0; l_idkhoa = 0;
            ena_but(true);
            mabn.Focus();
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            if (ngayra.Text.Trim().Length != 10)
            {
                ngayra.Focus();
                return;
            }
         
            if (m_v.get_done_thvp(ngayra.Text, mabn.Text, l_maql, l_idkhoa, ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh")+" \n" + hoten.Text + "\n" + ngayvv.Text + "\n"+lan.Change_language_MessageText("đã chuyển xuống viện phí !"), m_v.s_AppName);
                mabn.Focus();
                return;
            }
            m_v.execute_data("delete from medibv.d_suamadt");
            load_tamung();
            ds = m_v.get_data("select * from medibv.d_suamadt order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
            objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
            ts.MappingName = ds.Tables[0].TableName;
            dataGrid1.DataSource = ds;
            dataGrid1.DataMember = ds.Tables[0].TableName;
            ena_but(true);
            butSua.Enabled = false;
        }
        private void load_tamung()
        {
            DateTime dt1 = m_v.StringToDate(ngayvv.Text.Substring(0, 10));
            DateTime dt2 = m_v.StringToDate(ngayra.Text.Substring(0, 10));
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (m_v.bMmyy(mmyy))
                    {
                        sql = "select " + mmyy + " mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay,0 makp,a.madoituong,0 ma,to_char(a.sotien,'999,999,999,999') as ten,'' as dvt,a.sotien soluong,d.doituong doituongcu,d.doituong,0 bhyt,a.sotien,0 giaban,e.tenkp kp,a.sotien giamua ";
                        sql += " from " + m_v.user + mmyy + ".v_tamung a," + m_v.user + ".doituong d," + m_v.user + ".btdkp_bv e";
                        sql += " where a.madoituong=d.madoituong and a.makp=e.makp";
                        sql += " and a.done=0 and a.mabn='" + mabn.Text + "'";
                        if (l_idkhoa != 0)
                        {
                            if (b_ndot) sql += " and a.idkhoa=" + l_idkhoa;
                            sql += " and to_date(a.ngay,'dd/mm/yyyy') between to_date('" + ngayvv.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + ngayra.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                        }
                        sql += " and a.maql=" + l_maql;
                        sql += " order by to_char(a.ngay,'yyyymmdd')";
                        m_v.execute_data("insert into medibv.d_suamadt " + sql);
                        if (bVienphi_phongluu)
                        {
                            maql_phongluu = m_v.get_maql_benhancc(l_mavaovien.ToString(), mabn.Text.Trim(), ngayvv.Text);
                            if (maql_phongluu != 0)
                            {
                                sql = "select " + mmyy + " mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay,0 makp,a.madoituong,0 ma,to_char(a.sotien,'999,999,999,999') ten,'' dvt,a.sotien soluong,d.doituong doituongcu,d.doituong,0 bhyt,a.sotien,0 giaban,e.tenkp kp,a.sotien giamua ";
                                sql += " from " + m_v.user + mmyy + ".v_tamung a," + m_v.user + ".doituong d," + m_v.user + ".btdkp_bv e";
                                sql += " where a.madoituong=d.madoituong and a.makp=e.makp";
                                sql += " and a.done=0 and a.mabn='" + mabn.Text + "'";
                                sql += " and a.maql=" + maql_phongluu;
                                if (m_v.bThanhtoan_khoa) sql += " and to_date(a.ngay,'dd/mm/yyyy') between to_date('" + m_v.DateToString("dd/MM/yyyy", m_v.StringToDate(ngayvv.Text.Substring(0, 10)).AddDays(-1)) + "','dd/mm/yyyy') and to_date('" + ngayvv.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                                sql += " order by to_char(a.ngay,'yyyymmdd')";
                                m_v.execute_data("insert into medibv.d_suamadt " + sql);
                            }
                        }
                    }
                }
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (ngayra.Text == "")
            {
                ngayra.Focus();
                return;
            }
         
            if (m_v.get_done_thvp(ngayra.Text, mabn.Text, l_maql, l_idkhoa, ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh")+" \n" + hoten.Text + "\n" + ngayvv.Text + "\n"+lan.Change_language_MessageText("đã chuyển xuống viện phí !"), m_v.s_AppName);
                mabn.Focus();
                return;
            }
            if (theo.SelectedIndex == 0) //tonghop
                foreach (DataRow r1 in ds.Tables[0].Select("madoituong=" + int.Parse(madtcu.SelectedValue.ToString())))
                    m_v.execute_data_mmyy(r1["mmyy"].ToString().PadLeft(4, '0'), "update medibvmmyy.v_tamung set madoituong=" + int.Parse(madtmoi.SelectedValue.ToString()) + " where id=" + decimal.Parse(r1["id"].ToString()));
            else
                foreach (DataRow r1 in ds.Tables[0].Select("doituongcu<>doituong"))
                {
                    r = m_v.getrowbyid(dt, "doituong='" + r1["doituong"].ToString() + "'");
                    if (r != null)
                        m_v.execute_data_mmyy(r1["mmyy"].ToString().PadLeft(4, '0'), "update medibvmmyy.v_tamung set madoituong=" + int.Parse(r["madoituong"].ToString()) + " where id=" + decimal.Parse(r1["id"].ToString()));
                }
            ena_but(false);
            butSua.Enabled = true;
            m_v.upd_dasuamadt("",l_maql, l_idkhoa);
        }

        private void ngayvv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void ngayra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void makp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void tenkp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void theo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void madtcu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void madtmoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

    }
}