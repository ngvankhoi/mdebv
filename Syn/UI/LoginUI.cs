using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace UI
{
    public partial class LoginUI : UserControl
    {
        public LoginUI()
        {
            InitializeComponent();
        }
        #region events
        public event KeyPressEventHandler e_Pass_keypress;
        public event KeyEventHandler e_Pass_KeyDown;
        #endregion
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e_Pass_KeyDown != null)
            {
                e_Pass_KeyDown(sender, e);
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e_Pass_keypress != null)
            {
                e_Pass_keypress(sender, e);
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.BackColor = Color.PaleGoldenrod;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.BackColor = Color.PaleGoldenrod;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            txtUser.BackColor = Color.WhiteSmoke;
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            txtPass.BackColor = Color.WhiteSmoke;
        }
        /// <summary>
        /// trả về password đã được mã hóa md5
        /// </summary>
        public string Password
        {
            get
            {
                return UI.SecurityPass.getMd5(txtPass.Text);
            }
        }
        /// <summary>
        /// Trả về tên đăng nhập đã được mã hóa.
        /// </summary>
        public string User
        {
            get
            {
                return UI.SecurityPass.getMd5(txtUser.Text);
            }
        }
        /// <summary>
        /// phương thức kiểm tra mật khẩu đăng nhập.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool VerifyPassword(string password)
        {
            return UI.SecurityPass.verifyMd5Hash(txtPass.Text, password);
        }
        /// <summary>
        /// phương thức kiểm tra Tên đăng nhập.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public  bool VerifyUser(string userid)
        {
            return UI.SecurityPass.verifyMd5Hash(txtUser.Text, userid);
        }
    }
}
