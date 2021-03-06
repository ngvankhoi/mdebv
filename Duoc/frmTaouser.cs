using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Duoc
{
    public partial class frmTaouser : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m=new AccessData();
        private int i_userid;
        public frmTaouser(int userid)
        {
            InitializeComponent();
            i_userid = userid;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void frmTaouser_Load(object sender, EventArgs e)
        {
            yyyy.Maximum = DateTime.Now.Year + 1;
            yyyy.Minimum = DateTime.Now.Year - 1;
            tu.Value = DateTime.Now.Month;
            den.Value = tu.Value;
            yyyy.Value = DateTime.Now.Year;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string mmyy = "", s = "";
            for (int i = Convert.ToInt16(tu.Value); i <= Convert.ToInt16(den.Value); i++)
            {
                mmyy = i.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                if (m.bMmyy(mmyy))
                {
                    if (chkOnlyFunction.Checked)
                    {
                        m.tao_function(mmyy);
                    }
                    else
                    {
                        lblmmyy.Text = mmyy;
                        lblmmyy.Refresh();
                        //m.modify_schema(mmyy, i_userid);
                        //if (txtfile.Visible == false)
                        m.modify_schema(mmyy, i_userid);
                        m.Tao_Table(mmyy);
                        //
                        m.modify_schema_mmyy_sql_new(mmyy);
                        //else
                        //    m.modify_schema(mmyy, i_userid, txtfile.Text);
                    }
                }
                else s += mmyy.Substring(0, 2) + "/20" + mmyy.Substring(2, 2) + ";";                
            }
            //
            f_capnhat_ngayylenh();
            //Thuy 02.06.2012
            m.modify_schema();
            //end 02.06.2012
            Cursor = Cursors.Default;
            if (s != "") MessageBox.Show(lan.Change_language_MessageText("Những tháng sau chưa tạo số liệu :")+"\n" + s,LibMedi.AccessData.Msg);
            else MessageBox.Show(lan.Change_language_MessageText("Xong !"), LibMedi.AccessData.Msg);
        }

        private void frmTaouser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Alt && e.Shift && e.Control)
                txtfile.Visible = !txtfile.Visible;
        }

        private void f_capnhat_ngayylenh()
        {
            string asql = " update xxx.d_xuatsdct a set ngayylenh=(select ngayylenh from xxx.d_xuatsdll b where a.id=b.id) where ngayylenh is null and id in(select id from xxx.d_xuatsdll)";
            string mmyy = "", s = "";
            for (int i = Convert.ToInt16(tu.Value); i <= Convert.ToInt16(den.Value); i++)
            {
                mmyy = i.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                if (m.bMmyy(mmyy))
                {
                    string tmp_sql = asql.Replace("xxx.", m.user + mmyy + ".");
                    m.execute_data(tmp_sql);
                }
                else s += mmyy.Substring(0, 2) + "/20" + mmyy.Substring(2, 2) + ";";
            }
        }
    }
}