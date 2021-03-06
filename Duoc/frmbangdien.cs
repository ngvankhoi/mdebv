using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Duoc
{
    public partial class frmbangdien : Form
    {
        int y;
        int sizefont, mauchu_dk_r, mauchu_dk_g, mauchu_dk_b, maunen_dk_r, maunen_dk_g, maunen_dk_b, vitri_x, vitri_y, kt_rong, kt_cao;
        int tocdo, height = 0, mauchu_r, mauchu_g, mauchu_b, maunen_r, maunen_g, maunen_b, sizefont_dk, banner_height = 0, i_domin = 1;
        DataSet dsthongso = new DataSet(), dsdanhsach = new DataSet();
        string s_dsbn = "", s_bndangkham = "", s_tieude = "";
        bool bManHinhCuon = false;
        Label lbltenbn = new Label();

        public frmbangdien()
        {
            InitializeComponent();
        }
        public frmbangdien(DataSet dscho,string bndangkham,string s_dangkham)
        {
            InitializeComponent();
            dsdanhsach = dscho;
            s_bndangkham = bndangkham;
            s_tieude = s_dangkham;
            lbltenbn = new Label();
            this.Controls.Add(lbltenbn);
            lbltenbn.Visible = false;
        }

        private void frmbangdien_Load(object sender, EventArgs e)
        {
            try { dsthongso.ReadXml("..\\..\\..\\xml\\thongsobangdien.xml", XmlReadMode.ReadSchema); }
            catch { MessageBox.Show("Chưa khai báo thông số bảng điện"); return; }
            f_loadthongso();
            f_loadform();
            label1.Font = label2.Font = label4.Font = new Font("Arial", sizefont_dk, FontStyle.Bold);
            label3.Font = new Font("Time New Roman", sizefont);
            label1.ForeColor = label2.ForeColor = label3.ForeColor = label4.ForeColor = Color.FromArgb(mauchu_dk_r, mauchu_dk_g, mauchu_dk_b);
            label1.BackColor = label2.BackColor = label3.BackColor = label4.BackColor = Color.FromArgb(maunen_dk_r, maunen_dk_g, maunen_dk_b);
            label2.Height = label1.Height;
            label2.Width = this.Width - label1.Width;
            label1.Location = new Point(0, p_tieude.Height);
            label2.Location = new Point(label1.Location.X + label1.Width, label1.Location.Y);
            //linh
            try
            {
                int i = 1;
                s_dsbn = "";
                foreach (DataRow r in dsdanhsach.Tables[0].Select("","stt"))
                {
                    s_dsbn += i.ToString() + ".          " + r["hoten"].ToString() + "\n";
                    i++;
                    //if (i == 5) break;
                }
            }
            catch { }
            int t1 = 0, t2 = 0;
            label4.Location = new Point(0, label1.Location.Y + label1.Height);
            label4.Text = ((s_tieude == "") ? " " : s_tieude.ToUpper()) + "   "; t1 = label4.Width; t2 = label4.Height; label4.AutoSize = false;
            label4.Width = t1; label4.Height = t2;
            lbltenbn.AutoSize = true;
            lbltenbn.Font = new Font("Time New Roman", sizefont, FontStyle.Bold);
            lbltenbn.BackColor = Color.FromArgb(maunen_dk_r, maunen_dk_g, maunen_dk_b);
            lbltenbn.ForeColor = Color.FromArgb(mauchu_dk_r, mauchu_dk_g, mauchu_dk_b);
            lbltenbn.Text = s_bndangkham; t1 = lbltenbn.Height; lbltenbn.AutoSize = false; lbltenbn.Height = t1; lbltenbn.Width = this.Width - label4.Width;
            label4.Height = lbltenbn.Height; lbltenbn.Visible = true;
            lbltenbn.Location = new Point(label4.Width, label2.Location.Y + label2.Height);
            if (bManHinhCuon)
            {
                label3.Location = new Point(0, this.Height);
            }
            else
            {
                label3.Location = new Point(0, p_tieude.Height + label1.Height+label4.Height);
            }
            y = label3.Location.Y;
            if (s_bndangkham == "") label4.Visible = lbltenbn.Visible = false;
            else
            {
                t1 = label1.Height;
                label1.AutoSize = false;
                label1.Height = t1; label1.Width = label4.Width;
                label2.Location = new Point(lbltenbn.Location.X, label1.Location.Y); label2.Text = "HỌ VÀ TÊN";
            }
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            dsthongso.Tables[0].Rows[0]["isload"] = "true";
            dsthongso.WriteXml("..\\..\\..\\xml\\thongsobangdien.xml", XmlWriteMode.WriteSchema);
            if (dsdanhsach.Tables[0].Rows.Count == 0 && s_bndangkham == "") this.Close();
            timer1.Interval = tocdo;
            timer1.Start();
        }

        private void f_loadform()
        {
            this.Location = new Point(vitri_x, vitri_y);
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Width = kt_rong; this.Height = kt_cao;
            this.BackColor = Color.FromArgb(maunen_r, maunen_g, maunen_b);
            p_tieude.Width = this.Width;
            p_tieude.Location = new Point(0, 0);
            p_tieude.Height = banner_height;
            try
            {
                if (dsthongso.Tables[0].Rows[0]["hinhnen"].ToString() == "1")
                {
                    try
                    {
                        byte[] by = new byte[0];
                        by = (byte[])dsthongso.Tables[0].Rows[0]["img_back"];
                        MemoryStream mem = new MemoryStream(by);
                        Bitmap bit = new Bitmap(Image.FromStream(mem));
                        this.BackgroundImage = (Bitmap)bit;
                    }
                    catch //(Exception ex)
                    {
                    }
                }
            }
            catch { }
            try
            {
                if (dsthongso.Tables[0].Rows[0]["logo2"].ToString() != "")
                {
                    try
                    {
                        byte[] by2 = new byte[0];
                        by2 = (byte[])dsthongso.Tables[0].Rows[0]["logo2"];
                        MemoryStream mem2 = new MemoryStream(by2);
                        Bitmap bit2 = new Bitmap(Image.FromStream(mem2));
                        pic_title.Image = (Bitmap)bit2;
                    }
                    catch //(Exception ex)
                    {
                    }
                }
            }
            catch { }
            this.BackgroundImageLayout = ImageLayout.Stretch;

           
        }
    
  
        private void f_loadthongso()
        {
            try
            {
                sizefont = int.Parse(dsthongso.Tables[0].Rows[0]["sizefont"].ToString());
                sizefont_dk = int.Parse(dsthongso.Tables[0].Rows[0]["sizefont_dk"].ToString());
                tocdo = int.Parse(dsthongso.Tables[0].Rows[0]["tocdo"].ToString());
                mauchu_dk_r = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_dk_r"].ToString());
                mauchu_dk_g = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_dk_g"].ToString());
                mauchu_dk_b = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_dk_b"].ToString());

                maunen_dk_r = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_dk_r"].ToString());
                maunen_dk_g = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_dk_g"].ToString());
                maunen_dk_b = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_dk_b"].ToString());

                mauchu_r = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_r"].ToString());
                mauchu_g = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_g"].ToString());
                mauchu_b = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_b"].ToString());

                maunen_r = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_r"].ToString());
                maunen_g = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_g"].ToString());
                maunen_b = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_b"].ToString());

                vitri_x = int.Parse(dsthongso.Tables[0].Rows[0]["vitri_x"].ToString());
                vitri_y = int.Parse(dsthongso.Tables[0].Rows[0]["vitri_y"].ToString());

                kt_rong = int.Parse(dsthongso.Tables[0].Rows[0]["kt_rong"].ToString());
                kt_cao = int.Parse(dsthongso.Tables[0].Rows[0]["kt_cao"].ToString());
                banner_height = int.Parse(dsthongso.Tables[0].Rows[0]["logo2_height"].ToString());
                i_domin = int.Parse(dsthongso.Tables[0].Rows[0]["domin"].ToString());
                bManHinhCuon = dsthongso.Tables[0].Rows[0]["manhinhcuon"].ToString() == "1";
            }
            catch { this.Close(); }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = s_dsbn;
            if (bManHinhCuon)
            {
                y -= i_domin;
                int he = (s_bndangkham == "") ? label1.Height + label1.Location.Y : label4.Height + label4.Location.Y;
                if ((label3.Location.Y + label3.Height) <= he)
                { y = this.Height; label3.Location = new Point(0, y); }
                label3.Height = height;
                label3.AutoSize = true;
                label3.Location = new Point(0, y);
            }
            this.Invalidate();
        }

        private void frmbangdien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { dsthongso.Tables[0].Rows[0]["isload"] = "false"; dsthongso.WriteXml("..\\..\\..\\xml\\thongsobangdien.xml", XmlWriteMode.WriteSchema); this.Close(); }
        }
        public void refect(DataSet ds, string bndangkham)
        {
            if (ds.Tables[0].Rows.Count == 0 && bndangkham == "") this.Close();
            s_bndangkham = bndangkham;
            dsdanhsach = ds;
            s_dsbn = "";
            try
            {
                int i = 1;
                foreach (DataRow r in dsdanhsach.Tables[0].Select("", "stt"))
                {
                    s_dsbn += i.ToString() + ".          " + r["hoten"].ToString() + "\n";
                    i++;
                    //if (i == 5) break;
                }
            }

            catch { }
            label4.AutoSize = true;
            label4.Text = s_tieude.ToUpper() + "     ";
            int t = label4.Width;
            label4.AutoSize = false; label4.Width = t;

            lbltenbn.AutoSize = true; lbltenbn.Text = s_bndangkham; lbltenbn.Location = new Point(label4.Width, label2.Location.Y + label2.Height); t = lbltenbn.Height;
            lbltenbn.AutoSize = false; label4.Height = lbltenbn.Height = t; lbltenbn.Width = this.Width - label4.Width;
            if (s_bndangkham == "") label4.Visible = lbltenbn.Visible = false;
            else
            {
                label4.Visible = lbltenbn.Visible = true;
                t = label1.Height;
                label1.AutoSize = false;
                label1.Height = t; label1.Width = label4.Width; label2.Location = new Point(lbltenbn.Location.X, label1.Location.Y); label2.Text = "HỌ VÀ TÊN";
            }
            timer1_Tick(null, null);
        }

        private void frmbangdien_FormClosing(object sender, FormClosingEventArgs e)
        {
            dsthongso.Tables[0].Rows[0]["isload"] = "false";
            dsthongso.WriteXml("..\\..\\..\\xml\\thongsobangdien.xml", XmlWriteMode.WriteSchema);
            timer1.Stop();
        }

        private void frmbangdien_Paint(object sender, PaintEventArgs e)
        {
            Font f = new Font("Arial", Math.Max(1, sizefont), FontStyle.Bold);
            Color c = new Color();
            c = Color.FromArgb(mauchu_r, mauchu_g, mauchu_b);
            SolidBrush br;
            br = new SolidBrush(c);
            e.Graphics.DrawString(s_dsbn, f, (Brush)br, 0, y);
            
        }
    }
}