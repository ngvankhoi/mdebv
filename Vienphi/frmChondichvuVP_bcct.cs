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
	/// Summary description for frmChondichvuVP_bcct.
	/// </summary>
	public class frmChondichvuVP_bcct : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibVP.AccessData m_v;//
		private string m_mavp="";
		private string m_loai="";
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label lbStyle;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button butChon;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;

		public frmChondichvuVP_bcct()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			f_SetEvent(panel2);

			//khởi tạo các biến toàn cục
			m_v =  LibVP.AccessData.GetImplement();
			f_load_history();
			f_LoadDMVienPhi();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public frmChondichvuVP_bcct(string v_loai)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			f_SetEvent(panel2);
			m_loai=v_loai;

			//khởi tạo các biến toàn cục
			m_v =  LibVP.AccessData.GetImplement();
			f_load_history();
			f_LoadDMVienPhi();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChondichvuVP_bcct));
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbStyle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.butChon = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(784, 488);
            this.panel2.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(767, 442);
            this.tabControl1.TabIndex = 80;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(5, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(767, 3);
            this.label4.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(5, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(767, 1);
            this.label3.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(772, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 446);
            this.label2.TabIndex = 64;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lbStyle);
            this.panel4.Controls.Add(this.butChon);
            this.panel4.Controls.Add(this.butBoqua);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(5, 451);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(770, 28);
            this.panel4.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(33, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 28);
            this.label1.TabIndex = 21;
            this.label1.Text = "       Chọn / Không chọn tất cả";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label1, "Chọn / Không chọn tất cả");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbStyle
            // 
            this.lbStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbStyle.ImageIndex = 0;
            this.lbStyle.ImageList = this.imageList1;
            this.lbStyle.Location = new System.Drawing.Point(0, 0);
            this.lbStyle.Name = "lbStyle";
            this.lbStyle.Size = new System.Drawing.Size(33, 28);
            this.lbStyle.TabIndex = 20;
            this.toolTip1.SetToolTip(this.lbStyle, "Xem một dòng");
            this.lbStyle.Click += new System.EventHandler(this.lbStyle_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // butChon
            // 
            this.butChon.BackColor = System.Drawing.SystemColors.Control;
            this.butChon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butChon.Dock = System.Windows.Forms.DockStyle.Right;
            this.butChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChon.ForeColor = System.Drawing.Color.Navy;
            this.butChon.Image = ((System.Drawing.Image)(resources.GetObject("butChon.Image")));
            this.butChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChon.Location = new System.Drawing.Point(610, 0);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(80, 28);
            this.butChon.TabIndex = 0;
            this.butChon.Text = "     Chọn";
            this.butChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChon.UseVisualStyleBackColor = true;
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butBoqua.Dock = System.Windows.Forms.DockStyle.Right;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.Color.Navy;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(690, 0);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(80, 28);
            this.butBoqua.TabIndex = 3;
            this.butBoqua.Text = "      Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(784, 3);
            this.label15.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(784, 49);
            this.panel1.TabIndex = 18;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(71, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(449, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "  CHỌN DỊCH VỤ THU VIỆN PHÍ BÁO CÁO";
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
            // frmChondichvuVP_bcct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(790, 546);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChondichvuVP_bcct";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Chọn dịch vụ thu viện phí cần báo cáo";
            this.Load += new System.EventHandler(this.frmChondichvuVP_bcct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChondichvuVP_bcct_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		#region User Define Function
		private void f_Ketthuc()
		{
			try
			{
				m_mavp = "?";
				this.Close();
			}
			catch
			{
			}
		}
		public string s_loaiform
		{
			set
			{
				m_loai=value;
			}
		}
		public string s_mavp
		{
			get
			{
				return m_mavp;
			}
			set
			{
				f_SetItem(value);
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
					c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
				}
			}
			catch
			{
			}
		}
		/// <summary>
		/// id,ten,soluong,cachdung
		/// </summary>
		/// <param name="v_ds"></param>
		private string f_GetItem()
		{
			try
			{
				string r="";
				foreach(TabPage atp in tabControl1.TabPages)
				{
					foreach(Control c in atp.Controls)
					{
						try
						{
							CheckBox c1 = (CheckBox)(c);
							if(c1.Checked)
							{
								r=r.Trim().Trim(',')+","+c1.Tag.ToString();
							}
						}
						catch
						{
						}
					}
				}
				r=r.Trim().Trim(',');
				return r;
			}
			catch
			{
				return "";
			}
		}
		private void f_SetItem(string v_mavp)
		{
			string amavp=v_mavp.Trim()+",";
			try
			{
				foreach(TabPage atp in tabControl1.TabPages)
				{
					foreach(Control c in atp.Controls)
					{
						try
						{
							CheckBox c1 = (CheckBox)(c);
							c1.Checked=amavp.IndexOf(c1.Tag.ToString()+",")>=0;
						}
						catch
						{
						}
					}
				}
			}
			catch
			{
			}
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
				DataSet m_dsgiavp= new DataSet();
				string sql = "";

                sql = "select * from (select to_char(a.id) as id, trim(a.ma) as ma, trim(a.ten) as ten, case when c.id is null then 0 else 1 end as chon, trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, trim(b.ten) as tenloai, to_char(b.id)||'VP' as idloai, b.stt, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_option_bcct c on a.id=c.id and a.ten is not null";
                sql += " union all select to_char(a.id) as id, trim(a.ma) as ma, trim(a.ten)||' '||trim(a.hamluong) as ten, case when b.id is null then 0 else 1 end as chon, trim(a.dang) as dvt, a.giaban as gia_th, a.gia_bh, to_number(0) as gia_dv, trim(d.ten) as tenloai, to_char(d.ma)||'D' as idloai, d.stt, to_number(0) as trongoi from medibv.d_dmbd a left join medibv.v_option_bcct b on a.id=b.id inner join medibv.d_dmnhom c on a.manhom=c.id left join medibv.v_nhomvp d on c.nhomvp=d.ma where a.nhom=1) as froo order by idloai, ten desc";
				m_dsgiavp = m_v.get_data(sql);
				string atmp = "";
				TabPage aTab =  new TabPage("Test");
				CheckBox acheck =  new CheckBox();
				int aleft=3, atop=5,awidth=0, aheight=24,amaxw=0;
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
							acheck = new CheckBox();
							acheck.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
							acheck.MouseHover += new System.EventHandler(this.checkBox_MouseHover);
							acheck.MouseLeave += new System.EventHandler(this.checkBox_MouseLeave);

							acheck.Name = m_dsgiavp.Tables[0].Rows[i]["id"].ToString();
							acheck.Tag = m_dsgiavp.Tables[0].Rows[i]["id"].ToString();
							toolTip1.SetToolTip(acheck,m_dsgiavp.Tables[0].Rows[i]["ten"].ToString());
							atmp1=m_dsgiavp.Tables[0].Rows[i]["ten"].ToString() + " - "+ m_dsgiavp.Tables[0].Rows[i]["ma"].ToString();
							acheck.Checked=m_dsgiavp.Tables[0].Rows[i]["chon"].ToString()=="1";

							acheck.Text=aitemindex.ToString()+". "+atmp1;
							amaxw=f_GetWidthStringInPixel(acheck,acheck.Text);
							awidth=awidth<amaxw?amaxw:awidth;
							acheck.Width=awidth;
							if(m_loai=="2")
							{
								acheck.Enabled=m_dsgiavp.Tables[0].Rows[i]["trongoi"].ToString()!="1";
							}
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
		#endregion
		#region Control Events
		private void Control_Enter(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox"))
				{
					c.BackColor=SystemColors.Info;
					c.ForeColor=SystemColors.InfoText;
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
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox"))
				{
					c.BackColor=Color.FromArgb(255,255,255);
					c.ForeColor=SystemColors.ControlText;
				}
			}
			catch
			{
			}
		}

		private void Control_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			f_Ketthuc();
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
		/// <summary>
		///
		/// </summary>
		/// <returns>id,ten,soluong,cachdung</returns>
		
		private void frmChondichvuVP_bcct_Load(object sender, System.EventArgs e)
		{
			try
			{
				//lbRem.Top=DataGrid1.Top+5;
				//lbRem.Left = DataGrid1.Right-lbRem.Width-1;
			}
			catch
			{
			}
		}
		#endregion 
		public string s_Title
		{
			set
			{
				this.Text=value;
				lbTitle.Text=value.ToUpper();
			}
		}
		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_mavp="?";
				this.Close();
			}
			catch
			{
			}
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_mavp=f_GetItem();
				this.Close();
			}
			catch
			{
			}
		}
		private void f_save_history()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Table");
				ads.Tables[0].Columns.Add("Multiline");
				ads.Tables[0].Rows.Add(new string[]{lbStyle.ImageIndex.ToString()});
				ads.WriteXml("..\\..\\option\\v_option_chonvp_multiline_list_bcct.xml",XmlWriteMode.WriteSchema);
			}
			catch
			{
			}
		}
		private void f_load_history()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.ReadXml("..\\..\\option\\v_option_chonvp_multiline_list_bcct.xml");
				tabControl1.Multiline=ads.Tables[0].Rows[0]["Multiline"].ToString()=="1";
				lbStyle.ImageIndex=int.Parse(ads.Tables[0].Rows[0][0].ToString());
			}
			catch
			{
				tabControl1.Multiline=false;
				lbStyle.ImageIndex=0;
			}
		}
		private void lbStyle_Click(object sender, System.EventArgs e)
		{
			try
			{
				lbStyle.ImageIndex=lbStyle.ImageIndex==0?1:0;
				tabControl1.Multiline=(lbStyle.ImageIndex==1);
				toolTip1.SetToolTip(lbStyle,lbStyle.ImageIndex==0?
lan.Change_language_MessageText("Xem nhiều dòng"):
lan.Change_language_MessageText("Xem một dòng"));
				f_save_history();
			}
			catch
			{
			}
		}
		private void frmChondichvuVP_bcct_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				butKetthuc_Click(null,null);
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

		private void label1_Click(object sender, System.EventArgs e)
		{
			try
			{
				foreach(Control c in tabControl1.SelectedTab.Controls)
				{
					try
					{
						CheckBox c1 = (CheckBox)(c);
						c1.Checked=!c1.Checked;
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}
	}
}
