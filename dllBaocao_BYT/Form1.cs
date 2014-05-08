using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dllBaocao_BYT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LibMedi.AccessData m = new LibMedi.AccessData();
        private void vuDieuTriToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void bieu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu01 f = new frmBieu01("ADmin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void ketThucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bieu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu02 f = new frmBieu02("Admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu031 f = new frmBieu031("Admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu04 f = new frmBieu04("admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu05 f = new frmBieu05("Admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu06 f = new frmBieu06("ADmin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu07 f = new frmBieu07("ADmin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu08 f = new frmBieu08("admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBieu092 f = new frmBieu092("admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu091 f = new frmBieu091("admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBieu101 f = new frmBieu101("admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmBieu1021 f = new frmBieu1021("admin ", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmBieu1022 f = new frmBieu1022("admin ", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmBieu103 f = new frmBieu103("admin ", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (m.Mabv.Substring(0, 3) == "701")
            {
                frmBieu11_18_1 f1 = new frmBieu11_18_1(m, "Admin", 1, 1);
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                frmBieu11_1 f2 = new frmBieu11_1(m, "Admin", 1, 1);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void bieu01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m, "Bieu 01", false, "dm_01", 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu02ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m, "Hoạt động khám bệnh", true, "dm_02", 2);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu03ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Hoạt động điều trị", true, "dm_031", 3);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu01ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m, "Hoạt động phẫu thuật, thủ thuật", true, "dm_04", 4);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu05ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Hoạt động sức khỏe sinh sản", false, "dm_05", 5);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu06ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Hoạt động cận lâm sàng", false, "dm_06", 6);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu07ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Dược bệnh viện", false, "dm_07", 7);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu08ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Trang thiết bị y tế", false, "dm_08", 8);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu91ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Hoạt động chỉ đạo tuyến", false, "dm_091", 91);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu92ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Hoạt động nghiên cứu khoa học", false, "dm_092", 92);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu101ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Hoạt động tài chính", false, "dm_101", 101);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu1021ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Chi tiết về thu viện phí,Bảo hiểm", false, "dm_1021", 1021);
            f.MdiParent = this;
            f.Show();
        }

        private void bieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Chi tiết về các khoản chi", false, "dm_1022", 1022);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu103ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m,"Các khoản không thu được", false, "dm_103", 103);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m, "Tình hình bệnh tật, tử vong tại bệnh viện", true, "dm_11", 11);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu01ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmKh01 f = new frmKh01(m,"Admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh02 f = new frmKh02(m, "admin", 1,1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu03ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh031 f = new frmKh031(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu04ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh04 f = new frmKh04(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu05ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh05 f = new frmKh05(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu06ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh06 f = new frmKh06(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu07ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh07 f = new frmKh07(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu08ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh08 f = new frmKh08(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh09 f = new frmKh09(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu10ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh10 f = new frmKh10(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu11ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh11 f = new frmKh11(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu121ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh121 f = new frmKh121(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu122ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh122 f = new frmKh122(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu123ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh123 f = new frmKh123(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu124ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh124 f = new frmKh124(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu131ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh13 f = new frmKh13(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu132ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh132 f = new frmKh132(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu133ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh133 f = new frmKh133(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu141ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh141 f = new frmKh141(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu142ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh142 f = new frmKh142(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu143ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh143 f = new frmKh143(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu144ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh144 f = new frmKh144(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu145ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh145 f = new frmKh145(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKh15 f = new frmKh15(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void closeAllWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void bieu1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,"Dân số, đơn vị hành chính, trạm y tế xã", false, "khdm_01", 1);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, "Tình hình thu chi ngân sách y tế", false, "khdm_02", 2);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("Cơ sở và giường bệnh quận huyện"), false, "khdm_031", 3);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, (" Tình hình nhân lực y tế toàn huyện"), false, "khdm_04", 4);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("Hoạt động chăm sóc bà mẹ"), false, "khdm_05", 5);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu6ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("Tình hình mắc chết do tai biến sản khoa"), false, "khdm_06", 6);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu7ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("7.Bieu 07- Hoạt động khám chữa phụ khoa và nạo phá thai"), false, "khdm_07", 7);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu8ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("8.Bieu 08 - Hoạt động cung cấp dịch vụ kế hoạch hóa gia đình"), false, "khdm_08", 8);
            f.MdiParent = this;
            f.Show();
        }

        private void cuongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("9. Bieu 09- Tình hình sức khỏe tre em"), false, "khdm_09", 9);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu10ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("10. Bieu 10- Hoạt động tiêm chủn phòng 10 bệnh cho trẻ em"), false, "khdm_10", 10);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu11ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("11.Bieu 11 Mắc chết các bệnh có vacxin phòng ngừa"), false, "khdm_11", 11);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu121ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("12.1 Bieu 12.1 Hoạt động khám chữa bệnh"), false, "khdm_121", 121);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu122ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("12.2 Bieu 12.2 Hoạt động khám chữa bênh"), false, "khdm_122", 122);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu123ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,("Biểu 12.3//Công tác khám chữa bệnh và dịch vụ y tế"), false, "kh_dm_123", 123);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu124ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,("Biểu 12.4//Công tác khám chữa bệnh và dịch vụ y tế"), false, "kh_dm_124", 124);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu131ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("13.1 Bieu 13 Hoạt động phòng chống bệnh xã hội"), false, "khdm_13", 131);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu132ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,("Biểu 13.2//Thực hiện công tác phòng bệnh"), false, "kh_dm_132", 132);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu133ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,("Biểu 13.3//Thực hiện công tác phòng bệnh"), false, "kh_dm_133", 133);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu134ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("14.1 Bieu 14.1 Tình hình mắc chết bệnh truyền nhiễm gây dịch và  bệnh quan trọng"), false, "khdm_141", 141);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu142ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("14.2 Bieu 14.2 Tình hình mắc chết bệnh truyền nhiễm gây dịch và  bệnh quan trọng"), false, "khdm_142", 142);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu133ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, ("14.3 Bieu 14.3 Tình hình mắc chết bệnh truyền nhiễm gây dịch và  bệnh quan trọng"), false, "khdm_143", 143);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu144ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,("Biểu 14.4//Các bệnh lây và bệnh quan trọng"), false, "kh_dm_144", 144);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu145ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,("Báo cáo thống kê tai nạn, thuơng tích"), true, "kh_dm_1451", 145);
            f.MdiParent = this;
            f.Show();
        }

        private void bieu15ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,("Tình hình bệnh tật, tử vong tại bệnh viện theo ICD10"), true, "dm_11", 15);
            f.MdiParent = this;
            f.Show();
        }

        private void tạoSốLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaosolieu f = new frmTaosolieu(m);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCoso f = new frmCoso(m);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmKh031 f = new frmKh031(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmKh032 f = new frmKh032(m, "admin", 1, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            rptBieukh f = new rptBieukh(m, "Tình hình y tế xã - phường", false, "khdm_032", 32);
            f.MdiParent = this;
            f.Show();
        }
    }
}