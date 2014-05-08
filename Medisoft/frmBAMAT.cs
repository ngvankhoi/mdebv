using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Paint;
using LibMedi;

namespace Medisoft
{
	public class frmBAMAT : System.Windows.Forms.Form
    {
        #region Khai bao
        private Language lan = new Language();
        private System.Windows.Forms.PictureBox pic1;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butBoqua;
		private MemoryStream memo;
		private FileStream fstr;
		private Bitmap map;
        private byte[] image;
		private AccessData m;
		private decimal l_maql;
		private string thumucpic,s_ngay,f1="",filebmp="hinh.bmp",xxx;
		private Print print=new Print();
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.CheckBox chkXem;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox nhanxet;
        private System.Windows.Forms.TextBox chandoan;
		private System.ComponentModel.IContainer components;
        private bool bbadt = false;
        #endregion

        public frmBAMAT(AccessData acc,decimal maql,string ngay)
		{
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m=acc;l_maql=maql;s_ngay=ngay;
		}
        public frmBAMAT(AccessData acc, decimal maql, string ngay,bool _badt)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; l_maql = maql; s_ngay = ngay;
            bbadt = _badt;
        }
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
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBAMAT));
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nhanxet = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // pic1
            // 
            this.pic1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pic1.Location = new System.Drawing.Point(8, 10);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(528, 222);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            this.toolTip1.SetToolTip(this.pic1, "Chỉnh sửa hình Double Click");
            this.pic1.DoubleClick += new System.EventHandler(this.pic1_DoubleClick);
            this.pic1.Click += new System.EventHandler(this.pic1_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(175, 440);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(245, 440);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(315, 440);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXML.Location = new System.Drawing.Point(448, 432);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 16);
            this.chkXML.TabIndex = 4;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXem.Location = new System.Drawing.Point(448, 449);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(104, 16);
            this.chkXem.TabIndex = 5;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHẬN XÉT :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CHẨN ĐOÁN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhanxet
            // 
            this.nhanxet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhanxet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanxet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanxet.Location = new System.Drawing.Point(8, 256);
            this.nhanxet.Multiline = true;
            this.nhanxet.Name = "nhanxet";
            this.nhanxet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nhanxet.Size = new System.Drawing.Size(264, 168);
            this.nhanxet.TabIndex = 1;
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(288, 256);
            this.chandoan.Multiline = true;
            this.chandoan.Name = "chandoan";
            this.chandoan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.chandoan.Size = new System.Drawing.Size(248, 168);
            this.chandoan.TabIndex = 3;
            // 
            // frmBAMAT
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(548, 477);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.nhanxet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.pic1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBAMAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bệnh án Mắt";
            this.Load += new System.EventHandler(this.frmBAMAT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBAMAT_Load(object sender, System.EventArgs e)
		{
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);//579
            }
			chkXem.Checked=m.bPreview;
			thumucpic="..\\..\\..\\picture_ba";
			if (!Directory.Exists("..\\pict_ba")) Directory.CreateDirectory("..\\pict_ba");
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
			get_file();
			xxx=m.user+m.mmyy(s_ngay);
			bool bFound=false;
			foreach(DataRow r in m.get_data("select * from "+xxx+".bavv_mat where maql="+l_maql).Tables[0].Rows)
			{
				image =new byte[0];
                if (r["hinh"].ToString() != "")
                {
                    image = (byte[])(r["hinh"]);
                    memo = new MemoryStream(image);
                }
                try { map = new Bitmap(Image.FromStream(memo)); }
                catch { map = new Bitmap("bangmat_01.bmp"); }
				picture(pic1,f1);
				//
				nhanxet.Text=r["nhanxet"].ToString();
				chandoan.Text=r["chandoan"].ToString();
				bFound=true;
				break;
			}
			if (!bFound)
			{
				pic1.Tag=filebmp;
				fstr=new System.IO.FileStream(pic1.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
				map=new Bitmap(Image.FromStream(fstr));
				pic1.Image=(Bitmap)map;
				image=new byte[fstr.Length];
				fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
				fstr.Close();
				pic1.Tag=image;
				picture(pic1,f1);
			}
		}

		private void edit_pic(PictureBox pic)
		{
            string sDir = System.Environment.CurrentDirectory.ToString(), tenfile = "..\\pict_ba\\" + pic.Name.ToString() + ".bmp";
            try
            {
                if (File.Exists(f1))
                {
                    frmPaint f = new frmPaint(f1);
                    f.ShowDialog();
                    f.Save_image(tenfile);
                    fstr = new System.IO.FileStream(tenfile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    image = new byte[fstr.Length];
                    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                    pic.Tag = image;
                    map = new Bitmap(Image.FromStream(fstr));
                    pic.Image = (Bitmap)map;
                    pic.Update();
                    fstr.Close();
                    get_file();
                    File.Copy(tenfile, f1, true);

                    //Image imag = Image.FromStream(new MemoryStream(imageR));

                    //Bitmap img = new Bitmap(new Bitmap(imag));
                }
            }
            catch (Exception ex) { string s = ex.ToString(); }
            System.Environment.CurrentDirectory = sDir;
		}

		private void pic1_DoubleClick(object sender, System.EventArgs e)
		{
			edit_pic(pic1);
		}

		private void get_file()
		{
			f1=thumucpic+"\\1"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
		}

		private void emp_hinh()
		{
			pic1.Tag=filebmp;
			fstr=new System.IO.FileStream(pic1.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic1.Image=(Bitmap)map;
			image=new byte[fstr.Length];
			fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic1.Tag=image;
			System.IO.File.Copy(filebmp,f1,true);
		}

		private void picture(PictureBox pic,string tenfile)
		{
			pic.Image=(Bitmap)map;
			pic.Tag=image;
			map.Save(tenfile);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			fstr=new System.IO.FileStream(f1,System.IO.FileMode.Open,System.IO.FileAccess.Read);
			image=new byte[fstr.Length];
			fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			m.upd_bavv_mat(s_ngay,l_maql,"","","","","","","","",image,nhanxet.Text,chandoan.Text);
			butIn.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			m.close();
			System.GC.Collect();
			this.Close();
		}

		private void p1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string sql="select * from "+xxx+".bavv_mat where maql="+l_maql;
			DataSet ds=m.get_data(sql);			
			if (ds.Tables[0].Rows.Count>0)
			{
				if (chkXML.Checked)
				{
					if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
					ds.WriteXml("..\\xml\\bamat.xml",XmlWriteMode.WriteSchema);
				}
				if (chkXem.Checked)
				{
                    dllReportM.frmReport f = new dllReportM.frmReport(m, ds, "", "rptBaMAT.rpt");
					f.ShowDialog();
				}
				else print.Printer(m,ds,"rptBaMAT.rpt","",1,1);
			}
		}

        private void pic1_Click(object sender, EventArgs e)
        {

        }
	}
}
