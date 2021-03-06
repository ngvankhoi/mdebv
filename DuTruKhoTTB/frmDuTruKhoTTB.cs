using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LibTTB;

namespace DuTruKhoTTB
{
    public partial class frmDuTruKhoTTB : Form
    {
        private LibTTB.AccessData ttb = new LibTTB.AccessData();
        private string s_userid = "", s_makp = "", s_nhomkho = "";
        private int i_userid = 0;

        public frmDuTruKhoTTB()
        {
            InitializeComponent();
        }

        private void PhieuDuTruTaiSan_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmHaophi")) return;
            int loai = 4;
            frmChonthongso f = new frmChonthongso(ttb, 2, loai, 0, s_makp, false, s_nhomkho);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmHaophi f1 = new frmHaophi(ttb,f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Dự trù tài sản " + f.s_tennhom.Trim() + " (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", ttb.Msg, ttb.iSudungthuoc, f.s_manguon, false, f.s_tenkp, f.s_phieu, f.i_somay);
                //f1.MdiParent = this;
                f1.ShowDialog();
            }
        }

        private void PhieuHoanTraTaiSan_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmHoantrataisan")) return;
            int loai = 3;
            frmChonthongso f = new frmChonthongso(ttb, 2, loai, 0, s_makp, false, s_nhomkho);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmHoantrataisan f1 = new frmHoantrataisan(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu hoàn trả tài sản " + f.s_tennhom.Trim() + " (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", ttb.Msg, false, ttb.iSudungthuoc, f.s_manguon, f.s_tenkp, f.s_phieu, f.i_somay);
                //f1.MdiParent = this;
                f1.ShowDialog();
            }
        }
        private bool IsLoaded(string frm)
        {
            Form[] afrm = this.MdiChildren;
            foreach (Form f in afrm)
            {
                if (f.Name.Equals(frm)) { f.Activate(); return true; }
            }
            return false;
        }

        private void xemtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChontutruc f = new frmChontutruc(s_makp, ttb.nhom_duoc, 2, s_nhomkho);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtutructh f1 = new frmXemtutructh(f.i_nhom, f.i_makho, f.i_makp, f.mmyy, f.tenkho, f.tenkp, 2);
                //f1.MdiParent = this;
                f1.ShowDialog();
            }
        }
    }
}