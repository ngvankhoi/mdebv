using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmTK_baolucgiadinh : Form
    {
        private DataSet ds1 = new DataSet();
        private DataSet ds2 = new DataSet();
        LibMedi.AccessData lib = new LibMedi.AccessData();
        private string sql, vtungay = "", vdenngay = "";
       private DataSet vds1=new DataSet();
        private DataSet vds = new DataSet();
        private DataSet v_ds=new DataSet();
        private string vschemas = "";
        public frmTK_baolucgiadinh()
        {
            InitializeComponent();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTK_baolucgiadinh_Load(object sender, EventArgs e)
        {
            vschemas = lib.user;
        }

        private void butIN_Click(object sender, EventArgs e)
        {
            vtungay = tungay.Text;
            vdenngay = denngay.Text;
            ds1 = new DataSet();
            ds1.ReadXml("..\\..\\DataXml\\m_baolucgiadinh_th.xml", XmlReadMode.Auto);
            ds2.ReadXml("..\\..\\DataXml\\m_dkbaolucgiadinh.xml", XmlReadMode.Auto);
            f_get_baolucgiadinh_th();
         
            if (!System.IO.Directory.Exists("..\\..\\DataXml")) System.IO.Directory.CreateDirectory("..\\..\\DataXml");
               ds1.WriteXml("..\\..\\DataXml\\TK_baolucgiadinh.xml", XmlWriteMode.WriteSchema);
               string vsngaytk = "Từ ngày "+tungay.Text+" đến ngày "+denngay.Text;
               frmReport f = new frmReport(lib, ds1, "rptTKbaolucgiadinh.rpt", vsngaytk, "", "", "", "", "");
               f.ShowDialog();
        }
        //private DataSet f_get_dsbaolucgd_th(  string vschemas ,string vtungay, string vdenngay)
       // { 
          
         //   return lib.get_data_mmyy(sql, vtungay, vdenngay, false);
       //  }
        private void  f_get_baolucgiadinh_th()
        {
           vds1 = f_get_baolucgiadinh(vschemas, vtungay, vdenngay, ds1, ds2);

            tongcong(lib, "ID>=3 and ID<=8", 2, 4);
         tongcong(lib, "ID>=10 and ID<=12", 9, 4);
         tongcong(lib, "ID>=14 and ID<=19", 13, 4);
         tongcong(lib, "ID>=21 and ID<=23", 20, 4);
         tongcong(lib, "ID>=25 and ID<=29", 24, 4);
         tongcong(lib, "ID>=31 and ID<=34",30, 4);
         tongcong(lib, "ID>=36 and ID<=40", 35, 4);
         tongcong(lib, "ID>=41 and ID<=43", 41, 4);
         tongcong(lib, "ID>=45 and ID<=48", 44, 4);
         tongcong(lib, "ID>=50 and ID<=51", 49, 4);
         tongcong(lib, "ID>=52 and ID<=54", 52, 4);
       }
        public DataSet f_get_baolucgiadinh(string vschemas,string vtungay, string vdenngay, DataSet ds1, DataSet ds2)
        {


            string vasql;
            string vasql_goc;
            string vcolumn;

            sql = "  select b.phai,c.maql,a.mabn,to_number(to_char(a.ngay,'yyyy'))-to_number(b.namsinh) as tuoi,d.mann,e.id  as tdhv,tthonnhan,c.quanhe, ";
            sql += "c.loaibaoluc,c.tgchiudung, c.chuyendi as noichuyenden,r.xuly,r.xutri,c.tonhaisk,r.kehoachantoan,r.chuyendi  ";
            sql += "from " + vschemas + ".benhandt a  ";
            sql += "inner join " + vschemas + ".btdbn b on a.mabn=b.mabn ";
            sql += "inner join " + vschemas + ".blgd_vao c on c.mabn=b.mabn ";
            sql += "inner join " + vschemas + ".btdnn d on d.mann=b.mann ";
            sql += "inner join " + vschemas + ".blgd_tdhv e on e.id=c.tdhv ";
            sql += "inner join " + vschemas + ".blgd_tthonnhan g on g.id=c.tthonnhan ";
            sql += "inner join " + vschemas + ".blgd_nguoigaybl h on h.id=c.quanhe ";
            sql += "inner join " + vschemas + ".blgd_loaibaoluc v on v.id =c.loaibaoluc ";
            sql += "inner join " + vschemas + ".blgd_tgchiudung j on j.id=c.tgchiudung ";
            sql += "inner join " + vschemas + ".blgd_ra r on r.mavaovien=c.mavaovien ";
            sql += "inner join " + vschemas + ".blgd_tonhaisk k on k.id=c.tonhaisk ";
            sql += "where to_date(to_char(c.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + vtungay + "','dd/mm/yyyy') and to_date('" + vdenngay + "','dd/mm/yyyy') ";

            sql += "union all ";
            sql = "select b.phai,c.maql,a.mabn,to_number(to_char(a.ngay,'yyyy'))-to_number(b.namsinh) as tuoi,d.mann,e.id  as tdhv,tthonnhan,c.quanhe, ";
            sql += "c.loaibaoluc,c.tgchiudung, c.chuyendi as noichuyenden,r.xuly,r.xutri,c.tonhaisk,r.kehoachantoan,r.chuyendi ";
            sql += "from xxx.benhanpk a  ";
            sql += "inner join  " + vschemas + ".btdbn b on a.mabn=b.mabn ";
            sql += "inner join " + vschemas + ".blgd_vao c on c.mabn=b.mabn ";
            sql += "inner join " + vschemas + ".btdnn d on d.mann=b.mann ";
            sql += "inner join " + vschemas + ".blgd_tdhv e on e.id=c.tdhv ";
            sql += "inner join " + vschemas + ".blgd_tthonnhan g on g.id=c.tthonnhan ";
            sql += "inner join " + vschemas + ".blgd_nguoigaybl h on h.id=c.quanhe ";
            sql += "inner join " + vschemas + ".blgd_loaibaoluc v on v.id =c.loaibaoluc ";
            sql += "inner join " + vschemas + ".blgd_tgchiudung j on j.id=c.tgchiudung ";
            sql += "inner join " + vschemas + ".blgd_ra r on r.mavaovien=c.mavaovien ";
            sql += "inner join " + vschemas + ".blgd_tonhaisk k on k.id=c.tonhaisk ";
            sql += "where to_date(to_char(c.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + vtungay + "','dd/mm/yyyy') and to_date('" + vdenngay + "','dd/mm/yyyy') ";

            sql += "union all ";
            sql += "select b.phai,c.maql,a.mabn,to_number(to_char(a.ngay,'yyyy'))-to_number(b.namsinh) as tuoi,d.mann,e.id  as tdhv,tthonnhan,c.quanhe, ";
            sql += "c.loaibaoluc,c.tgchiudung, c.chuyendi as noichuyenden,r.xuly,r.xutri,c.tonhaisk,r.kehoachantoan,r.chuyendi  ";
            sql += "from xxx.benhancc a  ";
            sql += "inner join  " + vschemas + ".btdbn b on a.mabn=b.mabn ";
            sql += "inner join " + vschemas + ".blgd_vao c on c.mabn=b.mabn ";
            sql += "inner join " + vschemas + ".btdnn d on d.mann=b.mann ";
            sql += "inner join " + vschemas + ".blgd_tdhv e on e.id=c.tdhv ";
            sql += "inner join " + vschemas + ".blgd_tthonnhan g on g.id=c.tthonnhan ";
            sql += "inner join " + vschemas + ".blgd_nguoigaybl h on h.id=c.quanhe ";
            sql += "inner join " + vschemas + ".blgd_loaibaoluc v on v.id =c.loaibaoluc ";
            sql += "inner join " + vschemas + ".blgd_tgchiudung j on j.id=c.tgchiudung ";
            sql += "inner join " + vschemas + ".blgd_ra r on r.mavaovien=c.mavaovien ";
            sql += "inner join " + vschemas + ".blgd_tonhaisk k on k.id=c.tonhaisk ";
            sql += "where to_date(to_char(c.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + vtungay + "','dd/mm/yyyy') and to_date('" + vdenngay + "','dd/mm/yyyy') ";


            sql += "union all ";
            sql += "select b.phai,c.maql,a.mabn,to_number(to_char(a.ngay,'yyyy'))-to_number(b.namsinh) as tuoi,d.mann,e.id  as tdhv,tthonnhan,c.quanhe, ";
            sql += "c.loaibaoluc,c.tgchiudung, c.chuyendi as nochuyenden,r.xuly,xutri,c.tonhaisk,r.kehoachantoan,r.chuyendi  ";
            sql += "from " + vschemas + ".benhanngtr a  ";
            sql += "inner join  " + vschemas + ".btdbn b on a.mabn=b.mabn ";
            sql += "inner join " + vschemas + ".blgd_vao c on c.mabn=b.mabn ";
            sql += "inner join " + vschemas + ".btdnn d on d.mann=b.mann ";
            sql += "inner join " + vschemas + ".blgd_tdhv e on e.id=c.tdhv ";
            sql += "inner join " + vschemas + ".blgd_tthonnhan g on g.id=c.tthonnhan ";
            sql += "inner join " + vschemas + ".blgd_nguoigaybl h on h.id=c.quanhe ";
            sql += "inner join " + vschemas + ".blgd_loaibaoluc v on v.id =c.loaibaoluc ";
            sql += "inner join " + vschemas + ".blgd_tgchiudung j on j.id=c.tgchiudung ";
            sql += "inner join " + vschemas + ".blgd_ra r on r.mavaovien=c.mavaovien ";
            sql += "inner join " + vschemas + ".blgd_tonhaisk k on k.id=c.tonhaisk ";
            sql += "where to_date(to_char(c.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + vtungay + "','dd/mm/yyyy') and to_date('" + vdenngay + "','dd/mm/yyyy') ";


            vds = lib.get_data_mmyy(sql, vtungay, vdenngay,true);
            //DataSet vds = f_get_dsbaolucgd_th(vschemas, vtungay, vdenngay);
            DataRow[] ar;
           
            foreach (DataRow r in ds1.Tables[0].Rows)
            {
                vasql = "";
                vasql_goc = r["value"].ToString();
                vcolumn = "";
                try
                {
                    foreach (DataRow r1 in ds2.Tables[0].Rows)
                    {
                        vcolumn = r1["ten"].ToString();
                        if (vasql_goc != "")
                        {
                            vasql = vasql_goc + " and " + r1["value"].ToString();
                        }
                        else
                            vasql = " and " + r1["value"].ToString();
                        ar = vds.Tables[0].Select(vasql);
                        if (ar.Length > 0)
                        {
                            r[vcolumn] = ar.Length;
                          
                        }
                    }

                }
                catch { }
              
            }

         ds1.AcceptChanges();
             return ds1;
         
        }
     private void tongcong(LibMedi.AccessData m,string exp, int ma, int k)
        {
            decimal l_tong = 0M;
            DataRow[] r1 =  vds1.Tables[0].Select(exp);
            short iRec = Convert.ToInt16(r1.Length);
            for (int j = k; j <  vds1.Tables[0].Columns.Count; j++)
            {
                l_tong = 0M;
                for (short i = 0; i < iRec; i = (short)(i + 1))
                {
                    l_tong += decimal.Parse(r1[i][j].ToString());
                }
                updrec_145( vds1.Tables[0], ma, j, l_tong);
            }
        }
          public void updrec_145(DataTable dt, int stt, int col, Decimal so)
        {
            DataRow[] dr = dt.Select("ID=" + stt);
            dr[0][col] = so;
        }

      
        
        }

    }
