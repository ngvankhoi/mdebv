using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dllvpkhoa_chidinh
{
    public partial class frmMain : Form
    {
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private int i_userid = 1, i_khudt = 0;
        private string s_makp = "", s_userid = "";
        private bool b_admin = true;
        Language lan = new Language(); 
        public frmMain()
        {
            InitializeComponent();
        }

        private void menuItem42_Click(object sender, EventArgs e)
        {
            frmDMICD10 f = new frmDMICD10(m, "icd10", "", "", false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem43_Click(object sender, EventArgs e)
        {
            
        }

        private void menuItem44_Click(object sender, EventArgs e)
        {
            
        }

        private void menuItem47_Click(object sender, EventArgs e)
        {
        }

        private void menuItem48_Click(object sender, EventArgs e)
        {
           
        }

        private void menuItem49_Click(object sender, System.EventArgs e)
        {
                  
        }

        private void menuItem45_Click(object sender, EventArgs e)
        {
        }

        private void menuItem53_Click(object sender, EventArgs e)
        { }

        private void m310_Click(object sender, EventArgs e)
        { }

        private void menuItem164_Click(object sender, EventArgs e)
        {
            
        }

        private void menuItem26_Click(object sender, EventArgs e)
        {
        }

        private void menuItem102_Click(object sender, EventArgs e)
        {
        }

        private void menuItem62_Click(object sender, EventArgs e)
        {
        }

        private void menuItem82_Click(object sender, EventArgs e)
        {
        }

        private void menuItem64_Click(object sender, EventArgs e)
        {
        }

        private void menuItem66_Click(object sender, EventArgs e)
        {
        }

        private void menuItem68_Click(object sender, EventArgs e)
        {
        }

        private void menuItem89_Click(object sender, EventArgs e)
        {
        }

        private void menuItem98_Click(object sender, EventArgs e)
        {
        }

        private void menuItem217_Click(object sender, EventArgs e)
        {
        }

        private void menuItem243_Click(object sender, EventArgs e)
        {
        }

        private void menuItem65_Click(object sender, EventArgs e)
        {
        }

        private void menuItem22_Click(object sender, EventArgs e)
        {
        }

        private void menuItem168_Click(object sender, EventArgs e)
        {
        }

        private void menuItem219_Click(object sender, EventArgs e)
        {
        }

        private void menuItem220_Click(object sender, EventArgs e)
        {
        }

        private void menuItem242_Click(object sender, EventArgs e)
        {
        }

        private void menuItem266_Click(object sender, EventArgs e)
        {
        }

        private void menuItem171_Click(object sender, EventArgs e)
        {
        }

        private void menuItem284_Click(object sender, EventArgs e)
        {
        }

        private void menuItem339_Click(object sender, EventArgs e)
        { }

        private void menuItem363_Click(object sender, EventArgs e)
        {
        }

        private void menuItem362_Click(object sender, EventArgs e)
        {
        }

        private void menuItem361_Click(object sender, EventArgs e)
        {
        }

        private void menuItem63_Click(object sender, EventArgs e)
        {
        }

        private void menuItem100_Click(object sender, EventArgs e)
        {
            m.writeXml("d_netsend", "ma", "");
            m.writeXml("d_netsend", "ten", "");
            NetSend f = new NetSend();
            f.ShowDialog(this);
        }

        private void menuItem101_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Directory.GetCurrentDirectory().ToUpper();
                int pos = path.LastIndexOf("//MEDISOFT");
                if (pos != 0) path = path.Substring(0, pos) + "//Setup";
                string arg = " /qn /i \"" + path + "//zip.msi\"";
                backup e1 = new backup(@"msiexec", arg, false);
                e1.Launch();
                arg = "/qn /i \"" + path + "//Microsoft OLE DB Provider for Visual FoxPro.msi\"";
                backup e2 = new backup(@"msiexec", arg, false);
                e2.Launch();
                m.upd_thongso(101, "1", "1", "1");
            }
            catch { }
        }

        private void menuItem253_Click(object sender, EventArgs e)
        {
            string file = @"wordpad.exe";
            string fileToOpen = @m.Path_thongbao;//"..//..//..//doc//thongbao.rtf"
            backup f = new backup(file, fileToOpen, true);
            f.Launch();
        }

        private void menuItem277_Click(object sender, EventArgs e)
        {   
        }

        private void m312_Click(object sender, EventArgs e)
        {
        }

        private void m313_Click(object sender, EventArgs e)
        {
        }

        private void m314_Click(object sender, EventArgs e)
        {
        }

        private void m318_Click(object sender, EventArgs e)
        {
        }

        private void m319_Click(object sender, EventArgs e)
        {

        }

        private void m326_Click(object sender, EventArgs e)
        {
        }

        private void m333_Click(object sender, EventArgs e)
        {
        }

        private void m346_Click(object sender, EventArgs e)
        {
        }

        private void m347_Click(object sender, EventArgs e)
        {
        }

        private void menuItem338_Click(object sender, EventArgs e)
        {

        }

        private void m306_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem273_Click(object sender, EventArgs e)
        {
            frmChonthongsovp f = new frmChonthongsovp(m, s_makp,i_khudt);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                LibVienphi.AccessData v = new LibVienphi.AccessData();
                frmChidinh_n f1 = new frmChidinh_n(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, m.user + ".nhapkhoa", v.iNoitru, 1, b_admin, false);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem222_Click(object sender, EventArgs e)
        {
            frmChonthongsovp f = new frmChonthongsovp(m, s_makp, i_khudt);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmVpkhoa f1 = new frmVpkhoa(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, f.i_buoi);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem274_Click(object sender, EventArgs e)
        {
            frmChonkham f = new frmChonkham(m, s_makp, i_userid, 1);
            f.ShowDialog();
            if (f.s_makp != "")
            {
                frmChidinh_k f1 = new frmChidinh_k(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m353_Click(object sender, EventArgs e)
        {
            frmChonthongsotu f = new frmChonthongsotu(m, s_makp, i_userid, 0, i_khudt);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmTamung f1 = new frmTamung(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, 0, 0, b_admin);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem192_Click(object sender, EventArgs e)
        {

        }

        private void menuItem191_Click(object sender, EventArgs e)
        {

        }

        private void menuItem173_Click(object sender, EventArgs e)
        {

        }

        private void menuItem28_Click(object sender, EventArgs e)
        {

        }
    }
}