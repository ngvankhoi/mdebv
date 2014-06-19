using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmKhaibaokhoaphongbenhvien : Form
    {
        private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();

        private DataTable dtkhoa = new DataTable();
        private DataTable dt = new DataTable();
        private DataTable dt_K = new DataTable();

        private string s_khoa;
        private int i_id;
        private bool flag;
        public frmKhaibaokhoaphongbenhvien()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v.f_SetEvent(this);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKhaibaokhoaphongbenhvien_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            try
            {
                m_v.execute_data("CREATE TABLE medibv.v_nhomkhoabvll(id numeric(3) NOT NULL DEFAULT 0 PRIMARY KEY,ma varchar(10),ten text,  stt numeric(3) DEFAULT 0,makp text,ngayud timestamp DEFAULT now())");
                m_v.execute_data("CREATE TABLE medibv.v_nhomkhoabvct(id numeric(3) NOT NULL DEFAULT 0,makp varchar(3),tenkp text, PRIMARY KEY (id,makp)) ");
            }
            catch
            {
                m_v.execute_data("CREATE TABLE medibv.v_nhomkhoabvll(id numeric(3) NOT NULL DEFAULT 0,ma varchar(10),ten text,  stt numeric(3) DEFAULT 0,makp text,ngayud timestamp DEFAULT now(), CONSTRAINT pk_v_nhomkhoabvll PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS;");
                m_v.execute_data("CREATE TABLE medibv.v_nhomkhoabvct(id numeric(3) NOT NULL DEFAULT 0,makp varchar(3),tenkp text,CONSTRAINT pk_v_nhomkhoabvct PRIMARY KEY (id,makp) USING INDEX TABLESPACE medi_index) ");
            }
            dtkhoa = m_v.get_data("select makp,tenkp from medibv.btdkp_bv order by makp").Tables[0];
            khoa.DataSource = dtkhoa;
            khoa.DisplayMember = "tenkp";
            khoa.ValueMember = "makp";

            load_grid();
            AddGridTableStyle();
            ref_text();
            dt = m_v.get_data("select makp from medibv.v_nhomkhoabvll order by stt").Tables[0];
            butMoi_Click(null, null);
        }
        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "STT";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã";
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Nội dung";
            TextCol.Width = 280;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "makp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            flag = true;
            try
            {
                txtStt.Value = decimal.Parse(m_v.get_data("select max(stt) from medibv.v_nhomkhoabvll").Tables[0].Rows[0][0].ToString()) + 1;
            }
            catch
            {
                txtStt.Value = 1;
            }
            i_id = 0;
            txtMa.Text = "";
            txtTen.Text = "";
            for (int i = 0; i < khoa.Items.Count; i++) khoa.SetItemCheckState(i, CheckState.Unchecked);
            ena_object(true);
            txtStt.Focus();
        }
        private bool kiemtra()
        {
            if (txtMa.Text == "")
            {
                txtMa.Focus();
                return false;
            }
            if (txtTen.Text == "")
            {
                txtTen.Focus();
                return false;
            }
            s_khoa = "";
            for (int i = 0; i < khoa.Items.Count; i++)
                if (khoa.GetItemChecked(i)) s_khoa += dtkhoa.Rows[i]["makp"].ToString().Trim().PadLeft(2, '0') + ",";
            return true;
        }
        private void ena_object(bool ena)
        {
            dataGrid1.Enabled = !ena;
            khoa.Enabled = ena;
            txtStt.Enabled = ena;
            txtMa.Enabled = ena;
            txtTen.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butXoa.Enabled = !ena;
            butKetthuc.Enabled = !ena;
        }
        private void txtStt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            if (!kiemtra()) return;
            if (i_id == 0)
            {
                try
                {
                    i_id = int.Parse(m_v.get_data("select max(id) from medibv.v_nhomkhoabvll").Tables[0].Rows[0][0].ToString()) + 1;
                }
                catch
                {
                    i_id = 1;
                }
            }            
           
            if (i_id != 0 && txtTen.Text != "")
            {
                DataRow r1 = m_v.getrowbyid(dt, "makp='" + s_khoa + "'");
                {
                    if (r1 != null)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nội dung đã chọn ! "), m_v.s_AppName);
                        return;
                     }
                }
            }
            
            if (!m_v.upd_v_nhomkhoabvll(i_id, txtMa.Text, txtTen.Text, int.Parse(txtStt.Value.ToString()), s_khoa))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin !"), m_v.s_AppName);
                return;
            }
            for (int i = 0; i < khoa.Items.Count; i++)
            {
                if (khoa.GetItemChecked(i))
                {
                    m_v.upd_v_nhomkhoabvct(i_id, dtkhoa.Rows[i]["makp"].ToString().Trim(), dtkhoa.Rows[i]["tenkp"].ToString().Trim());
                }
            }

            load_grid();
            ena_object(false);
            ref_text();
         }
         private void ref_text()
         {
             try
             {
                 int i = dataGrid1.CurrentCell.RowNumber;
                 txtStt.Value = decimal.Parse(dataGrid1[i, 0].ToString());
                 txtMa.Text = dataGrid1[i, 1].ToString();
                 txtTen.Text = dataGrid1[i, 2].ToString();
                 s_khoa = "," + dataGrid1[i, 4].ToString();

                 for (int j = 0; j < dtkhoa.Rows.Count; j++)
                     if (s_khoa.IndexOf("," + dtkhoa.Rows[j]["makp"].ToString().Trim().PadLeft(2, '0') + ",") != -1) khoa.SetItemCheckState(j, CheckState.Checked);
                     else khoa.SetItemCheckState(j, CheckState.Unchecked);
             }
             catch
             {
             }
         }
        private void load_grid()
        {
            //khong co table v_nhomkhoabvll
            dt = m_v.get_data("select * from medibv.v_nhomkhoabvll order by stt").Tables[0];
            dataGrid1.DataSource = dt;
        }

        private void txtMa_Validated(object sender, EventArgs e)
        {
            if (txtMa.Text != "")
            {
                DataRow r1 = m_v.getrowbyid(dt, "ma='" + txtMa.Text + "'");
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã này đã nhập !"), m_v.s_AppName);
                    txtMa.Focus();
                    return;
                }
                if (txtTen.Text == "") txtTen.Text = txtMa.Text;
            }
        }

        private void txtTen_Validated(object sender, EventArgs e)
        {
            if (i_id == 0 && txtTen.Text != "")
            {
                DataRow r1 = m_v.getrowbyid(dt, "ten='" + txtTen.Text + "'");
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nội dung đã nhập !"), m_v.s_AppName);
                    txtTen.Focus();
                }
            }
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            flag = false;
            if (dt.Rows.Count == 0) return;
            i_id = int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString());
            ena_object(true);
            txtStt.Focus();
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy !"), m_v.s_AppName);
                return;
            }
            if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_v.execute_data("delete from medibv.v_nhomkhoabvll where id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString()));
                m_v.execute_data("delete from medibv.v_nhomkhoabvct where id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString()));
                load_grid();
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ref_text();
            ena_object(false);
        }

        private void khoa_Validated(object sender, EventArgs e)
        {
            if (i_id != 0 && txtTen.Text != "")
            {
                DataRow r1 = m_v.getrowbyid(dt, "makp='" + s_khoa + "'");
                {
                    if (r1 != null)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nội dung đã chọn !")+" ", m_v.s_AppName);
                        return;
                     }
                 }
             }
        }
        
    }
}