using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FixBugCongNo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LibDuoc.AccessData d = new LibDuoc.AccessData();
        private void Form1_Load(object sender, EventArgs e)
        {
            lb_status.Text = "Click button 'Tiến hành sửa lỗi' để bắt đầu tiến trình.....";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0, "Duyệt danh sách Schema...");
            string sql_schemammyy = "select schema_name,substring(schema_name from char_length(schema_name)-3) mmyy from information_schema.schemata where  schema_name Like 'medibv_%' ";
            //   formStatus fst = new formStatus();
            //  fst.progressBar1.Value = 0;
            // fst.Show();
            List<KeyValuePair<int, string>> Schemas = new List<KeyValuePair<int, string>>();
            using (Npgsql.NpgsqlCommand cmm = new Npgsql.NpgsqlCommand(sql_schemammyy, new Npgsql.NpgsqlConnection(d.ConStr)))
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

            backgroundWorker1.ReportProgress(5, "Tiến hành fix lỗi.....");
            for(int i=0; i< Schemas.Count;i++)
            {
                string sql1 = "select * from information_schema.key_column_usage where constraint_name = 'fk_d_thanhtoan_d_nhapll' and constraint_schema = '"+Schemas.ToArray()[i].Value+"' and table_name = 'd_thanhtoan'";
                using(Npgsql.NpgsqlCommand comm = new Npgsql.NpgsqlCommand(sql1,new Npgsql.NpgsqlConnection(d.ConStr)))
                {
                    try
                    {
                        backgroundWorker1.ReportProgress((int)((float)i / (float)Schemas.Count * 95) +5, "Fix lỗi Schema:" + Schemas.ToArray()[i].Value);
                        comm.Connection.Open();
                        if (comm.ExecuteReader().HasRows)
                        {
                            string slq2 = "alter table " + Schemas.ToArray()[i].Value + ".d_thanhtoan drop constraint fk_d_thanhtoan_d_nhapll";
                            comm.CommandText = slq2;
                            comm.ExecuteNonQuery();
                        }
                        string slq3 = "alter table " + Schemas.ToArray()[i].Value + ".d_thanhtoan add constraint fk_d_thanhtoan_d_nhapll foreign key (id) references " + Schemas.ToArray()[i].Value + ".d_nhapll (id) match simple on update restrict on delete restrict";
                        comm.CommandText = slq3;
                        comm.ExecuteNonQuery();

                        string sql4 = "INSERT INTO " +Schemas.ToArray()[i].Value+".d_thanhtoan( id, ngay,  sotien,  sotiennovat, ghichu, userid,  mmyy) select id,ngayud as ngay,0 as sotien,0 as sotiennovat,varchar 'fix by tool' as ghichu,userid, mmyy   from "+ Schemas.ToArray()[i].Value+".d_nhapll where id not in (select id from "+ Schemas.ToArray()[i].Value+".d_thanhtoan)";
                        comm.CommandText = sql4;
                        comm.ExecuteNonQuery();
                    }
                    catch
                    {}
                    finally
                    {
                        comm.Connection.Close();
                       
                    }
                }

            }
            backgroundWorker1.ReportProgress(100, "Hoàn tất!");

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                progressBar1.Value = e.ProgressPercentage;
                lb_status.Text = e.UserState.ToString();
            });
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Hoàn tất fix lỗi!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }
    }
}