using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class ClientUI : UserControl
    {
        private int _somay = 100;
        private long _id = -1;
        DataTable dtmay;
        public ClientUI()
        {
            InitializeComponent();
        }
        #region properties
        /// <summary>
        /// Số máy trạm dùng để đồng bộ data
        /// </summary>
        public int SomayTram
        {
            set { _somay = value; }
        }
        /// <summary>
        /// Trả về thông tin cần thiết để tạo database link
        /// </summary>
        public DAL.Client Client
        {
            get 
            {
                DAL.Client client = new DAL.Client();
                client.Host = txtIP.Text;
                client.Port = txtPort.Text;
                client.Userdb = txtUser.Text;
                client.Passworddb = txtPassword.Text;
                client.DatabaseName = txtDatabase.Text;
                client.DbLink = txttenmay.Text;
                client.ServerName = txttenmay.Text;
                cmbMay_SelectedIndexChanged(null, null);
                client.ID = _id;
                return client;
            }
            set
            {
                txtIP.Text = value.Host;
                txtPort.Text = value.Port;
                txtUser.Text = value.Userdb;
                txtPassword.Text = value.Passworddb;
                txttenmay.Text = value.ServerName;
                txtDatabase.Text = value.DatabaseName;
                cmbMay.SelectedValue = value.ID;
            }
        }
        public long ID
        {
            get 
            {
                return _id;
            }
        }
        public bool Enable
        {
            set
            {
                txtIP.Enabled = value;
                txtUser.Enabled = value;
                txtPort.Enabled = value;
                txtPassword.Enabled = value;
                txtDatabase.Enabled = value;
                txttenmay.Enabled = value;
            }
        }
        public bool Visitable
        {
            set
            {
                cmbMay.Visible = value;
                label7.Visible = value;
            }
        }
        #endregion
        #region Event
        public event EventHandler e_txttenmay;
        public event EventHandler e_cmbMaySelectIndexChange;
        #endregion
        private void txtIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void ClientUI_Load(object sender, EventArgs e)
        {
            //Init();
        }

        public void Init()
        {
            dtmay = new DataTable();
            dtmay.Columns.Add("ten", typeof(string));
            dtmay.Columns.Add("id", typeof(int));
            bool ok = false;
            for (int i = 0; i < _somay; i++)
            {
                DataRow row = dtmay.NewRow();
                row["ten"] = "Máy " + (i + 1).ToString();
                row["id"] = i + 1;
                dtmay.Rows.Add(row);
            }
            cmbMay.DisplayMember = "ten";
            cmbMay.ValueMember = "id";
            cmbMay.DataSource = dtmay;
        }

        private void txtIP_Validated(object sender, EventArgs e)
        {

        }
        public bool Kiemtra()
        {
            if (txtIP.Text.Trim() == "")
            {
                UI.Thongbao.Message("Syn001");
                return false;
            }
            if (txtPort.Text.Trim() == "")
            {
                UI.Thongbao.Message("Syn002");
                return false;
            }
            if (txtUser.Text.Trim() == "")
            {
                UI.Thongbao.Message("Syn003");
                return false;
            }
            if (txtPassword.Text.Trim()=="")
            {
                UI.Thongbao.Message("Syn004");
                return false;
            }
            if (txtDatabase.Text.Trim() == "")
            {
                UI.Thongbao.Message("Syn005");
                return false;
            }
            if (txttenmay.Text.Trim()=="")
            {
                UI.Thongbao.Message("Syn006");
                return false;
            }
            return true;
        }
        public void emptyText()
        {
            txtIP.Clear();
            txtPort.Clear();
            txtUser.Clear();
            txtPassword.Clear();
            txtDatabase.Clear();
            txttenmay.Clear();
        }

        /// <summary>
        /// Phương thức dùng loại bỏ những máy đã được khai báo rồi. dùng cho bên server trung tâm.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveMay(long v_id)
        {
            int j=-1;
            for (int i = 0; i < dtmay.Rows.Count; i++)
            {
                if (v_id == long.Parse(dtmay.Rows[i]["id"].ToString()))
                {
                    j = i;
                    break;
                }
            }
            if (j != -1) dtmay.Rows.RemoveAt(j);
        }
        /// <summary>
        /// Thêm vào 1 tên máy và số thứ tự của máy.
        /// </summary>
        /// <param name="ten"></param>
        /// <param name="id"></param>
        public void AddMay(string ten, long id)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbMay.DataSource];
            DataView dv = (DataView)cm.List;
            DataRow row = dv.Table.NewRow();
            row["id"] = id;
            row["ten"] = ten;
            dv.Table.Rows.Add(row);
        }
        /// <summary>
        /// xóa toàn bộ danh mục máy.
        /// </summary>
        public void RemoveAllMay()
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbMay.DataSource];
            DataView dv = (DataView)cm.List;
            dv.Table.Rows.Clear();
        }
        private void txttenmay_Validated(object sender, EventArgs e)
        {
            if (e_txttenmay != null)
            {
                e_txttenmay(this, e);
            }
        }

        private void cmbMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _id =  long.Parse(cmbMay.SelectedValue.ToString());
            }
            catch
            {
                _id = -1;
            }
            if (e_cmbMaySelectIndexChange != null)
            {
                e_cmbMaySelectIndexChange(this, e);
            }
        }

        private void txttenmay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true; 
        }
      
    }
}