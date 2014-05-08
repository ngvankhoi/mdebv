using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using LibVP;
using Excel;

namespace Vienphi
{
    public partial class frmDoanhthu_domedic : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();



        private AccessData m_v;

        private string sql = "",  haison = "", tenfile = "", v_user = "";

        private DataColumn dc;
        private DataRow r1, r2;
        private DataRow[] dr;

        private System.Data.DataTable dt_user = new System.Data.DataTable();
        private DataSet ads;
        private DataSet ads1;


        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        Excel.Range orange;

        public frmDoanhthu_domedic(LibVP.AccessData v)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m_v = v;
        }

        private void frmDoanhthu_domedic_Load(object sender, EventArgs e)
        {
            dt_user = m_v.get_data("select * from medibv.v_dlogin order by id").Tables[0];
            user_thu.DataSource = dt_user;
            user_thu.DisplayMember = "hoten";
            user_thu.ValueMember = "id";
        }
        private void taotable()
        {
            haison = "";
            ads = new DataSet();
            ads1 = new DataSet();
            v_user = v_user.Trim(',');
            sql = "select * from medibv.v_dlogin ";
            if (v_user != "")
            {
                sql += " where id in(" + v_user + ")";
            }
            ads1 = m_v.get_data(sql);

            ads.Tables.Add("Table");
            ads.Tables[0].Columns.Add(new DataColumn("loai", typeof(decimal)));
            ads.Tables[0].Columns.Add(new DataColumn("noidung", typeof(string)));

            

            foreach (DataRow r in ads1.Tables[0].Rows)
            {
                if (checkBox1.Checked)
                {
                    haison += r["hoten"].ToString() + "+ ";
                }
                else
                {
                    haison += r["userid"].ToString() + "+ ";
                }
                dc = new DataColumn();
                dc.ColumnName = "id_" + r["id"].ToString();
                dc.DataType = Type.GetType("System.Decimal");
                ads.Tables[0].Columns.Add(dc);
            }
            haison += "Tổng cộng+ ";
            dc = new DataColumn();
            dc.ColumnName = "tongcong";
            dc.DataType = Type.GetType("System.Decimal");
            ads.Tables[0].Columns.Add(dc);
        }

        private void butIN_Click(object sender, EventArgs e)
        {
            v_user = "";
            string  exp = "";

            for (int i = 0; i < user_thu.Items.Count; i++)
                if (user_thu.GetItemChecked(i)) v_user += dt_user.Rows[i]["ID"].ToString() + ",";
            v_user = v_user.Trim(',');
            taotable();            

            if (v_user != "")
            {
                exp = " and bb.userid in(" + v_user + ")";
            }
            sql = "select 1 as loai,'Trực tiếp' as noidung, (nvl(sum(soluong*dongia),0)-nvl(sum(c.sotien),0)) as sotien,userid as id from medibvmmyy.v_vienphict a inner join medibvmmyy.v_vienphill bb on a.id=bb.id left join medibvmmyy.v_mienngtru c on a.id=c.id where  to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + den.Text.Substring(0, 10) + "','dd/mm/yyyy')";
            sql += " " + exp + " group by userid";            
            ins_items();

            sql = "select 2 as loai,'Tạm ứng' as noidung, nvl(sum(bb.sotien),0) as sotien,bb.userid as id  from medibvmmyy.v_tamung bb where to_date(to_char(bb.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + den.Text.Substring(0, 10) + "','dd/mm/yyyy')";
            sql += "  " + exp + " group by userid";            
            ins_items();

            sql = "select 3 as loai,'Ra viện' as noidung, nvl(sum(bb.sotien-bb.tamung-bb.mien-bb.bhyt-bb.mien),0) as sotien,bb.userid as id from medibvmmyy.v_ttrvll bb where to_date(to_char(bb.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + den.Text.Substring(0, 10) + "','dd/mm/yyyy')";
            sql += "  " + exp + "  group by bb.userid";            
            ins_items();

            sql = "select 4 as loai,'Hoàn trả' as noidung,-sum(case when bb.tamung>bb.sotien then bb.tamung-bb.sotien else 0 end) as sotien,bb.userid as id ";
            sql += " from medibvmmyy.v_ttrvll bb where to_date(to_char(bb.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + den.Text.Substring(0, 10) + "','dd/mm/yyyy')";
            sql += " " + exp + "   group by bb.userid";
            ins_items();        

            if (ads.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu."), m_v.s_AppName);
                return;
            }
            exp_excel(false);
        }
        private void exp_excel(bool print)
        {
            try
            {
                m_v.check_process_Excel();
                int i_rec = 0, be = 4, dong = 6, sodong = ads.Tables[0].Rows.Count + 6, socot = ads.Tables[0].Columns.Count - 1, dongke = sodong - 1;
                char[] cSplit ={ '+' };
                string[] sTitle = haison.Split(cSplit);
                i_rec = sTitle.Length;
                tenfile = m_v.f_export_excel(ads.Tables[0], "doanhthu");                
                oxl = new Excel.Application();

                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;

                for (int i = 0; i < be; i++) osheet.get_Range(m_v.getIndex(i) + "1", m_v.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
                osheet.get_Range(m_v.getIndex(0) + "5", m_v.getIndex(0) + "5").EntireRow.Delete(Missing.Value);//remove row field
                osheet.get_Range(m_v.getIndex(2) + "5", m_v.getIndex(socot) + sodong.ToString()).NumberFormat = "###,###,###,###";
                osheet.get_Range(m_v.getIndex(0) + "4", m_v.getIndex(socot) + dongke.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;

                osheet.Cells[dong - 2, 1] = "STT";
                osheet.Cells[dong - 2, 2] = "Nội dung";
               
                osheet.Cells[dong + 3, 2] = "Tổng cộng";

                for (int i = 0; i < i_rec; i++)
                {
                    osheet.Cells[dong - 2, i + 3] = sTitle[i].ToString();
                    osheet.Cells[dong + 3, i + 3] = "=SUM(" + m_v.getIndex(i+2) + "5:"+ m_v.getIndex(i+2) + "8)";
                }

                orange = osheet.get_Range(m_v.getIndex(i_rec * 2 + 4) + "4", m_v.getIndex(i_rec * 2 + 5) + "4");               
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Bold = true;
                orange = osheet.get_Range(m_v.getIndex(0) + "1", m_v.getIndex(socot) + sodong.ToString());
                orange.Font.Name = "Arial";
                orange.Font.Size = 8;
                orange.EntireColumn.AutoFit();
                oxl.ActiveWindow.DisplayZeros = false;
                osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                osheet.PageSetup.LeftMargin = 20;
                osheet.PageSetup.RightMargin = 20;
                osheet.PageSetup.TopMargin = 30;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                osheet.Cells[1, 1] = m_v.Syte; osheet.Cells[2, 1] = m_v.Tenbv;
                orange = osheet.get_Range(m_v.getIndex(1) + "1", m_v.getIndex(3) + "2");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                osheet.Cells[1, 8] = "BÁO CÁO DOANH THU THEO NGƯỜI THU";
                osheet.Cells[2, 8] = (tu.Value == den.Value) ? "Ngày " + tu.Text : "Từ ngày :" + tu.Text + " đến ngày :" + den.Text;
                orange = osheet.get_Range(m_v.getIndex(3) + "1", m_v.getIndex(socot - 1) + "2");

                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size = 12;
                orange.Font.Bold = true;
                if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                else oxl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void ins_items()
        {
            string s_exp = "";
            foreach (DataRow r in m_v.get_data_mmyy(sql, tu.Text.Substring(0, 10), den.Text.Substring(0, 10), false).Tables[0].Rows)
            {
                s_exp = "loai=" + r["loai"].ToString();
                r1 = m_v.getrowbyid(ads.Tables[0], s_exp);
                if (r1 == null)
                {
                    r2 = ads.Tables[0].NewRow();
                    r2["loai"] = r["loai"].ToString();
                    r2["noidung"] = r["noidung"].ToString();
                    foreach (DataRow rr in ads1.Tables[0].Rows)
                    {
                        r2["id_" + rr["id"].ToString()] = 0;
                    }
                    r2["id_" + r["id"].ToString()] = decimal.Parse(r["sotien"].ToString());
                    r2["tongcong"] = decimal.Parse(r["sotien"].ToString());
                    ads.Tables[0].Rows.Add(r2);
                }
                else
                {
                    dr = ads.Tables[0].Select(s_exp);
                    dr[0]["id_" + r["id"].ToString()] = (dr[0]["id_" + r["id"].ToString()].ToString().Trim() == "") ? 0 : decimal.Parse(dr[0]["id_" + r["id"].ToString()].ToString()) + decimal.Parse(r["sotien"].ToString());
                    dr[0]["tongcong"] = (dr[0]["tongcong"].ToString().Trim() == "") ? 0 : decimal.Parse(dr[0]["tongcong"].ToString()) + decimal.Parse(r["sotien"].ToString());
                }
            }
            ads.AcceptChanges();
        }

        private void tu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void den_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}