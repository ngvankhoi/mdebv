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
	public class rptBhyt : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		//
		System.Data.DataTable dtkp=new System.Data.DataTable();
		//
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_madoituong, d_userid=0;
        private bool bClear = true, bSotien, bIncstt;
		private string sql,s_kho,s_makho,user,xxx,stime;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private DataSet ds;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.CheckBox chksotoa;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox madoituong;
        private GroupBox groupBox1;
        private RadioButton rd_vatay1;
        private RadioButton rd_vatay3;
        private RadioButton rd_vatay2;
        private CheckBox chkNhathuoc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBhyt(AccessData acc,int nhom,string kho,int madoituong, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;

            i_madoituong=madoituong;
            d_userid = _userid;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBhyt));
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
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chksotoa = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_vatay3 = new System.Windows.Forms.RadioButton();
            this.rd_vatay2 = new System.Windows.Forms.RadioButton();
            this.rd_vatay1 = new System.Windows.Forms.RadioButton();
            this.chkNhathuoc = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(109, 293);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(179, 293);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 63);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(192, 21);
            this.manguon.TabIndex = 3;
            this.manguon.Visible = false;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kho: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(126, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 46);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 196);
            this.kho.TabIndex = 5;
            // 
            // butXem
            // 
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(39, 293);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 6;
            this.butXem.Text = "&Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 16);
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
            this.den.Location = new System.Drawing.Point(168, 16);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(256, 16);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(248, 228);
            this.makp.TabIndex = 14;
            this.makp.Click += new System.EventHandler(this.makp_Click);
            // 
            // chkAll
            // 
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(266, 247);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(88, 24);
            this.chkAll.TabIndex = 15;
            this.chkAll.Text = "Chọn tất cả";
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // chksotoa
            // 
            this.chksotoa.Checked = true;
            this.chksotoa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chksotoa.Location = new System.Drawing.Point(56, 268);
            this.chksotoa.Name = "chksotoa";
            this.chksotoa.Size = new System.Drawing.Size(168, 24);
            this.chksotoa.TabIndex = 16;
            this.chksotoa.Text = "Tính thêm số toa không in";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Đối tượng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // madoituong
            // 
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(56, 39);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(192, 21);
            this.madoituong.TabIndex = 2;
            this.madoituong.Visible = false;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_vatay3);
            this.groupBox1.Controls.Add(this.rd_vatay2);
            this.groupBox1.Controls.Add(this.rd_vatay1);
            this.groupBox1.Location = new System.Drawing.Point(256, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 41);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toa phát có kiểm tra Vân tay";
            // 
            // rd_vatay3
            // 
            this.rd_vatay3.AutoSize = true;
            this.rd_vatay3.Checked = true;
            this.rd_vatay3.Location = new System.Drawing.Point(186, 17);
            this.rd_vatay3.Name = "rd_vatay3";
            this.rd_vatay3.Size = new System.Drawing.Size(56, 17);
            this.rd_vatay3.TabIndex = 2;
            this.rd_vatay3.TabStop = true;
            this.rd_vatay3.Text = "Tất cả";
            this.rd_vatay3.UseVisualStyleBackColor = true;
            // 
            // rd_vatay2
            // 
            this.rd_vatay2.AutoSize = true;
            this.rd_vatay2.Location = new System.Drawing.Point(93, 17);
            this.rd_vatay2.Name = "rd_vatay2";
            this.rd_vatay2.Size = new System.Drawing.Size(56, 17);
            this.rd_vatay2.TabIndex = 1;
            this.rd_vatay2.Text = "Không";
            this.rd_vatay2.UseVisualStyleBackColor = true;
            // 
            // rd_vatay1
            // 
            this.rd_vatay1.AutoSize = true;
            this.rd_vatay1.Location = new System.Drawing.Point(23, 17);
            this.rd_vatay1.Name = "rd_vatay1";
            this.rd_vatay1.Size = new System.Drawing.Size(38, 17);
            this.rd_vatay1.TabIndex = 0;
            this.rd_vatay1.Text = "Có";
            this.rd_vatay1.UseVisualStyleBackColor = true;
            // 
            // chkNhathuoc
            // 
            this.chkNhathuoc.Location = new System.Drawing.Point(56, 246);
            this.chkNhathuoc.Name = "chkNhathuoc";
            this.chkNhathuoc.Size = new System.Drawing.Size(168, 24);
            this.chkNhathuoc.TabIndex = 20;
            this.chkNhathuoc.Text = "Cả toa nhà thuốc";
            // 
            // rptBhyt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(514, 321);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chksotoa);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkNhathuoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptBhyt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảo hiểm y tế";
            this.Load += new System.EventHandler(this.rptBhyt_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptBhyt_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBhyt_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			bSotien=d.bSotien_bhyt(i_nhom);
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
            bIncstt = d.bIncstt(i_nhom);
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
			//phong kham
			Load_btdkp_bv();
            f_capnhat_db();
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
            sql = "select b.makho,b.mabd,c.ten,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c,"+xxx+".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai<>3 and b.madoituong=1 and a.nhom=" + i_nhom + " and to_date(to_char(a.ngay," + stime + ")," + stime + ") between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
			ins_items();

            sql = "select b.makho,b.mabd,c.ten,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c,"+xxx+".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom + " and to_date(to_char(a.ngay," + stime + ")," + stime + ")  between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
			ins_items();
		}

		private void ins_items()
		{
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["stt"]=d.get_stt(ds.Tables[0]);
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						foreach(DataRow r4 in dtkho.Rows)
						{
							r2["soluong_"+r4["id"].ToString().Trim()]=0;
							r2["sotien_"+r4["id"].ToString().Trim()]=0;
						}
						r2["soluong_"+r["makho"].ToString().Trim()]=r["soluong"].ToString();
						r2["sotien_"+r["makho"].ToString().Trim()]=r["sotien"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["soluong_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["soluong_"+r["makho"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["sotien_"+r["makho"].ToString().Trim()].ToString())+decimal.Parse(r["sotien"].ToString());
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
            sql = "select b.makho,b.mabd,c.ten,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c,"+xxx+".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=3 and b.madoituong=1 and a.nhom=" + i_nhom + " and to_date(to_char(a.ngay," + stime + ")," + stime + ") between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["stt"]=d.get_stt(ds.Tables[0]);
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						foreach(DataRow r4 in dtkho.Rows)
						{
							r2["soluong_"+r4["id"].ToString().Trim()]=0;
							r2["sotien_"+r4["id"].ToString().Trim()]=0;
						}
						r2["soluong_"+r["makho"].ToString().Trim()]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien_"+r["makho"].ToString().Trim()]=-decimal.Parse(r["sotien"].ToString());
						r2["soluong"]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien"]=-decimal.Parse(r["sotien"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["soluong_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["soluong_"+r["makho"].ToString().Trim()].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["sotien_"+r["makho"].ToString().Trim()].ToString())-decimal.Parse(r["sotien"].ToString());
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


		private void rptBhyt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				bClear=false;
			}
		}

		private string get_ten(int i)
		{
			string []map={"Số lượng","Số tiền","TT","Mã số","Tên","ĐVT"};
			return map[i];
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{			
			kiemtra_toa();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			kiemtra_toa();
		}

		private DataSet get_dsbn_bhyt(string d_mmyy, string s_kho, string s_pk, string s_cond)
		{
            xxx = user + d_mmyy;
			sql=" select ((to_char(a.sotoa,'0000')||a.mabn)||to_char(a.id,'000000000000000000')) as key_, a.mabn, c.hoten, a.sothe, a.maphu, a.congkham,a.ngay,b.soluong,";
			if (bSotien) sql+="b.soluong*t.giamua as sotien,t.giamua as dongia,";
			else sql+="round(b.soluong*t.giaban,3) as sotien,t.giaban as dongia,";
            sql += "d.ma,(d.ten||' '||d.hamluong) as ten, d.tenhc, d.hamluong, d.dang, case when a.sotoa is null then 0 else a.sotoa end as sotoa,kp.tenkp  ";
            sql += " from " + xxx + ".bhytkb a, " + xxx + ".bhytthuoc b, " + xxx + ".bhytds c, " + user + ".d_dmbd d," + xxx + ".d_theodoi t," + user + ".btdkp_bv kp ";
            sql += " where a.id=b.id and b.sttt=t.id and a.mabn=c.mabn and b.mabd=d.id and a.makp=kp.makp and b.soluong>0";
            //if (i_madoituong==1) sql+=" and a.maphu in (0,1)";
            //else sql+="and a.maphu="+int.Parse(madoituong.SelectedValue.ToString());
			if (!chksotoa.Checked) sql+=" and a.sotoa>0";
			if(s_kho!="") sql+=" and b.makho in ("+s_kho+")";
			sql+=s_cond;
			if(s_pk!="")sql+=" and a.makp in("+s_pk+")";
            if (rd_vatay1.Checked) sql += " and a.vantay=1 ";
            else if (rd_vatay2.Checked) sql += " and a.vantay=0 ";
            if (bIncstt)
            {
                sql += " union all ";
                sql += " select '0000'||a.mabn||to_char(a.id,'000000000000000000') as key_, a.mabn, c.hoten, d.sothe, f.madoituong as maphu,";
                sql+= " 0 as congkham,a.ngay,f.soluong,";
                if (bSotien) sql += "f.soluong*t.giamua as sotien,t.giamua as dongia,";
                else sql += "round(f.soluong*t.giaban,3) as sotien,t.giaban as dongia,";
                sql += "b.ma,(b.ten||' '||b.hamluong) as ten, b.tenhc, b.hamluong, b.dang,";
                sql += "0 as sotoa,kp.tenkp ";
                sql += " from " + xxx + ".d_xuatsdct f inner join " + user + ".d_dmbd b on f.mabd=b.id ";
                sql += " inner join " + xxx + ".d_xuatsdll a on a.id=f.id ";
                sql += " inner join "+ xxx + ".d_theodoi t on f.sttt=t.id ";                
                sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".d_duockp e on a.makp=e.id ";
                sql += " inner join " + xxx + ".benhancc g on a.maql=g.maql ";
                sql += " left join " + xxx + ".bhyt d on g.maql=d.maql ";
                sql += " inner join " + user + ".btdkp_bv kp on e.makp=kp.makp ";
                //sql += " where f.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                sql += " where a.loai=2 ";
                if (s_kho != "") sql += " and f.makho in (" + s_kho + ")";
                if (s_pk != "") sql += " and e.makp in(" + s_pk + ")";
                sql += s_cond;
            }
            if (chkNhathuoc.Checked)
            {
                sql += " union all ";
                sql += " select ((to_char(a.sotoa,'0000')||a.mabn)||to_char(a.id,'000000000000000000')) as key_, a.mabn, c.hoten, '' as sothe, 0 as maphu, 0 as congkham,a.ngay,b.soluong,";
                sql += "round(b.soluong*b.giaban,3) as sotien,b.giaban as dongia,";
                sql += "d.ma,(d.ten||' '||d.hamluong) as ten, d.tenhc, d.hamluong, d.dang, case when a.sotoa is null then 0 else a.sotoa end as sotoa,kp.tenkp ";
                sql += " from " + xxx + ".d_ngtrull a, " + xxx + ".d_ngtruct b, " + user + ".btdbn c," + user + ".d_dmbd d," + user + ".btdkp_bv kp ," + user + ".d_duockp dkp";
                sql += " where a.id=b.id and a.mabn=c.mabn and b.mabd=d.id and kp.makp=dkp.makp and b.soluong>0";
                if (s_kho != "") sql += " and b.makho in (" + s_kho + ")";
                sql += s_cond;
                //if (s_pk != "") sql += " and a.makp in(" + s_pk + ")";
                //if (rd_vatay1.Checked) sql += " and a.vantay=1 ";
                //else if (rd_vatay2.Checked) sql += " and a.vantay=0 ";
            }
			DataSet ds=new DataSet();
			ds=d.get_data(sql);
			return ds;
		}	
		private void kiemtra_toa()
		{			
			//
			//string s_cond="and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
            string s_cond = "and to_date(to_char(a.ngay," + stime + ")," + stime + ") between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			//if(manguon.SelectedIndex>=0)s_cond+=" and t.manguon="+manguon.SelectedValue.ToString();
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			string s_rpt="d_pxuatct_kp.rpt";
			//
			s_kho="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++)	if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
			string s_pk="", s_tenpk="";
			if (makp.CheckedItems.Count==0){s_pk=",";s_tenpk=",";}// for(int i=0;i<makp.Items.Count;i++) makp.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<makp.Items.Count;i++)	
			{
				if (makp.GetItemChecked(i)) 
				{
					s_pk+="'"+dtkp.Rows[i]["makp"].ToString()+"',";
					s_tenpk+=dtkp.Rows[i]["tenkp"].ToString()+", ";
				}
			}
            
			//
			//
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";		
			ds=new DataSet();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
						//Cap nhat lai table bhytds
                        /*
                        string s_sql = "insert into " + xxx + ".bhytds select mabn, hoten, namsinh, substr(thon,0,50) from " + user + ".btdbn where mabn in( " +
                            " select mabn from " + xxx + ".bhytkb where mabn not in(select mabn from " + xxx + ".bhytds))";
						d.execute_data(s_sql);
                        */

						if(ds.Tables.Count<=0) 
							ds.Tables.Add(get_dsbn_bhyt(mmyy, s_kho.Substring(0,s_kho.Length-1),s_pk.Substring(0,s_pk.Length-1),s_cond).Tables[0].Copy());
						else
							ds.Merge(get_dsbn_bhyt(mmyy, s_kho.Substring(0,s_kho.Length-1),s_pk.Substring(0,s_pk.Length-1),s_cond).Tables[0].Copy());
					}
				}
			}
			//						
			//
			if(ds.Tables[0].Rows.Count<=0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu."),lan.Change_language_MessageText("BHYT"),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			else
			{
				doiso.Doisototext dd=new doiso.Doisototext();				
				decimal tc=0;
				foreach(DataRow r in ds.Tables[0].Select("sotien<>0")) tc+=decimal.Parse(r["sotien"].ToString());
                if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                ds.WriteXml("..\\..\\dataxml\\d_pxuatct_kp.xml", XmlWriteMode.WriteSchema);//khuyen 03/03/2014
				frmReport f=new frmReport(d,ds.Tables[0],d_userid,s_rpt,"",s_title,kho.Text,s_tenpk.Substring(0,s_tenpk.Trim().Length-1),"","",kho.Text,"","",dd.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
				f.ShowDialog();				
			}
		}
		//binh: Load btdkp_bv: Thong ke toa theo phong kham
		private void Load_btdkp_bv()
		{
			string sql="select * from "+user+".btdkp_bv order by tenkp";
			dtkp=d.get_data(sql).Tables[0].Copy();
			makp.DataSource=dtkp;
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";			
		}

		private void enable_pk(bool ena)
		{
			makp.Enabled=ena;
			chkAll.Enabled=ena;
		}

		private void chkAll_Click(object sender, System.EventArgs e)
		{			
			for(int i=0;i<makp.Items.Count;i++)
			{
				if(chkAll.Checked)
					makp.SetItemCheckState(i,CheckState.Checked);
				else
					makp.SetItemCheckState(i,CheckState.Unchecked);
			}
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1 && madoituong.Items.Count>0) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

        private void f_capnhat_db()
        {
            string asql = "select vantay from xxx.bhytkb where 1=2";
            DataSet lds = d.get_data_mmyy(asql,tu.Text,den.Text,true);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table xxx.bhytkb add vantay numeric (1) default 0";
                d.execute_data_mmyy(asql,tu.Text,den.Text,true);
            }
        }

        private void makp_Click(object sender, EventArgs e)
        {

        }
	}
}
