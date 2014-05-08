using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using doiso;
namespace Duoc
{
	/// <summary>
	/// Summary description for rptThpnhap.
	/// </summary>
	public class rptThpnhap : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker den;
		private AccessData d;
        private int i_nhom, i_madv, i_userid=0;
		private bool bClear=true;
		private string sql,s_kho,user,xxx,stime;
		private DataRow r,r1,r2,r3;
		private DataSet ds=new DataSet();
		private DataTable dtnhom=new DataTable();
		private DataTable dtdmnx=new DataTable();
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox kho;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tendv;
		private System.Windows.Forms.TextBox madv;
		private LibList.List listNX;
		private MaskedTextBox.MaskedTextBox diachi;
		private MaskedTextBox.MaskedTextBox masothue;
		private MaskedTextBox.MaskedTextBox sotk;
		private MaskedTextBox.MaskedTextBox sophieu;
		private MaskedTextBox.MaskedTextBox no;
		private MaskedTextBox.MaskedTextBox co;
		private Doisototext doiso=new Doisototext();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptThpnhap(AccessData acc,int nhom,string kho, int _userid )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptThpnhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tendv = new System.Windows.Forms.TextBox();
            this.diachi = new MaskedTextBox.MaskedTextBox();
            this.masothue = new MaskedTextBox.MaskedTextBox();
            this.sotk = new MaskedTextBox.MaskedTextBox();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.no = new MaskedTextBox.MaskedTextBox();
            this.co = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.madv = new System.Windows.Forms.TextBox();
            this.listNX = new LibList.List();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(130, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(52, 10);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(165, 10);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đơn vị :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(178, 164);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 11;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(250, 164);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 12;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tendv
            // 
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(112, 34);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(368, 21);
            this.tendv.TabIndex = 4;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // diachi
            // 
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(52, 58);
            this.diachi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(428, 21);
            this.diachi.TabIndex = 5;
            // 
            // masothue
            // 
            this.masothue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masothue.Location = new System.Drawing.Point(64, 81);
            this.masothue.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.masothue.Name = "masothue";
            this.masothue.Size = new System.Drawing.Size(136, 21);
            this.masothue.TabIndex = 6;
            // 
            // sotk
            // 
            this.sotk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotk.Location = new System.Drawing.Point(272, 80);
            this.sotk.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotk.Name = "sotk";
            this.sotk.Size = new System.Drawing.Size(208, 21);
            this.sotk.TabIndex = 7;
            // 
            // sophieu
            // 
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(112, 104);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(368, 21);
            this.sophieu.TabIndex = 8;
            // 
            // no
            // 
            this.no.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.Location = new System.Drawing.Point(56, 128);
            this.no.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(272, 21);
            this.no.TabIndex = 9;
            // 
            // co
            // 
            this.co.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co.Location = new System.Drawing.Point(360, 128);
            this.co.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(120, 21);
            this.co.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Mã số thuế :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(200, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Số tài khoản :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-4, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Theo phiếu nhập số :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(24, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Nợ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(328, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "Có :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(272, 10);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(208, 21);
            this.kho.TabIndex = 2;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(243, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 22;
            this.label12.Text = "Kho :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madv
            // 
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(52, 34);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(58, 21);
            this.madv.TabIndex = 3;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(408, 160);
            this.listNX.MatchBufferTimeOut = 1000;
            this.listNX.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNX.Name = "listNX";
            this.listNX.Size = new System.Drawing.Size(75, 17);
            this.listNX.TabIndex = 26;
            this.listNX.TextIndex = -1;
            this.listNX.TextMember = null;
            this.listNX.ValueIndex = -1;
            this.listNX.Visible = false;
            this.listNX.Validated += new System.EventHandler(this.listNX_Validated);
            // 
            // rptThpnhap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(498, 207);
            this.Controls.Add(this.den);
            this.Controls.Add(this.listNX);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.co);
            this.Controls.Add(this.no);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.sotk);
            this.Controls.Add(this.masothue);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptThpnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp phiếu nhập kho";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptThpnhap_MouseMove);
            this.Load += new System.EventHandler(this.rptThpnhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptThpnhap_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			listNX.DisplayMember="MA";
			listNX.ValueMember="TEN";
			dtdmnx=d.get_data("select ma,ten,id,nhomcc,sotk,masothue,diachi from "+user+".d_dmnx where nhom="+i_nhom+" order by stt").Tables[0];
			listNX.DataSource=dtdmnx;

			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			kho.DataSource=d.get_data(sql).Tables[0];

			dtnhom=d.get_data("select * from "+user+".d_nhombc where nhom="+i_nhom+" order by id").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_Thpnhap.xml");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (madv.Text!="")
				{
					i_madv=0;
					r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
					if (r==null)
					{
						MessageBox.Show(
lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
						madv.Focus();
						return;
					}
					i_madv=int.Parse(r["id"].ToString());
				}
				ds.Clear();
				get_nhap();
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
					return;
				}
				decimal tc=0;
				foreach(DataRow r in ds.Tables[0].Rows) tc+=decimal.Parse(r["sotien"].ToString());
				frmReport f=new frmReport(d,ds.Tables[0], i_userid,"d_thpnhap.rpt",(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,tendv.Text,diachi.Text,masothue.Text,sotk.Text,sophieu.Text,kho.Text,no.Text,co.Text,doiso.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
				f.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private string get_sophieu(string so)
		{
			if (so.Substring(so.Length-1)=="+") so=so.Substring(0,so.Length-2);
			string s="";
			for(int i=0;i<so.Length;i++)
			{
				if (so.Substring(i,1)=="+") s+=",";
				else s+=so.Substring(i,1);
			}		
			return (s.Substring(s.Length)==",")?s.Substring(s.Length-1):s;
		}

		private void get_nhap()
		{
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
					if (d.bMmyy(mmyy))
					{
						upd_data(mmyy);
					}
				}
			}
			ds.AcceptChanges();
		}

		private void upd_data(string mmyy)
		{
            xxx = user + mmyy;
			sql="select d.loai as manhom,round(b.sotien+b.sotien*b.vat/100,3) as sotien from "+xxx+".d_nhapll a,"+xxx+".d_nhapct b,"+user+".d_dmbd c,"+user+".d_dmnhom d where a.id=b.id and b.mabd=c.id and c.manhom=d.id and a.nhom="+i_nhom+" and a.ngaysp between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (kho.SelectedIndex!=-1) sql+=" and a.makho="+int.Parse(kho.SelectedValue.ToString());
			if (madv.Text!="") sql+=" and a.madv="+i_madv;
			if (sophieu.Text!="") sql+=" and a.sophieu in ("+get_sophieu(sophieu.Text.Trim())+")";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"manhom="+int.Parse(r["manhom"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dtnhom,"id="+int.Parse(r["manhom"].ToString()));
					r3 = ds.Tables[0].NewRow();
					r3["manhom"]=r["manhom"].ToString();
					if (r2!=null) r3["tennhom"]=r2["ten"].ToString();
					r3["sotien"]=r["sotien"].ToString();
					ds.Tables[0].Rows.Add(r3);
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select("manhom="+int.Parse(r["manhom"].ToString()));
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void rptThpnhap_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				if (kho.Enabled) kho.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tendv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNX.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNX.Visible)	listNX.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tendv_TextChanged(object sender, System.EventArgs e)
		{
			Filter_dmnx(tendv.Text);
			listNX.BrowseToDmnx(tendv,madv,sophieu);
		}

		private void tendv_Validated(object sender, System.EventArgs e)
		{
			if(!listNX.Focused) listNX.Hide();
			if (tendv.Text!="" && madv.Text=="")
			{
				r=d.getrowbyid(dtdmnx,"ten='"+tendv.Text+"'");
				if (r!=null)
				{
					madv.Text=r["ma"].ToString();
					diachi.Text=r["diachi"].ToString();
					sotk.Text=r["sotk"].ToString();
					masothue.Text=r["masothue"].ToString();
				}
			}
		}
		private void madv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
		private void madv_Validated(object sender, System.EventArgs e)
		{
			if (madv.Text!="")
			{
				r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r!=null)
				{
					tendv.Text=r["ten"].ToString();
					diachi.Text=r["diachi"].ToString();
					sotk.Text=r["sotk"].ToString();
					masothue.Text=r["masothue"].ToString();
				}
			}
		}
		private void Filter_dmnx(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNX.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void listNX_Validated(object sender, System.EventArgs e)
		{
			if (madv.Text!="") madv_Validated(null,null);
		}
	}
}
