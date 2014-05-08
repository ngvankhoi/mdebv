using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Duoc
{
    public partial class frmChonphieucstt : Form
    {
        private LibDuoc.AccessData d;
        private string s_makp, s_makho,sql,user;
        public frmChonphieucstt(LibDuoc.AccessData acc,string _makp,string _makho)
        {
            InitializeComponent();
            d = acc;
            s_makho = _makho;
            s_makp = _makp;
        }
        
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
        public int IDKHOA
        {
            get
            {
                try
                {
                    return int.Parse(cmbKhoa.SelectedValue.ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }
        private void frmChonphieucstt_Load(object sender, EventArgs e)
        {
            user = d.user;
            cmbsophieu.DisplayMember = "sophieu";
            cmbsophieu.ValueMember = "id";
            cmbKho.DisplayMember = "ten";
            cmbKho.ValueMember = "id";
            sql = "select id,ten from " + user + ".d_dmkho ";
            if (s_makho != "") sql += " where id in (" + s_makho.Trim(',') + ")";
            cmbKho.DataSource = d.get_data(sql).Tables[0];
            cmbKhoa.DisplayMember = "ten";
            cmbKhoa.ValueMember = "id";
            sql = "select id,ten from " + user + ".d_duockp ";
            if (s_makp != "") sql += " where id in (" + s_makp + ")";
            cmbKhoa.DataSource = d.get_data(sql).Tables[0];

            ddmmyyyy_Validated(null, null);
        }

        private void ddmmyyyy_Validated(object sender, EventArgs e)
        {
            load_phieu();
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_phieu();
        }
        private void load_phieu()
        {
            try
            {
                cmbsophieu.DataSource = null;
                cmbsophieu.DisplayMember = "sophieu";
                cmbsophieu.ValueMember = "id";
                sql = "select * from " + d.user + ".d_dutrucsttll where done=2 and to_char(ngay,'dd/mm/yyyy')='" + ddmmyyyy.Value.ToString("dd/MM/yyyy") + "'";
                if (cmbKho.SelectedValue.ToString() != "") sql += " and makho="+cmbKho.SelectedValue.ToString();
                if (cmbKhoa.SelectedValue.ToString() != "") sql += " and makp='" + cmbKhoa.SelectedValue.ToString() + "'";
                cmbsophieu.DataSource = d.get_data(sql).Tables[0];
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
            load_phieu();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            bChon = true;
            this.Close();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            bChon = false;
            this.Close();
        }
    }
}