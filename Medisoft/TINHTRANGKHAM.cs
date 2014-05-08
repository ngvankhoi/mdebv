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
	/// Summary description for TINHTRANGKHAM.
	/// </summary>
	public class TINHTRANGKHAM : System.Windows.Forms.Form
	{
        Language lan = new Language();
		string msb = "Thông Báo";
		DataSet Ds;
		Lib_LH.Access_Data k= new Lib_LH.Access_Data();
		private System.Windows.Forms.Button cmdKetthuc;
		private System.Windows.Forms.Button cmdHuy;
		private System.Windows.Forms.Button cmdBoqua;
		private System.Windows.Forms.Button cmdSua;
		private System.Windows.Forms.Button cmdThem;
		private System.Windows.Forms.Button cmdLuu_Update;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbMatinhtrang;
		private System.Windows.Forms.TextBox txtTINHTRANG;
		private System.Windows.Forms.TextBox txtMATINHTRANG;
		private System.Windows.Forms.Button cmdLuu;
		private System.Windows.Forms.DataGrid dtgTINHTRANGKHAM;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TINHTRANGKHAM()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TINHTRANGKHAM));
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.cmdHuy = new System.Windows.Forms.Button();
			this.cmdBoqua = new System.Windows.Forms.Button();
			this.cmdSua = new System.Windows.Forms.Button();
			this.cmdThem = new System.Windows.Forms.Button();
			this.cmdLuu_Update = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lbMatinhtrang = new System.Windows.Forms.Label();
			this.txtTINHTRANG = new System.Windows.Forms.TextBox();
			this.txtMATINHTRANG = new System.Windows.Forms.TextBox();
			this.cmdLuu = new System.Windows.Forms.Button();
			this.dtgTINHTRANGKHAM = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dtgTINHTRANGKHAM)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdKetthuc.Image")));
			this.cmdKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdKetthuc.Location = new System.Drawing.Point(400, 280);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(80, 32);
			this.cmdKetthuc.TabIndex = 67;
			this.cmdKetthuc.Text = "Kết thúc";
			this.cmdKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// cmdHuy
			// 
			this.cmdHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdHuy.Image")));
			this.cmdHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdHuy.Location = new System.Drawing.Point(328, 280);
			this.cmdHuy.Name = "cmdHuy";
			this.cmdHuy.Size = new System.Drawing.Size(72, 32);
			this.cmdHuy.TabIndex = 66;
			this.cmdHuy.Text = "      Huỷ";
			this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
			// 
			// cmdBoqua
			// 
			this.cmdBoqua.Enabled = false;
			this.cmdBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdBoqua.Image")));
			this.cmdBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdBoqua.Location = new System.Drawing.Point(256, 280);
			this.cmdBoqua.Name = "cmdBoqua";
			this.cmdBoqua.Size = new System.Drawing.Size(72, 32);
			this.cmdBoqua.TabIndex = 4;
			this.cmdBoqua.Text = "Bỏ qua";
			this.cmdBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdBoqua.Click += new System.EventHandler(this.cmdBoqua_Click);
			// 
			// cmdSua
			// 
			this.cmdSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdSua.Image")));
			this.cmdSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdSua.Location = new System.Drawing.Point(120, 280);
			this.cmdSua.Name = "cmdSua";
			this.cmdSua.Size = new System.Drawing.Size(64, 32);
			this.cmdSua.TabIndex = 65;
			this.cmdSua.Text = "    Sửa";
			this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
			// 
			// cmdThem
			// 
			this.cmdThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdThem.Image")));
			this.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdThem.Location = new System.Drawing.Point(56, 280);
			this.cmdThem.Name = "cmdThem";
			this.cmdThem.Size = new System.Drawing.Size(64, 32);
			this.cmdThem.TabIndex = 0;
			this.cmdThem.Text = "Thêm ";
			this.cmdThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
			// 
			// cmdLuu_Update
			// 
			this.cmdLuu_Update.Enabled = false;
			this.cmdLuu_Update.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdLuu_Update.Image")));
			this.cmdLuu_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdLuu_Update.Location = new System.Drawing.Point(184, 280);
			this.cmdLuu_Update.Name = "cmdLuu_Update";
			this.cmdLuu_Update.Size = new System.Drawing.Size(72, 32);
			this.cmdLuu_Update.TabIndex = 3;
			this.cmdLuu_Update.Text = "Luu";
			this.cmdLuu_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdLuu_Update.Click += new System.EventHandler(this.cmdLuu_Update_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(196, 253);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 61;
			this.label2.Text = "Tên Tình Trạng :";
			// 
			// lbMatinhtrang
			// 
			this.lbMatinhtrang.Location = new System.Drawing.Point(32, 253);
			this.lbMatinhtrang.Name = "lbMatinhtrang";
			this.lbMatinhtrang.Size = new System.Drawing.Size(88, 16);
			this.lbMatinhtrang.TabIndex = 60;
			this.lbMatinhtrang.Text = "Mã Tình Trạng :";
			// 
			// txtTINHTRANG
			// 
			this.txtTINHTRANG.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtTINHTRANG.Location = new System.Drawing.Point(284, 250);
			this.txtTINHTRANG.Name = "txtTINHTRANG";
			this.txtTINHTRANG.Size = new System.Drawing.Size(228, 20);
			this.txtTINHTRANG.TabIndex = 2;
			this.txtTINHTRANG.Text = "";
			this.txtTINHTRANG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTINHTRANG_KeyDown);
			// 
			// txtMATINHTRANG
			// 
			this.txtMATINHTRANG.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtMATINHTRANG.Location = new System.Drawing.Point(114, 250);
			this.txtMATINHTRANG.Name = "txtMATINHTRANG";
			this.txtMATINHTRANG.Size = new System.Drawing.Size(56, 20);
			this.txtMATINHTRANG.TabIndex = 1;
			this.txtMATINHTRANG.Text = "";
			this.txtMATINHTRANG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMATINHTRANG_KeyDown);
			// 
			// cmdLuu
			// 
			this.cmdLuu.Enabled = false;
			this.cmdLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdLuu.Image")));
			this.cmdLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdLuu.Location = new System.Drawing.Point(184, 280);
			this.cmdLuu.Name = "cmdLuu";
			this.cmdLuu.Size = new System.Drawing.Size(72, 32);
			this.cmdLuu.TabIndex = 3;
			this.cmdLuu.Text = "     Lưu";
			this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
			// 
			// dtgTINHTRANGKHAM
			// 
			this.dtgTINHTRANGKHAM.AllowSorting = false;
			this.dtgTINHTRANGKHAM.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgTINHTRANGKHAM.BackColor = System.Drawing.Color.White;
			this.dtgTINHTRANGKHAM.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dtgTINHTRANGKHAM.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgTINHTRANGKHAM.CaptionVisible = false;
			this.dtgTINHTRANGKHAM.DataMember = "";
			this.dtgTINHTRANGKHAM.FlatMode = true;
			this.dtgTINHTRANGKHAM.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgTINHTRANGKHAM.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.dtgTINHTRANGKHAM.HeaderBackColor = System.Drawing.Color.DarkSlateBlue;
			this.dtgTINHTRANGKHAM.HeaderForeColor = System.Drawing.Color.Yellow;
			this.dtgTINHTRANGKHAM.Location = new System.Drawing.Point(8, 8);
			this.dtgTINHTRANGKHAM.Name = "dtgTINHTRANGKHAM";
			this.dtgTINHTRANGKHAM.ReadOnly = true;
			this.dtgTINHTRANGKHAM.RowHeaderWidth = 20;
			this.dtgTINHTRANGKHAM.SelectionBackColor = System.Drawing.Color.Red;
			this.dtgTINHTRANGKHAM.SelectionForeColor = System.Drawing.Color.White;
			this.dtgTINHTRANGKHAM.Size = new System.Drawing.Size(528, 232);
			this.dtgTINHTRANGKHAM.TabIndex = 76;
			this.dtgTINHTRANGKHAM.CurrentCellChanged += new System.EventHandler(this.dtgTINHTRANGKHAM_CurrentCellChanged_1);
			// 
			// TINHTRANGKHAM
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dtgTINHTRANGKHAM,
																		  this.cmdLuu,
																		  this.txtMATINHTRANG,
																		  this.cmdKetthuc,
																		  this.cmdHuy,
																		  this.cmdBoqua,
																		  this.cmdSua,
																		  this.cmdThem,
																		  this.cmdLuu_Update,
																		  this.label2,
																		  this.lbMatinhtrang,
																		  this.txtTINHTRANG});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TINHTRANGKHAM";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DANH MỤC TÌNH TRẠNG HẸN KHÁM";
			this.Load += new System.EventHandler(this.TINHTRANGKHAM_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgTINHTRANGKHAM)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdThem_Click(object sender, System.EventArgs e)
		{
			Text_clear();
			Vis_buttonLuu(true);
			Ena_button(true);
			txtMATINHTRANG.Enabled=true;
			txtTINHTRANG.Enabled=true;
			txtMATINHTRANG.Focus();		
		}

		private void Text_clear()
		{
			txtMATINHTRANG.Clear();
			txtTINHTRANG.Clear();
		}

		private void Vis_buttonLuu(bool ena)
		{
			cmdLuu.Visible=ena;
			cmdLuu_Update.Visible=!ena;
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

		private void cmdBoqua_Click(object sender, System.EventArgs e)
		{
			Ena_button(false);
			cmdLuu.Visible=true;
			cmdLuu_Update.Visible=false;
			cmdLuu.Enabled=false;
			txtMATINHTRANG.Enabled=false;
			txtTINHTRANG.Enabled=false;
			Text_First();
		}

		private void Text_First()
		{
			if(dtgTINHTRANGKHAM.VisibleRowCount>1)
			{
				txtMATINHTRANG.Text=dtgTINHTRANGKHAM [0,0].ToString();
				txtTINHTRANG.Text=dtgTINHTRANGKHAM[0,1].ToString();
			}
		}

		private void cmdLuu_Click(object sender, System.EventArgs e)
		{
			if(!Check_EmptyText()) return;			
			if(k.Get_matt(txtMATINHTRANG.Text.ToString().Trim())!=null)
			{
				MessageBox.Show("Đã có mã tình trạng này",msb);
				txtMATINHTRANG.Focus();
				return;
			}			
			k.Ins_Tinhtrang(txtMATINHTRANG.Text.ToString().Trim(),txtTINHTRANG.Text.ToString().Trim());			
			Ena_button(false);
			Load_Grid();
			txtMATINHTRANG.Enabled=false;
			txtTINHTRANG.Enabled=false;
			cmdThem.Focus();
		}

		private bool Check_EmptyText()
		{
			if(txtMATINHTRANG.TextLength==0)
			{
				MessageBox.Show("Nhập mã tình trạng hẹn khám ",msb);
				txtMATINHTRANG.Focus();
				return false;
			}

			if(txtTINHTRANG.TextLength==0)
			{
				MessageBox.Show("Nhập tên tình trạng hẹn khám",msb);
				txtTINHTRANG.Focus();
				return false;
			}

			return true;
		}

		private void Load_Grid()
		{
			Ds=k.Get_Tinhtrang();
			dtgTINHTRANGKHAM.DataSource=Ds.Tables[0];
			LoadGridStyle();
		}

		private void TINHTRANGKHAM_Load(object sender, System.EventArgs e)
		{
			Ena_button(false);
			txtMATINHTRANG.Enabled=false;
			txtTINHTRANG.Enabled=false;
			Load_Grid();			
			Text_First();
			cmdThem.Focus();
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
			c0.MappingName="MATT";
			c0.HeaderText="Mã Tình Trạng Hẹn Khám";
			c0.Width=160;
			c0.NullText="";
			tbs.GridColumnStyles.Add(c0);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="TENTT";
			c1.HeaderText="Tên Tình Trạng Hẹn Khám";
			c1.NullText="";
			c1.Width=340;
			tbs.GridColumnStyles.Add(c1);
            
			dtgTINHTRANGKHAM.TableStyles.Clear();
			dtgTINHTRANGKHAM.TableStyles.Add(tbs);
		}

		private void cmdSua_Click(object sender, System.EventArgs e)
		{
			if(txtMATINHTRANG.TextLength==0)
			{
				MessageBox.Show("Chọn một tình trạng muốn sửa từ danh sách",msb);
			}
			else
			{
				txtTINHTRANG.Enabled=true;
				txtMATINHTRANG.Enabled=false;
				cmdLuu.Visible=false;				
				cmdLuu_Update.Visible=true;
				cmdLuu_Update.Enabled=true;
				Ena_button(true);
				txtTINHTRANG.Focus();
			}
		}

		private void cmdHuy_Click(object sender, System.EventArgs e)
		{
			DataSet dataset1 = k.get_data("Select distinct tinhtrang from lh_khambenh");
			DataTable datatable1=dataset1.Tables[0];
			if(datatable1.Rows.Count>0)
			{
				for(int i=0;i < datatable1.Rows.Count;i++)
				{
					if(datatable1.Rows[i]["TINHTRANG"].ToString()==txtMATINHTRANG.Text)
					{
						MessageBox.Show("Không được phép huỷ thông tin đã sử dụng","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
						return;
					}
				}
			}			
			if(txtMATINHTRANG.TextLength==0)
				MessageBox.Show("Chọn mẩu tin muốn xoá từ danh sách trên",msb);
			else
			{
				if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?",msb,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					k.Del_Tinhtrang(txtMATINHTRANG.Text.ToString().Trim());
					Load_Grid();
					Text_First();
				}
			}		
		}

		private void dtgTINHTRANGKHAM_CurrentCellChanged(object sender, System.EventArgs e)
		{
			
		}

		private void txtMATINHTRANG_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter ) txtTINHTRANG.Focus();
		}

		private void txtTINHTRANG_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter ) 
			{
				cmdLuu.Focus();
				cmdLuu_Update.Focus();
			}
		}

		private void cmdLuu_Update_Click(object sender, System.EventArgs e)
		{
			if(txtTINHTRANG.TextLength ==0)
			{
				MessageBox.Show("Nhập tên tình trạng",msb);
				txtTINHTRANG.Focus();
				return;
			}
			else
			{
				k.Upd_Tinhtrang(txtMATINHTRANG.Text.ToString().Trim(),txtTINHTRANG.Text.ToString().Trim());
				Load_Grid();
				Ena_cmd_Upd(false);
				txtTINHTRANG.Enabled=false;
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

		private void dtgTINHTRANGKHAM_CurrentCellChanged_1(object sender, System.EventArgs e)
		{
			txtMATINHTRANG.Text=dtgTINHTRANGKHAM[dtgTINHTRANGKHAM.CurrentCell.RowNumber,0].ToString();
			txtTINHTRANG.Text=dtgTINHTRANGKHAM[dtgTINHTRANGKHAM.CurrentCell.RowNumber,1].ToString();
		}
	}
}
