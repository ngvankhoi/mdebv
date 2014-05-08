using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmManHinhLCD.
	/// </summary>
	public class frmManHinhLCD_DSBN : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox picbx;
		private System.Windows.Forms.Label lbltieude;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;		
		private System.Windows.Forms.Panel pnldanhsach;
		
		LibMedi.AccessData _libM=new LibMedi.AccessData();
		string _sMakp="";
		string _sSql="",mmyy="0113";
		bool bStt=false;
		DataTable dtPathImage;
		private System.Windows.Forms.Label lbltat;
		private System.Windows.Forms.Label lblbndangkham;
		int _iIndexImageHT=0;
		Label _lblstt=new Label();
		private System.Windows.Forms.Timer timer2;
		Label _lblhoten=new Label();
        frmManHinhLCD_thongso _ts;

		public frmManHinhLCD_DSBN()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManHinhLCD_DSBN));
            this.picbx = new System.Windows.Forms.PictureBox();
            this.pnldanhsach = new System.Windows.Forms.Panel();
            this.lbltieude = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblbndangkham = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbltat = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbx)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picbx
            // 
            this.picbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picbx.Image = ((System.Drawing.Image)(resources.GetObject("picbx.Image")));
            this.picbx.Location = new System.Drawing.Point(0, 0);
            this.picbx.Name = "picbx";
            this.picbx.Size = new System.Drawing.Size(600, 688);
            this.picbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbx.TabIndex = 0;
            this.picbx.TabStop = false;
            this.picbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbx_MouseMove);
            // 
            // pnldanhsach
            // 
            this.pnldanhsach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnldanhsach.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pnldanhsach.Location = new System.Drawing.Point(600, 56);
            this.pnldanhsach.Name = "pnldanhsach";
            this.pnldanhsach.Size = new System.Drawing.Size(424, 632);
            this.pnldanhsach.TabIndex = 1;
            // 
            // lbltieude
            // 
            this.lbltieude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltieude.BackColor = System.Drawing.Color.Green;
            this.lbltieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.ForeColor = System.Drawing.Color.White;
            this.lbltieude.Location = new System.Drawing.Point(600, 0);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(424, 56);
            this.lbltieude.TabIndex = 0;
            this.lbltieude.Text = "DANH SÁCH BỆNH NHÂN CHỜ KHÁM BỆNH";
            this.lbltieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.lblbndangkham);
            this.panel2.Location = new System.Drawing.Point(0, 688);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 80);
            this.panel2.TabIndex = 2;
            // 
            // lblbndangkham
            // 
            this.lblbndangkham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbndangkham.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbndangkham.ForeColor = System.Drawing.Color.Yellow;
            this.lblbndangkham.Location = new System.Drawing.Point(0, 8);
            this.lblbndangkham.Name = "lblbndangkham";
            this.lblbndangkham.Size = new System.Drawing.Size(1024, 64);
            this.lblbndangkham.TabIndex = 0;
            this.lblbndangkham.Text = "Đang khám:  NGUYỄN VĂN AN";
            this.lblbndangkham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbltat
            // 
            this.lbltat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbltat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltat.ForeColor = System.Drawing.Color.Red;
            this.lbltat.Location = new System.Drawing.Point(0, 0);
            this.lbltat.Name = "lbltat";
            this.lbltat.Size = new System.Drawing.Size(107, 24);
            this.lbltat.TabIndex = 3;
            this.lbltat.Text = "Tắt màn hình";
            this.lbltat.Visible = false;
            this.lbltat.MouseLeave += new System.EventHandler(this.lbltat_MouseLeave);
            this.lbltat.Click += new System.EventHandler(this.lbltat_Click);
            this.lbltat.MouseEnter += new System.EventHandler(this.lbltat_MouseEnter);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmManHinhLCD_DSBN
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lbltat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnldanhsach);
            this.Controls.Add(this.lbltieude);
            this.Controls.Add(this.picbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManHinhLCD_DSBN";
            this.Text = "Màn hình LCD";
            this.Load += new System.EventHandler(this.frmManHinhLCD_Load);
            this.Closed += new System.EventHandler(this.frmManHinhLCD_Closed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbx_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picbx)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if(_iIndexImageHT==dtPathImage.Rows.Count)_iIndexImageHT=0;
				picbx.Image=Image.FromFile(dtPathImage.Rows[_iIndexImageHT]["ten"].ToString());
				_iIndexImageHT++;
				//lblbndangkham_hienthi.Visible=false;
				picbx.Visible=true;
				picbx.BringToFront();
				_lblhoten.Visible=_lblstt.Visible=false;
			}
			catch{}
			
		}
		DataSet LoadData()
		{
			_sSql="select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten,a.done,rownum as stt,";
			_sSql+=" case when a.noitiepdon=16 then 'x' else 'y' end as tk, a.makp, c.tenkp ";
			_sSql+=" from "+_libM.user+mmyy+".tiepdon a,btdbn b, btdkp_bv c ";
			_sSql+=" where a.mabn=b.mabn and a.makp=c.makp and (a.done is null or a.done in ('?','d')) and to_char(a.ngay,'dd/mm/yyyy')='14/01/2013'";
			_sSql+=" and a.noitiepdon in (0,1,5,16)";
			if (_sMakp!="" )
			{
				string s=_sMakp.Trim(',').Replace(",","','");
				_sSql+=" and a.makp in ('"+s+"')";//.Substring(0,s.Length-3)
			}
			if (bStt) 
			{
				_sSql+=" and a.sovaovien is not null";
				_sSql+=" order by to_char(a.sovaovien,'0000000000'),a.ngay,a.makp";
			}
			else _sSql+=" order by a.ngay,a.makp";
			DataSet dstam=_libM.get_data(_sSql);
			return dstam;
		}
		
		public void HienThi(DataTable dttam,string stt,string mabn,string tenbn)
		{
			pnldanhsach.Controls.Clear();			
			Label lblten,lblstt;

			Label lbltam=new Label();
			lbltam.AutoSize=true;			
			lbltam.Font=new Font("Arial",float.Parse(_ts.DanhSach_cochu.ToString()),FontStyle.Bold);
            lbltam.Text = "a";
            this.Controls.Add(lbltam);
            lbltam.Location = new Point(0, 0);
            int iHei = lbltam.Height+10;
            int iWei2 = 0,iWei1=0;
			pnldanhsach.BackColor=Color.FromArgb(_ts.DanhSach_maunen_red
				,_ts.DanhSach_maunen_green
				,_ts.DanhSach_maunen_blue);
			pnldanhsach.ForeColor=Color.FromArgb(_ts.DanhSach_mauchu_red
				,_ts.DanhSach_mauchu_green
				,_ts.DanhSach_mauchu_blue);
            this.BackColor = Color.FromArgb(_ts.TieuDe_maunen_red
                , _ts.TieuDe_maunen_green
                , _ts.TieuDe_maunen_blue);
            this.ForeColor = Color.FromArgb(_ts.TieuDe_mauchu_red
                , _ts.TieuDe_mauchu_green
                , _ts.TieuDe_mauchu_blue);
			
			int imaxlengh=0;
			
			for(int i=0;i<((dttam.Rows.Count>10)?11:dttam.Rows.Count);i++)
			{
				
				lblstt=new Label();
                lblstt.TextAlign = ContentAlignment.MiddleLeft;
				lblstt.Text=dttam.Rows[i]["stt"].ToString().PadLeft(2,'0');
                if (i == 10) lblstt.Text = "";
				lblstt.AutoSize=false;
				lblstt.Anchor=AnchorStyles.Left;
                lbltam.Text = lblstt.Text;
				
                iWei1 = (iWei1 < lbltam.Width) ? lbltam.Width : iWei1;
                lblstt.Width = iWei1;
				lblstt.Height=iHei;				
				lblstt.Font=lbltam.Font;
				lblstt.Location=new Point(0,iHei*i+5);

//				lblmabn=new Label();
//				lblmabn.AutoSize=true;
//				lblmabn.Text=dttam.Rows[i]["mabn"].ToString();
//				lblmabn.AutoSize=false;
//				lblmabn.Anchor=AnchorStyles.Left;
//
//				lbltam.Text="99999999   ";
//
//				lblmabn.Width=lbltam.Width;
//				lblmabn.Height=lbltam.Height;				
//				lblmabn.Font=lbltam.Font;
//				lblmabn.Location=new Point(lblstt.Location.X+lblstt.Width,lbltam.Height*i+5);

				lblten=new Label();
                lblten.TextAlign = ContentAlignment.MiddleLeft;
				lblten.Text=dttam.Rows[i]["hoten"].ToString();
                if (i == 10) lblten.Text = "...";
				lbltam.Text=lblten.Text+" ";
				lblten.AutoSize=false;
				lblten.Anchor=AnchorStyles.Left;

                iWei2 = (iWei2 < lbltam.Width) ? lbltam.Width : iWei2;
                lblten.Width = iWei2;				
				lblten.Height=iHei;				
				lblten.Font=lbltam.Font;
				lblten.Location=new Point(lblstt.Location.X+lblstt.Width,iHei*i+5);
				
				pnldanhsach.Controls.Add(lblstt);
				//pnldanhsach.Controls.Add(lblmabn);
				pnldanhsach.Controls.Add(lblten);

				if((lblstt.Width+lblten.Width)>imaxlengh)
					imaxlengh=lblstt.Width+lblten.Width;

				lblstt=lblten=null;

			}
            lbltieude.Width = (imaxlengh > lbltieude.Width) ? imaxlengh : lbltieude.Width;
			lbltieude.Location=new Point(this.Width-lbltieude.Width,0);
			pnldanhsach.Width=lbltieude.Width;
			pnldanhsach.Location=new Point(lbltieude.Location.X,lbltieude.Location.Y+lbltieude.Height);
			picbx.Width=this.Width-lbltieude.Width;
			//lblbndangkham_hienthi.Width=picbx.Width;
			
			lblbndangkham.Text=(stt==""&&mabn==""&&tenbn=="")?"":"Đang khám: "+stt+"   "+tenbn;
			//lblbndangkham_hienthi.Text=stt+"\n"+tenbn;
			try{timer1.Stop();}
			catch{}
			if(stt==""&&mabn==""&&tenbn=="")
			{
				_lblhoten.Visible=_lblstt.Visible=false;
				//lblbndangkham_hienthi.Visible=false;
				picbx.Visible=true;
				picbx.BringToFront();
				timer1.Start();
			}
			else
			{
				DataSet dstam=new DataSet();
				try{
					dstam.ReadXml("..\\..\\..\\xml\\ThongSoManHinhLCD.xml");
				}
				catch{dstam=new DataSet();
					dstam.Tables.Add();
					dstam.Tables[0].Columns.Add("STT_size");
					dstam.Tables[0].Columns.Add("TenBN_size");
					DataRow dr=dstam.Tables[0].NewRow();
					dr[0]=150;
					dr[1]=30;
					dstam.Tables[0].Rows.Add(dr);
					dstam.WriteXml("..\\..\\..\\xml\\ThongSoManHinhLCD.xml");
				}
				lbltam.Font=new Font("Arial",int.Parse(dstam.Tables[0].Rows[0][0].ToString()));
				lbltam.Text="00";
				_lblhoten.AutoSize=true;
				_lblhoten.Text=tenbn;
				_lblhoten.ForeColor=this.ForeColor;
				_lblhoten.Font=new Font("Arial",int.Parse(dstam.Tables[0].Rows[0][1].ToString()));
				_lblhoten.Width=lbltam.Width;				
				_lblhoten.TextAlign=ContentAlignment.BottomCenter;
				
				
				_lblstt.Text=stt;
				_lblstt.Font=lbltam.Font;
				_lblstt.AutoSize=false;
				_lblstt.Width=_lblhoten.Width;
				_lblstt.Height=lbltam.Height;
				_lblstt.TextAlign=ContentAlignment.MiddleCenter;
				_lblstt.ForeColor=_lblhoten.ForeColor;
				//_lblstt.BackColor=Color.White;
				
				_lblstt.Location=new Point((this.Width-pnldanhsach.Width)/2-(_lblhoten.Width/2),(this.Height-panel2.Height)/2-(_lblstt.Height+_lblhoten.Height)/2);
				_lblhoten.Location=new Point((this.Width-pnldanhsach.Width)/2-(_lblhoten.Width/2),_lblstt.Location.Y+_lblstt.Height);
                _lblhoten.Height = this.Height-_lblhoten.Location.Y;

				_lblhoten.Visible=_lblstt.Visible=true;
				picbx.Visible=false;
				_lblhoten.BringToFront();
				_lblstt.BringToFront();
				timer2.Interval=7000;
				timer2.Start();
			}
			//lblbndangkham_hienthi.BringToFront();

            this.Controls.Remove(lbltam);
			
		}

		public void frmManHinhLCD_Load(object sender, System.EventArgs e)
		{
            _ts = new frmManHinhLCD_thongso();
            _ts.bCauHinhTheoDSBN = true;
            _ts.frmManHinhLCD_thongso_Load(null, null);

			this.Controls.Add(_lblhoten);
			this.Controls.Add(_lblstt);
			dtPathImage=new DataTable();
			dtPathImage.Columns.Add("ten");
			//ds.WriteXml("dstam.xml",XmlWriteMode.WriteSchema);			
			try
			{
				DataRow dr;
				string stam="";
				string[] arr=System.IO.Directory.GetFiles("ImageLCD");	
				for(int i=0;i<arr.Length;i++)
				{
					stam=arr[i].Split('\\')[arr[i].Split('\\').Length-1];
					if(stam.IndexOf(".jpeg")>-1||stam.IndexOf(".jpg")>-1||stam.IndexOf(".gif")>-1)
					{
						dr=dtPathImage.NewRow();
						dr[0]=arr[i];
						dtPathImage.Rows.Add(dr);
					}
					
				}
				
			}
			catch{System.IO.Directory.CreateDirectory("ImageLCD");}
			
			try
			{
				this.Location=new Point(int.Parse(_ts.ToaDo_X.ToString())
					,int.Parse(_ts.ToaDo_Y.ToString()));
				this.Width=int.Parse(_ts.ChieuRong.ToString());
				this.Height=int.Parse(_ts.ChieuCao.ToString());
				
			}
			catch{}
            timer1.Interval = 5000;			
			UpdateStateForm(0);
		}

		private void lbltat_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void lbltat_MouseEnter(object sender, System.EventArgs e)
		{
			lbltat.Visible=true;
			lbltat.BringToFront();
		}

		private void lbltat_MouseLeave(object sender, System.EventArgs e)
		{
			lbltat.Visible=false;
		}

		private void picbx_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.X<=(lbltat.Location.X+lbltat.Width)&&e.X>lbltat.Location.X&&e.Y<=(lbltat.Location.Y+lbltat.Height)&&e.Y>lbltat.Location.Y)
			{
				lbltat_MouseEnter(null,null);
			}
			else
				lbltat_MouseLeave(null,null);
		}

		private void frmManHinhLCD_Closed(object sender, System.EventArgs e)
		{
			UpdateStateForm(1);
		}
		static public bool IsClose
		{
			get{
				DataSet ds=new DataSet();
				try
				{
					ds.ReadXml("StateLCD.xml");
				}
				catch
				{
					UpdateStateForm(1);
					ds.ReadXml("StateLCD.xml");
				}
				return (ds.Tables[0].Rows[0][0].ToString()=="1");
			}
			set{UpdateStateForm((value)?1:0);}
		}
		static void UpdateStateForm(int giatri)
		{
			DataSet ds=new DataSet();
			try
			{
				ds.ReadXml("StateLCD.xml");
				
			}
			catch
			{
				ds=new DataSet();
				ds.Tables.Add("LCD");
				ds.Tables[0].Columns.Add("isClose");
				DataRow dr=ds.Tables[0].NewRow();
				ds.Tables[0].Rows.Add(dr);
				
			}
			ds.Tables[0].Rows[0][0]=giatri;
			ds.WriteXml("StateLCD.xml");
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			timer2.Stop();
			timer1.Start();
		}

	
	}
}
