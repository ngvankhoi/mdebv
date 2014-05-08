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
    public partial class frmSolien : Form 
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private DataSet m_ds;
        private LibVP.AccessData m_v;
        private string m_userid = "";
        public frmSolien(LibVP.AccessData v_v,string v_userid)
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
        private void frmSolien_Load(object sender, EventArgs e)
        {
            f_Load_Data();
        }
        private void f_Load_Data()
        {
            try
            {
                m_ds = m_v.get_data("select stt, ten, tenreport from medibv.v_optionlien order by tenreport, stt");
                if (m_ds == null)
                {
                    m_v.f_create_v_optionlien();
                    m_v.f_Macdinh_Solien();
                    m_ds = m_v.get_data("select stt, ten, tenreport from medibv.v_optionlien order by tenreport, stt");
                }
                dataGridView1.DataSource = m_ds.Tables[0];
                dataGridView1.Update();
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
                m_v.execute_data("delete from medibv.v_optionlien");
                decimal astt = 0;
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
                    m_v.upd_v_optionlien(astt, r["ten"].ToString().Trim(), r["tenreport"].ToString().Trim().ToLower());
                    ttProgress.Value = ttProgress.Value + 1;
                    statusStrip1.Refresh();
                }
            }
            catch
            {
            }
            finally
            {
                f_Load_Data();
                butSave.Enabled = true;
                butClose.Enabled = true;
                ttProgress.Visible = false;
                ttStatus.Text = "";
            }
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_Data();
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

        private void tmn_Tructiep_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                f_Load_Data();
            }
            catch
            {
            }
        }

        private void butMacdinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý lấy lại số liên mặc định?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    m_v.f_Macdinh_Solien();
                    f_Load_Data();
                }
            }
            catch
            {
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_Load_Data();
        }

        private void tmn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                m_ds.Tables[0].Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
            catch
            {
            }
        }
    }
}