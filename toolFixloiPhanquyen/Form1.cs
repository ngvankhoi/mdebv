using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace toolFixloiPhanquyen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LibDuoc.AccessData ac = new LibDuoc.AccessData();
                backgroundWorker1.ReportProgress(0,"Bắt đầu xử lý....");
                using (Npgsql.NpgsqlCommand cmm = new Npgsql.NpgsqlCommand("select * from medibv.d_menuitem where id = '000' and id_goc ='901'", new Npgsql.NpgsqlConnection(ac.ConStr)))
                {
                    try
                    {
                        cmm.Connection.Open();
                        if (cmm.ExecuteReader().HasRows)
                        {
                            cmm.CommandText = "UPDATE medibv.d_menuitem   SET id='23400', id_menu='23400' WHERE id = '000' and id_goc ='901'";
                            cmm.ExecuteNonQuery();
                            cmm.CommandText = "select id,userid,right_ from medibv.d_dlogin";
                            Npgsql.NpgsqlDataAdapter apd = new Npgsql.NpgsqlDataAdapter(cmm);
                            DataTable ls_user = new DataTable(); 
                            apd.Fill(ls_user);
                            Npgsql.NpgsqlTransaction T = cmm.Connection.BeginTransaction();
                            foreach (DataRow dtr in ls_user.Rows)
                            {
                                string right = dtr["right_"].ToString();
                                if (right.Contains("+000"))
                                {
                                   right= right.Replace("+000", "+23400");
                                    string upd = "UPDATE medibv.d_dlogin set right_='" + right + "' where id='" + dtr["id"].ToString() + "'";
                                    cmm.CommandText = upd;
                                    cmm.ExecuteNonQuery();
                                }
                            }
                            T.Commit();
                            backgroundWorker1.ReportProgress(100, "Hoàn thành.");
                            e.Result = true;
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        cmm.Connection.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không kết nối được với cơ sở dữ liệu!. \nHãy thử copy tool và các file dll vào thư mục chứa chương trình Dược và chạy lại.","Lỗi");
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && (bool)e.Result == true)
            {
                MessageBox.Show("Hoàn tất.");
            }
            button1.Enabled = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                progressBar1.Value = e.ProgressPercentage;
                if (e.UserState != null)
                    lb_status.Text = e.UserState.ToString();
            });           
        }
    }
}