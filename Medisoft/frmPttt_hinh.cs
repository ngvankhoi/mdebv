using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
using Paint;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmPttt_hinh.
	/// </summary>
	public class frmPttt_hinh : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m;
		private decimal l_id;
		private string filebmp="pttt.bmp",ngay,xxx;
		private string f1="",f2="",thumucpic,s_mamau;
		private System.Windows.Forms.PictureBox pic1;
		private System.Windows.Forms.PictureBox pic2;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.ToolTip toolTip1;
		private DataTable dtmau=new DataTable();
		private byte[] image,image1,image2;
		private System.IO.MemoryStream memo;
		private System.IO.FileStream fstr;
		private Bitmap map;
		private System.ComponentModel.IContainer components;

		public frmPttt_hinh(AccessData acc,string _ngay,decimal _id,DataTable _dtmau,string _mamau)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 
            ngay = _ngay; m = acc; l_id = _id; dtmau = _dtmau; s_mamau = _mamau;
            if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPttt_hinh));
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            this.SuspendLayout();
            // 
            // pic1
            // 
            this.pic1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pic1.Location = new System.Drawing.Point(0, 1);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(361, 318);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 49;
            this.pic1.TabStop = false;
            this.toolTip1.SetToolTip(this.pic1, "Chỉnh sửa hình Double Click");
            this.pic1.DoubleClick += new System.EventHandler(this.pic1_DoubleClick);
            // 
            // pic2
            // 
            this.pic2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pic2.Location = new System.Drawing.Point(364, 1);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(361, 318);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 50;
            this.pic2.TabStop = false;
            this.toolTip1.SetToolTip(this.pic2, "Chỉnh sửa hình Double Click");
            this.pic2.DoubleClick += new System.EventHandler(this.pic2_DoubleClick);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(303, 330);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 0;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(373, 330);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 1;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // frmPttt_hinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(726, 364);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPttt_hinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hình phẫu thủ thuật";
            this.Load += new System.EventHandler(this.frmPttt_hinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmPttt_hinh_Load(object sender, System.EventArgs e)
		{
            xxx = m.user + m.mmyy(ngay);
			thumucpic="..//..//..//picture_pt";
			if (!Directory.Exists("..//pict_pt")) Directory.CreateDirectory("..//pict_pt");
			if (!Directory.Exists(thumucpic)) Directory.CreateDirectory(thumucpic);
			else
			{
				try
				{
					string [] files=Directory.GetFiles(thumucpic);
					for(int i=0;i<files.GetLength(0);i++) File.Delete(files[i].ToString());
				}
				catch{}
			}
			get_file(0);
			DataTable tmp=m.get_data("select * from "+xxx+".pttt_hinh where id="+l_id).Tables[0];
			if (tmp.Rows.Count==0)
			{
				DataRow r1=m.getrowbyid(dtmau,"ma='"+s_mamau+"'");
				if (r1!=null)
				{
					try
					{
						image1 =new byte[0];
						image1 =(byte[])(r1["image1"]);
						memo=new MemoryStream(image1);
						map=new Bitmap(Image.FromStream(memo));
						pic1.Image=(Bitmap)map;
						pic1.Tag=image1;
						map.Save(f1);
					}
					catch{load_pic1();}
					try
					{
						image2 =new byte[0];
						image2 =(byte[])(r1["image2"]);
						memo=new MemoryStream(image2);
						map=new Bitmap(Image.FromStream(memo));
						pic2.Image=(Bitmap)map;
						pic2.Tag=image2;
						map.Save(f2);
					}
					catch{load_pic2();}
				}				
				else
				{
					load_pic1();
					load_pic2();
				}
			}
			else
			{
				image1 =new byte[0];
				image1 =(byte[])(tmp.Rows[0]["image1"]);
				memo=new MemoryStream(image1);
				map=new Bitmap(Image.FromStream(memo));
				pic1.Image=(Bitmap)map;
				pic1.Tag=image1;
				map.Save(f1);

				image2 =new byte[0];
				image2 =(byte[])(tmp.Rows[0]["image2"]);
				memo=new MemoryStream(image2);
				map=new Bitmap(Image.FromStream(memo));
				pic2.Image=(Bitmap)map;
				pic2.Tag=image2;
				map.Save(f2);
			}
		}

		private void load_pic1()
		{
			pic1.Tag=filebmp;
			fstr=new System.IO.FileStream(pic1.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic1.Image=(Bitmap)map;
			image1=new byte[fstr.Length];
			fstr.Read(image1,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic1.Tag=image1;
			System.IO.File.Copy(filebmp,f1,true);
		}

		private void load_pic2()
		{
			pic2.Tag=filebmp;
			fstr=new System.IO.FileStream(pic2.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic2.Image=(Bitmap)map;
			image2=new byte[fstr.Length];
			fstr.Read(image2,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic2.Tag=image2;
			System.IO.File.Copy(filebmp,f2,true);
		}

		private void edit_pic(PictureBox pic,int i)
		{
			string sDir=System.Environment.CurrentDirectory.ToString(),tenfile="..//pict_pt//"+pic.Name.ToString()+".bmp";
			if (File.Exists((i==1)?f1:f2))
			{
				frmPaint f=new frmPaint((i==1)?f1:f2);
				f.ShowDialog(this);
				f.Save_image(tenfile);
				fstr=new System.IO.FileStream(tenfile,System.IO.FileMode.Open,System.IO.FileAccess.Read);
				image=new byte[fstr.Length];
				fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
				pic.Tag=image;
				map=new Bitmap(Image.FromStream(fstr));
				pic.Image=(Bitmap)map;
				pic.Update();
				fstr.Close();
				get_file(i);
				File.Copy(tenfile,(i==1)?f1:f2,true);
			}
			System.Environment.CurrentDirectory=sDir;
		}

		private void get_file(int i)
		{
			if (i==0)
			{
				f1=thumucpic+"//1"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
				f2=thumucpic+"//2"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
			}
			else if (i==1) f1=thumucpic+"//1"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
			else f2=thumucpic+"//2"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			m.upd_pttt_hinh(ngay,l_id,(byte[])(pic1.Tag),(byte[])(pic2.Tag));
			m.close();this.Close();
		}

		private void pic1_DoubleClick(object sender, System.EventArgs e)
		{
			edit_pic(pic1,1);
		}

		private void pic2_DoubleClick(object sender, System.EventArgs e)
		{
			edit_pic(pic2,2);
		}
	}
}
