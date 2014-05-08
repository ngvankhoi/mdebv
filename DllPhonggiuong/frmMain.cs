using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace DllPhonggiuong
{
	public class frmMain : System.Windows.Forms.Form
	{
        private LibMedi.AccessData m = new LibMedi.AccessData();
		private string s_tenform="",s_log="",s_makp="",s_user="";
		private int i_userid,i_log;
		private DataSet dsxml=new DataSet();
		private System.Windows.Forms.Panel pSplit;
		private System.Windows.Forms.Panel pKhoaphong;
		private System.Windows.Forms.Button butExit;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.Panel pVienphi;
		private System.Windows.Forms.Button butLogoff;
		private System.Windows.Forms.Button butThongke;
		private System.Windows.Forms.Button butDmgiuong;
		private System.Windows.Forms.Button butDatgiuong;
		private System.Windows.Forms.Button butChuyengiuong;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butDmloaiphong;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel pButton;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Panel pForm;
		private System.Windows.Forms.Button butKetxuat_2;
		private System.Windows.Forms.Button butGiugiuong;
		private System.Windows.Forms.Button butTivi;
		private System.ComponentModel.Container components = null;

		public frmMain(string tenform,int userid)
		{
			InitializeComponent();
			this.s_tenform=tenform;
			this.i_userid=userid;
			if(System.IO.File.Exists(@"..\..\..\xml\g_datgiuonglog.xml"))
			{
				dsxml.ReadXml(@"..\..\..\xml\g_datgiuonglog.xml",XmlReadMode.ReadSchema);
				s_log=dsxml.Tables[0].Rows[0]["loai"].ToString();
			}
			if(s_log=="1"||s_log=="") 
			{
				i_log=1;
				pKhoaphong.Visible=false;
			}
			else 
			{
				i_log=0;
				pVienphi.Visible=false;
			}
		}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.pSplit = new System.Windows.Forms.Panel();
			this.pKhoaphong = new System.Windows.Forms.Panel();
			this.butExit = new System.Windows.Forms.Button();
			this.butXem = new System.Windows.Forms.Button();
			this.butKetxuat_2 = new System.Windows.Forms.Button();
			this.pVienphi = new System.Windows.Forms.Panel();
			this.butLogoff = new System.Windows.Forms.Button();
			this.butThongke = new System.Windows.Forms.Button();
			this.butDmgiuong = new System.Windows.Forms.Button();
			this.butDatgiuong = new System.Windows.Forms.Button();
			this.butTivi = new System.Windows.Forms.Button();
			this.butChuyengiuong = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.butGiugiuong = new System.Windows.Forms.Button();
			this.butDmloaiphong = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.pButton = new System.Windows.Forms.Panel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.pForm = new System.Windows.Forms.Panel();
			this.pKhoaphong.SuspendLayout();
			this.pVienphi.SuspendLayout();
			this.pButton.SuspendLayout();
			this.pForm.SuspendLayout();
			this.SuspendLayout();
			// 
			// pSplit
			// 
			this.pSplit.BackColor = System.Drawing.Color.SteelBlue;
			this.pSplit.Dock = System.Windows.Forms.DockStyle.Top;
			this.pSplit.Location = new System.Drawing.Point(0, 24);
			this.pSplit.Name = "pSplit";
			this.pSplit.Size = new System.Drawing.Size(792, 3);
			this.pSplit.TabIndex = 7;
			// 
			// pKhoaphong
			// 
			this.pKhoaphong.BackColor = System.Drawing.Color.SteelBlue;
			this.pKhoaphong.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.butExit,
																					 this.butXem,
																					 this.butKetxuat_2});
			this.pKhoaphong.Dock = System.Windows.Forms.DockStyle.Top;
			this.pKhoaphong.Location = new System.Drawing.Point(0, 26);
			this.pKhoaphong.Name = "pKhoaphong";
			this.pKhoaphong.Size = new System.Drawing.Size(792, 26);
			this.pKhoaphong.TabIndex = 9;
			// 
			// butExit
			// 
			this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.butExit.BackColor = System.Drawing.Color.RoyalBlue;
			this.butExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butExit.ForeColor = System.Drawing.Color.White;
			this.butExit.Location = new System.Drawing.Point(530, 0);
			this.butExit.Name = "butExit";
			this.butExit.Size = new System.Drawing.Size(262, 24);
			this.butExit.TabIndex = 8;
			this.butExit.Text = "Kết thúc";
			this.butExit.Click += new System.EventHandler(this.butExit_Click);
			// 
			// butXem
			// 
			this.butXem.BackColor = System.Drawing.Color.RoyalBlue;
			this.butXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butXem.ForeColor = System.Drawing.Color.White;
			this.butXem.Name = "butXem";
			this.butXem.Size = new System.Drawing.Size(263, 24);
			this.butXem.TabIndex = 8;
			this.butXem.Text = "Xem phòng giường";
			this.butXem.Click += new System.EventHandler(this.butXem_Click);
			// 
			// butKetxuat_2
			// 
			this.butKetxuat_2.BackColor = System.Drawing.Color.RoyalBlue;
			this.butKetxuat_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butKetxuat_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butKetxuat_2.ForeColor = System.Drawing.Color.MintCream;
			this.butKetxuat_2.Location = new System.Drawing.Point(265, 0);
			this.butKetxuat_2.Name = "butKetxuat_2";
			this.butKetxuat_2.Size = new System.Drawing.Size(263, 24);
			this.butKetxuat_2.TabIndex = 9;
			this.butKetxuat_2.Text = "Kết xuất Tivi";
			this.butKetxuat_2.Click += new System.EventHandler(this.butTivi_Click);
			// 
			// pVienphi
			// 
			this.pVienphi.BackColor = System.Drawing.Color.SteelBlue;
			this.pVienphi.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.butLogoff,
																				   this.butThongke,
																				   this.butDmgiuong,
																				   this.butDatgiuong,
																				   this.butTivi,
																				   this.butChuyengiuong,
																				   this.butKetthuc,
																				   this.butGiugiuong});
			this.pVienphi.Dock = System.Windows.Forms.DockStyle.Top;
			this.pVienphi.Name = "pVienphi";
			this.pVienphi.Size = new System.Drawing.Size(792, 26);
			this.pVienphi.TabIndex = 8;
			// 
			// butLogoff
			// 
			this.butLogoff.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.butLogoff.BackColor = System.Drawing.Color.RoyalBlue;
			this.butLogoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butLogoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butLogoff.ForeColor = System.Drawing.Color.MintCream;
			this.butLogoff.Location = new System.Drawing.Point(726, 0);
			this.butLogoff.Name = "butLogoff";
			this.butLogoff.Size = new System.Drawing.Size(64, 24);
			this.butLogoff.TabIndex = 7;
			this.butLogoff.Text = "Log off...";
			this.butLogoff.Click += new System.EventHandler(this.butLogoff_Click);
			// 
			// butThongke
			// 
			this.butThongke.BackColor = System.Drawing.Color.RoyalBlue;
			this.butThongke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butThongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butThongke.ForeColor = System.Drawing.Color.MintCream;
			this.butThongke.Location = new System.Drawing.Point(223, 0);
			this.butThongke.Name = "butThongke";
			this.butThongke.Size = new System.Drawing.Size(110, 24);
			this.butThongke.TabIndex = 7;
			this.butThongke.Text = "Thống kê báo cáo";
			this.butThongke.Click += new System.EventHandler(this.butThongke_Click);
			// 
			// butDmgiuong
			// 
			this.butDmgiuong.BackColor = System.Drawing.Color.RoyalBlue;
			this.butDmgiuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butDmgiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butDmgiuong.ForeColor = System.Drawing.Color.MintCream;
			this.butDmgiuong.Location = new System.Drawing.Point(3, 0);
			this.butDmgiuong.Name = "butDmgiuong";
			this.butDmgiuong.Size = new System.Drawing.Size(112, 24);
			this.butDmgiuong.TabIndex = 1;
			this.butDmgiuong.Text = "Danh mục giường";
			this.butDmgiuong.Click += new System.EventHandler(this.butDmgiuong_Click);
			// 
			// butDatgiuong
			// 
			this.butDatgiuong.BackColor = System.Drawing.Color.RoyalBlue;
			this.butDatgiuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butDatgiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butDatgiuong.ForeColor = System.Drawing.Color.MintCream;
			this.butDatgiuong.Location = new System.Drawing.Point(429, 0);
			this.butDatgiuong.Name = "butDatgiuong";
			this.butDatgiuong.Size = new System.Drawing.Size(103, 24);
			this.butDatgiuong.TabIndex = 0;
			this.butDatgiuong.Text = "Đặt giường";
			this.butDatgiuong.Click += new System.EventHandler(this.butDatgiuong_Click);
			// 
			// butTivi
			// 
			this.butTivi.BackColor = System.Drawing.Color.RoyalBlue;
			this.butTivi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butTivi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butTivi.ForeColor = System.Drawing.Color.MintCream;
			this.butTivi.Location = new System.Drawing.Point(117, 0);
			this.butTivi.Name = "butTivi";
			this.butTivi.Size = new System.Drawing.Size(104, 24);
			this.butTivi.TabIndex = 2;
			this.butTivi.Text = "Kết xuất Tivi";
			this.butTivi.Click += new System.EventHandler(this.butTivi_Click);
			// 
			// butChuyengiuong
			// 
			this.butChuyengiuong.BackColor = System.Drawing.Color.RoyalBlue;
			this.butChuyengiuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butChuyengiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butChuyengiuong.ForeColor = System.Drawing.Color.MintCream;
			this.butChuyengiuong.Location = new System.Drawing.Point(535, 0);
			this.butChuyengiuong.Name = "butChuyengiuong";
			this.butChuyengiuong.Size = new System.Drawing.Size(97, 24);
			this.butChuyengiuong.TabIndex = 4;
			this.butChuyengiuong.Text = "Chuyển giường";
			this.butChuyengiuong.Click += new System.EventHandler(this.butChuyengiuong_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.BackColor = System.Drawing.Color.RoyalBlue;
			this.butKetthuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butKetthuc.ForeColor = System.Drawing.Color.MintCream;
			this.butKetthuc.Location = new System.Drawing.Point(635, 0);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(88, 24);
			this.butKetthuc.TabIndex = 3;
			this.butKetthuc.Text = "Kết thúc";
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// butGiugiuong
			// 
			this.butGiugiuong.BackColor = System.Drawing.Color.RoyalBlue;
			this.butGiugiuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butGiugiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butGiugiuong.ForeColor = System.Drawing.Color.MintCream;
			this.butGiugiuong.Location = new System.Drawing.Point(336, 0);
			this.butGiugiuong.Name = "butGiugiuong";
			this.butGiugiuong.Size = new System.Drawing.Size(90, 24);
			this.butGiugiuong.TabIndex = 8;
			this.butGiugiuong.Text = "Giữ giường";
			this.butGiugiuong.Click += new System.EventHandler(this.butGiugiuong_Click);
			// 
			// butDmloaiphong
			// 
			this.butDmloaiphong.BackColor = System.Drawing.Color.RoyalBlue;
			this.butDmloaiphong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butDmloaiphong.ForeColor = System.Drawing.Color.White;
			this.butDmloaiphong.Location = new System.Drawing.Point(9, 80);
			this.butDmloaiphong.Name = "butDmloaiphong";
			this.butDmloaiphong.Size = new System.Drawing.Size(128, 24);
			this.butDmloaiphong.TabIndex = 5;
			this.butDmloaiphong.Text = "Danh mục loại phòng";
			this.butDmloaiphong.Visible = false;
			this.butDmloaiphong.Click += new System.EventHandler(this.butDmloaiphong_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.RoyalBlue;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(726, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 6;
			this.button1.Text = "XK";
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pButton
			// 
			this.pButton.BackColor = System.Drawing.Color.SteelBlue;
			this.pButton.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.pKhoaphong,
																				  this.pVienphi,
																				  this.butDmloaiphong,
																				  this.button1});
			this.pButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.pButton.Name = "pButton";
			this.pButton.Size = new System.Drawing.Size(792, 24);
			this.pButton.TabIndex = 6;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.ItemHeight = 13;
			this.comboBox1.Location = new System.Drawing.Point(224, -40);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(216, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.Visible = false;
			// 
			// pForm
			// 
			this.pForm.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("pForm.BackgroundImage")));
			this.pForm.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.comboBox1});
			this.pForm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pForm.Location = new System.Drawing.Point(0, 27);
			this.pForm.Name = "pForm";
			this.pForm.Size = new System.Drawing.Size(792, 546);
			this.pForm.TabIndex = 8;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pForm,
																		  this.pSplit,
																		  this.pButton});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý phòng giường";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
			this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.pKhoaphong.ResumeLayout(false);
			this.pVienphi.ResumeLayout(false);
			this.pButton.ResumeLayout(false);
			this.pForm.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain("",1));
		}
		private void butDmloaiphong_Click(object sender, System.EventArgs e)
		{
			LoadForm("frmDmloaiphong");
		}
		private void LoadForm(string tenform)
		{
			switch(tenform.ToLower().Trim())
			{
				case "frmdmloaiphong": 
					frmDmloaiphong f=new frmDmloaiphong(m,i_userid);
					f.ShowDialog();
					break;
				case "frmdmphong": 
					frmDmphong f1=new frmDmphong(m,i_userid);
					f1.ShowDialog();
					break;
				case "frmdmgiuong": 
					frmDmgiuong f2=new frmDmgiuong(m,i_userid);
					f2.ShowDialog();
					break;
				case "frmchuyenphong": 
					
					break;
			}
		}

		private void butDmphong_Click(object sender, System.EventArgs e)
		{
			
		}

		private void butDmgiuong_Click(object sender, System.EventArgs e)
		{
			LoadForm("frmDmgiuong");
		}

		private void butDatgiuong_Click(object sender, System.EventArgs e)
		{
			if(MdiChildren.Length>0) return;
			frmDatphong f=new frmDatphong(m,i_userid);
			f.ShowInTaskbar=false;
			f.MdiParent=this;
			f.Show();
			f.Dock=DockStyle.Fill;
			f.BringToFront();
			f.Left=pForm.Left;
			f.Top=pForm.Top;
			f.Height=pForm.Height;
			f.Width=pForm.Width;
			pForm.SendToBack();
//			if (Screen.PrimaryScreen.WorkingArea.Width >= 800) 
//			{
				pButton.Dock=DockStyle.None;
				pButton.Visible=false;
//			}
		}

		private void butChuyengiuong_Click(object sender, System.EventArgs e)
		{
            return;//
			if(MdiChildren.Length>0) return;
			frmChuyenphong f=new frmChuyenphong(m,m.DateToString("dd/MM/yyyy",DateTime.Now.Date),"","",i_userid,"",0);
			f.ShowInTaskbar=false;
			f.MdiParent=this;
			f.Show();
			f.Dock=DockStyle.Fill;
			f.BringToFront();
			f.Left=pForm.Left;
			f.Top=pForm.Top;
			f.Height=pForm.Height;
			f.Width=pForm.Width;
			pForm.SendToBack();
//			if (Screen.PrimaryScreen.WorkingArea.Width >= 800) 
//			{
				pButton.Dock=DockStyle.None;
				pButton.Visible=false;
//			}
		}

		private void frmMain_MdiChildActivate(object sender, System.EventArgs e)
		{
			pForm.BringToFront();
//			if (Screen.PrimaryScreen.WorkingArea.Width >= 800) 
//			{
				pButton.Visible=true;
				pButton.Dock=DockStyle.Top;
//			}
		}
		private void frmMain_Load(object sender, System.EventArgs e)
		{
            s_user = m.user;
			comboBox1.DisplayMember="TENKP";
			comboBox1.ValueMember="MAKP";
            comboBox1.DataSource = m.get_data("select * from " + s_user + ".btdkp_bv where loai=0").Tables[0];
			frmLogin f=new frmLogin(i_log);
			f.ShowDialog(this);
			if(f.s_hoten!="")
			{
				i_userid=f.i_userid;
				s_makp=f.s_makp;
				this.Text="Quản lý phòng giường - ["+f.s_hoten+"]";
//				if (Screen.PrimaryScreen.WorkingArea.Width >= 800) 
//				{
//					this.WindowState = System.Windows.Forms.FormWindowState.Normal;
//				}
			}
			else Application.Exit();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            //frmXuatkhoa f=new frmXuatkhoa(m,comboBox1.SelectedValue.ToString(),"",1,205,false,false,"","","");
            //f.ShowDialog();
		}

		private void butLogoff_Click(object sender, System.EventArgs e)
		{
			frmLogin f=new frmLogin(i_log);
			f.ShowDialog(this);
			if(f.s_hoten!="")
			{
				i_userid=f.i_userid;
				s_makp=f.s_makp;
				this.Text="Quản lý phòng giường - ["+f.s_hoten+"]";
//				if (Screen.PrimaryScreen.WorkingArea.Width >= 800) 
//				{
//					this.WindowState = System.Windows.Forms.FormWindowState.Normal;
//				}
			}
			else Application.Exit();
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			frmDsgiuong f=new frmDsgiuong(m,s_makp.Trim(','),true);
			f.ShowDialog();
		}

		private void butThongke_Click(object sender, System.EventArgs e)
		{
			frmThongke f=new frmThongke(i_userid);
			f.ShowDialog();
		}

		private void butTivi_Click(object sender, System.EventArgs e)
		{
			frmCauhinhTivi f=new frmCauhinhTivi(m);
			f.ShowInTaskbar=false;
			f.Show();
//			if(f.bTrue)
//			{
//				frmExportTivi fi=new frmExportTivi(m);
//				fi.ShowDialog();
//			}
		}

		private void frmMain_SizeChanged(object sender, System.EventArgs e)
		{
			int iChange=(this.Width-792)/8;
//			butDmphong.Width=104+iChange;
			butDmgiuong.Width=112+iChange;
//			butDmgiuong.Location=new Point(108+iChange,0);
			butTivi.Width=104+iChange;
			butTivi.Location=new Point(117+iChange,0);
			butThongke.Width=110+iChange;
			butThongke.Location=new Point(223+iChange*2,0);
			butGiugiuong.Width=90+iChange;
			butGiugiuong.Location=new Point(336+iChange*3,0);
			butDatgiuong.Width=103+iChange;
			butDatgiuong.Location=new Point(429+iChange*4,0);
			butChuyengiuong.Width=97+iChange;
			butChuyengiuong.Location=new Point(535+iChange*5,0);
			butKetthuc.Width=88+iChange;
			butKetthuc.Location=new Point(635+iChange*6,0);
			butLogoff.Width=64+iChange-8;
			butLogoff.Location=new Point(726+iChange*7,0);
			//
			int iChange2=(this.Width-792)/3;
			butXem.Width=263+iChange2;
			butKetxuat_2.Width=263+iChange2;
			butKetxuat_2.Location=new Point(265+iChange2,0);
			butExit.Width=263+iChange2;
			butExit.Location=new Point(530+iChange2*2,0);
		}

		private void butGiugiuong_Click(object sender, System.EventArgs e)
		{
			frmDsgiuong f=new frmDsgiuong(m,"",true);
			f.ShowDialog();
		}
	}
}
