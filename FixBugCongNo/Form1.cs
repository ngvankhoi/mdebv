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