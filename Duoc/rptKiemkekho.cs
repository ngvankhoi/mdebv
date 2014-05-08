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
	/// Summary description for rptKiemkekho.
	/// </summary>
	public class rptKiemkekho : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom = 0, i_userid = 0;
		private string user,xxx,sql,s_mmyy,s_kho,tenfile,s_tenkho;
		private DataRow r1,r2;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtkho=new DataTable();
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.ComboBox nguon;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.CheckBox chkChitiet;
		private System.Windows.Forms.CheckBox chkAB;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
        private CheckBox chkGianovat;
        private CheckBox chkbh0;
        private CheckBox chkbh100;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptKiemkekho(AccessData acc,int nhom,string kho,string mmyy,string file,string title, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;s_kho=kho;tenfile=file;
			mm.Value=decimal.Parse(mmyy.Substring(0,2));
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
			this.Text=title;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptKiemkekho));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.nguon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.chkChitiet = new System.Windows.Forms.CheckBox();
            this.chkAB = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.chkbh100 = new System.Windows.Forms.CheckBox();
            this.chkbh0 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(162, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(125, 221);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 4;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(195, 221);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(29, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 22;
            this.label12.Text = "Kho :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(199, 4);
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
            this.mm.Location = new System.Drawing.Point(60, 4);
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
            this.nguon.Location = new System.Drawing.Point(60, 129);
            this.nguon.Name = "nguon";
            this.nguon.Size = new System.Drawing.Size(303, 21);
            this.nguon.TabIndex = 3;
            this.nguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nguồn :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(60, 27);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(303, 100);
            this.kho.TabIndex = 2;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // chkChitiet
            // 
            this.chkChitiet.Location = new System.Drawing.Point(62, 153);
            this.chkChitiet.Name = "chkChitiet";
            this.chkChitiet.Size = new System.Drawing.Size(128, 24);
            this.chkChitiet.TabIndex = 25;
            this.chkChitiet.Text = "Chi tiết theo kho";
            this.chkChitiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // chkAB
            // 
            this.chkAB.Location = new System.Drawing.Point(62, 171);
            this.chkAB.Name = "chkAB";
            this.chkAB.Size = new System.Drawing.Size(152, 24);
            this.chkAB.TabIndex = 26;
            this.chkAB.Text = "Theo thứ tự tên thuốc";
            this.chkAB.CheckedChanged += new System.EventHandler(this.chkAB_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(377, 288);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkbh0);
            this.tabPage1.Controls.Add(this.chkbh100);
            this.tabPage1.Controls.Add(this.chkGianovat);
            this.tabPage1.Controls.Add(this.mm);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkAB);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chkChitiet);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.kho);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.nguon);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.yyyy);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(369, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kiểm kê kho";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkGianovat
            // 
            this.chkGianovat.Location = new System.Drawing.Point(235, 153);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(128, 24);
            this.chkGianovat.TabIndex = 27;
            this.chkGianovat.Text = "In theo giá trước VAT";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(369, 246);
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
            this.richTextBox1.Size = new System.Drawing.Size(363, 240);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "+ Kiểm kê tồn kho:\n\t- Chỉ lấy số liệu từ tồn kho chi tiết --> tương đương với men" +
                "u: Tiện ích --> kho --> Chi tiết\n\t";
            // 
            // chkbh100
            // 
            this.chkbh100.Location = new System.Drawing.Point(235, 171);
            this.chkbh100.Name = "chkbh100";
            this.chkbh100.Size = new System.Drawing.Size(152, 24);
            this.chkbh100.TabIndex = 28;
            this.chkbh100.Text = "BHYT chi trả";
            this.chkbh100.CheckedChanged += new System.EventHandler(this.chkbh100_CheckedChanged);
            // 
            // chkbh0
            // 
            this.chkbh0.Location = new System.Drawing.Point(235, 190);
            this.chkbh0.Name = "chkbh0";
            this.chkbh0.Size = new System.Drawing.Size(152, 24);
            this.chkbh0.TabIndex = 29;
            this.chkbh0.Text = "BHYT không chi trả";
            this.chkbh0.CheckedChanged += new System.EventHandler(this.chkbh0_CheckedChanged);
            // 
            // rptKiemkekho
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(377, 288);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptKiemkekho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu kiểm kê kho";
            this.Load += new System.EventHandler(this.rptKiemkekho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptKiemkekho_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
			//Nguon			
			nguon.DisplayMember="TEN";
			nguon.ValueMember="ID";
            sql = "select * from " + user + ".d_dmnguon where nhom=" + i_nhom;			
			sql+=" order by stt";
			nguon.DataSource=d.get_data(sql).Tables[0];
			nguon.Enabled=d.bQuanlynguon(i_nhom);
			//
            sql = "select a.*,b.ten as tenhang,c.ten as tennuoc,d.stt as sttnn,d.ten as noingoai from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnuoc c," + user + ".d_nhomhang d where a.mahang=b.id and a.manuoc=c.id and b.loai=d.id and a.nhom=" + i_nhom + " order by a.id";
			dt=d.get_data(sql).Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_kiemkekho.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_kiemkekho.xml");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			ds.Clear();
			s_kho="";s_tenkho="";
			if (kho.SelectedItems.Count>0)
				for(int i=0;i<kho.Items.Count;i++)
					if (kho.GetItemChecked(i))
					{
						s_kho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
						s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+",";
					}
			get_tonkhoct();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
			tenfile=(chkAB.Checked)?"d_bctonkho_abc.rpt":(chkChitiet.Checked)?"d_bctonkho_ct.rpt":"d_bctonkho.rpt";
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,tenfile,"Tháng "+mm.Value.ToString().PadLeft(2,'0')+" năm "+yyyy.Value.ToString(),s_tenkho,nguon.Text,"","","","","","","");
			f.ShowDialog();
		}

		private void get_sort()
		{
			dsxml.Clear();
			sql=(chkAB.Checked)?"sttnn,ten":"tenkho,stt";
			dsxml.Merge(ds.Tables[0].Select("tondau+slnhap-slxuat>0",sql));
		}

		private void get_tonkhoct()
		{
            xxx = user + s_mmyy;
            string s_gia = chkGianovat.Checked ? "e.gianovat" : "e.giamua";
			sql="select ";
			if (chkChitiet.Checked) sql+="d.ten as tenkho,";
			else sql+="'' as tenkho,";
			if (chkAB.Checked) sql+=" e.handung,";
			else sql+="'' as handung,";
            sql += "a.mabd," + s_gia + " as giamua,sum(a.tondau) as tondau,sum(a.slnhap) as slnhap,sum(a.slxuat) as slxuat,sum(a.tondau*" + s_gia + ") as sttondau,sum(a.slnhap*" + s_gia + ") as stnhap,sum(a.slxuat*" + s_gia + ") as stxuat, c.stt, c.ten as nhombd ";
			sql+=" from "+xxx+".d_tonkhoct a,"+user+".d_dmbd b, "+user+".d_dmnhom c,"+user+".d_dmkho d,"+xxx+".d_theodoi e where a.mabd=b.id and b.manhom=c.id and a.makho=d.id and a.stt=e.id";
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if(d.bQuanlynguon(i_nhom))
				if(nguon.SelectedIndex>=0) sql+=" and e.manguon="+nguon.SelectedValue.ToString();
            if (chkbh0.Checked) sql += " and b.bhyt=0 ";
            if (chkbh100.Checked) sql += " and bhyt<>0";
			sql+=" group by ";
			if (chkChitiet.Checked) sql+="d.ten,";
			if (chkAB.Checked) sql+=" e.handung,";
            sql += "a.mabd," + s_gia + ",c.stt,c.ten";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r1!=null)
				{
					r2 = ds.Tables[0].NewRow();
					r2["mabd"]=r["mabd"].ToString();
					r2["ma"]=r1["ma"].ToString();
					r2["ten"]=r1["ten"].ToString().Trim()+" "+r1["hamluong"].ToString();
					r2["tenhc"]=r1["tenhc"].ToString();
					r2["dang"]=r1["dang"].ToString();
					r2["giamua"]=r["giamua"].ToString();
					r2["tondau"]=r["tondau"].ToString();
					r2["sttondau"]=r["sttondau"].ToString();
					r2["slnhap"]=r["slnhap"].ToString();
					r2["stnhap"]=r["stnhap"].ToString();
					r2["slxuat"]=r["slxuat"].ToString();
					r2["stxuat"]=r["stxuat"].ToString();
					//
					r2["sttnn"]=r1["sttnn"].ToString();
					r2["noingoai"]=r1["noingoai"].ToString();
					r2["stt"]=r["stt"].ToString();
					r2["nhombd"]=r["nhombd"].ToString();
					r2["tenkho"]=r["tenkho"].ToString();
					r2["handung"]=r["handung"].ToString();
					r2["tenhang"]=r1["tenhang"].ToString();
					r2["tennuoc"]=r1["tennuoc"].ToString();
					//
					ds.Tables[0].Rows.Add(r2);
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
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void chkAB_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkAB.Checked) chkChitiet.Checked=false;
		}

        private void chkbh100_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbh100.Checked) chkbh0.Checked = false;
        }

        private void chkbh0_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbh0.Checked) chkbh100.Checked = false;
        }
	}
}
