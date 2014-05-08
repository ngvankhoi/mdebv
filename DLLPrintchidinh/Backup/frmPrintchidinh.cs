using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using System.Data;
using System.Xml;
using LibMedi;

namespace Medisoft
{
	public class frmPrintchidinh : System.Windows.Forms.Form
	{
		private LibMedi.AccessData m_m;
		private string m_sql="";
		//linh 11/09/2006
		string s_ngay="",s_mmyy="";
		private DataSet m_ds=new DataSet();
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtMabn;
		private System.Windows.Forms.TextBox txtHoten;
		private System.Windows.Forms.TextBox txtNgaysinh;
		private System.Windows.Forms.TextBox txtGioitinh;
		private System.Windows.Forms.ComboBox cbNgayvv;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.RadioButton rd1;
		private System.Windows.Forms.RadioButton rd2;
		private System.Windows.Forms.RadioButton rd3;
		private System.Windows.Forms.ComboBox cbPhieu;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button butIn;
		private System.ComponentModel.Container components = null;
		
		public frmPrintchidinh()
		{
			InitializeComponent();
			m_m =  new LibMedi.AccessData();
			if(s_ngay.Trim()=="")s_ngay=DateTime.Now.Day.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Month.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Year.ToString();
			s_mmyy=s_ngay.Substring(3,2)+s_ngay.Substring(8,2);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v_userid">dlogin.id.ToString()</param>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrintchidinh));
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.cbPhieu = new System.Windows.Forms.ComboBox();
			this.butXem = new System.Windows.Forms.Button();
			this.cbNgayvv = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtGioitinh = new System.Windows.Forms.TextBox();
			this.txtNgaysinh = new System.Windows.Forms.TextBox();
			this.txtHoten = new System.Windows.Forms.TextBox();
			this.txtMabn = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.rd3 = new System.Windows.Forms.RadioButton();
			this.rd2 = new System.Windows.Forms.RadioButton();
			this.rd1 = new System.Windows.Forms.RadioButton();
			this.butIn = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.BackColor = System.Drawing.SystemColors.Control;
			this.crystalReportViewer1.DisplayGroupTree = false;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 50);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = null;
			this.crystalReportViewer1.Size = new System.Drawing.Size(792, 523);
			this.crystalReportViewer1.TabIndex = 85;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.button1,
																				 this.label6,
																				 this.cbPhieu,
																				 this.butXem,
																				 this.cbNgayvv,
																				 this.label5,
																				 this.txtGioitinh,
																				 this.txtNgaysinh,
																				 this.txtHoten,
																				 this.txtMabn,
																				 this.label4,
																				 this.label3,
																				 this.label2,
																				 this.label1,
																				 this.rd3,
																				 this.rd2,
																				 this.rd1});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 50);
			this.panel1.TabIndex = 86;
			// 
			// button1
			// 
			this.button1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.button1.ForeColor = System.Drawing.Color.Blue;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(725, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 21);
			this.button1.TabIndex = 16;
			this.button1.Text = "&Kết thúc";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label6
			// 
			this.label6.ContextMenu = this.contextMenu1;
			this.label6.Location = new System.Drawing.Point(184, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 21);
			this.label6.TabIndex = 15;
			this.label6.Text = "Phiếu:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Khai báo thông số phiếu xét nghiệm";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// cbPhieu
			// 
			this.cbPhieu.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.cbPhieu.BackColor = System.Drawing.Color.White;
			this.cbPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPhieu.Location = new System.Drawing.Point(248, 24);
			this.cbPhieu.Name = "cbPhieu";
			this.cbPhieu.Size = new System.Drawing.Size(234, 21);
			this.cbPhieu.TabIndex = 5;
			this.cbPhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			this.cbPhieu.SelectionChangeCommitted += new System.EventHandler(this.cbPhieu_SelectionChangeCommitted);
			// 
			// butXem
			// 
			this.butXem.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.butXem.ForeColor = System.Drawing.Color.Blue;
			this.butXem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butXem.Image")));
			this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butXem.Location = new System.Drawing.Point(725, 3);
			this.butXem.Name = "butXem";
			this.butXem.Size = new System.Drawing.Size(64, 21);
			this.butXem.TabIndex = 9;
			this.butXem.Text = "       &Xem";
			this.butXem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butXem.Click += new System.EventHandler(this.butXem_Click);
			// 
			// cbNgayvv
			// 
			this.cbNgayvv.BackColor = System.Drawing.Color.White;
			this.cbNgayvv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbNgayvv.Location = new System.Drawing.Point(58, 25);
			this.cbNgayvv.Name = "cbNgayvv";
			this.cbNgayvv.Size = new System.Drawing.Size(110, 21);
			this.cbNgayvv.TabIndex = 4;
			this.cbNgayvv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(-11, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Ngày VV:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGioitinh
			// 
			this.txtGioitinh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.txtGioitinh.BackColor = System.Drawing.Color.White;
			this.txtGioitinh.Enabled = false;
			this.txtGioitinh.Location = new System.Drawing.Point(670, 4);
			this.txtGioitinh.Name = "txtGioitinh";
			this.txtGioitinh.Size = new System.Drawing.Size(53, 20);
			this.txtGioitinh.TabIndex = 3;
			this.txtGioitinh.Text = "";
			this.txtGioitinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			// 
			// txtNgaysinh
			// 
			this.txtNgaysinh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.txtNgaysinh.BackColor = System.Drawing.Color.White;
			this.txtNgaysinh.Enabled = false;
			this.txtNgaysinh.Location = new System.Drawing.Point(542, 4);
			this.txtNgaysinh.Name = "txtNgaysinh";
			this.txtNgaysinh.Size = new System.Drawing.Size(72, 20);
			this.txtNgaysinh.TabIndex = 2;
			this.txtNgaysinh.Text = "";
			this.txtNgaysinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			// 
			// txtHoten
			// 
			this.txtHoten.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtHoten.BackColor = System.Drawing.Color.White;
			this.txtHoten.Enabled = false;
			this.txtHoten.Location = new System.Drawing.Point(248, 4);
			this.txtHoten.Name = "txtHoten";
			this.txtHoten.Size = new System.Drawing.Size(234, 20);
			this.txtHoten.TabIndex = 1;
			this.txtHoten.Text = "";
			this.txtHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			// 
			// txtMabn
			// 
			this.txtMabn.BackColor = System.Drawing.Color.White;
			this.txtMabn.Location = new System.Drawing.Point(58, 4);
			this.txtMabn.MaxLength = 8;
			this.txtMabn.Name = "txtMabn";
			this.txtMabn.Size = new System.Drawing.Size(110, 20);
			this.txtMabn.TabIndex = 0;
			this.txtMabn.Text = "";
			this.txtMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			this.txtMabn.Validated += new System.EventHandler(this.txtMabn_Validated);
			// 
			// label4
			// 
			this.label4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label4.Location = new System.Drawing.Point(614, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "Giới tính:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label3.Location = new System.Drawing.Point(478, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Ngày sinh:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(184, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Họ và tên:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã BN:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// rd3
			// 
			this.rd3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.rd3.Location = new System.Drawing.Point(661, 25);
			this.rd3.Name = "rd3";
			this.rd3.Size = new System.Drawing.Size(72, 21);
			this.rd3.TabIndex = 8;
			this.rd3.Text = "Tất cả";
			this.rd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			// 
			// rd2
			// 
			this.rd2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.rd2.Checked = true;
			this.rd2.Location = new System.Drawing.Point(597, 25);
			this.rd2.Name = "rd2";
			this.rd2.Size = new System.Drawing.Size(72, 21);
			this.rd2.TabIndex = 7;
			this.rd2.TabStop = true;
			this.rd2.Text = "Chưa làm";
			this.rd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			// 
			// rd1
			// 
			this.rd1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.rd1.Location = new System.Drawing.Point(541, 25);
			this.rd1.Name = "rd1";
			this.rd1.Size = new System.Drawing.Size(64, 21);
			this.rd1.TabIndex = 6;
			this.rd1.Text = "Đã làm";
			this.rd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
			// 
			// butIn
			// 
			this.butIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butIn.ForeColor = System.Drawing.Color.Black;
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.Location = new System.Drawing.Point(140, 51);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(28, 21);
			this.butIn.TabIndex = 17;
			this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// frmPrintchidinh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butIn,
																		  this.crystalReportViewer1,
																		  this.panel1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmPrintchidinh";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintchidinh_KeyDown);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private string f_GetNgay(string v_ngay)
		{
			try
			{
				return "Ngày " + v_ngay.Substring(0,2) + " tháng " + v_ngay.Substring(3,2) + " năm " + v_ngay.Substring(6);
			}
			catch
			{
				return "";
			}
		}
		private void f_Load_HC()
		{
			try
			{
				string amabn="";
				amabn=txtMabn.Text.Trim();
				if(amabn.Length<8)
				{
					if(amabn.Length>=3)
					{
						amabn=amabn.Substring(0,2)+amabn.Substring(2).PadLeft(6,'0');
					}
					else
					if(amabn.Length>=1)
					{
						amabn=DateTime.Now.Year.ToString().Substring(2)+amabn.PadLeft(6,'0');
					}
				}
				txtMabn.Text="";
				txtHoten.Text="";
				txtNgaysinh.Text="";
				txtGioitinh.Text="";

				foreach(DataRow r in m_m.get_data("select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, e.ten phai, a.sonha, a.thon,a.cholam, b.tentt, c.tenquan, d.tenpxa from btdbn a, btdtt b, btdquan c, btdpxa d, dmphai e where a.phai=e.ma(+) and a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and mabn='"+amabn+"'").Tables[0].Rows)
				{
					txtMabn.Text=r["mabn"].ToString();
					txtHoten.Text=r["hoten"].ToString();
					txtNgaysinh.Text=r["ngaysinh"].ToString();
					txtGioitinh.Text=r["phai"].ToString();
					break;
				}
				cbNgayvv.DisplayMember="NGAY";
				cbNgayvv.ValueMember="MAQL";
				//linh 11/09/2006
				//cbNgayvv.DataSource=m_m.get_data("select to_char(max(ngay),'dd/mm/yyyy hh24:mi') ngay, maql from (select mabn, maql, ngay from benhandt where mabn='"+amabn+"' union select mabn,maql,ngay from tiepdon where mabn='"+amabn+"') group by maql order by to_date(ngay,'dd/mm/yyyy hh24:mi') desc").Tables[0];
				//cbNgayvv.DataSource=m_m.get_data("select to_char(max(ngay),'dd/mm/yyyy hh24:mi') ngay, maql from (select mabn, maql, ngay from (select mabn, maql, ngay from benhandt union all select mabn, maql, ngay from "+m_m.user+s_mmyy+".benhandt union all select mabn, maql, ngay from "+m_m.user+m_m.Mmyy_truoc(s_mmyy)+".benhandt) where mabn='"+amabn+"' union select mabn,maql,ngay from "+m_m.user+s_mmyy+".tiepdon where mabn='"+amabn+"') group by maql order by to_date(ngay,'dd/mm/yyyy hh24:mi') desc").Tables[0];
				cbNgayvv.DataSource=m_m.get_data("select to_char(max(ngay),'dd/mm/yyyy hh24:mi') ngay, maql from (select mabn, maql, ngay from (select mabn, maql, ngay from benhandt union all select mabn, maql, ngay from "+m_m.user+s_mmyy+".benhandt) where mabn='"+amabn+"' union select mabn,maql,ngay from "+m_m.user+s_mmyy+".tiepdon where mabn='"+amabn+"') group by maql order by to_date(ngay,'dd/mm/yyyy hh24:mi') desc").Tables[0];
				//end linh
			}
			catch
			{
			}
		}
		private void f_Load_HC(string _mmyy)
		{
			try
			{
				string amabn="";
				amabn=txtMabn.Text.Trim();
				if(amabn.Length<8)
				{
					if(amabn.Length>=3)
					{
						amabn=amabn.Substring(0,2)+amabn.Substring(2).PadLeft(6,'0');
					}
					else
						if(amabn.Length>=1)
					{
						amabn=DateTime.Now.Year.ToString().Substring(2)+amabn.PadLeft(6,'0');
					}
				}
				txtMabn.Text="";
				txtHoten.Text="";
				txtNgaysinh.Text="";
				txtGioitinh.Text="";

				foreach(DataRow r in m_m.get_data("select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, e.ten phai, a.sonha, a.thon,a.cholam, b.tentt, c.tenquan, d.tenpxa from btdbn a, btdtt b, btdquan c, btdpxa d, dmphai e where a.phai=e.ma(+) and a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and mabn='"+amabn+"'").Tables[0].Rows)
				{
					txtMabn.Text=r["mabn"].ToString();
					txtHoten.Text=r["hoten"].ToString();
					txtNgaysinh.Text=r["ngaysinh"].ToString();
					txtGioitinh.Text=r["phai"].ToString();
					break;
				}
				cbNgayvv.DisplayMember="NGAY";
				cbNgayvv.ValueMember="MAQL";
				cbNgayvv.DataSource=m_m.get_data("select to_char(max(ngay),'dd/mm/yyyy hh24:mi') ngay, maql from (select mabn, maql, ngay from (select mabn, maql, ngay from benhandt union all select mabn, maql, ngay from "+m_m.user+_mmyy+".benhandt) where mabn='"+amabn+"' union select mabn,maql,ngay from "+m_m.user+_mmyy+".tiepdon where mabn='"+amabn+"') group by maql order by to_date(ngay,'dd/mm/yyyy hh24:mi') desc").Tables[0];
			}
			catch
			{
			}
		}
		public void f_Print_Chidinh(bool v_dir, string v_mabn, string v_maql, string v_done)
		{
//			if(!v_dir)
//			{
//				this.TopMost=true;
//				this.Show();
//			}
			try
			{
				this.Text="In phiếu chỉ định dịch vụ";
				txtMabn.Text=v_mabn;
				f_Load_HC();
				try
				{
					cbNgayvv.SelectedValue=v_maql;
				}
				catch
				{
				}
				f_Load_Chidinh(v_dir);
				if(v_dir)
				{
					for(int i=0;i<cbPhieu.Items.Count;i++)
					{
						cbPhieu.SelectedIndex=i;
						f_Preview_Chidinh(v_dir,s_mmyy);
					}
				}
				else
				{
					f_Preview_Chidinh(v_dir,s_mmyy);
				}
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_Chidinh(bool v_dir, string v_mabn, string v_maql, string v_done,string v_ngay)
		{
			string _mmyy="";
			if(v_ngay=="")_mmyy=s_mmyy;
			else _mmyy=v_ngay.Substring(0,2).PadLeft(2,'0')+v_ngay.Substring(8,2);
			try
			{
				this.Text="In phiếu chỉ định dịch vụ";
				txtMabn.Text=v_mabn;
				f_Load_HC(_mmyy);
				try
				{
					cbNgayvv.SelectedValue=v_maql;
				}
				catch
				{
				}
				f_Load_Chidinh(v_dir,_mmyy);
				if(v_dir)
				{
					for(int i=0;i<cbPhieu.Items.Count;i++)
					{
						cbPhieu.SelectedIndex=i;
						f_Preview_Chidinh(v_dir,_mmyy);
					}
				}
				else
				{
					f_Preview_Chidinh(v_dir,_mmyy);
				}
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void f_Load_Chidinh(bool v_dir)
		{
			try
			{
				string amaql="",auser="";
				auser=m_m.user;
				try
				{
					amaql=cbNgayvv.SelectedValue.ToString();
				}
				catch
				{
				}
				this.Text="In phiếu chỉ định dịch vụ";
				m_ds.Dispose();
				m_ds=new DataSet();
				//m_sql="select distinct a.mabn, to_char(a.maql) maql, to_char(a.idkhoa) idkhoa,
				m_sql="select distinct a.mabn, to_char(a.maql) maql, to_char(a.idchidinh) idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay, to_char(nvl(a.tinhtrang,0)) tinhtrang, to_char(a.mavp) mavp, b.ten tenvp,trim(nvl(c.id,0)) id,lower(trim(nvl(c.report,'na_chidinhcls.rpt'))) report,trim(b.ten) val,a.mabs from "+auser+s_mmyy+".v_chidinh a, "+auser.Trim()+".v_giavp b,"+auser.Trim()+".cd_thongsophieucd c where a.mavp=b.id and a.mavp=c.mavp(+)";
				m_sql+=" and a.mabn='"+txtMabn.Text.Trim()+"'";
				m_sql+=" and to_char(a.maql)='"+amaql+"' and soluong>0";
				if(rd1.Checked)
				{
					m_sql+=" and to_char(a.done)='1'";
				}
				else
				if(rd2.Checked)
				{
					m_sql+=" and to_char(a.done)<>'1'";
				}
				m_ds = m_m.get_data(m_sql);
				DataSet ads1 = new DataSet();
				ads1.Tables.Add("Table");
				ads1.Tables[0].Columns.Add("report");
				ads1.Tables[0].Columns.Add("ngay");
				foreach(DataRow r in m_ds.Tables[0].Rows)
				{
					if(ads1.Tables[0].Select("report='"+r["report"].ToString()+"?"+r["ngay"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString()+"'").Length<=0)
					{
						ads1.Tables[0].Rows.Add(new string[] {r["report"].ToString()+"?"+r["ngay"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString(),r["ngay"].ToString()+" : "+r["report"].ToString()});
					}
				}
				if(ads1.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(this,"Không tìm thấy thông tin chỉ định <maql:"+cbNgayvv.SelectedValue.ToString()+">","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				cbPhieu.DisplayMember="ngay";
				cbPhieu.ValueMember="report";
				cbPhieu.DataSource=ads1.Tables[0];
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			if(m_ds.Tables[0].Rows.Count==0)butIn.Visible=false;
		}
		private void f_Load_Chidinh(bool v_dir,string _mmyy)
		{
			if(_mmyy=="")_mmyy=s_mmyy;
			try
			{
				string amaql="",auser="";
				auser=m_m.user;
				try
				{
					amaql=cbNgayvv.SelectedValue.ToString();
				}
				catch
				{
				}
				this.Text="In phiếu chỉ định dịch vụ";
				m_ds.Dispose();
				m_ds=new DataSet();
				//m_sql="select distinct a.mabn, to_char(a.maql) maql, to_char(a.idkhoa) idkhoa,
				m_sql="select distinct a.mabn, to_char(a.maql) maql, to_char(a.idchidinh) idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay, to_char(nvl(a.tinhtrang,0)) tinhtrang, to_char(a.mavp) mavp, b.ten tenvp,trim(nvl(c.id,0)) id,lower(trim(nvl(c.report,'na_chidinhcls.rpt'))) report,trim(b.ten) val,a.mabs from "+auser+_mmyy+".v_chidinh a, "+auser.Trim()+".v_giavp b,"+auser.Trim()+".cd_thongsophieucd c where a.mavp=b.id and a.mavp=c.mavp(+)";
				m_sql+=" and a.mabn='"+txtMabn.Text.Trim()+"'";
				m_sql+=" and to_char(a.maql)='"+amaql+"' and soluong>0";
				if(rd1.Checked)
				{
					m_sql+=" and to_char(a.done)='1'";
				}
				else
					if(rd2.Checked)
				{
					m_sql+=" and to_char(a.done)<>'1'";
				}
				m_ds = m_m.get_data(m_sql);
				DataSet ads1 = new DataSet();
				ads1.Tables.Add("Table");
				ads1.Tables[0].Columns.Add("report");
				ads1.Tables[0].Columns.Add("ngay");
				foreach(DataRow r in m_ds.Tables[0].Rows)
				{
					if(ads1.Tables[0].Select("report='"+r["report"].ToString()+"?"+r["ngay"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString()+"'").Length<=0)
					{
						ads1.Tables[0].Rows.Add(new string[] {r["report"].ToString()+"?"+r["ngay"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString(),r["ngay"].ToString()+" : "+r["report"].ToString()});
					}
				}
				if(ads1.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(this,"Không tìm thấy thông tin chỉ định <maql:"+cbNgayvv.SelectedValue.ToString()+">","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				cbPhieu.DisplayMember="ngay";
				cbPhieu.ValueMember="report";
				cbPhieu.DataSource=ads1.Tables[0];
			}
			catch
			{
			}
			if(m_ds.Tables[0].Rows.Count==0)butIn.Visible=false;
		}
		private void f_Preview_Chidinh(bool v_dir,string _mmyy)
		{
			if(_mmyy=="")_mmyy=s_mmyy;
			try
			{
				this.Text="In phiếu chỉ định dịch vụ";
				string asyt="",abv="",angayin="",anguoiin="",areport="";
				string amabn="",ahoten="",angaysinh="",aphai="",adiachi="",akhoa="",achandoan="",aicd="",atinhtrang="",aphonggiuong="",athekcb="",abacsi="";
				asyt = m_m.Syte;
				abv = m_m.Tenbv;
				
				angayin="";
				anguoiin="";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				foreach(DataRow r in m_m.get_data("select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, e.ten phai, a.sonha, a.thon,a.cholam, b.tentt, c.tenquan, d.tenpxa from btdbn a, btdtt b, btdquan c, btdpxa d, dmphai e where a.phai=e.ma(+) and a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and a.mabn='"+amabn+"'").Tables[0].Rows)
				{
					amabn=r["mabn"].ToString();
					ahoten=r["hoten"].ToString();
					angaysinh=r["ngaysinh"].ToString();
					aphai=r["phai"].ToString();
					adiachi=r["sonha"].ToString().Trim();
					adiachi+=" "+r["thon"].ToString().Trim();
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tenpxa"].ToString().Trim().Replace("Không xác định","");
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tenquan"].ToString().Trim().Replace("Không xác định","");
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tentt"].ToString().Trim().Replace("Không xác định","");
					break;
				}
				
				areport=cbPhieu.SelectedValue.ToString();
				string ang="",att="",amaql="",aidkhoa="";
				ang=areport.Split('?')[1];
				att=areport.Split('?')[2];
				amaql=areport.Split('?')[3];
				aidkhoa=areport.Split('?')[4];
				areport=areport.Split('?')[0];
				areport=areport.ToLower();
				string m_mabs="";
				try
				{
					foreach(DataRow r in m_m.get_data("select a.sothe from "+m_m.user+_mmyy+".bhyt a where to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
					{
						athekcb=r["sothe"].ToString();
						break;
					}
				}
				catch{}
				//khoa
				try
				{
					foreach(DataRow r in m_m.get_data("select nvl(d.giuong,a.giuong) giuong, a.maicd,a.chandoan, b.tenkp, c.hoten from nhapkhoa a, btdkp_bv b, dmbs c,(select idkhoa,giuong,mabs from d_dausinhton where id=(select max(id) from d_dausinhton where idkhoa="+aidkhoa+")) d where a.makp=b.makp(+) and a.id=d.idkhoa(+)and d.mabs=c.ma(+) and to_char(a.maql)='"+amaql+"' and to_char(a.id)='"+aidkhoa+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
					{
						akhoa=r["tenkp"].ToString();
						abacsi=r["hoten"].ToString();
						aphonggiuong=r["giuong"].ToString();
						aicd=r["maicd"].ToString();
						achandoan=r["chandoan"].ToString();
						break;
					}
				}
				catch{}

				if(akhoa=="")
				{
					try
					{
						foreach(DataRow r in m_m.get_data("select b.tenkp, c.hoten, a.maicd,a.chandoan from (select mabn,maql,makp,mabs,maicd,chandoan from benhandt where to_char(maql)='"+amaql+"' and mabn='"+amabn+"' union all select mabn,maql,makp,mabs,maicd,chandoan from "+m_m.user+_mmyy+".benhandt where to_char(maql)='"+amaql+"' and mabn='"+amabn+"') a, btdkp_bv b, dmbs c where a.makp=b.makp(+) and a.mabs=c.ma(+)").Tables[0].Rows)
						{
							akhoa=r["tenkp"].ToString();
							abacsi=r["hoten"].ToString();
							aicd=r["maicd"].ToString();
							achandoan=r["chandoan"].ToString();
							break;
						}
					}
					catch{}
				}

				if(akhoa=="")
				{
					try
					{
						foreach(DataRow r in m_m.get_data("select b.tenkp from "+m_m.user+_mmyy+".tiepdon a, btdkp_bv b where a.makp=b.makp(+) and to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
						{
							akhoa=r["tenkp"].ToString();
							break;
						}
					}
					catch
					{
					}
				}
				try
				{
					foreach(DataRow r in m_m.get_data("select distinct chandoan,mabs from "+m_m.user+_mmyy+".v_chidinh a where to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"' and (mabs is not null or chandoan is not null)").Tables[0].Rows)
					{
						if(r["mabs"].ToString().Trim()!="")m_mabs=r["mabs"].ToString().Trim();
						if(r["chandoan"].ToString().Trim()!="")achandoan=r["chandoan"].ToString();
						if(m_mabs!="" && achandoan!="")break;
					}
				}
				catch
				{}
				bool chuky=false;
				DataRow r2=null;
				DataSet ads = new DataSet();
				ads=m_m.get_data("select '' id,'' report,'' mavp,'' val,image from dmbs where ma='-9999'").Clone();
				foreach(DataRow r in m_ds.Tables[0].Select("report='"+areport+"' and ngay='"+ang+"' and tinhtrang='"+att+"' and idkhoa='"+aidkhoa+"' and maql="+amaql))
				{
					DataRow nr=ads.Tables[0].NewRow();
					nr["id"]=r["id"];
					nr["report"]=r["report"];
					nr["mavp"]=r["mavp"];
					nr["val"]=r["val"];
					try
					{
						if(m_mabs!="")
						{
							if(!chuky)
							{
								r2= m_m.get_data("select image,hoten from dmbs where ma='"+m_mabs+"'").Tables[0].Rows[0];
								abacsi=r2["hoten"].ToString();
								chuky=true;
							}
							nr["image"]=r2["image"];
						}
					}
					catch
					{}
					ads.Tables[0].Rows.Add(nr);
					ads.AcceptChanges();
				}
				if(!System.IO.File.Exists("..\\..\\..\\report\\"+areport))
				{
					MessageBox.Show("Không tìm thấy file: "+areport);
				}
				try
				{
					ReportDocument cMain=new ReportDocument();
					cMain.Load("..\\..\\..\\report\\"+areport);//, OpenReportMethod.OpenReportByDefault .OpenReportByTempCopy);
					cMain.SetDataSource(ads);
					cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
					cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
					cMain.DataDefinition.FormulaFields["v_mabn"].Text="'"+amabn+"'";
					cMain.DataDefinition.FormulaFields["v_hoten"].Text="'"+ahoten+"'";
					cMain.DataDefinition.FormulaFields["v_ngaysinh"].Text="'"+angaysinh+"'";
					cMain.DataDefinition.FormulaFields["v_phai"].Text="'"+aphai+"'";
					cMain.DataDefinition.FormulaFields["v_diachi"].Text="'"+adiachi+"'";
					cMain.DataDefinition.FormulaFields["v_khoa"].Text="'"+akhoa+"'";
					cMain.DataDefinition.FormulaFields["v_chandoan"].Text="'"+achandoan+"'";
					cMain.DataDefinition.FormulaFields["v_icd"].Text="'"+aicd+"'";
					cMain.DataDefinition.FormulaFields["v_thekcb"].Text="'"+athekcb+"'";
					cMain.DataDefinition.FormulaFields["v_phonggiuong"].Text="'"+aphonggiuong+"'";
					cMain.DataDefinition.FormulaFields["v_tinhtrang"].Text="'"+atinhtrang+"'";
					cMain.DataDefinition.FormulaFields["v_bacsi"].Text="'"+abacsi+"'";
					cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
					cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

					this.Text+="("+areport+")";
					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain;
						this.Show();
					}
					else
					{
						cMain.PrintToPrinter(1,false,0,0);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_VPKhoa(bool v_dir, string v_mabn, string v_maql, string v_done)
		{
			if(!v_dir)
			{
				this.TopMost=true;
				this.Show();
			}
			try
			{
				this.Text="In phiếu chỉ định dịch vụ";
				txtMabn.Text=v_mabn;
				f_Load_HC();
				try
				{
					cbNgayvv.SelectedValue=v_maql;
				}
				catch
				{
				}
				f_Load_VPKhoa(v_dir);
				if(v_dir)
				{
					for(int i=0;i<cbPhieu.Items.Count;i++)
					{
						cbPhieu.SelectedIndex=i;
						f_Preview_VPKhoa(v_dir);
					}
				}
				else
				{
					f_Preview_VPKhoa(v_dir);
				}
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void f_Load_VPKhoa(bool v_dir)
		{
			try
			{
				string amaql="",auser="";
				auser=m_m.user;
				try
				{
					amaql=cbNgayvv.SelectedValue.ToString();
				}
				catch
				{
				}
				this.Text="In phiếu chỉ định dịch vụ";
				m_sql="select a.mabn, to_char(a.maql) maql, to_char(a.idkhoa) idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay, 0 tinhtrang, to_char(a.mavp) mavp, sum(nvl(a.soluong,0)) soluong, b.ten tenvp from v_vpkhoa a, "+auser.Trim()+".v_giavp b where a.mavp=b.id";
				m_sql+=" and a.mabn='"+txtMabn.Text.Trim()+"'";
				m_sql+=" and to_char(a.maql)='"+amaql+"'";
				
				if(rd1.Checked)
				{
					m_sql+=" and to_char(a.done)='1'";
				}
				else
					if(rd2.Checked)
				{
					m_sql+=" and to_char(a.done)<>'1'";
				}

				m_sql+=" group by a.mabn,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy'), to_char(a.mavp), b.ten order by to_date(ngay,'dd/mm/yyyy') desc";

				m_ds = m_m.get_data_v(cbNgayvv.Text.Substring(8,2),m_sql);

				DataSet ads = new DataSet();
				try
				{
					ads=m_m.get_data("select trim(id) id,lower(trim(report)) report,trim(mavp) mavp,'' val from cd_thongsophieucd order by report");
				}
				catch
				{
					m_m.execute_data("create table cd_phieucd(reportname varchar2(100), constraint pk_cd_phieucd primary key(reportname))");
					ads=m_m.get_data("select trim(id) id,lower(trim(report)) report,trim(mavp) mavp,'' val from cd_thongsophieucd order by report");
				}
				
				foreach(DataRow r in ads.Tables[0].Rows)
				{
					r["val"]="";
					try
					{
						r["val"]=m_ds.Tables[0].Select("mavp='"+r["mavp"].ToString()+"'")[0]["tenvp"].ToString().Trim();
					}
					catch
					{
						r["val"]="";
					}
				}
				
				DataSet ads1 = new DataSet();
				ads1.Tables.Add("Table");
				ads1.Tables[0].Columns.Add("report");
				ads1.Tables[0].Columns.Add("ngay");
				foreach(DataRow r in m_ds.Tables[0].Rows)
				{
					foreach(DataRow r1 in ads.Tables[0].Select("mavp='"+r["mavp"].ToString()+"'"))
					{
						if(ads1.Tables[0].Select("report='"+r1["report"].ToString()+"?"+r["ngay"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString()+"'").Length<=0)
						{
							ads1.Tables[0].Rows.Add(new string[] {r1["report"].ToString()+"?"+r["ngay"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString(),r["ngay"].ToString()+" : "+r1["report"].ToString()});
						}
					}
				}
				if(ads1.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,"Không tìm thấy thông tin chỉ định <maql:"+cbNgayvv.SelectedValue.ToString()+">","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				cbPhieu.DisplayMember="ngay";
				cbPhieu.ValueMember="report";
				cbPhieu.DataSource=ads1.Tables[0];
			}
			catch(Exception ex)
			{
				//MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void f_Preview_VPKhoa(bool v_dir)
		{
			try
			{
				this.Text="In phiếu chỉ định dịch vụ";
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",areport="";
				string amabn="",ahoten="",angaysinh="",aphai="",adiachi="",akhoa="",achandoan="",aicd="",atinhtrang="",aphonggiuong="",athekcb="",abacsi="";
				asyt = m_m.Syte;
				abv = m_m.Tenbv;
				
				angayin="";
				anguoiin="";
				aghichu = "";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				foreach(DataRow r in m_m.get_data("select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, e.ten phai, a.sonha, a.thon,a.cholam, b.tentt, c.tenquan, d.tenpxa from btdbn a, btdtt b, btdquan c, btdpxa d, dmphai e where a.phai=e.ma(+) and a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and a.mabn='"+amabn+"'").Tables[0].Rows)
				{
					amabn=r["mabn"].ToString();
					ahoten=r["hoten"].ToString();
					angaysinh=r["ngaysinh"].ToString();
					aphai=r["phai"].ToString();
					adiachi=r["sonha"].ToString().Trim();
					adiachi+=" "+r["thon"].ToString().Trim();
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tenpxa"].ToString().Trim().Replace("Không xác định","");
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tenquan"].ToString().Trim().Replace("Không xác định","");
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tentt"].ToString().Trim().Replace("Không xác định","");
					break;
				}
				
				areport=cbPhieu.SelectedValue.ToString();
				string ang="",att="",amaql="",aidkhoa="";
				ang=areport.Split('?')[1];
				att=areport.Split('?')[2];
				amaql=areport.Split('?')[3];
				aidkhoa=areport.Split('?')[4];
				areport=areport.Split('?')[0];
				areport=areport.ToLower();

				DataSet ads = new DataSet();
				try
				{
					ads=m_m.get_data("select trim(id) id,lower(trim(report)) report,trim(mavp) mavp,'' val from cd_thongsophieucd where lower(trim(report))=trim('"+areport+"') order by report");
				}
				catch
				{
					m_m.execute_data("create table cd_phieucd(reportname varchar2(100), constraint pk_cd_phieucd primary key(reportname))");
					ads=m_m.get_data("select trim(id) id,lower(trim(report)) report,trim(mavp) mavp,'' val from cd_thongsophieucd where lower(trim(report))=trim('"+areport+"') order by report");
				}
				
				foreach(DataRow r in ads.Tables[0].Rows)
				{
					r["val"]="";
					if(r["report"].ToString()==areport)
					{
						try
						{
							r["val"]=m_ds.Tables[0].Select("mavp='"+r["mavp"].ToString()+"' and ngay='"+ang+"' and tinhtrang='"+att+"' and idkhoa='"+aidkhoa+"' and soluong>0")[0]["tenvp"].ToString().Trim();
						}
						catch
						{
							r["val"]="";
						}
					}
				}
				while(ads.Tables[0].Select("report<>'"+areport+"' or val=''").Length>0)
				{
					DataRow r=ads.Tables[0].Select("report<>'"+areport+"' or val=''")[0];
					ads.Tables[0].Rows.Remove(r);
				}

				try
				{
					foreach(DataRow r in m_m.get_data("select a.sothe from bhyt a where to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
					{
						athekcb=r["sothe"].ToString();
						break;
					}
				}
				catch
				{
				}

				//khoa
				try
				{
					foreach(DataRow r in m_m.get_data("select nvl(d.giuong,a.giuong) giuong, a.maicd,a.chandoan, b.tenkp, c.hoten from nhapkhoa a, btdkp_bv b, dmbs c,(select idkhoa,giuong,mabs from d_dausinhton where id=(select max(id) from d_dausinhton where idkhoa="+aidkhoa+")) d where a.makp=b.makp(+) and a.id=d.idkhoa(+) and d.mabs=c.ma(+) and to_char(a.maql)='"+amaql+"' and to_char(a.id)='"+aidkhoa+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
					{
						akhoa=r["tenkp"].ToString();
						abacsi=r["hoten"].ToString();
						aphonggiuong=r["giuong"].ToString();
						aicd=r["maicd"].ToString();
						achandoan=r["chandoan"].ToString();
						break;
					}
				}
				catch
				{
				}

				if(akhoa=="")
				{
					try
					{
						foreach(DataRow r in m_m.get_data("select b.tenkp, c.hoten, a.maicd,a.chandoan from benhandt a, btdkp_bv b, dmbs c where a.makp=b.makp(+) and a.mabs=c.ma(+) and to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
						{
							akhoa=r["tenkp"].ToString();
							abacsi=r["hoten"].ToString();
							aicd=r["maicd"].ToString();
							achandoan=r["chandoan"].ToString();
							break;
						}
					}
					catch
					{
					}
				}

				if(akhoa=="")
				{
					try
					{
						foreach(DataRow r in m_m.get_data("select b.tenkp from tiepdon a, btdkp_bv b where a.makp=b.makp(+) and to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
						{
							akhoa=r["tenkp"].ToString();
							break;
						}
					}
					catch
					{
					}
				}

				if(!System.IO.File.Exists("..\\..\\..\\report\\"+areport))
				{
					MessageBox.Show("Không tìm thấy file: "+areport);
				}
				try
				{
					ReportDocument cMain=new ReportDocument();
					cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
					cMain.SetDataSource(ads);
					cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
					cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
					cMain.DataDefinition.FormulaFields["v_mabn"].Text="'"+amabn+"'";
					cMain.DataDefinition.FormulaFields["v_hoten"].Text="'"+ahoten+"'";
					cMain.DataDefinition.FormulaFields["v_ngaysinh"].Text="'"+angaysinh+"'";
					cMain.DataDefinition.FormulaFields["v_phai"].Text="'"+aphai+"'";
					cMain.DataDefinition.FormulaFields["v_diachi"].Text="'"+adiachi+"'";
					cMain.DataDefinition.FormulaFields["v_khoa"].Text="'"+akhoa+"'";
					cMain.DataDefinition.FormulaFields["v_chandoan"].Text="'"+achandoan+"'";
					cMain.DataDefinition.FormulaFields["v_icd"].Text="'"+aicd+"'";
					cMain.DataDefinition.FormulaFields["v_thekcb"].Text="'"+athekcb+"'";
					cMain.DataDefinition.FormulaFields["v_phonggiuong"].Text="'"+aphonggiuong+"'";
					cMain.DataDefinition.FormulaFields["v_tinhtrang"].Text="'"+atinhtrang+"'";
					cMain.DataDefinition.FormulaFields["v_bacsi"].Text="'"+abacsi+"'";
					cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
					cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

					this.Text+="("+areport+")";
					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain;
					}
					else
					{
						cMain.PrintToPrinter(1,false,0,0);
					}
				}
				catch//(Exception ex)
				{
					//MessageBox.Show(ex.ToString());
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void frmPrintchidinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Escape)butIn.Visible=false;
				else if((e.KeyCode==Keys.P&&e.Control) && butIn.Visible )butIn_Click(null,null);
			}
			catch
			{
			}
		}

		private void txtMabn_Validated(object sender, System.EventArgs e)
		{
			f_Load_HC();
		}

		private void txtMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			f_Load_Chidinh(false);
			f_Preview_Chidinh(false,s_mmyy);
		}

		private void cbPhieu_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			f_Preview_Chidinh(false,s_mmyy);
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			frmDMThongsophieucd af = new frmDMThongsophieucd("","");
			af.ShowDialog();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			f_Preview_Chidinh(true,s_mmyy);
		}
	}
}
