using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmUpdateDuLieuGoc : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private CreateTableMMYY CrTa;
        private AlterTableMMYY AlTa;
        private AlterTableGoc AltaGoc;
        private AlterTableGoc1 AltaGoc1;
        private int i_userid;
        bool b_taomoi = false;
        public frmUpdateDuLieuGoc(AccessData acc, int userid)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_userid = userid;
        }

        private void mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void frmTaouser_Load(object sender, EventArgs e)
        {
            
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }
        //Thuy
        private void butOk_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            this.progressBar1.Value = 0;
            timer1.Interval = 100;
            timer1.Enabled = true;
            
            //string s_user = m.user;
            //AlTa = new AlterTableMMYY(m);
            //AltaGoc = new AlterTableGoc(m);
            //AlTa.AlterTable_Medibv_Goc();
            //alter table gốc lúc đầu chưa có update --lấy từ Bác lần 1
            //AltaGoc.Alter_TableGoc1(s_user);
            //AltaGoc.Alter_TableGoc2(s_user);
            //AltaGoc.Alter_TableGoc3(s_user);
            //AltaGoc.Alter_TableGoc4(s_user);
            //AltaGoc.Alter_TableGoc5(s_user);
            //AltaGoc.Alter_TableGoc6(s_user);
            //AltaGoc.Alter_TableGoc7(s_user);
            //AltaGoc.Alter_TableGoc8(s_user);
            //AltaGoc.Alter_TableGoc9(s_user);
            //AltaGoc.Alter_TableGoc10(s_user);
            //AltaGoc.Alter_TableGoc11(s_user);
            //AltaGoc.Alter_TableGoc12(s_user);
            //AltaGoc.Alter_TableGoc13(s_user);
            //AltaGoc.Alter_TableGoc14(s_user);
            //AltaGoc.Alter_TableGoc15(s_user);
            //AltaGoc.Alter_TableGoc16(s_user);
            //end alter table gốc lúc đầu chưa có update --lấy từ Bác lần 1
            //Cursor = Cursors.Default;
            //MessageBox.Show(lan.Change_language_MessageText("Xong !"), LibMedi.AccessData.Msg);
        }

        private void frmTaouser_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void f_capnhat_ngayylenh()
        {
            
        }
        private void f_capnhat_datinhchenhlech()
        {
           

        }
        private void f_capnhat_xuatvien_paid()
        {
            string yymmdd=DateTime.Now.Year.ToString().Substring(2,2)+"0101";
            int i_yy=int.Parse(DateTime.Now.Year.ToString());
            int i_mm=int.Parse(DateTime.Now.Month.ToString());
            int i_dd=int.Parse(DateTime.Now.Day.ToString());
            string s_user=m.user, s_mmyy="";
            if(i_mm==1)
            {
                yymmdd=i_yy.ToString().Substring(2,2)+i_mm.ToString().PadLeft(2,'0')+i_dd.ToString().PadLeft(2,'0');
            }

            string asql = " update " + s_user + ".xuatvien set paid=1 where to_char(ngay,'yymmdd')<'" + yymmdd + "' AND PAID=0 ";
            m.execute_data(asql);
            for(int i=1;i<=12;i++)
            {
                s_mmyy=i.ToString().PadLeft(2,'0')+i_yy.ToString().Substring(2,2);
                if (m.bMmyy(s_mmyy))
                {
                    asql = " update " + s_user + ".xuatvien set paid=1 where maql in(select maql from " + s_user + s_mmyy + ".v_ttrvds) and paid=0 ";
                    m.execute_data(asql);
                }
            }
        }

        private void tu_ValueChanged(object sender, EventArgs e)
        {
           
        }
        public bool Taomoi
        {
            set { b_taomoi = value; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value <= 50)
            {
                this.progressBar1.Value++;
                if (this.progressBar1.Value == 50)
                {
                    string s_user = m.user;
                    AltaGoc1 = new AlterTableGoc1(m);
                    AltaGoc1.AlterTable_Medibv_Goc(s_user);//create table goc
                    //update --lấy từ Bác lần 2
                    AltaGoc1.Alter_TableGoc1(s_user);
                    AltaGoc1.Alter_TableGoc2(s_user);
                    AltaGoc1.Alter_TableGoc3(s_user);
                }
            }
            else
            {
                //Cursor = Cursors.Default;
                if(this.progressBar1.Value < 100)
                {
                    this.progressBar1.Value++;
                }
                else if (this.progressBar1.Value == 100)
                {
                    //MessageBox.Show(lan.Change_language_MessageText("Xong !"), LibMedi.AccessData.Msg);
                    this.timer1.Enabled = false;
                    this.timer1.Stop();
                }
                
            }
        }
    }
}