using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi; 

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmTkvaovien.
	/// </summary>
	public class frmTkpttt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.ComboBox madantoc;
		private System.Windows.Forms.ComboBox mann;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.ComboBox maphuongxa;
		private MaskedTextBox.MaskedTextBox mabn;
		private MaskedTextBox.MaskedTextBox hoten;
		private MaskedTextBox.MaskedTextBox sonha;
		private MaskedTextBox.MaskedTextBox thon;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox makp;
		private MaskedTextBox.MaskedTextBox sovaovien;
		private DataSet ds=new DataSet();
		private AccessData m;
		private bool bClear=true;
		private System.Windows.Forms.Label lbl;
		private MaskedTextBox.MaskedTextBox mapt;
		private System.Windows.Forms.ComboBox tuvong;
		private System.Windows.Forms.ComboBox taibien;
		private System.Windows.Forms.ComboBox tinhhinh;
		private System.Windows.Forms.ComboBox tenbs;
		private System.Windows.Forms.ComboBox tenphuongphap;
		private System.Windows.Forms.ComboBox loaipt;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.ComboBox comboBox2;
		private MaskedBox.MaskedBox ngaysinh;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.ComboBox dotuoi;
		private System.Windows.Forms.Label label6;
		private LibList.List listpttt;
		private System.Windows.Forms.TextBox tenpt;
		private System.Windows.Forms.ComboBox nguoidung;
		private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox time;
        private CheckBox chkmonoisoi;
        private CheckBox chkmolai;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTkpttt(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkpttt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.madantoc = new System.Windows.Forms.ComboBox();
            this.mann = new System.Windows.Forms.ComboBox();
            this.maqu = new System.Windows.Forms.ComboBox();
            this.matt = new System.Windows.Forms.ComboBox();
            this.maphuongxa = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.thon = new MaskedTextBox.MaskedTextBox();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.mapt = new MaskedTextBox.MaskedTextBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.tuvong = new System.Windows.Forms.ComboBox();
            this.taibien = new System.Windows.Forms.ComboBox();
            this.tinhhinh = new System.Windows.Forms.ComboBox();
            this.tenbs = new System.Windows.Forms.ComboBox();
            this.tenphuongphap = new System.Windows.Forms.ComboBox();
            this.loaipt = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.dotuoi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listpttt = new LibList.List();
            this.tenpt = new System.Windows.Forms.TextBox();
            this.nguoidung = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.CheckBox();
            this.chkmonoisoi = new System.Windows.Forms.CheckBox();
            this.chkmolai = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(116, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(266, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(369, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(558, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(0, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giới tính :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(140, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số nhà :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(250, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Thôn, phố :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madantoc
            // 
            this.madantoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(720, 28);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(64, 21);
            this.madantoc.TabIndex = 10;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(504, 28);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(152, 21);
            this.mann.TabIndex = 9;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(314, 51);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(120, 21);
            this.maqu.TabIndex = 12;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(64, 51);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(168, 21);
            this.matt.TabIndex = 11;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(504, 51);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(152, 21);
            this.maphuongxa.TabIndex = 13;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(433, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "Phường/Xã :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(234, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 54;
            this.label17.Text = "Quận/Huyện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(8, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tỉnh/TP :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(427, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "Nghề nghiệp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(662, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 56;
            this.label11.Text = "Dân tộc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(-14, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 57;
            this.label12.Text = "Kh./Phòng  :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 74);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(136, 21);
            this.makp.TabIndex = 15;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(646, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 23);
            this.label13.TabIndex = 59;
            this.label13.Text = "Số VV :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(205, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 23);
            this.label14.TabIndex = 60;
            this.label14.Text = "Phương pháp PTTT :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(630, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 23);
            this.label20.TabIndex = 63;
            this.label20.Text = "Đối tượng :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(314, 5);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 2;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(416, 5);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(143, 21);
            this.hoten.TabIndex = 3;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(64, 28);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(64, 21);
            this.phai.TabIndex = 6;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // sonha
            // 
            this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(186, 28);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(64, 21);
            this.sonha.TabIndex = 7;
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(314, 28);
            this.thon.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.thon.MaxLength = 50;
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(120, 21);
            this.thon.TabIndex = 8;
            // 
            // sovaovien
            // 
            this.sovaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(720, 51);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 10;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(64, 21);
            this.sovaovien.TabIndex = 14;
            // 
            // mapt
            // 
            this.mapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapt.Location = new System.Drawing.Point(314, 74);
            this.mapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapt.MaxLength = 6;
            this.mapt.Name = "mapt";
            this.mapt.Size = new System.Drawing.Size(46, 21);
            this.mapt.TabIndex = 16;
            this.mapt.Validated += new System.EventHandler(this.mapt_Validated);
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(720, 74);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(64, 21);
            this.madoituong.TabIndex = 18;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 145);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 340);
            this.dataGrid1.TabIndex = 23;
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.BackColor = System.Drawing.Color.Transparent;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(290, 492);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 25;
            this.butTim.Text = "     &Tìm";
            this.butTim.UseVisualStyleBackColor = false;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(361, 492);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 26;
            this.butIn.Text = "     &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(432, 492);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 27;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(8, 488);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(248, 23);
            this.lbl.TabIndex = 65;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tuvong
            // 
            this.tuvong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tuvong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuvong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuvong.Location = new System.Drawing.Point(720, 121);
            this.tuvong.Name = "tuvong";
            this.tuvong.Size = new System.Drawing.Size(64, 21);
            this.tuvong.TabIndex = 23;
            this.tuvong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuvong_KeyDown);
            // 
            // taibien
            // 
            this.taibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.taibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taibien.Location = new System.Drawing.Point(552, 120);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(104, 21);
            this.taibien.TabIndex = 22;
            this.taibien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.taibien_KeyDown);
            // 
            // tinhhinh
            // 
            this.tinhhinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhhinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhhinh.Location = new System.Drawing.Point(552, 97);
            this.tinhhinh.Name = "tinhhinh";
            this.tinhhinh.Size = new System.Drawing.Size(104, 21);
            this.tinhhinh.TabIndex = 21;
            this.tinhhinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhhinh_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(64, 97);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(136, 21);
            this.tenbs.TabIndex = 19;
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // tenphuongphap
            // 
            this.tenphuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphuongphap.Location = new System.Drawing.Point(314, 97);
            this.tenphuongphap.Name = "tenphuongphap";
            this.tenphuongphap.Size = new System.Drawing.Size(188, 21);
            this.tenphuongphap.TabIndex = 20;
            this.tenphuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenphuongphap_KeyDown);
            // 
            // loaipt
            // 
            this.loaipt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loaipt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaipt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaipt.Location = new System.Drawing.Point(720, 97);
            this.loaipt.Name = "loaipt";
            this.loaipt.Size = new System.Drawing.Size(64, 21);
            this.loaipt.TabIndex = 24;
            this.loaipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaipt_KeyDown);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(664, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 23);
            this.label22.TabIndex = 69;
            this.label22.Text = "Tử vong :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(478, 119);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 23);
            this.label21.TabIndex = 68;
            this.label21.Text = "Tai biến :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(-24, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 23);
            this.label15.TabIndex = 67;
            this.label15.Text = "PTTT viên :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(678, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 23);
            this.label19.TabIndex = 66;
            this.label19.Text = "Loại :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(493, 97);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 23);
            this.label23.TabIndex = 77;
            this.label23.Text = "Tình hình :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(198, 97);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(120, 23);
            this.label24.TabIndex = 76;
            this.label24.Text = "Phương pháp vô cảm :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.Location = new System.Drawing.Point(64, 97);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(136, 21);
            this.comboBox2.TabIndex = 19;
            // 
            // ngaysinh
            // 
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(618, 5);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(64, 21);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(186, 5);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 1;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(64, 5);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // dotuoi
            // 
            this.dotuoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dotuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotuoi.Location = new System.Drawing.Point(720, 5);
            this.dotuoi.Name = "dotuoi";
            this.dotuoi.Size = new System.Drawing.Size(64, 21);
            this.dotuoi.TabIndex = 5;
            this.dotuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dotuoi_KeyDown);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(678, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 23);
            this.label6.TabIndex = 79;
            this.label6.Text = "Tuổi :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(656, 512);
            this.listpttt.MatchBufferTimeOut = 1000;
            this.listpttt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listpttt.Name = "listpttt";
            this.listpttt.Size = new System.Drawing.Size(75, 17);
            this.listpttt.TabIndex = 81;
            this.listpttt.TextIndex = -1;
            this.listpttt.TextMember = null;
            this.listpttt.ValueIndex = -1;
            this.listpttt.Visible = false;
            this.listpttt.Validated += new System.EventHandler(this.listpttt_Validated);
            // 
            // tenpt
            // 
            this.tenpt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpt.Location = new System.Drawing.Point(361, 74);
            this.tenpt.Name = "tenpt";
            this.tenpt.Size = new System.Drawing.Size(295, 21);
            this.tenpt.TabIndex = 17;
            this.tenpt.TextChanged += new System.EventHandler(this.tenpt_TextChanged);
            this.tenpt.Validated += new System.EventHandler(this.tenpt_Validated);
            this.tenpt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpt_KeyDown);
            // 
            // nguoidung
            // 
            this.nguoidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoidung.Location = new System.Drawing.Point(314, 120);
            this.nguoidung.Name = "nguoidung";
            this.nguoidung.Size = new System.Drawing.Size(188, 21);
            this.nguoidung.TabIndex = 82;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(230, 121);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(88, 23);
            this.label25.TabIndex = 83;
            this.label25.Text = "Người nhập :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.time.Location = new System.Drawing.Point(65, 125);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(184, 16);
            this.time.TabIndex = 84;
            this.time.Text = "checkBox1";
            // 
            // chkmonoisoi
            // 
            this.chkmonoisoi.AutoSize = true;
            this.chkmonoisoi.Location = new System.Drawing.Point(64, 145);
            this.chkmonoisoi.Name = "chkmonoisoi";
            this.chkmonoisoi.Size = new System.Drawing.Size(74, 17);
            this.chkmonoisoi.TabIndex = 85;
            this.chkmonoisoi.Text = "Mổ nội soi";
            this.chkmonoisoi.UseVisualStyleBackColor = true;
            // 
            // chkmolai
            // 
            this.chkmolai.AutoSize = true;
            this.chkmolai.Location = new System.Drawing.Point(151, 145);
            this.chkmolai.Name = "chkmolai";
            this.chkmolai.Size = new System.Drawing.Size(98, 17);
            this.chkmolai.TabIndex = 86;
            this.chkmolai.Text = "Mổ lại miễn phí";
            this.chkmolai.UseVisualStyleBackColor = true;
            // 
            // frmTkpttt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkmolai);
            this.Controls.Add(this.chkmonoisoi);
            this.Controls.Add(this.tenpt);
            this.Controls.Add(this.tinhhinh);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.time);
            this.Controls.Add(this.nguoidung);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.listpttt);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.dotuoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.tenphuongphap);
            this.Controls.Add(this.mapt);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tuvong);
            this.Controls.Add(this.loaipt);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTkpttt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách bệnh nhân phẫu thuật / thủ thuật";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTkpttt_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTkpttt_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTkpttt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkpttt_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			time.Text="Giờ báo cáo "+m.sGiobaocao;
			nguoidung.DisplayMember="HOTEN";
			nguoidung.ValueMember="ID";
			nguoidung.DataSource=m.get_data("select * from "+m.user+".dlogin").Tables[0];

			DataSet dsd=new DataSet();
			dotuoi.DisplayMember="ten";
			dotuoi.ValueMember="ma";
			dsd.ReadXml("..//..//..//xml//dotuoi.xml");
			dotuoi.DataSource=dsd.Tables[0];

			listpttt.DisplayMember="NOI_DUNG";
			listpttt.ValueMember="NOI_DUNG";
            listpttt.DataSource = m.get_data("select MAPT,NOI_DUNG,DACBIET,LOAI1,LOAI2,LOAI3 from " + m.user + ".dmpttt").Tables[0];

			tenbs.DisplayMember="HOTEN";
			tenbs.ValueMember="MA";
            tenbs.DataSource = m.get_data("select * from " + m.user + ".dmbs order by ma").Tables[0];

			tenphuongphap.DisplayMember="TEN";
			tenphuongphap.ValueMember="MA";
            tenphuongphap.DataSource = m.get_data("select * from " + m.user + ".dmmete order by ma").Tables[0];

			loaipt.DisplayMember="TEN";
			loaipt.ValueMember="MA";
            loaipt.DataSource = m.get_data("select * from " + m.user + ".loaipttt order by ma").Tables[0];

			taibien.DisplayMember="TEN";
			taibien.ValueMember="MA";
            taibien.DataSource = m.get_data("select * from " + m.user + ".taibienpt order by ma").Tables[0];

			tinhhinh.DisplayMember="TEN";
			tinhhinh.ValueMember="MA";
            tinhhinh.DataSource = m.get_data("select * from " + m.user + ".tinhhinhpt order by ma").Tables[0];
			
			tuvong.DisplayMember="TEN";
			tuvong.ValueMember="MA";
            tuvong.DataSource = m.get_data("select * from " + m.user + ".tuvongpt order by ma").Tables[0];

			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            makp.DataSource = m.get_data("select * from " + m.user + ".btdkp_bv order by loai,makp").Tables[0];

			mann.DisplayMember="TENNN";
			mann.ValueMember="MANN";
            mann.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv order by mann").Tables[0];

			madantoc.DisplayMember="DANTOC";
			madantoc.ValueMember="MADANTOC";
            madantoc.DataSource = m.get_data("select * from " + m.user + ".btddt order by madantoc").Tables[0];

			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + m.user + ".btdtt order by matt").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";
			
			maphuongxa.DisplayMember="TENPXA";
			maphuongxa.ValueMember="MAPHUONGXA";

			load_quan();
			load_pxa();

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select * from " + m.user + ".doituong order by madoituong").Tables[0];

            ds = m.get_data("select * from " + m.user + ".capid where ma=0");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;
		}


		private void emp_text()
		{
			makp.SelectedIndex=-1;
			mann.SelectedIndex=-1;
			madantoc.SelectedIndex=-1;
			matt.SelectedIndex=-1;
			maqu.SelectedIndex=-1;
			maphuongxa.SelectedIndex=-1;
			madoituong.SelectedIndex=-1;
			tenbs.SelectedIndex=-1;
			tenphuongphap.SelectedIndex=-1;
			loaipt.SelectedIndex=-1;
			taibien.SelectedIndex=-1;
			tinhhinh.SelectedIndex=-1;
			tuvong.SelectedIndex=-1;
			dotuoi.SelectedIndex=-1;
			nguoidung.SelectedIndex=-1;
		}

		private void load_quan()
		{
			try
			{
                maqu.DataSource = m.get_data("select * from " + m.user + ".btdquan where matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
			}
			catch{}
		}

		private void load_pxa()
		{
			try
			{
                maphuongxa.DataSource = m.get_data("select * from " + m.user + ".btdpxa where maqu='" + maqu.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
			}
			catch{}
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void mann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void madantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maqu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maphuongxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhantu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dentu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (tu.Text=="")
			{
				den.Text="";
				return;
			}
			tu.Text=tu.Text.Trim();
			if (!m.bNgay(tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				tu.Focus();
				return;
			}
			tu.Text=m.Ktngaygio(tu.Text,10);
            if (den.Text == "") den.Text = tu.Text;
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (den.Text=="")
			{	
				tu.Text="";
				return;
			}
			den.Text=den.Text.Trim();
			if (!m.bNgay(den.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				den.Focus();
				return;
			}
			den.Text=m.Ktngaygio(den.Text,10);
			if (tu.Text=="")
			{
				tu.Focus();
				return;
			}
			if (!m.bNgay(den.Text,tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"));
				den.Focus();
				return;
			}
		}

		private void ngaysinh_Validated(object sender, System.EventArgs e)
		{
			if (ngaysinh.Text=="") return;
			ngaysinh.Text=ngaysinh.Text.Trim();
			if (!m.bNgay(ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			ngaysinh.Text=m.Ktngaygio(ngaysinh.Text,10);
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
            if (tu.Text.Length != 10 || den.Text.Length != 10)
            {
                tu.Focus();
                return;
            }

			int i_userid=(nguoidung.SelectedIndex==-1)?-1:int.Parse(nguoidung.SelectedValue.ToString());
			ds=m.get_pttt("benhandt",tu.Text,den.Text,mabn.Text,hoten.Text,ngaysinh.Text,phai.SelectedIndex,sonha.Text,thon.Text,
				(mann.SelectedIndex==-1)?"":mann.SelectedValue.ToString(),(madantoc.SelectedIndex==-1)?"":madantoc.SelectedValue.ToString(),
				(matt.SelectedIndex==-1)?"":matt.SelectedValue.ToString(),(maqu.SelectedIndex==-1)?"":maqu.SelectedValue.ToString(),
				(maphuongxa.SelectedIndex==-1)?"":maphuongxa.SelectedValue.ToString(),(makp.SelectedIndex==-1)?"":makp.SelectedValue.ToString(),
				sovaovien.Text,(madoituong.SelectedIndex==-1)?"":madoituong.SelectedValue.ToString(),mapt.Text,(tenbs.SelectedIndex==-1)?"":tenbs.SelectedValue.ToString(),
				(tenphuongphap.SelectedIndex==-1)?"":tenphuongphap.SelectedValue.ToString(),(tinhhinh.SelectedIndex==-1)?"":tinhhinh.SelectedValue.ToString(),
				(loaipt.SelectedIndex==-1)?"":loaipt.SelectedValue.ToString(),(taibien.SelectedIndex==-1)?"":taibien.SelectedValue.ToString(),
				(tuvong.SelectedIndex==-1)?"":tuvong.SelectedValue.ToString(),(dotuoi.SelectedIndex==-1)?"":dotuoi.SelectedValue.ToString(),i_userid,time.Checked,(chkmonoisoi.Checked)?1:0,(chkmolai.Checked)?1:0);
            ds.Merge(m.get_pttt("benhanngtr", tu.Text, den.Text, mabn.Text, hoten.Text, ngaysinh.Text, phai.SelectedIndex, sonha.Text, thon.Text,
                (mann.SelectedIndex == -1) ? "" : mann.SelectedValue.ToString(), (madantoc.SelectedIndex == -1) ? "" : madantoc.SelectedValue.ToString(),
                (matt.SelectedIndex == -1) ? "" : matt.SelectedValue.ToString(), (maqu.SelectedIndex == -1) ? "" : maqu.SelectedValue.ToString(),
                (maphuongxa.SelectedIndex == -1) ? "" : maphuongxa.SelectedValue.ToString(), (makp.SelectedIndex == -1) ? "" : makp.SelectedValue.ToString(),
                sovaovien.Text, (madoituong.SelectedIndex == -1) ? "" : madoituong.SelectedValue.ToString(), mapt.Text, (tenbs.SelectedIndex == -1) ? "" : tenbs.SelectedValue.ToString(),
                (tenphuongphap.SelectedIndex == -1) ? "" : tenphuongphap.SelectedValue.ToString(), (tinhhinh.SelectedIndex == -1) ? "" : tinhhinh.SelectedValue.ToString(),
                (loaipt.SelectedIndex == -1) ? "" : loaipt.SelectedValue.ToString(), (taibien.SelectedIndex == -1) ? "" : taibien.SelectedValue.ToString(),
                (tuvong.SelectedIndex == -1) ? "" : tuvong.SelectedValue.ToString(), (dotuoi.SelectedIndex == -1) ? "" : dotuoi.SelectedValue.ToString(), i_userid, time.Checked, (chkmonoisoi.Checked) ? 1 : 0, (chkmolai.Checked) ? 1 : 0));
            ds.Merge(m.get_pttt_mmyy("tiepdon", tu.Text, den.Text, mabn.Text, hoten.Text, ngaysinh.Text, phai.SelectedIndex, sonha.Text, thon.Text,
                (mann.SelectedIndex == -1) ? "" : mann.SelectedValue.ToString(), (madantoc.SelectedIndex == -1) ? "" : madantoc.SelectedValue.ToString(),
                (matt.SelectedIndex == -1) ? "" : matt.SelectedValue.ToString(), (maqu.SelectedIndex == -1) ? "" : maqu.SelectedValue.ToString(),
                (maphuongxa.SelectedIndex == -1) ? "" : maphuongxa.SelectedValue.ToString(), (makp.SelectedIndex == -1) ? "" : makp.SelectedValue.ToString(),
                sovaovien.Text, (madoituong.SelectedIndex == -1) ? "" : madoituong.SelectedValue.ToString(), mapt.Text, (tenbs.SelectedIndex == -1) ? "" : tenbs.SelectedValue.ToString(),
                (tenphuongphap.SelectedIndex == -1) ? "" : tenphuongphap.SelectedValue.ToString(), (tinhhinh.SelectedIndex == -1) ? "" : tinhhinh.SelectedValue.ToString(),
                (loaipt.SelectedIndex == -1) ? "" : loaipt.SelectedValue.ToString(), (taibien.SelectedIndex == -1) ? "" : taibien.SelectedValue.ToString(),
                (tuvong.SelectedIndex == -1) ? "" : tuvong.SelectedValue.ToString(), (dotuoi.SelectedIndex == -1) ? "" : dotuoi.SelectedValue.ToString(), i_userid, time.Checked, 4, (chkmonoisoi.Checked) ? 1 : 0, (chkmolai.Checked) ? 1 : 0));
            ds.Merge(m.get_pttt_mmyy("benhanpk", tu.Text, den.Text, mabn.Text, hoten.Text, ngaysinh.Text, phai.SelectedIndex, sonha.Text, thon.Text,
                (mann.SelectedIndex == -1) ? "" : mann.SelectedValue.ToString(), (madantoc.SelectedIndex == -1) ? "" : madantoc.SelectedValue.ToString(),
                (matt.SelectedIndex == -1) ? "" : matt.SelectedValue.ToString(), (maqu.SelectedIndex == -1) ? "" : maqu.SelectedValue.ToString(),
                (maphuongxa.SelectedIndex == -1) ? "" : maphuongxa.SelectedValue.ToString(), (makp.SelectedIndex == -1) ? "" : makp.SelectedValue.ToString(),
                sovaovien.Text, (madoituong.SelectedIndex == -1) ? "" : madoituong.SelectedValue.ToString(), mapt.Text, (tenbs.SelectedIndex == -1) ? "" : tenbs.SelectedValue.ToString(),
                (tenphuongphap.SelectedIndex == -1) ? "" : tenphuongphap.SelectedValue.ToString(), (tinhhinh.SelectedIndex == -1) ? "" : tinhhinh.SelectedValue.ToString(),
                (loaipt.SelectedIndex == -1) ? "" : loaipt.SelectedValue.ToString(), (taibien.SelectedIndex == -1) ? "" : taibien.SelectedValue.ToString(),
                (tuvong.SelectedIndex == -1) ? "" : tuvong.SelectedValue.ToString(), (dotuoi.SelectedIndex == -1) ? "" : dotuoi.SelectedValue.ToString(), i_userid, time.Checked, 2,(chkmonoisoi.Checked) ? 1 : 0, (chkmolai.Checked) ? 1 : 0));
            ds.Merge(m.get_pttt_mmyy("benhancc", tu.Text, den.Text, mabn.Text, hoten.Text.Replace("'", "''"), ngaysinh.Text, phai.SelectedIndex, sonha.Text, thon.Text.Replace("'", "''"),
                (mann.SelectedIndex == -1) ? "" : mann.SelectedValue.ToString(), (madantoc.SelectedIndex == -1) ? "" : madantoc.SelectedValue.ToString(),
                (matt.SelectedIndex == -1) ? "" : matt.SelectedValue.ToString(), (maqu.SelectedIndex == -1) ? "" : maqu.SelectedValue.ToString(),
                (maphuongxa.SelectedIndex == -1) ? "" : maphuongxa.SelectedValue.ToString(), (makp.SelectedIndex == -1) ? "" : makp.SelectedValue.ToString(),
                sovaovien.Text, (madoituong.SelectedIndex == -1) ? "" : madoituong.SelectedValue.ToString(), mapt.Text, (tenbs.SelectedIndex == -1) ? "" : tenbs.SelectedValue.ToString(),
                (tenphuongphap.SelectedIndex == -1) ? "" : tenphuongphap.SelectedValue.ToString(), (tinhhinh.SelectedIndex == -1) ? "" : tinhhinh.SelectedValue.ToString(),
                (loaipt.SelectedIndex == -1) ? "" : loaipt.SelectedValue.ToString(), (taibien.SelectedIndex == -1) ? "" : taibien.SelectedValue.ToString(),
                (tuvong.SelectedIndex == -1) ? "" : tuvong.SelectedValue.ToString(), (dotuoi.SelectedIndex == -1) ? "" : dotuoi.SelectedValue.ToString(), i_userid, time.Checked, 3,(chkmonoisoi.Checked) ? 1 : 0, (chkmolai.Checked) ? 1 : 0));
            dataGrid1.DataSource=ds.Tables[0];
			lbl.Text="TỔNG SỐ : "+ds.Tables[0].Rows.Count.ToString();
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
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
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa/Phòng";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sovaovien";
			TextCol.HeaderText = "Số vào viện";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 120;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tuoi";
			TextCol.HeaderText = "Tuổi";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sonha";
			TextCol.HeaderText = "Số nhà";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thon";
			TextCol.HeaderText = "Thôn đường";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenpxa";
			TextCol.HeaderText = "Phường/Xã";
			TextCol.Width = 120;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenquan";
			TextCol.HeaderText = "Quận/Huyện";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tentt";
			TextCol.HeaderText = "Tỉnh/Thành phố";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennn";
			TextCol.HeaderText = "Nghề nghiệp";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày giờ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "noichuyen";
            TextCol.HeaderText = "Nơi chuyển";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenpt";
			TextCol.HeaderText = "Phương pháp phẫu thuật/thủ thuật";
			TextCol.Width = 300;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mapt";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "PTTT viên";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loaipt";
			TextCol.HeaderText = "Loại PTTT";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "phuongphap";
			TextCol.HeaderText = "Phương pháp vô cảm";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tinhhinh";
			TextCol.HeaderText = "Tình hình";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "taibien";
			TextCol.HeaderText = "Tai biến";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tuvong";
			TextCol.HeaderText = "Tử vong";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenuser";
			TextCol.HeaderText = "Người nhập";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
					return;
				}
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,this.Text.ToUpper(),"rptTkpttt.rpt");
				f.ShowDialog();
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_quan();
		}

		private void maqu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_pxa();
		}

		private void frmTkpttt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
		}

		private void frmTkpttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void mapt_Validated(object sender, System.EventArgs e)
		{
			if (mapt.Text=="")
			{
				tenpt.Text="";
				return;
			}
			string s=m.get_tenpt(mapt.Text).Trim();
			if (s!="") tenpt.Text=s.Substring(1);
			else tenpt.Text="";
			if (tenpt.Text=="" && mapt.Text!="")
			{
                dllDanhmucMedisoft.frmDmpttt f = new dllDanhmucMedisoft.frmDmpttt(m, mapt.Text, tenpt.Text, true);
				f.ShowDialog();
				if (f.m_mapt!="")
				{
					tenpt.Text=f.m_tenpt;
					mapt.Text=f.m_mapt;
				}
			}		
		}

		private void loaipt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenphuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tinhhinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void taibien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tuvong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void dotuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenpt_Validated(object sender, System.EventArgs e)
		{
			string s=m.get_mapt(tenpt.Text);
			if (s!="") mapt.Text=s.Substring(1);
			if(!listpttt.Focused)listpttt.Hide();
		}

		private void tenpt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listpttt.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listpttt.Visible)
				{
					listpttt.Focus();
					SendKeys.Send("{Down}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenpt_TextChanged(object sender, System.EventArgs e)
		{
			Filt_pttt(tenpt.Text);
			listpttt.BrowseToText(tenpt,mapt,madoituong);		
		}

		private void Filt_pttt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listpttt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="NOI_DUNG LIKE '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void listpttt_Validated(object sender, System.EventArgs e)
		{
			if (mapt.Text=="" && tenpt.Text!="")
				mapt.Text=m.get_mapt(tenpt.Text).Trim().Substring(1);
		}
	}
}
