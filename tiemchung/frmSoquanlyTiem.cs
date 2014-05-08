using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tiemchung
{
    public partial class frmSoquanlyTiem : Form
    {
        LibMedi.AccessData m;
        DataSet ds;
        string sql = "",s_chinhanh="";
        Language lan = new Language();
        
        public frmSoquanlyTiem(LibMedi.AccessData _m)
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
            sql = "select a.mabn,m.hoten,case when m.phai='0' then '"+lan.Change_language_MessageText("Nam")+"' else '"+lan.Change_language_MessageText("Nữ")+"' end phai,case when k.sonha='' then '' else k.sonha||', ' end || case when k.thon='' then '' else  k.thon||', ' end ||k3.tenpxa||', '||k2.tenquan||', '||k1.tentt as diachi, ";
            sql += " substr(k.tuoivao,1,3)||case when substr(k.tuoivao,4,1)='0' then '' else case when substr(k.tuoivao,4,1)='1' then ' "+lan.Change_language_MessageText("tháng")+"' else case when substr(k.tuoivao,4,1)='2' then ' "+lan.Change_language_MessageText("ngày")+"' else case when substr(k.tuoivao,4,1)='2' then ' "+lan.Change_language_MessageText("giờ")+"' end end end end as tuoi, ";
            sql += " j.ten loai,b.ten thuoc,a.muitiem,b.duongdung,a.vitritiem,c.hoten nguoitiem,to_char(a.ngaytiem,'dd/mm/yyyy hh24:mi') ngaytiem , d.sttt,g.ten hangsx,h.ten nhacungcap,  ";
            sql += " case when to_number(f.handung)=0 then '' else f.handung end handung,f.losx,a.phanung,a.mabd ,n.tenkp,a.makp   ";
            sql += " from " + m.user + ".phieutiemchung a left join " + m.user + ".dmbs c on a.mabs=c.ma left join " + m.user + ".btdkp_bv n on a.makp=n.makp, " + m.user + ".d_dmbd b, xxx.v_chidinh e,xxx.d_xuatsdct d,  xxx.d_theodoi f, ";
            sql += " " + m.user + ".d_dmhang g, " + m.user + ".d_dmnx h ," + m.user + ".d_dmloai j," + m.user + ".btdbn m,xxx.lienhe k ";
            sql += " left join " + m.user + ".btdtt k1 on k.matt=k1.matt left join " + m.user + ".btdquan k2 on k.maqu=k2.maqu left join " + m.user + ".btdpxa k3 on k.maphuongxa=k3.maphuongxa  ";
            sql += " where a.mabd=b.id and e.idduoc=d.id and a.mabd=d.mabd and e.id=a.id and f.id=d.sttt and b.mahang=g.id and f.nhomcc=h.id and j.id=b.maloai and k.maql=e.maql and m.mabn=a.mabn ";

            ds = m.get_data_mmyy(sql, tungay.Text.Substring(0, 10), denngay.Text.Substring(0, 10), 0);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibMedi.AccessData.Msg);
                return;
            }
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\..\\dataxml")) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                ds.WriteXml("..\\..\\dataxml\\rptSoquanlyTiem.xml", XmlWriteMode.WriteSchema);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds.Tables[0], "rptSoquanlyTiem.rpt", s_chinhanh, tungay.Text.Substring(0, 10), denngay.Text.Substring(0, 10), "", "", "", "", "", "", "");
                f.ShowDialog();
            }
        }

        private void frmSoquanlyTiem_Load(object sender, EventArgs e)
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