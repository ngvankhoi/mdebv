using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace XN
{	
	public class DMVTST : System.Windows.Forms.Form
	{
		DataSet dsDmvtst= new DataSet();
        private gpblib.AccessData k = new gpblib.AccessData();
		private bool bUpdate;
        private string user;
		private System.Windows.Forms.Button buttonKetthuc;
		private System.Windows.Forms.Button buttonHuy;
		private System.Windows.Forms.Button buttonBoqua;
		private System.Windows.Forms.Button buttonLuu;
		private System.Windows.Forms.Button buttonSua;
		private System.Windows.Forms.Button buttonThem;
		private System.Windows.Forms.TextBox txtMa;
		private System.Windows.Forms.Label LBMa;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lbTen;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.Label lbNhom;
		private System.Windows.Forms.ComboBox cmbNhom;
		private System.Windows.Forms.TextBox txtMa1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dtgDMVITRISINHTHIET;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hadt;
		private System.Windows.Forms.TextBox havt;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.ComponentModel.Container components = null;

		public DMVTST()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMVTST));
            this.txtMa = new System.Windows.Forms.TextBox();
            this.LBMa = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbTen = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbNhom = new System.Windows.Forms.Label();
            this.buttonKetthuc = new System.Windows.Forms.Button();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.buttonBoqua = new System.Windows.Forms.Button();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.cmbNhom = new System.Windows.Forms.ComboBox();
            this.txtMa1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtgDMVITRISINHTHIET = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hadt = new System.Windows.Forms.TextBox();
            this.havt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDMVITRISINHTHIET)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMa
            // 
            this.txtMa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa.Enabled = false;
            this.txtMa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(179, 8);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(65, 21);
            this.txtMa.TabIndex = 2;
            this.txtMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMa_KeyDown);
            // 
            // LBMa
            // 
            this.LBMa.Location = new System.Drawing.Point(121, 8);
            this.LBMa.Name = "LBMa";
            this.LBMa.Size = new System.Drawing.Size(40, 22);
            this.LBMa.TabIndex = 12;
            this.LBMa.Text = "Mã :";
            this.LBMa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTen.Enabled = false;
            this.txtTen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(280, 8);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(224, 21);
            this.txtTen.TabIndex = 3;
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(549, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(233, 21);
            this.txtName.TabIndex = 4;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // lbTen
            // 
            this.lbTen.Location = new System.Drawing.Point(248, 8);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(44, 22);
            this.lbTen.TabIndex = 13;
            this.lbTen.Text = "Tên :";
            this.lbTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbName
            // 
            this.lbName.Location = new System.Drawing.Point(509, 8);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(42, 22);
            this.lbName.TabIndex = 14;
            this.lbName.Text = "Name :";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNhom
            // 
            this.lbNhom.Location = new System.Drawing.Point(8, 8);
            this.lbNhom.Name = "lbNhom";
            this.lbNhom.Size = new System.Drawing.Size(41, 22);
            this.lbNhom.TabIndex = 11;
            this.lbNhom.Text = "Nhóm :";
            this.lbNhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonKetthuc
            // 
            this.buttonKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("buttonKetthuc.Image")));
            this.buttonKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKetthuc.Location = new System.Drawing.Point(514, 149);
            this.buttonKetthuc.Name = "buttonKetthuc";
            this.buttonKetthuc.Size = new System.Drawing.Size(68, 25);
            this.buttonKetthuc.TabIndex = 10;
            this.buttonKetthuc.Text = "Kết thúc";
            this.buttonKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKetthuc.Click += new System.EventHandler(this.buttonKetthuc_Click);
            // 
            // buttonHuy
            // 
            this.buttonHuy.Image = ((System.Drawing.Image)(resources.GetObject("buttonHuy.Image")));
            this.buttonHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHuy.Location = new System.Drawing.Point(452, 149);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(60, 25);
            this.buttonHuy.TabIndex = 9;
            this.buttonHuy.Text = "    Hủy";
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // buttonBoqua
            // 
            this.buttonBoqua.Enabled = false;
            this.buttonBoqua.Image = ((System.Drawing.Image)(resources.GetObject("buttonBoqua.Image")));
            this.buttonBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBoqua.Location = new System.Drawing.Point(390, 149);
            this.buttonBoqua.Name = "buttonBoqua";
            this.buttonBoqua.Size = new System.Drawing.Size(60, 25);
            this.buttonBoqua.TabIndex = 8;
            this.buttonBoqua.Text = "Bỏ qua";
            this.buttonBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBoqua.Click += new System.EventHandler(this.buttonBoqua_Click);
            // 
            // buttonLuu
            // 
            this.buttonLuu.Enabled = false;
            this.buttonLuu.Image = ((System.Drawing.Image)(resources.GetObject("buttonLuu.Image")));
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLuu.Location = new System.Drawing.Point(328, 149);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(60, 25);
            this.buttonLuu.TabIndex = 7;
            this.buttonLuu.Text = "     Lưu";
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Image = ((System.Drawing.Image)(resources.GetObject("buttonSua.Image")));
            this.buttonSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSua.Location = new System.Drawing.Point(266, 149);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(60, 25);
            this.buttonSua.TabIndex = 6;
            this.buttonSua.Text = "     Sửa";
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Image = ((System.Drawing.Image)(resources.GetObject("buttonThem.Image")));
            this.buttonThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonThem.Location = new System.Drawing.Point(204, 149);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(60, 25);
            this.buttonThem.TabIndex = 5;
            this.buttonThem.Text = "     Thêm ";
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // cmbNhom
            // 
            this.cmbNhom.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhom.Enabled = false;
            this.cmbNhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhom.Location = new System.Drawing.Point(48, 8);
            this.cmbNhom.MaxDropDownItems = 15;
            this.cmbNhom.Name = "cmbNhom";
            this.cmbNhom.Size = new System.Drawing.Size(70, 21);
            this.cmbNhom.TabIndex = 0;
            this.cmbNhom.SelectedValueChanged += new System.EventHandler(this.cmbNhom_SelectedValueChanged);
            this.cmbNhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNhom_KeyDown);
            // 
            // txtMa1
            // 
            this.txtMa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMa1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa1.Enabled = false;
            this.txtMa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa1.Location = new System.Drawing.Point(146, 8);
            this.txtMa1.MaxLength = 2;
            this.txtMa1.Name = "txtMa1";
            this.txtMa1.Size = new System.Drawing.Size(31, 21);
            this.txtMa1.TabIndex = 1;
            this.txtMa1.Validated += new System.EventHandler(this.txtMa1_Validated);
            this.txtMa1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMa1_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(40, 240);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Visible = false;
            // 
            // dtgDMVITRISINHTHIET
            // 
            this.dtgDMVITRISINHTHIET.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dtgDMVITRISINHTHIET.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDMVITRISINHTHIET.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgDMVITRISINHTHIET.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDMVITRISINHTHIET.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dtgDMVITRISINHTHIET.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDMVITRISINHTHIET.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgDMVITRISINHTHIET.CaptionVisible = false;
            this.dtgDMVITRISINHTHIET.DataMember = "";
            this.dtgDMVITRISINHTHIET.FlatMode = true;
            this.dtgDMVITRISINHTHIET.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDMVITRISINHTHIET.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgDMVITRISINHTHIET.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dtgDMVITRISINHTHIET.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dtgDMVITRISINHTHIET.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dtgDMVITRISINHTHIET.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDMVITRISINHTHIET.LinkColor = System.Drawing.Color.Teal;
            this.dtgDMVITRISINHTHIET.Location = new System.Drawing.Point(4, 4);
            this.dtgDMVITRISINHTHIET.Name = "dtgDMVITRISINHTHIET";
            this.dtgDMVITRISINHTHIET.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dtgDMVITRISINHTHIET.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgDMVITRISINHTHIET.ReadOnly = true;
            this.dtgDMVITRISINHTHIET.RowHeaderWidth = 10;
            this.dtgDMVITRISINHTHIET.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dtgDMVITRISINHTHIET.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDMVITRISINHTHIET.Size = new System.Drawing.Size(786, 398);
            this.dtgDMVITRISINHTHIET.TabIndex = 1;
            this.dtgDMVITRISINHTHIET.CurrentCellChanged += new System.EventHandler(this.dtgDMVITRISINHTHIET_CurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonLuu);
            this.panel1.Controls.Add(this.buttonSua);
            this.panel1.Controls.Add(this.buttonKetthuc);
            this.panel1.Controls.Add(this.txtMa1);
            this.panel1.Controls.Add(this.buttonHuy);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.cmbNhom);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.buttonBoqua);
            this.panel1.Controls.Add(this.txtMa);
            this.panel1.Controls.Add(this.buttonThem);
            this.panel1.Controls.Add(this.lbNhom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.lbTen);
            this.panel1.Controls.Add(this.LBMa);
            this.panel1.Location = new System.Drawing.Point(4, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 181);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hadt);
            this.groupBox1.Controls.Add(this.havt);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 104);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mẫu nhận xét đại thể - vi thể";
            // 
            // hadt
            // 
            this.hadt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hadt.Enabled = false;
            this.hadt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hadt.Location = new System.Drawing.Point(38, 23);
            this.hadt.Multiline = true;
            this.hadt.Name = "hadt";
            this.hadt.Size = new System.Drawing.Size(368, 72);
            this.hadt.TabIndex = 15;
            // 
            // havt
            // 
            this.havt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.havt.Enabled = false;
            this.havt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.havt.Location = new System.Drawing.Point(408, 23);
            this.havt.Multiline = true;
            this.havt.Name = "havt";
            this.havt.Size = new System.Drawing.Size(360, 72);
            this.havt.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(408, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nhận xét vi thể :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DMVTST
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 591);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgDMVITRISINHTHIET);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMVTST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DM VỊ TRÍ SINH THIẾT";
            this.Load += new System.EventHandler(this.DMVTST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDMVITRISINHTHIET)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void DMVTST_Load(object sender, System.EventArgs e)
		{
            user = k.user;
			ShowGrid();
			cmbNhom.DisplayMember="MANHOM";
			cmbNhom.ValueMember="MANHOM";
            cmbNhom.DataSource = k.get_data("select distinct manhomvtst as manhom from " + user + ".gpb_vtst order by manhomvtst").Tables[0];
			cmbNhom.SelectedIndex=-1;
			LoadGrid_Style();
			First_Text();
		}

		public void LoadGrid_Style()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName=dsDmvtst.Tables[0].TableName;
			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.MidnightBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.RowHeaderWidth=20;
			tbs.ReadOnly=true;

			DataGridTextBoxColumn c0=new DataGridTextBoxColumn();
			c0.MappingName="MaNhomVTST";
			c0.HeaderText="Mã Nhóm VTST";
			c0.Width=100;
			tbs.GridColumnStyles.Add(c0);
			dtgDMVITRISINHTHIET.TableStyles.Add(tbs);
			
			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="MaVTST";
			c1.HeaderText="Mã VTST";
			c1.Width=80;
			tbs.GridColumnStyles.Add(c1);			
			dtgDMVITRISINHTHIET.TableStyles.Add(tbs);
			
			DataGridTextBoxColumn c2=new DataGridTextBoxColumn();
			c2.MappingName="TenVTST";
			c2.HeaderText="Tên VTST";
			c2.Width=280;
			tbs.GridColumnStyles.Add(c2);			
			dtgDMVITRISINHTHIET.TableStyles.Add(tbs);

			DataGridTextBoxColumn c3=new DataGridTextBoxColumn();
			c3.MappingName="NameVTST";
			c3.HeaderText="Name of VTVT";
			c3.Width=280;
			tbs.GridColumnStyles.Add(c3);		
			dtgDMVITRISINHTHIET.TableStyles.Add(tbs);

			DataGridTextBoxColumn c4=new DataGridTextBoxColumn();
			c4.MappingName="hadt";
			c4.HeaderText="";
			c4.Width=0;
			tbs.GridColumnStyles.Add(c4);		
			dtgDMVITRISINHTHIET.TableStyles.Add(tbs);

			DataGridTextBoxColumn c5=new DataGridTextBoxColumn();
			c5.MappingName="havt";
			c5.HeaderText="";
			c5.Width=0;
			tbs.GridColumnStyles.Add(c5);		
			dtgDMVITRISINHTHIET.TableStyles.Add(tbs);
		}	
		
		private void buttonKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ShowGrid()
		{
            dsDmvtst = k.get_data("select * from " + user + ".gpb_vtst order by mavtst");
			dtgDMVITRISINHTHIET.DataSource=dsDmvtst.Tables[0];
		}

		private void buttonThem_Click(object sender, System.EventArgs e)
		{
			bUpdate=true;
			clear_text();
			Enable_Button(false);
			enable_text(true);
			cmbNhom.Focus();
			SendKeys.Send("{f4}");
		}

		private void Enable_Button(bool ena)
		{
			buttonBoqua.Enabled=!ena;
			buttonHuy.Enabled=ena;
			buttonKetthuc.Enabled=ena;
			buttonLuu.Enabled=!ena;
			buttonSua.Enabled=ena;
			buttonThem.Enabled=ena;
		}

		private void clear_text()
		{
			cmbNhom.SelectedIndex=-1;
			txtMa.Clear();
			txtMa1.Clear();
			txtTen.Clear();
			txtName.Clear();
			hadt.Clear();havt.Clear();
		}

		private void enable_text(bool ena)
		{
			cmbNhom.Enabled=ena;
			//txtMa.Enabled=ena;
			txtMa1.Enabled=ena;
			txtTen.Enabled=ena;
			txtName.Enabled=ena;
			hadt.Enabled=ena;
			havt.Enabled=ena;
		}

		private void buttonBoqua_Click(object sender, System.EventArgs e)
		{
			Enable_Button(true);
			enable_text(false);
			buttonThem.Focus();
		}

		private void buttonLuu_Click(object sender, System.EventArgs e)
		{	
			if(!Kiemtra())return;
			string ma = txtMa.Text.ToString().Trim();
			if(bUpdate)
			{
                if (k.Kiemtratrungma("select mavtst from " + user + ".gpb_vtst ", ma))
				{
					MessageBox.Show("Đã tồn tại mã này, hãy chọn mã khác !",LibMedi.AccessData.Msg);
					txtMa.Focus();
					return;
				}				
			}
			
			if(!k.updgpb_dmvtst(cmbNhom.SelectedValue.ToString(), txtMa.Text.Trim(), txtTen.Text.Trim(), txtName.Text.Trim(), hadt.Text.Trim(), havt.Text.Trim()))
			{
				MessageBox.Show("Không cập nhật!",LibMedi.AccessData.Msg,MessageBoxButtons.OK,MessageBoxIcon.Information );
				buttonBoqua.Focus();
				return;
			}

			ShowGrid();
			enable_text(false);
			Enable_Button(true);
			buttonThem.Focus();
		}

		public void First_Text()
		{
			cmbNhom.SelectedValue=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,0].ToString();
			txtMa1.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,1].ToString().Remove(0,4);
			txtMa.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,1].ToString();
			txtTen.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,2].ToString();
			txtName.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,3].ToString();
			hadt.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,4].ToString();
			havt.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,5].ToString();
		}

		private void dtgDMVITRISINHTHIET_CurrentCellChanged(object sender, System.EventArgs e)
		{
			cmbNhom.SelectedValue=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,0].ToString();
			txtMa1.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,1].ToString().Remove(0,4);
			txtMa.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,1].ToString();
			txtTen.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,2].ToString();
			txtName.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,3].ToString();
			hadt.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,4].ToString();
			havt.Text=dtgDMVITRISINHTHIET[dtgDMVITRISINHTHIET.CurrentRowIndex,5].ToString();
		}

		private void cmbNhom_SelectedValueChanged(object sender, System.EventArgs e)
		{
			try
			{			
				textBox1.Text = cmbNhom.SelectedValue.ToString();				
			}
			catch
			{
			
			}
		}

		private void buttonHuy_Click(object sender, System.EventArgs e)
		{
			if(dtgDMVITRISINHTHIET.VisibleRowCount !=0 )
			{
				if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?", "Chú ý",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
                    k.execute_data("Delete  From " + user + ".GPB_VTST Where MaVTST = '" + txtMa.Text.ToString() + "'");
					ShowGrid();
					First_Text();
				}
			}
		}

		private void buttonSua_Click(object sender, System.EventArgs e)
		{
			bUpdate=false;
			enable_text(true);
			cmbNhom.Enabled=false;
			Enable_Button(false);
			txtMa1.Focus();
		}

		private void txtMa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtTen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dtgDMVITRISINHTHIET_DoubleClick(object sender, System.EventArgs e)
		{
			
		}

		private void dtgDMVITRISINHTHIET_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Delete)
			{
				if(dtgDMVITRISINHTHIET.VisibleRowCount !=0 )
				{
					if(MessageBox.Show("Bạn muốn xoá mẩu tin này ?", "Chú ý",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
                        k.execute_data("Delete  From " + user + ".GPB_VTST Where MaVTST = '" + txtMa.Text.ToString() + "'");
						ShowGrid();
						First_Text();
					}
				}			
			}
		}

		private bool Kiemtra()
		{			
			if(cmbNhom.SelectedIndex==-1)
			{
				MessageBox.Show("Hãy chọn Mã Nhóm VTST",LibMedi.AccessData.Msg);
				cmbNhom.Focus();
				return false;
			}
			
			if(txtMa.TextLength ==0)
			{
				MessageBox.Show("Chưa nhập mã HMMD !",LibMedi.AccessData.Msg);
				txtMa.Focus();
				return false;
			}
			
			if(txtTen.TextLength ==0)
			{
				MessageBox.Show("Chưa nhập tên HMMD");
				txtTen.Focus();
				return false;
			}					
			return true;
		}

		private void cmbNhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtMa1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtMa1_Validated(object sender, System.EventArgs e)
		{
			
			if(txtMa1.Text!="") txtMa.Text=cmbNhom.SelectedValue.ToString()+"."+txtMa1.Text.Trim();
		}
	}
}
