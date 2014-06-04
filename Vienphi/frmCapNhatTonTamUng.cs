using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Vienphi
{
    public partial class frmCapNhatTonTamUng : Form
    {
        public delegate void XuLyCapNhatTonTamUngHoanTat();
        public event XuLyCapNhatTonTamUngHoanTat HoanTatXuLy;
        private LibVP.AccessData m_v;
        private string m_userid = "";
        public frmCapNhatTonTamUng(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();
            m_v = v_v;
            m_userid = v_userid;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0);
            string curSchema = m_v.get_mmyy(DateTime.Today.ToString("dd/MM/yyyy"));
            //  DateTime premonth = DateTime.Today;
            // premonth.AddMonths(-1);
            //string preSchema = m_v.get_mmyy(premonth.ToString("dd/MM/yyyy"));
            string sql_schemammyy = "select schema_name,substring(schema_name from char_length(schema_name)-3) mmyy from information_schema.schemata where  schema_name Like 'medibv0%' or schema_name Like 'medibv1%' ";
            //   formStatus fst = new formStatus();
            //  fst.progressBar1.Value = 0;
            // fst.Show();
            List<KeyValuePair<int, string>> Schemas = new List<KeyValuePair<int, string>>();
            using (Npgsql.NpgsqlCommand cmm = new Npgsql.NpgsqlCommand(sql_schemammyy, new Npgsql.NpgsqlConnection(m_v.ConStr)))
            {
                try
                {
                    cmm.Connection.Open();
                    Npgsql.NpgsqlDataReader read = cmm.ExecuteReader();
                    while (read.Read())
                    {
                        Schemas.Add(new KeyValuePair<int, string>(int.Parse(read["mmyy"].ToString().Substring(2) + read["mmyy"].ToString().Substring(0, 2)), read["schema_name"].ToString()));
                    }
                }
                finally
                {
                    cmm.Connection.Close();
                }
            }

            Schemas.Sort(delegate(KeyValuePair<int, string> p1, KeyValuePair<int, string> p2)
                         {
                             return p1.Key.CompareTo(p2.Key);
                         });

            for (int i = 0; i < Schemas.Count - 1; i++)
            {
                int keymmdd = Schemas.ToArray()[i + 1].Key;
                string ngaydauthang = "20" + (keymmdd / 100) + "-" + ((int)(keymmdd % 100)).ToString("00") + "-01";
                string currschema = Schemas.ToArray()[i].Value;
                string nextschema = Schemas.ToArray()[i + 1].Value;
                string sql_bosung = "INSERT INTO " + nextschema + ".v_tontamung( id, mabn, mavaovien, maql, idkhoa, quyenso, sobienlai, ngay, loai, makp, madoituong, sotien, ketoan, done, lanin, loaibn,idttrv, datru, userid, ngaytra, idcomputer, mmyy, idsystem ) select * from(select id, mabn, mavaovien, maql, idkhoa, quyenso, sobienlai, ngay, loai, makp, madoituong, sotien, ketoan,case when done = 1 then case when date_trunc('month',ngaytra) > date_trunc('month',date '" + ngaydauthang + "') then 0 else 1 end else done end  , lanin, loaibn,idttrv, datru, userid,ngaytra , idcomputer, mmyy, idsystem from " + currschema + ".v_tamung where done =0 or (date_trunc('month',ngaytra)>date_trunc('month',ngay))  union all select id, mabn, mavaovien, maql, idkhoa, quyenso, sobienlai, ngay, loai, makp, madoituong, sotien, ketoan, case when ngaytra is not null then case when date_trunc('month',ngaytra)<= date_trunc('month',date '" + ngaydauthang + "') then 1 else 0 end else 0 end, lanin, loaibn,idttrv, datru, userid, ngaytra, idcomputer, mmyy, idsystem from " + currschema + ".v_tontamung where done = 0) where id not in (select id from " + nextschema + ".v_tontamung)";
                string sql_capnhat = "UPDATE " + nextschema + ".v_tontamung SET sotien=b.sotien, ngaytra=b.ngaytra from (" + nextschema + ".v_tontamung as a inner join (select * from(select id, mabn, mavaovien, maql, idkhoa, quyenso, sobienlai, ngay, loai, makp, madoituong, sotien, ketoan,case when done = 1 then case when date_trunc('month',ngaytra) > date_trunc('month',date '" + ngaydauthang + "') then 0 else 1 end else done end  , lanin, loaibn,idttrv, datru, userid,ngaytra , idcomputer, mmyy, idsystem from " + currschema + ".v_tamung where done =0 or (date_trunc('month',ngaytra)>date_trunc('month',ngay))  union all select id, mabn, mavaovien, maql, idkhoa, quyenso, sobienlai, ngay, loai, makp, madoituong, sotien, ketoan, case when ngaytra is not null then case when date_trunc('month',ngaytra)<= date_trunc('month',date '" + ngaydauthang + "') then 1 else 0 end else 0 end, lanin, loaibn,idttrv, datru, userid, ngaytra, idcomputer, mmyy, idsystem from " + currschema + ".v_tontamung where done = 0) where id in (select id from " + nextschema + ".v_tontamung)) as b on a.id = b.id ) where "+ nextschema + ".v_tontamung.id = a.id";
                using (Npgsql.NpgsqlCommand cmm = new Npgsql.NpgsqlCommand(sql_bosung, new Npgsql.NpgsqlConnection(m_v.ConStr)))
                {
                    try
                    {
                        backgroundWorker1.ReportProgress((int)((((float)i) / ((float)Schemas.Count) * 100) + (1 / (float)Schemas.Count * 100) / 2));

                        cmm.Connection.Open();
                        cmm.ExecuteNonQuery();
                        backgroundWorker1.ReportProgress((int)(((float)i + 1) / ((float)Schemas.Count) * 100));
                        // fst.progressBar1.Value = (int)((((float)i) / ((float)Schemas.Count) * 100) + (1 / (float)Schemas.Count * 100) / 2);
                        cmm.CommandText = sql_capnhat;
                        cmm.ExecuteNonQuery();

                        //fst.progressBar1.Value = (int)(((float)i + 1) / ((float)Schemas.Count) * 100);
                    }
                    catch
                    {
 
                    }
                    finally
                    {
                        cmm.Connection.Close();
                    }
                }
                //Thread.Sleep(10);
            }
            //  fst.Close();
            //
            backgroundWorker1.ReportProgress(95);
            using (Npgsql.NpgsqlCommand cmm = new Npgsql.NpgsqlCommand("INSERT INTO updatedatatontamung( ngayupdate, userid) VALUES (:ngayupdate, :userid)", new Npgsql.NpgsqlConnection(m_v.ConStr)))
            {
                try
                {
                    cmm.Connection.Open();
                    cmm.Parameters.Add(":ngayupdate", DateTime.Now);
                    cmm.Parameters.Add(":userid", m_userid);
                    cmm.ExecuteNonQuery();
                }
                finally
                {
                    cmm.Connection.Close();
                }
            }
            backgroundWorker1.ReportProgress(100);
            Thread.Sleep(500);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MessageBox.Show("persent:" + e.ProgressPercentage);
            //progressBar1.            
            this.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.ProgressPercentage;
            });
           // this.Refresh();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            this.Close();
            if (this.HoanTatXuLy != null)
                this.HoanTatXuLy();
        }
        public void ThucHien()
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void formStatus_Load(object sender, EventArgs e)
        {
          
           
        }

        private void formStatus_Activated(object sender, EventArgs e)
        {

        }
    }
}