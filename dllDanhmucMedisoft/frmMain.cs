using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dllDanhmucMedisoft
{
    public partial class frmMain : Form
    {
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private int i_userid = 1;
        private string s_makp = "", s_userid = "";
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
            frmDmpttt f = new frmDmpttt(m, "", "", false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem44_Click(object sender, EventArgs e)
        {
            frmTenvien f = new frmTenvien(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem47_Click(object sender, EventArgs e)
        {
            frmBtdtt f = new frmBtdtt(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem48_Click(object sender, EventArgs e)
        {
            frmBtdquan f = new frmBtdquan(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem49_Click(object sender, System.EventArgs e)
        {
            frmBtdpxa f = new frmBtdpxa(m, i_userid);
            f.MdiParent = this;
            f.Show();        
        }

        private void menuItem45_Click(object sender, EventArgs e)
        {
            frmDm f = new frmDm(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem53_Click(object sender, EventArgs e)
        {
            frmMaubc f = new frmMaubc(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m310_Click(object sender, EventArgs e)
        {
            frmIcd10 f = new frmIcd10(m, "icd10", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem164_Click(object sender, EventArgs e)
        {
            frmKbpttt f = new frmKbpttt(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem26_Click(object sender, EventArgs e)
        {
            frmDstt f = new frmDstt(m, "dstt", lan.Change_language_MessageText("Cơ quan y tế chuyển đến"), i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem102_Click(object sender, EventArgs e)
        {
            frmDstt f = new frmDstt(m, "dmnoicapbhyt", lan.Change_language_MessageText("Danh mục đăng ký khám chữa bệnh"), i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem62_Click(object sender, EventArgs e)
        {
            frmBtdkp f = new frmBtdkp(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem82_Click(object sender, EventArgs e)
        {
            frmBtdpk f = new frmBtdpk(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem64_Click(object sender, EventArgs e)
        {
            frmBtdvt f = new frmBtdvt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem66_Click(object sender, EventArgs e)
        {
            frmDmmete f = new frmDmmete(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem68_Click(object sender, EventArgs e)
        {
            frmDmnhommau f = new frmDmnhommau(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem89_Click(object sender, EventArgs e)
        {
            frmBtdnn f = new frmBtdnn(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem98_Click(object sender, EventArgs e)
        {
            frmDmbenhan f = new frmDmbenhan(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem217_Click(object sender, EventArgs e)
        {

            frmXutrikb f = new frmXutrikb(m,s_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem243_Click(object sender, EventArgs e)
        {
            frmDoituong f = new frmDoituong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem65_Click(object sender, EventArgs e)
        {
            frmDmbs f = new frmDmbs(m, s_userid, i_userid, 0);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem22_Click(object sender, EventArgs e)
        {
            frmCoso f = new frmCoso(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem168_Click(object sender, EventArgs e)
        {
            frmSxkd f = new frmSxkd(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem219_Click(object sender, EventArgs e)
        {
            frmDmthuoc f = new frmDmthuoc(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem220_Click(object sender, EventArgs e)
        {
            frmDmcachdung f = new frmDmcachdung(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem242_Click(object sender, EventArgs e)
        {
            frmKygiayrv f = new frmKygiayrv(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem266_Click(object sender, EventArgs e)
        {
            frmBtdpmo f = new frmBtdpmo(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem171_Click(object sender, EventArgs e)
        {
            frmDonthuoc_bacsy f = new frmDonthuoc_bacsy(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem284_Click(object sender, EventArgs e)
        {
            frmDanhmuc f = new frmDanhmuc(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem339_Click(object sender, EventArgs e)
        {
            frmDmbhyt f = new frmDmbhyt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem363_Click(object sender, EventArgs e)
        {
            frmDmloaiphong f = new frmDmloaiphong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem362_Click(object sender, EventArgs e)
        {
            frmDmphong f = new frmDmphong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem361_Click(object sender, EventArgs e)
        {
            frmDmgiuong f = new frmDmgiuong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem63_Click(object sender, EventArgs e)
        {
            frmError f = new frmError(m);
            f.MdiParent = this;
            f.Show();
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
            frmICD10_Ora f = new frmICD10_Ora(m);
            f.MdiParent = this;
            f.Show();
        }

        private void m312_Click(object sender, EventArgs e)
        {
            frmLoaitrieuchung f = new frmLoaitrieuchung(i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m313_Click(object sender, EventArgs e)
        {
            frmTrieuchung f = new frmTrieuchung(i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m314_Click(object sender, EventArgs e)
        {
            frmNhomnv f = new frmNhomnv(m);
            f.MdiParent = this;
            f.Show();
        }

        private void m318_Click(object sender, EventArgs e)
        {
            frmKskdoan f = new frmKskdoan(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m319_Click(object sender, EventArgs e)
        {

            frmLoaikham f = new frmLoaikham(m, "m_loaikhamsk", "Giá trị mặc nhiên khám sức khỏe", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m326_Click(object sender, EventArgs e)
        {
            frmDmtheodoi f = new frmDmtheodoi(m);
            f.MdiParent = this;
            f.Show();
        }

        private void m333_Click(object sender, EventArgs e)
        {

            frmDmthe f = new frmDmthe(m);
            f.MdiParent = this;
            f.Show();
        }

        private void m346_Click(object sender, EventArgs e)
        {
            frmDmhuyet f = new frmDmhuyet(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m347_Click(object sender, EventArgs e)
        {
            frmBsnghi f = new frmBsnghi(m, i_userid);
            f.MdiParent = this;
            f.Show();
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

        private void menuItem28_Click(object sender, EventArgs e)
        {
            frmdmloaithebhyt_chinhsach f = new frmdmloaithebhyt_chinhsach();
            f.MdiParent = this;
            f.Show();
        }
        
        private void menuItem61_Click(object sender, EventArgs e)
        {
            
        }
    }
}