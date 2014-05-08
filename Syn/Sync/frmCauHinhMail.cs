using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;
using System.Net.Sockets;

namespace Server
{
    public partial class frmCauHinhMail : Form
    {
        DAL.Accessdata m;
        int i_userid = 0;
        DataTable m_dt_mail;
        public frmCauHinhMail()
        {
            InitializeComponent();
            m = new DAL.Accessdata();
        }

        private void butThumau_Click(object sender, EventArgs e)
        {
            frmDmemail f = new frmDmemail(m, i_userid);
            f.ShowDialog();
            f_load_ds_mail();
        }
        private void f_load_ds_mail()
        {
            string sql = "select * from medibv.dmemail order by id";
            m_dt_mail = m.get_data(sql).Tables[0];
            cmbMail.DataSource = m_dt_mail;
        }
        private void butLuucauhinh_Click(object sender, EventArgs e)
        {
            //if(System.IO.Directory.Exists("..//..//..//xml")
            DataSet dttmp = new DataSet();
            dttmp.Tables.Add("cauhinh");
            dttmp.Tables[0].Columns.Add("smtpserver");
            dttmp.Tables[0].Columns.Add("port");
            dttmp.Tables[0].Columns.Add("from");
            dttmp.Tables[0].Columns.Add("password");
            dttmp.Tables[0].Columns.Add("to");
            dttmp.Tables[0].Columns.Add("subject");
            dttmp.Tables[0].Columns.Add("Logo");
            DataRow r = dttmp.Tables[0].NewRow();
            r["smtpserver"] = txtSmtp.Text.Trim();
            r["port"] = txtPort.Text.Trim();
            r["from"] = txtFrom.Text.Trim();
            r["to"] = txtTo.Text.Trim();
            r["subject"] = cmbMail.SelectedValue.ToString();
            r["password"] = txtPass.Text.Trim();
            r["Logo"] = LogList.Text.Trim();
            dttmp.Tables[0].Rows.Add(r);

            dttmp.WriteXml("..//..//..//xml//cauhinhmail.xml");
        }

        private void load_CauhinhMail()
        {
            DataSet lds = new DataSet();
            if (System.IO.File.Exists("..//..//..//xml//cauhinhmail.xml"))
            {
                lds.ReadXml("..//..//..//xml//cauhinhmail.xml");
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    txtSmtp.Text = r["smtpserver"].ToString();
                    txtPort.Text = r["port"].ToString();
                    txtFrom.Text = r["from"].ToString();
                    txtTo.Text = r["to"].ToString();
                }
            }
        }

        private void butTest_Click(object sender, EventArgs e)
        {
            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            LogList.Items.Clear();

            try
            {
                LogList.Items.Add("Lấy thông tin.");
                string server = txtSmtp.Text.Trim();
                string port = txtPort.Text.Trim();
                string username = txtFrom.Text.Trim();
                string password = txtPass.Text.Trim();
                string tomail = txtTo.Text.Trim();
                string subject = txtChude.Text.Trim();
                string message = txtNoidung.Text.Trim();
                //
                if (txtLogo.Text != "") message = txtLogo.Text + "<br/>" + "<br/>" + "<br/>" + message;
                //
                LogList.Items.Add("Bắt đầu gửi.");
                if (sendEmail(server, port, username, password, tomail, subject, message))
                    LogList.Items.Add("Gửi mail thành công!");
                else
                    LogList.Items.Add("Chưa gửi được mail! Vui lòng thử lại sau.");

                // back to normal cursor
                Cursor.Current = cr;

            }
            catch (InvalidOperationException err)
            {
                LogList.Items.Add("Error: " + err.ToString());
            }
        }

        private void cmbMail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow r = m.getrowbyid(m_dt_mail, "id=" + cmbMail.SelectedValue);
                txtChude.Text = r["tieude"].ToString();
                txtNoidung.Text = r["noidung"].ToString();
            }
            catch
            {
                txtChude.Text = "";
                txtNoidung.Text = "";
            }
        }

        private bool sendEmail(string server, string port, string user, string pass, string to, string subject, string body)
        {
            try
            {
                string mMailServer = server;
                int mPort = int.Parse(port);

                NetworkCredential nc = new NetworkCredential(user, pass);

                MailMessage message = new MailMessage(user.Trim(), to.Trim(), subject.Trim(), body.Trim());
                message.Priority = MailPriority.High;
                //True: html document; False: plain text
                message.IsBodyHtml = true;

                SmtpClient mySmtpClient = new SmtpClient(mMailServer, mPort);

                //mySmtpClient.UseDefaultCredentials = true;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Credentials = nc;

                mySmtpClient.Send(message);

                return true;
            }
            catch (FormatException ex)
            {
                return false;
            }
            catch (SmtpException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        private void butKetthuc3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCauHinhMail_Load(object sender, EventArgs e)
        {
            cmbMail.DisplayMember = "TEN";
            cmbMail.ValueMember = "ID";
            f_load_ds_mail();
            load_CauhinhMail();
        }


    }
}