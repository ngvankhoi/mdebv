using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmChitietmiengiam : Form
    {
        private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string m_cur_yy = "";
        private DateTime m_cur_ngay = DateTime.Now;
        private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();        
        private string m_id = "", m_mavaovien = "", m_maql = "", m_userid = "";
        private TableLayoutPanel m_table;
        private frmTimbenhnhan m_frmtimbenhnhan;
        private DataSet ads_ct = new DataSet();

        public frmChitietmiengiam(string s_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);


            m_userid = s_userid;
            f_Load_Data();
            m_v.f_SetEvent(this);
        }

        private void frmChitietmiengiam_Load(object sender, EventArgs e)
        {
            f_Load_PChitiet();
            f_Enable(false);
            this.Refresh();
            butBoqua_Click(null, null);
            butMoi_Click(null, null);
        }
        private void f_Load_Data()
        {
            m_frmtimbenhnhan = new frmTimbenhnhan(m_v, m_userid);
            m_frmtimbenhnhan.ShowInTaskbar = false;

            string atmp = m_v.s_curmmyyyy;
            m_cur_ngay = m_v.f_parse_date(atmp);
            m_cur_yy = m_cur_ngay.Year.ToString().Substring(2);

            cbGioitinh.DataSource = m_v.get_data("select ma,ten from medibv.dmphai order by ma desc").Tables[0];
            cbGioitinh.DisplayMember = "ten";
            cbGioitinh.ValueMember = "ma";

            cbKymien.DataSource = m_v.get_data("select ma,ten from medibv.v_dsduyet order by ten desc").Tables[0];
            cbKymien.DisplayMember = "ten";
            cbKymien.ValueMember = "ma";
            

            cbLoaibn.DataSource = m_v.get_data("select id,ten from medibv.v_loaibn order by id").Tables[0];
            cbLoaibn.DisplayMember = "ten";
            cbLoaibn.ValueMember = "id";

            cbKhoaTD.DataSource = m_v.get_data("select makp,tenkp from medibv.btdkp_bv  order by makp").Tables[0];
            cbKhoaTD.DisplayMember = "tenkp";
            cbKhoaTD.ValueMember = "makp";

            cbDoituongTD.DataSource = m_v.get_data("select madoituong,doituong,field_gia,mien,mabv,sothe,ngay from medibv.doituong order by madoituong").Tables[0];
            cbDoituongTD.DisplayMember = "doituong";
            cbDoituongTD.ValueMember = "madoituong";

            cbTuoi.DataSource = m_v.f_get_dmtuoi().Tables[0];
            cbTuoi.DisplayMember = "ten";
            cbTuoi.ValueMember = "id";
           
        }
        private void f_Load_PChitiet()
        {
            try
            {           
                pCT.Controls.Clear();
                Label alb;
                Label albphantram;
                TextBox atb;

                m_table = new TableLayoutPanel();
                m_table.Name = "tableLayoutPanel_01";
                m_table.Text = "?";
                m_table.AutoScroll = true;
                m_table.BorderStyle = BorderStyle.None;
                m_table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
                m_table.BackColor = Color.Honeydew;
                
                m_table.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                m_table.AutoSize = true;

                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));

                DataSet ads = m_v.get_data("select a.id,a.viettat,a.ten from medibv.v_loaivp a order by a.ten");
                int ai = 0, arow = 0, acol = 0;
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    ai++;
                    m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));

                    alb = new Label();
                    alb.Name = "lbma_" + r["id"].ToString();
                    alb.Text = (r["viettat"].ToString().Trim() != "" ? r["viettat"].ToString().Trim() : r["ten"].ToString().Trim()) + ":";
                    toolTip1.SetToolTip(alb, r["ten"].ToString().Trim());
                    alb.AutoSize = true;
                    alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                    alb.TextAlign = ContentAlignment.MiddleRight;
                    m_table.Controls.Add(alb, acol, arow);

                    atb = new TextBox();
                    atb.Name = "tbma_" + r["id"].ToString();
                    atb.Text = "";
                    atb.BackColor = Color.White;
                    atb.Width = 70;

                    atb.Leave += new System.EventHandler(this.f_Control_Leave);
                    atb.Enter += new System.EventHandler(this.f_Control_Enter);
                    atb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                    atb.Validated += new System.EventHandler(this.txt_Validated);
                    atb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.f_Control_Keypress);
                    
                    atb.ReadOnly = false;
                    atb.TextAlign = HorizontalAlignment.Right;
                    m_table.Controls.Add(atb, acol + 1, arow);

                    albphantram = new Label();
                    albphantram.Text="%";
                    albphantram.AutoSize = true;
                    albphantram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                   // albphantram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                    albphantram.TextAlign = ContentAlignment.MiddleRight;
                    m_table.Controls.Add(albphantram, acol+2, arow);

                    arow++;
                }
                m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                alb = new Label();
                alb.Name = "_blank";
                alb.Text = "";
                alb.AutoSize = true;
                alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
                alb.TextAlign = ContentAlignment.MiddleRight;
                m_table.Controls.Add(alb, 0, ai);

                pCT.Controls.Add(m_table);
                m_table.Dock = DockStyle.Fill;
                m_table.BringToFront();
            }
            catch
            {
            }
            finally
            {
            }
        }
        private void f_Control_Keypress(object sender, System.EventArgs e)
        {
            foreach (Control c in m_table.Controls)
            {
                decimal asotien = 0;
                if (c.Name.IndexOf("tbma_") == 0)
                {
                    try
                    {
                        asotien = decimal.Parse(c.Text.Replace(",", ""));
                    }
                    catch
                    {
                        asotien = 0;
                    }
                    if (asotien < 0 || asotien > 100)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập từ 0->100"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        public void f_Control_Enter(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                c.BackColor = Color.LightYellow;
           
            }
            catch
            {
            }
        }
        public void f_Control_Leave(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                c.BackColor = Color.White;
            }
            catch
            {
            }
        }
        private void f_Control_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextBox atb = (TextBox)(sender);
                    if (atb == m_table.Controls[m_table.Controls.Count - 2])
                    {
                        butLuu.Focus();
                    }
                    else
                    {
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch
            {
            }
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMabn_Validated(null, null);
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtMabn1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtMabn1_Validated(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtMabn1.Text.Trim());
                if (i >= 0 && i <= 999999)
                {
                    txtMabn1.Text = i.ToString().PadLeft(6, '0');
                }
                else
                {
                    txtMabn1.Text = "";
                }
            }
            catch
            {
                txtMabn1.Text = "";
            }
            if (txtMabn.Text.Length == 2 && txtMabn1.Text.Length == 6)
            {
                f_Load_Hanhchanh(txtMabn.Text + txtMabn1.Text);
            }
        }
        private void f_Load_Hanhchanh(string v_mabn)
        {
            try
            {
                bool aok = false;
                string sql = "";               
                sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.phai,a.sonha,a.thon,a.cholam,b.tentt as tinh, c.tenquan as quan, d.tenpxa as xa from medibv.btdbn a left join medibv.btdtt b on a.matt=b.matt left join medibv.btdquan c on a.maqu=c.maqu left join medibv.btdpxa d on a.maphuongxa=d.maphuongxa where a.mabn='" + v_mabn + "'";
                f_Clear_HC();
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    txtHoten.Text = r["hoten"].ToString();
                    txtNgaysinh.Text = r["ngaysinh"].ToString();
                    if (txtNgaysinh.Text.Trim() == "null" || txtNgaysinh.Text.Trim() == "")
                    {
                        txtNgaysinh.Text = r["namsinh"].ToString();
                    }
                    cbGioitinh.SelectedValue = r["phai"].ToString();
                    txtDiachi.Text = r["sonha"].ToString().Trim();
                    if (r["thon"].ToString().Trim() != "")
                    {
                        if (r["sonha"].ToString().Trim() != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + " " + r["thon"].ToString().Trim();
                    }
                    if (r["xa"].ToString().Trim() != "" && r["xa"].ToString().Trim().ToLower() != "không xác định")
                    {
                        if (txtDiachi.Text != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + " " + r["xa"].ToString().Trim();
                    }
                    if (r["quan"].ToString().Trim() != "" && r["quan"].ToString().Trim().ToLower() != "không xác định")
                    {
                        if (txtDiachi.Text != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + " " + r["quan"].ToString().Trim();
                    }
                    if (r["tinh"].ToString().Trim() != "" && r["tinh"].ToString().Trim().ToLower() != "không xác định")
                    {
                        if (txtDiachi.Text != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + ", ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + " " + r["tinh"].ToString().Trim();
                    }

                    if (r["cholam"].ToString().Trim() != "")
                    {
                        if (txtDiachi.Text.Trim() != "")
                        {
                            txtDiachi.Text = txtDiachi.Text.Trim() + " ";
                        }
                        txtDiachi.Text = txtDiachi.Text.Trim() + "(" + r["cholam"].ToString().Trim() + ")";
                    }
                    txtDiachi.Text = txtDiachi.Text.Trim();

                    if (m_id == "")
                    {
                        f_Load_CB_Ngayvv("", "");
                    }
                    else
                    {
                        f_Load_CB_Ngayvv(txtNgaythu.Text.Substring(0, 10), m_maql);
                    }
                    if (cbNgayvv.Items.Count <= 0)
                    {
                        try
                        {
                            cbLoaibn.SelectedValue = "0";
                        }
                        catch
                        {
                        }
                        
                    }
                    txtNgaysinh_Validated(null, null);                    
                    aok = true;
                    break;
                }

                if (m_id == "" || m_id == "0")
                {
                    
                    if (cbNgayvv.Items.Count <= 0)
                    {
                        MessageBox.Show(this, lan.Change_language_MessageText("Không cho phép bệnh nhân chưa hoàn tất thủ tục!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        f_Enable_HC(false);
                        txtMabn.Focus();
                        return;
                    }
                    else
                    {
                        cbNgayvv_Validated(null, null);
                        f_Enable_HC(!aok);
                        txtKymien.Focus();
                    }
                }

            }
            catch
            {
            }
        }
        private void f_Enable_HC(bool v_bool)
        {
            try
            {                
                txtNgaythu.Enabled = false;                
                txtHoten.ReadOnly = !v_bool;
                txtNgaysinh.ReadOnly = !v_bool;
                txtTuoi.ReadOnly = !v_bool;
                cbTuoi.Enabled = v_bool;
                cbGioitinh.Enabled = v_bool;
                txtDiachi.ReadOnly = !v_bool;
                txtSothe.ReadOnly = !v_bool;
                txtTN.ReadOnly = !v_bool;
                txtDN.ReadOnly = !v_bool;
                txtNDK_Ma.ReadOnly = !v_bool;
                txtNDK_Ten.ReadOnly = !v_bool;
                cbLoaibn.Enabled = false;
                cbDoituongTD.Enabled = false;                
            }
            catch
            {
            }

        }
        private void f_Load_CB_Ngayvv(string v_tn, string v_maql)
        {
            try
            {
                string asql1 = "", amabn = "";
                amabn = txtMabn.Text + txtMabn1.Text;
                DateTime adt = txtNgaythu.Value;
                v_tn = m_v.f_string_date(v_tn);

                if (v_tn.Length >= 10)
                {
                    adt = m_v.f_parse_date(v_tn.Substring(0, 10));
                }

             
                if (tmn_Cotiepdon.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, maql as mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong, to_number(0,9) as loaibn from medibvmmyy.tiepdon where mabn='" + amabn + "' and to_char(ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                }
                if (tmn_Cokhambenh.Checked)
                {
                    if (asql1 != "")
                    {
                        asql1 += " union all ";
                    }
                    asql1 += "select maql, mavaovien,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, to_char(ngay,'yyyymmddhh24:mi') as ngay1, makp,madoituong,to_number(3,9) as loaibn  from medibvmmyy.benhanpk where mabn='" + amabn + "' and to_char(ngay,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
                }


                DataSet  ads1 = null;
                if (asql1 != "")
                {
                    asql1 += "  order by ngay desc";
                    ads1 = m_v.get_data_bc(adt.AddMonths(-1), txtNgaythu.Value.AddMonths(1), asql1);
                }



                cbNgayvv.DataSource = ads1.Tables[0];
                cbNgayvv.DisplayMember = "ngay";
                cbNgayvv.ValueMember = "maql";
                if (v_maql != "")
                {
                    try
                    {
                        cbNgayvv.SelectedValue = v_maql;
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void f_Clear_HC()
        {
            try
            {

                txtHoten.Text = "";
                txtNgaysinh.Text = "";
                txtTuoi.Text = "";
                try
                {
                    cbTuoi.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    cbGioitinh.SelectedIndex = 0;
                }
                catch
                {
                }
                txtDiachi.Text = "";
                txtSothe.Text = "";

                txtTN.Text = "";
                txtDN.Text = "";
                txtNDK_Ma.Text = "";
                txtNDK_Ten.Text = "";                
                txtKhoaTD.Text = "";
                try
                {
                    cbLoaibn.SelectedValue = "0";
                }
                catch
                {
                }
                try
                {
                    cbDoituongTD.SelectedValue = 2;
                }
                catch
                {
                }
                
                try
                {
                    cbKhoaTD.SelectedIndex = -1;
                }
                catch
                {
                }                
                try
                {
                    cbNgayvv.DataSource = null;
                    cbNgayvv.SelectedIndex = -1;
                }
                catch
                {
                }                
            }
            catch
            {
            }
        }
        private void txtMabn_Validated(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtMabn.Text.Trim());
                if (i >= 0 && i <= 99)
                {
                    txtMabn.Text = i.ToString().PadLeft(2, '0');
                }
                else
                {
                    txtMabn.Text = m_v.s_curyy;
                }
            }
            catch
            {
                txtMabn.Text = m_v.s_curyy;
            }
        }

        private void txtMabn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtMabn.Text = txtMabn.Text.Trim();
            }
            catch
            {
            }
        }

        private void txtMabn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtMabn1.Text = txtMabn1.Text.Trim();
            }
            catch
            {
            }
        }

        private void txtNgaysinh_Validated(object sender, EventArgs e)
        {
            try
            {
                string atmp = m_v.tinhtuoi(txtNgaysinh.Text, 300);
                //ngay_or_nam:tuoi:thang:ngay
                txtNgaysinh.Text = "";
                txtTuoi.Text = "";
                if (atmp.Split(':')[0] != "?")
                {
                    txtNgaysinh.Text = atmp.Split(':')[0];
                }
                if (atmp.Split(':')[1] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[1];
                    cbTuoi.SelectedValue = "1";
                }
                if (atmp.Split(':')[2] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[2];
                    cbTuoi.SelectedValue = "2";
                }
                if (atmp.Split(':')[3] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[3];
                    cbTuoi.SelectedValue = "3";
                }
            }
            catch
            {
            }
        }

        private void txtNgaysinh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNgaysinh_Validated(null, null);
                    if (txtNgaysinh.Text != "")
                    {
                        cbGioitinh.Focus();
                        SendKeys.Send("{F4}");
                    }
                    else
                    {
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch
            {
            }
        }

        private void txtTuoi_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTuoi_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal atuoi = decimal.Parse(txtTuoi.Text);
                if (atuoi < 0)
                {
                    atuoi = 0;
                }
                txtTuoi.Text = atuoi.ToString("####");
            }
            catch
            {
                txtTuoi.Text = "1";
            }
        }

        private void cbTuoi_Validated(object sender, EventArgs e)
        {
            try
            {
                string atmp = "";
                txtTuoi_Validated(null, null);
                if (txtTuoi.Text != "")
                {
                    atmp = m_v.tinhngay(txtTuoi.Text, cbTuoi.SelectedValue.ToString());
                }
                else
                {
                    atmp = m_v.tinhtuoi(txtNgaysinh.Text, 300);
                }
                //ngay_or_nam:tuoi:thang:ngay
                //MessageBox.Show(atmp);
                //txtNgaysinh.Text = "";
                txtTuoi.Text = "";
                if (atmp.Split(':')[0] != "?")
                {
                    if (txtNgaysinh.Text.Length < 10)
                    {
                        if (atmp.Split(':')[0].Length == 10)
                        {
                            txtNgaysinh.Text = atmp.Split(':')[0].Split('/')[2];
                        }
                        else
                        {
                            txtNgaysinh.Text = atmp.Split(':')[0];
                        }
                    }
                }
                if (atmp.Split(':')[1] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[1];
                    cbTuoi.SelectedValue = "1";
                }
                if (atmp.Split(':')[2] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[2];
                    cbTuoi.SelectedValue = "2";
                }
                if (atmp.Split(':')[3] != "?")
                {
                    txtTuoi.Text = atmp.Split(':')[3];
                    cbTuoi.SelectedValue = "3";
                }
            }
            catch
            {
                txtNgaysinh.Text = "";
            }
        }

        private void cbGioitinh_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSothe_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSothe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtChieudaithe.Text = txtSothe.Text.Length.ToString();
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

        private void txtNDK_Ma_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNDK_Ten_KeyDown(object sender, KeyEventArgs e)
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

        private void cbNgayvv_KeyDown(object sender, KeyEventArgs e)
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
        private void cbNgayvv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[cbNgayvv.DataSource]);
                DataView dv = (DataView)(cm.List);
                m_mavaovien = "";
                m_maql = "";

                foreach (DataRow r in dv.Table.Select("maql=" + cbNgayvv.SelectedValue.ToString()))
                {


                    cbLoaibn.SelectedValue = r["loaibn"].ToString();

                    cbKhoaTD.SelectedValue = r["makp"].ToString();
                   
                    cbDoituongTD.SelectedValue = r["madoituong"].ToString();
                    m_mavaovien = decimal.Parse(r["mavaovien"].ToString()).ToString();
                    m_maql = decimal.Parse(r["maql"].ToString()).ToString();

                    break;
                }                
            }
            catch
            {
                m_mavaovien = "";
                m_maql = "";
            }
        }

        private void cbNgayvv_Validated(object sender, EventArgs e)
        {
            try
            {
                cbNgayvv_SelectedIndexChanged(null, null);
                f_Load_BHYT();                
            }
            catch
            {
            }
        }
        private void f_Load_BHYT()
        {
            try
            {
                txtSothe.Text = "";
                txtTN.Text = "";
                txtDN.Text = "";
                txtNDK_Ma.Text = "";
                txtNDK_Ten.Text = "";
                string amaql = "", atn = "";
                try
                {
                    amaql = decimal.Parse(cbNgayvv.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    return;
                }
                atn = m_v.f_string_date(atn);
                if (atn.Length >= 10)
                {
                    atn = atn.Substring(0, 10);
                }
                else
                {
                    atn = txtNgaythu.Text.Substring(0, 10);
                }
                string sql = "";
                sql = "select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tn, to_char(a.denngay,'dd/mm/yyyy') as dn,a.mabv,b.tenbv,a.maphu from medibv.bhyt a left join medibv.dmnoicapbhyt b on a.mabv=b.mabv where a.maql = " + amaql;
                sql += " union all select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tn, to_char(a.denngay,'dd/mm/yyyy') as dn,a.mabv,b.tenbv,a.maphu from medibvmmyy.bhyt a left join medibv.dmnoicapbhyt b on a.mabv=b.mabv where a.maql = " + amaql;
                foreach (DataRow r in m_v.get_data_bc_1(atn, txtNgaythu.Text.Substring(0, 10), sql, 1).Tables[0].Rows)
                {
                    txtSothe.Text = r["sothe"].ToString();
                    txtTN.Text = r["tn"].ToString();
                    txtDN.Text = r["dn"].ToString();
                    txtNDK_Ma.Text = r["mabv"].ToString();
                    txtNDK_Ten.Text = r["tenbv"].ToString();
                    break;
                }
            }
            catch
            {
            }
        }
        private void cbLoaibn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void cbDoituongTD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void cbKhoaTD_KeyDown(object sender, KeyEventArgs e)
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

        private void cbKhoaTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKhoaTD.Text = cbKhoaTD.SelectedValue.ToString();
            }
            catch
            {
            }
        }

        private void txtHoten_KeyDown(object sender, KeyEventArgs e)
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

        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void f_Moi()
        {
            try
            {                              
                m_id = "";
                m_mavaovien = "";
                m_maql = "";
                
                f_Clear_HC();
                f_Enable(true);
                f_Enable_HC(true);
                txtNgaythu.Value = m_cur_ngay;
                cbNgayvv.DataSource = null;                                   
                txtMabn.Text = m_cur_yy;
                txtMabn1.Text = "";
                txtSotien.Text = "0";
                txtMabn.Focus();
                cbKymien.SelectedIndex = -1;
                txtKymien.Text = "";
                f_Clear_pTonghop();
                f_Load_Gird();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void f_Clear_pTonghop()
        {
            try
            {
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        c.Text = "";
                        c.BackColor = (c.Text != "") ? Color.LightYellow : Color.White;
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Load_Gird()
        {
            string sql = "select id,a.mabn,hoten,namsinh,case when phai=0 then 'Nữ' else 'Nam' end as phai,c.tenkp, d.ten as nguoiduyet from medibv.v_tylegiamll a,medibv.btdbn b,medibv.btdkp_bv c,medibv.v_dsduyet d where a.mabn=b.mabn and a.makp=c.makp and a.maduyet=d.ma and to_char(ngayvao,'dd/mm/yyyy')='" + txtNgaythu.Text.Substring(0, 10) + "'";
            dgDanhsach.DataSource = m_v.get_data(sql).Tables[0];
        }
        private void f_Enable(bool v_bool)
        {
            try
            {
                butMoi.Enabled = !v_bool;
                butLuu.Enabled = v_bool;                
                butSua.Enabled = !v_bool && m_id != "" && m_id != "0";
                butXoa.Enabled = !v_bool && m_id != "" && m_id != "0";
                butBoqua.Enabled = true;                
                butKetthuc.Enabled = !v_bool;
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        TextBox atb = (TextBox)(c);
                        atb.ReadOnly = !v_bool;
                    }
                }
            }
            catch
            {
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_Enable_HC(false);
            f_Enable(false);
            butMoi.Focus();
        }

        private void txtKymien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == txtKymien)
                {
                    cbKymien.SelectedValue = txtKymien.Text;
                }
            }
            catch
            {
            }
        }

        private void txtKymien_KeyDown(object sender, KeyEventArgs e)
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

        private void cbKymien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKymien.Text = cbKymien.SelectedValue.ToString();
            }
            catch
            {
            }
        }

        private void cbKymien_KeyDown(object sender, KeyEventArgs e)
        {
            //txtKymien.Text = cbKymien.SelectedValue.ToString();
            //m_table.Controls[1].Focus();
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
        private void txt_Validated(object sender, EventArgs e)
        {            
            f_Tinhtien();
        }
  
        private void butLuu_Click(object sender, EventArgs e)
        {
            f_Luu();
        }
        private void f_Tinhtien()
        {
            try
            {
                decimal asotien = 0, asotienct = 0;
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        try
                        {
                            asotienct = decimal.Parse(c.Text.Replace(",", ""));
                        }
                        catch
                        {
                            asotienct = 0;
                        }
                        if (asotienct < 0)
                        {
                            asotienct = 0;
                        }
                        c.Text = asotienct.ToString("###,###,###");
                        asotien += asotienct;                    
                    }
                }
                txtSotien.Text = asotien.ToString("###,###,##0");
            }
            catch
            {
                txtSotien.Text = "0";
            }
        }
        private void f_Luu()
        {
            bool asua = (m_id != "" && m_id != "0");            
            butLuu.Enabled = false;

            if (cbNgayvv.SelectedIndex < 0)
            {
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Bệnh nhân này chưa qua tiếp đón. !"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbNgayvv.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            if (cbKymien.SelectedIndex < 0)
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Vui lòng chọn người ký miễn!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbKymien.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            string aid = "",angay = "", amabn = "",amakp = "";
            angay = txtNgaythu.Text.Substring(0, 16);            
            aid = m_id;
            try
            {
                aid = decimal.Parse(m_id).ToString();
            }
            catch
            {
                aid = "0";
            }
            amabn = txtMabn.Text.Trim() + txtMabn1.Text.Trim();
            if (amabn.Length != 8)
            {
                butLuu.Enabled = true;
                MessageBox.Show(this, lan.Change_language_MessageText("Nhập thông tin bệnh nhân!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMabn.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            try
            {
                amakp = cbKhoaTD.SelectedValue.ToString();
            }
            catch
            {
                amakp = "00";
            }

            if (txtSotien.Text == "0")
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Nhập số tiền chi tiết!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_table.Controls[1].Focus();
                return;
            }
            else
            {
                aid = m_v.upd_v_tylegiamll(decimal.Parse(aid), amabn,decimal.Parse(m_mavaovien), cbNgayvv.Text.Substring(0, 10), amakp, decimal.Parse(txtKymien.Text), decimal.Parse(m_userid));

                m_id = aid;
                if (m_id == "0")
                {
                    f_Enable(true);
                    f_Enable_HC(true);
                    MessageBox.Show(this, lan.Change_language_MessageText("Lỗi lưu dữ liệu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    m_v.execute_data("delete from medibv.v_tylegiamct where id=" + aid);
                    decimal asotienct = 0;
                    foreach (Control c in m_table.Controls)
                    {
                        if (c.Name.IndexOf("tbma_") == 0)
                        {
                            try
                            {
                                asotienct = decimal.Parse(c.Text.Replace(",", ""));
                            }
                            catch
                            {
                                asotienct = 0;
                            }
                            if (asotienct > 0)
                            {
                                m_v.upd_v_tylegiamct(decimal.Parse(aid), decimal.Parse(c.Name.Replace("tbma_", "")), asotienct);
                            }
                        }
                    }
                }
                f_Enable(false);
                f_Enable_HC(false);
                f_Load_Gird();
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView arv = (DataRowView)(dgDanhsach.CurrentRow.DataBoundItem);          

            txtMabn.Text = arv["mabn"].ToString().Substring(0, 2);
            txtMabn1.Text = arv["mabn"].ToString().Substring(2);

            f_Load_MG(arv["id"].ToString());

        }
        private void f_Load_MG(string s_id)
        {
            try
            {  
                try
                {
                    m_id = s_id;
                }
                catch
                {
                }
                txtMabn1_Validated(null, null);
                ads_ct = m_v.get_data("select * from medibv.v_tylegiamct where id=" + m_id + "");
                foreach (DataRow r in m_v.get_data("select * from medibv.v_tylegiamll where id=" + m_id + "").Tables[0].Rows)
                {
                    cbKymien.SelectedValue = r["maduyet"].ToString();
                }
                decimal asotienct = 0, atongtien = 0;
                foreach (DataRow r in ads_ct.Tables[0].Rows)
                {
                    atongtien += decimal.Parse(ads_ct.Tables[0].Rows[0]["tyle"].ToString());
                }
                txtSotien.Text = atongtien.ToString("###,###,###");
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        try
                        {
                            asotienct = decimal.Parse(ads_ct.Tables[0].Select("id_loaivp=" + c.Name.Replace("tbma_", ""))[0]["tyle"].ToString());
                        }
                        catch
                        {
                            asotienct = 0;
                        }
                        c.Text = asotienct.ToString("###,###,###");
                        TextBox atb = (TextBox)(c);
                        atb.ReadOnly = true;
                    }
                }
                f_Enable(m_id == "" || m_id == "0");
            }
            catch
            {
            }
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            f_Enable(true);
            f_Enable_HC(false);
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                m_v.execute_data("delete from medibv.v_tylegiamll where id="+m_id+"");
                m_v.execute_data("delete from medibv.v_tylegiamct where id=" + m_id + "");
                f_Load_Gird();
                f_Clear_HC();
                f_Enable(false);
                f_Enable_HC(false);
                butMoi.Focus();
            }
            catch
            { 
            }
        }

        private void tmn_Timbenhnhan_Click(object sender, EventArgs e)
        {
            try
            {
                m_frmtimbenhnhan.s_ngay = txtNgaythu.Value;
                if (m_frmtimbenhnhan.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmtimbenhnhan.s_mabn != "")
                    {
                        string atmp = m_frmtimbenhnhan.s_mabn;
                        txtMabn.Text = atmp.Substring(0, 2);
                        txtMabn1.Text = atmp.Substring(2);
                        txtMabn1_Validated(null, null);
                    }
                }
            }
            catch
            {
            }
        }
    }
}