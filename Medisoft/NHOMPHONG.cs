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
	/// Summary description for NHOMPHONG.
	/// </summary>
	public class NHOMPHONG : System.Windows.Forms.Form
	{
        Language lan = new Language();
		Lib_LH.Access_Data k= new Lib_LH.Access_Data();
		DataSet Ds;
		private System.Windows.Forms.Button luu;
		private System.Windows.Forms.TextBox manhom;
		private System.Windows.Forms.TextBox tennhom;
		private System.Windows.Forms.Button ketthuc;
		private System.Windows.Forms.Button huy;
		private System.Windows.Forms.Button boqua;
		private System.Windows.Forms.Button sua;
		private System.Windows.Forms.Button them;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbMaLOAIKHAM;
		private System.Windows.Forms.DataGrid dtg;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NHOMPHONG()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NHOMPHONG));
			this.luu = new System.Windows.Forms.Button();
			this.manhom = new System.Windows.Forms.TextBox();
			this.tennhom = new System.Windows.Forms.TextBox();
			this.ketthuc = new System.Windows.Forms.Button();
			this.huy = new System.Windows.Forms.Button();
			this.boqua = new System.Windows.Forms.Button();
			this.sua = new System.Windows.Forms.Button();
			this.them = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lbMaLOAIKHAM = new System.Windows.Forms.Label();
			this.dtg = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
			this.SuspendLayout();
			// 
			// luu
			// 
			this.luu.Enabled = false;
			this.luu.Image = ((System.Drawing.Bitmap)(resources.GetObject("luu.Image")));
			this.luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.luu.Location = new System.Drawing.Point(192, 288);
			this.luu.Name = "luu";
			this.luu.Size = new System.Drawing.Size(64, 32);
			this.luu.TabIndex = 4;
			this.luu.Text = "     Lưu";
			this.luu.Click += new System.EventHandler(this.luu_Click);
			// 
			// manhom
			// 
			this.manhom.BackColor = System.Drawing.SystemColors.HighlightText;
			this.manhom.Location = new System.Drawing.Point(93, 248);
			this.manhom.Name = "manhom";
			this.manhom.Size = new System.Drawing.Size(72, 20);
			this.manhom.TabIndex = 1;
			this.manhom.Text = "";
			this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manhom_KeyDown);
			// 
			// tennhom
			// 
			this.tennhom.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tennhom.Location = new System.Drawing.Point(256, 248);
			this.tennhom.Name = "tennhom";
			this.tennhom.Size = new System.Drawing.Size(200, 20);
			this.tennhom.TabIndex = 2;
			this.tennhom.Text = "";
			this.tennhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhom_KeyDown);
			// 
			// ketthuc
			// 
			this.ketthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("ketthuc.Image")));
			this.ketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ketthuc.Location = new System.Drawing.Point(392, 288);
			this.ketthuc.Name = "ketthuc";
			this.ketthuc.Size = new System.Drawing.Size(76, 32);
			this.ketthuc.TabIndex = 7;
			this.ketthuc.Text = "Kết thúc";
			this.ketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ketthuc.Click += new System.EventHandler(this.ketthuc_Click);
			// 
			// huy
			// 
			this.huy.Image = ((System.Drawing.Bitmap)(resources.GetObject("huy.Image")));
			this.huy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.huy.Location = new System.Drawing.Point(328, 288);
			this.huy.Name = "huy";
			this.huy.Size = new System.Drawing.Size(64, 32);
			this.huy.TabIndex = 6;
			this.huy.Text = "    Huỷ";
			this.huy.Click += new System.EventHandler(this.huy_Click);
			// 
			// boqua
			// 
			this.boqua.Enabled = false;
			this.boqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("boqua.Image")));
			this.boqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.boqua.Location = new System.Drawing.Point(256, 288);
			this.boqua.Name = "boqua";
			this.boqua.Size = new System.Drawing.Size(72, 32);
			this.boqua.TabIndex = 5;
			this.boqua.Text = "Bỏ qua";
			this.boqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.boqua.Click += new System.EventHandler(this.boqua_Click);
			// 
			// sua
			// 
			this.sua.Image = ((System.Drawing.Bitmap)(resources.GetObject("sua.Image")));
			this.sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.sua.Location = new System.Drawing.Point(128, 288);
			this.sua.Name = "sua";
			this.sua.Size = new System.Drawing.Size(64, 32);
			this.sua.TabIndex = 3;
			this.sua.Text = "     Sửa";
			this.sua.Click += new System.EventHandler(this.sua_Click);
			// 
			// them
			// 
			this.them.Image = ((System.Drawing.Bitmap)(resources.GetObject("them.Image")));
			this.them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.them.Location = new System.Drawing.Point(64, 288);
			this.them.Name = "them";
			this.them.Size = new System.Drawing.Size(64, 32);
			this.them.TabIndex = 0;
			this.them.Text = "Thêm ";
			this.them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.them.Click += new System.EventHandler(this.them_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(200, 252);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 74;
			this.label2.Text = "Tên Nhóm";
			// 
			// lbMaLOAIKHAM
			// 
			this.lbMaLOAIKHAM.Location = new System.Drawing.Point(40, 252);
			this.lbMaLOAIKHAM.Name = "lbMaLOAIKHAM";
			this.lbMaLOAIKHAM.Size = new System.Drawing.Size(84, 16);
			this.lbMaLOAIKHAM.TabIndex = 73;
			this.lbMaLOAIKHAM.Text = "Mã Nhóm";
			// 
			// dtg
			// 
			this.dtg.AllowSorting = false;
			this.dtg.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dtg.BackColor = System.Drawing.Color.White;
			this.dtg.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dtg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtg.CaptionVisible = false;
			this.dtg.DataMember = "";
			this.dtg.FlatMode = true;
			this.dtg.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtg.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.dtg.HeaderBackColor = System.Drawing.Color.DarkSlateBlue;
			this.dtg.HeaderForeColor = System.Drawing.Color.Yellow;
			this.dtg.Location = new System.Drawing.Point(8, 8);
			this.dtg.Name = "dtg";
			this.dtg.ReadOnly = true;
			this.dtg.RowHeaderWidth = 20;
			this.dtg.SelectionBackColor = System.Drawing.Color.Red;
			this.dtg.SelectionForeColor = System.Drawing.Color.White;
			this.dtg.Size = new System.Drawing.Size(496, 232);
			this.dtg.TabIndex = 75;
			this.dtg.CurrentCellChanged += new System.EventHandler(this.dtg_CurrentCellChanged_1);
			// 
			// NHOMPHONG
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 333);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dtg,
																		  this.luu,
																		  this.manhom,
																		  this.tennhom,
																		  this.ketthuc,
																		  this.huy,
																		  this.boqua,
																		  this.sua,
																		  this.them,
																		  this.label2,
																		  this.lbMaLOAIKHAM});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(520, 360);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(520, 360);
			this.Name = "NHOMPHONG";
			this.Text = "Danh Mục Nhóm Phòng";
			this.Load += new System.EventHandler(this.NHOMPHONG_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void NHOMPHONG_Load(object sender, System.EventArgs e)
		{
			EnaText(false);
			EnaBut(false);
			Load_data();
			
		}

		private void EnaText(bool ena)
		{
			manhom.Enabled=ena;
			tennhom.Enabled=ena;
		}

		private void EnaBut(bool ena)
		{
			huy.Enabled=!ena;
			luu.Enabled=ena;
			boqua.Enabled=ena;
			sua.Enabled=!ena;
			ketthuc.Enabled=!ena;
			them.Enabled=!ena;
			ketthuc.Enabled=!ena;
		}
		
		private void Load_data()
		{
			Ds = k.get_data("Select * from lh_nhomphong");
			dtg.DataSource=Ds.Tables[0];
			LoadGridStyle();
		}

		private void ketthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void them_Click(object sender, System.EventArgs e)
		{
			manhom.Text="";
			tennhom.Text="";
			EnaBut(true);
			EnaText(true);
			manhom.Focus();
		}

		private void boqua_Click(object sender, System.EventArgs e)
		{
			EnaBut(false);
			EnaText(false);
			huy.Enabled=true;
		}

		private void luu_Click(object sender, System.EventArgs e)
		{
			int i;
			if(manhom.TextLength==0)
			{
				MessageBox.Show("Nhập mã nhóm","Thông Báo");
				manhom.Focus();
				return;
			}
			if(tennhom.TextLength==0)
			{
				MessageBox.Show("Nhập tên nhóm","Thông Báo");
				tennhom.Focus();
				return;
			}
			try
			{
				i= int.Parse(manhom.Text.ToString());
			}
			catch
			{
				MessageBox.Show("Nhập mã nhóm bằng ký tự số","Thông Báo");
				manhom.Focus();
				return;
			}
			k.ins_nhomphong(i,tennhom.Text.ToString());
			Load_data();
			EnaBut(false);
			EnaText(false);
			them.Focus();
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
			c0.MappingName="MANHOM";
			c0.HeaderText="Mã Nhóm Phòng";
			c0.Width=120;
			c0.NullText="";			
			tbs.GridColumnStyles.Add(c0);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="TENNHOM";
			c1.HeaderText="Tên Nhóm Phòng";
			c1.NullText="";
			c1.Width=350;
			tbs.GridColumnStyles.Add(c1);
            
			dtg.TableStyles.Clear();
			dtg.TableStyles.Add(tbs);
		}

		private void manhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void tennhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void huy_Click(object sender, System.EventArgs e)
		{
			if(manhom.TextLength >0)
			{
				DataSet ds = k.get_data("select loai from btdkp_bv");
				DataRow[] r=ds.Tables[0].Select("loai='"+manhom.Text+"'");
				if(r.Length>0)
				{
					MessageBox.Show("Đã có phòng thuộc nhóm phòng này. Không huỷ được","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
				else
				{
					if(MessageBox.Show("Bạn muốn huỷ mẩu tin này ?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						k.Excute_data("delete from lh_nhomphong where manhom='"+manhom.Text.ToString()+"' ");
						Load_data();
					}
				}
			}
		}

		private void sua_Click(object sender, System.EventArgs e)
		{
			tennhom.Enabled=true;
			manhom.Enabled=false;
			them.Enabled=false;
			ketthuc.Enabled=false;
			luu.Enabled=true;
			boqua.Enabled=true;
			huy.Enabled=false;
			sua.Enabled=false;
		}			

		private void dtg_CurrentCellChanged_1(object sender, System.EventArgs e)
		{
			manhom.Text= dtg[dtg.CurrentCell.RowNumber,0].ToString();
			tennhom.Text= dtg[dtg.CurrentCell.RowNumber,1].ToString();
		}

	}
}
