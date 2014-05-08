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
    public partial class frmNhap_hepa : frmNhap_chung
    {
        private DataTable dtphieudathang;
        private DataSet dsphieudathang;

        public frmNhap_hepa(LibDuoc.AccessData acc, string loai, string mmyy, string ngay, int nhom, int userid, string kho, string title, bool ban, bool admin, string _manhom, int _khudt,int _chinhanh)
        {
            InitializeComponent();
            base.init();
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
            base.iChinhanh = _chinhanh;
            base.iSuasoluong = 60;
        }
        private void frmNhap_hepa_Load(object sender, EventArgs e)
        {
            base.Load_form();
            Load_chinhanh();
            enaObject(false);
        }
        private void Load_chinhanh()
        {
            try
            {
                cbochinhanh.DisplayMember = "TEN";
                cbochinhanh.ValueMember = "ID";
                cbochinhanh.DataSource = base.libDuoc.get_data("select id,ten from " + base.user + ".dmchinhanh").Tables[0];
            }
            catch { }
        }
        private void Load_sophieu()
        {
            try
            {
                dtphieudathang = new DataTable();
                string sql = "";
                sql = "select a.id,a.phieu ";
                sql += "from " + base.user + ".d_kehoachdathang a," + base.user + ".d_kehoachdathangtheodoi b ";
                sql += "," + base.user + ".d_theodoiduyetdutru c ";
                sql += "where a.id=b.id and b.id_duyetdutrukho=c.id and a.mua=0 and c.id_chinhanh="+cbochinhanh.SelectedValue.ToString()+"";
                //if (dk != "") sql += " and a.sophieu=" + dk + " ";
                //sql += "and to_char(a.ngay,'dd/mm/yyyy')='" + base.sNgay + "' ";
                dtphieudathang = base.libDuoc.get_data(sql).Tables[0];
            }
            catch { dtphieudathang = null; }
        }
        private void Load_grid()
        {
            try
            {
                base.dtct.Clear();
                dataGrid1.DataSource = null;
                dsphieudathang = new DataSet();
                string sql = "";
                sql = "select b.stt,b.mabd,c.ma,trim(c.ten)||' '||c.hamluong as ten,nullif(c.tenhc,' ') as tenhc";
                sql += ",c.dang,'' as handung,'' as losx,b.soluong,b.slthucte,c.dongia as dongia,b.vat, ";
                sql += "b.soluong*round(c.dongia," + base.i_thanhtien_le + ") as sotien,";
                sql += "(b.soluong*round(c.dongia," + base.i_thanhtien_le + "))+(b.soluong*round(c.dongia*b.vat/100," + base.i_thanhtien_le + ")) as tongtien,";
                sql += "c.giaban,c.dongia giamua,f.ten as tenhang,e.ten as tennuoc,0 as sl1,0 as sl2,0 as tyle,0 as cuocvc,0 as chaythu,0 as namsx,";
                sql += "'' as tailieu,0 as baohanh,0 as nguongoc,0 as tinhtrang,'' as sothe,0 as giabancu,0 as giamuacu,0 as giaban2,0 as tyle2,0 as tyle_ggia,";
                sql += "0 as st_ggia,case when b.vat=0 then 0 else b.soluong*round(c.dongia*b.vat/100," + base.i_thanhtien_le + ") end as sotienvat ";
                sql += "from " + base.user + ".d_kehoachdathang a," + base.user + ".d_kehoachdathangct b, ";
                sql += "" + base.user + ".d_dmbd c," + base.user + ".d_kehoachdathangtheodoi d," + base.user + ".d_dmnuoc e," + base.user + ".d_dmhang f ";
                sql += "where a.id=b.id and b.mabd=c.id and a.id=d.id and c.manuoc=e.id and c.mahang=f.id ";
                sql += " and a.id=" + cbosophieudh.SelectedValue.ToString() + " ";
                dsphieudathang = base.libDuoc.get_data(sql);
                dataGrid1.DataSource = dsphieudathang.Tables[0];
                base.dtct = dsphieudathang.Tables[0];
            }
            catch { }
        }
        private void f_Disnable()
        {
            base.bbkiem.Visible = false;
        }
        private void f_LoadData()
        {

        }

        private void cbochinhanh_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cbochinhanh)
                {
                    Load_sophieu();
                    cbosophieudh.DisplayMember = "PHIEU";
                    cbosophieudh.ValueMember = "ID";
                    cbosophieudh.DataSource = dtphieudathang;
                }
            }
            catch { }
        }

        private void cbosophieudh_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_grid();
                //if (dsphieudathang.Tables[0].Rows.Count > 0)
            }
            catch { }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.bLuu)
                {
                    decimal id_khdh = 0;
                    try { id_khdh = decimal.Parse(cbosophieudh.SelectedValue.ToString()); }
                    catch { id_khdh = 0; }
                    base.libDuoc.execute_data("update " + base.xxx + ".d_nhapll set id_kehoachdathang=" + id_khdh + " where id=" + base.l_id + "");
                    base.libDuoc.execute_data("update " + base.user + ".d_kehoachdathang set mua=1 where id=" + id_khdh + "");
                    foreach (DataRow r in dsphieudathang.Tables[0].Rows)
                    {
                        base.libDuoc.execute_data("update " + base.xxx + ".d_nhapct set soluong=" + r["slthucte"].ToString() + " where id=" + base.l_id + " and stt=" + r["stt"].ToString() + "");
                    }
                }
            }
            catch { }
        }

        private void co_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{F4}");
                cbochinhanh.Focus();
            }
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            enaObject(true);
        }
        private void enaObject(bool ena)
        {
            cbochinhanh.Enabled = ena;
            cbosophieudh.Enabled = ena;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            enaObject(false);
        }
    }
}