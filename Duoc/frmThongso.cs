using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
namespace Duoc
{
	/// <summary>
	/// Summary description for frmThongso.
	/// </summary>
	public class frmThongso : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.CheckBox c02;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private MaskedTextBox.MaskedTextBox c07;
		private MaskedTextBox.MaskedTextBox c08;
		private MaskedTextBox.MaskedTextBox c09;
		private System.Windows.Forms.Button butOK;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataSet dstt=new DataSet();
		private DataSet dsmua=new DataSet();
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private System.Windows.Forms.CheckBox c05;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown c10;
		private System.Windows.Forms.CheckBox c11;
		private System.Windows.Forms.CheckBox c12;
		private string s_mmyy,user;
		private int i_nhom,i_userid;
		private MaskedTextBox.MaskedTextBox c15;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox c16;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown c22;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox c23;
		private System.Windows.Forms.CheckBox c24;
        private System.Windows.Forms.CheckBox c25;
		private System.Windows.Forms.CheckBox c26;
		private System.Windows.Forms.CheckBox c27;
		private System.Windows.Forms.CheckBox c28;
		private System.Windows.Forms.CheckBox c29;
		private System.Windows.Forms.CheckBox c30;
		private System.Windows.Forms.CheckBox c31;
		private MaskedTextBox.MaskedTextBox c32;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button butHinh;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private MaskedTextBox.MaskedTextBox kho;
		private MaskedTextBox.MaskedTextBox hinh;
		private System.Windows.Forms.CheckBox c34;
		private System.Windows.Forms.CheckBox c36;
		private System.Windows.Forms.CheckBox c35;
		private System.Windows.Forms.CheckBox c37;
		private System.Windows.Forms.CheckBox c38;
		private System.Windows.Forms.CheckBox c39;
		private System.Windows.Forms.CheckBox c40;
        private System.Windows.Forms.CheckBox c41;
		private System.Windows.Forms.TabControl tab;
		private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label24;
		private MaskedTextBox.MaskedTextBox c56;
		private System.Windows.Forms.CheckBox c62;
        private System.Windows.Forms.CheckBox c70;
		private System.Windows.Forms.Label label33;
		private MaskedTextBox.MaskedTextBox c83;
		private MaskedTextBox.MaskedTextBox c84;
		private System.Windows.Forms.CheckBox c94;
		private System.Windows.Forms.CheckBox c95;
		private System.Windows.Forms.CheckBox c96;
		private System.Windows.Forms.CheckBox c97;
		private System.Windows.Forms.CheckBox c106;
		private System.Windows.Forms.Label label40;
		private MaskedTextBox.MaskedTextBox c112;
		private System.Windows.Forms.CheckBox c116;
		private System.Windows.Forms.Label label41;
		private MaskedTextBox.MaskedTextBox c120;
		private MaskedTextBox.MaskedTextBox c121;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.CheckBox c13;
		private System.Windows.Forms.CheckBox c04;
		private System.Windows.Forms.CheckBox c45;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.NumericUpDown c105;
        private System.Windows.Forms.Label label37;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThongso(LibDuoc.AccessData acc,string mmyy,int nhom,int userid,bool giaban,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			s_mmyy=mmyy;
			i_nhom=nhom;
			i_userid=userid;
			c13.Text="Khoá số liệu tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
			c13.Enabled=admin;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongso));
            this.c02 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c07 = new MaskedTextBox.MaskedTextBox();
            this.c08 = new MaskedTextBox.MaskedTextBox();
            this.c09 = new MaskedTextBox.MaskedTextBox();
            this.butOK = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.c05 = new System.Windows.Forms.CheckBox();
            this.c10 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.c11 = new System.Windows.Forms.CheckBox();
            this.c12 = new System.Windows.Forms.CheckBox();
            this.c15 = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.c16 = new MaskedTextBox.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c22 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.c23 = new System.Windows.Forms.CheckBox();
            this.c24 = new System.Windows.Forms.CheckBox();
            this.c25 = new System.Windows.Forms.CheckBox();
            this.c26 = new System.Windows.Forms.CheckBox();
            this.c27 = new System.Windows.Forms.CheckBox();
            this.c28 = new System.Windows.Forms.CheckBox();
            this.c29 = new System.Windows.Forms.CheckBox();
            this.c30 = new System.Windows.Forms.CheckBox();
            this.c31 = new System.Windows.Forms.CheckBox();
            this.c32 = new MaskedTextBox.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.butHinh = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.kho = new MaskedTextBox.MaskedTextBox();
            this.hinh = new MaskedTextBox.MaskedTextBox();
            this.c34 = new System.Windows.Forms.CheckBox();
            this.c36 = new System.Windows.Forms.CheckBox();
            this.c35 = new System.Windows.Forms.CheckBox();
            this.c37 = new System.Windows.Forms.CheckBox();
            this.c38 = new System.Windows.Forms.CheckBox();
            this.c39 = new System.Windows.Forms.CheckBox();
            this.c40 = new System.Windows.Forms.CheckBox();
            this.c41 = new System.Windows.Forms.CheckBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label37 = new System.Windows.Forms.Label();
            this.c105 = new System.Windows.Forms.NumericUpDown();
            this.label36 = new System.Windows.Forms.Label();
            this.c45 = new System.Windows.Forms.CheckBox();
            this.c04 = new System.Windows.Forms.CheckBox();
            this.c13 = new System.Windows.Forms.CheckBox();
            this.c116 = new System.Windows.Forms.CheckBox();
            this.c106 = new System.Windows.Forms.CheckBox();
            this.c97 = new System.Windows.Forms.CheckBox();
            this.c96 = new System.Windows.Forms.CheckBox();
            this.c95 = new System.Windows.Forms.CheckBox();
            this.c94 = new System.Windows.Forms.CheckBox();
            this.c70 = new System.Windows.Forms.CheckBox();
            this.c62 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.c121 = new MaskedTextBox.MaskedTextBox();
            this.c120 = new MaskedTextBox.MaskedTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.c56 = new MaskedTextBox.MaskedTextBox();
            this.c112 = new MaskedTextBox.MaskedTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.c84 = new MaskedTextBox.MaskedTextBox();
            this.c83 = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c22)).BeginInit();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c105)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // c02
            // 
            this.c02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c02.Location = new System.Drawing.Point(19, 32);
            this.c02.Name = "c02";
            this.c02.Size = new System.Drawing.Size(136, 20);
            this.c02.TabIndex = 2;
            this.c02.Text = "A01. Mã số tự động";
            this.c02.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(499, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ban giám đốc :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(470, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phụ trách bộ phận :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(499, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Người lập biểu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c07
            // 
            this.c07.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c07.Location = new System.Drawing.Point(587, 32);
            this.c07.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c07.Name = "c07";
            this.c07.Size = new System.Drawing.Size(171, 21);
            this.c07.TabIndex = 13;
            // 
            // c08
            // 
            this.c08.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c08.Location = new System.Drawing.Point(587, 80);
            this.c08.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c08.Name = "c08";
            this.c08.Size = new System.Drawing.Size(171, 21);
            this.c08.TabIndex = 15;
            // 
            // c09
            // 
            this.c09.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c09.Location = new System.Drawing.Point(587, 104);
            this.c09.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c09.Name = "c09";
            this.c09.Size = new System.Drawing.Size(171, 21);
            this.c09.TabIndex = 16;
            // 
            // butOK
            // 
            this.butOK.Image = global::Duoc.Properties.Resources.save;
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(326, 401);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(74, 25);
            this.butOK.TabIndex = 56;
            this.butOK.Text = "&Cập nhật";
            this.butOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(401, 401);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(74, 25);
            this.butKetthuc.TabIndex = 57;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // c05
            // 
            this.c05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c05.Location = new System.Drawing.Point(276, 154);
            this.c05.Name = "c05";
            this.c05.Size = new System.Drawing.Size(136, 20);
            this.c05.TabIndex = 6;
            this.c05.Text = "Xem trước khi in";
            this.c05.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c10
            // 
            this.c10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c10.Location = new System.Drawing.Point(688, 176);
            this.c10.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.c10.Name = "c10";
            this.c10.Size = new System.Drawing.Size(48, 21);
            this.c10.TabIndex = 19;
            this.c10.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.c10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(736, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "ngày";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(504, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Ngày làm việc so với ngày hệ thống :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c11
            // 
            this.c11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c11.Location = new System.Drawing.Point(19, 85);
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(269, 20);
            this.c11.TabIndex = 21;
            this.c11.Text = "Nhập dược bệnh viện trong khai báo danh mục";
            this.c11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c12
            // 
            this.c12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(19, 103);
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(250, 21);
            this.c12.TabIndex = 22;
            this.c12.Text = "Nhập nhóm kế toán trong khai báo danh mục";
            this.c12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c15
            // 
            this.c15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c15.Location = new System.Drawing.Point(587, 56);
            this.c15.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c15.Name = "c15";
            this.c15.Size = new System.Drawing.Size(171, 21);
            this.c15.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(510, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Kế toán kho :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c16
            // 
            this.c16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c16.Location = new System.Drawing.Point(587, 152);
            this.c16.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c16.Name = "c16";
            this.c16.Size = new System.Drawing.Size(171, 21);
            this.c16.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(510, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Thủ kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c22
            // 
            this.c22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c22.Location = new System.Drawing.Point(688, 200);
            this.c22.Name = "c22";
            this.c22.Size = new System.Drawing.Size(48, 21);
            this.c22.TabIndex = 20;
            this.c22.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.c22.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(736, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 19);
            this.label6.TabIndex = 31;
            this.label6.Text = "ngày";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(502, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "Số ngày hoàn trả so với ngày lãnh là :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c23
            // 
            this.c23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c23.Location = new System.Drawing.Point(19, 66);
            this.c23.Name = "c23";
            this.c23.Size = new System.Drawing.Size(136, 20);
            this.c23.TabIndex = 3;
            this.c23.Text = "Nhập tên hoạt chất";
            this.c23.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c24
            // 
            this.c24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c24.Location = new System.Drawing.Point(19, 225);
            this.c24.Name = "c24";
            this.c24.Size = new System.Drawing.Size(186, 21);
            this.c24.TabIndex = 27;
            this.c24.Text = "Nhập họ tên trong xuất ngoại trú";
            this.c24.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c25
            // 
            this.c25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c25.Location = new System.Drawing.Point(19, 243);
            this.c25.Name = "c25";
            this.c25.Size = new System.Drawing.Size(202, 21);
            this.c25.TabIndex = 28;
            this.c25.Text = "Nhập năm sinh trong xuất ngoại trú";
            this.c25.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c26
            // 
            this.c26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c26.Location = new System.Drawing.Point(176, 36);
            this.c26.Name = "c26";
            this.c26.Size = new System.Drawing.Size(85, 16);
            this.c26.TabIndex = 40;
            this.c26.Text = "Nhập mã số";
            this.c26.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c27
            // 
            this.c27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c27.Location = new System.Drawing.Point(19, 136);
            this.c27.Name = "c27";
            this.c27.Size = new System.Drawing.Size(178, 22);
            this.c27.TabIndex = 23;
            this.c27.Text = "Nhập số thẻ trong bảo hiểm";
            // 
            // c28
            // 
            this.c28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c28.Location = new System.Drawing.Point(276, 99);
            this.c28.Name = "c28";
            this.c28.Size = new System.Drawing.Size(160, 20);
            this.c28.TabIndex = 8;
            this.c28.Text = "Lọc ngày trong phiếu lĩnh";
            this.c28.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c29
            // 
            this.c29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c29.Location = new System.Drawing.Point(276, 117);
            this.c29.Name = "c29";
            this.c29.Size = new System.Drawing.Size(176, 20);
            this.c29.TabIndex = 9;
            this.c29.Text = "Lọc ngày trong phiếu hoàn trả";
            this.c29.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c30
            // 
            this.c30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c30.Location = new System.Drawing.Point(276, 49);
            this.c30.Name = "c30";
            this.c30.Size = new System.Drawing.Size(184, 20);
            this.c30.TabIndex = 10;
            this.c30.Text = "Lọc ngày trong xuất bảo hiểm";
            this.c30.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c31
            // 
            this.c31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c31.Location = new System.Drawing.Point(276, 66);
            this.c31.Name = "c31";
            this.c31.Size = new System.Drawing.Size(176, 20);
            this.c31.TabIndex = 11;
            this.c31.Text = "Lọc ngày trong xuất ngoại trú";
            this.c31.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c32
            // 
            this.c32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c32.Location = new System.Drawing.Point(587, 128);
            this.c32.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c32.Name = "c32";
            this.c32.Size = new System.Drawing.Size(171, 21);
            this.c32.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(483, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 23);
            this.label13.TabIndex = 38;
            this.label13.Text = "Phụ trách  kế toán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butHinh
            // 
            this.butHinh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHinh.Location = new System.Drawing.Point(760, 8);
            this.butHinh.Name = "butHinh";
            this.butHinh.Size = new System.Drawing.Size(22, 21);
            this.butHinh.TabIndex = 35;
            this.butHinh.Text = "...";
            this.butHinh.Click += new System.EventHandler(this.butHinh_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(-21, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 23);
            this.label14.TabIndex = 40;
            this.label14.Text = "Tiêu đề :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(302, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 23);
            this.label15.TabIndex = 41;
            this.label15.Text = "Hình :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 8);
            this.kho.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(251, 21);
            this.kho.TabIndex = 0;
            // 
            // hinh
            // 
            this.hinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hinh.Enabled = false;
            this.hinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hinh.Location = new System.Drawing.Point(342, 8);
            this.hinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hinh.Name = "hinh";
            this.hinh.Size = new System.Drawing.Size(416, 21);
            this.hinh.TabIndex = 1;
            // 
            // c34
            // 
            this.c34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c34.Location = new System.Drawing.Point(19, 155);
            this.c34.Name = "c34";
            this.c34.Size = new System.Drawing.Size(197, 21);
            this.c34.TabIndex = 24;
            this.c34.Text = "Nhập phòng khám trong bảo hiểm";
            this.c34.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c36
            // 
            this.c36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c36.Location = new System.Drawing.Point(19, 173);
            this.c36.Name = "c36";
            this.c36.Size = new System.Drawing.Size(197, 20);
            this.c36.TabIndex = 25;
            this.c36.Text = "Nhập chẩn đoán trong bảo hiểm";
            this.c36.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c35
            // 
            this.c35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c35.Location = new System.Drawing.Point(19, 190);
            this.c35.Name = "c35";
            this.c35.Size = new System.Drawing.Size(166, 21);
            this.c35.TabIndex = 34;
            this.c35.Text = "Nhập bác sĩ trong bảo hiểm";
            this.c35.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c37
            // 
            this.c37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c37.Location = new System.Drawing.Point(276, 83);
            this.c37.Name = "c37";
            this.c37.Size = new System.Drawing.Size(168, 21);
            this.c37.TabIndex = 12;
            this.c37.Text = "Lọc ngày trong xuất tủ trực";
            this.c37.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c38
            // 
            this.c38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c38.Location = new System.Drawing.Point(19, 300);
            this.c38.Name = "c38";
            this.c38.Size = new System.Drawing.Size(198, 21);
            this.c38.TabIndex = 35;
            this.c38.Text = "Nhập khoa/phòng xuất ngoại trú";
            this.c38.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c39
            // 
            this.c39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c39.Location = new System.Drawing.Point(19, 261);
            this.c39.Name = "c39";
            this.c39.Size = new System.Drawing.Size(198, 21);
            this.c39.TabIndex = 36;
            this.c39.Text = "Nhập bác sỹ trong xuất ngoại trú";
            this.c39.CheckedChanged += new System.EventHandler(this.c39_CheckedChanged);
            this.c39.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c40
            // 
            this.c40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c40.Location = new System.Drawing.Point(19, 207);
            this.c40.Name = "c40";
            this.c40.Size = new System.Drawing.Size(234, 21);
            this.c40.TabIndex = 26;
            this.c40.Text = "Nhập mã người bệnh trong xuất ngoại trú";
            // 
            // c41
            // 
            this.c41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c41.Location = new System.Drawing.Point(276, 136);
            this.c41.Name = "c41";
            this.c41.Size = new System.Drawing.Size(200, 20);
            this.c41.TabIndex = 37;
            this.c41.Text = "Lọc theo người dùng trong duyệt";
            this.c41.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(792, 392);
            this.tab.TabIndex = 92;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.c105);
            this.tabPage1.Controls.Add(this.c10);
            this.tabPage1.Controls.Add(this.c22);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.c28);
            this.tabPage1.Controls.Add(this.c45);
            this.tabPage1.Controls.Add(this.c04);
            this.tabPage1.Controls.Add(this.c13);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.c37);
            this.tabPage1.Controls.Add(this.c116);
            this.tabPage1.Controls.Add(this.c106);
            this.tabPage1.Controls.Add(this.c29);
            this.tabPage1.Controls.Add(this.c97);
            this.tabPage1.Controls.Add(this.c96);
            this.tabPage1.Controls.Add(this.c95);
            this.tabPage1.Controls.Add(this.c94);
            this.tabPage1.Controls.Add(this.c70);
            this.tabPage1.Controls.Add(this.c62);
            this.tabPage1.Controls.Add(this.hinh);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.kho);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.butHinh);
            this.tabPage1.Controls.Add(this.c02);
            this.tabPage1.Controls.Add(this.c23);
            this.tabPage1.Controls.Add(this.c05);
            this.tabPage1.Controls.Add(this.c11);
            this.tabPage1.Controls.Add(this.c12);
            this.tabPage1.Controls.Add(this.c30);
            this.tabPage1.Controls.Add(this.c31);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.c07);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.c32);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.c08);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.c09);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.c15);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.c16);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.c26);
            this.tabPage1.Controls.Add(this.c27);
            this.tabPage1.Controls.Add(this.c34);
            this.tabPage1.Controls.Add(this.c36);
            this.tabPage1.Controls.Add(this.c40);
            this.tabPage1.Controls.Add(this.c24);
            this.tabPage1.Controls.Add(this.c25);
            this.tabPage1.Controls.Add(this.c41);
            this.tabPage1.Controls.Add(this.c35);
            this.tabPage1.Controls.Add(this.c38);
            this.tabPage1.Controls.Add(this.c39);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(784, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(736, 224);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 19);
            this.label37.TabIndex = 126;
            this.label37.Text = "ngày";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c105
            // 
            this.c105.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c105.Location = new System.Drawing.Point(688, 224);
            this.c105.Name = "c105";
            this.c105.Size = new System.Drawing.Size(48, 21);
            this.c105.TabIndex = 125;
            this.c105.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(544, 224);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(152, 17);
            this.label36.TabIndex = 124;
            this.label36.Text = "Khoảng cách ngày kiểm kê :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c45
            // 
            this.c45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c45.Location = new System.Drawing.Point(276, 256);
            this.c45.Name = "c45";
            this.c45.Size = new System.Drawing.Size(240, 20);
            this.c45.TabIndex = 123;
            this.c45.Text = "Nhập số lượng qui đổi trong phiếu nhập";
            // 
            // c04
            // 
            this.c04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c04.Location = new System.Drawing.Point(276, 239);
            this.c04.Name = "c04";
            this.c04.Size = new System.Drawing.Size(136, 20);
            this.c04.TabIndex = 122;
            this.c04.Text = "Nhập đơn giá";
            // 
            // c13
            // 
            this.c13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c13.Location = new System.Drawing.Point(276, 32);
            this.c13.Name = "c13";
            this.c13.Size = new System.Drawing.Size(224, 20);
            this.c13.TabIndex = 121;
            this.c13.Text = "Đã khóa số liệu";
            // 
            // c116
            // 
            this.c116.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c116.Location = new System.Drawing.Point(19, 51);
            this.c116.Name = "c116";
            this.c116.Size = new System.Drawing.Size(237, 16);
            this.c116.TabIndex = 120;
            this.c116.Text = "Nhập nhà cung cấp trong danh mục";
            // 
            // c106
            // 
            this.c106.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c106.Location = new System.Drawing.Point(19, 280);
            this.c106.Name = "c106";
            this.c106.Size = new System.Drawing.Size(198, 21);
            this.c106.TabIndex = 119;
            this.c106.Text = "Bắt buộc phải nhập bác sỹ";
            this.c106.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c97
            // 
            this.c97.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c97.Location = new System.Drawing.Point(276, 223);
            this.c97.Name = "c97";
            this.c97.Size = new System.Drawing.Size(232, 21);
            this.c97.TabIndex = 116;
            this.c97.Text = "Nhập định khoản trong phiếu nhập";
            // 
            // c96
            // 
            this.c96.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c96.Location = new System.Drawing.Point(276, 207);
            this.c96.Name = "c96";
            this.c96.Size = new System.Drawing.Size(232, 21);
            this.c96.TabIndex = 115;
            this.c96.Text = "Nhập người giao hàng trong phiếu nhập";
            // 
            // c95
            // 
            this.c95.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c95.Location = new System.Drawing.Point(276, 189);
            this.c95.Name = "c95";
            this.c95.Size = new System.Drawing.Size(232, 21);
            this.c95.TabIndex = 114;
            this.c95.Text = "Nhập biên bản kê trong phiếu nhập";
            // 
            // c94
            // 
            this.c94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c94.Location = new System.Drawing.Point(19, 317);
            this.c94.Name = "c94";
            this.c94.Size = new System.Drawing.Size(229, 21);
            this.c94.TabIndex = 113;
            this.c94.Text = "Nhập chẩn đoán trong xuất ngoại trú";
            this.c94.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c70
            // 
            this.c70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c70.Location = new System.Drawing.Point(276, 171);
            this.c70.Name = "c70";
            this.c70.Size = new System.Drawing.Size(248, 20);
            this.c70.TabIndex = 94;
            this.c70.Text = "Lọc theo người nhập trong phiếu bảo hiểm";
            this.c70.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c62
            // 
            this.c62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c62.Location = new System.Drawing.Point(19, 122);
            this.c62.Name = "c62";
            this.c62.Size = new System.Drawing.Size(216, 16);
            this.c62.TabIndex = 89;
            this.c62.Text = "Nhập mã người bệnh  trong bảo hiểm";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label43);
            this.tabPage3.Controls.Add(this.label42);
            this.tabPage3.Controls.Add(this.c121);
            this.tabPage3.Controls.Add(this.c120);
            this.tabPage3.Controls.Add(this.label41);
            this.tabPage3.Controls.Add(this.c56);
            this.tabPage3.Controls.Add(this.c112);
            this.tabPage3.Controls.Add(this.label40);
            this.tabPage3.Controls.Add(this.c84);
            this.tabPage3.Controls.Add(this.c83);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.dataGrid1);
            this.tabPage3.Controls.Add(this.dataGrid2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(784, 366);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "2";
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(176, 55);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(96, 17);
            this.label43.TabIndex = 137;
            this.label43.Text = "Tự nguyện :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(408, 52);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(32, 23);
            this.label42.TabIndex = 136;
            this.label42.Text = "Vị trí";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c121
            // 
            this.c121.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c121.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c121.Location = new System.Drawing.Point(440, 52);
            this.c121.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c121.Name = "c121";
            this.c121.Size = new System.Drawing.Size(39, 21);
            this.c121.TabIndex = 135;
            this.c121.Text = "5,2";
            this.c121.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c121.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c120
            // 
            this.c120.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c120.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c120.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c120.Location = new System.Drawing.Point(272, 52);
            this.c120.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c120.Name = "c120";
            this.c120.Size = new System.Drawing.Size(112, 21);
            this.c120.TabIndex = 134;
            this.c120.Text = "SS,TT,RR";
            this.c120.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(408, 29);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(32, 23);
            this.label41.TabIndex = 133;
            this.label41.Text = "Vị trí";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c56
            // 
            this.c56.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c56.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c56.Location = new System.Drawing.Point(272, 4);
            this.c56.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c56.Name = "c56";
            this.c56.Size = new System.Drawing.Size(112, 21);
            this.c56.TabIndex = 94;
            this.c56.Text = "report";
            // 
            // c112
            // 
            this.c112.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c112.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c112.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c112.Location = new System.Drawing.Point(440, 4);
            this.c112.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c112.Name = "c112";
            this.c112.Size = new System.Drawing.Size(112, 21);
            this.c112.TabIndex = 102;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(384, 7);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 16);
            this.label40.TabIndex = 101;
            this.label40.Text = "Domain :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c84
            // 
            this.c84.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c84.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c84.Location = new System.Drawing.Point(440, 28);
            this.c84.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c84.Name = "c84";
            this.c84.Size = new System.Drawing.Size(39, 21);
            this.c84.TabIndex = 100;
            this.c84.Text = "3,2";
            this.c84.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c84.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c83
            // 
            this.c83.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c83.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c83.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c83.Location = new System.Drawing.Point(272, 28);
            this.c83.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c83.Name = "c83";
            this.c83.Size = new System.Drawing.Size(112, 21);
            this.c83.TabIndex = 99;
            this.c83.Text = "50";
            this.c83.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(176, 29);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(96, 17);
            this.label33.TabIndex = 98;
            this.label33.Text = "Số thẻ trong tỉnh :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(168, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 17);
            this.label24.TabIndex = 93;
            this.label24.Text = "Thư mục báo cáo :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.CaptionText = "Thứ tự phiếu lĩnh";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(560, 6);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(220, 142);
            this.dataGrid1.TabIndex = 109;
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.CaptionText = "Thứ tự dự trù mua";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(560, 143);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(220, 144);
            this.dataGrid2.TabIndex = 132;
            // 
            // frmThongso
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 463);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo thông số hệ thống";
            this.Load += new System.EventHandler(this.frmThongso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c22)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c105)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmThongso_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            load_tooltip();
			d.ins_thongso(i_nhom,123);
			ds.ReadXml("..\\..\\..\\xml\\d_thongso.xml");
			dstt.ReadXml("..\\..\\..\\xml\\d_sttphieulinh.xml");
			dsmua.ReadXml("..\\..\\..\\xml\\d_sttmua.xml");
			dataGrid1.DataSource=dstt.Tables[0];
			AddGridTableStyle();
			dataGrid1.ReadOnly=false;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 

			dataGrid2.DataSource=dsmua.Tables[0];
			AddGridTableStyle2();
			dataGrid2.ReadOnly=false;
			CurrencyManager cm2 = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid2.DataMember];  
			DataView dv2 = (DataView) cm2.List; 
			dv2.AllowNew = false; 
			foreach(DataRow r in d.get_data("select * from "+user+".d_thongso where nhom="+i_nhom+" order by id").Tables[0].Rows)
			{
				switch (int.Parse(r["id"].ToString()))
				{
					case 2: c02.Checked=(d.Thongso("c02")=="1")?true:false;
						break;
					case 4: c04.Checked=r["ten"].ToString().Trim()=="1";
						break;
					case 5: c05.Checked=(d.Thongso("c05")=="1")?true:false;
						break;
					case 7: c07.Text=r["ten"].ToString();
						break;
					case 8: c08.Text=r["ten"].ToString();
						break;
					case 9: c09.Text=r["ten"].ToString();
						break;
					case 10: c10.Value=decimal.Parse(d.Thongso("c10"));
						break;
					case 11: c11.Checked=(d.Thongso("c11")=="1")?true:false;
						break;
					case 12: c12.Checked=(d.Thongso("c12")=="1")?true:false;
						break;
					case 15: c15.Text=r["ten"].ToString();
						break;
					case 16: c16.Text=r["ten"].ToString();
						break;
					case 22: c22.Value=decimal.Parse(d.Thongso("c22"));
						break;
					case 23: c23.Checked=(d.Thongso("c23")=="1")?true:false;
						break;
					case 24: c24.Checked=(d.Thongso("c24")=="1")?true:false;
						break;
					case 25: c25.Checked=(d.Thongso("c25")=="1")?true:false;
						break;
					case 26: c26.Checked=(d.Thongso("c26")=="1")?true:false;
						break;
					case 27: c27.Checked=(d.Thongso("c27")=="1")?true:false;
						break;
					case 28: c28.Checked=(d.Thongso("c28")=="1")?true:false;
						break;
					case 29: c29.Checked=(d.Thongso("c29")=="1")?true:false;
						break;
					case 30: c30.Checked=(d.Thongso("c30")=="1")?true:false;
						break;
					case 31: c31.Checked=(d.Thongso("c31")=="1")?true:false;
						break;
					case 32: c32.Text=r["ten"].ToString();
						break;
					case 34: c34.Checked=(d.Thongso("c34")=="1")?true:false;
						break;
					case 35: c35.Checked=(d.Thongso("c35")=="1")?true:false;
						break;
					case 36: c36.Checked=(d.Thongso("c36")=="1")?true:false;
						break;
					case 37: c37.Checked=(d.Thongso("c37")=="1")?true:false;
						break;
					case 38: c38.Checked=(d.Thongso("c38")=="1")?true:false;
						break;
					case 39: c39.Checked=(d.Thongso("c39")=="1")?true:false;
						break;
					case 40: c40.Checked=(d.Thongso("c40")=="1")?true:false;
						break;
					case 41: c41.Checked=(d.Thongso("c41")=="1")?true:false;
						break;
					case 45: c45.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 56: c56.Text=r["ten"].ToString();//ten thu muc report
						break;
					case 62: c62.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 70: c70.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 83: c83.Text=r["ten"].ToString();
						break;
					case 84: c84.Text=r["ten"].ToString();
						break;
					case 94: c94.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 95: c95.Checked=d.Thongso("c95")=="1";
						break;
					case 96: c96.Checked=d.Thongso("c96")=="1";
						break;
					case 97: c97.Checked=d.Thongso("c97")=="1";
						break;
					case 105: c105.Value=decimal.Parse(r["ten"].ToString());
						break;
					case 106: c106.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 116: c116.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 120: c120.Text=r["ten"].ToString();
						break;
					case 121: c121.Text=r["ten"].ToString();
						break;
				}
			}
			if (c105.Value==0) c105.Value=7;
			c13.Checked=d.bKhoaso(i_nhom,s_mmyy);
			if (c13.Checked) c13.ForeColor=Color.Red;
    		kho.Text=d.Thongso("kho").Trim();
			hinh.Text=d.Thongso("hinh").Trim();
			butHinh.Enabled=hinh.Text.ToString()=="";
			if (c83.Text=="0") c83.Text="50";
			if (c84.Text=="0") c84.Text="3,2";
            foreach (System.Windows.Forms.Control t in this.tab.Controls)
            {
                foreach (System.Windows.Forms.Control c in t.Controls)
                {
                    try
                    {
                        CheckBox chk = (CheckBox)c;
                        if (chk.Checked) chk.ForeColor = Color.Red;
                    }
                    catch { }
                }
            }
		}

		private void butOK_Click(object sender, System.EventArgs e)
		{
			//if (!c40.Checked) c24.Checked=true;
            int itable = d.tableid("", "d_thongso");
            //foreach (DataRow r in d.get_data("select * from " + user + ".d_thongso where nhom=" + i_nhom + " order by id").Tables[0].Rows)
            //{
            //    d.upd_eve_tables(itable, i_userid, "upd");
            //    d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_thongso", "nhom=" + i_nhom + " and id=" + decimal.Parse(r["id"].ToString())));
            //}
			dstt.WriteXml("..\\..\\..\\xml\\d_sttphieulinh.xml",XmlWriteMode.WriteSchema);
			dsmua.WriteXml("..\\..\\..\\xml\\d_sttmua.xml",XmlWriteMode.WriteSchema);
			d.upd_thongso(i_nhom,4,"don gia",(c04.Checked)?"1":"0");
			d.upd_thongso(i_nhom,45,"qui doi",(c45.Checked)?"1":"0");
			d.upd_thongso(i_nhom,62,"mabn->bhyt",(c62.Checked)?"1":"0");
			d.upd_thongso(i_nhom,70,"bhyt",(c70.Checked)?"1":"0");
			d.upd_thongso(i_nhom,94,"chan doan trong xuat ban",(c94.Checked)?"1":"0");
            foreach (DataRow r in d.get_data("select id from " + user + ".d_dmnhomkho order by id").Tables[0].Rows)
			{
				d.upd_thongso(int.Parse(r["id"].ToString()),105,"ngay kiem ke",c105.Value.ToString());
				d.upd_thongso(int.Parse(r["id"].ToString()),83,"the trong tinh",c83.Text.ToString());
				d.upd_thongso(int.Parse(r["id"].ToString()),84,"vitri the tinh",c84.Text.ToString());
				d.upd_thongso(int.Parse(r["id"].ToString()),120,"tu nguyen",c120.Text.ToString());
				d.upd_thongso(int.Parse(r["id"].ToString()),121,"vitri the tinh",c121.Text.ToString());
			}
			d.upd_thongso(i_nhom,106,"bb bac sy xuat ban",(c106.Checked)?"1":"0");
			d.upd_thongso(i_nhom,112,"domain",c112.Text);
			d.upd_thongso(i_nhom,116,"nha cung cap",(c116.Checked)?"1":"0");
			d.upd_thongso(i_nhom,7,"",c07.Text.Trim());
			d.upd_thongso(i_nhom,8,"",c08.Text.Trim());
			d.upd_thongso(i_nhom,9,"",c09.Text.Trim());
			d.upd_thongso(i_nhom,15,"",c15.Text.Trim());
			d.upd_thongso(i_nhom,16,"",c16.Text.Trim());
			d.upd_thongso(i_nhom,32,"",c32.Text.Trim());
			ds.Tables[0].Rows[0]["c02"]=(c02.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c05"]=(c05.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c10"]=c10.Value.ToString();
			ds.Tables[0].Rows[0]["c11"]=(c11.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c12"]=(c12.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c22"]=c22.Value.ToString();
			ds.Tables[0].Rows[0]["c23"]=(c23.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c24"]=(c24.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c25"]=(c25.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c26"]=(c26.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c27"]=(c27.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c28"]=(c28.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c29"]=(c29.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c30"]=(c30.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c31"]=(c31.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c07"]=c07.Text.Trim();
			ds.Tables[0].Rows[0]["c08"]=c08.Text.Trim();
			ds.Tables[0].Rows[0]["c09"]=c09.Text.Trim();
			ds.Tables[0].Rows[0]["c15"]=c15.Text.Trim();
			ds.Tables[0].Rows[0]["c16"]=c16.Text.Trim();
			ds.Tables[0].Rows[0]["c32"]=c32.Text.Trim();
			ds.Tables[0].Rows[0]["c34"]=(c34.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c35"]=(c35.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c36"]=(c36.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c37"]=(c37.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c38"]=(c38.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c39"]=(c39.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c40"]=(c40.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c41"]=(c41.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c95"]=(c95.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c96"]=(c96.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c97"]=(c97.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["kho"]=kho.Text.Trim();
			ds.Tables[0].Rows[0]["hinh"]=hinh.Text.Trim();
			//binh
			d.upd_thongso(i_nhom,56,"Thu muc report",(c56.Text=="")?"report":c56.Text);//phan biet thuoc noi, ngoai theo hang san xuat
			//
			ds.WriteXml("..\\..\\..\\xml\\d_thongso.xml");
			if (c13.Checked) d.upd_khoaso(i_nhom,s_mmyy,i_userid);
            else if (d.bKhoaso(i_nhom, s_mmyy)) d.execute_data("delete from " + user + ".d_khoaso where nhom=" + i_nhom + " and mmyy='" + s_mmyy + "'");
			butKetthuc.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void c02_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butHinh_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Title = "Chọn hình hệ thống";
			of.Filter = "Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
			of.RestoreDirectory=true;
			of.InitialDirectory = "..\\..\\..\\Picture";
			if (of.ShowDialog() == DialogResult.OK)	 hinh.Text=of.FileName;
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = dstt.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "Thứ tự";
			TextCol1.Width = 40;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Nội dung";
			TextCol1.Width = 145;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return Color.Black;
		}

		private void c39_CheckedChanged(object sender, System.EventArgs e)
		{
			c106.Enabled=c39.Checked;
			if (!c39.Checked) c106.Checked=false;
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
				}
			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void AddGridTableStyle2()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = dsmua.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "Thứ tự";
			TextCol1.Width = 40;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Nội dung";
			TextCol1.Width = 145;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);
		}
        private void load_tooltip()
        {
            ToolTip tip = new ToolTip();
            DataSet dstooltip = new DataSet();
            if (!System.IO.File.Exists(@"..\..\..\xml\tooltip_thongso.xml"))
            {
                dstooltip = m.get_data("select '' control_name,'' text,'' vie,'' eng from dual").Clone();
                dstooltip.WriteXml(@"..\..\..\xml\tooltip_thongso.xml", XmlWriteMode.WriteSchema);
            }
            dstooltip.ReadXml(@"..\..\..\xml\tooltip_thongso.xml", XmlReadMode.ReadSchema);
            foreach (Control c in this.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.Panel":
                    case "System.Windows.Forms.GroupBox":
                        foreach (Control c2 in c.Controls)
                        {
                            DataRow r = m.getrowbyid(dstooltip.Tables[0], "control_name='" + c2.Name + "'");
                            if (r == null)
                            {
                                DataRow nr = dstooltip.Tables[0].NewRow();
                                nr["control_name"] = c2.Name.ToString();
                                nr["text"] = c2.Text.Trim().ToString();
                                dstooltip.Tables[0].Rows.Add(nr);
                            }
                            else
                            {
                                r["text"] = c2.Text.Trim().ToString();
                                if (r["vie"].ToString().Trim() == "") r["vie"] = r["text"].ToString().Trim();
                                string strtip = r["vie"].ToString();
                                if (strtip.Length > 400)
                                {
                                    string[] a = strtip.Split(' ');
                                }
                                tip.SetToolTip(c2, strtip);
                            }
                            dstooltip.AcceptChanges();
                        }
                        break;
                    case "System.Windows.Forms.TabControl":
                        TabControl tabclt = (TabControl)c;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            foreach (Control c3 in tab.Controls)
                            {
                                DataRow r = m.getrowbyid(dstooltip.Tables[0], "control_name='" + c3.Name + "'");
                                if (r == null)
                                {
                                    DataRow nr = dstooltip.Tables[0].NewRow();
                                    nr["control_name"] = c3.Name.ToString();
                                    nr["text"] = c3.Text.Trim().ToString();
                                    dstooltip.Tables[0].Rows.Add(nr);
                                }
                                else
                                {
                                    r["text"] = c3.Text.Trim().ToString();
                                    if (r["vie"].ToString().Trim() == "") r["vie"] = r["text"].ToString().Trim();
                                    tip.SetToolTip(c3, r["vie"].ToString());
                                }
                                dstooltip.AcceptChanges();
                            }
                        }
                        break;
                    default:
                        DataRow r2 = m.getrowbyid(dstooltip.Tables[0], "control_name='" + c.Name + "'");
                        if (r2 == null)
                        {
                            DataRow nr = dstooltip.Tables[0].NewRow();
                            nr["control_name"] = c.Name.ToString();
                            nr["text"] = c.Text.Trim().ToString();
                            dstooltip.Tables[0].Rows.Add(nr);
                        }
                        else
                        {
                            r2["text"] = c.Text.Trim().ToString();
                            if (r2["vie"].ToString().Trim() == "") r2["vie"] = r2["text"].ToString().Trim();
                            tip.SetToolTip(c, r2["vie"].ToString());
                        }
                        break;
                }
                dstooltip.AcceptChanges();
            }
            dstooltip.WriteXml(@"..\..\..\xml\tooltip_thongso.xml", XmlWriteMode.WriteSchema);
        }
	}
}
