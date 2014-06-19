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
	/// Summary description for frmKhaibaodoituong.
	/// </summary>
	public class frmKhaibaodoituongthanhtoanravien : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string m_userid="";
		private string m_loai="";

		private DataSet m_dsdoituong = new DataSet();
		private bool m_saved=false;
		private string m_file="v_optionchithudoituong_thanhtoannoitru.xml";

		private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckedListBox chkDoituong;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkAll;
		private System.ComponentModel.IContainer components;
	/// <summary>
	/// 
	/// </summary>
	/// <param name="v_userid"></param>
	/// <param name="v_loai">v_loai="1": noitru In hoa don dac thu; "2": noitru In hoa don thuong; "3": noitru Khong in; "4": Tructiep In hoa dondacthu;</param>
		public frmKhaibaodoituongthanhtoanravien(string v_userid, string v_loai)
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
			f_Display();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhaibaodoituongthanhtoanravien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkDoituong = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
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
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(420, 49);
            this.panel1.TabIndex = 16;
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
            this.lbTitle.Text = " ĐỐI TƯỢNG IN BIÊN LAI VIỆN PHÍ";
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
            this.label15.Size = new System.Drawing.Size(420, 3);
            this.label15.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chkDoituong);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(420, 211);
            this.panel2.TabIndex = 19;
            // 
            // chkDoituong
            // 
            this.chkDoituong.CheckOnClick = true;
            this.chkDoituong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDoituong.Location = new System.Drawing.Point(3, 3);
            this.chkDoituong.Name = "chkDoituong";
            this.chkDoituong.Size = new System.Drawing.Size(410, 169);
            this.chkDoituong.TabIndex = 0;
            this.chkDoituong.SelectedIndexChanged += new System.EventHandler(this.chkDoituong_SelectedIndexChanged);
            this.chkDoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkDoituong_KeyDown);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 3);
            this.label1.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.butLuu);
            this.panel3.Controls.Add(this.butBoqua);
            this.panel3.Controls.Add(this.butKetthuc);
            this.panel3.Controls.Add(this.chkAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.Color.Navy;
            this.panel3.Location = new System.Drawing.Point(3, 176);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 28);
            this.panel3.TabIndex = 9;
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLuu.Dock = System.Windows.Forms.DockStyle.Right;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(174, 0);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 28);
            this.butLuu.TabIndex = 1;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butBoqua.Dock = System.Windows.Forms.DockStyle.Right;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(244, 0);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(80, 28);
            this.butBoqua.TabIndex = 2;
            this.butBoqua.Text = "    &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.UseVisualStyleBackColor = true;
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Dock = System.Windows.Forms.DockStyle.Right;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = global::Vienphi.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(324, 0);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(86, 28);
            this.butKetthuc.TabIndex = 3;
            this.butKetthuc.Text = "     &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.SystemColors.Control;
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAll.Location = new System.Drawing.Point(0, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(171, 28);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Chọn tất cả";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            this.chkAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAll_KeyDown);
            // 
            // frmKhaibaodoituongthanhtoanravien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(426, 269);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhaibaodoituongthanhtoanravien";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đối tượng in biên lai viện phí";
            this.SizeChanged += new System.EventHandler(this.frmKhaibaodoituong_SizeChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmKhaibaodoituong_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKhaibaodoituong_KeyDown);
            this.Load += new System.EventHandler(this.frmKhaibaodoituong_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		private void f_Display()
		{
			try
			{
				if(m_loai=="")
				{
					m_loai="1";
				}
				switch(m_loai)
				{
					case "1"://HDDT
						m_file="v_optionchithudoituong_thanhtoannoitru.xml";
						this.Text=lan.Change_language_MessageText("Đối tượng in hoá đơn đăc thù");
						lbTitle.Text=lan.Change_language_MessageText("ĐỐI TƯỢNG IN HOÁ ĐƠN ĐẶC THÙ");
						break;
					case "2"://HDNB
						m_file="v_optionchithudoituongnoibo_thanhtoannoitru.xml";
						this.Text=lan.Change_language_MessageText("Đối tượng in hoá đơn nội bộ");
						lbTitle.Text=lan.Change_language_MessageText("ĐỐI TƯỢNG IN HOÁ ĐƠN NỘI BỘ");
						break;
					case "3"://KHONG IN
						m_file="v_optionkhongthudoituong_thanhtoannoitru.xml";
						this.Text=lan.Change_language_MessageText("Đối tượng không in hoá đơn");
						lbTitle.Text=lan.Change_language_MessageText("ĐỐI TƯỢNG IN HOÁ ĐƠN GTGT");
						break;
					case "4"://HDDT_ Tructiep
						m_file="v_optionchithudoituong_thutructiep.xml";
						this.Text=lan.Change_language_MessageText("Đối tượng in hoá đơn đăc thù");
						lbTitle.Text=lan.Change_language_MessageText("ĐỐI TƯỢNG IN HOÁ ĐƠN ĐẶC THÙ");
						break;
					case "5"://HDDT_ Thanh toán ngoại trú
						m_file="v_optionchithudoituong_thanhtoanngoaitru.xml";
						this.Text=lan.Change_language_MessageText("Đối tượng in hoá đơn đăc thù");
						lbTitle.Text=lan.Change_language_MessageText("ĐỐI TƯỢNG IN HOÁ ĐƠN ĐẶC THÙ");
						break;
					case "6"://Đối tượng trẻ em
						m_file="v_optiondoituongtreem.xml";
						this.Text=lan.Change_language_MessageText("Đối tượng trẻ em");
						lbTitle.Text=lan.Change_language_MessageText("ĐỐI TƯỢNG TRẺ EM");
						break;
				}
			}
			catch
			{
			}
		}
		public string s_title
		{
			set
			{
				this.Text=value;
				lbTitle.Text=value.ToUpper();
			}
		}
		private void frmKhaibaodoituong_Load(object sender, System.EventArgs e)
		{
			f_Load_Data();
		}
		private void f_Load_Data()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.ReadXml("...//...//option//"+m_file);
			}
			catch
			{
				ads.Tables.Add("Table");
				ads.Tables[0].Columns.Add("id_vp");
				ads.WriteXml("...//...//option//"+m_file,XmlWriteMode.WriteSchema);
			}

			try
			{
				m_dsdoituong=m_v.get_data("select to_char(madoituong) ma, doituong ten from doituong order by madoituong asc");
				chkDoituong.DisplayMember="TEN";
				chkDoituong.ValueMember="MA";
				chkDoituong.DataSource=m_dsdoituong.Tables[0];
			}
			catch
			{
			}

			try
			{
				string aidd = "";
				switch(m_loai)
				{
					case "6"://Doituong tre em
						try
						{
							aidd=m_v.get_data("select * from v_optiondoituongtreem").Tables[0].Rows[0]["id"].ToString();
						}
						catch
						{
							aidd="";
						}
						break;
					default:
						aidd=ads.Tables[0].Rows[0]["id_vp"].ToString();
						break;
				}
				string[] aid=aidd.Split(',');
				for(int i=0;i<chkDoituong.Items.Count;i++)
				{
					for(int j=0;j<aid.Length;j++)
					{
						if(m_dsdoituong.Tables[0].Rows[i]["ma"].ToString()==aid[j])
						{
							chkDoituong.SetItemChecked(i,true);
							chkDoituong.SetItemCheckState(i,CheckState.Checked);
							break;
						}
					}
				}
			}
			catch
			{
			}
			m_saved=true;
		}
		private void f_Save()
		{
			try
			{
				string aid_vp="";
				for(int i=0;i<chkDoituong.Items.Count;i++)
				{
					if(chkDoituong.GetItemChecked(i))
					{
						aid_vp=aid_vp.Trim(',')+","+m_dsdoituong.Tables[0].Rows[i]["MA"].ToString().Trim();
					}
				}
				aid_vp=aid_vp.Trim(',');
				switch(m_loai)
				{
					case "6":
						try
						{
							string n = m_v.get_data("select * from v_optiondoituongtreem").Tables[0].Rows.Count.ToString();
						}
						catch
						{
							m_v.execute_data("create table v_optiondoituongtreem(id varchar2(20), constraint pk_v_optiondoituongtreem primary key(id))");
						}
						m_v.execute_data("delete from v_optiondoituongtreem");
						if(aid_vp!="")
						{
							m_v.execute_data("insert into v_optiondoituongtreem(id) values('"+aid_vp+"')");
						}
						break;
					default:
						DataSet ads = new DataSet();
						ads.Tables.Add("Tables");
						ads.Tables[0].Columns.Add("id_vp");
						ads.Tables[0].Rows.Add(new string[]{aid_vp});
						ads.WriteXml("...//...//option//"+m_file,XmlWriteMode.WriteSchema);
						break;
				}
				MessageBox.Show(this,lan.Change_language_MessageText("Lưu thành công"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Không thể lưu"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Error);
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
		private void frmKhaibaodoituong_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void frmKhaibaodoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void frmKhaibaodoituong_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if(!m_saved)
				{
					if(MessageBox.Show(this,lan.Change_language_MessageText("Có muốn lưu dữ liệu không?"),m_v.s_AppName,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
					{
						f_Save();
					}
				}
			}
			catch
			{
			}
		}

		private void chkDoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_saved=false;
		}
		private void f_set_check(CheckedListBox v_c,bool v_b)
		{
			try
			{
				for(int i=0;i<v_c.Items.Count;i++)
				{
					v_c.SetItemChecked(i,v_b);
					v_c.SetItemCheckState(i,v_b?CheckState.Checked:CheckState.Unchecked);
				}
			}
			catch
			{
			}
		}
		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				chkAll.Text=chkAll.Checked?lan.Change_language_MessageText("Không chọn tất cả"):lan.Change_language_MessageText("Chọn tất cả");
				f_set_check(chkDoituong,chkAll.Checked);
			}
			catch
			{
			}
		}

		private void chkDoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkAll_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
	}
}
