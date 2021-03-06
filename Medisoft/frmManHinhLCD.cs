using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmManHinhLCD : Form
    {
        
        public frmManHinhLCD()
        {
            InitializeComponent();
        }
        frmManHinhLCD_thongso _ts;
        LibMedi.AccessData libM = new LibMedi.AccessData();
        Panel pnl1 = new Panel();
        Panel pnl2 = new Panel();
        Panel pnl3 = new Panel();
        Panel pnltieude = new Panel();
        Label lblkethuc = new Label();
        Label lblcauhinh = new Label();
        int _iX = 0;
        private void frmManHinhLCD_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            _ts = new frmManHinhLCD_thongso();
            _ts.frmManHinhLCD_thongso_Load(null, null);
            
            //this.Location = new Point(10, 10);
            this.Location = new Point(int.Parse(_ts.ToaDo_X.ToString()), int.Parse(_ts.ToaDo_Y.ToString()));
            this.Width = int.Parse(_ts.ChieuRong.ToString());
            this.Height = int.Parse(_ts.ChieuCao.ToString());

            lblkethuc.Visible = false;
            lblkethuc.AutoSize = true;
            lblkethuc.Text = "Tắt màn hình";            
            lblkethuc.Font = new Font("Arial", 18, FontStyle.Bold);
            lblkethuc.ForeColor = Color.Red;            
            lblkethuc.Location = new Point(0, 0);
            lblkethuc.Click += new EventHandler(lblketthuc_click);
            lblkethuc.MouseEnter += new EventHandler(lblkethuc_MouseEnter);
            lblkethuc.MouseLeave += new EventHandler(lblkethuc_MouseLeave);
            lblkethuc.Cursor = Cursors.Hand;

            lblcauhinh.Visible = false;
            lblcauhinh.AutoSize = true;
            lblcauhinh.Text = "Thông số LCD";
            lblcauhinh.Font = new Font("Arial", 18, FontStyle.Bold);
            lblcauhinh.ForeColor = Color.Yellow;
            lblcauhinh.Location = new Point(0, lblkethuc.Height + lblkethuc.Location.Y);
            lblcauhinh.Click += new EventHandler(lblcauhinh_click);
            lblcauhinh.MouseEnter += new EventHandler(lblcauhinh_MouseEnter);
            lblcauhinh.MouseLeave += new EventHandler(lblcauhinh_MouseLeave);
            lblcauhinh.Cursor = Cursors.Hand;

            pnltieude.MouseMove += new MouseEventHandler(pnl_MouseMove);

            this.Controls.Add(lblkethuc);
            this.Controls.Add(lblcauhinh);
            this.Controls.Add(pnltieude);
            this.Controls.Add(pnl1);
            this.Controls.Add(pnl2);
            this.Controls.Add(pnl3);            
            HienThi(LoadData());
        }
        void lblcauhinh_MouseEnter(object sender, EventArgs e)
        {
            lblcauhinh.Visible = true;
            lblcauhinh.BringToFront();
        }
        void lblcauhinh_MouseLeave(object sender, EventArgs e)
        {
            lblcauhinh.Visible = false;
        }
        
        void lblcauhinh_click(object sender, EventArgs e)
        {
            frmManHinhLCD_thongso fr = new frmManHinhLCD_thongso();
            fr.ShowDialog();
            //frmManHinhLCD_Load(null, null);
        }       
        void lblkethuc_MouseEnter(object sender, EventArgs e)
        {
            lblkethuc.Visible = true;
            lblkethuc.BringToFront();
        }
        void lblkethuc_MouseLeave(object sender, EventArgs e)
        {
            lblkethuc.Visible = false;            
        }
        private void pnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X <= (lblkethuc.Location.X + lblkethuc.Width) && e.X > lblkethuc.Location.X && e.Y <= (lblkethuc.Location.Y + lblkethuc.Height) && e.Y > lblkethuc.Location.Y)
            {
                lblkethuc_MouseEnter(null, null);
            }
            else
                lblkethuc_MouseLeave(null, null);
            if (e.X <= (lblcauhinh.Location.X + lblcauhinh.Width) && e.X > lblcauhinh.Location.X && e.Y <= (lblcauhinh.Location.Y + lblcauhinh.Height) && e.Y > lblcauhinh.Location.Y)
            {
                lblcauhinh_MouseEnter(null, null);
            }
            else
                lblcauhinh_MouseLeave(null, null);
        }
        void lblketthuc_click(object sender, EventArgs e)
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
        DataTable LoadData()
        {

            //string s_date = "04/02/2013";
            string s_date = DateTime.Now.ToString("dd/MM/yyyy");
            string s_mmyy = DateTime.Now.ToString("MMyy");
            string s_user = libM.user;
            string sql = "select * from (";
            string sql1 = "select a.mabn,a.maql,a1.maql maqlcls,to_char(a.ngay,'dd/mm/yyyy') ngay,a.ngay ngaygio,c.hoten,b.makp,b.tenkp,a.soluong,a2.ten"
                    + " from " + s_user + s_mmyy + ".v_chidinh a left join medibv.btdkp_bv b on a.makp=b.makp "
                    + " left join " + s_user + ".btdbn c on a.mabn=c.mabn "
                    + " left join " + s_user + s_mmyy + ".xn_phieu a1 on a1.maql=a.maql "
                    + " left join " + s_user + ".v_giavp a2 on a2.id=a.mavp "
                    + " inner join " + s_user + ".v_loaivp a21 on a21.id=a2.id_loai"
                    + " inner join " + s_user + ".v_nhomvp a22 on a22.ma=a21.id_nhom"
                    + " where a22.ma in(1)";
            sql1 += " union all ";
            sql1 += " select a.mabn,a.maql,a1.maql maqlcls,to_char(a.ngay,'dd/mm/yyyy') ngay,a.ngay ngaygio,c.hoten,b.makp,b.tenkp,a.soluong,a2.ten "
                + " from " + s_user + s_mmyy + ".v_chidinh a "
                + " left join " + s_user + ".btdkp_bv b on a.makp=b.makp "
                + " left join " + s_user + ".btdbn c on a.mabn=c.mabn "
                + " left join " + s_user + s_mmyy + ".cdha_bnll a1 on a.maql=a1.maql "
                + " left join " + s_user + ".v_giavp a2 on a2.id=a.mavp "
                + " inner join " + s_user + ".v_loaivp a21 on a21.id=a2.id_loai"
                + " inner join " + s_user + ".v_nhomvp a22 on a22.ma=a21.id_nhom"
                + " where a22.ma in(2)";
            sql += sql1 + ") where ngay='" + s_date + "' order by maql";
            DataTable dttam = libM.get_data(sql).Tables[0];
            DataTable dttam2 = libM.get_data("select distinct maql,mabn,hoten,makp,tenkp,ngay,0.0 slchidinh,0.0 sldathuchien"
            + " from (" + sql1 + ") where ngay='" + s_date + "' order by maql").Tables[0];

           
            foreach (DataRow r in dttam2.Rows)
            {
                
                foreach (DataRow r2 in dttam.Select("mabn='" + r["mabn"].ToString() + "' and maql="+r["maql"].ToString()
                    +" and makp='"+r["makp"].ToString()+"'"))
                {
                    r["slchidinh"] = int.Parse(r["slchidinh"].ToString().Split('.')[0]) + int.Parse(r2["soluong"].ToString().Split('.')[0]);
                    if(r2["maqlcls"].ToString()!="")
                        r["sldathuchien"] = int.Parse(r["sldathuchien"].ToString().Split('.')[0]) + 1;
                }
               
            }
            return dttam2;

        }
        public void HienThi(DataTable dttam)
        {
            try { timer1.Stop(); }
            catch { }

            pnl1.Controls.Clear();
            pnl2.Controls.Clear();
            pnl3.Controls.Clear();
            pnltieude.Controls.Clear();

            pnl1.Width = pnl2.Width = pnl3.Width = 0;
            pnl3.Height = 0;
            //string s1 = "", s2 = "", s3 = "";   
            Label lblhoten, lbltenpk, lbltinhtrang;
            int hei = 0, wei2 = 0,wei3=0;
            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Font = new Font("Arial", float.Parse(_ts.TieuDe_cochu.ToString()), FontStyle.Bold);
            label2.Location = new Point(0, 0);            
            this.Controls.Add(label2);
            label2.Text = "phòng khám   ".ToUpper();
            hei = label2.Height + 5;
            wei2 = label2.Width;
            label2.Text = "CLS ".ToUpper();            
            wei3 = label2.Width;
            label2.Font = new Font("Arial", float.Parse(_ts.DanhSach_cochu.ToString()), FontStyle.Bold);


            pnl1.BackColor = pnl2.BackColor = pnl3.BackColor = Color.FromArgb(_ts.DanhSach_maunen_red
                , _ts.DanhSach_maunen_green
                , _ts.DanhSach_maunen_blue);
            pnl1.ForeColor = pnl2.ForeColor = pnl3.ForeColor = Color.FromArgb(_ts.DanhSach_mauchu_red
                , _ts.DanhSach_mauchu_green
                , _ts.DanhSach_mauchu_blue);
            this.BackColor = pnl1.BackColor;

            for (int i = 0; i < dttam.Rows.Count; i++)
            {
                //label2.Text = dttam.Rows[i]["hoten"].ToString() + "   ";
                //if (pnl1.Width < label2.Width) pnl1.Width = label2.Width;
                //s1 += label2.Text + "/r/n";

                //label2.Text = dttam.Rows[i]["tenkp"].ToString() + "   ";
                //if (pnl2.Width < label2.Width) pnl2.Width = label2.Width;
                //s2 += label2.Text + "/r/n";

                //label2.Text = dttam.Rows[i]["slchidinh"].ToString() + "/" + dttam.Rows[i]["sldathuchien"].ToString();
                //if (pnl3.Width < label2.Width) pnl3.Width = label2.Width;
                //s3 += label2.Text + "/r/n";

                lblhoten = new Label();
                lblhoten.Text = dttam.Rows[i]["hoten"].ToString() + "   ";
                lblhoten.AutoSize = false;
                lblhoten.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                lblhoten.Height = hei;
                lblhoten.Font = label2.Font;
                lblhoten.Location = new Point(0, hei * i + 5);
                pnl1.Controls.Add(lblhoten);
                label2.Text = lblhoten.Text + "   ";
                if (pnl1.Width < label2.Width) pnl1.Width = label2.Width;
                lblhoten.Width = pnl1.Width;

                lbltenpk = new Label();
                lbltenpk.Text = dttam.Rows[i]["tenkp"].ToString() + "    ";
                lbltenpk.AutoSize = false;
                lbltenpk.Height = hei;
                lbltenpk.Font = label2.Font;
                lbltenpk.Location = new Point(0, hei * i + 5);
                pnl2.Controls.Add(lbltenpk);
                lbltenpk.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                label2.Text = lbltenpk.Text;
                if (pnl2.Width < label2.Width) pnl2.Width = label2.Width;
                lbltenpk.Width =(lbltenpk.Width>pnl2.Width)?wei2: pnl2.Width;

                lbltinhtrang = new Label();
                lbltinhtrang.Text = " "+dttam.Rows[i]["sldathuchien"].ToString().Split('.')[0] + "/" + dttam.Rows[i]["slchidinh"].ToString()+"  ";
                lbltinhtrang.AutoSize = false;
                lbltinhtrang.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                lbltinhtrang.Height = hei;
                lbltinhtrang.Font = label2.Font;
                lbltinhtrang.Location = new Point(0, hei * i + 5);
                pnl3.Controls.Add(lbltinhtrang);
                label2.Text = lbltinhtrang.Text;
                if (pnl3.Width < label2.Width) pnl3.Width = label2.Width;
                lbltinhtrang.Width = (lbltinhtrang.Width > pnl3.Width) ? wei3 : pnl3.Width;
                pnl3.Height = pnl3.Height + hei;

                lbltenpk.TextAlign =lblhoten.TextAlign=lbltinhtrang.TextAlign= ContentAlignment.MiddleLeft;
                lbltenpk = lblhoten = lbltinhtrang = null;

            }
            //pnl1.Text = s1;
            //pnl2.Text = s2;
            //pnl3.Text = s3;
            pnl3.Location = new Point(this.Width - pnl3.Width, this.Height);
            pnl2.Location = new Point(this.Width - pnl3.Width - pnl2.Width, this.Height);
            pnl1.Location = new Point(0, this.Height);
            pnl1.Width = this.Width - pnl2.Width - pnl3.Width;
            pnl1.Height = pnl2.Height = pnl3.Height;

            pnltieude.Width = this.Width;
            pnltieude.Height = 50;
            pnltieude.Location = new Point(0, 0);
            pnltieude.Font = new Font("Arial", float.Parse(_ts.TieuDe_cochu.ToString()), FontStyle.Bold);
            pnltieude.ForeColor = Color.FromArgb(int.Parse(_ts.TieuDe_mauchu_red.ToString())
                ,int.Parse(_ts.TieuDe_mauchu_green.ToString())
                ,int.Parse(_ts.TieuDe_mauchu_blue.ToString()));
            pnltieude.BackColor = Color.FromArgb(int.Parse(_ts.TieuDe_maunen_red.ToString())
                , int.Parse(_ts.TieuDe_maunen_green.ToString())
                , int.Parse(_ts.TieuDe_maunen_blue.ToString()));

            lblhoten = new Label();
            lblhoten.Text = "Họ và tên   ".ToUpper();
            lblhoten.Location = new Point(0, 0);
            lblhoten.TextAlign = ContentAlignment.MiddleLeft;
            lblhoten.MouseMove += new MouseEventHandler(pnl_MouseMove);

            lbltenpk = new Label();
            lbltenpk.Text = "Phòng khám  ".ToUpper();
            lbltenpk.Location = new Point(pnl2.Location.X, 0);
            lbltenpk.TextAlign = ContentAlignment.MiddleLeft;

            lbltinhtrang = new Label();
            lbltinhtrang.Text = "CLS ";
            lbltinhtrang.Location = new Point(pnl3.Location.X, 0);
            lbltinhtrang.TextAlign = ContentAlignment.MiddleLeft;

            lblhoten.AutoSize = lbltenpk.AutoSize = lbltinhtrang.AutoSize = false;
            lblhoten.Height = lbltenpk.Height = lbltinhtrang.Height = pnltieude.Height;
            lblhoten.Width = pnl1.Width;            
            lbltenpk.Width =(wei2>pnl2.Width)?wei2: pnl2.Width;
            lbltinhtrang.Width = pnl3.Width;

            pnltieude.Controls.Add(lblhoten);
            pnltieude.Controls.Add(lbltenpk);
            pnltieude.Controls.Add(lbltinhtrang);
            
            

            this.Controls.Remove(label2);
            _iX = this.Height-pnltieude.Height;
            timer1.Start();
            timer1.Interval = 10; 

        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            _iX -= 1;
            if ((_iX + pnl1.Height - pnltieude.Height) < 0)
            {
                HienThi(LoadData());
                _iX = this.Height - pnltieude.Height;
            }
            pnl1.Location = new Point(pnl1.Location.X, _iX);
            pnl2.Location = new Point(pnl2.Location.X, _iX);
            pnl3.Location = new Point(pnl3.Location.X, _iX);
        }

        private void frmManHinhLCD_Closed(object sender, FormClosedEventArgs e)
        {
            UpdateStateForm(1);
        }

    }
}