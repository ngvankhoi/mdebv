using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace frmCanlamsan
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmxemthongtinBN : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmxemthongtinBN()
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmxemthongtinBN));
			// 
			// FrmxemthongtinBN
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 405);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmxemthongtinBN";
			this.Load += new System.EventHandler(this.FrmxemthongtinBN_Load_1);

		}
		#endregion
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
        //[STAThread]
        //static void Main() 
        //{
        //    Application.Run(new frmXemCanLamSan_medi("","","",""));//"05071870"
        //}
		private void FrmxemthongtinBN_Load(object sender, System.EventArgs e)
		{
		
		}
		private void get_image_cdha(long count_cdha, string makt)
		{
//			try
//			{
//				
//				delete_image();
//				pnhinh.Controls.Clear();
//				string sql="select * from sa_cdha_image where count_cdha='"+count_cdha+"' and makt='"+makt+"'";
//				DataSet ds=new DataSet();
//				ds=lcdha.get_data(sql);
//				int x=0,y=0;
//				if(ds.Tables[0].Rows.Count>0)
//				{
//					foreach(DataRow r in ds.Tables[0].Rows)
//					{
//						PictureBox l=new PictureBox();
//						Byte[] imageadata =new Byte[0];
//						imageadata =(Byte[])(r["image"]);
//						MemoryStream memo=new MemoryStream(imageadata);
//						Bitmap b=new Bitmap(Image.FromStream(memo));
//						l.Image=(Bitmap)b;
//						l.Width=150;
//						l.Height=pnhinh.Height-20;
//						l.SizeMode=PictureBoxSizeMode.StretchImage;
//						l.Dock=DockStyle.Left;
//						l.Location=new System.Drawing.Point(x,y);
//						x+=l.Width+2;
//						l.DoubleClick+=new System.EventHandler(this.im_Click);
//						l.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;
//						pnhinh.Controls.Add(l);
//						// coppy hình 
//						try
//						{
//							
//							b.Save(path_image_tmp+"\\image"+r["id"].ToString()+".bmp",System.Drawing.Imaging.ImageFormat.Bmp);
//							l.Tag=path_image_tmp+"\\image"+r["id"].ToString()+".bmp";
//							toolTip1.SetToolTip(l,l.Tag.ToString());
//						}
//						catch
//						{
//							
//						}
//						lblsohinh.Text=pnhinh.Controls.Count.ToString();
//					}
//				}
//			}
//			catch
//			{
//			}
		}

		private void FrmxemthongtinBN_Load_1(object sender, System.EventArgs e)
		{
		
		}

	}
}
