using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmTruyvan.
	/// </summary>
	public class frmTruyvan : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox manhom;
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable dtnhom=new DataTable();
		private DataTable dtloai=new DataTable();
		private DataTable dtnhombc=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataSet dsxml=new DataSet();
		private AccessData d;
		private string sql,s_manhom,s_maloai,s_mmyy,user;
		private int i_nhom,i_mabd,i_dang;
		private System.Windows.Forms.Button butTonghop;
		private System.Windows.Forms.Button butKetthuc;
		private MaskedBox.MaskedBox dang;
		private System.Windows.Forms.TextBox mabd;
		private System.Windows.Forms.TextBox tenbd;
		private LibList.List listDMBD;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox theo;
		private System.Windows.Forms.CheckedListBox maloai;
		private System.Windows.Forms.GroupBox nhapxuat;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb3;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox bieudo;
        //private AQuangChartControl.AQuangChartControl dothi;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTruyvan(AccessData acc,int nhom,string mmyy)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;s_mmyy=mmyy;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTruyvan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.maloai = new System.Windows.Forms.CheckedListBox();
            this.butTonghop = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dang = new MaskedBox.MaskedBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.listDMBD = new LibList.List();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
            this.nhapxuat = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.bieudo = new System.Windows.Forms.CheckBox();
            //this.dothi = new AQuangChartControl.AQuangChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(129, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(52, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(161, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            // 
            // manhom
            // 
            this.manhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.manhom.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(5, 50);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(203, 452);
            this.manhom.TabIndex = 12;
            // 
            // maloai
            // 
            this.maloai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.maloai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maloai.CheckOnClick = true;
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(5, 519);
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(203, 196);
            this.maloai.TabIndex = 13;
            // 
            // butTonghop
            // 
            this.butTonghop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTonghop.Image = global::Duoc.Properties.Resources.ok;
            this.butTonghop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTonghop.Location = new System.Drawing.Point(366, 719);
            this.butTonghop.Name = "butTonghop";
            this.butTonghop.Size = new System.Drawing.Size(76, 25);
            this.butTonghop.TabIndex = 14;
            this.butTonghop.Text = "&Tổng hợp";
            this.butTonghop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(512, 719);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(1295, 27);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(48, 21);
            this.dang.TabIndex = 11;
            // 
            // mabd
            // 
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(52, 27);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(52, 21);
            this.mabd.TabIndex = 8;
            // 
            // tenbd
            // 
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(106, 27);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(320, 21);
            this.tenbd.TabIndex = 9;
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(224, 536);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 32;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(240, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đánh giá :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-11, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thuốc :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theo
            // 
            this.theo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.theo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.theo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theo.Items.AddRange(new object[] {
            "Tỷ lệ thuốc cấp cứu,thiết yếu,bổ sung",
            "Danh sách mặt hàng cao nhất",
            "Danh sách thành tiền theo nhóm",
            "Tình hình cung cấp theo nhà sản xuất",
            "Tình hình cung cấp theo nhà cung cấp",
            "Quàn lý số đăng ký",
            "Quản lý giá",
            "Quản lý hạn dùng",
            "Quản lý thuốc nội-ngoại",
            "Sử dụng theo khoa/phòng"});
            this.theo.Location = new System.Drawing.Point(296, 5);
            this.theo.Name = "theo";
            this.theo.Size = new System.Drawing.Size(554, 21);
            this.theo.TabIndex = 5;
            // 
            // nhapxuat
            // 
            this.nhapxuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhapxuat.Location = new System.Drawing.Point(6, 713);
            this.nhapxuat.Name = "nhapxuat";
            this.nhapxuat.Size = new System.Drawing.Size(202, 34);
            this.nhapxuat.TabIndex = 33;
            this.nhapxuat.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Checked = true;
            this.rb3.Location = new System.Drawing.Point(112, 12);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(80, 16);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.Text = "Nhập-xuất";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(64, 12);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(48, 18);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Xuất";
            // 
            // rb1
            // 
            this.rb1.Location = new System.Drawing.Point(8, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 16);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "Nhập";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(428, 27);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(422, 21);
            this.tenhc.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(1212, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 23);
            this.label5.TabIndex = 35;
            this.label5.Text = "tháng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mm
            // 
            this.mm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mm.Enabled = false;
            this.mm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(1253, 5);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(34, 21);
            this.mm.TabIndex = 6;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yyyy
            // 
            this.yyyy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yyyy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.yyyy.Enabled = false;
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(1295, 5);
            this.yyyy.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(48, 21);
            this.yyyy.TabIndex = 7;
            this.yyyy.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(1281, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 23);
            this.label6.TabIndex = 38;
            this.label6.Text = "/";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bieudo
            // 
            this.bieudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bieudo.Appearance = System.Windows.Forms.Appearance.Button;
            this.bieudo.Image = global::Duoc.Properties.Resources.Export;
            this.bieudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bieudo.Location = new System.Drawing.Point(443, 719);
            this.bieudo.Name = "bieudo";
            this.bieudo.Size = new System.Drawing.Size(68, 25);
            this.bieudo.TabIndex = 15;
            this.bieudo.Text = "Biểu đồ";
            this.bieudo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dothi
            // 
            //this.dothi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            //this.dothi.AngleColor = 20F;
            //this.dothi.BGround1 = System.Drawing.Color.Red;
            //this.dothi.BGround2 = System.Drawing.Color.Blue;
            //this.dothi.isVisibleX = true;
            //this.dothi.isVisibleY1 = true;
            //this.dothi.isVisibleY2 = true;
            //this.dothi.Location = new System.Drawing.Point(208, 52);
            //this.dothi.Name = "dothi";
            //this.dothi.Size = new System.Drawing.Size(642, 442);
            //this.dothi.TabIndex = 39;
            //this.dothi.TileChia = 1000;
            //this.dothi.Title = "Tiêu đề của biểu đồ";
            //this.dothi.Visible = false;
            //this.dothi.XAxis_max = 500;
            //this.dothi.XAxis_min = 0;
            //this.dothi.XAxis_Title = "Đơn vị theo trục x";
            //this.dothi.Y2Axis_max = 500;
            //this.dothi.Y2Axis_min = 0;
            //this.dothi.Y2Axis_Title = "Số tiền ( ĐVT : 1000 đ)";
            //this.dothi.YAxis_max = 500;
            //this.dothi.YAxis_min = 0;
            //this.dothi.YAxis_Title = "Số tiền ( ĐVT : 1000 đ)";
            // 
            // frmTruyvan
            // 
            this.ClientSize = new System.Drawing.Size(851, 496);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.den);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.maloai);
            this.Controls.Add(this.butTonghop);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.theo);
            this.Controls.Add(this.nhapxuat);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bieudo);
            //this.Controls.Add(this.dothi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTruyvan";
            this.Load += new System.EventHandler(this.frmTruyvan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTruyvan_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user;
			mm.Value=decimal.Parse(s_mmyy.Substring(0,2));
			yyyy.Value=decimal.Parse("20"+s_mmyy.Substring(2,2));
			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="MA";
            dtdmbd = d.get_data("select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(a.tenhc)||'/'||b.ten as tenhc,a.dang,a.id,a.tenhc as hoatchat from " + user + ".d_dmbd a," + user + ".d_dmhang b where a.mahang=b.id and a.nhom=" + i_nhom + " order by a.ten").Tables[0];
			listDMBD.DataSource=dtdmbd;
            dtloai = d.get_data("select * from " + user + ".d_dmloai where nhom=" + i_nhom + " order by stt").Tables[0];
            dtnhom = d.get_data("select * from " + user + ".d_dmnhom where nhom=" + i_nhom + " order by stt").Tables[0];
            dtnhombc = d.get_data("select * from " + user + ".d_nhombc where nhom=" + i_nhom + " order by stt").Tables[0];
            manhom.DataSource = dtnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";

            maloai.DataSource = dtloai;
			maloai.DisplayMember="TEN";
			maloai.ValueMember="ID";
			
			theo.SelectedIndex=0;
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)	mabd_Validated(null,null);
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			if (mabd.Text!="")
			{
				DataRow r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
				if (r!=null) 
				{
					tenbd.Text=r["ten"].ToString();
					dang.Text=r["dang"].ToString();
					tenhc.Text=r["hoatchat"].ToString();
				}
			}
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				Filter_mabd(mabd.Text);
				listDMBD.BrowseToDmbd(mabd,tenbd,tenbd,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+tenbd.Width+tenhc.Width+dang.Width+5,mabd.Height+5);
			}		
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'"+" or hoatchat like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBD.Visible) listDMBD.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				Filter_dmbd(tenbd.Text);
				listDMBD.BrowseToDmbd(tenbd,mabd,manhom,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+tenbd.Width+tenhc.Width+dang.Width+5,mabd.Height+5);
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
			if (tenbd.Text!="" && mabd.Text=="")
			{
				DataRow r=d.getrowbyid(dtdmbd,"ten='"+tenbd.Text+"'");
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					dang.Text=r["dang"].ToString();
					tenhc.Text=r["hoatchat"].ToString();
				}
			}
			SendKeys.Send("{F4}");
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ma like '%"+ma.Trim()+"%'";
			}
			catch{}
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (theo.SelectedIndex==6 || theo.SelectedIndex==7 || theo.SelectedIndex==5)
			{
				if (theo.SelectedIndex==7 || theo.SelectedIndex==5)
				{
					if (decimal.Parse(this.dataGrid1[row,0].ToString().Trim())==0) return Color.Blue;
					else return Color.Black;
				}
				else return Color.Black;
			}
			else
			{
				if (decimal.Parse(this.dataGrid1[row,0].ToString().Trim())==0) return Color.Red;
				else if (col>6) return Color.Blue;
				else return Color.Black;
			}
		}

		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts=new DataGridTableStyle();
			ts.MappingName = dsxml.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.AllowSorting=false;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=5;

			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = (i_dang!=0)?"Tên thuốc - hàm lượng":"Nội dung";
			TextCol.Width = 175-i_dang+((theo.SelectedIndex==4 || rb1.Checked || rb2.Checked)?185:0);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = i_dang;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			if (theo.SelectedIndex==7 || theo.SelectedIndex==5)
			{
				TextCol=new DataGridColoredTextBoxColumn(de, 3);
				TextCol.MappingName = "kho";
				TextCol.HeaderText = "Kho";
				TextCol.Width = 105;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 4);
				TextCol.MappingName = "losx";
				TextCol.HeaderText = (theo.SelectedIndex==7)?"Lô":"Số ĐK";
				TextCol.Width = 50;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 5);
				TextCol.MappingName = "handung";
				TextCol.HeaderText = "Date";
				TextCol.Width = 35;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de,6);
				TextCol.MappingName = "soluong";
				TextCol.HeaderText = "Số lượng";
				TextCol.Width = 40;
				TextCol.Format="###,###,###.##";
				TextCol.Alignment=HorizontalAlignment.Right;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de,6);
				TextCol.MappingName = "giamua";
				TextCol.HeaderText = "Đơn giá";
				TextCol.Width = 60;
				TextCol.Format="###,###,###.##";
				TextCol.Alignment=HorizontalAlignment.Right;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de,7);
				TextCol.MappingName = "sotien";
				TextCol.HeaderText = "Số tiền";
				TextCol.Width = 80;
				TextCol.Format="###,###,###,###.##";
				TextCol.Alignment=HorizontalAlignment.Right;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);
			}
			else if (theo.SelectedIndex==6)
			{
				string ngay;
				int i=3;
				for(;i<dsxml.Tables[0].Columns.Count-2;i++)
				{
					ngay=dsxml.Tables[0].Columns[i].ColumnName.ToString().Substring(1);
					TextCol=new DataGridColoredTextBoxColumn(de, i);
					TextCol.MappingName = dsxml.Tables[0].Columns[i].ColumnName.ToString();
					TextCol.HeaderText = ngay.Substring(4,2)+"/"+ngay.Substring(2,2)+"/"+ngay.Substring(0,2);
					TextCol.Format="#,###,###.##";
					TextCol.Alignment=HorizontalAlignment.Right;
					TextCol.Width = 50;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);
				}
				TextCol=new DataGridColoredTextBoxColumn(de, i+1);
				TextCol.MappingName = "tyle";
				TextCol.HeaderText = "Tỷ lệ";
				TextCol.Width = 35;
				TextCol.Format="###.##";
				TextCol.Alignment=HorizontalAlignment.Right;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, i+2);
				TextCol.MappingName = "ghichu";
				TextCol.HeaderText = "Ghi chú";
				TextCol.Width = 50;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);
			}
			else
			{
				if (rb1.Checked || rb3.Checked)
				{
					TextCol=new DataGridColoredTextBoxColumn(de, 3);
					TextCol.MappingName = "n_so";
					TextCol.HeaderText = (i_dang!=0)?"SL":"Số";
					TextCol.Width =30;
					TextCol.Format="#,###,###";
					TextCol.Alignment=HorizontalAlignment.Right;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);
			
					TextCol=new DataGridColoredTextBoxColumn(de, 4);
					TextCol.MappingName = "n_so_tl";
					TextCol.HeaderText = "%";
					TextCol.Width = 35;
					TextCol.Format="#,###,###.##";
					TextCol.Alignment=HorizontalAlignment.Right;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);

					TextCol=new DataGridColoredTextBoxColumn(de, 5);
					TextCol.MappingName = "n_tien";
					TextCol.HeaderText = "Số tiền nhập";
					TextCol.Width = 85;
					TextCol.Format="#,###,###.##";
					TextCol.Alignment=HorizontalAlignment.Right;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);

					TextCol=new DataGridColoredTextBoxColumn(de, 6);
					TextCol.MappingName = "n_tien_tl";
					TextCol.HeaderText = "%";
					TextCol.Width = 35;
					TextCol.Format="#,###,###.##";
					TextCol.Alignment=HorizontalAlignment.Right;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);
				}
				if (rb2.Checked || rb3.Checked)
				{
					TextCol=new DataGridColoredTextBoxColumn(de, 7);
					TextCol.MappingName = "x_so";
					TextCol.HeaderText = (i_dang!=0)?"SL":"Số";
					TextCol.Width =30;
					TextCol.Format="#,###,###";
					TextCol.Alignment=HorizontalAlignment.Right;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);
			
					TextCol=new DataGridColoredTextBoxColumn(de, 8);
					TextCol.MappingName = "x_so_tl";
					TextCol.HeaderText = "%";
					TextCol.Width = 35;
					TextCol.Format="#,###,###.##";
					TextCol.Alignment=HorizontalAlignment.Right;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);

					TextCol=new DataGridColoredTextBoxColumn(de, 9);
					TextCol.MappingName = "x_tien";
					TextCol.HeaderText = "Số tiền xuất";
					TextCol.Width = 85;
					TextCol.Format="#,###,###.##";
					TextCol.Alignment=HorizontalAlignment.Right;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);

					TextCol=new DataGridColoredTextBoxColumn(de, 10);
					TextCol.MappingName = "x_tien_tl";
					TextCol.HeaderText = "%";
					TextCol.Width = 35;
					TextCol.Format="#,###,###.##";
					TextCol.Alignment=HorizontalAlignment.Right;
					ts.GridColumnStyles.Add(TextCol);
					dataGrid1.TableStyles.Add(ts);
				}
			}
		}

		private void get_data()
		{
			s_maloai="";s_manhom="";
			i_mabd=0;
			if (mabd.Text!="")
			{
				DataRow r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
				if (r!=null) i_mabd=int.Parse(r["id"].ToString());
			}
			for(int i=0;i<manhom.Items.Count;i++)
				if (manhom.GetItemChecked(i)) s_manhom+=dtnhom.Rows[i]["id"].ToString().Trim()+",";
			for(int i=0;i<maloai.Items.Count;i++)
				if (maloai.GetItemChecked(i)) s_maloai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
			sql="";
			if (i_mabd!=0) sql+=" and c.id="+i_mabd;
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_maloai!="") sql+=" and c.maloai in ("+s_maloai.Substring(0,s_maloai.Length-1)+")";
			
			Cursor=Cursors.WaitCursor;
			i_dang=0;
			switch (theo.SelectedIndex)
			{
				case 0: dsxml=d.get_0(i_nhom,tu.Text,den.Text,dtnhombc,(rb1.Checked)?0:(rb2.Checked)?1:2);
						break;
				case 1: dsxml=d.get_1(i_nhom,tu.Text,den.Text,dtdmbd,(rb1.Checked)?0:(rb2.Checked)?1:2,sql);
						i_dang=30;
						break;
				case 2: dsxml=d.get_2(i_nhom,tu.Text,den.Text,dtnhom,(rb1.Checked)?0:(rb2.Checked)?1:2,sql);
					break;
				case 3: dsxml=d.get_3(i_nhom,tu.Text,den.Text,d.get_data("select * from "+user+".d_dmhang where nhom="+i_nhom).Tables[0],(rb1.Checked)?0:(rb2.Checked)?1:2,sql);
					break;
				case 4: dsxml=d.get_4(i_nhom,tu.Text,den.Text,d.get_data("select * from "+user+".d_dmnx where nhom="+i_nhom).Tables[0],sql);
					break;
				case 5: dsxml=d.get_5(i_nhom,s_mmyy,yyyy.Value.ToString().PadLeft(0,'4').Substring(2,2),sql);
					i_dang=30;
					break;
				case 6: dsxml=d.get_6(i_nhom,tu.Text,den.Text,sql);
					i_dang=30;
					break;
				case 7: dsxml=d.get_7(i_nhom,s_mmyy,mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(0,'4').Substring(2,2),sql,"");
					i_dang=30;
					break;
				case 8: dsxml=d.get_8(i_nhom,tu.Text,den.Text,(rb1.Checked)?0:(rb2.Checked)?1:2,sql);
					break;
				case 9: dsxml=d.get_9(i_nhom,tu.Text,den.Text,d.get_data("select * from "+user+".d_duockp where nhom like '%"+i_nhom.ToString().Trim()+",%'").Tables[0],sql);
					break;
			}
			Cursor=Cursors.Default;
		}

		private void butTonghop_Click(object sender, System.EventArgs e)
		{
			get_data();
			foreach(System.Windows.Forms.Control c in this.Controls) if (c.Name=="dataGrid1") this.Controls.Remove(c);
			dataGrid1=new System.Windows.Forms.DataGrid();
			dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			dataGrid1.DataMember = "";
			dataGrid1.FlatMode = true;
			dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
			dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			dataGrid1.CaptionText=(theo.SelectedIndex==5 || theo.SelectedIndex==6 || theo.SelectedIndex==7)?theo.Text:(rb1.Checked)?"Nhập":(rb2.Checked)?"Xuất":"Nhập                                                                                                           Xuất";
			dataGrid1.Location = new System.Drawing.Point(210,50);
			dataGrid1.Name = "dataGrid1";
			dataGrid1.RowHeaderWidth = 5;
			dataGrid1.Size = new System.Drawing.Size(578, 440);
			dataGrid1.TabIndex = 5;
			dataGrid1.DataSource=dsxml.Tables[0];
			AddGridTableStyle();
			this.Controls.Add(dataGrid1);
		}

		private void theo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==theo)
			{
				nhapxuat.Enabled=theo.SelectedIndex!=4 && theo.SelectedIndex!=9 && theo.SelectedIndex!=6 && theo.SelectedIndex!=5 && theo.SelectedIndex!=7;
				mm.Enabled=theo.SelectedIndex==7;
				yyyy.Enabled=theo.SelectedIndex==7 || theo.SelectedIndex==5;
				if (theo.SelectedIndex==4) rb1.Checked=true;
				if (theo.SelectedIndex==9) rb2.Checked=true;
			}
		}

		private void bieudo_CheckedChanged(object sender, System.EventArgs e)
		{
            //dothi.Visible=bieudo.Checked;
			try
			{
				if (bieudo.Checked && dsxml.Tables[0].Rows.Count>0)
				{
					DataSet dstmp=dsxml.Copy();
					dstmp.Clear();
					dstmp.Merge(dsxml.Tables[0].Select("id<>0"));
                    //dothi.Title=theo.Text.ToString().ToUpper();
					if (theo.SelectedIndex==7 || theo.SelectedIndex==5 || theo.SelectedIndex==6) return;
                    //else dothi.SetY1Y2_Xfield(dstmp,"TEN","N_TIEN","X_TIEN","Tiền nhập","Tiền xuất");
                    //dothi.XAxis_Title="";//(i_dang!=0)?"Tên thuốc - hàm lượng":"Nội dung";
				}
			}
			catch{}
		}
	}
}
