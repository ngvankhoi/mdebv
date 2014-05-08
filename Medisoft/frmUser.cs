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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private AccessData m;
		private DataSet	ds=new DataSet();
		private DataSet dsr=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtdt=new DataTable();
		private DataTable dtnk=new DataTable();
        private DataTable dtkhudt = new DataTable();
		private DataTable dtcls=new DataTable();
        private DataTable dtmay = new DataTable();
		private DataTable dtbs=new DataTable();
        private DataTable dtduockp = new DataTable();
        private string v_user = "", v_psw = "", v_right = "", s_makp = "", s_madoituong = "", s_nhomkho = "", s_cls = "", s_may = "", mahoa = "", s_khudt="";
		private int m_id;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckedListBox madoituong;
        private System.Windows.Forms.CheckedListBox nhomkho;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.Label label5;
        private LibList.List listBS;
        private bool bMahoa;
        private CheckedListBox khudt;
        private ComboBox cbocn;
        private Label label6;
        private CheckBox chkduyetcv;
        private DataRow[] dr;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUser(AccessData acc,DataSet dset,int id,string user,string psw,string right)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; dsr = dset; m_id = id; if (m.bBogo) tv.GanBogo(this, textBox111);
			v_user=user;v_psw=psw;v_right=right;
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
            this.label4 = new System.Windows.Forms.Label();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.madoituong = new System.Windows.Forms.CheckedListBox();
            this.nhomkho = new System.Windows.Forms.CheckedListBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBS = new LibList.List();
            this.khudt = new System.Windows.Forms.CheckedListBox();
            this.cbocn = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkduyetcv = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(59, 10);
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(197, 23);
            this.hoten.TabIndex = 1;
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // userid
            // 
            this.userid.BackColor = System.Drawing.SystemColors.HighlightText;
            this.userid.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userid.Location = new System.Drawing.Point(59, 35);
            this.userid.MaxLength = 10;
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(197, 23);
            this.userid.TabIndex = 3;
            this.userid.Validated += new System.EventHandler(this.userid_Validated);
            this.userid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userid_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Login :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.SystemColors.HighlightText;
            this.password.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(59, 60);
            this.password.MaxLength = 10;
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(197, 23);
            this.password.TabIndex = 5;
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-5, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-5, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhom
            // 
            this.nhom.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Items.AddRange(new object[] {
            "Quản trị hệ thống",
            "Quản trị khoa/Phòng",
            "Người dùng",
            "Nhập liệu khoa/phòng"});
            this.nhom.Location = new System.Drawing.Point(59, 85);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(197, 24);
            this.nhom.TabIndex = 7;
            this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(110, 280);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 10;
            this.butOk.Text = "     &Lưu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(181, 280);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 11;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(259, 9);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(202, 308);
            this.makp.TabIndex = 12;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.CheckOnClick = true;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(59, 161);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(197, 116);
            this.madoituong.TabIndex = 13;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // nhomkho
            // 
            this.nhomkho.CheckOnClick = true;
            this.nhomkho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomkho.Location = new System.Drawing.Point(463, 10);
            this.nhomkho.Name = "nhomkho";
            this.nhomkho.Size = new System.Drawing.Size(161, 180);
            this.nhomkho.TabIndex = 14;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(98, 111);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(158, 21);
            this.tenbs.TabIndex = 9;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(59, 111);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 8;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-5, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Y Bác sỹ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(8, 285);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 226;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // khudt
            // 
            this.khudt.CheckOnClick = true;
            this.khudt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khudt.Location = new System.Drawing.Point(463, 200);
            this.khudt.Name = "khudt";
            this.khudt.Size = new System.Drawing.Size(161, 116);
            this.khudt.TabIndex = 227;
            // 
            // cbocn
            // 
            this.cbocn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbocn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocn.Items.AddRange(new object[] {
            "Quản trị hệ thống",
            "Quản trị khoa/Phòng",
            "Người dùng",
            "Nhập liệu khoa/phòng"});
            this.cbocn.Location = new System.Drawing.Point(59, 134);
            this.cbocn.Name = "cbocn";
            this.cbocn.Size = new System.Drawing.Size(197, 24);
            this.cbocn.TabIndex = 229;
            this.cbocn.SelectedIndexChanged += new System.EventHandler(this.cbocn_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-5, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 228;
            this.label6.Text = "Chọn CN :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkduyetcv
            // 
            this.chkduyetcv.AutoSize = true;
            this.chkduyetcv.Location = new System.Drawing.Point(4, 305);
            this.chkduyetcv.Name = "chkduyetcv";
            this.chkduyetcv.Size = new System.Drawing.Size(115, 17);
            this.chkduyetcv.TabIndex = 230;
            this.chkduyetcv.Text = "Duyệt chuyển viện";
            this.chkduyetcv.UseVisualStyleBackColor = true;
            // 
            // frmUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(626, 325);
            this.Controls.Add(this.chkduyetcv);
            this.Controls.Add(this.cbocn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.khudt);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.nhomkho);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label1);
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
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập họ tên !"),LibMedi.AccessData.Msg);
				hoten.Focus();
				return;
			}
			if (userid.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập tên login !"),LibMedi.AccessData.Msg);
				userid.Focus();
				return;
			}
			s_makp="";
			if (makp.SelectedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++)
					if (makp.GetItemChecked(i)) s_makp+=dt.Rows[i]["makp"].ToString().Trim()+",";
			s_madoituong="";
			if (madoituong.SelectedItems.Count>0)
				for(int i=0;i<madoituong.Items.Count;i++)
					if (madoituong.GetItemChecked(i)) s_madoituong+=dtdt.Rows[i]["madoituong"].ToString().Trim()+",";
			s_nhomkho="";
			if (nhomkho.SelectedItems.Count>0)
				for(int i=0;i<nhomkho.Items.Count;i++)
					if (nhomkho.GetItemChecked(i)) s_nhomkho+=dtnk.Rows[i]["id"].ToString().Trim()+",";

            s_khudt = "";
            if (khudt.SelectedItems.Count > 0)
                for (int i = 0; i < khudt.Items.Count; i++)
                    if (khudt.GetItemChecked(i)) s_khudt += dtkhudt.Rows[i]["id"].ToString().Trim() + ",";

            mahoa = password.Text;
            if (bMahoa) mahoa = m.encode(mahoa);
            //Tu:20/05/2011
            int i_chinhanh=0;
            if (cbocn.SelectedIndex != -1) i_chinhanh = int.Parse(cbocn.SelectedValue.ToString());
            //end Tu
            if (m_id != 0)
                dr = m.get_data("select id from " + m.user + ".dlogin where id=" + m_id + "").Tables[0].Select();
            //hien: 03-06-2011. cong them chi nhanh vao dau
            if (dr.Length <= 0)
                m_id = int.Parse(i_chinhanh.ToString() + m_id.ToString());
            // end hien
			m.upd_dlogin(m_id,hoten.Text,userid.Text,mahoa,nhom.SelectedIndex,s_makp,v_right,s_madoituong,s_nhomkho,s_cls,mabs.Text,s_may, s_khudt,i_chinhanh);
            m.execute_data("update " + m.user + ".dlogin set duyetcv=" + (chkduyetcv.Checked ? "1" : "0") + " where id=" + m_id + "");
			m.updrec(dsr.Tables[0],m_id,userid.Text,mahoa,v_right);
			m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private bool test()
		{
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập họ tên !"),LibMedi.AccessData.Msg);
				hoten.Focus();
				return false;
			}

			if (userid.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập tên login !"),LibMedi.AccessData.Msg);
				userid.Focus();
				return false;
			}

			return true;
		}
		private void frmUser_Load(object sender, System.EventArgs e)
		{
            dtbs = m.get_data("select * from " + m.user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien+") order by ma").Tables[0];
			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";
			listBS.DataSource=dtbs;
            dt = m.get_data("select * from " + m.user + ".btdkp_bv where loai in (0,1,4) order by loai,makp").Tables[0];
			makp.DataSource=dt;
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            dtnk = m.get_data("select * from " + m.user + ".d_dmnhomkho order by stt").Tables[0];
			nhomkho.DataSource=dtnk;
			nhomkho.DisplayMember="TEN";
			nhomkho.ValueMember="ID";
            //
            dtkhudt = m.get_data("select * from " + m.user + ".dmkhudt order by ten").Tables[0];
            khudt.DataSource = dtkhudt;
            khudt.DisplayMember = "TEN";
            khudt.ValueMember = "ID";
            //
            //Tu:20/05/2011 them Chi nhanh
            f_Loadchinhanh();
            //cbocn.DisplayMember = "TEN";
            //cbocn.ValueMember = "ID";
            //cbocn.DataSource = m.get_data("select id,ten from " + m.user + ".dmchinhanh").Tables[0];
            //
            dtdt = m.get_data("select * from " + m.user + ".doituong order by madoituong").Tables[0];
			madoituong.DataSource=dtdt;
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			nhom.SelectedIndex=0;

            bMahoa = m.bMahoamatkhau;
            if (m_id != 0)
            {
                this.Text = "Sửa Password";
                foreach (DataRow r in m.get_data("select * from " + m.user + ".dlogin where id=" + m_id).Tables[0].Rows)
                {
                    hoten.Text = r["hoten"].ToString();
                    f_load_btdkp(int.Parse(r["chinhanh"].ToString()));
                    f_load_dmbs(int.Parse(r["chinhanh"].ToString()));
                    nhom.SelectedIndex = int.Parse(r["manhom"].ToString());
                    s_makp = r["makp"].ToString();
                    for (int i = 0; i < makp.Items.Count; i++)
                        if (s_makp.IndexOf(dt.Rows[i]["makp"].ToString().Trim() + ",") != -1) makp.SetItemCheckState(i, CheckState.Checked);
                        else makp.SetItemCheckState(i, CheckState.Unchecked);
                    s_madoituong = r["madoituong"].ToString();
                    for (int i = 0; i < madoituong.Items.Count; i++)
                        if (s_madoituong.IndexOf(dtdt.Rows[i]["madoituong"].ToString().Trim() + ",") != -1) madoituong.SetItemCheckState(i, CheckState.Checked);
                        else madoituong.SetItemCheckState(i, CheckState.Unchecked);
                    s_nhomkho = r["nhomkho"].ToString();
                    for (int i = 0; i < nhomkho.Items.Count; i++)
                        if (s_nhomkho.IndexOf(dtnk.Rows[i]["id"].ToString().Trim() + ",") != -1) nhomkho.SetItemCheckState(i, CheckState.Checked);
                        else nhomkho.SetItemCheckState(i, CheckState.Unchecked);

                    s_khudt = r["khu"].ToString();
                    for (int i = 0; i < khudt.Items.Count; i++)
                        if (s_khudt.IndexOf(dtkhudt.Rows[i]["id"].ToString().Trim() + ",") != -1) khudt.SetItemCheckState(i, CheckState.Checked);
                        else khudt.SetItemCheckState(i, CheckState.Unchecked);

                    s_cls = r["cls"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    if (mabs.Text != "")
                    {
                        DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                        if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                        else tenbs.Text = "";
                    }
                    cbocn.SelectedValue = r["chinhanh"].ToString();                    
                    if (cbocn.Items.Count > 0 && cbocn.SelectedIndex >= 0) cbocn.Enabled = false;
                    if (r["duyetcv"].ToString() == "1") chkduyetcv.Checked = true;
                    else chkduyetcv.Checked = false;
                    break;
                }
                if (hoten.Text == "") hoten.Text = v_user;
                if (nhom.SelectedIndex == -1) nhom.SelectedIndex = 0;
                
                userid.Text = v_user;
                password.Text = (bMahoa) ? m.decode(v_psw) : v_psw;
                //hoten.Enabled=false;
                userid.Enabled = false;
                //nhom.Enabled=false;
            }
            else m_id = Convert.ToInt16(m.get_capid(-30));
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	    {
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void userid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void password_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void userid_Validated(object sender, System.EventArgs e)
		{
			if (userid.Text!="")
			{
				DataRow r=m.getrowbyid(dsr.Tables[0],"userid='"+userid.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Tên login đã có !"),LibMedi.AccessData.Msg);
					userid.Focus();
					return;
				}
			}
		}

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
				if (makp.Enabled) SendKeys.Send("{F4}");
			}
		}

		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if (this.ActiveControl==nhom) makp.Enabled=nhom.SelectedIndex%2==1;
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		public DataSet dsright
		{
			get
			{
				return dsr;
			}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r!=null) tenbs.Text=r["hoten"].ToString();
				else tenbs.Text="";
			}
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs(tenbs.Text);
				listBS.BrowseToICD10(tenbs,mabs,butOk,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
			}
			catch{}
		}

        private void cbocn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ActiveControl==cbocn) f_load_btdkp((cbocn.SelectedIndex < 0 || cbocn.Items.Count <= 0) ? 0 : int.Parse(cbocn.SelectedValue.ToString()));
        }

        private void f_load_btdkp(int m_chinhanh)
        {
            dt = new DataTable();
            string sql = "select * from " + m.user + ".btdkp_bv ";
            if (m_chinhanh > 0) sql += " where chinhanh=" + m_chinhanh;
            sql += " order by loai,makp";
            dt = m.get_data(sql).Tables[0];
            makp.DataSource = dt;
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";

            //CurrencyManager cm = (CurrencyManager)BindingContext[makp.DataSource];
            //DataView dv = (DataView)cm.List;
            //if (m_chinhanh>0)
            //    dv.RowFilter = "chinhanh="+m_chinhanh;
            //else
            //    dv.RowFilter = "";
        }

        private void f_load_dmbs(int m_chinhanh)
        {
            dtbs = new DataTable();
            string sql = "select * from " + m.user + ".dmbs ";            
            sql += " where nhom not in (" + LibMedi.AccessData.nhanvien + ")";
            if (m_chinhanh > 0) sql += " and chinhanh=" + m_chinhanh;
            sql += " order by hoten";
            dtbs = m.get_data(sql).Tables[0];
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            listBS.DataSource = dtbs;

            //CurrencyManager cm = (CurrencyManager)BindingContext[makp.DataSource];
            //DataView dv = (DataView)cm.List;
            //if (m_chinhanh>0)
            //    dv.RowFilter = "chinhanh="+m_chinhanh;
            //else
            //    dv.RowFilter = "";
        }
        //linh
        private void f_Loadchinhanh()
        {
            string s_ip_local = m.Maincode("Ip");
            string s_database_local = m.Maincode("Database").ToLower();
            DataSet dsChinhanh = m.get_data("select id,ten,trungtam from " + m.user +
                ".dmchinhanh where ip='" + s_ip_local + "' and lower(database_local)='" + s_database_local + "' and port='" + m.Maincode("Post") + "' order by ten");
            if (dsChinhanh.Tables[0].Select("trungtam=1").Length > 0 || dsChinhanh.Tables[0].Rows.Count == 0)
            {
                dsChinhanh = m.get_data(" select id,ten from " + m.user + ".dmchinhanh where id>0 order by ten");
            }
            cbocn.DisplayMember = "ten";
            cbocn.ValueMember = "id";
            cbocn.DataSource = dsChinhanh.Tables[0];
        }
        //end
	}
}
