using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace XN
{
	
	public class DMPHUONGPHAPNHUOM : System.Windows.Forms.Form
	{
		//Lib_gpbl.Khaibao k = new Lib_gpbl.Khaibao();
        private gpblib.AccessData k = new gpblib.AccessData();
		DataSet dsNhuom = new DataSet();
		private bool bUpdate;
		private System.Windows.Forms.Label lbTen;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.Label LBMa;
		private System.Windows.Forms.TextBox txtMa;
		private System.Windows.Forms.Button buttonKetthuc;
		private System.Windows.Forms.Button buttonHuy;
		private System.Windows.Forms.Button buttonBoqua;
		private System.Windows.Forms.Button buttonLuu;
		private System.Windows.Forms.Button buttonSua;
		private System.Windows.Forms.Button buttonThem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dtgDMPHUONGPHAPNHUOM;
	
		private System.ComponentModel.Container components = null;

		public DMPHUONGPHAPNHUOM()
		{			
			InitializeComponent();			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMPHUONGPHAPNHUOM));
            this.lbTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.LBMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.buttonKetthuc = new System.Windows.Forms.Button();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.buttonBoqua = new System.Windows.Forms.Button();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.dtgDMPHUONGPHAPNHUOM = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDMPHUONGPHAPNHUOM)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTen
            // 
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.Location = new System.Drawing.Point(127, 9);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(133, 22);
            this.lbTen.TabIndex = 12;
            this.lbTen.Text = "Tên phương pháp nhuộm";
            this.lbTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTen.Enabled = false;
            this.txtTen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(256, 8);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(259, 21);
            this.txtTen.TabIndex = 2;
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // LBMa
            // 
            this.LBMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBMa.Location = new System.Drawing.Point(9, 9);
            this.LBMa.Name = "LBMa";
            this.LBMa.Size = new System.Drawing.Size(53, 22);
            this.LBMa.TabIndex = 10;
            this.LBMa.Text = "Mã PPN :";
            this.LBMa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa
            // 
            this.txtMa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMa.Enabled = false;
            this.txtMa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(57, 8);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(64, 21);
            this.txtMa.TabIndex = 1;
            this.txtMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMa_KeyDown);
            // 
            // buttonKetthuc
            // 
            this.buttonKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("buttonKetthuc.Image")));
            this.buttonKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKetthuc.Location = new System.Drawing.Point(387, 40);
            this.buttonKetthuc.Name = "buttonKetthuc";
            this.buttonKetthuc.Size = new System.Drawing.Size(68, 25);
            this.buttonKetthuc.TabIndex = 18;
            this.buttonKetthuc.Text = "Kết thúc";
            this.buttonKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKetthuc.Click += new System.EventHandler(this.buttonKetthuc_Click);
            // 
            // buttonHuy
            // 
            this.buttonHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHuy.Image = ((System.Drawing.Image)(resources.GetObject("buttonHuy.Image")));
            this.buttonHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHuy.Location = new System.Drawing.Point(325, 40);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(60, 25);
            this.buttonHuy.TabIndex = 17;
            this.buttonHuy.Text = "     Hủy";
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // buttonBoqua
            // 
            this.buttonBoqua.Enabled = false;
            this.buttonBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBoqua.Image = ((System.Drawing.Image)(resources.GetObject("buttonBoqua.Image")));
            this.buttonBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBoqua.Location = new System.Drawing.Point(263, 40);
            this.buttonBoqua.Name = "buttonBoqua";
            this.buttonBoqua.Size = new System.Drawing.Size(60, 25);
            this.buttonBoqua.TabIndex = 4;
            this.buttonBoqua.Text = "Bỏ qua";
            this.buttonBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBoqua.Click += new System.EventHandler(this.buttonBoqua_Click);
            // 
            // buttonLuu
            // 
            this.buttonLuu.Enabled = false;
            this.buttonLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLuu.Image = ((System.Drawing.Image)(resources.GetObject("buttonLuu.Image")));
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLuu.Location = new System.Drawing.Point(201, 40);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(60, 25);
            this.buttonLuu.TabIndex = 3;
            this.buttonLuu.Text = "     Lưu";
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSua.Image = ((System.Drawing.Image)(resources.GetObject("buttonSua.Image")));
            this.buttonSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSua.Location = new System.Drawing.Point(139, 40);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(60, 25);
            this.buttonSua.TabIndex = 14;
            this.buttonSua.Text = "     Sửa";
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThem.Image = ((System.Drawing.Image)(resources.GetObject("buttonThem.Image")));
            this.buttonThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonThem.Location = new System.Drawing.Point(77, 40);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(60, 25);
            this.buttonThem.TabIndex = 0;
            this.buttonThem.Text = "Thêm ";
            this.buttonThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // dtgDMPHUONGPHAPNHUOM
            // 
            this.dtgDMPHUONGPHAPNHUOM.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dtgDMPHUONGPHAPNHUOM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDMPHUONGPHAPNHUOM.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgDMPHUONGPHAPNHUOM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDMPHUONGPHAPNHUOM.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dtgDMPHUONGPHAPNHUOM.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDMPHUONGPHAPNHUOM.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgDMPHUONGPHAPNHUOM.CaptionVisible = false;
            this.dtgDMPHUONGPHAPNHUOM.DataMember = "";
            this.dtgDMPHUONGPHAPNHUOM.FlatMode = true;
            this.dtgDMPHUONGPHAPNHUOM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDMPHUONGPHAPNHUOM.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgDMPHUONGPHAPNHUOM.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dtgDMPHUONGPHAPNHUOM.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dtgDMPHUONGPHAPNHUOM.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dtgDMPHUONGPHAPNHUOM.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDMPHUONGPHAPNHUOM.LinkColor = System.Drawing.Color.Teal;
            this.dtgDMPHUONGPHAPNHUOM.Location = new System.Drawing.Point(4, 2);
            this.dtgDMPHUONGPHAPNHUOM.Name = "dtgDMPHUONGPHAPNHUOM";
            this.dtgDMPHUONGPHAPNHUOM.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dtgDMPHUONGPHAPNHUOM.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgDMPHUONGPHAPNHUOM.ReadOnly = true;
            this.dtgDMPHUONGPHAPNHUOM.RowHeaderWidth = 10;
            this.dtgDMPHUONGPHAPNHUOM.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dtgDMPHUONGPHAPNHUOM.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDMPHUONGPHAPNHUOM.Size = new System.Drawing.Size(521, 262);
            this.dtgDMPHUONGPHAPNHUOM.TabIndex = 33;
            this.dtgDMPHUONGPHAPNHUOM.CurrentCellChanged += new System.EventHandler(this.dtgDMPHUONGPHAPNHUOM_CurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.lbTen);
            this.panel1.Controls.Add(this.buttonHuy);
            this.panel1.Controls.Add(this.buttonThem);
            this.panel1.Controls.Add(this.txtMa);
            this.panel1.Controls.Add(this.buttonLuu);
            this.panel1.Controls.Add(this.buttonSua);
            this.panel1.Controls.Add(this.LBMa);
            this.panel1.Controls.Add(this.buttonBoqua);
            this.panel1.Controls.Add(this.buttonKetthuc);
            this.panel1.Location = new System.Drawing.Point(2, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 74);
            this.panel1.TabIndex = 34;
            // 
            // DMPHUONGPHAPNHUOM
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgDMPHUONGPHAPNHUOM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMPHUONGPHAPNHUOM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DM PHƯƠNG PHÁP NHUỘM (HOÁ MÔ MIỄN DỊCH)";
            this.Load += new System.EventHandler(this.DMPHUONGPHAPNHUOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDMPHUONGPHAPNHUOM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void DMPHUONGPHAPNHUOM_Load(object sender, System.EventArgs e)
		{
			ShowGrid();
			LoadGrid_Style();
			First_Text();
		}

		public void ShowGrid()
		{
			dsNhuom= k.get_data("select * from "+k.user+".gpb_hmmd order by mahmmd");
			dtgDMPHUONGPHAPNHUOM.DataSource = dsNhuom.Tables[0];
		}
		public void LoadGrid_Style()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName=dsNhuom.Tables[0].TableName;
			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.MidnightBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.RowHeaderWidth=20;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.ReadOnly=true;

			DataGridTextBoxColumn c0=new DataGridTextBoxColumn();
			c0.MappingName="mahmmd";
			c0.HeaderText="Mã HMMD";
			c0.Width=110;
			tbs.GridColumnStyles.Add(c0);
			dtgDMPHUONGPHAPNHUOM.TableStyles.Add(tbs);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="tenhmmd";
			c1.HeaderText="Tên HMMD";
			c1.Width=370;
			tbs.GridColumnStyles.Add(c1);
			dtgDMPHUONGPHAPNHUOM.TableStyles.Add(tbs);
			
		}

		private void buttonKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void buttonThem_Click(object sender, System.EventArgs e)
		{
			bUpdate=true;
			clear_text();
			enable_text(true);
			Enable_Button(false);
			txtMa.Focus();
		}

		private void Enable_Button(bool ena)
		{
			buttonThem.Enabled=ena;
			buttonSua.Enabled =ena;
            buttonLuu.Enabled=!ena;
			buttonBoqua.Enabled=!ena;
			buttonHuy.Enabled=ena;
			buttonKetthuc.Enabled=ena;
		}

		private void clear_text()
		{
			txtMa.Clear();
			txtTen.Clear();
		}

		private void enable_text(bool ena)
		{
			txtMa.Enabled=ena;
			txtTen.Enabled=ena;
		}

		private void buttonLuu_Click(object sender, System.EventArgs e)
		{
			if(!Kiemtra()) return;
			string sql = "select mahmmd from "+k.user+".gpb_hmmd";
			if(bUpdate)
			{
				if(k.Kiemtratrungma(sql,txtMa.Text.ToString().Trim()))
				{
					MessageBox.Show("Mã hoá mô miễn dịch này đã tồn tại!","Chú ý");
					txtMa.Focus();
					return;
				}			
			}
			if(!k.updgpb_dmhmmd(txtMa.Text.Trim(),txtTen.Text.Trim()))
			{
				MessageBox.Show("Không cập nhật!",LibMedi.AccessData.Msg);
				buttonBoqua.Focus();
				return;
			}
			ShowGrid();
			enable_text(false);
			Enable_Button(true);
			buttonThem.Focus();			
		}	

		private bool Kiemtra()
		{
			if(txtMa.TextLength==0)
			{
				MessageBox.Show("Nhập mã HMMD","Thông báo");
				txtMa.Focus();
				return false;
			}
			if(txtTen.TextLength==0)
			{
				MessageBox.Show("Nhập tên HMMD","Thông báo");
				txtTen.Focus();
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

		public void First_Text()
		{
			txtMa.Text=dtgDMPHUONGPHAPNHUOM[0,0].ToString();
			txtTen.Text=dtgDMPHUONGPHAPNHUOM[0,1].ToString();
		}		

		private void buttonHuy_Click(object sender, System.EventArgs e)
		{
			if(dtgDMPHUONGPHAPNHUOM.VisibleRowCount != 0)
			{
				if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?","Chú ý",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    k.execute_data("delete from " + k.user + ".gpb_hmmd where mahmmd=" + txtMa.Text + "");
					ShowGrid();
					First_Text();
					buttonThem.Focus();
				}
			}
		}

		private void dtgDMPHUONGPHAPNHUOM_CurrentCellChanged(object sender, System.EventArgs e)
		{
			txtMa.Text=dtgDMPHUONGPHAPNHUOM[dtgDMPHUONGPHAPNHUOM.CurrentRowIndex,0].ToString();
			txtTen.Text=dtgDMPHUONGPHAPNHUOM[dtgDMPHUONGPHAPNHUOM.CurrentRowIndex,1].ToString();
		}

		private void buttonSua_Click(object sender, System.EventArgs e)
		{
			bUpdate=false;
			Enable_Button(false);
			enable_text(true);
			txtMa.Enabled=false;
			txtTen.Focus();
		}

		private void buttonBoqua_Click(object sender, System.EventArgs e)
		{
			clear_text();
			enable_text(false);
			Enable_Button(true);
			buttonThem.Focus();
		}

		private void dtgDMPHUONGPHAPNHUOM_DoubleClick(object sender, System.EventArgs e)
		{
			
		}

		private void txtMa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");			
		}

		private void txtTen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");

		}

		private void dtgDMPHUONGPHAPNHUOM_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Delete) 
			{				
				if(dtgDMPHUONGPHAPNHUOM.VisibleRowCount != 0)
				{
					if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?","Chú ý",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
                        k.execute_data("Delete  From " + k.user + ".GPB_HMMD Where MaHMMD = " + txtMa.Text + "");
						ShowGrid();
						First_Text();
					}
				}
			}
		}	


	}
}
