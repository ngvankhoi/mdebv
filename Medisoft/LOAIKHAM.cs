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
	/// Summary description for FRMLOAIKHAM.
	/// </summary>
	public class LOAIKHAM : System.Windows.Forms.Form
	{
        Language lan = new Language();
		DataSet Ds;
		Lib_LH.Access_Data k = new Lib_LH.Access_Data();
		string msb = "Thông Báo";
		private System.Windows.Forms.Button cmdKetthuc;
		private System.Windows.Forms.Button cmdHuy;
		private System.Windows.Forms.Button cmdBoqua;
		private System.Windows.Forms.Button cmdSua;
		private System.Windows.Forms.Button cmdThem;
		private System.Windows.Forms.Button cmdLuu_Update;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbMaLOAIKHAM;
		private System.Windows.Forms.TextBox txtTENLOAIKHAM;
		private System.Windows.Forms.TextBox txtMALOAIKHAM;
		private System.Windows.Forms.Button cmdLuu;
		private System.Windows.Forms.DataGrid dtgLOAIKHAM;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LOAIKHAM()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LOAIKHAM));
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.cmdHuy = new System.Windows.Forms.Button();
			this.cmdBoqua = new System.Windows.Forms.Button();
			this.cmdSua = new System.Windows.Forms.Button();
			this.cmdThem = new System.Windows.Forms.Button();
			this.cmdLuu_Update = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lbMaLOAIKHAM = new System.Windows.Forms.Label();
			this.txtTENLOAIKHAM = new System.Windows.Forms.TextBox();
			this.txtMALOAIKHAM = new System.Windows.Forms.TextBox();
			this.cmdLuu = new System.Windows.Forms.Button();
			this.dtgLOAIKHAM = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dtgLOAIKHAM)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdKetthuc.Image")));
			this.cmdKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdKetthuc.Location = new System.Drawing.Point(416, 288);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(76, 32);
			this.cmdKetthuc.TabIndex = 67;
			this.cmdKetthuc.Text = "Kết thúc";
			this.cmdKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// cmdHuy
			// 
			this.cmdHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdHuy.Image")));
			this.cmdHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdHuy.Location = new System.Drawing.Point(344, 288);
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
			this.cmdBoqua.Location = new System.Drawing.Point(272, 288);
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
			this.cmdSua.Location = new System.Drawing.Point(144, 288);
			this.cmdSua.Name = "cmdSua";
			this.cmdSua.Size = new System.Drawing.Size(64, 32);
			this.cmdSua.TabIndex = 65;
			this.cmdSua.Text = "     Sửa";
			this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
			// 
			// cmdThem
			// 
			this.cmdThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdThem.Image")));
			this.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdThem.Location = new System.Drawing.Point(80, 288);
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
			this.cmdLuu_Update.Location = new System.Drawing.Point(208, 288);
			this.cmdLuu_Update.Name = "cmdLuu_Update";
			this.cmdLuu_Update.Size = new System.Drawing.Size(64, 32);
			this.cmdLuu_Update.TabIndex = 3;
			this.cmdLuu_Update.Text = "Luu";
			this.cmdLuu_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdLuu_Update.Click += new System.EventHandler(this.cmdLuu_Update_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(180, 259);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 61;
			this.label2.Text = "Tên Loại Khám :";
			// 
			// lbMaLOAIKHAM
			// 
			this.lbMaLOAIKHAM.Location = new System.Drawing.Point(38, 259);
			this.lbMaLOAIKHAM.Name = "lbMaLOAIKHAM";
			this.lbMaLOAIKHAM.Size = new System.Drawing.Size(84, 16);
			this.lbMaLOAIKHAM.TabIndex = 60;
			this.lbMaLOAIKHAM.Text = "Mã Loại Khám :";
			// 
			// txtTENLOAIKHAM
			// 
			this.txtTENLOAIKHAM.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtTENLOAIKHAM.Location = new System.Drawing.Point(264, 256);
			this.txtTENLOAIKHAM.Name = "txtTENLOAIKHAM";
			this.txtTENLOAIKHAM.Size = new System.Drawing.Size(240, 20);
			this.txtTENLOAIKHAM.TabIndex = 2;
			this.txtTENLOAIKHAM.Text = "";
			this.txtTENLOAIKHAM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTENLOAIKHAM_KeyDown);
			// 
			// txtMALOAIKHAM
			// 
			this.txtMALOAIKHAM.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtMALOAIKHAM.Location = new System.Drawing.Point(118, 256);
			this.txtMALOAIKHAM.Name = "txtMALOAIKHAM";
			this.txtMALOAIKHAM.Size = new System.Drawing.Size(46, 20);
			this.txtMALOAIKHAM.TabIndex = 1;
			this.txtMALOAIKHAM.Text = "";
			this.txtMALOAIKHAM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMALOAIKHAM_KeyDown);
			// 
			// cmdLuu
			// 
			this.cmdLuu.Enabled = false;
			this.cmdLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdLuu.Image")));
			this.cmdLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdLuu.Location = new System.Drawing.Point(208, 288);
			this.cmdLuu.Name = "cmdLuu";
			this.cmdLuu.Size = new System.Drawing.Size(64, 32);
			this.cmdLuu.TabIndex = 3;
			this.cmdLuu.Text = "     Lưu";
			this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
			// 
			// dtgLOAIKHAM
			// 
			this.dtgLOAIKHAM.AllowSorting = false;
			this.dtgLOAIKHAM.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgLOAIKHAM.BackColor = System.Drawing.Color.White;
			this.dtgLOAIKHAM.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dtgLOAIKHAM.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgLOAIKHAM.CaptionVisible = false;
			this.dtgLOAIKHAM.DataMember = "";
			this.dtgLOAIKHAM.FlatMode = true;
			this.dtgLOAIKHAM.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgLOAIKHAM.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.dtgLOAIKHAM.HeaderBackColor = System.Drawing.Color.DarkSlateBlue;
			this.dtgLOAIKHAM.HeaderForeColor = System.Drawing.Color.Yellow;
			this.dtgLOAIKHAM.Location = new System.Drawing.Point(8, 8);
			this.dtgLOAIKHAM.Name = "dtgLOAIKHAM";
			this.dtgLOAIKHAM.ReadOnly = true;
			this.dtgLOAIKHAM.RowHeaderWidth = 20;
			this.dtgLOAIKHAM.SelectionBackColor = System.Drawing.Color.Red;
			this.dtgLOAIKHAM.SelectionForeColor = System.Drawing.Color.White;
			this.dtgLOAIKHAM.Size = new System.Drawing.Size(544, 232);
			this.dtgLOAIKHAM.TabIndex = 76;
			this.dtgLOAIKHAM.CurrentCellChanged += new System.EventHandler(this.dtgLOAIKHAM_CurrentCellChanged_1);
			// 
			// LOAIKHAM
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 333);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dtgLOAIKHAM,
																		  this.cmdLuu,
																		  this.txtMALOAIKHAM,
																		  this.txtTENLOAIKHAM,
																		  this.cmdKetthuc,
																		  this.cmdHuy,
																		  this.cmdBoqua,
																		  this.cmdSua,
																		  this.cmdThem,
																		  this.cmdLuu_Update,
																		  this.label2,
																		  this.lbMaLOAIKHAM});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LOAIKHAM";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Danh mục loại hẹn khám";
			this.Load += new System.EventHandler(this.LOAIKHAM_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgLOAIKHAM)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{this.Close();			
		}

		private void txtMALOAIKHAM_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtTENLOAIKHAM_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmdThem_Click(object sender, System.EventArgs e)
		{
			Text_clear();
			Vis_buttonLuu(true);
			Ena_button(true);
			txtMALOAIKHAM.Enabled=true;
			txtTENLOAIKHAM.Enabled=true;
			txtMALOAIKHAM.Focus();
		}

		private void Text_clear()
		{
			txtMALOAIKHAM.Clear();
			txtTENLOAIKHAM.Clear();
		}

		private void Vis_buttonLuu(bool ena)
		{
			cmdLuu.Visible=ena;
			cmdLuu_Update.Visible=!ena;
		}

		private void cmdLuu_Click(object sender, System.EventArgs e)
		{
			if(!Check_EmptyText()) return;			
			if(k.Get_mahk(txtMALOAIKHAM.Text.ToString().Trim()).Tables[0].Rows.Count >0)
			{
				MessageBox.Show("Đã có mã loại hẹn này",msb);
				txtMALOAIKHAM.Focus();
				return;
			}			
			k.Ins_Henkham(txtMALOAIKHAM.Text.ToString().Trim(),txtTENLOAIKHAM.Text.ToString().Trim());			
			Ena_button(false);
			Load_Grid();
			txtMALOAIKHAM.Enabled=false;
			txtTENLOAIKHAM.Enabled=false;
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

		private void Load_Grid()
		{
			Ds=k.Get_Henkham();
			dtgLOAIKHAM.DataSource=Ds.Tables[0];
			LoadGridStyle();
		}

		private void LOAIKHAM_Load(object sender, System.EventArgs e)
		{
			Ena_button(false);
			txtMALOAIKHAM.Enabled=false;
			txtTENLOAIKHAM.Enabled=false;
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
			c0.MappingName="MAHK";
			c0.HeaderText="Mã Loại Hẹn Khám";
			c0.Width=120;
			c0.NullText="";
			tbs.GridColumnStyles.Add(c0);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="TENHK";
			c1.HeaderText="Tên Loại Hẹn Khám";
			c1.NullText="";
			c1.Width=407;
			tbs.GridColumnStyles.Add(c1);
            
			dtgLOAIKHAM.TableStyles.Clear();
			dtgLOAIKHAM.TableStyles.Add(tbs);
		}

		private void Text_First()
		{
			if(dtgLOAIKHAM.VisibleRowCount>1)
			{
				txtMALOAIKHAM.Text=dtgLOAIKHAM[0,0].ToString();
				txtTENLOAIKHAM.Text=dtgLOAIKHAM[0,1].ToString();
			}
		}

		private bool Check_EmptyText()
		{
			if(txtMALOAIKHAM.TextLength==0)
			{
				MessageBox.Show("Nhập mã loại hẹn khám",msb);
				txtMALOAIKHAM.Focus();
				return false;
			}

			if(txtTENLOAIKHAM.TextLength==0)
			{
				MessageBox.Show("Nhập tên loại hẹn khám",msb);
				txtTENLOAIKHAM.Focus();
				return false;
			}

			return true;
		}

		private void cmdBoqua_Click(object sender, System.EventArgs e)
		{
			Ena_button(false);
			cmdLuu.Visible=true;
			cmdLuu_Update.Visible=false;
			cmdLuu.Enabled=false;
			txtMALOAIKHAM.Enabled=false;
			txtTENLOAIKHAM.Enabled=false;
			Text_First();
		}

		private void cmdHuy_Click(object sender, System.EventArgs e)
		{
			DataSet dataset1 = k.get_data("Select distinct lydohen from lh_khambenh");
			DataTable datatable1=dataset1.Tables[0];
			if(datatable1.Rows.Count>0)
			{
				for(int i=0;i < datatable1.Rows.Count;i++)
				{
					if(datatable1.Rows[i]["LYDOHEN"].ToString()==txtMALOAIKHAM.Text)
					{
						MessageBox.Show("Không được phép huỷ thông tin đã sử dụng","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
						return;
					}
				}
			}			
			if(txtMALOAIKHAM.TextLength==0)
				MessageBox.Show("Chọn mẩu tin muốn xoá từ danh sách trên",msb);
			else
			{
				if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?",msb,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					k.Del_Henkham(txtMALOAIKHAM.Text.ToString().Trim());
					Load_Grid();
					Text_First();
					
				}
			}				
		}

		private void cmdSua_Click(object sender, System.EventArgs e)
		{
			if(txtMALOAIKHAM.TextLength==0)
			{
				MessageBox.Show("Chọn một loại khám muốn sửa từ danh sách",msb);
			}
			else
			{
				txtTENLOAIKHAM.Enabled=true;
				txtMALOAIKHAM.Enabled=false;
				cmdLuu.Visible=false;				
				cmdLuu_Update.Visible=true;
				cmdLuu_Update.Enabled=true;
				Ena_button(true);
				txtTENLOAIKHAM.Focus();
			}
		}

		private void cmdLuu_Update_Click(object sender, System.EventArgs e)
		{
			if(txtTENLOAIKHAM.TextLength ==0)
			{
				MessageBox.Show("Nhập tên loại hẹn khám",msb);
				txtTENLOAIKHAM.Focus();
				return;
			}
			else
			{
				k.Upd_Henkham(txtMALOAIKHAM.Text.ToString().Trim(),txtTENLOAIKHAM.Text.ToString().Trim());
				Load_Grid();
				Ena_cmd_Upd(false);
				txtTENLOAIKHAM.Enabled=false;
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

		private void dtgLOAIKHAM_CurrentCellChanged_1(object sender, System.EventArgs e)
		{
			txtMALOAIKHAM.Text=dtgLOAIKHAM[dtgLOAIKHAM.CurrentCell.RowNumber,0].ToString();
			txtTENLOAIKHAM.Text=dtgLOAIKHAM[dtgLOAIKHAM.CurrentCell.RowNumber,1].ToString();
		}


	}
}	
