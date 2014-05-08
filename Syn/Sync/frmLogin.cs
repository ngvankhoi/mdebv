using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmLogin : Form
    {

        private DAL.user user = new DAL.user();
        private bool bOK = false;
        public frmLogin()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int AnimateWindow(IntPtr hwand, int dwTime, int dwFlags);  
        private void loginUI1_e_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           string username = UI.SecurityPass.getMd5(user.UserName);
            string passs = UI.SecurityPass.getMd5(user.Password);
            if (username == loginUI1.User)
            {
                if (passs == loginUI1.Password)
                {
                    bOK = true;
                   this.Close();
                }
                else
                {
                    UI.Thongbao.Message("Log001");
                    return;
                }
            }
            else
            {
                UI.Thongbao.Message("Log002");
                return;
            }
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            bOK = false;
            this.Close();
            //Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 300, 20);
        }
        /// <summary>
        /// Đăng nhập thành công.
        /// </summary>
        public bool accept
        {
            get { return bOK; }
        }

        private void loginUI1_e_Pass_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}