using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using LibDuoc;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptBbkiemke.
	/// </summary>
	public class rptBbkiemke : System.Windows.Forms.Form
	{
        // minh
        //Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private Excel.Application oxl;
        private Excel._Workbook owb;
        private Excel._Worksheet osheet;
        private Excel.Range orange;
        private string haison = "";

        private bool bln_noingoai = false, bnhom, bGiaban, bGiabandot;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_dongiale, i_userid = 0;
		private string sql,s_mmyy,s_kho,user,xxx,table;
		private DataRow r1,r2,r3;
		private DataSet ds=new DataSet();
		private DataSet dsrpt=new DataSet();
        private System.Data.DataTable dt = new System.Data.DataTable();
        private System.Data.DataTable dtnhom = new System.Data.DataTable();
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
		private System.Windows.Forms.Label lkhoa;
		private MaskedTextBox.MaskedTextBox c18;
		private MaskedTextBox.MaskedTextBox c17;
		private MaskedTextBox.MaskedTextBox c16;
		private MaskedTextBox.MaskedTextBox c15;
		private MaskedTextBox.MaskedTextBox c14;
		private MaskedTextBox.MaskedTextBox c13;
		private MaskedTextBox.MaskedTextBox c12;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.ComboBox nguon;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox noingoai;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.CheckBox chkloai;
        private System.Windows.Forms.Button butExcel;
        private System.Windows.Forms.CheckBox chkGianovat;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBbkiemke(AccessData acc,int nhom,string kho,string mmyy,bool dmnhom,bool giaban,string _table, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; table = _table;            
			s_kho=kho;bnhom=dmnhom;bGiaban=giaban;
			mm.Value=decimal.Parse(mmyy.Substring(0,2));
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
            i_userid = _userid;
            // minh
            //lan.Read_Language_to_Xml(this.Name.ToString(), this);
            //lan.Changelanguage_to_English(this.Name.ToString(), this);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBbkiemke));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
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
            this.lkhoa = new System.Windows.Forms.Label();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.nguon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.noingoai = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkloai = new System.Windows.Forms.CheckBox();
            this.butExcel = new System.Windows.Forms.Button();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(99, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(157, 259);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 21;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(297, 259);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 23;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // c1
            // 
            this.c1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1.Location = new System.Drawing.Point(52, 59);
            this.c1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(192, 21);
            this.c1.TabIndex = 5;
            // 
            // c2
            // 
            this.c2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2.Location = new System.Drawing.Point(52, 83);
            this.c2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(192, 21);
            this.c2.TabIndex = 7;
            // 
            // c3
            // 
            this.c3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3.Location = new System.Drawing.Point(52, 107);
            this.c3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(192, 21);
            this.c3.TabIndex = 9;
            // 
            // c4
            // 
            this.c4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c4.Location = new System.Drawing.Point(52, 131);
            this.c4.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(192, 21);
            this.c4.TabIndex = 11;
            // 
            // c5
            // 
            this.c5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c5.Location = new System.Drawing.Point(52, 155);
            this.c5.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(192, 21);
            this.c5.TabIndex = 13;
            // 
            // c6
            // 
            this.c6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c6.Location = new System.Drawing.Point(52, 179);
            this.c6.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(192, 21);
            this.c6.TabIndex = 15;
            // 
            // c7
            // 
            this.c7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c7.Location = new System.Drawing.Point(52, 203);
            this.c7.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(192, 21);
            this.c7.TabIndex = 17;
            // 
            // c8
            // 
            this.c8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c8.Location = new System.Drawing.Point(52, 227);
            this.c8.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c8.Name = "c8";
            this.c8.Size = new System.Drawing.Size(192, 21);
            this.c8.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-3, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "1. ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-3, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "2. ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-3, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "3. ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-3, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "4. ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-3, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "5. ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-3, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "6. ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-3, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "7. ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-3, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 23);
            this.label11.TabIndex = 20;
            this.label11.Text = "8. ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c18
            // 
            this.c18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c18.Location = new System.Drawing.Point(246, 227);
            this.c18.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c18.Name = "c18";
            this.c18.Size = new System.Drawing.Size(234, 21);
            this.c18.TabIndex = 20;
            this.c18.Text = "Thủ kho - Ủy viên";
            // 
            // c17
            // 
            this.c17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c17.Location = new System.Drawing.Point(246, 203);
            this.c17.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c17.Name = "c17";
            this.c17.Size = new System.Drawing.Size(234, 21);
            this.c17.TabIndex = 18;
            this.c17.Text = "Thủ kho - Ủy viên";
            // 
            // c16
            // 
            this.c16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c16.Location = new System.Drawing.Point(246, 179);
            this.c16.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c16.Name = "c16";
            this.c16.Size = new System.Drawing.Size(234, 21);
            this.c16.TabIndex = 16;
            this.c16.Text = "Kế toán - Ủy viên";
            // 
            // c15
            // 
            this.c15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c15.Location = new System.Drawing.Point(246, 155);
            this.c15.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c15.Name = "c15";
            this.c15.Size = new System.Drawing.Size(234, 21);
            this.c15.TabIndex = 14;
            this.c15.Text = "Phụ trách phỏng TCKT - Ủy viên";
            // 
            // c14
            // 
            this.c14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c14.Location = new System.Drawing.Point(246, 131);
            this.c14.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c14.Name = "c14";
            this.c14.Size = new System.Drawing.Size(234, 21);
            this.c14.TabIndex = 12;
            this.c14.Text = "Phụ trách khoa dược - Ủy viên";
            // 
            // c13
            // 
            this.c13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c13.Location = new System.Drawing.Point(246, 107);
            this.c13.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c13.Name = "c13";
            this.c13.Size = new System.Drawing.Size(234, 21);
            this.c13.TabIndex = 10;
            this.c13.Text = "Phó CN kho - Phụ trách kho - Ủy viên";
            // 
            // c12
            // 
            this.c12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(246, 83);
            this.c12.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(234, 21);
            this.c12.TabIndex = 8;
            this.c12.Text = "Trưởng phòng KHTH - Ủy viên";
            // 
            // c11
            // 
            this.c11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c11.Location = new System.Drawing.Point(246, 59);
            this.c11.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(234, 21);
            this.c11.TabIndex = 6;
            this.c11.Text = "Chủ tịch hội đồng";
            // 
            // kho
            // 
            this.kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(246, 11);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(234, 21);
            this.kho.TabIndex = 2;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // lkhoa
            // 
            this.lkhoa.Location = new System.Drawing.Point(191, 10);
            this.lkhoa.Name = "lkhoa";
            this.lkhoa.Size = new System.Drawing.Size(52, 23);
            this.lkhoa.TabIndex = 22;
            this.lkhoa.Text = "Kho :";
            this.lkhoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(137, 11);
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
            this.yyyy.TabIndex = 1;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(53, 11);
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
            this.mm.Size = new System.Drawing.Size(40, 21);
            this.mm.TabIndex = 0;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // nguon
            // 
            this.nguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguon.Location = new System.Drawing.Point(52, 35);
            this.nguon.Name = "nguon";
            this.nguon.Size = new System.Drawing.Size(196, 21);
            this.nguon.TabIndex = 3;
            this.nguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nguồn";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // noingoai
            // 
            this.noingoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noingoai.Location = new System.Drawing.Point(312, 35);
            this.noingoai.Name = "noingoai";
            this.noingoai.Size = new System.Drawing.Size(168, 21);
            this.noingoai.TabIndex = 4;
            this.noingoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(246, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 23);
            this.label14.TabIndex = 28;
            this.label14.Text = "Nội/ngoại";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkloai
            // 
            this.chkloai.Location = new System.Drawing.Point(12, 248);
            this.chkloai.Name = "chkloai";
            this.chkloai.Size = new System.Drawing.Size(148, 24);
            this.chkloai.TabIndex = 29;
            this.chkloai.Text = "In phân lọai";
            // 
            // butExcel
            // 
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(227, 259);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(70, 25);
            this.butExcel.TabIndex = 22;
            this.butExcel.Text = "&Excel";
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // chkGianovat
            // 
            this.chkGianovat.Location = new System.Drawing.Point(12, 266);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(148, 24);
            this.chkGianovat.TabIndex = 30;
            this.chkGianovat.Text = "In Giá trước thuế";
            // 
            // rptBbkiemke
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(498, 302);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.chkGianovat);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.noingoai);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.nguon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.lkhoa);
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
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkloai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptBbkiemke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biên bản kiểm kê";
            this.Load += new System.EventHandler(this.rptBbkiemke_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptBbkiemke_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            bGiabandot = d.bGiaban_theodot(i_nhom);
			i_dongiale=d.d_dongia_le(i_nhom);
			if (bnhom) label14.Text="Nhóm :";
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
            if (table == "d_tonkhoct")
            {
                sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
                if (s_kho != "") sql += " and id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                sql += " order by stt";
            }
            else
            {
                lkhoa.Text = "Khoa :";
                sql = "select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString()+",%'";
                sql += " order by stt";
            }
			kho.DataSource=d.get_data(sql).Tables[0];
			//
			//Load_nguon
			nguon.DisplayMember="TEN";
			nguon.ValueMember="ID";
			sql="select * from "+user+".d_dmnguon where nhom="+i_nhom;			
			sql+=" order by stt";
			nguon.DataSource=d.get_data(sql).Tables[0];
			nguon.SelectedIndex=-1;
			//
			if (!bnhom) bln_noingoai=d.bNoiNgoai_Hang(i_nhom) || d.bNoiNgoai_Nuoc(i_nhom);
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
                sql = "select a.*, b.stt, b.ten as tennhom, a.maloai as idnn, f.ten as noingoai from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_dmloai f";
				sql+=" where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and a.nhom="+i_nhom+" order by a.id";
			}
			dt=d.get_data(sql).Tables[0];
			//
            dtnhom = d.get_data("select * from " + user + ".d_dmnhom where nhom=" + i_nhom + " order by id").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_Bbkiemke.xml");
			dsrpt.ReadXml("..\\..\\..\\xml\\d_Bbkiemke.xml");
			d.ins_thongso(i_nhom,601,616);
            foreach (DataRow r in d.get_data("select * from " + user + ".d_thongso where id between 601 and 616 and nhom=" + i_nhom).Tables[0].Rows)
			{
				switch (int.Parse(r["id"].ToString()))
				{
					case 601:c1.Text=r["ten"].ToString().Trim();break;
					case 602:c2.Text=r["ten"].ToString().Trim();break;
					case 603:c3.Text=r["ten"].ToString().Trim();break;
					case 604:c4.Text=r["ten"].ToString().Trim();break;
					case 605:c5.Text=r["ten"].ToString().Trim();break;
					case 606:c6.Text=r["ten"].ToString().Trim();break;
					case 607:c7.Text=r["ten"].ToString().Trim();break;
					case 608:c8.Text=r["ten"].ToString().Trim();break;
					case 609:c11.Text=r["ten"].ToString().Trim();break;
					case 610:c12.Text=r["ten"].ToString().Trim();break;
					case 611:c13.Text=r["ten"].ToString().Trim();break;
					case 612:c14.Text=r["ten"].ToString().Trim();break;
					case 613:c15.Text=r["ten"].ToString().Trim();break;
					case 614:c16.Text=r["ten"].ToString().Trim();break;
					case 615:c17.Text=r["ten"].ToString().Trim();break;
					case 616:c18.Text=r["ten"].ToString().Trim();break;
				}
			}
			noingoai.DisplayMember="TEN";
			noingoai.ValueMember="ID";
			if(bln_noingoai)
			{
                if (d.bNoiNgoai_Hang(i_nhom)) noingoai.DataSource = d.get_data("select * from " + user + ".d_nhomhang where nhom=" + i_nhom + " order by stt").Tables[0];
                else noingoai.DataSource = d.get_data("select * from " + user + ".d_nhomnuoc where nhom=" + i_nhom + " order by stt").Tables[0];
			}
            else if (bnhom) noingoai.DataSource = d.get_data("select * from " + user + ".d_dmnhom where nhom=" + i_nhom + " order by stt").Tables[0];
            else noingoai.DataSource = d.get_data("select * from " + user + ".d_dmloai where nhom=" + i_nhom + " order by stt").Tables[0];
			noingoai.SelectedIndex=-1;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			ds.Clear();
			get_tonkhoct();
			if (ds.Tables[0].Rows.Count==0)
			{
                // minh
                //MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
			string tenfile=(chkloai.Checked)?"d_bbkiemke_loai":(noingoai.SelectedIndex==-1)?"d_bbkiemke_nn":"d_bbkiemke";
			if (bGiaban) tenfile+="_gban";
			else if (d.bKiemke_c14(i_nhom)) tenfile="d_bbkiemke_c14";
			tenfile+=".rpt";

            frmReport f = new frmReport(d, dsrpt.Tables[0], i_userid, tenfile, kho.Text + ((nguon.SelectedIndex >= 0) ? " - Nguồn: " + nguon.Text : ""), "Tháng " + mm.Value.ToString().PadLeft(2, '0') + " năm " + yyyy.Value.ToString(), c1.Text.Trim() + "+" + c11.Text, c2.Text.Trim() + "+" + c12.Text, c3.Text.Trim() + "+" + c13.Text, c4.Text.Trim() + "+" + c14.Text, c5.Text.Trim() + "+" + c15.Text, c6.Text.Trim() + "+" + c16.Text, c7.Text.Trim() + "+" + c17.Text, c8.Text.Trim() + "+" + c18.Text);
            f.ShowDialog();
		}

		private void get_sort()
		{
			dsrpt.Clear();
			DataRow r1,r2;
			DataRow [] dr;
			string sort=(d.bKiemke_c14(i_nhom))?"ten":"idnn,stt,ten";
			foreach(DataRow r in ds.Tables[0].Select("sttondau+stnhap-stxuat>0 or tondau+slnhap-slxuat>0 or thua+thieu+hongvo>=0",sort))
			{
				sql="mabd="+int.Parse(r["mabd"].ToString())+" and giamua="+decimal.Parse(r["giamua"].ToString())+" and handung='"+r["handung"].ToString()+"'";
				r1=d.getrowbyid(dsrpt.Tables[0],sql);
				if (r1==null)
				{
					r2=dsrpt.Tables[0].NewRow();
					r2["tennhom"]=r["tennhom"].ToString();
					r2["mabd"]=r["mabd"].ToString();
					r2["ma"]=r["ma"].ToString();
					r2["ten"]=r["ten"].ToString();
					r2["tenhc"]=r["tenhc"].ToString();
					r2["dang"]=r["dang"].ToString();
					r2["tondau"]=r["tondau"].ToString();
					r2["sttondau"]=r["sttondau"].ToString();
					r2["slnhap"]=r["slnhap"].ToString();
					r2["stnhap"]=r["stnhap"].ToString();
					r2["slxuat"]=r["slxuat"].ToString();
					r2["stxuat"]=r["stxuat"].ToString();
					r2["stt"]=r["stt"].ToString();
					r2["handung"]=r["handung"].ToString();
					r2["losx"]=r["losx"].ToString();
					r2["nuocsx"]=r["nuocsx"].ToString();
					r2["idnn"]=r["idnn"].ToString();
					r2["noingoai"]=r["noingoai"].ToString();
					r2["giamua"]=r["giamua"].ToString();
					r2["giaban"]=r["giaban"].ToString();
					r2["thua"]=r["thua"].ToString();
					r2["thieu"]=r["thieu"].ToString();
					r2["hongvo"]=r["hongvo"].ToString();
					r2["sttt"]=r["sttt"].ToString();
					dsrpt.Tables[0].Rows.Add(r2);
                }
                else
                {
                    dr = dsrpt.Tables[0].Select(sql);
                    if (dr.Length > 0)
                    {
                        dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) + decimal.Parse(r["tondau"].ToString());
                        dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) + decimal.Parse(r["sttondau"].ToString());
                        dr[0]["slnhap"] = decimal.Parse(dr[0]["slnhap"].ToString()) + decimal.Parse(r["slnhap"].ToString());
                        dr[0]["stnhap"] = decimal.Parse(dr[0]["stnhap"].ToString()) + decimal.Parse(r["stnhap"].ToString());
                        dr[0]["slxuat"] = decimal.Parse(dr[0]["slxuat"].ToString()) + decimal.Parse(r["slxuat"].ToString());
                        dr[0]["stxuat"] = decimal.Parse(dr[0]["stxuat"].ToString()) + decimal.Parse(r["stxuat"].ToString());
                        dr[0]["thua"] = decimal.Parse(dr[0]["thua"].ToString()) + decimal.Parse(r["thua"].ToString());
                        dr[0]["thieu"] = decimal.Parse(dr[0]["thieu"].ToString()) + decimal.Parse(r["thieu"].ToString());
                        dr[0]["hongvo"] = decimal.Parse(dr[0]["hongvo"].ToString()) + decimal.Parse(r["hongvo"].ToString());
                        dsrpt.Tables[0].Rows.Add(dr);
                    }
                }
			}
            DataSet tmp = new DataSet();
            tmp = dsrpt.Copy();
            dsrpt.Clear();
            dsrpt.Merge(tmp.Tables[0].Select("mabd<>0"));
		}

		private void get_tonkhoct()
		{
            xxx = user + s_mmyy;
            string s_field = (chkGianovat.Checked) ? "gianovat" : "giamua";
            sql = "select a.mabd,trunc(f." + s_field + "," + i_dongiale + ") giamua,a.stt as sttt,sum(a.tondau) as tondau,sum(a.slnhap) as slnhap,sum(a.slxuat) as slxuat,sum(a.tondau*f." + s_field + ") as sttondau,sum(a.slnhap*f." + s_field + ") as stnhap,sum(a.slxuat*f." + s_field + ") as stxuat, c.stt, c.ten as nhombd, f.handung,f.losx, b.manuoc, b.mahang, d.ten as nuocsx, e.ten as tenhang ";
            if (bGiaban && bGiabandot) sql += ",trunc(f.giaban," + i_dongiale + ") as giaban";// gia ban theo d_theodoi
            else if (bGiaban && !bGiabandot) sql += ",trunc(b.giaban," + i_dongiale + ") as giaban";//gia ban theo dmbd
			else sql+=",0 as giaban";            
			sql+=" from "+xxx+"."+table+" a, "+user+".d_dmbd b, "+user+".d_dmnhom c, "+user+".d_dmnuoc d, "+user+".d_dmhang e,"+xxx+".d_theodoi f ";
			sql+=" where a.mabd=b.id and b.manhom=c.id and b.manuoc=d.id and b.mahang=e.id and a.stt=f.id";
            if (table == "d_tonkhoct")
                sql += " and a.makho=" + int.Parse(kho.SelectedValue.ToString());
            else
                sql += " and a.makp=" + int.Parse(kho.SelectedValue.ToString());
			if(nguon.SelectedIndex>=0) sql+=" and f.manguon="+nguon.SelectedValue.ToString();
			if(noingoai.SelectedIndex>=0)
			{
				if (bln_noingoai)
				{
					if (d.bNoiNgoai_Hang(i_nhom)) sql+=" and e.loai="+int.Parse(noingoai.SelectedValue.ToString());
					else sql+=" and d.loai="+int.Parse(noingoai.SelectedValue.ToString());
				}
				else sql+=" and "+((bnhom)?"b.manhom=":"b.maloai=")+int.Parse(noingoai.SelectedValue.ToString());
			}
            sql += " and b.nhom=" + i_nhom;
			sql+=" group by a.mabd,trunc(f." + s_field + ","+i_dongiale+"),a.stt,c.stt,c.ten,f.handung,f.losx,b.manuoc,b.mahang,d.ten,e.ten";
            if (bGiaban && bGiabandot) sql += ",trunc(f.giaban," + i_dongiale + ") ";
            else if (bGiaban && !bGiabandot) sql += ",trunc(b.giaban," + i_dongiale + ") ";
            //if (bGiaban) sql+=",b.giaban";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r1!=null)
				{
					r2=d.getrowbyid(dtnhom,"id="+int.Parse(r1["manhom"].ToString()));
					r3 = ds.Tables[0].NewRow();
					r3["mabd"]=r["mabd"].ToString();
					r3["ma"]=r1["ma"].ToString();
					r3["ten"]=r1["ten"].ToString().Trim()+" "+r1["hamluong"].ToString();
					r3["tenhc"]=r1["tenhc"].ToString();
					r3["dang"]=r1["dang"].ToString();
					if (r2!=null) r3["tennhom"]=r2["ten"].ToString();
					r3["tondau"]=r["tondau"].ToString();
					r3["sttondau"]=r["sttondau"].ToString();
					r3["slnhap"]=r["slnhap"].ToString();
					r3["stnhap"]=r["stnhap"].ToString();
					r3["slxuat"]=r["slxuat"].ToString();
					r3["stxuat"]=r["stxuat"].ToString();
					r3["giamua"]=r["giamua"].ToString();
					r3["giaban"]=r["giaban"].ToString();
					r3["sttt"]=r["sttt"].ToString();
					r3["thua"]=0;
					r3["thieu"]=0;
					r3["hongvo"]=0;
					//Add STT Nhombd: de group by
					r3["stt"]=r["stt"].ToString();
					r3["handung"]=r["handung"].ToString();
					r3["losx"]=r["losx"].ToString();
					string s_tensx=(r["mahang"].ToString()=="0")?"":r["tenhang"].ToString();
					s_tensx+=(r["manuoc"].ToString()=="0")?"":" - "+r["nuocsx"].ToString();
					r3["nuocsx"]=s_tensx.Trim();
					r3["idnn"]=r1["idnn"].ToString();
					r3["noingoai"]=r1["noingoai"].ToString();
					//
					ds.Tables[0].Rows.Add(r3);
				}
			}
            if (table == "d_tonkhoct")
            {
                sql = "select b.mabd,trunc(f." + s_field + "," + i_dongiale + ") as giamua,b.sttt,a.khon,sum(b.soluong) as soluong from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + user + ".d_dmhang d," + xxx + ".d_theodoi f," + user + ".d_dmnuoc g  where a.id=b.id and b.mabd=c.id and c.mahang=d.id and b.sttt=f.id and c.manuoc=g.id";
                sql += " and a.khox=" + int.Parse(kho.SelectedValue.ToString());
                sql += " and a.loai='XK' and a.khon in (1,2,3)";
                if (nguon.SelectedIndex >= 0) sql += " and f.manguon=" + nguon.SelectedValue.ToString();
                if (noingoai.SelectedIndex >= 0)
                {
                    if (bln_noingoai)
                    {
                        if (d.bNoiNgoai_Hang(i_nhom)) sql += " and e.loai=" + int.Parse(noingoai.SelectedValue.ToString());
                        else sql += " and g.loai=" + int.Parse(noingoai.SelectedValue.ToString());
                    }
                    else sql += " and " + ((bnhom) ? "c.manhom=" : "c.maloai=") + int.Parse(noingoai.SelectedValue.ToString());
                }
                sql += " group by b.mabd,trunc(f." + s_field + "," + i_dongiale + "),b.sttt,a.khon";
                string fie;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    fie = (r["khon"].ToString() == "3") ? "thieu" : "hongvo";
                    r1 = d.getrowbyid(ds.Tables[0], "mabd=" + int.Parse(r["mabd"].ToString()) + " and giamua=" + decimal.Parse(r["giamua"].ToString()) + " and sttt=" + decimal.Parse(r["sttt"].ToString()));
                    if (r1 != null)
                        r1[fie] = r["soluong"].ToString();
                }
                sql = "select b.mabd,trunc(f." + s_field + "," + i_dongiale + ") as giamua,e.stt sttt,sum(b.soluong) as soluong from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c," + user + ".d_dmhang d," + xxx + "." + table + " e," + xxx + ".d_theodoi f," + user + ".d_dmnuoc g where a.id=b.id and b.mabd=c.id and c.mahang=d.id and a.id=e.idn and e.stt=f.id and c.manuoc=g.id";
                sql += " and a.makho=" + int.Parse(kho.SelectedValue.ToString());
                sql += " and a.loai='T'";
                if (nguon.SelectedIndex >= 0) sql += " and f.manguon=" + nguon.SelectedValue.ToString();
                if (noingoai.SelectedIndex >= 0)
                {
                    if (bln_noingoai)
                    {
                        if (d.bNoiNgoai_Hang(i_nhom)) sql += " and e.loai=" + int.Parse(noingoai.SelectedValue.ToString());
                        else sql += " and g.loai=" + int.Parse(noingoai.SelectedValue.ToString());
                    }
                    else sql += " and " + ((bnhom) ? "c.manhom=" : "c.maloai=") + int.Parse(noingoai.SelectedValue.ToString());
                }
                sql += " group by b.mabd,trunc(f." + s_field + "," + i_dongiale + "),e.stt";
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    r1 = d.getrowbyid(ds.Tables[0], "mabd=" + int.Parse(r["mabd"].ToString()) + " and giamua=" + decimal.Parse(r["giamua"].ToString()) + " and sttt=" + decimal.Parse(r["sttt"].ToString()));
                    if (r1 != null)
                        r1["thua"] = r["soluong"].ToString();
                }
            }
			ds.AcceptChanges();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.upd_thongso(i_nhom,601,"",c1.Text.Trim());
			d.upd_thongso(i_nhom,602,"",c2.Text.Trim());
			d.upd_thongso(i_nhom,603,"",c3.Text.Trim());
			d.upd_thongso(i_nhom,604,"",c4.Text.Trim());
			d.upd_thongso(i_nhom,605,"",c5.Text.Trim());
			d.upd_thongso(i_nhom,606,"",c6.Text.Trim());
			d.upd_thongso(i_nhom,607,"",c7.Text.Trim());
			d.upd_thongso(i_nhom,608,"",c8.Text.Trim());
			d.upd_thongso(i_nhom,609,"",c11.Text.Trim());
			d.upd_thongso(i_nhom,610,"",c12.Text.Trim());
			d.upd_thongso(i_nhom,611,"",c13.Text.Trim());
			d.upd_thongso(i_nhom,612,"",c14.Text.Trim());
			d.upd_thongso(i_nhom,613,"",c15.Text.Trim());
			d.upd_thongso(i_nhom,614,"",c16.Text.Trim());
			d.upd_thongso(i_nhom,615,"",c17.Text.Trim());
			d.upd_thongso(i_nhom,616,"",c18.Text.Trim());
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

        private void butExcel_Click(object sender, EventArgs e)
        {
            try
            {
                s_mmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                ds.Clear();
                get_tonkhoct();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    // minh
                    // MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
                    return;
                }
                get_sort();
                string tenfile = (chkloai.Checked) ? "d_bbkiemke_loai" : (noingoai.SelectedIndex == -1) ? "d_bbkiemke_nn" : "d_bbkiemke";
                if (bGiaban) tenfile += "_gban";
                else if (d.bKiemke_c14(i_nhom)) tenfile = "d_bbkiemke_c14";
                tenfile += ".rpt";
                exp_excel(false);
            }
            catch
            {
            }
        }

        private void exp_excel(bool print)
        {
            try
            {
                d.check_process_Excel();
                string tenfile = "";
                System.Data.DataTable adt = new System.Data.DataTable();
                if(chkloai.Checked)
                    adt = tao_datatable_excel(ds, "TENNHOM,DANG,TEN");
                else
                    adt = tao_datatable_excel(ds, "DANG,TEN");
                haison = "STT+Mã số+Liệt kê+ĐVT+Đơn giá+Số lượng+Số tiền+Số lượng+Số tiền+Số lượng+Số tiền+Số lượng+Số tiền";
                d.check_process_Excel();
                int i_rec = 0, be = 8, dong = 6, sodong = adt.Rows.Count + dong, socot = adt.Columns.Count - 1, dongke = sodong - dong + be;
                char[] cSplit ={ '+' };
                string[] sTitle = haison.Split(cSplit);
                i_rec = sTitle.Length;
                tenfile = d.Export_Excel(adt, "bbknhap");
                
                oxl = new Excel.Application();
                oxl.Visible = true;

                owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = false;

                for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
                osheet.get_Range(d.getIndex(0) + "5", d.getIndex(0) + "5").EntireRow.Delete(Missing.Value);//remove row field
                osheet.get_Range(d.getIndex(be + 1) + dong.ToString(), d.getIndex(4) + (sodong+2).ToString()).NumberFormat = "###,###,###,###";
                osheet.get_Range(d.getIndex(0) + (be-1).ToString(), d.getIndex(socot) + dongke.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                try
                {
                    osheet.get_Range(d.getIndex(0) + (be+1).ToString(), d.getIndex(socot) + (dongke - 1).ToString()).Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlDash;
                }
                catch { }

                for (int i = 0; i < i_rec; i++)
                {
                    osheet.Cells[be, i + 1] = sTitle[i].ToString();
                }
                orange = osheet.get_Range("A" + be.ToString(), d.getIndex(socot) + be.ToString());
                orange.WrapText = true;
                orange = osheet.get_Range(d.getIndex(i_rec * 2 + 4) + "4", d.getIndex(i_rec * 2 + 5) + "4");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Bold = true;
                orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(socot) + (sodong + be).ToString());
                orange.Font.Name = "Arial";
                orange.Font.Size = 8;
                orange.EntireColumn.AutoFit();
                oxl.ActiveWindow.DisplayZeros = false;
                osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                osheet.PageSetup.LeftMargin = 20;
                osheet.PageSetup.RightMargin = 20;
                osheet.PageSetup.TopMargin = 30;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
                osheet.Cells[1, 1] = d.Syte; osheet.Cells[2, 1] = d.Tenbv;
                orange = osheet.get_Range(d.getIndex(1) + "1", d.getIndex(4) + "2");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                //osheet.Cells[1, 4] = "Cộng hòa xã hội chủ nghĩa Việt Nam";
                //osheet.Cells[2, 4] = "Độc lập - Tự do - Hạnh phúc";

                osheet.Cells[1, socot - 3] = "Mẫu số C14-H";
                osheet.Cells[2, socot - 3] = "(Ban hành theo QĐ số: 999-TC/QĐ/CĐKT";
                osheet.Cells[3, socot - 3] = "Ngày 02/11/1996 của Bộ Tài Chính)";
                orange = osheet.get_Range(d.getIndex(socot-4) + "1", d.getIndex(socot) + "3");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                osheet.Cells[4, 4] = "BIÊN BẢN KIỂM KÊ VẬT TƯ, SẢN PHẨM, HÀNG HÓA";
                orange = osheet.get_Range("D4", "E4");
                orange.Font.Name = "Arial"; orange.Font.Size = 14; orange.Font.Bold = true;
                if (kho.SelectedIndex >= 0)
                {
                    osheet.Cells[5, 1] = (table=="d_tonkhoct")?"Kho: ":"Khoa : "; osheet.Cells[5, 2] = kho.Text; osheet.get_Range("B5", "B6").Font.Bold=true;
                }
                osheet.Cells[5, 4] = "Thời điểm kiểm kê: " + DateTime.Now.Hour.ToString() + " giờ, ngày " + DateTime.Now.Date.ToString("dd/MM/yyyy");
                osheet.Cells[6, 4] = "Số liệu: " + mm.Text.PadLeft(2,'0')+"/"+yyyy.Value.ToString();
                orange = osheet.get_Range(d.getIndex(3) + "4", d.getIndex(socot) + "6");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                osheet.Cells[7, 6] = "Theo sổ sách";
                osheet.Cells[7, 8] = "Theo kiểm kê";
                osheet.Cells[7, 10] = "Chênh lệch thừa";
                osheet.Cells[7, 12] = "Chênh lệch thiếu";
                orange.EntireColumn.AutoFit();

                orange = osheet.get_Range("A7", "A8");
                orange.MergeCells=true;
                orange = osheet.get_Range("B7", "B8");
                orange.MergeCells = true;
                orange = osheet.get_Range("C7", "C8");
                orange.MergeCells = true;
                orange = osheet.get_Range("D7", "D8");
                orange.MergeCells = true;
                orange = osheet.get_Range("E7", "E8");
                orange.MergeCells = true;
                orange = osheet.get_Range("F7", "G7");
                orange.MergeCells = true; orange.Font.Bold = true;
                orange = osheet.get_Range("H7", "I7");
                orange.MergeCells = true; orange.Font.Bold = true;
                orange = osheet.get_Range("J7", "K7");
                orange.MergeCells = true; orange.Font.Bold = true;
                orange = osheet.get_Range("L7", "M7");
                orange.MergeCells = true;orange.Font.Bold = true;
                orange = osheet.get_Range("A7", "M8");
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                orange = osheet.get_Range(d.getIndex(0) + (sodong + 2).ToString(), d.getIndex(socot) + (sodong + 2).ToString());
                orange.Font.Bold = true;
                orange = osheet.get_Range(d.getIndex(0) + (sodong + 4).ToString(), d.getIndex(socot) + (sodong + 4).ToString());
                orange.MergeCells = true; orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection; 
                osheet.Cells[sodong + 4, 1] = "Người lập bảng                    Thủ kho                    Phụ trách bộ phận                    Kế toán trưởng                    Giám đốc";
                osheet.get_Range("A"+(sodong+4).ToString(), "B"+(sodong+4).ToString()).Font.Bold = true;


                if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                else oxl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private System.Data.DataTable tao_datatable_excel(DataSet dataset,string sort)
        {
            System.Data.DataTable dt_tmp = new System.Data.DataTable();
            dt_tmp.Columns.Add(new DataColumn("STT"));
            dt_tmp.Columns.Add(new DataColumn("MA"));
            dt_tmp.Columns.Add(new DataColumn("TEN"));
            dt_tmp.Columns.Add(new DataColumn("DANG"));
            dt_tmp.Columns.Add(new DataColumn("GIAMUA"));
            dt_tmp.Columns.Add(new DataColumn("TON"));
            dt_tmp.Columns.Add(new DataColumn("STTON"));
            dt_tmp.Columns.Add(new DataColumn("TONKK"));
            dt_tmp.Columns.Add(new DataColumn("STTONKK"));
            dt_tmp.Columns.Add(new DataColumn("THUA"));
            dt_tmp.Columns.Add(new DataColumn("STTHUA"));
            dt_tmp.Columns.Add(new DataColumn("THIEU"));
            dt_tmp.Columns.Add(new DataColumn("STTHIEU"));

            
            int iStt = 0;
            int iStt_nhom = 1;
            int irow = 0;
            string s_tennhom = "";
            string s_ma = "_",s_ten="_";
            string sql = "";
            decimal s_dongia = -1;
            decimal s01 = 0, s02 = 0, s03 = 0, s04 = 0, s05 = 0, s06 = 0, s07 = 0, s08 = 0;

            DataRow dr_tmp;
            
            foreach (DataRow dr in dataset.Copy().Tables[0].Select("",sort))
            {
                dr_tmp = dt_tmp.NewRow();
                s_ma = dr["MA"].ToString();
                s_ten = dr["TEN"].ToString();
                s_dongia = decimal.Parse(dr["GIAMUA"].ToString());
                sql = "MA='" + s_ma + "' and TEN='" + s_ten + "' and GIAMUA=" + s_dongia;
                try
                {
                    if (decimal.Parse(dr["TONDAU"].ToString()) + decimal.Parse(dr["SLNHAP"].ToString()) - decimal.Parse(dr["SLXUAT"].ToString()) > 0 )
                    {
                        if (s_tennhom != dr["TENNHOM"].ToString().Trim() && chkloai.Checked)
                        {
                            iStt = 1;
                            DataRow dr_tennhom = dt_tmp.NewRow();
                            dr_tennhom["STT"] = d.getIndex(iStt_nhom - 1);
                            dr_tennhom["MA"] = "-";
                            dr_tennhom["TEN"] = dr["TENNHOM"].ToString().ToUpper();
                            dt_tmp.Rows.Add(dr_tennhom);
                            iStt_nhom = iStt_nhom + 1;
                        }
                        else
                        {
                            iStt = iStt + 1;
                        }

                        DataRow row = d.getrowbyid(dt_tmp, sql);

                        if (row == null)
                        {
                            s_tennhom = dr["TENNHOM"].ToString().Trim();
                            dr_tmp["STT"] = iStt;
                            dr_tmp["MA"] = dr["MA"];
                            dr_tmp["TEN"] = dr["TEN"];
                            dr_tmp["DANG"] = dr["DANG"];
                            dr_tmp["GIAMUA"] = dr["GIAMUA"];
                            dr_tmp["TON"] = decimal.Parse(dr["TONDAU"].ToString()) + decimal.Parse(dr["SLNHAP"].ToString()) - decimal.Parse(dr["SLXUAT"].ToString());
                            dr_tmp["STTON"] = decimal.Parse(dr["STTONDAU"].ToString()) + decimal.Parse(dr["STNHAP"].ToString()) - decimal.Parse(dr["STXUAT"].ToString());
                            dr_tmp["TONKK"] = 0;// decimal.Parse(dr["TONDAU"].ToString()) + decimal.Parse(dr["SLNHAP"].ToString()) - decimal.Parse(dr["SLXUAT"].ToString());
                            dr_tmp["STTONKK"] = 0;// decimal.Parse(dr["STTONDAU"].ToString()) + decimal.Parse(dr["STNHAP"].ToString()) - decimal.Parse(dr["STXUAT"].ToString());
                            dr_tmp["THUA"] = 0;// decimal.Parse(dr["THUA"].ToString());
                            dr_tmp["STTHUA"] = 0;// decimal.Parse(dr["THUA"].ToString()) * decimal.Parse(dr["GIAMUA"].ToString());
                            dr_tmp["THIEU"] = 0;// decimal.Parse(dr["THIEU"].ToString()) + decimal.Parse(dr["HONGVO"].ToString());
                            dr_tmp["STTHIEU"] = 0;// (decimal.Parse(dr["THIEU"].ToString()) + decimal.Parse(dr["HONGVO"].ToString())) * decimal.Parse(dr["GIAMUA"].ToString());
                            s01 += 0;// decimal.Parse(dr["TONDAU"].ToString()) + decimal.Parse(dr["SLNHAP"].ToString()) - decimal.Parse(dr["SLXUAT"].ToString());
                            s02 += decimal.Parse(dr["STTONDAU"].ToString()) + decimal.Parse(dr["STNHAP"].ToString()) - decimal.Parse(dr["STXUAT"].ToString());
                            s03 += 0;// decimal.Parse(dr["TONDAU"].ToString()) + decimal.Parse(dr["SLNHAP"].ToString()) - decimal.Parse(dr["SLXUAT"].ToString());
                            s04 += 0;// decimal.Parse(dr["STTONDAU"].ToString()) + decimal.Parse(dr["STNHAP"].ToString()) - decimal.Parse(dr["STXUAT"].ToString());
                            s05 += 0;// decimal.Parse(dr["THUA"].ToString());
                            s06 += 0;// decimal.Parse(dr["THUA"].ToString()) * decimal.Parse(dr["GIAMUA"].ToString());
                            s07 += 0;// decimal.Parse(dr["THIEU"].ToString()) + decimal.Parse(dr["HONGVO"].ToString());
                            s08 += 0;// (decimal.Parse(dr["THIEU"].ToString()) + decimal.Parse(dr["HONGVO"].ToString())) * decimal.Parse(dr["GIAMUA"].ToString());
                            dt_tmp.Rows.Add(dr_tmp);
                            irow = irow + 1;
                            
                        }
                        else
                        {
                            string s_Test = row["TEN"].ToString();
                            row["TON"] = decimal.Parse(row["TON"].ToString()) + (decimal.Parse(dr["TONDAU"].ToString()) + decimal.Parse(dr["SLNHAP"].ToString()) - decimal.Parse(dr["SLXUAT"].ToString()));
                            row["STTON"] = decimal.Parse(row["STTON"].ToString()) + (decimal.Parse(dr["STTONDAU"].ToString()) + decimal.Parse(dr["STNHAP"].ToString()) - decimal.Parse(dr["STXUAT"].ToString()));
                            s02 += (decimal.Parse(dr["STTONDAU"].ToString()) + decimal.Parse(dr["STNHAP"].ToString()) - decimal.Parse(dr["STXUAT"].ToString()));
                        }
                    }
                    dt_tmp.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!");
                }
            }
            try
            {
                dr_tmp = dt_tmp.NewRow();
                dr_tmp["TEN"] = "     TỔNG CỘNG: ";
                dr_tmp["TON"] = s01;
                dr_tmp["STTON"] = s02;
                dr_tmp["TONKK"] = s03;
                dr_tmp["STTONKK"] = s04;
                dr_tmp["THUA"] = s05;
                dr_tmp["STTHUA"] = s06;
                dr_tmp["THIEU"] = s07;
                dr_tmp["STTHIEU"] = s08;
                dt_tmp.Rows.Add(dr_tmp);
            }
            catch { }
            return dt_tmp;
        }
	}
}
