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
	public class rptXuat_CT : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom,i_tt;
		private bool bClear=true;
		private string user,xxx,sql,s_mmyy,s_tu,s_den,s_yy,s_kho,tenfile,s_manhom,tenreport,exp,s_makp;
		private DataRow r1,r2,r3,r4;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private DataSet dsts=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.Label label3;
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Data.DataTable dtdmnhom=new System.Data.DataTable();
		private System.Data.DataTable dtkp=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtnhomkp=new System.Data.DataTable();
		private System.Data.DataTable dtmadt=new System.Data.DataTable();
		private System.Data.DataTable dtthuythem=new System.Data.DataTable();
		private System.Windows.Forms.CheckedListBox manhom;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox tt;
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckBox cstt;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkMadt;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkgianovat;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptXuat_CT(AccessData acc,int nhom,string kho,string mmyy,string file)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
			tenfile=file;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptXuat_CT));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.cstt = new System.Windows.Forms.CheckBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkMadt = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkgianovat = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(172, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(254, 212);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 18;
            this.butIn.Text = "       &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(323, 212);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 19;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(71, 27);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(184, 21);
            this.manguon.TabIndex = 7;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nguồn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(71, 4);
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
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(207, 4);
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
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(143, 4);
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(111, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(444, 4);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(200, 196);
            this.manhom.TabIndex = 17;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(2, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Kho ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(71, 75);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(184, 100);
            this.kho.TabIndex = 13;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Thứ tự :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tt
            // 
            this.tt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tt.Items.AddRange(new object[] {
            "Nội ngoại,nhóm",
            "Kho,nhóm kế toán"});
            this.tt.Location = new System.Drawing.Point(71, 178);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(184, 21);
            this.tt.TabIndex = 15;
            this.tt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(257, 4);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(184, 196);
            this.makp.TabIndex = 16;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // cstt
            // 
            this.cstt.Checked = true;
            this.cstt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cstt.Location = new System.Drawing.Point(444, 206);
            this.cstt.Name = "cstt";
            this.cstt.Size = new System.Drawing.Size(160, 24);
            this.cstt.TabIndex = 18;
            this.cstt.Text = "Số liệu xuất theo tủ trực";
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Items.AddRange(new object[] {
            "Nội ngoại,nhóm",
            "Kho,nhóm kế toán"});
            this.madoituong.Location = new System.Drawing.Point(71, 51);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(184, 21);
            this.madoituong.TabIndex = 11;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(10, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Đối tượng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkMadt
            // 
            this.chkMadt.Location = new System.Drawing.Point(444, 227);
            this.chkMadt.Name = "chkMadt";
            this.chkMadt.Size = new System.Drawing.Size(160, 24);
            this.chkMadt.TabIndex = 20;
            this.chkMadt.Text = "Chi tiết theo đối tượng";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(662, 295);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.den);
            this.tabPage1.Controls.Add(this.chkgianovat);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.manguon);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chkMadt);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.madoituong);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cstt);
            this.tabPage1.Controls.Add(this.tu);
            this.tabPage1.Controls.Add(this.makp);
            this.tabPage1.Controls.Add(this.yyyy);
            this.tabPage1.Controls.Add(this.tt);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.kho);
            this.tabPage1.Controls.Add(this.manhom);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(654, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xuất kho";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkgianovat
            // 
            this.chkgianovat.Location = new System.Drawing.Point(71, 202);
            this.chkgianovat.Name = "chkgianovat";
            this.chkgianovat.Size = new System.Drawing.Size(160, 24);
            this.chkgianovat.TabIndex = 21;
            this.chkgianovat.Text = "In theo giá trước VAT";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(654, 269);
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
            this.richTextBox1.Size = new System.Drawing.Size(648, 263);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // rptXuat_CT
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(662, 295);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptXuat_CT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất (chi tiết)";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptXuat_CT_MouseMove);
            this.Load += new System.EventHandler(this.rptXuat_CT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptXuat_CT_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			dc=new DataColumn();
			dc.ColumnName="makp";
			dc.DataType=Type.GetType("System.String");
			dtmakp.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="tenkp";
			dc.DataType=Type.GetType("System.String");
			dtmakp.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="stt";
			dc.DataType=Type.GetType("System.Decimal");
			dtmakp.Columns.Add(dc);

			if (tt.Items.Count>0) tt.SelectedIndex=0;
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";

			sql="select * from "+user+".d_duockp where nhom like '%"+i_nhom.ToString()+",%'";
			sql+=" order by stt";
			dtkp=d.get_data(sql).Tables[0];
            makp.DataSource = dtkp;
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			
			dtmadt=d.get_data("select * from "+user+".d_doituong order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtmadt;

			dtnhomkp=d.get_data("select * from "+user+".d_nhomkhoa order by stt").Tables[0];
			dtdmnhom=d.get_data("select * from "+user+".d_dmnhom where stt<>0 and nhom="+i_nhom+" order by stt").Tables[0];
            manhom.DataSource = dtdmnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";
			

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where id=0 or nhom="+i_nhom+" order by stt").Tables[0];
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			i_tt=tt.SelectedIndex;
			if (i_tt==0)
			{
                sql = "select a.*, b.stt as tt, b.ten as tennhom, a.maloai as idnn, f.ten as noingoai,g.ten as tenvp ";
                sql += " from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_dmloai f," + user + ".v_nhomvp g";
				sql+=" where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and b.nhomvp=g.ma and a.nhom="+i_nhom+" order by a.id";
			}
			else 
			{
				sql="select a.*, b.stt as tt, b.ten as tennhom,g.ten as tenvp";
                sql += " from " + user + ".d_dmbd a," + user + ".d_dmnhomkt b,"+user+".d_dmnhom e,"+user+".v_nhomvp g ";
                sql+=" where a.sotk=b.id and a.manhom=e.id and e.nhomvp=g.id and a.nhom=" + i_nhom + " order by a.id";
			}
			dt=d.get_data(sql).Tables[0];
            if (!get_data()) return;
			if (chkMadt.Checked) exp_excel_madt(false);
			else exp_excel(false);
		}

		private string get_ten(int i)
		{
			string []map={"TT","Tên thuốc - hàm lượng","ĐVT","Đơn gía","SL","TT","BHYT","NGOẠI TRÚ","KHÁC"};
			return map[i];
		}

		private void exp_excel_madt(bool print)
		{
			d.check_process_Excel();
			ds=dsxml.Copy();
            ds.Tables[0].Columns.Remove("losx");
            ds.Tables[0].Columns.Remove("handung");
            ds.Tables[0].Columns.Remove("hangsx");
            ds.Tables[0].Columns.Remove("nuocsx");
			int be=4,dong=6,sodong=ds.Tables[0].Rows.Count+dong,socot=ds.Tables[0].Columns.Count-1,dongke=sodong-1;
			tenfile=d.Export_Excel(ds,"xuat_ct");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;

            

			for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
			osheet.get_Range(d.getIndex(be-1)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat="#,##0.00";

            if (d.Mabv == "205.2.01")
            {
                osheet.get_Range(d.getIndex(0)+"4",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
            }
            else
            {
                osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;

            }
            int pos = 5, row = dong - 2, p = 5, row1 = row;
			foreach(DataRow r in dtmadt.Select("true","madoituong"))
			{
				osheet.Cells[row1,pos]=r["doituong"].ToString();
				osheet.get_Range(d.getIndex(p-1)+row1.ToString(),d.getIndex(pos-1)+row1.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				p=pos;
				osheet.get_Range(d.getIndex(pos-1)+row.ToString(),d.getIndex(pos)+row.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				pos+=2;
			}
//			osheet.get_Range(d.getIndex(p-1)+row1.ToString(),d.getIndex(pos-1)+row1.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			osheet.Cells[dong-2,pos]="Tổng cộng";
			osheet.get_Range(d.getIndex(pos-1)+row.ToString(),d.getIndex(pos)+row.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
//			osheet.Cells[row1,pos]=" ";
//			osheet.get_Range(d.getIndex(pos-1)+row1.ToString(),d.getIndex(pos)+row1.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			for(int i=0;i<4;i++)
			{
				osheet.Cells[dong-1,i+1]=get_ten(i);
				orange=osheet.get_Range(d.getIndex(i)+"4",d.getIndex(i)+"5");
				orange.VerticalAlignment=XlVAlign.xlVAlignCenter;
				orange.MergeCells=true;
			}
			for(int i=4;i<=socot;i++) osheet.Cells[dong-1,i+1]=get_ten((i%2==0)?4:5);
			orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=8;
			orange.EntireColumn.AutoFit();

			oxl.ActiveWindow.DisplayZeros=false;
			osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			osheet.Cells[1,4]="BÁO CÁO XUẤT KHO";
			string s_title=d.title(tu.Value.ToString(),den.Value.ToString())+" năm "+yyyy.Value.ToString();
			osheet.Cells[2,4]=s_title;
			orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-1)+"2");
			orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			orange.Font.Size=12;
			orange.Font.Bold=true;
			if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
			else oxl.Visible=true;
		}

		private void exp_excel(bool print)
		{
			d.check_process_Excel();
            ds = dsxml.Copy();
            ds.Tables[0].Columns.Remove("losx");
            ds.Tables[0].Columns.Remove("handung");
            ds.Tables[0].Columns.Remove("hangsx");
            ds.Tables[0].Columns.Remove("nuocsx");
			int be=4,dong=6,sodong=ds.Tables[0].Rows.Count+dong,socot=ds.Tables[0].Columns.Count-1,dongke=sodong-1;
			tenfile=d.Export_Excel(ds,"xuat_ct");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			
			for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
			osheet.get_Range(d.getIndex(be-1)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat="#,##0.00";
			osheet.get_Range(d.getIndex(0)+"3",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			string kh="BHY,NTR,KHA",ten="";
			int pos=5,row=dong-2,stt=0,p=5,row1=row-1;
			foreach(DataRow r in dtmakp.Select("makp<>''","stt,makp"))
			{
				if (stt!=int.Parse(r["stt"].ToString()))
				{
					stt=int.Parse(r["stt"].ToString());
					osheet.Cells[row1,pos]=r["tenkp"].ToString();
					osheet.get_Range(d.getIndex(p-1)+row1.ToString(),d.getIndex(pos-1)+row1.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
					p=pos;
				}
				if (kh.IndexOf(r["makp"].ToString())!=-1)
					ten=(r["makp"].ToString()=="BHY")?get_ten(6):(r["makp"].ToString()=="NTR")?get_ten(7):get_ten(8);
				else
				{
					r1=d.getrowbyid(dtkp,"id="+int.Parse(r["makp"].ToString()));
					if (r1!=null) ten=r1["ten"].ToString();
				}
				osheet.Cells[row,pos]=ten;
				osheet.get_Range(d.getIndex(pos-1)+row.ToString(),d.getIndex(pos)+row.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				pos+=2;
			}
			osheet.get_Range(d.getIndex(p-1)+row1.ToString(),d.getIndex(pos-1)+row1.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			osheet.Cells[dong-2,pos]="Tổng cộng";
			osheet.get_Range(d.getIndex(pos-1)+row.ToString(),d.getIndex(pos)+row.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			osheet.Cells[row1,pos]=" ";
			osheet.get_Range(d.getIndex(pos-1)+row1.ToString(),d.getIndex(pos)+row1.ToString()).HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			for(int i=0;i<4;i++)
			{
				osheet.Cells[dong-1,i+1]=get_ten(i);
				orange=osheet.get_Range(d.getIndex(i)+"3",d.getIndex(i)+"5");
				orange.VerticalAlignment=XlVAlign.xlVAlignCenter;
				orange.MergeCells=true;
			}
			for(int i=4;i<=socot;i++) osheet.Cells[dong-1,i+1]=get_ten((i%2==0)?4:5);
			orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=8;
			orange.EntireColumn.AutoFit();

			oxl.ActiveWindow.DisplayZeros=false;
//			osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
//			osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
//			osheet.PageSetup.LeftMargin=20;
//			osheet.PageSetup.RightMargin=20;
//			osheet.PageSetup.TopMargin=30;
//			osheet.PageSetup.CenterFooter="Trang : &P/&N";

			osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			osheet.Cells[1,4]="BÁO CÁO XUẤT KHO";
			string s_title=d.title(tu.Value.ToString(),den.Value.ToString())+" năm "+yyyy.Value.ToString();
			osheet.Cells[2,4]=s_title;
			orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-1)+"2");
			orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			orange.Font.Size=12;
			orange.Font.Bold=true;
			if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
			else oxl.Visible=true;
		}

		private void tao_table()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_xuat_ct.xml");
            ds.Tables[0].Columns.Add("tenvp");
			dtmakp.Clear();
			if (chkMadt.Checked)
			{
				foreach(DataRow r in dtmadt.Select("true","madoituong"))
				{
					dc=new DataColumn();
					dc.ColumnName="SL_"+r["madoituong"].ToString().Trim().PadLeft(2,'0');
					dc.DataType=Type.GetType("System.Decimal");
					ds.Tables[0].Columns.Add(dc);
					dc=new DataColumn();
					dc.ColumnName="ST_"+r["madoituong"].ToString().Trim().PadLeft(2,'0');
					dc.DataType=Type.GetType("System.Decimal");
					ds.Tables[0].Columns.Add(dc);
				}
			}
			else
			{
				s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
				s_tu=tu.Value.ToString().PadLeft(2,'0');
				s_den=den.Value.ToString().PadLeft(2,'0');
				s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
				int y1=int.Parse(yyyy.Value.ToString()),m1=int.Parse(tu.Value.ToString());
				int y2=int.Parse(yyyy.Value.ToString()),m2=int.Parse(den.Value.ToString());
				int itu,iden;
				string mmyy=m1.ToString().PadLeft(2,'0')+y1.ToString().Substring(2,2);
				for(int i=y1;i<=y2;i++)
				{
					itu=(i==y1)?m1:1;
					iden=(i==y2)?m2:12;
					for(int j=itu;j<=iden;j++)
					{
						mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
						if (d.bMmyy(mmyy)) get_xuat_makp(mmyy);
					}
				}		
				foreach(DataRow r in dtmakp.Select("makp<>''","stt,makp"))
				{
					dc=new DataColumn();
					dc.ColumnName="SL_"+r["makp"].ToString().Trim();
					dc.DataType=Type.GetType("System.Decimal");
					ds.Tables[0].Columns.Add(dc);
					dc=new DataColumn();
					dc.ColumnName="ST_"+r["makp"].ToString().Trim();
					dc.DataType=Type.GetType("System.Decimal");
					ds.Tables[0].Columns.Add(dc);
				}
			}
			dc=new DataColumn();
			dc.ColumnName="SOLUONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="SOTIEN";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
        }
        #region  // chuong trinh lao cai 

        private void get_sort_madt_laocai()
        {
            dsts = ds.Copy();
            dsxml = ds.Copy();
            dsxml.Clear();
            dsts.Clear();
            int idnn = 0, stt = 0, tt = 1;
            sql = (s_manhom != "") ? "tennhom,idnn" : "tennhom,idnn";
            string tennhom = "";
            tenreport = tenfile;
            DataRow[] dr = ds.Tables[0].Select("ma<>''", sql);
            for (int i = 0; i < dr.Length; i++)
            {
                idnn = int.Parse(dr[i]["idnn"].ToString());
              //  stt = int.Parse(dr[i]["stt"].ToString());
                tennhom = dr[i]["tennhom"].ToString();
                exp = "idnn=" + idnn + " and stt=" + stt + " and tennhom='" + tennhom + "'";
                r3 = d.getrowbyid(dsts.Tables[0], exp);
                if (r3 == null)
                {
                    r4 = dsts.Tables[0].NewRow();
                    r4["idnn"] = idnn;
                    r4["tennhom"] = tennhom;
                    foreach (DataRow r5 in dtmadt.Select("true", "madoituong"))
                        r4["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = decimal.Parse(dr[i]["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString());
                    r4["sotien"] = decimal.Parse(dr[i]["sotien"].ToString());
                    dsts.Tables[0].Rows.Add(r4);
                }
                else
                {
                    DataRow[] dr1 = dsts.Tables[0].Select(exp);
                    foreach (DataRow r5 in dtmadt.Select("true", "madoituong"))
                        dr1[0]["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = decimal.Parse(dr1[0]["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString()) + decimal.Parse(dr[i]["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString());
                    dr1[0]["sotien"] = decimal.Parse(dr1[0]["sotien"].ToString()) + decimal.Parse(dr[i]["sotien"].ToString());
                }
            }


            for (int i = 0; i < dr.Length; i++)
            {
                if (tennhom != dr[i]["tennhom"].ToString() || idnn != int.Parse(dr[i]["idnn"].ToString()) )
                {
                    if (tennhom != dr[i]["tennhom"].ToString())
                    {
                        tennhom = dr[i]["tennhom"].ToString();
                        stt = 0;
                        exp = "tennhom='" + tennhom + "'";
                        r2 = dsxml.Tables[0].NewRow();
                        r2["stt"] = 0;
                        r2["ten"] = dr[i]["tennhom"].ToString().ToUpper();
                        r2["dang"] = "";
                        r2["dongia"] = 0;
                        foreach (DataRow r5 in dtmadt.Select("true", "madoituong"))
                        {
                            r2["sl_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = 0;
                            r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = 0;
                            foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                                r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = decimal.Parse(r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString()) + decimal.Parse(r6["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString());
                        }
                        r2["soluong"] = 0;
                        r2["sotien"] = 0;
                        foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                            r2["sotien"] = decimal.Parse(r2["sotien"].ToString()) + decimal.Parse(r6["sotien"].ToString());
                        dsxml.Tables[0].Rows.Add(r2);
                    }
                    if (idnn != int.Parse(dr[i]["idnn"].ToString()))
                    {
                        idnn = int.Parse(dr[i]["idnn"].ToString());
                        stt = 0;
                        exp = "idnn=" + idnn;
                        r2 = dsxml.Tables[0].NewRow();
                        
                        r2["ten"] = dr[i]["noingoai"].ToString().ToUpper();
                        r2["dang"] = "";
                        r2["dongia"] = 0;
                        foreach (DataRow r5 in dtmadt.Select("true", "madoituong"))
                        {
                            r2["sl_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = 0;
                            r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = 0;
                            foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                                r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = decimal.Parse(r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString()) + decimal.Parse(r6["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString());
                        }
                        r2["soluong"] = 0;
                        r2["sotien"] = 0;
                        foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                            r2["sotien"] = decimal.Parse(r2["sotien"].ToString()) + decimal.Parse(r6["sotien"].ToString());
                        dsxml.Tables[0].Rows.Add(r2);
                    }
                    
                }
                r2 = dsxml.Tables[0].NewRow();
                r2["manhom"] = dr[i]["manhom"].ToString();
                r2["tennhom"] = dr[i]["tennhom"].ToString();
                r2["mabd"] = dr[i]["mabd"].ToString();
                r2["ma"] = dr[i]["ma"].ToString();
                r2["ten"] = dr[i]["ten"].ToString();
                r2["tenhc"] = dr[i]["tenhc"].ToString();
                r2["dang"] = dr[i]["dang"].ToString();
                r2["dongia"] = dr[i]["dongia"].ToString();
                r2["manguon"] = dr[i]["manguon"].ToString();
             
                r2["idnn"] = dr[i]["idnn"].ToString();
                r2["noingoai"] = dr[i]["noingoai"].ToString();
             //   r2["tenvp"] = dr[i]["tenvp"].ToString();
                foreach (DataRow r5 in dtmadt.Select("true", "madoituong"))
                {
                    r2["sl_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = dr[i]["sl_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString();
                    r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = dr[i]["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString();
                }
                r2["soluong"] = dr[i]["soluong"].ToString();
                r2["sotien"] = dr[i]["sotien"].ToString();
                dsxml.Tables[0].Rows.Add(r2);
                tt++;
            }
            //tongcong
            if (dr.Length > 0)
            {
                exp = "true";
                r2 = dsxml.Tables[0].NewRow();
                r2["stt"] = 0;
                r2["ten"] = "TỔNG CỘNG :";
                r2["dang"] = "";
                r2["dongia"] = 0;
                foreach (DataRow r5 in dtmadt.Select("true", "madoituong"))
                {
                    r2["sl_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = 0;
                    r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = 0;
                    foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                        r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = decimal.Parse(r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString()) + decimal.Parse(r6["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString());
                }
                r2["soluong"] = 0;
                r2["sotien"] = 0;
                foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                    r2["sotien"] = decimal.Parse(r2["sotien"].ToString()) + decimal.Parse(r6["sotien"].ToString());
                dsxml.Tables[0].Rows.Add(r2);
            }
            //
            dsxml.Tables[0].Columns.Remove("manhom");
            dsxml.Tables[0].Columns.Remove("mabd");
            dsxml.Tables[0].Columns.Remove("ma");
            dsxml.Tables[0].Columns.Remove("tenhc");
            dsxml.Tables[0].Columns.Remove("manguon");
            dsxml.Tables[0].Columns.Remove("tennhom");
            dsxml.Tables[0].Columns.Remove("noingoai");
            dsxml.Tables[0].Columns.Remove("idnn");
            dsxml.Tables[0].Columns.Remove("tenvp");
        }

        #endregion

        private void get_sort_madt()
		{
			dsts=ds.Copy();
			dsxml=ds.Copy();
			dsxml.Clear();
			dsts.Clear();
			int idnn=0,stt=0,tt=1;
			 sql=(s_manhom!="")?"tenvp,idnn,stt,ten":"tenvp,idnn,stt,ten"; 
            string tenvp = "";
			tenreport=tenfile;
			DataRow []dr=ds.Tables[0].Select("ma<>''",sql);
			for(int i=0;i<dr.Length;i++)
			{
				idnn=int.Parse(dr[i]["idnn"].ToString());
				stt=int.Parse(dr[i]["stt"].ToString());
                tenvp = dr[i]["tenvp"].ToString();
                exp = "idnn=" + idnn + " and stt=" + stt + " and tenvp='" + tenvp + "'";
				r3=d.getrowbyid(dsts.Tables[0],exp);
				if (r3==null)
				{
					r4=dsts.Tables[0].NewRow();
					r4["idnn"]=idnn;
					r4["stt"]=stt;
                    r4["tenvp"] = tenvp;
					foreach(DataRow r5 in dtmadt.Select("true","madoituong")) 
						r4["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=decimal.Parse(dr[i]["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString());
					r4["sotien"]=decimal.Parse(dr[i]["sotien"].ToString());
					dsts.Tables[0].Rows.Add(r4);
				}
				else
				{
					DataRow []dr1=dsts.Tables[0].Select(exp);
					foreach(DataRow r5 in dtmadt.Select("true","madoituong")) 
						dr1[0]["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=decimal.Parse(dr1[0]["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString())+decimal.Parse(dr[i]["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString());
					dr1[0]["sotien"]=decimal.Parse(dr1[0]["sotien"].ToString())+decimal.Parse(dr[i]["sotien"].ToString());
				}
			}


			for(int i=0;i<dr.Length;i++)
			{
				if (tenvp !=dr[i]["tenvp"].ToString() || idnn!=int.Parse(dr[i]["idnn"].ToString()) || stt!=int.Parse(dr[i]["stt"].ToString()))
				{
                    if (tenvp != dr[i]["tenvp"].ToString())
                    {
                        tenvp = dr[i]["tenvp"].ToString();
                        stt = 0;
                        exp = "tenvp='" + tenvp+"'";
                        r2 = dsxml.Tables[0].NewRow();
                        r2["stt"] = 0;
                        r2["ten"] = dr[i]["tenvp"].ToString().ToUpper();
                        r2["dang"] = "";
                        r2["dongia"] = 0;
                        foreach (DataRow r5 in dtmadt.Select("true", "madoituong"))
                        {
                            r2["sl_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = 0;
                            r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = 0;
                            foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                                r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')] = decimal.Parse(r2["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString()) + decimal.Parse(r6["st_" + r5["madoituong"].ToString().Trim().PadLeft(2, '0')].ToString());
                        }
                        r2["soluong"] = 0;
                        r2["sotien"] = 0;
                        foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                            r2["sotien"] = decimal.Parse(r2["sotien"].ToString()) + decimal.Parse(r6["sotien"].ToString());
                        dsxml.Tables[0].Rows.Add(r2);
                    }
					if (idnn!=int.Parse(dr[i]["idnn"].ToString()))
					{
						idnn=int.Parse(dr[i]["idnn"].ToString());
						stt=0;
						exp="idnn="+idnn;
						r2 = dsxml.Tables[0].NewRow();
						r2["stt"]=0;
						r2["ten"]=dr[i]["noingoai"].ToString().ToUpper();
						r2["dang"]="";
						r2["dongia"]=0;
						foreach(DataRow r5 in dtmadt.Select("true","madoituong"))
						{
							r2["sl_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=0;
							r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=0;
							foreach(DataRow r6 in dsts.Tables[0].Select(exp))
								r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=decimal.Parse(r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString())+decimal.Parse(r6["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString());
						}
						r2["soluong"]=0;
						r2["sotien"]=0;
						foreach(DataRow r6 in dsts.Tables[0].Select(exp))
							r2["sotien"]=decimal.Parse(r2["sotien"].ToString())+decimal.Parse(r6["sotien"].ToString());
						dsxml.Tables[0].Rows.Add(r2);
					}
					if (stt!=int.Parse(dr[i]["stt"].ToString()))
					{
						stt=int.Parse(dr[i]["stt"].ToString());
						exp="idnn="+idnn+" and stt="+stt;
						r2 = dsxml.Tables[0].NewRow();
						r2["stt"]=0;
						r2["ten"]=dr[i]["tennhom"].ToString().ToUpper();
						r2["dang"]="";
						r2["dongia"]=0;
						foreach(DataRow r5 in dtmadt.Select("true","madoituong"))
						{
							r2["sl_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=0;
							r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=0;
							foreach(DataRow r6 in dsts.Tables[0].Select(exp))
								r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=decimal.Parse(r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString())+decimal.Parse(r6["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString());
						}
						r2["soluong"]=0;
						r2["sotien"]=0;
						foreach(DataRow r6 in dsts.Tables[0].Select(exp))
							r2["sotien"]=decimal.Parse(r2["sotien"].ToString())+decimal.Parse(r6["sotien"].ToString());
						dsxml.Tables[0].Rows.Add(r2);
					}
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
				r2["manguon"]=dr[i]["manguon"].ToString();
				r2["stt"]=tt.ToString();
				r2["idnn"]=dr[i]["idnn"].ToString();
				r2["noingoai"]=dr[i]["noingoai"].ToString();
                r2["tenvp"] = dr[i]["tenvp"].ToString();
				foreach(DataRow r5 in dtmadt.Select("true","madoituong"))
				{
					r2["sl_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=dr[i]["sl_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString();
					r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=dr[i]["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString();
				}
				r2["soluong"]=dr[i]["soluong"].ToString();
				r2["sotien"]=dr[i]["sotien"].ToString();
				dsxml.Tables[0].Rows.Add(r2);
				tt++;
			}
			//tongcong
			if (dr.Length>0)
			{
				exp="true";
				r2 = dsxml.Tables[0].NewRow();
				r2["stt"]=0;
				r2["ten"]="TỔNG CỘNG :";
				r2["dang"]="";
				r2["dongia"]=0;
				foreach(DataRow r5 in dtmadt.Select("true","madoituong"))
				{
					r2["sl_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=0;
					r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=0;
					foreach(DataRow r6 in dsts.Tables[0].Select(exp))
						r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=decimal.Parse(r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString())+decimal.Parse(r6["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')].ToString());
				}
				r2["soluong"]=0;
				r2["sotien"]=0;
				foreach(DataRow r6 in dsts.Tables[0].Select(exp))
					r2["sotien"]=decimal.Parse(r2["sotien"].ToString())+decimal.Parse(r6["sotien"].ToString());
				dsxml.Tables[0].Rows.Add(r2);
			}
			//
			dsxml.Tables[0].Columns.Remove("manhom");
			dsxml.Tables[0].Columns.Remove("mabd");
			dsxml.Tables[0].Columns.Remove("ma");
			dsxml.Tables[0].Columns.Remove("tenhc");
			dsxml.Tables[0].Columns.Remove("manguon");
			dsxml.Tables[0].Columns.Remove("tennhom");
			dsxml.Tables[0].Columns.Remove("noingoai");
			dsxml.Tables[0].Columns.Remove("idnn");
            dsxml.Tables[0].Columns.Remove("tenvp");
		}

		private void get_sort()
		{
			dsts=ds.Copy();
			dsxml=ds.Copy();
			dsxml.Clear();
			dsts.Clear();
			int idnn=0,stt=0,tt=1;
            string tenvp = "";
			sql=(s_manhom!="")?"tenvp,idnn,stt,ten":"tenvp,idnn,stt,ten";
			tenreport=tenfile;
			DataRow []dr=ds.Tables[0].Select("ma<>''",sql);
				for(int i=0;i<dr.Length;i++)
				{
					idnn=int.Parse(dr[i]["idnn"].ToString());
					stt=int.Parse(dr[i]["stt"].ToString());
                    tenvp = dr[i]["tenvp"].ToString();
					exp="idnn="+idnn+" and stt="+stt+" and tenvp='"+tenvp+"'";
					r3=d.getrowbyid(dsts.Tables[0],exp);
					if (r3==null)
					{
						r4=dsts.Tables[0].NewRow();
						r4["idnn"]=idnn;
						r4["stt"]=stt;
                        r4["tenvp"] = tenvp;
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp")) 
							r4["st_"+r5["makp"].ToString().Trim()]=decimal.Parse(dr[i]["st_"+r5["makp"].ToString().Trim()].ToString());
						r4["sotien"]=decimal.Parse(dr[i]["sotien"].ToString());
						dsts.Tables[0].Rows.Add(r4);
					}
					else
					{
						DataRow []dr1=dsts.Tables[0].Select(exp);
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp")) 
							dr1[0]["st_"+r5["makp"].ToString().Trim()]=decimal.Parse(dr1[0]["st_"+r5["makp"].ToString().Trim()].ToString())+decimal.Parse(dr[i]["st_"+r5["makp"].ToString().Trim()].ToString());
						dr1[0]["sotien"]=decimal.Parse(dr1[0]["sotien"].ToString())+decimal.Parse(dr[i]["sotien"].ToString());
					}
				}


			for(int i=0;i<dr.Length;i++)
			{
				if (tenvp!=dr[i]["tenvp"].ToString() || idnn!=int.Parse(dr[i]["idnn"].ToString()) || stt!=int.Parse(dr[i]["stt"].ToString()))
                {
                    if (tenvp != dr[i]["tenvp"].ToString())
                    {
                        tenvp = dr[i]["tenvp"].ToString();
                        stt = 0;
                        exp = "tenvp='" + tenvp+"'";
                        r2 = dsxml.Tables[0].NewRow();
                        r2["stt"] = 0;
                        r2["ten"] = dr[i]["tenvp"].ToString().ToUpper();
                        r2["dang"] = "";
                        r2["dongia"] = 0;
                        foreach (DataRow r5 in dtmakp.Select("makp<>''", "stt,makp"))
                        {
                            r2["sl_" + r5["makp"].ToString().Trim()] = 0;
                            r2["st_" + r5["makp"].ToString().Trim()] = 0;
                            foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                                r2["st_" + r5["makp"].ToString().Trim()] = decimal.Parse(r2["st_" + r5["makp"].ToString().Trim()].ToString()) + decimal.Parse(r6["st_" + r5["makp"].ToString().Trim()].ToString());
                        }
                        r2["soluong"] = 0;
                        r2["sotien"] = 0;
                        foreach (DataRow r6 in dsts.Tables[0].Select(exp))
                            r2["sotien"] = decimal.Parse(r2["sotien"].ToString()) + decimal.Parse(r6["sotien"].ToString());
                        dsxml.Tables[0].Rows.Add(r2);
                    }
					if (idnn!=int.Parse(dr[i]["idnn"].ToString()))
					{
						idnn=int.Parse(dr[i]["idnn"].ToString());
						stt=0;
						exp="idnn="+idnn;
						r2 = dsxml.Tables[0].NewRow();
						r2["stt"]=0;
						r2["ten"]=dr[i]["noingoai"].ToString().ToUpper();
						r2["dang"]="";
						r2["dongia"]=0;
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
						{
							r2["sl_"+r5["makp"].ToString().Trim()]=0;
							r2["st_"+r5["makp"].ToString().Trim()]=0;
							foreach(DataRow r6 in dsts.Tables[0].Select(exp))
								r2["st_"+r5["makp"].ToString().Trim()]=decimal.Parse(r2["st_"+r5["makp"].ToString().Trim()].ToString())+decimal.Parse(r6["st_"+r5["makp"].ToString().Trim()].ToString());
						}
						r2["soluong"]=0;
						r2["sotien"]=0;
						foreach(DataRow r6 in dsts.Tables[0].Select(exp))
							r2["sotien"]=decimal.Parse(r2["sotien"].ToString())+decimal.Parse(r6["sotien"].ToString());
						dsxml.Tables[0].Rows.Add(r2);
					}
					if (stt!=int.Parse(dr[i]["stt"].ToString()))
					{
						stt=int.Parse(dr[i]["stt"].ToString());
						exp="idnn="+idnn+" and stt="+stt;
						r2 = dsxml.Tables[0].NewRow();
						r2["stt"]=0;
						r2["ten"]=dr[i]["tennhom"].ToString().ToUpper();
						r2["dang"]="";
						r2["dongia"]=0;
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
						{
							r2["sl_"+r5["makp"].ToString().Trim()]=0;
							r2["st_"+r5["makp"].ToString().Trim()]=0;
							foreach(DataRow r6 in dsts.Tables[0].Select(exp))
								r2["st_"+r5["makp"].ToString().Trim()]=decimal.Parse(r2["st_"+r5["makp"].ToString().Trim()].ToString())+decimal.Parse(r6["st_"+r5["makp"].ToString().Trim()].ToString());
						}
						r2["soluong"]=0;
						r2["sotien"]=0;
						foreach(DataRow r6 in dsts.Tables[0].Select(exp))
							r2["sotien"]=decimal.Parse(r2["sotien"].ToString())+decimal.Parse(r6["sotien"].ToString());
						dsxml.Tables[0].Rows.Add(r2);
					}
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
				r2["manguon"]=dr[i]["manguon"].ToString();
				r2["stt"]=tt.ToString();
				r2["idnn"]=dr[i]["idnn"].ToString();
				r2["noingoai"]=dr[i]["noingoai"].ToString();
                r2["tenvp"] = dr[i]["tenvp"].ToString();
				foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
				{
					r2["sl_"+r5["makp"].ToString().Trim()]=dr[i]["sl_"+r5["makp"].ToString().Trim()].ToString();
					r2["st_"+r5["makp"].ToString().Trim()]=dr[i]["st_"+r5["makp"].ToString().Trim()].ToString();
				}
				r2["soluong"]=dr[i]["soluong"].ToString();
				r2["sotien"]=dr[i]["sotien"].ToString();
				dsxml.Tables[0].Rows.Add(r2);
				tt++;
			}
			//tongcong
			if (dr.Length>0)
			{
				exp="true";
				r2 = dsxml.Tables[0].NewRow();
				r2["stt"]=0;
				r2["ten"]="TỔNG CỘNG :";
				r2["dang"]="";
				r2["dongia"]=0;
				foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
				{
					r2["sl_"+r5["makp"].ToString().Trim()]=0;
					r2["st_"+r5["makp"].ToString().Trim()]=0;
					foreach(DataRow r6 in dsts.Tables[0].Select(exp))
						r2["st_"+r5["makp"].ToString().Trim()]=decimal.Parse(r2["st_"+r5["makp"].ToString().Trim()].ToString())+decimal.Parse(r6["st_"+r5["makp"].ToString().Trim()].ToString());
				}
				r2["soluong"]=0;
				r2["sotien"]=0;
				foreach(DataRow r6 in dsts.Tables[0].Select(exp))
					r2["sotien"]=decimal.Parse(r2["sotien"].ToString())+decimal.Parse(r6["sotien"].ToString());
				dsxml.Tables[0].Rows.Add(r2);
			}
			//
			dsxml.Tables[0].Columns.Remove("manhom");
			dsxml.Tables[0].Columns.Remove("mabd");
			dsxml.Tables[0].Columns.Remove("ma");
			dsxml.Tables[0].Columns.Remove("tenhc");
			dsxml.Tables[0].Columns.Remove("manguon");
			dsxml.Tables[0].Columns.Remove("tennhom");
			dsxml.Tables[0].Columns.Remove("noingoai");
			dsxml.Tables[0].Columns.Remove("idnn");
            dsxml.Tables[0].Columns.Remove("tenvp");
		}

		private void get_xuat_makp(string d_mmyy)
		{
            xxx = user + d_mmyy;
			//string tenfile=(cstt.Checked)?"d_thucxuat":"d_thucbucstt";
            
            string s_tablexuatct = madoituong.SelectedIndex >= 0 ? "d_xuatsdct" : "d_thucxuat";
            string tenfile = (cstt.Checked && madoituong.SelectedIndex < 0) ? "d_thucxuat" : "d_thucbucstt";
            sql = "select distinct a.makp from " + xxx + ".d_xuatsdll a," + xxx + "." + s_tablexuatct + " b," + xxx + ".d_theodoi t," + user + ".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in(1,3,4) and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" union all ";
			sql+="select distinct a.makp from "+xxx+".d_xuatsdll a,"+xxx+"."+tenfile+" b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in(2) and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
            //if (cstt.Checked && madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			sql+=" and b.soluong>0";
            dtthuythem = d.get_data(sql).Tables[0];
			foreach(DataRow r in dtthuythem.Rows) updrec(r["makp"].ToString().Trim(),true);

			if (madoituong.SelectedIndex==-1)
			{
				sql="select count(*) as so from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom;
				if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and b.soluong>0";
				if (d.get_data(sql).Tables[0].Rows[0]["so"].ToString()!="0") updrec("BHY",false);

				sql="select count(*) as so from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom;
				if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and b.soluong>0";
				if (d.get_data(sql).Tables[0].Rows[0]["so"].ToString()!="0") updrec("NTR",false);

				sql="select count(*) as so from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom+" and a.loai in ('BS','XK')";
				if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and b.soluong>0";
				if (d.get_data(sql).Tables[0].Rows[0]["so"].ToString()!="0") updrec("KHA",false);
			}
		}

		private void get_xuat_madt(string d_mmyy)
		{
            xxx = user + d_mmyy;
            string s_gia = chkgianovat.Checked ? "d.gianovat" : "d.giamua";
            string s_tablexuatct = madoituong.SelectedIndex >= 0 ? "d_xuatsdct" : "d_xuatsdct";// "d_thucxuat";
            string tenfile = (cstt.Checked && madoituong.SelectedIndex < 0) ? "d_thucxuat" : "d_thucbucstt";
            //
			sql="select to_char(b.madoituong,'00') as ma,b.makho,b.mabd,sum(b.soluong) as soluong,";
            sql += "sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia,";
            sql += "d.manguon from " + xxx + ".d_xuatsdll a," + xxx + "." + s_tablexuatct + " b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,2,4) and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by to_char(b.madoituong,'00'),b.makho,b.mabd,";
            sql += "" + s_gia + ",";
			sql+="d.manguon";
			sql+=" union all ";
			sql+="select to_char(b.madoituong,'00') as ma,b.makho,b.mabd,-sum(b.soluong) as soluong,";
            sql += "-sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia,";
            sql += "d.manguon from " + xxx + ".d_xuatsdll a," + xxx + "." + s_tablexuatct + " b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.sttt=d.id and b.mabd=c.id and a.loai in(3) and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (cstt.Checked && madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by to_char(b.madoituong,'00'),b.makho,b.mabd,";
            sql += "" + s_gia + ",";
			sql+="d.manguon  ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{				
				exp="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
                        r2["tenvp"] = r3["tenvp"].ToString();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						foreach(DataRow r5 in dtmadt.Select("true","madoituong"))
						{
							r2["sl_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=0;
							r2["st_"+r5["madoituong"].ToString().Trim().PadLeft(2,'0')]=0;
						}
						r2["sl_"+r["ma"].ToString().Trim().PadLeft(2,'0')]=r["soluong"].ToString();
						r2["st_"+r["ma"].ToString().Trim().PadLeft(2,'0')]=r["sotien"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();						
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0]["sl_"+r["ma"].ToString().Trim().PadLeft(2,'0')]=decimal.Parse(dr[0]["sl_"+r["ma"].ToString().Trim().PadLeft(2,'0')].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["st_"+r["ma"].ToString().Trim().PadLeft(2,'0')]=decimal.Parse(dr[0]["st_"+r["ma"].ToString().Trim().PadLeft(2,'0')].ToString())+decimal.Parse(r["sotien"].ToString());
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
            string s_gia = chkgianovat.Checked ? "d.gianovat" : "d.giamua";
            string s_tablexuatct = madoituong.SelectedIndex >= 0 ? "d_xuatsdct" : "d_thucxuat";
            string tenfile = (cstt.Checked && madoituong.SelectedIndex < 0) ? "d_thucxuat" : "d_thucbucstt";
            tenfile = (cstt.Checked && madoituong.SelectedIndex >= 0) ? "d_xuatsdct" : "d_bucstt";
			//LINH + HAO PHI
            sql="select to_char(a.makp) as makp,b.makho,b.mabd,sum(b.soluong) as soluong,";
            sql += "sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia,";
            sql += "d.manguon from " + xxx + ".d_xuatsdll a," + xxx + "." + s_tablexuatct + " b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,4) and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by to_char(a.makp),b.makho,b.mabd,";
            sql += "" + s_gia + ",";
			sql+="d.manguon"; 
            //XUAT TU TRUC -- HOAC BU TU TRUC (TÙY THEO CHECKBOX: SO LIEU TINH THEO XUAT TU TRUC
			sql+=" union all ";
			sql+="select to_char(a.makp) as makp,b.makho,b.mabd,sum(b.soluong) as soluong,";
            sql += "sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia,";
			sql+="d.manguon from "+xxx+".d_xuatsdll a,"+xxx+"."+tenfile+" b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.sttt=d.id and b.mabd=c.id and a.loai in(2) and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (cstt.Checked && madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by to_char(a.makp),b.makho,b.mabd,";
            sql += "" + s_gia + ",";
			sql+="d.manguon  ";
			if (madoituong.SelectedIndex==-1)
			{
				//xuat BS, XK
				sql+=" union all ";
				sql+="select 'KHA' as makp,a.khox as makho,b.mabd,sum(b.soluong) as soluong,";
                sql += "sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia,";
				sql+="d.manguon from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.sttt=d.id and b.mabd=c.id and a.nhom="+i_nhom+" and a.loai in ('BS','XK')";
				if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and b.soluong>0";
				sql+=" group by a.khox,b.mabd,";
                sql += "" + s_gia + ",";
				sql+="d.manguon ";
				//BHYT
				sql+=" union all ";
				sql+="select 'BHY' as makp,b.makho,b.mabd,sum(b.soluong) as soluong,";
                sql += "sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia,";
				sql+="d.manguon from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.sttt=d.id and b.mabd=c.id and a.nhom="+i_nhom;
				if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and b.soluong>0";
				sql+=" group by b.makho,b.mabd,";
                sql += "" + s_gia + ",";
				sql+="d.manguon ";
				//ngoaitru
				//BHYT
				sql+=" union all ";
				sql+="select 'NTR' as makp,b.makho,b.mabd,sum(b.soluong) as soluong,";
                sql += "sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia,";
				sql+="d.manguon from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.sttt=d.id and b.mabd=c.id and a.nhom="+i_nhom;
				if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and b.soluong>0";
				sql+=" group by b.makho,b.mabd,";
                sql += "" + s_gia + ",";
				sql+="d.manguon ";
			}
            dtthuythem = d.get_data(sql).Tables[0];
			foreach(DataRow r in dtthuythem.Rows)
			{				
				exp="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
                        r2["tenvp"] = r3["tenvp"].ToString();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
						{
							r2["sl_"+r5["makp"].ToString().Trim()]=0;
							r2["st_"+r5["makp"].ToString().Trim()]=0;
						}
						r2["sl_"+r["makp"].ToString().Trim()]=r["soluong"].ToString();
						r2["st_"+r["makp"].ToString().Trim()]=r["sotien"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();						
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["st_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["st_"+r["makp"].ToString().Trim()].ToString())+decimal.Parse(r["sotien"].ToString());
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
            string s_gia = chkgianovat.Checked ? "d.gianovat" : "d.giamua";
            string s_tablexuatct = madoituong.SelectedIndex >= 0 ? "d_xuatsdct" : "d_thucxuat";
			sql="select to_char(a.makp) as makp,b.makho,b.mabd,sum(b.soluong) as soluong,";
            sql += "sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia,";
            sql += "d.manguon from " + xxx + ".d_xuatsdll a," + xxx + "." + s_tablexuatct + " b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.sttt=d.id and b.mabd=c.id and a.loai=3 and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by to_char(a.makp),b.makho,b.mabd,";
            sql += "" + s_gia + ",";
			sql+="d.manguon ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
                        r2["tenvp"] = r3["tenvp"].ToString();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
						{
							r2["sl_"+r5["makp"].ToString().Trim()]=0;
							r2["st_"+r5["makp"].ToString().Trim()]=0;
						}
						r2["sl_"+r["makp"].ToString().Trim()]=-decimal.Parse(r["soluong"].ToString());
						r2["st_"+r["makp"].ToString().Trim()]=-decimal.Parse(r["sotien"].ToString());
						r2["soluong"]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien"]=-decimal.Parse(r["sotien"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["st_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["st_"+r["makp"].ToString().Trim()].ToString())-decimal.Parse(r["sotien"].ToString());
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())-decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}


		private void rptXuat_CT_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				madoituong.SelectedIndex=-1;
				bClear=false;
			}
		}

		private bool get_data()
		{
			if (tu.Value>den.Value)
			{
				MessageBox.Show(lan.Change_language_MessageText("Tháng không hợp lệ !"),d.Msg);
				tu.Focus();
				return false;
			}
			s_makp="";
			if (makp.SelectedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++) if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["id"].ToString().Trim()+",";
			s_manhom="";
			for(int i=0;i<manhom.Items.Count;i++) 
				if (manhom.GetItemChecked(i)) s_manhom+=dtdmnhom.Rows[i]["id"].ToString()+",";
			s_kho="";
			string s_tenkho="";
			for(int i=0;i<kho.Items.Count;i++) 
			{
				if (kho.GetItemChecked(i))
				{
					s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
					s_tenkho+=dtdmkho.Rows[i]["ten"].ToString()+",";
				}
			}
			tao_table();
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			int y1=int.Parse(yyyy.Value.ToString()),m1=int.Parse(tu.Value.ToString());
			int y2=int.Parse(yyyy.Value.ToString()),m2=int.Parse(den.Value.ToString());
			int itu,iden;
			string mmyy=m1.ToString().PadLeft(2,'0')+y1.ToString().Substring(2,2);
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{						
						if (chkMadt.Checked) get_xuat_madt(mmyy);
						else
						{
							get_xuat(mmyy);
							get_hoantra(mmyy);
						}
					}
				}
			}			
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return false;
			}
            if (chkMadt.Checked)
            {
                if (d.Mabv == "205.2.01")
                {
                    get_sort_madt_laocai();
                }
                else
                {
                    get_sort_madt();
                }
            }
            else get_sort();
            return true;
		}

		private void updrec (string makp,bool so)
		{
			int stt=999;
			string ten="Khác",ma=makp;
		//	makp=makp.PadLeft(3,'0');
            makp = makp;//.PadLeft(3, '0');
			exp="makp='"+makp+"'";
			DataRow r = d.getrowbyid (dtmakp,exp); 
			if ( r == null )
			{
				if (so)
				{
					foreach(DataRow r1 in dtnhomkp.Rows)
					{
						if (r1["makp"].ToString().IndexOf(ma.PadLeft(3,'0')+",")!=-1)
						{
							stt=int.Parse(r1["stt"].ToString());
							ten=r1["ten"].ToString().ToUpper();
						}
					}
				}
				else
				{
					ten=(makp=="BHY")?"BHYT":(makp=="NTR")?"NGOẠI TRÚ":"KHÁC";
					stt=(makp=="BHY")?997:(makp=="NTR")?998:999;
				}
				DataRow nrow = dtmakp.NewRow ( ) ;
				nrow["makp"] = makp;
				nrow["tenkp"]= ten;
				nrow["stt"]=stt;
				dtmakp.Rows.Add ( nrow ) ;
			}
		}

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
	}
}