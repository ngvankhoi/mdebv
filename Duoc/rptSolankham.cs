using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Data;
using LibDuoc;
using LibMedi;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptBhyt.
	/// </summary>
	public class rptSolankham : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private DataColumn dc;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
        private int i_nhom, i_madoituong, i_userid=0;
		private bool bClear=true,bSothe,bCongkham,bSotien;
		private string sql,tenfile,s_kho,s_makho,s_thetrongtinh,user,xxx,stime;
		private decimal soluot,dcongkham,dthuoc,dcls;
		private DataRow r1,r2;
		private DataRow[] dr;
		private DataSet ds;
		private DataSet dsxml;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Data.DataTable dtso=new System.Data.DataTable();
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label3;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel psothe;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown vitri;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.Label label7;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptSolankham(LibDuoc.AccessData acc,int nhom,string kho,int madoituong,int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;s_makho=kho;i_madoituong=madoituong;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptSolankham));
            this.label1 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.psothe = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.vitri = new System.Windows.Forms.NumericUpDown();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.psothe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vitri)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(95, 198);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 8;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(165, 198);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 56);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(192, 21);
            this.manguon.TabIndex = 3;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(126, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 80);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 84);
            this.kho.TabIndex = 5;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butXem
            // 
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(25, 198);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 7;
            this.butXem.Text = "&Excel";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 9);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(168, 9);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(56, 32);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(192, 21);
            this.madoituong.TabIndex = 2;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Đối tượng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // psothe
            // 
            this.psothe.Controls.Add(this.label8);
            this.psothe.Controls.Add(this.vitri);
            this.psothe.Controls.Add(this.sothe);
            this.psothe.Controls.Add(this.label7);
            this.psothe.Location = new System.Drawing.Point(0, 167);
            this.psothe.Name = "psothe";
            this.psothe.Size = new System.Drawing.Size(256, 24);
            this.psothe.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(136, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Vị trí :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vitri
            // 
            this.vitri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vitri.Location = new System.Drawing.Point(184, 0);
            this.vitri.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.vitri.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vitri.Name = "vitri";
            this.vitri.Size = new System.Drawing.Size(64, 21);
            this.vitri.TabIndex = 19;
            this.vitri.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.vitri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // sothe
            // 
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(56, 0);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(72, 21);
            this.sothe.TabIndex = 18;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-8, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Lọc ký tự :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rptSolankham
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 236);
            this.Controls.Add(this.psothe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptSolankham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp số lượt khám bệnh";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptSolankham_MouseMove);
            this.Load += new System.EventHandler(this.rptSolankham_Load);
            this.psothe.ResumeLayout(false);
            this.psothe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vitri)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void rptSolankham_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			bCongkham=d.bcongkham_bhyt(i_nhom);
			bSotien=d.bSotien_bhyt(i_nhom);
			psothe.Enabled=d.sothe_doituong(i_madoituong);
			s_thetrongtinh=d.thetrongtinh(i_nhom);
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            dt = d.get_data("select * from " + user + ".d_dmbd where nhom=" + i_nhom + " order by id").Tables[0];

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";

            sql = "select * from " + user + ".doituong";
			if (i_madoituong==1) sql+=" where madoituong=1";
			else sql+=" where madoituong<>1";
			sql+=" order by madoituong";
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=d.get_data(sql).Tables[0];
			
			dc=new DataColumn();
			dc.ColumnName="sothe";
			dc.DataType=Type.GetType("System.String");
			dtso.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="hoten";
			dc.DataType=Type.GetType("System.String");
			dtso.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="ngay";
			dc.DataType=Type.GetType("System.String");
			dtso.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="id";
			dc.DataType=Type.GetType("System.Decimal");
			dtso.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="congkham";
			dc.DataType=Type.GetType("System.Decimal");
			dtso.Columns.Add(dc);
		}

		private void Tao_dataset()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_solankham.xml");
            ds.Tables[0].Columns.Add("sophieu", typeof(decimal));
			dsxml=new DataSet();
			dsxml=ds.Copy();
		}

		private void get_xuat(string d_mmyy)
		{
			Cursor=Cursors.WaitCursor;
            xxx = user + d_mmyy;
			sql="select 0 as loai,a.id,to_char(a.ngay,'yyyymmdd') as ngay,a.sothe,a.mabn,f.hoten,f.namsinh,f.diachi,g.tenbv,d.nhomvp,sum(0) as congkham,";
			sql+="sum(b.soluong*t.giamua) as sotien ";
            sql += ", a.mavaovien, to_char(a.ngay,'dd/mm/yyyy') as ngayduyet ";
			sql+="from "+xxx+".bhytkb a inner join "+xxx+".bhytthuoc b on a.id=b.id ";
            sql+=" inner join "+user+".d_dmbd c on b.mabd=c.id ";
			sql+=" inner join "+user+".d_dmnhom d on c.manhom=d.id ";
            sql+=" inner join "+xxx+".bhytds f on a.mabn=f.mabn ";
            sql+=" left join "+user+".dmnoicapbhyt g on a.mabv=g.mabv ";
            sql += " inner join " + xxx + ".d_theodoi t on b.sttt=t.id ";
            sql += "where a.maphu=" + int.Parse(madoituong.SelectedValue.ToString()) + " and a.nhom=" + i_nhom;
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (sothe.Text!="" && psothe.Enabled)	sql+=" and substr(a.sothe,"+int.Parse(vitri.Value.ToString())+","+sothe.Text.Trim().Length+")='"+sothe.Text.Trim()+"'";
			sql+=" group by a.id,to_char(a.ngay,'yyyymmdd'),a.sothe,a.mabn,f.hoten,f.namsinh,f.diachi,g.tenbv,d.nhomvp";
            sql += ", a.mavaovien, to_char(a.ngay,'dd/mm/yyyy') ";
			sql+=" UNION all ";
			sql+="select 1 as loai,a.id,to_char(a.ngay,'yyyymmdd') as ngay,a.sothe,a.mabn,f.hoten,f.namsinh,f.diachi,g.tenbv,d.id_nhom as nhomvp,sum(0) as congkham,sum(b.soluong*b.dongia) sotien ";
            sql += ", a.mavaovien, to_char(a.ngay,'dd/mm/yyyy') as ngayduyet ";
            sql+=" from "+xxx+".bhytkb a inner join "+xxx+".bhytcls b on a.id=b.id ";
            sql+=" inner join "+user+".v_giavp c on b.mavp=c.id ";
			sql+=" inner join "+user+".v_loaivp d on c.id_loai=d.id ";
            sql+=" inner join "+xxx+".bhytds f on a.mabn=f.mabn ";
            sql+=" left join "+user+".dmnoicapbhyt g on a.mabv=g.mabv ";
            sql += "where a.maphu=" + int.Parse(madoituong.SelectedValue.ToString()) + " and a.nhom=" + i_nhom;
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (sothe.Text!="" && psothe.Enabled)	sql+=" and substr(a.sothe,"+int.Parse(vitri.Value.ToString())+","+sothe.Text.Trim().Length+")='"+sothe.Text.Trim()+"'";
			sql+=" group by a.id,to_char(a.ngay,'yyyymmdd'),a.sothe,a.mabn,f.hoten,f.namsinh,f.diachi,g.tenbv,d.id_nhom";
            sql += ", a.mavaovien, to_char(a.ngay,'dd/mm/yyyy') ";
			ins_items();
			Cursor=Cursors.Default;
		}

		private void ins_items()
		{
			System.Data.DataTable dt=d.get_data(sql).Tables[0];
			string ten;
			if (bSothe)
			{
				decimal id=0;
				foreach(DataRow r in dt.Select("loai=0","id"))
				{
					if (id!=decimal.Parse(r["id"].ToString()))
					{
						id=decimal.Parse(r["id"].ToString());
						r1=dtso.NewRow();
						r1["id"]=r["id"].ToString();
						r1["ngay"]=r["ngay"].ToString();
						r1["sothe"]=r["sothe"].ToString();
						r1["hoten"]=r["hoten"].ToString();
						r1["congkham"]=d.Congkham(i_nhom);
						dtso.Rows.Add(r1);
						soluot+=1;
					}
				}
			}
            int isophieu = 0;
			foreach(DataRow r in dt.Rows)
			{
				if (bSothe) sql="sothe='"+r["sothe"].ToString()+"' and hoten='"+r["hoten"].ToString()+"'";
				else sql="mabn='"+r["mabn"].ToString()+"' and hoten='"+r["hoten"].ToString()+"'";
				r1=d.getrowbyid(ds.Tables[0],sql);
				ten=(r["loai"].ToString()=="0")?"thuoc":"cls";
				if (r1==null)
				{
                    //
                    isophieu = d.get_sophieu_bhyt_userid(tu.Text, den.Text, r["mabn"].ToString(), decimal.Parse(r["mavaovien"].ToString()), r["ngayduyet"].ToString(), int.Parse(madoituong.SelectedValue.ToString()));
                    //
					r2 = ds.Tables[0].NewRow();
					r2["sothe"]=r["sothe"].ToString();
					if (r["sothe"].ToString().Trim().Length>4)
					{
						r2["stt"]=(r["sothe"].ToString().Substring(2,2)==s_thetrongtinh)?0:1;
						r2["sothe1"]=r["sothe"].ToString().Substring(0,2);
						r2["sothe2"]=r["sothe"].ToString().Substring(2,2);
						r2["sothe3"]=r["sothe"].ToString().Substring(4);
					}
					r2["mabn"]=r["mabn"].ToString();
					r2["hoten"]=r["hoten"].ToString();
					r2["thuoc"]=0;
					r2["cls"]=0;
					r2[ten]=r["sotien"].ToString();
					r2["congkham"]=0;
                    r2["sophieu"] = isophieu;
					r2["tongcong"]=decimal.Parse(r["sotien"].ToString())+decimal.Parse(r["congkham"].ToString());
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr = ds.Tables[0].Select(sql);
					if (dr.Length>0)
					{
						dr[0][ten]=decimal.Parse(dr[0][ten].ToString())+decimal.Parse(r["sotien"].ToString());
						dr[0]["tongcong"]=decimal.Parse(dr[0]["tongcong"].ToString())+decimal.Parse(r["sotien"].ToString());
					}
				}
			}
			if (bSothe)
			{
				foreach(DataRow r in ds.Tables[0].Rows)
				{
					if (bSothe) sql="sothe='"+r["sothe"].ToString()+"' and hoten='"+r["hoten"].ToString()+"'";
					else sql="mabn='"+r["mabn"].ToString()+"' and hoten='"+r["hoten"].ToString()+"'";
					r["soluot"]=dtso.Select(sql).Length.ToString();
					r["congkham"]=decimal.Parse(r["soluot"].ToString())*d.Congkham(i_nhom);
					r["tongcong"]=decimal.Parse(r["thuoc"].ToString())+decimal.Parse(r["cls"].ToString())+decimal.Parse(r["congkham"].ToString());
					dthuoc+=decimal.Parse(r["thuoc"].ToString());
					dcls+=decimal.Parse(r["cls"].ToString());
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

		private void exp_excel(bool print)
		{
			d.check_process_Excel();
			try
			{
				int be=3,dong=5,sodong=dsxml.Tables[0].Rows.Count+5,socot=dsxml.Tables[0].Columns.Count-1,dongke=sodong;
				tenfile=d.Export_Excel(dsxml,"solankham");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));//,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);//,Missing.Value);
				osheet.get_Range(d.getIndex(be+2)+dong.ToString(),d.getIndex(socot)+sodong.ToString()).NumberFormat="#,##0";
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				for(int i=0;i<=socot;i++) osheet.Cells[dong-1,i+1]=get_ten(i).ToString();
				osheet.Cells[sodong,2]="TỔNG CỘNG";
				orange=osheet.get_Range(d.getIndex(0)+"4",d.getIndex(1)+"4");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Bold=true;
				int so=sodong;
				osheet.Cells[sodong,4]=soluot;
				osheet.Cells[sodong,5]=dcongkham;
				osheet.Cells[sodong,6]=dthuoc;
				osheet.Cells[sodong,7]=dcls;
				osheet.Cells[sodong,8]=dcongkham+dthuoc+dcls;
				orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
				orange.Font.Name="Arial";
				orange.Font.Size=8;
				orange.EntireColumn.AutoFit();
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.PageSetup.Orientation=XlPageOrientation.xlPortrait;
				osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
				osheet.PageSetup.LeftMargin=20;
				osheet.PageSetup.RightMargin=20;
				osheet.PageSetup.TopMargin=30;
				osheet.Cells[sodong+1,6]="Ngày ... tháng ... năm ....";
				osheet.Cells[sodong+2,2]="THỦ TRƯỞNG ĐƠN VỊ";
				osheet.Cells[sodong+2,6]="       NGƯỜI LẬP BIỂU      ";
				osheet.PageSetup.CenterFooter="Trang : &P/&N";
				osheet.Cells[1,1]=d.Syte;osheet.Cells[2,1]=d.Tenbv;
				orange=osheet.get_Range(d.getIndex(1)+"1",d.getIndex(3)+"2");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				osheet.Cells[1,3]="TỔNG HỢP SỐ LƯỢT KHÁM BỆNH "+madoituong.Text.Trim().ToUpper()+" NGỌAI TRÚ";
				osheet.Cells[2,3]=(tu.Text==den.Text)?"Ngày : "+tu.Text:"Từ ngày :"+tu.Text+" đến ngày :"+den.Text;
				orange=osheet.get_Range(d.getIndex(2)+"1",d.getIndex(socot)+"2");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size=12;
				orange.Font.Bold=true;
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
			string []map={"MÃ BN","HỌ TÊN","SỐ THẺ","SỐ LƯỢT","CÔNG KHÁM","TIỀN THUỐC","TIỀN CLS","TỔNG CỘNG","SỐ PHIẾU"};
			return map[i];
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{				
			if (kiemtra()) exp_excel(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (kiemtra())
			{
				frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,"d_solankham.rpt","",(tu.Text==den.Text)?"Ngày : "+tu.Text:"Từ ngày :"+tu.Text+" đến ngày :"+den.Text,"","","","","","","","");
				f.ShowDialog(this);
			}
		}

		private bool kiemtra()
		{
			soluot=0;dthuoc=0;dcls=0;dcongkham=0;
			bSothe=int.Parse(m.sothe(int.Parse(madoituong.SelectedValue.ToString())).Substring(0,2))>0;
			if (tu.Value>den.Value)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày/tháng không hợp lệ !"),d.Msg);
				tu.Focus();
				return false;
			}
			s_kho="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++)	if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
			dtso.Clear();
			Tao_dataset();
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy)) get_xuat(mmyy);
				}
			}
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return false;
			}
			string sort="stt,sothe1,sothe2,sothe3,sothe,mabn";
			dsxml.Merge(ds.Tables[0].Select("true",sort));
			dsxml.Tables[0].Columns.Remove("STT");
			dsxml.Tables[0].Columns.Remove("SOTHE1");
			dsxml.Tables[0].Columns.Remove("SOTHE2");
			dsxml.Tables[0].Columns.Remove("SOTHE3");
			foreach(DataRow r in dtso.Rows)	dcongkham+=decimal.Parse(r["congkham"].ToString());
			return true;
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1 && madoituong.Items.Count>0) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void rptSolankham_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void madoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==madoituong)
				psothe.Enabled=d.sothe_doituong(int.Parse(madoituong.SelectedValue.ToString()));
		}

		private void sothe_Validated(object sender, System.EventArgs e)
		{
			if (sothe.Text=="") butIn.Focus();
		}
	}
}
