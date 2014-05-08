using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmManHinhLCD_thongso : Form
    {
        public frmManHinhLCD_thongso()
        {
            InitializeComponent();
        }
        DataSet _dsThongSo;
        public decimal ToaDo_X
        {
            get { return vitri_x.Value; }
            set { vitri_x.Value = value; }
        }
        public decimal ToaDo_Y
        {
            get { return vitri_y.Value; }
            set { vitri_y.Value = value; }
        }
        public decimal ChieuRong
        {
            get { return kt_rong.Value; }
            set { kt_rong.Value = value; }
        }
        public decimal ChieuCao
        {
            get { return kt_cao.Value; }
            set { kt_cao.Value = value; }
        }
        public decimal TieuDe_cochu
        {
            get { return sizefont.Value; }
            set { sizefont.Value = value; }
        }
        public int TieuDe_maunen_red
        {
            get { return maunen_r.Value; }
            set { maunen_r.Value = value; }
        }
        public int TieuDe_maunen_green
        {
            get { return maunen_g.Value; }
            set { maunen_g.Value = value; }
        }
        public int TieuDe_maunen_blue
        {
            get { return maunen_b.Value; }
            set { maunen_b.Value = value; }
        }
        public int TieuDe_mauchu_red
        {
            get { return mauchu_r.Value; }
            set { mauchu_r.Value = value; }
        }
        public int TieuDe_mauchu_green
        {
            get { return mauchu_g.Value; }
            set { mauchu_g.Value = value; }
        }
        public int TieuDe_mauchu_blue
        {
            get { return mauchu_b.Value; }
            set { mauchu_b.Value = value; }
        }
        public decimal DanhSach_cochu
        {
            get { return sizefont_ds.Value; }
            set { sizefont_ds.Value = value; }
        }
        public int DanhSach_maunen_red
        {
            get { return maunen_ds_r.Value; }
            set { maunen_ds_r.Value = value; }
        }
        public int DanhSach_maunen_green
        {
            get { return maunen_ds_g.Value; }
            set { maunen_ds_g.Value = value; }
        }
        public int DanhSach_maunen_blue
        {
            get { return maunen_ds_b.Value; }
            set { maunen_ds_b.Value = value; }
        }
        public int DanhSach_mauchu_red
        {
            get { return mauchu_ds_r.Value; }
            set { mauchu_ds_r.Value = value; }
        }
        public int DanhSach_mauchu_green
        {
            get { return mauchu_ds_g.Value; }
            set { mauchu_ds_g.Value = value; }
        }
        public int DanhSach_mauchu_blue
        {
            get { return mauchu_ds_b.Value; }
            set { mauchu_ds_b.Value = value; }
        }
        public string FileXml
        {
            get { return (!bCauHinhTheoDSBN) ? "..\\..\\..\\xml\\ThongSoLCDPhongKham.xml" : "..\\..\\..\\xml\\ThongSoLCDDanhSachBN.xml"; }
        }
        public bool bCauHinhTheoDSBN = false;
        
        public void frmManHinhLCD_thongso_Load(object sender, EventArgs e)
        {
            _dsThongSo = new DataSet();
            try
            {
                _dsThongSo.ReadXml(FileXml);
            }
            catch
            {
                _dsThongSo.Tables.Add(TaoThongSo());

            }
            if (_dsThongSo.Tables[0].Rows.Count == 0)
            {
                DataRow r = _dsThongSo.Tables[0].NewRow();
                _dsThongSo.Tables[0].Rows.Add(r);
                LuuThongSo(_dsThongSo);
            }
            DocThongSo(_dsThongSo.Tables[0]);
            mauchu_ds_r_Scroll(null, null);
            mauchu_r_Scroll(null, null);
        }
        DataTable TaoThongSo()
        {
            DataTable dttam = new DataTable();

            dttam.Columns.Add("ToaDo_X");
            dttam.Columns.Add("ToaDo_Y");
            dttam.Columns.Add("ChieuRong");
            dttam.Columns.Add("ChieuCao");
            dttam.Columns.Add("TieuDe_cochu");
            dttam.Columns.Add("TieuDe_maunen_r");
            dttam.Columns.Add("TieuDe_maunen_g");
            dttam.Columns.Add("TieuDe_maunen_b");

            dttam.Columns.Add("TieuDe_mauchu_r");
            dttam.Columns.Add("TieuDe_mauchu_g");
            dttam.Columns.Add("TieuDe_mauchu_b");

            dttam.Columns.Add("DanhSach_cochu");
            dttam.Columns.Add("DanhSach_maunen_r");
            dttam.Columns.Add("DanhSach_maunen_g");
            dttam.Columns.Add("DanhSach_maunen_b");

            dttam.Columns.Add("DanhSach_mauchu_r");
            dttam.Columns.Add("DanhSach_mauchu_g");
            dttam.Columns.Add("DanhSach_mauchu_b");

            return dttam;
        }
        void DocThongSo(DataTable dttam)
        {
            

            ToaDo_X = decimal.Parse(dttam.Rows[0]["ToaDo_X"].ToString());
            ToaDo_Y = decimal.Parse(dttam.Rows[0]["ToaDo_Y"].ToString());

            ChieuRong = decimal.Parse(dttam.Rows[0]["ChieuRong"].ToString());
            ChieuCao = decimal.Parse(dttam.Rows[0]["ChieuCao"].ToString());

            TieuDe_cochu = decimal.Parse(dttam.Rows[0]["TieuDe_cochu"].ToString());
            DanhSach_cochu = decimal.Parse(dttam.Rows[0]["DanhSach_cochu"].ToString());

            TieuDe_mauchu_blue = int.Parse(dttam.Rows[0]["TieuDe_mauchu_b"].ToString()); 
            TieuDe_mauchu_green = int.Parse(dttam.Rows[0]["TieuDe_mauchu_g"].ToString()); 
            TieuDe_mauchu_red = int.Parse(dttam.Rows[0]["TieuDe_mauchu_r"].ToString());

            DanhSach_mauchu_blue = int.Parse(dttam.Rows[0]["DanhSach_mauchu_b"].ToString());
            DanhSach_mauchu_green = int.Parse(dttam.Rows[0]["DanhSach_mauchu_g"].ToString());
            DanhSach_mauchu_red = int.Parse(dttam.Rows[0]["DanhSach_mauchu_r"].ToString());

            TieuDe_maunen_blue = int.Parse(dttam.Rows[0]["TieuDe_maunen_b"].ToString());
            TieuDe_maunen_green = int.Parse(dttam.Rows[0]["TieuDe_maunen_g"].ToString());
            TieuDe_maunen_red = int.Parse(dttam.Rows[0]["TieuDe_maunen_r"].ToString());

            DanhSach_maunen_blue = int.Parse(dttam.Rows[0]["DanhSach_maunen_b"].ToString());
            DanhSach_maunen_green = int.Parse(dttam.Rows[0]["DanhSach_maunen_g"].ToString());
            DanhSach_maunen_red = int.Parse(dttam.Rows[0]["DanhSach_maunen_r"].ToString());


        }
        void LuuThongSo(DataSet dstam)
        {
            
            dstam.Tables[0].Rows[0]["ToaDo_X"] = ToaDo_X.ToString();
            dstam.Tables[0].Rows[0]["ToaDo_Y"] = ToaDo_Y.ToString();

            dstam.Tables[0].Rows[0]["ChieuRong"] = ChieuRong.ToString();
            dstam.Tables[0].Rows[0]["ChieuCao"] = ChieuCao.ToString();

            dstam.Tables[0].Rows[0]["TieuDe_cochu"] = TieuDe_cochu.ToString();
            dstam.Tables[0].Rows[0]["DanhSach_cochu"] = DanhSach_cochu.ToString();

            dstam.Tables[0].Rows[0]["TieuDe_mauchu_b"] = mauchu_b.Value.ToString();
            dstam.Tables[0].Rows[0]["TieuDe_mauchu_g"] = mauchu_g.Value.ToString();
            dstam.Tables[0].Rows[0]["TieuDe_mauchu_r"] = mauchu_r.Value.ToString();

            dstam.Tables[0].Rows[0]["TieuDe_maunen_b"] = maunen_b.Value.ToString();
            dstam.Tables[0].Rows[0]["TieuDe_maunen_g"] = maunen_g.Value.ToString();
            dstam.Tables[0].Rows[0]["TieuDe_maunen_r"] = maunen_r.Value.ToString();


            dstam.Tables[0].Rows[0]["DanhSach_mauchu_b"] = mauchu_ds_b.Value.ToString();
            dstam.Tables[0].Rows[0]["DanhSach_mauchu_g"] = mauchu_ds_g.Value.ToString();
            dstam.Tables[0].Rows[0]["DanhSach_mauchu_r"] = mauchu_ds_r.Value.ToString();

            dstam.Tables[0].Rows[0]["DanhSach_maunen_b"] = maunen_ds_b.Value.ToString();
            dstam.Tables[0].Rows[0]["DanhSach_maunen_g"] = maunen_ds_g.Value.ToString();
            dstam.Tables[0].Rows[0]["DanhSach_maunen_r"] = maunen_ds_r.Value.ToString();

            dstam.WriteXml(FileXml);
        }
        
        void LoadMauTieuDe(int mauchu_red, int mauchu_green, int mauchu_blue
            , int maunen_red, int maunen_green, int maunen_blue)
        {
            lbl_mauchu.ForeColor = lbl_maunen.ForeColor = Color.FromArgb(mauchu_red, mauchu_green, mauchu_blue);
            lbl_mauchu.BackColor = lbl_maunen.BackColor = Color.FromArgb(maunen_red, maunen_green, maunen_blue);
        }

        void LoadMauDanhSach(int mauchu_red, int mauchu_green, int mauchu_blue
            , int maunen_red, int maunen_green, int maunen_blue)
        {
            lbl_mauchu_ds.ForeColor = lbl_maunen_ds.ForeColor = Color.FromArgb(mauchu_red, mauchu_green, mauchu_blue);
            lbl_mauchu_ds.BackColor = lbl_maunen_ds.BackColor = Color.FromArgb(maunen_red, maunen_green, maunen_blue);
        }
        

       

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mauchu_r_num_ValueChanged(object sender, EventArgs e)
        {

            if (ActiveControl != mauchu_b_num
                && ActiveControl != mauchu_g_num
                && ActiveControl != mauchu_r_num
                && ActiveControl != maunen_b_num
                && ActiveControl != maunen_g_num
                && ActiveControl != maunen_r_num) return;

            mauchu_b.Value=int.Parse(mauchu_b_num.Value.ToString());
            mauchu_g.Value=int.Parse(mauchu_g_num.Value.ToString());
            mauchu_r.Value=int.Parse(mauchu_r_num.Value.ToString());

            maunen_b.Value=int.Parse(maunen_b_num.Value.ToString());
            maunen_g.Value=int.Parse(maunen_g_num.Value.ToString());
            maunen_r.Value=int.Parse(maunen_r_num.Value.ToString());

            LoadMauTieuDe(int.Parse(mauchu_r_num.Value.ToString())
            , int.Parse(mauchu_g_num.Value.ToString())
            , int.Parse(mauchu_b_num.Value.ToString())
            , int.Parse(maunen_r_num.Value.ToString())
            , int.Parse(maunen_g_num.Value.ToString())
            , int.Parse(maunen_b_num.Value.ToString()));

           

        }

        public void btnluu_Click(object sender, EventArgs e)
        {
            LuuThongSo(_dsThongSo);
        }

        private void mauchu_ds_r_num_ValueChanged(object sender, EventArgs e)
        {

            if (ActiveControl != mauchu_ds_b_num
                && ActiveControl != mauchu_ds_g_num
                && ActiveControl != mauchu_ds_r_num
                && ActiveControl != maunen_ds_b_num
                && ActiveControl != maunen_ds_g_num
                && ActiveControl != maunen_ds_r_num) return;
            mauchu_ds_b.Value=int.Parse(mauchu_ds_b_num.Value.ToString());
            mauchu_ds_g.Value=int.Parse(mauchu_ds_g_num.Value.ToString());
            mauchu_ds_r.Value=int.Parse(mauchu_ds_r_num.Value.ToString());

            maunen_ds_b.Value=int.Parse(maunen_ds_b_num.Value.ToString());
            maunen_ds_g.Value=int.Parse(maunen_ds_g_num.Value.ToString());
            maunen_ds_r.Value=int.Parse(maunen_ds_r_num.Value.ToString());

            LoadMauDanhSach(int.Parse(mauchu_ds_r_num.Value.ToString())
            , int.Parse(mauchu_ds_g_num.Value.ToString())
            , int.Parse(mauchu_ds_b_num.Value.ToString())
            , int.Parse(maunen_ds_r_num.Value.ToString())
            , int.Parse(maunen_ds_g_num.Value.ToString())
            , int.Parse(maunen_ds_b_num.Value.ToString()));
        }

        private void mauchu_r_Scroll(object sender, ScrollEventArgs e)
        {
            mauchu_b_num.Value = mauchu_b.Value;
            mauchu_g_num.Value = mauchu_g.Value;
            mauchu_r_num.Value = mauchu_r.Value;

            maunen_b_num.Value = maunen_b.Value;
            maunen_g_num.Value = maunen_g.Value;
            maunen_r_num.Value = maunen_r.Value;

            LoadMauTieuDe(int.Parse(mauchu_r_num.Value.ToString())
            , int.Parse(mauchu_g_num.Value.ToString())
            , int.Parse(mauchu_b_num.Value.ToString())
            , int.Parse(maunen_r_num.Value.ToString())
            , int.Parse(maunen_g_num.Value.ToString())
            , int.Parse(maunen_b_num.Value.ToString()));
        }

        private void mauchu_ds_r_Scroll(object sender, ScrollEventArgs e)
        {
            mauchu_ds_b_num.Value = mauchu_ds_b.Value;
            mauchu_ds_g_num.Value = mauchu_ds_g.Value;
            mauchu_ds_r_num.Value = mauchu_ds_r.Value;

            maunen_ds_b_num.Value = maunen_ds_b.Value;
            maunen_ds_g_num.Value = maunen_ds_g.Value;
            maunen_ds_r_num.Value = maunen_ds_r.Value;

            LoadMauDanhSach(int.Parse(mauchu_ds_r_num.Value.ToString())
            , int.Parse(mauchu_ds_g_num.Value.ToString())
            , int.Parse(mauchu_ds_b_num.Value.ToString())
            , int.Parse(maunen_ds_r_num.Value.ToString())
            , int.Parse(maunen_ds_g_num.Value.ToString())
            , int.Parse(maunen_ds_b_num.Value.ToString()));
        }

        

       
    }
}