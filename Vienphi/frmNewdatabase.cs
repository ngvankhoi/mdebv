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
    public partial class frmNewdatabase : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private LibVP.AccessData m_v;
        private string m_userid = "";
        public frmNewdatabase(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_userid = v_userid;
            m_v = v_v;
        }

        private void frmNewdatabase_Load(object sender, EventArgs e)
        {
            ttStatus.Text = "";
        }

        private void butDongy_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                butDongy.Enabled = false;
                butClose.Enabled = false;
                this.ControlBox = false;
                if (chkVienphi.Checked)
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý tạo số liệu tháng ") + txtMMYY.Text, m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        ttStatus.Text = lan.Change_language_MessageText("Đang thực hiện, xin chờ...");
                        this.Update();
                        m_v.create_schema_vp(txtMMYY.Text.Substring(0, 2) + txtMMYY.Text.Substring(5, 2));
                        m_v.modify_tables_vp();
                        m_v.create_tables_vp();
                        m_v.create_tables_vp_mmyy(txtMMYY.Text.Substring(0, 2) + txtMMYY.Text.Substring(5, 2));
                        MessageBox.Show(this, lan.Change_language_MessageText("Đã tạo thành công!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, lan.Change_language_MessageText("Tạo không thành công!")+"\n"+ lan.Change_language_MessageText("Lỗi:")+" " + ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                ttStatus.Text = lan.Change_language_MessageText("Thực hiện xong!");
                this.Cursor = Cursors.Default;
                butDongy.Enabled = true;
                butClose.Enabled = true;
                this.ControlBox = true;
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}