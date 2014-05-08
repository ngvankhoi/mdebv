using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmThuhoi.
	/// </summary>
	public class frmInphieu : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private DataTable dtphieu=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtkho=new DataTable();
		private DataTable dtnguon=new DataTable();
		private DataTable dtdt=new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable tmpyc = new DataTable();
        private DataTable dtnhomin = new DataTable();
        private string user, xxx, s_ngay, s_mmyy, sql, s_kho, s_makho, s_madt, s_tendt, s_tenkho, s_title, file1, file2, tenfile, s_idduyet, tieude, s_manguon, s_tennguon, s_doc, f_ngay, stime,s_userid, s_ngayylenhduyet,s_nhomin,s_tennhomin;
        private int i_nhom, i_loai, i_makp, i_phieu, i_songay, i_khudt = 0, i_userid=0;
        private bool bBuhaophi, bNhomin_mabd, bInngang, bDoituong_phieulinh, bInphieu_ngay, bNgayylenh_phieulinh, bChuky, bLinh_dongia, bSLYeucau, bPhatthuoc_kho_khoa,bThua;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Print prn=new Print();
		private System.Windows.Forms.CheckBox xuatcstt;
		private System.Windows.Forms.CheckedListBox manguon;
		private System.Windows.Forms.CheckBox xem;
		private System.Windows.Forms.TextBox nguoilinh;
		private System.Windows.Forms.Label label11;
		private DataColumn dc;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown banin;
		private System.Windows.Forms.CheckedListBox kho;
        private byte[] image_duoc = new byte[0];
        private byte[] image_dieutri = new byte[0];
        private byte[] image;
        private System.IO.MemoryStream memo;
        private FileStream fstr;
        private Panel p;
        private CheckBox chkXml;
        private CheckBox chkslyeucau;
        private CheckBox chkChuyenXuatSDCT_Thucxuat;
        private CheckedListBox ckNhomIn;
        private Label label8;
        private CheckBox cbdongy;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInphieu(LibDuoc.AccessData acc,DataTable kp,DataTable phieu,int imakp,int iphieu,string ngay,string mmyy,int nhom,int loai,string kho,string title,bool buhaophi,string _userid,bool bthua, int _khudt, int _iuserid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;dtphieu=phieu;dtkp=kp;bBuhaophi=buhaophi;
            i_makp = imakp; i_phieu = iphieu; s_kho = kho; s_title = title; bThua = bthua;
            s_ngay = ngay; s_mmyy = mmyy; i_nhom = nhom; i_loai = loai; s_userid = _userid;            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_khudt = _khudt;
            i_userid = _iuserid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInphieu));
            this.phieu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.madoituong = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xuatcstt = new System.Windows.Forms.CheckBox();
            this.manguon = new System.Windows.Forms.CheckedListBox();
            this.xem = new System.Windows.Forms.CheckBox();
            this.nguoilinh = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.banin = new System.Windows.Forms.NumericUpDown();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.p = new System.Windows.Forms.Panel();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.chkslyeucau = new System.Windows.Forms.CheckBox();
            this.chkChuyenXuatSDCT_Thucxuat = new System.Windows.Forms.CheckBox();
            this.ckNhomIn = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbdongy = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
            this.SuspendLayout();
            // 
            // phieu
            // 
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(66, 54);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(198, 21);
            this.phieu.TabIndex = 7;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phiếu :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(66, 31);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(198, 21);
            this.makp.TabIndex = 5;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.Print1;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(159, 243);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 12;
            this.butOk.Text = "     &In";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = global::Duoc.Properties.Resources.close_r;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(229, 243);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 13;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ ngày :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(66, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Location = new System.Drawing.Point(152, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "đến :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(184, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.Validated += new System.EventHandler(this.den_Validated);
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.CheckOnClick = true;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(66, 149);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(198, 68);
            this.madoituong.TabIndex = 11;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Đối tượng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xuatcstt
            // 
            this.xuatcstt.Location = new System.Drawing.Point(267, 200);
            this.xuatcstt.Name = "xuatcstt";
            this.xuatcstt.Size = new System.Drawing.Size(134, 16);
            this.xuatcstt.TabIndex = 17;
            this.xuatcstt.Text = "Phiếu xuất tủ trực";
            this.xuatcstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // manguon
            // 
            this.manguon.CheckOnClick = true;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(267, 8);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(198, 68);
            this.manguon.TabIndex = 14;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // xem
            // 
            this.xem.Location = new System.Drawing.Point(375, 200);
            this.xem.Name = "xem";
            this.xem.Size = new System.Drawing.Size(104, 16);
            this.xem.TabIndex = 18;
            this.xem.Text = "Xem trước khi in";
            this.xem.CheckedChanged += new System.EventHandler(this.xem_CheckedChanged);
            // 
            // nguoilinh
            // 
            this.nguoilinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoilinh.Location = new System.Drawing.Point(328, 174);
            this.nguoilinh.Name = "nguoilinh";
            this.nguoilinh.Size = new System.Drawing.Size(136, 21);
            this.nguoilinh.TabIndex = 16;
            this.nguoilinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(264, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Người lĩnh :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(360, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Số bản in :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // banin
            // 
            this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banin.Location = new System.Drawing.Point(425, 222);
            this.banin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.banin.Name = "banin";
            this.banin.Size = new System.Drawing.Size(40, 21);
            this.banin.TabIndex = 20;
            this.banin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(66, 78);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(198, 68);
            this.kho.TabIndex = 9;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // p
            // 
            this.p.AutoScroll = true;
            this.p.Location = new System.Drawing.Point(61, 274);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(401, 118);
            this.p.TabIndex = 21;
            // 
            // chkXml
            // 
            this.chkXml.Location = new System.Drawing.Point(6, 222);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(104, 16);
            this.chkXml.TabIndex = 22;
            this.chkXml.Text = "Xuất ra XML";
            // 
            // chkslyeucau
            // 
            this.chkslyeucau.Location = new System.Drawing.Point(6, 237);
            this.chkslyeucau.Name = "chkslyeucau";
            this.chkslyeucau.Size = new System.Drawing.Size(166, 22);
            this.chkslyeucau.TabIndex = 23;
            this.chkslyeucau.Text = "Cập nhật lại SL yêu cầu";
            // 
            // chkChuyenXuatSDCT_Thucxuat
            // 
            this.chkChuyenXuatSDCT_Thucxuat.Location = new System.Drawing.Point(304, 246);
            this.chkChuyenXuatSDCT_Thucxuat.Name = "chkChuyenXuatSDCT_Thucxuat";
            this.chkChuyenXuatSDCT_Thucxuat.Size = new System.Drawing.Size(166, 22);
            this.chkChuyenXuatSDCT_Thucxuat.TabIndex = 24;
            this.chkChuyenXuatSDCT_Thucxuat.Text = "Chuyển Xuatsdct-> Thucxuat";
            this.chkChuyenXuatSDCT_Thucxuat.Visible = false;
            this.chkChuyenXuatSDCT_Thucxuat.CheckedChanged += new System.EventHandler(this.chkChuyenXuatSDCT_Thucxuat_CheckedChanged);
            // 
            // ckNhomIn
            // 
            this.ckNhomIn.CheckOnClick = true;
            this.ckNhomIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNhomIn.Location = new System.Drawing.Point(267, 104);
            this.ckNhomIn.Name = "ckNhomIn";
            this.ckNhomIn.Size = new System.Drawing.Size(198, 68);
            this.ckNhomIn.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(264, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Nhóm in :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbdongy
            // 
            this.cbdongy.AutoSize = true;
            this.cbdongy.Location = new System.Drawing.Point(267, 220);
            this.cbdongy.Name = "cbdongy";
            this.cbdongy.Size = new System.Drawing.Size(89, 17);
            this.cbdongy.TabIndex = 26;
            this.cbdongy.Text = "Phiếu đông y";
            this.cbdongy.UseVisualStyleBackColor = true;
            // 
            // frmInphieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(481, 401);
            this.Controls.Add(this.cbdongy);
            this.Controls.Add(this.ckNhomIn);
            this.Controls.Add(this.chkChuyenXuatSDCT_Thucxuat);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.p);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.banin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nguoilinh);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.xem);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.xuatcstt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkslyeucau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInphieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In phiếu";
            this.Load += new System.EventHandler(this.frmInphieu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInphieu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.banin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmInphieu_Load(object sender, System.EventArgs e)
		{
            
            bSLYeucau = d.bSLYeucau(i_nhom);
            chkslyeucau.Visible = bSLYeucau;
            user = d.user; xxx = user + s_mmyy; f_ngay = d.f_ngay; stime = "'" + m.f_ngay + "'";
            
            bInngang = d.bPhieulinh_ngang(i_nhom); bLinh_dongia = d.bPhieulinh_dongia(i_nhom) || d.bPhieulinh_dongia_losx_date(i_nhom);
			bDoituong_phieulinh=d.bDoituong_Phieulinh(i_nhom);
			xem.Checked=d.bPreview;
            bPhatthuoc_kho_khoa = m.bPhatthuoc_kho_khoa;
			banin.Enabled=!xem.Checked;
            if (d.bIntheocstt(i_nhom) && i_loai == 2) label1.Text = "Tủ trực :";
            s_doc = ""; bInphieu_ngay = d.bInphieu_ngay(i_nhom);
            if (!bInphieu_ngay)
            {
                this.ClientSize = new System.Drawing.Size(480, 280);
                p.Visible = false;
            }
            bChuky = m.bChuky;
            bNgayylenh_phieulinh = d.bNgayylenh_phieulinh(i_nhom);
			if (d.bHoten_docGN(i_nhom)!=0) s_doc+=d.bHoten_docGN(i_nhom).ToString()+",";
			if (d.bHoten_docHTT(i_nhom)!=0) s_doc+=d.bHoten_docHTT(i_nhom).ToString()+",";
			if (d.bHoten_docAB(i_nhom)!=0) s_doc+=d.bHoten_docAB(i_nhom).ToString()+",";
            s_doc=(s_doc!="")?s_doc.Substring(0,s_doc.Length-1):"";
			bNhomin_mabd=d.bNhomin_mabd(i_nhom);
			xuatcstt.Enabled=i_loai==2 || bBuhaophi;
			i_songay=d.Ngay_in_phieu(i_nhom);
			ds.ReadXml("..\\..\\..\\xml\\d_inphieu.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_inphieu.xml");
            if (bChuky)
            {
                dtbs = d.get_data("select * from "+user+".dmbs where nhom=" + LibMedi.AccessData.truongkhoa).Tables[0];
                DataColumn dc = new DataColumn("image_duoc", typeof(byte[]));
                dsxml.Tables[0].Columns.Add(dc);
                dc = new DataColumn("image_dieutri", typeof(byte[]));
                dsxml.Tables[0].Columns.Add(dc);
            }
            dsxml.Tables[0].Columns.Add("CHANDOAN");
            dsxml.Tables[0].Columns.Add("MAICD");
            dsxml.Tables[0].Columns.Add("NGAYDUYET");
            try
            {
                dsxml.Tables[0].Columns.Add("NGUOIDUYET");
            }
            catch { }
            ds.Tables[0].Columns.Add("MABN");
            dsxml.Tables[0].Columns.Add("MABN");
            try
            {
                ds.Tables[0].Columns.Add("LOSX");
                dsxml.Tables[0].Columns.Add("LOSX");
            }
            catch { }
            try//gam 12/12/2011
            {
                ds.Tables[0].Columns.Add("MANHOM1");
                dsxml.Tables[0].Columns.Add("MANHOM1");
                ds.Tables[0].Columns.Add("TENNHOM1");
                dsxml.Tables[0].Columns.Add("TENNHOM1");
            }
            catch { }

            try
            {
                ds.Tables[0].Columns.Add("HANDUNG");
                dsxml.Tables[0].Columns.Add("HANDUNG");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("giaban");
                dsxml.Tables[0].Columns.Add("giaban");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("tennguon");
                dsxml.Tables[0].Columns.Add("tennguon");
            }
            catch { }
            //khuyen 10/01/2014
            try
            {
                ds.Tables[0].Columns.Add("sothangdongy");
                dsxml.Tables[0].Columns.Add("sothangdongy");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("slmotthang");
                dsxml.Tables[0].Columns.Add("slmotthang");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("sothe");
                dsxml.Tables[0].Columns.Add("sothe");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("giuong");
                dsxml.Tables[0].Columns.Add("giuong");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("doituong");
                dsxml.Tables[0].Columns.Add("doituong");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("sonha");
                dsxml.Tables[0].Columns.Add("sonha");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("thon");
                dsxml.Tables[0].Columns.Add("thon");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("tenpxa");
                dsxml.Tables[0].Columns.Add("tenpxa");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("tenquan");
                dsxml.Tables[0].Columns.Add("tenquan");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("tentt");
                dsxml.Tables[0].Columns.Add("tentt");
            }
            catch { }
            //11/03/14
            try
            {
                ds.Tables[0].Columns.Add("tungay");
                dsxml.Tables[0].Columns.Add("tungay");
            }
            catch { }
            try
            {
                ds.Tables[0].Columns.Add("denngay");
                dsxml.Tables[0].Columns.Add("denngay");
            }
            catch { }
            //
           
            //sql = "select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,a.tenhc,c.ten as tennhom," +
            //    "c.stt as manhom,c.stt,d.ten as tenhang,e.ten as tennhom1,e.stt as manhom1 from " + user + ".d_dmbd a," +
            //    user + ".d_dmnhom b," + user + ".d_dmnhom e," + user + ".d_nhomin c," + user + ".d_dmhang d";
            //sql += " where a.manhom=b.id ";
            //if (bNhomin_mabd) sql += " and a.nhomin=c.id ";
            //else sql += " and b.nhomin=c.id ";
            //if (bNhomin_mabd) sql += " and b.nhomin=e.id ";//gam 12/12/2011
            //else sql += " and a.nhomin=e.id ";
            //sql += " and a.mahang=d.id and a.nhom=" + i_nhom;

            if (bNhomin_mabd)//gam 22/12/2011 
            {
                sql = "select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,a.tenhc,(case when c.ten is null then '' else c.ten end) as tennhom,(case when c.stt is null then -1 else c.stt end) as manhom,";
                sql += "c.stt,d.ten as tenhang,(case when e.ten is null then '' else e.ten end ) as tennhom1,(case when e.stt is null then -1 else e.stt end) as manhom1 "; //gam 13042012 sửa e.stt --> (case when e.stt is null then -1 else e.stt end)
                sql += "from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b on a.manhom=b.id left join " + user + ".d_dmnhom e on b.nhomin=e.id left join ";
                sql += user + ".d_nhomin c on a.nhomin=c.id inner join " + user + ".d_dmhang d on a.mahang=d.id where a.nhom=" + i_nhom;
            }
            else
            {
                sql = "select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,a.tenhc,(case when c.ten is null then '' else c.ten end) as tennhom,(case when c.stt is null then -1 else c.stt end) as manhom,";
                sql += "c.stt,d.ten as tenhang,(case when e.ten is null then '' else e.ten end ) as tennhom1,(case when e.stt is null then -1 else e.stt end) as manhom1 from " + user + ".d_dmbd a left join " + user + ".d_dmnhom b on a.manhom=b.id ";
                sql += "left join " + user + ".d_nhomin e on a.nhomin=e.id inner join ";
                sql += "" + user + ".d_nhomin c on b.nhomin=c.id inner join " + user + ".d_dmhang d on a.mahang=d.id where a.nhom=" + i_nhom;
            }
			dt=d.get_data(sql).Tables[0];
			tu.Value=new DateTime(int.Parse(s_ngay.Substring(6,4)),int.Parse(s_ngay.Substring(3,2)),int.Parse(s_ngay.Substring(0,2)),0,0,0);
			den.Value=tu.Value;
            /*
			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";
			phieu.DataSource=dtphieu;
			if (i_phieu!=-1) phieu.SelectedValue=i_phieu.ToString();
			else phieu.SelectedIndex=0;
            */
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			makp.DataSource=dtkp;
			if (i_makp!=-1) makp.SelectedValue=i_makp.ToString();
			else makp.SelectedIndex=0;

			if (d.bQuanlynguon(i_nhom))
                dtnguon = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by id").Tables[0];
			else
                dtnguon = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by id").Tables[0];
			manguon.DataSource=dtnguon;
            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";

            //khuyen 10/01/2014

            dtnhomin = d.get_data("select * from " + user + ".d_nhomin where nhom=" + i_nhom + " order by stt").Tables[0];
            ckNhomIn.DataSource = dtnhomin;
            ckNhomIn.DisplayMember = "TEN";
            ckNhomIn.ValueMember = "ID";
            //

            dtdt = d.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madoituong.DataSource=dtdt;
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";

			if (bDoituong_phieulinh)
			{
				foreach(DataRow r in dtdt.Rows)
				{
					dc=new DataColumn();
					dc.ColumnName="c_"+r["madoituong"].ToString().Trim();
					dc.DataType=Type.GetType("System.Decimal");
					ds.Tables[0].Columns.Add(dc);
					dc=new DataColumn();
					dc.ColumnName="c_"+r["madoituong"].ToString().Trim();
					dc.DataType=Type.GetType("System.Decimal");
					dsxml.Tables[0].Columns.Add(dc);
				}
			}
			load_makho();
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";

			if (bBuhaophi)
			{
                file1 = "d_haophill"; file2 = "d_haophict";
			}
			else
			{
				switch (i_loai)
				{
                    case 1: file1 = "d_dutrull"; file2 = "d_dutruct";
						break;
                    case 2: file1 = "d_xtutrucll"; file2 = "d_xtutrucct";
						break;
                    case 3: file1 = "d_hoantrall"; file2 = "d_hoantract";
						break;
                    default: file1 = "d_haophill"; file2 = "d_haophict";
						break;
				}
			}
            load_phieu();
		}

		private void load_makho()
		{
			s_makho="";
			sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
            if (i_khudt != 0) sql += " and (khu=0 or khu =" + i_khudt + ")";//binh 210411
			if (s_kho!="")
			{
				sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				DataRow r=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
				if (r!=null) nguoilinh.Text=r["nguoilinh"].ToString();
			}
			else 
			{
				DataRow r=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
				if (r!=null) s_makho=r["makho"].ToString();
				if (s_makho=="") 
				{
                    string sql1 = "select kho from " + user + ".d_dmphieu where nhom=" + i_nhom;
					if (bBuhaophi) sql1+=" and id=4";
					else sql1+=" and id="+i_loai;
					DataTable tmp=d.get_data(sql1).Tables[0];
					if (tmp.Rows.Count>0) s_makho=tmp.Rows[0][0].ToString();
				}
				if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Trim().Length-1)+")";
				if (r!=null) nguoilinh.Text=r["nguoilinh"].ToString();
			}
			sql+=" order by stt";
            if (bPhatthuoc_kho_khoa)
            {
            	sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
                if (i_khudt != 0) sql += " and (khu=0 or khu =" + i_khudt + ")";//binh 210411
                if (s_kho != "") sql += " and id in (" + s_kho.Substring(0, s_kho.Trim().Length - 1) + ")";
                else
                {
                    string skho = d.get_data("select kho from " + user + ".d_dmphieu where id=" + i_loai).Tables[0].Rows[0][0].ToString();
                    if (skho != "") sql += " and id in (" + skho.Substring(0, skho.Trim().Length - 1) + ")";
                }
                sql += " order by stt";
            }
			dtkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
		}

        private void load_phieu()
        {
            string s_phieuk = "", s_loai = "";
            if (bThua) sql = "select * from " + user + ".d_loaiphieu where id=0";
            else
            {
                string s_phieu = "";
                if (s_kho != "")
                {
                    sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
                    if (s_kho != "") sql += " and id in (" + s_kho.Substring(0, s_kho.Trim().Length - 1) + ")";
                    if (i_khudt != 0) sql += " and (khu=0 or khu =" + i_khudt + ")";//binh 210411
                    foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                    {
                        s_phieuk += r["phieu"].ToString();
                        s_loai += r["loaiphieu"].ToString();
                    }
                }
                /*
                string tenfile = (i_loai == 2) ? "d_bucstt" : "d_xuatsdct";
                sql = "select distinct a.phieu from " + xxx + ".d_xuatsdll a," + xxx + "." + tenfile + " b where a.id=b.id and a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (makp.SelectedIndex != -1) sql += " and a.makp=" + int.Parse(makp.SelectedValue.ToString());
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    s_phieu += r["phieu"].ToString() + ",";
                */
                sql = "select * from " + user + ".d_loaiphieu where nhom=" + i_nhom;
                sql += " and (loai=" + i_loai;
                if (i_loai == 3) { sql += " or id=0"; }
                sql += ")";
                //if (s_phieu != "") sql += " and id in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                if (s_phieuk.IndexOf(i_loai.ToString()) != -1 && s_loai != "") sql += " and id in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
                //sql += " and id<>0 order by stt";//gam 19/12/2011 comment bv yêu cầu được in phiếu hoàn trả thừa theo khoa phòng
                sql += " order by stt";
            }
            dtphieu = d.get_data(sql).Tables[0];
            phieu.DataSource = dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
            if (i_phieu > 0 && phieu.Items.Count > 0) phieu.SelectedValue = i_phieu;
        }

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
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (m.songay(m.StringToDate(den.Text),m.StringToDate(tu.Text),1)>i_songay)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số ngày in phiếu (")+i_songay.ToString()+")",d.Msg);
				tu.Focus();
				return;
			}
			if (makp.SelectedIndex==-1 || phieu.SelectedIndex==-1)
			{
				if (makp.SelectedIndex==-1) makp.Focus();
				else phieu.Focus();
				return;
			}
            //binh 110413
            if(chkChuyenXuatSDCT_Thucxuat.Checked && i_loai!=2)
            {
                Chuyen_Xuatsdct_Thucxuat(s_mmyy, den.Text, int.Parse(phieu.SelectedValue.ToString()), int.Parse(makp.SelectedValue.ToString()));
            }
            else if (chkChuyenXuatSDCT_Thucxuat.Checked && i_loai == 2)
            {
                Chuyen_bucstt_Thucbucstt(s_mmyy, den.Text, int.Parse(phieu.SelectedValue.ToString()), int.Parse(makp.SelectedValue.ToString()));
            }
            //
            if (chkslyeucau.Checked) capnhat_d_ngayduyet(s_mmyy,tu.Text,den.Text,i_loai,int.Parse(phieu.SelectedValue.ToString()),int.Parse(makp.SelectedValue.ToString()));
			i_makp=int.Parse(makp.SelectedValue.ToString());
			i_phieu=int.Parse(phieu.SelectedValue.ToString());
			s_makho="";s_tenkho="";
			s_madt="";s_tendt="";
            s_manguon = ""; s_tennguon = ""; s_nhomin = ""; s_tennhomin = "";


            //khuyen 10/01/14
            if (ckNhomIn.CheckedItems.Count == 0)
                for (int i = 0; i < ckNhomIn.Items.Count; i++) s_nhomin += dtnhomin.Rows[i]["id"].ToString() + ",";
            else
            {
                for (int i = 0; i < ckNhomIn.Items.Count; i++)
                {
                    if (ckNhomIn.GetItemChecked(i))
                    {
                        s_nhomin += dtnhomin.Rows[i]["id"].ToString() + ",";
                        s_tennhomin += dtnhomin.Rows[i]["ten"].ToString() + ";";
                    }
                }
            }
            //
			if (madoituong.CheckedItems.Count==0)
				for(int i=0;i<madoituong.Items.Count;i++) s_madt+=dtdt.Rows[i]["madoituong"].ToString()+",";
			else
			{
				for(int i=0;i<madoituong.Items.Count;i++)
				{
					if (madoituong.GetItemChecked(i))
					{
						s_madt+=dtdt.Rows[i]["madoituong"].ToString()+",";
						s_tendt+=dtdt.Rows[i]["doituong"].ToString()+";";
					}
				}
			}
			if (manguon.CheckedItems.Count==0)
				for(int i=0;i<manguon.Items.Count;i++) s_manguon+=dtnguon.Rows[i]["id"].ToString().Trim()+",";
			else
			{
				for(int i=0;i<manguon.Items.Count;i++)
				{
					if (manguon.GetItemChecked(i))
					{
						s_manguon+=dtnguon.Rows[i]["id"].ToString().Trim()+",";
						s_tennguon+=dtnguon.Rows[i]["ten"].ToString()+";";
					}
				}
			}
			if (kho.CheckedItems.Count==0)
				for(int i=0;i<kho.Items.Count;i++) s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
			else
			{
				for(int i=0;i<kho.Items.Count;i++)
				{
					if (kho.GetItemChecked(i))
					{
						s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
						s_tenkho+=dtkho.Rows[i]["ten"].ToString()+";";
					}
				}
			}
            string cont="",tuden="";
            if (tu.Text != den.Text && bInphieu_ngay)
            {
                foreach (Control c in this.p.Controls)
                {
                    if (c.Name.ToString() == "ng")
                    {
                        cont += "(to_char(a.ngay,'dd/mm/yyyy')='" + c.Text + "'";
                        tuden += c.Text;
                    }
                    if (c.Name.ToString() == "ph")
                    {
                        ComboBox cb = (ComboBox)c;
                        if (cb.SelectedIndex != -1)
                        {
                            cont += " and a.phieu=" + int.Parse(cb.SelectedValue.ToString());
                            tuden += " " + cb.Text.Trim();
                        }
                        cont += ") or ";
                        tuden += ";";
                    }
                }
            }
            if (cont != "") cont = cont.Substring(0, cont.Length - 4);
            sql = "select a.nhom, a.ngay, a.makp, a.loai, a.phieu, a.makp, a.done, a.duyettreole, a.userid from xxx.d_daduyet a where a.nhom=" + i_nhom;
            sql += " and a.makp=" + i_makp + " and a.loai=" + i_loai;
            if (cont != "") sql += " and (" + cont + ")";
            else sql += " and a.phieu=" + i_phieu+" and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (s_makho!="") sql += " and a.makho in (" + s_makho.Substring(0, s_makho.Trim().Length - 1) + ")";
            if (d.get_thuoc(tu.Text, den.Text, sql).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
                tu.Focus();
                return;
            }
			ds.Clear();
            s_idduyet = ""; s_ngayylenhduyet = "";
			string s_idstt="",s_id="";
            s_id ="a.id in ( ";
            sql = "select a.idduyet,a.sttduyet from " + xxx + ".d_ngayduyet a where a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and a.makp=" + i_makp;
            if (cont != "") sql += " and (" + cont + ")";
            else sql+=" and a.ngay between to_date('" + tu.Text + "','" + f_ngay + "') and to_date('" + den.Text + "','" + f_ngay + "') and a.phieu=" + i_phieu;
            //foreach (DataRow r in d.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0].Rows) truongthuy :02052014
            foreach (DataRow r in d.get_data_mmyy(sql,tu.Text,den.Text,true).Tables[0].Rows)
			{
               
                    s_idduyet += "(a.id=" + decimal.Parse(r["idduyet"].ToString());
                    if (r["sttduyet"].ToString() != "")
                        s_idduyet += " and b.sttduyet in (" + r["sttduyet"].ToString().Trim().Substring(0, r["sttduyet"].ToString().Trim().Length - 1) + ")";
                    s_idduyet += ") or ";

                    //s_idstt+="(a.id="+decimal.Parse(r["idduyet"].ToString());
                     if (r["sttduyet"].ToString() != "")
                        {
                            s_id += (decimal.Parse(r["idduyet"].ToString()) + "," );//gam 05/09/2011
                            s_idstt += "(a.id=" + decimal.Parse(r["idduyet"].ToString());
                            s_idstt += " and b.stt in (" + r["sttduyet"].ToString().Trim().Substring(0, r["sttduyet"].ToString().Trim().Length - 1) + ")";
                            s_idstt += ") or ";
                        }
                        //s_idstt+=") or ";
			}
            
			if (s_idduyet=="")
			{
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
				tu.Focus();
				return;
			}

            //bbbb
            sql = "select to_char(min(ngayylenh),'dd/mm/yyyy') as ngayylenh from " + xxx + ".d_xuatsdll a where a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and a.makp=" + i_makp;
            if (cont != "") sql += " and (" + cont + ")";
            else sql += " and a.ngay between to_date('" + tu.Text + "','" + f_ngay + "') and to_date('" + den.Text + "','" + f_ngay + "') and a.phieu=" + i_phieu;
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                s_ngayylenhduyet=r["ngayylenh"].ToString();
            }
            //bbbb
            if (s_idstt != "" ) s_idstt = s_idstt.Substring(0, s_idstt.Length - 4);
			if (s_idduyet!="" ) s_idduyet=s_idduyet.Substring(0,s_idduyet.Length-4);
            if(s_id != "") {s_id = s_id.Substring(0, s_id.Length - 1);s_id += ") ";}//gam 05/09/2011
            if (bSLYeucau && s_idstt!="" && s_id != "")
            {

               //khuyen khoa 11/01/14 ds = d.get_slyeucau(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_doc, i_nhom, s_ngayylenhduyet,s_id);//gam 05/09/2011
                //khuyen 11/01/14 them tham so s_nhomin
                ds = d.get_slyeucau(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_doc, i_nhom, s_ngayylenhduyet,s_id,s_nhomin);//gam 05/09/2011
                //
                if (s_doc!="") 
                   //khuyen khoa 13/01/2014 tmpyc = d.get_slyeucau_doc(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_doc).Tables[0];
                   //khuyen 13/01/2014
                    if (s_nhomin == "") tmpyc = d.get_slyeucau_doc(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_doc).Tables[0];
                    else tmpyc = d.get_slyeucau_doc(tu.Text, den.Text, ds, dt, dtkho, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, dtdt, bDoituong_phieulinh, bNhomin_mabd, s_nhomin.Substring(0,s_nhomin.Length-1)).Tables[0];
                //
            }
            //Tu:23/08/2011
            DataSet ds_tmp = new DataSet();
            ds_tmp = ds.Copy(); 
            //ds.Clear();// binh bo ra
			if (xuatcstt.Checked)
			{
				tieude="PHIẾU XUẤT TỦ TRỰC";
                if (bLinh_dongia)
                {
                    ds = d.get_xuatcstt_dongia(tu.Text, den.Text, ds, dt, dtkho, s_idduyet, s_madt, s_makho, s_manguon, bBuhaophi, s_doc, bNhomin_mabd, dtdt, bDoituong_phieulinh, i_nhom);//ds=d.get_xuatcstt_dongia(s_mmyy,ds,dt,dtkho,s_idduyet,s_madt,s_makho,s_manguon,bBuhaophi,s_doc,bNhomin_mabd,dtdt,bDoituong_phieulinh,i_nhom);
                }
                else
                {
                    ds = d.get_xuatcstt(tu.Text,den.Text, ds, dt, dtkho, s_idduyet, s_madt, s_makho, s_manguon, bBuhaophi, s_doc, bNhomin_mabd, dtdt, bDoituong_phieulinh);
                    //ds = d.get_xuatcstt(s_mmyy, ds, dt, dtkho, s_idduyet, s_madt, s_makho, s_manguon, bBuhaophi, s_doc, bNhomin_mabd, dtdt, bDoituong_phieulinh);
                }
			}
			else
			{
                if (bLinh_dongia)
                {
                   //khuyen khoa 11/01/2014 ds = d.get_slxuat_dongia(ds, dt, dtkho, tu.Text, den.Text, s_mmyy, i_nhom, i_loai, i_phieu, i_makp, s_madt, s_makho, s_manguon, bBuhaophi, s_doc, bNhomin_mabd, dtdt, bDoituong_phieulinh, cont,s_nhomin);
                   // khuyen 11/01/2014 them tham so s_nhomin
                    ds = d.get_slxuat_dongia(ds, dt, dtkho, tu.Text, den.Text, s_mmyy, i_nhom, i_loai, i_phieu, i_makp, s_madt, s_makho, s_manguon, bBuhaophi, s_doc, bNhomin_mabd, dtdt, bDoituong_phieulinh, cont, s_nhomin);
                    //
                }
                else
                    ds = d.get_slxuat(ds, dt, dtkho, tu.Text, den.Text, s_mmyy, i_nhom, i_loai, i_phieu, i_makp, s_madt, s_makho, s_manguon, bBuhaophi, s_doc, bNhomin_mabd, dtdt, bDoituong_phieulinh, cont);
				if (bBuhaophi) tieude="PHIẾU BÙ";
				else tieude=s_title;
			}
            //gam 14/09/2011 
            #region Binh bo phan xu ly so luong yeu cau 15042013
            //if (i_loai == 2)//binh 15042013 -- truong hop nay chi xet cho bu tu truc
            //{
            //    DataSet ds_tam = ds_tmp.Clone();
            //    string s_mabdduyet = "";
            //    foreach (DataRow row in ds_tmp.Tables[0].Rows)
            //    {                   
            //        DataRow[] arRow = ds.Tables[0].Select("mabd=" + row["mabd"].ToString());
            //        if (arRow.Length > 1) // trường hợp 1 thuốc dược duyệt bù 2 thuốc cùng mabd nhưng khác số stt --> yêu cầu 1 dòng nhưng bù 2 dòng
            //        {
            //            row["soluong"] = arRow[0]["soluong"].ToString();
            //            row["dongia"] = (bLinh_dongia) ? decimal.Parse(arRow[0]["dongia"].ToString()) : 0;
            //            row["giaban"] = arRow[0]["giaban"].ToString();
            //            row["tenkho"] = arRow[0]["tenkho"].ToString();//gam 12/09/2011 lay ten kho + ten tu truc
            //            s_mabdduyet += row["mabd"].ToString() + ",";
            //            for (int i = 1; i < arRow.Length; i++)
            //            {
            //                DataRow rct = ds_tam.Tables[0].NewRow();
            //                for (int j = 0; j < rct.ItemArray.Length; j++)
            //                {
            //                    if (row[j].ToString() != "")
            //                        rct[j] = row[j].ToString();
            //                }
            //                rct["soluong"] = arRow[i]["soluong"].ToString();
            //                row["giaban"] = arRow[0]["giaban"].ToString();
            //                rct["dongia"] = decimal.Parse(arRow[i]["dongia"].ToString() == "" ? "0" : arRow[i]["dongia"].ToString());//gam 04/11/2011 bv quỳnh phụ không nhập giá khi gán báo lỗi
            //                rct["tenkho"] = arRow[i]["tenkho"].ToString();//gam 12/09/2011 lay ten kho + ten tu truc
            //                ds_tam.Tables[0].Rows.Add(rct);
            //            }

            //        }
            //        else if (arRow.Length == 1)// trường hợp 1 thuốc được duyệt = số lượng yêu cầu, yêu cầu 1 dòng, duyệt 1 dòng
            //        {
            //            s_mabdduyet += row["mabd"].ToString() + ",";
            //            foreach (DataRow row1 in ds.Tables[0].Select("mabd=" + row["mabd"].ToString() + ""))
            //            {
            //                row["soluong"] = row1["soluong"].ToString();
            //                row["giaban"] = row1["giaban"].ToString();
            //                row["dongia"] = decimal.Parse(row1["dongia"].ToString() == "" ? "0" : row1["dongia"].ToString());//gam 04/11/2011 bv quỳnh phụ không nhập giá khi gán báo lỗi
            //                row["tenkho"] = row1["tenkho"].ToString();//gam 12/09/2011 lay ten kho + ten tu truc
            //            }
            //        }

            //    }
            //    // xét trường hợp duyệt thuốc tương đương mabd thuốc bù không nằm trong danh sách mabd yeu cau --> add số lượng thực phát
            //    if (s_mabdduyet != "")
            //    {
            //        foreach (DataRow row in ds.Tables[0].Select("mabd not in (" + s_mabdduyet.Trim(',') + ")"))
            //        {
            //            DataRow rct = ds_tam.Tables[0].NewRow();
            //            for (int j = 0; j < rct.ItemArray.Length; j++)
            //            {
            //                if (row[j].ToString() != "")
            //                    rct[j] = row[j].ToString();
            //            }
            //            ds_tam.Tables[0].Rows.Add(rct);
            //        }
            //    }
            //    else
            //    {
            //        foreach (DataRow row in ds.Tables[0].Rows)
            //        {
            //            DataRow rct = ds_tam.Tables[0].NewRow();
            //            for (int j = 0; j < rct.ItemArray.Length; j++)
            //            {
            //                if (row[j].ToString() != "")
            //                    rct[j] = row[j].ToString();
            //            }
            //            ds_tam.Tables[0].Rows.Add(rct);
            //        }
            //    }
            //    //end gam
            //    ds_tmp.Merge(ds_tam);
            //    if (ds_tmp.Tables[0].Rows.Count > 0)
            //    {
            //        ds.Clear();
            //        ds_tmp.AcceptChanges();
            //        ds = ds_tmp.Copy();
            //        ds_tmp.Clear();
            //    }
            //    //end Tu
            //}//end binh
            #endregion //binh bo phan xu ly slyeu cau 15042013
            if (ds.Tables[0].Rows.Count==0 && s_doc=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
			if (bLinh_dongia)
                
				d.sort_inphieu_dongia(dsxml,ds,bSLYeucau,s_mmyy,tu.Text,i_nhom,i_makp,i_loai,i_phieu,s_makho,s_madt,s_manguon,nguoilinh.Text,dtdt,bDoituong_phieulinh,(xuatcstt.Checked)?false:(i_loai==2)?true:bBuhaophi);
			else
				d.sort_inphieu(dsxml,ds,bSLYeucau,s_mmyy,tu.Text,i_nhom,i_makp,i_loai,i_phieu,s_makho,s_madt,s_manguon,nguoilinh.Text,dtdt,bDoituong_phieulinh,(xuatcstt.Checked)?false:(i_loai==2)?true:bBuhaophi);
			if (bDoituong_phieulinh) 
			{
				tenfile=(bLinh_dongia)?"d_phieulanh_yc_dt_dg":"d_phieulanh_yc_dt";
				tenfile=(m.Mabv_so==701424)?"d_phieulanh_dt_dg":tenfile;
			}
			else if (bInngang) tenfile="d_phieulanh_ng";
			else
			{
				tenfile=(bSLYeucau)?"d_phieulanh_yc":"d_phieulanh";
				tenfile+=(bLinh_dongia)?"_dg":"";
			}
            if (tieude == "PHIẾU HOÀN TRẢ")
            {
                if (System.IO.File.Exists("..//..//..//report//" + tenfile + "_ht.rpt"))
                {
                    tenfile += "_ht";//gam 03/11/2011 phiếu hoàn trả in riêng report
                }
            }
            string ngayylenh = "",ngayduyet="",s_dk="";
            s_dk = " and a.makhoa=" + i_makp + " and a.loai=" + i_loai;
            s_dk += " and a.phieu=" + i_phieu + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (bNgayylenh_phieulinh)
            {
                ngayylenh = d.get_ngayylenh(tu.Text, den.Text, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, bNhomin_mabd, s_doc, false);
                ngayduyet = d.get_ngayduyet(tu.Text, den.Text, i_loai,"d_xuatsdll",(i_loai==2)?"d_thucbucstt":"d_thucxuat", s_dk, s_madt, s_makho, s_manguon, bBuhaophi, bNhomin_mabd, s_doc, false);
            }
            if (ngayylenh != "" && ngayduyet!="")
            {
                foreach (DataRow r in dsxml.Tables[0].Rows)
                {
                    r["ngayylenh"] = ngayylenh;
                    r["ngayduyet"] = ngayduyet.Substring(0,ngayduyet.IndexOf("^"));
                    r["nguoiduyet"] = ngayduyet.Substring(ngayduyet.IndexOf("^")+1);
                }
            }

            bool bDuoc = false, bDieutri = false;
            if (bChuky)
            {
                DataRow r1 = m.getrowbyid(dtbs, "makp='" + dtkp.Rows[makp.SelectedIndex]["makp"].ToString() + "'");
                if (r1 != null)
                {
                    string truongkhoa = r1["ma"].ToString().Trim();
                    if (File.Exists("..\\..\\..\\chuky\\" + truongkhoa + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\..\\chuky\\" + truongkhoa + ".bmp", FileMode.Open, FileAccess.Read);
                        image_dieutri = new byte[fstr.Length];
                        fstr.Read(image_dieutri, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                        bDieutri = true;
                    }
                }
                string truongkho = "kho"+i_nhom.ToString();
                if (File.Exists("..\\..\\..\\chuky\\" + truongkho + ".bmp"))
                {
                    fstr = new FileStream("..\\..\\..\\chuky\\" + truongkho + ".bmp", FileMode.Open, FileAccess.Read);
                    image_duoc = new byte[fstr.Length];
                    fstr.Read(image_duoc, 0, System.Convert.ToInt32(fstr.Length));
                    fstr.Close();
                    bDuoc = true;
                }
                foreach (DataRow r in dsxml.Tables[0].Rows)
                {
                    if (bDuoc) r["Image_duoc"] = image_duoc;
                    if (bDieutri) r["Image_dieutri"] = image_dieutri;
                }
            }
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\inphieu.xml",XmlWriteMode.WriteSchema);
            }
            if (dsxml.Tables[0].Rows.Count > 0)
            {
                try
                {
                    int isolanintoida = d.solaninphieulinh(i_nhom);
                    if (int.Parse(dsxml.Tables[0].Rows[0]["lanin"].ToString()) > isolanintoida)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số lần in vượt quá số lần cho phép là :" + isolanintoida.ToString() + "."), lan.Change_language_MessageText("In phiếu"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                catch { }
            }
			if (xem.Checked)
			{
                //khuyen khoa 10/01/2014
                //frmReport f = new frmReport(d, dsxml.Tables[0], tenfile + ".rpt", makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, s_ngay, s_userid);
                //f.ShowDialog(this);
                if (dsxml.Tables[0].Rows.Count > 0 )
                {
                    frmReport f = new frmReport(d, dsxml.Tables[0], i_userid, tenfile + ".rpt", makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, s_ngay, s_userid);
                    f.ShowDialog(this);
                }
			}
			else 
			{
                prn.Printer(d, dsxml, tenfile + ".rpt", makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, s_ngay, s_userid, (bInngang || bDoituong_phieulinh) ? 2 : 1, Convert.ToInt16(banin.Value));
				MessageBox.Show(lan.Change_language_MessageText("Đang in")+" "+tieude,lan.Change_language_MessageText("In phiếu"),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

			if (s_doc!="")
			{                
				dsxml=d.get_slxuat_doc(dsxml,tu.Text,den.Text,s_mmyy,i_nhom,i_loai,i_phieu,i_makp,s_madt,s_makho,s_manguon,bBuhaophi,s_doc,bNhomin_mabd,nguoilinh.Text,cont,tmpyc);
				if(dsxml.Tables[0].Rows.Count<=0)return;
                ngayylenh = ngayduyet="";
                if (bNgayylenh_phieulinh)
                {
                    ngayylenh = d.get_ngayylenh(tu.Text, den.Text, i_loai, file1, file2, s_idstt, s_madt, s_makho, s_manguon, bBuhaophi, bNhomin_mabd, s_doc, true);
                    ngayduyet = d.get_ngayduyet(tu.Text, den.Text, i_loai, "d_xuatsdll", (i_loai == 2) ? "d_thucbucstt" : "d_thucxuat", s_dk, s_madt, s_makho, s_manguon, bBuhaophi, bNhomin_mabd, s_doc, true);
                }
                if (ngayylenh != "" && ngayduyet!="")
                {
                    foreach (DataRow r in dsxml.Tables[0].Rows)
                    {
                        r["ngayylenh"] = ngayylenh;
                        r["ngayduyet"] = ngayduyet.Substring(0, ngayduyet.IndexOf("^"));
                        r["nguoiduyet"] = ngayduyet.Substring(ngayduyet.IndexOf("^") + 1);
                    }
                }
               //khuyen khoa 13/01/14 tenfile = "d_pldoc.rpt";
                //khuyen 13/01/14
                if (s_doc == "3" && cbdongy.Checked)
                {
                    tenfile = "d_pldoc1.rpt";
                }
                else
                {
                    tenfile = "d_pldoc.rpt";
                }
                //
                if (bChuky)
                {
                    foreach (DataRow r in dsxml.Tables[0].Rows)
                    {
                        if (bDuoc) r["Image_duoc"] = image_duoc;
                        if (bDieutri) r["Image_dieutri"] = image_dieutri;
                    }
                }
                if (chkXml.Checked)
                {
                    if (!System.IO.Directory.Exists("..//..//dataxml")) System.IO.Directory.CreateDirectory("..//..//dataxml");
                    //khuyen khoa 10/01/14 dsxml.WriteXml("..\\xml\\inphieudoc.xml", XmlWriteMode.WriteSchema);
                    //khuyen 10/01/14
                    dsxml.WriteXml("..//..//dataxml//d_inphieudongy.xml", XmlWriteMode.WriteSchema);
                }
				if (xem.Checked)
				{
                    frmReport f = new frmReport(d, dsxml.Tables[0],i_userid, tenfile, makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, s_ngay, s_userid);
					f.ShowDialog(this);
				}
				else 
				{
                    prn.Printer(d, dsxml, tenfile, makp.Text, tieude, (tuden != "") ? tuden : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (tuden != "") ? "" : phieu.Text, s_tendt, s_tenkho, s_tennguon, s_mmyy, s_ngay,s_userid, 1, Convert.ToInt16(banin.Value));
					MessageBox.Show(lan.Change_language_MessageText("Đang in")+" "+tieude,lan.Change_language_MessageText("In phiếu"),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)	SendKeys.Send("{Tab}");
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp) load_makho();
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (kho.SelectedIndex==-1 && kho.Items.Count>0) kho.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (i_songay==1) den.Value=tu.Value;
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
            p.Controls.Clear();
			if (i_songay==1) tu.Value=den.Value;
            else if (tu.Text!=den.Text && bInphieu_ngay)
            {
                DateTimePicker dt;
                ComboBox cb;
                int t=0;
                for (int i = 0; i <= d.songay(d.StringToDate(den.Text), d.StringToDate(tu.Text), 0); i++)
                {
                    dt = new DateTimePicker();
                    dt.Name = "ng"; dt.Left = 0; dt.Top = t; dt.Size = new System.Drawing.Size(80, 21);
                    dt.CustomFormat = "dd/MM/yyyy";
                    dt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                    dt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
                    dt.Value = d.StringToDate(tu.Text).AddDays(i);
                    cb = new ComboBox();
                    cb.Name = "ph"; cb.Left = 82; cb.Top = t; cb.Size = new System.Drawing.Size(300, 21);
                    cb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    cb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
                    cb.DisplayMember = "TEN";
                    cb.ValueMember = "ID";
                    cb.DataSource = d.get_data("select * from " + user + ".d_loaiphieu where nhom=" + i_nhom + " and loai=" + i_loai + " order by stt").Tables[0];
                    cb.SelectedIndex = -1;
                    p.Controls.Add(dt);
                    p.Controls.Add(cb);
                    t += 23;
                }
            }
		}

        private void xem_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==xem) banin.Enabled=!xem.Checked;
        }

        private void capnhat_d_ngayduyet(string mmyy, string tu, string den, int loai, int phieu, int makp )
        {
            string tbl_ct = (loai == 2) ? "d_bucstt" : "d_xuatsdct";
            string asql = " select distinct nhom, loai, makp, to_char(ngay,'dd/mm/yyyy') as ngay, idduyet, phieu, b.makho, b.sttduyet, to_char(a.ngayylenh,'dd/mm/yyyy') as ngayylenh ";
            asql += " from xxx.d_xuatsdll a inner join xxx." + tbl_ct + " b on a.id=b.id where a.loai=" + loai + " and a.phieu=" + phieu + " and a.makp=" + makp;
            asql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy')";
            //asql += " order by a.idduyet, b.sttduyet ";
            DataSet lds = d.get_data_mmyy(asql, tu, den, true);
            string s_idduyet = "", s_sttduyet = "", s_makho = "", s_ngay = "", s_nhom = "", s_ngayyl1 = "", s_ngayyl2 = "", s_phieu_xtt = ",", s_makp_xtt = ",";
            int tmp_makho=0;
            foreach (DataRow r in lds.Tables[0].Select("true", "idduyet,sttduyet"))
            {
                if (s_phieu_xtt.IndexOf("," + r["phieu"].ToString() + ",") < 0) s_phieu_xtt += r["phieu"].ToString() + ",";
                if (s_makp_xtt.IndexOf("," + r["makp"].ToString() + ",") < 0) s_makp_xtt += r["makp"].ToString() + ",";
                if (s_ngayyl1 == "") s_ngayyl1 = r["ngayylenh"].ToString();
                else
                {
                    if (m.StringToDate(s_ngayyl1) > m.StringToDate(r["ngayylenh"].ToString()))
                        s_ngayyl1 = r["ngayylenh"].ToString();
                }
                if (s_ngayyl2 == "") s_ngayyl2 = r["ngayylenh"].ToString();
                else
                {
                    if (m.StringToDate(s_ngayyl2) < m.StringToDate(r["ngayylenh"].ToString()))
                        s_ngayyl2 = r["ngayylenh"].ToString();
                }
                //
                if (s_idduyet != r["idduyet"].ToString())
                {
                    if (s_sttduyet != "") d.upd_ngayduyet(mmyy, int.Parse(s_nhom), loai, phieu, makp, s_ngay, decimal.Parse(s_idduyet), s_makho, s_sttduyet);
                    s_sttduyet = "";
                    s_idduyet = r["idduyet"].ToString();
                    // gam 09-03-2011 nếu xuất tủ trực thì cập nhật lại bảng d_thucxuat
                    // binh sua lai: 28/04/11 --> 
                    if (loai == 2)
                    {
                        asql = "  select a.id, b.sttt, b.madoituong, b.makho, b.mabd, b.soluong, b.giaban, b.stt, b.gia_bh ";
                        asql += " from xxx.d_xuatsdll a inner join xxx.d_xuatsdct b on a.id=b.id left join xxx.d_thucxuat c on b.id=c.id and b.stt=c.stt where a.loai=" + loai;
                        asql += " and c.id is null ";
                        asql += " and a.idduyet=" + r["idduyet"].ToString();
                        //if (s_phieu_xtt.Trim().Trim(',') != "") asql += " and a.phieu in(" + s_phieu_xtt.Trim().Trim(',') + ")";// +phieu;
                        //if (s_makp_xtt.Trim().Trim(',') != "") asql += " and a.makp in(" + s_makp_xtt.Trim().Trim(',') + ")";// makp;                    
                        //asql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_ngayyl1 + "','dd/mm/yyyy') and to_date('" + s_ngayyl2 + "','dd/mm/yyyy')";
                        DataSet lds1 = d.get_data_mmyy(asql, tu, den, true);
                        foreach (DataRow r1 in lds1.Tables[0].Rows)
                        {
                            //binh comment 280411
                            //d.upd_thucxuat(mmyy, decimal.Parse(r["id"].ToString()), decimal.Parse(r["sttt"].ToString()), 
                            //    int.Parse(r["madoituong"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["mabd"].ToString()), 
                            //    decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["giaban"].ToString()));
                            //binh sua 280411
                            d.upd_thucxuat_stt(mmyy, decimal.Parse(r1["id"].ToString()), decimal.Parse(r1["sttt"].ToString()),
                                int.Parse(r1["madoituong"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()),
                                decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["stt"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["gia_bh"].ToString()));
                        }
                    }
                    //
                }
                s_sttduyet += r["sttduyet"].ToString() + ",";
                s_ngay = r["ngay"].ToString();
                s_nhom = r["nhom"].ToString();
                // 
                d.upd_daduyet(mmyy, int.Parse(s_nhom), s_ngay, makp, i_loai, phieu, int.Parse(r["makho"].ToString()));
                tmp_makho=int.Parse(r["makho"].ToString());
            }
            if (s_sttduyet != "")
            {
                d.upd_ngayduyet(mmyy, int.Parse(s_nhom), loai, phieu, makp, s_ngay, decimal.Parse(s_idduyet), s_makho, s_sttduyet);
                d.upd_daduyet(mmyy, int.Parse(s_nhom), s_ngay, makp, i_loai, phieu, tmp_makho);
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            capnhat_d_ngayduyet(s_mmyy, tu.Text, den.Text, i_loai, int.Parse(phieu.SelectedValue.ToString()), int.Parse(makp.SelectedValue.ToString()));
        }

        private void chkChuyenXuatSDCT_Thucxuat_CheckedChanged(object sender, EventArgs e)
        {

        }
        //binh 110413
        private void Chuyen_Xuatsdct_Thucxuat( string a_mmyy, string a_ngay, int a_phieu, int a_makp)
        {
            return;// tam thoi khong dung nua: binh 05.03.2014
            bool bPhattron = d.bPhattron(i_nhom);
            bool b1kho = d.b1kho(s_kho);
            if (bPhattron)
            {
                if (i_loai != 3)
                {
                    sql = " delete from " + user + a_mmyy + ".d_thucxuat where id in(select id from " + user+a_mmyy + ".d_xuatsdll where loai=" + i_loai + " and makp=" + a_makp + " and phieu=" + a_phieu + " and to_char(ngay,'dd/mm/yyyy')='" + a_ngay + "')";
                    d.execute_data(sql);
                    //
                    d.upd_kiemtra(a_mmyy, i_nhom);
                    //
                    //sql = "select b.*,c.handung,c.losx,c.manguon,c.nhomcc,c.giamua, b.gia_bh ";
                    //sql += " from " + user + s_mmyy + ".d_xuatsdll a," + user + a_mmyy + ".d_xuatsdct b," + user + a_mmyy + ".d_theodoi c ";
                    //sql += " where a.id=b.id and b.sttt=c.id and a.nhom=" + i_nhom + " and a.loai=" + i_loai;
                    //sql += " and a.phieu=" + a_phieu + " and to_char(a.ngay,'dd/mm/yyyy')='" + a_ngay + "' and a.makp=" + a_makp;
                    //foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                    //{
                    //    if (i_loai == 2)
                    //        d.upd_tonkhoct_thucbucstt(d.delete, a_mmyy, a_makp, decimal.Parse(r["sttt"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), int.Parse(r["mabd"].ToString()), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()));
                    //    else
                    //        d.upd_tonkhoct_thucxuat(d.delete, a_mmyy, a_makp, i_loai, 1, decimal.Parse(r["sttt"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["mabd"].ToString()), decimal.Parse(r["soluong"].ToString()));
                    //}
                }
                d.upd_thucxuat(a_ngay, i_nhom, i_loai, a_phieu, a_makp, a_makp, s_mmyy, 1, 0);
            }
        }

        //binh 110413
        private void Chuyen_bucstt_Thucbucstt(string a_mmyy, string a_ngay, int a_phieu, int a_makp)
        {
            return;// tam thoi khong dung nua: binh 05.03.2014
            bool bPhattron = d.bPhattron(i_nhom);
            bool b1kho = d.b1kho(s_kho);
            if (bPhattron)
            {
                if (i_loai == 2)
                {
                    sql = " delete from " + user + a_mmyy + ".d_thucbucstt where id in(select id from " + user + a_mmyy + ".d_xuatsdll where loai=" + i_loai + " and makp=" + a_makp + " and phieu=" + a_phieu + " and to_char(ngay,'dd/mm/yyyy')='" + a_ngay + "')";
                    d.execute_data(sql);
                    //
                    d.upd_kiemtra(a_mmyy, i_nhom);
                    //                    
                }                
                d.upd_thucbucstt(a_ngay, i_nhom, i_loai, a_phieu, a_makp, a_makp, s_mmyy,0);
            }
        }

        private void frmInphieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control && e.Shift && e.Alt)
            {

                //chkChuyenXuatSDCT_Thucxuat.Visible = !chkChuyenXuatSDCT_Thucxuat.Visible;
                //if (chkChuyenXuatSDCT_Thucxuat.Visible == false) chkChuyenXuatSDCT_Thucxuat.Checked = false;

            }
        }
	}
}
