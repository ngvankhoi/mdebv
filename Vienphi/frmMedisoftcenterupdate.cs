using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmMedisoftcenterupdate : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string m_userid="",m_loaidata="";
        public frmMedisoftcenterupdate(LibVP.AccessData v_v, string v_userid, string v_loaidata)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
            lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
         
            m_v = v_v;
            m_loaidata = v_loaidata;
            m_userid = v_userid;
            m_v.f_SetEvent(this);
        }

        private void frmMedisoftcenterupdate_Load(object sender, EventArgs e)
        {
            switch (m_loaidata)
            {
                case "DMXN":
                    break;
                case "DMVT":
                    break;
                case "DMBP":
                    break;
                case "DMVTLM":
                    break;
                case "DMKS":
                    break;
                default:
                    break;
            }
            butDownload.Enabled = false;
            butSave.Enabled = false;
            timer1.Interval = 2;
            timer1.Enabled = true;
            f_Load_Data();
        }
        private void f_Load_Data()
        {
            try
            {
                dataGridView1.DataSource = m_v.f_get_v_dmcapnhat_frmMedisoftcenterupdate().Tables[0];
            }
            catch
            {
            }
        }
        private void f_Chonall()
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                ttProgress.Visible = true;
                ttProgress.Value = 0;
                ttProgress.Maximum = dv.Table.Rows.Count;
                foreach (DataRow r in dv.Table.Rows)
                {
                    r["chon"] = r["chon"].ToString() == "1" ? "0" : "1";
                    ttProgress.Value++;
                    ttProgress.Refresh();
                }
                dataGridView1.Refresh();
            }
            catch
            {
            }
            finally
            {
                ttProgress.Visible = false;
            }
        }
        private void f_Taive()
        {
            string acur = System.Environment.CurrentDirectory;
            try
            {
                string atmp = Application.ExecutablePath;
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp += "\\MedisoftCenterDownload";
                if (!System.IO.Directory.Exists(atmp))
                {
                    System.IO.Directory.CreateDirectory(atmp);
                }
                FolderBrowserDialog adg = new FolderBrowserDialog();
                adg.SelectedPath = atmp;
                adg.Description = 
lan.Change_language_MessageText("Chọn thư mục chứa dữ liệu tải về từ MedisoftCenter!");
                adg.ShowDialog();
                if (adg.SelectedPath != "")
                {
                    MessageBox.Show(this, 
lan.Change_language_MessageText("Tải về xong!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                adg.Dispose();
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acur;
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            timer1.Dispose();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ttProgress.Value=ttProgress.Value+1;
                if (ttProgress.Value == ttProgress.Maximum)
                {
                    timer1.Stop();
                    timer1.Dispose();
                    ttProgress.Visible = false;
                    pStart.Image = pStop.Image;
                    butSave.Enabled = true;
                    butDownload.Enabled = true;
                }
            }
            catch
            {
            }
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            ttProgress.Visible = true;
            ttProgress.Value = 0;
            timer1.Enabled = true;
            ttProgress.Refresh();
            f_Load_Data();
        }


        private void butChonall_Click(object sender, EventArgs e)
        {
            f_Chonall();
        }

        private void butDownload_Click(object sender, EventArgs e)
        {
            f_Taive();
        }

        private void butSave_Click(object sender, EventArgs e)
        {

        }
    }
}