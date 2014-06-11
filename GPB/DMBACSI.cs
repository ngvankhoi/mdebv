using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using Lib_gpbl;

namespace XN
{	
	public class DMBACSI : System.Windows.Forms.Form
	{		
		DataSet Ds = new DataSet();

        private gpblib.AccessData k = new gpblib.AccessData();
		frmMain m = new frmMain();

		private System.Windows.Forms.CheckBox checkBoxTruongkhoa;
		private System.Windows.Forms.CheckBox checkBoxConlam;
		private System.Windows.Forms.Button buttonThem;
		private System.Windows.Forms.Button buttonSua;
		private System.Windows.Forms.Button buttonLuu;
		private System.Windows.Forms.Button buttonBoqua;
		private System.Windows.Forms.Button buttonHuy;
		private System.Windows.Forms.Button buttonKetthuc;
		private System.Windows.Forms.DataGrid dtgDANHMUCBACSI;
		private System.Windows.Forms.Label lbMaBS;
		private System.Windows.Forms.TextBox txtMaBS;
		private System.Windows.Forms.Label lbTenBS;
		private System.Windows.Forms.TextBox txtTenBS;
		private System.Windows.Forms.Button buttonLuuUpdate;
		

		private System.ComponentModel.Container components = null;

		public DMBACSI()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DMBACSI));
			this.dtgDANHMUCBACSI = new System.Windows.Forms.DataGrid();
			this.lbMaBS = new System.Windows.Forms.Label();
			this.txtMaBS = new System.Windows.Forms.TextBox();
			this.lbTenBS = new System.Windows.Forms.Label();
			this.txtTenBS = new System.Windows.Forms.TextBox();
			this.checkBoxTruongkhoa = new System.Windows.Forms.CheckBox();
			this.checkBoxConlam = new System.Windows.Forms.CheckBox();
			this.buttonThem = new System.Windows.Forms.Button();
			this.buttonSua = new System.Windows.Forms.Button();
			this.buttonLuu = new System.Windows.Forms.Button();
			this.buttonBoqua = new System.Windows.Forms.Button();
			this.buttonHuy = new System.Windows.Forms.Button();
			this.buttonKetthuc = new System.Windows.Forms.Button();
			this.buttonLuuUpdate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtgDANHMUCBACSI)).BeginInit();
			this.SuspendLayout();
			// 
			// dtgDANHMUCBACSI
			// 
			this.dtgDANHMUCBACSI.DataMember = "";
			this.dtgDANHMUCBACSI.GridLineColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.dtgDANHMUCBACSI.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgDANHMUCBACSI.Location = new System.Drawing.Point(8, 8);
			this.dtgDANHMUCBACSI.Name = "dtgDANHMUCBACSI";
			this.dtgDANHMUCBACSI.PreferredColumnWidth = 200;
			this.dtgDANHMUCBACSI.ReadOnly = true;
			this.dtgDANHMUCBACSI.Size = new System.Drawing.Size(504, 312);
			this.dtgDANHMUCBACSI.TabIndex = 30;
			this.dtgDANHMUCBACSI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgDANHMUCBACSI_KeyDown);
			this.dtgDANHMUCBACSI.DoubleClick += new System.EventHandler(this.dtgDANHMUCBACSI_DoubleClick);
			this.dtgDANHMUCBACSI.CurrentCellChanged += new System.EventHandler(this.dtgDANHMUCBACSI_CurrentCellChanged);
			// 
			// lbMaBS
			// 
			this.lbMaBS.Location = new System.Drawing.Point(8, 340);
			this.lbMaBS.Name = "lbMaBS";
			this.lbMaBS.Size = new System.Drawing.Size(48, 16);
			this.lbMaBS.TabIndex = 1;
			this.lbMaBS.Text = "Mã BS :";
			// 
			// txtMaBS
			// 
			this.txtMaBS.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtMaBS.Enabled = false;
			this.txtMaBS.Location = new System.Drawing.Point(52, 336);
			this.txtMaBS.Name = "txtMaBS";
			this.txtMaBS.Size = new System.Drawing.Size(48, 20);
			this.txtMaBS.TabIndex = 1;
			this.txtMaBS.Text = "";
			this.txtMaBS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaBS_KeyDown);
			// 
			// lbTenBS
			// 
			this.lbTenBS.Location = new System.Drawing.Point(112, 340);
			this.lbTenBS.Name = "lbTenBS";
			this.lbTenBS.Size = new System.Drawing.Size(56, 16);
			this.lbTenBS.TabIndex = 3;
			this.lbTenBS.Text = "Tên  BS :";
			// 
			// txtTenBS
			// 
			this.txtTenBS.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtTenBS.Enabled = false;
			this.txtTenBS.Location = new System.Drawing.Point(164, 336);
			this.txtTenBS.Name = "txtTenBS";
			this.txtTenBS.Size = new System.Drawing.Size(160, 20);
			this.txtTenBS.TabIndex = 2;
			this.txtTenBS.Text = "";
			this.txtTenBS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenBS_KeyDown);
			// 
			// checkBoxTruongkhoa
			// 
			this.checkBoxTruongkhoa.Enabled = false;
			this.checkBoxTruongkhoa.Location = new System.Drawing.Point(344, 336);
			this.checkBoxTruongkhoa.Name = "checkBoxTruongkhoa";
			this.checkBoxTruongkhoa.TabIndex = 3;
			this.checkBoxTruongkhoa.Text = "Trưởng Khoa";
			this.checkBoxTruongkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxTruongkhoa_KeyDown);
			// 
			// checkBoxConlam
			// 
			this.checkBoxConlam.Enabled = false;
			this.checkBoxConlam.Location = new System.Drawing.Point(440, 336);
			this.checkBoxConlam.Name = "checkBoxConlam";
			this.checkBoxConlam.Size = new System.Drawing.Size(72, 24);
			this.checkBoxConlam.TabIndex = 4;
			this.checkBoxConlam.Text = "Còn Làm";
			this.checkBoxConlam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxConlam_KeyDown);
			// 
			// buttonThem
			// 
			this.buttonThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonThem.Image")));
			this.buttonThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonThem.Location = new System.Drawing.Point(71, 368);
			this.buttonThem.Name = "buttonThem";
			this.buttonThem.Size = new System.Drawing.Size(60, 25);
			this.buttonThem.TabIndex = 0;
			this.buttonThem.Text = "Thêm ";
			this.buttonThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
			// 
			// buttonSua
			// 
			this.buttonSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonSua.Image")));
			this.buttonSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSua.Location = new System.Drawing.Point(133, 368);
			this.buttonSua.Name = "buttonSua";
			this.buttonSua.Size = new System.Drawing.Size(60, 25);
			this.buttonSua.TabIndex = 8;
			this.buttonSua.Text = "    Sửa";
			this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
			// 
			// buttonLuu
			// 
			this.buttonLuu.Enabled = false;
			this.buttonLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonLuu.Image")));
			this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonLuu.Location = new System.Drawing.Point(195, 368);
			this.buttonLuu.Name = "buttonLuu";
			this.buttonLuu.Size = new System.Drawing.Size(60, 25);
			this.buttonLuu.TabIndex = 5;
			this.buttonLuu.Text = "     Lưu";
			this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
			// 
			// buttonBoqua
			// 
			this.buttonBoqua.Enabled = false;
			this.buttonBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonBoqua.Image")));
			this.buttonBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonBoqua.Location = new System.Drawing.Point(257, 368);
			this.buttonBoqua.Name = "buttonBoqua";
			this.buttonBoqua.Size = new System.Drawing.Size(60, 25);
			this.buttonBoqua.TabIndex = 10;
			this.buttonBoqua.Text = "Bỏ qua";
			this.buttonBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonBoqua.Click += new System.EventHandler(this.buttonBoqua_Click);
			// 
			// buttonHuy
			// 
			this.buttonHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonHuy.Image")));
			this.buttonHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonHuy.Location = new System.Drawing.Point(319, 368);
			this.buttonHuy.Name = "buttonHuy";
			this.buttonHuy.Size = new System.Drawing.Size(60, 25);
			this.buttonHuy.TabIndex = 11;
			this.buttonHuy.Text = "     Hủy";
			this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
			// 
			// buttonKetthuc
			// 
			this.buttonKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonKetthuc.Image")));
			this.buttonKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonKetthuc.Location = new System.Drawing.Point(381, 368);
			this.buttonKetthuc.Name = "buttonKetthuc";
			this.buttonKetthuc.Size = new System.Drawing.Size(68, 25);
			this.buttonKetthuc.TabIndex = 12;
			this.buttonKetthuc.Text = "Kết thúc";
			this.buttonKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonKetthuc.Click += new System.EventHandler(this.buttonKetthuc_Click);
			// 
			// buttonLuuUpdate
			// 
			this.buttonLuuUpdate.Enabled = false;
			this.buttonLuuUpdate.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonLuuUpdate.Image")));
			this.buttonLuuUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonLuuUpdate.Location = new System.Drawing.Point(472, 384);
			this.buttonLuuUpdate.Name = "buttonLuuUpdate";
			this.buttonLuuUpdate.Size = new System.Drawing.Size(58, 32);
			this.buttonLuuUpdate.TabIndex = 5;
			this.buttonLuuUpdate.Text = "Luu";
			this.buttonLuuUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonLuuUpdate.Click += new System.EventHandler(this.buttonLuuUpdate_Click);
			// 
			// DMBACSI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 413);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.buttonKetthuc,
																		  this.buttonHuy,
																		  this.buttonBoqua,
																		  this.buttonLuu,
																		  this.buttonSua,
																		  this.buttonThem,
																		  this.checkBoxConlam,
																		  this.checkBoxTruongkhoa,
																		  this.txtTenBS,
																		  this.lbTenBS,
																		  this.txtMaBS,
																		  this.lbMaBS,
																		  this.dtgDANHMUCBACSI,
																		  this.buttonLuuUpdate});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DMBACSI";
			this.Text = "DANH MỤC BÁC SĨ";
			this.Load += new System.EventHandler(this.DMBACSI_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgDANHMUCBACSI)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonKetthuc_Click(object sender, System.EventArgs e)
		{		
			m.Enable_buttonBacsi(true);
			this.Close();			
		}

		private void DMBACSI_Load(object sender, System.EventArgs e)
		{
			ShowDataGrid();
			LoadGridStyle();
			First_Text();			
		}

		private void ShowDataGrid()
		{
			string sql_select = "Select * From BACSI ";
			Ds = k.get_data(sql_select);
			if(Ds!=null)				
			dtgDANHMUCBACSI.DataSource = Ds.Tables[0];
		}

		private void LoadGridStyle()
		{
			DataGridTableStyle tbs=new DataGridTableStyle();

			tbs.MappingName=Ds.Tables[0].TableName;
			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.MidnightBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.ReadOnly=true;

			DataGridTextBoxColumn c0=new DataGridTextBoxColumn();
			c0.MappingName="MaBS";
			c0.HeaderText="Mã Bác Sĩ";
			c0.Width=80;
			tbs.GridColumnStyles.Add(c0);

			dtgDANHMUCBACSI.TableStyles.Add(tbs);
			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="TenBS";
			c1.HeaderText="Tên Bác Sĩ";
			c1.Width=160;
			tbs.GridColumnStyles.Add(c1);

			dtgDANHMUCBACSI.TableStyles.Add(tbs);
			DataGridBoolColumn c2 = new DataGridBoolColumn();
			c2.MappingName="TruongKhoa";
			c2.HeaderText="Trưởng Khoa";
			c2.Width=120;
			c2.ReadOnly=true;
			tbs.GridColumnStyles.Add(c2);

			dtgDANHMUCBACSI.TableStyles.Add(tbs);
			DataGridBoolColumn c3 = new DataGridBoolColumn();
			c3.MappingName="ConLam";
			c3.HeaderText="Còn Làm";
			c3.Width=120;
			c3.ReadOnly=true;
			tbs.GridColumnStyles.Add(c3);

			dtgDANHMUCBACSI.TableStyles.Add(tbs);
			
		}	

		private void GridToText(int d)
		{
			txtMaBS.Text=dtgDANHMUCBACSI[d,0].ToString();
			txtTenBS.Text=dtgDANHMUCBACSI[d,1].ToString();
			
			bool check = true;
			
			if(dtgDANHMUCBACSI[d,2].Equals(check))
			{
				checkBoxTruongkhoa.Checked = true; 
			}
			else
			{
				checkBoxTruongkhoa.Checked = false; 
			}
			if(dtgDANHMUCBACSI[d,3].Equals(check))
			{
				checkBoxConlam.Checked = true; 
			}
			else
			{
				checkBoxConlam.Checked = false;
			}
			  
		}

		private void dtgDANHMUCBACSI_CurrentCellChanged(object sender, System.EventArgs e)
		{
			GridToText(dtgDANHMUCBACSI.CurrentCell.RowNumber);
		}

		private void Text_First()
		{
			txtMaBS.Text=dtgDANHMUCBACSI[0,0].ToString();
			txtTenBS.Text=dtgDANHMUCBACSI[0,1].ToString();		
		}

		private void buttonThem_Click(object sender, System.EventArgs e)
		{
			Enable_Text(true);
			txtMaBS.Clear();
			txtTenBS.Clear();
			txtTenBS.Focus();
			checkBoxConlam.Checked=false;
			checkBoxTruongkhoa.Checked=false;
			buttonLuu.Visible = true;
			buttonLuu.Enabled = true;
			buttonLuuUpdate.Visible=false;
		}

		private void Enable_Text(bool ena)
		{
			buttonBoqua.Enabled= ena;
			buttonHuy.Enabled =!ena;
			buttonKetthuc.Enabled=!ena;
			buttonLuu.Enabled=ena;
			buttonSua.Enabled = !ena;
			buttonThem.Enabled= !ena;
			buttonLuuUpdate.Visible=false; 
			txtTenBS.Enabled= ena;		
			checkBoxConlam.Enabled=ena;
			checkBoxTruongkhoa.Enabled=ena;
		}

		private void buttonLuu_Click(object sender, System.EventArgs e)
		{			
			if(txtTenBS.TextLength==0)
			{
				MessageBox.Show("Chưa nhập tên Bác Sĩ","Thông Báo");
				txtTenBS.Focus();
				return;
			}
			k.execute_data("Insert into BACSI(TenBS,TruongKhoa,ConLam) Values('"+txtTenBS.Text.ToString()+"',"+checkBoxTruongkhoa.Checked+","+checkBoxConlam.Checked +")"); 
			ShowDataGrid();
			Enable_Text(false);
			buttonThem.Focus();
		}

		private void buttonHuy_Click(object sender, System.EventArgs e)
		{
			if(dtgDANHMUCBACSI.VisibleRowCount !=0)
			{
				if(MessageBox.Show("Bạn muốn xóa mẫu tin này ?","Chú ý",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
				{
					k.execute_data("Delete * From BACSI Where MaBS = "+txtMaBS.Text+"") ;
                    ShowDataGrid();						
				}
			}
		}

		private void buttonSua_Click(object sender, System.EventArgs e)
		{
			Enable_Sua(true);			
		}

		private void Enable_Sua(bool ena)
		{
			buttonBoqua.Enabled=ena;
			buttonHuy.Enabled=!ena;
			buttonKetthuc.Enabled=!ena;
			buttonLuu.Visible = !ena;
			buttonHuy.Enabled = !ena;
			buttonLuuUpdate.Visible=true;
			buttonLuuUpdate.Enabled=true;
			buttonSua.Enabled= !ena;
			buttonThem.Enabled=!ena;

			txtMaBS.Enabled= false;
			txtTenBS.Enabled=ena;
			checkBoxConlam.Enabled=ena;
			checkBoxTruongkhoa.Enabled=ena;
		}

		private void buttonLuuUpdate_Click(object sender, System.EventArgs e)
		{
			if(txtTenBS.TextLength==0)
			{
				MessageBox.Show("Chưa nhập tên Bác Sĩ","Thông Báo");
				txtTenBS.Focus();
				return;
			}
			k.execute_data("Update BACSI set TenBS = '"+txtTenBS.Text.ToString()+"',TruongKhoa = "+checkBoxTruongkhoa.Checked+",ConLam = "+checkBoxConlam.Checked+" Where MaBS = "+txtMaBS.Text+"") ;
			ShowDataGrid();
			Enable_Sua(false);
			buttonLuuUpdate.Visible=false;
			First_Text();
		}

		private void dtgDANHMUCBACSI_DoubleClick(object sender, System.EventArgs e)
		{			
			Enable_Sua(true);
		}

		private void buttonBoqua_Click(object sender, System.EventArgs e)
		{
			Enable_Text(false);
			Enable_Sua(false);
			buttonLuu.Visible=true;
			buttonLuu.Enabled=false;
			buttonLuuUpdate.Visible=false;
			ShowDataGrid();
			Text_First();
		}

		private void First_Text()
		{
			txtMaBS.Text=dtgDANHMUCBACSI[0,0].ToString();
			txtTenBS.Text=dtgDANHMUCBACSI[0,1].ToString();
			if(dtgDANHMUCBACSI[0,2].Equals(true)) checkBoxTruongkhoa.Checked=true;
			if(dtgDANHMUCBACSI[0,3].Equals(true)) checkBoxConlam.Checked=true;
		}

		private void txtMaBS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter ) SendKeys.Send("{Tab}");
		}

		private void txtTenBS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter ) SendKeys.Send("{Tab}");
		}

		private void checkBoxTruongkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter ) SendKeys.Send("{Tab}");
		}

		private void checkBoxConlam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter ) SendKeys.Send("{Tab}");
		}

		private void dtgDANHMUCBACSI_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete )
			{
				if(dtgDANHMUCBACSI.VisibleRowCount !=0)
				{
					if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?","Chú ý",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
					{
						k.execute_data("Delete * From BACSI Where MaBS = "+txtMaBS.Text+"") ;
						ShowDataGrid();						
					}
				}				
			}
		}
	}
}
