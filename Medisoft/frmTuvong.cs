﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmTuvong.
	/// </summary>
	public class frmTuvong : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ngay;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox chandoan;
		private MaskedTextBox.MaskedTextBox maicd;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox nguyennhan;
		private System.Windows.Forms.ComboBox giaiphau;
		private System.Windows.Forms.ComboBox khamtuthi;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private string user,m_mabn,m_hoten,m_tuoivao,m_ngay,m_songay,s_msg,m_loaituoi,s_maicd,s_ngaynhan,s_ngaymo;
		private int m_userid,songay;
		private decimal m_maql;
		private System.Windows.Forms.TextBox songaydt;
		private MaskedBox.MaskedBox ngaynhan;
		private MaskedBox.MaskedBox ngaymo;
		private LibList.List listICD;
		private DataTable dticd=new DataTable();
        private TextBox ghichu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTuvong(AccessData acc,string mabn,string hoten,string tuoivao,string ngay,string songay,decimal maql,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;m_mabn=mabn;m_hoten=hoten;m_tuoivao=tuoivao;
			m_ngay=ngay;m_songay=songay;m_userid=userid;m_maql=maql;
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTuvong));
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.songaydt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nguyennhan = new System.Windows.Forms.ComboBox();
            this.giaiphau = new System.Windows.Forms.ComboBox();
            this.khamtuthi = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.ngaynhan = new MaskedBox.MaskedBox();
            this.ngaymo = new MaskedBox.MaskedBox();
            this.listICD = new LibList.List();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(257, 6);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 3;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(136, 6);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(73, 21);
            this.mabn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(199, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(457, 6);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(54, 21);
            this.tuoi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(416, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tuổi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(136, 29);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(96, 21);
            this.ngay.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày giờ tử vong :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // songaydt
            // 
            this.songaydt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songaydt.Enabled = false;
            this.songaydt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songaydt.Location = new System.Drawing.Point(457, 29);
            this.songaydt.Name = "songaydt";
            this.songaydt.Size = new System.Drawing.Size(54, 21);
            this.songaydt.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(360, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Thời gian điều trị :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(195, 118);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(317, 21);
            this.chandoan.TabIndex = 15;
            this.chandoan.Validated += new System.EventHandler(this.chandoan_Validated);
            this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chandoan_KeyDown);
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(136, 118);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.maicd.MaxLength = 9;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(56, 21);
            this.maicd.TabIndex = 14;
            this.maicd.Validated += new System.EventHandler(this.maicd_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Chẩn đoán tử vong :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(56, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nguyên nhân :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Giải phẩu bệnh :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(264, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "Khám tử thi :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 23);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ngày giờ nhận tử thi :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(264, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Ngày giờ mỗ tử thi :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nguyennhan
            // 
            this.nguyennhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguyennhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nguyennhan.Enabled = false;
            this.nguyennhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguyennhan.Location = new System.Drawing.Point(136, 51);
            this.nguyennhan.Name = "nguyennhan";
            this.nguyennhan.Size = new System.Drawing.Size(375, 21);
            this.nguyennhan.TabIndex = 11;
            this.nguyennhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguyennhan_KeyDown);
            // 
            // giaiphau
            // 
            this.giaiphau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaiphau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.giaiphau.Enabled = false;
            this.giaiphau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaiphau.Location = new System.Drawing.Point(136, 141);
            this.giaiphau.Name = "giaiphau";
            this.giaiphau.Size = new System.Drawing.Size(96, 21);
            this.giaiphau.TabIndex = 17;
            this.giaiphau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.giaiphau_KeyDown);
            // 
            // khamtuthi
            // 
            this.khamtuthi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khamtuthi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khamtuthi.Enabled = false;
            this.khamtuthi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khamtuthi.Items.AddRange(new object[] {
            "Không",
            "Có"});
            this.khamtuthi.Location = new System.Drawing.Point(416, 141);
            this.khamtuthi.Name = "khamtuthi";
            this.khamtuthi.Size = new System.Drawing.Size(96, 21);
            this.khamtuthi.TabIndex = 19;
            this.khamtuthi.SelectedIndexChanged += new System.EventHandler(this.khamtuthi_SelectedIndexChanged);
            this.khamtuthi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khamtuthi_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(112, 198);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 26;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(182, 198);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 24;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(252, 198);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 25;
            this.butBoqua.Text = " &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(322, 198);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 27;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // ngaynhan
            // 
            this.ngaynhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaynhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaynhan.Location = new System.Drawing.Point(136, 164);
            this.ngaynhan.Mask = "##/##/#### ##:##";
            this.ngaynhan.Name = "ngaynhan";
            this.ngaynhan.Size = new System.Drawing.Size(94, 21);
            this.ngaynhan.TabIndex = 21;
            this.ngaynhan.Text = "  /  /       :  ";
            this.ngaynhan.Validated += new System.EventHandler(this.ngaynhan_Validated);
            // 
            // ngaymo
            // 
            this.ngaymo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaymo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaymo.Location = new System.Drawing.Point(416, 164);
            this.ngaymo.Mask = "##/##/#### ##:##";
            this.ngaymo.Name = "ngaymo";
            this.ngaymo.Size = new System.Drawing.Size(96, 21);
            this.ngaymo.TabIndex = 23;
            this.ngaymo.Text = "  /  /       :  ";
            this.ngaymo.Validated += new System.EventHandler(this.ngaymo_Validated);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(419, 210);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 222;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(136, 73);
            this.ghichu.Multiline = true;
            this.ghichu.Name = "ghichu";
            this.ghichu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ghichu.Size = new System.Drawing.Size(376, 43);
            this.ghichu.TabIndex = 12;
            this.ghichu.TextChanged += new System.EventHandler(this.ghichu_TextChanged);
            // 
            // frmTuvong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 241);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.ngaymo);
            this.Controls.Add(this.ngaynhan);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.khamtuthi);
            this.Controls.Add(this.giaiphau);
            this.Controls.Add(this.nguyennhan);
            this.Controls.Add(this.songaydt);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTuvong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tử vong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTuvong_KeyDown);
            this.Load += new System.EventHandler(this.frmTuvong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTuvong_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dticd=m.get_data("select cicd10,vviet from "+user+".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			nguyennhan.DisplayMember="TEN";
			nguyennhan.ValueMember="MA";
            nguyennhan.DataSource = m.get_data("select * from " + user + ".chetdo order by ma").Tables[0];
			
			giaiphau.DisplayMember="TEN";
			giaiphau.ValueMember="MA";
            giaiphau.DataSource = m.get_data("select * from " + user + ".gphaubenh order by ma").Tables[0];
			khamtuthi.SelectedIndex=0;

			mabn.Text=m_mabn;
			hoten.Text=m_hoten;
			
			try
			{
				switch (int.Parse(m_tuoivao.Substring(3,1)))
				{
					case 0: m_loaituoi="TU";
						break;
					case 1: m_loaituoi="TH";
						break;
					case 2: m_loaituoi="NG";
						break;
					default: m_loaituoi="GI";
						break;
				}

				tuoi.Text=m_tuoivao.Substring(0,3)+m_loaituoi;
			}
			catch{}
			ngay.Text=m_ngay;
			songaydt.Text=m_songay;
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
            foreach (DataRow r in m.get_data("select * from " + user + ".tuvong where maql=" + m_maql).Tables[0].Rows)
			{
				nguyennhan.SelectedValue=r["nguyennhan"].ToString();
				maicd.Text=r["maicd"].ToString();
				chandoan.Text=r["chandoan"].ToString();
				giaiphau.SelectedValue=r["benhly"].ToString();
				khamtuthi.SelectedIndex=int.Parse(r["khamtuthi"].ToString());
				if (r["ngaynhan"].ToString()!="")
					ngaynhan.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngaynhan"].ToString()));
				if (r["ngaymo"].ToString()!="")
					ngaymo.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngaymo"].ToString()));
                ghichu.Text = r["ghichu"].ToString();
				break;
			}
			s_maicd=maicd.Text;
			s_ngaynhan=ngaynhan.Text;
			s_ngaymo=ngaymo.Text;
			if (maicd.Text=="") butMoi_Click(null,null);
		}

		private void nguyennhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (nguyennhan.SelectedIndex==-1) nguyennhan.SelectedIndex=0;
				SendKeys.Send("{Tab}{Home}");
			}
		}

		private void maicd_Validated(object sender, System.EventArgs e)
		{
			if (maicd.Text!=s_maicd)
			{
				if (maicd.Text=="") chandoan.Text="";
				else chandoan.Text=m.get_vviet(maicd.Text);
				if (chandoan.Text=="" && maicd.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", maicd.Text, chandoan.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						chandoan.Text=f.mTen;
						maicd.Text=f.mICD;
					}
				}
				s_maicd=maicd.Text;
			}
		}

		private void chandoan_Validated(object sender, System.EventArgs e)
		{
			if (maicd.Text=="") maicd.Text=m.get_cicd10(chandoan.Text);
			if (!m.bMaicd(maicd.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				maicd.Text="";
				maicd.Focus();
			}
		}

		private void giaiphau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (giaiphau.SelectedIndex==-1) giaiphau.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void khamtuthi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (khamtuthi.SelectedIndex==-1) khamtuthi.SelectedIndex=0;
				SendKeys.Send("{Tab}{Home}");
			}
		}

		private void khamtuthi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ngaynhan.Enabled=khamtuthi.SelectedIndex==1;
			ngaymo.Enabled=ngaynhan.Enabled;
			if (ngaynhan.Enabled && ngaynhan.Text=="")
			{
				ngaynhan.Text=ngay.Text;
				ngaymo.Text=ngay.Text;
			}
			else
			{
				ngaynhan.Text="";
				ngaymo.Text="";
			}
		}

		private void ngaynhan_Validated(object sender, System.EventArgs e)
		{
			if (ngaynhan.Text=="")
			{
				ngaynhan.Focus();
				return;
			}
			ngaynhan.Text=ngaynhan.Text.Trim();
			if (ngaynhan.Text!=s_ngaynhan)
			{
				if (ngaynhan.Text.Length<16)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ nhận !"),s_msg);
					ngaynhan.Focus();
					return;
				}
				if (!m.bNgay(ngaynhan.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
					ngaynhan.Focus();
					return;
				}
				ngaynhan.Text=m.Ktngaygio(ngaynhan.Text,16);
				if (!m.bNgaygio(ngaynhan.Text,ngay.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày nhận không được nhỏ hơn ngày tử vong !"),s_msg);
					ngaynhan.Focus();
					return;
				}

				if (!m.ngay(m.StringToDate(ngaynhan.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày nhận không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
					ngaynhan.Focus();
					return;
				}
			}
		}

		private void ngaymo_Validated(object sender, System.EventArgs e)
		{
			if (ngaymo.Text=="")
			{
				ngaymo.Focus();
				return;
			}
			ngaymo.Text=ngaymo.Text.Trim();
			if (ngaymo.Text!=s_ngaymo)
			{
				if (ngaymo.Text.Length<16)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ mỗ !"),s_msg);
					ngaymo.Focus();
					return;
				}
				if (!m.bNgay(ngaymo.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
					ngaymo.Focus();
					return;
				}
				ngaymo.Text=m.Ktngaygio(ngaymo.Text,16);
				if (!m.bNgaygio(ngaymo.Text,ngaynhan.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày mỗ không được nhỏ hơn ngày nhận !"),s_msg);
					ngaymo.Focus();
					return;
				}

				if (!m.ngay(m.StringToDate(ngaymo.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày mỗ không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
					ngaymo.Focus();
					return;
				}
			}
		}

		private void ena_object(bool ena)
		{
			butMoi.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			ghichu.Enabled=nguyennhan.Enabled=ena;
			if (ena) chandoan.Enabled=m.bChandoan;
			maicd.Enabled=ena;
			giaiphau.Enabled=ena;
			khamtuthi.Enabled=ena;
		}

		private bool kiemtra()
		{
			if (nguyennhan.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập nguyên nhân tử vong !"),s_msg);
				nguyennhan.Focus();
				return false;
			}
			if (maicd.Text=="" || chandoan.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán tử vong !"),s_msg);
				maicd.Focus();
				return false;
			}
			if (!m.Kiemtra_maicd(dticd,maicd.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
				maicd.Focus();
				return false;
			}
			if (!m.Kiemtra_tenbenh(dticd,chandoan.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
				chandoan.Focus();
				return false;
			}
			if (khamtuthi.SelectedIndex==1)
			{
				if (ngaynhan.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập ngày nhận tử thi !"),s_msg);
					ngaynhan.Focus();
					return false;
				}

				if (ngaymo.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập ngày mỗ tử thi !"),s_msg);
					ngaymo.Focus();
					return false;
				}
			}
			return true;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			nguyennhan.Focus();
			SendKeys.Send("{F4}");
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            int itable = m.tableid("","tuvong");
            if (m.get_data("select * from " + user + ".tuvong where maql=" + m_maql).Tables[0].Rows.Count > 0)
            {
                m.upd_eve_tables(itable, m_userid, "upd");
                m.upd_eve_upd_del(itable, m_userid, "upd", m_maql.ToString() + "^" + ngaynhan.Text + "^" + ngaymo.Text + "^" + chandoan.Text + "^" + maicd.Text + "^" + nguyennhan.SelectedValue.ToString() + "^" + giaiphau.SelectedValue.ToString() + "^" + khamtuthi.SelectedIndex.ToString() + "^" + m_userid.ToString());
            }
            else m.upd_eve_tables(itable, m_userid, "ins");
			if (!m.upd_tuvong(m_maql,ngaynhan.Text,ngaymo.Text,chandoan.Text,maicd.Text,int.Parse(nguyennhan.SelectedValue.ToString()),ghichu.Text,int.Parse(giaiphau.SelectedValue.ToString()),khamtuthi.SelectedIndex,m_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tử vong !"),s_msg);
				return;
			}
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void chandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{F4}");
			}
		}

		private void frmTuvong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void chandoan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chandoan)
			{
				Filt_ICD(chandoan.Text);
				listICD.BrowseToICD10(chandoan,maicd,giaiphau,maicd.Location.X,maicd.Location.Y+maicd.Height,maicd.Width+chandoan.Width+2,maicd.Height);
			}		
		}

        private void ghichu_TextChanged(object sender, EventArgs e)
        {
            if (ghichu.Text == "\r\n") SendKeys.Send("{Tab}");
        }
	}
}
