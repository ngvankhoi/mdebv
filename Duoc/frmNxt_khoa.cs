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
	/// Summary description for rptBhyt.
	/// </summary>
	public class frmNxt_khoa : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_userid=0;
        private string sql, mmyy, s_makho, s_manhom, user, xxx, stime, s_gia = "", s_expression1 = "", s_expression2 = "";
        private bool bThongke_thang = false;
		private DataTable dt=new DataTable();
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dssort=new DataSet();
		private DataTable dtkho=new DataTable();
		private DataTable dtnhom=new DataTable();
		private DataRow [] dr;
		private DataRow r1,r2,r3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox sort;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.CheckedListBox manhom;
        private CheckBox chkXML;
        private CheckBox chkDongia;
        private RadioButton radioButton1;
        private RadioButton rdthang;
        private Label label6;
        private NumericUpDown dent;
        private NumericUpDown yyyy;
        private NumericUpDown tut;
        private Label label7;
        private Label label8;
        private NumericUpDown mmtu;
        private NumericUpDown mmden;
        private NumericUpDown yyden;
        private NumericUpDown yytu;
        private Label label13;
        private Label label16;
        private CheckBox chkGianovat;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmNxt_khoa(AccessData acc, int nhom, string s_mmyy, string makho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;mmyy=s_mmyy;s_makho=makho;
			this.Text+=" tháng "+s_mmyy.Substring(0,2)+" năm 20"+s_mmyy.Substring(2);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNxt_khoa));
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.sort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkDongia = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdthang = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.dent = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.tut = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mmtu = new System.Windows.Forms.NumericUpDown();
            this.mmden = new System.Windows.Forms.NumericUpDown();
            this.yyden = new System.Windows.Forms.NumericUpDown();
            this.yytu = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmtu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yytu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(201, 262);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butXem
            // 
            this.butXem.Image = global::Duoc.Properties.Resources.Print1;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(132, 262);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 10;
            this.butXem.Text = "      &In";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 53);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 3;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(56, 75);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 6;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khoa :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thứ tự :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(56, 97);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(219, 21);
            this.makp.TabIndex = 9;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // sort
            // 
            this.sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sort.Location = new System.Drawing.Point(56, 207);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(219, 21);
            this.sort.TabIndex = 9;
            this.sort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 120);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(219, 84);
            this.kho.TabIndex = 7;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(281, 8);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(192, 276);
            this.manhom.TabIndex = 12;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(163, 234);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 17;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // chkDongia
            // 
            this.chkDongia.AutoSize = true;
            this.chkDongia.Location = new System.Drawing.Point(10, 234);
            this.chkDongia.Name = "chkDongia";
            this.chkDongia.Size = new System.Drawing.Size(86, 17);
            this.chkDongia.TabIndex = 16;
            this.chkDongia.Text = "Kèm đơn giá";
            this.chkDongia.UseVisualStyleBackColor = true;
            this.chkDongia.CheckedChanged += new System.EventHandler(this.chkDongia_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(171, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 60;
            this.radioButton1.Text = "Theo ngày";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdthang
            // 
            this.rdthang.AutoSize = true;
            this.rdthang.Checked = true;
            this.rdthang.Location = new System.Drawing.Point(56, 6);
            this.rdthang.Name = "rdthang";
            this.rdthang.Size = new System.Drawing.Size(84, 17);
            this.rdthang.TabIndex = 59;
            this.rdthang.TabStop = true;
            this.rdthang.Text = "Theo Tháng";
            this.rdthang.UseVisualStyleBackColor = true;
            this.rdthang.CheckedChanged += new System.EventHandler(this.rdthang_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(107, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 23);
            this.label6.TabIndex = 63;
            this.label6.Text = "đến :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dent
            // 
            this.dent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dent.Location = new System.Drawing.Point(146, 30);
            this.dent.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.dent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dent.Name = "dent";
            this.dent.Size = new System.Drawing.Size(40, 21);
            this.dent.TabIndex = 1;
            this.dent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(227, 30);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(48, 21);
            this.yyyy.TabIndex = 2;
            this.yyyy.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.yyyy.ValueChanged += new System.EventHandler(this.yyyy_ValueChanged);
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tut
            // 
            this.tut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tut.Location = new System.Drawing.Point(56, 30);
            this.tut.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tut.Name = "tut";
            this.tut.Size = new System.Drawing.Size(40, 21);
            this.tut.TabIndex = 0;
            this.tut.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tut.ValueChanged += new System.EventHandler(this.tut_ValueChanged);
            this.tut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(188, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 23);
            this.label7.TabIndex = 65;
            this.label7.Text = "năm";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Từ tháng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mmtu
            // 
            this.mmtu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmtu.Location = new System.Drawing.Point(185, 53);
            this.mmtu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mmtu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mmtu.Name = "mmtu";
            this.mmtu.Size = new System.Drawing.Size(40, 21);
            this.mmtu.TabIndex = 4;
            this.mmtu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mmtu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // mmden
            // 
            this.mmden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmden.Location = new System.Drawing.Point(185, 75);
            this.mmden.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mmden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mmden.Name = "mmden";
            this.mmden.Size = new System.Drawing.Size(40, 21);
            this.mmden.TabIndex = 7;
            this.mmden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mmden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yyden
            // 
            this.yyden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyden.Location = new System.Drawing.Point(227, 75);
            this.yyden.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyden.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyden.Name = "yyden";
            this.yyden.Size = new System.Drawing.Size(48, 21);
            this.yyden.TabIndex = 8;
            this.yyden.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yytu
            // 
            this.yytu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yytu.Location = new System.Drawing.Point(227, 53);
            this.yytu.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yytu.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yytu.Name = "yytu";
            this.yytu.Size = new System.Drawing.Size(48, 21);
            this.yytu.TabIndex = 5;
            this.yytu.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yytu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(142, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 17);
            this.label13.TabIndex = 81;
            this.label13.Text = "SốLiệu";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(142, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 17);
            this.label16.TabIndex = 85;
            this.label16.Text = "SốLiệu";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkGianovat
            // 
            this.chkGianovat.AutoSize = true;
            this.chkGianovat.Location = new System.Drawing.Point(10, 257);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(93, 17);
            this.chkGianovat.TabIndex = 86;
            this.chkGianovat.Text = "Giá trước VAT";
            this.chkGianovat.UseVisualStyleBackColor = true;
            // 
            // frmNxt_khoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(479, 299);
            this.Controls.Add(this.chkGianovat);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.mmtu);
            this.Controls.Add(this.mmden);
            this.Controls.Add(this.yyden);
            this.Controls.Add(this.yytu);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dent);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.tut);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rdthang);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.chkDongia);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.den);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNxt_khoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo nhập xuất tồn";
            this.Load += new System.EventHandler(this.frmNxt_khoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmtu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yytu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNxt_khoa_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
            sql = "select a.*,b.ten as tenhang,c.stt as sttnhom,c.ten as tennhom,d.ma as stk,d.ten as ttk ";
            sql+=" from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id ";
            sql+=" inner join " + user + ".d_dmnhom c on a.manhom=c.id ";
            sql += " inner join " + user + ".d_dmnuoc e on a.manuoc=e.id ";
            sql+=" left join "+user+".d_dmnhomkt d on a.sotk=d.id ";
            sql+=" where a.nhom=" + i_nhom;

            dt = d.get_data(sql).Tables[0];
			dssort.ReadXml("..\\..\\..\\xml\\d_sortnxt.xml");
			ds.ReadXml("..\\..\\..\\xml\\d_nxtnhathuoc.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_nxtnhathuoc.xml");
            ds.Tables[0].Columns.Add("stk");
            ds.Tables[0].Columns.Add("ttk");
            dsxml.Tables[0].Columns.Add("stk");
            dsxml.Tables[0].Columns.Add("ttk");
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
            kho.DataSource = dtkho;
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			

			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
            makp.DataSource = d.get_data("select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString().Trim() + ",%' order by stt").Tables[0];

            dtnhom = d.get_data("select * from " + user + ".d_dmnhom where nhom=" + i_nhom + " order by stt").Tables[0];
            manhom.DataSource = dtnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";

			sort.DisplayMember="TEN";
			sort.ValueMember="FIELD";
			sort.DataSource=dssort.Tables[0];

            chkDongia.Checked = d.Thongso("dgcstt") == "1";

            Enable_ngay((rdthang.Checked == true) ? true : false);
            mmtu.Value = decimal.Parse(tu.Text.Substring(3, 2));
            mmden.Value = decimal.Parse(den.Text.Substring(3, 2));
            yytu.Value = decimal.Parse(tu.Text.Substring(6, 4));
            yyden.Value = decimal.Parse(den.Text.Substring(6, 4)); 
            //
            tut.Value = mmtu.Value;
            dent.Value = mmden.Value;
            //

		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void items_tondau()
		{
			foreach(DataRow r in get_tondau().Tables[0].Rows)
			{
                sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["manhom"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tondau"]=r["soluong"].ToString();
                        r3["sttondau"] = r["sotien"].ToString();
						r3["slnhap"]=0;
                        r3["stnhap"] = 0;
						r3["slxuat"]=0;
                        r3["stxuat"] = 0;
                        r3["stk"] = r2["stk"].ToString();
                        r3["ttk"] = r2["ttk"].ToString();
                        r3["dongia"] = r["dongia"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
                    if (dr.Length > 0)
                    {
                        dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
				}
			}
			//nhap
            if (bThongke_thang == false)
            {
                foreach (DataRow r in get_nhap(" and a.ngay<to_date('" + tu.Text + "'," + stime + ")", " and a.ngay<to_date('" + tu.Text + "'," + stime + ")").Tables[0].Rows)
                {
                    sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
                    r1 = d.getrowbyid(ds.Tables[0], sql);
                    if (r1 == null)
                    {
                        r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                        if (r2 != null)
                        {
                            r3 = ds.Tables[0].NewRow();
                            r3["manhom"] = r2["sttnhom"].ToString();
                            r3["tennhom"] = r2["tennhom"].ToString();
                            r3["mabd"] = r["mabd"].ToString();
                            r3["ma"] = r2["ma"].ToString();
                            r3["ten"] = r2["ten"].ToString().Trim() + " " + r2["hamluong"].ToString();
                            r3["tenhc"] = r2["tenhc"].ToString();
                            r3["dang"] = r2["dang"].ToString();
                            r3["tenhang"] = r2["tenhang"].ToString();
                            r3["tondau"] = r["soluong"].ToString();
                            r3["sttondau"] = r["sotien"].ToString();
                            r3["slnhap"] = 0;
                            r3["stnhap"] = 0;
                            r3["stxuat"] = 0;
                            r3["slxuat"] = 0;
                            r3["stk"] = r2["stk"].ToString();
                            r3["ttk"] = r2["ttk"].ToString();
                            r3["dongia"] = r["dongia"].ToString();
                            ds.Tables[0].Rows.Add(r3);
                        }
                    }
                    else
                    {
                        dr = ds.Tables[0].Select(sql);
                        if (dr.Length > 0)
                        {
                            dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) + decimal.Parse(r["soluong"].ToString());
                            dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) + decimal.Parse(r["sotien"].ToString());
                        }
                    }
                }
                //xuat
                foreach (DataRow r in get_xuat(" and a.ngay<to_date('" + tu.Text + "'," + stime + ")").Tables[0].Rows)
                {
                    sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
                    r1 = d.getrowbyid(ds.Tables[0], sql);
                    if (r1 == null)
                    {
                        r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                        if (r2 != null)
                        {
                            r3 = ds.Tables[0].NewRow();
                            r3["manhom"] = r2["sttnhom"].ToString();
                            r3["tennhom"] = r2["tennhom"].ToString();
                            r3["mabd"] = r["mabd"].ToString();
                            r3["ma"] = r2["ma"].ToString();
                            r3["ten"] = r2["ten"].ToString().Trim() + " " + r2["hamluong"].ToString();
                            r3["tenhc"] = r2["tenhc"].ToString();
                            r3["dang"] = r2["dang"].ToString();
                            r3["tenhang"] = r2["tenhang"].ToString();
                            r3["tondau"] = r["soluong"].ToString();
                            r3["sttondau"] = r["sotien"].ToString();
                            r3["slnhap"] = 0;
                            r3["stnhap"] = 0;
                            r3["stk"] = r2["stk"].ToString();
                            r3["ttk"] = r2["ttk"].ToString();
                            r3["slxuat"] = 0;// r["soluong"].ToString();
                            r3["stxuat"] = 0;
                            r3["dongia"] = r["dongia"].ToString();
                            ds.Tables[0].Rows.Add(r3);
                        }
                    }
                    else
                    {
                        dr = ds.Tables[0].Select(sql);
                        if (dr.Length > 0)
                        {
                            dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) - decimal.Parse(r["soluong"].ToString());
                            dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) - decimal.Parse(r["sotien"].ToString());
                        }
                    }
                }
            }
		}
        private void items_tondau(string s_mmyy)
        {
            foreach (DataRow r in get_tondau(s_mmyy).Tables[0].Rows)
            {
                sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], sql);
                if (r1 == null)
                {
                    r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        r3 = ds.Tables[0].NewRow();
                        r3["manhom"] = r2["sttnhom"].ToString();
                        r3["tennhom"] = r2["tennhom"].ToString();
                        r3["mabd"] = r["mabd"].ToString();
                        r3["ma"] = r2["ma"].ToString();
                        r3["ten"] = r2["ten"].ToString().Trim() + " " + r2["hamluong"].ToString();
                        r3["tenhc"] = r2["tenhc"].ToString();
                        r3["dang"] = r2["dang"].ToString();
                        r3["tenhang"] = r2["tenhang"].ToString();
                        r3["tondau"] = r["soluong"].ToString();
                        r3["sttondau"] = r["sotien"].ToString();
                        r3["slnhap"] = 0;
                        r3["stnhap"] = 0;
                        r3["slxuat"] = 0;
                        r3["stxuat"] = 0;
                        r3["stk"] = r2["stk"].ToString();
                        r3["ttk"] = r2["ttk"].ToString();
                        r3["dongia"] = r["dongia"].ToString();
                        ds.Tables[0].Rows.Add(r3);
                    }
                }
                else
                {
                    dr = ds.Tables[0].Select(sql);
                    if (dr.Length > 0) dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) + decimal.Parse(r["soluong"].ToString());
                }
            }            
        }
		private DataSet get_tondau()
		{
            //string s_mmyy = mmtu.Value.ToString().PadLeft(2, '0') + yytu.Value.ToString().Substring(2, 2);
            xxx = user + mmyy;
			sql=" select a.mabd,";
            if (chkDongia.Checked) sql += s_gia + " as dongia,";
            else sql += "0 as dongia,";
            sql += "sum(a.tondau) as soluong, sum(a.tondau*" + s_gia + ") as sotien from " + xxx + ".d_tutrucct a," + user + ".d_dmbd b," + xxx + ".d_theodoi t";
			sql+=" where a.mabd=b.id and a.stt=t.id and a.makp="+int.Parse(makp.SelectedValue.ToString());
			if (s_makho!="") sql+=" and a.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (s_manhom!="") sql+=" and b.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			sql+=" group by a.mabd";
            if (chkDongia.Checked) sql += "," + s_gia;
			return d.get_data(sql);
		}

        private DataSet get_tondau(string s_mmyy)
        {
            xxx = user + s_mmyy;
            sql = " select a.mabd,";
            if (chkDongia.Checked) sql += s_gia + " as dongia,";
            else sql += "0 as dongia,";
            sql += "sum(a.tondau) as soluong, sum(a.tondau*" + s_gia + ") as sotien from " + xxx + ".d_tutrucct a," + user + ".d_dmbd b," + xxx + ".d_theodoi t";
            sql += " where a.mabd=b.id and a.stt=t.id and a.makp=" + int.Parse(makp.SelectedValue.ToString());
            if (s_makho != "") sql += " and a.makho in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            if (s_manhom != "") sql += " and b.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            sql += " group by a.mabd";
            if (chkDongia.Checked) sql += ",t.giamua";
            return d.get_data(sql);
        }

		private void items_xuat()
		{
            if (bThongke_thang)
            {
                s_expression1 = "";
                s_expression2 = "";
            }
            else
            {
                s_expression1 = " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                s_expression2 = " ";
            }
			foreach(DataRow r in get_xuat(s_expression1).Tables[0].Rows)
			{
                sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["manhom"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tondau"]=0;
                        r3["sttondau"] = 0;
						r3["slnhap"]=0;
                        r3["stnhap"] = 0;
                        r3["stk"] = r2["stk"].ToString();
                        r3["ttk"] = r2["ttk"].ToString();
						r3["slxuat"]=r["soluong"].ToString();
                        r3["stxuat"] = r["sotien"].ToString();
                        r3["dongia"] = r["dongia"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
                    if (dr.Length > 0)
                    {
                        dr[0]["slxuat"] = decimal.Parse(dr[0]["slxuat"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["stxuat"] = decimal.Parse(dr[0]["stxuat"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
				}
			}
		}

		private void items_nhap()
		{
            if (bThongke_thang)
            {
                s_expression1 = "";
                s_expression2 = "";
            }
            else
            {
                s_expression1 = " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                s_expression2 = " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            }
			foreach(DataRow r in get_nhap(s_expression1,s_expression2).Tables[0].Rows)
			{
                sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["manhom"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tondau"]=0;
                        r3["sttondau"] = 0;
						r3["slnhap"]=r["soluong"].ToString();
                        r3["stnhap"] = r["sotien"].ToString();
                        r3["slnhap"] = 0;
                        r3["stnhap"] = 0;
                        r3["slxuat"] = 0;
                        r3["stxuat"] = 0;
                        r3["stk"] = r2["stk"].ToString();
                        r3["ttk"] = r2["ttk"].ToString();
                        r3["dongia"] = r["dongia"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
                    if (dr.Length > 0)
                    {
                        dr[0]["slnhap"] = decimal.Parse(dr[0]["slnhap"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["stnhap"] = decimal.Parse(dr[0]["stnhap"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
				}
			}
		}
		private DataSet get_nhap(string cont1,string cont2)
		{
            xxx = user + mmyy;
            sql = " select b.mabd,";
            if (chkDongia.Checked) sql += s_gia + " as dongia,";
            else sql += "0 as dongia,";
            sql += "sum(b.soluong) as soluong, sum(b.soluong*" + s_gia + ") as sotien from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + user + ".d_dmbd c," + xxx + ".d_theodoi t";
			sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=t.id and a.loai=2 and a.makp="+int.Parse(makp.SelectedValue.ToString());
			if (s_makho!="") sql+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			sql+=cont1;
			sql+=" group by b.mabd";
            if (chkDongia.Checked) sql += "," + s_gia;
			sql+=" union all ";
			sql+=" select b.mabd,";
            if (chkDongia.Checked) sql += s_gia + " as dongia,";
            else sql += "0 as dongia,";
            sql += "sum(b.soluong) as soluong, sum(b.soluong*" + s_gia + ") as sotien  from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi t";
			sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=t.id and a.loai in ('BS') and a.khon="+int.Parse(makp.SelectedValue.ToString());
			if (s_makho!="") sql+=" and a.khox in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			sql+=cont2;
			sql+=" group by b.mabd";
            if (chkDongia.Checked) sql += "," + s_gia;
			return d.get_data(sql);
		}

		private DataSet get_xuat(string cont)
		{
            xxx = user + mmyy;
			sql=" select b.mabd,";
            if (chkDongia.Checked) sql += s_gia + " as dongia,";
            else sql += "0 as dongia,";
            sql += "sum(b.soluong) as soluong, sum(b.soluong*" + s_gia + ") as sotien  from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi t";
			sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=t.id and a.loai=2 and a.makp="+int.Parse(makp.SelectedValue.ToString());
			if (s_makho!="") sql+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			sql+=cont;
			sql+=" group by b.mabd";
            if (chkDongia.Checked) sql += "," + s_gia;
			sql+=" union all ";
			sql+=" select b.mabd,";
            if (chkDongia.Checked) sql += s_gia + " as dongia,";
            else sql += "0 as dongia,";
            sql += "sum(b.soluong) as soluong, sum(b.soluong*" + s_gia + ") as sotien  from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi t";
			sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=t.id and a.loai in ('TH','HT') and a.khox="+int.Parse(makp.SelectedValue.ToString());
			if (s_makho!="") sql+=" and a.khon in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			sql+=cont;
			sql+=" group by b.mabd";
            if (chkDongia.Checked) sql += "," + s_gia;
			return d.get_data(sql);
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{			
			print();
		}	

		private void print()
		{
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
            if (chkGianovat.Checked) s_gia = "t.gianovat ";
            else s_gia = "t.giamua ";
            bThongke_thang = rdthang.Checked;
            //
			s_makho="";s_manhom="";
			if (kho.SelectedItems.Count>0)
				for(int i=0;i<kho.Items.Count;i++) if (kho.GetItemChecked(i)) s_makho+=dtkho.Rows[i]["id"].ToString()+",";
			if (manhom.SelectedItems.Count>0)
				for(int i=0;i<manhom.Items.Count;i++) if (manhom.GetItemChecked(i)) s_manhom+=dtnhom.Rows[i]["id"].ToString()+",";
			ds.Clear();
            //
            if (radioButton1.Checked)
            {
                mmyy = mmtu.Value.ToString().PadLeft(2, '0') + yytu.Value.ToString().Substring(2, 2);
            }
            else
            {
                if (tut.Value > 9)
                { mmyy = tut.Value + yyyy.Value.ToString().Substring(2, 2); }
                else { mmyy = "0" + tut.Value + yyyy.Value.ToString().Substring(2, 2); }
            }
          	items_tondau();
            //
            //int y1 = int.Parse(yytu.Value.ToString()), m1 = int.Parse(tut.Value.ToString());
            //int y2 = int.Parse(yyden.Value.ToString()), m2 = int.Parse(dent.Value.ToString());
            int y1 = 0, y2 = 0, m1 = 0, m2 = 0;
            if (radioButton1.Checked)
            {
                y1 = int.Parse(yytu.Value.ToString()); m1 = int.Parse(mmtu.Value.ToString());
                y2 = int.Parse(yyden.Value.ToString()); m2 = int.Parse(mmden.Value.ToString());
            }
            else
            {
                y1 = int.Parse(yyyy.Value.ToString()); m1 = int.Parse(tut.Value.ToString());
                y2 = int.Parse(yyyy.Value.ToString()); m2 = int.Parse(dent.Value.ToString());
            }
            int itu, iden;

            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (d.bMmyy(mmyy))
                    {
                        items_nhap();
                        items_xuat();
                    }
                }
            }
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
			else
			{
				dsxml.Clear();
				foreach(DataRow r in ds.Tables[0].Select("true",sort.SelectedValue.ToString()+",ten"))
				{
					r3=dsxml.Tables[0].NewRow();
					r3["manhom"]=r["manhom"].ToString();
					r3["tennhom"]=r["tennhom"].ToString();
					r3["mabd"]=r["mabd"].ToString();
					r3["ma"]=r["ma"].ToString();
					r3["ten"]=r["ten"].ToString();
					r3["tenhc"]=r["tenhc"].ToString();
					r3["dang"]=r["dang"].ToString();
					r3["tenhang"]=r["tenhang"].ToString();
					r3["tondau"]=r["tondau"].ToString();
					r3["slnhap"]=r["slnhap"].ToString();
					r3["slxuat"]=r["slxuat"].ToString();

                    r3["sttondau"] = r["sttondau"].ToString();
                    r3["stnhap"] = r["stnhap"].ToString();
                    r3["stxuat"] = r["stxuat"].ToString();

                    r3["dongia"] = r["dongia"].ToString();
                    r3["stk"] = r["stk"].ToString();
                    r3["ttk"] = r["ttk"].ToString();
					dsxml.Tables[0].Rows.Add(r3);
				}
                if (chkXML.Checked)
                {
                    try
                    {
                        if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                        ds.WriteXml("..\\xml\\nxt_khoa.xml", XmlWriteMode.WriteSchema);
                    }
                    catch { }
                }
				frmReport f1=new frmReport(d,dsxml.Tables[0], i_userid,"d_nxt_khoa.rpt",makp.Text,s_title,"","","","","","","","");
				f1.ShowDialog(this);
			}
		}

        private void chkDongia_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkDongia) d.writeXml("d_thongso", "dgcstt", (chkDongia.Checked) ? "1" : "0");
        }

        private void rdthang_CheckedChanged(object sender, EventArgs e)
        {
            Enable_ngay((rdthang.Checked == true) ? true : false);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Enable_ngay((rdthang.Checked == true) ? true : false);
        }

        private void Enable_ngay(bool ena)
        {
            tu.Enabled = !ena;
            den.Enabled = !ena;
            mmtu.Enabled = !ena;
            mmden.Enabled = !ena;
            yytu.Enabled = !ena;
            yyden.Enabled = !ena;
            //
            tut.Enabled = ena;
            dent.Enabled = ena;
            yyyy.Enabled = ena;
        }

        private void tut_ValueChanged(object sender, EventArgs e)
        {

        }

        private void yyyy_ValueChanged(object sender, EventArgs e)
        {
            
        }

	}
}

