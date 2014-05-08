using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DllPhonggiuong
{
	public class frmExportTivi : System.Windows.Forms.Form
	{
		private string sql="",sKhoaphong="",sTitle="",sMakp1="",sMakp2="",s_tungay="",s_denngay="", s_user="";
		private int iPhut=0,iGio=0,ii=0,iHeight,iWidth,iKiemtra=20,iChuyenkhoa=10,iSocot=1,iSochia=1,iGio_ck=0,iPhut_ck=0,iGio_upd=0,iPhut_upd=0;
		private bool bKiemtra=false,bChuyenkhoa=false;
		private Button but=new Button();
		private DataTable dt=new DataTable();
		private DataTable dtkp=new DataTable();
		private LibMedi.AccessData m;
		private System.Windows.Forms.Panel pTitle;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pGhichu;
		private System.Windows.Forms.Panel pButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lConguoi;
		private System.Windows.Forms.Label lGiuongtrong;
		private System.Windows.Forms.Label lDattruoc;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label lYeucau;
		private System.ComponentModel.IContainer components;

		public frmExportTivi(LibMedi.AccessData acc)
		{
			InitializeComponent();
			this.m=acc;
		}
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmExportTivi));
			this.pTitle = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pGhichu = new System.Windows.Forms.Panel();
			this.lYeucau = new System.Windows.Forms.Label();
			this.lGiuongtrong = new System.Windows.Forms.Label();
			this.lDattruoc = new System.Windows.Forms.Label();
			this.lConguoi = new System.Windows.Forms.Label();
			this.pButton = new System.Windows.Forms.Panel();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.pTitle.SuspendLayout();
			this.pGhichu.SuspendLayout();
			this.pButton.SuspendLayout();
			this.SuspendLayout();
			// 
			// pTitle
			// 
			this.pTitle.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label2,
																				 this.label1});
			this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pTitle.Name = "pTitle";
			this.pTitle.Size = new System.Drawing.Size(800, 72);
			this.pTitle.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label2.BackColor = System.Drawing.Color.SteelBlue;
			this.label2.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Yellow;
			this.label2.Location = new System.Drawing.Point(0, -1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(800, 33);
			this.label2.TabIndex = 1;
			this.label2.Text = "THÔNG TIN ĐẶT GIƯỜNG DỊCH VỤ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label1.BackColor = System.Drawing.Color.SteelBlue;
			this.label1.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(800, 41);
			this.label1.TabIndex = 0;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pGhichu
			// 
			this.pGhichu.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.lYeucau,
																				  this.lGiuongtrong,
																				  this.lDattruoc,
																				  this.lConguoi});
			this.pGhichu.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pGhichu.Location = new System.Drawing.Point(0, 525);
			this.pGhichu.Name = "pGhichu";
			this.pGhichu.Size = new System.Drawing.Size(800, 48);
			this.pGhichu.TabIndex = 1;
			// 
			// lYeucau
			// 
			this.lYeucau.BackColor = System.Drawing.Color.Blue;
			this.lYeucau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lYeucau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lYeucau.ForeColor = System.Drawing.Color.Black;
			this.lYeucau.Location = new System.Drawing.Point(598, 2);
			this.lYeucau.Name = "lYeucau";
			this.lYeucau.Size = new System.Drawing.Size(200, 45);
			this.lYeucau.TabIndex = 3;
			this.lYeucau.Text = "Giường yêu cầu";
			this.lYeucau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lGiuongtrong
			// 
			this.lGiuongtrong.BackColor = System.Drawing.Color.White;
			this.lGiuongtrong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lGiuongtrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lGiuongtrong.ForeColor = System.Drawing.Color.Black;
			this.lGiuongtrong.Location = new System.Drawing.Point(396, 2);
			this.lGiuongtrong.Name = "lGiuongtrong";
			this.lGiuongtrong.Size = new System.Drawing.Size(200, 45);
			this.lGiuongtrong.TabIndex = 2;
			this.lGiuongtrong.Text = "Giường trống";
			this.lGiuongtrong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lDattruoc
			// 
			this.lDattruoc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(248)), ((System.Byte)(250)), ((System.Byte)(138)));
			this.lDattruoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lDattruoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lDattruoc.ForeColor = System.Drawing.Color.Navy;
			this.lDattruoc.Location = new System.Drawing.Point(194, 2);
			this.lDattruoc.Name = "lDattruoc";
			this.lDattruoc.Size = new System.Drawing.Size(200, 45);
			this.lDattruoc.TabIndex = 1;
			this.lDattruoc.Text = "Giường đã đặt trước";
			this.lDattruoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lConguoi
			// 
			this.lConguoi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(117)), ((System.Byte)(221)));
			this.lConguoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lConguoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lConguoi.ForeColor = System.Drawing.Color.Black;
			this.lConguoi.Location = new System.Drawing.Point(1, 2);
			this.lConguoi.Name = "lConguoi";
			this.lConguoi.Size = new System.Drawing.Size(191, 45);
			this.lConguoi.TabIndex = 0;
			this.lConguoi.Text = "Giường đã có người";
			this.lConguoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pButton
			// 
			this.pButton.BackColor = System.Drawing.Color.Black;
			this.pButton.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.button4,
																				  this.button3,
																				  this.button1,
																				  this.button2});
			this.pButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pButton.Location = new System.Drawing.Point(0, 72);
			this.pButton.Name = "pButton";
			this.pButton.Size = new System.Drawing.Size(800, 453);
			this.pButton.TabIndex = 2;
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Blue;
			this.button4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.ForeColor = System.Drawing.Color.White;
			this.button4.Location = new System.Drawing.Point(320, 344);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(168, 64);
			this.button4.TabIndex = 2;
			this.button4.Text = "button1";
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.White;
			this.button3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.Navy;
			this.button3.Location = new System.Drawing.Point(320, 256);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(168, 64);
			this.button3.TabIndex = 1;
			this.button3.Text = "button1";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(117)), ((System.Byte)(221)));
			this.button1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(320, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 64);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(248)), ((System.Byte)(250)), ((System.Byte)(138)));
			this.button2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.Navy;
			this.button2.Location = new System.Drawing.Point(320, 168);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(168, 64);
			this.button2.TabIndex = 0;
			this.button2.Text = "button1";
			// 
			// frmExportTivi
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(800, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pButton,
																		  this.pGhichu,
																		  this.pTitle});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmExportTivi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thông tin đặt giường dịch vụ";
			this.SizeChanged += new System.EventHandler(this.frmExportTivi_SizeChanged);
			this.Load += new System.EventHandler(this.frmExportTivi_Load);
			this.pTitle.ResumeLayout(false);
			this.pGhichu.ResumeLayout(false);
			this.pButton.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmExportTivi_Load(object sender, System.EventArgs e)
		{
			int i=0;
            s_user = m.user;
			if(DateTime.Now.Day<10) i=-1;
			s_tungay="01/"+DateTime.Now.AddMonths(i).Month.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Year.ToString();
			s_denngay=m.ngayhienhanh_server.Substring(0,10);
			DataSet dsxml=new DataSet();
			if(System.IO.File.Exists(@"..\..\..\xml\g_thongso.xml"))
			{		
				dsxml.ReadXml(@"..\..\..\xml\g_thongso.xml");
				iKiemtra=int.Parse(dsxml.Tables[0].Rows[0]["c03"].ToString());
				bKiemtra=int.Parse(dsxml.Tables[0].Rows[0]["c02"].ToString())==1;
				bChuyenkhoa=int.Parse(dsxml.Tables[0].Rows[0]["c05"].ToString())==1;
				if(!bChuyenkhoa) sMakp2=dsxml.Tables[0].Rows[0]["c06"].ToString();
				iChuyenkhoa=int.Parse(dsxml.Tables[0].Rows[0]["c01"].ToString());
				sTitle=dsxml.Tables[0].Rows[0]["c04"].ToString().ToUpper();
			}
			iHeight=pButton.Height;
			iWidth=this.Width;
			iGio=DateTime.Now.Hour;
			iPhut=DateTime.Now.Minute;
			iGio_ck=DateTime.Now.Hour;
			iPhut_ck=DateTime.Now.Minute;
			iGio_upd=DateTime.Now.Hour;
			iPhut_upd=DateTime.Now.Minute;
            dtkp = m.get_data("select distinct b.makp,a.tenkp from " + s_user + ".btdkp_bv a," + s_user + ".dmphong b where a.makp=b.makp and b.dichvu=1 order by b.makp").Tables[0];
			if(bChuyenkhoa) Chuyenkhoa();
			else 
			{
				sKhoaphong=m.getrowbyid(dtkp,"makp='"+sMakp2+"'")["tenkp"].ToString();
				load_grid();
			}
			load();
			timer1.Enabled=true;
			if(sTitle=="") sTitle="HÂN HẠNH PHỤC VỤ";
			this.Location=new Point(1024,0);
			this.WindowState=System.Windows.Forms.FormWindowState.Maximized;
		}
		private void load_grid()
		{
			sql="select a.id,a.stt,case when instr(a.ma,'TG')=0 then 0 else 1 end tgoi,decode(a.ghichu,null,trim(a.ten),trim(a.ten)||'('||a.ghichu||')') as tengiuong,trim(b.ten) as tenphong,a.tinhtrang";
            sql += " from " + s_user + ".dmgiuong a," + s_user + ".dmphong b where a.idphong=b.id and b.dichvu=1 and instr(a.ma,'TG')=0";// and b.makp='44'";
			if(sMakp2!="") sql+=" and b.makp='"+sMakp2+"'";
			sql+=" order by b.ten,a.stt";
			dt=m.get_data(sql).Tables[0];
		}
		private void load()
		{
			pButton.Controls.Clear();
			int t=5,l=5,j=0,index=0;
			if(dt.Rows.Count%6!=0) iSochia=dt.Rows.Count/6+1;
			else iSochia=dt.Rows.Count/6;
			iSocot=1;
			foreach(DataRow r in dt.Rows)
			{
				if (j%iSochia==0 && j!=0)
				{
					t=5;
					l+=135;
				    index++;
					iSocot++;
				}
				Addchkbox(r["tenphong"].ToString(),r["tengiuong"].ToString().Replace("số",""),r["id"].ToString(),int.Parse(r["tinhtrang"].ToString()),t,l,index);
				t+=32;
				j++;
			}
			pButton.AutoScroll=true;
		}
		public void Addchkbox(string tenphong,string tengiuong,string s_id,int tt,int t,int l,int index)
		{
			but=new Button();
			but.Text=tenphong+"\n"+tengiuong;
			but.Name=tt.ToString();
			but.Tag=s_id;
			but.Top=t;
			but.Left=l;
			but.TabIndex=index;
			switch(tt)
			{
				case 0:
					but.BackColor=Color.White;
					but.ForeColor=Color.Black;
					break;
				case 1:
					but.BackColor=Color.FromArgb(248, 250, 138);
					but.ForeColor=Color.Navy;
					break;
				case 2:
					but.BackColor=Color.FromArgb(255, 117, 221);
					but.ForeColor=Color.Black;
					break;
				case 3:
					but.BackColor=Color.Blue;
					but.ForeColor=Color.White;
					break;
			}
			if(index==0) but.KeyDown += new System.Windows.Forms.KeyEventHandler(this.but_KeyDown);
			but.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			but.Size = new System.Drawing.Size(130, 30);
			but.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pButton.Controls.Add(but);
			pButton.Refresh();
			this.Refresh();
		}

		private void frmExportTivi_SizeChanged(object sender, System.EventArgs e)
		{
			int iCountX=0,iCountY=0,iTabindex=0,iLocY=5;
			int iChangeX=(this.Width-iWidth)/iSocot;
			int iChangeY=(this.Height-iHeight)/iSochia;
			foreach(Control ctr in pButton.Controls)
			{
				if(ctr.GetType()==typeof(Button))
				{
					if(ctr.TabIndex==0)
					{
						ctr.Width=130+iChangeX;
						ctr.Height=30+iChangeY;
						ctr.Location=new Point(5,(32+iChangeY)*iCountY+5);
						iCountY++;
					}
					else
					{
						if(iTabindex==ctr.TabIndex)
						{
							iLocY=(32+iChangeY)*iCountY+5;
							iCountY++;
						}
						else if(ctr.TabIndex!=iTabindex) 
						{
							iCountX++;iLocY=5;iCountY=1;
						}
						iTabindex=ctr.TabIndex;
						ctr.Width=130+iChangeX;
						ctr.Height=30+iChangeY;
						ctr.Location=new Point((132+iChangeX)*iCountX+5,iLocY);
					}
				}
			}
			//Resize Ghi Chu
			int iiWidth=(this.Width-800)/4;
			lDattruoc.Width=200+iiWidth;
			lConguoi.Width=191+iiWidth;
			lGiuongtrong.Width=200+iiWidth;
			lYeucau.Width=200+iiWidth;
			lDattruoc.Location=new Point(iiWidth+194,2);
			lGiuongtrong.Location=new Point(iiWidth*2+396,2);
			lYeucau.Location=new Point(iiWidth*3+598,2);
			//
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			bool be=false;
			string ss=(sKhoaphong+" "+sTitle).ToUpper();
			if(ii==ss.Length)
			{
				ii=0;label1.Text="";
			}
			if(ii<=ss.Length)
			{
				label1.Text+=ss[ii].ToString().ToUpper();
				ii++;
			}
			if(DateTime.Now.Hour==iGio_ck && DateTime.Now.Minute-iPhut_ck==iChuyenkhoa && bChuyenkhoa)
			{
				be=true;
				iGio_ck=DateTime.Now.Hour;
				iPhut_ck=DateTime.Now.Minute;
				Chuyenkhoa();
				load();
				frmExportTivi_SizeChanged(null,null);
				if(sMakp1.Split(',').Length==dtkp.Rows.Count) sMakp1="";
			}
			if(DateTime.Now.Hour==iGio_upd && DateTime.Now.Minute-iPhut_upd==iKiemtra && bKiemtra)
			{
				iGio_upd=DateTime.Now.Hour;iPhut_upd=DateTime.Now.Minute;
				upd_tinhtrang_giuong();
			}
			if((DateTime.Now.Hour==iGio && DateTime.Now.Minute-iPhut==1)||DateTime.Now.Hour>iGio)
			{
				iGio=DateTime.Now.Hour;
				iPhut=DateTime.Now.Minute;
				if(!be)
				{
					load_grid();
					load();frmExportTivi_SizeChanged(null,null);
				}
			}
		}
		private void Chuyenkhoa()
		{
			string exp=(sMakp1=="")?"true":"makp not in ("+sMakp1+")";
			foreach(DataRow r in dtkp.Select(exp))
			{
				sMakp1+=",'"+r["makp"].ToString()+"',";
				sMakp2=r["makp"].ToString();
				sKhoaphong=r["tenkp"].ToString();
				load_grid();
				break;
			}
			sMakp1=sMakp1.Trim().Trim(',').Trim();
		}
		private void upd_tinhtrang_giuong()
		{
			//Kiem tra trang thai giuong
            m.execute_data("update " + s_user + ".dmgiuong set tinhtrang= 1,soluong = 1 where id in(select idgiuong from " + s_user + ".datgiuong where den is null)");
            m.execute_data("update " + s_user + ".dmgiuong set tinhtrang= 2,soluong = 1 where id in(select idgiuong from " + s_user + ".theodoigiuong where den is null)");
            sql = "select a.idgiuong,to_char(den,'dd/mm/yyyy hh24:mi') ngayra,b.ma,b.idphong from " + s_user + ".theodoigiuong a,dmgiuong b,(select idgiuong from " + s_user + ".theodoigiuong where den is null union all select idgiuong from " + s_user + ".datgiuong where den is null) c where a.idgiuong=b.id and a.den is not null and a.idgiuong=c.idgiuong(+) and c.idgiuong is null and instr(b.ma,'TG')>0 and to_date(a.den,'dd/mm/yy') between to_date('" + s_tungay + "','dd/mm/yy') and to_date('" + s_denngay + "','dd/mm/yy')";
			foreach(DataRow row in m.get_data(sql).Tables[0].Rows)
			{
				int idex1=row["ma"].ToString().IndexOf("TG")+2;
				int idex2=row["ma"].ToString().IndexOf("/");
				string s_stt=row["ma"].ToString().Substring(idex1,idex2-idex1)+","+row["ma"].ToString().Substring(idex2+1);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0,soluong=0 where tinhtrang<>3 and id=" + int.Parse(row["idgiuong"].ToString()));
                foreach (DataRow row1 in m.get_data("select * from " + s_user + ".dmgiuong where idphong=" + int.Parse(row["idphong"].ToString()) + " and stt in(" + s_stt + ")").Tables[0].Rows)
                    m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0,soluong=0 where tinhtrang<>3 and id=" + int.Parse(row1["id"].ToString()) + " and id not in(select idgiuong from " + s_user + ".theodoigiuong where den is null union all select idgiuong from " + s_user + ".datgiuong where den is null)");
			}
            sql = "select a.idgiuong,to_char(a.den,'dd/mm/yyyy hh24:mi') ngayra,b.ma,b.idphong from " + s_user + ".xuatvien xv, " + s_user + ".theodoigiuong a, " + s_user + ".dmgiuong b,(select idgiuong from " + s_user + ".theodoigiuong where den is null union all select idgiuong from " + s_user + ".datgiuong where den is null) c where xv.maql=a.maql and a.idgiuong=b.id and a.den is not null and a.idgiuong=c.idgiuong(+) and c.idgiuong is null and to_char(a.den,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
			foreach(DataRow row in m.get_data(sql).Tables[0].Rows)
			{
				string file="";
				if(m.bNgaygio(row["ngayra"].ToString(),m.ngayhienhanh_server))
				{
                    m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=2 where tinhtrang<>3 and id=" + int.Parse(row["idgiuong"].ToString()));
					file="tinhtrang=2";
				}
				else
				{
                    m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0,soluong=0 where tinhtrang<>3 and id=" + int.Parse(row["idgiuong"].ToString()) + " and idphong not in(select idphong from " + s_user + ".dmgiuong where idphong=" + int.Parse(row["idphong"].ToString()) + " and instr(ma,'TG')>0 and tinhtrang<>3)");
					file="tinhtrang=0,soluong=0";
				}
				if(row["ma"].ToString().IndexOf("TG")!=-1)
				{
					int idex1=row["ma"].ToString().IndexOf("TG")+2;
					int idex2=row["ma"].ToString().IndexOf("/");
					string s_stt=row["ma"].ToString().Substring(idex1,idex2-idex1)+","+row["ma"].ToString().Substring(idex2+1);
                    m.execute_data("update " + s_user + ".dmgiuong set " + file + " where tinhtrang<>3 and idphong=" + int.Parse(row["idphong"].ToString()) + " and stt in(" + s_stt + ") and id not in(select idgiuong from " + s_user + ".datgiuong where den is null union all select idgiuong from " + s_user + ".theodoigiuong where den is null)");
				}
			}
            sql = "select a.*,b.ma,b.idphong from " + s_user + ".theodoigiuong a, " + s_user + ".dmgiuong b where a.idgiuong=b.id and a.den is null and instr(b.ma,'TG')>0";
			foreach(DataRow row in m.get_data(sql).Tables[0].Rows)
			{
				int idex1=row["ma"].ToString().IndexOf("TG")+2;
				int idex2=row["ma"].ToString().IndexOf("/");
				string s_stt=row["ma"].ToString().Substring(idex1,idex2-idex1)+","+row["ma"].ToString().Substring(idex2+1);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=2 where tinhtrang<>3 and idphong=" + int.Parse(row["idphong"].ToString()) + " and stt in(" + s_stt + ")");
			}
            sql = "select a.*,b.ma,b.idphong from " + s_user + ".datgiuong a, " + s_user + ".dmgiuong b where a.idgiuong=b.id and a.den is null and instr(b.ma,'TG')>0";
			foreach(DataRow row in m.get_data(sql).Tables[0].Rows)
			{
				int idex1=row["ma"].ToString().IndexOf("TG")+2;
				int idex2=row["ma"].ToString().IndexOf("/");
				string s_stt=row["ma"].ToString().Substring(idex1,idex2-idex1)+","+row["ma"].ToString().Substring(idex2+1);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=1 where tinhtrang<>3 and idphong=" + int.Parse(row["idphong"].ToString()) + " and stt in(" + s_stt + ")");
			}
            m.execute_data("update " + s_user + ".dmgiuong set ghichu='' where tinhtrang=0");
			//End kiem tra
		}
		private void reload_button()
		{
			load_grid();
			foreach(Control ctr in pButton.Controls)
			{
				if(ctr.GetType()==typeof(Button))
				{
					DataRow r=m.getrowbyid(dt,"id="+ctr.Tag.ToString());
					if(r!=null)// && r["tinhtrang"].ToString()!=ctr.Name.ToString()
					{
						switch(r["tinhtrang"].ToString())
						{
							case "0":
								ctr.BackColor=Color.White;
								ctr.ForeColor=Color.Black;
								ctr.Refresh();
								pButton.Refresh();
								break;
							case "1":
								but.BackColor=Color.FromArgb(248, 250, 138);
								ctr.ForeColor=Color.Navy;
								ctr.Refresh();
								pButton.Refresh();
								break;
							case "2":
								but.BackColor=Color.FromArgb(255, 117, 221);
								ctr.ForeColor=Color.Black;
								ctr.Refresh();
								pButton.Refresh();
								break;
						}
					}
					this.Refresh();
				}
			}
			pButton.Refresh();this.Refresh();
		}

		private void but_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
				this.Close();
		}
	}
}
