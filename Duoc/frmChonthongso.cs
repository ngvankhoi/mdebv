using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Duoc
{
    public partial class frmChonthongso : Form
    {
        private LibDuoc.AccessData d;
        public bool bChon = false;
        /// <summary>
        /// trả về ngày được chọn để duyệt
        /// </summary>
        public string Ngay
        {
            get { return ddmmyyyy.Value.ToString("dd/MM/yyyy"); }
        }
        /// <summary>
        /// ID dự trù
        /// </summary>
        public decimal ID
        {
            get
            {
                try
                {
                    return decimal.Parse(cmbsophieu.SelectedValue.ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Số phiếu cần duyệt
        /// </summary>
        public decimal Sophieu
        {
            get
            {
                try
                {
                    return decimal.Parse(cmbsophieu.Text);
                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Trả về id của kho. trong table danh mục kho.
        /// </summary>
        public int IDKHO
        {
            get 
            {
                try
                {
                    return int.Parse(cmbKho.SelectedValue.ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }
        public frmChonthongso(LibDuoc.AccessData acc)
        {
            InitializeComponent();
            d = acc;
        }

        private void ddmmyyyy_Validated(object sender, EventArgs e)
        {
            load_phieu();
            //try
            //{
            //    cmbsophieu.DataSource = d.get_data("select * from " + d.user + ".d_dutrukholl where done=2 and to_char(ngay,'dd/mm/yyyy')='" + ddmmyyyy.Value.ToString("dd/MM/yyyy") + "' and makho="+cmbKho.SelectedValue.ToString()).Tables[0];
            //    cmbsophieu.Enabled = true;
            //    butOk.Enabled = true;
            //}
            //catch
            //{
            //    cmbsophieu.Enabled = false;
            //    butOk.Enabled = false;
            //}
        }

        private void frmChonthongso_Load(object sender, EventArgs e)
        {
            cmbsophieu.DisplayMember = "sophieu";
            cmbsophieu.ValueMember = "id";

            cmbKho.DisplayMember = "ten";
            cmbKho.ValueMember = "id";
            cmbKho.DataSource = d.get_data("select id,ten from "+d.user+".d_dmkho").Tables[0];
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            bChon = true;
            this.Close();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void ddmmyyyy_ValueChanged(object sender, EventArgs e)
        {
            if (ActiveControl == ddmmyyyy)
            {
                load_phieu();
            }
        }

        void load_phieu()
        {
            try
            {
                cmbsophieu.DataSource = d.get_data("select * from " + d.user + ".d_dutrukholl where done=1 and to_char(ngay,'dd/mm/yyyy')='" + ddmmyyyy.Value.ToString("dd/MM/yyyy") + "'").Tables[0];
                cmbsophieu.Enabled = true;
                butOk.Enabled = true;
            }
            catch
            {
                cmbsophieu.Enabled = false;
                butOk.Enabled = false;
            }
        }

        private void cmbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cmbKho)
            {
                load_phieu();
            }
        }
    }
}