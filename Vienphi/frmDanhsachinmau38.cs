using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace Vienphi
{
    public partial class frmDanhsachinmau38 : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_mabn="",m_maql="",m_ngaycd="",m_quyenso="";
        private bool bTunguyen, bBatbuoc,bDain = false;
        bool bthuphi = false, btatca = false;
        private string acongkham = "0";
        private bool bNhieudot = false;
        private frmPrintHD m_frmprinthd;

        public frmDanhsachinmau38(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();

                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
                lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");
                m_v = v_v;
                m_userid = v_userid;
                m_v.f_SetEvent(this);
                f_Load_Data();
            }
            catch
            {
            }
        }
        //public frmDanhsachinmau38(LibVP.AccessData v_v, string v_userid)
        //{
        //    try
        //    {
        //        InitializeComponent();

        //        lan.Read_Language_to_Xml(this.Name.ToString(), this);
        //        lan.Changelanguage_to_English(this.Name.ToString(), this);
        //        lan.Read_dtgrid_to_Xml(dgHoadon, this.Name + "_" + "dgHoadon");
        //        lan.Change_dtgrid_HeaderText_to_English(dgHoadon, this.Name + "_" + "dgHoadon");

        //        m_v = v_v;
        //        m_userid = v_userid;
        //        bthuphi = v_thuphi;// chỉ thu chi phí bệnh nhân <> bhyt, giống form thu trực tiếp
        //        btatca = v_tatca;// thu tất cả chi phí thu phí + bhyt
        //        m_v.f_SetEvent(this);
        //        f_Load_Data();
        //    }
        //    catch
        //    {
        //    }
        //}
        public string s_mabn
        {
            get
            {
                return m_mabn;
            }
        }
        public string s_maql
        {
            get
            {
                return m_maql;
            }
        }
        public string s_ngaycd
        {
            get
            {
                return m_ngaycd;
            }
        }
        public DateTime s_ngay
        {
            set
            {
                txtTN.Value = value;
                txtDN.Value = value;
            }
        }
        private void f_Load_Data()
        {
            try
            {
                bTunguyen = m_v.bhyt_tunguyen(m_userid);
                bBatbuoc = m_v.bhyt_batbuoc(m_userid);
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmdanhsachchoBHYT(m_userid);
                f_set_Fullgrid();
                txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmdanhsachchoBHYT(m_userid).ToString());
            }
            catch
            {
            }
        }
        private string f_Load_Bhyt_Kytu()
        {
            return m_v.get_ma13 + m_v.get_ma16 + m_v.get_ma16_95;
            //try
            //{
            //    return (m_v.get_data("select ten from medibv.thongso where id=50").Tables[0].Rows[0][0].ToString());
            //}
            //catch { return "-1"; };
        }
        private void f_Load_DG()
        {
            butTim.Enabled = false;
            string asql = "";
          
             try
             {
                 asql = "select a.mavaovien,a.mabn,b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') ";
                 asql += "end as ngaysinh,b1.ten as phai, to_char(a1.ngay,'dd/mm/yyyy') as ngayhd, sum(a1.sotien - a1.bhyt - a1.mien) as sotien,";
                 asql += "b.sonha,b.thon,e.tenpxa as xa,d.tenquan as quan, c.tentt as tinh,b.cholam,f.nha as dt_nha,";
                 asql += "f.coquan as dt_coquan,f.didong as dt_didong ,f.email,h.sothe,g.makp ";
                 asql += "from medibvmmyy.v_ttrvds a inner join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a2 on a.id=a2.id ";
                 asql += "inner join medibv.btdbn b on a.mabn=b.mabn left join medibv.dmphai b1 on b.phai=b1.ma left join medibv.btdtt c on b.matt=c.matt ";
                 asql += "left join medibv.btdquan d on b.maqu=d.maqu left join medibv.btdpxa e on b.maphuongxa=e.maphuongxa ";
                 asql += "left join medibv.dienthoai f on b.mabn=f.mabn inner join medibvmmyy.bhytkb g on b.mabn=g.mabn left join medibvmmyy.bhyt h on g.maql=h.maql ";
                 asql += "where a2.bhyttra > 0 and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') >= to_date('"+txtTN.Text+"','dd/mm/yyyy') ";
                 asql += "and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('"+txtDN.Text+"','dd/mm/yyyy') ";
                 if (bDain)
                     asql += " and a.dain38 <> 0 ";
                 else
                     asql += " and a.dain38 = 0 ";
                 asql += "group by a.mavaovien,a.mabn,b.hoten,b.ngaysinh,b.namsinh,b1.ten,to_char(a1.ngay,'dd/mm/yyyy'),";
                 asql += "b.sonha,b.thon,e.tenpxa,d.tenquan, c.tentt,b.cholam,f.nha,f.coquan,f.didong,f.email,h.sothe,g.makp ";
                dgHoadon.DataSource = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true).Tables[0];
                dgHoadon.Update();
                tmn_Sotien.Text = lan.Change_language_MessageText("TỔNG SỐ:")+" " + dgHoadon.RowCount.ToString();
            }
            catch
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    dv.Table.Rows.Clear();
                }
                catch
                {
                }
                tmn_Sotien.Text = "";
            }
            butTim.Enabled = true;
        }

        private void tmn_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tmn_Chon_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                m_mabn = arv["mabn"].ToString();
                m_maql = arv["maql"].ToString();
                m_ngaycd = arv["ngaycd"].ToString();
            }
            catch
            {
                m_mabn = "";
                m_maql = "";
                m_ngaycd = "";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tmn_Inhoadon_Click(object sender, EventArgs e)
        {
            try
            {
                string ammyy = "";
                DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                ammyy = this.m_v.get_mmyy(arv["ngayhd"].ToString());
                this.m_frmprinthd.f_Print_ChiphiTTRVNgtruCT_tenreport(!this.tmn_Xemtruockhiin.Checked, "", this.m_v.get_mmyy(arv["ngayhd"].ToString()), arv["mabn"].ToString(),arv["mavaovien"].ToString(), decimal.Parse(acongkham), arv["ngayhd"].ToString(), "v_ttrv_mau01.rpt",false);
                m_v.execute_data_mmyy(ammyy, "update medibvmmyy.v_ttrvds set dain38=dain38+1 where mavaovien = " +
                   arv["mavaovien"].ToString() + " and mabn='" + arv["mabn"].ToString() + "'");
                if(!bDain)f_Load_DG();
               
            }
            catch { }
        }

        private void tmn_Inchiphi_Click(object sender, EventArgs e)
        {

        }

        private void frmDanhsachchoBHYT_Load(object sender, EventArgs e)
        {
            tmn_huy38.Enabled = false;
            bDain = false;
            f_Load_DG();
            m_frmprinthd = new frmPrintHD(m_v, m_userid);
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
                    butTim_Click(null,null);
                }
            }
            catch
            {
            }
        }

        private void frmDanhsachchoBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    m_mabn = "";
                    m_maql = "";
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
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

        private void tmn_Timnhanh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "";
                string atmp = tmn_Timnhanh.Text.Trim();
                if (atmp.ToLower().Trim() != 
lan.Change_language_MessageText("Tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "mabn like '%" + atmp + "%' or hoten like '%" + atmp + "%' or ngaysinh like '%" + atmp + "%' or phai like '%" + atmp + "%' or sonha like '%" + atmp + "%' or thon like '%" + atmp + "%' or cholam like '%" + atmp + "%' or xa like '%" + atmp + "%' or quan like '%" + atmp + "%' or tinh like '%" + atmp + "%' or dt_nha like '%" + atmp + "%' or dt_coquan like '%" + atmp + "%' or dt_didong like '%" + atmp + "%' or email like '%" + atmp + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch//(Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
        }

        private void tmn_Timnhanh_Enter(object sender, EventArgs e)
        {
            tmn_Timnhanh.Text = "";
        }

        private void tmn_Timnhanh_Leave(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.White;
                if (tmn_Timnhanh.Text.Trim() == "")
                {
                    tmn_Timnhanh.Text = 
lan.Change_language_MessageText("Tìm kiếm");
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int aid = 0;
                if (e.KeyCode == Keys.Up)
                {
                    if (dgHoadon.CurrentCell.RowIndex > 0)
                    {
                        aid = dgHoadon.CurrentCell.RowIndex - 1;
                        dgHoadon.Rows[aid].Selected = true;
                        dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                        SendKeys.Send("{End}");
                    }
                    else
                        if (dgHoadon.RowCount > 0)
                        {
                            aid = dgHoadon.RowCount - 1;
                            dgHoadon.Rows[aid].Selected = true;
                            dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                }
                else
                    if (e.KeyCode == Keys.Down)
                    {
                        if (dgHoadon.CurrentCell.RowIndex < dgHoadon.Rows.Count - 1)
                        {
                            aid = dgHoadon.CurrentCell.RowIndex + 1;
                            dgHoadon.Rows[aid].Selected = true;
                            dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                        else
                            if (dgHoadon.RowCount > 0)
                            {
                                aid = 0;
                                dgHoadon.Rows[aid].Selected = true;
                                dgHoadon.CurrentCell = dgHoadon.Rows[aid].Cells[1];
                                SendKeys.Send("{End}");
                            }
                    }
            }
            catch
            {
            }
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void txtLimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butTim.Focus();
                }
                m_v.set_o_limit_frmdanhsachchoBHYT(m_userid, txtLimit.Value.ToString());
            }
            catch
            {
            }
        }
        private void f_set_Fullgrid()
        {
            try
            {
                dgHoadon.Columns["Column_5"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_4"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_3"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_2"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_1"].Frozen = !tmn_Fullgrid.Checked;
                dgHoadon.Columns["Column_0"].Frozen = !tmn_Fullgrid.Checked;
            }
            catch
            {
            }
        }
        private void tmn_Fullgrid_Click(object sender, EventArgs e)
        {
            try
            {
                f_set_Fullgrid();
                m_v.set_o_fullgrid_frmdanhsachchoBHYT(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void dgHoadon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tmn_Chon_Click(null, null);
        }

        private void tmn_Xemtruockhiin_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Cho_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Cho.Checked = !ToolStripMenuItem_Cho.Checked;
        }

        private void tmn_Indanhsach_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)(BindingContext[dgHoadon.DataSource, dgHoadon.DataMember]);
            DataView dv = (DataView)(cm.List);
            string aReport = "rptDanhsachin38.rpt";
            try
            {
                DataSet ads = new DataSet();
               
                if (dv.Table.Rows.Count == 0)
                {
                }
                else
                {
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy report ") + aReport + ".");
                        return;
                    }

                    

                    ads.WriteXml("..\\..\\Datareport\\rptDanhsachin38.xml", XmlWriteMode.WriteSchema);

                    CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                    crystalReportViewer1.ActiveViewIndex = -1;
                    crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
                    crystalReportViewer1.DisplayGroupTree = false;
                    crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                    crystalReportViewer1.Name = "crystalReportViewer1";
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
                    crystalReportViewer1.TabIndex = 85;

                    System.Windows.Forms.Form af = new System.Windows.Forms.Form();
                    af.WindowState = FormWindowState.Maximized;
                    af.Controls.Add(crystalReportViewer1);
                    crystalReportViewer1.BringToFront();
                    crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                    ReportDocument cMain = new ReportDocument();

                    cMain.Load("..\\..\\..\\report\\" + aReport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.SetDataSource(dv);

                    //cMain.DataDefinition.FormulaFields["c1"].Text = "'" + atenbn + "'";

                    //cMain.DataDefinition.FormulaFields["c2"].Text = "'" + Math.Round(decimal.Parse(asotien == "" ? "0" : asotien)) + "'";
                    //cMain.DataDefinition.FormulaFields["ngayin"].Text = "'ngày " + txtNgaythu.Text.Substring(0, 2) + " tháng " + txtNgaythu.Text.Substring(3, 2) + " năm " + txtNgaythu.Text.Substring(6, 4) + "'";
                    if (tmn_Xemtruockhiin.Checked)
                    {
                        //cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                        //cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        crystalReportViewer1.ReportSource = cMain;
                        af.Text = "Danh sách bệnh nhân in mẫu 01  ";
                        af.Text = af.Text + " (" + aReport + ")";
                        af.ShowDialog();
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                }
            }
            catch { }
        }

        private void tmn_Danhsachchuain_Click(object sender, EventArgs e)
        {
            tmn_huy38.Enabled = false;
            bDain = false;
            f_Load_DG();
        }

        private void tmn_danhsachdain_Click(object sender, EventArgs e)
        {
            tmn_huy38.Enabled = true;
            bDain = true;
            f_Load_DG();
        }

        private void tmn_huy38_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn hủy không ?"), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataRowView arv = (DataRowView)(dgHoadon.CurrentRow.DataBoundItem);
                    m_v.execute_data_mmyy(m_v.get_mmyy(arv["ngayhd"].ToString()), "update medibvmmyy.v_ttrvds set dain38=0 where mavaovien = " +
                   arv["mavaovien"].ToString() + " and mabn='" + arv["mabn"].ToString() + "'");
                    f_Load_DG();
                }
                catch { MessageBox.Show(lan.Change_language_MessageText("Lỗi khi xóa dữ liệu.")); return; }
            }
            MessageBox.Show(lan.Change_language_MessageText("Xóa dữ liệu thành công."));
        }
    }
}