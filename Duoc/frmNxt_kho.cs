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
	public class frmNxt_kho : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, tt, i_dongiale, i_thanhtien_le, i_loai = 0, i_madv, i_userid=0;
		private string sql,mmyy,s_makho,s_manhom,s_khott,s_tenkho,s_khokhongin,user,xxx, s_gia="";
		private DataTable dt=new DataTable();
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dtkho=new DataTable();
		private DataTable dtnhom=new DataTable();
        private DataTable dtdmnx = new DataTable();
		private DataRow [] dr;
		private DataRow r1,r2,r3,r4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.CheckedListBox manhom;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nam;
		private System.Windows.Forms.ComboBox theo;
        private TextBox madv;
        private TextBox tendv;
        private Label label6;
        private LibList.List listNX;
        private CheckBox chkDonvi;
        private CheckBox chkXML;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
        private CheckBox chkGianovat;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNxt_kho(AccessData acc,int nhom,string s_mmyy,string makho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;mmyy=s_mmyy;s_makho=makho;
			tu.Value=decimal.Parse(s_mmyy.Substring(0,2));
			den.Value=tu.Value;
			nam.Value=decimal.Parse("20"+s_mmyy.Substring(2));

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNxt_kho));
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.madv = new System.Windows.Forms.TextBox();
            this.tendv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listNX = new LibList.List();
            this.chkDonvi = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(247, 243);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(96, 3);
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
            this.butXem.Location = new System.Drawing.Point(178, 243);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 8;
            this.butXem.Text = "     &In";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Theo :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theo
            // 
            this.theo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.theo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theo.Items.AddRange(new object[] {
            "Số lượng",
            "Đơn giá,Hạn dùng",
            "Số tiền,Hạng dùng",
            "Hạn dùng,lô sản xuất",
            "Tổng hợp",
            "Kế toán (tổng hợp)",
            "Nhóm",
            "Kế toán (chi tiết)"});
            this.theo.Location = new System.Drawing.Point(70, 147);
            this.theo.Name = "theo";
            this.theo.Size = new System.Drawing.Size(192, 21);
            this.theo.TabIndex = 4;
            this.theo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(31, 29);
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
            this.kho.Location = new System.Drawing.Point(70, 29);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 116);
            this.kho.TabIndex = 3;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(265, 4);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(192, 164);
            this.manhom.TabIndex = 7;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(70, 5);
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
            this.tu.Size = new System.Drawing.Size(36, 21);
            this.tu.TabIndex = 0;
            this.tu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(136, 5);
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
            this.den.Size = new System.Drawing.Size(36, 21);
            this.den.TabIndex = 1;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(169, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nam
            // 
            this.nam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(206, 5);
            this.nam.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nam.Minimum = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(56, 21);
            this.nam.TabIndex = 2;
            this.nam.Value = new decimal(new int[] {
            2006,
            0,
            0,
            0});
            this.nam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // madv
            // 
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(70, 170);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(58, 21);
            this.madv.TabIndex = 5;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // tendv
            // 
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(130, 170);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(327, 21);
            this.tendv.TabIndex = 6;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Đơn vị :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(364, 253);
            this.listNX.MatchBufferTimeOut = 1000;
            this.listNX.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNX.Name = "listNX";
            this.listNX.Size = new System.Drawing.Size(75, 17);
            this.listNX.TabIndex = 44;
            this.listNX.TextIndex = -1;
            this.listNX.TextMember = null;
            this.listNX.ValueIndex = -1;
            this.listNX.Visible = false;
            // 
            // chkDonvi
            // 
            this.chkDonvi.AutoSize = true;
            this.chkDonvi.Location = new System.Drawing.Point(340, 195);
            this.chkDonvi.Name = "chkDonvi";
            this.chkDonvi.Size = new System.Drawing.Size(120, 17);
            this.chkDonvi.TabIndex = 45;
            this.chkDonvi.Text = "Theo nhà cung cấp";
            this.chkDonvi.UseVisualStyleBackColor = true;
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(340, 212);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 46;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(477, 302);
            this.tabControl1.TabIndex = 47;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkGianovat);
            this.tabPage1.Controls.Add(this.theo);
            this.tabPage1.Controls.Add(this.kho);
            this.tabPage1.Controls.Add(this.tu);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkXML);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.chkDonvi);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.listNX);
            this.tabPage1.Controls.Add(this.butXem);
            this.tabPage1.Controls.Add(this.madv);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tendv);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.nam);
            this.tabPage1.Controls.Add(this.den);
            this.tabPage1.Controls.Add(this.manhom);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(469, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "N.X.T kho";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkGianovat
            // 
            this.chkGianovat.AutoSize = true;
            this.chkGianovat.Location = new System.Drawing.Point(70, 197);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(127, 17);
            this.chkGianovat.TabIndex = 47;
            this.chkGianovat.Text = "In theo giá trước VAT";
            this.chkGianovat.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(469, 276);
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
            this.richTextBox1.Size = new System.Drawing.Size(463, 270);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // frmNxt_kho
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(477, 302);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNxt_kho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo nhập xuất tồn";
            this.Load += new System.EventHandler(this.frmNxt_kho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmNxt_kho_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			i_loai=(d.Mabv_so==701424)?28:0;
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			i_dongiale=d.d_dongia_le(i_nhom);
            listNX.DisplayMember = "MA";
            listNX.ValueMember = "TEN";
            dtdmnx = d.get_data("select ma,ten,id,nhomcc from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
            listNX.DataSource = dtdmnx;
			sql="select a.*,b.ten as tenhang,case when c.stt is null then 0 else c.stt end as sttnhom,c.ten as tennhom,";
            sql+=" case when d.stt is null then 0 else d.stt end as sttkt,d.ten as nhomkt ";
            sql += " from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id ";
            sql+=" inner join " + user + ".d_dmnhom c on a.manhom=c.id ";
            sql+=" left join " + user + ".d_dmnhomkt d on a.sotk=d.id ";
			sql+=" where a.nhom="+i_nhom;
			dt=d.get_data(sql).Tables[0];

			ds.ReadXml("..\\..\\..\\xml\\d_nxtnhathuoc.xml");
            DataColumn dc = new DataColumn("nhomcc", typeof(decimal));         
            ds.Tables[0].Columns.Add(dc);
            ds.Tables[0].Columns.Add("tennx");

            dsxml = ds.Copy();
            dsxml.Clear();

			sql="select * from "+user+".d_dmkho where hide=0 and nhom="+i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
            kho.DataSource = dtkho;
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			
			s_khokhongin="";
			foreach(DataRow r in d.get_data("select * from "+user+".d_dmkho where hide=0 and nhom="+i_nhom+" and ketoan=1").Tables[0].Rows)
				s_khokhongin+=r["id"].ToString().Trim()+",";
			dtnhom=d.get_data("select * from "+user+".d_dmnhom where nhom="+i_nhom+" order by stt").Tables[0];
            manhom.DataSource = dtnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";

			theo.SelectedIndex=0;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{			
			print();
		}	
		
		private void ins_items(string fie1,string fie2)
		{
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				sql="id="+int.Parse(r["mabd"].ToString());
				if (tt==5 && i_loai!=0) sql+=" and maloai<>"+i_loai;
				r1=d.getrowbyid(dt,sql);
				if (r1!=null)
				{
					sql="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString())+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"' and nhomcc="+int.Parse(r["nhomcc"].ToString());
					r2=d.getrowbyid(ds.Tables[0],sql);
					if (r2==null)
					{
						r3=ds.Tables[0].NewRow();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r1["ma"].ToString();
						r3["ten"]=r1["ten"].ToString().Trim()+" "+r1["hamluong"].ToString();
						r3["tenhc"]=r1["tenhc"].ToString();
						r3["dang"]=r1["dang"].ToString();
						if (tt==5 || tt==7)
						{
							r3["stt"]=r1["sttkt"].ToString();
							r3["tennhom"]=r1["nhomkt"].ToString();
						}
						else
						{
							r3["stt"]=r1["sttnhom"].ToString();
							r3["tennhom"]=r1["tennhom"].ToString();
						}
						r3["tenhang"]=r1["tenhang"].ToString();
						r3["handung"]=r["handung"].ToString();
						r3["losx"]=r["losx"].ToString();
						r3["dongia"]=r["dongia"].ToString();
						r3["tondau"]=0;
						r3["sttondau"]=0;
						r3["slnhap"]=0;
						r3["stnhap"]=0;
						r3["slxuat"]=0;
						r3["stxuat"]=0;
						r3["slnhap_ck"]=0;
						r3["stnhap_ck"]=0;
						r3["slxuat_ck"]=0;
						r3["stxuat_ck"]=0;
						r3[fie1]=r["soluong"].ToString();
						r3[fie2]=r["sotien"].ToString();
                        r3["nhomcc"] = int.Parse(r["nhomcc"].ToString());
                        r4 = d.getrowbyid(dtdmnx, "id=" + int.Parse(r["nhomcc"].ToString()));
                        if (r4 != null) r3["tennx"] = r4["ten"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
					else 
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0)
						{
							dr[0][fie1]=decimal.Parse(dr[0][fie1].ToString())+decimal.Parse(r["soluong"].ToString());
							dr[0][fie2]=decimal.Parse(dr[0][fie2].ToString())+decimal.Parse(r["sotien"].ToString());
						}
					}
				}
			}
		}

		private void get_tondau(string mmyy)
		{
            xxx = user + mmyy;
            s_gia = (chkGianovat.Checked) ? "d.gianovat" : "d.giamua";
			sql="select b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            else sql += ",0 as nhomcc";
            if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
            else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,'' as losx";
            else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,d.losx";
            else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
			else sql+=",0 as dongia,'' as handung,'' as losx";
            sql += ",sum(b.tondau) as soluong,sum(b.tondau*" + s_gia + ") as sotien ";
			sql+=" from "+xxx+".d_tonkhoct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where b.mabd=c.id and b.stt=d.id";
			sql+=" and c.nhom="+i_nhom;
            if (s_makho != "" && (tt <= 3 || tt == 7 || tt == 6)) sql += " and b.makho in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            if (tt > 4 && s_khokhongin != "" && tt != 7 && tt != 6) sql += " and b.makho not in (" + s_khokhongin.Substring(0, s_khokhongin.Length - 1) + ")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
			sql+=" group by b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
            else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung";
            else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung,d.losx";
            else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
			ins_items("tondau","sttondau");
			if (tt>=4 && tt<=5)
			{
				sql="select b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
                else sql += ",0 as nhomcc";
                if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
                else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,'' as losx";
                else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,d.losx";
                else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
				else sql+=",0 as dongia,'' as handung,'' as losx";
                sql += ",sum(b.tondau) as soluong,sum(b.tondau*" + s_gia + ") as sotien ";
				sql+=" from "+xxx+".d_tutrucct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where b.mabd=c.id and b.stt=d.id";
				sql+=" and c.nhom="+i_nhom;
				if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
				if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and b.makho not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
                if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
				sql+=" group by b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
                if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
                else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung";
                else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung,d.losx";
                else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
				ins_items("tondau","sttondau");
			}
		}

		private void get_nhap(string mmyy)
		{
            xxx = user + mmyy;
            s_gia = (chkGianovat.Checked) ? "b.dongia" : "b.giamua";
            string s_sotien = (chkGianovat.Checked) ? "0" : "b.sotien*b.vat/100";
			sql="select b.mabd";
            if (chkDonvi.Checked) sql += ",a.madv as nhomcc";
            else sql += ",0 as nhomcc";
            if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
            else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,b.handung,'' as losx";
            else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,b.handung,b.losx";
            else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
			else sql+=",0 as dongia,'' as handung,'' as losx";
            sql += ",sum(b.soluong) as soluong,sum(b.sotien+" + s_sotien + "+b.cuocvc+b.chaythu) as sotien ";
			sql+=" from "+xxx+".d_nhapll a,"+xxx+".d_nhapct b,"+user+".d_dmbd c where a.id=b.id and b.mabd=c.id";
			sql+=" and a.nhom="+i_nhom;
			if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and a.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and a.makho not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            if (i_madv != 0) sql += " and a.madv=" + i_madv;
			sql+=" group by b.mabd";
            if (chkDonvi.Checked) sql += ",a.madv";
            if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
            else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),b.handung";
            else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),b.handung,b.losx";
            else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
			ins_items("slnhap","stnhap");
			if (tt<4 || s_khott=="")
			{
                s_gia = (chkGianovat.Checked) ? "d.gianovat" : "d.giamua";
				sql="select b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
                else sql += ",0 as nhomcc";
                if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
                else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,'' as losx";
                else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,d.losx";
                else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
				else sql+=",0 as dongia,'' as handung,'' as losx";
                sql += ",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
				sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
				sql+=" and a.nhom="+i_nhom+" and a.loai in ('CK','HT','TH')";
				if (s_makho!="" && tt<=3) sql+=" and a.khon in ("+s_makho.Substring(0,s_makho.Length-1)+")";
				if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and a.khon not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
                if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
				sql+=" group by b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
                if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
                else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung";
                else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung,d.losx";
                else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
				if (s_khott=="") ins_items("slnhap","stnhap");
				else ins_items("slnhap_ck","stnhap_ck");
			}
			else if (tt==5 && s_khokhongin!="")
			{
				sql="select b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
                else sql += ",0 as nhomcc";
				sql+=",0 as dongia,'' as handung,'' as losx";
                sql += ",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
				sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
				sql+=" and a.nhom="+i_nhom+" and a.loai in ('CK')";
				sql+=" and a.khox in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
				sql+=" and a.khon not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
                if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
				sql+=" group by b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
				ins_items("slnhap_ck","stnhap_ck");
			}
		}

		private void get_xuat(string mmyy)
		{
            xxx = user + mmyy;
            s_gia = (chkGianovat.Checked) ? "d.gianovat" : "d.giamua";
			string tenfile=(tt<4 || tt>5)?"d_thucbucstt":"d_thucxuat";
            //ling+haophi
			sql="select b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            else sql += ",0 as nhomcc";
            if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
            else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,'' as losx";
            else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,d.losx";
            else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
			else sql+=",0 as dongia,'' as handung,'' as losx";
            sql += ",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
			sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
			sql+=" and a.nhom="+i_nhom+" and a.loai in (1,4)";
			if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and b.makho not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
			sql+=" group by b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
            else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung";
            else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung,d.losx";
            else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
			ins_items("slxuat","stxuat");
            //bu tu truc
			sql="select b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            else sql += ",0 as nhomcc";
            if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
            else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,'' as losx";
            else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,d.handung,d.losx";
            else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ") as dongia,'' as handung,'' as losx";
			else sql+=",0 as dongia,'' as handung,'' as losx";
            sql += ",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
			sql+=" from "+xxx+".d_xuatsdll a,"+xxx+"."+tenfile+" b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
			sql+=" and a.nhom="+i_nhom+" and a.loai in (2)";
			if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and b.makho not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
			sql+=" group by b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            if (tt == 0) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
            else if (tt < 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung";
            else if (tt == 3) sql += ",trunc(" + s_gia + "," + i_dongiale + "),d.handung,d.losx";
            else if (tt == 4) sql += ",trunc(" + s_gia + "," + i_dongiale + ")";
			ins_items("slxuat","stxuat");
            //tra
			sql="select b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            else sql += ",0 as nhomcc";
			if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
			else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,'' as losx";
			else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,d.losx";
			else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
			else sql+=",0 as dongia,'' as handung,'' as losx";
			sql+=",-sum(b.soluong) as soluong,-sum(b.soluong*" + s_gia + ") as sotien ";
			sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
			sql+=" and a.nhom="+i_nhom+" and a.loai in (3)";
			if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and b.makho not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
			sql+=" group by b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
			if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
			else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung";
			else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung,d.losx";
			else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
			ins_items("slxuat","stxuat");
            //xuat ban
			sql="select b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            else sql += ",0 as nhomcc";
			if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
			else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,'' as losx";
			else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,d.losx";
			else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
			else sql+=",0 as dongia,'' as handung,'' as losx";
			sql+=",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
			sql+=" from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
			sql+=" and a.nhom="+i_nhom;
			if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and b.makho not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
			sql+=" group by b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
			if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
			else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung";
			else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung,d.losx";
			else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
			ins_items("slxuat","stxuat");
            //cap toa bhyt
			sql="select b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            else sql += ",0 as nhomcc";
			if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
			else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,'' as losx";
			else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,d.losx";
			else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
			else sql+=",0 as dongia,'' as handung,'' as losx";
			sql+=",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
			sql+=" from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
			sql+=" and a.nhom="+i_nhom;
			if (s_makho!="" && (tt<=3 || tt==7 ||tt==6)) sql+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and b.makho not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
			sql+=" group by b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
			if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
			else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung";
			else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung,d.losx";
			else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
			ins_items("slxuat","stxuat");
            //xuat khac
			sql="select b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
            else sql += ",0 as nhomcc";
			if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
			else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,'' as losx";
			else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,d.losx";
			else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
			else sql+=",0 as dongia,'' as handung,'' as losx";
			sql+=",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
			sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
			sql+=" and a.nhom="+i_nhom+" and a.loai='XK'";
			if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and a.khox in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and a.khox not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
			sql+=" group by b.mabd";
            if (chkDonvi.Checked) sql += ",d.nhomcc";
			if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
			else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung";
			else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung,d.losx";
			else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
			ins_items("slxuat","stxuat");
			if(tt<4 || tt==7)
			{
                //xuat chuyen kho, bo sung
				sql="select b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
                else sql += ",0 as nhomcc";
				if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
				else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,'' as losx";
				else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,d.losx";
				else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
				else sql+=",0 as dongia,'' as handung,'' as losx";
				sql+=",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
				sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
				sql+=" and a.nhom="+i_nhom+" and a.loai in ('CK','BS')";
				if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and a.khox in ("+s_makho.Substring(0,s_makho.Length-1)+")";
				if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6) sql+=" and a.khox not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
                if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
				sql+=" group by b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
				if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
				else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung";
				else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung,d.losx";
				else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
				ins_items("slxuat_ck","stxuat_ck");
			}
			else if (s_khokhongin!="")
			{
                //chuyen kho
				sql="select b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
                else sql += ",0 as nhomcc";
				if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
				else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,'' as losx";
				else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,d.handung,d.losx";
				else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+") as dongia,'' as handung,'' as losx";
				else sql+=",0 as dongia,'' as handung,'' as losx";
				sql+=",sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien ";
				sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id";
				sql+=" and a.nhom="+i_nhom+" and a.loai in ('CK')";
				if (s_makho!="" && (tt<=3 || tt==7 || tt==6)) sql+=" and a.khox in ("+s_makho.Substring(0,s_makho.Length-1)+")";
				if (tt>4 && s_khokhongin!="" && tt!=7 && tt!=6)
				{
					sql+=" and a.khox not in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
					sql+=" and a.khon in ("+s_khokhongin.Substring(0,s_khokhongin.Length-1)+")";
				}
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
                if (i_madv != 0) sql += " and d.nhomcc=" + i_madv;
				sql+=" group by b.mabd";
                if (chkDonvi.Checked) sql += ",d.nhomcc";
				if (tt==0) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
				else if (tt<3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung";
				else if (tt==3) sql+=",trunc(" + s_gia + ","+i_dongiale+"),d.handung,d.losx";
				else if (tt==4) sql+=",trunc(" + s_gia + ","+i_dongiale+")";
				ins_items("slxuat","stxuat");
			}
		}

		private void print()
		{
			Cursor=Cursors.WaitCursor;
			tt=theo.SelectedIndex;
			s_makho="";s_manhom="";s_khott="";s_tenkho="";
			if (kho.SelectedItems.Count>0)
			{
				if (kho.SelectedItems.Count==1 && tt==5) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
				for(int i=0;i<kho.Items.Count;i++) 
					if (kho.GetItemChecked(i))
					{
						s_makho+=dtkho.Rows[i]["id"].ToString()+",";
						s_tenkho+=dtkho.Rows[i]["ten"].ToString()+",";
						if (dtkho.Rows[i]["khott"].ToString()=="1") s_khott+=dtkho.Rows[i]["id"].ToString()+",";
					}
			}
            if (madv.Text != "")
            {
                i_madv = 0;
                DataRow r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
                if (r == null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"), d.Msg);
                    madv.Focus();
                    return;
                }
                i_madv = int.Parse(r["id"].ToString());
            }
            string s_title = (tendv.Text != "") ? tendv.Text.Trim() + ", " : "";            
            if (tu.Text == den.Text) s_title += "Tháng " + tu.Value.ToString() + " năm " + nam.Value.ToString();
            else s_title += "Từ tháng " + tu.Value.ToString() + " đến " + den.Value.ToString() + " năm " + nam.Value.ToString();
			if (manhom.SelectedItems.Count>0)
				for(int i=0;i<manhom.Items.Count;i++) if (manhom.GetItemChecked(i)) s_manhom+=dtnhom.Rows[i]["id"].ToString()+",";
			ds.Clear();
			int y1=int.Parse(nam.Value.ToString()),m1=int.Parse(tu.Value.ToString());
			int y2=int.Parse(nam.Value.ToString()),m2=int.Parse(den.Value.ToString());
			int itu,iden;
			string mmyy=m1.ToString().PadLeft(2,'0')+y1.ToString().Substring(2,2);
			if (d.bMmyy(mmyy))get_tondau(mmyy);
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{						
						get_nhap(mmyy);
						get_xuat(mmyy);
					}
				}
			}
			dsxml.Clear();
			dsxml.Merge(ds.Tables[0].Select("true","stt,tennhom,ten"));
			Cursor=Cursors.Default;
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\d_nxt.xml", XmlWriteMode.WriteSchema);
            }
			if (tt==5) s_tenkho=d.Thongso("d_thongso","kho");
			else if (tt==7) tt=5;
			string tenfile="d_nxt_kho"+tt.ToString().Trim()+".rpt";
			if (dsxml.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
			else
			{
				frmReport f1=new frmReport(d,dsxml.Tables[0],i_userid,tenfile,s_tenkho,s_title,"","","","","","","","");
				f1.ShowDialog(this);
			}
		}
        private void tendv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listNX.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listNX.Visible) listNX.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void tendv_TextChanged(object sender, System.EventArgs e)
        {
            Filter_dmnx(tendv.Text);
            listNX.BrowseToDmnx(tendv, madv, manhom);
        }

        private void tendv_Validated(object sender, System.EventArgs e)
        {
            if (!listNX.Focused) listNX.Hide();
            if (tendv.Text != "" && madv.Text == "")
            {
                DataRow r = d.getrowbyid(dtdmnx, "ten='" + tendv.Text + "'");
                if (r != null) madv.Text = r["ma"].ToString();
            }
        }
        private void madv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void madv_Validated(object sender, System.EventArgs e)
        {
            if (madv.Text != "")
            {
                DataRow r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
                if (r != null) tendv.Text = r["ten"].ToString();
            }
        }
        private void Filter_dmnx(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listNX.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }
	}
}
