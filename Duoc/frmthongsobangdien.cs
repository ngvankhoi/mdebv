using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Duoc
{
    public partial class frmthongsobangdien : DevExpress.XtraEditors.XtraForm
    {
        public frmthongsobangdien()
        {
            InitializeComponent();
            p_hinhnen = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
            hn_h = pictureBox1.Height; hn_w = pictureBox1.Width;
        }
        DataSet dsthongso=new DataSet();
        DataRow dr;
        byte[] image,image2;
        int img_h, img_w;
        Point p_hinhnen;
        int hn_w, hn_h;
        private void frmthongsobangdien_Load(object sender, EventArgs e)
        {
            f_loadthongso();
            mauchu_r_ValueChanged(null, null);
            maunen_r_ValueChanged(null, null);
            mauchu_dk_r_ValueChanged(null, null);
            maunen_dk_r_ValueChanged(null, null);
           
        }
        private void f_loadthongso()
        {
            try
            {
                dsthongso.ReadXml("..\\..\\..\\xml\\thongsobangdien.xml",XmlReadMode.ReadSchema);
                try { dsthongso.Tables[0].Columns.Add("manhinhcuon", typeof(int)).DefaultValue = 0; }
                catch{}
                try { dsthongso.Tables[0].Columns.Add("KhongLoadDSCLS", typeof(int)).DefaultValue = 0; }
                catch { }
                sizefont.Value = int.Parse(dsthongso.Tables[0].Rows[0]["sizefont"].ToString());
                sizefont_dk.Value = int.Parse(dsthongso.Tables[0].Rows[0]["sizefont_dk"].ToString());
                tocdo.Value = int.Parse(dsthongso.Tables[0].Rows[0]["tocdo"].ToString());
                mauchu_r.Value = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_r"].ToString());               
                mauchu_g.Value = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_g"].ToString());               
                mauchu_b.Value = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_b"].ToString());

                maunen_r.Value = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_r"].ToString());
                maunen_g.Value = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_g"].ToString());
                maunen_b.Value = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_b"].ToString());

                mauchu_dk_r.Value = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_dk_r"].ToString());
                mauchu_dk_g.Value = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_dk_g"].ToString());
                mauchu_dk_b.Value = int.Parse(dsthongso.Tables[0].Rows[0]["mauchu_dk_b"].ToString());

                maunen_dk_r.Value = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_dk_r"].ToString());
                maunen_dk_g.Value = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_dk_g"].ToString());
                maunen_dk_b.Value = int.Parse(dsthongso.Tables[0].Rows[0]["maunen_dk_b"].ToString());

                vitri_x.Value = int.Parse(dsthongso.Tables[0].Rows[0]["vitri_x"].ToString());
                vitri_y.Value = int.Parse(dsthongso.Tables[0].Rows[0]["vitri_y"].ToString());

                kt_rong.Value = int.Parse(dsthongso.Tables[0].Rows[0]["kt_rong"].ToString());
                kt_cao.Value = int.Parse(dsthongso.Tables[0].Rows[0]["kt_cao"].ToString());
                cbo_port.SelectedText = dsthongso.Tables[0].Rows[0]["port"].ToString();
                string tam = dsthongso.Tables[0].Rows[0]["config"].ToString();
                string[] t1 = tam.Split(',');
                cbo_port.SelectedItem = t1[0];
                cbo_baud.SelectedItem = t1[1];
                cbo_parity.SelectedItem = t1[2];
                cbo_stopbit.SelectedItem = t1[3];
                cbo_databit.SelectedItem = t1[4];
                if (dsthongso.Tables[0].Rows[0]["img_back"].ToString() != "")
                {
                    image = new byte[0];
                    image = (byte[])dsthongso.Tables[0].Rows[0]["img_back"];
                    try
                    {
                        MemoryStream mem = new MemoryStream(image);
                        Bitmap bt = new Bitmap(Image.FromStream(mem));
                        pictureBox1.Image = (Bitmap)bt;
                    }
                    catch { }
                }
                t1 = dsthongso.Tables[0].Rows[0]["img_size"].ToString().Split('x');
                img_h = int.Parse(t1[1]); img_w = int.Parse(t1[0]);
                chk_hinhnen.Checked = (dsthongso.Tables[0].Rows[0]["hinhnen"].ToString() == "1") ? true : false;
                if (dsthongso.Tables[0].Rows[0]["logo2"].ToString() != "")
                {
                    image2 = new byte[0];
                    image2 = (byte[])dsthongso.Tables[0].Rows[0]["logo2"];
                    try
                    {
                        MemoryStream mem2 = new MemoryStream(image2);
                        Bitmap bt2 = new Bitmap(Image.FromStream(mem2));
                        pic_logo.Image = (Bitmap)bt2;
                    }
                    catch { }
                }
                num_cao.Value = int.Parse(dsthongso.Tables[0].Rows[0]["logo2_height"].ToString());
                try
                {
                    num_domin.Value = int.Parse(dsthongso.Tables[0].Rows[0]["domin"].ToString());
                }
                catch { dsthongso.Tables[0].Columns.Add("domin"); dsthongso.Tables[0].Rows[0]["domin"] = num_domin.Value; }
                chkManHinhCuon.Checked = dsthongso.Tables[0].Rows[0]["manhinhcuon"].ToString() == "1";
                chkKhongLoadDSdiCLS.Checked = dsthongso.Tables[0].Rows[0]["KhongLoadDSCLS"].ToString() == "1";
            }
            catch //(Exception ex)
            {
                dsthongso = new DataSet();
                dsthongso.Tables.Add("thongso");               
                dr = dsthongso.Tables[0].NewRow();
                dsthongso.Tables[0].Rows.Add(dr);
                dsthongso.Tables[0].Columns.Add("sizefont", typeof(int)).DefaultValue = 1;
                dsthongso.Tables[0].Columns.Add("sizefont_dk", typeof(int)).DefaultValue = 1;
                dsthongso.Tables[0].Columns.Add("tocdo", typeof(int)).DefaultValue = 1;
                dsthongso.Tables[0].Columns.Add("domin", typeof(int)).DefaultValue = 1;
                dsthongso.Tables[0].Columns.Add("mauchu_r", typeof(int)).DefaultValue = 0;
                dsthongso.Tables[0].Columns.Add("mauchu_g", typeof(int)).DefaultValue = 0;
                dsthongso.Tables[0].Columns.Add("mauchu_b", typeof(int)).DefaultValue = 0;

                dsthongso.Tables[0].Columns.Add("maunen_r", typeof(int)).DefaultValue = 246;
                dsthongso.Tables[0].Columns.Add("maunen_g", typeof(int)).DefaultValue = 246;
                dsthongso.Tables[0].Columns.Add("maunen_b", typeof(int)).DefaultValue = 246;

                dsthongso.Tables[0].Columns.Add("mauchu_dk_r", typeof(int)).DefaultValue = 0;
                dsthongso.Tables[0].Columns.Add("mauchu_dk_g", typeof(int)).DefaultValue = 0;
                dsthongso.Tables[0].Columns.Add("mauchu_dk_b", typeof(int)).DefaultValue = 0;

                dsthongso.Tables[0].Columns.Add("maunen_dk_r", typeof(int)).DefaultValue = 246;
                dsthongso.Tables[0].Columns.Add("maunen_dk_g", typeof(int)).DefaultValue = 246;
                dsthongso.Tables[0].Columns.Add("maunen_dk_b", typeof(int)).DefaultValue = 246;

                dsthongso.Tables[0].Columns.Add("vitri_x", typeof(int)).DefaultValue = 0;
                dsthongso.Tables[0].Columns.Add("vitri_y", typeof(int)).DefaultValue = 0;

                dsthongso.Tables[0].Columns.Add("kt_rong", typeof(int)).DefaultValue = Screen.PrimaryScreen.WorkingArea.Width;
                dsthongso.Tables[0].Columns.Add("kt_cao", typeof(int)).DefaultValue = Screen.PrimaryScreen.WorkingArea.Height;

                dsthongso.Tables[0].Columns.Add("port", typeof(int)).DefaultValue = 3;
                dsthongso.Tables[0].Columns.Add("config", typeof(string)).DefaultValue = "3,9600,None,1,8";
                dsthongso.Tables[0].Columns.Add("isload", typeof(string)).DefaultValue = "False";
                dsthongso.Tables[0].Columns.Add("img_back",typeof(byte[]));
                dsthongso.Tables[0].Columns.Add("img_size");
                dsthongso.Tables[0].Columns.Add("hinhnen");
                dsthongso.Tables[0].Columns.Add("logo2",typeof(byte[]));
                dsthongso.Tables[0].Columns.Add("logo2_height");
                dsthongso.Tables[0].Columns.Add("ngayud_banner");
                dsthongso.Tables[0].Columns.Add("manhinhcuon", typeof(int)).DefaultValue = 0;
                dsthongso.Tables[0].Columns.Add("KhongLoadDSCLS", typeof(int)).DefaultValue = 0; 
                dsthongso.WriteXml("..//..//..//xml//thongsobangdien.xml",XmlWriteMode.WriteSchema);
            }
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            dsthongso.Tables[0].Rows[0]["sizefont"] = sizefont.Value;
            dsthongso.Tables[0].Rows[0]["sizefont_dk"] = sizefont_dk.Value;
            dsthongso.Tables[0].Rows[0]["tocdo"] = tocdo.Value;
            dsthongso.Tables[0].Rows[0]["mauchu_r"] = mauchu_r.Value;
            dsthongso.Tables[0].Rows[0]["mauchu_g"] = mauchu_g.Value;
            dsthongso.Tables[0].Rows[0]["mauchu_b"] = mauchu_b.Value;

            dsthongso.Tables[0].Rows[0]["maunen_r"] = maunen_r.Value;
            dsthongso.Tables[0].Rows[0]["maunen_g"] = maunen_g.Value;
            dsthongso.Tables[0].Rows[0]["maunen_b"] = maunen_b.Value;

            dsthongso.Tables[0].Rows[0]["mauchu_dk_r"] = mauchu_dk_r.Value;
            dsthongso.Tables[0].Rows[0]["mauchu_dk_g"] = mauchu_dk_g.Value;
            dsthongso.Tables[0].Rows[0]["mauchu_dk_b"] = mauchu_dk_b.Value;

            dsthongso.Tables[0].Rows[0]["maunen_dk_r"] = maunen_dk_r.Value;
            dsthongso.Tables[0].Rows[0]["maunen_dk_g"] = maunen_dk_g.Value;
            dsthongso.Tables[0].Rows[0]["maunen_dk_b"] = maunen_dk_b.Value;

            dsthongso.Tables[0].Rows[0]["vitri_x"] = vitri_x.Value; ;
            dsthongso.Tables[0].Rows[0]["vitri_y"] = vitri_y.Value; ;

            dsthongso.Tables[0].Rows[0]["kt_rong"] = kt_rong.Value;
            dsthongso.Tables[0].Rows[0]["kt_cao"] = kt_cao.Value;
            dsthongso.Tables[0].Rows[0]["port"] = cbo_port.Text;
            dsthongso.Tables[0].Rows[0]["isload"] = "false";
            dsthongso.Tables[0].Rows[0]["img_back"] = image;
            dsthongso.Tables[0].Rows[0]["logo2"] = image2;
            dsthongso.Tables[0].Rows[0]["img_size"] = img_w.ToString() + "x" + img_h.ToString();
            if (chk_hinhnen.Checked) dsthongso.Tables[0].Rows[0]["hinhnen"] = 1;
            else dsthongso.Tables[0].Rows[0]["hinhnen"] = 0;
            dsthongso.Tables[0].Rows[0]["config"] =cbo_port.Text+","+ cbo_baud.Text + "," + cbo_parity.Text.ToString() + "," + cbo_stopbit.Text.ToString() + "," + cbo_databit.Text;
            dsthongso.Tables[0].Rows[0]["logo2_height"] = num_cao.Value;
            dsthongso.Tables[0].Rows[0]["domin"] = num_domin.Value;
            dsthongso.Tables[0].Rows[0]["KhongLoadDSCLS"] = chkKhongLoadDSdiCLS.Checked ? "1" : "0";
            dsthongso.Tables[0].Rows[0]["manhinhcuon"] = chkManHinhCuon.Checked ? "1" : "0";
            if (!Directory.Exists("..\\..\\..\\xml")) Directory.CreateDirectory("..\\..\\..\\xml");
            dsthongso.WriteXml("..\\..\\..\\xml\\thongsobangdien.xml", XmlWriteMode.WriteSchema);
        }

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mauchu_r_ValueChanged(object sender, EventArgs e)
        {
            lbl_mauchu.ForeColor =lbl_maunen.ForeColor= Color.FromArgb(mauchu_r.Value, mauchu_g.Value, mauchu_b.Value);
        }

        private void maunen_r_ValueChanged(object sender, EventArgs e)
        {
            lbl_mauchu.BackColor = lbl_maunen.BackColor = Color.FromArgb(maunen_r.Value, maunen_g.Value, maunen_b.Value);
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Width>170)
            pictureBox1_DoubleClick(null, null);
            OpenFileDialog fd = new OpenFileDialog();
            fd.RestoreDirectory = true;
            fd.Filter = "All files (*.*)|*.*|*.bmp|*.bmp|*.jpg|*.jpg|*.gif|*.gif";
           DialogResult re= fd.ShowDialog();
           if (re == DialogResult.OK && fd.FileName.Length > 0)
           {
               Bitmap b = new Bitmap(fd.FileName.ToString());
               b.Tag = fd.FileName.ToString();
               pictureBox1.Image =(Bitmap) b;
               img_w = b.Width; img_h = b.Height;
               FileStream frst = new FileStream(fd.FileName, FileMode.Open, FileAccess.Read);
               image = new byte[frst.Length];
               frst.Read(image, 0,System.Convert.ToInt32(frst.Length));
               frst.Close();
           }
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            pic_logo.Image = null;            
        }

        private void chk_hinhnen_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void logo2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.RestoreDirectory = true;
            fd.Filter = "All files (*.*)|*.*|*.bmp|*.bmp|*.jpg|*.jpg|*.gif|*.gif";
            DialogResult re = fd.ShowDialog();
            if (re == DialogResult.OK && fd.FileName.Length > 0)
            {
                Bitmap b = new Bitmap(fd.FileName.ToString());
                b.Tag = fd.FileName.ToString();
                pic_logo.Image = (Bitmap)b;
                img_w = b.Width; img_h = b.Height;
                FileStream frst = new FileStream(fd.FileName, FileMode.Open, FileAccess.Read);
                image2 = new byte[frst.Length];
                frst.Read(image2, 0, System.Convert.ToInt32(frst.Length));
                frst.Close();
                try
                {
                    string s = dsthongso.Tables[0].Rows[0]["ngayud_banner"].ToString();
                }
                catch {dsthongso.Tables[0].Columns.Add("ngayud_banner"); }
                dsthongso.Tables[0].Rows[0]["ngayud_banner"]=  DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            }
        }

        private void mauchu_dk_r_ValueChanged(object sender, EventArgs e)
        {
            lblmauchu_dk.ForeColor = lblmaunen_dk.ForeColor = Color.FromArgb(mauchu_dk_r.Value, mauchu_dk_g.Value, mauchu_dk_b.Value);
        }

        private void maunen_dk_r_ValueChanged(object sender, EventArgs e)
        {
            lblmauchu_dk.BackColor = lblmaunen_dk.BackColor = Color.FromArgb(maunen_dk_r.Value, maunen_dk_g.Value, maunen_dk_b.Value);
        }

        private void butdefault_Click(object sender, EventArgs e)
        {
            sizefont.Value = 45;
            sizefont_dk.Value = 1;
            tocdo.Value = 1;
            mauchu_r.Value = 246;
            mauchu_g.Value = 246;
            mauchu_b.Value = 246;

            maunen_r.Value = 0;
            maunen_g.Value = 0;
            maunen_b.Value = 0;

            mauchu_dk_r.Value = 246;
            mauchu_dk_g.Value = 246;
            mauchu_dk_b.Value = 246;

            maunen_dk_r.Value = 0;
            maunen_dk_g.Value = 0;
            maunen_dk_b.Value = 0;

            vitri_x.Value = 0;
            vitri_y.Value = 0;

            int kt_r = Screen.PrimaryScreen.WorkingArea.Width;
            int kt_c = Screen.PrimaryScreen.WorkingArea.Height;
            kt_rong.Value = (decimal)kt_r;
            kt_cao.Value = (decimal)kt_c;
            cbo_port.SelectedIndex = 2;
            cbo_baud.SelectedIndex = 5;
            cbo_parity.SelectedIndex = 0;
            cbo_stopbit.SelectedIndex = 0;
            cbo_databit.SelectedIndex = 0;
        }

        private void pic_logo_DoubleClick(object sender, EventArgs e)
        {
            pic_logo.Image = null;
        }
    }
}