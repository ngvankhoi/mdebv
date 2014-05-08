using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmChondoan : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private string user,sql;
        private DataSet ds = new DataSet();
        public decimal l_doan = 0;
        public int i_loai = 0;
        public string s_mmyy = "",s_ngay="",s_doan="";
        public frmChondoan(AccessData acc)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc;
        }   

        private void frmChondoan_Load(object sender, EventArgs e)
        {
            user = m.user;
            sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngayhd,to_char(a.ngayud,'mmyy') as mmyy from " + user + ".ct_doan a order by a.id desc ";
            ds = m.get_data(sql);
            cmbten.DisplayMember = "ten";
            cmbten.ValueMember = "id";
            cmbten.DataSource = ds.Tables[0];
            ngay.Text = m.ngayhienhanh_server.Substring(0, 10);
        }

        private void tim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim) RefreshChildren(tim.Text);
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void RefreshChildren(string text)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbten.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + text.Trim() + "%' or sohd like '%" + text + "%'";
            }
            catch {}
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (cmbten.SelectedIndex == -1)
            {
                cmbten.Focus();
                return;
            }
            s_ngay = ngay.Text; s_doan = cmbten.Text;
            l_doan = decimal.Parse(cmbten.SelectedValue.ToString());
            s_mmyy = ds.Tables[0].Rows[cmbten.SelectedIndex]["mmyy"].ToString();
            i_loai = int.Parse(ds.Tables[0].Rows[cmbten.SelectedIndex]["loai"].ToString());
            m.close();this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            l_doan = 0; s_mmyy = "";
            m.close();this.Close();
        }

        private void ngay_Validated(object sender, EventArgs e)
        {
            if (ngay.Text == "")
            {
                ngay.Focus();
                return;
            }
            ngay.Text = ngay.Text.Trim();
            if (ngay.Text.Length == 6) ngay.Text = ngay.Text + DateTime.Now.Year.ToString();
            if (ngay.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày")+" ",LibMedi.AccessData.Msg);
                ngay.Focus();
                return;
            }
            if (!m.bNgay(ngay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
                ngay.Focus();
                return;
            }
        }

        private void cmbten_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ngay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}