using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Lib_LH;
using System.Xml;
using LibMedi;

namespace Medisoft
{	
	public class LICHHEN : System.Windows.Forms.Form
	{		
        Language lan = new Language();
		long u_maql;
		long u_idnhapkhoa;
		string u_mabs;	
		string u_makp;
		int u_loaiba;
		string u_mabn;
		bool seeallbs=false;
		bool seeallkp=false;		

		int PX_BS;
		int PY_BS;
		int PX_KP;
		int PY_KP;

		DataSet Dskhoaphong = new DataSet();
		DataSet DsBS;
		DataSet DsUser = new DataSet();		
		DataTable dtbkhoaphong = new DataTable();
		DataTable dtbBacSi;
		DataColumn dclUser,dclBS;
		DataTable dt,dtBS;
		DataTable dtable;
		int cot=0,dong=0;
		DataRow drw,drwBS;
		DataTable dtbUser,dtbBS;
		string[] phongkham = new String[500];			
		string[] tenbacsi = new String[1000];
		string[] mabacsi = new String[1000];
//		string[] makhoaphong = new String[100];
		Lib_LH.Access_Data k = new Lib_LH.Access_Data();
		private int hitRow;			
		private int _rows,_rowsBS;
		private int _columns,_columnsBS;
		private int pointX, pointY,pointXBS, pointYBS;
		int val;
		string status;
		bool dr;
		private AccessData m=new AccessData();
		private System.Windows.Forms.Button cmdKetthuc;
		private System.Windows.Forms.Button cmdXEM;
		private System.Windows.Forms.Button cmdDENNGAY;
		private System.Windows.Forms.Button cmdDENTUAN;
		private System.Windows.Forms.Button cmdNGAYHT;	
		private System.Windows.Forms.Button cmdLUINGAY;
		private System.Windows.Forms.Button cmdLUITUAN;
		public System.Windows.Forms.ComboBox cmbnhomphong;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dtgLICHHEN;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ContextMenu ctMenu1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem ctm_Xemthongtin;
		private System.Windows.Forms.MenuItem ctm_Xoathongtin;
		private System.Windows.Forms.MenuItem ctm_Henmoi;
		private System.Windows.Forms.Label lbLichhen;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MenuItem ctm_suacuochen;
		private System.Windows.Forms.MenuItem ctm_benhnhanden;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem ctm_Inphieuhen;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MenuItem ctm_bohen;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem ctm_lammoi;
		private System.Windows.Forms.DataGrid dtgLHBS;
		private System.Windows.Forms.ToolTip toolTip2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.ContextMenu ctmhethong;
		private System.Windows.Forms.MenuItem ctm2_xembs;
		private System.Windows.Forms.MenuItem ctm2_xemphong;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem ctm2_phancong;
		private System.Windows.Forms.MenuItem ctm2_inlichhen;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem ctm2_thoigian;
		private System.Windows.Forms.MenuItem ctm2_phong;
		private System.Windows.Forms.MenuItem ctm2_loaihen;
		private System.Windows.Forms.MenuItem ctm2_tinhtrang;
		private System.Windows.Forms.MenuItem ctm2_nhomphong;
		private System.Windows.Forms.ContextMenu ctm_all;
		private System.Windows.Forms.MenuItem ctm_tatca;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtpLICHHEN;	
	
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					object o = this.GetColumnValueAtRow(source, rowNum);
					if( o!= null)
					{
						string t=o.ToString();
						string ten=o.ToString();
						if(ten.Length!=0)
						{
							string gio =t.Substring(0,1);
							switch(gio)
							{
								case "0":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;

								case "1":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;	

								case "2":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;

								case "3":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;	

								case "4":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;	

								case "5":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;	

								case "6":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;	

								case "7":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;

								case "8":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;	

								case "9":
									backBrush = new LinearGradientBrush(bounds,Color.LightYellow,Color.LightYellow,LinearGradientMode.BackwardDiagonal);
									foreBrush = new SolidBrush(Color.Red);
									break;	
								default:	
									if(t==ten)
									{
										backBrush = new LinearGradientBrush(bounds,Color.DeepSkyBlue  ,Color.White,LinearGradientMode.BackwardDiagonal);
										foreBrush = new SolidBrush(Color.Red);
//										backBrush = new LinearGradientBrush(bounds,Color.Red,Color.Red,LinearGradientMode.BackwardDiagonal);
//										foreBrush = new SolidBrush(Color.White);
									}
									break;
							}							
						}
					}
				}
				catch(Exception ex)
				{ 
					MessageBox.Show(ex.ToString());
				}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
		private System.ComponentModel.IContainer components;

		public LICHHEN(long b_maql, string b_makp, string b_mabs,long b_idnhapkhoa, int b_loaiba)
		{
			u_mabs =b_mabs;
			u_makp =b_makp;
			u_maql=b_maql;
			u_idnhapkhoa = b_idnhapkhoa;
			u_loaiba=b_loaiba;
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LICHHEN));
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.cmdXEM = new System.Windows.Forms.Button();
			this.cmdDENNGAY = new System.Windows.Forms.Button();
			this.cmdDENTUAN = new System.Windows.Forms.Button();
			this.cmdNGAYHT = new System.Windows.Forms.Button();
			this.lbLichhen = new System.Windows.Forms.Label();
			this.ctmhethong = new System.Windows.Forms.ContextMenu();
			this.ctm2_xembs = new System.Windows.Forms.MenuItem();
			this.ctm2_xemphong = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.ctm2_phancong = new System.Windows.Forms.MenuItem();
			this.ctm2_inlichhen = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.ctm2_thoigian = new System.Windows.Forms.MenuItem();
			this.ctm2_phong = new System.Windows.Forms.MenuItem();
			this.ctm2_loaihen = new System.Windows.Forms.MenuItem();
			this.ctm2_tinhtrang = new System.Windows.Forms.MenuItem();
			this.ctm2_nhomphong = new System.Windows.Forms.MenuItem();
			this.ctMenu1 = new System.Windows.Forms.ContextMenu();
			this.ctm_Henmoi = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.ctm_lammoi = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.ctm_Xemthongtin = new System.Windows.Forms.MenuItem();
			this.ctm_suacuochen = new System.Windows.Forms.MenuItem();
			this.ctm_Xoathongtin = new System.Windows.Forms.MenuItem();
			this.ctm_bohen = new System.Windows.Forms.MenuItem();
			this.ctm_benhnhanden = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.ctm_Inphieuhen = new System.Windows.Forms.MenuItem();
			this.cmdLUINGAY = new System.Windows.Forms.Button();
			this.cmdLUITUAN = new System.Windows.Forms.Button();
			this.cmbnhomphong = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtpLICHHEN = new System.Windows.Forms.DateTimePicker();
			this.dtgLICHHEN = new System.Windows.Forms.DataGrid();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dtgLHBS = new System.Windows.Forms.DataGrid();
			this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ctm_all = new System.Windows.Forms.ContextMenu();
			this.ctm_tatca = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgLICHHEN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgLHBS)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.BackColor = System.Drawing.Color.SteelBlue;
			this.cmdKetthuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdKetthuc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.cmdKetthuc.Location = new System.Drawing.Point(632, 32);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(80, 32);
			this.cmdKetthuc.TabIndex = 2;
			this.cmdKetthuc.Text = "Kết Thúc";
			this.toolTip1.SetToolTip(this.cmdKetthuc, "Đóng màn hình Lịch Hẹn");
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// cmdXEM
			// 
			this.cmdXEM.BackColor = System.Drawing.Color.SteelBlue;
			this.cmdXEM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdXEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdXEM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.cmdXEM.Location = new System.Drawing.Point(504, 32);
			this.cmdXEM.Name = "cmdXEM";
			this.cmdXEM.Size = new System.Drawing.Size(128, 32);
			this.cmdXEM.TabIndex = 5;
			this.cmdXEM.Text = "Cập Nhật Lại Hẹn";
			this.toolTip1.SetToolTip(this.cmdXEM, "Load lại thông tin các cuộc hẹn lên màn hình");
			this.cmdXEM.Click += new System.EventHandler(this.cmdXEM_Click);
			// 
			// cmdDENNGAY
			// 
			this.cmdDENNGAY.BackColor = System.Drawing.Color.SteelBlue;
			this.cmdDENNGAY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdDENNGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdDENNGAY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.cmdDENNGAY.Location = new System.Drawing.Point(424, 32);
			this.cmdDENNGAY.Name = "cmdDENNGAY";
			this.cmdDENNGAY.Size = new System.Drawing.Size(40, 32);
			this.cmdDENNGAY.TabIndex = 7;
			this.cmdDENNGAY.Text = ">";
			this.toolTip1.SetToolTip(this.cmdDENNGAY, "Đến 1 ngày");
			this.cmdDENNGAY.Click += new System.EventHandler(this.cmdDENNGAY_Click);
			// 
			// cmdDENTUAN
			// 
			this.cmdDENTUAN.BackColor = System.Drawing.Color.SteelBlue;
			this.cmdDENTUAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdDENTUAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdDENTUAN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.cmdDENTUAN.Location = new System.Drawing.Point(464, 32);
			this.cmdDENTUAN.Name = "cmdDENTUAN";
			this.cmdDENTUAN.Size = new System.Drawing.Size(40, 32);
			this.cmdDENTUAN.TabIndex = 8;
			this.cmdDENTUAN.Text = "+ 7";
			this.toolTip1.SetToolTip(this.cmdDENTUAN, "Đến 1 tuần");
			this.cmdDENTUAN.Click += new System.EventHandler(this.cmdDENTUAN_Click);
			// 
			// cmdNGAYHT
			// 
			this.cmdNGAYHT.BackColor = System.Drawing.Color.SteelBlue;
			this.cmdNGAYHT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdNGAYHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdNGAYHT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.cmdNGAYHT.Location = new System.Drawing.Point(312, 32);
			this.cmdNGAYHT.Name = "cmdNGAYHT";
			this.cmdNGAYHT.Size = new System.Drawing.Size(112, 32);
			this.cmdNGAYHT.TabIndex = 9;
			this.toolTip1.SetToolTip(this.cmdNGAYHT, "Ngày hôm nay");
			this.cmdNGAYHT.Click += new System.EventHandler(this.cmdNGAYHT_Click);
			// 
			// lbLichhen
			// 
			this.lbLichhen.BackColor = System.Drawing.Color.SteelBlue;
			this.lbLichhen.ContextMenu = this.ctmhethong;
			this.lbLichhen.Name = "lbLichhen";
			this.lbLichhen.Size = new System.Drawing.Size(808, 80);
			this.lbLichhen.TabIndex = 1;
			// 
			// ctmhethong
			// 
			this.ctmhethong.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.ctm2_xembs,
																					   this.ctm2_xemphong,
																					   this.menuItem12,
																					   this.ctm2_phancong,
																					   this.ctm2_inlichhen,
																					   this.menuItem15,
																					   this.menuItem16});
			// 
			// ctm2_xembs
			// 
			this.ctm2_xembs.Index = 0;
			this.ctm2_xembs.Text = "1. Xem theo Bác Sĩ";
			this.ctm2_xembs.Click += new System.EventHandler(this.ctm2_xembs_Click);
			// 
			// ctm2_xemphong
			// 
			this.ctm2_xemphong.Index = 1;
			this.ctm2_xemphong.Text = "2. Xem theo Phòng";
			this.ctm2_xemphong.Click += new System.EventHandler(this.ctm2_xemphong_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.Text = "-";
			// 
			// ctm2_phancong
			// 
			this.ctm2_phancong.Index = 3;
			this.ctm2_phancong.Text = "3. Phân công khám";
			this.ctm2_phancong.Click += new System.EventHandler(this.ctm2_phancong_Click);
			// 
			// ctm2_inlichhen
			// 
			this.ctm2_inlichhen.Index = 4;
			this.ctm2_inlichhen.Text = "4. In lịch hẹn";
			this.ctm2_inlichhen.Click += new System.EventHandler(this.ctm2_inlichhen_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 5;
			this.menuItem15.Text = "-";
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 6;
			this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.ctm2_thoigian,
																					   this.ctm2_phong,
																					   this.ctm2_loaihen,
																					   this.ctm2_tinhtrang,
																					   this.ctm2_nhomphong});
			this.menuItem16.Text = "5. Danh mục";
			// 
			// ctm2_thoigian
			// 
			this.ctm2_thoigian.Index = 0;
			this.ctm2_thoigian.Text = "A.Thời gian làm việc";
			this.ctm2_thoigian.Click += new System.EventHandler(this.ctm2_thoigian_Click);
			// 
			// ctm2_phong
			// 
			this.ctm2_phong.Index = 1;
			this.ctm2_phong.Text = "B. Phòng";
			this.ctm2_phong.Click += new System.EventHandler(this.ctm2_phong_Click);
			// 
			// ctm2_loaihen
			// 
			this.ctm2_loaihen.Index = 2;
			this.ctm2_loaihen.Text = "C. Loại hẹn";
			this.ctm2_loaihen.Click += new System.EventHandler(this.ctm2_loaihen_Click);
			// 
			// ctm2_tinhtrang
			// 
			this.ctm2_tinhtrang.Index = 3;
			this.ctm2_tinhtrang.Text = "D. Tình trạng hẹn";
			this.ctm2_tinhtrang.Click += new System.EventHandler(this.ctm2_tinhtrang_Click);
			// 
			// ctm2_nhomphong
			// 
			this.ctm2_nhomphong.Index = 4;
			this.ctm2_nhomphong.Text = "E. Nhóm phòng";
			this.ctm2_nhomphong.Click += new System.EventHandler(this.ctm2_nhomphong_Click);
			// 
			// ctMenu1
			// 
			this.ctMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.ctm_Henmoi,
																					this.menuItem4,
																					this.ctm_lammoi,
																					this.menuItem3,
																					this.ctm_Xemthongtin,
																					this.ctm_suacuochen,
																					this.ctm_Xoathongtin,
																					this.ctm_bohen,
																					this.ctm_benhnhanden,
																					this.menuItem2,
																					this.ctm_Inphieuhen});
			this.ctMenu1.Popup += new System.EventHandler(this.ctMenu1_Popup);
			// 
			// ctm_Henmoi
			// 
			this.ctm_Henmoi.Index = 0;
			this.ctm_Henmoi.Text = "1. Tạo hẹn mới";
			this.ctm_Henmoi.Click += new System.EventHandler(this.ctm_Henmoi_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "-";
			// 
			// ctm_lammoi
			// 
			this.ctm_lammoi.Index = 2;
			this.ctm_lammoi.Text = "2. Cập nhật hẹn";
			this.ctm_lammoi.Click += new System.EventHandler(this.ctm_lammoi_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "-";
			// 
			// ctm_Xemthongtin
			// 
			this.ctm_Xemthongtin.Index = 4;
			this.ctm_Xemthongtin.Text = "3. Xem cuộc hẹn";
			this.ctm_Xemthongtin.Click += new System.EventHandler(this.ctm_Xemthongtin_Click);
			// 
			// ctm_suacuochen
			// 
			this.ctm_suacuochen.Index = 5;
			this.ctm_suacuochen.Text = "4. Sửa cuộc hẹn";
			this.ctm_suacuochen.Click += new System.EventHandler(this.ctm_suacuochen_Click);
			// 
			// ctm_Xoathongtin
			// 
			this.ctm_Xoathongtin.Index = 6;
			this.ctm_Xoathongtin.Text = "5. Xoá cuộc hẹn";
			this.ctm_Xoathongtin.Click += new System.EventHandler(this.ctm_Xoathongtin_Click);
			// 
			// ctm_bohen
			// 
			this.ctm_bohen.Index = 7;
			this.ctm_bohen.Text = "6. Bỏ hẹn";
			this.ctm_bohen.Click += new System.EventHandler(this.ctm_bohen_Click);
			// 
			// ctm_benhnhanden
			// 
			this.ctm_benhnhanden.Index = 8;
			this.ctm_benhnhanden.Text = "7. Bệnh nhân đến";
			this.ctm_benhnhanden.Click += new System.EventHandler(this.ctm_benhnhanden_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 9;
			this.menuItem2.Text = "-";
			// 
			// ctm_Inphieuhen
			// 
			this.ctm_Inphieuhen.Index = 10;
			this.ctm_Inphieuhen.Text = "8. In Phiếu hẹn";
			this.ctm_Inphieuhen.Click += new System.EventHandler(this.ctm_Inphieuhen_Click);
			// 
			// cmdLUINGAY
			// 
			this.cmdLUINGAY.BackColor = System.Drawing.Color.SteelBlue;
			this.cmdLUINGAY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdLUINGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdLUINGAY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.cmdLUINGAY.Location = new System.Drawing.Point(272, 32);
			this.cmdLUINGAY.Name = "cmdLUINGAY";
			this.cmdLUINGAY.Size = new System.Drawing.Size(40, 32);
			this.cmdLUINGAY.TabIndex = 10;
			this.cmdLUINGAY.Text = "<";
			this.toolTip1.SetToolTip(this.cmdLUINGAY, "Lùi lại 1 ngày");
			this.cmdLUINGAY.Click += new System.EventHandler(this.cmdLUINGAY_Click);
			// 
			// cmdLUITUAN
			// 
			this.cmdLUITUAN.BackColor = System.Drawing.Color.SteelBlue;
			this.cmdLUITUAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdLUITUAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdLUITUAN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.cmdLUITUAN.Location = new System.Drawing.Point(232, 32);
			this.cmdLUITUAN.Name = "cmdLUITUAN";
			this.cmdLUITUAN.Size = new System.Drawing.Size(40, 32);
			this.cmdLUITUAN.TabIndex = 11;
			this.cmdLUITUAN.Text = "-7";
			this.toolTip1.SetToolTip(this.cmdLUITUAN, "Lùi lại 1 tuần");
			this.cmdLUITUAN.Click += new System.EventHandler(this.cmdLUITUAN_Click);
			// 
			// cmbnhomphong
			// 
			this.cmbnhomphong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbnhomphong.DropDownWidth = 130;
			this.cmbnhomphong.ItemHeight = 13;
			this.cmbnhomphong.Location = new System.Drawing.Point(8, 38);
			this.cmbnhomphong.Name = "cmbnhomphong";
			this.cmbnhomphong.Size = new System.Drawing.Size(121, 21);
			this.cmbnhomphong.TabIndex = 14;
			this.cmbnhomphong.SelectedIndexChanged += new System.EventHandler(this.cmbnhomphong_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.dtpLICHHEN,
																					this.cmbnhomphong});
			this.groupBox1.Location = new System.Drawing.Point(16, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(136, 70);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			// 
			// dtpLICHHEN
			// 
			this.dtpLICHHEN.CustomFormat = "dd/MM/yyyy hh:mm";
			this.dtpLICHHEN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpLICHHEN.Location = new System.Drawing.Point(8, 16);
			this.dtpLICHHEN.Name = "dtpLICHHEN";
			this.dtpLICHHEN.Size = new System.Drawing.Size(120, 20);
			this.dtpLICHHEN.TabIndex = 15;
			this.dtpLICHHEN.ValueChanged += new System.EventHandler(this.dtpLICHHEN_ValueChanged);
			// 
			// dtgLICHHEN
			// 
			this.dtgLICHHEN.AllowSorting = false;
			this.dtgLICHHEN.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgLICHHEN.BackColor = System.Drawing.Color.White;
			this.dtgLICHHEN.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.dtgLICHHEN.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgLICHHEN.CaptionVisible = false;
			this.dtgLICHHEN.ContextMenu = this.ctMenu1;
			this.dtgLICHHEN.DataMember = "";
			this.dtgLICHHEN.FlatMode = true;
			this.dtgLICHHEN.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgLICHHEN.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.dtgLICHHEN.HeaderBackColor = System.Drawing.Color.DarkSlateBlue;
			this.dtgLICHHEN.HeaderForeColor = System.Drawing.Color.Yellow;
			this.dtgLICHHEN.Location = new System.Drawing.Point(0, 80);
			this.dtgLICHHEN.Name = "dtgLICHHEN";
			this.dtgLICHHEN.ReadOnly = true;
			this.dtgLICHHEN.RowHeaderWidth = 20;
			this.dtgLICHHEN.SelectionBackColor = System.Drawing.Color.Red;
			this.dtgLICHHEN.SelectionForeColor = System.Drawing.Color.White;
			this.dtgLICHHEN.Size = new System.Drawing.Size(800, 470);
			this.dtgLICHHEN.TabIndex = 12;
			this.dtgLICHHEN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtgLICHHEN_MouseDown);
			this.dtgLICHHEN.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtgLICHHEN_MouseMove);
			this.dtgLICHHEN.CursorChanged += new System.EventHandler(this.dtgLICHHEN_CursorChanged);
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 300;
			this.toolTip1.AutoPopDelay = 6000;
			this.toolTip1.InitialDelay = 300;
			this.toolTip1.ReshowDelay = 150;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.SteelBlue;
			this.label1.Location = new System.Drawing.Point(392, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 21;
			this.label1.Visible = false;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.SteelBlue;
			this.label2.Location = new System.Drawing.Point(200, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 23);
			this.label2.TabIndex = 23;
			this.label2.Visible = false;
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.SteelBlue;
			this.label3.Location = new System.Drawing.Point(504, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(192, 23);
			this.label3.TabIndex = 25;
			this.label3.Visible = false;
			// 
			// dtgLHBS
			// 
			this.dtgLHBS.AllowSorting = false;
			this.dtgLHBS.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgLHBS.BackColor = System.Drawing.Color.White;
			this.dtgLHBS.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.dtgLHBS.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgLHBS.CaptionVisible = false;
			this.dtgLHBS.ContextMenu = this.ctMenu1;
			this.dtgLHBS.DataMember = "";
			this.dtgLHBS.FlatMode = true;
			this.dtgLHBS.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgLHBS.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.dtgLHBS.HeaderBackColor = System.Drawing.Color.DarkSlateBlue;
			this.dtgLHBS.HeaderForeColor = System.Drawing.Color.Yellow;
			this.dtgLHBS.Location = new System.Drawing.Point(0, 80);
			this.dtgLHBS.Name = "dtgLHBS";
			this.dtgLHBS.ReadOnly = true;
			this.dtgLHBS.RowHeaderWidth = 20;
			this.dtgLHBS.SelectionBackColor = System.Drawing.Color.Red;
			this.dtgLHBS.SelectionForeColor = System.Drawing.Color.White;
			this.dtgLHBS.Size = new System.Drawing.Size(800, 470);
			this.dtgLHBS.TabIndex = 27;
			this.dtgLHBS.Visible = false;
			this.dtgLHBS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtgLHBS_MouseDown);
			this.dtgLHBS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtgLHBS_MouseMove);
			this.dtgLHBS.CursorChanged += new System.EventHandler(this.dtgLHBS_CursorChanged);
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.SteelBlue;
			this.label4.Location = new System.Drawing.Point(536, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 23);
			this.label4.TabIndex = 29;
			this.label4.Visible = false;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.SteelBlue;
			this.label5.Location = new System.Drawing.Point(744, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 32);
			this.label5.TabIndex = 31;
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// ctm_all
			// 
			this.ctm_all.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.ctm_tatca});
			// 
			// ctm_tatca
			// 
			this.ctm_tatca.Index = 0;
			this.ctm_tatca.Text = "Xem tất cả";
			this.ctm_tatca.Click += new System.EventHandler(this.ctm_tatca_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = -1;
			this.menuItem8.Text = "";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.SteelBlue;
			this.label6.ContextMenu = this.ctm_all;
			this.label6.Location = new System.Drawing.Point(768, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(24, 40);
			this.label6.TabIndex = 33;
			// 
			// LICHHEN
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 564);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.dtgLHBS,
																		  this.label3,
																		  this.label2,
																		  this.groupBox1,
																		  this.dtgLICHHEN,
																		  this.cmdLUITUAN,
																		  this.cmdLUINGAY,
																		  this.cmdNGAYHT,
																		  this.cmdDENTUAN,
																		  this.cmdDENNGAY,
																		  this.cmdXEM,
																		  this.cmdKetthuc,
																		  this.lbLichhen});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "LICHHEN";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lịch hẹn";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LICHHEN_KeyDown);
			this.Click += new System.EventHandler(this.LICHHEN_Click);
			this.Load += new System.EventHandler(this.LICHHEN_Load);
			this.Activated += new System.EventHandler(this.LICHHEN_Activated);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgLICHHEN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgLHBS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{			
			this.Close();
		}		
		
		private void cmdLUITUAN_Click(object sender, System.EventArgs e)
		{
			dtpLICHHEN.Value=dtpLICHHEN.Value.AddDays(-7);
		}

		private void cmdDENTUAN_Click(object sender, System.EventArgs e)
		{
			dtpLICHHEN.Value=dtpLICHHEN.Value.AddDays(7);
		}

		private void cmdLUINGAY_Click(object sender, System.EventArgs e)
		{
			dtpLICHHEN.Value=dtpLICHHEN.Value.AddDays(-1);
		}

		private void cmdDENNGAY_Click(object sender, System.EventArgs e)
		{
			dtpLICHHEN.Value=dtpLICHHEN.Value.AddDays(1);
		}

		private void cmdNGAYHT_Click(object sender, System.EventArgs e)
		{
			dtpLICHHEN.Value = DateTime.Today.Date;
		}

		private void cmdXEM_Click(object sender, System.EventArgs e)
		{
			LoadPhong(cmbnhomphong.SelectedValue.ToString());
		}

		private void LICHHEN_Load(object sender, System.EventArgs e)
		{	
//			if(u_mabs.Length<=0 || u_mabs ==null)		
//			{seeallbs=true;	}
//			else
//			{seeallbs=false;}
//			if(u_makp.Length<=0 || u_makp == null)
//			{seeallkp=true;	}
//			else
//			{seeallkp=false;}
//			if(seeallbs==false)
//			{
//				DsBS = k.get_data("select mabs,hoten from(Select distinct a.mabs, b.hoten from lh_phancong a, dmbs b where a.mabs=b.ma and a.ngaylam=to_date('"+dtpLICHHEN.Text.Substring(0,10)+"','dd/mm/yyyy')) where mabs='"+u_mabs+"'");
//				if (DsBS.Tables[0].Rows.Count==0) DsBS =k.get_data("Select ma,hoten from dmbs where nhom=0");
//			}
//			else
//			{
//				DsBS =k.get_data("Select ma,hoten from dmbs where nhom=0");
//			}
//			dtgLHBS.DataSource=DsBS.Tables[0];			
			Load_cmbnhomphong();
			LoadPhong(cmbnhomphong.SelectedValue.ToString());
			Load_bacsi();
			//dtpLICHHEN.Value = DateTime.Today.Date;			
			Load_hand();
			ctm2_xemphong.Checked=true;
//			m.DateToString("dd/MM/yyyy",DateTime.Parse(dt.Rows[0]["NGAYKHAM"].ToString().Substring(0,10)));
            cmdNGAYHT.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(DateTime.Now.ToShortDateString()));			
			xulydoiso();
		}

		private void SetcellFocus(DataGrid myGrid)
		{
			myGrid.CurrentCell= new DataGridCell(0,0);
		}

		private void Load_cmbnhomphong()
		{			
			try
			{
				cmbnhomphong.DisplayMember="TENNHOM";
				cmbnhomphong.ValueMember="MANHOM";
				cmbnhomphong.DataSource=k.Get_nhomphong().Tables[0];
				cmbnhomphong.SelectedIndex = 0;
			}
			catch
			{				
			}
		}

		private void cmbnhomphong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(cmbnhomphong.SelectedIndex!=-1)
				{				
					LoadPhong(cmbnhomphong.SelectedValue.ToString());					
					val = int.Parse(cmbnhomphong.SelectedValue.ToString());
				}
				else
				{}			
			}
			catch
			{
				return;
			}
		}

		public void LoadPhong(string manhom)
		{		
			Load_info();			
			if(dr==true)
			{
				Load_bacsi();
			}
			else
			{
				try
				{	
					DataColumn[] arrdclPK = new DataColumn[1];			
					dtbUser = new DataTable();
					dclUser = new DataColumn();
					dclUser.ColumnName="Time";
					dclUser.DataType=Type.GetType("System.String");
					dclUser.MaxLength=100;
					dclUser.AllowDBNull=true;	
					dtbUser.Columns.Add(dclUser);
					arrdclPK[0]=dclUser;
//					u_makp ="40";
					if(seeallkp==false)
					{
						Dskhoaphong =k.get_data("select tenkp from btdkp_bv where makp='"+u_makp+"'");
					}
					else
					{
						Dskhoaphong = k.Get_tenkp(manhom);// load ten phòng theo mã nhóm
					}
					dtbkhoaphong = Dskhoaphong.Tables[0];// đổ dữ liệu vào datatable
					cot = dtbkhoaphong.Rows.Count;			
					for(int i=0;i<cot;i++)// create datacolumn
					{
						dclUser = new DataColumn();
						dclUser.ColumnName =dtbkhoaphong.Rows[i][0].ToString();				
						dclUser.DataType=Type.GetType("System.String");
						dclUser.MaxLength=150;
						dclUser.AllowDBNull=true;
						dtbUser.Columns.Add(dclUser);
						phongkham[i]= dtbkhoaphong.Rows[i][0].ToString();// lưu tên phòng vào một chuỗi 
					}		
					DataSet Dsgio=k.Loadgio();
					dt = Dsgio.Tables[0];
					dong = dt.Rows.Count;
					for(int j=0;j<dong;j++)
					{
						drw = dtbUser.NewRow();				
						drw["Time"]=dt.Rows[j][0].ToString();// neu drw[time]= 1 so nao do co trong du lieu cu
						for(int i=0;i<cot;i++)	
						{							
							string tennguoi = sosanh(dt.Rows[j][0].ToString(),dtbkhoaphong.Rows[i][0].ToString());
							if(tennguoi==null)tennguoi="";
							drw[dtbkhoaphong.Rows[i][0].ToString()]=tennguoi;
						}
						dtbUser.Rows.Add(drw);
					}	
					dtgLICHHEN.DataSource=dtbUser;					
					Dsgio.Clear();
					AddGridStyle();	
				}
				catch(Exception caught )
				{					
					MessageBox.Show(caught.Message);
				}
			}
		}

		private void dtgLICHHEN_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				DataGrid.HitTestInfo hti = dtgLICHHEN.HitTest(new Point(e.X,e.Y));
				BindingManagerBase bmb = BindingContext[dtgLICHHEN.DataSource,dtgLICHHEN.DataMember];
				if(hti.Row < bmb.Count && hti.Type==DataGrid.HitTestType.Cell && hti.Row !=hitRow)
				{
					_rows =hti.Row;
					_columns = hti.Column;

					if(toolTip1 != null && toolTip1.Active)	toolTip1.Active=false;

					string tiptext = "";
					tiptext = dtgLICHHEN[hti.Row,0].ToString();
					if(tiptext!="")
					{
						hitRow = hti.Row;
						if(dtgLICHHEN[hti.Row,hti.Column].ToString()!="")
						{
							DataSet ds = new DataSet();
							DataTable dt = new DataTable();
							ds=k.get_data(dtgLICHHEN[hti.Row,0].ToString(),dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLICHHEN[hti.Row,hti.Column].ToString());
							dt = ds.Tables[0];
							if(dt.Rows.Count>0)
							{
								string hoten = dt.Rows[0]["HOTEN"].ToString();	
								string namsinh = dt.Rows[0]["NAMSINH"].ToString();
								string ngaykham = m.DateToString("dd/MM/yyyy",DateTime.Parse(dt.Rows[0]["NGAYKHAM"].ToString().Substring(0,10)));
//								string ngaykham = dt.Rows[0]["NGAYKHAM"].ToString().Substring(0,10);
								string giokham = dt.Rows[0]["GIOKHAM"].ToString();
								string stt = dt.Rows[0]["STT"].ToString();	
								string name = dt.Rows[0]["HOTENBS"].ToString();
								status = dt.Rows[0]["STATUS"].ToString();
								string status_;
								if(status=="1")
								{	status_="Đã đến";}
								else
								{
										if(status=="0")
									{status_="Chưa đến";}
									else
										status_="Bỏ hẹn";
								}								
								string a = "Họ tên              "+hoten+"\nNăm sinh          "+namsinh+"\nNgày khám       "+ngaykham+"\nGiờ khám          "+ giokham+"\nSố thứ tự         "+stt+"\nTình trạng hẹn "+ status_+"\nBác Sĩ               "+name+"";
								toolTip1.SetToolTip(dtgLICHHEN,a);
							}
							else
							{
								toolTip1.SetToolTip(dtgLICHHEN,dtgLICHHEN[hti.Row,hti.Column].ToString());
							}						
						}
						else
						{
							toolTip1.SetToolTip(dtgLICHHEN,dtgLICHHEN[hti.Row,0].ToString());
						}
						toolTip1.Active=true;
					}	
					else
						hitRow = -1;
				}
				else
				{
					
				}
				label1.Text="R_KP: "+_rows.ToString()+","+_columns.ToString();
			}
			catch(Exception caught)
			{
				MessageBox.Show(caught.Message);
			}
		}

		private void Load_info()
		{
			DataSet ds = new DataSet();
//			string s =dtpLICHHEN.Text.Substring(0,10);
//			string sql="select a.hoten,a.maql,b.giokham,c.tenkp,b.thoigian,d.ma,d.hoten as hotenbs from lh_benhnhan a,lh_khambenh b, btdkp_bv c,dmbs d where a.maql=b.maql and to_char(ngaykham,'dd/mm/yyyy')='"+s+"' and b.phongkham = c.makp and b.mabs=d.ma";
//			ds = k.get_data(sql);

//			ds = k.Get_all(dtpLICHHEN.Value.ToShortDateString().ToString());
			ds = k.Get_all(dtpLICHHEN.Text.Substring(0,10));
			dtable=ds.Tables[0];	

		}

		private void dtpLICHHEN_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{				
				LoadPhong(cmbnhomphong.SelectedValue.ToString());
//				checked_menuCuaso(cmbnhomphong.SelectedValue.ToString());
			}
			catch{MessageBox.Show("dtpLICHHEN_ValueChanged");}
		}

		private void cmdHUY_Click(object sender, System.EventArgs e)
		{}

		private string sosanh(string gio,string tenphong)
		{
			int sodong = dtable.Rows.Count;
			int socot = dtable.Columns.Count;
			for(int i=0;i<sodong;i++)// duyet mang cua bang du lieu tim thay theo ngay
			{
				if(dtable.Rows[i]["GIOKHAM"].ToString()==gio && dtable.Rows[i]["TENKP"].ToString()==tenphong)
				{
					int thoigian =int.Parse(dtable.Rows[i]["THOIGIAN"].ToString());
					if(thoigian>5)
					{
						int times = thoigian/5;
						-- times;
						if(times >=1)
						{
							string gioganvao = tinhgio(dtable.Rows[i]["GIOKHAM"].ToString());
							dtable.Rows[i]["GIOKHAM"]=gioganvao;
							dtable.Rows[i]["THOIGIAN"]= thoigian-5;
						}
					}
					return dtable.Rows[i]["HOTEN"].ToString();
				}				
			}
			return null;
		}

		private string tinhgio(string gio)
		{
			int hour = int.Parse(gio.Substring(0,2));
			int min = int.Parse(gio.Substring(3,2));
			string ho="";
			string mi="";

			min=min+5;
			if(min>=60 || min ==0)
			{
				hour++;
				min = min-60;
			}
			else
			{}

			if(hour.ToString().Length==1)
			{
				ho = "0"+hour.ToString();
			}
			else
			{
				ho=hour.ToString();
			}
			if(min.ToString().Length==1)
			{
				mi = "0"+min.ToString();
			}
			else
			{
				mi = min.ToString();
			}
			string ketqua = ho+":"+mi;
			return ketqua;
		}

		private void LICHHEN_Click(object sender, System.EventArgs e)
		{
			
		}

		private void ctm_Henmoi_Click(object sender, System.EventArgs e)
		{
			if(dtpLICHHEN.Value<DateTime.Today)
			{
				MessageBox.Show("Bạn không thể tạo hẹn mới với ngày đã chọn","Thông Báo");
				return;
			}
			if(dr==true)
			{
//				if(pointXBS >60 && pointYBS > 120 && dtgLHBS[_rowsBS,_columnsBS].ToString() == "")
//				if(pointXBS >60 && pointYBS > 120 && pointXBS < 200 && dtgLHBS[_rowsBS,_columnsBS].ToString() == "")
				if(PX_BS >60 &&  PY_BS > 120 && PX_BS < 200 && dtgLHBS[_rowsBS,_columnsBS].ToString() == "")
				{
					string maql="";
					string makp= Timmakp(dtpLICHHEN.Text.Substring(0,10).ToString(),mabacsi[_columnsBS -1],dtgLHBS[_rowsBS,0].ToString());
					if(!kiemtragiolamviec(dtgLHBS[_rowsBS,0].ToString(),mabacsi[_columnsBS -1],dtpLICHHEN.Text.Substring(0,10).ToString(),makp))
					{
						MessageBox.Show("Không đăng ký hẹn được, BS không làm giờ này","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
					string a=dtgLHBS[_rowsBS,0].ToString();
					DANGKYKHAM frmdangkykham = new DANGKYKHAM(this,dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLHBS[_rowsBS,0].ToString(),u_makp,mabacsi[_columnsBS -1],maql,u_mabn,u_maql,u_loaiba,u_idnhapkhoa,true);
					frmdangkykham.ShowDialog();									
				}
			}
			else
			{
//				if(pointX >60 && pointY > 120 && dtgLICHHEN[_rows,_columns].ToString() == "")
				if(PX_KP >60 && PY_KP  > 120 && PX_KP < 160 && dtgLICHHEN[_rows,_columns].ToString() == "")
				{
					string maql="";
//					int a = _columns -1;
//					string b=mabacsi[_columnsBS -1].ToString();
//					string s = _rowsBS.ToString();
//					string ddd= (dtbBS.Rows.Count>0)?dtbBS.Rows[_rowsBS][0].ToString():"";
//					_columnsBS=(_columnsBS==0)?1:_columnsBS;
					DANGKYKHAM frmdangkykham = new DANGKYKHAM(this,dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLICHHEN[_rows,0].ToString(),u_makp,mabacsi[_columns -1],maql,u_mabn,u_maql,u_loaiba,u_idnhapkhoa,true);
					frmdangkykham.ShowDialog();									
				}
			}			
		}

		private void dtgLICHHEN_CursorChanged(object sender, System.EventArgs e)
		{
			label2.Text="pointX: "+Cursor.Position.X.ToString()+" , "+"pointY :"+Cursor.Position.Y.ToString();
			pointX=int.Parse(Cursor.Position.X.ToString());
			pointY=int.Parse(Cursor.Position.Y.ToString());
		}

		private void ctm_Xemthongtin_Click(object sender, System.EventArgs e)
		{
			if(dr==true)
			{
				if(pointXBS >60 && pointYBS > 120 && dtgLHBS[_rowsBS,_columnsBS].ToString() != "")
				{
					DataSet dts = new DataSet();
					DataTable dtt = new DataTable();
					dts=k.get_data(dtgLHBS[_rowsBS,0].ToString(),dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLHBS[_rowsBS,_columnsBS].ToString());
					dtt = dts.Tables[0];
					if(dtt.Rows.Count>0)
					{
						string id = dtt.Rows[0]["MAQL"].ToString();					
						TTBN frmttbn = new TTBN(this,id);
						frmttbn.ShowDialog();		
						SetcellFocus(dtgLICHHEN);
					}	
				}
			}
			else
			{
				if(pointX >60 && pointY > 120 && dtgLICHHEN[_rows,_columns].ToString() != "")
				{
					DataSet dts = new DataSet();
					DataTable dtt = new DataTable();
					dts=k.get_data(dtgLICHHEN[_rows,0].ToString(),dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLICHHEN[_rows,_columns].ToString());
					dtt = dts.Tables[0];					
					if(dtt.Rows.Count>0)
					{
						string id = dtt.Rows[0]["MAQL"].ToString();					
						TTBN frmttbn = new TTBN(this,id);
						frmttbn.ShowDialog();		
						SetcellFocus(dtgLICHHEN);
					}	
				}
			}
		}

		private void Load_hand()
		{
			cmdDENNGAY.Cursor=Cursors.Hand;
			cmdDENTUAN.Cursor=Cursors.Hand;
			cmdKetthuc.Cursor=Cursors.Hand;
			cmdLUINGAY.Cursor=Cursors.Hand;
			cmdLUITUAN.Cursor=Cursors.Hand;
			cmdNGAYHT.Cursor=Cursors.Hand;			
			cmdXEM.Cursor=Cursors.Hand;
		}

		private void ctm_Xoathongtin_Click(object sender, System.EventArgs e)
		{
			if(ctm_benhnhanden.Checked)
			{
				MessageBox.Show("Cuộc hẹn đã hoàn thành","Thông Báo");
				return;
			}
			else
			{
				if(dr==true)
				{
					if(pointXBS >60 && pointYBS > 120 && dtgLHBS[_rowsBS,_columnsBS].ToString() != "")
					{
						DataSet dts = new DataSet();
						DataTable dtt = new DataTable();
						dts=k.get_data(dtgLHBS[_rowsBS,0].ToString(),dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLHBS[_rowsBS,_columnsBS].ToString());
						dtt = dts.Tables[0];					
						if(dtt.Rows.Count>0)
						{
							int id = int.Parse(dtt.Rows[0]["MAQL"].ToString());					
							string sql="";
							if(MessageBox.Show("Chắc chắn xoá cuộc hẹn này ?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
							{				
								sql="delete from lh_benhnhan where maql="+id;
								k.Excute_data(sql);
								sql="delete from lh_khambenh where maql="+id;
								k.Excute_data(sql);						
								LoadPhong(cmbnhomphong.SelectedValue.ToString());
								SetcellFocus(dtgLICHHEN);
							}
						}	
					}
				}
				else
				{
					if(pointX >60 && pointY > 120 && dtgLICHHEN[_rows,_columns].ToString() != "")
					{
						DataSet dts = new DataSet();
						DataTable dtt = new DataTable();
						dts=k.get_data(dtgLICHHEN[_rows,0].ToString(),dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLICHHEN[_rows,_columns].ToString());
						dtt = dts.Tables[0];					
						if(dtt.Rows.Count>0)
						{
							int id = int.Parse(dtt.Rows[0]["MAQL"].ToString());					
							string sql="";
							if(MessageBox.Show("Chắc chắn xoá cuộc hẹn này ?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
							{				
								sql="delete from lh_benhnhan where maql="+id;
								k.Excute_data(sql);
								sql="delete from lh_khambenh where maql="+id;
								k.Excute_data(sql);						
								LoadPhong(cmbnhomphong.SelectedValue.ToString());
								SetcellFocus(dtgLICHHEN);
							}
						}	
					}
				}
			}
		}

		private void ctm_suacuochen_Click(object sender, System.EventArgs e)
		{
			if(ctm_benhnhanden.Checked)
			{
				MessageBox.Show("Cuộc hẹn đã hoàn thành","Thông Báo");
				return;
			}
			else
			{
//				string mabn1="";
				if(dr==true)
				{
					if(pointXBS >60 && pointYBS > 120 && dtgLHBS[_rowsBS,_columnsBS].ToString() != "")
					{
						DataSet dts = new DataSet();
						DataTable dtt = new DataTable();
						dts=k.get_data(dtgLHBS[_rowsBS,0].ToString(),dtpLICHHEN.Text.Substring(0,10),dtgLHBS[_rowsBS,_columnsBS].ToString());
						dtt = dts.Tables[0];					
						if(dtt.Rows.Count>0)
						{							
							string maql = dtt.Rows[0]["MAQL"].ToString();					
							string makp= Timmakp(dtpLICHHEN.Text.Substring(0,10),mabacsi[_columnsBS -1],dtgLHBS[_rowsBS,0].ToString());

								DANGKYKHAM frmdangkykham = new DANGKYKHAM(this,dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLHBS[_rowsBS,0].ToString(),u_makp,mabacsi[_columnsBS -1],maql,u_mabn,u_maql,u_loaiba,u_idnhapkhoa,false);
								frmdangkykham.ShowDialog();									
							SetcellFocus(dtgLICHHEN);
						}	
					}
				}
				else
				{
					if(pointX >60 && pointY > 120 && dtgLICHHEN[_rows,_columns].ToString() != "")
					{
						DataSet dts = new DataSet();
						DataTable dtt = new DataTable();
						dts=k.get_data(dtgLICHHEN[_rows,0].ToString(),dtpLICHHEN.Text.Substring(0,10),dtgLICHHEN[_rows,_columns].ToString());
						dtt = dts.Tables[0];					
						if(dtt.Rows.Count>0)
						{
							string maql = dtt.Rows[0]["MAQL"].ToString();					
							DANGKYKHAM frmdangkykham = new DANGKYKHAM(this,dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLICHHEN[_rows,0].ToString(),u_makp,mabacsi[_columns -1],maql,u_mabn,u_maql,u_loaiba,u_idnhapkhoa,false);
							frmdangkykham.ShowDialog();									
							SetcellFocus(dtgLICHHEN);
						}	
					}
				}
			}
		}

		private void LICHHEN_Activated(object sender, System.EventArgs e)
		{
			try
			{
				LoadPhong(cmbnhomphong.SelectedValue.ToString());
			}
			catch{}
		}

		private void ctm_benhnhanden_Click(object sender, System.EventArgs e)
		{
			if(pointX >60 && pointY > 120 && dtgLICHHEN[_rows,_columns].ToString() != "")
			{
				DataSet dts = new DataSet();
				DataTable dtt = new DataTable();
				dts=k.get_data(dtgLICHHEN[_rows,0].ToString(),dtpLICHHEN.Text.Substring(0,10),dtgLICHHEN[_rows,_columns].ToString());
				dtt = dts.Tables[0];					
				if(dtt.Rows.Count>0)
				{
					string maql = dtt.Rows[0]["MAQL"].ToString();	
					if(ctm_benhnhanden.Checked)
					{
						k.Excute_data("Update lh_khambenh set status=0 where maql="+int.Parse(maql.ToString())+"");
					}
					else
					{
						k.Excute_data("Update lh_khambenh set status=1 where maql="+int.Parse(maql.ToString())+"");
					}
					SetcellFocus(dtgLICHHEN);
				}	
			}		
		}

		private void ctMenu1_Popup(object sender, System.EventArgs e)
		{
			if(pointX >60 && pointY > 120 && dtgLICHHEN[_rows,_columns].ToString() != "")
			{
				if(status=="1")
				{
					ctm_benhnhanden.Checked=true;
					ctm_bohen.Checked=false;
				}
				else
				{
					if(status=="0")
					{
						ctm_benhnhanden.Checked =false;
						ctm_bohen.Checked=false;
					}
					else
					{
						if(status=="2")
						{
							ctm_bohen.Checked =true;
							ctm_benhnhanden.Checked=false;
						}
					}
				}
			}
		}

		private void ctm_bohen_Click(object sender, System.EventArgs e)
		{
			if(pointX >60 && pointY > 120 && dtgLICHHEN[_rows,_columns].ToString() != "")
			{
				DataSet dts = new DataSet();
				DataTable dtt = new DataTable();
				dts=k.get_data(dtgLICHHEN[_rows,0].ToString(),dtpLICHHEN.Text.Substring(0,10),dtgLICHHEN[_rows,_columns].ToString());
				dtt = dts.Tables[0];					
				if(dtt.Rows.Count>0)
				{
					string maql = dtt.Rows[0]["MAQL"].ToString();	
					if(ctm_bohen.Checked==false)
					{
						k.Excute_data("Update lh_khambenh set status=2 where maql="+int.Parse(maql.ToString())+"");
					}
					else
					{
						MessageBox.Show("Cuộc hẹn đã không thực hiện","Thông Báo");						
						//k.Excute_data("Update lh_khambenh set status=1 where maql="+int.Parse(maql.ToString())+"");
					}
					SetcellFocus(dtgLICHHEN);
				}	
			}
		}

		private void ctm_lammoi_Click(object sender, System.EventArgs e)
		{
			LoadPhong(cmbnhomphong.SelectedValue.ToString());
		}

		private void menuItemNhomphong_Click(object sender, System.EventArgs e)
		{
			
		}

		private void AddGridStyle()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName = dtbUser.TableName;
			
			tbs.AlternatingBackColor = Color.White;
			tbs.BackColor = Color.White;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.DarkSlateBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.RowHeaderWidth=10;
			tbs.AllowSorting=false;
			tbs.ReadOnly=true;

			int numCols = dtbUser.Columns.Count;
			DataGridColoredTextBoxColumn aColumnTextColumn;//=new DataGridColoredTextBoxColumn(hvtemp) ;
			for(int i = 0; i < numCols; ++i)
			{
				aColumnTextColumn = new DataGridColoredTextBoxColumn();
				aColumnTextColumn.HeaderText = dtbUser.Columns[i].ColumnName;
				aColumnTextColumn.MappingName = dtbUser.Columns[i].ColumnName;
				if(i==0)
				{aColumnTextColumn.Width =40;}
				else
				{aColumnTextColumn.Width =100;}
				tbs.GridColumnStyles.Add(aColumnTextColumn);
			}
			dtgLICHHEN.TableStyles.Clear();
			dtgLICHHEN.TableStyles.Add(tbs);						
			dtgLICHHEN.DataSource = dtbUser;
		}

		private void mnuXemBS_Click(object sender, System.EventArgs e)
		{
			
		}

		private void mnuXemphong_Click(object sender, System.EventArgs e)
		{
			
		}
		//////////////////////////////////////////////////////////////////////////////////
		///DataGrid xem theo Bác Sĩ
		//////////////////////////////////////////////////////////////////////////////////

		private void Load_bacsi()
		{
			try
			{	
				DataColumn[] arrdclPK = new DataColumn[1];			
				dtbBS = new DataTable();
				dclBS = new DataColumn();
				dclBS.ColumnName="Time";
				dclBS.DataType=Type.GetType("System.String");
				dclBS.MaxLength=100;
				dclBS.AllowDBNull=true;	
				dtbBS.Columns.Add(dclBS);
				arrdclPK[0]=dclBS;  
				if(seeallbs==false)
				{
					DsBS = k.get_data("select mabs,hoten from(Select distinct a.mabs, b.hoten from lh_phancong a, dmbs b where a.mabs=b.ma and a.ngaylam=to_date('"+dtpLICHHEN.Text.Substring(0,10)+"','dd/mm/yyyy')) where mabs='"+u_mabs+"'");
					if (DsBS.Tables[0].Rows.Count==0) DsBS =k.get_data("Select ma,hoten from dmbs where nhom=0");
				}
				else
				{
					DsBS =k.get_data("Select ma,hoten from dmbs where nhom=0");
				}
				
//				if(seeallbs == true)
//				{
//					DsBS = k.get_data("Select distinct a.mabs, b.hoten from lh_phancong a, dmbs b where a.mabs=b.ma and a.ngaylam=to_date('"+dtpLICHHEN.Text+"','dd/mm/yyyy')");
//					DsBS =k.get_data("Select ma,hoten from dmbs where nhom=0");
//					MessageBox.Show("heloo","ductien");
//				}
				dtbBacSi = DsBS.Tables[0];// đổ dữ liệu vào datatable				
				int sobacsi = dtbBacSi.Rows.Count;			
				for(int i=0;i<sobacsi;i++)// create datacolumn
				{
					dclBS = new DataColumn();
					dclBS.ColumnName = i.ToString()+"."+dtbBacSi.Rows[i][1].ToString();				
					dclBS.DataType=Type.GetType("System.String");
					dclBS.MaxLength=150;
					dclBS.AllowDBNull=true;
					dtbBS.Columns.Add(dclBS);
					tenbacsi[i]=dtbBacSi.Rows[i][1].ToString();					
					mabacsi[i]=dtbBacSi.Rows[i][0].ToString();
//					makhoaphong[i]=dtbBacSi.Rows[i][2].ToString();
				}		
				DataSet Dsgio=k.Loadgio();
				dtBS = Dsgio.Tables[0];
				dong = dtBS.Rows.Count;
				for(int j=0;j<dong;j++)
				{
					drwBS = dtbBS.NewRow();				
					drwBS["Time"]=dtBS.Rows[j][0].ToString();
					for(int i=0;i<sobacsi;i++)	
					{							
						string tennguoi = sosanhBS(dtBS.Rows[j][0].ToString(),dtbBacSi.Rows[i][1].ToString());
						if(tennguoi==null)
							tennguoi="";
							drwBS[i.ToString()+"."+dtbBacSi.Rows[i][1].ToString()]=tennguoi;
					}
					dtbBS.Rows.Add(drwBS);
				}	
				dtgLHBS.DataSource=dtbBS;
				Dsgio.Clear();
				AddGridStyleBS();	
			}			
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}		
		}

		private void AddGridStyleBS()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName = dtbBS.TableName;
			
			tbs.AlternatingBackColor = Color.WhiteSmoke;
			tbs.BackColor = Color.WhiteSmoke;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.DarkSlateBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.RowHeaderWidth=10;
			tbs.AllowSorting=false;
			tbs.ReadOnly=true;

			int numCols = dtbBS.Columns.Count;
			DataGridColoredTextBoxColumn aColumnTextColumn;//=new DataGridColoredTextBoxColumn(hvtemp) ;
			for(int i = 0; i < numCols; ++i)
			{
				aColumnTextColumn = new DataGridColoredTextBoxColumn();
				aColumnTextColumn.HeaderText = dtbBS.Columns[i].ColumnName;
				aColumnTextColumn.MappingName = dtbBS.Columns[i].ColumnName;
				if(i==0)
				{aColumnTextColumn.Width =40;}
				else
				{aColumnTextColumn.Width =140;}
				tbs.GridColumnStyles.Add(aColumnTextColumn);
			}
			dtgLHBS.TableStyles.Clear();
			dtgLHBS.TableStyles.Add(tbs);						
			dtgLHBS.DataSource = dtbBS;
		}

		private string sosanhBS(string gio,string tenbacsi)
		{
			int sodong = dtable.Rows.Count;
			int socot = dtable.Columns.Count;
			for(int i=0;i<sodong;i++)// duyet mang cua bang du lieu tim thay theo ngay
			{
				if(dtable.Rows[i]["GIOKHAM"].ToString()==gio && dtable.Rows[i]["HOTENBS"].ToString()==tenbacsi)
				{
					int thoigian =int.Parse(dtable.Rows[i]["THOIGIAN"].ToString());
					if(thoigian>5)
					{
						int times = thoigian/5;
						-- times;
						if(times >=1)
						{
							string gioganvao = tinhgio(dtable.Rows[i]["GIOKHAM"].ToString());
							dtable.Rows[i]["GIOKHAM"]=gioganvao;
							dtable.Rows[i]["THOIGIAN"]= thoigian-5;
						}
					}
					return dtable.Rows[i]["HOTEN"].ToString();
				}				
			}
			return null;
		}

		private void dtgLHBS_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				DataGrid.HitTestInfo hti = dtgLHBS.HitTest(new Point(e.X,e.Y));
				BindingManagerBase bmb = BindingContext[dtgLHBS.DataSource,dtgLHBS.DataMember];
				if(hti.Row < bmb.Count && hti.Type==DataGrid.HitTestType.Cell && hti.Row !=hitRow)
				{
					_rowsBS =hti.Row;
					_columnsBS = hti.Column;
					if(toolTip2 != null && toolTip2.Active)	toolTip2.Active=false;
					string tiptext = "";
					tiptext = dtgLHBS[hti.Row,0].ToString();
					if(tiptext!="")
					{
						hitRow = hti.Row;
						if(dtgLHBS[hti.Row,hti.Column].ToString()!="")
						{
							DataSet ds = new DataSet();
							DataTable dt = new DataTable();
							ds=k.get_data(dtgLHBS[hti.Row,0].ToString(),dtpLICHHEN.Text.Substring(0,10),dtgLHBS[hti.Row,hti.Column].ToString());
							dt = ds.Tables[0];
							if(dt.Rows.Count>0)
							{
								string hoten = dt.Rows[0]["HOTEN"].ToString();	
								string namsinh = dt.Rows[0]["NAMSINH"].ToString();
//								m.DateToString("dd/MM/yyyy",DateTime.Parse(datatable.Rows[0]["NGAYSINH"].ToString())
								string ngaykham = m.DateToString("dd/MM/yyyy",DateTime.Parse(dt.Rows[0]["NGAYKHAM"].ToString().Substring(0,10)));
								string giokham = dt.Rows[0]["GIOKHAM"].ToString();
								string stt = dt.Rows[0]["STT"].ToString();
								string phongkham = dt.Rows[0]["TENKP"].ToString();
								status = dt.Rows[0]["STATUS"].ToString();
								string status_;
								if(status=="1")
								{	status_="Đã đến";}
								else
								{
									if(status=="0")
									{status_="Chưa đến";}
									else
										status_="Bỏ hẹn";
								}								
								string a = "Họ tên              "+hoten+"\nNăm sinh          "+namsinh+"\nNgày khám       "+ngaykham+"\nGiờ khám          "+ giokham+"\nSố thứ tự         "+stt+"\nTình trạng hẹn "+ status_+"\nPhòng               "+phongkham+"";
								toolTip2.SetToolTip(dtgLHBS,a);
							}
							else
							{
								toolTip2.SetToolTip(dtgLHBS,dtgLHBS[hti.Row,hti.Column].ToString());
							}						
						}
						else
						{
							toolTip2.SetToolTip(dtgLHBS,dtgLHBS[hti.Row,0].ToString());
						}
						toolTip2.Active=true;
					}	
					else
						hitRow = -1;
				}
				else
				{}
				label4.Text="R_BS:"+_rowsBS.ToString()+","+_columnsBS.ToString();
			}
			catch(Exception caught)
			{
				MessageBox.Show(caught.Message);
			}		
		}

		private void dtgLHBS_CursorChanged(object sender, System.EventArgs e)
		{
			label3.Text="PointX: "+Cursor.Position.X.ToString()+",PointY: "+Cursor.Position.Y.ToString();
			pointXBS=int.Parse(Cursor.Position.X.ToString());
			pointYBS=int.Parse(Cursor.Position.Y.ToString());
		}

		private void ctm_Inphieuhen_Click(object sender, System.EventArgs e)
		{
			if(dr==true)
			{
				if(pointXBS >60 && pointYBS > 120 && dtgLHBS[_rowsBS,_columnsBS].ToString() != "")
				{
					DataSet dts = new DataSet();
					DataTable dtt = new DataTable();
					dts=k.get_data(dtgLHBS[_rowsBS,0].ToString(),dtpLICHHEN.Text.Substring(0,10),dtgLHBS[_rowsBS,_columnsBS].ToString());
					dtt = dts.Tables[0];
					if(dtt.Rows.Count>0)
					{
						string id = dtt.Rows[0]["MAQL"].ToString();					
						string sql="Select a.mabn,a.hoten,a.namsinh,a.sonha||' '||a.thon tenduong,b.tenpxa||' - '||c.tenquan||' - '||d.tentt diachi,e.giokham,e.stt,f.hoten as bacsi,e.ngaykham,e.ghichu,g.tenkp from lh_benhnhan a,btdpxa b, btdquan c,btdtt d,lh_khambenh e,dmbs f,btdkp_bv g where a.maql=e.maql and a.maphuongxa=b.maphuongxa and a.maqu=c.maqu and a.matt=d.matt and e.phongkham=g.makp and e.mabs=f.ma and a.maql="+id+" and e.maql="+id+"";
						DataSet ds = k.get_data(sql);						
						frmReport f=new frmReport(m,ds,"","lh_phieuhen.rpt");
						f.ShowDialog();
						SetcellFocus(dtgLICHHEN);
					}	
				}
			}
			else
			{
				if(pointX >60 && pointY > 120 && dtgLICHHEN[_rows,_columns].ToString() != "")
				{
					DataSet dts = new DataSet();
					DataTable dtt = new DataTable();
					dts=k.get_data(dtgLICHHEN[_rows,0].ToString(),dtpLICHHEN.Text.Substring(0,10).ToString(),dtgLICHHEN[_rows,_columns].ToString());
					dtt = dts.Tables[0];					
					if(dtt.Rows.Count>0)
					{
						string id = dtt.Rows[0]["MAQL"].ToString();					
						string sql="Select a.mabn,a.hoten,a.namsinh,a.sonha||' '||a.thon tenduong,b.tenpxa||' - '||c.tenquan||' - '||d.tentt diachi,e.giokham,e.stt,f.hoten as bacsi,e.ngaykham,e.ghichu,g.tenkp from lh_benhnhan a,btdpxa b, btdquan c,btdtt d,lh_khambenh e,dmbs f,btdkp_bv g where a.maql=e.maql and a.maphuongxa=b.maphuongxa and a.maqu=c.maqu and a.matt=d.matt and e.phongkham=g.makp and e.mabs=f.ma and a.maql="+id+" and e.maql="+id+"";
						DataSet ds = k.get_data(sql);
						frmReport f=new frmReport(m,ds,"","lh_phieuhen.rpt");
						f.ShowDialog();
						SetcellFocus(dtgLICHHEN);
					}	
				}
			}
		}

		private string Timmakp(string ngay,string mabacsi,string giohenkham)
		{
			DataSet ds = k.get_data("Select * from lh_phancong where ngaylam=to_date('"+ngay+"','dd/mm/yyyy') and mabs='"+mabacsi+"'");
			DataTable dt = ds.Tables[0];
			int i = dt.Rows.Count;
			if(i==1)
			{
				return dt.Rows[0]["MAKP"].ToString();
			}
			else
			{
				if(i>1)
				{
					for(int j=0;j<i;j++)
					{
						int first= int.Parse(dt.Rows[j]["TUGIO"].ToString().Substring(0,2));
						int last = int.Parse(dt.Rows[j]["DENGIO"].ToString().Substring(0,2));
						int gio = int.Parse(giohenkham.Substring(0,2));
						for(int jj=first;jj<=last;jj++)
						{
							if(jj==gio)
							{
								return dt.Rows[j]["MAKP"].ToString();
							}
						}
					}
				}
			}
			return null;
		}

		private void label5_Click(object sender, System.EventArgs e)
		{
			if(label1.Visible==true)
			{
				label1.Visible=false;
				label2.Visible=false;
				label3.Visible=false;
				label4.Visible=false;
			}
			else
			{
				label1.Visible=true;
				label2.Visible=true;
				label3.Visible=true;
				label4.Visible=true;
			}
		}

		private bool kiemtragiolamviec(string giodinhhen,string bacsi, string ngay, string phong)
		{
			try
			{
				string mabacsi=bacsi.ToString();
				string maphongdinhlam=phong.ToString();
				string sql = "Select * from lh_phancong where ngaylam=to_date('"+ngay+"','dd/mm/yyyy') and mabs='"+mabacsi+"' and makp= '"+maphongdinhlam+"' ";			
				DataSet dsphancong = k.get_data(sql);
				int giobatdau = int.Parse(dsphancong.Tables[0].Rows[0]["TUGIO"].ToString().Substring(0,2));
				int gioketthuc = int.Parse(dsphancong.Tables[0].Rows[0]["DENGIO"].ToString().Substring(0,2));
				int gio = int.Parse(giodinhhen.Substring(0,2)); 
				if(gio >= giobatdau && gio <= gioketthuc)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return true;
			}
		}	

		private void ctm2_inlichhen_Click(object sender, System.EventArgs e)
		{
			frmlhthongso frm = new frmlhthongso();
			frm.ShowDialog();
		}

		private void ctm2_xembs_Click(object sender, System.EventArgs e)
		{
			dr=true;			
			dtgLICHHEN.Visible=false;
			dtgLHBS.Visible=true;
			ctm2_xembs.Checked=true;
			ctm2_xemphong.Checked=false;
			LoadPhong(cmbnhomphong.SelectedValue.ToString());
		}

		private void ctm2_xemphong_Click(object sender, System.EventArgs e)
		{
			dr=false;			
			dtgLICHHEN.Visible=true;
			dtgLHBS.Visible=false;
			ctm2_xembs.Checked=false;
			ctm2_xemphong.Checked=true;
		}

		private void ctm2_phancong_Click(object sender, System.EventArgs e)
		{
			PHANCONG frmphancong = new PHANCONG();
			frmphancong.Show();
		}

		private void ctm2_thoigian_Click(object sender, System.EventArgs e)
		{
			THOIGIAN frmthoigian = new THOIGIAN();
			frmthoigian.Show();
		}

		private void ctm2_phong_Click(object sender, System.EventArgs e)
		{
			DIADIEMKHAM frmdiadiemkham = new DIADIEMKHAM();
			frmdiadiemkham.Show();
		}

		private void ctm2_loaihen_Click(object sender, System.EventArgs e)
		{
			
			LOAIKHAM frmloaikham = new LOAIKHAM();
			frmloaikham.Show();
		}

		private void ctm2_tinhtrang_Click(object sender, System.EventArgs e)
		{
			TINHTRANGKHAM frmtinhtrangkham = new TINHTRANGKHAM();
			frmtinhtrangkham.Show();
		}

		private void ctm2_nhomphong_Click(object sender, System.EventArgs e)
		{
			NHOMPHONG frm = new NHOMPHONG();
			frm.ShowDialog();
		}

		private void LICHHEN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				dr=true;				
				dtgLICHHEN.Visible=false;
				dtgLHBS.Visible=true;
				ctm2_xembs.Checked=true;
				ctm2_xemphong.Checked=false;
				LoadPhong(cmbnhomphong.SelectedValue.ToString());
			}
			else
			{
				if(e.KeyCode==Keys.F3)
				{
					dr=false;					
					dtgLICHHEN.Visible=true;
					dtgLHBS.Visible=false;
					ctm2_xembs.Checked=false;
					ctm2_xemphong.Checked=true;
				}
			}
		}

		private void xulydoiso()
		{
			if(u_idnhapkhoa > 0) mabn_idnhapkhoa();
			else if(u_loaiba==3)mabn_tiepdon();                    				
			else mabn_benhandt();						
		}
	
		private void mabn_idnhapkhoa()
		{
			try
			{
				string sql="select mabn,makp,maql,maba from nhapkhoa where id="+u_idnhapkhoa+"";
				DataTable tb = new DataTable();
				tb = k.get_data(sql).Tables[0];
				u_mabn = tb.Rows[0]["MABN"].ToString();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"mabn_idnhapkhoa");
			}
		}

		private void mabn_tiepdon()
		{
			try
			{
				string sql = "select mabn from tiepdon where maql="+u_maql+"";
				DataTable tb = new DataTable();
				tb = k.get_data(sql).Tables[0];				
				u_mabn = tb.Rows[0]["MABN"].ToString();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"mabn_tiepdon");
			}
		}

		private void mabn_benhandt()
		{
			try
			{
				string sql = "select mabn,makp,mabs from benhandt where maql="+u_maql+"";
				DataTable tb = new DataTable();
				tb = k.get_data(sql).Tables[0];
				if (tb.Rows.Count>0) u_mabn = tb.Rows[0]["MABN"].ToString();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"mabn_benhandt");
			}
		}

		private void ctm_tatca_Click(object sender, System.EventArgs e)
		{
			if(dr==false)
			{
				seeallkp = true;
				LoadPhong(cmbnhomphong.SelectedValue.ToString());
				seeallkp =false;
			}
			else
			{
				seeallbs = true;
				Load_bacsi();
				seeallbs = false;
			}
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void dtgLHBS_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			PX_BS=int.Parse(Cursor.Position.X.ToString());			
			PY_BS=int.Parse(Cursor.Position.Y.ToString());
		}

		private void dtgLICHHEN_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			PX_KP=int.Parse(Cursor.Position.X.ToString());			
			PY_KP=int.Parse(Cursor.Position.Y.ToString());
			//label7.Text="PX_KP: "+PX_KP.ToString()+"PY_KP: "+PY_KP.ToString();
			
		}
	}
}
