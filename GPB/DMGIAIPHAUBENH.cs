using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace XN
{	
	public class DMGIAIPHAUBENH : System.Windows.Forms.Form
	{
		private DataSet dsGpb= new DataSet();
		//Lib_gpbl.Khaibao  k = new Lib_gpbl.Khaibao();
        private gpblib.AccessData k = new gpblib.AccessData();
        private string user;
		private System.Windows.Forms.Button buttonKetthuc;
		private System.Windows.Forms.Button buttonHuy;
		private System.Windows.Forms.Button buttonBoqua;
		private System.Windows.Forms.Button buttonLuu;
		private System.Windows.Forms.Button buttonSua;
		private System.Windows.Forms.Button buttonThem;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.Label lbTenGPB;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtTenGPB;
		private System.Windows.Forms.Label LBMaGPB;
		private System.Windows.Forms.TextBox txtMaGPB;
		private System.Windows.Forms.DataGrid dtgGIAIPHAUBENH;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox chkdung;
		private bool bUpdate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox nhanxet;
		private System.Windows.Forms.TextBox chandoan;
		
		private System.ComponentModel.Container components = null;

		public DMGIAIPHAUBENH()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMGIAIPHAUBENH));
            this.buttonKetthuc = new System.Windows.Forms.Button();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.buttonBoqua = new System.Windows.Forms.Button();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbTenGPB = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTenGPB = new System.Windows.Forms.TextBox();
            this.LBMaGPB = new System.Windows.Forms.Label();
            this.txtMaGPB = new System.Windows.Forms.TextBox();
            this.dtgGIAIPHAUBENH = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nhanxet = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.chkdung = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGIAIPHAUBENH)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKetthuc
            // 
            this.buttonKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("buttonKetthuc.Image")));
            this.buttonKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKetthuc.Location = new System.Drawing.Point(511, 144);
            this.buttonKetthuc.Name = "buttonKetthuc";
            this.buttonKetthuc.Size = new System.Drawing.Size(68, 25);
            this.buttonKetthuc.TabIndex = 9;
            this.buttonKetthuc.Text = "Kết thúc";
            this.buttonKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKetthuc.Click += new System.EventHandler(this.buttonKetthuc_Click);
            // 
            // buttonHuy
            // 
            this.buttonHuy.Image = ((System.Drawing.Image)(resources.GetObject("buttonHuy.Image")));
            this.buttonHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHuy.Location = new System.Drawing.Point(449, 144);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(60, 25);
            this.buttonHuy.TabIndex = 8;
            this.buttonHuy.Text = "     Hủy";
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // buttonBoqua
            // 
            this.buttonBoqua.Enabled = false;
            this.buttonBoqua.Image = ((System.Drawing.Image)(resources.GetObject("buttonBoqua.Image")));
            this.buttonBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBoqua.Location = new System.Drawing.Point(387, 144);
            this.buttonBoqua.Name = "buttonBoqua";
            this.buttonBoqua.Size = new System.Drawing.Size(60, 25);
            this.buttonBoqua.TabIndex = 7;
            this.buttonBoqua.Text = "Bỏ qua";
            this.buttonBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBoqua.Click += new System.EventHandler(this.buttonBoqua_Click);
            // 
            // buttonLuu
            // 
            this.buttonLuu.Enabled = false;
            this.buttonLuu.Image = ((System.Drawing.Image)(resources.GetObject("buttonLuu.Image")));
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLuu.Location = new System.Drawing.Point(325, 144);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(60, 25);
            this.buttonLuu.TabIndex = 6;
            this.buttonLuu.Text = "    Lưu";
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Image = ((System.Drawing.Image)(resources.GetObject("buttonSua.Image")));
            this.buttonSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSua.Location = new System.Drawing.Point(263, 144);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(60, 25);
            this.buttonSua.TabIndex = 5;
            this.buttonSua.Text = "     Sửa";
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Image = ((System.Drawing.Image)(resources.GetObject("buttonThem.Image")));
            this.buttonThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonThem.Location = new System.Drawing.Point(201, 144);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(60, 25);
            this.buttonThem.TabIndex = 4;
            this.buttonThem.Text = "Thêm ";
            this.buttonThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // lbName
            // 
            this.lbName.Location = new System.Drawing.Point(445, 8);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(41, 22);
            this.lbName.TabIndex = 30;
            this.lbName.Text = "Name :";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTenGPB
            // 
            this.lbTenGPB.Location = new System.Drawing.Point(144, 9);
            this.lbTenGPB.Name = "lbTenGPB";
            this.lbTenGPB.Size = new System.Drawing.Size(58, 22);
            this.lbTenGPB.TabIndex = 29;
            this.lbTenGPB.Text = "Tên GPB :";
            this.lbTenGPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(485, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(229, 22);
            this.txtName.TabIndex = 2;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtTenGPB
            // 
            this.txtTenGPB.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTenGPB.Enabled = false;
            this.txtTenGPB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenGPB.Location = new System.Drawing.Point(198, 8);
            this.txtTenGPB.Name = "txtTenGPB";
            this.txtTenGPB.Size = new System.Drawing.Size(241, 22);
            this.txtTenGPB.TabIndex = 1;
            this.txtTenGPB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenGPB_KeyDown);
            // 
            // LBMaGPB
            // 
            this.LBMaGPB.Location = new System.Drawing.Point(8, 8);
            this.LBMaGPB.Name = "LBMaGPB";
            this.LBMaGPB.Size = new System.Drawing.Size(67, 22);
            this.LBMaGPB.TabIndex = 26;
            this.LBMaGPB.Text = "Mã GPB :";
            this.LBMaGPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaGPB
            // 
            this.txtMaGPB.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMaGPB.Enabled = false;
            this.txtMaGPB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGPB.Location = new System.Drawing.Point(64, 8);
            this.txtMaGPB.MaxLength = 6;
            this.txtMaGPB.Name = "txtMaGPB";
            this.txtMaGPB.Size = new System.Drawing.Size(80, 21);
            this.txtMaGPB.TabIndex = 0;
            this.txtMaGPB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaGPB_KeyDown);
            // 
            // dtgGIAIPHAUBENH
            // 
            this.dtgGIAIPHAUBENH.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dtgGIAIPHAUBENH.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtgGIAIPHAUBENH.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgGIAIPHAUBENH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgGIAIPHAUBENH.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dtgGIAIPHAUBENH.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgGIAIPHAUBENH.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgGIAIPHAUBENH.CaptionVisible = false;
            this.dtgGIAIPHAUBENH.DataMember = "";
            this.dtgGIAIPHAUBENH.FlatMode = true;
            this.dtgGIAIPHAUBENH.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgGIAIPHAUBENH.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgGIAIPHAUBENH.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dtgGIAIPHAUBENH.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dtgGIAIPHAUBENH.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dtgGIAIPHAUBENH.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgGIAIPHAUBENH.LinkColor = System.Drawing.Color.Teal;
            this.dtgGIAIPHAUBENH.Location = new System.Drawing.Point(6, 4);
            this.dtgGIAIPHAUBENH.Name = "dtgGIAIPHAUBENH";
            this.dtgGIAIPHAUBENH.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dtgGIAIPHAUBENH.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgGIAIPHAUBENH.ReadOnly = true;
            this.dtgGIAIPHAUBENH.RowHeaderWidth = 10;
            this.dtgGIAIPHAUBENH.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dtgGIAIPHAUBENH.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgGIAIPHAUBENH.Size = new System.Drawing.Size(780, 420);
            this.dtgGIAIPHAUBENH.TabIndex = 1;
            this.dtgGIAIPHAUBENH.CurrentCellChanged += new System.EventHandler(this.dtgGIAIPHAUBENH_CurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMaGPB);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.LBMaGPB);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.txtTenGPB);
            this.panel1.Controls.Add(this.buttonSua);
            this.panel1.Controls.Add(this.buttonHuy);
            this.panel1.Controls.Add(this.buttonThem);
            this.panel1.Controls.Add(this.buttonLuu);
            this.panel1.Controls.Add(this.buttonKetthuc);
            this.panel1.Controls.Add(this.buttonBoqua);
            this.panel1.Controls.Add(this.lbTenGPB);
            this.panel1.Controls.Add(this.chkdung);
            this.panel1.Location = new System.Drawing.Point(4, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 184);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nhanxet);
            this.groupBox1.Controls.Add(this.chandoan);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(2, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 97);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mẫu nhận xét - chẩn đoán giải phẫu bệnh lý";
            // 
            // nhanxet
            // 
            this.nhanxet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanxet.Enabled = false;
            this.nhanxet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanxet.Location = new System.Drawing.Point(38, 18);
            this.nhanxet.Multiline = true;
            this.nhanxet.Name = "nhanxet";
            this.nhanxet.Size = new System.Drawing.Size(368, 72);
            this.nhanxet.TabIndex = 15;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(408, 18);
            this.chandoan.Multiline = true;
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(360, 72);
            this.chandoan.TabIndex = 16;
            // 
            // chkdung
            // 
            this.chkdung.Enabled = false;
            this.chkdung.Location = new System.Drawing.Point(718, 8);
            this.chkdung.Name = "chkdung";
            this.chkdung.Size = new System.Drawing.Size(92, 24);
            this.chkdung.TabIndex = 3;
            this.chkdung.Text = "Sử dụng";
            this.chkdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkdung_KeyDown);
            // 
            // DMGIAIPHAUBENH
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 607);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgGIAIPHAUBENH);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMGIAIPHAUBENH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DM GIẢI PHẪU BỆNH";
            this.Load += new System.EventHandler(this.DMGIAIPHAUBENH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGIAIPHAUBENH)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void DMGIAIPHAUBENH_Load(object sender, System.EventArgs e)
		{
            user = k.user;
			ShowGrid();
			LoadGridStyle();
			Text_First();
		}

		private void LoadGridStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsGpb.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;

			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "manhomgpb";
			TextCol.HeaderText = "Mã nhóm GPB";
			TextCol.Width = 80;
			//TextCol.Alignment=HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol);
			dtgGIAIPHAUBENH.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "magpb";
			TextCol.HeaderText = "Mã GPB";
			TextCol.Width = 80;
			//TextCol.Alignment=HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol);
			dtgGIAIPHAUBENH.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tengpb";
			TextCol.HeaderText = "Tên GPB";
			TextCol.Width = 310;
			ts.GridColumnStyles.Add(TextCol);
			dtgGIAIPHAUBENH.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "name";
			TextCol.HeaderText = "Name";
			TextCol.Width = 275;
			ts.GridColumnStyles.Add(TextCol);
			dtgGIAIPHAUBENH.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sudung";
			TextCol.HeaderText = "Hiện dùng";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dtgGIAIPHAUBENH.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhanxet";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dtgGIAIPHAUBENH.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dtgGIAIPHAUBENH.TableStyles.Add(ts);
		}	

		private void ShowGrid()
		{			
			dsGpb= k.get_data("select * from "+user+".gpb_gpb"); 
			dtgGIAIPHAUBENH.DataSource = dsGpb.Tables[0];
		}

		private void buttonKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void buttonThem_Click(object sender, System.EventArgs e)
		{
			bUpdate=false;
			Clear_Text();
			enable_text(true);
			enable_button(false);
			txtMaGPB.Focus();
		}

		private void enable_text(bool ena)
		{
			txtMaGPB.Enabled = ena;
			txtName.Enabled= ena;
			txtTenGPB.Enabled= ena;
			nhanxet.Enabled=ena;
			chandoan.Enabled=ena;
			chkdung.Enabled=ena;
		}

		private void Clear_Text()
		{
			txtMaGPB.Clear();
			txtName.Clear();
			txtTenGPB.Clear();
			nhanxet.Clear();chandoan.Clear();
			chkdung.Checked=false;
		}

		private void enable_button(bool ena)
		{
			buttonBoqua.Enabled =!ena;
			buttonHuy.Enabled=ena;
			buttonLuu.Enabled=!ena;
			buttonThem.Enabled=ena;
			buttonSua.Enabled=ena;
			buttonKetthuc.Enabled=ena;
		}

		private void buttonLuu_Click(object sender, System.EventArgs e)
		{
			if(!Kiemtra())return;
			
			if(!bUpdate)
			{
				if(k.get_data("select magpb,tengpb from "+user+".gpb_gpb where magpb='"+txtMaGPB.Text.Trim()+"'").Tables[0].Rows.Count>0)
				{
					MessageBox.Show("Mã giải phẫu bệnh này đã tồn tại!",LibMedi.AccessData.Msg);
					txtMaGPB.Focus();
					return;
				}
			}

			if(!k.updgpb_dmgpb(txtMaGPB.Text.Substring(0,4).ToString(),txtMaGPB.Text,txtTenGPB.Text,txtName.Text,chkdung.Checked ? 1 :0,nhanxet.Text.Trim(),chandoan.Text.Trim()))
			{
				MessageBox.Show ("Không cập nhật được thông tin giải phẫu bệnh!",LibMedi.AccessData.Msg,MessageBoxButtons.OK,MessageBoxIcon.Information);
				buttonBoqua.Focus();
				return;
			}
			
			ShowGrid();
			enable_button(true);
			enable_text(false);
			buttonThem.Focus();
		}

		private bool Kiemtra()
		{			
			if(txtMaGPB.Text== "")
			{
				MessageBox.Show("Chưa nhập mã GPB !",LibMedi.AccessData.Msg);
				txtMaGPB.Focus();				
				return false;
			}
			
			if(txtTenGPB.Text =="")
			{
				MessageBox.Show("Chưa nhập tên GPB !",LibMedi.AccessData.Msg);
				txtTenGPB.Focus();				
				return false;
			}
			
			if(txtName.Text=="")
			{
				MessageBox.Show("Chưa nhập Name GPB !",LibMedi.AccessData.Msg);
				txtName.Focus();				
				return false;
			}
            if (txtMaGPB.Text.Trim().Length < 5)
            {
                MessageBox.Show("Chiều dài mã GPB lớn hơn 4 ký tự !", LibMedi.AccessData.Msg);
                txtMaGPB.Focus();
                return false;
            }
			return true;
		}		

		private void dtgGIAIPHAUBENH_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtMaGPB.Text=dtgGIAIPHAUBENH[dtgGIAIPHAUBENH.CurrentRowIndex,1].ToString();
				txtTenGPB.Text=dtgGIAIPHAUBENH[dtgGIAIPHAUBENH.CurrentRowIndex,2].ToString();
				txtName.Text=dtgGIAIPHAUBENH[dtgGIAIPHAUBENH.CurrentRowIndex,3].ToString(); 
				chkdung.Checked=(dtgGIAIPHAUBENH[dtgGIAIPHAUBENH.CurrentRowIndex,4].ToString()=="1") ? true : false;
				nhanxet.Text=dtgGIAIPHAUBENH[dtgGIAIPHAUBENH.CurrentRowIndex,5].ToString(); 
				chandoan.Text=dtgGIAIPHAUBENH[dtgGIAIPHAUBENH.CurrentRowIndex,6].ToString(); 
			}
			catch{}
		}

		private void Text_First()
		{
			txtMaGPB.Text = dtgGIAIPHAUBENH[0,1].ToString();
			txtTenGPB.Text = dtgGIAIPHAUBENH[0,2].ToString(); 
			txtName.Text = dtgGIAIPHAUBENH[0,3].ToString();
			chkdung.Checked=(dtgGIAIPHAUBENH[0,4].ToString()=="1") ? true : false;
		}

		private void buttonHuy_Click(object sender, System.EventArgs e)
		{
			if(dtgGIAIPHAUBENH.VisibleRowCount != 0)
			{
				if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?","Chú ý",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
				{
                    k.execute_data("delete from " + user + ".gpb_gpb where magpb='" + txtMaGPB.Text.ToString() + "'");
					ShowGrid();
				}
			}
			else
			{
				MessageBox.Show("Không còn dữ liệu !", "Chú ý");
			}

		}

		private void buttonSua_Click(object sender, System.EventArgs e)
		{
			bUpdate=true;
			enable_text(true);
			enable_button(false);
			txtMaGPB.Enabled=false;
			txtTenGPB.Focus();
		}

		private void txtMaGPB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter )  SendKeys.Send("{Tab}");
		}

		private void txtTenGPB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter )  SendKeys.Send("{Tab}");
		}

		private void txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter )  SendKeys.Send("{Tab}");
		}

		private void buttonBoqua_Click(object sender, System.EventArgs e)
		{
			enable_text(false);
			enable_button(true);
			buttonThem.Focus();
		}
		private void dtgGIAIPHAUBENH_DoubleClick(object sender, System.EventArgs e)
		{
			txtMaGPB.Enabled=false;
			txtTenGPB.Focus();
		}

		private void chkdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter )  SendKeys.Send("{Tab}");
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	}
}
