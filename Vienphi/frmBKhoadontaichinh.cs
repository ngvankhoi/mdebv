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
    public partial class frmBKhoadontaichinh : Form
    {
        LibVP.AccessData m_v;
        Language lan = new Language();
        string v_userid = "";
        public frmBKhoadontaichinh(LibVP.AccessData v,string s_userid)
        {
            InitializeComponent();
            m_v = v;
            v_userid = s_userid;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBKhoadontaichinh_Load(object sender, EventArgs e)
        {
            //cbdoituong.DataSource = m_v.get_data("select to_number('0') as id,'Dịch vụ' as ten from dua");
            cbdoituong.Items.AddRange(new object[]{"Khác BHYT","BHYT"});
            label4.Text = "BẢNG KÊ YÊU CẦU XUẤT " + Environment.NewLine + "HÓA ĐƠN TÀI CHÍNH";
            cbdoituong.SelectedIndex = 0;
            dttungay.Value = DateTime.Now;
            dtdenngay.Value = DateTime.Now;
            
        }
        private void f_ketxuat(bool v_print)
        {
            string sql = "", aReport = "", aexp = "", atenbv = "", adiachibv = "", asyt = "",ngay="";
            aexp = " where a.ngayhd between to_date('"+dttungay.Text.Substring(0,10)+
                "','dd/mm/yyyy') and to_date('"+dtdenngay.Text.Substring(0,10)+"','dd/mm/yyyy') ";
            if (chkDaduyetin.Checked)
                aexp += " and a.done=1 ";
            else
                aexp += " and a.done=0 ";
            if (cbdoituong.SelectedIndex == 0)
            {
                aexp += " and a.bhyt = 0 ";
                aReport = "v_BKhoadontaichinh_dv.rpt";
            }
            else
            {
                aexp += " and a.bhyt > 0 ";
                aReport = "v_BKhoadontaichinh_bh.rpt";
            }
            DataSet ads = new DataSet();
            sql = "select a.id,e.hoten,to_char(a.ngayhd,'dd/mm/yyyy') as ngayhd,to_char(a.ngayhen,'dd/mm/yyyy') as ngayhen,a.tendv as congty,a.diachi as dccongty,a.masothue,a.noidung as ghichu,max(c.vat) as vat, ";
            sql += "sum(case when d.ma <> 15 and d.ma <> 4 and b.madoituong <>1 then b.sotien-b.mien else to_number('0')  end) as bntracls,";
            sql += "sum(case when d.ma <> 15 and d.ma <> 4 and b.madoituong = 1 then b.sotien-b.bhyt else to_number('0') end) as bndongtracls,";
            sql += "sum(case when d.ma = 15 and b.madoituong <> 1 then b.sotien-b.mien-b.bhyt else to_number('0') end) as bntrathuoc,";
            sql += "sum(case when d.ma = 15 and b.madoituong = 1 then b.sotien-b.bhyt-b.mien else to_number('0') end) as bndongtrathuoc,";
            sql += "sum(case when d.ma=4 then b.sotien-b.bhyt-b.mien else to_number('0') end) as congkham ";
            sql += "from medibvmmyy.v_bienlaitaichinhll a inner join medibvmmyy.v_bienlaitaichinhct b ";
            sql += "on a.id=b.id inner join (select id,ten as tenvp,vat,id_loai from medibv.v_giavp union all ";
            sql += "select id,ten as tenvp,vat,to_number('87') as loai from medibv.d_dmbd) c on b.mavp=c.id ";
            sql += "inner join medibv.v_loaivp dd on dd.id=c.id_loai inner join medibv.v_nhomvp d on dd.id_nhom=d.ma ";
            sql += "inner join medibv.btdbn e on a.mabn=e.mabn " + aexp;
            sql += "group by a.id,e.hoten,a.ngayhd,a.ngayhen,a.tendv,a.diachi,a.masothue,a.noidung";

            try
            {
                DateTime tungay = Convert.ToDateTime(dttungay.Value);
                DateTime denngay = Convert.ToDateTime(dtdenngay.Value);
                ngay = "Từ ngày " + tungay.Day.ToString().PadLeft(2, '0') + "/" + tungay.Month.ToString().PadLeft(2, '0')
                    + "/" + tungay.Year + " đến ngày " + denngay.Day.ToString().PadLeft(2, '0') + "/" + denngay.Month.ToString().PadLeft(2, '0') + "/" + denngay.Year;
                ads = m_v.get_data_bc(tungay,denngay,sql);
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu. "));
                    return;
                }
                else
                {
                    if (!System.IO.File.Exists("..\\..\\..\\report\\" + aReport))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy report )" )+ aReport + ".");
                        return;
                    }

                    atenbv = m_v.Tenbv;
                    adiachibv = m_v.sys_diachi;
                    asyt = m_v.Syte;

                    ads.WriteXml("..\\..\\Datareport\\"+aReport.Substring(0,aReport.Length-3)+"xml", XmlWriteMode.WriteSchema);

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
                    cMain.SetDataSource(ads);

                    cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + atenbv + "'";
                    cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + atenbv + "'";
                    cMain.DataDefinition.FormulaFields["v_diachibv"].Text = adiachibv;
                    cMain.DataDefinition.FormulaFields["v_ngay"].Text = "'" + ngay + "'";
                    if (!v_print)
                    {
                        //cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                        //cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        crystalReportViewer1.ReportSource = cMain;
                        af.Text = lan.Change_language_MessageText("Bảng kê xuất hóa đơn tài chính ");
                        af.Text = af.Text + " (" + aReport + ")";
                        af.ShowDialog();
                    }
                    else
                    {
                        cMain.PrintToPrinter(1, false, 0, 0);
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(lan.Change_language_MessageText(ex.ToString())); }
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            f_ketxuat(false);
        }

        private void butInhoadon_Click(object sender, EventArgs e)
        {
            f_ketxuat(true);
        }
    }
}