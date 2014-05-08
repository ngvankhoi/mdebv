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
    public partial class frmKetxuatloi : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private DataSet m_ds;
        private LibVP.AccessData m_v;
        public frmKetxuatloi(LibVP.AccessData v_v)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
                lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
                m_v = v_v;
            }
            catch
            {
            }
        }
        private void frmKetxuatloi_Load(object sender, EventArgs e)
        {
            f_Load_DG();
        }
        private void f_Load_DG()
        {
            try
            {
                m_ds = m_v.f_get_v_error();
                dataGridView1.DataSource = m_ds.Tables[0];
                lbDG.Text = lan.Change_language_MessageText("Danh sách lỗi hệ thống (") + m_ds.Tables[0].Rows.Count.ToString()+")";
                ttStatus.Text = "";
            }
            catch
            {
                lbDG.Text = lan.Change_language_MessageText("Danh sách lỗi hệ thống");
                ttStatus.Text = "";
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
                string atmp = Application.ExecutablePath;
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp += "\\Errors";
                if (!System.IO.Directory.Exists(atmp))
                {
                    System.IO.Directory.CreateDirectory(atmp);
                }
                SaveFileDialog adg = new SaveFileDialog();
                adg.RestoreDirectory = true;
                adg.Filter = "Microsoft XML Document(*.xml)|*.xml";
                adg.InitialDirectory = atmp;
                adg.FileName = DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Second.ToString().PadLeft(2, '0') + "_VPError.xml";
                if(adg.ShowDialog() == DialogResult.OK)
                {
                    if (adg.FileName != "")
                    {
                        m_ds.WriteXml(adg.FileName,XmlWriteMode.WriteSchema);
                    }
                }
                adg.Dispose();
            }
            catch
            {
            }
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, 
lan.Change_language_MessageText("Đồng ý xoá thông tin lỗi hệ thống!"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    m_v.del_v_error();
                    f_Load_DG();
                }
            }
            catch
            {
            }
        }
    }
}