using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.ComponentModel;
using System.IO;
using System.Drawing.Printing;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmBCdoanhthutonghop : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        LibVP.AccessData a;
        DataTable dt_user = new DataTable();
        string sql = "",v_user="";
        DataSet ds = new DataSet();
        
        public frmBCdoanhthutonghop(AccessData vp)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);


            a = vp;
        }

        private void frmBCdoanhthutonghop_Load(object sender, EventArgs e)
        {
            dt_user = a.get_data("select * from medibv.v_dlogin order by id").Tables[0];
            user_thu.DataSource = dt_user;
            user_thu.DisplayMember = "hoten";
            user_thu.ValueMember = "id";
        }

        private void butIN_Click(object sender, EventArgs e)
        {
            v_user = "";
            
            for (int i = 0; i < user_thu.Items.Count; i++)
                if (user_thu.GetItemChecked(i)) v_user += dt_user.Rows[i]["ID"].ToString() + ",";
            v_user = v_user.Trim(',');

            sql=" select  c.hoten,d.sohieu,mavp,a.sobienlai,a.tamung,case when mavp in (select id from medibv.d_dmbd ) then sum(b.sotien) else 0 end thuoc,";
            sql+=" case when mavp in (select id from medibv.v_giavp ) then sum(b.sotien) else 0 end vienphi ";
            sql+=" from medibvmmyy.v_ttrvll a  inner join medibvmmyy.v_ttrvct b  on (a.id=b.id) inner join medibv.v_dlogin c on a.userid=c.id ";
            sql+=" inner join medibv.v_quyenso d on a.quyenso=d.id";            
            sql += "  where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + ngay.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + den.Text.Substring(0, 10) + "','dd/mm/yyyy')";
            if (v_user != "") sql += " and a.userid in(" + v_user + ")";
            sql += " group by c.hoten,d.sohieu,mavp,a.sobienlai,a.tamung order by a.sobienlai";
                        
            try
            {
                ds = a.get_data_mmyy(sql,ngay.Text,den.Text,true);
                if (ds == null || ds.Tables[0].Rows.Count < 0)
                {
                    MessageBox.Show(this,
lan.Change_language_MessageText("Không có dữ liệu báo cáo"), a.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ds.WriteXml("..//..//Datareport//v_BCDoanhthutonghop.xml", XmlWriteMode.WriteSchema);
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
				af.WindowState=FormWindowState.Maximized;
				af.Controls.Add(crystalReportViewer1);
				crystalReportViewer1.BringToFront();
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                string areport = "v_BCDoanhthutonghop.rpt", asyt = "", abv = "", angayin = "";
                areport = "v_BCDoanhthutonghop.rpt";
                asyt = a.Syte;
                abv = a.Tenbv;
                if (ngay.Value == den.Value) angayin = "Ngày " + ngay.Text;
                else angayin = "Từ Ngày " + ngay.Text + " Đến Ngày " + den.Text;

                ReportDocument cMain = new ReportDocument();

                cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ds);

                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = "Báo cáo doanh thu tổng hợp";
                af.Text = af.Text + " (" + areport + ")";
                af.ShowDialog();
            }
            catch { }

        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}