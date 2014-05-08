using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibDuoc;
using Excel;
using System.Runtime.InteropServices;
using System.Reflection;
namespace Duoc
{
	/// <summary>
	/// Summary description for frmIndmbd.
	/// </summary>
	public class frmIndmbd : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		AccessData d=new AccessData();		
		System.Data.DataTable dtnhombd,dtdmkho, dtngay;
		DataSet ds; 
		DataRow [] dr;
		string s_mmyy="", s_tu="", s_den="", s_yy="",s_makho="", s_kho="",s_nhombd="",tenfile="";
        int i_nhom, i_userid=0;
		private DataColumn dc;
		//
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		//
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.CheckedListBox nhombd;
		private System.Windows.Forms.RadioButton opt1;
		private System.Windows.Forms.RadioButton opt2;
		private System.Windows.Forms.RadioButton opt3;
		private System.Windows.Forms.RadioButton opt4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown yy;
		private System.Windows.Forms.RadioButton opt5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIndmbd(int nhom,string makho, string mmyy, int _userid)
		{
			InitializeComponent();
			i_nhom=nhom;
			den.Value=tu.Value=decimal.Parse(mmyy.Substring(0,2));
			yy.Value=yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
			s_makho=makho;
            i_userid = _userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndmbd));
            this.butXem = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.opt1 = new System.Windows.Forms.RadioButton();
            this.opt2 = new System.Windows.Forms.RadioButton();
            this.opt3 = new System.Windows.Forms.RadioButton();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.nhombd = new System.Windows.Forms.CheckedListBox();
            this.opt4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yy = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.opt5 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.SuspendLayout();
            // 
            // butXem
            // 
            this.butXem.Image = global::Duoc.Properties.Resources.search;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(72, 336);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 7;
            this.butXem.Text = "    &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(142, 336);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // opt1
            // 
            this.opt1.Checked = true;
            this.opt1.Location = new System.Drawing.Point(24, 64);
            this.opt1.Name = "opt1";
            this.opt1.Size = new System.Drawing.Size(248, 24);
            this.opt1.TabIndex = 1;
            this.opt1.TabStop = true;
            this.opt1.Text = "Theo tên thương mại";
            // 
            // opt2
            // 
            this.opt2.Location = new System.Drawing.Point(24, 88);
            this.opt2.Name = "opt2";
            this.opt2.Size = new System.Drawing.Size(248, 24);
            this.opt2.TabIndex = 2;
            this.opt2.Text = "Theo tên gốc - tên hoạt chất";
            // 
            // opt3
            // 
            this.opt3.Location = new System.Drawing.Point(24, 112);
            this.opt3.Name = "opt3";
            this.opt3.Size = new System.Drawing.Size(248, 24);
            this.opt3.TabIndex = 3;
            this.opt3.Text = "Theo dõi biến động giá thuốc - Ngày";
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(16, 192);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(256, 132);
            this.kho.TabIndex = 5;
            // 
            // nhombd
            // 
            this.nhombd.CheckOnClick = true;
            this.nhombd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhombd.Location = new System.Drawing.Point(280, 8);
            this.nhombd.Name = "nhombd";
            this.nhombd.Size = new System.Drawing.Size(208, 356);
            this.nhombd.TabIndex = 6;
            // 
            // opt4
            // 
            this.opt4.Location = new System.Drawing.Point(24, 136);
            this.opt4.Name = "opt4";
            this.opt4.Size = new System.Drawing.Size(248, 24);
            this.opt4.TabIndex = 4;
            this.opt4.Text = "Theo dõi giá thuốc -Tháng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.den);
            this.groupBox1.Controls.Add(this.yyyy);
            this.groupBox1.Controls.Add(this.tu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // yy
            // 
            this.yy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yy.Location = new System.Drawing.Point(170, 12);
            this.yy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yy.Name = "yy";
            this.yy.Size = new System.Drawing.Size(48, 21);
            this.yy.TabIndex = 3;
            this.yy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yy_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(138, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "năm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(33, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến tháng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(96, 36);
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
            this.den.TabIndex = 5;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(170, 36);
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
            this.yyyy.TabIndex = 7;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yyyy_KeyDown);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(96, 12);
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
            this.label2.Location = new System.Drawing.Point(138, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // opt5
            // 
            this.opt5.Location = new System.Drawing.Point(24, 160);
            this.opt5.Name = "opt5";
            this.opt5.Size = new System.Drawing.Size(240, 24);
            this.opt5.TabIndex = 9;
            this.opt5.Text = "Theo dõi biến động giá thuốc - Tháng";
            // 
            // frmIndmbd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(496, 375);
            this.Controls.Add(this.opt5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.opt4);
            this.Controls.Add(this.nhombd);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.opt3);
            this.Controls.Add(this.opt2);
            this.Controls.Add(this.opt1);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.butKetthuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmIndmbd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In danh mục hàng hóa";
            this.Load += new System.EventHandler(this.frmIndmbd_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void butXem_Click(object sender, System.EventArgs e)
		{
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_tu=yy.Value.ToString().PadLeft(4,'0').Substring(2)+tu.Value.ToString().PadLeft(2,'0');
			s_den=yyyy.Value.ToString().PadLeft(4,'0').Substring(2)+den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_kho="";			
			for(int i=0;i<kho.Items.Count;i++)
				if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";						
			if(s_kho=="")s_kho=s_makho+",";
			s_nhombd="";
			for(int i=0;i<nhombd.Items.Count;i++)
				if (nhombd.GetItemChecked(i)) s_nhombd+=dtnhombd.Rows[i]["id"].ToString()+",";
			ds=new DataSet();
			if(opt1.Checked==true || opt2.Checked==true)
				ds.Tables.Add(get_dmbd());
			else if(opt5.Checked)
			{
				get_gia();
				exp_excel(false,true);
				return;
			}
			else
			{				
				get_biendonggia();
				exp_excel(false,false);
				return;
			}
			string s_tenkho="";
			string s_tennhom="";
			string s_rpt=(opt1.Checked)?"d_dmbd_nt.rpt":"d_dmbd_nt1.rpt";
			s_rpt=(opt3.Checked)?"d_dmbd_gia.rpt":s_rpt;//report the doi gia
			if(s_rpt!="")
			{
				frmReport f=new frmReport(d,ds.Tables[0], i_userid,s_rpt,s_tenkho,s_tennhom,"","","","","","","","");
				f.ShowDialog();
			}
			else
			{
				MessageBox.Show(
lan.Change_language_MessageText("Đề nghị chọn lại!"));
			}
		}
		private System.Data.DataTable get_dmbd()
		{
			//string sql="select distinct a.ma, (a.ten||' '||a.hamluong) tenbd, a.tenhc, a.dang, c.losx, c.handung, d.ten nhacc, e.ten nuocsx, f.ten hangsx, decode(a.manuoc,0,1,e.loai) noingoai, g.ten nhom, a.manhom, a.manuoc, a.mahang "+
            string sql = "select distinct a.ma, (a.ten||' '||a.hamluong) tenbd, a.tenhc, a.dang, c.losx, c.handung, d.ten nhacc, e.ten nuocsx, f.ten hangsx, (case when a.manuoc=0 then  1 else e.loai end) as noingoai, g.ten nhom, a.manhom, a.manuoc, a.mahang " +
				" from d_dmbd a, d_nhapll b, d_nhapct c, d_dmnx d, d_dmnuoc e, d_dmhang f, d_dmnhom g "+
				" where b.id=c.id and c.mabd=a.id and b.madv=d.id and a.manuoc=e.id and a.mahang=f.id and a.manhom=g.id "+
				" and to_number(substr(b.mmyy,3,2)||substr(b.mmyy,1,2))>=to_number('"+s_tu+"') and to_number(substr(b.mmyy,3,2)||substr(b.mmyy,1,2))<=to_number('"+s_den+"')";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";			
			if (s_nhombd!="") sql+=" and a.manhom in ("+s_nhombd.Substring(0,s_nhombd.Length-1)+")";
			if(opt1.Checked)//sort theo ten thuong mai
				sql+=" order by a.manhom, tenbd";
			else if(opt2.Checked)//sort theo ten hoat chat
				sql+=" order by a.manhom, a.tenhc";
			System.Data.DataTable dt=d.get_data(sql).Tables[0];
			return dt;
		}

		private void get_biendonggia()
		{
			Tao_dataset();
			s_tu=yy.Value.ToString().PadLeft(4,'0').Substring(2)+tu.Value.ToString().PadLeft(2,'0');
			s_den=yyyy.Value.ToString().PadLeft(4,'0').Substring(2)+den.Value.ToString().PadLeft(2,'0');
			bool blnngay=(opt3.Checked)?true:false;
			string sql="";
			if(blnngay==true)
			{
				//sql="select distinct b.mabd, a.ma, a.ten,a.hamluong, a.tenhc,a.dang, d.ten nuocsx, decode(a.manuoc,0,1,d.loai) noingoai, c.ten nhom, a.manhom, a.manuoc, b.dongia, b.ngayud, b.ngay, to_char(b.ngay,'ddmmyy') ng "+
                sql = "select distinct b.mabd, a.ma, a.ten,a.hamluong, a.tenhc,a.dang, d.ten nuocsx, ( case when a.manuoc=0 then 1 else d.loai end) noingoai, c.ten nhom, a.manhom, a.manuoc, b.dongia, b.ngayud, b.ngay, to_char(b.ngay,'ddmmyy') ng " +
					" from d_dmbd a, d_theodoigia b, d_dmnhom c, d_dmnuoc d "+
					" where b.mabd=a.id and a.manhom=c.id and a.manuoc=d.id and "+
					" to_number(substr(to_char(b.ngay,'mmyy'),3,2)||substr(to_char(b.ngay,'mmyy'),1,2))>=to_number('"+s_tu+"') and to_number(substr(to_char(b.ngay,'mmyy'),3,2)||substr(to_char(b.ngay,'mmyy'),1,2))<=to_number('"+s_den+"')";
				if (s_nhombd!="") sql+=" and a.manhom in ("+s_nhombd.Substring(0,s_nhombd.Length-1)+")";					
				sql+=" order by a.manhom,tenhc, ten, to_char(b.ngay,'yyyy'),to_char(b.ngay,'mm'),to_char(b.ngay,'dd')";
			}
			else
			{
				//sql="select distinct b.mabd, a.ma, a.ten,a.hamluong, a.tenhc,a.dang, d.ten nuocsx, decode(a.manuoc,0,1,d.loai) noingoai, c.ten nhom, a.manhom, a.manuoc, b.dongia, to_char(b.ngayud,'mm/yyyy') ngayud, to_char(b.ngay,'mm/yyyy') ngay, to_char(b.ngay,'mmyy') ng "+
                sql = "select distinct b.mabd, a.ma, a.ten,a.hamluong, a.tenhc,a.dang, d.ten nuocsx, (case when a.manuoc=0 then 1 else d.loai end) noingoai, c.ten nhom, a.manhom, a.manuoc, b.dongia, to_char(b.ngayud,'mm/yyyy') ngayud, to_char(b.ngay,'mm/yyyy') ngay, to_char(b.ngay,'mmyy') ng " +
					" from d_dmbd a, d_theodoigia b, d_dmnhom c, d_dmnuoc d "+
					" where b.mabd=a.id and a.manhom=c.id and a.manuoc=d.id and "+
					" to_number(substr(to_char(b.ngay,'mmyy'),3,2)||substr(to_char(b.ngay,'mmyy'),1,2))>=to_number('"+s_tu+"') and to_number(substr(to_char(b.ngay,'mmyy'),3,2)||substr(to_char(b.ngay,'mmyy'),1,2))<=to_number('"+s_den+"')";
				if (s_nhombd!="") sql+=" and a.manhom in ("+s_nhombd.Substring(0,s_nhombd.Length-1)+")";					
				sql+=" order by a.manhom,tenhc, ten,to_char(b.ngay,'mmyy')";
			}
			System.Data.DataTable dt=d.get_data(sql).Tables[0];
			DataRow r2;
			foreach(DataRow r in dt.Rows)
			{
				DataRow r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));				
				if ( r1 == null )
				{					
					r2 = ds.Tables[0].NewRow();
					r2["mabd"]=r["mabd"].ToString();
					r2["stt"]=d.get_stt(ds.Tables[0]);
					r2["ma"]=r["ma"].ToString();
					string s_tenbd=(r["ten"].ToString().Trim()==r["tenhc"].ToString().Trim())?r["ten"].ToString()+" "+r["hamluong"].ToString():r["ten"].ToString()+" ["+r["tenhc"].ToString().Trim()+"] "+r["hamluong"].ToString();
					r2["ten"]=s_tenbd;
					r2["dang"]=r["dang"].ToString();
					foreach(DataRow r4 in dtngay.Rows) r2["soluong_"+r4["ngay"].ToString().Trim()]=0;
					r2["soluong_"+r["ng"].ToString().Trim()]=decimal.Parse(r["dongia"].ToString());					
					ds.Tables[0].Rows.Add(r2);					
				}				
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["soluong_"+r["ng"].ToString().Trim()]=decimal.Parse(r["dongia"].ToString());					
				}
			}
			ds.AcceptChanges();
		}
		private void get_gia()
		{
			ds=new DataSet();
			ds=create_dataset();
			s_tu=tu.Value.ToString().PadLeft(2,'0')+yy.Value.ToString().PadLeft(4,'0').Substring(2);
			s_den=den.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2);
			string sql="select distinct b.mabd, a.ma, a.ten,a.hamluong, a.tenhc,a.dang,e.dongia giatruoc,f.dongia giasau,f.dongia-e.dongia chenhlech"+
					" from d_dmbd a, d_theodoigia b,"+
					" (select mabd,dongia from d_theodoigia where to_char(ngay,'mmyy')='"+s_tu+"') e,"+
					" (select mabd,dongia from d_theodoigia where to_char(ngay,'mmyy')='"+s_den+"') f"+
					" where b.mabd=a.id and e.mabd=b.mabd and f.mabd=b.mabd";
				if (s_nhombd!="") sql+=" and a.manhom in ("+s_nhombd.Substring(0,s_nhombd.Length-1)+")";					
				sql+=" order by tenhc,ten";
			System.Data.DataTable dt=d.get_data(sql).Tables[0];
			DataRow r2;
			foreach(DataRow r in dt.Rows)
			{
				DataRow r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));				
				if ( r1 == null )
				{					
					r2 = ds.Tables[0].NewRow();
					r2["mabd"]=r["mabd"].ToString();
					r2["stt"]=d.get_stt(ds.Tables[0]);
					r2["ma"]=r["ma"].ToString();
					string s_tenbd=(r["ten"].ToString().Trim()==r["tenhc"].ToString().Trim())?r["ten"].ToString()+" "+r["hamluong"].ToString():r["ten"].ToString()+" ["+r["tenhc"].ToString().Trim()+"] "+r["hamluong"].ToString();
					r2["ten"]=s_tenbd;
					r2["dang"]=r["dang"].ToString();
					r2[s_tu]=0;r2[s_den]=0;
					r2[s_tu]=decimal.Parse(r["giatruoc"].ToString());
					if(s_tu!=s_den)
					{
						r2[s_den]=decimal.Parse(r["giasau"].ToString());
						r2["chenhlech"]=decimal.Parse(r["chenhlech"].ToString());
					}
					ds.Tables[0].Rows.Add(r2);					
				}				
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0][s_tu]=decimal.Parse(r["giatruoc"].ToString());
					if(s_tu!=s_den)
					{
						dr[0][s_den]=decimal.Parse(r["giasau"].ToString());
						dr[0]["chenhlech"]=decimal.Parse(r["chenhlech"].ToString());
					}
				}
			}
			ds.AcceptChanges();
		}
		DataSet create_dataset()
		{
			string d_tu="",d_den="";
			d_tu=tu.Value.ToString().PadLeft(2,'0')+yy.Value.ToString().PadLeft(4,'0').Substring(2);
			d_den=den.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2);
			DataSet tmp=new DataSet();
			System.Data.DataTable dttmp=new System.Data.DataTable();
			dttmp.Columns.Add("stt",typeof(int));
			dttmp.Columns.Add("mabd",typeof(decimal));
			dttmp.Columns.Add("ma",typeof(string));
			dttmp.Columns.Add("ten",typeof(string));
			dttmp.Columns.Add("dang",typeof(string));
			dttmp.Columns.Add(d_tu,typeof(string));
			if(d_den!=d_tu)
			{
				dttmp.Columns.Add(d_den,typeof(string));
				dttmp.Columns.Add("chenhlech",typeof(string));
			}
			dttmp.AcceptChanges();
			tmp.Tables.Add(dttmp);
			tmp.AcceptChanges();
			return tmp;
		}
		private void frmIndmbd_Load(object sender, System.EventArgs e)
		{
			string s_sql="select * from d_dmkho where nhom="+i_nhom;
			s_makho=(s_makho!="")?s_makho.Substring(0,s_makho.Length-1):"";
			s_sql+=(s_makho!="")?" and id in ("+s_makho+")":"";
			s_sql+=" order by stt";
			dtdmkho=d.get_data(s_sql).Tables[0];
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			kho.DataSource=dtdmkho;
			dtnhombd=d.get_data("select * from d_dmnhom").Tables[0];
			nhombd.DisplayMember="TEN";
			nhombd.ValueMember="ID";
			nhombd.DataSource=dtnhombd;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private System.Data.DataTable Get_ngaydoi(string s_tu, string s_den, string s_nam, bool blnngay)
		{
			System.Data.DataTable ldt;
			string sql="";
			if(blnngay)
				sql="select distinct to_char(ngay,'dd/mm/yy') ngaydoi, to_char(ngay,'ddmmyy') ngay from d_theodoigia a, d_dmbd b where a.mabd=b.id and to_number(substr(to_char(ngay,'mmyy'),3,2)||substr(to_char(ngay,'mmyy'),1,2))>=to_number('"+s_tu+"') and to_number(substr(to_char(ngay,'mmyy'),3,2)||substr(to_char(ngay,'mmyy'),1,2))<=to_number('"+s_den+"')";
			else
				sql="select distinct to_char(ngay,'mm/yy') ngaydoi, to_char(ngay,'mmyy') ngay from d_theodoigia a, d_dmbd b where a.mabd=b.id and to_number(substr(to_char(ngay,'mmyy'),3,2)||substr(to_char(ngay,'mmyy'),1,2))>=to_number('"+s_tu+"') and to_number(substr(to_char(ngay,'mmyy'),3,2)||substr(to_char(ngay,'mmyy'),1,2))<=to_number('"+s_den+"')";
			if (s_nhombd!="") sql+=" and b.manhom in ("+s_nhombd.Substring(0,s_nhombd.Length-1)+")";
			ldt=d.get_data(sql).Tables[0];
			return ldt;
		}
		private void Tao_dataset()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_theodoigia.xml");
			string s_tu=yy.Value.ToString().PadLeft(4,'0').Substring(2)+tu.Value.ToString().PadLeft(2,'0');
			string s_den=yyyy.Value.ToString().PadLeft(4,'0').Substring(2)+den.Value.ToString().PadLeft(2,'0');
			string s_nam=yyyy.Value.ToString();
			bool blnngay=(opt3.Checked)?true:false;
			dtngay=Get_ngaydoi(s_tu,s_den,s_nam,blnngay);
			foreach(DataRow r in dtngay.Rows)
			{
				dc=new DataColumn();
				dc.ColumnName="SOLUONG_"+r["ngay"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
		}

		private void exp_excel(bool print,bool biendong)
		{
			try
			{
				int be=3,dong=5,sodong=ds.Tables[0].Rows.Count+5,socot=ds.Tables[0].Columns.Count-2,dongke=sodong-1;
				tenfile=d.Export_Excel(ds,"theodoigia");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				osheet.get_Range(d.getIndex(0)+"1",d.getIndex(0)+"1").EntireColumn.Delete(Missing.Value);
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
				osheet.get_Range(d.getIndex(be)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat="#,##0.000";
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				for(int i=1;i<dong;i++) osheet.Cells[dong-1,i]=get_ten(i-1);
				orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
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
				osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
				s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
				s_tu=tu.Value.ToString().PadLeft(2,'0');
				s_den=den.Value.ToString().PadLeft(2,'0');
				s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
				osheet.Cells[1,4]="THEO DÕI BIẾN ĐỘNG GIÁ";				
				osheet.Cells[2,4]=(tu.Value==den.Value && yy.Value==yyyy.Value)?"Tháng : "+s_tu+"/"+yyyy.Value.ToString():"Từ tháng :"+s_tu+"/"+yy.Value.ToString()+" đến tháng :"+s_den+"/"+yyyy.Value.ToString();			
				orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-1)+"2");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size=12;
				orange.Font.Bold=true;
				osheet.get_Range(d.getIndex(4)+"4",d.getIndex(ds.Tables[0].Columns.Count)+"4").NumberFormat="@";
				osheet.get_Range(d.getIndex(4)+"4",d.getIndex(ds.Tables[0].Columns.Count)+"4").RowHeight=24;
				if(!biendong)
					for(int i=0;i<dtngay.Rows.Count;i++)
						osheet.Cells[dong-1,i+5]=dtngay.Rows[i]["ngaydoi"].ToString();
				else
				{
					osheet.Cells[dong-1,5]=s_tu+"/"+yy.Value.ToString();
					if(s_tu!=s_den)
					{
						osheet.Cells[dong-1,6]=s_den+"/"+yyyy.Value.ToString();
						osheet.Cells[dong-1,7]="Chênh lệch";
					}
				}
				orange=osheet.get_Range(d.getIndex(4)+"5",d.getIndex(socot+1)+sodong.ToString());
				orange.EntireColumn.AutoFit();
				if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
				else oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private string get_ten(int i)
		{
			string []map={"TT","Mã số","Tên","ĐVT"};
			return map[i];
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}");
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}");
		}

		private void yyyy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}");
		}

		private void yy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}");
		}
	}
}
