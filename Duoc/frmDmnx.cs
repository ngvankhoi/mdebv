using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmDmnx : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown stt;
		private decimal l_id;
		private int i_nhom,itable,i_userid,i_makt;
		private string s_mmyy,s_ngayud,user;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox sotk;
		private System.Windows.Forms.TextBox masothue;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox dienthoai;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox daidien;
        private System.Windows.Forms.Button butExcel;
        private Excel.Application oxl;
        private Excel._Workbook owb;
        private Excel._Worksheet osheet;
        private System.Windows.Forms.TextBox makt;
        private LibList.List listKT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkKetoan;
        private System.Data.DataTable dtkt = new System.Data.DataTable();
        private System.Windows.Forms.CheckBox chkKhongdung;
        private System.Windows.Forms.Button butImpExcel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmnx(AccessData acc,int nhom,string mmyy,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; s_mmyy = mmyy; i_nhom = nhom; i_userid = userid;            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmnx));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.ma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sotk = new System.Windows.Forms.TextBox();
            this.masothue = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dienthoai = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.daidien = new System.Windows.Forms.TextBox();
            this.butExcel = new System.Windows.Forms.Button();
            this.makt = new System.Windows.Forms.TextBox();
            this.listKT = new LibList.List();
            this.label10 = new System.Windows.Forms.Label();
            this.chkKetoan = new System.Windows.Forms.CheckBox();
            this.chkKhongdung = new System.Windows.Forms.CheckBox();
            this.butImpExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 414);
            this.dataGrid1.TabIndex = 15;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(666, 528);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 17;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(203, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nội dung :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(257, 454);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(352, 21);
            this.ten.TabIndex = 3;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(158, 528);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 13;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(228, 528);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 14;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(298, 528);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 11;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(368, 528);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 12;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(508, 528);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 16;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(3, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "STT :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(47, 454);
            this.stt.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(44, 21);
            this.stt.TabIndex = 1;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // ma
            // 
            this.ma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(118, 454);
            this.ma.MaxLength = 20;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(74, 21);
            this.ma.TabIndex = 2;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(88, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(608, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(656, 454);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(128, 21);
            this.nhomcc.TabIndex = 4;
            this.nhomcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomcc_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(0, 477);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Số TK :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(187, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 22;
            this.label6.Text = "Mã số thuế :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(-9, 500);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "Địa chỉ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sotk
            // 
            this.sotk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sotk.Enabled = false;
            this.sotk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotk.Location = new System.Drawing.Point(47, 478);
            this.sotk.MaxLength = 20;
            this.sotk.Name = "sotk";
            this.sotk.Size = new System.Drawing.Size(145, 21);
            this.sotk.TabIndex = 5;
            this.sotk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sotk_KeyDown);
            // 
            // masothue
            // 
            this.masothue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.masothue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.masothue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.masothue.Enabled = false;
            this.masothue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masothue.Location = new System.Drawing.Point(257, 478);
            this.masothue.MaxLength = 20;
            this.masothue.Name = "masothue";
            this.masothue.Size = new System.Drawing.Size(167, 21);
            this.masothue.TabIndex = 6;
            this.masothue.Validated += new System.EventHandler(this.masothue_Validated);
            this.masothue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.masothue_KeyDown);
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(47, 502);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(377, 21);
            this.diachi.TabIndex = 8;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(8, 5);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(776, 21);
            this.tim.TabIndex = 16;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(414, 503);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Đ. thoại :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dienthoai
            // 
            this.dienthoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienthoai.Enabled = false;
            this.dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienthoai.Location = new System.Drawing.Point(480, 502);
            this.dienthoai.MaxLength = 20;
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Size = new System.Drawing.Size(304, 21);
            this.dienthoai.TabIndex = 9;
            this.dienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(414, 477);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 23;
            this.label9.Text = "Đại diện :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // daidien
            // 
            this.daidien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.daidien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.daidien.Enabled = false;
            this.daidien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daidien.Location = new System.Drawing.Point(480, 478);
            this.daidien.Name = "daidien";
            this.daidien.Size = new System.Drawing.Size(304, 21);
            this.daidien.TabIndex = 7;
            this.daidien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // butExcel
            // 
            this.butExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExcel.Image = global::Duoc.Properties.Resources.Export;
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(438, 528);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(70, 25);
            this.butExcel.TabIndex = 15;
            this.butExcel.Text = "    &Excel";
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // makt
            // 
            this.makt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makt.Enabled = false;
            this.makt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makt.Location = new System.Drawing.Point(47, 430);
            this.makt.Name = "makt";
            this.makt.Size = new System.Drawing.Size(737, 21);
            this.makt.TabIndex = 0;
            this.makt.TextChanged += new System.EventHandler(this.makt_TextChanged);
            this.makt.Validated += new System.EventHandler(this.makt_Validated);
            this.makt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makt_KeyDown);
            // 
            // listKT
            // 
            this.listKT.BackColor = System.Drawing.SystemColors.Info;
            this.listKT.ColumnCount = 0;
            this.listKT.Location = new System.Drawing.Point(339, 573);
            this.listKT.MatchBufferTimeOut = 1000;
            this.listKT.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listKT.Name = "listKT";
            this.listKT.Size = new System.Drawing.Size(75, 17);
            this.listKT.TabIndex = 74;
            this.listKT.TextIndex = -1;
            this.listKT.TextMember = null;
            this.listKT.ValueIndex = -1;
            this.listKT.Visible = false;
            this.listKT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listKT_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(-7, 428);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 23);
            this.label10.TabIndex = 75;
            this.label10.Text = "Kế toán :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkKetoan
            // 
            this.chkKetoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKetoan.AutoSize = true;
            this.chkKetoan.Location = new System.Drawing.Point(39, 542);
            this.chkKetoan.Name = "chkKetoan";
            this.chkKetoan.Size = new System.Drawing.Size(114, 17);
            this.chkKetoan.TabIndex = 76;
            this.chkKetoan.Text = "Danh mục kế toán";
            this.chkKetoan.UseVisualStyleBackColor = true;
            this.chkKetoan.CheckedChanged += new System.EventHandler(this.chkKetoan_CheckedChanged);
            // 
            // chkKhongdung
            // 
            this.chkKhongdung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKhongdung.AutoSize = true;
            this.chkKhongdung.Location = new System.Drawing.Point(39, 526);
            this.chkKhongdung.Name = "chkKhongdung";
            this.chkKhongdung.Size = new System.Drawing.Size(84, 17);
            this.chkKhongdung.TabIndex = 10;
            this.chkKhongdung.Text = "Không dùng";
            this.chkKhongdung.UseVisualStyleBackColor = true;
            this.chkKhongdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // butImpExcel
            // 
            this.butImpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butImpExcel.Image = ((System.Drawing.Image)(resources.GetObject("butImpExcel.Image")));
            this.butImpExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImpExcel.Location = new System.Drawing.Point(578, 528);
            this.butImpExcel.Name = "butImpExcel";
            this.butImpExcel.Size = new System.Drawing.Size(88, 25);
            this.butImpExcel.TabIndex = 122;
            this.butImpExcel.Text = "Imp_Excel";
            this.butImpExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImpExcel.UseVisualStyleBackColor = true;
            this.butImpExcel.Click += new System.EventHandler(this.butImpExcel_Click);
            // 
            // frmDmnx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.butImpExcel);
            this.Controls.Add(this.chkKhongdung);
            this.Controls.Add(this.chkKetoan);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listKT);
            this.Controls.Add(this.makt);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.masothue);
            this.Controls.Add(this.daidien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dienthoai);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.sotk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmnx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nhà cung cấp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDmnx_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmnx_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmnx_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; itable = d.tableid("", "d_dmnx");
            //
            f_capnhat_db();
            //
			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			nhomcc.DataSource=d.get_data("select * from "+user+".d_nhomcc where nhom="+i_nhom+" order by stt").Tables[0];

            dtkt=d.get_data("select tendt,tendt as ten,id,mavt,dienthoai,diachi,masothue,sotaikhoan,daidien from " + user + ".a_dmdt where loaidt>0 order by mavt").Tables[0];
            listKT.DisplayMember = "tendt";
            listKT.ValueMember = "tendt";
            listKT.DataSource = dtkt;

            chkKetoan.Checked = d.Thongso("dmnx_kt") == "1";
			load_grid();
			AddGridTableStyle();
			ref_text();
		}

		private void load_grid()
		{
            dt = d.get_data("select a.*,b.ten as tennhom,to_char(a.ngayud,'dd/mm/yyyy') as ngay from " + user + ".d_dmnx a left join " + user + ".d_nhomcc b on a.nhomcc=b.id where a.nhom=" + i_nhom + " order by a.stt").Tables[0];
			dataGrid1.DataSource=dt;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
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
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 225;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotk";
			TextCol.HeaderText = "Tài khoản";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "masothue";
			TextCol.HeaderText = "Mã số thuế";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "diachi";
			TextCol.HeaderText = "Địa chỉ";
			TextCol.Width = 160;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhomcc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "daidien";
			TextCol.HeaderText = "Đại diện";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhom";
			TextCol.HeaderText = "Nhóm";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dienthoai";
			TextCol.HeaderText = "Điện thoại";
			TextCol.Width = 65;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "macongno";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "hide";
            TextCol.HeaderText = "Ẩn";
            TextCol.Width = 40;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void ena_object(bool ena)
		{
			dataGrid1.Enabled=!ena;
			stt.Enabled=ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
			tim.Enabled=!ena;
			nhomcc.Enabled=ena;
			sotk.Enabled=ena;
			masothue.Enabled=ena;
			diachi.Enabled=ena;
			daidien.Enabled=ena;
			dienthoai.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            chkKetoan.Enabled = ena;
            chkKhongdung.Enabled = ena;
            if (chkKetoan.Checked) makt.Enabled = ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
                stt.Value = decimal.Parse(d.get_data("select max(stt) from " + user + ".d_dmnx where nhom=" + i_nhom).Tables[0].Rows[0][0].ToString()) + 1;
			}
			catch{stt.Value=1;}
			l_id=0;
			makt.Text=ma.Text="";
			ten.Text="";s_ngayud="";
			nhomcc.SelectedIndex=-1;
			sotk.Text="";
			masothue.Text="";
			diachi.Text="";
			dienthoai.Text="";
			daidien.Text="";
			ena_object(true);
            if (makt.Enabled) makt.Focus();
            else stt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,7].ToString());
			ena_object(true);
            //if (s_ngayud.Substring(0,10)!=d.ngayhienhanh_server.Substring(0,10)) ten.Enabled=false;
            if (makt.Enabled) makt.Focus();
            else stt.Focus();
		}

		private bool kiemtra()
		{
			if (ma.Text=="")
			{
				ma.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (nhomcc.SelectedIndex==-1)
			{
				nhomcc.Focus();
				return false;
			}
            i_makt = 0;
            if (makt.Enabled)
            {
                DataRow r = d.getrowbyid(dtkt, "tendt='" + makt.Text + "'");
                i_makt = (r != null) ? int.Parse(r["id"].ToString()) : 0;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
            if (l_id == 0)
            {
                // hien sua 06-06-2011 //gam comment ngay 19/09/2011
                //l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString() + d.get_id_dmnx.ToString().PadLeft(5, '0'));
                // end hien
                l_id = decimal.Parse(d.get_id_dmnx.ToString().PadLeft(5, '0'));
                d.upd_eve_tables(itable, i_userid, "ins");
            }
            else
            {
                d.upd_eve_tables(itable, i_userid, "upd");
                d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_dmnx", "id=" + l_id));
            }
			if (!d.upd_dmnx(l_id,ma.Text,ten.Text,i_nhom,int.Parse(stt.Value.ToString()),int.Parse(nhomcc.SelectedValue.ToString()),sotk.Text,masothue.Text,diachi.Text,dienthoai.Text,daidien.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin")+" "+this.Text.Trim()+" !",d.Msg);
				return;
			}
            if (makt.Enabled) d.execute_data("update " + user + ".d_dmnx set macongno=" + i_makt + " where id=" + l_id);
			if (!d.bDanhmuc) d.writeXml("d_thongso","c01","1");
            d.execute_data("update " + user + ".d_dmnx set hide=" + (chkKhongdung.Checked ? "1" : "0") + " where id=" + l_id);
			load_grid();
            ref_text();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ref_text();
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy ?"),d.Msg);
				return;
			}	
			try
			{
				if (d.get_data("select * from "+user+s_mmyy+".d_nhapll where madv="+decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,7].ToString())).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đang sử dụng không cho phép hủy !"),d.Msg);
					return;
				}
                if (d.get_data("select * from " + user + s_mmyy + ".d_theodoi where nhomcc=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 7].ToString())).Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đang sử dụng không cho phép hủy !"),d.Msg);
					return;
				}                
			}
			catch{}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                l_id = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 7].ToString());
                d.upd_eve_tables(itable, i_userid, "del");
                d.upd_eve_upd_del(itable, i_userid, "del", d.fields(user + ".d_dmnx", "id=" + l_id));
				d.execute_data("delete from "+user+".d_dmnx where id="+l_id);
				if (!d.bDanhmuc) d.writeXml("d_thongso","c01","1");
				load_grid();
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Value=decimal.Parse(dataGrid1[i,0].ToString());
				ma.Text=dataGrid1[i,1].ToString();
				ten.Text=dataGrid1[i,2].ToString();
				sotk.Text=dataGrid1[i,3].ToString();
				masothue.Text=dataGrid1[i,4].ToString();
				diachi.Text=dataGrid1[i,5].ToString();
				nhomcc.SelectedValue=dataGrid1[i,6].ToString();
				daidien.Text=dataGrid1[i,8].ToString();
				dienthoai.Text=dataGrid1[i,10].ToString();
				s_ngayud=dataGrid1[i,11].ToString();                
                i_makt=int.Parse(dataGrid1[i,12].ToString());
                DataRow r = d.getrowbyid(dtkt, "id=" + i_makt);
                makt.Text = (r != null) ? r["tendt"].ToString() : "";

                chkKhongdung.Checked = dataGrid1[i, 13].ToString() == "1";
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmDmnx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void stt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="" && l_id==0)
			{
				DataRow r1=d.getrowbyid(dt,"ma='"+ma.Text+"'");
				if (r1!=null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Mã này đã nhập !"),d.Msg);
					ma.Focus();
					return;
				}
				if (ten.Text=="") ten.Text=ma.Text;
			}
		}

		private void nhomcc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhomcc.SelectedIndex==-1) nhomcc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void sotk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void masothue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void diachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			if (l_id==0 && ten.Text!="")
			{
				DataRow r1=d.getrowbyid(dt,"ten='"+ten.Text+"'");
				if (r1!=null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nội dung đã nhập !"),d.Msg);
					ten.Focus();
				}
			}
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+text.Trim()+"%' or masothue like '%"+text.Trim()+"%' or sotk like '%"+text.Trim()+"%' or diachi like '%"+text.Trim()+"%'";
				ref_text();
			}
			catch{}
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim) RefreshChildren(tim.Text);
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void masothue_Validated(object sender, System.EventArgs e)
		{
			if (l_id==0 && masothue.Text!="")
			{
				DataRow r=d.getrowbyid(dt,"masothue='"+masothue.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã số thuế đã nhập !"),d.Msg);
					masothue.Focus();
				}
			}
		}

        private void butExcel_Click(object sender, EventArgs e)
        {
            DataSet tmp = new DataSet();
            tmp = d.get_data("select a.ma,a.ten,a.sotk,a.masothue,a.diachi,a.dienthoai,a.daidien,b.ten as tennhom from " + user + ".d_dmnx a left join " + user + ".d_nhomcc b on a.nhomcc=b.id where a.nhom=" + i_nhom + " order by a.stt");
            if (tmp.Tables[0].Rows.Count > 0)
            {
                d.check_process_Excel();
                string tenfile = d.Export_Excel(tmp, "dmnx");
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = true;
                oxl.ActiveWindow.DisplayZeros = false;
                int row = tmp.Tables[0].Rows.Count + 1;
                osheet.get_Range(d.getIndex(0) + "1", d.getIndex(tmp.Tables[0].Columns.Count - 1) + row.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                oxl.Visible = true;
            }
        }

        private void makt_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == makt)
            {
                Filter(makt.Text, listKT);
                listKT.BrowseToDanhmuc(makt,makt,stt);
            }
        }

        private void Filter(string ten, LibList.List list)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "tendt like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void makt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listKT.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listKT.Visible) listKT.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void makt_Validated(object sender, EventArgs e)
        {
            if (!listKT.Focused) listKT.Hide();
            DataRow r = d.getrowbyid(dtkt, "tendt='" + makt.Text + "'");
            if (r != null && ten.Text == "")
            {
                ten.Text = r["tendt"].ToString();
                ma.Text = r["mavt"].ToString();
                diachi.Text = r["diachi"].ToString();
                daidien.Text = r["daidien"].ToString();
                sotk.Text = r["sotaikhoan"].ToString();
                masothue.Text = r["masothue"].ToString();
            }
        }

        private void chkKetoan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkKetoan)
            {
                makt.Enabled = chkKetoan.Checked;
                d.writeXml("d_thongso", "dmnx_kt", (chkKetoan.Checked) ? "1" : "0");
            }
        }

        private void listKT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) makt_Validated(sender, e);
        }

        private void f_capnhat_db()
        {
            string asql = "alter table " + user + ".d_dmnx add hide numric(1) default 0";
            d.execute_data(asql);
        }

        private void butImpExcel_Click(object sender, EventArgs e)
        {
            frmNhap_dmnx f = new frmNhap_dmnx();
            f.ShowDialog();
            load_grid();
        }
	}
}
