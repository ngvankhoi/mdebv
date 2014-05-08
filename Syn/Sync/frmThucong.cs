using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmThucong : Form
    {
        DataTable dtChinhanh = null;
        public frmThucong()
        {
            InitializeComponent();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThucong_Load(object sender, EventArgs e)
        {
            dgrChinhanh.AutoGenerateColumns = false;
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {
                dtChinhanh = acc.get_data("select false as chon,false as server,a.* from medibv.dmchinhanh a").Tables[0];
                dgrChinhanh.DataSource = dtChinhanh;
            }
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            using (DAL.Accessdata acc = new DAL.Accessdata())
            {
                foreach (DataRow r in dtChinhanh.Select("chon=True"))
                {
                    DAL.Client client = new DAL.Client(r["ip"].ToString(), r["port"].ToString(), r["database_local"].ToString(), "medisoft", "links1920", r["database_local"].ToString());
                    client.ID = int.Parse(r["id"].ToString());
                    lblstatuss.Text = "btdbn";
                    acc.update(client, "medibv", "btdbn", txtText, lblstatuss, proStatus, "to_number(to_char(ngayud,'yymmdd'))", txtTungay.Text, txtDenngay.Text, txtMabn.Text);
                    //acc.update(client, "medibv", "btdbn", txtText, lblstatuss, proStatus);
                    statusServer.Text = "";
                    lblstatuss.Text = "";
                    DateTime tn = txtTungay.Value;
                    DateTime dn = txtDenngay.Value;
                    for (int j = tn.Year; j <= dn.Year; j++)
                    {
                        for (int i = tn.Month; i <= dn.Month; i++)
                        {
                            string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                            string schema = acc.User + mmyy;
                            if (acc.bShemaValid(schema))
                            {
                                lblstatuss.Text = schema + ".lienhe";
                                Application.DoEvents();
                                acc.update(client, schema, "lienhe", txtText, lblstatuss, proStatus, "maql", txtTungay.Text, txtDenngay.Text, txtMabn.Text);
                                lblstatuss.Text = schema + ".tiepdon";
                                Application.DoEvents();
                                acc.update(client, schema, "tiepdon", txtText, lblstatuss, proStatus, "maql", txtTungay.Text, txtDenngay.Text, txtMabn.Text);
                                lblstatuss.Text = schema + ".bhyt";
                                //Application.DoEvents();
                                //acc.update(client, schema, "bhyt", txtText, lblstatuss, proStatus, "maql", txtTungay.Text, txtDenngay.Text, txtMabn.Text);
                                //lblstatuss.Text = schema + ".lydokham";
                                Application.DoEvents();
                                acc.update(client, schema, "lydokham", txtText, lblstatuss, proStatus, "maql", txtTungay.Text, txtDenngay.Text, txtMabn.Text);
                                lblstatuss.Text = schema + ".trieuchung";
                                Application.DoEvents();
                                acc.update(client, schema, "trieuchung", txtText, lblstatuss, proStatus, "maql", txtTungay.Text, txtDenngay.Text, txtMabn.Text);
                                lblstatuss.Text = schema + ".v_chidinh";
                                Application.DoEvents();
                                acc.update(client, schema, "v_chidinh", txtText, lblstatuss, proStatus, "maql", txtTungay.Text, txtDenngay.Text, txtMabn.Text);
                                //lblstatuss.Text = schema + ".xn_phieu";
                                //Application.DoEvents();
                                //acc.update(client, schema, "xn_phieu", txtText, lblstatuss, proStatus, "id", txtTungay.Text, txtDenngay.Text);
                                //lblstatuss.Text = schema + ".xn_ketqua";
                                //Application.DoEvents();
                                //acc.update(client, schema, "xn_ketqua", txtText, lblstatuss, proStatus, "id", txtTungay.Text, txtDenngay.Text);
                                //lblstatuss.Text = "";
                            }
                        }
                    }
                }
                foreach (DataRow r in dtChinhanh.Select("server=True"))
                {
                    DAL.Client client = new DAL.Client(r["ip"].ToString(), r["port"].ToString(), r["database_local"].ToString(), "medisoft", "links1920", r["database_local"].ToString());
                    client.ID = int.Parse(r["id"].ToString());
                    lblstatuss.Text = "btdbn";
                    //acc.update(client, "medibv", "btdbn", txtText, lblstatuss, proStatus, "to_number(to_char(ngayud,'yymmdd'))", txtTungay.Text, txtDenngay.Text);
                    //acc.update(client, "medibv", "btdbn", txtText, lblstatuss, proStatus);
                    statusServer.Text = "";
                    lblstatuss.Text = "";
                    string s_id = "", tmp = "";
                    DateTime tn = txtTungay.Value;
                    DateTime dn = txtDenngay.Value;
                    for (int j = tn.Year; j <= dn.Year; j++)
                    {
                        for (int i = tn.Month; i <= dn.Month; i++)
                        {
                            string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                            string schema = acc.User + mmyy;
                            if (acc.bShemaValid(schema))
                            {
                                lblstatuss.Text = schema + ".xn_phieu";
                                Application.DoEvents();
                                acc.update(client, schema, "xn_phieu", txtText, lblstatuss, proStatus, "id", txtTungay.Text, txtDenngay.Text,ref s_id,"");
                                if (s_id.Trim(',') == "") return;
                                lblstatuss.Text = schema + ".xn_ketqua";
                                Application.DoEvents();
                                acc.update(client, schema, "xn_ketqua", txtText, lblstatuss, proStatus, "id", txtTungay.Text, txtDenngay.Text,ref tmp, s_id);
                                lblstatuss.Text = "";
                            }
                        }
                    }
                }
                lblstatuss.Text = "Finish.";
                this.Cursor = Cursors.Default;
            }
        }
    }
}