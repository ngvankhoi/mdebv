using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Server
{
    public partial class frmDongBoKSK : Form
    {
        DataSet dsdoan;
        DAL.Accessdata m_dal = new DAL.Accessdata();
        DAL.Client m_server = new DAL.Client();
        
        List<DAL.Client> list;
        DataSet dsxml_ksk = new DataSet();
        double i_khoang_cach_ngay = 5;
        public frmDongBoKSK()
        {
            InitializeComponent();
        }
        private void Load_Data()
        {
            dsdoan=m_dal.LayDanhSachDoan();
            dgDSDoan.DataSource = dsdoan.Tables[0];

        }

        private void frmDongBoKSK_Load(object sender, EventArgs e)
        {
            Load_Data();
            load_table();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dgDSDoan.DataSource];
            DataView dv = (DataView)cm.List;
            long l_iddoanksk = 0;
            foreach (DataRow r in dv.Table.Select("chon=true"))
            {
                l_iddoanksk = long.Parse(r["id"].ToString());
                Dongbo_khamsuckhoe(l_iddoanksk);
            }
        }

        public void Dongbo_khamsuckhoe(long m_iddoanksk)
        {
            this.Cursor = Cursors.WaitCursor;
            lblstatuss.Text = "Running ...";
            load_listview();
            string schema = "", table = "", dieukien = "";
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

        private void load_table()
        {
            dsxml_ksk = DAL.Manager.SynTable_KSK("");
            
        }

        private void load_listview()
        {
            list = DAL.Manager.listClient();
        }
    }
}