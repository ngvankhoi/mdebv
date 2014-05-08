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
    public partial class frmViettat : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private DataSet m_ds;
        private LibVP.AccessData m_v;
        private string m_userid = "";
        public frmViettat(LibVP.AccessData v_v,string v_userid)
        {
            try
            {
                InitializeComponent();


                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
                lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");

                m_v = v_v;
                m_userid = v_userid;
            }
            catch
            {
            }
        }
        private void frmViettat_Load(object sender, EventArgs e)
        {
            f_Load_Viettat();
        }
        private void f_Load_Viettat()
        {
            try
            {
                m_ds = m_v.f_get_v_viettat();
                dataGridView1.DataSource = m_ds.Tables[0];
            }
            catch
            {
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                m_ds.AcceptChanges();
                butSave.Enabled = false;
                butClose.Enabled = false;
                ttProgress.Visible = true;
                ttProgress.Minimum = 0;
                ttProgress.Value = 0;
                ttProgress.Maximum = m_ds.Tables[0].Rows.Count;
                ttStatus.Text = lan.Change_language_MessageText("Đang lưu ...");
                this.Refresh();
                m_v.del_v_viettat();
                decimal astt = 0, areadonly = 0;
                foreach (DataRow r in m_ds.Tables[0].Rows)
                {
                    try
                    {
                        astt = decimal.Parse(r["stt"].ToString());
                    }
                    catch
                    {
                        astt = 1;
                    }
                    try
                    {
                        areadonly = decimal.Parse(r["readonly"].ToString());
                    }
                    catch
                    {
                        areadonly = 0;
                    }
                    try
                    {
                        if (r["ma"].ToString().Trim() != "" && r["ten"].ToString().Trim() != "")
                        {
                            m_v.upd_v_viettat(astt, r["ma"].ToString(), r["ten"].ToString(), areadonly);
                        }
                    }
                    catch
                    {
                    }
                    ttProgress.Value = ttProgress.Value + 1;
                    statusStrip1.Refresh();
                }
            }
            catch
            {
            }
            finally
            {
                f_Load_Viettat();
                butSave.Enabled = true;
                butClose.Enabled = true;
                ttProgress.Visible = false;
                ttStatus.Text = "";
            }
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_Viettat();
        }

        private void butMedisoftcenter_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedisoftcenterupdate af = new frmMedisoftcenterupdate(m_v, m_userid, "DMVT");
                af.TopMost = true;
                af.ShowDialog();
            }
            catch
            {
            }
        }
        private void butLocal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog afo = new OpenFileDialog();
                afo.RestoreDirectory = true;
                afo.Filter = "Microsoft XML Document (*.XML)|*.xml";
                afo.Title = lan.Change_language_MessageText("Chọn file dữ liệu đã download từ Medisoft Center Update");
                afo.ShowDialog();
                if (afo.FileName != "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Cập nhật thành công!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
    }
}