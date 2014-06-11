using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
//using Lib_gpbl;

namespace XN
{	
	public class DMKHOAPHONG : System.Windows.Forms.Form
	{
		DataSet Ds = new DataSet();
		OleDbCommand cm = new OleDbCommand();
		//Lib_gpbl.Khaibao k = new Lib_gpbl.Khaibao();
        private gpblib.AccessData k = new gpblib.AccessData();
		frmMain m = new frmMain();
		DataTable tb = new DataTable();
		

		private System.Windows.Forms.Button buttonKetthuc;
		private System.Windows.Forms.Button buttonHuy;
		private System.Windows.Forms.Button buttonBoqua;
		private System.Windows.Forms.Button buttonLuu;
		private System.Windows.Forms.Button buttonSua;
		private System.Windows.Forms.Button buttonThem;
		private System.Windows.Forms.DataGrid dtgDMKHOAPHONG;
		private System.Windows.Forms.Label LBMa;
		private System.Windows.Forms.TextBox txtMa;
		private System.Windows.Forms.TextBox txtTenkhoaphong;
		private System.Windows.Forms.Label lbTenkhoaphong;
		private System.Windows.Forms.Button buttonLuuUpdate;
		private System.Windows.Forms.ComboBox cmbLoai;
		private System.Windows.Forms.Label lbLoai;
		private System.Windows.Forms.Button buttonLoaiDV;
		private System.Windows.Forms.TextBox txtLoai;
		
		private System.ComponentModel.Container components = null;

		public DMKHOAPHONG()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DMKHOAPHONG));
			this.dtgDMKHOAPHONG = new System.Windows.Forms.DataGrid();
			this.buttonKetthuc = new System.Windows.Forms.Button();
			this.buttonHuy = new System.Windows.Forms.Button();
			this.buttonBoqua = new System.Windows.Forms.Button();
			this.buttonLuu = new System.Windows.Forms.Button();
			this.buttonSua = new System.Windows.Forms.Button();
			this.buttonThem = new System.Windows.Forms.Button();
			this.LBMa = new System.Windows.Forms.Label();
			this.txtMa = new System.Windows.Forms.TextBox();
			this.txtTenkhoaphong = new System.Windows.Forms.TextBox();
			this.lbTenkhoaphong = new System.Windows.Forms.Label();
			this.buttonLuuUpdate = new System.Windows.Forms.Button();
			this.cmbLoai = new System.Windows.Forms.ComboBox();
			this.lbLoai = new System.Windows.Forms.Label();
			this.buttonLoaiDV = new System.Windows.Forms.Button();
			this.txtLoai = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dtgDMKHOAPHONG)).BeginInit();
			this.SuspendLayout();
			// 
			// dtgDMKHOAPHONG
			// 
			this.dtgDMKHOAPHONG.DataMember = "";
			this.dtgDMKHOAPHONG.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgDMKHOAPHONG.Location = new System.Drawing.Point(8, 8);
			this.dtgDMKHOAPHONG.Name = "dtgDMKHOAPHONG";
			this.dtgDMKHOAPHONG.ReadOnly = true;
			this.dtgDMKHOAPHONG.Size = new System.Drawing.Size(528, 304);
			this.dtgDMKHOAPHONG.TabIndex = 30;
			this.dtgDMKHOAPHONG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgDMKHOAPHONG_KeyDown);
			this.dtgDMKHOAPHONG.DoubleClick += new System.EventHandler(this.dtgDMKHOAPHONG_DoubleClick);
			this.dtgDMKHOAPHONG.CurrentCellChanged += new System.EventHandler(this.dtgDMKHOAPHONG_CurrentCellChanged);
			// 
			// buttonKetthuc
			// 
			this.buttonKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonKetthuc.Image")));
			this.buttonKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonKetthuc.Location = new System.Drawing.Point(393, 360);
			this.buttonKetthuc.Name = "buttonKetthuc";
			this.buttonKetthuc.Size = new System.Drawing.Size(68, 25);
			this.buttonKetthuc.TabIndex = 18;
			this.buttonKetthuc.Text = "Kết thúc";
			this.buttonKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonKetthuc.Click += new System.EventHandler(this.buttonKetthuc_Click);
			// 
			// buttonHuy
			// 
			this.buttonHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonHuy.Image")));
			this.buttonHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonHuy.Location = new System.Drawing.Point(331, 360);
			this.buttonHuy.Name = "buttonHuy";
			this.buttonHuy.Size = new System.Drawing.Size(60, 25);
			this.buttonHuy.TabIndex = 17;
			this.buttonHuy.Text = "    Hủy";
			this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
			// 
			// buttonBoqua
			// 
			this.buttonBoqua.Enabled = false;
			this.buttonBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonBoqua.Image")));
			this.buttonBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonBoqua.Location = new System.Drawing.Point(269, 360);
			this.buttonBoqua.Name = "buttonBoqua";
			this.buttonBoqua.Size = new System.Drawing.Size(60, 25);
			this.buttonBoqua.TabIndex = 20;
			this.buttonBoqua.Text = "Bỏ qua";
			this.buttonBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonBoqua.Click += new System.EventHandler(this.buttonBoqua_Click);
			// 
			// buttonLuu
			// 
			this.buttonLuu.Enabled = false;
			this.buttonLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonLuu.Image")));
			this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonLuu.Location = new System.Drawing.Point(207, 360);
			this.buttonLuu.Name = "buttonLuu";
			this.buttonLuu.Size = new System.Drawing.Size(60, 25);
			this.buttonLuu.TabIndex = 4;
			this.buttonLuu.Text = "    Lưu";
			this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
			// 
			// buttonSua
			// 
			this.buttonSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonSua.Image")));
			this.buttonSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSua.Location = new System.Drawing.Point(145, 360);
			this.buttonSua.Name = "buttonSua";
			this.buttonSua.Size = new System.Drawing.Size(60, 25);
			this.buttonSua.TabIndex = 14;
			this.buttonSua.Text = "   Sửa";
			this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
			// 
			// buttonThem
			// 
			this.buttonThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonThem.Image")));
			this.buttonThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonThem.Location = new System.Drawing.Point(83, 360);
			this.buttonThem.Name = "buttonThem";
			this.buttonThem.Size = new System.Drawing.Size(60, 25);
			this.buttonThem.TabIndex = 0;
			this.buttonThem.Text = "Thêm ";
			this.buttonThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
			// 
			// LBMa
			// 
			this.LBMa.Location = new System.Drawing.Point(16, 332);
			this.LBMa.Name = "LBMa";
			this.LBMa.Size = new System.Drawing.Size(32, 16);
			this.LBMa.TabIndex = 19;
			this.LBMa.Text = "Mã :";
			// 
			// txtMa
			// 
			this.txtMa.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtMa.Enabled = false;
			this.txtMa.Location = new System.Drawing.Point(40, 328);
			this.txtMa.Name = "txtMa";
			this.txtMa.Size = new System.Drawing.Size(32, 20);
			this.txtMa.TabIndex = 1;
			this.txtMa.Text = "";
			this.txtMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMa_KeyDown);
			// 
			// txtTenkhoaphong
			// 
			this.txtTenkhoaphong.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtTenkhoaphong.Enabled = false;
			this.txtTenkhoaphong.Location = new System.Drawing.Point(178, 328);
			this.txtTenkhoaphong.Name = "txtTenkhoaphong";
			this.txtTenkhoaphong.Size = new System.Drawing.Size(136, 20);
			this.txtTenkhoaphong.TabIndex = 2;
			this.txtTenkhoaphong.Text = "";
			this.txtTenkhoaphong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenkhoaphong_KeyDown);
			// 
			// lbTenkhoaphong
			// 
			this.lbTenkhoaphong.Location = new System.Drawing.Point(80, 332);
			this.lbTenkhoaphong.Name = "lbTenkhoaphong";
			this.lbTenkhoaphong.Size = new System.Drawing.Size(98, 16);
			this.lbTenkhoaphong.TabIndex = 22;
			this.lbTenkhoaphong.Text = "Tên Khoa, Phòng :";
			// 
			// buttonLuuUpdate
			// 
			this.buttonLuuUpdate.Enabled = false;
			this.buttonLuuUpdate.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonLuuUpdate.Image")));
			this.buttonLuuUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonLuuUpdate.Location = new System.Drawing.Point(-24, 376);
			this.buttonLuuUpdate.Name = "buttonLuuUpdate";
			this.buttonLuuUpdate.Size = new System.Drawing.Size(60, 25);
			this.buttonLuuUpdate.TabIndex = 4;
			this.buttonLuuUpdate.Text = "Luu";
			this.buttonLuuUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonLuuUpdate.Click += new System.EventHandler(this.buttonLuuUpdate_Click);
			// 
			// cmbLoai
			// 
			this.cmbLoai.BackColor = System.Drawing.Color.White;
			this.cmbLoai.Enabled = false;
			this.cmbLoai.Location = new System.Drawing.Point(360, 328);
			this.cmbLoai.Name = "cmbLoai";
			this.cmbLoai.Size = new System.Drawing.Size(88, 21);
			this.cmbLoai.TabIndex = 3;
			this.cmbLoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoai_KeyDown);
			this.cmbLoai.SelectedIndexChanged += new System.EventHandler(this.cmbLoai_SelectedIndexChanged);
			// 
			// lbLoai
			// 
			this.lbLoai.Location = new System.Drawing.Point(328, 332);
			this.lbLoai.Name = "lbLoai";
			this.lbLoai.Size = new System.Drawing.Size(32, 16);
			this.lbLoai.TabIndex = 24;
			this.lbLoai.Text = "Loại :";
			// 
			// buttonLoaiDV
			// 
			this.buttonLoaiDV.Enabled = false;
			this.buttonLoaiDV.Location = new System.Drawing.Point(481, 328);
			this.buttonLoaiDV.Name = "buttonLoaiDV";
			this.buttonLoaiDV.Size = new System.Drawing.Size(24, 20);
			this.buttonLoaiDV.TabIndex = 25;
			this.buttonLoaiDV.Text = "...";
			// 
			// txtLoai
			// 
			this.txtLoai.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtLoai.Enabled = false;
			this.txtLoai.Location = new System.Drawing.Point(448, 328);
			this.txtLoai.Name = "txtLoai";
			this.txtLoai.Size = new System.Drawing.Size(32, 20);
			this.txtLoai.TabIndex = 26;
			this.txtLoai.Text = "";
			// 
			// DMKHOAPHONG
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 403);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtLoai,
																		  this.buttonLoaiDV,
																		  this.lbLoai,
																		  this.cmbLoai,
																		  this.lbTenkhoaphong,
																		  this.txtTenkhoaphong,
																		  this.txtMa,
																		  this.LBMa,
																		  this.buttonKetthuc,
																		  this.buttonHuy,
																		  this.buttonBoqua,
																		  this.buttonLuu,
																		  this.buttonSua,
																		  this.buttonThem,
																		  this.dtgDMKHOAPHONG,
																		  this.buttonLuuUpdate});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DMKHOAPHONG";
			this.Text = "DM KHOA PHÒNG, BỆNH VIỆN";
			this.Load += new System.EventHandler(this.DMKHOAPHONG_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgDMKHOAPHONG)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		public void LoadGrid_Style()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();

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
			c0.MappingName="MaDVYC";
			c0.HeaderText="Mã DVYC";
			c0.Width=100;
			tbs.GridColumnStyles.Add(c0);

			dtgDMKHOAPHONG.TableStyles.Add(tbs);
			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="TenDVYC";
			c1.HeaderText="Tên DVYC";
			c1.Width=274;
			tbs.GridColumnStyles.Add(c1);	
		
			DataGridTextBoxColumn c2=new DataGridTextBoxColumn();
			c2.MappingName="MaloaiDV";
			c2.HeaderText="Mã Loại ĐC";
			c2.Width=100;
			tbs.GridColumnStyles.Add(c2);		

			dtgDMKHOAPHONG.TableStyles.Add(tbs);
			
		}	
		private void DMKHOAPHONG_Load(object sender, System.EventArgs e)
		{
			ShowGrid();		
			LoadGrid_Style();	
			Text_First();
			Load_ComboLoai();	
			cmbLoai.Text="";
			txtLoai.Text="";
		}

		public void ShowGrid()
		{
			string sql_select ="Select * From GPB_DVYC";
			Ds = k.get_data(sql_select);
			dtgDMKHOAPHONG.DataSource = Ds.Tables[0];			
		}		

		private void dtgDMKHOAPHONG_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtMa.Text=dtgDMKHOAPHONG[dtgDMKHOAPHONG.CurrentCell.RowNumber,0].ToString();
				txtTenkhoaphong.Text=dtgDMKHOAPHONG[dtgDMKHOAPHONG.CurrentCell.RowNumber,1].ToString();
				txtLoai.Text=dtgDMKHOAPHONG[dtgDMKHOAPHONG.CurrentRowIndex,2].ToString();
			}
			catch{}
			
		}

		private void buttonKetthuc_Click(object sender, System.EventArgs e)
		{
			m.UnEnableButton(true);
			this.Close();
		}

		private void buttonThem_Click(object sender, System.EventArgs e)
		{
			EnableTextBox(true);
			txtMa.Clear();
			txtTenkhoaphong.Clear();
			txtMa.Focus();
			buttonLuu.Visible=true;		
			buttonLuu.Enabled=true;
			buttonLuuUpdate.Visible = false;
		}

		public void EnableTextBox(bool ena)
		{
			buttonBoqua.Enabled=ena;
			buttonHuy.Enabled=!ena;
			buttonKetthuc.Enabled=!ena;
			buttonLuu.Enabled=ena;
			buttonLuuUpdate.Visible=!ena;
			buttonThem.Enabled=!ena;
			buttonSua.Enabled=!ena;
		

			txtMa.Enabled=ena;
			txtTenkhoaphong.Enabled=ena;	
		
			cmbLoai.Enabled=ena;
			buttonLoaiDV.Enabled=ena;
		}

		private void buttonLuu_Click(object sender, System.EventArgs e)
		{	
			if(!Kiemtra())return;			
			string sql = "Select MaDVYC From DVYC";				
			if(k.Kiemtratrungma(sql,txtMa.Text.ToString().Trim()))
			{
				MessageBox.Show("Mã ĐVYC bị trùng, Hãy chọn mã khác ","Chú ý");
				txtMa.Clear();
				txtMa.Focus();
			}
			else
			{
				k.execute_data("Insert into DVYC(MaDVYC,TenDVYC,MaloaiDV) Values('"+txtMa.Text.ToString()+"','"+txtTenkhoaphong.Text.ToString()+"','"+txtLoai.Text.ToString()+"')");
				ShowGrid();
				EnableTextBox(false);
				buttonThem.Focus();	              
			}
		}

		private bool Kiemtra()
		{
			if(txtMa.TextLength==0)
			{
				MessageBox.Show("Chưa nhập Mã Khoa Phòng","Thông Báo");
				txtMa.Focus();
				return false;
			}

			if(txtTenkhoaphong.TextLength==0)
			{
				MessageBox.Show("Chưa nhập tên Khoa Phòng","Thông Báo");
				txtTenkhoaphong.Focus();
				return false;
			}
			if(cmbLoai.SelectedIndex<0)
			{
				MessageBox.Show("Chưa chọn loại Khoa Phòng","Thông Báo");
				cmbLoai.Focus();
				return false;
			}
			try 
			{
				int b = int.Parse(txtMa.Text);				
			}
			catch
			{
				MessageBox.Show("Hãy nhập Mã bằng một ký tự số");	
				txtMa.Focus();			
				return false;
			}
			return true;
		}

		private void buttonBoqua_Click(object sender, System.EventArgs e)
		{
			EnableTextBox(false);			
			buttonThem.Focus();
			txtMa.Text =dtgDMKHOAPHONG[0,0].ToString();
			txtTenkhoaphong.Text=dtgDMKHOAPHONG[0,1].ToString();
			txtLoai.Text=dtgDMKHOAPHONG[0,2].ToString();
			buttonLuuUpdate.Visible=false;
			buttonLuu.Visible=true;
			buttonLuu.Enabled=false;
		}

		private void buttonHuy_Click(object sender, System.EventArgs e)
		{
			if(dtgDMKHOAPHONG.VisibleRowCount !=0)
			{
				if(MessageBox.Show("Bạn chắc chắn muốn xoá mẩu tin nay ?","Chú ý",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
				{			
					k.execute_data("Delete * From DVYC Where MaDVYC = "+dtgDMKHOAPHONG[dtgDMKHOAPHONG.CurrentRowIndex,0]+" ");
					ShowGrid();	
					Text_First();
				}
			}
			else
			{
				MessageBox.Show("Không còn dữ liệu !","Chú ý");
			}
		}

		private void buttonSua_Click(object sender, System.EventArgs e)
		{
			Enable_buttonSua(true);
			buttonLuu.Visible=false;
			buttonLuuUpdate.Visible=true;
			buttonLuuUpdate.Enabled=true;
		}

		public void Enable_buttonSua(bool ena)
		{
			buttonBoqua.Enabled=ena;
			buttonHuy.Enabled=!ena;
			buttonKetthuc.Enabled=!ena;			
			buttonSua.Enabled=!ena;
			buttonThem.Enabled=!ena;
			buttonLuuUpdate.Enabled=ena; 
			buttonLoaiDV.Enabled= ena;

			cmbLoai.Enabled=ena;

			txtMa.Enabled = false;
			txtTenkhoaphong.Enabled=ena;		
		}

		private void buttonLuuUpdate_Click(object sender, System.EventArgs e)
		{
			if(!Kiemtra())return;

			string sql_update = "Update DVYC set TenDVYC = '"+txtTenkhoaphong.Text.ToString()+"',MaloaiDV='"+txtLoai.Text.ToString()+"' Where MaDVYC = "+txtMa.Text+" ";
			k.execute_data(sql_update);
			ShowGrid();
			Enable_buttonSua(false);		
		}

		private void txtMa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtTenkhoaphong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void dtgDMKHOAPHONG_DoubleClick(object sender, System.EventArgs e)
		{
			Enable_buttonSua(true);
		}

		public void Text_First()
		{
			txtMa.Text=dtgDMKHOAPHONG[0,0].ToString();
			txtTenkhoaphong.Text = dtgDMKHOAPHONG[0,1].ToString();
			txtLoai.Text=dtgDMKHOAPHONG[0,2].ToString();
		}

		private void dtgDMKHOAPHONG_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete )
			{
				if(dtgDMKHOAPHONG.VisibleRowCount !=0)
				{
					if(MessageBox.Show("Bạn chắc chắn muốn xoá mẩu tin nay ?","Chú ý",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
					{			
						k.execute_data("Delete * From DVYC Where MaDVYC = "+dtgDMKHOAPHONG[dtgDMKHOAPHONG.CurrentRowIndex,0]+" ");
						ShowGrid();	
						Text_First();
					}
				}
				else
				{
					MessageBox.Show("Không còn dữ liệu !","Chú ý");
				}
			}
		}


		private void Load_ComboLoai()
		{
			string sql = "Select * From GPB_DONVI";
			k.OutputCMB(cmbLoai,k.get_data(sql).Tables[0],"MaloaiDV","TenloaiDV");
		}

		private void cmbLoai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtLoai.Text=cmbLoai.SelectedValue.ToString();
		}

		private void cmbLoai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) 
				buttonLuu.Focus();
		}		
	}
}
