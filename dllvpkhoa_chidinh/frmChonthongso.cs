using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
namespace dllvpkhoa_chidinh
{
	/// <summary>
	/// Summary description for frmChonthongso.
	/// </summary>
	public class frmChonthongso : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.ListBox makho;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m;
		private int i_loai,i_benhnhan,i_thuoc;
		private string user,sql,kho_phieu;
        public int i_makp, i_nhom, i_phieu, i_macstt, i_buoi, i_somay, i_khudt = 0, i_idchinhanh=0;
		public long l_duyet;
        public string s_makp, s_makho, s_makho1, s_ngay, s_tenkp, s_phieu, s_mmyy, s_tennhom, s_manguon, s_nhomkho;
		private DataRow r;
		private bool bThua=false,bLetet;
        private DataTable dtletet = new DataTable();
		private DataTable dtkho=new DataTable();
		private DataTable dtmakp=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtphieu=new DataTable();
        private DataTable dtkp = new DataTable();
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label ltutruc;
		private System.Windows.Forms.ComboBox matutruc;
		private System.Windows.Forms.TextBox kp;
        private CheckBox chkAll;
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>

		public frmChonthongso(LibMedi.AccessData acc,int thuoc,int loai,int benhnhan,string makp,bool thua,string _nhomkho, int _khudt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;i_thuoc=thuoc;s_nhomkho=_nhomkho;
			i_loai=loai;i_benhnhan=benhnhan;
            i_khudt = _khudt;
            s_makp = makp; bThua = thua; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public frmChonthongso(LibMedi.AccessData acc, int thuoc, int loai, int benhnhan, string makp, bool thua, string _nhomkho)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_thuoc = thuoc; s_nhomkho = _nhomkho;
            i_loai = loai; i_benhnhan = benhnhan;
            s_makp = makp; bThua = thua; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonthongso));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.phieu = new System.Windows.Forms.ComboBox();
            this.makho = new System.Windows.Forms.ListBox();
            this.makp = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ltutruc = new System.Windows.Forms.Label();
            this.matutruc = new System.Windows.Forms.ComboBox();
            this.kp = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Khoa :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Phiếu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phieu
            // 
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(45, 74);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(172, 21);
            this.phieu.TabIndex = 6;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(45, 122);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(219, 82);
            this.makho.TabIndex = 8;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(80, 51);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(184, 21);
            this.makp.TabIndex = 5;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(67, 208);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "    Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(138, 208);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-2, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhom
            // 
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(45, 28);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(219, 21);
            this.nhom.TabIndex = 3;
            this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(45, 5);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(83, 21);
            this.ngay.TabIndex = 0;
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(122, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số liệu :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(171, 5);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(34, 21);
            this.mm.TabIndex = 1;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(219, 5);
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(45, 21);
            this.yyyy.TabIndex = 2;
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(206, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "/";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ltutruc
            // 
            this.ltutruc.Location = new System.Drawing.Point(-2, 96);
            this.ltutruc.Name = "ltutruc";
            this.ltutruc.Size = new System.Drawing.Size(48, 24);
            this.ltutruc.TabIndex = 13;
            this.ltutruc.Text = "Tủ trực :";
            this.ltutruc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matutruc
            // 
            this.matutruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matutruc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matutruc.Location = new System.Drawing.Point(45, 98);
            this.matutruc.Name = "matutruc";
            this.matutruc.Size = new System.Drawing.Size(219, 21);
            this.matutruc.TabIndex = 7;
            this.matutruc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // kp
            // 
            this.kp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kp.Location = new System.Drawing.Point(45, 51);
            this.kp.Name = "kp";
            this.kp.Size = new System.Drawing.Size(32, 21);
            this.kp.TabIndex = 4;
            this.kp.Validated += new System.EventHandler(this.kp_Validated);
            this.kp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(217, 73);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 23);
            this.chkAll.TabIndex = 14;
            this.chkAll.Text = "Tất cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmChonthongso
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(274, 247);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.kp);
            this.Controls.Add(this.matutruc);
            this.Controls.Add(this.ltutruc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonthongso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn thông số";
            this.Load += new System.EventHandler(this.frmChonthongso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void phieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (phieu.SelectedIndex==-1) phieu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void load_makp()
		{
			if (nhom.SelectedIndex!=-1)
			{
                sql = "select a.* from " + user + ".d_duockp a left join " + user + ".btdkp_bv b on a.makp=b.makp where a.nhom like '%" + int.Parse(nhom.SelectedValue.ToString()) + ",%'";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    if (s.Length > 3) s = s.Substring(0, s.Length - 3);
                    sql += " and a.makp in ('" + s + "')";
                }
                else if (i_benhnhan == 1) sql += " and a.makp is not null";
                //if (i_loai == 3) sql += " and b.loai<>1 ";//binh 150311
                if (i_khudt != 0) sql += " and (a.khu=0 or a.khu=" + i_khudt + ")";//binh 210411
                if (i_idchinhanh > 0) sql += " and chinhanh=" + i_idchinhanh;
				sql+=" order by a.stt";
				dtmakp=d.get_data(sql).Tables[0];
				makp.DataSource=dtmakp;
				if (makp.Items.Count>0) kp.Text=dtmakp.Rows[makp.SelectedIndex]["ma"].ToString();
				if (i_loai==2) load_matutruc();
			}
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp)
			{
				if (i_loai==2) load_matutruc();
				if (makp.SelectedIndex!=-1) kp.Text=dtmakp.Rows[makp.SelectedIndex]["ma"].ToString();
                load_makho();
			}
		}

		private void load_nhom()
		{
            sql = "select * from " + user + ".d_dmnhomkho where loai=" + i_thuoc;
			if (s_nhomkho!="") sql+=" and id in ("+s_nhomkho.Substring(0,s_nhomkho.Length-1)+")";
			sql+=" order by stt";
			nhom.DataSource=d.get_data(sql).Tables[0];
			if (nhom.SelectedIndex!=-1) 
			{
				load_makp();
				load_makho();
			}
		}

		private void load_makho()
		{
			if (makp.SelectedIndex!=-1 && nhom.SelectedIndex!=-1)
			{
                sql=m.getkho(i_thuoc,int.Parse(nhom.SelectedValue.ToString()),bThua,dtmakp,int.Parse(makp.SelectedValue.ToString()),i_loai,ngay.Text,dtletet);
				dtkho=d.get_data(sql).Tables[0];
				makho.DataSource=dtkho;
                sql = "select * from " + user + ".d_loaiphieu where nhom=" + int.Parse(nhom.SelectedValue.ToString()) + " and loai=" + i_loai;
				if (bThua)
				{
                    sql = "select * from " + user + ".d_loaiphieu where id=0";
                    if (d.get_data("select * from " + user + ".d_loaiphieu where id=0").Tables[0].Rows.Count == 0)
						d.upd_loaiphieu(0,lan.Change_language_MessageText("Hoàn trả thừa theo khoa/phòng"),i_loai,int.Parse(nhom.SelectedValue.ToString()),0,0,true);
				}
				else sql+=" and id<>0";
				sql+=" order by stt";
				dtphieu=d.get_data(sql).Tables[0];
				phieu.DataSource=dtphieu;
                loc_phieu(chkAll.Checked);
			}
		}

		private bool kiemtra()
		{
			if (nhom.SelectedIndex==-1)
			{
				nhom.Focus();
				return false;
			}
			if (phieu.SelectedIndex==-1)
			{
				phieu.Focus();
				return false;
			}
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();
				return false;
			}
			if (matutruc.Visible && matutruc.SelectedIndex==-1)
			{
				matutruc.Focus();
				return false;
			}
			if (makho.Items.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chưa chọn kho dự trù !"),LibMedi.AccessData.Msg);
				makp.Focus();
				return false;
			}
			return true;
		}
		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			s_mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			if (!d.bMmyy(s_mmyy))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu ")+nhom.Text+lan.Change_language_MessageText(" tháng ")+mm.Value.ToString()+"/"+yyyy.Value.ToString()+lan.Change_language_MessageText(" chưa tạo !"),LibMedi.AccessData.Msg);
				mm.Focus();
				return;
			}
			i_nhom=int.Parse(nhom.SelectedValue.ToString());
			Cursor=Cursors.WaitCursor;
            s_manguon = d.get_data("select nguon from " + user + ".d_dmphieu where id=" + i_loai).Tables[0].Rows[0][0].ToString();
            s_makp = ""; s_makho = ""; s_makho1 = "";
			s_ngay=ngay.Text.Substring(0,10);
			s_tenkp=makp.Text;
			s_phieu=phieu.Text;
			s_tennhom=nhom.Text;
			i_somay=1;
			i_buoi=0;
			i_makp=int.Parse(makp.SelectedValue.ToString());
			if (i_loai==2) i_macstt=int.Parse(matutruc.SelectedValue.ToString());
			else i_macstt=0;
			i_phieu=int.Parse(phieu.SelectedValue.ToString());
			r=d.getrowbyid(dtmakp,"id="+i_makp);
			if (r!=null) 
			{
				s_makp=r["makp"].ToString();
                
                //DataRow r1 = m.getrowbyid(dtkp, "loai=1 and makp='" + s_makp + "'");//
                //if (r1 != null) s_makp = "";//neu la phong kham--> makp=""--> khong hoan tra duoc
                //
				i_somay=int.Parse(r["somay"].ToString());
			}
			for(int i=0;i<makho.Items.Count;i++) s_makho+=dtkho.Rows[i]["id"].ToString()+",";
            s_makho1 = makho.SelectedValue.ToString();
            dt = d.get_data("select a.id,a.makp,b.ten from " + user+s_mmyy + ".d_duyet a,"+user+".d_duockp b where a.makp=b.id and a.nhom=" + i_nhom + " and to_char(a.ngay,'dd/mm/yyyy')='" + ((s_ngay.Length>10)?s_ngay.Substring(0,10):s_ngay) + "'" + " and a.loai=" + i_loai + " and a.phieu=" + i_phieu + " and a.makhoa=" + i_makp).Tables[0];
            if (dt.Rows.Count != 0)
            {
                l_duyet = long.Parse(dt.Rows[0][0].ToString());
                if (i_loai == 2 && int.Parse(dt.Rows[0]["makp"].ToString()) != int.Parse(matutruc.SelectedValue.ToString()))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Khoa :")+" "+makp.Text+lan.Change_language_MessageText(" ngày : ")+" "+ngay.Text.Substring(0,10)+" "+lan.Change_language_MessageText("phiếu : ")+" "+phieu.Text+"\n"+lan.Change_language_MessageText("đã chọn tủ trực :")+" "+dt.Rows[0]["ten"].ToString(),LibMedi.AccessData.Msg);
                    matutruc.SelectedValue=dt.Rows[0]["makp"].ToString();
                    matutruc.Focus();
                    return;
                }
            }
            else l_duyet = 0;

			if (i_benhnhan==0 && s_makp=="") s_makp="xx";
			r=d.getrowbyid(dtphieu,"id="+i_phieu);
			if (r!=null) i_buoi=int.Parse(r["buoi"].ToString());
			if (d.bKiemtra_duyet(i_nhom)) d.upd_tonkho(s_mmyy,i_nhom,0);
			Cursor=Cursors.Default;
            string ngayt = m.DateToString("dd/MM/yyyy", m.StringToDate("01/" + mm.Value.ToString().PadLeft(2, '0') + "/" + yyyy.Value.ToString().PadLeft(4, '0')).AddMonths(-1));
            string mmyyt = m.mmyy(ngayt);
            if (i_loai == 2)
            {
                if (d.bMmyy(mmyyt))
                {
                    sql = "select a.* from " + user + mmyyt + ".d_xtutrucll a," + user + mmyyt + ".d_duyet b ";
                    sql += " where a.idduyet=b.id ";
                    sql += " and nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    sql += " and loai=" + i_loai + " and phieu=" + i_phieu + " and makhoa=" + i_makp;
                    if (d.get_data(sql).Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã nhập trong tháng")+" " + mmyyt.Substring(0, 2) + lan.Change_language_MessageText(" năm 20") + mmyyt.Substring(2, 2), LibMedi.AccessData.Msg);
                        mm.Value = decimal.Parse(mmyyt.Substring(0, 2));
                        yyyy.Value = decimal.Parse("20" + mmyyt.Substring(2, 2));
                        mm.Focus();
                        return;
                    }
                }
            }
            else if (i_loai == 1)
            {
                if (d.bMmyy(mmyyt))
                {
                    sql = "select a.* from " + user + mmyyt + ".d_dutrull a," + user + mmyyt + ".d_duyet b ";
                    sql += " where a.idduyet=b.id ";
                    sql += " and nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    sql += " and loai=" + i_loai + " and phieu=" + i_phieu + " and makhoa=" + i_makp;
                    if (d.get_data(sql).Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã nhập trong tháng") + " " + mmyyt.Substring(0, 2) + " "+lan.Change_language_MessageText("năm 20") + mmyyt.Substring(2, 2), LibMedi.AccessData.Msg);
                        mm.Value = decimal.Parse(mmyyt.Substring(0, 2));
                        yyyy.Value = decimal.Parse("20" + mmyyt.Substring(2, 2));
                        mm.Focus();
                        return;
                    }
                }
            }
			m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			s_makp="";
			m.close();this.Close();
		}

		private void frmChonthongso_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            i_idchinhanh = m.i_Chinhanh_hientai;
            string ng = m.ngayhienhanh_server;
            dtletet = m.get_data("select * from "+user+".letet").Tables[0];
            if (m.gio_linh != "00:00" || m.sGiochunhat != "00:00" || m.bPhatthuoc_kho_khoa)
            {
                this.ngay.CustomFormat = "dd/MM/yyyy HH:mm";
                this.ngay.Size = new System.Drawing.Size(123, 21);
                this.ngay.Value = new DateTime(int.Parse(ng.Substring(6, 4)), int.Parse(ng.Substring(3, 2)), int.Parse(ng.Substring(0, 2)), int.Parse(ng.Substring(11, 2)), int.Parse(ng.Substring(14, 2)), 0, 0);
            }
            else this.ngay.Value = new DateTime(int.Parse(ng.Substring(6, 4)), int.Parse(ng.Substring(3, 2)), int.Parse(ng.Substring(0, 2)), 0, 0, 0, 0);
            /*
            dtletet = m.get_data("select * from "+user+".letet").Tables[0];
            if (m.gio_linh != "00:00")
            {
                this.ngay.CustomFormat = "dd/MM/yyyy HH:mm";
                this.ngay.Size = new System.Drawing.Size(123, 21);
            }
             * */
			if (i_loai==2)
			{
				matutruc.DisplayMember="TEN";
				matutruc.ValueMember="ID";
			}
			else
			{
				makho.Location = new System.Drawing.Point(45,96);
				ltutruc.Visible=false;
				matutruc.Visible=false;
				makho.Height=makho.Height+matutruc.Height+10;
			}
            kho_phieu = d.get_data("select kho from " + user + ".d_dmphieu where id=" + i_loai).Tables[0].Rows[0][0].ToString().Trim();
            dtkp = m.get_data("select * from "+user+".btdkp_bv").Tables[0];
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";

			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			load_nhom();
            //load_makp();
            //load_makho();

            sql = "select mmyy from " + user + ".table ";
			sql+=" order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
			dt=d.get_data(sql).Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                s_mmyy = r["mmyy"].ToString();
                sql = "select a.* from " + user + s_mmyy + ".d_tonkhoth a, " + user + ".d_dmkho b where a.makho=b.id ";
                sql += " and b.nhom=" + m.nhom_duoc;
                DataSet lds = d.get_data(sql);
                if (lds.Tables.Count>0 && lds.Tables[0].Rows.Count > 0) break;
            }
			decimal yy=decimal.Parse("20"+s_mmyy.Substring(2,2));
			mm.Value=decimal.Parse(s_mmyy.Substring(0,2));
			yyyy.Minimum=yy-3;yyyy.Maximum=yy+3;
			yyyy.Value=yy;
            loc_phieu(false);
		}

		private void load_matutruc()
		{
            if (makp.SelectedIndex != -1)
            {
                r = m.getrowbyid(dtmakp, "id=" + int.Parse(makp.SelectedValue.ToString()));
                if (r != null)
                {
                    string s = r["tutruc"].ToString();
                    sql = "select * from "+user+".d_duockp ";
                    sql += " where id in (" + int.Parse(r["id"].ToString()) + ", " + int.Parse(r["matutruc"].ToString());
                    if (s != "") sql += "," + s;
                    sql += ")";
                    if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
                    if (i_idchinhanh > 0) sql += " and chinhanh=" + i_idchinhanh;
                    sql+=" order by id";
                    matutruc.DataSource = d.get_data(sql).Tables[0];
                    matutruc.SelectedIndex = 0;
                }
            }
		}

		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == nhom)
            {
                load_makp();
                load_makho();
            }
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,m.Ngaylv_Ngayht+3))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
				ngay.Focus();
				return;
			}
            loc_phieu(false);// gam 21-06-2011
            if (m.gio_linh != "00:00" || m.bPhieulinh_chanle || m.bPhatthuoc_kho_khoa) load_makho();
		}

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhom.SelectedIndex==-1) nhom.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void kp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DataRow r=m.getrowbyid(dtmakp,"ma='"+kp.Text+"'");
				if (r!=null) makp.SelectedValue=r["id"].ToString();
				else makp.SelectedIndex=-1;
			}
			catch{}
		}

        private void loc_phieu(bool all)
        {
            string s_phieu = "",s_loai="",s_phieukp="";
            s_ngay = ngay.Text;
            s_mmyy = ngay.Value.Month.ToString().PadLeft(2,'0') + ngay.Value.Year.ToString().Substring(2, 2);// mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            i_nhom = (nhom.SelectedIndex != -1) ? int.Parse(nhom.SelectedValue.ToString()) : 0;
            i_makp = (makp.SelectedIndex != -1) ? int.Parse(makp.SelectedValue.ToString()) : 0;
            if (makp.SelectedIndex != -1)
            {
                s_loai = dtmakp.Rows[makp.SelectedIndex]["loaiphieu"].ToString();
                s_phieukp = dtmakp.Rows[makp.SelectedIndex]["phieu"].ToString();
            }
            if (!all && m.bMmyy(s_mmyy))
            {
                sql = "select phieu from "+user+s_mmyy+".d_duyet where nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0,10) + "' and done<>0 ";
                sql += " and loai=" + i_loai + " and makhoa=" + i_makp;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows) s_phieu += r["phieu"].ToString() + ",";
            }
            sql = "select * from "+user+".d_loaiphieu where nhom=" + i_nhom + " and loai=" + i_loai;
            if (bThua)
            {
                sql = "select * from "+user+".d_loaiphieu where id=0";
                if (d.get_data("select * from "+user+".d_loaiphieu where id=0").Tables[0].Rows.Count == 0)
                    d.upd_loaiphieu(0, "Hoàn trả thừa theo khoa/phòng", i_loai, i_nhom, 0, 0,true);
            }
            else sql += " and id<>0";
            if (s_phieu != "") sql += " and id not in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
            if (s_phieukp.IndexOf(i_loai.ToString()) != -1 && s_loai != "") sql += " and id in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
            sql += " order by stt";
            dtphieu = d.get_data(sql).Tables[0];
            phieu.DataSource = dtphieu;
        }

        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == chkAll) loc_phieu(chkAll.Checked);
        }
	}
}
