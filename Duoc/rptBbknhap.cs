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
	public class rptBbknhap : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		bool bln_noingoai=false;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker den;
		private AccessData d;
        private int i_nhom, i_madv, i_userid=0;
		private bool bClear=true;
        private string user, stime, xxx, sql, s_tongcong, dau, s_kho, tenfile, s_khott, s01, s02, s03, s04, s_manhom = "";
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
		private MaskedTextBox.MaskedTextBox c1;
		private MaskedTextBox.MaskedTextBox c2;
		private MaskedTextBox.MaskedTextBox c3;
		private MaskedTextBox.MaskedTextBox c4;
		private MaskedTextBox.MaskedTextBox c5;
		private MaskedTextBox.MaskedTextBox c6;
		private MaskedTextBox.MaskedTextBox c7;
		private MaskedTextBox.MaskedTextBox c8;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private MaskedTextBox.MaskedTextBox c11;
		private System.Windows.Forms.ComboBox kho;
		private System.Windows.Forms.Label label12;
		private MaskedTextBox.MaskedTextBox c18;
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
        private CheckBox chkXml;
        private CheckBox chkNgaykiem;
        private CheckBox chkGianovat;
        private CheckedListBox dmnhom;
        private CheckBox chkAll;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBbknhap(AccessData acc,int nhom,string kho,string file, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
			tenfile=file;
            i_userid = _userid;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBbknhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tendv = new System.Windows.Forms.TextBox();
            this.c1 = new MaskedTextBox.MaskedTextBox();
            this.c2 = new MaskedTextBox.MaskedTextBox();
            this.c3 = new MaskedTextBox.MaskedTextBox();
            this.c4 = new MaskedTextBox.MaskedTextBox();
            this.c5 = new MaskedTextBox.MaskedTextBox();
            this.c6 = new MaskedTextBox.MaskedTextBox();
            this.c7 = new MaskedTextBox.MaskedTextBox();
            this.c8 = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.c18 = new MaskedTextBox.MaskedTextBox();
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
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.chkNgaykiem = new System.Windows.Forms.CheckBox();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            this.dmnhom = new System.Windows.Forms.CheckedListBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
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
            this.tu.TabIndex = 1;
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
            this.den.TabIndex = 3;
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
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(190, 327);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 39;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(260, 327);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 40;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tendv
            // 
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(112, 56);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(368, 21);
            this.tendv.TabIndex = 10;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // c1
            // 
            this.c1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1.Location = new System.Drawing.Point(52, 102);
            this.c1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(192, 21);
            this.c1.TabIndex = 16;
            // 
            // c2
            // 
            this.c2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2.Location = new System.Drawing.Point(52, 126);
            this.c2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(192, 21);
            this.c2.TabIndex = 19;
            // 
            // c3
            // 
            this.c3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3.Location = new System.Drawing.Point(52, 150);
            this.c3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(192, 21);
            this.c3.TabIndex = 22;
            // 
            // c4
            // 
            this.c4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c4.Location = new System.Drawing.Point(52, 174);
            this.c4.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(192, 21);
            this.c4.TabIndex = 25;
            // 
            // c5
            // 
            this.c5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c5.Location = new System.Drawing.Point(52, 198);
            this.c5.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(192, 21);
            this.c5.TabIndex = 28;
            // 
            // c6
            // 
            this.c6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c6.Location = new System.Drawing.Point(52, 222);
            this.c6.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(192, 21);
            this.c6.TabIndex = 31;
            // 
            // c7
            // 
            this.c7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c7.Location = new System.Drawing.Point(52, 246);
            this.c7.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(192, 21);
            this.c7.TabIndex = 34;
            // 
            // c8
            // 
            this.c8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c8.Location = new System.Drawing.Point(52, 270);
            this.c8.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c8.Name = "c8";
            this.c8.Size = new System.Drawing.Size(192, 21);
            this.c8.TabIndex = 37;
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
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-3, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 23);
            this.label10.TabIndex = 33;
            this.label10.Text = "7. ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-3, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 23);
            this.label11.TabIndex = 36;
            this.label11.Text = "8. ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c18
            // 
            this.c18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c18.Location = new System.Drawing.Point(246, 270);
            this.c18.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c18.Name = "c18";
            this.c18.Size = new System.Drawing.Size(234, 21);
            this.c18.TabIndex = 38;
            this.c18.Text = "Thủ kho - Ủy viên";
            // 
            // c17
            // 
            this.c17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c17.Location = new System.Drawing.Point(246, 246);
            this.c17.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c17.Name = "c17";
            this.c17.Size = new System.Drawing.Size(234, 21);
            this.c17.TabIndex = 35;
            this.c17.Text = "Thủ kho - Ủy viên";
            // 
            // c16
            // 
            this.c16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c16.Location = new System.Drawing.Point(246, 222);
            this.c16.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c16.Name = "c16";
            this.c16.Size = new System.Drawing.Size(234, 21);
            this.c16.TabIndex = 32;
            this.c16.Text = "Kế toán - Ủy viên";
            // 
            // c15
            // 
            this.c15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c15.Location = new System.Drawing.Point(246, 198);
            this.c15.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c15.Name = "c15";
            this.c15.Size = new System.Drawing.Size(234, 21);
            this.c15.TabIndex = 29;
            this.c15.Text = "Phụ trách phỏng TCKT - Ủy viên";
            // 
            // c14
            // 
            this.c14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c14.Location = new System.Drawing.Point(246, 174);
            this.c14.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c14.Name = "c14";
            this.c14.Size = new System.Drawing.Size(234, 21);
            this.c14.TabIndex = 26;
            this.c14.Text = "Phụ trách khoa dược - Ủy viên";
            // 
            // c13
            // 
            this.c13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c13.Location = new System.Drawing.Point(246, 150);
            this.c13.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c13.Name = "c13";
            this.c13.Size = new System.Drawing.Size(234, 21);
            this.c13.TabIndex = 23;
            this.c13.Text = "Phó CN kho - Phụ trách kho - Ủy viên";
            // 
            // c12
            // 
            this.c12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(246, 126);
            this.c12.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(234, 21);
            this.c12.TabIndex = 20;
            this.c12.Text = "Trưởng phòng KHTH - Ủy viên";
            // 
            // c11
            // 
            this.c11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c11.Location = new System.Drawing.Point(246, 102);
            this.c11.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(234, 21);
            this.c11.TabIndex = 17;
            this.c11.Text = "Chủ tịch hội đồng";
            // 
            // kho
            // 
            this.kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(280, 10);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(200, 21);
            this.kho.TabIndex = 5;
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
            this.madv.TabIndex = 9;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(0, 320);
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
            this.manguon.TabIndex = 12;
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
            this.noingoai.TabIndex = 14;
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
            this.bbkiem.TabIndex = 7;
            // 
            // chkXml
            // 
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(400, 297);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 44;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // chkNgaykiem
            // 
            this.chkNgaykiem.AutoSize = true;
            this.chkNgaykiem.Location = new System.Drawing.Point(52, 297);
            this.chkNgaykiem.Name = "chkNgaykiem";
            this.chkNgaykiem.Size = new System.Drawing.Size(110, 17);
            this.chkNgaykiem.TabIndex = 45;
            this.chkNgaykiem.Text = "In theo ngày kiểm";
            this.chkNgaykiem.UseVisualStyleBackColor = true;
            // 
            // chkGianovat
            // 
            this.chkGianovat.AutoSize = true;
            this.chkGianovat.Location = new System.Drawing.Point(190, 297);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(126, 17);
            this.chkGianovat.TabIndex = 46;
            this.chkGianovat.Text = "In kèm giá trước VAT";
            this.chkGianovat.UseVisualStyleBackColor = true;
            // 
            // dmnhom
            // 
            this.dmnhom.FormattingEnabled = true;
            this.dmnhom.Location = new System.Drawing.Point(485, 10);
            this.dmnhom.Name = "dmnhom";
            this.dmnhom.Size = new System.Drawing.Size(265, 274);
            this.dmnhom.TabIndex = 47;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(665, 290);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(81, 17);
            this.chkAll.TabIndex = 48;
            this.chkAll.Text = "Chạn tất cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // rptBbknhap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(762, 364);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dmnhom);
            this.Controls.Add(this.chkGianovat);
            this.Controls.Add(this.chkNgaykiem);
            this.Controls.Add(this.chkXml);
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
            this.Controls.Add(this.c18);
            this.Controls.Add(this.c17);
            this.Controls.Add(this.c16);
            this.Controls.Add(this.c15);
            this.Controls.Add(this.c14);
            this.Controls.Add(this.c13);
            this.Controls.Add(this.c12);
            this.Controls.Add(this.c11);
            this.Controls.Add(this.c8);
            this.Controls.Add(this.c7);
            this.Controls.Add(this.c6);
            this.Controls.Add(this.c5);
            this.Controls.Add(this.c4);
            this.Controls.Add(this.c3);
            this.Controls.Add(this.c2);
            this.Controls.Add(this.c1);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
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
            this.Name = "rptBbknhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biên bản kiểm nhập";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptBbknhap_MouseMove);
            this.Load += new System.EventHandler(this.rptBbknhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptBbknhap_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			listNX.DisplayMember="MA";
			listNX.ValueMember="TEN";
			dtdmnx=d.get_data("select ma,ten,id,nhomcc from "+user+".d_dmnx where nhom="+i_nhom+" order by stt").Tables[0];
			listNX.DataSource=dtdmnx;

			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
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
            //
			bln_noingoai=d.bNoiNgoai_Hang(i_nhom) || d.bNoiNgoai_Nuoc(i_nhom);
			if(bln_noingoai)
			{
				if (d.bNoiNgoai_Hang(i_nhom))
				{
                    sql = "select a.*, b.stt, b.ten as tennhom, e.loai as idnn, f.ten as noingoai,e.ten as tenhang from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_nhomhang f";
					sql+=" where a.manhom=b.id and a.mahang=e.id and e.loai=f.id and a.nhom="+i_nhom+" order by a.id";
				}
				else
				{
                    sql = "select a.*, b.stt, b.ten as tennhom, e.loai as idnn, f.ten as noingoai,e.ten as tenhang from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmnuoc e, " + user + ".d_nhomnuoc f";
					sql+=" where a.manhom=b.id and a.manuoc=e.id and e.loai=f.id and a.nhom="+i_nhom+" order by a.id";
				}
			}
			else
			{
                sql = "select a.*, b.stt, b.ten as tennhom, a.maloai as idnn, f.ten as noingoai,e.ten as tenhang from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_dmloai f";
				sql+=" where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and a.nhom="+i_nhom+" order by a.id";
			}
			dt=d.get_data(sql).Tables[0];
            //           
                        			
            //
            dtnhom = d.get_data("select * from " + user + ".d_dmnhom where nhom=" + i_nhom + " order by id").Tables[0];
            dmnhom.DataSource = dtnhom;
            dmnhom.DisplayMember = "TEN";
            dmnhom.ValueMember = "ID";
            //
            dtnuoc = d.get_data("select * from " + user + ".d_dmnuoc where nhom=" + i_nhom + " order by id").Tables[0];
            dtnhombc = d.get_data("select * from " + user + ".d_nhombc where nhom=" + i_nhom + " order by id").Tables[0];
            dtnhomnuoc = d.get_data("select * from " + user + ".d_nhomnuoc where nhom=" + i_nhom + " order by id").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_Bbknhap.xml");
            ds.Tables[0].Columns.Add("tennx");
            ds.Tables[0].Columns.Add("sodk");
            ds.Tables[0].Columns.Add("ngayhoadon");
            ds.Tables[0].Columns.Add("sodangky");
			dsst.ReadXml("..\\..\\..\\xml\\d_stnhap.xml");
			d.ins_thongso(i_nhom,501,516);
            foreach (DataRow r in d.get_data("select * from " + user + ".d_thongso where id between 501 and 516 and nhom=" + i_nhom).Tables[0].Rows)
			{
				switch (int.Parse(r["id"].ToString()))
				{
					case 501:c1.Text=r["ten"].ToString().Trim();break;
					case 502:c2.Text=r["ten"].ToString().Trim();break;
					case 503:c3.Text=r["ten"].ToString().Trim();break;
					case 504:c4.Text=r["ten"].ToString().Trim();break;
					case 505:c5.Text=r["ten"].ToString().Trim();break;
					case 506:c6.Text=r["ten"].ToString().Trim();break;
					case 507:c7.Text=r["ten"].ToString().Trim();break;
					case 508:c8.Text=r["ten"].ToString().Trim();break;
					case 509:c11.Text=r["ten"].ToString().Trim();break;
					case 510:c12.Text=r["ten"].ToString().Trim();break;
					case 511:c13.Text=r["ten"].ToString().Trim();break;
					case 512:c14.Text=r["ten"].ToString().Trim();break;
					case 513:c15.Text=r["ten"].ToString().Trim();break;
					case 514:c16.Text=r["ten"].ToString().Trim();break;
					case 515:c17.Text=r["ten"].ToString().Trim();break;
					case 516:c18.Text=r["ten"].ToString().Trim();break;
				}
			}
			//
			manguon.Enabled=d.bQuanlynguon(i_nhom);
			//
			noingoai.DisplayMember="TEN";
			noingoai.ValueMember="ID";			
			if(bln_noingoai)
			{
                if (d.bNoiNgoai_Hang(i_nhom)) sql = "select * from " + user + ".d_nhomhang where nhom=" + i_nhom + " order by stt ";
                else sql = "select * from " + user + ".d_nhomnuoc where nhom=" + i_nhom + " order by stt ";
				noingoai.DataSource=d.get_data(sql).Tables[0];
			}
			else
                noingoai.DataSource = d.get_data("select * from " + user + ".d_dmloai where nhom=" + i_nhom + " order by stt ").Tables[0];
			//
			noingoai.SelectedIndex=-1;
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
			//		
            //
            s_manhom = "";
            for (int i = 0; i < dmnhom.Items.Count; i++) if (dmnhom.GetItemChecked(i)) s_manhom += dtnhom.Rows[i]["id"].ToString() + ",";
            //
			ds.Clear();
			dsst.Clear();
			//
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";
			s01="";s02="";s03="";s04="";
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(get_khott(int.Parse(kho.SelectedValue.ToString()))==1)
							get_nhap(mmyy);
						else
							get_nhap_kl(mmyy);
						//
					}
				}
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
			string ngay=(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text;
			if(manguon.SelectedIndex>=0)ngay="Nguồn: "+manguon.Text+" - "+ngay;
			ngay+=";"+s_tongcong;
			if (s01!="")
				foreach(DataRow r in ds.Tables[0].Rows)
				{
					r["c01"]=s01;r["c02"]=s02;r["c03"]=s03;r["c04"]=s04;
				}
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                ds.WriteXml("..\\xml\\bbknhap.xml", XmlWriteMode.WriteSchema);
            }
            string tmp = tenfile;
            if (chkGianovat.Checked) tmp = tmp.Replace(".rpt", "") + "_novat.rpt";
			frmReport f=new frmReport(d,ds.Tables[0], i_userid,tmp,tendv.Text.Trim()+"+"+kho.Text,ngay,c1.Text.Trim()+"+"+c11.Text.Trim(),c2.Text.Trim()+"+"+c12.Text.Trim(),c3.Text.Trim()+"+"+c13.Text.Trim(),c4.Text.Trim()+"+"+c14.Text.Trim(),c5.Text.Trim()+"+"+c15.Text.Trim(),c6.Text.Trim()+"+"+c16.Text.Trim(),c7.Text.Trim()+"+"+c17.Text.Trim(),c8.Text.Trim()+"+"+c18.Text.Trim());
			f.ShowDialog();
		}

		private void get_nhap(string d_mmyy)
		{
            xxx = user + d_mmyy;
            string ngay = (chkNgaykiem.Checked) ? "ngaykiem" : "ngaysp";
			sql="select to_char(a."+ngay+",'dd/mm/yyyy') as ngayhd,trim(a.sophieu)||'-'||trim(a.sohd) as sohd,b.mabd,b.soluong,b.vat,b.sotien,b.losx,b.handung, d.stt, d.ten as nhombd,g.ten as tennx,a.ngayhd as ngayhd1,b.sodangky ";
            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c," + user + ".d_dmnhom d, " + user + ".d_dmhang e," + user + ".d_dmnuoc f,"+user+".d_dmnx g";
			sql+=" where a.id=b.id and b.mabd=c.id and c.manhom=d.id and c.mahang=e.id and c.manuoc=f.id and a.madv=g.id and a.nhom="+i_nhom;
			sql+=" and a."+ngay+" between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (kho.SelectedIndex!=-1) sql+=" and a.makho="+int.Parse(kho.SelectedValue.ToString());
			if (madv.Text!="") sql+=" and a.madv="+i_madv;
			if(manguon.SelectedIndex>=0)sql+=" and a.manguon="+manguon.SelectedValue.ToString();
            if (s_manhom.Trim().Trim(',') != "") sql += " and c.manhom in(" + s_manhom.Trim().Trim(',') + ")";
			if(noingoai.SelectedIndex>=0)
			{
				if (bln_noingoai)
				{
					if (d.bNoiNgoai_Hang(i_nhom)) sql+=" and e.loai="+int.Parse(noingoai.SelectedValue.ToString());
					else sql+=" and f.loai="+int.Parse(noingoai.SelectedValue.ToString());
				}
				else sql+=" and c.maloai="+int.Parse(noingoai.SelectedValue.ToString());
			}
			if (bbkiem.Text!="") sql+=" and a.bbkiem='"+bbkiem.Text.Trim()+"'";
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
					r4["tenhang"]=r1["tenhang"].ToString();
					r4["dang"]=r1["dang"].ToString();
                    r4["sodk"] = r["sodangky"].ToString() == "" ? r1["sodk"].ToString() : r["sodangky"].ToString();
					r4["sohd"]=r["sohd"].ToString();
					r4["ngayhd"]=r["ngayhd"].ToString();
                    r4["ngayhoadon"] = r["ngayhd1"].ToString();
					r4["handung"]=r["handung"].ToString();
					r4["losx"]=r["losx"].ToString();
					//binh: them d_dmnhom.stt, d_dmnhom.ten
					r4["stt"]=r["stt"].ToString();
					r4["nhombd"]=r["nhombd"].ToString();
					r4["idnn"]=r1["idnn"].ToString();
					r4["noingoai"]=r1["noingoai"].ToString();
					r4["tennhom"]=(bbkiem.Text!="")?bbkiem.Text:r1["tennhom"].ToString();
					//
					if (r3!=null) r4["tennuoc"]=r3["ten"].ToString();
					r4["soluong"]=r["soluong"].ToString();
					r4["vat"]=r["vat"].ToString();
					r4["sotien"]=r["sotien"].ToString();
                    r4["tennx"] = r["tennx"].ToString();

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
			sql="select f.ten,to_char(a."+ngay+",'dd/mm/yyyy') as ngayhd,trim(a.sohd) as sohd,sum(b.sotien+b.sotien*b.vat/100) as sotien ";
            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c," + user + ".d_dmnhom d, " + user + ".d_dmhang e," + user + ".d_dmnx f," + user + ".d_dmnuoc g";
			sql+=" where a.id=b.id and b.mabd=c.id and c.manhom=d.id and c.mahang=e.id and a.madv=f.id and c.manuoc=g.id and a.nhom="+i_nhom;
			sql+=" and a."+ngay+" between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (kho.SelectedIndex!=-1) sql+=" and a.makho="+int.Parse(kho.SelectedValue.ToString());
			if (madv.Text!="") sql+=" and a.madv="+i_madv;
			if(manguon.SelectedIndex>=0)sql+=" and a.manguon="+manguon.SelectedValue.ToString();
			if(noingoai.SelectedIndex>=0)
			{
				if (bln_noingoai) 
				{
					if (d.bNoiNgoai_Hang(i_nhom)) sql+=" and e.loai="+int.Parse(noingoai.SelectedValue.ToString());
					else sql+=" and g.loai="+int.Parse(noingoai.SelectedValue.ToString());
				}
				else sql+=" and c.maloai="+int.Parse(noingoai.SelectedValue.ToString());
			}
			if (bbkiem.Text!="") sql+=" and a.bbkiem='"+bbkiem.Text.Trim()+"'";
			sql+=" group by f.ten,to_char(a."+ngay+",'dd/mm/yyyy'),trim(a.sohd)";
			decimal st=0;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				st=decimal.Parse(r["sotien"].ToString());
				s01+=r["ten"].ToString().Trim()+"\n\n";
				s02+=r["sohd"].ToString().Trim()+"\n\n";
				s03+=r["ngayhd"].ToString().Trim()+"\n\n";
				s04+=st.ToString("###,###,###,###.00")+"\n\n";
			}
		}

		private void get_nhap_kl(string d_mmyy)
		{
            xxx = user + d_mmyy;
			s_khott="";
            foreach (DataRow r in d.get_data("select * from " + user + ".d_dmkho where hide=0 and khott=1").Tables[0].Rows) s_khott += r["id"].ToString().Trim() + ",";
			sql="select to_char(a.ngay,'dd/mm/yyyy') as ngayhd,a.sophieu as sohd,b.mabd,b.soluong,0 as vat,b.soluong*t.giamua as sotien,t.losx,t.handung, d.stt, d.ten as nhombd,g.ten as tennx,t.sodangky ";
			sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmnhom d, "+user+".d_dmhang e,"+user+".d_dmnuoc f,"+user+".d_dmnx g";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.manhom=d.id and c.mahang=e.id  and c.manuoc=f.id and a.nhom="+i_nhom+" and a.loai='CK' and t.nhomcc=g.id";
			sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (kho.SelectedIndex!=-1) sql+=" and a.khon="+int.Parse(kho.SelectedValue.ToString());
			if (s_khott!="") sql+=" and a.khox in ("+s_khott.Substring(0,s_khott.Length-1)+")";
			if(manguon.SelectedIndex>=0)sql+=" and t.manguon="+manguon.SelectedValue.ToString();
            if (s_manhom.Trim().Trim(',') != "") sql += " and c.manhom in(" + s_manhom.Trim().Trim(',') + ")";
			if(noingoai.SelectedIndex>=0)
			{
				if (bln_noingoai)
				{
					if (d.bNoiNgoai_Hang(i_nhom)) sql+=" and e.loai="+int.Parse(noingoai.SelectedValue.ToString());
					else sql+=" and f.loai="+int.Parse(noingoai.SelectedValue.ToString());
				}
				else sql+=" and c.maloai="+int.Parse(noingoai.SelectedValue.ToString());
			}
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
					r4["tenhang"]=r1["tenhang"].ToString();
					r4["dang"]=r1["dang"].ToString();
                    r4["sodk"] = r["sodangky"].ToString() == "" ? r1["sodk"].ToString() : r["sodangky"].ToString();
					r4["sohd"]=r["sohd"].ToString();
					r4["ngayhd"]=r["ngayhd"].ToString();
					r4["handung"]=r["handung"].ToString();
					r4["losx"]=r["losx"].ToString();
					//binh: them d_dmnhom.stt, d_dmnhom.ten
					r4["stt"]=r["stt"].ToString();
					r4["nhombd"]=r["nhombd"].ToString();
					r4["idnn"]=r1["idnn"].ToString();
					r4["noingoai"]=r1["noingoai"].ToString();
                    r4["tennhom"] = r1["tennhom"].ToString();
					//
					if (r3!=null) r4["tennuoc"]=r3["ten"].ToString();
					r4["soluong"]=r["soluong"].ToString();
					r4["vat"]=r["vat"].ToString();
					r4["sotien"]=r["sotien"].ToString();
                    r4["tennx"] = r["tennx"].ToString();
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
			d.upd_thongso(i_nhom,502,"",c2.Text.Trim());
			d.upd_thongso(i_nhom,503,"",c3.Text.Trim());
			d.upd_thongso(i_nhom,504,"",c4.Text.Trim());
			d.upd_thongso(i_nhom,505,"",c5.Text.Trim());
			d.upd_thongso(i_nhom,506,"",c6.Text.Trim());
			d.upd_thongso(i_nhom,507,"",c7.Text.Trim());
			d.upd_thongso(i_nhom,508,"",c8.Text.Trim());
			d.upd_thongso(i_nhom,509,"",c11.Text.Trim());
			d.upd_thongso(i_nhom,510,"",c12.Text.Trim());
			d.upd_thongso(i_nhom,511,"",c13.Text.Trim());
			d.upd_thongso(i_nhom,512,"",c14.Text.Trim());
			d.upd_thongso(i_nhom,513,"",c15.Text.Trim());
			d.upd_thongso(i_nhom,514,"",c16.Text.Trim());
			d.upd_thongso(i_nhom,515,"",c17.Text.Trim());
			d.upd_thongso(i_nhom,516,"",c18.Text.Trim());
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void rptBbknhap_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
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
			Filter_dmnx(tendv.Text);
			listNX.BrowseToDmnx(tendv,madv,c1);
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
            string sql = "select khott from " + user + ".d_dmkho where hide=0 and id=" + i_kho;
			DataTable ldt=d.get_data(sql).Tables[0];
			foreach(DataRow r in ldt.Rows)
			{
				i_khott=int.Parse(r["khott"].ToString());
				break;
			}
			ldt.Dispose();
			return i_khott;
		}

        private void chkAll_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                for (int i = 0; i < dmnhom.Items.Count; i++) dmnhom.SetItemCheckState(i, CheckState.Checked);
            else
                for (int i = 0; i < dmnhom.Items.Count; i++) dmnhom.SetItemCheckState(i, CheckState.Unchecked);

        }
	}
}
