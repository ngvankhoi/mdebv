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
	/// Summary description for frmUser.
	/// </summary>
	public class frmUser : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox userid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
        private DataTable dtkhu = new DataTable();
		private DataTable dtdmkho=new DataTable();
		private DataTable dtmakp=new DataTable();
		private DataTable dtdmnhom=new DataTable();
		private DataTable dtnt=new DataTable();
		private DataTable dtkhac=new DataTable();
		private AccessData d;
		private DataSet	ds=new DataSet();
		private DataSet dsr=new DataSet();
        private string user, d_user = "", d_psw = "", d_right = "", s_makho = "", s_makp = "", s_manhom = "", s_userid, s_loaint = "", s_loaikhac = "", s_khudt = "";
		private int i_nhomkho;
		private decimal m_id;
        private bool bnew = false;
		private System.Windows.Forms.ComboBox nhomkho;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckedListBox makho;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckBox tao;
		private System.Windows.Forms.CheckBox admin;
		private System.Windows.Forms.CheckedListBox manhom;
		private System.Windows.Forms.CheckedListBox loaint;
		private System.Windows.Forms.CheckedListBox loaikhac;
        private bool bMahoa;
        private CheckBox thuhoi;
        private CheckedListBox khudt;
        private Label label5;
        private Label label6;
        private ComboBox cbocn;
        private CheckBox chkmau38_duyetthuoc;
        private CheckBox chkmau38_duyetcls;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUser(AccessData acc,DataSet dset,decimal id,string user,string psw,string right,int nhomkho,string _makho,string _makp,bool change,string _manhom,string _userid,string _loaint,string _loaikhac)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;dsr=dset;m_id=id;
			d_user=user;d_psw=psw;d_right=right;
			i_nhomkho=nhomkho;s_makho=_makho;
			s_makp=_makp;s_manhom=_manhom;s_loaint=_loaint;s_loaikhac=_loaikhac;
			makho.Enabled=change;makp.Enabled=change;
            loaint.Enabled = change; loaikhac.Enabled = change;
			manhom.Enabled=change;s_userid=_userid;
            tao.Enabled = change; admin.Enabled = change; thuhoi.Enabled = chkmau38_duyetcls.Enabled = chkmau38_duyetthuoc.Enabled = change;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.label1 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.userid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.nhomkho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.tao = new System.Windows.Forms.CheckBox();
            this.admin = new System.Windows.Forms.CheckBox();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.loaint = new System.Windows.Forms.CheckedListBox();
            this.loaikhac = new System.Windows.Forms.CheckedListBox();
            this.thuhoi = new System.Windows.Forms.CheckBox();
            this.khudt = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbocn = new System.Windows.Forms.ComboBox();
            this.chkmau38_duyetthuoc = new System.Windows.Forms.CheckBox();
            this.chkmau38_duyetcls = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(57, 9);
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 1;
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // userid
            // 
            this.userid.BackColor = System.Drawing.SystemColors.HighlightText;
            this.userid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userid.Location = new System.Drawing.Point(57, 31);
            this.userid.MaxLength = 10;
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(160, 21);
            this.userid.TabIndex = 3;
            this.userid.Validated += new System.EventHandler(this.userid_Validated);
            this.userid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userid_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Login :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.SystemColors.HighlightText;
            this.password.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(57, 53);
            this.password.MaxLength = 10;
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(160, 21);
            this.password.TabIndex = 5;
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-7, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butOk.Image = global::Duoc.Properties.Resources.save;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(532, 419);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 13;
            this.butOk.Text = "     &Lưu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = global::Duoc.Properties.Resources.close_r;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(602, 419);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 14;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // nhomkho
            // 
            this.nhomkho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomkho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomkho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomkho.Location = new System.Drawing.Point(57, 76);
            this.nhomkho.Name = "nhomkho";
            this.nhomkho.Size = new System.Drawing.Size(160, 21);
            this.nhomkho.TabIndex = 7;
            this.nhomkho.SelectedIndexChanged += new System.EventHandler(this.nhomkho_SelectedIndexChanged);
            this.nhomkho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomkho_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-7, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhóm kho :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Location = new System.Drawing.Point(57, 129);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(160, 169);
            this.makho.TabIndex = 8;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Location = new System.Drawing.Point(220, 33);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(178, 379);
            this.makp.TabIndex = 12;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // tao
            // 
            this.tao.Location = new System.Drawing.Point(57, 312);
            this.tao.Name = "tao";
            this.tao.Size = new System.Drawing.Size(136, 24);
            this.tao.TabIndex = 9;
            this.tao.Text = "Tạo số liệu tháng mới";
            this.tao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // admin
            // 
            this.admin.Location = new System.Drawing.Point(57, 332);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(176, 24);
            this.admin.TabIndex = 10;
            this.admin.Text = "Chỉnh sửa số liệu";
            this.admin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Location = new System.Drawing.Point(400, 33);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(272, 154);
            this.manhom.TabIndex = 15;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // loaint
            // 
            this.loaint.CheckOnClick = true;
            this.loaint.Location = new System.Drawing.Point(400, 205);
            this.loaint.Name = "loaint";
            this.loaint.Size = new System.Drawing.Size(272, 94);
            this.loaint.TabIndex = 16;
            // 
            // loaikhac
            // 
            this.loaikhac.CheckOnClick = true;
            this.loaikhac.Location = new System.Drawing.Point(400, 318);
            this.loaikhac.Name = "loaikhac";
            this.loaikhac.Size = new System.Drawing.Size(139, 94);
            this.loaikhac.TabIndex = 17;
            // 
            // thuhoi
            // 
            this.thuhoi.Location = new System.Drawing.Point(57, 352);
            this.thuhoi.Name = "thuhoi";
            this.thuhoi.Size = new System.Drawing.Size(176, 24);
            this.thuhoi.TabIndex = 11;
            this.thuhoi.Text = "Thu hồi trong duyệt";
            this.thuhoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // khudt
            // 
            this.khudt.CheckOnClick = true;
            this.khudt.Location = new System.Drawing.Point(541, 318);
            this.khudt.Name = "khudt";
            this.khudt.Size = new System.Drawing.Size(130, 94);
            this.khudt.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(397, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nhóm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-7, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Chọn CN :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbocn
            // 
            this.cbocn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbocn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocn.Location = new System.Drawing.Point(57, 101);
            this.cbocn.Name = "cbocn";
            this.cbocn.Size = new System.Drawing.Size(160, 21);
            this.cbocn.TabIndex = 21;
            // 
            // chkmau38_duyetthuoc
            // 
            this.chkmau38_duyetthuoc.Checked = true;
            this.chkmau38_duyetthuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkmau38_duyetthuoc.Location = new System.Drawing.Point(57, 372);
            this.chkmau38_duyetthuoc.Name = "chkmau38_duyetthuoc";
            this.chkmau38_duyetthuoc.Size = new System.Drawing.Size(136, 24);
            this.chkmau38_duyetthuoc.TabIndex = 22;
            this.chkmau38_duyetthuoc.Text = "Duyệt thuốc Mẫu 38";
            // 
            // chkmau38_duyetcls
            // 
            this.chkmau38_duyetcls.Checked = true;
            this.chkmau38_duyetcls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkmau38_duyetcls.Location = new System.Drawing.Point(57, 394);
            this.chkmau38_duyetcls.Name = "chkmau38_duyetcls";
            this.chkmau38_duyetcls.Size = new System.Drawing.Size(136, 24);
            this.chkmau38_duyetcls.TabIndex = 23;
            this.chkmau38_duyetcls.Text = "Duyệt CLS Mẫu 38";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(223, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "Khoa phòng";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(25, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Kho";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(403, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 23);
            this.label9.TabIndex = 26;
            this.label9.Text = "Loại";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(402, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "Khác";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(543, 299);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 23);
            this.label11.TabIndex = 28;
            this.label11.Text = "Khu điều trị";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(674, 456);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.chkmau38_duyetcls);
            this.Controls.Add(this.chkmau38_duyetthuoc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbocn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.khudt);
            this.Controls.Add(this.loaint);
            this.Controls.Add(this.thuhoi);
            this.Controls.Add(this.loaikhac);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.tao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nhomkho);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm người dùng";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập họ tên !"),d.Msg);
				hoten.Focus();
				return;
			}

			if (userid.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập tên login !"),d.Msg);
				userid.Focus();
				return;
			}
			i_nhomkho=int.Parse(nhomkho.SelectedValue.ToString());
			s_makho="";
			for(int i=0;i<makho.Items.Count;i++) if (makho.GetItemChecked(i)) s_makho+=dtdmkho.Rows[i]["id"].ToString()+",";
			s_makp="";
			for(int i=0;i<makp.Items.Count;i++)	if (makp.GetItemChecked(i)) s_makp+=dtmakp.Rows[i]["id"].ToString()+",";
			s_manhom="";
			for(int i=0;i<manhom.Items.Count;i++)	if (manhom.GetItemChecked(i)) s_manhom+=dtdmnhom.Rows[i]["id"].ToString()+",";
			s_loaint="";
			for(int i=0;i<loaint.Items.Count;i++)	if (loaint.GetItemChecked(i)) s_loaint+=dtnt.Rows[i]["id"].ToString()+",";
			s_loaikhac="";
			for(int i=0;i<loaikhac.Items.Count;i++)	if (loaikhac.GetItemChecked(i)) s_loaikhac+=dtkhac.Rows[i]["id"].ToString()+",";

            s_khudt = "";
            for (int i = 0; i < khudt.Items.Count; i++) if (khudt.GetItemChecked(i)) s_khudt += dtkhu.Rows[i]["id"].ToString() + ",";

            string mahoa = password.Text;
            if (bMahoa) mahoa = d.encode(password.Text);
            //Tu:20/05/2011
            int i_chinhanh = 0;
            if (cbocn.SelectedIndex != -1 && cbocn.Enabled) i_chinhanh = int.Parse(cbocn.SelectedValue.ToString());
            //end Tu
            //hien:03/06/2011: xu ly cap id theo chi nhanh
            if (bnew) m_id = int.Parse(m_id.ToString() + i_chinhanh.ToString().PadLeft(2, '0'));
            //end hien
			d.upd_dlogin(m_id,hoten.Text,userid.Text,mahoa,d_right,i_nhomkho,s_makho.Trim(),s_makp.Trim(),(tao.Checked)?1:0,(admin.Checked)?1:0,s_manhom,s_loaint,s_loaikhac, s_khudt,i_chinhanh);
            d.execute_data("update " + user + ".d_dlogin set thuhoi=" + ((thuhoi.Checked) ? 1 : 0) + ", thuoc38=" + (chkmau38_duyetthuoc.Checked ? "1" : "0") + ", cls38=" + (chkmau38_duyetcls.Checked ? "1" : "0")+" where id=" + m_id);
			d.updrec(dsr.Tables[0],m_id,userid.Text,mahoa,d_right,i_nhomkho,s_makho.Trim(),s_makp.Trim());
			d.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private bool test()
		{
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập họ tên !"),d.Msg);
				hoten.Focus();
				return false;
			}

			if (userid.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập tên login !"),d.Msg);
				userid.Focus();
				return false;
			}

			return true;
		}

		private void frmUser_Load(object sender, System.EventArgs e)
		{
            user = d.user; bMahoa = d.bMahoamatkhau;
			nhomkho.DisplayMember="TEN";
			nhomkho.ValueMember="ID";
			nhomkho.DataSource=d.get_data("select * from "+user+".d_dmnhomkho order by stt").Tables[0];
			nhomkho.SelectedValue=i_nhomkho.ToString();
			nhomkho.Enabled=s_userid==LibDuoc.AccessData.links_userid+LibDuoc.AccessData.links_pass;
			
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";

			loaint.DisplayMember="TEN";
			loaint.ValueMember="ID";

			loaikhac.DisplayMember="TEN";
			loaikhac.ValueMember="ID";

			makp.DisplayMember="TEN";
			makp.ValueMember="ID";

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";

            khudt.DisplayMember = "TEN";
            khudt.ValueMember = "ID";
            //Tu:20/05/2011 them chi nhanh
            f_Loadchinhanh();
            //try
            //{
            //    cbocn.DisplayMember = "TEN";
            //    cbocn.ValueMember = "ID";
            //    cbocn.DataSource = d.get_data("select id,ten from " + user + ".dmchinhanh").Tables[0];
            //}
            //catch 
            //{
            //    cbocn.Enabled = false;
            //}
            //end Tu
			load_dmkho();

            if (m_id != 0)
            {
                this.Text = "Sửa Password";
                foreach (DataRow r in d.get_data("select * from " + user + ".d_dlogin where id=" + m_id).Tables[0].Rows)
                {
                    hoten.Text = r["hoten"].ToString();
                    nhomkho.SelectedValue = r["nhomkho"].ToString();
                    s_makho = r["makho"].ToString();
                    s_makp = r["makp"].ToString();
                    s_manhom = r["manhom"].ToString();
                    s_loaint = r["loaint"].ToString();
                    s_loaikhac = r["loaikhac"].ToString();
                    tao.Checked = int.Parse(r["tao"].ToString()) == 1;
                    admin.Checked = int.Parse(r["admin"].ToString()) == 1;
                    thuhoi.Checked = int.Parse(r["thuhoi"].ToString()) == 1;
                    s_khudt = r["khu"].ToString();
                    if (cbocn.Enabled)
                        cbocn.SelectedValue = r["chinhanh"].ToString();
                    chkmau38_duyetcls.Checked = r["cls38"].ToString() == "1";
                    chkmau38_duyetthuoc.Checked = r["thuoc38"].ToString() == "1";
                    break;
                }
                if (hoten.Text == "") hoten.Text = d_user;
                userid.Text = d_user;
                password.Text = (bMahoa) ? d.decode(d_psw) : d_psw;
                userid.Enabled = false;
                nhomkho.Enabled = false;
                s_makho = "," + s_makho;
                for (int i = 0; i < dtdmkho.Rows.Count; i++)
                    if (s_makho.IndexOf("," + dtdmkho.Rows[i]["id"].ToString().Trim() + ",") != -1) makho.SetItemCheckState(i, CheckState.Checked);
                    else makho.SetItemCheckState(i, CheckState.Unchecked);

                s_makp = "," + s_makp;
                for (int i = 0; i < dtmakp.Rows.Count; i++)
                    if (s_makp.IndexOf("," + dtmakp.Rows[i]["id"].ToString().Trim() + ",") != -1) makp.SetItemCheckState(i, CheckState.Checked);
                    else makp.SetItemCheckState(i, CheckState.Unchecked);

                s_manhom = "," + s_manhom;
                for (int i = 0; i < dtdmnhom.Rows.Count; i++)
                    if (s_manhom.IndexOf("," + dtdmnhom.Rows[i]["id"].ToString().Trim() + ",") != -1) manhom.SetItemCheckState(i, CheckState.Checked);
                    else manhom.SetItemCheckState(i, CheckState.Unchecked);

                s_loaint = "," + s_loaint;
                for (int i = 0; i < dtnt.Rows.Count; i++)
                    if (s_loaint.IndexOf("," + dtnt.Rows[i]["id"].ToString().Trim() + ",") != -1) loaint.SetItemCheckState(i, CheckState.Checked);
                    else loaint.SetItemCheckState(i, CheckState.Unchecked);

                s_loaikhac = "," + s_loaikhac;
                for (int i = 0; i < dtkhac.Rows.Count; i++)
                    if (s_loaikhac.IndexOf("," + dtkhac.Rows[i]["id"].ToString().Trim() + ",") != -1) loaikhac.SetItemCheckState(i, CheckState.Checked);
                    else loaikhac.SetItemCheckState(i, CheckState.Unchecked);

                if (s_khudt.Trim().Trim(',') != "")
                {
                    s_khudt = "," + s_khudt;
                    for (int i = 0; i < dtkhu.Rows.Count; i++)
                        if (s_khudt.IndexOf("," + dtkhu.Rows[i]["id"].ToString().Trim() + ",") != -1) khudt.SetItemCheckState(i, CheckState.Checked);
                        else khudt.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            else
            {
                bnew = true;//binh 29032012
                m_id = d.get_id_dlogin;
            }
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void userid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void password_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void userid_Validated(object sender, System.EventArgs e)
		{
			if (userid.Text!="")
			{
				DataRow r=d.getrowbyid(dsr.Tables[0],"userid='"+userid.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Tên login đã có !"),d.Msg);
					userid.Focus();
					return;
				}
			}
		}

		private void nhomkho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhomkho.SelectedIndex==-1) nhomkho.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void nhomkho_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_dmkho();
		}

		private void makho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) SendKeys.Send("{Tab}");
		}

		private void load_dmkho()
		{
			try
			{
                dtkhu = d.get_data("select * from " + user + ".dmkhudt ").Tables[0];
                khudt.DataSource = dtkhu;

                dtdmkho = d.get_data("select * from " + user + ".d_dmkho where hide=0 and nhom=" + int.Parse(nhomkho.SelectedValue.ToString()) + " order by stt").Tables[0];
				makho.DataSource=dtdmkho;
                dtmakp = d.get_data("select * from " + user + ".d_duockp where nhom like '%" + nhomkho.SelectedValue.ToString().Trim() + ",%' order by stt").Tables[0];
				makp.DataSource=dtmakp;
                dtdmnhom = d.get_data("select * from " + user + ".d_dmnhom where nhom=" + int.Parse(nhomkho.SelectedValue.ToString()) + " order by stt").Tables[0];
				manhom.DataSource=dtdmnhom;
                dtnt = d.get_data("select * from " + user + ".d_dmloaint where nhom=" + int.Parse(nhomkho.SelectedValue.ToString()) + " order by stt").Tables[0];
				loaint.DataSource=dtnt;
                dtkhac = d.get_data("select * from " + user + ".d_dmkhac where nhom=0 or nhom=" + int.Parse(nhomkho.SelectedValue.ToString()) + " order by stt").Tables[0];
				loaikhac.DataSource=dtkhac;
                manhom.DisplayMember = "TEN";
                manhom.ValueMember = "ID";

                loaint.DisplayMember = "TEN";
                loaint.ValueMember = "ID";

                loaikhac.DisplayMember = "TEN";
                loaikhac.ValueMember = "ID";

                makp.DisplayMember = "TEN";
                makp.ValueMember = "ID";

                makho.DisplayMember = "TEN";
                makho.ValueMember = "ID";
			}
			catch{}
		}

		public DataSet dsright
		{
			get
			{
				return dsr;
			}
		}
        //linh
        private void f_Loadchinhanh()
        {
            LibMedi.AccessData m = new LibMedi.AccessData();
            if (m.bQuanly_Theo_Chinhanh)
            {
                string s_ip_local = d.Maincode("Ip");
                string s_database_local = d.Maincode("Database").ToLower();
                DataSet dsChinhanh = d.get_data(" select id,ten,trungtam from " + d.user +
                    ".dmchinhanh where ip='" + s_ip_local + "' and lower(database_local)='" + s_database_local + "' and port='" + d.Maincode("Post") + "' order by ten");
                if (dsChinhanh.Tables[0].Select("trungtam=1").Length > 0 || dsChinhanh.Tables[0].Rows.Count == 0)
                {
                    dsChinhanh = d.get_data(" select id,ten from " + d.user + ".dmchinhanh order by ten");
                }
                cbocn.DisplayMember = "ten";
                cbocn.ValueMember = "id";
                cbocn.DataSource = dsChinhanh.Tables[0];
                if (cbocn.Items.Count == 1)
                {
                    cbocn.SelectedIndex = 0;
                    cbocn.Enabled = false;
                }
            }
            else
            {
                cbocn.SelectedIndex = -1;
                cbocn.Enabled = false;
            }
        }
        //end
	}
}
