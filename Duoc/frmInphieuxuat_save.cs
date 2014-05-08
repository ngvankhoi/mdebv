using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using doiso;

namespace Duoc
{
	/// <summary>
	/// Summary description for Phieu xuat kho.	
	/// </summary>
	public class frmInphieuxuat_save : System.Windows.Forms.Form
	{
		bool bln_noingoai=false;
		//
		DataTable dtkp=new DataTable();
		DataTable dtkn=new DataTable();
		string s_lydoxuat="",s_noinhan="";
		//
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.CheckedListBox phieu;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckedListBox makho;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private string s_makp="",sql,s_nhom,s_makho,s_loai,cont,s_phieu,s_tenkho,tmp_makho;
		private DataRow r1,r2,r3;
		private decimal d_tongcong;
		private DataTable dtkho=new DataTable();
		private DataTable dtmakp=new DataTable();
		private DataTable dtloai=new DataTable();
		private DataTable dtphieu=new DataTable();
		private DataTable dtdmbd=new DataTable();
        private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private Doisototext doiso=new Doisototext();
		private System.Windows.Forms.CheckedListBox khoaphong;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.CheckedListBox loai1;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.CheckBox chkdongia;
		private System.Windows.Forms.CheckedListBox khonhan;
		private System.Windows.Forms.TextBox sotoabhyt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInphieuxuat_save(string smakho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			tmp_makho=smakho;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInphieuxuat_save));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tu = new System.Windows.Forms.DateTimePicker();
			this.den = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.makp = new System.Windows.Forms.ComboBox();
			this.nhom = new System.Windows.Forms.ComboBox();
			this.loai1 = new System.Windows.Forms.CheckedListBox();
			this.phieu = new System.Windows.Forms.CheckedListBox();
			this.label7 = new System.Windows.Forms.Label();
			this.makho = new System.Windows.Forms.CheckedListBox();
			this.butIn = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.khoaphong = new System.Windows.Forms.CheckedListBox();
			this.chkAll = new System.Windows.Forms.CheckBox();
			this.loai = new System.Windows.Forms.ComboBox();
			this.chkdongia = new System.Windows.Forms.CheckBox();
			this.khonhan = new System.Windows.Forms.CheckedListBox();
			this.sotoabhyt = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ ngày :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "đến ngày :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tu
			// 
			this.tu.CustomFormat = "dd/MM/yyyy";
			this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tu.Location = new System.Drawing.Point(64, 8);
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(80, 21);
			this.tu.TabIndex = 0;
			this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			this.tu.Validated += new System.EventHandler(this.tu_Validated);
			// 
			// den
			// 
			this.den.CustomFormat = "dd/MM/yyyy";
			this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.den.Location = new System.Drawing.Point(200, 8);
			this.den.Name = "den";
			this.den.Size = new System.Drawing.Size(80, 21);
			this.den.TabIndex = 1;
			this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
			this.den.Validated += new System.EventHandler(this.den_Validated);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Khoa :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Nhóm :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Loại :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 23);
			this.label6.TabIndex = 7;
			this.label6.Text = "Phiếu :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// makp
			// 
			this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(64, 32);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(216, 21);
			this.makp.TabIndex = 2;
			this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
			this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
			// 
			// nhom
			// 
			this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhom.Location = new System.Drawing.Point(64, 56);
			this.nhom.Name = "nhom";
			this.nhom.Size = new System.Drawing.Size(216, 21);
			this.nhom.TabIndex = 3;
			this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
			this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
			// 
			// loai1
			// 
			this.loai1.CheckOnClick = true;
			this.loai1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loai1.Location = new System.Drawing.Point(280, 104);
			this.loai1.Name = "loai1";
			this.loai1.Size = new System.Drawing.Size(216, 68);
			this.loai1.TabIndex = 8;
			this.loai1.Visible = false;
			this.loai1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// phieu
			// 
			this.phieu.CheckOnClick = true;
			this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.phieu.Location = new System.Drawing.Point(64, 111);
			this.phieu.Name = "phieu";
			this.phieu.Size = new System.Drawing.Size(216, 84);
			this.phieu.TabIndex = 5;
			this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 195);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 23);
			this.label7.TabIndex = 12;
			this.label7.Text = "Kho :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// makho
			// 
			this.makho.CheckOnClick = true;
			this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makho.Location = new System.Drawing.Point(64, 200);
			this.makho.Name = "makho";
			this.makho.Size = new System.Drawing.Size(216, 100);
			this.makho.TabIndex = 6;
			this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(71, 312);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(74, 28);
			this.butIn.TabIndex = 9;
			this.butIn.Text = "&In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(146, 312);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(74, 28);
			this.butKetthuc.TabIndex = 10;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// khoaphong
			// 
			this.khoaphong.CheckOnClick = true;
			this.khoaphong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.khoaphong.Location = new System.Drawing.Point(288, 8);
			this.khoaphong.Name = "khoaphong";
			this.khoaphong.Size = new System.Drawing.Size(288, 292);
			this.khoaphong.TabIndex = 8;
			// 
			// chkAll
			// 
			this.chkAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkAll.Location = new System.Drawing.Point(408, 304);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(168, 24);
			this.chkAll.TabIndex = 12;
			this.chkAll.Text = "Chọn tất cả phòng khám";
			this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
			// 
			// loai
			// 
			this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loai.Location = new System.Drawing.Point(64, 80);
			this.loai.Name = "loai";
			this.loai.Size = new System.Drawing.Size(216, 21);
			this.loai.TabIndex = 4;
			this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
			// 
			// chkdongia
			// 
			this.chkdongia.Checked = true;
			this.chkdongia.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkdongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkdongia.Location = new System.Drawing.Point(288, 304);
			this.chkdongia.Name = "chkdongia";
			this.chkdongia.Size = new System.Drawing.Size(120, 24);
			this.chkdongia.TabIndex = 11;
			this.chkdongia.Text = "Theo đơn giá";
			// 
			// khonhan
			// 
			this.khonhan.CheckOnClick = true;
			this.khonhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.khonhan.Location = new System.Drawing.Point(288, 200);
			this.khonhan.Name = "khonhan";
			this.khonhan.Size = new System.Drawing.Size(288, 100);
			this.khonhan.TabIndex = 13;
			this.khonhan.Visible = false;
			// 
			// sotoabhyt
			// 
			this.sotoabhyt.Location = new System.Drawing.Point(448, 328);
			this.sotoabhyt.Name = "sotoabhyt";
			this.sotoabhyt.Size = new System.Drawing.Size(128, 20);
			this.sotoabhyt.TabIndex = 14;
			this.sotoabhyt.Text = "0";
			// 
			// frmInphieuxuat_save
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(586, 359);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.sotoabhyt,
																		  this.khonhan,
																		  this.chkdongia,
																		  this.loai,
																		  this.chkAll,
																		  this.khoaphong,
																		  this.butKetthuc,
																		  this.butIn,
																		  this.makho,
																		  this.label7,
																		  this.phieu,
																		  this.nhom,
																		  this.makp,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.den,
																		  this.tu,
																		  this.label2,
																		  this.label1,
																		  this.loai1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmInphieuxuat_save";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "In phiếu xuất";
			this.Load += new System.EventHandler(this.frmInphieuxuat_save_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmInphieuxuat_save_Load(object sender, System.EventArgs e)
		{
			ds.ReadXml("..\\..\\..\\xml\\d_pxuatkho.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_pxuatkho.xml");
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			sql="select * from d_duockp";
			if (s_makp!="") sql+=" where makp='"+s_makp+"'";
			else sql+=" where makp is not null";
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
			makp.DataSource=dtmakp;
			makp.SelectedIndex=0;

			loai.DisplayMember="TEN";
			loai.ValueMember="ID";

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";

			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			load_nhom();
			load_makho();				
		}

		private void load_nhom()
		{
			string tmp=(nhom.SelectedIndex>=0)?nhom.SelectedValue.ToString():"0";
			s_nhom="";
			r1=d.getrowbyid(dtmakp,"id="+int.Parse(makp.SelectedValue.ToString()));
			if (r1!=null) s_nhom=r1["nhom"].ToString();
			sql="select * from d_dmnhomkho";
			if (s_nhom!="") sql+=" where id in ("+s_nhom.Substring(0,s_nhom.Length-1)+")";
			sql+=" order by stt";
			nhom.DataSource=d.get_data(sql).Tables[0];
			if(tmp!="0")nhom.SelectedValue=tmp;
			load_makho();
		}

		private void load_makho()
		{
			s_makho=tmp_makho;
			sql=" select * from d_dmkho where nhom="+int.Parse(nhom.SelectedValue.ToString());
			/*
			r1=d.getrowbyid(dtmakp,"id="+int.Parse(makp.SelectedValue.ToString()));
			if (r1!=null) s_makho=r1["makho"].ToString();
			if (s_makho=="") 
			{
				foreach(DataRow r in d.get_data("select kho from d_dmphieu where nhom="+int.Parse(nhom.SelectedValue.ToString())).Tables[0].Rows)
					s_makho+=r["kho"].ToString();
			}
			*/
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
			//
			string tmp=(loai.SelectedIndex>=0)?loai.SelectedValue.ToString():"0";
			dtloai=d.get_data("select * from d_dmphieu where nhom="+int.Parse(nhom.SelectedValue.ToString())+" order by stt").Tables[0];//id in (1,2,3,4) and
			loai.DataSource=dtloai;
			if(tmp!="0")loai.SelectedValue=tmp;
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp)
			{
				load_nhom();
			}
		}

		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nhom)
			{
				load_makho();				
			}
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (!m.ngay(m.StringToDate(tu.Text.Substring(0,10)),DateTime.Now,m.Ngaylv_Ngayht))
			{
				MessageBox.Show("Ngày không hợp lệ so với khai báo hệ thống ("+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
				tu.Focus();
				return;
			}
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (!m.ngay(m.StringToDate(den.Text.Substring(0,10)),DateTime.Now,m.Ngaylv_Ngayht))
			{
				MessageBox.Show("Ngày không hợp lệ so với khai báo hệ thống ("+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
				den.Focus();
				return;
			}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (makp.SelectedIndex==-1 && makp.Items.Count>0) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (nhom.SelectedIndex==-1 && nhom.Items.Count>0) nhom.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==loai)
			{
				s_loai=(loai.SelectedIndex>=0)?loai.SelectedValue.ToString()+",":"";
				visible_khon((s_loai=="8,")?true:false);
				if (s_loai!="")
				{
					s_loai=s_loai.Substring(0,s_loai.Length-1);
					dtphieu=d.get_data("select * from d_loaiphieu where loai in ("+s_loai+")"+" order by stt").Tables[0];
					Load_phongkham();					
				}				
				else dtphieu=d.get_data("select * from d_loaiphieu where id=-1").Tables[0];
				phieu.DataSource=dtphieu;
			}
		}

		private void taotable()
		{
			ds.Clear();
			dtdmbd=d.get_data("select * from d_dmbd where nhom="+int.Parse(nhom.SelectedValue.ToString())).Tables[0];
			cont=" and a.makp="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			s_phieu="";
			for(int i=0;i<phieu.Items.Count;i++)
				if (phieu.GetItemChecked(i)) s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";
			if (s_phieu!="") cont+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			s_loai="";
			s_loai=(loai.SelectedIndex>=0)?loai.SelectedValue.ToString()+",":"";			
			s_makho="";s_tenkho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho!="") cont+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			else for(int i=0;i<makho.Items.Count;i++) s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
			sql="select b.mabd,sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien from d_xuatsdll a,d_thucxuat b where a.id=b.id ";
			sql+=cont;
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_loai.IndexOf("3")!=-1) sql+=" and a.loai<>3";//phieu hoan tra: bo qua
			sql+=" group by b.mabd";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
			}
			//hoantra
			sql="select b.mabd,sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien from d_xuatsdll a,d_thucxuat b where a.id=b.id ";
			sql+=cont;
			sql+=" and a.loai=3";
			sql+=" group by b.mabd";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien"]=-decimal.Parse(r["sotien"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow []dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0)
					{
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())-decimal.Parse(r["soluong"].ToString());
						dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())-decimal.Parse(r["sotien"].ToString());
					}
				}
			}
			sort();
		}

		private void sort()
		{
			dsxml.Clear();
			d_tongcong=0;
			DataRow [] dr=ds.Tables[0].Select("soluong>0","ten");
			for(int i=0;i<dr.Length;i++)
			{
				r1=dsxml.Tables[0].NewRow();
				r1["stt"]=d.get_stt(dsxml.Tables[0]);
				r1["mabd"]=dr[i]["mabd"].ToString();
				r1["ma"]=dr[i]["ma"].ToString();
				r1["ten"]=dr[i]["ten"].ToString();
				r1["dang"]=dr[i]["dang"].ToString();
				r1["soluong"]=dr[i]["soluong"].ToString();
				r1["dongia"]=Math.Round(decimal.Parse(dr[i]["sotien"].ToString())/decimal.Parse(dr[i]["soluong"].ToString()),3);
				r1["sotien"]=dr[i]["sotien"].ToString();
				//
				//
				r1["manguon"]=dr[i]["manguon"].ToString();
				r1["nhomcc"]=dr[i]["nhomcc"].ToString();
				r1["tennguon"]=dr[i]["tennguon"].ToString();
				r1["tennhomcc"]=dr[i]["tennhomcc"].ToString();
				r1["dongia"]=dr[i]["dongia"].ToString();
				//
				r1["tenhc"]=dr[i]["tenhc"].ToString();
				r1["idnhom"]=dr[i]["idnhom"].ToString();
				r1["tennhom"]=dr[i]["tennhom"].ToString();
				r1["idnn"]=dr[i]["idnn"].ToString();
				r1["noingoai"]=dr[i]["noingoai"].ToString();
				r1["mahang"]=dr[i]["mahang"].ToString();
				r1["tenhang"]=dr[i]["tenhang"].ToString();
				r1["manuoc"]=dr[i]["manuoc"].ToString();
				r1["tennuoc"]=dr[i]["tennuoc"].ToString();
				//
				r1["handung"]=dr[i]["handung"].ToString();
				r1["losx"]=dr[i]["losx"].ToString();
				//
				//
				d_tongcong+=decimal.Parse(dr[i]["sotien"].ToString());
				dsxml.Tables[0].Rows.Add(r1);
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			sotoabhyt.Text="";
			if(loai.SelectedIndex<0)return;
			Load_dmbd();
			//
			int i_loaiphieu=int.Parse(loai.SelectedValue.ToString());
			Print_phieuxuat(i_loaiphieu);
			if (dsxml.Tables[0].Rows.Count==0)
			{
				MessageBox.Show("Không có số liệu !",d.Msg);
				tu.Focus();
				return;
			}
			string s_tndn="Ngày "+tu.Text;
			if(tu.Value!=den.Value)s_tndn="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			frmReport f=new frmReport(d,dsxml.Tables[0],"d_pxuatkho.rpt","",s_tndn,"","",s_noinhan,s_lydoxuat,s_tenkho,doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString()),(sotoabhyt.Text.Trim()=="")?"":"Tổng số toa : "+sotoabhyt.Text,"");
			f.ShowDialog();
		}
		#region binh_phieuxuatkho
		private void Print_phieuxuat(int i_loaiphieu)
		{
			sotoabhyt.Text="";
			switch (i_loaiphieu)
			{
				case 5://BHYT
				{
					taotable_xuat_toaBHYT();
					break;
				}
				case 6://xuat ngoai tru
				{
					taotable_xuat_ngoaitru();
					break;
				}				
				case 9://xuat khac
				{
					taotable_xuat_khac();
					break;
				}
				case 10://xuat chuyen kho
				{
					taotable_xuat_chuyenkho();
					break;
				}
				case 11://tang co so tu truc
				{
					taotable_xuat_tangcoso();
					break;
				}
				case 12://bu co so tu truc
				{
					taotable_xuat_bucoso();
					break;
				}
				default:
				{
					taotable_thucxuat();
					break;
				}
			}
		}
		private void Load_phongkham()
		{
			khoaphong.DisplayMember="TENKP";
			khoaphong.ValueMember="MAKP";			
			sql="select makp, tenkp from btdkp_bv where loai=1 order by tenkp";//load danh sach phong kham							
			dtkp=d.get_data(sql).Tables[0];
			khoaphong.DataSource=dtkp;
		}
		private void visible_khon(bool vis)
		{
			khonhan.Visible=vis;
			khoaphong.Height=(vis)?180:292;
			if(vis)load_khoanhan();
			chkAll.Visible=!vis;
		}
		private void load_khoanhan()
		{
			sql="select * from d_dmkho where nhom="+nhom.SelectedValue.ToString()+" order by stt";
			khonhan.DisplayMember="TEN";
			khonhan.ValueMember="ID";
			dtkn=d.get_data(sql).Tables[0].Copy();
			khonhan.DataSource=dtkn;
		}
		private void Load_dmbd()
		{
			//load danh muc biet duoc
			bln_noingoai=d.bNoiNgoai(int.Parse(nhom.SelectedValue.ToString()));
			if(bln_noingoai)
			{
				sql="select a.*, b.ten tennhom, (case when(a.manuoc=0) then substr(c.ten,0,0) else c.ten end) tennuoc, (case when(a.mahang=0) then substr(c.ten,0,0) else d.ten end) tenhang, d.loai idnn, e.ten noingoai";
				sql+=" from d_dmbd a, d_dmnhom b,d_dmnuoc c, d_dmhang d,d_nhomhang e  ";
				sql+=" where a.manhom=b.id and a.manuoc=c.id and a.mahang=d.id and d.loai=e.id and a.nhom="+ int.Parse(nhom.SelectedValue.ToString());
			}
			else
			{
				sql="select a.*, b.ten tennhom, (case when(a.manuoc=0) then substr(c.ten,0,0) else c.ten end) tennuoc, (case when(a.mahang=0) then substr(c.ten,0,0) else d.ten end) tenhang, a.maloai idnn, e.ten noingoai";
				sql+=" from d_dmbd a, d_dmnhom b,d_dmnuoc c, d_dmhang d,d_dmloai e  ";
				sql+=" where a.manhom=b.id and a.manuoc=c.id and a.mahang=d.id and a.maloai=e.id and a.nhom="+ int.Parse(nhom.SelectedValue.ToString());
			}
			dtdmbd=d.get_data(sql).Tables[0];
		}
		private void taotable_thucxuat()
		{
			//Phieu xuat kho: bao cao su dung (co ca xuat tu truc)
			//table: d_xuatsdll+d_thucxuat
			s_lydoxuat="Xuất sử dụng";
			s_noinhan=makho.Text;
			ds.Clear();			
			cont=" and a.makp="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			s_phieu="";
			for(int i=0;i<phieu.Items.Count;i++)
				if (phieu.GetItemChecked(i)) s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";
			if (s_phieu!="") cont+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			s_loai="";
			s_loai=(loai.SelectedIndex>=0)?loai.SelectedValue.ToString()+",":"";			
			s_makho="";s_tenkho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho!="") cont+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			else for(int i=0;i<makho.Items.Count;i++) s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
			sql="select b.mabd,nvl(b.manguon,0) manguon, nvl(b.nhomcc,0) nhomcc, sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien, b.giamua dongia, c.ten tennguon, d.ten tennhomcc, b.handung, b.losx ";
			sql+=" from d_xuatsdll a,d_thucxuat b, "+d.user+".d_dmnguon c, "+d.user+".d_nhomcc d ";
			sql+=" where a.id=b.id and b.manguon=c.id and b.nhomcc=d.id and b.soluong>0";
			sql+=cont;
			if (s_loai!="") sql+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_loai.IndexOf("3")!=-1) sql+=" and a.loai<>3";//phieu hoan tra: bo qua
			sql+=" group by b.mabd,b.manguon, b.nhomcc, b.giamua, c.ten, d.ten, b.handung, b.losx ";
			//
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";					
			DataSet lds=new DataSet();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(lds.Tables.Count<=0)
							lds=d.get_data(mmyy,sql);
						else
							lds.Merge(d.get_data(mmyy,sql).Tables[0].Copy());
					}
				}
			}
			//
			foreach(DataRow r in lds.Tables[0].Rows)
			{
				string s_exp="";
				if(chkdongia.Checked)
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and dongia="+r["dongia"].ToString()+" and nhomcc="+r["nhomcc"].ToString()+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"'";
				else
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and nhomcc="+r["nhomcc"].ToString();
				//
				r1=d.getrowbyid(ds.Tables[0],s_exp);
				if (r1==null)
				{					
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));				
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						//
						r2["manguon"]=r["manguon"].ToString();
						r2["nhomcc"]=r["nhomcc"].ToString();
						r2["tennguon"]=r["tennguon"].ToString();
						r2["tennhomcc"]=r["tennhomcc"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["handung"]=r["handung"].ToString();
						r2["losx"]=r["losx"].ToString();
						//
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["idnhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						r2["mahang"]=r3["mahang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["manuoc"]=r3["manuoc"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}
			}
			//hoantra
			sql="select b.mabd,nvl(b.manguon,0) manguon, nvl(b.nhomcc,0) nhomcc, sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien, b.giamua dongia, c.ten tennguon, d.ten tennhomcc, b.handung, b.losx ";
			sql+=" from d_xuatsdll a,d_thucxuat b, d_dmnguon c, d_nhomcc d ";
			sql+=" where a.id=b.id and b.manguon=c.id and b.nhomcc=d.id and b.soluong>0";
			sql+=cont;
			sql+=" and a.loai=3";
			sql+=" group by b.mabd,b.manguon, b.nhomcc, b.giamua, c.ten, d.ten, b.handung, b.losx ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				string s_exp="";
				if(chkdongia.Checked)
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and dongia="+r["dongia"].ToString()+" and nhomcc="+r["nhomcc"].ToString()+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"'";
				else
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and nhomcc="+r["nhomcc"].ToString();
				//
				r1=d.getrowbyid(ds.Tables[0],s_exp);
				if (r1==null)
				{
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien"]=-decimal.Parse(r["sotien"].ToString());
						//
						r2["manguon"]=r["manguon"].ToString();
						r2["nhomcc"]=r["nhomcc"].ToString();
						r2["tennguon"]=r["tennguon"].ToString();
						r2["tennhomcc"]=r["tennhomcc"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["handung"]=r["handung"].ToString();
						r2["losx"]=r["losx"].ToString();
						//
						r2["idnhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						r2["mahang"]=r3["mahang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["manuoc"]=r3["manuoc"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow []dr=ds.Tables[0].Select(s_exp);
					if (dr.Length>0)
					{
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())-decimal.Parse(r["soluong"].ToString());
						dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())-decimal.Parse(r["sotien"].ToString());
					}
				}
			}
			sort();
		}
		private void taotable_xuat_toaBHYT()
		{
			//Phieu xuat kho: bao cao xuat kho: xuat phieu linh+xuat bu tu truc
			//table: d_bhytkb+bhytthuoc
			s_lydoxuat="Xuất theo toa BHYT";
			s_noinhan="";
			ds.Clear();						
			cont=" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			s_phieu="";
			for(int i=0;i<khoaphong.Items.Count;i++)
				if (khoaphong.GetItemChecked(i)) 
				{
					s_phieu+="'"+dtkp.Rows[i]["makp"].ToString().Trim()+"',";
					s_noinhan+=dtkp.Rows[i]["tenkp"].ToString().Trim()+", ";
				}
			s_noinhan=(s_noinhan.Trim()=="")?"Khoa khám bệnh":s_noinhan.Substring(0,s_noinhan.Trim().Length-1);
			//
			if (s_phieu!="") cont+=" and a.makp in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";						
			s_makho="";s_tenkho="";
			if(makho.CheckedItems.Count<=0)for(int i=0;i<makho.Items.Count;i++) makho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho!="") cont+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			else for(int i=0;i<makho.Items.Count;i++) s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
			sql="select b.mabd,nvl(b.manguon,0) manguon, nvl(b.nhomcc,0) nhomcc, sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien, b.giamua dongia, c.ten tennguon, d.ten tennhomcc, b.handung, b.losx ";
			sql+=" from bhytkb a,bhytthuoc b, "+d.user+".d_dmnguon c, "+d.user+".d_nhomcc d ";
			sql+=" where a.id=b.id and b.manguon=c.id and b.nhomcc=d.id and b.soluong>0";
			sql+=cont;			
			sql+=" group by b.mabd,b.manguon, b.nhomcc, b.giamua, c.ten, d.ten, b.handung, b.losx ";			
			DataSet lds=new DataSet();
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";					
			int i_tongsotoa=0;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(lds.Tables.Count<=0)
							lds=d.get_data(mmyy,sql);
						else
							lds.Merge(d.get_data(mmyy,sql).Tables[0].Copy());
						//
						i_tongsotoa+=get_tongsotoa_bhyt(mmyy, cont);
					}
				}
			}
			//Get tong so toa BHYT			
			sotoabhyt.Text=i_tongsotoa.ToString("###,###");
			//
			foreach(DataRow r in lds.Tables[0].Rows)
			{
				string s_exp="";
				if(chkdongia.Checked)
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and dongia="+r["dongia"].ToString()+" and nhomcc="+r["nhomcc"].ToString()+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"'";
				else
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and nhomcc="+r["nhomcc"].ToString();
				//
				r1=d.getrowbyid(ds.Tables[0],s_exp);
				if (r1==null)
				{					
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));				
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						//						
						r2["manguon"]=r["manguon"].ToString();
						r2["nhomcc"]=r["nhomcc"].ToString();
						r2["tennguon"]=r["tennguon"].ToString();
						r2["tennhomcc"]=r["tennhomcc"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["handung"]=r["handung"].ToString();
						r2["losx"]=r["losx"].ToString();
						//
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["idnhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						r2["mahang"]=r3["mahang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["manuoc"]=r3["manuoc"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}						
			}
			sort();
		}
		
		private void taotable_xuat_ngoaitru()
		{
			//Phieu xuat kho: bao cao xuat kho: xuat phieu linh+xuat bu tu truc
			//table: d_bhytkb+bhytthuoc
			ds.Clear();	
			cont="";
			s_noinhan="";
			s_lydoxuat="Xuất ngoại trú - Miễn phí";
			/*
			if(makp.SelectedIndex>=0)
			{
				s_noinhan=makp.Text;
				cont=" and a.makp="+makp.SelectedValue.ToString();
			}
			*/
			cont+=" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";			
			s_makho="";s_tenkho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho!="") cont+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			else for(int i=0;i<makho.Items.Count;i++) s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
			sql="select b.mabd,nvl(b.manguon,0) manguon, nvl(b.nhomcc,0) nhomcc, sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien, b.giamua dongia, c.ten tennguon, d.ten tennhomcc, b.handung, b.losx ";
			sql+=" from d_ngtrull a,d_ngtruct b, "+d.user+".d_dmnguon c, "+d.user+".d_nhomcc d ";
			sql+=" where a.id=b.id and b.manguon=c.id and b.nhomcc=d.id and b.soluong>0";
			sql+=cont;			
			sql+=" group by b.mabd,b.manguon, b.nhomcc, b.giamua, c.ten, d.ten, b.handung, b.losx ";
			//
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";					
			DataSet lds=new DataSet();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(lds.Tables.Count<=0)
							lds=d.get_data(mmyy,sql);
						else
							lds.Merge(d.get_data(mmyy,sql).Tables[0].Copy());
					}
				}
			}
			//
			foreach(DataRow r in lds.Tables[0].Rows)
			{
				string s_exp="";
				if(chkdongia.Checked)
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and dongia="+r["dongia"].ToString()+" and nhomcc="+r["nhomcc"].ToString()+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"'";
				else
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and nhomcc="+r["nhomcc"].ToString();
				//
				r1=d.getrowbyid(ds.Tables[0],s_exp);
				if (r1==null)
				{					
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));				
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						//
						r2["manguon"]=r["manguon"].ToString();
						r2["nhomcc"]=r["nhomcc"].ToString();
						r2["tennguon"]=r["tennguon"].ToString();
						r2["tennhomcc"]=r["tennhomcc"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["handung"]=r["handung"].ToString();
						r2["losx"]=r["losx"].ToString();
						//
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["idnhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						r2["mahang"]=r3["mahang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["manuoc"]=r3["manuoc"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}						
			}
			sort();
		}
		
		private void taotable_xuat_chuyenkho()
		{
			//Phieu xuat kho: bao cao xuat kho: xuat phieu linh+xuat bu tu truc
			//table: d_bhytkb+bhytthuoc
			ds.Clear();		
			s_noinhan="";
			s_lydoxuat="Xuất chuyển kho";
			cont=" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			s_phieu="";
			for(int i=0;i<phieu.Items.Count;i++)
				if (phieu.GetItemChecked(i)) s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";			
			s_makho="";s_tenkho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho!="") cont+=" and a.khox in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			else for(int i=0;i<makho.Items.Count;i++) s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
			//khoa nhan
			string s_makn="";
			if(khonhan.CheckedItems.Count<=0)for(int i=0;i<khonhan.Items.Count;i++)khonhan.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<khonhan.Items.Count;i++)
				if (khonhan.GetItemChecked(i))
				{
					s_makn+=dtkn.Rows[i]["id"].ToString().Trim()+",";
					s_noinhan+=dtkn.Rows[i]["ten"].ToString().Trim()+";";
				}
			if(s_makn!="")cont+=" and a.khon in ("+s_makn.Substring(0,s_makn.Length-1)+")";
			if(s_noinhan!="")s_noinhan=s_noinhan.Substring(0,s_noinhan.Trim().Length-1);
			//
			sql="select b.mabd,nvl(b.manguon,0) manguon, nvl(b.nhomcc,0) nhomcc, sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien, b.giamua dongia, c.ten tennguon, d.ten tennhomcc, b.handung, b.losx ";
			sql+=" from d_xuatll a,d_xuatct b, "+d.user+".d_dmnguon c, "+d.user+".d_nhomcc d ";
			sql+=" where a.id=b.id and b.manguon=c.id and b.nhomcc=d.id and b.soluong>0 and a.loai='CK'";
			sql+=cont;			
			sql+=" group by b.mabd,b.manguon, b.nhomcc, b.giamua, c.ten, d.ten, b.handung, b.losx ";
			//
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";					
			DataSet lds=new DataSet();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(lds.Tables.Count<=0)
							lds=d.get_data(mmyy,sql);
						else
							lds.Merge(d.get_data(mmyy,sql).Tables[0].Copy());
					}
				}
			}
			//
			foreach(DataRow r in lds.Tables[0].Rows)
			{
				string s_exp="";
				if(chkdongia.Checked)
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and dongia="+r["dongia"].ToString()+" and nhomcc="+r["nhomcc"].ToString()+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"'";
				else
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and nhomcc="+r["nhomcc"].ToString();
				//
				r1=d.getrowbyid(ds.Tables[0],s_exp);
				if (r1==null)
				{					
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));				
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						//
						r2["manguon"]=r["manguon"].ToString();
						r2["nhomcc"]=r["nhomcc"].ToString();
						r2["tennguon"]=r["tennguon"].ToString();
						r2["tennhomcc"]=r["tennhomcc"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["handung"]=r["handung"].ToString();
						r2["losx"]=r["losx"].ToString();
						//
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["idnhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						r2["mahang"]=r3["mahang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["manuoc"]=r3["manuoc"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}						
			}
			sort();
		}
		
		private void taotable_xuat_khac()
		{
			//Phieu xuat kho: bao cao xuat kho: xuat phieu linh+xuat bu tu truc
			//table: d_bhytkb+bhytthuoc
			ds.Clear();			
			s_noinhan="";
			s_lydoxuat="Hỏng, vở, hết date...";
			cont=" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			s_phieu="";
			for(int i=0;i<phieu.Items.Count;i++)
				if (phieu.GetItemChecked(i)) s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";			
			s_makho="";s_tenkho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho!="") cont+=" and a.khox in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			else for(int i=0;i<makho.Items.Count;i++) s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
			sql="select b.mabd,nvl(b.manguon,0) manguon, nvl(b.nhomcc,0) nhomcc, sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien, b.giamua dongia, c.ten tennguon, d.ten tennhomcc, b.handung, b.losx ";
			sql+=" from d_xuatll a,d_xuatct b, "+d.user+".d_dmnguon c, "+d.user+".d_nhomcc d ";
			sql+=" where a.id=b.id and b.manguon=c.id and b.nhomcc=d.id and b.soluong>0 and a.loai='XK'";
			sql+=cont;			
			sql+=" group by b.mabd,b.manguon, b.nhomcc, b.giamua, c.ten, d.ten, b.handung, b.losx ";
			//
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";					
			DataSet lds=new DataSet();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(lds.Tables.Count<=0)
							lds=d.get_data(mmyy,sql);
						else
							lds.Merge(d.get_data(mmyy,sql).Tables[0].Copy());
					}
				}
			}
			foreach(DataRow r in lds.Tables[0].Rows)
			{
				string s_exp="";
				if(chkdongia.Checked)
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and dongia="+r["dongia"].ToString()+" and nhomcc="+r["nhomcc"].ToString()+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"'";
				else
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and nhomcc="+r["nhomcc"].ToString();
				//
				r1=d.getrowbyid(ds.Tables[0],s_exp);
				if (r1==null)
				{					
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));				
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						//
						r2["manguon"]=r["manguon"].ToString();
						r2["nhomcc"]=r["nhomcc"].ToString();
						r2["tennguon"]=r["tennguon"].ToString();
						r2["tennhomcc"]=r["tennhomcc"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["handung"]=r["handung"].ToString();
						r2["losx"]=r["losx"].ToString();
						//
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["idnhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						r2["mahang"]=r3["mahang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["manuoc"]=r3["manuoc"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}						
			}
			sort();
		}
		
		private void taotable_xuat_tangcoso()
		{
			//Phieu xuat kho: bao cao xuat kho: xuat phieu linh+xuat bu tu truc
			//table: d_bhytkb+bhytthuoc
			ds.Clear();	
			s_noinhan=makp.Text;
			s_lydoxuat="Tăng cơ số";
			cont=" and a.khon="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";			
			s_makho="";s_tenkho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho!="") cont+=" and a.khox in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			else for(int i=0;i<makho.Items.Count;i++) s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
			sql="select b.mabd,nvl(b.manguon,0) manguon, nvl(b.nhomcc,0) nhomcc, sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien, b.giamua dongia, c.ten tennguon, d.ten tennhomcc, b.handung, b.losx ";
			sql+=" from d_xuatll a,d_xuatct b, d_dmnguon c, d_nhomcc d ";
			sql+=" where a.id=b.id and b.manguon=c.id and b.nhomcc=d.id and b.soluong>0 and a.loai='BS'";
			sql+=cont;			
			sql+=" group by b.mabd,b.manguon, b.nhomcc, b.giamua, c.ten, d.ten, b.handung, b.losx ";
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";					
			DataSet lds=new DataSet();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(lds.Tables.Count<=0)
							lds=d.get_data(mmyy,sql);
						else
							lds.Merge(d.get_data(mmyy,sql).Tables[0].Copy());
					}
				}
			}
			//
			foreach(DataRow r in lds.Tables[0].Rows)
			{
				string s_exp="";
				if(chkdongia.Checked)
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and dongia="+r["dongia"].ToString()+" and nhomcc="+r["nhomcc"].ToString()+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"'";
				else
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and nhomcc="+r["nhomcc"].ToString();
				//
				r1=d.getrowbyid(ds.Tables[0],s_exp);
				if (r1==null)
				{					
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));				
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						//
						r2["manguon"]=r["manguon"].ToString();
						r2["nhomcc"]=r["nhomcc"].ToString();
						r2["tennguon"]=r["tennguon"].ToString();
						r2["tennhomcc"]=r["tennhomcc"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["handung"]=r["handung"].ToString();
						r2["losx"]=r["losx"].ToString();
						//
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["idnhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						r2["mahang"]=r3["mahang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["manuoc"]=r3["manuoc"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}						
			}
			sort();
		}
		
		private void taotable_xuat_bucoso()
		{
			//Phieu xuat kho: bao cao xuat kho: xuat phieu linh+xuat bu tu truc
			//table: d_bhytkb+bhytthuoc
			ds.Clear();			
			s_noinhan=makp.Text;
			s_lydoxuat="Bù tủ trực";
			cont=" and a.makp="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";			
			s_makho="";s_tenkho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho!="") cont+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			else for(int i=0;i<makho.Items.Count;i++) s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
			sql="select b.mabd,nvl(b.manguon,0) manguon, nvl(b.nhomcc,0) nhomcc, sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien, b.giamua dongia, c.ten tennguon, d.ten tennhomcc, b.handung, b.losx ";
			sql+=" from d_xuatsdll a,d_bucstt b, "+d.user+".d_dmnguon c, "+d.user+".d_nhomcc d ";
			sql+=" where a.id=b.id and b.manguon=c.id and b.nhomcc=d.id and b.soluong>0 ";
			sql+=cont;			
			sql+=" group by b.mabd,b.manguon, b.nhomcc, b.giamua, c.ten, d.ten, b.handung, b.losx ";
			//
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";					
			DataSet lds=new DataSet();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(lds.Tables.Count<=0)
							lds=d.get_data(mmyy,sql);
						else
							lds.Merge(d.get_data(mmyy,sql).Tables[0].Copy());
					}
				}
			}
			foreach(DataRow r in lds.Tables[0].Rows)
			{
				string s_exp="";
				if(chkdongia.Checked)
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and dongia="+r["dongia"].ToString()+" and nhomcc="+r["nhomcc"].ToString()+" and handung='"+r["handung"].ToString()+"' and losx='"+r["losx"].ToString()+"'";
				else
					s_exp="mabd="+int.Parse(r["mabd"].ToString())+" and manguon="+r["manguon"].ToString()+" and nhomcc="+r["nhomcc"].ToString();
				//
				r1=d.getrowbyid(ds.Tables[0],s_exp);
				if (r1==null)
				{					
					r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));				
					if (r3!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						//
						r2["manguon"]=r["manguon"].ToString();
						r2["nhomcc"]=r["nhomcc"].ToString();
						r2["tennguon"]=r["tennguon"].ToString();
						r2["tennhomcc"]=r["tennhomcc"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["handung"]=r["handung"].ToString();
						r2["losx"]=r["losx"].ToString();
						//
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["idnhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						r2["mahang"]=r3["mahang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["manuoc"]=r3["manuoc"].ToString();
						r2["tennuoc"]=r3["tennuoc"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}						
			}
			sort();
		}
		private int get_tongsotoa_bhyt(string d_mmyy, string s_cond)
		{
			int i_sotoa=0;
			DataTable ldt=new DataTable();
			string s_sql="select distinct a.id from bhytkb a,bhytthuoc b where a.id=b.id ";
			s_sql+=s_cond;						
			//
			ldt=d.get_data(d_mmyy, s_sql).Tables[0];
			i_sotoa=int.Parse(ldt.Rows.Count.ToString());			
			ldt.Dispose();
			return i_sotoa;
		}
#endregion

		private void chkAll_Click(object sender, System.EventArgs e)
		{
			if(chkAll.Checked)
				for(int i=0;i<khoaphong.CheckedItems.Count;i++)khoaphong.SetItemCheckState(i,CheckState.Checked);
			else
				for(int i=0;i<khoaphong.CheckedItems.Count;i++)khoaphong.SetItemCheckState(i,CheckState.Unchecked);
		}
	}
}
