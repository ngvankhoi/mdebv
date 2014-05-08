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
	public class rptLaigop : System.Windows.Forms.Form
	{
		//
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom = 0, i_userid=0;
		private string sql,s_kho,s_makho,user,xxx,stime;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private	doiso.Doisototext dd=new doiso.Doisototext();

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptLaigop(AccessData acc,int nhom,string kho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptLaigop));
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(139, 136);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(132, 5);
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
            this.kho.Location = new System.Drawing.Point(52, 29);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(200, 100);
            this.kho.TabIndex = 2;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butXem
            // 
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(69, 136);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 3;
            this.butXem.Text = "&In";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(52, 5);
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
            this.den.Location = new System.Drawing.Point(172, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rptLaigop
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(260, 172);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptLaigop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng kết lãi gộp";
            this.Load += new System.EventHandler(this.rptLaigop_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptLaigop_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			dt=d.get_data("select * from "+user+".d_dmnhom where nhom="+i_nhom+" order by stt").Tables[0];
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
			ds.ReadXml("..\\..\\..\\xml\\d_laigop.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_laigop.xml");
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
			kiemtra_toa();
		}	

		private void get_data()
		{
			ds.Clear();
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			DataRow r1,r2,r3;
			DataRow [] dr;
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
                        xxx = user + mmyy;
						sql=" select c.manhom,sum(b.soluong*t.giamua) as sotienmua,sum(b.soluong*b.giaban) as sotienban ";
						sql+=" from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+user+".d_dmbd c,"+xxx+".d_theodoi t ";
						sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id ";
						if(s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
						sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						sql+=" group by c.manhom";
						foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
						{
							r1=d.getrowbyid(ds.Tables[0],"manhom="+int.Parse(r["manhom"].ToString()));
							if (r1==null)
							{
								r2=d.getrowbyid(dt,"id="+int.Parse(r["manhom"].ToString()));
								if (r2!=null)
								{
									r3=ds.Tables[0].NewRow();
									r3["manhom"]=r["manhom"].ToString();
									r3["tennhom"]=r2["ten"].ToString();
									r3["mua"]=r["sotienmua"].ToString();
									r3["ban"]=r["sotienban"].ToString();
									ds.Tables[0].Rows.Add(r3);
								}
							}
							else 
							{
								dr=ds.Tables[0].Select("manhom="+int.Parse(r["manhom"].ToString()));
								if (dr.Length>0)
								{
									dr[0]["mua"]=decimal.Parse(dr[0]["mua"].ToString())+decimal.Parse(r["sotienmua"].ToString());
									dr[0]["ban"]=decimal.Parse(dr[0]["ban"].ToString())+decimal.Parse(r["sotienban"].ToString());
								}
							}
						}
					}
				}
			}
		}

		private void kiemtra_toa()
		{			
			string s_tenkho="",s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			s_kho="";
			if (kho.CheckedItems.Count>0) 
				for(int i=0;i<kho.Items.Count;i++)
					if (kho.GetItemChecked(i)) 
					{
						s_kho+=dtkho.Rows[i]["id"].ToString()+",";
						s_tenkho+=dtkho.Rows[i]["ten"].ToString()+",";
					}
			get_data();
			if(ds.Tables[0].Rows.Count<=0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu."),d.Msg,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			else
			{
				dsxml.Clear();
				dsxml.Merge(ds.Tables[0].Select("true","tennhom"));
				frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,"d_laigop.rpt","",s_title,s_tenkho,"","","",s_tenkho,"","","");
				f.ShowDialog();				
			}
		}
				
	}
}
