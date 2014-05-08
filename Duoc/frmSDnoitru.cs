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
	/// Summary description for rptNxt_tonghop.
	/// </summary>
	public class frmSDnoitru : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom;
		private string sql,s_mmyy,tenfile,s_kho,s_makp,format_soluong,user,stime,xxx, s_gia="";
        private bool bClear = true, bGia = false, bGianovat = false;
		private DataRow r1,r2,r3;
		private DataRow [] dr;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtkp=new System.Data.DataTable();
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkGianovat;
        private System.Windows.Forms.CheckBox chkInkemgia;
        private System.Windows.Forms.CheckBox chkAll;
        private RadioButton rdthang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private RadioButton radioButton1;
        private NumericUpDown tut;
        private NumericUpDown yyyy;
        private NumericUpDown dent;
        private System.Windows.Forms.Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSDnoitru(AccessData acc,int nhom,string mmyy,string _kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;s_kho=_kho;
			i_nhom=nhom;
			s_mmyy=mmyy;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSDnoitru));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            this.chkInkemgia = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.rdthang = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tut = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.dent = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dent)).BeginInit();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(64, 272);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(74, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(138, 272);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(74, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kho :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(50, 82);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(190, 21);
            this.makho.TabIndex = 2;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(50, 106);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(190, 21);
            this.manguon.TabIndex = 3;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(247, 9);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(230, 276);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Enabled = false;
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(160, 58);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Enabled = false;
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(50, 58);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(120, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "đến :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-5, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Từ ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkGianovat
            // 
            this.chkGianovat.AutoSize = true;
            this.chkGianovat.Enabled = false;
            this.chkGianovat.Location = new System.Drawing.Point(50, 149);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(103, 17);
            this.chkGianovat.TabIndex = 14;
            this.chkGianovat.Text = "In giá trước VAT";
            this.chkGianovat.UseVisualStyleBackColor = true;
            // 
            // chkInkemgia
            // 
            this.chkInkemgia.AutoSize = true;
            this.chkInkemgia.Location = new System.Drawing.Point(50, 131);
            this.chkInkemgia.Name = "chkInkemgia";
            this.chkInkemgia.Size = new System.Drawing.Size(97, 17);
            this.chkInkemgia.TabIndex = 16;
            this.chkInkemgia.Text = "In kèm đơn giá";
            this.chkInkemgia.UseVisualStyleBackColor = true;
            this.chkInkemgia.Click += new System.EventHandler(this.chkInkemgia_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(247, 291);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(108, 17);
            this.chkAll.TabIndex = 17;
            this.chkAll.Text = "Chọn tất cả khoa";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // rdthang
            // 
            this.rdthang.AutoSize = true;
            this.rdthang.Checked = true;
            this.rdthang.Location = new System.Drawing.Point(50, 9);
            this.rdthang.Name = "rdthang";
            this.rdthang.Size = new System.Drawing.Size(84, 17);
            this.rdthang.TabIndex = 65;
            this.rdthang.TabStop = true;
            this.rdthang.Text = "Theo Tháng";
            this.rdthang.UseVisualStyleBackColor = true;
            this.rdthang.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-5, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Từ tháng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(153, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 23);
            this.label6.TabIndex = 64;
            this.label6.Text = "năm";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(167, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 66;
            this.radioButton1.Text = "Theo ngày";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tut
            // 
            this.tut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tut.Location = new System.Drawing.Point(50, 34);
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
            this.tut.TabIndex = 60;
            this.tut.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(190, 34);
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
            this.yyyy.TabIndex = 63;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.ValueChanged += new System.EventHandler(this.yyyy_ValueChanged);
            // 
            // dent
            // 
            this.dent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dent.Location = new System.Drawing.Point(121, 34);
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
            this.dent.TabIndex = 61;
            this.dent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dent.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(91, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 23);
            this.label7.TabIndex = 62;
            this.label7.Text = "đến :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSDnoitru
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(484, 309);
            this.Controls.Add(this.tut);
            this.Controls.Add(this.dent);
            this.Controls.Add(this.rdthang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkInkemgia);
            this.Controls.Add(this.chkGianovat);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSDnoitru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo sử dụng nội trú";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSDnoitru_MouseMove);
            this.Load += new System.EventHandler(this.frmSDnoitru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSDnoitru_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			format_soluong=d.format_soluong(i_nhom);
            sql = "select a.*, b.stt as sttnhom, b.ten as tennhom from " + user + ".d_dmbd a, " + user + ".d_dmnhom b";
			sql+=" where a.manhom=b.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];

            sql = "select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString().Trim() + ",%' order by stt";
			dtkp=d.get_data(sql).Tables[0];
			makp.DataSource=dtkp;
            makp.DisplayMember = "TEN";
            makp.ValueMember = "ID";

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where id=0 or nhom="+i_nhom+" order by stt").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtdmkho;
            //
            tut.Value = DateTime.Now.Month;
            dent.Value = DateTime.Now.Month;
            yyyy.Value = DateTime.Now.Year;
            //
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            bGia = chkInkemgia.Checked;
            bGianovat = chkGianovat.Checked;
			get_data();
		}

		private string get_ten(int i)
		{
			string []map={"TT","Tên thuốc - hàm lượng","ĐVT","Tổng số"};
			return map[i];
		}

        private string get_ten_gia(int i)
        {
            string[] map ={ "TT", "Tên thuốc - hàm lượng", "ĐVT", "Đơn giá", "Tổng số" };
            string[] map1 ={ "TT", "Tên thuốc - hàm lượng", "ĐVT", "Đơn giá sau VAT", "Tổng số" };
            return (bGianovat) ? map[i] : map1[1];
        }

		private void exp_excel(bool print)
		{
			d.check_process_Excel();
			ds=dsxml.Copy();
			int dong=2,sodong=ds.Tables[0].Rows.Count+dong,socot=ds.Tables[0].Columns.Count-1,dongke=sodong-1;
			tenfile=d.Export_Excel(ds,"sudung");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;		
			//for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
			osheet.get_Range(d.getIndex(3)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat=format_soluong;
			osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			int pos=5, colfix=4;
            if (bGia) { pos = 6; colfix = 5; }
			foreach(DataRow r in dtmakp.Select("","stt,makp"))
			{
				osheet.Cells[dong-1,pos]=r["tenkp"].ToString();
				pos+=1;
			}
            for (int i = 0; i < colfix; i++)
                osheet.Cells[dong - 1, i + 1] = (bGia) ? get_ten_gia(i) : get_ten(i);
            //
			orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=10;
			orange.EntireColumn.AutoFit();

			oxl.ActiveWindow.DisplayZeros=false;
			osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
			osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
			osheet.PageSetup.CenterFooter="Trang : &P/&N";

//			osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
//			osheet.Cells[1,4]="BÁO CÁO SỬ DỤNG NỘI TRÚ";
//			osheet.Cells[2,4]=s_title;
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			osheet.PageSetup.LeftHeader = d.Syte+"\n"+d.Tenbv;
			osheet.PageSetup.CenterHeader = "&\"Arial,Bold\"&14BÁO CÁO SỬ DỤNG NỘI TRÚ\n"+s_title;
//			orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-1)+"2");
//			orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
//			orange.Font.Size=12;
//			orange.Font.Bold=true;
			if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
			else oxl.Visible=true;
		}

		private void tao_table()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_xuat_ct.xml");
			dc=new DataColumn();
			dc.ColumnName="SOLUONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
           
			sql="select distinct stt,id as makp,ten as tenkp from "+user+".d_duockp where nhom like '%"+i_nhom.ToString().Trim()+",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
			foreach(DataRow r in dtmakp.Select("","makp"))
			{
				dc=new DataColumn();
                dc.ColumnName = "SL_" + r["makp"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
		}

		private void get_sort()
		{
			dsxml=ds.Copy();
			dsxml.Clear();
			int stt=0,tt=1;
			sql="stt,ten";
			DataRow []dr=ds.Tables[0].Select("ma<>''",sql);
			for(int i=0;i<dr.Length;i++)
			{
				if (stt!=int.Parse(dr[i]["stt"].ToString()))
				{
					stt=int.Parse(dr[i]["stt"].ToString());
					r2 = dsxml.Tables[0].NewRow();
					r2["stt"]=0;
					r2["ten"]=dr[i]["tennhom"].ToString().ToUpper();
					r2["dang"]="";
                    foreach (DataRow r5 in dtmakp.Select("", "stt,makp"))
                    { if(r5["makp"].ToString()!="")r2["sl_" + r5["makp"].ToString().Trim()] = 0; }
					r2["soluong"]=0;
					dsxml.Tables[0].Rows.Add(r2);
				}
				r2 = dsxml.Tables[0].NewRow();
				r2["manhom"]=dr[i]["manhom"].ToString();
				r2["tennhom"]=dr[i]["tennhom"].ToString();
				r2["mabd"]=dr[i]["mabd"].ToString();
				r2["ma"]=dr[i]["ma"].ToString();
				r2["ten"]=dr[i]["ten"].ToString();
				r2["tenhc"]=dr[i]["tenhc"].ToString();
				r2["dang"]=dr[i]["dang"].ToString();
				r2["stt"]=tt;
                foreach (DataRow r5 in dtmakp.Select("", "stt,makp"))
                { if (r5["makp"].ToString() != "")r2["sl_" + r5["makp"].ToString().Trim()] = dr[i]["sl_" + r5["makp"].ToString().Trim()].ToString(); }
				r2["soluong"]=dr[i]["soluong"].ToString();
                r2["dongia"] = dr[i]["dongia"].ToString();
				dsxml.Tables[0].Rows.Add(r2);
				tt++;
			}
			dsxml.Tables[0].Columns.Remove("manhom");
			dsxml.Tables[0].Columns.Remove("mabd");
			dsxml.Tables[0].Columns.Remove("ma");
			dsxml.Tables[0].Columns.Remove("tenhc");
			dsxml.Tables[0].Columns.Remove("manguon");
			dsxml.Tables[0].Columns.Remove("tennhom");
			dsxml.Tables[0].Columns.Remove("noingoai");
			dsxml.Tables[0].Columns.Remove("idnn");
			if(chkInkemgia.Checked==false) dsxml.Tables[0].Columns.Remove("dongia");
            try
            {
                dsxml.Tables[0].Columns.Remove("tennhom");
            }
            catch { }
            try
            {
                dsxml.Tables[0].Columns.Remove("losx");
            }
            catch { }
            try
            {
                dsxml.Tables[0].Columns.Remove("handung");
            }
            catch { }
            try
            {
                dsxml.Tables[0].Columns.Remove("hangsx");
            }
            catch { }
            try
            {
                dsxml.Tables[0].Columns.Remove("nuocsx");
            }
            catch { }
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
            d.writeXml("d_thongso", "sudung", s_makp);            
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void get_data()
		{
			s_makp="";
			for(int i=0;i<makp.Items.Count;i++)                
				if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["id"].ToString().Trim()+",";
			d.writeXml("d_thongso","sudung",s_makp);
			tao_table();
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
            if (rdthang.Checked)
            {
                y1 = y2 = int.Parse(yyyy.Value.ToString());
                m1 = int.Parse(tut.Value.ToString());
                m2 = int.Parse(dent.Value.ToString());
            }
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					s_mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(s_mmyy)) items_xuat();
				}
			}
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
			exp_excel(false);
		}

		private void items_xuat()
		{
            string sexp = "";
            string s_dk = " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (rdthang.Checked) s_dk = "";
			foreach(DataRow r in get_xuat(s_dk,s_mmyy).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
                    sexp = "id=" + int.Parse(r["mabd"].ToString());
                    if (bGia) sexp += " and dongia=" + Math.Round(decimal.Parse(r["dongia"].ToString()), 3);
					r2=d.getrowbyid(dt,sexp);
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["manhom"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
                        foreach (DataRow r5 in dtmakp.Select("", "stt,makp"))
                        { if (r5["makp"].ToString() != "")r3["sl_" + r5["makp"].ToString().Trim()] = 0; }
						r3["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(r["soluong"].ToString());
						r3["soluong"]=decimal.Parse(r["soluong"].ToString());
                        r3["dongia"] = Math.Round(decimal.Parse(r["dongia"].ToString()), 3);
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0)
					{
						dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					}
				}
			}
		}

		private DataSet get_xuat(string cont, string mmyy)
		{
            xxx = user + mmyy;
			sql=" select a.makp as makp,b.mabd,sum(b.soluong) as soluong ";
            if (bGia && bGianovat) sql += ", t.gianovat as dongia ";
            else if (bGia && bGianovat == false) sql += ", t.giamua as dongia ";
            else sql += " , 0 as dongia ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi t";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai<>3 ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=cont;
			sql+=" group by a.makp,b.mabd";
            if (bGia && bGianovat) sql += ", t.gianovat ";
            else if (bGia && bGianovat == false) sql += ", t.giamua ";
			sql+=" union all ";
			sql+=" select a.makp as makp,b.mabd,-sum(b.soluong) as soluong ";
            if (bGia && bGianovat) sql += ", t.gianovat as dongia ";
            else if (bGia && bGianovat == false) sql += ", t.giamua as dongia ";
            else sql += " , 0 as dongia ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi t";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=3 ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=cont;
			sql+=" group by a.makp,b.mabd";
            if (bGia && bGianovat) sql += ", t.gianovat ";
            else if (bGia && bGianovat == false) sql += ", t.giamua ";
			return d.get_data(sql);
		}

		private void frmSDnoitru_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				s_makp=d.Thongso("d_thongso","sudung").Trim();
				for(int i=0;i<makp.Items.Count;i++)
					if (s_makp.IndexOf(dtkp.Rows[i]["id"].ToString().Trim()+",")!=-1) makp.SetItemCheckState(i,CheckState.Checked);
					else makp.SetItemCheckState(i,CheckState.Unchecked);
				bClear=false;
			}
		}

        private void chkInkemgia_Click(object sender, EventArgs e)
        {
            chkGianovat.Enabled = chkInkemgia.Checked;
            if (chkInkemgia.Checked == false) chkGianovat.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Enable_ngay(rdthang.Checked);
        }
        private void Enable_ngay(bool ena)
        {
            //ngay
            tu.Enabled = !ena;
            den.Enabled = !ena;
            
            //thang
            tut.Enabled = ena;
            dent.Enabled = ena;
            yyyy.Enabled = ena;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void yyyy_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkAll.Text = "Bỏ chọn tất cả";
                for (int i = 0; i < makp.Items.Count; i++) makp.SetItemCheckState(i, CheckState.Checked);
            }
            else
            {
                chkAll.Text = "Chọn tất cả khoa";
                for (int i = 0; i < makp.Items.Count; i++) makp.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
	}
}
