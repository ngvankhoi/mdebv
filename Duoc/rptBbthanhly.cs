using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using LibDuoc;
using doiso;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptBbthanhly.
	/// </summary>
	public class rptBbthanhly : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker den;
		private decimal tongcong;
		private AccessData d;
        private int i_nhom, i_rec, d_userid=0;
		private string sql,ngay,tenfile,s_kho,user,stime,xxx;
		private DataRow r1,r2,r3;
		private DataRow []dr;
		private DataSet ds;
		private Doisototext doiso=new Doisototext();
		private DataSet dsxml=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtkho=new System.Data.DataTable();
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
		private MaskedTextBox.MaskedTextBox c108;
		private MaskedTextBox.MaskedTextBox c107;
		private MaskedTextBox.MaskedTextBox c106;
		private MaskedTextBox.MaskedTextBox c105;
		private MaskedTextBox.MaskedTextBox c104;
		private MaskedTextBox.MaskedTextBox c103;
		private MaskedTextBox.MaskedTextBox c102;
		private MaskedTextBox.MaskedTextBox c101;
		private MaskedTextBox.MaskedTextBox c109;
		private MaskedTextBox.MaskedTextBox c9;
		private System.Windows.Forms.Label label3;
		private MaskedTextBox.MaskedTextBox c110;
		private MaskedTextBox.MaskedTextBox c10;
		private System.Windows.Forms.Label label12;
		private MaskedTextBox.MaskedTextBox c111;
		private MaskedTextBox.MaskedTextBox c11;
		private System.Windows.Forms.Label label13;
		private MaskedTextBox.MaskedTextBox c112;
		private MaskedTextBox.MaskedTextBox c12;
		private System.Windows.Forms.Label label14;
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
        private System.Windows.Forms.CheckBox chkXML;
        private System.Windows.Forms.Label label15;
        private ComboBox makho;
        private System.Windows.Forms.Button butExcel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBbthanhly(AccessData acc,int nhom,string kho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
            d_userid = _userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBbthanhly));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
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
            this.c108 = new MaskedTextBox.MaskedTextBox();
            this.c107 = new MaskedTextBox.MaskedTextBox();
            this.c106 = new MaskedTextBox.MaskedTextBox();
            this.c105 = new MaskedTextBox.MaskedTextBox();
            this.c104 = new MaskedTextBox.MaskedTextBox();
            this.c103 = new MaskedTextBox.MaskedTextBox();
            this.c102 = new MaskedTextBox.MaskedTextBox();
            this.c101 = new MaskedTextBox.MaskedTextBox();
            this.c109 = new MaskedTextBox.MaskedTextBox();
            this.c9 = new MaskedTextBox.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c110 = new MaskedTextBox.MaskedTextBox();
            this.c10 = new MaskedTextBox.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.c111 = new MaskedTextBox.MaskedTextBox();
            this.c11 = new MaskedTextBox.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.c112 = new MaskedTextBox.MaskedTextBox();
            this.c12 = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.butExcel = new System.Windows.Forms.Button();
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
            this.label2.TabIndex = 1;
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
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(207, 331);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 27;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(277, 331);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 28;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // c1
            // 
            this.c1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1.Location = new System.Drawing.Point(52, 35);
            this.c1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(192, 21);
            this.c1.TabIndex = 3;
            // 
            // c2
            // 
            this.c2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2.Location = new System.Drawing.Point(52, 59);
            this.c2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(192, 21);
            this.c2.TabIndex = 5;
            // 
            // c3
            // 
            this.c3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3.Location = new System.Drawing.Point(52, 83);
            this.c3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(192, 21);
            this.c3.TabIndex = 7;
            // 
            // c4
            // 
            this.c4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c4.Location = new System.Drawing.Point(52, 107);
            this.c4.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(192, 21);
            this.c4.TabIndex = 9;
            // 
            // c5
            // 
            this.c5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c5.Location = new System.Drawing.Point(52, 131);
            this.c5.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(192, 21);
            this.c5.TabIndex = 11;
            // 
            // c6
            // 
            this.c6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c6.Location = new System.Drawing.Point(52, 155);
            this.c6.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(192, 21);
            this.c6.TabIndex = 13;
            // 
            // c7
            // 
            this.c7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c7.Location = new System.Drawing.Point(52, 179);
            this.c7.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(192, 21);
            this.c7.TabIndex = 15;
            // 
            // c8
            // 
            this.c8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c8.Location = new System.Drawing.Point(52, 203);
            this.c8.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c8.Name = "c8";
            this.c8.Size = new System.Drawing.Size(192, 21);
            this.c8.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-4, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "1. ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-4, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "2. ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-4, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "3. ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-4, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "4. ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-4, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "5. ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-4, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "6. ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-4, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "7. ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-4, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 23);
            this.label11.TabIndex = 20;
            this.label11.Text = "8. ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c108
            // 
            this.c108.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c108.Location = new System.Drawing.Point(246, 202);
            this.c108.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c108.Name = "c108";
            this.c108.Size = new System.Drawing.Size(234, 21);
            this.c108.TabIndex = 18;
            this.c108.Text = "Thủ kho - Ủy viên";
            // 
            // c107
            // 
            this.c107.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c107.Location = new System.Drawing.Point(246, 178);
            this.c107.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c107.Name = "c107";
            this.c107.Size = new System.Drawing.Size(234, 21);
            this.c107.TabIndex = 16;
            this.c107.Text = "Thủ kho - Ủy viên";
            // 
            // c106
            // 
            this.c106.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c106.Location = new System.Drawing.Point(246, 154);
            this.c106.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c106.Name = "c106";
            this.c106.Size = new System.Drawing.Size(234, 21);
            this.c106.TabIndex = 14;
            this.c106.Text = "Kế toán - Ủy viên";
            // 
            // c105
            // 
            this.c105.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c105.Location = new System.Drawing.Point(246, 130);
            this.c105.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c105.Name = "c105";
            this.c105.Size = new System.Drawing.Size(234, 21);
            this.c105.TabIndex = 12;
            this.c105.Text = "Phụ trách phỏng TCKT - Ủy viên";
            // 
            // c104
            // 
            this.c104.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c104.Location = new System.Drawing.Point(246, 106);
            this.c104.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c104.Name = "c104";
            this.c104.Size = new System.Drawing.Size(234, 21);
            this.c104.TabIndex = 10;
            this.c104.Text = "Phụ trách khoa dược - Ủy viên";
            // 
            // c103
            // 
            this.c103.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c103.Location = new System.Drawing.Point(246, 82);
            this.c103.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c103.Name = "c103";
            this.c103.Size = new System.Drawing.Size(234, 21);
            this.c103.TabIndex = 8;
            this.c103.Text = "Phó CN kho - Phụ trách kho - Ủy viên";
            // 
            // c102
            // 
            this.c102.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c102.Location = new System.Drawing.Point(246, 58);
            this.c102.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c102.Name = "c102";
            this.c102.Size = new System.Drawing.Size(234, 21);
            this.c102.TabIndex = 6;
            this.c102.Text = "Trưởng phòng KHTH - Ủy viên";
            // 
            // c101
            // 
            this.c101.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c101.Location = new System.Drawing.Point(246, 34);
            this.c101.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c101.Name = "c101";
            this.c101.Size = new System.Drawing.Size(234, 21);
            this.c101.TabIndex = 4;
            this.c101.Text = "Chủ tịch hội đồng";
            // 
            // c109
            // 
            this.c109.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c109.Location = new System.Drawing.Point(246, 226);
            this.c109.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c109.Name = "c109";
            this.c109.Size = new System.Drawing.Size(234, 21);
            this.c109.TabIndex = 20;
            this.c109.Text = "Thủ kho - Ủy viên";
            // 
            // c9
            // 
            this.c9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c9.Location = new System.Drawing.Point(52, 227);
            this.c9.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c9.Name = "c9";
            this.c9.Size = new System.Drawing.Size(192, 21);
            this.c9.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-4, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "9. ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c110
            // 
            this.c110.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c110.Location = new System.Drawing.Point(246, 250);
            this.c110.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c110.Name = "c110";
            this.c110.Size = new System.Drawing.Size(234, 21);
            this.c110.TabIndex = 22;
            this.c110.Text = "Thủ kho - Ủy viên";
            // 
            // c10
            // 
            this.c10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c10.Location = new System.Drawing.Point(52, 251);
            this.c10.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c10.Name = "c10";
            this.c10.Size = new System.Drawing.Size(192, 21);
            this.c10.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-4, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 23);
            this.label12.TabIndex = 27;
            this.label12.Text = "10. ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c111
            // 
            this.c111.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c111.Location = new System.Drawing.Point(246, 274);
            this.c111.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c111.Name = "c111";
            this.c111.Size = new System.Drawing.Size(234, 21);
            this.c111.TabIndex = 24;
            this.c111.Text = "Thủ kho - Ủy viên";
            // 
            // c11
            // 
            this.c11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c11.Location = new System.Drawing.Point(52, 275);
            this.c11.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(192, 21);
            this.c11.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(-4, 273);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 23);
            this.label13.TabIndex = 30;
            this.label13.Text = "11. ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c112
            // 
            this.c112.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c112.Location = new System.Drawing.Point(246, 298);
            this.c112.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c112.Name = "c112";
            this.c112.Size = new System.Drawing.Size(234, 21);
            this.c112.TabIndex = 26;
            this.c112.Text = "Thủ kho - Ủy viên";
            // 
            // c12
            // 
            this.c12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(52, 299);
            this.c12.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(192, 21);
            this.c12.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(-4, 297);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 23);
            this.label14.TabIndex = 33;
            this.label14.Text = "12. ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(400, 325);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 34;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(247, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Kho :";
            // 
            // makho
            // 
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.FormattingEnabled = true;
            this.makho.Location = new System.Drawing.Point(285, 10);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(195, 21);
            this.makho.TabIndex = 2;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butExcel
            // 
            this.butExcel.Image = global::Duoc.Properties.Resources.Export;
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(137, 331);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(70, 25);
            this.butExcel.TabIndex = 36;
            this.butExcel.Text = "&Excel";
            this.butExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // rptBbthanhly
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(498, 375);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.c112);
            this.Controls.Add(this.c12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.c111);
            this.Controls.Add(this.c11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.c110);
            this.Controls.Add(this.c10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.c109);
            this.Controls.Add(this.c9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c108);
            this.Controls.Add(this.c107);
            this.Controls.Add(this.c106);
            this.Controls.Add(this.c105);
            this.Controls.Add(this.c104);
            this.Controls.Add(this.c103);
            this.Controls.Add(this.c102);
            this.Controls.Add(this.c101);
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
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptBbthanhly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biên bản thanh lý";
            this.Load += new System.EventHandler(this.rptBbthanhly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptBbthanhly_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";
            makho.DataSource = dtkho;
            dt = d.get_data("select a.*,b.ten as tennuoc from " + user + ".d_dmbd a," + user + ".d_dmnuoc b where a.manuoc=b.id and a.nhom=" + i_nhom + " order by a.id").Tables[0];
			dsxml.ReadXml("..\\..\\..\\xml\\d_tsthanhly.xml");
			c1.Text=dsxml.Tables[0].Rows[0]["c01"].ToString();
			c2.Text=dsxml.Tables[0].Rows[0]["c02"].ToString();
			c3.Text=dsxml.Tables[0].Rows[0]["c03"].ToString();
			c4.Text=dsxml.Tables[0].Rows[0]["c04"].ToString();
			c5.Text=dsxml.Tables[0].Rows[0]["c05"].ToString();
			c6.Text=dsxml.Tables[0].Rows[0]["c06"].ToString();
			c7.Text=dsxml.Tables[0].Rows[0]["c07"].ToString();
			c8.Text=dsxml.Tables[0].Rows[0]["c08"].ToString();
			c9.Text=dsxml.Tables[0].Rows[0]["c09"].ToString();
			c10.Text=dsxml.Tables[0].Rows[0]["c10"].ToString();
			c11.Text=dsxml.Tables[0].Rows[0]["c11"].ToString();
			c12.Text=dsxml.Tables[0].Rows[0]["c12"].ToString();
			c101.Text=dsxml.Tables[0].Rows[0]["c101"].ToString();
			c102.Text=dsxml.Tables[0].Rows[0]["c102"].ToString();
			c103.Text=dsxml.Tables[0].Rows[0]["c103"].ToString();
			c104.Text=dsxml.Tables[0].Rows[0]["c104"].ToString();
			c105.Text=dsxml.Tables[0].Rows[0]["c105"].ToString();
			c106.Text=dsxml.Tables[0].Rows[0]["c106"].ToString();
			c107.Text=dsxml.Tables[0].Rows[0]["c107"].ToString();
			c108.Text=dsxml.Tables[0].Rows[0]["c108"].ToString();
			c109.Text=dsxml.Tables[0].Rows[0]["c109"].ToString();
			c110.Text=dsxml.Tables[0].Rows[0]["c110"].ToString();
			c111.Text=dsxml.Tables[0].Rows[0]["c111"].ToString();
			c112.Text=dsxml.Tables[0].Rows[0]["c112"].ToString();
		}

        private void exp_data()
        {
            Tao_dataset();
            tongcong = 0;
            DateTime dt1 = d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
            DateTime dt2 = d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (d.bMmyy(mmyy))
                    {
                        get_data(mmyy);
                    }
                }
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
                return;
            }
            ngay = (tu.Text == den.Text) ? lan.Change_language_MessageText("Ngày") + " " + tu.Text : lan.Change_language_MessageText("Từ ngày") + " " + tu.Text + " " + lan.Change_language_MessageText("đến") + " " + den.Text;
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                ds.WriteXml("..\\xml\\bbthanhly.xml", XmlWriteMode.WriteSchema);
            }
        }

		private void butIn_Click(object sender, System.EventArgs e)
		{
            exp_data();
            if (ds.Tables[0].Rows.Count > 0)
            {
                frmReport f = new frmReport(d, ds,d_userid,ngay,"rptBbthanhly.rpt");
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.writeXml("d_tsthanhly","c01",c1.Text);
			d.writeXml("d_tsthanhly","c02",c2.Text);
			d.writeXml("d_tsthanhly","c03",c3.Text);
			d.writeXml("d_tsthanhly","c04",c4.Text);
			d.writeXml("d_tsthanhly","c05",c5.Text);
			d.writeXml("d_tsthanhly","c06",c6.Text);
			d.writeXml("d_tsthanhly","c07",c7.Text);
			d.writeXml("d_tsthanhly","c08",c8.Text);
			d.writeXml("d_tsthanhly","c09",c9.Text);
			d.writeXml("d_tsthanhly","c10",c10.Text);
			d.writeXml("d_tsthanhly","c11",c11.Text);
			d.writeXml("d_tsthanhly","c12",c12.Text);
			d.writeXml("d_tsthanhly","c101",c101.Text);
			d.writeXml("d_tsthanhly","c102",c102.Text);
			d.writeXml("d_tsthanhly","c103",c103.Text);
			d.writeXml("d_tsthanhly","c104",c104.Text);
			d.writeXml("d_tsthanhly","c105",c105.Text);
			d.writeXml("d_tsthanhly","c106",c106.Text);
			d.writeXml("d_tsthanhly","c107",c107.Text);
			d.writeXml("d_tsthanhly","c108",c108.Text);
			d.writeXml("d_tsthanhly","c109",c109.Text);
			d.writeXml("d_tsthanhly","c110",c110.Text);
			d.writeXml("d_tsthanhly","c111",c111.Text);
			d.writeXml("d_tsthanhly","c112",c112.Text);
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void Tao_dataset()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_Bbthanhly.xml");
			foreach(DataRow r in dtkho.Rows)
			{
				dc=new DataColumn();
				dc.ColumnName="SOLUONG_"+r["id"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
			dc=new DataColumn();
			dc.ColumnName="TONGCONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc=new DataColumn();
			dc.ColumnName="DONGIA";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="SOTIEN";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="LYDO";
			dc.DataType=Type.GetType("System.String");
			ds.Tables[0].Columns.Add(dc);
		}

		private void get_data(string d_mmyy)
		{
            xxx = user + d_mmyy;
            sql = "select a.khox,b.mabd,b.soluong,b.soluong*t.giamua as sotien,t.handung,case when a.lydo='' then d.ten else a.lydo end as lydo,t.giamua as dongia from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi t," + user + ".d_dmkhac d ";
			sql+="where a.id=b.id and a.khon=d.id and b.sttt=t.id and b.mabd=c.id and a.loai='XK' and a.khon in (1,2) and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
            if (makho.SelectedIndex != -1) sql += " and a.khox=" + int.Parse(makho.SelectedValue.ToString());
			else if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by c.ten";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString())+" and handung='"+r["handung"].ToString()+"' and dongia="+decimal.Parse(r["dongia"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["stt"]=d.get_stt(ds.Tables[0]);
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["handung"]=r["handung"].ToString().Substring(0,2)+"/"+r["handung"].ToString().Substring(2);
                        r2["dongia"]=r["dongia"].ToString();
						foreach(DataRow r4 in dtkho.Rows) r2["soluong_"+r4["id"].ToString().Trim()]=0;
						r2["soluong_"+r["khox"].ToString().Trim()]=r["soluong"].ToString();
						r2["tongcong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						if (r["lydo"].ToString()!="") r2["lydo"]=r["lydo"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
                    dr = ds.Tables[0].Select("mabd=" + int.Parse(r["mabd"].ToString()) + " and handung='" + r["handung"].ToString() + "' and dongia=" + decimal.Parse(r["dongia"].ToString()));
                    if (dr.Length > 0)
                    {
                        dr[0]["soluong_" + r["khox"].ToString().Trim()] = decimal.Parse(dr[0]["soluong_" + r["khox"].ToString().Trim()].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["tongcong"] = decimal.Parse(dr[0]["tongcong"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
				}
				tongcong+=decimal.Parse(r["sotien"].ToString());
			}
		}

		private void exp_excel()
		{
			try
			{
				int be=21,dong=23,sodong=ds.Tables[0].Rows.Count+24,socot=ds.Tables[0].Columns.Count-2,dongke=sodong-1;
				tenfile=d.Export_Excel(ds,"bbthanhly");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				osheet.get_Range(d.getIndex(0)+"1",d.getIndex(1)+"1").EntireColumn.Delete(Missing.Value);
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
				osheet.get_Range(d.getIndex(5)+dong.ToString(),d.getIndex(socot)+sodong.ToString()).NumberFormat="#,##0.00";
				osheet.get_Range(d.getIndex(0)+"21",d.getIndex(socot-1)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				for(int i=1;i<6;i++)
				{
					osheet.Cells[dong-1,i]=get_title(i-1);
					orange=osheet.get_Range(d.getIndex(i-1)+"21",d.getIndex(i-1)+"22");
					orange.MergeCells=true;
				}
				for(int i=0;i<dtkho.Rows.Count;i++)	osheet.Cells[dong-1,i+6]=dtkho.Rows[i]["ten"].ToString();
				i_rec=dtkho.Rows.Count;
				for(int i=5;i<9;i++) osheet.Cells[dong-1,i+i_rec+1]=get_title(i);
				for(int i=6+i_rec;i<6+i_rec+3;i++)
				{
					orange=osheet.get_Range(d.getIndex(i)+"21",d.getIndex(i)+"22");
					orange.MergeCells=true;
				}
				osheet.Cells[dong-2,6]="Số lượng";
				orange=osheet.get_Range(d.getIndex(5)+"21",d.getIndex(i_rec+5)+"21");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Bold=true;
				orange=osheet.get_Range(d.getIndex(0)+dong.ToString(),d.getIndex(socot)+sodong.ToString());
				orange.Font.Name="Arial";
				orange.Font.Size=8;
				orange.EntireColumn.AutoFit();
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
				osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
				osheet.PageSetup.LeftMargin=20;
				osheet.PageSetup.RightMargin=20;
				osheet.PageSetup.TopMargin=30;
				osheet.PageSetup.CenterFooter="Trang : &P/&N";
				osheet.Cells[1,1]=d.Syte;osheet.Cells[2,1]=d.Tenbv;
				osheet.Cells[1,3]="BIÊN BẢN THANH LÝ,HỦY";
				osheet.Cells[2,3]=ngay;
				for(int i=0;i<16;i++) osheet.Cells[i+4,2]=get_ten(i);
				for(int i=0;i<12;i++) osheet.Cells[i+6,7]=get_chucdanh(i);
				orange=osheet.get_Range(d.getIndex(2)+"1",d.getIndex(socot-1)+"2");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size=12;
				orange.Font.Bold=true;
				osheet.Cells[sodong-1,2]="Tổng số tiền :";
				osheet.Cells[sodong-1,5+i_rec+3]=tongcong;
				string s=doiso.Doiso_Unicode(ds.Tables[0].Rows.Count.ToString()).Trim();
				osheet.Cells[sodong+1,2]="Tổng số :"+s.Substring(0,s.Length-4)+" khoản";
				osheet.Cells[sodong+2,2]="Số tiền :"+doiso.Doiso_Unicode(Convert.ToInt64(tongcong).ToString());
				int so1=sodong+4,so2=sodong+5;
				osheet.Cells[sodong+4,3]="HỘI ĐỒNG THANH LÝ";
				osheet.Cells[sodong+5,3]="(Ký)";
				orange=osheet.get_Range(d.getIndex(2)+so1.ToString(),d.getIndex(7)+so2.ToString());
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				so1=sodong-1;
				orange=osheet.get_Range(d.getIndex(1)+so1.ToString(),d.getIndex(socot)+so2.ToString());
				orange.Font.Bold=true;
				for(int i=sodong+6;i<sodong+6+12;i++) osheet.Cells[i,2]=get_ten(i-sodong-4);
				for(int i=sodong+6;i<sodong+6+12;i++) osheet.Cells[i,7]=get_chucdanh(i-sodong-6);
				oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private string get_ten(int i)
		{
			string []map={"Căn cứ quyết định số 03 QĐ/GĐ ngày . . . . . . . về việc thành lập hội đồng thanh lý thuốc quá hạn sử dụng tại các quầy phát lẻ.","Gồm các thành viên có tên sau đây :","1."+c1.Text,"2."+c2.Text,"3."+c3.Text,"4."+c4.Text,"5."+c5.Text,"6."+c6.Text,"7."+c7.Text,"8."+c8.Text,"9."+c9.Text,"10."+c10.Text,"11."+c11.Text,"12."+c12.Text,"    Đã tiến hành xem xét kiểm tra đề nghị thanh lý,hủy bỏ vào hồi      ngày     tháng    năm","Kết quả như sau :"};
			return map[i];
		}

		private string get_chucdanh(int i)
		{
			string [] map={c101.Text,c102.Text,c103.Text,c104.Text,c105.Text,c106.Text,c107.Text,c108.Text,c109.Text,c110.Text,c111.Text,c112.Text};
			return map[i];
		}

		private string get_title(int i)
		{
			string [] map={"TT","Tên","ĐVT","Nước SX","Hạn dùng","Tổng","Đơn giá","Số tiền","Lý do hủy"};
			return map[i];
		}

        private void butExcel_Click(object sender, EventArgs e)
        {
            exp_data();
            exp_excel();
        }
	}
}
