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
	/// Summary description for frmLoaitamung.
	/// </summary>
	public class frmLoaitamung : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private LibVP.AccessData m_v;//
		

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
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Panel pChitiet;
		private System.ComponentModel.IContainer components;

		public frmLoaitamung()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			f_SetEvent(panel2);

			//khởi tạo các biến toàn cục
			m_v =  new LibVP.AccessData();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public frmLoaitamung(LibVP.AccessData v_v)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			f_SetEvent(panel2);

			//khởi tạo các biến toàn cục
			m_v = v_v;
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

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaitamung));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pChitiet = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.butLuu = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
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
            this.panel2.Controls.Add(this.pChitiet);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(784, 488);
            this.panel2.TabIndex = 16;
            // 
            // pChitiet
            // 
            this.pChitiet.AutoScroll = true;
            this.pChitiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pChitiet.Location = new System.Drawing.Point(3, 3);
            this.pChitiet.Name = "pChitiet";
            this.pChitiet.Size = new System.Drawing.Size(772, 446);
            this.pChitiet.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(3, 449);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(772, 3);
            this.label4.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(3, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(772, 1);
            this.label3.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(775, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 450);
            this.label2.TabIndex = 64;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.butLuu);
            this.panel4.Controls.Add(this.butKetthuc);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 453);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(774, 28);
            this.panel4.TabIndex = 49;
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLuu.Dock = System.Windows.Forms.DockStyle.Right;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.Color.Navy;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(608, 0);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(83, 28);
            this.butLuu.TabIndex = 7;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Dock = System.Windows.Forms.DockStyle.Right;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(691, 0);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(83, 28);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "    &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click_1);
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
            this.lbTitle.Size = new System.Drawing.Size(345, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "KHAI BÁO CHI TIẾT THU TẠM ỨNG";
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
            // frmLoaitamung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(790, 546);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoaitamung";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo chi tiết thu tạm ứng";
            this.Load += new System.EventHandler(this.frmLoaitamung_Load);
            this.SizeChanged += new System.EventHandler(this.frmLoaitamung_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLoaitamung_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		private void checkBox_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				CheckBox c = (CheckBox)(sender);
				c.ForeColor = c.Checked?Color.Red:Color.Navy;
				f_set_ten(c.Tag.ToString());
			}
			catch
			{
			}
		}
		private void f_Load_Chitiet()
		{
			try
			{
				DataSet ads = new DataSet();
				pChitiet.Controls.Clear();
				string aloaivp="v_loaivp";
				string sql="select b.id, b.ten, a.ten viettat, nvl(a.sotien,0) sotien, nvl(a.id,-1) idc, nvl(a.ktt,0) ktt from v_loaitu a, "+aloaivp+" b where b.id=a.id(+) order by b.ten asc";
				ads = m_v.get_data(sql);
				CheckBox acb;
				TextBox atb;
				Label alb;
				int aw=0,amw=0,atop=5;
				foreach(DataRow r in ads.Tables[0].Rows)
				{
					acb = new CheckBox();
					aw=f_GetWidthStringInPixel(acb,r["ten"].ToString());
					if(amw<aw) amw=aw;
				}
				amw=amw+10;

				alb= new Label();
				alb.Text=
lan.Change_language_MessageText("Số tiền mặc định")+"  ";
				alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				//alb.TextAlign=ContentAlignment.MiddleRight;
				alb.Left=amw+1;
				alb.Width=150;
				alb.Height=20;
				alb.Top=atop;
				pChitiet.Controls.Add(alb);
				alb.BringToFront();

				alb= new Label();
				alb.Text=
lan.Change_language_MessageText("Viết tắt");
				alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				alb.Left=amw+1+150;
				alb.Width=150;
				alb.Top=atop;
				alb.Height=20;
				pChitiet.Controls.Add(alb);
				alb.BringToFront();

				atop=alb.Bottom-5;

				foreach(DataRow r in ads.Tables[0].Rows)
				{
					try
					{
						acb = new CheckBox();
						acb.Size = new System.Drawing.Size(amw, 23);
						acb.Left=amw-acb.Width;
						acb.Top=atop;
						acb.Text = r["ten"].ToString();
						acb.CheckAlign=ContentAlignment.MiddleRight;
						acb.Name="chkCT_"+r["id"].ToString();
						acb.Tag=r["id"].ToString();
						acb.TabStop=false;
						acb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;//.MiddleLeft;
						acb.Checked=r["idc"].ToString()==r["id"].ToString();
						acb.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
						acb.ForeColor=acb.Checked?Color.Red:Color.Navy;
						pChitiet.Controls.Add(acb);
						acb.BringToFront();
						
						atb= new TextBox();
						atb.MaxLength = 12;
						atb.Name = "txtCT_"+r["id"].ToString();
						atb.Tag = r["id"].ToString();
						atb.TextAlign=HorizontalAlignment.Right;
						atb.Text = decimal.Parse(r["sotien"].ToString()).ToString("###,###,###");
						atb.BackColor=Color.White;
						atb.Left=amw+1;
						atb.Width=150;
						atb.Top=atop;
						atb.Validated += new System.EventHandler(this.txtCT_Validated);
						pChitiet.Controls.Add(atb);
						atb.BringToFront();

						atb= new TextBox();
						atb.MaxLength = 50;
						atb.Name = "txtCTVT_"+r["id"].ToString();
						atb.Tag = r["id"].ToString();
						atb.BackColor=Color.White;
						atb.Text = r["viettat"].ToString();
						atb.Left=amw+1+150;
						atb.Width=150;
						atb.Top=atop;
						//atb.Validated += new System.EventHandler(this.txtCT_Validated);
						pChitiet.Controls.Add(atb);
						atb.BringToFront();

						acb = new CheckBox();
						acb.Size = new System.Drawing.Size(150, 23);
						acb.Left=atb.Right+2;
						acb.Top=atop;
						acb.Text = 
lan.Change_language_MessageText("Không thanh toán ra viện");
						acb.CheckAlign=ContentAlignment.MiddleLeft;
						acb.Name="chkCTKTT_"+r["id"].ToString();
						acb.Tag=r["id"].ToString();
						acb.TabStop=false;
						acb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
						acb.Checked=r["ktt"].ToString()=="1";
						acb.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
						acb.ForeColor=acb.Checked?Color.Red:Color.Navy;
						pChitiet.Controls.Add(acb);
						acb.BringToFront();

						acb.Height=atb.Height;

						atop=atop+atb.Height+1;
					}
					catch
					{
					}
				}
				f_SetEvent(pChitiet);
			}
			catch
			{
			}
		}
		private void txtCT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
		private void txtCT_Validated(object sender, System.EventArgs e)
		{
			try
			{
				TextBox atb = (TextBox)(sender);
				try
				{
					decimal l = decimal.Parse(atb.Text.Trim());
					if(l<0)
					{
						l=l*-1;
					}
					atb.Text=l.ToString("###,###,###");
				}
				catch
				{
					atb.Text="";
				}
			}
			catch
			{
			}
		}
		private void f_Ketthuc()
		{
			try
			{
				this.Close();
			}
			catch
			{
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
		private void frmLoaitamung_Load(object sender, System.EventArgs e)
		{
			try
			{
				f_Load_Chitiet();
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
					c=Color.Navy;
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
			//if (col==3) c=Color.Navy;
			//
			//			if (this.DataGrid1[row,4].ToString()=="1")
			//			{
			//				c=Color.Red;
			//				iUser=row;
			//			}
			//			if (row==iUser && row!=0) c=Color.Red;
			return c;
		}

		private void frmLoaitamung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				butKetthuc_Click(null,null);
			}
		}

		private void frmLoaitamung_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private decimal f_get_sotien(string v_id)
		{
			try
			{
				decimal ast=0;
				foreach(Control c in pChitiet.Controls)
				{
					if((c.GetType().ToString()=="System.Windows.Forms.TextBox")&&(c.Tag.ToString()==v_id)&&c.Name.IndexOf("txtCT_")==0)
					{
						try
						{
							ast=decimal.Parse(c.Text.ToString());
						}
						catch
						{
							ast=0;
						}
						break;
					}
				}
				return ast;
			}
			catch//(Exception ex)
			{
				return 0;
			}
		}
		private string f_get_ten(string v_id)
		{
			try
			{
				string r="";
				foreach(Control c in pChitiet.Controls)
				{
					if((c.GetType().ToString()=="System.Windows.Forms.TextBox")&&(c.Tag.ToString()==v_id)&&c.Name.IndexOf("txtCTVT_")==0)
					{
						r=c.Text.Trim();
						break;
					}
				}
				r=r.PadRight(51,' ');
				r=r.Substring(0,40).Trim();
				return r;
			}
			catch//(Exception ex)
			{
				return "";
			}
		}
		private string f_get_ktt(string v_id)
		{
			try
			{
				string r="0";
				foreach(Control c in pChitiet.Controls)
				{
					if((c.GetType().ToString()=="System.Windows.Forms.CheckBox")&&(c.Tag.ToString()==v_id)&&c.Name.IndexOf("chkCTKTT_")==0)
					{
						CheckBox acb = (CheckBox)(c);
						r=acb.Checked?"1":"0";
						break;
					}
				}
				return r;
			}
			catch//(Exception ex)
			{
				return "0";
			}
		}
		private void f_set_ten(string v_id)
		{
			try
			{
				string r="";
				bool b=false;
				foreach(Control c in pChitiet.Controls)
				{
					if((c.GetType().ToString()=="System.Windows.Forms.CheckBox")&&(c.Tag.ToString()==v_id)&&c.Name.IndexOf("chkCT_")==0)
					{
						r=c.Text.Trim();
						CheckBox acb = (CheckBox)(c);
						b=acb.Checked;
						break;
					}
				}
				//MessageBox.Show(r);
				foreach(Control c in pChitiet.Controls)
				{
					if((c.GetType().ToString()=="System.Windows.Forms.TextBox")&&(c.Tag.ToString()==v_id)&&c.Name.IndexOf("txtCTVT_")==0)
					{
						if(b)
						{
							if(c.Text.Trim()=="")
							{
								c.Text=r.PadRight(51,' ');
								c.Text=c.Text.Substring(0,50).Trim();
							}
						}
						else
						{
							c.Text="";
						}
						break;
					}
				}

				foreach(Control c in pChitiet.Controls)
				{
					if((c.GetType().ToString()=="System.Windows.Forms.TextBox")&&(c.Tag.ToString()==v_id)&&c.Name.IndexOf("txtCT_")==0)
					{
						if(!b)
						{
							c.Text="";
						}
						break;
					}
				}
			}
			catch//(Exception ex)
			{
			}
		}
		private DataSet f_get_Chitiet()
		{
			DataSet ads = new DataSet();
			ads.Tables.Add("Table");
			ads.Tables[0].Columns.Add("id");
			ads.Tables[0].Columns.Add("sotien");
			ads.Tables[0].Columns.Add("ten");
			ads.Tables[0].Columns.Add("ktt");
			try
			{
				foreach(Control c in pChitiet.Controls)
				{
					if(c.Name.IndexOf("chkCT_")==0 && c.GetType().ToString()=="System.Windows.Forms.CheckBox")
					{
						try
						{
							CheckBox acb = (CheckBox)(c);
							decimal ast=0;
							string aten="", aktt="";
							if(acb.Checked)
							{
								ast=f_get_sotien(acb.Tag.ToString());
								aten=f_get_ten(acb.Tag.ToString());
								aktt=f_get_ktt(acb.Tag.ToString());
								ads.Tables[0].Rows.Add(new string[]{acb.Tag.ToString().Trim(),ast.ToString("##0"),aten,aktt});
							}
						}
						catch//(Exception ex1)
						{
							//MessageBox.Show(ex1.ToString());
						}
					}
				}
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(ex.ToString());
			}
			return ads;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet ads = new DataSet();
				ads= f_get_Chitiet();
				//MessageBox.Show(ads.Tables[0].Rows.Count.ToString());
				m_v.execute_data("delete from v_loaitu");
				foreach(DataRow r in ads.Tables[0].Rows)
				{
					try
					{
						//MessageBox.Show(r["id"].ToString()+":"+r["sotien"].ToString()+":"+r["ten"].ToString());
						m_v.upd_loaitu(decimal.Parse(r["id"].ToString()),decimal.Parse(r["sotien"].ToString()),r["ten"].ToString(), decimal.Parse(r["ktt"].ToString()));
					}
					catch
					{
					}
					//m_v.execute_data("insert into v_loaitu(id,sotien) values("+r["id"].ToString()+","+r["sotien"].ToString()+")");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void butKetthuc_Click_1(object sender, System.EventArgs e)
		{
			f_Ketthuc();
		}
	
		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		#endregion
	}
}
