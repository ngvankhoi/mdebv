using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmStatusProcess : Form
    {
        public delegate void DoWorkEventHandler(BackgroundWorker sender,DoWorkEventArgs e);
        public event DoWorkEventHandler DoWork;
        public event System.ComponentModel.RunWorkerCompletedEventHandler WorkerCompleted;
        public event System.ComponentModel.ProgressChangedEventHandler ProgressChange;
        public void ShowRunWorkerAsync()
        {
            this.Show();
            backgroundWorker.RunWorkerAsync();
        }
        public void ShowRunWorkerAsync(object arg)
        {
            this.Show();
            backgroundWorker.RunWorkerAsync(arg);
        }
        public frmStatusProcess()
        {
           
            InitializeComponent();
            lb_TenTienTrinh.Text = "";
           // backgroundWorker.RunWorkerAsync
        }
        public frmStatusProcess(string tentientrinh): this()
        {
            lb_TenTienTrinh.Text = tentientrinh;
        }
        /// <summary>
        /// sender is BackgroundWorker type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Value = 0;
            if (DoWork != null)
                DoWork(backgroundWorker, e);
        }
        
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressChange != null)
                ProgressChange(sender, e);
            this.Invoke((MethodInvoker)delegate()
            {
                progressBar1.Value = e.ProgressPercentage;
                if (e.UserState != null)
                    lb_trangthai.Text = e.UserState.ToString();
            });
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
            if (WorkerCompleted != null)
                WorkerCompleted(sender, e);
            
        }

        private void fromStatus_Load(object sender, EventArgs e)
        {

        }
    }
}