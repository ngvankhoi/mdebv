using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LibDuoc;
namespace testc
{
    public partial class Form1 : Form
    {
        private string s_user="";
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private DataTable dthc;
        private DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.MDB|*.*";
            of.ShowDialog();
            thumuc.Text = of.FileName.ToString();
            System.Environment.CurrentDirectory = sDir;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (thumuc.Text == "")
            {
                button1_Click(null, null);
                return;
            }
            if (!System.IO.File.Exists(thumuc.Text))
            {
                MessageBox.Show("Không tìm thấy File !");
                return;
            }
            string sql = "";
            sql = " create table " + s_user + ".d_group (id numeric(7), generic1 varchar(255),generic2 varchar(255), group1 varchar(255), group2 varchar(255), severity numeric(3), mechanism text,actions text, s_effect text, mec_detail text)";
            d.execute_data(sql);
            //
            dthc = d.get_data("select * from " + s_user + ".d_group ").Tables[0];
            sql = "select * from group1 order by generic1";
            string s_name = "", s_generic = "", s_group = "", s_exp = "", s_id = "0", s_severity="0";
            string s_ploai = "";
            int i_loai = 0, i_stt = 0, i_id = 0,  i_nhom = 1;//Khoa duoc
            long l_id = 0;
            ds = m.get_data_acc(sql, thumuc.Text);
            int jjj = 0;

            foreach (DataRow r in ds.Tables[0].Rows)
            {

                s_exp = "generic1='" + r["generic1"].ToString().Trim().Replace("'", "") + "' and generic2='" + r["generic2"].ToString().Trim().Replace("'", "") + "'";
                DataRow dr = d.getrowbyid(dthc, s_exp);
                if (dr == null)
                {
                    s_group = r["group1"].ToString().Trim().Replace("'", "");
                    s_generic = r["generic1"].ToString().Trim().Replace("'", "");
                    s_id = (r["id"].ToString().Trim() == "") ? "0" : r["id"].ToString().Trim();
                    s_severity = (r["severity"].ToString().Trim() == "") ? "0" : r["severity"].ToString().Trim();
                    sql = "insert into " + s_user + ".d_group (id, generic1, generic2, group1, group2, severity, mechanism, actions, s_effect, mec_detail) ";
                    sql += " values(" + s_id + ",'" + s_generic + "','" + r["generic2"].ToString().Trim().Replace("'", "") + "','" + s_group + "','" + r["group2"].ToString().Trim().Replace("'", "") + "'," + s_severity + ",'" + r["mechanism"].ToString().Trim().Replace("'", "") + "','" + r["actions"].ToString().Trim().Replace("'", "") + "','" + r["s_effect"].ToString().Trim().Replace("'", "") + "','" + r["mec_detail"].ToString().Trim().Replace("'", "") + "')";
                    d.execute_data(sql);
                }
                jjj += 1;
                label1.Text = "Record " + jjj.ToString();
                this.Refresh();
            }
            thumuc.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s_user = d.user;
        }
    }
}