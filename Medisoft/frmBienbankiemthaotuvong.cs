using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmBienbankiemthaotuvong : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private DataSet dsbs = new DataSet();
        private DataTable dticd = new DataTable();

        private DataSet ads;
        private string sql = "", ngay_VV = "", m_userid = "";

        public frmBienbankiemthaotuvong(string s_userid)
        {
            InitializeComponent();
            m_userid = s_userid;
        }
        private void load_dm()
        {
            ads = new DataSet();
            ads.ReadXml("..//..//..//xml//m_bienbankienthaotuvong.xml");           

            dsbs = m.get_data("select * from medibv.dmbs order by ma");
            listChutoa.DisplayMember = "MA";
            listChutoa.ValueMember = "HOTEN";
            listChutoa.DataSource = dsbs.Tables[0];

            dticd = m.get_data("select cicd10,vviet from medibv.icd10 order by cicd10").Tables[0];
            listICD.DisplayMember = "CICD10";
            listICD.ValueMember = "VVIET";
            listICD.DataSource = dticd;

            phai.DisplayMember = "TEN";
            phai.ValueMember = "MA";
            phai.DataSource = m.get_data("select * from medibv.dmphai").Tables[0];

            nn.DisplayMember = "tennn";
            nn.ValueMember = "mann";
            nn.DataSource = m.get_data("select * from medibv.btdnn_bv order by mann").Tables[0];
            ngay_VV = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Now);
            ngayvv.Text = ngay_VV.Substring(0, 10);
            giovv.Text = ngay_VV.Substring(11);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }
        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listChutoa.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txtChutoa_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtChutoa)
            {
                Filt_tenbs(txtChutoa.Text);

                listChutoa.BrowseToICD10(txtChutoa, txtMachutoa, txtMathuky, txtMachutoa.Location.X, txtMachutoa.Location.Y + txtMachutoa.Height - 2, txtChutoa.Width + txtChutoa.Width + 80, txtMachutoa.Height);
            }		
        }

        private void txtChutoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listChutoa.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listChutoa.Visible) listChutoa.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void frmBienbankiemthaotuvong_Load(object sender, EventArgs e)
        {
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            load_dm();
            Clear_HC();
            //butTiep_Click(null, null);
        }

        private void txtMachutoa_Validated(object sender, EventArgs e)
        {
            if (txtMachutoa.Text != "")
            {
                DataRow r = m.getrowbyid(dsbs.Tables[0], "ma='" + txtMachutoa.Text + "'");
                if (r != null) txtChutoa.Text = r["hoten"].ToString();
                else txtChutoa.Text = "";
            }
        }

        private void txtMachutoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtMathuky_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtMathuky_Validated(object sender, EventArgs e)
        {
            if (txtMathuky.Text != "")
            {
                DataRow r = m.getrowbyid(dsbs.Tables[0], "ma='" + txtMathuky.Text + "'");
                if (r != null) thuky.Text = r["hoten"].ToString();
                else thuky.Text = "";
            }
        }

        private void thuky_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listChutoa.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listChutoa.Visible) listChutoa.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void thuky_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == thuky)
            {
                Filt_tenbs(thuky.Text);

                listChutoa.BrowseToICD10(thuky, txtMathuky, makhth, txtMathuky.Location.X, txtMathuky.Location.Y + txtMathuky.Height - 2, thuky.Width + thuky.Width + 80, txtMathuky.Height);
            }	
        }

        private void makhth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void makhth_Validated(object sender, EventArgs e)
        {
            if (makhth.Text != "")
            {
                DataRow r = m.getrowbyid(dsbs.Tables[0], "ma='" + makhth.Text + "'");
                if (r != null) khth.Text = r["hoten"].ToString();
                else khth.Text = "";
            }
        }

        private void khth_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == khth)
            {
                Filt_tenbs(khth.Text);

                listChutoa.BrowseToICD10(khth, makhth, ma1, makhth.Location.X, makhth.Location.Y + makhth.Height - 2, khth.Width + khth.Width + 80, makhth.Height);
            }
        }

        private void khth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listChutoa.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listChutoa.Visible) listChutoa.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void ma1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ma1_Validated(object sender, EventArgs e)
        {
            if (ma1.Text != "")
            {
                DataRow r = m.getrowbyid(dsbs.Tables[0], "ma='" + ma1.Text + "'");
                if (r != null) ten1.Text = r["hoten"].ToString();
                else ten1.Text = "";
            }
        }

        private void ten1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listChutoa.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listChutoa.Visible) listChutoa.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void ten1_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == ten1)
            {
                Filt_tenbs(ten1.Text);

                listChutoa.BrowseToICD10(ten1, ma1, chucvu1, ma1.Location.X, ma1.Location.Y + ma1.Height - 2, ten1.Width + ten1.Width + 80, ma1.Height);
            }	
        }

        private void chucvu1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chucvu2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chucvu3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chucvu4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void hoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void namsinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void phai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void nn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ngayvao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) lydo.Focus();//SendKeys.Send("{Tab}");
        }

        private void diachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void noigioithieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void lydo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void benhsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void maicd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void lamsang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void huongdieutri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void dienbienBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void thaido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chetngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void bncomat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void nguyennhanchet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void maicdchet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void maicdgpbl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void textBox31_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ma2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ma3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ma4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ma2_Validated(object sender, EventArgs e)
        {
            if (ma2.Text != "")
            {
                DataRow r = m.getrowbyid(dsbs.Tables[0], "ma='" + ma2.Text + "'");
                if (r != null) ten2.Text = r["hoten"].ToString();
                else ten2.Text = "";
            }
        }

        private void ma3_Validated(object sender, EventArgs e)
        {
            if (ma3.Text != "")
            {
                DataRow r = m.getrowbyid(dsbs.Tables[0], "ma='" + ma3.Text + "'");
                if (r != null) ten3.Text = r["hoten"].ToString();
                else ten3.Text = "";
            }
        }

        private void ma4_Validated(object sender, EventArgs e)
        {
            if (ma4.Text != "")
            {
                DataRow r = m.getrowbyid(dsbs.Tables[0], "ma='" + ma4.Text + "'");
                if (r != null) ten4.Text = r["hoten"].ToString();
                else ten4.Text = "";
            }
        }

        private void ten2_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == ten2)
            {
                Filt_tenbs(ten2.Text);

                listChutoa.BrowseToICD10(ten2, ma2, chucvu2, ma2.Location.X, ma2.Location.Y + ma2.Height - 2, ten2.Width + ten2.Width + 80, ma2.Height);
            }	
        }

        private void ten3_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == ten3)
            {
                Filt_tenbs(ten3.Text);

                listChutoa.BrowseToICD10(ten3, ma3, chucvu3, ma3.Location.X, ma3.Location.Y + ma3.Height - 2, ten3.Width + ten3.Width + 80, ma3.Height);
            }
        }

        private void ten4_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == ten4)
            {
                Filt_tenbs(ten4.Text);

                listChutoa.BrowseToICD10(ten4, ma4, chucvu4, ma4.Location.X, ma4.Location.Y + ma4.Height - 2, ten4.Width + ten4.Width + 80, ma4.Height);
            }
        }

        private void ten2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listChutoa.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listChutoa.Visible) listChutoa.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void ten3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listChutoa.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listChutoa.Visible) listChutoa.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void ten4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listChutoa.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listChutoa.Visible) listChutoa.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void mabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void mabn_Validated(object sender, EventArgs e)
        {
            ads.Clear();
            DataSet ds = new DataSet();
            decimal l_maql = 0;
            if (mabn.Text.Trim().Length > 3) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
            else return;
            sql = "select c.mabn,c.hoten,c.namsinh,c.phai,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra,b.makp,d.tenkp,c.mann,e.tennn,f.dantoc,trim(c.sonha)||' '||trim(c.thon)||' '||trim(i.tenpxa)||','||trim(h.tenquan)||','||trim(g.tentt) as diachi,b.soluutru,b.chandoan,b.maicd";
            sql += " from medibv.benhandt a inner join medibv.xuatvien b on a.maql=b.maql inner join medibv.btdbn c on b.mabn=c.mabn inner join medibv.btdkp_bv d on b.makp=d.makp inner join medibv.btdnn_bv e on c.mann=e.mann inner join medibv.btddt f on c.madantoc=f.madantoc left join medibv.btdtt g on c.matt=g.matt left join medibv.btdquan h on c.maqu=h.maqu left join medibv.btdpxa i on c.maphuongxa=i.maphuongxa";
            sql += " where a.loaiba=1 and a.mabn='" + mabn.Text.Trim() + "' and b.ttlucrv=7" ;
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                l_maql = decimal.Parse(r["maql"].ToString());
                hoten.Text = r["hoten"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                phai.SelectedValue = r["phai"].ToString();
                nn.SelectedValue = r["mann"].ToString();
                diachi.Text = r["diachi"].ToString();
                ngayra.Text = r["ngayra"].ToString();
                ngayvv.Text = ngayra.Text.Substring(0, 10);
                giovv.Text = ngayra.Text.Substring(11);
                maicd.Text = r["maicd"].ToString();
                maicd_Validated(null, null);
                foreach (DataRow rr in m.get_data("select * from medibv.tuvong where maql=" + l_maql + "").Tables[0].Rows)
                {
                    maicdchet.Text = rr["maicd"].ToString();
                    maicdchet_Validated(null, null);
                }
                ins_item(r["mabn"].ToString(), r["hoten"].ToString(), l_maql, r["ngayvao"].ToString(), r["ngayra"].ToString(), r["chandoan"].ToString(), r["maicd"].ToString());
            }
            if (l_maql == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"), LibMedi.AccessData.Msg);
                mabn.Focus();
            }
            else
            {

                ngayvao.DisplayMember = "NGAYVAO";
                ngayvao.ValueMember = "MAQL";
                ngayvao.DataSource = ads.Tables[0];
                ngayvao.SelectedValue = l_maql.ToString();                
                ngayvao.Focus();
                decimal s = 0;
                try
                {
                    s = decimal.Parse(m.get_data("select maql from medibv.bbtuvong where maql=" + l_maql.ToString() + "").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    s = 0;
                }
                if (s != 0) load_lai(l_maql.ToString());                    
                ena_but(true);
            }
        }
        private void ins_item(string s_mabn, string s_hoten, decimal l_maql, string s_ngayvao, string s_ngayra, string s_chandoan, string s_maicd)
        {
            DataRow r2 = ads.Tables[0].NewRow();
            r2["mabn"] = s_mabn;
            r2["hoten"] = s_hoten;
            r2["maql"] = l_maql;
            r2["ngayvao"] = s_ngayvao;
            r2["ngayra"] = s_ngayra;
            r2["chandoan"] = s_chandoan;
            r2["maicd"] = s_maicd;
            ads.Tables[0].Rows.Add(r2);
        }
        private void Clear_HC()
        {
            mabn.Text = "";
            hoten.Text = "";
            namsinh.Text = "";
            nn.SelectedIndex = 0;
            ngayvao.DataSource = null;
            diachi.Text = "";
            noigioithieu.Text = "";
            lydo.Text = "";
            benhsu.Text = "";
            maicd.Text = "";
            chandoan.Text = "";
            lamsang.Text = "";
            huongdieutri.Text = "";
            dienbienBN.Text = "";
            thaido.Text = "";
            ngayvv.Text = ngay_VV.Substring(0, 10);
            giovv.Text = ngay_VV.Substring(11);
            bncomat.Text = "";
            nguyennhanchet.Text = "";
            maicdchet.Text = "";
            cdchet.Text = "";
            maicdgpbl.Text = "";
            gpbl.Text = "";
            khuyetdiem.Text = "";
        }

        private void butTiep_Click(object sender, EventArgs e)
        {
            Clear_HC();
            ena_but(true);
            mabn.Focus();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (txtMachutoa.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText("Vui lòng nhập chủ toạ"),LibMedi.AccessData.Msg);
                txtMachutoa.Focus();
                return;
            }
            if (txtMathuky.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText("Vui lòng nhập thư ký"), LibMedi.AccessData.Msg);
                txtMathuky.Focus();
                return;
            }
            if (txtMathuky.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText("Vui lòng nhập thư ký"), LibMedi.AccessData.Msg);
                txtMathuky.Focus();
                return;
            }
            if (mabn.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText("Vui lòng nhập mã bệnh nhân tử vong"), LibMedi.AccessData.Msg);
                mabn.Focus();
                return;
            }
            if(ngayvao.SelectedIndex<0)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Bệnh nhân này chưa hoàn tất thủ tục"), LibMedi.AccessData.Msg);
                mabn.Focus();
                return;
            }
            if (!m.upd_bbtuvong(mabn.Text.Trim(), decimal.Parse(ngayvao.SelectedValue.ToString()), ngayvao.Text, lydo.Text.Trim(), benhsu.Text.Trim(), chandoan.Text.Trim(), "", lamsang.Text.Trim(), "", huongdieutri.Text.Trim(), dienbienBN.Text.Trim(), thaido.Text.Trim(), ngayvv.Text + " " + giovv.Text, bncomat.Text.Trim(), nguyennhanchet.Text.Trim(), cdchet.Text.Trim(), gpbl.Text.Trim(), khuyetdiem.Text.Trim(), txtMachutoa.Text.Trim(), txtMathuky.Text.Trim(), makhth.Text.Trim(),int.Parse(m_userid)))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                return;
            }

            if (ma1.Text != "")
            {
                m.upd_bbtuvongnv(decimal.Parse(ngayvao.SelectedValue.ToString()), 1, ma1.Text.Trim(), chucvu1.Text.Trim());
            }
            if (ma2.Text != "")
            {
                m.upd_bbtuvongnv(decimal.Parse(ngayvao.SelectedValue.ToString()), 2, ma2.Text.Trim(), chucvu2.Text.Trim());
            }
            if (ma3.Text != "")
            {
                m.upd_bbtuvongnv(decimal.Parse(ngayvao.SelectedValue.ToString()), 3, ma3.Text.Trim(), chucvu3.Text.Trim());
            }
            if (ma4.Text != "")
            {
                m.upd_bbtuvongnv(decimal.Parse(ngayvao.SelectedValue.ToString()), 4, ma4.Text.Trim(), chucvu4.Text.Trim());
            }
            ena_but(false);
            butTiep.Focus();
        }

        private void maicd_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void maicd_Validated(object sender, EventArgs e)
        {
            if (maicd.Text != "")
            {
                DataRow r = m.getrowbyid(dticd, "cicd10='" + maicd.Text + "'");
                if (r != null) chandoan.Text = r["vviet"].ToString();
                else chandoan.Text = "";
            }
        }

        private void chandoan_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chandoan)
            {
                Filt_ICD(chandoan.Text);

                listICD.BrowseToICD10(chandoan, maicd, lamsang, maicd.Location.X, maicd.Location.Y + maicd.Height - 2, chandoan.Width+80, maicd.Height);
            }
        }

        private void Filt_ICD(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listICD.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "vviet like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void chandoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void maicdchet_Validated(object sender, EventArgs e)
        {
            if (maicdchet.Text != "")
            {
                DataRow r = m.getrowbyid(dticd, "cicd10='" + maicdchet.Text + "'");
                if (r != null) cdchet.Text = r["vviet"].ToString();
                else cdchet.Text = "";
            }
        }

        private void maicdgpbl_Validated(object sender, EventArgs e)
        {
            if (maicdgpbl.Text != "")
            {
                DataRow r = m.getrowbyid(dticd, "cicd10='" + maicdgpbl.Text + "'");
                if (r != null) gpbl.Text = r["vviet"].ToString();
                else gpbl.Text = "";
            }
        }

        private void ngayvv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void giovv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cdchet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void cdchet_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cdchet)
            {
                Filt_ICD(cdchet.Text);

                listICD.BrowseToICD10(cdchet, maicdchet, maicdgpbl, maicdchet.Location.X, maicdchet.Location.Y + maicdchet.Height - 2, cdchet.Width + 200, maicdchet.Height);
            }
        }

        private void gpbl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void gpbl_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == gpbl)
            {
                Filt_ICD(gpbl.Text);

                listICD.BrowseToICD10(gpbl, maicdgpbl, khuyetdiem, maicdgpbl.Location.X - 421, maicdgpbl.Location.Y + maicdgpbl.Height - 2, maicdgpbl.Width + gpbl.Width + 2 + 421, maicdgpbl.Height);
                
                //listICD.BrowseToICD10(maicdgpbl, gpbl, khuyetdiem, maicdgpbl.Location.X - 421, maicdgpbl.Location.Y + maicdgpbl.Height - 2, maicdgpbl.Width + maicdgpbl.Width + 2 + 421, maicdgpbl.Height);
                //listICD.BrowseToICD10(cdchet, maicdchet, maicdgpbl, maicdchet.Location.X, maicdchet.Location.Y + maicdchet.Height - 2, cdchet.Width + 200, maicdchet.Height);
            }
        }

        private void butboqua_Click(object sender, EventArgs e)
        {
            ena_but(false);
            butTiep.Focus();
        }
        private void ena_but(bool ena)
        {
            butTiep.Enabled = !ena;
            butLuu.Enabled = ena;
            butboqua.Enabled = ena;
            butHuy.Enabled = !ena;
            butIn.Enabled = !ena;
            butKetthuc.Enabled = !ena;
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            DataSet ds_in = new DataSet();
            string nv1 = "", nv2 = "", nv3 = "", nv4 = "";
            string cv1 = "", cv2 = "", cv3 = "", cv4 = "";
            string s_ngayin = "";

            sql = " select a.mabn,c.hoten,c.namsinh,case when phai=1 then 'Nữ' else 'Nam' end as phai,e.tennn,trim(c.sonha)||' '||trim(c.thon)||' '||trim(i.tenpxa)||','||trim(h.tenquan)||','||trim(g.tentt) as diachi,a.*,ct.hoten as chutoa,tk.hoten as thuky,khth.hoten as khth";
            sql += ",0 as stt, ' ' as chucvu1,' ' as tennv1, ' ' as chucvu2,' ' as tennv2, ' ' as chucvu3,' ' as tennv3, ' ' as chucvu4,' ' as tennv4, a.maql ";//binh230908
            sql += ", c.phai as gioitinh";
            //sql += " from medibv.bbtuvong a left join medibv.bbtuvongnv b on a.maql=b.maql inner join medibv.btdbn c on a.mabn=c.mabn inner join medibv.btdnn_bv e on c.mann=e.mann inner join medibv.btddt f on c.madantoc=f.madantoc inner join medibv.btdtt g on c.matt=g.matt inner join medibv.btdquan h on c.maqu=h.maqu inner join medibv.btdpxa i on c.maphuongxa=i.maphuongxa";
            sql += " from medibv.bbtuvong a inner join medibv.btdbn c on a.mabn=c.mabn inner join medibv.btdnn_bv e on c.mann=e.mann inner join medibv.btddt f on c.madantoc=f.madantoc inner join medibv.btdtt g on c.matt=g.matt inner join medibv.btdquan h on c.maqu=h.maqu inner join medibv.btdpxa i on c.maphuongxa=i.maphuongxa ";
            sql += " inner join medibv.dmbs ct on a.chutoa=ct.ma inner join medibv.dmbs tk on a.thuky=tk.ma inner join medibv.dmbs khth on a.khth=khth.ma";// inner join medibv.dmbs nv on b.manv=nv.ma";
            sql += " where a.maql=" + ngayvao.SelectedValue.ToString() + "";
            ds_in = m.get_data(sql);
            //
            //
            sql = "select a.*, b.hoten as tennv from medibv.bbtuvongnv a, medibv.dmbs b where a.manv=b.ma and a.maql=" + ngayvao.SelectedValue.ToString() + " order by a.stt";
            DataSet lds = m.get_data(sql);
            int ii = 0;
            foreach (DataRow r in lds.Tables[0].Rows)
            {
                ii += 1;
                string s_exp = "maql=" + ngayvao.SelectedValue.ToString() + ""; ;
                DataRow ldr = m.getrowbyid(ds_in.Tables[0], s_exp);
                if (ldr != null)
                {
                    ldr["chucvu" + ii.ToString()] = r["chucvu"].ToString();
                    ldr["tennv" + ii.ToString()] = r["tennv"].ToString();
                }
                //
                if (r["stt"].ToString() == "1")
                {
                    nv1 = r["tennv"].ToString();
                    cv1 = r["chucvu"].ToString();
                }
                else if (r["stt"].ToString() == "2")
                {
                    nv2 = r["tennv"].ToString();
                    cv2 = r["chucvu"].ToString();
                }
                else if (r["stt"].ToString() == "3")
                {
                    nv3 = r["tennv"].ToString();
                    cv3 = r["chucvu"].ToString();
                }
                else if (r["stt"].ToString() == "4")
                {
                    nv4 = r["tennv"].ToString();
                    cv4 = r["chucvu"].ToString();
                }
            }
            ds_in.AcceptChanges();
            //
            /*
            foreach (DataRow r in ds_in.Tables[0].Select("stt=1")) 
            {                
                nv1 = r["tennv"].ToString();
                cv1 = r["chucvu"].ToString();  
            }
            foreach (DataRow r in ds_in.Tables[0].Select("stt=2"))
            {
                nv2 = r["tennv"].ToString();
                cv2 = r["chucvu"].ToString();
            }
            foreach (DataRow r in ds_in.Tables[0].Select("stt=3"))
            {
                nv3 = r["tennv"].ToString();
                cv3 = r["chucvu"].ToString();
            }
            foreach (DataRow r in ds_in.Tables[0].Select("stt=4"))
            {
                nv4 = r["tennv"].ToString();
                cv4 = r["chucvu"].ToString();
            }
            */
            s_ngayin = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString() + "";

            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                ds_in.WriteXml("..//xml//tuvong.xml", XmlWriteMode.WriteSchema);
            }
            dllReportM.frmReport f = new dllReportM.frmReport(m, ds_in.Tables[0], "rpt_bienbankiemtuvong.rpt", nv1, cv1, nv2, cv2, nv3, cv3, nv4, cv4, s_ngayin, "");
            f.Show();
        }

        private void ngayvao_SelectedValueChanged(object sender, EventArgs e)
        {            

           
        }
        private void load_lai(string x_maql)
        {
            sql = " select a.mabn,c.hoten,c.namsinh,case when phai=0 then 'Nữ' else 'Nam' end as phai,e.tennn,trim(c.sonha)||' '||trim(c.thon)||' '||trim(i.tenpxa)||','||trim(h.tenquan)||','||trim(g.tentt) as diachi,a.*,b.chucvu,nv.hoten as tennv,ct.hoten as chutoa,tk.hoten as thuky,khth.hoten as khth,b.stt,b.manv,to_char(a.chetngay,'dd/mm/yyyy hh24:mi') as cngay";
            sql += " from medibv.bbtuvong a left join medibv.bbtuvongnv b on a.maql=b.maql inner join medibv.btdbn c on a.mabn=c.mabn inner join medibv.btdnn_bv e on c.mann=e.mann inner join medibv.btddt f on c.madantoc=f.madantoc inner join medibv.btdtt g on c.matt=g.matt inner join medibv.btdquan h on c.maqu=h.maqu inner join medibv.btdpxa i on c.maphuongxa=i.maphuongxa";
            sql += " inner join medibv.dmbs ct on a.chutoa=ct.ma inner join medibv.dmbs tk on a.thuky=tk.ma inner join medibv.dmbs khth on a.khth=khth.ma inner join medibv.dmbs nv on b.manv=nv.ma";
            sql += " where a.maql=" + x_maql + "";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                txtMachutoa.Text = r["chutoa"].ToString();
                txtMachutoa_Validated(null, null);
                txtMathuky.Text = r["thuky"].ToString();
                txtMathuky_Validated(null, null);
                makhth.Text = r["khth"].ToString();
                makhth_Validated(null, null);
                if (r["stt"].ToString() == "1")
                {
                    ma1.Text = r["manv"].ToString();
                    ma1_Validated(null, null);
                    chucvu1.Text = r["chucvu"].ToString();
                }
                if (r["stt"].ToString() == "2")
                {
                    ma2.Text = r["manv"].ToString();
                    ma2_Validated(null, null);
                    chucvu2.Text = r["chucvu"].ToString();
                }
                if (r["stt"].ToString() == "3")
                {
                    ma3.Text = r["manv"].ToString();
                    ma3_Validated(null, null);
                    chucvu3.Text = r["chucvu"].ToString();
                }
                if (r["stt"].ToString() == "4")
                {
                    ma4.Text = r["manv"].ToString();
                    ma4_Validated(null, null);
                    chucvu4.Text = r["chucvu"].ToString();
                }
                lydo.Text = r["lydo"].ToString();
                benhsu.Text = r["benhsu"].ToString();
                chandoan.Text = r["chandoan"].ToString();
                lamsang.Text = r["lamsang"].ToString();
                huongdieutri.Text = r["dieutri"].ToString();
                dienbienBN.Text = r["dienbien"].ToString();
                thaido.Text = r["tinhthan"].ToString();
                //ngayvv.Text = r["cngay"].ToString().Substring(0, 10);
                //giovv.Text = r["cngay"].ToString().Substring(11);
                bncomat.Text = r["comat"].ToString();
                nguyennhanchet.Text = r["nguyennhan"].ToString();
                cdchet.Text = r["chandoant"].ToString();
                gpbl.Text = r["chandoangpb"].ToString();
                khuyetdiem.Text = r["kiemdiem"].ToString();
            }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập mã bệnh nhân cần xoá !"), LibMedi.AccessData.Msg);
                mabn.Focus();
            }
            if (MessageBox.Show(this,"Bạn có muốn xoá biên bản kiểm thảo của bệnh nhân này không", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                m.execute_data("delete from medibv.bbtuvongnv where maql=" + ngayvao.SelectedValue.ToString() + "");
                m.execute_data("delete from medibv.bbtuvong where maql=" + ngayvao.SelectedValue.ToString() + "");
            }
        }

        private void lydo_TextChanged(object sender, EventArgs e)
        {
            if (lydo.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void benhsu_TextChanged(object sender, EventArgs e)
        {
            if (benhsu.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void lamsang_TextChanged(object sender, EventArgs e)
        {
            if (lamsang.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void huongdieutri_TextChanged(object sender, EventArgs e)
        {
            if (huongdieutri.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void dienbienBN_TextChanged(object sender, EventArgs e)
        {
            if (dienbienBN.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void thaido_TextChanged(object sender, EventArgs e)
        {
            if (thaido.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void bncomat_TextChanged(object sender, EventArgs e)
        {
            if (bncomat.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void nguyennhanchet_TextChanged(object sender, EventArgs e)
        {
            if (nguyennhanchet.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void khuyetdiem_TextChanged(object sender, EventArgs e)
        {
            if (khuyetdiem.Text == "\r\n") SendKeys.Send("{Tab}");
        }
    }
}