using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tiemchung
{
    public partial class frmSoquanlyVaccin : Form
    {
        LibMedi.AccessData m;
        DataSet ds;
        string sql = "",s_chinhanh="";
        Language lan = new Language();
        
        public frmSoquanlyVaccin(LibMedi.AccessData _m)
        {
            InitializeComponent();
            m = _m;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butin_Click(object sender, EventArgs e)
        {
            sql = "select to_char(b.ngaysp,'dd/mm/yyyy') ngaysp,b.sohd,a.ten tenbd,a.ma, a.id mabd,a.hamluong,a.dang,a.tenhc,d1.ten nhomcc,nvl(b.soluong,0) slnhap,nvl(f.soluong,0) slxuat,d.losx, ";
            sql += " d.handung,aa.ten||case when a.manuoc=0 then '' else ' ('||ab.ten||')' end hang,nvl(g.soluong,0) slhuy,e.tondau+e.slnhap-e.slxuat ton  ";
            sql += " from " + m.user + ".d_dmbd a left join " + m.user + ".d_dmhang aa on a.mahang=aa.id left join " + m.user + ".d_dmnuoc ab on a.manuoc=ab.id  , xxx.d_theodoi d  ";
            sql += " left join  (select b.sttt,sum(b.soluong) soluong from xxx.d_xuatsdll a, xxx.d_xuatsdct b where a.id=b.id and a.loai=2 and a.ngay between to_date('" + tungay.Text.Substring(0, 10) + "','dd/mm/yyyy')  ";
            sql += " and to_date('" + denngay.Text.Substring(0, 10) + "','dd/mm/yyyy') group by b.sttt) f on d.id=f.sttt  ";
            sql += " left join  (select b.sttt,sum(b.soluong) soluong from xxx.d_xuatll a, xxx.d_xuatct b where a.id=b.id and a.loai='XK' and a.ngay between to_date('" + tungay.Text.Substring(0, 10) + "','dd/mm/yyyy')  ";
            sql += " and to_date('" + denngay.Text.Substring(0, 10) + "','dd/mm/yyyy') group by b.sttt) g on d.id=g.sttt   ";
            sql += " left join xxx.d_tonkhoct e on d.id=e.stt left join ( select b.ngaysp,b.sohd,b.id,c.stt,c.soluong from xxx.d_nhapct c  ,xxx.d_nhapll b where b.id=c.id  ";
            sql += " and b.ngaysp between to_date('" + tungay.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + denngay.Text.Substring(0, 10) + "','dd/mm/yyyy') ) b on e.idn=b.id and e.sttn=b.stt ";
            sql += " left join medibv.d_dmnx d1 on d.nhomcc=d1.id   ";
            sql += " where a.vacxin=1 and a.id=d.mabd ";

            ds = m.get_data_mmyy(sql, tungay.Text.Substring(0, 10), denngay.Text.Substring(0, 10), 0);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibMedi.AccessData.Msg);
                return;
            }
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\..\\dataxml")) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                ds.WriteXml("..\\..\\dataxml\\rptSoquanlyVacxin.xml", XmlWriteMode.WriteSchema);
            }
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds.Tables[0], "rptSoquanlyVacxin.rpt", s_chinhanh, tungay.Text.Substring(0, 10), denngay.Text.Substring(0, 10), "", "","","", "", "", "");
                f.ShowDialog();
            }
        }

        private void frmSoquanlyVaccin_Load(object sender, EventArgs e)
        {
            int idchinhanh = m.i_Chinhanh_hientai;
            sql = "select ten from "+m.user+".dmchinhanh where id="+idchinhanh;
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                s_chinhanh = r["ten"].ToString();
            }
        }
    }
}