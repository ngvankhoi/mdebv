using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmLCD_laocai : Form
    {
        public frmLCD_laocai()
        {
            InitializeComponent();
        }
        
        Label _lblketthuc = new Label();
        Label _lbltam = new Label();
        Label _lblhoten = new Label();
        Label _lblstt = new Label();
        Timer _time = new Timer();      
       
        DataTable _dtDanhSach;
        DataTable dtPathImage;
        frmManHinhLCD_thongso _frmthongso;

        int _ipost_cur = 0;
        string _stenpk = "phòng khám";
        string _stenbn = "";
        string _sstt = "";
        //string _sghichu = "";
        string _sts_STT_size = "", _sts_STT_vitri_x = "", _sts_STT_vitri_y = "";
        string _sts_DangKham_vitri_x = "", _sts_DangKham_vitri_y = "";
        string _sts_DangCho_vitri_x = "", _sts_DangCho_vitri_y = "";
        string _sts_PhongKham_vitri_x = "", _sts_PhongKham_vitri_y = "", _sts_PhongKham_size = "";
        string _sts_DSBN_vitri_x = "", _sts_DSBN_vitri_y_bd = "";
        string _sts_TenBacSi_vitri_x = "", _sts_TenBacSi_vitri_y = "", _sts_TenBacSi_size="";
        string _sts_TenBN_size = "";
        string _sts_GhiChu = "";
        string _sts_TenBacSi = "";
        string _sts_GhiChu_size = "";

        private void frmLCD_laocai_Load(object sender, EventArgs e)
        {
            
            _frmthongso = new frmManHinhLCD_thongso();
            _frmthongso.bCauHinhTheoDSBN = true;
            _frmthongso.frmManHinhLCD_thongso_Load(null, null);

            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(int.Parse(_frmthongso.ToaDo_X.ToString())
                , int.Parse(_frmthongso.ToaDo_Y.ToString()));
            this.Height = int.Parse(_frmthongso.ChieuCao.ToString());
            this.Width = int.Parse(_frmthongso.ChieuRong.ToString());

            #region đọc file hình ảnh
            dtPathImage = new DataTable();
            dtPathImage.Columns.Add("ten");
            //ds.WriteXml("dstam.xml",XmlWriteMode.WriteSchema);			
            try
            {
                DataRow dr;
                string stam = "";
                string[] arr = System.IO.Directory.GetFiles("ImageLCD");
                for (int i = 0; i < arr.Length; i++)
                {
                    stam = arr[i].Split('\\')[arr[i].Split('\\').Length - 1];
                    if (stam.IndexOf(".jpeg") > -1 || stam.IndexOf(".jpg") > -1 || stam.IndexOf(".gif") > -1)
                    {
                        dr = dtPathImage.NewRow();
                        dr[0] = arr[i];
                        dtPathImage.Rows.Add(dr);
                    }

                }

            }
            catch { System.IO.Directory.CreateDirectory("ImageLCD"); }
            try
            {
                this.BackgroundImage = Image.FromFile(dtPathImage.Rows[0][0].ToString());
            }
            catch { }
            #endregion
            #region đọc thông số LCD
            DataSet dstam = new DataSet();
            try
            {
                dstam.ReadXml("..\\..\\..\\xml\\ThongSoManHinhLCD.xml");
                try
                {
                    dstam.Tables[0].Columns.Add("PhongKham_size");
                    dstam.Tables[0].Columns["PhongKham_size"].SetOrdinal(9);
                    dstam.Tables[0].Rows[0]["PhongKham_size"] = 20;
                    
                }
                catch 
                { 
                }
                try
                {
                    dstam.Tables[0].Columns.Add("TenBacSi_vitri_x");
                    dstam.Tables[0].Columns.Add("TenBacSi_vitri_y");
                    dstam.Tables[0].Columns.Add("TenBacSi_size");

                    dstam.Tables[0].Rows[0]["TenBacSi_vitri_x"] = 100;
                    dstam.Tables[0].Rows[0]["TenBacSi_vitri_y"] = 20;
                    dstam.Tables[0].Rows[0]["TenBacSi_size"] = 0;
                }
                catch { }
            }
            catch
            {
                dstam = new DataSet();
                dstam.Tables.Add();
                dstam.Tables[0].Columns.Add("STT_size");
                dstam.Tables[0].Columns.Add("STT_vitri_x");
                dstam.Tables[0].Columns.Add("STT_vitri_y");
                dstam.Tables[0].Columns.Add("DangKham_vitri_x");
                dstam.Tables[0].Columns.Add("DangKham_vitri_y");
                dstam.Tables[0].Columns.Add("DangCho_vitri_x");
                dstam.Tables[0].Columns.Add("DangCho_vitri_y");
                dstam.Tables[0].Columns.Add("PhongKham_vitri_x");
                dstam.Tables[0].Columns.Add("PhongKham_vitri_y");
                dstam.Tables[0].Columns.Add("PhongKham_size");
                dstam.Tables[0].Columns.Add("TenBN_size");
                //dstam.Tables[0].Columns.Add("DSBN_chieucao");
                dstam.Tables[0].Columns.Add("DSBN_vitri_x");
                dstam.Tables[0].Columns.Add("DSBN_vitri_y_bd");
                dstam.Tables[0].Columns.Add("GhiChu");
                dstam.Tables[0].Columns.Add("GhiChu_size");
                dstam.Tables[0].Columns.Add("TenBacSi_vitri_x");
                dstam.Tables[0].Columns.Add("TenBacSi_vitri_y");
                dstam.Tables[0].Columns.Add("TenBacSi_size");
                DataRow dr = dstam.Tables[0].NewRow();
                //stt
                dr[0] = "150"; dr[1] = "100"; dr[2] = "100";
                //
                //Dang Kham
                dr[3] = "220"; dr[4] = "35";
                //
                //Dang Cho Kham
                dr[5] = "800"; dr[6] = "35";
                //
                //Phong Kham
                dr[7] = "500"; dr[8] = "570"; dr[9] = "20";
                //
                //Kich thuoc ten benh nhan
                dr[10] = "20";
                //
                //Kich thuoc danh sach benh nhan
                //dr[10] = "420"; 
                dr[11] = "750"; dr[12] = "80";
                //
                //Ghi chú
                dr[13] = "Địa chỉ: đường Chiềng On, P. Bình Minh, TP Lào Cai | Điện Thoại: 020 38….. | Fax: 020 38….. | mail: bvdktinhlaocai-syt@laocai.gov.vn | Website: www.bvdktinhlaocai.vn";
                dr[14] = "15";
                //
                //Tên bác sĩ
                dr[15] = "100";
                dr[16] = "20";
                dr[17] = "0";
                //
                dstam.Tables[0].Rows.Add(dr);
                
            }
            dstam.WriteXml("..\\..\\..\\xml\\ThongSoManHinhLCD.xml");
            //stt
            _sts_STT_size = dstam.Tables[0].Rows[0][0].ToString();
            _sts_STT_vitri_x = dstam.Tables[0].Rows[0][1].ToString();
            _sts_STT_vitri_y = dstam.Tables[0].Rows[0][2].ToString();
            //
            //Dang Kham
            _sts_DangKham_vitri_x = dstam.Tables[0].Rows[0][3].ToString();
            _sts_DangKham_vitri_y = dstam.Tables[0].Rows[0][4].ToString();
            //
            //Dang Cho Kham
            _sts_DangCho_vitri_x = dstam.Tables[0].Rows[0][5].ToString();
            _sts_DangCho_vitri_y = dstam.Tables[0].Rows[0][6].ToString(); ;
            //
            //Phong Kham
            _sts_PhongKham_vitri_x = dstam.Tables[0].Rows[0][7].ToString();
            _sts_PhongKham_vitri_y = dstam.Tables[0].Rows[0][8].ToString();
            _sts_PhongKham_size = dstam.Tables[0].Rows[0][9].ToString();
            //
            //Kich thuoc ten benh nhan
            _sts_TenBN_size = dstam.Tables[0].Rows[0][10].ToString();
            //
            //Kich thuoc danh sach benh nhan
            //_sts_DSBN_chieucao = dstam.Tables[0].Rows[0][10].ToString();
            _sts_DSBN_vitri_x = dstam.Tables[0].Rows[0][11].ToString();
            _sts_DSBN_vitri_y_bd = dstam.Tables[0].Rows[0][12].ToString();
            //
            //Ghi chú
            _sts_GhiChu = dstam.Tables[0].Rows[0][13].ToString();
            _sts_GhiChu_size = dstam.Tables[0].Rows[0][14].ToString();
            //
            //Tên bác sĩ
            _sts_TenBacSi_vitri_x = dstam.Tables[0].Rows[0][15].ToString();
            _sts_TenBacSi_vitri_y = dstam.Tables[0].Rows[0][16].ToString();
            _sts_TenBacSi_size = dstam.Tables[0].Rows[0][17].ToString();
            //
            #endregion
            #region define button ket thuc
            this.Controls.Add(_lblketthuc);
            
            _lblketthuc.AutoSize = true;
            _lblketthuc.Text = "Tắt màn hình";
            _lblketthuc.Font = new Font("Arial", 16);
            _lblketthuc.ForeColor = Color.Red;
            _lblketthuc.Location = new Point(0, 0);
            _lblketthuc.Click += new EventHandler(_lblketthuc_click);
            _lblketthuc.MouseEnter +=new EventHandler(lbltat_MouseEnter);
            _lblketthuc.MouseLeave += new EventHandler(lbltat_MouseLeave);
            _lblketthuc.Cursor = Cursors.Hand;
            _lblketthuc.Visible = false;
            #endregion

            _ipost_cur = 500;
            this.Controls.Add(_lbltam);
            _lbltam.Visible = false;
            _lbltam.Location = new Point(0, _ipost_cur);
            _lbltam.Font = new Font("Arial",float.Parse(_frmthongso.DanhSach_cochu.ToString()),FontStyle.Bold);
            _lbltam.Text = "aa";
            _lbltam.AutoSize = true;

            this.Controls.Add(_lblhoten);
            this.Controls.Add(_lblstt);

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //setTable();
            //HienThi(_dtDanhSach, "", "", "");
            
            
            //_time.Tick += new EventHandler(time_tick);             
            //_time.Interval = 10;
            //_time.Start();
            IsClose = false;
        }
        void setTable()
        {
            _dtDanhSach = new DataTable();
            _dtDanhSach.Columns.Add("stt");
            _dtDanhSach.Columns.Add("hoten");
            DataRow dr;
            dr = _dtDanhSach.NewRow();
            dr[0] = 1; dr[1] = "nguyễn quang tài";
            _dtDanhSach.Rows.Add(dr);

            dr = _dtDanhSach.NewRow();
            dr[0] = 2; dr[1] = "văn thành thơ";
            _dtDanhSach.Rows.Add(dr);

            dr = _dtDanhSach.NewRow();
            dr[0] = 3; dr[1] = "đào văn cây";
            _dtDanhSach.Rows.Add(dr);

            dr = _dtDanhSach.NewRow();
            dr[0] = 4; dr[1] = "trần cờ đỏ";
            _dtDanhSach.Rows.Add(dr);

            dr = _dtDanhSach.NewRow();
            dr[0] = 5; dr[1] = "nguyễn lung linh";
            _dtDanhSach.Rows.Add(dr);

            dr = _dtDanhSach.NewRow();
            dr[0] = 5; dr[1] = "đỗ bờ rào";
            _dtDanhSach.Rows.Add(dr);

            dr = _dtDanhSach.NewRow();
            dr[0] = 5; dr[1] = "tiêu văn chí";
            _dtDanhSach.Rows.Add(dr);

            dr = _dtDanhSach.NewRow();
            dr[0] = 5; dr[1] = "kì văn cục";
            _dtDanhSach.Rows.Add(dr);
            dr = _dtDanhSach.NewRow();
            dr[0] = 5; dr[1] = "kì văn cục 2";
            _dtDanhSach.Rows.Add(dr);
            dr = _dtDanhSach.NewRow();
            dr[0] = 5; dr[1] = "kì văn cục 3";
            _dtDanhSach.Rows.Add(dr);
            dr = _dtDanhSach.NewRow();
            dr[0] = 5; dr[1] = "kì văn cục 4";
            _dtDanhSach.Rows.Add(dr);
        }
        void _lblketthuc_click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        
        static public bool IsClose
        {
            get
            {
                DataSet ds = new DataSet();
                try
                {
                    ds.ReadXml("StateLCD.xml");
                }
                catch
                {
                    UpdateStateForm(1);
                    ds.ReadXml("StateLCD.xml");
                }
                return (ds.Tables[0].Rows[0][0].ToString() == "1");
            }
            set { UpdateStateForm((value) ? 1 : 0); }
        }
        static void UpdateStateForm(int giatri)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml("StateLCD.xml");

            }
            catch
            {
                ds = new DataSet();
                ds.Tables.Add("LCD");
                ds.Tables[0].Columns.Add("isClose");
                DataRow dr = ds.Tables[0].NewRow();
                ds.Tables[0].Rows.Add(dr);

            }
            ds.Tables[0].Rows[0][0] = giatri;
            ds.WriteXml("StateLCD.xml");
        }
        void lbltat_MouseEnter(object sender, EventArgs e)
        {
            _lblketthuc.Visible = true;
            _lblketthuc.BringToFront();
        }
        void lbltat_MouseLeave(object sender, EventArgs e)
        {
            _lblketthuc.Visible = false;
        }
        void time_tick(object sender, EventArgs e)
        {
            //_ipost_cur--;
            //if ((_ipost_cur + _dtDanhSach.Rows.Count * _lbltam.Height) < (int.Parse(_sts_DSBN_vitri_y_bd) + int.Parse(_sts_DSBN_chieucao)))
            //    _ipost_cur = int.Parse(_sts_DSBN_chieucao) + int.Parse(_sts_DSBN_vitri_y_bd);
            
            
            this.Invalidate();
            
        }
        private void frmLCD_laocai_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X <= (_lblketthuc.Location.X + _lblketthuc.Width) 
                && e.X > _lblketthuc.Location.X 
                && e.Y <= (_lblketthuc.Location.Y + _lblketthuc.Height) 
                && e.Y > _lblketthuc.Location.Y)
            {
                lbltat_MouseEnter(null, null);
            }
            else
                lbltat_MouseLeave(null, null);
        }
        public void HienThi(DataTable dtdanhsach, string stt, string tenbn, string tenpk,string tenbacsi)
        {
            _dtDanhSach = dtdanhsach;
            _sstt = stt.PadLeft(2,'0');
            _stenbn = tenbn;
            _stenpk = tenpk;
            _sts_TenBacSi = tenbacsi;

            
            Label lbltam = new Label();          
               
            lbltam.AutoSize = true;
            lbltam.Font = new Font("Arial", int.Parse(_sts_STT_size));
            lbltam.Text = _sstt;
            this.Controls.Add(lbltam);
            
            _lblhoten.AutoSize = false;
            _lblhoten.Text = tenbn.ToUpper();
            _lblhoten.ForeColor = Color.Green;
            _lblhoten.Font = new Font("Arial", int.Parse(_sts_TenBN_size),FontStyle.Bold);
            _lblhoten.Width = lbltam.Width;
            _lblhoten.TextAlign = ContentAlignment.TopCenter;



            _lblstt.Text = _sstt;
            _lblstt.Font = lbltam.Font;
            _lblstt.AutoSize = false;
            _lblstt.Width = _lblhoten.Width;
            _lblstt.Height = lbltam.Height;
            _lblstt.TextAlign = ContentAlignment.MiddleCenter;
            _lblstt.ForeColor = _lblhoten.ForeColor;
            _lblstt.BackColor=_lblhoten.BackColor= Color.White;

            //_lblstt.Location = new Point((this.Width - pnldanhsach.Width) / 2 - (_lblhoten.Width / 2), (this.Height - panel2.Height) / 2 - (_lblstt.Height + _lblhoten.Height) / 2);
            //_lblhoten.Location = new Point((this.Width - pnldanhsach.Width) / 2 - (_lblhoten.Width / 2), _lblstt.Location.Y + _lblstt.Height);
            _lblstt.Location = new Point(int.Parse(_sts_STT_vitri_x), int.Parse(_sts_STT_vitri_y));
            _lblhoten.Location = new Point(_lblstt.Location.X, _lblstt.Location.Y + _lblstt.Height);
            _lblhoten.Height = this.Height - _lblhoten.Location.Y-300;

            this.Controls.Remove(lbltam);
            _lblhoten.Visible = _lblstt.Visible = false;
            this.Invalidate();

        }
        
        private void frmLCD_laocai_Paint(object sender, PaintEventArgs e)
        {
            //_stieude1 = "Đang khám";     
            Color c2 = new Color();
            c2 = Color.FromArgb(int.Parse(_frmthongso.DanhSach_mauchu_red.ToString())
                , int.Parse(_frmthongso.DanhSach_mauchu_green.ToString())
                , int.Parse(_frmthongso.DanhSach_mauchu_blue.ToString()));
            Color c = new Color();
            c = Color.FromArgb(int.Parse(_frmthongso.TieuDe_mauchu_red.ToString())
                , int.Parse(_frmthongso.TieuDe_mauchu_green.ToString())
                , int.Parse(_frmthongso.TieuDe_mauchu_blue.ToString()));

            e.Graphics.DrawString("Đang khám bệnh".ToUpper()
                , new Font("Arial", float.Parse(_frmthongso.TieuDe_cochu.ToString()), FontStyle.Bold)
                , (Brush)new SolidBrush(c), float.Parse(_sts_DangKham_vitri_x), float.Parse(_sts_DangKham_vitri_y));
            e.Graphics.DrawString("danh sách chờ khám bệnh".ToUpper()
                , new Font("Arial", float.Parse(_frmthongso.TieuDe_cochu.ToString()), FontStyle.Bold)
                , (Brush)new SolidBrush(c), float.Parse(_sts_DangCho_vitri_x), float.Parse(_sts_DangCho_vitri_y));
            Color c3 = Color.White;
            Label lb = new Label();
            lb.Visible = false;
            lb.AutoSize = true;
            lb.Font = new Font("Arial", float.Parse(_frmthongso.TieuDe_cochu.ToString()), FontStyle.Bold);
            lb.Text=_stenpk.ToUpper();
            this.Controls.Add(lb);
            e.Graphics.DrawString(lb.Text
                , new Font("Arial",float.Parse(_sts_PhongKham_size),FontStyle.Bold)
                , (Brush)new SolidBrush(c), float.Parse(_sts_PhongKham_vitri_x)-(lb.Width/2), float.Parse(_sts_PhongKham_vitri_y));
            if (_sts_GhiChu != "")
            {
                lb.Font = new Font("Arial", float.Parse(_sts_GhiChu_size), FontStyle.Bold);                
                lb.Text = _sts_GhiChu;
                e.Graphics.DrawString(_sts_GhiChu
                , lb.Font
                , (Brush)new SolidBrush(c3), (this.Width-lb.Width)/2, this.Height-30);
                
            }
            if (_sts_TenBacSi_size != "0"&&_sts_TenBacSi!="")
            {
                e.Graphics.DrawString(_sts_TenBacSi
                , new Font("Arial", float.Parse(_sts_TenBacSi_size), FontStyle.Bold)
                , (Brush)new SolidBrush(c), float.Parse(_sts_TenBacSi_vitri_x), float.Parse(_sts_TenBacSi_vitri_y));
            }
            if (_sstt != "00" )
            {
                RectangleF rect = new RectangleF(float.Parse(_lblstt.Location.X.ToString())
                , float.Parse(_lblstt.Location.Y.ToString())
                , float.Parse(_lblstt.Width.ToString())
                , float.Parse(_lblstt.Height.ToString()));

                e.Graphics.DrawString(_lblstt.Text
                , new Font("Arial", float.Parse(_lblstt.Font.Size.ToString()), FontStyle.Bold)
                , (Brush)new SolidBrush(c),rect);
            }
            if (_stenbn != "")
            {
                RectangleF rect2 = new RectangleF(float.Parse(_lblhoten.Location.X.ToString())
                , float.Parse(_lblhoten.Location.Y.ToString())
                , float.Parse(_lblhoten.Width.ToString())
                , float.Parse(_lblhoten.Height.ToString()));

                e.Graphics.DrawString(_lblhoten.Text
                , new Font("Arial", float.Parse(_lblhoten.Font.Size.ToString()), FontStyle.Bold)
                , (Brush)new SolidBrush(c), rect2);
            }
            this.Controls.Remove(lb);
            
            //e.Graphics.DrawString(_sstt.ToUpper()
            //    , new Font("Arial", float.Parse(_sts_STT_size), FontStyle.Bold)
            //    , (Brush)new SolidBrush(c), float.Parse(_sts_STT_vitri_x), float.Parse(_sts_STT_vitri_y));

            string strS1 = "",strS2="";
            for (int i = 0; i < ((_dtDanhSach.Rows.Count>10)?11:_dtDanhSach.Rows.Count); i++)
            {

                //if ((_ipost_cur + _d1) <= (int.Parse(_sts_DSBN_chieucao) + int.Parse(_sts_DSBN_vitri_y_bd)) 
                //    && (_ipost_cur + i * _lbltam.Height) >= int.Parse(_sts_DSBN_vitri_y_bd))
                //{
                //    e.Graphics.DrawString(_dtDanhSach.Rows[i]["ten"].ToString().ToUpper()
                //       , _lbltam.Font
                //           , (Brush)new SolidBrush(c2), 800, _ipost_cur + i * _lbltam.Height);
                //    _d1 += _lbltam.Height;
                //}
                strS1=_dtDanhSach.Rows[i]["hoten"].ToString();
                strS2 = _dtDanhSach.Rows[i]["sovaovien"].ToString().PadLeft(2,'0');
                if (i == 10) { strS1 = "..."; strS2 = " "; }
                e.Graphics.DrawString(strS2.ToUpper()
                   , _lbltam.Font
                       , (Brush)new SolidBrush(c2), int.Parse(_sts_DSBN_vitri_x), int.Parse(_sts_DSBN_vitri_y_bd) + i * _lbltam.Height);
                e.Graphics.DrawString("."
                   , _lbltam.Font
                       , (Brush)new SolidBrush(c2), int.Parse(_sts_DSBN_vitri_x)+30, int.Parse(_sts_DSBN_vitri_y_bd) + i * _lbltam.Height);
                e.Graphics.DrawString(strS1.ToUpper()
                   , _lbltam.Font
                       , (Brush)new SolidBrush(c2), int.Parse(_sts_DSBN_vitri_x)+50, int.Parse(_sts_DSBN_vitri_y_bd) + i * _lbltam.Height);
                

            }
            
            
        }

        private void frmLCD_laocai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _lblketthuc_click(null, null);
            }
        }

        private void frmManHinhLCD_Closed(object sender, FormClosedEventArgs e)
        {
            UpdateStateForm(1);
        }

        
        
    }
}