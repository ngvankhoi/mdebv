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
    public partial class frmChuphinhchungtu : Form
    {
        Capture capture = null;
        Filters filters=null;
        private float brightnessImage = 1.2f;
        bool capImg=false;
        string sql = "", s_mabn = "", nam = "", s_msg="",s_path="",thumuc="";
        decimal d_mavaovien = 0,mavaovienbandau=0;
        int i_userid = 0;
        LibMedi.AccessData m = new LibMedi.AccessData();
        DataTable dtchungtu = new DataTable();
        Language lan = new Language();

        public frmChuphinhchungtu(string _mabn, decimal _mavaovien,int _userid)
        {
            InitializeComponent();
            s_mabn = _mabn;
            d_mavaovien =mavaovienbandau= _mavaovien;
            i_userid = _userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            
        }

        private void frmChuphinhchungtu_Load(object sender, EventArgs e)
        {
            
            filters = new Filters();
            s_msg = LibMedi.AccessData.Msg;
            load_menuDevice();
            capture = null;
            DataTable dthinh = new DataTable();
            
            Filter videoDevice=null;
            Filter audioDevice=null;

            videoDevice = filters.VideoInputDevices[0];
            audioDevice = filters.AudioInputDevices[0];
            capture = new Capture(videoDevice, audioDevice);
            capture.PreviewWindow = pictureBox2;

            sql = "select * from "+m.user+".dmloaict order by id";
            dtchungtu = m.get_data(sql).Tables[0];
            cmbLoaict.DataSource = dtchungtu;
            cmbLoaict.DisplayMember = "ten";
            cmbLoaict.ValueMember = "id";

            sql = "select nam from " + m.user + ".btdbn where mabn='"+s_mabn+"'";
            nam = m.get_data(sql).Tables[0].Rows[0][0].ToString();
            load_treeview();
            ena_obj(true);

            sql="select ten from "+m.user+".thongso where id=1085";
            dthinh = m.get_data(sql).Tables[0];
            if (dthinh.Rows.Count == 0)
            {
                thumuc = "";
            }
            else thumuc = dthinh.Rows[0][0].ToString();
            if (thumuc.Trim() != "")
            {
                if (thumuc.Substring(0, 1) != "\\")
                {
                    thumuc = thumuc.Trim().Trim('\\') + "\\";
                }
                else
                    thumuc = "\\\\" + thumuc.Trim().Trim('\\') + "\\";
            }
            //sql = "select * from " + m.user + ".hachungtu b," + m.user + ".dmloaict a where a.id=b.id_loaict";
        }

        private void load_treeview()
        {
            treeView1.Nodes.Clear();
            DataTable dttam = new DataTable();
            TreeNode node;
            try
            {
                sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.ten,c.id,a.mavaovien,to_char(a.ngay,'yyyymmddhh24mi') as yymmdd,b.duongdan from xxx.tiepdon a," + m.user + ".hachungtu b," + m.user + ".dmloaict c where a.mavaovien=b.mavaovien and b.id_loaict=c.id and a.mabn='" + s_mabn + "'" + " and a.noitiepdon=0 ";
                if (!chkXemtatca.Checked)
                {
                    sql += " and a.mavaovien="+d_mavaovien;
                }
                //foreach (DataRow r in m.get_data_nam(nam, sql).Tables[0].Select("true", "yymmdd desc"))
                //{
                //    node = treeView1.Nodes.Add(r["ngay"].ToString());
                //    node.Nodes.Add(r["ten"].ToString());
                //}

                TreeNode nodenhom = new TreeNode();
                TreeNode nodeloai = new TreeNode();
                string nhom = "";
                dttam = m.get_data_nam(nam, sql).Tables[0];
                foreach (DataRow r1 in dttam.Select("true", "yymmdd desc"))
                {
                    if (nhom != r1["ngay"].ToString())
                    {
                        nhom = r1["ngay"].ToString();
                        nodenhom = treeView1.Nodes.Add(r1["mavaovien"].ToString(), m.getrowbyid(dttam, "ngay='" + nhom+"'")["ngay"].ToString());
                    }

                    nodeloai = nodenhom.Nodes.Add(r1["id"].ToString(), r1["ten"].ToString());
                    nodeloai.Tag = r1["duongdan"].ToString().Trim() ;
                }
                treeView1.ExpandAll();
            }
            catch (Exception exx){ }
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

        private void frmChuphinhchungtu_FormClosing(object sender, FormClosingEventArgs e)
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
            if (!chkXemtatca.Checked)
            {
                d_mavaovien = mavaovienbandau;
            }
            load_treeview();
            
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "", name = s_mabn + "_" + d_mavaovien + "_" + cmbLoaict.SelectedValue;
                path = thumuc + name + ".jpg";
                Bitmap b = (Bitmap)pictureBox1.Image;
                //if (File.Exists(path))
                //{
                //    pictureBox1.Image=pictureBox1.ErrorImage;
                //    File.Delete(path);
                //}
                lock (pictureBox1)
                {
                    b.Save(path);
                }
                if (!m.upd_hachungtu(s_mabn, d_mavaovien, int.Parse(cmbLoaict.SelectedValue.ToString()), name+".jpg", i_userid))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được hình ảnh chứng từ !"), s_msg);
                    return;
                }

                ena_obj(true);
                load_treeview();
            }
            catch (Exception exx){
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
                s_path = thumuc+e.Node.Tag.ToString();
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
                ena_obj(true);
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
                if (!m.execute_data("delete from " + m.user + ".hachungtu where mabn='" + s_mabn + "' and mavaovien=" + d_mavaovien + " and id_loaict=" + cmbLoaict.SelectedValue))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Xóa không thành công!"), s_msg);
                    return;
                }
                //pictureBox1.Image.Dispose();
                File.Delete(s_path);
                load_treeview();
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
            ena_obj(false);
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ena_obj(true);
        }
    }
}