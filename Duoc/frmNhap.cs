using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;

namespace Duoc
{
    public partial class frmNhap : frmNhap_chung 
    {
        public frmNhap()
        {
            InitializeComponent();
            base.init();
        }
        public frmNhap(AccessData acc, string loai, string mmyy, string ngay, int nhom, int userid, string kho, string title, bool ban, bool admin, string _manhom, int _khudt)
        {
            InitializeComponent();
            init();            
            base.iNhom = nhom;
            base.sManhom = _manhom;
            base.sKho = kho;
            base.iUserid = userid;
            base.sMmyy = mmyy;
            base.sNgay = ngay;
            base.sLoai = loai;
            base.bBan = ban;
            base.b_Admin = admin;
            base.sTitle = title;
            base.iKhudt = _khudt;
        }
        ///Dong 13/07/2011
        public frmNhap(AccessData acc, string loai, string mmyy, string ngay, int nhom, int userid, string kho, string title, bool ban, bool admin, string _manhom, int _khudt, int _ichinhanh)
        {
            InitializeComponent();
            init();
            base.iNhom = nhom;
            base.sManhom = _manhom;
            base.sKho = kho;
            base.iUserid = userid;
            base.sMmyy = mmyy;
            base.sNgay = ngay;
            base.sLoai = loai;
            base.bBan = ban;
            base.b_Admin = admin;
            base.sTitle = title;
            base.iKhudt = _khudt;
            base.iChinhanh = _ichinhanh;            
        }

        private void frmNhap_Load(object sender, EventArgs e)
        {
            base.Load_form();
        }       
    }
}