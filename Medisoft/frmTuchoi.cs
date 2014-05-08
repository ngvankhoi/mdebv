using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSuamabn.
	/// </summary>
	public class frmTuchoi : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn1;
		private System.Windows.Forms.TextBox mabn2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private DataSet dsxml=new DataSet();
		private string mabn,sql,user;
		private int i_userid;
		private System.Windows.Forms.TextBox tqx;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox lydo;
		private System.Windows.Forms.ComboBox cbkhoa;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkdoikhoanhapvien;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTuchoi(LibMedi.AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;i_userid=userid;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTuchoi));
			this.label1 = new System.Windows.Forms.Label();
			this.mabn1 = new System.Windows.Forms.TextBox();
			this.mabn2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.hoten = new System.Windows.Forms.TextBox();
			this.namsinh = new System.Windows.Forms.TextBox();
			this.diachi = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tqx = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.mann = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.butSua = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.ngayvao = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lydo = new System.Windows.Forms.ComboBox();
			this.cbkhoa = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.chkdoikhoanhapvien = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(21, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mabn1
			// 
			this.mabn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn1.Location = new System.Drawing.Point(96, 16);
			this.mabn1.MaxLength = 2;
			this.mabn1.Name = "mabn1";
			this.mabn1.Size = new System.Drawing.Size(24, 21);
			this.mabn1.TabIndex = 1;
			this.mabn1.Text = "";
			this.mabn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
			this.mabn1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn1_KeyPress);
			this.mabn1.Validated += new System.EventHandler(this.mabn1_Validated);
			// 
			// mabn2
			// 
			this.mabn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn2.Location = new System.Drawing.Point(121, 16);
			this.mabn2.MaxLength = 6;
			this.mabn2.Name = "mabn2";
			this.mabn2.Size = new System.Drawing.Size(46, 21);
			this.mabn2.TabIndex = 2;
			this.mabn2.Text = "";
			this.mabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
			this.mabn2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn2_KeyPress);
			this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(164, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(212, 16);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(220, 21);
			this.hoten.TabIndex = 4;
			this.hoten.Text = "";
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(488, 16);
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(32, 21);
			this.namsinh.TabIndex = 6;
			this.namsinh.Text = "";
			// 
			// diachi
			// 
			this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.diachi.Enabled = false;
			this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diachi.Location = new System.Drawing.Point(320, 40);
			this.diachi.Name = "diachi";
			this.diachi.Size = new System.Drawing.Size(200, 21);
			this.diachi.TabIndex = 10;
			this.diachi.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(272, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Địa chỉ :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tqx
			// 
			this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tqx.Enabled = false;
			this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tqx.Location = new System.Drawing.Point(96, 64);
			this.tqx.Name = "tqx";
			this.tqx.Size = new System.Drawing.Size(424, 21);
			this.tqx.TabIndex = 12;
			this.tqx.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "Tỉnh,Quận,P.Xã :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mann
			// 
			this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mann.Enabled = false;
			this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mann.Location = new System.Drawing.Point(96, 40);
			this.mann.Name = "mann";
			this.mann.Size = new System.Drawing.Size(176, 21);
			this.mann.TabIndex = 8;
			this.mann.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(13, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 7;
			this.label6.Text = "Ng nghiệp :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(192, 144);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(70, 25);
			this.butSua.TabIndex = 17;
			this.butSua.Text = "      &Lưu";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(264, 144);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(70, 25);
			this.butKetthuc.TabIndex = 18;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(37, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 13;
			this.label7.Text = "Ngày vào :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ngayvao
			// 
			this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayvao.Location = new System.Drawing.Point(96, 88);
			this.ngayvao.Name = "ngayvao";
			this.ngayvao.Size = new System.Drawing.Size(176, 21);
			this.ngayvao.TabIndex = 14;
			this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(256, 88);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 23);
			this.label10.TabIndex = 15;
			this.label10.Text = "Lý do :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(424, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Năm sinh :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lydo
			// 
			this.lydo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lydo.Location = new System.Drawing.Point(320, 88);
			this.lydo.Name = "lydo";
			this.lydo.Size = new System.Drawing.Size(200, 21);
			this.lydo.TabIndex = 16;
			this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
			// 
			// cbkhoa
			// 
			this.cbkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbkhoa.Enabled = false;
			this.cbkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbkhoa.Location = new System.Drawing.Point(320, 112);
			this.cbkhoa.Name = "cbkhoa";
			this.cbkhoa.Size = new System.Drawing.Size(200, 21);
			this.cbkhoa.TabIndex = 19;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(248, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 20;
			this.label8.Text = "Khoa";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkdoikhoanhapvien
			// 
			this.chkdoikhoanhapvien.Location = new System.Drawing.Point(96, 113);
			this.chkdoikhoanhapvien.Name = "chkdoikhoanhapvien";
			this.chkdoikhoanhapvien.Size = new System.Drawing.Size(168, 24);
			this.chkdoikhoanhapvien.TabIndex = 21;
			this.chkdoikhoanhapvien.Text = "Đổi khoa nhập viện";
			this.chkdoikhoanhapvien.Click += new System.EventHandler(this.chkdoikhoanhapvien_Click);
			// 
			// frmTuchoi
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 181);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkdoikhoanhapvien,
																		  this.label8,
																		  this.cbkhoa,
																		  this.lydo,
																		  this.ngayvao,
																		  this.hoten,
																		  this.label10,
																		  this.label7,
																		  this.butKetthuc,
																		  this.butSua,
																		  this.mann,
																		  this.tqx,
																		  this.label5,
																		  this.diachi,
																		  this.label4,
																		  this.namsinh,
																		  this.label3,
																		  this.mabn2,
																		  this.label2,
																		  this.mabn1,
																		  this.label1,
																		  this.label6});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTuchoi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Từ chối nhập viện";
			this.Load += new System.EventHandler(this.frmTuchoi_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void mabn1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn1_Validated(object sender, System.EventArgs e)
		{
			mabn1.Text=mabn1.Text.PadLeft(2,'0');
		}

		private void mabn2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void emp_text()
		{
			hoten.Text="";
			namsinh.Text="";
			diachi.Text="";
			mann.Text="";
			tqx.Text="";
			dsxml.Clear();
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			emp_text();
			mabn2.Text=mabn2.Text.PadLeft(6,'0');
			mabn=mabn1.Text+mabn2.Text;
			sql="select a.hoten,a.namsinh,nvl(a.sonha,'')||' '||a.thon as diachi,b.tennn,trim(c.tentt)||','||trim(d.tenquan)||','||e.tenpxa as tqx";
            sql += " from " + user + ".btdbn a," + user + ".btdnn_bv b," + user + ".btdtt c," + user + ".btdquan d," + user + ".btdpxa e";
			sql+=" where a.mann=b.mann and a.matt=c.matt and a.maqu=d.maqu and a.maphuongxa=e.maphuongxa";
			sql+=" and a.mabn='"+mabn+"'";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				diachi.Text=r["diachi"].ToString();
				mann.Text=r["tennn"].ToString();
				tqx.Text=r["tqx"].ToString();
				break;
			}
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy mã người bệnh ")+mabn,LibMedi.AccessData.Msg);
				mabn1.Focus();
			}
			else
			{
				sql="select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra, a.makp";
                sql += " from " + user + ".benhandt a," + user + ".xuatvien b where a.maql=b.maql(+) and a.mabn='" + mabn1.Text + mabn2.Text + "'";
				sql+=" and a.loaiba=1";
				sql+=" order by a.maql desc";
				int ii=0;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					if(ii==0)cbkhoa.SelectedValue=r["makp"].ToString();
					ii++;
					updrec(decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["ngayra"].ToString());
				}
			}
		}

		private void updrec(decimal maql,string ngayvao,string ngayra)
		{
			DataRow r1=dsxml.Tables[0].NewRow();
			r1["maql"]=maql;
			r1["ngayvao"]=ngayvao;
			r1["ngayra"]=ngayra;
			dsxml.Tables[0].Rows.Add(r1);
		}

		private bool kiemtra()
		{
			if (hoten.Text=="" || mabn1.Text=="" || mabn2.Text=="")
			{
				mabn1.Focus();
				return false;
			}
			if (lydo.SelectedIndex==-1)
			{
				lydo.Focus();
				return false;
			}
			if (ngayvao.SelectedIndex==-1)
			{
				ngayvao.Focus();
				return false;
			}
			decimal l_maql=decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
			if(chkdoikhoanhapvien.Checked==false)
			{
                if (m.get_data("select * from " + user + ".v_theodoicongno where maql=" + l_maql).Tables[0].Rows.Count > 0)// || m.get_data("select * from v_vpkhoa where idkhoa="+l_id).Tables[0].Rows.Count>0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã sử dụng các dịch vụ không cho phép xóa !"),LibMedi.AccessData.Msg);
					return false;
				}
			}
            if (m.get_data("select * from " + user + ".nhapkhoa where maql=" + l_maql).Tables[0].Rows.Count > 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập khoa không cho phép xóa !"),LibMedi.AccessData.Msg);
				return false;
			}
			return true;
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if(chkdoikhoanhapvien.Checked ) 
			{
				if(f_doitkhoa_nhapvien(mabn1.Text.PadLeft(2,'0')+mabn2.Text.PadLeft(6,'0'), dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString(),cbkhoa.SelectedValue.ToString())==false)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã nhập khoa rồi, không thể đổi khoa được."));
					return;
				}
			}
			else
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý từ chối ngày giờ ")+ngayvao.Text,LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
                    foreach (DataRow r in m.get_data("select a.*,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ng from " + user + ".benhandt a where a.maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString())).Tables[0].Rows)
						m.upd_tuchoi(r["mabn"].ToString(),decimal.Parse(r["maql"].ToString()),r["makp"].ToString(),r["ng"].ToString(),int.Parse(r["dentu"].ToString()),int.Parse(r["nhantu"].ToString()),int.Parse(r["lanthu"].ToString()),int.Parse(r["madoituong"].ToString()),r["chandoan"].ToString(),r["maicd"].ToString(),r["mabs"].ToString(),r["sovaovien"].ToString(),int.Parse(r["loaiba"].ToString()),int.Parse(lydo.SelectedValue.ToString()),i_userid);

					int itableid = m.tableid("","benhandt");
					//
                    if (m.get_data("select * from " + user + ".xuatvien where maql=" + dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()).Tables[0].Rows.Count > 0)
					{
						itableid = m.tableid("","hiendien");
						m.upd_eve_upd_del(itableid,i_userid , "del",m.fields(user+".hiendien","maql="+decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString())));
						m.upd_eve_tables(itableid,i_userid,"del");
                        m.execute_data("delete from " + user + ".hiendien where maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
						return;
					}
					//
					m.upd_eve_upd_del(itableid,i_userid , "del",m.fields(user+".benhandt","maql="+decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString())));
					m.upd_eve_tables(itableid,i_userid,"del");
					itableid = m.tableid("","hiendien");
					m.upd_eve_upd_del(itableid,i_userid , "del",m.fields(user+".hiendien","maql="+decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString())));
					m.upd_eve_tables(itableid,i_userid,"del");
                    m.execute_data("delete from " + user + ".hiendien where maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
                    m.execute_data("update " + user + ".benhandt set tuchoi=1 where maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
                    //m.execute_data("delete from " + user + ".benhandt where maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
					MessageBox.Show(lan.Change_language_MessageText("Đã từ chối thành công !"),LibMedi.AccessData.Msg);
					mabn1.Focus();
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();
			System.GC.Collect();
			this.Close();
		}

		private void frmTuchoi_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            //
            f_capnhat_db();
            //
			dsxml.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
			mabn1.Text=DateTime.Now.Year.ToString().Substring(2,2);
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="MAQL";
			ngayvao.DataSource=dsxml.Tables[0];
			lydo.DisplayMember="TEN";
			lydo.ValueMember="ID";
            
            lydo.DataSource = m.get_data("select * from " + user + ".tuchoilydo order by id").Tables[0];

			cbkhoa.DisplayMember="TENKP";
			cbkhoa.ValueMember="MAKP";
            cbkhoa.DataSource = m.get_data("select makp, tenkp from " + user + ".btdkp_bv where loai=0 order by tenkp").Tables[0];
		}

		private void mabn1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void mabn2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void chkdoikhoanhapvien_Click(object sender, System.EventArgs e)
		{
			cbkhoa.Enabled=chkdoikhoanhapvien.Checked;
		}

		private bool f_doitkhoa_nhapvien(string smabn, string lmaql, string smakp)
		{
			bool bln=false;
            sql = "select maql from " + user + ".hiendien where mabn='" + smabn + "' and maql=" + lmaql + " and nhapkhoa=0 and xuatkhoa=0 and noichuyen='01'";
			if(m.get_data(sql).Tables[0].Rows.Count>0)
			{
                sql = "update " + user + ".benhandt set makp='" + smakp + "' where mabn='" + smabn + "' and maql=" + lmaql;
				m.execute_data(sql);
                sql = "update " + user + ".hiendien set makp='" + smakp + "' where mabn='" + smabn + "' and maql=" + lmaql + " and nhapkhoa=0 and xuatkhoa=0 and noichuyen='01'";
				m.execute_data(sql);
				bln=true;
			}
			return bln;
		}

        private void f_capnhat_db()
        {
            string asql="";

            asql = " create table " + user + ".tuchoilydo (id numeric(2), ten text, pk_tuchoilydo primary key (id))";
            m.execute_data(asql, false);
            asql = "select tuchoi from " + user + ".benhandt where 1=2";
            DataSet lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + user + ".benhandt add tuchoi numeric(1) default 0";
                m.execute_data(asql, false);
            }
        }
	}
}
