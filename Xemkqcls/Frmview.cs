using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ReadDicomfile;
using LibMedi;
using LibXetnghiem;
using System.Data;


namespace frmCanlamsan
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class Frmview : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuMos11;
		private System.Windows.Forms.MenuItem menuMos22;
		private System.Windows.Forms.MenuItem menuMos33;
		private System.Windows.Forms.MenuItem menu_Mosaics;
		private System.Windows.Forms.MenuItem z_bestfit;
		private System.Windows.Forms.MenuItem z_50;
		private System.Windows.Forms.MenuItem z_100;
		private System.Windows.Forms.MenuItem z_150;
		private System.Windows.Forms.MenuItem z_200;
		private System.Windows.Forms.MenuItem file_open;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.MenuItem menu_Zooms;
		private System.Windows.Forms.MenuItem menuCopy;
		private System.Windows.Forms.MenuItem file_saveit;
		private System.Windows.Forms.MenuItem file_exit;
		private System.Windows.Forms.ToolBarButton ContrastButton;
		private System.Windows.Forms.ToolBarButton AreaContrastButton;
		private System.Windows.Forms.ToolBarButton ZoomInButton;
		private System.Windows.Forms.ToolBarButton PanButton;
		private System.Windows.Forms.ToolBarButton MeasureButton;
		private System.Windows.Forms.ImageList il1;
		private AxezDICOMax.AxezDICOMX the_ezdicom;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuToggleHeader;
		private LibXetnghiem.AccessData Acc_xn=new LibXetnghiem.AccessData(); 
		private LibMedi.AccessData Acc_lib=new LibMedi.AccessData();

		private System.Windows.Forms.ContextMenu cm_Zoom;

		//bool is_smoothed = false;
		//bool is_header = false;
		int current_tool = 0;
		//int colourscheme = +1;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.ListView lsttags;
		private string pathimage;
		private ArrayList lstresult=new ArrayList();
		private String[] lstinfo={"Mã Bệnh nhân",
								  "Họ tên",
								  "Ngày sinh",
								  "Tuổi",
								  "Phái",
								  "Địa chỉ",
								  "Điện thoại",
								  "Chiều cao",
		                          "Cân nặng",
		                          "Ngày Khám",
								  "Chẩn đoán",
								  "Kết quả"};
		public Frmview(string path)
		{
			InitializeComponent();
			string pathip=@"..\\..\\..\\xml\\thongsoIP.xml";
			DataSet dsxml=new DataSet();
			dsxml.ReadXml(pathip);
			string dir=dsxml.Tables[0].Rows[0]["c4"].ToString()+"/"+path+".DCM";
			pathimage=dir;
			the_ezdicom.DCMfilename = pathimage;
			
			string sql="";
			string mabn="";
			string hoten="";
			string ngaysinh="";
			string tuoi="";
			string phai="";
			string add="";
			string phone="";
			string chieucao="";
			string cannang="";
			string ngaykham="";
			string ketqua="";
			try
			{

				ProcesFile prf=new ProcesFile();
				prf.CStore(pathimage);
				mabn=InFoPatient.mabn==null?"":InFoPatient.mabn;
				string sqlbn="select hoten from btdbn where mabn='"+mabn+"'";
				DataSet dsbn=Acc_xn.get_data(sqlbn);
				hoten=dsbn.Tables[0].Rows.Count>0?dsbn.Tables[0].Rows[0]["hoten"].ToString():InFoPatient.hoten;
				ngaysinh=InFoPatient.ngaysinh==null?"":InFoPatient.ngaysinh ;
				phai=InFoPatient.phai==null?"":InFoPatient.phai;	
				tuoi=InFoPatient.tuoi==null?"":InFoPatient.tuoi;
				add=InFoPatient.diachi==null?"":InFoPatient.diachi;
				phone=InFoPatient.dienthoai==null?"":InFoPatient.dienthoai;
				chieucao=InFoPatient.chieucao==null?"":InFoPatient.chieucao;
				cannang=InFoPatient.cannang==null?"":InFoPatient.cannang;
				ngaykham=InFoPatient.ngaycd==null?"":InFoPatient.ngaycd;
                
				if(ngaykham.Length!=0 && ngaysinh.Length!=0)
				{
					string dd="";string mm=""; string yy="" ;
					string dd1="";string mm1=""; string yy1="" ;
					for(int i=0;i<ngaykham.Length;i++)
					{
						if(i>=0 && i<=3){ yy+=ngaykham[i];yy1+=ngaysinh[i];}
						if(i>3 && i<=5){ mm+=ngaykham[i]; mm1+=ngaysinh[i];}
						if(i>5){dd+=ngaykham[i];dd1+=ngaysinh[i];}
					}
				ngaykham=dd+"/"+mm+"/"+yy;
				ngaysinh=dd1+"/"+mm1+"/"+yy1;
                
				}

				sql="select b.ketqua,a.chandoan from sa_bncdha a join sa_bncdha_ct b on a.count_cdha=b.count_cdha"; 
				sql+=" where a.mabn='"+mabn+"' and a.ngaycdha=to_date('"+ngaykham+"','dd/mm/yyyy')";
                
                DataSet ds=new DataSet();
				ds=Acc_lib.get_data(sql);
				string kq=""; string chandoan="";
				if(ds.Tables[0].Rows.Count>0)
				{
				   kq=ds.Tables[0].Rows[0]["ketqua"].ToString();
				   chandoan=ds.Tables[0].Rows[0]["chandoan"].ToString();
				}
				String[] lst={mabn,hoten,ngaysinh,tuoi,phai,add,phone,chieucao,cannang,ngaykham,chandoan,kq};
				for(int i=0;i<lst.Length;i++)
					lstresult.Add(lst[i].ToString());
			}
			catch
			{
            }
			InitalizeListview();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frmview));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.ContrastButton = new System.Windows.Forms.ToolBarButton();
			this.AreaContrastButton = new System.Windows.Forms.ToolBarButton();
			this.ZoomInButton = new System.Windows.Forms.ToolBarButton();
			this.PanButton = new System.Windows.Forms.ToolBarButton();
			this.MeasureButton = new System.Windows.Forms.ToolBarButton();
			this.il1 = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.file_open = new System.Windows.Forms.MenuItem();
			this.file_saveit = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.file_exit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuCopy = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menu_Zooms = new System.Windows.Forms.MenuItem();
			this.z_bestfit = new System.Windows.Forms.MenuItem();
			this.z_50 = new System.Windows.Forms.MenuItem();
			this.z_100 = new System.Windows.Forms.MenuItem();
			this.z_150 = new System.Windows.Forms.MenuItem();
			this.z_200 = new System.Windows.Forms.MenuItem();
			this.menu_Mosaics = new System.Windows.Forms.MenuItem();
			this.menuMos11 = new System.Windows.Forms.MenuItem();
			this.menuMos22 = new System.Windows.Forms.MenuItem();
			this.menuMos33 = new System.Windows.Forms.MenuItem();
			this.menuToggleHeader = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.the_ezdicom = new AxezDICOMax.AxezDICOMX();
			this.cm_Zoom = new System.Windows.Forms.ContextMenu();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lsttags = new System.Windows.Forms.ListView();
			((System.ComponentModel.ISupportInitialize)(this.the_ezdicom)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.ContrastButton,
																						this.AreaContrastButton,
																						this.ZoomInButton,
																						this.PanButton,
																						this.MeasureButton});
			this.toolBar1.ButtonSize = new System.Drawing.Size(20, 20);
			this.toolBar1.Cursor = System.Windows.Forms.Cursors.Default;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.il1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(790, 25);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.Wrappable = false;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolButtonClicked);
			// 
			// ContrastButton
			// 
			this.ContrastButton.ImageIndex = 0;
			this.ContrastButton.Tag = "1";
			this.ContrastButton.ToolTipText = "Drag mouse to adjust contrast and brightness";
			// 
			// AreaContrastButton
			// 
			this.AreaContrastButton.ImageIndex = 1;
			this.AreaContrastButton.Tag = "2";
			this.AreaContrastButton.ToolTipText = "Drag mouse over area to adjust contrast to show that area best";
			// 
			// ZoomInButton
			// 
			this.ZoomInButton.ImageIndex = 2;
			this.ZoomInButton.Tag = "3";
			this.ZoomInButton.ToolTipText = "Click mouse to see an enlargement of the region round it";
			// 
			// PanButton
			// 
			this.PanButton.ImageIndex = 4;
			this.PanButton.Tag = "4";
			this.PanButton.ToolTipText = "Drag mouse to pan around the image";
			// 
			// MeasureButton
			// 
			this.MeasureButton.ImageIndex = 3;
			this.MeasureButton.Tag = "5";
			this.MeasureButton.ToolTipText = "Drag mouse to measure distances on the image";
			// 
			// il1
			// 
			this.il1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.il1.ImageSize = new System.Drawing.Size(16, 16);
			this.il1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il1.ImageStream")));
			this.il1.TransparentColor = System.Drawing.Color.Olive;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.file_open,
																					  this.file_saveit,
																					  this.menuItem5,
																					  this.file_exit});
			this.menuItem1.Text = "&Tập tin";
			// 
			// file_open
			// 
			this.file_open.Index = 0;
			this.file_open.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.file_open.Text = "&Mở";
			this.file_open.Click += new System.EventHandler(this.file_open_Click);
			// 
			// file_saveit
			// 
			this.file_saveit.Index = 1;
			this.file_saveit.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.file_saveit.Text = "Lưu dạng bitmap....";
			this.file_saveit.Click += new System.EventHandler(this.menuSaveAs);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "-";
			// 
			// file_exit
			// 
			this.file_exit.Index = 3;
			this.file_exit.Text = "Thoát";
			this.file_exit.Click += new System.EventHandler(this.file_exit_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuCopy});
			this.menuItem2.Text = "&Cập nhật";
			// 
			// menuCopy
			// 
			this.menuCopy.Index = 0;
			this.menuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.menuCopy.Text = "&Copy";
			this.menuCopy.Click += new System.EventHandler(this.menuCopyIt);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menu_Zooms,
																					  this.menu_Mosaics,
																					  this.menuToggleHeader});
			this.menuItem3.Text = "&Xem hình";
			// 
			// menu_Zooms
			// 
			this.menu_Zooms.Index = 0;
			this.menu_Zooms.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.z_bestfit,
																					   this.z_50,
																					   this.z_100,
																					   this.z_150,
																					   this.z_200});
			this.menu_Zooms.Text = "Phóng to";
			// 
			// z_bestfit
			// 
			this.z_bestfit.Index = 0;
			this.z_bestfit.Text = "Best fit";
			this.z_bestfit.Click += new System.EventHandler(this.some_zoom_menu_selected);
			// 
			// z_50
			// 
			this.z_50.Index = 1;
			this.z_50.Text = "50%";
			this.z_50.Click += new System.EventHandler(this.some_zoom_menu_selected);
			// 
			// z_100
			// 
			this.z_100.Checked = true;
			this.z_100.Index = 2;
			this.z_100.Text = "100%";
			this.z_100.Click += new System.EventHandler(this.some_zoom_menu_selected);
			// 
			// z_150
			// 
			this.z_150.Index = 3;
			this.z_150.Text = "150%";
			this.z_150.Click += new System.EventHandler(this.some_zoom_menu_selected);
			// 
			// z_200
			// 
			this.z_200.Index = 4;
			this.z_200.Text = "200%";
			this.z_200.Click += new System.EventHandler(this.some_zoom_menu_selected);
			// 
			// menu_Mosaics
			// 
			this.menu_Mosaics.Index = 1;
			this.menu_Mosaics.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuMos11,
																						 this.menuMos22,
																						 this.menuMos33});
			this.menu_Mosaics.Text = "Tỷ lệ";
			this.menu_Mosaics.Click += new System.EventHandler(this.menuMosaic);
			// 
			// menuMos11
			// 
			this.menuMos11.Checked = true;
			this.menuMos11.Index = 0;
			this.menuMos11.Text = "1x1";
			this.menuMos11.Click += new System.EventHandler(this.menuMosaic);
			// 
			// menuMos22
			// 
			this.menuMos22.Index = 1;
			this.menuMos22.Text = "2x2";
			this.menuMos22.Click += new System.EventHandler(this.menuMosaic);
			// 
			// menuMos33
			// 
			this.menuMos33.Index = 2;
			this.menuMos33.Text = "3x3";
			this.menuMos33.Click += new System.EventHandler(this.menuMosaic);
			// 
			// menuToggleHeader
			// 
			this.menuToggleHeader.Index = 2;
			this.menuToggleHeader.Text = "Xem thông tin Bệnh nhân";
			this.menuToggleHeader.Click += new System.EventHandler(this.ToggleHeader);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "&Help";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "doc1";
			// 
			// the_ezdicom
			// 
			this.the_ezdicom.Name = "the_ezdicom";
			this.the_ezdicom.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("the_ezdicom.OcxState")));
			this.the_ezdicom.Size = new System.Drawing.Size(488, 560);
			this.the_ezdicom.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(158)), ((System.Byte)(185)), ((System.Byte)(195)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lsttags});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(790, 545);
			this.panel1.TabIndex = 5;
			// 
			// lsttags
			// 
			this.lsttags.FullRowSelect = true;
			this.lsttags.GridLines = true;
			this.lsttags.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsttags.Location = new System.Drawing.Point(488, 24);
			this.lsttags.Name = "lsttags";
			this.lsttags.Size = new System.Drawing.Size(304, 232);
			this.lsttags.TabIndex = 4;
			this.lsttags.View = System.Windows.Forms.View.Details;
			// 
			// Frmview
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(790, 545);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.toolBar1,
																		  this.the_ezdicom,
																		  this.panel1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "Frmview";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chẩn Đoán Hình Ảnh PACS";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Frmview_Load);
			((System.ComponentModel.ISupportInitialize)(this.the_ezdicom)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void axezDICOMX1_Enter(object sender, System.EventArgs e)
		{
		}
		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show("Visual C# demo of EZDicom by Tom Womack. \nDemonstrates use of the ActiveX component \n\n" + the_ezdicom.DCMversionInfo);
		}
		private void some_zoom_menu_selected(object sender, System.EventArgs e)
		{
			int zoom = -1;
			if (sender == z_bestfit) {zoom = -1;}
			if (sender == z_50) {zoom = 50;}
			if (sender == z_100) {zoom = 100;}
			if (sender == z_150) {zoom = 150;}
			if (sender == z_200) {zoom = 200;}
			if (zoom == -1) the_ezdicom.DCMbestFitZoom = true;
			else
			{
				the_ezdicom.DCMbestFitZoom = false;
				the_ezdicom.DCMzoomPct = zoom;
			}
			ClearChecks(menu_Zooms);
			// and check the one we're on
			((MenuItem)sender ).Checked = true;
		}
		private void file_open_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.ShowDialog();
			string fn = openFileDialog1.FileName;
			the_ezdicom.DCMfilename = fn;
		}

		private void ToggleSmooth(object sender, System.EventArgs e)
		{
			//is_smoothed = !is_smoothed;
			//menuSmooth.Checked = is_smoothed;
			//the_ezdicom.DCMsmoothOn = is_smoothed;
		}
		private void ToggleHeader(object sender, System.EventArgs e)
		{
			string path=@"..\\..\\..\\xml\\thongsoIP.xml";
			DataSet ds=new DataSet();
			ds.ReadXml(path);
			//string dir=ds.Tables[0].Rows[0]["c4"].ToString()+"//1.2.804.114118.2.20050911.171653.2217087716.1.1";
			//the_ezdicom.DCMfilename =dir;

		}
		private void ReflectHeaderState(bool s)
		{
			the_ezdicom.DCMshowHeader = s;
			if (s)
				menuToggleHeader.Text = "Display image";
			else
				menuToggleHeader.Text = "Display header";
		}
		private void ClearChecks(MenuItem mic)
		{
			IEnumerator k = mic.MenuItems.GetEnumerator();
			while (k.MoveNext())
				((MenuItem) k.Current).Checked = false;
		}
		private void ReflectColourScheme(int c)
		{
//			the_ezdicom.DCMcolorScheme = c;
//			ClearChecks(menu_Colours);
//			if (c==+1) menuColBW.Checked = true;
//			if (c==+2) menuColHot.Checked = true;
//			if (c==-1) menuColIBW.Checked = true;
//			if (c==-2) menuColIHot.Checked = true;
		}
		private void menuMosaic(object sender, System.EventArgs e)
		{
			int nmos = -1;
			if (sender == menuMos11) nmos=1;
			if (sender == menuMos22) nmos=2;
			if (sender == menuMos33) nmos=3;
			ClearChecks(menu_Mosaics);

			((MenuItem)sender).Checked = true;
			the_ezdicom.DCMmosaicRows = nmos;
			the_ezdicom.DCMmosaicFirstSlice = 1;
			the_ezdicom.DCMmosaicLastSlice = 9999;
			the_ezdicom.DCMmosaicCols = nmos;
		}
		private void menuColourScheme(object sender, System.EventArgs e)
		{
//			if (sender == menuColBW) colourscheme = +1;
//			if (sender == menuColHot) colourscheme = +2;
//			if (sender == menuColIBW) colourscheme = -1;
//			if (sender == menuColIHot) colourscheme = -2;
//			ReflectColourScheme(colourscheme);
		}
		private void menuCopyIt(object sender, System.EventArgs e)
		{
			bool a = the_ezdicom.DCMcopyImage2Clipboard;
		}

		private void menuSaveAs(object sender, System.EventArgs e)
		{
			saveFileDialog1.Filter = "Bitmap file|*.BMP|JPEG file|*.JPG";
			DialogResult a = saveFileDialog1.ShowDialog();
			if (a == DialogResult.OK) 
				the_ezdicom.DCMsaveToFile = saveFileDialog1.FileName;
		}

		private void ToolButtonClicked(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			((ToolBarButton)toolBar1.Buttons[current_tool]).Pushed = false;
			current_tool = Convert.ToInt32(e.Button.Tag) - 1;
			((ToolBarButton)(toolBar1.Buttons[current_tool])).Pushed = true;
			the_ezdicom.DCMtool = 1 + current_tool;
			
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>	
		private void file_exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void InitalizeListview()
		{
			string[] lstview=null;
			ColumnHeader headerone=this.lsttags.Columns.Add("Thông tin Bệnh nhân",14*Convert.ToInt32(lsttags.Font.SizeInPoints), HorizontalAlignment.Center);
			ColumnHeader headertwo=this.lsttags.Columns.Add("",25*Convert.ToInt32(lsttags.Font.SizeInPoints),HorizontalAlignment.Left);  
			for(int i=0;i<lstinfo.Length;i++)
			{
				lstview=new string[]
				{
					lstinfo[i].ToString(),
					lstresult[i].ToString()
				};
				ListViewItem lvi=new ListViewItem(lstview);
				lsttags.Items.Add(lvi);
				
			}
		}
		private void Frmview_Load(object sender, System.EventArgs e)
		{
			MessageBox.Show( the_ezdicom.Caption.ToString());
			InitalizeListview();
			
		}
	}
}



