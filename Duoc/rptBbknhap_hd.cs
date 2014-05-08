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
	/// Summary description for rptBbknhap.
	/// </summary>
	public class rptBbknhap_hd : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker den;
		private AccessData d;
        private DataView dv;
        private int i_nhom, i_madv, i_makho, i_userid=0;
		private bool bClear=true;
        private string stime, user, xxx, sql, s_tongcong, dau, s_kho, tenfile, so, s_sohd, s_ngayhd, s_nghd, s_ngsp, s_manhom = "";
		private decimal sotien;
		private DataRow r,r1,r2,r3,r4,r5,r6,r7,r8;
		private DataSet ds=new DataSet();
		private DataSet dsst=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtnhom=new DataTable();
		private DataTable dtnuoc=new DataTable();
		private DataTable dtnhombc=new DataTable();
		private DataTable dtnhomnuoc=new DataTable();
		private DataTable dtdmnx=new DataTable();
		private DataSet dssohd;
        private MaskedTextBox.MaskedTextBox c1;
		private MaskedTextBox.MaskedTextBox c3;
		private MaskedTextBox.MaskedTextBox c4;
		private MaskedTextBox.MaskedTextBox c5;
		private MaskedTextBox.MaskedTextBox c6;
        private MaskedTextBox.MaskedTextBox c7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
		private MaskedTextBox.MaskedTextBox c11;
		private System.Windows.Forms.ComboBox kho;
        private System.Windows.Forms.Label label12;
		private MaskedTextBox.MaskedTextBox c17;
		private MaskedTextBox.MaskedTextBox c16;
		private MaskedTextBox.MaskedTextBox c15;
		private MaskedTextBox.MaskedTextBox c14;
		private MaskedTextBox.MaskedTextBox c13;
		private MaskedTextBox.MaskedTextBox c12;
		private System.Windows.Forms.TextBox tendv;
		private System.Windows.Forms.TextBox madv;
        private LibList.List listNX;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox noingoai;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private MaskedTextBox.MaskedTextBox bbkiem;
		private System.Windows.Forms.CheckedListBox sohd;
		private System.Windows.Forms.Button butLoc;
		private System.Windows.Forms.CheckBox chkngay;
        private CheckBox chkXml;
        private CheckBox chkKiem;
        private MaskedTextBox.MaskedTextBox c18;
        private MaskedTextBox.MaskedTextBox c8;
        private Label label10;
        private MaskedTextBox.MaskedTextBox c19;
        private MaskedTextBox.MaskedTextBox c9;
        private Label label11;
        private CheckBox chkTonghop;
        private TextBox tim;
        private CheckBox chkall;
        private CheckedListBox dmnhom;
        private CheckBox chkAllNhom;
        private CheckBox chkGianovat;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBbknhap_hd(AccessData acc,int nhom,string kho,string file,string _madv,string _tendv,string _nghd,string _ngsp,int _makho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;s_kho=kho;tenfile=file;i_makho=_makho;

            i_userid = _userid;
			madv.Text=_madv.Trim();tendv.Text=_tendv;s_nghd=_nghd;s_ngsp=_ngsp;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBbknhap_hd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tendv = new System.Windows.Forms.TextBox();
            this.c1 = new MaskedTextBox.MaskedTextBox();
            this.c3 = new MaskedTextBox.MaskedTextBox();
            this.c4 = new MaskedTextBox.MaskedTextBox();
            this.c5 = new MaskedTextBox.MaskedTextBox();
            this.c6 = new MaskedTextBox.MaskedTextBox();
            this.c7 = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.c17 = new MaskedTextBox.MaskedTextBox();
            this.c16 = new MaskedTextBox.MaskedTextBox();
            this.c15 = new MaskedTextBox.MaskedTextBox();
            this.c14 = new MaskedTextBox.MaskedTextBox();
            this.c13 = new MaskedTextBox.MaskedTextBox();
            this.c12 = new MaskedTextBox.MaskedTextBox();
            this.c11 = new MaskedTextBox.MaskedTextBox();
            this.kho = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.madv = new System.Windows.Forms.TextBox();
            this.listNX = new LibList.List();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.noingoai = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bbkiem = new MaskedTextBox.MaskedTextBox();
            this.sohd = new System.Windows.Forms.CheckedListBox();
            this.butLoc = new System.Windows.Forms.Button();
            this.chkngay = new System.Windows.Forms.CheckBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.chkKiem = new System.Windows.Forms.CheckBox();
            this.c18 = new MaskedTextBox.MaskedTextBox();
            this.c8 = new MaskedTextBox.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.c19 = new MaskedTextBox.MaskedTextBox();
            this.c9 = new MaskedTextBox.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkTonghop = new System.Windows.Forms.CheckBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.dmnhom = new System.Windows.Forms.CheckedListBox();
            this.chkAllNhom = new System.Windows.Forms.CheckBox();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(130, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(52, 10);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(165, 10);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Đơn vị :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(266, 372);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 9;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(336, 372);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tendv
            // 
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(112, 56);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(368, 21);
            this.tendv.TabIndex = 5;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // c1
            // 
            this.c1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1.Location = new System.Drawing.Point(52, 102);
            this.c1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(192, 21);
            this.c1.TabIndex = 11;
            this.c1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c3
            // 
            this.c3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3.Location = new System.Drawing.Point(52, 126);
            this.c3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(192, 21);
            this.c3.TabIndex = 13;
            this.c3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c4
            // 
            this.c4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c4.Location = new System.Drawing.Point(52, 150);
            this.c4.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(192, 21);
            this.c4.TabIndex = 15;
            this.c4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c5
            // 
            this.c5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c5.Location = new System.Drawing.Point(52, 174);
            this.c5.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(192, 21);
            this.c5.TabIndex = 17;
            this.c5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c6
            // 
            this.c6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c6.Location = new System.Drawing.Point(52, 198);
            this.c6.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(192, 21);
            this.c6.TabIndex = 19;
            this.c6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c7
            // 
            this.c7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c7.Location = new System.Drawing.Point(52, 222);
            this.c7.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(192, 21);
            this.c7.TabIndex = 21;
            this.c7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-3, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "1. ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-3, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "2. ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-3, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 21;
            this.label6.Text = "3. ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-3, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "4. ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-3, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 23);
            this.label8.TabIndex = 27;
            this.label8.Text = "5. ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-3, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 23);
            this.label9.TabIndex = 30;
            this.label9.Text = "6. ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c17
            // 
            this.c17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c17.Location = new System.Drawing.Point(246, 222);
            this.c17.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c17.Name = "c17";
            this.c17.Size = new System.Drawing.Size(234, 21);
            this.c17.TabIndex = 22;
            this.c17.Text = "Thủ kho - Ủy viên";
            this.c17.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c16
            // 
            this.c16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c16.Location = new System.Drawing.Point(246, 198);
            this.c16.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c16.Name = "c16";
            this.c16.Size = new System.Drawing.Size(234, 21);
            this.c16.TabIndex = 20;
            this.c16.Text = "Kế toán - Ủy viên";
            this.c16.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c15
            // 
            this.c15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c15.Location = new System.Drawing.Point(246, 174);
            this.c15.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c15.Name = "c15";
            this.c15.Size = new System.Drawing.Size(234, 21);
            this.c15.TabIndex = 18;
            this.c15.Text = "Phụ trách phỏng TCKT - Ủy viên";
            this.c15.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c14
            // 
            this.c14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c14.Location = new System.Drawing.Point(246, 150);
            this.c14.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c14.Name = "c14";
            this.c14.Size = new System.Drawing.Size(234, 21);
            this.c14.TabIndex = 16;
            this.c14.Text = "Phụ trách khoa dược - Ủy viên";
            this.c14.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c13
            // 
            this.c13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c13.Location = new System.Drawing.Point(246, 126);
            this.c13.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c13.Name = "c13";
            this.c13.Size = new System.Drawing.Size(234, 21);
            this.c13.TabIndex = 14;
            this.c13.Text = "Phó CN kho - Phụ trách kho - Ủy viên";
            this.c13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c12
            // 
            this.c12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(776, 126);
            this.c12.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(234, 21);
            this.c12.TabIndex = 20;
            this.c12.Text = "Trưởng phòng KHTH - Ủy viên";
            this.c12.Visible = false;
            // 
            // c11
            // 
            this.c11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c11.Location = new System.Drawing.Point(246, 102);
            this.c11.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(234, 21);
            this.c11.TabIndex = 12;
            this.c11.Text = "Chủ tịch hội đồng";
            this.c11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // kho
            // 
            this.kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(280, 10);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(200, 21);
            this.kho.TabIndex = 2;
            this.kho.SelectedIndexChanged += new System.EventHandler(this.kho_SelectedIndexChanged);
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(248, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 4;
            this.label12.Text = "Kho :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madv
            // 
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(52, 56);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(58, 21);
            this.madv.TabIndex = 4;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(435, 400);
            this.listNX.MatchBufferTimeOut = 1000;
            this.listNX.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNX.Name = "listNX";
            this.listNX.Size = new System.Drawing.Size(75, 17);
            this.listNX.TabIndex = 43;
            this.listNX.TextIndex = -1;
            this.listNX.TextMember = null;
            this.listNX.ValueIndex = -1;
            this.listNX.Visible = false;
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(52, 79);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(196, 21);
            this.manguon.TabIndex = 6;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(-8, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 23);
            this.label14.TabIndex = 11;
            this.label14.Text = "Nguồn";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // noingoai
            // 
            this.noingoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noingoai.Location = new System.Drawing.Point(320, 78);
            this.noingoai.Name = "noingoai";
            this.noingoai.Size = new System.Drawing.Size(160, 21);
            this.noingoai.TabIndex = 7;
            this.noingoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(256, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 13;
            this.label15.Text = "Nội/ngoại";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(-3, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 23);
            this.label16.TabIndex = 6;
            this.label16.Text = "BB kiểm :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bbkiem
            // 
            this.bbkiem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bbkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbkiem.Location = new System.Drawing.Point(52, 33);
            this.bbkiem.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bbkiem.Name = "bbkiem";
            this.bbkiem.Size = new System.Drawing.Size(428, 21);
            this.bbkiem.TabIndex = 3;
            // 
            // sohd
            // 
            this.sohd.CheckOnClick = true;
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(485, 9);
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(228, 196);
            this.sohd.TabIndex = 44;
            // 
            // butLoc
            // 
            this.butLoc.Image = global::Duoc.Properties.Resources.search;
            this.butLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLoc.Location = new System.Drawing.Point(196, 372);
            this.butLoc.Name = "butLoc";
            this.butLoc.Size = new System.Drawing.Size(70, 25);
            this.butLoc.TabIndex = 8;
            this.butLoc.Text = "    &Tìm";
            this.butLoc.Click += new System.EventHandler(this.butLoc_Click);
            // 
            // chkngay
            // 
            this.chkngay.Checked = true;
            this.chkngay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkngay.Location = new System.Drawing.Point(52, 315);
            this.chkngay.Name = "chkngay";
            this.chkngay.Size = new System.Drawing.Size(146, 19);
            this.chkngay.TabIndex = 46;
            this.chkngay.Text = "In theo ngày hoá đơn";
            this.chkngay.Click += new System.EventHandler(this.chkngay_Click);
            this.chkngay.CheckedChanged += new System.EventHandler(this.chkngay_CheckedChanged);
            // 
            // chkXml
            // 
            this.chkXml.Checked = true;
            this.chkXml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXml.Location = new System.Drawing.Point(52, 372);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(104, 19);
            this.chkXml.TabIndex = 47;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.CheckedChanged += new System.EventHandler(this.chkXml_CheckedChanged);
            // 
            // chkKiem
            // 
            this.chkKiem.Location = new System.Drawing.Point(52, 334);
            this.chkKiem.Name = "chkKiem";
            this.chkKiem.Size = new System.Drawing.Size(146, 19);
            this.chkKiem.TabIndex = 48;
            this.chkKiem.Text = "In theo ngày kiểm";
            this.chkKiem.Click += new System.EventHandler(this.chkKiem_Click);
            this.chkKiem.CheckedChanged += new System.EventHandler(this.chkKiem_CheckedChanged);
            // 
            // c18
            // 
            this.c18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c18.Location = new System.Drawing.Point(246, 246);
            this.c18.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c18.Name = "c18";
            this.c18.Size = new System.Drawing.Size(234, 21);
            this.c18.TabIndex = 24;
            this.c18.Text = "Thủ kho - Ủy viên";
            this.c18.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c8
            // 
            this.c8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c8.Location = new System.Drawing.Point(52, 246);
            this.c8.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c8.Name = "c8";
            this.c8.Size = new System.Drawing.Size(192, 21);
            this.c8.TabIndex = 23;
            this.c8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-2, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "7. ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c19
            // 
            this.c19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c19.Location = new System.Drawing.Point(246, 270);
            this.c19.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c19.Name = "c19";
            this.c19.Size = new System.Drawing.Size(234, 21);
            this.c19.TabIndex = 26;
            this.c19.Text = "Thủ kho - Ủy viên";
            this.c19.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // c9
            // 
            this.c9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c9.Location = new System.Drawing.Point(52, 270);
            this.c9.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c9.Name = "c9";
            this.c9.Size = new System.Drawing.Size(192, 21);
            this.c9.TabIndex = 25;
            this.c9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-2, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 23);
            this.label11.TabIndex = 52;
            this.label11.Text = "8. ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTonghop
            // 
            this.chkTonghop.Location = new System.Drawing.Point(52, 296);
            this.chkTonghop.Name = "chkTonghop";
            this.chkTonghop.Size = new System.Drawing.Size(104, 19);
            this.chkTonghop.TabIndex = 53;
            this.chkTonghop.Text = "In Tổng hợp";
            this.chkTonghop.Click += new System.EventHandler(this.chkTonghop_Click);
            // 
            // tim
            // 
            this.tim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(483, 207);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(148, 21);
            this.tim.TabIndex = 54;
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.Leave += new System.EventHandler(this.tim_Leave);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // chkall
            // 
            this.chkall.Location = new System.Drawing.Point(637, 208);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(90, 18);
            this.chkall.TabIndex = 55;
            this.chkall.Text = "Chọn tất cả";
            this.chkall.Click += new System.EventHandler(this.chkall_Click);
            // 
            // dmnhom
            // 
            this.dmnhom.FormattingEnabled = true;
            this.dmnhom.Location = new System.Drawing.Point(485, 231);
            this.dmnhom.Name = "dmnhom";
            this.dmnhom.Size = new System.Drawing.Size(228, 154);
            this.dmnhom.TabIndex = 56;
            // 
            // chkAllNhom
            // 
            this.chkAllNhom.Location = new System.Drawing.Point(637, 387);
            this.chkAllNhom.Name = "chkAllNhom";
            this.chkAllNhom.Size = new System.Drawing.Size(90, 18);
            this.chkAllNhom.TabIndex = 57;
            this.chkAllNhom.Text = "Chọn tất cả";
            this.chkAllNhom.Click += new System.EventHandler(this.chkAllNhom_Click);
            // 
            // chkGianovat
            // 
            this.chkGianovat.Location = new System.Drawing.Point(52, 353);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(138, 19);
            this.chkGianovat.TabIndex = 58;
            this.chkGianovat.Text = "In kèm giá trước VAT";
            // 
            // rptBbknhap_hd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(727, 417);
            this.Controls.Add(this.chkGianovat);
            this.Controls.Add(this.chkAllNhom);
            this.Controls.Add(this.dmnhom);
            this.Controls.Add(this.chkall);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.chkngay);
            this.Controls.Add(this.chkTonghop);
            this.Controls.Add(this.c19);
            this.Controls.Add(this.c9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.c18);
            this.Controls.Add(this.c8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkKiem);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.butLoc);
            this.Controls.Add(this.sohd);
            this.Controls.Add(this.bbkiem);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.noingoai);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.listNX);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.c17);
            this.Controls.Add(this.c16);
            this.Controls.Add(this.c15);
            this.Controls.Add(this.c14);
            this.Controls.Add(this.c13);
            this.Controls.Add(this.c12);
            this.Controls.Add(this.c11);
            this.Controls.Add(this.c7);
            this.Controls.Add(this.c6);
            this.Controls.Add(this.c5);
            this.Controls.Add(this.c4);
            this.Controls.Add(this.c3);
            this.Controls.Add(this.c1);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptBbknhap_hd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biên bản kiểm nhập";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptBbknhap_hd_MouseMove);
            this.Load += new System.EventHandler(this.rptBbknhap_hd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptBbknhap_hd_Load(object sender, System.EventArgs e)
		{           
            chkngay.Checked = d.Thongso("bbkn_ngayhd") == "1";
            chkKiem.Checked = d.Thongso("bbkn_ngaykiem") == "1";
            user = d.user; stime = "'" + d.f_ngay + "'";
			sohd.DisplayMember="SONGAY";
			sohd.ValueMember="SOHD";

			listNX.DisplayMember="MA";
			listNX.ValueMember="TEN";
			dtdmnx=d.get_data("select ma,ten,id from "+user+".d_dmnx where nhom="+i_nhom+" order by stt").Tables[0];
			listNX.DataSource=dtdmnx;

			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
            sql += " and khott<>0";
			sql+=" order by stt";
			kho.DataSource=d.get_data(sql).Tables[0];
			//
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
            sql = "select * from " + user + ".d_dmnguon where nhom=" + i_nhom;			
			sql+=" order by stt";
			manguon.DataSource=d.get_data(sql).Tables[0];
			manguon.SelectedIndex=-1;
            //
            chkTonghop.Checked = d.Thongso("bbknhap_intonghop") == "1";
			//
            sql = "select a.*, b.stt, b.ten tennhom, a.maloai idnn, f.ten noingoai, g.ten as nuocsx from " + user + ".d_dmbd a," + user + ".d_dmnhom b," + user + ".d_dmhang e," + user + ".d_dmloai f," + user + ".d_dmnuoc g";
			sql+=" where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and a.manuoc=g.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];
            //
            dtnhom = d.get_data("select * from " + user + ".d_dmnhom where nhom=" + i_nhom + " order by id").Tables[0];
            dmnhom.DataSource = dtnhom;
            dmnhom.DisplayMember = "TEN";
            dmnhom.ValueMember = "ID";
            //
            dtnuoc = d.get_data("select * from " + user + ".d_dmhang where nhom=" + i_nhom + " order by id").Tables[0];
            dtnhombc = d.get_data("select * from " + user + ".d_nhombc where nhom=" + i_nhom + " order by id").Tables[0];
            dtnhomnuoc = d.get_data("select * from " + user + ".d_nhomnuoc where nhom=" + i_nhom + " order by id").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_Bbknhap.xml");
            ds.Tables[0].Columns.Add("sodk");
            ds.Tables[0].Columns.Add("nuocsx");
            ds.Tables[0].Columns.Add("makho");
            ds.Tables[0].Columns.Add("tenkho");
            ds.Tables[0].Columns.Add("ngayhoadon");
            ds.Tables[0].Columns.Add("sodangky");
			dsst.ReadXml("..\\..\\..\\xml\\d_stnhap.xml");
			d.ins_thongso(i_nhom,501,516);
            foreach (DataRow r in d.get_data("select * from " + user + ".d_thongso where id between 501 and 519 and nhom=" + i_nhom).Tables[0].Rows)
			{
				switch (int.Parse(r["id"].ToString()))
				{
					case 501:c1.Text=r["ten"].ToString().Trim();break;
					case 503:c3.Text=r["ten"].ToString().Trim();break;
					case 504:c4.Text=r["ten"].ToString().Trim();break;
					case 505:c5.Text=r["ten"].ToString().Trim();break;
					case 506:c6.Text=r["ten"].ToString().Trim();break;
					case 507:c7.Text=r["ten"].ToString().Trim();break;
					case 509:c11.Text=r["ten"].ToString().Trim();break;
					case 510:c12.Text=r["ten"].ToString().Trim();break;
					case 511:c13.Text=r["ten"].ToString().Trim();break;
					case 512:c14.Text=r["ten"].ToString().Trim();break;
					case 513:c15.Text=r["ten"].ToString().Trim();break;
					case 514:c16.Text=r["ten"].ToString().Trim();break;
					case 515:c17.Text=r["ten"].ToString().Trim();break;
					case 516:c18.Text=r["ten"].ToString().Trim();break;
                    case 517: c8.Text = r["ten"].ToString().Trim(); break;
                    case 518: c9.Text = r["ten"].ToString().Trim(); break;
                    case 519: c19.Text = r["ten"].ToString().Trim(); break;
				}
			}

			manguon.Enabled=d.bQuanlynguon(i_nhom);

			noingoai.DisplayMember="TEN";
			noingoai.ValueMember="ID";
            noingoai.DataSource = d.get_data("select * from " + user + ".d_dmloai where nhom=" + i_nhom + " order by stt ").Tables[0];

			noingoai.SelectedIndex=-1;
			if (s_nghd!="" && s_ngsp!="")
			{
				if (chkngay.Checked) tu.Value=new DateTime(int.Parse(s_nghd.Substring(6,4)),int.Parse(s_nghd.Substring(3,2)),int.Parse(s_nghd.Substring(0,2)),0,0,0);
				else tu.Value=new DateTime(int.Parse(s_ngsp.Substring(6,4)),int.Parse(s_ngsp.Substring(3,2)),int.Parse(s_ngsp.Substring(0,2)),0,0,0);
				den.Value=tu.Value;	
				try
				{
					kho.SelectedValue=i_makho.ToString();
				}
				catch{}
				butLoc_Click(sender,e);
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if(kho.SelectedIndex<0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn kho!"),lan.Change_language_MessageText("Kho"),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			if (madv.Text!="")
			{
				i_madv=0;
				r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
					madv.Focus();
					return;
				}
				i_madv=int.Parse(r["id"].ToString());
			}
			if(d.bQuanlynguon(i_nhom)==false)manguon.SelectedIndex=-1;
			so="'";
			s_sohd="";s_ngayhd="";
            //
            s_manhom = "";
            for (int i = 0; i < dmnhom.Items.Count; i++) if (dmnhom.GetItemChecked(i)) s_manhom += dtnhom.Rows[i]["id"].ToString() + ",";
            //
			if (sohd.SelectedItems.Count>0)
			{
				if (sohd.CheckedItems.Count==0) for(int i=0;i<sohd.Items.Count;i++) sohd.SetItemCheckState(i,CheckState.Checked);
                DataTable ldt = dv.ToTable();
				for(int i=0;i<sohd.Items.Count;i++) 
					if (sohd.GetItemChecked(i))
					{
                        so += ldt.Rows[i]["sohd"].ToString().Trim() + "','";
                        s_sohd += ldt.Rows[i]["sohd"].ToString().Trim() + ",";
                        if (s_ngayhd.IndexOf(ldt.Rows[i]["ngayhd"].ToString().Trim() + ",") == -1) s_ngayhd += ldt.Rows[i]["ngayhd"].ToString().Trim() + ",";
						//so+=dssohd.Tables[0].Rows[i]["sohd"].ToString().Trim()+"','";
						//s_sohd+=dssohd.Tables[0].Rows[i]["sohd"].ToString().Trim()+",";
						//if (s_ngayhd.IndexOf(dssohd.Tables[0].Rows[i]["ngayhd"].ToString().Trim()+",")==-1) s_ngayhd+=dssohd.Tables[0].Rows[i]["ngayhd"].ToString().Trim()+",";
					}
			}
			ds.Clear();
			dsst.Clear();
			DateTime dt1=d.StringToDate(tu.Text).AddMonths(-1);//.AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddMonths(1);//.AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";					
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(get_khott(int.Parse(kho.SelectedValue.ToString()))==1) get_nhap(mmyy);
						else get_nhap_kl(mmyy);
					}
				}
			}
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                ds.WriteXml("..\\xml\\bbknhap.xml", XmlWriteMode.WriteSchema);
            }
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}            
			s_tongcong="";
			DataRow []dr=dsst.Tables[0].Select("sotien<>0","maloai,tenloai desc,manuoc");
			for(int i=0;i<dr.Length;i++)
			{
				sotien=decimal.Parse(dr[i]["sotien"].ToString());
				dau=(dr[i]["tenloai"].ToString()!="")?"+":"";
				dau+="       ";
				s_tongcong+=dr[i]["tenloai"].ToString()+dau+dr[i]["tennuoc"].ToString()+" : "+sotien.ToString("###,###,###,###0.000")+"+";
			}
			s_tongcong=(s_tongcong!="")?s_tongcong.Substring(0,s_tongcong.Length-1):"";
            string ngay = (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text;
			if(manguon.SelectedIndex>=0)ngay="Nguồn: "+manguon.Text+" - "+ngay;
			ngay+=";"+s_tongcong;
            string tmp = tenfile;
            if (chkGianovat.Checked) tenfile = tenfile.Replace(".rpt", "") + "_novat.rpt";
            if(chkTonghop.Checked) tenfile = tenfile.Replace(".rpt", "") + "_th.rpt";

            frmReport f = new frmReport(d, ds.Tables[0], i_userid, tenfile, tendv.Text.Trim() + "+" + kho.Text, ngay, c1.Text.Trim() + "+" + c11.Text.Trim(), "" + "+" + "", c3.Text.Trim() + "+" + c13.Text.Trim(), c4.Text.Trim() + "+" + c14.Text.Trim(), c5.Text.Trim() + "+" + c15.Text.Trim(), c6.Text.Trim() + "+" + c16.Text.Trim(), c7.Text.Trim() + "+" + c17.Text.Trim() + "+" + c8.Text.Trim() + "+" + c18.Text.Trim() + "+" + c9.Text.Trim() + "+" + c19.Text.Trim(), s_sohd.Trim() + "++" + s_ngayhd.Trim());
			f.ShowDialog();
            tenfile = tmp;
		}

		private void get_nhap(string d_mmyy)
		{
            string ngay = (chkngay.Checked) ? "ngayhd" : (chkKiem.Checked) ? "ngaykiem" : "ngaysp";
            xxx = user + d_mmyy;
            sql = "select a.makho, g.ten as tenkho, to_char(a."+ngay+",'dd/mm/yyyy') as ngayhd,trim(a.sohd)||' - '||to_char(a."+ngay+",'dd/mm/yyyy')||' ^ '||trim(a.sophieu)||' - '||to_char(a.ngaysp,'dd/mm/yyyy') as sohd,";
            sql += " b.mabd,b.soluong,b.vat,b.sotien,b.losx,b.handung, d.stt, d.ten as nhombd,f.ten as tendv, b.dongia as gianovat,b.haohut,b.giamua,to_char(a.ngayhd,'dd/mm/yyyy') as ngayhoadon, b.sodangky ";
            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c," + user + ".d_dmnhom d, " + user + ".d_dmhang e," + user + ".d_dmnx f," + user + ".d_dmkho g  ";
			sql+=" where a.id=b.id and b.mabd=c.id and c.manhom=d.id and c.mahang=e.id and a.madv=f.id and a.makho=g.id and a.nhom="+i_nhom;
            sql+=" and a."+ngay+" between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (so.Length>1) sql+=" and trim(a.sohd) in ("+so.Substring(0,so.Length-2)+")";
			if (kho.SelectedIndex!=-1) sql+=" and a.makho="+int.Parse(kho.SelectedValue.ToString());
			if (madv.Text!="") sql+=" and a.madv="+i_madv;
			if(manguon.SelectedIndex>=0)sql+=" and a.manguon="+manguon.SelectedValue.ToString();
			if (bbkiem.Text!="") sql+=" and a.bbkiem='"+bbkiem.Text.Trim()+"'";
            if (s_manhom.Trim().Trim(',') != "") sql += " and c.manhom in(" + s_manhom.Trim().Trim(',') + ")";
			sql+=" order by a.id,d.loai, d.stt, d.ten ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r1!=null)
				{
					r2=d.getrowbyid(dtnhom,"id="+int.Parse(r1["manhom"].ToString()));
					r3=d.getrowbyid(dtnuoc,"id="+int.Parse(r1["mahang"].ToString()));
					r4 = ds.Tables[0].NewRow();
                    r4["makho"] = r["makho"].ToString();
                    r4["tenkho"] = r["tenkho"].ToString();
					r4["mabd"]=r["mabd"].ToString();
					r4["ma"]=r1["ma"].ToString();
					r4["ten"]=r1["ten"].ToString().Trim()+" "+r1["hamluong"].ToString();
					r4["tenhc"]=r1["tenhc"].ToString();
					r4["dang"]=r1["dang"].ToString();
					r4["sohd"]=r["sohd"].ToString();
					r4["ngayhd"]=r["ngayhd"].ToString();
					r4["handung"]=r["handung"].ToString();
					r4["losx"]=r["losx"].ToString();
					r4["stt"]=r["stt"].ToString();
					r4["nhombd"]=r["nhombd"].ToString();
					r4["idnn"]=r1["idnn"].ToString();
					r4["noingoai"]=r1["noingoai"].ToString();
					r4["tennhom"]=bbkiem.Text;
					if (r3!=null) r4["tennuoc"]=r3["ten"].ToString();
					r4["soluong"]=r["soluong"].ToString();
					r4["vat"]=r["vat"].ToString();
					r4["sotien"]=r["sotien"].ToString();
                    r4["sodk"] = r1["sodk"].ToString();
                    r4["nuocsx"] = r1["nuocsx"].ToString();
                    r4["tendv"] = r["tendv"].ToString();
                    r4["ngayhoadon"] = r["ngayhoadon"].ToString();
                    r4["sodangky"] = r["sodangky"].ToString();
					ds.Tables[0].Rows.Add(r4);
					if (r2!=null && r3!=null)
					{
						r4=d.getrowbyid(dsst.Tables[0],"maloai="+int.Parse(r2["loai"].ToString())+" and manuoc="+int.Parse(r3["loai"].ToString()));
						if (r4==null)
						{
							r5=dsst.Tables[0].NewRow();
							r6=d.getrowbyid(dtnhombc,"id="+int.Parse(r2["loai"].ToString()));
							r7=d.getrowbyid(dtnhomnuoc,"id="+int.Parse(r3["loai"].ToString()));
							r5["maloai"]=r2["loai"].ToString();
							r5["manuoc"]=r3["loai"].ToString();
							if (r6!=null)
							{
								r8=d.getrowbyid(dsst.Tables[0],"tenloai='"+r6["ten"].ToString()+"'");
								if (r8==null) r5["tenloai"]=r6["ten"].ToString();
							}
							if (r7!=null) r5["tennuoc"]=r7["ten"].ToString();
							r5["sotien"]=decimal.Parse(r["sotien"].ToString())+decimal.Parse(r["sotien"].ToString())*decimal.Parse(r["vat"].ToString())/100;
							dsst.Tables[0].Rows.Add(r5);
						}
						else
						{
							DataRow []dr=dsst.Tables[0].Select("maloai="+int.Parse(r2["loai"].ToString())+" and manuoc="+int.Parse(r3["loai"].ToString()));
							dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString())+decimal.Parse(r["sotien"].ToString())*decimal.Parse(r["vat"].ToString())/100;
						}
					}
				}
			}
			ds.AcceptChanges();
			dsst.AcceptChanges();
		}

		private void get_nhap_kl(string d_mmyy)
		{
            xxx = user + d_mmyy;
            sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngayhd,a.sophieu as sohd,b.mabd,b.soluong,0 as vat,b.soluong*t.giamua as sotien,t.losx,t.handung, d.stt, d.ten as nhombd, f.ten as tendv, t.gianovat,'' as sodangky ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + user + ".d_dmnhom d, " + user + ".d_dmhang e," + xxx + ".d_theodoi t," + user + ".d_dmnx f ";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.manhom=d.id and c.mahang=e.id and t.nhomcc=f.id(+) and a.nhom="+i_nhom+" and a.loai='CK'";
            sql += " and " + d.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (kho.SelectedIndex!=-1) sql+=" and a.khon="+int.Parse(kho.SelectedValue.ToString());
			if(manguon.SelectedIndex>=0)sql+=" and t.manguon="+manguon.SelectedValue.ToString();
			if(noingoai.SelectedIndex>=0)sql+=" and c.maloai="+int.Parse(noingoai.SelectedValue.ToString());
            if (s_manhom.Trim().Trim(',') != "") sql += " and c.manhom in(" + s_manhom.Trim().Trim(',') + ")";
			sql+=" order by a.id,d.loai, d.stt, d.ten ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r1!=null)
				{
					r2=d.getrowbyid(dtnhom,"id="+int.Parse(r1["manhom"].ToString()));
					r3=d.getrowbyid(dtnuoc,"id="+int.Parse(r1["manuoc"].ToString()));
					r4 = ds.Tables[0].NewRow();
					r4["mabd"]=r["mabd"].ToString();
					r4["ma"]=r1["ma"].ToString();
					r4["ten"]=r1["ten"].ToString().Trim()+" "+r1["hamluong"].ToString();
					r4["tenhc"]=r1["tenhc"].ToString();
					r4["dang"]=r1["dang"].ToString();
					r4["sohd"]=r["sohd"].ToString();
					r4["ngayhd"]=r["ngayhd"].ToString();
					r4["handung"]=r["handung"].ToString();
					r4["losx"]=r["losx"].ToString();
					r4["stt"]=r["stt"].ToString();
					r4["nhombd"]=r["nhombd"].ToString();
					r4["idnn"]=r1["idnn"].ToString();
					r4["noingoai"]=r1["noingoai"].ToString();
					r4["tennhom"]="";
					if (r3!=null) r4["tennuoc"]=r3["ten"].ToString();
					r4["soluong"]=r["soluong"].ToString();
					r4["vat"]=r["vat"].ToString();
					r4["sotien"]=r["sotien"].ToString();
                    r4["sodk"] = r1["sodk"].ToString();
                    r4["nuocsx"] = r1["nuocsx"].ToString();
					ds.Tables[0].Rows.Add(r4);
					if (r2!=null && r3!=null)
					{
						r4=d.getrowbyid(dsst.Tables[0],"maloai="+int.Parse(r2["loai"].ToString())+" and manuoc="+int.Parse(r3["loai"].ToString()));
						if (r4==null)
						{
							r5=dsst.Tables[0].NewRow();
							r6=d.getrowbyid(dtnhombc,"id="+int.Parse(r2["loai"].ToString()));
							r7=d.getrowbyid(dtnhomnuoc,"id="+int.Parse(r3["loai"].ToString()));
							r5["maloai"]=r2["loai"].ToString();
							r5["manuoc"]=r3["loai"].ToString();
							if (r6!=null)
							{
								r8=d.getrowbyid(dsst.Tables[0],"tenloai='"+r6["ten"].ToString()+"'");
								if (r8==null) r5["tenloai"]=r6["ten"].ToString();
							}
							if (r7!=null) r5["tennuoc"]=r7["ten"].ToString();
							r5["sotien"]=decimal.Parse(r["sotien"].ToString())+decimal.Parse(r["sotien"].ToString())*decimal.Parse(r["vat"].ToString())/100;
							dsst.Tables[0].Rows.Add(r5);
						}
						else
						{
							DataRow []dr=dsst.Tables[0].Select("maloai="+int.Parse(r2["loai"].ToString())+" and manuoc="+int.Parse(r3["loai"].ToString()));
							dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString())+decimal.Parse(r["sotien"].ToString())*decimal.Parse(r["vat"].ToString())/100;
						}
					}
				}
			}
			ds.AcceptChanges();
			dsst.AcceptChanges();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.upd_thongso(i_nhom,501,"",c1.Text.Trim());
			d.upd_thongso(i_nhom,503,"",c3.Text.Trim());
			d.upd_thongso(i_nhom,504,"",c4.Text.Trim());
			d.upd_thongso(i_nhom,505,"",c5.Text.Trim());
			d.upd_thongso(i_nhom,506,"",c6.Text.Trim());
			d.upd_thongso(i_nhom,507,"",c7.Text.Trim());
			d.upd_thongso(i_nhom,509,"",c11.Text.Trim());
			d.upd_thongso(i_nhom,510,"",c12.Text.Trim());
			d.upd_thongso(i_nhom,511,"",c13.Text.Trim());
			d.upd_thongso(i_nhom,512,"",c14.Text.Trim());
			d.upd_thongso(i_nhom,513,"",c15.Text.Trim());
			d.upd_thongso(i_nhom,514,"",c16.Text.Trim());
			d.upd_thongso(i_nhom,515,"",c17.Text.Trim());
			d.upd_thongso(i_nhom,516,"",c18.Text.Trim());
            d.upd_thongso(i_nhom, 517, "", c8.Text.Trim());
            d.upd_thongso(i_nhom, 518, "", c9.Text.Trim());
            d.upd_thongso(i_nhom, 519, "", c19.Text.Trim());            
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void rptBbknhap_hd_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				if (manguon.Enabled)manguon.SelectedIndex=-1;
				noingoai.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void tendv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNX.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNX.Visible)	listNX.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tendv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendv)
			{
				Filter_dmnx(tendv.Text);
				listNX.BrowseToDmnx(tendv,madv,butLoc);
			}
		}

		private void tendv_Validated(object sender, System.EventArgs e)
		{
			if(!listNX.Focused) listNX.Hide();
			if (tendv.Text!="" && madv.Text=="")
			{
				r=d.getrowbyid(dtdmnx,"ten='"+tendv.Text+"'");
				if (r!=null) madv.Text=r["ma"].ToString();
			}
		}
		private void madv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
		private void madv_Validated(object sender, System.EventArgs e)
		{
			if (madv.Text!="")
			{
				r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r!=null) tendv.Text=r["ten"].ToString();
			}
		}
		private void Filter_dmnx(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNX.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}
		private int get_khott(int i_kho)
		{
			int i_khott=0;
			string sql="select khott from "+user+".d_dmkho where id="+i_kho;
			DataTable ldt=d.get_data(sql).Tables[0];
			foreach(DataRow r in ldt.Rows)
			{
				i_khott=int.Parse(r["khott"].ToString());
				break;
			}
			ldt.Dispose();
			return i_khott;
		}

		private void butLoc_Click(object sender, System.EventArgs e)
		{
            /*
			if (madv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn nhà cung cấp !"),d.Msg);
				madv.Focus();
				return;
			}*/
			dssohd=new DataSet();
			DateTime dt1=d.StringToDate(tu.Text.Substring(0,10)).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text.Substring(0,10)).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			bool be=true;
			string mmyy="",sql,ngay;
            ngay = (chkngay.Checked) ? "ngayhd" : (chkKiem.Checked) ? "ngaykiem" : "ngaysp";
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
						sql="select distinct to_char(a."+ngay+",'dd/mm/yyyy')||'     '||a.sohd as songay,a.sohd,to_char(a.ngayhd,'dd/mm/yyyy') as ngayhd ";
						sql+=" from "+xxx+".d_nhapll a,"+user+".d_dmnx b where a.madv=b.id";
						sql+=" and a."+ngay+" between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
						if (madv.Text!="") sql+=" and trim(b.ma)='"+madv.Text+"'";
						sql+=" and a.nhom="+i_nhom;
                        if (kho.SelectedIndex >= 0) sql += " and a.makho= " + kho.SelectedValue.ToString();
						if (be) dssohd=d.get_data(sql);
						else dssohd.Merge(d.get_data(sql));
						be=false;
					}
				}
			}
			sohd.DataSource=dssohd.Tables[0];
            sohd.DisplayMember = "SONGAY";
            sohd.ValueMember = "SOHD";
            //
            CurrencyManager cm = (CurrencyManager)BindingContext[sohd.DataSource];
            dv = (DataView)cm.List;
            //
		}

        private void chkngay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkngay && chkKiem.Checked) chkKiem.Checked = false;
        }

        private void chkKiem_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkKiem && chkngay.Checked) chkngay.Checked = false;
        }

        private void chkngay_Click(object sender, EventArgs e)
        {
            d.writeXml("d_thongso", "bbkn_ngayhd", (chkngay.Checked)?"1":"0");
            d.writeXml("d_thongso", "bbkn_ngaykiem", (chkKiem.Checked) ? "1" : "0");
        }

        private void chkKiem_Click(object sender, EventArgs e)
        {
            d.writeXml("d_thongso", "bbkn_ngayhd", (chkngay.Checked) ? "1" : "0");
            d.writeXml("d_thongso", "bbkn_ngaykiem", (chkKiem.Checked) ? "1" : "0");
        }

        private void kho_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            butLoc_Click(null, null);
            Cursor = Cursors.Default;
        }

        private void chkXml_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void chkTonghop_Click(object sender, EventArgs e)
        {
            d.writeXml("d_thongso", "bbknhap_intonghop", chkTonghop.Checked ? "1" : "0");
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (tim.Text != "Tìm" || tim.Text != "TÌM") Filter_hoadon(tim.Text);
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            if (tim.Text == "Tìm" || tim.Text != "TÌM") tim.Text = "";
        }

        private void tim_Leave(object sender, EventArgs e)
        {
            if (tim.Text == "") tim.Text = "Tìm";
        }
        private void Filter_hoadon(string shoadon)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[sohd.DataSource];
                dv = (DataView)cm.List;
                dv.RowFilter = "sohd like '%" + shoadon.Trim() + "%'";
            }
            catch { }
        }

        private void chkall_Click(object sender, EventArgs e)
        {
            if (chkall.Checked)
            {
                for (int i = 0; i < sohd.Items.Count; i++)
                {
                    sohd.SetItemCheckState(i, CheckState.Checked);
                }
            }
            else
            {
                for (int i = 0; i < sohd.Items.Count; i++)
                {
                    sohd.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void chkAllNhom_Click(object sender, EventArgs e)
        {
            if (chkAllNhom.Checked)
                for (int i = 0; i < dmnhom.Items.Count; i++) dmnhom.SetItemCheckState(i, CheckState.Checked);
            else
                for (int i = 0; i < dmnhom.Items.Count; i++) dmnhom.SetItemCheckState(i, CheckState.Unchecked);
        }
	}
}
