using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMediFox;

namespace Medisoft
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMedi_SYT : System.Windows.Forms.Form
	{
        Language lan = new Language();
		private System.Windows.Forms.Button button1;
		private AccessData m=new AccessData();
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckBox btdnn;
		private System.Windows.Forms.CheckBox btdkp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox server;
		private System.Windows.Forms.Label label3;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.CheckBox nhaptonghop;
		private System.Windows.Forms.CheckBox benhannt;
		private System.Windows.Forms.CheckBox benhanngtr;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMedi_SYT()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMedi_SYT));
			this.button1 = new System.Windows.Forms.Button();
			this.lbl = new System.Windows.Forms.Label();
			this.tu = new System.Windows.Forms.DateTimePicker();
			this.den = new System.Windows.Forms.DateTimePicker();
			this.btdnn = new System.Windows.Forms.CheckBox();
			this.btdkp = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.benhannt = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.server = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.nhaptonghop = new System.Windows.Forms.CheckBox();
			this.benhanngtr = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(63, 171);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 25);
			this.button1.TabIndex = 9;
			this.button1.Text = "&Chuyển";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lbl
			// 
			this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl.ForeColor = System.Drawing.Color.Red;
			this.lbl.Location = new System.Drawing.Point(14, 136);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(252, 23);
			this.lbl.TabIndex = 4;
			this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tu
			// 
			this.tu.CustomFormat = "dd/MM/yyyy";
			this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tu.Location = new System.Drawing.Point(64, 16);
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(88, 20);
			this.tu.TabIndex = 1;
			this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// den
			// 
			this.den.CustomFormat = "dd/MM/yyyy";
			this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.den.Location = new System.Drawing.Point(184, 16);
			this.den.Name = "den";
			this.den.Size = new System.Drawing.Size(88, 20);
			this.den.TabIndex = 3;
			this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// btdnn
			// 
			this.btdnn.Location = new System.Drawing.Point(152, 66);
			this.btdnn.Name = "btdnn";
			this.btdnn.Size = new System.Drawing.Size(88, 24);
			this.btdnn.TabIndex = 5;
			this.btdnn.Text = "Nghề nghiệp";
			this.btdnn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// btdkp
			// 
			this.btdkp.Location = new System.Drawing.Point(64, 66);
			this.btdkp.Name = "btdkp";
			this.btdkp.Size = new System.Drawing.Size(88, 24);
			this.btdkp.TabIndex = 4;
			this.btdkp.Text = "Khoa/phòng";
			this.btdkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ ngày :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(152, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "đến :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// benhannt
			// 
			this.benhannt.Checked = true;
			this.benhannt.CheckState = System.Windows.Forms.CheckState.Checked;
			this.benhannt.Location = new System.Drawing.Point(64, 84);
			this.benhannt.Name = "benhannt";
			this.benhannt.Size = new System.Drawing.Size(72, 24);
			this.benhannt.TabIndex = 6;
			this.benhannt.Text = "Nội trú";
			this.benhannt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(143, 171);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 25);
			this.button2.TabIndex = 10;
			this.button2.Text = "&Kết thúc";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.Location = new System.Drawing.Point(248, 38);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(24, 23);
			this.button3.TabIndex = 24;
			this.button3.Text = "...";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// server
			// 
			this.server.BackColor = System.Drawing.SystemColors.HighlightText;
			this.server.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.server.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.server.Location = new System.Drawing.Point(64, 39);
			this.server.Name = "server";
			this.server.Size = new System.Drawing.Size(180, 23);
			this.server.TabIndex = 23;
			this.server.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 22;
			this.label3.Text = "Thư mục :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nhaptonghop
			// 
			this.nhaptonghop.Location = new System.Drawing.Point(64, 104);
			this.nhaptonghop.Name = "nhaptonghop";
			this.nhaptonghop.TabIndex = 8;
			this.nhaptonghop.Text = "Nhập tổng hợp";
			// 
			// benhanngtr
			// 
			this.benhanngtr.Checked = true;
			this.benhanngtr.CheckState = System.Windows.Forms.CheckState.Checked;
			this.benhanngtr.Location = new System.Drawing.Point(152, 84);
			this.benhanngtr.Name = "benhanngtr";
			this.benhanngtr.Size = new System.Drawing.Size(72, 24);
			this.benhanngtr.TabIndex = 7;
			this.benhanngtr.Text = "Ngoại trú";
			// 
			// frmMedi_SYT
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 213);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.benhanngtr,
																		  this.nhaptonghop,
																		  this.button3,
																		  this.server,
																		  this.label3,
																		  this.button2,
																		  this.benhannt,
																		  this.label2,
																		  this.label1,
																		  this.btdkp,
																		  this.btdnn,
																		  this.den,
																		  this.tu,
																		  this.lbl,
																		  this.button1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMedi_SYT";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chuyển số liệu từ Medisoft-> SYT 6.0";
			this.Load += new System.EventHandler(this.frmMedi_SYT_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		private void button1_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			if (btdkp.Checked)
			{
				foreach(DataRow r in m.get_data_ora("select * from btdkp_bv").Tables[0].Rows)
					m.upd_btdkp(r["makp"].ToString(),r["tenkp"].ToString());
			}
			if (btdnn.Checked)
			{
				foreach(DataRow r in m.get_data_ora("select * from btdnn_bv").Tables[0].Rows)
					m.upd_btdnn(r["mann"].ToString(),r["tennn"].ToString());
			}
			if (benhannt.Checked)
			{
				string sql="select a.mabn,a.hoten,a.namsinh,a.mann,a.phai,a.mann,a.madantoc,a.sonha,a.thon,a.maqu,";
				sql+=" b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') ngayvao,b.maicd maicdvv,b.madoituong,b.makp,";
				sql+=" to_char(c.ngay,'dd/mm/yyyy hh24:mi') ngayra,";
				sql+=" c.maicd maicdrv,c.ttlucrv,nvl(d.sothe,'') sothe,b.loaiba ";
				sql+=" from btdbn a,benhandt b,xuatvien c,bhyt d ";
				sql+=" where a.mabn=b.mabn and b.maql=c.maql and b.maql=d.maql(+)";
				sql+=" and b.loaiba=1";
				sql+=" and to_date(c.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
				int i=1,irec;
				DataTable dt=m.get_data_ora(sql).Tables[0];
				irec=dt.Rows.Count;
				foreach(DataRow r in dt.Rows)
				{
					lbl.Text=r["mabn"].ToString()+"->"+i.ToString()+"/"+irec.ToString();
					lbl.Refresh();
					m.upd_btdbn(r["mabn"].ToString(),r["hoten"].ToString(),r["namsinh"].ToString(),int.Parse(r["phai"].ToString()),r["mann"].ToString(),r["madantoc"].ToString(),r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim(),r["maqu"].ToString(),r["sothe"].ToString());
					if (r["loaiba"].ToString()=="1")
						m.upd_benhandt(long.Parse(r["maql"].ToString()),r["mabn"].ToString(),r["makp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),int.Parse(r["madoituong"].ToString()),r["maicdvv"].ToString(),r["maicdrv"].ToString(),int.Parse(r["ttlucrv"].ToString()));
					else
						m.upd_benhancc(long.Parse(r["maql"].ToString()),r["mabn"].ToString(),r["makp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),int.Parse(r["madoituong"].ToString()),r["maicdvv"].ToString(),r["maicdrv"].ToString(),int.Parse(r["ttlucrv"].ToString()));
					i++;
				}
			}
			if (benhanngtr.Checked)
			{
				string sql="select a.mabn,a.hoten,a.namsinh,a.mann,a.phai,a.mann,a.madantoc,a.sonha,a.thon,a.maqu,";
				sql+=" b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') ngayvao,b.maicd maicdvv,b.madoituong,b.makp,";
				sql+=" to_char(c.ngay,'dd/mm/yyyy hh24:mi') ngayra,";
				sql+=" c.maicd maicdrv,c.ttlucrv,nvl(d.sothe,'') sothe,b.loaiba ";
				sql+=" from btdbn a,benhandt b,xuatvien c,bhyt d ";
				sql+=" where a.mabn=b.mabn and b.maql=c.maql and b.maql=d.maql(+)";
				sql+=" and b.loaiba<>1";
				sql+=" and to_date(c.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
				int i=1,irec;
				DataTable dt=m.get_data_ora(sql).Tables[0];
				irec=dt.Rows.Count;
				foreach(DataRow r in dt.Rows)
				{
					lbl.Text=r["mabn"].ToString()+"->"+i.ToString()+"/"+irec.ToString();
					lbl.Refresh();
					m.upd_btdbn(r["mabn"].ToString(),r["hoten"].ToString(),r["namsinh"].ToString(),int.Parse(r["phai"].ToString()),r["mann"].ToString(),r["madantoc"].ToString(),r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim(),r["maqu"].ToString(),r["sothe"].ToString());
					if (r["loaiba"].ToString()=="1")
						m.upd_benhandt(long.Parse(r["maql"].ToString()),r["mabn"].ToString(),r["makp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),int.Parse(r["madoituong"].ToString()),r["maicdvv"].ToString(),r["maicdrv"].ToString(),int.Parse(r["ttlucrv"].ToString()));
					else
						m.upd_benhancc(long.Parse(r["maql"].ToString()),r["mabn"].ToString(),r["makp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),int.Parse(r["madoituong"].ToString()),r["maicdvv"].ToString(),r["maicdrv"].ToString(),int.Parse(r["ttlucrv"].ToString()));
					i++;
				}
			}
			if (nhaptonghop.Checked) upd_tonghop();
			Cursor=Cursors.Default;
			MessageBox.Show("Đã cập nhật xong !");
		}

		private void upd_tonghop()
		{
			string sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_05 a";
			sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bhdskss1 where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_05(int.Parse(r["ma"].ToString()),r["ngaynhap"].ToString(),decimal.Parse(r["soluong"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_06 a";
			sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bhdcls1 where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_06(int.Parse(r["ma"].ToString()),r["ngaynhap"].ToString(),decimal.Parse(r["c01"].ToString()),decimal.Parse(r["c02"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_07 a";
			sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bdbv1 where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_07(int.Parse(r["ma"].ToString()),r["ngaynhap"].ToString(),decimal.Parse(r["soluong"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_08 a";
			sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bttbyt1 where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_08(int.Parse(r["ma"].ToString()),r["ngaynhap"].ToString(),decimal.Parse(r["c01"].ToString()),decimal.Parse(r["c02"].ToString()),decimal.Parse(r["c03"].ToString()),decimal.Parse(r["c04"].ToString()),decimal.Parse(r["c05"].ToString()),decimal.Parse(r["c06"].ToString()),decimal.Parse(r["c07"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_091 a";
			sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bhdcdt1 where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_091(int.Parse(r["ma"].ToString()),r["ngaynhap"].ToString(),decimal.Parse(r["tongso"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_092 a";
			sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bhdnckh where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_092(int.Parse(r["ma"].ToString()),r["ngaynhap"].ToString(),m.Hoten_khongdau(r["ten"].ToString()),decimal.Parse(r["c01"].ToString()),decimal.Parse(r["c02"].ToString()),decimal.Parse(r["c03"].ToString()),decimal.Parse(r["c04"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_101 a";
			sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bhdtc1 where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_101(int.Parse(r["ma"].ToString()),r["ngaynhap"].ToString(),decimal.Parse(r["sotien"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_1021 a";
			sql+=" where ma>1 and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bhdtcvp1 where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_1021(int.Parse(r["ma"].ToString())-1,r["ngaynhap"].ToString(),decimal.Parse(r["vienphi"].ToString()),decimal.Parse(r["bhyt"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_1022 a";
			sql+=" where ma>1 and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_1022(int.Parse(r["ma"].ToString())+21,r["ngaynhap"].ToString(),decimal.Parse(r["sotien"].ToString()));
			//
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaynhap from bieu_103 a";
			sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			m.execute_data_qlba("delete from bhdtckt1 where between(ngaynhap,ctod('"+m.StringToMMDDYYYY(tu.Text)+"'),ctod('"+m.StringToMMDDYYYY(den.Text)+"'))");
			foreach(DataRow r in m.get_data_ora(sql).Tables[0].Rows) m.upd_103(int.Parse(r["ma"].ToString()),r["ngaynhap"].ToString(),decimal.Parse(r["c01"].ToString()),decimal.Parse(r["c02"].ToString()),decimal.Parse(r["c03"].ToString()),decimal.Parse(r["c04"].ToString()),decimal.Parse(r["c05"].ToString()),decimal.Parse(r["c06"].ToString()));
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			frmThumuc f=new frmThumuc(server.Text,"Chọn thư mục CSDL Fox của chương trình Sở Y Tế TPHCM",0);
			f.ShowDialog();
			server.Text=f.s_dir;
			ds.ReadXml("..\\..\\..\\xml\\maincode.xml");
			ds.Tables[0].Rows[0]["Fox"]=server.Text;
			ds.WriteXml("..\\..\\..\\xml\\maincode.xml");
		}

		private void frmMedi_SYT_Load(object sender, System.EventArgs e)
		{
			server.Text=m.Maincode("Fox").ToString().Trim();
		}

	}
}
