using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibDuoc;
using System.Data;
using System.IO;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmhandung.
	/// </summary>
	public class frmhandung : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		string s_makho="",s_nhombd="",s_mmyy="",s_mm="",s_yy="",user,xxx,sql;
		DataTable dtdmkho;
		DataTable dtnhombd;
		DataSet ds;
        int i_nhom, i_makho, i_userid=0;
		AccessData d=new AccessData();
		//
		private System.Windows.Forms.CheckedListBox nhombd;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox kho;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton optnhom;
		private System.Windows.Forms.RadioButton optloai;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmhandung(int nhom,string skho,string mmyy, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			s_makho=skho;
			i_nhom=nhom;
			s_mmyy=mmyy;
			s_mm=mmyy.Substring(0,2);
			s_yy=mmyy.Substring(2,2);
			tu.Value=int.Parse(s_mm);
			yyyy.Value=int.Parse(s_yy)+2000;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmhandung));
            this.nhombd = new System.Windows.Forms.CheckedListBox();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.optnhom = new System.Windows.Forms.RadioButton();
            this.optloai = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // nhombd
            // 
            this.nhombd.CheckOnClick = true;
            this.nhombd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhombd.Location = new System.Drawing.Point(48, 80);
            this.nhombd.Name = "nhombd";
            this.nhombd.Size = new System.Drawing.Size(240, 228);
            this.nhombd.TabIndex = 21;
            // 
            // butXem
            // 
            this.butXem.Image = global::Duoc.Properties.Resources.search;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(92, 320);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 18;
            this.butXem.Text = "     &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(144, 8);
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
            this.tu.TabIndex = 16;
            this.tu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(162, 320);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 19;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Thuốc hết hạn vào tháng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(240, 8);
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
            this.yyyy.TabIndex = 22;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(208, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kho.Location = new System.Drawing.Point(48, 32);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(240, 21);
            this.kho.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Kho ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // optnhom
            // 
            this.optnhom.Checked = true;
            this.optnhom.Location = new System.Drawing.Point(48, 56);
            this.optnhom.Name = "optnhom";
            this.optnhom.Size = new System.Drawing.Size(96, 24);
            this.optnhom.TabIndex = 27;
            this.optnhom.TabStop = true;
            this.optnhom.Text = "Theo nhóm";
            this.optnhom.CheckedChanged += new System.EventHandler(this.optnhom_CheckedChanged);
            // 
            // optloai
            // 
            this.optloai.Location = new System.Drawing.Point(192, 56);
            this.optloai.Name = "optloai";
            this.optloai.Size = new System.Drawing.Size(96, 24);
            this.optloai.TabIndex = 28;
            this.optloai.Text = "Theo loại";
            // 
            // frmhandung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(312, 365);
            this.Controls.Add(this.optloai);
            this.Controls.Add(this.optnhom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nhombd);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmhandung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hạn dùng";
            this.Load += new System.EventHandler(this.frmhandung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmhandung_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			s_makho=(s_makho!="")?s_makho.Substring(0,s_makho.Length-1):"";
			sql+=(s_makho!="")?" and id in ("+s_makho+")":"";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			kho.DataSource=dtdmkho;
			Load_nhom_loai("d_dmnhom");
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			bool bln=get_dsbd_date();
			if(bln)
			{
				string s_rpt="";
				if(optnhom.Checked==true)
					s_rpt="d_baodong_date.rpt";
				else
					s_rpt="d_baodong_date_pl.rpt";
				//			
				string s_tenkho=kho.Text;
				string s_msg="Thuốc hết hạn vào tháng "+tu.Value.ToString().PadLeft(2,'0')+" năm "+yyyy.Value.ToString();
				string s_title="DANH MỤC THUỐC SẮP HẾT HẠN";
				frmReport f=new frmReport(d,ds.Tables[0], i_userid,s_rpt,s_tenkho,s_msg,"","",s_title,"","","","","");
				f.ShowDialog();
			}
		}
		private bool get_dsbd_date()
		{	
			ds=new DataSet();
			i_makho=int.Parse(kho.SelectedValue.ToString());
			s_mm=tu.Value.ToString().PadLeft(2,'0');			
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_nhombd="";
			bool bln=true;
			for(int i=0;i<nhombd.Items.Count;i++)
				if (nhombd.GetItemChecked(i)) s_nhombd+=dtnhombd.Rows[i]["id"].ToString()+",";
			
			//
            xxx = user + s_mmyy;
			sql="select a.tondau+a.slnhap-a.slxuat as ton, a.mabd,t.handung, t.losx, (b.ten||' '||b.hamluong) as ten, b.tenhc, b.hamluong, b.dang,b.ma, "+
				" b.manhom, b.maloai, c.ten as tennhom, d.ten as tenloai "+
				" from "+xxx+".d_tonkhoct a,"+xxx+".d_theodoi t,"+user+".d_dmbd b,"+user+".d_dmnhom c,"+user+".d_dmloai d "+
				" where a.stt=t.id and a.mabd=b.id and b.manhom=c.id and b.maloai=d.id and a.tondau+a.slnhap-a.slxuat>0 and t.handung !='0000' and t.handung!='????'"+
				" and substr(t.handung,3,2)||substr(t.handung,1,2) <='"+s_yy+s_mm+"' and  a.makho="+i_makho;
			if(s_nhombd!="")
			{
				s_nhombd=(s_nhombd!="")?s_nhombd.Substring(0,s_nhombd.Length-1):"";
				if(optnhom.Checked==true)			
					sql+=" and b.manhom in ("+s_nhombd+")";
				else
					sql+=" and b.maloai in ("+s_nhombd+")";
			}
			ds=d.get_data(sql);
			//
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				bln=false;
			}			
			return bln;
		}

		private void optnhom_CheckedChanged(object sender, System.EventArgs e)
		{
			if(optnhom.Checked==true) //nhom
				Load_nhom_loai("d_dmnhom");
			else
				Load_nhom_loai("d_dmloai");
		}
		private void Load_nhom_loai(string s_tbl)
		{
			dtnhombd=d.get_data("select * from "+user+"."+s_tbl+" where nhom="+i_nhom+" order by stt").Tables[0];
            nhombd.DataSource = dtnhombd;
			nhombd.DisplayMember="TEN";
			nhombd.ValueMember="ID";
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}
	}
}
