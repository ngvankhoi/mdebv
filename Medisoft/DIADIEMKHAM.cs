using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Lib_LH;

namespace Medisoft
{
	/// <summary>
	/// Summary description for FRMDIADIEMKHAM.
	/// </summary>
	public class DIADIEMKHAM : System.Windows.Forms.Form
	{
        Language lan = new Language();
		DataSet Ds ;
		Lib_LH.Access_Data k= new Lib_LH.Access_Data();
		string msb="Thông Báo";
		private System.Windows.Forms.Button cmdKetthuc;
		private System.Windows.Forms.Button cmdHuy;
		private System.Windows.Forms.Button cmdBoqua;
		private System.Windows.Forms.Button cmdSua;
		private System.Windows.Forms.Button cmdThem;
		private System.Windows.Forms.Button cmdLuu_Update;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbMadiadiem;
		private System.Windows.Forms.TextBox txtTENDD;
		private System.Windows.Forms.TextBox txtMADD;
		private System.Windows.Forms.Button cmdLuu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbThuoc;
		private System.Windows.Forms.TextBox txtthuoc;
		private System.Windows.Forms.DataGrid dtgDIADIEM;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DIADIEMKHAM()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DIADIEMKHAM));
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.cmdHuy = new System.Windows.Forms.Button();
			this.cmdBoqua = new System.Windows.Forms.Button();
			this.cmdSua = new System.Windows.Forms.Button();
			this.cmdThem = new System.Windows.Forms.Button();
			this.cmdLuu_Update = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lbMadiadiem = new System.Windows.Forms.Label();
			this.txtTENDD = new System.Windows.Forms.TextBox();
			this.txtMADD = new System.Windows.Forms.TextBox();
			this.cmdLuu = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbThuoc = new System.Windows.Forms.ComboBox();
			this.txtthuoc = new System.Windows.Forms.TextBox();
			this.dtgDIADIEM = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dtgDIADIEM)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdKetthuc.Image")));
			this.cmdKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdKetthuc.Location = new System.Drawing.Point(422, 296);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(76, 32);
			this.cmdKetthuc.TabIndex = 56;
			this.cmdKetthuc.Text = "Kết thúc";
			this.cmdKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// cmdHuy
			// 
			this.cmdHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdHuy.Image")));
			this.cmdHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdHuy.Location = new System.Drawing.Point(346, 296);
			this.cmdHuy.Name = "cmdHuy";
			this.cmdHuy.Size = new System.Drawing.Size(76, 32);
			this.cmdHuy.TabIndex = 55;
			this.cmdHuy.Text = "     Huỷ";
			this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
			// 
			// cmdBoqua
			// 
			this.cmdBoqua.Enabled = false;
			this.cmdBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdBoqua.Image")));
			this.cmdBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdBoqua.Location = new System.Drawing.Point(270, 296);
			this.cmdBoqua.Name = "cmdBoqua";
			this.cmdBoqua.Size = new System.Drawing.Size(76, 32);
			this.cmdBoqua.TabIndex = 53;
			this.cmdBoqua.Text = "Bỏ qua";
			this.cmdBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdBoqua.Click += new System.EventHandler(this.cmdBoqua_Click);
			// 
			// cmdSua
			// 
			this.cmdSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdSua.Image")));
			this.cmdSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdSua.Location = new System.Drawing.Point(118, 296);
			this.cmdSua.Name = "cmdSua";
			this.cmdSua.Size = new System.Drawing.Size(76, 32);
			this.cmdSua.TabIndex = 54;
			this.cmdSua.Text = "      Sửa";
			this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
			// 
			// cmdThem
			// 
			this.cmdThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdThem.Image")));
			this.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdThem.Location = new System.Drawing.Point(42, 296);
			this.cmdThem.Name = "cmdThem";
			this.cmdThem.Size = new System.Drawing.Size(76, 32);
			this.cmdThem.TabIndex = 0;
			this.cmdThem.Text = "    Thêm ";
			this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
			// 
			// cmdLuu_Update
			// 
			this.cmdLuu_Update.Enabled = false;
			this.cmdLuu_Update.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdLuu_Update.Image")));
			this.cmdLuu_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdLuu_Update.Location = new System.Drawing.Point(194, 296);
			this.cmdLuu_Update.Name = "cmdLuu_Update";
			this.cmdLuu_Update.Size = new System.Drawing.Size(76, 32);
			this.cmdLuu_Update.TabIndex = 5;
			this.cmdLuu_Update.Text = "Luu";
			this.cmdLuu_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdLuu_Update.Click += new System.EventHandler(this.cmdLuu_Update_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(125, 260);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 16);
			this.label2.TabIndex = 50;
			this.label2.Text = "Tên Phòng";
			// 
			// lbMadiadiem
			// 
			this.lbMadiadiem.Location = new System.Drawing.Point(16, 260);
			this.lbMadiadiem.Name = "lbMadiadiem";
			this.lbMadiadiem.Size = new System.Drawing.Size(94, 16);
			this.lbMadiadiem.TabIndex = 49;
			this.lbMadiadiem.Text = "Mã Phòng";
			// 
			// txtTENDD
			// 
			this.txtTENDD.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtTENDD.Location = new System.Drawing.Point(184, 256);
			this.txtTENDD.Name = "txtTENDD";
			this.txtTENDD.Size = new System.Drawing.Size(168, 20);
			this.txtTENDD.TabIndex = 2;
			this.txtTENDD.Text = "";
			this.txtTENDD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTENDD_KeyDown);
			// 
			// txtMADD
			// 
			this.txtMADD.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtMADD.Location = new System.Drawing.Point(72, 256);
			this.txtMADD.Name = "txtMADD";
			this.txtMADD.Size = new System.Drawing.Size(40, 20);
			this.txtMADD.TabIndex = 1;
			this.txtMADD.Text = "";
			this.txtMADD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMADD_KeyDown);
			// 
			// cmdLuu
			// 
			this.cmdLuu.Enabled = false;
			this.cmdLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdLuu.Image")));
			this.cmdLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdLuu.Location = new System.Drawing.Point(194, 296);
			this.cmdLuu.Name = "cmdLuu";
			this.cmdLuu.Size = new System.Drawing.Size(76, 32);
			this.cmdLuu.TabIndex = 5;
			this.cmdLuu.Text = "      Lưu";
			this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(364, 260);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 57;
			this.label1.Text = "Thuộc ";
			// 
			// cmbThuoc
			// 
			this.cmbThuoc.Items.AddRange(new object[] {
														  "Phòng Khám",
														  "Khoa Nội Trú",
														  "Phòng Chức Năng",
														  "Phòng Phẫu Thuật",
														  "Khác"});
			this.cmbThuoc.Location = new System.Drawing.Point(408, 256);
			this.cmbThuoc.Name = "cmbThuoc";
			this.cmbThuoc.Size = new System.Drawing.Size(120, 21);
			this.cmbThuoc.TabIndex = 4;
			this.cmbThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbThuoc_KeyDown);
			this.cmbThuoc.SelectedIndexChanged += new System.EventHandler(this.cmbThuoc_SelectedIndexChanged);
			// 
			// txtthuoc
			// 
			this.txtthuoc.Location = new System.Drawing.Point(405, 256);
			this.txtthuoc.Name = "txtthuoc";
			this.txtthuoc.Size = new System.Drawing.Size(24, 20);
			this.txtthuoc.TabIndex = 3;
			this.txtthuoc.Text = "";
			this.txtthuoc.Visible = false;
			this.txtthuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtthuoc_KeyDown);
			this.txtthuoc.Validated += new System.EventHandler(this.txtthuoc_Validated);
			// 
			// dtgDIADIEM
			// 
			this.dtgDIADIEM.AllowSorting = false;
			this.dtgDIADIEM.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgDIADIEM.BackColor = System.Drawing.Color.White;
			this.dtgDIADIEM.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dtgDIADIEM.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgDIADIEM.CaptionVisible = false;
			this.dtgDIADIEM.DataMember = "";
			this.dtgDIADIEM.FlatMode = true;
			this.dtgDIADIEM.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgDIADIEM.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.dtgDIADIEM.HeaderBackColor = System.Drawing.Color.DarkSlateBlue;
			this.dtgDIADIEM.HeaderForeColor = System.Drawing.Color.Yellow;
			this.dtgDIADIEM.Location = new System.Drawing.Point(8, 8);
			this.dtgDIADIEM.Name = "dtgDIADIEM";
			this.dtgDIADIEM.ReadOnly = true;
			this.dtgDIADIEM.RowHeaderWidth = 20;
			this.dtgDIADIEM.SelectionBackColor = System.Drawing.Color.Red;
			this.dtgDIADIEM.SelectionForeColor = System.Drawing.Color.White;
			this.dtgDIADIEM.Size = new System.Drawing.Size(528, 232);
			this.dtgDIADIEM.TabIndex = 77;
			this.dtgDIADIEM.CurrentCellChanged += new System.EventHandler(this.dtgDIADIEM_CurrentCellChanged_1);
			// 
			// DIADIEMKHAM
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dtgDIADIEM,
																		  this.txtthuoc,
																		  this.cmbThuoc,
																		  this.txtMADD,
																		  this.txtTENDD,
																		  this.label1,
																		  this.cmdLuu,
																		  this.cmdKetthuc,
																		  this.cmdHuy,
																		  this.cmdBoqua,
																		  this.cmdSua,
																		  this.cmdThem,
																		  this.cmdLuu_Update,
																		  this.label2,
																		  this.lbMadiadiem});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DIADIEMKHAM";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Danh mục phòng khám";
			this.Load += new System.EventHandler(this.DIADIEMKHAM_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgDIADIEM)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{		
			this.Close();			
		}

		private void DIADIEMKHAM_Load(object sender, System.EventArgs e)
		{
			Ena_button(false);
			txtMADD.Enabled=false;
			txtTENDD.Enabled=false;
			Load_Grid();
			
			Load_cmbThuoc();
			Text_First();
			cmdThem.Focus();
		}

		private void Ena_button(bool ena)
		{
			cmdBoqua.Enabled=ena;
			cmdHuy.Enabled=!ena;
			cmdKetthuc.Enabled=!ena;
			cmdLuu.Enabled=ena;
			cmdSua.Enabled=!ena;
			cmdThem.Enabled=!ena;			
		}

		private void LoadGridStyle()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName=Ds.Tables[0].TableName;

			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.MidnightBlue;
			tbs.HeaderForeColor = Color.Lavender;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.ReadOnly=true;
			tbs.RowHeaderWidth =8;

			DataGridTextBoxColumn c0=new DataGridTextBoxColumn();
			c0.MappingName="MAKP";
			c0.HeaderText="Mã Khoa Phòng";
			c0.Width=100;
			c0.NullText="";			
			tbs.GridColumnStyles.Add(c0);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="TENKP";
			c1.HeaderText="Tên Khoa Phòng";
			c1.NullText="";
			c1.Width=230;
			tbs.GridColumnStyles.Add(c1);

			DataGridTextBoxColumn c2=new DataGridTextBoxColumn();
			c2.MappingName="LOAI";
			c2.HeaderText="Nhóm";
			c2.NullText="";
			c2.Width=0;
			tbs.GridColumnStyles.Add(c2);

			DataGridTextBoxColumn c3=new DataGridTextBoxColumn();
			c3.MappingName="TENNHOM";
			c3.HeaderText="Tên Nhóm";
			c3.NullText="";
			c3.Width=156;			
			tbs.GridColumnStyles.Add(c3);

			dtgDIADIEM.TableStyles.Clear();
			dtgDIADIEM.TableStyles.Add(tbs);
		}

		private void Load_Grid()
		{
			Ds=k.Get_Khoaphong();
			dtgDIADIEM.DataSource=Ds.Tables[0];
			LoadGridStyle();
		}

		private void Text_First()
		{			
			if(dtgDIADIEM.VisibleRowCount>1)
			{
				txtMADD.Text=dtgDIADIEM[0,0].ToString();
				txtTENDD.Text=dtgDIADIEM[0,1].ToString();
			}
		}

		private void dtgDIADIEM_CurrentCellChanged(object sender, System.EventArgs e)
		{
			
		}

		private void cmdThem_Click(object sender, System.EventArgs e)
		{
			Text_clear();
			Vis_buttonLuu(true);
			Ena_button(true);
			txtMADD.Enabled=true;
			txtTENDD.Enabled=true;
			txtMADD.Focus();
		}

		private void Text_clear()
		{
			txtMADD.Clear();
			txtTENDD.Clear();
		}

		private void Vis_buttonLuu(bool ena)
		{
			cmdLuu.Visible=ena;
			cmdLuu_Update.Visible=!ena;
		}

		private void cmdLuu_Click(object sender, System.EventArgs e)
		{
			if(!Check_EmptyText()) return;			
			if(k.Get_makp(txtMADD.Text.ToString().Trim()).Tables[0].Rows.Count >0)
			{
				MessageBox.Show("Đã có mã Khoa Phòng này",msb);
				txtMADD.Focus();
				return;
			}			
			k.Ins_Khoaphong(txtMADD.Text.ToString().Trim(),txtTENDD.Text.ToString().Trim(),txtthuoc.Text.ToString().Trim());			
			Ena_button(false);
			Load_Grid();
			txtMADD.Enabled=false;
			txtTENDD.Enabled=false;
			cmdThem.Focus();			
		}

		private bool Check_EmptyText()
		{
			if(txtMADD.TextLength==0)
			{
				MessageBox.Show("Nhập mã phòng khám",msb);
				txtMADD.Focus();
				return false;
			}

			if(txtTENDD.TextLength==0)
			{
				MessageBox.Show("Nhập tên phòng khám",msb);
				txtTENDD.Focus();
				return false;
			}
			return true;
		}

		private void txtMADD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtTENDD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) 	
			{
				cmbThuoc.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void cmdBoqua_Click(object sender, System.EventArgs e)
		{			
			Ena_button(false);
			cmdLuu.Visible=true;
			cmdLuu_Update.Visible=false;
			cmdLuu.Enabled=false;
			txtMADD.Enabled=false;
			txtTENDD.Enabled=false;

			Text_First();
		}

		private void cmdHuy_Click(object sender, System.EventArgs e)
		{	
			MessageBox.Show("Không được phép huỷ","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			return;
//			if(txtMADD.TextLength==0)
//				MessageBox.Show("Chọn mẩu tin muốn xoá từ danh sách trên",msb);
//			else
//			{
//				if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?",msb,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
//				{
//					k.Del_Khoaphong(txtMADD.Text.ToString().Trim());					
//					Load_Grid();
//					Text_First();					
//				}
//			}
		}

		private void cmdSua_Click(object sender, System.EventArgs e)
		{
			if(txtMADD.TextLength==0)
			{
				MessageBox.Show("Chọn phòng muốn sửa từ danh sách",msb);
			}
			else
			{
				txtTENDD.Enabled=true;
				txtMADD.Enabled=false;
				cmdLuu.Visible=false;				
				cmdLuu_Update.Visible=true;
				cmdLuu_Update.Enabled=true;
				Ena_button(true);
				txtTENDD.Focus();
			}
		}

		private void cmdLuu_Update_Click(object sender, System.EventArgs e)
		{
			if(txtTENDD.TextLength ==0)
			{
				MessageBox.Show("Nhập tên phòng khám",msb);
				txtTENDD.Focus();
				return;
			}
			else
			{
				k.Upd_Phongkham(txtMADD.Text.ToString().Trim(),txtTENDD.Text.ToString().Trim(),txtthuoc.Text.ToString().Trim());				;
				Load_Grid();
				Ena_cmd_Upd(false);
				txtTENDD.Enabled=false;
				cmdLuu_Update.Visible=false;
				cmdLuu.Visible=true;
				cmdLuu.Enabled=false;
			}		
		}

		private void Ena_cmd_Upd(bool ena)
		{
			cmdBoqua.Enabled=ena;
			cmdHuy.Enabled=!ena;
			cmdKetthuc.Enabled=!ena;
			cmdLuu_Update.Enabled=ena;
			cmdSua.Enabled=!ena;
			cmdThem.Enabled=!ena;						
		}

		private void Load_cmbThuoc()
		{
			cmbThuoc.DisplayMember="TENNHOM";
			cmbThuoc.ValueMember="MANHOM";
			cmbThuoc.DataSource=k.Get_nhomphong().Tables[0];
			cmbThuoc.SelectedIndex=0;			
		}

		private void cmbThuoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtthuoc.Text=cmbThuoc.SelectedValue.ToString();
		}

		private void txtthuoc_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbThuoc.SelectedValue=txtthuoc.Text.ToString().Trim();
			}
			catch{}
		}

		private void txtthuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbThuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) cmdLuu.Focus();
		}

		private void dtgDIADIEM_CurrentCellChanged_1(object sender, System.EventArgs e)
		{
			txtMADD.Text=dtgDIADIEM[dtgDIADIEM.CurrentCell.RowNumber,0].ToString();
			txtTENDD.Text=dtgDIADIEM[dtgDIADIEM.CurrentCell.RowNumber,1].ToString();
			txtthuoc.Text=dtgDIADIEM[dtgDIADIEM.CurrentCell.RowNumber,2].ToString();
			try
			{
				cmbThuoc.SelectedValue=txtthuoc.Text.ToString();
			}
			catch{};
		}

	}
}
