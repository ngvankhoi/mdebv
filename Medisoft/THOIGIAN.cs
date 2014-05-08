using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Lib_LH;
using System.Xml;

namespace Medisoft
{			
	
	public class THOIGIAN : System.Windows.Forms.Form
	{
        Language lan = new Language();
//		LICHHEN frmlichhen = new LICHHEN();
		DataSet Ds = new DataSet();
		Lib_LH.Access_Data k = new Lib_LH.Access_Data();
		DataTable tb;
		int gbd,pbd,gkt,pkt,gio,phut,count=0,upd=0;
		string a,w,q;

/// <summary>
/// /////////////////////////////////////////////
/// </summary>
		int h_start,m_start,h_end,m_end,minutes,hours,counts=0;
		string ass,wss,qss;
		int stt=1;
		int lan =0;

/// <summary>
/// /////////////////////////////////////////////
/// </summary>




		private System.Windows.Forms.Label lbLOAIKHAM;
		private System.Windows.Forms.Button cmdLUU;
		private System.Windows.Forms.Button cmdSua;
		private System.Windows.Forms.GroupBox grb1;
		private System.Windows.Forms.Label lb2;
		private System.Windows.Forms.Label lb1;
		private System.Windows.Forms.Label lb3;
		private System.Windows.Forms.GroupBox grb2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbgbd;
		private System.Windows.Forms.ComboBox cmbgkt;
		private System.Windows.Forms.ComboBox cmbpbd;
		private System.Windows.Forms.ComboBox cmbpkt;
		private System.Windows.Forms.Button cmdKetthuc;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdob5;
		private System.Windows.Forms.RadioButton rdob10;
		private System.Windows.Forms.RadioButton rdob7;
		
		private System.ComponentModel.Container components = null;

		public THOIGIAN()
		{			
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(THOIGIAN));
			this.lbLOAIKHAM = new System.Windows.Forms.Label();
			this.cmdLUU = new System.Windows.Forms.Button();
			this.cmdSua = new System.Windows.Forms.Button();
			this.grb1 = new System.Windows.Forms.GroupBox();
			this.lb3 = new System.Windows.Forms.Label();
			this.lb1 = new System.Windows.Forms.Label();
			this.lb2 = new System.Windows.Forms.Label();
			this.grb2 = new System.Windows.Forms.GroupBox();
			this.cmbpkt = new System.Windows.Forms.ComboBox();
			this.cmbpbd = new System.Windows.Forms.ComboBox();
			this.cmbgkt = new System.Windows.Forms.ComboBox();
			this.cmbgbd = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdob7 = new System.Windows.Forms.RadioButton();
			this.rdob10 = new System.Windows.Forms.RadioButton();
			this.rdob5 = new System.Windows.Forms.RadioButton();
			this.grb1.SuspendLayout();
			this.grb2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbLOAIKHAM
			// 
			this.lbLOAIKHAM.Location = new System.Drawing.Point(-16, 80);
			this.lbLOAIKHAM.Name = "lbLOAIKHAM";
			this.lbLOAIKHAM.Size = new System.Drawing.Size(416, 256);
			this.lbLOAIKHAM.TabIndex = 0;
			// 
			// cmdLUU
			// 
			this.cmdLUU.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdLUU.Image")));
			this.cmdLUU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdLUU.Location = new System.Drawing.Point(96, 192);
			this.cmdLUU.Name = "cmdLUU";
			this.cmdLUU.Size = new System.Drawing.Size(85, 32);
			this.cmdLUU.TabIndex = 68;
			this.cmdLUU.Text = "Cập Nhật";
			this.cmdLUU.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdLUU.Click += new System.EventHandler(this.cmdLUU_Click);
			// 
			// cmdSua
			// 
			this.cmdSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdSua.Image")));
			this.cmdSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdSua.Location = new System.Drawing.Point(38, 192);
			this.cmdSua.Name = "cmdSua";
			this.cmdSua.Size = new System.Drawing.Size(58, 32);
			this.cmdSua.TabIndex = 69;
			this.cmdSua.Text = "Sửa";
			this.cmdSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
			this.cmdSua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdSua_KeyDown);
			// 
			// grb1
			// 
			this.grb1.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.lb3,
																			   this.lb1,
																			   this.lb2});
			this.grb1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.grb1.Location = new System.Drawing.Point(40, 16);
			this.grb1.Name = "grb1";
			this.grb1.Size = new System.Drawing.Size(200, 88);
			this.grb1.TabIndex = 74;
			this.grb1.TabStop = false;
			this.grb1.Text = "Giờ làm việc hiện tại";
			// 
			// lb3
			// 
			this.lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.lb3.Location = new System.Drawing.Point(120, 32);
			this.lb3.Name = "lb3";
			this.lb3.Size = new System.Drawing.Size(72, 32);
			this.lb3.TabIndex = 2;
			this.lb3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb1
			// 
			this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.lb1.Location = new System.Drawing.Point(8, 32);
			this.lb1.Name = "lb1";
			this.lb1.Size = new System.Drawing.Size(72, 32);
			this.lb1.TabIndex = 1;
			this.lb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb2
			// 
			this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.lb2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.lb2.Location = new System.Drawing.Point(80, 40);
			this.lb2.Name = "lb2";
			this.lb2.Size = new System.Drawing.Size(40, 16);
			this.lb2.TabIndex = 0;
			this.lb2.Text = "==>";
			this.lb2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// grb2
			// 
			this.grb2.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.cmbpkt,
																			   this.cmbpbd,
																			   this.cmbgkt,
																			   this.cmbgbd,
																			   this.label2,
																			   this.label1,
																			   this.lbLOAIKHAM});
			this.grb2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.grb2.Location = new System.Drawing.Point(24, 16);
			this.grb2.Name = "grb2";
			this.grb2.Size = new System.Drawing.Size(248, 88);
			this.grb2.TabIndex = 75;
			this.grb2.TabStop = false;
			this.grb2.Text = "Thời gian làm việc";
			// 
			// cmbpkt
			// 
			this.cmbpkt.DropDownWidth = 65;
			this.cmbpkt.Items.AddRange(new object[] {
														"00 Phút",
														"05 Phút",
														"10 Phút",
														"15 Phút",
														"20 Phút",
														"25 Phút",
														"30 Phút",
														"35 Phút",
														"40 Phút",
														"45 Phút",
														"50 Phút",
														"55 Phút"});
			this.cmbpkt.Location = new System.Drawing.Point(192, 56);
			this.cmbpkt.MaxDropDownItems = 15;
			this.cmbpkt.Name = "cmbpkt";
			this.cmbpkt.Size = new System.Drawing.Size(48, 21);
			this.cmbpkt.TabIndex = 5;
			this.cmbpkt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbpkt_KeyDown_1);
			// 
			// cmbpbd
			// 
			this.cmbpbd.DropDownWidth = 65;
			this.cmbpbd.Items.AddRange(new object[] {
														"00 Phút",
														"05 Phút",
														"10 Phút",
														"15 Phút",
														"20 Phút",
														"25 Phút",
														"30 Phút",
														"35 Phút",
														"40 Phút",
														"45 Phút",
														"50 Phút",
														"55 Phút"});
			this.cmbpbd.Location = new System.Drawing.Point(192, 24);
			this.cmbpbd.MaxDropDownItems = 15;
			this.cmbpbd.Name = "cmbpbd";
			this.cmbpbd.Size = new System.Drawing.Size(48, 21);
			this.cmbpbd.TabIndex = 4;
			this.cmbpbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbpbd_KeyDown_1);
			// 
			// cmbgkt
			// 
			this.cmbgkt.DropDownWidth = 65;
			this.cmbgkt.Items.AddRange(new object[] {
														"07 Giờ",
														"08 Giờ",
														"09 Giờ",
														"10 Giờ",
														"11 Giờ",
														"12 Giờ",
														"13 Giờ",
														"14 Giờ",
														"15 Giờ",
														"16 Giờ",
														"17 Giờ",
														"18 Giờ",
														"19 Giờ",
														"20 Giờ",
														"21 Giờ",
														"22 Giờ",
														"23 Giờ",
														"00 Giờ",
														"01 Giờ",
														"02 Giờ",
														"03 Giờ",
														"04 Giờ",
														"05 Giờ",
														"06 Giờ"});
			this.cmbgkt.Location = new System.Drawing.Point(144, 56);
			this.cmbgkt.MaxDropDownItems = 15;
			this.cmbgkt.Name = "cmbgkt";
			this.cmbgkt.Size = new System.Drawing.Size(48, 21);
			this.cmbgkt.TabIndex = 3;
			this.cmbgkt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbgkt_KeyDown_1);
			// 
			// cmbgbd
			// 
			this.cmbgbd.DropDownWidth = 65;
			this.cmbgbd.Items.AddRange(new object[] {
														"07 Giờ",
														"08 Giờ",
														"09 Giờ",
														"10 Giờ",
														"11 Giờ",
														"12 Giờ",
														"13 Giờ",
														"14 Giờ",
														"15 Giờ",
														"16 Giờ",
														"17 Giờ",
														"18 Giờ",
														"19 Giờ",
														"20 Giờ",
														"21 Giờ",
														"22 Giờ",
														"23 Giờ",
														"00 Giờ",
														"01 Giờ",
														"02 Giờ",
														"03 Giờ",
														"04 Giờ",
														"05 Giờ",
														"06 Giờ"});
			this.cmbgbd.Location = new System.Drawing.Point(144, 24);
			this.cmbgbd.MaxDropDownItems = 15;
			this.cmbgbd.Name = "cmbgbd";
			this.cmbgbd.Size = new System.Drawing.Size(48, 21);
			this.cmbgbd.TabIndex = 2;
			this.cmbgbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbgbd_KeyDown_1);
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label2.Location = new System.Drawing.Point(8, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Thời gian kết thúc làm việc";
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label1.Location = new System.Drawing.Point(8, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Thời gian bắt đầu làm việc";
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdKetthuc.Image")));
			this.cmdKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdKetthuc.Location = new System.Drawing.Point(181, 192);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(76, 32);
			this.cmdKetthuc.TabIndex = 76;
			this.cmdKetthuc.Text = "Kết thúc";
			this.cmdKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.rdob7,
																					this.rdob10,
																					this.rdob5});
			this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.groupBox2.Location = new System.Drawing.Point(24, 120);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(248, 56);
			this.groupBox2.TabIndex = 77;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thời gian trung bình một lần khám";
			// 
			// rdob7
			// 
			this.rdob7.Location = new System.Drawing.Point(88, 24);
			this.rdob7.Name = "rdob7";
			this.rdob7.Size = new System.Drawing.Size(72, 24);
			this.rdob7.TabIndex = 2;
			this.rdob7.Text = "7 phút";
			// 
			// rdob10
			// 
			this.rdob10.Location = new System.Drawing.Point(168, 24);
			this.rdob10.Name = "rdob10";
			this.rdob10.Size = new System.Drawing.Size(72, 24);
			this.rdob10.TabIndex = 1;
			this.rdob10.Text = "10 phút";
			// 
			// rdob5
			// 
			this.rdob5.Checked = true;
			this.rdob5.Location = new System.Drawing.Point(24, 24);
			this.rdob5.Name = "rdob5";
			this.rdob5.Size = new System.Drawing.Size(64, 24);
			this.rdob5.TabIndex = 0;
			this.rdob5.TabStop = true;
			this.rdob5.Text = "5 phút";
			// 
			// THOIGIAN
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 237);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.cmdKetthuc,
																		  this.grb2,
																		  this.grb1,
																		  this.cmdSua,
																		  this.cmdLUU});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "THOIGIAN";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "THỜI GIAN LÀM VIỆC";
			this.Click += new System.EventHandler(this.THOIGIAN_Click);
			this.Load += new System.EventHandler(this.THOIGIAN_Load);
			this.grb1.ResumeLayout(false);
			this.grb2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		

		private void cmdLUU_Click(object sender, System.EventArgs e)
		{
			if(!Kiemtra())	return;		
			string gbdlamviec;
			string gktlamviec;
			try
			{
				gbdlamviec = cmbgbd.Text.Substring(0,2).ToString().Trim()+":"+cmbpbd.Text.Substring(0,2).ToString().Trim();
				gktlamviec = cmbgkt.Text.Substring(0,2).ToString().Trim()+":"+cmbpkt.Text.Substring(0,2).ToString().Trim();
			}
			catch
			{
				MessageBox.Show("Chọn giờ từ danh sách sổ xuống","Thông Báo");
				return;
			}
			MessageBox.Show("Từ "+gbdlamviec+" Đến "+gktlamviec,"Giờ làm việc");
			k.Del_thoigian(lb1.Text.ToString().Trim());
			k.Ins_Thoigian(gbdlamviec,gktlamviec);
			WriteXML();
			Write_XML();
			Ena_Textbox(true);				
			Load_TG();		
			grb1.Visible=true;
			grb2.Visible=false;
			cmdKetthuc.Enabled=true;
			cmdSua.Enabled=true;
			cmdLUU.Enabled=false;
			cmdKetthuc.Focus();
			upd++;
		}

		private void cmdSua_Click(object sender, System.EventArgs e)
		{
			grb1.Visible=false;
			grb2.Visible=true;			
			Ena_Textbox(true);
			cmbgbd.Focus();
			SendKeys.Send("{f4}");	
			cmdKetthuc.Enabled=true;
		}

		private void Ena_Textbox(bool ena)
		{
			cmbgbd.Enabled= ena;
			cmbgkt.Enabled= ena;
			cmbpbd.Enabled= ena;
			cmbpkt.Enabled= ena;
			cmdLUU.Enabled= ena;	
			cmdKetthuc.Enabled=!ena;
			cmdSua.Enabled=!ena;			
		}

		private void THOIGIAN_Click(object sender, System.EventArgs e)
		{
			Ena_Textbox(false);
		}

		private void THOIGIAN_Load(object sender, System.EventArgs e)
		{
			grb1.Visible=true;
			grb2.Visible=false;
			Ena_Textbox(false);	
			Load_TG();
			Load_radiobutton();
		}

		private void Load_TG()
		{
            Ds = k.Get_Thoigian();
			tb=Ds.Tables[0];
			lb1.Text=tb.Rows[0]["TGBD"].ToString();
			lb3.Text=tb.Rows[0]["TGKT"].ToString();						
		}

		private void cmdSua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmbgbd.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void cmbgbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmbpbd.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void cmbpbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmbgkt.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void cmbgkt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmbpkt.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void cmbpkt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmdLUU.Focus();				
			}
		}

		private bool Kiemtra()
		{
			if(cmbgbd.Text=="")
			{
				MessageBox.Show("Nhập giờ bắt đầu làm việc","Thông Báo");
				cmbgbd.Focus();
				return false;
			}
			if(cmbpbd.Text=="")
			{
				MessageBox.Show("Nhập phút bắt đầu làm việc","Thông Báo");
				cmbpbd.Focus();
				return false;
			}
			if(cmbgkt.Text=="")
			{
				MessageBox.Show("Nhập giờ kết thúc làm việc","Thông Báo");
				cmbgkt.Focus();
				return false;
			}
			if(cmbpkt.Text=="")
			{
				MessageBox.Show("Nhập phút kết thúc làm việc","Thông Báo");
				cmbpkt.Focus();
				return false;
			}
			return true;
		}

		private void cmbgbd_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmbpbd.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void cmbpbd_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmbgkt.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void cmbgkt_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmbpkt.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void cmbpkt_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmdLUU.Focus();
			}
		}

		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void WriteXML()
		{
//			string XmlFile;
//			System.IO.DirectoryInfo directoryInfo;
//			System.IO.DirectoryInfo directoryXML;
//			directoryInfo = System.IO.Directory.GetParent(Application.StartupPath);
//			if (directoryInfo.Name.ToString() == "bin")
//			{
//				directoryXML = System.IO.Directory.GetParent(directoryInfo.FullName);
//				XmlFile = directoryXML.FullName + "\\" + "gio.xml";
//			}
//			else
//				XmlFile = directoryInfo.FullName + "\\" + "gio.xml";
			
			XmlTextWriter XmlWtr = new System.Xml.XmlTextWriter("..\\..\\..\\xml\\lh_gio.xml",null);//XmlFile
			XmlWtr.Formatting=Formatting.Indented;
			XmlWtr.WriteStartDocument();
			XmlWtr.WriteStartElement("Import");					

			gbd=int.Parse(cmbgbd.Text.Substring(0,2));
			pbd=int.Parse(cmbpbd.Text.Substring(0,2));
			gkt=int.Parse(cmbgkt.Text.Substring(0,2));
			pkt=int.Parse(cmbpkt.Text.Substring(0,2));
			
			for(gio=gbd;gio<=gkt;gio++)
			{
				count++;
				if(count == 1)
				{
					pbd=int.Parse(cmbpbd.Text.Substring(0,2));
					pkt=55;
				}
				else
				{
					pbd=0;
					pkt=55;
				}
				if((count+gbd)==(gkt+1))
				{
					pbd=0;
					pkt=int.Parse(cmbpkt.Text.Substring(0,2));

				}
				for(phut=pbd;phut<=pkt;phut=phut+5)
				{					
					if(gio.ToString().Length==1)	w = "0"+gio.ToString();
					else						w=gio.ToString();
					if(phut.ToString().Length==1)	q ="0"+phut.ToString();
					else						q=phut.ToString();					
					a = w+":"+q;					
					//cmb.Items.Add(a);
					
					XmlWtr.WriteStartElement("Giolam");
					XmlWtr.WriteElementString("Gio",a);		
					XmlWtr.WriteEndElement();
				}
			}			
			XmlWtr.Flush();
			XmlWtr.Close();
		}

		private void Write_XML()
		{
			XmlTextWriter XmlWtr = new System.Xml.XmlTextWriter("..\\..\\..\\xml\\lh_giostt.xml",null);//XmlFile
			XmlWtr.Formatting=Formatting.Indented;
			XmlWtr.WriteStartDocument();
			XmlWtr.WriteStartElement("Import");	

			h_start=int.Parse(cmbgbd.Text.Substring(0,2));
			m_start=int.Parse(cmbpbd.Text.Substring(0,2));
			h_end=int.Parse(cmbgkt.Text.Substring(0,2));
			m_end=int.Parse(cmbpkt.Text.Substring(0,2));	
			int khoangcachthoigian;
			if(rdob10.Checked)
			{
				khoangcachthoigian=10;
			}
			else
			{
				if(rdob5.Checked)
				{
					khoangcachthoigian=5;
				}
				else
				{
					khoangcachthoigian=7;
				}
			}

			for(hours=h_start;hours<=h_end;hours++)
			{
				counts++;
				if(counts == 1)
				{
					//pbd=int.Parse(cmbpbd.Text.Substring(0,2));
					m_start=int.Parse("00");
					//pkt=55;
					m_end=59;
				}
				else
				{
					m_start=0;
					//pkt=55;
					m_end=59;
				}
				if((counts+h_start)==(h_end+1))
				{
					m_start=0;
					//pkt=int.Parse(cmbpkt.Text.Substring(0,2));
					m_end=int.Parse("30");
				}
				for(minutes=m_start;minutes<=m_end;minutes=minutes+1)
				{						
					lan++;
					
					if(hours.ToString().Length==1)	wss = "0"+hours.ToString();
					else						wss=hours.ToString();
					if(minutes.ToString().Length==1)	qss ="0"+minutes.ToString();
					else						qss=minutes.ToString();					
					ass = wss+":"+qss;					
					XmlWtr.WriteStartElement("Giolam");
					XmlWtr.WriteElementString("Gio",ass);		
					XmlWtr.WriteElementString("Sothutu",stt.ToString());	
					XmlWtr.WriteElementString("Thoigiantb",khoangcachthoigian.ToString());		
					if(lan ==khoangcachthoigian)
					{
						stt++;
						lan=0;
					}
					XmlWtr.WriteEndElement();
				}
			}			
			XmlWtr.Flush();
			XmlWtr.Close();
		}

		private void Load_radiobutton()
		{
			DataSet Ds = k.Loadgio_stt();
			DataTable tb=Ds.Tables[0];
			if(int.Parse(tb.Rows[0]["Thoigiantb"].ToString())==5)
			{
				rdob5.Checked=true;
			}
			else
			{
				if(int.Parse(tb.Rows[0]["Thoigiantb"].ToString())==10)
				{
					rdob10.Checked=true;
				}
				else
				{
					rdob7.Checked=true;
				}
			}
		}
	}
}
