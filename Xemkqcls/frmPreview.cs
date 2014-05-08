using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
namespace sieuam
{
	/// <summary>
	/// 
	/// </summary>
	public class frmPreview : System.Windows.Forms.Form
	{
		public bool kt=false;
		private DataSet dsimage;
		
		private int mN=0;
		private int mI=0;
		private string mMoTa="";
		private string mKetLuan="";
		private string mImage01="";
		private string mImage02="";
		//private BaseFormat mFormat;
		//private frmOptionSieuAm mOption;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbView;
		private System.Windows.Forms.Panel pv;
		private System.Windows.Forms.Label lbt;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button btChonIn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel ptt;
		private System.Windows.Forms.Panel pt;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lbHI_1;
		private System.Windows.Forms.Button btIn;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.Label lbZoomin;
		private System.Windows.Forms.Label lbZoomout;
		private System.Windows.Forms.Label lbActualsize;
		private System.Windows.Forms.Panel pd;
	
		/// <summary>
		/// 
		/// </summary>
		public frmPreview(DataSet dsimage_)
		{
			///
			InitializeComponent();
//			mFormat = new BaseFormat();
//			mOption = new frmOptionSieuAm();
			dsimage=dsimage_;

		}
		public frmPreview(string vMoTa, string vKetLuan)
		{
			///
			InitializeComponent();
			//mFormat = new BaseFormat();
			//mOption = new frmOptionSieuAm();
//			txtNoiDung.Text = vMoTa;
//			txtKetLuan.Text=vKetLuan;
		}
		public string mmImage01
		{
			get
			{
				return mImage01;
			}
		}

		public string mmImage02
		{
			get
			{
				return mImage02;
			}
		}
		public string mmMoTa
		{
			get
			{
				return mMoTa;//txtNoiDung.Text.Trim();
			}
			set
			{
				mMoTa=value;
				//txtNoiDung.Text =  mMoTa;
			}
		}
		public string mmKetLuan
		{
			get
			{
				return mKetLuan;
			}
			set
			{
				mKetLuan=value;
			//	txtKetLuan.Text=mKetLuan;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPreview));
			this.ptt = new System.Windows.Forms.Panel();
			this.lbHI_1 = new System.Windows.Forms.Label();
			this.pt = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.pd = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbZoomout = new System.Windows.Forms.Label();
			this.lbZoomin = new System.Windows.Forms.Label();
			this.lbActualsize = new System.Windows.Forms.Label();
			this.btIn = new System.Windows.Forms.Button();
			this.btClose = new System.Windows.Forms.Button();
			this.btChonIn = new System.Windows.Forms.Button();
			this.pv = new System.Windows.Forms.Panel();
			this.lbt = new System.Windows.Forms.Label();
			this.lbView = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.label3 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ptt.SuspendLayout();
			this.pd.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pv.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ptt
			// 
			this.ptt.BackColor = System.Drawing.Color.Black;
			this.ptt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ptt.Controls.AddRange(new System.Windows.Forms.Control[] {
																			  this.lbHI_1,
																			  this.pt,
																			  this.label7});
			this.ptt.Dock = System.Windows.Forms.DockStyle.Left;
			this.ptt.DockPadding.All = 1;
			this.ptt.Name = "ptt";
			this.ptt.Size = new System.Drawing.Size(280, 527);
			this.ptt.TabIndex = 0;
			// 
			// lbHI_1
			// 
			this.lbHI_1.BackColor = System.Drawing.Color.Black;
			this.lbHI_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbHI_1.ForeColor = System.Drawing.Color.Navy;
			this.lbHI_1.Location = new System.Drawing.Point(4, 276);
			this.lbHI_1.Name = "lbHI_1";
			this.lbHI_1.Size = new System.Drawing.Size(270, 248);
			this.lbHI_1.TabIndex = 0;
			this.lbHI_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbHI_1.Click += new System.EventHandler(this.lbHI_1_Click);
			// 
			// pt
			// 
			this.pt.AutoScroll = true;
			this.pt.BackColor = System.Drawing.Color.Black;
			this.pt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pt.Location = new System.Drawing.Point(1, 21);
			this.pt.Name = "pt";
			this.pt.Size = new System.Drawing.Size(276, 243);
			this.pt.TabIndex = 0;
			this.pt.Resize += new System.EventHandler(this.pt_Resize);
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.SystemColors.Control;
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(276, 20);
			this.label7.TabIndex = 18;
			this.label7.Text = "DANH SÁCH HÌNH ĐÃ CHỤP";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pd
			// 
			this.pd.AutoScroll = true;
			this.pd.BackColor = System.Drawing.Color.Black;
			this.pd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pd.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.panel3,
																			 this.pv});
			this.pd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pd.DockPadding.All = 1;
			this.pd.Location = new System.Drawing.Point(283, 0);
			this.pd.Name = "pd";
			this.pd.Size = new System.Drawing.Size(488, 527);
			this.pd.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.SteelBlue;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lbZoomout,
																				 this.lbZoomin,
																				 this.lbActualsize,
																				 this.btIn,
																				 this.btClose,
																				 this.btChonIn});
			this.panel3.DockPadding.All = 2;
			this.panel3.Location = new System.Drawing.Point(1, 483);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(480, 40);
			this.panel3.TabIndex = 1;
			this.panel3.Resize += new System.EventHandler(this.panel3_Resize);
			// 
			// lbZoomout
			// 
			this.lbZoomout.BackColor = System.Drawing.Color.Black;
			this.lbZoomout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbZoomout.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbZoomout.Image = ((System.Drawing.Bitmap)(resources.GetObject("lbZoomout.Image")));
			this.lbZoomout.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.lbZoomout.Location = new System.Drawing.Point(39, 5);
			this.lbZoomout.Name = "lbZoomout";
			this.lbZoomout.Size = new System.Drawing.Size(30, 28);
			this.lbZoomout.TabIndex = 14;
			this.toolTip1.SetToolTip(this.lbZoomout, "Thu nhỏ");
			this.lbZoomout.Click += new System.EventHandler(this.lbZoomout_Click);
			// 
			// lbZoomin
			// 
			this.lbZoomin.BackColor = System.Drawing.Color.Black;
			this.lbZoomin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbZoomin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbZoomin.Image = ((System.Drawing.Bitmap)(resources.GetObject("lbZoomin.Image")));
			this.lbZoomin.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.lbZoomin.Location = new System.Drawing.Point(5, 5);
			this.lbZoomin.Name = "lbZoomin";
			this.lbZoomin.Size = new System.Drawing.Size(30, 28);
			this.lbZoomin.TabIndex = 13;
			this.toolTip1.SetToolTip(this.lbZoomin, "Phóng to");
			this.lbZoomin.Click += new System.EventHandler(this.lbZoomin_Click);
			// 
			// lbActualsize
			// 
			this.lbActualsize.BackColor = System.Drawing.Color.Black;
			this.lbActualsize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbActualsize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbActualsize.Image = ((System.Drawing.Bitmap)(resources.GetObject("lbActualsize.Image")));
			this.lbActualsize.Location = new System.Drawing.Point(73, 5);
			this.lbActualsize.Name = "lbActualsize";
			this.lbActualsize.Size = new System.Drawing.Size(30, 28);
			this.lbActualsize.TabIndex = 26;
			this.toolTip1.SetToolTip(this.lbActualsize, "Kích thước thật");
			this.lbActualsize.Click += new System.EventHandler(this.lbActualsize_Click);
			// 
			// btIn
			// 
			this.btIn.BackColor = System.Drawing.SystemColors.Control;
			this.btIn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btIn.ForeColor = System.Drawing.Color.Blue;
			this.btIn.Location = new System.Drawing.Point(320, 5);
			this.btIn.Name = "btIn";
			this.btIn.Size = new System.Drawing.Size(72, 28);
			this.btIn.TabIndex = 1;
			this.btIn.Text = "&Đồng ý";
			this.btIn.Click += new System.EventHandler(this.btIn_Click);
			// 
			// btClose
			// 
			this.btClose.BackColor = System.Drawing.SystemColors.Control;
			this.btClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btClose.ForeColor = System.Drawing.Color.Blue;
			this.btClose.Location = new System.Drawing.Point(394, 4);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(72, 28);
			this.btClose.TabIndex = 2;
			this.btClose.Text = "&Bỏ qua";
			this.btClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btChonIn
			// 
			this.btChonIn.BackColor = System.Drawing.SystemColors.Control;
			this.btChonIn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btChonIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btChonIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btChonIn.ForeColor = System.Drawing.Color.Blue;
			this.btChonIn.Location = new System.Drawing.Point(245, 5);
			this.btChonIn.Name = "btChonIn";
			this.btChonIn.Size = new System.Drawing.Size(72, 28);
			this.btChonIn.TabIndex = 7;
			this.btChonIn.TabStop = false;
			this.btChonIn.Text = "Chọn để in   ";
			this.btChonIn.Click += new System.EventHandler(this.btChonIn_Click);
			// 
			// pv
			// 
			this.pv.AutoScroll = true;
			this.pv.BackColor = System.Drawing.Color.Black;
			this.pv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pv.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.lbt,
																			 this.lbView});
			this.pv.Location = new System.Drawing.Point(1, 3);
			this.pv.Name = "pv";
			this.pv.Size = new System.Drawing.Size(480, 479);
			this.pv.TabIndex = 2;
			// 
			// lbt
			// 
			this.lbt.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbt.Location = new System.Drawing.Point(0, 467);
			this.lbt.Name = "lbt";
			this.lbt.Size = new System.Drawing.Size(476, 8);
			this.lbt.TabIndex = 4;
			this.lbt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbt.Visible = false;
			// 
			// lbView
			// 
			this.lbView.ForeColor = System.Drawing.Color.White;
			this.lbView.Name = "lbView";
			this.lbView.Size = new System.Drawing.Size(20, 20);
			this.lbView.TabIndex = 3;
			this.lbView.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.lbView.Click += new System.EventHandler(this.lbView_Click);
			this.lbView.Resize += new System.EventHandler(this.lbView_Resize);
			this.lbView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbView_MouseMove);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.pd,
																				 this.splitter1,
																				 this.ptt});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(771, 527);
			this.panel1.TabIndex = 3;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(280, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 527);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label3.Location = new System.Drawing.Point(3, 529);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(771, 3);
			this.label3.TabIndex = 9;
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmPreview
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 534);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.label3});
			this.DockPadding.Bottom = 2;
			this.DockPadding.Left = 3;
			this.DockPadding.Right = 2;
			this.DockPadding.Top = 2;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPreview";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "  Bác sĩ xem hình và cho kết quả chẩn đoán";
			this.Load += new System.EventHandler(this.frmPreview_Load);
			this.Closed += new System.EventHandler(this.frmPreview_Closed);
			this.ptt.ResumeLayout(false);
			this.pd.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.pv.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmPreview_Load(object sender, System.EventArgs e)
		{
			try
			{
				f_LoadThum();
				//f_ResetHinhIn();
				//chkHI_1.Checked=false;
				//chkHI_2.Checked=false;
				lbi_Click(pt.Controls[0],null);
			}
			catch
			{
			}
			lbView.Focus();
		}
		private void f_ResetHinhIn()
		{
			try
			{
				lbHI_1.Tag="";
				lbHI_1.Image=null;
//				lbHI_2.Tag="";
//				lbHI_2.Image=null;
			}
			catch
			{
			}
		}
		private void f_LoadThum()
		{
			#region thang
			try
			{
				int x=0,y=0,w=0;
				try
				{
					w=(pt.Width-pt.DockPadding.Left-pt.DockPadding.Right)/4;
				}
				catch(Exception ee)
				{
					w=100;
					MessageBox.Show(ee.ToString());
				}
				//DataSet ads = mFormat.f_GetFile(path_image);
				
				foreach(DataRow r in dsimage.Tables[0].Rows)//ads.Tables[0].Rows)
				{
					PictureBox l = new PictureBox();
					l.Width=w-2;
					l.Height=w-2;
					//Bitmap bm=new Bitmap(r["FPATH"].ToString()+"\\"+r["FNAME"].ToString());
					Bitmap bm=new Bitmap(r["FNAME"].ToString());
					//l.Image = new System.Drawing.Bitmap(new System.Drawing.Bitmap(r[3].ToString() + "\\" + r[0].ToString()),l.Size);
					l.Image=(Bitmap)bm;
					l.SizeMode=PictureBoxSizeMode.StretchImage;
					l.BorderStyle=BorderStyle.Fixed3D;
					l.ForeColor=Color.White;
					l.Location = new Point(x*w + 1,y*w + 1);
					l.Text = "";
					l.Tag = r[0].ToString();
					toolTip1.SetToolTip(l,l.Tag.ToString());
					l.Cursor=Cursors.Hand;
					l.Click += new System.EventHandler(this.lbi_Click);
					pt.Controls.Add(l);
					x=x+1;
					if(x>=4)
					{
						x=0;
						y=y+1;
					}
				}
				this.Update();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			#endregion


		}

		private void pt_Resize(object sender, System.EventArgs e)
		{
			f_Resize();
		}
		private void f_Resize()
		{
			try
			{
				int x=0,y=0,w=0;
				try
				{
					w=(pt.Width-pt.DockPadding.Left-pt.DockPadding.Right)/4;
				}
				catch(Exception ee)
				{
					w=100;
					MessageBox.Show(ee.ToString());
				}
				foreach(Control l in pt.Controls)
				{
					if(l.GetType().ToString()=="System.Windows.Forms.Label")
					{
						l.Width=w-2;
						l.Height=w-2;
						l.Left=x*w + 1;
						l.Top=y*w + 1;
						//l.Location = new Point(x*w,y*w);
						x=x+1;
						if(x>=4)
						{
							x=0;
							y=y+1;
						}
					}
				}
				//pt.SuspendLayout();
				this.Update();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void lbi_Click(object sender, System.EventArgs e)
		{
			try
			{
				PictureBox l = (PictureBox)(sender);
				//lbView.Image =  new System.Drawing.Bitmap(mPath + "\\" + l.Text);
				//lbView.Image =  new System.Drawing.Bitmap(path_image + "\\" + l.Tag.ToString());
				lbView.Image =  new System.Drawing.Bitmap(l.Tag.ToString());
				lbView.Size=lbView.Image.Size;
				//lbView.Tag = path_image + "\\" + l.Tag.ToString();
				lbView.Tag = l.Tag.ToString();
				toolTip1.SetToolTip(lbView,lbView.Tag.ToString());
				mN = 0;
				lbt.Image = lbView.Image;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void lbView_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(lbView.Cursor==Cursors.SizeAll)
				{
					btZoomIn_Click(null,null);
				}
				else
					if(lbView.Cursor==Cursors.NoMove2D)
				{
					btZoomOut_Click(null,null);
				}
			}
			catch
			{
			}
		}

		private void btZoomIn_Click(object sender, System.EventArgs e)
		{
			
		}
		private void btZoomOut_Click(object sender, System.EventArgs e)
		{
			
		}

		private void btOrigin_Click(object sender, System.EventArgs e)
		{
			
		}

		private void lbView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				//if((e.X<pv.Left + 10) ||(e.Y<pv.Top + 10))
				//{
				//	pv.AutoScrollPosition = new Point(pv.Left-e.X,pv.Top-e.Y);
				//	pv.AutoScrollPosition = new Point(pv.Left-e.X,pv.Top-e.Y);
				//}
				//lbView.Text=e.X + ":" + e.Y + "___" + lbView.Left.ToString()+ ":" + lbView.Top.ToString();
			}
			catch
			{
			}
		}

		private void btClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void panel3_Resize(object sender, System.EventArgs e)
		{
			try
			{
				lbZoomin.Width=(panel3.Width-panel3.DockPadding.Left-panel3.DockPadding.Right)/5;
				lbZoomout.Width=lbZoomin.Width;
				lbActualsize.Width=lbZoomout.Width;
				//btSlide.Width=btZoomIn.Width;
				//btChonIn.Width=btZoomIn.Width;
			}
			catch
			{
			}
		}

		private void lbView_Resize(object sender, System.EventArgs e)
		{
			try
			{
				lbView.Left=(pv.Width>lbView.Image.Width)?(pv.Width-lbView.Image.Width)/2:0;
				lbView.Top=(pv.Height>lbView.Image.Height)?(pv.Height-lbView.Image.Height)/2:0;
			}
			catch
			{
			}
		}

		private void btSlide_Click(object sender, System.EventArgs e)
		{
			
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				mI=mI + 1;
				if(mI>pt.Controls.Count)
				{
					mI=0;
				}
				lbi_Click(pt.Controls[mI],null);
			}
			catch
			{
			}
		}

		private void btChonIn_Click(object sender, System.EventArgs e)
		{
			try
			{
//				lbHI_2.Tag=lbHI_1.Tag.ToString();
//				lbHI_2.Image=lbHI_1.Image;
//				chkHI_2.Checked = chkHI_1.Checked;
//				mImage02 = lbHI_2.Tag.ToString();
			
				lbHI_1.Tag=lbView.Tag;
				Bitmap b=new System.Drawing.Bitmap(lbHI_1.Tag.ToString());
				//lbHI_1.Image=new System.Drawing.Bitmap(new System.Drawing.Bitmap(lbHI_1.Tag.ToString()),lbHI_1.Size);
				lbHI_1.Image=(Bitmap)b;
				lbHI_1.Size=b.Size;
				//chkHI_1.Checked = true;
				mImage01 = lbHI_1.Tag.ToString();
				toolTip1.SetToolTip(lbHI_1,lbHI_1.Tag.ToString());
			
			}
			
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			lbView.Focus();
		}

		private void chkHI_1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmPreview_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void btIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				if(lbHI_1.Image!=null)
				{
					string path_image_report="c:\\reportpic";
					string image1 = path_image_report + "\\image01.bmp";
					if(System.IO.Directory.Exists(path_image_report))
					{
						System.IO.Directory.Delete(path_image_report,true);
					}
					System.IO.Directory.CreateDirectory(path_image_report);
					System.IO.File.Copy(lbHI_1.Tag.ToString(),image1,true);
					kt=true;
					this.Close();
				}
				else
				{
					MessageBox.Show(this,"Chọn hình để in","MedisoftTHIS");
				}
			}
			catch
			{}
		}
		

		private void txtNoiDung_TextChanged(object sender, System.EventArgs e)
		{
			//mMoTa = txtNoiDung.Text.Trim();
		}

		private void txtKetLuan_TextChanged(object sender, System.EventArgs e)
		{
			//mKetLuan = txtKetLuan.Text;
		}

		private void chkHI_1_Click(object sender, System.EventArgs e)
		{
//			if(!chkHI_1.Checked)
//			{
//				lbHI_1.Image=null;
//				lbHI_1.Tag="";
//			}
		}

		private void chkHI_2_Click(object sender, System.EventArgs e)
		{
//			if(!chkHI_2.Checked)
//			{
//				lbHI_2.Image=null;
//				lbHI_2.Tag="";
//			}
		}

		private void lbHI_1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lbZoomin_Click(object sender, System.EventArgs e)
		{
			try
			{
				lbView.Cursor = Cursors.SizeAll;
				mN = mN + 5;
				int aw = (lbt.Image.Width * mN)/100;
				int ah = (lbt.Image.Width * mN)/100;

				lbView.Image =  new System.Drawing.Bitmap(lbt.Image,lbt.Image.Width + aw,lbt.Image.Height + ah);
				lbView.Width = lbView.Image.Width;
				lbView.Height = lbView.Image.Height;
				lbView_Resize(null,null);
			}
			catch
			{
				
			}
			lbView.Focus();
		}

		private void lbZoomout_Click(object sender, System.EventArgs e)
		{
			try
			{
				lbView.Cursor = Cursors.NoMove2D;
				mN = mN - 5;
				int aw = (lbt.Image.Width * mN)/100;
				int ah = (lbt.Image.Width * mN)/100;

				lbView.Image =  new System.Drawing.Bitmap(lbt.Image,lbt.Image.Width + aw,lbt.Image.Height + ah);
				lbView.Width = lbView.Image.Width;
				lbView.Height = lbView.Image.Height;
				lbView_Resize(null,null);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			lbView.Focus();
		}

		private void lbActualsize_Click(object sender, System.EventArgs e)
		{
			try
			{
				mN = 0;
				lbView.Cursor = Cursors.Default;
				int aw = (lbt.Image.Width * mN)/100;
				int ah = (lbt.Image.Width * mN)/100;

				lbView.Image =  new System.Drawing.Bitmap(lbt.Image,lbt.Image.Width + aw,lbt.Image.Height + ah);
				lbView.Width = lbView.Image.Width;
				lbView.Height = lbView.Image.Height;
				lbView_Resize(null,null);
			}
			catch
			{
				
			}
			lbView.Focus();
		}

		private void lbPre_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
