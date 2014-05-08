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
	public class rptNXTChitiet_ck : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom,i_dongia;
		private string sql,s_mmyy,tenfile,s_kho,format_soluong,user,xxx;
		private DataRow r1,r2,r3;
		private DataRow [] dr;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox makho;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox chkGianovat;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptNXTChitiet_ck(AccessData acc,int nhom,string mmyy,string _kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;s_kho=_kho;
			i_nhom=nhom;
			tu.Value=decimal.Parse(mmyy.Substring(0,2));
			den.Value=tu.Value;
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptNXTChitiet_ck));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(104, 194);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 9;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(174, 194);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 33);
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
            this.manguon.Location = new System.Drawing.Point(80, 31);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(200, 21);
            this.manguon.TabIndex = 7;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(120, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(152, 7);
            this.den.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.den.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(40, 21);
            this.den.TabIndex = 3;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(232, 7);
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
            this.yyyy.TabIndex = 5;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(80, 7);
            this.tu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(40, 21);
            this.tu.TabIndex = 1;
            this.tu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(192, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(80, 54);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(200, 100);
            this.makho.TabIndex = 8;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(313, 263);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkGianovat);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.makho);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.den);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.yyyy);
            this.tabPage1.Controls.Add(this.manguon);
            this.tabPage1.Controls.Add(this.tu);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(305, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nhập.Xuất.Tồn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkGianovat
            // 
            this.chkGianovat.AutoSize = true;
            this.chkGianovat.Location = new System.Drawing.Point(84, 160);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(127, 17);
            this.chkGianovat.TabIndex = 11;
            this.chkGianovat.Text = "In theo giá trước VAT";
            this.chkGianovat.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(305, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hướng dẫn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(299, 231);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // rptNXTChitiet_ck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(313, 263);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptNXTChitiet_ck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo nhập xuất tồn chi tiết các kho";
            this.Load += new System.EventHandler(this.rptNXTChitiet_ck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptNXTChitiet_ck_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			i_dongia=d.d_dongia_le(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
            sql = "select a.*, b.stt as sttnhom, b.ten as tennhom from " + user + ".d_dmbd a, " + user + ".d_dmnhom b";
			sql+=" where a.manhom=b.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtdmkho;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			get_data();
		}

		private string get_ten(int i)
		{
            string[] map ={ "TT", "Tên thuốc - hàm lượng", "ĐVT", "Đơn giá", "SL", "ST", "SL", "ST", "SL", "ST" };
			return map[i];
		}

		private void exp_excel(bool print)
		{
			d.check_process_Excel();
			ds=dsxml.Copy();
			int dong=3,sodong=ds.Tables[0].Rows.Count+dong,socot=ds.Tables[0].Columns.Count-1,dongke=sodong+1;
			tenfile=d.Export_Excel(ds,"BAOCAONXT");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			
			for(int i=0;i<2;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
			osheet.get_Range(d.getIndex(3)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat=format_soluong;
			osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			int pos=11;
			int row=dong-1;
			foreach(DataRow r in dtdmkho.Rows)
			{
				osheet.Cells[row,pos]=r["ten"].ToString();
				osheet.get_Range(d.getIndex(pos-1)+row.ToString(),d.getIndex(pos)+row.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				pos+=2;
			}
			for(int i=0;i<10;i++)
			{
				osheet.Cells[dong,i+1]=get_ten(i);
				if (i<4) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+dong.ToString()).MergeCells=true;
				//else osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"2").MergeCells=true;
			}
			for(int i=8;i<ds.Tables[0].Columns.Count;i++) osheet.Cells[dong,i+1]=get_ten((i%2==0)?4:5);
			osheet.Cells[dong-1,5]="Tồn đầu";
			osheet.Cells[dong-1,7]="Nhập";
			osheet.Cells[dong-1,9]="Nhập khác";
            osheet.Cells[dong - 2, 11] = "Xuất";
			osheet.Cells[dong-1,11+dtdmkho.Rows.Count*2]="Tồn cuối";
			osheet.get_Range(d.getIndex(10)+"1",d.getIndex(ds.Tables[0].Columns.Count-3)+"1").HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			orange=osheet.get_Range(d.getIndex(4)+"1",d.getIndex(5)+"2");
			orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
			orange.VerticalAlignment = XlVAlign.xlVAlignCenter;
			orange.MergeCells = true;
			orange=osheet.get_Range(d.getIndex(6)+"1",d.getIndex(7)+"2");
			orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
			orange.VerticalAlignment = XlVAlign.xlVAlignCenter;
			orange.MergeCells = true;
            orange = osheet.get_Range(d.getIndex(8) + "1", d.getIndex(9) + "2");
            orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
            orange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            orange.MergeCells = true;
			orange=osheet.get_Range(d.getIndex(socot-1)+"1",d.getIndex(socot)+"2");
			orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
			orange.VerticalAlignment = XlVAlign.xlVAlignCenter;
			orange.MergeCells = true;

			orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=10;
			orange.EntireColumn.AutoFit();

			oxl.ActiveWindow.DisplayZeros=false;
			osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
			osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
			osheet.PageSetup.CenterFooter="Trang : &P/&N";
			string s_title="Từ tháng "+tu.Value.ToString().PadLeft(2,'0')+" đến "+den.Value.ToString().PadLeft(2,'0');
			if(tu.Text==den.Text)s_title="Tháng "+tu.Value.ToString().PadLeft(2,'0');
			s_title+=" Năm "+yyyy.Value.ToString();
			osheet.PageSetup.LeftHeader = d.Syte+"\n"+d.Tenbv;
			osheet.PageSetup.CenterHeader = "&\"Arial,Bold\"&14BÁO CÁO NHẬP XUẤT TỒN\n"+s_title;
			if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
			else oxl.Visible=true;
		}

		private void tao_table()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_xuat_ct.xml");
			dc=new DataColumn();
			dc.ColumnName="tondau";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="sttondau";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="slnhap";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="stnhap";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
            //
            dc = new DataColumn();
            dc.ColumnName = "slnhap_k";
            dc.DataType = Type.GetType("System.Decimal");
            dc.DefaultValue = 0;
            ds.Tables[0].Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "stnhap_k";
            dc.DataType = Type.GetType("System.Decimal");
            dc.DefaultValue = 0;
            ds.Tables[0].Columns.Add(dc);
            //
			foreach(DataRow r in dtdmkho.Rows)
			{
				dc=new DataColumn();
				dc.ColumnName="sl_"+r["id"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
                dc.DefaultValue = 0;
				dc=new DataColumn();
				dc.ColumnName="st_"+r["id"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
                dc.DefaultValue = 0;
				ds.Tables[0].Columns.Add(dc);
			}
			dc=new DataColumn();
			dc.ColumnName="toncuoi";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
            dc.DefaultValue = 0;
			dc=new DataColumn();
			dc.ColumnName="sttoncuoi";
			dc.DataType=Type.GetType("System.Decimal");
            dc.DefaultValue = 0;
			ds.Tables[0].Columns.Add(dc);
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
					r2["dongia"]=0;
					foreach(DataRow r5 in dtdmkho.Rows)
					{
						r2["sl_"+r5["id"].ToString().Trim()]=0;
						r2["st_"+r5["id"].ToString().Trim()]=0;
					}
					r2["tondau"]=0;
					r2["sttondau"]=0;
					r2["slnhap"]=0;
					r2["stnhap"]=0;
                    r2["slnhap_k"] = 0;
                    r2["stnhap_k"] = 0;
					r2["toncuoi"]=0;
					r2["sttoncuoi"]=0;
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
				r2["dongia"]=dr[i]["dongia"].ToString();
				r2["tondau"]=dr[i]["tondau"].ToString();
				r2["sttondau"]=dr[i]["sttondau"].ToString();
				r2["slnhap"]=dr[i]["slnhap"].ToString();
				r2["stnhap"]=dr[i]["stnhap"].ToString();
                r2["slnhap_k"] = dr[i]["slnhap_k"].ToString();
                r2["stnhap_k"] = dr[i]["stnhap_k"].ToString();
                r2["toncuoi"] = decimal.Parse(dr[i]["tondau"].ToString()) + decimal.Parse(dr[i]["slnhap"].ToString()) +decimal.Parse(dr[i]["slnhap_k"].ToString());
                r2["sttoncuoi"] = decimal.Parse(dr[i]["sttondau"].ToString()) + decimal.Parse(dr[i]["stnhap"].ToString()) + decimal.Parse(dr[i]["stnhap_k"].ToString());
				r2["stt"]=tt;
				foreach(DataRow r5 in dtdmkho.Rows)
				{
					r2["sl_"+r5["id"].ToString().Trim()]=dr[i]["sl_"+r5["id"].ToString().Trim()].ToString();
					r2["st_"+r5["id"].ToString().Trim()]=dr[i]["st_"+r5["id"].ToString().Trim()].ToString();
					r2["toncuoi"]=decimal.Parse(r2["toncuoi"].ToString())-decimal.Parse(dr[i]["sl_"+r5["id"].ToString().Trim()].ToString());
					r2["sttoncuoi"]=decimal.Parse(r2["sttoncuoi"].ToString())-decimal.Parse(dr[i]["st_"+r5["id"].ToString().Trim()].ToString());

				}
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
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void get_data()
		{
			s_kho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString().Trim()+",";
			tao_table();
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			if (d.bMmyy(s_mmyy)) items_tondau(s_mmyy);
			int itu=Convert.ToInt16(tu.Value),iden=Convert.ToInt16(den.Value);
			for(int i=itu;i<=iden;i++)
			{
				s_mmyy=i.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
				if (d.bMmyy(s_mmyy))
				{
					items_nhap(s_mmyy);
					items_xuat(s_mmyy);
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

		private void items(string f1,string f2)
		{
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				sql="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["giamua"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["manhom"]=r2["manhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["dongia"]=r["giamua"].ToString();
						r3["tondau"]=0;
						r3["sttondau"]=0;
						r3["slnhap"]=0;
						r3["stnhap"]=0;
                        r3["slnhap_k"] = 0;
                        r3["stnhap_k"] = 0;
						r3["toncuoi"]=0;
						r3["sttoncuoi"]=0;
						foreach(DataRow r5 in dtdmkho.Rows)	
						{
							r3["sl_"+r5["id"].ToString().Trim()]=0;
							r3["st_"+r5["id"].ToString().Trim()]=0;
						}
						if (f1=="" && f2=="")
						{
							r3["sl_"+r["makho"].ToString().Trim()]=r["soluong"].ToString();
							r3["st_"+r["makho"].ToString().Trim()]=r["sotien"].ToString();
						}
						else
						{
							r3[f1]=r["soluong"].ToString();
							r3[f2]=r["sotien"].ToString();
						}
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0) 
					{
						if (f1=="" && f2=="")
						{
							dr[0]["sl_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makho"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
							dr[0]["st_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["st_"+r["makho"].ToString().Trim()].ToString())+decimal.Parse(r["sotien"].ToString());
						}
						else
						{
							dr[0][f1]=decimal.Parse(dr[0][f1].ToString())+decimal.Parse(r["soluong"].ToString());
							dr[0][f2]=decimal.Parse(dr[0][f2].ToString())+decimal.Parse(r["sotien"].ToString());
						}
					}
				}
			}
		}
		private void items_tondau(string mmyy)
		{
            xxx = user + mmyy;
            string s_gia = (chkGianovat.Checked) ? "b.gianovat" : "b.giamua";
            sql = "select a.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(a.tondau) as soluong,sum(a.tondau*" + s_gia + ") as sotien ";
			sql+=" from "+xxx+".d_tonkhoct a,"+xxx+".d_theodoi b,"+user+".d_dmkho c where a.stt=b.id and a.makho=c.id and c.nhom="+i_nhom;
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
            sql += " group by a.mabd,trunc(" + s_gia + "," + i_dongia + ")";            
			items("tondau","sttondau");
		}

		private void items_xuat(string mmyy)
		{
            xxx = user + mmyy;
            string s_gia = (chkGianovat.Checked) ? "c.gianovat" : "c.giamua";
            sql = "select b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in (1,4)";
			sql+=" and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
            sql += " group by b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
            sql += " union all ";
            sql += "select b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in (2)";
            sql += " and a.nhom=" + i_nhom;
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (manguon.SelectedIndex != -1) sql += " and c.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " group by b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
            sql += " union all ";
            //tra: chuyen qua nhap_k
            //sql += "select b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,-sum(b.soluong) as soluong,-sum(b.soluong*" + s_gia + ") as sotien ";
            //sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in (3)";
            //sql+=" and a.nhom="+i_nhom;
            //if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
            //if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
            //sql += " group by b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
            //sql+=" union all ";
            sql += "select a.khox as makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in('XK','BS')";
            sql += " and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
            sql += " group by a.khox,b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
            sql += " union all ";
            sql += "select a.khox as makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai='CK'";
            sql += " and a.nhom=" + i_nhom;
            if (s_kho != "") sql += " and a.khox in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_kho != "") sql += " and a.khon not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (manguon.SelectedIndex != -1) sql += " and c.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " group by a.khox,b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
            sql += " union all ";          
            sql += "select b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id";
			sql+=" and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
            sql += " group by b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
            sql += " union all ";
            sql += "select b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id";
			sql+=" and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
            sql += " group by b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
			items("","");			
		}

		private void items_nhap(string mmyy)
		{
            xxx = user + mmyy;
            string s_gia = (chkGianovat.Checked) ? "b.dongia" : "b.giamua";
            string s_sotien = (chkGianovat.Checked) ? "0" : "b.sotien*b.vat/100";
            sql = "select b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.sotien+" + s_sotien + "+b.cuocvc+b.chaythu) as sotien";
            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b where a.id=b.id and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and a.manguon="+int.Parse(manguon.SelectedValue.ToString());
            sql += " and a.loai='M' ";//mua moi
            sql += " group by b.mabd,trunc(" + s_gia + "," + i_dongia + ")";
			items("slnhap","stnhap");

            //
            sql = "select b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.sotien+" + s_sotien + "+b.cuocvc+b.chaythu) as sotien";
            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b where a.id=b.id and a.nhom=" + i_nhom;
            if (s_kho != "") sql += " and a.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (manguon.SelectedIndex != -1) sql += " and a.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and a.loai<>'M' ";//tai nhap, tra
            sql += " group by b.mabd,trunc(" + s_gia + "," + i_dongia + ")";
            items("slnhap_k", "stnhap_k");
            //
            s_gia = (chkGianovat.Checked) ? "c.gianovat" : "c.giamua";
            sql = "select b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai='CK'";
            sql += " and a.nhom=" + i_nhom;
            if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_kho != "") sql += " and a.khox not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (manguon.SelectedIndex != -1) sql += " and c.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " group by b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
            items("slnhap_k", "stnhap_k");

            sql = " select b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in('HT','TH')";
            sql += " and a.nhom=" + i_nhom;
            if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (manguon.SelectedIndex != -1) sql += " and c.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " group by b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";
            sql += " union all ";
            sql += "select b.mabd,trunc(" + s_gia + "," + i_dongia + ") as giamua,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in (3)";
            sql += " and a.nhom=" + i_nhom;
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (manguon.SelectedIndex != -1) sql += " and c.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " group by b.makho,b.mabd,trunc(" + s_gia + "," + i_dongia + ") ";

            items("slnhap_k", "stnhap_k");
		}
	}
}
