using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;
namespace Duoc
{
    public partial class frmChonChinhanh : Form
    {
        private Language lan = new Language();
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private DataSet dscn;
        public bool bCungchinhanh = true;
        public int i_ChiNhanhXuat = 0, i_ChiNhanhHienTai = 0;
        public frmChonChinhanh()
        {
            InitializeComponent();
        }

        private void chkCungchinhanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (cmbChinhanh.Enabled && cmbChinhanh.SelectedIndex < 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn chi nhánh xuất."));
                cmbChinhanh.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            bCungchinhanh = chkCungchinhanh.Checked;
            i_ChiNhanhXuat = (cmbChinhanh.Enabled) ? int.Parse(cmbChinhanh.SelectedValue.ToString()) : 0;
            this.Close();
        }

        private void f_Loadchinhanh()
        {
            string asql = "select * from medibv.dmchinhanh where id>0 ";
            if (i_ChiNhanhHienTai > 0) asql += " and id<>" + i_ChiNhanhHienTai;
            dscn = d.get_data(asql);
            cmbChinhanh.DataSource = dscn.Tables[0];
            cmbChinhanh.DisplayMember = "TEN";
            cmbChinhanh.ValueMember = "ID";
        }

        private void frmChonChinhanh_Load(object sender, EventArgs e)
        {
            i_ChiNhanhHienTai = d.i_Chinhanh_hientai;
            f_Loadchinhanh();
        }

        private void chkCungchinhanh_CheckedChanged(object sender, EventArgs e)
        {
            chkKhacchinhanh.Checked = !chkCungchinhanh.Checked;
            cmbChinhanh.Enabled = chkKhacchinhanh.Checked;
        }

        private void chkKhacchinhanh_CheckedChanged(object sender, EventArgs e)
        {
            chkCungchinhanh.Checked = !chkKhacchinhanh.Checked;
            cmbChinhanh.Enabled = chkKhacchinhanh.Checked;
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            bCungchinhanh = true;
            i_ChiNhanhXuat = 0;
            this.Close();
        }
    }
}