using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DirectX.Capture;
using System.Drawing.Imaging;
using System.IO;


namespace Medisoft
{
    public partial class frmChuphinh : Form
    {
        Capture capture = null;
        Filters filters=null;
        private float brightnessImage = 1.2f;
        bool capImg=false,bcohinh = false;
        string sql = "", s_mabn = "", nam = "", s_msg="",s_path="",thumuc="",FileType="jpg";
        decimal d_mavaovien = 0,mavaovienbandau=0;
        int i_userid = 0;
        LibMedi.AccessData m = new LibMedi.AccessData();
        DataTable dtchungtu = new DataTable();
        Language lan = new Language();
        

        public frmChuphinh(string _mabn)
        {
            InitializeComponent();
            s_mabn = _mabn;
            //d_mavaovien =mavaovienbandau= _mavaovien;
            //i_userid = _userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            
        }

        private void frmChuphinh_Load(object sender, EventArgs e)
        {
            try
            {
                FileType = m.FileType;
                filters = new Filters();
                s_msg = LibMedi.AccessData.Msg;
                load_menuDevice();
                capture = null;
                DataTable dthinh = new DataTable();

                Filter videoDevice = null;
                Filter audioDevice = null;

                videoDevice = filters.VideoInputDevices[0];
                audioDevice = filters.AudioInputDevices[0];
                capture = new Capture(videoDevice, audioDevice);
                capture.PreviewWindow = pictureBox2;


                //sql = "select nam from " + m.user + ".btdbn where mabn='" + s_mabn + "'";
                //DataSet lds = m.get_data(sql);
                //if (lds != null && lds.Tables.Count <= 0 && lds.Tables[0].Rows.Count > 0)
                //{
                //    nam = m.get_data(sql).Tables[0].Rows[0][0].ToString();
                //}
                //else nam = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2) + "+";
                //ena_obj(true);

                sql = "select ten from " + m.user + ".thongso where id=265";
                dthinh = m.get_data(sql).Tables[0];
                if (dthinh.Rows.Count == 0)
                {
                    thumuc = "";
                }
                else thumuc = dthinh.Rows[0][0].ToString();
                thumuc = thumuc.Trim('\\') + "\\";
                Bitmap bm = null;

                try
                {
                    //if (e.Node.Tag == null)
                    //{
                    //    pictureBox1.Image = null;
                    //    return;
                    //}
                    s_path = thumuc + s_mabn + "."+FileType;
                    if (!Directory.Exists("temp")) Directory.CreateDirectory("temp");
                    File.Copy(s_path, "temp\\" + s_mabn + "." + FileType, true);
                    bm = new Bitmap("temp\\" + s_mabn + "." + FileType);
                    pictureBox1.Image = bm;
                    //ena_obj(true);
                }
                catch (Exception exx)
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception exx) { }
        }

        
        /*
         * 
         * */

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image.Dispose();//  = null;
            }
            catch { }
                capImg = true;

                this.capture.FrameEvent2 += new DirectX.Capture.Capture.HeFrame(this.CaptureDone);
                this.capture.GrapImg();
            
        }

        private void CaptureDone(Bitmap GetBmp)
        {
            if (this.capImg)
            {
                Bitmap bmp = new Bitmap(this.AdjustImage(GetBmp, this.brightnessImage));
                //Bitmap bmp = new Bitmap(pictureBox2.Image);

                this.pictureBox1.Image = bmp;
                capImg = false;
            }
            return;
        }

        private Bitmap AdjustImage(Bitmap originalImage, float brightness)
        {
            Bitmap adjustedImage = new Bitmap(originalImage);
            float constrast = 1f;
            float gamma = 1f;
            float adjustedBrightness = brightness - 1f;
            float[][] CS0 = new float[5][];
            float[] CS1 = new float[5];
            CS1[0] = constrast;
            CS0[0] = CS1;
            float[] CS2 = new float[5];
            CS2[1] = constrast;
            CS0[1] = CS2;
            float[] CS3 = new float[5];
            CS3[2] = constrast;
            CS0[2] = CS3;
            float[] CS4 = new float[5];
            CS4[3] = 1f;
            CS0[3] = CS4;
            float[] CS5 = new float[5];
            CS5[0] = adjustedBrightness;
            CS5[1] = adjustedBrightness;
            CS5[2] = adjustedBrightness;
            CS5[4] = 1f;
            CS0[4] = CS5;
            float[][] ptsArray = CS0;
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics.FromImage(adjustedImage).DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imageAttributes);
            return adjustedImage;
        }

        private void frmChuphinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                capture.Dispose();
            }
            catch { }
        }
        void load_menuDevice()
        {
            DirectX.Capture.Filter f;
            int c;
            MenuItem m;
            if (this.capture != null)
            {
                this.capture.PreviewWindow = null;
            }
           

            Filter videoDevice = null;
            if (capture != null)
                videoDevice = capture.VideoDevice;
            mnuVideoDevices.MenuItems.Clear();
            m = new MenuItem("(None)", new EventHandler(mnuVideoDevices_Click));
            m.Checked = (videoDevice == null);
            mnuVideoDevices.MenuItems.Add(m);
            for ( c = 0; c < filters.VideoInputDevices.Count; c++)
            {
                f = filters.VideoInputDevices[c];
                m = new MenuItem(f.Name, new EventHandler(mnuVideoDevices_Click));
                m.Checked = (videoDevice == f);
                mnuVideoDevices.MenuItems.Add(m);
            }
            //mnuVideoDevices.Enabled = (filters.VideoInputDevices.Count > 0);

        }

        private void mnuVideoDevices_Click(object sender, EventArgs e)
        {
            try
            {
                //capture.Dispose();
                Filter videoDevice = null;
                Filter audioDevice = null;
                if (capture != null)
                {
                    videoDevice = capture.VideoDevice;
                    audioDevice = capture.AudioDevice;
                    capture.Dispose();
                    capture = null;
                }

                // Get new video device
                MenuItem m = sender as MenuItem;
                videoDevice = (m.Index > 0 ? filters.VideoInputDevices[m.Index - 1] : null);

                // Create capture object
                audioDevice = filters.AudioInputDevices[0];
                if (mnuVideoDevices.MenuItems[0].Checked)
                {
                    //capture.Stop();
                }
                if ((videoDevice != null) && (audioDevice != null))
                {
                    capture = new Capture(videoDevice, audioDevice);
                    capture.PreviewWindow = pictureBox2;
                    //capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                }

                // Update the menu
                //load_menuDevice();
                bool chon = false;

                for (int c = 0; c < filters.VideoInputDevices.Count; c++)
                {
                    if (filters.VideoInputDevices[c].Name == videoDevice.Name)
                    {
                        mnuVideoDevices.MenuItems[c+1].Checked = true;
                        chon = true;
                    }
                    else
                        mnuVideoDevices.MenuItems[c+1].Checked = false;
                }
                if(!chon)
                    mnuVideoDevices.MenuItems[0].Checked = true;
                else
                    mnuVideoDevices.MenuItems[0].Checked = false;
            }
            catch (Exception ex)
            {

                for (int i = 0; i < mnuVideoDevices.MenuItems.Count; i++)
                {
                    mnuVideoDevices.MenuItems[i].Checked = false;
                }
                mnuVideoDevices.MenuItems[0].Checked = true;
                //MessageBox.Show(lan.Change_language_MessageText("Video device not supported.\n\n" + ex.Message + "\n\n" + ex.ToString());
            }
        }

        private void chkXemtatca_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                //pictureBox1.Image = null;
                string path = "", name = s_mabn;
                path = thumuc + name + "." + FileType;
                //path = "temp\\" + s_mabn + "." + m.FileType;
                Bitmap b = (Bitmap)pictureBox1.Image;
                //System.Threading.Monitor.Enter(pictureBox1);
                //lock (File.Replace()
                //{
                //    lock (b)
                //    {
                //if (!Directory.Exists("temp")) Directory.CreateDirectory("temp");
                //b.Save("temp\\"+name+".jpg");
                //File.Copy("temp\\" + name + ".jpg", path,true);
                b.Save(path);
                MessageBox.Show(lan.Change_language_MessageText("Cập nhật Thành công !"), s_msg);
                bcohinh = true;
                this.Close();
                //    }
                //}


                //ena_obj(true);
            }
            catch (Exception exx)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không truy cập được thư mục hình ảnh!"), s_msg);
                return;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Bitmap bm = null ;
            //try
            //{
            //    pictureBox1.Dispose();
            //    bm.Dispose();
            //}
            //catch { }
            try
            {
                //string path = "";
                if (e.Node.Tag == null)
                {
                    pictureBox1.Image = null;
                    return;
                }
                s_path = e.Node.Tag.ToString();
                d_mavaovien = decimal.Parse(e.Node.Parent.Name);
                cmbLoaict.SelectedValue=e.Node.Name;
                //pictureBox1.Image = null;
                //File.Delete("image\\image.jpg");
                //if (!Directory.Exists("image"))
                //{
                //    Directory.CreateDirectory("image");
                //}
                //File.Copy(s_path, "image\\image.jpg",true);
                bm = new Bitmap(s_path);
                pictureBox1.Image = bm;
               // ena_obj(true);
            }
            catch (Exception exx){
                MessageBox.Show(lan.Change_language_MessageText("Không truy cập được thư mục hình ảnh!"), s_msg);
                return;
            }
            //pictureBox1.Image = new Bitmap(open.FileName);
        }

        private void butXoa_Click(object sender, EventArgs e)
        {

            try
            {
                //if (!m.execute_data("delete from " + m.user + ".hachungtu where mabn='" + s_mabn + "' and mavaovien=" + d_mavaovien + " and id_loaict=" + cmbLoaict.SelectedValue))
                //{
                //    MessageBox.Show(lan.Change_language_MessageText("Xóa không thành công!"), s_msg);
                //    return;
                //}
                //pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                lock(pictureBox1)
                File.Delete(s_path);
                
                //load_treeview();
            }
            catch (Exception exx) { }
         } 
        private void ena_obj(bool ena)
        {
            butThem.Enabled = ena;
            butChup.Enabled = !ena;
            butXoa.Enabled = ena;
            butLuu.Enabled = !ena;
            cmbLoaict.Enabled = !ena;
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            //ena_obj(false);
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
           // ena_obj(true);
        }
        public bool bCochuphinh
        {
            get { return bcohinh; }
        }
    }
}