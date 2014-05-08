using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibVP;

namespace Vienphi
{
	/// <summary>
	/// Summary description for frmKhaibaolocgiavienphi.
	/// </summary>
	public class frmKhaibaolocgiavienphi : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string m_userid="";
		private DataSet m_dsgiavp = new DataSet();
		private bool m_saved=false;
		private string m_loai="-1"; 
		private string m_tenloai="-1"; 
		private string m_file="v_option_khongthu_vpkhoa.xml";
        private string m_name="Viện phí khoa";

		private LibVP.AccessData m_v = new LibVP.AccessData();

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbNgayDN;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lbNguoiDN;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label lbStyle;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cbUser;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// v_loai:
		/// "-1": Khong thu trong vien phi khoa
		/// "-2": Không thu trong thu truc tiep
		/// "-3": Không thu trong thu theo chi dinh
		/// "-4": Không thu trong thanh toan ra vien noi tru
		/// "-5": Không thu trong thanh toan ra vien ngoai tru
		/// "1": Thu trong vien phi khoa
		/// "2": Thu trong thu truc tiep
		/// "3": Thu trong thu theo chi dinh
		/// "4": Thu trong thanh toan ra vien noi tru
		/// "5": Thu trong thanh toan ra vien ngoai tru
		/// "6": Tinh theo ngay (giường yêu cầu)
		/// "7": Tinh theo suat (suất ăn)
		/// </summary>
		/// <param name="v_userid"></param>
		/// <param name="v_loai"></param>
		public frmKhaibaolocgiavienphi(string v_userid,string v_loai)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            
			m_userid=v_userid;
			m_loai=v_loai;
			f_SetEvent(panel2);
            m_name = lan.Change_language_MessageText(m_name);
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhaibaolocgiavienphi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNgayDN = new System.Windows.Forms.Label();
            this.lbNguoiDN = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lbStyle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbNgayDN);
            this.panel1.Controls.Add(this.lbNguoiDN);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(788, 49);
            this.panel1.TabIndex = 16;
            // 
            // lbNgayDN
            // 
            this.lbNgayDN.ForeColor = System.Drawing.Color.White;
            this.lbNgayDN.Location = new System.Drawing.Point(633, 26);
            this.lbNgayDN.Name = "lbNgayDN";
            this.lbNgayDN.Size = new System.Drawing.Size(143, 13);
            this.lbNgayDN.TabIndex = 0;
            this.lbNgayDN.Text = "Ngày làm việc";
            this.lbNgayDN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNgayDN.Visible = false;
            // 
            // lbNguoiDN
            // 
            this.lbNguoiDN.ForeColor = System.Drawing.Color.White;
            this.lbNguoiDN.Location = new System.Drawing.Point(638, 5);
            this.lbNguoiDN.Name = "lbNguoiDN";
            this.lbNguoiDN.Size = new System.Drawing.Size(138, 18);
            this.lbNguoiDN.TabIndex = 66;
            this.lbNguoiDN.Text = "Người đăng nhập";
            this.lbNguoiDN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNguoiDN.Visible = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(71, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(721, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = " NỘI DUNG KHÔNG CHO PHÉP NHẬP TRONG VIỆN PHÍ KHOA";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(788, 3);
            this.label15.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel2.Size = new System.Drawing.Size(788, 453);
            this.panel2.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 412);
            this.tabControl1.TabIndex = 81;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.cbUser);
            this.panel3.Controls.Add(this.chkAll);
            this.panel3.Controls.Add(this.lbStyle);
            this.panel3.Controls.Add(this.butLuu);
            this.panel3.Controls.Add(this.butBoqua);
            this.panel3.Controls.Add(this.butKetthuc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(3, 415);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panel3.Size = new System.Drawing.Size(778, 34);
            this.panel3.TabIndex = 9;
            // 
            // cbUser
            // 
            this.cbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUser.Location = new System.Drawing.Point(242, 6);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(292, 21);
            this.cbUser.TabIndex = 5;
            this.cbUser.Validated += new System.EventHandler(this.cbUser_Validated);
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            // 
            // chkAll
            // 
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAll.Location = new System.Drawing.Point(34, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 28);
            this.chkAll.TabIndex = 4;
            this.chkAll.Text = "Chọn/Không chọn tất cả";
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lbStyle
            // 
            this.lbStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbStyle.ImageIndex = 0;
            this.lbStyle.ImageList = this.imageList1;
            this.lbStyle.Location = new System.Drawing.Point(3, 3);
            this.lbStyle.Name = "lbStyle";
            this.lbStyle.Size = new System.Drawing.Size(31, 28);
            this.lbStyle.TabIndex = 3;
            this.lbStyle.Click += new System.EventHandler(this.lbStyle_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLuu.Dock = System.Windows.Forms.DockStyle.Right;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(542, 3);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 28);
            this.butLuu.TabIndex = 0;
            this.butLuu.Text = "    Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butBoqua.Dock = System.Windows.Forms.DockStyle.Right;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(612, 3);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(80, 28);
            this.butBoqua.TabIndex = 1;
            this.butBoqua.Text = "    Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = true;
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Dock = System.Windows.Forms.DockStyle.Right;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(692, 3);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(86, 28);
            this.butKetthuc.TabIndex = 2;
            this.butKetthuc.Text = "     Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmKhaibaolocgiavienphi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(794, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhaibaolocgiavienphi";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nội dung không cho phép nhập trong viện phí khoa";
            this.SizeChanged += new System.EventHandler(this.frmKhaibaolocgiavienphi_SizeChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmKhaibaolocgiavienphi_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKhaibaolocgiavienphi_KeyDown);
            this.Load += new System.EventHandler(this.frmKhaibaolocgiavienphi_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmKhaibaolocgiavienphi_Load(object sender, System.EventArgs e)
		{
			f_Display();
			f_load_cb_user();
			f_Display_User();
			f_LoadDMVienPhi();
			f_set_data(false,false,false);
			lbStyle_Click(null,null);
		}
		private bool f_admin()
		{
			bool r=false;
			try
			{
				try
				{
					DataSet ads = new DataSet();
					ads.ReadXml("...//...//option//admin.xml");
					r=ads.Tables[0].Rows[0][0].ToString()=="1";
				}
				catch
				{
					r=false;
				}
			}
			catch
			{
				r= false;
			}
			return r;
		}
		private void f_load_cb_user()
		{
			try
			{
				DataSet ads = new DataSet();

				string sql="select to_char(id) ma, hoten||' ('||userid||')' ten from medibv.v_dlogin order by hoten";
				if(f_admin() && m_loai!="6" && m_loai!="7")
				{
					sql="select to_char(id) ma, hoten||' ('||userid||')' ten from medibv.v_dlogin order by hoten";
				}
				else
				{
					sql="select to_char(id) ma, hoten||' ('||userid||')' ten from medibv.v_dlogin where to_char(id)='"+m_userid+"' order by hoten";
				}
				ads=m_v.get_data(sql);
				cbUser.DisplayMember="TEN";
				cbUser.ValueMember="MA";
				cbUser.DataSource=ads.Tables[0];
				try
				{
					cbUser.SelectedValue=m_userid;
				}
				catch
				{
				}
			}
			catch
			{
			}
		}
		private void f_set_data(bool v_clear, bool v_current,bool v_val)
		{
			string aid_vp="";
			DataSet ads = new DataSet();
			if(!v_clear)
			{
				try
				{
					if(m_loai=="6")//Giuong yeu cau
					{
						aid_vp=m_v.get_data("select id_vp from v_option_locgiavp where to_char(userid)='-1' and to_char(loai)='"+m_loai+"'").Tables[0].Rows[0]["id_vp"].ToString().Trim();
					}
					else
						if(m_loai=="7")//Xuat an dinh duong
					{
						aid_vp=m_v.get_data("select id_vp from v_option_locgiavp where to_char(userid)='-1' and to_char(loai)='"+m_loai+"'").Tables[0].Rows[0]["id_vp"].ToString().Trim();
					}
					else
					{
						aid_vp=m_v.get_data("select id_vp from v_option_locgiavp where to_char(userid)='"+cbUser.SelectedValue.ToString()+"' and to_char(loai)='"+m_loai+"'").Tables[0].Rows[0]["id_vp"].ToString().Trim();
					}
				}
				catch
				{
				}
			}

			try
			{
				string []rs=aid_vp.Split(',');
				if(v_current)
				{
					foreach(Control c in tabControl1.SelectedTab.Controls)
					{
						try
						{
							CheckBox acb = (CheckBox)(c);
							acb.Checked=v_val;
							for(int i=0;i<rs.Length;i++)
							{
								if(acb.Name.ToString()==rs[i])
								{
									acb.Checked=true;
									break;
								}
							}
						}
						catch
						{
						}
					}
				}
				else
				{
					foreach(TabPage atp in tabControl1.TabPages)
					{
						foreach(Control c in atp.Controls)
						{
							try
							{
								CheckBox acb = (CheckBox)(c);
								acb.Checked=v_val;
								for(int i=0;i<rs.Length;i++)
								{
									if(acb.Name.ToString()==rs[i])
									{
										acb.Checked=true;
										break;
									}
								}
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}
		private string f_get_data()
		{
			string r="";
			try
			{
				foreach(TabPage atp in tabControl1.TabPages)
				{
					foreach(Control c in atp.Controls)
					{
						try
						{
							CheckBox acb = (CheckBox)(c);
							if(acb.Checked)
							{
								r=r.Trim(',')+","+acb.Name.ToString();
							}
						}
						catch
						{
						}
					}
				}
				r=r.Trim();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				r="";
			}
			return r;
		}
		public int f_GetWidthStringInPixel(System.Windows.Forms.CheckBox v_cb, string v_str)
		{
			try
			{
				int aWidth=0;
				Graphics g = Graphics.FromHwnd(v_cb.Handle); 
				StringFormat sf = new StringFormat(StringFormat.GenericTypographic); 
				SizeF size; 
				size = g.MeasureString(v_str, v_cb.Font, 500, sf); 
				//MessageBox.Show(size.Width.ToString());
				aWidth=(int)(size.Width)+ 40;
				g.Dispose(); 
				return aWidth;
			}
			catch
			{
				return 0;
			}
		}	
		private int f_XedichPixel(string v_str)
		{
			try
			{
				return v_str.Length*1/10;
			}
			catch
			{
				return 0;
			}
		}
		private void f_LoadDMVienPhi()
		{
			try
			{
				m_dsgiavp.Tables.Clear();
				string sql = "";
				sql = "select to_char(a.id) id, trim(a.ten) ten, trim(a.dvt) dvt, nvl(a.gia_th,0) gia_th, nvl(a.gia_bh,0) gia_bh, nvl(a.gia_dv,0) gia_dv, trim(b.ten) tenloai,to_char(b.id) idloai, b.stt from v_giavp a, v_loaivp b where a.id_loai=b.id and a.ten is not null order by b.stt, b.ten, a.stt";
				m_dsgiavp = m_v.get_data(sql);

				//				//thuốc có id_nhom=0, id_loai=0; d_theodoigia
				//				sql="select to_char(a.id) id, a.ten||' '||a.hamluong ten, a.dang dvt, nvl(a.dongia,0) gia_th, nvl(a.dongia,0) gia_bh, nvl(a.dongia,0) gia_dv, 'Thuoc' tenloai, '0' id_loai, 0 stt from d_dmbd a order by ten";
				//				//MessageBox.Show(sql);
				//				DataSet ads = m_v.get_data(sql);
				//				for(int i=0;i<ads.Tables[0].Rows.Count;i++)
				//				{
				//					DataRow r = m_dsgiavp.Tables[0].NewRow();
				//					for(int j=0;j<m_dsgiavp.Tables[0].Columns.Count;j++)
				//					{
				//						r[j]=ads.Tables[0].Rows[i][j].ToString();
				//					}
				//					r["tenloai"]="Thuốc khoa dược";
				//					m_dsgiavp.Tables[0].Rows.Add(r);
				//				}

				string atmp = "";
				
				TabPage aTab =  new TabPage("Test");
				CheckBox acheck =  new CheckBox();
				int aleft=3, atop=5,awidth=0, aheight=24, amaxw=0;
				int atabindex=1;
				int aitemindex=1;

				for(int i=0;i<m_dsgiavp.Tables[0].Rows.Count;i++)
				{

					try
					{
						if(m_dsgiavp.Tables[0].Rows[i]["idloai"].ToString().Trim()!=atmp)
						{
							atmp = m_dsgiavp.Tables[0].Rows[i]["idloai"].ToString().Trim();
							aTab = new TabPage(atabindex.ToString()+". "+m_dsgiavp.Tables[0].Rows[i]["tenloai"].ToString().Trim()+"  ");
							//MessageBox.Show(m_dsgiavp.Tables[0].Rows[i]["tenloai"].ToString().Trim()+":"+m_dsgiavp.Tables[0].Rows[i]["idloai"].ToString().Trim());
							aTab.ForeColor = Color.Navy;
							aTab.AutoScroll=true;
							tabControl1.TabPages.Add(aTab);
							atop = 1;
							aleft = 3;
							awidth=0;
							atabindex+=1;
							aitemindex=1;
						}

						if(m_dsgiavp.Tables[0].Rows[i]["idloai"].ToString().Trim()==atmp)
						{
							string atmp1 = m_dsgiavp.Tables[0].Rows[i]["ten"].ToString();
							decimal agia = 0;
							try
							{
								agia=decimal.Parse(m_dsgiavp.Tables[0].Rows[i]["gia_th"].ToString());
							}
							catch
							{
								agia=0;
							}
							acheck = new CheckBox();
							acheck.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
							acheck.MouseHover += new System.EventHandler(this.checkBox_MouseHover);
							acheck.MouseLeave += new System.EventHandler(this.checkBox_MouseLeave);

							acheck.Name = m_dsgiavp.Tables[0].Rows[i]["id"].ToString();
							acheck.Tag = m_dsgiavp.Tables[0].Rows[i]["gia_th"].ToString().Trim() + ":" + m_dsgiavp.Tables[0].Rows[i]["ten"].ToString().Trim();
							toolTip1.SetToolTip(acheck,m_dsgiavp.Tables[0].Rows[i]["ten"].ToString() + " ( "+ agia.ToString("###,###,##0.##") +"đ )");
							atmp1=m_dsgiavp.Tables[0].Rows[i]["ten"].ToString() + " ( "+ agia.ToString("###,###,##0.##") +"đ )";
							//if(atmp1.Length>30)
							//{
							//	atmp1 = atmp1.Substring(0,30)+"...";
							//}
							acheck.Text=aitemindex.ToString()+". "+atmp1;
							amaxw=f_GetWidthStringInPixel(acheck,acheck.Text);
							awidth=awidth<amaxw?amaxw:awidth;
							acheck.Width=awidth;
							acheck.Height=aheight;
							acheck.Left = aleft;
							acheck.Top = atop;
							aTab.Controls.Add(acheck);
							aitemindex+=1;

							atop = atop + acheck.Height;
							if(atop>tabControl1.Height-70)
							{
								atop = 1;
								aleft = aleft + awidth;
								awidth=0;
							}
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}
				}
			}
			catch(Exception exx)
			{
				MessageBox.Show(exx.ToString());
			}
		}
		private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			try
			{
				//This line of code will help you to change the apperance like size,name,style.
				Font f;
				//For background color
				Brush backBrush;
				//For forground color
				Brush foreBrush;
			
				//This construct will hell you to deside which tab page have current focus
				//to change the style.
				if(e.Index == this.tabControl1.SelectedIndex)
				{
					//This line of code will help you to change the apperance like size,name,style.
					f = new Font(e.Font, FontStyle.Regular | FontStyle.Regular);
					f = new Font(e.Font,FontStyle.Regular);

					backBrush = new System.Drawing.SolidBrush(SystemColors.Control);
					foreBrush = Brushes.Blue;
				}
				else
				{
					f = e.Font;
					backBrush = new SolidBrush(SystemColors.Control); 
					foreBrush = new SolidBrush(Color.Navy);
				}
                
				//To set the alignment of the caption.
				string tabName = this.tabControl1.TabPages[e.Index].Text;
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
	
				//Thsi will help you to fill the interior portion of
				//selected tabpage.
				
				e.Graphics.FillRectangle(backBrush, e.Bounds);
				Rectangle r = e.Bounds;
				r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height-3);
				e.Graphics.DrawString(tabName, f, foreBrush, r, sf);

				sf.Dispose();
				if(e.Index == this.tabControl1.SelectedIndex)
				{
					f.Dispose();
					backBrush.Dispose();
				}
				else
				{
					backBrush.Dispose();
					foreBrush.Dispose();
				}
			}
			catch(Exception Ex)
			{
				MessageBox.Show(Ex.Message.ToString(),"Error Occured",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void checkBox_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				CheckBox c = (CheckBox)(sender);
				c.ForeColor = c.Checked?Color.Red:Color.Navy;
			}
			catch
			{
			}
		}
		private void checkBox_MouseHover(object sender, System.EventArgs e)
		{
			try
			{
				CheckBox c = (CheckBox)(sender);
				c.ForeColor = c.Checked?Color.Brown:Color.Blue;
			}
			catch
			{
			}
		}

		private void checkBox_MouseLeave(object sender, System.EventArgs e)
		{
			try
			{
				CheckBox c = (CheckBox)(sender);
				c.ForeColor = c.Checked?Color.Red:Color.Navy;
			}
			catch
			{
			}
		}
	
		private void f_Display()
		{
			if(m_loai.Trim()=="")
			{
				m_loai="-1";
			}
			try
			{
				switch(m_loai)
				{
					case "1":
						m_file="v_optionchongiavp_vienphikhoa.xml";
						m_name=
lan.Change_language_MessageText("Viện phí khoa");
						m_tenloai="+viephikhoa";
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG NHẬP TRONG VIỆN PHÍ KHOA");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Viện phí khoa");
						break;
					case "2":
						m_file="v_optionchongiavp_thutructiep.xml";
						m_name=
lan.Change_language_MessageText("Thu trực tiếp");
						m_tenloai="+thutructiep";
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG THU VIỆN PHÍ TRỰC TIẾP");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Thu viện phí trực tiếp");
						break;
					case "3":
						m_file="v_optionchongiavp_thuchidinh.xml";
						m_name=
lan.Change_language_MessageText("Thu chỉ định");
						m_tenloai="+thutheochidinh";
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI THU THEO CHỈ ĐỊNH");
						this.Text=
lan.Change_language_MessageText("Tùy chọn thu theo chỉ định");
						break;
					case "4":
						m_file="v_optionchongiavp_thanhtoanngoaitru.xml";
						m_name=
lan.Change_language_MessageText("Thanh toán ngoại trú");
						m_tenloai="+thantoanngoaitru";
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG THANH TOÁN RA VIỆN NGOẠI TRÚ");
						this.Text=
lan.Change_language_MessageText("Tùy chọn thanh toán ra viện ngoại trú");
						break;
					case "5":
						m_file="v_optionchongiavp_thanhtoannoitru.xml";
						m_name=
lan.Change_language_MessageText("Thanh toán nội trú");
						m_tenloai="+thanhtoannoitru";
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG THANH TOÁN RA VIỆN NỘI TRÚ");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Thanh toán ra viện nội trú");
						break;
					case "6":
						m_file="v_optionchongiavp_tinhtheongay.xml";
						m_name=
lan.Change_language_MessageText("Thu trực tiếp");
						m_tenloai="+thu truc tiep";
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG GIƯỜNG YÊU CẦU");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Thu trực tiếp");
						break;
					case "7":
						m_file="v_optionchongiavp_tinhtheosuat.xml";
						m_name=
lan.Change_language_MessageText("Thu trực tiếp");
						m_tenloai=
lan.Change_language_MessageText("+thu truc tiep");
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG SUẤT ĂN");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Thu trực tiếp");
						break;
					case "-1":
						m_file="v_optionkhongchonggiavp_vienphikhoa.xml";
						m_name=
lan.Change_language_MessageText("Viện phí khoa");
						m_tenloai=
lan.Change_language_MessageText("-vienphikhoa");
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG KHÔNG NHẬP TRONG VIỆN PHÍ KHOA");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Viện phí khoa");
						break;
					case "-2":
						m_file="v_optionkhongchongiavp_thutructiep.xml";
						m_name=
lan.Change_language_MessageText("Thu trực tiếp");
						m_tenloai="-thutructiep";
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG KHÔNG THU VIỆN PHÍ TRỰC TIẾP");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Thu viện phí trực tiếp");
						break;
					case "-3":
						m_file="v_optionkhongchongiavp_thuchidinh.xml";
						m_name=
lan.Change_language_MessageText("Thu chỉ dinh");
						m_tenloai=
lan.Change_language_MessageText("-thutheochidinh");
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI KHÔNG THU THEO CHỈ ĐỊNH");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Thu theo chỉ định");
						break;
					case "-4":
						m_file="v_optionkhongchongiavp_thanhtoanngoaitru.xml";
						m_name=
lan.Change_language_MessageText("Thanh toán ngoại trú");
						m_tenloai=
lan.Change_language_MessageText("-thanhtoanngoaitru");
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG KHÔNG THU THANH TOÁN RA VIỆN NGOẠI TRÚ");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Thanh toán ra viện ngoại trú");
						break;
					case "-5":
						m_file="v_optionkhongchongiavp_thanhtoannoitru.xml";
						m_name=
lan.Change_language_MessageText("Thanh toán nội trú");
						m_tenloai=
lan.Change_language_MessageText("-thanhtoannoitru");
						lbTitle.Text=
lan.Change_language_MessageText("KHAI BÁO CÁC NỘI DUNG KHÔNG THU THANH TOÁN RA VIỆN NỘI TRÚ");
						this.Text=
lan.Change_language_MessageText("Tùy chọn Thanh toán ra viện nội trú");
						break;
				}
			}
			catch
			{
			}
		}
		private void f_Save()
		{
			try
			{
				string aid_vp=f_get_data();
				aid_vp=aid_vp.Trim(',');
				//MessageBox.Show(aid_vp);
				DataSet ads = new DataSet();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("id_vp");
				ads.Tables[0].Rows.Add(new string[]{aid_vp});
				ads.WriteXml("...//...//option//"+m_file,XmlWriteMode.WriteSchema);
				if(m_loai=="6")//Giuong yeu cau
				{
					m_v.upd_option_locgiavp(-1,decimal.Parse(m_loai),m_tenloai,aid_vp);
				}
				else
					if(m_loai=="7")//Suat an dinh duong
				{
					m_v.upd_option_locgiavp(-1,decimal.Parse(m_loai),m_tenloai,aid_vp);
				}
				else
					if(cbUser.SelectedIndex>=0)
				{
					m_v.upd_option_locgiavp(decimal.Parse(cbUser.SelectedValue.ToString()),decimal.Parse(m_loai),m_tenloai,aid_vp);
				}
				MessageBox.Show(this,
lan.Change_language_MessageText("Lưu thành công"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show(this,
lan.Change_language_MessageText("Không thể lưu"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			m_saved=true;
		}
		private string f_Cur_Date()
		{
			try
			{
				return System.DateTime.Now.Day.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Month.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Year.ToString();
			}
			catch
			{
				return "";
			}
		}

		private void f_Display_User()
		{
			try
			{
				DataSet ads = m_v.get_data("select to_char(id) id, hoten from medibv.v_dlogin where to_char(id)='"+ m_userid + "'");
				lbNguoiDN.Text=
lan.Change_language_MessageText("Người đăng nhập:")+" " + ads.Tables[0].Rows[0]["hoten"].ToString();
				lbNgayDN.Text=
lan.Change_language_MessageText("Ngày:")+" " + f_Cur_Date();
			}
			catch
			{
				//MessageBox.Show(this,"Chưa đăng nhập. Chỉ có quyền xem thông tin",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				lbNguoiDN.Text="";//"Người đăng nhập: <????>";
				lbNgayDN.Text="";//"Ngày: "+f_Cur_Date();
			}
		}
		private void f_SetEvent(System.Windows.Forms.Control v_c)
		{
			try
			{
				foreach(Control c in v_c.Controls)
				{
					c.Leave += new System.EventHandler(this.Control_Leave);
					c.Enter += new System.EventHandler(this.Control_Enter);
				}
			}
			catch
			{
			}
		}
		private void Control_Enter(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox"))
				{
					c.BackColor=SystemColors.Info;
					if(c.ForeColor!=Color.Red)
					{
						//c.ForeColor=SystemColors.InfoText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=SystemColors.Info;
					}
					else
						if(c.GetType().ToString()=="System.Windows.Forms.ComboBox")
					{
						System.Windows.Forms.ComboBox c1 = (System.Windows.Forms.ComboBox)(sender);
						if(c1.SelectedIndex<0)
						{
							c1.SelectedIndex=0;
						}
					}
				}
			}
			catch
			{
			}
		}
		private void Control_Leave(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox"))
				{
					c.BackColor=Color.FromArgb(255,255,255);
					if(c.ForeColor!=Color.Red)
					{
						//c.ForeColor=SystemColors.ControlText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=Color.White;
					}
				}
			}
			catch
			{
			}
		}
		#region Datagrid Colored Collum
		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
			switch (col.ToString())
			{
				case "0":
					c=Color.Black;
					break;
				case "1":
					c=Color.Blue;
					break;
				case "2":
					c=Color.Red;
					break;
				case "3":
					c=Color.Orange;
					break;
				case "4":
					c=Color.Cyan;
					break;
				default:
					c=Color.Black;
					break;
			}
			return c;
		}

		private void frmKhaibaolocgiavienphi_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void frmKhaibaolocgiavienphi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Escape)
				{
					this.Close();
				}
			}
			catch
			{
			}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			f_Save();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmKhaibaolocgiavienphi_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if(!m_saved)
				{
					if(MessageBox.Show(this,
lan.Change_language_MessageText("Có muốn lưu dữ liệu không?"),m_v.s_AppName,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
					{
						f_Save();
					}
				}
			}
			catch
			{
			}
		}

		#endregion

		private void lbStyle_Click(object sender, System.EventArgs e)
		{
			try
			{
				lbStyle.ImageIndex=lbStyle.ImageIndex==0?1:0;
				tabControl1.Multiline=(lbStyle.ImageIndex==1);
				toolTip1.SetToolTip(lbStyle,lbStyle.ImageIndex==0?
lan.Change_language_MessageText("Xem nhiều dòng"):
lan.Change_language_MessageText("Xem một dòng"));
			}
			catch
			{
			}
		}

		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				f_set_data(true,true,chkAll.Checked);
			}
			catch
			{
			}
		}

		private void cbUser_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			f_set_data(false,false,false);
		}

		private void cbUser_Validated(object sender, System.EventArgs e)
		{
			f_set_data(false,false,false);
		}
	}
}
