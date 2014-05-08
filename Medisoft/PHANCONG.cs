using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Lib_LH;

namespace Medisoft
{
	public class PHANCONG : System.Windows.Forms.Form
	{
        Language lan = new Language();
		Lib_LH.Access_Data k = new Lib_LH.Access_Data();
		DataSet Ds ;
		//DataSet Dshen;
		string tugio;
		string dengio;
		string manhanvien,maphong;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdKetthuc;
		private System.Windows.Forms.Button cmdHuy;
		private System.Windows.Forms.Button cmdBoqua;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button cmdThem;
		private System.Windows.Forms.DateTimePicker dtpPHANCONG;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button cmdLuu;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid dtgPhancong;
		private System.Windows.Forms.ComboBox cmbkhoiphong;
		private System.Windows.Forms.ComboBox cmbphong;
		private System.Windows.Forms.ComboBox cmbbacsi;
		private System.Windows.Forms.TextBox txtnhanvien;
		private System.Windows.Forms.TextBox txtkhoiphong;
		private System.Windows.Forms.TextBox txtphong;
		private System.Windows.Forms.Button cmdSua;
		private System.Windows.Forms.Label lbmaql;
		private System.Windows.Forms.Label lb2;
		private System.Windows.Forms.CheckBox chk;
		private MaskedBox.MaskedBox msk1;
		private MaskedBox.MaskedBox msk2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox maql;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label9;
		private System.ComponentModel.Container components = null;

		public PHANCONG()
		{
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PHANCONG));
			this.label1 = new System.Windows.Forms.Label();
			this.dtpPHANCONG = new System.Windows.Forms.DateTimePicker();
			this.dtgPhancong = new System.Windows.Forms.DataGrid();
			this.cmbbacsi = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbkhoiphong = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.cmdHuy = new System.Windows.Forms.Button();
			this.cmdBoqua = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cmdThem = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cmdLuu = new System.Windows.Forms.Button();
			this.cmbphong = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtnhanvien = new System.Windows.Forms.TextBox();
			this.txtkhoiphong = new System.Windows.Forms.TextBox();
			this.txtphong = new System.Windows.Forms.TextBox();
			this.cmdSua = new System.Windows.Forms.Button();
			this.lbmaql = new System.Windows.Forms.Label();
			this.lb2 = new System.Windows.Forms.Label();
			this.chk = new System.Windows.Forms.CheckBox();
			this.msk1 = new MaskedBox.MaskedBox();
			this.msk2 = new MaskedBox.MaskedBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.maql = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtgPhancong)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, -8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(816, 616);
			this.label1.TabIndex = 20;
			// 
			// dtpPHANCONG
			// 
			this.dtpPHANCONG.CustomFormat = "DD/MM/YYYY";
			this.dtpPHANCONG.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpPHANCONG.Location = new System.Drawing.Point(680, 8);
			this.dtpPHANCONG.Name = "dtpPHANCONG";
			this.dtpPHANCONG.Size = new System.Drawing.Size(100, 20);
			this.dtpPHANCONG.TabIndex = 15;
			this.dtpPHANCONG.ValueChanged += new System.EventHandler(this.dtpPHANCONG_ValueChanged);
			// 
			// dtgPhancong
			// 
			this.dtgPhancong.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dtgPhancong.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgPhancong.CaptionVisible = false;
			this.dtgPhancong.DataMember = "";
			this.dtgPhancong.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgPhancong.Location = new System.Drawing.Point(0, 48);
			this.dtgPhancong.Name = "dtgPhancong";
			this.dtgPhancong.RowHeaderWidth = 10;
			this.dtgPhancong.Size = new System.Drawing.Size(800, 400);
			this.dtgPhancong.TabIndex = 78;
			this.dtgPhancong.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dtgPhancong_Navigate);
			this.dtgPhancong.CurrentCellChanged += new System.EventHandler(this.dtgPhancong_CurrentCellChanged);
			// 
			// cmbbacsi
			// 
			this.cmbbacsi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbbacsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbbacsi.Location = new System.Drawing.Point(254, 480);
			this.cmbbacsi.Name = "cmbbacsi";
			this.cmbbacsi.Size = new System.Drawing.Size(156, 21);
			this.cmbbacsi.TabIndex = 4;
			this.cmbbacsi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbbacsi_KeyDown);
			this.cmbbacsi.SelectedIndexChanged += new System.EventHandler(this.cmbbacsi_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label3.Location = new System.Drawing.Point(216, 464);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Nhân viên ";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// cmbkhoiphong
			// 
			this.cmbkhoiphong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbkhoiphong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbkhoiphong.Location = new System.Drawing.Point(72, 480);
			this.cmbkhoiphong.Name = "cmbkhoiphong";
			this.cmbkhoiphong.Size = new System.Drawing.Size(122, 21);
			this.cmbkhoiphong.TabIndex = 2;
			this.cmbkhoiphong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbkhoiphong_KeyDown);
			this.cmbkhoiphong.SelectedIndexChanged += new System.EventHandler(this.cmbkhoiphong_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label4.Location = new System.Drawing.Point(40, 464);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Khối  Phòng ";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.cmdKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdKetthuc.Image")));
			this.cmdKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdKetthuc.Location = new System.Drawing.Point(384, 16);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(74, 32);
			this.cmdKetthuc.TabIndex = 14;
			this.cmdKetthuc.Text = "Kết thúc";
			this.cmdKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// cmdHuy
			// 
			this.cmdHuy.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.cmdHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdHuy.Image")));
			this.cmdHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdHuy.Location = new System.Drawing.Point(310, 16);
			this.cmdHuy.Name = "cmdHuy";
			this.cmdHuy.Size = new System.Drawing.Size(74, 32);
			this.cmdHuy.TabIndex = 13;
			this.cmdHuy.Text = "    Huỷ";
			this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
			// 
			// cmdBoqua
			// 
			this.cmdBoqua.Enabled = false;
			this.cmdBoqua.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.cmdBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdBoqua.Image")));
			this.cmdBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdBoqua.Location = new System.Drawing.Point(235, 16);
			this.cmdBoqua.Name = "cmdBoqua";
			this.cmdBoqua.Size = new System.Drawing.Size(74, 32);
			this.cmdBoqua.TabIndex = 12;
			this.cmdBoqua.Text = "     Bỏ qua";
			this.cmdBoqua.Click += new System.EventHandler(this.cmdBoqua_Click);
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label5.Location = new System.Drawing.Point(616, 464);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 16);
			this.label5.TabIndex = 75;
			this.label5.Text = "Từ giờ ";
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label6.Location = new System.Drawing.Point(672, 464);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 76;
			this.label6.Text = "Đến giờ";
			// 
			// cmdThem
			// 
			this.cmdThem.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.cmdThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdThem.Image")));
			this.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdThem.Location = new System.Drawing.Point(10, 16);
			this.cmdThem.Name = "cmdThem";
			this.cmdThem.Size = new System.Drawing.Size(77, 32);
			this.cmdThem.TabIndex = 0;
			this.cmdThem.Text = "     Mới";
			this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.SteelBlue;
			this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(0, -8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(805, 72);
			this.label7.TabIndex = 78;
			this.label7.Text = "PHÂN CÔNG KHÁM";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmdLuu
			// 
			this.cmdLuu.Enabled = false;
			this.cmdLuu.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.cmdLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdLuu.Image")));
			this.cmdLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdLuu.Location = new System.Drawing.Point(161, 16);
			this.cmdLuu.Name = "cmdLuu";
			this.cmdLuu.Size = new System.Drawing.Size(74, 32);
			this.cmdLuu.TabIndex = 10;
			this.cmdLuu.Text = "    Lưu";
			this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
			// 
			// cmbphong
			// 
			this.cmbphong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbphong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbphong.Location = new System.Drawing.Point(464, 480);
			this.cmbphong.MaxDropDownItems = 15;
			this.cmbphong.Name = "cmbphong";
			this.cmbphong.Size = new System.Drawing.Size(112, 21);
			this.cmbphong.TabIndex = 6;
			this.cmbphong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbphong_KeyDown);
			this.cmbphong.SelectedIndexChanged += new System.EventHandler(this.cmbphong_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label8.Location = new System.Drawing.Point(432, 464);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 16);
			this.label8.TabIndex = 81;
			this.label8.Text = "Phòng ";
			// 
			// txtnhanvien
			// 
			this.txtnhanvien.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtnhanvien.Location = new System.Drawing.Point(216, 480);
			this.txtnhanvien.Name = "txtnhanvien";
			this.txtnhanvien.Size = new System.Drawing.Size(36, 20);
			this.txtnhanvien.TabIndex = 3;
			this.txtnhanvien.Text = "";
			this.txtnhanvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnhanvien_KeyDown);
			this.txtnhanvien.Validated += new System.EventHandler(this.txtnhanvien_Validated);
			// 
			// txtkhoiphong
			// 
			this.txtkhoiphong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtkhoiphong.Location = new System.Drawing.Point(40, 480);
			this.txtkhoiphong.Name = "txtkhoiphong";
			this.txtkhoiphong.Size = new System.Drawing.Size(30, 20);
			this.txtkhoiphong.TabIndex = 1;
			this.txtkhoiphong.Text = "";
			this.txtkhoiphong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtkhoiphong_KeyDown);
			this.txtkhoiphong.Validated += new System.EventHandler(this.txtkhoiphong_Validated);
			// 
			// txtphong
			// 
			this.txtphong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtphong.Location = new System.Drawing.Point(432, 480);
			this.txtphong.Name = "txtphong";
			this.txtphong.Size = new System.Drawing.Size(30, 20);
			this.txtphong.TabIndex = 5;
			this.txtphong.Text = "";
			this.txtphong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtphong_KeyDown);
			this.txtphong.Validated += new System.EventHandler(this.txtphong_Validated);
			// 
			// cmdSua
			// 
			this.cmdSua.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.cmdSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdSua.Image")));
			this.cmdSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdSua.Location = new System.Drawing.Point(87, 16);
			this.cmdSua.Name = "cmdSua";
			this.cmdSua.Size = new System.Drawing.Size(74, 32);
			this.cmdSua.TabIndex = 11;
			this.cmdSua.Text = "    Sửa";
			this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
			// 
			// lbmaql
			// 
			this.lbmaql.BackColor = System.Drawing.Color.SteelBlue;
			this.lbmaql.Location = new System.Drawing.Point(552, 8);
			this.lbmaql.Name = "lbmaql";
			this.lbmaql.TabIndex = 83;
			// 
			// lb2
			// 
			this.lb2.BackColor = System.Drawing.Color.SteelBlue;
			this.lb2.Font = new System.Drawing.Font("Times New Roman", 10F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.lb2.ForeColor = System.Drawing.Color.White;
			this.lb2.Location = new System.Drawing.Point(0, 24);
			this.lb2.Name = "lb2";
			this.lb2.Size = new System.Drawing.Size(256, 24);
			this.lb2.TabIndex = 85;
			this.lb2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lb2.Click += new System.EventHandler(this.lb2_Click);
			// 
			// chk
			// 
			this.chk.Checked = true;
			this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk.Location = new System.Drawing.Point(592, 480);
			this.chk.Name = "chk";
			this.chk.Size = new System.Drawing.Size(16, 24);
			this.chk.TabIndex = 7;
			this.chk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chk_KeyDown);
			this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
			// 
			// msk1
			// 
			this.msk1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.msk1.Enabled = false;
			this.msk1.Location = new System.Drawing.Point(616, 480);
			this.msk1.Mask = "##/##";
			this.msk1.MaxLength = 5;
			this.msk1.Name = "msk1";
			this.msk1.Size = new System.Drawing.Size(40, 20);
			this.msk1.TabIndex = 8;
			this.msk1.Text = "";
			this.msk1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msk1_KeyDown);
			this.msk1.Validated += new System.EventHandler(this.msk1_Validated);
			// 
			// msk2
			// 
			this.msk2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.msk2.Enabled = false;
			this.msk2.Location = new System.Drawing.Point(672, 480);
			this.msk2.Mask = "##/##";
			this.msk2.MaxLength = 5;
			this.msk2.Name = "msk2";
			this.msk2.Size = new System.Drawing.Size(40, 20);
			this.msk2.TabIndex = 9;
			this.msk2.Text = "";
			this.msk2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msk2_KeyDown);
			this.msk2.Validated += new System.EventHandler(this.msk2_Validated);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.cmdKetthuc,
																					this.cmdHuy,
																					this.cmdBoqua,
																					this.cmdLuu,
																					this.cmdSua,
																					this.cmdThem});
			this.groupBox1.Location = new System.Drawing.Point(152, 504);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(468, 56);
			this.groupBox1.TabIndex = 89;
			this.groupBox1.TabStop = false;
			// 
			// maql
			// 
			this.maql.Name = "maql";
			this.maql.TabIndex = 90;
			this.maql.Text = "";
			this.maql.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.textBox2,
																					this.label9,
																					this.textBox1,
																					this.label2});
			this.groupBox2.Location = new System.Drawing.Point(8, 496);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(136, 64);
			this.groupBox2.TabIndex = 91;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "makp_mabs";
			this.groupBox2.Visible = false;
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(48, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(80, 20);
			this.textBox1.TabIndex = 92;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Enabled = false;
			this.textBox2.Location = new System.Drawing.Point(48, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(80, 20);
			this.textBox2.TabIndex = 93;
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 92;
			this.label2.Text = "nv";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 94;
			this.label9.Text = "kp";
			// 
			// PHANCONG
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtkhoiphong,
																		  this.cmbkhoiphong,
																		  this.groupBox2,
																		  this.maql,
																		  this.groupBox1,
																		  this.msk2,
																		  this.msk1,
																		  this.chk,
																		  this.lb2,
																		  this.lbmaql,
																		  this.txtphong,
																		  this.dtpPHANCONG,
																		  this.txtnhanvien,
																		  this.label8,
																		  this.cmbphong,
																		  this.dtgPhancong,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.cmbbacsi,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PHANCONG";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BẢNG PHÂN CÔNG ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.PHANCONG_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgPhancong)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void PHANCONG_Load(object sender, System.EventArgs e)
		{			
			lb2.Text= "Lịch khám bệnh ngày "+dtpPHANCONG.Text.ToString();
			Enable(false);
			Load_cmb();
			Loadgrid();			
			LoadGridStyle();						
		}

		private void dtpPHANCONG_ValueChanged(object sender, System.EventArgs e)
		{				
			lb2.Text="Lịch khám bệnh ngày "+dtpPHANCONG.Text.ToString();
			Loadgrid();
			if(dtpPHANCONG.Value<DateTime.Today)
			{
				groupBox1.Enabled=false;
				cmdKetthuc.Enabled=true;
			}
			else
			{groupBox1.Enabled=true;}
		}

		private void Load_cmb()
		{
			cmbbacsi.DisplayMember="HOTEN";
			cmbbacsi.ValueMember="MA";
			cmbbacsi.DataSource=k.Get_dmbacsi().Tables[0];			
			cmbbacsi.SelectedIndex=0;

			cmbkhoiphong.DisplayMember="TENNHOM";
			cmbkhoiphong.ValueMember="MANHOM";
			cmbkhoiphong.DataSource=k.Get_nhomphong().Tables[0];
			cmbkhoiphong.SelectedIndex = 0;					
		}		

		private void Load_cmbphong(string maloai)
		{
			cmbphong.DisplayMember="TENKP";
			cmbphong.ValueMember="MAKP";
			cmbphong.DataSource=k.get_phong(maloai).Tables[0];
			//cmbphong.SelectedIndex=0;
		}

		private void cmbbacsi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtnhanvien.Text=cmbbacsi.SelectedValue.ToString();
		}

		private void cmbkhoiphong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtkhoiphong.Text=cmbkhoiphong.SelectedValue.ToString();
			Load_cmbphong(cmbkhoiphong.SelectedValue.ToString());
		}

		private void cmbphong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtphong.Text=cmbphong.SelectedValue.ToString();
		}

		private void txtnhanvien_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbbacsi.SelectedValue=txtnhanvien.Text.ToString();
			}
			catch{}
		}

		private void txtkhoiphong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbkhoiphong.SelectedValue=txtkhoiphong.Text.ToString();
			}
			catch{}

		}

		private void txtphong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbphong.SelectedValue=txtphong.Text.ToString();
			}
			catch{}
		}

		private void txtnhanvien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbbacsi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtkhoiphong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbkhoiphong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtphong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}		

		private void cmdThem_Click(object sender, System.EventArgs e)
		{
			Enable(true);
			enabut(true);	
			cmdSua.Enabled=false;
			chk.Checked=true;
			msk1.Text="";
			msk2.Text="";
			dtgPhancong.Enabled=false;
			dtpPHANCONG.Enabled=false;
			Loadmax_maql();
			macu(false);
			txtkhoiphong.Focus();
		}

		private void Enable(bool ena)
		{
			txtkhoiphong.Enabled=ena;
			txtnhanvien.Enabled=ena;
			txtphong.Enabled=ena;
			cmbbacsi.Enabled=ena;
			cmbkhoiphong.Enabled=ena;
			cmbphong.Enabled=ena;
		}

		private void enabut(bool ena)
		{
			cmdBoqua.Enabled=ena;
			cmdHuy.Enabled=!ena;
			cmdKetthuc.Enabled=!ena;
			cmdLuu.Enabled=ena;			
			cmdThem.Enabled=!ena;			
		}

		private void cmdSua_Click(object sender, System.EventArgs e)
		{			
			Enable(true);
			cmdBoqua.Enabled=true;
			cmdHuy.Enabled=false;
			cmdKetthuc.Enabled=false;
			cmdLuu.Enabled=true;			
			cmdSua.Enabled=false;
			cmdThem.Enabled=false;
			dtgPhancong.Enabled=false;
			dtpPHANCONG.Enabled=false;
			macu(true);
			txtnhanvien.Focus();
		}

		private void cmdLuu_Click(object sender, System.EventArgs e)
		{
			if(!check())
			{
				return;
			}
			if(!kiemtra())
			{
				MessageBox.Show("Lịch làm việc bị trùng","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				cmdBoqua.Focus();
				return;
			}
			if(chk.Checked)
			{
                DataSet ds = k.get_thoigian("Select * from lh_thoigian");
				DataTable tb = ds.Tables[0];
				tugio=tb.Rows[0][0].ToString();
				int first=tb.Rows.Count;
				dengio =tb.Rows[0][1].ToString();
			}
			else
			{
				tugio = msk1.Text.Substring(0,2)+":"+msk1.Text.Substring(3,2);
				dengio = msk2.Text.Substring(0,2)+":"+msk2.Text.Substring(3,2);
			}			
			k.ins_phancong(dtpPHANCONG.Text.ToString(),txtnhanvien.Text.ToString(),
				int.Parse(txtkhoiphong.Text.ToString()),txtphong.Text.ToString(),
				tugio,dengio,int.Parse(maql.Text.ToString()));

			Enable(false);
			enabut(false);
			Loadgrid();
			dtgPhancong.Enabled=true;
			dtpPHANCONG.Enabled=true;	
			cmdSua.Enabled=true;
			macu(false);
			cmdThem.Focus();
		}

		private void cmdBoqua_Click(object sender, System.EventArgs e)
		{
			Enable(false);
			enabut(false);
			cmdSua.Enabled=true;
			chk.Checked=true;
			msk1.Text="";
			msk2.Text="";
			dtgPhancong.Enabled=true;
			dtpPHANCONG.Enabled=true;
			macu(false);
		}

		private void Loadgrid()
		{
			Ds = k.get_phancong(dtpPHANCONG.Text.ToString());
			dtgPhancong.DataSource=Ds.Tables[0];
		}

		private void LoadGridStyle()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName=Ds.Tables[0].TableName;

			tbs.AlternatingBackColor = Color.LightYellow;
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

			DataGridTextBoxColumn c1a=new DataGridTextBoxColumn();
			c1a.MappingName="MABS";
			c1a.HeaderText="Mã";
			c1a.NullText="";
			c1a.Width=54;
			tbs.GridColumnStyles.Add(c1a);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="HOTEN";
			c1.HeaderText="Họ Tên Bác Sĩ";
			c1.NullText="";
			c1.Width=300;
			tbs.GridColumnStyles.Add(c1);

			DataGridTextBoxColumn c3=new DataGridTextBoxColumn();
			c3.MappingName="TENKP";
			c3.HeaderText="Tên Phòng";
			c3.NullText="";
			c3.Width=290;			
			tbs.GridColumnStyles.Add(c3);

			DataGridTextBoxColumn c4=new DataGridTextBoxColumn();
			c4.MappingName="TUGIO";
			c4.HeaderText="Từ giờ";
			c4.NullText="";
			c4.Width=70;			
			tbs.GridColumnStyles.Add(c4);

			DataGridTextBoxColumn c5=new DataGridTextBoxColumn();
			c5.MappingName="DENGIO";
			c5.HeaderText="Đến giờ";
			c5.NullText="";
			c5.Width=70;			
			tbs.GridColumnStyles.Add(c5);

			DataGridTextBoxColumn c5a=new DataGridTextBoxColumn();
			c5a.MappingName="MAQL";
			c5a.HeaderText="MAQL";
			c5a.NullText="";
			c5a.Width=0;			
			tbs.GridColumnStyles.Add(c5a);

			DataGridTextBoxColumn c6=new DataGridTextBoxColumn();
			c6.MappingName="LOAI";
			c6.HeaderText="LOAI";
			c6.NullText="";
			c6.Width=0;			
			tbs.GridColumnStyles.Add(c6);

			DataGridTextBoxColumn c7=new DataGridTextBoxColumn();
			c7.MappingName="MAKP";
			c7.HeaderText="MAKP";
			c7.NullText="";
			c7.Width=0;			
			tbs.GridColumnStyles.Add(c7);

			dtgPhancong.TableStyles.Add(tbs);
		}

		private void cmdHuy_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Bạn chắc chắn muốn xoá mẩu tin này ?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				k.del_phancong(int.Parse(dtgPhancong[dtgPhancong.CurrentCell.RowNumber,5].ToString()));
			}
			Loadgrid();
			macu(false);
		}

		private void dtgPhancong_CurrentCellChanged(object sender, System.EventArgs e)
		{
			maql.Text=dtgPhancong[dtgPhancong.CurrentCell.RowNumber,5].ToString();
			try
			{
				cmbbacsi.SelectedValue=dtgPhancong[dtgPhancong.CurrentCell.RowNumber,0].ToString();
			}
			catch{}
			try
			{
				cmbkhoiphong.SelectedValue=dtgPhancong[dtgPhancong.CurrentCell.RowNumber,6].ToString();
			}
			catch{}
			try
			{
				cmbphong.SelectedValue=dtgPhancong[dtgPhancong.CurrentCell.RowNumber,7].ToString();
			}
			catch{}
			msk1.Text=dtgPhancong[dtgPhancong.CurrentCell.RowNumber,3].ToString();
			msk2.Text=dtgPhancong[dtgPhancong.CurrentCell.RowNumber ,4].ToString();
		}

		private void Loadmax_maql()
		{
			try
			{
				 maql.Text = k.get_maxmaql().ToString();
			}
			catch
			{
				maql.Text = "0";
			}
		}

		private void cmdLuu_Update_Click(object sender, System.EventArgs e)
		{}

		private void chk_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk.Checked)
			{
				msk1.Enabled=false;
				msk2.Enabled=false;
				msk1.Text="";
				msk2.Text="";
			}
			else
			{
				msk1.Enabled=true;
				msk2.Enabled=true;
				msk1.Focus();
			}
		}

		private void msk1_Validated(object sender, System.EventArgs e)
		{
			if(msk1.TextLength!=0)
			{
				if(!Check(msk1))
				{
					MessageBox.Show("Nhập giờ không đúng","Thông Báo");
					msk1.Focus();
					return;
				}
			}
		}

		private void msk2_Validated(object sender, System.EventArgs e)
		{
			if(msk2.TextLength!=0)
			{
				if(!Check(msk2))
				{
					MessageBox.Show("Nhập giờ không đúng","Thông Báo");
					msk2.Focus();
					return;
				}
			}
		}

		private bool Check(MaskedBox.MaskedBox msk)
		{
			try
			{
				DataSet Ds = k.get_thoigian("Select * from lh_thoigian");
				DataTable tb = Ds.Tables[0];
				int tgbd = int.Parse(tb.Rows[0]["TGBD"].ToString().Substring(0,2));
				int tgkt = int.Parse(tb.Rows[0]["TGKT"].ToString().Substring(0,2));
				int phutkt = int.Parse(tb.Rows[0]["TGKT"].ToString().Substring(3,2));
				string a = msk.Text.ToString().Trim();			

				int gio = int.Parse(msk.Text.Substring(0,2).ToString());
				int phut = int.Parse(msk.Text.Substring(3,2).ToString());
				if(phut>59)
				{
					return false;
				}
				if(gio<tgbd)
				{
					MessageBox.Show("Giờ hẹn phải lớn hơn giờ bắt đầu làm việc","Thông Báo");
					return false;
				}
				if(gio>tgkt)
				{
					MessageBox.Show("Giờ hẹn phải nhỏ hơn giờ nghỉ","Thông Báo");
					return false;
				}
				if(gio == tgkt && phutkt>phut)
				{
					MessageBox.Show("Giờ hẹn phải nhỏ hơn giờ nghỉ","Thông Báo");
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		private bool kiemtra()
		{
			DataRow [] r=Ds.Tables[0].Select("MABS='"+txtnhanvien.Text+"' and MAKP='"+txtphong.Text+"'");
			if(r.Length>0)
			{
				if(manhanvien.Length>1)
				{
					if(r[0]["MABS"].ToString()==manhanvien && r[0]["MAKP"].ToString()==maphong)
					{}
					else
					{
						return false;
					}
				}				
			}
			DataRow [] r1=Ds.Tables[0].Select("MABS='"+txtnhanvien.Text+"'");
			if(r1.Length>0)
			{	
				if(manhanvien.Length>0 && r1[0]["MABS"].ToString()==manhanvien)			
				{
				}
				else
				{
					if(chk.Checked)
					{
						return false;
					}
					int start=int.Parse((r1[0]["TUGIO"].ToString().Substring(0,2)));
					int end = int.Parse((r1[0]["DENGIO"].ToString().Substring(0,2)));
					for(int i=start;i<=end;i++)
					{
						if(i== int.Parse(msk1.Text.Substring(0,2)))
							return false;
					}
				}
			}
			DataRow [] r2=Ds.Tables[0].Select("MAKP='"+txtphong.Text+"'");
			if(r2.Length>0)
			{
				if(maphong.Length>0 && r1[0]["MAKP"].ToString()==maphong)			
				{
				}
				else
				{
					if(chk.Checked)
					{
						return false;
					}
					int start=int.Parse((r2[0]["TUGIO"].ToString().Substring(0,2)));
					int end = int.Parse((r2[0]["DENGIO"].ToString().Substring(0,2)));
					for(int i=start;i<=end;i++)
					{
						if(i== int.Parse(msk1.Text.Substring(0,2)))
							return false;
					}
				}
			}		
			return true;
		}

		private void cmbphong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				chk.Focus();
		}

		private void chk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(chk.Checked)
				{
					cmdLuu.Focus();
				}
				else
				{
					msk1.Focus();
				}
			}
		
		}

		private void msk1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{Tab}");
		}

		private void msk2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				cmdLuu.Focus();
		}

		private void lb2_Click(object sender, System.EventArgs e)
		{
			if(maql.Visible==true)
			{
					maql.Visible=false;
			}
			else
			{maql.Visible=true;}
		}

		private bool check()
		{
			if(chk.Checked ==false)
			{
				if(msk1.TextLength == 0 || msk2.TextLength ==0)
				{
					MessageBox.Show("Nhập giờ không đúng","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
						return false;
				}
				else
				{}
			}
			return true;
		}

		private void dtgPhancong_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

		private void macu(bool a)
		{
			if(a==true)
			{
				manhanvien=txtnhanvien.Text.ToString();
				maphong=txtphong.Text.ToString();
			}
			else
			{
				manhanvien="";
				maphong="";
			}

		}

		private void label4_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(groupBox2.Visible==true)
				{
					groupBox2.Visible=false;
				}
				else
				{
					groupBox2.Visible=true;
					textBox1.Text=manhanvien.ToString();
					textBox2.Text=maphong.ToString();
				}
			}
			catch{}
		}



	}
}
