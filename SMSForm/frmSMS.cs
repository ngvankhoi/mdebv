using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMSForm
{
    
    public partial class frmSMS : Form
    {
        LibMedi.AccessData dao = new LibMedi.AccessData();
        public string mabn = "",sql="",user,ngayvv;
        public decimal maql;
        public frmSMS()
        {
            InitializeComponent();
            
        }
        public frmSMS(string _mabn,decimal _maql,string _ngayvv)
        {
            InitializeComponent();
            mabn = _mabn;
            maql = _maql;
            ngayvv = _ngayvv;


        }
        public frmSMS(string sender, string receiver, string message)
        {
            InitializeComponent();

           // txtSender.Text = sender;
            txtReceiver.Text = receiver;
            txtMessage.Text = message;
        }

       
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtReceiver.Text == "" || txtReceiver.Text == "0000000000")
            {
                MessageBox.Show("Nhập số điện thoại cần gửi", "Medisoft");
                txtReceiver.Focus();
            }
            else
            {
                string error = "";
                foreach(string s in txtReceiver.Text.Split(';'))
                {
                    if (s != "")
                    {
                        string sqlQuery = "INSERT INTO " + dao.user + ".ozekimessageout(sender,receiver,msg,status) values('','" + s + "','" + dao.khongdau(txtMessage.Text.Replace("'", "''")) + "','send');";
                        bool result = dao.execute_data(sqlQuery);
                        if (!result)
                        {
                            error += s+ ";";
                        }
                    }
                }
                if (error != "")
                {
                    MessageBox.Show("Các số điện thoại không gửi được", "Medisoft");
                }
                else
                {
                    MessageBox.Show("Đã gửi tin nhắn","Medisoft");
                }
                //if (result)
                //{
                //    txtReceiver.Text = "";
                //    txtMessage.Text = "";
                //    MessageBox.Show("Tin nhắn đã được lưu vào hàng đợi gửi tin.");
                //}
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSMS_Load(object sender, EventArgs e)
        {
            user = dao.user;
            sql = "select a.mabn,a.hoten,a.namsinh,b.chandoan,d.chandoan as kemtheo,c.mabv,e.tenbv,f.didong ";
            sql += "from " + user + ".btdbn a ";
            sql += "left join xxx.benhanpk b on a.mabn=b.mabn ";
            sql +="left join xxx.bhyt c on a.mabn=c.mabn ";
            sql += "left join " + user + ".dmnoicapbhyt e on c.mabv=e.mabv ";
            sql += "left join xxx.cdkemtheo d on b.maql=d.maql ";
            sql += "left join " + user + ".dienthoai f on a.mabn=f.mabn";
            sql +=" where a.mabn='" + mabn + "'";

            DataTable dt = dao.get_data_mmyy(sql,ngayvv,ngayvv,true).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtMessage.Text  = "Mã BN: " + dt.Rows[i]["mabn"].ToString() + Environment.NewLine;
                txtMessage.Text += "Họ tên: " + dt.Rows[i]["hoten"].ToString() + Environment.NewLine;
                txtMessage.Text += "Nơi ĐKKCB: " + dt.Rows[i]["tenbv"].ToString() + Environment.NewLine;
                txtMessage.Text += "Chẩn đoán: " + dt.Rows[i]["chandoan"].ToString().Trim(',') + Environment.NewLine;
                txtReceiver.Text = dt.Rows[i]["didong"].ToString() !="" ? dt.Rows[i]["didong"].ToString().PadLeft(10, '0'):"";
                if (dt.Rows[i]["kemtheo"].ToString() != "")
                {
                    txtMessage.Text += "Kèm theo: ";
                    string s_kt = "";
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        s_kt +=dt.Rows[j]["kemtheo"].ToString().Trim(',')+",";

                    }
                    txtMessage.Text+=s_kt.Trim(',');
                }                
            }
        }
    }
}