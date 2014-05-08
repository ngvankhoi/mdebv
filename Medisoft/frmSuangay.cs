﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSuamabn.
	/// </summary>
	public class frmSuangay : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
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
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private DataSet dsxml=new DataSet();
		private string mabn,sql,user;
		private System.Windows.Forms.TextBox tqx;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox benhan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ngayra;
        private string s_ngayvaovien = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSuangay(LibMedi.AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuangay));
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
            this.label8 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.benhan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ngayra = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(178, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn1
            // 
            this.mabn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn1.Location = new System.Drawing.Point(229, 16);
            this.mabn1.MaxLength = 2;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(24, 21);
            this.mabn1.TabIndex = 3;
            this.mabn1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn1_KeyPress);
            this.mabn1.Validated += new System.EventHandler(this.mabn1_Validated);
            this.mabn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // mabn2
            // 
            this.mabn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(254, 16);
            this.mabn2.MaxLength = 8;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(62, 21);
            this.mabn2.TabIndex = 4;
            this.mabn2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn2_KeyPress);
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            this.mabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(314, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(360, 16);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 6;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(81, 40);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(37, 21);
            this.namsinh.TabIndex = 8;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(360, 40);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(160, 21);
            this.diachi.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(309, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.Enabled = false;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(81, 64);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(439, 21);
            this.tqx.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-3, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tỉnh,Quận,P.Xã :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(228, 40);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(88, 21);
            this.mann.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(164, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ng nghiệp :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(193, 144);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 21;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(265, 144);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 22;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(238, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 19;
            this.label8.Text = "Sửa thành ngày giờ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy HH:mm";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(360, 112);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(160, 21);
            this.tu.TabIndex = 20;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(20, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ngày vào :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(81, 88);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(176, 21);
            this.ngayvao.TabIndex = 16;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhan_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(20, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thông tin :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(256, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "Ngày ra :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // benhan
            // 
            this.benhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.benhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhan.Items.AddRange(new object[] {
            "Nhận bệnh",
            "Nhập khoa",
            "Ngoại trú",
            "Phòng khám",
            "Phòng lưu"});
            this.benhan.Location = new System.Drawing.Point(81, 16);
            this.benhan.Name = "benhan";
            this.benhan.Size = new System.Drawing.Size(104, 21);
            this.benhan.TabIndex = 1;
            this.benhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhan_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ngayra.Enabled = false;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(360, 88);
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(160, 21);
            this.ngayra.TabIndex = 18;
            // 
            // frmSuangay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 189);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.benhan);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.tqx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSuangay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa ngày nhập sai từ hồ sơ bệnh án";
            this.Load += new System.EventHandler(this.frmSuangay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
            dsxml.Clear();
			hoten.Text="";
			namsinh.Text="";
			diachi.Text="";
			mann.Text="";
			tqx.Text="";
			ngayra.Text="";
			dsxml.Clear();
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			emp_text();
			mabn2.Text=mabn2.Text.PadLeft(6,'0');
			mabn=mabn1.Text+mabn2.Text;
            string nam = "";
			sql="select a.hoten,a.namsinh,nvl(a.sonha,'')||' '||a.thon as diachi,b.tennn,trim(c.tentt)||','||trim(d.tenquan)||','||e.tenpxa as tqx,a.nam";
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
                nam = r["nam"].ToString().Trim();
				break;
			}
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy mã người bệnh ")+mabn,LibMedi.AccessData.Msg);
				mabn1.Focus();
			}
			else
			{
                s_ngayvaovien = f_get_ngayvv();
                if (benhan.SelectedIndex == 3)
                {
                    sql = "select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,'' as ngayra";
                    sql += " from xxx.benhanpk a where a.mabn='" + mabn1.Text + mabn2.Text + "'";
                    sql += " order by a.maql desc";
                }
                else if (benhan.SelectedIndex == 4)
                {
                    sql = "select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra";
                    sql += " from xxx.benhancc a where a.mabn='" + mabn1.Text + mabn2.Text + "'";
                    sql += " order by a.maql desc";
                }
				else if (benhan.SelectedIndex==1)
				{
					sql="select a.id as maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra";
                    sql+=" from " + user + ".nhapkhoa a left join " + user + ".xuatkhoa b on a.id=b.id ";
                    sql+=" inner join " + user + ".benhandt c on a.maql=c.maql where a.mabn='" + mabn1.Text + mabn2.Text + "' order by a.id desc";
				}
                else if (benhan.SelectedIndex == 0)
                {
                    sql = "select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra";
                    sql += " from " + user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql where a.mabn='" + mabn1.Text + mabn2.Text + "'";
                    sql += " order by a.maql desc";
                }
                else // ngoai tru
                {
                    sql = "select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra";
                    sql += " from " + user + ".benhanngtr a where a.mabn='" + mabn1.Text + mabn2.Text + "'";
                    sql += " order by a.maql desc";
                }
				int irec=1;
				foreach(DataRow r in (benhan.SelectedIndex==3 || benhan.SelectedIndex==4)?m.get_data_nam_all_dec(nam,sql).Tables[0].Rows:m.get_data(sql).Tables[0].Rows)
				{
					if (irec==1)
					{
						int dd=int.Parse(r["ngayvao"].ToString().Substring(0,2));
						int mm=int.Parse(r["ngayvao"].ToString().Substring(3,2));
						int yyyy=int.Parse(r["ngayvao"].ToString().Substring(6,4));
						int hh=int.Parse(r["ngayvao"].ToString().Substring(11,2));
						int mi=int.Parse(r["ngayvao"].ToString().Substring(14,2));
						tu.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
						ngayra.Text=r["ngayra"].ToString();
					}
					updrec(decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["ngayra"].ToString());
					irec++;
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
            /*
			if (ngayra.Text!="")// && benhan.SelectedIndex!=3)
			{
				if (!m.bNgaygio(ngayra.Text,tu.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày vào không được lớn hơn ngày ra !"),LibMedi.AccessData.Msg);
					tu.Focus();
					return false;
				}
			}
			return true;*/
            decimal idkhoa = 0, maql = decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
            string ngay = ngayvao.Text, ngaydv = "";
            bool bFound = false;
            DataTable tmp;
            //
            if (benhan.SelectedIndex == 0 && !(m.bThanhtoan_ndot || m.bThanhtoan_khoa))//ngay vao vien
            {
                sql = "select b.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".benhandt a, xxx.v_thvpll b where a.maql=b.maql and b.maql=" + maql;
                tmp = m.get_data_mmyy(sql,ngay.Substring(0, 10), ngay.Substring(0, 10), true).Tables[0];
                if (tmp.Rows.Count > 0)
                {                    
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã chuyển số liệu xuống viện phí, đề nghị hủy trước khi sửa ngày vào viện (" + ngay + ")"), LibMedi.AccessData.Msg);                    
                    return false;                    
                }
            }
            //
            if (benhan.SelectedIndex == 1)
            {
                sql = "select b.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from "+user+".benhandt a,"+user+".nhapkhoa b where a.maql=b.maql and b.id=" + maql;
                tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    ngay = tmp.Rows[0]["ngay"].ToString();
                    if (!m.bNgaygio(tu.Text, ngay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày vào khoa không được nhỏ hơn ngày vào viện (" + ngay + ")"), LibMedi.AccessData.Msg);
                        tu.Focus();
                        return false;
                    }
                    idkhoa = decimal.Parse(tmp.Rows[0]["id"].ToString());
                }
            }
            if (ngayra.Text != "" && benhan.SelectedIndex != 3)
            {
                if (!m.bNgaygio(ngayra.Text, tu.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày vào không được lớn hơn ngày ra !"), LibMedi.AccessData.Msg);
                    tu.Focus();
                    return false;
                }
            }
            sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24mi') as yymmdd from xxx.v_vpkhoa ";
            sql += " where mabn='" + mabn1.Text + mabn2.Text + "'";
            if (idkhoa != 0) sql += " and idkhoa=" + idkhoa;
            else sql += " and maql=" + maql;
            sql += " union all ";
            sql += "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24mi') as yymmdd from xxx.v_chidinh ";
            sql += " where mabn='" + mabn1.Text + mabn2.Text + "'";
            if (idkhoa != 0) sql += " and idkhoa=" + idkhoa;
            else sql += " and maql=" + maql;
            tmp = m.get_data_mmyy(sql, ngay.Substring(0, 10), ngay.Substring(0, 10), false).Tables[0];
            ngaydv = ngay;
            foreach (DataRow r in tmp.Select("true", "yymmdd"))
            {
                ngaydv = r["ngay"].ToString();
                bFound = true;
                break;
            }
            if (bFound)
            {
                if (!m.bNgaygio(ngaydv.Substring(0, 10) + " 00:00", tu.Text.Substring(0, 10) + " 00:00"))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày sửa không được lớn hơn ngày sử dụng dịch vụ (" + ngaydv.Substring(0, 10) + ")"), LibMedi.AccessData.Msg);
                    tu.Focus();
                    return false;
                }
            }
            bFound = false;
            sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(ngay,'yyyymmddhh24mi') as yymmdd from xxx.d_tienthuoc ";
            sql += " where mabn='" + mabn1.Text + mabn2.Text + "'";
            if (idkhoa != 0) sql += " and idkhoa=" + idkhoa;
            else sql += " and maql=" + maql;
            tmp = m.get_data_mmyy(sql, ngay.Substring(0, 10), ngay.Substring(0, 10),true).Tables[0];
            ngaydv = ngay;
            foreach (DataRow r in tmp.Select("true", "yymmdd"))
            {
                ngaydv = r["ngay"].ToString();
                bFound = true;
                break;
            }
            if (bFound)
            {
                if (!m.bNgaygio(ngaydv.Substring(0, 10) + " 00:00", tu.Text.Substring(0, 10) + " 00:00"))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày sửa không được lớn hơn ngày sử dụng thuốc (" + ngaydv.Substring(0, 10) + ")"), LibMedi.AccessData.Msg);
                    tu.Focus();
                    return false;
                }
            }
            return true;
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý sửa ngày giờ ")+ngayvao.Text+lan.Change_language_MessageText(" thành ")+tu.Text,LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
                if (benhan.SelectedIndex == 3)//phong kham
                    m.execute_data("update " + user+m.mmyy(ngayvao.Text) + ".benhanpk set ngay=to_timestamp('" + tu.Text + "','dd/mm/yyyy hh24:mi') where maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
                else if (benhan.SelectedIndex == 4) //phong luu
                    m.execute_data("update " + user + m.mmyy(ngayvao.Text) + ".benhancc set ngay=to_timestamp('" + tu.Text + "','dd/mm/yyyy hh24:mi') where maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
                else if (benhan.SelectedIndex == 1)//nhap khoa
                {
                    //DateTime dt1= m.StringToDateTime(s_ngayvaovien, "dd/mm/yyyy hh24:mi");
                    DateTime dt1 = m.StringToDateTime(s_ngayvaovien, "dd/MM/yyyy HH:mm");
                    DateTime dt2 = m.StringToDateTime(tu.Text, "dd/MM/yyyy HH:mm");//"dd/mm/yyyy hh24:mi");
                    if (DateTime.Compare(dt1, dt2) <= 0) //if (dt2 >= dt1)
                    {
                        m.execute_data("update " + user + ".nhapkhoa set ngay=to_timestamp('" + tu.Text + "','dd/mm/yyyy hh24:mi') where id=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
                        m.execute_data("update " + user + ".hiendien set ngay=to_timestamp('" + tu.Text + "','dd/mm/yyyy hh24:mi') where id=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
                        if (m.bPhonggiuong)
                            m.execute_data("update " + user + ".theodoigiuong set tu=to_timestamp('" + tu.Text + "','dd/mm/yyyy hh24:mi') where idkhoa=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()) + " and soluong=0");
                    }
                    else
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày giờ vào khoa '") + tu.Text + "' " + lan.Change_language_MessageText("không thể nhỏ hơn ngày vào viện '") + s_ngayvaovien + "'", lan.Change_language_MessageText("Sửa ngày giờ"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tu.Focus();
                    }
                }
                else if (benhan.SelectedIndex == 0) m.execute_data("update " + user + ".benhandt set ngay=to_timestamp('" + tu.Text + "','dd/mm/yyyy hh24:mi') where maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
                else m.execute_data("update " + user + ".benhanngtr set ngay=to_timestamp('" + tu.Text + "','dd/mm/yyyy hh24:mi') where maql=" + decimal.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
				MessageBox.Show(lan.Change_language_MessageText("Đã sửa thành công !"),LibMedi.AccessData.Msg);
				mabn1.Focus();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void frmSuangay_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dsxml.ReadXml("..//..//..//xml//m_ngayvao.xml");
			mabn1.Text=DateTime.Now.Year.ToString().Substring(2,2);
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="MAQL";
			ngayvao.DataSource=dsxml.Tables[0];
			benhan.SelectedIndex=0;
		}

		private void mabn1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void mabn2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao && ngayvao.SelectedIndex!=-1)
			{
				string ngay=dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString();
				int dd=int.Parse(ngay.Substring(0,2));
				int mm=int.Parse(ngay.Substring(3,2));
				int yyyy=int.Parse(ngay.Substring(6,4));
				int hh=int.Parse(ngay.Substring(11,2));
				int mi=int.Parse(ngay.Substring(14,2));
				tu.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
				ngayra.Text=dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
			}
		}

		private void benhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

        private string f_get_ngayvv()
        {
            string s_ngayvv="";
            sql = "select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra";
            sql += " from " + user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql where a.mabn='" + mabn1.Text + mabn2.Text + "'";
            sql += " order by a.maql desc";
            DataSet lds = m.get_data(sql);
            foreach (DataRow r in lds.Tables[0].Rows)
            {
                s_ngayvv = r["ngayvao"].ToString();
            }
            return s_ngayvv;
        }
	}
}
