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
	/// Summary description for frmChonindmbd.
	/// </summary>
	public class frmChonindmbd : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox maloai;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Data.DataTable dtnhom=new System.Data.DataTable();
		private System.Data.DataTable dtloai=new System.Data.DataTable();
		private	DataSet ds=new DataSet();
		private bool bClear=true;
        private int i_loai, i_bhyt, i_thietyeu, i_tonkho, i_tt, i_nhomkho, i_sunghiep, i_dongiale, i_userid=0;
		private System.Windows.Forms.CheckBox bhyt;
		private System.Windows.Forms.CheckBox thietyeu;
		private System.Windows.Forms.CheckBox tonkho;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox stt;
		private string sql,s_mmyy,s_manhom,user;
		private AccessData d;
		private System.Windows.Forms.CheckBox sunghiep;
		private System.Windows.Forms.Button butExcel;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		private System.Windows.Forms.CheckedListBox manhom;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChonindmbd(AccessData acc,System.Data.DataTable nhom,System.Data.DataTable loai,string mmyy,int nhomkho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			dtnhom=nhom;dtloai=loai;d=acc;s_mmyy=mmyy;i_nhomkho=nhomkho;
			tonkho.Text="Còn tồn kho tháng "+mmyy.Substring(0,2)+"/20"+mmyy.Substring(2,2);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonindmbd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maloai = new System.Windows.Forms.ComboBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.bhyt = new System.Windows.Forms.CheckBox();
            this.thietyeu = new System.Windows.Forms.CheckBox();
            this.tonkho = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.ComboBox();
            this.sunghiep = new System.Windows.Forms.CheckBox();
            this.butExcel = new System.Windows.Forms.Button();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhóm :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-8, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maloai
            // 
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(48, 94);
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(288, 21);
            this.maloai.TabIndex = 3;
            this.maloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manhom_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(77, 198);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 10;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(217, 198);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 12;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // bhyt
            // 
            this.bhyt.Location = new System.Drawing.Point(48, 141);
            this.bhyt.Name = "bhyt";
            this.bhyt.Size = new System.Drawing.Size(56, 24);
            this.bhyt.TabIndex = 6;
            this.bhyt.Text = "BHYT";
            this.bhyt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manhom_KeyDown);
            // 
            // thietyeu
            // 
            this.thietyeu.BackColor = System.Drawing.SystemColors.Control;
            this.thietyeu.Location = new System.Drawing.Point(104, 141);
            this.thietyeu.Name = "thietyeu";
            this.thietyeu.Size = new System.Drawing.Size(72, 24);
            this.thietyeu.TabIndex = 7;
            this.thietyeu.Text = "Thiết yếu";
            this.thietyeu.UseVisualStyleBackColor = false;
            this.thietyeu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manhom_KeyDown);
            // 
            // tonkho
            // 
            this.tonkho.Location = new System.Drawing.Point(176, 141);
            this.tonkho.Name = "tonkho";
            this.tonkho.Size = new System.Drawing.Size(160, 24);
            this.tonkho.TabIndex = 8;
            this.tonkho.Text = "Còn tồn kho";
            this.tonkho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manhom_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thứ tự :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Items.AddRange(new object[] {
            "Tên",
            "Nhóm,phân loại,tên biệt dược",
            "Nhóm,phân loại,tên hoạt chất",
            "Số thứ tự"});
            this.stt.Location = new System.Drawing.Point(48, 118);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(288, 21);
            this.stt.TabIndex = 5;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manhom_KeyDown);
            // 
            // sunghiep
            // 
            this.sunghiep.Location = new System.Drawing.Point(48, 162);
            this.sunghiep.Name = "sunghiep";
            this.sunghiep.Size = new System.Drawing.Size(80, 24);
            this.sunghiep.TabIndex = 9;
            this.sunghiep.Text = "Sự nghiệp";
            this.sunghiep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manhom_KeyDown);
            // 
            // butExcel
            // 
            this.butExcel.Image = global::Duoc.Properties.Resources.Export;
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(147, 198);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(70, 25);
            this.butExcel.TabIndex = 11;
            this.butExcel.Text = "    &Excel";
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(48, 8);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(288, 84);
            this.manhom.TabIndex = 1;
            // 
            // frmChonindmbd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(344, 234);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.sunghiep);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tonkho);
            this.Controls.Add(this.thietyeu);
            this.Controls.Add(this.bhyt);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.maloai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonindmbd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In danh mục";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmChonindmbd_MouseMove);
            this.Load += new System.EventHandler(this.frmChonindmbd_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void manhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
		private void get_data()
		{
			s_manhom="";
			for(int i=0;i<manhom.Items.Count;i++)
				if (manhom.GetItemChecked(i)) s_manhom+=dtnhom.Rows[i]["id"].ToString().Trim()+",";
			i_loai=(maloai.SelectedIndex!=-1)?int.Parse(maloai.SelectedValue.ToString()):0;
			i_tt=stt.SelectedIndex;
			i_bhyt=(bhyt.Checked)?1:0;
			i_thietyeu=(thietyeu.Checked)?1:0;
			i_sunghiep=(sunghiep.Checked)?1:0;
			i_tonkho=(tonkho.Checked)?1:0;
			sql="select a.ma,a.tenhc,trim(a.ten)||' '||a.hamluong as tenbd,a.dang as dvt,";
			sql+="b.ten as tenhang,c.ten as tennuoc,nullif(d.ten,' ') as tennx,a.dongia";
			sql+=" from "+user+".d_dmbd a inner join "+user+".d_dmhang b on a.mahang=b.id inner join "+user+".d_dmnuoc c on a.manuoc=c.id left join "+user+".d_dmnx d on a.madv=d.id";
			sql+=" where a.nhom="+i_nhomkho;
			if (i_loai!=0) sql+=" and a.maloai="+i_loai;
			if (i_bhyt!=0) sql+=" and a.bhyt<>0";
			if (i_thietyeu!=0) sql+=" and a.thietyeu=1";
			if (i_sunghiep!=0) sql+=" and a.sunghiep=1";
			sql+=" order by a.ten";
			ds=d.get_data(sql);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_manhom="";
			for(int i=0;i<manhom.Items.Count;i++)
				if (manhom.GetItemChecked(i)) s_manhom+=dtnhom.Rows[i]["id"].ToString().Trim()+",";
			i_loai=(maloai.SelectedIndex!=-1)?int.Parse(maloai.SelectedValue.ToString()):0;
			i_tt=stt.SelectedIndex;
			i_bhyt=(bhyt.Checked)?1:0;
			i_thietyeu=(thietyeu.Checked)?1:0;
			i_sunghiep=(sunghiep.Checked)?1:0;
			i_tonkho=(tonkho.Checked)?1:0;
			string tenfile="d_dmbd_ten.rpt";
			sql="select a.*,trim(a.ten)||' '||a.hamluong as tenbd,b.ten as tennhom,c.ten as tenloai,d.ten as tenhang,e.ten as tennuoc,f.ten as tenbo,"+
                "g.ten as nhomkt,b.stt as ttnhom,c.stt as ttloai";
			sql+=" from "+user+".d_dmbd a inner join "+user+".d_dmnhom b on a.manhom=b.id inner join "+user+".d_dmloai c on a.maloai=c.id inner join "+user+".d_dmhang d on a.mahang=d.id inner join "+user+".d_dmnuoc e on a.manuoc=e.id left join "+user+".d_nhombo f on a.nhombo=f.id left join "+user+".d_dmnhomkt g on a.sotk=g.id";
			sql+=" where a.nhom="+i_nhomkho;
			if (s_manhom!="") sql+=" and a.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (i_loai!=0) sql+=" and a.maloai="+i_loai;
			if (i_bhyt!=0) sql+=" and a.bhyt<>0";
			if (i_thietyeu!=0) sql+=" and a.thietyeu=1";
			if (i_sunghiep!=0) sql+=" and a.sunghiep=1";
			if (i_tonkho!=0) sql+=" and a.id in (select mabd from "+user+s_mmyy+".d_tonkhoth where tondau+slnhap-slxuat>0)";//gam 14/11/2011
			if (i_tt==0) sql+=" order by a.ten";
			else if (i_tt==3) sql+=" order by a.stt";
			else
			{
				sql+=" order by b.stt,c.stt";
				if (i_tt==1) sql+=",a.ten";
				else sql+=",a.tenhc,a.ten";
				tenfile="d_dmbd_nhom.rpt";
			}
			string tit="DANH MỤC THUỐC ";
			if (i_thietyeu!=0) tit+=" CHỦ YẾU";
			if (i_bhyt!=0) tit+=" BHYT";
			if (i_sunghiep!=0) tit+=" SỰ NGHIỆP";
			tit+=" SỬ DỤNG TRONG BỆNH VIỆN";
			ds=d.get_data(sql);
			if (ds.Tables[0].Rows.Count>0)
			{
                ds.WriteXml("..//..//dataxml//dmbd.xml",XmlWriteMode.WriteSchema);
				frmReport f=new frmReport(d,ds.Tables[0], i_userid,tenfile,tit,"","","","","","","","","");
				f.ShowDialog();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void frmChonindmbd_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			i_dongiale=d.d_dongia_le(i_nhomkho);
            manhom.DataSource = dtnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";

			maloai.DisplayMember="TEN";
			maloai.ValueMember="ID";
			maloai.DataSource=dtloai;
			stt.SelectedIndex=0;
		}

		private void butExcel_Click(object sender, System.EventArgs e)
		{
			get_data();
			DataSet tmp=new DataSet();
			tmp=ds.Copy();
			tmp.Clear();
			tmp.Merge(ds.Tables[0].Select("true","tenbd"));
			if (tmp.Tables[0].Rows.Count>0)
			{
				d.check_process_Excel();
				string tenfile=d.Export_Excel(tmp,"dmthuoc");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				for(int i=0;i<8;i++) osheet.Cells[1,i+1]=get_ten(i);
				oxl.ActiveWindow.DisplayGridlines=true;
				oxl.ActiveWindow.DisplayZeros=false;
				int row=tmp.Tables[0].Rows.Count+1;
				osheet.get_Range(d.getIndex(0)+"1",d.getIndex(tmp.Tables[0].Columns.Count-1)+row.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				osheet.PageSetup.CenterFooter="Trang : &P/&N";
				oxl.Visible=true;		
			}
		}

		private string get_ten(int i)
		{
			string [] map={"Mã","Hoạt chất","Tên thuốc - hàm lượng","ĐVT","Hãng sản xuất","Nước sản xuất","Nhà cung cấp","Đơn gía"};
			return map[i];
		}

		private void frmChonindmbd_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				maloai.SelectedIndex=-1;
				bClear=false;
			}
		}
	}
}
